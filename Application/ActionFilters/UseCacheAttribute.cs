﻿using Application.Cache;
using DataAccess.Entities;
using Domain.Models;
using Domain.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ActionFilters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class UseCacheAttribute : ActionFilterAttribute
    {
        private readonly int _timeToLiveSeconds;

        public UseCacheAttribute(int timeToLiveSeconds)
        {
            _timeToLiveSeconds = timeToLiveSeconds;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var cacheSettings = context.HttpContext.RequestServices.GetRequiredService<RedisCacheSettings>();
            if (!cacheSettings.Enabled)
            {
                await ExecuteNextAsync(next);
                return;
            }

            var cacheService = context.HttpContext.RequestServices.GetRequiredService<IResponseCacheService>();
            var cacheKey = GenerateCacheKeyFromRequest(context.HttpContext.Request);
            var cachedResponse = await cacheService.GetCacheResponseAsync(cacheKey);

            if (cachedResponse != null)
            {
                context.Result = new OkObjectResult(cachedResponse);
                return;
            }

            var executedContext = await ExecuteNextAsync(next);
            if (executedContext.Result is OkObjectResult okObjectResult)
            {
                var valueType = okObjectResult.Value.GetType();
                if (valueType.GetInterfaces().Contains(typeof(IEnumerable)) && valueType.GetGenericArguments().Any())
                {
                    okObjectResult.Value = (okObjectResult.Value as IEnumerable<object>)
                        .Select(item => item
                        .GetType()
                        .GetProperty(nameof(DomainModel<Guild>.Entity))
                        .GetValue(item))
                        .ToList();
                }

                await cacheService.CacheResponseAsync(cacheKey, okObjectResult.Value, timeToLive: TimeSpan.FromSeconds(_timeToLiveSeconds));
            }
        }

        private async Task<ActionExecutedContext> ExecuteNextAsync(ActionExecutionDelegate next)
        {
            var executedContext = await next();
            var valueProperty =  executedContext.Result.GetType().GetProperty("Value");
            var value = valueProperty?.GetValue(executedContext.Result);
            var validationMethod = value?.GetType().GetMethod(nameof(DomainModel<Guild>.Validate));
            var validation = validationMethod?.Invoke(value, null);
            
            if (validation is IValidationResult)
            {
                if (validation is ErrorValidationResult errorResult)
                {
                    executedContext.HttpContext.Response.StatusCode = (int) errorResult.Status;
                    executedContext.Result = errorResult.AsErrorActionResult();
                }
                else
                {
                    var entityValue = value.GetType().GetProperty(nameof(DomainModel<Guild>.Entity))?.GetValue(value);
                    executedContext.Result.GetType().GetProperty("Value")?.SetValue(executedContext.Result, entityValue);
                }
            }
            return executedContext;
        }

        private static string GenerateCacheKeyFromRequest(HttpRequest request)
        {
            var cacheKeyBuilder = new StringBuilder(request.Path);

            if (request.Query.Any())
            {
                cacheKeyBuilder = request.Query
                    .OrderBy(q => q.Key)
                    .Aggregate(
                        cacheKeyBuilder,
                        (orderedQueryBuilder, currentQueryStringPair) =>
                        {
                            var previousFullValue = orderedQueryBuilder.Append(orderedQueryBuilder.ToString() == request.Path.ToString() ? "?" : "&").ToString();
                            orderedQueryBuilder.Clear().Append($"{previousFullValue}{currentQueryStringPair.Key}={currentQueryStringPair.Value}");
                            return orderedQueryBuilder;
                        });
            }

            cacheKeyBuilder = request.Headers
                .Where(header => !string.IsNullOrWhiteSpace(header.Value) && !header.Key.ToLowerInvariant().Contains("token"))
                .Aggregate(cacheKeyBuilder, (headerBuilder, header) => headerBuilder.Append($"|{header.Key}={header.Value}"));

            return cacheKeyBuilder.ToString();
        }
    }
}

﻿using Business.Responses;
using Business.Usecases.Members.ListMember;
using Domain.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Tests.Business.Usecases.Members.ListMember;
using Tests.Helpers;
using Tests.Helpers.Builders;
using Xunit;

namespace Tests.Business.Usecases.Members.GetMember
{
    [Trait("Business", "Handler")]
    public class ListMemberHandlerTests
    {
        [Fact]
        public async Task Handle_Should_Succeed_With_ValidCommand()
        {
            // arrange
            var expectedPage = new Random().Next(1, 5);
            var expectedPages = new Random().Next(expectedPage, expectedPage + 1);
            var expectedPageSize = new Random().Next(5, 10);
            var command = ListMemberCommandFake.Valid(pageSize: expectedPageSize, page: expectedPage).Generate();
            var repository = MemberRepositoryMockBuilder.Create().Paginate(
                pageSize: command.PageSize,
                page: command.Page,
                totalItems: command.PageSize * expectedPages).Build();
            var mapper = MapperConfig.Configuration.CreateMapper();
            var sut = new ListMemberHandler(repository);

            // act
            var result = await sut.Handle(command, default);

            // assert
            result.Should().NotBeNull().And.BeOfType<ApiResult>();
            result.Success.Should().BeTrue();
            result.Errors.Should().BeEmpty();
            result.As<ApiResult>().StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Data.Should().NotBeNull().And.BeOfType<Pagination<Member>>();
            result.Data.As<Pagination<Member>>().Items.Should().NotBeEmpty()
                .And.AllBeAssignableTo<Member>()
                .And.HaveCount(expectedPageSize)
                .And.HaveCount(command.PageSize);
            result.Data.As<Pagination<Member>>().PageSize.Should().Be(expectedPageSize)
                .And.Be(command.PageSize);
            result.Data.As<Pagination<Member>>().Page.Should().Be(expectedPage)
                .And.Be(command.Page);
            result.Data.As<Pagination<Member>>().Pages.Should().Be(expectedPages);
        }
    }
}

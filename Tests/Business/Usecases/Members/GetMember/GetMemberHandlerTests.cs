﻿using Business.Dtos;
using Business.Responses;
using Business.Usecases.Members.GetMember;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Tests.Domain.Models.Fakes;
using Tests.Helpers;
using Tests.Helpers.Builders;
using Xunit;

namespace Tests.Business.Usecases.Members.GetMember
{
    [Trait("Business", "Handler")]
    public class GetMemberHandlerTests
    {
        [Fact]
        public async Task Handle_Should_Succeed_With_ValidCommand()
        {
            // arrange
            var expectedMember = MemberFake.GuildLeader().Generate();
            var command = GetMemberCommandFake.Valid(expectedMember.Id).Generate();
            var repository = MemberRepositoryMockBuilder.Create()
                .GetByIdSuccess(input: command.Id, output: expectedMember).Build();
            var mapper = MapperConfig.Configuration.CreateMapper();
            var sut = new GetMemberHandler(repository, mapper);

            // act
            var result = await sut.Handle(command, default);

            // assert
            result.Should().NotBeNull().And.BeOfType<ApiResult>();
            result.Success.Should().BeTrue();
            result.Errors.Should().BeEmpty();
            result.As<ApiResult>().StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Data.Should().NotBeNull().And.BeOfType<MemberDto>();
            result.Data.As<MemberDto>().Id.Should().Be(expectedMember.Id);
            result.Data.As<MemberDto>().Guild.Id.Should().Be(expectedMember.GuildId.Value);
        }
    }
}

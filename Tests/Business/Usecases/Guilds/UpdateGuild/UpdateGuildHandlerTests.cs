﻿using Business.Responses;
using Business.Usecases.Guilds.UpdateGuild;
using Domain.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Tests.Business.Usecases.Guilds.UpdateGuild;
using Tests.Domain.Models.Fakes;
using Tests.Helpers.Builders;
using Xunit;

namespace Tests.Business.Usecases.Members.UpdateGuild
{
    [Trait("Business", "Handler")]
    public class UpdateGuildHandlerTests
    {
        [Fact]
        public async Task Handle_Should_Succeed_With_ValidCommand()
        {
            // arrange
            var otherMembersCount = new Random().Next(1, 5);
            var expectedGuild = GuildFake.WithGuildLeaderAndMembers(otherMembersCount: otherMembersCount).Generate();
            var expectedLeader = expectedGuild.Vice;
            var expectedVice = expectedGuild.Leader;
            var command = UpdateGuildCommandFake.Valid(
                id: expectedGuild.Id,
                masterId: expectedLeader.Id,
                name: expectedGuild.Name).Generate();
            var guildRepository = GuildRepositoryMockBuilder.Create()
                .GetByIdSuccess(command.Id, expectedGuild)
                .Update(expectedGuild, expectedGuild).Build();
            var memberRepository = MemberRepositoryMockBuilder.Create()
                .Update(expectedLeader, expectedLeader)
                .Update(expectedVice, expectedVice)
                .Build();
            var sut = new UpdateGuildHandler(guildRepository, memberRepository);

            // act
            var result = await sut.Handle(command, default);

            // assert
            result.Should().NotBeNull().And.BeOfType<ApiResult>();
            result.Success.Should().BeTrue();
            result.Errors.Should().BeEmpty();
            result.As<ApiResult>().StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Data.Should().NotBeNull().And.BeOfType<Guild>();
            result.Data.As<Guild>().Name.Should().Be(expectedGuild.Name);
            result.Data.As<Guild>().Id.Should().Be(expectedGuild.Id);
            result.Data.As<Guild>().Leader.Id.Should().Be(expectedLeader.Id);
            result.Data.As<Guild>().Members.Should().NotBeEmpty()
                .And.HaveCount(otherMembersCount + 1)
                .And.Contain(x => x.Id == expectedLeader.Id)
                .And.Contain(x => x.Id == expectedVice.Id);
        }
    }
}

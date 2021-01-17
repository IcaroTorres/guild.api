﻿using Business.Dtos;
using Business.Responses;
using Business.Usecases.Members.DemoteMember;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Tests.Domain.Models.Fakes;
using Tests.Helpers;
using Tests.Helpers.Builders;
using Xunit;

namespace Tests.Business.Usecases.Members.DemoteMember
{
    [Trait("Business", "Handler")]
    public class DemoteMemberHandlerTests
    {
        [Fact]
        public async Task Handle_Should_Succeed_With_ValidCommand()
        {
            // arrange
            var demotedMember = MemberFake.GuildLeader().Generate();
            var guild = demotedMember.Guild;
            var expectedLeader = demotedMember.Guild.Vice;
            var command = PatchMemberCommandFake.DemoteMemberValid(demotedMember.Id).Generate();
            var memberRepository = MemberRepositoryMockBuilder.Create()
                .GetForGuildOperationsSuccess(command.Id, demotedMember)
                .Update(demotedMember, demotedMember)
                .Update(expectedLeader, expectedLeader)
                .Build();
            var mapper = MapperConfig.Configuration.CreateMapper();
            var sut = new DemoteMemberHandler(memberRepository, mapper);

            // act
            var result = await sut.Handle(command, default);

            // assert
            result.Should().NotBeNull().And.BeOfType<ApiResult>();
            result.Success.Should().BeTrue();
            result.Errors.Should().BeEmpty();
            result.As<ApiResult>().StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Data.Should().NotBeNull().And.BeOfType<MemberDto>();
            result.Data.As<MemberDto>().Id.Should().Be(demotedMember.Id);
            result.Data.As<MemberDto>().IsGuildLeader.Should().BeFalse()
                .And.Be(!expectedLeader.IsGuildLeader);
            result.Data.As<MemberDto>().Guild.Should().NotBeNull();
            result.Data.As<MemberDto>().Guild.Id.Should().Be(guild.Id);
        }
    }
}

using Domain.DTOs;
using DataAccess.Entities;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Domain.Models;

namespace Services
{
    public interface IMemberService
    {
        MemberModel Get(Guid id, bool readOnly = false);
        MemberModel Create(MemberDto payload);
        MemberModel Update(MemberDto payload, Guid id);
        MemberModel Patch(Guid id, JsonPatchDocument<Member> payload);
        MemberModel Promote(Guid id);
        MemberModel Demote(Guid id);
        MemberModel LeaveGuild(Guid id);
        MemberModel Delete(Guid id);
        IReadOnlyList<MemberModel> List(MemberFilterDto payload);
    }
}
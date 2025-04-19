using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class MemberFactory
{
    //public static Member ToModel(MemberEntity entity)
    //{
    //    return entity == null
    //        ? null!
    //        : new Member
    //        {

    //            Id = entity.Id,
    //            FirstName = entity.FirstName,
    //            LastName = entity.LastName,

    //        };
    //}
    //public static MemberEntity ToEntity(EditMemberForm formData)
    //{
    //    return formData == null
    //        ? null!
    //        : new MemberEntity
    //        {
    //            Id = Guid.NewGuid().ToString(),
    //            FirstName = formData.FirstName,
    //            LastName = formData.LastName,
    //            Email = formData.Email,
    //            Phone = formData.Phone,
    //            JobbTitle = formData.JobbTitle,
    //            MemberRole = formData.MemberRole,
    //            Address = formData.Andress,
    //            PostalCode = formData.PostalCode,
    //            City = formData.City

    //        };
    //}

    //public static MemberEntity ToEntity(AddMemberForm formData)
    //{
    //    return formData == null
    //        ? null!
    //        : new MemberEntity
    //        {
    //            Id = Guid.NewGuid().ToString(),
    //            FirstName = formData.FirstName,
    //            LastName = formData.LastName,
    //            Email = formData.Email,
    //            Phone = formData.Phone,
    //            JobbTitle = formData.JobbTitle,
    //            MemberRole = formData.MemberRole,
    //            Address = formData.Andress,
    //            PostalCode = formData.PostalCode,
    //            City = formData.City

    //        };
    //}
}

using Business.Factories;
using Business.Models;
using Data.Repositories;

namespace Business.Services;

public interface IMemberService
{
    Task<Member?> GetMemberByMemberIdAsync(string id);
    Task<IEnumerable<Member>> GetMembersAsync();
}

public class MemberService(IMemberRepository memberRepository) : IMemberService
{
    private readonly IMemberRepository _memberRepository = memberRepository;

    public async Task<IEnumerable<Member>> GetMembersAsync()
    {
        var entities = await _memberRepository.GetAllAsync(sortBy: x => x.FirstName);
        var members = entities.Select(member => new Member
        {
            Id = member.Id,
            FirstName = member.FirstName,
            LastName = member.LastName,
        });
        return members;
    }
    public async Task<Member?> GetMemberByMemberIdAsync(string id)
    {
        var entity = await _memberRepository.GetAsync(x => x.Id == id);
        return entity == null ? null : new Member
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
        };


    }
    //public async Task<bool> CreateMemberAsync(AddMemberForm form)
    //{
    //    if (form == null)
    //        return false;

    //    var memberEntity = MemberFactory.ToEntity(form);

    //    var result = await _memberRepository.AddAsync(memberEntity);
    //    return result;
    //}
    //public async Task<bool> UpdateMemberAsync(EditMemberForm form)
    //{
    //    if (form == null)
    //        return false;

    //    var memberEntity = ProjectFactory.ToEntity(form);
    //    var result = await _memberRepository.UpdateAsync(memberEntity);
    //    return result;
    //}

    public async Task<bool> DeleteMemberAsync(string id)
    {
        return await _memberRepository.DeleteAsync(x => x.Id == id);
    }
}


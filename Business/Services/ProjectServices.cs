using Business.Factories;
using Business.Models;
using Data.Entities;
using Data.Repositories;
using System.Linq.Expressions;

namespace Business.Services;

public interface IProjectService
{
    Task<bool> CreateProjectAsync(AddProjectForm form);
    Task<bool> DeleteProjectAsync(string id);
    Task<IEnumerable<Project>> GetProjectAsync(Data.Entities.Status? status = null, bool orderByDescending = true);
    Task<Project> GetProjectByIdAsync(string id);
    Task<bool> UpdateProjectAsync(EditProjectForm form);
}

public class ProjectService(IProjectRepository projectRepository, IClientRepository clientRepository, IMemberRepository memberRepository) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IClientRepository _clientRepository = clientRepository;
    private readonly IMemberRepository _memberRepository = memberRepository;

    public async Task<IEnumerable<Project>> GetProjectAsync(Data.Entities.Status? status = null, bool orderByDescending = true)
    {
        Expression<Func<ProjectEntity, bool>>? filter = status.HasValue
            ? (p => p.Status == status.Value)
            : null;


        var entities = await _projectRepository.GetAllAsync(
            orderByDescending: orderByDescending,
            sortBy: x => x.Created,
            filterBy: filter,
            i => i.Client,
            i => i.Member
            );
        var projects = entities.Select(ProjectFactory.ToModel);
        return projects;
    }

    public async Task<Project> GetProjectByIdAsync(string id)
    {
        var entity = await _projectRepository.GetAsync(

            x => x.Id == id,
            i => i.Client,
            i => i.Member
            );
        return ProjectFactory.ToModel(entity);
    }

    public async Task<bool> CreateProjectAsync(AddProjectForm form)
    {
        if (form == null)
            return false;
        var client = await _clientRepository.GetAsync(x => x.ClientName.ToLower() == form.ClientName.ToLower());
        var member = await _memberRepository.GetAsync(x => (x.FirstName).ToLower() == form.MemberFirstName.ToLower() && (x.LastName).ToLower()== form.MemberLastName.ToLower());
        if (client == null || member == null)
        {
            return false;
        }

        var projectEntity = ProjectFactory.ToEntity(form, client.Id, member.Id);

        var result = await _projectRepository.AddAsync(projectEntity);
        return result;
    }
    public async Task<bool> UpdateProjectAsync(EditProjectForm form)
    {
        if (form == null)
            return false;
        var client = await _clientRepository.GetAsync(x => x.ClientName.ToLower() == form.ClientName.ToLower());
        var member = await _memberRepository.GetAsync(x => (x.FirstName).ToLower() == form.MemberFirstName.ToLower() && (x.LastName).ToLower() == form.MemberLastName.ToLower());
        if (client == null || member == null)
        {
            return false;
        }

        var projectEntity = ProjectFactory.ToEntity(form, client.Id, member.Id);
        var result = await _projectRepository.UpdateAsync(projectEntity);
        return result;
    }

    public async Task<bool> DeleteProjectAsync(string id)
    {
        return await _projectRepository.DeleteAsync(x => x.Id == id);
    }
}

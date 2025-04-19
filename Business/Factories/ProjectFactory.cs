using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class ProjectFactory
{
    public static Project ToModel(ProjectEntity entity)
    {
        return entity == null
            ? null!
            : new Project
            {
                Id = entity.Id,
                ProjectName = entity.ProjectName,
                Description = entity.Description,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                Status = (Models.Status)entity.Status,
                Budget= entity.Budget,
                Client = new Client
                {
                    Id = entity.Client.Id,
                    ClientName = entity.Client.ClientName,
                },
                Member = new Member
                {
                    Id = entity.Member.Id,
                    FirstName = entity.Member.FirstName,
                    LastName = entity.Member.LastName,
                },
                
            };
    }
    public static ProjectEntity ToEntity(EditProjectForm formData, string clientId, string memberId)
    {
        return formData == null
            ? null!
            : new ProjectEntity
            {
                Id = formData.Id,
                ProjectName = formData.ProjectName,
                Description = formData.Description,
                StartDate = formData.StartDate,
                EndDate = formData.EndDate,
                Budget= formData.Budget,
                ClientId = clientId,
                MemberId = memberId,
                Status = (Data.Entities.Status)formData.Status,

            };
    }

    public static ProjectEntity ToEntity(AddProjectForm formData, string clientId, string memberId)
    {
        return formData == null
            ? null!
            : new ProjectEntity
            {
                Id = Guid.NewGuid().ToString(),
                ProjectName = formData.ProjectName,
                Description = formData.Description,
                StartDate = formData.StartDate,
                EndDate = formData.EndDate,
                Budget = formData.Budget,
                ClientId = clientId,
                MemberId = memberId,
                Status = Data.Entities.Status.Started,
            };
    }
}

using Data.Context;
using Data.Entities;
namespace Data.Repositories;
public interface IProjectRepository : IBaseRepository<ProjectEntity>
{

}

public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context), IProjectRepository
{
}

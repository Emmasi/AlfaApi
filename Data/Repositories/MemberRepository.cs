using Data.Context;
using Data.Entities;
namespace Data.Repositories;
public interface IMemberRepository : IBaseRepository<MemberEntity>
{

}

public class MemberRepository(DataContext context) : BaseRepository<MemberEntity>(context), IMemberRepository
{
}

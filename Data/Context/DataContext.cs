using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public class DataContext(DbContextOptions<DataContext> option) : DbContext(option)
{
    public virtual DbSet<ClientAddressEntity> ClientAddress { get; set; }
    public virtual DbSet<ClientEntity> Client { get; set; }
    public virtual DbSet<ClientInformationEntity> ClientInformation { get; set; }
    public virtual DbSet<MemberEntity> Member { get; set; }
    public virtual DbSet<ProjectEntity> Projects { get; set; }
}

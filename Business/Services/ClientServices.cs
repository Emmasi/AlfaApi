using Business.Models;
using Data.Repositories;

namespace Business.Services;

public interface IClientService
{
    Task<IEnumerable<Client>> GetClientsAsync();
    Task<Client?> GetClientByClientNamedAsync(string clientName);
}

public class ClientService(IClientRepository clientRepository) : IClientService
{
    private readonly IClientRepository _clientRepository = clientRepository;
    public async Task<IEnumerable<Client>> GetClientsAsync()
    {
        var entities = await _clientRepository.GetAllAsync(sortBy: x => x.ClientName);
        var statuses = entities.Select(entity => new Client
        {
            Id = entity.Id,
            ClientName = entity.ClientName,
        });
        return statuses;
    }
    public async Task<Client?> GetClientByClientNamedAsync(string clientName)
    {
        var entity = await _clientRepository.GetAsync(x => x.ClientName == clientName);
        return entity == null ? null : new Client
        {
            Id = entity.Id,
            ClientName = entity.ClientName,
        };

    }
}



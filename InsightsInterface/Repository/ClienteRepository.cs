using MongoDB.Driver;

public interface IClienteRepository
{
    Task<List<Cliente>> GetAllAsync();
    Task<Cliente?> GetByIdAsync(string id);
    Task CreateAsync(Cliente cliente);
    Task UpdateAsync(string id, Cliente cliente);
    Task DeleteAsync(string id);
}

public class ClienteRepository : IClienteRepository
{
    private readonly IMongoCollection<Cliente> _clientes;

    public ClienteRepository(IMongoDatabase database)
    {
        _clientes = database.GetCollection<Cliente>("cliente");
    }

    public async Task<List<Cliente>> GetAllAsync()
    {
        return await _clientes.Find(_ => true).ToListAsync();
    }

    public async Task<Cliente?> GetByIdAsync(string id)
    {
        var objectId = new string(id);
        return await _clientes.Find(c => c.Id == objectId).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(Cliente cliente)
    {
        await _clientes.InsertOneAsync(cliente);
    }

    public async Task UpdateAsync(string id, Cliente cliente)
    {
        var objectId = new string(id);
        cliente.Id = objectId;
        await _clientes.ReplaceOneAsync(c => c.Id == objectId, cliente);
    }

    public async Task DeleteAsync(string id)
    {
        var objectId = new string(id);
        await _clientes.DeleteOneAsync(c => c.Id == objectId);
    }
}

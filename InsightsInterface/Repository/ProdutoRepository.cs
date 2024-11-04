using MongoDB.Driver;

public interface IProdutoRepository
{
    Task<List<Produto>> GetAllAsync();
    Task<Produto?> GetByIdAsync(string id);
    Task CreateAsync(Produto produto);
    Task UpdateAsync(string id, Produto produto);
    Task DeleteAsync(string id);
}

public class ProdutoRepository : IProdutoRepository
{
    private readonly IMongoCollection<Produto> _produtos;

    public ProdutoRepository(IMongoDatabase database)
    {
        _produtos = database.GetCollection<Produto>("produto");
    }

    public async Task<List<Produto>> GetAllAsync()
    {
        return await _produtos.Find(_ => true).ToListAsync();
    }


    public async Task<Produto?> GetByIdAsync(string id)
    {
        var objectId = new string(id);
        return await _produtos.Find(p => p.Id == objectId).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(Produto produto)
    {
        await _produtos.InsertOneAsync(produto);
    }

    public async Task UpdateAsync(string id, Produto produto)
    {
        var objectId = new string(id);
        produto.Id = objectId;
        await _produtos.ReplaceOneAsync(p => p.Id == objectId, produto);
    }

    public async Task DeleteAsync(string id)
    {
        var objectId = new string(id);
        await _produtos.DeleteOneAsync(p => p.Id == objectId);
    }
}

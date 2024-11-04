using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

[BsonIgnoreExtraElements]
public class Cliente
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    [BsonElement("nome")]
    public string Nome { get; set; } = null!;

    [BsonElement("email")]
    public string Email { get; set; } = null!;

    [BsonElement("telefone")]
    public string Telefone { get; set; } = null!;

    [BsonElement("genero")]
    public string Genero { get; set; } = null!;

    [BsonElement("interesses")]
    public List<string> Interesses { get; set; } = new();

    [BsonElement("endereco")]
    public Endereco Endereco { get; set; } = null!;

    [BsonElement("dataNascimento")]
    public DateOnly DataNascimento { get; set; }

    [BsonElement("cpf")]
    public string Cpf { get; set; } = null!;

    [BsonElement("dataCadastro")]
    public DateOnly DataCadastro { get; set; }

    [BsonElement("ativo")]
    public bool Ativo { get; set; }
}

public class Endereco
{
    [BsonElement("rua")]
    public string Rua { get; set; } = null!;

    [BsonElement("numero")]
    public int Numero { get; set; }

    [BsonElement("cidade")]
    public string Cidade { get; set; } = null!;

    [BsonElement("estado")]
    public string Estado { get; set; } = null!;

    [BsonElement("cep")]
    public string Cep { get; set; } = null!;
}

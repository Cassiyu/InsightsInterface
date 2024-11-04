using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

[BsonIgnoreExtraElements]
public class Produto
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    [BsonElement("nome")]
    public string Nome { get; set; } = null!;

    [BsonElement("descricao")]
    public string Descricao { get; set; } = null!;

    [BsonElement("preco")]
    public decimal Preco { get; set; }

    [BsonElement("peso")]
    public string Peso { get; set; } = null!;

    [BsonElement("cor")]
    public string Cor { get; set; } = null!;

    [BsonElement("estoque")]
    public int Estoque { get; set; }

    [BsonElement("categoria")]
    public string Categoria { get; set; } = null!;

    [BsonElement("fornecedor")]
    public string Fornecedor { get; set; } = null!;

    [BsonElement("dataAdicao")]
    public DateOnly DataAdicao { get; set; }
}

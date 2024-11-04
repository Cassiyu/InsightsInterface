using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

[BsonIgnoreExtraElements]
public class Feedback
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    [BsonElement("clienteNome")]
    public string ClienteNome { get; set; } = null!;

    [BsonElement("produtoNome")]
    public string ProdutoNome { get; set; } = null!;

    [BsonElement("dataFeedback")]
    public DateOnly DataFeedback { get; set; }

    [BsonElement("avaliacao")]
    public int Avaliacao { get; set; }

    [BsonElement("comentario")]
    public string Comentario { get; set; } = null!;

    [BsonElement("classificacaoLoja")]
    public int ClassificacaoLoja { get; set; }

    [BsonElement("tempoUso")]
    public int TempoUso { get; set; }

    [BsonElement("tipoUso")]
    public string TipoUso { get; set; } = null!;

    [BsonElement("recomenda")]
    public bool Recomenda { get; set; }
}

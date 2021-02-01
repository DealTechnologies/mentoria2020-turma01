using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Livraria.Domain.Queries.Livro
{
    public class LivroQueryResult
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get;  set; }
        public string Nome { get;  set; }
        public string Autor { get;  set; }
        public int Edicao { get;  set; }
        public string Isbn { get;  set; }
        public string Imagem { get;  set; }
    }
}

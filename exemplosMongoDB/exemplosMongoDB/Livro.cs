using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace exemplosMongoDB
{
    public class Livro
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Ano { get; set; }
        public int Paginas { get; set; }
        public List<string> Assunto { get; set; }
    }

    public class ValoresLivro
    {
        public static Livro incluiValoresLivro(string Titulo, string Autor, int Ano, int Paginas, string assuntos)
        {
            Livro livro = new Livro()
            {
                Titulo = Titulo,
                Autor = Autor,
                Ano = Ano,
                Paginas = Paginas
            };
            string[] vetAssuntos = assuntos.Split(',');
            List<string> vetAssuntos2 = new List<string>();
            for (int i = 0; i <= vetAssuntos.Length - 1; i++)
            {
                vetAssuntos2.Add(vetAssuntos[i].Trim());
            }
            livro.Assunto = vetAssuntos2;
            return livro;
        }
    }
}

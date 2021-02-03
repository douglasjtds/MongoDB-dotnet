using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace exemplosMongoDB
{
    class AcessandoMongoDB
    {
        static void Main(string[] args)
        {
            Task T = MainAsync(args);
            Console.WriteLine("Pressione ENTER");
            Console.ReadLine();
        }

        static async Task MainAsync(string[] args)
        {
            //{
            //    "Titulo":"Guerra dos Tronos",
            //    "Autor":"George R R Martin",
            //    "Ano":1999,
            //    "Páginas":856
            //    "Assunto": [
            //        "Fantasia",
            //        "Ação"
            //]
            //}
            var doc = new BsonDocument
            {
                {"Titulo",  "Guerra dos Tronos"}
            };
            doc.Add("Autor", "George R R Martin");
            doc.Add("Ano", 1999);
            doc.Add("Páginas", 856);

            var assuntoArray = new BsonArray
            {
                "Fantasia",
                "Ação"
            };

            doc.Add("Assunto", assuntoArray);

            Console.WriteLine(doc);

            //acesso ao servidor do MongoDB
            string stringConexao = "mongodb://localhost:27017";

            IMongoClient cliente = new MongoClient(stringConexao);

            //acesso ao banco de dados
            IMongoDatabase bancoDados = cliente.GetDatabase("Biblioteca");

            //acesso à coleção
            IMongoCollection<BsonDocument> collection = bancoDados.GetCollection<BsonDocument>("Livros");

            //incluindo documento
            await collection.InsertOneAsync(doc);
            Console.WriteLine("Documento incluido.");
        }
    }
}

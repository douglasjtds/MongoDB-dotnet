using exemplosMongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace exemploMongoDB
{
    class ListandoDocumentos
    {
        static void Main(string[] args)
        {
            Task T = MainAsync(args);
            Console.WriteLine();
            Console.WriteLine("Pressione Enter");
            Console.ReadLine();
        }
        static async Task MainAsync(string[] args)
        {
            var conexaoBiblioteca = new ConectandoMongoDB();
            Console.WriteLine("Listando Documentos");

            var listaLivros = await conexaoBiblioteca.Livros.Find(new BsonDocument()).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            Console.WriteLine("Fim da Lista");
        }
    }
}
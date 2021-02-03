using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;


namespace exemplosMongoDB
{
    class ListandoDocumentosOrdem
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
            Console.WriteLine("Listando Documentos com mais de 100 páginas");

            var construtor = Builders<Livro>.Filter;
            var condicao = construtor.Gte(x => x.Paginas, 100);

            var listaLivros = await conexaoBiblioteca.Livros.Find(condicao).SortBy(x => x.Titulo).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            Console.WriteLine("Fim da Lista");
            Console.WriteLine("");
            Console.WriteLine("");
        }
    }
}

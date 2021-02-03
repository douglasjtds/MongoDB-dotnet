using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    class ExcluindoDocumento
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
            Console.WriteLine("Buscar os livros de M. Assis");

            var construtor = Builders<Livro>.Filter;
            var condicao = construtor.Eq(x => x.Autor, "M. Assis");

            var listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            Console.WriteLine("Fim da Lista");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Excluindo os livros");
            await conexaoBiblioteca.Livros.DeleteManyAsync(condicao);



            Console.WriteLine("Buscar os livros de M. Assis");
            construtor = Builders<Livro>.Filter;
            condicao = construtor.Eq(x => x.Autor, "M. Assis");

            listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();
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

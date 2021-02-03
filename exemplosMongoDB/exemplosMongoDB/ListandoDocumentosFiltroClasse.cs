using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace exemplosMongoDB
{
    class ListandoDocumentosFiltroClasse
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
            Console.WriteLine("Listando Documentos Autor = Machado de Assis");

            var Filtro = new BsonDocument
            {
                { "Autor", "Machado de Assis"}
            };

            var listaLivros = await conexaoBiblioteca.Livros.Find(Filtro).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            Console.WriteLine("Fim da Lista");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Listando Documentos Autor = Machado de Assis - Classe");
            var construtor = Builders<Livro>.Filter;
            var condicao = construtor.Eq(x => x.Autor, "Machado de Assis");

            listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            Console.WriteLine("Fim da Lista");
            Console.WriteLine("");
            Console.WriteLine("");


            Console.WriteLine("Listando Documentos Ano publicação seja maior ou igual a 1999 - Classe");
             construtor = Builders<Livro>.Filter;
             condicao = construtor.Gte(x => x.Ano, 1999);

            listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            Console.WriteLine("Fim da Lista");
            Console.WriteLine("");
            Console.WriteLine("");


            Console.WriteLine("Listando Documentos Ano publicação a partir de 199 e que " +
                "tenham mais de 300 páginas");
            construtor = Builders<Livro>.Filter;
            condicao = construtor.Gte(x => x.Ano, 1999) & construtor.Gte(x => x.Paginas, 300);

            listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            Console.WriteLine("Fim da Lista");
            Console.WriteLine("");
            Console.WriteLine("");


            Console.WriteLine("Listando Documentos somente de ficção científica");
            construtor = Builders<Livro>.Filter;
            condicao = construtor.AnyEq(x => x.Assunto, "Ficção Científica");

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

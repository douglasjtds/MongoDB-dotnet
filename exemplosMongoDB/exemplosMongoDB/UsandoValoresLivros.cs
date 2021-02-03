using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace exemplosMongoDB
{
    class UsandoValoresLivros
    {
        static void Main(string[] args)
        {
            Task T = MainAsync(args);
            Console.WriteLine("Pressione ENTER");
            Console.ReadLine();
        }

        static async Task MainAsync(string[] args)
        {
            //Acessando através da classe de conexão
            var conexaoBiblioteca = new ConectandoMongoDB();

            Livro livro = new Livro();
            livro = ValoresLivro.incluiValoresLivro("Dom Casmurro", "Machado de Assis", 1923, 188, "Romance, Literatura Brasileira");

            Livro livro2 = new Livro();
            livro2 = ValoresLivro.incluiValoresLivro("A Arte da Ficção", "David Lodge", 2002, 230, "Didático, Auto Ajuda");


            //incluindo documento
            await conexaoBiblioteca.Livros.InsertOneAsync(livro);
            await conexaoBiblioteca.Livros.InsertOneAsync(livro2);
            Console.WriteLine("Documento incluido.");
        }
    }
}

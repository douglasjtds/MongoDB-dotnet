using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace exemplosMongoDB
{
    class ManipulandoClassesExternas
    {
        static void Main(string[] args)
        {
            Task T = MainAsync(args);
            Console.WriteLine("Pressione ENTER");
            Console.ReadLine();
        }

        static async Task MainAsync(string[] args)
        {
            //Inicializar variavel do tipo objeto livro
            Livro livro = new Livro
            {
                Titulo = "Star Wars Legends",
                Autor = "Timothy Zahn",
                Ano = 2010,
                Paginas = 245
            };
            List<string> Lista_Assuntos = new List<string>();
            Lista_Assuntos.Add("Ficção Científica");
            Lista_Assuntos.Add("Ação");
            livro.Assunto = Lista_Assuntos;

            //Acessando através da classe de conexão
            var conexaoBiblioteca = new ConectandoMongoDB();


            //incluindo documento
            await conexaoBiblioteca.Livros.InsertOneAsync(livro);
            Console.WriteLine("Documento incluido.");
        }
    }
}

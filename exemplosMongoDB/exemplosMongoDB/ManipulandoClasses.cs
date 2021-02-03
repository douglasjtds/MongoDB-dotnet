using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    class ManipulandoClasses
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
                Titulo = "Sob a redoma",
                Autor = "Stephan King",
                Ano = 2012,
                Paginas = 679
            };

            List<string> listaAssuntos = new List<string>();
            listaAssuntos.Add("Ficção Científica");
            listaAssuntos.Add("Terror");
            listaAssuntos.Add("Ação");
            livro.Assunto = listaAssuntos;

            //acesso ao servidor do MongoDB
            string stringConexao = "mongodb://localhost:27017";

            IMongoClient cliente = new MongoClient(stringConexao);

            //acesso ao banco de dados
            IMongoDatabase bancoDados = cliente.GetDatabase("Biblioteca");

            //acesso à coleção
            IMongoCollection<Livro> colecao = bancoDados.GetCollection<Livro>("Livros");

            //incluindo documento
            await colecao.InsertOneAsync(livro);
            Console.WriteLine("Documento incluido.");
        }
    }
}

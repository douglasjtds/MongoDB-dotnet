using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exemplosMongoDB
{
    class AlterandoDocumentoClasse
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
            Console.WriteLine("Listar o livro Guerra dos Tronos");

            var construtor = Builders<Livro>.Filter;
            var condicao = construtor.Eq(x => x.Titulo, "Guerra dos Tronos");

            var listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            Console.WriteLine("Fim da Lista");
            Console.WriteLine("");
            Console.WriteLine("");

            var construtorAlteracao = Builders<Livro>.Update;
            var condicaoDeAlteracao = construtorAlteracao.Set(x => x.Ano, 2001);
            await conexaoBiblioteca.Livros.UpdateOneAsync(condicao, condicaoDeAlteracao);

            Console.WriteLine("Registro alterado.");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Listar e alterar livro Guerra dos Tronos");
            construtor = Builders<Livro>.Filter;
            condicao = construtor.Eq(x => x.Titulo, "Guerra dos Tronos");

            listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }







            Console.WriteLine("Fim da Lista.");
            Console.WriteLine("");
            Console.WriteLine("");


            Console.WriteLine("Listar todos os livros de Machado de Assis");
            construtor = Builders<Livro>.Filter;
            condicao = construtor.Eq(x => x.Autor, "Machado de Assis");

            listaLivros = await conexaoBiblioteca.Livros.Find(condicao).ToListAsync();
            foreach (var doc in listaLivros)
            {
                Console.WriteLine(doc.ToJson<Livro>());
            }

            construtorAlteracao = Builders<Livro>.Update;
            condicaoDeAlteracao = construtorAlteracao.Set(x => x.Autor, "M. Assis");
            await conexaoBiblioteca.Livros.UpdateManyAsync(condicao, condicaoDeAlteracao);

            Console.WriteLine("Registro alterado.");
            Console.WriteLine("");
            Console.WriteLine("");

        }
    }
}

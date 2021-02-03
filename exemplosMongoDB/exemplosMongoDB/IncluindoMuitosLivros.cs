using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace exemplosMongoDB
{
    class IncluindoMuitosLivros
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

            List<Livro> livros = new List<Livro>
            {
                ValoresLivro.incluiValoresLivro("A Dança com os Dragões", "George R R Martin", 2011, 934, "Fantasia, Ação"),
                ValoresLivro.incluiValoresLivro("A Tormenta das Espadas", "George R R Martin", 2006, 1276, "Fantasia, Ação"),
                ValoresLivro.incluiValoresLivro("Memórias Póstumas de Brás Cubas", "Machado de Assis", 1915, 267, "Literatura Brasileira"),
                ValoresLivro.incluiValoresLivro("Star Trek Portal do Tempo", "Crispin A C", 2002, 321, "Fantasia, Ação"),
                ValoresLivro.incluiValoresLivro("Star Trek Enigmas", "Dedopolus Tim", 2006, 195, "Ficção Científica, Ação"),
                ValoresLivro.incluiValoresLivro("Emília no Pais da Gramática", "Monteiro Lobato", 1936, 230, "Infantil, Literatura Brasileira, Didático"),
                ValoresLivro.incluiValoresLivro("Chapelzinho Amarelo", "Chico Buarque", 2008, 123, "Infantil, Literatura Brasileira"),
                ValoresLivro.incluiValoresLivro("20000 Léguas Submarinas", "Julio Verne", 1894, 256, "Ficção Científica, Ação"),
                ValoresLivro.incluiValoresLivro("Primeiros Passos na Matemática", "Mantin Ibanez", 2014, 190, "Didático, Infantil"),
                ValoresLivro.incluiValoresLivro("Saúde e Sabor", "Yeomans Matthew", 2012, 245, "Culinária, Didático"),
                ValoresLivro.incluiValoresLivro("Goldfinger", "Iam Fleming", 1956, 267, "Espionagem, Ação"),
                ValoresLivro.incluiValoresLivro("Da Rússia com Amor", "Iam Fleming", 1966, 245, "Espionagem, Ação"),
                ValoresLivro.incluiValoresLivro("O Senhor dos Aneis", "J R R Token", 1948, 1956, "Fantasia, Ação")
            };

            //incluindo documento
            await conexaoBiblioteca.Livros.InsertManyAsync(livros);
            Console.WriteLine("Documentos incluidos com sucesso.");
        }
    }
}

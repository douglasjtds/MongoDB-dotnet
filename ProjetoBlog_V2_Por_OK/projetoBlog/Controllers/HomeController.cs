using projetoBlog.Models;
using projetoBlog.Models.Home;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;


namespace projetoBlog.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var conectandoMongoDb = new AcessoMongoDB();
            var filtro = new BsonDocument();
            var publicacoesRecentes = await conectandoMongoDb.Publicacoes.Find(filtro)
                .SortByDescending(x => x.DataCriacao).Limit(10).ToListAsync();


            var model = new IndexModel
            {
                PublicacoesRecentes = publicacoesRecentes
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult NovaPublicacao()
        {
            return View(new NovaPublicacaoModel());
        }

        [HttpPost]
        public async Task<ActionResult> NovaPublicacao(NovaPublicacaoModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var post = new Publicacao
            {
                Autor = User.Identity.Name,
                Titulo = model.Titulo,
                Conteudo = model.Conteudo,
                Tags = model.Tags.Split(' ', ',', ';'),
                DataCriacao = DateTime.UtcNow,
                Comentarios = new List<Comentario>()
            };

            var conectandoMongoDb = new AcessoMongoDB();
            //incluir publicacao na base de dados
            await conectandoMongoDb.Publicacoes.InsertOneAsync(post);

            return RedirectToAction("Publicacao", new { id = post.Id });
        }

        [HttpGet]
        public async Task<ActionResult> Publicacao(string id)
        {
            var conectandoMongoDb = new AcessoMongoDB();
            var publicacao = await conectandoMongoDb.Publicacoes.Find(x => x.Id == id).SingleOrDefaultAsync();


            if (publicacao == null)
                return RedirectToAction("Index");

            var model = new PublicacaoModel
            {
                Publicacao = publicacao,
                NovoComentario = new NovoComentarioModel
                {
                    PublicacaoId = id
                }
            };

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Publicacoes(string tag = null)
        {
            var conectandoMongoDb = new AcessoMongoDB();
            var posts = new List<Publicacao>();

            if (tag == null)
            {
                var filtro = new BsonDocument();
                posts = await conectandoMongoDb.Publicacoes.Find(filtro)
                    .SortByDescending(x => x.DataCriacao).Limit(10).ToListAsync();
            }
            else
            {
                var construtor = Builders<Publicacao>.Filter;
                var condicao = construtor.AnyEq(x => x.Tags, tag);
                posts = await conectandoMongoDb.Publicacoes.Find(condicao)
                    .SortByDescending(x => x.DataCriacao).Limit(10).ToListAsync();
            }

            return View(posts);
        }

        [HttpPost]
        public async Task<ActionResult> NovoComentario(NovoComentarioModel model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Publicacao", new { id = model.PublicacaoId });

            // Inclua novo comentário na publicação já existente.

            return RedirectToAction("Publicacao", new { id = model.PublicacaoId });
        }
    }
}
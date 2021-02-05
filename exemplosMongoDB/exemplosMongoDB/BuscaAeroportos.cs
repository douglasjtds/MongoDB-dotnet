using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;

namespace exemplosMongoDB
{
    public class BuscaAeroportos
    {
        static void Main(string[] args)
        {
            Task T = MainAsync(args);
            Console.WriteLine();
            //Console.WriteLine("Pressione Enter");
            Console.ReadLine();
        }
        static async Task MainAsync(string[] args)
        {
            var conexaoAeroporto = new ConectandoMongoDbGeo();
            var ponto = new GeoJson2DGeographicCoordinates(-118.325258, 34.103212);
            var localizacao = new GeoJsonPoint<GeoJson2DGeographicCoordinates>(ponto);

            var construtor = Builders<Aeroporto>.Filter;
            var condicao = construtor.NearSphere(x => x.Loc, localizacao, 200000);
            var listaAeroportos = await conexaoAeroporto.Airports.Find(condicao).ToListAsync();

            foreach (var doc in listaAeroportos)
            {
                Console.WriteLine(doc.ToJson<Aeroporto>());
            }

            Console.WriteLine("Fim da Lista");
        }
    }
}

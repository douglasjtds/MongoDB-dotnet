using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace exemplosMongoDB
{
    class ConectandoMongoDbGeo
    {
        public const string STRING_DE_CONEXAO = "mongodb://localhost:27017";
        public const string NOME_DA_BASE = "geo";
        public const string NOME_DA_COLECAO = "airports";

        private static readonly IMongoClient _cliente;
        private static readonly IMongoDatabase _baseDeDados;

        static ConectandoMongoDbGeo()
        {
            _cliente = new MongoClient(STRING_DE_CONEXAO);
            _baseDeDados = _cliente.GetDatabase(NOME_DA_BASE);
        }

        public IMongoClient Cliente
        {
            get { return _cliente; }
        }

        public IMongoCollection<Aeroporto> Airports
        {
            get { return _baseDeDados.GetCollection<Aeroporto>(NOME_DA_COLECAO); }
        }
    }
}

using System;

namespace projetoBlog.Models
{
    public class Comentario
    {
        public string Autor { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
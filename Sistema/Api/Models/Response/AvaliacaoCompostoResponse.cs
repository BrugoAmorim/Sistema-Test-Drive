using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable
namespace Api.Models.Response
{
    public class AvaliacaoCompostoResponse
    {
        public string status { get; set; }
        public string mensagem { get; set; }
        public int codigo { get; set; }
        public Models.Response.AvaliacaoResponse avaliacao { get; set; }
    }
}
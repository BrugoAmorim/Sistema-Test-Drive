using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace Api.Models.Request
{
    public class AvaliacaoRequest
    {
        public string avaliacao { get; set; }
        public int notaavaliacao { get; set; }
    }
}
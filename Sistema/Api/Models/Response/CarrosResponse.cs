using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace Api.Models.Response
{
    public class CarrosResponse
    {
        public int idcarro { get; set; }
        public string carro { get; set; }
        public DateTime anofabricacao { get; set; }
        public DateTime anomodelo { get; set; }
        public string potencia { get; set; }
        public decimal preco { get; set; }
        public string modelo { get; set; }
        public string cambio { get; set; }
        public string fabricante { get; set; }
        public string combustivel { get; set; }
    }
}
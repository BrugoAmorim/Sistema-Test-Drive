using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace Api.Models.Request
{
    public class AgendarRequest
    {
        public string cliente { get; set; }
        public string endereco { get; set; }
        public string rg { get; set; }
        public string cpf { get; set; }
        public string cnh { get; set; }
        public string telefone { get; set; }
        public string celular { get; set; }
        public DateTime datatest { get; set; }
        public int idcarro { get; set; }      
    }
}
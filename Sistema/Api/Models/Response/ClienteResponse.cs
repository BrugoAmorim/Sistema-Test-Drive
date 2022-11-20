using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace Api.Models.Response
{
    public class ClienteResponse
    {
        public int idcliente { get; set; }
        public string cliente { get; set; }
        public string endereco { get; set; }
        public string rg { get; set; }
        public string cpf { get; set; }
        public string cnh { get; set; }
        public string telefone { get; set; }
        public string celular { get; set; }
        public int idusuario { get; set; }
    }
}
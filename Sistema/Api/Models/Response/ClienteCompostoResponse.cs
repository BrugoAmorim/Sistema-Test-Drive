using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace Api.Models.Response
{
    public class ClienteCompostoResponse
    {
        public int codigo { get; set; }
        public string status { get; set; }
        public string mensagem { get; set; }
        public Dados dados { get; set; } 
        public class Dados {     
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
}
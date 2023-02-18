using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable
namespace Api.Models.Response
{
    public class UsuariosAgendamentosResponse
    {
        public int numAgendamentos { get; set; }
        public Usuario usuario { get; set; }
        public class Usuario {
            public string nome { get; set; }
            public string email { get; set; }
            public string nivelacesso { get; set; }
        } 
    }
}
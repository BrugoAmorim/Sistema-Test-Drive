using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable
namespace Api.Models.Response
{
    public class ModelosAgendamentosResponse
    {
        public int numAgendamentos { get; set; }
        public Modelo modelo { get; set; }
        public class Modelo { 
            public int idModelo { get; set; }
            public string modelo { get; set; }
        }
    }
}
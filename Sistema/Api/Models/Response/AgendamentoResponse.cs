using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace Api.Models.Response
{
    public class AgendamentoResponse
    {
        public int idagendamento { get; set; }
        public DateTime datatest { get; set; }
        public bool desmarcado { get; set; }
        public bool realizado { get; set; }
        public Models.Response.ClienteResponse Cliente { get; set; }
        public Models.Response.CarrosResponse Carro { get; set; }
        
    }
}
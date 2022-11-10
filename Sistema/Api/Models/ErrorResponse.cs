using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class ErrorResponse
    {
        public string ?motivo { get; set; }
        public int codigo { get; set; }

        public ErrorResponse(string ?motivo, int codigo){

            this.motivo = motivo;
            this.codigo = codigo;
        }
    }
}
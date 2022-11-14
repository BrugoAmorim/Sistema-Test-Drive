using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace Api.Models
{
    public class ErrorResponse
    {
        public string status { get; set; }
        public string mensagem { get; set; }
        public int codigo { get; set; }

        public ErrorResponse(string mensagem, int codigo){

            this.status = "Falha na requisição";
            this.mensagem = mensagem;
            this.codigo = codigo;
        }
    }
}
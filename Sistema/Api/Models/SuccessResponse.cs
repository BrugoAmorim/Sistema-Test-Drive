using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable
namespace Api.Models
{
    public class SuccessResponse
    {
        public string status { get; set; }
        public string mensagem { get; set; }
        public int codigo { get; set; }
    
        public SuccessResponse(string mensagem, int codigo){

            this.status = "Sucesso";
            this.mensagem = mensagem;
            this.codigo = codigo;
        }
    }
}
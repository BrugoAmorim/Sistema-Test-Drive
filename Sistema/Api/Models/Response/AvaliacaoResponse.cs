using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace Api.Models.Response
{
    public class AvaliacaoResponse
    {
        public int idavaliacao { get; set; }
        public string avaliacao { get; set; }
        public DateTime datapostagem { get; set; }
        public DateTime dataalteracao { get; set; }
        public decimal notaavaliacao { get; set; }
        public usuario infousuario { get; set; }

        public class usuario{
            public int idusuario { get; set; }
            public string nomeusuario { get; set; }
            public string email { get; set; }
        }
    }
}
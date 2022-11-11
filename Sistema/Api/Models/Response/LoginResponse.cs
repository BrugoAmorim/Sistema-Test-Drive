using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Response
{
    public class LoginResponse
    {
        public int idusuario { get; set; }
        public string ?usuario { get; set; }
        public string ?email { get; set; }
        public DateTime datanascimento { get; set; }
        public DateTime ultimologin { get; set; }
        public DateTime contacriada { get; set; }
        public DateTime contaatualizada { get; set; }
        public string ?nivelacesso { get; set; }
    }
}
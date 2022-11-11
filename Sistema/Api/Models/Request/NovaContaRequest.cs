using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace Api.Models.Request
{
    public class NovaContaRequest
    {
        public string email { get; set; }
        public string usuario { get; set; }
        public DateTime nascimento { get; set; }
        public string senha { get; set; }
        public string confirmarsenha { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable
namespace Api.Models.Request
{
    public class LoginRequest
    {
        public string email { get; set; }
        public string senha { get; set; }
    }
}
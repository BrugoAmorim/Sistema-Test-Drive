using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable
namespace Api.Models.Response
{
    public class CarrosRequeridosResponse
    {
        public int numeroagendamentos { get; set; }
        public Models.Response.CarrosResponse carro { get; set; }
    }
}
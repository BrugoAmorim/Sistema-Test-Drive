using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        Business.TestDriveBusiness validacoes = new Business.TestDriveBusiness();

        [HttpGet("negocios/carrosrequeridos/{idusuario}")]
        public ActionResult<List<Models.Response.CarrosRequeridosResponse>> carrosMaisRequeridos(int idusuario){

            try{
                Business.NegociosBusiness validacoes = new Business.NegociosBusiness();
                List<Models.Response.CarrosRequeridosResponse> populares = validacoes.validarCarrosPopulares(idusuario);

                return populares.Take(5).ToList();
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.ErrorResponse(ex.Message, 400)
                );                
            }
        }
    }
}
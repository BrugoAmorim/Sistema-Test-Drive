using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestDriveController : ControllerBase
    {

        Business.TestDriveBusiness validacoes = new Business.TestDriveBusiness();
        Utils.TestDriveUtils conversor = new Utils.TestDriveUtils();

        [HttpGet("consultar/carros")]
        public ActionResult<List<Models.Response.CarrosResponse>> ListarCarros(){

            try{
                List<Models.TbCarro> cars = validacoes.validarBuscarCarros();

                List<Models.Response.CarrosResponse> carrosRes = conversor.ListarCarrosRes(cars);
                return carrosRes;
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.ErrorResponse(ex.Message, 400)
                );
            }
        }

        [HttpGet("consultar/filtrar-modelo")]
        public ActionResult<List<Models.Response.CarrosResponse>> FiltrarModelo(string modelo){

            try{
                List<Models.TbCarro> carros = validacoes.validarFiltroModelo(modelo);
                
                List<Models.Response.CarrosResponse> carrosRes = conversor.ListarCarrosRes(carros);
                return carrosRes;
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.ErrorResponse(ex.Message, 400)
                );
            }
        }
    }
}
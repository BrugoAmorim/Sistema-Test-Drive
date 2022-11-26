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
        
        [HttpPost("agendar/novotest/{idusuario}")]
        public ActionResult<Models.Response.AgendamentoResponse> FazerAgendamento(Models.Request.AgendarRequest req, int idusuario){

            try{
                Models.TbTestDrive agendamento = validacoes.validarNovoAgendamento(req, idusuario);

                Models.Response.AgendamentoResponse TestdriveRes = conversor.TbTestDriveparaTestRes(agendamento);
                return TestdriveRes;
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.ErrorResponse(ex.Message, 400)
                );
            }
        }

        [HttpGet("consultar/agendamentos")]
        public ActionResult<List<Models.Response.AgendamentoResponse>> GetAgendamentos(){

            try{

                List<Models.TbTestDrive> agendamentos = validacoes.validarGetAgendamentos();
                List<Models.Response.AgendamentoResponse> TestRes = conversor.TbListaTestparaTestRes(agendamentos);

                return TestRes;
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.ErrorResponse(ex.Message, 400)
                );
            }
        }
    }
}
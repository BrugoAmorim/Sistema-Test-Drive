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
        Business.ClienteBusiness validacoesCliente = new Business.ClienteBusiness();
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

        [HttpGet("consultar/agendamentos/{idusuario}")]
        public ActionResult<List<Models.Response.AgendamentoResponse>> GetAgendamentos(int idusuario){

            try{

                List<Models.TbTestDrive> agendamentos = validacoes.validarGetAgendamentos(idusuario);
                List<Models.Response.AgendamentoResponse> TestRes = conversor.TbListaTestparaTestRes(agendamentos);

                return TestRes;
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.ErrorResponse(ex.Message, 400)
                );
            }
        }

        [HttpPut("agendamento/marcarRealizado/{idagendamento}")]
        public ActionResult<Models.Response.AgendamentoResponse> MarcarcomoFeito(int idagendamento){

            try{

                Models.TbTestDrive Test = validacoes.validarMarcarAgendamentoFeito(idagendamento);
                Models.Response.AgendamentoResponse caixote = conversor.TbTestDriveparaTestRes(Test);

                return caixote;
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.ErrorResponse(ex.Message, 400)
                );
            }
        }

        [HttpPut("agendamento/marcarNaoRealizado/{idagendamento}")]
        public ActionResult<Models.Response.AgendamentoResponse> MarcarcomoNaoFeito(int idagendamento){

            try{

                Models.TbTestDrive Agendamento = validacoes.validarMarcarAgendamentoNaoFeito(idagendamento);
                Models.Response.AgendamentoResponse caixoteRes = conversor.TbTestDriveparaTestRes(Agendamento);

                return caixoteRes;
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.ErrorResponse(ex.Message, 400)
                );
            }
        }

        [HttpGet("agendamento/detalhes/{idagendamento}")]
        public ActionResult<Models.Response.AgendamentoResponse> BuscarAgendamento(int idagendamento){

            try{

                Models.TbTestDrive Agendamento = validacoes.validarBuscarAgendamento(idagendamento);
                Models.Response.AgendamentoResponse caixoteRes = conversor.TbTestDriveparaTestRes(Agendamento);

                return caixoteRes;                
            }
            catch(System.Exception ex){
                
                return new BadRequestObjectResult(
                    new Models.ErrorResponse(ex.Message, 400)
                );
            }
        }

        [HttpPut("agendamento/atualizarCliente/{iduser}/{idclient}")]        
        public ActionResult<Models.Response.ClienteCompostoResponse> atualizarDadosCliente(Models.Request.ClienteRequest clientereq, int iduser, int idclient){

            try{
                Models.TbCliente atualizarCliente = validacoesCliente.validarDadosCliente(clientereq, iduser, idclient);
                Models.Response.ClienteCompostoResponse res = conversor.TbClienteparaClienteCompRes(atualizarCliente);

                return res;
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.ErrorResponse(ex.Message, 400)
                );
            }
        }

        [HttpPut("agendamento/desmarcartestdrive/{idusuario}/{idcliente}/{idtestdrive}")]
        public ActionResult<Models.Response.AgendamentoResponse> DesmarcarTestDrive(int idusuario, int idcliente, int idtestdrive){

            try{

                Models.TbTestDrive agendamento = validacoes.validarDesmarcarTestDrive(idusuario, idcliente, idtestdrive);
                Models.Response.AgendamentoResponse caixoteRes = conversor.TbTestDriveparaTestRes(agendamento);

                return caixoteRes;
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.ErrorResponse(ex.Message, 404)
                );
            }
        }
    }
}
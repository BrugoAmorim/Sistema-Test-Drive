using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AvaliacoesController : ControllerBase
    {
        Business.AvaliacoesBusiness validacoes = new Business.AvaliacoesBusiness();
        Utils.AvaliacoesUtils converter = new Utils.AvaliacoesUtils();

        [HttpGet("buscaravaliacoes")]
        public ActionResult<List<Models.Response.AvaliacaoResponse>> buscarAvaliacoes(){

            try{
                List<Models.TbFeedback> feedbacks = validacoes.validarbuscarFeedbacks();
                List<Models.Response.AvaliacaoResponse> feedbackRes = converter.listaAvlparaAvlRes(feedbacks);

                return feedbackRes;
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.ErrorResponse(ex.Message, 400)
                );
            }
        }    

        [HttpPost("fazeravaliacao/{idusuario}")]
        public ActionResult<Models.Response.AvaliacaoResponse> FazerAvaliacao(Models.Request.AvaliacaoRequest avaliacaoReq, int idusuario){

            try{
                Models.TbFeedback feedbacksalvo = validacoes.validarnovoFeedback(avaliacaoReq, idusuario);
                Models.Response.AvaliacaoResponse feedbackRes = converter.TbAvlparaAvlRes(feedbacksalvo);

                return feedbackRes;
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.ErrorResponse(ex.Message, 400)
                );
            }
        }

        [HttpPut("editar/{idusuario}/{idavaliacao}")]       
        public ActionResult<Models.Response.AvaliacaoResponse> EditarAvaliacao(Models.Request.AvaliacaoRequest Avlreq, int idusuario, int idavaliacao){

            try{

                Models.TbFeedback Feedbackalterado = validacoes.validareditarFeedback(Avlreq, idusuario, idavaliacao);
                Models.Response.AvaliacaoResponse feedbackRes = converter.TbAvlparaAvlRes(Feedbackalterado);

                return feedbackRes;
            }   
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.ErrorResponse(ex.Message, 400)
                );
            }
        }
    }
}
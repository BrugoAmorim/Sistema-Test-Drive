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

        [HttpGet("minhas")]
        public ActionResult<List<Models.Response.AvaliacaoResponse>> minhasAvaliacoes(int idusuario){

            try{
                List<Models.TbFeedback> feedbacks = validacoes.validarMeusFeedbacks(idusuario);
                List<Models.Response.AvaliacaoResponse> feedbackRes = converter.listaAvlparaAvlRes(feedbacks);

                return feedbackRes;
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.ErrorResponse(ex.Message, 400)
                );
            }
        }

        [HttpGet("outras")]
        public ActionResult<List<Models.Response.AvaliacaoResponse>> outrasAvaliacoes(int idusuario, string ordenar){

            try{
                List<Models.TbFeedback> feedbacks = validacoes.validarOutrosFeedbacks(idusuario, ordenar);
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
        public ActionResult<Models.Response.AvaliacaoCompostoResponse> FazerAvaliacao(Models.Request.AvaliacaoRequest avaliacaoReq, int idusuario){

            try{
                Models.TbFeedback feedbacksalvo = validacoes.validarnovoFeedback(avaliacaoReq, idusuario);

                Models.Response.AvaliacaoResponse feedback = converter.TbAvlparaAvlRes(feedbacksalvo);
                Models.Response.AvaliacaoCompostoResponse FeedbackComRes = converter.CriarAvlCompostoResponse(feedback);

                return FeedbackComRes;
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.ErrorResponse(ex.Message, 400)
                );
            }
        }

        [HttpPut("editar/{idusuario}/{idavaliacao}")]       
        public ActionResult<Models.Response.AvaliacaoCompostoResponse> EditarAvaliacao(Models.Request.AvaliacaoRequest Avlreq, int idusuario, int idavaliacao){

            try{

                Models.TbFeedback Feedbackalterado = validacoes.validareditarFeedback(Avlreq, idusuario, idavaliacao);
                
                Models.Response.AvaliacaoResponse feedback = converter.TbAvlparaAvlRes(Feedbackalterado);
                Models.Response.AvaliacaoCompostoResponse FeedbackComRes = converter.CriarAvlCompostoResponse(feedback);

                return FeedbackComRes;
            }   
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.ErrorResponse(ex.Message, 400)
                );
            }
        }

        [HttpDelete("excluir/{idusuario}/{idavaliacao}")]
        public ActionResult<Models.SuccessResponse> ExcluirAvaliacao(int idusuario, int idavaliacao){
            
            try{

                validacoes.validarexcluirFeedback(idusuario, idavaliacao);

                return new Models.SuccessResponse("A avaliação foi excluída com êxito", 200);
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.ErrorResponse(ex.Message, 400)
                );
            }
        }
    }
}
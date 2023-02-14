using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AcessoController : ControllerBase
    {
        Utils.AcessoUtils conversor = new Utils.AcessoUtils();
        Business.AcessoBusiness validacoes = new Business.AcessoBusiness();

        [HttpPost("login")]
        public ActionResult<Models.Response.LoginResponse> LoginSistema(Models.Request.LoginRequest logar){

            try{
            Models.TbUsuario usuario = validacoes.validarLogin(logar);
            Models.Response.LoginResponse usuarioRes = conversor.TbUsuarioparaLoginRes(usuario);

            return usuarioRes;
            } 
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.ErrorResponse(ex.Message, 400)
                );
            }
        }

        [HttpPost("novaconta")]
        public ActionResult<Models.Response.LoginResponse> CriarConta(Models.Request.NovaContaRequest req){

            try{
                Models.TbUsuario novousuario = validacoes.validarNovaConta(req);
                Models.Response.LoginResponse caixoteRes = conversor.TbUsuarioparaLoginRes(novousuario);
            
                return caixoteRes;
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.ErrorResponse(ex.Message, 400)
                );
            }
        }
    
        [HttpPut("conta/editar/{idusuario}")]
        public ActionResult<Models.Response.LoginResponse> EditarcontaUser(Models.Request.EditarContaRequest req, int idusuario){

            try{

                Models.TbUsuario usuarioupdate = validacoes.validarEditarConta(req, idusuario);
                Models.Response.LoginResponse caixoteRes = conversor.TbUsuarioparaLoginRes(usuarioupdate);

                return caixoteRes;
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.ErrorResponse(ex.Message, 400)
                );
            }
        }

        [HttpDelete("conta/excluir/{idusuario}")]
        public ActionResult<Models.SuccessResponse> ExcluircontaUser(int idusuario, string senhaacesso){

            try{
                validacoes.validarApagarConta(idusuario, senhaacesso);

                return new Models.SuccessResponse("Conta excluída", 200);
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.ErrorResponse(ex.Message, 400)
                );
            }
        }
    }
}   
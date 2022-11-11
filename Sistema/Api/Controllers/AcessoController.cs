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
    }
}   
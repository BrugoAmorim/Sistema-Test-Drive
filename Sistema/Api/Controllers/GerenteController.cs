using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        Business.NegociosBusiness validacoes = new Business.NegociosBusiness();

        [HttpGet("negocios/carrosrequeridos/{idusuario}")]
        public ActionResult<List<Models.Response.CarrosRequeridosResponse>> carrosMaisRequeridos(int idusuario){

            try{

                List<Models.Response.CarrosRequeridosResponse> populares = validacoes.validarCarrosPopulares(idusuario);
                return populares;
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.ErrorResponse(ex.Message, 400)
                );                
            }
        }

        [HttpGet("negocios/melhoresclientes/{idusuario}")]
        public ActionResult<List<Models.Response.UsuariosAgendamentosResponse>> usersMaisAgendamentos(int idusuario){

            try{

                List<Models.Response.UsuariosAgendamentosResponse> sumAgendUsers = validacoes.validarAgendamentosUsuarios(idusuario);
                return sumAgendUsers;
            }
            catch(System.Exception ex){

                return new BadRequestObjectResult(
                    new Models.ErrorResponse(ex.Message, 400)
                );
            }
        }
    }
}
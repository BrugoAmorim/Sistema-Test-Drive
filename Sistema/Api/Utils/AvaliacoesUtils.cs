using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace Api.Utils
{
    public class AvaliacoesUtils
    {
        public Models.Response.AvaliacaoResponse TbAvlparaAvlRes(Models.TbFeedback feedback){

            Models.Response.AvaliacaoResponse avaliacaores = new Models.Response.AvaliacaoResponse();
            avaliacaores.idavaliacao = feedback.IdFeedback;
            avaliacaores.avaliacao = feedback.DsFeedback;
            avaliacaores.dataalteracao = feedback.DtUltimaAlteracao;
            avaliacaores.datapostagem = feedback.DtFeedback;
            avaliacaores.notaavaliacao = feedback.IdAvaliacaoNavigation.VlFeedback;
            
            Models.Response.AvaliacaoResponse.usuario infouser = new Models.Response.AvaliacaoResponse.usuario();
            infouser.idusuario = feedback.IdUsuarioNavigation.IdUsuario;
            infouser.email = feedback.IdUsuarioNavigation.DsEmail;
            infouser.nomeusuario = feedback.IdUsuarioNavigation.NmUsuario;

            avaliacaores.infousuario = infouser;
            return avaliacaores;
        }

        public List<Models.Response.AvaliacaoResponse> listaAvlparaAvlRes(List<Models.TbFeedback> listaFeedback){

            List<Models.Response.AvaliacaoResponse> FeedbackRes = new List<Models.Response.AvaliacaoResponse>();
            foreach(Models.TbFeedback item in listaFeedback){

                FeedbackRes.Add(TbAvlparaAvlRes(item));
            }

            return FeedbackRes;
        }

        public Models.TbFeedback reqAvlparaTbAvl(Models.Request.AvaliacaoRequest reqavaliacao, int idusuario){

            Models.TbFeedback tbfeedback = new Models.TbFeedback();
            tbfeedback.DsFeedback = reqavaliacao.avaliacao;
            tbfeedback.IdAvaliacao = reqavaliacao.notaavaliacao;
            tbfeedback.IdUsuario = idusuario;
            tbfeedback.DtFeedback = DateTime.Now;
            tbfeedback.DtUltimaAlteracao = DateTime.Now;

            return tbfeedback;
        }
    }
}
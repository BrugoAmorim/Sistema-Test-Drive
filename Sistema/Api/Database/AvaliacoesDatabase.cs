using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Api.Database
{
    public class AvaliacoesDatabase
    {
        Models.dbTestDriveContext db = new Models.dbTestDriveContext();
        Utils.AvaliacoesUtils converter = new Utils.AvaliacoesUtils();

        public List<Models.TbFeedback> listarFeedbacks(){

            List<Models.TbFeedback> avl = db.TbFeedbacks.Include(x => x.IdAvaliacaoNavigation)
                                                        .Include(x => x.IdUsuarioNavigation)
                                                        .ToList();   
            return avl;
        }

        public List<Models.TbAvaliacao> listarNotas(){
            
            List<Models.TbAvaliacao> notas = db.TbAvaliacaos.ToList();
            return notas;
        }

        public Models.TbFeedback salvarAvaliacao(Models.Request.AvaliacaoRequest avaliacaoReq, int idusuario){

            Models.TbFeedback Tbfeedback = converter.reqAvlparaTbAvl(avaliacaoReq, idusuario);
            
            db.TbFeedbacks.Add(Tbfeedback);
            db.SaveChanges();
        
            Models.TbFeedback feedbacksalvo = buscarAvaliacaoId(Tbfeedback.IdFeedback);
            return feedbacksalvo;
        }

        public Models.TbFeedback buscarAvaliacaoId(int idfeedback){

            Models.TbFeedback feedback = db.TbFeedbacks.Include(x => x.IdAvaliacaoNavigation)
                                                       .Include(x => x.IdUsuarioNavigation)
                                                       .FirstOrDefault(x => x.IdFeedback == idfeedback);

            return feedback;
        }

        public Models.TbFeedback salvarAlteracoesAvaliacao(Models.Request.AvaliacaoRequest req, int iduser, int idfeed){

            Models.TbFeedback alterarDados = db.TbFeedbacks.First(x => x.IdFeedback == idfeed && x.IdUsuario == iduser);
            alterarDados.DsFeedback = req.avaliacao;
            alterarDados.IdAvaliacao = req.notaavaliacao;
            alterarDados.DtUltimaAlteracao = DateTime.Now;

            db.SaveChanges();

            Models.TbFeedback feedbackalterado = buscarAvaliacaoId(alterarDados.IdFeedback);
            return feedbackalterado;
        }
    }
}
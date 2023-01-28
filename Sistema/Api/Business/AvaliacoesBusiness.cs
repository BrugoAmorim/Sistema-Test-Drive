using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Business
{
    public class AvaliacoesBusiness
    {
        Database.AvaliacoesDatabase bdfeedback = new Database.AvaliacoesDatabase();
        Database.UsuarioDatabase bdusuarios = new Database.UsuarioDatabase();
        ValidarCamposBusiness validarcampos = new ValidarCamposBusiness();

        public List<Models.TbFeedback> validarMeusFeedbacks(int iduser){

            List<Models.TbFeedback> avl = bdfeedback.listarFeedbacks();

            if(iduser <= 0)
                throw new ArgumentException("Esse usuário é inválido");

            Models.TbUsuario user = bdusuarios.buscarUsuarioId(iduser);
            if(user == null)
                throw new ArgumentException("Esse usuário não foi encontrado");

            List<Models.TbFeedback> meusfeedbacks = avl.Where(x => x.IdUsuario == iduser).ToList();
            if(meusfeedbacks.Count == 0)
                throw new ArgumentException("Você ainda não escreveu uma avaliação");

            return meusfeedbacks;
        }

        public List<Models.TbFeedback> validarOutrosFeedbacks(int iduser){

            List<Models.TbFeedback> avl = bdfeedback.listarFeedbacks();

            if(iduser <= 0)
                throw new ArgumentException("Esse usuário é inválido");

            Models.TbUsuario user = bdusuarios.buscarUsuarioId(iduser);
            if(user == null)
                throw new ArgumentException("Esse usuário não foi encontrado");

            if(avl.Count == 0)
                throw new ArgumentException("Ainda não há registros de avaliações");

            return avl.Where(x => x.IdUsuario != iduser).ToList(); 
        }

        public Models.TbFeedback validarnovoFeedback(Models.Request.AvaliacaoRequest req, int idusuario){

            validarcampos.Avaliacao(req);

            Models.TbUsuario user = bdusuarios.buscarUsuarioId(idusuario);
            if(user == null)
                throw new ArgumentException("Esse usuário não foi encontrado");

            Models.TbFeedback feedbacksalvo = bdfeedback.salvarAvaliacao(req, idusuario);
            return feedbacksalvo;
        }

        public Models.TbFeedback validareditarFeedback(Models.Request.AvaliacaoRequest req, int idusuario, int idavl){

            validarcampos.Avaliacao(req);

            Models.TbUsuario user = bdusuarios.buscarUsuarioId(idusuario);
            if(user == null)
                throw new ArgumentException("Esse usuário não foi encontrado");

            Models.TbFeedback feedback = bdfeedback.buscarAvaliacaoId(idavl);
            if(feedback == null)
                throw new ArgumentException("Essa avaliação não foi encontrada");

            if(feedback.IdUsuario != user.IdUsuario)
                throw new ArgumentException("Você não tem permissão para editar essa avaliação");
     
            Models.TbFeedback novoFeedback = bdfeedback.salvarAlteracoesAvaliacao(req, idusuario, idavl);
            return novoFeedback;
        }

        public void validarexcluirFeedback(int idusuario, int idavl){
            
            if(idusuario <= 0)
                throw new ArgumentException("O ID do usuário é inválido");

            if(idavl <= 0)
                throw new ArgumentException("O ID da avaliação é inválido");

            Models.TbUsuario user = bdusuarios.buscarUsuarioId(idusuario);
            if(user == null)
                throw new ArgumentException("Esse usuário não foi encontrado");

            Models.TbFeedback feedback = bdfeedback.buscarAvaliacaoId(idavl);
            if(feedback == null)
                throw new ArgumentException("Essa avaliação não foi encontrada");

            if(feedback.IdUsuario != user.IdUsuario)
                throw new ArgumentException("Você não tem permissão para excluir essa avaliação");
     
            bdfeedback.apagarAvaliacao(idusuario, idavl);
        }
    }
}
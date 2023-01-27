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

        public List<Models.TbFeedback> validarbuscarFeedbacks(){

            List<Models.TbFeedback> avl = bdfeedback.listarFeedbacks();

            if(avl.Count == 0)
                throw new ArgumentException("Ainda não há registros de avaliações");

            return avl;
        }

        public Models.TbFeedback validarnovoFeedback(Models.Request.AvaliacaoRequest req, int idusuario){

            if(string.IsNullOrEmpty(req.avaliacao))
                throw new ArgumentException("Você precisa escrever uma avaliação");

            List<Models.TbAvaliacao> notasfeedback = bdfeedback.listarNotas();
            if(notasfeedback.FirstOrDefault(x => x.VlFeedback == req.notaavaliacao) == null)
                throw new ArgumentException("Essa nota é inválida");

            Models.TbUsuario user = bdusuarios.buscarUsuarioId(idusuario);
            if(user == null)
                throw new ArgumentException("Esse usuário não foi encontrado");

            Models.TbFeedback feedbacksalvo = bdfeedback.salvarAvaliacao(req, idusuario);
            return feedbacksalvo;
        }
    }
}
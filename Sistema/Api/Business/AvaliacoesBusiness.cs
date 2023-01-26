using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Business
{
    public class AvaliacoesBusiness
    {
        Database.AvaliacoesDatabase bdfeedback = new Database.AvaliacoesDatabase();

        public List<Models.TbFeedback> validarbuscarFeedbacks(){

            List<Models.TbFeedback> avl = bdfeedback.listarFeedbacks();

            if(avl.Count == 0)
                throw new ArgumentException("Ainda não há registros de avaliações");

            return avl;
        }
    }
}
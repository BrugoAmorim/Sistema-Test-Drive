using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Api.Database
{
    public class AvaliacoesDatabase
    {
        Models.dbTestDriveContext db = new Models.dbTestDriveContext();

        public List<Models.TbFeedback> listarFeedbacks(){

            List<Models.TbFeedback> avl = db.TbFeedbacks.Include(x => x.IdAvaliacaoNavigation)
                                                        .Include(x => x.IdUsuarioNavigation)
                                                        .ToList();   
            return avl;
        }
    }
}
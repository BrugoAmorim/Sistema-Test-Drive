using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Api.Database
{
    public class TestDriveDatabase
    {
        Models.dbTestDriveContext ctx = new Models.dbTestDriveContext();
        public List<Models.TbCarro> listarcarros(){

            List<Models.TbCarro> carros = ctx.TbCarros.Include(x => x.IdCambioNavigation)
                                                      .Include(x => x.IdModeloNavigation)
                                                      .Include(x => x.IdCombustivelNavigation)
                                                      .Include(x => x.IdFabricanteNavigation)
                                                      .ToList();

            return carros;
        }
    }
}
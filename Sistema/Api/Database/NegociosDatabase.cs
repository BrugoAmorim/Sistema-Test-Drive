using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Database
{
    public class NegociosDatabase
    {
        Database.TestDriveDatabase dbTest = new TestDriveDatabase();
        public List<Models.Response.CarrosRequeridosResponse> NumeroAgendamentos(){

            Utils.NegociosUtils conversor = new Utils.NegociosUtils();
            List<Models.TbTestDrive> testsdrives = dbTest.listartestdrives();

            List<Models.Response.CarrosRequeridosResponse> RankingPopulares = 
            testsdrives.GroupBy(x => x.IdCarro)
                    .Select(z => new Models.Response.CarrosRequeridosResponse{
                        numeroagendamentos = z.Where(car => car.IdCarro == car.IdCarro).Count(),
                        carro = conversor.ExtrarInfoCarro(z.First(test => test.IdCarro == test.IdCarro))
                    })
                    .OrderByDescending(x => x.numeroagendamentos)
                    .ToList();

            return RankingPopulares;
        }
    }
}
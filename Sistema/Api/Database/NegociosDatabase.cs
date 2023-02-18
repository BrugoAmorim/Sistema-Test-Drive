using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

#nullable disable
namespace Api.Database
{
    public class NegociosDatabase
    {
        Models.dbTestDriveContext ctx = new Models.dbTestDriveContext();
        Database.TestDriveDatabase dbTest = new TestDriveDatabase();
        Utils.NegociosUtils conversor = new Utils.NegociosUtils();
        public List<Models.Response.CarrosRequeridosResponse> NumeroAgendamentos(){

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

        public List<Models.Response.UsuariosAgendamentosResponse> UsuariosAgendamentos(){

            List<Models.TbTestDrive> tests = ctx.TbTestDrives.Include(x => x.IdClienteNavigation)
                                                             .Include(x => x.IdClienteNavigation.IdUsuarioNavigation)
                                                             .ToList();

            List<Models.Response.UsuariosAgendamentosResponse> AgendamentosUser =
            tests.GroupBy(x => x.IdClienteNavigation.IdUsuario)
            .Select(z => new Models.Response.UsuariosAgendamentosResponse {
                numAgendamentos = z.Where(test => test.IdClienteNavigation.IdUsuario == test.IdClienteNavigation.IdUsuario).Count(),
                usuario = conversor.ExtrairInfoUsuario(z.First(u => u.IdClienteNavigation.IdUsuario == u.IdClienteNavigation.IdUsuario))
            })
            .OrderByDescending(x => x.numAgendamentos)
            .ToList();

            return AgendamentosUser;
        }
    }
}
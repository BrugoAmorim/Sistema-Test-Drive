using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Api.Database
{
    public class TestDriveDatabase
    {
        Models.dbTestDriveContext ctx = new Models.dbTestDriveContext();
        Utils.TestDriveUtils conversor = new Utils.TestDriveUtils();
        public List<Models.TbCarro> listarcarros(){

            List<Models.TbCarro> carros = ctx.TbCarros.Include(x => x.IdCambioNavigation)
                                                      .Include(x => x.IdModeloNavigation)
                                                      .Include(x => x.IdCombustivelNavigation)
                                                      .Include(x => x.IdFabricanteNavigation)
                                                      .ToList();

            return carros;
        }

        public Models.TbCarro buscarCarro(int idcarro){

            List<Models.TbCarro> allcars = listarcarros();
            Models.TbCarro car = allcars.FirstOrDefault(x => x.IdCarro == idcarro);

            return car;
        }

        public Models.TbTestDrive SalvarAgendamento(Models.Request.AgendarRequest req, int iduser){

            Models.TbCliente dadosCliente = conversor.ClienteReqparaTbClient(req, iduser);
            ctx.TbClientes.Add(dadosCliente);
            ctx.SaveChanges();

            Models.TbTestDrive TestDrive = conversor.GerarTbtestdrive(dadosCliente.IdCliente, req.idcarro, req.datatest);
            ctx.TbTestDrives.Add(TestDrive);
            ctx.SaveChanges();       
        
            Models.TbTestDrive Agendamento = ctx.TbTestDrives.Include(x => x.IdClienteNavigation)
                                                             .Include(x => x.IdCarroNavigation)
                                                             .Include(x => x.IdCarroNavigation.IdFabricanteNavigation)
                                                             .Include(x => x.IdCarroNavigation.IdCambioNavigation)
                                                             .Include(x => x.IdCarroNavigation.IdCombustivelNavigation)
                                                             .Include(x => x.IdCarroNavigation.IdModeloNavigation)
                                                             .First(x => x.IdTestDrive == TestDrive.IdTestDrive);

            return Agendamento;
        }

        public List<Models.TbTestDrive> listartestdrives(){

            List<Models.TbTestDrive> tests = ctx.TbTestDrives.Include(x => x.IdClienteNavigation)
                                                             .Include(x => x.IdCarroNavigation)
                                                             .Include(x => x.IdCarroNavigation.IdFabricanteNavigation)
                                                             .Include(x => x.IdCarroNavigation.IdCambioNavigation)
                                                             .Include(x => x.IdCarroNavigation.IdCombustivelNavigation)
                                                             .Include(x => x.IdCarroNavigation.IdModeloNavigation)
                                                             .ToList();

            return tests;
        }

        public Models.TbTestDrive buscarAgendamentoId(int id){

            Models.TbTestDrive test = ctx.TbTestDrives.Include(x => x.IdClienteNavigation)
                                                      .Include(x => x.IdCarroNavigation)
                                                      .Include(x => x.IdCarroNavigation.IdFabricanteNavigation)
                                                      .Include(x => x.IdCarroNavigation.IdCambioNavigation)
                                                      .Include(x => x.IdCarroNavigation.IdCombustivelNavigation)
                                                      .Include(x => x.IdCarroNavigation.IdModeloNavigation)
                                                      .FirstOrDefault(x => x.IdTestDrive == id);
            return test;
        }

        public Models.TbTestDrive AgendamentoFeito(Models.TbTestDrive Test){
        
            Test.BlRealizado = true;

            ctx.SaveChanges();
            return Test;
        }

        public Models.TbTestDrive AgendamentoNaoFeito(Models.TbTestDrive Test){

            Test.BlRealizado = false;

            ctx.SaveChanges();
            return Test;
        }

        public Models.TbTestDrive DesmarcarTestDrive(int idtest){

            Models.TbTestDrive agend = buscarAgendamentoId(idtest);
            agend.BlDesmarcado = true;

            ctx.SaveChanges();
            return agend;
        }
    }
}
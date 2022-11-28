using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace Api.Business
{
    public class TestDriveBusiness
    {
        Database.TestDriveDatabase bd = new Database.TestDriveDatabase();
        public List<Models.TbCarro> validarBuscarCarros(){

            List<Models.TbCarro> allCars = bd.listarcarros();

            if(allCars.Count == 0)
                throw new ArgumentException("Nenhum carro foi encontrado");

            return allCars;
        }

        public List<Models.TbCarro> validarFiltroModelo(string modelo){
            
            List<Models.TbCarro> allCars = bd.listarcarros();
            List<Models.TbCarro> filterCars = allCars.Where(x => x.IdModeloNavigation.DsModelo == modelo).ToList();

            if(filterCars.Count == 0)
                throw new ArgumentException("Não há registros de carros com este modelo");

            return filterCars;            
        }

        public Models.TbTestDrive validarNovoAgendamento(Models.Request.AgendarRequest req, int iduser){

            ValidarCamposBusiness TestDrive = new ValidarCamposBusiness();

            Database.UsuarioDatabase dbuser = new Database.UsuarioDatabase();
            Models.TbUsuario user = dbuser.buscarUsuarioId(iduser);

            if(user == null)
                throw new ArgumentException("Este usuário não existe");

            if(string.IsNullOrEmpty(req.cliente))
                throw new ArgumentException("Campo Nome do cliente é obrigatorio");
                
            if(string.IsNullOrEmpty(req.endereco))
                throw new ArgumentException("Campo Endereço é obrigatorio");

            if(string.IsNullOrEmpty(req.rg))
                throw new ArgumentException("Campo Rg é obrigatorio");
            
            if(string.IsNullOrEmpty(req.cpf))
                throw new ArgumentException("Campo Cpf é obrigatorio");
                
            if(string.IsNullOrEmpty(req.cnh))
                throw new ArgumentException("Campo Cnh é obrigatorio");

            if(req.telefone.Length > 20)
                throw new ArgumentException("Este telefone é inválido");
                
            if(req.celular.Length > 20)
                throw new ArgumentException("Este celular é inválido");

            TestDrive.ValidarData(req.datatest);

            Models.TbTestDrive agendamento = bd.SalvarAgendamento(req, iduser);
            return agendamento;
        }

        public List<Models.TbTestDrive> validarGetAgendamentos(){

            List<Models.TbTestDrive> testsdrives = bd.listartestdrives();

            if(testsdrives.Count == 0)
                throw new ArgumentException("Não foram encontrados nenhum registro");

            return testsdrives; 
        }
    }
}
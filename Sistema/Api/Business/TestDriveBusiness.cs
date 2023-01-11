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
        Database.UsuarioDatabase bduser = new Database.UsuarioDatabase();
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

        public List<Models.TbTestDrive> validarGetAgendamentos(int idusuario){

            List<Models.TbTestDrive> testsdrives = bd.listartestdrives();            

            if(testsdrives.Count == 0)
                throw new ArgumentException("Não foram encontrados nenhum registro");

            Models.TbUsuario usuario = bduser.buscarUsuarioId(idusuario);

            if(usuario == null)
                throw new ArgumentException("Usuário não identificado");

            List<Models.TbTestDrive> userAgend = testsdrives.Where(x => x.IdClienteNavigation.IdUsuario == idusuario).ToList();

            if(userAgend.Count == 0 && usuario.IdNivelAcesso != 1)
                throw new ArgumentException("Você ainda não fez nenhum agendamento");

            if(usuario.IdNivelAcesso != 1)
                return userAgend;
                
            else
                return testsdrives;
        }

        public Models.TbTestDrive validarMarcarAgendamentoFeito(int idagendamento){

            Models.TbTestDrive Test = bd.buscarAgendamentoId(idagendamento);

            if(idagendamento <= 0)
                throw new ArgumentException("Agendamento inválido");

            if(Test == null)
                throw new ArgumentException("Este agendamento não foi encontrado");

            if(Test.BlDesmarcado == true)
                throw new ArgumentException("Você não pode marcar como feito um test drive que foi desmarcado");

            if(Test.BlRealizado == true)
                throw new ArgumentException("Este agendamento já foi marcado como feito");

            return bd.AgendamentoFeito(Test);
        }

        public Models.TbTestDrive validarMarcarAgendamentoNaoFeito(int idagendamento){
            
            Models.TbTestDrive Test = bd.buscarAgendamentoId(idagendamento);

            if(idagendamento <= 0)
                throw new ArgumentException("Agendamento inválido");

            if(Test == null)
                throw new ArgumentException("Este agendamento não foi encontrado");

            if(Test.BlDesmarcado == true)
                throw new ArgumentException("Este agendamento foi desmarcado");

            if(DateTime.Now > Test.DtTestDrive)
                throw new ArgumentException("Você não pode marcar como não feito um agendamento fora da data estabelecida");

            return bd.AgendamentoNaoFeito(Test);
        }

        public Models.TbTestDrive validarBuscarAgendamento(int idagendamento){
            
            Models.TbTestDrive Test = bd.buscarAgendamentoId(idagendamento);

            if(idagendamento <= 0)
                throw new ArgumentException("Agendamento inválido");

            if(Test == null)
                throw new ArgumentException("Este agendamento não foi encontrado");
        
            return Test;
        }
    
        public Models.TbTestDrive validarDesmarcarTestDrive(int idusuario, int idcliente, int idtest){

            ClienteBusiness validacoesusuario = new ClienteBusiness();
            Models.TbUsuario user = validacoesusuario.validarUsuario(idusuario);
            Models.TbCliente client = validacoesusuario.validarCliente(idcliente);

            if(client.IdUsuario != user.IdUsuario && user.IdUsuario != 1)
                throw new ArgumentException("O seu usuário não criou o registro desse cliente");

            Models.TbTestDrive testdrive = bd.buscarAgendamentoId(idtest);

            if(testdrive == null)
                throw new ArgumentException("Esse teste drive não foi encontrado");

            if(testdrive.IdCliente != client.IdCliente && user.IdUsuario != 1)
                throw new ArgumentException("Você não tem permissão para desmarcar esse teste drive");

            if(testdrive.BlDesmarcado == true)
                throw new ArgumentException("Esse teste drive já foi desmarcado");

            Models.TbTestDrive teste = bd.DesmarcarTestDrive(idtest);
            return teste;
        }
    }
}
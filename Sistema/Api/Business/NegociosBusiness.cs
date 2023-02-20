using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Business
{
    public class NegociosBusiness
    {
        Database.NegociosDatabase dbNegocios = new Database.NegociosDatabase();
        Database.TestDriveDatabase testsbd = new Database.TestDriveDatabase();
        
        public void validarAcessoUsuario(int iduser){

            Database.UsuarioDatabase userbd = new Database.UsuarioDatabase();
    
            Models.TbUsuario user = userbd.buscarUsuarioId(iduser);
            if(user == null)
                throw new ArgumentException("Esse usuário não foi encontrado");

            if(user.IdNivelAcesso != 1)
                throw new ArgumentException("Você não tem permissão para acessar essa funcionalidade");

        }
        public List<Models.Response.CarrosRequeridosResponse> validarCarrosPopulares(int idusuario){

            validarAcessoUsuario(idusuario);

            List<Models.TbCarro> carros = testsbd.listarcarros();
            if(carros.Count == 0)
                throw new ArgumentException("Nenhum carro foi encontrado no sistema");

            List<Models.Response.CarrosRequeridosResponse> carroNumAgendamentos = dbNegocios.NumeroAgendamentos();
            return carroNumAgendamentos;
        }

        public List<Models.Response.UsuariosAgendamentosResponse> validarAgendamentosUsuarios(int idusuario){

            validarAcessoUsuario(idusuario);

            List<Models.TbTestDrive> tests = testsbd.listartestdrives();
            if(tests.Count == 0)
                throw new ArgumentException("Ainda não há registros agendamentos");

            List<Models.Response.UsuariosAgendamentosResponse> NumAgend = dbNegocios.UsuariosAgendamentos();
            return NumAgend;
        }

        public List<Models.Response.ModelosAgendamentosResponse> validarAgendamentosModelos(int idusuario){

            validarAcessoUsuario(idusuario);

            List<Models.TbModelo> modelos = testsbd.listarmodelos();
            if(modelos.Count == 0)
                throw new ArgumentException("Nenhum modelo de carro foi encontrado");

            List<Models.Response.ModelosAgendamentosResponse> NumAgendModelos = dbNegocios.ModelosAgendamentos();
            return NumAgendModelos;
        }
    }
}
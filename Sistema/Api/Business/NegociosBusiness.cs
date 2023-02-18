using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Business
{
    public class NegociosBusiness
    {
        Database.UsuarioDatabase userbd = new Database.UsuarioDatabase();
        Database.TestDriveDatabase carrosbd = new Database.TestDriveDatabase();
        Database.NegociosDatabase negociosbd = new Database.NegociosDatabase();
        public List<Models.Response.CarrosRequeridosResponse> validarCarrosPopulares(int idusuario){

            Models.TbUsuario user = userbd.buscarUsuarioId(idusuario);
            if(user == null)
                throw new ArgumentException("Esse usuário não foi encontrado");

            if(user.IdNivelAcesso != 1)
                throw new ArgumentException("Você não tem permissão para acessar essa funcionalidade");

            List<Models.TbCarro> carros = carrosbd.listarcarros();
            if(carros.Count == 0)
                throw new ArgumentException("Nenhum carro foi encontrado no sistema");

            List<Models.Response.CarrosRequeridosResponse> carroNumAgendamentos = negociosbd.NumeroAgendamentos();
            return carroNumAgendamentos;
        }
    }
}
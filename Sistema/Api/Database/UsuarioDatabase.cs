using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace Api.Database
{
    public class UsuarioDatabase
    {
        Models.dbTestDriveContext ctx = new Models.dbTestDriveContext();
        
        public Models.TbUsuario buscarUsuarioEmail(string email){

            List<Models.TbUsuario> usuarios = ctx.TbUsuarios.ToList();

            Models.TbUsuario user = usuarios.FirstOrDefault(x => x.DsEmail == email);
            return user;
        }

        public Models.TbUsuario salvarNovaConta(Models.Request.NovaContaRequest req){

            Utils.AcessoUtils conversor = new Utils.AcessoUtils();
            Models.TbUsuario novoUser = conversor.UsuarioReqparaTbUsuario(req);

            ctx.TbUsuarios.Add(novoUser);
            ctx.SaveChanges();

            return novoUser;
        }

        public Models.TbNivelAcesso nivelacesso(int idnivel){

            Models.TbNivelAcesso nvl = ctx.TbNivelAcessos.First(x => x.IdNivelAcesso == idnivel);
            return nvl;
        }

        public Models.TbUsuario buscarUsuarioId(int iduser){

            Models.TbUsuario user = ctx.TbUsuarios.FirstOrDefault(x => x.IdUsuario == iduser);
            return user;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Database
{
    public class UsuarioDatabase
    {
        Models.dbTestDriveContext ctx = new Models.dbTestDriveContext();

        public Models.TbUsuario ?buscarUsuarioEmail(string ?email){

            List<Models.TbUsuario> usuarios = ctx.TbUsuarios.ToList();

            Models.TbUsuario ?user = usuarios.FirstOrDefault(x => x.DsEmail == email);
            return user;
        }
    }
}
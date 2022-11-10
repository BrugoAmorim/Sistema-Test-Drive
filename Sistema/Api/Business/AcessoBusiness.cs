using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Business
{
    public class AcessoBusiness
    {
        Database.UsuarioDatabase bd = new Database.UsuarioDatabase();
        public Models.TbUsuario validarLogin(Models.Request.LoginRequest req){

            if(string.IsNullOrEmpty(req.email))
                throw new ArgumentException("Campo email obrigátorio");

            if(string.IsNullOrEmpty(req.senha))
                throw new ArgumentException("Campo Senha obrigátorio");

            Models.TbUsuario ?usuario = bd.buscarUsuarioEmail(req.email);

            if(usuario == null)
                throw new ArgumentException("Este usuário não foi encontrado");

            if(usuario.DsSenha != req.senha)
                throw new ArgumentException("Senha incorreta, tente novamente");

            return usuario;
        }
    }
}
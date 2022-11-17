using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Business
{
    public class AcessoBusiness
    {
        Database.UsuarioDatabase bd = new Database.UsuarioDatabase();
        ValidarCamposBusiness ValidarCampos = new ValidarCamposBusiness();
        public Models.TbUsuario validarLogin(Models.Request.LoginRequest req){

            if(string.IsNullOrEmpty(req.email))
                throw new ArgumentException("Campo email obrigátorio");

            if(string.IsNullOrEmpty(req.senha))
                throw new ArgumentException("Campo Senha obrigátorio");

            if(ValidarCampos.ValidarEmail(req.email) == false)
                throw new ArgumentException("Insira um Email válido");

            Models.TbUsuario ?usuario = bd.buscarUsuarioEmail(req.email);

            if(usuario == null)
                throw new ArgumentException("Este usuário não foi encontrado");

            if(usuario.DsSenha != req.senha)
                throw new ArgumentException("Senha incorreta, tente novamente");

            return usuario;
        }

        public Models.TbUsuario validarNovaConta(Models.Request.NovaContaRequest req){

            if(string.IsNullOrEmpty(req.email))
                throw new ArgumentException("Campo Email é obrigátorio");

            if(string.IsNullOrEmpty(req.usuario))
                throw new ArgumentException("Campo nome de usuário é obrigátorio");

            if(string.IsNullOrEmpty(req.senha))
                throw new ArgumentException("Campo senha é obrigatorio");
                
            if(req.senha != req.confirmarsenha)
                throw new ArgumentException("As senhas não coincidem");

            if(req.nascimento.Year >= DateTime.Now.Year)
                throw new ArgumentException("Data de nascimento inválida");

            Models.TbUsuario ?usuario = bd.buscarUsuarioEmail(req.email);
            if(usuario != null)
                throw new ArgumentException("Um usuário já esta utilizando este email");

            if(ValidarCampos.ValidarEmail(req.email) == false)
                throw new ArgumentException("Este email é inválido");

            ValidarCampos.ValidarSenha(req.senha);

            Models.TbUsuario usuarioCriado = bd.salvarNovaConta(req);
            return usuarioCriado;
        }
    }
}
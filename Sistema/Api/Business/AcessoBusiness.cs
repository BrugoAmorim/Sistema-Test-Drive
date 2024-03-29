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

            Models.TbUsuario usuariologado = bd.LoginUsuario(req);
            return usuariologado;
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

        public Models.TbUsuario validarEditarConta(Models.Request.EditarContaRequest req, int idusuario){

            Models.TbUsuario user = bd.buscarUsuarioId(idusuario);

            if(user == null)
                throw new ArgumentException("Esse usuário não existe");

            if(string.IsNullOrEmpty(req.usuario))
                throw new ArgumentException("campo usuário obrigatorio");

            if(string.IsNullOrEmpty(req.antigasenha))
                throw new ArgumentException("Campo antiga senha obrigatorio");
            
            if(string.IsNullOrEmpty(req.senha))
                throw new ArgumentException("Campo senha obrigatorio");
                
            if(string.IsNullOrEmpty(req.confirmarsenha))
                throw new ArgumentException("Campo confirmar senha é obrigatorio");
                
            if(req.senha != req.confirmarsenha)
                throw new ArgumentException("As senhas não coincidem");

            if(user.DsSenha != req.antigasenha)
                throw new ArgumentException("Senha incorreta");

            ValidarCampos.ValidarSenha(req.senha);

            if(req.nascimento.Year == DateTime.Now.Year)
                throw new ArgumentException("Insira uma data de nascimento válida");

            Models.TbUsuario usuarioatualizado = bd.EditarContaUser(req, idusuario);
            return usuarioatualizado;
        }
    
        public void validarApagarConta(int iduser, string senhaacesso){

            Models.TbUsuario user = bd.buscarUsuarioId(iduser);

            if(iduser <= 0)
                throw new ArgumentException("Esse usuário é inválido");

            if(user == null)
                throw new ArgumentException("Esse usuário não foi encontrado");

            if(string.IsNullOrEmpty(senhaacesso))
                throw new ArgumentException("Campo senha de acesso vazio");

            if(user.DsSenha != senhaacesso)
                throw new ArgumentException("Senha de acesso incorreta");

            bd.ApagarUsuario(iduser);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Utils
{
    public class AcessoUtils
    {
        
        public Models.Response.LoginResponse TbUsuarioparaLoginRes(Models.TbUsuario req){

            Models.dbTestDriveContext ctx = new Models.dbTestDriveContext();
            List<Models.TbNivelAcesso> niveis = ctx.TbNivelAcessos.ToList();
            Models.TbNivelAcesso cargo = niveis.First(x => x.IdNivelAcesso == req.IdNivelAcesso);

            Models.Response.LoginResponse usuarioRes = new Models.Response.LoginResponse();
            usuarioRes.idusuario = req.IdUsuario;
            usuarioRes.email = req.DsEmail;
            usuarioRes.usuario = req.NmUsuario;
            usuarioRes.datanascimento = req.DtNascimento;
            usuarioRes.ultimologin = req.DtUltimoLogin;
            usuarioRes.contacriada = req.DtContaCriada;
            usuarioRes.contaatualizada = req.DtContaAtualizada;
            usuarioRes.nivelacesso = cargo.DsNivel;

            return usuarioRes;
        }

        public Models.TbUsuario UsuarioReqparaTbUsuario(Models.Request.NovaContaRequest req){

            Models.TbUsuario modelTb = new Models.TbUsuario();

            modelTb.DsEmail = req.email;
            modelTb.DtNascimento = req.nascimento;
            modelTb.NmUsuario = req.usuario;
            modelTb.DsSenha = req.senha;
            modelTb.DtContaCriada = DateTime.Now;
            modelTb.DtContaAtualizada = DateTime.Now;
            modelTb.DtUltimoLogin = DateTime.Now;
            modelTb.IdNivelAcesso = 2;

            return modelTb;
        }
    }
}
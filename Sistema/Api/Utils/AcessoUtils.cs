using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Utils
{
    public class AcessoUtils
    {
        Database.UsuarioDatabase banco = new Database.UsuarioDatabase();
        
        public Models.Response.LoginResponse TbUsuarioparaLoginRes(Models.TbUsuario req){

            Models.TbNivelAcesso cargo = banco.nivelacesso(req.IdNivelAcesso);

            Models.Response.LoginResponse usuarioRes = new Models.Response.LoginResponse();
            usuarioRes.codigo = 200;
            usuarioRes.status = "Sucesso";
            usuarioRes.mensagem = "Ação realizada com êxito";

            Models.Response.LoginResponse.Dados dados = new Models.Response.LoginResponse.Dados();
            dados.idusuario = req.IdUsuario;
            dados.email = req.DsEmail;
            dados.usuario = req.NmUsuario;
            dados.datanascimento = req.DtNascimento;
            dados.ultimologin = req.DtUltimoLogin;
            dados.contacriada = req.DtContaCriada;
            dados.contaatualizada = req.DtContaAtualizada;
            dados.nivelacesso = cargo.DsNivel;

            usuarioRes.dados = dados;
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
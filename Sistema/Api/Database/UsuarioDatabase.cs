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

        public Models.TbUsuario EditarContaUser(Models.Request.EditarContaRequest req, int idusuario){

            Models.TbUsuario user = buscarUsuarioId(idusuario);
            user.NmUsuario = req.usuario;
            user.DsSenha = req.senha;
            user.DtNascimento = req.nascimento;

            ctx.SaveChanges();
            return user;
        }

        public void ApagarUsuario(int iduser){

            Models.TbUsuario user = ctx.TbUsuarios.First(x => x.IdUsuario == iduser);
            List<Models.TbCliente> clientesUser = ctx.TbClientes.Where(x => x.IdUsuario == user.IdUsuario).ToList();

            List<Models.TbTestDrive> testesdrives = ctx.TbTestDrives.ToList();
            foreach(Models.TbCliente client in clientesUser){

                Models.TbTestDrive test = testesdrives.First(x => x.IdCliente == client.IdCliente);
                
                ctx.TbTestDrives.Remove(test);
                ctx.SaveChanges();
            }

            ctx.TbClientes.RemoveRange(clientesUser);
            ctx.SaveChanges();
            
            List<Models.TbFeedback> avaliacoes = ctx.TbFeedbacks.Where(x => x.IdUsuario == user.IdUsuario).ToList();
            foreach(Models.TbFeedback feedback in avaliacoes){

                ctx.TbFeedbacks.Remove(feedback);
                ctx.SaveChanges();
            }

            ctx.TbUsuarios.Remove(user);
            ctx.SaveChanges();
        }
    }
}
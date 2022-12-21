using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

#nullable disable
namespace Api.Database
{
    public class ClienteDatabase
    {
        Models.dbTestDriveContext ctx = new Models.dbTestDriveContext();

        public Models.TbCliente buscarClienteId(int idcliente){

            Models.TbCliente tbcliente = ctx.TbClientes.FirstOrDefault(x => x.IdCliente == idcliente);
            return tbcliente;
        }

        public Models.TbUsuario buscarUsuarioId(int idusuario){

            Models.TbUsuario tbuser = ctx.TbUsuarios.FirstOrDefault(x => x.IdUsuario == idusuario);         
            return tbuser;
        }

        public Models.TbCliente atualizardadosCliente(Models.Request.ClienteRequest req, int idcliente, int idusuario){

            Models.TbCliente dadoscliente = ctx.TbClientes.First(x => x.IdCliente == idcliente && 
                                                                      x.IdUsuario == idusuario);
            dadoscliente.NmCliente = req.nomecliente;
            dadoscliente.NrCelular = req.celular;
            dadoscliente.NrTelefone = req.telefone;
            dadoscliente.NrCnh = req.cnh;
            dadoscliente.NrCpf = req.cpf;
            dadoscliente.NrRg = req.rg;
            dadoscliente.DsEndereco = req.endereco;
            ctx.SaveChanges();
            
            return dadoscliente;
        }
    }
}
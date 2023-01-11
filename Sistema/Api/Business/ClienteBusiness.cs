using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Business
{
    public class ClienteBusiness
    {
        Database.ClienteDatabase clientedb = new Database.ClienteDatabase();
        ValidarCamposBusiness validatefields = new ValidarCamposBusiness();

        public Models.TbCliente validarDadosCliente(Models.Request.ClienteRequest req, int iduser, int idcliente){
            
            Models.TbUsuario uservalido = clientedb.buscarUsuarioId(iduser);

            if(uservalido == null)
                throw new ArgumentException("O registro desse usuário não foi encontrado");

            Models.TbCliente clientevalido = clientedb.buscarClienteId(idcliente);

            if(clientevalido == null)
                throw new ArgumentException("O registro desse cliente não foi encontrado");

            if(string.IsNullOrEmpty(req.nomecliente))
                throw new ArgumentException("Campo Nome do cliente é obrigatorio");
                
            if(string.IsNullOrEmpty(req.endereco))
                throw new ArgumentException("Campo Endereço é obrigatorio");

            if(string.IsNullOrEmpty(req.rg))
                throw new ArgumentException("Campo Rg é obrigatorio");
            
            if(string.IsNullOrEmpty(req.cpf))
                throw new ArgumentException("Campo Cpf é obrigatorio");
                
            if(string.IsNullOrEmpty(req.cnh))
                throw new ArgumentException("Campo Cnh é obrigatorio");

            if(req.telefone.Length > 20)
                throw new ArgumentException("Este telefone é inválido");
                
            if(req.celular.Length > 20)
                throw new ArgumentException("Este celular é inválido");

            Models.TbCliente dadosAtualizados = clientedb.atualizardadosCliente(req, idcliente, iduser);
            return dadosAtualizados;
        }
    
        public Models.TbCliente validarCliente(int idcliente){

            Models.TbCliente client = clientedb.buscarClienteId(idcliente);

            if(idcliente == 0)
                throw new ArgumentException("Este cliente é inválido");

            if(client == null)
                throw new ArgumentException("Este cliente não foi encontrado");

            return client;
        }

        public Models.TbUsuario validarUsuario(int idusuario){

            Models.TbUsuario user = clientedb.buscarUsuarioId(idusuario);

            if(idusuario == 0)
                throw new ArgumentException("Este usuario é inválido");

            if(user == null)
                throw new ArgumentException("Este usuário não foi encontrado");

            return user;
        }
    }
}
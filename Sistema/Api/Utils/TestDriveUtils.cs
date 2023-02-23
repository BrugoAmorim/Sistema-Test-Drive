using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable
namespace Api.Utils
{
    public class TestDriveUtils
    {
        public Models.Response.CarrosResponse TbCarroparaCarroRes(Models.TbCarro req){

            Models.Response.CarrosResponse res = new Models.Response.CarrosResponse();
            res.idcarro = req.IdCarro;
            res.carro = req.NmCarro;
            res.anofabricacao = req.DtAnoFabricacao;
            res.anomodelo = req.DtAnoModelo;
            res.potencia = req.DsPotencia;
            res.preco = req.VlPreco;
            res.fabricante = req.IdFabricanteNavigation.DsFabricante;
            res.cambio = req.IdCambioNavigation.DsCambio;
            res.combustivel = req.IdCombustivelNavigation.DsCombustivel;
            res.modelo = req.IdModeloNavigation.DsModelo;

            return res;
        }

        public List<Models.Response.CarrosResponse> ListarCarrosRes(List<Models.TbCarro> lista){

            List<Models.Response.CarrosResponse> cars = new List<Models.Response.CarrosResponse>();
            
            foreach(Models.TbCarro item in lista)
            {
                cars.Add(TbCarroparaCarroRes(item));
            }

            return cars;
        }

        public Models.TbCliente ClienteReqparaTbClient(Models.Request.AgendarRequest req, int iduser){

            Models.TbCliente dadoscliente = new Models.TbCliente();
            dadoscliente.NmCliente = req.cliente;
            dadoscliente.DsEndereco = req.endereco;
            dadoscliente.NrCpf = req.cpf;
            dadoscliente.NrRg = req.rg;
            dadoscliente.NrCnh = req.cnh;
            dadoscliente.NrTelefone = req.telefone;
            dadoscliente.NrCelular = req.celular;
            dadoscliente.IdUsuario = iduser;
            
            return dadoscliente;
        }

        public Models.Response.ClienteCompostoResponse TbClienteparaClienteCompRes(Models.TbCliente cliente){

            Models.Response.ClienteCompostoResponse clienteres = new Models.Response.ClienteCompostoResponse();
            clienteres.codigo = 200;
            clienteres.status = "sucesso";
            clienteres.mensagem = "Ação realizada com êxito";

            Models.Response.ClienteCompostoResponse.Dados infocliente = new Models.Response.ClienteCompostoResponse.Dados();
            infocliente.idcliente = cliente.IdCliente;
            infocliente.cliente = cliente.NmCliente;
            infocliente.endereco = cliente.DsEndereco;
            infocliente.rg = cliente.NrRg;
            infocliente.cpf = cliente.NrCpf;
            infocliente.cnh = cliente.NrCnh;
            infocliente.telefone = cliente.NrTelefone;
            infocliente.celular = cliente.NrCelular;
            infocliente.idusuario = cliente.IdUsuario;

            clienteres.dados = infocliente;
            return clienteres;
        }

        public Models.Response.ClienteSimpleResponse TbClienteparaClienteSimpRes(Models.TbCliente cliente){

            Models.Response.ClienteSimpleResponse infocliente = new Models.Response.ClienteSimpleResponse();
            infocliente.idcliente = cliente.IdCliente;
            infocliente.cliente = cliente.NmCliente;
            infocliente.endereco = cliente.DsEndereco;
            infocliente.rg = cliente.NrRg;
            infocliente.cpf = cliente.NrCpf;
            infocliente.cnh = cliente.NrCnh;
            infocliente.telefone = cliente.NrTelefone;
            infocliente.celular = cliente.NrCelular;
            infocliente.idusuario = cliente.IdUsuario;

            return infocliente;
        }

        public Models.TbTestDrive GerarTbtestdrive(int idcliente, int idcarro, DateTime datatest){

            Models.TbTestDrive test = new Models.TbTestDrive();
            test.IdCarro = idcarro;
            test.IdCliente = idcliente;
            test.DtTestDrive = datatest;
            test.BlDesmarcado = false;
            test.BlRealizado = false;

            return test;
        }

        public Models.Response.AgendamentoResponse TbTestDriveparaTestRes(Models.TbTestDrive test){

            Models.Response.AgendamentoResponse TestRes = new Models.Response.AgendamentoResponse();
            TestRes.codigo = 200;
            TestRes.status = "Sucesso";
            if(test.BlDesmarcado == false)
                TestRes.mensagem = "Seu test drive foi marcado com sucesso";
            else if(test.BlDesmarcado == true)
                TestRes.mensagem = "Seu test drive foi desmarcado com sucesso";    

            Models.Response.TestDriveResponse data = new Models.Response.TestDriveResponse();
            data.idagendamento = test.IdTestDrive;
            data.datatest = test.DtTestDrive;
            data.desmarcado = test.BlDesmarcado;
            data.realizado = test.BlRealizado;
            data.Carro = TbCarroparaCarroRes(test.IdCarroNavigation);
            data.Cliente = TbClienteparaClienteSimpRes(test.IdClienteNavigation);

            TestRes.dados = data;
            return TestRes;
        }

        public List<Models.Response.AgendamentoResponse> TbListaTestparaTestRes(List<Models.TbTestDrive> req){

            List<Models.Response.AgendamentoResponse> agendamentosRes = new List<Models.Response.AgendamentoResponse>();

            foreach(Models.TbTestDrive item in req)
            {
                agendamentosRes.Add(TbTestDriveparaTestRes(item));
            }

            return agendamentosRes;
        }
    }
}
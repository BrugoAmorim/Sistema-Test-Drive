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

        public Models.Response.ClienteResponse TbClienteparaClienteRes(Models.TbCliente cliente){

            Models.Response.ClienteResponse infocliente = new Models.Response.ClienteResponse();
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
            TestRes.idagendamento = test.IdTestDrive;
            TestRes.datatest = test.DtTestDrive;
            TestRes.desmarcado = test.BlDesmarcado;
            TestRes.realizado = test.BlRealizado;
            TestRes.Carro = TbCarroparaCarroRes(test.IdCarroNavigation);
            TestRes.Cliente = TbClienteparaClienteRes(test.IdClienteNavigation);

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
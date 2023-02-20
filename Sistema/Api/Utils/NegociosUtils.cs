using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable
namespace Api.Utils
{
    public class NegociosUtils
    {
        public Models.Response.CarrosResponse ExtrarInfoCarro(Models.TbTestDrive test){

            Models.Response.CarrosResponse infoCar = new Models.Response.CarrosResponse();
            infoCar.idcarro = test.IdCarro;
            infoCar.carro = test.IdCarroNavigation.NmCarro;
            infoCar.anofabricacao = test.IdCarroNavigation.DtAnoFabricacao;
            infoCar.anomodelo = test.IdCarroNavigation.DtAnoModelo;
            infoCar.potencia = test.IdCarroNavigation.DsPotencia;
            infoCar.preco = test.IdCarroNavigation.VlPreco;
            infoCar.cambio = test.IdCarroNavigation.IdCambioNavigation.DsCambio;
            infoCar.modelo = test.IdCarroNavigation.IdModeloNavigation.DsModelo;
            infoCar.combustivel = test.IdCarroNavigation.IdCombustivelNavigation.DsCombustivel;
            infoCar.fabricante = test.IdCarroNavigation.IdFabricanteNavigation.DsFabricante;

            return infoCar;
        }

        public Models.Response.UsuariosAgendamentosResponse.Usuario ExtrairInfoUsuario(Models.TbTestDrive test){

            Database.UsuarioDatabase userbd = new Database.UsuarioDatabase();
            Models.TbNivelAcesso nvlacesso = userbd.nivelacesso(test.IdClienteNavigation.IdUsuarioNavigation.IdNivelAcesso);

            Models.Response.UsuariosAgendamentosResponse.Usuario user = new Models.Response.UsuariosAgendamentosResponse.Usuario();
            user.email = test.IdClienteNavigation.IdUsuarioNavigation.DsEmail;
            user.nome = test.IdClienteNavigation.IdUsuarioNavigation.NmUsuario;
            user.nivelacesso = nvlacesso.DsNivel;

            return user;
        }

        public Models.Response.ModelosAgendamentosResponse.Modelo ExtrairInfoModelo(Models.TbTestDrive test){

            Models.Response.ModelosAgendamentosResponse.Modelo modelo = new Models.Response.ModelosAgendamentosResponse.Modelo();
            modelo.idModelo = test.IdCarroNavigation.IdModelo;
            modelo.modelo = test.IdCarroNavigation.IdModeloNavigation.DsModelo;
        
            return modelo;
        }
    }
}
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

    }
}
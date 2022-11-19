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
    }
}
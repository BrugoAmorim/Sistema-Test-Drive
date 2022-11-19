using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace Api.Business
{
    public class TestDriveBusiness
    {
        Database.TestDriveDatabase bd = new Database.TestDriveDatabase();
        public List<Models.TbCarro> validarBuscarCarros(){

            List<Models.TbCarro> allCars = bd.listarcarros();

            if(allCars.Count == 0)
                throw new ArgumentException("Nenhum carro foi encontrado");

            return allCars;
        }

        public List<Models.TbCarro> validarFiltroModelo(string modelo){
            
            List<Models.TbCarro> allCars = bd.listarcarros();
            List<Models.TbCarro> filterCars = allCars.Where(x => x.IdModeloNavigation.DsModelo == modelo).ToList();

            if(filterCars.Count == 0)
                throw new ArgumentException("Não há registros de carros com este modelo");

            return filterCars;            
        }
    }
}
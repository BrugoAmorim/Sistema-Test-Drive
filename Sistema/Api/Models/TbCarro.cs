using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class TbCarro
    {
        public TbCarro()
        {
            TbTestDrives = new HashSet<TbTestDrive>();
        }

        public int IdCarro { get; set; }
        public string NmCarro { get; set; } = null!;
        public DateTime DtAnoFabricacao { get; set; }
        public DateTime DtAnoModelo { get; set; }
        public string DsPotencia { get; set; } = null!;
        public decimal VlPreco { get; set; }
        public int? IdModelo { get; set; }
        public int? IdFabricante { get; set; }
        public int? IdCambio { get; set; }
        public int? IdCombustivel { get; set; }

        public virtual TbCambio? IdCambioNavigation { get; set; }
        public virtual TbCombustivel? IdCombustivelNavigation { get; set; }
        public virtual TbFabricante? IdFabricanteNavigation { get; set; }
        public virtual TbModelo? IdModeloNavigation { get; set; }
        public virtual ICollection<TbTestDrive> TbTestDrives { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class TbCambio
    {
        public TbCambio()
        {
            TbCarros = new HashSet<TbCarro>();
        }

        public int IdCambio { get; set; }
        public string? DsCambio { get; set; }

        public virtual ICollection<TbCarro> TbCarros { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class TbCombustivel
    {
        public TbCombustivel()
        {
            TbCarros = new HashSet<TbCarro>();
        }

        public int IdCombustivel { get; set; }
        public string? DsCombustivel { get; set; }

        public virtual ICollection<TbCarro> TbCarros { get; set; }
    }
}

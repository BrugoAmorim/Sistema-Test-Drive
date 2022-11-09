using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class TbFabricante
    {
        public TbFabricante()
        {
            TbCarros = new HashSet<TbCarro>();
        }

        public int IdFabricante { get; set; }
        public string? DsFabricante { get; set; }

        public virtual ICollection<TbCarro> TbCarros { get; set; }
    }
}

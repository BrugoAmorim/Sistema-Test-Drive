using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class TbModelo
    {
        public TbModelo()
        {
            TbCarros = new HashSet<TbCarro>();
        }

        public int IdModelo { get; set; }
        public string? DsModelo { get; set; }

        public virtual ICollection<TbCarro> TbCarros { get; set; }
    }
}

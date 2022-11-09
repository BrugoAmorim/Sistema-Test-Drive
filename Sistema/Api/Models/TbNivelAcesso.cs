using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class TbNivelAcesso
    {
        public TbNivelAcesso()
        {
            TbUsuarios = new HashSet<TbUsuario>();
        }

        public int IdNivelAcesso { get; set; }
        public string DsNivel { get; set; } = null!;

        public virtual ICollection<TbUsuario> TbUsuarios { get; set; }
    }
}

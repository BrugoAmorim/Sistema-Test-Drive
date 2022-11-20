using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class TbCliente
    {
        public TbCliente()
        {
            TbTestDrives = new HashSet<TbTestDrive>();
        }

        public int IdCliente { get; set; }
        public string NmCliente { get; set; } = null!;
        public string DsEndereco { get; set; } = null!;
        public string NrRg { get; set; } = null!;
        public string NrCpf { get; set; } = null!;
        public string NrCnh { get; set; } = null!;
        public string? NrTelefone { get; set; }
        public string? NrCelular { get; set; }
        public int IdUsuario { get; set; }

        public virtual TbUsuario? IdUsuarioNavigation { get; set; }
        public virtual ICollection<TbTestDrive> TbTestDrives { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class TbTestDrive
    {
        public int IdTestDrive { get; set; }
        public DateTime DtTestDrive { get; set; }
        public bool BlDesmarcado { get; set; }
        public bool BlRealizado { get; set; }
        public int? IdCliente { get; set; }
        public int? IdCarro { get; set; }

        public virtual TbCarro? IdCarroNavigation { get; set; }
        public virtual TbCliente? IdClienteNavigation { get; set; }
    }
}

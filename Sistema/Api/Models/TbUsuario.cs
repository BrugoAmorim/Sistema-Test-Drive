using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class TbUsuario
    {
        public TbUsuario()
        {
            TbClientes = new HashSet<TbCliente>();
            TbFeedbacks = new HashSet<TbFeedback>();
        }

        public int IdUsuario { get; set; }
        public string NmUsuario { get; set; } = null!;
        public string DsEmail { get; set; } = null!;
        public string DsSenha { get; set; } = null!;
        public DateTime DtNascimento { get; set; }
        public DateTime DtUltimoLogin { get; set; }
        public DateTime DtContaCriada { get; set; }
        public DateTime DtContaAtualizada { get; set; }
        public int? IdNivelAcesso { get; set; }

        public virtual TbNivelAcesso? IdNivelAcessoNavigation { get; set; }
        public virtual ICollection<TbCliente> TbClientes { get; set; }
        public virtual ICollection<TbFeedback> TbFeedbacks { get; set; }
    }
}

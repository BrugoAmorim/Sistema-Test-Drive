using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class TbFeedback
    {
        public int IdFeedback { get; set; }
        public string DsFeedback { get; set; } = null!;
        public DateTime DtFeedback { get; set; }
        public DateTime DtUltimaAlteracao { get; set; }
        public int? IdAvaliacao { get; set; }
        public int? IdUsuario { get; set; }

        public virtual TbAvaliacao? IdAvaliacaoNavigation { get; set; }
        public virtual TbUsuario? IdUsuarioNavigation { get; set; }
    }
}

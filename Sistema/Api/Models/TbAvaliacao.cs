using System;
using System.Collections.Generic;

namespace Api.Models
{
    public partial class TbAvaliacao
    {
        public TbAvaliacao()
        {
            TbFeedbacks = new HashSet<TbFeedback>();
        }

        public int IdAvaliacao { get; set; }
        public decimal? VlFeedback { get; set; }

        public virtual ICollection<TbFeedback> TbFeedbacks { get; set; }
    }
}

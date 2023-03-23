using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IaraProj.Domain.Entities
{
    public class CotacaoItem
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public Guid IdCotacao { get; set; }
        public virtual Cotacao Cotacao { get; set; }
    }
}

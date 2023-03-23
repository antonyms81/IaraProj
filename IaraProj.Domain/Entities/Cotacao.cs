using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IaraProj.Domain.Entities
{
    public class Cotacao
    {
        public Guid Id { get; set; }
        public string CnpjComprador { get; set; }
        public virtual List<CotacaoItem> CotacaoItens { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IaraProj.Domain.Entities
{
    public class ListaCotacao
    {
        public List<Cotacao> Cotacoes { get; set; } = new();
    }
}

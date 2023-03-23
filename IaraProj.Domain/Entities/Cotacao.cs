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
        public string CNPJFornecedor { get; set; }
        public int NumeroCotacao { get; set; }
        public DateTime DataCotacao { get; set; }
        public DateTime DataEntregaCotacao { get; set; }
        public string CEP { get; set; }
        public string? Logradouro { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? UF { get; set; }
        public string? Observacao { get; set; }
        public virtual List<CotacaoItem> CotacaoItens { get; set; } = new();
    }
}

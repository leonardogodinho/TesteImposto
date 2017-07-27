using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Imposto.Core.Domain
{
    [XmlRoot(ElementName = "NotaFiscalItem")]
    public class NotaFiscalItem
    {
        [XmlElement(ElementName = "Id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "IdNotaFiscal")]
        public int IdNotaFiscal { get; set; }

        [XmlElement(ElementName = "Cfop")]
        public string Cfop { get; set; }

        [XmlElement(ElementName = "TipoIcms")]
        public string TipoIcms { get; set; }

        [XmlElement(ElementName = "BaseIcms")]
        public double BaseIcms { get; set; }

        [XmlElement(ElementName = "AliquotaIcms")]
        public double AliquotaIcms { get; set; }

        [XmlElement(ElementName = "ValorIcms")]
        public double ValorIcms { get; set; }

        [XmlElement(ElementName = "BaseIPI")]
        public double BaseIPI { get; set; }

        [XmlElement(ElementName = "AliquotaIPI")]
        public double AliquotaIPI { get; set; }

        [XmlElement(ElementName = "ValorIPI")]
        public double ValorIPI { get; set; }

        [XmlElement(ElementName = "NomeProduto")]
        public string NomeProduto { get; set; }

        [XmlElement(ElementName = "CodigoProduto")]
        public string CodigoProduto { get; set; }

        [XmlElement(ElementName = "Desconto")]
        public double Desconto { get; set; }
    }
}

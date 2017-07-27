using Imposto.Core.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Imposto.Core.Domain
{
    [XmlRoot(ElementName = "NotaFiscal")]
    public class NotaFiscal
    {
        [XmlElement(ElementName = "Id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "NumeroNotaFiscal")]
        public int NumeroNotaFiscal { get; set; }

        [XmlElement(ElementName = "Serie")]
        public int Serie { get; set; }

        [XmlElement(ElementName = "NomeCliente")]
        public string NomeCliente { get; set; }

        [XmlElement(ElementName = "EstadoDestino")]
        public string EstadoDestino { get; set; }

        [XmlElement(ElementName = "EstadoOrigem")]
        public string EstadoOrigem { get; set; }

        [XmlElement(ElementName = "ItensDaNotaFiscal")]
        public List<NotaFiscalItem> ItensDaNotaFiscal { get; set; }

        public NotaFiscal()
        {
            ItensDaNotaFiscal = new List<NotaFiscalItem>();
        }

        public void EmitirNotaFiscal(Pedido pedido)
        {
            Random rnd = new Random();

            this.NumeroNotaFiscal = rnd.Next(Int32.MaxValue);
            this.Serie = 1;
            this.NomeCliente = pedido.NomeCliente;

            this.EstadoDestino = pedido.EstadoDestino;
            this.EstadoOrigem = pedido.EstadoOrigem;

            foreach (PedidoItem itemPedido in pedido.ItensDoPedido)
            {
                NotaFiscalItem notaFiscalItem = new NotaFiscalItem();
                notaFiscalItem.IdNotaFiscal = rnd.Next(Int32.MaxValue);

                if ((this.EstadoOrigem == "SP") && (this.EstadoDestino == "RJ"))
                {
                    notaFiscalItem.Cfop = "6.000";
                }
                else if ((this.EstadoOrigem == "SP") && (this.EstadoDestino == "PE"))
                {
                    notaFiscalItem.Cfop = "6.001";
                }
                else if ((this.EstadoOrigem == "SP") && (this.EstadoDestino == "MG"))
                {
                    notaFiscalItem.Cfop = "6.002";
                }
                else if ((this.EstadoOrigem == "SP") && (this.EstadoDestino == "PB"))
                {
                    notaFiscalItem.Cfop = "6.003";
                }
                else if ((this.EstadoOrigem == "SP") && (this.EstadoDestino == "PR"))
                {
                    notaFiscalItem.Cfop = "6.004";
                }
                else if ((this.EstadoOrigem == "SP") && (this.EstadoDestino == "PI"))
                {
                    notaFiscalItem.Cfop = "6.005";
                }
                else if ((this.EstadoOrigem == "SP") && (this.EstadoDestino == "RO"))
                {
                    notaFiscalItem.Cfop = "6.006";
                }
                else if ((this.EstadoOrigem == "SP") && (this.EstadoDestino == "SE"))
                {
                    notaFiscalItem.Cfop = "6.007";
                }
                else if ((this.EstadoOrigem == "SP") && (this.EstadoDestino == "TO"))
                {
                    notaFiscalItem.Cfop = "6.008";
                }
                else if ((this.EstadoOrigem == "SP") && (this.EstadoDestino == "SE"))
                {
                    notaFiscalItem.Cfop = "6.009";
                }
                else if ((this.EstadoOrigem == "SP") && (this.EstadoDestino == "PA"))
                {
                    notaFiscalItem.Cfop = "6.010";
                }
                else if ((this.EstadoOrigem == "MG") && (this.EstadoDestino == "RJ"))
                {
                    notaFiscalItem.Cfop = "6.000";
                }
                else if ((this.EstadoOrigem == "MG") && (this.EstadoDestino == "PE"))
                {
                    notaFiscalItem.Cfop = "6.001";
                }
                else if ((this.EstadoOrigem == "MG") && (this.EstadoDestino == "MG"))
                {
                    notaFiscalItem.Cfop = "6.002";
                }
                else if ((this.EstadoOrigem == "MG") && (this.EstadoDestino == "PB"))
                {
                    notaFiscalItem.Cfop = "6.003";
                }
                else if ((this.EstadoOrigem == "MG") && (this.EstadoDestino == "PR"))
                {
                    notaFiscalItem.Cfop = "6.004";
                }
                else if ((this.EstadoOrigem == "MG") && (this.EstadoDestino == "PI"))
                {
                    notaFiscalItem.Cfop = "6.005";
                }
                else if ((this.EstadoOrigem == "MG") && (this.EstadoDestino == "RO"))
                {
                    notaFiscalItem.Cfop = "6.006";
                }
                else if ((this.EstadoOrigem == "MG") && (this.EstadoDestino == "SE"))
                {
                    notaFiscalItem.Cfop = "6.007";
                }
                else if ((this.EstadoOrigem == "MG") && (this.EstadoDestino == "TO"))
                {
                    notaFiscalItem.Cfop = "6.008";
                }
                else if ((this.EstadoOrigem == "MG") && (this.EstadoDestino == "SE"))
                {
                    notaFiscalItem.Cfop = "6.009";
                }
                else if ((this.EstadoOrigem == "MG") && (this.EstadoDestino == "PA"))
                {
                    notaFiscalItem.Cfop = "6.010";
                }
                if (this.EstadoDestino == this.EstadoOrigem)
                {
                    notaFiscalItem.TipoIcms = "60";
                    notaFiscalItem.AliquotaIcms = 0.18;
                }
                else
                {
                    notaFiscalItem.TipoIcms = "10";
                    notaFiscalItem.AliquotaIcms = 0.17;
                }
                if (notaFiscalItem.Cfop == "6.009")
                {
                    notaFiscalItem.BaseIcms = itemPedido.ValorItemPedido * 0.90; //redução de base
                }
                else
                {
                    notaFiscalItem.BaseIcms = itemPedido.ValorItemPedido;
                }
                notaFiscalItem.ValorIcms = Math.Round(notaFiscalItem.BaseIcms * notaFiscalItem.AliquotaIcms, 2);
                notaFiscalItem.BaseIPI = itemPedido.ValorItemPedido;

                if (this.EstadoDestino == "RJ" || this.EstadoDestino == "MG")
                    notaFiscalItem.Desconto = itemPedido.ValorItemPedido * 0.1;
                else
                    notaFiscalItem.Desconto = 0;

                if (itemPedido.Brinde)
                {
                    notaFiscalItem.TipoIcms = "60";
                    notaFiscalItem.AliquotaIcms = 0.18;
                    notaFiscalItem.ValorIcms = Math.Round(notaFiscalItem.BaseIcms * notaFiscalItem.AliquotaIcms, 2);

                    notaFiscalItem.AliquotaIPI = 0;
                }
                else
                {
                    notaFiscalItem.AliquotaIPI = 0.1;
                }
                notaFiscalItem.ValorIPI = Math.Round(notaFiscalItem.BaseIPI * notaFiscalItem.AliquotaIPI, 2);

                notaFiscalItem.NomeProduto = itemPedido.NomeProduto;
                notaFiscalItem.CodigoProduto = itemPedido.CodigoProduto;

                this.ItensDaNotaFiscal.Add(notaFiscalItem);
            }

            if (this.GerarXML())
            {
                NotaFiscalRepository repo = new NotaFiscalRepository();
                repo.InserirNotaFiscal(this);
                foreach (var _nfItem in this.ItensDaNotaFiscal)
                {
                    repo.InserirNotaFiscalItem(_nfItem);
                }
            }
        }

        private bool GerarXML()
        {
            StringBuilder b = new StringBuilder();
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            string path = ConfigurationManager.AppSettings["DiretorioXML"];
            XmlWriterSettings xws = new XmlWriterSettings();
            xws.OmitXmlDeclaration = true;

            try
            {
                using (XmlWriter writer = XmlWriter.Create(b, xws))
                {
                    serializer.Serialize(writer, this);
                    File.WriteAllText(Path.Combine(path, "NF_" + this.NumeroNotaFiscal + ".xml"), b.ToString());
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}

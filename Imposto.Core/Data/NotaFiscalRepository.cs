using Imposto.Core.Domain;
using Imposto.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Data
{
    public class NotaFiscalRepository : BaseRepository
    {
        public int InserirNotaFiscal(NotaFiscal nf)
        {
            List<SqlParameter> parameterCollection = new List<SqlParameter>();
            parameterCollection.Add(new SqlParameter() { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = nf.Id });
            parameterCollection.Add(new SqlParameter() { ParameterName = "@pNumeroNotaFiscal", SqlDbType = SqlDbType.Int, Value = nf.NumeroNotaFiscal });
            parameterCollection.Add(new SqlParameter() { ParameterName = "@pSerie", SqlDbType = SqlDbType.Int, Value = nf.Serie });
            parameterCollection.Add(new SqlParameter() { ParameterName = "@pNomeCliente", SqlDbType = SqlDbType.VarChar, Value = nf.NomeCliente });
            parameterCollection.Add(new SqlParameter() { ParameterName = "@pEstadoDestino", SqlDbType = SqlDbType.VarChar, Value = nf.EstadoDestino });
            parameterCollection.Add(new SqlParameter() { ParameterName = "@pEstadoOrigem", SqlDbType = SqlDbType.VarChar, Value = nf.EstadoOrigem });

            return this.ExecuteNonQueryCommand("P_NOTA_FISCAL", parameterCollection.ToArray());
        }

        public int InserirNotaFiscalItem(NotaFiscalItem nfItem)
        {
            List<SqlParameter> parameterCollection = new List<SqlParameter>();
            parameterCollection.Add(new SqlParameter() { ParameterName = "@pId", SqlDbType = SqlDbType.Int, Value = nfItem.Id });
            parameterCollection.Add(new SqlParameter() { ParameterName = "@pIdNotaFiscal", SqlDbType = SqlDbType.Int, Value = nfItem.IdNotaFiscal });
            parameterCollection.Add(new SqlParameter() { ParameterName = "@pCfop", SqlDbType = SqlDbType.VarChar, Value = nfItem.Cfop });
            parameterCollection.Add(new SqlParameter() { ParameterName = "@pTipoIcms", SqlDbType = SqlDbType.VarChar, Value = nfItem.TipoIcms });
            parameterCollection.Add(new SqlParameter() { ParameterName = "@pBaseIcms", SqlDbType = SqlDbType.Decimal, Value = nfItem.BaseIcms });
            parameterCollection.Add(new SqlParameter() { ParameterName = "@pAliquotaIcms", SqlDbType = SqlDbType.Decimal, Value = nfItem.AliquotaIcms });
            parameterCollection.Add(new SqlParameter() { ParameterName = "@pValorIcms", SqlDbType = SqlDbType.Decimal, Value = nfItem.ValorIcms });
            parameterCollection.Add(new SqlParameter() { ParameterName = "@pBaseIpi", SqlDbType = SqlDbType.Decimal, Value = nfItem.BaseIPI });
            parameterCollection.Add(new SqlParameter() { ParameterName = "@pAliquotaIpi", SqlDbType = SqlDbType.Decimal, Value = nfItem.AliquotaIPI });
            parameterCollection.Add(new SqlParameter() { ParameterName = "@pValorIpi", SqlDbType = SqlDbType.Decimal, Value = nfItem.ValorIPI });
            parameterCollection.Add(new SqlParameter() { ParameterName = "@pNomeProduto", SqlDbType = SqlDbType.VarChar, Value = nfItem.NomeProduto });
            parameterCollection.Add(new SqlParameter() { ParameterName = "@pCodigoProduto", SqlDbType = SqlDbType.VarChar, Value = nfItem.CodigoProduto });
            parameterCollection.Add(new SqlParameter() { ParameterName = "@pDesconto", SqlDbType = SqlDbType.Decimal, Value = nfItem.Desconto });

            return this.ExecuteNonQueryCommand("P_NOTA_FISCAL_ITEM", parameterCollection.ToArray());
        }
    }
}

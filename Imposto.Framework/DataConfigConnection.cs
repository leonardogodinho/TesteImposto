using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Framework
{
    internal static class DataConfigConnection
    {
        internal static string AppConfigConnectionStringSqlServer
        {
            get
            {
                string sqlServerConnection = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;
                if (string.IsNullOrWhiteSpace(sqlServerConnection)) throw new SettingsPropertyNotFoundException("Chave [SqlServerConnection] não encontrada ou inválida em connectionStrings da configuração do projeto");
                return sqlServerConnection;
            }
        }

        internal static string OwnerSqlServer
        {
            get
            {
                string owner = ConfigurationManager.AppSettings["OwnerSqlServer"];
                if (string.IsNullOrWhiteSpace(owner)) throw new SettingsPropertyNotFoundException("Chave [Owner] não encontrada ou inválida no appSettings da configuração do projeto");
                return owner;
            }
        }
    }
}

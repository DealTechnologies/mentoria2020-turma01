using Microsoft.Extensions.Options;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Livraria.Infra.DataContexts
{
    public class DataContext : IDisposable
    {
        public SqlConnection SQLServerConexao { get; set; }

        public DataContext(IOptions<SettingsInfra> opitions)
        {
            try
            {
                SQLServerConexao = new SqlConnection(opitions.Value.ConnectionString);
                SQLServerConexao.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            try
            {
                if (SQLServerConexao.State != ConnectionState.Closed)
                {
                    SQLServerConexao.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

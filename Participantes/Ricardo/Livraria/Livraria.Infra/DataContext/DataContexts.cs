using Microsoft.Extensions.Options;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Livraria.Infra.DataContexts
{
    public class DataContext : IDisposable
    {
        public SqlConnection SqlServerConexao { get; set; }

        public DataContext(IOptions<SettingsInfra> options)
        {
            try
            {
                SqlServerConexao = new SqlConnection(options.Value.ConnectionString);
                SqlServerConexao.Open();
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
                if (SqlServerConexao.State != ConnectionState.Closed) ;
                SqlServerConexao.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

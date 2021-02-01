using Microsoft.Extensions.Options;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Usuario.Infra.DataContexts
{
    public class DataContext : IDisposable
    {
        public SqlConnection SQLConexao { get; set; }

        public DataContext(IOptions<SettingsInfra> options)
        {
            try
            {
                SQLConexao = new SqlConnection(options.Value.ConnectionString);
                SQLConexao.Open();
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
                if(SQLConexao.State != ConnectionState.Open)
                {
                    SQLConexao.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

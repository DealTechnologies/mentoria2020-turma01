using Microsoft.Extensions.Options;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Voto.Infra.DataContexts
{
    public class DataContext : IDisposable
    {
        public SqlConnection SQLServerConnection { get; set; }

        public DataContext(IOptions<SettingsInfra> options)
        {

            try
            {
                SQLServerConnection = new SqlConnection(options.Value.ConnectionString);
                SQLServerConnection.Open();
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
                if (SQLServerConnection.State != ConnectionState.Closed)
                {
                    SQLServerConnection.Close();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}

﻿using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Votacao.Infra.DataContext
{
    public class DataContext : IDisposable
    {
        public SqlConnection SQLConnection { get; set; }

        public DataContext(IOptions<SettingsInfra> options)
        {
            try
            {
                SQLConnection = new SqlConnection(options.Value.ConnectionString);
                SQLConnection.Open();
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
                if (SQLConnection.State != ConnectionState.Closed)
                {
                    SQLConnection.Close();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

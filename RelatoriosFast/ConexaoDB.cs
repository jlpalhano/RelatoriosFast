using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;

namespace RelatoriosFast
{
    class ConexaoDB
    {        
            public static String IP = "192.168.254.251";

            public static OracleConnection GetDBConnection()
            {
                Oracle.ManagedDataAccess.Client.OracleConnection conexao = null;
                String connectionString = ConfigurationManager.ConnectionStrings["conexaoBD"].ConnectionString;
                string con2 = string.Format(connectionString, IP);
                //  conexao = new OracleConnection(connectionString);
                conexao = new OracleConnection(con2);
                return conexao;
            }
        
    }
}


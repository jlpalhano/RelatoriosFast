using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace RelatoriosFast
{
   public class Conn
    {
        public Conn() { }
        public DataSet ListaTodasInstanciasERPReportDAO(string procedure)
        {
            OracleConnection conn = ConexaoDB.GetDBConnection();
            try
            {
                conn.Open();
                DataSet _dataSet = new DataSet();
                OracleCommand comando = conn.CreateCommand();
                comando.CommandText = procedure;
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
             //    OracleDataReader dr2 = comando.ExecuteReader();

                OracleDataAdapter da = new OracleDataAdapter(comando);
                da.Fill(_dataSet);
                comando.ExecuteNonQuery();

                return _dataSet;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}

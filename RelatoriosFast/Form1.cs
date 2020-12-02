using FastReport;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;


namespace RelatoriosFast
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {     
            OracleConnection conn = ConexaoDB.GetDBConnection();
            conn.Open();
             OracleCommand cmd = conn.CreateCommand();
            //  cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.CommandText = "PRC_MN_SELECT_MANTER_INST_CIGAM_ALL_V102";
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT CL.NM_EMPRESA, CC.VERSAO_CIGAM, CC.VERSAO_CIGAM, CC.TP_INST_CIGAM,CC.PATCH_CIGAM FROM TBL_MN_INSTANCIA_CLIENTE_CIGAM CC INNER JOIN TBL_MN_CLIENTES CL ON CL.COD_CLI = CC.COD_CLI";
          //  cmd.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
            dt.Load(dr);
            dt.TableName = "MainReport";

            Report report = new Report();
            report.Load("1.frx");
            report.RegisterData(dt, dt.TableName);
            //COMMENT WHEN YOU FINISHED WITH REPORT DESIGNER
            report.GetDataSource(dt.TableName).Enabled = true;
            report.Design(true);
            report.Prepare();
            report.ShowPrepared();                
                
        }
    }    
}

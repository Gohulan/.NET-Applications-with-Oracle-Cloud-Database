using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;

namespace CloudTry
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			OracleConnection conn = new OracleConnection();
			conn.ConnectionString = "User Id = ADMIN; Password =Demodata@123; Data Source = demooradb_high";
			conn.Open();

			//OracleCommand oraCmd = new OracleCommand("SELECT TABLE_NAME FROM ALL_TABLES", conn);
			OracleCommand oraCmd = new OracleCommand("UPDATE DEMODATA SET FNAME='OLIVER', LNAME='HARRY', ADDRESS='SRI LANKA' WHERE FNAME='OLIVER'", conn);
			OracleDataReader oraReader;
			oraReader = oraCmd.ExecuteReader();
			while (oraReader.Read())
			{
				label1.Text = oraReader.GetString(0);
				label2.Text = oraReader.GetString(1);
				label3.Text = oraReader.GetString(2);

				//MessageBox.Show(oraReader.GetString(0));
			}
			oraReader.Close();
			conn.Close();
		}
	}
}

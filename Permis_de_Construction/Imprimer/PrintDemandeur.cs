using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Permis_de_Construction.Imprimer
{
    public partial class PrintDemandeur : Form
    {
        public PrintDemandeur()
        {
            InitializeComponent();
        }

        Imprimer.Demandeur demandeur = new Demandeur();
        private void PrintDemandeur_Load(object sender, EventArgs e)
        {
            SqlConnection connextion = new SqlConnection();
            connextion.ConnectionString = ConfigurationManager.ConnectionStrings["Permis_de_Construction.Properties.Settings.ConstructionConnectionString"].ToString();

            string query = "select * from demandeur";
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connextion);
            adapter.Fill(ds, "Demandeur");
            DataTable dt = ds.Tables["Demandeur"];
            demandeur.SetDataSource(ds.Tables["Demandeur"]);
            crystalReportViewer1.ReportSource = demandeur;
            crystalReportViewer1.Refresh();
        }
    }
}

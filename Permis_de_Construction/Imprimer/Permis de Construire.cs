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
    public partial class Permis_de_Construire : Form
    {
        string Designation;
        public Permis_de_Construire()
        {
            InitializeComponent();
            //this.Designation = Des;
        }


        Class.Reponse reponse = new Class.Reponse();
        Imprimer.CrystalReportPermis permis = new CrystalReportPermis();
        private void Permis_de_Construire_Load(object sender, EventArgs e)
        {
            ComboBoxRetrait.DataSource = reponse.VuePermis();
            ComboBoxRetrait.DisplayMember = "T_Reponse";
            ComboBoxRetrait.SelectedItem = null;

            //SqlConnection connextion = new SqlConnection();
            //connextion.ConnectionString = ConfigurationManager.ConnectionStrings["Permis_de_Construction.Properties.Settings.ConstructionConnectionString"].ToString();

            //string query = "select * from Permis_de_Construire where T_Reponse like '%" + ComboBoxRetrait.Text.ToString() + "%'";
            //DataSet ds = new DataSet();
            //SqlDataAdapter adapter = new SqlDataAdapter(query, connextion);
            //adapter.Fill(ds, "Permis_de_Construire");
            //DataTable dt = ds.Tables["Permis_de_Construire"];
            //permis.SetDataSource(ds.Tables["Permis_de_Construire"]);
            //crystalReportViewer1.ReportSource = permis;
            //crystalReportViewer1.Refresh();
        }

        private void ComboBoxRetrait_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connextion = new SqlConnection();
            connextion.ConnectionString = ConfigurationManager.ConnectionStrings["Permis_de_Construction.Properties.Settings.ConstructionConnectionString"].ToString();

            string query = "select * from Permis_de_Construire where T_Reponse like '%" + ComboBoxRetrait.Text.ToString() + "%'";
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connextion);
            adapter.Fill(ds, "Permis_de_Construire");
            DataTable dt = ds.Tables["Permis_de_Construire"];
            permis.SetDataSource(ds.Tables["Permis_de_Construire"]);
            crystalReportViewer1.ReportSource = permis;
            crystalReportViewer1.Refresh();
        }
    }
}

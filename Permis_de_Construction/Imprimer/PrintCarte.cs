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
    public partial class PrintCarte : Form
    {
        string Designation;
        public PrintCarte(string Des)
        {
            InitializeComponent();
            this.Designation = Des;
        }


        private void gunaPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        Class.Controleur controleur = new Class.Controleur();
        Imprimer.Carte carte = new Carte();
        private void PrintCarte_Load(object sender, EventArgs e)
        {
            ComboBoxNom.DataSource = controleur.Controle();
            ComboBoxNom.DisplayMember = "Nom";
            ComboBoxNom.ValueMember = "Id";
            ComboBoxNom.Text = Designation;

            SqlConnection connextion = new SqlConnection();
            connextion.ConnectionString = ConfigurationManager.ConnectionStrings["Permis_de_Construction.Properties.Settings.ConstructionConnectionString"].ToString();

            string query = "Select * from controleur where concat(Nom, ' ', Postnom) like '%" + ComboBoxNom.Text.ToString() + "%'";
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connextion);
            adapter.Fill(ds, "CarteAgent");
            DataTable dt = ds.Tables["CarteAgent"];
            carte.SetDataSource(ds.Tables["CarteAgent"]);
            crystalReportViewer1.ReportSource = carte;
            crystalReportViewer1.Refresh();
        }

        private void ComboBoxNom_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connextion = new SqlConnection();
            connextion.ConnectionString = ConfigurationManager.ConnectionStrings["Permis_de_Construction.Properties.Settings.ConstructionConnectionString"].ToString();

            string query = "Select * from controleur where concat(Nom, ' ', Postnom) like '%" + ComboBoxNom.Text.ToString() + "%'";
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connextion);
            adapter.Fill(ds, "CarteAgent");
            DataTable dt = ds.Tables["CarteAgent"];
            carte.SetDataSource(ds.Tables["CarteAgent"]);
            crystalReportViewer1.ReportSource = carte;
            crystalReportViewer1.Refresh();
        }
    }
}

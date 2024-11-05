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
    public partial class PrintDemandes : Form
    {
        public PrintDemandes()
        {
            InitializeComponent();
        }

        Imprimer.Dem demande = new Dem();
        private void PrintDemandes_Load(object sender, EventArgs e)
        {
            SqlConnection connextion = new SqlConnection();
            connextion.ConnectionString = ConfigurationManager.ConnectionStrings["Permis_de_Construction.Properties.Settings.ConstructionConnectionString"].ToString();

            string query = "select Demande.Id, Demande.Designation as Motif , CONCAT( Demandeur.Nom, ' ', Demandeur.Postnom) as Demandeur, convert(varchar(25),Demande.Datedemande, 103) as Date_Demande, Terrain.Designation as Terrain from Demande inner join Demandeur on Demandeur.Id= Demande.Demandeur inner join Terrain on Terrain.Id =Demande.Terrain";
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connextion);
            adapter.Fill(ds, "ListDemandes");
            DataTable dt = ds.Tables["ListDemandes"];
            demande.SetDataSource(ds.Tables["ListDemandes"]);
            crystalReportViewer1.ReportSource = demande;
            crystalReportViewer1.Refresh();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            SqlConnection connextion = new SqlConnection();
            connextion.ConnectionString = ConfigurationManager.ConnectionStrings["Permis_de_Construction.Properties.Settings.ConstructionConnectionString"].ToString();

            string query = "select Demande.Id, Demande.Designation as Motif , CONCAT( Demandeur.Nom, ' ', Demandeur.Postnom) as Demandeur, convert(varchar(25),Demande.Datedemande, 103) as Date_Demande, Terrain.Designation as Terrain from Demande inner join Demandeur on Demandeur.Id= Demande.Demandeur inner join Terrain on Terrain.Id =Demande.Terrain where  convert(varchar(25),Demande.Datedemande, 103) between '" + DateTimePickerdudate.Value.ToString("dd-MM-yyyy") + "' and  '" + DateTimeAudate.Value.ToString("dd-MM-yyyy") + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connextion);
            adapter.Fill(ds, "ListDemandes");
            DataTable dt = ds.Tables["ListDemandes"];
            demande.SetDataSource(ds.Tables["ListDemandes"]);
            crystalReportViewer1.ReportSource = demande;
            crystalReportViewer1.Refresh();
        }
    }
}

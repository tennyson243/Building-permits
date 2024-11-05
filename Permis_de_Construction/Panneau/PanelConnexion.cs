using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Permis_de_Construction.Panneau
{
    public partial class PanelConnexion : Form
    {
        private Panneau.PanneauPrincipal dp = null;
        public PanelConnexion()
        {
            InitializeComponent();
        }

        public PanelConnexion(Panneau.PanneauPrincipal sourceform)
        {
            
            dp = sourceform as Panneau.PanneauPrincipal;
            InitializeComponent();

        }
        private void ButtonConnexion_Click(object sender, EventArgs e)
        {
            Base_de_donnee.Connexion connexion = new Base_de_donnee.Connexion();



            string nomutilisateur = TextBoxNomUtilisateur.Text;
            string motdepasse = TextBoxMotdepasse.Text;

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("Select*from Utilisateur where nomutilisateur = @nom_utilisateur and motdepasse = @Mot_de_Passe", connexion.GetConnection());

            cmd.Parameters.Add("@Nom_Utilisateur", SqlDbType.VarChar).Value = nomutilisateur;
            cmd.Parameters.Add("@Mot_de_Passe", SqlDbType.VarChar).Value = motdepasse;

            adapter.SelectCommand = cmd;
            adapter.Fill(table);


            if (table.Rows.Count > 0)
            {
                dp.Enabled = true;
                this.Close();
            }
            else
            {
                if (nomutilisateur.Trim().Equals(""))
                {
                    MessageBox.Show("Mettez votre nom d'utlisateur pour vous conncter", "Nom d'utilisateur vide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else if (motdepasse.Trim().Equals(""))
                {
                    MessageBox.Show("Mettez votre mot de passe pour vous conncter", "Mot de passe vide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    MessageBox.Show("Le nom d'utilisateur ou le mot de passe est incorrect", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

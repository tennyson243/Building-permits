using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Permis_de_Construction.Panneau
{
    public partial class PanneauPrincipal : Form
    {
        public PanneauPrincipal()
        {
            InitializeComponent();
        }

        Class.Demandeur demandeur = new Class.Demandeur();
        Class.Demande demande = new Class.Demande();
        Class.Terrain terrain = new Class.Terrain();
        private void PanneauPrincipal_Load(object sender, EventArgs e)
        {
           

        }

        private void buttonDemandeur_Click(object sender, EventArgs e)
        {
            GererDemandeur gd = new GererDemandeur();
            gd.Show();
        }

        private void buttonDemande_Click(object sender, EventArgs e)
        {
            Panneau.GererCommune gerer = new GererCommune();
            gerer.Show();
        }

        private void buttonTerrain_Click(object sender, EventArgs e)
        {
            GererTerrain gererTerrain = new GererTerrain();
            gererTerrain.Show();
        }

        private void buttonAgent_Click(object sender, EventArgs e)
        {
            Panneau.GererControleur controleur = new GererControleur();
            controleur.Show();
        }

        private void buttonIngenieur_Click(object sender, EventArgs e)
        {
            GererIngenieur gerer = new GererIngenieur();
            gerer.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Panneau.GererDemdande demdande = new GererDemdande();
            demdande.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Imprimer.Permis_de_Construire permis = new Imprimer.Permis_de_Construire();
            permis.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Panneau.GererUtilisateur utilisateur = new GererUtilisateur();
            utilisateur.Show();
        }

        private void PanneauPrincipal_Shown(object sender, EventArgs e)
        {
            this.Enabled = false;
            Panneau.PanelConnexion pn = new PanelConnexion(this);
            pn.Show();

            labeldemandes.Text = demande.list().Rows.Count.ToString();
            labeldemandeur.Text = demandeur.listDemandeur().Rows.Count.ToString();
            labelterrain.Text = terrain.listTerrainJointure().Rows.Count.ToString();

        }
    }
}
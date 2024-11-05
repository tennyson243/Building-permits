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
    public partial class GererTerrain : Form
    {

        Class.Terrain terrain = new Class.Terrain();
        Class.Demandeur demandeur = new Class.Demandeur();
        Class.Autorite agent = new Class.Autorite();
        Class.Avenue avenue = new Class.Avenue();
        Class.Controleur controleur = new Class.Controleur();
        Class.Ingenieur ingenieur = new Class.Ingenieur();
        public GererTerrain()
        {
            InitializeComponent();
        }

        private void buttonajouter_Click(object sender, EventArgs e)
        {
           
        }

        private void DataGridViewterrain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxid.Text = DataGridViewTerrain.CurrentRow.Cells[0].Value.ToString();
            textBoxLongeur.Text = DataGridViewTerrain.CurrentRow.Cells[1].Value.ToString();
            comboBoxDemandeur.SelectedValue = DataGridViewTerrain.CurrentRow.Cells[2].Value.ToString();
            comboBoxagent.SelectedValue = DataGridViewTerrain.CurrentRow.Cells[3].Value.ToString();

        }

        private void buttonmodifier_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonsupprimer_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    int id = Convert.ToInt32(textBoxid.Text);

            //    {

            //        if (MessageBox.Show("Vouslez-Vous Vraiment Supprimer ce terrain?", "Suppression terrain", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //        {
            //            if (terrain.SupprimerTerrain(id))
            //            {
            //                MessageBox.Show("Terrain Supprimer", "Suppression Terrain", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                DataGridViewTerrain.DataSource = terrain.listTerrain();
            //            }
            //            else
            //            {
            //                MessageBox.Show("Echec de Suppression", "Suppresion Terrain", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //        }

            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }

        private void GererTerrain_Load(object sender, EventArgs e)
        {
            actualiser();
            comboBoxagent.DataSource = agent.listAgent();
            comboBoxagent.DisplayMember = "Nom";
            comboBoxagent.ValueMember = "id";
            comboBoxagent.SelectedItem = null;

            comboBoxDemandeur.DataSource = demandeur.listDemandeur();
            comboBoxDemandeur.DisplayMember = "Nom";
            comboBoxDemandeur.ValueMember = "id";
            comboBoxDemandeur.SelectedItem = null;

            comboBoxControleur.DataSource = controleur.listcontroleur();
            comboBoxControleur.DisplayMember = "Nom";
            comboBoxControleur.ValueMember = "id";
            comboBoxControleur.SelectedItem = null;

            comboBoxAvenue.DataSource = avenue.listAvenue();
            comboBoxAvenue.DisplayMember = "Avenue";
            comboBoxAvenue.ValueMember = "id";
            comboBoxAvenue.SelectedItem = null;

            comboBoxIngenieur.DataSource = ingenieur.listingenieur();
            comboBoxIngenieur.DisplayMember = "Nom";
            comboBoxIngenieur.ValueMember = "id";
            comboBoxIngenieur.SelectedItem = null;
            initialise();
            DataGridViewTerrain.DataSource = terrain.listTerrainJointure();




        }

        private void buttonajouter_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            //try
            //{
                int Longeur = Convert.ToInt32(textBoxLongeur.Text);
                int Largeur = Convert.ToInt32(textBoxLargeur.Text);
                string Designation = LabelDesignation.Text;
                int demandeur = Convert.ToInt32(comboBoxDemandeur.SelectedValue);
                int agent = Convert.ToInt32(comboBoxagent.SelectedValue);
                int Avenue = Convert.ToInt32(comboBoxAvenue.SelectedValue);
                int Controleur = Convert.ToInt32(comboBoxControleur.SelectedValue);
                int Ingenieur = Convert.ToInt32(comboBoxIngenieur.SelectedValue);

                if (terrain.AjouterTerrain(Designation, Longeur, Largeur, demandeur, agent, Avenue, Controleur,Ingenieur))
                {
                    MessageBox.Show("Terrain Ajouter", "Ajout Terrain", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataGridViewTerrain.DataSource = terrain.listTerrainJointure();
                    actualiser();
                    initialise();

                }
                else
                {
                    MessageBox.Show("Echec d'ajout", "Ajout Ingenieur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            //}
            ////catch (Exception ex)
            //{
            //    MessageBox.Show("La Superficie ne doit pas etre vide", "Superficie", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //}
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxid.Text);
                int Longeur = Convert.ToInt32(textBoxLongeur.Text);
                int Largeur = Convert.ToInt32(textBoxLargeur.Text);
                string Designation = LabelDesignation.Text;
                int demandeur = Convert.ToInt32(comboBoxDemandeur.SelectedValue);
                int agent = Convert.ToInt32(comboBoxagent.SelectedValue);
                int Avenue = Convert.ToInt32(comboBoxAvenue.SelectedValue);
                int Controleur = Convert.ToInt32(comboBoxControleur.SelectedValue);
                int Ingenieur = Convert.ToInt32(comboBoxIngenieur.SelectedValue);

                if (terrain.ModifierTerrain(id, Designation, Longeur, Largeur, demandeur, agent, Avenue, Controleur, Ingenieur))
                {
                    MessageBox.Show("Terrain Modifier", "Modification Terrain", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataGridViewTerrain.DataSource = terrain.listTerrainJointure();
                    actualiser();
                    initialise();

                }
                else
                {
                    MessageBox.Show("Echec de modification", "Modification Ingenieur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void initialise()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Construction.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 Designation  FROM Terrain order by id DESC", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet table = new DataSet();
            adapter.Fill(table);

            if (table.Tables[0].Rows.Count > 0)
            {
                string tmp = table.Tables[0].Rows[0]["Designation"].ToString().Substring(8, 3);
                int new_id = Convert.ToInt32(tmp) + 1;
                LabelDesignation.Text = "TERRAIN-" + new_id.ToString("000");

            }
            else
            {
                LabelDesignation.Text = "TERRAIN-001";
            }
        }

        private void DataGridViewTerrain_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(DataGridViewTerrain.CurrentRow.Cells[0].Value);

            DataTable table = terrain.listTerrain(id);

            if(table.Rows.Count>0)
            {
                textBoxid.Text = table.Rows[0][0].ToString();
                LabelDesignation.Text = table.Rows[0][1].ToString();
                textBoxLongeur.Text = table.Rows[0][2].ToString();
                textBoxLargeur.Text = table.Rows[0][3].ToString();
                comboBoxDemandeur.SelectedValue = table.Rows[0][4].ToString();
                comboBoxagent.SelectedValue = table.Rows[0][5].ToString();
                comboBoxAvenue.SelectedValue = table.Rows[0][6].ToString();
                comboBoxControleur.SelectedValue = table.Rows[0][7].ToString();
                comboBoxIngenieur.SelectedValue = table.Rows[0][8].ToString();
            }
        }

        public void actualiser()
        {
            textBoxid.Text = "";
            textBoxLongeur.Text = "";
            textBoxLargeur.Text = "";
            comboBoxDemandeur.SelectedItem = null;
            comboBoxagent.SelectedItem = null;
            comboBoxAvenue.SelectedItem = null;
            comboBoxControleur.SelectedItem = null;
            comboBoxIngenieur.SelectedItem = null;


      
        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {

            try
            {
                int id = Convert.ToInt32(textBoxid.Text);

                {

                    if (MessageBox.Show("Vouslez-Vous Vraiment Supprimer ce terrain?", "Suppression terrain", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (terrain.SupprimerTerrain(id))
                        {
                            MessageBox.Show("Terrain Supprimer", "Suppression Terrain", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DataGridViewTerrain.DataSource = terrain.listTerrainJointure();
                            actualiser();
                            initialise();
                        }
                        else
                        {
                            MessageBox.Show("Echec de Suppression", "Suppresion Terrain", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            actualiser();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
   }


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
    public partial class GererCommune : Form
    {
        public GererCommune()
        {
            InitializeComponent();
        }

        Class.Avenue avenue = new Class.Avenue();
        Class.Quartier quartier = new Class.Quartier();
        Class.Commune commune = new Class.Commune();
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            string Designation = textBoxDesignationAvenue.Text;
            int Quartier = Convert.ToInt32(comboBoxQuartierAvenue.SelectedValue);

            if (textBoxDesignationAvenue.Text.Trim().Equals(""))
            {
                MessageBox.Show("La Designation ne peux pas etre vide ", "Ajout Designation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(comboBoxQuartierAvenue.SelectedValue==null)
            {
                MessageBox.Show("Veiller Choisir un Quartier , le Quartier ne peux pas etre vide ", "Ajout Designation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if(avenue.AjouterAvenue(Designation, Quartier))
                {
                    MessageBox.Show("Avenue Ajouter", "Ajout Avenue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataGridViewAvenues.DataSource = avenue.listAvenue();
                    Actualiser1();
                }
                else
                {
                    MessageBox.Show("Echec d'ajout", "Ajout Avenue", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxid.Text);
                string Designation = textBoxDesignationAvenue.Text;
                int Quartier = Convert.ToInt32(comboBoxQuartierAvenue.SelectedValue);

                if (textBoxDesignationAvenue.Text.Trim().Equals(""))
                {
                    MessageBox.Show("La Designation ne peux pas etre vide ", "Ajout Designation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (comboBoxQuartierAvenue.SelectedValue == null)
                {
                    MessageBox.Show("Veiller Choisir un Quartier , le Quartier ne peux pas etre vide ", "Ajout Designation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (avenue.ModifierAvenue(id, Designation, Quartier))
                    {
                        MessageBox.Show("Avenue Modifier", "Modification Avenue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataGridViewAvenues.DataSource = avenue.listAvenue();
                        Actualiser1();
                    }
                    else
                    {
                        MessageBox.Show("Echec de Modification", "Modification Avenue", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxid.Text);

                {
                    if (avenue.SupprimerAvenue(id))
                    {
                        MessageBox.Show("Avenue Supprimer", "Suppression Avenue", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataGridViewAvenues.DataSource = avenue.listAvenue();
                        Actualiser1();
                    }
                    else
                    {
                        MessageBox.Show("Echec de Suppression", "Suppresion Avenue", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PanelAvenue_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            string Designation = textBoxDesignationQuartier.Text;
            int Quartier = Convert.ToInt32(comboBoxCommuneQuartier.SelectedValue) ;

            if (textBoxDesignationQuartier.Text.Trim().Equals(""))
            {
                MessageBox.Show("La Designation ne peux pas etre vide ", "Ajout Designation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (comboBoxCommuneQuartier.SelectedValue == null)
            {
                MessageBox.Show("Veiller Choisir un Quartier , le Quartier ne peux pas etre vide ", "Ajout Designation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (quartier.AjouterQuartier(Designation, Quartier))
                {
                    MessageBox.Show("Quartier Ajouter", "Ajout Quartier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataGridViewQuartier.DataSource = quartier.listQuartier();
                    Actualiser1();
                }
                else
                {
                    MessageBox.Show("Echec d'ajout", "Ajout Quartier", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxidQuartier.Text);
                string Designation = textBoxDesignationQuartier.Text;
                int Quartier = Convert.ToInt32(comboBoxCommuneQuartier.SelectedValue);

                if (textBoxDesignationQuartier.Text.Trim().Equals(""))
                {
                    MessageBox.Show("La Designation ne peux pas etre vide ", "Ajout Designation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (comboBoxCommuneQuartier.SelectedValue == null)
                {
                    MessageBox.Show("Veiller Choisir un Quartier , le Quartier ne peux pas etre vide ", "Ajout Designation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (quartier.ModifierQuartier(id, Designation, Quartier))
                    {
                        MessageBox.Show("Quartier Modifier", "Modification Quartier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataGridViewQuartier.DataSource = quartier.listQuartier();
                        Actualiser1();
                    }
                    else
                    {
                        MessageBox.Show("Echec de Modification", "Modification Quartier", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxidQuartier.Text);

                {
                    if (quartier.SupprimerAvenue(id))
                    {
                        MessageBox.Show("Quartier Supprimer", "Suppression Quartier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataGridViewQuartier.DataSource = quartier.listQuartier();
                        Actualiser1();
                    }
                    else
                    {
                        MessageBox.Show("Echec de Suppression", "Suppresion Quartier", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            string Designation = textBoxDesignationCommune.Text;
            

            if (textBoxDesignationCommune.Text.Trim().Equals(""))
            {
                MessageBox.Show("La Designation ne peux pas etre vide ", "Ajout Designation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (commune.AjouterCommune (Designation))
                {
                    MessageBox.Show("Commune Ajouter", "Ajout Commune", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataGridViewCommune.DataSource = commune.listCommune();
                    Actualiser1();
                }
                else
                {
                    MessageBox.Show("Echec d'ajout", "Ajout Commune", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxidCommune.Text);
                string Designation = textBoxDesignationCommune.Text;
               

                if (textBoxDesignationCommune.Text.Trim().Equals(""))
                {
                    MessageBox.Show("La Designation ne peux pas etre vide ", "Ajout Designation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (commune.ModifierAvenue(id, Designation))
                    {
                        MessageBox.Show("Commune Modifier", "Modification Commune", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataGridViewCommune.DataSource = commune.listCommune();
                        Actualiser1();
                    }
                    else
                    {
                        MessageBox.Show("Echec de Modification", "Modification Commune", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxidCommune.Text);

                {
                    if (commune.SupprimerCommune(id))
                    {
                        MessageBox.Show("Commune Supprimer", "Suppression Commune", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataGridViewCommune.DataSource = commune.listCommune();
                        Actualiser1();
                    }
                    else
                    {
                        MessageBox.Show("Echec de Suppression", "Suppresion Commune", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            PanelCommune.BringToFront();
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            PanelAvenue.BringToFront();
        }

        private void bunifuTileButton3_Click(object sender, EventArgs e)
        {
            PanelQuartier.BringToFront();
        }

        private void GererCommune_Load(object sender, EventArgs e)
        {
            Actualiser1();

            comboBoxCommuneQuartier.DataSource = commune.listCommune();
            comboBoxCommuneQuartier.DisplayMember = "Designation";
            comboBoxCommuneQuartier.ValueMember = "Id";
            comboBoxCommuneQuartier.SelectedItem = null;

            comboBoxQuartierAvenue.DataSource = quartier.listQuartier();
            comboBoxQuartierAvenue.DisplayMember = "Quartier";
            comboBoxQuartierAvenue.ValueMember = "Id";
            comboBoxQuartierAvenue.SelectedItem = null;
        }

        private void DataGridViewCommune_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxidCommune.Text = DataGridViewCommune.CurrentRow.Cells[0].Value.ToString();
            textBoxDesignationCommune.Text = DataGridViewCommune.CurrentRow.Cells[1].Value.ToString();
        }


        public void actualiser ()
        {
          

        }

        private void DataGridViewQuartier_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int id = Convert.ToInt32(DataGridViewQuartier.CurrentRow.Cells[0].Value);

            DataTable table = quartier.GetQuartier(id);

            if (table.Rows.Count > 0)
            {
                textBoxidQuartier.Text = table.Rows[0][0].ToString();
                textBoxDesignationQuartier.Text = table.Rows[0][1].ToString();
                comboBoxCommuneQuartier.SelectedValue = table.Rows[0][2];

            }
          
        }

        public void Actualiser1()
        {
            textBoxidQuartier.Text = "";
            textBoxDesignationQuartier.Text = "";
            comboBoxCommuneQuartier.SelectedItem = null;
            textBoxid.Text = "";
            textBoxDesignationAvenue.Text = "";
            comboBoxQuartierAvenue.SelectedItem = null;
            textBoxidCommune.Text = "";
            textBoxDesignationCommune.Text = "";

            DataGridViewCommune.DataSource = commune.listCommune();
            DataGridViewAvenues.DataSource = avenue.listAvenue();
            DataGridViewQuartier.DataSource = quartier.listQuartier();
         
            DataGridViewColumn dgic = new DataGridViewColumn();
            dgic = (DataGridViewColumn)DataGridViewAvenues.Columns[0];
            dgic.Visible = false;

      
            DataGridViewColumn dgi = new DataGridViewColumn();
            dgi = (DataGridViewColumn)DataGridViewCommune.Columns[0];
            dgi.Visible = false;

          
            DataGridViewColumn dg = new DataGridViewColumn();
            dg = (DataGridViewColumn)DataGridViewQuartier.Columns[0];
            dg.Visible = false;
        }

        private void DataGridViewAvenues_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(DataGridViewAvenues.CurrentRow.Cells[0].Value);

            DataTable table = avenue.GetAvenue(id);

            if (table.Rows.Count > 0)
            {
                textBoxid.Text = table.Rows[0][0].ToString();
                textBoxDesignationAvenue.Text = table.Rows[0][1].ToString();
                comboBoxQuartierAvenue.SelectedValue = table.Rows[0][2];
             
            }
           
        }
    }
}

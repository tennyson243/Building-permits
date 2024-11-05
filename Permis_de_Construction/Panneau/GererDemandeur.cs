using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Permis_de_Construction.Panneau
{
    public partial class GererDemandeur : Form
    {
        Class.Demandeur demandeur = new Class.Demandeur();
        public GererDemandeur()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonparcourir_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd .Filter = "Choisissez une photo (*.jpg; *.png; *.gif)| *.jpg; *.png; *.gif";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBoxdemandeur.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void buttonajouter_Click(object sender, EventArgs e)
        {
           

        }

        private void buttonparcourir_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Choisissez une photo (*.jpg; *.png; *.gif)| *.jpg; *.png; *.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBoxdemandeur.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void GererDemandeur_Load(object sender, EventArgs e)
        {

            dataGridViewdemandeur.RowTemplate.Height = 80;
            dataGridViewdemandeur.DataSource = demandeur.listDemandeur();
            DataGridViewImageColumn dgic = new DataGridViewImageColumn();
            dgic = (DataGridViewImageColumn)dataGridViewdemandeur.Columns[5];
            dgic.ImageLayout = DataGridViewImageCellLayout.Stretch;

            DataGridViewColumn dgi = new DataGridViewColumn();
            dgi = (DataGridViewColumn)dataGridViewdemandeur.Columns[0];
            dgi.Visible = false;
            //dataGridViewdemandeur.ColumnHeadersDefaultCellStyle.ForeColor = Color.Chocolate;
            //dataGridViewdemandeur.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 8, FontStyle.Bold);
            //dataGridViewdemandeur.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridViewdemandeur.EnableHeadersVisualStyles = false;

        }

        private void buttonmodifier_Click(object sender, EventArgs e)
        {
           

        }

        private void dataGridViewdemandeur_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          



        }

        private void buttonsupprimer_Click(object sender, EventArgs e)
        {
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string nm = textBoxnom.Text;
            string pst = textBoxpostnom.Text;
            string adr = textBoxadresse.Text;
            string phn = textBoxphone.Text;

            MemoryStream ms = new MemoryStream();
            pictureBoxdemandeur.Image.Save(ms, pictureBoxdemandeur.Image.RawFormat);
            byte[] image = ms.ToArray();

            if (textBoxnom.Text.Trim().Equals(""))
            {
                MessageBox.Show("Le nom ne peux pas etre vide ", "Ajout Demandeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBoxpostnom.Text.Trim().Equals(""))
            {
                MessageBox.Show("Le Postnom ne peux pas etre vide ", "Ajout Demandeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBoxadresse.Text.Trim().Equals(""))
            {
                MessageBox.Show("L'Adresse ne peux pas etre vide ", "Ajout Demandeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBoxphone.Text.Trim().Equals(""))
            {
                MessageBox.Show("Le numero de telephone  ne peux pas etre vide ", "Ajout Demandeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (demandeur.Ajouterdemandeur(nm, pst, adr, phn, image))
                {
                    MessageBox.Show("Demandeur Ajouter", "Ajout Demandeur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewdemandeur.DataSource = demandeur.listDemandeur();
                    act();
                }
                else
                {
                    MessageBox.Show("Echec d'ajout", "Ajout Demandeur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxid.Text);
                string nm = textBoxnom.Text;
                string pst = textBoxpostnom.Text;
                string adr = textBoxadresse.Text;
                string phn = textBoxphone.Text;

                MemoryStream ms = new MemoryStream();
                pictureBoxdemandeur.Image.Save(ms, pictureBoxdemandeur.Image.RawFormat);
                byte[] image = ms.ToArray();

                if (textBoxnom.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Le nom ne peux pas etre vide ", "Ajout Demandeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBoxpostnom.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Le Postnom ne peux pas etre vide ", "Ajout Demandeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBoxadresse.Text.Trim().Equals(""))
                {
                    MessageBox.Show("L'Adresse ne peux pas etre vide ", "Ajout Demandeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBoxphone.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Le numero de telephone  ne peux pas etre vide ", "Ajout Demandeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (demandeur.Modifierdemandeur(id, nm, pst, adr, phn, image))
                    {
                        MessageBox.Show("Demandeur Modifier", "Modification Demandeur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridViewdemandeur.DataSource = demandeur.listDemandeur();
                        act();
                    }
                    else
                    {
                        MessageBox.Show("Echec de Modification", "Modification Demandeur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

            try
            {
                int id = Convert.ToInt32(textBoxid.Text);

                {
                    if (demandeur.Supprimerdemandeur(id))
                    {
                        MessageBox.Show("Demandeur Supprimer", "Suppression Demandeur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridViewdemandeur.DataSource = demandeur.listDemandeur();
                        act();
                    }
                    else
                    {
                        MessageBox.Show("Echec de Modification", "Suppresion Demandeur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridViewdemandeur_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        public void act()
        {
            textBoxid.Text = "";
            textBoxnom.Text = "";
            textBoxpostnom.Text = "";
            textBoxadresse.Text = "";
            textBoxphone.Text = "";
        }

        private void TextBoxRecherche_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Construction.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand("select * from demandeur where CONCAT(Nom,PostNom,Adresse,Telephone) like '%" + TextBoxRecherche.Text + "%'", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            dataGridViewdemandeur.DataSource = table;
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Imprimer.PrintDemandeur demandeur = new Imprimer.PrintDemandeur();
            demandeur.Show();
        }

        private void dataGridViewdemandeur_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBoxid.Text = dataGridViewdemandeur.CurrentRow.Cells[0].Value.ToString();
                textBoxnom.Text = dataGridViewdemandeur.CurrentRow.Cells[1].Value.ToString();
                textBoxpostnom.Text = dataGridViewdemandeur.CurrentRow.Cells[2].Value.ToString();
                textBoxadresse.Text = dataGridViewdemandeur.CurrentRow.Cells[3].Value.ToString();
                textBoxphone.Text = dataGridViewdemandeur.CurrentRow.Cells[4].Value.ToString();

                byte[] demandeur = (byte[])dataGridViewdemandeur.CurrentRow.Cells[5].Value;
                MemoryStream ms = new MemoryStream(demandeur);
                byte[] image = ms.ToArray();
                pictureBoxdemandeur.Image = Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

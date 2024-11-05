using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Permis_de_Construction.Panneau
{
    public partial class GererAgent : Form
    {
        Class.Autorite agent = new Class.Autorite();
        public GererAgent()
        {
            InitializeComponent();
        }

        private void buttonajouter_Click(object sender, EventArgs e)
        {
            string nm = textBoxnom.Text;
            string sexe = comboBoxSexe.Text;
            string pst = textBoxpostnom.Text;
            string adr = textBoxadresse.Text;
            string phn = textBoxphone.Text;
            string matricule = textBoxmatricule.Text;
            string fonction = textBoxfonction.Text;

            MemoryStream ms = new MemoryStream();
            pictureBoxAgent.Image.Save(ms, pictureBoxAgent.Image.RawFormat);
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
                if (agent.AjouterAgent(nm, pst, sexe , adr ,fonction ,matricule , phn, image))
                {
                    MessageBox.Show("Agent Ajouter", "Ajout Agent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataGridViewAgent .DataSource = agent .listAgent ();
                }
                else
                {
                    MessageBox.Show("Echec d'ajout", "Ajout Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void DataGridViewAgent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxid.Text = DataGridViewAgent.CurrentRow.Cells[0].Value.ToString();
           textBoxnom.Text = DataGridViewAgent.CurrentRow.Cells[1].Value.ToString();
            textBoxpostnom.Text = DataGridViewAgent.CurrentRow.Cells[2].Value.ToString();
            comboBoxSexe.SelectedItem = DataGridViewAgent.CurrentRow.Cells[3].Value.ToString();

            textBoxadresse.Text = DataGridViewAgent.CurrentRow.Cells[4].Value.ToString();
            textBoxfonction.Text = DataGridViewAgent.CurrentRow.Cells[5].Value.ToString();
            textBoxmatricule.Text = DataGridViewAgent.CurrentRow.Cells[6].Value.ToString();
            textBoxphone.Text = DataGridViewAgent.CurrentRow.Cells[7].Value.ToString();

            byte[] Agent = (byte[])DataGridViewAgent.CurrentRow.Cells[8].Value;
            MemoryStream ms = new MemoryStream(Agent);
            byte[] image = ms.ToArray();
            pictureBoxAgent.Image = Image.FromStream(ms);
        }

        private void buttonmodifier_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxid.Text);
                string nm = textBoxnom.Text;
                string sexe = comboBoxSexe.Text;
                string pst = textBoxpostnom.Text;
                string adr = textBoxadresse.Text;
                string phn = textBoxphone.Text;
                string matricule = textBoxmatricule.Text;
                string fonction = textBoxfonction.Text;

                MemoryStream ms = new MemoryStream();
                pictureBoxAgent.Image.Save(ms, pictureBoxAgent.Image.RawFormat);
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
                    if (agent.ModifierAgent(id,nm, pst, sexe, adr, fonction, matricule, phn, image))
                    {
                        MessageBox.Show("Agent Modifier", "Modification Agent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataGridViewAgent.DataSource = agent.listAgent();
                    }
                    else
                    {
                        MessageBox.Show("Echec de Modification", "Modification Agent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonsupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxid.Text);

                {
                    if (agent.SupprimerAgent(id))
                    {
                        MessageBox.Show("Agent Supprimer", "Suppression Agent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataGridViewAgent.DataSource = agent.listAgent();
                    }
                    else
                    {
                        MessageBox.Show("Echec de Suppression", "Suppresion Demandeur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void GererAgent_Load(object sender, EventArgs e)
        {
            DataGridViewAgent.RowTemplate.Height = 80;
            DataGridViewAgent.DataSource = agent.listAgent();
            DataGridViewImageColumn dgic = new DataGridViewImageColumn();
            dgic = (DataGridViewImageColumn)DataGridViewAgent.Columns[8];
            dgic.ImageLayout = DataGridViewImageCellLayout.Stretch;

            //DataGridViewAgent.ColumnHeadersDefaultCellStyle.ForeColor = Color.Chocolate;
            //DataGridViewAgent.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 8, FontStyle.Bold);
            //DataGridViewAgent.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //DataGridViewAgent.EnableHeadersVisualStyles = false;
        }

        private void buttonparcourir_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Choisissez une photo (*.jpg; *.png; *.gif)| *.jpg; *.png; *.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBoxAgent.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void buttonImprimer_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(@"F:\Agent"))
            {
                Directory.CreateDirectory(@"F:\Agent");
            }
            String filepath = @"F:\Agent\list.txt";
            if (!File.Exists(filepath))
            {
                File.Create(filepath).Close();
                MessageBox.Show("Fichier Cree");
            }

            //Maintenant nous allons remplir les textes avec les zones libres des textes Box

            TextWriter tx = new StreamWriter(filepath);

            string Nom;
            string Postnom;
            string Sexe;
            string Adresse;
            string Fonction;
            string Matricule;
            string Tel;


            for (int i = 0; i < DataGridViewAgent.Rows.Count; i++) //Boucles pour les lignes
            {
                //for (int j = 0; j < dataGridViewauteurs.Columns.Count; j++)  //Boucle pour compter les colones
                //{
                //    tx.Write(dataGridViewauteurs.Rows[i].Cells[j].Value.ToString());
                //}

                // Nous voullons juste initialiser le nom de l'auteur et son id

                Nom = DataGridViewAgent.Rows[i].Cells[1].Value.ToString();
                Postnom = DataGridViewAgent.Rows[i].Cells[2].Value.ToString();
                Sexe = DataGridViewAgent.Rows[i].Cells[2].Value.ToString();
                Adresse = DataGridViewAgent.Rows[i].Cells[3].Value.ToString();
                Fonction = DataGridViewAgent.Rows[i].Cells[4].Value.ToString();
                Matricule = DataGridViewAgent.Rows[i].Cells[5].Value.ToString();
                Tel = DataGridViewAgent.Rows[i].Cells[6].Value.ToString();


                tx.Write(Nom + "-" + Postnom + "-" + Sexe + "-" + Adresse + "-" + Fonction + "-" + Matricule + "-" + Tel);
                tx.WriteLine(""); // Creation d'une nouvelle lignes
                tx.WriteLine("-----------------------------------");
            }

            tx.Close();
            MessageBox.Show("Donnee Exporter");
        }
    }
}

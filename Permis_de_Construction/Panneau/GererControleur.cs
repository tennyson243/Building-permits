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
    public partial class GererControleur : Form
    {
        public GererControleur()
        {
            InitializeComponent();
        }

        Class.Autorite autorite = new Class.Autorite();
        Class.Controleur controleur = new Class.Controleur();
        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            PanelAutorite.BringToFront();
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            PanelControleurs.BringToFront();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string nm = textBoxNomAutorite.Text;
            string sexe = comboBoxsexeAutorite.Text;
            string pst = textBoxPostnonAutorite.Text;
            string adr = textBoxAdresseAutorite.Text;
            string phn = textBoxPhoneAutorite.Text;
            string matricule = textBoxMatriculeAutorite.Text;
            string fonction = textBoxFonctionAUtorite.Text;

            MemoryStream ms = new MemoryStream();
            pictureBoxAutorite.Image.Save(ms, pictureBoxAutorite.Image.RawFormat);
            byte[] image = ms.ToArray();

            if (textBoxNomAutorite.Text.Trim().Equals(""))
            {
                MessageBox.Show("Le nom ne peux pas etre vide ", "Ajout Autorite", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBoxPostnonAutorite.Text.Trim().Equals(""))
            {
                MessageBox.Show("Le Postnom ne peux pas etre vide ", "Ajout Autorite", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBoxAdresseAutorite.Text.Trim().Equals(""))
            {
                MessageBox.Show("L'Adresse ne peux pas etre vide ", "Ajout Autorite", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBoxPhoneAutorite.Text.Trim().Equals(""))
            {
                MessageBox.Show("Le numero de telephone  ne peux pas etre vide ", "Ajout Autorite", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (autorite.AjouterAgent(nm, pst, sexe, adr, fonction, matricule, phn, image))
                {
                    MessageBox.Show("Autorite Ajouter", "Ajout Autorite", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bunifuDataGridViewAutorite.DataSource = autorite.listAgent();
                    Actualiser();
                }
                else
                {
                    MessageBox.Show("Echec d'ajout", "Ajout Autorite", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxIDautorite.Text);

                string nm = textBoxNomAutorite.Text;
                string sexe = comboBoxsexeAutorite.Text;
                string pst = textBoxPostnonAutorite.Text;
                string adr = textBoxAdresseAutorite.Text;
                string phn = textBoxPhoneAutorite.Text;
                string matricule = textBoxMatriculeAutorite.Text;
                string fonction = textBoxFonctionAUtorite.Text;

                MemoryStream ms = new MemoryStream();
                pictureBoxAutorite.Image.Save(ms, pictureBoxAutorite.Image.RawFormat);
                byte[] image = ms.ToArray();

                if (textBoxNomAutorite.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Le nom ne peux pas etre vide ", "Ajout Autorite", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBoxPostnonAutorite.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Le Postnom ne peux pas etre vide ", "Ajout Autorite", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBoxAdresseAutorite.Text.Trim().Equals(""))
                {
                    MessageBox.Show("L'Adresse ne peux pas etre vide ", "Ajout Autorite", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBoxPhoneAutorite.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Le numero de telephone  ne peux pas etre vide ", "Ajout Autorite", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (autorite.ModifierAgent(id, nm, pst, sexe, adr, fonction, matricule, phn, image))
                    {
                        MessageBox.Show("Autorite Modifier", "Modification Autorite", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bunifuDataGridViewAutorite.DataSource = autorite.listAgent();
                        Actualiser();
                    }
                    else
                    {
                        MessageBox.Show("Echec de Modification", "Modification Autorite", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (autorite.SupprimerAgent(id))
                    {
                        MessageBox.Show("Autorite Supprimer", "Suppression Autorite", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bunifuDataGridViewAutorite.DataSource = autorite.listAgent();
                    }
                    else
                    {
                        MessageBox.Show("Echec de Suppression", "Suppresion Autorite", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
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

            if(textBoxnom.Text.Trim().Equals(""))
            {
                MessageBox.Show("Le nom ne peux pas etre vide ", "Ajout controleur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBoxpostnom.Text.Trim().Equals(""))
            {
                MessageBox.Show("Le Postnom ne peux pas etre vide ", "Ajout controleur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBoxadresse.Text.Trim().Equals(""))
            {
                MessageBox.Show("L'Adresse ne peux pas etre vide ", "Ajout controleur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBoxphone.Text.Trim().Equals(""))
            {
                MessageBox.Show("Le numero de telephone  ne peux pas etre vide ", "Ajout controleur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (controleur.AjouterControleur(nm, pst, sexe, adr, fonction, matricule, phn, image))
                {
                    MessageBox.Show("Agent Ajouter", "Ajout controleur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataGridViewControleur.DataSource = controleur.listcontroleur();
                    Actualiser();
                }
                else
                {
                    MessageBox.Show("Echec d'ajout", "Ajout controleur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
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
                    MessageBox.Show("Le nom ne peux pas etre vide ", "Ajout controleur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBoxpostnom.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Le Postnom ne peux pas etre vide ", "Ajout controleur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBoxadresse.Text.Trim().Equals(""))
                {
                    MessageBox.Show("L'Adresse ne peux pas etre vide ", "Ajout controleur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBoxphone.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Le numero de telephone  ne peux pas etre vide ", "Ajout controleur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (controleur.ModifierControleur(id, nm, pst, sexe, adr, fonction, matricule, phn, image))
                    {
                        MessageBox.Show("Agent Modifier", "Modification controleur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataGridViewControleur.DataSource = controleur.listcontroleur();
                        Actualiser();
                    }
                    else
                    {
                        MessageBox.Show("Echec de Modification", "Modification controleur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Choisissez une photo (*.jpg; *.png; *.gif)| *.jpg; *.png; *.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
               pictureBoxAutorite.Image = Image.FromFile(ofd.FileName);
            }
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

        private void GererControleur_Load(object sender, EventArgs e)
        {
            DataGridViewControleur.RowTemplate.Height = 80;
            bunifuDataGridViewAutorite.RowTemplate.Height = 80;
            DataGridViewControleur.DataSource = controleur.listcontroleur();
            bunifuDataGridViewAutorite.DataSource = autorite.listAgent();

            DataGridViewImageColumn dgic = new DataGridViewImageColumn();
            dgic = (DataGridViewImageColumn)DataGridViewControleur.Columns[8];
            dgic.ImageLayout = DataGridViewImageCellLayout.Stretch;

            DataGridViewImageColumn dgi = new DataGridViewImageColumn();
            dgi = (DataGridViewImageColumn)bunifuDataGridViewAutorite.Columns[8];
            dgi.ImageLayout = DataGridViewImageCellLayout.Stretch;

        }

        private void DataGridViewControleur_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxid.Text = DataGridViewControleur.CurrentRow.Cells[0].Value.ToString();
            textBoxnom.Text = DataGridViewControleur.CurrentRow.Cells[1].Value.ToString();
            textBoxpostnom.Text = DataGridViewControleur.CurrentRow.Cells[2].Value.ToString();
            comboBoxSexe.Text = DataGridViewControleur.CurrentRow.Cells[3].Value.ToString();
            textBoxadresse.Text = DataGridViewControleur.CurrentRow.Cells[4].Value.ToString();
            textBoxfonction.Text = DataGridViewControleur.CurrentRow.Cells[5].Value.ToString();
            textBoxmatricule.Text = DataGridViewControleur.CurrentRow.Cells[6].Value.ToString();
            textBoxphone.Text = DataGridViewControleur.CurrentRow.Cells[7].Value.ToString();

            byte[] Agent = (byte[])DataGridViewControleur.CurrentRow.Cells[8].Value;
            MemoryStream ms = new MemoryStream(Agent);
            byte[] image = ms.ToArray();
            pictureBoxAgent.Image = Image.FromStream(ms);
        }

        public void Actualiser ()
        {
            textBoxid.Text = "";
            textBoxnom.Text = "";
            textBoxpostnom.Text = "";
            comboBoxSexe.SelectedItem = null;
            textBoxadresse.Text = "";
            textBoxfonction.Text = "";
            textBoxmatricule.Text = "";
            textBoxphone.Text = "";
            pictureBoxAgent.ImageLocation = "../../Images/member_50px.png";

            textBoxIDautorite.Text = "";
            textBoxNomAutorite.Text = "";
            textBoxPostnonAutorite.Text = "";
            comboBoxsexeAutorite.SelectedItem = null;
            textBoxAdresseAutorite.Text = "";
            textBoxFonctionAUtorite.Text = "";
            textBoxMatriculeAutorite.Text = "";
            textBoxPhoneAutorite.Text = "";
            pictureBoxAutorite.ImageLocation = "../../Images/member_50px.png";
        }

        private void bunifuDataGridViewAutorite_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxIDautorite.Text = bunifuDataGridViewAutorite.CurrentRow.Cells[0].Value.ToString();
            textBoxNomAutorite.Text = bunifuDataGridViewAutorite.CurrentRow.Cells[1].Value.ToString();
            textBoxPostnonAutorite.Text = bunifuDataGridViewAutorite.CurrentRow.Cells[2].Value.ToString();
            comboBoxsexeAutorite.Text = bunifuDataGridViewAutorite.CurrentRow.Cells[3].Value.ToString();
            textBoxAdresseAutorite.Text = bunifuDataGridViewAutorite.CurrentRow.Cells[4].Value.ToString();
            textBoxFonctionAUtorite.Text = bunifuDataGridViewAutorite.CurrentRow.Cells[5].Value.ToString();
            textBoxMatriculeAutorite.Text = bunifuDataGridViewAutorite.CurrentRow.Cells[6].Value.ToString();
            textBoxPhoneAutorite.Text = bunifuDataGridViewAutorite.CurrentRow.Cells[7].Value.ToString();

            byte[] Agent = (byte[])bunifuDataGridViewAutorite.CurrentRow.Cells[8].Value;
            MemoryStream ms = new MemoryStream(Agent);
            byte[] image = ms.ToArray();
            pictureBoxAutorite.Image = Image.FromStream(ms);

        }

        private void DataGridViewControleur_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(DataGridViewControleur.CurrentRow.Cells[0].Value);
            string nom = DataGridViewControleur.CurrentRow.Cells[1].Value.ToString();
            string postnom = DataGridViewControleur.CurrentRow.Cells[3].Value.ToString();

            string name = nom + ' ' + postnom;

            Imprimer.PrintCarte carte = new Imprimer.PrintCarte(name);
            carte.Show();

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            PanelAutorite.BringToFront();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            PanelControleurs.BringToFront();
        }
    }
}

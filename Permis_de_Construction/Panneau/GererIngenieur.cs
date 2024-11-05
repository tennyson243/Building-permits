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
    public partial class GererIngenieur : Form
    {
        Class.Ingenieur ingenieur = new Class.Ingenieur();
        public GererIngenieur()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonajouter_Click(object sender, EventArgs e)
        {
            string nom = textBoxNom.Text;
            string postnom = textBoxPostnom.Text;
            string adresse = textBoxAdresse.Text;
            string telephone = textBoxTelephone.Text;

            if (nom.Trim().Equals(""))
            {
                MessageBox.Show("Le nom ne peux pas etre vide ", "Ajout ingenieur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (postnom.Trim().Equals(""))
            {
                MessageBox.Show("Le Postnom ne peux pas etre vide ", "Ajout ingenieur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (adresse.Trim().Equals(""))
            {
                MessageBox.Show("L'Adresse ne peux pas etre vide ", "Ajout  ingenieur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (telephone.Trim().Equals(""))
            {
                MessageBox.Show("Le numero de telephone  ne peux pas etre vide ", "Ajout ingenieur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (ingenieur.AjouterIngenieurt(nom, postnom, adresse, telephone))
                {
                    MessageBox.Show("Ingenieur Ajouter", "Ajout Ingenieur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataGridViewingenieur.DataSource = ingenieur.listingenieur();
                    rafrechir();
                }
                else
                {
                    MessageBox.Show("Echec d'ajout", "Ajout Ingenieur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void GererIngenieur_Load(object sender, EventArgs e)
        {
            DataGridViewingenieur.DataSource = ingenieur.listingenieur();
        }

        private void DataGridViewingenieur_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TextboxId.Text = DataGridViewingenieur.CurrentRow.Cells[0].Value.ToString();
            textBoxNom.Text = DataGridViewingenieur.CurrentRow.Cells[1].Value.ToString();
            textBoxPostnom.Text = DataGridViewingenieur.CurrentRow.Cells[2].Value.ToString();
            textBoxAdresse.Text = DataGridViewingenieur.CurrentRow.Cells[3].Value.ToString();
            textBoxTelephone.Text = DataGridViewingenieur.CurrentRow.Cells[4].Value.ToString();

        }

        private void buttonmodifier_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(TextboxId.Text);
                string nom = textBoxNom.Text;
                string postnom = textBoxPostnom.Text;
                string adresse = textBoxAdresse.Text;
                string telephone = textBoxTelephone.Text;

                if (nom.Trim().Equals(""))
                {
                    MessageBox.Show("Le nom ne peux pas etre vide ", "Modifier ingenieur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (postnom.Trim().Equals(""))
                {
                    MessageBox.Show("Le Postnom ne peux pas etre vide ", "Modifier ingenieur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (adresse.Trim().Equals(""))
                {
                    MessageBox.Show("L'Adresse ne peux pas etre vide ", "Modifier ingenieur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (telephone.Trim().Equals(""))
                {
                    MessageBox.Show("Le numero de telephone  ne peux pas etre vide ", "Modifier ingenieur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (ingenieur.Modifieringenieur(id, nom, postnom, adresse, telephone))
                    {
                        MessageBox.Show("Ingenieur Modifier", "Modifier Ingenieur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataGridViewingenieur.DataSource = ingenieur.listingenieur();
                        rafrechir();
                    }
                    else
                    {
                        MessageBox.Show("Echec d'ajout", "Modifier Ingenieur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                int id = Convert.ToInt32(TextboxId.Text);

                {

                    if (MessageBox.Show("Vouslez-Vous Vraiment Supprimer cet ingenieur?", "Suppression ingenieur", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (ingenieur.Supprimeringenieur(id))
                        {
                            MessageBox.Show("Ingenieur Supprimer", "Suppression Ingenieur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DataGridViewingenieur.DataSource = ingenieur.listingenieur();
                            rafrechir();
                        }
                        else
                        {
                            MessageBox.Show("Echec de Suppression", "Suppresion Ingenieur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        
        }

        public void rafrechir()
        {
            TextboxId.Text = "";
            textBoxNom.Text = "";
            textBoxPostnom.Text = "";
            textBoxAdresse.Text = "";
            textBoxTelephone.Text = "";
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            string nom = textBoxNom.Text;
            string postnom = textBoxPostnom.Text;
            string adresse = textBoxAdresse.Text;
            string telephone = textBoxTelephone.Text;

            if (nom.Trim().Equals(""))
            {
                MessageBox.Show("Le nom ne peux pas etre vide ", "Ajout ingenieur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (postnom.Trim().Equals(""))
            {
                MessageBox.Show("Le Postnom ne peux pas etre vide ", "Ajout ingenieur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (adresse.Trim().Equals(""))
            {
                MessageBox.Show("L'Adresse ne peux pas etre vide ", "Ajout  ingenieur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (telephone.Trim().Equals(""))
            {
                MessageBox.Show("Le numero de telephone  ne peux pas etre vide ", "Ajout ingenieur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (ingenieur.AjouterIngenieurt(nom, postnom, adresse, telephone))
                {
                    MessageBox.Show("Ingenieur Ajouter", "Ajout Ingenieur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataGridViewingenieur.DataSource = ingenieur.listingenieur();
                    rafrechir();
                }
                else
                {
                    MessageBox.Show("Echec d'ajout", "Ajout Ingenieur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(TextboxId.Text);
                string nom = textBoxNom.Text;
                string postnom = textBoxPostnom.Text;
                string adresse = textBoxAdresse.Text;
                string telephone = textBoxTelephone.Text;

                if (nom.Trim().Equals(""))
                {
                    MessageBox.Show("Le nom ne peux pas etre vide ", "Modifier ingenieur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (postnom.Trim().Equals(""))
                {
                    MessageBox.Show("Le Postnom ne peux pas etre vide ", "Modifier ingenieur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (adresse.Trim().Equals(""))
                {
                    MessageBox.Show("L'Adresse ne peux pas etre vide ", "Modifier ingenieur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (telephone.Trim().Equals(""))
                {
                    MessageBox.Show("Le numero de telephone  ne peux pas etre vide ", "Modifier ingenieur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (ingenieur.Modifieringenieur(id, nom, postnom, adresse, telephone))
                    {
                        MessageBox.Show("Ingenieur Modifier", "Modifier Ingenieur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataGridViewingenieur.DataSource = ingenieur.listingenieur();
                        rafrechir();
                    }
                    else
                    {
                        MessageBox.Show("Echec d'ajout", "Modifier Ingenieur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                int id = Convert.ToInt32(TextboxId.Text);

                {

                    if (MessageBox.Show("Vouslez-Vous Vraiment Supprimer cet ingenieur?", "Suppression ingenieur", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (ingenieur.Supprimeringenieur(id))
                        {
                            MessageBox.Show("Ingenieur Supprimer", "Suppression Ingenieur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DataGridViewingenieur.DataSource = ingenieur.listingenieur();
                            rafrechir();
                        }
                        else
                        {
                            MessageBox.Show("Echec de Suppression", "Suppresion Ingenieur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void DataGridViewingenieur_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            TextboxId.Text = DataGridViewingenieur.CurrentRow.Cells[0].Value.ToString();
            textBoxNom.Text = DataGridViewingenieur.CurrentRow.Cells[1].Value.ToString();
            textBoxPostnom.Text = DataGridViewingenieur.CurrentRow.Cells[2].Value.ToString();
            textBoxAdresse.Text = DataGridViewingenieur.CurrentRow.Cells[3].Value.ToString();
            textBoxTelephone.Text = DataGridViewingenieur.CurrentRow.Cells[4].Value.ToString();
        }
    }
 }


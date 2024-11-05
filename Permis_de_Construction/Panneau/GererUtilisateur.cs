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
    public partial class GererUtilisateur : Form
    {
        public GererUtilisateur()
        {
            InitializeComponent();
        }

        Class.Utilisateur utilisateur = new Class.Utilisateur();
        private void textBoxid_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBoxnomutilisateur_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBoxpostnom_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBoxnom_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxmotdepasse_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            string nom = textBoxnom.Text;
            string postnom = textBoxpostnom.Text;
            string nomutilisateur = textBoxnomutilisateur.Text;
            string motdepasse = textBoxmotdepasse.Text;
            string TypeUtilisateur = "Utilisateur";

            if (checkBox1converturadmin.Checked)
            {
                TypeUtilisateur = "Admin";
            }

            if (nom.Trim().Equals(""))
            {
                MessageBox.Show("Veillez ajouter un nom", "Nom invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (postnom.Trim().Equals(""))
            {
                MessageBox.Show("Veillez ajouter un Post-nom", "Post-Nom invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (nomutilisateur.Trim().Equals(""))
            {
                MessageBox.Show("Veillez ajouter un Nom Utilisateur", "Nom Utilisateur invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (motdepasse.Trim().Equals(""))
            {
                MessageBox.Show("Veillez ajouter un mot de passe", "Mot de passe invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (verification())
                {
                    if (utilisateur.AjouterUser(nom, postnom, nomutilisateur, motdepasse, TypeUtilisateur))
                    {
                        MessageBox.Show("Utilisateur Ajouter", "Ajout Utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataGridViewUtilisateur.DataSource = utilisateur.listUtilisateur();
                        rafrechir();
                    }

                    else
                    {
                        MessageBox.Show("Echec d'ajout", "Ajout Utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("Les deux mots de passe sont differents", "Confirmation Mot de passe", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxmotdepasse.Text = "";
                    textBoxconfirmemotdepasse.Text = "";
                }
            }
        }

        public Boolean verification()
        {
            string nom = textBoxnom.Text.Trim();
            string postnom = textBoxpostnom.Text.Trim();
            string nomutilisateur = textBoxnomutilisateur.Text.Trim();
            string motdepasse = textBoxmotdepasse.Text.Trim();
            string confirmemot = textBoxconfirmemotdepasse.Text.Trim();

            if (!confirmemot.Equals(motdepasse))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBoxid.Text);
            string nom = textBoxnom.Text;
            string postnom = textBoxpostnom.Text;
            string nomutilisateur = textBoxnomutilisateur.Text;
            string motdepasse = textBoxmotdepasse.Text;
            string TypeUtilisateur = "Utilisateur";

            if (checkBox1converturadmin.Checked)
            {
                TypeUtilisateur = "Admin";
            }

            if (nom.Trim().Equals(""))
            {
                MessageBox.Show("Veillez ajouter un nom", "Nom invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (postnom.Trim().Equals(""))
            {
                MessageBox.Show("Veillez ajouter un Post-nom", "Post-Nom invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (nomutilisateur.Trim().Equals(""))
            {
                MessageBox.Show("Veillez ajouter un Nom Utilisateur", "Nom Utilisateur invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (motdepasse.Trim().Equals(""))
            {
                MessageBox.Show("Veillez ajouter un mot de passe", "Mot de passe invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                if (utilisateur.ModifierUtilisateur(id, nom, postnom, nomutilisateur, motdepasse, TypeUtilisateur))
                {
                    MessageBox.Show("Utilisateur Modifier", "Modification Utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataGridViewUtilisateur.DataSource = utilisateur.listUtilisateur();
                    rafrechir();
                }

                else
                {
                    MessageBox.Show("Echec de Modification", "Modification Utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }

        }
        public void rafrechir()
        {
            textBoxid.Text = "";
            textBoxnom.Text = "";
            textBoxpostnom.Text = "";
            textBoxmotdepasse.Text = "";
            textBoxconfirmemotdepasse.Text = "";

        }

        private void GererUtilisateur_Load(object sender, EventArgs e)
        {
           DataGridViewUtilisateur.DataSource = utilisateur.listUtilisateur();
        }

        private void DataGridViewUtilisateur_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxid.Text = DataGridViewUtilisateur.CurrentRow.Cells[0].Value.ToString();
            textBoxnom.Text = DataGridViewUtilisateur.CurrentRow.Cells[1].Value.ToString();
            textBoxpostnom.Text = DataGridViewUtilisateur.CurrentRow.Cells[2].Value.ToString();
            textBoxnomutilisateur.Text = DataGridViewUtilisateur.CurrentRow.Cells[3].Value.ToString();
            textBoxmotdepasse.Text = DataGridViewUtilisateur.CurrentRow.Cells[4].Value.ToString();
            textBoxconfirmemotdepasse.Text = DataGridViewUtilisateur.CurrentRow.Cells[5].Value.ToString();
        }
    }
}

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
    public partial class GererDemdande : Form
    {

        Class.Demande demande = new Class.Demande();
        Class.Demandeur demandeur = new Class.Demandeur();
        Class.Reponse reponse = new Class.Reponse();
        Class.Terrain terrain = new Class.Terrain();
        public GererDemdande()
        {
            InitializeComponent();
        }

        private void GererDemdande_Load(object sender, EventArgs e)
        {
            DataGridViewDemande.DataSource = demande.list();

            //comboBoxDemandeur.DataSource = demande.listDemandeconc();
            //comboBoxDemandeur.DisplayMember = "Noms";
            //comboBoxDemandeur.ValueMember = "id";
            //comboBoxDemandeur.SelectedItem = null;

            comboBoxDemandeReponses.DataSource = demande.listDemande();
            comboBoxDemandeReponses.DisplayMember = "Designation";
            comboBoxDemandeReponses.ValueMember = "id";
            comboBoxDemandeReponses.SelectedItem = null;
            DataGridViewReponses.DataSource = reponse.listReponseConc();

            comboBoxTerrainDemande.DataSource = terrain.listTerrainJointure();
            comboBoxTerrainDemande.DisplayMember = "Designation";
            comboBoxTerrainDemande.ValueMember = "id";
            comboBoxTerrainDemande.SelectedItem = null;

            initialise();
            initialise1();
        }

        private void buttonajouter_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string designation = TextboxDesignation.Text;
            //    int montant = Convert.ToInt32(textBoxmontant.Text);
            //    DateTime datedemande = dateTimePickerDatedelademande.Value;
            //    int demandeur = Convert.ToInt32(comboBoxDemandeur.SelectedValue.ToString());

            //    if (TextboxDesignation.Text.Trim().Equals(""))
            //    {
            //        MessageBox.Show("La Designation ne peux pas etre vide ", "Ajout Demandeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    else if (textBoxmontant.Text.Trim().Equals(""))
            //    {
            //        MessageBox.Show("Le Montant ne peux pas etre vide ", "Ajout Demandeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    else
            //    {
            //        if (demande.Ajouterdemande(designation, demandeur, montant, datedemande))
            //        {
            //            MessageBox.Show("Demande Ajouter", "Ajout Demande", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            DataGridViewDemande.DataSource = demande.listDemande();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Echec d'ajout", "Ajout Demande", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Le montant n'est dois pas etre vide", "Erreur d'ajout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        private void DataGridViewDemande_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonmodifier_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    int id = Convert.ToInt32(textBoxid.Text);
            //    string designation = labelDesignationDemande.Text;

            //    DateTime datedemande = dateTimePickerDatedelademande.Value;
            //    int demandeur = Convert.ToInt32(comboBoxDemandeur.SelectedValue.ToString());

            //    if (labelDesignationDemande.Text.Trim().Equals(""))
            //    {
            //        MessageBox.Show("La Designation ne peux pas etre vide ", "Ajout Demandeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }

            //    else

            //    {
            //        if (demande.Modifiertdemande(id, designation, demandeur, datedemande))
            //        {
            //            MessageBox.Show("Demande Modifier", "Modification Demande", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            DataGridViewDemande.DataSource = demande.list();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Echec de Modification", "Modification Demande", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void buttonsupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxid.Text);

                {

                    if (MessageBox.Show("Vouslez-Vous Vraiment Supprimer cette Demande??", "Suppression demande", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (demande.Supprimerdemande(id))
                        {
                            MessageBox.Show("Demande Supprimer", "Suppression Demande", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DataGridViewDemande.DataSource = demande.list();
                        }
                        else
                        {
                            MessageBox.Show("Echec de Suppression", "Suppresion Demand", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonImprimer_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(@"F:\Demandeur"))
            {
                Directory.CreateDirectory(@"F:\Demandeur");
            }
            String filepath = @"F:\Demandeur\list.txt";
            if (!File.Exists(filepath))
            {
                File.Create(filepath).Close();
                MessageBox.Show("Fichier Cree");
            }

            //Maintenant nous allons remplir les textes avec les zones libres des textes Box

            TextWriter tx = new StreamWriter(filepath);

            //string iddemande;
            //string Designation;
            //string Demandeur;
            //string Montant;
            //string Dan;


            for (int i = 0; i < DataGridViewDemande.Rows.Count; i++) //Boucles pour les lignes
            {
                for (int j = 0; j < DataGridViewDemande.Columns.Count; j++)  //Boucle pour compter les colones
                {
                    tx.Write(DataGridViewDemande.Rows[i].Cells[j].Value.ToString());
                }

                // Nous voullons juste initialiser le nom de l'auteur et son id

                //id = DataGridViewDemande.Rows[i].Cells[0].Value.ToString();
                //Isbn = DataGridViewDemande.Rows[i].Cells[1].Value.ToString();
                //Titre = DataGridViewDemande.Rows[i].Cells[2].Value.ToString();


                //tx.Write(id + "-" + Isbn + "-" + Titre);
                tx.WriteLine(""); // Creation d'une nouvelle lignes
                tx.WriteLine("-----------------------------------");
            }

            tx.Close();
            MessageBox.Show("Donnee Exporter");
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string designation = labelDesignationDemande.Text;

            //    DateTime datedemande = dateTimePickerDatedelademande.Value;
            //    int demandeur = Convert.ToInt32(comboBoxDemandeur.SelectedValue.ToString());

            //    if (labelDesignationDemande.Text.Trim().Equals(""))
            //    {
            //        MessageBox.Show("La Designation ne peux pas etre vide ", "Ajout Demandeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    else
            //    {
            //        if (demande.Ajouterdemande(designation, demandeur, datedemande))
            //        {
            //            MessageBox.Show("Demande Ajouter", "Ajout Demande", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            DataGridViewDemande.DataSource = demande.list();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Echec d'ajout", "Ajout Demande", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Le montant n'est dois pas etre vide", "Erreur d'ajout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    int id = Convert.ToInt32(textBoxid.Text);
            //    string designation = labelDesignationDemande.Text;

            //    DateTime datedemande = dateTimePickerDatedelademande.Value;
            //    int demandeur = Convert.ToInt32(comboBoxDemandeur.SelectedValue.ToString());

            //    if (labelDesignationDemande.Text.Trim().Equals(""))
            //    {
            //        MessageBox.Show("La Designation ne peux pas etre vide ", "Ajout Demandeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }

            //    else

            //    {
            //        if (demande.Modifiertdemande(id, designation, demandeur, datedemande))
            //        {
            //            MessageBox.Show("Demande Modifier", "Modification Demande", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            DataGridViewDemande.DataSource = demande.list();
            //        }
            //        else
            //        {
            //            MessageBox.Show("Echec de Modification", "Modification Demande", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxid.Text);

                {

                    if (MessageBox.Show("Vouslez-Vous Vraiment Supprimer cette Demande??", "Suppression demande", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (demande.Supprimerdemande(id))
                        {
                            MessageBox.Show("Demande Supprimer", "Suppression Demande", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DataGridViewDemande.DataSource = demande.list();
                        }
                        else
                        {
                            MessageBox.Show("Echec de Suppression", "Suppresion Demand", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridViewDemande_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBoxid.Text = DataGridViewDemande.CurrentRow.Cells[0].Value.ToString();
            labelDesignationDemande.Text = DataGridViewDemande.CurrentRow.Cells[1].Value.ToString();
            comboBoxidDemandeur.Text = DataGridViewDemande.CurrentRow.Cells[2].Value.ToString();
            dateTimePickerDatedelademande.Value = (DateTime)DataGridViewDemande.CurrentRow.Cells[3].Value;
        }

        private void guna2Button9_Click_1(object sender, EventArgs e)
        {
            try
            {
                string designation = labelDesignationDemande.Text;

                DateTime datedemande = dateTimePickerDatedelademande.Value;
                int demandeur = Convert.ToInt32(comboBoxidDemandeur.Text.ToString());
                int Terrain = Convert.ToInt32(comboBoxTerrainDemande.SelectedValue.ToString());

                if (labelDesignationDemande.Text.Trim().Equals(""))
                {
                    MessageBox.Show("La Designation ne peux pas etre vide ", "Ajout Demandeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (comboBoxDemandeur.SelectedItem == null)
                {
                    MessageBox.Show("Veiller Choisir un Demandeur ", "Ajout Demandeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (demande.Ajouterdemande(designation, demandeur, datedemande, Terrain))
                    {
                        MessageBox.Show("Demande Ajouter", "Ajout Demande", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataGridViewDemande.DataSource = demande.list();
                        actualiser();
                        initialise1();
                    }
                    else
                    {
                        MessageBox.Show("Echec d'ajout", "Ajout Demande", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Le montant n'est dois pas etre vide", "Erreur d'ajout", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void guna2Button8_Click_1(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxid.Text);
                string designation = labelDesignationDemande.Text;

                DateTime datedemande = dateTimePickerDatedelademande.Value;
                int demandeur = Convert.ToInt32(comboBoxidDemandeur.Text.ToString());
                int Terrain = Convert.ToInt32(comboBoxTerrainDemande.SelectedValue.ToString());

                if (labelDesignationDemande.Text.Trim().Equals(""))
                {
                    MessageBox.Show("La Designation ne peux pas etre vide ", "Ajout Demandeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else

                {
                    if (demande.Modifiertdemande(id, designation, demandeur, datedemande,Terrain))
                    {
                        MessageBox.Show("Demande Modifier", "Modification Demande", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataGridViewDemande.DataSource = demande.list();
                        actualiser();
                    }
                    else
                    {
                        MessageBox.Show("Echec de Modification", "Modification Demande", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Button7_Click_1(object sender, EventArgs e)
        {

            try
            {
                int id = Convert.ToInt32(textBoxid.Text);

                {

                    if (MessageBox.Show("Vouslez-Vous Vraiment Supprimer cette Demande??", "Suppression demande", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (demande.Supprimerdemande(id))
                        {
                            MessageBox.Show("Demande Supprimer", "Suppression Demande", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DataGridViewDemande.DataSource = demande.list();
                            actualiser();
                        }
                        else
                        {
                            MessageBox.Show("Echec de Suppression", "Suppresion Demand", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void actualiser()
        {
            textBoxid.Text = "";
         
            comboBoxDemandeur.SelectedItem = null;
            comboBoxidDemandeur.SelectedItem = null;
            dateTimePickerDatedelademande.Value = DateTime.Now;
            textidReponses.Text = "";
            comboBoxDemandeReponses.SelectedItem = null;
            gunaDateTimePickerReponses.Value = DateTime.Now;
            comboBoxStatutReponses.SelectedItem = null;
            comboBoxTerrainDemande.SelectedItem = null;

            
        }

        private void DataGridViewDemande_CellClick_2(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(DataGridViewDemande.CurrentRow.Cells[0].Value.ToString());

            DataTable table = demande.GetDemande(id);

            if (table.Rows.Count > 0)
            {
                textBoxid.Text = table.Rows[0][0].ToString();
                labelDesignationDemande.Text = table.Rows[0][1].ToString();
                comboBoxidDemandeur.Text = table.Rows[0][2].ToString();
                dateTimePickerDatedelademande.Value = (DateTime)table.Rows[0][3];
                comboBoxTerrainDemande.SelectedValue = table.Rows[0][4].ToString();
                comboBoxDemandeur.Text = DataGridViewDemande.CurrentRow.Cells[2].Value.ToString();

            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            string Designation = labelDesignationReponses.Text;
            int Demande = Convert.ToInt32(comboBoxDemandeReponses.SelectedValue);
            string Statut = comboBoxStatutReponses.Text;
            DateTime Date = gunaDateTimePickerReponses.Value;

            if (labelDesignationDemande.Text.Trim().Equals(""))
            {
                MessageBox.Show("La Designation ne peux pas etre vide ", "Ajout Demandeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (comboBoxDemandeReponses.SelectedItem == null)
            {
                MessageBox.Show("Veiller Choisir un Demandeur ", "Ajout Demandeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (comboBoxStatutReponses.SelectedItem==null)
            {
                MessageBox.Show("Veiller Choisir un Statut ", "Ajout Demandeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (reponse.AjouterReponse(Designation, Demande, Statut, Date))
                {
                    MessageBox.Show("Reponse Ajouter ", "Ajout Reponse", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataGridViewReponses.DataSource = reponse.listReponseConc();
                    actualiser();
                    initialise();
                }
                else
                {
                    MessageBox.Show("Echec d'ajout", "Ajout Reponse", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



        }


        public void initialise()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Construction.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 Designation  FROM Reponse order by id DESC", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet table = new DataSet();
            adapter.Fill(table);

            if (table.Tables[0].Rows.Count > 0)
            {
                string tmp = table.Tables[0].Rows[0]["Designation"].ToString().Substring(4, 3);
                int new_id = Convert.ToInt32(tmp) + 1;
                labelDesignationReponses.Text = "REP-" + new_id.ToString("000");

            }
            else
            {
                labelDesignationReponses.Text = "REP-001";
            }
        }

        public void initialise1()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Construction.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 Designation  FROM Demande order by id DESC", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet table = new DataSet();
            adapter.Fill(table);

            if (table.Tables[0].Rows.Count > 0)
            {
                string tmp = table.Tables[0].Rows[0]["Designation"].ToString().Substring(4, 3);
                int new_id = Convert.ToInt32(tmp) + 1;
                labelDesignationDemande.Text = "DEM-" + new_id.ToString("000");

            }
            else
            {
                labelDesignationDemande.Text = "DEM-001";
            }
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            PanelDemandes.BringToFront();
        }

        private void bunifuTileButton2_Click(object sender, EventArgs e)
        {
            PanelReponses.BringToFront();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textidReponses.Text);
            string Designation = labelDesignationReponses.Text;
            int Demande = Convert.ToInt32(comboBoxDemandeReponses.SelectedValue);
            string Statut = comboBoxStatutReponses.Text;
            DateTime Date = gunaDateTimePickerReponses.Value;
            int Terrain = Convert.ToInt32(comboBoxTerrainDemande.SelectedValue);

            if (labelDesignationDemande.Text.Trim().Equals(""))
            {
                MessageBox.Show("La Designation ne peux pas etre vide ", "Ajout Demandeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (comboBoxDemandeReponses.SelectedItem == null)
            {
                MessageBox.Show("Veiller Choisir un Demandeur ", "Ajout Demandeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (reponse.ModifierReponse(id, Designation, Demande, Statut, Date))
                {
                    MessageBox.Show("Reponse Modifier ", "Modification Reponse", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataGridViewReponses.DataSource = reponse.listReponseConc();
                    actualiser();
                }
                else
                {
                    MessageBox.Show("Echec de Modification", "Modification Reponse", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DataGridViewReponses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(DataGridViewReponses.CurrentRow.Cells[0].Value.ToString());

            DataTable table = reponse.GetReponse(id);

            if(table.Rows.Count>0)
            {
                textidReponses.Text = table.Rows[0][0].ToString();
                labelDesignationReponses.Text = table.Rows[0][1].ToString();
                comboBoxDemandeReponses.SelectedValue= table.Rows[0][2].ToString();
                comboBoxStatutReponses.Text = table.Rows[0][3].ToString();
                gunaDateTimePickerReponses.Value = (DateTime)table.Rows[0][4];
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            Imprimer.PrintDemandes demande = new Imprimer.PrintDemandes();
            demande.Show();
            
        }

        private void comboBoxTerrainDemande_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Construction.mdf;Integrated Security=True;Connect Timeout=30");
                SqlCommand cmd = new SqlCommand("Select T.Designation, CONCAT(Demandeur.Nom, ' ', Demandeur.Postnom) Demandeur, Demandeur.Id from terrain T inner join Demandeur on Demandeur.Id=T.Demandeur Where T.Designation =  '" + comboBoxTerrainDemande.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataReader dr;
                dr = cmd.ExecuteReader();

                comboBoxDemandeur.Items.Clear();
                comboBoxidDemandeur.Items.Clear();
              
                while (dr.Read())
                {
                    comboBoxDemandeur.Items.Add(dr[1]);
                    comboBoxidDemandeur.Items.Add(dr[2]);
                }
                con.Close();
            
        }
    }
    
}

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

namespace Permis_de_Construction.Imprimer
{
    public partial class Carte_Agent : Form
    {
        int AgentID;
        public Carte_Agent(int id)
        {
            InitializeComponent();
            this.AgentID = id;
        }

        Class.Controleur controleur = new Class.Controleur();
        private void Carte_Agent_Load(object sender, EventArgs e)
        {
            DataTable table = controleur.GetControleur(AgentID);

            if(table.Rows.Count>0)
            {
                labelid.Text = table.Rows[0][0].ToString();
                labelNom.Text = table.Rows[0][1].ToString();
                labelPostNom.Text = table.Rows[0][2].ToString();
                labelSexe.Text = table.Rows[0][3].ToString();
                labelAdresse.Text = table.Rows[0][4].ToString();
                labelFonction.Text = table.Rows[0][5].ToString();
                labelMatricule.Text = table.Rows[0][6].ToString();
                labelTelephone.Text = table.Rows[0][7].ToString();
               

                try
                {
                    byte[] couverture = (byte[])table.Rows[0][8];
                    MemoryStream ms = new MemoryStream(couverture);
                    byte[] image = ms.ToArray();
                    PictureBoxAgent.Image = Image.FromStream(ms);
                }
                catch
                {

                }
            }

        }
    }
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permis_de_Construction.Class
{
    class Terrain
    {
        Base_de_donnee.Connecteur db = new Base_de_donnee.Connecteur();
        Base_de_donnee.Connexion connexion = new Base_de_donnee.Connexion();

        public Boolean AjouterTerrain(string Designation, int Longeur, int Largeur, int Demandeur, int Agent, int Avenue, int Controleur, int Ingenieur)
        {
            string query = "INSERT INTO terrain (Designation,Longeur,Largeur ,Demandeur, Agent, Avenue, Controleur, Ingenieur) VALUES (@Designation,@Longeur, @Largeur, @Demandeur, @Agent, @Avenue, @Controleur, @Ingenieur);";
            SqlParameter[] parameters = new SqlParameter[8];

            if (string.IsNullOrEmpty(Designation))
            {
                parameters[0] = new SqlParameter("@Designation", DBNull.Value);
                parameters[0].Value = Designation;
            }
            else
            {
                parameters[0] = new SqlParameter("@Designation", SqlDbType.VarChar);
                parameters[0].Value = Designation;
            }
   
            parameters[1] = new SqlParameter("@Longeur", SqlDbType.Int);
            parameters[1].Value = Longeur ;
           
            parameters[2] = new SqlParameter("@Demandeur", SqlDbType.Int);
            parameters[2].Value = Demandeur;

            parameters[3] = new SqlParameter("@Agent", SqlDbType.Int);
            parameters[3].Value = Agent;

            parameters[4] = new SqlParameter("@Avenue", SqlDbType.Int);
            parameters[4].Value = Avenue;

            parameters[5] = new SqlParameter("@Controleur", SqlDbType.Int);
            parameters[5].Value = Controleur;

            parameters[6] = new SqlParameter("@Largeur", SqlDbType.Int);
            parameters[6].Value = Largeur;

            parameters[7] = new SqlParameter("@Ingenieur", SqlDbType.Int);
            parameters[7].Value = Ingenieur;

            if (connexion.setdata(query, parameters) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        public Boolean ModifierTerrain(int id, string Designation, int Longeur, int Largeur, int Demandeur, int Agent, int Avenue, int Controleur, int Ingenieur)
        {
            string query = "UPDATE Terrain SET Designation= @Designation, Longeur=@Longeur, Largeur = @Largeur,  Demandeur = @Demandeur, Agent = @Agent, Avenue= @Avenue, Controleur = @Controleur, Ingenieur = @Ingenieur WHERE Id = @Id;";
            SqlParameter[] parameters = new SqlParameter[9];

            parameters[8] = new SqlParameter("@id", SqlDbType.Int);
            parameters[8].Value = id;

            if (string.IsNullOrEmpty(Designation))
            {
                parameters[0] = new SqlParameter("@Designation", DBNull.Value);
                parameters[0].Value = Designation;
            }
            else
            {
                parameters[0] = new SqlParameter("@Designation", SqlDbType.VarChar);
                parameters[0].Value = Designation;
            }

            parameters[1] = new SqlParameter("@Longeur", SqlDbType.Int);
            parameters[1].Value = Longeur;

            parameters[2] = new SqlParameter("@Demandeur", SqlDbType.Int);
            parameters[2].Value = Demandeur;

            parameters[3] = new SqlParameter("@Agent", SqlDbType.Int);
            parameters[3].Value = Agent;

            parameters[4] = new SqlParameter("@Avenue", SqlDbType.Int);
            parameters[4].Value = Avenue;

            parameters[5] = new SqlParameter("@Controleur", SqlDbType.Int);
            parameters[5].Value = Controleur;

            parameters[6] = new SqlParameter("@Largeur", SqlDbType.Int);
            parameters[6].Value = Largeur;

            parameters[7] = new SqlParameter("@Ingenieur", SqlDbType.Int);
            parameters[7].Value = Ingenieur;

            if (connexion.setdata(query, parameters) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable listTerrain(int id)
        {
            DataTable table = new DataTable();
            string query = "select * from terrain where id=@id";

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Id", SqlDbType.Int);
            parameters[0].Value = id;
            table = connexion.getdata(query, parameters);
            return table;
        }

        public DataTable listTerrainJointure()
        {
            DataTable table = new DataTable();
            table = connexion.getdata("Select Terrain.id, Terrain.Designation, Terrain.longeur, Terrain.largeur, CONCAT(Demandeur.Nom, ' ', Demandeur.Postnom) as Demandeur , CONCAT(Autorite.Nom, ' ', Autorite.Postnom) AS Autorite, Avenue.Designation as Avenue, CONCAT(controleur.nom, ' ', Controleur.Postnom) as Controleur, concat(Ingenieur.Nom, ' ', Ingenieur.Postnom) as Ingenieur from Terrain inner join Demandeur on Demandeur.Id = Terrain.Demandeur inner join Autorite on Autorite.Id = Terrain.Agent inner join Avenue on Avenue.Id = Terrain.Avenue inner join Controleur on Controleur.Id = Terrain.Controleur inner join Ingenieur on Ingenieur.id= Terrain.Ingenieur", null);
            return table;
        }
        public Boolean SupprimerTerrain(int id)
        {
            string query = "DELETE FROM terrain WHERE Id = @Id;";

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Id", SqlDbType.Int);
            parameters[0].Value = id;

            if (connexion .setdata(query, parameters) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

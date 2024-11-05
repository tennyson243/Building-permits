using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Permis_de_Construction.Class
{

    class Demande
    {
        Base_de_donnee.Connecteur db = new Base_de_donnee.Connecteur();
        Base_de_donnee.Connexion connexion = new Base_de_donnee.Connexion();

        public Boolean Ajouterdemande(string designation, int demande, DateTime datedemande, int Terrain)
        {
            string query = "INSERT INTO demande (Designation, Demandeur, Datedemande, Terrain) VALUES (@Designation, @Demandeur, @Datedemande, @Terrain)";

            SqlParameter[] parameters = new SqlParameter[4];

            if(string.IsNullOrEmpty(designation))
            {
                parameters[0] = new SqlParameter("@Designation",DBNull.Value);
                parameters[0].Value = designation;
            }
            else
            {
                parameters[0] = new SqlParameter("@Designation", SqlDbType.VarChar);
                parameters[0].Value = designation;
            }

            parameters[0] = new SqlParameter("@Designation", SqlDbType.VarChar);
            parameters[0].Value = designation;
            parameters[1] = new SqlParameter("@Demandeur", SqlDbType.Int);
            parameters[1].Value = demande;
          
            parameters[2] = new SqlParameter("@Datedemande", SqlDbType.DateTime);
            parameters[2].Value = datedemande;

            parameters[3] = new SqlParameter("@Terrain", SqlDbType.Int);
            parameters[3].Value = Terrain;

            if (connexion.setdata(query, parameters) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public DataTable listDemande()
        {
            DataTable table = new DataTable();
            table = connexion .getdata("select * from demande", null);
            return table;
        }

        public DataTable list()
        {
            DataTable table = new DataTable();
            table = connexion.getdata("select Demande.Id, Demande.Designation as Motif , CONCAT( Demandeur.Nom, ' ', Demandeur.Postnom) as Demandeur,  Demande.Datedemande, Terrain.Designation as Terrain from Demande inner join Demandeur on Demandeur.Id= Demande.Demandeur inner join Terrain on Terrain.Id =Demande.Terrain", null);
            return table;
        }
        public DataTable listDemandeconc()
        {
            DataTable table = new DataTable();
            table = connexion .getdata("select id,  concat( Nom , ' ', postnom) as Noms from demandeur", null);
            return table;
        }

        public Boolean Modifiertdemande(int id, string designation, int demande, DateTime datedemande, int Terrain)
        {
            string query = "UPDATE demande SET Designation = @Designation, Demandeur = @Demandeur,  Datedemande = @Datedemande, Terrain=@Terrain WHERE Id = @Id;";

            SqlParameter[] parameters = new SqlParameter[5];

            parameters[4] = new SqlParameter("@Id", SqlDbType.Int);
            parameters[4].Value = id;
          
            if(string.IsNullOrEmpty(designation))
            {
                parameters[0] = new SqlParameter("@Designation", DBNull.Value);
                parameters[0].Value = designation;
            }
            else
            {
                parameters[0] = new SqlParameter("@Designation", SqlDbType.VarChar);
                parameters[0].Value = designation;
            }
            parameters[1] = new SqlParameter("@Demandeur", SqlDbType.Int);
            parameters[1].Value = demande;

            parameters[2] = new SqlParameter("@Datedemande", SqlDbType.DateTime);
            parameters[2].Value = datedemande;

            parameters[3] = new SqlParameter("@Terrain", SqlDbType.Int);
            parameters[3].Value = Terrain;

            if (connexion.setdata(query, parameters) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        public Boolean Supprimerdemande(int id)
        {
            string query = "DELETE FROM demande WHERE Id= @Id";

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Id", SqlDbType.Int);
            parameters[0].Value = id;

            if (connexion.setdata(query, parameters) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable GetDemande(int id)
        {
            DataTable table = new DataTable();
            string query = "select * from Demande where id=@id";

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Id", SqlDbType.Int);
            parameters[0].Value = id;
            table = connexion.getdata(query, parameters);
            return table;
        }
    }
}

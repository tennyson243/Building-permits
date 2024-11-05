using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permis_de_Construction.Class
{
    class Reponse
    {
        Base_de_donnee.Connecteur db = new Base_de_donnee.Connecteur();
        Base_de_donnee.Connexion connexion = new Base_de_donnee.Connexion();

        public Boolean AjouterReponse(string Designation, int Demande, string Status, DateTime Date)
        {
            string query = "INSERT INTO Reponse(Designation, Demande, Statut, DateReponse ) VALUES (@Designation, @Demande, @Statut, @DateReponse);";
            SqlParameter[] parameters = new SqlParameter[4];

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

            parameters[1] = new SqlParameter("@Demande", SqlDbType.Int);
            parameters[1].Value = Demande;

            if (string.IsNullOrEmpty(Status))
            {
                parameters[2] = new SqlParameter("@Statut", DBNull.Value);
                parameters[2].Value = Status;
            }
            else
            {
                parameters[2] = new SqlParameter("@Statut", SqlDbType.VarChar);
                parameters[2].Value = Status;
            }
          
            parameters[3] = new SqlParameter("@DateReponse", SqlDbType.DateTime);
            parameters[3].Value = Date;

            if (connexion.setdata(query, parameters) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        public Boolean ModifierReponse(int id, string Designation, int Demande, string Status, DateTime Date)
        {
            string query = "UPDATE Reponse SET Designation= @Designation, Demande= @Demande, Statut= @Statut, DateReponse = @DateReponse WHERE Id = @Id";
            SqlParameter[] parameters = new SqlParameter[5];

            parameters[4] = new SqlParameter("@id", SqlDbType.Int);
            parameters[4].Value = id;

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

            parameters[1] = new SqlParameter("@Demande", SqlDbType.Int);
            parameters[1].Value = Demande;

            if (string.IsNullOrEmpty(Status))
            {
                parameters[2] = new SqlParameter("@Statut", DBNull.Value);
                parameters[2].Value = Status;
            }
            else
            {
                parameters[2] = new SqlParameter("@Statut", SqlDbType.VarChar);
                parameters[2].Value = Status;
            }

            parameters[3] = new SqlParameter("@DateReponse", SqlDbType.DateTime);
            parameters[3].Value = Date;


            if (connexion.setdata(query, parameters) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public DataTable listReponse()
        {
            DataTable table = new DataTable();
            table = connexion.getdata("select * from Reponse", null);
            return table;
        }

        public DataTable VuePermis()
        {
            DataTable table = new DataTable();
            table = connexion.getdata("select * from Permis_de_Construire", null);
            return table;
        }

        public DataTable listReponseConc()
        {
            DataTable table = new DataTable();
            table = connexion.getdata("Select Reponse.Id as ID, Reponse.Designation as Designation, Demande.Designation as Demande, Reponse.Statut , Reponse.DateReponse as Date from Reponse inner join Demande on Demande.Id=Reponse.Demande", null);
            return table;
        }


        public Boolean SupprimerDemande(int id)
        {
            string query = "DELETE FROM Reponse WHERE Id = @Id;";

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

        public DataTable GetReponse(int id)
        {
            DataTable table = new DataTable();
            string query = "select * from Reponse where id=@id";

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Id", SqlDbType.Int);
            parameters[0].Value = id;
            table = connexion.getdata(query, parameters);
            return table;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permis_de_Construction.Class
{
    class Quartier
    {

        Base_de_donnee.Connecteur db = new Base_de_donnee.Connecteur();
        Base_de_donnee.Connexion connexion = new Base_de_donnee.Connexion();
        public Boolean AjouterQuartier(string Designation, int Quartier)
        {
            string query = "INSERT INTO Quartier (Designation, Commune) VALUES (@Designation, @Commune);";

            SqlParameter[] parameters = new SqlParameter[2];

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

            parameters[1] = new SqlParameter("@Commune", SqlDbType.Int);
            parameters[1].Value = Quartier;


            if (connexion.setdata(query, parameters) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Boolean ModifierQuartier(int Id, string Designation, int Quartier)
        {
            string query = "UPDATE Quartier set Designation = @Designation, Commune=@Commune where id=@Id";

            SqlParameter[] parameters = new SqlParameter[3];

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

            parameters[1] = new SqlParameter("@Commune", SqlDbType.Int);
            parameters[1].Value = Quartier;


            parameters[2] = new SqlParameter("@id", SqlDbType.Int);
            parameters[2].Value = Id;

            if (connexion.setdata(query, parameters) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Boolean SupprimerAvenue(int id)
        {
            string query = "DELETE FROM Quartier WHERE id = @id;";

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@id", SqlDbType.Int);
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
        public DataTable listQuartier()
        {
            DataTable table = new DataTable();
            table = connexion.getdata("Select Quartier.id as id , Quartier.Designation as Quartier, Commune.Designation as Commune from Quartier inner join Commune ON Commune.Id = Quartier.Commune", null);
            return table;
        }

        public DataTable GetQuartier(int id)
        {
            DataTable table = new DataTable();
            string query = "select * from Quartier where id=@id";

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Id", SqlDbType.Int);
            parameters[0].Value = id;
            table = connexion.getdata(query, parameters);
            return table;
        }
    }
}

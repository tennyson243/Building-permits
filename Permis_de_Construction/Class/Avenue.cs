using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permis_de_Construction.Class
{
    class Avenue
    {
        Base_de_donnee.Connecteur db = new Base_de_donnee.Connecteur();
        Base_de_donnee.Connexion connexion = new Base_de_donnee.Connexion();


        public Boolean AjouterAvenue(string Designation, int Quartier)
        {
            string query = "INSERT INTO Avenue (Designation, Quartier) VALUES (@Designation, @Quartier);";

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

            parameters[1] = new SqlParameter("@Quartier", SqlDbType.Int);
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

        public Boolean ModifierAvenue(int Id, string Designation, int Quartier)
        {
            string query = "UPDATE Avenue set Designation = @Designation, Quartier=@Quartier where id=@Id";

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

            parameters[1] = new SqlParameter("@Quartier", SqlDbType.Int);
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
            string query = "DELETE FROM Avenue WHERE id = @id;";

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
        public DataTable listAvenue()
        {
            DataTable table = new DataTable();
            table = connexion.getdata("Select Avenue.id as id , Avenue.Designation as Avenue, Quartier.Designation as Quartier from Avenue inner join Quartier ON Quartier.Id = Avenue.Quartier", null);
            return table;
        }

        public DataTable GetAvenue(int id)
        {
            DataTable table = new DataTable();
            string query = "select * from Avenue where id=@id";

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Id", SqlDbType.Int);
            parameters[0].Value = id;
            table = connexion.getdata(query, parameters);
            return table;
        }
    }
}

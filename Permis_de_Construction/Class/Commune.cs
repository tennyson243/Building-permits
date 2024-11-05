using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permis_de_Construction.Class
{
    class Commune
    {

        Base_de_donnee.Connecteur db = new Base_de_donnee.Connecteur();
        Base_de_donnee.Connexion connexion = new Base_de_donnee.Connexion();


        public Boolean AjouterCommune(string Designation)
        {
            string query = "INSERT INTO Commune (Designation) VALUES (@Designation);";

            SqlParameter[] parameters = new SqlParameter[1];

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

            if (connexion.setdata(query, parameters) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Boolean ModifierAvenue(int Id, string Designation)
        {
            string query = "UPDATE Commune set Designation = @Designation where id=@Id";

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

            parameters[1] = new SqlParameter("@id", SqlDbType.Int);
            parameters[1].Value = Id;

            if (connexion.setdata(query, parameters) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Boolean SupprimerCommune(int id)
        {
            string query = "DELETE FROM Commune WHERE id = @id;";

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
        public DataTable listCommune()
        {
            DataTable table = new DataTable();
            table = connexion.getdata("select * from Commune", null);
            return table;
        }
    }
}

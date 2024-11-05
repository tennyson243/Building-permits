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
    class Ingenieur
    {
        Base_de_donnee.Connecteur db = new Base_de_donnee.Connecteur();
        Base_de_donnee.Connexion connexion = new Base_de_donnee.Connexion();

        public Boolean AjouterIngenieurt(string Nom, string postnom, string Adresse, string telephone)
        {
            string query = "INSERT INTO ingenieur (Nom, postnom, adresse, telephone) VALUES (@Nom, @postnom, @adresse,@telephone)";
            SqlParameter[] parameters = new SqlParameter[4];

            if(string .IsNullOrEmpty(Nom))
            {
                parameters[0] = new SqlParameter("@Nom", DBNull .Value );
                parameters[0].Value = Nom;
            }
            else
            {
                parameters[0] = new SqlParameter("@Nom", MySqlDbType.VarChar);
                parameters[0].Value = Nom;
            }

            if (string.IsNullOrEmpty(postnom))
            {
                parameters[1] = new SqlParameter("@postnom", DBNull .Value );
                parameters[1].Value = postnom;
            }
            else
            {
                parameters[1] = new SqlParameter("@postnom", SqlDbType.VarChar);
                parameters[1].Value = postnom;
            }

            if (string.IsNullOrEmpty(Adresse ))
            {
                parameters[2] = new SqlParameter("@Adresse", DBNull .Value );
                parameters[2].Value = Adresse;
            }
            else
            {
                parameters[2] = new SqlParameter("@Adresse", SqlDbType.VarChar);
                parameters[2].Value = Adresse;
            }

            if (string.IsNullOrEmpty(telephone))
            {
                parameters[3] = new SqlParameter("@telephone", DBNull.Value);
                parameters[3].Value = telephone;
            }
            else
            {
                parameters[3] = new SqlParameter("@telephone", SqlDbType.VarChar);
                parameters[3].Value = telephone;
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
        public Boolean Modifieringenieur(int id, string Nom, string postnom, string Adresse, string telephone)
        {
            string query = "UPDATE ingenieur SET Nom =@Nom, postnom =@postnom, adresse =@adresse, telephone = @telephone WHERE (`Id` = @Id);";
            SqlParameter[] parameters = new SqlParameter[5];

            parameters[4] = new SqlParameter("@id", SqlDbType.Int);
            parameters[4].Value = id;

            if (string.IsNullOrEmpty(Nom))
            {
                parameters[0] = new SqlParameter("@Nom", DBNull.Value);
                parameters[0].Value = Nom;
            }
            else
            {
                parameters[0] = new SqlParameter("@Nom", MySqlDbType.VarChar);
                parameters[0].Value = Nom;
            }

            if (string.IsNullOrEmpty(postnom))
            {
                parameters[1] = new SqlParameter("@postnom", DBNull.Value);
                parameters[1].Value = postnom;
            }
            else
            {
                parameters[1] = new SqlParameter("@postnom", SqlDbType.VarChar);
                parameters[1].Value = postnom;
            }

            if (string.IsNullOrEmpty(Adresse))
            {
                parameters[2] = new SqlParameter("@Adresse", DBNull.Value);
                parameters[2].Value = Adresse;
            }
            else
            {
                parameters[2] = new SqlParameter("@Adresse", SqlDbType.VarChar);
                parameters[2].Value = Adresse;
            }

            if (string.IsNullOrEmpty(telephone))
            {
                parameters[3] = new SqlParameter("@telephone", DBNull.Value);
                parameters[3].Value = telephone;
            }
            else
            {
                parameters[3] = new SqlParameter("@telephone", SqlDbType.VarChar);
                parameters[3].Value = telephone;
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

        public DataTable listingenieur()
        {
            DataTable table = new DataTable();
            table = connexion .getdata("select * from ingenieur", null);
            return table;
        }

        public Boolean Supprimeringenieur(int id)
        {
            string query = "DELETE FROM ingenieur WHERE (Id = @Id);";

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@Id", MySqlDbType.Int32);
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

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
    class Demandeur
    {
        Base_de_donnee.Connecteur db = new Base_de_donnee.Connecteur();
        Base_de_donnee.Connexion connexion = new Base_de_donnee.Connexion();


        public Boolean Ajouterdemandeur(string nm, string psn, string adr, string phn, byte[] photo)
        {
            string query = "INSERT INTO demandeur (Nom, Postnom, Adresse, Telephone, Photo) VALUES (@Nom, @Postnom, @Adresse, @Telephone, @Photo);";

            SqlParameter[] parameters = new SqlParameter[5];

            if(string.IsNullOrEmpty(nm))
            {
                parameters[0] = new SqlParameter("@Nom", DBNull.Value);
                parameters[0].Value = nm;
            }
            else
            {
                parameters[0] = new SqlParameter("@Nom", SqlDbType.VarChar);
                parameters[0].Value = nm;
            }

            if (string.IsNullOrEmpty(psn))
            {
                parameters[1] = new SqlParameter("@Postnom", DBNull.Value);
                parameters[1].Value = psn;
            }
            else
            {
                parameters[1] = new SqlParameter("@Postnom", SqlDbType.VarChar);
                parameters[1].Value = psn;
            }
            if (string.IsNullOrEmpty(adr))
            {
                parameters[2] = new SqlParameter("@Adresse", DBNull.Value);
                parameters[2].Value = adr;
            }
            else
            {
                parameters[2] = new SqlParameter("@Adresse", SqlDbType.VarChar);
                parameters[2].Value = adr;
            }
            if (string.IsNullOrEmpty(phn))
            {
                parameters[3] = new SqlParameter("@Telephone", DBNull.Value);
                parameters[3].Value = phn;
            }
            else
            {
                parameters[3] = new SqlParameter("@Telephone", SqlDbType.VarChar);
                parameters[3].Value = phn;
            }

           
            parameters[4] = new SqlParameter("@Photo", SqlDbType.Binary);
            parameters[4].Value = photo;

            if (connexion.setdata(query, parameters) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Boolean Modifierdemandeur(int id, string nm, string psn, string adr, string phn, byte[] photo)
        {
            string query = "UPDATE demandeur SET Nom = @Nom, Postnom = @Postnom, Adresse = @Adresse, Telephone = @Telephone, Photo= @Photo WHERE (id = @id );";

            SqlParameter[] parameters = new SqlParameter[6];

            if (string.IsNullOrEmpty(nm))
            {
                parameters[0] = new SqlParameter("@Nom", DBNull.Value);
                parameters[0].Value = nm;
            }
            else
            {
                parameters[0] = new SqlParameter("@Nom", SqlDbType.VarChar);
                parameters[0].Value = nm;
            }

            if (string.IsNullOrEmpty(psn))
            {
                parameters[1] = new SqlParameter("@Postnom", DBNull.Value);
                parameters[1].Value = psn;
            }
            else
            {
                parameters[1] = new SqlParameter("@Postnom", SqlDbType.VarChar);
                parameters[1].Value = psn;
            }
            if (string.IsNullOrEmpty(adr))
            {
                parameters[2] = new SqlParameter("@Adresse", DBNull.Value);
                parameters[2].Value = adr;
            }
            else
            {
                parameters[2] = new SqlParameter("@Adresse", SqlDbType.VarChar);
                parameters[2].Value = adr;
            }
            if (string.IsNullOrEmpty(phn))
            {
                parameters[3] = new SqlParameter("@Telephone", DBNull.Value);
                parameters[3].Value = phn;
            }
            else
            {
                parameters[3] = new SqlParameter("@Telephone", SqlDbType.VarChar);
                parameters[3].Value = phn;
            }


            parameters[4] = new SqlParameter("@Photo", SqlDbType.Binary);
            parameters[4].Value = photo;

            parameters[5] = new SqlParameter("@id", SqlDbType.Int);
            parameters[5].Value = id;

            if (connexion.setdata(query, parameters) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Boolean Supprimerdemandeur(int id)
        {
            string query = "DELETE FROM demandeur WHERE id = @id";

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
        public DataTable listDemandeur()
        {
            DataTable table = new DataTable();
            table = connexion .getdata("select *from demandeur", null);
            return table;
        }
    }
}

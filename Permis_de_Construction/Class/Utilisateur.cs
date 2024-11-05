using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permis_de_Construction.Class
{
    class Utilisateur
    {
        Base_de_donnee.Connexion connexion = new Base_de_donnee.Connexion();
        public Boolean AjouterUser(string nm, string postnom, string NomUtilisateur, string MotdePasse, string type)
        {
            string query = "Insert into Utilisateur (Nom, Postnom, nomutilisateur, motdepasse, TypeUtilisateur) values (@Nom, @Post_Nom, @Nom_Utilisateur, @Mot_de_Passe, @TypeUtilisateur)";
            SqlParameter[] parameters = new SqlParameter[5];

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
            if (string.IsNullOrEmpty(postnom))
            {
                parameters[1] = new SqlParameter("@Post_Nom", DBNull.Value);
                parameters[1].Value = postnom;
            }
            else
            {
                parameters[1] = new SqlParameter("@Post_Nom", SqlDbType.VarChar);
                parameters[1].Value = postnom;
            }
            if (string.IsNullOrEmpty(NomUtilisateur))
            {
                parameters[2] = new SqlParameter("@Nom_Utilisateur", DBNull.Value);
                parameters[2].Value = NomUtilisateur;
            }
            else
            {
                parameters[2] = new SqlParameter("@Nom_Utilisateur", SqlDbType.VarChar);
                parameters[2].Value = NomUtilisateur;
            }
            if (string.IsNullOrEmpty(MotdePasse))
            {
                parameters[3] = new SqlParameter("@Mot_de_Passe", DBNull.Value);
                parameters[3].Value = MotdePasse;
            }
            else
            {
                parameters[3] = new SqlParameter("@Mot_de_Passe", SqlDbType.VarChar);
                parameters[3].Value = MotdePasse;
            }
            if (string.IsNullOrEmpty(type))
            {
                parameters[4] = new SqlParameter("@TypeUtilisateur", DBNull.Value);
                parameters[4].Value = type;
            }
            else
            {
                parameters[4] = new SqlParameter("@TypeUtilisateur", SqlDbType.VarChar);
                parameters[4].Value = type;
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

        public Boolean ModifierUtilisateur(int id, string nm, string postnom, string NomUtilisateur, string MotdePasse, string type)
        {
            string query = "Update Utilisateur set nom = @Nom, postnom = @Post_Nom, nomutilisateur = @Nom_Utilisateur, motdepasse = @Mot_de_Passe, TypeUtilisateur=@TypeUtilisateur where Id = @Id";
            SqlParameter[] parameters = new SqlParameter[5];

            parameters[4] = new SqlParameter("@Id", SqlDbType.Int);
            parameters[4].Value = id;

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
            if (string.IsNullOrEmpty(postnom))
            {
                parameters[1] = new SqlParameter("@Post_Nom", DBNull.Value);
                parameters[1].Value = postnom;
            }
            else
            {
                parameters[1] = new SqlParameter("@Post_Nom", SqlDbType.VarChar);
                parameters[1].Value = postnom;
            }
            if (string.IsNullOrEmpty(NomUtilisateur))
            {
                parameters[2] = new SqlParameter("@Nom_Utilisateur", DBNull.Value);
                parameters[2].Value = NomUtilisateur;
            }
            else
            {
                parameters[2] = new SqlParameter("@Nom_Utilisateur", SqlDbType.VarChar);
                parameters[2].Value = NomUtilisateur;
            }
            if (string.IsNullOrEmpty(MotdePasse))
            {
                parameters[3] = new SqlParameter("@Mot_de_Passe", DBNull.Value);
                parameters[3].Value = MotdePasse;
            }
            else
            {
                parameters[3] = new SqlParameter("@Mot_de_Passe", SqlDbType.VarChar);
                parameters[3].Value = MotdePasse;
            }

            if (string.IsNullOrEmpty(type))
            {
                parameters[5] = new SqlParameter("@TypeUtilisateur", DBNull.Value);
                parameters[5].Value = type;
            }
            else
            {
                parameters[5] = new SqlParameter("@TypeUtilisateur", SqlDbType.VarChar);
                parameters[5].Value = type;
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

        public DataTable listUtilisateur()
        {
            DataTable table = new DataTable();
            table = connexion.getdata("Select*from Utilisateur", null);
            return table;
        }



        public Boolean SupprimerUtilisateur(int id)
        {
            string query = "Delete from Utilisateur where id = @id";
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
    }
}

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
    class Autorite
    {
        Base_de_donnee.Connecteur db = new Base_de_donnee.Connecteur();
        Base_de_donnee.Connexion connexion = new Base_de_donnee.Connexion();

        public Boolean AjouterAgent(string Nom, string postnom, string sexe, string Adresse, string fonction, string matricule, string telephone, byte [] image)
        {
            string query = "INSERT INTO Autorite (Nom, postnom, sexe, Adresse, fonction, matricule, teleagent, photoagent) VALUES (@Nom, @postnom, @sexe, @Adresse, @fonction, @matricule, @teleagent, @photoagent);";
            SqlParameter[] parameters = new SqlParameter[8];

            if(string.IsNullOrEmpty(Nom))
            {
                parameters[0] = new SqlParameter("@Nom", DBNull.Value);
                parameters[0].Value = Nom;
            }
            else
            {
                parameters[0] = new SqlParameter("@Nom", SqlDbType.VarChar);
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

            if (string.IsNullOrEmpty(sexe))
            {
                parameters[2] = new SqlParameter("@sexe", DBNull.Value);
                parameters[2].Value = sexe;
            }
            else
            {
                parameters[2] = new SqlParameter("@sexe", SqlDbType.VarChar);
                parameters[2].Value = sexe;
            }
            if (string.IsNullOrEmpty(Adresse))
            {
                parameters[3] = new SqlParameter("@Adresse", DBNull.Value);
                parameters[3].Value = Adresse;
            }
            else
            {
                parameters[3] = new SqlParameter("@Adresse", SqlDbType.VarChar);
                parameters[3].Value = Adresse;
            }
            if (string.IsNullOrEmpty(fonction))
            {
                parameters[4] = new SqlParameter("@fonction", DBNull.Value);
                parameters[4].Value = fonction;
            }
            else
            {
                parameters[4] = new SqlParameter("@fonction", SqlDbType.VarChar);
                parameters[4].Value =fonction;
            }
            if (string.IsNullOrEmpty(matricule))
            {
                parameters[5] = new SqlParameter("@matricule", DBNull.Value);
                parameters[5].Value = matricule;
            }
            else
            {
                parameters[5] = new SqlParameter("@matricule", SqlDbType.VarChar);
                parameters[5].Value = matricule;
            }
            if (string.IsNullOrEmpty(telephone))
            {
                parameters[6] = new SqlParameter("@teleagent", DBNull.Value);
                parameters[6].Value = telephone;
            }
            else
            {
                parameters[6] = new SqlParameter("@teleagent", SqlDbType.VarChar);
                parameters[6].Value = telephone;
            }


            parameters[7] = new SqlParameter("@Photoagent", SqlDbType.Binary);
            parameters[7].Value = image;


            if (connexion.setdata(query, parameters) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }


        }
        public Boolean ModifierAgent(int id, string Nom, string postnom, string sexe, string Adresse, string fonction, string matricule, string telephone, byte[] image)
        {
            string query = "UPDATE Autorite SET Nom= @Nom, postnom= @postnom, sexe= @sexe, Adresse=@Adresse, fonction= @fonction, matricule= @matricule, teleagent = @teleagent, photoagent= @photoagent WHERE Id = @Id";
            SqlParameter[] parameters = new SqlParameter[9];

            parameters[8] = new SqlParameter("@id", SqlDbType.Int);
            parameters[8].Value = id;

            if (string.IsNullOrEmpty(Nom))
            {
                parameters[0] = new SqlParameter("@Nom", DBNull.Value);
                parameters[0].Value = Nom;
            }
            else
            {
                parameters[0] = new SqlParameter("@Nom", SqlDbType.VarChar);
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

            if (string.IsNullOrEmpty(sexe))
            {
                parameters[2] = new SqlParameter("@sexe", DBNull.Value);
                parameters[2].Value = sexe;
            }
            else
            {
                parameters[2] = new SqlParameter("@sexe", SqlDbType.VarChar);
                parameters[2].Value = sexe;
            }
            if (string.IsNullOrEmpty(Adresse))
            {
                parameters[3] = new SqlParameter("@Adresse", DBNull.Value);
                parameters[3].Value = Adresse;
            }
            else
            {
                parameters[3] = new SqlParameter("@Adresse", SqlDbType.VarChar);
                parameters[3].Value = Adresse;
            }
            if (string.IsNullOrEmpty(fonction))
            {
                parameters[4] = new SqlParameter("@fonction", DBNull.Value);
                parameters[4].Value = fonction;
            }
            else
            {
                parameters[4] = new SqlParameter("@fonction", SqlDbType.VarChar);
                parameters[4].Value = fonction;
            }
            if (string.IsNullOrEmpty(matricule))
            {
                parameters[5] = new SqlParameter("@matricule", DBNull.Value);
                parameters[5].Value = matricule;
            }
            else
            {
                parameters[5] = new SqlParameter("@matricule", SqlDbType.VarChar);
                parameters[5].Value = matricule;
            }
            if (string.IsNullOrEmpty(telephone))
            {
                parameters[6] = new SqlParameter("@teleagent", DBNull.Value);
                parameters[6].Value = telephone;
            }
            else
            {
                parameters[6] = new SqlParameter("@teleagent", SqlDbType.VarChar);
                parameters[6].Value = telephone;
            }


            parameters[7] = new SqlParameter("@Photoagent", SqlDbType.Binary);
            parameters[7].Value = image;

            if (connexion.setdata(query, parameters) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public DataTable listAgent()
        {
            DataTable table = new DataTable();
            table = connexion.getdata("select * from Autorite", null);
            return table;
        }



        public Boolean SupprimerAgent(int id)
        {
            string query = "DELETE FROM Autorite WHERE Id = @Id;";

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
    }
}

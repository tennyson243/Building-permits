using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Permis_de_Construction.Base_de_donnee
{
    class Connecteur
    {
      
        private MySqlConnection Connexion = new MySqlConnection("server =localhost;userid=root;password=243tennyson;database=urbanisme;sslmode=Required");

        public void openconnexion()
        {
            if (Connexion.State == System.Data.ConnectionState.Closed)
            {
                Connexion.Open();
            }
        }

        public void closeconnexion()
        {
            if (Connexion.State == System.Data.ConnectionState.Open)
            {
                Connexion.Close();
            }
        }

        public MySqlConnection getconnexion()
        {
            return Connexion;
        }

        public DataTable getdata(string query, MySqlParameter[] parameters)
        {
            MySqlCommand command = new MySqlCommand(query, Connexion);
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }

        public int setdata(string query, MySqlParameter[] parameters)
        {
            MySqlCommand command = new MySqlCommand(query, Connexion);
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            openconnexion();

            int commandstat = command.ExecuteNonQuery();
            closeconnexion();

            return commandstat;
        }
    }




}

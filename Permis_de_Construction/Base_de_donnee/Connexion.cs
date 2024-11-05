using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permis_de_Construction.Base_de_donnee
{
    class Connexion
    {
       
        private SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Construction.mdf;Integrated Security=True;Connect Timeout=30");

        public void OpenConnection()
        {
            if(Con.State == System.Data.ConnectionState.Closed)
            {
                Con.Open();
            }
        }

        public void CloseConnection()
        {
            if(Con.State == System.Data.ConnectionState.Open)
            {
                Con.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            return Con;
        }

        public DataTable getdata(string query, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(query, Con);

            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(table);
            return table;
        }

        public int setdata(string query, SqlParameter[] parameters)
        {
            SqlCommand cmd = new SqlCommand(query, Con);

            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            OpenConnection();
            int commandState = cmd.ExecuteNonQuery();
            CloseConnection();
            return commandState;

        }
    }
}

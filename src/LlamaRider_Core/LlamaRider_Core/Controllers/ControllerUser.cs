using DataImport.Factories;
using DataImport.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LlamaRider_Core.Controllers
{
    internal class ControllerUser
    {
        private readonly NpgsqlConnection? _connectHost;
        public ControllerUser(NpgsqlConnection? connectHost)
        {
            _connectHost = connectHost;
        }

        public void InsertAutoUser(User user)
        {

            string sqlQuery = string.Format("Insert Into users" +
                   "(Id, username, email, passwordHash, role_id) " +
                   "Values(@id, @username, @email, @passwordHash, @role_id)");

            using (var sqlCommand = new NpgsqlCommand(sqlQuery, _connectHost))
            {
                sqlCommand.Parameters.AddWithValue("@id", user.ID);
                sqlCommand.Parameters.AddWithValue("@username", user.Username);
                sqlCommand.Parameters.AddWithValue("@email", user.Email);
                sqlCommand.Parameters.AddWithValue("@passwordHash", user.Password);
                sqlCommand.Parameters.AddWithValue("@role_id", 0);

                sqlCommand.ExecuteNonQuery();
            }
        }

        public DataTable GetAllUsers()
        {
            DataTable inv = new DataTable();
            string sql = "Select * From users";
            using (var cmd = new NpgsqlCommand(sql, _connectHost))
            {
                var dr = cmd.ExecuteReader();
                inv.Load(dr);
                dr.Close();
            }

            foreach (DataRow dataRow in inv.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    Console.Write(item+" ");
                }
                Console.WriteLine();
            }
            return inv;
        }

    }
}

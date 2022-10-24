using System.Data;
using DataImport.Models;
using Npgsql;

namespace DataImport.Controller;

public class ControllerUser
{
    public static NpgsqlConnection? _connectHost;

    public static void InsertAutoUser(User user)
    {
        var sqlQuery = string.Format("Insert Into users" +
                                     "(Id, username, email, passwordHash, role) " +
                                     "Values(@id, @username, @email, @passwordHash, @role)");

        using (var sqlCommand = new NpgsqlCommand(sqlQuery, _connectHost))
        {
            sqlCommand.Parameters.AddWithValue("@id", user.Id);
            sqlCommand.Parameters.AddWithValue("@username", user.Username);
            sqlCommand.Parameters.AddWithValue("@email", user.Email);
            sqlCommand.Parameters.AddWithValue("@passwordHash", user.Password);
            sqlCommand.Parameters.AddWithValue("@role", 0);

            sqlCommand.ExecuteNonQuery();
        }
    }

    public static DataTable GetAllUsers()
    {
        var dataTable = new DataTable();
        var sqlQuery = "Select * From users";
        using (var cmd = new NpgsqlCommand(sqlQuery, _connectHost))
        {
            var npgsqlDataReader = cmd.ExecuteReader();
            dataTable.Load(npgsqlDataReader);
            npgsqlDataReader.Close();
        }

        foreach (DataRow dataRow in dataTable.Rows)
        {
            foreach (var item in dataRow.ItemArray)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();
        }
        return dataTable;
    }
}
using System.Data;
using DataImport.Models;
using Npgsql;

namespace DataImport.Controller;

public class ControllerBook
{
    public static NpgsqlConnection? _connectHost;

        public static void InsertAutoBook(Book book)
        {
            var sqlQuery = string.Format("Insert Into books" +
                   "(Id, url_to_file, publisher_id, titular_photo, author, name, genre, description, rating, pages_number) " +
                   "Values(@id, @url_to_file, @publisher_id, @titular_photo, @author, @name, @genre, @description, @rating, @pages_number)");

            using (var sqlCommand = new NpgsqlCommand(sqlQuery, _connectHost))
            {
                sqlCommand.Parameters.AddWithValue("@id", book.Id);
                sqlCommand.Parameters.AddWithValue("@publisher_id", book.PublisherId);
                sqlCommand.Parameters.AddWithValue("@titular_photo", book.TitularPhoto);
                sqlCommand.Parameters.AddWithValue("@url_to_file", book.UrlToFile);
                sqlCommand.Parameters.AddWithValue("@author", book.Author);
                sqlCommand.Parameters.AddWithValue("@name", book.Name);
                sqlCommand.Parameters.AddWithValue("@genre", book.Genre);
                sqlCommand.Parameters.AddWithValue("@description", book.Description);
                sqlCommand.Parameters.AddWithValue("@rating", book.Rating);
                sqlCommand.Parameters.AddWithValue("@pages_number", book.PagesNumber);

                sqlCommand.ExecuteNonQuery();
            }
        }

        public static void GetAllBooks()
        {
            var dataTable = new DataTable();
            var sqlQuery = "Select * From books";
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
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }
}
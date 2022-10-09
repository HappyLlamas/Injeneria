using DataImport.Factories;
using DataImport.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LlamaRider_Core.Controllers
{
    public class ControllerBook
    {
        private readonly NpgsqlConnection? _connectHost;
        public ControllerBook(NpgsqlConnection? connectHost)
        {
            _connectHost = connectHost;
        }

        public void InsertAutoBook(Book book)
        {
            string sqlQuery = string.Format("Insert Into books" +
                   "(Id, url_to_file, Publisher_ID, Author, Name, Genre, Description, Rating, Pages_Number) " +
                   "Values(@id, @url_to_file, @Publisher_ID, @Author, @Name, @Genre, @Description, @Rating, @Pages_Number)");

            using (var sqlCommand = new NpgsqlCommand(sqlQuery, _connectHost))
            {
                sqlCommand.Parameters.AddWithValue("@id", book.ID);
                sqlCommand.Parameters.AddWithValue("@Publisher_ID", book.PublisherID);
                sqlCommand.Parameters.AddWithValue("@url_to_file", book.UrlToFile);
                sqlCommand.Parameters.AddWithValue("@Author", book.Author);
                sqlCommand.Parameters.AddWithValue("@Name", book.Name);
                sqlCommand.Parameters.AddWithValue("@Genre", book.Genre);
                sqlCommand.Parameters.AddWithValue("@Description", book.Description);
                sqlCommand.Parameters.AddWithValue("@Rating", book.Rating);
                sqlCommand.Parameters.AddWithValue("@Pages_Number", book.PagesNumber);

                sqlCommand.ExecuteNonQuery();
            }
        }

        public void GetAllBooks()
        {
            DataTable inv = new DataTable();
            string sql = "Select * From books";
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
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

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
    public class ControllerReadingProgress
    {
        private readonly NpgsqlConnection? _connectHost;
        public ControllerReadingProgress(NpgsqlConnection? connectHost)
        {
            _connectHost = connectHost;
        }

        public void InsertAutoReadingProgress(ReadingProgress readingProgressFactory)
        {

            string sqlQuery = string.Format("Insert Into reading_progress" +
                   "(Id, book_id, user_id, path_to_file, last_page, theme_id, is_favourite, font_size, updated_at) " +
                   "Values(@id, @book_id, @user_id, @path_to_file, @last_page, @theme_id, @is_favourite, @font_size, @updated_at)");

            using (var sqlCommand = new NpgsqlCommand(sqlQuery, _connectHost))
            {
                sqlCommand.Parameters.AddWithValue("@id", readingProgressFactory.Id);
                sqlCommand.Parameters.AddWithValue("@book_id", readingProgressFactory.BookId);
                sqlCommand.Parameters.AddWithValue("@user_id", readingProgressFactory.UserId);
                sqlCommand.Parameters.AddWithValue("@path_to_file", readingProgressFactory.PathToFile);
                sqlCommand.Parameters.AddWithValue("@last_page", readingProgressFactory.LastPage % 30);
                sqlCommand.Parameters.AddWithValue("@theme_id", (int)readingProgressFactory.Theme);
                sqlCommand.Parameters.AddWithValue("@is_favourite", readingProgressFactory.IsFavourite);
                sqlCommand.Parameters.AddWithValue("@font_size", readingProgressFactory.FontSize);
                sqlCommand.Parameters.AddWithValue("@updated_at", readingProgressFactory.UpdatedAt);

                sqlCommand.ExecuteNonQuery();
            }
        }

        public void GetAllReadingProgress()
        {
            DataTable inv = new DataTable();
            string sql = "Select * From reading_progress";
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

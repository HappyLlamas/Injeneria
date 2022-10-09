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
                   "(Id, BookID, UserID, LastPage, IsFavourite, FontSize) " +
                   "Values(@id, @BookID, @UserID, @LastPage, @IsFavourite, @FontSize");

            using (var sqlCommand = new NpgsqlCommand(sqlQuery, _connectHost))
            {
                sqlCommand.Parameters.AddWithValue("@id", readingProgressFactory.ID);
                sqlCommand.Parameters.AddWithValue("@BookID", readingProgressFactory.BookID);
                sqlCommand.Parameters.AddWithValue("@UserID", readingProgressFactory.UserID);
                sqlCommand.Parameters.AddWithValue("@LastPage", readingProgressFactory.LastPage);
                sqlCommand.Parameters.AddWithValue("@IsFavourite", readingProgressFactory.IsFavourite);
                sqlCommand.Parameters.AddWithValue("@FontSize", readingProgressFactory.FontSize);

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

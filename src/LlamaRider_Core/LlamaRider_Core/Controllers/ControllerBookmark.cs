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
    public class ControllerBookmark
    {
        private readonly NpgsqlConnection? _connectHost;
        public ControllerBookmark(NpgsqlConnection? connect)
        {
            _connectHost = connect;
        }

        public void InsertAutoBookmark(Bookmark bookmark)
        {

            string sqlQuery = string.Format("Insert Into bookmarks" +
                   "(Id, Reading_Progress_Id, Page_Number, Note) " +
                   "Values(@id, @Reading_Progress_Id, @Page_Number, @Note)");

            using (var sqlCommand = new NpgsqlCommand(sqlQuery, _connectHost))
            {
                sqlCommand.Parameters.AddWithValue("@id", bookmark.Id);
                sqlCommand.Parameters.AddWithValue("@Reading_Progress_Id", bookmark.ReadingProgressId);
                sqlCommand.Parameters.AddWithValue("@Page_Number", bookmark.PageNumber);
                sqlCommand.Parameters.AddWithValue("@Note", bookmark.Note);

                sqlCommand.ExecuteNonQuery();
            }
        }

        public void GetAllBookmarks()
        {
            DataTable inv = new DataTable();
            string sql = "Select * From bookmarks";
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

using System.Data;
using DataImport.Models;
using Npgsql;

namespace DataImport.Controller;

public class ControllerBookmark
{
    public static NpgsqlConnection? _connectHost;

    public static void InsertAutoBookmark(Bookmark bookmark)
    {

        var sqlQuery = string.Format("Insert Into bookmarks" +
                                        "(id, reading_progress_id, page_number, note) " +
                                        "Values(@id, @reading_progress_id, @page_number, @note)");

        using (var sqlCommand = new NpgsqlCommand(sqlQuery, _connectHost))
        {
            sqlCommand.Parameters.AddWithValue("@id", bookmark.Id);
            sqlCommand.Parameters.AddWithValue("@reading_progress_id", bookmark.ReadingProgressId);
            sqlCommand.Parameters.AddWithValue("@page_number", bookmark.PageNumber);
            sqlCommand.Parameters.AddWithValue("@note", bookmark.Note);

            sqlCommand.ExecuteNonQuery();
        }
    }

    public static void GetAllBookmarks()
    {
        var dataTable = new DataTable();
        var sqlQuery = "Select * From bookmarks";
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
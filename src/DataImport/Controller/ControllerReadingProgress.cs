using System.Data;
using DataImport.Models;
using Npgsql;

namespace DataImport.Controller;

public class ControllerReadingProgress
{
    public static NpgsqlConnection? _connectHost;

    public static void InsertAutoReadingProgress(ReadingProgress readingProgressFactory)
    {
        string sqlQuery = string.Format("Insert Into reading_progress" +
                                        "(Id, book_id, user_id, path_to_file, last_page, theme, is_favourite, font_size, updated_at) " +
                                        "Values(@id, @book_id, @user_id, @path_to_file, @last_page, @theme, @is_favourite, @font_size, @updated_at)");

        using (var sqlCommand = new NpgsqlCommand(sqlQuery, _connectHost))
        {
            sqlCommand.Parameters.AddWithValue("@id", readingProgressFactory.Id);
            sqlCommand.Parameters.AddWithValue("@book_id", readingProgressFactory.BookId);
            sqlCommand.Parameters.AddWithValue("@user_id", readingProgressFactory.UserId);
            sqlCommand.Parameters.AddWithValue("@path_to_file", readingProgressFactory.PathToFile);
            sqlCommand.Parameters.AddWithValue("@last_page", readingProgressFactory.LastPage % 30);
            sqlCommand.Parameters.AddWithValue("@theme", (int) readingProgressFactory.Theme);
            sqlCommand.Parameters.AddWithValue("@is_favourite", readingProgressFactory.IsFavourite);
            sqlCommand.Parameters.AddWithValue("@font_size", readingProgressFactory.FontSize);
            sqlCommand.Parameters.AddWithValue("@updated_at", readingProgressFactory.UpdatedAt);

            sqlCommand.ExecuteNonQuery();
        }
    }

    public static void GetAllReadingProgress()
    {
        var dataTable = new DataTable();
        var sqlQuery = "Select * From reading_progress";
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
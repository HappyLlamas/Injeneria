using DataImport.Controller;
using Npgsql;

namespace DataImport.Utilities;

public class Database
{
    public static NpgsqlConnection? _connect;
    public static void ConnetionOther(NpgsqlConnection? connect)
    {
        _connect = connect;
        ControllerUser._connectHost = _connect;
        ControllerBook._connectHost = _connect;
        ControllerBookmark._connectHost = _connect;
        ControllerReadingProgress._connectHost = _connect;
    }

    public static void FillValueToDatabase(int count)
    {
        var users = RandomData.GenerateUsers(count);
        
        for (var i = 0; i < count; i++)
        {
            ControllerUser.InsertAutoUser(users[i]);
        }

        var books = RandomData.GenerateBooks(count, users);
        for (var i = 0; i < count; i++)
        {
            ControllerBook.InsertAutoBook(books[i]);
        }

        var readingProgresss = RandomData.GenerateReadingProgress(count, users, books);
        for (var i = 0; i < count; i++)
        {
            ControllerReadingProgress.InsertAutoReadingProgress(readingProgresss[i]);
        }

        var bookmarks = RandomData.GenerateBookmarks(count, readingProgresss);
        for (var i = 0; i < count; i++)
        {
            ControllerBookmark.InsertAutoBookmark(bookmarks[i]);
        }
    }

    public static void GetUsers() => ControllerUser.GetAllUsers();
    public static void GetBooks() => ControllerBook.GetAllBooks();
    public static void GetReadingProgress() => ControllerReadingProgress.GetAllReadingProgress();
    public static void GetBookmark() => ControllerBookmark.GetAllBookmarks();
}
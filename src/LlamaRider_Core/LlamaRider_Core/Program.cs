using Bogus;
using DataImport.Factories;
using DataImport.Models;
using DataImport.Utilities;
using LlamaRider_Core;
using LlamaRider_Core.Controllers;
using Npgsql;
using System.Data;

string connString = "Host=db.ikyuxfksnzysklzobngb.supabase.co;Database=postgres;User Id=postgres;Password=febL5712PTWDXh8M;";
NpgsqlConnection? connect = new NpgsqlConnection(connString);
connect.Open();
var user = new ControllerUser(connect);
var book = new ControllerBook(connect);
var bookmark = new ControllerBookmark(connect);
var reading_progress = new ControllerReadingProgress(connect);


var count = 40;
var users = RandomData.GenerateUsers(count);





for (int i = 0; i < count; i++)
{
    user.InsertAutoUser(users[i]);
}

var books = RandomData.GenerateBooks(count, users);
for (int i = 0; i < count; i++)
{
    book.InsertAutoBook(books[i]);
}

var reading_progresss = RandomData.GenerateReadingProgress(count, users, books);
for (int i = 0; i < count; i++)
{
    reading_progress.InsertAutoReadingProgress(reading_progresss[i]);
}

var bookmarks = RandomData.GenerateBookmarks(count, reading_progresss);
for (int i = 0; i < count; i++)
{
    bookmark.InsertAutoBookmark(bookmarks[i]);

}


//user.GetAllUsers();


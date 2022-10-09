
using DataImport.Models;
using DataImport.Factories;
using Faker;

namespace DataImport.Utilities;


public static class StaticData
{
	public static string[] Genres = File.ReadAllLines(
		path: "./Strings/Genres.txt");

	public static string[] Names = File.ReadAllLines(
		path: "./Strings/Names.txt");

	public static string[] Authors = File.ReadAllLines(
		path: "./Strings/Authors.txt");

	public static string[] Descriptions = File.ReadAllLines(
		path: "./Strings/Descriptions.txt");

	public static string[] Urls = File.ReadAllLines(
		path: "./Strings/Urls.txt");
}

public class RandomData
{
	public static User[] GenerateUsers(
		int quantity)
	{
		User[] users = new User[quantity];
		Random random = new Random();
		
		for (int i = 0; i < quantity; ++i)
		{
			users[i] = new UserFactory().Get(
				param: new Dictionary<string, object>()
				{
					{"Id", i},
				});
			Console.WriteLine(users[i]);
		}
		
		return (users);
	}

	public static Book[] GenerateBooks(
		int quantity,
		User[] publishers)
	{
		Book[] books = new Book[quantity];
		
		for (int i = 0; i < quantity; ++i)
		{
			books[i] = new BookFactory().Get(
				param: new Dictionary<string, object>()
				{
					{"Id", i},
					{"PublisherId", RandomChoices<User>.FromArray(publishers).Id},
					{"Genre", RandomChoices<string>.FromArray(StaticData.Genres)},
					{"UrlToFile", Internet.Url()},
				});
		}
		
		return (books);
	}
	
	public static Bookmark[] GenerateBookmarks(
		int quantity,
		User[] users,
		Book[] books)
	{
		Bookmark[] bookmarks = new Bookmark[quantity];
		
		for (int i = 0; i < quantity; ++i)
		{
			Book book = RandomChoices<Book>.FromArray(books);
			bookmarks[i] = new BookmarkFactory().Get(
				param: new Dictionary<string, object>()
				{
					{"Id", i},
					{"UserId", RandomChoices<User>.FromArray(users).Id},
					{"BookId", book.Id},
					{"PageNumber", RandomNumber.Next(book.PagesNumber)},
				});
		}
		
		return (bookmarks);
	}
	
	public static ReadingProgress[] GenerateReadingProgress(
		int quantity,
		User[] users,
		Book[] books)
	{
		ReadingProgress[] progresses = new ReadingProgress[quantity];
		
		for (int i = 0; i < quantity; ++i)
		{
			Book book = RandomChoices<Book>.FromArray(books);
			progresses[i] = new ReadingProgressFactory().Get(
				param: new Dictionary<string, object>()
				{
					{"Id", i},
					{"UserId", RandomChoices<User>.FromArray(users).Id},
					{"BookId", book.Id},
					{"LastPage", RandomNumber.Next(book.PagesNumber)},
				});
		}
		
		return (progresses);
	}
}
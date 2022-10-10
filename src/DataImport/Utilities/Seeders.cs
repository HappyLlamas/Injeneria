using DataImport.Factories;
using DataImport.Models;
using Faker;

namespace DataImport.Utilities;

public static class Seeders
{
	public static int length = 38;
	
	public static Book[] GetBooks()
	{
		Book[] books = new Book[length];

		for (int i = 0; i < length; ++i)
		{
			books[i] = new BookFactory().Get(
				param: new Dictionary<string, object>()
				{
					{"Id", i},
					{"Name", StaticData.Names[i]},
					{"Author", StaticData.Authors[i]},
					{"Descriptions", StaticData.Descriptions[i]},
					{"Genre", RandomChoices<string>.FromArray(StaticData.Genres)},
					{"PublisherId", RandomNumber.Next() % length},
					{"UrlToFile", StaticData.Urls[i]},
				});
		}
		
		return (books);
	}
}
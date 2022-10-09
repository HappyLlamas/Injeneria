using DataImport.Models;
using Faker;

namespace DataImport.Factories;

public class BookmarkFactory
	: ModelFactory<Bookmark>
{
	public int ID { get; } = RandomNumber.Next();
	public int BookID { get; } = RandomNumber.Next();
	public int UserID { get; } = RandomNumber.Next();
	public int PageNumber { get; } = RandomNumber.Next();
	public string Note { get; } = Lorem.Paragraph();
}
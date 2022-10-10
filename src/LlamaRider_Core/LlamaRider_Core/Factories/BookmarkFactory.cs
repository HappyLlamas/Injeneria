using DataImport.Models;
using Faker;

namespace DataImport.Factories;

public class BookmarkFactory
	: ModelFactory<Bookmark>
{
	public int Id { get; } = RandomNumber.Next();
	public int ReadingProgressId { get; } = RandomNumber.Next();
	public int PageNumber { get; } = RandomNumber.Next();
	public string Note { get; } = Lorem.Paragraph();
}
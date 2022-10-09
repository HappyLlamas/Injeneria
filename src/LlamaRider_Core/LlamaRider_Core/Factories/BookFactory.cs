using Faker;
using DataImport.Models;

namespace DataImport.Factories;

public class BookFactory 
	: ModelFactory<Book>
{
	public int ID { get; } = RandomNumber.Next();
    public int PublisherID { get; } = RandomNumber.Next();
	public string Author { get; } = Faker.Name.FullName();
	public string Name { get; } = Company.Name();
	public string Genre { get; } = Lorem.GetFirstWord();
	public string Description { get; } = Lorem.Paragraph();
	public float Rating { get; } = RandomNumber.Next() % 6;
	public int PagesNumber { get; } = RandomNumber.Next();
}
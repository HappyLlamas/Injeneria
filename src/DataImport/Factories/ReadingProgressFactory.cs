using Faker;
using DataImport.Models;

namespace DataImport.Factories;

public class ReadingProgressFactory
	: ModelFactory<ReadingProgress>
{
	public int Id { get; } = RandomNumber.Next();
	public int BookId { get; } = RandomNumber.Next();
	public int UserId { get; } = RandomNumber.Next();
	public int LastPage { get; } = RandomNumber.Next();
	public bool IsFavourite { get; } = (RandomNumber.Next() % 2 == 0);
	public int FontSize { get; } = RandomNumber.Next() % 100;
	public string PathToFile { get; } = Internet.Url();
}
using Faker;
using DataImport.Models;

namespace DataImport.Factories;

public class ReadingProgressFactory
	: ModelFactory<ReadingProgress>
{
	public int ID { get; } = RandomNumber.Next();
	public int BookID { get; } = RandomNumber.Next();
	public int UserID { get; } = RandomNumber.Next();
	public int LastPage { get; } = RandomNumber.Next();
	public bool IsFavourite { get; } = (RandomNumber.Next() % 2 == 0);
	public int FontSize { get; } = RandomNumber.Next() % 100;
}
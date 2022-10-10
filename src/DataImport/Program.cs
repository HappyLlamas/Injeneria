using DataImport.Utilities;

namespace DataImport;


public static class Program
{
	public static void Main(
		string[] args)
	{
		RandomData.GenerateUsers(quantity: 5);
		return;
	}
}

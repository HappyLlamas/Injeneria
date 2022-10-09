using System;

namespace DataImport.Utilities;


public static class RandomChoices<TRandomChoice>
{
	public static Random random = new Random();
	
	public static TRandomChoice FromArray(
		TRandomChoice[] array)
	{
		int randomIndex = random.Next(0, array.Length);
		return (array[randomIndex]);
	}
}

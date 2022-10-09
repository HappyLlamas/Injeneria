using System.Text;
using System.Security.Cryptography;

namespace DataImport.Utilities;

public static class Hashing
{
	public static string HashSHA256(
		string? pass)
	{
		if (pass == null)
		{
			throw new ArgumentException(
				message: "Password cannot be null");
		}
		
		byte[]? hash = SHA256.Create().ComputeHash(
				buffer: Encoding.UTF8.GetBytes(s: pass));
		StringBuilder str = new StringBuilder();

		foreach (byte b in hash)
		{
			str.Append(b);
		}
		
		return (str.ToString());
	}
}
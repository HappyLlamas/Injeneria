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
				buffer: Encoding.ASCII.GetBytes(s: pass));
		
		return (BitConverter.ToString(hash));
	}
}

using System.Reflection;

namespace DataImport.Models;


public class User
{
	public enum UserRole
	{
		USER = 0,
		AUTHOR = 1,
		EDITOR = 2,
		ADMIN = 3,
	}
	
	public int Id { get; set; }
	public string Email { get; set; }
	public string Username { get; set; }
	public string Password { get; set; }
	public UserRole Role { get; set; } = UserRole.USER;
	public byte[]? Avatar { get; set; } = new byte[1];
	public DateTime UpdatedAt { get; set; } = DateTime.Now;

	public override string ToString()
	{
		string res = "";
		PropertyInfo[] propeties = this.GetType().GetProperties()!.ToArray();
		res += propeties[0].GetValue(obj: this)?.ToString();
		
		for (int i = 1; i < propeties.Count(); ++i)
		{
			res += (' ' + propeties[i].GetValue(obj: this)?.ToString());
		}

		return (res);
	}
}

using System.Reflection;

namespace DataImport.Models;


public class User
{
	public enum UserRole
	{
		USER,
		AUTHOR,
		EDITOR,
		ADMIN,
	}
	
	public int ID { get; set; }
	public string Email { get; set; }
	public string Username { get; set; }
	public string Password { get; set; }
	public UserRole Role { get; set; }	
	public byte[]? Avatar { get; set; }
	public DateTime UpdatedAt { get; set; }

	public User()
		: this(id: 0, email: "", username: "", password: "")
	{
		return;
	}
	
	public User(
		int id,
		string email,
		string username,
		string password,
		int userRole = 0)
	{
		this.ID = id;
		this.Email = email;
		this.Password = password;
		this.Username = username;
		this.Role = (UserRole)userRole;
		this.Avatar = new byte[1];
		this.UpdatedAt = DateTime.Now;
		return;
	}

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

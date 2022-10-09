using Faker;
using DataImport.Models;
using DataImport.Utilities;

namespace DataImport.Factories;


public class UserFactory
	: ModelFactory<User>
{
	public int ID { get; } = RandomNumber.Next();
	public string Email { get; } = Internet.Email();
	public string Username { get; } = Internet.UserName();
	public string Password { get; } = Hashing.HashSHA256(
		pass: Lorem.GetFirstWord());
}
﻿using System.Configuration;
using DataImport.Controller;
using DataImport.Utilities;
using Npgsql;

namespace DataImport;


public static class Program
{
	public static void Main(
		string[] args)
	{
		const string connectionString = "Host=db.ikyuxfksnzysklzobngb.supabase.co;Database=postgres;User Id=postgres;Password=febL5712PTWDXh8M;";
		var connect = new NpgsqlConnection(connectionString);
		Database.ConnetionOther(connect);
		
		connect.Open();
		Database.GetBooks();
		connect.Close();
		return;
	}
}

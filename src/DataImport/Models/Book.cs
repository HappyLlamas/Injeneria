using System;

namespace DataImport.Models;

public class Book
{
	public enum StatusCode
	{
		NOT_ALLOWED = -1,
		IN_REVIEW = 0,
		ALLOWED = 1,
	}
	
	public int Id { get; set; }
	public string UrlToFile { get; set; }
	public int PublisherId { get; set; }
	public byte[]? TitularPhoto { get; set; } = new byte[1];
	public string Author { get; set; }
	public string Name { get; set; }
	public string Genre { get; set; }
	public string Description { get; set; }
	public float Rating { get; set; }
	public int PagesNumber { get; set; }
	public StatusCode Status { get; set; } = StatusCode.IN_REVIEW;
	public DateTime UpdatedAt { get; set; } = DateTime.Now;
}

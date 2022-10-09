using System;

namespace DataImport.Models;

public class Book
{
	public enum StatusCode
	{
		NOT_ALLOWED,
		IN_REVIEW,
		ALLOWED,
	}
	
	public int ID { get; set; }
	public string UrlToFile { get; set; }
	public int PublisherID { get; set; }
	public byte[]? TitularPhoto { get; set; }
	public string Author { get; set; }
	public string Name { get; set; }
	public string Genre { get; set; }
	public string Description { get; set; }
	public float Rating { get; set; }
	public int PagesNumber { get; set; }
	public StatusCode Status { get; set; }
	public DateTime UpdatedAt { get; set; }

	public Book()
	{
		this.Status = StatusCode.IN_REVIEW;
		this.TitularPhoto = new byte[1];
		this.UpdatedAt = DateTime.Now;
	}
}

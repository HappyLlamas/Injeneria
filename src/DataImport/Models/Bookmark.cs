using System;

namespace DataImport.Models;


public class Bookmark
{
	public int ID { get; set; }
	public int BookID { get; set; }
	public int UserID { get; set; }
	public int PageNumber { get; set; }
	public string Note { get; set; }
	public DateTime UpdatedAt { get; set; }

	public Bookmark()
	{
		this.UpdatedAt = DateTime.Now;
	}
}
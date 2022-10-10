using System;

namespace DataImport.Models;


public class Bookmark
{
	public int Id { get; set; }
	public int ReadingProgressId { get; set; }
	public int PageNumber { get; set; }
	public string Note { get; set; }
	public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
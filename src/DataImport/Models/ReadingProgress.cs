using System;

namespace DataImport.Models;


public class ReadingProgress
{
	public enum BookTheme
	{
		WHITE,
		BLACK,
		MIXED,
	}
	
	public int ID { get; set; }
	public int BookID { get; set; }
	public int UserID { get; set; }
	public int LastPage { get; set; }
	public bool IsFavourite { get; set; }
	public BookTheme Theme { get; set; }
	public int FontSize { get; set; }
	public DateTime UpdatedAt { get; set; }

	public ReadingProgress()
	{
		this.Theme = BookTheme.WHITE;
		this.UpdatedAt = DateTime.Now;
	}
}
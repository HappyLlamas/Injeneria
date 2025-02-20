﻿using System;

namespace DataImport.Models;


public class ReadingProgress
{
	public enum BookTheme
	{
		WHITE = 0,
		BLACK = 1,
		MIXED = 2,
	}
	
	public int Id { get; set; }
	public int BookId { get; set; }
	public int UserId { get; set; }
	public int LastPage { get; set; }
	public bool IsFavourite { get; set; }
	public BookTheme Theme { get; set; } = BookTheme.WHITE;
	public int FontSize { get; set; }
	public string PathToFile { get; set; }
	public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
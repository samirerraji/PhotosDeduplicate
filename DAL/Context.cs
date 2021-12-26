using System;
using Microsoft.EntityFrameworkCore;

namespace PhotosDeduplicate.DAL
{
	class Context : DbContext
	{
		public DbSet<File> Files { get; set; }

		public string DbPath { get; private set; }

		public Context()
		{
			var folder = Environment.SpecialFolder.LocalApplicationData;
			var path = Environment.GetFolderPath(folder);
			DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}file.db";
		}
		protected override void OnConfiguring(DbContextOptionsBuilder options)
			=> options.UseSqlite($"Data Source={DbPath}");
	}
}

﻿using ClownClubMVC.Models.loggin;
using Microsoft.EntityFrameworkCore;
namespace ClownClubMVC.Data;

public class DataDBContext : DbContext
{
	public DataDBContext()
	{
	}

	public DataDBContext(DbContextOptions<DataDBContext> options)
		: base(options)
	{ }

	public DbSet<usersLoggin> usersLoggin { get; set; }
    public DbSet<passwordLoggin> passwordLoggin { get; set; }
}

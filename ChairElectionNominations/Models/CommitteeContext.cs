using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace ChairElections.Models;
public class CommitteeContext : DbContext
{
    
    private readonly IConfiguration _configuration;

    public CommitteeContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<Committee> Committees { get; set; }
    public DbSet<ChairNomination> ChairNominations { get; set; }

    public DbSet<RegisteredInterest> RegisteredInterests { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // Read values from appsettings.json
        var workingDirectory = _configuration["WorkingDirectory"] 
                               ?? Environment.GetEnvironmentVariable("WorkingDirectory") 
                               ?? AppContext.BaseDirectory;

        Console.WriteLine($"Working Directory: {workingDirectory}");

        var connectionString = _configuration.GetConnectionString("DatabaseSource")
                               ?? Environment.GetEnvironmentVariable("DatabaseSource") 
                               ?? "App_Data/CommitteeChairNominations.db";

        Console.WriteLine($"Connection String: {connectionString}");

        // Build full path
        string dbPath;
        if (connectionString.StartsWith("App_Data/"))
        {
            var relativePath = connectionString.Substring("App_Data/".Length);
            dbPath = Path.Combine(workingDirectory, "App_Data", relativePath);
        }
        else
        {
            dbPath = Path.Combine(workingDirectory, connectionString);
        }
        Console.WriteLine($"Database Path: {dbPath}");
        options.UseSqlite($"Data Source={dbPath}");
    }
  
}
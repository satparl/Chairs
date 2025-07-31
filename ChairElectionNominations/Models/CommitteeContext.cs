using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace ChairElections.Models;
public class CommitteeContext : DbContext
{
    public DbSet<Committee> Committees { get; set; }
    public DbSet<ChairNomination> ChairNominations { get; set; }

    public DbSet<RegisteredInterest> RegisteredInterests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=App_Data/CommitteeChairNominations.db");
}
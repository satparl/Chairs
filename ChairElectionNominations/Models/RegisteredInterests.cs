using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChairElectionNominations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace ChairElections.Models;

public class RegisteredInterest
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RegisteredInterestId { get; set; }
    public int MemberId { get; set; }
    public int CommitteeId { get; set; }
    public string RegisteredInterestText { get; set; }
}
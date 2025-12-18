using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChairElectionNominations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace ChairElections.Models;

public class ChairStatement
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ChairStatementId { get; set; }
    public int MemberId { get; set; }
    public int CommitteeId { get; set; }
    [MaxWords(500, ErrorMessage = "Chair statement cannot exceed 500 words.")]
    public string ChairStatementText { get; set; }
}
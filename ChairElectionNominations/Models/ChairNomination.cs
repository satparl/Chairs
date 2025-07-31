using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
namespace ChairElections.Models;
public class ChairNomination
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [HiddenInput(DisplayValue = false)]
    [Required(ErrorMessage = "Committee is required.")]

    public int CommitteeId { get; set; }

    [Required(ErrorMessage = "Nominee is required.")]
    public int NomineeId { get; set; }

    [Required(ErrorMessage = "Nominator is required.")]
    public int NominatedById { get; set; }

    public string NominationSummary { get; set; }

    public string RegisteredInterest { get; set; }
    public DateTime NominationDate { get; set; }
    
    [NotMapped]
    [ValidateNever]
    public List<KeyValuePair<int, string>> Committees { get; set; }
}
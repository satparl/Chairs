using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChairElectionNominations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace ChairElections.Models;


public class Committee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
    public DateTime DateModified { get; set; }
    public int? CurrentChairId { get; set; }

    public string AssignedParty { get; set; }

    [ValidateNever]
    [NotMapped]
    public List<ChairNomination> ChairNominations { get; set; }

    [ValidateNever]
    [NotMapped]
    public List<NominationViewModel> NominationFullDetails { get; set; }

}



using MemberApi.Models;

namespace ChairElections.Models
{
    public class NominationViewModel
    {
        public int Id { get; set; }
        public int NomineeId { get; set; }
        public string NomineeName { get; set; }

        public string NominateeParty { get; set; }
        public int NominatedById { get; set; }
        public string NominatedByName { get; set; }
        public int CommitteeId { get; set; }
        public string CommitteeName { get; set; }
        public string? RegisteredInterest { get; set; }

        public string? VoteRegisteredInterest { get; set; }
        public DateTime NominationDate { get; set; }
        public string Summary { get; set; }
        public string NominatedParty { get; internal set; }
    }
}
using Microsoft.AspNetCore.Mvc;
using ParliamentApi.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using MemberApi.Models;


namespace ChairElectionNominations.Controllers
{
    [Route("api/Members")]
    [ApiController]
    public class MembersController : Controller
    {
        private readonly MembersApiService _service;
        private readonly HttpClient httpClient;

        public MembersController(HttpClient _httpClient)
        {
            httpClient = _httpClient;
            _service = new MembersApiService("https://members-api.parliament.uk/", httpClient);
        }


        // 🕰️ Historical Members
        [HttpGet("search-historical")]
        public async Task<IActionResult> SearchHistorical(string name, DateTimeOffset? date)
        {
            var result = await _service.SearchHistoricalAsync(name, date, 0, 20);
            return Ok(result);
        }

        // 👤 Member by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMember(int id)
        {
            var result = await _service.MembersAsync(id, null);
            return Ok(result);
        }

        // 📜 Biography
        [HttpGet("{id}/biography")]
        public async Task<IActionResult> GetBiography(int id)
        {
            var result = await _service.BiographyAsync(id);
            return Ok(result);
        }

        // 📞 Contact
        [HttpGet("{id}/contact")]
        public async Task<IActionResult> GetContact(int id)
        {
            var result = await _service.ContactAsync(id);
            return Ok(result);
        }

        // 🗣️ Contributions
        [HttpGet("{id}/contributions")]
        public async Task<IActionResult> GetContributions(int id, int? page = 0)
        {
            var result = await _service.ContributionSummaryAsync(id, page);
            return Ok(result);
        }

        // 📄 Early Day Motions
        [HttpGet("{id}/edms")]
        public async Task<IActionResult> GetEdms(int id, int? page = 0)
        {
            var result = await _service.EdmsAsync(id, page);
            return Ok(result);
        }

        // 💼 Experience
        [HttpGet("{id}/experience")]
        public async Task<IActionResult> GetExperience(int id)
        {
            var result = await _service.ExperienceAsync(id);
            return Ok(result);
        }

        // 🎯 Focus
        [HttpGet("{id}/focus")]
        public async Task<IActionResult> GetFocus(int id)
        {
            var result = await _service.FocusAsync(id);
            return Ok(result);
        }

        // 🧾 Registered Interests
        [HttpGet("{id}/interests")]
        public async Task<IActionResult> GetInterests(int id)
        {
            var result = await _service.RegisteredInterestsAsync(id, null);
            return Ok(result);
        }

        // 👥 Staff
        [HttpGet("{id}/staff")]
        public async Task<IActionResult> GetStaff(int id)
        {
            var result = await _service.Staff2Async(id);
            return Ok(result);
        }

        // 🧠 Synopsis
        [HttpGet("{id}/synopsis")]
        public async Task<IActionResult> GetSynopsis(int id)
        {
            var result = await _service.Synopsis2Async(id);
            return Ok(result);
        }

        // 🗳️ Voting
        [HttpGet("{id}/voting")]
        public async Task<IActionResult> GetVoting(int id)
        {
            var result = await _service.VotingAsync(id, House.Commons, 0);
            return Ok(result);
        }

        // ❓ Written Questions
        [HttpGet("{id}/questions")]
        public async Task<IActionResult> GetQuestions(int id)
        {
            var result = await _service.WrittenQuestionsAsync(id, 0);
            return Ok(result);
        }

        // 🧑‍⚖️ State of the Parties
        [HttpGet("state-of-the-parties")]
        public async Task<IActionResult> GetStateOfTheParties()
        {
            var result = await _service.StateOfThePartiesAsync(House.Commons, DateTimeOffset.UtcNow);
            return Ok(result);
        }

        // 👑 Lords by Type
        [HttpGet("lords-by-type")]
        public async Task<IActionResult> GetLordsByType()
        {
            var result = await _service.LordsByTypeAsync(DateTimeOffset.UtcNow);
            return Ok(result);
        }

        // 🏛️ Active Parties
        [HttpGet("active-parties")]
        public async Task<IActionResult> GetActiveParties()
        {
            var result = await _service.GetActiveAsync(House.Commons);
            return Ok(result);
        }
        [HttpGet("active-commons")]
        public async Task<IActionResult> GetAllActiveCommons()
        {
            var result = await _service.Search2Async(
                name: null,
                location: null,
                postTitle: null,
                partyId: null,
                house: House.Commons,
                constituencyId: null,
                nameStartsWith: null,
                gender: null,
                membershipStartedSince: null,
                membershipEnded_MembershipEndedSince: null,
                membershipEnded_MembershipEndReasonIds: null,
                membershipInDateRange_WasMemberOnOrAfter: null,
                membershipInDateRange_WasMemberOnOrBefore: null,
                membershipInDateRange_WasMemberOfHouse: null,
                isEligible: null,
                isCurrentMember: true,
                policyInterestId: null,
                experience: null,
                skip: 0,
                take: 20, // You can paginate or loop to get more
                cancellationToken: CancellationToken.None

            );

            return Ok(result);
        }
        [HttpGet("active-commons-view")]
        public async Task<IActionResult> GetAllActiveCommonsView()
        {
            var allMembers = new List<MemberViewModel>();
            int skip = 0;
            const int take = 20;
            bool moreResults = true;

            while (moreResults)
            {
                var result = await _service.Search2Async(
                    name: null,
                    location: null,
                    postTitle: null,
                    partyId: null,
                    house: House.Commons, // Replace with House.Commons if you rename the enum
                    constituencyId: null,
                    nameStartsWith: null,
                    gender: null,
                    membershipStartedSince: null,
                    membershipEnded_MembershipEndedSince: null,
                    membershipEnded_MembershipEndReasonIds: null,
                    membershipInDateRange_WasMemberOnOrAfter: null,
                    membershipInDateRange_WasMemberOnOrBefore: null,
                    membershipInDateRange_WasMemberOfHouse: null,
                    isEligible: null,
                    isCurrentMember: true,
                    policyInterestId: null,
                    experience: null,
                    skip: skip,
                    take: take,
                    cancellationToken: CancellationToken.None

                );

                if (result?.Items == null || result.Items.Count == 0)
                {
                    moreResults = false;
                }
                else
                {
                    allMembers.AddRange(result.Items.Select(m => new MemberViewModel
                    {
                        Id = m.Value.Id,
                        Name = m.Value.NameDisplayAs,
                        Party = m.Value.LatestParty?.Name
                    }));

                    skip += take;
                    moreResults = result.Items.Count == take;
                }
            }

            return View(allMembers);
        }
        
[HttpGet]
public async Task<IActionResult> SearchMembers(string term)
{
    var result = await _service.Search2Async(
                    name: term,
                    location: null,
                    postTitle: null,
                    partyId: null,
                    house: House.Commons, // Replace with House.Commons if you rename the enum
                    constituencyId: null,
                    nameStartsWith: null,
                    gender: null,
                    membershipStartedSince: null,
                    membershipEnded_MembershipEndedSince: null,
                    membershipEnded_MembershipEndReasonIds: null,
                    membershipInDateRange_WasMemberOnOrAfter: null,
                    membershipInDateRange_WasMemberOnOrBefore: null,
                    membershipInDateRange_WasMemberOfHouse: null,
                    isEligible: null,
                    isCurrentMember: true,
                    policyInterestId: null,
                    experience: null,
                    skip: 0,
                    take: 20,
                    cancellationToken: CancellationToken.None
    );

    var suggestions = result.Items.Select(m => new MemberViewModel
    {
        Id = m.Value.Id,
        Name = m.Value.NameDisplayAs,// + (m.Value.LatestParty != null ? $" ({m.Value.LatestParty.Name})" : ""),
        Party = m.Value.LatestParty?.Name
    });

    return Json(suggestions);
}



    }
}

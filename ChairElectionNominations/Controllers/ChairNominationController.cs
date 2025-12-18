using System.Threading.Tasks;
using ChairElections.Models;
using ChairElections.Services;
using Microsoft.AspNetCore.Mvc;
using ParliamentApi.Client;

using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Xml;


public class ChairNominationController : Controller
{
    private readonly ChairNominationService _service;
    private readonly CommitteeService _committeeService;

    private readonly MembersApiService _memberService;
    private readonly HttpClient _httpClient;


    private readonly MembersApiService _membersApiService = new MembersApiService("", new HttpClient());

    public ChairNominationController(ChairNominationService service, CommitteeService committeeService, HttpClient httpClient)
    {
        // Initialize the service with the committee service to fetch committees
        _committeeService = committeeService;
        _service = service;
        _httpClient = httpClient;
        _memberService = new MembersApiService("https://members-api.parliament.uk/", _httpClient);
    }

    public async Task<IActionResult> Index()
    {
        List<NominationViewModel> nominationDetails = await MapToViewModel();
        return View(nominationDetails);
    }


    [HttpGet("xml")]
    [Produces("application/xml")]
    public async Task<IActionResult> GetNominationsXml()
    {
        var nominations = await MapToViewModel();
        return Ok(nominations); 
    }

    public async Task<List<NominationViewModel>> MapToViewModel()
    {
        var nominations = await _service.GetAllAsync();
        var nominationDetails = new List<NominationViewModel>();
        foreach (var nomination in nominations)
        {

            var nominee = await _memberService.MembersAsync(nomination.NomineeId, null);
            var nominator = await _memberService.MembersAsync(nomination.NominatedById, null);
            var committee = await _committeeService.GetCommitteeByIdAsync(nomination.CommitteeId);
            var registeredInterest = await _service.GetRegisteredInterestByIds(nomination.NomineeId, nomination.CommitteeId);
            var statement = await _service.GetChairStatements(new ChairStatement { CommitteeId = nomination.CommitteeId, MemberId = nomination.NomineeId });
            nominationDetails.Add(new NominationViewModel
            {
                Id = nomination.Id,
                NomineeId = nomination.NomineeId,
                NomineeName = nominee?.Value.NameDisplayAs ?? "Unknown",
                NominatedById = nomination.NominatedById,
                NominatedParty = (nominator.Value as MemberApi.Models.Member).LatestParty.Name ?? "Unknown",
                NominatedByName = nominator?.Value.NameDisplayAs ?? "Unknown",
                CommitteeId = nomination.CommitteeId,
                CommitteeName = committee ?? "Unknown",
                NominationDate = nomination.NominationDate,
                Summary = statement?.ChairStatementText ??  "",
                RegisteredInterest = registeredInterest?.RegisteredInterestText,
                VoteRegisteredInterest = nomination.RegisteredInterest,// registeredInterest != null ? registeredInterest.RegisteredInterestText : "",
                NominateeParty = (nominee.Value as MemberApi.Models.Member).LatestParty.Name ?? "Unknown"
            });
        }
        return nominationDetails;
    }



    public async Task<IActionResult> Create()
    {
        var nomination = new ChairNomination
        {
            Committees = new List<KeyValuePair<int, string>>()
        };
        var committees = await _committeeService.GetAllCommitteesAsync("ACTIVE");

        nomination.Committees.AddRange(
            committees.Select(c => new KeyValuePair<int, string>(c.Id, c.Name))
        );
        return View(nomination);
        //return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ChairNomination nomination)
    {
        if (nomination.NominatedById == nomination.NomineeId)
        {
            ModelState.AddModelError("NominatedById", "You cannot nominate yourself.");
            ModelState.AddModelError("NomineeId", "You cannot nominate yourself.");
        }
        var hasAlreadyVoted = await _service.HasAlreadyVotedOffice(nomination.CommitteeId, nomination.NominatedById);
        if (hasAlreadyVoted)
        {
            ModelState.AddModelError("NomineeId", "You have already voted for this Committee Chair Elect.");
        }
        if (ModelState.IsValid)
        {
            await _service.CreateAsync(nomination);
            return RedirectToAction(nameof(Index));
        }

        nomination.Committees = new List<KeyValuePair<int, string>>();
        var committees = await _committeeService.GetAllCommitteesAsync("ACTIVE");

        nomination.Committees.AddRange(
            committees.Select(c => new KeyValuePair<int, string>(c.Id, c.Name))
        );
        if (nomination.NominatedById != 0)
        {
            MemberApi.Models.MemberItem tempName = await _memberService.MembersAsync(nomination.NominatedById, null);
            ViewData["NominatedBy"] = tempName.Value;
        }
        if (nomination.NomineeId != 0)
        {
            MemberApi.Models.MemberItem tempName = await _memberService.MembersAsync(nomination.NomineeId, null);
            ViewData["Nominee"] = tempName.Value;
        }


        return View(nomination);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var nomination = await _service.GetByIdAsync(id);
        if (nomination == null) return NotFound();
        return View(nomination);
    }

    [HttpPost, ActionName("DeleteConfirmed")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet("registered-interest")]
    public async Task<IActionResult> RegisterInterests(int MemberId, int CommitteeId)
    {
        var model = new RegisteredInterest();

        model.CommitteeId = CommitteeId;
        model.MemberId = MemberId;
        var checkModel = await _service.GetRegisteredInterest(model);
        if (checkModel != null)
        {
            model = checkModel;
        }
        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult> AddRegisterInterest(RegisteredInterest model)
    {
        if (ModelState.IsValid)
        {
            _service.SaveOrUpdateInterest(model);
        }
        else
        {
            ModelState.AddModelError("RegisteredInterestText", "Error");
            RedirectToAction("RegisterInterests", model);
        }
        return RedirectToAction("Index");//
    }
    [HttpGet("chair-statements")]
    public async Task<IActionResult> ChairStatements(int MemberId, int CommitteeId)
    {
        var model = new ChairStatement();

        model.CommitteeId = CommitteeId;
        model.MemberId = MemberId;
        var checkModel = await _service.GetChairStatements(model);
        if (checkModel != null)
        {
            model = checkModel;
        }
        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult> AddChairStatement(ChairStatement model)
    {
        if (!ModelState.IsValid)
        {
            // Return the view with validation messages so the user can fix the input
            return View("ChairStatements", model);
        }

        await _service.SaveOrUpdateChairStatement(model);
        return RedirectToAction("Index");
    }

}

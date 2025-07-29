using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChairElections.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ChairElections.Controllers;

public class CommitteeController : Controller
{
    private readonly CommitteeContext _context;

    public CommitteeController(CommitteeContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var committees = await _context.Set<Committee>().ToListAsync();
        return View(committees);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Committee committee)
    {
        committee.ChairNominations = new List<ChairNomination>();
        Console.WriteLine(committee.Name);
        if (ModelState.IsValid)
        {
            committee.DateModified = DateTime.UtcNow;
            _context.Add(committee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        else
        {
            ModelState.AddModelError("Name", "Committee name is required.");
            WriteErrors(ModelState);
        }

        return View(committee);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var committee = await _context.Set<Committee>().FindAsync(id);
        if (committee == null) return NotFound();
        return View(committee);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Committee committee)
    {
        if (ModelState.IsValid)
        {
            committee.DateModified = DateTime.UtcNow;
            _context.Update(committee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(committee);
    }
    //[HttpPost, ActionName("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var committee = await _context.Set<Committee>().FindAsync(id);
        if (committee == null) return NotFound();
        return View(committee);
    }



    [HttpPost, ActionName("DeleteConfirmed")]

    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var committee = await _context.Set<Committee>().FindAsync(id);
        if (committee != null)
        {
            _context.Remove(committee);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    public void WriteErrors(ModelStateDictionary states)
    {

        foreach (var state in states)
        {
            var key = state.Key;
            var errors = state.Value.Errors;

            foreach (var error in errors)
            {
                Console.WriteLine($"Field: {key}, Error: {error.ErrorMessage}");
            }
        }

    }
    

    [HttpGet("search")]
    public async Task<IActionResult> SearchCommittees(string term)
    {
        var results = await _context.Set<Committee>()
            .Where(c => c.Name.ToLower().Contains(term.ToLower()))
            .OrderBy(c => c.Name)
            .Select(c => new {
                label = c.Name,
                value = c.Id
            })
            .ToListAsync();

        return Ok(results);
    }


}

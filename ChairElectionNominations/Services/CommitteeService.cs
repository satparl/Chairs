using Microsoft.EntityFrameworkCore;
using ChairElections.Models;

namespace ChairElections.Services;

public class CommitteeService
{
    private readonly CommitteeContext _context;

    public CommitteeService(CommitteeContext context)
    {
        _context = context;
    }

    public async Task<List<Committee>> GetAllCommitteesAsync()
    {
        return await _context.Committees.ToListAsync();
    }

    public async Task<Committee> CreateCommitteeAsync(Committee committee)
    {
        Console.WriteLine(committee.Name);
        committee.DateModified = DateTime.UtcNow;
        _context.Add(committee);
        await _context.SaveChangesAsync();
        return committee;
    }

    public async Task<Committee> UpdateCommitteeAsync(Committee updatedCommittee)
    {
        var existing = await _context.Set<Committee>().FindAsync(updatedCommittee.Id);
        if (existing == null) return null;

        existing.Name = updatedCommittee.Name;
        existing.Status = updatedCommittee.Status;
        existing.CurrentChairId = updatedCommittee.CurrentChairId;
        existing.DateModified = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteCommitteeAsync(int id)
    {
        var committee = await _context.Set<Committee>().FindAsync(id);
        if (committee == null) return false;

        _context.Remove(committee);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<string?> GetCommitteeByIdAsync(int committeeId)
    {
        var committee = await _context.Committees.FindAsync(committeeId);
        return committee?.Name;
    }
}

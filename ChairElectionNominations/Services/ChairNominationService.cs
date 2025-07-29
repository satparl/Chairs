using ChairElections.Models;
using Microsoft.EntityFrameworkCore;

public class ChairNominationService
{
    private readonly CommitteeContext _context;

    public ChairNominationService(CommitteeContext context)
    {
        _context = context;
    }

    public async Task<List<ChairNomination>> GetAllAsync()
    {
        return await _context.ChairNominations.ToListAsync();
    }

    public async Task<ChairNomination?> GetByIdAsync(int id)
    {
        return await _context.ChairNominations.FindAsync(id);
    }

    public async Task<ChairNomination> CreateAsync(ChairNomination nomination)
    {
        nomination.NominationDate = DateTime.UtcNow;
        _context.ChairNominations.Add(nomination);
        await _context.SaveChangesAsync();
        return nomination;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var nomination = await _context.ChairNominations.FindAsync(id);
        if (nomination == null) return false;

        _context.ChairNominations.Remove(nomination);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> HasAlreadyVotedOffice(int office, int NominatedById)
    {
        return await _context.ChairNominations.AnyAsync(n => n.CommitteeId == office && n.NominatedById == NominatedById);
    }
}

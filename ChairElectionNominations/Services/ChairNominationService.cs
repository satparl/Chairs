using System.Security.Authentication.ExtendedProtection;
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
    public async Task<string?> SaveOrUpdateInterest(RegisteredInterest model)
    {
        var existingInterest = await _context.RegisteredInterests
            .FirstOrDefaultAsync(r => r.MemberId == model.MemberId && r.CommitteeId == model.CommitteeId);

        if (existingInterest != null)
        {
            // Update existing record
            existingInterest.RegisteredInterestText = model.RegisteredInterestText;
            _context.Update(existingInterest);
        }
        else
        {
            // Insert new record
            await _context.RegisteredInterests.AddAsync(model);
        }

        await _context.SaveChangesAsync();
        return model.RegisteredInterestText;
    }
    public async Task<RegisteredInterest> GetRegisteredInterest(RegisteredInterest model)
    {
        var existingInterest = await _context.RegisteredInterests
            .FirstOrDefaultAsync(r => r.MemberId == model.MemberId && r.CommitteeId == model.CommitteeId);
        return existingInterest;
        
    }

    public async Task<RegisteredInterest> GetRegisteredInterestByIds(int nomineeId, int committeeId)
    {
        var model = new RegisteredInterest();
        model.CommitteeId = committeeId;
        model.MemberId = nomineeId;
        var interest = await GetRegisteredInterest(model);
        return interest;
    }
}

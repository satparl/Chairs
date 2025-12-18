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
    public async Task<ChairStatement> GetChairStatements(ChairStatement model, bool All=false)
    {

        var existingStatement = await _context.ChairStatements
            .FirstOrDefaultAsync(r => r.MemberId == model.MemberId && r.CommitteeId == model.CommitteeId);
        return existingStatement;

    }

    public async Task<List<ChairStatement>> GetAllChairStatements(int committeeId=0)
    {
        if (committeeId == 0)
        {
            return await _context.ChairStatements.ToListAsync();
        }
        else
        {
        var statements = await _context.ChairStatements
            .Where(r => r.CommitteeId == committeeId)
            .ToListAsync();
            return statements;
        }
    }
    public async Task<string?> SaveOrUpdateChairStatement(ChairStatement model)
    {
        var existingStatement = await _context.ChairStatements
            .FirstOrDefaultAsync(r => r.MemberId == model.MemberId && r.CommitteeId == model.CommitteeId);

        if (existingStatement != null)
        {
            // Update existing record
            existingStatement.ChairStatementText = model.ChairStatementText;
            _context.Update(existingStatement);
        }
        else
        {
            // Insert new record
            await _context.ChairStatements.AddAsync(model);
        }

        await _context.SaveChangesAsync();
        return model.ChairStatementText;
    }
}

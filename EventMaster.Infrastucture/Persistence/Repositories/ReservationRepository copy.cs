using EventMaster.Application.Common.Interfaces.Persistence;
using EventMaster.Domain.Reservations;
using Microsoft.EntityFrameworkCore;

namespace EventMaster.Infrastructure.Persistence.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly EventMasterDbContext _dbContext;

    public ReservationRepository(EventMasterDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Reservation>> LoadAsync(int GuestId)
    {
        return await _dbContext.Reservations
        .Where(x => x.GuestId == GuestId)
        .ToListAsync();
    }

    public async Task<Reservation?> FetchAsync(int id)
    {
        return await _dbContext.Reservations.FindAsync(id);
    }

    public async Task<Reservation?> AddAsync(Reservation reservation)
    {
        var createdReservation = await _dbContext.Reservations.AddAsync(reservation);
        await _dbContext.SaveChangesAsync();

        return createdReservation.Entity;
    }

    public async Task UpdateAsync(Reservation reservation)
    {
        _dbContext.Reservations.Update(reservation);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Reservation reservation)
    {
        _dbContext.Reservations.Remove(reservation);
        await _dbContext.SaveChangesAsync();
    }

}
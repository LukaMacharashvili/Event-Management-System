using EventMaster.Domain.Reservations;

namespace EventMaster.Application.Common.Interfaces.Persistence;

public interface IReservationRepository
{
    Task<List<Reservation>> LoadAsync(int GuestId);
    Task<Reservation?> FetchAsync(int id);
    Task<Reservation?> AddAsync(Reservation reservation);
    Task UpdateAsync(Reservation reservation);
    Task DeleteAsync(Reservation reservation);
}
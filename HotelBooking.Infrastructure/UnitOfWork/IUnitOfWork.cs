namespace HotelBooking.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        void Dispose();
    }
}

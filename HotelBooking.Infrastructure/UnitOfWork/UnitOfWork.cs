using HotelBooking.Infrastructure.Persistence;

namespace HotelBooking.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed = false;
        private readonly HotelBookingContext _dbContext;

        public UnitOfWork(HotelBookingContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

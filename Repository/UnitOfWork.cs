using Project_PRN221_BookingFields.Data;

namespace Project_PRN221_BookingFields.Repository
{
    public class UnitOfWork:IUnitOfWork,IDisposable
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        private bool dispose = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }

        private void Dispose(bool disposing)
        {
            if (!this.dispose)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.dispose = true;
        }

        public IGenericRepository<T> GenericRepository<T>() where T : class
        {
            IGenericRepository<T> repo = new GenericRepository<T>(_context);
            return repo;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

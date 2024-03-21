namespace Project_PRN221_BookingFields.Repository
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GenericRepository<T>() where T: class;
        void Save();
    }
}

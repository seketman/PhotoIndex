namespace PhotoIndex.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}

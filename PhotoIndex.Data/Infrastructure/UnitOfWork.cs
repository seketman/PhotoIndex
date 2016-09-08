namespace PhotoIndex.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private PhotoIndexEntities dbContext;
        private readonly IDatabaseFactory dbFactory;

        protected PhotoIndexEntities DbContext
        {
            get
            {
                return dbContext ?? dbFactory.Get();
            }
        }

        public UnitOfWork(IDatabaseFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }
    }
}

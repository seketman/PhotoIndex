using PhotoIndex.Data;
using PhotoIndex.Model;

namespace PhotoIndex.Data.Infrastructure 
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private PhotoIndexEntities dataContext;
        public PhotoIndexEntities Get()
        {
            return dataContext ?? (dataContext = new PhotoIndexEntities());
        }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}

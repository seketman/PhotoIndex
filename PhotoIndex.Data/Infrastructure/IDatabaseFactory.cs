using System;

namespace PhotoIndex.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        PhotoIndexEntities Get();
    }
}

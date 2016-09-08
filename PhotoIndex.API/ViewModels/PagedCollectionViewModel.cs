using System.Collections.Generic;

namespace PhotoIndex.API.ViewModels
{
    public class PagedCollectionViewModel<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int TotalCount { get; set; }
    }
}
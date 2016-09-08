using System;

namespace PhotoIndex.API.ViewModels
{
    public class ResourceActivityViewModel
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public DateTime ActivityDate { get; set; }
        public string ActivityDateString { get; set; }
    }
}
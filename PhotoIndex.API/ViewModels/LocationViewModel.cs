using System;

namespace PhotoIndex.API.ViewModels
{
    public class LocationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
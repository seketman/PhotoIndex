using System;
using System.Collections.Generic;

namespace PhotoIndex.API.ViewModels
{
    public class PhotoViewModel
    {
        public int Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string UserFirstName { get; set; }

        //public virtual IEnumerable<FaceViewModel> Faces { get; set; }
        //public virtual IEnumerable<CategoryViewModel> Categories { get; set; }
        public virtual IEnumerable<LocationViewModel> Locations { get; set; }
    }
}
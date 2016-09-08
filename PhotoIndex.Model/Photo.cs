using System;
using System.Collections.Generic;

namespace PhotoIndex.Model
{
    public class Photo
    {
        public Photo()
        {
            this.CreatedOn = DateTimeOffset.UtcNow;

            this.Faces = new HashSet<Face>();
            this.Categories = new HashSet<Category>();
            this.Locations = new HashSet<Location>();
        }

        public int Id { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public ApplicationUser User { get; set; }

        public virtual ICollection<Face> Faces { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }
}

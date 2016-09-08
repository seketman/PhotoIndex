using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhotoIndex.Model
{
    public class Location
    {
        public Location()
        {
            this.CreatedOn = DateTimeOffset.UtcNow;

            this.Photos = new HashSet<Photo>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}

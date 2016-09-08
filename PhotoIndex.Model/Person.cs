using System;
using System.Collections.Generic;

namespace PhotoIndex.Model
{
    public class Person
    {
        public Person()
        {
            CreatedOn = DateTimeOffset.UtcNow;

            this.Faces = new HashSet<Face>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Face> Faces { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}

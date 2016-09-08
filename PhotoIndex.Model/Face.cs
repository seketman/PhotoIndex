using System;

namespace PhotoIndex.Model
{
    public class Face
    {
        public Face()
        {
            Found = DateTimeOffset.UtcNow;
        }

        public int Id { get; set; }
        public virtual Photo Photo { get; set; }

        //  Face rectangle
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public DateTimeOffset Found { get; set; }
        public DateTimeOffset PersonIdentified { get; set; }
        public DateTimeOffset ConfirmedOn { get; set; }

        public virtual Person Person { get; set; }
    }
}

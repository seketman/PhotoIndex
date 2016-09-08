using System.Data.Entity.ModelConfiguration;

using PhotoIndex.Model;

namespace PhotoIndex.Data.Configurations
{
    internal class ResourceConfiguration : EntityTypeConfiguration<Resource>
    {
        public ResourceConfiguration()
        {
            HasRequired(r => r.Location).WithMany().HasForeignKey(r => r.LocationId).WillCascadeOnDelete(true);
            HasRequired(r => r.User).WithMany().HasForeignKey(r => r.UserId).WillCascadeOnDelete(true);
        }
    }
}

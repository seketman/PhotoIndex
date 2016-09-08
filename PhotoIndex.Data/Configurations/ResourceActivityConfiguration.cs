using System.Data.Entity.ModelConfiguration;

using PhotoIndex.Model;

namespace PhotoIndex.Data.Configurations
{
    internal class ResourceActivityConfiguration : EntityTypeConfiguration<ResourceActivity>
    {
        public ResourceActivityConfiguration()
        {
            HasRequired(a => a.Resource).WithMany(r => r.Activities).HasForeignKey(a => a.ResourceId).WillCascadeOnDelete(true);
        }
    }
}

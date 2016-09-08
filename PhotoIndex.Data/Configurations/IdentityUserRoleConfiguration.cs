using System.Data.Entity.ModelConfiguration;

using Microsoft.AspNet.Identity.EntityFramework;

namespace PhotoIndex.Data.Configurations
{
    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentityUserRoleConfiguration()
        {
            HasKey(role => new { role.RoleId, role.UserId });
            //HasRequired(role => role.User).WithMany().HasForeignKey(role => role.UserId);
        }
    }
}

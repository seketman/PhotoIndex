using System.Data.Entity.ModelConfiguration;

using Microsoft.AspNet.Identity.EntityFramework;

namespace PhotoIndex.Data.Configurations
{
    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public IdentityUserLoginConfiguration()
        {
            HasKey(login => new { login.UserId, login.LoginProvider, login.ProviderKey });
            //HasRequired(login => login.UserId).WithMany().HasForeignKey(login => login.UserId);
        }
    }
}

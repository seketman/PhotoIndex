using System;
using System.Data.Entity;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using PhotoIndex.Model;
using PhotoIndex.Data.Configurations;

namespace PhotoIndex.Data
{
    public class PhotoIndexEntities : IdentityDbContext<ApplicationUser>
    {
        public PhotoIndexEntities()
            : base("PhotoIndexEntities")
        {
        }

        public DbSet<Resource> Resources { get; set; }
        public DbSet<ResourceActivity> Activities { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Face> Faces { get; set; }
        public DbSet<Person> People { get; set; }

        //public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new LocationConfiguration());
            modelBuilder.Configurations.Add(new ResourceConfiguration());
            modelBuilder.Configurations.Add(new ResourceActivityConfiguration());

            //Configurations Auto generated tables for IdentityDbContext.
            modelBuilder.Configurations.Add(new IdentityUserRoleConfiguration());
            modelBuilder.Configurations.Add(new IdentityUserLoginConfiguration());
        }
    }

    public class PhotoIndexDbInitializer : DropCreateDatabaseIfModelChanges<PhotoIndexEntities>
    {
        protected override void Seed(PhotoIndexEntities context)
        {
            try
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
                {
                    AllowOnlyAlphanumericUserNames = false
                };
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                if (!roleManager.RoleExists("Admin"))
                {
                    roleManager.Create(new IdentityRole("Admin"));
                }

                if (!roleManager.RoleExists("Member"))
                {
                    roleManager.Create(new IdentityRole("Member"));
                }

                var user = new ApplicationUser();
                user.FirstName = "Admin";
                user.LastName = "PhotoIndex";
                user.Email = "admin@photoindex.com";
                user.UserName = "admin@photoindex.com";

                var userResult = userManager.Create(user, "PhotoIndex");
                if (userResult.Succeeded)
                {
                    userManager.AddToRole<ApplicationUser>(user.Id, "Admin");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            //context.Users.Add(new ApplicationUser { Email = "abc@yahoo.com", Password = "PhotoIndex" });
            //context.SaveChanges();           
        }
    }
}

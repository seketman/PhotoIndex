using System.Web.Http;

using Autofac;
using Autofac.Integration.WebApi;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using PhotoIndex.API.Mappers;
using PhotoIndex.Data;
using PhotoIndex.Data.Infrastructure;
using PhotoIndex.Data.Repositories;
using PhotoIndex.Model;
using PhotoIndex.Service;

namespace PhotoIndex.API.App_Start
{
    public static class Bootstrapper
    {
        public static void Configure()
        {
            ConfigureAutofacContainer();
            AutoMapperConfiguration.Configure();
        }

        public static void ConfigureAutofacContainer()
        {
            var webApiContainerBuilder = new ContainerBuilder();
            ConfigureWebApiContainer(webApiContainerBuilder);
        }

        public static void ConfigureWebApiContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().AsImplementedInterfaces().InstancePerApiRequest();
            containerBuilder.RegisterType<UnitOfWork>().As<IUnitOfWork>().AsImplementedInterfaces().InstancePerApiRequest();
            containerBuilder.RegisterType<ResourceRepository>().As<IResourceRepository>().AsImplementedInterfaces().InstancePerApiRequest();
            containerBuilder.RegisterType<ResourceActivityRepository>().As<IResourceActivityRepository>().InstancePerApiRequest();
            containerBuilder.RegisterType<LocationRepository>().As<ILocationRepository>().InstancePerApiRequest();
            containerBuilder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerApiRequest();
            containerBuilder.RegisterType<ResourceService>().As<IResourceService>().InstancePerApiRequest();
            containerBuilder.RegisterType<ResourceActivityService>().As<IResourceActivityService>().InstancePerApiRequest();
            containerBuilder.RegisterType<LocationService>().As<ILocationService>().InstancePerApiRequest();
            containerBuilder.RegisterType<UserService>().As<IUserService>().InstancePerApiRequest();

            containerBuilder.Register(c => new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new PhotoIndexEntities())
            {
                /*Avoids UserStore invoking SaveChanges on every actions.*/
                //AutoSaveChanges = false
            })).As<UserManager<ApplicationUser>>().InstancePerApiRequest();

            containerBuilder.RegisterApiControllers(System.Reflection.Assembly.GetExecutingAssembly());
            IContainer container = containerBuilder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
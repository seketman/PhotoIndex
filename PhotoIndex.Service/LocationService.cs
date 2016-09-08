using System.Collections.Generic;

using PhotoIndex.Data.Infrastructure;
using PhotoIndex.Data.Repositories;
using PhotoIndex.Model;

namespace PhotoIndex.Service
{
    public class LocationService : ILocationService
    {
        private ILocationRepository repository;
        private IResourceRepository resourceRepository;
        private IUnitOfWork unitOfWork;

        public LocationService(ILocationRepository repository, IResourceRepository resourceRepository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.resourceRepository = resourceRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Location> GetLocations()
        {
            return repository.GetAll();
        }

        public Location AddLocation(Location location)
        {
            repository.Add(location);
            SaveChanges();
            return location;
        }

        public Location GetLocationById(int id)
        {
            return repository.GetById(id);
        }

        public Location UpdateLoaction(Location location)
        {
            repository.Update(location);
            SaveChanges();
            return location;
        }

        public void DeleteLocation(int id)
        {
            var location = repository.GetById(id);
            var resources = resourceRepository.GetMany(r => r.LocationId == id);

            foreach (var item in resources)
            {
                resourceRepository.Delete(item);
            }
            repository.Delete(location);
            SaveChanges();
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }
    }

    public interface ILocationService
    {
        IEnumerable<Location> GetLocations();
        Location AddLocation(Location location);
        Location GetLocationById(int id);
        Location UpdateLoaction(Location location);
        void DeleteLocation(int locationId);
    }
}

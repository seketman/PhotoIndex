using PhotoIndex.Data.Infrastructure;
using PhotoIndex.Data.Repositories;
using PhotoIndex.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoIndex.Service
{
    public class PhotoService : IPhotoService
    {
        private IPhotoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public PhotoService(IPhotoRepository repository, IUnitOfWork unitOfWork)
        {
            this._repository = repository;
            this._unitOfWork = unitOfWork;
        }

        public Photo Add(Photo photo)
        {
            _repository.Add(photo);
            this.SaveChanges();

            return photo;
        }

        public Photo Update(Photo photo)
        {
            try
            {
                _repository.Update(photo);
                this.SaveChanges();

                return photo;
            }
            catch (Exception ex)
            {
                //  TODO: Add log
                throw ex;
            }
        }

        public void Delete(int id)
        {
            var photo = _repository.GetById(id);
            _repository.Delete(photo);
            this.SaveChanges();
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

        public Photo GetById(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Photo> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Photo> GetAllByUserId(string userId)
        {
            return _repository.GetMany(p => p.User.Id == userId);
        }

        public IEnumerable<Photo> GetTopByUserId(string userId, int count)
        {
            return _repository.Query(p => p.User.Id == userId).OrderByDescending(p => p.CreatedOn).Take(count);
        }

        public IEnumerable<Photo> GetPagedByUserId(string userId, int count, int page, ref int totalCount)
        {
            var query = _repository.Query(p => p.User.Id == userId).OrderByDescending(p => p.CreatedOn);
            totalCount = query.Count();

            return query.Skip((page - 1) * count).Take(count); ;
        }
    }

    public interface IPhotoService
    {
        Photo Add(Photo photo);

        Photo Update(Photo photo);

        void Delete(int id);

        Photo GetById(int id);

        IEnumerable<Photo> GetAll();

        IEnumerable<Photo> GetAllByUserId(string userId);

        IEnumerable<Photo> GetTopByUserId(string userId, int count);

        IEnumerable<Photo> GetPagedByUserId(string userId, int count, int page, ref int totalCount);
    }
}

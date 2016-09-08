using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using AutoMapper;

using Microsoft.AspNet.Identity;

using PhotoIndex.API.ViewModels;
using PhotoIndex.Model;
using PhotoIndex.Service;

namespace PhotoIndex.API.Controllers
{
    public class PhotosController : ApiController
    {
        private readonly IPhotoService _photoService;
        private readonly UserManager<ApplicationUser> _userManager;

        public PhotosController(IPhotoService photoService, UserManager<ApplicationUser> userManager)
        {
            this._photoService = photoService;
            this._userManager = userManager;
        }

        // GET: api/Photos
        public IHttpActionResult GetPhotos()
        {
            string userId = RequestContext.Principal.Identity.GetUserId();
            var photos = _photoService.GetAllByUserId(userId).ToList();

            IList<PhotoViewModel> viewModel = new List<PhotoViewModel>();
            Mapper.Map(photos, viewModel);

            return Ok(viewModel);
        }

        public IHttpActionResult GetPhotos(int count, int page)
        {
            string userId = RequestContext.Principal.Identity.GetUserId();

            int totalCount = 0;
            var photos = _photoService.GetPagedByUserId(userId, count, page, ref totalCount).ToList();

            IEnumerable<PhotoViewModel> viewModels = new List<PhotoViewModel>();
            Mapper.Map(photos, viewModels);
            PagedCollectionViewModel<PhotoViewModel> viewModel = 
                new PagedCollectionViewModel<PhotoViewModel> { Data = viewModels, TotalCount = totalCount };

            return Ok(viewModel);
        }

        public IHttpActionResult GetTopPhotos(int count)
        {
            string userId = RequestContext.Principal.Identity.GetUserId();
            var photos = _photoService.GetTopByUserId(userId, count);

            IList<PhotoViewModel> viewModel = new List<PhotoViewModel>();
            Mapper.Map(photos, viewModel);

            return Ok(viewModel);
        }

        public IHttpActionResult GetPhotoById(int id)
        {
            var photo = _photoService.GetById(id);
            if (photo.User.Id != RequestContext.Principal.Identity.GetUserId())
            {
                return Unauthorized();
            }

            var viewModel = new ResourceViewModel();
            Mapper.Map(photo, viewModel);

            return Ok(viewModel);
        }

        // POST: api/Photos
        public IHttpActionResult PostPhoto(PhotoViewModel photoViewModel)
        {
            var photo = new Photo();
            Mapper.Map(photoViewModel, photo);
            photo.User = _userManager.FindByName(RequestContext.Principal.Identity.Name);

            photo = _photoService.Add(photo);
            photoViewModel.Id = photo.Id;

            return Created(Url.Link("DefaultApi", new { controller = "Photos", id = photoViewModel.Id }), photoViewModel);
        }

        // PUT: api/Photos
        public IHttpActionResult PutPhoto(int id, PhotoViewModel photoViewModel)
        {
            var photo = _photoService.GetById(id);
            if (photo.User.Id != RequestContext.Principal.Identity.GetUserId())
            {
                return Unauthorized();
            }

            photoViewModel.Id = id;
            Mapper.Map(photoViewModel, photo);
            _photoService.Update(photo);

            return Ok(photoViewModel);
        }

        // DELETE: api/Photos/5
        public IHttpActionResult DeletePhoto(int id)
        {
            var photo = _photoService.GetById(id);
            if (photo.User.Id != RequestContext.Principal.Identity.GetUserId())
            {
                return Unauthorized();
            }

            _photoService.Delete(id);
            return Ok();
        }
    }
}
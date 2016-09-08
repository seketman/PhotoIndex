using System;
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
    public class ResourcesController : ApiController
    {
        private readonly IResourceService _resourceService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ResourcesController(IResourceService resourceService, UserManager<ApplicationUser> userManager)
        {
            this._resourceService = resourceService;
            this._userManager = userManager;
        }

        public IHttpActionResult Get()
        {
            string userEmail = RequestContext.Principal.Identity.Name;
            var user = _userManager.FindByName(userEmail);
            var resources = _resourceService.GetAllResourcesByUserId(user.Id).ToList();
            IList<ResourceViewModel> viewModel = new List<ResourceViewModel>();
            Mapper.Map(resources, viewModel);
            return Ok(viewModel);
        }

        public IHttpActionResult Get(int count, int page, string sortField, string sortOrder)
        {
            string userEmail = RequestContext.Principal.Identity.Name;
            var user = _userManager.FindByName(userEmail);

            int totalCount = 0;
            var resources = _resourceService.GetPagedResourcesByUserId(user.Id, count, page, sortField, sortOrder, ref totalCount).ToList();
            IEnumerable<ResourceViewModel> resourceViewModels = new List<ResourceViewModel>();
            Mapper.Map(resources, resourceViewModels);
            PagedCollectionViewModel<ResourceViewModel> viewModel = new PagedCollectionViewModel<ResourceViewModel> { Data = resourceViewModels, TotalCount = totalCount };

            return Ok(viewModel);
        }

        public IHttpActionResult GetTopFiveResources(int count)
        {
            string userEmail = RequestContext.Principal.Identity.Name;
            var user = _userManager.FindByName(userEmail);

            IList<ResourceViewModel> viewModel = new List<ResourceViewModel>();
            var resources = _resourceService.GetTopFiveResourcesByUserId(user.Id);
            Mapper.Map(resources, viewModel);
            return Ok(viewModel);
        }

        public IHttpActionResult GetResourceById(int id)
        {
            Resource resource = _resourceService.GetResourceById(id);
            var viewModel = new ResourceViewModel();
            Mapper.Map(resource, viewModel);
            return Ok(viewModel);
        }

        public IHttpActionResult PostResource(ResourceViewModel resourceViewModel)
        {
            Resource resource = new Resource();
            Mapper.Map(resourceViewModel, resource);
            resource.CreatedOn = DateTime.Now;
            resource.UserId = _userManager.FindByName(RequestContext.Principal.Identity.Name).Id;

            resource = _resourceService.AddResource(resource);
            resourceViewModel.Id = resource.Id;
            return Created(Url.Link("DefaultApi", new { controller = "Resources", id = resourceViewModel.Id }), resourceViewModel);
        }

        public IHttpActionResult PutResource(int id, ResourceViewModel resourceViewModel)
        {
            resourceViewModel.Id = id;
            var resource = _resourceService.GetResourceById(id);
            Mapper.Map(resourceViewModel, resource);
            _resourceService.UpdateResource(resource);
            return Ok(resourceViewModel);
        }

        public IHttpActionResult DeleteResource(int id)
        {
            _resourceService.DeleteResource(id);
            return Ok();
        }
    }
}
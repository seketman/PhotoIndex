using System.Collections.Generic;
using System.Web.Http;

using AutoMapper;

using PhotoIndex.API.ViewModels;
using PhotoIndex.Model;
using PhotoIndex.Service;

namespace PhotoIndex.API.Controllers
{
    public class ResourceActivitiesController : ApiController
    {
        private readonly IResourceActivityService activityService;

        public ResourceActivitiesController(IResourceActivityService activityService)
        {
            this.activityService = activityService;
        }

        [Route("api/Resources/{resourceId}/Activities")]
        public IHttpActionResult Get(int resourceId)
        {
            var activities = activityService.GetActivitiesByResourceId(resourceId);
            IList<ResourceActivityViewModel> activityViewModel = new List<ResourceActivityViewModel>();
            Mapper.Map(activities, activityViewModel);
            return Ok(activityViewModel);
        }

        [Route("api/Resources/{resourceId}/Activities")]
        public IHttpActionResult Post(int resourceId, ResourceActivityViewModel activity)
        {
            var entity = new ResourceActivity();
            Mapper.Map(activity, entity);
            activityService.AddResourceActivity(entity);
            activity.Id = entity.Id;
            return Created(Url.Link("DefaultApi", new { controller = "ResourceActivities", id = activity.Id }), activity);
        }

        [Route("api/Resources/{resourceId}/Activities/{id}")]
        public IHttpActionResult Delete(int id)
        {
            activityService.DeleteActivity(id);
            return Ok();
        }
    }
}
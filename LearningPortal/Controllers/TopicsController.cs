using LearningPortal.Models;
using Microsoft.AspNet.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace LearningPortal.Controllers
{
    public class TopicsController : ODataController
    {
        LearningPortalContext db = new LearningPortalContext();

        [EnableQuery]
        public IQueryable<Topic> Get()
        {
            return db.Topics;
        }
        
        [EnableQuery]
        public SingleResult<Topic> Get([FromODataUri] int key)
        {
            IQueryable<Topic> result = db.Topics.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(Topic topic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Topics.Add(topic);
            await db.SaveChangesAsync();
            return Created(topic);
        }

        private bool TopicExists(int key)
        {
            return db.Topics.Any(p => p.Id == key);
        }
        
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
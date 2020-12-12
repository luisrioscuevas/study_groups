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
    public class LessonsController : ODataController
    {
        LearningPortalContext db = new LearningPortalContext();

        [EnableQuery]
        public IQueryable<Lesson> Get()
        {
            return db.Lessons;
        }

        [EnableQuery]
        public SingleResult<Lesson> Get([FromODataUri] int key)
        {
            IQueryable<Lesson> result = db.Lessons.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(Lesson lesson)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Lessons.Add(lesson);
            await db.SaveChangesAsync();
            return Created(lesson);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
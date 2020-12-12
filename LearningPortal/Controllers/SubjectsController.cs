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
    public class SubjectsController : ODataController
    {
        LearningPortalContext db = new LearningPortalContext();

        [EnableQuery]
        public IQueryable<Subject> Get()
        {
            return db.Subjects;
        }
        
        [EnableQuery]
        public SingleResult<Subject> Get([FromODataUri] int key)
        {
            IQueryable<Subject> result = db.Subjects.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(Subject subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Subjects.Add(subject);
            await db.SaveChangesAsync();
            return Created(subject);
        }

        private bool SubjectExists(int key)
        {
            return db.Subjects.Any(p => p.Id == key);
        }
        
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
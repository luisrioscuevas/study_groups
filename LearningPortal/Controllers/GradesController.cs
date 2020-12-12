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
    public class GradesController : ODataController
    {
        LearningPortalContext db = new LearningPortalContext();

        [EnableQuery]
        public IQueryable<Grade> Get()
        {
            return db.Grades;
        }
        
        [EnableQuery]
        public SingleResult<Grade> Get([FromODataUri] int key)
        {
            IQueryable<Grade> result = db.Grades.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(Grade grade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Grades.Add(grade);
            await db.SaveChangesAsync();
            return Created(grade);
        }

        private bool GradeExists(int key)
        {
            return db.Grades.Any(p => p.Id == key);
        }
        
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pgEfCore.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace pgEfCore.Controllers
{
    [Route("api/[controller]")]
    public class SubjectsController : Controller
    {
        private CalCalcDbContext _dbContext;

        public SubjectsController(CalCalcDbContext context)
        {
            _dbContext = context;
        }


        // GET: api/values
        [HttpGet]
        public IEnumerable<Subject> Get()
        {
            return _dbContext.Subject.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var subject = _dbContext.Subject.Where(s => s.Id == id).FirstOrDefault();
            return Json(subject);
        }

        // POST api/
        [HttpPost]
        public JsonResult Post([FromBody]Subject subject)
        {
            if (subject != null)
            {
                if (ModelState.IsValid)
                {
                    _dbContext.Entry(subject).State = EntityState.Added;
                    _dbContext.SaveChanges();
                    return Json(subject);
                }
            }
            return Json("Not saved");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]Subject subject)
        {

            _dbContext.Entry(subject).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return Json(subject);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var subject = _dbContext.Subject.Where(s => s.Id == id).FirstOrDefault();
            _dbContext.Subject.Remove(subject);
            _dbContext.SaveChanges();
        }
    }
}

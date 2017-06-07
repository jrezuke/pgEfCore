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
    public class SitesController : Controller
    {
        private CalCalcDbContext _dbContext;

        public SitesController(CalCalcDbContext context)
        {
            _dbContext = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Site> Get()
        {
            return _dbContext.Site.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var site = _dbContext.Site.Where(s => s.Id == id).FirstOrDefault();
            return Json(site);
        }

        // POST api/sites
        [HttpPost]
        public JsonResult Post([FromBody]Site site)
        {
            if (site != null)
            {
                if (ModelState.IsValid)
                {
                    _dbContext.Entry(site).State = EntityState.Added;
                    _dbContext.SaveChanges();
                    return Json(site);
                }
            }
            return Json("Not saved");

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody]Site site)
        {
            _dbContext.Entry(site).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return Json(site);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var site = _dbContext.Site.Where(s => s.Id == id).FirstOrDefault();
            _dbContext.Site.Remove(site);
            _dbContext.SaveChanges();
        }
    }
}

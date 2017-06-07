using pgEfCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace pgEfCore.Controllers
{
    [Route("api/[controller]")]
    public class CalEntries : Controller
    {
        private CalCalcDbContext _dbContext;

        public CalEntries(CalCalcDbContext context)
        {
            _dbContext = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<CalEntry> Get()
        {
            return _dbContext.CalEntry.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody] Models.CalEntry entry)
        {
            if(entry != null)
            {
                if (ModelState.IsValid)
                {
                    _dbContext.Entry(entry).State = EntityState.Added;
                    _dbContext.SaveChanges();
                    return Json(entry);
                }
            }
            return Json("Not saved");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

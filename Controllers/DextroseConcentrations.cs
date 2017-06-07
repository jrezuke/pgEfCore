using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pgEfCore.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace pgEfCore.Controllers
{
    [Route("api/[controller]")]
    public class DextroseConcentrationsController : Controller
    {
        private CalCalcDbContext _dbContext;

        public DextroseConcentrationsController(CalCalcDbContext context)
        {
            _dbContext = context;
        }
        // GET: /<controller>/
        public IEnumerable<DextroseConcentration> Get()
        {
            return _dbContext.DextroseConcentration.ToList();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RenderApi.Models;

namespace RenderApi.Controllers
{
    [Route("cars")]
    [ApiController]
    public class AutoController : ControllerBase
    {
        private readonly AutotraderContext autotraderContext;

        public AutoController(AutotraderContext autotraderContext)
        {
            this.autotraderContext = autotraderContext;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCar()
        {
            return Ok(await autotraderContext.Cars.ToListAsync());
        }
    }
}

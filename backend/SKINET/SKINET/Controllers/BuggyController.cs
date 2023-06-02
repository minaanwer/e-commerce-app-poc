using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace SKINET.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;

        public BuggyController(StoreContext context) {
            this._context = context;
        }   



        [HttpGet("notfound")]
        public ActionResult getNotFound()
        {
            return Ok();
        }

        
    }
}

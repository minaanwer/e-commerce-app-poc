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
        public ActionResult GetNotFoundRequest()
        {
            var thing = _context.Products.Find(44);
            if(thing == null)
            {
                return NotFound(new Error.ApiResponse(404));
            }

            return Ok();
        }


        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var thing = _context.Products.Find(44);
            thing.ToString(); //this code will generate server error

            return Ok();
        }


    }
}

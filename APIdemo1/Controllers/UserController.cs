using APIdemo1.BAL;
using APIdemo1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;

namespace APIdemo1.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController] // Add this attribute to make it an ApiController
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            User_BALBase bal = new User_BALBase();
            List<UserModel> per = bal.Selectall();
            Dictionary<string,dynamic > data = new Dictionary<string,dynamic>();
            if(per.Count > 0 && per != null)
            {
                data.Add("status", true);
                data.Add("message", "data not found");
                data.Add("data", per);
                return Ok(data);
            }
            else
            {
                data.Add("status", false);
                data.Add("message", "data not found");
                data.Add("data", null);
                return NotFound(data);

            }
            
        }

        [HttpGet("{PersonID}")]

        public IActionResult Getbyid(int PersonID)
        {
            User_BALBase bal = new User_BALBase();
            UserModel user = bal.SellectByID(PersonID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (user.PersonID != 0)
            {
                response.Add("status", true);
                response.Add("message", "data found");
                response.Add("data", user);
                return Ok(response);

            }
            else
            {
                response.Add("status", false);
                response.Add("message", "data not found");
                response.Add("data", null);
                return NotFound(response);

            }

        }

        [HttpDelete]
        public IActionResult DeleteById(int userid)
        {

            User_BALBase bal = new User_BALBase();
            bool IsSuccess = bal.DeleteById(userid);
            Dictionary<string, dynamic> data = new Dictionary<string, dynamic>();

            if (IsSuccess)
            {
                data.Add("status", true);
                data.Add("message", "data found");
                return Ok(data);
            }
            else
            {
                data.Add("status", false);
                data.Add("message", "data not found");
                return NotFound(data);

            }
        }
    }
}

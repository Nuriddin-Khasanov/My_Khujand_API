using Bee.MySQL;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace My_Khujand_API.Controllers
{

    [ApiController]
    [Route("/categories")]
    public class Categories:Controller
    {
        public Categories()
        {
            MySQL.connectionString = "server=localhost;userId=root;port=3306;password=;database=my_khujand;Charset=utf8mb4";
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var result = MySQL.select("select * from category");

            if(result.execute && result.data != null)
            {
                return Ok(new
                {
                    code = 1,
                    message = "Ушпешно прочитан!",
                    data = result.data
                });
            }

            return Ok(new
            {
                code = 0,
                message = result.message,
                data = new { }
            });
        }

    }
}

using Bee.MySQL;
using Bee.MySQL.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace My_Khujand_API.Controllers
{
    public class test : Controller
    {
        public test()
        {
            MySQL.connectionString = "server=localhost;userId=root;port=3306;password=;database=my_khujand;Charset=utf8mb4";
        }

        [HttpGet("/test")]
        public IActionResult Test()
        {
            try
            {
                Select a = MySQL.select("SELECT * FROM place");

                if(a.execute && a.data != null)
                {
                    return Ok(new
                    {
                        code = 1,
                        message = "Успешно прочитано",
                        date = a.data
                    });
                }

                return Ok(new
                {
                    code = 0,
                    message = a.message,
                    date = new { }
                });
            }
            catch (Exception error)
            {
                return Ok(new
                {
                    code = 0,
                    message = error.Message,
                    date = new { }
                });
            }
        }

        /*
        [HttpPost("/cgange_data_place")]
        public IActionResult CgangeDataPlace([FromQuery] Models.Place model)
        {
            try
            {
                Dictionary<string, object> v = new Dictionary<string, object>
                {
                    {"@id", model.Id},
                    {"@NAME", model.Name }
                };

                var a = MySQL.update("update place set NAME = @NAME WHERE id = @id", v);

                if (a.execute && a.affectedRowCount > 0)
                {
                    return Ok(new
                    {
                        code = 1,
                        message = "Успешно изменено",
                    });
                }

                return Ok(new
                {
                    code = 0,
                    message = a.message,
                });

            }
            catch (Exception error)
            {
                return Ok(new
                {
                    code = 0,
                    message = error.Message,
                    date = new { }
                });
            }
        }*/
    }
}

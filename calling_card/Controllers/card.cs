using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace calling_card{
    public class card : Controller{
        [HttpGet]
        [Route("{firstname}/{lastname}/{age}/{favoritecolor}")]
        public JsonResult ShowInfo(string firstname, string lastname, int age, string favoritecolor){
            var stuff = new {
                FirstName = firstname,
                LastName = lastname,
                Age = age,
                Favoritecolor = favoritecolor
            };
            return Json(stuff);
        }
    }
}
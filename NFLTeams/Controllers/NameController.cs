using Microsoft.AspNetCore.Mvc;
using NFLTeams.Models;

namespace NFLTeams.Controllers
{
    public class NameController : Controller
    {
        public NameController(){}


        public IActionResult Index(){
            var session = new NFLSession(HttpContext.Session);

            var sessionModel = new TeamListViewModel
            {
                ActiveConf = session.GetActiveConf(),
                ActiveDiv = session.GetActiveDiv(),
                Teams = session.GetMyTeams(),
                UserName = session.GetName()
            };

            return View(sessionModel);
        }


        public RedirectToActionResult Change(TeamListViewModel sessionModel){
            var session = new NFLSession(HttpContext.Session);
           
            session.SetName(sessionModel.UserName);
            return RedirectToAction("Index","Home", new {
                ActiveConf = session.GetActiveConf(),
                ActiveDiv = session.GetActiveDiv()
            });
        }
        
    }
}
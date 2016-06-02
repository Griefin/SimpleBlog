using NHibernate.Linq;
using SimpleBlog.Areas.Admin.ViewModels;
using SimpleBlog.Infrastructure;
using SimpleBlog.Models;
using System.Linq;
using System.Web.Mvc;

namespace SimpleBlog.Areas.Admin.Controllers
{
  [Authorize(Roles = "Admin")]
  [SelectedTab("Users")]
  public class UsersController : Controller
  {
    //
    // GET: /Admin/Users/

    public ActionResult Index()
    {
      return View(new UsersIndex
      {
        Users = Database.Session.Query<User>().ToList()
      });
    }

  }
}

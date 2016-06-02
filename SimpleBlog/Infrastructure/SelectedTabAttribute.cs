using System;
using System.Web.Mvc;

namespace SimpleBlog.Infrastructure
{
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
  public class SelectedTabAttribute : ActionFilterAttribute
  {
    private string _selectedTab;

    public SelectedTabAttribute(string selectedTab)
    {
      _selectedTab = selectedTab;
    }

    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
      filterContext.Controller.ViewBag.SelectedTab = _selectedTab;
    }
  }
}
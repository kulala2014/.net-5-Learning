using Kulala.Learning.WebApp.Utility.Filter;
using System.Web;
using System.Web.Mvc;

namespace Kulala.Learning.WebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            // 这里可以全局注册filter
            //filters.Add(new CustomAuthorizeAttribute());
            filters.Add(new CustomHandleErrorAttribute());
            //filters.Add(new CustomGlobalActionFilterAttribute());
            filters.Add(new CompressActionFilterAttribute());
        }
    }
}

using System.Web;
using System.Web.Mvc;

namespace asp_with_users_and_rols
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new Filters.SesionVerification());

        }
    }
}

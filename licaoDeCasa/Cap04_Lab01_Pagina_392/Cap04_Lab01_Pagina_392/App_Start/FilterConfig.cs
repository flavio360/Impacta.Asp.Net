using System.Web;
using System.Web.Mvc;

namespace Cap04_Lab01_Pagina_392
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

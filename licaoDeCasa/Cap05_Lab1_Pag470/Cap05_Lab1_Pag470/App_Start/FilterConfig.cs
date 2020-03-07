using System.Web;
using System.Web.Mvc;

namespace Cap05_Lab1_Pag470
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

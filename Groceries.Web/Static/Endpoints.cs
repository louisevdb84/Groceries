using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Groceries.Web.Static
{
    public static class Endpoints
    {
        public static string BaseUrl = "https://localhost:44392/";
        public static string GroceryItemsEndpoint = $"{BaseUrl}api/groceryitems";
        public static string StoresEndpoint = $"{BaseUrl}api/stores";
        public static string RegisterEndpoint = $"{BaseUrl}api/users/register";
        public static string LoginEndpoint = $"{BaseUrl}api/users/login";
    }
}
    
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_BP.Includes
{
    public class DefaultAPI
    {
        private static Uri BaseUri = new Uri("http://localhost:1185/api/");

        public static void AddPath(string path)
        {
            BaseUri = new Uri(BaseUri.ToString() + path);
        }

        public static Uri GetPah()
        {
            return BaseUri;
        }
        public static Uri GetPath(String Path)
        {
            return new Uri(BaseUri.ToString() + Path);
        }
    }
}
using System;
using System.Web;

namespace ELH.Framework.Tests
{
    public static class HttpContextFactory
    {
        [ThreadStatic]
        private static HttpContextBase mockHttpContext;

        public static void SetHttpContext(HttpContextBase httpContextBase)
        {
            mockHttpContext = httpContextBase;
        }

        public static void ResetHttpContext()
        {
            mockHttpContext = null;
        }

        public static HttpContextBase GetHttpContext()
        {
            if (mockHttpContext != null)
            {
                return mockHttpContext;
            }

            if (HttpContext.Current != null)
            {
                return new HttpContextWrapper(HttpContext.Current);
            }
            return null;
        }
    }
}

using System;
using System.Collections.Specialized;
using System.Web;
using ELH.Framework.Interfaces;
using ELH.Framework.Base;

namespace ELH.Framework
{
    public class HttpParameters : ValueConvertBase, IHttpParameters
    {
        private HttpContextBase _context;

        public HttpParameters()
        {
            _context = new HttpContextWrapper(HttpContext.Current);
        }

        public HttpParameters(HttpContextBase baseContext)
        {
            _context = baseContext;
        }

        /// <summary>
        /// Returns the typed value of a Querystring or Form <see cref="System.Collections.Specialized.NameValueCollection" /> key.
        /// </summary>
        /// <typeparam name="T">The <see cref="System.Type" /> to return.</typeparam>
        /// <param name="key">The key used to retrieve a value.</param>
        /// <returns>A value of the given <see cref="System.Type" />.</returns>
        public T GetValue<T>(string key)
        {
            return GetValue<T>(key, default(T));
        }

        /// <summary>
        /// Returns the typed value of a Querystring or Form <see cref="System.Collections.Specialized.NameValueCollection" /> key. If none is found, then returns the nullValue given.
        /// </summary>
        /// <typeparam name="T">The <see cref="System.Type" /> to return.</typeparam>
        /// <param name="key">The key used to retrieve a value.</param>
        /// <param name="nullValue">A value to return in the event a proper value isn't found in the Querystring or Form <see cref="System.Collections.Specialized.NameValueCollection" />.</param>
        /// <returns>A value of the given <see cref="System.Type" />.</returns>
        public T GetValue<T>(string key, T nullValue)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }

            NameValueCollection nvc = _context.Request.QueryString;
            nvc.Add(HttpContext.Current.Request.Form);

            string keyValue = nvc[key];
            T result = GetValue<T>(nullValue, keyValue);
            return result;
        }
    }
}

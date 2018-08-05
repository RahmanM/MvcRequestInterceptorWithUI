using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Web.Mvc;

namespace Asp.Net.RequestInterceptors.Interceptors.Framework
{
    /// <summary>
    /// Class the register/de-register handlers and fire them if needed
    /// </summary>
    public class InterceptorHandler
    {
        protected static Lazy<ConcurrentDictionary<string, IInterceptor>> LazyCache = 
            new Lazy<ConcurrentDictionary<string, IInterceptor>>(() => new ConcurrentDictionary<string, IInterceptor>());

        protected static ConcurrentDictionary<string, IInterceptor> Cache = 
            new ConcurrentDictionary<string, IInterceptor>();


        InterceptorHandler()
        {
            Cache = LazyCache.Value;
        }

        /// <summary>
        /// Singleton factory method
        /// </summary>
        /// <returns>Returns the singleton instance of the handler</returns>
        public static InterceptorHandler Init()
        {
            return new InterceptorHandler();
        }

        /// <summary>
        /// Registers all the available interceptors
        /// </summary>
        /// <param name="interceptorRegisteration">Interceptor registery</param>
        public void RegisterInterceptors(InterceptorRegisteration interceptorRegisteration)
        {
            if (interceptorRegisteration == null)
                throw new ArgumentNullException(nameof(interceptorRegisteration));

            var interceptors = interceptorRegisteration.GetInterceptors();

            foreach (var interceptor in interceptors)
            {
                Register(interceptor.Key, interceptor.Value);
            }
        }

        /// <summary>
        /// Register a single interceptor
        /// </summary>
        /// <param name="key">Interceptor key</param>
        /// <param name="interceptor">Interceptor</param>
        public void Register(string key, IInterceptor interceptor)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (interceptor == null)
                throw new ArgumentNullException(nameof(interceptor));

            if (!Cache.ContainsKey(key))
            {
                Cache.TryAdd(key, interceptor);
            }
        }

        /// <summary>
        /// De-register interceptor
        /// </summary>
        /// <param name="key">Interceptor key</param>
        public void DeRegister(string key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            IInterceptor interceptor;
            Cache.TryRemove(key, out interceptor);
        }

        public void Fire()
        {
            Cache.Values.FirstOrDefault(w => w.ShouldIntercept())?.OnShow();
        }

        /// <summary>
        /// Fires the first interceptor registered
        /// </summary>
        /// <param name="actionContext">Action context via action filter</param>
        public void Fire(ActionExecutingContext actionContext)
        {
            if (actionContext == null)
                throw new ArgumentNullException(nameof(actionContext));

            var interceptor = 
                Cache.Values.OrderBy(o=> o.Order).FirstOrDefault(w => w.ShouldIntercept());

            if (interceptor != null)
            {
                actionContext.Result = interceptor.OnShow();
            }
        }
    }
}
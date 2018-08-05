using Asp.Net.RequestInterceptors.Interceptors.Registers;
using System.Collections.Generic;

namespace Asp.Net.RequestInterceptors.Interceptors.Framework
{

    /// <summary>
    /// Reigistery of all available interceptors
    /// </summary>
    public class InterceptorRegisteration
    {
        public Dictionary<string, IInterceptor> GetInterceptors()
        {
            var dictionary = new Dictionary<string, IInterceptor>();

            // TODO: Use DI etc if needed
            var welcomeInterceptor = new LoginWelcomeInterceptorController() {Order = 1 };
            dictionary.Add(welcomeInterceptor.InterceptorName, welcomeInterceptor);

            var testInterceptor = new TestInterceptorController() { Order = 2 };
            dictionary.Add(testInterceptor.InterceptorName, testInterceptor);
            
            return dictionary;
        }
    }
}
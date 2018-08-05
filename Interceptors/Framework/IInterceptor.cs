using System.Web.Mvc;

namespace Asp.Net.RequestInterceptors.Interceptors.Framework
{

    public interface IInterceptor
    {
        /// <summary>
        /// Indicats if should be intercepted or not
        /// </summary>
        bool ShouldIntercept();

        /// <summary>
        /// In the interceptor, once the user accepts the condition
        /// </summary>
        ActionResult OnOk();

        /// <summary>
        /// In the interceptor, once the user rejects the condition
        /// </summary>
        ActionResult OnCancel();

        /// <summary>
        /// Action to be called to fire the interceptor
        /// </summary>
        ActionResult OnShow();

        /// <summary>
        /// The order interceptor to be fired
        /// </summary>
        int Order { get; set; }
    }
}
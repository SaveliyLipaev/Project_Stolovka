using ModernHttpClient;
using Polly;
using Refit;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XamarinMobileApp.DAL.DataServices.Online
{
    class RequestMaker
    {
        protected async Task<RequestResult<T>> MakeRequest<T>(Func<CancellationToken, Task<T>> loadingFunction, CancellationToken cancellationToken)
            where T : class
        {
            Exception exception = null;
            var result = default(T);
            RequestResult<T> requestResult = default(RequestResult<T>);

            try
            {
                result = Policy.Handle<WebException>().Or<HttpRequestException>()
                    .WaitAndRetryAsync(3, i => TimeSpan.FromMilliseconds(300), (ex, span) => exception = ex)
                    .ExecuteAsync(loadingFunction, cancellationToken).GetAwaiter().GetResult();

                requestResult = new RequestResult<T>(result, RequestStatus.Ok);
            }
            catch (Exception e)
            {
                requestResult = new RequestResult<T>(null, RequestStatus.BadRequest, e.Message);
            }
            
            return requestResult;
        }
    }
}

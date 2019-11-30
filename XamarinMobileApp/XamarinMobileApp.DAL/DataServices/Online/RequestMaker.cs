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
        protected IStolovkaAPI _stolovkaAPI;

        protected RequestMaker()
        {
            var client = new HttpClient(new NativeMessageHandler())
            {
                BaseAddress = new Uri("здесь будет api")
            };
            _stolovkaAPI = RestService.For<IStolovkaAPI>(client);
        }

        protected async Task<T> MakeRequest<T>(Func<CancellationToken, Task<T>> loadingFunction, CancellationToken cancellationToken)
        {
            Exception exception = null;
            var result = default(T);

            try
            {
                result = await Policy.Handle<WebException>().Or<HttpRequestException>()
                    .WaitAndRetryAsync(3, i => TimeSpan.FromMilliseconds(300), (ex, span) => exception = ex)
                    .ExecuteAsync(loadingFunction, cancellationToken);
            }
            catch (Exception e)
            {
                // Сюда приходят ошибки вроде отсутствия интернет-соединения или неправильной работы DNS
                exception = e;
            }
            //TODO: Обработать исключения или передать их дальше            
            return result;
        }
    }
}

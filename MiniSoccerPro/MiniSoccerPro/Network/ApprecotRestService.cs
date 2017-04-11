using MiniSoccerPro.Models;
using ModernHttpClient;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace MiniSoccerPro.Network
{
    public class ApprecotRestService
    {
        private static readonly HttpClient Client = new HttpClient(new NativeMessageHandler());
       

        private static readonly ApprecotRestService _instance = new ApprecotRestService();

        static ApprecotRestService()
        {

        }

        private ApprecotRestService()
        {

        }

        public static ApprecotRestService Instance => _instance;

        public IObservable<ServiceResponse> GetAsync(string url)
        {
            return Observable.Create<ServiceResponse>(async (observer) => {

                string json = string.Empty;
                var serviceResponse = new ServiceResponse();
                try
                {
                    using (var response = await Client.GetAsync(url).ConfigureAwait(false))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            json = await response.Content.ReadAsStringAsync();

                            var obj = JObject.Parse(json);
                            serviceResponse.StatusCode = (int)obj["rs"];

                            serviceResponse.Json = json;

                            observer.OnNext(serviceResponse);
                            observer.OnCompleted();

                        }
                        else
                            observer.OnError(new Exception(response.StatusCode.ToString()));
                    }
                }
                catch (TaskCanceledException e)
                {
                    Debug.WriteLine(e.Message);
                    observer.OnError(new Exception(e.Message));
                }
                catch (HttpRequestException e)
                {
                    Debug.WriteLine(e.Message);
                }
                catch (WebException e)
                {
                    Debug.WriteLine(e.Message);
                    observer.OnError(new Exception(e.Message));
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    observer.OnError(new Exception(e.Message));
                }

                return Disposable.Empty;
            });
        }
    }
}

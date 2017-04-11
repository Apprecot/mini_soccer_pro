using Newtonsoft.Json;
using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace MiniSoccerPro.Network
{
    public class Api 
    {
        public IObservable<Url> GetPost(int id)
        {
            return Observable.Create<Url>((observer) =>
            {
                var subscription =
                ApprecotRestService.Instance.GetAsync($"http://www.anaxoft.com/goandwin_development/api/urls")
                .Subscribe((response) => {
                    var post = JsonConvert.DeserializeObject<Url>(response.Json);
                    observer.OnNext(post);
                    observer.OnCompleted();
                });

                return Disposable.Empty;
            });
        }
    }

    public class Url
    {
        public string rs { get; set; }
        public string userimages_base_url { get; set; }
        public string storeimages_base_url { get; set; }
        public string brandsimages_base_url { get; set; }
        public string categories_icons_base_url { get; set; }
        public string campaigns_base_url { get; set; }
        public string point_system_base_url { get; set; }
        public string services_url { get; set; }
        public string server_time { get; set; }
        public string distance { get; set; }
        public string rm { get; set; }
    }
}

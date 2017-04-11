using Newtonsoft.Json;
using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace MiniSoccerPro.Network
{
    public class Api
    {
        public IObservable<Post> GetPost(int id)
        {
            return Observable.Create<Post>((observer) =>
            {
                ApprecotRestService.Instance.GetAsync($"https://jsonplaceholder.typicode.com/posts/{id}")
                .Subscribe((response) => {
                    var post = JsonConvert.DeserializeObject<Post>(response.Json);
                    observer.OnNext(post);
                    observer.OnCompleted();
                });
                return Disposable.Empty;
            });
        }
    }

    public class Post
    {
         public int userId { get; set; }
         public int id { get; set; }
         public string title { get; set; }
         public string body { get; set; }
    }
}

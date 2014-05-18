using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamesWright.SimpleHttp
{
    public class App
    {
        private Server server;

        public App()
        {
            this.server = new Server(new Listener(), new RouteRepository());
        }

        public async Task StartAsync(string port = "8005")
        {
            await this.server.StartAsync(port);
        }

        public void Get(string endpoint, Action<Request, Response> handler)
        {
            this.server.RouteRepository.Get.Add(endpoint, handler);
        }

        public void Post(string endpoint, Action<Request, Response> handler)
        {
            this.server.RouteRepository.Post.Add(endpoint, handler);
        }

        public void Put(string endpoint, Action<Request, Response> handler)
        {
            this.server.RouteRepository.Put.Add(endpoint, handler);
        }

        public void Delete(string endpoint, Action<Request, Response> handler)
        {
            this.server.RouteRepository.Delete.Add(endpoint, handler);
        }
    }
}

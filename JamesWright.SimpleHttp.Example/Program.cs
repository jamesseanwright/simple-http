using JamesWright.SimpleHttp;
using System.Threading;
using System.Threading.Tasks;

namespace JamesWright.SimpleHttp.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync();
            AutoResetEvent keepAlive = new AutoResetEvent(false);
            keepAlive.WaitOne();
        }

        private static async void RunAsync()
        {
            App app = new App();

            app.Get("/", async (req, res) =>
            {
                res.Content = "<p>You did a GET.</p>";
                res.ContentType = "text/html";
                await res.SendAsync();
            });

            app.Post("/", async (req, res) =>
            {
                res.Content = "<p>You did a POST: " + req.Body + "</p>";
                res.ContentType = "text/html";
                await res.SendAsync();
            });

            app.Put("/", async (req, res) =>
            {
                res.Content = "<p>You did a PUT: " + req.Body + "</p>";
                res.ContentType = "text/html";
                await res.SendAsync();
            });

            app.Delete("/", async (req, res) =>
            {
                res.Content = "<p>You did a DELETE: " + req.Body + "</p>";
                res.ContentType = "text/html";
                await res.SendAsync();
            });

            await app.StartAsync();
        }
    }
}

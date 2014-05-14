using JamesWright.SimpleHttp;

namespace JamesWright.SimpleHttp.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            App app = new App();

            app.Get("/", (req, res) =>
            {
                res.Content = "{ \"message\": \"Hello\" }";
                res.ContentType = "application/json";
                res.Send();
            });

            app.Get("/version", (req, res) =>
            {
                res.Content = "{ \"message\": \"Hello\" }";
                res.ContentType = "application/json";
                res.Send();
            });

            app.Start();
        }
    }
}

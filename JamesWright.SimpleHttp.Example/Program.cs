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
                res.Content = "<p>You did a GET.</p>";
                res.ContentType = "text/html";
                res.Send();
            });

            app.Post("/", (req, res) =>
            {
                res.Content = "<p>You did a POST: " + req.Body + "</p>";
                res.ContentType = "text/html";
                res.Send();
            });

            app.Put("/", (req, res) =>
            {
                res.Content = "<p>You did a PUT: " + req.Body + "</p>";
                res.ContentType = "text/html";
                res.Send();
            });

            app.Delete("/", (req, res) =>
            {
                res.Content = "<p>You did a DELETE: " + req.Body + "</p>";
                res.ContentType = "text/html";
                res.Send();
            });

            app.Start();
        }
    }
}

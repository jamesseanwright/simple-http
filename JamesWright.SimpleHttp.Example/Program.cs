using JamesWright.SimpleHttp;

namespace JamesWright.SimpleHttp.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            App app = new App();

            app.Get("/content", (req, res) =>
            {
                res.Content = "You did a GET.";
                res.Send();
            });

            app.Post("/content", (req, res) =>
            {
                res.Content = "You did a POST: " + req.Body;
                res.Send();
            });

            app.Put("/content", (req, res) =>
            {
                res.Content = "You did a PUT: " + req.Body;
                res.Send();
            });

            app.Delete("/content", (req, res) =>
            {
                res.Content = "You did a DELETE: " + req.Body;
                res.Send();
            });

            app.Start();
        }
    }
}

using JamesWright.SimpleHttp;

namespace JamesWright.SimpleHttp.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();

            server.Routes.Add("/", (req, res) =>
            {
                res.Content = "{ \"message\": \"Hello\" }";
                res.ContentType = "application/json";
                res.Send();
            });

            server.Start(args);
        }
    }
}

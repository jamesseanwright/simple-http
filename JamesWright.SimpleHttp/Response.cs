using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JamesWright.SimpleHttp
{
    public class Response
    {
        private HttpListenerResponse httpListenerResponse;

        public string Content { get; set; }
        public string ContentType { get; set; }

        internal Response(HttpListenerResponse httpListenerResponse)
        {
            this.httpListenerResponse = httpListenerResponse;
        }

        public async Task SendAsync()
        {
            byte[] responseBuffer = Encoding.UTF8.GetBytes(Content);
            this.httpListenerResponse.ContentType = ContentType;

            if (this.httpListenerResponse.ContentLength64 == 0)
                this.httpListenerResponse.ContentLength64 = responseBuffer.Length;

            using (Stream output = this.httpListenerResponse.OutputStream)
            { 
                await output.WriteAsync(responseBuffer, 0, responseBuffer.Length);
            }

            Console.WriteLine("{0}: Responded to request with {1} bytes of data.", DateTime.Now, responseBuffer.Length);
            this.httpListenerResponse.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

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

        public void Send()
        {
            byte[] responseBuffer = Encoding.UTF8.GetBytes(Content);
            this.httpListenerResponse.ContentType = ContentType;
            this.httpListenerResponse.ContentLength64 = responseBuffer.Length;
            Stream output = this.httpListenerResponse.OutputStream;
            output.Write(responseBuffer, 0, responseBuffer.Length);
            output.Close();
            Console.WriteLine("{0}: Responded to request with {1} bytes of data.", DateTime.Now, responseBuffer.Length);
        }
    }
}

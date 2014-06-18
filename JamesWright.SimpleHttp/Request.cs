using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JamesWright.SimpleHttp
{
    public class Request
    {
        private HttpListenerRequest httpRequest;
        private string body;

        internal Request(HttpListenerRequest httpRequest)
        {
            this.httpRequest = httpRequest;
        }

        public string[] Parameters { get; private set; }

        public string Endpoint
        {
            get { return this.httpRequest.RawUrl; }
        }

        public string Method
        {
            get { return this.httpRequest.HttpMethod; }
        }

        public async Task<string> GetBodyAsync()
        {
            //TODO: handle exceptions
            if (Method == Methods.Get || !this.httpRequest.HasEntityBody)
                return null;

            if (this.body == null)
            {
                byte[] buffer = new byte[this.httpRequest.ContentLength64];
                using (Stream inputStream = this.httpRequest.InputStream)
                {
                    await inputStream.ReadAsync(buffer, 0, buffer.Length);
                }

                this.body = Encoding.UTF8.GetString(buffer);
            }

            return this.body;
        }
    }
}

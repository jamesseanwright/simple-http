# SimpleHttp

A basic HTTP server framework written in C#.

## Usage

    using JamesWright.SimpleHttp;
    
    namespace ServerExample
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


## APIs

### `App` ###
Represents an application, served over HTTP, and the requests for which it will listen.

#### Public properties and methods #####
##### `void Get(string endpoint, Action<Request, Response> handler)` ######
Adds a handler for a HTTP Get request to the requested endpoint.

##### `void Post(string endpoint, Action<Request, Response> handler)` ######
**Not yet implemented** Adds a handler for a HTTP Post request to the requested endpoint.

##### `void Put(string endpoint, Action<Request, Response> handler)` ######
**Not yet implemented** Adds a handler for a HTTP Put request to the requested endpoint.

##### `void Delete(string endpoint, Action<Request, Response> handler)` ######
**Not yet implemented** Adds a handler for a HTTP Delete request to the requested endpoint.

##### `void Start(string portNumber = "8005")`#####
Initialises the server and its underlying listener. Port number can be optionally specified.

### `Request` ###
A HTTP request, and its underlying information, that is sent to the server.

#### Public properties and methods #####
##### `string Endpoint { get; }` ######
Returns the endpoint that the Request instance represents e.g. "/".

##### `string[] Parameters`#####
Contains the parameters sent with the HTTP request. Currently not populated.

### `Response` ###
A response to be sent to the user.

#### Public properties and methods #####
##### `string Content { get; set; }` ######
The body content to be returned to the user.

##### `string ContentType { get; set; }`#####
The Internet media type (MIME) of the response e.g. "application/json".

##### `void Send()` #####
Sends the response.

## Future Considerations

* Unit tests
* HTTPS/SSL
* Asynchronous HTTP operations
* Memory management

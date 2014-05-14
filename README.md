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
                Server server = new Server();

                server.Routes.Add("/", (req, res) =>
                {
                    res.Content = "{ message: \"Hello\" }";
                    res.ContentType = "application/json";
                    res.Send();
                });

                server.Start(args);
            }
        }
    }


## APIs

### `Server` ###
Represents the HTTP server and the requests for which it will listen.

#### Public properties and methods #####
##### `Dictionary<string, Action<Request, Response>> Routes` ######
The routes for each possible request, and a handler to specify its logic

##### `void Start(string[] args = null)`#####
Initialises the server and its underlying listener. Only one argument is valid at present: the port number (8005 if not specified). This signature might get deprecated.

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
* Support for HTTP verbs/REST
* Memory management

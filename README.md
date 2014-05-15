# SimpleHttp

A basic HTTP server framework written in C#.

## Usage

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
	

## APIs

### `App` ###
Represents an application, served over HTTP, and the requests for which it will listen.

#### Public properties and methods #####
##### `void Get(string endpoint, Action<Request, Response> handler)` ######
Adds a handler for a HTTP GET request to the requested endpoint.

##### `void Post(string endpoint, Action<Request, Response> handler)` ######
Adds a handler for a HTTP POST request to the requested endpoint.

##### `void Put(string endpoint, Action<Request, Response> handler)` ######
Adds a handler for a HTTP PUT request to the requested endpoint.

##### `void Delete(string endpoint, Action<Request, Response> handler)` ######
Adds a handler for a HTTP DELETE request to the requested endpoint.

##### `void Start(string portNumber = "8005")`#####
Initialises the server and its underlying listener. Port number can be optionally specified.

### `Request` ###
A HTTP request, and its underlying information, that is sent to the server.

#### Public properties and methods #####
##### `string Endpoint { get; }` ######
Returns the endpoint that the Request instance represents e.g. "/".

##### `string Body { get; }` ######
Returns request's body content.

##### `string[] Parameters { get; }`#####
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

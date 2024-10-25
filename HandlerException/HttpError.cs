using System.Net;

namespace HandlerException
{
    public class HttpError : Exception
    {
        public HttpStatusCode _code { get; }
        public object _data { get; }
        public HttpError(HttpStatusCode code, object data = null) 
        {
            _code = code;
            _data = data;
        }
    }
}

using System.Net;

namespace BeautyStore.Infrastructure.Repositories
{
    [Serializable]
    internal class HttpException : Exception
    {
        private HttpStatusCode notFound;
        private string v;

        public HttpException()
        {
        }

        public HttpException(string? message) : base(message)
        {
        }

        public HttpException(HttpStatusCode notFound, string v)
        {
            this.notFound = notFound;
            this.v = v;
        }

        public HttpException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
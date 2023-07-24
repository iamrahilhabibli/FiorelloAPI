using System.Net;

namespace Fiorello.Persistence.Exceptions;

public class DuplicatedException : Exception, IBaseException
{
    public int StatusCode { get ; set ; }
    public string CustomMessage { get ; set; }
    public DuplicatedException(string message):base(message)
    {
        StatusCode = (int)HttpStatusCode.Conflict;
        CustomMessage = message;
    }
}

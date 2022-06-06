namespace Skinet.Domain.Exceptions;

public class NullControllerException : Exception
{
    public NullControllerException(string message) : base(message) { }
}
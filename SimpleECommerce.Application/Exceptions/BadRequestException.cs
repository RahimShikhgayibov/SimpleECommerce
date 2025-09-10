namespace SimpleECommerce.Application.Exceptions;

public sealed class BadRequestException(string message) : Exception(message)
{
    public string Code => "BAD_REQUEST_EXCEPTION";
    public override string Message { get; } = message;
}
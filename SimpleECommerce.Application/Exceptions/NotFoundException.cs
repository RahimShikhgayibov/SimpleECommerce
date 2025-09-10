namespace SimpleECommerce.Application.Exceptions;

public sealed class NotFoundException(string message) : Exception(message)
{
    public string Code => "NOT_FOUND_EXCEPTION";
    public override string Message { get; } = message;
}
namespace Pastinha.Model.Model;

public sealed record Error(string Code, string Message)
{
    public static Error None(string message) => new(string.Empty, message);
    public static Error NullValue(string message) => new("Error.NullValue", message);
    public static Error NotFound(string message) => new("NotFound", message);
    public static Error BadRequest(string message) => new("BadRequest", message);
    public static Error InternalServer(string message) => new("InternalServer", message);
    public static Error Unauthorized(string message) => new("Unauthorized", message);
    public static Error Forbidden(string message) => new("Forbidden", message);
    public static Error Conflict(string message) => new("Conflict", message);
    public static Error Validation(string message) => new("Validation", message);
    public static Error NotImplemented(string message) => new("NotImplemented", message);
    public static Error ServiceUnavailable(string message) => new("ServiceUnavailable", message);
}

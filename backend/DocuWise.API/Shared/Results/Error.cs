namespace DocuWise.API.Shared.Results;

public class Error
{
    public string Code { get; }
    public string Message { get; }

    private Error(string code, string message)
    {
        Code = code;
        Message = message;
    }
    public static Error None => new("", "");
    public static Error Validation(string message) => new("Validation.Error", message);
    public static Error NotFound(string entity) => new("General.NotFound", $"{entity} was not found.");
    public static Error Unexpected(string message) => new("General.Unexpected", message);
    public static Error Custom(string code, string message) => new(code, message);
    public override string ToString() => $"{Code}: {Message}";
}
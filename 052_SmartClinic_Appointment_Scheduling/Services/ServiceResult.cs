namespace SmartClinic.Services;

public record ServiceResult<T>(bool Success, string? ErrorMessage, T? Value)
{
    public static ServiceResult<T> Ok(T value) => new(true, null, value);
    public static ServiceResult<T> Fail(string error) => new(false, error, default);
}

using System.Text.Json.Serialization;

namespace ZenBlogServer.Application.Base;

public class BaseResult<T>
{
    public T? Data { get; set; }
    public IEnumerable<Error> Errors { get; set; } = Enumerable.Empty<Error>();

    [JsonIgnore]
    public bool IsSuccess => Data != null;
    [JsonIgnore]
    public bool IsFailure => Errors.Any(); // artık güvenli


    public static BaseResult<T> Success(T data)
    {
        return new BaseResult<T>
        {
            Data = data,
        };
    }
    
    public static BaseResult<T> Fail(T data)
    {
        return new BaseResult<T>
        {
            Errors = new [] { new Error { ErrorMessage = data.ToString() } }
        };
    }
    
    public static BaseResult<T> Fail()
    {
        return new BaseResult<T>
        {
            Errors = new [] { new Error { ErrorMessage = "An error occured" } }
        };
    }
    
    public static BaseResult<T> Fail(IEnumerable<Error> errors)
    {
        return new BaseResult<T>
        {
            Errors = (from e in errors select new Error { ErrorMessage = e.ToString() }  ).ToList()
        };
    }
    
    public static BaseResult<T> NotFound(string message)
    {
        return new BaseResult<T>
        {
            Errors = new [] { new Error { ErrorMessage = message } }
        };
    }
}

public class Error
{
    public string? PropertyName { get; set; }
    public string? ErrorMessage { get; set; }
}
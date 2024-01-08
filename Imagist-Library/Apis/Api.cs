namespace Imagist_Library.Apis;

public class Api<T>
{
    public int Code { get; set; }
    public bool IsSuccess { get; set; }
    public string? Msg { get; set; }
    public T? Data { get; set; }

    public static Api<T> Success(string message)
    {
        return new Api<T>()
        {
            IsSuccess = true,
            Code = (int)ApiCode.Success, 
            Msg = message
        };
    }
    public static Api<T> Success(T data,string message)
    {
        return new Api<T>()
        {
            IsSuccess = true,
            Code = (int)ApiCode.Success, 
            Msg = message,
            Data = data
        };
    }

    public static Api<T> Success(T data)
    {
        return new Api<T>()
        {
            IsSuccess = true,
            Code = (int)ApiCode.Success, 
            Data = data
        };
    }

    public static Api<T> Failed(ApiCode apiCode,string message)
    {
        return new Api<T>()
        {
            IsSuccess = false,
            Code = (int)apiCode, 
            Msg = message
        };
    }
    
}

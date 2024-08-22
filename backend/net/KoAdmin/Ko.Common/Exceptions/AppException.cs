using System.Net;

namespace Ko.Common.Exceptions;

/// <summary>
/// 系统异常
/// </summary>
public class AppException : Exception
{
    /// <summary>
    /// 
    /// </summary>
    public string AppMessage { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string AppCode { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int StatusCode { get; set; } = (int)HttpStatusCode.OK;
    /// <summary>
    /// 
    /// </summary>
    public AppException()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public AppException(string message)
        : base(message)
    {
        AppMessage= message;
    }

    /// <summary>
    /// 
    /// </summary>
    public AppException(string message, string code)
        : base(message)
    {
        AppMessage = message;
        AppCode = code;
    }

    /// <summary>
    /// 
    /// </summary>
    public AppException(string message, string code, int statusCode)
        : base(message)
    {
        AppMessage = message;
        AppCode = code;
        StatusCode = statusCode;
    }
    
    /// <summary>
    /// 
    /// </summary>
    public AppException(string message, Exception innerException)
        : base(message, innerException)
    {
        AppMessage= message;
    }

    /// <summary>
    /// 
    /// </summary>
    public AppException(string message, string code, Exception innerException)
        : base(message, innerException)
    {
        AppMessage = message;
        AppCode = code;
    }

    /// <summary>
    /// 
    /// </summary>
    public AppException(string message, string code, int statusCode, Exception innerException)
        : base(message, innerException)
    {
        AppMessage = message;
        AppCode = code;
        StatusCode = statusCode;
    }
}

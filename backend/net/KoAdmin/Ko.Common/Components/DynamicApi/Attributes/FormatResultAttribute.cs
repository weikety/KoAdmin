namespace DynamicApi.Attributes;

/// <summary>
/// 
/// </summary>
[Serializable]
[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public class FormatResultAttribute : ProducesResponseTypeAttribute
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="statusCode"></param>
    public FormatResultAttribute(int statusCode) : base(statusCode)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    public FormatResultAttribute(Type type) : base(type, StatusCodes.Status200OK)
    {
        FormatType(type);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <param name="statusCode"></param>
    public FormatResultAttribute(Type type, int statusCode) : base(type, statusCode)
    {
        FormatType(type);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    private void FormatType(Type type)
    {
        if (type != null && type != typeof(void))
        {
            Type = AppConsts.FormatResultType.MakeGenericType(type);
        }
    }
}
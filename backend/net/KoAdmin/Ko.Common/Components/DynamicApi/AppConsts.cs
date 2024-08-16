namespace DynamicApi;

/// <summary>
/// 
/// </summary>
public static class AppConsts
{
    /// <summary>
    /// 
    /// </summary>
    public static string DefaultHttpVerb { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public static string DefaultAreaName { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public static string DefaultApiPreFix { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public static List<string> ControllerPostfixes { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public static List<string> ActionPostfixes { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public static List<Type> FormBodyBindingIgnoredTypes { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public static Dictionary<string,string> HttpVerbs { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public static NamingConventionEnum NamingConvention { get; set; } = NamingConventionEnum.KebabCase;

    /// <summary>
    /// 
    /// </summary>
    public static Func<string, string> GetRestFulControllerName { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public static Func<string, string> GetRestFulActionName { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public static Dictionary<Assembly, AssemblyDynamicApiOptions> AssemblyDynamicApiOptions { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public static bool FormatResult { get; set; } = true;

    /// <summary>
    /// 
    /// </summary>
    public static Type FormatResultType { get; set; } = FormatResultContext.FormatResultType;

    /// <summary>
    /// 
    /// </summary>
    static AppConsts()
    {
        HttpVerbs=new Dictionary<string, string>()
        {
            ["add"] = "POST",
            ["create"] = "POST",
            ["insert"] = "POST",
            ["submit"] = "POST",
            ["post"] = "POST",

            ["get"] = "GET",
            ["find"] = "GET",
            ["fetch"] = "GET",
            ["query"] = "GET",

            ["update"] = "PUT",
            ["change"] = "PUT",
            ["put"] = "PUT",
            ["batch"] = "PUT",

            ["delete"] = "DELETE",
            ["soft"] = "DELETE",
            ["remove"] = "DELETE",
            ["clear"] = "DELETE",
        };
    }
}
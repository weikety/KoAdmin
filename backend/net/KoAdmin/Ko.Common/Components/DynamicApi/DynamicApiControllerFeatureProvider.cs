namespace DynamicApi;

/// <summary>
/// 
/// </summary>
public class DynamicApiControllerFeatureProvider: ControllerFeatureProvider
{
    /// <summary>
    /// 
    /// </summary>
    private ISelectController _selectController;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="selectController"></param>
    public DynamicApiControllerFeatureProvider(ISelectController selectController)
    {
        _selectController = selectController;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="typeInfo"></param>
    /// <returns></returns>
    protected override bool IsController(TypeInfo typeInfo)
    {
        return _selectController.IsController(typeInfo);
    }
}
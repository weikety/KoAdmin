namespace DynamicApi.Attributes;

/// <summary>
/// 
/// </summary>
[Serializable]
[AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Method)]
public class NonDynamicApiAttribute:Attribute
{
    
}
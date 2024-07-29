namespace Ko.Common.Extension;

public static class ConvertExtension
{
    /// <summary>
    /// To Int
    /// </summary>
    /// <param name="thisValue"></param>
    /// <returns></returns>
    public static int ObjToInt(this object? thisValue)
    {
        var reveal = 0;
        if (thisValue == null) return 0;
        if (thisValue != DBNull.Value && int.TryParse(thisValue.ToString(), out reveal))
        {
            return reveal;
        }

        return reveal;
    }

    /// <summary>
    /// To Int
    /// </summary>
    /// <param name="thisValue"></param>
    /// <param name="errorValue"></param>
    /// <returns></returns>
    public static int ObjToInt(this object? thisValue, int errorValue)
    {
        if (thisValue != null && thisValue != DBNull.Value && int.TryParse(thisValue.ToString(), out var reveal))
        {
            return reveal;
        }
        return errorValue;
    }

    /// <summary>
    /// To Money（double）
    /// </summary>
    /// <param name="thisValue"></param>
    /// <returns></returns>
    public static double ObjToMoney(this object? thisValue)
    {
        if (thisValue != null && thisValue != DBNull.Value && double.TryParse(thisValue.ToString(), out var reveal))
        {
            return reveal;
        }

        return 0;
    }

    /// <summary>
    /// To Money（double）
    /// </summary>
    /// <param name="thisValue"></param>
    /// <param name="errorValue"></param>
    /// <returns></returns>
    public static double ObjToMoney(this object? thisValue, double errorValue)
    {
        if (thisValue != null && thisValue != DBNull.Value && double.TryParse(thisValue.ToString(), out var reveal))
        {
            return reveal;
        }
        return errorValue;
    }

    /// <summary>
    /// To String
    /// </summary>
    /// <param name="thisValue"></param>
    /// <returns></returns>
    public static string ObjToString(this object? thisValue)
    {
        return thisValue != null ? thisValue.ToString().Trim() : "";
    }

    /// <summary>
    /// Is Not Empty Or Null
    /// </summary>
    /// <param name="thisValue"></param>
    /// <returns></returns>
    public static bool IsNotEmptyOrNull(this object? thisValue)
    {
        return ObjToString(thisValue) != "" && ObjToString(thisValue) != "undefined" &&
               ObjToString(thisValue) != "null";
    }

    /// <summary>
    /// To String
    /// </summary>
    /// <param name="thisValue"></param>
    /// <param name="errorValue"></param>
    /// <returns></returns>
    public static string ObjToString(this object? thisValue, string errorValue)
    {
        return thisValue != null ? thisValue.ToString().Trim() : errorValue;
    }

    /// <summary>
    /// To Decimal
    /// </summary>
    /// <param name="thisValue"></param>
    /// <returns></returns>
    public static Decimal ObjToDecimal(this object? thisValue)
    {
        if (thisValue != null && thisValue != DBNull.Value && decimal.TryParse(thisValue.ToString(), out var reveal))
        {
            return reveal;
        }
        return 0;
    }

    /// <summary>
    /// To Decimal
    /// </summary>
    /// <param name="thisValue"></param>
    /// <param name="errorValue"></param>
    /// <returns></returns>
    public static Decimal ObjToDecimal(this object? thisValue, decimal errorValue)
    {
        if (thisValue != null && thisValue != DBNull.Value && decimal.TryParse(thisValue.ToString(), out var reveal))
        {
            return reveal;
        }
        return errorValue;
    }

    /// <summary>
    /// To Date
    /// </summary>
    /// <param name="thisValue"></param>
    /// <returns></returns>
    public static DateTime ObjToDate(this object? thisValue)
    {
        var reveal = DateTime.MinValue;
        if (thisValue != null && thisValue != DBNull.Value && DateTime.TryParse(thisValue.ToString(), out reveal))
        {
            reveal = Convert.ToDateTime(thisValue);
        }
        return reveal;
    }

    /// <summary>
    /// To Date
    /// </summary>
    /// <param name="thisValue"></param>
    /// <param name="errorValue"></param>
    /// <returns></returns>
    public static DateTime ObjToDate(this object? thisValue, DateTime errorValue)
    {
        if (thisValue != null && thisValue != DBNull.Value && DateTime.TryParse(thisValue.ToString(), out var reveal))
        {
            return reveal;
        }
        return errorValue;
    }

    /// <summary>
    /// To Bool
    /// </summary>
    /// <param name="thisValue"></param>
    /// <returns></returns>
    public static bool ObjToBool(this object? thisValue)
    {
        var reveal = false;
        if (thisValue != null && thisValue != DBNull.Value && bool.TryParse(thisValue.ToString(), out reveal))
        {
            return reveal;
        }
        return reveal;
    }

    /// <summary>
    /// 时间转时间戳
    /// </summary>
    /// <param name="thisValue"></param>
    /// <returns></returns>
    public static string DateToTimeStamp(this DateTime thisValue)
    {
        var ts = thisValue - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return Convert.ToInt64(ts.TotalSeconds).ToString();
    }
}
namespace ProductMaintenance;

public static class Validator
{
    public static string LineEnd { get; set; } = "\n";

    public static string IsPresent(string value, string name)
    {
        string msg = "";
        if (value == "")
        {
            msg = $"{name} is a required field.{LineEnd}";
        }
        return msg;
    }

    public static string IsDecimal(string value, string name)
    {
        string msg = "";
        if (!Decimal.TryParse(value, out _))
        {
            msg = $"{name} must be a valid decimal value.{LineEnd}";
        }
        return msg;
    }

    public static string IsInt32(string value, string name)
    {
        string msg = "";
        if (!Int32.TryParse(value, out _))
        {
            msg = $"{name} must be a valid integer value.{LineEnd}";
        }
        return msg;
    }

    public static string IsWithinRange(string value, string name, decimal min,
        decimal max)
    {
        string msg = "";
        if (Decimal.TryParse(value, out decimal number))
        {
            if (number < min || number > max)
            {
                msg = $"{name} must be between {min} and {max}.{LineEnd}";
            }
        }
        return msg;
    }
}
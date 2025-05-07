namespace Murach.Validation;

/// <summary>
/// Provides static methods for validating data.
/// </summary>
public static class Validator
{
    /// <summary>
    /// The character sequence to terminate each line in the validation message.
    /// </summary>
    public static string LineEnd { get; set; } = "\n";

    /// <summary>
    /// Checks whether the user entered a value.
    /// </summary>
    /// <param name="value">The value to be validated.</param>
    /// <param name="name">A name that identifies the value to be validated.</param>
    /// <returns>An error message if the user didn't enter a value.</returns>
    public static string IsPresent(string value, string name)
    {
        string msg = "";
        if (value == "")
        {
            msg = $"{name} is a required field.{LineEnd}";
        }
        return msg;
    }

    /// <summary>
    /// Checks whether the user entered a decimal value.
    /// </summary>
    /// <param name="value">The value to be validated.</param>
    /// <param name="name">A name that identifies the value to be validated.</param>
    /// <returns>An error message if the value isn't a valid decimal.</returns>
    public static string IsDecimal(string value, string name)
    {
        string msg = "";
        if (!Decimal.TryParse(value, out _))
        {
            msg = $"{name} must be a valid decimal value.{LineEnd}";
        }
        return msg;
    }

    /// <summary>
    /// Checks whether the user entered an integer value.
    /// </summary>
    /// <param name="value">The value to be validated.</param>
    /// <param name="name">A name that identifies the value to be validated.</param>
    /// <returns>An error message if the value isn't a valid integer.</returns>
    public static string IsInt32(string value, string name)
    {
        string msg = "";
        if (!Int32.TryParse(value, out _))
        {
            msg = $"{name} must be a valid integer value.{LineEnd}";
        }
        return msg;
    }

    /// <summary>
    /// Checks whether a value is within a specified range.
    /// </summary>
    /// <param name="value">The value to be validated.</param>
    /// <param name="name">A name that identifies the value to be validated.</param>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>An error message if the value isn't within the specified range.</returns>
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

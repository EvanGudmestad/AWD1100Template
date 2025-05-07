namespace ValidationLibTests;

[TestClass]
public class ValidatorTests
{
    [TestMethod]
    public void IsWithinRange_IsValidReturnsEmptyString()
    {
        // Arrange
        string value = "9";
        string name = "Price";
        decimal min = 0.0m;
        decimal max = 100.0m;

        string expected = "";

        // Act
        var result = Validator.IsWithinRange(value, name, min, max);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [TestMethod]
    public void IsWithinRange_InvalidTooSmallReturnsErrorMessage()
    {
        // Arrange
        string value = "-9";
        string name = "Price";
        decimal min = 0.0m;
        decimal max = 100.0m;

        string expected = $"{name} must be between {min} and {max}.\n";

        // Act
        var result = Validator.IsWithinRange(value, name, min, max);

        // Assert
        Assert.IsTrue(result == expected);
    }

    [TestMethod]
    public void IsWithinRange_InvalidTooLargeReturnsErrorMessage()
    {
        // Arrange
        string value = "101";
        string name = "Price";
        decimal min = 0.0m;
        decimal max = 100.0m;

        string expected = $"{name} must be between {min} and {max}.\n";

        // Act
        var result = Validator.IsWithinRange(value, name, min, max);

        // Assert
        Assert.IsTrue(result == expected);
    }
}
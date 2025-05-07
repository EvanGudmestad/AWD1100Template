namespace ValidationLibraryTests;

[TestClass]
public class ValidatorTests
{
    [TestMethod]
    public void IsDecimal_ValidValueReturnsEmptyString()
    {
        string expected = "";                              // arrange
        var result = Validator.IsDecimal("3.14", "Name");  // act
        Assert.AreEqual(expected, result);                 // assert
    }

    [TestMethod]
    public void IsDecimal_InvalidValueContainsFieldName()
    {
        string name = "Test field";                        // arrange
        var result = Validator.IsDecimal("three", name);   // act
        Assert.IsTrue(result.Contains(name));              // assert
    }

}
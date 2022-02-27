using Xunit;

namespace MonkeyValidatorTests;

public class MonkeyValidatorTrackingTests
{
    [Fact]
    public void Test_CustomValidator()
    {
        var sut = new TestClass(3, "hello");
        sut.TestUsabilityPrimitive(3);   
    }
}
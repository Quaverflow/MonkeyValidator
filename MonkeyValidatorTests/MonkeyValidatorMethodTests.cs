using MonkeyValidator.Validator;
using MonkeyValidator.Validator.Extensions;
using Xunit;

namespace MonkeyValidatorTests;

public class MonkeyValidatorMethodTests
{
    [Fact]
    public void Test_MethodShouldReturn()
    {
        var sut = new TestClass(3, "hello");
        Assert.Throws<MonkeyValidatorException> (()=> sut.GetValidator().MethodShouldReturn(x => x.TestMethodReturn("over"), 34).Execute());
        sut.GetValidator().MethodShouldReturn(x => x.TestMethodReturn("over"), 4).Execute();
    }
}
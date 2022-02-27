using MonkeyValidator.Validator;
using MonkeyValidator.Validator.Extensions;
using Xunit;

namespace MonkeyValidatorTests;

public class MonkeyValidatorBoolTests
{
    [Fact]
    public void Test_TrueFalse()
    {
        Assert.Throws<MonkeyValidatorException>(() => true.GetValidator().ShouldBeFalse().Execute());
        Assert.Throws<MonkeyValidatorException>(() => false.GetValidator().ShouldBeTrue().Execute());
        false.GetValidator().ShouldBeFalse().Execute();
        true.GetValidator().ShouldBeTrue().Execute();
    }
    [Fact]
    public void Test_NullableTrueFalse()
    {
        bool? truthy = true;
        bool? falsy = false;
        bool? nully = null;

        Assert.Throws<MonkeyValidatorException>(() => truthy.GetValidator().ShouldHaveValueFalse().Execute());
        Assert.Throws<MonkeyValidatorException>(() => falsy.GetValidator().ShouldHaveValueTrue().Execute());
        Assert.Throws<MonkeyValidatorException>(() => nully.GetValidator().ShouldHaveValueFalse().Execute());
        Assert.Throws<MonkeyValidatorException>(() => nully.GetValidator().ShouldHaveValueTrue().Execute());
        truthy.GetValidator().ShouldHaveValueTrue().Execute();
        falsy.GetValidator().ShouldHaveValueFalse().Execute();
    }
}
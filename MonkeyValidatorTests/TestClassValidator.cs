using MonkeyValidator.Validator;
using MonkeyValidator.Validator.Extensions;

namespace MonkeyValidatorTests;

public class TestClassValidator : CustomMonkeyValidatorBase<TestClass>
{
    protected override MonkeyClassValidator<TestClass> SetupValidator(TestClass instance)
    => instance.BuildValidator(
        y => y.Number.GetValidator().ShouldBeMoreThan(4),
        y => y.String.GetValidator().ShouldBe(x => x == "hello"),
        y => y.TestClass1.Number.GetValidator().ShouldBeLessThan(5),
        y => y.TestClass1.GetValidator().ShouldNotBeNull());
}
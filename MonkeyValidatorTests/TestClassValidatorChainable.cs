using MonkeyValidator.Validator;
using MonkeyValidator.Validator.Extensions;

namespace MonkeyValidatorTests;

public class TestClassValidatorChainable : CustomMonkeyValidatorBase<TestClass>
{
    protected override MonkeyClassValidator<TestClass> SetupValidator(TestClass instance)
        => instance.BuildValidator(
            y => y.Number.GetValidator().ShouldBeMoreThan(4),
            y => y.String.GetValidator().ShouldBe(x => x == "hello"));
}
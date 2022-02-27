using MonkeyValidator.Validator;
using MonkeyValidator.Validator.Extensions;

namespace MonkeyValidatorTests;

public class TestClassChainedNestedValidator : CustomMonkeyValidatorBase<TestClassChainedNested>
{
    protected override MonkeyClassValidator<TestClassChainedNested> SetupValidator(TestClassChainedNested instance)
        => instance.BuildValidator(y => y.Bool.GetValidator().ShouldBeEqualTo(false));
}
using MonkeyValidator.Validator;
using MonkeyValidator.Validator.Extensions;

namespace MonkeyValidatorTests;

public class TestClassChainableValidator : CustomMonkeyValidatorBase<TestClassChainable>
{
    protected override MonkeyClassValidator<TestClassChainable> SetupValidator(TestClassChainable instance)
        => instance.BuildValidator(y => y.String.GetValidator()
                   .ShouldBe(x => x == "hello"))
                   .Chain(new TestClassChainedValidator(), instance.TestClassChained);
}
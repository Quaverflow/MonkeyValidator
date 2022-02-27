using MonkeyValidator.Validator;
using MonkeyValidator.Validator.Extensions;

namespace MonkeyValidatorTests;

public class TestClassChainedValidator : CustomMonkeyValidatorBase<TestClassChained>
{

    protected override MonkeyClassValidator<TestClassChained> SetupValidator(TestClassChained instance)
        => instance.BuildValidator(y => y.Number.GetValidator()
                .ShouldBeMoreThan(4))
            .Chain(new TestClassChainedNestedValidator(), instance.TestClassChainedNested);
}
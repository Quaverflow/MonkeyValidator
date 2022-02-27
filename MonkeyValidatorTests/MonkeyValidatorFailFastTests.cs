using System;
using MonkeyValidator.Validator.Extensions;
using Xunit;

namespace MonkeyValidatorTests;

public class MonkeyValidatorFailFastTests
{
    [Fact]
    public void Test_ConditionalValidation()
    {
        Assert.Throws<InvalidOperationException>(() => 3.GetValidator().FailFastIf(x => x != 5, new InvalidOperationException()).Execute());
        3.GetValidator().FailFastIf(x => x == 5, new InvalidOperationException()).Execute();
    }
}
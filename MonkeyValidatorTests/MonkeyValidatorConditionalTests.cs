using MonkeyValidator.Validator;
using MonkeyValidator.Validator.Extensions;
using Xunit;

namespace MonkeyValidatorTests;

public class MonkeyValidatorConditionalTests
{
    [Fact]
    public void Test_ConditionalValidation()
    {
        3.GetValidator().ConditionalValidation(x => x
            .If(y => y > 4, y => y.ShouldBeEqualTo(5))
            .ElseIf(y => y != 3, y => y.ShouldBeEqualTo(4))
            .ElseIf(y => y == 5, y => y.ShouldBeEqualTo(4))
            .Else(y => y.ShouldBeEqualTo(3))
            ).Execute();
    }

    [Fact]
    public void Test_ConditionalValidationComplex()
    {
        const int sut = 3;
        sut.GetValidator()
            .ShouldBeMoreOrEqualTo(2)
            .ShouldBeLessOrEqualTo(100)
            .ConditionalValidation(x => x
                .If(y => y > 4, y => y.ShouldBeEqualTo(5))
                .ElseIf(y => y != 3, y => y.ShouldBeEqualTo(4))
                .ElseIf(y => y == 5, y => y.ShouldBeEqualTo(4))
                .Else(y => y.ShouldBeEqualTo(3)))
            .ConditionalValidation(x => x
                .If(y => y % 4 == 2, y => y.ShouldBeEqualTo(5))
                .Else(y => y.ShouldNotBeMultipleOf(53)))
            .ShouldBeMultipleOf(3)
            .Execute();
    }
}
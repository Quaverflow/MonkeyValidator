using MonkeyValidator.Validator;

namespace MonkeyValidatorTests;

public static class MonkeyValidatorFragments
{
    public static MonkeyValidator<TestClass> SumLengthOfStringAndNumberShouldBe(this MonkeyValidator<TestClass> validator, int sum)
    {
        var actual = validator.Sut.Number + validator.Sut.String.Length;
        if (actual != sum)
        {
            validator.Errors.Add($"Expected sum to be {sum} but instead was {actual}");
        }

        return validator;
    }
}
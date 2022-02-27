namespace MonkeyValidator.Validator.Extensions;

public static class MonkeyValidatorBoolExtensions
{
    public static MonkeyValidator<bool> ShouldBeTrue(this MonkeyValidator<bool> validator, string? message = null)
    {
        if (!validator.Sut)
        {
            validator.AddError(message ?? $"Expected to not be true");
        }

        return validator;
    }

    public static MonkeyValidator<bool> ShouldBeFalse(this MonkeyValidator<bool> validator, string? message = null)
    {
        if (validator.Sut)
        {
            validator.AddError(message ?? $"Expected to not be false");
        }

        return validator;
    }

    public static MonkeyValidator<bool?> ShouldHaveValueTrue(this MonkeyValidator<bool?> validator, string? message = null)
    {
        if (validator.Sut is null or false)
        {
            validator.AddError(message ?? $"Expected to not be true");
        }

        return validator;
    }

    public static MonkeyValidator<bool?> ShouldHaveValueFalse(this MonkeyValidator<bool?> validator, string? message = null)
    {
        if (validator.Sut is null or true)
        {
            validator.AddError(message ?? $"Expected to not be false");
        }

        return validator;
    }

}
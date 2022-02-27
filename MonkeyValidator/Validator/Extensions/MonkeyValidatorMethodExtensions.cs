namespace MonkeyValidator.Validator.Extensions;

public static class MonkeyValidatorMethodExtensions
{
    public static MonkeyValidator<T> MethodShouldReturn<T, TResult>(this MonkeyValidator<T> validator, Func<T, TResult> predicate, TResult? expected, string? message = null)
    {
        var result = predicate.Invoke(validator.Sut);
        if (result == null && expected == null)
        {
            return validator;
        }

        if (result == null || !result.Equals(expected))
        {
            validator.AddError(message ?? $"Expectations not met for {validator.Sut}");
        }

        return validator;
    }

}
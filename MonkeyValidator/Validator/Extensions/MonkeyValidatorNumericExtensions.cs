namespace MonkeyValidator.Validator.Extensions;

public static class MonkeyValidatorNumericExtensions
{
    public static MonkeyValidator<T> ShouldBeMoreThan<T>(this MonkeyValidator<T> validator, T actual, string? message = null)
        where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
    {

        if (validator.Sut.CompareTo(actual) <= 0)
        {
            validator.AddError(message ?? $"Expected {validator.Sut} to be more than {actual}");
        }

        return validator;
    }  

    public static MonkeyValidator<T> ShouldBeMoreOrEqualTo<T>(this MonkeyValidator<T> validator, T actual, string? message = null)
        where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
    {

        if (validator.Sut.CompareTo(actual) < 0)
        {
            validator.AddError(message ?? $"Expected {validator.Sut} to be more or equal to {actual}");
        }

        return validator;
    }

    public static MonkeyValidator<T> ShouldBeLessThan<T>(this MonkeyValidator<T> validator, T actual, string? message = null)
        where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
    {

        if (validator.Sut.CompareTo(actual) >= 0)
        {
            validator.AddError(message ?? $"Expected {validator.Sut} to be less than {actual}");
        }

        return validator;
    }

    public static MonkeyValidator<T> ShouldBeLessOrEqualTo<T>(this MonkeyValidator<T> validator, T actual, string? message = null)
        where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
    {

        if (validator.Sut.CompareTo(actual) > 0)
        {
            validator.AddError(message ?? $"Expected {validator.Sut} to be less or equal to {actual}");
        }

        return validator;
    }

    public static MonkeyValidator<T> ShouldBeMultipleOf<T>(this MonkeyValidator<T> validator, T actual, string? message = null)
        where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
    {

        if (Convert.ToDouble(validator.Sut) % Convert.ToDouble(actual) != 0)
        {
            validator.AddError(message ?? $"Expected {validator.Sut} multiple of {actual}");
        }

        return validator;
    }
    public static MonkeyValidator<T> ShouldNotBeMultipleOf<T>(this MonkeyValidator<T> validator, T actual, string? message = null)
        where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
    {

        if (Convert.ToDouble(validator.Sut) % Convert.ToDouble(actual) == 0)
        {
            validator.AddError(message ?? $"Expected {validator.Sut} multiple of {actual}");
        }

        return validator;
    }
}
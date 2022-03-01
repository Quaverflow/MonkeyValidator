using System.Collections;
using MonkeyValidator.Validator.ConditionalValidation;

namespace MonkeyValidator.Validator.Extensions;

public static class MonkeyValidatorCollectionExtensions
{
    private static int Count(this IEnumerable enumerable)
    {
        var count = 0;
        var enumerator = enumerable.GetEnumerator();
        while (enumerator.MoveNext())
        {
            count++;
        }

        return count;
    }

    public static MonkeyValidator<TCollection> ValidateForeach<TCollection, TValue>(this MonkeyValidator<TCollection> validator, 
        Func<MonkeyValidator<TValue>, MonkeyValidator<TValue>> rules) 
        where TCollection : IEnumerable<TValue>
    {
        foreach (var value in validator.Sut)
        {
            var valueValidator = value.GetValidator();
                rules.Invoke(valueValidator);

            if (valueValidator.Errors.Any())
            {
                validator.Errors.AddRange(valueValidator.Errors);
            }
        }

        return validator;
    }


    #region Counting

    public static MonkeyValidator<T> CountShouldBeEqualToCountOf<T>(this MonkeyValidator<T> validator, T expected, string? message = null) where T : IEnumerable
    {
        if (validator.Sut.Count() != expected.Count())
        {
            validator.AddError(message ?? $"Expected {validator.Sut} to be equal to {expected}");
        }

        return validator;
    }

    public static MonkeyValidator<T> CountShouldBeMoreThanCountOf<T>(this MonkeyValidator<T> validator, T expected, string? message = null) where T : IEnumerable
    {
        if (validator.Sut.Count() <= expected.Count())
        {
            validator.AddError(message ?? $"Expected {validator.Sut} to be more than {expected}");
        }

        return validator;
    }

    public static MonkeyValidator<T> CountShouldBeMoreOrEqualToCountOf<T>(this MonkeyValidator<T> validator, T expected, string? message = null) where T : IEnumerable
    {

        if (validator.Sut.Count() < expected.Count())
        {
            validator.AddError(message ?? $"Expected {validator.Sut} to be more or equal to {expected}");
        }

        return validator;
    }

    public static MonkeyValidator<T> CountShouldBeLessThanCountOf<T>(this MonkeyValidator<T> validator, T expected, string? message = null) where T : IEnumerable
    {

        if (validator.Sut.Count() >= expected.Count())
        {
            validator.AddError(message ?? $"Expected {validator.Sut} to be less than {expected}");
        }

        return validator;
    }

    public static MonkeyValidator<T> CountShouldBeLessOrEqualToCountOf<T>(this MonkeyValidator<T> validator, T expected, string? message = null) where T : IEnumerable
    {

        if (validator.Sut.Count() > expected.Count())
        {
            validator.AddError(message ?? $"Expected {validator.Sut} to be less or equal to {expected}");
        }

        return validator;
    }

    public static MonkeyValidator<T> CountShouldBeEqualTo<T>(this MonkeyValidator<T> validator, int expected, string? message = null) where T : IEnumerable
    {
        if (validator.Sut.Count() != expected)
        {
            validator.AddError(message ?? $"Expected {validator.Sut} to be equal to {expected}");
        }

        return validator;
    }

    public static MonkeyValidator<T> CountShouldBeMoreThan<T>(this MonkeyValidator<T> validator, int expected, string? message = null) where T : IEnumerable
    {
        if (validator.Sut.Count() <= expected)
        {
            validator.AddError(message ?? $"Expected {validator.Sut} to be more than {expected}");
        }

        return validator;
    }

    public static MonkeyValidator<T> CountShouldBeMoreOrEqualTo<T>(this MonkeyValidator<T> validator, int expected, string? message = null) where T : IEnumerable
    {

        if (validator.Sut.Count() < expected)
        {
            validator.AddError(message ?? $"Expected {validator.Sut} to be more or equal to {expected}");
        }

        return validator;
    }

    public static MonkeyValidator<T> CountShouldBeLessThan<T>(this MonkeyValidator<T> validator, int expected, string? message = null) where T : IEnumerable
    {

        if (validator.Sut.Count() >= expected)
        {
            validator.AddError(message ?? $"Expected {validator.Sut} to be less than {expected}");
        }

        return validator;
    }

    public static MonkeyValidator<T> CountShouldBeLessOrEqualTo<T>(this MonkeyValidator<T> validator, int expected, string? message = null) where T : IEnumerable
    {

        if (validator.Sut.Count() > expected)
        {
            validator.AddError(message ?? $"Expected {validator.Sut} to be less or equal to {expected}");
        }

        return validator;
    }

    public static MonkeyValidator<T> ShouldBeEmpty<T>(this MonkeyValidator<T> validator, string? message = null) where T : IEnumerable
    {
        if (validator.Sut.Count() != 0)
        {
            validator.AddError(message ?? $"Expected {validator.Sut} to be empty");
        }

        return validator;
    }

    public static MonkeyValidator<T> ShouldNotBeEmpty<T>(this MonkeyValidator<T> validator, string? message = null) where T : IEnumerable
    {
        if (validator.Sut.Count() == 0)
        {
            validator.AddError(message ?? $"Expected {validator.Sut} to contain values");
        }

        return validator;
    }

    #endregion

    #region Containing

    public static MonkeyValidator<T> ShouldContain<T, TValue>(this MonkeyValidator<T> validator, TValue expected, string? message = null) where T : IEnumerable
    {
        if (!validator.Sut.Cast<TValue>().Contains(expected))
        {
            validator.AddError(message ?? $"Expected {validator.Sut} to contain {expected}");
        }

        return validator;
    }

    public static MonkeyValidator<T> ShouldNotContain<T, TValue>(this MonkeyValidator<T> validator, TValue expected, string? message = null) where T : IEnumerable
    {
        if (validator.Sut.Cast<TValue>().Contains(expected))
        {
            validator.AddError(message ?? $"Expected {validator.Sut} to not contain {expected}");
        }

        return validator;
    }

    public static MonkeyValidator<T> ShouldContainMany<T, TValue>(this MonkeyValidator<T> validator, TValue expected, string? message = null) where T : IEnumerable
    {
        if (validator.Sut.Cast<TValue>().Count(x => x != null && x.Equals(expected)) <= 1)
        {
            validator.AddError(message ?? $"Expected {validator.Sut} to contain many {expected}");
        }

        return validator;
    }

    public static MonkeyValidator<T> ShouldContainSingle<T, TValue>(this MonkeyValidator<T> validator, TValue expected, string? message = null) where T : IEnumerable
    {
        if (validator.Sut.Cast<TValue>().Count(x => x != null && x.Equals(expected)) != 1)
        {
            validator.AddError(message ?? $"Expected {validator.Sut} to contain one {expected}");
        }

        return validator;
    }

    public static MonkeyValidator<T> ShouldContainThisMany<T, TValue>(this MonkeyValidator<T> validator, TValue expected, int amount, string? message = null) where T : IEnumerable
    {
        if (validator.Sut.Cast<TValue>().Count(x => x != null && x.Equals(expected)) != amount)
        {
            validator.AddError(message ?? $"Expected {validator.Sut} to contain {amount} {expected}");
        }

        return validator;
    }

    #endregion


}
namespace MonkeyValidator.Validator.Extensions;

public static class MonkeyValidatorStringExtensions
{
    #region Length

    public static MonkeyValidator<string> LengthShouldBe(this MonkeyValidator<string> validator, int expected, string? message = null)
    {
        if (validator.Sut.Length != expected)
        {
            validator.AddError(message ?? $"Expected to be of length ({expected}) actual ({validator.Sut.Length})");
        }

        return validator;
    }

    public static MonkeyValidator<string> LengthShouldBeLessThan(this MonkeyValidator<string> validator, int expected, string? message = null)
    {
        if (validator.Sut.Length >= expected)
        {
            validator.AddError(message ?? $"Expected length to be lesser than ({expected}) actual ({validator.Sut.Length})");
        }

        return validator;
    }

    public static MonkeyValidator<string> LengthShouldBeLessOrEqualTo(this MonkeyValidator<string> validator, int expected, string? message = null)
    {
        if (validator.Sut.Length > expected)
        {
            validator.AddError(message ?? $"Expected length to be lesser or equal to ({expected}) actual ({validator.Sut.Length})");
        }

        return validator;
    }

    public static MonkeyValidator<string> LengthShouldBeMoreThan(this MonkeyValidator<string> validator, int expected, string? message = null)
    {
        if (validator.Sut.Length <= expected)
        {
            validator.AddError(message ?? $"Expected length to be more than ({expected}) actual ({validator.Sut.Length})");
        }

        return validator;
    }

    public static MonkeyValidator<string> LengthShouldBeMoreOrEqualTo(this MonkeyValidator<string> validator, int expected, string? message = null)
    {
        if (validator.Sut.Length < expected)
        {
            validator.AddError(message ?? $"Expected length to be more or equal to ({expected}) actual ({validator.Sut.Length})");
        }

        return validator;
    }

    #endregion

    #region Contains

    //Any
    public static MonkeyValidator<string> ShouldContainAnyAmountOf(this MonkeyValidator<string> validator, char @char, bool ignoreCase, string? message = null)
    {
        var contains = ignoreCase ? validator.Sut.Contains(@char, StringComparison.InvariantCultureIgnoreCase) : validator.Sut.Contains(@char);

        if (!contains)
        {
            validator.AddError(message ?? $"Expected to contain ({@char}) in ({validator.Sut})");
        }

        return validator;
    }

    public static MonkeyValidator<string> ShouldContainAnyAmountOf(this MonkeyValidator<string> validator, string expected, bool ignoreCase, string? message = null)
    {
        var contains = ignoreCase ? validator.Sut.Contains(expected, StringComparison.InvariantCultureIgnoreCase) : validator.Sut.Contains(expected);

        if (!contains)
        {
            validator.AddError(message ?? $"Expected to contain ({expected}) in ({validator.Sut})");
        }

        return validator;
    }

    //None
    public static MonkeyValidator<string> ShouldNotContainAny(this MonkeyValidator<string> validator, char @char, bool ignoreCase, string? message = null)
    {
        var contains = ignoreCase ? validator.Sut.Contains(@char, StringComparison.InvariantCultureIgnoreCase) : validator.Sut.Contains(@char);

        if (contains)
        {
            validator.AddError(message ?? $"Expected to contain ({@char}) in ({validator.Sut})");
        }

        return validator;
    }

    public static MonkeyValidator<string> ShouldNotContainAny(this MonkeyValidator<string> validator, string expected, bool ignoreCase, string? message = null)
    {
        var contains = ignoreCase ? validator.Sut.Contains(expected, StringComparison.InvariantCultureIgnoreCase) : validator.Sut.Contains(expected);

        if (contains)
        {
            validator.AddError(message ?? $"Expected to contain ({expected}) in ({validator.Sut})");
        }

        return validator;
    }

    //Single
    public static MonkeyValidator<string> ShouldContainSingle(this MonkeyValidator<string> validator, char @char, bool ignoreCase, string? message = null)
    {
        var count = ignoreCase ? validator.Sut.ToLower().Count(x => x == char.ToLower(@char)) : validator.Sut.Count(x => x == @char);
        if (count != 1)
        {
            validator.AddError(message ?? $"Expected to contain single ({@char}) actual ({count})");
        }

        return validator;
    }

    public static MonkeyValidator<string> ShouldContainSingle(this MonkeyValidator<string> validator, string substring, bool ignoreCase, string? message = null)
    {
        var count = ignoreCase ? SubstringCount(validator.Sut.ToLower(), substring.ToLower()) : SubstringCount(validator.Sut, substring);
        if (count != 1)
        {
            validator.AddError(message ?? $"Expected to contain single ({substring}) actual ({count})");
        }

        return validator;
    }

    //Multiple
    public static MonkeyValidator<string> ShouldContainMultiple(this MonkeyValidator<string> validator, char @char, bool ignoreCase, string? message = null)
    {
        var count = ignoreCase ? validator.Sut.ToLower().Count(x => x == char.ToLower(@char)) : validator.Sut.Count(x => x == @char);
        if (count <= 1)
        {
            validator.AddError(message ?? $"Expected to contain multiple ({@char}) actual ({count})");
        }

        return validator;
    }

    public static MonkeyValidator<string> ShouldContainMultiple(this MonkeyValidator<string> validator, string substring, bool ignoreCase, string? message = null)
    {
        var count = ignoreCase ? SubstringCount(validator.Sut.ToLower(), substring.ToLower()) : SubstringCount(validator.Sut, substring);
        if (count <= 1)
        {
            validator.AddError(message ?? $"Expected to contain multiple ({substring}) actual ({count})");
        }

        return validator;
    }

    //Amount
    public static MonkeyValidator<string> ShouldContain(this MonkeyValidator<string> validator, int expected, char @char, bool ignoreCase, string? message = null)
    {
        var count = ignoreCase ? validator.Sut.ToLower().Count(x => x == char.ToLower(@char)) : validator.Sut.Count(x => x == @char);
        if (count != expected)
        {
            validator.AddError(message ?? $"Expected to contain exactly ({expected} {@char}) actual ({count})");
        }

        return validator;
    }

    public static MonkeyValidator<string> ShouldContain(this MonkeyValidator<string> validator, int expected, string substring, bool ignoreCase, string? message = null)
    {
        var count = ignoreCase ? SubstringCount(validator.Sut.ToLower(), substring.ToLower()) : SubstringCount(validator.Sut, substring);
        if (count != expected)
        {
            validator.AddError(message ?? $"Expected to contain exactly ({expected} {substring}) actual ({count})");
        }

        return validator;
    }

    //More than
    public static MonkeyValidator<string> ShouldContainMoreThan(this MonkeyValidator<string> validator, int expected, char @char, bool ignoreCase, string? message = null)
    {
        var count = ignoreCase ? validator.Sut.ToLower().Count(x => x == char.ToLower(@char)) : validator.Sut.Count(x => x == @char);
        if (count <= expected)
        {
            validator.AddError(message ?? $"Expected to contain more than ({expected} {@char}) actual ({count})");
        }

        return validator;
    }

    public static MonkeyValidator<string> ShouldContainMoreThan(this MonkeyValidator<string> validator, int expected, string substring, bool ignoreCase, string? message = null)
    {
        var count = ignoreCase ? SubstringCount(validator.Sut.ToLower(), substring.ToLower()) : SubstringCount(validator.Sut, substring);
        if (count <= expected)
        {
            validator.AddError(message ?? $"Expected to contain more than ({expected} {substring}) actual ({count})");
        }

        return validator;
    }

    //More or equal than
    public static MonkeyValidator<string> ShouldContainMoreOrEqualTo(this MonkeyValidator<string> validator, int expected, char @char, bool ignoreCase, string? message = null)
    {
        var count = ignoreCase ? validator.Sut.ToLower().Count(x => x == char.ToLower(@char)) : validator.Sut.Count(x => x == @char);
        if (count < expected)
        {
            validator.AddError(message ?? $"Expected to contain more or equal than ({expected} {@char}) actual ({count})");
        }

        return validator;
    }

    public static MonkeyValidator<string> ShouldContainMoreOrEqualTo(this MonkeyValidator<string> validator, int expected, string substring, bool ignoreCase, string? message = null)
    {
        var count = ignoreCase ? SubstringCount(validator.Sut.ToLower(), substring.ToLower()) : SubstringCount(validator.Sut, substring);
        if (count < expected)
        {
            validator.AddError(message ?? $"Expected to contain more or equal than ({expected} {substring}) actual ({count})");
        }

        return validator;
    }

    //More than
    public static MonkeyValidator<string> ShouldContainLessThan(this MonkeyValidator<string> validator, int expected, char @char, bool ignoreCase, string? message = null)
    {
        var count = ignoreCase ? validator.Sut.ToLower().Count(x => x == char.ToLower(@char)) : validator.Sut.Count(x => x == @char);
        if (count >= expected)
        {
            validator.AddError(message ?? $"Expected to contain less than ({expected} {@char}) actual ({count})");
        }

        return validator;
    }

    public static MonkeyValidator<string> ShouldContainLessThan(this MonkeyValidator<string> validator, int expected, string substring, bool ignoreCase, string? message = null)
    {
        var count = ignoreCase ? SubstringCount(validator.Sut.ToLower(), substring.ToLower()) : SubstringCount(validator.Sut, substring);
        if (count >= expected)
        {
            validator.AddError(message ?? $"Expected to contain less than ({expected} {substring}) actual ({count})");
        }

        return validator;
    }

    //More or equal than
    public static MonkeyValidator<string> ShouldContainLessOrEqualTo(this MonkeyValidator<string> validator, int expected, char @char, bool ignoreCase, string? message = null)
    {
        var count = ignoreCase ? validator.Sut.ToLower().Count(x => x == char.ToLower(@char)) : validator.Sut.Count(x => x == @char);
        if (count > expected)
        {
            validator.AddError(message ?? $"Expected to contain less or equal than ({expected} {@char}) actual ({count})");
        }

        return validator;
    }

    public static MonkeyValidator<string> ShouldContainLessOrEqualTo(this MonkeyValidator<string> validator, int expected, string substring, bool ignoreCase, string? message = null)
    {
        var count = ignoreCase ? SubstringCount(validator.Sut.ToLower(), substring.ToLower()) : SubstringCount(validator.Sut, substring);
        if (count > expected)
        {
            validator.AddError(message ?? $"Expected to contain less or equal than ({expected} {substring}) actual ({count})");
        }

        return validator;
    }

    //Starts with
    public static MonkeyValidator<string> ShouldStartWith(this MonkeyValidator<string> validator, char @char, bool ignoreCase, string? message = null)
    {
        var startsWith = ignoreCase ? validator.Sut.StartsWith(char.ToLower(@char)) : validator.Sut.StartsWith(@char);
        if (!startsWith)
        {
            validator.AddError(message ?? $"Expected to start with ({@char}) actual ({validator.Sut[0]})");
        }

        return validator;
    }

    public static MonkeyValidator<string> ShouldStartWith(this MonkeyValidator<string> validator, string substring, bool ignoreCase, string? message = null)
    {
        var startsWith = ignoreCase ? validator.Sut.StartsWith(substring, StringComparison.InvariantCultureIgnoreCase) : validator.Sut.StartsWith(substring);
        if (!startsWith)
        {
            var toDisplayInMessage = substring.Length > validator.Sut.Length
                ? validator.Sut
                : validator.Sut[..substring.Length];
            validator.AddError(message ?? $"Expected to start with ({substring}) actual ({toDisplayInMessage})");
        }

        return validator;
    }

    //Starts with
    public static MonkeyValidator<string> ShouldEndWith(this MonkeyValidator<string> validator, char @char, bool ignoreCase, string? message = null)
    {
        var endsWith = ignoreCase ? validator.Sut.EndsWith(char.ToLower(@char)) : validator.Sut.EndsWith(@char);
        if (!endsWith)
        {
            validator.AddError(message ?? $"Expected to end with ({@char}) actual ({validator.Sut.Last()})");
        }

        return validator;
    }

    public static MonkeyValidator<string> ShouldEndWith(this MonkeyValidator<string> validator, string substring, bool ignoreCase, string? message = null)
    {
        var endsWith = ignoreCase ? validator.Sut.EndsWith(substring, StringComparison.InvariantCultureIgnoreCase) : validator.Sut.EndsWith(substring);
        if (!endsWith)
        {
            var toDisplayInMessage = substring.Length > validator.Sut.Length
                ? validator.Sut
                : validator.Sut[^substring.Length..];

            validator.AddError(message ?? $"Expected to end with ({substring}) actual {toDisplayInMessage}");
        }

        return validator;
    }

    private static int SubstringCount(string toVerify, string toSearch)
    {
        var count = 0;

        var index = toVerify.IndexOf(toSearch, StringComparison.Ordinal);

        var sum = index + toSearch.Length;
        if (index != -1)
        {
            count++;

            if (sum < toVerify.Length)
            {
                var substring = toVerify[sum..];
                count += SubstringCount(substring, toSearch);
            }
        }

        return count;
    }

    #endregion
}
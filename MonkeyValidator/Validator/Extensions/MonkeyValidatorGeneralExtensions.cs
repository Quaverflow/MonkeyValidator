using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MonkeyValidator.Validator.Extensions;

public static class MonkeyValidatorGeneralExtensions
{
    /// <summary>
    /// Create an instance of the MonkeyValidator class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="sut"></param>
    /// <param name="ruleForName"></param>
    /// <returns></returns>
    public static MonkeyValidator<T> GetValidator<T>(this T sut, [CallerArgumentExpression("sut")] string? ruleForName = null) => new(sut, ruleForName);

    /// <summary>
    /// Throws an exception if there are errors, containing the a list of Errors and a formatted string version in Message
    /// </summary>
    /// <param name="validator"></param>
    /// <exception cref="MonkeyValidatorException"></exception>
    public static void Execute(this IMonkeyValidator validator)
    {
        if (validator.Errors.Any())
        {
            var errors = new List<string>(validator.Errors);
            validator.Errors.Clear();
            throw new MonkeyValidatorException(errors);
        }
    }

    /// <summary>
    /// Allows you to pass your own logic in the event of validation failure, passing the Error list into your Action.
    /// </summary>
    /// <param name="validator"></param>
    /// <param name="onValidationFailed"></param>
    public static void Execute(this IMonkeyValidator validator, Action<List<string>> onValidationFailed, bool throwMonkeyException = false)
    {
        if (validator.Errors.Any())
        {
            var errors = new List<string>(validator.Errors);
            validator.Errors.Clear();
            onValidationFailed.Invoke(errors);

            if (throwMonkeyException)
            {
                throw new MonkeyValidatorException(errors);
            }
        }
    }

    /// <summary>
    /// Creates an on-the-fly rule to chain to the rest.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="validator"></param>
    /// <param name="predicate"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static MonkeyValidator<T> CustomRule<T>(this MonkeyValidator<T> validator, Func<T, bool> predicate, string? message = null)
    {
        if (!predicate.Invoke(validator.Sut))
        {
            validator.AddError(message ?? $"Expectations not met for {validator.Sut}");
        }

        return validator;
    }

    #region Equality

    public static MonkeyValidator<T> ShouldBeEqualTo<T>(this MonkeyValidator<T> validator, T expected, string? message = null)
    {
        if (!Equals(validator.Sut, expected))
        {
            validator.AddError(message ?? $"Expected {expected}, actual {validator.Sut}");
        }

        return validator;
    }

    public static MonkeyValidator<T> ShouldBe<T>(this MonkeyValidator<T> validator, Func<T, bool> expected, string? message = null)
    {
        if (!expected.Invoke(validator.Sut))
        {
            validator.AddError(message ?? $"Expectations failed on value {validator.Sut}");
        }

        return validator;
    }

    #endregion

    #region Nullability

    public static MonkeyValidator<T> ShouldBeNull<T>(this MonkeyValidator<T> validator, string? message = null)
    {
        if (validator.Sut != null)
        {
            validator.AddError(message ?? $"Expected to be null {validator.Sut}");
        }

        return validator;
    }

    public static MonkeyValidator<T> ShouldNotBeNull<T>(this MonkeyValidator<T> validator, string? message = null)
    {
        if (validator.Sut == null)
        {
            validator.AddError(message ?? $"Expected to not be null {validator.Sut}");
        }

        return validator;
    }

    #endregion

    #region Type

    public static MonkeyValidator<T> ShouldBeTypeOf<T>(this MonkeyValidator<T> validator, Type expected, string? message = null)
    {
        if (typeof(T) != expected)
        {
            validator.AddError(message ?? $"Expected type {typeof(T).Name} actual {expected.Name}");
        }

        return validator;
    }

    public static MonkeyValidator<T> ShouldNotBeTypeOf<T>(this MonkeyValidator<T> validator, Type expected, string? message = null)
    {
        if (typeof(T) == expected)
        {
            validator.AddError(message ?? $"Expected type {typeof(T).Name} actual {expected.Name}");
        }

        return validator;
    }

    public static MonkeyValidator<T> ShouldInheritFromTypeOf<T>(this MonkeyValidator<T> validator, Type expected, string? message = null)
    {
        var parents = GetParentTypes(typeof(T));
        if (!parents.Contains(expected))
        {
            validator.AddError(message ?? $"Expected {typeof(T).Name} to inherit from {expected.Name}");
        }

        return validator;
    }

    public static MonkeyValidator<T> ShouldNotInheritFromTypeOf<T>(this MonkeyValidator<T> validator, Type expected, string? message = null)
    {
        var parents = GetParentTypes(typeof(T));
        if (parents.Contains(expected))
        {
            validator.AddError(message ?? $"Expected {typeof(T).Name} to inherit from {expected.Name}");
        }

        return validator;
    }

    public static MonkeyValidator<T> ShouldImplementInterface<T>(this MonkeyValidator<T> validator, Type expected, string? message = null)
    {
        var parents = typeof(T).GetInterfaces();
        if (!parents.Contains(expected))
        {
            validator.AddError(message ?? $"Expected {typeof(T).Name} to inherit from {expected.Name}");
        }

        return validator;
    }

    public static MonkeyValidator<T> ShouldNotImplementInterface<T>(this MonkeyValidator<T> validator, Type expected, string? message = null)
    {
        var parents = typeof(T).GetInterfaces();
        if (parents.Contains(expected))
        {
            validator.AddError(message ?? $"Expected {typeof(T).Name} to inherit from {expected.Name}");
        }

        return validator;
    }

    private static List<Type> GetParentTypes(Type child)
    {
        var parents = new List<Type>();
        while (true)
        {
            if (child.BaseType == null)
            {
                break;
            };

            parents.Add(child.BaseType);
            child = child.BaseType;
        }

        return parents;
    }

    #endregion
}
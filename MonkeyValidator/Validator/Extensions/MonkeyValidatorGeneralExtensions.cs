using System.Runtime.CompilerServices;

namespace MonkeyValidator.Validator.Extensions;

public static class MonkeyValidatorGeneralExtensions
{
    public static MonkeyValidator<T> GetValidator<T>(this T sut, [CallerArgumentExpression("sut")] string? ruleForName = null) => new(sut, ruleForName);

    public static void Execute(this IMonkeyValidator validator)
    {
        if (validator.Errors.Any())
        {
            var errors = new List<string>(validator.Errors);
            validator.Errors.Clear();
            throw new MonkeyValidatorException(errors);
        }
    }

    public static void Execute(this IMonkeyValidator validator, Action<List<string>> onValidationFailed)
    {
        if (validator.Errors.Any())
        {
            var errors = new List<string>(validator.Errors);
            validator.Errors.Clear();
            onValidationFailed.Invoke(errors);
        }
    }

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
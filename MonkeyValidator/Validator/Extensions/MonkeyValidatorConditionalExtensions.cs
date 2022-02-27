using MonkeyValidator.Validator.ConditionalValidation;

namespace MonkeyValidator.Validator.Extensions;

public static class MonkeyValidatorConditionalExtensions
{
    public static MonkeyValidator<T> ConditionalValidation<T>(this MonkeyValidator<T> validator, params Func<MonkeyConditionalValidationContext<T>, IConditionalValidation<T>>[] validations)
    {
        foreach (var rule in validations)
        {
            rule.Invoke(new MonkeyConditionalValidationContext<T>(validator));
        }

        return validator;
    }

    public static IIfCondition<T> If<T>(this MonkeyConditionalValidationContext<T> context, Func<T, bool> predicate, Action<MonkeyValidator<T>> validationToExecute)
    {

        if (predicate.Invoke(context.Validator.Sut))
        {
            validationToExecute.Invoke(context.Validator);
            context.IfCondition.Fulfilled = true;
        }

        return context.IfCondition;
    }

    public static IIfCondition<T> ElseIf<T>(this IIfCondition<T> context, Func<T, bool> predicate, Action<MonkeyValidator<T>> validationToExecute)
    {
        if (context.Fulfilled || !predicate.Invoke(context.Validator.Sut))
        {
            return context;
        }

        validationToExecute.Invoke(context.Validator);
        context.Fulfilled = true;

        return context;
    }

    public static IConditionalValidation<T> Else<T>(this IIfCondition<T> context, Action<MonkeyValidator<T>> validationToExecute)
    {
        if (context.Fulfilled)
        {
            return context;
        }
        validationToExecute.Invoke(context.Validator);

        return context;
    }
}
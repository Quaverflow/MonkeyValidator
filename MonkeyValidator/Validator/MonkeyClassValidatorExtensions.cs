using System.Data;
using System.Text;
using MonkeyValidator.Utilities;
using MonkeyValidator.Validator.Extensions;

namespace MonkeyValidator.Validator;

public static class MonkeyClassValidatorExtensions
{
    public static MonkeyClassValidator<T> BuildValidator<T>(this T instance, params Func<T, IMonkeyValidator>[] rules) where T : class
    {
        var validator = new MonkeyClassValidator<T>();

        foreach (var rule in rules)
        {
            try
            {
                validator.Validators.Add(rule.Invoke(instance));
            }
            catch (Exception e)
            {
                validator.Validators.Add(rule.GetValidator("Something went wrong").CustomRule(x => 1 == 2, e.GetFullStack().ToString()));
            }
        }
        return validator;
    }

    private static StringBuilder GetFullStack(this Exception e, StringBuilder? stringBuilder = null)
    {
        stringBuilder ??= new StringBuilder();
        stringBuilder.Append(e.Message + e.StackTrace);
        if (e.InnerException != null)
        {
            stringBuilder.Append(e.GetFullStack(stringBuilder));
        }

        return stringBuilder;
    }


    public static void Validate(this List<IMonkeyClassValidator> classValidators)
    {
        classValidators.ThrowIfNull();
        var errors = classValidators.SelectMany(x => x.Validators.SelectMany(y => y.Errors)).ToList();
        if (errors.Any())
        {
            throw new MonkeyValidatorException(errors);
        }
    }

    public static void Validate(this List<IMonkeyClassValidator> classValidators, Action<List<string>> onValidationFailed)
    {
        classValidators.ThrowIfNull();
        var errors = classValidators.SelectMany(x => x.Validators.SelectMany(y => y.Errors)).ToList();
        if (errors.Any())
        {
            onValidationFailed.Invoke(errors);
        }
    }

    /// <summary>
    /// Allows you to run multiple validators and get a single result out. If the chained validators has chains, those will be run as well.
    /// </summary>
    /// <typeparam name="TParent"></typeparam>
    /// <typeparam name="TChild"></typeparam>
    /// <param name="parent"></param>
    /// <param name="chain"></param>
    /// <param name="instance"></param>
    /// <returns></returns>
    public static MonkeyClassValidator<TParent> Chain<TParent, TChild>(this MonkeyClassValidator<TParent> parent, CustomMonkeyValidatorBase<TChild> chain, TChild instance)
        where TChild : class where TParent : class
    {
        var validator = chain.SetupInternal(instance);
        parent.Validators.AddRange(validator.Validators);
        return parent;
    }
}
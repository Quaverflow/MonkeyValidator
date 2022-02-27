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
            catch(Exception e)
            {
                //workaround for now
                validator.Validators.Add(rule.GetValidator("Something went wrong").CustomRule(x=> 1 == 2, e.GetFullStack().ToString()));
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


    public static void Validate<T>(this MonkeyClassValidator<T> classValidator) where T : class
    {
        classValidator.ThrowIfNull();
        var errors = classValidator.Validators.SelectMany(x => x.Errors).ToList();
        if (errors.Any())
        {
            throw new MonkeyValidatorException(errors);
        }
    }
}
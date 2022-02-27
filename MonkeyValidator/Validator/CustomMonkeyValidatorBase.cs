
using MonkeyValidator.Utilities;

namespace MonkeyValidator.Validator;

public abstract class CustomMonkeyValidatorBase<T>
{
    internal readonly List<IMonkeyClassValidator> Validators = new();

    /// <summary>
    /// Throws an exception if there are errors, containing the a list of Errors and a formatted string version in Message
    /// </summary>
    /// <param name="instance"></param>
    /// <exception cref="MonkeyValidatorException"></exception>

    public void Validate(T instance)
    {
        Validators.Add(SetupValidator(instance));
        Validators.Validate();
    }

    /// <summary>
    /// Allows you to pass your own logic in the event of validation failure, passing the Error list into your Action.
    /// </summary>
    /// <param name="instance"></param>
    /// <param name="onValidationFailed"></param>
    public void Validate(T instance, Action<List<string>> onValidationFailed)
    {
        Validators.Add(SetupValidator(instance));
        Validators.Validate(onValidationFailed);
    }

    /// <summary>
    /// Called internally when executing the Validate method.
    /// </summary>
    /// <param name="instance"></param>
    /// <returns></returns>
    protected abstract MonkeyClassValidator<T> SetupValidator(T instance);
    internal MonkeyClassValidator<T> SetupInternal(T instance) => SetupValidator(instance);

}


using MonkeyValidator.Utilities;

namespace MonkeyValidator.Validator;

public abstract class CustomMonkeyValidatorBase<T>
{
    internal readonly List<IMonkeyClassValidator> Validators = new();

    public void Validate(T instance)
    {
        Validators.Add(SetupValidator(instance));
        Validators.Validate();
    }
    public void Validate(T instance, Action<List<string>> onValidationFailed)
    {
        Validators.Add(SetupValidator(instance));
        Validators.Validate(onValidationFailed);
    }

    protected abstract MonkeyClassValidator<T> SetupValidator(T instance);
    internal MonkeyClassValidator<T> SetupInternal(T instance) => SetupValidator(instance);

}

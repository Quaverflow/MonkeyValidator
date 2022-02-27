
using MonkeyValidator.Utilities;

namespace MonkeyValidator.Validator;

public abstract class CustomMonkeyValidatorBase<T> where T : class
{
    public void Validate(T instance)
    {
        var validator = BuildValidator(instance);
        validator.ThrowIfNull("You must setup your Validator in the constructor of your Custom Validator, before you can use it.");
        validator.Validate();
    }

    protected abstract MonkeyClassValidator<T> BuildValidator(T instance);
}
namespace MonkeyValidator.Validator.Extensions;

public static class MonkeyValidatorFailFastExtensions
{
    public static MonkeyValidator<T> FailFastIf<T, TException>(this MonkeyValidator<T> validator, Func<T, bool> predicate, TException exception) 
        where TException:Exception
    {
       
        if (predicate.Invoke(validator.Sut))
        {
            throw exception;
        }

        return validator;
    }
}

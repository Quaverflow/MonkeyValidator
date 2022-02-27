namespace MonkeyValidator.Validator.ConditionalValidation;

public interface IConditionalValidation<T>
{
    public MonkeyValidator<T> Validator { get; set; }
}
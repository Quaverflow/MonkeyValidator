namespace MonkeyValidator.Validator.ConditionalValidation;

public interface IConditionalMonkeyValidation<T>
{
    public MonkeyValidator<T> Validator { get; set; }
}
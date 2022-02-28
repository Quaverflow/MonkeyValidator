namespace MonkeyValidator.Validator.ConditionalValidation;

public interface IIfCondition<T> : IConditionalMonkeyValidation<T>
{
    public bool Fulfilled { get; set; }
}
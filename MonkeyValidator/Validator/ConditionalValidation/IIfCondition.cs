namespace MonkeyValidator.Validator.ConditionalValidation;

public interface IIfCondition<T> : IConditionalValidation<T>
{
    public bool Fulfilled { get; set; }
}
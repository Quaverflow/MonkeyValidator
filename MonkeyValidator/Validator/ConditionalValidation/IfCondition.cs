namespace MonkeyValidator.Validator.ConditionalValidation;

internal class IfCondition<T> : IIfCondition<T>
{
    public IfCondition(MonkeyValidator<T> validator)
    {
        Validator = validator;
    }

    public MonkeyValidator<T> Validator { get; set; }
    public bool Fulfilled { get; set; }
}
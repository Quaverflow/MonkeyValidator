namespace MonkeyValidator.Validator.ConditionalValidation;

public class MonkeyConditionalValidationContext<T> : IConditionalMonkeyValidation<T>
{
    public MonkeyConditionalValidationContext(MonkeyValidator<T> validator)
    {
        Validator = validator;
        IfCondition = new IfCondition<T>(Validator);
    }

    internal IfCondition<T> IfCondition { get; set; }
    public MonkeyValidator<T> Validator { get; set; }

}
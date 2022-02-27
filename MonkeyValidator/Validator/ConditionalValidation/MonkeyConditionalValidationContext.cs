namespace MonkeyValidator.Validator.ConditionalValidation;

public class MonkeyConditionalValidationContext<T> : IConditionalValidation<T>
{
    public MonkeyConditionalValidationContext(MonkeyValidator<T> validator)
    {
        Validator = validator;
        IfCondition = new IfCondition<T>(Validator);
    }

    public IfCondition<T> IfCondition { get; set; }
    public MonkeyValidator<T> Validator { get; set; }

}
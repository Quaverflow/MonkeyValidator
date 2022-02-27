namespace MonkeyValidator.Validator;

public class MonkeyClassValidator<T> : IMonkeyClassValidator
{
    public List<IMonkeyValidator> Validators { get; } = new ();

    internal MonkeyClassValidator()
    {
    }
    
}
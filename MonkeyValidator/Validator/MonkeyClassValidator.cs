namespace MonkeyValidator.Validator;

public class MonkeyClassValidator<T>
{
    internal List<IMonkeyValidator> Validators = new();

    internal MonkeyClassValidator()
    {
        
    }
    
}
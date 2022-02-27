namespace MonkeyValidator.Validator;

public interface IMonkeyClassValidator
{
    public List<IMonkeyValidator> Validators { get; }
}
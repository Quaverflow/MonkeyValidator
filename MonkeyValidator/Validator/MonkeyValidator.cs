namespace MonkeyValidator.Validator;

public class MonkeyValidator<T> : IMonkeyValidator
{
    private readonly string _ruleForName;
    public T Sut { get; }
    public List<string> Errors { get; }

    public MonkeyValidator(T sut, string? ruleForName)
    {
        _ruleForName = ruleForName[(ruleForName.IndexOf(".", StringComparison.Ordinal) + 1)..];
        Sut = sut;
        Errors = new List<string>();
    }

    internal void AddError(string error) => Errors.Add($"| Rule for: {_ruleForName}. ({error})");
}
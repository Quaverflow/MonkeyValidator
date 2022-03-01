namespace MonkeyValidator.Validator;

public class MonkeyValidatorException : Exception
{
    public List<string> Errors { get; }

    public MonkeyValidatorException(List<string> errors) : base($"\n{string.Join("\n", errors)}") => Errors = errors;
}
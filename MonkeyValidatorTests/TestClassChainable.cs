namespace MonkeyValidatorTests;

public class TestClassChainable
{
    public TestClassChainable(string s, TestClassChained testClassChained)
    {
        String = s;
        TestClassChained = testClassChained;
    }

    public string String { get; set; }
    public TestClassChained TestClassChained { get; set; }
}
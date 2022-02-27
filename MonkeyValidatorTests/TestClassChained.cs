namespace MonkeyValidatorTests;

public class TestClassChained
{
    public TestClassChained(int number, TestClassChainedNested testClassChainedNested)
    {
        Number = number;
        TestClassChainedNested = testClassChainedNested;
    }

    public int Number { get; set; }
    public TestClassChainedNested TestClassChainedNested { get; set; }
}
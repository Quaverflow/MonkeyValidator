namespace MonkeyValidatorTests;

public class TestClassChainable
{
    public TestClassChainable(string s, TestClassChained testClassChained)
    {
        String = s;
        TestClassChained = testClassChained;
    }
    public TestClassChainable(string s, TestClassChained testClassChained, TestClass tc1, TestClass tc2)
    {
        String = s;
        TestClassChained = testClassChained;
        TestChainable2 = tc1;
        TestChainable3 = tc2;
    }

    public string String { get; set; }
    public TestClassChained TestClassChained { get; set; }
    public TestClass TestChainable2 { get; set; }
    public TestClass TestChainable3 { get; set; }
}
using System.Collections.Generic;
using MonkeyValidator.Validator.Extensions;

namespace MonkeyValidatorTests;

public class TestClass
{
    public int Number { get; set; }
    public string String { get; set; }
    public TestClass TestClass1 { get; set; }

    public TestClass(int number, string s, TestClass testClass)
    {
        Number = number;
        String = s;
        TestClass1 = testClass;
    }
    
    public TestClass(int number, string s)
    {
        Number = number;
        String = s;
    }

    public void TestUsabilityPrimitive(int x)
    {
        x.GetValidator().ShouldBeEqualTo(3).Execute();

        x++;

        x.GetValidator().ShouldBeEqualTo(4).Execute();

    }

    public int TestMethodReturn(string a) => a.Length;
}
using System;
using System.Collections;
using System.Collections.Generic;
using MonkeyValidator.Validator;
using MonkeyValidator.Validator.Extensions;
using Xunit;

namespace MonkeyValidatorTests;

public class MonkeyValidatorTests
{
    [Theory]
    [InlineData(3, 4)]
    [InlineData(true, false)]
    [InlineData(3.1, 4.3)]
    [InlineData("hello", "goodbye")]
    [InlineData('a', 'c')]
    public void Test_ShouldBe_FailDefaultMessage<T>(T sut, T actual)
    {
        var result = Assert.Throws<MonkeyValidatorException>(
            () => sut.GetValidator().ShouldBe(x => Equals(x, actual)).Execute());

        Assert.Equal($"| Rule for: sut. (Expectations failed on value {sut})", result.Message);
    }

    [Theory]
    [InlineData(3, 4)]
    [InlineData(true, false)]
    [InlineData(3.1, 4.3)]
    [InlineData("hello", "goodbye")]
    [InlineData('a', 'c')]
    public void Test_ShouldBeEqual_FailDefaultMessage(object sut, object actual)
    {
        var result =
            Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldBeEqualTo(actual).Execute());
        Assert.Equal($"| Rule for: sut. (Expected {actual}, actual {sut})", result.Message);
    }

    [Theory]
    [InlineData(3, 4)]
    [InlineData(true, false)]
    [InlineData(3.1, 4.3)]
    [InlineData("hello", "goodbye")]
    [InlineData('a', 'c')]
    public void Test_ShouldBeEqual_FailCustomMessage(object sut, object actual)
    {
        var result =
            Assert.Throws<MonkeyValidatorException>(
                () => sut.GetValidator().ShouldBeEqualTo(actual, "oh no").Execute());
        Assert.Equal("| Rule for: sut. (oh no)", result.Message);
    }

    [Fact]
    public void Test_CustomValidator_IncludesInnerException()
    {
        var sut = new TestClass(3, "hello");
        var validator = new TestClassValidator();
        var result = Assert.Throws<MonkeyValidatorException>(() => validator.Validate(sut));
        var assumedResult = @"| Rule for: Number. (Expected 3 to be more than 4)
                            | Rule for: Something went wrong. (Object reference not set to an instance of an object.at MonkeyValidatorTests.TestClassValidator.<>c.<BuildValidator>b__0_2(TestClass y) 
                            in C:\Users\mirko\source\repos\MonkeyValidator\MonkeyValidatorTests\TestClassValidator.cs:line 12
                            at MonkeyValidator.Validator.MonkeyClassValidatorExtensions.BuildValidator[T](T instance, Func`2[] rules) 
                            in C:\Users\mirko\source\repos\MonkeyValidator\MonkeyValidator\Validator\MonkeyClassValidatorExtensions.cs:line 18)
                            | Rule for: TestClass1. (Expected to not be null)";
        var trimmedResult = result.Message.Trim().Replace(" ", "").Replace("\n", "").Replace("\r", "");
        var trimmedAssumedResult = assumedResult.Trim().Replace(" ", "").Replace("\n", "").Replace("\r", "");

        Assert.Equal(trimmedAssumedResult, trimmedResult);
    }

    [Fact]
    public void Test_ShouldBeNull()
    {
        Assert.Throws<MonkeyValidatorException>(() => 3.GetValidator().ShouldBeNull().Execute());
    }

    [Fact]
    public void Test_ShouldNotBeNull()
    {
        string? sut = null;
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldNotBeNull().Execute());
    }

    [Fact]
    public void Test_ShouldBeType()
    {
        Assert.Throws<MonkeyValidatorException>(() => 3.GetValidator().ShouldBeTypeOf(typeof(string)).Execute());
        3.GetValidator().ShouldBeTypeOf(typeof(int)).Execute();
    }

    [Fact]
    public void Test_ShouldNotBeType()
    {
        Assert.Throws<MonkeyValidatorException>(() => 3.GetValidator().ShouldNotBeTypeOf(typeof(int)).Execute());
        3.GetValidator().ShouldNotBeTypeOf(typeof(string)).Execute();
    }

    [Fact]
    public void Test_ShouldInheritFromType()
    {
        Assert.Throws<MonkeyValidatorException>(() =>
            3.GetValidator().ShouldInheritFromTypeOf(typeof(string)).Execute());
        3.GetValidator().ShouldInheritFromTypeOf(typeof(object)).Execute();
    }

    [Fact]
    public void Test_ShouldNotInheritFromType()
    {
        Assert.Throws<MonkeyValidatorException>(() =>
            3.GetValidator().ShouldNotInheritFromTypeOf(typeof(object)).Execute());
        3.GetValidator().ShouldNotInheritFromTypeOf(typeof(string)).Execute();
    }

    [Fact]
    public void Test_ShouldImplementInterface()
    {
        Assert.Throws<MonkeyValidatorException>(() =>
            3.GetValidator().ShouldImplementInterface(typeof(IEnumerable)).Execute());
        3.GetValidator().ShouldImplementInterface(typeof(IComparable)).Execute();
    }

    [Fact]
    public void Test_ShouldNotImplementInterface()
    {
        Assert.Throws<MonkeyValidatorException>(() =>
            3.GetValidator().ShouldNotImplementInterface(typeof(IComparable)).Execute());
        3.GetValidator().ShouldNotImplementInterface(typeof(IEnumerable)).Execute();
    }

    [Fact]
    public void Test_CustomRule()
    {
        Assert.Throws<MonkeyValidatorException>(() => 3.GetValidator().CustomRule(x => x > 3).Execute());
        3.GetValidator().CustomRule(x => x > 1).Execute();
    }

    [Fact]
    public void Test_CustomOnErrors()
    {
        var testCallback = new List<string>();
        Assert.Throws<ArgumentException>(() => 3.GetValidator().CustomRule(x => x > 3).Execute(errors =>
        {
            testCallback.AddRange(errors);
            throw new ArgumentException();
        }));

        Assert.Single(testCallback);
    }
}
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using MonkeyValidator.Validator;
using MonkeyValidator.Validator.Extensions;
using Xunit;

namespace MonkeyValidatorTests.GettingStarted;

public class GettingStarted
{
    [Fact]
    public void GettingStarted_Inline()
    {
        const string sut = "Hello";

        sut.GetValidator()
            .LengthShouldBeMoreOrEqualTo(5)
            .Execute();
    }

    [Fact]
    public void GettingStarted_Conditional()
    {
        const string sut = "Hello";

        Assert.Throws<InvalidOperationException>(()=> sut.GetValidator()
            .LengthShouldBeMoreOrEqualTo(5)
            .ConditionalValidation(x => x
                .If(y => y.StartsWith('h'), y => y.ShouldContainSingle('o'))
                .ElseIf(y => y.Equals("not today"), y => y
                    .ConditionalValidation(p => p
                        .If(t => t.StartsWith("m"), t => t.ShouldNotContainAny("daily vitamin", true))
                        .Else(t => t.ShouldNotBeNull())))
                .Else(_ => throw new InvalidOperationException()))
            .ShouldEndWith("lo", true)
            .Execute());
    }

    [Fact]
    public void GettingStarted_FailFast()
    {
        const int sut = 321;

        sut.GetValidator()
            .ShouldBeMoreThan(300)
            .FailFastIf(x => x == 0, new InvalidOperationException("Value cannot be 0"))
            .FailFastIf(x => x > 400, new InvalidOperationException("Value cannot be more than 400"))
            .ShouldBeMultipleOf(3)
            .Execute();
    }


    [Fact]
    public void GettingStarted_Foreach()
    {
        var sut = new[] { 3, 4, 5, 77, 77, 2, 2, 2, 2, 2 };

        sut.GetValidator()
            .ShouldContainSingle(3)
            .ShouldContainMany(77)
            .ShouldContainThisMany(2, 5)
            .CountShouldBeEqualTo(10)
            .ValidateForeach<int[], int>(x => x
                .ShouldNotBeTypeOf(typeof(string))
                .ShouldBeLessThan(80)
                .ShouldBeMoreOrEqualTo(2))
            .Execute();
    }



    [Fact]
    public void GettingStarted_CustomAction()
    {
        var sut = new Dictionary<int, bool> { {3, true}, {4, false} };

        var errors = new List<string>();

        sut.GetValidator()
            .ShouldContainSingle(new KeyValuePair<int,bool>(3, true))
            .Execute(x => errors.AddRange(x));
    }


    [Fact]
    public void GettingStarted_ActionInjection()
    {
        var sut = new Dictionary<int, bool> { {3, true}, {4, false} };

        var errors = new List<string>();

        sut.GetValidator()
            .ShouldContainSingle(new KeyValuePair<int,bool>(3, true))
            .Execute(x => errors.AddRange(x), true);
    }


    [Fact]
    public void GettingStarted_Custom()
    {
        const bool someUserDefinedCondition = true;
        const bool sut = false;

        sut.GetValidator()
            .ShouldBeFalse()
            .CustomRule(_ => someUserDefinedCondition)
            .Execute();
    }
}


public class MyClassValidator : CustomMonkeyValidatorBase<MyClass>
{
    protected override MonkeyClassValidator<MyClass> SetupValidator(MyClass instance)
        => instance.BuildValidator(
            x => x.Text.GetValidator().LengthShouldBeMoreOrEqualTo(5),
            x => x.MagicNumber.GetValidator().ShouldBeLessOrEqualTo(3))
            .Chain(new MyClass2Validator(), instance.MyClass2);
}

public class MyClass2Validator : CustomMonkeyValidatorBase<MyClass2>
{
    protected override MonkeyClassValidator<MyClass2> SetupValidator(MyClass2 instance)
        => instance.BuildValidator(x => x.Text.GetValidator().LengthShouldBeMoreOrEqualTo(5));
}

public class MyClass
{
    public MyClass(string text, int magicNumber, MyClass2 myClass2)
    {
        Text = text;
        MagicNumber = magicNumber;
        MyClass2 = myClass2;
    }

    public string Text { get; set; }
    public int MagicNumber { get; set; }
    public MyClass2 MyClass2 { get; set; }
}

public class MyClass2
{
    public MyClass2(string text) => Text = text;
    public string Text { get; set; }
}

public class GettingStartedReusable
{
    [Fact]
    public void GettingStarted_Reusable()
    {
        var sut = new MyClass("hello", 2, new MyClass2("hello"));
        var validator = new MyClassValidator();

        validator.Validate(sut);
    }
}


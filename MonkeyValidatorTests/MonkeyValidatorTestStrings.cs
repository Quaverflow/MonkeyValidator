using MonkeyValidator.Validator;
using MonkeyValidator.Validator.Extensions;
using Xunit;

namespace MonkeyValidatorTests;

public class MonkeyValidatorTestStrings
{
    #region Length

    [Fact]
    public void LengthShouldBe()
    {
        var sut = "home";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().LengthShouldBe(3).Execute());
        sut.GetValidator().LengthShouldBe(4).Execute();
    }

    [Fact]
    public void LengthShouldBeLessThan()
    {
        var sut = "home";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().LengthShouldBeLessThan(3).Execute());
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().LengthShouldBeLessThan(4).Execute());
        sut.GetValidator().LengthShouldBeLessThan(5).Execute();
    }

    [Fact]
    public void LengthShouldBeLessOrEqualTo()
    {
        var sut = "home";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().LengthShouldBeLessOrEqualTo(3).Execute());
        sut.GetValidator().LengthShouldBeLessOrEqualTo(4).Execute();
        sut.GetValidator().LengthShouldBeLessOrEqualTo(5).Execute();
    }

    [Fact]
    public void LengthShouldBeMoreThan()
    {
        var sut = "home";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().LengthShouldBeMoreThan(5).Execute());
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().LengthShouldBeMoreThan(4).Execute());
        sut.GetValidator().LengthShouldBeMoreThan(2).Execute();
    }

    [Fact]
    public void LengthShouldBeMoreOrEqualTo()
    {
        var sut = "home";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().LengthShouldBeMoreOrEqualTo(5).Execute());
        sut.GetValidator().LengthShouldBeMoreOrEqualTo(4).Execute();
        sut.GetValidator().LengthShouldBeMoreOrEqualTo(3).Execute();
    }

    #endregion

    #region Contains

    [Fact]
    public void ShouldContainAnyAmountOf_Char()
    {
        var sut = "home";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainAnyAmountOf('H', false).Execute());
        sut.GetValidator().ShouldContainAnyAmountOf('h', false).Execute();
    }

    [Fact]
    public void ShouldContainAnyAmountOf_CaseInsensitive_Char()
    {
        var sut = "home";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainAnyAmountOf('p', true).Execute());
        sut.GetValidator().ShouldContainAnyAmountOf('H', true).Execute();
    }

    [Fact]
    public void ShouldNotContainAny_Char()
    {
        var sut = "home";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldNotContainAny('h', false).Execute());
        sut.GetValidator().ShouldNotContainAny('H', false).Execute();
    }

    [Fact]
    public void ShouldNotContainAny_CaseInsensitive_Char()
    {
        var sut = "home";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldNotContainAny('h', true).Execute());
        sut.GetValidator().ShouldNotContainAny('f', true).Execute();
    }

    [Fact]
    public void ShouldContainAnyAmountOf_String()
    {
        var sut = "home";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainAnyAmountOf("Ho", false).Execute());
        sut.GetValidator().ShouldContainAnyAmountOf("ho", false).Execute();
    }

    [Fact]
    public void ShouldContainAnyAmountOf_CaseInsensitive_String()
    {
        var sut = "home";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainAnyAmountOf("dt", true).Execute());
        sut.GetValidator().ShouldContainAnyAmountOf("HO", true).Execute();
    }

    [Fact]
    public void ShouldContainSingle_Char()
    {
        var sut = "hello";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainAnyAmountOf('p', false).Execute());
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainAnyAmountOf('H', false).Execute());
        sut.GetValidator().ShouldContainAnyAmountOf('h', false).Execute();
    }

    [Fact]
    public void ShouldContainSingle_CaseInsensitive_Char()
    {
        var sut = "hello";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainSingle('l', true).Execute());
        sut.GetValidator().ShouldContainSingle('H', true).Execute();
        sut.GetValidator().ShouldContainSingle('h', true).Execute();
    }

    [Fact]
    public void ShouldContainSingle_String()
    {
        var sut = "hello lovers OWNERS";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainSingle("Ho", false).Execute());
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainSingle("lo", false).Execute());
        sut.GetValidator().ShouldContainSingle("ers", false).Execute();
        sut.GetValidator().ShouldContainSingle("he", false).Execute();
    }

    [Fact]
    public void ShouldContainSingle_CaseInsensitive_String()
    {
        var sut = "hello lovers OWNERS";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainSingle("lo", true).Execute());
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainSingle("LO", true).Execute());
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainSingle("ers", true).Execute());
        sut.GetValidator().ShouldContainSingle("he", true).Execute();
    }

    [Fact]
    public void ShouldContainMultiple_Char()
    {
        var sut = "hello";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainMultiple('h', false).Execute());
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainMultiple('L', false).Execute());
        sut.GetValidator().ShouldContainMultiple('l', false).Execute();
    }

    [Fact]
    public void ShouldContainMultiple_CaseInsensitive_Char()
    {
        var sut = "hello";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainMultiple('H', true).Execute());
        sut.GetValidator().ShouldContainMultiple('l', true).Execute();
        sut.GetValidator().ShouldContainMultiple('L', true).Execute();
    }

    [Fact]
    public void ShouldContainMultiple_String()
    {
        var sut = "hello lovers OWNERS";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainMultiple("Ho", false).Execute());
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainMultiple("ers", false).Execute());
        sut.GetValidator().ShouldContainMultiple("lo", false).Execute();
    }

    [Fact]
    public void ShouldContainMultiple_CaseInsensitive_String()
    {
        var sut = "hello lovers OWNERS";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainMultiple("HE", true).Execute());
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainMultiple("HO", true).Execute());
        sut.GetValidator().ShouldContainMultiple("lo", true).Execute();
        sut.GetValidator().ShouldContainMultiple("LO", true).Execute();
        sut.GetValidator().ShouldContainMultiple("ers", true).Execute();
    }

    [Fact]
    public void ShouldContain_Char()
    {
        var sut = "hello";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContain(3, 'h', false).Execute());
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContain(2, 'L', false).Execute());
        sut.GetValidator().ShouldContain(2, 'l', false).Execute();
    }

    [Fact]
    public void ShouldContain_CaseInsensitive_Char()
    {
        var sut = "hello";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContain(0, 'H', true).Execute());
        sut.GetValidator().ShouldContain(2, 'l', true).Execute();
        sut.GetValidator().ShouldContain(2, 'L', true).Execute();
    }

    [Fact]
    public void ShouldContain_String()
    {
        var sut = "hello lovers OWNERS";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContain(1, "Ho", false).Execute());
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContain(4, "ers", false).Execute());
        sut.GetValidator().ShouldContain(2, "lo", false).Execute();
        sut.GetValidator().ShouldContain(0, "mamma", false).Execute();
    }

    [Fact]
    public void ShouldContain_CaseInsensitive_String()
    {
        var sut = "hello lovers OWNERS";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContain(2, "HE", true).Execute());
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContain(1, "HO", true).Execute());
        sut.GetValidator().ShouldContain(2, "lo", true).Execute();
        sut.GetValidator().ShouldContain(2, "LO", true).Execute();
        sut.GetValidator().ShouldContain(2, "ers", true).Execute();
    }

    [Fact]
    public void ShouldContainMoreThan_Char()
    {
        var sut = "hello";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainMoreThan(3, 'h', false).Execute());
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainMoreThan(2, 'L', false).Execute());
        sut.GetValidator().ShouldContainMoreThan(1, 'l', false).Execute();
    }

    [Fact]
    public void ShouldContainMoreThan_CaseInsensitive_Char()
    {
        var sut = "hello";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainMoreThan(1, 'H', true).Execute());
        sut.GetValidator().ShouldContainMoreThan(1, 'l', true).Execute();
        sut.GetValidator().ShouldContainMoreThan(1, 'L', true).Execute();
    }

    [Fact]
    public void ShouldContainMoreThan_String()
    {
        var sut = "hello lovers OWNERS";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainMoreThan(1, "Ho", false).Execute());
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainMoreThan(4, "ers", false).Execute());
        sut.GetValidator().ShouldContainMoreThan(1, "lo", false).Execute();
        sut.GetValidator().ShouldContainMoreThan(-1, "mamma", false).Execute();
    }

    [Fact]
    public void ShouldContainMoreThan_CaseInsensitive_String()
    {
        var sut = "hello lovers OWNERS";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainMoreThan(2, "HE", true).Execute());
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainMoreThan(1, "HO", true).Execute());
        sut.GetValidator().ShouldContainMoreThan(1, "lo", true).Execute();
        sut.GetValidator().ShouldContainMoreThan(1, "LO", true).Execute();
        sut.GetValidator().ShouldContainMoreThan(1, "ers", true).Execute();
    }

    [Fact]
    public void ShouldContainMoreOrEqualThan_Char()
    {
        var sut = "hello";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainMoreOrEqualTo(3, 'h', false).Execute());
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainMoreOrEqualTo(2, 'L', false).Execute());
        sut.GetValidator().ShouldContainMoreOrEqualTo(1, 'l', false).Execute();
    }

    [Fact]
    public void ShouldContainMoreOrEqualThan_CaseInsensitive_Char()
    {
        var sut = "hello";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainMoreOrEqualTo(2, 'H', true).Execute());
        sut.GetValidator().ShouldContainMoreOrEqualTo(1, 'l', true).Execute();
        sut.GetValidator().ShouldContainMoreOrEqualTo(1, 'L', true).Execute();
    }

    [Fact]
    public void ShouldContainMoreOrEqualThan_String()
    {
        var sut = "hello lovers OWNERS";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainMoreOrEqualTo(1, "Ho", false).Execute());
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainMoreOrEqualTo(4, "ers", false).Execute());
        sut.GetValidator().ShouldContainMoreOrEqualTo(1, "lo", false).Execute();
        sut.GetValidator().ShouldContainMoreOrEqualTo(-1, "mamma", false).Execute();
    }

    [Fact]
    public void ShouldContainMoreOrEqualThan_CaseInsensitive_String()
    {
        var sut = "hello lovers OWNERS";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainMoreOrEqualTo(2, "HE", true).Execute());
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainMoreOrEqualTo(1, "HO", true).Execute());
        sut.GetValidator().ShouldContainMoreOrEqualTo(1, "lo", true).Execute();
        sut.GetValidator().ShouldContainMoreOrEqualTo(1, "LO", true).Execute();
        sut.GetValidator().ShouldContainMoreOrEqualTo(1, "ers", true).Execute();
    }

    [Fact]
    public void ShouldContainLessThan_Char()
    {
        var sut = "hello";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainLessThan(1, 'h', false).Execute());
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainLessThan(0, 'L', false).Execute());
        sut.GetValidator().ShouldContainLessThan(3, 'l', false).Execute();
    }

    [Fact]
    public void ShouldContainLessThan_CaseInsensitive_Char()
    {
        var sut = "hello";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainLessThan(1, 'H', true).Execute());
        sut.GetValidator().ShouldContainLessThan(3, 'l', true).Execute();
        sut.GetValidator().ShouldContainLessThan(3, 'L', true).Execute();
    }

    [Fact]
    public void ShouldContainLessThan_String()
    {
        var sut = "hello lovers OWNERS";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainLessThan(0, "Ho", false).Execute());
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainLessThan(1, "ers", false).Execute());
        sut.GetValidator().ShouldContainLessThan(3, "lo", false).Execute();
        sut.GetValidator().ShouldContainLessThan(3, "mamma", false).Execute();
    }

    [Fact]
    public void ShouldContainLessThan_CaseInsensitive_String()
    {
        var sut = "hello lovers OWNERS";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainLessThan(0, "HE", true).Execute());
        sut.GetValidator().ShouldContainLessThan(3, "lo", true).Execute();
        sut.GetValidator().ShouldContainLessThan(3, "LO", true).Execute();
        sut.GetValidator().ShouldContainLessThan(3, "ers", true).Execute();
    }

    [Fact]
    public void ShouldContainLessOrEqualThan_Char()
    {
        var sut = "hello";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainLessOrEqualTo(0, 'h', false).Execute());
        sut.GetValidator().ShouldContainLessOrEqualTo(3, 'l', false).Execute();
    }

    [Fact]
    public void ShouldContainLessOrEqualThan_CaseInsensitive_Char()
    {
        var sut = "hello";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainLessOrEqualTo(0, 'H', true).Execute());
        sut.GetValidator().ShouldContainLessOrEqualTo(3, 'l', true).Execute();
        sut.GetValidator().ShouldContainLessOrEqualTo(2, 'L', true).Execute();
    }

    [Fact]
    public void ShouldContainLessOrEqualThan_String()
    {
        var sut = "hello lovers OWNERS";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainLessOrEqualTo(0, "ers", false).Execute());
        sut.GetValidator().ShouldContainLessOrEqualTo(2, "lo", false).Execute();
    }

    [Fact]
    public void ShouldContainLessOrEqualThan_CaseInsensitive_String()
    {
        var sut = "hello lovers OWNERS";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldContainLessOrEqualTo(0, "he", true).Execute());
        sut.GetValidator().ShouldContainLessOrEqualTo(2, "lo", true).Execute();
        sut.GetValidator().ShouldContainLessOrEqualTo(2, "LO", true).Execute();
        sut.GetValidator().ShouldContainLessOrEqualTo(3, "ers", true).Execute();
    }

    [Fact]
    public void ShouldStartWith_Char()
    {
        var sut = "hello";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldStartWith('e', false).Execute());
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldStartWith('H', false).Execute());
        sut.GetValidator().ShouldStartWith('h', false).Execute();
    }

    [Fact]
    public void ShouldStartWith_CaseInsensitive_Char()
    {
        var sut = "hello";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldStartWith('e', true).Execute());
        sut.GetValidator().ShouldStartWith('h', true).Execute();
        sut.GetValidator().ShouldStartWith('H', true).Execute();
    }

    [Fact]
    public void ShouldStartWith_String()
    {
        var sut = "hello";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldStartWith("ers", false).Execute());
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldStartWith("HE", false).Execute());
        sut.GetValidator().ShouldStartWith("he", false).Execute();
    }

    [Fact]
    public void ShouldStartWith_CaseInsensitive_String()
    {
        var sut = "hello";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldStartWith("ers", true).Execute());
        sut.GetValidator().ShouldStartWith("he", true).Execute();
        sut.GetValidator().ShouldStartWith("HE", true).Execute();
    }

    [Fact]
    public void ShouldEndWith_Char()
    {
        var sut = "hello";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldEndWith('e', false).Execute());
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldEndWith('H', false).Execute());
        sut.GetValidator().ShouldEndWith('o', false).Execute();
    }

    [Fact]
    public void ShouldEndWith_CaseInsensitive_Char()
    {
        var sut = "hello";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldEndWith('e', true).Execute());
        sut.GetValidator().ShouldEndWith('o', true).Execute();
        sut.GetValidator().ShouldEndWith('O', true).Execute();
    }

    [Fact]
    public void ShouldEndWith_String()
    {
        var sut = "hello";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldEndWith("ers", false).Execute());
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldEndWith("LO", false).Execute());
        sut.GetValidator().ShouldEndWith("lo", false).Execute();
    }

    [Fact]
    public void ShouldEndWith_CaseInsensitive_String()
    {
        var sut = "hello";
        Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldEndWith("ers", true).Execute());
        sut.GetValidator().ShouldEndWith("lo", true).Execute();
        sut.GetValidator().ShouldEndWith("LO", true).Execute();
    }

    #endregion

    [Fact]
    public void Test_RealWordScenarios()
    {
        var sutBasic = "Hello darling, today I'm planning on going for shopping.";

        Assert.Throws<MonkeyValidatorException>(() => sutBasic.GetValidator().ShouldContain('!').Execute());

        sutBasic.GetValidator()
            .ShouldStartWith("he", true)
            .ShouldContainAnyAmountOf('a', true)
            .ShouldContainMultiple("ing", false)
            .ShouldContainSingle("hello", true)
            .ShouldEndWith('.', false)
            .LengthShouldBeMoreThan(13)
            .ShouldContainLessThan(10, 'b', true)
            .Execute();
    }

    [Fact]
    public void Test_RealWordScenarios_BasicScriptCheck()
    {
        var sutWithScript = "Hello darling, today I'm planning on going for shopping. <script> Alert(I'm a sneaky script);</script>";
        Assert.Throws<MonkeyValidatorException>(() => sutWithScript.GetValidator().ShouldNotContainAny("<script>", true).Execute());
    }

    [Fact]
    public void Test_RealWordScenarios_ComplexFailure()
    {
        var sutBasic = "tityre tu patulae recubans sub tegmine fagi";

        var result = Assert.Throws<MonkeyValidatorException>(() =>
        sutBasic.GetValidator()
            .ShouldStartWith("he", true)
            .ShouldContainAnyAmountOf('q', true)
            .ShouldContainMultiple("ing", false)
            .ShouldContainSingle("hello", true)
            .ShouldEndWith('.', false)
            .LengthShouldBeLessThan(13)
            .ShouldContainMoreThan(10, 'b', true)
            .Execute());

        var assumedResult =
            @"| Rule for: sutBasic. (Expected to start with (he) actual (ti))
              | Rule for: sutBasic. (Expected to contain (q) in (tityre tu patulae recubans sub tegmine fagi))
              | Rule for: sutBasic. (Expected to contain multiple (ing) actual (0))
              | Rule for: sutBasic. (Expected to contain single (hello) actual (0))
              | Rule for: sutBasic. (Expected to end with (.) actual (i))
              | Rule for: sutBasic. (Expected length to be lesser than (13) actual (43))
              | Rule for: sutBasic. (Expected to contain more than(10 b) actual (2))";

        var trimmedResult = result.Message.Trim().Replace(" ", "").Replace("\n", "").Replace("\r", "");
        var trimmedAssumedResult = assumedResult.Trim().Replace(" ", "").Replace("\n", "").Replace("\r", "");

        Assert.Equal(trimmedAssumedResult, trimmedResult);
    }
}
using System.Collections;
using MonkeyValidator.Validator;
using MonkeyValidator.Validator.Extensions;
using Xunit;

namespace MonkeyValidatorTests;

public class MonkeyValidatorTestsNumeric
{
    #region More (this does it for all numeric types for completenes)
   
    [Theory]
    [InlineData((double) 5, (double) 6)]
    [InlineData((double) 5, (double) 5)]
    public void Test_ShouldBeMore_Double_ShouldFail(double sut, double actual) 
        => Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldBeMoreThan(actual, "oh no").Execute());

    [Theory]
    [InlineData((byte) 5, (byte) 6)]
    [InlineData((byte) 5, (byte) 5)]

    public void Test_ShouldBeMore_Byte_ShouldFail(byte sut, byte actual)
        => Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldBeMoreThan(actual, "oh no").Execute());

    [Theory]
    [InlineData(5, 6)]
    [InlineData(5, 5)]
    public void Test_ShouldBeMore_Int_ShouldFail(int sut, int actual) 
        => Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldBeMoreThan(actual, "oh no").Execute());

    [Theory]
    [InlineData((short) 5, (short) 6)]
    [InlineData((short) 5, (short) 5)]
    public void Test_ShouldBeMore_Short_ShouldFail(short sut, short actual) 
        => Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldBeMoreThan(actual, "oh no").Execute());

    [Theory]
    [InlineData((float) 5, (float) 6)]
    [InlineData((float) 5, (float) 5)]
    public void Test_ShouldBeMore_Float_ShouldFail(float sut, float actual) 
        => Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldBeMoreThan(actual, "oh no").Execute());

    [Theory]
    [InlineData((long) 5, (long) 6)]
    [InlineData((long) 5, (long) 5)]

    public void Test_ShouldBeMore_Long_ShouldFail(long sut, long actual)
        => Assert.Throws<MonkeyValidatorException>(() => sut.GetValidator().ShouldBeMoreThan(actual, "oh no").Execute());

    #endregion

    #region MoreOrEqual
   
    [Fact]
    public void Test_ShouldBeMoreOrEqual_Double_ShouldFailOnMore() 
        => Assert.Throws<MonkeyValidatorException>(() => 3.GetValidator().ShouldBeMoreOrEqualTo(5, "oh no").Execute());

    [Fact]
    public void Test_ShouldBeMoreOrEqual_Double_ShouldPass() 
        => 3.GetValidator().ShouldBeMoreOrEqualTo(3, "oh no").Execute();

    #endregion

    #region Less

    [Fact]
    public void Test_ShouldBeLess_Double_ShouldFailOnMore()
        => Assert.Throws<MonkeyValidatorException>(() => 3.GetValidator().ShouldBeLessThan(1, "oh no").Execute());

    [Fact]
    public void Test_ShouldBeLess_Double_ShouldPass()
        => Assert.Throws<MonkeyValidatorException>(() => 3.GetValidator().ShouldBeLessThan(3, "oh no").Execute());


    #endregion

    #region LessOrEqual

    [Fact]
    public void Test_ShouldBeLessOrEqual_Double_ShouldFailOnMore()
        => Assert.Throws<MonkeyValidatorException>(() => 3.GetValidator().ShouldBeLessOrEqualTo(1, "oh no").Execute());

    [Fact]
    public void Test_ShouldBeLessOrEqual_Double_ShouldPass()
        => 3.GetValidator().ShouldBeLessOrEqualTo(3, "oh no").Execute();

    #endregion

    #region ShouldBeMultipleOf
    [Fact]
    public void Test_ShouldBeMultipleOf_Double_ShouldFailOnMore()
        => Assert.Throws<MonkeyValidatorException>(() => 3.GetValidator().ShouldBeMultipleOf(9, "oh no").Execute());

    [Fact]
    public void Test_ShouldBeMultipleOf_Double_ShouldPass()
        => 9.GetValidator().ShouldBeMultipleOf(3, "oh no").Execute();


    #endregion
}
using System;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;
using System.Text.Json;
using System.Threading.Tasks;
using MonkeyValidator.Validator;
using MonkeyValidator.Validator.Extensions;

namespace MonkeyValidatorTests;

public class MonkeyValidatorHttpContextTests
{
    private static readonly DefaultHttpContext Context = new()
    {
        Response =
        {
            StatusCode = 200
        }
    };


    [Fact]
    public void Test_StatusCode()
    {
        Assert.Throws<MonkeyValidatorException>(() => Context.GetValidator().StatusCodeShouldBe(HttpStatusCode.BadRequest).Execute());
        Context.GetValidator().StatusCodeShouldBe(HttpStatusCode.OK).Execute();
    }

    [Fact]
    public void Test_StatusCodeShouldNotBe()
    {
        Assert.Throws<MonkeyValidatorException>(() => Context.GetValidator().StatusCodeShouldNotBe(HttpStatusCode.OK).Execute());
        Context.GetValidator().StatusCodeShouldNotBe(HttpStatusCode.BadRequest).Execute();
    }

    [Fact]
    public void Test_StatusCodeShouldNotBeInRange()
    {
        Assert.Throws<MonkeyValidatorException>(() => Context.GetValidator().StatusCodeShouldNotBeInRange(100, 300).Execute());
        Context.GetValidator().StatusCodeShouldNotBeInRange(400, 500).Execute();
    }

    [Fact]
    public void Test_StatusCodeShouldBeInRange()
    {
        Assert.Throws<MonkeyValidatorException>(() => Context.GetValidator().StatusCodeShouldBeInRange(400, 500).Execute());
        Context.GetValidator().StatusCodeShouldBeInRange(100, 300).Execute();
    }



}


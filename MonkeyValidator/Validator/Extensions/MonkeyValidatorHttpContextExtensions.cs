using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace MonkeyValidator.Validator.Extensions;

public static class MonkeyValidatorHttpContextExtensions
{
    #region StatusCode

    public static MonkeyValidator<T> StatusCodeShouldBe<T>(this MonkeyValidator<T> validator, HttpStatusCode expected, string? message = null) where T : HttpContext
    {
        if (!Equals(validator.Sut.Response.StatusCode, (int)expected))
        {
            validator.AddError(message ?? $"Expected {expected}, actual {validator.Sut.Response.StatusCode}");
        }

        return validator;
    }

    public static MonkeyValidator<T> StatusCodeShouldNotBe<T>(this MonkeyValidator<T> validator, HttpStatusCode expected, string? message = null) where T : HttpContext
    {
        if (Equals(validator.Sut.Response.StatusCode, (int)expected))
        {
            validator.AddError(message ?? $"Expected to not be {expected}, actual {validator.Sut.Response.StatusCode}");
        }

        return validator;
    }

    public static MonkeyValidator<T> StatusCodeShouldBeInRange<T>(this MonkeyValidator<T> validator, int min, int max, string? message = null) where T : HttpContext
    {
        var actual = validator.Sut.Response.StatusCode;
        if (actual <= min || actual > max)
        {
            validator.AddError(message ?? $"Expected {actual}, to be within range {min}/{max}");
        }

        return validator;
    }

    public static MonkeyValidator<T> StatusCodeShouldNotBeInRange<T>(this MonkeyValidator<T> validator, int min, int max, string? message = null) where T : HttpContext
    {
        var actual = validator.Sut.Response.StatusCode;
        if (actual >= min && actual <= max)
        {
            validator.AddError(message ?? $"Expected {actual}, to be outside of range {min}/{max}");
        }

        return validator;
    }

    #endregion
}
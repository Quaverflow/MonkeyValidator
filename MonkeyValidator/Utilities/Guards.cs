using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace MonkeyValidator.Utilities;

public static class Guards
{
    public static void ThrowIfNull([NotNull] this object? argument, [CallerArgumentExpression("argument")] string? paramName = null)
    {
        if (argument == null)
        {
            throw new ArgumentNullException(paramName);
        }
    }
}
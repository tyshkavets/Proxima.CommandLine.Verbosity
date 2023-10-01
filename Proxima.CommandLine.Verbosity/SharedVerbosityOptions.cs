using System.CommandLine;

namespace Proxima.CommandLine.Verbosity;

public static class SharedVerbosityOptions
{
    public static readonly Option<Verbosity> Verbose =
        new(new[] { "--verbose", "-v" }, getDefaultValue: () => Verbosity.Diagnostic)
        {
            IsRequired = false,
            Arity = ArgumentArity.ZeroOrOne,
            Description = "Verbosity setting."
        };
}

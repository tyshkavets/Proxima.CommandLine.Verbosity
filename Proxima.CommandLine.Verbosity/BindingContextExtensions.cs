using System.CommandLine;
using System.CommandLine.Binding;

namespace Proxima.CommandLine.Verbosity;

public static class BindingContextExtensions
{
    public static Verbosity GetVerboseValue(this BindingContext ctx)
    {
        return ctx.ParseResult.GetValueForOption(SharedVerbosityOptions.Verbose);
    }

    public static void WriteDiagnosticLine(this BindingContext ctx, string line)
    {
        WriteLine(ctx, line, Verbosity.Diagnostic);
    }

    public static void WriteDetailedLine(this BindingContext ctx, string line)
    {
        WriteLine(ctx, line, Verbosity.Detailed);
    }

    public static void WriteMinimalLine(this BindingContext ctx, string line)
    {
        WriteLine(ctx, line, Verbosity.Minimal);
    }

    public static void WriteQuietLine(this BindingContext ctx, string line)
    {
        Write(ctx, line, Verbosity.Quiet);
    }

    public static void WriteDiagnostic(this BindingContext ctx, string line)
    {
        Write(ctx, line, Verbosity.Diagnostic);
    }

    public static void WriteDetailed(this BindingContext ctx, string line)
    {
        Write(ctx, line, Verbosity.Detailed);
    }

    public static void WriteMinimal(this BindingContext ctx, string line)
    {
        Write(ctx, line, Verbosity.Minimal);
    }

    public static void WriteQuiet(this BindingContext ctx, string line)
    {
        WriteLine(ctx, line, Verbosity.Quiet);
    }

    public static void WriteLine(this BindingContext ctx, string line, Verbosity verbosity = Verbosity.Normal)
    {
        WriteToConsole(ctx, line, verbosity, ctx.Console.WriteLine);
    }

    public static void Write(this BindingContext ctx, string line, Verbosity verbosity = Verbosity.Normal)
    {
        WriteToConsole(ctx, line, verbosity, ctx.Console.Write);
    }

    private static void WriteToConsole(BindingContext ctx, string line, Verbosity verbosity, Action<string> writer)
    {
        if (verbosity <= GetVerboseValue(ctx))
        {
            writer(line);
        }
    }
}

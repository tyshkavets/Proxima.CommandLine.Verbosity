# Proxima.CommandLine.Verbosity
Standard verbosity option for .NET System.CommandLine with accompanying console.write extensions

# Usage

Normally added as a global option for a root command.

```csharp
rootCommand.AddGlobalOption(SharedVerbosityOptions.Verbose);
```

BindingContext, that is a part of InvocationContext, gets a few extension methods for console output:

```csharp
ctx.WriteMinimal("I will only be printed if verbosity is set to Minimal or above, but won't be run if" +
                 "the command is called with --verbose Quiet");
```
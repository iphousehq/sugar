#Syntactic Sugar for .NET

A collection of .NET helper classes, extension methods and shortcuts for common .NET operations.

The project is divided in several class libraries:

- Sugar: Core of the nice to have helpers and extensions methods.
- Sugar.Http: Helper classes and interface to leverage .NET's HttpClient.
- Sugar.Test: Unit tests (nunit + moq)
- Sugar.Test.Integration: Integration test
- Sugar.Web: Handy helpers when dealing with domain names and URLs.

[![Build status](https://ci.appveyor.com/api/projects/status/py4kl09udd0t7egy/branch/master?svg=true)](https://ci.appveyor.com/project/bounav/sugar/branch/master)

##Overview

We started this project internally to centralise the code we kept re-using from project to project. If the bits we add have a dependency we try to put it in its own project / DLL (e.g. Sugar.Http depending on System.Net.Http).

###Command

Check the `Sugar.Command` namespace out if you're thinking need to create a command line tool. It will help you define different commands and then execute a given command.

```csharp

public class ResetEvalDateCommand : BoundCommand<ResetEvalDateCommand.Options> 
{
    [Flag("reset", "eval-date")]
    public class Options
    {
        [Parameter("eval-date", Default = "2001-01-01")]
        public DateTime Since { get; set; }
    }
    
    public override int Execute(Options options)
    {
        var exitCode = (int) ExitCode.Success;
    
        // TODO: Implement your command here
        
        return exitCode;
    }
}

public class MyConsole : BaseConsole
{
    protected override int Main()
    {
        var exitCode = Arguments.Count > 0 ? Run(Arguments) : Default();

        return exitCode;
    }
    
    public int Run(Arguments arguments)
    {
        var exitCode = (int)ExitCode.GeneralError;

            var commandType = new BoundCommandFactory().GetCommandType(parameters, () => GetType().Assembly.GetTypes()
                                                                                                  .Where(type => type.Namespace != null && type.Namespace.StartsWith("My.Namespace.Commands"))
                                                                                                  .Where(type => type.Name == "Options"));

            if (commandType != null)
            {
                exitCode = Run(commandType, parameters);
            }
            else
            {
                System.Console.WriteLine("Unknown command arguments: {0}", Arguments);
            }

            return exitCode;
    }
    
    public int Default()
    {
        Console.WriteLine("Default output / help message");
        
        return (int) ExitCode.Nocommand;
    }
}

public static class EntryPoint
{
    public static void Main(string[] args)
    {
        var console = new MyConsole();
        
        var exitCode = console.Run(args);
        
        Environment.Exit(exitCode);
    }
}

```

###Extensions

A major part of this project consists in (mostly) chainable extension methods. They live in the namespace `Sugar.Extensions`.

The most usefull extensions methods are probably the string ones such as `.StartsWith()` or `.SubstringAfterChar()`. We've also created .Humanise() extensions methods for datetimes and timespans.

###CountryCode

Enumeration listing all countries on Earth (ISO 3166-1-alpha-2 code elements).

###File Service

Wraps System.IO.File behind an interface to ease unit testing.

###GeoLocation

Represents a point on the surface of a sphere approximating the Earth. It contains a few methods that will compute (approximatively) the distance between two points on earth as well a give you a bouding box containing for a given radius around a point.

If you need precision and or performance, use a specialed library!

###HtmlBuilder

`IBuilder` implementation to help generating HTML fragments.

###Http Service

This service and its interface live in the `Sugar.Web` project. It wraps calls to .NET's HttpWebResponse with an interface that is easily mockable in a unit test.

We wrote this class before HttpClient was introduced in .NET 4.0 and are considering this project near it's end of life.

###Retry

Helper class to retry a given action `x` times. If you need more flexibility checkout [Polly](https://github.com/App-vNext/Polly).

###TextTable

Helper class to ouput text as a table in a console application

##License

This project is licensed under the terms of the [MIT license](https://github.com/comsechq/sugar/blob/master/LICENSE.txt). 

By submitting a pull request for this project, you agree to license your contribution under the MIT license to this project.

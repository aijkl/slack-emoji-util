using SlackUtil.Commands;
using Spectre.Console.Cli;

namespace SlackUtil;

internal class Program
{
    private static int Main(string[] args)
    {
        var commandApp = new CommandApp();
        commandApp.Configure(x =>
        {
            x.AddCommand<SignInCommand>("signin");
            x.AddCommand<ProfileCommand>("profile");
            x.AddCommand<ClearProfileCommand>("clear-profile");
        });
        return commandApp.Run(args);
    }
}
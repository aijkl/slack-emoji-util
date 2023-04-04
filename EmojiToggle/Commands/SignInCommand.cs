using SlackAPI;
using System.Web;
using Spectre.Console;
using System.Diagnostics;
using Spectre.Console.Cli;
using SlackUtil.Helpers;

namespace SlackUtil.Commands;

public class SignInCommand : AsyncCommand
{
    public override async Task<int> ExecuteAsync(CommandContext context)
    {
        var appSettings = AppSettings.LoadFromFile();

        var slackClientHelpers = new SlackClientHelpers();
        var url = slackClientHelpers.GetAuthorizeUri(appSettings.ClientId, SlackScope.Post, appSettings.CallbackUrl);
        Process.Start(new ProcessStartInfo(url.AbsoluteUri)
        {
            UseShellExecute = true
        });


        var callbackUrl = AnsiConsole.Ask<string>("Slack APIからリダイレクトされたURLを入力してください");
        var query = HttpUtility.ParseQueryString(new Uri(callbackUrl).Query);
        if (!query.Keys.Cast<string>().ToDictionary(n => n, m => query[m]).TryGetValue("code", out var code))
        {
            return 1;
        }

        var response = await slackClientHelpers.GetAccessTokenAsync(appSettings.ClientId, appSettings.ClientSecret, appSettings.CallbackUrl, code);

        AnsiConsoleHelper.MarkupLine($"Token: {response.access_token}", AnsiConsoleHelper.State.Success);
        return 0;
    }
}
using SlackNet;
using SlackUtil.Helpers;
using SlackUtil.Settings;
using Spectre.Console.Cli;

namespace SlackUtil.Commands
{
    public class ClearProfileCommand : AsyncCommand<TokenSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, TokenSettings settings)
        {
            var slackApi = new SlackApiClient(settings.Token);
            await slackApi.UserProfile.Set(new UserProfile
            {
                StatusEmoji = string.Empty,
                StatusText = string.Empty,
            });

            AnsiConsoleHelper.MarkupLine("プロフィールのリセットに成功しました", AnsiConsoleHelper.State.Success);
            return 0;
        }
    }
}

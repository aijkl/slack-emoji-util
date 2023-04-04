using SlackNet;
using SlackUtil.Helpers;
using SlackUtil.Settings;
using Spectre.Console.Cli;

namespace SlackUtil.Commands
{
    public class ProfileCommand : AsyncCommand<ProfileSettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, ProfileSettings settings)
        {
            var slackApi = new SlackApiClient(settings.Token);
            await slackApi.UserProfile.Set(new UserProfile
            {
                StatusEmoji = settings.Emoji,
                StatusText = settings.Status
            });

            AnsiConsoleHelper.MarkupLine($"絵文字を{settings.Emoji}に変更しました", AnsiConsoleHelper.State.Success);
            return 0;
        }
    }
}

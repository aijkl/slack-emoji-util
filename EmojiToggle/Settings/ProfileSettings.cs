using Spectre.Console;
using Spectre.Console.Cli;

namespace SlackUtil.Settings
{
    public class ProfileSettings : TokenSettings
    {
        public ProfileSettings(string emoji, string token, string status) : base(token)
        {
            Emoji = emoji;
            Status = status;
        }

        [CommandOption("--emoji")]
        public string? Emoji { get; set; }

        [CommandOption("--status")]
        public string? Status { get; set; }

        public override ValidationResult Validate()
        {
            if(string.IsNullOrWhiteSpace(Emoji) && string.IsNullOrWhiteSpace(Status)) return ValidationResult.Error("絵文字とステータスはどちらかを指定する必要があります");
            return base.Validate();
        }
    }
}

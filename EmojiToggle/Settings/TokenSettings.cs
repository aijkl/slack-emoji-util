using System.ComponentModel;
using Spectre.Console.Cli;

namespace SlackUtil.Settings
{
    public class TokenSettings : CommandSettings
    {
        public TokenSettings(string token)
        {
            Token = token;
        }

        [CommandArgument(0, "<token>")]
        public string Token { set; get; }
    }
}

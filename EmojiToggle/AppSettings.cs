using Newtonsoft.Json;

namespace SlackUtil;

public class AppSettings
{
    public static readonly string FilePath = "./appsettings.json";
    public AppSettings(string clientId, string callbackUrl, string clientSecret)
    {
        ClientId = clientId;
        CallbackUrl = callbackUrl;
        ClientSecret = clientSecret;
    }

    [JsonRequired]
    public string ClientId { set; get; }

    [JsonRequired]
    public string ClientSecret { set; get; }

    [JsonRequired]
    public string CallbackUrl { set; get; }

    public static AppSettings LoadFromFile()
    {
        return JsonConvert.DeserializeObject<AppSettings>(File.ReadAllText(FilePath)) ?? throw new Exception();
    }
}
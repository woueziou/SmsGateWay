using System.Text.Json;

namespace SmsGateWayApi;


public class SnakeCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        if (string.IsNullOrEmpty(name))
            return name;
        return name.ToLower();
    }
}

using System.Text.Json;

namespace SmsGateWayApi;


public class SnakeCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        if (string.IsNullOrEmpty(name))
            return name;

        string convertedName = "";

        for (int i = 0; i < name.Length; i++)
        {
            if (char.IsUpper(name[i]))
            {
                convertedName += "_" + char.ToLower(name[i]);
            }
            else
            {
                convertedName += name[i];
            }
        }

        return convertedName;
    }
}

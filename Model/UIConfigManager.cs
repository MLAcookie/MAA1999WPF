using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using M9AWPF.Constants;
using M9AWPF.JsonSerializeObject;

namespace M9AWPF.Model;

public static class UIConfigManager
{
    private static readonly JsonSerializerOptions defaultSerializeOptions = new()
    {
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
    };

    private static readonly string UIConfigPath = ConfKeys.UIConfig;
    private static UIConfigObject UIConfigObject;

    static UIConfigManager()
    {
        if (File.Exists(UIConfigPath))
        {
            StreamReader sr = File.OpenText(UIConfigPath);
            string jsonString = sr.ReadToEnd();
            UIConfigObject = JsonSerializer.Deserialize<UIConfigObject>(jsonString)!;
            sr.Close();
        }
        else
        {
            UIConfigObject = new UIConfigObject();
        }
    }

    #region StaticProperties

    public static string GlobalADBPath
    {
        get
        {
            return UIConfigObject.ADBPath;
        }
        set
        {
            UIConfigObject.ADBPath = value;
        }
    }

    public static string GlobalABDPort
    {
        get
        {
            return UIConfigObject.ADBPort;
        }
        set
        {
            UIConfigObject.ADBPort = value;
        }
    }

    public static string GlobalHttpProxy
    {
        get
        {
            return UIConfigObject.HttpProxy;
        }
        set
        {
            UIConfigObject.HttpProxy = value;
            HttpClient.DefaultProxy = new WebProxy(value);
        }
    }

    public static string? LastSelectConfig
    {
        get
        {
            return UIConfigObject.LastSelectConfig;
        }
        set
        {
            UIConfigObject.LastSelectConfig = value;
        }
    }

    public static bool IsLastUseTimer
    {
        get
        {
            return UIConfigObject.IsLastUseTimer;
        }
        set
        {
            UIConfigObject.IsLastUseTimer = value;
        }
    }

    public static TaskTimerObject Timer
    {
        get
        {
            return UIConfigObject.Timer;
        }
        set
        {
            UIConfigObject.Timer = value;
        }
    }

    #endregion StaticProperties

    #region PublicMethods

    public static void SaveUIConfig()
    {
        var jsonString = JsonSerializer.Serialize(UIConfigObject, defaultSerializeOptions);
        File.WriteAllText(UIConfigPath, jsonString, new UTF8Encoding(false));
    }

    #endregion PublicMethods
}
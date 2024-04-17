using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using M9AWPF.Constants;

namespace M9AWPF.Model;

public static class M9AConfigManager
{
    static readonly string ConfigPath = ConfKeys.UIManagedConfig;

    static Dictionary<string, string> nameToPath = new();
    static Dictionary<string, M9AConfig> nameToObject = new();

    #region Properties
    public static Dictionary<string, string> NameToPath
    {
        get { return nameToPath; }
    }

    public static Dictionary<string, M9AConfig> NameToObject
    {
        get { return nameToObject; }
    }

    public static List<string> ConfigNames
    {
        get { return nameToPath.Keys.ToList(); }
    }

    public static Dictionary<string, bool> IsConfigChanged = new();
    #endregion

    static M9AConfigManager()
    {
        string[] allConfigPath = Directory.GetFiles(ConfigPath);
        foreach (string filePath in allConfigPath)
        {
            M9AConfig temp = new(filePath);
            nameToPath.Add(Path.GetFileName(filePath), filePath);
            nameToObject.Add(Path.GetFileName(filePath), temp);
            IsConfigChanged.Add(Path.GetFileName(filePath), false);
        }
    }

    public static void SaveAllConfig()
    {
        foreach (var config in IsConfigChanged)
        {
            if (config.Value)
            {
                NameToObject[config.Key].SaveConfig();
            }
        }
    }

    public static M9AConfig NewConfig(string name)
    {
        if (!name.EndsWith(".json"))
        {
            name += ".json";
        }
        string newConfigPath = Path.Combine(ConfigPath, name);
        M9AConfig newConfig = new(newConfigPath);
        nameToPath[name] = newConfigPath;
        NameToObject[name] = newConfig;
        IsConfigChanged[name] = true;
        return newConfig;
    }

    public static void SwichConfig(string name) { }
}

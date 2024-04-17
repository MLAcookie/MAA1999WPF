using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Windows.Shapes;
using M9AWPF.JsonSerializeObject;

namespace M9AWPF.Model;

public class M9AConfig
{
    static readonly JsonSerializerOptions defaultSerializerOptions =
        new() { Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) };

    readonly M9AConfigObject m9AConfigObject;

    public string ConfigPath { get; set; }

    public string ADBPath
    {
        get { return m9AConfigObject.controller.adb_path; }
        set { m9AConfigObject.controller.adb_path = value; }
    }

    public string ADBAddress
    {
        get { return m9AConfigObject.controller.address; }
        set { m9AConfigObject.controller.address = value; }
    }

    public List<M9AConfigObject.Task> Tasks
    {
        get { return m9AConfigObject.task; }
        set { m9AConfigObject.task = value; }
    }

    public M9AConfig(string configPath)
    {
        ConfigPath = configPath;
        if (File.Exists(configPath))
        {
            StreamReader sr = File.OpenText(configPath);
            string jsonString = sr.ReadToEnd();
            m9AConfigObject = JsonSerializer.Deserialize<M9AConfigObject>(jsonString)!;
            sr.Close();
        }
        else
        {
            m9AConfigObject = new M9AConfigObject();
        }
    }

    public void SaveConfig()
    {
        var jsonString = JsonSerializer.Serialize(m9AConfigObject, defaultSerializerOptions);
        File.WriteAllText(ConfigPath, jsonString, new UTF8Encoding(false));
    }
}

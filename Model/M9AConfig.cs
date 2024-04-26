﻿using M9AWPF.JsonSerializeObject;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace M9AWPF.Model;

public class M9AConfig
{
    private static readonly JsonSerializerOptions defaultSerializeOptions =
        new() { Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) };

    private readonly M9AConfigObject m9AConfigObject;

    public string ConfigName { get; set; }

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

    internal M9AConfig(string configPath)
    {
        ConfigPath = configPath;
        ConfigName = Path.GetFileName(configPath);
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

    public async Task SaveConfig()
    {
        var jsonString = JsonSerializer.Serialize(m9AConfigObject, defaultSerializeOptions);
        await File.WriteAllTextAsync(ConfigPath, jsonString, new UTF8Encoding(false));
        M9AConfigManager.IsConfigChanged[ConfigName] = false;
    }
}
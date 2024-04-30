using System;
using System.Collections.Generic;

namespace M9AWPF.JsonSerializeObject;

[Serializable]
public class UIConfigObject
{
    public string ADBPath { get; set; } = string.Empty;
    public string ADBPort { get; set; } = string.Empty;
    public string UIVersion { get; set; } = string.Empty;
    public string HttpProxy { get; set; } = string.Empty;
    public string? LastSelectConfig { get; set; } = null;
    public bool IsLastUseTimer { get; set; } = false;
    public TaskTimerObject Timer { get; set; } = new();
}

[Serializable]
public class TimeTaskPair
{
    public string Time { get; set; } = string.Empty;
    public string ConfigFilePath { get; set; } = string.Empty;
}

[Serializable]
public class TaskTimerObject
{
    public List<TimeTaskPair> TimerTasks { get; set; } = new();
}
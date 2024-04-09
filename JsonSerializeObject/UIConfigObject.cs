using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace M9AWPF.JsonSerializeObject;

[Serializable]
class UIConfigObject
{
    public string UIVersion { get; set; } = string.Empty;
    public string HttpProxy { get; set; } = string.Empty;
    public List<TimerTaskObject> TimerTasks { get; set; } = new();
}

[Serializable]
class TimerTaskObject
{
    public string Time { get; set; } = string.Empty;
    public string ConfigFilePath { get; set; } = string.Empty;
}

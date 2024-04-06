using System.Collections.Generic;
using System.Windows.Documents;

namespace M9AWPF.Model;

public class TimerTaskObject
{
    string targetConfigFile;
    string time;
}

public class TimerTaskPipeline
{
    List<TimerTaskObject> timerTasks;
}

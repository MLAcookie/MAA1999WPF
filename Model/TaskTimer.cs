using System;
using System.Collections.Generic;
using System.Threading;
using M9AWPF.JsonSerializeObject;

namespace M9AWPF.Model;

public class TaskTimer
{
    public TaskTimerObject TaskTimerObject { get; set; }

    public List<TimeTaskPair> TimeTaskPairs
    {
        get
        {
            return TaskTimerObject.TimerTasks;
        }
    }

    public List<Timer> Timers { get; set; }

    public void RunTaskAt(int index)
    {
        DateTime now = DateTime.Now;

        string targetTimeStrng = TimeTaskPairs[index].Time;
        double tt = int.Parse(targetTimeStrng.Substring(0, 2));
        tt += int.Parse(targetTimeStrng.Substring(3, 2)) / 60.0;
        DateTime target = DateTime.Today.AddHours(tt);

        if (now > target)
        {
            now = target.AddDays(1);
        }
    }

    public void StartTimerTask()
    {
    }
}
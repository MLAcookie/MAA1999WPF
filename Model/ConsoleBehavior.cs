using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M9AWPF.Constants;

namespace M9AWPF.Model;

public class ConsoleBehavior
{
    static readonly string M9A_PATH = ConfKeys.M9ABin;

    static readonly Lazy<ConsoleBehavior> _instance = new(() => new ConsoleBehavior());

    private ConsoleBehavior() { }

    public static ConsoleBehavior Instance
    {
        get { return _instance.Value; }
    }

    public void Start()
    {
        Process m9a =
            new()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = M9A_PATH,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = false,
                    CreateNoWindow = false,
                    UseShellExecute = false,
                    Arguments = "-d", // 使MAA不进行交互，直接运行
                }
            };
        m9a.Start();
        m9a.WaitForExit();
        m9a.Close();
    }
}

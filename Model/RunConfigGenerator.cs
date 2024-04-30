using M9AWPF.Constants;

namespace M9AWPF.Model;

public class RunConfigGenerator
{
    private static readonly string OutputConfigPath = ConfKeys.M9AConfig;

    public static void GenerateConfig(M9AConfig config)
    {
        M9AConfig ans = new(OutputConfigPath)
        {
            ADBAddress = $"127.0.0.1:{UIConfigManager.GlobalABDPort}",
            ADBPath = UIConfigManager.GlobalADBPath,
            Tasks = config.Tasks,
        };
        ans.SaveConfig();
    }
}
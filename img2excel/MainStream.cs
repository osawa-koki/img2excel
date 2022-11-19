using Microsoft.Extensions.Configuration;

internal static partial class Program
{
  internal static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

  internal static void MainStream(string[] args)
  {
    if (ParamsParser.Parse(args) == false)
    {
      logger.Warn("パラメータの解析に失敗しました。");
      return;
    }
  }
}

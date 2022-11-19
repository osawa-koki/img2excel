using Microsoft.Extensions.Configuration;

internal static partial class Program
{
  internal static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

  internal static void MainStream(string[] args)
  {
    if (Parse(args) == false)
    {
      logger.Warn("パラメータの解析に失敗しました。");
      return;
    }

    if (File.Exists(target_img_file) == false)
    {
      logger.Warn($"対象画像ファイル({target_img_file})が存在しません。");
      return;
    }
  }
}

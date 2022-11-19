
using Microsoft.Extensions.Configuration;
using NLog;
using static Program;

internal class ParamsParser
{
  internal static string target_img_file = "";
  internal static string target_excel_file = "";
  
  internal static bool Parse(string[] args)
  {
    try
    {
      // コマンドライン引数の解析
      var builder = new ConfigurationBuilder();
      builder.AddCommandLine(args);

      var config = builder.Build();

      var tmp_target_img_file = config["t"];
      var tmp_target_excel_file = config["o"];

      if (tmp_target_img_file == null)
      {
        logger.Warn("-tオプションで対象画像ファイルパスを指定して下さい。");
        return false;
      }
      if (tmp_target_excel_file == null)
      {
        logger.Warn("-oオプションで出力先Excelファイルパスを指定して下さい。");
        return false;
      }

      // コマンドラインが正常なら、パラメータを設定する

      target_excel_file = tmp_target_excel_file;
      target_img_file = tmp_target_img_file;

      return true;
    }
    catch (Exception ex)
    {
      logger.Error(ex);
      return false;
    }
  }
}

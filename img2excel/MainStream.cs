using System.Drawing;
using ClosedXML.Excel;

#pragma warning disable

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
      logger.Warn("対象画像ファイルが存在しません。");
      return;
    }

    logger.Info($"画像ファイル({target_img_file})の解析を開始します。");

    // エクセル関連

    // Excelブックを作成する。
    XLWorkbook book = File.Exists(output_excel_file) ? new(output_excel_file) : new();

    // 対象の画像一覧を取得する。
    var target_imgs = Directory.GetFiles("", Path.GetFileNameWithoutExtension(target_img_file));

    foreach (var target_img in target_imgs)
    {
      Bitmap bitmap = new(target_img);
      int width = bitmap.Width;
      int height = bitmap.Height;
      
      // ファイル名を取得
      var file_name = Path.GetFileNameWithoutExtension(target_img);

      // ワークシートを追加する。
      IXLWorksheet sheet = book.Worksheets.Add(file_name);

      // 行の高さをまとめて変更する。
      sheet.Rows(1, width).Height = 4.5;
      // 列の幅をまとめて変更する。
      sheet.Columns(1, height).Width = 0.1;

      for (int x = 1; x <= width; x++)
      {
        for (int y = 1; y <= height; y++)
        {
          Color color = bitmap.GetPixel(x - 1, y - 1);
          string hex = color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
          // sheet.Cell(y, x).Value = hex;
          sheet.Cell(y, x).Style.Fill.BackgroundColor = XLColor.FromHtml($"#{hex}");
        }
      }
    }

    // Excelブックを保存保存する。
    book.SaveAs(output_excel_file);
  }
}

#pragma warning restore

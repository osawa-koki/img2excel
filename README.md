# img2excel

画像ファイルをExcelファイルに変換します。  
<https://github.com/osawa-koki/excel2img>プロジェクトの兄弟プロジェクト。

お遊びプロジェクト。

![サンプル画像](./docs/img/fruits.gif)  

## 使用した画像ファイル

- [タコ](https://frame-illust.com/?p=13667)
- [スズメ](https://frame-illust.com/?p=13680)
- [キツネ](https://frame-illust.com/?p=9584)

## 使い方

```shell
./img2excel.exe /t 対象画像ファイルパス /b 出力先ファイル名

# One By One
./img2excel.exe /t tako.png /b tako.xlsx
./img2excel.exe /t tanuki.png /b tanuki.xlsx
./img2excel.exe /t suzume.png /b suzume.xlsx

# Unixオペレーティングシステムでのワイルドカードを使用可能です。

# 全てのPNGファイルを対象
./img2excel.exe /t *.png /b animal.xlsx

# 5文字の名前のファイルを対象
./img2excel.exe /t ?????.png /b pokemon.xlsx
```

<!-- https://www.youtube.com/watch?v=2PMSwTQXYnk -->

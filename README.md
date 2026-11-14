# DathMo

[![Build and Release](https://github.com/denpadokei/DathMo/actions/workflows/build-and-release.yml/badge.svg)](https://github.com/denpadokei/DathMo/actions/workflows/build-and-release.yml)

曲の再生に合わせて、スタッフロール風のテキストを目の前から奥へ流す MOD です。テキストはテキストファイルから読み込み、曲の長さに合わせて移動します。

## 機能

- `UserData/DathMo/Staff.txt` の内容をフローティングスクリーンに表示する
- 曲の再生位置 (`songTime` / `songLength`) に合わせて、画面を手前 (z = -4) から奥 (z = 8) へ移動させる
- 画面の高さをテキストの描画高さに合わせて自動調整する
- テキストファイルが無い場合は `UserData/DathMo` フォルダと空の `Staff.txt` を自動で作成する
- フォントに Segoe UI を使用する
- ゲームプレイ設定タブから機能の ON/OFF を切り替えられる

## 動作環境

| 項目 | 内容 |
| --- | --- |
| Beat Saber | 1.39.1 |
| 依存 MOD | BSIPA ^4.3.5 / SiraUtil ^3.1.14 / BeatSaberMarkupLanguage ^1.12.3 |

## インストール

1. Beat Saber を 1.39.1 に合わせる (BSManager などのバージョン管理ツールを推奨)
2. BSIPA と上記の依存 MOD をインストールする
3. [Releases](https://github.com/denpadokei/DathMo/releases) から `DathMo-1.0.0-bs1.39.1.zip` をダウンロードし、`Plugins` フォルダをゲームフォルダへ上書きコピーする

## 使い方

1. 一度ゲームを起動すると `UserData/DathMo/Staff.txt` が作成されます (空ファイル)。
2. `Staff.txt` に表示したい文章を書きます。改行はそのまま画面の改行になります。
3. 曲をプレイすると、テキストがスタッフロールのように手前から奥へ流れます。

## 設定

ゲームプレイ設定の `DathMo` タブで設定します。

| 項目 | 型 | 既定値 | 説明 |
| --- | --- | --- | --- |
| Enable | bool | true | スタッフロール表示を有効にする |

設定は `UserData/DathMo.json` に保存されます。

## ビルド

```powershell
git clone https://github.com/denpadokei/DathMo.git
cd DathMo
dotnet build .\DathMo\DathMo.csproj -c Release
```

`BeatSaberDir` (または `GameDirectory`) に Beat Saber のインストール先を設定すると、ゲームの参照アセンブリを解決できます。

GitHub Actions の `build-and-release.yml` が push ごとにビルドし、`X.X.X` 形式のタグを push するとリリースを作成します。

## ライセンス

MIT

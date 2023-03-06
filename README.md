# GameOfLifeCSharp

- このリポジトリは、C#の学習のために作成されたライフゲームの実装です。
- ライフゲームは、セルオートマトンの一種であり、生物の群れの進化をモデル化するためのものです。
- ロジック部分のコードと、それを使用したコンソールアプリケーションのコードが含まれています。
    - ロジック部分はコンソールに依存せず、描画先は他のものに差し替えられるように設計されています。

```
□ ■ ■ ■ □ ■ □ ■ □ □ ■ □ □ ■ ■ ■ □ □ □ □ □ ■ □ □ □ □ □ ■ □ ■
□ ■ ■ ■ □ ■ □ ■ □ ■ □ ■ □ ■ □ ■ □ ■ ■ ■ ■ □ □ ■ □ □ ■ ■ ■ ■
■ ■ □ □ □ ■ □ □ ■ □ ■ ■ □ ■ □ □ ■ □ □ ■ ■ ■ ■ ■ □ ■ ■ □ □ ■
□ □ ■ ■ □ ■ ■ ■ □ ■ □ ■ □ □ ■ □ ■ ■ □ ■ ■ ■ ■ □ □ □ ■ □ ■ ■
■ ■ ■ □ □ ■ □ □ ■ ■ □ □ □ ■ ■ □ □ □ □ □ ■ □ □ ■ ■ □ □ ■ ■ □
■ ■ ■ ■ ■ ■ □ □ ■ □ □ ■ □ ■ ■ ■ ■ ■ ■ □ □ □ ■ ■ □ ■ □ ■ ■ ■
□ □ ■ □ ■ □ ■ ■ ■ □ ■ ■ □ ■ ■ □ ■ □ □ □ □ □ ■ ■ □ ■ □ □ ■ □
■ □ □ □ ■ ■ □ ■ □ □ ■ ■ □ □ ■ ■ ■ ■ □ ■ □ □ ■ ■ □ ■ ■ ■ □ □
■ ■ □ ■ □ □ □ □ ■ □ ■ ■ ■ □ □ ■ ■ □ ■ □ □ ■ ■ ■ □ □ □ □ □ ■
■ ■ □ □ □ ■ □ ■ ■ ■ ■ □ □ ■ □ □ □ ■ □ □ ■ □ □ □ ■ ■ □ ■ □ □
■ □ □ □ ■ ■ ■ ■ ■ ■ □ □ ■ □ □ □ □ □ ■ □ ■ ■ ■ □ □ ■ ■ ■ ■ □
■ ■ □ □ ■ □ □ ■ □ □ □ ■ □ □ ■ ■ ■ ■ □ ■ ■ ■ ■ ■ ■ □ ■ ■ □ □
■ ■ ■ ■ ■ □ ■ □ □ ■ □ □ ■ □ ■ □ □ □ ■ □ □ □ □ ■ □ ■ □ □ □ ■
■ ■ □ ■ □ □ ■ ■ ■ ■ □ □ ■ ■ ■ ■ ■ ■ □ ■ □ □ ■ ■ □ ■ □ ■ □ □
■ ■ □ □ ■ □ □ □ ■ ■ ■ ■ ■ ■ □ □ ■ □ □ □ ■ ■ □ ■ ■ □ □ ■ □ □
■ ■ ■ □ □ □ ■ ■ ■ ■ ■ ■ ■ □ ■ ■ □ ■ ■ □ □ □ ■ ■ ■ □ ■ ■ ■ ■
■ □ ■ ■ □ □ □ ■ ■ □ □ □ ■ ■ □ ■ ■ ■ □ □ □ ■ ■ □ □ □ ■ □ □ ■
■ ■ □ ■ □ □ □ ■ □ ■ □ ■ □ □ ■ □ ■ ■ ■ ■ ■ ■ ■ □ ■ ■ □ ■ ■ ■
■ ■ ■ □ □ ■ ■ ■ ■ ■ □ □ ■ ■ ■ □ □ □ □ □ ■ □ □ □ ■ ■ □ ■ ■ □
□ □ ■ ■ □ ■ ■ □ ■ ■ □ ■ ■ ■ □ □ □ ■ □ □ □ □ ■ □ ■ ■ ■ ■ □ □
□ ■ ■ □ ■ ■ □ ■ □ □ ■ □ □ □ □ ■ □ □ ■ □ ■ □ □ □ ■ □ □ ■ □ □
□ □ ■ □ □ ■ ■ □ ■ ■ □ ■ □ ■ ■ ■ ■ □ □ ■ □ ■ □ □ □ □ □ □ ■ ■
■ □ ■ □ ■ ■ ■ □ □ ■ □ ■ □ □ □ ■ ■ □ ■ □ □ □ ■ □ ■ □ □ □ ■ ■
□ □ ■ ■ □ ■ ■ □ ■ ■ □ □ □ ■ □ □ ■ ■ □ □ □ ■ ■ ■ ■ □ □ □ ■ □
□ ■ ■ □ ■ ■ □ □ □ ■ □ □ □ ■ ■ ■ ■ □ ■ ■ ■ ■ □ ■ □ □ □ □ □ ■
□ □ ■ ■ □ □ ■ □ ■ ■ □ □ □ □ ■ ■ □ ■ □ ■ ■ □ □ □ □ ■ ■ ■ ■ ■
□ □ □ □ □ ■ □ □ □ ■ ■ ■ ■ ■ ■ □ □ ■ ■ □ ■ ■ □ □ □ ■ ■ □ □ ■
■ □ ■ □ ■ ■ ■ ■ ■ □ □ □ ■ ■ □ ■ ■ □ □ □ ■ □ ■ ■ □ □ □ ■ □ ■
■ □ □ □ ■ □ ■ ■ ■ ■ ■ □ □ □ ■ □ □ □ ■ ■ □ ■ □ ■ ■ □ ■ ■ ■ □
□ □ ■ □ ■ □ □ □ ■ □ ■ □ □ ■ ■ □ □ ■ ■ □ □ ■ ■ ■ ■ ■ ■ ■ □ □
```

## ルール

ライフゲームでは、各セルは8つの近傍セルと隣接しており、次のルールに従って状態が変化します。

- 生きているセルが2つか3つの近傍セルと隣接していれば、次の世代でも生き続ける。
- 生きているセルが1つ以下または4つ以上の近傍セルと隣接していれば、過疎または過密により死ぬ。
- 死んでいるセルがちょうど3つの近傍セルと隣接していれば、誕生して生きる。

## 実行方法

このプロジェクトをビルドするには、Visual Studio 2019以降が必要です。ソリューションファイル`GameOfLifeCSharp.sln`を開いてビルドし、実行してください。

## 参考資料

このプロジェクトは以下のサイトを参考にしました。

- [ライフゲーム - フリー百科事典『ウィキペディア（Wikipedia）](https://ja.wikipedia.org/wiki/%E3%83%A9%E3%82%A4%E3%83%95%E3%82%B2%E3%83%BC%E3%83%A0)
- [Conway's Game of Life - Wikipedia, the free encyclopedia](https://conwaylife.com/)
- [Play John Conway's Game of Life](https://playgameoflife.com/)
# BindUWP
Data Binding on UWP

## Overview

最新のUWPでd:DesignInstanceが使えない問題の解決方法を調べる。

## Tips

### x:Bind

コードビハインドのプロパティでビューモデルを持つ。

ページのプロパティとしてビューモデルが存在するため、
DesignContextのような設定なしで、
xamlからそのままプロパティにx:Bindできる。

インテリセンスは効くが、表示は全くされない。

ViewModelのpublicメソッドをClickイベントなどに
直接バインドできるため、
コードビハインドのイベント関数を持たなくてよい。

ただし、引数を指定できない。

ICommandと違いCanCommitはViewModelの中で
プロパティとして実装が必要となる。

準備不要であったりインテリセンスが効くなど
至れり尽くせりの最新機能だ
が表示できないことだけが残念。

Anniversaryだとマニュアル通りにプレースホルダー値が
表示される。新しいバージョンのバグらしい。

Fall Creators Update(10.0.16299)以降を
ターゲットにすると表示されなくなる。
.NetStandard1.5以降では使えないということになってしまう。

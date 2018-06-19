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

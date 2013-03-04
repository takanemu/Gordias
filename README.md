Welcome to Gordias WPF MVVM framework library.
==========

Gordiasは、Livet MVVM インフラストラクチャ<http://ugaya40.net/livet>を利用しつつコーディング量を減らす目的で開発されています。
リフレクションを多用しているため高速で動作させる用途には向きませんが、アプリケーションを構成する多くの部分では、高速な動作よりもコーディング量の減少とそれに伴うメンテンナンス性の向上の方が有用です。
高速動作が必要な部分では、従来のコーディング方法を併用することが可能です。

Library details
-----------------
(1)CommandとPropertyをViewModelから分離
　ViewModelは、View偏重のWPFでは大きくなりがちになります。Modelへの処理の分離をしたとしてもViewとの繋ぎ部分に、繰り返し同じ処理を記述しなければなりません。
Gordiasでは、下記のように、ViewModelクラスとCommand処理クラスとProperty処理クラスを分離し見通しの良いコーディングを実現します。

public class MainWindowViewModel : TacticsViewModel<MainWindowViewModelProperty, MainWindowViewModelCommand>
{}
public class MainWindowViewModelProperty : TacticsProperty
{}
public class MainWindowViewModelCommand
{}

(2)Commandの実装
　ボタンからのコマンドを受け取る処理を記述するには、下記のようにします。
MainWindowViewModelCommandクラスに、プロパティを一行登録し、プロパティ名と同じ名前のメソッドをMainWindowViewModelクラスへ登録するだけで、コマンドの受け取り処理は完成します。[Command]は、メソッドをコマンド用だとプログラムに判定させるための属性です。

public class MainWindowViewModel : TacticsViewModel<MainWindowViewModelProperty, MainWindowViewModelCommand>
{
    [Command]
    private void TestButton()
    {
        MessageBox.Show("テスト");
    }
}

public class MainWindowViewModelCommand
{
    public TacticsCommand TestButton { get; private set; }
}

<Button Command="{Binding Commands.TestButton, Mode=OneWay}" Grid.Row="1" Content="テスト"/>

(2)Propertyの実装
　プログラムは、MainWindowViewModelPropertyクラスへプロパティを実装するだけで、PropertyChangedEventの発生を補完します。

public class MainWindowViewModelProperty : TacticsProperty
{
    public virtual bool IsCheck { get; set; }
}

<CheckBox IsChecked="{Binding Propertys.IsCheck, Mode=TwoWay}" Content="Button Enable"/>

(3)ViewModel間の通信用の特殊Model

(4)グローバルデータを保持する特殊Model

以上

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Broadleaf.Library;

//*******************************************************************************//
// System           :   ＳＦ．ＮＥＴ                                             //
// Sub System       :                                                            //
// Program name     :   ＳＣＭ設定　ＵＩクラス    　　　　　　　　               //
//                  :   SFCMN02561U.DLL								             //
// Name Space       :   Broadleaf.Windows.Forms                                  //
// Programmer       :   95094  大塚　たえ子	                                     //
// Date             :   2009.05.22                                               //
//-------------------------------------------------------------------------------//
// Update Note      :   2009.07.15 22024　寺坂　誉志                             //
//                  :   １．構造を大幅に変更(コメント無しで修正)                 //
// Update Note      :   2011.07.21 duzg                                          //
//                  :    パスワード入力確認画面を追加する                        //
// Update Note      :   2011.08.12 x_zhuxk                                       //
//                  :    PCCUOE                                                  //
// Update Note      :   2011.10.132 呉軍                                         //
//                  :    Redmine#25912:１．更新モードで自社情報の拠点コードが存在//
//                  :    しない場合、メッセージを表示するように修正              //
//-------------------------------------------------------------------------------//
//                 Copyright(c)2009 Broadleaf Co.,Ltd.                           //
//*******************************************************************************//

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("SFCMN02561U")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Broadleaf.NS series")]
[assembly: AssemblyCopyright("(c)2009 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark(".NS")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDeployment(DeployPosition.Client)]		

// ComVisible を false に設定すると、このアセンブリ内の型は COM コンポーネントには 
// 参照不可能になります。COM からこのアセンブリ内の型にアクセスする場合は、 
// その型の ComVisible 属性を true に設定してください。
[assembly: ComVisible(false)]

// 次の GUID は、このプロジェクトが COM に公開される場合の、typelib の ID です
[assembly: Guid("a4231634-283b-439f-a1c7-9389338d55c3")]

// アセンブリのバージョン情報は、以下の 4 つの値で構成されています:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
[assembly: AssemblyVersion("5.20.1.0")]
[assembly: AssemblyFileVersion("5.20.1.0")]
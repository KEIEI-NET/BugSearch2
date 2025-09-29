//**********************************************************************//
// System           :   ＳＦ．ＮＥＴ                                     //
// Sub System       :                                                   //
// Program name     :   SuperFrontman.NSメインメニュー(マトリクスタイプ)  //
//                  :    業務メニュー                                    //
//                  :   SFNETMENU2.exe                                  //
// Name Space       :   Broadleaf.Windows.Forms                         //
// Programmer       :   鹿野 幸生　　                                    //
// Date             :   2006.09.04                                      //
//----------------------------------------------------------------------//
// Update Note      :   2006.09.29  鹿野　幸生                           //
//                  :   詳細表示部のシステムオプション判別改良             //
// Update Note      :   2007.01.10  鹿野　幸生                           //
//                  :   1 Vista対応                                     //
//                  :   2 タブコントロールの描画色をカテゴリ同調           //
//                  :   3 カスタム色削除でエラーが発生する場合の有る障害を //
//                  :     解除                                          //
//                  :   4 ユーザーメニュー作成時に詳細表示内容が選択できる //
//                  :     障害を解除                                    //
//                  :   5 ユーザーメニューが初期表示できない障害を解除     //
// Update Note      :   2007.02.23  鹿野　幸生                           //
//                  :   1 BK単体＋申請書類を可能にｓる為にシステムチェック //
//                  :     方法を変更                                     //
//----------------------------------------------------------------------//
//                    (c)2006 Broadleaf Co.,Ltd.                        //
//**********************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Broadleaf.Library;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle(".NS業務メニュー")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Partsman")]
[assembly: AssemblyCopyright("(c)2008 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark("Partsman")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDeployment(DeployPosition.Client)]

// ComVisible を false に設定すると、このアセンブリ内の型は COM コンポーネントには 
// 参照不可能になります。COM からこのアセンブリ内の型にアクセスする場合は、 
// その型の ComVisible 属性を true に設定してください。
[assembly: ComVisible(false)]


// アセンブリのバージョン情報は、以下の 4 つの値で構成されています:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
[assembly: AssemblyVersion("8.10.1.0")]
[assembly: AssemblyFileVersion("8.10.1.0")]

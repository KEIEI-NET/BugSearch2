//**********************************************************************//
// System           :   PM.NS　                                         //
// Sub System       :                                                   //
// Program name     :   S&E売上データテキスト出力アクセスクラス         //
//                  :   PMSAE02015A.DLL                                 //
// Name Space       :   Broadleaf.Application.Controller                //
// Programmer       :   張凱                                            // 
// Date             :   2009.08.13                                      // 
//----------------------------------------------------------------------//
//UpdateNote        : 2012/12/07 zhuhh</br>                             //
//                  : Ｓ＆ＥブレーキＡＢ商品コードの桁数の改修</br>     //
//----------------------------------------------------------------------//
//UpdateNote        : 2013/02/25 zhuhh</br>                             //
//                  : Ｓ＆Ｅ(AB) テキスト出力のレイアウト変更           //
//----------------------------------------------------------------------//
//UpdateNote        : 2013/05/21 zhuhh</br>                             //
//                  : テキスト出力自動送信Javaツールを利用する          //
//----------------------------------------------------------------------//
//UpdateNote        : 2013/06/24 zhuhh</br>                             //
//                  : S&Eブレーキ送信コマンド                           //
//----------------------------------------------------------------------//
// UpdateNote       : 2013/06/26 田建委                                 //
//                  : 自動送信処理の追加及び送信ログの登録              //
//----------------------------------------------------------------------//
// UpdateNote       : 2013/07/25 田建委                                 //
//                  : Redmine#39145 エラー発生時もS&E売上抽出データ更新した場合がある対応//
//----------------------------------------------------------------------//
// UpdateNote       : 2013/08/07 田建委                                 //
//                  : Redmine#39695 抽出結果無時の結果画面表示の変更対応//
//----------------------------------------------------------------------//
// UpdateNote       : 2013/08/12 田建委                                 //
//                  : Redmine#39695 抽出結果無時のログ内容の変更対応    //
//----------------------------------------------------------------------//
//                Copyright(c)2009 Broadleaf Co.,Ltd.                   //
//**********************************************************************//

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Broadleaf.Library;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("PMSAE02015A")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Partsman")]
[assembly: AssemblyCopyright("(c)2009 Broadleaf Co.,Ltd.")]
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


using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;
using Broadleaf.Application.Resources;

//**********************************************************************//
// System           :   PM.NS　　　　                                   //
// Sub System       :                                                   //
// Program name     :   在庫リモートオブジェクト				        //
//                  :   MAZAI04134R.DLL									//
// Name Space       :   Broadleaf.Application.Remoting					//
// Programmer       :   22008　長内　数馬	                            //
// Date             :   2008.07.02                                      //
//----------------------------------------------------------------------//
// Update Note      :   2011/07/12 施炳中                               //
//                  :   連番No.1027 発注残がマイナスになる場合は、      //
//                      固定で０をセットしているが、卸商仕入受信が      //
//                      起動元となる場合は、発注残のマイナスを許可する。//
//----------------------------------------------------------------------//
// Update Note      :   2011/07/20 施炳中                               //
//                  :   Redmine#23074 先頭から「：」までの文字列が      //
//                     「PMUOE01300U」か否かの判定の対応               //
//----------------------------------------------------------------------//
// Update Note      :   2012/05/29 zhangy3                              //
//                  :   10801804-00 2012/06/27配信分 Redmine#30029      //
//                      在庫マスタ一覧印刷 特定条件下での印刷不具合     //
//----------------------------------------------------------------------//
// Update Note      :   2014/08/13 劉超                                 //
//                  :   PMSCM同期化対応の変更                           //
//----------------------------------------------------------------------//
// Update Note      :    K2020/03/25 陳艶丹                             //
//                  :    PMKOBETSU-3622対応 UOE発注送信不具合の対応     //
//----------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

//
// アセンブリに関する一般情報は以下の 
// 属性セットを通して制御されます。アセンブリに関連付けられている 
// 情報を変更するには、これらの属性値を変更してください。
//
[assembly: AssemblyTitle("MAZAI04134R.DLL")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Partsman")]
[assembly: AssemblyCopyright("(c)2008 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark("Partsman")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDeployment(DeployPosition.Server, ConstantManagement_SF_PRO.ServerCode_UserAP)]		

//
// アセンブリのバージョン情報は、以下の 4 つの属性で構成されます :
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// 下にあるように、'*' を使って、すべての値を指定するか、
// ビルドおよびリビジョン番号を既定値にすることができます。

[assembly: AssemblyVersion("8.10.1.0")]
[assembly: AssemblyFileVersion("8.10.1.0")]

//
// アセンブリに署名するには、使用するキーを指定しなければなりません。 
// アセンブリ署名に関する詳細については、Microsoft .NET Framework ドキュメントを参照してください。
//
// 下記の属性を使って、署名に使うキーを制御します。 
//
// メモ : 
//   (*) キーが指定されないと、アセンブリは署名されません。
//   (*) KeyName は、コンピュータにインストールされている
//        暗号サービス プロバイダ (CSP) のキーを表します。KeyFile は、
//       キーを含むファイルです。
//   (*) KeyFile および KeyName の値が共に指定されている場合は、 
//       以下の処理が行われます :
//       (1) KeyName が CSP に見つかった場合、そのキーが使われます。
//       (2) KeyName が存在せず、KeyFile が存在する場合、 
//           KeyFile にあるキーが CSP にインストールされ、使われます。
//   (*) KeyFile を作成するには、sn.exe (厳密な名前) ユーティリティを使ってください。
//       KeyFile を指定するとき、KeyFile の場所は、
//       プロジェクト出力 ディレクトリへの相対パスでなければなりません。
//       パスは、%Project Directory%\obj\<configuration> です。たとえば、KeyFile がプロジェクト ディレクトリにある場合、
//       AssemblyKeyFile 属性を 
//       [assembly: AssemblyKeyFile("..\\..\\mykey.snk")] として指定します。
//   (*) 遅延署名は高度なオプションです。
//       詳細については Microsoft .NET Framework ドキュメントを参照してください。
//
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile("")]
[assembly: AssemblyKeyName("")]

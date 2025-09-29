//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :	UOE入庫更新アクセスクラス						//
//                  :   PMUOE01203A.DLL                                 //
// Name Space		:	Broadleaf.Application.Controller				//
// Programmer       :   照田 貴志										// 
// Date             :   2008/09/04                                      // 
//----------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 鄧潘ハン　　　　　　　　　　　　　　//
// 修 正 日  2012/08/30  修正内容 : 2012/09/12配信分、                  //
//                                  redmine #31885:吉田商会　　　　　　 //
//                                  在庫入庫更新処理の対応。            //
// 管理番号              作成担当 : chenw   　　　　　　　　　　　　　　//
// 修 正 日  2013/03/07  修正内容 : 2013/04/03配信分                    //
//                                  Redmine#34989の対応日産UOEWEBの     //
//                                  改良(ＯＰＥＮ価格対応)              //
// 管理番号  10801804-00 作成担当 : 李占川    　　　　　　　　　　　　　//
// 修 正 日  2013/05/16  修正内容 : 2013/06/18配信分                    //
//                                  Redmine#35459 #42の対応　　　　　　 //
// 管理番号  11070149-00 作成担当 : 高騁    　　　　　　　　　　　　    //
// 修 正 日  2015/01/21  修正内容 : 2015/01/21配信分                    //
//                                  Redmine#44056 在庫入庫更新で　　　　//
//                                  締月次チェックの修正の対応          //
// 管理番号  11170129-00 作成担当 : 宋剛    　　　　　　　　　　　　    //
// 修 正 日  2015/08/26  修正内容 : Redmine#47030 【№332】在庫入庫更新 //
//                                  の障害対応                    　　　//
//----------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 譚洪    　　　　　　　　　　　　    //
// 修 正 日  2017/08/11  修正内容 : ハンディターミナル在庫仕入登録の対応//
//----------------------------------------------------------------------//
//                 Copyright(c)2008 Broadleaf Co.,Ltd.                  //
//**********************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;


// アセンブリに関する一般情報は以下の 
// 属性セットを通して制御されます。アセンブリに関連付けられている 
// 情報を変更するには、これらの属性値を変更してください。
[assembly: AssemblyTitle("PMUOE01203A")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("DistributionCore")]
[assembly: AssemblyCopyright("(c)2008 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark("DistributionCore")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDeployment(DeployPosition.Client)]		

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

[assembly: AssemblyVersion("1.10.1.0")]
[assembly: AssemblyFileVersion("1.10.1.0")]

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

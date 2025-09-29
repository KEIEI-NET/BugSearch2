//**********************************************************************//
// System           :   ＳＦ．ＮＥＴ                                    //
// Sub System       :                                                   //
// Program name     :   請求書一覧表詳細タイプフォーム印刷クラス        //
//                  :   MAKAU02020P_02A4C.DLL                           //
// Name Space       :   Broadleaf.Drawing.Printing                      //
// Programmer       :   Y.Sasaki                                        //
// Date             :   2006.08.01                                      //
//----------------------------------------------------------------------//
// Update Note      :   2006.08.01  Y.Sasaki                            //
//                  :   １.ヘッダコメント追加                           //
// Update Note      :   2006.08.21  Y.Sasaki                            //
//                  :   １.合計行ヘッダー出力対応                       //
// Update Note      :   20081 疋田 勇人                                 //
//                  :   2007.10.15 DC.NS用に変更                        //
//----------------------------------------------------------------------//
// Update Note      :   2008.09.04 30413 犬飼                           //
//   		        :	PM.NS対応									    //
//----------------------------------------------------------------------//
// Update Note      :   2011/03/14 yangmj                               //
//   		        :	印字制御の区分の追加対応					    //
//----------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf                               //
// 修 正 日  2012/11/15  修正内容 : 1月16日配信分、Redmine#32160 PM.NS障害一覧No.1060の対応//
//                                : 請求一覧表印刷表現不全の対応、Design画面項目のプロパティの改修だけ       //
//----------------------------------------------------------------------//
// Update Note      :   2020/04/13 陳艶丹                               //
//   		        :	11570208-00 軽減税率対応                        //
//----------------------------------------------------------------------//
//                Copyright(c)2006 Broadleaf Co.,Ltd.                   //
//**********************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;

//
// アセンブリに関する一般情報は以下の 
// 属性セットを通して制御されます。アセンブリに関連付けられている 
// 情報を変更するには、これらの属性値を変更してください。
//
[assembly: AssemblyTitle("MAKAU02020P_02A4C")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Partsman")]
[assembly: AssemblyCopyright("(c)2008 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark("Partsman")]
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

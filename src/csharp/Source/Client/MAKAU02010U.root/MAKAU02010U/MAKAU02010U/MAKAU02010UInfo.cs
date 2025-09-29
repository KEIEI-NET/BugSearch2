//**********************************************************************//
// System           :   ＭＡ．ＮＥＴ                                    //
// Sub System       :                                                   //
// Program name     :   請求帳票フレームクラス                          //
//                  :   MAKAU02010U.DLL                                 //
// Name Space       :   Broadleaf.Windows.Forms                         //
// Programmer       :   Y.Sasaki                                        //
// Date             :   2006.08.01                                      //
//----------------------------------------------------------------------//
// Update Note      :   2006.08.01  Y.Sasaki                            //
//                  :   １.ヘッダコメント追加                           //
// Update Note      :   2006.08.31  Y.Sasaki                            //
//                  :   １.テキスト出力対応                             //
// Update Note      :   2006.09.14  Y.Sasaki                            //
//                  :   １.抽出・印刷中のツールバー制御対応             //
// Update Note      :   20081 疋田 勇人                                 //
//                  :   2007.10.15 DC.NS用に変更                        //
//----------------------------------------------------------------------//
// Update Note      :   2008.09.04 30413 犬飼                           //
//   		        :	PM.NS対応									    //
//----------------------------------------------------------------------//
// Update Note      :   2010/02/25 30531 大矢　睦美                     //
//   		        :	Mantis【15053】複数PGを起動したときにタスクバー //
//                  :             　　にPG名が表示されるようにする      //
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
// --- ADD  大矢睦美  2010/02/25 ---------->>>>>
//[assembly: AssemblyTitle("MAKAU02010U")]
[assembly: AssemblyTitle("請求管理")]
// --- ADD  大矢睦美  2010/02/25 ----------<<<<<
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

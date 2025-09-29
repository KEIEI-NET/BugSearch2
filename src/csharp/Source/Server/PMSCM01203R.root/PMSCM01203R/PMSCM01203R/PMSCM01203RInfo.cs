//********************************************************************//
// System           :   PM.NS                                         //
// Sub System       :                                                 //
// Program name     :   自動送受信バッチ処理クラス                    //
//                  :   PMSCM01203R.DLL                               //
// Name Space       :   Broadleaf.Application.Remoting                //
// Programmer       :   qianl                                         //
// Date             :   2011.07.21                                    //
//--------------------------------------------------------------------//
// Update Note      :   障害報告 #23716                               //
// Programmer       :   qianl                                         //
// Date             :   2011.08.17                                    //
//--------------------------------------------------------------------//
// Update Note      :   障害報告 #23848                               //
// Programmer       :   gaoy                                          //
// Date             :   2011.08.22                                    //
//--------------------------------------------------------------------//
// Update Note      :   仕様連絡 #24006                               //
// Programmer       :   gaoy                                          //
// Date             :   2011.08.25                                    //
//--------------------------------------------------------------------//
// Update Note      :   障害報告 #24068                               //
// Programmer       :   gaoy                                          //
// Date             :   2011.08.29                                    //
//--------------------------------------------------------------------//
// Update Note      :   仕様連絡 #24126                               //
// Programmer       :   gaoy                                          //
// Date             :   2011.08.30                                    //
//--------------------------------------------------------------------//
// Update Note      :   仕様連絡 #25021                               //
// Programmer       :   gaoy                                          //
// Date             :   2011.09.14                                    //
//--------------------------------------------------------------------//
// Update Note      :   PMKOBETSU-4005 ＥＢＥ対策                     //
// Programmer       :   陳艶丹                                        //
// Date             :   2020/06/18                                    //
//--------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.               //
//********************************************************************//

using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;
using Broadleaf.Application.Resources;

//
// アセンブリに関する一般情報は以下の 
// 属性セットを通して制御されます。アセンブリに関連付けられている 
// 情報を変更するには、これらの属性値を変更してください。
//
[assembly: AssemblyTitle("PMSCM01203R")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Partsman")]
[assembly: AssemblyCopyright("(c)2011 Broadleaf Co.,Ltd.")]
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

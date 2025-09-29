//******************************************************************************//
// System           :   PM.NS                                                   //
// Sub System       :                                                           //
// Program name     :   PCCキャンペーン設定マスタメンテ  データパラメータ       //
//                  :   PMPCC09066D.DLL									        //
// Name Space       :   Broadleaf.Application.Remoting.ParamData     	        //
// Programmer       :   自動生成      	                          　　          //
// Date             :   2011.08.11                                              //
//------------------------------------------------------------------------------//
// Update Note      :													        //
//------------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.                         //
//******************************************************************************//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 三戸　伸悟
// 作 成 日  2012/11/20  修正内容 : 12/12配信 システムテスト障害№49対応
//----------------------------------------------------------------------------//

using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;
using Broadleaf.Application.Resources;

//
// アセンブリに関する一般情報は以下の 
// 属性セットを通して制御されます。アセンブリに関連付けられている 
// 情報を変更するには、これらの属性値を変更してください。
//
[assembly: AssemblyTitle("PMPCC09066D")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Partsman")]
[assembly: AssemblyCopyright("(c)2011 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark("Partsman")]
[assembly: AssemblyCulture("")]

// --- UPD 2012/11/20 三戸 2012/12/12配信分 システムテスト障害№49 --------->>>>>>>>>>>>>>>>>>>>>>>>
//[assembly: AssemblyDeployment(DeployPosition.Common, ConstantManagement_SF_PRO.ServerCode_UserAP)]
[assembly: AssemblyDeployment(DeployPosition.Common, ConstantManagement_SF_PRO.ServerCode_SCM_UserAP)]
// --- UPD 2012/11/20 三戸 2012/12/12配信分 システムテスト障害№49 ---------<<<<<<<<<<<<<<<<<<<<<<<<

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

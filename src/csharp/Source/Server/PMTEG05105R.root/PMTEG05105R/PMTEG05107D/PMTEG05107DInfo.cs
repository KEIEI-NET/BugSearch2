﻿//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 決済手形消込処理
// プログラム概要   : オプションフラグ（手形）が「あり」の場合に満期日が過ぎた手形データに対してデータの消し込み処理を行う。
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張義
// 作 成 日  2010/04/22  修正内容 : 新規作成
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
[assembly: AssemblyTitle("PMTEG05107D")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Partsman")]
[assembly: AssemblyCopyright("(c)2010 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark("Partsman")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDeployment(DeployPosition.Common, ConstantManagement_SF_PRO.ServerCode_UserAP)]

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

//**********************************************************************//
// System           :   ＳＦ．ＮＥＴ                                    //
// Sub System       :                                                   //
// Program name     :   オフラインデータシリアライザ					//
//                  :   SFCMN00024C.DLL									//
// Name Space       :   Broadleaf.Library.Runtime.Serialization			//
// Programmer       :   96137  久保田　信一								//
// Date             :   2005.10.24                                      //
//----------------------------------------------------------------------//
// Update Note      :													//
//----------------------------------------------------------------------//
//                 Copyright(c)2006 Broadleaf Co.,Ltd.                  //
//**********************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;

[assembly: AssemblyTitle("SFCMN00024C")]
[assembly: AssemblyDescription("")]
//[assembly: AssemblyConfiguration("")] // → Properties\AssemblyInfo.csで定義
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("SuperFrontman")]
[assembly: AssemblyCopyright("(c)2005 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark("SuperFrontman")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDeployment(DeployPosition.Common)]

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
[assembly: AssemblyVersion("5.10.1.0")]
[assembly: AssemblyFileVersion("5.20.1.0")]

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

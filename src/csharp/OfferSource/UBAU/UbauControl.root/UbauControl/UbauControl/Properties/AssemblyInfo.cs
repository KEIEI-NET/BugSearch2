﻿//**********************************************************************//
// System			:	PM.NS									        //
// Sub System       :                                                   //
// Program name     :   認証情報設定クラス                              //
//                  :   UbauControl.DLL                                 //
// Name Space		:	Broadleaf.Windows.Forms							//
// Programmer		:	佐々木 健   									//
// Date				:	2009.02.16										//
//----------------------------------------------------------------------//
// Update Note		:													//
//----------------------------------------------------------------------//
//                 Copyright(c)2009 Broadleaf Co.,Ltd.                  //
//**********************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("UbauControl")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Partsman")]
[assembly: AssemblyCopyright("(c)2009 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark("Partsman")]
[assembly: AssemblyCulture("")]

// ComVisible を false に設定すると、このアセンブリ内の型は COM コンポーネントには 
// 参照不可能になります。COM からこのアセンブリ内の型にアクセスする場合は、 
// その型の ComVisible 属性を true に設定してください。
[assembly: ComVisible(false)]

// 次の GUID は、このプロジェクトが COM に公開される場合の、typelib の ID です
[assembly: Guid("696511e4-8aa6-469a-a974-d9aa561ca3a8")]

// アセンブリのバージョン情報は、以下の 4 つの値で構成されています:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// すべての値を指定するか、下のように '*' を使ってリビジョンおよびビルド番号を 
// 既定値にすることができます:
[assembly: AssemblyVersion("1.10.1.0")]
[assembly: AssemblyFileVersion("1.10.1.0")]

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
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile("")]
[assembly: AssemblyKeyName("")]

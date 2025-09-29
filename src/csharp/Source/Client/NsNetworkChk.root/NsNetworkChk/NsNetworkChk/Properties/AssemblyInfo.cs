//**********************************************************************//
// System			:	Brpadleaf.NS									//
// Sub System		:													//
// Program name		:	NSネットワーク通信テスト						//
//					:	NSNetworkTest.exe								//
// Name Space		:	Broadleaf.NSNetworkTest.UI						//
// Programmer		:	23002 上野　耕平								//
// Date				:	2007.10.31										//
//----------------------------------------------------------------------//
// Update Note		:	2019.01.02 朱宝軍								//
//					:	①AWS通信テスト結果をDBに登録する処理の追加		//
//					:	②AWS通信自動テスト処理の追加					//
//					:	③FTPチェック処理の追加							//
//----------------------------------------------------------------------//
//				(c)Copyright  2008 Broadleaf Co.,Ltd.					//
//**********************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Broadleaf.Library;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("NSNetworkTest")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Broadleaf.NS series")]
[assembly: AssemblyCopyright("(c)2008 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark(".NS")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDeployment(DeployPosition.Client)]

// ComVisible を false に設定すると、このアセンブリ内の型は COM コンポーネントには 
// 参照不可能になります。COM からこのアセンブリ内の型にアクセスする場合は、 
// その型の ComVisible 属性を true に設定してください。
[assembly: ComVisible(false)]

// 次の GUID は、このプロジェクトが COM に公開される場合の、typelib の ID です
[assembly: Guid("f43d2995-5e5e-48f0-9472-45624282fa8f")]

// アセンブリのバージョン情報は、以下の 4 つの値で構成されています:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
[assembly: AssemblyVersion("2.0.0.1")]
[assembly: AssemblyFileVersion("2.0.0.1")]

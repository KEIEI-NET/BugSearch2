//**********************************************************************//
// System			:	DC.NS											//
// Sub System		:													//
// Program name		:	発注一覧表アクセスクラス						//
//					:	DCZAI02166A.DLL									//
// Name Space		:	Broadleaf.Application.Controller				//
// Programmer		:	22018 鈴木正臣									//
// Date				:	2007.09.11										//
//----------------------------------------------------------------------//
// Update Note      :   2008.09.01 30413 犬飼                           //
//   		        :	PM.NS対応									    //
//----------------------------------------------------------------------//
// Update Note      :   liyp 2011/04/11                                 //
//   		        :	障害改良対応(2011年04月)					    //
//----------------------------------------------------------------------//
// Update Note      :   zhangy3 2012/10/16                              //
//   		        :	障害改良対応Redmine#32860					    //
//----------------------------------------------------------------------//
// Update Note      :   donggy 2012/11/27                              //
//   		        :	Redmine#33267 「発注一覧表」のDBサーバー負荷軽減 //
//----------------------------------------------------------------------//
// Update Note      :   譚洪 2017/09/14                                 //
//   		        :	ハンディターミナル二次開発の対応                //
//----------------------------------------------------------------------//
// Update Note      :   譚洪 2019/11/05                                 //
//   		        :	㈱ダイサブの対応                                //
//----------------------------------------------------------------------//
//                 Copyright(c)2007 Broadleaf Co.,Ltd.                  //
//**********************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Broadleaf.Library;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("DCHAT02105A")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Partsman")]
[assembly: AssemblyCopyright("(c)2008 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark("Partsman")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDeployment(DeployPosition.Client)]

// ComVisible を false に設定すると、このアセンブリ内の型は COM コンポーネントには 
// 参照不可能になります。COM からこのアセンブリ内の型にアクセスする場合は、 
// その型の ComVisible 属性を true に設定してください。
[assembly: ComVisible(false)]

// 次の GUID は、このプロジェクトが COM に公開される場合の、typelib の ID です
[assembly: Guid("0c37756d-3f10-4fa9-b65f-e1d36db8e7e0")]

// アセンブリのバージョン情報は、以下の 4 つの値で構成されています:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// すべての値を指定するか、下のように '*' を使ってリビジョンおよびビルド番号を 
// 既定値にすることができます:
[assembly: AssemblyVersion("8.10.1.0")]
[assembly: AssemblyFileVersion("8.10.1.0")]

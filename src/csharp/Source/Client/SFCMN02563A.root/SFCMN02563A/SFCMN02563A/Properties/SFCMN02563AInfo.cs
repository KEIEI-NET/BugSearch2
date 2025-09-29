//**********************************************************************//
// System			:	Broadleaf.NS									//
// Sub System		:	SCMオプション									//
// Program name		:	SCM企業拠点連結　アクセスクラス					//
//					:	SFCMN02563A.DLL									//
// Name Space		:	Broadleaf.Application.Controller				//
// Programmer		:	30015　橋本　裕毅								//
// Date				:	2009.06.02										//
//----------------------------------------------------------------------//
// Update Note		:	2009.06.23 22024 寺坂誉志						//
//					:	≪SFCMN02563AB.cs≫								//
//					:	１．汎用ガイドの実装								//
// Update Note		:	2011.05.26 30015 橋本裕毅						//
//					:	≪SFCMN02563AD.cs≫								//
//					:	１．SCM連結元拠点別設定データアクセスクラスを追加	//
// Update Note		:	2011.08.12 x_zhuxk						        //
//					:	≪SFCMN02563AC.cs≫								//
//					:	１．PCCUOE	                                    //
//----------------------------------------------------------------------//
//					Copyright(c)2009 Broadleaf Co.,Ltd.					//
//**********************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Broadleaf.Library;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("SFCMN02563A")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Broadleaf.NS series")]
[assembly: AssemblyCopyright("(c)2009 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark(".NS")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDeployment(DeployPosition.Client)]

// ComVisible を false に設定すると、このアセンブリ内の型は COM コンポーネントには 
// 参照不可能になります。COM からこのアセンブリ内の型にアクセスする場合は、 
// その型の ComVisible 属性を true に設定してください。
[assembly: ComVisible(false)]

// 次の GUID は、このプロジェクトが COM に公開される場合の、typelib の ID です
[assembly: Guid("8cc20f71-40d3-4a9a-89b6-b93127771db7")]

// アセンブリのバージョン情報は、以下の 4 つの値で構成されています:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// すべての値を指定するか、下のように '*' を使ってリビジョンおよびビルド番号を 
// 既定値にすることができます:
[assembly: AssemblyVersion("5.20.1.0")]
[assembly: AssemblyFileVersion("5.20.1.0")]

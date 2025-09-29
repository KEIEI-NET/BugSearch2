//**********************************************************************//
// System			:	Partsman    									//
// Sub System		:													//
// Program name		:	支払検索アクセスクラス							//
//					:	SFSIR02104A.DLL									//
// Name Space		:	Broadleaf.Application.Controller				//
// Programmer		:	寺坂　誉志										//
// Date				:	2006.05.24										//
//----------------------------------------------------------------------//
// Update Note		:	2006.12.22  木村 武正							//
//						携帯.NS用に変更									//
//----------------------------------------------------------------------//
// Update Note		:	2008/07/08  忍 幸史 							//
//						Partsman用に変更								//
//----------------------------------------------------------------------//
// Update Note		:	2009/12/20 譚洪 ＰＭ．ＮＳ保守依頼④			//
//          		:	操作性/入力速度向上のために以下の改良を行う		//
//          		:	仕入先入力後に入金一覧を初期表示しないように変更//
//                      の対応                                  		//
//----------------------------------------------------------------------//
// Update Note		:	2012/12/24 王君 　　　　　　　　　　			//
//          		:	2013/03/13配信分　Redmine#33741の対応          	//
//----------------------------------------------------------------------//
// Update Note		:	2013/03/01 王君 　　　　　　　　　　			//
//          		:	2013/03/13配信分　Redmine#33741の対応          	//
//----------------------------------------------------------------------//
//					Copyright(c)2008 Broadleaf Co.,Ltd.					//
//**********************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Broadleaf.Library;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("SFSIR02104A")]
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
[assembly: Guid("cfb26c50-d96f-4932-9011-8ff8e676be57")]

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


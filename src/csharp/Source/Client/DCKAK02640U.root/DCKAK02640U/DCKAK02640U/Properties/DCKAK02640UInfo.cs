//**********************************************************************//
// System			:	DC.NS											//
// Sub System		:													//
// Program name		:	買掛残高一覧表 UIクラス							//
//					:	DCKAK02640U.DLL									//
// Name Space		:	Broadleaf.Windows.Forms							//
// Programmer		:	22018 鈴木 正臣									//
// Date				:	2007.10.24										//
//----------------------------------------------------------------------//
// Update Note      :   2008.10.01 30413 犬飼                           //
//   		        :	PM.NS対応									    //
//----------------------------------------------------------------------//
// Update Note      :   2013/01/04 田建委                               //
// 管理番号         :   10806793-00 2013/03/13配信分                    //
//   		        :	Redmine#34098 罫線印字制御の追加対応    	    //
//----------------------------------------------------------------------//
// Update Note      :   2013/02/27 王君                                 //
// 管理番号         :   10806793-00 2013/03/13配信分                    //
//   		        :	Redmine#34098 罫線印字制御の追加対応    	    //
//----------------------------------------------------------------------//
// Update Note      :   2013/03/11 cheq                                 //
// 管理番号  		:	10900690-00 2013/03/26配信分                    //
//                      Redmine#34987 フォーカス遷移の対応              //
//----------------------------------------------------------------------//
// Update Note	    :	2012/03/02	劉星光							    //
//                  :   11570208-00 軽減税率対応                        //                  
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
[assembly: AssemblyTitle( "DCKAK02640U" )]
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
[assembly: Guid("c371f6ca-ed6e-4f7d-823f-3f709a6b2608")]

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

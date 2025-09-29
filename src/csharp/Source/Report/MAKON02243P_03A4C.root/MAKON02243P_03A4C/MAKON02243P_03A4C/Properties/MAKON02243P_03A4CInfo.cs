//**********************************************************************//
// System			:	ＰＭ．ＮＳ										//
// Sub System		:													//
// Program name		:	仕入日報月報									//
//					:	MAKON02243P_03A4C.DLL							//
// Name Space		:	Broadleaf.Application.UIData					//
// Programmer		:	96186 立花 裕輔									//
// Date				:	2007.xx.xx										//
//----------------------------------------------------------------------//
// UpdateNote	    :   情報の修正                                      // 
// Programmer	    :   30415 柴田 倫幸                                 //
// Date		        :   2008/07/16                                      //
//----------------------------------------------------------------------//
// Update Note      :   2012/12/26 cheq                                 //
// 管理番号         :	10806793-00 2013/03/13配信分                    //
//                      Redmine#34098 罫線印字制御の追加対応    	    //
//----------------------------------------------------------------------//
// Update Note      :   2013/06/21 wangf                                //
// 管理番号         :	10806793-00 PM1300A（配信日なし分）             //
//                  :   帳票印字する時に、伝票枚数の表示桁数を変更し    //
//                  :   デザインファイルの修正                          //
//----------------------------------------------------------------------//
// Update Note      :   2020/02/27 3H 尹安                              //
// 管理番号         :	11570208-00 軽減税率対応                        //
//----------------------------------------------------------------------//
//                 Copyright(c)2008 Broadleaf Co.,Ltd.                  //
//**********************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Broadleaf.Library;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("MAKON02243P_03A4C")]
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
[assembly: Guid("70d70f83-6ce9-4bff-9442-f80faf0ad06e")]

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

//**********************************************************************//
// System			:	MK.NS											//
// Sub System		:													//
// Program name		:	入金一覧表 UIクラス								//
//					:	MAHNB02010U.DLL									//
// Name Space		:	Broadleaf.Windows.Forms							//
// Programmer		:	22013 kubo										//
// Date				:	2007.03.06										//
//----------------------------------------------------------------------//
// Data		        :	2008.07.09									    //
// Programmer       :   犬飼                                            //
// Update Note      :   PM.NS対応                                       //
//----------------------------------------------------------------------//
// Data		        :	2012/11/14									    //
// Programmer       :   李亜博                                          //
// Update Note      :   2013/01/16配信分、Redmine#33271                 //
//                      印字制御の区分の追加                            //
//----------------------------------------------------------------------//
// Date	            :	2012/12/25									    //
// Programmer       :   董桂鈺                                          //
// Update Note      :   2013/01/16配信分、Redmine#33271                 //
//                      帳票の罫線印字（する・しない）を前回指定したも  //
//                      のを記憶させることの設定を追加する              //
//----------------------------------------------------------------------//
// Update Note      :   2013/01/05 zhuhh                                //
// 管理番号         :   10806793-00　2013/03/13配信分                   //
//                  :   Redmine #33796 改頁制御を追加する         　　  //
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
[assembly: AssemblyTitle("MAHNB02010U")]
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

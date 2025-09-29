//**********************************************************************//
// System			:	Partsman    									//
// Sub System		:													//
// Program name		:													//
//					:	MAZAI05130U.DLL									//
// Name Space		:	Broadleaf.Windows.Forms							//
// Programmer		:													//
// Date				:	2007.xx.xx										//
//----------------------------------------------------------------------//
// Update Note		:	2008/09/01 30414 忍 幸史 Partsman用に変更		//
//----------------------------------------------------------------------//
//----------------------------------------------------------------------//
// Update Note		:	2009/12/03 李占川 PM.NS　保守対応       		//
//----------------------------------------------------------------------//
// Update Note		:	2011/01/11 鄧潘ハン                             //
//                      ①貸出分の印刷がされない不具合の修正。          //
//                      ②商品マスタに存在しないデータも新規登録出来る不//                                        
//                      具合修正。　                                    //
// Update Note		:	2011/01/30 鄧潘ハン    障害報告 #18764          //
//                                                                      //
//----------------------------------------------------------------------//
// Update Note		:	2011/02/10 鄧潘ハン    障害報告 #18869          //
//                                             障害報告 #18870          //
//----------------------------------------------------------------------//
// Update Note		:	2012/10/29 yangyi      障害報告 #32868          //
//                                                                      //
//----------------------------------------------------------------------//
// Update Note		:	2014/10/31 xuyb        仕掛№2133 Redmine#40336 //
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
[assembly: AssemblyTitle("MAZAI05130U")]
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
[assembly: Guid("11a3e2bc-bdcd-41b2-a763-0b7c7cc1dbc8")]

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

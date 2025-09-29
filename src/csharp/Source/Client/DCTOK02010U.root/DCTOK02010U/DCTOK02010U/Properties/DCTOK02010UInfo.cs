//**********************************************************************//
// System			:	DC.NS											//
// Sub System		:													//
// Program name		:	売上日報月報 UIクラス							//
//					:	DCTOK02010U.DLL									//
// Name Space		:	Broadleaf.Windows.Forms							//
// Programmer		:	96186 立花 裕輔									//
// Date				:	2007.09.03										//
//----------------------------------------------------------------------//
// Update Note      :   2008.08.11 30413 犬飼                           //
//   		        :	PM.NS対応									    //
//----------------------------------------------------------------------//
// UpdateNote       :   2012/12/28 zhuhh                                //
// 管理番号         :   10806793-00 2013/03/13配信分                    //
//                  :   redmine #34098 罫線印字制御を追加する           //
//----------------------------------------------------------------------//
// UpdateNote       :   2013/02/27 王君                                 //
// 管理番号         :   10806793-00 2013/03/13配信分                    //
//                  :   redmine #34098 罫線印字制御を追加する           //
//----------------------------------------------------------------------//
// UpdateNote       :  2013/03/08 cheq                                  //
// 管理番号         :  10900690-00 2013/03/26配信分                     //
//                  :  Redmine#34987 帳票redmine#34098の残分の対応      //
//----------------------------------------------------------------------//
// UpdateNote       :  2014/12/04 周洋                                  //
//                  :  Redmine#43991の#33の対応                         //
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
[assembly: AssemblyTitle("DCTOK02010U")]
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

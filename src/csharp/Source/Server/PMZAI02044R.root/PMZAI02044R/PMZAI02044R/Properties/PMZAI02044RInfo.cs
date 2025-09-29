using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Broadleaf.Library;
using Broadleaf.Application.Resources;

//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   発注残クリアDBリモートオブジェクト              //
//                  :   PMZAI02044R.DLL								　　//
// Name Space       :   Broadleaf.Application.Remoting　                //
// Programmer       :   20081      	                                　　//
// Date             :   2008.08.20                                      //
//----------------------------------------------------------------------//
// Update Note      :   2009/12/16 呉元嘯	                         	//
//                  :   商品管理情報マスタの仕入先を参照するように変更  //
//----------------------------------------------------------------------//
// Update Note      :   2010/06/08 高峰	                         	　　//
//                  :   障害・改良対応（７月リリース案件）          　  //
//----------------------------------------------------------------------//
// Update Note      :   2011/04/11 liyp	                         	　　//
//                  :   障害改良対応(2011年04月)                        //
//----------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.       　　　　　//
//**********************************************************************//

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("PMZAI02044R")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Partsman")]
[assembly: AssemblyCopyright("(c)2008 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark("Partsman")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDeployment(DeployPosition.Server, ConstantManagement_SF_PRO.ServerCode_UserAP)]

// ComVisible を false に設定すると、このアセンブリ内の型は COM コンポーネントには 
// 参照不可能になります。COM からこのアセンブリ内の型にアクセスする場合は、 
// その型の ComVisible 属性を true に設定してください。
[assembly: ComVisible(false)]

// 次の GUID は、このプロジェクトが COM に公開される場合の、typelib の ID です
[assembly: Guid("264fae18-6302-4bb0-9406-2b14913f3ded")]

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

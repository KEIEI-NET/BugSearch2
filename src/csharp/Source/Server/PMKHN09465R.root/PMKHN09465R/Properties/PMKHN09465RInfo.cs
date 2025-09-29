//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   掛率設定リモートオブジェクト  　	            //
//                  :   PMKHN09465R.DLL									//
// Name Space       :   Broadleaf.Application.Remoting.Adapter			//
// Programmer       :   張凱	                                        //
// Date             :   2010/08/10                                      //
//----------------------------------------------------------------------//
// Update Note      :   2010/08/27                                      //
//                      品番の曖昧検索                                  //
//----------------------------------------------------------------------//
// Update Note      :   2010/09/01 呉元嘯                               //
//                      明細のソート順が「品番・ﾒｰｶｰ順」にソートする    //
//----------------------------------------------------------------------//
// Update Note      :   2010/09/02 楊明俊                               //
//                      #13972の対応    　　　　　　　　　　　　　　　　//
//----------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;
using Broadleaf.Application.Resources;
using System.Runtime.InteropServices;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("PMKHN09465R")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Partsman")]
[assembly: AssemblyCopyright("(c)2010 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark("Partsman")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDeployment(DeployPosition.Server, ConstantManagement_SF_PRO.ServerCode_UserAP)]	

// ComVisible を false に設定すると、このアセンブリ内の型は COM コンポーネントには 
// 参照不可能になります。COM からこのアセンブリ内の型にアクセスする場合は、 
// その型の ComVisible 属性を true に設定してください。
[assembly: ComVisible(false)]

// 次の GUID は、このプロジェクトが COM に公開される場合の、typelib の ID です
[assembly: Guid("991f4c02-a864-46cf-94e1-d53e9e4fd0f7")]

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

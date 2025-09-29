using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Broadleaf.Library;
using Broadleaf.Application.Resources;

//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   出荷商品順位表DBリモートオブジェクト              //
//                  :   DCHNB02064R.DLL								　　//
// Name Space       :   Broadleaf.Application.Remoting　                //
// Programmer       :   横川昌令      	                                //
// Date             :   2007.11.27                                      //
//----------------------------------------------------------------------//
// Update Note      :	PM.NS対応                   						//
//                  :   23015 森本 大輝                                  //
//                  :   2008.08.25                                      //
// Update Note      :	2012/08/09 wangf                                //
//                  :   10801804-00、9/12配信分、Redmine#31531 売上順位表 品番指定時の抽出不正の対応//
//                  :   品番を「*」で入力した場合、売上順位表抽出可能になります。//
//----------------------------------------------------------------------//
// Update Note      :   2014/12/16 劉超                                 //
// 管理番号         :   11070263-00                                     //
//                  :   明治産業様Seiken品番変更                        //
//----------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.       　　　　　//
//**********************************************************************//

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("DCHNB02064R")]
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
[assembly: Guid("42c80a56-d298-4ba0-b840-f0284a3b4bdd")]

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

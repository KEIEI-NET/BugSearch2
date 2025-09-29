using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Broadleaf.Library;
using Broadleaf.Application.Resources;

//***********************************************************************//
// System           :   DC.NS                                            //
// Sub System       :                                                    //
// Program name     :   売上日報月報DBリモートオブジェクト               //
//                  :   DCTOK02024R.DLL								　　 //
// Name Space       :   Broadleaf.Application.Remoting　                 //
// Programmer       :   横川昌令      	                                 //
// Date             :   2007.11.16                                       //
//-----------------------------------------------------------------------//
// Update Note      :	2010/08/05 楊明俊                         		 //
//                  :   PM1012 得意先マスタのコードで集計して印字する    //
//-----------------------------------------------------------------------//
// Update Note      : Redmine#28712 ReadUnCommitted対応                  //
//                  : zhangyong                                          //
//                  : 2012/02/28                                         //
//-----------------------------------------------------------------------//
// Update Note      :   2012/04/16 許培珠　　                            //
//   		        :	10801804-00　05/24配信分	redmine#29135        //
//                  :   売上・粗利目標、進捗率・達成率の印字について     //
//-----------------------------------------------------------------------//  
// Update Note      :   2012/05/22 李亜博　　                            //
//   		        :	10801804-00  06/27配信分    Redmine#29901        //
//                      売上日報月報 売上目標が不正に印字される場合がある//
//-----------------------------------------------------------------------//
// Update Note      :   2012/05/22 李亜博　　                            //
//   		        :	10801804-00  06/27配信分    Redmine#29898        //
//                      売上日報月報 進捗率算出時に営業日を参照していない//
//                      パターンが存在する                               //
//-----------------------------------------------------------------------//
// Update Note      :   2013/02/06 汪権来　　                            //
//   		        :	10801804-00  03/13配信分    Redmine#34586        //
//                      No.1158　三和部品　売上日報月報（受注者別）　    //
//                                                                       //
//-----------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.       　　　　　 //
//***********************************************************************//

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("DCTOK02024R")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("DistributionCore")]
[assembly: AssemblyCopyright("(c)2007 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark("DistributionCore")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDeployment(DeployPosition.Server, ConstantManagement_SF_PRO.ServerCode_UserAP)]

// ComVisible を false に設定すると、このアセンブリ内の型は COM コンポーネントには 
// 参照不可能になります。COM からこのアセンブリ内の型にアクセスする場合は、 
// その型の ComVisible 属性を true に設定してください。
[assembly: ComVisible(false)]

// 次の GUID は、このプロジェクトが COM に公開される場合の、typelib の ID です
[assembly: Guid("44d2270e-d5a9-4000-b04a-d6acd1344566")]

// アセンブリのバージョン情報は、以下の 4 つの値で構成されています:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// すべての値を指定するか、下のように '*' を使ってリビジョンおよびビルド番号を 
// 既定値にすることができます:
[assembly: AssemblyVersion("1.10.1.0")]
[assembly: AssemblyFileVersion("1.10.1.0")]

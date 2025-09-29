//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   検品データ  DBリモートオブジェクト              //
//                  :   PMHND00211R.DLL								　　//
// Name Space       :   Broadleaf.Application.Remoting　                //
// Programmer       :   3H 張小磊         	                            //
// Date             :   2017/05/22                                      //
//----------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 陳艶丹                              //
// 修 正 日  2017/06/30  修正内容 : 検品データ登録の対応                //
//----------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 陳艶丹                              //
// 修 正 日  2017/07/20  修正内容 : 検品ガイドデータ検索の対応          //
//----------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 3H 張小磊                           //
// 修 正 日  2017/09/07  修正内容 : 検品照会の変更対応                  //
//----------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.       　　　　　//
//**********************************************************************//

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Broadleaf.Library;
using Broadleaf.Application.Resources;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("PMHND00211R")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Partsman")]
[assembly: AssemblyCopyright("(c)2017 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark("Partsman")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDeployment(DeployPosition.Server, ConstantManagement_SF_PRO.ServerCode_UserAP)]

// ComVisible を false に設定すると、このアセンブリ内の型は COM コンポーネントには 
// 参照不可能になります。COM からこのアセンブリ内の型にアクセスする場合は、 
// その型の ComVisible 属性を true に設定してください。
[assembly: ComVisible(false)]

// 次の GUID は、このプロジェクトが COM に公開される場合の、typelib の ID です
[assembly: Guid("61ca5b85-6835-46b0-b817-0c01112ce267")]

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

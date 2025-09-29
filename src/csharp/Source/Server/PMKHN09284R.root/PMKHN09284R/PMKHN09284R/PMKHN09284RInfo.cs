//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   ＢＬコード層別変換処理DBリモートオブジェクト    //
//                  :   PMKHN09284R.DLL								　　//
// Name Space       :   Broadleaf.Application.Remoting　                //
// Programmer       :   張凱     	                                    //
// Date             :   2010/01/12                                      //
//----------------------------------------------------------------------//
// Update Note    　:   2010/01/25 張凱                                 //
//                      掛率変換仕様変更                                //
//----------------------------------------------------------------------//
// Update Note    　:   2010/01/26 譚洪                                 //
//                      商品・日次データのタイムアウト値を設定の仕様変更//
//                    　優良設定変換前のコードを使用の仕様変更          //
//　　　　　　　　　　　商品管理情報ログ出力内容と処理結果リストに追加条//
//                      件の仕様変更                                    //
//----------------------------------------------------------------------//
// Update Note    　:   2010/01/27 張凱                                 //
//                      掛率マスタのパラメータＣの処理の仕様変更        //
//----------------------------------------------------------------------//
// Update Note    　:   2010/02/01 呉元嘯                               //
//                      Redmine#2710の対応                              //
//----------------------------------------------------------------------//
// Update Note    　:   2010/02/02 張凱                                 //
//                      Redmine#2742の対応                              //
//----------------------------------------------------------------------//
// Update Note    　:   2010/02/03 張凱                                 //
//                      Redmine#2783の対応                              //
//----------------------------------------------------------------------//
// Update Note    　:   2010/02/05 張凱                                 //
//                      Redmine#2841の対応                              //
//----------------------------------------------------------------------//
// Update Note    　:   2010/02/08 譚洪                                 //
//                      Redmine#2879の日次データ更新仕様変更対応        //
//----------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.       　　　　　//
//**********************************************************************//

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Broadleaf.Library;
using Broadleaf.Application.Resources;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("PMKHN09284R")]
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

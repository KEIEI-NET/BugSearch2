//******************************************************************************//
// System           :   ＤＣ．ＮＳ　                                            //
// Sub System       :                                                           //
// Program name     :   在庫検索UIクラス                                        //
//                  :   MAZAI04110U.DLL                                         //
// Name Space       :   Broadleaf.Windows.Forms                                 //
// Programmer       :   鈴木 正臣                                               //
// Date             :   2007.09.07                                              //
//------------------------------------------------------------------------------//
// Update Note      :   2008.08.08                                              //
// Programmer       :   30418 徳永                                              //
//------------------------------------------------------------------------------//
// Update Note      :   2009/09/07  汪千来                                      //
//                  :   PM.NS-2-B 保守依頼①                                    //
//                      表示データが存在するが「該当データなし」となる為、修正  //
//                      tEdit_WarehouseCode_Enterのイベントを削除する           //
//                      tEdit_SectionCode ⇒ tEdit_SectionCodeAllowZero         //
//------------------------------------------------------------------------------//
// Update Note      :   2009/12/18  李侠                                   　   //
//                  :   PM.NS-5-C 保守依頼④                                    //
//                      検索条件の拠点ガイドへ全社を追加　　　　　　　　　　　  //
//                      マスタ未登録時の処理を変更　　　　　　　　　            //
//------------------------------------------------------------------------------//
//                Copyright(c)2008 Broadleaf Co.,Ltd.                           //
//******************************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using Broadleaf.Library;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("MAZAI04110U")]
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
[assembly: Guid("0d963e4b-091b-4326-bd45-ede9b96239ae")]

// アセンブリのバージョン情報は、以下の 4 つの値で構成されています:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
[assembly: AssemblyVersion("8.10.1.0")]
[assembly: AssemblyFileVersion("8.10.1.0")]

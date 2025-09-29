//**********************************************************************//
// System           :   Partsman                                        //
// Sub System       :                                                   //
// Program name     :	在庫移動画面             			            //
//                  :   MAZAI04120U.DLL                                 //
// Name Space		:	Broadleaf.Windows.Forms				            //
// Programmer       :   鈴木 正臣　                                     // 
// Date             :   2007.09.05                                      // 
//----------------------------------------------------------------------//
// Update Note      :   2008/07/14 30414 忍 幸史                        //
//                  :   Partsman用に変更                                //
//----------------------------------------------------------------------//
// Update Note      :   2010/11/15 曹文傑                               //
//                  :   障害改良対応「５，６，７」の対応                //
//----------------------------------------------------------------------//
// Update Note      :   2011/04/11 鄧潘ハン                             //
//                  :   ①明細に仕入先を追加する。                      //
//                  :   ②定価取得時の不具合修正。                      //
//----------------------------------------------------------------------//
// Update Note      :   2011/05/10 tianjw                               //
//                  :   redmine #20881                                  //
//----------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 譚洪
// 修 正 日  2011/07/25  修正内容 : 連番No.16 掛率設定に関して、00全社共通 と 拠点の掛率の優先順位の同等化（WAN運用）の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/05/22  修正内容 : 06/27配信分、Redmine#29881 在庫移動入力抽出条件に日付を指定しても反映されないの対応
//----------------------------------------------------------------------//
//                Copyright(c)2008 Broadleaf Co., Ltd.                  //
//**********************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Broadleaf.Library;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("MAZAI04120U")]
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
[assembly: Guid("58daa970-b7a4-4241-88f3-b093c1575abf")]

// アセンブリのバージョン情報は、以下の 4 つの値で構成されています:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
[assembly: AssemblyVersion("8.10.1.0")]
[assembly: AssemblyFileVersion("8.10.1.0")]

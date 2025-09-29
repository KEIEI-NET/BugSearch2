//**********************************************************************//
// System           :   Partsman                                        //
// Sub System       :                                                   //
// Program name     :	在庫移動画面             			            //
//                  :   MAZAI04100U.EXE                                 //
// Name Space		:	Broadleaf.Windows.Forms				            //
// Programmer       :   鈴木 正臣　                                     // 
// Date             :   2007.09.12                                      // 
//----------------------------------------------------------------------//
// Update Note      :   2008/07/14 30414 忍 幸史                        //
//                  :   Partsman用に変更                                //
//----------------------------------------------------------------------//
// Update Note      :   2010/11/15 曹文傑                               //
//                  :   障害改良対応「５，６，７」の対応                //
//----------------------------------------------------------------------//
// Update Note      :   2011/04/11 鄧潘ハン　　　　                     //
//                  :   明細に仕入先を追加する                          //
//----------------------------------------------------------------------//
// Update Note      :   2011/05/10 tianjw    　　　                     //
//                  :   redmine #20901                                  //
//----------------------------------------------------------------------//
// Update Note      :   K2013/09/11 田建委 　　　　                     //
//                  :   フタバ個別対応                                  //
//----------------------------------------------------------------------//
//                Copyright(c)2008 Broadleaf Co., Ltd.                  //
//**********************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;
using System.Runtime.InteropServices;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("在庫移動入力")]
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
[assembly: Guid("0a5777d8-3328-4936-b3af-38dea2852a0d")]

// アセンブリのバージョン情報は、以下の 4 つの値で構成されています:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
[assembly: AssemblyVersion("8.10.1.0")]
[assembly: AssemblyFileVersion("8.10.1.0")]


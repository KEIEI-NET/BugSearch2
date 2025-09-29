using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Broadleaf.Library;
using Broadleaf.Application.Resources;

//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   棚卸表示DBリモートオブジェクト          　　    //
//                  :   PMZAI04205R.DLL								　　//
// Name Space       :   Broadleaf.Application.Remoting　                //
// Programmer       :   23012 畠中 啓次朗                           　　//
// Date             :   2008.10.08                                      //
//----------------------------------------------------------------------//
// Update Note      :	2011/03/22 曹文傑          						//
//                  :   照会プログラムのログ出力対応                    //
//----------------------------------------------------------------------//
// Update Note      :	2012/03/26 wangf          						//
//                  :   redmine#29109の対応                             //
//----------------------------------------------------------------------//
// Update Note      :	2013/10/14 汪権来          						//
//                  :   redmine#40178の対応                             //
//----------------------------------------------------------------------//
// Update Note      :	2014/03/10 汪権来          						//
//                  :   redmine#40178の25対応                           //
//----------------------------------------------------------------------//
// Update Note      :	2014/05/13 田建委          						//
//                  :   redmine#36564 　棚卸表示の速度改善(#1989)       //
//----------------------------------------------------------------------//
// Update Note      :	2015/03/13 caohh          						//
//                  :   redmine#44951 　棚卸表示の不具合(No.3)対応      //
//                  :   原価計算の掛率グループのパラメータの設定を修正  //
//----------------------------------------------------------------------//
// Update Note      :   2020/09/28 陳艶丹                               //
//                  :   PMKOBETSU-4005 ＥＢＥ対策                       //
//----------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.       　　　　　//
//**********************************************************************//

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("PMZAI04205R")]
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

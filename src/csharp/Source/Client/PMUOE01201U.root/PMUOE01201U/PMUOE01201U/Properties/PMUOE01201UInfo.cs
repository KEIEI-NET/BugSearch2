//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   UOE入庫更新 UIクラス                            //
//                  :   PMUOE01201U.DLL                                 //
// Name Space       :   Broadleaf.Windows.Forms                         //
// Programmer       :   照田 貴志                                       //
// Date             :   2008/09/04                                      //
//----------------------------------------------------------------------//
//----------------------------------------------------------------------//
// Update Note      :   2009/11/24 李侠                                 //
//                      PM.NS-4・保守依頼③区分の入力制御を追加         //
//----------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf　　　　　　　　　　　　　　　 //
// 修 正 日  2012/11/15  修正内容 : 1月16日配信分、Redmine#31980 PM.NS障害一覧No.829の対応//
//                                : 在庫入庫更新の原単価は、回答データの原単価とPMの原単価と異なる場合黄色に変わる機能があるが//
//                                : 価格マスタの原価を変えても、色彩は変化しない。//
//----------------------------------------------------------------------//
//                 Copyright(c)2008 Broadleaf Co.,Ltd.                  //
//**********************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Broadleaf.Library;


// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("PMUOE01201U")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("DistributionCore")]
[assembly: AssemblyCopyright("(c)2008 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark("DistributionCore")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDeployment(DeployPosition.Client)]

// アセンブリのバージョン情報は、以下の 4 つの値で構成されています:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
[assembly: AssemblyVersion("1.10.1.0")]
[assembly: AssemblyFileVersion("1.10.1.0")]
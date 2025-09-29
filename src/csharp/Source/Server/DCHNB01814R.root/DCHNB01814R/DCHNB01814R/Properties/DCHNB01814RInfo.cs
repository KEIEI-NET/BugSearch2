using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;
using Broadleaf.Application.Resources;
using System.Runtime.InteropServices;

//**********************************************************************//
// System           :   ＰＭ．ＮＳ                                      //
// Sub System       :                                                   //
// Program name     :   売上サーバ更新リモートオブジェクト 				//
//                  :   DCHNB01814R.DLL									//
// Name Space       :   Broadleaf.Application.Remoting					//
// Programmer       :   21112  久保田　誠	                            //
// Date             :   2008.06.06                                      //
//----------------------------------------------------------------------//
// Update Note      :	2009/09/16       汪千来                         //
//                  :   車輌備考を追加する</br>
//----------------------------------------------------------------------//
// Update Note      :	2009/10/26       張凱                           //
//                  :   赤伝時、車輌情報処理を追加する</br>
//----------------------------------------------------------------------//
// Update Note      :	2010/04/27       gaoyh                          //
//                  :   受注マスタ（車両）自由検索型式固定番号配列の追加対応
//----------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("DCHNB01814R")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Partsman")]
[assembly: AssemblyCopyright("(c)2008 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark("Partsman")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDeployment(DeployPosition.Server, ConstantManagement_SF_PRO.ServerCode_UserAP)]

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

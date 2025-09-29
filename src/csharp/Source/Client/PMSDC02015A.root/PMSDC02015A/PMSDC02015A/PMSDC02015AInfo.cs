//**********************************************************************//
// System           :   PM.NS　                                         //
// Sub System       :                                                   //
// Program name     :   売上連携テキスト出力アクセスクラス              //
//                  :   PMSDC02015A.DLL                                 //
// Name Space       :   Broadleaf.Application.Controller                //
// Programmer       :   田建委                                          // 
// Date             :   2019/12/02                                      // 
//----------------------------------------------------------------------//
// Update Note      :	2019/09/03 3H 尹安                              //
//                  :   11670214-00 売上データ出力文字種拡張対応        //
//                  :   ①連携データの品名全角文字を半角スペースに変換  //
//                  :     する処理をせず、元の品名のまま送信する        // 
//                  :   ②連携データの商品名称カナが未設定の場合、      //
//                  :     商品名称を設定する                            //
//----------------------------------------------------------------------//
//                Copyright(c)2019 Broadleaf Co.,Ltd.                   //
//**********************************************************************//

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Broadleaf.Library;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("PMSDC02015A")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Partsman")]
[assembly: AssemblyCopyright("(c)2019 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark("Partsman")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDeployment(DeployPosition.Client)]

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
[assembly: AssemblyVersion("8.10.1.0")]
[assembly: AssemblyFileVersion("8.10.1.0")]


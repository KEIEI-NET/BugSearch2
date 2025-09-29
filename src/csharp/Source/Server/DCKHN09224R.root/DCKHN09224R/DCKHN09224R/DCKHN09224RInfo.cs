using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;
using Broadleaf.Application.Resources;

//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   売上全体設定マスタリモートオブジェクト          //
//                  :   DCKHN09264R.DLL                                 //
// Name Space       :   Broadleaf.Application.Remoting                  //
// Programmer       :   22008 長内 数馬                                 //
// Date             :   2008.06.03                                      //
//----------------------------------------------------------------------//
// Update Note		:	2009/10/19 朱俊成                               //
//                      PM.NS-3-A・保守依頼②表示区分プロセスを追加     //
//----------------------------------------------------------------------//
// Update Note		:	2010/01/29 李侠　                               //
//                      PM1003・四次改良受注数入力を追加                //
//----------------------------------------------------------------------//																								
// Update Note		:	2010/04/30 姜凱　                               //					
//                      PM1007D・自由検索自由検索部品自動登録区分を追加 //								
//----------------------------------------------------------------------//
// Update Note		:	2010/05/04 王海立                               //
//                      PM1007・6次改良発行者チェック区分、             //
//                      入力倉庫チェック区分を追加                      //
//----------------------------------------------------------------------//
// Update Note		:	2010/08/04 楊明俊                               //
//                      PM1012・小数点表示区分を追加                    //
//----------------------------------------------------------------------//
// Update Note		:	2011/06/06 長内数馬                             //
//                      販売区分表示区分を追加                          //
//----------------------------------------------------------------------//
// Update Note		:	2012/04/13 福田康夫                             //
//                      貸出仕入区分を追加                              //
//----------------------------------------------------------------------//
// Update Note		:	11370030-00　2017/04/13 譚洪                    //
//                      仕入担当参照区分を追加                          //
//----------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

//
// アセンブリに関する一般情報は以下の 
// 属性セットを通して制御されます。アセンブリに関連付けられている 
// 情報を変更するには、これらの属性値を変更してください。
//
[assembly: AssemblyTitle("DCKHN09224R.DLL")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Partsman")]
[assembly: AssemblyCopyright("(c)2008 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark("Partsman")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDeployment(DeployPosition.Server, ConstantManagement_SF_PRO.ServerCode_UserAP)]        

//
// アセンブリのバージョン情報は、以下の 4 つの属性で構成されます :
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// 下にあるように、'*' を使って、すべての値を指定するか、
// ビルドおよびリビジョン番号を既定値にすることができます。

[assembly: AssemblyVersion("8.10.1.0")]
[assembly: AssemblyFileVersion("8.10.1.0")]

//
// アセンブリに署名するには、使用するキーを指定しなければなりません。 
// アセンブリ署名に関する詳細については、Microsoft .NET Framework ドキュメントを参照してください。
//
// 下記の属性を使って、署名に使うキーを制御します。 
//
// メモ : 
//   (*) キーが指定されないと、アセンブリは署名されません。
//   (*) KeyName は、コンピュータにインストールされている
//        暗号サービス プロバイダ (CSP) のキーを表します。KeyFile は、
//       キーを含むファイルです。
//   (*) KeyFile および KeyName の値が共に指定されている場合は、 
//       以下の処理が行われます :
//       (1) KeyName が CSP に見つかった場合、そのキーが使われます。
//       (2) KeyName が存在せず、KeyFile が存在する場合、 
//           KeyFile にあるキーが CSP にインストールされ、使われます。
//   (*) KeyFile を作成するには、sn.exe (厳密な名前) ユーティリティを使ってください。
//       KeyFile を指定するとき、KeyFile の場所は、
//       プロジェクト出力 ディレクトリへの相対パスでなければなりません。
//       パスは、%Project Directory%\obj\<configuration> です。たとえば、KeyFile がプロジェクト ディレクトリにある場合、
//       AssemblyKeyFile 属性を 
//       [assembly: AssemblyKeyFile("..\\..\\mykey.snk")] として指定します。
//   (*) 遅延署名は高度なオプションです。
//       詳細については Microsoft .NET Framework ドキュメントを参照してください。
//
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile("")]
[assembly: AssemblyKeyName("")]

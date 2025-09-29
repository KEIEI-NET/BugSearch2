//**********************************************************************//
// System			:	PM.NS        									//
// Sub System       :                                                   //
// Program name     :   UOE発注先マスタ アクセスクラス                  //
//                  :   PMUOE09022A.DLL                                 //
// Name Space       :   BloadLeaf.Application.Controller                //
// Programmer		:	30413 犬飼         							    //
// Date				:	2008.06.26										//
//----------------------------------------------------------------------//
// Update Note      :  2009/12/29 xuxh                                  // 
//                  :   【要件No.1】                                    //
//                     トヨタ電子カタログで使用する送信・受信データ     //
//                     の保存場所を設定する                             //
//----------------------------------------------------------------------//
// Update Note      :  2010/03/08 楊明俊                                // 
//                  :  PM1006                                           //
//                     UOE発注データを登録する機能で入力制御の対応      //
//----------------------------------------------------------------------//
// Update Note      :  2010/04/23 jiangk                                // 
//                  :  PM1007C                                          //
//                     UOE発注データを登録する機能で入力制御の対応      //
//----------------------------------------------------------------------//
// Update Note      :  2010/05/07 高峰                                  // 
//                  :  PM1008                                           //
//                     明治UOE-WEB対応に伴う仕様追加                    //
//----------------------------------------------------------------------//
// Update Note      :  2010/12/31 譚洪                                  // 
//                     UOE自動化改良                                    //
//----------------------------------------------------------------------//
// Update Note     : 2011/01/28 施ヘイ中
//                      :  PM1102A         
//                      回答自動取込区分（トヨタWEBUOE用自動連携用の設定区分）の変更
//----------------------------------------------------------------------------//
// Update Note      :  2011/03/01 liyp                                  //
//            回答自動取込区分（日産WEBUOE用自動連携用の設定区分）の変更//
//----------------------------------------------------------------------//
// Update Note     : 2011/05/10 施ヘイ中
//                      :  PM1105A         
//                      マッダ制御用情報への項目追加
//----------------------------------------------------------------------------//
// Update Note     : 2011/12/15 yangmj
//                   Redmine#27386トヨタUOEWebタクティー品番の発注対応
//----------------------------------------------------------------------//
// Update Note      :   2013/04/15 donggy                                                      //
// 管理番号         :   10900691-00 2013/05/15配信分                                      //
//----------------------------------------------------------------------// 
//                 Copyright(c)2008 Broadleaf Co.,Ltd.                  //
//**********************************************************************//

using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("PMUOE09022A")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Partsman")]
[assembly: AssemblyCopyright("(c)2008 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark("Partsman")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDeployment(DeployPosition.Client)]

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

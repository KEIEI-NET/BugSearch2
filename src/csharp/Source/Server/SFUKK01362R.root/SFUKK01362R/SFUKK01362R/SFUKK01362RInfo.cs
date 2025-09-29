//**********************************************************************//
// System           :   PM.NS
// Sub System       :
// Program name     :   入金更新処理リモーティング
//                  :   SFUKK01362R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programer        :   徳永　誠
// Date             :   2005.08.11
//----------------------------------------------------------------------//
// Update Note      :
// 2006.02.20 toku  : 諸費用別入金対応
// 2006.10.18 toku	: トランザクション分離レベルを変更
// ---------------------------------------------------------------------
// 2007.01.23       : 18322 T.Kimura MA.NS用に変更
// 2007.03.27 木村  : 得意先請求(売掛)金額マスタの更新は準備処理で
//                    行うように変更された為、更新処理を削除
//----------------------------------------------------------------------//
// 2007.10.11       :  980081 A.Yamada DC.NS用に変更
// 2007.12.10       :  EdiTakeInDate(EDI取込日)をInt32→DateTimeに変更
// 2008.01.11       :  論理削除機能を追加(LogicalDelete)
//----------------------------------------------------------------------//
// 2008.04.25       :  21112  PM.NS用に変更
//----------------------------------------------------------------------//
// Update Note		:  2010/12/20 李占川 PM.NS障害改良対応(12月分)	    //
//----------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/10/17  修正内容 : Redmine#32870、2012/11/14配信分 PM.NS障害一覧No.1516 入金伝票入力/売掛残高が異なるの対応。
//                                : 入金伝票保存する関連の得意先（変動情報）の現在売掛残高の値の対応。
//----------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/10/29  修正内容 : Redmine#32870、2012/11/14配信分 PM.NS障害一覧No.1516 入金伝票入力/売掛残高が異なるの再対応。
//                                : 入金伝票保存する関連の得意先（変動情報）の現在売掛残高の値の再対応。
//----------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/11/06  修正内容 : Redmine#32870、2012/11/14配信分 PM.NS障害一覧No.1516 入金伝票入力/売掛残高が異なるの再対応。
//                                : 入金伝票保存する関連の得意先（変動情報）の現在売掛残高の値の再対応。
//                                : 入金合計はマイナス値を設定すれば、現在売掛残高の更新の対応。
//----------------------------------------------------------------------//
// Update Note      :   2013/01/10 zhuhh                                //
// 管理番号         :   10806793-00　2013/03/13配信分                   //
//                  :   Redmine #34123 手形データ重複した伝票番号の登録 //
//                                                      を出来る様にする//
//--------------------------------------------------------------------  //
//                (c)Copyright  2008 Broadleaf Co,. Ltd
//**********************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;

using Broadleaf.Library;
using Broadleaf.Application.Resources;

//
// アセンブリに関する一般情報は以下の 
// 属性セットを通して制御されます。アセンブリに関連付けられている 
// 情報を変更するには、これらの属性値を変更してください。
//
[assembly: AssemblyTitle("SFUKK01362R")]
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

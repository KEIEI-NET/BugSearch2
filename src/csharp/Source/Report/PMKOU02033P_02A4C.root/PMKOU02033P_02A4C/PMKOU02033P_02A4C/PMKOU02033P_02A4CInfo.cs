//**********************************************************************//
// System           :   DC.NS                                           //
// Sub System       :                                                   //
// Program name     :   仕入先元帳フォーム印刷クラス                    //
//                  :   PMKOU02033P_02A4C.DLL                           //
// Name Space       :   Broadleaf.Drawing.Printing                      //
// Programmer       :   20081 疋田 勇人                                 //
// Date             :   2007.11.26                                      //
//----------------------------------------------------------------------//
// Update Note		:	2014/09/16 時シン				     			//
//           		:	㈱陸整自動車用品 伝票番号印字区分の追加  	    //
//----------------------------------------------------------------------//
// UpdateNote       :   2015/10/21 田思春                               //
// 管理番号         :   11170187-00                                     //
//                  :   Redmine#47545 仕入先元帳の明細部に仕入先子の明細が印字されないの障害対応 //
//----------------------------------------------------------------------//
// UpdateNote       :   2015/12/10 田思春                               //
// 管理番号         :   11170204-00                                     //
//                  :   Redmine#47545 障害２ 仕入総括オプション有効時、明細部の仕入金額が実際値の２倍で印字されるの障害対応 //
//                                    障害３ 複数ページに跨る条件を指定した場合、締日による改ページ不正の障害対応 //
//----------------------------------------------------------------------//
// UpdateNote       :   2016/01/05 陳艶丹                               //
// 管理番号         :   11170204-00                                     //
//                  :   Redmine#47545 ソースレビュー指摘NO3の対応       //
//----------------------------------------------------------------------//

//                Copyright(c)2007 Broadleaf Co.,Ltd.                   //
//**********************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;

//
// アセンブリに関する一般情報は以下の 
// 属性セットを通して制御されます。アセンブリに関連付けられている 
// 情報を変更するには、これらの属性値を変更してください。
//
[assembly: AssemblyTitle("PMKOU02033P_02A4C")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("DistributionCore")]
[assembly: AssemblyCopyright("(c)2007 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark("DistributionCore")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDeployment(DeployPosition.Client)]		

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

[assembly: AssemblyVersion("1.10.1.0")]
[assembly: AssemblyFileVersion("1.10.1.0")]

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

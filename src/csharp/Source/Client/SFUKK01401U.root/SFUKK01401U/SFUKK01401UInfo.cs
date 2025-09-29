//**********************************************************************//
// System			:	Partsman    									//
// Sub System       :													//
// Program name     :	入金伝票入力メインフレーム							//
//					:	SFUKK01401U.DLL									//
// Name Space		:	Broadleaf.Windows.Forms							//
// Programmer		:	amami											//
// Date				:	2005.08.20										//
//----------------------------------------------------------------------//
// Update Note		:	2007.02.02 18322 T.Kimura MA.NS対応				//
// Update Note		:	2007.10.05 20081 疋田 勇人 DC.NS対応			//
// Update Note		:	2008.06.26 30414 忍 幸史 Partsman対応			//
//----------------------------------------------------------------------//
// Update Note		:	2012/12/24 王君　　　　             			//
//                  :   2013/03/13配信分　Redmine#33741の対応　　　　　 //
//----------------------------------------------------------------------//
// Update Note		:	2013/02/05 田建委　　　　             			//
// 管理番号         : 　10801804-00 2013/03/13配信分　Redmine#33735　　 //
//----------------------------------------------------------------------//
// Update Note		:	2014/07/08 zhujw　　　　             			//
// 管理番号         : 　11001635-00 Redmine#42902の⑧ 既存障害の修正 　 //
//----------------------------------------------------------------------//
// Update Note		:	2015/08/18 李侠　　　　             			//
// 管理番号         : 　11170129-00 Redmine#47016　　　　　　           //
//                      画面タイプリストを変更する場合、例外エラーの対応//
//----------------------------------------------------------------------//
//				  Copyright(c)2008 Broadleaf Co.,Ltd.					//
//**********************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;

//
// アセンブリに関する一般情報は以下の 
// 属性セットを通して制御されます。アセンブリに関連付けられている 
// 情報を変更するには、これらの属性値を変更してください。
//
[assembly: AssemblyTitle("SFUKK01401U")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Partsman")]
[assembly: AssemblyCopyright("(c)2008 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark("Partsman")]
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

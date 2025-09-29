//**********************************************************************//
// System           :   MA.NS                                           //
// Sub System       :                                                   //
// Program name     :	商品セット入力フォーム     			            //
//                  :   MAKHN09620U.DLL                                 //
// Name Space		:	Broadleaf.Windows.Forms         				//
// Programmer       :   木建　翼                                        // 
// Date             :   2007.05.07                                      // 
//----------------------------------------------------------------------//
// Update Note      :   2008.08.01 30413 犬飼                           //
//   		        :	PM.NS対応									    //
//----------------------------------------------------------------------//
// Update Note      :   2010/06/08 譚洪                                 //
//   		        :	障害・改良対応7月リリース分 				    //
//----------------------------------------------------------------------//
// Update Note      :   2012/10/10 wangf                                //
//   		        :	10801804-00、Redmine#32620 №1559、セットマスタでエラーが発生する件の調査//
//   		        :	検索結果の子商品情報データリストの中に品名が長すぎデータがあると、エラーが発生することの対応//
//   		        :	GoodsSetGoodsDataSet.xsd改修のみ、本体ソース改修無し//
//----------------------------------------------------------------------//
// Update Note      :   2015/05/08 gaocheng                                //
//   		        :	ウィンドウを広げた際にセットマスタの画面も同様に広がらずの修正//
//   		        :	ツールバーでショートカットキーの修正//
//----------------------------------------------------------------------//
// Update Note      :   2015/07/02 gaocheng                                //
//   		        :	ウィンドウ位置とサイズの記憶功能の対応//
//----------------------------------------------------------------------//
// Update Note      :   2015/10/28 時シン                               //
//   		        :	セット子品番入力時に "." を入力できないことの対応//
//----------------------------------------------------------------------//
// Update Note      :   K2019/01/07 譚洪                                //
//   		        :	ランテル様にてセットマスタの最大登録件数を99件に増やすの対応//
//----------------------------------------------------------------------//
//                Copyright(c)2007 Broadleaf Co., Ltd.                  //
//**********************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;

//
// アセンブリに関する一般情報は以下の 
// 属性セットを通して制御されます。アセンブリに関連付けられている 
// 情報を変更するには、これらの属性値を変更してください。
//
[assembly: AssemblyTitle("MAKHN09620U")]
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

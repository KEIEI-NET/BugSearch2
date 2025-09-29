//*************************************************************************************//
// System			:	PM.NS									                       //
// Sub System       :				     								               //
// Program name     :	キャンペーン管理マスタ      			　　　　　             //
//					:	PMKHN09625R.DLL									               //
// Name Space		:	Broadleaf.Application.Remoting.ParamData		               //
// Programmer		:	曹文傑										                   //
// Date				:	2011/04/26	                                                   //
//-------------------------------------------------------------------------------------//
// UpdateNote       :   2011/07/07 譚洪                                                //
//                      Redmine#22810 登録していない商品設定についてのみ、             //
//                      重複して登録することが可能の対応                               //
//-------------------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 曹文傑
// 修 正 日  2011/07/14  修正内容 : Redmine#22962 拠点違いで登録可能にするように変更対応
//-------------------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 譚洪                                               //
// 修 正 日  2011/07/14  修正内容 : Redmine#22984 売価区分を異なる設定にすると、       //
//                       同一商品設定を重複して登録することが可能になっていますの対応  //
//-------------------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 曹文傑
// 修 正 日  2011/07/15  修正内容 : Redmine#22993 価格の範囲が重複していますが登録出来てしまいます
//----------------------------------------------------------------------------         //
// 管理番号  10700008-00 作成担当 : 曹文傑
// 修 正 日  2011/07/15  修正内容 : Redmine#22984 売価区分を異なる設定にすると、同一商品設定を重複チェック
//----------------------------------------------------------------------------         //
// 管理番号              作成担当 : 譚洪
// 修 正 日  2011/08/15  修正内容 : ユーザー先では発生しないが複数の企業が混載する営業デモ機などで発生するの対応
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.                                //
//*************************************************************************************//

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Broadleaf.Library;
using Broadleaf.Application.Resources;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("PMKHN09625R")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Partsman")]
[assembly: AssemblyCopyright("Copyright (C)  2011")]
[assembly: AssemblyTrademark("(c)2011 Broadleaf Co.,Ltd.")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDeployment(DeployPosition.Common, ConstantManagement_SF_PRO.ServerCode_UserAP)]

// アセンブリのバージョン情報は、以下の 4 つの値で構成されています:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
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
//*************************************************************************************//
// System			:	Partsman									                   //
// Sub System       :				     								               //
// Program name     :	キャンペーン対象商品設定マスタアクセス　　　                   //
//					:	PMKHN09623A.DLL									               //
// Name Space		:	Broadleaf.Windows.Forms							               //
// Programmer		:	曹文傑										                   //
// Date				:	2011/04/26	                                                   //
//-------------------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 譚洪                                               //
// 修 正 日  2011/07/06  修正内容 : Redmine#22810 明細”メーカー名称”から”カナ名称” //
//                                  に変更の対応                                       //
//----------------------------------------------------------------------------         //
// 管理番号  10700008-00 作成担当 : 曹文傑
// 修 正 日  2011/07/14  修正内容 : Redmine#22984 最終行の情報がデータ登録されない
//----------------------------------------------------------------------------         //
// 管理番号  10700008-00 作成担当 : 曹文傑
// 修 正 日  2011/07/14  修正内容 : Redmine#23004 キャンペーン対象商品設定マスタの日付範囲チェックエラー対応
//----------------------------------------------------------------------------         //
// 管理番号  10700008-00 作成担当 : 譚洪
// 修 正 日  2011/07/22  修正内容 : Redmine#23119 ①優良設定マスタを設定後に最新情報取得を実行しても、再取得されない事が問題ありますの対応
//                                                ②検索時の表示時間が他のＰＧと比較して遅いの対応
//----------------------------------------------------------------------------         //
//                (c)Copyright  2011 Broadleaf Co.,Ltd.                                //
//*************************************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("PMKHN09623A")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Partsman")]
[assembly: AssemblyCopyright("(c)2011 Broadleaf Co.,Ltd.")]
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

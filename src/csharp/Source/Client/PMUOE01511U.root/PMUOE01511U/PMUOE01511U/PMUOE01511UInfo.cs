//*************************************************************************************//
// System			:	Partsman									                   //
// Sub System       :				     								               //
// Program name     :	トヨタ発注処理					　　　　　　               　　//
//					:	PMUOE01511U.DLL									               //
// Name Space		:	Broadleaf.Windows.Forms							               //
// Programmer		:	譚洪										                   //
// Date				:	2009/12/31	                                                   //
//-------------------------------------------------------------------------------------//
// Update Note      :  2010/01/19 譚洪                                                 // 
//                  :  Redmine:2505、2550                                              //
//                     Redmine指摘の対応                                               //
//                     BO区分の入力必須チェックの追加                                  //
//-------------------------------------------------------------------------------------//
// Update Note      :  2010/01/25 譚洪                                                 // 
//                  :  Redmine:2602                                                    //
//                     Redmine指摘の対応                                               //
//                     指定拠点の入力チェック指摘事項の対応                            // 
//-------------------------------------------------------------------------------------//
// Update Note      :  2010/07/26 呉元嘯                                               //
//                  :  PM1011 トヨタ発注処理　自動場合仕様追加                         //
//-------------------------------------------------------------------------------------//
// Update Note      :  2010/08/26 呉元嘯                                               //
//                  :  Redmine#13666対応                                               //
//-------------------------------------------------------------------------------------//
// Update Note      :  2011/01/30 曹文傑                                               //
//                  :  UOE自動化対応、自動化のタイプ追加による変更                     //
//-------------------------------------------------------------------------------------//
// Update Note      :  2011/12/15 yangmj                                               //
//                  :  トヨタUOEWebタクティー品番の発注対応                            //
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.                                //
//*************************************************************************************//

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Broadleaf.Library;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("PMUOE01511U")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Partsman")]
[assembly: AssemblyCopyright("(c)2009 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark("Partsman")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDeployment(DeployPosition.Client)]

// 次の GUID は、このプロジェクトが COM に公開される場合の、typelib の ID です
//[assembly: Guid("10909ba0-505f-4d9f-be69-2704eccfa181")]

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

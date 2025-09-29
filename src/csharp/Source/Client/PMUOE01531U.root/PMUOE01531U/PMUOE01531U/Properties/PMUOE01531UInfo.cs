//*************************************************************************************//
// System			:	Partsman									                   //
// Sub System       :				     								               //
// Program name     :	三菱発注処理					　　　　　　               　　//
//					:	PMUOE01531U.DLL									               //
// Name Space		:	Broadleaf.Windows.Forms							               //
// Programmer		:	gaoyh										                   //
// Date				:	2010/04/20	                                                   //
//-------------------------------------------------------------------------------------//
// Update Note      :   2010/05/07 gaoyh
//                  :   #7086 発注可能数のチェック
// Update Note      :   2010/05/16 gaoyh
//                  :   #7591 三菱発注処理 ファイルの存在チェック追加
// Update Note      :   2010/05/18 gaoyh
//                  :   #7591 三菱発注処理 ファイルの存在チェック追加
//-------------------------------------------------------------------------------------//
// Update Note          2010/12/31 曹文傑 UOE自動化改良　　                            //
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.                                //
//*************************************************************************************//

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Broadleaf.Library;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("PMUOE01531U")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Partsman")]
[assembly: AssemblyCopyright("(c)2010 Broadleaf Co.,Ltd.")]
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

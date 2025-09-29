//**********************************************************************//
// System			:	MA.NS									        //
// Sub System		:													//
// Program name		:	棚卸関連一覧表印刷クラス  			            //
//					:	MAZAI02112P.DLL									//
// Name Space		:	Broadleaf.Drawing.Printing  					//
// Programmer		:	23010 中村　仁  								//
// Date				:	2007.04.09										//
//----------------------------------------------------------------------//
// Update Note      :   2008.10.08 30413 犬飼                           //
//   		        :	PM.NS対応									    //
//----------------------------------------------------------------------//
// Update Note      :   2011/01/11 liyp
// 抽出条件追加に伴い帳票のヘッダへ抽出条件を追加で印字するように変更する
//----------------------------------------------------------------------//
// Update Note      :   2011/01/11 田建委　　                           //
//   		        :	棚卸障害対応　　　　							//
//----------------------------------------------------------------------//
// Update Note      :   2011/02/10 liyp
//                  :   障害報告 #18873 と 障害報告 #18874
//----------------------------------------------------------------------//
// Update Note      :   2012/12/27 田建委
//                  :   2013/01/16配信分　Redmine#33233
//----------------------------------------------------------------------//
//				(c)Copyright  2007 Broadleaf Co.,Ltd.					//
//**********************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;
using System.Runtime.InteropServices;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("MAZAI02112P")]
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


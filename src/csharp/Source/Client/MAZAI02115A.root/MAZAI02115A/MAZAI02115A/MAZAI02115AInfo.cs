//**********************************************************************//
// System			:	MA.NS       					    			//
// Sub System       :													//
// Program name     :	棚卸関連一覧表アクセスクラス     		        //
//					:	MAZAI02115A.DLL					        		//
// Name Space		:	Broadleaf.Application.Controller   				//
// Programmer		:	23010 中村　仁　								//
// Date				:	2007.04.09										//
//----------------------------------------------------------------------//
// Update Note      :   2008.10.08 30413 犬飼                           //
//   		        :	PM.NS対応									    //
//----------------------------------------------------------------------//
// Update Note      :   2009.12.04 呉元嘯                               //
//   		        :	PM.NS保守依頼③対応							    //
//----------------------------------------------------------------------//
// Update Note      :   2009.12.07 張凱                                 //
//   		        :	PM.NS保守依頼③対応							    //
//----------------------------------------------------------------------//
// Update Note      :   2010/02/20 呉元嘯                               //
//   		        :	不具合対応(PM1005)							    //
//----------------------------------------------------------------------//
// Update Note      :   2010/03/02 呉元嘯                               //
//   		        :	不具合対応(PM1005)							    //
//----------------------------------------------------------------------//
// Update Note      :   2011/01/11 liyp                                 //
//   		        :	不具合対応(PM1101B)							    //
//----------------------------------------------------------------------//
// Update Note      :   2011/02/10 田建委                               //
//   		        :	redmine#18865 棚卸障害対応   				    //
//----------------------------------------------------------------------//
// Update Note      :   2011/02/10 liyp                                 //
//   		        :	redmine#18871 棚卸障害対応   				    //
//----------------------------------------------------------------------//
// Update Note      :   2011/02/17 田建委                               //
//   		        :	redmine#19025 抽出時間について 				    //
//----------------------------------------------------------------------//
// Update Note      :   2011/11/28 陳建明                               //
//   		        :	Redmine #8073 棚卸障害対応   				    //
//----------------------------------------------------------------------//
// Update Note      :   2012/07/20 李小路                               //
//   		        :	redmine#31158 「棚卸差異表」のサーバー負荷軽減  //
//                                                    と速度アップの調査//
//----------------------------------------------------------------------//
// Update Note	    :	K2014/03/10	licb							    //
//                  :   信越自動車商会個別開発                 　　　　 //
//                      テキスト出力機能を追加する 　　　　　　　　　　 //
//----------------------------------------------------------------------//
//				  (c)Copyright  2007 Broadleaf Co.,Ltd.                	//
//**********************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;
using System.Runtime.InteropServices;

//
// アセンブリに関する一般情報は以下の 
// 属性セットを通して制御されます。アセンブリに関連付けられている 
// 情報を変更するには、これらの属性値を変更してください。
//
[assembly: AssemblyTitle("MAZAI02115A")]
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

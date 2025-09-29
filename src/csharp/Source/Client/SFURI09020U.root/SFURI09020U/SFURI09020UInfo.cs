//**********************************************************************//
// System			:	ＳＦ．ＮＥＴ									//
// Sub System       :				     								//
// Program name     :	伝票印刷設定画面								//
//					:	SFURI09020U.DLL									//
// Name Space		:	Broadleaf.Windows.Forms							//
// Programmer		:	高橋 明子										//
// Date				:	2005.08.31										//
//----------------------------------------------------------------------//
// Update Note		:	2006.01.24  22024 寺坂 誉志						//
//					:		・ファイルレイアウト変更に伴う項目追加		//
//					:	2006.01.25  22024 寺坂 誉志						//
//					:		・伝票コメントを表示に変更					//
//					:		・出力確認メッセージを表示に変更			//
//					:		・伝票印刷帳票IDを非表示に変更				//
//					:	2006.05.09  22024 寺坂 誉志						//
//					:		・項目名称変更：フォント名称⇒フォント		//
//                  :   2008.06.05 30413 犬飼                           //
//                  :         ・PM.NS用にバージョン情報を変更           //
//                  :   2009.12.31 張凱                                 //
//                  :         ・PM.NS保守依頼④対応                     //
//                  :   2010.08.06 caowj                                //
//                  :         ・PM.NS1012対応                           //
//                  :   2011/02/16 鄧潘ハン                             //
//                  :         ・自社名称１，２が縦倍角になっていない不  //
//                             具合の対応                               //
// Update Date      :   2011/07/19 chenyd                               //
//                  :         ・回答区分追加の対応  　　　　　　　　　　//
// Update Note      :  2011/08/08  豆昌紅　　　　　　　　　　　　　　 　//
//                            ・障害報告 #23459対応   　　　　　　　　　//
// Update Date      :   2011/08/11 zhubj                                //
//                  :         ・「通常マーク」「手動回答」「自動回答マーク」エデット幅調整対応//
//                  :         ・「閉じる」ボタンで終了した、保存確認ダイアログが表示対応//
//----------------------------------------------------------------------//
//				  (c)Copyright  2007 Broadleaf Co.,Ltd.		            //
//**********************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;

//
// アセンブリに関する一般情報は以下の 
// 属性セットを通して制御されます。アセンブリに関連付けられている 
// 情報を変更するには、これらの属性値を変更してください。
//
[assembly: AssemblyTitle("SFURI09020U")]
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

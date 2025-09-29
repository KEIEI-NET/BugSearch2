//*************************************************************************************//
// System			:	Partsman		 							                   //
// Sub System       :							　　　　　　			               //
// Program name     :	全体初期値設定アクセスクラス　　　　　　　　　　　　　　　　   //
//					:	SFCMN09082A.DLL									               //
// Name Space		:	Broadleaf.Windows.Controller						           //
// Programmer		:	高橋　明子										               //
// Date				:	2005.10.03										               //
//-------------------------------------------------------------------------------------//
// Update Note      : 2006.12.07  木村 武正                                            //
//                      1. 携帯システム用に以下の不用項目を削除                        //
//                           ・管区コード                                              //
//                           ・初期表示住所コード１～３                                //
//                           ・初期表示住所                                            //
//                           ・自賠責算定区分                                          //
//                           ・車両確定選択方式                                        //
//                           ・陸運事務所番号                                          //
//-------------------------------------------------------------------------------------//
// 管理番号         作成担当：忍　幸史                                                 //
// 修正日           「顧客コード自動発番」「得意先削除チェック」「会員情報管理」削除   //
//-------------------------------------------------------------------------------------//
// Update Note      : 2013/05/02  王君                                                 //
// 管理番号         : 10901273-00 2013/06/18配信分                                     //
//                  : Redmine#35434 商品在庫マスタ起動区分の追加　　　                 //
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.                                //
//*************************************************************************************//

using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;

//
// アセンブリに関する一般情報は以下の 
// 属性セットを通して制御されます。アセンブリに関連付けられている 
// 情報を変更するには、これらの属性値を変更してください。
//
[assembly: AssemblyTitle("SFCMN09082A")]
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


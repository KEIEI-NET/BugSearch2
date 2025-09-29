using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;
using Broadleaf.Application.Resources;

//**********************************************************************//
// System           :   ＤＣ．ＮＥＴ                                    //
// Sub System       :                                                   //
// Program name     :   全体初期値リモートオブジェクト			        //
//                  :   SFCMN09084R.DLL									//
// Name Space       :   Broadleaf.Application.Remoting					//
// Programmer       :   21052　山田　圭	                                //
// Date             :   2005.10.03                                      //
//----------------------------------------------------------------------//
// Update Note      : 2006.12.07  木村 武正                             //
//                      1. 携帯システム用に以下の不用項目を削除         //
//                           ・管区コード                               //
//                           ・初期表示住所コード１～３                 //
//                           ・初期表示住所                             //
//                           ・自賠責算定区分                           //
//                           ・車両確定選択方式                         //
//                           ・陸運事務所番号                           //
//----------------------------------------------------------------------//
// Update Note      : 2007.08.16  山田 明友                             //
//                      1. 流通基幹システム対応                         //
//----------------------------------------------------------------------//
// Update Note      : 2007.12.17  山田 明友                             //
//                      1. 項目追加対応(9項目)                          //
//----------------------------------------------------------------------//
// Update Note      : 2008.01.10  山田 明友                             //
//                      1. 「部署管理区分」の削除                       //
//                         (自社情報設定に持つように変更)               //
//----------------------------------------------------------------------//
// Update Note      :	ＰＭ.ＮＳ用に変更       						//
// Update Date      :   2008.05.27                                      //
//                  :   20081 疋田 勇人　                               //
//----------------------------------------------------------------------//
//Update Note       : 王君　　　　　　　　　　　　　　　　　　　　　　　//
//Date              : 2013/05/02                                        //
//管理番号          : 10901273-00 2013/06/18配信分                      //
//　                : Redmine#35434の対応                               //
//----------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

//
// アセンブリに関する一般情報は以下の 
// 属性セットを通して制御されます。アセンブリに関連付けられている 
// 情報を変更するには、これらの属性値を変更してください。
//
[assembly: AssemblyTitle("SFCMN09084R")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Partsman")]
[assembly: AssemblyCopyright("(c)2008 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark("Partsman")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDeployment(DeployPosition.Server, ConstantManagement_SF_PRO.ServerCode_UserAP)]		

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

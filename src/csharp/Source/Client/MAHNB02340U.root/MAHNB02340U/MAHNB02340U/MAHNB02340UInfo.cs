//**********************************************************************//
// System           :   DistributionCore                                //
// Sub System       :                                                   //
// Program name     :   売上確認表印刷条件フォームクラス                //
//                  :   MAHNB02340U.DLL                                 //
// Name Space       :   Broadleaf.Windows.Forms                         //
// Programmer       :   飯谷耕平                                        //
// Date             :   2007.03.30                                      //
//----------------------------------------------------------------------//
// Data		        :	2007.11.08									    //
// Programmer       :   矢田 敬吾                                       //
// Update Note      :   出荷日付を入力日付に変更                        //
//                      出力単位を削除                                  //
//                      キャリア、売上形式、販売形態を削除              //
//                      商品区分グループ、商品区分を削除                //
//                      商品コードを入力者コードに変更                  //
//                      出力順を変更・追加                              //
//                      粗利チェックを追加                              //
//----------------------------------------------------------------------//
// Update Note      :   2008.07.03 30413 犬飼                           //
//   		        :	PM.NS対応									    //
//----------------------------------------------------------------------//
// Update Note      :   2013/01/04 田建委                               //
// 管理番号         :   10806793-00 2013/03/13配信分                    //
//   		        :	Redmine#34098 罫線印字制御の追加対応    	    //
//----------------------------------------------------------------------//
// Update Note      :   2013/02/27 王君                                 //
// 管理番号         :   10806793-00 2013/03/13配信分                    //
//   		        :	Redmine#34098 罫線印字制御の追加対応    	    //
//----------------------------------------------------------------------//
// Update Note      :   2013/03/11 cheq                                 //
// 管理番号         :   10900690-00 2013/03/26配信分                    //
//   		        :	Redmine#34987 フォーカス遷移の追加対応    	    //
//----------------------------------------------------------------------//
// Update Note      :   2020/02/27 尹安                                 //
// 管理番号         :   11570208-00 軽減税率対応                        //
//----------------------------------------------------------------------//
//                Copyright(c)2007 Broadleaf Co.,Ltd.                   //
//**********************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;

//
// アセンブリに関する一般情報は以下の 
// 属性セットを通して制御されます。アセンブリに関連付けられている 
// 情報を変更するには、これらの属性値を変更してください。
//
[assembly: AssemblyTitle("MAHNB02340U")]
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

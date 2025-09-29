using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;
//**********************************************************************//
// System           :   ＳＦ．ＮＥＴ                                    //
// Sub System       :                                                   //
// Program name     :   帳票共通(条件入力タイプ)フレームクラス          //
//                  :   SFANL07200.DLL        　                        //
// Name Space       :   Broadleaf.Windows.Forms                         //
// Programmer       :   Y.Sasaki                                        //
// Date             :   2006.01.17                                      //
//----------------------------------------------------------------------//
// Update Note      :   2006.01.17  Y.Sasaki                            //
//                  :   新規作成                                        //
// Update Note      :   2006.08.09  Y.Sasaki                            //
//                  :   １.システム選択有り時の選択可能システムの設定を //
//                  :   選択可能システムより選択できるように機能追加。  //
// Update Note      :   2006.09.04  Y.Sasaki                            //
//                  :   １.拠点コードのトリム追加                       //
// Update Note      :   2006.09.26  Y.Sasaki                            //
//                  :   １.拠点制御設定で「全拠点」が設定されるとき、   //
//                  :   「全社」にチェックがつかない障害解除。          //
// Update Note      :   2006.09.28  Y.Sasaki                            //
//                  :   １.テキスト出力機能追加                         //
// Update Note      :   2007.03.06  Y.Sasaki                            //
//                  :   １.携帯.NS用に改良                              //
// Update Note      :   2007.07.17  Y.Sasaki                            //
//                  :   １.グラフ画面タブがアクティブな時に抽出条件が   //
//                  :   選択できないように修正                          //
// Update Note      :   K2014/03/10  licb                               //
//                  :   信越自動車商会個別開発テキスト出力機能を追加する//
// Update Note      :   2021/01/04 譚洪                                 //
//                  :   PMKOBETSU-4109　プログラム起動ログを操作履歴ログ//
//                  :   に出力する追加対応                              //
//----------------------------------------------------------------------//
//                Copyright(c)2006 Broadleaf Co.,Ltd.                   //
//**********************************************************************//

//
// アセンブリに関する一般情報は以下の 
// 属性セットを通して制御されます。アセンブリに関連付けられている 
// 情報を変更するには、これらの属性値を変更してください。
//
[assembly: AssemblyTitle("帳票メイン")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Mobile")]
[assembly: AssemblyCopyright("(c)2006 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark("Mobile")]
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

[assembly: AssemblyVersion("5.10.1.0")]
[assembly: AssemblyFileVersion("1.10.1.0")]

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

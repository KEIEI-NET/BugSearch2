using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;
using System.Runtime.InteropServices;

//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   得意先電子元帳データ取得アクセスクラス       	//
//                  :   PMTAB00162A.DLL							        //
// Name Space       :   Broadleaf.Application.Controller				//
// Programmer       :   licb	                                        //
// Date             :   2013/05/29                                      //
//----------------------------------------------------------------------//
// Update Note		:	2013/06/11 licb                                 //
//                  :   ソースチェック確認事項一覧NO.9の対応            //
//----------------------------------------------------------------------//
// Update Note		:	2013/06/24 licb                                 //
//                  :   #37126の対応、得意先伝票履歴画面 伝票区分「全て //
//                      にすると表示されない                            //
//----------------------------------------------------------------------//
// Update Note		:	2013/06/25 licb                                 //
//                  :   #37231の対応、タブレットログ対応                //
//----------------------------------------------------------------------//
// Update Note		:	2013/06/29 licb                                 //
//                  :   #37133の対応、初期検索時４９伝票しか表示されない//
//----------------------------------------------------------------------//
// Update Note		:	2013/06/29 licb                                 //
//                  :   #37693の対応、正常に動作しない場合がある        //
//----------------------------------------------------------------------//
// Update Note		:	2013/07/09 licb                                 //
//                  :   #37785の対応、次の50件が有効になりません        //
//----------------------------------------------------------------------//
// Update Note		:	2013/07/09 licb                                 //
//                  :   #38047の対応、入金伝票の明細表示がPMNSと異なる  //
//----------------------------------------------------------------------//
// Update Note		:	2013/07/11 licb                                 //
//                  :   #38182の対応、【(得意先電子元帳)】ソート 　　　 //
//----------------------------------------------------------------------//
// Update Note		:	2013/07/11 licb                                 //
//                  :   #38220の対応、不必要なログ出力の削除     　　　 //
//----------------------------------------------------------------------//
// Update Note		:	2013/07/23 鄭慕鈞                               //
//                  :   #38877の対応、得意先元帳の売上入力者名称をカット//
//----------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.                 //
//**********************************************************************//


// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("PMTAB00162A")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Partsman")]
[assembly: AssemblyCopyright("(c)2013 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark("Partsman")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDeployment(DeployPosition.Client)]

// ComVisible を false に設定すると、このアセンブリ内の型は COM コンポーネントには 
// 参照不可能になります。COM からこのアセンブリ内の型にアクセスする場合は、 
// その型の ComVisible 属性を true に設定してください。
[assembly: ComVisible(false)]

// 次の GUID は、このプロジェクトが COM に公開される場合の、typelib の ID です
//[assembly: Guid("0a5777d8-3328-4936-b3af-38dea2852a0d")]

// アセンブリのバージョン情報は、以下の 4 つの値で構成されています:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
[assembly: AssemblyVersion("8.10.1.0")]
[assembly: AssemblyFileVersion("8.10.1.0")]

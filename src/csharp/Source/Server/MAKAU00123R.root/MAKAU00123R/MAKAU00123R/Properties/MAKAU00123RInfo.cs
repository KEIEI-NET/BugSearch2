using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;
using Broadleaf.Application.Resources;
using System.Runtime.InteropServices;

//**********************************************************************//
// System           :   ＤＣ．ＮＳ                                      //
// Sub System       :                                                   //
// Program name     :   請求金額マスタ更新リモーティング 				//
//                  :   MAKAU00123R.DLL									//
// Name Space       :   Broadleaf.Application.Remoting					//
// Programmer       :   20036  斉藤　雅明	                            //
// Date             :   2007.03.14                                      //
//----------------------------------------------------------------------//
// Update Note      :   980081  山田 明友                               //
// Date             :   2007.12.08 流通基幹対応                         //
//----------------------------------------------------------------------//
// Update Note      :   980081  山田 明友                               //
// Date             :   2008.01.10 請求先略称をセットするよう修正       //
//                  :              全拠点一括締め対応                   //
//----------------------------------------------------------------------//
// Update Note      :	ＰＭ.ＮＳ用に変更       						//
// Update Date      :   2008.07.18                                      //
//                  :   20081 疋田 勇人　                               //
//----------------------------------------------------------------------//
// Update Note      :	2010/12/20  鄧潘ハン       						//
//                  :   ①得意先請求金額マスタのデータセット仕様変更    //
//----------------------------------------------------------------------//
// Update Note      :   2011/12/22 凌小青                               //
// 管理番号         :   10707327-00 2012/01/25配信分                    //
//----------------------------------------------------------------------//
// Update Note      :   2012/10/18 liusy                                //
// 管理番号         :   10801804-00 2012/11/14配信分                    //
//----------------------------------------------------------------------//
// Update Note      :   2012/12/12  dpp                                 //
// 管理番号         :   10801804-00 2013/01/16配信分                    //
//----------------------------------------------------------------------//
// Update Note      :   2013/08/08  汪権来                              //
// 管理番号         :   10902175-00 2013/06/18配信分                    //
//                  :   Redmine#35552 「売上締次更新」の処理速度遅延    //
//                  :   の調査と対応(№1921)                            //
//----------------------------------------------------------------------//
// Update Note      :   2016/10/27 田建委                               //
// 管理番号         :   11275240-00 Redmine#48899                       //
//                  :   売上締次処理のレコードロック解除                //
//----------------------------------------------------------------------//
// Update Note      :   2019/10/15 譚洪                                 //
// 管理番号         :   11575156-00                                     //
//                  :   PMKOBETSU-1860 速度遅延やタイムアウトの対応     //
//----------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("MAKAU00123R")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Partsman")]
[assembly: AssemblyCopyright("(c)2008 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark("Partsman")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDeployment(DeployPosition.Server, ConstantManagement_SF_PRO.ServerCode_UserAP)]

// ComVisible を false に設定すると、このアセンブリ内の型は COM コンポーネントには 
// 参照不可能になります。COM からこのアセンブリ内の型にアクセスする場合は、 
// その型の ComVisible 属性を true に設定してください。
[assembly: ComVisible(false)]

// アセンブリのバージョン情報は、以下の 4 つの値で構成されています:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// すべての値を指定するか、下のように '*' を使ってリビジョンおよびビルド番号を 
// 既定値にすることができます:
[assembly: AssemblyVersion("8.10.1.0")]
[assembly: AssemblyFileVersion("8.10.1.0")]

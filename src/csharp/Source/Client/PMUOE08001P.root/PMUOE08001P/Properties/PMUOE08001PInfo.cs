//**********************************************************************//
// System         :  ＰＭ．ＮＳ										    //
// Sub System     :  												    //
// Program name   :  自由帳票ＵＯＥ伝票印刷クラス				        //
//                :  PMUOE08001P.DLL								    //
// Name Space     :  Broadleaf.Drawing.Printing						    //
// Programmer     :  鈴木 正臣										    //
// Date           :  2008.11.18										    //
//----------------------------------------------------------------------//
// Update Note    :  2011/02/16  徐嘉                                   //
//                   自社名称１，２が縦倍角になっていない不具合の対応   //
// Update Note    :  2011/07/19  豆昌紅　　　　　　　　　　　　　　　　 //
//                   回答区分印字の対応   　　　　　　　　　　　　　　　//
// Update Note    :  2011/08/05  豆昌紅　　　　　　　　　　　　　　　　 //
//                   障害報告 #23404対応   　　　　　　　　　　　　　　 //
// Update Note    :  2011/08/08  豆昌紅　　　　　　　　　　　　　　　　 //
//                   障害報告 #23459対応   　　　　　　　　　　　　　　 //
// Update Note    :  2017/08/30 3H 楊善娟                               //
//                :  11370074-00 ハンディ対応（2次）                    //
//----------------------------------------------------------------------//
//					Copyright(c)2008 Broadleaf Co.,Ltd.					//
//**********************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Broadleaf.Library;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle( "PMUOE08001P" )]
[assembly: AssemblyDescription( "" )]
[assembly: AssemblyConfiguration( "" )]
[assembly: AssemblyCompany( "Broadleaf Co.,Ltd." )]
[assembly: AssemblyProduct( "Partsman" )]
[assembly: AssemblyCopyright( "(c)2008 Broadleaf Co.,Ltd." )]
[assembly: AssemblyTrademark( "Partsman" )]
[assembly: AssemblyCulture( "" )]
[assembly: AssemblyDeployment( DeployPosition.Client )]

// ComVisible を false に設定すると、このアセンブリ内の型は COM コンポーネントには 
// 参照不可能になります。COM からこのアセンブリ内の型にアクセスする場合は、 
// その型の ComVisible 属性を true に設定してください。
[assembly: ComVisible( false )]

// 次の GUID は、このプロジェクトが COM に公開される場合の、typelib の ID です
[assembly: Guid( "399ffd12-17bc-4396-8395-4508f3680847" )]

// アセンブリのバージョン情報は、以下の 4 つの値で構成されています:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// すべての値を指定するか、下のように '*' を使ってリビジョンおよびビルド番号を 
// 既定値にすることができます:
[assembly: AssemblyVersion( "8.10.1.0" )]
[assembly: AssemblyFileVersion( "8.10.1.0" )]

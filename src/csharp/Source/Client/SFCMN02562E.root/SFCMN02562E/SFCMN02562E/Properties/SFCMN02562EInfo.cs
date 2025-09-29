using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Broadleaf.Library;
//*******************************************************************************//
// System           :   ＳＦ．ＮＥＴ                                             //
// Sub System       :                                                            //
// Program name     :   ＳＣＭ設定　ＵＩデータクラス　　　　　　　　　           //
//                  :   SFCMN02562E.DLL								             //
// Name Space       :   Broadleaf.Application.UIData                             //
// Programmer       :   95094  大塚　たえ子	                                     //
// Date             :   2009.05.22                                               //
//-------------------------------------------------------------------------------//
// Update Note      :	2011.05.26 30015 橋本　裕毅						         //
//                  :	SCM連結元拠点別設定マスタを追加                          //
// Update Note      :	2011.08.12 x_zhuxk									 	 //
//                  :	PCCUOE													 //
// Update Note      :   2014.09.10  Ryo.  №11070111-00：FTC事業場対応           //
//                  :   ・以下のクラスを追加                                     //
//                  :     提供側SCM事業場連結マスタヘッダファイル(OScmBPCnt)     //
//                  :     → SFCMN02562ED.cs                                     //
//                  :     提供側SCM事業場拠点連結マスタヘッダファイル(OScmBPSCnt)//
//                  :     → SFCMN02565DE.cs                                     //
//-------------------------------------------------------------------------------//
//                 Copyright(c)2009 Broadleaf Co.,Ltd.                           //
//*******************************************************************************//

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("SFCMN02562E")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Broadleaf.NS series")]
[assembly: AssemblyCopyright("(c)2009 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark(".NS")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDeployment(DeployPosition.Client)]		

// ComVisible を false に設定すると、このアセンブリ内の型は COM コンポーネントには 
// 参照不可能になります。COM からこのアセンブリ内の型にアクセスする場合は、 
// その型の ComVisible 属性を true に設定してください。
[assembly: ComVisible(false)]

// 次の GUID は、このプロジェクトが COM に公開される場合の、typelib の ID です
[assembly: Guid("2944c47f-628c-44e1-98db-fe1298148973")]

// アセンブリのバージョン情報は、以下の 4 つの値で構成されています:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
[assembly: AssemblyVersion("5.20.1.0")]
[assembly: AssemblyFileVersion("5.20.1.0")]
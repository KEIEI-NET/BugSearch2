//**********************************************************************//
// System         :  PM.NS
// Sub System     :
// Program name   :  自由帳票（請求書）アクセスクラス
//                :  PMKAU01002A.DLL
// Name Space     :  Broadleaf.Application.Controller
// Programmer     :  陳艶丹
// Date           :  2022/03/07
//----------------------------------------------------------------------//
// Update Note    :  2023/04/14 3H 仰亮亮                               // 
//                   11970040-00 自由帳票項目追加対応                   //
//                   ①売上伝票計金額(税込み)                           //
//                   ②消費税(伝票転嫁)/売上伝票計金額(税込み)          //
//----------------------------------------------------------------------//
//                 Copyright(c)2021 Broadleaf Co.,Ltd.                  //
//**********************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Broadleaf.Library;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle( "PMKAU01002A" )]
[assembly: AssemblyDescription( "" )]
[assembly: AssemblyConfiguration( "" )]
[assembly: AssemblyCompany( "Broadleaf Co.,Ltd." )]
[assembly: AssemblyProduct( "Partsman" )]
[assembly: AssemblyCopyright( "(c)2021 Broadleaf Co.,Ltd." )]
[assembly: AssemblyTrademark( "Partsman" )]
[assembly: AssemblyCulture( "" )]
[assembly: AssemblyDeployment( DeployPosition.Client )]

// ComVisible を false に設定すると、このアセンブリ内の型は COM コンポーネントには 
// 参照不可能になります。COM からこのアセンブリ内の型にアクセスする場合は、 
// その型の ComVisible 属性を true に設定してください。
[assembly: ComVisible( false )]

// 次の GUID は、このプロジェクトが COM に公開される場合の、typelib の ID です
[assembly: Guid( "a8a601cb-7e28-405b-8409-cbedcc27680b" )]

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

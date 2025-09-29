//**********************************************************************//
// System			:	ＰＭ．ＮＳ										//
// Sub System		:													//
// Program name		:	自由帳票検索条件設定UI							//
//					:	SFANL08130U.DLL									//
// Name Space		:	Broadleaf.Windows.Forms							//
// Programmer		:	鈴木　正臣										//
// Date				:	2008.05.21										//
//----------------------------------------------------------------------//
// Update Note		:	2008.03.19 22024 寺坂誉志						//
//					:	１．帳票の抽出条件に日付系項目が含まれない状態での	//
//					:	　　確定を不可とする。							//
//					:	2008.04.04 22024 寺坂誉志						//
//					:	１．品管№2008P058-5-005010-01					//
//					:	　　「×」押下時に入力ﾁｪｯｸがかからない不具合修正	//
//					:	2008.04.07 22024 寺坂誉志						//
//					:	１．品管№2008P058-2-001005-02					//
//					:	　　2008.04.04対応追加分 表示順位等を編集状態にて	//
//					:	　　入力チェックがかからない不具合修正				//
//----------------------------------------------------------------------//
//					Copyright(c)2008 Broadleaf Co.,Ltd.					//
//**********************************************************************//
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using Broadleaf.Library;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("SFANL08130U")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Partsman")]
[assembly: AssemblyCopyright("(c)2008 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark("Partsman")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDeployment(DeployPosition.Client)]

// ComVisible を false に設定すると、このアセンブリ内の型は COM コンポーネントには 
// 参照不可能になります。COM からこのアセンブリ内の型にアクセスする場合は、 
// その型の ComVisible 属性を true に設定してください。
[assembly: ComVisible(false)]

// 次の GUID は、このプロジェクトが COM に公開される場合の、typelib の ID です
[assembly: Guid("abbdd661-167c-46ce-abfc-f2033080ed82")]

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

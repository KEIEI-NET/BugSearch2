//**********************************************************************//
// System			:	ＰＭ．ＮＳ										//
// Sub System		:													//
// Program name		:	自由帳票印字位置設定UIクラス						//
//					:	SFANL08105U.DLL									//
// Name Space		:	Broadleaf.Windows.Forms							//
// Programmer		:	鈴木　正臣										//
// Date				:	2008.05.21										//
//----------------------------------------------------------------------//
// Update Note		:	2008.03.19 22024 寺坂誉志						//
//					:	１．帳票の抽出条件に日付系項目が含まれない状態での	//
//					:	　　登録を不可とする。							//
//					:	２．SummaryGroupに存在しないGroupHeaderが			//
//					:	　　指定されていると印刷時にエラーが発生する		//
//					:	　　不具合修正。									//
//					:	３．抽出条件の必須条件の入力チェックが				//
//					:	　　行なわれるように修正。						//
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
[assembly: AssemblyTitle("SFANL08105U")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Partsman")]
[assembly: AssemblyCopyright("(c)2008 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark( "Partsman" )]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDeployment(DeployPosition.Client)]	

// ComVisible を false に設定すると、このアセンブリ内の型は COM コンポーネントには 
// 参照不可能になります。COM からこのアセンブリ内の型にアクセスする場合は、 
// その型の ComVisible 属性を true に設定してください。
[assembly: ComVisible(false)]

// 次の GUID は、このプロジェクトが COM に公開される場合の、typelib の ID です
[assembly: Guid("d6e1dd89-819d-432a-b3b7-c905b36166c3")]

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

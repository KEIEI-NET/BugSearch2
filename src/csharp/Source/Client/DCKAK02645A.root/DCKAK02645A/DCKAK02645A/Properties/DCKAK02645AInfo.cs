//**********************************************************************//
// System			:	DC.NS											//
// Sub System		:													//
// Program name		:	買掛残高一覧表アクセスクラス					//
//					:	DCKAK02645A.DLL									//
// Name Space		:	Broadleaf.Application.Controller				//
// Programmer		:	22018 鈴木 正臣									//
// Date				:	2007.10.24										//
//----------------------------------------------------------------------//
// Update Note      :   2008.10.01 30413 犬飼                           //
//   		        :	PM.NS対応									    //
//----------------------------------------------------------------------//
// Update Note      :   2020/03/02 劉星光                               //
//   		        :	11570208-00 軽減税率対応 				        //
//----------------------------------------------------------------------//
// Update Note      :   2022/10/09 仰亮亮                               //
//   		        :	11870141-00 インボイス対応（税率別合計金額不具合修正）//
//----------------------------------------------------------------------//
//                 Copyright(c)2007 Broadleaf Co.,Ltd.                  //
//**********************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Broadleaf.Library;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("DCKAK02645A")]
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
[assembly: Guid("0c37756d-3f10-4fa9-b65f-e1d36db8e7e0")]

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

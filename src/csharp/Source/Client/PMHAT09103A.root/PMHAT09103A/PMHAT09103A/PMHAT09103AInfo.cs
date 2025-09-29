//**********************************************************************//
// System			:	PM.NS											//
// Sub System		:													//
// Program name		:	発注点設定処理アクセスクラス				    //
//					:	PMHAT09103A.DLL									//
// Name Space		:	Broadleaf.Application.Controller				//
// Programmer		:	劉学智  									    //
// Date				:	2009.04.13										//
//----------------------------------------------------------------------//
// Update Note      :   2015/06/03 許雁波	                         	//
//                  :   11100937-00 Redmine#45978 イスコジャパン 同一倉庫内で同一品番が複数印字される修正//
//----------------------------------------------------------------------//
// Update Note      :                                                   //
// 管理番号  11100937-00 作成担当 : 金慶園
// 修 正 日  2015/07/13  修正内容 : Redmine#45978 
//                                  東海自動車課題対応案件No.3:商品マスタの商品属性が、0：純正の商品しか対象とならず、
//                                  1:その他を設定している優良品番が抽出対象外となってしまう。
//----------------------------------------------------------------------------//
// Update Note      :   2015/08/13 許雁波	                         	//
//                  :   11100937-00 Redmine#45978の#93と#94 仕入先取得、原単価算出の障害対応//
//----------------------------------------------------------------------//
//                 Copyright(c)2008 Broadleaf Co.,Ltd.                  //
//**********************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Broadleaf.Library;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("PMHAT09103A")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Partsman")]
[assembly: AssemblyCopyright("(c)2009 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark("Partsman")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDeployment(DeployPosition.Client)]

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

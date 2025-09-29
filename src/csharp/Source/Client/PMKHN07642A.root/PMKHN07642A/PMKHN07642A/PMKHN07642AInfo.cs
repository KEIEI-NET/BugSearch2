//**********************************************************************//
// System			:	PM.NS											//
// Sub System		:													//
// Program name		:	得意先マスタ（インポート）アクセスクラス	    //
//					:	PMKHN07642A.DLL									//
// Name Space		:	Broadleaf.Application.Controller				//
// Programmer		:	劉学智  									    //
// Date				:	2009.05.13										//
//----------------------------------------------------------------------//
// Update Note      :   2012/06/12 李亜博　　                           //
//   		        :	10801804-00  大陽案件 Redmine#30393             //
//                      得意先マスタインポート・エクスポート            //
//                      得意先掛率グループとチェックを追加              //
//----------------------------------------------------------------------//
// Update Note      :   2012/07/03  李亜博　　                          //
//   		        :	10801804-00 大陽案件  Redmine#30393             //
//                      得意先マスタインポート・エクスポート            //
//                      得意先掛率グループとチェックを追加の改良        //
//----------------------------------------------------------------------//
// Update Note      :   2012/07/09 李亜博　　                           // 
//   		        :	10801804-00   大陽案件 Redmine#30387            //   
//                      障害一覧の指摘NO.46の対応                       //
//----------------------------------------------------------------------//
// Update Note      :   2012/07/11 李亜博　　                           // 
//   		        :	10801804-00   大陽案件 Redmine#30387            //   
//                      障害一覧の指摘NO.62の対応                       //
//----------------------------------------------------------------------//
// Update Note      :   2012/07/13 李亜博　　                           // 
//   		        :	10801804-00   大陽案件 Redmine#30387            //   
//                      障害一覧の指摘NO.7の対応                        //
//----------------------------------------------------------------------//
// Update Note      :   2012/07/20 李亜博　　                           // 
//   		        :	10801804-00   大陽案件 Redmine#30387            //   
//                      障害一覧の指摘NO.108の対応                      //
//----------------------------------------------------------------------//
//                 Copyright(c)2009 Broadleaf Co.,Ltd.                  //
//**********************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Broadleaf.Library;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("PMKHN07642A")]
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

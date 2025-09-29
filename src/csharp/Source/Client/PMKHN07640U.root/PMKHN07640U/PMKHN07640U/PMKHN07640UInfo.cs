//**********************************************************************//
// System			:	PM.NS											//
// Sub System		:													//
// Program name		:	得意先マスタ（インポート） UIクラス		        //
//					:	PMKHN07640U.DLL									//
// Name Space		:	Broadleaf.Windows.Forms							//
// Programmer		:	劉学智								　　　　　　//
// Date				:	2009.05.12										//
//----------------------------------------------------------------------//
// Update Note      :   2012/06/12 李亜博　　                           //
//   		        :	10801804-00 大陽案件  Redmine#30393             //
//                      得意先マスタインポート・エクスポート            //
//                      得意先掛率グループとチェックを追加              //
//----------------------------------------------------------------------//
// Update Note      :   2012/06/28  李亜博　　                          //
//   		        :	10801804-00 大陽案件                            //
//                      内部発見バッグの対応：大小写について            //
//----------------------------------------------------------------------//
// Update Note      :   2012/06/28  李亜博　　                          //
//   		        :	10801804-00 大陽案件                            //
//                      内部発見バッグの対応：ログファイル形について    //
//----------------------------------------------------------------------//
// Update Note      :   2012/06/28  李亜博　　                          //
//   		        :	10801804-00 大陽案件                            //
//                      内部発見バッグの対応：ログファイルの名について  //
//----------------------------------------------------------------------//
// Update Note      :   2012/07/03  李亜博　　                          //
//   		        :	10801804-00 大陽案件  Redmine#30393             //
//                      得意先マスタインポート・エクスポート            //
//                      得意先掛率グループとチェックを追加の改良        //
//----------------------------------------------------------------------//
// Update Note      :   2012/07/20 李亜博　　                           // 
//   		        :	10801804-00   大陽案件 Redmine#30387            //   
//                      障害一覧の指摘NO.108の対応                      //
//----------------------------------------------------------------------//
// Update Note      :   2012/07/26 李亜博　　                           // 
//   		        :	10801804-00   大陽案件 Redmine#30387            //   
//                      障害一覧の指摘NO.119の対応                      //
//                      メッセージの修正                                //
//----------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.                 //
//**********************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Broadleaf.Library;

// アセンブリに関する一般情報は以下の属性セットをとおして制御されます。 
// アセンブリに関連付けられている情報を変更するには、
// これらの属性値を変更してください。
[assembly: AssemblyTitle("PMKHN07640U")]
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
[assembly: AssemblyVersion("8.10.1.0")]
[assembly: AssemblyFileVersion("8.10.1.0")]

//
// アセンブリに署名するには、使用するキーを指定しなければなりません。 
// アセンブリ署名に関する詳細については、Microsoft .NET Framework ドキュメントを参照してください。
//
// 下記の属性を使って、署名に使うキーを制御します。 
//
// メモ : 
//   (*) キーが指定されないと、アセンブリは署名されません。
//   (*) KeyName は、コンピュータにインストールされている
//        暗号サービス プロバイダ (CSP) のキーを表します。KeyFile は、
//       キーを含むファイルです。
//   (*) KeyFile および KeyName の値が共に指定されている場合は、 
//       以下の処理が行われます :
//       (1) KeyName が CSP に見つかった場合、そのキーが使われます。
//       (2) KeyName が存在せず、KeyFile が存在する場合、 
//           KeyFile にあるキーが CSP にインストールされ、使われます。
//   (*) KeyFile を作成するには、sn.exe (厳密な名前) ユーティリティを使ってください。
//       KeyFile を指定するとき、KeyFile の場所は、
//       プロジェクト出力 ディレクトリへの相対パスでなければなりません。
//       パスは、%Project Directory%\obj\<configuration> です。たとえば、KeyFile がプロジェクト ディレクトリにある場合、
//       AssemblyKeyFile 属性を 
//       [assembly: AssemblyKeyFile("..\\..\\mykey.snk")] として指定します。
//   (*) 遅延署名は高度なオプションです。
//       詳細については Microsoft .NET Framework ドキュメントを参照してください。
//
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile("")]
[assembly: AssemblyKeyName("")]
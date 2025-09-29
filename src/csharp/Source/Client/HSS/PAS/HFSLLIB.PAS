unit HFSLLIB;
{***************************************************************************}
{ System         :                                                          }
{ Sub System     :                                                          }
{ Program Name   : 共通関数部品                                             }
{ Programer      : ueo                                                      }
{ Date           : 1999.08.07                                               }
{---------------------------------------------------------------------------}
{               (c)Copyright  1999 TSUBASA SYSTEM Co,. Ltd                  }
{---------------------------------------------------------------------------}
{===========================================================================}
{20000106 ueo    : HHanToZenで全角と半角が混ざっている場合に半角文字が変換さ}
{                : れない不具合解除                                         }
{20000218 ueo    : MDI子画面からShowdalでWindowsを表示し、さらに画面無しDLL }
{                : DLLからHMsgDispを呼び出すと裏に隠れる為、WindowsHandleを }
{                : 自動で検索するように修正                                 }
{20000512 ueo    : 半角変換、全角変換関数に記号を追加                       }
{20000617 ueo    : HIniPathMakeでSFPATH.INIﾌｧｲﾙに設定が無い場合ﾒｯｾｰｼﾞを表示 }
{                : していたが、LOCALﾊﾟｽを返すように変更                     }
{20000620 ueo    : HConnectDBで失敗した場合にﾒｯｾｰｼﾞを表示するように変更     }
{20000624 ueo    : SF-LITE共通ﾍｯﾀﾞ(ﾊﾞｯﾁﾍｯﾀﾞ)領域ﾃﾞｰﾀｾｯﾄ関数の追加           }
{20000624 ueo    : SF-LITE共通ﾍｯﾀﾞ(ﾊﾞｯﾁﾍｯﾀﾞ)領域ﾃﾞｰﾀｾｯﾄ関数の追加           }
// Update Note   :   2000.06.27  鹿野　幸生                                //
//               :               ① DBコネクト、シェアチェックをHInitProc  //
//               :                  として外出し                           //
//               :   2000.07.04  鹿野　幸生 (植田Sより依頼の分)            //
//               :               ① HGetFileHeader関数の中で常にFalseを    //
//               :                  返していたのを修正                     //
//               :               ② HGetFileHeader関数の中で一度ﾕｰｻﾞｰｺｰﾄﾞ  //
//               :                  を取得したら2度目以降取得しないように  //
//               :                  修正                                   //
//               :   2000.07.12  鹿野　幸生                                //
//               :      ① DLLのLoad Freeを変更                            //
//               :   2000.08.16  鹿野　幸生                                //
//               :      ①  HDspMsg, HWrtSysLogを追加                      //
//               :   2000.08.20  鹿野　幸生                                //
//               :      ①  HSetDefColor, HGetIniPathを追加                //
//               :   2000.08.21  鹿野　幸生                                //
//               :      ①  HMsgDispに×ボタン終了無しを追加               //
//               :   2000.09.12  鹿野　幸生                                //
//               :      ①  HMsgDispに終了確認(保存優先)を追加             //
//               :      ②  HStrPNCopyで250バイト以上扱えるように修正      //
//               :   2000.10.05  鹿野　幸生                                //
//               :      ①  HSetDefColorにStringGrid,PerfectGridを追加     //
//               :   2000.10.12  鹿野　幸生                                //
//               :      ①  HSetDefColorにBrsu,Penを追加                   //
//               :   2000.10.21  鹿野　幸生                                //
//               :      ①  セキュリティチェック・ログの仕様変更に合わせ   //
//               :          内部変更                                       //
//               :   2000.11.22  鹿野　幸生                                //
//               :      ①  HWrtSysLog, HMsgDisp関数を修正                 //
//               :   2000.11.28  鹿野　幸生                                //
//               :      ①  HExecFilte関数を追加                           //
//               :   2000.12.27  鹿野　幸生                                //
//               :      ①  HGetIniPathで、SFPATH.INIからの取得に失敗しても//
//               :          一つ上のディレクトリでINIファイル名を合成する  //
//               :          ように変更                                     //
//               :   2001.01.23  鹿野　幸生                                //
//               :      ①  IMEを強制クローズするHCloseImeを追加           //
//               :   2002.02.20  鹿野　幸生                                //
//               :      ①  SFPATH.INIの名前をバージョン別に取得できるよう //
//               :          に SFPATH50.INI に変更                         //
//               :   2002.02.22  鹿野　幸生                                //
//               :      ①  HGetIniPathで取得する際にHSS部品が使用するINI  //
//               :          を取得できるように                             //
//               :   2001.02.26  鹿野　幸生                                //
//               :    ② ALPBU0002をHLOGACS50に変更                        //
//               :   2001.03.19  鹿野　幸生                                //
//               :      ①  HDspMsgでメッセージがFormの下に隠れる場合が    //
//               :          有った障害を解除                               //
//               :   2001.03.27  鹿野　幸生                                //
//               :      ①  HHanToZen, HZenToHanで「ﾂ」の変換が「ゥ」に    //
//               :          成ってしまう障害を解除                         //
//               :   2001.04.03  鹿野　幸生                                //
//               :      ①  HGetFilteHeader関数で時間の値が不正になる障害を//
//               :          解除                                           //
//               :   2001.04.12  鹿野　幸生                                //
//               :      ①  HDspMsgでPGの初期処理中のタイミングによっては、//
//               :          アドレスエラーが発生する障害を解除             //
//               :   2001.04.19  鹿野　幸生                                //
//               :      ①  HHPCHK32からHHPCHK50に変更                     //
//               :   2001.10.19  鹿野　幸生                                //
//               :      ①  HZenToHanで半角が混じっていると正しく変換でき  //
//               :          ない障害を解除                                 //
//               :   2002.07.25  鹿野　幸生                                //
//               :      ①  全角半角変換で全角小文字'ォ'の変換できない     //
//               :          障害を解除                                     //
//               :   2009.08.10 徳永　誠                                   //
//               :      ①  Delphi2009対応(HSS100対応）                    //
//               :   2009.09.04 上野 耕平                                  //
//               :      ①  HGetFileHeader,GetTimeNowToTicks()             //
//               :   2009.09.07 上野 耕平                                  //
//               :      ①  GetTimeNowToTicksを削除してHDate.pasに移動     //
//               :      ②  HDateを参照に追加                              //
//               :   2009.09.08 上野 耕平                                  //
//               :      ①  項目IDを大文字に統一                           //
//               :   2009.10.10 徳永　誠                                   //
//              :      ①  エラーログ・認証部品組込                        //
//               : 2010.07.06 noguchi INIファイルが1つ上のディレクトリに   //
//                                    作成される不具合解消                 //
{***************************************************************************}
interface

uses
//  Windows, Messages, SysUtils, Classes, Forms, Graphics, HDBACS, Filectrl, TypInfo, // 2009.08.10 Del
  Windows, Messages, SysUtils, Classes, Forms, Graphics, TypInfo,     // 2009.08.10 Ins
  Dialogs,  //2009.10.10 Ins
  IniFiles,
  DBClient, //2009.09.04 ueno add
  HDate     //2009.09.07 ueno add
  ;

const
  ERR_LEVEL_STOP        = 0;           // ｴﾗｰ
  ERR_LEVEL_EXCLAMATION = 1;           // 警告
  ERR_LEVEL_INFO        = 2;           // 情報
  ERR_LEVEL_QUESTION    = 3;           // 確認
  ERR_LEVEL_CONFIRM     = 4;           // 終了確認
  ERR_LEVEL_STOPDISP    = 5;           // ｴﾗｰ(×ボタン表示終了無し)
  ERR_LEVEL_SAVECONFIRM = 6;           // 終了確認(保存優先)
  ERR_LEVEL_NODISP      = 99;          // メッセージ表示無しログのみ書き込み    2001.04.12 追加

  HGET_FHINS            = 0;           // INSERT
  HGET_FHUPD            = 1;           // UPDATE

  ctHSSBASEINI   = 'HSSBASEINI';
  ctSFBASEINI    = 'SFBASEINI';

//  ctLOG_NOWRT           = 0;           // ログ書込み無し
//  ctLOG_WRT             = 1;           // ログ書込み有り

  ctMAINFORM_TITLE      = '-1';        // メインフォーム・タイトル
  ctACTIVEFORM_TITLE    = '0';         // アクティブフォーム・タイトル

  ctOPE_START           = 'START';     // 起動
  ctOPE_LOGIN           = 'LOGIN';     // ログイン
  ctOPE_CONNECT         = 'CONNECT';   // 接続
  ctOPE_DISCONCT        = 'DISCONCT';  // 接続解除
  ctOPE_INIT            = 'INIT';      // 初期化処理                            2002.07.25 追加
  ctOPE_OPEN            = 'OPEN';      // ファイルオープン
  ctOPE_GET             = 'GET';       // データ読込み
  ctOPE_READ            = 'GET';       // データ読込み
  ctOPE_INS             = 'INS';       // データ挿入
  ctOPE_INSERT          = 'INS';       // データ挿入
  ctOPE_UPDT            = 'UPDT';      // データ更新
  ctOPE_UPDATE          = 'UPDT';      // データ更新
//  ctOPE_UPATE           = 'UPDT';      // データ更新
  ctOPE_HIDE            = 'HIDE';      // データ論理削除
  ctOPE_DEL             = 'DEL';       // データ削除
  ctOPE_DELETE          = 'DEL';       // データ削除
  ctOPE_LOCK            = 'LOCK';      // データLOCK
  ctOPE_UNLOCK          = 'UNLOCK';    // データLOCK解除
  ctOPE_CLOSE           = 'CLOSE';     // ファイルクローズ
  ctOPE_PRINT           = 'PRINT';     // 印刷
  ctOPE_COMMT           = 'COMM';      // 通信
  ctOPE_CALL            = 'CALL';      // 呼出し
  ctOPE_SEND            = 'SEND';      // 送信
  ctOPE_RECV            = 'RECV';      // 受信
  ctOPE_RECIEVE         = 'RECV';      // 受信
  ctOPE_TIMEOUT         = 'TIMEOUT';   // タイムアウト
  ctOPE_EXIT            = 'EXIT';      // 終了処理                              2002.07.25 追加

  ctMAX_PATH            = 255;         // マックスパスレングス

type
  //ﾊﾞｯﾁｵﾝﾗｲﾝﾌｧｲﾙ共通ﾍｯﾀﾞ
  tagBatHead = packed record
    creadate : LongInt;                //作成日
    update   : LongInt;                //更新日
    rdelkbn  : SmallInt;               //論理削除区分
    userid1  : Array[0..7-1] of Char;  //ﾕｰｻﾞｰID1
    userid2  : Array[0..2-1] of Char;  //ﾕｰｻﾞｰID2
    userid3  : Array[0..2-1] of Char;  //ﾕｰｻﾞｰID3
    actime   : LongInt;                //処理時間
  end;
// 20000624 <<

  // ログ書込み用構造体                                                         2000.08.16 追加
  tagLogData = Record
    nLogNo :      smallint;                                          // ログタイプNo     2001.03.04 追加
    szSysShu   :  char;                                              // ログデータ種別
    nSysTanCd  :  smallint;                                          // ログデータ担当者コード
    szSysTannm :  array[0..30-1]of char;                             // ログデータ担当者名
    nSysSeclvdt : smallint;                                          // ログデータオペレーターデータ処理レベル
    nSysSeclvfu : smallint;                                          // ログデータオペレーター機能処理レベル
    szSysPid :    array[0..32-1] of char;                            // ログデータ対象プログラムＩＤ
    szSysPnm :    array[0..40-1] of char;                            // ログデータ対象プログラムＩＤ
    szSysProc:    array[0..40-1] of char;                            // ログデータ対象プログラムＩＤ
    szSysOpe :    array[0..20-1] of char;                            // ログデータオペレーション
    szSysMstid :  array[0..32-1] of char;                            // ログデータ対象マスタＩＤ
    szSysSt :     array[0..8-1]  of char;                            // ログデータステータス
    szSysMsg :    array[0..80-1] of char;                            // ログデータメッセージ内容
    szSysBuff :   array[0..255-1]of char;                            // ログデータ　データ／キーバッファ内容
    nSysKeyno :   smallint;                                          // ログデータキーナンバー
    szSysFlver :  array[0..3-1]of char;                              // ログデータファイルバージョン
    szSysSysver : array[0..12-1]of char;                             // ログデータシステムバージョン
  end;

  function  Hstmake( wstr: String; len: Integer ): String;
  function  HStrPNCopy( pstr:PChar; wstr: String; len: Integer ): PChar;
  function  Hkanji( pstr: PChar; pos: Integer ): boolean;
  function  Hiskanji( c: Char ): boolean;
  function  Hsc_kanaf( kbn: Integer; data1: String):String;
//  function  Hsc_kanaf2( kbn: Integer; data1: String):String;      // 2009.08.10 Del
  function  HMemcpy( dest : PChar; p1 : PChar; Size : integer ):PChar;
  function  HSpcCut(szParam: String): String;
//  function  HHanToZen(data1: String; leng: Integer):String;       // 2009.08.10 Del
//  function  HHanToZen2(data1: String; leng: SmallInt):String;     // 2009.08.10 Del
//  function  HZenToHan(data1: String; leng: Integer):String;       // 2009.08.10 Del
  function  HMsgDisp(iLvl:Integer;strMsg:String;strPgId:String;
    			nSts:Integer;fuAddStyle:Integer):Integer;
  function  HMsgDisp2(AplHandle:HWND;iLvl:Integer;strMsg:String;
                strPgId:String;nSts:Integer;fuAddStyle:Integer):Integer;
//  procedure HLogOut(s:String;fname:String);                                   // 2009.08.10 Del
  function  HKanma( Str:String):String;
  function  HIniPathMake(strIFile:String):String;

  function GetTopMostWindows(Handle: HWND; Info: Pointer): BOOL; stdcall;

// 20000624 >>
//  function HGetFileHeader(Rec:Pointer;Mode:Integer):Boolean;                  // 2009.08.10 Del

  //>>>>2009.09.04 ueno add start
  function HGetFileHeader(fileHeader:TClientDataSet;Mode:Integer):Boolean;
  //function GetTimeNowToTicks():Int64;                                        // 2009.09.07 Del ueno
  //<<<<2009.09.04 ueno add end

  function DllLoadProc(DllNm:String;ModuleNm:String;
                       var InsHandle:THandle;var fpProc:FARPROC):Boolean;
//  function LoadCtlHPChk32(inFncType: integer): Boolean;                       // 2009.08.10 Del
  function SetPgInfo(inPgType: integer; istrPgId, istrPgNm: string): integer;
  function GetPgId: string;
  function GetPgNm: string;
  function GetPgDllId: string;                                                  // 2009.08.10 Ins
  function GetPgDllNm: string;                                                  // 2009.08.10 Ins
//  function LoadCtlALPBU0002(inFncType: integer): Boolean;                     2001.02.26 変更
//  function LoadCtlHLogAcs(inFncType: integer): Boolean;                       // 2009.08.10 Del
  function HDspMsg(iMsgLvl:Integer; istrUntId:String; istrPnm:String;
                   istrProcNm: string; istrOperate: string; istrMsg:String;
                    inSts:Integer; iMstCompo:TObject; inAddStyle:Integer): Integer;
//  function HWrtSysLog(istrPnm:String; istrProcNm:String; istrOperate: string;   // 2000.10.21 変更 // 2009.08.10 Del
//                     istrMsg:String; istrSts:string; iDetailBuff: string): Integer;                // 2009.08.10 Del
  function HSetDefColor(iForm: TForm; istrIniName, istrSecName: string; istrComp1:string = ''; iComp2:TComponent = nil): integer;
  function HGetIniPath(var istrSFLitePath: string): integer;
  function HExecFile(inExeType: integer; istrExecFile: string; istrExecDir: string; istrParam: string): integer; //2000.11.28 追加
  function HCloseIme(iwHandle: THandle): integer;                               //2001.01.23 追加
//  function HSetLogDataNo(inLogDataNo: smallint): integer;                     // 2009.08.10 Del
//  function HGetLogDataNo: smallint;                                           // 2009.08.10 Del
  function HGetBaseIniNo(inOperand: integer=0): integer;                        // 2009.08.10 Ins
  function HSetBaseIniNo(inIniNo:integer; inOperand: integer=0): integer;       // 2009.08.10 Ins
  function HKanaToZenkaku(const Str: String): String;                           // 2009.08.10 Ins
  function HZenkakuToHankaku(const Str: String): String;                        // 2009.08.10 Ins
  function LoadLogoutputDll(inFncType: integer): Boolean;                       // 2009.10.10 Ins


implementation

uses
  HInitProc, imm, HDlgForm;

//  procedure HPGetTkcd (var tkcd:LongInt;var tkcd2:LongInt);stdcall; external 'HHPCHK32.DLL';

// 20000624 >>
const
  ctUNITID    = 'HFSLLIB';                                                      // 2001.02.20 追加
  ctLOGFILE   = 'SFERROR.LOG';
//  ctALPBU0002 = 'ALPBU0002.DLL';                                              // 2001.02.26 変更
//  ctHLOGACS_DLL = 'HLOGACS50.DLL';                                            // 2009.08.10 Del
  ctLogout_DLL  = 'NSCMN00027.DLL';                                             // 2009.09.10 Ins
  ctWrtSysLog = 'WrtSysLog';
//  ctSFPATHINI = 'SFPATH50.INI';                                               // 2001.02.20 追加 // 2009.08.10 Del
  ctSFPATHINI = 'SFPATH100.INI';                                                // 2009.08.10 Ins
  ctSecNameWrtLog = 'ログ書込み処理';                                            // 2001.02.26 追加


// 20000624 <<

var
  glMsgHandle:  HWND;
// 20000624 >>
//  ghndHpChk32  : THANDLE;                                                     // 2009.08.10 Del
//  ghndALPBU0002: THANDLE;                                                     // 2001.02.26 変更
//  ghndHLogACs: THANDLE;                                                       // 2009.08.10 Del
//  pHpGetTkcd  : procedure (var tkcd:LongInt;var tkcd2:LongInt);stdcall;       // 2009.08.10 Del
// 20000624 <<
//  pWrtSysLog  : function (istLogData: tagLogData): integer; stdcall;            // 2000.08.16 追加  // 2009.08.10 Del
  ghndLogout    : THANDLE;                                                      // 2009.09.10 Ins
  pOutput       : function (pgId : string; messagestr : string ;  status : integer):string; stdcall; // 2009.09.10 Ins
  gstrPgExeId:   string;
  gstrPgExeNm:   string;
  gstrPgDllId:   string;
  gstrPgDllNm:   string;
  guserid1:      Array [0..6] of Char = #0;             // ユーザーID1          2000.07.04 追加
  guserid2:      Array [0..1] of Char = #0;             // ユーザーID2          2000.07.04 追加
  guserid3:      Array [0..1] of Char = #0;             // ユーザーID3          2000.07.04 追加
//  gnActivLogDataNo: smallint = 1;                       // ログ書き出しNo       2001.03.04 追加     // 2009.08.10 Del
  gnBaseIniNo : integer = 1;                            // 使用基本INIファイルNo// 2009.08.10 Ins


{*******************************************************************}
{ Module Name   : 文字列編集処理                                    }
{               : Hstmake                                           }
{ 引数          : 1 String  編集したい文字列                        }
{               : 2 Integer 文字の長さ                              }
{ 戻り値        : 1 String  編集後の文字列                          }
{ Programer     : ueo                                               }
{ Date          : 1999.08.06                                        }
{ Note          : 編集したい文字列を指定した文字の長さで切ります。  }
{               : 切った文字列の最後の1Byteが全角文字の1Byte目で    }
{               : あれば、そこは半角スペースに置き換えます。        }
{               : 文字列の長さが編集したい文字列より長い場合は残りを}
{               : ｽﾍﾟｰｽ(0x20)埋めします。                           }
{-------------------------------------------------------------------}
{ Update Note   :                                                   }
{               : 2009.08.10 徳永　誠                               }
{               :  Unicode化により、指定文字数で切るように変更      }
{               :  (Byteではない)                                   }
{*******************************************************************}
function Hstmake( wstr: String; len: Integer ): String;
var
  pstr1, pstr2: array[0..255] of Char;
  wlen: Integer;
  ix: Integer;
begin
  StrPCopy( pstr2, wstr );
//  FillChar(pstr1, sizeof(pstr1), ' ');                                        // 2009.08.10 Del
  for ix := 0 to Length(pstr1) - 1 do                                           // 2009.08.10 Ins
    pstr1[ix] := ' ';                                                           // 2009.08.10 Ins
  wlen := Length( wstr );
  if wlen > len then wlen := len;
  if wlen <> 0 then
  begin
    for ix := 0 to wlen -1 do pstr1[ix] := pstr2[ix];
  end;
// 2009.08.10 Del Start  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//  if len <> 0 then
//  begin
//    if Hkanji( pstr1, len - 1) then pstr1[len - 1] := ' ';
//  end;
// 2009.08.10 Del End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
  pstr1[len] := #0;

  result :=  pstr1;
end;

{*******************************************************************}
{ Module Name   : 文字列編集処理(String→PChar)                     }
{               : HStrPNCopy                                        }
{ 引数          : 1 PChar   編集後の文字列格納ﾊﾞｯﾌｧ                 }
{               : 2 String  編集したい文字列                        }
{               : 3 Integer 文字の長さ                              }
{ 戻り値        : 1 PChar   編集後の文字列                          }
{ Programer     : ueo                                               }
{ Date          : 1999.08.06                                        }
{ Note          : 編集したい文字列を指定した文字の長さで切ります。  }
{               : 切った文字列の最後の1Byteが全角文字の1Byte目で    }
{               : あれば、そこは半角スペースに置き換えます。        }
{               : 文字列の長さが編集したい文字列より長い場合は残りを}
{               : ｽﾍﾟｰｽ(0x20)埋めします。                           }
{-------------------------------------------------------------------}
{ Update Note   : 2000.09.12  鹿野　幸生                            }
{               : 2009.08.10 徳永　誠                               }
{               :  Unicode化により、指定文字数で切るように変更      }
{               :  (Byteではない)                                   }
{*******************************************************************}
function HStrPNCopy( pstr:PChar; wstr: String; len: Integer ): PChar;
var
//  pstr1, pstr2: array[0..255] of Char;
  wlen: Integer;
  ix: Integer;

begin


//  StrPCopy( pstr2, wstr );                                                    2000.09.12 変更
//  FillChar(pstr1, sizeof(pstr1), ' ');
//  FillMemory(pstr, Len, ord(' '));                                            // 2009.08.10 Del
  for ix := 0 to len - 1 do                                                     // 2009.08.10 Ins
    pstr[ix] := ' ';                                                            // 2009.08.10 Ins

  wlen := Length( wstr );
  if wlen > len then wlen := len;
  if wlen <> 0 then begin
//    for ix := 0 to wlen -1 do pstr[ix] := wstr[ix+1];
    for ix := 0 to wlen -1 do
      pstr[ix] := wstr[ix+1];
  end;
// 2009.08.10 Del Start  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//  if len <> 0 then
//  begin
//    if Hkanji( pstr1, len - 1) then pstr1[len - 1] := ' ';
//  end;
// 2009.08.10 Del End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

//  pstr[len] := #0;

//  HMemcpy(pstr,pstr1,len);
  result :=  pstr;

end;

{*******************************************************************}
{ Module Name   : 文字列漢字判断処理                                }
{               : Hkanji                                            }
{ 引数          : 1 PChar   検索させたい文字列                      }
{               : 2 Integer 判断したい文字の順番                    }
{ 戻り値        : 1 boolean 漢字第1ﾊﾞｲﾄ=TRUE,その他=FALSE           }
{ Programer     : ueo                                               }
{ Date          : 1999.08.06                                        }
{ Note          : 指定した文字列の指定した文字順番目が漢字の第1ﾊﾞｲﾄ }
{               : 目かどうを判断します。                            }
{-------------------------------------------------------------------}
{ Update Note   :                                                   }
{               : 2009.08.10 徳永　誠                               }
{               :  Unicode化により、指定文字数の文字が全角か半角かの}
{               :  判断を行うように変更                             }
{*******************************************************************}
function Hkanji( pstr: PChar; pos: Integer ): boolean;
//var                                                                           // 2009.08.10 Del
//  cnt:  Integer;                                                              // 2009.08.10 Del
begin
  result := Hiskanji(pstr[pos]);
// 2009.08.10 Del Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//  cnt := 0;
//
//  result := FALSE;
//  while cnt <= pos do
//  begin
//    if Hiskanji(pstr[cnt]) then
//    begin
//      if pos = cnt then
//      begin
//        result := TRUE;
//        break;
//      end;
//      cnt := cnt + 2;
//    end
//    else
//      inc( cnt );
//  end;
// 2009.08.10 Del End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
end;

{*******************************************************************}
{ Module Name   : 漢字検査処理                                      }
{               : Hiskanji                                          }
{ 引数          : 1 Char    検査する文字                            }
{ 戻り値        : 1 boolean 漢字第1ﾊﾞｲﾄ=TRUE,その他=FALSE           }
{ Programer     : ueo                                               }
{ Date          : 1999.08.06                                        }
{ Note          : 指定した文字が漢字の第1ﾊﾞｲﾄかどうか判断します。   }
{-------------------------------------------------------------------}
{ Update Note   :                                                   }
{               : 2009.08.10 徳永　誠                               }
{               :  Unicode化により、パラメータ文字が全角か半角かの  }
{               :  判断を行うように変更                             }
{*******************************************************************}
function Hiskanji( c: Char ): boolean;
begin
  // Unicode ASCII及び半角ｶﾅｺｰﾄﾞ範囲にて判定
  result := true;                                                   // 2009.08.10 Ins
  case Ord(c) of // var wc: WideChar;                               // 2009.08.10 Ins
    $00..$7F, $FF61..$FF9F:                                         // 2009.08.10 Ins
      result := false;                                              // 2009.08.10 Ins
  end;                                                              // 2009.08.10 Ins
//  result := ((Byte(c) >= $81) and (Byte(c) <= $9F))               // 2009.08.10 Del
//         or ((Byte(c) >= $E0) and (Byte(c) <= $FC))               // 2009.08.10 Del
end;

{*******************************************************************}
{ Module Name   : 半角ｶﾀｶﾅ⇔全角ひらがな変換                        }
{               : Hsc_kanaf                                         }
{ 引数          : 1 Integer 0:半角ｶﾀｶﾅ⇒全角ひらがなへ変換          }
{               :           1:全角ひらがな⇒半角ｶﾀｶﾅへ変換          }
{               : 2 String  変換させたい文字列(半角or全角)          }
{ 戻り値        : 1 strin   変換後の文字(失敗時は空文字)            }
{ Programer     : ueo                                               }
{ Date          : 1999.08.06                                        }
{ Note          : 半角ｶﾀｶﾅを全角ひらがなへ、全角ひらがなを半角ｶﾀｶﾅに}
{               : 変換します。                                      }
{-------------------------------------------------------------------}
{ Update Note   :                                                   }
{               : 2009.08.10 徳永　誠                               }
{               :  Unicode化による対応                              }
{*******************************************************************}
function Hsc_kanaf(kbn: Integer; data1: String):String;
const
// 2009.08.10 Del Start >>>>>>>>>>>>>
//  kana: array[0..83] of String[5]
//    =  ('ｱ あ','ｲ い','ｳ う','ｴ え','ｵ お',
//        'ｶ か','ｷ き','ｸ く','ｹ け','ｺ こ',
//        'ｻ さ','ｼ し','ｽ す','ｾ せ','ｿ そ',
//        'ﾀ た','ﾁ ち','ﾂ つ','ﾃ て','ﾄ と',
//        'ﾅ な','ﾆ に','ﾇ ぬ','ﾈ ね','ﾉ の',
//        'ﾊ は','ﾋ ひ','ﾌ ふ','ﾍ へ','ﾎ ほ',
//        'ﾏ ま','ﾐ み','ﾑ む','ﾒ め','ﾓ も',
//        'ﾔ や','ﾕ ゆ','ﾖ よ','ﾗ ら','ﾘ り',
//        'ﾙ る','ﾚ れ','ﾛ ろ','ﾜ わ','ﾝ ん',
//        'ｦ を','A Ａ','B Ｂ','C Ｃ','D Ｄ',
//        'E Ｅ','F Ｆ','G Ｇ','H Ｈ','I Ｉ',
//        'J Ｊ','K Ｋ','L Ｌ','M Ｍ','N Ｎ',
//        'O Ｏ','P Ｐ','Q Ｑ','R Ｒ','S Ｓ',
//        'T Ｔ','U Ｕ','V Ｖ','W Ｗ','X Ｘ',
//        'Y Ｙ','Z Ｚ','0 ０','1 １','2 ２',
//        '3 ３','4 ４','5 ５','6 ６','7 ７',
//        '8 ８','9 ９','ﾞ ゛','  　');
// 2009.08.10 Del End <<<<<<<<<<<<<<<<

  kanaHan: array[0..83] of char
    =  ('ｱ','ｲ','ｳ','ｴ','ｵ',
        'ｶ','ｷ','ｸ','ｹ','ｺ',
        'ｻ','ｼ','ｽ','ｾ','ｿ',
        'ﾀ','ﾁ','ﾂ','ﾃ','ﾄ',
        'ﾅ','ﾆ','ﾇ','ﾈ','ﾉ',
        'ﾊ','ﾋ','ﾌ','ﾍ','ﾎ',
        'ﾏ','ﾐ','ﾑ','ﾒ','ﾓ',
        'ﾔ','ﾕ','ﾖ','ﾗ','ﾘ',
        'ﾙ','ﾚ','ﾛ','ﾜ','ﾝ',
        'ｦ','A','B','C','D',
        'E','F','G','H','I',
        'J','K','L','M','N',
        'O','P','Q','R','S',
        'T','U','V','W','X',
        'Y','Z','0','1','2',
        '3','4','5','6','7',
        '8','9','ﾞ',' ');
  kanaZen: array[0..83] of char
    =  ('あ','い','う','え','お',
        'か','き','く','け','こ',
        'さ','し','す','せ','そ',
        'た','ち','つ','て','と',
        'な','に','ぬ','ね','の',
        'は','ひ','ふ','へ','ほ',
        'ま','み','む','め','も',
        'や','ゆ','よ','ら','り',
        'る','れ','ろ','わ','ん',
        'を','Ａ','Ｂ','Ｃ','Ｄ',
        'Ｅ','Ｆ','Ｇ','Ｈ','Ｉ',
        'Ｊ','Ｋ','Ｌ','Ｍ','Ｎ',
        'Ｏ','Ｐ','Ｑ','Ｒ','Ｓ',
        'Ｔ','Ｕ','Ｖ','Ｗ','Ｘ',
        'Ｙ','Ｚ','０','１','２',
        '３','４','５','６','７',
        '８','９','゛','　');

var
//  i, j, len, sts: Integer;                                                    // 2009.08.10 Del
  i, j, len: Integer;                                                           // 2009.08.10 Ins
  str: String;
begin

  str := '';
  len := Length(data1);

  for j := 0 to len - 1 do
  begin
    if kbn = 0 then
    begin
      for i := 0 to 83 do
      begin
// 2009.08.10 Del Start >>>>>>>>>>>>>
//        sts := CompareText(Copy(data1[j + 1], 1, 1), Copy(kana[i], 1, 1));
//        if sts = 0 then
//        begin
//          str := str + Copy(kana[i], 3, 2);                                   // 2009.08.10 Del
//        end;
// 2009.08.10 Del End <<<<<<<<<<<<<<<<
// 2009.08.10 Ins Start >>>>>>>>>>>>>
        if data1[j+1] = kanaHan[i] then
        begin
          str := str + kanaZen[i];
        end;
// 2009.08.10 Ins End <<<<<<<<<<<<<<<<
      end;
    end
    else begin
      for i := 0 to 83 do
      begin
// 2009.08.10 Del Start >>>>>>>>>>>>>
//        sts := CompareText(Copy(data1, j+1, 2), Copy(kana[i], 3, 2));         // 2009.08.10 Del
//        end;
//        if sts = 0 then
//        begin
//          str := str + Copy(kana[i], 1, 1);
//        end;
// 2009.08.10 Del End <<<<<<<<<<<<<<<<
// 2009.08.10 Ins Start >>>>>>>>>>>>>
        if data1[j+1] = kanaZen[i] then
        begin
          str := str + kanaHan[i];
        end;
// 2009.08.10 Ins End <<<<<<<<<<<<<<<<
      end;
    end;
  end;
  result := str;
end;

{*******************************************************************}
{ Module Name   : ｺﾋﾟｰ                                              }
{               : HMemcpy                                           }
{ 引数          : 1 PChar   ｺﾋﾟｰ先ﾊﾞｯﾌｧへのﾎﾟｲﾝﾀ                    }
{               : 2 PChar   ｺﾋﾟｰ元ﾊﾞｯﾌｧへのﾎﾟｲﾝﾀ                    }
{               : 3 Integer ｺﾋﾟｰするﾊﾞｲﾄ数                          }
{ 戻り値        : 1 PChar   ｺﾋﾟｰ先ﾊﾞｯﾌｧへのﾎﾟｲﾝﾀ                    }
{ Programer     : ueo                                               }
{ Date          : 1999.08.06                                        }
{ Note          : 文字列を指定ﾊﾞｲﾄ分ｺﾋﾟｰします。NULLの判断は行い    }
{               : ません。                                          }
{-------------------------------------------------------------------}
{ Update Note   :                                                   }
{ Update Note   :                                                   }
{               : 2009.08.10 徳永　誠                               }
{               :  Unicode化による対応により文字数分ｺﾋﾟｰへ変更      }
{               :  (バイト数ではありません)                         }
{*******************************************************************}
function HMemcpy(dest:PChar;p1:PChar;Size:integer):PChar;
var
   cnt : integer;
begin
   for cnt := 0 to (Size-1) do dest[cnt] := p1[cnt];
   HMemcpy := dest;

end;

{*******************************************************************}
{ Module Name   : ｽﾍﾟｰｽｶｯﾄ                                          }
{               : HSpcCut                                           }
{ 引数          : 1 String  ｽﾍﾟｰｽｶｯﾄする文字列                      }
{ 戻り値        : 1 String  ｽﾍﾟｰｽｶｯﾄ後の文字列                      }
{ Programer     : ueo                                               }
{ Date          : 1999.08.06                                        }
{ Note          : 文字列中の全ての半角ｽﾍﾟｰｽ、全角ｽﾍﾟｰｽをｶｯﾄします。 }
{-------------------------------------------------------------------}
{ Update Note   :                                                   }
{               : 2009.08.10 徳永　誠                               }
{               :  Unicode化による対応                              }
{*******************************************************************}
function HSpcCut(szParam: String): String;
var
  ix: integer;
  iCnt: integer;
  szStr: String;
  lpStr1: array[0..255] of Char;
  lpStr2: array[0..255] of Char;
begin
  FillChar(lpStr1, SizeOf(lpStr1), #0);
  FillChar(lpStr2, SizeOf(lpStr2), #0);
  StrPLCopy(lpStr1, szParam, Length(szParam));

  iCnt := 0;
  ix := 0;
  while (ix <= SizeOf(lpStr1) - 1) do
  begin
// 2009.08.10 Del Start >>>>>>>>>>>>>>>
//    if (lpStr1[ix] = Chr($81)) and (lpStr1[ix + 1] = Chr($40)) then
//    begin
//      Inc(ix);
//    end
//    else if (lpStr1[ix] <> Chr($20)) and (lpStr1[ix] <> Chr($0)) then
// 2009.08.10 Del End <<<<<<<<<<<<<<<<
    if (lpStr1[ix] <> ' ') and (lpStr1[ix] <> '　') and (lpStr1[ix] <> Chr($0)) then  // 2009.08.10 Ins
    begin
      lpStr2[iCnt] := lpStr1[ix];
      Inc(iCnt);
    end
    else if lpStr1[ix] = Chr($0) then
      Break;

    Inc(ix);
  end;

  lpStr2[iCnt + 1] := Chr($0);
  szStr := StrPas(lpStr2);
  Result := szStr;
end;

// 2009.08.10 Ins Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
{*******************************************************************}
{ Module Name   : 半角全角変換                                      }
{               : HKanaToZenkaku                                    }
{ 引数          : 1 String  変換する文字列                          }
{ Programer     : 徳永　誠                                          }
{ Date          : 2009.08.10                                        }
{ Note          : 文字列中の半角文字を全角文字に変換します。        }
{               : ※文字列中に全角ひらがながある場合全角カタカナに  }
{               :   変換されるので注意                              }
{-------------------------------------------------------------------}
{ Update Note   :                                                   }
{*******************************************************************}
function HKanaToZenkaku(const Str: String): String;
var
  Size: Integer;
  Flags: DWORD;
begin
  Flags := LCMAP_FULLWIDTH or LCMAP_KATAKANA;

  { Calculate destination size }
  Size := LCMapString(LOCALE_SYSTEM_DEFAULT,Flags,PChar(Str),Length(Str),nil,0);
  { Convert }
  SetLength(Result,Size);
  Size := LCMapString(LOCALE_SYSTEM_DEFAULT,Flags,
                      PChar(Str),Length(Str),PChar(Result),Size);
  if Size <= 0 then
  begin
    Result := Str;
    Exit;
  end;
  SetLength(Result,Size);

end;

{*******************************************************************}
{ Module Name   : 全角半角変換                                      }
{               : HZenkakuToHankaku                                 }
{ 引数          : 1 String  変換する文字列                          }
{ Programer     : 徳永　誠                                          }
{ Date          : 2009.08.10                                        }
{ Note          : 文字列中の全角文字を半角文字に変換します。        }
{               : ※全角ひらがなは変換されません（カナはカタカナのみ）}
{-------------------------------------------------------------------}
{ Update Note   :                                                   }
{*******************************************************************}
function HZenkakuToHankaku(const Str: String): String;
var
  Size: Integer;
  Flags: DWORD;
begin

  Flags := LCMAP_HALFWIDTH;

  { Calculate destination size }
  Size := LCMapString(LOCALE_SYSTEM_DEFAULT,Flags,PChar(Str),Length(Str),nil,0);

  { Convert }
  SetLength(Result,Size);
  Size := LCMapString(LOCALE_SYSTEM_DEFAULT,Flags,
                      PChar(Str),Length(Str),PChar(Result),Size);
  if Size <= 0 then
  begin
    Result := Str;
    Exit;
  end;
  SetLength(Result,Size);

end;
// 2009.08.10 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

// 2009.08.10 Del Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
(*
{*******************************************************************}
{ Module Name   : 半角全角変換                                      }
{               : HHanToZen                                         }
{ 引数          : 1 String  変換する文字列                          }
{ 戻り値        : 1 Integer 変換する文字数                          }
{ Programer     : ueo                                               }
{ Date          : 1999.08.06                                        }
{ Note          : 文字列中の半角文字を全角文字に変換します。        }
{-------------------------------------------------------------------}
{ Update Note   : 2001.03.27  鹿野　幸生                            }
{               : 2002.07.25  鹿野　幸生                            }
{*******************************************************************}
function HHanToZen(data1: String; leng: Integer):String;
const
//  kana: array[0..148] of String[5]                                            2002.07.25 変更
  kana: array[0..149] of String[5]
    =  ('ｱ ア','ｲ イ','ｳ ウ','ｴ エ','ｵ オ',
        'ｶ カ','ｷ キ','ｸ ク','ｹ ケ','ｺ コ',
        'ｻ サ','ｼ シ','ｽ ス','ｾ セ','ｿ ソ',
        'ﾀ タ','ﾁ チ','ﾂ ツ','ﾃ テ','ﾄ ト',
        'ﾅ ナ','ﾆ ニ','ﾇ ヌ','ﾈ ネ','ﾉ ノ',
        'ﾊ ハ','ﾋ ヒ','ﾌ フ','ﾍ ヘ','ﾎ ホ',
        'ﾏ マ','ﾐ ミ','ﾑ ム','ﾒ メ','ﾓ モ',
        'ﾔ ヤ','ﾕ ユ','ﾖ ヨ','ﾗ ラ','ﾘ リ',
        'ﾙ ル','ﾚ レ','ﾛ ロ','ﾜ ワ','ﾝ ン',
//        'ｦ ヲ','ｨ ィ','ｪ ェ','ｯ ゥ','ｬ ャ',
        'ｦ ヲ','ｨ ィ','ｪ ェ','ｯ ッ','ｬ ャ',
        'ｭ ュ','ｮ ョ','ｶﾞガ','ｷﾞギ','ｸﾞグ',
        'ｹﾞゲ','ｺﾞゴ','ｻﾞザ','ｼﾞジ','ｽﾞズ',
        'ｾﾞゼ','ｿﾞゾ','ﾀﾞダ','ﾁﾞヂ','ﾂﾞヅ',
        'ﾃﾞデ','ﾄﾞド','ﾊﾞバ','ﾋﾞビ','ﾌﾞブ',
        'ﾍﾞベ','ﾎﾞボ','ﾊﾟパ','ﾋﾟピ','ﾌﾟプ',
        'ﾍﾟペ','ﾎﾟポ','ｳﾞヴ','A Ａ','B Ｂ',
        'C Ｃ','D Ｄ','E Ｅ','F Ｆ','G Ｇ',
        'H Ｈ','I Ｉ','J Ｊ','K Ｋ','L Ｌ',
        'M Ｍ','N Ｎ','O Ｏ','P Ｐ','Q Ｑ',
        'R Ｒ','S Ｓ','T Ｔ','U Ｕ','V Ｖ',
        'W Ｗ','X Ｘ','Y Ｙ','Z Ｚ','a ａ',
        'b ｂ','c ｃ','d ｄ','e ｅ','f ｆ',
        'g ｇ','h ｈ','i ｉ','j ｊ','k ｋ',
        'l ｌ','m ｍ','n ｎ','o ｏ','p ｐ',
        'q ｑ','r ｒ','s ｓ','t ｔ','u ｕ',
        'v ｖ','w ｗ','x ｘ','y ｙ','z ｚ',
        '- －','/ ／','･ ・','1 １','2 ２',
        '3 ３','4 ４','5 ５','6 ６','7 ７',
        '8 ８','9 ９','0 ０','  　','ｰ ー',
//        '( （',') ）','ｧ ァ','ｩ ゥ');                                        2002.07.25 変更
        '( （',') ）','ｧ ァ','ｩ ゥ','ｫ ォ');
var
  ix1, ix2, cnt : SmallInt;
  work, str : array[0..255] of Char;
begin
  //変換文字が全角の場合はそのままかえす。
//if Hkanji(PChar(data1),0) = true then
//begin
//  Result := data1;
//  Exit;
//end;
  StrPCopy(work,data1);
  FillChar(str,sizeof(str),#0);
  str := '';
  cnt := 0;
  ix1 := 0;
//for ix1 := 0 to leng - 1 do
  while ix1 < leng do
  begin
    if work[ix1] = #0 then
      break;
    //変換文字が全角の場合はそのままかえす。
    if Hkanji(@work[ix1],0) = true then
    begin
      StrPCopy(@str[cnt*2],Copy(work, ix1+1, 2));
      Inc(cnt);
      Inc(ix1,2);
      Continue;
    end;

//    for ix2 := 0 to 148 do                                                    2002.07.25 変更
    for ix2 := 0 to 149 do
    begin
      if work[ix1] = Copy(kana[ix2], 1, 1) then
      begin
        if (work[ix1+1] = 'ﾞ') or (work[ix1+1] = 'ﾟ') then
        begin
          if work[ix1+1] = Copy(kana[ix2], 2, 1) then
          begin
            StrPCopy(@str[cnt*2],Copy(kana[ix2], 3, 2));
            Inc(cnt);
            break;
          end;
        end else
        begin
          StrPCopy(@str[cnt*2],Copy(kana[ix2], 3, 2));
          Inc(cnt);
          break;
        end;
      end;
    end;
    Inc(ix1);
  end;
  str[cnt*2] := #0;

  result := StrPas(str);
end;

{*******************************************************************}
{ Module Name   : 全角半角変換                                      }
{               : HZenToHan                                         }
{ 引数          : 1 String  変換する文字列                          }
{ 戻り値        : 1 Integer 変換する文字数                          }
{ Programer     : ueo                                               }
{ Date          : 1999.08.06                                        }
{ Note          : 文字列中の全角文字を半角文字に変換します。        }
{-------------------------------------------------------------------}
{ Update Note   : 2001.03.27  鹿野　幸生                            }
{               : 2001.10.19  鹿野　幸生                            }
{               : 2002.07.25  鹿野　幸生                            }
{*******************************************************************}
function HZenToHan(data1: String; leng: Integer):String;
const
//20000512 >>
//  ctKanaMax = 180;                                                            2002.07.25 変更
  ctKanaMax = 181;
//kana: array[0..148] of String[5]
  kana: array[0..ctKanaMax] of String[5]
//20000512 <<
    =  ('ｱ ア','ｲ イ','ｳ ウ','ｴ エ','ｵ オ',
        'ｶ カ','ｷ キ','ｸ ク','ｹ ケ','ｺ コ',
        'ｻ サ','ｼ シ','ｽ ス','ｾ セ','ｿ ソ',
        'ﾀ タ','ﾁ チ','ﾂ ツ','ﾃ テ','ﾄ ト',
        'ﾅ ナ','ﾆ ニ','ﾇ ヌ','ﾈ ネ','ﾉ ノ',
        'ﾊ ハ','ﾋ ヒ','ﾌ フ','ﾍ ヘ','ﾎ ホ',
        'ﾏ マ','ﾐ ミ','ﾑ ム','ﾒ メ','ﾓ モ',
        'ﾔ ヤ','ﾕ ユ','ﾖ ヨ','ﾗ ラ','ﾘ リ',
        'ﾙ ル','ﾚ レ','ﾛ ロ','ﾜ ワ','ﾝ ン',
//        'ｦ ヲ','ｨ ィ','ｪ ェ','ｯ ゥ','ｬ ャ',
        'ｦ ヲ','ｨ ィ','ｪ ェ','ｯ ッ','ｬ ャ',
        'ｭ ュ','ｮ ョ','ｶﾞガ','ｷﾞギ','ｸﾞグ',
        'ｹﾞゲ','ｺﾞゴ','ｻﾞザ','ｼﾞジ','ｽﾞズ',
        'ｾﾞゼ','ｿﾞゾ','ﾀﾞダ','ﾁﾞヂ','ﾂﾞヅ',
        'ﾃﾞデ','ﾄﾞド','ﾊﾞバ','ﾋﾞビ','ﾌﾞブ',
        'ﾍﾞベ','ﾎﾞボ','ﾊﾟパ','ﾋﾟピ','ﾌﾟプ',
        'ﾍﾟペ','ﾎﾟポ','ｳﾞヴ','A Ａ','B Ｂ',
        'C Ｃ','D Ｄ','E Ｅ','F Ｆ','G Ｇ',
        'H Ｈ','I Ｉ','J Ｊ','K Ｋ','L Ｌ',
        'M Ｍ','N Ｎ','O Ｏ','P Ｐ','Q Ｑ',
        'R Ｒ','S Ｓ','T Ｔ','U Ｕ','V Ｖ',
        'W Ｗ','X Ｘ','Y Ｙ','Z Ｚ','a ａ',
        'b ｂ','c ｃ','d ｄ','e ｅ','f ｆ',
        'g ｇ','h ｈ','i ｉ','j ｊ','k ｋ',
        'l ｌ','m ｍ','n ｎ','o ｏ','p ｐ',
        'q ｑ','r ｒ','s ｓ','t ｔ','u ｕ',
        'v ｖ','w ｗ','x ｘ','y ｙ','z ｚ',
        '- －','/ ／','･ ・','1 １','2 ２',
        '3 ３','4 ４','5 ５','6 ６','7 ７',
        '8 ８','9 ９','0 ０','  　','ｰ ー',
//20000512 >>
//      '( （',') ）','ｧ ァ','ｩ ゥ');
        '( （',') ）','ｧ ァ','ｩ ゥ','< ＜',
        '> ＞','? ？','_ ＿','[ ［','] ］',
        '{ ｛','} ｝','+ ＋','* ＊','@ ＠',
        '` ‘','| ｜','~ ～','= ＝','& ＆',
        '% ％','$ ＄','# ＃','" ”','! ！',
        '\ ￥',', ，','. ．','､ 、','｡ 。',
        '; ；',': ：','[ ［','] ］','｢ 「',
//        '｣ 」');                                                             2002.07.25 変更
        '｣ 」', 'ｫ ォ');
//20000512 <<
var
  ix1, ix2, sts : SmallInt;
  str  : String;
begin
  str := '';

//                                                                              2001.10.19 変更
//  for ix2 := 0 to leng - 1 do
//  begin
//
//    if Hkanji(@data1[ix2],0) = true then  begin
//
////20000512 >>
//  for ix1 := 0 to 148 do
//      for ix1 := 0 to ctKanaMax do
////20000512 <<
//      begin
//        sts := CompareStr(Copy(data1, ix2*2+1, 2), Copy(kana[ix1], 3, 2));
//        if sts = 0 then
//        begin
//          if Length(Trim(Copy(kana[ix1],1,2))) = 2 then
//            str := str + Copy(kana[ix1], 1, 2)
//          else
//            str := str + Copy(kana[ix1], 1, 1);
//          break;
//        end;
//      end;
//      if sts <> 0 then
//        str := str + Copy(data1, ix2*2+1, 2);
//
//    end else begin
//      str := str + data1[ix2];
//
//    end;
//
//  end;

//  for ix2 := 0 to leng - 1 do
//  begin

  ix2 := 1;
  while (ix2 <= leng) do begin

    if Hiskanji(data1[ix2]) = True then  begin
      for ix1 := 0 to ctKanaMax do  begin

        sts := CompareStr(Copy(data1, ix2, 2), Copy(kana[ix1], 3, 2));
        if sts = 0 then
        begin
          if Length(Trim(Copy(kana[ix1],1,2))) = 2 then
            str := str + Copy(kana[ix1], 1, 2)
          else
            str := str + Copy(kana[ix1], 1, 1);
          break;
        end;
      end;
      if sts <> 0 then
        str := str + Copy(data1, ix2, 2);

      ix2 := ix2+2;

    end else begin

      str := str + data1[ix2];
      Inc(ix2);

    end;

  end;

  result := str;

end;
*)
// 2009.08.10 Del End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

{*******************************************************************}
{ Module Name   : ﾒｯｾｰｼﾞ表示                                        }
{               : HMsgDisp                                          }
{ 引数          : 1 Integer ｴﾗｰﾚﾍﾞﾙ                                 }
{               :             0:ｴﾗｰ,1:警告,2:情報,3:確認,4:終了確認 }
{               : 2 String  ﾒｯｾｰｼﾞ文字列                            }
{               : 3 String  ﾌﾟﾛｸﾞﾗﾑID                               }
{               : 4 Integer ｽﾃｰﾀｽｺｰﾄﾞ                               }
{               : 5 Integer 追加ｽﾀｲﾙ                                }
{               :             0:無し,1:MB_OKCANCEL                  }
{               :             2:MB_ABORTRETRYIGNORE                 }
{               :             3:MB_YESNOCANCEL                      }
{               :             4:MB_YESNO,5:MB_RETRYCANCEL           }
{               :    ※MB_YESNOやMB_OKCANCELでの指定も可能です。    }
{ 戻り値        : 1 Integer MessageBoxが返すﾘﾀｰﾝｺｰﾄﾞを返します。    }
{ Programer     : ueo                                               }
{ Date          : 1999.08.06                                        }
{ Note          : ｴﾗｰﾒｯｾｰｼﾞを表示します。ｴﾗｰﾚﾍﾞﾙによりｱｲｺﾝﾏｰｸが     }
{               : 変わります。また、ｴﾗｰﾚﾍﾞﾙが｢0｣ｴﾗｰの場合はﾛｸﾞを    }
{               : 書き込みます。                                    }
{-------------------------------------------------------------------}
{ Update Note   : 2000.08.21  鹿野幸生                              }
{ Update Note   : 2000.09.12  鹿野幸生                              }
{ Update Note   : 2009.08.10  徳永　誠                              }
{               :  Log出力部削除　　　                              }
{*******************************************************************}
function HMsgDisp(iLvl:Integer;strMsg:String;strPgId:String;
                    nSts:Integer;fuAddStyle:Integer):Integer;
var
  fuStyle : Integer;
  szCaption : array[0..256] of Char;
//  szWrk : array[0..MAX_PATH] of Char;
  strCaption : string;
  strLogMsg : string;
//  strFile : string;
//  st : TSYSTEMTIME;
  hwndApl : HWND;
//  stLogData:    tagLogData;                                                    // 2000.08.16 追加 // 2009.08.10 Del
//  stLoginInf: tagLoginInf;                                                    // 2009.08.10 Del

begin
  //ﾒｯｾｰｼﾞ表示
  fuStyle := 0;
  ZeroMemory(@szCaption,sizeof(szCaption));
  if Application.MainForm.Caption <> '' then
    StrPCopy(szCaption, Application.MainForm.Caption)
  else
  begin
    if glMsgHandle <> 0 then
      GetWindowText(glMsgHandle,@szCaption,sizeof(szCaption))
    else
      GetWindowText(Application.Handle,@szCaption,sizeof(szCaption));
    end;

  case iLvl of
    //ｴﾗｰの場合
    0:
    begin
      //ﾛｸﾞ出力情報編集&ﾛｸﾞ出力                                                 2000.10.21 変更
//      GetLocalTime(st);
//      strLogMsg := format('%.4d/%.2d/%.2d,%.2d:%.2d:%.2d,',
//                          [st.wYear,st.wMonth,st.wDay,st.wHour,st.wMinute,st.wSecond]);
//      strLogMsg := strLogMsg + format('%-12s,%-50s,ST=%4d',[strPgId,strMsg,nSts]);
//      ZeroMemory(@szWrk,sizeof(szWrk));
//      GetCurrentDirectory(sizeof(szWrk)-1,szWrk);
//      strFile := StrPas(@szWrk) + '\' + ctLOGFILE;
//      HLogOut(strLogMsg,strFile);

      //ｴﾗｰﾒｯｾｰｼﾞ編集
      fuStyle := fuStyle or MB_ICONSTOP;
      strCaption := 'エラー発生 － ＜' + StrPas(szCaption) + '＞';
      strLogMsg := strMsg;
      strMsg := strPgId + 'にてエラーが発生しました' + #13#13+ strMsg;
      strMsg := strMsg + ' ST = ' + IntToStr(nSts);

      // ログの書き出し
//      if LoadCtlALPBU0002(1) = True then begin                                2001.02.26 変更
// 2009.08.10 Del Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
{
      if LoadCtlHLogAcs(1) = True then begin
         HInitProc.HGetLoginInf(stLoginInf);
         ZeroMemory(@stLogData, sizeof(stLogData));
         with stLogData do begin
           if gnActivLogDataNo = 0 then                                  // ログタイプNoをセット 2001.03.04 追加
             nLogNo := 1

             nLogelseNo := gnActivLogDataNo;
           szSysShu := 'E';                                               // ログデータ種別
           nSysTancd := stLoginInf.nTanCd;                                // ログデータ担当者コード
           StrLCopy(szSysTannm, stLoginInf.szTanNm, sizeof(szSysTannm));  // ログデータ担当者名
           nSysSeclvdt := 0;                                              // ログデータオペレーターデータ処理レベル
           nSysSeclvfu := stLoginInf.nTanLevel;                            // ログデータオペレーター機能処理レベル
           StrPLCopy(szSysPid, strPgId, sizeof(szSysPid));                // ログデータ対象プログラムＩＤ
           try
             StrPCopy(szSysSt, IntToStr(nSts));                           // ログデータステータス
           except
             else szSysSt[0] := #0;
           end;
           StrPLCopy(szSysPnm, Application.MainForm.Caption, sizeof(szSysProc));// ログデータプログラム名称
           StrPLCopy(szSysProc, Screen.ActiveForm.Caption, sizeof(szSysProc));  // ログデータ処理名称
           StrPLCopy(szSysMsg, strLogMsg, sizeof(szSysMsg));              // ログデータメッセージ内容
        end;
        pWrtSysLog(stLogData);
//        LoadCtlALPBU0002(0);                                                  2001.02.26 変更
        LoadCtlHLogAcs(0);
      end;
}
// 2009.08.10 Del End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
      //ｼｪｱﾁｪｯｸ解放
//      HEndSC;                                                                 // 2009.08.10 Del
      //ﾘｾｯﾄｽﾄｯﾌﾟ
//      ResetDB;                                                                // 2009.08.10 Del
//      StopDB;                                                                 // 2009.08.10 Del
      //ConnectEND
//      DisConnectDB;                                                           // 2009.08.10 Del
// 2009.10.10 Ins Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>      if LoadCtlALPBU0002(1) = True then begin                                2001.02.26 変更

      try
        if LoadLogoutputDll(1) = True then begin
          pOutput(strPgId, strMsg,  nSts);
          LoadLogoutputDll(0);
        end;
      except
        on e: Exception do
        begin
          ShowMessage('ログ出力実行に失敗しました' + #13 + e.Message);
          LoadLogoutputDll(0);
        end;
      end;

// 2009.10.10 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

      MessageBeep(MB_ICONHAND);
    end;
    //警告の場合
    1:
    begin
      fuStyle := fuStyle or MB_ICONEXCLAMATION;
      strCaption := '注意 － ＜' + StrPas(szCaption) + '＞';
      MessageBeep(MB_ICONEXCLAMATION);
    end;
    //情報の場合
    2:
    begin
      fuStyle := fuStyle or MB_ICONINFORMATION;
      strCaption := '情報 － ＜' + StrPas(szCaption) + '＞';
      MessageBeep(MB_ICONASTERISK);
    end;
    //確認
    3:
    begin
      fuStyle := fuStyle or MB_ICONQUESTION;
      strCaption := '確認 － ＜' + StrPas(szCaption) + '＞';
      MessageBeep(MB_ICONQUESTION);
    end;
    //終了確認
    4:
    begin
      fuStyle := fuStyle or MB_ICONQUESTION or MB_YESNO;
      strCaption := '確認 － ＜' + StrPas(szCaption) + '＞';
      strMsg  := '現在、編集中のデータが存在します' + #13 + #13;
      strMsg  := strMsg + '終了してもよろしいですか？';
      MessageBeep(MB_ICONQUESTION);
    end;
    //終了確認(保存優先)                                                        2000.09.12 追加
    ERR_LEVEL_SAVECONFIRM: begin
      fuStyle := fuStyle or MB_ICONQUESTION or MB_YESNOCANCEL;
      strCaption := '確認 － ＜' + StrPas(szCaption) + '＞';
      strMsg  := '現在、編集中のデータが存在します' + #13 + #13;
      strMsg  := strMsg + '登録してもよろしいですか？';
      MessageBeep(MB_ICONQUESTION);
    end;
    // エラー(×ボタン表示終了無し)                                             2000.08.21 追加
    ERR_LEVEL_STOPDISP: begin

      //ﾛｸﾞ出力情報編集&ﾛｸﾞ出力
{      GetLocalTime(st);
      strLogMsg := format('%.4d/%.2d/%.2d,%.2d:%.2d:%.2d,',
                          [st.wYear,st.wMonth,st.wDay,st.wHour,st.wMinute,st.wSecond]);
      strLogMsg := strLogMsg + format('%-12s,%-50s,ST=%4d',[strPgId,strMsg,nSts]);
      ZeroMemory(@szWrk,sizeof(szWrk));
      GetCurrentDirectory(sizeof(szWrk)-1,szWrk);
      strFile := StrPas(@szWrk) + '\' + ctLOGFILE;
      HLogOut(strLogMsg,strFile);
}
      //ｴﾗｰﾒｯｾｰｼﾞ編集
      fuStyle := fuStyle or MB_ICONSTOP;
      strCaption := 'エラー発生 － ＜' + StrPas(szCaption) + '＞';
      strMsg := strPgId + 'にてエラーが発生しました' + #13#13+ strMsg;
      strMsg := strMsg + ' ST = ' + IntToStr(nSts);

      // ログの書き出し
//      if LoadCtlALPBU0002(1) = True then begin                                2001.02.26 変更
// 2009.08.10 Del Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
{
      if LoadCtlHLogAcs(1) = True then begin
         HInitProc.HGetLoginInf(stLoginInf);
         ZeroMemory(@stLogData, sizeof(stLogData));
         with stLogData do begin
           if gnActivLogDataNo = 0 then                                  // ログタイプNoをセット 2001.03.04 追加
             nLogNo := 1
           else
             nLogNo := gnActivLogDataNo;
           szSysShu := 'E';                                               // ログデータ種別
           nSysTancd := stLoginInf.nTanCd;
           StrLCopy(szSysTannm, stLoginInf.szTanNm, sizeof(szSysTannm));  // ログデータ担当者名
           nSysSeclvdt := 0;                                              // ログデータオペレーターデータ処理レベル
           nSysSeclvfu := stLoginInf.nTanLevel;                            // ログデータオペレーター機能処理レベル
           StrPLCopy(szSysPid, strPgId, sizeof(szSysPid));                // ログデータ対象プログラムＩＤ
           try
             StrPCopy(szSysSt, IntToStr(nSts));                           // ログデータステータス
           except
             else szSysSt[0] := #0;
           end;
           StrPLCopy(szSysPnm, Application.MainForm.Caption, sizeof(szSysProc));// ログデータメッセージ内容
           StrPLCopy(szSysProc, Screen.ActiveForm.Caption, sizeof(szSysProc));  // ログデータ処理名称
           StrPLCopy(szSysMsg, strLogMsg, sizeof(szSysMsg));              // ログデータメッセージ内容
        end;
        pWrtSysLog(stLogData);
//        LoadCtlALPBU0002(0);                                                  2001.02.26 変更
        LoadCtlHLogAcs(0);
      end;
}
// 2009.08.10 Del End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
// 2009.10.10 Ins Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>      if LoadCtlALPBU0002(1) = True then begin                                2001.02.26 変更
      try
      if LoadLogoutputDll(1) = True then begin
        pOutput(strPgId, strMsg,  nSts);
        LoadLogoutputDll(0);
      end;
      except
        on e: Exception do
        begin
          ShowMessage('ログ出力実行に失敗しました' + #13 + e.Message);
          LoadLogoutputDll(0);
        end;
      end;

// 2009.10.10 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

      MessageBeep(MB_ICONHAND);
    end;
  end;

  //ｳｨﾝﾄﾞｳﾊﾝﾄﾞﾙ取得
  if glMsgHandle <> 0 then
    hwndApl := glMsgHandle
  else
  begin
// 20000218 >>
    //ｳｨﾝﾄﾞｳを検索し対象となるﾊﾝﾄﾞﾙを取得する。
    EnumWindows(@GetTopMostWindows,0);
    if glMsgHandle <> 0 then
      hwndApl := glMsgHandle
    else
    begin
// 20000226 >>
      //全てのﾒｯｾｰｼﾞ処理後にｳｨﾝﾄﾞｳを検索し対象となるﾊﾝﾄﾞﾙを取得する。
      Application.ProcessMessages;
      EnumWindows(@GetTopMostWindows,0);
      if glMsgHandle <> 0 then
        hwndApl := glMsgHandle
      else
// 20000226 <<
        hwndApl := Application.Handle;
    end;
// 20000218 <<
  end;

//  Result := MessageBox(hwndApl,PChar(strMsg),
//                       PChar(strCaption),fuStyle or fuAddStyle);
  Result := HMessageBox(hwndApl,PChar(strMsg),
                       PChar(strCaption),fuStyle or fuAddStyle);
  glMsgHandle := 0;
end;

{*******************************************************************}
{ Module Name   : ﾒｯｾｰｼﾞ表示                                        }
{               : HMsgDisp2                                         }
{ 引数          : 1 Integer ｴﾗｰﾚﾍﾞﾙ                                 }
{               :             0:ｴﾗｰ,1:警告,2:情報,3:確認,4:終了確認 }
{               : 2 String  ﾒｯｾｰｼﾞ文字列                            }
{               : 3 String  ﾌﾟﾛｸﾞﾗﾑID                               }
{               : 4 Integer ｽﾃｰﾀｽｺｰﾄﾞ                               }
{	             : 5 Integer 追加ｽﾀｲﾙ                                }
{               :             0:無し,1:MB_OKCANCEL                  }
{               :             2:MB_ABORTRETRYIGNORE	3:MB_YESNOCANCEL}
{               :             4:MB_YESNO,5:MB_RETRYCANCEL           }
{               :    ※MB_YESNOやMB_OKCANCELでの指定も可能です。    }
{ 戻り値        : 1 Integer MessageBoxが返すﾘﾀｰﾝｺｰﾄﾞを返します。    }
{ Programer     : ueo                                               }
{ Date          : 1999.08.06                                        }
{ Note          : ｴﾗｰﾒｯｾｰｼﾞを表示します。ｴﾗｰﾚﾍﾞﾙによりｱｲｺﾝﾏｰｸが     }
{               : 変わります。また、ｴﾗｰﾚﾍﾞﾙが｢0｣ｴﾗｰの場合はﾛｸﾞを    }
{               : 書き込みます。                                    }
{-------------------------------------------------------------------}
{ Update Note   :                                                   }
{*******************************************************************}
function HMsgDisp2(AplHandle:HWND;iLvl:Integer;strMsg:String;
            strPgId:String;nSts:Integer;fuAddStyle:Integer):Integer;
begin
  glMsgHandle := AplHandle;
  Result := HMsgDisp(iLvl,strMsg,strPgId,nSts,fuAddStyle);
  glMsgHandle := 0;
end;

//*******************************************************************//
// Module Name   : メッセージ表示(エラー時ログ付き)                  //
//               : HDspMsg                                           //
// 引数          : 1 メッセージレベル(0:ｴﾗｰ,1:警告,2:情報,           //
//               :                 3:確認,4:終了確認)                //
//               : 2 ユニットID                                      //
//               : 3 画面名称                                        //
//               : 4 処理名称                                        //
//               : 5 オペレーション内容                              //
//               : 6 メッセージ文字列                                //
//               : 7 ステータス                                      //
//               : 8 マスタオブジェクト                              //
//               : 9 追加スタイル                                    //
//               :             0:無し,1:MB_OKCANCEL                  //
//               :             2:MB_ABORTRETRYIGNORE                 //
//               :             3:MB_YESNOCANCEL                      //
//               :             4:MB_YESNO,5:MB_RETRYCANCEL           //
//               :    ※MB_YESNOやMB_OKCANCELでの指定可              //
// 戻り値        : MessageBoxの戻り値                                //
// Programer     : 鹿野　幸生                                        //
// Date          : 2000.08.16                                        //
//-------------------------------------------------------------------//
// Update Note   : 2001.03.19 鹿野　幸生                             //
//               : 2001.04.12 鹿野　幸生                             //
// Update Note   : 2009.08.10  徳永　誠                              //
//               :  Log出力部削除　　　                              //
//*******************************************************************//
function HDspMsg(iMsgLvl:Integer; istrUntId:String; istrPnm:String;
                   istrProcNm: string; istrOperate: string; istrMsg:String;
                    inSts:Integer; iMstCompo:TObject; inAddStyle:Integer): Integer;
var
  uStyle:     UINT;
  uIcon:      UINT;
  szCaption:  array[0..256] of Char;
  strMsg:     string;
  strCaption: string;
  hwndApl:    HWND;
//  stLogData:    tagLogData;                                                     // 2000.08.16 追加  // 2009.08.10 Del
  stLoginInf: tagLogininf;


begin
  result := 0;                                                                  // 2009.08.10 Ins

  // キャプション設定
  uStyle := 0;

  ZeroMemory(@szCaption,sizeof(szCaption));

  // キャプションの設定                                                         2001.04.12 変更
  if Application.MainForm <> nil then begin
    if Application.MainForm.Caption <> '' then begin
      StrPCopy(szCaption, Application.MainForm.Caption)
    end else begin
      if glMsgHandle <> 0 then
        GetWindowText(glMsgHandle,@szCaption,sizeof(szCaption))
      else
        GetWindowText(Application.Handle,@szCaption,sizeof(szCaption));
    end;
  end else begin
    if Screen.ActiveForm <> nil then begin
      StrPCopy(szCaption, Screen.ActiveForm.Caption);
    end else begin
      StrPCopy(szCaption, 'アプリケーション');
    end;
  end;

  // メッセージレベルによる処理分け
  uIcon := MB_ICONHAND;
  case iMsgLvl of
    0: begin                                                         //エラーの場合
      HInitProc.HGetLoginInf(stLoginInf);                                               // ログデータ担当者コード
      // ログ書き出しを強制的に有り設定
      // エラーメッセージ編集
      uStyle := inAddStyle or MB_ICONSTOP;
      uIcon := MB_ICONHAND;
      strCaption := 'エラー発生 － ＜' + StrPas(szCaption) + '＞';
      strMsg := StrPas(stLoginInf.szPgExeId) + '(' + istrUntId + ') ' + 'にてエラーが発生しました' + #13#13+ istrMsg;
      strMsg := strMsg + ' ST = ' + IntToStr(inSts);

    end;
    1: begin                                                         // 警告の場合
      uStyle := inAddStyle or MB_ICONEXCLAMATION;
      uIcon := MB_ICONEXCLAMATION;
      strCaption := '注意 － ＜' + StrPas(szCaption) + '＞';
      strMsg := istrMsg;
    end;
    2: begin                                                         // 情報の場合
      uStyle := inAddStyle or MB_ICONINFORMATION;
      uIcon := MB_ICONASTERISK;
      strCaption := '情報 － ＜' + StrPas(szCaption) + '＞';
      strMsg := istrMsg;
    end;
    3: begin                                                         // 確認
      uStyle := inAddStyle or MB_ICONQUESTION;
      uIcon := MB_ICONQUESTION;
      strCaption := '確認 － ＜' + StrPas(szCaption) + '＞';
      strMsg := istrMsg;
    end;
    4: begin                                                         //終了確認
      uStyle := inAddStyle or MB_ICONQUESTION or MB_YESNO;
      uIcon := MB_ICONQUESTION;
      strCaption := '確認 － ＜' + StrPas(szCaption) + '＞';
      strMsg  := '現在、編集中のデータが存在します' + #13 + #13;
      strMsg  := strMsg + '終了してもよろしいですか？';
    end;
    //終了確認(保存優先)
    ERR_LEVEL_SAVECONFIRM: begin
      uStyle := uStyle or MB_ICONQUESTION or MB_YESNOCANCEL;
      uIcon := MB_ICONQUESTION;
      strCaption := '確認 － ＜' + StrPas(szCaption) + '＞';
      strMsg  := '現在、編集中のデータが存在します' + #13 + #13;
      strMsg  := strMsg + '登録してもよろしいですか？';
    end;
    // エラー(×ボタン表示終了無し)
    ERR_LEVEL_STOPDISP: begin
      HInitProc.HGetLoginInf(stLoginInf);                            // ログデータ担当者コード
      uStyle := uStyle or MB_ICONSTOP;
      uIcon := MB_ICONHAND;
      strCaption := 'エラー発生 － ＜' + StrPas(szCaption) + '＞';
      strMsg := StrPas(stLoginInf.szPgExeId) + '(' + istrUntId + ') ' + 'にてエラーが発生しました' + #13#13+ istrMsg;
      strMsg := strMsg + ' ST = ' + IntToStr(inSts);
    end;
    // ダイアログ表示無し(ログのみ書き込み)                                     2001.04.12 追加
    ERR_LEVEL_NODISP: begin
      strCaption := 'エラー発生 － ＜' + StrPas(szCaption) + '＞';
      strMsg := StrPas(stLoginInf.szPgExeId) + '(' + istrUntId + ') ' + 'にてエラーが発生しました' + #13#13+ istrMsg;
      strMsg := strMsg + ' ST = ' + IntToStr(inSts);
    end;

  end;

  // ウインドハンドル取得                                                       2001.03.19 変更
//  if glMsgHandle <> 0 then begin
//    hwndApl := glMsgHandle
//  end else begin
//    // ウインドを検索し対象となるﾊﾝﾄﾞﾙを取得する。
//    EnumWindows(@GetTopMostWindows,0);
//    if glMsgHandle <> 0 then begin
//      hwndApl := glMsgHandle
//    end else begin
//      //全てのﾒｯｾｰｼﾞ処理後にｳｨﾝﾄﾞｳを検索し対象となるﾊﾝﾄﾞﾙを取得する。
//      Application.ProcessMessages;
//      EnumWindows(@GetTopMostWindows, 0);
//      if glMsgHandle <> 0 then
//        hwndApl := glMsgHandle
//      else
//        hwndApl := Application.Handle;
//    end;
//  end;
  hwndApl := 0;
  if Screen.ActiveForm <> nil then begin
    hwndApl := Screen.ActiveForm.Handle;
  end;

  // ログの書き出し
  if (iMsgLvl = 0) or
       (iMsgLvl = ERR_LEVEL_STOPDISP) or
          (iMsgLvl = ERR_LEVEL_NODISP) then begin

//    if LoadCtlALPBU0002(1) = True then begin                                  2001.02.26 変更
// 2009.08.10 Del Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
{
    if LoadCtlHLogAcs(1) = True then begin
      ZeroMemory(@stLogData, sizeof(stLogData));
      with stLogData do begin
        if gnActivLogDataNo = 0 then                                   // ログタイプNoをセット 2001.03.04 追加
          nLogNo := 1
        else
          nLogNo := gnActivLogDataNo;
        szSysShu := 'E';                                               // ログデータ種別
        nSysTancd := stLoginInf.nTanCd;
        StrLCopy(szSysTannm, stLoginInf.szTanNm, sizeof(szSysTannm));  // ログデータ担当者名
        nSysSeclvdt := 0;                                              // ログデータオペレーターデータ処理レベル
        nSysSeclvfu := stLoginInf.nTanLevel;                           // ログデータオペレーター機能処理レベル
        StrCopy(szSysPid, stLoginInf.szPgExeId);                       // ログデータ対象プログラムＩＤ
        try
          StrPCopy(szSysSt, IntToStr(inSts));                          // ログデータステータス
        except
          szSysSt[0] := #0;
        end;
        StrPCopy(szSysPnm, '');                                                 // 2001.04.12 変更
        if (istrPnm = '-1') then begin                                 // ログデータ画面名称
          // メインフォーム
          if Application.MainForm <> nil then
            StrPLCopy(szSysPnm, Application.MainForm.Caption, sizeof(szSysPnm));
        end else  if (istrPnm = '0') then begin
          // アクティブフォーム
          if Screen.ActiveForm <> nil then
            StrPLCopy(szSysPnm, Screen.ActiveForm.Caption, sizeof(szSysPnm));
        end else
          // 引数文字列
          StrPLCopy(szSysPnm, istrPnm, sizeof(szSysPnm));
        StrPLCopy(szSysProc, istrProcNm, sizeof(szSysProc));           // ログデータ処理名称
        StrPLCopy(szSysOpe, istrOperate, sizeof(szSysOpe));            // ログデータオペレーション
        StrPLCopy(szSysMsg, istrMsg, sizeof(szSysMsg));                // ログデータメッセージ内容
        if iMstCompo <> nil then begin
          with iMstCompo as TDBFileAcs do begin
            StrPLCopy(szSysMstid, ExtractFileName(FilePath), sizeof(szSysMstid)); // ログデータ対象マスタＩＤ
            CopyMemory(@szSysBuff, DatBuf, sizeof(szSysBuff));         // ログデータ　データ／キーバッファ内容
            if szSysST = '0'  then
              StrPLCopy(szSysSt, IntToStr(St), sizeof(szSysSt));       // ログデータステータス
            nSysKeyno := KeyNo;                                        // ログデータキーナンバー
          end;
        end;
      end;
      pWrtSysLog(stLogData);
//      LoadCtlALPBU0002(0);                                                    2001.02.26 変更
      LoadCtlHLogAcs(0);
    end;
}
// 2009.08.10 Del End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
// 2009.10.10 Ins Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    try
      if LoadLogoutputDll(1) = True then begin
        pOutput(istrUntId, strMsg,  inSts);
        LoadLogoutputDll(0);
      end;
    except
      on e: Exception do
      begin
        ShowMessage('ログ出力実行に失敗しました' + #13 + e.Message);
        LoadLogoutputDll(0);
      end;
    end;
// 2009.10.10 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
  end;

  // メッセージの表示                                                           2001.04.12 変更
  if iMsgLvl <> ERR_LEVEL_NODISP then begin
    MessageBeep(uIcon);
//    Result := MessageBox(hwndApl, PChar(strMsg), PChar(strCaption), uStyle);
    Result := HMessageBox(hwndApl, PChar(strMsg), PChar(strCaption), uStyle);
  end;

  if iMsgLvl = 0 then begin
    // シェアチェック解放
//    HEndSC;                                                                   // 2009.08.10 Del
    // リセットストップ
//    ResetDB;                                                                  // 2009.08.10 Del
//    StopDB;                                                                   // 2009.08.10 Del
    // ConnectEND
//    DisConnectDB;                                                             // 2009.08.10 Del
  end;

  glMsgHandle := 0;

end;

//*******************************************************************//
// Module Name   : メッセージ表示(エラー時ログ付き)                  //
//               : HDspMsg                                           //
// 引数          : 1 ログ書込み用構造体                              //
//               : 2 ログ連続書込みフラグ(0:連続書込み無しorOFF,1:有り)//
// 戻り値        : 書込み結果                                        //
// Programer     : 鹿野　幸生                                        //
// Date          : 2000.08.16                                        //
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
{
function HWrtSysLog(istLogData: tagLogData; nAddOperand: integer = 0): integer;
begin

  Result := 0;

  // ログの書き出し(構造体が存在している場合)
  if @istLogData <> nil then begin
    if LoadCtlALPBU0002(1) = True then begin
      Result := pWrtSysLog(istLogData);
      if nAddOperand = 0 then begin
        LoadCtlALPBU0002(0);
      end;
    end;
  end else begin
    // DLLの解放(構造体が存在していない場合)
    if nAddOperand = 0 then begin
      LoadCtlALPBU0002(0);
    end;
  end;


end;
}
// 2009.08.10 Del Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
(*
{*******************************************************************}
{ Module Name   : ﾛｸﾞ出力                                           }
{               : HLogOut                                           }
{ 引数          : 1 String  出力内容                                }
{               : 2 String  出力ﾌｧｲﾙ                                }
{ 戻り値        : 1 無し                                            }
{ Programer     : ueo                                               }
{ Date          : 1999.08.06                                        }
{ Note          : ﾛｸﾞを出力します。                                 }
{-------------------------------------------------------------------}
{ Update Note   :                                                   }
{*******************************************************************}
procedure HLogOut(s:String;fname:String);
var
  hf : HFILE;
begin
//  hf := _lopen(PChar(fname), OF_WRITE);       // 2009.08.10 Del
  hf := _lopen(PAnsiChar(fname), OF_WRITE);     // 2009.08.10 Ins
  if hf = HFILE_ERROR then
//    hf := _lcreat(PChar(fname), 0);           // 2009.08.10 Del
    hf := _lcreat(PAnsiChar(fname), 0);         // 2009.08.10 Ins
  if hf = HFILE_ERROR then Exit;
  _llseek(hf, 0, 2);
//  _lwrite(hf, PChar(s), lstrlen(PChar(s)));   // 2009.08.10 Del
  _lwrite(hf, PAnsiChar(s), lstrlen(PChar(s))); // 2009.08.10 Ins
  _lwrite(hf, #13, 1);
  _lclose(hf);
end;
*)
// 2009.08.10 Del End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

{*******************************************************************}
{ Module Name   : ｶﾝﾏ編集                                           }
{               : HKanma                                            }
{ 引数          : 1 String  数値文字列                              }
{ 戻り値        : 1 String  編集後文字列                            }
{ Programer     : ueo                                               }
{ Date          : 1999.08.06                                        }
{ Note          : ｶﾝﾏ編集をします。整数、実数対応版                 }
{-------------------------------------------------------------------}
{ Update Note   :                                                   }
{*******************************************************************}
function HKanma( Str:String):String;
var
  i:Integer;
  n:Integer;
begin
  n := Pos('.', Str);
  if n = 0 then
    n := Length(Str)
  else
    Dec(n);
  if n > 3 then
  begin
    i := 1;
    while (n - i > 0) and (Str[n - i] <> '-') do
    begin
      if (i mod 3 = 0) then
      Insert(',', Str, n - (i - 1));
      Inc(i);
    end;
  end;
  Result := Str;
end;

// 2009.08.10 Del Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
(*
{*******************************************************************}
{ Module Name   : 半角全角変換                                      }
{               : HHanToZen2                                        }
{ 引数          : 1 String  変換する文字列                          }
{ 戻り値        : 1 Integer 変換する文字数                          }
{ Programer     : ueo                                               }
{ Date          : 1999.08.06                                        }
{ Note          : 文字列中の半角文字を全角文字に変換します。        }
{               : ・小文字は大文字にして変換します。                }
{               : ・何もｾｯﾄされていない場合は全角ｽﾍﾟｰｽを返します。  }
{-------------------------------------------------------------------}
{ Update Note   : 2002.07.25  鹿野　幸生                            }
{*******************************************************************}
function HHanToZen2(data1: String; leng: SmallInt):String;
const
//  kana: array[0..180] of String[5]                                            2002.07.25 変更
  kana: array[0..181] of String[5]
    =  ('ｱ ア','ｲ イ','ｳ ウ','ｴ エ','ｵ オ',
        'ｶ カ','ｷ キ','ｸ ク','ｹ ケ','ｺ コ',
        'ｻ サ','ｼ シ','ｽ ス','ｾ セ','ｿ ソ',
        'ﾀ タ','ﾁ チ','ﾂ ツ','ﾃ テ','ﾄ ト',
        'ﾅ ナ','ﾆ ニ','ﾇ ヌ','ﾈ ネ','ﾉ ノ',
        'ﾊ ハ','ﾋ ヒ','ﾌ フ','ﾍ ヘ','ﾎ ホ',
        'ﾏ マ','ﾐ ミ','ﾑ ム','ﾒ メ','ﾓ モ',
        'ﾔ ヤ','ﾕ ユ','ﾖ ヨ','ﾗ ラ','ﾘ リ',
        'ﾙ ル','ﾚ レ','ﾛ ロ','ﾜ ワ','ﾝ ン',
        'ｦ ヲ','ｨ イ','ｪ エ','ｯ ツ','ｬ ヤ',
        'ｭ ユ','ｮ ヨ','ｶﾞガ','ｷﾞギ','ｸﾞグ',
        'ｹﾞゲ','ｺﾞゴ','ｻﾞザ','ｼﾞジ','ｽﾞズ',
        'ｾﾞゼ','ｿﾞゾ','ﾀﾞダ','ﾁﾞヂ','ﾂﾞヅ',
        'ﾃﾞデ','ﾄﾞド','ﾊﾞバ','ﾋﾞビ','ﾌﾞブ',
        'ﾍﾞベ','ﾎﾞボ','ﾊﾟパ','ﾋﾟピ','ﾌﾟプ',
        'ﾍﾟペ','ﾎﾟポ','ｳﾞヴ','A Ａ','B Ｂ',
        'C Ｃ','D Ｄ','E Ｅ','F Ｆ','G Ｇ',
        'H Ｈ','I Ｉ','J Ｊ','K Ｋ','L Ｌ',
        'M Ｍ','N Ｎ','O Ｏ','P Ｐ','Q Ｑ',
        'R Ｒ','S Ｓ','T Ｔ','U Ｕ','V Ｖ',
        'W Ｗ','X Ｘ','Y Ｙ','Z Ｚ','a Ａ',
        'b Ｂ','c Ｃ','d Ｄ','e Ｅ','f Ｆ',
        'g Ｇ','h Ｈ','i Ｉ','j Ｊ','k Ｋ',
        'l Ｌ','m Ｍ','n Ｎ','o Ｏ','p Ｐ',
        'q Ｑ','r Ｒ','s Ｓ','t Ｔ','u Ｕ',
        'v Ｖ','w Ｗ','x Ｘ','y Ｙ','z Ｚ',
        '- －','/ ／','･ ・','1 １','2 ２',
        '3 ３','4 ４','5 ５','6 ６','7 ７',
        '8 ８','9 ９','0 ０','  　','ｰ －',
        '( （',') ）','ｧ ア','ｩ ウ',''' ’',
        '! ！','" ”','# ＃','$ ＄','% ％',
        '& ＆','- －','+ ＋','= ＝','* ＊',
        '\ ￥','| ｜','^ ＾','~ ～','_ ＿',
        '? ？','< ＜','> ＞','{ ｛','} ｝',
        '[ ［','] ］',', ，','. ．','@ ＠',
        '; ；',': ：','､ 、','｡ 。','｢ 「',
//        '｣ 」');                                                             2002.07.25 変更
        '｣ 」', 'ｫ オ');
var
  ix1, ix2, cnt : SmallInt;
  work, str : array[0..255] of Char;
begin
  StrPCopy(work,data1);
  FillChar(str,sizeof(str),#0);
  str := '';
  cnt := 0;

  for ix1 := 0 to leng - 1 do
  begin
    if work[ix1] = #0 then
      break;
    // 2ﾊﾞｲﾄ文字はそのままｺﾋﾟｰ
    if StrByteType(work,ix1) <> mbSingleByte then
    begin
      if StrByteType(work,ix1) = mbLeadByte then
      begin
//        StrLCopy(@str[cnt*2],@work[ix1],2);                                   // 2009.08.10 Del
        StrLCopy(PAnsiChar(@str[cnt*2]),PAnsiChar(@work[ix1]),2);               // 2009.08.10 Ins
        inc(cnt);
      end;
    end else
    begin
//      for ix2 := 0 to 180 do                                                  2002.07.25 変更
      for ix2 := 0 to 181 do
      begin
        if work[ix1] = Copy(kana[ix2], 1, 1) then
        begin
          if (work[ix1+1] = 'ﾞ') or (work[ix1+1] = 'ﾟ') then
          begin
            if work[ix1+1] = Copy(kana[ix2], 2, 1) then
            begin
              StrPCopy(@str[cnt*2],Copy(kana[ix2], 3, 2));
              inc(cnt);
              break;
            end;
          end else
          begin
            StrPCopy(@str[cnt*2],Copy(kana[ix2], 3, 2));
            inc(cnt);
            break;
          end;
        end;
      end;
      //ﾃｰﾌﾞﾙにない半角ﾃﾞｰﾀは全角空白を印字
//      if ix2 > 180 then                                                       2002.07.25 変更
      if ix2 > 181 then
      begin
        if (work[ix1] = 'ﾞ') or (work[ix1] = 'ﾟ') then
        else
        begin
          StrPCopy(@str[cnt*2],'　');
          inc(cnt);
        end;
      end;
    end;
  end;

  str[cnt*2] := #0;

  result := StrPas(str);
end;
*)
// 2009.08.10 Del End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

{*******************************************************************}
{ Module Name   : 各種INIﾌｧｲﾙﾊﾟｽ取得                                }
{               : HIniPathMake                                      }
{ 引数          : 1 String   INIﾌｧｲﾙ名称                            }
{ 戻り値        : 1 String   編集後文字列                           }
{ Programer     : ueo                                               }
{ Date          : 1999.09.25                                        }
{ Note          : SFPATH.INIﾌｧｲﾙよりそれぞれのINIﾌｧｲﾙﾊﾟｽを取得します}
{               : 取得した文字列が'LAN'or'LOCAL'の場合はさらにLANの }
{               : ﾊﾟｽ及びLOCALのﾊﾟｽを取得する。                     }
{-------------------------------------------------------------------}
{ Update Note   : 2001.02.20  鹿野　幸生                            }
{*******************************************************************}
function HIniPathMake(strIFile:String):String;
var
//  ix         : Integer;
//  szRetPath  : Array[0..MAX_PATH] of Char;
  strWkName  : String;
  strIName   : String;
//  cDrive     : Char;
//  strDirPart : String;
//  strFilePart: String;
begin

  Result := '';

  //INIﾌｧｲﾙ名称から拡張子、ﾄﾞﾗｲﾌﾞﾊﾟｽをはずす。                                  2001.02.20 変更
//  strIName := ChangeFileExt(ExtractFileName(strIFile),'');
  strWkName := strIFile;
  strIName := ChangeFileExt(ExtractFileName(strWkName),'');


{                                                                               2001.02.20 変更
  //SFPATH.INIより情報取得
  ZeroMemory(@szRetPath,sizeof(szRetPath));
  for ix:=0 to 100 do  //一発で取得できない可能性があるのでﾙｰﾌﾟさせる
  begin
    GetPrivateProfileString('INIPATH',PChar(strIName),'',@szRetPath, sizeof(szRetPath),ctSFPATHINI);
    if strlen(szRetPath) <> 0 then
      break;
  end;

  if strlen(szRetPath) = 0 then
  begin
//20000617 >>
//  HMsgDisp(0,'「SFPATH.INI」が見つかりません。','HFSLLIB',-1,0);
//  Exit;
    szRetPath := 'LOCAL';
//20000617 <<
  end;
  if CompareText(szRetPath,'LAN') = 0 then
  begin
    for ix:=0 to 100 do
    begin
      GetPrivateProfileString('INIPATH','LAN','',@szRetPath, sizeof(szRetPath), ctSFPATHINI);
      if strlen(szRetPath) <> 0 then
        break;
    end;
    if strlen(szRetPath) = 0 then
    begin
      HDspMsg(ERR_LEVEL_STOP, ctUNITID, ctMAINFORM_TITLE, 'INI取得処理', ctOPE_OPEN,
               ctSFPATHINI+'に｢LAN｣が設定されていないか、オープン出来ません', -1, nil, 0);
      Exit;
    end;
  end;
  if CompareText(szRetPath,'LOCAL') = 0 then
  begin
    for ix:=0 to 100 do
    begin
      GetPrivateProfileString('INIPATH','LOCAL','',@szRetPath, sizeof(szRetPath), ctSFPATHINI);
      if strlen(szRetPath) <> 0 then
        break;
    end;
    if strlen(szRetPath) = 0 then
    begin
      HDspMsg(ERR_LEVEL_STOP, ctUNITID, ctMAINFORM_TITLE, 'INI取得処理', ctOPE_OPEN,
               ctSFPATHINI+'に｢LOCAL｣が設定されていないか、オープン出来ません', -1, nil, 0);
      Exit;
    end;
  end;

  //取得したﾊﾟｽの確認
  cDrive := CHR(0);
  strDirPart := '';
  strFilePart:= '';
  ProcessPath(szRetPath,cDrive,strDirPart,strFilePart);
  if strFilePart = '' then
  begin
    if szRetPath[strlen(szRetPath)-1] <> '\' then
      strcat(szRetPath,'\');
    strcat(szRetPath,PChar(ExtractFileName(strIFile)));
  end;

  //拡張子が無い場合は｢.INI｣をつける
  if ExtractFileExt(szRetPath) = '' then
    strcat(szRetPath,'.INI');
}
  // 内部でHGetIniPathを呼ぶ
  if HGetIniPath(strIName) <> 0 then begin

    HDspMsg(ERR_LEVEL_STOP, ctUNITID, ctMAINFORM_TITLE, 'INI取得処理', ctOPE_OPEN,
               ctSFPATHINI+'の設定に誤りがあるか、オープン出来ません', -1, nil, 0);
    Result := '';

  end else begin

    Result := strIName;

  end;

end;

// 2009.08.10 Del Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
(*
{*******************************************************************}
{ Module Name   : 半角ｶﾀｶﾅ⇔全角ひらがな変換                        }
{               : Hsc_kanaf                                         }
{ 引数          : 1 Integer 0:半角ｶﾀｶﾅ⇒全角ひらがなへ変換          }
{               :           1:全角ひらがな⇒半角ｶﾀｶﾅへ変換          }
{               : 2 String  変換させたい文字列(半角or全角)          }
{ 戻り値        : 1 strin   変換後の文字(失敗時は空文字)            }
{ Programer     : ueo                                               }
{ Date          : 1999.08.06                                        }
{ Note          : 半角ｶﾀｶﾅを全角ひらがなへ、全角ひらがなを半角ｶﾀｶﾅに}
{               : 変換します。                                      }
{               : 濁音、ちっちゃい文字に対応                        }
{-------------------------------------------------------------------}
{ Update Note   :                                                   }
{*******************************************************************}
function Hsc_kanaf2(kbn: Integer; data1: String):String;
const
//  ctKanaMax = 179;
kana2: array[0..119] of String[6]
    =  ('ｱ  あ','ｲ  い','ｳ  う','ｴ  え','ｵ  お',
        'ｧ  ぁ','ｨ  ぃ','ｩ  ぅ','ｪ  ぇ','ｫ  ぉ',
        'ｶ  か','ｷ  き','ｸ  く','ｹ  け','ｺ  こ',
        'ｶﾞ が','ｷﾞ ぎ','ｸﾞ ぐ','ｹﾞ げ','ｺﾞ ご',
        'ｻ  さ','ｼ  し','ｽ  す','ｾ  せ','ｿ  そ',
        'ｻﾞ ざ','ｼﾞ じ','ｽﾞ ず','ｾﾞ ぜ','ｿﾞ ぞ',
        'ﾀ  た','ﾁ  ち','ﾂ  つ','ﾃ  て','ﾄ  と',
        'ﾀﾞ だ','ﾁﾞ ぢ','ﾂﾞ づ','ﾃﾞ で','ﾄﾞ ど',
        'ﾅ  な','ﾆ  に','ﾇ  ぬ','ﾈ  ね','ﾉ  の',
        'ﾊ  は','ﾋ  ひ','ﾌ  ふ','ﾍ  へ','ﾎ  ほ',
        'ﾊﾞ ば','ﾋﾞ び','ﾌﾞ ぶ','ﾍﾞ べ','ﾎﾞ ぼ',
        'ﾊﾟ ぱ','ﾋﾟ ぴ','ﾌﾟ ぷ','ﾍﾟ ぺ','ﾎﾟ ぽ',
        'ﾏ  ま','ﾐ  み','ﾑ  む','ﾒ  め','ﾓ  も',
        'ﾔ  や','ﾕ  ゆ','ﾖ  よ','ﾗ  ら','ﾘ  り',
        'ﾙ  る','ﾚ  れ','ﾛ  ろ','ﾜ  わ','ﾝ  ん',
        'ｦ  を','A  Ａ','B  Ｂ','C  Ｃ','D  Ｄ',
        'E  Ｅ','F  Ｆ','G  Ｇ','H  Ｈ','I  Ｉ',
        'J  Ｊ','K  Ｋ','L  Ｌ','M  Ｍ','N  Ｎ',
        'O  Ｏ','P  Ｐ','Q  Ｑ','R  Ｒ','S  Ｓ',
        'T  Ｔ','U  Ｕ','V  Ｖ','W  Ｗ','X  Ｘ',
        'Y  Ｙ','Z  Ｚ','0  ０','1  １','2  ２',
        '3  ３','4  ４','5  ５','6  ６','7  ７',
        '8  ８','9  ９','ﾞ  ゛','   　','ｬ  ゃ',
        'ｭ  ゅ','ｮ  ょ','ｯ  っ','ｰ  ー','-  －');
(*
//20000512 >>
        '､  、','｡  。',',  ，','.  ．',':  ：',
        '_  ＿','･  ・','?  ？','>  ＞','<  ＜',
        '｢  「','｣  」','{  ｛','}  ｝','*  ＊',
        ':  ：','+  ＋',';  ；','@  ＠','\  ￥',
        '|  ｜','^  ＾','=  ＝','(  （',')  ）',
        '&  ＆','%  ％','$  ＄','#  ＃','"  ”',
        '!  ！','a  ａ','b  ｂ','c  ｃ','d  ｄ',
        'e  ｅ','f  ｆ','g  ｇ','h  ｈ','i  ｉ',
        'j  ｊ','k  ｋ','l  ｌ','m  ｍ','n  ｎ',
        'o  ｏ','p  ｐ','q  ｑ','r  ｒ','s  ｓ',
        't  ｔ','u  ｕ','v  ｖ','w  ｗ','x  ｘ',
        'y  ｙ','z  ｚ','   　','   　','   　');
//20000512 <<
*)
(*
var
  i, j, len, sts: Integer;
  str: String;
begin

  str := '';
  len := Length(data1);

//  for j := 0 to len - 1 do
  j := 0;
  while j < len do
  begin
    if kbn = 0 then
    begin
      for i := 0 to 119 do
      begin
        //既に全角文字の場合はそのままコピー
        if Hiskanji(data1[j+1]) = TRUE then
        begin
          str := str + Copy(data1,j+1,2);
          Inc(j);
          break;
        end;
        //濁音付のｶﾅは特殊変換
        if (data1[j+2] = 'ﾞ') or (data1[j+2] = 'ﾟ') then
        begin
          sts := CompareText(Copy(data1, j+1, 2), Copy(kana2[i], 1, 2));
          if sts = 0 then
          begin
            str := str + Copy(kana2[i], 4, 2);
            Inc(j);
            break;
          end;
        //ﾉｰﾏﾙ条件の変換処理
        end else
        begin
          sts := CompareText(Copy(data1[j + 1], 1, 1), Copy(kana2[i], 1, 1));
          if sts = 0 then
          begin
            str := str + Copy(kana2[i], 4, 2);
            break;
          end;
        end;
//20000512 >>
        //ﾃｰﾌﾞﾙに該当するﾃﾞｰﾀが無い場合は自動変換
        if i = 119 then
        begin
          str := str + HHanToZen2(Copy(data1[j+1],1,1),1);
          break;
        end;
//20000512 <<
      end;
    end
    else begin
      for i := 0 to 119 do
      begin
        sts := CompareStr(Copy(data1, j+1, 2), Copy(kana2[i], 4, 2));
        if sts = 0 then
        begin
          if Copy(kana2[i],2,1) = ' ' then
            str := str + Copy(kana2[i], 1, 1)
          else
            str := str + Copy(kana2[i], 1, 2);
          Inc(j);
          break;
        end;
        //ﾃｰﾌﾞﾙに該当するﾃﾞｰﾀが無い場合は自動変換
        if i = 119 then
        begin
//          str := str + HZenToHan(Copy(data1,j+1,2),2);      // 2009.08.10 Del
          Inc(j);
          break;
        end;
      end;
    end;
    Inc(j);
  end;
  result := str;
end;
*)
// 2009.08.10 Del End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

// 20000218 >>
{*******************************************************************}
{ Module Name   : EnumWindowsのコールバック関数                     }
{               : GetTopMostWindows                                 }
{ 引数          : 1 HWND     検索したｳｨﾝﾄﾞｳﾊﾝﾄﾞﾙ                    }
{               : 2 Pointer  EnumWIndowsから渡されるパラメータ      }
{ 戻り値        : 1 Boolean  FALSE:再取得する, TRUE:もう取得しない  }
{ Programer     : ueo                                               }
{ Date          : 1999.08.06                                        }
{ Note          : 現在のｶﾚﾝﾄｳｨﾝﾄﾞｳﾊﾝﾄﾞﾙを取得します                 }
{-------------------------------------------------------------------}
{ Update Note   :                                                   }
{*******************************************************************}
function GetTopMostWindows(Handle: HWND; Info: Pointer): BOOL; stdcall;
begin
  if GetCurrentThreadID = GetWindowThreadProcessId(Handle, Nil) then
  begin
    glMsgHandle := GetTopWindow(Handle);
    Result := FALSE;
  end else
    Result := TRUE;
end;
// 20000218 <<

// 2009.08.10 Del Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
(*
// 20000624 >>
{*******************************************************************}
{ Module Name   : SF-LITE共通ﾍｯﾀﾞ領域ﾃﾞｰﾀｾｯﾄ関数                    }
{               : HGetFileHeader                                    }
{ 引数          : 1 Pointer  ﾃﾞｰﾀをｾｯﾄする構造体の先頭ｱﾄﾞﾚｽ         }
{               : 2 Integer  ﾓｰﾄﾞ  HGET_FHINS:ｲﾝｻｰﾄﾓｰﾄﾞ             }
{               :                  HGET_FHUPD:ｱｯﾌﾟﾃﾞｰﾄﾓｰﾄﾞ          }
{ 戻り値        : 1 Boolean  FALSE:失敗, TRUE:成功                  }
{ Programer     : ueo                                               }
{ Date          : 2000.06.24                                        }
{ Note          : ﾊﾞｯﾁ処理用共通ﾍｯﾀﾞのﾃﾞｰﾀをｾｯﾄします               }
{-------------------------------------------------------------------}
{ Update Note   : 2000.07.04  鹿野　幸生                            }
{ Update Note   : 2000.07.12  鹿野　幸生                            }
{ Update Note   : 2001.04.03  鹿野　幸生                            }
{*******************************************************************}
function HGetFileHeader(Rec:Pointer;Mode:Integer):Boolean;
var
  BatRec  : tagBATHEAD;      //ﾊﾞｯﾁ用共通ﾍｯﾀﾞ情報
  tkcd    : LongInt;         //ﾕｰｻﾞｰｺｰﾄﾞ1&2
  tkcd2   : LongInt;         //ﾕｰｻﾞｰｺｰﾄﾞ3
  sysdate : LongInt;         //ｼｽﾃﾑ日付
  systime : LongInt;         //ｼｽﾃﾑ時間
  STime   : TSYSTEMTIME;     //SYTEMTIME構造体

begin

//  Result := FALSE;

  //現在の情報を取得
//  HMemCpy(@BatRec, Rec, sizeof(BatRec));
  CopyMemory(@BatRec, Rec, sizeof(BatRec));

  //ｼｽﾃﾑ日付時間取得
  GetLocalTime(STime);
  sysdate := (STime.wYear * 10000) + (STime.wMonth * 100) + (STime.wDay);
  systime := (STime.wHour * 10000) + (STime.wMinute* 100) + (STime.wSecond);

  //DLLの関数ｱﾄﾞﾚｽ取得
//  if DllLoadProc('HHPCHK32.DLL','HPGetTkcd',ghndHpChk32,@pHpGetTkcd)=FALSE then
//    Exit;

  //ﾕｰｻﾞｰｺｰﾄﾞ取得(初回の１回目だけ行う)                                         2000.07.04 変更
  if guserid1[0] = #0 then begin
    HFSLLIB.LoadCtlHPChk32(1);                             // DLLの関数ｱﾄﾞﾚｽ取得
    pHpGetTkcd(tkcd, tkcd2);
//    HPGetTkcd(tkcd, tkcd2);
    HStrPNCopy(guserid1, Format('%.7d', [tkcd div 100]), sizeof(guserid1));
    HStrPNCopy(guserid2, Format('%.2d', [tkcd mod 100]), sizeof(guserid2));
    HStrPNCopy(guserid3, Format('%.2d', [tkcd2]), sizeof(guserid2));
    HFSLLIB.LoadCtlHPChk32(0);                             // DLL解放
  end;

  //ﾊﾞｯﾁ用ﾍｯﾀﾞ情報ｾｯﾄ
  with BatRec do
  begin
    if Mode = HGET_FHINS then
      creadate := sysdate;
    BatRec.update := sysdate;
    BatRec.actime := systime;
//    StrLCopy(userid1, guserid1, sizeof(userid1));                               // 2000.07.04 変更
//    StrLCopy(userid2, guserid2, sizeof(userid2));                               // 2000.07.04 変更
//    StrLCopy(userid3, guserid3, sizeof(userid2));                               // 2000.07.04 変更
    CopyMemory(@userid1, @guserid1, sizeof(userid1));                               // 2000.07.04 変更
    CopyMemory(@userid2, @guserid2, sizeof(userid2));                               // 2000.07.04 変更
    CopyMemory(@userid3, @guserid3, sizeof(userid2));                               // 2000.07.04 変更
  end;

  //設定内容を元に戻す
//  HMemCpy(Rec, @BatRec, sizeof(BatRec));
  CopyMemory(Rec, @BatRec, sizeof(BatRec));



  Result := TRUE;                                                               // 2000.07.04 追加

end;
*)
// 2009.08.10 Del End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

{*******************************************************************}
{ Module Name   : 共通ﾍｯﾀﾞ領域ﾃﾞｰﾀｾｯﾄ関数                          }
{               : HGetFileHeader                                    }
{ 引数          : 1 TClientDataSet                                  }
{               : 2 Integer  ﾓｰﾄﾞ  HGET_FHINS:ｲﾝｻｰﾄﾓｰﾄﾞ             }
{               :                  HGET_FHUPD:ｱｯﾌﾟﾃﾞｰﾄﾓｰﾄﾞ          }
{ 戻り値        : 1 Boolean  FALSE:失敗, TRUE:成功                  }
{ Programer     : 上野　耕平                                        }
{ Date          : 2009.09.04                                        }
{ Note          : 共通ﾍｯﾀﾞのﾃﾞｰﾀをｾｯﾄします                         }
{-------------------------------------------------------------------}
{ Update Note   :                                                   }
{ Update Note   : 2009.10.10  徳永　誠　                            }
{               :   認証情報から各値を取得・セットするように修正    }
{*******************************************************************}
function HGetFileHeader(fileHeader:TClientDataSet;Mode:Integer):Boolean;
var
  guid    : TGUID; // GUID生成用
  productCode : string;

  stLoginInf: tagLogininf;
  ModuleName: array[0..255] of Char;
begin
   HInitProc.HGetLoginInf(stLoginInf);  // ログイン情報取得

  //先頭行にする
//  fileHeader.First;


// while not fileHeader.Eof do
    begin
        fileHeader.Edit;

      // GUID生成
      CreateGUID(guid);

// 2009.09.08 項目IDを大文字に統一  STA >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
      begin
      if Mode = HGET_FHINS then
        fileHeader.FieldByName('CREATEDATETIMERF').Value := GetTimeNowToTicks();
        fileHeader.FieldByName('ENTERPRISECODERF').Value := String(stLoginInf.enterpriseCode);
        fileHeader.FieldByName('FILEHEADERGUIDRF').Value := GUIDToString(guid);
        fileHeader.FieldByName('LOGICALDELETECODERF').Value :=  0;
      end;

      fileHeader.FieldByName('UPDATEDATETIMERF').Value := GetTimeNowToTicks();
      fileHeader.FieldByName('UPDEMPLOYEECODERF').Value :=String(stLoginInf.employeeCode);
      fileHeader.FieldByName('UPDASSEMBLYID1RF').Value := String(stLoginInf.szPgExeId);
      fileHeader.FieldByName('UPDASSEMBLYID2RF').Value := String(stLoginInf.szPgExeId);
// 2009.09.08 項目IDを大文字に統一  END <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

      // 次の行
//      fileHeader.Next
   end;

  Result :=True;
end;

// 2009.09.07 Del Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
(*
{*******************************************************************}
{ Module Name   : Ticks取得関数                                     }
{               : GetTimeNowToTicks                                   }
{ 引数          :                                                   }
{               :                                                   }
{ 戻り値        : 1 Int64                                           }
{ Programer     : 上野　耕平                                        }
{ Date          : 2009.09.04                                        }
{ Note          : 0001 年 1 月 1 日午前 00:00:00 以降の経過時間     }
{               : (100 ナノ秒単位）で取得します                     }
{-------------------------------------------------------------------}
{ Update Note   :                                                   }
{*******************************************************************}
function GetTimeNowToTicks():Int64;
var
  utcTime : FILETIME; //
  ticks   : Int64;    //
begin

  // システムの現在の日付と時刻を UTC 形式で取得
  GetSystemTimeAsFileTime(&utcTime);

  // UTC形式の時刻をローカル形式に変換
  FileTimeToLocalFileTime(utcTime,&utcTime);

  // 1601年1月1日 00:00:00 からの経過時間を100ナノ秒単位で取得（Int64形式）
  ticks := Int64(utcTime.dwLowDateTime) + (int64(utcTime.dwHighDateTime) shl 32);

  // 0001/1/1 00:00:00 からの経過時間に変換する
  // 1601年1月1日 00:00:00　⇒ 504911232000000000　を足す
  ticks := ticks + 504911232000000000;

  result := ticks;

end;
*)
// 2009.09.07 Del End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<


{*******************************************************************}
{ Module Name   : DLLﾛｰﾄﾞ関数                                       }
{               : DllLoadProc                                       }
{ 引数          : 1 String   ﾛｰﾄﾞするDLLの名前                      }
{               : 2 String   ｱﾄﾞﾚｽを取得する関数の名前              }
{               :            ただし、指定無しはｱﾄﾞﾚｽ取得をしません  }
{               : 3 THandle  ﾛｰﾄﾞしたDLLのｲﾝｽﾀﾝｽﾊﾝﾄﾞﾙ(ただし0以外は }
{               :            ﾛｰﾄﾞ済みと判断しﾛｰﾄﾞしません)          }
{               : 4 FARPROC  取得した関数ｱﾄﾞﾚｽ                      }
{ 戻り値        : 1 Boolean  FALSE:失敗, TRUE:成功                  }
{ Programer     : ueo                                               }
{ Date          : 2000.06.24                                        }
{ Note          : DLLのﾛｰﾄﾞおよび関数のｱﾄﾞﾚｽを取得します            }
{-------------------------------------------------------------------}
{ Update Note   :                                                   }
{*******************************************************************}
function DllLoadProc(DllNm:String;ModuleNm:String;
                     var InsHandle:THandle;var fpProc:FARPROC):Boolean;
begin

  Result := FALSE;

  //DLLが既にﾛｰﾄﾞ済みであればﾛｰﾄﾞ処理は行わない
  if InsHandle = 0 then
  begin
    //DLLのﾛｰﾄﾞ
    InsHandle := LoadLibrary(PChar(DllNm));
    if InsHandle < 32 then
    begin
      //ﾛｰﾄﾞ失敗
      InsHandle := 0;
      HMsgDisp(0,PChar(DllNm+'のロードに失敗しました'),
        'HFSLLIB',GetLastError,0);
      Exit;
    end;
  end;

  //ﾓｼﾞｭｰﾙﾈｰﾑが無い場合はｱﾄﾞﾚｽ取得を行わない
  if ModuleNm <> '' then
  begin
    //関数ｱﾄﾞﾚｽ取得
    fpProc := GetProcAddress(InsHandle,PChar(ModuleNm));
    if fpProc = nil then
    begin
      HMsgDisp(0,PChar(DllNm+'で関数('+ModuleNm+')の取得に失敗しました'), 'HFSLLIB',GetLastError,0);
      Exit;
    end;
  end;

  Result := TRUE;

end;
// 20000624 <<

// 2009.08.10 Del Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
(*
{*******************************************************************}
{ Module Name   : HHPCHK32.DLLロード制御関数                        }
{               : LoadCtlHPChk32                                    }
{ 引数          : 1 Inteer   DLLロード制御(1:LOAD, 0:UNLOAD)        }
{ 戻り値        : 1 Boolean  FALSE:失敗, TRUE:成功                  }
{ Programer     : 鹿野　幸生                                        }
{ Date          : 2000.06.27                                        }
{ Note          : HHPCHK32.DLLのロード・アンロードの制御            }
{-------------------------------------------------------------------}
{ Update Note   : 2001.04.19  鹿野　幸生                            }
{*******************************************************************}
function LoadCtlHPChk32(inFncType: integer): Boolean;
begin

  if inFncType = 1 then begin

//    Result := DllLoadProc('HHPCHK32.DLL','HPGetTkcd', ghndHpChk32, @pHpGetTkcd);
    Result := DllLoadProc('HHPCHK50.DLL','HPGetTkcd', ghndHpChk32, @pHpGetTkcd);

  end else begin

    Result := FreeLibrary(ghndHpChk32);
    ghndHpChk32 := 0;

  end;

end;
*)
// 2009.08.10 Del End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

{*******************************************************************}
{ Module Name   : プログラムInfo設定関数                            }
{               : SetPgId                                           }
{ 引数          : 1 integer  プログラムタイプ(0:EXE,1:DLL)          }
{               : 2 string   プログラムID                           }
{               : 3 string   プログラム名称                         }
{ 戻り値        : 1 integer  ダミー ゼロ固定                        }
{ Programer     : 鹿野　幸生                                        }
{ Date          : 2000.06.27                                        }
{ Note          : プログラムID、名称の内部セット                    }
{-------------------------------------------------------------------}
{ Update Note   :                                                   }
{*******************************************************************}
function SetPgInfo(inPgType:integer; istrPgId, istrPgNm: string): integer;
begin

  case inPgType of
    0: begin                                     // EXE
       gstrPgExeId := istrPgId;
       gstrPgExeNm := istrPgNm;
    end;
    1: begin                                     // DLL
       gstrPgDllId := istrPgId;
       gstrPgDllNm := istrPgNm;
    end;
  end;

  Result := 0;

end;


{*******************************************************************}
{ Module Name   : プログラムId取得関数                              }
{               : SetPgId                                           }
{ 引数          : 1          無し                                   }
{ 戻り値        : 1 string   プログラムId                           }
{ Programer     : 鹿野　幸生                                        }
{ Date          : 2000.06.27                                        }
{ Note          : 内部のプログラムIDを返す                          }
{-------------------------------------------------------------------}
{ Update Note   :                                                   }
{*******************************************************************}
function GetPgId: string;
begin

  Result := gstrPgExeId;

end;

{*******************************************************************}
{ Module Name   : プログラム名称取得関数                            }
{               : SetPgNm                                           }
{ 引数          : 1          無し                                   }
{ 戻り値        : 1 string   プログラム名称                         }
{ Programer     : 鹿野　幸生                                        }
{ Date          : 2000.06.27                                        }
{ Note          : 内部のプログラム名称を返す                        }
{-------------------------------------------------------------------}
{ Update Note   :                                                   }
{*******************************************************************}
function GetPgNm: string;
begin

  Result := gstrPgExeNm;

end;

{*******************************************************************}
{ Module Name   : 子プログラムId取得関数                            }
{               : GetPgDllId                                        }
{ 引数          : 1          無し                                   }
{ 戻り値        : 1 string   プログラムId                           }
{ Programer     : 徳永　誠                                          }
{ Date          : 2009.08.10                                        }
{ Note          : 内部のプログラムIDを返す                          }
{-------------------------------------------------------------------}
{ Update Note   :                                                   }
{*******************************************************************}
function GetPgDllId: string;
begin

  Result := gstrPgDllId;

end;

{*******************************************************************}
{ Module Name   : 子プログラム名称取得関数                          }
{               : GetPgDllNm                                        }
{ 引数          : 1          無し                                   }
{ 戻り値        : 1 string   プログラム名称                         }
{ Programer     : 徳永　誠                                          }
{ Date          : 2009.08.10                                        }
{ Note          : 内部のプログラム名称を返す                        }
{-------------------------------------------------------------------}
{ Update Note   :                                                   }
{*******************************************************************}
function GetPgDllNm: string;
begin

  Result := gstrPgDllNm;

end;

// 2009.08.10 Del Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
{
//*******************************************************************//
// Module Name   : ALPBU0002.DLLロード制御関数                       //
//               : LoadCtlHSecAcs                                    //
// 引数          : 1 DLLロード制御(1:LOAD, 0:UNLOAD)                 //
// 戻り値        : FALSE:失敗, TRUE:成功                             //
// Programer     : 鹿野　幸生                                        //
// Date          : 2000.07.12                                        //
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
//function LoadCtlALPBU0002(inFncType: integer): Boolean;                       2001.02.26 変更
function LoadCtlHLogAcs(inFncType: integer): Boolean;
begin

  Result := False;

  if inFncType = 1 then begin

    //DLLが既にﾛｰﾄﾞ済みであればﾛｰﾄﾞ処理は行わない
//    if ghndALPBU0002 = 0 then begin                                           2001.02.26 変更
      //DLLのﾛｰﾄﾞ
//      ghndALPBU0002 := LoadLibrary(ctALPBU0002);
//      if ghndALPBU0002 =0 then begin
//          HMsgDisp(0, PChar(ctALPBU0002 + 'のロードに失敗しました'), 'HFSLLIB', GetLastError, 0);
    if ghndHLogAcs = 0 then begin
      ghndHLogAcs := LoadLibrary(ctHLOGACS_DLL);
      if ghndHLogAcs =0 then begin
        //ﾛｰﾄﾞ失敗
          HDspMsg(ERR_LEVEL_EXCLAMATION, 'HFSLLIB', GetPgNm, ctSecNameWrtLog, ctOPE_START,
            PChar(ctHLOGACS_DLL + 'のロードに失敗しました' + #13 + '起動できません' + #13 + #13 + 'このエラーは記録されません'),
              GetLastError, nil, 0);
        Exit;
      end;
      //関数ｱﾄﾞﾚｽ取得
//      pWrtSysLog := GetProcAddress(ghndALPBU0002, 'WrtSysLog');               2001.02.26 変更
      pWrtSysLog := GetProcAddress(ghndHLogAcs, 'WrtSysLog');
      if @pWrtSysLog = nil then begin
//          HMsgDisp(0, PChar(ctALPBU0002+'で関数の取得に失敗しました'), 'HFSLLIB', GetLastError, 0);
          HDspMsg(ERR_LEVEL_EXCLAMATION, 'HFSLLIB', GetPgNm, ctSecNameWrtLog, ctOPE_START,
            PChar(ctHLOGACS_DLL + 'で関数の取得に失敗しました' + #13 + '起動できません' + #13 + #13 + 'このエラーは記録されません'),
              GetLastError, nil, 0);
        exit;
      end;
    end;

    Result := True;

  end else begin

    // DLLを解放する
//    Result := FreeLibrary(ghndALPBU0002);                                     2001.02.26 変更
//    ghndALPBU0002 := 0;
    Result := FreeLibrary(ghndHLogAcs);
    ghndHLogAcs := 0;
    pWrtSysLog := nil;

  end;


end;
}
// 2009.08.10 Del End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

//*******************************************************************//
// Module Name   : 画面コンポーネント色一括変更関数                  //
//               : HSetDefColor                                      //
// 引数          : 1 対象フォームオブジェクト                        //
//               : 2 色定義INI名                                     //
//               : 3 色定義セクション名                              //
//               : 4 対象コンポーネント名                            //
//               : 5 置換色指定コンポーネント名                      //
//  戻り値       : 整数   0:正常終了                                 //
//               :        3:色定義INI名設定エラー                    //
//               :        5:色設定エラー                             //
// Programer     : 鹿野　幸生                                        //
// Date          : 2000.08.20                                        //
//-------------------------------------------------------------------//
//               :   2000.10.05  鹿野　幸生                          //
//               :   2000.10.12  鹿野　幸生                          //
//*******************************************************************//
function HSetDefColor(iForm: TForm; istrIniName, istrSecName: string; istrComp1:string = ''; iComp2:TComponent = nil): integer;
var
  i, j :      integer;
  nEPos:      integer;
  nCmmaPos:   integer;
  nColor:     integer;
  nValidPos:  integer;
  nValidLen:  integer;

  ClassRef:   TClass;
  TObj :      TComponent;
  tFnt:       TFont;
  tBrs:       TBrush;
  tPn:        TPen;
  pPropName:  PPropInfo;
  pPropColor: PPropInfo;
  pPropFont:  PPropInfo;
  pPropBrsh:  PPropInfo;
  pPropPen:   PPropInfo;
  IniName:    TIniFile;
  IniList:    TStringList;
  IniList2:   TStringList;

  IniFrColorList: TStringList;
  IniBkColorList: TStringList;
  IniFtColorList: TStringList;
  IniFcColorList: TStringList;                                                  // 2000.10.05 追加
  IniOdColorList: TStringList;                                                  // 2000.10.05 追加

  strIniFlName: string;
  strKeyNanme : string;
  strCompoName: string;
  strColor:     string;

begin

  Result := 5;

  IniList2 := nil;                                                              // 2009.08.10 Ins

  try

    // INIファイルを読み込む
    IniList  := TStringList.Create;
    IniList2 := TStringList.Create;

    strIniFlName := istrIniName;
    if HGetIniPath(strIniFlName) <> 0 then begin
      Result := 3;
      exit;
    end;

    IniName := TIniFile.Create(strIniFlName);
    with IniName do begin
      ReadSection(istrSecName, IniList);
      ReadSectionValues(istrSecName, IniList2);
    end;

    // INIファイルの中身が無ければ、警告終了
    if IniList.Count = 0 then begin
      result := 3;
      exit;
    end;

    // それぞれのカラーを取得
    IniFrColorList := TStringList.Create;
    IniBkColorList := TStringList.Create;
    IniFtColorList := TStringList.Create;
    IniFcColorList := TStringList.Create;                                       // 2000.10.05 追加
    IniOdColorList := TStringList.Create;                                       // 2000.10.05 追加
    for j := 0 to IniList.Count - 1 do begin
      nEPos    := Length(IniList.Strings[j]);
      IniList2.Strings[j] := Copy(IniList2.Strings[j], nEPos + 2, Length(IniList2.Strings[j])-nEPos);
      nCmmaPos := Pos(',', IniList2.Strings[j]);
      // フォアカラーを取得
      strColor := '';
      nCmmaPos := Length(IniList2.Strings[j]);
      for i := 1 to Length(IniList2.Strings[j]) do begin
        if IniList2.Strings[j][i] = ',' then begin
          nCmmaPos := i;
          break;
        end;
        strColor := strColor + IniList2.Strings[j][i];
      end;
      IniFrColorList.Add(strColor);
      IniList2.Strings[j] := Copy(IniList2.Strings[j], nCmmaPos + 1, Length(IniList2.Strings[j]) - nCmmaPos);
      // バックカラーを取得
      strColor := '';
      nCmmaPos := Length(IniList2.Strings[j]);
      for i := 1 to Length(IniList2.Strings[j]) do begin
        if IniList2.Strings[j][i] = ',' then begin
          nCmmaPos := i;
          break;
        end;
        strColor := strColor + IniList2.Strings[j][i];
      end;
      IniBkColorList.Add(strColor);
      IniList2.Strings[j] := Copy(IniList2.Strings[j], nCmmaPos + 1, Length(IniList2.Strings[j]) - nCmmaPos);
      // フォントカラーを取得
      strColor := '';
      nCmmaPos := Length(IniList2.Strings[j]);
      for i := 1 to Length(IniList2.Strings[j]) do begin
        if IniList2.Strings[j][i] = ',' then begin
          nCmmaPos := i;
          break;
        end;
        strColor := strColor + IniList2.Strings[j][i];
      end;
      IniFtColorList.Add(strColor);
      IniList2.Strings[j] := Copy(IniList2.Strings[j], nCmmaPos + 1, Length(IniList2.Strings[j]) - nCmmaPos);
      // Ｆｉｘｅｄカラーを取得                                                 2000.10.05 追加
      strColor := '';
      nCmmaPos := Length(IniList2.Strings[j]);
      for i := 1 to Length(IniList2.Strings[j]) do begin
        if IniList2.Strings[j][i] = ',' then begin
          nCmmaPos := i;
          break;
        end;
        strColor := strColor + IniList2.Strings[j][i];
      end;
      IniFcColorList.Add(strColor);
      IniList2.Strings[j] := Copy(IniList2.Strings[j], nCmmaPos + 1, Length(IniList2.Strings[j]) - nCmmaPos);
      // Ｏｄｄカラー(PerfectGrid)を取得                                         2000.10.05 追加
      strColor := '';
      nCmmaPos := Length(IniList2.Strings[j]);
      for i := 1 to Length(IniList2.Strings[j]) do begin
        if IniList2.Strings[j][i] = ',' then begin
          nCmmaPos := i;
          break;
        end;
        strColor := strColor + IniList2.Strings[j][i];
      end;
      IniOdColorList.Add(strColor);

    end;

    for j := 0 to IniList.Count - 1 do begin

      strKeyNanme := UpperCase(IniList.Strings[j]);

      // フォーム色を設定
      if strKeyNanme = 'TFORM' then begin
        strColor := IniFrColorList.Strings[j];
        if Copy(strColor, 1, 2) = 'cl' then begin
          nColor := StringToColor(strColor);
        end else begin
          try
            nColor := StrToInt(strColor);
          except
            else nColor := -1;
          end;
        end;
        if nColor <> -1 then
          iForm.Color :=  nColor;
        continue;
      end;

      // コンポーネント名が指定されていれば、それと一致した場合のみ色をセット
      if (istrComp1 <> '') and (UpperCase(istrComp1) <> strKeyNanme) then
        Continue;

      // もし、Key中に'*'あれば部分一致でもOKとする
      nValidPos := 0;
      nValidLen := 0;
      if Pos('*', strKeyNanme) > 0 then begin
        nValidPos := Pos(strKeyNanme, '*');
        if nValidPos = 1 then begin
          nValidPos := 2;
          nValidLen := Length(strKeyNanme) - nValidPos
        end else begin
          nValidPos := 1;
          nValidLen := Length(strKeyNanme) - 1;
        end;
        strKeyNanme := Copy(strKeyNanme, nValidPos, nValidLen);
      end;

      // フォームのコントロール分回す
      for i := iForm.ComponentCount - 1 downto 0 do begin

        TObj := iForm.Components[i];

        // クラス名(先頭に*がついている場合は、無条件にコンポーネント名と考える)
        if (nValidPos = 0) and (strKeyNanme[1] = 'T') then begin

          // コントロールのプロパティにColorプロパティがあれば、新しい色をセットする
          ClassRef := TObj.ClassType;
          if UpperCase(ClassRef.ClassName) = strKeyNanme then begin

            // カラーを設定
            pPropColor := GetPropInfo(TObj.ClassInfo, 'Color');
            if pPropColor <> nil then begin
              strColor := IniFrColorList.Strings[j];
              if strColor <>  '' then begin
                if Copy(strColor, 1, 2) = 'cl' then begin
                  SetOrdProp(TObj, pPropColor, StringToColor(strColor));
                end else begin
                  try
                    nColor := StrToInt(strColor);
                  except
                    else nColor := -1;
                  end;
                  if nColor <> -1 then
                    SetOrdProp(TObj, pPropColor, nColor);
                end;
              end;
            end;

            // フォアカラーを設定
            pPropColor := GetPropInfo(TObj.ClassInfo, 'ForeColor');
            if pPropColor <> nil then begin
              strColor := IniFrColorList.Strings[j];
              if strColor <>  '' then begin
                if Copy(strColor, 1, 2) = 'cl' then begin
                  SetOrdProp(TObj, pPropColor, StringToColor(strColor));
                end else begin
                  try
                    nColor := StrToInt(strColor);
                  except
                    else nColor := -1;
                  end;
                  if nColor <> -1 then
                    SetOrdProp(TObj, pPropColor, nColor);
                end;
              end;
            end;

            // バックカラーを設定
            pPropColor := GetPropInfo(TObj.ClassInfo, 'BackColor');
            if pPropColor <> nil then begin
              strColor := IniBkColorList.Strings[j];
              if strColor <>  '' then begin
                if Copy(strColor, 1, 2) = 'cl' then begin
                  SetOrdProp(TObj, pPropColor, StringToColor(strColor));
                end else begin
                  try
                    nColor := StrToInt(strColor);
                  except
                    else nColor := -1;
                  end;
                  if nColor <> -1 then
                    SetOrdProp(TObj, pPropColor, nColor);
                end;
              end;
            end;

            // フォントカラーを設定
//            pPropFont := GetPropInfo(iForm.ClassInfo, 'Font');
            pPropFont := GetPropInfo(TObj.ClassInfo, 'Font');
            if pPropFont <> nil then begin
              if (pPropFont^.PropType^^.Kind = tkClass) then begin
               // オブジェクトを取り出す。
               tFnt := TFont(GetOrdProp(TObj, pPropFont));
               // しつこく判定。TFont 派生クラスであれば、
               if Assigned(tFnt) and (tFnt is TFont) then
                 strColor := IniFtColorList.Strings[j];
                 if strColor <>  '' then begin
                   if Copy(strColor, 1, 2) = 'cl' then begin
                     try
                       tFnt.Color := StringToColor(strColor);
                     except
                       else nColor := -1;
                     end;
                   end else begin
                     try
                       tFnt.Color := StrToInt(strColor);
                     except
                       else nColor := -1;
                     end;
                   end;
                 end;
              end;
            end;

            // ブラシのカラーを設定
            pPropBrsh := GetPropInfo(TObj.ClassInfo, 'Brush');
            if pPropBrsh <> nil then begin
              if (pPropBrsh^.PropType^^.Kind = tkClass) then begin
               // オブジェクトを取り出す。
               tBrs := TBrush(GetOrdProp(TObj, pPropBrsh));
               // しつこく判定。TFont 派生クラスであれば、
               if Assigned(tBrs) and (tBrs is TBrush) then
                 strColor := IniFrColorList.Strings[j];
                 if strColor <>  '' then begin
                   if Copy(strColor, 1, 2) = 'cl' then begin
                     try
                       tBrs.Color := StringToColor(strColor);
                     except
                       else nColor := -1;
                     end;
                   end else begin
                     try
                       tBrs.Color := StrToInt(strColor);
                     except
                       else nColor := -1;
                     end;
                   end;
                 end;
              end;
            end;

            // ペンのカラーを設定
            pPropPen := GetPropInfo(TObj.ClassInfo, 'Pen');
            if pPropPen <> nil then begin
              if (pPropPen^.PropType^^.Kind = tkClass) then begin
               // オブジェクトを取り出す。
               tPn := TPen(GetOrdProp(TObj, pPropPen));
               // しつこく判定。TFont 派生クラスであれば、
               if Assigned(tPn) and (tPn is TPen) then
                 strColor := IniBkColorList.Strings[j];
                 if strColor <>  '' then begin
                   if Copy(strColor, 1, 2) = 'cl' then begin
                     try
                       tPn.Color := StringToColor(strColor);
                     except
                       else nColor := -1;
                     end;
                   end else begin
                     try
                       tPn.Color := StrToInt(strColor);
                     except
                       else nColor := -1;
                     end;
                   end;
                 end;
              end;
            end;

            // Ｆｉｘｅｄカラーを設定                                           2000.10.05 追加
            pPropColor := GetPropInfo(TObj.ClassInfo, 'FixedColor');
            if pPropColor <> nil then begin
              strColor := IniFcColorList.Strings[j];
              if strColor <>  '' then begin
                if Copy(strColor, 1, 2) = 'cl' then begin
                  SetOrdProp(TObj, pPropColor, StringToColor(strColor));
                end else begin
                  try
                    nColor := StrToInt(strColor);
                  except
                    else nColor := -1;
                  end;
                  if nColor <> -1 then
                    SetOrdProp(TObj, pPropColor, nColor);
                end;
              end;
            end;

            // ＦｉｘｅｄＢａｃｋカラーを設定                                   2000.10.05 追加
            pPropColor := GetPropInfo(TObj.ClassInfo, 'FixedBackColor');
            if pPropColor <> nil then begin
              strColor := IniFcColorList.Strings[j];
              if strColor <>  '' then begin
                if Copy(strColor, 1, 2) = 'cl' then begin
                  SetOrdProp(TObj, pPropColor, StringToColor(strColor));
                end else begin
                  try
                    nColor := StrToInt(strColor);
                  except
                    else nColor := -1;
                  end;
                  if nColor <> -1 then
                    SetOrdProp(TObj, pPropColor, nColor);
                end;
              end;
            end;

            // ＯｄｄＲｏｗＢａｃｋカラーを設定                                 2000.10.05 追加
            pPropColor := GetPropInfo(TObj.ClassInfo, 'OddRowBackColor');
            if pPropColor <> nil then begin
              strColor := IniOdColorList.Strings[j];
              if strColor <>  '' then begin
                if Copy(strColor, 1, 2) = 'cl' then begin
                  SetOrdProp(TObj, pPropColor, StringToColor(strColor));
                end else begin
                  try
                    nColor := StrToInt(strColor);
                  except
                    else nColor := -1;
                  end;
                  if nColor <> -1 then
                    SetOrdProp(TObj, pPropColor, nColor);
                end;
              end;
            end;

          end;

        end else begin

          // コンポーネント名
          // コントロールのプロパティにColorプロパティがあれば、新しい色をセットする
          pPropName := GetPropInfo(TObj.ClassInfo, 'Name');
          if (pPropName <> nil) then begin

            // *が有れば有効桁数で判断
            strCompoName := UpperCase(GetStrProp(TObj, pPropName));
            if ((nValidPos = 0) and (strCompoName = strKeyNanme)) or
               (nValidPos > 0) and (Pos(strKeyNanme, strCompoName) = nValidPos) then begin

              // カラーを設定
              pPropColor := GetPropInfo(TObj.ClassInfo, 'Color');
              if pPropColor <> nil then begin
                strColor := IniFrColorList.Strings[j];
                if strColor <>  '' then begin
                  if Copy(strColor, 1, 2) = 'cl' then begin
                    SetOrdProp(TObj, pPropColor, StringToColor(strColor));
                  end else begin
                    try
                      nColor := StrToInt(strColor);
                    except
                      else nColor := -1;
                    end;
                    if nColor <> -1 then
                      SetOrdProp(TObj, pPropColor, nColor);
                  end;
                end;
              end;

              // フォアカラーを設定
              pPropColor := GetPropInfo(TObj.ClassInfo, 'ForeColor');
              if pPropColor <> nil then begin
                strColor := IniFrColorList.Strings[j];
                if strColor <>  '' then begin
                  if Copy(strColor, 1, 2) = 'cl' then begin
                    SetOrdProp(TObj, pPropColor, StringToColor(strColor));
                  end else begin
                    try
                      nColor := StrToInt(strColor);
                    except
                      else nColor := -1;
                    end;
                    if nColor <> -1 then
                      SetOrdProp(TObj, pPropColor, nColor);
                  end;
                end;
              end;

              // バックカラーを設定
              pPropColor := GetPropInfo(TObj.ClassInfo, 'BackColor');
              if pPropColor <> nil then begin
                strColor := IniBkColorList.Strings[j];
                if strColor <>  '' then begin
                  if Copy(strColor, 1, 2) = 'cl' then begin
                    SetOrdProp(TObj, pPropColor, StringToColor(strColor));
                  end else begin
                    try
                      nColor := StrToInt(strColor);
                    except
                      else nColor := -1;
                    end;
                    if nColor <> -1 then
                      SetOrdProp(TObj, pPropColor, nColor);
                  end;
                end;
              end;

              // フォントカラーを設定
//              pPropFont := GetPropInfo(iForm.ClassInfo, 'Font');
              pPropFont := GetPropInfo(TObj.ClassInfo, 'Font');
              if pPropFont <> nil then begin
                if (pPropFont^.PropType^^.Kind = tkClass) then begin
                 // オブジェクトを取り出す。
                 tFnt := TFont(GetOrdProp(TObj, pPropFont));
                 // しつこく判定。TFont 派生クラスであれば、
                 if Assigned(tFnt) and (tFnt is TFont) then
                   strColor := IniFtColorList.Strings[j];
                   if strColor <>  '' then begin
                     if Copy(strColor, 1, 2) = 'cl' then begin
                       try
                         tFnt.Color := StringToColor(strColor);
                       except
                         else nColor := -1;
                       end;
                     end else begin
                       try
                         tFnt.Color := StrToInt(strColor);
                       except
                         else nColor := -1;
                       end;
                     end;
                   end;
                end;
              end;

              // ブラシのカラーを設定
              pPropBrsh := GetPropInfo(TObj.ClassInfo, 'Brush');
              if pPropBrsh <> nil then begin
                if (pPropBrsh^.PropType^^.Kind = tkClass) then begin
                 // オブジェクトを取り出す。
                 tBrs := TBrush(GetOrdProp(TObj, pPropBrsh));
                 // しつこく判定。TFont 派生クラスであれば、
                 if Assigned(tBrs) and (tBrs is TBrush) then
                   strColor := IniFrColorList.Strings[j];
                   if strColor <>  '' then begin
                     if Copy(strColor, 1, 2) = 'cl' then begin
                       try
                         tBrs.Color := StringToColor(strColor);
                       except
                         else nColor := -1;
                       end;
                     end else begin
                       try
                         tBrs.Color := StrToInt(strColor);
                       except
                         else nColor := -1;
                       end;
                     end;
                   end;
                end;
              end;

              // ペンのカラーを設定
              pPropPen := GetPropInfo(TObj.ClassInfo, 'Pen');
              if pPropPen <> nil then begin
                if (pPropPen^.PropType^^.Kind = tkClass) then begin
                 // オブジェクトを取り出す。
                 tPn := TPen(GetOrdProp(TObj, pPropPen));
                 // しつこく判定。TFont 派生クラスであれば、
                 if Assigned(tPn) and (tPn is TPen) then
                   strColor := IniBkColorList.Strings[j];
                   if strColor <>  '' then begin
                     if Copy(strColor, 1, 2) = 'cl' then begin
                       try
                         tPn.Color := StringToColor(strColor);
                       except
                         else nColor := -1;
                       end;
                     end else begin
                       try
                         tPn.Color := StrToInt(strColor);
                       except
                         else nColor := -1;
                       end;
                     end;
                   end;
                end;
              end;

              // Ｆｉｘｅｄカラーを設定                                         2000.10.05 追加
              pPropColor := GetPropInfo(TObj.ClassInfo, 'FixedColor');
              if pPropColor <> nil then begin
                strColor := IniFcColorList.Strings[j];
                if strColor <>  '' then begin
                  if Copy(strColor, 1, 2) = 'cl' then begin
                    SetOrdProp(TObj, pPropColor, StringToColor(strColor));
                  end else begin
                    try
                      nColor := StrToInt(strColor);
                    except
                      else nColor := -1;
                    end;
                    if nColor <> -1 then
                      SetOrdProp(TObj, pPropColor, nColor);
                  end;
                end;
              end;

              // ＦｉｘｅｄＢａｃｋカラーを設定                                 2000.10.05 追加
              pPropColor := GetPropInfo(TObj.ClassInfo, 'FixedBackColor');
              if pPropColor <> nil then begin
                strColor := IniFcColorList.Strings[j];
                if strColor <>  '' then begin
                  if Copy(strColor, 1, 2) = 'cl' then begin
                    SetOrdProp(TObj, pPropColor, StringToColor(strColor));
                  end else begin
                    try
                      nColor := StrToInt(strColor);
                    except
                      else nColor := -1;
                    end;
                    if nColor <> -1 then
                      SetOrdProp(TObj, pPropColor, nColor);
                  end;
                end;
              end;

            // ＯｄｄＲｏｗＢａｃｋカラーを設定                                 2000.10.05 追加
              pPropColor := GetPropInfo(TObj.ClassInfo, 'OddRowBackColor');
              if pPropColor <> nil then begin
                strColor := IniOdColorList.Strings[j];
                if strColor <>  '' then begin
                  if Copy(strColor, 1, 2) = 'cl' then begin
                    SetOrdProp(TObj, pPropColor, StringToColor(strColor));
                  end else begin
                    try
                      nColor := StrToInt(strColor);
                    except
                      else nColor := -1;
                    end;
                    if nColor <> -1 then
                      SetOrdProp(TObj, pPropColor, nColor);
                  end;
                end;
              end;

            end;

          end;

        end;

      end;

    end;

    result := 0;

  finally

    if IniList <> nil then
      IniList.Free;
    if IniList2 <> nil then
      IniList2.Free;
    if IniFrColorList <> nil then
      IniFrColorList.Free;
    if IniBkColorList <> nil then
      IniBkColorList.Free;
    if IniFtColorList <> nil then
      IniFtColorList.Free;
    if IniFcColorList <> nil then                                               // 2000.10.05 追加
      IniFcColorList.Free;
    if IniOdColorList <> nil then
      IniOdColorList.Free;                                                      // 2000.10.05 追加
    if IniName <> nil then
      IniName.Free;

  end;


end;

//*********************************************************************//
//  Module Name : GetIniPath                                           //
//  引数        : 1 フルパス取得したいINI名                            //
//  戻り値      : 整数   0:正常終了                                    //
//              :        3:引数設定エラー                              //
//              :        5:取得エラー                                  //
//  Programer   : 鹿野　幸生                                           //
//  Date        : 2000.08.20                                           //
//---------------------------------------------------------------------//
//  Update Note : 200.1.02.20  鹿野　幸生                              //
//              : 200.1.02.22  鹿野　幸生                              //
//*********************************************************************//
function HGetIniPath(var istrSFLitePath: string): integer;
var
  i, nEndTerm: integer;
  strWkName: string;
  szIniKey: array [0..ctMAX_PATH-1] of Char;
  szWinPath: array [0..ctMAX_PATH-1] of Char;
  szText:    array [0..ctMAX_PATH-1] of Char;
  szKey:     array [0..ctMAX_PATH-1] of Char;
  szIniPath: array [0..ctMAX_PATH-1] of Char;
  szTrgtPath:array [0..ctMAX_PATH-1] of Char;
  szIniNo:array [0..9] of Char;                         // 2009.08.10 Ins


begin

  //  引数の妥当性検査
  if istrSFLitePath = '' then begin
    Result := 3;
    Exit;
  end;

// 2009.08.10 Ins Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
  // 基本IniファイルNoを設定
  case gnBaseIniNo of
    2 :  StrPCopy(szIniNo, '2');                         // 第二基本INIファイル使用宣言
    3 :  StrPCopy(szIniNo, '3');                         // 第三基本INIファイル使用宣言
    4 :  StrPCopy(szIniNo, '4');                         // 第四基本INIファイル使用宣言
    5 :  StrPCopy(szIniNo, '5');                         // 第五基本INIファイル使用宣言
    else StrPCopy(szIniNo, '');                          // 第一基本INIファイル使用宣言
  end;

  strWkName := ChangeFileExt(ExtractFileName(istrSFLitePath),'');

  StrPCopy(szIniKey, ExtractFileName(strWkName));
  StrCat(szIniKey, szIniNo);
// 2009.08.10 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<


  strWkName := ChangeFileExt(ExtractFileName(istrSFLitePath),'');

  StrPCopy(szIniKey, ExtractFileName(strWkName));

  ZeroMemory(@szIniPath, sizeof(szIniPath));

  //  Windowsディレクトリを取得
  GetWindowsDirectory(szWinPath, sizeof(szWinPath));
  StrCopy(szIniPath, szWinPath);
  if (szIniPath[StrLen(szIniPath)-1] <> '\') then begin
    StrCat(szIniPath, '\');
  end;

  //  Sfpath.iniを読み込む
//  StrCat(szIniPath, 'SFPATH.INI');                                            2001.02.20 変更 
  StrCat(szIniPath, ctSFPATHINI);
  if (GetPrivateProfileString('INIPATH', szIniKey, '', szText, sizeof(szText), szIniPath) <> 0) then begin

    StrCopy(szKey, szText);

    // HSSDBINIを取得(このキーが指定された時だけ特別)
    if UpperCase(Trim(istrSFLitePath)) = ctHSSBASEINI then begin
      if (GetPrivateProfileString('INIPATH', szKey, '', szText, sizeof(szText), szIniPath) = 0) then begin
        Result := 5;
        exit;
      end;
      // HSSBASEINIを参照したINIファイル名にすり替える
      StrCopy(szIniKey, szKey);
      StrCopy(szKey, szText);

     // HSSDBINIを取得(このキーが指定された時だけ特別)
    end else if UpperCase(Trim(istrSFLitePath)) = ctSFBASEINI then begin
      if (GetPrivateProfileString('INIPATH', szKey, '', szText, sizeof(szText), szIniPath) = 0) then begin
        Result := 5;
        exit;
      end;
      // HSSBASEINIを参照したINIファイル名にすり替える
      StrCopy(szIniKey, szKey);
      StrCopy(szKey, szText);
    end;

    if (GetPrivateProfileString('INIPATH', szKey, '', szText, sizeof(szText), szIniPath) = 0) then begin
      //  INIが取得できなかった場合、ひとつ上のディレクトリにあるかどうかやってみる
      GetCurrentDirectory(sizeof(szWinPath), szWinPath);

      if (szWinPath[StrLen(szWinPath)-1] <> '\') then begin
        StrCat(szWinPath, '\');
      end;

      //>> 2010.07.06 noguchi INIファイルが1つ上のディレクトリに作成される不具合解消
//      nEndTerm := 0;
//      for i := StrLen(szWinPath)-1 Downto 0 do begin
//        if (szWinPath[i] = '\') then begin
//          nEndTerm := i;
//          break;
//        end;
//      end;
//
//      for i := nEndTerm-1 downto 0 do begin
//        if (szWinPath[i] = '\') then begin
//          nEndTerm := i;
//          break;
//        end;
//      end;
//
//      if (nEndTerm > 2) then begin
//        StrLCopy(szTrgtPath, szWinPath, nEndTerm);
//      end;
        StrLCopy(szTrgtPath, szWinPath, StrLen(szWinPath));
      //>> 2010.07.06 noguchi INIファイルが1つ上のディレクトリに作成される不具合解消

    end else begin

      StrCopy(szTrgtPath, szText);

    end;

    Result := 0;

  end else begin

    // HSSBASEINI、SFBASEINIのキーが指定された時だけ特別
    if (UpperCase(Trim(istrSFLitePath)) = ctHSSBASEINI) or
       (UpperCase(Trim(istrSFLitePath)) = ctSFBASEINI) then begin
      Result := 5;
      exit;
    end;

    //  INIが取得できなかった場合、ひとつ上のディレクトリにあるかどうかやってみる
    GetCurrentDirectory(sizeof(szWinPath), szWinPath);
    if (szWinPath[StrLen(szWinPath)-1] <> '\') then begin
      StrCat(szWinPath, '\');
    end;

      //>> 2010.07.06 noguchi INIファイルが1つ上のディレクトリに作成される不具合解消
//    nEndTerm := 0;
//    for i := StrLen(szWinPath)-1 Downto 0 do begin
//      if (szWinPath[i] = '\') then begin
//        nEndTerm := i;
//        break;
//      end;
//    end;
//
//    for i := nEndTerm-1 downto 0 do begin
//      if (szWinPath[i] = '\') then begin
//        nEndTerm := i;
//        break;
//      end;
//    end;
//
//    if (nEndTerm > 2) then begin
//      StrLCopy(szTrgtPath, szWinPath, nEndTerm);
//    end;
      StrLCopy(szTrgtPath, szWinPath, StrLen(szWinPath));
      //>> 2010.07.06 noguchi INIファイルが1つ上のディレクトリに作成される不具合解消

    Result := 5;

  end;

  if (szTrgtPath[strlen(szTrgtPath)-1] <> '\') then begin
    StrCat(szTrgtPath, '\');
  end;

  //  引数のバッファに設定
  StrCat(szTrgtPath, szIniKey);
  StrCat(szTrgtPath, '.INI');

  istrSFLitePath := StrPas(szTrgtPath);


end;

// 2009.08.10 Del Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
(*
//*******************************************************************//
// Module Name   : ログ書き込み                                      //
//               : HWrtSysLog                                        //
// 引数          : 1 画面名称                                        //
//               : 2 処理名称                                        //
//               : 3 オペレーション内容                              //
//               : 4 メッセージ内容                                  //
//               : 5 ステータス                                      //
//               : 6 詳細内容                                        //
// 戻り値        : MessageBoxの戻り値                                //
// Programer     : 鹿野　幸生                                        //
// Date          : 2000.10.21                                        //
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function HWrtSysLog(istrPnm:String; istrProcNm:String; istrOperate: string;
                     istrMsg:String; istrSts:string; iDetailBuff: string): Integer;
var
  stLogData: tagLogData;
  stLoginInf: tagLoginInf;

begin

  Result := 0;

  // ログの書き出し
//  if LoadCtlALPBU0002(1) = True then begin                                    2001.02.26 変更
  if LoadCtlHLogAcs(1) = True then begin

    // ログイン情報取得
    HInitProc.HGetLoginInf(stLoginInf);

    // ログ情報セット
    ZeroMemory(@stLogData, sizeof(stLogData));
    with stLogData do begin
      if gnActivLogDataNo = 0 then                                  // ログタイプNoをセット 2001.03.04 追加
        nLogNo := 1
      else
        nLogNo := gnActivLogDataNo;
      szSysShu := 'L';                                               // ログデータ種別
      nSysTancd := stLoginInf.nTanCd;                                // 担当者コード
      StrLCopy(szSysTanNm, stLoginInf.szTanNm, sizeof(szSysTanNm));  // 担当者名称
      nSysSeclvdt := 0;                                              // ログデータオペレーターデータ処理レベル
      nSysSeclvfu := stLoginInf.nTanLevel;                           // ログデータオペレーター機能処理レベル
      StrPLCopy(szSysPid, stLoginInf.szPgExeId, sizeof(szSysPid));   // ログデータ対象プログラムＩＤ
      if (istrPnm = '-1') then                                       // ログデータ画面名称
        // メインフォーム
        StrPLCopy(szSysPnm, Application.MainForm.Caption, sizeof(szSysPnm))
      else if (istrPnm = '0') then
        // アクティブフォーム
        StrPLCopy(szSysPnm, Screen.ActiveForm.Caption, sizeof(szSysPnm))
      else
        // 引数文字列
        StrPLCopy(szSysPnm, istrPnm, sizeof(szSysPnm));
      StrPLCopy(szSysProc, istrProcNm, sizeof(szSysProc));           // ログデータ処理名称
      StrPLCopy(szSysOpe, istrOperate, sizeof(szSysOpe));            // ログデータオペレーション
      StrPLCopy(szSysMsg, istrMsg, sizeof(szSysMsg));                // ログデータメッセージ内容
      StrPLCopy(szSysSt, istrSts, sizeof(szSysSt));                  // ステータス
      StrPLCopy(szSysBuff, iDetailBuff, sizeof(szSysBuff))           // ログデータ詳細内容
    end;

    // 書き込み
    Result := pWrtSysLog(stLogData);

    // DLL解放
//    LoadCtlALPBU0002(0);                                                        2001.02.26 変更
    LoadCtlHLogAcs(0);
  end;

end;
*)
// 2009.08.10 Del End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

//**********************************************************************//
// Module Name     :  ＥＸＥ実行処理                                    //
//                 :  ExecFile                                          //
// 引数            :  1 EXEの実行方式(0:実行終了を待たない,1:待つ)      //
//                 :  2 実行ファイル名                                  //
//                 :  3 実行するファイルが有るディレクトリ名            //
//                 :  4 EXEに渡すパラメータ                             //
// 戻り値          :  1 整数 (0:正常, 5:異常終了)                       //
// Programer       :  鹿野　幸生                                        //
// Date            :  2000.11.28                                        //
//----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ＸＸ ＸＸ                             //
//**********************************************************************//
function HExecFile(inExeType: integer; istrExecFile: string; istrExecDir: string; istrParam: string): integer;
var
//  i:          integer;
  STARTINF  : TSTARTUPINFO;
  Process   : TPROCESSINFORMATION;
  hProcess  : longint;                                               // 終了時チェック用
  strExec   : string;
  szExecFile: array [0..256] of Char;

const
  SYNCHRONIZE = '$100000';
  INFINITE    = '$FFFFFFFF';
  
begin

  Result := 5;

  // 構造体初期化
  ZeroMemory(@Process, SizeOf(Process ));
  ZeroMemory(@STARTINF, SizeOf(STARTINF));

  // 構造体初期設定
  STARTINF.cb := SizeOf(STARTINF);

  if istrExecDir <> '' then begin
    if Copy(istrExecDir, Length(istrExecDir), 1) <> '\' then
      istrExecDir := istrExecDir + '\';
  end;

  strExec := istrExecDir + istrExecFile + ' ' + istrParam;

  ZeroMemory(@szExecFile, SizeOf(szExecFile) );
  StrPCopy  (@szExecFile, strExec);

  if CreateProcess(nil, @szExecFile, nil, nil, False, 0, nil, nil, STARTINF, Process) = TRUE then
    begin
      hProcess := OpenProcess(StrToInt(SYNCHRONIZE), false, Process.dwProcessId );

      //  起動プログラムの終了待ち
      if inExeType = 1 then
        WaitForSingleObject(hProcess,strtoint(INFINITE));
      CloseHandle(hProcess);
      Result := 0;
    end;

  // おまじない
  Sleep(3000);

end;


//**********************************************************************//
// Module Name     :  IME強制クローズ処理                               //
//                 :  HCloseIme                                         //
// 引数            :  1 対象コントロールorフォームハンドル              //
// 戻り値          :  1 整数 (0:正常, 5:異常終了)                       //
// Programer       :  鹿野　幸生                                        //
// Date            :  2001.01.23                                        //
//----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ＸＸ ＸＸ                             //
//**********************************************************************//
function HCloseIme(iwHandle: THandle): integer;
var
 imc: HIMC;
 
begin

  try

    imc := ImmGetContext(iwHandle);
    if imc <> 0 then begin
      ImmSetOpenStatus(imc, False);
      ImmReleaseContext(iwHandle, imc);
    end;

  finally

    Result := 0;
    
  end;

end;

// 2009.08.10 Del Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
(*
//**********************************************************************//
// Module Name     :  LOG書き出しNo設定                                 //
//                 :  HSetLogDataNo                                     //
// 引数            :  1 LOG書き出しNo                                   //
// 戻り値          :  1 整数 (0:正常, 5:異常終了)                       //
// Programer       :  鹿野　幸生                                        //
// Date            :  2001.03.04                                        //
//----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ＸＸ ＸＸ                             //
//**********************************************************************//
function HSetLogDataNo(inLogDataNo: smallint): integer;
begin

  // ゼロ以下はエラー
  if inLogDataNo <= 0 then begin
    Result := 5;
    exit;
  end;

  // アクティブNoに設定
  gnActivLogDataNo := inLogDataNo;

  Result := 0;

end;

//**********************************************************************//
// Module Name     :  現在LOG書き出しNo取得定                           //
//                 :  HCloseIme                                         //
// 引数            :  1 無し                                            //
// 戻り値          :  1 整数 (0:正常, 5:異常終了)                       //
// Programer       :  鹿野　幸生                                        //
// Date            :  2001.03.04                                        //
//----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ＸＸ ＸＸ                             //
//**********************************************************************//
function HGetLogDataNo: smallint;
begin

  // アクティブNoに設定
  Result := gnActivLogDataNo;

end;
*)
// 2009.08.10 Del End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

{*******************************************************************}
{ Module Name   : 使用基本IniNo取得                                 }
{               : HGetBaseIniNo                                     }
{ 引数          : 1 integer  追加オペランド                         }
{ 戻り値        : 1 integer  使用基本IniNo                          }
{ Programer     : 徳永　誠                                          }
{ Date          : 2009.08.10                                        }
{-------------------------------------------------------------------}
{ Update Note   : 200x.xx.xx ＸＸ　ＸＸ                             }
{*******************************************************************}
function HGetBaseIniNo(inOperand: integer=0): integer;                          // 2009.08.10 追加
begin

  Result := gnBaseIniNo;

end;

{*******************************************************************}
{ Module Name   : 使用基本IniNo設定                                 }
{               : HSetBaseIniNo                                     }
{ 引数          : 1 integer  使用基本IniNo                          }
{               : 2 integer  追加オペランド                         }
{ 戻り値        : 1 integer  結果 ゼロ:正常設定                     }
{               :                    5:設定失敗                     }
{ Programer     : 徳永　誠                                          }
{ Date          : 2009.08.10                                        }
{-------------------------------------------------------------------}
{ Update Note   : 200x.xx.xx ＸＸ　ＸＸ                             }
{*******************************************************************}
function HSetBaseIniNo(inIniNo:integer; inOperand: integer=0): integer;         // 2009.08.10 追加
begin

  if (inIniNo < 0) or (inIniNo > 5) then begin
    Result := 5;
    exit;
  end;

  gnBaseIniNo := inIniNo;

  Result := 0;

end;

// 2009.09.10 Ins Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//*******************************************************************//
// Module Name   : ログ出力DLLロード制御関数                         //
//               : LoadLogoutputDll                                  //
// 引数          : 1 DLLロード制御(1:LOAD, 0:UNLOAD)                 //
// 戻り値        : FALSE:失敗, TRUE:成功                             //
// Programer     : 徳永　誠                                          //
// Date          : 2009.10.10                                       //
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function LoadLogoutputDll(inFncType: integer): Boolean;
begin

  Result := False;

  if inFncType = 1 then begin

    //DLLが既にﾛｰﾄﾞ済みであればﾛｰﾄﾞ処理は行わない
    if ghndLogout = 0 then begin
      ghndLogout := LoadLibrary(ctLogout_DLL);
      if ghndLogout =0 then begin
        //ﾛｰﾄﾞ失敗
          HDspMsg(ERR_LEVEL_EXCLAMATION, 'HFSLLIB', GetPgNm, ctSecNameWrtLog, ctOPE_START,
            PChar(ctLogout_DLL + 'のロードに失敗しました'  + #13 + #13 + 'このエラーは記録されません'),
              GetLastError, nil, 0);
        Exit;
      end;
      //関数ｱﾄﾞﾚｽ取得
      pOutput := GetProcAddress(ghndLogout, 'Output');
      if @pOutput = nil then begin
          HDspMsg(ERR_LEVEL_EXCLAMATION, 'HFSLLIB', GetPgNm, ctSecNameWrtLog, ctOPE_START,
            PChar(ctLogout_DLL + 'で関数の取得に失敗しました' + #13 + #13 + 'このエラーは記録されません'),
              GetLastError, nil, 0);
        exit;
      end;
    end;

    Result := True;

  end else begin

    // DLLを解放する
    Result := FreeLibrary(ghndLogout);
    ghndLogout := 0;
    pOutput     := nil;

  end;


end;


// 2009.09.10 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

end.


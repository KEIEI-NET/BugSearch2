//****************************************************************************//
// System           : HSS100                                                  //
// Sub System       : HInitProc                                               //
// Program name     : プログラム初期化・終了共通関数部品                      //
//                  : HInitProc.pas                                           //
// Name Space       :                                                         //
// Programmer       : Kumagai                                                 //
// Date             : 2009.08.10                                              //
// Note             : HSS70から生成（機能大幅削除＆現在枠だけ）               //
//----------------------------------------------------------------------------//
// Update Note      :                                                         //
//                  :   2009.10.10 徳永　誠                                   //
//                  :      ①  HStrtExeへ認証部品組込                         //
//                  :   2010.04.23 徳永　誠                                   //
//                  :      ①  HStrtDllへ従業員等の認証部組込                 //
//                  :          ※但し、StartApplicationは実行しない           //
//                  :      ②  Debug用の未認証時の強制実行可能な部分を削除    //
//                  :   2010.06.16 徳永　誠                                   //
//                  :      ① ActiveReportsのライセンス情報をHStrtExe時に     //
//                  :         読み込むように変更                              //
//----------------------------------------------------------------------------//
//          (c)Copyright  2009 Broadleaf Co,. Ltd                             //
//****************************************************************************//
unit HInitProc;

interface

uses
  Windows, SysUtils, Classes, HFSLLIB, Dialogs,Forms;

const
  LOGIN_CHECK    = True;                                                        // ログインチェック     → 有り
  LOGIN_NOCHECK  = False;                                                       // ログインチェック     → 無し
  ERR_MSG_DISP   = True;                                                        // エラーメッセージ表示 → 有り
  ERR_MSG_NODISP = False;                                                       // エラーメッセージ表示 → 無し

type
  // ログイン情報
  tagLoginInf = record
    nGetflg   : integer;          // ログイン情報正常取得時:1 他:0

    nSysKbn:    integer;                                                        // システム区分
    szPgExeId:  array[0..50] of char;                                           // プログラムID
    szPgExeNm:  array[0..255] of char;                                          // プログラム名称
    szPgDllId:  array[0..50] of char;                                           // DLL プログラムID
    szPgDllNm:  array[0..255] of char;                                          // DLL プログラム名称
//    nPgLevel:   integer;                                                        // PGLEVEL
//    nTancd:     smallint;                                                       // 担当者コード
//    szTanNm:    array [0..29] of char;                                          // 担当者名称
//    nTanLevel:  integer;                                                        // 担当者LEVEL

    //従業員情報
    authorityLevel1 : integer;
    authorityLevel2 : integer;
    belongSectionCode : array [0..255] of char;
    employeeCode    : array [0..255] of char;
    enterpriseCode  : array [0..255] of char;
    kana            : array [0..255] of char;
    loginId         : array [0..255] of char;
    loginPassword   : array [0..255] of char;
    name            : array [0..255] of char;
  end;

  function HStrtExe(inSysId: integer; istrPgId: String; istrPgNm: String; ibLogin, ibFlgDspMsg: Boolean): integer;
  function HStrtDll(inSysId: integer; istrPgId: String; istrPgNm: String; ibLogin, ibFlgDspMsg: Boolean): integer;
  function HChkLogin(inSysId: integer; istrPgId: String): integer;
  function HEndExe: integer;
  function HEndExe2: integer;
  function HEndDll: integer;
  function HEndDll2: integer;
  function HGetLoginInf(var ostLoginInf: tagLoginInf): integer;
// 2009.10.10 Ins Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
  function LoadDllProc(inFncType: integer): Boolean;
  function LoadLoginInfoDll(inFncType: integer): Boolean;
  function HGetEnterpriseCode: String;
  function HGetLoginEmployeeCode: String;
  function HGetLoginEmployeeName: String;
  function HGetLoginEmployeeKana: String;
  function HGetLoginEmployeeBelongSectionCode: String;
  function HGetOnlineFlag: boolean;
  function HSoftwarePurchasedCheckForCompany(constantManagementkey: string): integer;
  function HSoftwarePurchasedCheckForUSB(constantManagementkey: string): integer;
// 2009.10.10 ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

implementation


const
  ctSecNameInit = '起動処理';
  ctAppStart  = 'NSCMN00607.DLL';                                                   // 処理名称
  ctConstMngt = 'NSCMN00615.DLL';
  ctARLicence = 'NSCMN00054M.DLL';                                              // 2010.06.17 Ins
  ctLoginInfo_DLL  = 'NSCMN00651.DLL';                                          // 2009.09.10 Ins
var
  gPrevExitProc:  Pointer;
  gnSysId:        integer;                                                      // システムコード
  gstLoginInf:    tagLoginInf;
  gSecStrtFlg:    integer = 0;                                                  // Exeタイプかどうか (0:EXE以外, 1:EXE)
  gnChkSysType:   integer = 0;                                                  // システムタイプ判断の区分 (0:データ入力タイプ, 1:プロテクタタイプ )
  gbDspMsg:       boolean;                                                      // 汎用のメッセージ表示有無 (True:表示有り, False:表示無し)
// 2009.10.10 Ins Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
  ghndAppStart:   THANDLE;
  ghndConstMngt:  THANDLE;
  ghndARLicence:  THANDLE;

  pStartApplication: function (out returnMsg: string ; productCode:string ; application:TApplication):integer; stdcall;
  pEndApplication: function (): Integer; stdcall;
  pConstantManagement_SF_PRO: function (productCode:string): string; stdcall;
  pActiveReportsLicence: function():Integer; stdcall;                           // 2010.06.17 Ins

  ghndLoginInfo  : THANDLE;
  pGetEnterpriseCode : function ():string ; stdcall;
  pGetEmployee : procedure (
    var authorityLevel1 : integer;
    var authorityLevel2 : integer;
    var belongSectionCode : string;
    var employeeCode : string;
    var enterpriseCode : string;
    var kana : string;
    var loginId : string;
    var loginPassword : string;
    var name : string
    ); stdcall;
  pGetOnlineFlag: function() :Boolean ; stdcall;
  pSoftwarePurchasedCheckForCompany: function (softwareCode : string):integer ; stdcall;
  pSoftwarePurchasedCheckForUSB: function (softwareCode : string):integer ; stdcall;
 // 2009.190.10 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<


{*******************************************************************}
{ Module Name   : プログラム初期処理関数(EXE用)                     }
{               : HStrtExe                                          }
{ 引数          : 1 integer  システムコード                         }
{               : 2 String   プログラムID                           }
{               : 3 String   プログラム名称                         }
{               : 4 Boolean  ﾛｸﾞｲﾝﾁｪｯｸ有無(False:無し,True:有り)    }
{               : 5 Boolean  ﾒｯｾｰｼﾞ出力有無(False:無し,True:有り)   }
{ 戻り値        : 1 integer  起動可否 0:起動可                      }
{               :                     5:起動不可(ﾛｸﾞｲﾝﾁｪｯｸNG)       }
{ Programer     : Kumagai                                           }
{ Date          : 2009.08.10                                        }
{ Note          : EXE用プログラム初期処理                           }
{-------------------------------------------------------------------}
{ Update Note   : 200x.xx.xx  ＸＸ　ＸＸ                            }
{*******************************************************************}
function HStrtExe(inSysId: integer; istrPgId: String; istrPgNm: String; ibLogin, ibFlgDspMsg: Boolean): integer;
var
  nRtnCd : smallint;
  returnMsg : string;
  productCode:string;

  //従業員情報
  belongSectionCode : string;
  employeeCode : string;
  enterpriseCode : string;
  kana : string;
  loginId : string;
  loginPassword : string;
  name : string;
begin

  nRtnCd := 0;

  gSecStrtFlg   := 1;                                                           // Exeタイプ
  gnChkSysType  := 1;                                                           // システム判断をプロテクタコードで見るように設定

  // メッセージ出力区分を関数のパラメータ通りに設定
  gbDspMsg := ibFlgDspMsg;

  // プログラム情報を内部に保存
  gnSysId := inSysId;
  StrPCopy(gstLoginInf.szPgExeId, istrPgId);
  StrPCopy(gstLoginInf.szPgExeNm, istrPgNm);

  // HFSLLIB側にも設定
  HFslLib.SetPgInfo(0, istrPgId, istrPgNm);

  // 終了処理部を追加
  gPrevExitProc := ExitProc;
  ExitProc      := @HEndExe2;

{  // ログインチェック
  if ibLogin = True then begin
    nRtnCd := HChkLogin( inSysId, istrPgId );
    if nRtnCd <> 0 then begin
      if (nRtnCd = 5) and (ibFlgDspMsg = True) then begin
        HDspMsg(0, 'HInitProc', istrPgNm, ctSecNameInit, 'LOGIN', PChar('この機能を使用する為の権限が有りません'+#13 + #13 + istrPgId +' は起動できません'), nRtnCd, nil, 0);
      end;
      Result := nRtnCd;
      exit;
    end;
  end;
}
  { 初期処理系 }
  try
    try
      if LoadDllProc(1) = true then
      begin
        if LoadLoginInfoDll(1) = true then
        begin
          productCode := pConstantManagement_SF_PRO('productcode');

          //productCode := 'Partsman';    // 仮組 とりあえずPartsmanにしておく
          //アプリケーション開始準備処理。第二パラメータはアプリケーションのソフトウェアコードが指定出来る場合は指定。出来ない場合はプロダクトコード
          nRtnCd := pStartApplication(returnMsg, productCode, Application);
          if ( nRtnCd = 0) then begin

            //従業員情報の取得
            pGetEmployee(
              gstLoginInf.authorityLevel1,
              gstLoginInf.authorityLevel2,
              belongSectionCode,
              employeeCode,
              enterpriseCode,
              kana,
              loginId,
              loginPassword,
              name
            );
            StrPCopy(gstLoginInf.belongSectionCode, belongSectionCode);
            StrPCopy(gstLoginInf.employeeCode, employeeCode);
            StrPCopy(gstLoginInf.enterpriseCode, enterpriseCode);
            StrPCopy(gstLoginInf.kana, kana);
            StrPCopy(gstLoginInf.loginId, loginId);
            StrPCopy(gstLoginInf.loginPassword, loginPassword);
            StrPCopy(gstLoginInf.name, name);

            gstLoginInf.nGetflg := 1;

            pActiveReportsLicence();    // 2010.06.17 Ins ActiveReportsライセンスの取得
          end else begin
            HDspMsg(ERR_LEVEL_EXCLAMATION, 'HInitProc', istrPgNm, ctSecNameInit, 'LOGIN', returnMsg +#13 + #13 + istrPgId +' は起動できません', nRtnCd, nil, 0);
            Result := nRtnCd;
          end;
        end
        else begin
          nRtnCd := 4;
          Result := nRtnCd;
        end;
      end
      else begin
        nRtnCd := 4;
        Result := nRtnCd;
      end;
    except
      on e: Exception do
      begin
        ShowMessage('emErrorLevel' + istrPgId + e.Message);
        nRtnCd := 4;
      end;
    end;
  Finally
//    EndApplication ;
  end;


  gnChkSysType  := 0;                                                           // システムチェックタイプを以後パラメータ通りに設定
  gbDspMsg      := True;                                                        // 以降はメッセージ表示は有りに設定

// 20100426 Del Start Debug用削除>>>>>>>>>>
{
// Debug用仮>>>>>>>>>>
  if nRtnCd <> 0 then
  begin
    HDspMsg(ERR_LEVEL_EXCLAMATION, 'HInitProc', istrPgNm, ctSecNameInit, 'LOGIN', 'DEBUGモードとして強制実行します', nRtnCd, nil, 0);
    StrPCopy(gstLoginInf.belongSectionCode, '01');
    StrPCopy(gstLoginInf.employeeCode, '0001');
    StrPCopy(gstLoginInf.enterpriseCode, '0101150842020100');
    StrPCopy(gstLoginInf.kana, 'テストタントウシャ');
    StrPCopy(gstLoginInf.loginId, '0001');
    StrPCopy(gstLoginInf.loginPassword, '0001');
    StrPCopy(gstLoginInf.name, 'テスト担当者');
    nRtnCd := 0;
  end;
// Debug用仮<<<<<<<<<
}
// 20100426 Del Start Debug用削除<<<<<<<<<

  // 正常終了
  Result := nRtnCd;

end;

{*******************************************************************}
{ Module Name   : プログラム初期処理関数(DLL用)                     }
{               : EXEWがC#の場合に使用する。C#側PGで認証済みの事    }
{               : HStrtDll                                          }
{ 引数          : 1 integer  システムコード                         }
{               : 2 String   プログラムID                           }
{               : 3 String   プログラム名称                         }
{               : 4 Boolean  ﾛｸﾞｲﾝﾁｪｯｸ有無(False:無し,True:有り)    }
{               : 5 Boolean  ﾒｯｾｰｼﾞ出力有無(False:無し,True:有り)   }
{ 戻り値        : 1 integer  起動可否 0:起動可                      }
{               :                     5:起動不可(ﾛｸﾞｲﾝﾁｪｯｸNG)       }
{ Programer     : Tokunaga                                          }
{ Date          : 2010.04.26                                        }
{ Note          : DLL用プログラム初期処理                           }
{-------------------------------------------------------------------}
{ Update Note   : 200x.xx.xx  ＸＸ　ＸＸ                            }
{*******************************************************************}
function HStrtDll(inSysId: integer; istrPgId: String; istrPgNm: String; ibLogin, ibFlgDspMsg: Boolean): integer;
var
  st : integer;
  // 2010.04.26 Ins Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
  nRtnCd : smallint;
  //従業員情報
  belongSectionCode : string;
  employeeCode : string;
  enterpriseCode : string;
  kana : string;
  loginId : string;
  loginPassword : string;
  name : string;
  // 2010.04.26 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
begin

  if( gSecStrtFlg <> 1 ) then                                                   // 既にgSecStrtFlgに1が入っている場合はそのまま
    gSecStrtFlg := 0;                                                           // StrtDLLが直接呼び出された場合は０を設定

  gnChkSysType := 1;                                                            // システム判断をプロテクタコードで見るように設定

  // メッセージ出力区分を内部セット
  gbDspMsg := ibFlgDspMsg;

  // プログラム情報を内部に保存
  gnSysId := inSysId;
  StrPCopy(gstLoginInf.szPgDllId, istrPgId);
  StrPCopy(gstLoginInf.szPgDllNm, istrPgNm);

  // HFSLLIB側にも設定
  HFslLib.SetPgInfo(1, istrPgId, istrPgNm);

  // 2010.04.26 Del Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
  {
  // ログインチェック
  if ibLogin = True then begin
    st := HChkLogin( inSysId, istrPgId );                                       // 2000.08.02 追加
    if st <> 0 then begin                                                       // 2000.08.02 変更
      if (st = 5) and (ibFlgDspMsg = True) then begin
        HDspMsg(0, 'HInitProc', istrPgNm, ctSecNameInit, 'LOGIN', PChar('この機能を使用する為の権限が有りません'+#13 + #13 + istrPgId +' は起動できません'), st, nil, 0);
      end;
      Result := st;
      exit;
    end;
  end;
  }
  // 2010.04.26 Del End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

  // 2010.04.26 Ins Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
  // 終了処理部を追加
//  gPrevExitProc := ExitProc;
//  ExitProc      := @HEndExe2;

  nRtnCd := 0;

  { 初期処理系 }
  try
    try
      // 認証情報取得済みの場合は何もしない
      if gstLoginInf.nGetflg = 1 then
      begin
        nRtnCd := 0;
        Result := nRtnCd;
      end
      // 認証情報取得されていない場合は認StartApplicationを飛ばして、従業員情報
      // を取得する（親C#側PGが認証済みのはずの為）
      else begin
        if LoadDllProc(1) = true then
        begin
          if LoadLoginInfoDll(1) = true then
          begin
            //従業員情報の取得
            pGetEmployee(
              gstLoginInf.authorityLevel1,
              gstLoginInf.authorityLevel2,
              belongSectionCode,
              employeeCode,
              enterpriseCode,
              kana,
              loginId,
              loginPassword,
              name
            );
            StrPCopy(gstLoginInf.belongSectionCode, belongSectionCode);
            StrPCopy(gstLoginInf.employeeCode, employeeCode);
            StrPCopy(gstLoginInf.enterpriseCode, enterpriseCode);
            StrPCopy(gstLoginInf.kana, kana);
            StrPCopy(gstLoginInf.loginId, loginId);
            StrPCopy(gstLoginInf.loginPassword, loginPassword);
            StrPCopy(gstLoginInf.name, name);

            gstLoginInf.nGetflg := 1;

            pActiveReportsLicence();    // 2010.06.17 Ins ActiveReportsライセンスの取得
          end
          else begin
            nRtnCd := 4;
            Result := nRtnCd;
          end;
        end
        else begin
          nRtnCd := 4;
          Result := nRtnCd;
        end;
      end;
    except
      on e: Exception do
      begin
        ShowMessage('emErrorLevel' + istrPgId + e.Message);
        nRtnCd := 4;
      end;
    end;
  Finally
//    EndApplication ;
  end;
  // 2010.04.26 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

  { 初期処理系 }

  gnChkSysType  := 0;                                                           // システムチェックタイプを以後パラメータ通りに設定
  gbDspMsg      := True;                                                        // 以降はメッセージ表示は有りに設定

  // 正常終了
//  Result := 0;      // 2010.04.26 Del
  Result := nRtnCd;   // 2010.04.26 Ins

end;

{*******************************************************************}
{ Module Name   : ログインチェック                                  }
{               : HChkLogin                                         }
{ 引数          : 1 integer  システムコード                         }
{               : 2 String   プログラムID                           }
{ 戻り値        : 1 integer  起動可否 0:起動可                      }
{                                     5:起動不可                    }
{ Programer     : Kumagai                                           }
{ Date          : 2009.08.10                                        }
{ Note          : ログインチェックを行う                            }
{-------------------------------------------------------------------}
{ Update Note   : 200x.xx.xx  ＸＸ　ＸＸ                            }
{*******************************************************************}
function HChkLogin(inSysId: integer; istrPgId: String): integer;
begin

  Result := 0;

end;

{*******************************************************************}
{ Module Name   : プログラム終了処理関数(EXE用)                     }
{               : HEndExe                                           }
{ 引数          : 1          無し                                   }
{ 戻り値        : 1 integer  ダミー                                 }
{ Programer     : Kumagai                                           }
{ Date          : 2009.08.10                                        }
{ Note          : EXE用プログラム終了処理                           }
{-------------------------------------------------------------------}
{ Update Note   : 200x.xx.xx  ＸＸ　ＸＸ                            }
{*******************************************************************}
function HEndExe: integer;
begin
  if ( ghndAppStart <> 0) then
    pEndApplication();

  Result := 0;

end;

{*******************************************************************}
{ Module Name   : プログラム終了処理関数2(EXE - ExitPorc用)         }
{               : HEndExe2                                          }
{ 引数          : 1          無し                                   }
{ 戻り値        : 1 integer  ダミー                                 }
{ Programer     : Kumagai                                           }
{ Date          : 2009.08.10                                        }
{ Note          : EXE用プログラム終了処理                           }
{-------------------------------------------------------------------}
{ Update Note   : 200x.xx.xx  ＸＸ　ＸＸ                            }
{*******************************************************************}
function HEndExe2: integer;
begin

  // ExitProcを戻す
  ExitProc := gPrevExitProc;

  Result := 0;

end;

{*******************************************************************}
{ Module Name   : プログラム終了処理関数(DLL用)                     }
{               : HEndDll                                           }
{ 引数          : 1          無し                                   }
{ 戻り値        : 1 integer  ダミー                                 }
{ Programer     : Kumagai                                           }
{ Date          : 2009.08.10                                        }
{ Note          : DLL用プログラム終了処理                           }
{-------------------------------------------------------------------}
{ Update Note   : 200x.xx.xx  ＸＸ　ＸＸ                            }
{*******************************************************************}
function HEndDll: integer;
begin

  Result := 0;

end;

{*******************************************************************}
{ Module Name   : プログラム終了処理関数(DLL - ExitProc用)          }
{               : HEndDll2                                          }
{ 引数          : 1          無し                                   }
{ 戻り値        : 1 integer  ダミー                                 }
{ Programer     : Kumagai                                           }
{ Date          : 2009.08.10                                        }
{ Note          : DLL用プログラム終了処理                           }
{-------------------------------------------------------------------}
{ Update Note   : 200x.xx.xx  ＸＸ　ＸＸ                            }
{*******************************************************************}
function HEndDll2: integer;
begin

  Result := 0;

end;

{*******************************************************************}
{ Module Name   : ログイン情報取得                                  }
{               : HGetLoginTancd                                    }
{ 引数          : 1 tagLoginInf  ログイン情報                       }
{ 戻り値        : 1 integer      ダミー                             }
{ Programer     : Kumagai                                           }
{ Date          : 2009.08.10                                        }
{-------------------------------------------------------------------}
{ Update Note   :                                                   }
{*******************************************************************}
function HGetLoginInf(var ostLoginInf: tagLoginInf): integer;
begin
{    ostLoginInf.nSysKbn := gstLoginInf.nSysKbn;
    ostLoginInf.szPgExeId := gstLoginInf.szPgExeId;                                           // プログラムID
    ostLoginInf.szPgExeNm := gstLoginInf.szPgExeNm;                                          // プログラム名称
    ostLoginInf.szPgDllId := gstLoginInf.szPgDllId;                                           // DLL プログラムID
    ostLoginInf.szPgDllNm := gstLoginInf.szPgDllNm;
    ostLoginInf.authorityLevel1 := gstLoginInf.authorityLevel1;
    ostLoginInf.authorityLevel2 := gstLoginInf.authorityLevel2;
    ostLoginInf.belongSectionCode := gstLoginInf.belongSectionCode;
    ostLoginInf.employeeCode := gstLoginInf.employeeCode;
    ostLoginInf.enterpriseCode := gstLoginInf.enterpriseCode;
    ostLoginInf.kana := gstLoginInf.kana;
    ostLoginInf.loginId := gstLoginInf.loginId;
    ostLoginInf.loginPassword := gstLoginInf.loginPassword;
    ostLoginInf.name := gstLoginInf.name;
}
  CopyMemory(@ostLoginInf, @gstLoginInf, sizeof(gstLoginInf));

  Result := 0;

end;

// 2009.09.10 Ins Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//*******************************************************************//
// Module Name   :DLLロード制御関数                                   //
//               : LoadDllProc                                        //
// 引数          : 1 DLLロード制御(1:LOAD, 0:UNLOAD)                 //
// 戻り値        : FALSE:失敗, TRUE:成功                             //
// Programer     : 徳永　誠                                          //
// Date          : 2009.10.10                                       //
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function LoadDllProc(inFncType: integer): Boolean;
begin

  Result := False;

  if inFncType = 1 then begin

    //DLLが既にﾛｰﾄﾞ済みであればﾛｰﾄﾞ処理は行わない
    if ghndAppStart = 0 then begin
      ghndAppStart := LoadLibrary(ctAppStart);
      if ghndAppStart =0 then begin
        //ﾛｰﾄﾞ失敗
          HDspMsg(ERR_LEVEL_EXCLAMATION, 'HInitProc', GetPgNm, 'LoadDllProc', ctOPE_START,
            PChar(ctAppStart + 'のロードに失敗しました' + #13 + '起動できません'),
              GetLastError, nil, 0);
        Exit;
      end;
      //関数ｱﾄﾞﾚｽ取得
      pStartApplication := GetProcAddress(ghndAppStart, 'StartApplication');
      if @pStartApplication = nil then begin
          HDspMsg(ERR_LEVEL_EXCLAMATION, 'HInitProc', GetPgNm, 'LoadDllProc', ctOPE_START,
            PChar(ctAppStart + 'で関数の取得に失敗しました' + #13 + '起動できません' ),
              GetLastError, nil, 0);
        exit;
      end;
      //関数ｱﾄﾞﾚｽ取得
      pEndApplication := GetProcAddress(ghndAppStart, 'EndApplication');
      if @pEndApplication = nil then begin
          HDspMsg(ERR_LEVEL_EXCLAMATION, 'HInitProc', GetPgNm, 'LoadDllProc', ctOPE_START,
            PChar(ctAppStart + 'で関数の取得に失敗しました' + #13 + '起動できません' ),
              GetLastError, nil, 0);
        exit;
      end;
    end;

    //DLLが既にﾛｰﾄﾞ済みであればﾛｰﾄﾞ処理は行わない
    if ghndConstMngt = 0 then begin
      ghndConstMngt := LoadLibrary(ctConstMngt);
      if ghndConstMngt =0 then begin
        //ﾛｰﾄﾞ失敗
          HDspMsg(ERR_LEVEL_EXCLAMATION, 'HInitProc', GetPgNm, 'LoadDllProc', ctOPE_START,
            PChar(ctConstMngt + 'のロードに失敗しました' + #13 + '起動できません'),
              GetLastError, nil, 0);
        Exit;
      end;
      //関数ｱﾄﾞﾚｽ取得
      pConstantManagement_SF_PRO := GetProcAddress(ghndConstMngt, 'ConstantManagement_SF_PRO');
      if @pConstantManagement_SF_PRO = nil then begin
          HDspMsg(ERR_LEVEL_EXCLAMATION, 'HInitProc', GetPgNm, 'LoadDllProc', ctOPE_START,
            PChar(ctConstMngt + 'で関数の取得に失敗しました' + #13 + '起動できません'),
              GetLastError, nil, 0);
        exit;
      end;
    end;

    // 2010.06.17 Ins Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    //DLLが既にﾛｰﾄﾞ済みであればﾛｰﾄﾞ処理は行わない
    if ghndARLicence = 0 then begin
      ghndARLicence := LoadLibrary(ctARLicence);
      if ghndARLicence =0 then begin
        //ﾛｰﾄﾞ失敗
          HDspMsg(ERR_LEVEL_EXCLAMATION, 'HInitProc', GetPgNm, 'LoadDllProc', ctOPE_START,
            PChar(ctARLicence + 'のロードに失敗しました' + #13 + '起動できません'),
              GetLastError, nil, 0);
        Exit;
      end;
      //関数ｱﾄﾞﾚｽ取得
      pActiveReportsLicence := GetProcAddress(ghndARLicence, 'CreateInstance');
      if @pActiveReportsLicence = nil then begin
          HDspMsg(ERR_LEVEL_EXCLAMATION, 'HInitProc', GetPgNm, 'LoadDllProc', ctOPE_START,
            PChar(ctARLicence + 'で関数の取得に失敗しました' + #13 + '起動できません'),
              GetLastError, nil, 0);
        exit;
      end;
    end;
    // 2010.06.17 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<


    Result := True;

  end else begin

    // DLLを解放する
    if ghndAppStart <> 0 then
    begin
      Result := FreeLibrary(ghndAppStart);
      ghndAppStart := 0;
      pStartApplication := nil;
      pEndApplication := nil;
    end;

    if ghndConstMngt <> 0 then
    begin
      Result := FreeLibrary(ghndConstMngt);
      ghndConstMngt := 0;
      pConstantManagement_SF_PRO := nil;
    end;

    // 2010.06.17 Ins Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    if ghndARLicence <> 0 then
    begin
      Result := FreeLibrary(ghndARLicence);
      ghndARLicence := 0;
      pActiveReportsLicence := nil;
    end;
    // 2010.06.17 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
  end;


end;

//*******************************************************************//
// Module Name   : ログイン情報取得DLLロード制御関数                 //
//               : LoadLoginInfoDll                                  //
// 引数          : 1 DLLロード制御(1:LOAD, 0:UNLOAD)                 //
// 戻り値        : FALSE:失敗, TRUE:成功                             //
// Programer     : 徳永　誠                                          //
// Date          : 2009.10.10                                       //
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function LoadLoginInfoDll(inFncType: integer): Boolean;
begin

  Result := False;

  if inFncType = 1 then begin

    //DLLが既にﾛｰﾄﾞ済みであればﾛｰﾄﾞ処理は行わない
    if ghndLoginInfo = 0 then begin
      ghndLoginInfo := LoadLibrary(ctLoginInfo_DLL);
      if ghndLoginInfo =0 then begin
        //ﾛｰﾄﾞ失敗
          HDspMsg(0, 'HInitProc', GetPgNm, 'LoadLoginInfoDll', ctOPE_START,
            PChar(ctLoginInfo_DLL + 'のロードに失敗しました'),
              GetLastError, nil, 0);
        Exit;
      end;
      //関数ｱﾄﾞﾚｽ取得
      pGetEnterpriseCode := GetProcAddress(ghndLoginInfo, 'GetEnterpriseCode');
      if @pGetEnterpriseCode = nil then begin
          HDspMsg(0, 'HInitProc', GetPgNm, 'LoadLoginInfoDll', ctOPE_START,
            PChar(ctLoginInfo_DLL + 'で関数の取得に失敗しましたA'),
              GetLastError, nil, 0);
        exit;
      end;
      //関数ｱﾄﾞﾚｽ取得
      pGetEmployee := GetProcAddress(ghndLoginInfo, 'GetEmployee');
      if @pGetEmployee = nil then begin
          HDspMsg(0, 'HInitProc', GetPgNm, 'LoadLoginInfoDll', ctOPE_START,
            PChar(ctLoginInfo_DLL + 'で関数の取得に失敗しましたB'),
              GetLastError, nil, 0);
        exit;
      end;
      //関数ｱﾄﾞﾚｽ取得
      pGetOnlineFlag := GetProcAddress(ghndLoginInfo, 'GetOnlineFlag');
      if @pGetOnlineFlag = nil then begin
          HDspMsg(0, 'HInitProc', GetPgNm, 'LoadLoginInfoDll', ctOPE_START,
            PChar(ctLoginInfo_DLL  + 'で関数の取得に失敗しましたC'),
              GetLastError, nil, 0);
        exit;
      end;
      //関数ｱﾄﾞﾚｽ取得
      pSoftwarePurchasedCheckForCompany := GetProcAddress(ghndLoginInfo, 'SoftwarePurchasedCheckForCompany');
      if @pSoftwarePurchasedCheckForCompany = nil then begin
          HDspMsg(0, 'HInitProc', GetPgNm, 'LoadLoginInfoDll', ctOPE_START,
            PChar(ctLoginInfo_DLL  + 'で関数の取得に失敗しましたD'),
              GetLastError, nil, 0);
        exit;
      end;
      //関数ｱﾄﾞﾚｽ取得
      pSoftwarePurchasedCheckForUSB := GetProcAddress(ghndLoginInfo, 'SoftwarePurchasedCheckForUSB');
      if @pSoftwarePurchasedCheckForUSB = nil then begin
          HDspMsg(0, 'HInitProc', GetPgNm, 'LoadLoginInfoDll', ctOPE_START,
            PChar(ctLoginInfo_DLL  + 'で関数の取得に失敗しましたE'),
              GetLastError, nil, 0);
        exit;
      end;

    end;

    Result := True;

  end else begin

    // DLLを解放する
    if ghndLoginInfo <> 0 then
    begin
      Result := FreeLibrary(ghndLoginInfo);
      ghndLoginInfo := 0;
      pGetEnterpriseCode := nil;
      pGetEmployee := nil;
      pGetOnlineFlag := nil;
      pSoftwarePurchasedCheckForCompany := nil;
      pSoftwarePurchasedCheckForUSB := nil;
    end;

  end;


end;

//*******************************************************************//
// Module Name   : 企業コード取得関数                                //
//               : HGetEnterpriseCode                                //
// 引数          : 無し                                              //
// 戻り値        : String 企業コード                                 //
// Programer     : 徳永　誠                                          //
// Date          : 2009.10.10                                        //
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function HGetEnterpriseCode: String;
begin
  result := gstLoginInf.enterpriseCode;
end;

//*******************************************************************//
// Module Name   : ログイン従業員コード取得関数                      //
//               : HGetLoginEmployeeCode                             //
// 引数          : 無し                                              //
// 戻り値        : String 従業員コード                               //
// Programer     : 徳永　誠                                          //
// Date          : 2009.10.10                                        //
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function HGetLoginEmployeeCode: String;
begin
  result := gstLoginInf.employeeCode;
end;

//*******************************************************************//
// Module Name   : ログイン従業員名取得関数                          //
//               : HGetLoginEmployeeName                             //
// 引数          : 無し                                              //
// 戻り値        : String 従業員名称                                 //
// Programer     : 徳永　誠                                          //
// Date          : 2009.10.10                                        //
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function HGetLoginEmployeeName: String;
begin
  result := gstLoginInf.name;
end;


//*******************************************************************//
// Module Name   : ログイン従業員カナ取得関数                        //
//               : HGetLoginEmployeeKana                             //
// 引数          : 無し                                              //
// 戻り値        : String 従業員カナ                                 //
// Programer     : 徳永　誠                                          //
// Date          : 2009.10.10                                        //
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function HGetLoginEmployeeKana: String;
begin
  result := gstLoginInf.kana;
end;

//*******************************************************************//
// Module Name   : ログイン従業員所属拠点取得関数                    //
//               : HGetLoginEmployeeBelongSectionCode                //
// 引数          : 無し                                              //
// 戻り値        : String 所属拠点コード                             //
// Programer     : 徳永　誠                                          //
// Date          : 2009.10.10                                        //
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function HGetLoginEmployeeBelongSectionCode: String;
begin
  result := gstLoginInf.belongSectionCode;
end;

//*******************************************************************//
// Module Name   : オンラインフラグ取得関数                          //
//               : HGetOnlineFlag                                    //
// 引数          : 無し                                              //
// 戻り値        : boolean True:オンライン/False:オフライン          //
// Programer     : 徳永　誠                                          //
// Date          : 2009.10.10                                        //
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function HGetOnlineFlag: boolean;
begin
  if gstLoginInf.nGetflg = 1 then   // 認証OKならば
    result := pGetOnlineFlag()
  else
    result := false;
end;

//*******************************************************************//
// Module Name   : 企業の契約ソフトウェア情報関数                    //
//               : HSoftwarePurchasedCheckForCompany                 //
// 引数          : 1 string ソフトウェアコード                       //
// 戻り値        : integer チェック結果                              //
// Programer     : 徳永　誠                                          //
// Date          : 2009.10.10                                        //
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function HSoftwarePurchasedCheckForCompany(constantManagementkey: string): integer;
begin
  if gstLoginInf.nGetflg = 1 then   // 認証OKならば
    result := pSoftwarePurchasedCheckForCompany(pConstantManagement_SF_PRO((constantManagementkey)))
  else
    result := 0;                    // 認証NGならばUncontractを返す
end;

//*******************************************************************//
// Module Name   : 企業の契約ソフトウェア情報関数                    //
//               : HSoftwarePurchasedCheckForUSB                    //
// 引数          : 1 string ソフトウェアコード                       //
// 戻り値        : integer チェック結果                              //
// Programer     : 徳永　誠                                          //
// Date          : 2009.10.10                                        //
//-------------------------------------------------------------------//
// Update Note   :                                                   //
//*******************************************************************//
function HSoftwarePurchasedCheckForUSB(constantManagementkey: string): integer;
begin
  if gstLoginInf.nGetflg = 1 then   // 認証OKならば
    result := pSoftwarePurchasedCheckForUSB(pConstantManagement_SF_PRO((constantManagementkey)))
  else
    result := 0;                    // 認証NGならばUncontractを返す
end;

(*============================================================================*)
(*  終了処理部                                                                *)
(*============================================================================*)
initialization

finalization

   LoadLoginInfoDll(0);
   LoadDllProc(0);

// 2009.09.10 Ins End <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

end.

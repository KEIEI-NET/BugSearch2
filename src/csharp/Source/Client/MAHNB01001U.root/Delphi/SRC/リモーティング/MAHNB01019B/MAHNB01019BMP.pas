unit MAHNB01019BMP;

interface

uses
    ShareMem, SysUtils, Classes, HDllCall, HFSLLIB, MAHNB01019C, Forms;

type
    TDataModule1 = class(TDataModule)
        HDllCall1: THDllCall;
        private
            { Private 宣言 }
        public
            { Public 宣言 }
    end;

    /////////////////// 仲介クラスからのインポート関数型宣言 /////////////////

    // 売上入力で使用する初期データをＤＢより取得メソッド型
    TxSalesSlipInputInitDataAcs_ReadInitData = function(enterpriseCode: WideString;
    sectionCode: WideString): Integer; stdcall;

    // 売上入力で使用する初期データをＤＢより取得メソッド型
    TxSalesSlipInputInitDataAcs_ReadInitDataSecond = function(enterpriseCode: WideString;
    sectionCode: WideString): Integer; stdcall;

    // 売上入力で使用する初期データをＤＢより取得メソッド型
    TxSalesSlipInputInitDataAcs_ReadInitDataThird = function(enterpriseCode: WideString;
    sectionCode: WideString): Integer; stdcall;

    // 売上入力で使用する初期データをＤＢより取得メソッド型
    TxSalesSlipInputInitDataAcs_ReadInitDataFourth = function(enterpriseCode: WideString;
    sectionCode: WideString): Integer; stdcall;

    // 売上入力で使用する初期データをＤＢより取得メソッド型
    TxSalesSlipInputInitDataAcs_ReadInitDataFifth = function(enterpriseCode: WideString;
    sectionCode: WideString): Integer; stdcall;

        // 売上入力で使用する初期データをＤＢより取得メソッド型
    TxSalesSlipInputInitDataAcs_ReadInitDataSixth = function(enterpriseCode: WideString;
    sectionCode: WideString): Integer; stdcall;

        // 売上入力で使用する初期データをＤＢより取得メソッド型
    TxSalesSlipInputInitDataAcs_ReadInitDataSeventh = function(enterpriseCode: WideString;
    sectionCode: WideString): Integer; stdcall;

        // 売上入力で使用する初期データをＤＢより取得メソッド型
    TxSalesSlipInputInitDataAcs_ReadInitDataEighth = function(enterpriseCode: WideString;
    sectionCode: WideString): Integer; stdcall;

        // 売上入力で使用する初期データをＤＢより取得メソッド型
    TxSalesSlipInputInitDataAcs_ReadInitDataNinth = function(enterpriseCode: WideString;
    sectionCode: WideString): Integer; stdcall;

        // 売上入力で使用する初期データをＤＢより取得メソッド型
    TxSalesSlipInputInitDataAcs_ReadInitDataTenth = function(enterpriseCode: WideString;
    sectionCode: WideString): Integer; stdcall;

    // オプション情報処理メソッド型
    TxSalesSlipInputInitDataAcs_GetOptInfo = function(var optCarMng: Integer;
                                                      var optFreeSearch: Integer;
                                                      var optPcc: Integer;
                                                      var optRCLink: Integer;
                                                      var optUoe: Integer;
                                                      var optStockingPayment: Integer;
                                                      var optScm: Integer;
                                                      var opt_QRMail: Integer;
                                                      var opt_DateCtrl: Integer; // ADD T.Miyamoto 2012/11/13
                                                      var opt_NoBuTo: Integer  // ADD 譚洪 K2014/01/22
                                                     ): Integer; stdcall;

// --- ADD 2012/12/21 T.Miyamoto ------------------------------>>>>>
    // 山形部品オプション情報処理
    TxSalesSlipInputInitDataAcs_GetYamagataOptInfo = function(var optStockEntCtrl: Integer;
                                                              var optStockDateCtrl: Integer;
                                                              var optSalesCostCtrl: Integer
                                                             ): Integer; stdcall;
// --- ADD 2012/12/21 T.Miyamoto ------------------------------<<<<<

    // 端末管理マスタメソッド型
    TxSalesSlipInputInitDataAcs_GetPosTerminalMg = function(var resultPosTerminalMg: TPosTerminalMg): Integer; stdcall;

    // -- Add St 2012.07.23 30182 R.Tachiya --
    // 受発注管理全体設定マスタメソッド型
    TxSalesSlipInputInitDataAcs_GetAcptAnOdrTtlSt = function(var resultAcptAnOdrTtlSt: TAcptAnOdrTtlSt): Integer; stdcall;
    // -- Add Ed 2012.07.23 30182 R.Tachiya --

    // 売上全体設定マスタメソッド型
    TxSalesSlipInputInitDataAcs_GetSalesTtlSt = function(var resultSalesTtlSt: TSalesTtlSt): Integer; stdcall;

    // 全体初期値設定マスタメソッド型
    TxSalesSlipInputInitDataAcs_GetAllDefSet = function(var resultAllDefSet: TAllDefSet): Integer; stdcall;

    // 自社情報設定マスタメソッド型
    TxSalesSlipInputInitDataAcs_GetCompanyInf = function(var resultCompanyInf: TCompanyInf): Integer; stdcall;

    // 売上金額処理区分設定マスタ制御処理メソッド型
    TxSalesSlipInputInitDataAcs_CacheSalesProcMoneyListCall = function(): Integer; stdcall;

    // 仕入金額処理区分設定マスタ制御処理メソッド型
    TxSalesSlipInputInitDataAcs_CacheStockProcMoneyListCall = function(): Integer; stdcall;

    // 掛率優先管理マスタ制御処理メソッド型
    TxSalesSlipInputInitDataAcs_CacheRateProtyMngListCall = function(): Integer; stdcall;

    // 処理区分マスタリスト設定処理メソッド型
    TxSalesSlipInputInitDataAcs_SettingProcMoney = function(): Integer; stdcall;

    // 解放メソッド型
    TxSalesSlipInputInitDataAcs_FreePosTerminalMg = function(resultList: PPosTerminalMg;
        resultCount: Integer): Integer; stdcall;

    // -- Add St 2012.07.23 30182 R.Tachiya --
    // 解放メソッド型
    TxSalesSlipInputInitDataAcs_FreeAcptAnOdrTtlSt = function(resultList: PAcptAnOdrTtlSt;
        resultCount: Integer): Integer; stdcall;
    // -- Add Ed 2012.07.23 30182 R.Tachiya --

    // 解放メソッド型
    TxSalesSlipInputInitDataAcs_FreeSalesTtlSt = function(resultList: PSalesTtlSt;
        resultCount: Integer): Integer; stdcall;

    // 解放メソッド型
    TxSalesSlipInputInitDataAcs_FreeAllDefSet = function(resultList: PAllDefSet;
        resultCount: Integer): Integer; stdcall;

    // 解放メソッド型
    TxSalesSlipInputInitDataAcs_FreeCompanyInf = function(resultList: PCompanyInf;
        resultCount: Integer): Integer; stdcall;

    //文字列解放メソッド型
    TxSalesSlipInputInitDataAcs_FreeMessage = function(msg : WideString):Integer; stdcall;

    //アクセスクラス仲介DLLロードメソッド
    function LoadLibraryMAHNB01019M(HDllCall1: THDllCall): Integer;

    //アクセスクラス仲介DLLアンロードメソッド
    procedure FreeLibraryMAHNB01019M(HDllCall1: THDllCall);

var
    // 売上入力で使用する初期データをＤＢより取得関数呼出し用ポインタ変数
    gpxSalesSlipInputInitDataAcs_ReadInitData: TxSalesSlipInputInitDataAcs_ReadInitData;
    // 売上入力で使用する初期データをＤＢより取得関数呼出し用ポインタ変数
    gpxSalesSlipInputInitDataAcs_ReadInitDataSecond: TxSalesSlipInputInitDataAcs_ReadInitDataSecond;
    // 売上入力で使用する初期データをＤＢより取得関数呼出し用ポインタ変数
    gpxSalesSlipInputInitDataAcs_ReadInitDataThird: TxSalesSlipInputInitDataAcs_ReadInitDataThird;
    // 売上入力で使用する初期データをＤＢより取得関数呼出し用ポインタ変数
    gpxSalesSlipInputInitDataAcs_ReadInitDataFourth: TxSalesSlipInputInitDataAcs_ReadInitDataFourth;
    // 売上入力で使用する初期データをＤＢより取得関数呼出し用ポインタ変数
    gpxSalesSlipInputInitDataAcs_ReadInitDataFifth: TxSalesSlipInputInitDataAcs_ReadInitDataFifth;
    // 売上入力で使用する初期データをＤＢより取得関数呼出し用ポインタ変数
    gpxSalesSlipInputInitDataAcs_ReadInitDataSixth: TxSalesSlipInputInitDataAcs_ReadInitDataSixth;
    // 売上入力で使用する初期データをＤＢより取得関数呼出し用ポインタ変数
    gpxSalesSlipInputInitDataAcs_ReadInitDataSeventh: TxSalesSlipInputInitDataAcs_ReadInitDataSeventh;
    // 売上入力で使用する初期データをＤＢより取得関数呼出し用ポインタ変数
    gpxSalesSlipInputInitDataAcs_ReadInitDataEighth: TxSalesSlipInputInitDataAcs_ReadInitDataEighth;
    // 売上入力で使用する初期データをＤＢより取得関数呼出し用ポインタ変数
    gpxSalesSlipInputInitDataAcs_ReadInitDataNinth: TxSalesSlipInputInitDataAcs_ReadInitDataNinth;
    // 売上入力で使用する初期データをＤＢより取得関数呼出し用ポインタ変数
    gpxSalesSlipInputInitDataAcs_ReadInitDataTenth: TxSalesSlipInputInitDataAcs_ReadInitDataTenth;
    // 端末管理マスタ関数呼出し用ポインタ変数
    gpxSalesSlipInputInitDataAcs_GetPosTerminalMg: TxSalesSlipInputInitDataAcs_GetPosTerminalMg;
    // -- Add St 2012.07.23 30182 R.Tachiya --
    // 受発注管理全体設定マスタ関数呼出し用ポインタ変数
    gpxSalesSlipInputInitDataAcs_GetAcptAnOdrTtlSt: TxSalesSlipInputInitDataAcs_GetAcptAnOdrTtlSt;
    // -- Add Ed 2012.07.23 30182 R.Tachiya --
    // 売上全体設定マスタ関数呼出し用ポインタ変数
    gpxSalesSlipInputInitDataAcs_GetSalesTtlSt: TxSalesSlipInputInitDataAcs_GetSalesTtlSt;
    // オプション情報処理関数呼出し用ポインタ変数
    gpxSalesSlipInputInitDataAcs_GetOptInfo: TxSalesSlipInputInitDataAcs_GetOptInfo;
// --- ADD 2012/12/21 T.Miyamoto ------------------------------>>>>>
    // 山形部品オプション情報処理関数呼出し用ポインタ変数
    gpxSalesSlipInputInitDataAcs_GetYamagataOptInfo: TxSalesSlipInputInitDataAcs_GetYamagataOptInfo;
// --- ADD 2012/12/21 T.Miyamoto ------------------------------<<<<<
    // 全体初期値設定マスタ関数呼出し用ポインタ変数
    gpxSalesSlipInputInitDataAcs_GetAllDefSet: TxSalesSlipInputInitDataAcs_GetAllDefSet;
    // 自社情報設定マスタ関数呼出し用ポインタ変数
    gpxSalesSlipInputInitDataAcs_GetCompanyInf: TxSalesSlipInputInitDataAcs_GetCompanyInf;
    // 売上金額処理区分設定マスタ制御処理関数呼出し用ポインタ変数
    gpxSalesSlipInputInitDataAcs_CacheSalesProcMoneyListCall: TxSalesSlipInputInitDataAcs_CacheSalesProcMoneyListCall;
    // 仕入金額処理区分設定マスタ制御処理関数呼出し用ポインタ変数
    gpxSalesSlipInputInitDataAcs_CacheStockProcMoneyListCall: TxSalesSlipInputInitDataAcs_CacheStockProcMoneyListCall;
    // 掛率優先管理マスタ制御処理関数呼出し用ポインタ変数
    gpxSalesSlipInputInitDataAcs_CacheRateProtyMngListCall: TxSalesSlipInputInitDataAcs_CacheRateProtyMngListCall;
    // 処理区分マスタリスト設定処理関数呼出し用ポインタ変数
    gpxSalesSlipInputInitDataAcs_SettingProcMoney: TxSalesSlipInputInitDataAcs_SettingProcMoney;
    // メモリ解放処理呼び出し用ポインタ変数
    gpxSalesSlipInputInitDataAcs_FreePosTerminalMg: TxSalesSlipInputInitDataAcs_FreePosTerminalMg;
    // -- Add St 2012.07.23 30182 R.Tachiya --
    // メモリ解放処理呼び出し用ポインタ変数
    gpxSalesSlipInputInitDataAcs_FreeAcptAnOdrTtlSt: TxSalesSlipInputInitDataAcs_FreeAcptAnOdrTtlSt;
    // -- Add Ed 2012.07.23 30182 R.Tachiya --
    // メモリ解放処理呼び出し用ポインタ変数
    gpxSalesSlipInputInitDataAcs_FreeSalesTtlSt: TxSalesSlipInputInitDataAcs_FreeSalesTtlSt;
    // メモリ解放処理呼び出し用ポインタ変数
    gpxSalesSlipInputInitDataAcs_FreeAllDefSet: TxSalesSlipInputInitDataAcs_FreeAllDefSet;
    // メモリ解放処理呼び出し用ポインタ変数
    gpxSalesSlipInputInitDataAcs_FreeCompanyInf: TxSalesSlipInputInitDataAcs_FreeCompanyInf;

    //文字列解放処理呼び出し用ポインタ変数
    gpxSalesSlipInputInitDataAcs_FreeMessage: TxSalesSlipInputInitDataAcs_FreeMessage;

    DataModule1: TDataModule1;

implementation

{$R *.dfm}

// 初期化アクセスクラス仲介DLLロード処理
function LoadLibraryMAHNB01019M(HDllCall1: THDllCall): Integer;
var
    nSt: Integer;
begin
    Result := 4;
    HDllCall1.DllName := 'MAHNB01019M.DLL';
    nSt := HDllCall1.HLoadLibrary;

    // DLLロード
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '初期化',
            'LoadLibraryMAHNB01019M', 'LOADLIBRARY', '初期化のロードに失敗しました',
            nSt, nil, 0);
        Exit;
    end;

    // 売上入力で使用する初期データをＤＢより取得関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_ReadInitData';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_ReadInitData);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '初期データをＤＢより取得',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '初期データをＤＢより取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // オプション情報処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_GetOptInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_GetOptInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '車種部品',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '車種部品オプション情報処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // --- ADD 2012/12/21 T.Miyamoto ------------------------------>>>>>
    // 山形部品オプション情報処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_GetYamagataOptInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_GetYamagataOptInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '山形部品',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '山形部品オプション情報処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2012/12/21 T.Miyamoto ------------------------------<<<<<

    // 売上入力で使用する初期データをＤＢより取得関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_ReadInitDataSecond';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_ReadInitDataSecond);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '初期データをＤＢより取得',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '初期データをＤＢより取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 売上入力で使用する初期データをＤＢより取得関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_ReadInitDataThird';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_ReadInitDataThird);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '初期データをＤＢより取得',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '初期データをＤＢより取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 売上入力で使用する初期データをＤＢより取得関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_ReadInitDataFourth';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_ReadInitDataFourth);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '初期データをＤＢより取得',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '初期化部品売上入力で使用する取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 売上入力で使用する初期データをＤＢより取得関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_ReadInitDataFifth';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_ReadInitDataFifth);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '初期データをＤＢより取得',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '初期化部品売上入力で使用する取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 売上入力で使用する初期データをＤＢより取得関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_ReadInitDataSixth';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_ReadInitDataSixth);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '初期データをＤＢより取得',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '初期化部品売上入力で使用する取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 売上入力で使用する初期データをＤＢより取得関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_ReadInitDataSeventh';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_ReadInitDataSeventh);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '初期データをＤＢより取得',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '初期化部品売上入力で使用する取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 売上入力で使用する初期データをＤＢより取得関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_ReadInitDataEighth';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_ReadInitDataEighth);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '初期データをＤＢより取得',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '初期化部品売上入力で使用する取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 売上入力で使用する初期データをＤＢより取得関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_ReadInitDataNinth';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_ReadInitDataNinth);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '初期データをＤＢより取得',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '初期化部品売上入力で使用する取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 売上入力で使用する初期データをＤＢより取得関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_ReadInitDataTenth';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_ReadInitDataTenth);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '初期データをＤＢより取得',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '初期化部品売上入力で使用する取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 端末管理マスタ関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_GetPosTerminalMg';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_GetPosTerminalMg);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '初期化端末管理マスタ',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '初期化端末管理マスタ関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // -- Add St 2012.07.23 30182 R.Tachiya --
    // 受発注管理全体設定マスタ関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_GetAcptAnOdrTtlSt';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_GetAcptAnOdrTtlSt);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '初期化部品受発注管理全体設定マスタ',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '初期化部品受発注管理全体設定マスタ関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // -- Add Ed 2012.07.23 30182 R.Tachiya --

    // 売上全体設定マスタ関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_GetSalesTtlSt';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_GetSalesTtlSt);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '初期化品売上全体設定マスタ',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '初期化品売上全体設定マスタ関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 全体初期値設定マスタ関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_GetAllDefSet';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_GetAllDefSet);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '初期化全体初期値設定マスタ',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '初期化全体初期値設定マスタ関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 自社情報設定マスタ関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_GetCompanyInf';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_GetCompanyInf);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '初期化自社情報設定マスタ',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '初期化自社情報設定マスタ関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 売上金額処理区分設定マスタ制御処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_CacheSalesProcMoneyListCall';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_CacheSalesProcMoneyListCall);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '初期化売上金額処理区分設定マスタ',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '初期化売上金額処理区分設定マスタ制御処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 仕入金額処理区分設定マスタ制御処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_CacheStockProcMoneyListCall';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_CacheStockProcMoneyListCall);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '初期化仕入金額処理区分設定マスタ',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '初期化仕入金額処理区分設定マスタ制御処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 掛率優先管理マスタ制御処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_CacheRateProtyMngListCall';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_CacheRateProtyMngListCall);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '初期化掛率優先管理マスタ',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '初期化掛率優先管理マスタ制御処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 処理区分マスタリスト設定処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_SettingProcMoney';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_SettingProcMoney);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '初期化処理区分マスタ',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '初期化処理区分マスタリスト設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // データ解放関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_FreePosTerminalMg';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_FreePosTerminalMg);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '初期化メモリ解放',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '初期化メモリ解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // -- Add St 2012.07.23 R.Tachiya --
    // データ解放関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_FreeAcptAnOdrTtlSt';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_FreeAcptAnOdrTtlSt);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '初期化メモリ解放',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '初期化メモリ解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // -- Add Ed 2012.07.23 R.Tachiya --

    // データ解放関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_FreeSalesTtlSt';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_FreeSalesTtlSt);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '初期化メモリ解放',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '初期化メモリ解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // データ解放関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_FreeAllDefSet';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_FreeAllDefSet);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '初期化メモリ解放',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '初期化メモリ解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // データ解放関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_FreeCompanyInf';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_FreeCompanyInf);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '初期化メモリ解放',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '初期化メモリ解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //文字列解放関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputInitDataAcs_FreeMessage';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputInitDataAcs_FreeMessage);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019B', '初期化文字列解放',
            'LoadLibraryMAHNB01019M', 'GETPROCADDRESS',
            '初期化文字列解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    Result := 0;

end;

// アクセスクラス仲介DLL解放メソッド
procedure FreeLibraryMAHNB01019M(HDllCall1: THDllCall);
begin
    HDllCall1.DllName := 'MAHNB01019M.DLL';
    HDllCall1.HFreeLibrary;
    gpxSalesSlipInputInitDataAcs_ReadInitData := nil;
    gpxSalesSlipInputInitDataAcs_ReadInitDataSecond := nil;
    gpxSalesSlipInputInitDataAcs_ReadInitDataThird := nil;
    gpxSalesSlipInputInitDataAcs_ReadInitDataFourth := nil;
    gpxSalesSlipInputInitDataAcs_ReadInitDataFifth := nil;
    gpxSalesSlipInputInitDataAcs_ReadInitDataSixth := nil;
    gpxSalesSlipInputInitDataAcs_ReadInitDataSeventh := nil;
    gpxSalesSlipInputInitDataAcs_ReadInitDataEighth := nil;
    gpxSalesSlipInputInitDataAcs_ReadInitDataNinth := nil;
    gpxSalesSlipInputInitDataAcs_ReadInitDataTenth := nil;
    gpxSalesSlipInputInitDataAcs_GetPosTerminalMg := nil;
    gpxSalesSlipInputInitDataAcs_GetAcptAnOdrTtlSt := nil;// -- Add 2012.07.23 30182 R.Tachiya --
    gpxSalesSlipInputInitDataAcs_GetSalesTtlSt := nil;
    gpxSalesSlipInputInitDataAcs_GetAllDefSet := nil;
    gpxSalesSlipInputInitDataAcs_GetCompanyInf := nil;
    gpxSalesSlipInputInitDataAcs_CacheSalesProcMoneyListCall := nil;
    gpxSalesSlipInputInitDataAcs_CacheStockProcMoneyListCall := nil;
    gpxSalesSlipInputInitDataAcs_CacheRateProtyMngListCall := nil;
    gpxSalesSlipInputInitDataAcs_SettingProcMoney := nil;
    gpxSalesSlipInputInitDataAcs_GetOptInfo := nil;
    gpxSalesSlipInputInitDataAcs_GetYamagataOptInfo := nil; // ADD 2012/12/21 T.Miyamoto

    gpxSalesSlipInputInitDataAcs_FreePosTerminalMg := nil;
    gpxSalesSlipInputInitDataAcs_FreeAcptAnOdrTtlSt := nil;// -- Add 2012.07.23 30182 R.Tachiya --
    gpxSalesSlipInputInitDataAcs_FreeSalesTtlSt := nil;
    gpxSalesSlipInputInitDataAcs_FreeAllDefSet := nil;
    gpxSalesSlipInputInitDataAcs_FreeCompanyInf := nil;
    gpxSalesSlipInputInitDataAcs_FreeMessage := nil;
end;

(*============================================================================*)
(*  初期処理部                                                                *)
(*============================================================================*)
initialization
  //------------------------------------------------//
  //  データモジュールの生成                        //
  //------------------------------------------------//
  if DataModule1 = nil then
  begin
    DataModule1 := TDataModule1.Create(Application);
    if DataModule1 = nil then
    begin
      //HDspErrorDlg('初期化処理(initialization)', 'CREATE', 'データモジュール生成エラー', -99, nil);
    end
    else
    begin
        //関数ロード
        LoadLibraryMAHNB01019M(DataModule1.HDllCall1);
    end;
  end;


(*============================================================================*)
(*  終了処理部                                                                *)
(*============================================================================*)
finalization

  //------------------------------------------------//
  //  データモジュールの解放                        //
  //------------------------------------------------//
  if DataModule1 <> nil then
  begin
    //関数アンロード
    FreeLibraryMAHNB01019M(DataModule1.HDllCall1);

    DataModule1.Free;
    DataModule1 := nil;
  end;

end.

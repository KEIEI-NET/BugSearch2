unit MAHNB01019BAP;

interface

uses ShareMem, SysUtils, HFSLLIB, MAHNB01019C,
    MAHNB01019BMP, messages, classes, windows, controls, dialogs;

/////////////// Delphi側へのエクスポート関数宣言 //////////////////////////


// 売上入力で使用する初期データをＤＢより取得
function MAHNB01019B_ReadInitData(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

    // オプション情報処理
function MAHNB01019B_GetOptInfo(var optCarMng: Integer;
                                var optFreeSearch: Integer;
                                var optPcc: Integer;
                                var optRCLink: Integer;
                                var optUoe: Integer;
                                var optStockingPayment: Integer;
                                var optScm: Integer;
                                var opt_QRMail: Integer;
                                var opt_DateCtrl: Integer; // ADD T.Miyamoto 2012/11/13
                                var opt_NoBuTo: Integer // ADD 譚洪 K2014/01/22
                               ) : Integer; stdcall;

// --- ADD 2012/12/21 T.Miyamoto ------------------------------>>>>>
    // 山形部品オプション情報処理
function MAHNB01019B_GetYamagataOptInfo(var optStockEntCtrl: Integer;
                                        var optStockDateCtrl: Integer;
                                        var optSalesCostCtrl: Integer
                                       ) : Integer; stdcall;
// --- ADD 2012/12/21 T.Miyamoto ------------------------------<<<<<

// 売上入力で使用する初期データをＤＢより取得
function MAHNB01019B_ReadInitDataSecond(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;


// 売上入力で使用する初期データをＤＢより取得
function MAHNB01019B_ReadInitDataThird(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

// 売上入力で使用する初期データをＤＢより取得
function MAHNB01019B_ReadInitDataFourth(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

// 売上入力で使用する初期データをＤＢより取得
function MAHNB01019B_ReadInitDataFifth(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

    // 売上入力で使用する初期データをＤＢより取得
function MAHNB01019B_ReadInitDataSixth(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

    // 売上入力で使用する初期データをＤＢより取得
function MAHNB01019B_ReadInitDataSeventh(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

    // 売上入力で使用する初期データをＤＢより取得
function MAHNB01019B_ReadInitDataEighth(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

    // 売上入力で使用する初期データをＤＢより取得
function MAHNB01019B_ReadInitDataNinth(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

    // 売上入力で使用する初期データをＤＢより取得
function MAHNB01019B_ReadInitDataTenth(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;


// 端末管理マスタ
function MAHNB01019B_GetPosTerminalMg(var posTerminalMg: TPosTerminalMg)
    : Integer; stdcall;

// -- Add St 2012.07.23 30182 R.Tachiya --
// 受発注管理全体設定マスタ
function MAHNB01019B_GetAcptAnOdrTtlSt(var acptAnOdrTtlSt: TAcptAnOdrTtlSt)
    : Integer; stdcall;
// -- Add Ed 2012.07.23 30182 R.Tachiya --

// 売上全体設定マスタ
function MAHNB01019B_GetSalesTtlSt(var salesTtlSt: TSalesTtlSt)
    : Integer; stdcall;


// 全体初期値設定マスタ
function MAHNB01019B_GetAllDefSet(var allDefSet: TAllDefSet)
    : Integer; stdcall;


// 自社情報設定マスタ
function MAHNB01019B_GetCompanyInf(var companyInf: TCompanyInf)
    : Integer; stdcall;

// 売上金額処理区分設定マスタ制御処理
function MAHNB01019B_CacheSalesProcMoneyListCall()
    : Integer; stdcall;


// 仕入金額処理区分設定マスタ制御処理
function MAHNB01019B_CacheStockProcMoneyListCall()
    : Integer; stdcall;


// 掛率優先管理マスタ制御処理
function MAHNB01019B_CacheRateProtyMngListCall()
    : Integer; stdcall;


// 処理区分マスタリスト設定処理
function MAHNB01019B_SettingProcMoney()
    : Integer; stdcall;


implementation

// 売上入力で使用する初期データをＤＢより取得
function MAHNB01019B_ReadInitData(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化

            // 検索メソッド呼出し
            status := gpxSalesSlipInputInitDataAcs_ReadInitData(enterpriseCode, sectionCode);
            // 結果コピー

            // 結果を設定
            Result := status;
            // 例外処理
        except
            on ex: Exception do
            begin
                // 例外発生時はエラーメッセージを戻す
                Result := -1;
            end;
        end;
    finally
        // ラッパークラス側から渡されたメモリを解放

    end;
end;

// オプション情報処理
function MAHNB01019B_GetOptInfo(var optCarMng: Integer;
                                var optFreeSearch: Integer;
                                var optPcc: Integer;
                                var optRCLink: Integer;
                                var optUoe: Integer;
                                var optStockingPayment: Integer;
                                var optScm: Integer;
                                var opt_QRMail: Integer;
                                var opt_DateCtrl: Integer; // ADD T.Miyamoto 2012/11/13
                                var opt_NoBuTo: Integer // ADD 譚洪 K2014/01/22
                               ) : Integer; stdcall;

var
    status: Integer;
    resultOptCarMng: Integer;
    resultOptFreeSearch: Integer;
    resultOptPcc: Integer;
    resultOptRCLink: Integer;
    resultOptUoe: Integer;
    resultOptStockingPayment: Integer;
    resultOptScm: Integer;
    resultOpt_QRMail: Integer;
    resultOpt_DateCtrl: Integer; // ADD T.Miyamoto 2012/11/13
    resultOpt_NoBuTo: Integer; // ADD 譚洪 K2014/01/22

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;
    optCarMng := 0;
    optFreeSearch := 0;
    optPcc := 0;
    optRCLink := 0;
    optUoe := 0;
    optStockingPayment := 0;
    optScm := 0;
    opt_QRMail := 0;
    opt_DateCtrl := 0; // ADD T.Miyamoto 2012/11/13
    opt_NoBuTo := 0; // ADD 譚洪 K2014/01/22

    try
        try
            // 結果データを初期化
            resultOptCarMng := 0;
            resultOptFreeSearch := 0;
            resultOptPcc := 0;
            resultOptRCLink := 0;
            resultOptUoe := 0;
            resultOptStockingPayment := 0;
            resultOptScm := 0;
            resultOpt_QRMail := 0;
            resultOpt_DateCtrl := 0; // ADD T.Miyamoto 2012/11/13
            resultOpt_NoBuTo := 0; // ADD 譚洪 K2014/01/22

            // 検索メソッド呼出し
            // UPD T.Miyamoto 2012/11/13 ------------------------------>>>>>
            //status := gpxSalesSlipInputInitDataAcs_GetOptInfo(resultOptCarMng, resultOptFreeSearch, resultOptPcc, resultOptRCLink, resultOptUoe, resultOptStockingPayment, resultOptScm, resultOpt_QRMail);
            //status := gpxSalesSlipInputInitDataAcs_GetOptInfo(resultOptCarMng, resultOptFreeSearch, resultOptPcc, resultOptRCLink, resultOptUoe, resultOptStockingPayment, resultOptScm, resultOpt_QRMail, resultOpt_DateCtrl);  // DEL 譚洪 K2014/01/22
            status := gpxSalesSlipInputInitDataAcs_GetOptInfo(resultOptCarMng, resultOptFreeSearch, resultOptPcc, resultOptRCLink, resultOptUoe, resultOptStockingPayment, resultOptScm, resultOpt_QRMail, resultOpt_DateCtrl, resultOpt_NoBuTo);  // ADD 譚洪 K2014/01/22
            // UPD T.Miyamoto 2012/11/13 ------------------------------<<<<<
            // 結果コピー
            optCarMng := resultOptCarMng;
            optFreeSearch := resultOptFreeSearch;
            optPcc := resultOptPcc;
            optRCLink := resultOptRCLink;
            optUoe := resultOptUoe;
            optStockingPayment := resultOptStockingPayment;
            optScm := resultOptScm;
            opt_QRMail := resultOpt_QRMail;
            opt_DateCtrl := resultOpt_DateCtrl; // ADD T.Miyamoto 2012/11/13
            opt_NoBuTo := resultOpt_NoBuTo; // ADD 譚洪 K2014/01/22

            // 結果を設定
            Result := status;
            // 例外処理
        except
            on ex: Exception do
            begin
                // 例外発生時はエラーメッセージを戻す
                Result := -1;
            end;
        end;
    finally
        // ラッパークラス側から渡されたメモリを解放

        // メッセージのメモリ解放
    end;
end;

// --- ADD 2012/12/21 T.Miyamoto ------------------------------>>>>>
    // 山形部品オプション情報処理
function MAHNB01019B_GetYamagataOptInfo(var optStockEntCtrl: Integer;
                                        var optStockDateCtrl: Integer;
                                        var optSalesCostCtrl: Integer
                                       ) : Integer; stdcall;

var
    status: Integer;
    resultOptStockEntCtrl: Integer;
    resultOptStockDateCtrl: Integer;
    resultOptSalesCostCtrl: Integer;
begin
    // 戻りステータス初期化
    Result := -1;
    optStockEntCtrl := 0;
    optStockDateCtrl := 0;
    optSalesCostCtrl := 0;

    try
        try
            // 結果データを初期化
            resultOptStockEntCtrl := 0;
            resultOptStockDateCtrl := 0;
            resultOptSalesCostCtrl := 0;

            // 検索メソッド呼出し
            status := gpxSalesSlipInputInitDataAcs_GetYamagataOptInfo(resultOptStockEntCtrl
                                                                     ,resultOptStockDateCtrl
                                                                     ,resultOptSalesCostCtrl
                                                                     );
            // 結果コピー
            optStockEntCtrl := resultOptStockEntCtrl;
            optStockDateCtrl := resultOptStockDateCtrl;
            optSalesCostCtrl := resultOptSalesCostCtrl;

            // 結果を設定
            Result := status;
            // 例外処理
        except
            on ex: Exception do
            begin
                // 例外発生時はエラーメッセージを戻す
                Result := -1;
            end;
        end;
    finally
        // ラッパークラス側から渡されたメモリを解放

        // メッセージのメモリ解放
    end;
end;
// --- ADD 2012/12/21 T.Miyamoto ------------------------------<<<<<

// 売上入力で使用する初期データをＤＢより取得
function MAHNB01019B_ReadInitDataSecond(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化

            // 検索メソッド呼出し
            status := gpxSalesSlipInputInitDataAcs_ReadInitDataSecond(enterpriseCode, sectionCode);
            // 結果コピー

            // 結果を設定
            Result := status;
            // 例外処理
        except
            on ex: Exception do
            begin
                // 例外発生時はエラーメッセージを戻す
                Result := -1;
            end;
        end;
    finally
        // ラッパークラス側から渡されたメモリを解放

    end;
end;

// 売上入力で使用する初期データをＤＢより取得
function MAHNB01019B_ReadInitDataThird(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化

            // 検索メソッド呼出し
            status := gpxSalesSlipInputInitDataAcs_ReadInitDataThird(enterpriseCode, sectionCode);
            // 結果コピー

            // 結果を設定
            Result := status;
            // 例外処理
        except
            on ex: Exception do
            begin
                // 例外発生時はエラーメッセージを戻す
                Result := -1;
            end;
        end;
    finally
        // ラッパークラス側から渡されたメモリを解放

    end;
end;

// 売上入力で使用する初期データをＤＢより取得
function MAHNB01019B_ReadInitDataFourth(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化

            // 検索メソッド呼出し
            status := gpxSalesSlipInputInitDataAcs_ReadInitDataFourth(enterpriseCode, sectionCode);
            // 結果コピー

            // 結果を設定
            Result := status;
            // 例外処理
        except
            on ex: Exception do
            begin
                // 例外発生時はエラーメッセージを戻す
                Result := -1;
            end;
        end;
    finally
        // ラッパークラス側から渡されたメモリを解放

    end;
end;

// 売上入力で使用する初期データをＤＢより取得
function MAHNB01019B_ReadInitDataFifth(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化

            // 検索メソッド呼出し
            status := gpxSalesSlipInputInitDataAcs_ReadInitDataFifth(enterpriseCode, sectionCode);
            // 結果コピー

            // 結果を設定
            Result := status;
            // 例外処理
        except
            on ex: Exception do
            begin
                // 例外発生時はエラーメッセージを戻す
                Result := -1;
            end;
        end;
    finally
        // ラッパークラス側から渡されたメモリを解放

    end;
end;

// 売上入力で使用する初期データをＤＢより取得
function MAHNB01019B_ReadInitDataSixth(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化

            // 検索メソッド呼出し
            status := gpxSalesSlipInputInitDataAcs_ReadInitDataSixth(enterpriseCode, sectionCode);
            // 結果コピー

            // 結果を設定
            Result := status;
            // 例外処理
        except
            on ex: Exception do
            begin
                // 例外発生時はエラーメッセージを戻す
                Result := -1;
            end;
        end;
    finally
        // ラッパークラス側から渡されたメモリを解放

    end;
end;

// 売上入力で使用する初期データをＤＢより取得
function MAHNB01019B_ReadInitDataSeventh(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化

            // 検索メソッド呼出し
            status := gpxSalesSlipInputInitDataAcs_ReadInitDataSeventh(enterpriseCode, sectionCode);
            // 結果コピー

            // 結果を設定
            Result := status;
            // 例外処理
        except
            on ex: Exception do
            begin
                // 例外発生時はエラーメッセージを戻す
                Result := -1;
            end;
        end;
    finally
        // ラッパークラス側から渡されたメモリを解放

    end;
end;

// 売上入力で使用する初期データをＤＢより取得
function MAHNB01019B_ReadInitDataEighth(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化

            // 検索メソッド呼出し
            status := gpxSalesSlipInputInitDataAcs_ReadInitDataEighth(enterpriseCode, sectionCode);
            // 結果コピー

            // 結果を設定
            Result := status;
            // 例外処理
        except
            on ex: Exception do
            begin
                // 例外発生時はエラーメッセージを戻す
                Result := -1;
            end;
        end;
    finally
        // ラッパークラス側から渡されたメモリを解放

    end;
end;

// 売上入力で使用する初期データをＤＢより取得
function MAHNB01019B_ReadInitDataNinth(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化

            // 検索メソッド呼出し
            status := gpxSalesSlipInputInitDataAcs_ReadInitDataNinth(enterpriseCode, sectionCode);
            // 結果コピー

            // 結果を設定
            Result := status;
            // 例外処理
        except
            on ex: Exception do
            begin
                // 例外発生時はエラーメッセージを戻す
                Result := -1;
            end;
        end;
    finally
        // ラッパークラス側から渡されたメモリを解放

    end;
end;

// 売上入力で使用する初期データをＤＢより取得
function MAHNB01019B_ReadInitDataTenth(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化

            // 検索メソッド呼出し
            status := gpxSalesSlipInputInitDataAcs_ReadInitDataTenth(enterpriseCode, sectionCode);
            // 結果コピー

            // 結果を設定
            Result := status;
            // 例外処理
        except
            on ex: Exception do
            begin
                // 例外発生時はエラーメッセージを戻す
                Result := -1;
            end;
        end;
    finally
        // ラッパークラス側から渡されたメモリを解放

    end;
end;

// 端末管理マスタ
function MAHNB01019B_GetPosTerminalMg(var posTerminalMg: TPosTerminalMg)
    : Integer; stdcall;

var
    status: Integer;
    resultPosTerminalMg: TPosTerminalMg;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            ClearTPosTerminalMg(resultPosTerminalMg);

            // 検索メソッド呼出し
            status := gpxSalesSlipInputInitDataAcs_GetPosTerminalMg(resultPosTerminalMg);
            // 結果コピー
            posTerminalMg := resultPosTerminalMg;

            // 結果を設定
            Result := status;
            // 例外処理
        except
            on ex: Exception do
            begin
                // 例外発生時はエラーメッセージを戻す
                Result := -1;
            end;
        end;
    finally
        // ラッパークラス側から渡されたメモリを解放

    end;
end;

// -- Add St 2012.07.23 30182 R.Tachiya --
// 受発注管理全体設定マスタ
function MAHNB01019B_GetAcptAnOdrTtlSt(var acptAnOdrTtlSt: TAcptAnOdrTtlSt)
    : Integer; stdcall;

var
    status: Integer;
    resultAcptAnOdrTtlSt: TAcptAnOdrTtlSt;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            ClearTAcptAnOdrTtlSt(resultAcptAnOdrTtlSt);

            // 検索メソッド呼出し
            status := gpxSalesSlipInputInitDataAcs_GetAcptAnOdrTtlSt(resultAcptAnOdrTtlSt);
            // 結果コピー
            acptAnOdrTtlSt := resultAcptAnOdrTtlSt;

            // 結果を設定
            Result := status;
            // 例外処理
        except
            on ex: Exception do
            begin
                // 例外発生時はエラーメッセージを戻す
                Result := -1;
            end;
        end;
    finally
        // ラッパークラス側から渡されたメモリを解放

    end;
end;
// -- Add Ed 2012.07.23 30182 R.Tachiya --

// 売上全体設定マスタ
function MAHNB01019B_GetSalesTtlSt(var salesTtlSt: TSalesTtlSt)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesTtlSt: TSalesTtlSt;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            ClearTSalesTtlSt(resultSalesTtlSt);

            // 検索メソッド呼出し
            status := gpxSalesSlipInputInitDataAcs_GetSalesTtlSt(resultSalesTtlSt);
            // 結果コピー
            salesTtlSt := resultSalesTtlSt;

            // 結果を設定
            Result := status;
            // 例外処理
        except
            on ex: Exception do
            begin
                // 例外発生時はエラーメッセージを戻す
                Result := -1;
            end;
        end;
    finally
        // ラッパークラス側から渡されたメモリを解放

    end;
end;

// 全体初期値設定マスタ
function MAHNB01019B_GetAllDefSet(var allDefSet: TAllDefSet)
    : Integer; stdcall;

var
    status: Integer;
    resultAllDefSet: TAllDefSet;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            ClearTAllDefSet(resultAllDefSet);

            // 検索メソッド呼出し
            status := gpxSalesSlipInputInitDataAcs_GetAllDefSet(resultAllDefSet);
            // 結果コピー
            allDefSet := resultAllDefSet;

            // 結果を設定
            Result := status;
            // 例外処理
        except
            on ex: Exception do
            begin
                // 例外発生時はエラーメッセージを戻す
                Result := -1;
            end;
        end;
    finally
        // ラッパークラス側から渡されたメモリを解放

    end;
end;

// 自社情報設定マスタ
function MAHNB01019B_GetCompanyInf(var companyInf: TCompanyInf)
    : Integer; stdcall;

var
    status: Integer;
    resultCompanyInf: TCompanyInf;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            ClearTCompanyInf(resultCompanyInf);

            // 検索メソッド呼出し
            status := gpxSalesSlipInputInitDataAcs_GetCompanyInf(resultCompanyInf);
            // 結果コピー
            companyInf := resultCompanyInf;

            // 結果を設定
            Result := status;
            // 例外処理
        except
            on ex: Exception do
            begin
                // 例外発生時はエラーメッセージを戻す
                Result := -1;
            end;
        end;
    finally
        // ラッパークラス側から渡されたメモリを解放

    end;
end;

// 売上金額処理区分設定マスタ制御処理
function MAHNB01019B_CacheSalesProcMoneyListCall()
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化

            // 検索メソッド呼出し
            status := gpxSalesSlipInputInitDataAcs_CacheSalesProcMoneyListCall();
            // 結果コピー

            // 結果を設定
            Result := status;
            // 例外処理
        except
            on ex: Exception do
            begin
                // 例外発生時はエラーメッセージを戻す
                Result := -1;
            end;
        end;
    finally
        // ラッパークラス側から渡されたメモリを解放

    end;
end;

// 仕入金額処理区分設定マスタ制御処理
function MAHNB01019B_CacheStockProcMoneyListCall()
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化

            // 検索メソッド呼出し
            status := gpxSalesSlipInputInitDataAcs_CacheStockProcMoneyListCall();
            // 結果コピー

            // 結果を設定
            Result := status;
            // 例外処理
        except
            on ex: Exception do
            begin
                // 例外発生時はエラーメッセージを戻す
                Result := -1;
            end;
        end;
    finally
        // ラッパークラス側から渡されたメモリを解放

    end;
end;

// 掛率優先管理マスタ制御処理
function MAHNB01019B_CacheRateProtyMngListCall()
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化

            // 検索メソッド呼出し
            status := gpxSalesSlipInputInitDataAcs_CacheRateProtyMngListCall();
            // 結果コピー

            // 結果を設定
            Result := status;
            // 例外処理
        except
            on ex: Exception do
            begin
                // 例外発生時はエラーメッセージを戻す
                Result := -1;
            end;
        end;
    finally
        // ラッパークラス側から渡されたメモリを解放

    end;
end;

// 処理区分マスタリスト設定処理
function MAHNB01019B_SettingProcMoney()
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化

            // 検索メソッド呼出し
            status := gpxSalesSlipInputInitDataAcs_SettingProcMoney();
            // 結果コピー

            // 結果を設定
            Result := status;
            // 例外処理
        except
            on ex: Exception do
            begin
                // 例外発生時はエラーメッセージを戻す
                Result := -1;
            end;
        end;
    finally
        // ラッパークラス側から渡されたメモリを解放

    end;
end;


end.

//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売上伝票入力
// プログラム概要   :
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 作 成 日  2010/06/12  修正内容 : 携帯メール機能の組込
//----------------------------------------------------------------------------//
// 管理番号  10703874-00 作成担当 : yangyi
// 作 成 日  K2011/08/12 修正内容 : イスコ個別対応
//----------------------------------------------------------------------------//
// 管理番号  10900269-00 作成担当 : FSI今野 利裕
// 作 成 日  2013/03/21  修正内容 : SPK車台番号文字列対応
//----------------------------------------------------------------------------//
// 管理番号  11070071-00 作成担当 : 宮本　利明
// 作 成 日  2014/05/19  修正内容 : 仕掛一覧№2218 車輌備考欄にコード入力項目を追加
//----------------------------------------------------------------------------//

unit MAHNB01012BAP;

interface

uses ShareMem, SysUtils, HDllCall, DBClient, HFSLLIB, MAHNB01012C,
    MAHNB01012BMP, messages, classes, windows, controls, dialogs;

/////////////// Delphi側へのエクスポート関数宣言 //////////////////////////

// 車両検索処理
function MAHNB01012B_CarSearch(condition: TCarSearchCondition;
    salesRowNo: Integer;
    conditionType: Integer)
    : Integer; stdcall;


// 車両情報行オブジェクト取得
function MAHNB01012B_GetCarInfoRow(salesRowNo: Integer;
    getCarInfoMode: Integer;
    var carInfo: TCarInfo)
    : Integer; stdcall;

// オプション情報処理
function MAHNB01012B_GetSettingOptionInfo(var optCarMng: Integer;
    var optStockingPayment: Integer)
    : Integer; stdcall;


// カラー情報取得処理
function MAHNB01012B_GetColorInfo(carRelationGuid: WideString;
    var colorInfoList: TSalesSlipInputCustomArrayB2)
    : Integer; stdcall;


// 選択カラー情報取得処理
function MAHNB01012B_GetSelectColorInfo(carRelationGuid: WideString;
    var colorInfo: TColorInfo)
    : Integer; stdcall;


// トリム情報取得処理
function MAHNB01012B_GetTrimInfo(carRelationGuid: WideString;
    var trimInfoList: TSalesSlipInputCustomArrayB3)
    : Integer; stdcall;


// 選択トリム情報取得処理
function MAHNB01012B_GetSelectTrimInfo(carRelationGuid: WideString;
    var trimInfo: TTrimInfo)
    : Integer; stdcall;


// 装備情報取得処理
function MAHNB01012B_GetEquipInfo(carRelationGuid: WideString;
    var cEqpDefDspInfoList: TSalesSlipInputCustomArrayB4)
    : Integer; stdcall;


// カラー情報選択処理
function MAHNB01012B_SelectColorInfo(carRelationGuid: WideString;
    colorCode: WideString)
    : Integer; stdcall;


// トリム情報選択処理
function MAHNB01012B_SelectTrimInfo(carRelationGuid: WideString;
    trimCode: WideString)
    : Integer; stdcall;


// 生産年式範囲チェック
function MAHNB01012B_CheckProduceTypeOfYearRange(carRelationGuid: WideString;
    firstEntryDate: Integer)
    : Integer; stdcall;


// 車両検索データテーブル年式設定処理
function MAHNB01012B_SettingCarModelUIDataFromFirstEntryDate(carRelationGuid: WideString;
    firstEntryDate: WideString)
    : Integer; stdcall;


// 車台番号範囲チェック
function MAHNB01012B_CheckProduceFrameNo(carRelationGuid: WideString;
    inputFrameNo: WideString;
    searchFrameNo: Integer)
    : Integer; stdcall;


// 車両検索データテーブル車台番号設定処理
function MAHNB01012B_SettingCarModelUIDataFromProduceFrameNo(carRelationGuid: WideString;
    frameNo: WideString)
    : Integer; stdcall;


// 対象年式取得処理(車台番号より取得)
function MAHNB01012B_GetProduceTypeOfYear(carRelationGuid: WideString;
    frameNo: WideString)
    : Integer; stdcall;


// 車両情報テーブルのクリア
function MAHNB01012B_ClearCarInfoRow(salesRowNo: Integer)
    : Integer; stdcall;


// 車両情報テーブル行の年式セット
function MAHNB01012B_SettingCarInfoRowFromFirstEntryDate(salesRowNo: Integer;
    firstEntryDate: Integer)
    : Integer; stdcall;


// 車両情報テーブル行の車台番号セット
function MAHNB01012B_SettingCarInfoRowFromFrameNo(salesRowNo: Integer;
    frameNo: WideString)
    : Integer; stdcall;


// 車両情報テーブル行の車種情報セット
function MAHNB01012B_SettingCarInfoRowFromModelInfo(salesRowNo: Integer;
    makerCode: Integer;
    makerFullName: WideString;
    makerHalfName: WideString;
    modelCode: Integer;
    modelSubCode: Integer;
    modelFullName: WideString;
    modelHalfName: WideString)
    : Integer; stdcall;


// 車種名称取得処理
function MAHNB01012B_GetModelFullName(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer)
    : Integer; stdcall;


// 車種半角名称取得処理
function MAHNB01012B_GetModelHalfName(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer)
    : Integer; stdcall;


// 車両情報テーブル行の管理番号セット
function MAHNB01012B_SettingCarInfoRowFromCarMngCode(salesRowNo: Integer;
    carMngCode: WideString)
    : Integer; stdcall;


// 車両情報テーブル行の型式指定番号および類別区分番号セット
function MAHNB01012B_SettingCarInfoRowFromCategoryNoAndDesignationNo(salesRowNo: Integer;
    modelDesignationNo: Integer;
    categoryNo: Integer)
    : Integer; stdcall;


// 車両情報テーブル行の型式セット
function MAHNB01012B_SettingCarInfoRowFromFullModel(salesRowNo: Integer;
    fullModel: WideString)
    : Integer; stdcall;


// 車両情報テーブル行のエンジン型式セット
function MAHNB01012B_SettingCarInfoRowFromEngineModelNm(salesRowNo: Integer;
    engineModelNm: WideString)
    : Integer; stdcall;


// 車両情報存在チェック
function MAHNB01012B_ExistCarInfo()
    : Integer; stdcall;

// --- ADD 2014/05/19 T.Miyamoto 仕掛一覧№2218 ------------------------------>>>>>
// 車両情報テーブル行の車輌備考コードセット
function MAHNB01012B_SettingCarInfoRowFromCarNoteCode(salesRowNo: Integer;
    carNoteCode: Integer)
    : Integer; stdcall;
// --- ADD 2014/05/19 T.Miyamoto 仕掛一覧№2218 ------------------------------<<<<<

// 車両情報テーブル行の車輌備考セット
function MAHNB01012B_SettingCarInfoRowFromCarNote(salesRowNo: Integer;
    carNote: WideString)
    : Integer; stdcall;


// 車両情報テーブル行の車輌走行距離セット
function MAHNB01012B_SettingCarInfoRowFromMileage(salesRowNo: Integer;
    mileage: Integer)
    : Integer; stdcall;

// add by gaofeng start

// 拠点ガイド処理
function MAHNB01012B_sectionGuide(enterpriseCode: WideString;
    formName: WideString;
    var salesSlip: TSalesSlip)
    : Integer; stdcall;

// 部門ガイド処理
function MAHNB01012B_subSectionGuide(enterpriseCode: WideString;
    var salesSlip: TSalesSlip)
    : Integer; stdcall;

// 従業員ガイド処理
function MAHNB01012B_employeeGuide(sender: WideString;
    enterpriseCode: WideString;
    salesInputNm: WideString;
    salesInputCode: WideString;
    var salesSlip: TSalesSlip;
    var isReInputErr: Boolean)
    : Integer; stdcall;

// 管理番号ガイド処理
function MAHNB01012B_carMngNoGuide(customerCode: Integer;
    enterpriseCode: WideString;
    var selectedInfo: TCarMangInputExtraInfo;
    var resultStatus: Integer;
    salesRowNo: Integer;
    carMngCode: string)
    : Integer; stdcall;

// 車種ガイド処理
function MAHNB01012B_modelFullGuide(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer;
    enterpriseCode: WideString;
    salesRowNo: Integer;
    var modelNameU: TModelNameU)
    : Integer; stdcall;

// 備考ガイドボボタン処理
function MAHNB01012B_slipNote(sender: WideString;
    enterpriseCode: WideString;
    var salesSlip: TSalesSlip)
    : Integer; stdcall;

// 率算定処理
function MAHNB01012B_GetRate(numerator: Double;
    denominator: Double;
    var rate: Double)
    : Integer; stdcall;

// --- ADD 2010/05/31 ---------->>>>>
// CalculationSalesPrice
function MAHNB01012B_CalculationSalesPrice()
    : Integer; stdcall;
// --- ADD 2010/05/31 ----------<<<<<
// add by gaofeng end

    // add by Zhangkai start


    // add by Zhangkai end

    // add by Lizc start
// カーメーカーコードのフォーカス処理
function MAHNB01012B_AfterMakerCodeFocus(makerCode: Integer;
    salesRowNo: Integer;
    var makerName: WideString)
    : Integer; stdcall;


// 車種コードのフォーカス処理
function MAHNB01012B_AfterModelCodeFocus(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer;
    salesRowNo: Integer;
    var modelFullName: WideString)
    : Integer; stdcall;


// 車種呼称コードのフォーカス処理
function MAHNB01012B_AfterModelSubCodeFocus(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer;
    salesRowNo: Integer;
    var modelFullName: WideString)
    : Integer; stdcall;


// 車種名称のフォーカス処理
function MAHNB01012B_AfterModelFullNameFocus(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer;
    modelFullName: WideString;
    salesRowNo: Integer)
    : Integer; stdcall;


// 年式のフォーカス処理
function MAHNB01012B_AfterFirstEntryDateFocus(firstEntryDate: Integer;
    salesRowNo: Integer;
    var boolRet: Boolean)
    : Integer; stdcall;
    
// 車台番号のフォーカス処理
function MAHNB01012B_AfterProduceFrameNoFocus(produceFrameNo: WideString;
    salesRowNo: Integer;
    var boolRet: Boolean;
    mode : Integer)
    : Integer; stdcall;

// 追加情報タブ項目Visible設定
function MAHNB01012B_SettingAddInfoVisible(customerCode: Integer;
    carMngCode: WideString;
    salesRowNo: Integer;
    var boolRet: Boolean)
    : Integer; stdcall;
    
// 車種変更ボタンVisible
function MAHNB01012B_GetChangeCarInfoVisible(customerCode: Integer;
    carMngCode: WideString;
    var visibleFlag: Integer)
    : Integer; stdcall;
    
// 管理番号のフォーカス処理
function MAHNB01012B_AfterCarMngCodeFocus(carMngCode: WideString;
    customerCode: Integer;
    enterpriseCode: WideString;
    salesRowNo: Integer;
    var selectedInfo: TCarMangInputExtraInfo;
    var returnFlag: Boolean;
    var clearCarInfoFlag: Boolean)
    : Integer; stdcall;
    
// 拠点コードのフォーカス処理
function MAHNB01012B_AfterSectionCodeFocus(sectionCode: WideString;
    var refSalesSlip: TSalesSlip)
    : Integer; stdcall;
    
// 部門名称取得処理
function MAHNB01012B_GetNameFromSubSection(subSectionCode: Integer;
    var subSectionNm: WideString)
    : Integer; stdcall;
    
// 担当者変更処理
function MAHNB01012B_ChangeSalesEmployee(var refSalesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    code: WideString;
    var refCanChangeFocus: Boolean)
    : Integer; stdcall;
    
// 受注者変更処理
function MAHNB01012B_ChangeFrontEmployee(var refSalesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    code: WideString;
    var refCanChangeFocus: Boolean)
    : Integer; stdcall;


// 発行者変更処理
function MAHNB01012B_ChangeSalesInput(var refSalesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    code: WideString;
    var refCanChangeFocus: Boolean)
    : Integer; stdcall;
    
// 伝票区分変更処理
function MAHNB01012B_ChangeSalesSlip(var refSalesSlip: TSalesSlip;
    isCache: Boolean;
    code: Integer;
    var refChangeSalesSlipDisplay: Boolean;
    var clearDetailInput: Boolean;
    var clearCarInfo: Boolean)
    : Integer; stdcall;


// 商品区分変更処理
function MAHNB01012B_ChangeSalesGoodsCd(salesSlipCurrent: TSalesSlip;
    code: Integer;
    var refChangeSalesGoodsCd: Boolean;
    var clearDetailInput: Boolean;
    var clearCarInfo: Boolean)
    : Integer; stdcall;
    
// 得意先コードのフォーカス処理
function MAHNB01012B_AfterCustomerCodeFocus(var refSalesSlip: TSalesSlip;
    code: Integer;
    var refCustomerInfo: TCustomerInfo;
    var clearAddCarInfo: Boolean;
    var refCanChangeFocus: Boolean;
    var refReCalcSalesPrice: Boolean;
    var refGuideStart: Boolean;
    var clearDetailInput: Boolean;
    var clearCarInfo: Boolean;
    var refReCalcSalesUnitPrice: Boolean;
    var refClearRateInfo: Boolean)
    : Integer; stdcall;
    
// 伝票番号のフォーカス処理
function MAHNB01012B_AfterSalesSlipNumFocus(var refSalesSlip: TSalesSlip;
    var refSalesSlipCurrent: TSalesSlip;
    code: WideString;
    enterpriseCode: WideString;
    var equelFlag: Boolean;
    var readDBDatStatus: Integer;
    var refReCalcSalesPrice: Boolean;
    var deleteEmptyRow: Boolean;
    var findDataFlg: Boolean)   // ADD 2010/07/01
    : Integer; stdcall;


// 受注ステータスリスト作成
function MAHNB01012B_SetStateList()
    : Integer; stdcall;
    
// 売上日のフォーカス処理
function MAHNB01012B_AfterSalesDateFocus(var refSalesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    salesDate: Int64;
    salesDateText: WideString;
    var refReCalcSalesUnitPrice: Boolean;
    var refReCalcSalesPrice: Boolean;
    var refTaxRate: Double;
    var refReCanChangeFocus: Boolean) // ADD K2011/08/12
    : Integer; stdcall;


// 納入先コードのフォーカス処理
function MAHNB01012B_AfterAddresseeCodeFocue(var refSalesSlip: TSalesSlip;
    code: Integer;
    enterpriseCode: WideString;
    var refReCalcSalesPrice: Boolean)
    : Integer; stdcall;
    
// 売上データオブジェクトをインスタンス変数にキャッシュします。
function MAHNB01012B_CacheForChange(salesSlip: TSalesSlip)
    : Integer; stdcall;

// メモリ上の内容と比較
function MAHNB01012B_CompareSalesSlip(salesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    var compareRes: Boolean)
    : Integer; stdcall;
    
// 売上単価再計算
function MAHNB01012B_ReCalcSalesUnitPrice(var refSalesSlip: TSalesSlip)
    : Integer; stdcall;


// 掛率情報クリア処理（全て）
function MAHNB01012B_ClearAllRateInfo()
    : Integer; stdcall;


// 備考１コードのフォーカス処理
function MAHNB01012B_AfterSlipNoteCodeFocus(var refSalesSlip: TSalesSlip;
    value: Integer)
    : Integer; stdcall;


// 備考２コードのフォーカス処理
function MAHNB01012B_AfterSlipNote2CodeFocus(var refSalesSlip: TSalesSlip;
    value: Integer;
    var refReCanChangeFocus: Boolean) // ADD K2011/08/12
    : Integer; stdcall;

// ----- ADD K2011/08/12 --------------------------->>>>>
// 備考２のフォーカス処理
function MAHNB01012B_AfterSlipNote2Focus(salesSlip: TSalesSlip;
    slipNote2: WideString;
    var refReCanChangeFocus: Boolean)
    : Integer; stdcall;
// ----- ADD K2011/08/12 ---------------------------<<<<<


// 備考３コードのフォーカス処理
function MAHNB01012B_AfterSlipNote3CodeFocus(var refSalesSlip: TSalesSlip;
    value: Integer)
    : Integer; stdcall;
    
// 売上データ処理
function MAHNB01012B_GetSalesSlip(var salesSlip: TSalesSlip)
    : Integer; stdcall;
    
// 請求先確認ボタンクリック
function MAHNB01012B_CustomerClaimConfirmationClick(salesDate: Int64;
    var focus: WideString)
    : Integer; stdcall;


// 納入先確認ボタンクリック
function MAHNB01012B_AddresseeConfirmationClick(var salesSlip: TSalesSlip)
    : Integer; stdcall;
    
// 売上明細データの存在チェック
function MAHNB01012B_ExistSalesDetail(var exist: Boolean)
    : Integer; stdcall;


// 売上形式変更可能チェック処理
function MAHNB01012B_ChangeCheckAcptAnOdrStatus(code: Integer;
    salesSlip: TSalesSlip;
    var clearDisplayCarInfo: Boolean;
    var clearAddUpInfo: Boolean;
    var result1: Boolean)
    : Integer; stdcall;


// 売上形式変更可能処理
function MAHNB01012B_ChangeAcptAnOdrStatus(code: Integer;
    var refSalesSlip: TSalesSlip;
    svCode: Integer)
    : Integer; stdcall;


// 売上データキャッシュ処理
function MAHNB01012B_Cache(salesSlip: TSalesSlip)
    : Integer; stdcall;
    
// 表示用伝票区分より、データ用の伝票区分、売掛区分をセットします
function MAHNB01012B_SetSlipCdAndAccRecDivCdFromDisplay(var refSalesSlip: TSalesSlip)
    : Integer; stdcall;
    
// 装備情報選択処理
function MAHNB01012B_SelectEquipInfo(carRelationGuid: WideString;
    equipmentGenreCd: WideString;
    equipmentName: WideString)
    : Integer; stdcall;
    
// データ変更フラグの設定処理
function MAHNB01012B_SetGetIsDataChanged(flag: Integer;
    var refIsDataChanged: Boolean)
    : Integer; stdcall;
    
// ヘッダフォーカス設定リストの取込処理
function MAHNB01012B_GetHeaderFocusConstructionListValue(var headerFocusConstructionList: TSalesSlipInputCustomArrayB5;
    var footerFocusConstructionList: TSalesSlipInputCustomArrayB6)
    : Integer; stdcall;


// フォーカス設定リストの取込処理
function MAHNB01012B_GetFocusConstructionValue(var headerList: WideString;
    var footerList: WideString)
    : Integer; stdcall;
    
// 拠点名称の取込処理
function MAHNB01012B_GetSectionNm(section: WideString;
    var sectionName: WideString)
    : Integer; stdcall;

// --- ADD 2010/07/16 ---------->>>>>    
// 車両検索区分の取込処理
function MAHNB01012B_SetGetSearchCarDiv(flag: Integer;
    var refSearchCarDiv: Boolean)
    : Integer; stdcall;
// --- ADD 2010/07/16 ----------<<<<<

// --- ADD 2012/02/09 ---------->>>>>
// 印刷中フラグの取込処理
function MAHNB01012B_GetPrintThreadOverFlag(var printThreadOverFlag: Boolean)
    : Integer; stdcall;
// --- ADD 2012/02/09  ----------<<<<<
    // add by Lizc end

    // add by Yangmj start
// ツールチップ生成処理
// ツールチップ生成処理
function MAHNB01012B_CreateStockCountInfoString(salesRowNo: Integer;
    var StockCountInfo: WideString)
    : Integer; stdcall;

    // add by Yangmj end

    // add by Tanhong start

    // add by Tanhong end

// --- ADD m.suzuki 2010/06/12 ---------->>>>>
procedure MAHNB01012B_MakeMailDefaultData( var fileName: WideString ); stdcall;
// --- ADD m.suzuki 2010/06/12 ----------<<<<<

//2010/06/15 yamaji ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
function MAHNB01012B_CopyToRC(salesRowNo: Integer) : Integer; stdcall;
//2010/06/15 yamaji ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

// --- ADD 2013/03/21 ---------->>>>>
// ハンドル位置チェック処理
function MAHNB01012B_CheckHandlePosition(carRelationGuid: WideString;
    vinCode: WideString)
    : Boolean; stdcall;
// --- ADD 2013/03/21 ----------<<<<<

implementation

// オプション情報処理
function MAHNB01012B_GetSettingOptionInfo(var optCarMng: Integer;
    var optStockingPayment: Integer)
    : Integer; stdcall;

var
    status: Integer;
    resultOptCarMng: Integer;
    resultOptStockingPayment: Integer;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;
    optCarMng := 0;
    optStockingPayment := 0;

    try
        try
            // 結果データを初期化
            resultOptCarMng := 0;
            resultOptStockingPayment := 0;

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_GetSettingOptionInfo(resultOptCarMng, resultOptStockingPayment);
            // 結果コピー
            optCarMng := resultOptCarMng;
            optStockingPayment := resultOptStockingPayment;

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

// 車両検索処理
function MAHNB01012B_CarSearch(condition: TCarSearchCondition;
    salesRowNo: Integer;
    conditionType: Integer)
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
            status := gpxSalesSlipInputAcs_CarSearch(condition, salesRowNo, conditionType);
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

// 車両情報行オブジェクト取得
function MAHNB01012B_GetCarInfoRow(salesRowNo: Integer;
    getCarInfoMode: Integer;
    var carInfo: TCarInfo)
    : Integer; stdcall;

var
    status: Integer;
    resultCarInfo: TCarInfo;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            ClearTCarInfo(resultCarInfo);

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_GetCarInfoRow(salesRowNo, getCarInfoMode, resultCarInfo);
            // 結果コピー
            carInfo := resultCarInfo;

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

// カラー情報取得処理
function MAHNB01012B_GetColorInfo(carRelationGuid: WideString;
    var colorInfoList: TSalesSlipInputCustomArrayB2)
    : Integer; stdcall;

var
    status: Integer;
    //resultColorInfoList: TSalesSlipInputCustomArrayB2;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_GetColorInfo(carRelationGuid, colorInfoList);
            // 結果コピー
            //colorInfoList := resultColorInfoList;

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
        //gpxSalesSlipInputAcs_FreeCustomArrayB2(@colorInfoList, 0);

    end;
end;

// 選択カラー情報取得処理
function MAHNB01012B_GetSelectColorInfo(carRelationGuid: WideString;
    var colorInfo: TColorInfo)
    : Integer; stdcall;

var
    status: Integer;
    resultColorInfo: TColorInfo;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            ClearTColorInfo(resultColorInfo);

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_GetSelectColorInfo(carRelationGuid, resultColorInfo);
            // 結果コピー
            colorInfo := resultColorInfo;

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

// トリム情報取得処理
function MAHNB01012B_GetTrimInfo(carRelationGuid: WideString;
    var trimInfoList: TSalesSlipInputCustomArrayB3)
    : Integer; stdcall;

var
    status: Integer;
    //resultTrimInfoList: TSalesSlipInputCustomArrayB3;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_GetTrimInfo(carRelationGuid, trimInfoList);
            // 結果コピー
            //trimInfoList := resultTrimInfoList;

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
        //gpxSalesSlipInputAcs_FreeCustomArrayB3(@resultTrimInfoList, 0);

    end;
end;

// 選択トリム情報取得処理
function MAHNB01012B_GetSelectTrimInfo(carRelationGuid: WideString;
    var trimInfo: TTrimInfo)
    : Integer; stdcall;

var
    status: Integer;
    resultTrimInfo: TTrimInfo;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            ClearTTrimInfo(resultTrimInfo);

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_GetSelectTrimInfo(carRelationGuid, resultTrimInfo);
            // 結果コピー
            trimInfo := resultTrimInfo;

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

// 装備情報取得処理
function MAHNB01012B_GetEquipInfo(carRelationGuid: WideString;
    var cEqpDefDspInfoList: TSalesSlipInputCustomArrayB4)
    : Integer; stdcall;

var
    status: Integer;
    //resultCEqpDefDspInfoList: TSalesSlipInputCustomArrayB4;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_GetEquipInfo(carRelationGuid, cEqpDefDspInfoList);
            // 結果コピー
            //cEqpDefDspInfoList := resultCEqpDefDspInfoList;

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
        //gpxSalesSlipInputAcs_FreeCustomArrayB4(@resultCEqpDefDspInfoList, 0);

    end;
end;

// カラー情報選択処理
function MAHNB01012B_SelectColorInfo(carRelationGuid: WideString;
    colorCode: WideString)
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
            status := gpxSalesSlipInputAcs_SelectColorInfo(carRelationGuid, colorCode);
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

// トリム情報選択処理
function MAHNB01012B_SelectTrimInfo(carRelationGuid: WideString;
    trimCode: WideString)
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
            status := gpxSalesSlipInputAcs_SelectTrimInfo(carRelationGuid, trimCode);
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

// 生産年式範囲チェック
function MAHNB01012B_CheckProduceTypeOfYearRange(carRelationGuid: WideString;
    firstEntryDate: Integer)
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
            status := gpxSalesSlipInputAcs_CheckProduceTypeOfYearRange(carRelationGuid, firstEntryDate);
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

// 車両検索データテーブル年式設定処理
function MAHNB01012B_SettingCarModelUIDataFromFirstEntryDate(carRelationGuid: WideString;
    firstEntryDate: WideString)
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
            status := gpxSalesSlipInputAcs_SettingCarModelUIDataFromFirstEntryDate(carRelationGuid, firstEntryDate);
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

// 車台番号範囲チェック
function MAHNB01012B_CheckProduceFrameNo(carRelationGuid: WideString;
    inputFrameNo: WideString;
    searchFrameNo: Integer)
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
            status := gpxSalesSlipInputAcs_CheckProduceFrameNo(carRelationGuid, inputFrameNo, searchFrameNo);
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

// 車両検索データテーブル車台番号設定処理
function MAHNB01012B_SettingCarModelUIDataFromProduceFrameNo(carRelationGuid: WideString;
    frameNo: WideString)
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
            status := gpxSalesSlipInputAcs_SettingCarModelUIDataFromProduceFrameNo(carRelationGuid, frameNo);
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

// 対象年式取得処理(車台番号より取得)
function MAHNB01012B_GetProduceTypeOfYear(carRelationGuid: WideString;
    frameNo: WideString)
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
            status := gpxSalesSlipInputAcs_GetProduceTypeOfYear(carRelationGuid, frameNo);
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

// 車両情報テーブルのクリア
function MAHNB01012B_ClearCarInfoRow(salesRowNo: Integer)
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
            status := gpxSalesSlipInputAcs_ClearCarInfoRow(salesRowNo);
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

// 車両情報テーブル行の年式セット
function MAHNB01012B_SettingCarInfoRowFromFirstEntryDate(salesRowNo: Integer;
    firstEntryDate: Integer)
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
            status := gpxSalesSlipInputAcs_SettingCarInfoRowFromFirstEntryDate(salesRowNo, firstEntryDate);
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

// 車両情報テーブル行の車台番号セット
function MAHNB01012B_SettingCarInfoRowFromFrameNo(salesRowNo: Integer;
    frameNo: WideString)
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
            status := gpxSalesSlipInputAcs_SettingCarInfoRowFromFrameNo(salesRowNo, frameNo);
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

// 車両情報テーブル行の車種情報セット
function MAHNB01012B_SettingCarInfoRowFromModelInfo(salesRowNo: Integer;
    makerCode: Integer;
    makerFullName: WideString;
    makerHalfName: WideString;
    modelCode: Integer;
    modelSubCode: Integer;
    modelFullName: WideString;
    modelHalfName: WideString)
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
            status := gpxSalesSlipInputAcs_SettingCarInfoRowFromModelInfo(salesRowNo, makerCode, makerFullName, makerHalfName, modelCode, modelSubCode, modelFullName, modelHalfName);
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

// 車種名称取得処理
function MAHNB01012B_GetModelFullName(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer)
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
            status := gpxSalesSlipInputAcs_GetModelFullName(makerCode, modelCode, modelSubCode);
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

// 車種半角名称取得処理
function MAHNB01012B_GetModelHalfName(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer)
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
            status := gpxSalesSlipInputAcs_GetModelHalfName(makerCode, modelCode, modelSubCode);
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

// 車両情報テーブル行の管理番号セット
function MAHNB01012B_SettingCarInfoRowFromCarMngCode(salesRowNo: Integer;
    carMngCode: WideString)
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
            status := gpxSalesSlipInputAcs_SettingCarInfoRowFromCarMngCode(salesRowNo, carMngCode);
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

// 車両情報テーブル行の型式指定番号および類別区分番号セット
function MAHNB01012B_SettingCarInfoRowFromCategoryNoAndDesignationNo(salesRowNo: Integer;
    modelDesignationNo: Integer;
    categoryNo: Integer)
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
            status := gpxSalesSlipInputAcs_SettingCarInfoRowFromCategoryNoAndDesignationNo(salesRowNo, modelDesignationNo, categoryNo);
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

// 車両情報テーブル行の型式セット
function MAHNB01012B_SettingCarInfoRowFromFullModel(salesRowNo: Integer;
    fullModel: WideString)
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
            status := gpxSalesSlipInputAcs_SettingCarInfoRowFromFullModel(salesRowNo, fullModel);
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

// 車両情報テーブル行のエンジン型式セット
function MAHNB01012B_SettingCarInfoRowFromEngineModelNm(salesRowNo: Integer;
    engineModelNm: WideString)
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
            status := gpxSalesSlipInputAcs_SettingCarInfoRowFromEngineModelNm(salesRowNo, engineModelNm);
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

// 車両情報存在チェック
function MAHNB01012B_ExistCarInfo()
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
            status := gpxSalesSlipInputAcs_ExistCarInfo();
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

// --- ADD 2014/05/19 T.Miyamoto 仕掛一覧№2218 ------------------------------>>>>>
// 車両情報テーブル行の車輌備考コードセット
function MAHNB01012B_SettingCarInfoRowFromCarNoteCode(salesRowNo: Integer;
    carNoteCode: Integer)
    : Integer; stdcall;

var
    status: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_SettingCarInfoRowFromCarNoteCode(salesRowNo, carNoteCode);
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
// --- ADD 2014/05/19 T.Miyamoto 仕掛一覧№2218 ------------------------------<<<<<

// 車両情報テーブル行の車輌備考セット
function MAHNB01012B_SettingCarInfoRowFromCarNote(salesRowNo: Integer;
    carNote: WideString)
    : Integer; stdcall;

var
    status: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_SettingCarInfoRowFromCarNote(salesRowNo, carNote);
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

// 車両情報テーブル行の車輌走行距離セット
function MAHNB01012B_SettingCarInfoRowFromMileage(salesRowNo: Integer;
    mileage: Integer)
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
            status := gpxSalesSlipInputAcs_SettingCarInfoRowFromMileage(salesRowNo, mileage);
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
// add by gaofeng start

function MAHNB01012B_sectionGuide(enterpriseCode: WideString;
    formName: WideString;
    var salesSlip: TSalesSlip)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            ClearTSalesSlip(resultSalesSlip);

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_sectionGuide(enterpriseCode, formName, resultSalesSlip);
            // 結果コピー
            salesSlip := resultSalesSlip;

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

// 部門ガイド処理
function MAHNB01012B_subSectionGuide(enterpriseCode: WideString;
    var salesSlip: TSalesSlip)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            ClearTSalesSlip(resultSalesSlip);

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_subSectionGuide(enterpriseCode, resultSalesSlip);
            // 結果コピー
            salesSlip := resultSalesSlip;

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

// 従業員ガイド処理
function MAHNB01012B_employeeGuide(sender: WideString;
    enterpriseCode: WideString;
    salesInputNm: WideString;
    salesInputCode: WideString;
    var salesSlip: TSalesSlip;
    var isReInputErr: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;
    resultIsReInputErr: Boolean;
    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            ClearTSalesSlip(resultSalesSlip);

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_employeeGuide(sender, enterpriseCode, salesInputNm, salesInputCode, resultSalesSlip, resultIsReInputErr);
            // 結果コピー
            salesSlip := resultSalesSlip;
            isReInputErr := resultIsReInputErr;
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

// 管理番号ガイド処理
function MAHNB01012B_carMngNoGuide(customerCode: Integer;
    enterpriseCode: WideString;
    var selectedInfo: TCarMangInputExtraInfo;
    var resultStatus: Integer;
    salesRowNo: Integer;
    carMngCode: string)
    : Integer; stdcall;
var
    status: Integer;
    resultSelectedInfo: TCarMangInputExtraInfo;
    paraStatus: Integer;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            ClearTCarMangInputExtraInfo(resultSelectedInfo);

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_carMngNoGuide(customerCode, enterpriseCode, resultSelectedInfo, paraStatus, salesRowNo, carMngCode);
            // 結果コピー
            selectedInfo := resultSelectedInfo;
            resultStatus := paraStatus;

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

// 車種ガイド処理
function MAHNB01012B_modelFullGuide(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer;
    enterpriseCode: WideString;
    salesRowNo: Integer;
    var modelNameU: TModelNameU)
    : Integer; stdcall;

var
    status: Integer;
    resultModelNameU: TModelNameU;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            ClearTModelNameU(resultModelNameU);

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_modelFullGuide(makerCode, modelCode, modelSubCode, enterpriseCode, salesRowNo, resultModelNameU);
            // 結果コピー
            modelNameU := resultModelNameU;

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

// 備考ガイドボボタン処理
function MAHNB01012B_slipNote(sender: WideString;
    enterpriseCode: WideString;
    var salesSlip: TSalesSlip)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            ClearTSalesSlip(resultSalesSlip);

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_slipNote(sender, enterpriseCode, resultSalesSlip);
            // 結果コピー
            salesSlip := resultSalesSlip;

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

// 率算定処理
function MAHNB01012B_GetRate(numerator: Double;
    denominator: Double;
    var rate: Double)
    : Integer; stdcall;

var
    status: Integer;
    resultRate: Double;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;
    rate := 0;

    try
        try
            // 結果データを初期化
            resultRate := 0;

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_GetRate(numerator, denominator, resultRate);
            // 結果コピー
            rate := resultRate;

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

// --- ADD 2010/05/31 ---------->>>>>
// CalculationSalesPrice
function MAHNB01012B_CalculationSalesPrice()
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
            status := gpxSalesSlipInputAcs_CalculationSalesPrice();
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

        // メッセージのメモリ解放
    end;
end;
// --- ADD 2010/05/31 ----------<<<<<

// add by gaofeng end

    // add by Zhangkai start

    // add by Zhangkai end

    // add by Lizc start
// カーメーカーコードのフォーカス処理
function MAHNB01012B_AfterMakerCodeFocus(makerCode: Integer;
    salesRowNo: Integer;
    var makerName: WideString)
    : Integer; stdcall;

var
    status: Integer;
    resultMakerName: WideString;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;
    makerName := '';

    try
        try
            // 結果データを初期化
            resultMakerName := '';

            // 検索メソッド呼出し
            gpxSalesSlipInputAcs_AfterMakerCodeFocus(makerCode, salesRowNo, resultMakerName);
            // 結果コピー
            makerName := resultMakerName;

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

// 車種コードのフォーカス処理
function MAHNB01012B_AfterModelCodeFocus(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer;
    salesRowNo: Integer;
    var modelFullName: WideString)
    : Integer; stdcall;

var
    status: Integer;
    resultModelFullName: WideString;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;
    modelFullName := '';

    try
        try
            // 結果データを初期化
            resultModelFullName := '';

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_AfterModelCodeFocus(makerCode, modelCode, modelSubCode, salesRowNo, resultModelFullName);
            // 結果コピー
            modelFullName := resultModelFullName;

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

// 車種呼称コードのフォーカス処理
function MAHNB01012B_AfterModelSubCodeFocus(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer;
    salesRowNo: Integer;
    var modelFullName: WideString)
    : Integer; stdcall;

var
    status: Integer;
    resultModelFullName: WideString;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;
    modelFullName := '';

    try
        try
            // 結果データを初期化
            resultModelFullName := '';

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_AfterModelSubCodeFocus(makerCode, modelCode, modelSubCode, salesRowNo, resultModelFullName);
            // 結果コピー
            modelFullName := resultModelFullName;

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

// 車種名称のフォーカス処理
function MAHNB01012B_AfterModelFullNameFocus(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer;
    modelFullName: WideString;
    salesRowNo: Integer)
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
            status := gpxSalesSlipInputAcs_AfterModelFullNameFocus(makerCode, modelCode, modelSubCode, modelFullName, salesRowNo);
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

// 年式のフォーカス処理
function MAHNB01012B_AfterFirstEntryDateFocus(firstEntryDate: Integer;
    salesRowNo: Integer;
    var boolRet: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultBoolRet: Boolean;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            //resultBoolRet := False;

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_AfterFirstEntryDateFocus(firstEntryDate, salesRowNo, resultBoolRet);
            // 結果コピー
            boolRet := resultBoolRet;

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

// 車台番号のフォーカス処理
function MAHNB01012B_AfterProduceFrameNoFocus(produceFrameNo: WideString;
    salesRowNo: Integer;
    var boolRet: Boolean;
    mode : Integer)
    : Integer; stdcall;

var
    status: Integer;
    resultBoolRet: Boolean;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_AfterProduceFrameNoFocus(produceFrameNo, salesRowNo, resultBoolRet, mode);
            // 結果コピー
            boolRet := resultBoolRet;

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

// 追加情報タブ項目Visible設定
function MAHNB01012B_SettingAddInfoVisible(customerCode: Integer;
    carMngCode: WideString;
    salesRowNo: Integer;
    var boolRet: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultBoolRet: Boolean;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_SettingAddInfoVisible(customerCode, carMngCode, salesRowNo, resultBoolRet);
            // 結果コピー
            boolRet := resultBoolRet;

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

// 車種変更ボタンVisible
function MAHNB01012B_GetChangeCarInfoVisible(customerCode: Integer;
    carMngCode: WideString;
    var visibleFlag: Integer)
    : Integer; stdcall;

var
    status: Integer;
    resultVisibleFlag: Integer;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;
    visibleFlag := 0;

    try
        try
            // 結果データを初期化
            resultVisibleFlag := 0;

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_GetChangeCarInfoVisible(customerCode, carMngCode, resultVisibleFlag);
            // 結果コピー
            visibleFlag := resultVisibleFlag;

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

// 管理番号のフォーカス処理
function MAHNB01012B_AfterCarMngCodeFocus(carMngCode: WideString;
    customerCode: Integer;
    enterpriseCode: WideString;
    salesRowNo: Integer;
    var selectedInfo: TCarMangInputExtraInfo;
    var returnFlag: Boolean;
    var clearCarInfoFlag: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultSelectedInfo: TCarMangInputExtraInfo;
    //resultReturnFlag: Tbool;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            ClearTCarMangInputExtraInfo(resultSelectedInfo);
            //ClearTbool(resultReturnFlag);

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_AfterCarMngCodeFocus(carMngCode, customerCode, enterpriseCode, salesRowNo, resultSelectedInfo, returnFlag, clearCarInfoFlag);
            // 結果コピー
            selectedInfo := resultSelectedInfo;
            //refReturnFlag := resultReturnFlag;

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

// 拠点コードのフォーカス処理
function MAHNB01012B_AfterSectionCodeFocus(sectionCode: WideString;
    var refSalesSlip: TSalesSlip)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            ClearTSalesSlip(resultSalesSlip);

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_AfterSectionCodeFocus(sectionCode, refSalesSlip, resultSalesSlip);
            // 結果コピー
            refSalesSlip := resultSalesSlip;

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

// 部門名称取得処理
function MAHNB01012B_GetNameFromSubSection(subSectionCode: Integer;
    var subSectionNm: WideString)
    : Integer; stdcall;

var
    status: Integer;
    resultSubSectionNm: WideString;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;
    subSectionNm := '';

    try
        try
            // 結果データを初期化
            resultSubSectionNm := '';

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_GetNameFromSubSection(subSectionCode, resultSubSectionNm);
            // 結果コピー
            subSectionNm := resultSubSectionNm;

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

// 担当者変更処理
function MAHNB01012B_ChangeSalesEmployee(var refSalesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    code: WideString;
    var refCanChangeFocus: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;
    //resultCanChangeFocus: Boolean;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            ClearTSalesSlip(resultSalesSlip);
            //ClearTbool(resultCanChangeFocus);

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_ChangeSalesEmployee(refSalesSlip, resultSalesSlip, salesSlipCurrent, code, refCanChangeFocus, refCanChangeFocus);
            // 結果コピー
            refSalesSlip := resultSalesSlip;
            //refCanChangeFocus := resultCanChangeFocus;

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

// 受注者変更処理
function MAHNB01012B_ChangeFrontEmployee(var refSalesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    code: WideString;
    var refCanChangeFocus: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;
    resultCanChangeFocus: Boolean;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            ClearTSalesSlip(resultSalesSlip);

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_ChangeFrontEmployee(refSalesSlip, resultSalesSlip, salesSlipCurrent, code, refCanChangeFocus, resultCanChangeFocus);
            // 結果コピー
            refSalesSlip := resultSalesSlip;
            refCanChangeFocus := resultCanChangeFocus;

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

// 発行者変更処理
function MAHNB01012B_ChangeSalesInput(var refSalesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    code: WideString;
    var refCanChangeFocus: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;
    resultCanChangeFocus: Boolean;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            ClearTSalesSlip(resultSalesSlip);

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_ChangeSalesInput(refSalesSlip, resultSalesSlip, salesSlipCurrent, code, refCanChangeFocus, resultCanChangeFocus);
            // 結果コピー
            refSalesSlip := resultSalesSlip;
            refCanChangeFocus := resultCanChangeFocus;

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

// 伝票区分変更処理
function MAHNB01012B_ChangeSalesSlip(var refSalesSlip: TSalesSlip;
    isCache: Boolean;
    code: Integer;
    var refChangeSalesSlipDisplay: Boolean;
    var clearDetailInput: Boolean;
    var clearCarInfo: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;
    resultChangeSalesSlipDisplay: Boolean;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            ClearTSalesSlip(resultSalesSlip);

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_ChangeSalesSlip(refSalesSlip, resultSalesSlip, isCache, code, refChangeSalesSlipDisplay, resultChangeSalesSlipDisplay, clearDetailInput, clearCarInfo);
            // 結果コピー
            refSalesSlip := resultSalesSlip;
            refChangeSalesSlipDisplay := resultChangeSalesSlipDisplay;

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

// 商品区分変更処理
function MAHNB01012B_ChangeSalesGoodsCd(salesSlipCurrent: TSalesSlip;
    code: Integer;
    var refChangeSalesGoodsCd: Boolean;
    var clearDetailInput: Boolean;
    var clearCarInfo: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultChangeSalesGoodsCd: Boolean;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_ChangeSalesGoodsCd(salesSlipCurrent, code, refChangeSalesGoodsCd, resultChangeSalesGoodsCd, clearDetailInput, clearCarInfo);
            // 結果コピー
            refChangeSalesGoodsCd := resultChangeSalesGoodsCd;

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

// 得意先コードのフォーカス処理
function MAHNB01012B_AfterCustomerCodeFocus(var refSalesSlip: TSalesSlip;
    code: Integer;
    var refCustomerInfo: TCustomerInfo;
    var clearAddCarInfo: Boolean;
    var refCanChangeFocus: Boolean;
    var refReCalcSalesPrice: Boolean;
    var refGuideStart: Boolean;
    var clearDetailInput: Boolean;
    var clearCarInfo: Boolean;
    var refReCalcSalesUnitPrice: Boolean;
    var refClearRateInfo: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;
    resultCustomerInfo: TCustomerInfo;
    resultClearAddCarInfo: Boolean;
    resultCanChangeFocus: Boolean;
    resultReCalcSalesPrice: Boolean;
    resultGuideStart: Boolean;
    resultClearDetailInput: Boolean;
    resultClearCarInfo: Boolean;
    resultReCalcSalesUnitPrice: Boolean;
    resultClearRateInfo: Boolean;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            ClearTSalesSlip(resultSalesSlip);

            // --- ADD 2010/07/06 ----------<<<<<
            ClearTCustomerInfo(resultCustomerInfo);
            // --- ADD 2010/07/06 ---------->>>>>

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_AfterCustomerCodeFocus(refSalesSlip, resultSalesSlip, code, refCustomerInfo, resultCustomerInfo, resultClearAddCarInfo, refCanChangeFocus, resultCanChangeFocus, refReCalcSalesPrice, resultReCalcSalesPrice, refGuideStart, resultGuideStart, resultClearDetailInput, resultClearCarInfo, refReCalcSalesUnitPrice, resultReCalcSalesUnitPrice, refClearRateInfo, resultClearRateInfo);
            // 結果コピー
            refSalesSlip := resultSalesSlip;
            refCustomerInfo := resultCustomerInfo;
            clearAddCarInfo := resultClearAddCarInfo;
            refCanChangeFocus := resultCanChangeFocus;
            refReCalcSalesPrice := resultReCalcSalesPrice;
            refGuideStart := resultGuideStart;
            clearDetailInput := resultClearDetailInput;
            clearCarInfo := resultClearCarInfo;
            refReCalcSalesUnitPrice := resultReCalcSalesUnitPrice;
            refClearRateInfo := resultClearRateInfo;

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

// 伝票番号のフォーカス処理
function MAHNB01012B_AfterSalesSlipNumFocus(var refSalesSlip: TSalesSlip;
    var refSalesSlipCurrent: TSalesSlip;
    code: WideString;
    enterpriseCode: WideString;
    var equelFlag: Boolean;
    var readDBDatStatus: Integer;
    var refReCalcSalesPrice: Boolean;
    var deleteEmptyRow: Boolean;
    var findDataFlg: Boolean)   // ADD 2010/07/01
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;
    resultSalesSlipCurrent: TSalesSlip;
    resultEquelFlag: Boolean;
    resultReadDBDatStatus: Integer;
    resultReCalcSalesPrice: Boolean;
    resultDeleteEmptyRow: Boolean;
    resultFindDataFlg: Boolean;     // ADD 2010/07/01

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;
    readDBDatStatus := 0;

    try
        try
            // 結果データを初期化
            ClearTSalesSlip(resultSalesSlip);
            ClearTSalesSlip(resultSalesSlipCurrent);
            resultReadDBDatStatus := 0;

            // 検索メソッド呼出し
            // --- UPD 2010/07/01 --------->>>>>
//            status := gpxSalesSlipInputAcs_AfterSalesSlipNumFocus(refSalesSlip, resultSalesSlip, refSalesSlipCurrent, resultSalesSlipCurrent, code, enterpriseCode, resultEquelFlag, resultReadDBDatStatus, refReCalcSalesPrice, resultReCalcSalesPrice, resultDeleteEmptyRow);
            status := gpxSalesSlipInputAcs_AfterSalesSlipNumFocus(refSalesSlip, resultSalesSlip, refSalesSlipCurrent, resultSalesSlipCurrent, code, enterpriseCode, resultEquelFlag, resultReadDBDatStatus, refReCalcSalesPrice, resultReCalcSalesPrice, resultDeleteEmptyRow, resultFindDataFlg);
            // --- UPD 2010/07/01 ---------<<<<<

            // 結果コピー
            refSalesSlip := resultSalesSlip;
            refSalesSlipCurrent := resultSalesSlipCurrent;
            equelFlag := resultEquelFlag;
            readDBDatStatus := resultReadDBDatStatus;
            refReCalcSalesPrice := resultReCalcSalesPrice;
            deleteEmptyRow := resultDeleteEmptyRow;
            findDataFlg := resultFindDataFlg;  // ADD 2010/07/01

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

// 受注ステータスリスト作成
function MAHNB01012B_SetStateList()
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
            status := gpxSalesSlipInputAcs_SetStateList();
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

// 売上日のフォーカス処理
function MAHNB01012B_AfterSalesDateFocus(var refSalesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    salesDate: Int64;
    salesDateText: WideString;
    var refReCalcSalesUnitPrice: Boolean;
    var refReCalcSalesPrice: Boolean;
    var refTaxRate: Double;
    var refReCanChangeFocus: Boolean) // ADD K2011/08/12
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;
    resultReCalcSalesUnitPrice: Boolean;
    resultReCalcSalesPrice: Boolean;
    resultTaxRate: Double;
    resultReCanChangeFocus: Boolean; // ADD K2011/08/12

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            ClearTSalesSlip(resultSalesSlip);
            resultTaxRate := 0;

            // 検索メソッド呼出し
            //status := gpxSalesSlipInputAcs_AfterSalesDateFocus(refSalesSlip, resultSalesSlip, salesSlipCurrent, salesDate, salesDateText, refReCalcSalesUnitPrice, resultReCalcSalesUnitPrice, refReCalcSalesPrice, resultReCalcSalesPrice, resultTaxRate); // DEL K2011/08/12
            status := gpxSalesSlipInputAcs_AfterSalesDateFocus(refSalesSlip, resultSalesSlip, salesSlipCurrent, salesDate, salesDateText, refReCalcSalesUnitPrice, resultReCalcSalesUnitPrice, refReCalcSalesPrice, resultReCalcSalesPrice, resultTaxRate, resultReCanChangeFocus); // ADD K2011/08/12
            // 結果コピー
            refSalesSlip := resultSalesSlip;
            refReCalcSalesUnitPrice := resultReCalcSalesUnitPrice;
            refReCalcSalesPrice := resultReCalcSalesPrice;
            refTaxRate := resultTaxRate;
            refReCanChangeFocus := resultReCanChangeFocus; // ADD K2011/08/12

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

// 納入先コードのフォーカス処理
function MAHNB01012B_AfterAddresseeCodeFocue(var refSalesSlip: TSalesSlip;
    code: Integer;
    enterpriseCode: WideString;
    var refReCalcSalesPrice: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;
    resultReCalcSalesPrice: Boolean;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            ClearTSalesSlip(resultSalesSlip);

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_AfterAddresseeCodeFocue(refSalesSlip, resultSalesSlip, code, enterpriseCode, refReCalcSalesPrice, resultReCalcSalesPrice);
            // 結果コピー
            refSalesSlip := resultSalesSlip;
            refReCalcSalesPrice := resultReCalcSalesPrice;

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

// 売上データオブジェクトをインスタンス変数にキャッシュします。
function MAHNB01012B_CacheForChange(salesSlip: TSalesSlip)
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
            status := gpxSalesSlipInputAcs_CacheForChange(salesSlip);
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

// メモリ上の内容と比較
function MAHNB01012B_CompareSalesSlip(salesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    var compareRes: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultCompareRes: Boolean;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_CompareSalesSlip(salesSlip, salesSlipCurrent, resultCompareRes);
            // 結果コピー
            compareRes := resultCompareRes;

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

// 売上単価再計算
function MAHNB01012B_ReCalcSalesUnitPrice(var refSalesSlip: TSalesSlip)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            ClearTSalesSlip(resultSalesSlip);

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_ReCalcSalesUnitPrice(refSalesSlip, resultSalesSlip);
            // 結果コピー
            refSalesSlip := resultSalesSlip;

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

// 掛率情報クリア処理（全て）
function MAHNB01012B_ClearAllRateInfo()
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
            status := gpxSalesSlipInputAcs_ClearAllRateInfo();
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

// 備考１コードのフォーカス処理
function MAHNB01012B_AfterSlipNoteCodeFocus(var refSalesSlip: TSalesSlip;
    value: Integer)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            ClearTSalesSlip(resultSalesSlip);

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_AfterSlipNoteCodeFocus(refSalesSlip, resultSalesSlip, value);
            // 結果コピー
            refSalesSlip := resultSalesSlip;

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

// 備考２コードのフォーカス処理
function MAHNB01012B_AfterSlipNote2CodeFocus(var refSalesSlip: TSalesSlip;
    value: Integer;
    var refReCanChangeFocus: Boolean) // ADD K2011/08/12
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;

    I: Integer;
    resultReCanChangeFocus: Boolean; // ADD K2011/08/12
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            ClearTSalesSlip(resultSalesSlip);

            // 検索メソッド呼出し
            //status := gpxSalesSlipInputAcs_AfterSlipNote2CodeFocus(refSalesSlip, resultSalesSlip, value); // DEL K2011/08/12
            status := gpxSalesSlipInputAcs_AfterSlipNote2CodeFocus(refSalesSlip, resultSalesSlip, value, resultReCanChangeFocus); // ADD K2011/08/12
            // 結果コピー
            refSalesSlip := resultSalesSlip;
            refReCanChangeFocus := resultReCanChangeFocus; // ADD K2011/08/12

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

// ----- ADD K2011/08/12 --------------------------->>>>>
// 備考２のフォーカス処理
function MAHNB01012B_AfterSlipNote2Focus(salesSlip: TSalesSlip;
    slipNote2: WideString;
    var refReCanChangeFocus: Boolean)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
    resultReCanChangeFocus: Boolean;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_AfterSlipNote2Focus(salesSlip, slipNote2, resultReCanChangeFocus);
            // 結果コピー
            refReCanChangeFocus := resultReCanChangeFocus;

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
// ----- ADD K2011/08/12 ---------------------------<<<<<

// 備考３コードのフォーカス処理
function MAHNB01012B_AfterSlipNote3CodeFocus(var refSalesSlip: TSalesSlip;
    value: Integer)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            ClearTSalesSlip(resultSalesSlip);

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_AfterSlipNote3CodeFocus(refSalesSlip, resultSalesSlip, value);
            // 結果コピー
            refSalesSlip := resultSalesSlip;

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

// 売上データ処理
function MAHNB01012B_GetSalesSlip(var salesSlip: TSalesSlip)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            ClearTSalesSlip(resultSalesSlip);

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_GetSalesSlip(resultSalesSlip);
            // 結果コピー
            salesSlip := resultSalesSlip;

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

// 請求先確認ボタンクリック
function MAHNB01012B_CustomerClaimConfirmationClick(salesDate: Int64;
    var focus: WideString)
    : Integer; stdcall;

var
    status: Integer;
    resultFocus: WideString;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;
    focus := '';

    try
        try
            // 結果データを初期化
            resultFocus := '';

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_CustomerClaimConfirmationClick(salesDate, resultFocus);
            // 結果コピー
            focus := resultFocus;

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

// 納入先確認ボタンクリック
function MAHNB01012B_AddresseeConfirmationClick(var salesSlip: TSalesSlip)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            ClearTSalesSlip(resultSalesSlip);

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_AddresseeConfirmationClick(resultSalesSlip);
            // 結果コピー
            salesSlip := resultSalesSlip;

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

// 売上明細データの存在チェック
function MAHNB01012B_ExistSalesDetail(var exist: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultExist: Boolean;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_ExistSalesDetail(resultExist);
            // 結果コピー
            exist := resultExist;

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

// 売上形式変更可能チェック処理
function MAHNB01012B_ChangeCheckAcptAnOdrStatus(code: Integer;
    salesSlip: TSalesSlip;
    var clearDisplayCarInfo: Boolean;
    var clearAddUpInfo: Boolean;
    var result1: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultClearDisplayCarInfo: Boolean;
    resultClearAddUpInfo: Boolean;
    resultResult: Boolean;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_ChangeCheckAcptAnOdrStatus(code, salesSlip, resultClearDisplayCarInfo, resultClearAddUpInfo, resultResult);
            // 結果コピー
            clearDisplayCarInfo := resultClearDisplayCarInfo;
            clearAddUpInfo := resultClearAddUpInfo;
            result1 := resultResult;

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

// 売上形式変更可能処理
function MAHNB01012B_ChangeAcptAnOdrStatus(code: Integer;
    var refSalesSlip: TSalesSlip;
    svCode: Integer)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            ClearTSalesSlip(resultSalesSlip);

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_ChangeAcptAnOdrStatus(code, refSalesSlip, resultSalesSlip, svCode);
            // 結果コピー
            refSalesSlip := resultSalesSlip;

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

// 売上データキャッシュ処理
function MAHNB01012B_Cache(salesSlip: TSalesSlip)
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
            status := gpxSalesSlipInputAcs_Cache(salesSlip);
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

// 表示用伝票区分より、データ用の伝票区分、売掛区分をセットします
function MAHNB01012B_SetSlipCdAndAccRecDivCdFromDisplay(var refSalesSlip: TSalesSlip)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesSlip: TSalesSlip;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            ClearTSalesSlip(resultSalesSlip);

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_SetSlipCdAndAccRecDivCdFromDisplay(refSalesSlip, resultSalesSlip);
            // 結果コピー
            refSalesSlip := resultSalesSlip;

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

// 装備情報選択処理
function MAHNB01012B_SelectEquipInfo(carRelationGuid: WideString;
    equipmentGenreCd: WideString;
    equipmentName: WideString)
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
            status := gpxSalesSlipInputAcs_SelectEquipInfo(carRelationGuid, equipmentGenreCd, equipmentName);
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

// データ変更フラグの設定処理
function MAHNB01012B_SetGetIsDataChanged(flag: Integer;
    var refIsDataChanged: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultIsDataChanged: Boolean;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            //ClearTbool(resultIsDataChanged);
            resultIsDataChanged := refIsDataChanged;

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_SetGetIsDataChanged(flag, refIsDataChanged, resultIsDataChanged);
            // 結果コピー
            refIsDataChanged := resultIsDataChanged;

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

// ヘッダフォーカス設定リストの取込処理
function MAHNB01012B_GetHeaderFocusConstructionListValue(var headerFocusConstructionList: TSalesSlipInputCustomArrayB5;
    var footerFocusConstructionList: TSalesSlipInputCustomArrayB6)
    : Integer; stdcall;

var
    status: Integer;
    resultHeaderFocusConstructionList: TSalesSlipInputCustomArrayB5;
    resultFooterFocusConstructionList: TSalesSlipInputCustomArrayB6;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_GetHeaderFocusConstructionListValue(resultHeaderFocusConstructionList, resultFooterFocusConstructionList);
            // 結果コピー
            headerFocusConstructionList := resultHeaderFocusConstructionList;
            footerFocusConstructionList := resultFooterFocusConstructionList;

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
        gpxSalesSlipInputAcs_FreeCustomArrayB5(@resultHeaderFocusConstructionList, 0);
        gpxSalesSlipInputAcs_FreeCustomArrayB6(@resultFooterFocusConstructionList, 0);

    end;
end;

// フォーカス設定リストの取込処理
function MAHNB01012B_GetFocusConstructionValue(var headerList: WideString;
    var footerList: WideString)
    : Integer; stdcall;

var
    status: Integer;
    resultHeaderList: WideString;
    resultFooterList: WideString;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;
    headerList := '';
    footerList := '';

    try
        try
            // 結果データを初期化
            resultHeaderList := '';
            resultFooterList := '';

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_GetFocusConstructionValue(resultHeaderList, resultFooterList);
            // 結果コピー
            headerList := resultHeaderList;
            footerList := resultFooterList;

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

// 拠点名称の取込処理
function MAHNB01012B_GetSectionNm(section: WideString;
    var sectionName: WideString)
    : Integer; stdcall;

var
    status: Integer;
    resultSectionName: WideString;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;
    sectionName := '';

    try
        try
            // 結果データを初期化
            resultSectionName := '';

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_GetSectionNm(section, resultSectionName);
            // 結果コピー
            sectionName := resultSectionName;

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

// --- ADD 2010/07/16 ---------->>>>>
// 車両検索区分の取込処理
function MAHNB01012B_SetGetSearchCarDiv(flag: Integer;
    var refSearchCarDiv: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultSearchCarDiv: Boolean;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            resultSearchCarDiv := refSearchCarDiv;

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_SetGetSearchCarDiv(flag, refSearchCarDiv, resultSearchCarDiv);
            // 結果コピー
            refSearchCarDiv := resultSearchCarDiv;

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
// --- ADD 2010/07/16 ----------<<<<<
    // add by Lizc end

    // add by Yangmj start
// ツールチップ生成処理
function MAHNB01012B_CreateStockCountInfoString(salesRowNo: Integer;
    var StockCountInfo: WideString)
    : Integer; stdcall;

var
    status: Integer;
    resultStockCountInfo: WideString;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;
    StockCountInfo := '';

    try
        try
            // 結果データを初期化
            resultStockCountInfo := '';

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_CreateStockCountInfoString(salesRowNo, resultStockCountInfo);
            // 結果コピー
            StockCountInfo := resultStockCountInfo;

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
    // add by Yangmj end

    // add by Tanhong start

    // add by Tanhong end

// --- ADD m.suzuki 2010/06/12 ---------->>>>>
//**************************************************
// メール初期表示データ作成処理
//**************************************************
procedure MAHNB01012B_MakeMailDefaultData( var fileName: WideString ); stdcall;
var
    resultFileName: WideString;
begin
    try
        try
            // 結果データを初期化
            resultFileName := '';

            // 検索メソッド呼出し
            gpxSalesSlipInputAcs_MakeMailDefaultData( resultFileName );
            // 結果コピー
            fileName := resultFileName;

            // 結果を設定
        // 例外処理
        except
            on ex: Exception do
            begin
                // 例外発生時はエラーメッセージを戻す
            end;
        end;
    finally
        // ラッパークラス側から渡されたメモリを解放

    end;
end;
// --- ADD m.suzuki 2010/06/12 ----------<<<<<

//2010/06/15 yamaji ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//******************************************************************************
// RC連動-CSV出力
//******************************************************************************
function MAHNB01012B_CopyToRC(salesRowNo: Integer) : Integer; stdcall;
var
  status: Integer;
begin
  // 戻りステータス初期化
  try
    try
      // 検索メソッド呼出し
      status := gpxSalesSlipInputAcs_CopyToRC(salesRowNo);

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

//2010/06/15 yamaji ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

// ADD 2012/02/09 李占川 Redmine#28289 --- >>>>>
//**************************************************
// 印刷中フラグの取込処理
//**************************************************
function MAHNB01012B_GetPrintThreadOverFlag(var printThreadOverFlag: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultPrintThreadOverFlag: Boolean;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            resultPrintThreadOverFlag := printThreadOverFlag;

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_GetPrintThreadOverFlag(resultPrintThreadOverFlag);
            // 結果コピー
            printThreadOverFlag := resultPrintThreadOverFlag;

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
// ADD 2012/02/09 李占川 Redmine#28289 --- <<<<

// --- ADD 2013/03/21 ---------->>>>>
// ハンドル位置チェック処理
function MAHNB01012B_CheckHandlePosition(carRelationGuid: WideString;
    vinCode: WideString)
    : Boolean; stdcall;

var
    status: Boolean;

    I: Integer;
begin
    // 戻りステータス初期化
    // デフォルトでTRUEを返す
    Result := True;

    try
        try
            // 結果データを初期化

            // 検索メソッド呼出し
            status := gpxSalesSlipInputAcs_CheckHandlePosition(carRelationGuid, vinCode);
            // 結果コピー

            // 結果を設定
            Result := status;
            // 例外処理
        except
            on ex: Exception do
            begin
                // 例外発生時はエラーメッセージを戻す
                Result := True;
            end;
        end;
    finally
        // ラッパークラス側から渡されたメモリを解放

    end;
end;
// --- ADD 2013/03/21 ----------<<<<<

end.

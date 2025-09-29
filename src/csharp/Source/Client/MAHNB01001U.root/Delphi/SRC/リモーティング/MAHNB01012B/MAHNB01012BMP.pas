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
// 管理番号  10707327-00 作成担当 : 李占川
// 作 成 日  2012/02/09  修正内容 : アプリケーション終了処理前に、印刷中フラグの判断を追加する
//----------------------------------------------------------------------------//
// 管理番号  10900269-00 作成担当 : FSI今野 利裕
// 作 成 日  2013/03/21  修正内容 : SPK車台番号文字列対応
//----------------------------------------------------------------------------//
// 管理番号  11070071-00 作成担当 : 宮本　利明
// 作 成 日  2014/05/19  修正内容 : 仕掛一覧№2218 車輌備考欄にコード入力項目を追加
//----------------------------------------------------------------------------//

unit MAHNB01012BMP;

interface

uses
    ShareMem, SysUtils, Classes, HDllCall,DBClient,  HFSLLIB, MAHNB01012C, Forms;

type
    TDataModule1 = class(TDataModule)
        HDllCall1: THDllCall;
        private
            { Private 宣言 }
        public
            { Public 宣言 }
    end;

    /////////////////// 仲介クラスからのインポート関数型宣言 /////////////////

    // 車両検索処理メソッド型
    TxSalesSlipInputAcs_CarSearch = function(condition: TCarSearchCondition;
    salesRowNo: Integer;
    conditionType: Integer): Integer; stdcall;

    // 車両情報行オブジェクト取得メソッド型
    TxSalesSlipInputAcs_GetCarInfoRow = function(salesRowNo: Integer;
    getCarInfoMode: Integer;
    var resultCarInfo: TCarInfo): Integer; stdcall;

    // オプション情報処理メソッド型
    TxSalesSlipInputAcs_GetSettingOptionInfo = function(var optCarMng: Integer;
    var optStockingPayment: Integer): Integer; stdcall;

    // カラー情報取得処理メソッド型
    TxSalesSlipInputAcs_GetColorInfo = function(carRelationGuid: WideString;
    var resultColorInfoList: TSalesSlipInputCustomArrayB2): Integer; stdcall;

    // 選択カラー情報取得処理メソッド型
    TxSalesSlipInputAcs_GetSelectColorInfo = function(carRelationGuid: WideString;
    var resultColorInfo: TColorInfo): Integer; stdcall;

    // トリム情報取得処理メソッド型
    TxSalesSlipInputAcs_GetTrimInfo = function(carRelationGuid: WideString;
    var resultTrimInfoList: TSalesSlipInputCustomArrayB3): Integer; stdcall;
    
    // 選択トリム情報取得処理メソッド型
    TxSalesSlipInputAcs_GetSelectTrimInfo = function(carRelationGuid: WideString;
    var resultTrimInfo: TTrimInfo): Integer; stdcall;

    // 装備情報取得処理メソッド型
    TxSalesSlipInputAcs_GetEquipInfo = function(carRelationGuid: WideString;
    var resultCEqpDefDspInfoList: TSalesSlipInputCustomArrayB4): Integer; stdcall;

    // カラー情報選択処理メソッド型
    TxSalesSlipInputAcs_SelectColorInfo = function(carRelationGuid: WideString;
    colorCode: WideString): Integer; stdcall;

    // トリム情報選択処理メソッド型
    TxSalesSlipInputAcs_SelectTrimInfo = function(carRelationGuid: WideString;
    trimCode: WideString): Integer; stdcall;

    // 生産年式範囲チェックメソッド型
    TxSalesSlipInputAcs_CheckProduceTypeOfYearRange = function(carRelationGuid: WideString;
    firstEntryDate: Integer): Integer; stdcall;

    // 車両検索データテーブル年式設定処理メソッド型
    TxSalesSlipInputAcs_SettingCarModelUIDataFromFirstEntryDate = function(carRelationGuid: WideString;
    firstEntryDate: WideString): Integer; stdcall;

    // 車台番号範囲チェックメソッド型
    TxSalesSlipInputAcs_CheckProduceFrameNo = function(carRelationGuid: WideString;
    inputFrameNo: WideString;
    searchFrameNo: Integer): Integer; stdcall;

    // 車両検索データテーブル車台番号設定処理メソッド型
    TxSalesSlipInputAcs_SettingCarModelUIDataFromProduceFrameNo = function(carRelationGuid: WideString;
    frameNo: WideString): Integer; stdcall;

    // 対象年式取得処理(車台番号より取得)メソッド型
    TxSalesSlipInputAcs_GetProduceTypeOfYear = function(carRelationGuid: WideString;
    frameNo: WideString): Integer; stdcall;

    // 車両情報テーブルのクリアメソッド型
    TxSalesSlipInputAcs_ClearCarInfoRow = function(salesRowNo: Integer): Integer; stdcall;

    // 車両情報テーブル行の年式セットメソッド型
    TxSalesSlipInputAcs_SettingCarInfoRowFromFirstEntryDate = function(salesRowNo: Integer;
    firstEntryDate: Integer): Integer; stdcall;

    // 車両情報テーブル行の車台番号セットメソッド型
    TxSalesSlipInputAcs_SettingCarInfoRowFromFrameNo = function(salesRowNo: Integer;
    frameNo: WideString): Integer; stdcall;

    // 車両情報テーブル行の車種情報セットメソッド型
    TxSalesSlipInputAcs_SettingCarInfoRowFromModelInfo = function(salesRowNo: Integer;
    makerCode: Integer;
    makerFullName: WideString;
    makerHalfName: WideString;
    modelCode: Integer;
    modelSubCode: Integer;
    modelFullName: WideString;
    modelHalfName: WideString): Integer; stdcall;

    // 車種名称取得処理メソッド型
    TxSalesSlipInputAcs_GetModelFullName = function(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer): Integer; stdcall;

    // 車種半角名称取得処理メソッド型
    TxSalesSlipInputAcs_GetModelHalfName = function(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer): Integer; stdcall;

    // 車両情報テーブル行の管理番号セットメソッド型
    TxSalesSlipInputAcs_SettingCarInfoRowFromCarMngCode = function(salesRowNo: Integer;
    carMngCode: WideString): Integer; stdcall;

    // 車両情報テーブル行の型式指定番号および類別区分番号セットメソッド型
    TxSalesSlipInputAcs_SettingCarInfoRowFromCategoryNoAndDesignationNo = function(salesRowNo: Integer;
    modelDesignationNo: Integer;
    categoryNo: Integer): Integer; stdcall;

    // 車両情報テーブル行の型式セットメソッド型
    TxSalesSlipInputAcs_SettingCarInfoRowFromFullModel = function(salesRowNo: Integer;
    fullModel: WideString): Integer; stdcall;

    // 車両情報テーブル行のエンジン型式セットメソッド型
    TxSalesSlipInputAcs_SettingCarInfoRowFromEngineModelNm = function(salesRowNo: Integer;
    engineModelNm: WideString): Integer; stdcall;

    // 車両情報存在チェックメソッド型
    TxSalesSlipInputAcs_ExistCarInfo = function(): Integer; stdcall;

    // --- ADD 2014/05/19 T.Miyamoto 仕掛一覧№2218 ------------------------------>>>>>
    // 車両情報テーブル行の車輌備考コードセットメソッド型
    TxSalesSlipInputAcs_SettingCarInfoRowFromCarNoteCode = function(salesRowNo: Integer;
    carNoteCode: Integer): Integer; stdcall;
    // --- ADD 2014/05/19 T.Miyamoto 仕掛一覧№2218 ------------------------------<<<<<

    // 車両情報テーブル行の車輌備考セットメソッド型
    TxSalesSlipInputAcs_SettingCarInfoRowFromCarNote = function(salesRowNo: Integer;
    carNote: WideString): Integer; stdcall;

    // 車両情報テーブル行の車輌走行距離セットメソッド型
    TxSalesSlipInputAcs_SettingCarInfoRowFromMileage = function(salesRowNo: Integer;
    mileage: Integer): Integer; stdcall;

    // add by gaofeng start
    // 拠点ガイド処理メソッド型
    TxSalesSlipInputAcs_sectionGuide = function(enterpriseCode: WideString;
    formName: WideString;
    var resultSalesSlip: TSalesSlip): Integer; stdcall;

    // 解放メソッド型
    TxSalesSlipInputAcs_FreeSalesSlip = function(resultList: PSalesSlip;
        resultCount: Integer): Integer; stdcall;

    // 部門ガイド処理メソッド型
    TxSalesSlipInputAcs_subSectionGuide = function(enterpriseCode: WideString;
    var resultSalesSlip: TSalesSlip): Integer; stdcall;

    // 従業員ガイド処理メソッド型
    TxSalesSlipInputAcs_employeeGuide = function(sender: WideString;
    enterpriseCode: WideString;
    salesInputNm: WideString;
    salesInputCode: WideString;
    var salesSlip: TSalesSlip;
    var isReInputErr: Boolean)
    : Integer; stdcall;


    // 管理番号ガイド処理メソッド型
    TxSalesSlipInputAcs_carMngNoGuide = function(customerCode: Integer;
    enterpriseCode: WideString;
    var resultSelectedInfo: TCarMangInputExtraInfo;
    var resultStatus: Integer;
    salesRowNo: Integer;
    carMngCode: string): Integer; stdcall;

    // 解放メソッド型
    TxSalesSlipInputAcs_FreeCarMangInputExtraInfo = function(resultList: PCarMangInputExtraInfo;
        resultCount: Integer): Integer; stdcall;

    // 車種ガイド処理メソッド型
    TxSalesSlipInputAcs_modelFullGuide = function(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer;
    enterpriseCode: WideString;
    salesRowNo: Integer;
    var resultModelNameU: TModelNameU): Integer; stdcall;

    // 解放メソッド型
    TxSalesSlipInputAcs_FreeModelNameU = function(resultList: PModelNameU;
        resultCount: Integer): Integer; stdcall;

    // 備考ガイドボボタン処理メソッド型
    TxSalesSlipInputAcs_slipNote = function(sender: WideString;
    enterpriseCode: WideString;
    var resultSalesSlip: TSalesSlip): Integer; stdcall;

    // 率算定処理メソッド型
    TxSalesSlipInputAcs_GetRate = function(numerator: Double;
    denominator: Double;
    var rate: Double): Integer; stdcall;

    // --- ADD 2010/05/31 ---------->>>>>
    // CalculationSalesPriceメソッド型
    TxSalesSlipInputAcs_CalculationSalesPrice = function(): Integer; stdcall;
    // --- ADD 2010/05/31 ----------<<<<<

    // add by gaofeng end

    // 解放メソッド型
    TxSalesSlipInputAcs_FreeColorInfo = function(resultList: PColorInfo;
        resultCount: Integer): Integer; stdcall;

    // 解放メソッド型
    TxSalesSlipInputAcs_FreeTrimInfo = function(resultList: PTrimInfo;
        resultCount: Integer): Integer; stdcall;

//    // 解放メソッド型
//    TxShowUAcs_FreeSalesSlipSearchResult = function(resultList: PSalesSlipSearchResult;
//        resultCount: Integer): Integer; stdcall;

    TxSalesSlipInputAcs_FreeCEqpDefDspInfo = function(resultList: PCEqpDefDspInfo;
        resultCount: Integer): Integer; stdcall;

    // 解放メソッド型
    TxSalesSlipInputAcs_FreeCarSpecInfo = function(resultList: PCarSpecInfo;
        resultCount: Integer): Integer; stdcall;

    // 解放メソッド型
    TxSalesSlipInputAcs_FreeCarInfo = function(resultList: PCarInfo;
        resultCount: Integer): Integer; stdcall;

    // 解放メソッド型
    TxSalesSlipInputAcs_FreeCarModel = function(resultList: PCarModel;
        resultCount: Integer): Integer; stdcall;

    // 解放メソッド型
    TxSalesSlipInputAcs_FreeEngineModel = function(resultList: PEngineModel;
        resultCount: Integer): Integer; stdcall;

    // 解放メソッド型
    TxSalesSlipInputAcs_FreeCarSearchCondition = function(resultList: PCarSearchCondition;
        resultCount: Integer): Integer; stdcall;
        
    // 解放メソッド型
    TxSalesSlipInputAcs_FreeCustomArrayB4 = function(resultList: PSalesSlipInputCustomArrayB4;
        resultCount: Integer): Integer; stdcall;

    // 解放メソッド型
    TxSalesSlipInputAcs_FreeCustomArrayB3 = function(resultList: PSalesSlipInputCustomArrayB3;
        resultCount: Integer): Integer; stdcall;

    // 解放メソッド型
    TxSalesSlipInputAcs_FreeCustomArrayB2 = function(resultList: PSalesSlipInputCustomArrayB2;
        resultCount: Integer): Integer; stdcall;

    //文字列解放メソッド型
     TxShowUAcs_FreeMessage = function(msg : WideString):Integer; stdcall;

    TxSalesSlipInputAcs_FreeMessage = function(msg : WideString):Integer; stdcall;
    
    // add by gaofeng start
	// add by gaofeng end

    // add by Zhangkai start

    // 解放メソッド型
    TxSalesSlipInputAcs_FreeSalesDetail = function(resultList: PSalesDetail;
        resultCount: Integer): Integer; stdcall;

    // 解放メソッド型
    TxSalesSlipInputAcs_FreeCustomArrayA2 = function(resultList: PSalesSlipInputCustomArrayA2;
        resultCount: Integer): Integer; stdcall;

    // add by Zhangkai end

    // add by Lizc start
    // カーメーカーコードのフォーカス処理メソッド型
    TxSalesSlipInputAcs_AfterMakerCodeFocus = function(makerCode: Integer;
    salesRowNo: Integer;
    var makerName: WideString): Integer; stdcall;

    // 車種コードのフォーカス処理メソッド型
    TxSalesSlipInputAcs_AfterModelCodeFocus = function(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer;
    salesRowNo: Integer;
    var modelFullName: WideString): Integer; stdcall;

    // 車種呼称コードのフォーカス処理メソッド型
    TxSalesSlipInputAcs_AfterModelSubCodeFocus = function(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer;
    salesRowNo: Integer;
    var modelFullName: WideString): Integer; stdcall;

    // 車種名称のフォーカス処理メソッド型
    TxSalesSlipInputAcs_AfterModelFullNameFocus = function(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer;
    modelFullName: WideString;
    salesRowNo: Integer): Integer; stdcall;

    // 年式のフォーカス処理メソッド型
    TxSalesSlipInputAcs_AfterFirstEntryDateFocus = function(firstEntryDate: Integer;
    salesRowNo: Integer;
    var resultBoolRet: Boolean): Integer; stdcall;
    
    // 車台番号のフォーカス処理メソッド型
    TxSalesSlipInputAcs_AfterProduceFrameNoFocus = function(produceFrameNo: WideString;
    salesRowNo: Integer;
    var resultBoolRet: Boolean;
    mode : Integer): Integer; stdcall;
    
    // 追加情報タブ項目Visible設定メソッド型
    TxSalesSlipInputAcs_SettingAddInfoVisible = function(customerCode: Integer;
    carMngCode: WideString;
    salesRowNo: Integer;
    var resultBoolRet: Boolean): Integer; stdcall;
    
    // 車種変更ボタンVisibleメソッド型
    TxSalesSlipInputAcs_GetChangeCarInfoVisible = function(customerCode: Integer;
    carMngCode: WideString;
    var visibleFlag: Integer): Integer; stdcall;
    
    // 管理番号のフォーカス処理メソッド型
    TxSalesSlipInputAcs_AfterCarMngCodeFocus = function(carMngCode: WideString;
    customerCode: Integer;
    enterpriseCode: WideString;
    salesRowNo: Integer;
    var resultSelectedInfo: TCarMangInputExtraInfo;
    var resultReturnFlag: Boolean;
    var clearCarInfoFlag: Boolean): Integer; stdcall;
    
    // 拠点コードのフォーカス処理メソッド型
    TxSalesSlipInputAcs_AfterSectionCodeFocus = function(sectionCode: WideString;
    salesSlip: TSalesSlip;
    var refSalesSlip: TSalesSlip): Integer; stdcall;
    
    // 部門名称取得処理メソッド型
    TxSalesSlipInputAcs_GetNameFromSubSection = function(subSectionCode: Integer;
    var subSectionNm: WideString): Integer; stdcall;
    
    // 担当者変更処理メソッド型
    TxSalesSlipInputAcs_ChangeSalesEmployee = function(salesSlip: TSalesSlip;
    var refSalesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    code: WideString;
    canChangeFocus: Boolean;
    var refCanChangeFocus: Boolean): Integer; stdcall;

    // 受注者変更処理メソッド型
    TxSalesSlipInputAcs_ChangeFrontEmployee = function(salesSlip: TSalesSlip;
    var refSalesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    code: WideString;
    canChangeFocus: Boolean;
    var refCanChangeFocus: Boolean): Integer; stdcall;

    // 発行者変更処理メソッド型
    TxSalesSlipInputAcs_ChangeSalesInput = function(salesSlip: TSalesSlip;
    var refSalesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    code: WideString;
    canChangeFocus: Boolean;
    var refCanChangeFocus: Boolean): Integer; stdcall;
    
    // 伝票区分変更処理メソッド型
    TxSalesSlipInputAcs_ChangeSalesSlip = function(salesSlip: TSalesSlip;
    var refSalesSlip: TSalesSlip;
    isCache: Boolean;
    code: Integer;
    changeSalesSlipDisplay: Boolean;
    var refChangeSalesSlipDisplay: Boolean;
    var resultClearDetailInput: Boolean;
    var resultClearCarInfo: Boolean): Integer; stdcall;

    // 商品区分変更処理メソッド型
    TxSalesSlipInputAcs_ChangeSalesGoodsCd = function(salesSlipCurrent: TSalesSlip;
    code: Integer;
    changeSalesGoodsCd: Boolean;
    var refChangeSalesGoodsCd: Boolean;
    var resultClearDetailInput: Boolean;
    var resultClearCarInfo: Boolean): Integer; stdcall;
    
    // 得意先コードのフォーカス処理メソッド型
    TxSalesSlipInputAcs_AfterCustomerCodeFocus = function(salesSlip: TSalesSlip;
    var refSalesSlip: TSalesSlip;
    code: Integer;
    customerInfo: TCustomerInfo;
    var refCustomerInfo: TCustomerInfo;
    var resultClearAddCarInfo: Boolean;
    canChangeFocus: Boolean;
    var refCanChangeFocus: Boolean;
    reCalcSalesPrice: Boolean;
    var refReCalcSalesPrice: Boolean;
    guideStart: Boolean;
    var refGuideStart: Boolean;
    var resultClearDetailInput: Boolean;
    var resultClearCarInfo: Boolean;
    reCalcSalesUnitPrice: Boolean;
    var refReCalcSalesUnitPrice: Boolean;
    clearRateInfo: Boolean;
    var refClearRateInfo: Boolean): Integer; stdcall;
    
    // 伝票番号のフォーカス処理メソッド型
    TxSalesSlipInputAcs_AfterSalesSlipNumFocus = function(salesSlip: TSalesSlip;
    var refSalesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    var refSalesSlipCurrent: TSalesSlip;
    code: WideString;
    enterpriseCode: WideString;
    var resultEquelFlag: Boolean;
    var readDBDatStatus: Integer;
    reCalcSalesPrice: Boolean;
    var refReCalcSalesPrice: Boolean;
    var resultDeleteEmptyRow: Boolean;
    var resultFindDataFlg: Boolean    // ADD 2010/07/01
    ): Integer; stdcall;

    // 受注ステータスリスト作成メソッド型
    TxSalesSlipInputAcs_SetStateList = function(): Integer; stdcall;
    
    // 売上日のフォーカス処理メソッド型
    TxSalesSlipInputAcs_AfterSalesDateFocus = function(salesSlip: TSalesSlip;
    var refSalesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    salesDate: Int64;
    salesDateText: WideString;
    reCalcSalesUnitPrice: Boolean;
    var refReCalcSalesUnitPrice: Boolean;
    reCalcSalesPrice: Boolean;
    var refReCalcSalesPrice: Boolean;
    //var refTaxRate: Double): Integer; stdcall;// DEL K2011/08/12
    // ----- ADD K2011/08/12 --------->>>>>
    var refTaxRate: Double;
    var refReCanChangeFocus: Boolean): Integer; stdcall;
    // ----- ADD K2011/08/12 ---------<<<<<

    // 納入先コードのフォーカス処理メソッド型
    TxSalesSlipInputAcs_AfterAddresseeCodeFocue = function(salesSlip: TSalesSlip;
    var refSalesSlip: TSalesSlip;
    code: Integer;
    enterpriseCode: WideString;
    reCalcSalesPrice: Boolean;
    var refReCalcSalesPrice: Boolean): Integer; stdcall;
    
    // 売上データオブジェクトをインスタンス変数にキャッシュします。メソッド型
    TxSalesSlipInputAcs_CacheForChange = function(salesSlip: TSalesSlip): Integer; stdcall;
    
    // メモリ上の内容と比較メソッド型
    TxSalesSlipInputAcs_CompareSalesSlip = function(salesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    var resultCompareRes: Boolean): Integer; stdcall;
    
    // 売上単価再計算メソッド型
    TxSalesSlipInputAcs_ReCalcSalesUnitPrice = function(salesSlip: TSalesSlip;
    var refSalesSlip: TSalesSlip): Integer; stdcall;

    // 掛率情報クリア処理（全て）メソッド型
    TxSalesSlipInputAcs_ClearAllRateInfo = function(): Integer; stdcall;


    // 備考１コードのフォーカス処理メソッド型
    TxSalesSlipInputAcs_AfterSlipNoteCodeFocus = function(salesSlip: TSalesSlip;
    var refSalesSlip: TSalesSlip;
    value: Integer): Integer; stdcall;

    // 備考２コードのフォーカス処理メソッド型
    TxSalesSlipInputAcs_AfterSlipNote2CodeFocus = function(salesSlip: TSalesSlip;
    var refSalesSlip: TSalesSlip;
    //value: Integer): Integer; stdcall; // DEL K2011/08/12
    // ----- ADD K2011/08/12 --------->>>>>
    value: Integer;
    var refReCanChangeFocus: Boolean): Integer; stdcall;
    // ----- ADD K2011/08/12 ---------<<<<<

    // ----- ADD K2011/08/12 --------------------------->>>>>
    // 備考２のフォーカス処理メソッド型
    TxSalesSlipInputAcs_AfterSlipNote2Focus = function(salesSlip: TSalesSlip;
    slipNote2: WideString;
    var refReCanChangeFocus: Boolean): Integer; stdcall;
    // ----- ADD K2011/08/12 ---------------------------<<<<<

    // 備考３コードのフォーカス処理メソッド型
    TxSalesSlipInputAcs_AfterSlipNote3CodeFocus = function(salesSlip: TSalesSlip;
    var refSalesSlip: TSalesSlip;
    value: Integer): Integer; stdcall;
    
    // 売上データ処理メソッド型
    TxSalesSlipInputAcs_GetSalesSlip = function(var resultSalesSlip: TSalesSlip): Integer; stdcall;

   // 請求先確認ボタンクリックメソッド型
    TxSalesSlipInputAcs_CustomerClaimConfirmationClick = function(salesDate: Int64;
    var focus: WideString): Integer; stdcall;

    // 納入先確認ボタンクリックメソッド型
    TxSalesSlipInputAcs_AddresseeConfirmationClick = function(var resultSalesSlip: TSalesSlip): Integer; stdcall;
    
    // 売上明細データの存在チェックメソッド型
    TxSalesSlipInputAcs_ExistSalesDetail = function(var resultExist: Boolean): Integer; stdcall;

    // 売上形式変更可能チェック処理メソッド型
    TxSalesSlipInputAcs_ChangeCheckAcptAnOdrStatus = function(code: Integer;
    salesSlip: TSalesSlip;
    var resultClearDisplayCarInfo: Boolean;
    var resultClearAddUpInfo: Boolean;
    var resultResult: Boolean): Integer; stdcall;

    // 売上形式変更可能処理メソッド型
    TxSalesSlipInputAcs_ChangeAcptAnOdrStatus = function(code: Integer;
    salesSlip: TSalesSlip;
    var refSalesSlip: TSalesSlip;
    svCode: Integer): Integer; stdcall;

    // 売上データキャッシュ処理メソッド型
    TxSalesSlipInputAcs_Cache = function(salesSlip: TSalesSlip): Integer; stdcall;
    
    // 表示用伝票区分より、データ用の伝票区分、売掛区分をセットしますメソッド型
    TxSalesSlipInputAcs_SetSlipCdAndAccRecDivCdFromDisplay = function(salesSlip: TSalesSlip;
    var refSalesSlip: TSalesSlip): Integer; stdcall;
    
    // 装備情報選択処理メソッド型
    TxSalesSlipInputAcs_SelectEquipInfo = function(carRelationGuid: WideString;
    equipmentGenreCd: WideString;
    equipmentName: WideString): Integer; stdcall;
    
    // データ変更フラグの設定処理メソッド型
    TxSalesSlipInputAcs_SetGetIsDataChanged = function(flag: Integer;
    isDataChanged: Boolean;
    var refIsDataChanged: Boolean): Integer; stdcall;
    
    // ヘッダフォーカス設定リストの取込処理メソッド型
    TxSalesSlipInputAcs_GetHeaderFocusConstructionListValue = function(var resultHeaderFocusConstructionList: TSalesSlipInputCustomArrayB5;
    var resultFooterFocusConstructionList: TSalesSlipInputCustomArrayB6): Integer; stdcall;

    // フォーカス設定リストの取込処理メソッド型
    TxSalesSlipInputAcs_GetFocusConstructionValue = function(var headerList: WideString;
    var footerList: WideString): Integer; stdcall;

    // 解放メソッド型
    TxSalesSlipInputAcs_FreeHeaderFocusConstruction = function(resultList: PHeaderFocusConstruction;
        resultCount: Integer): Integer; stdcall;

    // 解放メソッド型
    TxSalesSlipInputAcs_FreeFooterFocusConstruction = function(resultList: PFooterFocusConstruction;
        resultCount: Integer): Integer; stdcall;

    // 解放メソッド型
    TxSalesSlipInputAcs_FreeCustomArrayB6 = function(resultList: PSalesSlipInputCustomArrayB6;
        resultCount: Integer): Integer; stdcall;

    // 解放メソッド型
    TxSalesSlipInputAcs_FreeCustomArrayB5 = function(resultList: PSalesSlipInputCustomArrayB5;
        resultCount: Integer): Integer; stdcall;

	// 拠点名称の取込処理メソッド型
    TxSalesSlipInputAcs_GetSectionNm = function(section: WideString;
    var sectionName: WideString): Integer; stdcall;
    
    // --- ADD 2010/07/16 ---------->>>>>
    // 車両検索区分の取込処理メソッド型
    TxSalesSlipInputAcs_SetGetSearchCarDiv = function(flag: Integer;
    searchCarDiv: Boolean;
    var refSearchCarDiv: Boolean): Integer; stdcall;
    // --- ADD 2010/07/16 ----------<<<<<
    // add by Lizc end

    // add by Yangmj start
    // ツールチップ生成処理メソッド型
    TxSalesSlipInputAcs_CreateStockCountInfoString = function(salesRowNo: Integer;
    var StockCountInfo: WideString): Integer; stdcall;
    // add by Yangmj end

    // add by Tanhong start

    // add by Tanhong end

    // --- ADD m.suzuki 2010/06/12 ---------->>>>>
    TxSalesSlipInputAcs_MakeMailDefaultData = procedure( var sFileName: WideString ); stdcall;
    // --- ADD m.suzuki 2010/06/12 ----------<<<<<

//2010/06/15 yamaji ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    TxSalesSlipInputAcs_CopyToRC = function(salesRowNo: Integer) : Integer; stdcall;
//2010/06/15 yamaji ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

    TxSalesSlipInputAcs_GetPrintThreadOverFlag = function(var printThreadOverFlag: Boolean) : Integer; stdcall;  //ADD 2012/02/09 李占川 Redmine#28289

    // --- ADD 2013/03/21 ---------->>>>>
    // ハンドル位置チェック処理メソッド型
    TxSalesSlipInputAcs_CheckHandlePosition = function(carRelationGuid: WideString;
    vinCode: WideString)
    : Boolean; stdcall;
    // --- ADD 2013/03/21 ----------<<<<<

    //アクセスクラス仲介DLLロードメソッド
    function LoadLibraryMAHNB01012M(HDllCall1: THDllCall): Integer;

    //アクセスクラス仲介DLLアンロードメソッド
    procedure FreeLibraryMAHNB01012M(HDllCall1: THDllCall);

var
//    // 車両検索処理関数呼出し用ポインタ変数
//    gpxShowUAcs_SalesSlipGuide: TxShowUAcs_SalesSlipGuide;
//    // メモリ解放処理呼び出し用ポインタ変数
//    gpxShowUAcs_FreeSalesSlipSearchResult: TxShowUAcs_FreeSalesSlipSearchResult;

    // オプション情報処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_GetSettingOptionInfo: TxSalesSlipInputAcs_GetSettingOptionInfo;
    gpxSalesSlipInputAcs_CarSearch: TxSalesSlipInputAcs_CarSearch;
    // 車両情報行オブジェクト取得関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_GetCarInfoRow: TxSalesSlipInputAcs_GetCarInfoRow;
    // カラー情報取得処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_GetColorInfo: TxSalesSlipInputAcs_GetColorInfo;
    // 選択カラー情報取得処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_GetSelectColorInfo: TxSalesSlipInputAcs_GetSelectColorInfo;
    // トリム情報取得処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_GetTrimInfo: TxSalesSlipInputAcs_GetTrimInfo;
    // 選択トリム情報取得処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_GetSelectTrimInfo: TxSalesSlipInputAcs_GetSelectTrimInfo;
    // 装備情報取得処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_GetEquipInfo: TxSalesSlipInputAcs_GetEquipInfo;
    // カラー情報選択処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_SelectColorInfo: TxSalesSlipInputAcs_SelectColorInfo;
    // トリム情報選択処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_SelectTrimInfo: TxSalesSlipInputAcs_SelectTrimInfo;
    // 生産年式範囲チェック関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_CheckProduceTypeOfYearRange: TxSalesSlipInputAcs_CheckProduceTypeOfYearRange;
    // 車両検索データテーブル年式設定処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_SettingCarModelUIDataFromFirstEntryDate: TxSalesSlipInputAcs_SettingCarModelUIDataFromFirstEntryDate;
    // 車台番号範囲チェック関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_CheckProduceFrameNo: TxSalesSlipInputAcs_CheckProduceFrameNo;
    // 車両検索データテーブル車台番号設定処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_SettingCarModelUIDataFromProduceFrameNo: TxSalesSlipInputAcs_SettingCarModelUIDataFromProduceFrameNo;
    // 対象年式取得処理(車台番号より取得)関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_GetProduceTypeOfYear: TxSalesSlipInputAcs_GetProduceTypeOfYear;
    // 車両情報テーブルのクリア関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_ClearCarInfoRow: TxSalesSlipInputAcs_ClearCarInfoRow;
    // 車両情報テーブル行の年式セット関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_SettingCarInfoRowFromFirstEntryDate: TxSalesSlipInputAcs_SettingCarInfoRowFromFirstEntryDate;
    // 車両情報テーブル行の車台番号セット関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_SettingCarInfoRowFromFrameNo: TxSalesSlipInputAcs_SettingCarInfoRowFromFrameNo;
    // 車両情報テーブル行の車種情報セット関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_SettingCarInfoRowFromModelInfo: TxSalesSlipInputAcs_SettingCarInfoRowFromModelInfo;
    // 車種名称取得処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_GetModelFullName: TxSalesSlipInputAcs_GetModelFullName;
    // 車種半角名称取得処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_GetModelHalfName: TxSalesSlipInputAcs_GetModelHalfName;
    // 車両情報テーブル行の管理番号セット関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_SettingCarInfoRowFromCarMngCode: TxSalesSlipInputAcs_SettingCarInfoRowFromCarMngCode;
    // 車両情報テーブル行の型式指定番号および類別区分番号セット関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_SettingCarInfoRowFromCategoryNoAndDesignationNo: TxSalesSlipInputAcs_SettingCarInfoRowFromCategoryNoAndDesignationNo;
    // 車両情報テーブル行の型式セット関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_SettingCarInfoRowFromFullModel: TxSalesSlipInputAcs_SettingCarInfoRowFromFullModel;
    // 車両情報テーブル行のエンジン型式セット関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_SettingCarInfoRowFromEngineModelNm: TxSalesSlipInputAcs_SettingCarInfoRowFromEngineModelNm;
    // 車両情報存在チェック関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_ExistCarInfo: TxSalesSlipInputAcs_ExistCarInfo;
    // --- ADD 2014/05/19 T.Miyamoto 仕掛一覧№2218 ------------------------------>>>>>
    // 車両情報テーブル行の車輌備考コードセット関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_SettingCarInfoRowFromCarNoteCode: TxSalesSlipInputAcs_SettingCarInfoRowFromCarNoteCode;
    // --- ADD 2014/05/19 T.Miyamoto 仕掛一覧№2218 ------------------------------<<<<<
    // 車両情報テーブル行の車輌備考セット関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_SettingCarInfoRowFromCarNote: TxSalesSlipInputAcs_SettingCarInfoRowFromCarNote;
    // 車両情報テーブル行の車輌走行距離セット関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_SettingCarInfoRowFromMileage: TxSalesSlipInputAcs_SettingCarInfoRowFromMileage;
    // メモリ解放処理呼び出し用ポインタ変数
    gpxSalesSlipInputAcs_FreeColorInfo: TxSalesSlipInputAcs_FreeColorInfo;
    // メモリ解放処理呼び出し用ポインタ変数
    gpxSalesSlipInputAcs_FreeTrimInfo: TxSalesSlipInputAcs_FreeTrimInfo;
    // メモリ解放処理呼び出し用ポインタ変数
    gpxSalesSlipInputAcs_FreeCEqpDefDspInfo: TxSalesSlipInputAcs_FreeCEqpDefDspInfo;
    // メモリ解放処理呼び出し用ポインタ変数
    gpxSalesSlipInputAcs_FreeCarSpecInfo: TxSalesSlipInputAcs_FreeCarSpecInfo;
    // メモリ解放処理呼び出し用ポインタ変数
    gpxSalesSlipInputAcs_FreeCarInfo: TxSalesSlipInputAcs_FreeCarInfo;
    // メモリ解放処理呼び出し用ポインタ変数
    gpxSalesSlipInputAcs_FreeCarModel: TxSalesSlipInputAcs_FreeCarModel;
    // メモリ解放処理呼び出し用ポインタ変数
    gpxSalesSlipInputAcs_FreeEngineModel: TxSalesSlipInputAcs_FreeEngineModel;
    // メモリ解放処理呼び出し用ポインタ変数
    gpxSalesSlipInputAcs_FreeCarSearchCondition: TxSalesSlipInputAcs_FreeCarSearchCondition;
    // メモリ解放処理呼び出し用ポインタ変数
    gpxSalesSlipInputAcs_FreeCustomArrayB4: TxSalesSlipInputAcs_FreeCustomArrayB4;
    // メモリ解放処理呼び出し用ポインタ変数
    gpxSalesSlipInputAcs_FreeCustomArrayB3: TxSalesSlipInputAcs_FreeCustomArrayB3;
    // メモリ解放処理呼び出し用ポインタ変数
    gpxSalesSlipInputAcs_FreeCustomArrayB2: TxSalesSlipInputAcs_FreeCustomArrayB2;
    //文字列解放処理呼び出し用ポインタ変数
    gpxShowUAcs_FreeMessage: TxShowUAcs_FreeMessage;
    gpxSalesSlipInputAcs_FreeMessage: TxSalesSlipInputAcs_FreeMessage;
    // メモリ解放処理呼び出し用ポインタ変数
    gpxSalesSlipInputAcs_FreeHeaderFocusConstruction: TxSalesSlipInputAcs_FreeHeaderFocusConstruction;
    // メモリ解放処理呼び出し用ポインタ変数
    gpxSalesSlipInputAcs_FreeFooterFocusConstruction: TxSalesSlipInputAcs_FreeFooterFocusConstruction;
    // メモリ解放処理呼び出し用ポインタ変数
    gpxSalesSlipInputAcs_FreeCustomArrayB6: TxSalesSlipInputAcs_FreeCustomArrayB6;
    // メモリ解放処理呼び出し用ポインタ変数
    gpxSalesSlipInputAcs_FreeCustomArrayB5: TxSalesSlipInputAcs_FreeCustomArrayB5;

    DataModule1: TDataModule1;
    
    // add by gaofeng start

    // 拠点ガイド処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_sectionGuide: TxSalesSlipInputAcs_sectionGuide;
    // メモリ解放処理呼び出し用ポインタ変数
    gpxSalesSlipInputAcs_FreeSalesSlip: TxSalesSlipInputAcs_FreeSalesSlip;
    // 部門ガイド処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_subSectionGuide: TxSalesSlipInputAcs_subSectionGuide;
    // 従業員ガイド処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_employeeGuide: TxSalesSlipInputAcs_employeeGuide;
    // 管理番号ガイド処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_carMngNoGuide: TxSalesSlipInputAcs_carMngNoGuide;
    // メモリ解放処理呼び出し用ポインタ変数
    gpxSalesSlipInputAcs_FreeCarMangInputExtraInfo: TxSalesSlipInputAcs_FreeCarMangInputExtraInfo;
    // 車種ガイド処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_modelFullGuide: TxSalesSlipInputAcs_modelFullGuide;
    // メモリ解放処理呼び出し用ポインタ変数
    gpxSalesSlipInputAcs_FreeModelNameU: TxSalesSlipInputAcs_FreeModelNameU;
    // 備考ガイドボボタン処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_slipNote: TxSalesSlipInputAcs_slipNote;
    gpxSalesSlipInputAcs_GetRate: TxSalesSlipInputAcs_GetRate;

    // --- ADD 2010/05/31 ---------->>>>>
    // CalculationSalesPrice関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_CalculationSalesPrice: TxSalesSlipInputAcs_CalculationSalesPrice;
    // --- ADD 2010/05/31 ----------<<<<<

    // add by gaofeng end

    // add by Zhangkai start

    // メモリ解放処理呼び出し用ポインタ変数
    gpxSalesSlipInputAcs_FreeSalesDetail: TxSalesSlipInputAcs_FreeSalesDetail;

    // メモリ解放処理呼び出し用ポインタ変数
    gpxSalesSlipInputAcs_FreeCustomArrayA2: TxSalesSlipInputAcs_FreeCustomArrayA2;

    // add by Zhangkai end

    // add by Lizc start
	// カーメーカーコードのフォーカス処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_AfterMakerCodeFocus: TxSalesSlipInputAcs_AfterMakerCodeFocus;
    // 車種コードのフォーカス処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_AfterModelCodeFocus: TxSalesSlipInputAcs_AfterModelCodeFocus;
    // 車種呼称コードのフォーカス処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_AfterModelSubCodeFocus: TxSalesSlipInputAcs_AfterModelSubCodeFocus;
    // 車種名称のフォーカス処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_AfterModelFullNameFocus: TxSalesSlipInputAcs_AfterModelFullNameFocus;
    // 年式のフォーカス処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_AfterFirstEntryDateFocus: TxSalesSlipInputAcs_AfterFirstEntryDateFocus;
    // 車台番号のフォーカス処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_AfterProduceFrameNoFocus: TxSalesSlipInputAcs_AfterProduceFrameNoFocus;
     // 追加情報タブ項目Visible設定関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_SettingAddInfoVisible: TxSalesSlipInputAcs_SettingAddInfoVisible;
    // 車種変更ボタンVisible関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_GetChangeCarInfoVisible: TxSalesSlipInputAcs_GetChangeCarInfoVisible;
    // 管理番号のフォーカス処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_AfterCarMngCodeFocus: TxSalesSlipInputAcs_AfterCarMngCodeFocus;
    // 拠点コードのフォーカス処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_AfterSectionCodeFocus: TxSalesSlipInputAcs_AfterSectionCodeFocus;
    // 部門名称取得処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_GetNameFromSubSection: TxSalesSlipInputAcs_GetNameFromSubSection;
    // 担当者変更処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_ChangeSalesEmployee: TxSalesSlipInputAcs_ChangeSalesEmployee;
    // 受注者変更処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_ChangeFrontEmployee: TxSalesSlipInputAcs_ChangeFrontEmployee;
    // 発行者変更処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_ChangeSalesInput: TxSalesSlipInputAcs_ChangeSalesInput;
    // 伝票区分変更処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_ChangeSalesSlip: TxSalesSlipInputAcs_ChangeSalesSlip;
    // 商品区分変更処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_ChangeSalesGoodsCd: TxSalesSlipInputAcs_ChangeSalesGoodsCd;
    // 得意先コードのフォーカス処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_AfterCustomerCodeFocus: TxSalesSlipInputAcs_AfterCustomerCodeFocus;
    // 伝票番号のフォーカス処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_AfterSalesSlipNumFocus: TxSalesSlipInputAcs_AfterSalesSlipNumFocus;
    // 受注ステータスリスト作成関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_SetStateList: TxSalesSlipInputAcs_SetStateList;
    // 売上日のフォーカス処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_AfterSalesDateFocus: TxSalesSlipInputAcs_AfterSalesDateFocus;
    // 納入先コードのフォーカス処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_AfterAddresseeCodeFocue: TxSalesSlipInputAcs_AfterAddresseeCodeFocue;
    // 売上データオブジェクトをインスタンス変数にキャッシュします。関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_CacheForChange: TxSalesSlipInputAcs_CacheForChange;
    // メモリ上の内容と比較関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_CompareSalesSlip: TxSalesSlipInputAcs_CompareSalesSlip;
    // 売上単価再計算関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_ReCalcSalesUnitPrice: TxSalesSlipInputAcs_ReCalcSalesUnitPrice;
    // 掛率情報クリア処理（全て）関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_ClearAllRateInfo: TxSalesSlipInputAcs_ClearAllRateInfo;
    // 備考１コードのフォーカス処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_AfterSlipNoteCodeFocus: TxSalesSlipInputAcs_AfterSlipNoteCodeFocus;
    // 備考２コードのフォーカス処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_AfterSlipNote2CodeFocus: TxSalesSlipInputAcs_AfterSlipNote2CodeFocus;
    // 備考２のフォーカス処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_AfterSlipNote2Focus: TxSalesSlipInputAcs_AfterSlipNote2Focus; // ADD K2011/08/12
    // 備考３コードのフォーカス処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_AfterSlipNote3CodeFocus: TxSalesSlipInputAcs_AfterSlipNote3CodeFocus;
    // 売上データ処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_GetSalesSlip: TxSalesSlipInputAcs_GetSalesSlip;
    // 請求先確認ボタンクリック関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_CustomerClaimConfirmationClick: TxSalesSlipInputAcs_CustomerClaimConfirmationClick;
    // 納入先確認ボタンクリック関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_AddresseeConfirmationClick: TxSalesSlipInputAcs_AddresseeConfirmationClick;
    // 売上明細データの存在チェック関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_ExistSalesDetail: TxSalesSlipInputAcs_ExistSalesDetail;
    // 売上形式変更可能チェック処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_ChangeCheckAcptAnOdrStatus: TxSalesSlipInputAcs_ChangeCheckAcptAnOdrStatus;
    // 売上形式変更可能処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_ChangeAcptAnOdrStatus: TxSalesSlipInputAcs_ChangeAcptAnOdrStatus;
    // 売上データキャッシュ処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_Cache: TxSalesSlipInputAcs_Cache;
    // 表示用伝票区分より、データ用の伝票区分、売掛区分をセットします関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_SetSlipCdAndAccRecDivCdFromDisplay: TxSalesSlipInputAcs_SetSlipCdAndAccRecDivCdFromDisplay;
    // 装備情報選択処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_SelectEquipInfo: TxSalesSlipInputAcs_SelectEquipInfo;
    // データ変更フラグの設定処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_SetGetIsDataChanged: TxSalesSlipInputAcs_SetGetIsDataChanged;
    // ヘッダフォーカス設定リストの取込処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_GetHeaderFocusConstructionListValue: TxSalesSlipInputAcs_GetHeaderFocusConstructionListValue;
    // フォーカス設定リストの取込処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_GetFocusConstructionValue: TxSalesSlipInputAcs_GetFocusConstructionValue;
    // 拠点名称の取込処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_GetSectionNm: TxSalesSlipInputAcs_GetSectionNm;
    // --- ADD 2010/07/16 ---------->>>>>
    // 車両検索区分の取込処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_SetGetSearchCarDiv: TxSalesSlipInputAcs_SetGetSearchCarDiv;
    // --- ADD 2010/07/16 ----------<<<<<
    // add by Lizc end

    // add by Yangmj start
    // ツールチップ生成処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_CreateStockCountInfoString: TxSalesSlipInputAcs_CreateStockCountInfoString;
    // add by Yangmj end

    // add by Tanhong start

    // add by Tanhong end

    // --- ADD m.suzuki 2010/06/12 ---------->>>>>
    gpxSalesSlipInputAcs_MakeMailDefaultData: TxSalesSlipInputAcs_MakeMailDefaultData;
    // --- ADD m.suzuki 2010/06/12 ----------<<<<<

    gpxSalesSlipInputAcs_CopyToRC: TxSalesSlipInputAcs_CopyToRC; //2010/06/15 yamaji ADD

    gpxSalesSlipInputAcs_GetPrintThreadOverFlag: TxSalesSlipInputAcs_GetPrintThreadOverFlag; //ADD 2012/02/09 李占川 Redmine#28289

    // --- ADD 2013/03/21 ---------->>>>>
    // ハンドル位置チェック処理関数呼出し用ポインタ変数
    gpxSalesSlipInputAcs_CheckHandlePosition: TxSalesSlipInputAcs_CheckHandlePosition;
    // --- ADD 2013/03/21 ----------<<<<<

implementation

{$R *.dfm}

// 車両検索アクセスクラス仲介DLLロード処理
function LoadLibraryMAHNB01012M(HDllCall1: THDllCall): Integer;
var
    nSt: Integer;
begin
    Result := 4;
    HDllCall1.DllName := 'MAHNB01012M.DLL';
    nSt := HDllCall1.HLoadLibrary;

    // DLLロード
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'LOADLIBRARY', '車両検索部品のロードに失敗しました',
            nSt, nil, 0);
        Exit;
    end;

//    // 売上伝票ガイド処理関数アドレス取得
//    HDllCall1.ProcName := 'ShowUAcs_SalesSlipGuide';
//    nSt := HDllCall1.HGetPAdr(@gpxShowUAcs_SalesSlipGuide);
//    if nSt <> 0 then
//    begin
//        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車種部品',
//            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
//            '車種部品売上伝票ガイド処理関数のアドレス取得に失敗しました', nSt, nil, 0);
//        Exit;
//    end;
    // 車両検索処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_CarSearch';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_CarSearch);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品車両検索処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // オプション情報処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetSettingOptionInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetSettingOptionInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車種部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車種部品オプション情報処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 車両情報行オブジェクト取得関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetCarInfoRow';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetCarInfoRow);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品車両情報行オブジェクト取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // カラー情報取得処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetColorInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetColorInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品カラー情報取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 選択カラー情報取得処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetSelectColorInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetSelectColorInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品選択カラー情報取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // トリム情報取得処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetTrimInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetTrimInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品トリム情報取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 選択トリム情報取得処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetSelectTrimInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetSelectTrimInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品選択トリム情報取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 装備情報取得処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetEquipInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetEquipInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品装備情報取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // カラー情報選択処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_SelectColorInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SelectColorInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品カラー情報選択処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // トリム情報選択処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_SelectTrimInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SelectTrimInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品トリム情報選択処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 生産年式範囲チェック関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_CheckProduceTypeOfYearRange';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_CheckProduceTypeOfYearRange);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品生産年式範囲チェック関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 車両検索データテーブル年式設定処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_SettingCarModelUIDataFromFirstEntryDate';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SettingCarModelUIDataFromFirstEntryDate);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品車両検索データテーブル年式設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 車台番号範囲チェック関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_CheckProduceFrameNo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_CheckProduceFrameNo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品車台番号範囲チェック関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 車両検索データテーブル車台番号設定処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_SettingCarModelUIDataFromProduceFrameNo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SettingCarModelUIDataFromProduceFrameNo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品車両検索データテーブル車台番号設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 対象年式取得処理(車台番号より取得)関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetProduceTypeOfYear';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetProduceTypeOfYear);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品対象年式取得処理(車台番号より取得)関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 車両情報テーブルのクリア関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_ClearCarInfoRow';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_ClearCarInfoRow);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品車両情報テーブルのクリア関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 車両情報テーブル行の年式セット関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_SettingCarInfoRowFromFirstEntryDate';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SettingCarInfoRowFromFirstEntryDate);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品車両情報テーブル行の年式セット関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 車両情報テーブル行の車台番号セット関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_SettingCarInfoRowFromFrameNo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SettingCarInfoRowFromFrameNo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品車両情報テーブル行の車台番号セット関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 車両情報テーブル行の車種情報セット関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_SettingCarInfoRowFromModelInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SettingCarInfoRowFromModelInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品車両情報テーブル行の車種情報セット関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 車種名称取得処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetModelFullName';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetModelFullName);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品車種名称取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 車種半角名称取得処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetModelHalfName';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetModelHalfName);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品車種半角名称取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 車両情報テーブル行の管理番号セット関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_SettingCarInfoRowFromCarMngCode';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SettingCarInfoRowFromCarMngCode);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品車両情報テーブル行の管理番号セット関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 車両情報テーブル行の型式指定番号および類別区分番号セット関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_SettingCarInfoRowFromCategoryNoAndDesignationNo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SettingCarInfoRowFromCategoryNoAndDesignationNo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品車両情報テーブル行の型式指定番号および類別区分番号セット関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 車両情報テーブル行の型式セット関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_SettingCarInfoRowFromFullModel';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SettingCarInfoRowFromFullModel);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品車両情報テーブル行の型式セット関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 車両情報テーブル行のエンジン型式セット関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_SettingCarInfoRowFromEngineModelNm';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SettingCarInfoRowFromEngineModelNm);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品車両情報テーブル行のエンジン型式セット関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 車両情報存在チェック関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_ExistCarInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_ExistCarInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品車両情報存在チェック関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // --- ADD 2014/05/19 T.Miyamoto 仕掛一覧№2218 ------------------------------>>>>>
    // 車両情報テーブル行の車輌備考コードセット関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_SettingCarInfoRowFromCarNoteCode';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SettingCarInfoRowFromCarNoteCode);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品車両情報テーブル行の車輌備考コードセット関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2014/05/19 T.Miyamoto 仕掛一覧№2218 ------------------------------<<<<<

    // 車両情報テーブル行の車輌備考セット関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_SettingCarInfoRowFromCarNote';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SettingCarInfoRowFromCarNote);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品車両情報テーブル行の車輌備考セット関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 車両情報テーブル行の車輌走行距離セット関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_SettingCarInfoRowFromMileage';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SettingCarInfoRowFromMileage);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品車両情報テーブル行の車輌走行距離セット関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // データ解放関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeColorInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeColorInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品メモリ解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // データ解放関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeTrimInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeTrimInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品メモリ解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // データ解放関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeCEqpDefDspInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeCEqpDefDspInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品メモリ解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

//    // データ解放関数アドレス取得
//    HDllCall1.ProcName := 'ShowUAcs_FreeSalesSlipSearchResult';
//    nSt := HDllCall1.HGetPAdr(@gpxShowUAcs_FreeSalesSlipSearchResult);
//    if nSt <> 0 then
//    begin
//        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車種部品',
//            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
//            '車種部品メモリ解放関数のアドレス取得に失敗しました', nSt, nil, 0);
//        Exit;
//    end;
    // データ解放関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeCarSpecInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeCarSpecInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品メモリ解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // データ解放関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeCarInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeCarInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品メモリ解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // データ解放関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeCarModel';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeCarModel);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品メモリ解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // データ解放関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeEngineModel';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeEngineModel);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品メモリ解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // データ解放関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeCarSearchCondition';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeCarSearchCondition);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品メモリ解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

//    //文字列解放関数アドレス取得
//    HDllCall1.ProcName := 'ShowUAcs_FreeMessage';
//    nSt := HDllCall1.HGetPAdr(@gpxShowUAcs_FreeMessage);
//    if nSt <> 0 then
//    begin
//        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車種部品',
//            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
//            '車種部品文字列解放関数のアドレス取得に失敗しました', nSt, nil, 0);
//        Exit;
//    end;

    //文字列解放関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeMessage';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeMessage);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品文字列解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // add by gaofeng start

    // 拠点ガイド処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_sectionGuide';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_sectionGuide);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '拠点ガイド操作部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '拠点ガイド操作部品拠点ガイド処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // データ解放関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeSalesSlip';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeSalesSlip);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '拠点ガイド操作部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '拠点ガイド操作部品メモリ解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 部門ガイド処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_subSectionGuide';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_subSectionGuide);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '部門ガイド操作部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '部門ガイド操作部品部門ガイド処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 従業員ガイド処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_employeeGuide';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_employeeGuide);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '従業員ガイド操作部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '従業員ガイド操作部品従業員ガイド処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 管理番号ガイド処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_carMngNoGuide';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_carMngNoGuide);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '管理番号ガイド操作部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '管理番号ガイド操作部品管理番号ガイド処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // データ解放関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeCarMangInputExtraInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeCarMangInputExtraInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '管理番号ガイド操作部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '管理番号ガイド操作部品メモリ解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 車種ガイド処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_modelFullGuide';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_modelFullGuide);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車種部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車種部品車種ガイド処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // データ解放関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeModelNameU';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeModelNameU);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車種部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車種部品メモリ解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 備考ガイドボボタン処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_slipNote';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_slipNote);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '備考ガイドボボタン操作部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '備考ガイドボボタン操作部品備考ガイドボボタン処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 率算定処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetRate';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetRate);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '率算定処理部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '率算定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // --- ADD 2010/05/31 ---------->>>>>
    // CalculationSalesPrice関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_CalculationSalesPrice';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_CalculationSalesPrice);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '売上金額計算処理',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '売上金額計算処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2010/05/31 ----------<<<<<

	// add by gaofeng end
	
    // add by Zhangkai start

    // データ解放関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeSalesDetail';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeSalesDetail);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '品番検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '品番検索部品メモリ解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;


    // データ解放関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeCustomArrayA2';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeCustomArrayA2);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '品番検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '品番検索部品メモリ解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // add by Zhangkai end

    // add by Lizc start
    // カーメーカーコードのフォーカス処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_AfterMakerCodeFocus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AfterMakerCodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品カーメーカーコードのフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 車種コードのフォーカス処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_AfterModelCodeFocus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AfterModelCodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品車種コードのフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 車種呼称コードのフォーカス処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_AfterModelSubCodeFocus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AfterModelSubCodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品車種呼称コードのフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 車種名称のフォーカス処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_AfterModelFullNameFocus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AfterModelFullNameFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品車種名称のフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 年式のフォーカス処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_AfterFirstEntryDateFocus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AfterFirstEntryDateFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品年式のフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    
    // 車台番号のフォーカス処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_AfterProduceFrameNoFocus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AfterProduceFrameNoFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品車台番号のフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    
    // 追加情報タブ項目Visible設定関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_SettingAddInfoVisible';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SettingAddInfoVisible);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品追加情報タブ項目Visible設定関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    
    // 車種変更ボタンVisible関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetChangeCarInfoVisible';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetChangeCarInfoVisible);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品車種変更ボタンVisible関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    
    // 管理番号のフォーカス処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_AfterCarMngCodeFocus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AfterCarMngCodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品管理番号のフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    
    // 拠点コードのフォーカス処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_AfterSectionCodeFocus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AfterSectionCodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品拠点コードのフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    
    // 部門名称取得処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetNameFromSubSection';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetNameFromSubSection);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品部門名称取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    
    // 担当者変更処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_ChangeSalesEmployee';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_ChangeSalesEmployee);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品担当者変更処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    
    // 受注者変更処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_ChangeFrontEmployee';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_ChangeFrontEmployee);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品受注者変更処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 発行者変更処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_ChangeSalesInput';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_ChangeSalesInput);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品発行者変更処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    
    // 伝票区分変更処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_ChangeSalesSlip';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_ChangeSalesSlip);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品伝票区分変更処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 商品区分変更処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_ChangeSalesGoodsCd';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_ChangeSalesGoodsCd);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品商品区分変更処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    
    // 得意先コードのフォーカス処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_AfterCustomerCodeFocus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AfterCustomerCodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品得意先コードのフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    
    // 伝票番号のフォーカス処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_AfterSalesSlipNumFocus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AfterSalesSlipNumFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品伝票番号のフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 受注ステータスリスト作成関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_SetStateList';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SetStateList);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品受注ステータスリスト作成関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    
    // 売上日のフォーカス処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_AfterSalesDateFocus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AfterSalesDateFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品売上日のフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 納入先コードのフォーカス処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_AfterAddresseeCodeFocue';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AfterAddresseeCodeFocue);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品納入先コードのフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    
    // 売上データオブジェクトをインスタンス変数にキャッシュします。関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_CacheForChange';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_CacheForChange);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品売上データオブジェクトをインスタンス変数にキャッシュします。関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    
    // メモリ上の内容と比較関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_CompareSalesSlip';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_CompareSalesSlip);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品メモリ上の内容と比較関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    
    // 掛率情報クリア処理（全て）関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_ClearAllRateInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_ClearAllRateInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品掛率情報クリア処理（全て）関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 備考１コードのフォーカス処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_AfterSlipNoteCodeFocus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AfterSlipNoteCodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品備考１コードのフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 備考２コードのフォーカス処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_AfterSlipNote2CodeFocus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AfterSlipNote2CodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品備考２コードのフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // ----- ADD K2011/08/12 --------------------------->>>>>
    // 備考２のフォーカス処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_AfterSlipNote2Focus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AfterSlipNote2Focus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品備考２のフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // ----- ADD K2011/08/12 ---------------------------<<<<<

    // 備考３コードのフォーカス処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_AfterSlipNote3CodeFocus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AfterSlipNote3CodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品備考３コードのフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    
    // 売上データ処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetSalesSlip';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetSalesSlip);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品売上データ処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    
    // 請求先確認ボタンクリック関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_CustomerClaimConfirmationClick';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_CustomerClaimConfirmationClick);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品請求先確認ボタンクリック関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 納入先確認ボタンクリック関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_AddresseeConfirmationClick';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_AddresseeConfirmationClick);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品納入先確認ボタンクリック関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    
    // 売上明細データの存在チェック関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_ExistSalesDetail';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_ExistSalesDetail);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品売上明細データの存在チェック関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 売上形式変更可能チェック処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_ChangeCheckAcptAnOdrStatus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_ChangeCheckAcptAnOdrStatus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品売上形式変更可能チェック処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 売上形式変更可能処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_ChangeAcptAnOdrStatus';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_ChangeAcptAnOdrStatus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品売上形式変更可能処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 売上データキャッシュ処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_Cache';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_Cache);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品売上データキャッシュ処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    
    // 表示用伝票区分より、データ用の伝票区分、売掛区分をセットします関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_SetSlipCdAndAccRecDivCdFromDisplay';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SetSlipCdAndAccRecDivCdFromDisplay);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品表示用伝票区分より、データ用の伝票区分、売掛区分をセットします関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    
    // 装備情報選択処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_SelectEquipInfo';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SelectEquipInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品装備情報選択処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    
    // データ変更フラグの設定処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_SetGetIsDataChanged';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SetGetIsDataChanged);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品データ変更フラグの設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    
    // ヘッダフォーカス設定リストの取込処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetHeaderFocusConstructionListValue';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetHeaderFocusConstructionListValue);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品ヘッダフォーカス設定リストの取込処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // フォーカス設定リストの取込処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetFocusConstructionValue';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetFocusConstructionValue);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品フォーカス設定リストの取込処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    
    // データ解放関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeHeaderFocusConstruction';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeHeaderFocusConstruction);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品メモリ解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // データ解放関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeFooterFocusConstruction';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeFooterFocusConstruction);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品メモリ解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;


    // データ解放関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeCustomArrayB6';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeCustomArrayB6);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品メモリ解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // データ解放関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeCustomArrayB5';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeCustomArrayB5);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品メモリ解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    
    // データ解放関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeCustomArrayB4';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeCustomArrayB4);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品メモリ解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // データ解放関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeCustomArrayB3';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeCustomArrayB3);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品メモリ解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // データ解放関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_FreeCustomArrayB2';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_FreeCustomArrayB2);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品メモリ解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    
    // 拠点名称の取込処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetSectionNm';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetSectionNm);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品拠点名称の取込処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    
    // --- ADD 2010/07/16 ---------->>>>>
    // 車両検索区分の取込処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_SetGetSearchCarDiv';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_SetGetSearchCarDiv);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '車両検索部品車両検索区分の取込処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2010/07/16 ----------<<<<<
    // add by Lizc end

    // add by Yangmj start
    // ツールチップ生成処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_CreateStockCountInfoString';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_CreateStockCountInfoString);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '出荷照会部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '出荷照会部品ツールチップ生成処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // add by Yangmj end

    // --- ADD 2010/05/31 ---------->>>>>
    HDllCall1.ProcName := 'SalesSlipInputAcs_ReCalcSalesUnitPrice';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_ReCalcSalesUnitPrice);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '売上単価再計算',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '売上単価再計算処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2010/05/31 ----------<<<<<

    // add by Tanhong start

    // add by Tanhong end
    //2010/06/15 yamaji ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    //RC連携 - CSV出力
    HDllCALL1.ProcName := 'SalesSlipInputAcs_CopyToRC';
    nSt := HDllCALL1.HGetPAdr(@gpxSalesSlipInputAcs_CopyToRC);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', 'RC連携部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            'ＲＣ連携処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
//2010/06/15 yamaji ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

    // --- ADD m.suzuki 2010/06/12 ---------->>>>>
    // メール初期表示データ作成処理
    HDllCall1.ProcName := 'SalesSlipInputAcs_MakeMailDefaultData';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_MakeMailDefaultData);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '売上データ作成部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            'メール初期表示データ作成処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD m.suzuki 2010/06/12 ----------<<<<<

    // --- ADD 2012/02/09 李占川 Redmine#28289 ---------->>>>>
    // 印刷中フラグの取込処理
    HDllCall1.ProcName := 'SalesSlipInputAcs_GetPrintThreadOverFlag';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_GetPrintThreadOverFlag);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '印刷中フラグの取込処理',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '印刷中フラグの取込処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2012/02/09 李占川 Redmine#28289 ----------<<<<<

    // --- ADD 2013/03/21 ---------->>>>>
    // ハンドル位置チェック処理関数アドレス取得
    HDllCall1.ProcName := 'SalesSlipInputAcs_CheckHandlePosition';
    nSt := HDllCall1.HGetPAdr(@gpxSalesSlipInputAcs_CheckHandlePosition);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '車両検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            'ハンドル位置チェック処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2013/03/21 ----------<<<<<

    Result := 0;

end;

// アクセスクラス仲介DLL解放メソッド
procedure FreeLibraryMAHNB01012M(HDllCall1: THDllCall);
begin
    HDllCall1.DllName := 'MAHNB01012M.DLL';
    HDllCall1.HFreeLibrary;
//    gpxShowUAcs_SalesSlipGuide := nil;
//    gpxShowUAcs_FreeSalesSlipSearchResult := nil;
//    gpxShowUAcs_FreeMessage := nil;
    gpxSalesSlipInputAcs_CarSearch := nil;
    gpxSalesSlipInputAcs_GetSettingOptionInfo := nil;
    gpxSalesSlipInputAcs_GetCarInfoRow := nil;
    gpxSalesSlipInputAcs_GetColorInfo := nil;
    gpxSalesSlipInputAcs_GetSelectColorInfo := nil;
    gpxSalesSlipInputAcs_GetTrimInfo := nil;
    gpxSalesSlipInputAcs_GetSelectTrimInfo := nil;
    gpxSalesSlipInputAcs_GetEquipInfo := nil;
    gpxSalesSlipInputAcs_SelectColorInfo := nil;
    gpxSalesSlipInputAcs_SelectTrimInfo := nil;
    gpxSalesSlipInputAcs_CheckProduceTypeOfYearRange := nil;
    gpxSalesSlipInputAcs_SettingCarModelUIDataFromFirstEntryDate := nil;
    gpxSalesSlipInputAcs_CheckProduceFrameNo := nil;
    gpxSalesSlipInputAcs_SettingCarModelUIDataFromProduceFrameNo := nil;
    gpxSalesSlipInputAcs_GetProduceTypeOfYear := nil;
    gpxSalesSlipInputAcs_ClearCarInfoRow := nil;
    gpxSalesSlipInputAcs_SettingCarInfoRowFromFirstEntryDate := nil;
    gpxSalesSlipInputAcs_SettingCarInfoRowFromFrameNo := nil;
    gpxSalesSlipInputAcs_SettingCarInfoRowFromModelInfo := nil;
    gpxSalesSlipInputAcs_GetModelFullName := nil;
    gpxSalesSlipInputAcs_GetModelHalfName := nil;
    gpxSalesSlipInputAcs_SettingCarInfoRowFromCarMngCode := nil;
    gpxSalesSlipInputAcs_SettingCarInfoRowFromCategoryNoAndDesignationNo := nil;
    gpxSalesSlipInputAcs_SettingCarInfoRowFromFullModel := nil;
    gpxSalesSlipInputAcs_SettingCarInfoRowFromEngineModelNm := nil;
    gpxSalesSlipInputAcs_ExistCarInfo := nil;
    gpxSalesSlipInputAcs_SettingCarInfoRowFromCarNoteCode := nil; // ADD 2014/05/19 T.Miyamoto 仕掛一覧№2218
    gpxSalesSlipInputAcs_SettingCarInfoRowFromCarNote := nil;
    gpxSalesSlipInputAcs_SettingCarInfoRowFromMileage := nil;

    gpxSalesSlipInputAcs_FreeColorInfo := nil;
    gpxSalesSlipInputAcs_FreeTrimInfo := nil;
    gpxSalesSlipInputAcs_FreeCEqpDefDspInfo := nil;
    gpxSalesSlipInputAcs_FreeCarSpecInfo := nil;
    gpxSalesSlipInputAcs_FreeCarInfo := nil;
    gpxSalesSlipInputAcs_FreeCarModel := nil;
    gpxSalesSlipInputAcs_FreeEngineModel := nil;
    gpxSalesSlipInputAcs_FreeCarSearchCondition := nil;
    gpxSalesSlipInputAcs_FreeMessage := nil;
    gpxSalesSlipInputAcs_FreeHeaderFocusConstruction := nil;
    gpxSalesSlipInputAcs_FreeFooterFocusConstruction := nil;
    gpxSalesSlipInputAcs_FreeCustomArrayB6 := nil;
    gpxSalesSlipInputAcs_FreeCustomArrayB5 := nil;
    
    // add by gaofeng start
    gpxSalesSlipInputAcs_sectionGuide := nil;
    gpxSalesSlipInputAcs_FreeSalesSlip := nil;
    gpxSalesSlipInputAcs_subSectionGuide := nil;
    gpxSalesSlipInputAcs_employeeGuide := nil;
    gpxSalesSlipInputAcs_carMngNoGuide := nil;
    gpxSalesSlipInputAcs_FreeCarMangInputExtraInfo := nil;
    gpxSalesSlipInputAcs_modelFullGuide := nil;
    gpxSalesSlipInputAcs_FreeModelNameU := nil;
    gpxSalesSlipInputAcs_slipNote := nil;
    gpxSalesSlipInputAcs_GetRate := nil;

    // --- ADD 2010/05/31 ---------->>>>>
    gpxSalesSlipInputAcs_CalculationSalesPrice := nil;
    // --- ADD 2010/05/31 ----------<<<<<

    // add by gaofeng end
    
    // add by Zhangkai start
    gpxSalesSlipInputAcs_FreeSalesDetail := nil;
    gpxSalesSlipInputAcs_FreeCustomArrayA2 := nil;
    // add by Zhangkai end

    // add by Lizc start
	gpxSalesSlipInputAcs_AfterMakerCodeFocus := nil;
    gpxSalesSlipInputAcs_AfterModelCodeFocus := nil;
    gpxSalesSlipInputAcs_AfterModelSubCodeFocus := nil;
    gpxSalesSlipInputAcs_AfterModelFullNameFocus := nil;
    gpxSalesSlipInputAcs_AfterFirstEntryDateFocus := nil;
    gpxSalesSlipInputAcs_AfterProduceFrameNoFocus := nil;
    gpxSalesSlipInputAcs_SettingAddInfoVisible := nil;
    gpxSalesSlipInputAcs_GetChangeCarInfoVisible := nil;
    gpxSalesSlipInputAcs_AfterCarMngCodeFocus := nil;
    gpxSalesSlipInputAcs_AfterSectionCodeFocus := nil;
    gpxSalesSlipInputAcs_GetNameFromSubSection := nil;
    gpxSalesSlipInputAcs_ChangeSalesEmployee := nil;
    gpxSalesSlipInputAcs_ChangeFrontEmployee := nil;
    gpxSalesSlipInputAcs_ChangeSalesInput := nil;
    gpxSalesSlipInputAcs_ChangeSalesSlip := nil;
    gpxSalesSlipInputAcs_ChangeSalesGoodsCd := nil;
    gpxSalesSlipInputAcs_AfterCustomerCodeFocus := nil;
    gpxSalesSlipInputAcs_AfterSalesSlipNumFocus := nil;
    gpxSalesSlipInputAcs_SetStateList := nil;
    gpxSalesSlipInputAcs_AfterSalesDateFocus := nil;
    gpxSalesSlipInputAcs_AfterAddresseeCodeFocue := nil;
    gpxSalesSlipInputAcs_CacheForChange := nil;
    gpxSalesSlipInputAcs_CompareSalesSlip := nil;
    gpxSalesSlipInputAcs_ReCalcSalesUnitPrice := nil;
    gpxSalesSlipInputAcs_ClearAllRateInfo := nil;
    gpxSalesSlipInputAcs_AfterSlipNoteCodeFocus := nil;
    gpxSalesSlipInputAcs_AfterSlipNote2CodeFocus := nil;
    gpxSalesSlipInputAcs_AfterSlipNote2Focus := nil; // ADD K2011/08/12
    gpxSalesSlipInputAcs_AfterSlipNote3CodeFocus := nil;
    gpxSalesSlipInputAcs_GetSalesSlip := nil;
    gpxSalesSlipInputAcs_CustomerClaimConfirmationClick := nil;
    gpxSalesSlipInputAcs_AddresseeConfirmationClick := nil;
    gpxSalesSlipInputAcs_ExistSalesDetail := nil;
    gpxSalesSlipInputAcs_ChangeCheckAcptAnOdrStatus := nil;
    gpxSalesSlipInputAcs_ChangeAcptAnOdrStatus := nil;
    gpxSalesSlipInputAcs_Cache := nil;
    gpxSalesSlipInputAcs_SetSlipCdAndAccRecDivCdFromDisplay := nil;
    gpxSalesSlipInputAcs_SelectEquipInfo := nil;
    gpxSalesSlipInputAcs_SetGetIsDataChanged := nil;
    gpxSalesSlipInputAcs_GetHeaderFocusConstructionListValue := nil;
    gpxSalesSlipInputAcs_GetSectionNm := nil;
    gpxSalesSlipInputAcs_SetGetSearchCarDiv := nil; //ADD 2010/07/16
    // add by Lizc end

    // add by Yangmj start
    gpxSalesSlipInputAcs_CreateStockCountInfoString := nil;
    // add by Yangmj end

    // add by Tanhong start

    // add by Tanhong end

    // --- ADD m.suzuki 2010/06/12 ---------->>>>>
    gpxSalesSlipInputAcs_MakeMailDefaultData := nil;
    // --- ADD m.suzuki 2010/06/12 ----------<<<<<

//2010/06/15 yamaji ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    gpxSalesSlipInputAcs_CopyToRC := nil;
//2010/06/15 yamaji ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

    // --- ADD 2013/03/21 ---------->>>>>
    gpxSalesSlipInputAcs_CheckHandlePosition := nil;
    // --- ADD 2013/03/21 ----------<<<<<
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
        LoadLibraryMAHNB01012M(DataModule1.HDllCall1);
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
    FreeLibraryMAHNB01012M(DataModule1.HDllCall1);

    DataModule1.Free;
    DataModule1 := nil;
  end;

end.

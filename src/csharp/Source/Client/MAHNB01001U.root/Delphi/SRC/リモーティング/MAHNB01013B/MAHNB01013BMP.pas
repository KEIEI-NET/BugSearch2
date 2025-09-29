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
// 管理番号              作成担当 : 22018 鈴木 正臣
// 作 成 日  2010/06/16  修正内容 : オフライン対応の組込
//----------------------------------------------------------------------------//
// 管理番号  10601193-00 作成担当 : LDNS
// 作 成 日  2010/05/29  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10601193-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2010/05/30  修正内容 : 成果物統合
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20056 對馬 大輔
// 作 成 日  2010/08/30  修正内容 : 税率設定範囲チェック追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2011/01/31  修正内容 : パラメータ設定処理のパラメータ変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2011/02/12  修正内容 : 伝票内容が差し替わる件の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 曹文傑
// 作 成 日  2011/04/13  修正内容 : 明細複数選択行を削除可能とする
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 曹文傑
// 作 成 日  2011/05/30  修正内容 : 画面の拠点コード変化時（キャンペーン情報取得用）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 曹文傑 連番1028,Redmine#22936
// 作 成 日  2011/07/18  修正内容 : MANTIS[17500]仕入数=1と表示され仕入前の現在個数を表示、行移動後に現在個数が再表示される
//----------------------------------------------------------------------------//
// 管理番号  10703874-00 作成担当 : yangyi
// 作 成 日  K2011/08/12 修正内容 : イスコ個別対応
//----------------------------------------------------------------------------//
// 管理番号  10704766-00 作成担当 : 許雁波
// 作 成 日  2011/08/18  修正内容 : 連番729 明細貼付ファンクションボタンを追加
//----------------------------------------------------------------------------//
// 管理番号  10703874-00 作成担当 : yangyi
// 作 成 日  K2011/09/01  修正内容 : Redmine#24294の対応
//----------------------------------------------------------------------------//
// 管理番号10704766-00   作成担当 : 李占川
// 作 成 日  2011/11/18  修正内容 :redmine#26532
//			                           BLﾊﾟｰﾂｵｰﾀﾞｰｼｽﾃﾑの在庫確認で作成された見積伝票を修正呼出しした場合、
//                                 メッセージを表示し、参照モードで画面に表示するの仕様変更
//----------------------------------------------------------------------------//
// 管理番号10704766-00   作成担当 : 劉思遠
// 作 成 日  2011/11/22  修正内容 : Redmine#8037
//			                            BLﾊﾟｰﾂｵｰﾀﾞｰ　在庫確認→発注時のデータセットの仕様変更
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 福田 康夫
// 作 成 日  2012/05/31  修正内容 : 障害No.282
//                                  発注選択の時に「ESC」キーを押下することで発注扱いを解除する
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 譚洪
// 作 成 日  2012/10/15  修正内容 : Redmine#31582
//                                  仕入日のエラーメッセージを表示処理
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : 鄧潘ハン
// 作 成 日  2013/01/24  修正内容 : Redmine#34141
//                                  一括値引功能を追加
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30744 湯上 千加子
// 作 成 日  2013/02/17  修正内容 : SCM障害No.192対応
//----------------------------------------------------------------------------//
// 管理番号  11070100-00 作成担当 : 宮本 利明
// 作 成 日  2014/07/15  修正内容 : 仕掛一覧 №1912
//----------------------------------------------------------------------------//
// 管理番号  11100713-00 作成担当 : 高騁
// 作 成 日  K2015/04/01 修正内容 : 森川部品個別依頼の改良作業全拠点在庫情報一覧機能追加
//----------------------------------------------------------------------------//
// 管理番号  11100543-00 作成担当 : 黄興貴
// 作 成 日  K2015/04/29 修正内容 : 富士ジーワイ商事㈱ UOE取込対応
//----------------------------------------------------------------------------//
// 管理番号  11101427-00 作成担当 : 紀飛
// 作 成 日  K2015/06/18 修正内容 : ㈱メイゴ　WebUOE発注回答取込対応
//----------------------------------------------------------------------------//
// 管理番号  11170204-00 作成担当 : 宮本 利明
// 作 成 日  2015/12/09  修正内容 : リモ伝障害対応 Redmine#47670
// ----------------------------------------------------------------------------//
// 管理番号  11202099-00  作成担当 : 譚洪
// 作 成 日  K2016/11/01  修正内容 : 売上伝票入力から外部PGを起動して売単価を算出の対応
//----------------------------------------------------------------------------//
// 管理番号  11202452-00  作成担当 : 譚洪
// 作 成 日  K2016/12/30  修正内容 : 水野商工様個別変更内容をPM.NSにて実現するため、第二売価の対応行います。
//----------------------------------------------------------------------------//
// 管理番号  11470152-00  作成担当 : 譚洪
// 作 成 日  2018/09/04  修正内容 : 履歴自動表示機能追加対応
//----------------------------------------------------------------------------//
// 管理番号  11570208-00  作成担当 : 譚洪
// 作 成 日  2020/02/24   修正内容 : 消費税税率機能追加対応
//----------------------------------------------------------------------------//
// 管理番号  11870080-00  作成担当 : 陳艶丹
// 作 成 日  2022/04/26  修正内容 : PMKOBETSU-4208 電子帳簿対応
//----------------------------------------------------------------------------//


unit MAHNB01013BMP;

interface

uses
    ShareMem, SysUtils, Classes, HDllCall, DBClient, HFSLLIB, MAHNB01013C, MAHNB01012C, Forms;

type
    TDataModule1 = class(TDataModule)
        HDllCall1: THDllCall;
        private
            { Private 宣言 }
        public
            { Public 宣言 }
    end;

    /////////////////// 仲介クラスからのインポート関数型宣言 /////////////////

    // add by tanh
    // 得意先ガイド処理メソッド型
    TxDelphiSalesSlipInputAcs_Clear = function(isConfirm: Boolean;
    keepAcptAnOdrStatus: Boolean;
    keepDate: Boolean;
    keepFooterInfo: Boolean;
    keepCustomer: Boolean;
    keepSalesDate: Boolean;
    keepDetailRowCount :Boolean;
customerCode: Integer): Boolean; stdcall;

    // 伝票区分コンボエディタアイテム設定処理メソッド型
    TxDelphiSalesSlipInputAcs_GetItemtSalesSlipCd = function(var setItemtSalesSlipCdDisp: Integer;
    var setItemtSalesSlipCdFlg: Integer): Integer; stdcall;

    // --- ADD 2011/02/12 ---------->>>>>
    // 調査用ログ出力クラス処理メソッド型
    TxDelphiSalesSlipInputAcs_DoAddLine = function(logNo: Integer;
    slipNo: Integer;
    acptAnOdrStatus: Integer): Integer; stdcall;

    // 調査用ログImage出力処理メソッド型
    TxDelphiSalesSlipInputAcs_DoCacheImage = function(): Integer; stdcall;
    // 各種マスタチェックメソッド型
    TxDelphiSalesSlipInputAcs_GetErrorFlag = function(var resultErrorFlag: Boolean): Integer; stdcall;
    // --- ADD 2011/02/12 ----------<<<<<

    // --- ADD 2011/11/22 ---------->>>>>
    //連携判断処理関数定義
    TxDelphiSalesSlipInputAcs_CooprtKindDiv = function(var CooprtFlag: Boolean)
    : Integer; stdcall;
    // --- ADD 2011/11/22 ----------<<<<<


    // --- ADD 2011/04/13 ---------->>>>>
    // 選択済み売上行番号削除処理（多行削除場合用）メソッド型
    TxDelphiSalesSlipInputAcs_DetailDeleteActionTable = function(startRowNo: Integer;
    endRowNo: Integer): Integer; stdcall;
    // --- ADD 2011/04/13 ----------<<<<<

    // 各種起動データメソッド型
//    TxDelphiSalesSlipInputAcs_SetInitData = function(): Integer; stdcall;   //DEL 連番729 2011/08/18
    TxDelphiSalesSlipInputAcs_SetInitData = function(var existFlg: Boolean): Integer; stdcall;  //ADD 連番729 2011/08/18

    // --- ADD 2011/05/30 ---------->>>>>
    // 画面の拠点コード変化時（キャンペーン情報取得用）メソッド型
    TxDelphiSalesSlipInputAcs_SetSectionCode = function(sectionCode: WideString): Integer; stdcall;
    // --- ADD 2011/05/30 ----------<<<<<

    // --- ADD 2011/07/18 ---------->>>>>
    // 現在庫数を調整しますメソッド型
    TxDelphiSalesSlipInputAcs_StockInfoAdjust = function(): Integer; stdcall;
    // --- ADD 2011/07/18 ----------<<<<<


    // --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ---------->>>>>
    //第二売価ガイドの位置を設定します。
    TxDelphiSalesSlipInputAcs_SetSecondSalesUnPrcGideLocation = function(locationLeft: Integer;
    locationTop: Integer): Integer; stdcall;

    // 水野商工㈱オプション判定メソッド型
    TxDelphiSalesSlipInputAcs_OptPermitForMizuno2ndSellPriceCtl = function
    (var resultOptPermitForMizuno2ndSellPriceCtl: Boolean): Integer; stdcall;
    // --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ----------<<<<<

    // 設定用処理メソッド型
    TxDelphiSalesSlipInputAcs_SetAfterSaveData = function(resultData: Integer;
    carMngCode: WideString;
    printSlipFlag: Boolean;
    isMakeQR: Boolean;
    scmFlg: Boolean;
    cmtFlag: Boolean;
    // ----- ADD K2011/12/09 --------->>>>>
    slipNote2ErrFlag: Boolean;
    // UPD 2013/02/17 SCM障害№192対応 ------------------>>>>>
    //salesDateErrFlag: Boolean): Integer; stdcall;
    salesDateErrFlag: Boolean;
    isSCMSave: Integer): Integer; stdcall;
    // UPD 2013/02/17 SCM障害№192対応 ------------------<<<<<
    // ----- ADD K2011/12/09 ---------<<<<<

    // 保存用設定処理メソッド型
    TxDelphiSalesSlipInputAcs_GetAfterSaveData = function(var resultData: Integer;
    var resultIsMakeQR: Boolean;
    var resultScmFlg: Boolean;
    var resultCmtFlag: Boolean;
    // ----- ADD K2011/12/09 --------->>>>>
    var slipNote2ErrFlag: Boolean;
    // UPD 2013/02/17 SCM障害№192対応 ------------------>>>>>
    //var salesDateErrFlag: Boolean): Integer; stdcall;
    var salesDateErrFlag: Boolean;
    var isSCMSave: Integer): Integer; stdcall;
    // UPD 2013/02/17 SCM障害№192対応 ------------------<<<<<
    // ----- ADD K2011/12/09 ---------<<<<<

    TxDelphiSalesSlipInputAcs_DoAfterSave = function(): Integer; stdcall;

    // ----- ADD 2012/10/15 --------->>>>>>
    // 仕入日のエラーメッセージを表示処理
    TxDelphiSalesSlipInputAcs_ShowStockDateMsg = function(): Integer; stdcall;
    // ----- ADD 2012/10/15 ---------<<<<<<

    // 各種マスタチェックメソッド型
    TxDelphiSalesSlipInputAcs_InitMstCheck = function(var resultMstCheckFlg: Boolean): Integer; stdcall;

    // 得意先情報画面格納処理メソッド型
    TxDelphiSalesSlipInputAcs_GetDisplayCustomerInfo = function(var customerNameFlg: Integer;
    var totalDayDf: WideString;
    var collectMoneyDf: WideString): Integer; stdcall;

    // 追加情報タブ項目Visible設定メソッド型
    TxDelphiSalesSlipInputAcs_GetAddInfoVisible = function(var ctTabKeyAddInfo: Integer;
    var settingAddInfoVisibleFlg: Integer): Integer; stdcall;

    // 伝票区分コンボエディタアイテム設定処理メソッド型
    TxDelphiSalesSlipInputAcs_GetDisplayHeaderFooterInfo = function(
    var inputModeTitle: WideString;
    var defaultSalesSlipNumDf: WideString;
    var searchPartsModeFlg: Integer;
    var operationCodeFlg: Integer): Integer; stdcall;

    // オプション情報処理メソッド型
    TxDelphiSalesSlipInputAcs_FormPosSerialize = function(topInt: Integer;
    leftInt: Integer;
    heightInt: Integer;
    widthInt: Integer): Integer; stdcall;
    // オプション情報処理メソッド型
    TxDelphiSalesSlipInputAcs_FormPosDeserialize = function(var topInt: Integer;
    var leftInt: Integer;
    var heightInt: Integer;
    var widthInt: Integer): Integer; stdcall;

    // 備考設定処理メソッド型
    TxDelphiSalesSlipInputAcs_GetNoteGuidList = function(enterpriseCode: WideString): Integer; stdcall;

    // 明細データ取得メソッド型
    TxDelphiSalesSlipInputAcs_SetUserGdBdComboEditor = function(var resultGuideCodeList: PWideString;
                                                                var resultGuideCodeCount: Integer;
                                                                var resultGuideNameList: PWideString;
                                                                var resultGuideNameCount: Integer)
    : Integer; stdcall;

    // セルEnabled設定取得処理メソッド型
    TxDelphiSalesSlipInputAcs_GetCellEnabled = function(keyName: WideString): Integer; stdcall;

    // 元に戻す処理メソッド型
    TxDelphiSalesSlipInputAcs_Retry = function(isConfirm: Boolean;
    var resultDialogResultFlg: Boolean): Integer; stdcall;

    // 元に戻す処理メソッド型
    TxDelphiSalesSlipInputAcs_RetryResult = function(var resultStatusFlg: Boolean): Integer; stdcall;
    // 終了設定処理メソッド型
    // --- UPD m.suzuki 2010/06/12 ---------->>>>>
    //TxDelphiSalesSlipInputAcs_Close = function(isConfirmFlg: Boolean;
    //var resultCanCloseFlg: Boolean): Integer; stdcall;
    TxDelphiSalesSlipInputAcs_Close = function(isConfirmFlg: Boolean;
    var resultCanCloseFlg: Boolean; var isMakeQR: Boolean): Integer; stdcall;
    // --- UPD m.suzuki 2010/06/12 ----------<<<<<

    // 設定処理メソッド型
    TxDelphiSalesSlipInputAcs_SetSalesDetailData = function(inputdata: WideString;
    inputType: Integer): Integer; stdcall;
    // --- ADD 2010/05/31 ---------->>>>>
    // ESC処理メソッド型
    TxDelphiSalesSlipInputAcs_uButtonEscClick = function(var resultEscFlg: Boolean): Integer; stdcall;
    // --- ADD 2010/05/31 ----------<<<<<

    // --- ADD 2012/05/31 No.282---------->>>>>
    // ESC処理2(発注解除)メソッド型
    TxDelphiSalesSlipInputAcs_uButtonEscClick2 = function(var resultEscFlg: Boolean): Integer; stdcall;
    // 発注退避処理メソッド型
    TxDelphiSalesSlipInputAcs_SaveOrderInfo = function(var resultEscFlg: Boolean): Integer; stdcall;
    // --- ADD 2012/05/31 No.282----------<<<<<
    // オプション情報処理メソッド型
    TxDelphiSalesSlipInputAcs_GetGrossProfitRateFlg = function(var resultGrossProfitRateFlg: Boolean): Integer; stdcall;
    // 小数点表示区分処理メソッド型
    TxDelphiSalesSlipInputAcs_SmallPointProc = function(rowIndexParm: Integer): Integer; stdcall;
    // end add by tanh

    // add by zhangkai

    // ガイドボタンクリックイベント処理メソッド型
    TxDelphiSalesSlipInputAcs_uButtonGuideClick = function(rowIndexParm: Integer;
    columnName: WideString): Integer; stdcall;

    // 移動位置取得処理(Enterキー移動時)メソッド型
    TxDelphiSalesSlipInputAcs_GetNextMovePosition = function(p: WideString;
    var afterColKeyName: WideString): Integer; stdcall;

    // ファンクション明細制御取得処理メソッド型
    TxDelphiSalesSlipInputAcs_GetBitButtonCustomizeSetting = function(key: WideString;
    var bitButtonCustomizedVisible: Integer): Integer; stdcall;

    // --- ADD 2010/06/02 ---------->>>>>
    // 移動位置取得処理(Enterキー移動時)メソッド型
    TxDelphiSalesSlipInputAcs_GetPreMovePosition = function(p: WideString;
    var afterColKeyName: WideString): Integer; stdcall;
    // --- ADD 2010/06/02 ----------<<<<<

    // HOMEキー設定処理メソッド型
    TxDelphiSalesSlipInputAcs_SetHomeKeyFlg = function(homeKeyFlg: Boolean): Integer; stdcall;

    // Param取得処理メソッド型
    TxDelphiSalesSlipInputAcs_GetParam = function(var startKeyName: WideString;
    var endKeyNameList: WideString): Integer; stdcall;

    // フォーカス移動対象判定処理メソッド型
    TxDelphiSalesSlipInputAcs_GetEffectiveJudgment = function(keyName: WideString): Integer; stdcall;

    // 明細データ取得メソッド型
    TxDelphiSalesSlipInputAcs_GetSalesDetailDataTable = function(salesDetailList: TSalesSlipInputCustomArrayA2;
    var refSalesDetailList: TSalesSlipInputCustomArrayA2;
    salesRowNo: Integer): Integer; stdcall;

    // 行値引き処理メソッド型
    TxDelphiSalesSlipInputAcs_uButtonLineDiscountClick = function(parmRowIndex: Integer): Integer; stdcall;

    // 解放メソッド型
    TxDelphiSalesSlipInputAcs_FreeCustomArrayA2 = function(resultList: PSalesSlipInputCustomArrayA2;
        resultCount: Integer): Integer; stdcall;

    // 明細データ取得メソッド型
    TxDelphiSalesSlipInputAcs_GetSalesAllDetailDataTable = function(salesDetailList: TSalesSlipInputCustomArrayA2;
    var refSalesDetailList: TSalesSlipInputCustomArrayA2): Integer; stdcall;

    // 品番検索処理メソッド型
    TxDelphiSalesSlipInputAcs_AfterGoodsNoUpdate = function(rowIndex: Integer;
    cellValue: WideString;
    makerCd: Integer;         //ADD 連番729 2011/08/18
    salesRowNo: Integer): Integer; stdcall;

    // 商品値引き処理メソッド型
    TxDelphiSalesSlipInputAcs_uButtonGoodsDiscountClick = function(parmRowIndex: Integer): Integer; stdcall;

    // 注釈処理メソッド型
    TxDelphiSalesSlipInputAcs_uButtonAnnotationClick = function(parmRowIndex: Integer): Integer; stdcall;

    // 倉庫切替処理メソッド型
    TxDelphiSalesSlipInputAcs_uButtonChangeWarehouseClick = function(parmSalesRowNo: Integer): Integer; stdcall;

    // 在庫検索処理メソッド型
    TxDelphiSalesSlipInputAcs_uButtonStockSearchClick = function(parmRowIndex: Integer): Integer; stdcall;

    // ＴＢＯ処理メソッド型
    TxDelphiSalesSlipInputAcs_uButtonTBOClick = function(parmRowIndex: Integer): Integer; stdcall;

    // 前行複写処理メソッド型
    TxDelphiSalesSlipInputAcs_uButtonCopyStockBefLineClick = function(parmRowIndex: Integer): Integer; stdcall;

    // 一括複写処理メソッド型
    TxDelphiSalesSlipInputAcs_uButtonCopyStockAllLineClick = function(parmRowIndex: Integer): Integer; stdcall;

    // グリッドセルアップデート後処理メソッド型
    TxDelphiSalesSlipInputAcs_uGridDetailsAfterCellUpdate = function(rowIndexParm: Integer;
    cellValue: WideString;
    beforeCellValue: WideString;
    columnName: WideString): Integer; stdcall;

    // グリッドセルアップデート後処理メソッド型
    TxDelphiSalesSlipInputAcs_uGridDetailsAfterCellUpdateProc = function(rowIndexParm: Integer;
    cellValue: WideString;
    beforeCellValue: WideString;
    columnName: WideString): Integer; stdcall;

    // グリッド関連チェック処理メソッド型
    TxDelphiSalesSlipInputAcs_GridJoinCheck = function(salesRowNo: Integer;
    rowIndex: Integer;
    operationCode: Integer;
    mode: Integer): Integer; stdcall;

    // Table処理メソッド型
    TxDelphiSalesSlipInputAcs_DeatilActionTable = function(salesRowNo: Integer;
    actionType: WideString): Integer; stdcall;

    // 得意先注番のフォーカス処理メソッド型
    TxDelphiSalesSlipInputAcs_AfterPartySaleSlipNumFocus = function(salesSlip: TSalesSlip;
    var refSalesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    value: WideString;
    var dialogFlag: Boolean): Integer; stdcall;

    // チェック処理メソッド型
    TxDelphiSalesSlipInputAcs_CheckDetailAction = function(beforeRowIndex: Integer;
    parmRowIndex: Integer;
    checkType: Integer): Integer; stdcall;

    // ユーザー設定処理メソッド型
    TxDelphiSalesSlipInputAcs_GetSalesSlipInputConstructionData = function(var data: Integer;
    inputType: Integer): Integer; stdcall;

    // 返品理由ガイド処理メソッド型
    TxDelphiSalesSlipInputAcs_retGoodsReason = function(enterpriseCode: WideString;
    var resultUserGdHd: TUserGdHd;
    var resultUserGdBd: TUserGdBd;
    var salesSlip: TSalesSlip): Integer; stdcall;

    // 伝票メモ情報設定処理メソッド型
    TxDelphiSalesSlipInputAcs_SetSlipMemo = function(slipMemo1: WideString;
    slipMemo2: WideString;
    slipMemo3: WideString;
    insideMemo1: WideString;
    insideMemo2: WideString;
    insideMemo3: WideString;
    salesRowNo: Integer): Integer; stdcall;

    // 数値入力チェック処理メソッド型
    TxDelphiSalesSlipInputAcs_KeyPressNumCheck = function(keta: Integer;
    priod: Integer;
    prevVal: WideString;
    key: WideString;
    selstart: Integer;
    sellength: Integer;
    minusFlg: Boolean): Integer; stdcall;

    // CSV出力先が設定され、フォルダが存在しているかチェック処理メソッド型
    TxDelphiSalesSlipInputAcs_CsvPassCheck = function(var linkDir: WideString): Integer; stdcall;

    // end add by zhangkai

// add by yangmj

    // 出荷計上処理メソッド型
    TxDelphiSalesSlipInputAcs_ShipmentAddUp = function(isDataChanged: Boolean;
    var resultIsSave: Integer): Integer; stdcall;

    // 出荷照会ボタンクリック処理メソッド型
    TxDelphiSalesSlipInputAcs_GetSalesHisGuide = function(count: Integer; customerCode: WideString): Integer; stdcall;

    // 解放メソッド型
    TxDelphiSalesSlipInputAcs_FreeSalesSlip = function(resultList: PSalesSlip;
        resultCount: Integer): Integer; stdcall;

    // 受注照会(明細選択)メソッド型
    TxDelphiSalesSlipInputAcs_AcceptAnOrderReferenceSearch = function(rowCount: Integer; customerCode: WideString): Integer; stdcall;

    // 受注計上処理メソッド型
    TxDelphiSalesSlipInputAcs_AcceptAnOrderAddup = function(IsDataChanged: Boolean;
    var resultIsResult: Integer): Integer; stdcall;

    // 見積計上(明細選択)メソッド型
    TxDelphiSalesSlipInputAcs_EstimateReferenceSearch = function(rowCount: Integer; customerCode: WideString): Integer; stdcall;

    // 見積照会(伝票選択)メソッド型
    TxDelphiSalesSlipInputAcs_EstimateAddup = function(IsDataChanged: Boolean;
    var resultIsResult: Integer): Integer; stdcall;

    // 履歴照会(売上履歴データから明細選択) メソッド型
    TxDelphiSalesSlipInputAcs_SalesReferenceSearch = function(rowCount: Integer; customerCode: WideString): Integer; stdcall;

    // 伝票複写メソッド型
    TxDelphiSalesSlipInputAcs_CopySlip = function(IsDataChanged: Boolean;
    var resultIsResult: Integer): Integer; stdcall;

    // 車両管理オプション取得処理メソッド型
    TxDelphiSalesSlipInputAcs_GetOptCarMng = function(var optCarMng: Integer): Integer; stdcall;

    // 伝票備考、伝票備考２、伝票備考３の入力桁数設定処理メソッド型
    TxDelphiSalesSlipInputAcs_SetNoteCharCnt = function(var slipNoteCharCnt: Integer;
    var slipNote2CharCnt: Integer;
    var slipNote3CharCnt: Integer): Integer; stdcall;

    // 返品処理関係メソッド型
    TxDelphiSalesSlipInputAcs_ReturnSlip = function(isDataChanged: Boolean;
    var isResult: Integer): Integer; stdcall;

    // 保存確認ダイアログ表示処理メソッド型
    // --- UPD m.suzuki 2010/06/12 ---------->>>>>
    //TxDelphiSalesSlipInputAcs_ShowSaveCheckDialog = function(isConfirm: Boolean;
    //var resultNum: Integer; carMngCode: WideString): Integer; stdcall;
    TxDelphiSalesSlipInputAcs_ShowSaveCheckDialog = function(isConfirm: Boolean;
    var resultNum: Integer; carMngCode: WideString; var isMakeQR: Boolean): Integer; stdcall;
    // --- UPD m.suzuki 2010/06/12 ----------<<<<<

    // 保存処理メソッド型
    // --- UPD m.suzuki 2010/06/12 ---------->>>>>
    //TxDelphiSalesSlipInputAcs_Save = function(isShowSaveCompletionDialog: Boolean;
    //isConfirm: Boolean): Boolean; stdcall;
    TxDelphiSalesSlipInputAcs_Save = function(isShowSaveCompletionDialog: Boolean;
    isConfirm: Boolean; var isMakeQR: Boolean): Boolean; stdcall;
    // --- UPD m.suzuki 2010/06/12 ----------<<<<<

    // 保存後処理メソッド型
// 2011/01/31 >>>
//    // --- UPD m.suzuki 2010/06/12 ---------->>>>>
//    //TxDelphiSalesSlipInputAcs_AfterSave = function(var result: Integer;
//    //carMngCode: WideString; printSlipFlag: Boolean): Integer; stdcall;
//    TxDelphiSalesSlipInputAcs_AfterSave = function(var result: Integer;
//    carMngCode: WideString; printSlipFlag: Boolean; var isMakeQR: Boolean; scmFlg: Boolean): Integer; stdcall;
//    // --- UPD m.suzuki 2010/06/12 ----------<<<<<

    TxDelphiSalesSlipInputAcs_AfterSave =
        function(
          var result: Integer;
          carMngCode: WideString;
          printSlipFlag: Boolean;
          var isMakeQR: Boolean;
          var scmFlg: Boolean;
          var cmtFlg: Boolean;
          var slipNote2ErrFlag: Boolean; // ADD K2011/08/12
          // UPD 2013/02/17 SCM障害№192対応 ------------------>>>>>
          //var salesDateErrFlag: Boolean // ADD K2011/09/01
          var salesDateErrFlag: Boolean; // ADD K2011/09/01
          var isSCMSave: Integer
          // UPD 2013/02/17 SCM障害№192対応 ------------------<<<<<
        ): Integer; stdcall;
// 2011/01/31 <<<

    // 保存状態取得メソッド型
    TxDelphiSalesSlipInputAcs_GetSaveStatus = function(var status: Integer): Integer; stdcall;

    // --- ADD 2015/12/09 T.Miyamoto リモ伝障害対応 Redmine#47670 ---------->>>>>
    // オンライン種別取得メソッド型
    TxDelphiSalesSlipInputAcs_GetOnlineKindDiv = function(var onlineKindDiv: Integer): Integer; stdcall;
    // --- ADD 2015/12/09 T.Miyamoto リモ伝障害対応 Redmine#47670 ----------<<<<<

    // 解放メソッド型
    TxDelphiSalesSlipInputAcs_FreeUserGdHd = function(resultList: PUserGdHd;
        resultCount: Integer): Integer; stdcall;

    // 解放メソッド型
    TxDelphiSalesSlipInputAcs_FreeUserGdBd = function(resultList: PUserGdBd;
        resultCount: Integer): Integer; stdcall;

    // 部品検索切替処理メソッド型
    TxDelphiSalesSlipInputAcs_ChangeSearchMode = function(clearCarFlag: Integer;
    CheckRowEffectiveFlg: Boolean;
    salesRowNo: Integer;
    ContainsFocusFlg: Boolean;
    var resultCarMngCodeMode: Boolean): Integer; stdcall;

    // 部品検索モード取得メソッド型
    TxDelphiSalesSlipInputAcs_GetSearchPartsModeProperty = function(var searchPartsModeProperty: Integer): Integer; stdcall;

    //----ADD 2010/06/17----->>>>>
    // 売上データ設定メソッド型
    TxDelphiSalesSlipInputAcs_SetSalesSlip = function(Salesslip: TSalesSlip): Integer; stdcall;
    //----ADD 2010/06/17-----<<<<<
    //----ADD 2010/11/02----->>>>>
    TxDelphiSalesSlipInputAcs_SetSalesSlipByObj = function(Salesslip: TSalesSlip): Integer; stdcall;
    //----ADD 2010/11/02-----<<<<<

// end add by yangmj

// add by gaofeng start

    // 初期データをＤＢより取得の処理メソッド型
    TxDelphiGetSalesSlipInputInitDataAcs_GetInitData = function(): Integer; stdcall;

    //文字列解放メソッド型
    TxDelphiGetSalesSlipInputInitDataAcs_FreeMessage = function(msg : WideString):Integer; stdcall;

    // 売上伝票ガイド処理メソッド型
    TxDelphiSalesSlipInputAcs_salesSlipGuide = function(formName: WideString;
    enterpriseCode: WideString;
    acptAnOdrStatusDisplay: Integer;
    var refAcptAnOdrStatus: Integer;
    var estimateDivide: Integer;
    var resultSearchResult: TSalesSlipSearchResult;
    var salesSlip: TSalesSlip;
    var outDialogResult: Boolean;
    var outStatus: Boolean;
    var consTaxLayMethodChangedFlg: Boolean;
    var isPCCUOESaleSlip: Boolean): Integer; stdcall;//ADD 2011/11/18

    // 得意先ガイド処理メソッド型
    TxDelphiSalesSlipInputAcs_customerGuide = function(customerFlag: Boolean;
    addresseeCode: Integer;
    customerCode: Integer;
    var resultCustomerSearchRet: TCustomerSearchRet;
    var dialogResultFlag: Integer;
    var customerCodeChangedFlg: Boolean;
    var optCarMngFlg: Boolean): Integer; stdcall;

    // 解放メソッド型
    TxDelphiSalesSlipInputAcs_FreeCustomerSearchRet = function(resultList: PCustomerSearchRet;
        resultCount: Integer): Integer; stdcall;

    // 設定処理メソッド型
    TxDelphiSalesSlipInputAcs_ShowSalesSlipInputSetup = function(): Integer; stdcall;
    // 画面項目名称取得処理メソッド型
    // ADD　譚洪 2020/02/24 PMKOBETSU-2912の対応 ---------->>>>>
    //TxDelphiSalesSlipInputAcs_GetDisplayName = function(var rateName: WideString; var taxFlg: Boolean)): Integer; stdcall;
    TxDelphiSalesSlipInputAcs_GetDisplayName = function(var rateName: WideString; var taxFlg: Boolean): Integer; stdcall;
    // ADD　譚洪 2020/02/24 PMKOBETSU-2912の対応 ----------<<<<<
    // 明細粗利率取得処理メソッド型
    TxDelphiSalesSlipInputAcs_GetDetailGrossProfitRate = function(rowNo: Integer; var detailGrossProfitRate: WideString;
    var addDetailGrossProfitRate: WideString): Integer; stdcall;

    // 削除処理メソッド型
    TxDelphiSalesSlipInputAcs_Delete = function(var outCheck: Boolean;
    var outDialogResult: Integer;
    var outStatus: Integer): Integer; stdcall;
    // アイテム名の取得処理メソッド型
    TxDelphiSalesSlipInputAcs_GetItemName = function(var itemName: WideString;
    var tableName: WideString): Integer; stdcall;

    TxDelphiSalesSlipInputAcs_GetStatus = function(var status: Integer): Integer; stdcall;

    TxDelphiSalesSlipInputAcs_GetBeforeSalesSlipNumText = function(var beforeSalesSlipNumText: WideString): Integer; stdcall;
    // フォーカス位置の取得処理メソッド型
    TxDelphiSalesSlipInputAcs_GetFocusPositionValue = function(var focusPositionValue: Integer): Integer; stdcall;
    // 赤伝処理メソッド型
    TxDelphiSalesSlipInputAcs_RedSlip = function(isConfirm: Boolean; canRed: Boolean): Integer; stdcall;

    // 赤伝できるかどうかフラグの取得処理メソッド型
    TxDelphiSalesSlipInputAcs_GetCanRed = function(var resultCanRed: Boolean): Integer; stdcall;
    TxDelphiSalesSlipInputAcs_GetRedDialogResult = function(var redDialogResult: Integer): Integer; stdcall;

    // 見出貼付メソッド型
    TxDelphiSalesSlipInputAcs_CopySlipHeader = function(CarInfoEnabledFlg : Boolean;
    salesRowNo: Integer;
    addresseeName: Integer;
    var existSalesDetail: Boolean;
    var clearDetailFlg: Boolean;
    var searchPartsModeProperty: Integer;
    var fullModelFixedNoAryFlg: Boolean;
    var errorFlg: Boolean;
    var outSalesSlipHeaderCopyData: TSalesSlipHeaderCopyData;
    var copySlipHeaderClearFlg: Boolean): Integer; stdcall;

//-------------- ADD 連番729 2011/08/18 ----------------->>>>>
    // 詳細貼付メソッド型
    TxDelphiSalesSlipInputAcs_CopySlipDetail = function(salesRowNo: Integer): Integer; stdcall;
//-------------- ADD 連番729 2011/08/18 -----------------<<<<<

    // 管理番号ガイド表示後の処理メソッド型
    TxDelphiSalesSlipInputAcs_AfterCarMngNoGuideReturn = function(status: Integer;
    selectedInfo: TCarMangInputExtraInfo;
    inputflag: Integer;
    salesRowNo: Integer;
    carMngCode: WideString;
    var resultReturnFlag: Boolean;
    var resultClearCarInfoFlag: Boolean): Integer; stdcall;

    // xxxxメソッド型
    TxDelphiSalesSlipInputAcs_setToolMenuCustomizeSetting = function(key: WideString): Integer; stdcall;

    // xxxxメソッド型
    TxDelphiSalesSlipInputAcs_getToolMenuCustomizeSetting = function(var resultToolMenuCustomizeSettingNotNull: Boolean;
    var resultToolBarVisible: Boolean;
    var toolBarDockedRow: Integer;
    var toolBarDockedColumn: Integer;
    var toolBarDockedPosition: Integer): Integer; stdcall;

    // xxxxメソッド型
    TxDelphiSalesSlipInputAcs_setToolButtonCustomizeSetting = function(key: WideString): Integer; stdcall;

    // xxxxメソッド型
    TxDelphiSalesSlipInputAcs_getToolButtonCustomizeSetting = function(var resultToolButtonCustomizeSettingNotNull: Boolean;
    var toolBarCustomizedVisible: Integer): Integer; stdcall;

    // xxxxメソッド型
    TxDelphiSalesSlipInputAcs_SaveToolbarCustomizeSetting = function(key: WideString;
    visible: Boolean): Integer; stdcall;

    // xxxxメソッド型
    TxDelphiSalesSlipInputAcs_SaveToolManagerCustomizeInfo = function(key: WideString;
    visible: Boolean;
    dockedRow: Integer;
    dockedColumn: Integer;
    dockedPosition: Integer): Integer; stdcall;

    // xxxxメソッド型
    TxDelphiSalesSlipInputAcs_SaveCustomizeXml = function(): Integer; stdcall;

    TxDelphiSalesSlipInputAcs_GetUltraOptionSetValue = function(): Integer;
    TxDelphiSalesSlipInputAcs_SlipNoteGuide = function(salesRowNo: Integer): Integer; stdcall;
    // 売上金額変更後発生イベント処理メソッド型
    TxDelphiSalesSlipInputAcs_SalesPriceChanged = function(): Integer; stdcall;
    // 車両情報設定処理メソッド型
    TxDelphiSalesSlipInputAcs_CarInfoFormSetting = function(salesRowNo: Integer;
    var resultIsGoodsFlg: Boolean;
    var resultCarInfoRowFlg: Boolean): Integer; stdcall;

    // 保存確認ダイアログ表示処理メソッド型
    // --- UPD m.suzuki 2010/06/12 ---------->>>>>
    //TxDelphiSalesSlipInputAcs_ShowRedSaveCheckDialog = function(isConfirm: Boolean;
    //var resultAfterSaveClearFlg: Boolean): Integer; stdcall;
    TxDelphiSalesSlipInputAcs_ShowRedSaveCheckDialog = function(isConfirm: Boolean;
    var resultAfterSaveClearFlg: Boolean; var isMakeQR: Boolean): Integer; stdcall;
    // --- UPD m.suzuki 2010/06/12 ----------<<<<<

    //---UPD 2010/07/06---------->>>>>
    // SetItemsDictionaryメソッド型
//    TxDelphiSalesSlipInputAcs_SetItemsDictionary = function(headControlNames: WideString; footControlNames: WideString): Integer; stdcall;
    TxDelphiSalesSlipInputAcs_SetItemsDictionary = function(headControlNames: WideString; footControlNames: WideString; functionControlNames: WideString; functionDetailControlNames: WideString): Integer; stdcall;
    //---UPD 2010/07/06----------<<<<<

    // setColDisplayStatusListメソッド型
    TxDelphiSalesSlipInputAcs_setColDisplayStatusList = function(): Integer; stdcall;

    // --- ADD 2010/06/02 ---------->>>>>
    // GetReadSlipFlgメソッド型
    TxDelphiSalesSlipInputAcs_GetReadSlipFlg = function(var resultReadSlipFlg: Boolean): Integer; stdcall;
    // --- ADD 2010/06/02----------<<<<<

    // --- ADD 黄興貴 2015/04/29 回答取込パタン追加 ---------------->>>>>
    // UOEデータ取込メソッド型
    TxDelphiSalesSlipInputAcs_ReadUoeData = function(salesRowNo: Integer): Integer; stdcall;
    // 富士ジーワイ商事㈱オプション判定メソッド型
    TxDelphiSalesSlipInputAcs_OptPermitForFuJi = function(var resultOptPermitForFuJi: Boolean): Integer; stdcall;
    // --- ADD 黄興貴 2015/04/29 回答取込パタン追加 ----------------<<<<<

  // --- ADD 紀飛 2015/06/18 WebUOE発注回答取込 ---------------->>>>>
  // ㈱メイゴオプション判定メソッド型
  TxDelphiSalesSlipInputAcs_OptPermitForMeiGo = function
    (var resultOptPermitForMeiGo: Boolean): Integer; stdcall;
  // --- ADD 紀飛 2015/06/18 WebUOE発注回答取込 ----------------<<<<<
    // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応--->>>>>
    // 電子帳簿連携オプション判定
    TxDelphiSalesSlipInputAcs_OptPermitForEBooks = function(var resultOptPermitForEBooks: Boolean): Integer; stdcall;
    // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応---<<<<<

    // --- ADD 2010/07/08 ---------->>>>>
    // 操作権限の制御メソッド型
    TxDelphiSalesSlipInputAcs_BeginControllingByOperationAuthority = function(var resultRevisionVisible: Boolean;
    var resultDeleteVisible: Boolean;
    //var resultRedSlipVisible: Boolean): Integer; stdcall;// DEL 2013/01/24 鄧潘ハン REDMINE#34141
    var resultRedSlipVisible: Boolean;var SlipDiscountVisible: Boolean): Integer; stdcall;// ADD 2013/01/24 鄧潘ハン REDMINE#34141
    // --- ADD 2010/07/08 ----------<<<<<
// add by gaofeng end

    // --- ADD 2014/07/15 T.Miyamoto 仕掛一覧 №1912 ---------->>>>>
    TxDelphiSalesSlipInputAcs_GetOperationSt = function(iOperationCode: Integer): Boolean; stdcall;
    // --- ADD 2014/07/15 T.Miyamoto 仕掛一覧 №1912 ----------<<<<<

// add by lizc begin
// 最新情報処理メソッド型
    TxDelphiSalesSlipInputAcs_ReNewalBtnClick = function(enterpriseCode: WideString;
    loginSectionCode: WideString): Integer; stdcall;

    // xxxxxメソッド型
    TxDelphiSalesSlipInputAcs_ProcessingDialogDispose = function(): Integer; stdcall;
// add by lizc end

    //文字列解放メソッド型
    TxDelphiSalesSlipInputAcs_FreeMessage = function(msg : WideString):Integer; stdcall;

    // 解放メソッド型
    TxDelphiSalesSlipInputAcs_FreeSalesSlipSearchResult = function(resultList: PSalesSlipSearchResult;
        resultCount: Integer): Integer; stdcall;

    // --- ADD m.suzuki 2010/06/12 ---------->>>>>
    TxDelphiSalesSlipInputAcs_MakeQR = procedure( sParam: WideString ); stdcall;
    // --- ADD m.suzuki 2010/06/12 ----------<<<<<
    // --- ADD m.suzuki 2010/06/16 ---------->>>>>
    TxDelphiSalesSlipInputAcs_GetOnlineFlag = function(): Boolean; stdcall;
    // --- ADD m.suzuki 2010/06/16 ----------<<<<<

    //>>>2010/05/30
    // SCM問合せ一覧せメソッド型
    TxDelphiSalesSlipInputAcs_ReferenceList = function(isDataChanged: Boolean;
    var resultIsSave: Integer): Integer; stdcall;

    TxDelphiSalesSlipInputAcs_HisSearch = function(salesRowNo: Integer): Integer; stdcall;  // ADD　2018/09/04 譚洪　履歴自動表示の対応
    
    TxDelphiSalesSlipInputAcs_GetTaxRateDialogResult = function(var taxRateDialogResult: Integer): Integer; stdcall;  // ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応
    TxDelphiSalesSlipInputAcs_GetTaxRate = function(): Integer; stdcall;  // ADD 譚洪 2020/02/24PMKOBETSU-2912の対応
    TxDelphiSalesSlipInputAcs_OrderCheck = function(mode: Integer; var ret: Boolean): Integer; stdcall;  // ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応
    TxDelphiSalesSlipInputAcs_StartEBooks = function(): Integer; stdcall;  // ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応

    // 起動パラメータ設定メソッド型
// 2011/01/31 >>>
//    TxDelphiSalesSlipInputAcs_SettingParameter = function(param1:WideString; param2:WideString): Integer; stdcall;
    TxDelphiSalesSlipInputAcs_SettingParameter = function(param1:WideString; param2:WideString; param3:WideString): Integer; stdcall;
// 2011/01/31 <<<
    // SCM情報読込タイマー起動イベントメソッド型
    TxDelphiSalesSlipInputAcs_TimerSCMReadTick = function(var ret: Boolean; var customerCode: Integer): Integer; stdcall;
    // 相場価格情報取得メソッド型
    TxDelphiSalesSlipInputAcs_GetSobaInfo = function(): Integer; stdcall;
    //<<<2010/05/30

    //>>>2010/08/30
    TxDelphiSalesSlipInputAcs_ExistTaxRateRangeMethod = function(salesdate: Integer): Integer; stdcall;
    //<<<2010/08/30

    //>>>2011/02/01
    // SCM情報存在チェックメソッド型
    TxDelphiSalesSlipInputAcs_ExistSCMInfo = function(var ret: Boolean; salesSlipNum:WideString; salesRowNo:Integer): Integer; stdcall;
    //<<<2011/02/01

    //>>>2011/03/04
    // 従業員情報設定メソッド型
    TxDelphiSalesSlipInputAcs_SettingEmpInfo = procedure(); stdcall;
    //<<<2011/03/04

// ------  ADD K2015/04/01 高騁 森川部品個別依頼------->>>>>
    // 全社在庫情報表示メソッド型
    TxDelphiSalesSlipInputAcs_ReadAllSecStockInfo = function(makerCd: Integer;
    goodsNo: WideString;
    goodsName: WideString;
    isOpenPressed: Boolean;
    isClose: Boolean;
    var message: WideString): Integer; stdcall;
    // 森川個別オプション判定メソッド型
    TxDelphiSalesSlipInputAcs_OptPermitForMoriKawa = function(var resultOptPermitForMoriKawa: Boolean): Integer; stdcall;
// ------  ADD K2015/04/01 高騁 森川部品個別依頼-------<<<<<
    // --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- >>>>>
    // ㈱コーエイオプション判定メソッド型
    TxDelphiSalesSlipInputAcs_OptPermitForKoei = function(var resultOptPermitForKoei: Boolean): Integer; stdcall;
    // 売価算出処理メソッド型
    TxDelphiSalesSlipInputAcs_SalesUnPrcCalc = function(salesRowNo: Integer; var salesUnPrice: WideString): Integer; stdcall;
    // --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- <<<<<

    //アクセスクラス仲介DLLロードメソッド
    function LoadLibraryMAHNB01013M(HDllCall1: THDllCall): Integer;

    //アクセスクラス仲介DLLアンロードメソッド
    procedure FreeLibraryMAHNB01013M(HDllCall1: THDllCall);

var
// add by tanh
    // 得意先ガイド処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_Clear: TxDelphiSalesSlipInputAcs_Clear;
    // 伝票区分コンボエディタアイテム設定処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_GetItemtSalesSlipCd: TxDelphiSalesSlipInputAcs_GetItemtSalesSlipCd;
    // 追加情報タブ項目Visible設定関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_GetAddInfoVisible: TxDelphiSalesSlipInputAcs_GetAddInfoVisible;
    // 各種マスタチェック関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_InitMstCheck: TxDelphiSalesSlipInputAcs_InitMstCheck;
    // 伝票区分コンボエディタアイテム設定処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_GetDisplayHeaderFooterInfo: TxDelphiSalesSlipInputAcs_GetDisplayHeaderFooterInfo;
    // 得意先情報画面格納処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_GetDisplayCustomerInfo: TxDelphiSalesSlipInputAcs_GetDisplayCustomerInfo;
    // 明細データ取得関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_SetUserGdBdComboEditor: TxDelphiSalesSlipInputAcs_SetUserGdBdComboEditor;
    // セルEnabled設定取得処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_GetCellEnabled: TxDelphiSalesSlipInputAcs_GetCellEnabled;
    // 元に戻す処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_Retry: TxDelphiSalesSlipInputAcs_Retry;
    // 元に戻す処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_RetryResult: TxDelphiSalesSlipInputAcs_RetryResult;
    // 備考設定処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_GetNoteGuidList: TxDelphiSalesSlipInputAcs_GetNoteGuidList;
    // 終了設定処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_Close: TxDelphiSalesSlipInputAcs_Close;
    // オプション情報処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_FormPosSerialize: TxDelphiSalesSlipInputAcs_FormPosSerialize;
    // オプション情報処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_FormPosDeserialize: TxDelphiSalesSlipInputAcs_FormPosDeserialize;
    // --- ADD 2010/05/31 ---------->>>>>
    // オプション情報処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_uButtonEscClick: TxDelphiSalesSlipInputAcs_uButtonEscClick;
    // --- ADD 2010/05/31 ----------<<<<<
    // --- ADD 2012/05/31 No.282---------->>>>>
    // オプション情報処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_uButtonEscClick2: TxDelphiSalesSlipInputAcs_uButtonEscClick2;
    // オプション情報処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_SaveOrderInfo: TxDelphiSalesSlipInputAcs_SaveOrderInfo;
    // --- ADD 2012/05/31 No.282----------<<<<<
    // オプション情報処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_GetGrossProfitRateFlg: TxDelphiSalesSlipInputAcs_GetGrossProfitRateFlg;
    // ファンクション明細制御取得処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_GetBitButtonCustomizeSetting: TxDelphiSalesSlipInputAcs_GetBitButtonCustomizeSetting;
    // 小数点表示区分処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_SmallPointProc: TxDelphiSalesSlipInputAcs_SmallPointProc;
    // HOMEキー設定処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_SetHomeKeyFlg: TxDelphiSalesSlipInputAcs_SetHomeKeyFlg;
    // end add by tanh

    // 各種起動データ関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_SetInitData: TxDelphiSalesSlipInputAcs_SetInitData;

    // --- ADD 2011/02/12 ---- >>>>>
    // 調査用ログ出力クラス処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_DoAddLine: TxDelphiSalesSlipInputAcs_DoAddLine;
    // 調査用ログImage出力処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_DoCacheImage: TxDelphiSalesSlipInputAcs_DoCacheImage;
    // 各種マスタチェック関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_GetErrorFlag: TxDelphiSalesSlipInputAcs_GetErrorFlag;
    // --- ADD 2011/02/12 ---- <<<<<

    // --- ADD 2011/11/22 ---- >>>>>
    // 連携判断処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_CooprtKindDiv: TxDelphiSalesSlipInputAcs_CooprtKindDiv;
    // --- ADD 2011/11/22 ---- <<<<<


    // --- ADD 2011/04/13 ---- >>>>>
    // 選択済み売上行番号削除処理（多行削除場合用）関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_DetailDeleteActionTable: TxDelphiSalesSlipInputAcs_DetailDeleteActionTable;
    // --- ADD 2011/04/13 ---- <<<<<

    // --- ADD 2011/05/30 ---- >>>>>
    // 画面の拠点コード変化時（キャンペーン情報取得用）関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_SetSectionCode: TxDelphiSalesSlipInputAcs_SetSectionCode;
    // --- ADD 2011/05/30 ---- <<<<<

    // --- ADD 2011/07/18 ---- >>>>>
    // 現在庫数を調整します関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_StockInfoAdjust: TxDelphiSalesSlipInputAcs_StockInfoAdjust;
    // --- ADD 2011/07/18 ---- <<<<<

    // add by zhangkai
    // 行値引き処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_uButtonLineDiscountClick: TxDelphiSalesSlipInputAcs_uButtonLineDiscountClick;
    // 品番検索処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_AfterGoodsNoUpdate: TxDelphiSalesSlipInputAcs_AfterGoodsNoUpdate;
    // 商品値引き処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_uButtonGoodsDiscountClick: TxDelphiSalesSlipInputAcs_uButtonGoodsDiscountClick;
    // 注釈処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_uButtonAnnotationClick: TxDelphiSalesSlipInputAcs_uButtonAnnotationClick;
    // 倉庫切替処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_uButtonChangeWarehouseClick: TxDelphiSalesSlipInputAcs_uButtonChangeWarehouseClick;
    // 在庫検索処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_uButtonStockSearchClick: TxDelphiSalesSlipInputAcs_uButtonStockSearchClick;
    // ＴＢＯ処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_uButtonTBOClick: TxDelphiSalesSlipInputAcs_uButtonTBOClick;
    // 前行複写処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_uButtonCopyStockBefLineClick: TxDelphiSalesSlipInputAcs_uButtonCopyStockBefLineClick;
    // 一括複写処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_uButtonCopyStockAllLineClick: TxDelphiSalesSlipInputAcs_uButtonCopyStockAllLineClick;
    // メモリ解放処理呼び出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_FreeCustomArrayA2: TxDelphiSalesSlipInputAcs_FreeCustomArrayA2;

    // 明細データ取得関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_GetSalesDetailDataTable: TxDelphiSalesSlipInputAcs_GetSalesDetailDataTable;
    // グリッドセルアップデート後処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_uGridDetailsAfterCellUpdate: TxDelphiSalesSlipInputAcs_uGridDetailsAfterCellUpdate;
    // グリッドセルアップデート後処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_uGridDetailsAfterCellUpdateProc: TxDelphiSalesSlipInputAcs_uGridDetailsAfterCellUpdateProc;
    // ガイドボタンクリックイベント処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_uButtonGuideClick: TxDelphiSalesSlipInputAcs_uButtonGuideClick;

    // 移動位置取得処理(Enterキー移動時)関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_GetNextMovePosition: TxDelphiSalesSlipInputAcs_GetNextMovePosition;
    // --- ADD 2010/06/02 ---------->>>>>
    // 移動位置取得処理(Enterキー移動時)関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_GetPreMovePosition: TxDelphiSalesSlipInputAcs_GetPreMovePosition;
    // --- ADD 2010/06/02 ----------<<<<<
    // Param取得処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_GetParam: TxDelphiSalesSlipInputAcs_GetParam;
    // フォーカス移動対象判定処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_GetEffectiveJudgment: TxDelphiSalesSlipInputAcs_GetEffectiveJudgment;
    // 明細データ取得関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_GetSalesAllDetailDataTable: TxDelphiSalesSlipInputAcs_GetSalesAllDetailDataTable;
    // 設定処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_SetSalesDetailData: TxDelphiSalesSlipInputAcs_SetSalesDetailData;
    // グリッド関連チェック処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_GridJoinCheck: TxDelphiSalesSlipInputAcs_GridJoinCheck;
    // Table処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_DeatilActionTable: TxDelphiSalesSlipInputAcs_DeatilActionTable;
    // 得意先注番のフォーカス処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_AfterPartySaleSlipNumFocus: TxDelphiSalesSlipInputAcs_AfterPartySaleSlipNumFocus;
    // チェック処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_CheckDetailAction: TxDelphiSalesSlipInputAcs_CheckDetailAction;
    // ユーザー設定処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_GetSalesSlipInputConstructionData: TxDelphiSalesSlipInputAcs_GetSalesSlipInputConstructionData;
    // 伝票メモ情報設定処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_SetSlipMemo: TxDelphiSalesSlipInputAcs_SetSlipMemo;
    // 数値入力チェック処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_KeyPressNumCheck: TxDelphiSalesSlipInputAcs_KeyPressNumCheck;
    // CSV出力先が設定され、フォルダが存在しているかチェック処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_CsvPassCheck: TxDelphiSalesSlipInputAcs_CsvPassCheck;    // メモリ解放処理呼び出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_FreeUserGdHd: TxDelphiSalesSlipInputAcs_FreeUserGdHd;
    // メモリ解放処理呼び出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_FreeUserGdBd: TxDelphiSalesSlipInputAcs_FreeUserGdBd;
    // end add by zhangkai

// add by yangmj
    // 出荷計上処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_ShipmentAddUp: TxDelphiSalesSlipInputAcs_ShipmentAddUp;
    // 出荷照会ボタンクリック処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_GetSalesHisGuide: TxDelphiSalesSlipInputAcs_GetSalesHisGuide;
    // メモリ解放処理呼び出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_FreeSalesSlip: TxDelphiSalesSlipInputAcs_FreeSalesSlip;
    // 受注照会(明細選択)関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_AcceptAnOrderReferenceSearch: TxDelphiSalesSlipInputAcs_AcceptAnOrderReferenceSearch;
    // 受注計上処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_AcceptAnOrderAddup: TxDelphiSalesSlipInputAcs_AcceptAnOrderAddup;
    // 見積計上(明細選択)関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_EstimateReferenceSearch: TxDelphiSalesSlipInputAcs_EstimateReferenceSearch;
    // 見積照会(伝票選択)関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_EstimateAddup: TxDelphiSalesSlipInputAcs_EstimateAddup;
    // 履歴照会(売上履歴データから明細選択) 関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_SalesReferenceSearch: TxDelphiSalesSlipInputAcs_SalesReferenceSearch;
    // 伝票複写関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_CopySlip: TxDelphiSalesSlipInputAcs_CopySlip;
    // 車両管理オプション取得処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_GetOptCarMng: TxDelphiSalesSlipInputAcs_GetOptCarMng;
    // 伝票備考、伝票備考２、伝票備考３の入力桁数設定処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_SetNoteCharCnt: TxDelphiSalesSlipInputAcs_SetNoteCharCnt;
    // 返品処理関係関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_ReturnSlip: TxDelphiSalesSlipInputAcs_ReturnSlip;
    // 保存確認ダイアログ表示処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_ShowSaveCheckDialog: TxDelphiSalesSlipInputAcs_ShowSaveCheckDialog;
    // 保存処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_Save: TxDelphiSalesSlipInputAcs_Save;
    // 保存後処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_AfterSave: TxDelphiSalesSlipInputAcs_AfterSave;
    // 保存状態取得関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_GetSaveStatus: TxDelphiSalesSlipInputAcs_GetSaveStatus;
    // --- ADD 2015/12/09 T.Miyamoto リモ伝障害対応 Redmine#47670 ---------->>>>>
    // オンライン種別取得関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_GetOnlineKindDiv: TxDelphiSalesSlipInputAcs_GetOnlineKindDiv;
    // --- ADD 2015/12/09 T.Miyamoto リモ伝障害対応 Redmine#47670 ----------<<<<<
    // 部品検索切替処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_ChangeSearchMode: TxDelphiSalesSlipInputAcs_ChangeSearchMode;
    // 部品検索モード取得関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_GetSearchPartsModeProperty: TxDelphiSalesSlipInputAcs_GetSearchPartsModeProperty;
    //----ADD 2010/06/17----->>>>>
    // 売上データ設定関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_SetSalesSlip: TxDelphiSalesSlipInputAcs_SetSalesSlip;
    //----ADD 2010/06/17-----<<<<<
    //----ADD 2010/11/02----->>>>>
    gpxDelphiSalesSlipInputAcs_SetSalesSlipByObj: TxDelphiSalesSlipInputAcs_SetSalesSlipByObj;
    //----ADD 2010/11/02-----<<<<<

// end add by yangmj
    // --- ADD 黄興貴 2015/04/29 回答取込パタン追加 ---------------->>>>>
    // UOEデータ取込関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_ReadUoeData: TxDelphiSalesSlipInputAcs_ReadUoeData;
    // 富士ジーワイ商事㈱オプション判定関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_OptPermitForFuJi: TxDelphiSalesSlipInputAcs_OptPermitForFuJi;
    // --- ADD 黄興貴 2015/04/29 回答取込パタン追加 ----------------<<<<<

  // --- ADD 紀飛 2015/06/18 WebUOE発注回答取込 ---------------->>>>>
  // ㈱メイゴオプション判定関数呼出し用ポインタ変数
  gpxDelphiSalesSlipInputAcs_OptPermitForMeiGo:
    TxDelphiSalesSlipInputAcs_OptPermitForMeiGo;
  // --- ADD 紀飛 2015/06/18 WebUOE発注回答取込 ----------------<<<<<
  // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応--->>>>>
  //  電子帳簿連携オプション判定関数呼出し用ポインタ変数
  gpxDelphiSalesSlipInputAcs_OptPermitForEBooks:
    TxDelphiSalesSlipInputAcs_OptPermitForEBooks;
  // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応---<<<<<
// add by gaofeng start

// 初期データをＤＢより取得の処理関数呼出し用ポインタ変数
    gpxDelphiGetSalesSlipInputInitDataAcs_GetInitData: TxDelphiGetSalesSlipInputInitDataAcs_GetInitData;
    // 返品理由ガイド処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_retGoodsReason: TxDelphiSalesSlipInputAcs_retGoodsReason;
    //文字列解放処理呼び出し用ポインタ変数
    gpxDelphiGetSalesSlipInputInitDataAcs_FreeMessage: TxDelphiGetSalesSlipInputInitDataAcs_FreeMessage;
    gpxDelphiSalesSlipInputAcs_salesSlipGuide: TxDelphiSalesSlipInputAcs_salesSlipGuide;
    gpxDelphiSalesSlipInputAcs_FreeSalesSlipSearchResult: TxDelphiSalesSlipInputAcs_FreeSalesSlipSearchResult;
    gpxDelphiSalesSlipInputAcs_customerGuide: TxDelphiSalesSlipInputAcs_customerGuide;
    gpxDelphiSalesSlipInputAcs_FreeCustomerSearchRet: TxDelphiSalesSlipInputAcs_FreeCustomerSearchRet;
    gpxDelphiSalesSlipInputAcs_ShowSalesSlipInputSetup: TxDelphiSalesSlipInputAcs_ShowSalesSlipInputSetup;
    // 画面項目名称取得処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_GetDisplayName: TxDelphiSalesSlipInputAcs_GetDisplayName;
    // 明細粗利率取得処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_GetDetailGrossProfitRate: TxDelphiSalesSlipInputAcs_GetDetailGrossProfitRate;
    // 伝票削除処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_Delete: TxDelphiSalesSlipInputAcs_Delete;
    // アイテム名の取得処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_GetItemName: TxDelphiSalesSlipInputAcs_GetItemName;
    gpxDelphiSalesSlipInputAcs_GetStatus: TxDelphiSalesSlipInputAcs_GetStatus;
    gpxDelphiSalesSlipInputAcs_GetBeforeSalesSlipNumText: TxDelphiSalesSlipInputAcs_GetBeforeSalesSlipNumText;
    // フォーカス位置の取得処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_GetFocusPositionValue: TxDelphiSalesSlipInputAcs_GetFocusPositionValue;
    // 赤伝処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_RedSlip: TxDelphiSalesSlipInputAcs_RedSlip;
    // 赤伝できるかどうかフラグの取得処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_GetCanRed: TxDelphiSalesSlipInputAcs_GetCanRed;
    gpxDelphiSalesSlipInputAcs_GetRedDialogResult: TxDelphiSalesSlipInputAcs_GetRedDialogResult;
    gpxDelphiSalesSlipInputAcs_CopySlipHeader: TxDelphiSalesSlipInputAcs_CopySlipHeader;
    gpxDelphiSalesSlipInputAcs_CopySlipDetail: TxDelphiSalesSlipInputAcs_CopySlipDetail;  // ADD 連番729 2011/08/18
    // 管理番号ガイド表示後の処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_AfterCarMngNoGuideReturn: TxDelphiSalesSlipInputAcs_AfterCarMngNoGuideReturn;
    gpxDelphiSalesSlipInputAcs_setToolMenuCustomizeSetting: TxDelphiSalesSlipInputAcs_setToolMenuCustomizeSetting;
    gpxDelphiSalesSlipInputAcs_getToolMenuCustomizeSetting: TxDelphiSalesSlipInputAcs_getToolMenuCustomizeSetting;
    gpxDelphiSalesSlipInputAcs_setToolButtonCustomizeSetting: TxDelphiSalesSlipInputAcs_setToolButtonCustomizeSetting;
    gpxDelphiSalesSlipInputAcs_getToolButtonCustomizeSetting: TxDelphiSalesSlipInputAcs_getToolButtonCustomizeSetting;
    gpxDelphiSalesSlipInputAcs_SaveToolbarCustomizeSetting: TxDelphiSalesSlipInputAcs_SaveToolbarCustomizeSetting;
    gpxDelphiSalesSlipInputAcs_SaveToolManagerCustomizeInfo: TxDelphiSalesSlipInputAcs_SaveToolManagerCustomizeInfo;
    gpxDelphiSalesSlipInputAcs_SaveCustomizeXml: TxDelphiSalesSlipInputAcs_SaveCustomizeXml;
    gpxDelphiSalesSlipInputAcs_GetUltraOptionSetValue: TxDelphiSalesSlipInputAcs_GetUltraOptionSetValue;
    gpxDelphiSalesSlipInputAcs_SlipNoteGuide: TxDelphiSalesSlipInputAcs_SlipNoteGuide;
    // 売上金額変更後発生イベント処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_SalesPriceChanged: TxDelphiSalesSlipInputAcs_SalesPriceChanged;
    // 車両情報設定処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_CarInfoFormSetting: TxDelphiSalesSlipInputAcs_CarInfoFormSetting;
    // 保存確認ダイアログ表示処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_ShowRedSaveCheckDialog: TxDelphiSalesSlipInputAcs_ShowRedSaveCheckDialog;
    // SetItemsDictionary関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_SetItemsDictionary: TxDelphiSalesSlipInputAcs_SetItemsDictionary;
    // setColDisplayStatusList関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_setColDisplayStatusList: TxDelphiSalesSlipInputAcs_setColDisplayStatusList;

    // --- ADD 2010/06/02 ---------->>>>>
    // GetReadSlipFlg関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_GetReadSlipFlg: TxDelphiSalesSlipInputAcs_GetReadSlipFlg;
    // --- ADD 2010/06/02----------<<<<<

    // --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ---------->>>>>
    //第二売価ガイドの位置を設定します。
    gpxDelphiSalesSlipInputAcs_SetSecondSalesUnPrcGideLocation: TxDelphiSalesSlipInputAcs_SetSecondSalesUnPrcGideLocation;
    //水野商工㈱オプション判定関数定義。
    gpxDelphiSalesSlipInputAcs_OptPermitForMizuno2ndSellPriceCtl: TxDelphiSalesSlipInputAcs_OptPermitForMizuno2ndSellPriceCtl;
    // --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ----------<<<<<

    // 保存用設定処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_SetAfterSaveData: TxDelphiSalesSlipInputAcs_SetAfterSaveData;
    gpxDelphiSalesSlipInputAcs_GetAfterSaveData: TxDelphiSalesSlipInputAcs_GetAfterSaveData;
    gpxDelphiSalesSlipInputAcs_DoAfterSave: TxDelphiSalesSlipInputAcs_DoAfterSave;

    // --- ADD 2012/10/15 ---------->>>>>
    // 仕入日のエラーメッセージを表示処理
    gpxDelphiSalesSlipInputAcs_ShowStockDateMsg: TxDelphiSalesSlipInputAcs_ShowStockDateMsg;
    // --- ADD 2012/10/15 ----------<<<<<

    // --- ADD 2010/07/08 ---------->>>>>
    // 操作権限の制御関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_BeginControllingByOperationAuthority: TxDelphiSalesSlipInputAcs_BeginControllingByOperationAuthority;
    // --- ADD 2010/07/08 ----------<<<<<
// add by gaofeng end

    // --- ADD 2014/07/15 T.Miyamoto 仕掛一覧 №1912 ---------->>>>>
    // 操作権限の判定関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_GetOperationSt: TxDelphiSalesSlipInputAcs_GetOperationSt;
    // --- ADD 2014/07/15 T.Miyamoto 仕掛一覧 №1912 ----------<<<<<

// add by lizc begin
// 最新情報処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_ReNewalBtnClick: TxDelphiSalesSlipInputAcs_ReNewalBtnClick;
    // xxxxx関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_ProcessingDialogDispose: TxDelphiSalesSlipInputAcs_ProcessingDialogDispose;
// add by lizc end

    //文字列解放処理呼び出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_FreeMessage: TxDelphiSalesSlipInputAcs_FreeMessage;
    // --- ADD m.suzuki 2010/06/12 ---------->>>>>
    gpxDelphiSalesSlipInputAcs_MakeQR: TxDelphiSalesSlipInputAcs_MakeQR;
    // --- ADD m.suzuki 2010/06/12 ----------<<<<<
    // --- ADD m.suzuki 2010/06/16 ---------->>>>>
    gpxDelphiSalesSlipInputAcs_GetOnlineFlag: TxDelphiSalesSlipInputAcs_GetOnlineFlag;
    // --- ADD m.suzuki 2010/06/16 ----------<<<<<

    DataModule1: TDataModule1;

    //>>>2010/05/30
    // SCM問合せ一覧起動処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_ReferenceList: TxDelphiSalesSlipInputAcs_ReferenceList;
    //----- ADD　2018/09/04 譚洪　履歴自動表示の対応------->>>>>
    // 履歴検索選択関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_HisSearch: TxDelphiSalesSlipInputAcs_HisSearch;
    //----- ADD　2018/09/04 譚洪　履歴自動表示の対応-------<<<<<
    //----- ADD　譚洪 2020/02/24 PMKOBETSU-2912の対応------->>>>>
    // 税率入力関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_GetTaxRate: TxDelphiSalesSlipInputAcs_GetTaxRate;
    gpxDelphiSalesSlipInputAcs_GetTaxRateDialogResult: TxDelphiSalesSlipInputAcs_GetTaxRateDialogResult;
    gpxDelphiSalesSlipInputAcs_OrderCheck: TxDelphiSalesSlipInputAcs_OrderCheck;
    //----- ADD　譚洪 2020/02/24 PMKOBETSU-2912の対応-------<<<<<
    // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応 ----->>>>>
    // 電帳起動関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_StartEBooks: TxDelphiSalesSlipInputAcs_StartEBooks;
    // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応 -----<<<<<
    // 起動パラメータ設定関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_SettingParameter: TxDelphiSalesSlipInputAcs_SettingParameter;
    // SCM情報読込タイマー起動イベント処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_TimerSCMReadTick: TxDelphiSalesSlipInputAcs_TimerSCMReadTick;
    // 相場価格情報取得処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_GetSobaInfo: TxDelphiSalesSlipInputAcs_GetSobaInfo;
    //<<<2010/05/30

    //>>>2010/08/30
    // 税率設定範囲チェック処理関数呼び出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_ExistTaxRateRangeMethod: TxDelphiSalesSlipInputAcs_ExistTaxRateRangeMethod;
    //<<<2010/08/30

    //>>>2011/02/01
    // SCM情報存在チェック処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_ExistSCMInfo: TxDelphiSalesSlipInputAcs_ExistSCMInfo;
    //<<<2011/02/01

    //>>>2011/03/04
    // 従業員情報設定関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_SettingEmpInfo: TxDelphiSalesSlipInputAcs_SettingEmpInfo;
    //<<<2011/03/04
    // ------  ADD K2015/04/01 高騁 森川部品個別依頼------->>>>>
    // 全社在庫情報表示関数呼び出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_ReadAllSecStockInfo: TxDelphiSalesSlipInputAcs_ReadAllSecStockInfo;
    // 森川個別オプション判定関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_OptPermitForMoriKawa: TxDelphiSalesSlipInputAcs_OptPermitForMoriKawa;
    // ------  ADD K2015/04/01 高騁 森川部品個別依頼-------<<<<<
    // --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- >>>>>
    // 売価算出処理関数呼出し用ポインタ変数
    gpxDelphiSalesSlipInputAcs_SalesUnPrcCalc: TxDelphiSalesSlipInputAcs_SalesUnPrcCalc;
    gpxDelphiSalesSlipInputAcs_OptPermitForKoei: TxDelphiSalesSlipInputAcs_OptPermitForKoei;
    // --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- <<<<<

implementation

{$R *.dfm}

// 得意先アクセスクラス仲介DLLロード処理
function LoadLibraryMAHNB01013M(HDllCall1: THDllCall): Integer;
var
    nSt: Integer;
begin
    Result := 4;
    HDllCall1.DllName := 'MAHNB01013M.DLL';
    nSt := HDllCall1.HLoadLibrary;

    // DLLロード
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '得意先部品',
            'LoadLibraryMAHNB01013M', 'LOADLIBRARY', '得意先部品のロードに失敗しました',
            nSt, nil, 0);
        Exit;
    end;

    // 明細データ取得関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetSalesAllDetailDataTable';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetSalesAllDetailDataTable);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '品番検索部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '品番検索部品明細データ取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // HOMEキー設定処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_SetHomeKeyFlg';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_SetHomeKeyFlg);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '得意先部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '得意先部品HOMEキー設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 行値引き処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_uButtonLineDiscountClick';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_uButtonLineDiscountClick);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '行値引',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '行値引処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 商品値引き処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_uButtonGoodsDiscountClick';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_uButtonGoodsDiscountClick);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '商品値引き処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '商品値引き処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // --- ADD 2011/02/12 ---- >>>>>
    // 調査用ログ出力クラス処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_DoAddLine';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_DoAddLine);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '調査用ログ出力',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '調査用ログ出力クラス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 調査用ログImage出力処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_DoCacheImage';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_DoCacheImage);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '調査用ログImage出力',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '調査用ログImage出力処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 各種マスタチェック関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetErrorFlag';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetErrorFlag);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'エラーフラグ',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'エラーフラグ関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2011/02/12 ---- <<<<<

    // --- ADD 2011/11/22 ---- >>>>>
    // 連携判断処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_CooprtKindDiv';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_CooprtKindDiv);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '連携判断',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '連携判断処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2011/11/22 ---- <<<<<

    // --- ADD 2011/04/13 ---- >>>>>
    // 選択済み売上行番号削除処理（多行削除場合用）関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_DetailDeleteActionTable';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_DetailDeleteActionTable);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '多行削除',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '選択済み売上行番号削除処理（多行削除場合用）関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2011/04/13 ---- <<<<<

    // --- ADD 2011/05/30 ---- >>>>>
    // 画面の拠点コード変化時（キャンペーン情報取得用）関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_SetSectionCode';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_SetSectionCode);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '拠点コード変化',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '画面の拠点コード変化時（キャンペーン情報取得用）関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2011/05/30 ---- <<<<<

    // --- ADD 2011/07/18 ---- >>>>>
    // 現在庫数を調整します関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_StockInfoAdjust';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_StockInfoAdjust);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '現在庫数調整',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '現在庫数を調整します関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2011/07/18 ---- <<<<<
    // --- ADD 黄興貴 2015/04/29 回答取込パタン追加 ---------------->>>>>
    // UOEデータ取込関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_ReadUoeData';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_ReadUoeData);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'UOEデータ取込',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'UOEデータ取込関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_OptPermitForFuJi';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_OptPermitForFuJi);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'UOEデータ取込',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '富士ジーワイ商事㈱オプション判定関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 黄興貴 2015/04/29 回答取込パタン追加 ----------------<<<<<

// --- ADD 紀飛 2015/06/18 WebUOE発注回答取込 ---------------->>>>>
  HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_OptPermitForMeiGo';
  nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_OptPermitForMeiGo);
  if nSt <> 0 then
  begin
    HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'UOEデータ取込',
      'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
      '㈱メイゴオプション判定関数のアドレス取得に失敗しました', nSt, nil, 0);
    Exit;
  end;
  // --- ADD 紀飛 2015/06/18 WebUOE発注回答取込 ----------------<<<<<
      // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応--->>>>>
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_OptPermitForEBooks';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_OptPermitForEBooks);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '電子帳簿',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '電子帳簿連携オプション判定関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応---<<<<<

    // 注釈処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_uButtonAnnotationClick';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_uButtonAnnotationClick);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '注釈処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '注釈処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 倉庫切替処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_uButtonChangeWarehouseClick';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_uButtonChangeWarehouseClick);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '倉庫切替処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '倉庫切替処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ---------->>>>>
    //第二売価ガイドの位置を設定します。
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_SetSecondSalesUnPrcGideLocation';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_SetSecondSalesUnPrcGideLocation);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '売伝画面設定用',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '売伝画面第二売価ガイドの位置設定用処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //水野商工㈱オプション判定関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_OptPermitForMizuno2ndSellPriceCtl';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_OptPermitForMizuno2ndSellPriceCtl);
    if nSt <> 0 then
    begin
      HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '水野商工㈱オプション判定',
        'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
        '水野商工㈱オプション判定関数のアドレス取得に失敗しました', nSt, nil, 0);
      Exit;
    end;
    // --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ----------<<<<<

    // 保存用設定処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_SetAfterSaveData';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_SetAfterSaveData);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '売伝画面保存用',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '売伝画面保存用設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 保存用設定処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetAfterSaveData';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetAfterSaveData);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '売伝画面保存用',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '売伝画面保存用設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 保存用設定処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_DoAfterSave';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_DoAfterSave);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '売伝画面保存用',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '売伝画面保存用設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // --- ADD 2012/10/15 ---------->>>>>
    // 仕入日のエラーメッセージを表示処理
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_ShowStockDateMsg';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_ShowStockDateMsg);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '売伝画面仕入日メッセージ用',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '売伝画面仕入日メッセージ用処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2012/10/15 ----------<<<<<

    // 在庫検索処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_uButtonStockSearchClick';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_uButtonStockSearchClick);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '在庫検索',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '在庫検索処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // ＴＢＯ処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_uButtonTBOClick';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_uButtonTBOClick);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'ＴＢＯ処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'ＴＢＯ処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 前行複写処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_uButtonCopyStockBefLineClick';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_uButtonCopyStockBefLineClick);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '前行複写処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '前行複写処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 一括複写処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_uButtonCopyStockAllLineClick';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_uButtonCopyStockAllLineClick);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '一括複写処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '一括複写処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // グリッド関連チェック処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GridJoinCheck';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GridJoinCheck);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'グリッド関連チェック処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'グリッド関連チェック処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // Table処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_DeatilActionTable';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_DeatilActionTable);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'Table処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'Table処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 得意先注番のフォーカス処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_AfterPartySaleSlipNumFocus';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_AfterPartySaleSlipNumFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '得意先注番',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '得意先注番のフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // add by tanh
    // --- ADD 2010/05/31 ---------->>>>>
    // ESC処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_uButtonEscClick';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_uButtonEscClick);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'ESC処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'ESC処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2010/05/31 ----------<<<<<
    // --- ADD 2012/05/31 No.282---------->>>>>
    // ESC処理関数2（発注解除）アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_uButtonEscClick2';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_uButtonEscClick2);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'ESC処理2',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'ESC処理関数2のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // 発注退避関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_SaveOrderInfo';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_SaveOrderInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '発注退避処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '発注退避処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2012/05/31 No.282----------<<<<<
    // 得意先ガイド処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_Clear';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_Clear);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '得意先部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '得意先部品得意先ガイド処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // フォーム情報処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_FormPosDeserialize';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_FormPosDeserialize);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'フォーム',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'フォーム情報処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 終了設定処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_Close';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_Close);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '得意先部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '得意先部品終了設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 伝票区分コンボエディタアイテム設定処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetItemtSalesSlipCd';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetItemtSalesSlipCd);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '得意先部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '得意先部品伝票区分コンボエディタアイテム設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 各種マスタチェック関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_InitMstCheck';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_InitMstCheck);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '車種部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '車種部品各種マスタチェック関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 得意先情報画面格納処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetDisplayCustomerInfo';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetDisplayCustomerInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '車種部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '車種部品得意先情報画面格納処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 追加情報タブ項目Visible設定関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetAddInfoVisible';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetAddInfoVisible);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '得意先部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '得意先部品追加情報タブ項目Visible設定関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 伝票区分コンボエディタアイテム設定処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetDisplayHeaderFooterInfo';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetDisplayHeaderFooterInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '得意先部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '得意先部品伝票区分コンボエディタアイテム設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // 明細データ取得関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_SetUserGdBdComboEditor';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_SetUserGdBdComboEditor);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '品番検索部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '品番検索部品明細データ取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // セルEnabled設定取得処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetCellEnabled';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetCellEnabled);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012B', '品番検索部品',
            'LoadLibraryMAHNB01012M', 'GETPROCADDRESS',
            '品番検索部品セルEnabled設定取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // 元に戻す処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_Retry';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_Retry);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '車種部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '車種部品元に戻す処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 元に戻す処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_RetryResult';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_RetryResult);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '車種部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '車種部品元に戻す処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // ファンクション明細制御取得処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetBitButtonCustomizeSetting';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetBitButtonCustomizeSetting);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '得意先部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'ファンクション明細制御取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // データ解放関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_FreeUserGdHd';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_FreeUserGdHd);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '返品理由部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '返品理由部品メモリ解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // データ解放関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_FreeUserGdBd';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_FreeUserGdBd);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '返品理由部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '返品理由部品メモリ解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // end add by tanh

    // add by zhangkai

    // 品番検索処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_AfterGoodsNoUpdate';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_AfterGoodsNoUpdate);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '品番検索部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '品番検索部品品番検索処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // ガイドボタンクリックイベント処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_uButtonGuideClick';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_uButtonGuideClick);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '品番検索部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '品番検索部品ガイドボタンクリックイベント処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 移動位置取得処理(Enterキー移動時)関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetNextMovePosition';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetNextMovePosition);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '品番検索部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '品番検索部品移動位置取得処理(Enterキー移動時)関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // --- ADD 2010/06/02 ---------->>>>>
    // 移動位置取得処理(Enterキー移動時)関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetPreMovePosition';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetPreMovePosition);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '品番検索部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '品番検索部品移動位置取得処理(Enterキー移動時)関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2010/06/02 ----------<<<<<

    // フォーム情報処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_FormPosSerialize';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_FormPosSerialize);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '車種部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'フォーム情報処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // Param取得処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetParam';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetParam);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '品番検索部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '品番検索部品Param取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // フォーカス移動対象判定処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetEffectiveJudgment';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetEffectiveJudgment);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '品番検索部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '品番検索部品フォーカス移動対象判定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 明細データ取得関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetSalesDetailDataTable';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetSalesDetailDataTable);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '品番検索部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '品番検索部品明細データ取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 設定処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_SetSalesDetailData';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_SetSalesDetailData);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '品番検索部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '品番検索部品設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // グリッドセルアップデート後処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_uGridDetailsAfterCellUpdate';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_uGridDetailsAfterCellUpdate);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'グリッドセルアップデート後処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'グリッドセルアップデート後処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // グリッドセルアップデート後処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_uGridDetailsAfterCellUpdateProc';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_uGridDetailsAfterCellUpdateProc);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'グリッドセルアップデート後処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'グリッドセルアップデート後処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // チェック処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_CheckDetailAction';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_CheckDetailAction);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'チェック処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'チェック処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // ユーザー設定処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetSalesSlipInputConstructionData';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetSalesSlipInputConstructionData);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'ユーザー設定',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'ユーザー設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // end add by zhangkai

// add by yangmj
    // 出荷計上処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_ShipmentAddUp';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_ShipmentAddUp);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '出荷照会部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '出荷照会部品出荷計上処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 出荷照会ボタンクリック処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetSalesHisGuide';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetSalesHisGuide);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '出荷照会部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '出荷照会部品出荷照会ボタンクリック処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // データ解放関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_FreeSalesSlip';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_FreeSalesSlip);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '出荷照会部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '出荷照会部品メモリ解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 備考設定処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetNoteGuidList';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetNoteGuidList);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '得意先部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '得意先部品備考設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 受注照会(明細選択)関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_AcceptAnOrderReferenceSearch';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_AcceptAnOrderReferenceSearch);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '出荷照会部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '出荷照会部品受注照会(明細選択)関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 受注計上処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_AcceptAnOrderAddup';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_AcceptAnOrderAddup);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '出荷照会部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '出荷照会部品受注計上処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 見積計上(明細選択)関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_EstimateReferenceSearch';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_EstimateReferenceSearch);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '出荷照会部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '出荷照会部品見積計上(明細選択)関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 各種起動データ関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_SetInitData';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_SetInitData);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '起動データ',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '各種起動データ関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 見積照会(伝票選択)関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_EstimateAddup';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_EstimateAddup);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '出荷照会部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '出荷照会部品見積照会(伝票選択)関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 履歴照会(売上履歴データから明細選択) 関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_SalesReferenceSearch';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_SalesReferenceSearch);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '出荷照会部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '出荷照会部品履歴照会(売上履歴データから明細選択) 関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 小数点表示区分処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_SmallPointProc';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_SmallPointProc);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '小数点表示区分',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '小数点表示区分処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 伝票複写関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_CopySlip';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_CopySlip);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '出荷照会部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '出荷照会部品伝票複写関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 車両管理オプション取得処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetOptCarMng';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetOptCarMng);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '出荷照会部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '出荷照会部品車両管理オプション取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 伝票備考、伝票備考２、伝票備考３の入力桁数設定処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_SetNoteCharCnt';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_SetNoteCharCnt);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '出荷照会部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '出荷照会部品伝票備考、伝票備考２、伝票備考３の入力桁数設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 返品処理関係関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_ReturnSlip';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_ReturnSlip);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '出荷照会部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '出荷照会部品返品処理関係関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 保存確認ダイアログ表示処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_ShowSaveCheckDialog';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_ShowSaveCheckDialog);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '出荷照会部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '出荷照会部品保存確認ダイアログ表示処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // オプション情報処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetGrossProfitRateFlg';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetGrossProfitRateFlg);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '車種部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '車種部品オプション情報処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 保存処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_Save';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_Save);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '出荷照会部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '出荷照会部品保存処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;


    // 保存後処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_AfterSave';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_AfterSave);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '出荷照会部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '出荷照会部品保存後処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 保存状態取得関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetSaveStatus';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetSaveStatus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '出荷照会部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '出荷照会部品保存状態取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // --- ADD 2015/12/09 T.Miyamoto リモ伝障害対応 Redmine#47670 ---------->>>>>
    // オンライン種別取得関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetOnlineKindDiv';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetOnlineKindDiv);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '出荷照会部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '出荷照会部品オンライン種別取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2015/12/09 T.Miyamoto リモ伝障害対応 Redmine#47670 ----------<<<<<

    // 部品検索切替処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_ChangeSearchMode';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_ChangeSearchMode);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '出荷照会部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '出荷照会部品部品検索切替処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 部品検索モード取得関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetSearchPartsModeProperty';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetSearchPartsModeProperty);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '出荷照会部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '出荷照会部品部品検索モード取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //----ADD 2010/06/17----->>>>>
    // 売上データ設定関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_SetSalesSlip';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_SetSalesSlip);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '出荷照会部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '出荷照会部品売上データ設定関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    //----ADD 2010/06/17-----<<<<<
// end add by yangmj

    //----ADD 2010/11/02----->>>>>
    // 売上データ設定関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_SetSalesSlipByObj';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_SetSalesSlipByObj);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '出荷照会部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '出荷照会部品売上データ設定関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    //----ADD 2010/11/02-----<<<<<

    // データ解放関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_FreeCustomArrayA2';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_FreeCustomArrayA2);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '品番検索部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '品番検索部品メモリ解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

// add by gaofeng start

    // 初期データをＤＢより取得の処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiGetSalesSlipInputInitDataAcs_GetInitData';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiGetSalesSlipInputInitDataAcs_GetInitData);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '初期データをＤＢより取得',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '初期データをＤＢより取得の処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //文字列解放関数アドレス取得
    HDllCall1.ProcName := 'DelphiGetSalesSlipInputInitDataAcs_FreeMessage';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiGetSalesSlipInputInitDataAcs_FreeMessage);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '初期データ取得操作文字列解放',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '初期データ取得操作文字列解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 売上伝票ガイド処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_salesSlipGuide';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_salesSlipGuide);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '売上伝票ガイド',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '売上伝票ガイド処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 得意先ガイド処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_customerGuide';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_customerGuide);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '得意先ガイド',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '得意先ガイド処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // データ解放関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_FreeCustomerSearchRet';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_FreeCustomerSearchRet);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'メモリ解放',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'メモリ解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 伝票メモ情報設定処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_SetSlipMemo';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_SetSlipMemo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '品番検索部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '品番検索部品伝票メモ情報設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 数値入力チェック処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_KeyPressNumCheck';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_KeyPressNumCheck);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '品番検索部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '品番検索部品数値入力チェック処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // CSV出力先が設定され、フォルダが存在しているかチェック処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_CsvPassCheck';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_CsvPassCheck);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '品番検索部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '品番検索部品CSV出力先が設定され、フォルダが存在しているかチェック処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 設定処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_ShowSalesSlipInputSetup';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_ShowSalesSlipInputSetup);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '設定処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 画面項目名称取得処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetDisplayName';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetDisplayName);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '画面項目名称取得処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '画面項目名称取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 明細粗利率取得処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetDetailGrossProfitRate';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetDetailGrossProfitRate);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '明細粗利率取得処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '明細粗利率取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 削除処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_Delete';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_Delete);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '削除処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '削除処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // アイテム名の取得処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetItemName';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetItemName);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'アイテム名の取得処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'アイテム名の取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // アイテム名の取得処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetStatus';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetStatus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '状態の取得処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '状態の取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // アイテム名の取得処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetBeforeSalesSlipNumText';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetBeforeSalesSlipNumText);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '名称の取得処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '名称の取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // フォーカス位置の取得処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetFocusPositionValue';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetFocusPositionValue);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'フォーカス位置の取得処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'フォーカス位置の取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 赤伝処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_RedSlip';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_RedSlip);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '赤伝処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '赤伝処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 返品理由ガイド処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_retGoodsReason';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_retGoodsReason);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '返品理由部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '返品理由部品返品理由ガイド処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 赤伝できるかどうかフラグの取得処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetCanRed';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetCanRed);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '赤伝できるかどうかフラグの取得処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '赤伝できるかどうかフラグの取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetRedDialogResult';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetRedDialogResult);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'ダイアログの取得処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'ダイアログの取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 見出貼付関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_CopySlipHeader';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_CopySlipHeader);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '見出貼付',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '見出貼付関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

//-------------- ADD 連番729 2011/08/18 ----------------->>>>>
    // 詳細貼付関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_CopySlipDetail';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_CopySlipDetail);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '詳細貼付',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '詳細貼付関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
//-------------- ADD 連番729 2011/08/18 -----------------<<<<<

    // 管理番号ガイド表示後の処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_AfterCarMngNoGuideReturn';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_AfterCarMngNoGuideReturn);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '管理番号ガイド表示後',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '管理番号ガイド表示後の処理のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // xxxx関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_setToolMenuCustomizeSetting';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_setToolMenuCustomizeSetting);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'setToolMenuCustomizeSetting',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'setToolMenuCustomizeSetting関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // xxxx関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_getToolMenuCustomizeSetting';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_getToolMenuCustomizeSetting);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'getToolMenuCustomizeSetting',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'getToolMenuCustomizeSetting関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // xxxx関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_setToolButtonCustomizeSetting';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_setToolButtonCustomizeSetting);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'setToolButtonCustomizeSetting',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'setToolButtonCustomizeSetting関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // xxxx関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_getToolButtonCustomizeSetting';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_getToolButtonCustomizeSetting);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'getToolButtonCustomizeSetting',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'getToolButtonCustomizeSetting関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // SaveToolbarCustomizeSetting関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_SaveToolbarCustomizeSetting';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_SaveToolbarCustomizeSetting);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'SaveToolbarCustomizeSetting',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'SaveToolbarCustomizeSetting関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // SaveToolManagerCustomizeInfo関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_SaveToolManagerCustomizeInfo';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_SaveToolManagerCustomizeInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'SaveToolManagerCustomizeInfo',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'SaveToolManagerCustomizeInfo関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // SaveCustomizeXml関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_SaveCustomizeXml';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_SaveCustomizeXml);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'SaveCustomizeXml',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'SaveCustomizeXml関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // GetUltraOptionSetValue関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetUltraOptionSetValue';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetUltraOptionSetValue);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'GetUltraOptionSetValue',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'GetUltraOptionSetValue関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // SlipNoteGuide関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_SlipNoteGuide';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_SlipNoteGuide);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'SlipNoteGuide',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'SlipNoteGuide関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 売上金額変更後発生イベント処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_SalesPriceChanged';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_SalesPriceChanged);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '売上金額変更後発生イベント処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '売上金額変更後発生イベント処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 車両情報設定処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_CarInfoFormSetting';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_CarInfoFormSetting);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '車両情報設定処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '車両情報設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 保存確認ダイアログ表示処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_ShowRedSaveCheckDialog';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_ShowRedSaveCheckDialog);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '保存確認ダイアログ表示',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '保存確認ダイアログ表示処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // SetItemsDictionary関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_SetItemsDictionary';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_SetItemsDictionary);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'SetItemsDictionary',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'SetItemsDictionary関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // setColDisplayStatusList関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_setColDisplayStatusList';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_setColDisplayStatusList);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'setColDisplayStatusList',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'setColDisplayStatusList関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // --- ADD 2010/06/02 ---------->>>>>
    // GetReadSlipFlg関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetReadSlipFlg';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetReadSlipFlg);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'GetReadSlipFlg',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'GetReadSlipFlg関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2010/06/02----------<<<<<

    // --- ADD 2010/07/08 ---------->>>>>
    // 操作権限の制御関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_BeginControllingByOperationAuthority';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_BeginControllingByOperationAuthority);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '操作権限の制御',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '操作権限の制御関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2010/07/08 ----------<<<<<

// add by gaofeng end

    // --- ADD 2014/07/15 T.Miyamoto 仕掛一覧 №1912 ---------->>>>>
    // 操作権限の判定関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetOperationSt';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetOperationSt);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '操作権限の判定',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '操作権限の判定関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2014/07/15 T.Miyamoto 仕掛一覧 №1912 ----------<<<<<

// add by lizc begin
// 最新情報処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_ReNewalBtnClick';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_ReNewalBtnClick);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '車両検索部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '車両検索部品最新情報処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // xxxxx関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_ProcessingDialogDispose';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_ProcessingDialogDispose);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '車両検索部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '車両検索部品xxxxx関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
// add by lizc end

    //文字列解放関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_FreeMessage';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_FreeMessage);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '得意先文字列解放',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '得意先文字列解放関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // --- ADD m.suzuki 2010/06/12 ---------->>>>>
    // QR作成スレッド起動
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_MakeQR';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_MakeQR);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'QR作成スレッド起動',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'QR作成スレッド起動処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD m.suzuki 2010/06/12 ----------<<<<<

    // --- ADD m.suzuki 2010/06/16 ---------->>>>>
    // オンラインフラグ取得処理
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetOnlineFlag';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetOnlineFlag);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'オンラインフラグ取得処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'オンラインフラグ取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD m.suzuki 2010/06/16 ----------<<<<<

//>>>2010/05/30
    // SCM問合せ一覧選択関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_ReferenceList';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_ReferenceList);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'SCM問合せ一覧選択',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'aaaSCM問合せ一覧選択関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    //----- ADD　2018/09/04 譚洪　履歴自動表示の対応------->>>>>
    // 履歴検索選択関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_HisSearch';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_HisSearch);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '履歴検索',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'aaa履歴検索選択関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    //----- ADD　2018/09/04 譚洪　履歴自動表示の対応-------<<<<<
    //----- ADD　譚洪 2020/02/24 PMKOBETSU-2912の対応------->>>>>
    // 税率入力関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetTaxRate';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetTaxRate);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '税率入力',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'a税率入力関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_OrderCheck';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_OrderCheck);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '発注と仕入判断処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'a発注と仕入判断処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetTaxRateDialogResult';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetTaxRateDialogResult);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '税率入力',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'a税率入力関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    //----- ADD　譚洪 2020/02/24 PMKOBETSU-2912の対応-------<<<<<
    // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応 ----->>>>>
    // 電帳起動関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_StartEBooks';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_StartEBooks);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '電帳起動',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '電帳起動関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応 -----<<<<<
    // 起動パラメータ設定処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_SettingParameter';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_SettingParameter);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '起動パラメータ設定処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '起動パラメータ設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // SCM情報読込タイマー起動イベント関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_TimerSCMReadTick';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_TimerSCMReadTick);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'SCM情報読込タイマー起動イベント処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'SCM情報読込タイマー起動イベント処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // 相場価格情報取得関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_GetSobaInfo';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_GetSobaInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'SCM情報読込タイマー起動イベント処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '相場価格情報主塔処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    //<<<2010/05/30

    //>>>2010/08/30
    // 税率設定範囲チェック処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_ExistTaxRateRangeMethod';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_ExistTaxRateRangeMethod);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '税率設定範囲チェック処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '税率設定範囲チェック処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    //<<<2010/08/30

    //>>>2011/02/01
    // SCM情報存在チェック関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_ExistSCMInfo';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_ExistSCMInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', 'SCM情報存在チェック処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            'SCM情報存在チェック処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    //<<<2011/02/01

    //>>>2011/03/04
    // 従業員情報設定関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_SettingEmpInfo';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_SettingEmpInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '従業員情報設定処理',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '従業員情報設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    //<<<2011/03/04

    // ------  ADD K2015/04/01 高騁 森川部品個別依頼------->>>>>
    // 在庫品倉庫検索処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_ReadAllSecStockInfo';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_ReadAllSecStockInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '全社在庫情報表示',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '全社在庫情報表示関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_OptPermitForMoriKawa';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_OptPermitForMoriKawa);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '倉庫部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '倉庫部品森川個別オプション判定関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // ------  ADD K2015/04/01 高騁 森川部品個別依頼-------<<<<<
    // --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- >>>>>
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_OptPermitForKoei';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_OptPermitForKoei);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '㈱コーエイオプション判定',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '㈱コーエイオプション判定関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // 売価算出処理関数アドレス取得
    HDllCall1.ProcName := 'DelphiSalesSlipInputAcs_SalesUnPrcCalc';
    nSt := HDllCall1.HGetPAdr(@gpxDelphiSalesSlipInputAcs_SalesUnPrcCalc);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013B', '車種部品',
            'LoadLibraryMAHNB01013M', 'GETPROCADDRESS',
            '個別用売価算出関数のアドレス取得に失敗しました。', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- <<<<<

    Result := 0;

end;

// アクセスクラス仲介DLL解放メソッド
procedure FreeLibraryMAHNB01013M(HDllCall1: THDllCall);
begin
    HDllCall1.DllName := 'MAHNB01013M.DLL';
    HDllCall1.HFreeLibrary;
 // add by tanh
    gpxDelphiSalesSlipInputAcs_Clear := nil;
    gpxDelphiSalesSlipInputAcs_GetItemtSalesSlipCd := nil;
    gpxDelphiSalesSlipInputAcs_GetAddInfoVisible := nil;
    gpxDelphiSalesSlipInputAcs_GetDisplayCustomerInfo := nil;
    gpxDelphiSalesSlipInputAcs_GetDisplayHeaderFooterInfo := nil;
    gpxDelphiSalesSlipInputAcs_SetUserGdBdComboEditor := nil;
    gpxDelphiSalesSlipInputAcs_GetCellEnabled := nil;
    gpxDelphiSalesSlipInputAcs_InitMstCheck := nil;
    gpxDelphiSalesSlipInputAcs_Retry := nil;
    gpxDelphiSalesSlipInputAcs_RetryResult := nil;
    gpxDelphiSalesSlipInputAcs_GetNoteGuidList := nil;
    gpxDelphiSalesSlipInputAcs_Close := nil;
    gpxDelphiSalesSlipInputAcs_FormPosSerialize := nil;
    gpxDelphiSalesSlipInputAcs_FormPosDeserialize := nil;
    // --- ADD 2010/05/31 ---------->>>>>
    gpxDelphiSalesSlipInputAcs_uButtonEscClick := nil;
    gpxDelphiSalesSlipInputAcs_GetGrossProfitRateFlg := nil;
    gpxDelphiSalesSlipInputAcs_SmallPointProc := nil;
    // --- ADD 2010/05/31 ----------<<<<<
    gpxDelphiSalesSlipInputAcs_SetHomeKeyFlg := nil;
// end add by tanh
    // --- ADD 黄興貴 2015/04/29 回答取込パタン追加 ---->>>>>
    gpxDelphiSalesSlipInputAcs_ReadUoeData := nil;
    gpxDelphiSalesSlipInputAcs_OptPermitForFuJi := nil;
    // --- ADD 黄興貴 2015/04/29 回答取込パタン追加 ----<<<<<

  // --- ADD 紀飛 2015/06/18 WebUOE発注回答取込 ---->>>>>
  gpxDelphiSalesSlipInputAcs_OptPermitForMeiGo := nil;
  // --- ADD 紀飛 2015/06/18 WebUOE発注回答取込 ----<<<<<
    // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応--->>>>>
    gpxDelphiSalesSlipInputAcs_OptPermitForEBooks := nil;
    gpxDelphiSalesSlipInputAcs_StartEBooks := nil;
    // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応---<<<<<
    gpxDelphiSalesSlipInputAcs_SetAfterSaveData := nil;
    gpxDelphiSalesSlipInputAcs_GetAfterSaveData := nil;
    gpxDelphiSalesSlipInputAcs_DoAfterSave := nil;

    // --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ---------->>>>>
    gpxDelphiSalesSlipInputAcs_SetSecondSalesUnPrcGideLocation := nil;

    gpxDelphiSalesSlipInputAcs_OptPermitForMizuno2ndSellPriceCtl := nil;
    // --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ----------<<<<<

    // --- ADD 2012/10/15 ---------->>>>>
    gpxDelphiSalesSlipInputAcs_ShowStockDateMsg := nil;
    // --- ADD 2012/10/15 ----------<<<<<

    // --- ADD 2011/02/12 ---------->>>>>
    gpxDelphiSalesSlipInputAcs_DoAddLine := nil;
    gpxDelphiSalesSlipInputAcs_DoCacheImage := nil;
    gpxDelphiSalesSlipInputAcs_GetErrorFlag := nil;
    // --- ADD 2011/02/12 ----------<<<<<
    gpxDelphiSalesSlipInputAcs_CooprtKindDiv := nil;// ADD 2011/11/22
    // --- ADD 2011/04/13 ---------->>>>>
    gpxDelphiSalesSlipInputAcs_DetailDeleteActionTable := nil;
    // --- ADD 2011/04/13 ----------<<<<<

    // --- ADD 2011/05/30 ---------->>>>>
    gpxDelphiSalesSlipInputAcs_SetSectionCode := nil;
    // --- ADD 2011/05/30 ----------<<<<<

    // --- ADD 2011/07/18 ---------->>>>>
    gpxDelphiSalesSlipInputAcs_StockInfoAdjust := nil;
    // --- ADD 2011/07/18 ----------<<<<<

    // add by zhangkai
    gpxDelphiSalesSlipInputAcs_uButtonGuideClick := nil;
    gpxDelphiSalesSlipInputAcs_GetNextMovePosition := nil;
    // --- ADD 2010/06/02 ---------->>>>>
    gpxDelphiSalesSlipInputAcs_GetPreMovePosition := nil;
    // --- ADD 2010/06/02 ----------<<<<<
    gpxDelphiSalesSlipInputAcs_GetParam := nil;
    gpxDelphiSalesSlipInputAcs_GetEffectiveJudgment := nil;
    gpxDelphiSalesSlipInputAcs_GetSalesDetailDataTable := nil;
    gpxDelphiSalesSlipInputAcs_FreeCustomArrayA2 := nil;
    gpxDelphiSalesSlipInputAcs_GetSalesAllDetailDataTable := nil;
    gpxDelphiSalesSlipInputAcs_SetSalesDetailData := nil;
    gpxDelphiSalesSlipInputAcs_AfterGoodsNoUpdate := nil;
    gpxDelphiSalesSlipInputAcs_uButtonLineDiscountClick := nil;
    gpxDelphiSalesSlipInputAcs_uButtonGoodsDiscountClick := nil;
    gpxDelphiSalesSlipInputAcs_uButtonAnnotationClick := nil;
    gpxDelphiSalesSlipInputAcs_uButtonChangeWarehouseClick := nil;
    gpxDelphiSalesSlipInputAcs_uButtonStockSearchClick := nil;
    gpxDelphiSalesSlipInputAcs_uButtonTBOClick := nil;
    gpxDelphiSalesSlipInputAcs_uButtonCopyStockBefLineClick := nil;
    gpxDelphiSalesSlipInputAcs_uButtonCopyStockAllLineClick := nil;
    gpxDelphiSalesSlipInputAcs_uGridDetailsAfterCellUpdate := nil;
    gpxDelphiSalesSlipInputAcs_uGridDetailsAfterCellUpdateProc := nil;
    gpxDelphiSalesSlipInputAcs_GridJoinCheck := nil;
    gpxDelphiSalesSlipInputAcs_DeatilActionTable := nil;
    gpxDelphiSalesSlipInputAcs_AfterPartySaleSlipNumFocus := nil;
    gpxDelphiSalesSlipInputAcs_CheckDetailAction := nil;
    gpxDelphiSalesSlipInputAcs_GetSalesSlipInputConstructionData := nil;
    gpxDelphiSalesSlipInputAcs_retGoodsReason := nil;
    gpxDelphiSalesSlipInputAcs_SetSlipMemo := nil;
    gpxDelphiSalesSlipInputAcs_KeyPressNumCheck := nil;
    gpxDelphiSalesSlipInputAcs_CsvPassCheck := nil;
    gpxDelphiSalesSlipInputAcs_FreeUserGdHd := nil;
    gpxDelphiSalesSlipInputAcs_FreeUserGdBd := nil;
    // end add by zhangkai

// add by yangmj
    gpxDelphiSalesSlipInputAcs_ShipmentAddUp := nil;
    gpxDelphiSalesSlipInputAcs_GetSalesHisGuide := nil;
    gpxDelphiSalesSlipInputAcs_FreeSalesSlip := nil;
    gpxDelphiSalesSlipInputAcs_AcceptAnOrderReferenceSearch := nil;
    gpxDelphiSalesSlipInputAcs_AcceptAnOrderAddup := nil;
    gpxDelphiSalesSlipInputAcs_SalesReferenceSearch := nil;
    gpxDelphiSalesSlipInputAcs_CopySlip := nil;
    gpxDelphiSalesSlipInputAcs_GetOptCarMng := nil;
    gpxDelphiSalesSlipInputAcs_SetNoteCharCnt := nil;
    gpxDelphiSalesSlipInputAcs_ReturnSlip := nil;
    gpxDelphiSalesSlipInputAcs_ShowSaveCheckDialog := nil;
    gpxDelphiSalesSlipInputAcs_Save := nil;
    gpxDelphiSalesSlipInputAcs_AfterSave := nil;
    gpxDelphiSalesSlipInputAcs_GetSaveStatus := nil;
    // --- ADD 2015/12/09 T.Miyamoto リモ伝障害対応 Redmine#47670 ---------->>>>>
    gpxDelphiSalesSlipInputAcs_GetOnlineKindDiv := nil;
    // --- ADD 2015/12/09 T.Miyamoto リモ伝障害対応 Redmine#47670 ----------<<<<<
    gpxDelphiSalesSlipInputAcs_ChangeSearchMode := nil;
    gpxDelphiSalesSlipInputAcs_GetSearchPartsModeProperty := nil;
    gpxDelphiSalesSlipInputAcs_GetBitButtonCustomizeSetting := nil;


// end add by yangmj

// add by gaofeng start

    gpxDelphiGetSalesSlipInputInitDataAcs_GetInitData := nil;
    gpxDelphiGetSalesSlipInputInitDataAcs_FreeMessage := nil;
    gpxDelphiSalesSlipInputAcs_customerGuide := nil;
    gpxDelphiSalesSlipInputAcs_FreeCustomerSearchRet := nil;
    gpxDelphiSalesSlipInputAcs_ShowSalesSlipInputSetup := nil;
    gpxDelphiSalesSlipInputAcs_GetDisplayName := nil;
    gpxDelphiSalesSlipInputAcs_GetDetailGrossProfitRate := nil;
    gpxDelphiSalesSlipInputAcs_Delete := nil;
    gpxDelphiSalesSlipInputAcs_GetItemName := nil;
    gpxDelphiSalesSlipInputAcs_GetStatus := nil;
    gpxDelphiSalesSlipInputAcs_GetBeforeSalesSlipNumText := nil;
    gpxDelphiSalesSlipInputAcs_GetFocusPositionValue := nil;
    gpxDelphiSalesSlipInputAcs_RedSlip := nil;
    gpxDelphiSalesSlipInputAcs_GetCanRed := nil;
    gpxDelphiSalesSlipInputAcs_GetRedDialogResult := nil;
    gpxDelphiSalesSlipInputAcs_CopySlipHeader := nil;
    gpxDelphiSalesSlipInputAcs_CopySlipDetail := nil;         //ADD 連番729 2011/08/18
    gpxDelphiSalesSlipInputAcs_AfterCarMngNoGuideReturn := nil;
    gpxDelphiSalesSlipInputAcs_setToolMenuCustomizeSetting := nil;
    gpxDelphiSalesSlipInputAcs_getToolMenuCustomizeSetting := nil;
    gpxDelphiSalesSlipInputAcs_setToolButtonCustomizeSetting := nil;
    gpxDelphiSalesSlipInputAcs_getToolButtonCustomizeSetting := nil;
    gpxDelphiSalesSlipInputAcs_SaveToolbarCustomizeSetting := nil;
    gpxDelphiSalesSlipInputAcs_SaveToolManagerCustomizeInfo := nil;
    gpxDelphiSalesSlipInputAcs_SaveCustomizeXml := nil;
    gpxDelphiSalesSlipInputAcs_GetUltraOptionSetValue := nil;
    gpxDelphiSalesSlipInputAcs_SlipNoteGuide := nil;
    gpxDelphiSalesSlipInputAcs_SalesPriceChanged := nil;
    gpxDelphiSalesSlipInputAcs_CarInfoFormSetting := nil;
    gpxDelphiSalesSlipInputAcs_ShowRedSaveCheckDialog := nil;
    gpxDelphiSalesSlipInputAcs_SetItemsDictionary := nil;
    gpxDelphiSalesSlipInputAcs_setColDisplayStatusList := nil;

    // --- ADD 2010/06/02 ---------->>>>>
    gpxDelphiSalesSlipInputAcs_GetReadSlipFlg := nil;
    // --- ADD 2010/06/02----------<<<<<

    // --- ADD 2010/07/08 ---------->>>>>
    gpxDelphiSalesSlipInputAcs_BeginControllingByOperationAuthority := nil;
    // --- ADD 2010/07/08 ----------<<<<<

// add by gaofeng end

    // --- ADD 2014/07/15 T.Miyamoto 仕掛一覧 №1912 ---------->>>>>
    // 操作権限の判定関数アドレス取得
    gpxDelphiSalesSlipInputAcs_GetOperationSt := nil;
    // --- ADD 2014/07/15 T.Miyamoto 仕掛一覧 №1912 ----------<<<<<

// add by lizc begin
    gpxDelphiSalesSlipInputAcs_ReNewalBtnClick := nil;
    gpxDelphiSalesSlipInputAcs_ProcessingDialogDispose := nil;
// add by lizc end

    gpxDelphiSalesSlipInputAcs_FreeMessage := nil;

    // --- ADD m.suzuki 2010/06/12 ---------->>>>>
    gpxDelphiSalesSlipInputAcs_MakeQR := nil;
    // --- ADD m.suzuki 2010/06/12 ----------<<<<<
    // --- ADD m.suzuki 2010/06/16 ---------->>>>>
    gpxDelphiSalesSlipInputAcs_GetOnlineFlag := nil;
    // --- ADD m.suzuki 2010/06/16 ----------<<<<<

    //>>>2010/05/30
    gpxDelphiSalesSlipInputAcs_ReferenceList := nil;
    gpxDelphiSalesSlipInputAcs_HisSearch := nil;// ADD　2018/09/04 譚洪　履歴自動表示の対応
    // ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応 ------>>>>>
    gpxDelphiSalesSlipInputAcs_GetTaxRateDialogResult := nil;
    gpxDelphiSalesSlipInputAcs_GetTaxRate := nil;
    gpxDelphiSalesSlipInputAcs_OrderCheck := nil;
    // ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応 ------<<<<<
    gpxDelphiSalesSlipInputAcs_SettingParameter := nil;
    gpxDelphiSalesSlipInputAcs_TimerSCMReadTick := nil;
    gpxDelphiSalesSlipInputAcs_GetSobaInfo := nil;
    //<<<2010/05/30
    gpxDelphiSalesSlipInputAcs_SetInitData := nil;

    //>>>2010/08/30
    gpxDelphiSalesSlipInputAcs_ExistTaxRateRangeMethod := nil;
    //<<<2010/08/30
    // --- ADD 2012/05/31 No.282---------->>>>>
    gpxDelphiSalesSlipInputAcs_uButtonEscClick2 := nil;
    gpxDelphiSalesSlipInputAcs_SaveOrderInfo := nil;
    // --- ADD 2012/05/31 No.282----------<<<<<

    // --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- >>>>>
    gpxDelphiSalesSlipInputAcs_SalesUnPrcCalc := nil;
    gpxDelphiSalesSlipInputAcs_OptPermitForKoei := nil;
    // --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- <<<<<

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
        LoadLibraryMAHNB01013M(DataModule1.HDllCall1);
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
    FreeLibraryMAHNB01013M(DataModule1.HDllCall1);

    DataModule1.Free;
    DataModule1 := nil;
  end;

end.

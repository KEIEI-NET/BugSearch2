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
// 作 成 日  2011/01/31  修正内容 : ①起動パラメータ設定処理のパラメータ変更
//                                  ②AfterSaveのパラメータ変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20056 對馬 大輔
// 作 成 日  2011/02/01  修正内容 : SCM情報存在チェック処理追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20056 對馬 大輔
// 作 成 日  2011/03/04  修正内容 : 従業員情報設定処理追加
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
// 管理番号              作成担当 : 曹文傑  連番1028,Redmine#22936
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
// 作 成 日  2013/03/28  修正内容 : SCM障害No.192対応
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
//----------------------------------------------------------------------------//
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

unit MAHNB01013BAP;

interface

uses ShareMem, SysUtils, HDllCall, DBClient, HFSLLIB, MAHNB01012C, MAHNB01013C,
  MAHNB01013BMP, messages, classes, windows, controls, dialogs;

/// //////////// Delphi側へのエクスポート関数宣言 //////////////////////////

// add by tanh
// 得意先ガイド処理
function MAHNB01013B_Clear(isConfirm: Boolean; keepAcptAnOdrStatus: Boolean;
  keepDate: Boolean; keepFooterInfo: Boolean; keepCustomer: Boolean;
  keepSalesDate: Boolean; keepDetailRowCount: Boolean; customerCode: Integer): Boolean;
  stdcall;

// 明細データ取得
function MAHNB01013B_GetSalesDetailDataTable(var refSalesDetailList: TSalesSlipInputCustomArrayA2;
    salesRowNo: Integer)
    : Integer; stdcall;

// 明細データ取得
function MAHNB01013B_GetSalesAllDetailDataTable(var refSalesDetailList: TSalesSlipInputCustomArrayA2)
    : Integer; stdcall;

  // 備考設定処理
function MAHNB01013B_GetNoteGuidList(enterpriseCode: WideString)
    : Integer; stdcall;

// 小数点表示区分処理
function MAHNB01013B_SmallPointProc(rowIndexParm: Integer)
    : Integer; stdcall;

// 伝票区分コンボエディタアイテム設定処理
function MAHNB01013B_GetItemtSalesSlipCd(var setItemtSalesSlipCdDisp: Integer;
  var setItemtSalesSlipCdFlg: Integer): Integer; stdcall;

// 追加情報タブ項目Visible設定
function MAHNB01013B_GetAddInfoVisible(var ctTabKeyAddInfo: Integer;
  var settingAddInfoVisibleFlg: Integer): Integer; stdcall;

// 伝票区分コンボエディタアイテム設定処理
function MAHNB01013B_GetDisplayHeaderFooterInfo(
  var inputModeTitle: WideString; var defaultSalesSlipNumDf: WideString;
  var searchPartsModeFlg: Integer; var operationCodeFlg: Integer): Integer;
  stdcall;

// 各種マスタチェック
function MAHNB01013B_InitMstCheck(var mstCheckFlg: Boolean): Integer; stdcall;

// 得意先情報画面格納処理
function MAHNB01013B_GetDisplayCustomerInfo(var customerNameFlg: Integer;
  var totalDayDf: WideString; var collectMoneyDf: WideString): Integer; stdcall;

// 明細データ取得
function MAHNB01013B_SetUserGdBdComboEditor
  (var guideCodeList: TWideStringArray; var guideNameList: TWideStringArray)
  : Integer; stdcall;

// セルEnabled設定取得処理
function MAHNB01013B_GetCellEnabled(keyName: WideString): Integer; stdcall;

// 元に戻す処理
function MAHNB01013B_Retry(isConfirm: Boolean;
    var dialogResultFlg: Boolean)
    : Integer; stdcall;

// 設定処理
function MAHNB01013B_SetSalesDetailData(inputdata: WideString;
    inputType: Integer)
    : Integer; stdcall;

// 保存用設定処理
function MAHNB01013B_SetAfterSaveData(resultData: Integer;
    carMngCode: WideString;
    printSlipFlag: Boolean;
    isMakeQR: Boolean;
    scmFlg: Boolean;
    cmtFlag: Boolean;
    // ----- ADD K2011/12/09 --------->>>>>
    slipNote2ErrFlag: Boolean;
// UPD 2013/03/28 SCM障害№192対応 ------------->>>>>
//    salesDateErrFlag: Boolean)
    salesDateErrFlag: Boolean;
    isSCMSave: Integer)
// UPD 2013/03/28 SCM障害№192対応 -------------<<<<<
    // ----- ADD K2011/12/09 ---------<<<<<
    : Integer; stdcall;

// --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ---------->>>>>
//第二売価ガイドの位置を設定します。
function MAHNB01013B_SetSecondSalesUnPrcGideLocation(locationLeft: Integer;
    locationTop: Integer)
    : Integer; stdcall;

// 水野商工㈱オプション判定
function MAHNB01013B_OptPermitForMizuno2ndSellPriceCtl(var optPermitForMizuno2ndSellPriceCtl: Boolean)
    : Integer; stdcall;
// --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ----------<<<<<

// 保存用設定処理
function MAHNB01013B_GetAfterSaveData(var resultData: Integer;
    var isMakeQR: Boolean;
    var scmFlg: Boolean;
    var cmtFlag: Boolean;
    // ----- ADD K2011/12/09 --------->>>>>
    var slipNote2ErrFlag: Boolean;
// UPD 2013/03/28 SCM障害№192対応 ------------->>>>>
//    var salesDateErrFlag: Boolean)
    var salesDateErrFlag: Boolean;
    var isSCMSave: Integer)
// UPD 2013/03/28 SCM障害№192対応 -------------<<<<<
    // ----- ADD K2011/12/09 ---------<<<<<
    : Integer; stdcall;

// 保存用設定処理
function MAHNB01013B_DoAfterSave()
    : Integer; stdcall;

// ----- ADD 2012/10/15 --------->>>>>
// 仕入日のエラーメッセージを表示処理
function MAHNB01013B_ShowStockDateMsg()
    : Integer; stdcall;
// ----- ADD 2012/10/15 ---------<<<<<

// 元に戻す処理
function MAHNB01013B_RetryResult(var statusFlg: Boolean)
    : Integer; stdcall;

// オプション情報処理
function MAHNB01013B_FormPosSerialize(topInt: Integer;
    leftInt: Integer;
    heightInt: Integer;
    widthInt: Integer)
    : Integer; stdcall;

// --- ADD 2011/02/12 ---------->>>>>
// 調査用ログ出力クラス処理
function MAHNB01013B_DoAddLine(logNo: Integer;
    slipNo: Integer;
    acptAnOdrStatus: Integer)
    : Integer; stdcall;

// 調査用ログImage出力処理
function MAHNB01013B_DoCacheImage()
    : Integer; stdcall;

// 各種マスタチェック
function MAHNB01013B_GetErrorFlag(var errorFlag: Boolean)
    : Integer; stdcall;
// --- ADD 2011/02/12 ----------<<<<<

// --- ADD 2011/11/22 ---------->>>>>
// 連携判断処理
function MAHNB01013B_CooprtKindDiv(var CooprtFlag: Boolean)
    : Integer; stdcall;
// --- ADD 2011/11/22 ----------<<<<<

// --- ADD 2011/04/13 ---------->>>>>
// 選択済み売上行番号削除処理（多行削除場合用）
function MAHNB01013B_DetailDeleteActionTable(startRowNo: Integer;
    endRowNo: Integer)
    : Integer; stdcall;
// --- ADD 2011/04/13 ----------<<<<<

// 各種起動データ
//function MAHNB01013B_SetInitData()     //DEL 連番729 2011/08/18
function MAHNB01013B_SetInitData(var existFlg: Boolean)       //ADD 連番729 2011/08/18
    : Integer; stdcall;

// --- ADD 2011/05/30 ---------->>>>>
// 画面の拠点コード変化時（キャンペーン情報取得用）
function MAHNB01013B_SetSectionCode(sectionCode: WideString)
    : Integer; stdcall;
// --- ADD 2011/05/30 ----------<<<<<

// --- ADD 2011/07/18 ---------->>>>>
// 現在庫数を調整します
function MAHNB01013B_StockInfoAdjust()
    : Integer; stdcall;
// --- ADD 2011/07/18 ----------<<<<<

// オプション情報処理
function MAHNB01013B_FormPosDeserialize(var topInt: Integer;
    var leftInt: Integer;
    var heightInt: Integer;
    var widthInt: Integer)
    : Integer; stdcall;

// 終了設定処理
// --- UPD m.suzuki 2010/06/16 ---------->>>>>
//function MAHNB01013B_Close(isConfirmFlg: Boolean;
//    var canCloseFlg: Boolean)
//    : Integer; stdcall;
function MAHNB01013B_Close(isConfirmFlg: Boolean;
    var canCloseFlg: Boolean; var isMakeQR: Boolean)
    : Integer; stdcall;
// --- UPD m.suzuki 2010/06/16 ----------<<<<<

// --- ADD 2010/05/31 ---------->>>>>
// ESC処理
function MAHNB01013B_uButtonEscClick(var escFlg: Boolean)
    : Integer; stdcall;
// --- ADD 2010/05/31 ----------<<<<<

// end add by tanh

// add by zhangkai

// --- ADD 2012/05/31 No.282---------->>>>>
// 発注解除処理
function MAHNB01013B_uButtonEscClick2(var escFlg: Boolean)
    : Integer; stdcall;
// 発注退避処理
function MAHNB01013B_SaveOrderInfo(var escFlg: Boolean)
    : Integer; stdcall;
// --- ADD 2012/05/31 No.282----------<<<<<

// 品番検索処理
function MAHNB01013B_AfterGoodsNoUpdate(rowIndex: Integer;
    cellValue: WideString;
    makerCd: Integer;         //ADD 連番729 2011/08/18
    salesRowNo: Integer)
    : Integer; stdcall;

// 行値引き処理
function MAHNB01013B_uButtonLineDiscountClick(parmRowIndex: Integer)
    : Integer; stdcall;

// 商品値引き処理
function MAHNB01013B_uButtonGoodsDiscountClick(parmRowIndex: Integer)
    : Integer; stdcall;

// 注釈処理
function MAHNB01013B_uButtonAnnotationClick(parmRowIndex: Integer)
    : Integer; stdcall;

// 倉庫切替処理
function MAHNB01013B_uButtonChangeWarehouseClick(parmSalesRowNo: Integer)
    : Integer; stdcall;

// 在庫検索処理
function MAHNB01013B_uButtonStockSearchClick(parmRowIndex: Integer)
    : Integer; stdcall;


// ＴＢＯ処理
function MAHNB01013B_uButtonTBOClick(parmRowIndex: Integer)
    : Integer; stdcall;


// 前行複写処理
function MAHNB01013B_uButtonCopyStockBefLineClick(parmRowIndex: Integer)
    : Integer; stdcall;


// 一括複写処理
function MAHNB01013B_uButtonCopyStockAllLineClick(parmRowIndex: Integer)
    : Integer; stdcall;

// グリッドセルアップデート後処理
function MAHNB01013B_uGridDetailsAfterCellUpdate(rowIndexParm: Integer;
    cellValue: WideString;
    beforeCellValue: WideString;
    columnName: WideString)
    : Integer; stdcall;

// グリッドセルアップデート後処理
function MAHNB01013B_uGridDetailsAfterCellUpdateProc(rowIndexParm: Integer;
    cellValue: WideString;
    beforeCellValue: WideString;
    columnName: WideString)
    : Integer; stdcall;

// グリッド関連チェック処理
function MAHNB01013B_GridJoinCheck(salesRowNo: Integer;
    rowIndex: Integer;
    operationCode: Integer;
    mode: Integer)
    : Integer; stdcall;

// ファンクション明細制御取得処理
function MAHNB01013B_GetBitButtonCustomizeSetting(key: WideString;
    var bitButtonCustomizedVisible: Integer)
    : Integer; stdcall;

// Table処理
function MAHNB01013B_DeatilActionTable(salesRowNo: Integer;
    actionType: WideString)
    : Integer; stdcall;

// ガイドボタンクリックイベント処理
function MAHNB01013B_uButtonGuideClick(rowIndexParm: Integer;
    columnName: WideString)
    : Integer; stdcall;

// 移動位置取得処理(Enterキー移動時)
function MAHNB01013B_GetNextMovePosition(p: WideString;
    var afterColKeyName: WideString)
    : Integer; stdcall;

// --- ADD 2010/06/02 ---------->>>>>
// 移動位置取得処理(Enterキー移動時)
function MAHNB01013B_GetPreMovePosition(p: WideString;
    var afterColKeyName: WideString)
    : Integer; stdcall;
// --- ADD 2010/06/02 ----------<<<<<


// Param取得処理
function MAHNB01013B_GetParam(var startKeyName: WideString;
    var endKeyNameList: WideString)
    : Integer; stdcall;

// フォーカス移動対象判定処理
function MAHNB01013B_GetEffectiveJudgment(keyName: WideString)
    : Integer; stdcall;

// 得意先注番のフォーカス処理
function MAHNB01013B_AfterPartySaleSlipNumFocus(var refSalesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    value: WideString;
    var dialogFlag: Boolean)
    : Integer; stdcall;

// チェック処理
function MAHNB01013B_CheckDetailAction(beforeRowIndex: Integer;
    parmRowIndex: Integer;
    checkType: Integer)
    : Integer; stdcall;

// ユーザー設定処理
function MAHNB01013B_GetSalesSlipInputConstructionData(var data: Integer;
    inputType: Integer)
    : Integer; stdcall;

// 返品理由ガイド処理
function MAHNB01013B_retGoodsReason(enterpriseCode: WideString;
    var userGdHd: TUserGdHd;
    var userGdBd: TUserGdBd;
    var salesSlip: TSalesSlip)
    : Integer; stdcall;

// 伝票メモ情報設定処理
function MAHNB01013B_SetSlipMemo(slipMemo1: WideString;
    slipMemo2: WideString;
    slipMemo3: WideString;
    insideMemo1: WideString;
    insideMemo2: WideString;
    insideMemo3: WideString;
    salesRowNo: Integer)
    : Integer; stdcall;

// 数値入力チェック処理
function MAHNB01013B_KeyPressNumCheck(keta: Integer;
    priod: Integer;
    prevVal: WideString;
    key: WideString;
    selstart: Integer;
    sellength: Integer;
    minusFlg: Boolean)
    : Integer; stdcall;

// CSV出力先が設定され、フォルダが存在しているかチェック処理
function MAHNB01013B_CsvPassCheck(var linkDir: WideString)
    : Integer; stdcall;

// end add by zhangkai


// add by yangmj

function MAHNB01013B_ShipmentAddUp(isDataChanged: Boolean; var isSave: Integer)
  : Integer; stdcall;

// 出荷照会ボタンクリック処理
function MAHNB01013B_GetSalesHisGuide(count: Integer; CustomerCode: WideString)
  : Integer; stdcall;

// 受注照会(明細選択)
function MAHNB01013B_AcceptAnOrderReferenceSearch(rowCount: Integer;
  CustomerCode: WideString): Integer; stdcall;

// 受注計上処理
function MAHNB01013B_AcceptAnOrderAddup(isDataChanged: Boolean;
  var IsResult: Integer): Integer; stdcall;

// 見積計上(明細選択)
function MAHNB01013B_EstimateReferenceSearch(rowCount: Integer;
  CustomerCode: WideString): Integer; stdcall;

// HOMEキー設定処理
function MAHNB01013B_SetHomeKeyFlg(homeKeyFlg: Boolean)
    : Integer; stdcall;

// 見積照会(伝票選択)
function MAHNB01013B_EstimateAddup(isDataChanged: Boolean;
  var IsResult: Integer): Integer; stdcall;

// 履歴照会(売上履歴データから明細選択)
function MAHNB01013B_SalesReferenceSearch(rowCount: Integer;
  CustomerCode: WideString): Integer; stdcall;

// 伝票複写
function MAHNB01013B_CopySlip(isDataChanged: Boolean; var IsResult: Integer)
  : Integer; stdcall;

// 車両管理オプション取得処理
function MAHNB01013B_GetOptCarMng(var optCarMng: Integer): Integer; stdcall;

// 伝票備考、伝票備考２、伝票備考３の入力桁数設定処理
function MAHNB01013B_SetNoteCharCnt(var slipNoteCharCnt: Integer;
  var slipNote2CharCnt: Integer; var slipNote3CharCnt: Integer): Integer;
  stdcall;

// 返品処理関係
function MAHNB01013B_ReturnSlip(isDataChanged: Boolean; var IsResult: Integer)
  : Integer; stdcall;

  // オプション情報処理
function MAHNB01013B_GetGrossProfitRateFlg(var grossProfitRateFlg: Boolean)
    : Integer; stdcall;

// 保存確認ダイアログ表示処理
// --- UPD m.suzuki 2010/06/16 ---------->>>>>
//function MAHNB01013B_ShowSaveCheckDialog(isConfirm: Boolean;
//  var resultNum: Integer; carMngCode: WideString): Integer; stdcall;
function MAHNB01013B_ShowSaveCheckDialog(isConfirm: Boolean;
  var resultNum: Integer; carMngCode: WideString; var isMakeQR: Boolean): Integer; stdcall;
// --- UPD m.suzuki 2010/06/16 ----------<<<<<

// 保存処理
// --- UPD m.suzuki 2010/06/12 ---------->>>>>
//function MAHNB01013B_Save(isShowSaveCompletionDialog: Boolean;
//  isConfirm: Boolean): Boolean; stdcall;
function MAHNB01013B_Save(isShowSaveCompletionDialog: Boolean;
  isConfirm: Boolean; var isMakeQR: Boolean): Boolean; stdcall;
// --- UPD m.suzuki 2010/06/12 ----------<<<<<

// 保存後処理
// 2011/01/31 >>>
//// --- UPD m.suzuki 2010/06/12 ---------->>>>>
////function MAHNB01013B_AfterSave(var saveResult: Integer;
////    carMngCode: WideString; printSlipFlag: Boolean): Integer; stdcall;
//function MAHNB01013B_AfterSave(var saveResult: Integer;
//    carMngCode: WideString; printSlipFlag: Boolean; var isMakeQR: Boolean; scmFlg: Boolean): Integer; stdcall;
//// --- UPD m.suzuki 2010/06/12 ----------<<<<<

function MAHNB01013B_AfterSave(var saveResult: Integer;
// ----- DEL K2011/09/01 --------------------------->>>>>
   //carMngCode: WideString; printSlipFlag: Boolean; var isMakeQR: Boolean; var scmFlg: Boolean; var cmtFlg: Boolean; var slipNote2ErrFlag: Boolean): Integer; stdcall; // UPD K2011/08/12
// ----- DEL K2011/09/01 ---------------------------<<<<<
// ----- ADD K2011/09/01 --------------------------->>>>>
// UPD 2013/03/28 SCM障害№192対応 -------------------------->>>>>
//          carMngCode: WideString; printSlipFlag: Boolean; var isMakeQR: Boolean; var scmFlg: Boolean; var cmtFlg: Boolean; var slipNote2ErrFlag: Boolean ; var salesDateErrFlag: Boolean): Integer; stdcall;
          carMngCode: WideString;
          printSlipFlag: Boolean;
          var isMakeQR: Boolean;
          var scmFlg: Boolean;
          var cmtFlg: Boolean;
          var slipNote2ErrFlag: Boolean;
          var salesDateErrFlag: Boolean;
          var isSCMSave: Integer)
          : Integer; stdcall;
// UPD 2013/03/28 SCM障害№192対応 --------------------------<<<<<
// ----- ADD K2011/09/01 ---------------------------<<<<<


// 2011/01/31 <<<

// 保存状態取得
function MAHNB01013B_GetSaveStatus(var saveStatus: Integer): Integer; stdcall;

// --- ADD 2015/12/09 T.Miyamoto リモ伝障害対応 Redmine#47670 ---------->>>>>
// オンライン種別取得
function MAHNB01013B_GetOnlineKindDiv(var onlineKindDiv: Integer): Integer; stdcall;
// --- ADD 2015/12/09 T.Miyamoto リモ伝障害対応 Redmine#47670 ----------<<<<<

// 部品検索切替処理
function MAHNB01013B_ChangeSearchMode(clearCarFlag: Integer;
  CheckRowEffectiveFlg: Boolean; salesRowNo: Integer;
  ContainsFocusFlg: Boolean; var carMngCodeMode: Boolean): Integer; stdcall;

// 部品検索モード取得
function MAHNB01013B_GetSearchPartsModeProperty
  (var searchPartsModeProperty: Integer): Integer; stdcall;

//----ADD 2010/06/17----->>>>>
// 売上データ設定
function MAHNB01013B_SetSalesSlip(Salesslip: TSalesSlip)
    : Integer; stdcall;
//----ADD 2010/06/17-----<<<<<
//----ADD 2010/11/02----->>>>>
function MAHNB01013B_SetSalesSlipByObj(Salesslip: TSalesSlip)
    : Integer; stdcall;
//----ADD 2010/11/02-----<<<<<
// end add by yangmj

// add by gaofeng start
// 初期データをＤＢより取得の処理
function MAHNB01013B_GetInitData(): Integer; stdcall;

// 売上伝票ガイド処理
function MAHNB01013B_salesSlipGuide(formName: WideString;
  enterpriseCode: WideString; acptAnOdrStatusDisplay: Integer;
  var refAcptAnOdrStatus: Integer; var estimateDivide: Integer;
  var searchResult: TSalesSlipSearchResult; var salesSlip: TSalesSlip;
  var outDialogResult: Boolean; var outStatus: Boolean;
  var consTaxLayMethodChangedFlg: Boolean;
  var isPCCUOESaleSlip: Boolean) //ADD 2011/11/18
  : Integer; stdcall;

// 得意先ガイド処理
function MAHNB01013B_customerGuide(customerFlag: Boolean;
  addresseeCode: Integer; CustomerCode: Integer;
  var customerSearchRet: TCustomerSearchRet; var dialogResultFlag: Integer;
  var customerCodeChangedFlg: Boolean;
  var optCarMngFlg: Boolean)
  : Integer; stdcall;

// 設定処理
function MAHNB01013B_ShowSalesSlipInputSetup(): Integer; stdcall;

// 画面項目名称取得処理
// ADD　譚洪 2020/02/24 PMKOBETSU-2912の対応 ---------->>>>>
//function MAHNB01013B_GetDisplayName(var rateName: WideString): Integer; stdcall;
function MAHNB01013B_GetDisplayName(var rateName: WideString; var taxFlg: Boolean): Integer; stdcall;
// ADD　譚洪 2020/02/24 PMKOBETSU-2912の対応 ----------<<<<<
// 明細粗利率取得処理
function MAHNB01013B_GetDetailGrossProfitRate
  (rowNo: Integer; var detailGrossProfitRate: WideString; var addDetailGrossProfitRate
    : WideString): Integer; stdcall;

// 伝票削除処理
function MAHNB01013B_Delete(var outCheck: Boolean;
    var outDialogResult: Integer;
    var outStatus: Integer)
    : Integer; stdcall;

// アイテム名の取得処理
function MAHNB01013B_GetItemName(var itemName: WideString;
  var tableName: WideString): Integer; stdcall;

function MAHNB01013B_GetStatus(var outStatus: Integer): Integer; stdcall;

function MAHNB01013B_GetBeforeSalesSlipNumText
  (var beforeSalesSlipNumText: WideString): Integer; stdcall;

// フォーカス位置の取得処理
function MAHNB01013B_GetFocusPositionValue(var focusPositionValue: Integer)
  : Integer; stdcall;

// 赤伝処理
function MAHNB01013B_RedSlip(isConfirm: Boolean; canRed: Boolean): Integer; stdcall;

// 赤伝できるかどうかフラグの取得処理
function MAHNB01013B_GetCanRed(var canRed: Boolean): Integer; stdcall;

function MAHNB01013B_GetRedDialogResult(var redDialogResult: Integer): Integer;
  stdcall;

// 見出貼付
function MAHNB01013B_CopySlipHeader(CarInfoEnabledFlg: Boolean;
  salesRowNo: Integer; addresseeName: Integer; var existSalesDetail: Boolean;
  var clearDetailFlg: Boolean; var searchPartsModeProperty: Integer;
  var fullModelFixedNoAryFlg: Boolean; var errorFlg: Boolean;
  var outSalesSlipHeaderCopyData: TSalesSlipHeaderCopyData;
  var copySlipHeaderClearFlg: Boolean): Integer; stdcall;

//-------------- ADD 連番729 2011/08/18 ----------------->>>>>
// 明細貼付
function MAHNB01013B_CopySlipDetail(salesRowNo: Integer): Integer; stdcall;
//-------------- ADD 連番729 2011/08/18 -----------------<<<<<

// 管理番号ガイド表示後の処理
function MAHNB01013B_AfterCarMngNoGuideReturn(paraStatus: Integer;
  selectedInfo: TCarMangInputExtraInfo; inputflag: Integer;
  salesRowNo: Integer; carMngCode: WideString; var returnFlag: Boolean;
  var clearCarInfoFlag: Boolean): Integer; stdcall;

// xxxx
function MAHNB01013B_setToolMenuCustomizeSetting(key: WideString): Integer;
  stdcall;

// xxxx
function MAHNB01013B_getToolMenuCustomizeSetting
  (var toolMenuCustomizeSettingNotNull: Boolean; var toolBarVisible: Boolean;
  var toolBarDockedRow: Integer; var toolBarDockedColumn: Integer;
  var toolBarDockedPosition: Integer): Integer; stdcall;

// xxxx
function MAHNB01013B_setToolButtonCustomizeSetting(key: WideString): Integer;
  stdcall;

// xxxx
function MAHNB01013B_getToolButtonCustomizeSetting
  (var toolButtonCustomizeSettingNotNull: Boolean;
  var toolBarCustomizedVisible: Integer): Integer; stdcall;

// xxxx
function MAHNB01013B_SaveToolbarCustomizeSetting
  (key: WideString; visible: Boolean): Integer; stdcall;

// xxxx
function MAHNB01013B_SaveToolManagerCustomizeInfo
  (key: WideString; visible: Boolean; dockedRow: Integer;
  dockedColumn: Integer; dockedPosition: Integer): Integer; stdcall;

// xxxx
function MAHNB01013B_SaveCustomizeXml(): Integer; stdcall;

function MAHNB01013B_GetUltraOptionSetValue()
  : Integer; stdcall;

function MAHNB01013B_SlipNoteGuide(salesRowNo: Integer)
    : Integer; stdcall;

// 売上金額変更後発生イベント処理
function MAHNB01013B_SalesPriceChanged()
    : Integer; stdcall;

// 車両情報設定処理
function MAHNB01013B_CarInfoFormSetting(salesRowNo: Integer;
    var isGoodsFlg: Boolean;
    var carInfoRowFlg: Boolean)
    : Integer; stdcall;

// 保存確認ダイアログ表示処理
// --- UPD m.suzuki 2010/06/16 ---------->>>>>
//function MAHNB01013B_ShowRedSaveCheckDialog(isConfirm: Boolean;
//    var afterSaveClearFlg: Boolean)
//    : Integer; stdcall;
function MAHNB01013B_ShowRedSaveCheckDialog(isConfirm: Boolean;
    var afterSaveClearFlg: Boolean; var isMakeQR: Boolean)
    : Integer; stdcall;
// --- UPD m.suzuki 2010/06/16 ----------<<<<<

//---UPD 2010/07/06---------->>>>>
// SetItemsDictionary
//function MAHNB01013B_SetItemsDictionary(headControlNames: WideString; footControlNames: WideString)
//    : Integer; stdcall;
function MAHNB01013B_SetItemsDictionary(headControlNames: WideString; footControlNames: WideString; functionControlNames: WideString; functionDetailControlNames: WideString)
    : Integer; stdcall;
//---UPD 2010/07/06----------<<<<<

// setColDisplayStatusList
function MAHNB01013B_setColDisplayStatusList()
    : Integer; stdcall;

// --- ADD 2010/06/02 ---------->>>>>
// GetReadSlipFlg
function MAHNB01013B_GetReadSlipFlg(var readSlipFlg: Boolean)
    : Integer; stdcall;
// --- ADD 2010/06/02----------<<<<<

// --- ADD 2010/07/08 ---------->>>>>
// 操作権限の制御
function MAHNB01013B_BeginControllingByOperationAuthority(var RevisionVisible: Boolean;
    var DeleteVisible: Boolean;
    var RedSlipVisible: Boolean;
    var SlipDiscountVisible: Boolean) // ADD 2013/01/24 鄧潘ハン REDMINE#34141
    : Integer; stdcall;
// --- ADD 2010/07/08 ----------<<<<<

// add by gaofeng end

// --- ADD 2014/07/15 T.Miyamoto 仕掛一覧 №1912 ---------->>>>>
// 操作権限の判定
function MAHNB01013B_GetOperationSt(iOperationCode: Integer): Boolean; stdcall;
// --- ADD 2014/07/15 T.Miyamoto 仕掛一覧 №1912 ----------<<<<<

// add by lizc begin
// 最新情報処理
function MAHNB01013B_ReNewalBtnClick(enterpriseCode: WideString;
  loginSectionCode: WideString): Integer; stdcall;

// xxxxx
function MAHNB01013B_ProcessingDialogDispose(): Integer; stdcall;
// add by lizc end

// --- ADD m.suzuki 2010/06/12 ---------->>>>>
procedure MAHNB01013B_MakeQR( sParam: WideString ); stdcall;
// --- ADD m.suzuki 2010/06/12 ----------<<<<<
// --- ADD m.suzuki 2010/06/16 ---------->>>>>
function MAHNB01013B_GetOnlineFlag(): Boolean; stdcall;
// --- ADD m.suzuki 2010/06/16 ----------<<<<<

//>>>2010/05/30
function MAHNB01013B_ReferenceList(isDataChanged: Boolean; var isSave: Integer)
  : Integer; stdcall;
//----- ADD　2018/09/04 譚洪　履歴自動表示の対応------->>>>>
function MAHNB01013B_HisSearch(salesRowNo: Integer)
  : Integer; stdcall;
//----- ADD　2018/09/04 譚洪　履歴自動表示の対応-------<<<<<
//----- ADD　ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応------->>>>>
function MAHNB01013B_GetTaxRate()
  : Integer; stdcall;
function MAHNB01013B_GetTaxRateDialogResult(var taxRateDialogResult: Integer)
  : Integer; stdcall;
function MAHNB01013B_OrderCheck(mode: Integer; var orderFlg : Boolean )
  : Integer; stdcall;
//----- ADD　ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応-------<<<<<
// --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応 ----->>>>>
function MAHNB01013B_StartEBooks()
  : Integer; stdcall;
// --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応 -----<<<<<
// 2011/01/31 >>>
//function MAHNB01013B_SettingParameter(param1:WideString; param2:WideString)
//  : Integer; stdcall;
function MAHNB01013B_SettingParameter(param1:WideString; param2:WideString; param3:WideString)
  : Integer; stdcall;
// 2011/01/31 <<<
function MAHNB01013B_TimerSCMReadTick(var ret : Boolean; var customerCode : Integer)
  : Integer; stdcall;
function MAHNB01013B_GetSobaInfo()
  : Integer; stdcall;
//<<<2010/05/30

//>>>2010/08/30
function MAHNB01013B_ExistTaxRateRangeMethod(salesdate : Integer)
  : Integer; stdcall;
//<<<2010/08/30

//>>>2011/02/01
function MAHNB01013B_ExistSCMInfo(var ret : Boolean; salesSlipNum: WideString; salesRowNo: Integer)
  : Integer; stdcall;
//<<<2011/02/01
// --- ADD 黄興貴 2015/04/29 ---------------->>>>>
// UOEデータ取込
function MAHNB01013B_ReadUoeData(salesRowNo: Integer)
    : Integer; stdcall;
// 富士ジーワイ商事㈱オプション判定
function MAHNB01013B_OptPermitForFuJi(var optPermitForFuJi: Boolean)
    : Integer; stdcall;

// --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- >>>>>
function MAHNB01013B_OptPermitForKoei(var optPermitForKoei: Boolean)
    : Integer; stdcall;
// --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- <<<<<

// --- ADD 黄興貴 2015/04/29 ----------------<<<<<
// --- ADD 紀飛 2015/06/18 WebUOE発注回答取込---------------->>>>>
// ㈱メイゴオプション判定
function MAHNB01013B_OptPermitForMeiGo(var optPermitForMeiGo: Boolean)
    : Integer; stdcall;
// --- ADD 紀飛 2015/06/18 WebUOE発注回答取込----------------<<<<<
// --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応--->>>>>
// 電子帳簿連携オプションプション判定
function MAHNB01013B_OptPermitForEBooks(var optPermitForEBooks: Boolean)
    : Integer; stdcall;
// --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応---<<<<<

//>>>2011/03/04
procedure MAHNB01013B_SettingEmpInfo(); stdcall;
//<<<2011/03/04

// ------  ADD K2015/04/01 高騁 森川部品個別依頼------->>>>>
// 全拠点在庫情報一覧
function MAHNB01013B_ReadAllSecStockInfo(makerCd: Integer;
    goodsNo: WideString;
    goodsName: WideString;
    isOpenPressed: Boolean;
    isClose: Boolean;
    var message: WideString)
    : Integer; stdcall;
// 森川個別オプション判定
function MAHNB01013B_OptPermitForMoriKawa(var optPermitForMoriKawa: Boolean)
    : Integer; stdcall;
// ------  ADD K2015/04/01 高騁 森川部品個別依頼-------<<<<<

// --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- >>>>>
// 売価算出処理
function MAHNB01013B_SalesUnPrcCalc
  (salesRowNo: Integer; var salesUnPrice: WideString): Integer; stdcall;
// --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- <<<<<

implementation

// add by tanh
// 得意先ガイド処理
function MAHNB01013B_Clear(isConfirm: Boolean; keepAcptAnOdrStatus: Boolean;
  keepDate: Boolean; keepFooterInfo: Boolean; keepCustomer: Boolean;
  keepSalesDate: Boolean; keepDetailRowCount: Boolean; customerCode: Integer): Boolean;
  stdcall;

var
  status: Boolean;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := True;

  try
    try
      // 結果データを初期化

      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_Clear
        (isConfirm, keepAcptAnOdrStatus, keepDate, keepFooterInfo,
        keepCustomer, keepSalesDate,keepDetailRowCount, customerCode);
      // 結果コピー

      // 結果を設定
      Result := status;
      // 例外処理
    except
      on ex: Exception do
      begin
        // 例外発生時はエラーメッセージを戻す
//        Result := -1;
      end;
    end;
  finally
    // ラッパークラス側から渡されたメモリを解放

    // メッセージのメモリ解放
  end;
end;

 // 品番検索処理
function MAHNB01013B_AfterGoodsNoUpdate(rowIndex: Integer;
    cellValue: WideString;
    makerCd: Integer;         //ADD 連番729 2011/08/18
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
//            status := gpxDelphiSalesSlipInputAcs_AfterGoodsNoUpdate(rowIndex, cellValue, salesRowNo);   // DEL 連番729 2011/08/18
            status := gpxDelphiSalesSlipInputAcs_AfterGoodsNoUpdate(rowIndex, cellValue, makerCd, salesRowNo);  //ADD 連番729 2011/08/18
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

// 設定処理
function MAHNB01013B_SetSalesDetailData(inputdata: WideString;
    inputType: Integer)
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
            status := gpxDelphiSalesSlipInputAcs_SetSalesDetailData(inputdata, inputType);
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

// 明細データ取得
function MAHNB01013B_GetSalesAllDetailDataTable(var refSalesDetailList: TSalesSlipInputCustomArrayA2)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesDetailList: TSalesSlipInputCustomArrayA2;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            refSalesDetailList.Csafield1 := nil;
            refSalesDetailList.Csafield1Count := 0;

            // 検索メソッド呼出し
            status := gpxDelphiSalesSlipInputAcs_GetSalesAllDetailDataTable(refSalesDetailList, resultSalesDetailList);
            // 結果コピー
            refSalesDetailList := resultSalesDetailList;

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
        gpxDelphiSalesSlipInputAcs_FreeCustomArrayA2(@resultSalesDetailList, 0);

        // メッセージのメモリ解放
    end;
end;

// 行値引き処理
function MAHNB01013B_uButtonLineDiscountClick(parmRowIndex: Integer)
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
            status := gpxDelphiSalesSlipInputAcs_uButtonLineDiscountClick(parmRowIndex);
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

// 終了設定処理
// --- UPD m.suzuki 2010/06/12 ---------->>>>>
//function MAHNB01013B_Close(isConfirmFlg: Boolean;
//    var canCloseFlg: Boolean)
//    : Integer; stdcall;
function MAHNB01013B_Close(isConfirmFlg: Boolean;
    var canCloseFlg: Boolean; var isMakeQR: Boolean)
    : Integer; stdcall;
// --- UPD m.suzuki 2010/06/12 ----------<<<<<
var
    status: Integer;
    resultCanCloseFlg: Boolean;
    // --- ADD m.suzuki 2010/06/12 ---------->>>>>
    resultIsMakeQR: Boolean;
    // --- ADD m.suzuki 2010/06/12 ----------<<<<<

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // --- ADD m.suzuki 2010/06/12 ---------->>>>>
            resultIsMakeQR := isMakeQR;
            // --- ADD m.suzuki 2010/06/12 ----------<<<<<

            // 検索メソッド呼出し
            // --- UPD m.suzuki 2010/06/12 ---------->>>>>
            //status := gpxDelphiSalesSlipInputAcs_Close(isConfirmFlg, resultCanCloseFlg);
            status := gpxDelphiSalesSlipInputAcs_Close(isConfirmFlg, resultCanCloseFlg, resultIsMakeQR);
            // --- UPD m.suzuki 2010/06/12 ----------<<<<<
            // 結果コピー
            canCloseFlg := resultCanCloseFlg;
            // --- ADD m.suzuki 2010/06/12 ---------->>>>>
            isMakeQR := resultIsMakeQR;
            // --- ADD m.suzuki 2010/06/12 ----------<<<<<

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

// 伝票区分コンボエディタアイテム設定処理
function MAHNB01013B_GetItemtSalesSlipCd(var setItemtSalesSlipCdDisp: Integer;
  var setItemtSalesSlipCdFlg: Integer): Integer; stdcall;

var
  status: Integer;
  resultSetItemtSalesSlipCdDisp: Integer;
  resultSetItemtSalesSlipCdFlg: Integer;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;
  setItemtSalesSlipCdDisp := 0;
  setItemtSalesSlipCdFlg := 0;

  try
    try
      // 結果データを初期化
      resultSetItemtSalesSlipCdDisp := 0;
      resultSetItemtSalesSlipCdFlg := 0;

      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_GetItemtSalesSlipCd
        (resultSetItemtSalesSlipCdDisp, resultSetItemtSalesSlipCdFlg);
      // 結果コピー
      setItemtSalesSlipCdDisp := resultSetItemtSalesSlipCdDisp;
      setItemtSalesSlipCdFlg := resultSetItemtSalesSlipCdFlg;

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

// 追加情報タブ項目Visible設定
function MAHNB01013B_GetAddInfoVisible(var ctTabKeyAddInfo: Integer;
  var settingAddInfoVisibleFlg: Integer): Integer; stdcall;

var
  status: Integer;
  resultCtTabKeyAddInfo: Integer;
  resultSettingAddInfoVisibleFlg: Integer;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;
  ctTabKeyAddInfo := 0;
  settingAddInfoVisibleFlg := 0;

  try
    try
      // 結果データを初期化
      resultCtTabKeyAddInfo := 0;
      resultSettingAddInfoVisibleFlg := 0;

      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_GetAddInfoVisible
        (resultCtTabKeyAddInfo, resultSettingAddInfoVisibleFlg);
      // 結果コピー
      ctTabKeyAddInfo := resultCtTabKeyAddInfo;
      settingAddInfoVisibleFlg := resultSettingAddInfoVisibleFlg;

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
// ESC処理
function MAHNB01013B_uButtonEscClick(var escFlg: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultEscFlg: Boolean;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try

            // 検索メソッド呼出し
            status := gpxDelphiSalesSlipInputAcs_uButtonEscClick(resultEscFlg);
            // 結果コピー
            escFlg := resultEscFlg;
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

    // --- ADD 2012/05/31 No.282---------->>>>>
// ESC処理2（発注解除）
function MAHNB01013B_uButtonEscClick2(var escFlg: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultEscFlg: Boolean;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try

            // 検索メソッド呼出し
            status := gpxDelphiSalesSlipInputAcs_uButtonEscClick2(resultEscFlg);
            // 結果コピー
            escFlg := resultEscFlg;
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
// 発注退避処理
function MAHNB01013B_SaveOrderInfo(var escFlg: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultEscFlg: Boolean;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try

            // 検索メソッド呼出し
            status := gpxDelphiSalesSlipInputAcs_SaveOrderInfo(resultEscFlg);
            // 結果コピー
            escFlg := resultEscFlg;
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
    // --- ADD 2012/05/31 No.282----------<<<<<

// 各種マスタチェック
function MAHNB01013B_InitMstCheck(var mstCheckFlg: Boolean): Integer; stdcall;

var
  status: Integer;
  resultMstCheckFlg: Boolean;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;

  try
    try
      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_InitMstCheck(resultMstCheckFlg);

      mstCheckFlg := resultMstCheckFlg;
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

// 備考設定処理
function MAHNB01013B_GetNoteGuidList(enterpriseCode: WideString)
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
            status := gpxDelphiSalesSlipInputAcs_GetNoteGuidList(enterpriseCode);
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

// 元に戻す処理
function MAHNB01013B_Retry(isConfirm: Boolean;
    var dialogResultFlg: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultDialogResultFlg: Boolean;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 検索メソッド呼出し
            status := gpxDelphiSalesSlipInputAcs_Retry(isConfirm, resultDialogResultFlg);
            // 結果コピー
            dialogResultFlg := resultDialogResultFlg;

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

// HOMEキー設定処理
function MAHNB01013B_SetHomeKeyFlg(homeKeyFlg: Boolean)
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
            status := gpxDelphiSalesSlipInputAcs_SetHomeKeyFlg(homeKeyFlg);
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

// 元に戻す処理
function MAHNB01013B_RetryResult(var statusFlg: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultStatusFlg: Boolean;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try

            // 検索メソッド呼出し
            status := gpxDelphiSalesSlipInputAcs_RetryResult(resultStatusFlg);
            // 結果コピー
            statusFlg := resultStatusFlg;

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


// 伝票区分コンボエディタアイテム設定処理
function MAHNB01013B_GetDisplayHeaderFooterInfo(
  var inputModeTitle: WideString; var defaultSalesSlipNumDf: WideString;
  var searchPartsModeFlg: Integer; var operationCodeFlg: Integer): Integer;
  stdcall;

var
  status: Integer;
  resultInputModeTitle: WideString;
  resultDefaultSalesSlipNumDf: WideString;
  resultSearchPartsModeFlg: Integer;
  resultOperationCodeFlg: Integer;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;
  inputModeTitle := '';
  defaultSalesSlipNumDf := '';
  searchPartsModeFlg := 0;
  operationCodeFlg := 0;

  try
    try
      // 結果データを初期化
      resultInputModeTitle := '';
      resultDefaultSalesSlipNumDf := '';
      resultSearchPartsModeFlg := 0;
      resultOperationCodeFlg := 0;

      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_GetDisplayHeaderFooterInfo
        (resultInputModeTitle, resultDefaultSalesSlipNumDf,
        resultSearchPartsModeFlg, resultOperationCodeFlg);
      // 結果コピー
      inputModeTitle := resultInputModeTitle;
      defaultSalesSlipNumDf := resultDefaultSalesSlipNumDf;
      searchPartsModeFlg := resultSearchPartsModeFlg;
      operationCodeFlg := resultOperationCodeFlg;

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

// 得意先情報画面格納処理
function MAHNB01013B_GetDisplayCustomerInfo(var customerNameFlg: Integer;
  var totalDayDf: WideString; var collectMoneyDf: WideString): Integer; stdcall;

var
  status: Integer;
  resultCustomerNameFlg: Integer;
  resultTotalDayDf: WideString;
  resultCollectMoneyDf: WideString;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;
  customerNameFlg := 0;
  totalDayDf := '';
  collectMoneyDf := '';

  try
    try
      // 結果データを初期化
      resultCustomerNameFlg := 0;
      resultTotalDayDf := '';
      resultCollectMoneyDf := '';

      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_GetDisplayCustomerInfo
        (resultCustomerNameFlg, resultTotalDayDf, resultCollectMoneyDf);
      // 結果コピー
      customerNameFlg := resultCustomerNameFlg;
      totalDayDf := resultTotalDayDf;
      collectMoneyDf := resultCollectMoneyDf;

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

// 明細データ取得
function MAHNB01013B_SetUserGdBdComboEditor
  (var guideCodeList: TWideStringArray; var guideNameList: TWideStringArray)
  : Integer; stdcall;

var
  status: Integer;
  resultGuideCodeList: PWideString;
  currentCodePtr: PWideString;
  resultGuideCodeCount: Integer;
  resultGuideNameList: PWideString;
  currentNamePtr: PWideString;
  resultGuideNameCount: Integer;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;

  resultGuideCodeCount := 0;
  resultGuideNameCount := 0;

  try
    try
      // 結果データを初期化

      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_SetUserGdBdComboEditor
        (resultGuideCodeList, resultGuideCodeCount, resultGuideNameList,
        resultGuideNameCount);
      // 結果コピー
      if (resultGuideCodeList <> nil) and (resultGuideCodeCount > 0) then
      begin
        // 結果参照用ポインタへコピー
        currentCodePtr := resultGuideCodeList;

        // コピー処理
        SetLength(guideCodeList, resultGuideCodeCount);

        for I := 0 to resultGuideCodeCount - 1 do
        begin
          // 構造体をコピー
          guideCodeList[I] := currentCodePtr^;

          Inc(currentCodePtr);
        end;
      end;

      if (resultGuideNameList <> nil) and (resultGuideNameCount > 0) then
      begin
        // 結果参照用ポインタへコピー
        currentNamePtr := resultGuideNameList;

        // コピー処理
        SetLength(guideNameList, resultGuideNameCount);

        for I := 0 to resultGuideNameCount - 1 do
        begin
          // 構造体をコピー
          guideNameList[I] := currentNamePtr^;

          Inc(currentNamePtr);
        end;
      end;

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

// 商品値引き処理
function MAHNB01013B_uButtonGoodsDiscountClick(parmRowIndex: Integer)
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
            status := gpxDelphiSalesSlipInputAcs_uButtonGoodsDiscountClick(parmRowIndex);
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

// 注釈処理
function MAHNB01013B_uButtonAnnotationClick(parmRowIndex: Integer)
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
            status := gpxDelphiSalesSlipInputAcs_uButtonAnnotationClick(parmRowIndex);
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

// 倉庫切替処理
function MAHNB01013B_uButtonChangeWarehouseClick(parmSalesRowNo: Integer)
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
            status := gpxDelphiSalesSlipInputAcs_uButtonChangeWarehouseClick(parmSalesRowNo);
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

// 在庫検索処理
function MAHNB01013B_uButtonStockSearchClick(parmRowIndex: Integer)
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
            status := gpxDelphiSalesSlipInputAcs_uButtonStockSearchClick(parmRowIndex);
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

// ＴＢＯ処理
function MAHNB01013B_uButtonTBOClick(parmRowIndex: Integer)
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
            status := gpxDelphiSalesSlipInputAcs_uButtonTBOClick(parmRowIndex);
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

// 前行複写処理
function MAHNB01013B_uButtonCopyStockBefLineClick(parmRowIndex: Integer)
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
            status := gpxDelphiSalesSlipInputAcs_uButtonCopyStockBefLineClick(parmRowIndex);
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

// 一括複写処理
function MAHNB01013B_uButtonCopyStockAllLineClick(parmRowIndex: Integer)
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
            status := gpxDelphiSalesSlipInputAcs_uButtonCopyStockAllLineClick(parmRowIndex);
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

// 小数点表示区分処理
function MAHNB01013B_SmallPointProc(rowIndexParm: Integer)
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
            status := gpxDelphiSalesSlipInputAcs_SmallPointProc(rowIndexParm);
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

// セルEnabled設定取得処理
function MAHNB01013B_GetCellEnabled(keyName: WideString): Integer; stdcall;

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
      status := gpxDelphiSalesSlipInputAcs_GetCellEnabled(keyName);
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

// グリッドセルアップデート後処理
function MAHNB01013B_uGridDetailsAfterCellUpdate(rowIndexParm: Integer;
    cellValue: WideString;
    beforeCellValue: WideString;
    columnName: WideString)
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
            status := gpxDelphiSalesSlipInputAcs_uGridDetailsAfterCellUpdate(rowIndexParm, cellValue, beforeCellValue, columnName);
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

// グリッドセルアップデート後処理
function MAHNB01013B_uGridDetailsAfterCellUpdateProc(rowIndexParm: Integer;
    cellValue: WideString;
    beforeCellValue: WideString;
    columnName: WideString)
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
            status := gpxDelphiSalesSlipInputAcs_uGridDetailsAfterCellUpdateProc(rowIndexParm, cellValue, beforeCellValue, columnName);
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

// グリッド関連チェック処理
function MAHNB01013B_GridJoinCheck(salesRowNo: Integer;
    rowIndex: Integer;
    operationCode: Integer;
    mode: Integer)
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
            status := gpxDelphiSalesSlipInputAcs_GridJoinCheck(salesRowNo, rowIndex, operationCode, mode);
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

// Table処理
function MAHNB01013B_DeatilActionTable(salesRowNo: Integer;
    actionType: WideString)
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
            status := gpxDelphiSalesSlipInputAcs_DeatilActionTable(salesRowNo, actionType);
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

// 得意先注番のフォーカス処理
function MAHNB01013B_AfterPartySaleSlipNumFocus(var refSalesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    value: WideString;
    var dialogFlag: Boolean)
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
            status := gpxDelphiSalesSlipInputAcs_AfterPartySaleSlipNumFocus(refSalesSlip, resultSalesSlip, salesSlipCurrent, value, dialogFlag);
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
// end add by tanh

// add by zhangkai

// ガイドボタンクリックイベント処理
function MAHNB01013B_uButtonGuideClick(rowIndexParm: Integer;
    columnName: WideString)
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
            status := gpxDelphiSalesSlipInputAcs_uButtonGuideClick(rowIndexParm, columnName);
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

// 移動位置取得処理(Enterキー移動時)
function MAHNB01013B_GetNextMovePosition(p: WideString;
    var afterColKeyName: WideString)
    : Integer; stdcall;

var
    status: Integer;
    resultAfterColKeyName: WideString;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;
    afterColKeyName := '';

    try
        try
            // 結果データを初期化
            resultAfterColKeyName := '';

            // 検索メソッド呼出し
            status := gpxDelphiSalesSlipInputAcs_GetNextMovePosition(p, resultAfterColKeyName);
            // 結果コピー
            afterColKeyName := resultAfterColKeyName;

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

// --- ADD 2010/06/02 ---------->>>>>
// 移動位置取得処理(Enterキー移動時)
function MAHNB01013B_GetPreMovePosition(p: WideString;
    var afterColKeyName: WideString)
    : Integer; stdcall;

var
    status: Integer;
    resultAfterColKeyName: WideString;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;
    afterColKeyName := '';

    try
        try
            // 結果データを初期化
            resultAfterColKeyName := '';

            // 検索メソッド呼出し
            status := gpxDelphiSalesSlipInputAcs_GetPreMovePosition(p, resultAfterColKeyName);
            // 結果コピー
            afterColKeyName := resultAfterColKeyName;

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
// --- ADD 2010/06/02 ----------<<<<<

// Param取得処理
function MAHNB01013B_GetParam(var startKeyName: WideString;
    var endKeyNameList: WideString)
    : Integer; stdcall;

var
    status: Integer;
    resultStartKeyName: WideString;
    resultEndKeyNameList: WideString;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;
    startKeyName := '';
    endKeyNameList := '';

    try
        try
            // 結果データを初期化
            resultStartKeyName := '';
            resultEndKeyNameList := '';

            // 検索メソッド呼出し
            status := gpxDelphiSalesSlipInputAcs_GetParam(resultStartKeyName, resultEndKeyNameList);
            // 結果コピー
            startKeyName := resultStartKeyName;
            endKeyNameList := resultEndKeyNameList;

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

 // フォーカス移動対象判定処理
function MAHNB01013B_GetEffectiveJudgment(keyName: WideString)
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
            status := gpxDelphiSalesSlipInputAcs_GetEffectiveJudgment(keyName);
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

// チェック処理
function MAHNB01013B_CheckDetailAction(beforeRowIndex: Integer;
    parmRowIndex: Integer;
    checkType: Integer)
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
            status := gpxDelphiSalesSlipInputAcs_CheckDetailAction(beforeRowIndex, parmRowIndex, checkType);
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

// ユーザー設定処理
function MAHNB01013B_GetSalesSlipInputConstructionData(var data: Integer;
    inputType: Integer)
    : Integer; stdcall;

var
    status: Integer;
    resultData: Integer;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;
    data := 0;

    try
        try
            // 結果データを初期化
            resultData := 0;

            // 検索メソッド呼出し
            status := gpxDelphiSalesSlipInputAcs_GetSalesSlipInputConstructionData(resultData, inputType);
            // 結果コピー
            data := resultData;

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

// 伝票メモ情報設定処理
function MAHNB01013B_SetSlipMemo(slipMemo1: WideString;
    slipMemo2: WideString;
    slipMemo3: WideString;
    insideMemo1: WideString;
    insideMemo2: WideString;
    insideMemo3: WideString;
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
            status := gpxDelphiSalesSlipInputAcs_SetSlipMemo(slipMemo1, slipMemo2, slipMemo3, insideMemo1, insideMemo2, insideMemo3, salesRowNo);
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

// 数値入力チェック処理
function MAHNB01013B_KeyPressNumCheck(keta: Integer;
    priod: Integer;
    prevVal: WideString;
    key: WideString;
    selstart: Integer;
    sellength: Integer;
    minusFlg: Boolean)
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
            status := gpxDelphiSalesSlipInputAcs_KeyPressNumCheck(keta, priod, prevVal, key, selstart, sellength, minusFlg);
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


// CSV出力先が設定され、フォルダが存在しているかチェック処理
function MAHNB01013B_CsvPassCheck(var linkDir: WideString)
    : Integer; stdcall;

var
    status: Integer;
    resultLinkDir: WideString;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;
    linkDir := '';

    try
        try
            // 結果データを初期化
            resultLinkDir := '';

            // 検索メソッド呼出し
            status := gpxDelphiSalesSlipInputAcs_CsvPassCheck(resultLinkDir);
            // 結果コピー
            linkDir := resultLinkDir;

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

// オプション情報処理
function MAHNB01013B_FormPosSerialize(topInt: Integer;
    leftInt: Integer;
    heightInt: Integer;
    widthInt: Integer)
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
            status := gpxDelphiSalesSlipInputAcs_FormPosSerialize(topInt, leftInt, heightInt, widthInt);
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
// end add by zhangkai

// --- ADD 2011/02/12 ---- >>>>>
// 調査用ログ出力クラス処理
function MAHNB01013B_DoAddLine(logNo: Integer;
    slipNo: Integer;
    acptAnOdrStatus: Integer)
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
            status := gpxDelphiSalesSlipInputAcs_DoAddLine(logNo, slipNo, acptAnOdrStatus);
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

// 調査用ログImage出力処理
function MAHNB01013B_DoCacheImage()
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
            status := gpxDelphiSalesSlipInputAcs_DoCacheImage();
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

// 各種マスタチェック
function MAHNB01013B_GetErrorFlag(var errorFlag: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultErrorFlag: Boolean;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            resultErrorFlag := errorFlag;

            // 検索メソッド呼出し
            status := gpxDelphiSalesSlipInputAcs_GetErrorFlag(resultErrorFlag);
            // 結果コピー
            errorFlag := resultErrorFlag;

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
// --- ADD 2011/02/12 ---- <<<<<

// --- ADD 2011/11/22 ---------->>>>>
// 連携判断処理
function MAHNB01013B_CooprtKindDiv(var CooprtFlag: Boolean)
    : Integer; stdcall;
var
    status: Integer;
    resultCooprtFlag: Boolean;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            resultCooprtFlag := CooprtFlag;
            // 検索メソッド呼出し
            status := gpxDelphiSalesSlipInputAcs_CooprtKindDiv(resultCooprtFlag);
            // 結果コピー
            CooprtFlag := resultCooprtFlag;
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
// --- ADD 2011/11/22 ----------<<<<<

// --- ADD 2011/04/13 ---- >>>>>
// 選択済み売上行番号削除処理（多行削除場合用）
function MAHNB01013B_DetailDeleteActionTable(startRowNo: Integer;
    endRowNo: Integer)
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
            status := gpxDelphiSalesSlipInputAcs_DetailDeleteActionTable(startRowNo, endRowNo);
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
// --- ADD 2011/04/13 ---- <<<<<

// --- ADD 2011/05/30 ---- >>>>>
// 画面の拠点コード変化時（キャンペーン情報取得用）
function MAHNB01013B_SetSectionCode(sectionCode: WideString)
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
            status := gpxDelphiSalesSlipInputAcs_SetSectionCode(sectionCode);
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
// --- ADD 2011/05/30 ---- <<<<<

// --- ADD 2011/07/18 ---- >>>>>
// 現在庫数を調整します
function MAHNB01013B_StockInfoAdjust()
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
            status := gpxDelphiSalesSlipInputAcs_StockInfoAdjust();
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
// --- ADD 2011/07/18 ---- <<<<<

// add by yangmj

// 出荷計上処理
function MAHNB01013B_ShipmentAddUp(isDataChanged: Boolean; var isSave: Integer)
  : Integer; stdcall;

var
  status: Integer;
  resultIsSave: Integer;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;

  try
    try
      // 結果データを初期化
      // ClearTSalesSlip(resultSalesSlip);
      resultIsSave := 2;
      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_ShipmentAddUp
        (isDataChanged, resultIsSave);
      // 結果コピー
      isSave := resultIsSave;

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

// 出荷照会ボタンクリック処理
function MAHNB01013B_GetSalesHisGuide(count: Integer; CustomerCode: WideString)
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
      status := gpxDelphiSalesSlipInputAcs_GetSalesHisGuide
        (count, CustomerCode);
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

// 受注照会(明細選択)
function MAHNB01013B_AcceptAnOrderReferenceSearch(rowCount: Integer;
  CustomerCode: WideString): Integer; stdcall;

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
      status := gpxDelphiSalesSlipInputAcs_AcceptAnOrderReferenceSearch
        (rowCount, CustomerCode);
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


// --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ---------->>>>>
//第二売価ガイドの位置を設定します。
function MAHNB01013B_SetSecondSalesUnPrcGideLocation(locationLeft: Integer;
    locationTop: Integer)
    : Integer; stdcall;

var
    status: Integer;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try

            // 設定メソッド呼出し
            status := gpxDelphiSalesSlipInputAcs_SetSecondSalesUnPrcGideLocation(locationLeft, locationTop);

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

// 水野商工㈱オプション判定
function MAHNB01013B_OptPermitForMizuno2ndSellPriceCtl(var optPermitForMizuno2ndSellPriceCtl: Boolean)
    : Integer; stdcall;

var
    status: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try

            // 検索メソッド呼出し
            status := gpxDelphiSalesSlipInputAcs_OptPermitForMizuno2ndSellPriceCtl(optPermitForMizuno2ndSellPriceCtl);

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
// --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ----------<<<<<



// 保存用設定処理
function MAHNB01013B_SetAfterSaveData(resultData: Integer;
    carMngCode: WideString;
    printSlipFlag: Boolean;
    isMakeQR: Boolean;
    scmFlg: Boolean;
    cmtFlag: Boolean;
    // ----- ADD K2011/12/09 --------->>>>>
    slipNote2ErrFlag: Boolean;
    // UPD 2013/03/28 SCM障害№192対応 ---------------->>>>>
    //salesDateErrFlag: Boolean)
    salesDateErrFlag: Boolean;
    isSCMSave: Integer)
    // UPD 2013/03/28 SCM障害№192対応 ----------------<<<<<
    // ----- ADD K2011/12/09 ---------<<<<<
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
            // UPD 2013/03/28 SCM障害№192対応 ---------------->>>>>
            //status := gpxDelphiSalesSlipInputAcs_SetAfterSaveData(resultData, carMngCode, printSlipFlag, isMakeQR, scmFlg, cmtFlag, slipNote2ErrFlag, salesDateErrFlag); // ADD K2011/12/09
            status := gpxDelphiSalesSlipInputAcs_SetAfterSaveData(resultData, carMngCode, printSlipFlag, isMakeQR, scmFlg, cmtFlag, slipNote2ErrFlag, salesDateErrFlag, isSCMSave);
            // UPD 2013/03/28 SCM障害№192対応 ----------------<<<<<
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

// 保存用設定処理
function MAHNB01013B_GetAfterSaveData(var resultData: Integer;
    var isMakeQR: Boolean;
    var scmFlg: Boolean;
    var cmtFlag: Boolean;
    // ----- ADD K2011/12/09 --------->>>>>
    var slipNote2ErrFlag: Boolean;
    // UPD 2013/03/28 SCM障害№192対応 ---------------->>>>>
    //var salesDateErrFlag: Boolean)
    var salesDateErrFlag: Boolean;
    var isSCMSave: Integer)
    // UPD 2013/03/28 SCM障害№192対応 ----------------<<<<<
    // ----- ADD K2011/12/09 ---------<<<<<
    : Integer; stdcall;

var
    status: Integer;
    resultResultData: Integer;
    resultIsMakeQR: Boolean;
    resultScmFlg: Boolean;
    resultCmtFlag: Boolean;
    // ----- ADD K2011/12/09 --------->>>>>
    resultSlipNote2ErrFlag: Boolean;
    resultSalesDateErrFlag: Boolean;
    // ----- ADD K2011/12/09 ---------<<<<<
    // ADD 2013/03/28 SCM障害№192対応 ---------------->>>>>
    resultisSCMSave: Integer;
    // ADD 2013/03/28 SCM障害№192対応 ----------------<<<<<

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            resultResultData := 0;
            resultIsMakeQR := isMakeQR;
            resultScmFlg := scmFlg;
            resultCmtFlag := cmtFlag;
            // ----- ADD K2011/12/09 --------->>>>>
            resultSlipNote2ErrFlag := slipNote2ErrFlag;
            resultSalesDateErrFlag := salesDateErrFlag;
            // ----- ADD K2011/12/09 ---------<<<<<
            // ADD 2013/03/28 SCM障害№192対応 ---------------->>>>>
            resultisSCMSave := isSCMSave;
            // ADD 2013/03/28 SCM障害№192対応 ----------------<<<<<

            // 検索メソッド呼出し
            //status := gpxDelphiSalesSlipInputAcs_GetAfterSaveData(resultResultData, resultIsMakeQR, resultScmFlg, resultCmtFlag); // DEL K2011/12/09
            // UPD 2013/03/28 SCM障害№192対応 ---------------->>>>>
            //status := gpxDelphiSalesSlipInputAcs_GetAfterSaveData(resultResultData, resultIsMakeQR, resultScmFlg, resultCmtFlag, resultSlipNote2ErrFlag, resultSalesDateErrFlag);  // ADD K2011/12/09
            status := gpxDelphiSalesSlipInputAcs_GetAfterSaveData(resultResultData, resultIsMakeQR, resultScmFlg, resultCmtFlag, resultSlipNote2ErrFlag, resultSalesDateErrFlag, resultisSCMSave);
            // UPD 2013/03/28 SCM障害№192対応 ----------------<<<<<
            // 結果コピー
            resultData := resultResultData;
            isMakeQR := resultIsMakeQR;
            scmFlg := resultScmFlg;
            cmtFlag := resultCmtFlag;
            // ----- ADD K2011/12/09 --------->>>>>
            slipNote2ErrFlag := resultSlipNote2ErrFlag;
            salesDateErrFlag := resultSalesDateErrFlag;
            // ----- ADD K2011/12/09 ---------<<<<<
            // ADD 2013/03/28 SCM障害№192対応 ---------------->>>>>
            isSCMSave := resultisSCMSave;
            // ADD 2013/03/28 SCM障害№192対応 ----------------<<<<<

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

// 保存用設定処理
function MAHNB01013B_DoAfterSave()
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
            status := gpxDelphiSalesSlipInputAcs_DoAfterSave();
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

// --- ADD 2012/10/15 ------------->>>>>
//仕入日のエラーメッセージを表示処理
function MAHNB01013B_ShowStockDateMsg()
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
            status := gpxDelphiSalesSlipInputAcs_ShowStockDateMsg();
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
// --- ADD 2012/10/15 -------------<<<<<<

// 受注計上処理
function MAHNB01013B_AcceptAnOrderAddup(isDataChanged: Boolean;
  var IsResult: Integer): Integer; stdcall;

var
  status: Integer;
  resultIsResult: Integer;
  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;

  try
    try
      // 結果データを初期化
      resultIsResult := 2;
      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_AcceptAnOrderAddup
        (isDataChanged, resultIsResult);
      // 結果コピー
      IsResult := resultIsResult;
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

// 見積計上(明細選択)
function MAHNB01013B_EstimateReferenceSearch(rowCount: Integer;
  CustomerCode: WideString): Integer; stdcall;

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
      status := gpxDelphiSalesSlipInputAcs_EstimateReferenceSearch
        (rowCount, CustomerCode);
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

// 見積照会(伝票選択)
function MAHNB01013B_EstimateAddup(isDataChanged: Boolean;
  var IsResult: Integer): Integer; stdcall;

var
  status: Integer;
  resultIsResult: Integer;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;

  try
    try
      // 結果データを初期化
      resultIsResult := 2;

      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_EstimateAddup
        (isDataChanged, resultIsResult);
      // 結果コピー
      IsResult := resultIsResult;

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

// 履歴照会(売上履歴データから明細選択)
function MAHNB01013B_SalesReferenceSearch(rowCount: Integer;
  CustomerCode: WideString): Integer; stdcall;

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
      status := gpxDelphiSalesSlipInputAcs_SalesReferenceSearch
        (rowCount, CustomerCode);
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

// 伝票複写
function MAHNB01013B_CopySlip(isDataChanged: Boolean; var IsResult: Integer)
  : Integer; stdcall;

var
  status: Integer;
  resultIsResult: Integer;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;

  try
    try
      // 結果データを初期化
      resultIsResult := 2;

      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_CopySlip
        (isDataChanged, resultIsResult);
      // 結果コピー
      IsResult := resultIsResult;

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

// 車両管理オプション取得処理
function MAHNB01013B_GetOptCarMng(var optCarMng: Integer): Integer; stdcall;

var
  status: Integer;
  resultOptCarMng: Integer;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;
  optCarMng := 0;

  try
    try
      // 結果データを初期化
      resultOptCarMng := 0;

      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_GetOptCarMng(resultOptCarMng);
      // 結果コピー
      optCarMng := resultOptCarMng;

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

// 返品理由ガイド処理
function MAHNB01013B_retGoodsReason(enterpriseCode: WideString;
    var userGdHd: TUserGdHd;
    var userGdBd: TUserGdBd;
    var salesSlip: TSalesSlip)
    : Integer; stdcall;

var
    status: Integer;
    resultUserGdHd: TUserGdHd;
    resultUserGdBd: TUserGdBd;
    resultSalesSlip: TSalesSlip;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            ClearTUserGdHd(resultUserGdHd);
            ClearTUserGdBd(resultUserGdBd);
            ClearTSalesSlip(resultSalesSlip);

            // 検索メソッド呼出し
            status := gpxDelphiSalesSlipInputAcs_retGoodsReason(enterpriseCode, resultUserGdHd, resultUserGdBd, resultSalesSlip);
            // 結果コピー
            userGdHd := resultUserGdHd;
            userGdBd := resultUserGdBd;
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

// 伝票備考、伝票備考２、伝票備考３の入力桁数設定処理
function MAHNB01013B_SetNoteCharCnt(var slipNoteCharCnt: Integer;
  var slipNote2CharCnt: Integer; var slipNote3CharCnt: Integer): Integer;
  stdcall;

var
  status: Integer;
  resultSlipNoteCharCnt: Integer;
  resultSlipNote2CharCnt: Integer;
  resultSlipNote3CharCnt: Integer;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;
  slipNoteCharCnt := 0;
  slipNote2CharCnt := 0;
  slipNote3CharCnt := 0;

  try
    try
      // 結果データを初期化
      resultSlipNoteCharCnt := 0;
      resultSlipNote2CharCnt := 0;
      resultSlipNote3CharCnt := 0;

      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_SetNoteCharCnt
        (resultSlipNoteCharCnt, resultSlipNote2CharCnt, resultSlipNote3CharCnt);
      // 結果コピー
      slipNoteCharCnt := resultSlipNoteCharCnt;
      slipNote2CharCnt := resultSlipNote2CharCnt;
      slipNote3CharCnt := resultSlipNote3CharCnt;

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

// 返品処理関係
function MAHNB01013B_ReturnSlip(isDataChanged: Boolean; var IsResult: Integer)
  : Integer; stdcall;

var
  status: Integer;
  resultIsResult: Integer;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;
  IsResult := 0;

  try
    try
      // 結果データを初期化
      resultIsResult := 2;

      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_ReturnSlip
        (isDataChanged, resultIsResult);
      // 結果コピー
      IsResult := resultIsResult;

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

// 保存確認ダイアログ表示処理
// --- UPD m.suzuki 2010/06/12 ---------->>>>>
//function MAHNB01013B_ShowSaveCheckDialog(isConfirm: Boolean;
//  var resultNum: Integer; carMngCode: WideString): Integer; stdcall;
function MAHNB01013B_ShowSaveCheckDialog(isConfirm: Boolean;
  var resultNum: Integer; carMngCode: WideString; var isMakeQR: Boolean): Integer; stdcall;
// --- UPD m.suzuki 2010/06/12 ----------<<<<<
var
  status: Integer;
  resultResultNum: Integer;
  // --- ADD m.suzuki 2010/06/12 ---------->>>>>
  resultIsMakeQR: Boolean;
  // --- ADD m.suzuki 2010/06/12 ----------<<<<<

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;
  resultNum := 0;

  try
    try
      // 結果データを初期化
      resultResultNum := 0;
      // --- ADD m.suzuki 2010/06/12 ---------->>>>>
      resultIsMakeQR := isMakeQR;
      // --- ADD m.suzuki 2010/06/12 ----------<<<<<

      // 検索メソッド呼出し
      // --- UPD m.suzuki 2010/06/12 ---------->>>>>
      //status := gpxDelphiSalesSlipInputAcs_ShowSaveCheckDialog
      //  (isConfirm, resultResultNum, carMngCode);
      status := gpxDelphiSalesSlipInputAcs_ShowSaveCheckDialog
        (isConfirm, resultResultNum, carMngCode, resultIsMakeQR);
      // --- UPD m.suzuki 2010/06/12 ----------<<<<<

      // 結果コピー
      resultNum := resultResultNum;
      // --- ADD m.suzuki 2010/06/12 ---------->>>>>
      isMakeQR := resultIsMakeQR;
      // --- ADD m.suzuki 2010/06/12 ----------<<<<<

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

// 保存処理
// --- UPD m.suzuki 2010/06/12 ---------->>>>>
//function MAHNB01013B_Save(isShowSaveCompletionDialog: Boolean;
//  isConfirm: Boolean): Boolean; stdcall;
function MAHNB01013B_Save(isShowSaveCompletionDialog: Boolean;
  isConfirm: Boolean; var isMakeQR: Boolean): Boolean; stdcall;
// --- UPD m.suzuki 2010/06/12 ----------<<<<<
var
  status: Boolean;
  // --- ADD m.suzuki 2010/06/12 ---------->>>>>
  resultIsMakeQR: Boolean;
  // --- ADD m.suzuki 2010/06/12 ----------<<<<<
  I: Integer;
begin
  // 戻りステータス初期化
  Result := false;

  try
    try
      // 結果データを初期化
      // --- ADD m.suzuki 2010/06/12 ---------->>>>>
      resultIsMakeQR := isMakeQR;
      // --- ADD m.suzuki 2010/06/12 ----------<<<<<

      // 検索メソッド呼出し
      // --- UPD m.suzuki 2010/06/12 ---------->>>>>
      //status := gpxDelphiSalesSlipInputAcs_Save
      //  (isShowSaveCompletionDialog, isConfirm);
      status := gpxDelphiSalesSlipInputAcs_Save
        (isShowSaveCompletionDialog, isConfirm, resultIsMakeQR);
      // --- UPD m.suzuki 2010/06/12 ----------<<<<<

      // 結果コピー
      // --- ADD m.suzuki 2010/06/12 ---------->>>>>
      resultIsMakeQR := isMakeQR;
      // --- ADD m.suzuki 2010/06/12 ----------<<<<<

      // 結果を設定
      Result := status;
      // 例外処理
    except
      on ex: Exception do
      begin
        // 例外発生時はエラーメッセージを戻す
        Result := false;
      end;
    end;
  finally
    // ラッパークラス側から渡されたメモリを解放

  end;
end;

// 保存後処理
// 2011/01/31 >>>
//// --- UPD m.suzuki 2010/06/12 ---------->>>>>
////function MAHNB01013B_AfterSave(var saveResult: Integer;
////    carMngCode: WideString; printSlipFlag: Boolean): Integer; stdcall;
//function MAHNB01013B_AfterSave(var saveResult: Integer;
//    carMngCode: WideString; printSlipFlag: Boolean; var isMakeQR: Boolean; scmFlg: Boolean): Integer; stdcall;
//// --- UPD m.suzuki 2010/06/12 ----------<<<<<

function MAHNB01013B_AfterSave(var saveResult: Integer;
// ----- DEL K2011/09/01 --------------------------->>>>>
//carMngCode: WideString; printSlipFlag: Boolean; var isMakeQR: Boolean; var scmFlg: Boolean; var cmtFlg: Boolean; var slipNote2ErrFlag:Boolean): Integer; stdcall; // UPD K2011/08/12
// ----- DEL K2011/09/01 ---------------------------<<<<<
// ----- ADD K2011/09/01 --------------------------->>>>>
// UPD 2013/03/28 SCM障害№192対応 ----------------------->>>>>
//  carMngCode: WideString; printSlipFlag: Boolean; var isMakeQR: Boolean; var scmFlg: Boolean; var cmtFlg: Boolean; var slipNote2ErrFlag:Boolean ;var salesDateErrFlag:Boolean): Integer; stdcall;
  carMngCode: WideString;
  printSlipFlag: Boolean;
  var isMakeQR: Boolean;
  var scmFlg: Boolean;
  var cmtFlg: Boolean;
  var slipNote2ErrFlag:Boolean;
  var salesDateErrFlag:Boolean;
  var isSCMSave: Integer)
  : Integer; stdcall;
// UPD 2013/03/28 SCM障害№192対応 -----------------------<<<<<
// ----- ADD K2011/09/01 ---------------------------<<<<<


// 2011/01/31 <<<
var
  status: Integer;
  resultSaveResult: Integer;
  // --- ADD m.suzuki 2010/06/12 ---------->>>>>
  resultIsMakeQR: Boolean;
  // --- ADD m.suzuki 2010/06/12 ----------<<<<<
  I: Integer;
// 2011/01/31 >>>
  resultScmFlg: Boolean;
  resultCmtFlg: Boolean;
// 2011/01/31 <<<
  resultSlipNote2ErrFlag: Boolean; // ADD K2011/08/12
  resultSalesDateErrFlag: Boolean; // ADD K2011/09/01
// ADD 2013/03/28 SCM障害№192対応 ----------------------->>>>>
  resultisSCMSave: Integer;
// ADD 2013/03/28 SCM障害№192対応 -----------------------<<<<<
begin
  // 戻りステータス初期化
  Result := -1;
  saveResult := 0;

  try
    try
      // 結果データを初期化
      resultSaveResult := 0;
      // --- ADD m.suzuki 2010/06/12 ---------->>>>>
      resultIsMakeQR := isMakeQR;
      // --- ADD m.suzuki 2010/06/12 ----------<<<<<
// 2011/01/31 >>>
      resultScmFlg := scmFlg;
      resultCmtFlg := false;
// 2011/01/31 <<<
      resultSlipNote2ErrFlag := false; // ADD K2011/08/12
      resultSalesDateErrFlag := false; // ADD K2011/09/01
// ADD 2013/03/28 SCM障害№192対応 ----------------------->>>>>
      resultisSCMSave := 0;
// ADD 2013/03/28 SCM障害№192対応 -----------------------<<<<<

      // 検索メソッド呼出し
// 2011/01/31 >>>
//      // --- UPD m.suzuki 2010/06/12 ---------->>>>>
//      //status := gpxDelphiSalesSlipInputAcs_AfterSave(resultSaveResult, carMngCode, printSlipFlag);
//      status := gpxDelphiSalesSlipInputAcs_AfterSave(resultSaveResult, carMngCode, printSlipFlag, resultIsMakeQR,  scmFlg);
//      // --- UPD m.suzuki 2010/06/12 ----------<<<<<
// ----- DEL K2011/09/01 --------------------------->>>>>
//status := gpxDelphiSalesSlipInputAcs_AfterSave(resultSaveResult, carMngCode, printSlipFlag, resultIsMakeQR, resultScmFlg, resultCmtFlg, resultSlipNote2ErrFlag); // UPD K2011/08/12
// ----- DEL K2011/09/01 ---------------------------<<<<<
// ----- ADD K2011/09/01 --------------------------->>>>>
// UPD 2013/03/28 SCM障害№192対応 ----------------------->>>>>
//status := gpxDelphiSalesSlipInputAcs_AfterSave(resultSaveResult, carMngCode, printSlipFlag, resultIsMakeQR, resultScmFlg, resultCmtFlg, resultSlipNote2ErrFlag ,resultSalesDateErrFlag);
status := gpxDelphiSalesSlipInputAcs_AfterSave(resultSaveResult, carMngCode, printSlipFlag, resultIsMakeQR, resultScmFlg, resultCmtFlg, resultSlipNote2ErrFlag ,resultSalesDateErrFlag, resultisSCMSave);
// UPD 2013/03/28 SCM障害№192対応 -----------------------<<<<<
// ----- ADD K2011/09/01 ---------------------------<<<<<

// 2011/01/31 <<<

      // 結果コピー
      saveResult := resultSaveResult;
      // --- ADD m.suzuki 2010/06/12 ---------->>>>>
      isMakeQR := resultIsMakeQR;
      // --- ADD m.suzuki 2010/06/12 ----------<<<<<
// 2011/01/31 >>>
      scmFlg := resultScmFlg;
      cmtFlg := resultCmtFlg;
// 2011/01/31 <<<
      slipNote2ErrFlag := resultSlipNote2ErrFlag; // ADD K2011/08/12
      salesDateErrFlag := resultSalesDateErrFlag; // ADD K2011/09/01
      // ADD 2013/03/28 SCM障害№192対応 ----------------------->>>>>
      isSCMSave := resultisSCMSave;
      // ADD 2013/03/28 SCM障害№192対応 -----------------------<<<<<
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

// 保存状態取得
function MAHNB01013B_GetSaveStatus(var saveStatus: Integer): Integer; stdcall;

var
  status: Integer;
  resultSaveStatus: Integer;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;
  status := 0;

  try
    try
      // 結果データを初期化
      resultSaveStatus := 0;

      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_GetSaveStatus(resultSaveStatus);
      // 結果コピー
      saveStatus := resultSaveStatus;

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

// --- ADD 2015/12/09 T.Miyamoto リモ伝障害対応 Redmine#47670 ---------->>>>>
// オンライン種別取得
function MAHNB01013B_GetOnlineKindDiv(var onlineKindDiv: Integer): Integer; stdcall;

var
  status: Integer;
  retOnlineKindDiv: Integer;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;
  status := 0;

  try
    try
      // 結果データを初期化
      retOnlineKindDiv := 0;

      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_GetOnlineKindDiv(retOnlineKindDiv);
      // 結果コピー
      onlineKindDiv := retOnlineKindDiv;

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
// --- ADD 2015/12/09 T.Miyamoto リモ伝障害対応 Redmine#47670 ----------<<<<<

// 部品検索切替処理
function MAHNB01013B_ChangeSearchMode(clearCarFlag: Integer;
  CheckRowEffectiveFlg: Boolean; salesRowNo: Integer;
  ContainsFocusFlg: Boolean; var carMngCodeMode: Boolean): Integer; stdcall;

var
  status: Integer;
  resultCarMngCodeMode: Boolean;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;

  try
    try
      // 結果データを初期化
      resultCarMngCodeMode := false;

      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_ChangeSearchMode
        (clearCarFlag, CheckRowEffectiveFlg, salesRowNo, ContainsFocusFlg,
        resultCarMngCodeMode);
      // 結果コピー
      carMngCodeMode := resultCarMngCodeMode;

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

// 部品検索モード取得
function MAHNB01013B_GetSearchPartsModeProperty
  (var searchPartsModeProperty: Integer): Integer; stdcall;

var
  status: Integer;
  resultSearchPartsModeProperty: Integer;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;
  searchPartsModeProperty := 0;

  try
    try
      // 結果データを初期化
      resultSearchPartsModeProperty := 0;

      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_GetSearchPartsModeProperty
        (resultSearchPartsModeProperty);
      // 結果コピー
      searchPartsModeProperty := resultSearchPartsModeProperty;

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

//----ADD 2010/06/17----->>>>>
// 売上データ設定
function MAHNB01013B_SetSalesSlip(Salesslip: TSalesSlip)
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
            //ClearTSalesSlip(Salesslip);
            // 検索メソッド呼出し
            status := gpxDelphiSalesSlipInputAcs_SetSalesSlip(Salesslip);
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
//----ADD 2010/06/17-----<<<<<
// end add by yangmj

//----ADD 2010/11/02----->>>>>
// 売上データ設定
function MAHNB01013B_SetSalesSlipByObj(Salesslip: TSalesSlip)
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
            //ClearTSalesSlip(Salesslip);
            // 検索メソッド呼出し
            status := gpxDelphiSalesSlipInputAcs_SetSalesSlipByObj(Salesslip);
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
//----ADD 2010/11/02-----<<<<<

// add by gaofeng start
// 初期データをＤＢより取得の処理
function MAHNB01013B_GetInitData(): Integer; stdcall;

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
      status := gpxDelphiGetSalesSlipInputInitDataAcs_GetInitData();
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

// 売上伝票ガイド処理
function MAHNB01013B_salesSlipGuide(formName: WideString;
  enterpriseCode: WideString; acptAnOdrStatusDisplay: Integer;
  var refAcptAnOdrStatus: Integer; var estimateDivide: Integer;
  var searchResult: TSalesSlipSearchResult; var salesSlip: TSalesSlip;
  var outDialogResult: Boolean; var outStatus: Boolean;
  var consTaxLayMethodChangedFlg: Boolean;
  var isPCCUOESaleSlip: Boolean) //ADD 2011/11/18
  : Integer; stdcall;
var
  status: Integer;
  resultAcptAnOdrStatus: Integer;
  resultEstimateDivide: Integer;
  resultSearchResult: TSalesSlipSearchResult;
  resultSalesSlip: TSalesSlip;
  resultOutDialogResult, resultOutStatus: Boolean;
  resultConsTaxLayMethodChangedFlg: Boolean;
  resultIsPCCUOESaleSlip: Boolean;//ADD 2011/11/18

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;
  estimateDivide := 0;

  try
    try
      // 結果データを初期化
      resultAcptAnOdrStatus := 0;
      resultEstimateDivide := 0;
      ClearTSalesSlipSearchResult(resultSearchResult);
      ClearTSalesSlip(resultSalesSlip);

      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_salesSlipGuide
        (formName, enterpriseCode, acptAnOdrStatusDisplay,
        resultAcptAnOdrStatus, resultEstimateDivide, resultSearchResult,
//        resultSalesSlip, resultOutDialogResult, resultOutStatus, resultConsTaxLayMethodChangedFlg);  //DEL 2011/11/18
         resultSalesSlip, resultOutDialogResult, resultOutStatus, resultConsTaxLayMethodChangedFlg, resultIsPCCUOESaleSlip);  //ADD 2011/11/18
      // 結果コピー

      refAcptAnOdrStatus := resultAcptAnOdrStatus;
      estimateDivide := resultEstimateDivide;
      searchResult := resultSearchResult;
      salesSlip := resultSalesSlip;
      outDialogResult := resultOutDialogResult;
      outStatus := resultOutStatus;
      consTaxLayMethodChangedFlg := resultConsTaxLayMethodChangedFlg;
      isPCCUOESaleSlip := resultIsPCCUOESaleSlip; //ADD 2011/11/18
      // 結果を設定
      Result := status;
      // 例外処理
    except
      on ex: Exception do
      begin
        ShowMessage(ex.Message);
        // 例外発生時はエラーメッセージを戻す
        Result := -1;
      end;
    end;
  finally
    // ラッパークラス側から渡されたメモリを解放

    // メッセージのメモリ解放
  end;
end;

// 得意先ガイド処理
function MAHNB01013B_customerGuide(customerFlag: Boolean;
  addresseeCode: Integer; CustomerCode: Integer;
  var customerSearchRet: TCustomerSearchRet; var dialogResultFlag: Integer;
  var customerCodeChangedFlg: Boolean;
  var optCarMngFlg: Boolean)
  : Integer; stdcall;

var
  status: Integer;
  resultCustomerSearchRet: TCustomerSearchRet;
  resultDialogResultFlag: Integer;
  resultCustomerCodeChangedFlg, resultOptCarMngFlg: Boolean;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;

  try
    try
      // 結果データを初期化
      ClearTCustomerSearchRet(resultCustomerSearchRet);

      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_customerGuide
        (customerFlag, addresseeCode, CustomerCode, resultCustomerSearchRet,
        resultDialogResultFlag, resultCustomerCodeChangedFlg, resultOptCarMngFlg);
      // 結果コピー
      customerSearchRet := resultCustomerSearchRet;
      dialogResultFlag := resultDialogResultFlag;
      customerCodeChangedFlg := resultCustomerCodeChangedFlg;
      optCarMngFlg := resultOptCarMngFlg;

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

// 設定処理
function MAHNB01013B_ShowSalesSlipInputSetup(): Integer; stdcall;

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
      status := gpxDelphiSalesSlipInputAcs_ShowSalesSlipInputSetup();
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

// 画面項目名称取得処理
// ADD　譚洪 2020/02/24 PMKOBETSU-2912の対応 ---------->>>>>
// MAHNB01013B_GetDisplayName(var rateName: WideString): Integer; stdcall;
function MAHNB01013B_GetDisplayName(var rateName: WideString; var taxFlg: Boolean): Integer; stdcall;
// ADD　譚洪 2020/02/24 PMKOBETSU-2912の対応 ----------<<<<<
var
  status: Integer;
  resultRateName: WideString;
  resultTaxFlg: Boolean;   // ADD　譚洪 2020/02/24 PMKOBETSU-2912の対応
  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;
  rateName := '';
  taxFlg := false; // ADD　譚洪 2020/02/24 PMKOBETSU-2912の対応
  try
    try
      // 結果データを初期化
      resultRateName := '';
      resultTaxFlg := false; // ADD　譚洪 2020/02/24 PMKOBETSU-2912の対応

      // 検索メソッド呼出し
      // ADD　譚洪 2020/02/24 PMKOBETSU-2912の対応 ---------->>>>>
      //status := gpxDelphiSalesSlipInputAcs_GetDisplayName(resultRateName);
      status := gpxDelphiSalesSlipInputAcs_GetDisplayName(resultRateName, resultTaxFlg);
      // ADD　譚洪 2020/02/24 PMKOBETSU-2912の対応 ----------<<<<<
      // 結果コピー
      rateName := resultRateName;
      taxFlg := resultTaxFlg;   // ADD　譚洪 2020/02/24 PMKOBETSU-2912の対応
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

// 明細粗利率取得処理
function MAHNB01013B_GetDetailGrossProfitRate
  (rowNo: Integer; var detailGrossProfitRate: WideString; var addDetailGrossProfitRate
    : WideString): Integer; stdcall;

var
  status: Integer;
  resultDetailGrossProfitRate: WideString;
  resultAddDetailGrossProfitRate: WideString;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;
  detailGrossProfitRate := '';
  addDetailGrossProfitRate := '';

  try
    try
      // 結果データを初期化
      resultDetailGrossProfitRate := '';
      resultAddDetailGrossProfitRate := '';

      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_GetDetailGrossProfitRate
        (rowNo, resultDetailGrossProfitRate, resultAddDetailGrossProfitRate);
      // 結果コピー
      detailGrossProfitRate := resultDetailGrossProfitRate;
      addDetailGrossProfitRate := resultAddDetailGrossProfitRate;

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

// 削除処理
function MAHNB01013B_Delete(var outCheck: Boolean;
    var outDialogResult: Integer;
    var outStatus: Integer)
    : Integer; stdcall;

var
    status: Integer;
    resultOutDialogResult: Integer;
    resultOutStatus: Integer;
    outCheckResult: Boolean;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;
    outCheck := False;
    outDialogResult := 0;
    outStatus := 0;

    try
        try
            // 結果データを初期化
            outCheckResult := False;
            resultOutDialogResult := 0;
            resultOutStatus := 0;

            // 検索メソッド呼出し
            status := gpxDelphiSalesSlipInputAcs_Delete(outCheckResult, resultOutDialogResult, resultOutStatus);
            // 結果コピー
            outDialogResult := resultOutDialogResult;
            outStatus := resultOutStatus;
            outCheck := outCheckResult;

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

// アイテム名の取得処理
function MAHNB01013B_GetItemName(var itemName: WideString;
  var tableName: WideString): Integer; stdcall;

var
  status: Integer;
  resultItemName: WideString;
  resultTableName: WideString;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;
  itemName := '';
  tableName := '';

  try
    try
      // 結果データを初期化
      resultItemName := '';
      resultTableName := '';

      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_GetItemName
        (resultItemName, resultTableName);
      // 結果コピー
      itemName := resultItemName;
      tableName := resultTableName;

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

function MAHNB01013B_GetStatus(var outStatus: Integer): Integer; stdcall;

var
  status: Integer;
  resultStatus: Integer;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;
  status := 0;

  try
    try
      // 結果データを初期化
      resultStatus := 0;

      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_GetStatus(resultStatus);
      // 結果コピー
      outStatus := resultStatus;

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

function MAHNB01013B_GetBeforeSalesSlipNumText
  (var beforeSalesSlipNumText: WideString): Integer; stdcall;

var
  status: Integer;
  resultBeforeSalesSlipNumText: WideString;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;
  beforeSalesSlipNumText := '';

  try
    try
      // 結果データを初期化
      resultBeforeSalesSlipNumText := '';

      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_GetBeforeSalesSlipNumText
        (resultBeforeSalesSlipNumText);
      // 結果コピー
      beforeSalesSlipNumText := resultBeforeSalesSlipNumText;

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

// フォーカス位置の取得処理
function MAHNB01013B_GetFocusPositionValue(var focusPositionValue: Integer)
  : Integer; stdcall;

var
  status: Integer;
  resultFocusPositionValue: Integer;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;
  focusPositionValue := 0;

  try
    try
      // 結果データを初期化
      resultFocusPositionValue := 0;

      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_GetFocusPositionValue
        (resultFocusPositionValue);
      // 結果コピー
      focusPositionValue := resultFocusPositionValue;

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

// オプション情報処理
function MAHNB01013B_FormPosDeserialize(var topInt: Integer;
    var leftInt: Integer;
    var heightInt: Integer;
    var widthInt: Integer)
    : Integer; stdcall;

var
    status: Integer;
    resultTopInt: Integer;
    resultLeftInt: Integer;
    resultHeightInt: Integer;
    resultWidthInt: Integer;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;
    topInt := 0;
    leftInt := 0;
    heightInt := 0;
    widthInt := 0;

    try
        try
            // 結果データを初期化
            resultTopInt := 0;
            resultLeftInt := 0;
            resultHeightInt := 0;
            resultWidthInt := 0;

            // 検索メソッド呼出し
            status := gpxDelphiSalesSlipInputAcs_FormPosDeserialize(resultTopInt, resultLeftInt, resultHeightInt, resultWidthInt);
            // 結果コピー
            topInt := resultTopInt;
            leftInt := resultLeftInt;
            heightInt := resultHeightInt;
            widthInt := resultWidthInt;

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

// 赤伝処理
function MAHNB01013B_RedSlip(isConfirm: Boolean; canRed: Boolean): Integer; stdcall;

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
      status := gpxDelphiSalesSlipInputAcs_RedSlip(isConfirm, canRed);
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

// 赤伝できるかどうかフラグの取得処理
function MAHNB01013B_GetCanRed(var canRed: Boolean): Integer; stdcall;

var
  status: Integer;
  resultCanRed: Boolean;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;

  try
    try
      // 結果データを初期化

      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_GetCanRed(resultCanRed);
      // 結果コピー
      canRed := resultCanRed;

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

function MAHNB01013B_GetRedDialogResult(var redDialogResult: Integer): Integer;
  stdcall;

var
  status: Integer;
  resultredDialogResult: Integer;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;

  try
    try
      // 結果データを初期化

      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_GetRedDialogResult
        (resultredDialogResult);
      // 結果コピー
      redDialogResult := resultredDialogResult;

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

// 見出貼付
function MAHNB01013B_CopySlipHeader(CarInfoEnabledFlg: Boolean;
  salesRowNo: Integer; addresseeName: Integer; var existSalesDetail: Boolean;
  var clearDetailFlg: Boolean; var searchPartsModeProperty: Integer;
  var fullModelFixedNoAryFlg: Boolean; var errorFlg: Boolean;
  var outSalesSlipHeaderCopyData: TSalesSlipHeaderCopyData;
  var copySlipHeaderClearFlg: Boolean): Integer; stdcall;

var
  status, resultSearchPartsModeProperty: Integer;
  resultExistSalesDetail, resultClearDetailFlg, resultFullModelFixedNoAryFlg,
  resultErrorFlg: Boolean;
  resultOutSalesSlipHeaderCopyData: TSalesSlipHeaderCopyData;
  resultCopySlipHeaderClearFlg: Boolean;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;

  try
    try
      // 結果データを初期化
      ClearTSalesSlipHeaderCopyData(resultOutSalesSlipHeaderCopyData);

      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_CopySlipHeader
        (CarInfoEnabledFlg, salesRowNo, addresseeName, resultExistSalesDetail,
        resultClearDetailFlg, resultSearchPartsModeProperty,
        resultFullModelFixedNoAryFlg, resultErrorFlg,
        resultOutSalesSlipHeaderCopyData, resultCopySlipHeaderClearFlg);
      // 結果コピー
      existSalesDetail := resultExistSalesDetail;
      clearDetailFlg := resultClearDetailFlg;
      searchPartsModeProperty := resultSearchPartsModeProperty;
      fullModelFixedNoAryFlg := resultFullModelFixedNoAryFlg;
      errorFlg := resultErrorFlg;
      outSalesSlipHeaderCopyData := resultOutSalesSlipHeaderCopyData;
      copySlipHeaderClearFlg := resultCopySlipHeaderClearFlg;
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

//-------------- ADD 連番729 2011/08/18 ----------------->>>>>
// 詳細貼付
function MAHNB01013B_CopySlipDetail(salesRowNo: Integer): Integer; stdcall;
var
  status: Integer;
begin
  // 戻りステータス初期化
  Result := -1;

  try
    try
      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_CopySlipDetail(salesRowNo);
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
//-------------- ADD 連番729 2011/08/18 -----------------<<<<<

// 管理番号ガイド表示後の処理
function MAHNB01013B_AfterCarMngNoGuideReturn(paraStatus: Integer;
  selectedInfo: TCarMangInputExtraInfo; inputflag: Integer;
  salesRowNo: Integer; carMngCode: WideString; var returnFlag: Boolean;
  var clearCarInfoFlag: Boolean): Integer; stdcall;

var
  status: Integer;
  resultReturnFlag: Boolean;
  resultClearCarInfoFlag: Boolean;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;

  try
    try
      // 結果データを初期化

      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_AfterCarMngNoGuideReturn
        (paraStatus, selectedInfo, inputflag, salesRowNo, carMngCode,
        resultReturnFlag, resultClearCarInfoFlag);
      // 結果コピー
      returnFlag := resultReturnFlag;
      clearCarInfoFlag := resultClearCarInfoFlag;

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

// xxxx
function MAHNB01013B_setToolMenuCustomizeSetting(key: WideString): Integer;
  stdcall;

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
      status := gpxDelphiSalesSlipInputAcs_setToolMenuCustomizeSetting(key);
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

// xxxx
function MAHNB01013B_getToolMenuCustomizeSetting
  (var toolMenuCustomizeSettingNotNull: Boolean; var toolBarVisible: Boolean;
  var toolBarDockedRow: Integer; var toolBarDockedColumn: Integer;
  var toolBarDockedPosition: Integer): Integer; stdcall;

var
  status: Integer;
  resultToolMenuCustomizeSettingNotNull: Boolean;
  resultToolBarVisible: Boolean;
  resultToolBarDockedRow: Integer;
  resultToolBarDockedColumn: Integer;
  resultToolBarDockedPosition: Integer;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;
  toolBarDockedRow := 0;
  toolBarDockedColumn := 0;
  toolBarDockedPosition := 0;

  try
    try
      // 結果データを初期化

      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_getToolMenuCustomizeSetting
        (resultToolMenuCustomizeSettingNotNull, resultToolBarVisible,
        resultToolBarDockedRow, resultToolBarDockedColumn,
        resultToolBarDockedPosition);
      // 結果コピー
      toolMenuCustomizeSettingNotNull := resultToolMenuCustomizeSettingNotNull;
      toolBarVisible := resultToolBarVisible;
      toolBarDockedRow := resultToolBarDockedRow;
      toolBarDockedColumn := resultToolBarDockedColumn;
      toolBarDockedPosition := resultToolBarDockedPosition;

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

// 各種起動データ
//function MAHNB01013B_SetInitData()   //DEL 連番729 2011/08/18
function MAHNB01013B_SetInitData(var existFlg: Boolean)   //ADD 連番729 2011/08/18
    : Integer; stdcall;

var
    status: Integer;
    resultExistFlg: Boolean;    //ADD 連番729 2011/08/18

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            resultExistFlg := existFlg;      //ADD 連番729 2011/08/18

            // 検索メソッド呼出し
//            status := gpxDelphiSalesSlipInputAcs_SetInitData();  //DEL 連番729 2011/08/18
            status := gpxDelphiSalesSlipInputAcs_SetInitData(resultExistFlg);  //ADD 連番729 2011/08/18
            // 結果コピー
             existFlg := resultExistFlg;     //ADD 連番729 2011/08/18

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

// xxxx
function MAHNB01013B_setToolButtonCustomizeSetting(key: WideString): Integer;
  stdcall;

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
      status := gpxDelphiSalesSlipInputAcs_setToolButtonCustomizeSetting(key);
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

// xxxx
function MAHNB01013B_getToolButtonCustomizeSetting
  (var toolButtonCustomizeSettingNotNull: Boolean;
  var toolBarCustomizedVisible: Integer): Integer; stdcall;

var
  status: Integer;
  resultToolButtonCustomizeSettingNotNull: Boolean;
  resultToolBarCustomizedVisible: Integer;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;
  toolBarCustomizedVisible := 0;

  try
    try
      // 結果データを初期化

      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_getToolButtonCustomizeSetting
        (resultToolButtonCustomizeSettingNotNull,
        resultToolBarCustomizedVisible);
      // 結果コピー
      toolButtonCustomizeSettingNotNull :=
        resultToolButtonCustomizeSettingNotNull;
      toolBarCustomizedVisible := resultToolBarCustomizedVisible;

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

// xxxx
function MAHNB01013B_SaveToolbarCustomizeSetting
  (key: WideString; visible: Boolean): Integer; stdcall;

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
      status := gpxDelphiSalesSlipInputAcs_SaveToolbarCustomizeSetting
        (key, visible);
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

// ファンクション明細制御取得処理
function MAHNB01013B_GetBitButtonCustomizeSetting(key: WideString;
    var bitButtonCustomizedVisible: Integer)
    : Integer; stdcall;

var
    status: Integer;
    resultBitButtonCustomizedVisible: Integer;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;
    bitButtonCustomizedVisible := 0;

    try
        try
            // 結果データを初期化
            resultBitButtonCustomizedVisible := 0;

            // 検索メソッド呼出し
            status := gpxDelphiSalesSlipInputAcs_GetBitButtonCustomizeSetting(key, resultBitButtonCustomizedVisible);
            // 結果コピー
            bitButtonCustomizedVisible := resultBitButtonCustomizedVisible;

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


// xxxx
function MAHNB01013B_SaveToolManagerCustomizeInfo
  (key: WideString; visible: Boolean; dockedRow: Integer;
  dockedColumn: Integer; dockedPosition: Integer): Integer; stdcall;

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
      status := gpxDelphiSalesSlipInputAcs_SaveToolManagerCustomizeInfo
        (key, visible, dockedRow, dockedColumn, dockedPosition);
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

// xxxx
function MAHNB01013B_SaveCustomizeXml(): Integer; stdcall;

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
      status := gpxDelphiSalesSlipInputAcs_SaveCustomizeXml();
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

function MAHNB01013B_GetUltraOptionSetValue()
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
      status := gpxDelphiSalesSlipInputAcs_GetUltraOptionSetValue();
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

function MAHNB01013B_SlipNoteGuide(salesRowNo: Integer)
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
            status := gpxDelphiSalesSlipInputAcs_SlipNoteGuide(salesRowNo);
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

// 売上金額変更後発生イベント処理
function MAHNB01013B_SalesPriceChanged()
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
            status := gpxDelphiSalesSlipInputAcs_SalesPriceChanged();
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

// 車両情報設定処理
function MAHNB01013B_CarInfoFormSetting(salesRowNo: Integer;
    var isGoodsFlg: Boolean;
    var carInfoRowFlg: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultIsGoodsFlg: Boolean;
    resultCarInfoRowFlg: Boolean;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化


            // 検索メソッド呼出し
            status := gpxDelphiSalesSlipInputAcs_CarInfoFormSetting(salesRowNo, resultIsGoodsFlg, resultCarInfoRowFlg);
            // 結果コピー
            isGoodsFlg := resultIsGoodsFlg;
            carInfoRowFlg := resultCarInfoRowFlg;

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

// 保存確認ダイアログ表示処理
// --- ADD m.suzuki 2010/06/12 ---------->>>>>
//function MAHNB01013B_ShowRedSaveCheckDialog(isConfirm: Boolean;
//    var afterSaveClearFlg: Boolean)
//    : Integer; stdcall;
function MAHNB01013B_ShowRedSaveCheckDialog(isConfirm: Boolean;
    var afterSaveClearFlg: Boolean; var isMakeQR: Boolean)
    : Integer; stdcall;
// --- UPD m.suzuki 2010/06/12 ----------<<<<<
var
    status: Integer;
    resultAfterSaveClearFlg: Boolean;
    // --- ADD m.suzuki 2010/06/12 ---------->>>>>
    resultIsMakeQR: Boolean;
    // --- ADD m.suzuki 2010/06/12 ----------<<<<<

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            // --- ADD m.suzuki 2010/06/12 ---------->>>>>
            resultIsMakeQR := isMakeQR;
            // --- ADD m.suzuki 2010/06/12 ----------<<<<<

            // 検索メソッド呼出し
            // --- UPD m.suzuki 2010/06/12 ---------->>>>>
            //status := gpxDelphiSalesSlipInputAcs_ShowRedSaveCheckDialog(isConfirm, resultAfterSaveClearFlg);
            status := gpxDelphiSalesSlipInputAcs_ShowRedSaveCheckDialog(isConfirm, resultAfterSaveClearFlg, resultIsMakeQR);
            // --- UPD m.suzuki 2010/06/12 ----------<<<<<

            // 結果コピー
            afterSaveClearFlg := resultAfterSaveClearFlg;
            // --- ADD m.suzuki 2010/06/12 ---------->>>>>
            isMakeQR := resultIsMakeQR;
            // --- ADD m.suzuki 2010/06/12 ----------<<<<<

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

//---UPD 2010/07/06---------->>>>>
// SetItemsDictionary
//function MAHNB01013B_SetItemsDictionary(headControlNames: WideString; footControlNames: WideString)
//    : Integer; stdcall;
function MAHNB01013B_SetItemsDictionary(headControlNames: WideString; footControlNames: WideString; functionControlNames: WideString; functionDetailControlNames: WideString)
    : Integer; stdcall;
//---UPD 2010/07/06----------<<<<<

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
            //---UPD 2010/07/06---------->>>>>
//            status := gpxDelphiSalesSlipInputAcs_SetItemsDictionary(headControlNames, footControlNames);
            status := gpxDelphiSalesSlipInputAcs_SetItemsDictionary(headControlNames, footControlNames, functionControlNames, functionDetailControlNames);
            //---UPD 2010/07/06----------<<<<<
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

// setColDisplayStatusList
function MAHNB01013B_setColDisplayStatusList()
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
            status := gpxDelphiSalesSlipInputAcs_setColDisplayStatusList();
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

// --- ADD 2010/06/02 ---------->>>>>
// GetReadSlipFlg
function MAHNB01013B_GetReadSlipFlg(var readSlipFlg: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultReadSlipFlg: Boolean;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try

            // 検索メソッド呼出し
            status := gpxDelphiSalesSlipInputAcs_GetReadSlipFlg(resultReadSlipFlg);
            // 結果コピー
            readSlipFlg := resultReadSlipFlg;

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
// --- ADD 2010/06/02----------<<<<<

// --- ADD 2010/07/08 ---------->>>>>
// 操作権限の制御
function MAHNB01013B_BeginControllingByOperationAuthority(var RevisionVisible: Boolean;
    var DeleteVisible: Boolean;
    var RedSlipVisible: Boolean;
    var SlipDiscountVisible: Boolean)// ADD 2013/01/24 鄧潘ハン REDMINE#34141

    : Integer; stdcall;

var
    status: Integer;
    resultRevisionVisible: Boolean;
    resultDeleteVisible: Boolean;
    resultRedSlipVisible: Boolean;
    resultSlipDiscountVisible: Boolean;// ADD 2013/01/24 鄧潘ハン REDMINE#34141

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化

            // 検索メソッド呼出し
            //status := gpxDelphiSalesSlipInputAcs_BeginControllingByOperationAuthority(resultRevisionVisible, resultDeleteVisible, resultRedSlipVisible); // DEL 2013/01/24 鄧潘ハン REDMINE#34141
            status := gpxDelphiSalesSlipInputAcs_BeginControllingByOperationAuthority(resultRevisionVisible, resultDeleteVisible, resultRedSlipVisible, resultSlipDiscountVisible); // ADD 2013/01/24 鄧潘ハン REDMINE#34141
            // 結果コピー
            RevisionVisible := resultRevisionVisible;
            DeleteVisible := resultDeleteVisible;
            RedSlipVisible := resultRedSlipVisible;
            SlipDiscountVisible := resultSlipDiscountVisible;// ADD 2013/01/24 鄧潘ハン REDMINE#34141

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
// --- ADD 2010/07/08 ----------<<<<<

// add by gaofeng end

// --- ADD 2014/07/15 T.Miyamoto 仕掛一覧 №1912 ---------->>>>>
// 操作権限の判定
function MAHNB01013B_GetOperationSt(iOperationCode: Integer): Boolean; stdcall;
begin
  // 戻りステータス初期化
  Result := False;

  try
    try
      // 結果データを初期化

      // 検索メソッド呼出し
      Result := gpxDelphiSalesSlipInputAcs_GetOperationSt(iOperationCode);
      // 結果コピー
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
// --- ADD 2014/07/15 T.Miyamoto 仕掛一覧 №1912 ----------<<<<<

// add by lizc begin
// 最新情報処理
function MAHNB01013B_ReNewalBtnClick(enterpriseCode: WideString;
  loginSectionCode: WideString): Integer; stdcall;

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
      status := gpxDelphiSalesSlipInputAcs_ReNewalBtnClick(enterpriseCode, loginSectionCode);
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

// 明細データ取得
function MAHNB01013B_GetSalesDetailDataTable(var refSalesDetailList: TSalesSlipInputCustomArrayA2;
    salesRowNo: Integer)
    : Integer; stdcall;

var
    status: Integer;
    resultSalesDetailList: TSalesSlipInputCustomArrayA2;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            refSalesDetailList.Csafield1 := nil;
            refSalesDetailList.Csafield1Count := 0;

            // 検索メソッド呼出し
            status := gpxDelphiSalesSlipInputAcs_GetSalesDetailDataTable(refSalesDetailList, resultSalesDetailList, salesRowNo);
            // 結果コピー
            refSalesDetailList := resultSalesDetailList;

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
        gpxDelphiSalesSlipInputAcs_FreeCustomArrayA2(@resultSalesDetailList, 0);

        // メッセージのメモリ解放
    end;
end;

// xxxxx
function MAHNB01013B_ProcessingDialogDispose(): Integer; stdcall;

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
      status := gpxDelphiSalesSlipInputAcs_ProcessingDialogDispose();
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

// add by lizc end

// --- ADD m.suzuki 2010/06/12 ---------->>>>>
//************************************************************
// QRコード作成処理
//************************************************************
procedure MAHNB01013B_MakeQR( sParam: WideString ); stdcall;
begin
  // 戻りステータス初期化

  try
    try
      // 結果データを初期化

      // 検索メソッド呼出し
      gpxDelphiSalesSlipInputAcs_MakeQR( sParam );
      // 結果コピー

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
// --- ADD m.suzuki 2010/06/12 ---------->>>>>
//************************************************************
// オンラインフラグ取得処理
//************************************************************
function MAHNB01013B_GetOnlineFlag(): Boolean; stdcall;
begin
  // 戻りステータス初期化
  Result := False;

  try
    try
      // 結果データを初期化

      // 検索メソッド呼出し
      Result := gpxDelphiSalesSlipInputAcs_GetOnlineFlag();
      // 結果コピー
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

//>>>2010/05/30
// SCM問合せ一覧選択処理
function MAHNB01013B_ReferenceList(isDataChanged: Boolean; var isSave: Integer)
  : Integer; stdcall;

var
  status: Integer;
  resultIsSave: Integer;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;

  try
    try
      // 結果データを初期化
      // ClearTSalesSlip(resultSalesSlip);
      resultIsSave := 2;
      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_ReferenceList(isDataChanged, resultIsSave);
      // 結果コピー
      isSave := resultIsSave;

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
//----- ADD　2018/09/04 譚洪　履歴自動表示の対応------->>>>>
// 履歴検索
function MAHNB01013B_HisSearch(salesRowNo: Integer)
  : Integer; stdcall;

var
  status: Integer;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;

  try
    try
      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_HisSearch(salesRowNo);

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
//----- ADD　2018/09/04 譚洪　履歴自動表示の対応-------<<<<<

//----- ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応------->>>>>
// 税率入力
function MAHNB01013B_GetTaxRate()
  : Integer; stdcall;

var
  status: Integer;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;

  try
    try
      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_GetTaxRate();

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
// 税率入力
function MAHNB01013B_GetTaxRateDialogResult(var taxRateDialogResult: Integer)
  : Integer; stdcall;

var
  status: Integer;
  retTaxDialogResult,I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;

  try
    try
      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_GetTaxRateDialogResult
       (retTaxDialogResult);
      // 結果コピー
      taxRateDialogResult := retTaxDialogResult;
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

// 発注と仕入判断処理
function MAHNB01013B_OrderCheck(mode:Integer; var orderFlg: Boolean)
  : Integer; stdcall;
var
  status: Integer;
  resultOrderFlg: Boolean;
begin
  // 戻りステータス初期化
  Result := -1;

  try
    try
      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_OrderCheck(mode,resultOrderFlg);
      // 結果を設定
      orderFlg := resultOrderFlg;
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
//----- ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応-------<<<<<

// --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応 ----->>>>>
// 電帳起動
function MAHNB01013B_StartEBooks()
  : Integer; stdcall;

var
  status: Integer;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;

  try
    try
      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_StartEBooks();

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
// --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応 -----<<<<<

// 起動パラメータ設定処理
// 2011/01/31 >>>
//function MAHNB01013B_SettingParameter(param1: WideString; param2: WideString)
function MAHNB01013B_SettingParameter(param1: WideString; param2: WideString; param3: WideString)
// 2011/01/31 <<<
  : Integer; stdcall;
var
  status: Integer;
  resultIsSave: Integer;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;

  try
    try
      // 結果データを初期化
      // ClearTSalesSlip(resultSalesSlip);
      resultIsSave := 2;
      // 検索メソッド呼出し
// 2011/01/31 >>>
//      status := gpxDelphiSalesSlipInputAcs_SettingParameter(param1, param2);
      status := gpxDelphiSalesSlipInputAcs_SettingParameter(param1, param2, param3);
// 2011/01/31 <<<
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

// SCM情報読込タイマー起動イベント処理
function MAHNB01013B_TimerSCMReadTick(var ret : Boolean; var customerCode : Integer)
  : Integer; stdcall;

var
  status: Integer;
  resultIsSave: Integer;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;

  try
    try
      // 結果データを初期化
      // ClearTSalesSlip(resultSalesSlip);
      resultIsSave := 2;
      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_TimerSCMReadTick(ret, customerCode);
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

// 相場価格情報取得処理
function MAHNB01013B_GetSobaInfo()
  : Integer; stdcall;

var
  status: Integer;
  resultIsSave: Integer;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;

  try
    try
      resultIsSave := 2;
      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_GetSobaInfo();
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
//<<<2010/05/30

//>>>2010/08/30
// 税率設定範囲チェック
function MAHNB01013B_ExistTaxRateRangeMethod(salesdate: Integer)
  : Integer; stdcall;

var
  status: Integer;
  resultIsSave: Integer;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;

  try
    try
      resultIsSave := 2;
      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_ExistTaxRateRangeMethod(salesdate);
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
//<<<2010/08/30

// オプション情報処理
function MAHNB01013B_GetGrossProfitRateFlg(var grossProfitRateFlg: Boolean)
    : Integer; stdcall;

var
    status: Integer;
    resultGrossProfitRateFlg: Boolean;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try


            // 検索メソッド呼出し
            status := gpxDelphiSalesSlipInputAcs_GetGrossProfitRateFlg(grossProfitRateFlg);

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

//>>>2011/02/01
// SCM情報存在チェック
function MAHNB01013B_ExistSCMInfo(var ret : Boolean; salesSlipNum: WideString; salesRowNo:Integer)
  : Integer; stdcall;

var
  status: Integer;
  resultIsSave: Integer;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;

  try
    try
      // 結果データを初期化
      // ClearTSalesSlip(resultSalesSlip);
      resultIsSave := 2;
      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_ExistSCMInfo(ret, salesSlipNum, salesRowNo);
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
//<<<2011/02/01

//>>>2011/03/04
// 従業員情報設定処理
procedure MAHNB01013B_SettingEmpInfo(); stdcall;
var
  status: Integer;
  resultIsSave: Integer;

  I: Integer;
begin
  try
    try
      gpxDelphiSalesSlipInputAcs_SettingEmpInfo();
    except
      on ex: Exception do
      begin
      end;
    end;
  finally
    // ラッパークラス側から渡されたメモリを解放

  end;
end;
//<<<2011/02/01

// ------  ADD K2015/04/01 高騁 森川部品個別依頼------->>>>>
// 全拠点在庫情報一覧
function MAHNB01013B_ReadAllSecStockInfo(makerCd: Integer;
    goodsNo: WideString;
    goodsName: WideString;
    isOpenPressed: Boolean;
    isClose: Boolean;
    var message: WideString)
    : Integer; stdcall;
var
    status: Integer;
    resultMessage: WideString;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;
    message := '';

    try
        try
            // 結果データを初期化
            resultMessage := '';

            // 検索メソッド呼出し
            status := gpxDelphiSalesSlipInputAcs_ReadAllSecStockInfo(makerCd, goodsNo, goodsName, isOpenPressed, isClose, resultMessage);
            // 結果コピー
            message := resultMessage;

            // 結果を設定
            Result := status;
            // 例外処理
        except
            on ex: Exception do
            begin
                // 例外発生時はエラーメッセージを戻す
                message := ex.Message;
                Result := -1;
            end;
        end;
    finally
        // ラッパークラス側から渡されたメモリを解放
    end;
end;

// 森川個別オプション判定
function MAHNB01013B_OptPermitForMoriKawa(var optPermitForMoriKawa: Boolean)
    : Integer; stdcall;

var
    status: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try

            // 検索メソッド呼出し
            status := gpxDelphiSalesSlipInputAcs_OptPermitForMoriKawa(optPermitForMoriKawa);

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
// ------  ADD K2015/04/01 高騁 森川部品個別依頼-------<<<<<

// --- ADD 黄興貴 2015/04/29 ---------------->>>>>
// UOEデータ取込
function MAHNB01013B_ReadUoeData(salesRowNo: Integer)
    : Integer; stdcall;

var
    status: Integer;
    resultMessage: WideString;

    I: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try
            // 結果データを初期化
            resultMessage := '';

            // 検索メソッド呼出し
            status := gpxDelphiSalesSlipInputAcs_ReadUoeData(salesRowNo);

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

// 富士ジーワイ商事㈱オプション判定
function MAHNB01013B_OptPermitForFuJi(var optPermitForFuJi: Boolean)
    : Integer; stdcall;

var
    status: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try

            // 検索メソッド呼出し
            status := gpxDelphiSalesSlipInputAcs_OptPermitForFuJi(optPermitForFuJi);

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
// --- ADD 黄興貴 2015/04/29 ----------------<<<<<

// --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- >>>>>
// ㈱コーエイオプション判定
function MAHNB01013B_OptPermitForKoei(var optPermitForKoei: Boolean)
    : Integer; stdcall;

var
    status: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try

            // 検索メソッド呼出し
            status := gpxDelphiSalesSlipInputAcs_OptPermitForKoei(optPermitForKoei);

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
// --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- <<<<<


// --- ADD 紀飛 2015/06/18 WebUOE発注回答取込---------------->>>>>
// ㈱メイゴオプション判定
function MAHNB01013B_OptPermitForMeiGo(var optPermitForMeiGo: Boolean)
    : Integer; stdcall;

var
    status: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try

            // 検索メソッド呼出し
            status := gpxDelphiSalesSlipInputAcs_OptPermitForMeiGo(optPermitForMeiGo);

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
// --- ADD 紀飛 2015/06/18 WebUOE発注回答取込----------------<<<<<
// --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応--->>>>>
// 電子帳簿連携オプションプション判定
function MAHNB01013B_OptPermitForEBooks(var optPermitForEBooks: Boolean)
    : Integer; stdcall;

var
    status: Integer;
begin
    // 戻りステータス初期化
    Result := -1;

    try
        try

            // 検索メソッド呼出し
            status := gpxDelphiSalesSlipInputAcs_OptPermitForEBooks(optPermitForEBooks);

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
// --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応---<<<<<

// --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- >>>>>
// 売価算出処理
function MAHNB01013B_SalesUnPrcCalc
  (salesRowNo: Integer; var salesUnPrice: WideString): Integer; stdcall;

var
  status: Integer;
  resultSalesUnPrice: WideString;

  I: Integer;
begin
  // 戻りステータス初期化
  Result := -1;
  salesUnPrice := '';

  try
    try
      // 結果データを初期化
      resultSalesUnPrice := '';

      // 検索メソッド呼出し
      status := gpxDelphiSalesSlipInputAcs_SalesUnPrcCalc
        (salesRowNo, resultSalesUnPrice);
      // 結果コピー
      salesUnPrice := resultSalesUnPrice;

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
// --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- <<<<<

end.

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
// 管理番号              作成担当 : 20056 對馬 大輔
// 作 成 日  2010/08/30  修正内容 : 税率設定範囲チェック追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20056 對馬 大輔
// 作 成 日  2011/02/01  修正内容 : SCM情報存在チェック処理追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20056 對馬 大輔
// 作 成 日  2011/03/04  修正内容 : SCM情報存在チェック処理追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 曹文傑
// 作 成 日  2011/04/13  修正内容 : 明細複数選択行を削除可能とする
//----------------------------------------------------------------------------//
// 管理番号  10703874-00 作成担当 : yangyi
// 作 成 日  K2011/08/12 修正内容 : イスコ個別対応
//----------------------------------------------------------------------------//
// 管理番号  10704766-00 作成担当 : 許雁波
// 作 成 日  2011/08/18  修正内容 : 連番729 明細貼付ファンクションボタンを追加
//----------------------------------------------------------------------------//
// 管理番号10704766-00   作成担当 : 劉思遠
// 作 成 日  2011/11/22  修正内容 : Redmine#8037
//			                            BLﾊﾟｰﾂｵｰﾀﾞｰ　在庫確認→発注時のデータセットの仕様変更
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 福田 康夫
// 作 成 日  2012/05/31  修正内容 : 障害No.282
//                                  発注選択の時に「ESC」キーを押下することで発注扱いを解除する
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
// 作 成 日  2018/09/04   修正内容 : 履歴自動表示機能追加対応
//----------------------------------------------------------------------------//
// 管理番号  11570208-00  作成担当 : 譚洪
// 作 成 日  2020/02/24   修正内容 : 消費税税率機能追加対応
//----------------------------------------------------------------------------//
// 管理番号  11870080-00  作成担当 : 陳艶丹
// 作 成 日  2022/04/26  修正内容 : PMKOBETSU-4208 電子帳簿対応
//----------------------------------------------------------------------------//

  library MAHNB01013B;

{ DLL のメモリ管理に関する重要な注意：
  もしこの DLL が引数や返り値として String 型を使う関数/手続きをエクスポー
  トする場合、以下の USES 節とこの DLL を使うプロジェクトソースの USES 節
  の両方に、最初に現れるユニットとして ShareMem を指定しなければなりません。
  （プロジェクトソースはメニューから[プロジェクト｜ソース表示] を選ぶこと
  で表示されます）
  これは構造体やクラスに埋め込まれている場合も含め String 型を DLL とやり
  取りする場合に必ず必要となります。
  ShareMem は共用メモリマネージャである BORLNDMM.DLL とのインターフェース
  です。あなたの DLL と一緒に配布する必要があります。BORLNDMM.DLL を使うの
  を避けるには、PChar または ShortString 型を使って文字列のやり取りをおこ
  なってください。}

uses
  ShareMem,
  SysUtils,
  Classes,
  MAHNB01013BAP in 'MAHNB01013BAP.pas',
  MAHNB01013BMP in 'MAHNB01013BMP.pas' {DataModule1: TDataModule};

{$R *.res}

exports
    MAHNB01013B_Clear,
    MAHNB01013B_Close,
    MAHNB01013B_GetDisplayCustomerInfo,
    MAHNB01013B_ShipmentAddUp,
    MAHNB01013B_GetSalesHisGuide,
    MAHNB01013B_GetItemtSalesSlipCd,
    MAHNB01013B_GetAddInfoVisible,
    MAHNB01013B_GetDisplayHeaderFooterInfo,
    MAHNB01013B_GetSalesHisGuide,
    MAHNB01013B_GetInitData,
    MAHNB01013B_GetNoteGuidList,
    MAHNB01013B_customerGuide,
    MAHNB01013B_InitMstCheck,
    MAHNB01013B_Retry,
    MAHNB01013B_RetryResult,
    MAHNB01013B_ShowSalesSlipInputSetup,
    MAHNB01013B_salesSlipGuide,
    MAHNB01013B_SetUserGdBdComboEditor,
    MAHNB01013B_GetCellEnabled,
    MAHNB01013B_GetDisplayName,
    MAHNB01013B_salesSlipGuide,
    MAHNB01013B_GetDetailGrossProfitRate,
    MAHNB01013B_Delete,
    MAHNB01013B_GetItemName,
    MAHNB01013B_GetStatus,
    MAHNB01013B_GetBeforeSalesSlipNumText,
    MAHNB01013B_GetFocusPositionValue,
    MAHNB01013B_GetBeforeSalesSlipNumText,
    MAHNB01013B_AcceptAnOrderReferenceSearch,
    MAHNB01013B_AcceptAnOrderAddup,
    MAHNB01013B_EstimateReferenceSearch,
    MAHNB01013B_EstimateAddup,
    MAHNB01013B_SalesReferenceSearch,
    MAHNB01013B_CopySlip,
    MAHNB01013B_GetOptCarMng,
    MAHNB01013B_RedSlip,
    MAHNB01013B_GetCanRed,
    MAHNB01013B_GetRedDialogResult,
    MAHNB01013B_CopySlipHeader,
    MAHNB01013B_CopySlipDetail,    // ADD 連番729 2011/08/18
    MAHNB01013B_AfterCarMngNoGuideReturn,
    MAHNB01013B_GetRedDialogResult,
    MAHNB01013B_SetNoteCharCnt,
    MAHNB01013B_ReturnSlip,
    MAHNB01013B_ShowSaveCheckDialog,
    MAHNB01013B_Save,
    MAHNB01013B_afterSave,
    MAHNB01013B_GetSaveStatus,
    MAHNB01013B_GetOnlineKindDiv, // ADD 2015/12/09 T.Miyamoto リモ伝障害対応 Redmine#47670
    MAHNB01013B_setToolMenuCustomizeSetting,
    MAHNB01013B_getToolMenuCustomizeSetting,
    MAHNB01013B_setToolButtonCustomizeSetting,
    MAHNB01013B_getToolButtonCustomizeSetting,
    MAHNB01013B_SaveToolbarCustomizeSetting,
    MAHNB01013B_SaveToolManagerCustomizeInfo,
    MAHNB01013B_SaveCustomizeXml,
    MAHNB01013B_GetSaveStatus,
    MAHNB01013B_ChangeSearchMode,
    MAHNB01013B_GetSearchPartsModeProperty,
    MAHNB01013B_ReNewalBtnClick,
    MAHNB01013B_ProcessingDialogDispose,
    MAHNB01013B_GetUltraOptionSetValue,
    MAHNB01013B_SlipNoteGuide,
    MAHNB01013B_SalesPriceChanged,
    MAHNB01013B_CarInfoFormSetting,
    MAHNB01013B_ShowRedSaveCheckDialog,
    MAHNB01013B_uButtonGuideClick,
    MAHNB01013B_SetItemsDictionary,
    MAHNB01013B_GetNextMovePosition,
    MAHNB01013B_GetPreMovePosition,
    MAHNB01013B_GetParam,
    MAHNB01013B_GetEffectiveJudgment,
    MAHNB01013B_GetSalesDetailDataTable,
    MAHNB01013B_GetSalesAllDetailDataTable,
    MAHNB01013B_SetSalesDetailData,
    MAHNB01013B_AfterGoodsNoUpdate,
    MAHNB01013B_uButtonLineDiscountClick,
    MAHNB01013B_uButtonGoodsDiscountClick,
    MAHNB01013B_uButtonAnnotationClick,
    MAHNB01013B_uButtonChangeWarehouseClick,
    MAHNB01013B_uButtonStockSearchClick,
    MAHNB01013B_uButtonTBOClick,
    MAHNB01013B_uButtonCopyStockBefLineClick,
    MAHNB01013B_uButtonCopyStockAllLineClick,
    MAHNB01013B_uGridDetailsAfterCellUpdate,
    MAHNB01013B_uGridDetailsAfterCellUpdateProc,
    MAHNB01013B_GridJoinCheck,
    MAHNB01013B_DeatilActionTable,
    MAHNB01013B_AfterPartySaleSlipNumFocus,
    MAHNB01013B_CheckDetailAction,
    MAHNB01013B_GetSalesSlipInputConstructionData,
    MAHNB01013B_retGoodsReason,
    MAHNB01013B_SetSlipMemo,
    MAHNB01013B_KeyPressNumCheck,
    MAHNB01013B_CsvPassCheck,
    MAHNB01013B_uButtonEscClick,
    MAHNB01013B_setColDisplayStatusList,
    MAHNB01013B_GetReadSlipFlg,
    MAHNB01013B_SetSalesSlip,
    //----ADD 2010/11/02----->>>>>
    MAHNB01013B_SetSalesSlipByObj,
    //----ADD 2010/11/02-----<<<<<
    MAHNB01013B_FormPosSerialize,
    MAHNB01013B_FormPosDeserialize,
    // --- ADD m.suzuki 2010/06/12 ---------->>>>>
    MAHNB01013B_MakeQR,
    // --- ADD m.suzuki 2010/06/12 ----------<<<<<
    // --- ADD m.suzuki 2010/06/16 ---------->>>>>
    MAHNB01013B_GetOnlineFlag,
    // --- ADD m.suzuki 2010/06/16 ----------<<<<<
    MAHNB01013B_setColDisplayStatusList,
    MAHNB01013B_ReferenceList // 2010/05/30
   ,MAHNB01013B_HisSearch // ADD　2018/09/04 譚洪　履歴自動表示の対応
   //----- ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応------->>>>>
   ,MAHNB01013B_GetTaxRateDialogResult
   ,MAHNB01013B_GetTaxRate
   ,MAHNB01013B_OrderCheck
   //----- ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応-------<<<<<
   ,MAHNB01013B_StartEBooks // ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応
   ,MAHNB01013B_SettingParameter // 2010/05/30
   ,MAHNB01013B_TimerSCMReadTick // 2010/05/30
   ,MAHNB01013B_GetSobaInfo // 2010/05/30;
   ,MAHNB01013B_GetGrossProfitRateFlg   // 2010/07/16
   ,MAHNB01013B_GetBitButtonCustomizeSetting  // 2010/08/13
   ,MAHNB01013B_SmallPointProc   // 2010/08/23
   ,MAHNB01013B_ExistTaxRateRangeMethod // 2010/08/30
   ,MAHNB01013B_SetHomeKeyFlg // 2010/09/14
   ,MAHNB01013B_ExistSCMInfo // 2011/02/01
   ,MAHNB01013B_SettingEmpInfo // 2011/03/04
   ,MAHNB01013B_DoAddLine  // 2011/02/12
   ,MAHNB01013B_CooprtKindDiv  // 2011/11/22
   ,MAHNB01013B_DoCacheImage // 2011/02/12
   ,MAHNB01013B_GetErrorFlag // 2011/02/12
   ,MAHNB01013B_DetailDeleteActionTable // 2011/04/13
   ,MAHNB01013B_SetSectionCode // 2011/05/30
   ,MAHNB01013B_StockInfoAdjust // 2011/07/18
   ,MAHNB01013B_BeginControllingByOperationAuthority// ADD 2010/07/08
   ,MAHNB01013B_GetOperationSt // ADD 2014/07/15 T.Miyamoto 仕掛一覧 №1912
   ,MAHNB01013B_SetAfterSaveData
   ,MAHNB01013B_GetAfterSaveData
   ,MAHNB01013B_DoAfterSave
   ,MAHNB01013B_ShowStockDateMsg
   // --- ADD 黄興貴 2015/04/29 回答取込パタン追加 ----->>>>>
   ,MAHNB01013B_ReadUoeData
   ,MAHNB01013B_OptPermitForFuJi
   // --- ADD 黄興貴 2015/04/29 回答取込パタン追加 -----<<<<<
   // --- ADD 紀飛 K2015/06/18 WebUOE発注回答取込 ----->>>>>
   ,MAHNB01013B_OptPermitForMeiGo
   // --- ADD 紀飛 K2015/06/18 WebUOE発注回答取込 -----<<<<<
   ,MAHNB01013B_OptPermitForEBooks//ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応
   // --- UPD 2012/05/31 No.282---------->>>>>
   //,MAHNB01013B_SetInitData;
   ,MAHNB01013B_SetInitData
   // --- UPD 2012/05/31 No.282----------<<<<<
   // --- ADD 2012/05/31 No.282---------->>>>>
   ,MAHNB01013B_uButtonEscClick2
   // --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ---------->>>>>
   ,MAHNB01013B_SetSecondSalesUnPrcGideLocation
   ,MAHNB01013B_OptPermitForMizuno2ndSellPriceCtl
   // --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ----------<<<<<
   // ------  ADD K2015/04/01 高騁 森川部品個別依頼------->>>>>
   ,MAHNB01013B_ReadAllSecStockInfo
   ,MAHNB01013B_OptPermitForMoriKawa
   // ------  ADD K2015/04/01 高騁 森川部品個別依頼-------<<<<<
   // --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- >>>>>
   ,MAHNB01013B_SalesUnPrcCalc
   ,MAHNB01013B_OptPermitForKoei
   // --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- <<<<<
   ,MAHNB01013B_SaveOrderInfo;
   // --- ADD 2012/05/31 No.282----------<<<<<

begin
end.

//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売上伝票入力
// プログラム概要   :
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10601193-00 作成担当 : LDNS
// 作 成 日  2010/05/29  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10601193-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2010/05/30  修正内容 : 成果物統合
//----------------------------------------------------------------------------//
// 管理番号  10601193-00 作成担当 : 譚洪
// 作 成 日  2010/08/13  修正内容 : 障害・改良対応(８月リリース案件)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20056 對馬 大輔
// 作 成 日  2011/02/01  修正内容 : SCM情報存在チェック処理追加
//----------------------------------------------------------------------------//
// 管理番号  10600008-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2011/05/25  修正内容 : SCM改良
//                                : 1)送信確認画面に指示書番号の入力を追加
//                                : 2)フッタ部に指示書番号の入力を追加
//                                : 3)販売区分の入力制御追加
//----------------------------------------------------------------------------//
// 管理番号  10704766-00 作成担当 : 徐錦山
// 作 成 日  2011/08/20  修正内容 : 連番882 元定価が表示のを追加
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30182 立谷 亮介 R.Tachiya
// 作 成 日  2012.07.23  修正内容 : 障害No.995の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 宮本 利明　
// 作 成 日  2012/11/13  修正内容 : 日付制御をオプション化
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 宮本 利明　
// 作 成 日  2012/12/21  修正内容 : 山形部品オプション対応
//----------------------------------------------------------------------------//
unit MAHNB01019C;

interface

Uses
    HDllCall, DBClient, HFSLLIB;

type

    //端末管理設定マスタデータ構造体
    TPosTerminalMg = packed record
        PosPCTermCd: LongInt;    //POS/PC端末区分
    end;

    //端末管理設定マスタデータポインタ型
    PPosTerminalMg = ^TPosTerminalMg;

    //端末管理設定マスタデータ配列型
    TPosTerminalMgArray = array of TPosTerminalMg;

    // -- Add St 2012.07.23 30182 R.Tachiya --
    //受発注管理全体設定マスタデータ構造体
    TAcptAnOdrTtlSt = packed record
      EstmCountReflectDiv : LongInt;  //見積数反映区分
      AcpOdrrSlipPrtDiv : LongInt;    //受注伝票発行区分
      FaxOrderDiv : LongInt;          //ＦＡＸ発注区分
    end;

    //受発注管理全体設定マスタデータポインタ型
    PAcptAnOdrTtlSt = ^TAcptAnOdrTtlSt;

    //受発注管理全体設定マスタデータ配列型
    TAcptAnOdrTtlStArray = array of TAcptAnOdrTtlSt;
    // -- Add Ed 2012.07.23 30182 R.Tachiya --

    //売上全体設定マスタデータ構造体
    TSalesTtlSt = packed record
      AcpOdrAgentDispDiv: LongInt;    //受注者表示区分
      AcpOdrInputDiv: LongInt;    //xxxxxx
      AutoEntryGoodsDivCd: LongInt;    //商品自動登録
      BLGoodsCdInpDiv: LongInt;    //BL商品コード入力区分
      BrSlipNote2DispDiv: LongInt;    //伝票備考２表示区分
      BrSlipNote3DispDiv: LongInt;    //伝票備考３表示区分
      CarMngNoDispDiv: LongInt;    //車輌管理番号表示区分
      CostDspDivCd: LongInt;    //原価表示区分
      CustGuideDispDiv: LongInt;    //得意先ガイド初期表示区分
      DtlNoteDispDiv: LongInt;    //明細備考表示区分
      GrsProfitDspCd: LongInt;    //粗利表示区分
      InpAgentDispDiv: LongInt;    //発行者表示区分
      InpGrsProfChkLowDiv: LongInt;    //入力粗利チェック下限区分
      MakerInpDiv: LongInt;    //メーカー入力区分
      PartsSearchDivCd: LongInt;    //部品検索区分
      RetGoodsStockEtyDiv: LongInt;    //返品時在庫登録区分
      RetSlipChngDivCost: LongInt;    //返品伝票修正区分（原価）
      RetSlipChngDivUnPrc: LongInt;    //返品伝票修正区分（売価）
      SalesAgentChngDiv: LongInt;    //売上担当変更区分
      SalesStockDiv: LongInt;    //売上仕入区分
      SectDspDivCd: LongInt;    //拠点表示区分
      SlipChngDivCost: LongInt;    //伝票修正区分（原価）
      SlipChngDivDate: LongInt;    //伝票修正区分（日付）
      SlipChngDivLPrice: LongInt;    //伝票修正区分（定価）
      SlipDateClrDivCd: LongInt;    //伝票日付クリア区分
      SupplierInpDiv: LongInt;    //仕入先入力区分
      SupplierSlipDelDiv: LongInt;    //仕入伝票削除区分
      UnPrcNonSettingDiv: LongInt;    //売価未設定時区分
      SlipChngDivUnPrc: LongInt;
      InpGrsProfChkUppDiv: LongInt;
      DwnPLCdSpDivCd: LongInt;      // ADD 2010/08/13
      SalesCdDspDivCd: LongInt; // 2011/05/25
      RentStockDiv: LongInt;    // 2012/05/02
    end;

    //売上全体設定マスタデータポインタ型
    PSalesTtlSt = ^TSalesTtlSt;

    //売上全体設定マスタデータ配列型
    TSalesTtlStArray = array of TSalesTtlSt;

    //全体初期値設定マスタデータ構造体
    TAllDefSet = packed record
        EraNameDispCd1: LongInt;    //元号表示区分１
        RemCntAutoDspDiv: LongInt;    //残数自動表示区分
        GoodsNoInpDiv: LongInt;
    end;

    //全体初期値設定マスタデータポインタ型
    PAllDefSet = ^TAllDefSet;

    //全体初期値設定マスタデータ配列型
    TAllDefSetArray = array of TAllDefSet;

    //自社情報設定マスタデータ構造体
    TCompanyInf = packed record
        SecMngDiv: LongInt;    //部署管理区分ド
    end;

    //自社情報設定マスタデータポインタ型
    PCompanyInf = ^TCompanyInf;

    //自社情報設定マスタデータ配列型
    TCompanyInfArray = array of TCompanyInf;


    //関数型定義

    //売上入力で使用する初期データをＤＢより取得関数定義
    TxMAHNB01019B_ReadInitData = function(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

    //売上入力で使用する初期データをＤＢより取得関数定義
    TxMAHNB01019B_ReadInitDataSecond = function(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

    //売上入力で使用する初期データをＤＢより取得関数定義
    TxMAHNB01019B_ReadInitDataThird = function(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

    //売上入力で使用する初期データをＤＢより取得関数定義
    TxMAHNB01019B_ReadInitDataFourth = function(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

    //売上入力で使用する初期データをＤＢより取得関数定義
    TxMAHNB01019B_ReadInitDataFifth = function(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

    //売上入力で使用する初期データをＤＢより取得関数定義
    TxMAHNB01019B_ReadInitDataSixth = function(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

    //売上入力で使用する初期データをＤＢより取得関数定義
    TxMAHNB01019B_ReadInitDataSeventh = function(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

    //売上入力で使用する初期データをＤＢより取得関数定義
    TxMAHNB01019B_ReadInitDataEighth = function(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

    //売上入力で使用する初期データをＤＢより取得関数定義
    TxMAHNB01019B_ReadInitDataNinth = function(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

    //売上入力で使用する初期データをＤＢより取得関数定義
    TxMAHNB01019B_ReadInitDataTenth = function(enterpriseCode: WideString;
    sectionCode: WideString)
    : Integer; stdcall;

    //端末管理マスタ関数定義
    TxMAHNB01019B_GetPosTerminalMg = function(var posTerminalMg: TPosTerminalMg)
    : Integer; stdcall;

    //オプション情報処理関数定義
    TxMAHNB01019B_GetOptInfo = function(var optCarMng: Integer;
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
    //山形部品オプション情報処理関数定義
    TxMAHNB01019B_GetYamagataOptInfo = function(var optStockEntCtrl: Integer;  //売仕入同時入力制御オプション    (OPT-CPM0050)
                                                var optStockDateCtrl: Integer; //仕入日付フォーカス制御オプション(OPT-CPM0060)
                                                var optSalesCostCtrl: Integer  //原価修正制御オプション          (OPT-CPM0070)
                                               ) : Integer; stdcall;
    // --- ADD 2012/12/21 T.Miyamoto ------------------------------<<<<<

    // -- Add St 2012.07.23 30182 R.Tachiya --
    //受発注管理全体設定マスタ関数定義
    TxMAHNB01019B_GetAcptAnOdrTtlSt = function(var acptAnOdrTtlSt: TAcptAnOdrTtlSt)
    : Integer; stdcall;
    // -- Add Ed 2012.07.23 30182 R.Tachiya --

    //売上全体設定マスタ関数定義
    TxMAHNB01019B_GetSalesTtlSt = function(var salesTtlSt: TSalesTtlSt)
    : Integer; stdcall;

    //全体初期値設定マスタ関数定義
    TxMAHNB01019B_GetAllDefSet = function(var allDefSet: TAllDefSet)
    : Integer; stdcall;

    //自社情報設定マスタ関数定義
    TxMAHNB01019B_GetCompanyInf = function(var companyInf: TCompanyInf)
    : Integer; stdcall;

    //売上金額処理区分設定マスタ制御処理関数定義
    TxMAHNB01019B_CacheSalesProcMoneyListCall = function()
    : Integer; stdcall;

    //仕入金額処理区分設定マスタ制御処理関数定義
    TxMAHNB01019B_CacheStockProcMoneyListCall = function()
    : Integer; stdcall;

    //掛率優先管理マスタ制御処理関数定義
    TxMAHNB01019B_CacheRateProtyMngListCall = function()
    : Integer; stdcall;

    //処理区分マスタリスト設定処理関数定義
    TxMAHNB01019B_SettingProcMoney = function()
    : Integer; stdcall;

    PRCHNB01003UADM = ^TRCHNB01003UADM;
    TRCHNB01003UADM = packed record
      BLGoodsCode     : array[0..99] of LongInt;  // BLコード
      GoodsName       : array[0..99] of string;    // 品名
      GoodsNo         : array[0..99] of string;    // 品番
      RowStatus       : array[0..99] of LongInt;   // 行状態
      SalesSlipNum    : array[0..99] of string;    // 売上伝票番号
      SalesRowNo      : array[0..99] of LongInt;    // 売上行番号
      EditStatus      : array[0..99] of LongInt;    //
      AlreadyAddUpCnt : array[0..99] of Double;    //

      GoodsKindCode   : array[0..99] of LongInt;   // 商品属性 0:純正　1:その他
      GoodsMakerCd    : array[0..99] of LongInt;   // メーカーコード
      SupplierCd      : array[0..99] of LongInt;   // 仕入先 コード
      ShipmentCnt     : array[0..99] of Double;    // 出荷数
      StdUnPrcLPrice  : array[0..99] of Double;    // 基準単価（定価）
      SalesUnitCost   : array[0..99] of Double;    // 原価単価

      // 2011/08/20 XUJS ADD STA ------>>>>>>
      StdUnPrcUnCst   : array[0..99] of Double;    // 原価定価
      // 2011/08/20 XUJS ADD END ------<<<<<<

      ShipmentCntDisplay      : array[0..99] of Double;    // 出荷数(表示用)
      AcceptAnOrderCntDisplay : array[0..99] of Double;    // 受注数(表示用)
      SalesSlipCdDtl          : array[0..99] of LongInt;    // 売上伝票区分(明細)
      WarehouseCode           : array[0..99] of string;    // 倉庫コード
      SupplierStockDisplay    : array[0..99] of Double;    // 現在庫数(表示用)

      ListPriceTaxExcFl    : array[0..99] of Double;    // 標準価格
      ListPriceDisplay     : array[0..99] of Double;    // 標準価格(表示用)
      CostRate             : array[0..99] of Double;    // 原価率
      SalesRate            : array[0..99] of Double;    // 売価率
      SalesUnPrcTaxExcFl   : array[0..99] of Double;    // 売単価
      SalesMoneyTaxExc     : array[0..99] of LongInt;   // 売上金額
      StockDate            : array[0..99] of Int64;     // 仕入日

      BoCode               : array[0..99] of string;     // BO
      SupplierCdForOrder   : array[0..99] of LongInt;    // 発注先
      SupplierSnmForOrder  : array[0..99] of string;     // 発注先名称
      AcptAnOdrStatusSrc   : array[0..99] of LongInt;    // 受注ステータス（元）(10:見積,20:受注,30:売上,40:出荷)
      SalesSlipDtlNumSrc   : array[0..99] of LongInt;    // 売上伝票番号（元）
      TaxDiv               : array[0..99] of LongInt;    // 課税・非課税区分
      SalesMoneyInputDiv   : array[0..99] of LongInt;    // 金額手入力区分
      OpenPriceDiv         : array[0..99] of LongInt;    // OP

      DeliveredGoodsDivNm  : array[0..99] of string;     // 納品区分
      SalesCode            : array[0..99] of LongInt;    // 販売区分
      Cost                 : array[0..99] of LongInt;    // 原価
      //DeliGdsCmpltDueDate  : array[0..99] of Int64;      // 納品完了予定 // DEL 2010/07/01
      DeliGdsCmpltDueDate  : array[0..99] of string;      // 納品完了予定  // ADD 2010/07/01
      PartySlipNumDtl      : array[0..99] of string;     // 相手先伝票番号（明細）
      AcceptAnOrderCntForOrder     : array[0..99] of Double;    // 発注数
      FollowDeliGoodsDivNm : array[0..99] of string;    // Ｈ納品区分
      UOEResvdSectionNm    : array[0..99] of string;    // 指定拠点

      UOEDeliGoodsDiv      : array[0..99] of string;     // 納品区分
      FollowDeliGoodsDiv   : array[0..99] of string;    // Ｈ納品区分
      UOEResvdSection      : array[0..99] of string;    // 指定拠点

      WarehouseShelfNo     : array[0..99] of string;    // 倉庫棚番
      PartySalesSlipNum    : array[0..99] of string;     // 仕入伝票番号
      DtlNote              : array[0..99] of string;     // 明細備考
      SalesSlipDtlNum      : array[0..99] of LongInt;     // 明細通番
      AcceptAnOrderNo      : array[0..99] of LongInt;     // 受注番号
      AcptAnOdrStatus      : array[0..99] of LongInt;    // 受注ステータス(10:見積,20:受注,30:売上,40:出荷)
      SearchPartsModeState : array[0..99] of LongInt;    // 部品検索状態

      //>>>2010/05/30
      RecycleDivNm    : array[0..99] of string;    // RC区分名称
      RecycleDiv      : array[0..99] of LongInt;    // RC区分
      GoodsMngNo      : array[0..99] of LongInt;     // PS管理番号
      //<<<2010/05/30

    procedure ClrData(iRow :Integer);

    end;

    // 呼び出しＰＧは以下の関数をＰＧの開始と終わりに呼びます。
function LoadLibraryMAHNB01019B(HDllCALL1: THDLLCALL): Integer;
procedure FreeLibraryMAHNB01019B(HDllCALL1: THDLLCALL);
procedure ClearTPosTerminalMg(var h_PosTerminalMg: TPosTerminalMg);
procedure ClearTAcptAnOdrTtlSt(var h_AcptAnOdrTtlSt: TAcptAnOdrTtlSt);// -- Add 2012.07.23 30182 R.Tachiya --
procedure ClearTSalesTtlSt(var h_SalesTtlSt: TSalesTtlSt);
procedure ClearTAllDefSet(var h_AllDefSet: TAllDefSet);
procedure ClearTCompanyInf(var h_CompanyInf: TCompanyInf);

var
    //関数ポインタ宣言
    gpxMAHNB01019B_ReadInitData : TxMAHNB01019B_ReadInitData;
    gpxMAHNB01019B_ReadInitDataSecond : TxMAHNB01019B_ReadInitDataSecond;
    gpxMAHNB01019B_ReadInitDataThird : TxMAHNB01019B_ReadInitDataThird;
    gpxMAHNB01019B_ReadInitDataFourth : TxMAHNB01019B_ReadInitDataFourth;
    gpxMAHNB01019B_ReadInitDataFifth : TxMAHNB01019B_ReadInitDataFifth;
    gpxMAHNB01019B_ReadInitDataSixth : TxMAHNB01019B_ReadInitDataSixth;
    gpxMAHNB01019B_ReadInitDataSeventh : TxMAHNB01019B_ReadInitDataSeventh;
    gpxMAHNB01019B_ReadInitDataEighth : TxMAHNB01019B_ReadInitDataEighth;
    gpxMAHNB01019B_ReadInitDataNinth : TxMAHNB01019B_ReadInitDataNinth;
    gpxMAHNB01019B_ReadInitDataTenth : TxMAHNB01019B_ReadInitDataTenth;
    gpxMAHNB01019B_GetPosTerminalMg : TxMAHNB01019B_GetPosTerminalMg;
    gpxMAHNB01019B_GetAcptAnOdrTtlSt : TxMAHNB01019B_GetAcptAnOdrTtlSt;// -- Add 2012.07.23 30182 R.Tachiya --
    gpxMAHNB01019B_GetSalesTtlSt : TxMAHNB01019B_GetSalesTtlSt;
    gpxMAHNB01019B_GetAllDefSet : TxMAHNB01019B_GetAllDefSet;
    gpxMAHNB01019B_GetCompanyInf : TxMAHNB01019B_GetCompanyInf;
    gpxMAHNB01019B_CacheSalesProcMoneyListCall : TxMAHNB01019B_CacheSalesProcMoneyListCall;
    gpxMAHNB01019B_CacheStockProcMoneyListCall : TxMAHNB01019B_CacheStockProcMoneyListCall;
    gpxMAHNB01019B_CacheRateProtyMngListCall : TxMAHNB01019B_CacheRateProtyMngListCall;
    gpxMAHNB01019B_SettingProcMoney : TxMAHNB01019B_SettingProcMoney;
    gpxMAHNB01019B_GetOptInfo : TxMAHNB01019B_GetOptInfo;
    gpxMAHNB01019B_GetYamagataOptInfo : TxMAHNB01019B_GetYamagataOptInfo; // ADD 2012/12/21 T.Miyamoto

implementation

// **********************************************************************//
// Module Name     :  初期化部品ロード関数                            //
// :  LoadLibraryMAHNB01019B                            //
// 引数            :  １．HDLLCALL                                      //
// 戻り値          :  ステータス ctFNC_NORMAL : 成功                    //
// :             ctFNC_ERROR  : 失敗                    //
// Programer       :  自動生成                                            //
// Date            :  2010.03.25                                          //
// Note            :  初期化部品ロードします                          //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
// **********************************************************************//
function LoadLibraryMAHNB01019B(HDllCALL1: THDLLCALL): Integer;
var
    nSt: Integer;
begin
    Result := 4;
    HDllCALL1.DllName := 'MAHNB01019B.DLL';
    nSt := HDllCALL1.HLoadLibrary;

    //DLLロード
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '初期化',
            'LoadLibraryMAHNB01019B', 'LOADLIBRARY', '初期化のロードに失敗しました', nSt,
            nil, 0);
        Exit;
    end;

    //売上入力で使用する初期データをＤＢより取得関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01019B_ReadInitData';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_ReadInitData);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '初期化売上入力で使用する',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '初期化売上入力で使用する取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //オプション情報処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01019B_GetOptInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_GetOptInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '車種部品',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '車種部品オプション情報処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // --- ADD 2012/12/21 T.Miyamoto ------------------------------>>>>>
    //山形部品オプション情報処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01019B_GetYamagataOptInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_GetYamagataOptInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '山形部品',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '山形部品オプション情報処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2012/12/21 T.Miyamoto ------------------------------<<<<<

    //売上入力で使用する初期データをＤＢより取得関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01019B_ReadInitDataSecond';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_ReadInitDataSecond);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '初期化部品売上入力で使用する',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '初期化部品売上入力で使用する取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //売上入力で使用する初期データをＤＢより取得関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01019B_ReadInitDataThird';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_ReadInitDataThird);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '初期化部品売上入力で使用する',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '初期化部品売上入力で使用する取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //売上入力で使用する初期データをＤＢより取得関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01019B_ReadInitDataFourth';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_ReadInitDataFourth);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '初期化部品売上入力で使用する',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '初期化部品売上入力で使用する取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //売上入力で使用する初期データをＤＢより取得関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01019B_ReadInitDataFifth';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_ReadInitDataFifth);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '初期化部品売上入力で使用する',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '初期化部品売上入力で使用する取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //売上入力で使用する初期データをＤＢより取得関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01019B_ReadInitDataSixth';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_ReadInitDataSixth);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '初期化部品売上入力で使用する',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '初期化部品売上入力で使用する取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //売上入力で使用する初期データをＤＢより取得関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01019B_ReadInitDataSeventh';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_ReadInitDataSeventh);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '初期化部品売上入力で使用する',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '初期化部品売上入力で使用する取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //売上入力で使用する初期データをＤＢより取得関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01019B_ReadInitDataEighth';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_ReadInitDataEighth);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '初期化部品売上入力で使用する',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '初期化部品売上入力で使用する取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //売上入力で使用する初期データをＤＢより取得関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01019B_ReadInitDataNinth';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_ReadInitDataNinth);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '初期化部品売上入力で使用する',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '初期化部品売上入力で使用する取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //売上入力で使用する初期データをＤＢより取得関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01019B_ReadInitDataTenth';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_ReadInitDataTenth);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '初期化部品売上入力で使用する',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '初期化部品売上入力で使用する取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //端末管理マスタ関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01019B_GetPosTerminalMg';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_GetPosTerminalMg);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '端末管理マスタ',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '端末管理マスタ関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // -- Add St 2012.07.23 30182 R.Tachiya --
    //受発注管理全体設定マスタ関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01019B_GetAcptAnOdrTtlSt';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_GetAcptAnOdrTtlSt);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '受発注管理全体設定マスタ',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '受発注管理全体設定マスタ関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // -- Add Ed 2012.07.23 30182 R.Tachiya --

    //売上全体設定マスタ関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01019B_GetSalesTtlSt';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_GetSalesTtlSt);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '売上全体設定マスタ',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '売上全体設定マスタ関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //全体初期値設定マスタ関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01019B_GetAllDefSet';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_GetAllDefSet);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '全体初期値設定マスタ',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '全体初期値設定マスタ関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //自社情報設定マスタ関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01019B_GetCompanyInf';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_GetCompanyInf);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '自社情報設定マスタ',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '自社情報設定マスタ関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //売上金額処理区分設定マスタ制御処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01019B_CacheSalesProcMoneyListCall';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_CacheSalesProcMoneyListCall);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '売上金額処理区分設定マスタ',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '売上金額処理区分設定マスタ制御処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //仕入金額処理区分設定マスタ制御処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01019B_CacheStockProcMoneyListCall';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_CacheStockProcMoneyListCall);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '仕入金額処理区分設定マスタ',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '仕入金額処理区分設定マスタ制御処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //掛率優先管理マスタ制御処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01019B_CacheRateProtyMngListCall';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_CacheRateProtyMngListCall);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '掛率優先管理マスタ',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '掛率優先管理マスタ制御処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //処理区分マスタリスト設定処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01019B_SettingProcMoney';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01019B_SettingProcMoney);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01019C', '処理区分マスタ',
            'LoadLibraryMAHNB01019B', 'GETPROCADDRESS',
            '処理区分マスタリスト設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;


    Result := 0;

end;

// **********************************************************************//
// Module Name     :  初期化部品フリー関数                        //
// :  FreeLibraryMAHNB01019B                            //
// 引数            :  １．HDLLCALL                                      //
// 戻り値          :  無し                                              //
// Programer       :  自動生成                                            //
// Date            :  2010.03.25                                          //
// Note            :  初期化部品フリーします                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
// **********************************************************************//
procedure FreeLibraryMAHNB01019B(HDllCALL1: THDLLCALL);
begin
    HDllCALL1.DllName := 'MAHNB01019B.DLL';
    HDllCALL1.HFreeLibrary;
    gpxMAHNB01019B_ReadInitData := nil;
    gpxMAHNB01019B_ReadInitDataSecond := nil;
    gpxMAHNB01019B_ReadInitDataThird := nil;
    gpxMAHNB01019B_ReadInitDataFourth := nil;
    gpxMAHNB01019B_ReadInitDataFifth := nil;
    gpxMAHNB01019B_ReadInitDataSixth := nil;
    gpxMAHNB01019B_ReadInitDataSeventh := nil;
    gpxMAHNB01019B_ReadInitDataEighth := nil;
    gpxMAHNB01019B_ReadInitDataNinth := nil;
    gpxMAHNB01019B_ReadInitDataTenth := nil;
    gpxMAHNB01019B_GetPosTerminalMg := nil;
    gpxMAHNB01019B_GetAcptAnOdrTtlSt := nil;// -- Add 2012.07.23 30182 R.Tachiya --
    gpxMAHNB01019B_GetSalesTtlSt := nil;
    gpxMAHNB01019B_GetAllDefSet := nil;
    gpxMAHNB01019B_GetCompanyInf := nil;
    gpxMAHNB01019B_CacheSalesProcMoneyListCall := nil;
    gpxMAHNB01019B_CacheStockProcMoneyListCall := nil;
    gpxMAHNB01019B_CacheRateProtyMngListCall := nil;
    gpxMAHNB01019B_SettingProcMoney := nil;
    gpxMAHNB01019B_GetOptInfo := nil;
    gpxMAHNB01019B_GetYamagataOptInfo := nil; // ADD 2012/12/21 T.Miyamoto

end;

// **********************************************************************//
// Module Name     :  初期化部品フリー関数                        //
// :  ClearTPosTerminalMg                            //
// 引数            :  １．端末管理設定マスタ                                      //
// 戻り値          :  無し                                              //
// Programer       :  自動生成                                            //
// Date            :  2010.03.25                                          //
// Note            :  初期化部品フリーします                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
// **********************************************************************//
procedure ClearTPosTerminalMg(var h_PosTerminalMg: TPosTerminalMg);
var
  i: Integer;
  guidcleararray: array [0 .. 15] of AnsiChar;
begin
  h_PosTerminalMg.PosPCTermCd := 0;
end;

// -- Add St 2012.07.23 30182 R.Tachiya --
// **********************************************************************//
// Module Name     :  初期化部品フリー関数                               //
// :  ClearTAcptAnOdrTtlSt                                               //
// 引数            :  １．受発注管理全体設定マスタ                       //
// 戻り値          :  無し                                               //
// Programer       :  30182 立谷亮介 R.Tachiya                           //
// Date            :  2012.07.23                                         //
// Note            :  初期化部品フリーします                             //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                             //
// **********************************************************************//
procedure ClearTAcptAnOdrTtlSt(var h_AcptAnOdrTtlSt: TAcptAnOdrTtlSt);
var
  i: Integer;
  guidcleararray: array [0 .. 15] of AnsiChar;
begin
  h_AcptAnOdrTtlSt.EstmCountReflectDiv := 0;
  h_AcptAnOdrTtlSt.AcpOdrrSlipPrtDiv := 0;
  h_AcptAnOdrTtlSt.FaxOrderDiv := 0;
end;
// -- Add Ed 2012.07.23 30182 R.Tachiya --

// **********************************************************************//
// Module Name     :  初期化部品フリー関数                        //
// :  ClearTSalesTtlSt                            //
// 引数            :  １．売上全体設定マスタ                                      //
// 戻り値          :  無し                                              //
// Programer       :  自動生成                                            //
// Date            :  2010.03.25                                          //
// Note            :  初期化部品フリーします                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
// **********************************************************************//
procedure ClearTSalesTtlSt(var h_SalesTtlSt: TSalesTtlSt);
var
  i: Integer;
  guidcleararray: array [0 .. 15] of AnsiChar;
begin
  h_SalesTtlSt.AcpOdrAgentDispDiv := 0;
  h_SalesTtlSt.AcpOdrInputDiv := 0;
  h_SalesTtlSt.AutoEntryGoodsDivCd := 0;
  h_SalesTtlSt.BLGoodsCdInpDiv := 0;
  h_SalesTtlSt.BrSlipNote2DispDiv := 0;
  h_SalesTtlSt.BrSlipNote3DispDiv := 0;
  h_SalesTtlSt.CarMngNoDispDiv := 0;
  h_SalesTtlSt.CostDspDivCd := 0;
  h_SalesTtlSt.CustGuideDispDiv := 0;
  h_SalesTtlSt.DtlNoteDispDiv := 0;
  h_SalesTtlSt.GrsProfitDspCd := 0;
  h_SalesTtlSt.InpAgentDispDiv := 0;
  h_SalesTtlSt.InpGrsProfChkLowDiv := 0;
  h_SalesTtlSt.MakerInpDiv := 0;
  h_SalesTtlSt.PartsSearchDivCd := 0;
  h_SalesTtlSt.RetGoodsStockEtyDiv := 0;
  h_SalesTtlSt.RetSlipChngDivCost := 0;
  h_SalesTtlSt.RetSlipChngDivUnPrc := 0;
  h_SalesTtlSt.SalesAgentChngDiv := 0;
  h_SalesTtlSt.SalesStockDiv := 0;
  h_SalesTtlSt.SectDspDivCd := 0;
  h_SalesTtlSt.SlipChngDivCost := 0;
  h_SalesTtlSt.SlipChngDivDate := 0;
  h_SalesTtlSt.SlipChngDivLPrice := 0;
  h_SalesTtlSt.SlipDateClrDivCd := 0;
  h_SalesTtlSt.SupplierInpDiv := 0;
  h_SalesTtlSt.SupplierSlipDelDiv := 0;
  h_SalesTtlSt.UnPrcNonSettingDiv := 0;
  h_SalesTtlSt.InpGrsProfChkUppDiv :=0;
  h_SalesTtlSt.DwnPLCdSpDivCd :=0;        // ADD 2010/08/13
  h_SalesTtlSt.SalesCdDspDivCd := 0; // 2011/05/25
  h_SalesTtlSt.RentStockDiv := 0; // 2012/05/02
end;

// **********************************************************************//
// Module Name     :  初期化部品フリー関数                        //
// :  ClearTAllDefSet                            //
// 引数            :  １．全体初期値設定マスタ                                      //
// 戻り値          :  無し                                              //
// Programer       :  自動生成                                            //
// Date            :  2010.03.25                                          //
// Note            :  初期化部品フリーします                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
// **********************************************************************//
procedure ClearTAllDefSet(var h_AllDefSet: TAllDefSet);
var
  i: Integer;
  guidcleararray: array [0 .. 15] of AnsiChar;
begin
  h_AllDefSet.EraNameDispCd1 := 0;
  h_AllDefSet.RemCntAutoDspDiv := 0;
end;

// **********************************************************************//
// Module Name     :  初期化部品フリー関数                        //
// :  ClearTCompanyInf                            //
// 引数            :  １．自社情報設定マスタ                                      //
// 戻り値          :  無し                                              //
// Programer       :  自動生成                                            //
// Date            :  2010.03.25                                          //
// Note            :  初期化部品フリーします                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
// **********************************************************************//
procedure ClearTCompanyInf(var h_CompanyInf: TCompanyInf);
var
  i: Integer;
  guidcleararray: array [0 .. 15] of AnsiChar;
begin
  h_CompanyInf.SecMngDiv := 0;
end;

procedure TRCHNB01003UADM.ClrData(iRow : Integer);
begin
   if (iRow <= 99) then
   BLGoodsCode[iRow] := 0;
   GoodsName[iRow] := '';
   GoodsNo[iRow] := '';
   RowStatus[iRow] := 0;
   SalesSlipNum[iRow] := '';
   SalesRowNo[iRow] := 0;
   EditStatus[iRow] := 0;
   AlreadyAddUpCnt[iRow] := 0;

   GoodsKindCode[iRow] := 0;
   GoodsMakerCd[iRow] := 0;
   SupplierCd[iRow] := 0;
   ShipmentCnt[iRow] := 0;
   StdUnPrcLPrice[iRow] := 0;
   SalesUnitCost[iRow] := 0;

   // 2011/08/20 XUJS ADD STA ------>>>>>>
   StdUnPrcUnCst[iRow] := 0;
   // 2011/08/20 XUJS ADD END ------<<<<<<

   ShipmentCntDisplay[iRow] := 0;
   AcceptAnOrderCntDisplay[iRow] := 0;
   SalesSlipCdDtl[iRow] := 0;
   WarehouseCode[iRow] := '';
   SupplierStockDisplay[iRow] := 0;

   ListPriceTaxExcFl[iRow] := 0;
   CostRate[iRow] := 0;
   SalesRate[iRow] := 0;
   SalesUnPrcTaxExcFl[iRow] := 0;
   SalesMoneyTaxExc[iRow] := 0;
   StockDate[iRow] := 0;

   BoCode[iRow] := '';
   SupplierCdForOrder[iRow] := 0;
   SupplierSnmForOrder[iRow] := '';
   AcptAnOdrStatusSrc[iRow] := 0;
   SalesSlipDtlNumSrc[iRow] := 0;
   TaxDiv[iRow] := 0;
   SalesMoneyInputDiv[iRow] := 0;
   OpenPriceDiv[iRow] := 0;

   DeliveredGoodsDivNm[iRow] := '';
   SalesCode[iRow] := 0;
   Cost[iRow] := 0;
   //DeliGdsCmpltDueDate[iRow] := 0; // DEL 2010/07/01
   DeliGdsCmpltDueDate[iRow] := '';  // ADD 2010/07/01
   PartySlipNumDtl[iRow] := '';
   AcceptAnOrderCntForOrder[iRow] := 0;
   FollowDeliGoodsDivNm[iRow] := '';
   UOEResvdSectionNm[iRow] := '';

   UOEDeliGoodsDiv[iRow] := '';
   FollowDeliGoodsDiv[iRow] := '';
   UOEResvdSection[iRow] := '';
   WarehouseShelfNo[iRow] := '';
   PartySalesSlipNum[iRow] := '';
   DtlNote[iRow] := '';
   SalesSlipDtlNum[iRow] := 0;
   AcceptAnOrderNo[iRow] := 0;
   AcptAnOdrStatus[iRow] := 0;
   SearchPartsModeState[iRow] := 0;

   //>>>2010/05/30
   RecycleDivNm[iRow] := '';
   RecycleDiv[iRow] := 0;
   GoodsMngNo[iRow] := 0;
   //<<<2010/05/30
end;

end.

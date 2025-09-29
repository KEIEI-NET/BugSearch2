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
// 管理番号              作成担当 : 22018 鈴木 正臣
// 作 成 日  2010/06/12  修正内容 : 携帯メール機能の組込
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20056 對馬 大輔
// 作 成 日  2011/02/01  修正内容 : SCM情報存在チェック処理追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 作 成 日  2011/07/18  修正内容 : 回答区分の追加
//----------------------------------------------------------------------------//
// 管理番号  10703874-00 作成担当 : yangyi
// 作 成 日  K2011/08/12 修正内容 : イスコ個別対応
//----------------------------------------------------------------------------//
// 管理番号  10707327-00 作成担当 : 李占川
// 作 成 日  2012/02/09  修正内容 : アプリケーション終了処理前に、印刷中フラグの判断を追加する
//----------------------------------------------------------------------------//
// 管理番号  10707327-00 作成担当 : 鄧潘ハン
// 作 成 日  2012/03/12  修正内容 : Redmine#28288
//                                  行を追加して更新を行うと、送信済みのチェックがかかるについての修正
//----------------------------------------------------------------------------//
// 管理番号  10900269-00 作成担当 : FSI今野 利裕
// 作 成 日  2013/03/21  修正内容 : SPK車台番号文字列対応
//----------------------------------------------------------------------------//
// 管理番号  11070071-00 作成担当 : 宮本　利明
// 作 成 日  2014/05/19  修正内容 : 仕掛一覧№2218 車輌備考欄にコード入力項目を追加
//----------------------------------------------------------------------------//

unit MAHNB01012C;

interface

Uses
    HDllCall, DBClient, HFSLLIB;

type

    // add by gaofeng start
    //売上データデータ構造体
    TSalesSlip = packed record
        AcptAnOdrStatus: LongInt;    //受注ステータス
        SalesSlipNum: WideString;    //売上伝票番号
        SectionCode: WideString;    //拠点コード
        InputMode: LongInt;    //拠点コード
        SalesSlipDisplay : LongInt; // 売上伝票区分(画面表示用)
        AcptAnOdrStatusDisplay: LongInt;
        CarMngDivCd: LongInt;
        SubSectionCode: LongInt;    //部門コード
        SubSectionName: WideString;    //部門名称
        DebitNoteDiv: LongInt;    //赤伝区分
        DebitNLnkSalesSlNum: WideString;    //赤黒連結売上伝票番号
        SalesSlipCd: LongInt;    //売上伝票区分
        SalesGoodsCd: LongInt;    //売上商品区分
        AccRecDivCd: LongInt;    //売掛区分
        SalesInpSecCd: WideString;    //売上入力拠点コード
        DemandAddUpSecCd: WideString;    //請求計上拠点コード
        ResultsAddUpSecCd: WideString;    //実績計上拠点コード
        ResultsAddUpSecNm: WideString;
        UpdateSecCd: WideString;    //更新拠点コード
        SalesSlipUpdateCd: LongInt;    //売上伝票更新区分
        SearchSlipDate: Int64;    //伝票検索日付
        ShipmentDay: Int64;    //出荷日付
        SalesDate: Int64;    //売上日付
        AddUpADate: Int64;    //計上日付
        DelayPaymentDiv: LongInt;    //来勘区分
        EstimateFormNo: WideString;    //見積書番号
        EstimateDivide: LongInt;    //見積区分
        InputAgenCd: WideString;    //入力担当者コード
        InputAgenNm: WideString;    //入力担当者名称
        SalesInputCode: WideString;    //売上入力者コード
        SalesInputName: WideString;    //売上入力者名称
        FrontEmployeeCd: WideString;    //受付従業員コード
        FrontEmployeeNm: WideString;    //受付従業員名称
        SalesEmployeeCd: WideString;    //販売従業員コード
        SalesEmployeeNm: WideString;    //販売従業員名称
        TotalAmountDispWayCd: LongInt;    //総額表示方法区分
        TtlAmntDispRateApy: LongInt;    //総額表示掛率適用区分
        SalesTotalTaxInc: Int64;    //売上伝票合計（税込み）
        SalesTotalTaxExc: Int64;    //売上伝票合計（税抜き）
        SalesPrtTotalTaxInc: Int64;    //売上部品合計（税込み）
        SalesPrtTotalTaxExc: Int64;    //売上部品合計（税抜き）
        SalesWorkTotalTaxInc: Int64;    //売上作業合計（税込み）
        SalesWorkTotalTaxExc: Int64;    //売上作業合計（税抜き）
        SalesSubtotalTaxInc: Int64;    //売上小計（税込み）
        SalesSubtotalTaxExc: Int64;    //売上小計（税抜き）
        SalesPrtSubttlInc: Int64;    //売上部品小計（税込み）
        SalesPrtSubttlExc: Int64;    //売上部品小計（税抜き）
        SalesWorkSubttlInc: Int64;    //売上作業小計（税込み）
        SalesWorkSubttlExc: Int64;    //売上作業小計（税抜き）
        SalesNetPrice: Int64;    //売上正価金額
        SalesSubtotalTax: Int64;    //売上小計（税）
        ItdedSalesOutTax: Int64;    //売上外税対象額
        ItdedSalesInTax: Int64;    //売上内税対象額
        SalSubttlSubToTaxFre: Int64;    //売上小計非課税対象額
        SalesOutTax: Int64;    //売上金額消費税額（外税）
        SalAmntConsTaxInclu: Int64;    //売上金額消費税額（内税）
        SalesDisTtlTaxExc: Int64;    //売上値引金額計（税抜き）
        ItdedSalesDisOutTax: Int64;    //売上値引外税対象額合計
        ItdedSalesDisInTax: Int64;    //売上値引内税対象額合計
        ItdedPartsDisOutTax: Int64;    //部品値引対象額合計（税抜き）
        ItdedPartsDisInTax: Int64;    //部品値引対象額合計（税込み）
        ItdedWorkDisOutTax: Int64;    //作業値引対象額合計（税抜き）
        ItdedWorkDisInTax: Int64;    //作業値引対象額合計（税込み）
        ItdedSalesDisTaxFre: Int64;    //売上値引非課税対象額合計
        SalesDisOutTax: Int64;    //売上値引消費税額（外税）
        SalesDisTtlTaxInclu: Int64;    //売上値引消費税額（内税）
        PartsDiscountRate: Double;    //部品値引率
        RavorDiscountRate: Double;    //工賃値引率
        TotalCost: Int64;    //原価金額計
        ConsTaxLayMethod: LongInt;    //消費税転嫁方式
        ConsTaxRate: Double;    //消費税税率
        FractionProcCd: LongInt;    //端数処理区分
        AccRecConsTax: Int64;    //売掛消費税
        AutoDepositCd: LongInt;    //自動入金区分
        AutoDepositSlipNo: LongInt;    //自動入金伝票番号
        DepositAllowanceTtl: Int64;    //入金引当合計額
        DepositAlwcBlnce: Int64;    //入金引当残高
        ClaimCode: LongInt;    //請求先コード
        ClaimSnm: WideString;    //請求先略称
        CustomerCode: LongInt;    //得意先コード
        CustomerName: WideString;    //得意先名称
        CustomerName2: WideString;    //得意先名称2
        CustomerSnm: WideString;    //得意先略称
        HonorificTitle: WideString;    //敬称
        OutputNameCode: LongInt;    //諸口コード
        OutputName: WideString;    //諸口名称
        CustSlipNo: LongInt;    //得意先伝票番号
        SlipAddressDiv: LongInt;    //伝票住所区分
        AddresseeCode: LongInt;    //納品先コード
        AddresseeName: WideString;    //納品先名称
        AddresseeName2: WideString;    //納品先名称2
        AddresseePostNo: WideString;    //納品先郵便番号
        AddresseeAddr1: WideString;    //納品先住所1(都道府県市区郡・町村・字)
        AddresseeAddr3: WideString;    //納品先住所3(番地)
        AddresseeAddr4: WideString;    //納品先住所4(アパート名称)
        AddresseeTelNo: WideString;    //納品先電話番号
        AddresseeFaxNo: WideString;    //納品先FAX番号
        PartySaleSlipNum: WideString;    //相手先伝票番号
        SlipNote: WideString;    //伝票備考
        SlipNote2: WideString;    //伝票備考２
        SlipNote3: WideString;    //伝票備考３
        SlipNoteCode: LongInt;    //伝票備考
        SlipNote2Code: LongInt;    //伝票備考２
        SlipNote3Code: LongInt;    //伝票備考３
        RetGoodsReasonDiv: LongInt;    //返品理由コード
        RetGoodsReason: WideString;    //返品理由
        RegiProcDate: Int64;    //レジ処理日
        CashRegisterNo: LongInt;    //レジ番号
        PosReceiptNo: LongInt;    //POSレシート番号
        DetailRowCount: LongInt;    //明細行数
        EdiSendDate: Int64;    //ＥＤＩ送信日
        EdiTakeInDate: Int64;    //ＥＤＩ取込日
        UoeRemark1: WideString;    //ＵＯＥリマーク１
        UoeRemark2: WideString;    //ＵＯＥリマーク２
        SlipPrintDivCd: LongInt;    //伝票発行区分
        SlipPrintFinishCd: LongInt;    //伝票発行済区分
        SalesSlipPrintDate: Int64;    //売上伝票発行日
        BusinessTypeCode: LongInt;    //業種コード
        BusinessTypeName: WideString;    //業種名称
        OrderNumber: WideString;    //発注番号
        DeliveredGoodsDiv: LongInt;    //納品区分
        DeliveredGoodsDivNm: WideString;    //納品区分名称
        SalesAreaCode: LongInt;    //販売エリアコード
        SalesAreaName: WideString;    //販売エリア名称
        ReconcileFlag: LongInt;    //消込フラグ
        SlipPrtSetPaperId: WideString;    //伝票印刷設定用帳票ID
        CompleteCd: LongInt;    //一式伝票区分
        SalesPriceFracProcCd: LongInt;    //売上金額端数処理区分
        StockGoodsTtlTaxExc: Int64;    //在庫商品合計金額（税抜）
        PureGoodsTtlTaxExc: Int64;    //純正商品合計金額（税抜）
        ListPricePrintDiv: LongInt;    //定価印刷区分
        EraNameDispCd1: LongInt;    //元号表示区分１
        EstimaTaxDivCd: LongInt;    //見積消費税区分
        EstimateFormPrtCd: LongInt;    //見積書印刷区分
        EstimateSubject: WideString;    //見積件名
        Footnotes1: WideString;    //脚注１
        Footnotes2: WideString;    //脚注２
        EstimateTitle1: WideString;    //見積タイトル１
        EstimateTitle2: WideString;    //見積タイトル２
        EstimateTitle3: WideString;    //見積タイトル３
        EstimateTitle4: WideString;    //見積タイトル４
        EstimateTitle5: WideString;    //見積タイトル５
        EstimateNote1: WideString;    //見積備考１
        EstimateNote2: WideString;    //見積備考２
        EstimateNote3: WideString;    //見積備考３
        EstimateNote4: WideString;    //見積備考４
        EstimateNote5: WideString;    //見積備考５
        EstimateValidityDate: Int64;    //見積有効期限
        PartsNoPrtCd: LongInt;    //品番印字区分
        OptionPringDivCd: LongInt;    //オプション印字区分
        RateUseCode: LongInt;    //掛率使用区分
        CreateDateTime: Int64;    //作成日時
        UpdateDateTime: Int64;    //更新日時
        EnterpriseCode: WideString;    //企業コード
        FileHeaderGuid: array [0 .. 15] of AnsiChar;    //GUID
        UpdEmployeeCode: WideString;    //更新従業員コード
        UpdAssemblyId1: WideString;    //更新アセンブリID1
        UpdAssemblyId2: WideString;    //更新アセンブリID2
        CustOrderNoDispDiv: LongInt;
        CustWarehouseCd : WideString; //得意先優先倉庫コード
        CreditMngCode: LongInt;
        DetailRowCountForReadSlip: LongInt;  //明細行数
        //>>>2010/05/30
        OnlineKindDiv : LongInt;
        InqOriginalEpCd : WideString;
        InqOriginalSecCd : WideString;
        AnswerDiv : Integer;
        InquiryNumber : Int64;
        InqOrdDivCd : Integer;
        //<<<2010/05/30
        AutoAnswerDivSCM : Integer; // 自動回答区分(SCM)  2011/07/18 zhubj
        PreSalesDate : Int64;    //ADD 鄧潘ハン 2012/03/12 Redmine#28288
    end;

    //売上データデータポインタ型
    PSalesSlip = ^TSalesSlip;

    //売上データデータ配列型
    TSalesSlipArray = array of TSalesSlip;

    //売上データデータ構造体 TCarMngGuideParamInfo
    TCarMangInputExtraInfo = packed record
        AddiCarSpec1: WideString;    //追加諸元1
        AddiCarSpec2: WideString;    //追加諸元2
        AddiCarSpec3: WideString;    //追加諸元3
        AddiCarSpec4: WideString;    //追加諸元4
        AddiCarSpec5: WideString;    //追加諸元5
        AddiCarSpec6: WideString;    //追加諸元6
        AddiCarSpecTitle1: WideString;    //追加諸元タイトル1
        AddiCarSpecTitle2: WideString;    //追加諸元タイトル2
        AddiCarSpecTitle3: WideString;    //追加諸元タイトル3
        AddiCarSpecTitle4: WideString;    //追加諸元タイトル4
        AddiCarSpecTitle5: WideString;    //追加諸元タイトル5
        AddiCarSpecTitle6: WideString;    //追加諸元タイトル6
        BlockIllustrationCd: LongInt;    //ブロックイラストコード
        BodyName: WideString;    //ボディー名称
        BodyNameCode: LongInt;    //ボディー名コード
        CarAddInfo1: WideString;    //車輌追加情報１
        CarAddInfo2: WideString;    //車輌追加情報２
        CarInspectYear: LongInt;    //車検期間
        CarMngCode: WideString;    //車輌管理コード
        CarMngNo: LongInt;    //車両管理番号
        CarNo: WideString;    //号車
        CarNote: WideString;    //車輌備考
        CarRelationGuid: array [0 .. 15] of AnsiChar;    //車両関連付けGUID
        CategoryNo: LongInt;    //類別番号
//        CategoryObjAry: WideString;    //装備オブジェクト配列
        CategorySignModel: WideString;    //型式（類別記号）
        ColorCode: WideString;    //カラーコード
        ColorName1: WideString;    //カラー名称1
        CreateDateTime: Int64;    //作成日時
        CustomerCode: LongInt;    //得意先コード
        CustomerCodeForGuide: WideString;    //得意先コード
        CustomerName: LongInt;    //得意先名称
        DoorCount: LongInt;    //ドア数
        EDivNm: WideString;    //E区分名称
        EdProduceFrameNo: LongInt;    //生産車台番号終了
        EdProduceTypeOfYear: Int64;    //終了生産年式
        EngineDisplaceNm: WideString;    //排気量名称
        EngineModel: WideString;    //原動機型式（エンジン）
        EngineModelNm: WideString;    //エンジン型式名称
        EnterpriseCode: WideString;    //企業コード
        EntryDate: Int64;    // 登録年月日
        ExhaustGasSign: WideString;    //排ガス記号
        FileHeaderGuid: array [0 .. 15] of AnsiChar;    //GUID
        FirstEntryDate: LongInt;    //初年度
        FrameModel: WideString;    //車台型式
        FrameNo: WideString;    //車台番号
        FullModel: WideString;    //型式（フル型）
//        FullModelFixedNoAry: WideString;    //フル型式固定番号配列
        InspectMaturityDate: Int64;    //車検満期日
        LogicalDeleteCode: LongInt;    //論理削除区分
        LTimeCiMatDate: Int64;    //前回車検満期日
        MakerCode: LongInt;    //メーカーコード
        MakerFullName: WideString;    //メーカー全角名称
        MakerHalfName: WideString;    //メーカー半角名称
        Mileage: LongInt;    //車両走行距離
        ModelCode: LongInt;    //車種コード
        ModelDesignationNo: LongInt;    //型式指定番号
        ModelFullName: WideString;    //車種全角名称
        ModelGradeNm: WideString;    //型式グレード名称
        ModelGradeSname: WideString;    //型式グレード略称
        ModelHalfName: WideString;    //車種半角名称
        ModelSubCode: LongInt;    //車種サブコード
        NumberPlate1Code: LongInt;    //陸運事務所番号
        NumberPlate1Name: WideString;    //陸運事務局名称
        NumberPlate2: WideString;    //車両登録番号（種別）
        NumberPlate3: WideString;    //車両登録番号（カナ）
        NumberPlate4: LongInt;    //車両登録番号（プレート番号）
        NumberPlateForGuide: WideString;    //車両登録番号（ガイド用）
        PartsDataOfferFlag: LongInt;    //部品データ提供フラグプ
        ProduceTypeOfYearCd: LongInt;    //生産年式コード
        ProduceTypeOfYearInput: LongInt;    //年式
        ProduceTypeOfYearNm: WideString;    //生産年式名称
        RelevanceModel: WideString;    //関連型式
        SearchFrameNo: LongInt;    //車台番号（検索用）
        SeriesModel: WideString;    //シリーズ型式
        ShiftNm: WideString;    //シフト名称
        StProduceFrameNo: LongInt;    //生産車台番号開始
        StProduceTypeOfYear: Int64;    //開始生産年式
        SubCarNmCd: LongInt;    //サブ車名コード
        SystematicCode: LongInt;    //系統コード
        SystematicName: WideString;    //系統名称
        ThreeDIllustNo: LongInt;    //3DイラストNo
        TransmissionNm: WideString;    //ミッション名称
        TrimCode: WideString;    //トリムコード
        TrimName: WideString;    //トリム名称
        UpdateDateTime: Int64;    //更新日時
        WheelDriveMethodNm: WideString;    //駆動方式名称
        DomesticForeignCode: LongInt;    //国産/外車区分 // ADD 2013/03/21
    end;

    //売上データデータポインタ型
    PCarMangInputExtraInfo = ^TCarMangInputExtraInfo;

    //売上データデータ配列型
    TCarMangInputExtraInfoArray = array of TCarMangInputExtraInfo;

    //車種名称マスタデータ構造体
    TModelNameU = packed record
        CreateDateTime: Int64;    //作成日時
        CreateDateTimeAdFormal: WideString;    //作成日時 西暦
        CreateDateTimeAdInFormal: WideString;    //作成日時 西暦(略)
        CreateDateTimeJpFormal: WideString;    //作成日時 和暦
        CreateDateTimeJpInFormal: WideString;    //作成日時 和暦(略)
        Division: LongInt;    //表示区分
        DivisionName: WideString;    //表示区分名称
        EnterpriseCode: WideString;    //企業コード
        EnterpriseName: WideString;    //企業名称
        FileHeaderGuid: array [0 .. 15] of AnsiChar;    //GUID
        LogicalDeleteCode: LongInt;    //論理削除区分
        MakerCode: LongInt;    //メーカーコード
        ModelAliasName: WideString;    //車種呼び名名称
        ModelCode: LongInt;    //車種コード
        ModelFullName: WideString;    //車種全角名称
        ModelHalfName: WideString;    //車種半角名称
        ModelSubCode: LongInt;    //車種サブコード
        ModelUniqueCode: LongInt;    //車種コード（ユニーク）
        OfferDataDiv: LongInt;    //提供データ区分
        OfferDate: Int64;    //提供日付
        UpdAssemblyId1: WideString;    //更新アセンブリID1
        UpdAssemblyId2: WideString;    //更新アセンブリID2
        UpdateDateTime: Int64;    //更新日時
        UpdateDateTimeAdFormal: WideString;    //更新日時 西暦
        UpdateDateTimeAdInFormal: WideString;    //更新日時 西暦(略)
        UpdateDateTimeJpFormal: WideString;    //更新日時 和暦
        UpdateDateTimeJpInFormal: WideString;    //更新日時 和暦(略)
        UpdEmployeeCode: WideString;    //更新従業員コード
        UpdEmployeeName: WideString;    //更新従業員名称
    end;

    //車種名称マスタデータポインタ型
    PModelNameU = ^TModelNameU;

    //車種名称マスタデータ配列型
    TModelNameUArray = array of TModelNameU;

    //データ構造体
    TUserGdHd = packed record
        CreateDateTime          : Int64;    //作成日時
        CreateDateTimeAdFormal  : WideString;    //作成日時 西暦
        CreateDateTimeAdInFormal: WideString;    //作成日時 西暦(略)
        CreateDateTimeJpFormal  : WideString;    //作成日時 和暦
        CreateDateTimeJpInFormal: WideString;    //作成日時 和暦(略)
        LogicalDeleteCode       : LongInt;    //論理削除区分
        MasterOfferCd           : LongInt;    //XXXX
        UpdateDateTime          : Int64;    //更新日時
        UpdateDateTimeAdFormal  : WideString;    //更新日時 西暦
        UpdateDateTimeAdInFormal: WideString;    //更新日時 西暦(略)
        UpdateDateTimeJpFormal  : WideString;    //更新日時 和暦
        UpdateDateTimeJpInFormal: WideString;    //更新日時 和暦(略)
        UserGuideDivCd          : WideString;    //更新従業員コード
        UserGuideDivNm          : WideString;    //更新従業員名称
    end;

    //データポインタ型
    PUserGdHd = ^TUserGdHd;

    //データ配列型
    TUserGdHdArray = array of TUserGdHd;

    //データ構造体
    TUserGdBd = packed record
        CreateDateTime            : Int64;    //作成日時
        CreateDateTimeAdFormal    : WideString;    //作成日時西暦
        CreateDateTimeAdInFormal  : WideString;    //作成日時西暦(略)
        CreateDateTimeJpFormal    : WideString;    //作成日時和暦
        CreateDateTimeJpInFormal  : WideString;    //作成日時和暦(略)
        EnterpriseCode            : WideString;    //企業コード
        EnterpriseName            : WideString;    //企業名称
        FileHeaderGuid            : array [0 .. 15] of AnsiChar;    //GUID
        GuideCode                 : LongInt;    //ガイドコード
        GuideName                 : WideString;    //ガイド名称
        GuideType                 : LongInt;    //ガイドタイプ
        LogicalDeleteCode         : LongInt;    //論理削除区分
        UpdAssemblyId1            : WideString;    //更新アセンブリID1
        UpdAssemblyId2            : WideString;    //更新アセンブリID2
        UpdateDateTime          : Int64;    //更新日時
        UpdateDateTimeAdFormal    : WideString;    //更新日時 西暦
        UpdateDateTimeAdInFormal  : WideString;    //更新日時 西暦(略)
        UpdateDateTimeJpFormal    : WideString;    //更新日時 和暦
        UpdateDateTimeJpInFormal  : WideString;    //更新日時 和暦(略)
        UpdEmployeeCode           : WideString;    //更新従業員コード
        UpdEmployeeName           : WideString;    //更新従業員名称
        UserGuideDivCd            : LongInt;    //更新従業員コード
    end;

    //データポインタ型
    PUserGdBd = ^TUserGdBd;

    //データ配列型
    TUserGdBdArray = array of TUserGdBd;

    TCustomerInfo = packed record
        AcceptWholeSale: LongInt;
        AccountNoInfo1: WideString;
        AccountNoInfo2: WideString;
        AccountNoInfo3: WideString;
        AccRecDivCd: LongInt;
        AcpOdrrSlipPrtDiv: LongInt;
        Address1: WideString;
        Address3: WideString;
        Address4: WideString;
        BillCollecterCd: WideString;
        BillCollecterNm: WideString;
        BillHonorificTtl: WideString;
        BillHonorTtlPrtDiv: LongInt;
        BillOutputCode: LongInt;
        BillOutPutCodeNm: WideString;
        BillOutputName: WideString;
        BillPartsNoPrtCd: LongInt;
        BusinessTypeCode: LongInt;
        BusinessTypeName: WideString;
        CarMngDivCd: LongInt;
        ClaimCode: LongInt;
        ClaimName: WideString;
        ClaimName2: WideString;
        ClaimSectionCode: WideString;
        ClaimSectionName: WideString;
        ClaimSnm: WideString;
        CollectCond: LongInt;
        CollectMoneyCode: LongInt;
        CollectMoneyDay: LongInt;
        CollectMoneyName: WideString;
        CollectSight: LongInt;
        ConsTaxLayMethod: LongInt;
        CorporateDivCode: LongInt;
        CreateDateTime: Int64;
        CreateDateTimeAdFormal: WideString;
        CreateDateTimeAdInFormal: WideString;
        CreateDateTimeJpFormal: WideString;
        CreateDateTimeJpInFormal: WideString;
        CreditMngCode: LongInt;
        CustAgentChgDate: Int64;
        CustAnalysCode1: LongInt;
        CustAnalysCode2: LongInt;
        CustAnalysCode3: LongInt;
        CustAnalysCode4: LongInt;
        CustAnalysCode5: LongInt;
        CustAnalysCode6: LongInt;
        CustCTaXLayRefCd: LongInt;
        CustomerAgent: WideString;
        CustomerAgentCd: WideString;
        CustomerAgentNm: WideString;
        CustomerAttributeDiv: LongInt;
        CustomerCode: LongInt;
        CustomerEpCode: WideString;
        CustomerSecCode: WideString;
        CustomerSlipNoDiv: LongInt;
        CustomerSnm: WideString;
        CustomerSubCode: WideString;
        CustSlipNoMngCd: LongInt;
        CustWarehouseCd: WideString;
        CustWarehouseName: WideString;
        DefSalesSlipCd: LongInt;
        DeliHonorificTtl: WideString;
        DeliHonorTtlPrtDiv: LongInt;
        DeliPartsNoPrtCd: LongInt;
        DepoBankCode: LongInt;
        DepoBankName: WideString;
        DepoDelCode: LongInt;
        DmOutCode: LongInt;
        DmOutName: WideString;
        EnterpriseCode: WideString;
        EnterpriseName: WideString;
        EstimatePrtDiv: LongInt;
        EstmHonorificTtl: WideString;
        EstmHonorTtlPrtDiv: LongInt;
        GuidFileHeaderGuid: array [0 .. 15] of AnsiChar;
        HomeFaxNo: WideString;
        HomeFaxNoDspName: WideString;
        HomeTelNo: WideString;
        HomeTelNoDspName: WideString;
        HonorificTitle: WideString;
        InpSectionCode: WideString;
        InpSectionName: WideString;
        IsCustomer: Boolean;
        IsReceiver: Boolean;
        JobTypeCode: LongInt;
        JobTypeName: WideString;
        Kana: WideString;
        LavorRateRank: LongInt;
        LogicalDeleteCode: LongInt;
        MailAddress1: WideString;
        MailAddress2: WideString;
        MailAddrKindCode1: LongInt;
        MailAddrKindCode2: LongInt;
        MailAddrKindName1: WideString;
        MailAddrKindName2: WideString;
        MailSendCode1: LongInt;
        MailSendCode2: LongInt;
        MailSendName1: WideString;
        MailSendName2: WideString;
        MainContactCode: LongInt;
        MainContactName: WideString;
        MainSendMailAddrCd: LongInt;
        MngSectionCode: WideString;
        MngSectionName: WideString;
        MobileTelNoDspName: WideString;
        Name: WideString;
        Name2: WideString;
        Note1: WideString;
        Note10: WideString;
        Note2: WideString;
        Note3: WideString;
        Note4: WideString;
        Note5: WideString;
        Note6: WideString;
        Note7: WideString;
        Note8: WideString;
        Note9: WideString;
        NTimeCalcStDate: LongInt;
        OfficeFaxNo: WideString;
        OfficeFaxNoDspName: WideString;
        OfficeTelNo: WideString;
        OfficeTelNoDspName: WideString;
        OldCustomerAgentCd: WideString;
        OldCustomerAgentNm: WideString;
        OnlineKindDiv: LongInt;
        OthersTelNo: WideString;
        OtherTelNoDspName: WideString;
        OutputName: WideString;
        OutputNameCode: LongInt;
        PortableTelNo: WideString;
        PostNo: WideString;
        PrslOrCorpDivNm: WideString;
        PureCode: LongInt;
        QrcodePrtCd: LongInt;
        ReceiptOutputCode: LongInt;
        RectHonorificTtl: WideString;
        RectHonorTtlPrtDiv: LongInt;
        SalesAreaCode: LongInt;
        SalesAreaName: WideString;
        SalesCnsTaxFrcProcCd: LongInt;
        SalesMoneyFrcProcCd: LongInt;
        SalesSlipPrtDiv: LongInt;
        SalesUnPrcFrcProcCd: LongInt;
        SearchTelNo: WideString;
        ShipmSlipPrtDiv: LongInt;
        SlipTtlPrn: LongInt;
        TotalAmntDspWayRef: LongInt;
        TotalAmountDispWayCd: LongInt;
        TotalDay: LongInt;
        TransStopDate: Int64;
        UOESlipPrtDiv: LongInt;
        UpdAssemblyId1: WideString;
        UpdAssemblyId2: WideString;
        UpdateDateTime: Int64;
        UpdateDateTimeAdFormal: WideString;
        UpdateDateTimeAdInFormal: WideString;
        UpdateDateTimeJpFormal: WideString;
        UpdateDateTimeJpInFormal: WideString;
        UpdEmployeeCode: WideString;
        UpdEmployeeName: WideString;
    end;
    // add by gaofeng end

    //関数型定義

    // add by Zhangkai start
    //売上明細データデータ構造体
    TSalesDetail = packed record
        AcptAnOdrStatus: LongInt;    //受注ステータス
        SalesSlipNum: WideString;    //売上伝票番号
        SalesRowNo: LongInt;    //売上行番号
        SalesRowDerivNo: LongInt;    //売上行番号枝番
        SectionCode: WideString;    //拠点コード
        SubSectionCode: LongInt;    //部門コード
        SalesDate: LongInt;    //売上日付
        CommonSeqNo: Int64;    //共通通番
        SalesSlipDtlNum: Int64;    //売上明細通番
        AcptAnOdrStatusSrc: LongInt;    //受注ステータス（元）
        SalesSlipDtlNumSrc: Int64;    //売上明細通番（元）
        SupplierFormalSync: LongInt;    //仕入形式（同時）
        StockSlipDtlNumSync: Int64;    //仕入明細通番（同時）
        SalesSlipCdDtl: LongInt;    //売上伝票区分（明細）
        //DeliGdsCmpltDueDate: Int64;    //納品完了予定日// DEL 2010/07/01
        DeliGdsCmpltDueDate: WideString;    //納品完了予定日// ADD 2010/07/01
        GoodsKindCode: LongInt;    //商品属性
        GoodsSearchDivCd: LongInt;    //商品検索区分
        GoodsMakerCd: LongInt;    //商品メーカーコード
        MakerName: WideString;    //メーカー名称
        MakerKanaName: WideString;    //メーカーカナ名称
        GoodsNo: WideString;    //商品番号
        GoodsName: WideString;    //商品名称
        GoodsNameKana: WideString;    //商品名称カナ
        GoodsLGroup: LongInt;    //商品大分類コード
        GoodsLGroupName: WideString;    //商品大分類名称
        GoodsMGroup: LongInt;    //商品中分類コード
        GoodsMGroupName: WideString;    //商品中分類名称
        BLGroupCode: LongInt;    //BLグループコード
        BLGroupName: WideString;    //BLグループコード名称
        BLGoodsCode: LongInt;    //BL商品コード
        BLGoodsFullName: WideString;    //BL商品コード名称（全角）
        EnterpriseGanreCode: LongInt;    //自社分類コード
        EnterpriseGanreName: WideString;    //自社分類名称
        WarehouseCode: WideString;    //倉庫コード
        WarehouseName: WideString;    //倉庫名称
        WarehouseShelfNo: WideString;    //倉庫棚番
        SalesOrderDivCd: LongInt;    //売上在庫取寄せ区分
        OpenPriceDiv: LongInt;    //オープン価格区分
        GoodsRateRank: WideString;    //商品掛率ランク
        CustRateGrpCode: LongInt;    //得意先掛率グループコード
        ListPriceRate: Double;    //定価率
        RateSectPriceUnPrc: WideString;    //掛率設定拠点（定価）
        RateDivLPrice: WideString;    //掛率設定区分（定価）
        UnPrcCalcCdLPrice: LongInt;    //単価算出区分（定価）
        PriceCdLPrice: LongInt;    //価格区分（定価）
        StdUnPrcLPrice: Double;    //基準単価（定価）
        FracProcUnitLPrice: Double;    //端数処理単位（定価）
        FracProcLPrice: LongInt;    //端数処理（定価）
        ListPriceTaxIncFl: Double;    //定価（税込，浮動）
        ListPriceTaxExcFl: Double;    //定価（税抜，浮動）
        ListPriceChngCd: LongInt;    //定価変更区分
        SalesRate: Double;    //売価率
        RateSectSalUnPrc: WideString;    //掛率設定拠点（売上単価）
        RateDivSalUnPrc: WideString;    //掛率設定区分（売上単価）
        UnPrcCalcCdSalUnPrc: LongInt;    //単価算出区分（売上単価）
        PriceCdSalUnPrc: LongInt;    //価格区分（売上単価）
        StdUnPrcSalUnPrc: Double;    //基準単価（売上単価）
        FracProcUnitSalUnPrc: Double;    //端数処理単位（売上単価）
        FracProcSalUnPrc: LongInt;    //端数処理（売上単価）
        SalesUnPrcTaxIncFl: Double;    //売上単価（税込，浮動）
        SalesUnPrcTaxExcFl: Double;    //売上単価（税抜，浮動）
        SalesUnPrcChngCd: LongInt;    //売上単価変更区分
        CostRate: Double;    //原価率
        RateSectCstUnPrc: WideString;    //掛率設定拠点（原価単価）
        RateDivUnCst: WideString;    //掛率設定区分（原価単価）
        UnPrcCalcCdUnCst: LongInt;    //単価算出区分（原価単価）
        PriceCdUnCst: LongInt;    //価格区分（原価単価）
        StdUnPrcUnCst: Double;    //基準単価（原価単価）
        FracProcUnitUnCst: Double;    //端数処理単位（原価単価）
        FracProcUnCst: LongInt;    //端数処理（原価単価）
        SalesUnitCost: Double;    //原価単価
        SalesUnitCostChngDiv: LongInt;    //原価単価変更区分
        RateBLGoodsCode: LongInt;    //BL商品コード（掛率）
        RateBLGoodsName: WideString;    //BL商品コード名称（掛率）
        RateGoodsRateGrpCd: LongInt;    //商品掛率グループコード（掛率）
        RateGoodsRateGrpNm: WideString;    //商品掛率グループ名称（掛率）
        RateBLGroupCode: LongInt;    //BLグループコード（掛率）
        RateBLGroupName: WideString;    //BLグループ名称（掛率）
        PrtBLGoodsCode: LongInt;    //BL商品コード（印刷）
        PrtBLGoodsName: WideString;    //BL商品コード名称（印刷）
        SalesCode: LongInt;    //販売区分コード
        SalesCdNm: WideString;    //販売区分名称
        WorkManHour: Double;    //作業工数
        ShipmentCnt: Double;    //出荷数
        AcceptAnOrderCnt: Double;    //受注数量
        AcptAnOdrAdjustCnt: Double;    //受注調整数
        AcptAnOdrRemainCnt: Double;    //受注残数
        RemainCntUpdDate: LongInt;    //残数更新日
        SalesMoneyTaxInc: Int64;    //売上金額（税込み）
        SalesMoneyTaxExc: Int64;    //売上金額（税抜き）
        Cost: Int64;    //原価
        GrsProfitChkDiv: LongInt;    //粗利チェック区分
        SalesGoodsCd: LongInt;    //売上商品区分
        SalesPriceConsTax: Int64;    //売上金額消費税額
        TaxationDivCd: LongInt;    //課税区分
        PartySlipNumDtl: WideString;    //相手先伝票番号（明細）
        DtlNote: WideString;    //明細備考
        SupplierCd: LongInt;    //仕入先コード
        SupplierSnm: WideString;    //仕入先略称
        OrderNumber: WideString;    //発注番号
        WayToOrder: LongInt;    //注文方法
        SlipMemo1: WideString;    //伝票メモ１
        SlipMemo2: WideString;    //伝票メモ２
        SlipMemo3: WideString;    //伝票メモ３
        InsideMemo1: WideString;    //社内メモ１
        InsideMemo2: WideString;    //社内メモ２
        InsideMemo3: WideString;    //社内メモ３
        BfListPrice: Double;    //変更前定価
        BfSalesUnitPrice: Double;    //変更前売価
        BfUnitCost: Double;    //変更前原価
        CmpltSalesRowNo: LongInt;    //一式明細番号
        CmpltGoodsMakerCd: LongInt;    //メーカーコード（一式）
        CmpltMakerName: WideString;    //メーカー名称（一式）
        CmpltMakerKanaName: WideString;    //メーカーカナ名称（一式）
        CmpltGoodsName: WideString;    //商品名称（一式）
        CmpltShipmentCnt: Double;    //数量（一式）
        CmpltSalesUnPrcFl: Double;    //売上単価（一式）
        CmpltSalesMoney: Int64;    //売上金額（一式）
        CmpltSalesUnitCost: Double;    //原価単価（一式）
        CmpltCost: Int64;    //原価金額（一式）
        CmpltPartySalSlNum: WideString;    //相手先伝票番号（一式）
        CmpltNote: WideString;    //一式備考
        PrtGoodsNo: WideString;    //印刷用品番
        PrtMakerCode: LongInt;    //印刷用メーカーコード
        PrtMakerName: WideString;    //印刷用メーカー名称
        EditStatus:  LongInt;
        RowStatus:   LongInt;//行状態
        SalesMoneyInputDiv:  LongInt;//金額手入力区分
        ShipmentCntDisplay: Double; //出荷数(表示用)
        SupplierStockDisplay: Double; //現在庫数(表示用)
        ListPriceDisplay: Double; //標準価格(表示用)
        StockDate: Int64;    //仕入日
        BoCode: WideString;    //BO
        SupplierCdForOrder: LongInt;    //発注先
        SupplierSnmForOrder: WideString;    //発注先名称
        DeliveredGoodsDivNm: WideString;    //納品区分
        FollowDeliGoodsDivNm: WideString;    //Ｈ納品区
        UOEResvdSectionNm: WideString;    //指定拠点
        UOEDeliGoodsDiv: WideString;    //納品区分
        FollowDeliGoodsDiv: WideString;    //Ｈ納品区
        UOEResvdSection: WideString;    //指定拠点
        PartySalesSlipNum : WideString; //仕入伝票番号
        AcceptAnOrderNo :  LongInt; //受注番号
        SearchPartsModeState : LongInt; //部品検索状態
        //>>>2010/05/30
//        CampaignCode : Integer;
//        CampaignName : WideString;
//        GoodsDivCd : Integer;
//        AnswerDelivDate : WideString;
        RecycleDiv : Integer;
        RecycleDivNm : WideString;
//        WayToAcptOdr : Integer;
        GoodsMngNo : Integer;
//        InqRowNumber : Integer;
//        InqRowNumDerivedNo : Integer;
        //<<<2010/05/30
    end;

    //売上明細データデータポインタ型
    PSalesDetail = ^TSalesDetail;

    //売上明細データデータ配列型
    TSalesDetailArray = array of TSalesDetail;

    TSalesSlipInputCustomArrayA2 = packed record
        Csafield1: PSalesDetail;
        Csafield1Count: LongInt;
    end;

    PSalesSlipInputCustomArrayA2 = ^TSalesSlipInputCustomArrayA2;

    TSalesSlipInputCustomArrayA2Array = array of TSalesSlipInputCustomArrayA2;
    // add by Zhangkai end

    // add by Lizc start
    //カラー情報データ構造体
    TColorInfo = packed record
        ColorCode: WideString;    //カラーコード
        ColorName: WideString;    //カラー名称
        MakerCode: LongInt;    //メーカーコード
        ModelCode: LongInt;    //車種コード
        ModelSubCode: LongInt;    //車種サブコード
        SelectionState: Boolean;    //選択状態
    end;

    //カラー情報データポインタ型
    PColorInfo = ^TColorInfo;

    //カラー情報データ配列型
    TColorInfoArray = array of TColorInfo;

    //トリム情報データ構造体
    TTrimInfo = packed record
        MakerCode: LongInt;    //メーカーコード
        ModelCode: LongInt;    //車種コード
        ModelSubCode: LongInt;    //車種サブコード
        TrimCode: WideString;    //トリムコード
        TrimName: WideString;    //トリム名称
        SelectionState: Boolean;    //選択状態
    end;

    //トリム情報データポインタ型
    PTrimInfo = ^TTrimInfo;

    //トリム情報データ配列型
    TTrimInfoArray = array of TTrimInfo;

    //装備情報データ構造体
    TCEqpDefDspInfo = packed record
        EquipmentCode: LongInt;    //xxxxxxxxxxxx
        EquipmentDispOrder: LongInt;    //xxxxxxxxxxxx
        EquipmentGenreCd: LongInt;    //xxxxxxxxxxxx
        EquipmentGenreNm: WideString;    //xxxxxxxxxxxx
        EquipmentIconCode: LongInt;    //xxxxxxxxxxxx
        EquipmentName: WideString;    //xxxxxxxxxxxx
        EquipmentShortName: WideString;    //xxxxxxxxxxxx
        MakerCode: LongInt;    //メーカーコード
        ModelCode: LongInt;    //車種コード
        ModelSubCode: LongInt;    //車種サブコード
        SelectionState: Boolean;    //選択状態
        SystematicCode: LongInt;    //xxxxxxxxxxxx
    end;

    //装備情報データポインタ型
    PCEqpDefDspInfo = ^TCEqpDefDspInfo;

    //装備情報データ配列型
    TCEqpDefDspInfoArray = array of TCEqpDefDspInfo;

    //諸元情報データ構造体
    TCarSpecInfo = packed record
        ModelGradeNm: WideString;    //グレード
        BodyName: WideString;    //ボディ
        DoorCount: LongInt;    //ドア
        EDivNm: WideString;    //Ｅ区分
        EngineDisplaceNm: WideString;    //排気量
        EngineModelNm: WideString;    //エンジン
        ShiftNm: WideString;    //シフト
        TransmissionNm: WideString;    //ミッション
        WheelDriveMethodNm: WideString;    //駆動方式
        AddiCarSpec1: WideString;    //追加諸元１
        AddiCarSpec2: WideString;    //追加諸元２
        AddiCarSpec3: WideString;    //追加諸元３
        AddiCarSpec4: WideString;    //追加諸元４
        AddiCarSpec5: WideString;    //追加諸元５
        AddiCarSpec6: WideString;    //追加諸元６
    end;

    //諸元情報データポインタ型
    PCarSpecInfo = ^TCarSpecInfo;

    //諸元情報データ配列型
    TCarSpecInfoArray = array of TCarSpecInfo;

    //車両情報データ構造体
    TCarInfo = packed record
        CarRelationGuid: WideString;    //得意先コード
        CustomerCode: LongInt;    //得意先コード
        CarMngNo: LongInt;    //車両管理番号
        CarMngCode: WideString;    //車輌管理コード
        NumberPlate1Code: LongInt;    //陸運事務所番号
        NumberPlate1Name: WideString;    //陸運事務局名称
        NumberPlate2: WideString;    //車両登録番号（種別）
        NumberPlate3: WideString;    //車両登録番号（カナ）
        NumberPlate4: LongInt;    //車両登録番号（プレート番号）
        EntryDate: Int64;    //登録年月日
        FirstEntryDate: LongInt;    //初年度
        MakerCode: LongInt;    //メーカーコード
        MakerFullName: WideString;    //メーカー全角名称
        MakerHalfName: WideString;    //メーカー半角名称
        ModelCode: LongInt;    //車種コード
        ModelSubCode: LongInt;    //車種サブコード
        ModelFullName: WideString;    //車種全角名称
        ModelHalfName: WideString;    //車種半角名称
        SystematicCode: LongInt;    //系統コード
        SystematicName: WideString;    //系統名称
        ProduceTypeOfYearCd: LongInt;    //生産年式コード
        ProduceTypeOfYearNm: WideString;    //生産年式名称
        StProduceTypeOfYear: Int64;    //開始生産年式
        EdProduceTypeOfYear: Int64;    //終了生産年式
        DoorCount: LongInt;    //ドア数
        BodyNameCode: LongInt;    //ボディー名コード
        BodyName: WideString;    //ボディー名称
        ExhaustGasSign: WideString;    //排ガス記号
        SeriesModel: WideString;    //シリーズ型式
        CategorySignModel: WideString;    //型式（類別記号）
        FullModel: WideString;    //型式（フル型）
        ModelDesignationNo: LongInt;    //型式指定番号
        CategoryNo: LongInt;    //類別番号
        FrameModel: WideString;    //車台型式
        FrameNo: WideString;    //車台番号
        SearchFrameNo: LongInt;    //車台番号（検索用）
        StProduceFrameNo: LongInt;    //生産車台番号開始
        EdProduceFrameNo: LongInt;    //生産車台番号終了
        ModelGradeNm: WideString;    //型式グレード名称
        EngineModelNm: WideString;    //エンジン型式名称
        EngineDisplaceNm: WideString;    //排気量名称
        EDivNm: WideString;    //E区分名称
        TransmissionNm: WideString;    //ミッション名称
        ShiftNm: WideString;    //シフト名称
        WheelDriveMethodNm: WideString;    //駆動方式名称
        AddiCarSpec1: WideString;    //追加諸元1
        AddiCarSpec2: WideString;    //追加諸元2
        AddiCarSpec3: WideString;    //追加諸元3
        AddiCarSpec4: WideString;    //追加諸元4
        AddiCarSpec5: WideString;    //追加諸元5
        AddiCarSpec6: WideString;    //追加諸元6
        AddiCarSpecTitle1: WideString;    //追加諸元タイトル1
        AddiCarSpecTitle2: WideString;    //追加諸元タイトル2
        AddiCarSpecTitle3: WideString;    //追加諸元タイトル3
        AddiCarSpecTitle4: WideString;    //追加諸元タイトル4
        AddiCarSpecTitle5: WideString;    //追加諸元タイトル5
        AddiCarSpecTitle6: WideString;    //追加諸元タイトル6
        RelevanceModel: WideString;    //関連型式
        SubCarNmCd: LongInt;    //サブ車名コード
        ModelGradeSname: WideString;    //型式グレード略称
        BlockIllustrationCd: LongInt;    //ブロックイラストコード
        ThreeDIllustNo: LongInt;    //3DイラストNo
        PartsDataOfferFlag: LongInt;    //部品データ提供フラグ
        InspectMaturityDate: Int64;    //車検満期日
        LTimeCiMatDate: Int64;    //前回車検満期日
        CarInspectYear: LongInt;    //車検期間
        Mileage: LongInt;    //車両走行距離
        CarNo: WideString;    //号車
        FullModelFixedNoAry: WideString;    //フル型式固定番号配列
        CategoryObjAry: WideString;    //装備オブジェクト配列
        ProduceTypeOfYearInput: LongInt;    //生産年式
        ColorCode: WideString;    //カラーコード
        ColorName1: WideString;    //カラー名称1
        TrimCode: WideString;    //トリムコード
        TrimName: WideString;    //トリム名称
        AcceptAnOrderNo: LongInt;    //受注番号
        CarNote: WideString;    //車輌備考
        CarAddInfo1: WideString;    //車輌追加情報１
        CarAddInfo2: WideString;    //車輌追加情報２
        EngineModel: WideString;    //車輌備考
        ProduceTypeOfYearRange: WideString;    //生産年式
        ProduceFrameNoRange: WideString;    //生産車台番号
        DomesticForeignCode: LongInt;    //国産/外車区分 // ADD 2013/03/21
        CarNoteCode: Integer;   //車輌備考コード // ADD 2014/05/19 T.Miyamoto 仕掛一覧№2218
    end;

    //車両情報データポインタ型
    PCarInfo = ^TCarInfo;

    //車両情報データ配列型
    TCarInfoArray = array of TCarInfo;

    //型式データ構造体
    TCarModel = packed record
        CategorySign: WideString;    //型式（類別記号）
        ExhaustGasSign: WideString;    //排ガス記号
        FullModel: WideString;    //型式（フル型）
        IsFullModel: Boolean;    //
        SeriesModel: WideString;    //シリーズ型式
    end;

    //型式データポインタ型
    PCarModel = ^TCarModel;

    //型式データ配列型
    TCarModelArray = array of TCarModel;

    //原動機型式データ構造体
    TEngineModel = packed record
        FullModel: WideString;    //型式
        Model: WideString;    //車種
        ModelNm: WideString;    //車種名称
    end;

    //原動機型式データポインタ型
    PEngineModel = ^TEngineModel;

    //原動機型式データ配列型
    TEngineModelArray = array of TEngineModel;

    //車両検索条件データ構造体
    TCarSearchCondition = packed record
        CarModel: TCarModel;    //車種コード
        CategoryNo: LongInt;    //類別番号
        EngineModel: TEngineModel;    //原動機型式（エンジン）
        EraNameDispCd1: LongInt;    //
        IsReady: Boolean;    //
        MakerCode: LongInt;    //メーカーコード
        ModelCode: LongInt;    //車種コード
        ModelDesignationNo: LongInt;    //型式指定番号
        ModelPlate: WideString;    //
        ModelSubCode: LongInt;    //車種サブコード
    end;

    //車両検索条件データポインタ型
    PCarSearchCondition = ^TCarSearchCondition;

    //車両検索条件データ配列型
    TCarSearchConditionArray = array of TCarSearchCondition;

    TSalesSlipInputCustomArrayB4 = packed record
    Csafield1: PCEqpDefDspInfo;
    Csafield1Count: LongInt;
    end;

    PSalesSlipInputCustomArrayB4 = ^TSalesSlipInputCustomArrayB4;

    TSalesSlipInputCustomArrayB4Array = array of TSalesSlipInputCustomArrayB4;

    TSalesSlipInputCustomArrayB3 = packed record
        Csafield1: PTrimInfo;
        Csafield1Count: LongInt;
    end;

    PSalesSlipInputCustomArrayB3 = ^TSalesSlipInputCustomArrayB3;

    TSalesSlipInputCustomArrayB3Array = array of TSalesSlipInputCustomArrayB3;

    TSalesSlipInputCustomArrayB2 = packed record
        Csafield1: PColorInfo;
        Csafield1Count: LongInt;
    end;

    PSalesSlipInputCustomArrayB2 = ^TSalesSlipInputCustomArrayB2;

    TSalesSlipInputCustomArrayB2Array = array of TSalesSlipInputCustomArrayB2;

      // 車輌情報保持用
    BeforeCarSearchBuffer = packed record
        ProduceFrameNo          : WideString;  // 車台番号
        FirstEntryDate          : LongInt;     // 生産年式
        ColorNo                 : WideString;  // カラーコード
        TrimNo                  : WideString;  // トリムコード
    end;

    //ヘッダー部フォーカス移動設定クラスデータ構造体
    THeaderFocusConstruction = packed record
        Key: WideString;    //キー
        Caption: WideString;    //項目表示名称
        EnterStop: WideString;    //移動有無
    end;

    //ヘッダー部フォーカス移動設定クラスデータポインタ型
    PHeaderFocusConstruction = ^THeaderFocusConstruction;

    //ヘッダー部フォーカス移動設定クラスデータ配列型
    THeaderFocusConstructionArray = array of THeaderFocusConstruction;

    //フッタ部フォーカス移動設定クラスデータ構造体
    TFooterFocusConstruction = packed record
        Key: WideString;    //キー
        Caption: WideString;    //項目表示名称
        EnterStop: WideString;    //移動有無
    end;

    //フッタ部フォーカス移動設定クラスデータポインタ型
    PFooterFocusConstruction = ^TFooterFocusConstruction;

    //フッタ部フォーカス移動設定クラスデータ配列型
    TFooterFocusConstructionArray = array of TFooterFocusConstruction;

    TSalesSlipInputCustomArrayB6 = packed record
        Csafield1: PFooterFocusConstruction;
        Csafield1Count: LongInt;
    end;

    PSalesSlipInputCustomArrayB6 = ^TSalesSlipInputCustomArrayB6;

    TSalesSlipInputCustomArrayB6Array = array of TSalesSlipInputCustomArrayB6;

    TSalesSlipInputCustomArrayB5 = packed record
        Csafield1: PHeaderFocusConstruction;
        Csafield1Count: LongInt;
    end;

    PSalesSlipInputCustomArrayB5 = ^TSalesSlipInputCustomArrayB5;

    TSalesSlipInputCustomArrayB5Array = array of TSalesSlipInputCustomArrayB5;
    // add by Lizc end

    // add by Yangmj start

    // add by Yangmj end

    // add by Tanhong start
    //オプション情報処理関数定義
    TxMAHNB01012B_GetSettingOptionInfo = function(var optCarMng: Integer;
    var optStockingPayment: Integer)
    : Integer; stdcall;

    // add by Tanhong end

    //関数型定義

    // add by gaofeng start
    //拠点ガイド処理関数定義
    TxMAHNB01012B_sectionGuide = function(enterpriseCode: WideString;
    formName: WideString;
    var salesSlip: TSalesSlip)
    : Integer; stdcall;

    //部門ガイド処理関数定義
    TxMAHNB01012B_subSectionGuide = function(enterpriseCode: WideString;
    var salesSlip: TSalesSlip)
    : Integer; stdcall;

    //従業員ガイド処理関数定義
    TxMAHNB01012B_employeeGuide = function(sender: WideString;
    enterpriseCode: WideString;
    salesInputNm: WideString;
    salesInputCode: WideString;
    var salesSlip: TSalesSlip;
    var isReInputErr: Boolean)
    : Integer; stdcall;

    //管理番号ガイド処理関数定義
    TxMAHNB01012B_carMngNoGuide = function(customerCode: Integer;
    enterpriseCode: WideString;
    var selectedInfo: TCarMangInputExtraInfo;
    var resultStatus: Integer;
    salesRowNo: Integer;
    carMngCode: string)
    : Integer; stdcall;

    //車種ガイド処理関数定義
    TxMAHNB01012B_modelFullGuide = function(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer;
    enterpriseCode: WideString;
    salesRowNo: Integer;
    var modelNameU: TModelNameU)
    : Integer; stdcall;

    //備考ガイドボタン処理関数定義
    TxMAHNB01012B_slipNote = function(sender: WideString;
    enterpriseCode: WideString;
    var salesSlip: TSalesSlip)
    : Integer; stdcall;

    //率算定処理関数定義
    TxMAHNB01012B_GetRate = function(numerator: Double;
    denominator: Double;
    var rate: Double)
    : Integer; stdcall;

    // --- ADD 2010/05/31 ---------->>>>>
    //CalculationSalesPrice関数定義
    TxMAHNB01012B_CalculationSalesPrice = function()
    : Integer; stdcall;
    // --- ADD 2010/05/31 ----------<<<<<
    // add by gaofeng end

    // add by Zhangkai start


    // add by Zhangkai end

    // add by Lizc start
    //車両検索処理関数定義
    TxMAHNB01012B_CarSearch = function(condition: TCarSearchCondition;
    salesRowNo: Integer;
    conditionType: Integer)
    : Integer; stdcall;

    //車両情報行オブジェクト取得関数定義
    TxMAHNB01012B_GetCarInfoRow = function(salesRowNo: Integer;
    getCarInfoMode: Integer;
    var carInfo: TCarInfo)
    : Integer; stdcall;

    //カラー情報取得処理関数定義
    TxMAHNB01012B_GetColorInfo = function(carRelationGuid: WideString;
    var colorInfoList: TSalesSlipInputCustomArrayB2)
    : Integer; stdcall;

    //選択カラー情報取得処理関数定義
    TxMAHNB01012B_GetSelectColorInfo = function(carRelationGuid: WideString;
    var colorInfo: TColorInfo)
    : Integer; stdcall;

    //トリム情報取得処理関数定義
    TxMAHNB01012B_GetTrimInfo = function(carRelationGuid: WideString;
    var trimInfoList: TSalesSlipInputCustomArrayB3)
    : Integer; stdcall;

    //選択トリム情報取得処理関数定義
    TxMAHNB01012B_GetSelectTrimInfo = function(carRelationGuid: WideString;
    var trimInfo: TTrimInfo)
    : Integer; stdcall;

    //装備情報取得処理関数定義
    TxMAHNB01012B_GetEquipInfo = function(carRelationGuid: WideString;
    var cEqpDefDspInfoList: TSalesSlipInputCustomArrayB4)
    : Integer; stdcall;

    //カラー情報選択処理関数定義
    TxMAHNB01012B_SelectColorInfo = function(carRelationGuid: WideString;
    colorCode: WideString)
    : Boolean; stdcall;

    //トリム情報選択処理関数定義
    TxMAHNB01012B_SelectTrimInfo = function(carRelationGuid: WideString;
    trimCode: WideString)
    : Boolean; stdcall;

    //生産年式範囲チェック関数定義
    TxMAHNB01012B_CheckProduceTypeOfYearRange = function(carRelationGuid: WideString;
    firstEntryDate: Integer)
    : Integer; stdcall;

    //車両検索データテーブル年式設定処理関数定義
    TxMAHNB01012B_SettingCarModelUIDataFromFirstEntryDate = function(carRelationGuid: WideString;
    firstEntryDate: WideString)
    : Integer; stdcall;

    //車台番号範囲チェック関数定義
    TxMAHNB01012B_CheckProduceFrameNo = function(carRelationGuid: WideString;
    inputFrameNo: WideString;
    searchFrameNo: Integer)
    : Integer; stdcall;

    //車両検索データテーブル車台番号設定処理関数定義
    TxMAHNB01012B_SettingCarModelUIDataFromProduceFrameNo = function(carRelationGuid: WideString;
    frameNo: WideString)
    : Integer; stdcall;

    //対象年式取得処理(車台番号より取得)関数定義
    TxMAHNB01012B_GetProduceTypeOfYear = function(carRelationGuid: WideString;
    frameNo: WideString)
    : Integer; stdcall;

    //車両情報テーブルのクリア関数定義
    TxMAHNB01012B_ClearCarInfoRow = function(salesRowNo: Integer)
    : Integer; stdcall;

    //車両情報テーブル行の年式セット関数定義
    TxMAHNB01012B_SettingCarInfoRowFromFirstEntryDate = function(salesRowNo: Integer;
    firstEntryDate: Integer)
    : Integer; stdcall;

    //車両情報テーブル行の車台番号セット関数定義
    TxMAHNB01012B_SettingCarInfoRowFromFrameNo = function(salesRowNo: Integer;
    frameNo: WideString)
    : Integer; stdcall;

    //車両情報テーブル行の車種情報セット関数定義
    TxMAHNB01012B_SettingCarInfoRowFromModelInfo = function(salesRowNo: Integer;
    makerCode: Integer;
    makerFullName: WideString;
    makerHalfName: WideString;
    modelCode: Integer;
    modelSubCode: Integer;
    modelFullName: WideString;
    modelHalfName: WideString)
    : Integer; stdcall;

    //車種名称取得処理関数定義
    TxMAHNB01012B_GetModelFullName = function(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer)
    : Integer; stdcall;

    //車種半角名称取得処理関数定義
    TxMAHNB01012B_GetModelHalfName = function(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer)
    : Integer; stdcall;

    //車両情報テーブル行の管理番号セット関数定義
    TxMAHNB01012B_SettingCarInfoRowFromCarMngCode = function(salesRowNo: Integer;
    carMngCode: WideString)
    : Integer; stdcall;

    //車両情報テーブル行の型式指定番号および類別区分番号セット関数定義
    TxMAHNB01012B_SettingCarInfoRowFromCategoryNoAndDesignationNo = function(salesRowNo: Integer;
    modelDesignationNo: Integer;
    categoryNo: Integer)
    : Integer; stdcall;

    //車両情報テーブル行の型式セット関数定義
    TxMAHNB01012B_SettingCarInfoRowFromFullModel = function(salesRowNo: Integer;
    fullModel: WideString)
    : Integer; stdcall;

    //車両情報テーブル行のエンジン型式セット関数定義
    TxMAHNB01012B_SettingCarInfoRowFromEngineModelNm = function(salesRowNo: Integer;
    engineModelNm: WideString)
    : Integer; stdcall;

    //車両情報存在チェック関数定義
    TxMAHNB01012B_ExistCarInfo = function()
    : Integer; stdcall;

    // --- ADD 2014/05/19 T.Miyamoto 仕掛一覧№2218 ------------------------------>>>>>
    //車両情報テーブル行の車輌備考コードセット関数定義
    TxMAHNB01012B_SettingCarInfoRowFromCarNoteCode = function(salesRowNo: Integer; carNoteCode: Integer) : Integer; stdcall;
    // --- ADD 2014/05/19 T.Miyamoto 仕掛一覧№2218 ------------------------------<<<<<

    //車両情報テーブル行の車輌備考セット関数定義
    TxMAHNB01012B_SettingCarInfoRowFromCarNote = function(salesRowNo: Integer;
    carNote: WideString)
    : Integer; stdcall;

    //車両情報テーブル行の車輌走行距離セット関数定義
    TxMAHNB01012B_SettingCarInfoRowFromMileage = function(salesRowNo: Integer;
    mileage: Integer)
    : Integer; stdcall;

    //カーメーカーコードのフォーカス処理関数定義
    TxMAHNB01012B_AfterMakerCodeFocus = function(makerCode: Integer;
    salesRowNo: Integer;
    var makerName: WideString)
    : Integer; stdcall;

    //車種コードのフォーカス処理関数定義
    TxMAHNB01012B_AfterModelCodeFocus = function(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer;
    salesRowNo: Integer;
    var modelFullName: WideString)
    : Integer; stdcall;

    //車種呼称コードのフォーカス処理関数定義
    TxMAHNB01012B_AfterModelSubCodeFocus = function(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer;
    salesRowNo: Integer;
    var modelFullName: WideString)
    : Integer; stdcall;

    //車種名称のフォーカス処理関数定義
    TxMAHNB01012B_AfterModelFullNameFocus = function(makerCode: Integer;
    modelCode: Integer;
    modelSubCode: Integer;
    modelFullName: WideString;
    salesRowNo: Integer)
    : Integer; stdcall;

    //年式のフォーカス処理関数定義
    TxMAHNB01012B_AfterFirstEntryDateFocus = function(firstEntryDate: Integer;
    salesRowNo: Integer;
    var boolRet: Boolean)
    : Integer; stdcall;

    //車台番号のフォーカス処理関数定義
    TxMAHNB01012B_AfterProduceFrameNoFocus = function(produceFrameNo: WideString;
    salesRowNo: Integer;
    var boolRet: Boolean;
    mode : Integer)
    : Integer; stdcall;

    //追加情報タブ項目Visible設定関数定義
    TxMAHNB01012B_SettingAddInfoVisible = function(customerCode: Integer;
    carMngCode: WideString;
    salesRowNo: Integer;
    var boolRet: Boolean)
    : Integer; stdcall;

    //車種変更ボタンVisible関数定義
    TxMAHNB01012B_GetChangeCarInfoVisible = function(customerCode: Integer;
    carMngCode: WideString;
    var visibleFlag: Integer)
    : Integer; stdcall;

    //管理番号のフォーカス処理関数定義
    TxMAHNB01012B_AfterCarMngCodeFocus = function(carMngCode: WideString;
    customerCode: Integer;
    enterpriseCode: WideString;
    salesRowNo: Integer;
    var selectedInfo: TCarMangInputExtraInfo;
    var returnFlag: Boolean;
    var clearCarInfoFlag: Boolean)
    : Integer; stdcall;

    //拠点コードのフォーカス処理関数定義
    TxMAHNB01012B_AfterSectionCodeFocus = function(sectionCode: WideString;
    var salesSlip: TSalesSlip)
    : Integer; stdcall;

    //部門名称取得処理関数定義
    TxMAHNB01012B_GetNameFromSubSection = function(subSectionCode: Integer;
    var subSectionNm: WideString)
    : Integer; stdcall;

    //担当者変更処理関数定義
    TxMAHNB01012B_ChangeSalesEmployee = function(var salesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    code: WideString;
    var canChangeFocus: Boolean)
    : Integer; stdcall;

    //受注者変更処理関数定義
    TxMAHNB01012B_ChangeFrontEmployee = function(var salesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    code: WideString;
    var canChangeFocus: Boolean)
    : Integer; stdcall;

    //発行者変更処理関数定義
    TxMAHNB01012B_ChangeSalesInput = function(var salesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    code: WideString;
    var canChangeFocus: Boolean)
    : Integer; stdcall;

    //伝票区分変更処理関数定義
    TxMAHNB01012B_ChangeSalesSlip = function(var salesSlip: TSalesSlip;
    isCache: Boolean;
    code: Integer;
    var changeSalesSlipDisplay: Boolean;
    var clearDetailInput: Boolean;
    var clearCarInfo: Boolean)
    : Integer; stdcall;

    //商品区分変更処理関数定義
    TxMAHNB01012B_ChangeSalesGoodsCd = function(salesSlipCurrent: TSalesSlip;
    code: Integer;
    var changeSalesGoodsCd: Boolean;
    var clearDetailInput: Boolean;
    var clearCarInfo: Boolean)
    : Integer; stdcall;

    //得意先コードのフォーカス処理関数定義
    TxMAHNB01012B_AfterCustomerCodeFocus = function(var salesSlip: TSalesSlip;
    code: Integer;
    var customerInfo: TCustomerInfo;
    var clearAddCarInfo: Boolean;
    var canChangeFocus: Boolean;
    var reCalcSalesPrice: Boolean;
    var guideStart: Boolean;
    var clearDetailInput: Boolean;
    var clearCarInfo: Boolean;
    var reCalcSalesUnitPrice: Boolean;
    var clearRateInfo: Boolean)
    : Integer; stdcall;

    //伝票番号のフォーカス処理関数定義
    TxMAHNB01012B_AfterSalesSlipNumFocus = function(var salesSlip: TSalesSlip;
    var salesSlipCurrent: TSalesSlip;
    code: WideString;
    enterpriseCode: WideString;
    var equelFlag: Boolean;
    var readDBDatStatus: Integer;
    var reCalcSalesPrice: Boolean;
    var deleteEmptyRow: Boolean;
    var findDataFlg: Boolean)   // ADD 2010/07/01
    : Integer; stdcall;

    //受注ステータスリスト作成関数定義
    TxMAHNB01012B_SetStateList = function()
    : Integer; stdcall;

    //売上日のフォーカス処理関数定義
    TxMAHNB01012B_AfterSalesDateFocus = function(var salesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    salesDate: Int64;
    salesDateText: WideString;
    var reCalcSalesUnitPrice: Boolean;
    var reCalcSalesPrice: Boolean;
    var taxRate: Double;
    var reCanChangeFocus: Boolean)// ADD K2011/08/12
    : Integer; stdcall;

    //納入先コードのフォーカス処理関数定義
    TxMAHNB01012B_AfterAddresseeCodeFocue = function(var salesSlip: TSalesSlip;
    code: Integer;
    enterpriseCode: WideString;
    var reCalcSalesPrice: Boolean)
    : Integer; stdcall;

    //売上データオブジェクトをインスタンス変数にキャッシュします。関数定義
    TxMAHNB01012B_CacheForChange = function(salesSlip: TSalesSlip)
    : Integer; stdcall;

    //メモリ上の内容と比較関数定義
    TxMAHNB01012B_CompareSalesSlip = function(salesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    var compareRes: Boolean)
    : Integer; stdcall;

    //売上単価再計算関数定義
    TxMAHNB01012B_ReCalcSalesUnitPrice = function(var salesSlip: TSalesSlip)
    : Integer; stdcall;

    //掛率情報クリア処理（全て）関数定義
    TxMAHNB01012B_ClearAllRateInfo = function()
    : Integer; stdcall;

    //備考１コードのフォーカス処理関数定義
    TxMAHNB01012B_AfterSlipNoteCodeFocus = function(var salesSlip: TSalesSlip;
    value: Integer)
    : Integer; stdcall;

    //備考２コードのフォーカス処理関数定義
    TxMAHNB01012B_AfterSlipNote2CodeFocus = function(var salesSlip: TSalesSlip;
    value: Integer;
    var reCanChangeFocus: Boolean)// ADD K2011/08/12
    : Integer; stdcall;

    // ----- ADD K2011/08/12 --------------------------->>>>>
    //備考２のフォーカス処理関数定義
    TxMAHNB01012B_AfterSlipNote2Focus = function(salesSlip: TSalesSlip;
    slipNote2: WideString;
    var reCanChangeFocus: Boolean)
    : Integer; stdcall;
    // ----- ADD K2011/08/12 ---------------------------<<<<<

    //備考３コードのフォーカス処理関数定義
    TxMAHNB01012B_AfterSlipNote3CodeFocus = function(var salesSlip: TSalesSlip;
    value: Integer)
    : Integer; stdcall;

    //売上データ処理関数定義
    TxMAHNB01012B_GetSalesSlip = function(var salesSlip: TSalesSlip)
    : Integer; stdcall;

    //請求先確認ボタンクリック関数定義
    TxMAHNB01012B_CustomerClaimConfirmationClick = function(salesDate: Int64;
    var focus: WideString)
    : Integer; stdcall;

    //納入先確認ボタンクリック関数定義
    TxMAHNB01012B_AddresseeConfirmationClick = function(var salesSlip: TSalesSlip)
    : Integer; stdcall;

    //売上明細データの存在チェック関数定義
    TxMAHNB01012B_ExistSalesDetail = function(var exist: Boolean)
    : Integer; stdcall;

    //売上形式変更可能チェック処理関数定義
    TxMAHNB01012B_ChangeCheckAcptAnOdrStatus = function(code: Integer;
    salesSlip: TSalesSlip;
    var clearDisplayCarInfo: Boolean;
    var clearAddUpInfo: Boolean;
    var result: Boolean)
    : Integer; stdcall;

    //売上形式変更可能処理関数定義
    TxMAHNB01012B_ChangeAcptAnOdrStatus = function(code: Integer;
    var salesSlip: TSalesSlip;
    svCode: Integer)
    : Integer; stdcall;

    //売上データキャッシュ処理関数定義
    TxMAHNB01012B_Cache = function(salesSlip: TSalesSlip)
    : Integer; stdcall;

    //表示用伝票区分より、データ用の伝票区分、売掛区分をセットします関数定義
    TxMAHNB01012B_SetSlipCdAndAccRecDivCdFromDisplay = function(var salesSlip: TSalesSlip)
    : Integer; stdcall;

    //装備情報選択処理関数定義
    TxMAHNB01012B_SelectEquipInfo = function(carRelationGuid: WideString;
    equipmentGenreCd: WideString;
    equipmentName: WideString)
    : Integer; stdcall;

    //データ変更フラグの設定処理関数定義
    TxMAHNB01012B_SetGetIsDataChanged = function(flag: Integer;
    var isDataChanged: Boolean)
    : Integer; stdcall;

    //ヘッダフォーカス設定リストの取込処理関数定義
    TxMAHNB01012B_GetHeaderFocusConstructionListValue = function(var headerFocusConstructionList: TSalesSlipInputCustomArrayB5;
    var footerFocusConstructionList: TSalesSlipInputCustomArrayB6)
    : Integer; stdcall;

    //フォーカス設定リストの取込処理関数定義
    TxMAHNB01012B_GetFocusConstructionValue = function(var headerList: WideString;
    var footerList: WideString)
    : Integer; stdcall;

    //拠点名称の取込処理関数定義
    TxMAHNB01012B_GetSectionNm = function(section: WideString;
    var sectionName: WideString)
    : Integer; stdcall;
    
    // --- ADD 2010/07/16 ---------->>>>>
    //車両検索区分の取込処理関数定義
    TxMAHNB01012B_SetGetSearchCarDiv = function(flag: Integer;
    var searchCarDiv: Boolean)
    : Integer; stdcall;
    // --- ADD 2010/07/16 ----------<<<<<
    // add by Lizc end

    // add by Yangmj start

    //ツールチップ生成処理関数定義
    TxMAHNB01012B_CreateStockCountInfoString = function(salesRowNo: Integer;
    var StockCountInfo: WideString)
    : Integer; stdcall;

    // add by Yangmj end

    // add by Tanhong start

    // add by Tanhong end

    // --- ADD m.suzuki 2010/06/12 ---------->>>>>
    // メール用初期データ生成処理
    // public void MakeMailDefaultData(out string fileName)
    TxMAHNB01012B_MakeMailDefaultData = procedure( var fileName: WideString ) stdcall;
    // --- ADD m.suzuki 2010/06/12 ----------<<<<<

//2010/06/15 yamaji ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    //RC連携 **連携フォルダに対し、CSV出力を行います。
    TxMAHNB01012B_CopyToRC = function(salesRowNo: Integer) : Integer; stdcall;
//2010/06/15 yamaji ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

// ADD 2012/02/09 李占川 Redmine#28289 --- >>>>>
    //印刷中フラグの取込処理関数定義
    TxMAHNB01012B_GetPrintThreadOverFlag = function(var printThreadOverFlag: Boolean)
    : Integer; stdcall;
// ADD 2012/02/09 李占川 Redmine#28289 --- <<<<

    // --- ADD 2013/03/21 ---------->>>>>
    //ハンドル位置チェック処理関数定義
    TxMAHNB01012B_CheckHandlePosition = function(carRelationGuid: WideString;
    vinCode: WideString)
    : Boolean; stdcall;
    // --- ADD 2013/03/21 ----------<<<<<

// 呼び出しＰＧは以下の関数をＰＧの開始と終わりに呼びます。
function LoadLibraryMAHNB01012B(HDllCALL1: THDLLCALL): Integer;
procedure FreeLibraryMAHNB01012B(HDllCALL1: THDLLCALL);
//procedure ClearTSalesSlipSearchResult(var h_SalesSlipSearchResult: TSalesSlipSearchResult);
//procedure ClearTCustomerSearchRet(var h_CustomerSearchRet: TCustomerSearchRet);

    // add by Zhangkai start
procedure ClearTSalesDetail(var h_SalesDetail: TSalesDetail);
    // add by Zhangkai end

    // add by Lizc start
procedure ClearTColorInfo(var h_ColorInfo: TColorInfo);
procedure ClearTTrimInfo(var h_TrimInfo: TTrimInfo);
procedure ClearTCEqpDefDspInfo(var h_CEqpDefDspInfo: TCEqpDefDspInfo);
procedure ClearTCarSpecInfo(var h_CarSpecInfo: TCarSpecInfo);
procedure ClearTCarInfo(var h_CarInfo: TCarInfo);
procedure ClearTCarModel(var h_CarModel: TCarModel);
procedure ClearTEngineModel(var h_EngineModel: TEngineModel);
procedure ClearTCarSearchCondition(var h_CarSearchCondition: TCarSearchCondition);
// add by gaofeng start
procedure ClearTSalesSlip(var h_SalesSlip: TSalesSlip);
procedure ClearTCarMangInputExtraInfo(var h_CarMangInputExtraInfo: TCarMangInputExtraInfo);
procedure ClearTModelNameU(var h_ModelNameU: TModelNameU);
procedure ClearTUserGdHd(var h_UserGdHd: TUserGdHd);
procedure ClearTUserGdBd(var h_UserGdBd: TUserGdBd);
// add by gaofeng end
procedure ClearBeforeCarSearchBuffer(var h_BeforeCarSearchBuffer: BeforeCarSearchBuffer);
procedure ClearTCustomerInfo(var h_CustomerInfo: TCustomerInfo);
procedure ClearTHeaderFocusConstruction(var h_HeaderFocusConstruction: THeaderFocusConstruction);
procedure ClearTFooterFocusConstruction(var h_FooterFocusConstruction: TFooterFocusConstruction);
    // add by Lizc end

    // add by Yangmj start

    // add by Yangmj end

    // add by Tanhong start

    // add by Tanhong end

var
    //関数ポインタ宣言

    // add by gaofeng start
    //関数ポインタ宣言
    gpxMAHNB01012B_sectionGuide : TxMAHNB01012B_sectionGuide;
    gpxMAHNB01012B_subSectionGuide : TxMAHNB01012B_subSectionGuide;
    gpxMAHNB01012B_employeeGuide : TxMAHNB01012B_employeeGuide;
    gpxMAHNB01012B_carMngNoGuide : TxMAHNB01012B_carMngNoGuide;
    gpxMAHNB01012B_modelFullGuide : TxMAHNB01012B_modelFullGuide;
    gpxMAHNB01012B_slipNote : TxMAHNB01012B_slipNote;
    gpxMAHNB01012B_GetRate : TxMAHNB01012B_GetRate;
    // --- ADD 2010/05/31 ---------->>>>>
    gpxMAHNB01012B_CalculationSalesPrice : TxMAHNB01012B_CalculationSalesPrice;
    // --- ADD 2010/05/31 ----------<<<<<
    // add by gaofeng end

    // add by Zhangkai start
    // add by Zhangkai end

    // add by Lizc start
    gpxMAHNB01012B_CarSearch : TxMAHNB01012B_CarSearch;
    gpxMAHNB01012B_GetCarInfoRow : TxMAHNB01012B_GetCarInfoRow;
    gpxMAHNB01012B_GetColorInfo : TxMAHNB01012B_GetColorInfo;
    gpxMAHNB01012B_GetSelectColorInfo : TxMAHNB01012B_GetSelectColorInfo;
    gpxMAHNB01012B_GetTrimInfo : TxMAHNB01012B_GetTrimInfo;
    gpxMAHNB01012B_GetSelectTrimInfo : TxMAHNB01012B_GetSelectTrimInfo;
    gpxMAHNB01012B_GetEquipInfo : TxMAHNB01012B_GetEquipInfo;
    gpxMAHNB01012B_SelectColorInfo : TxMAHNB01012B_SelectColorInfo;
    gpxMAHNB01012B_SelectTrimInfo : TxMAHNB01012B_SelectTrimInfo;
    gpxMAHNB01012B_CheckProduceTypeOfYearRange : TxMAHNB01012B_CheckProduceTypeOfYearRange;
    gpxMAHNB01012B_SettingCarModelUIDataFromFirstEntryDate : TxMAHNB01012B_SettingCarModelUIDataFromFirstEntryDate;
    gpxMAHNB01012B_CheckProduceFrameNo : TxMAHNB01012B_CheckProduceFrameNo;
    gpxMAHNB01012B_SettingCarModelUIDataFromProduceFrameNo : TxMAHNB01012B_SettingCarModelUIDataFromProduceFrameNo;
    gpxMAHNB01012B_GetProduceTypeOfYear : TxMAHNB01012B_GetProduceTypeOfYear;
    gpxMAHNB01012B_ClearCarInfoRow : TxMAHNB01012B_ClearCarInfoRow;
    gpxMAHNB01012B_SettingCarInfoRowFromFirstEntryDate : TxMAHNB01012B_SettingCarInfoRowFromFirstEntryDate;
    gpxMAHNB01012B_SettingCarInfoRowFromFrameNo : TxMAHNB01012B_SettingCarInfoRowFromFrameNo;
    gpxMAHNB01012B_SettingCarInfoRowFromModelInfo : TxMAHNB01012B_SettingCarInfoRowFromModelInfo;
    gpxMAHNB01012B_GetModelFullName : TxMAHNB01012B_GetModelFullName;
    gpxMAHNB01012B_GetModelHalfName : TxMAHNB01012B_GetModelHalfName;
    gpxMAHNB01012B_SettingCarInfoRowFromCarMngCode : TxMAHNB01012B_SettingCarInfoRowFromCarMngCode;
    gpxMAHNB01012B_SettingCarInfoRowFromCategoryNoAndDesignationNo : TxMAHNB01012B_SettingCarInfoRowFromCategoryNoAndDesignationNo;
    gpxMAHNB01012B_SettingCarInfoRowFromFullModel : TxMAHNB01012B_SettingCarInfoRowFromFullModel;
    gpxMAHNB01012B_SettingCarInfoRowFromEngineModelNm : TxMAHNB01012B_SettingCarInfoRowFromEngineModelNm;
    gpxMAHNB01012B_ExistCarInfo : TxMAHNB01012B_ExistCarInfo;
    gpxMAHNB01012B_SettingCarInfoRowFromCarNoteCode : TxMAHNB01012B_SettingCarInfoRowFromCarNoteCode; // ADD 2014/05/19 T.Miyamoto 仕掛一覧№2218
    gpxMAHNB01012B_SettingCarInfoRowFromCarNote : TxMAHNB01012B_SettingCarInfoRowFromCarNote;
    gpxMAHNB01012B_SettingCarInfoRowFromMileage : TxMAHNB01012B_SettingCarInfoRowFromMileage;
    gpxMAHNB01012B_AfterMakerCodeFocus : TxMAHNB01012B_AfterMakerCodeFocus;
    gpxMAHNB01012B_AfterModelCodeFocus : TxMAHNB01012B_AfterModelCodeFocus;
    gpxMAHNB01012B_AfterModelSubCodeFocus : TxMAHNB01012B_AfterModelSubCodeFocus;
    gpxMAHNB01012B_AfterModelFullNameFocus : TxMAHNB01012B_AfterModelFullNameFocus;
    gpxMAHNB01012B_AfterFirstEntryDateFocus : TxMAHNB01012B_AfterFirstEntryDateFocus;
    gpxMAHNB01012B_AfterProduceFrameNoFocus : TxMAHNB01012B_AfterProduceFrameNoFocus;
    gpxMAHNB01012B_SettingAddInfoVisible : TxMAHNB01012B_SettingAddInfoVisible;
    gpxMAHNB01012B_GetChangeCarInfoVisible : TxMAHNB01012B_GetChangeCarInfoVisible;
    gpxMAHNB01012B_AfterCarMngCodeFocus : TxMAHNB01012B_AfterCarMngCodeFocus;
    gpxMAHNB01012B_AfterSectionCodeFocus : TxMAHNB01012B_AfterSectionCodeFocus;
    gpxMAHNB01012B_GetNameFromSubSection : TxMAHNB01012B_GetNameFromSubSection;
    gpxMAHNB01012B_ChangeSalesEmployee : TxMAHNB01012B_ChangeSalesEmployee;
    gpxMAHNB01012B_ChangeFrontEmployee : TxMAHNB01012B_ChangeFrontEmployee;
    gpxMAHNB01012B_ChangeSalesInput : TxMAHNB01012B_ChangeSalesInput;
    gpxMAHNB01012B_ChangeSalesSlip : TxMAHNB01012B_ChangeSalesSlip;
    gpxMAHNB01012B_ChangeSalesGoodsCd : TxMAHNB01012B_ChangeSalesGoodsCd;
    gpxMAHNB01012B_AfterCustomerCodeFocus : TxMAHNB01012B_AfterCustomerCodeFocus;
    gpxMAHNB01012B_AfterSalesSlipNumFocus : TxMAHNB01012B_AfterSalesSlipNumFocus;
    gpxMAHNB01012B_SetStateList : TxMAHNB01012B_SetStateList;
    gpxMAHNB01012B_AfterSalesDateFocus : TxMAHNB01012B_AfterSalesDateFocus;
    gpxMAHNB01012B_AfterAddresseeCodeFocue : TxMAHNB01012B_AfterAddresseeCodeFocue;
    gpxMAHNB01012B_CacheForChange : TxMAHNB01012B_CacheForChange;
    gpxMAHNB01012B_CompareSalesSlip : TxMAHNB01012B_CompareSalesSlip;
    gpxMAHNB01012B_ReCalcSalesUnitPrice : TxMAHNB01012B_ReCalcSalesUnitPrice;
    gpxMAHNB01012B_ClearAllRateInfo : TxMAHNB01012B_ClearAllRateInfo;
    gpxMAHNB01012B_AfterSlipNoteCodeFocus : TxMAHNB01012B_AfterSlipNoteCodeFocus;
    gpxMAHNB01012B_AfterSlipNote2CodeFocus : TxMAHNB01012B_AfterSlipNote2CodeFocus;
    gpxMAHNB01012B_AfterSlipNote3CodeFocus : TxMAHNB01012B_AfterSlipNote3CodeFocus;
    gpxMAHNB01012B_GetSalesSlip : TxMAHNB01012B_GetSalesSlip;
    gpxMAHNB01012B_CustomerClaimConfirmationClick : TxMAHNB01012B_CustomerClaimConfirmationClick;
    gpxMAHNB01012B_AddresseeConfirmationClick : TxMAHNB01012B_AddresseeConfirmationClick;
    gpxMAHNB01012B_ExistSalesDetail : TxMAHNB01012B_ExistSalesDetail;
    gpxMAHNB01012B_ChangeCheckAcptAnOdrStatus : TxMAHNB01012B_ChangeCheckAcptAnOdrStatus;
    gpxMAHNB01012B_ChangeAcptAnOdrStatus : TxMAHNB01012B_ChangeAcptAnOdrStatus;
    gpxMAHNB01012B_Cache : TxMAHNB01012B_Cache;
    gpxMAHNB01012B_SetSlipCdAndAccRecDivCdFromDisplay : TxMAHNB01012B_SetSlipCdAndAccRecDivCdFromDisplay;
    gpxMAHNB01012B_SelectEquipInfo : TxMAHNB01012B_SelectEquipInfo;
    gpxMAHNB01012B_SetGetIsDataChanged : TxMAHNB01012B_SetGetIsDataChanged;
    gpxMAHNB01012B_GetHeaderFocusConstructionListValue : TxMAHNB01012B_GetHeaderFocusConstructionListValue;
    gpxMAHNB01012B_GetFocusConstructionValue : TxMAHNB01012B_GetFocusConstructionValue;
    gpxMAHNB01012B_GetSectionNm : TxMAHNB01012B_GetSectionNm;
    gpxMAHNB01012B_SetGetSearchCarDiv : TxMAHNB01012B_SetGetSearchCarDiv; // ADD 2010/07/16
    gpxMAHNB01012B_AfterSlipNote2Focus : TxMAHNB01012B_AfterSlipNote2Focus; // ADD K2011/08/12
    // add by Lizc end

    // add by Yangmj start

    //関数ポインタ宣言
    gpxMAHNB01012B_CreateStockCountInfoString : TxMAHNB01012B_CreateStockCountInfoString;

    // add by Yangmj end

    // add by Tanhong start
    //関数ポインタ宣言
    gpxMAHNB01012B_GetSettingOptionInfo : TxMAHNB01012B_GetSettingOptionInfo;

    // add by Tanhong end
    gpxMAHNB01012B_CopyToRC        : TxMAHNB01012B_CopyToRC        ;            //2010/06/15 yamaji ADD

    // --- ADD m.suzuki 2010/06/12 ---------->>>>>
    //関数ポインタ宣言
    gpxMAHNB01012B_MakeMailDefaultData : TxMAHNB01012B_MakeMailDefaultData;
    // --- ADD m.suzuki 2010/06/12 ----------<<<<<

    gpxMAHNB01012B_GetPrintThreadOverFlag : TxMAHNB01012B_GetPrintThreadOverFlag; //ADD 2012/02/09 李占川 Redmine#28289

    // --- ADD 2013/03/21 ---------->>>>>
    gpxMAHNB01012B_CheckHandlePosition : TxMAHNB01012B_CheckHandlePosition;
    // --- ADD 2013/03/21 ----------<<<<<

implementation

// **********************************************************************//
// Module Name     :  車種部品ロード関数                            //
// :  LoadLibraryMAHNB01012B                            //
// 引数            :  １．HDLLCALL                                      //
// 戻り値          :  ステータス ctFNC_NORMAL : 成功                    //
// :             ctFNC_ERROR  : 失敗                    //
// Programer       :  自動生成                                            //
// Date            :  2010.03.16                                          //
// Note            :  車種部品ロードします                          //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
// **********************************************************************//
function LoadLibraryMAHNB01012B(HDllCALL1: THDLLCALL): Integer;
var
    nSt: Integer;
begin
    Result := 4;
    HDllCALL1.DllName := 'MAHNB01012B.DLL';
    nSt := HDllCALL1.HLoadLibrary;

    //DLLロード
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車種部品',
            'LoadLibraryMAHNB01012B', 'LOADLIBRARY', '車種部品のロードに失敗しました', nSt,
            nil, 0);
        Exit;
    end;

    // add by gaofeng start
    //拠点ガイド処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_sectionGuide';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_sectionGuide);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '拠点ガイド操作',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '拠点ガイド処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //オプション情報処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_GetSettingOptionInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetSettingOptionInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車種部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車種部品オプション情報処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;


    //部門ガイド処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_subSectionGuide';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_subSectionGuide);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '部門ガイド操作',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '部門ガイド操作処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //従業員ガイド処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_employeeGuide';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_employeeGuide);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '従業員ガイド操作',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '従業員ガイド操作処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //管理番号ガイド処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_carMngNoGuide';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_carMngNoGuide);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '管理番号ガイド操作',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '管理番号ガイド操作処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //車種ガイド処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_modelFullGuide';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_modelFullGuide);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車種ガイド操作',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車種ガイド操作処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //備考ガイドボタン処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_slipNote';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_slipNote);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '備考ガイド操作',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '備考ガイド操作処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //率算定処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_GetRate';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetRate);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '率算定処理',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '率算定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // --- ADD 2010/05/31 ---------->>>>>
    //CalculationSalesPrice関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_CalculationSalesPrice';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_CalculationSalesPrice);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '売上金額計算処理',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '売上金額計算処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2010/05/31 ----------<<<<<

    // add by gaofeng end

    // add by Zhangkai start


    // add by Zhangkai end

    // add by Lizc start
    //車両検索処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_CarSearch';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_CarSearch);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品車両検索処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //車両情報行オブジェクト取得関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_GetCarInfoRow';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetCarInfoRow);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品車両情報行オブジェクト取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //カラー情報取得処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_GetColorInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetColorInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品カラー情報取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //選択カラー情報取得処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_GetSelectColorInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetSelectColorInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品選択カラー情報取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //トリム情報取得処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_GetTrimInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetTrimInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品トリム情報取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //選択トリム情報取得処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_GetSelectTrimInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetSelectTrimInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品選択トリム情報取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //装備情報取得処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_GetEquipInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetEquipInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品装備情報取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //カラー情報選択処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_SelectColorInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SelectColorInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品カラー情報選択処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //トリム情報選択処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_SelectTrimInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SelectTrimInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品トリム情報選択処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //生産年式範囲チェック関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_CheckProduceTypeOfYearRange';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_CheckProduceTypeOfYearRange);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品生産年式範囲チェック関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //車両検索データテーブル年式設定処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_SettingCarModelUIDataFromFirstEntryDate';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SettingCarModelUIDataFromFirstEntryDate);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品車両検索データテーブル年式設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //車台番号範囲チェック関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_CheckProduceFrameNo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_CheckProduceFrameNo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品車台番号範囲チェック関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //車両検索データテーブル車台番号設定処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_SettingCarModelUIDataFromProduceFrameNo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SettingCarModelUIDataFromProduceFrameNo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品車両検索データテーブル車台番号設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //対象年式取得処理(車台番号より取得)関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_GetProduceTypeOfYear';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetProduceTypeOfYear);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品対象年式取得処理(車台番号より取得)関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //車両情報テーブルのクリア関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_ClearCarInfoRow';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_ClearCarInfoRow);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品車両情報テーブルのクリア関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //車両情報テーブル行の年式セット関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_SettingCarInfoRowFromFirstEntryDate';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SettingCarInfoRowFromFirstEntryDate);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品車両情報テーブル行の年式セット関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //車両情報テーブル行の車台番号セット関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_SettingCarInfoRowFromFrameNo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SettingCarInfoRowFromFrameNo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品車両情報テーブル行の車台番号セット関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //車両情報テーブル行の車種情報セット関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_SettingCarInfoRowFromModelInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SettingCarInfoRowFromModelInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品車両情報テーブル行の車種情報セット関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //車種名称取得処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_GetModelFullName';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetModelFullName);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品車種名称取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //車種半角名称取得処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_GetModelHalfName';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetModelHalfName);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品車種半角名称取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //車両情報テーブル行の管理番号セット関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_SettingCarInfoRowFromCarMngCode';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SettingCarInfoRowFromCarMngCode);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品車両情報テーブル行の管理番号セット関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //車両情報テーブル行の型式指定番号および類別区分番号セット関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_SettingCarInfoRowFromCategoryNoAndDesignationNo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SettingCarInfoRowFromCategoryNoAndDesignationNo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品車両情報テーブル行の型式指定番号および類別区分番号セット関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //車両情報テーブル行の型式セット関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_SettingCarInfoRowFromFullModel';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SettingCarInfoRowFromFullModel);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品車両情報テーブル行の型式セット関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //車両情報テーブル行のエンジン型式セット関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_SettingCarInfoRowFromEngineModelNm';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SettingCarInfoRowFromEngineModelNm);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品車両情報テーブル行のエンジン型式セット関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //車両情報存在チェック関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_ExistCarInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_ExistCarInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品車両情報存在チェック関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // --- ADD 2014/05/19 T.Miyamoto 仕掛一覧№2218 ------------------------------>>>>>
    //車両情報テーブル行の車輌備考コードセット関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_SettingCarInfoRowFromCarNoteCode';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SettingCarInfoRowFromCarNoteCode);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品車両情報テーブル行の車輌備考コードセット関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2014/05/19 T.Miyamoto 仕掛一覧№2218 ------------------------------<<<<<

    //車両情報テーブル行の車輌備考セット関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_SettingCarInfoRowFromCarNote';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SettingCarInfoRowFromCarNote);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品車両情報テーブル行の車輌備考セット関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //車両情報テーブル行の車輌走行距離セット関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_SettingCarInfoRowFromMileage';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SettingCarInfoRowFromMileage);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品車両情報テーブル行の車輌走行距離セット関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //カーメーカーコードのフォーカス処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_AfterMakerCodeFocus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AfterMakerCodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品カーメーカーコードのフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //車種コードのフォーカス処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_AfterModelCodeFocus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AfterModelCodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品車種コードのフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //車種呼称コードのフォーカス処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_AfterModelSubCodeFocus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AfterModelSubCodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品車種呼称コードのフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //車種名称のフォーカス処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_AfterModelFullNameFocus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AfterModelFullNameFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品車種名称のフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //年式のフォーカス処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_AfterFirstEntryDateFocus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AfterFirstEntryDateFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品年式のフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //車台番号のフォーカス処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_AfterProduceFrameNoFocus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AfterProduceFrameNoFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品車台番号のフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //追加情報タブ項目Visible設定関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_SettingAddInfoVisible';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SettingAddInfoVisible);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品追加情報タブ項目Visible設定関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //車種変更ボタンVisible関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_GetChangeCarInfoVisible';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetChangeCarInfoVisible);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品車種変更ボタンVisible関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //管理番号のフォーカス処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_AfterCarMngCodeFocus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AfterCarMngCodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品管理番号のフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //拠点コードのフォーカス処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_AfterSectionCodeFocus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AfterSectionCodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品拠点コードのフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //部門名称取得処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_GetNameFromSubSection';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetNameFromSubSection);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品部門名称取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //担当者変更処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_ChangeSalesEmployee';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_ChangeSalesEmployee);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品担当者変更処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //受注者変更処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_ChangeFrontEmployee';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_ChangeFrontEmployee);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品受注者変更処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //発行者変更処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_ChangeSalesInput';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_ChangeSalesInput);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品発行者変更処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //伝票区分変更処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_ChangeSalesSlip';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_ChangeSalesSlip);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品伝票区分変更処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //商品区分変更処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_ChangeSalesGoodsCd';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_ChangeSalesGoodsCd);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品商品区分変更処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //得意先コードのフォーカス処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_AfterCustomerCodeFocus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AfterCustomerCodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品得意先コードのフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //伝票番号のフォーカス処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_AfterSalesSlipNumFocus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AfterSalesSlipNumFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品伝票番号のフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //受注ステータスリスト作成関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_SetStateList';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SetStateList);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品受注ステータスリスト作成関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //売上日のフォーカス処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_AfterSalesDateFocus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AfterSalesDateFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品売上日のフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //納入先コードのフォーカス処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_AfterAddresseeCodeFocue';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AfterAddresseeCodeFocue);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品納入先コードのフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //売上データオブジェクトをインスタンス変数にキャッシュします。関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_CacheForChange';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_CacheForChange);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品売上データオブジェクトをインスタンス変数にキャッシュします。関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //メモリ上の内容と比較関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_CompareSalesSlip';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_CompareSalesSlip);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品メモリ上の内容と比較関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //売上単価再計算関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_ReCalcSalesUnitPrice';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_ReCalcSalesUnitPrice);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品売上単価再計算関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //掛率情報クリア処理（全て）関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_ClearAllRateInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_ClearAllRateInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品掛率情報クリア処理（全て）関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //備考１コードのフォーカス処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_AfterSlipNoteCodeFocus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AfterSlipNoteCodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品備考１コードのフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //備考２コードのフォーカス処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_AfterSlipNote2CodeFocus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AfterSlipNote2CodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品備考２コードのフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // ----- ADD K2011/08/12 --------------------------->>>>>
    //備考２のフォーカス処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_AfterSlipNote2Focus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AfterSlipNote2Focus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品備考２のフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // ----- ADD K2011/08/12 ---------------------------<<<<<

    //備考３コードのフォーカス処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_AfterSlipNote3CodeFocus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AfterSlipNote3CodeFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品備考３コードのフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //売上データ処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_GetSalesSlip';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetSalesSlip);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品売上データ処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //請求先確認ボタンクリック関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_CustomerClaimConfirmationClick';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_CustomerClaimConfirmationClick);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品請求先確認ボタンクリック関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //納入先確認ボタンクリック関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_AddresseeConfirmationClick';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_AddresseeConfirmationClick);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品納入先確認ボタンクリック関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //売上明細データの存在チェック関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_ExistSalesDetail';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_ExistSalesDetail);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品売上明細データの存在チェック関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //売上形式変更可能チェック処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_ChangeCheckAcptAnOdrStatus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_ChangeCheckAcptAnOdrStatus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品売上形式変更可能チェック処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //売上形式変更可能処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_ChangeAcptAnOdrStatus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_ChangeAcptAnOdrStatus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品売上形式変更可能処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //売上データキャッシュ処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_Cache';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_Cache);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品売上データキャッシュ処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //表示用伝票区分より、データ用の伝票区分、売掛区分をセットします関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_SetSlipCdAndAccRecDivCdFromDisplay';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SetSlipCdAndAccRecDivCdFromDisplay);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '、データ用の伝票区分、売掛区分をセットします関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //装備情報選択処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_SelectEquipInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SelectEquipInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品装備情報選択処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //データ変更フラグの設定処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_SetGetIsDataChanged';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SetGetIsDataChanged);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品データ変更フラグの設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //ヘッダフォーカス設定リストの取込処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_GetHeaderFocusConstructionListValue';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetHeaderFocusConstructionListValue);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品ヘッダフォーカス設定リストの取込処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //フォーカス設定リストの取込処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_GetFocusConstructionValue';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetFocusConstructionValue);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品フォーカス設定リストの取込処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //拠点名称の取込処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_GetSectionNm';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetSectionNm);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品拠点名称の取込処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    
    // --- ADD 2010/07/16 ---------->>>>>
    //車両検索区分の取込処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_SetGetSearchCarDiv';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_SetGetSearchCarDiv);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '車両検索部品車両検索区分の取込処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2010/07/16 ----------<<<<<
    // add by Lizc end

    // add by Yangmj start

    //ツールチップ生成処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_CreateStockCountInfoString';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_CreateStockCountInfoString);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '出荷照会部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '出荷照会部品ツールチップ生成処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // add by Yangmj end

    // add by Tanhong start

    // add by Tanhong end

    // --- ADD m.suzuki 2010/06/12 ---------->>>>>
    // メール用初期データ生成処理
    HDllCALL1.ProcName := 'MAHNB01012B_MakeMailDefaultData';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_MakeMailDefaultData);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', 'メール用初期データ生成処理',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            'メール用初期データ生成処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD m.suzuki 2010/06/12 ----------<<<<<

//2010/06/15 yamaji ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    //RC連携 - CSV出力
    HDllCALL1.ProcName := 'MAHNB01012B_CopyToRC';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_CopyToRC);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', 'RC連携部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            'ＲＣ連携処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

//2010/06/15 yamaji ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

//ADD 2012/02/09 李占川 Redmine#28289 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    //印刷中フラグの取込処理
    HDllCALL1.ProcName := 'MAHNB01012B_GetPrintThreadOverFlag';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_GetPrintThreadOverFlag);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '印刷中フラグの取込処理',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            '印刷中フラグの取込処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

//ADD 2012/02/09 李占川 Redmine#28289 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

    // --- ADD 2013/03/21 ---------->>>>>
    //ハンドル位置チェック処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01012B_CheckHandlePosition';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01012B_CheckHandlePosition);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01012C', '車両検索部品',
            'LoadLibraryMAHNB01012B', 'GETPROCADDRESS',
            'ハンドル位置チェック処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2013/03/21 ----------<<<<<

    Result := 0;

end;

// **********************************************************************//
// Module Name     :  車種部品フリー関数                        //
// :  FreeLibraryMAHNB01012B                            //
// 引数            :  １．HDLLCALL                                      //
// 戻り値          :  無し                                              //
// Programer       :  自動生成                                            //
// Date            :  2010.03.16                                          //
// Note            :  車種部品フリーします                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
// **********************************************************************//
procedure FreeLibraryMAHNB01012B(HDllCALL1: THDLLCALL);
begin
    HDllCALL1.DllName := 'MAHNB01012B.DLL';
    HDllCALL1.HFreeLibrary;
    // add by gaofeng start
    gpxMAHNB01012B_sectionGuide := nil;
    gpxMAHNB01012B_subSectionGuide := nil;
    gpxMAHNB01012B_employeeGuide := nil;
    gpxMAHNB01012B_carMngNoGuide := nil;
    gpxMAHNB01012B_modelFullGuide := nil;
    gpxMAHNB01012B_slipNote := nil;
    gpxMAHNB01012B_GetRate := nil;
    // --- ADD 2010/05/31 ---------->>>>>
    gpxMAHNB01012B_CalculationSalesPrice := nil;
    // --- ADD 2010/05/31 ----------<<<<<
    // add by gaofeng end

    // add by Zhangkai start
    // add by Zhangkai end

    // add by Lizc start
    gpxMAHNB01012B_CarSearch := nil;
    gpxMAHNB01012B_GetCarInfoRow := nil;
    gpxMAHNB01012B_GetColorInfo := nil;
    gpxMAHNB01012B_GetSelectColorInfo := nil;
    gpxMAHNB01012B_GetTrimInfo := nil;
    gpxMAHNB01012B_GetSelectTrimInfo := nil;
    gpxMAHNB01012B_GetEquipInfo := nil;
    gpxMAHNB01012B_SelectColorInfo := nil;
    gpxMAHNB01012B_SelectTrimInfo := nil;
    gpxMAHNB01012B_CheckProduceTypeOfYearRange := nil;
    gpxMAHNB01012B_SettingCarModelUIDataFromFirstEntryDate := nil;
    gpxMAHNB01012B_CheckProduceFrameNo := nil;
    gpxMAHNB01012B_SettingCarModelUIDataFromProduceFrameNo := nil;
    gpxMAHNB01012B_GetProduceTypeOfYear := nil;
    gpxMAHNB01012B_ClearCarInfoRow := nil;
    gpxMAHNB01012B_SettingCarInfoRowFromFirstEntryDate := nil;
    gpxMAHNB01012B_SettingCarInfoRowFromFrameNo := nil;
    gpxMAHNB01012B_SettingCarInfoRowFromModelInfo := nil;
    gpxMAHNB01012B_GetModelFullName := nil;
    gpxMAHNB01012B_GetModelHalfName := nil;
    gpxMAHNB01012B_SettingCarInfoRowFromCarMngCode := nil;
    gpxMAHNB01012B_SettingCarInfoRowFromCategoryNoAndDesignationNo := nil;
    gpxMAHNB01012B_SettingCarInfoRowFromFullModel := nil;
    gpxMAHNB01012B_SettingCarInfoRowFromEngineModelNm := nil;
    gpxMAHNB01012B_ExistCarInfo := nil;
    gpxMAHNB01012B_SettingCarInfoRowFromCarNoteCode := nil; // ADD 2014/05/19 T.Miyamoto 仕掛一覧№2218
    gpxMAHNB01012B_SettingCarInfoRowFromCarNote := nil;
    gpxMAHNB01012B_SettingCarInfoRowFromMileage := nil;
    gpxMAHNB01012B_AfterMakerCodeFocus := nil;
    gpxMAHNB01012B_AfterModelCodeFocus := nil;
    gpxMAHNB01012B_AfterModelSubCodeFocus := nil;
    gpxMAHNB01012B_AfterModelFullNameFocus := nil;
    gpxMAHNB01012B_AfterFirstEntryDateFocus := nil;
    gpxMAHNB01012B_AfterProduceFrameNoFocus := nil;
    gpxMAHNB01012B_SettingAddInfoVisible := nil;
    gpxMAHNB01012B_GetChangeCarInfoVisible := nil;
    gpxMAHNB01012B_AfterCarMngCodeFocus := nil;
    gpxMAHNB01012B_AfterSectionCodeFocus := nil;
    gpxMAHNB01012B_GetNameFromSubSection := nil;
    gpxMAHNB01012B_ChangeSalesEmployee := nil;
    gpxMAHNB01012B_ChangeFrontEmployee := nil;
    gpxMAHNB01012B_ChangeSalesInput := nil;
    gpxMAHNB01012B_ChangeSalesSlip := nil;
    gpxMAHNB01012B_ChangeSalesGoodsCd := nil;
    gpxMAHNB01012B_AfterCustomerCodeFocus := nil;
    gpxMAHNB01012B_AfterSalesSlipNumFocus := nil;
    gpxMAHNB01012B_SetStateList := nil;
    gpxMAHNB01012B_AfterSalesDateFocus := nil;
    gpxMAHNB01012B_AfterAddresseeCodeFocue := nil;
    gpxMAHNB01012B_CompareSalesSlip := nil;
    gpxMAHNB01012B_ReCalcSalesUnitPrice := nil;
    gpxMAHNB01012B_ClearAllRateInfo := nil;
    gpxMAHNB01012B_AfterSlipNoteCodeFocus := nil;
    gpxMAHNB01012B_AfterSlipNote2CodeFocus := nil;
    gpxMAHNB01012B_AfterSlipNote3CodeFocus := nil;
    gpxMAHNB01012B_GetSalesSlip := nil;
    gpxMAHNB01012B_CustomerClaimConfirmationClick := nil;
    gpxMAHNB01012B_AddresseeConfirmationClick := nil;
    gpxMAHNB01012B_ExistSalesDetail := nil;
    gpxMAHNB01012B_ChangeCheckAcptAnOdrStatus := nil;
    gpxMAHNB01012B_ChangeAcptAnOdrStatus := nil;
    gpxMAHNB01012B_Cache := nil;
    gpxMAHNB01012B_SetSlipCdAndAccRecDivCdFromDisplay := nil;
    gpxMAHNB01012B_SelectEquipInfo := nil;
    gpxMAHNB01012B_SetGetIsDataChanged := nil;
    gpxMAHNB01012B_GetHeaderFocusConstructionListValue := nil;
    gpxMAHNB01012B_GetFocusConstructionValue := nil;
    gpxMAHNB01012B_GetSectionNm := nil;
    gpxMAHNB01012B_SetGetSearchCarDiv := nil; // ADD 2010/07/16
    gpxMAHNB01012B_AfterSlipNote2Focus := nil; // ADD K2011/08/12
    // add by Lizc end

    // add by Yangmj start
    gpxMAHNB01012B_CreateStockCountInfoString := nil;
    // add by Yangmj end

    // add by Tanhong start
    gpxMAHNB01012B_GetSettingOptionInfo := nil;

    // add by Tanhong end

    // --- ADD m.suzuki 2010/06/12 ---------->>>>>
    gpxMAHNB01012B_MakeMailDefaultData := nil;
    // --- ADD m.suzuki 2010/06/12 ----------<<<<<

    // --- ADD 2012/02/09 李占川 Redmine#28289 ---------->>>>>
    gpxMAHNB01012B_GetPrintThreadOverFlag := nil;
    // --- ADD 2012/02/09 李占川 Redmine#28289 ----------<<<<<

    // --- ADD 2013/03/21 ---------->>>>>
    gpxMAHNB01012B_CheckHandlePosition := nil;
    // --- ADD 2013/03/21 ----------<<<<<
end;

// add by gaofeng start
// **********************************************************************//
// Module Name     :  拠点ガイド操作部品フリー関数                        //
// :  ClearTSalesSlip                            //
// 引数            :  １．売上データ                                      //
// 戻り値          :  無し                                              //
// Programer       :  自動生成                                            //
// Date            :  2010.04.01                                          //
// Note            :  拠点ガイド操作部品フリーします                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
// **********************************************************************//
procedure ClearTSalesSlip(var h_SalesSlip: TSalesSlip);
var
  i: Integer;
  guidcleararray: array [0 .. 15] of AnsiChar;
begin
  h_SalesSlip.AcptAnOdrStatus := 0;
  h_SalesSlip.SalesSlipNum := '';
  h_SalesSlip.SectionCode := '';
  h_SalesSlip.InputMode := 0;
  h_SalesSlip.SalesSlipDisplay := 0;
  h_SalesSlip.AcptAnOdrStatusDisplay := 0;
  h_SalesSlip.CarMngDivCd := 0;
  h_SalesSlip.SubSectionCode := 0;
  h_SalesSlip.SubSectionName := '';
  h_SalesSlip.DebitNoteDiv := 0;
  h_SalesSlip.DebitNLnkSalesSlNum := '';
  h_SalesSlip.SalesSlipCd := 0;
  h_SalesSlip.SalesGoodsCd := 0;
  h_SalesSlip.AccRecDivCd := 0;
  h_SalesSlip.SalesInpSecCd := '';
  h_SalesSlip.DemandAddUpSecCd := '';
  h_SalesSlip.ResultsAddUpSecCd := '';
  h_SalesSlip.ResultsAddUpSecNm := '';
  h_SalesSlip.UpdateSecCd := '';
  h_SalesSlip.SalesSlipUpdateCd := 0;
  h_SalesSlip.SearchSlipDate := 0;
  h_SalesSlip.ShipmentDay := 0;
  h_SalesSlip.SalesDate := 0;
  h_SalesSlip.AddUpADate := 0;
  h_SalesSlip.DelayPaymentDiv := 0;
  h_SalesSlip.EstimateFormNo := '';
  h_SalesSlip.EstimateDivide := 0;
  h_SalesSlip.InputAgenCd := '';
  h_SalesSlip.InputAgenNm := '';
  h_SalesSlip.SalesInputCode := '';
  h_SalesSlip.SalesInputName := '';
  h_SalesSlip.FrontEmployeeCd := '';
  h_SalesSlip.FrontEmployeeNm := '';
  h_SalesSlip.SalesEmployeeCd := '';
  h_SalesSlip.SalesEmployeeNm := '';
  h_SalesSlip.TotalAmountDispWayCd := 0;
  h_SalesSlip.TtlAmntDispRateApy := 0;
  h_SalesSlip.SalesTotalTaxInc := 0;
  h_SalesSlip.SalesTotalTaxExc := 0;
  h_SalesSlip.SalesPrtTotalTaxInc := 0;
  h_SalesSlip.SalesPrtTotalTaxExc := 0;
  h_SalesSlip.SalesWorkTotalTaxInc := 0;
  h_SalesSlip.SalesWorkTotalTaxExc := 0;
  h_SalesSlip.SalesSubtotalTaxInc := 0;
  h_SalesSlip.SalesSubtotalTaxExc := 0;
  h_SalesSlip.SalesPrtSubttlInc := 0;
  h_SalesSlip.SalesPrtSubttlExc := 0;
  h_SalesSlip.SalesWorkSubttlInc := 0;
  h_SalesSlip.SalesWorkSubttlExc := 0;
  h_SalesSlip.SalesNetPrice := 0;
  h_SalesSlip.SalesSubtotalTax := 0;
  h_SalesSlip.ItdedSalesOutTax := 0;
  h_SalesSlip.ItdedSalesInTax := 0;
  h_SalesSlip.SalSubttlSubToTaxFre := 0;
  h_SalesSlip.SalesOutTax := 0;
  h_SalesSlip.SalAmntConsTaxInclu := 0;
  h_SalesSlip.SalesDisTtlTaxExc := 0;
  h_SalesSlip.ItdedSalesDisOutTax := 0;
  h_SalesSlip.ItdedSalesDisInTax := 0;
  h_SalesSlip.ItdedPartsDisOutTax := 0;
  h_SalesSlip.ItdedPartsDisInTax := 0;
  h_SalesSlip.ItdedWorkDisOutTax := 0;
  h_SalesSlip.ItdedWorkDisInTax := 0;
  h_SalesSlip.ItdedSalesDisTaxFre := 0;
  h_SalesSlip.SalesDisOutTax := 0;
  h_SalesSlip.SalesDisTtlTaxInclu := 0;
  h_SalesSlip.PartsDiscountRate := 0;
  h_SalesSlip.RavorDiscountRate := 0;
  h_SalesSlip.TotalCost := 0;
  h_SalesSlip.ConsTaxLayMethod := 0;
  h_SalesSlip.ConsTaxRate := 0;
  h_SalesSlip.FractionProcCd := 0;
  h_SalesSlip.AccRecConsTax := 0;
  h_SalesSlip.AutoDepositCd := 0;
  h_SalesSlip.AutoDepositSlipNo := 0;
  h_SalesSlip.DepositAllowanceTtl := 0;
  h_SalesSlip.DepositAlwcBlnce := 0;
  h_SalesSlip.ClaimCode := 0;
  h_SalesSlip.ClaimSnm := '';
  h_SalesSlip.CustomerCode := 0;
  h_SalesSlip.CustomerName := '';
  h_SalesSlip.CustomerName2 := '';
  h_SalesSlip.CustomerSnm := '';
  h_SalesSlip.HonorificTitle := '';
  h_SalesSlip.OutputNameCode := 0;
  h_SalesSlip.OutputName := '';
  h_SalesSlip.CustSlipNo := 0;
  h_SalesSlip.SlipAddressDiv := 0;
  h_SalesSlip.AddresseeCode := 0;
  h_SalesSlip.AddresseeName := '';
  h_SalesSlip.AddresseeName2 := '';
  h_SalesSlip.AddresseePostNo := '';
  h_SalesSlip.AddresseeAddr1 := '';
  h_SalesSlip.AddresseeAddr3 := '';
  h_SalesSlip.AddresseeAddr4 := '';
  h_SalesSlip.AddresseeTelNo := '';
  h_SalesSlip.AddresseeFaxNo := '';
  h_SalesSlip.PartySaleSlipNum := '';
  h_SalesSlip.SlipNote := '';
  h_SalesSlip.SlipNote2 := '';
  h_SalesSlip.SlipNote3 := '';
  h_SalesSlip.SlipNoteCode := 0;
  h_SalesSlip.SlipNote2Code := 0;
  h_SalesSlip.SlipNote3Code := 0;
  h_SalesSlip.RetGoodsReasonDiv := 0;
  h_SalesSlip.RetGoodsReason := '';
  h_SalesSlip.RegiProcDate := 0;
  h_SalesSlip.CashRegisterNo := 0;
  h_SalesSlip.PosReceiptNo := 0;
  h_SalesSlip.DetailRowCount := 0;
  h_SalesSlip.EdiSendDate := 0;
  h_SalesSlip.EdiTakeInDate := 0;
  h_SalesSlip.UoeRemark1 := '';
  h_SalesSlip.UoeRemark2 := '';
  h_SalesSlip.SlipPrintDivCd := 0;
  h_SalesSlip.SlipPrintFinishCd := 0;
  h_SalesSlip.SalesSlipPrintDate := 0;
  h_SalesSlip.BusinessTypeCode := 0;
  h_SalesSlip.BusinessTypeName := '';
  h_SalesSlip.OrderNumber := '';
  h_SalesSlip.DeliveredGoodsDiv := 0;
  h_SalesSlip.DeliveredGoodsDivNm := '';
  h_SalesSlip.SalesAreaCode := 0;
  h_SalesSlip.SalesAreaName := '';
  h_SalesSlip.ReconcileFlag := 0;
  h_SalesSlip.SlipPrtSetPaperId := '';
  h_SalesSlip.CompleteCd := 0;
  h_SalesSlip.SalesPriceFracProcCd := 0;
  h_SalesSlip.StockGoodsTtlTaxExc := 0;
  h_SalesSlip.PureGoodsTtlTaxExc := 0;
  h_SalesSlip.ListPricePrintDiv := 0;
  h_SalesSlip.EraNameDispCd1 := 0;
  h_SalesSlip.EstimaTaxDivCd := 0;
  h_SalesSlip.EstimateFormPrtCd := 0;
  h_SalesSlip.EstimateSubject := '';
  h_SalesSlip.Footnotes1 := '';
  h_SalesSlip.Footnotes2 := '';
  h_SalesSlip.EstimateTitle1 := '';
  h_SalesSlip.EstimateTitle2 := '';
  h_SalesSlip.EstimateTitle3 := '';
  h_SalesSlip.EstimateTitle4 := '';
  h_SalesSlip.EstimateTitle5 := '';
  h_SalesSlip.EstimateNote1 := '';
  h_SalesSlip.EstimateNote2 := '';
  h_SalesSlip.EstimateNote3 := '';
  h_SalesSlip.EstimateNote4 := '';
  h_SalesSlip.EstimateNote5 := '';
  h_SalesSlip.EstimateValidityDate := 0;
  h_SalesSlip.PartsNoPrtCd := 0;
  h_SalesSlip.OptionPringDivCd := 0;
  h_SalesSlip.RateUseCode := 0;
  h_SalesSlip.CreateDateTime := 0;
  h_SalesSlip.UpdateDateTime := 0;
  h_SalesSlip.EnterpriseCode := '';
  for i := 0 to Length(guidcleararray) - 1 do
  begin
    h_SalesSlip.FileHeaderGuid[i] := guidcleararray[i];
  end;
  h_SalesSlip.UpdEmployeeCode := '';
  h_SalesSlip.UpdAssemblyId1 := '';
  h_SalesSlip.UpdAssemblyId2 := '';
  h_SalesSlip.CustOrderNoDispDiv := 0;
  h_SalesSlip.CustWarehouseCd := '';
  h_SalesSlip.CreditMngCode := 0;
  h_SalesSlip.DetailRowCountForReadSlip := 0;

  //>>>2010/05/30
  h_SalesSlip.OnlineKindDiv := 0;
  h_SalesSlip.InqOriginalEpCd := '';
  h_SalesSlip.InqOriginalSecCd := '';
  h_SalesSlip.AnswerDiv := 0;
  h_SalesSlip.InquiryNumber := 0;
  h_SalesSlip.InqOrdDivCd := 0;
  //<<<2010/05/30
  h_SalesSlip.AutoAnswerDivSCM := 0;// add 2011/07/18 zhubj
  h_SalesSlip.PreSalesDate  := 0; //ADD 鄧潘ハン 2012/03/12 Redmine#28288
end;

// **********************************************************************//
// Module Name     :  管理番号ガイド操作部品フリー関数                        //
// :  ClearTCarMangInputExtraInfo                            //
// 引数            :  １．売上データ                                      //
// 戻り値          :  無し                                              //
// Programer       :  自動生成                                            //
// Date            :  2010.04.01                                          //
// Note            :  管理番号ガイド操作部品フリーします                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
// **********************************************************************//
procedure ClearTCarMangInputExtraInfo(var h_CarMangInputExtraInfo: TCarMangInputExtraInfo);
var
  i: Integer;
  guidcleararray: array [0 .. 15] of AnsiChar;
begin
  h_CarMangInputExtraInfo.AddiCarSpec1 := '';
  h_CarMangInputExtraInfo.AddiCarSpec2 := '';
  h_CarMangInputExtraInfo.AddiCarSpec3 := '';
  h_CarMangInputExtraInfo.AddiCarSpec4 := '';
  h_CarMangInputExtraInfo.AddiCarSpec5 := '';
  h_CarMangInputExtraInfo.AddiCarSpec6 := '';
  h_CarMangInputExtraInfo.AddiCarSpecTitle1 := '';
  h_CarMangInputExtraInfo.AddiCarSpecTitle2 := '';
  h_CarMangInputExtraInfo.AddiCarSpecTitle3 := '';
  h_CarMangInputExtraInfo.AddiCarSpecTitle4 := '';
  h_CarMangInputExtraInfo.AddiCarSpecTitle5 := '';
  h_CarMangInputExtraInfo.AddiCarSpecTitle6 := '';
  h_CarMangInputExtraInfo.BlockIllustrationCd := 0;
  h_CarMangInputExtraInfo.BodyName := '';
  h_CarMangInputExtraInfo.BodyNameCode := 0;
  h_CarMangInputExtraInfo.CarAddInfo1 := '';
  h_CarMangInputExtraInfo.CarAddInfo2 := '';
  h_CarMangInputExtraInfo.CarInspectYear := 0;
  h_CarMangInputExtraInfo.CarMngCode := '';
  h_CarMangInputExtraInfo.CarMngNo := 0;
  h_CarMangInputExtraInfo.CarNo := '';
  h_CarMangInputExtraInfo.CarNote := '';
  for i := 0 to Length(guidcleararray) - 1 do
  begin
    h_CarMangInputExtraInfo.CarRelationGuid[i] := guidcleararray[i];
  end;
  h_CarMangInputExtraInfo.CategoryNo := 0;
//  h_CarMangInputExtraInfo.CategoryObjAry := '';
  h_CarMangInputExtraInfo.CategorySignModel := '';
  h_CarMangInputExtraInfo.ColorCode := '';
  h_CarMangInputExtraInfo.ColorName1 := '';
  h_CarMangInputExtraInfo.CreateDateTime := 0;
  h_CarMangInputExtraInfo.CustomerCode := 0;
  h_CarMangInputExtraInfo.CustomerCodeForGuide := '';
  h_CarMangInputExtraInfo.CustomerName := 0;
  h_CarMangInputExtraInfo.DoorCount := 0;
  h_CarMangInputExtraInfo.EDivNm := '';
  h_CarMangInputExtraInfo.EdProduceFrameNo := 0;
  h_CarMangInputExtraInfo.EdProduceTypeOfYear := 0;
  h_CarMangInputExtraInfo.EngineDisplaceNm := '';
  h_CarMangInputExtraInfo.EngineModel := '';
  h_CarMangInputExtraInfo.EngineModelNm := '';
  h_CarMangInputExtraInfo.EnterpriseCode := '';
  h_CarMangInputExtraInfo.EntryDate := 0;
  h_CarMangInputExtraInfo.ExhaustGasSign := '';
  for i := 0 to Length(guidcleararray) - 1 do
  begin
    h_CarMangInputExtraInfo.FileHeaderGuid[i] := guidcleararray[i];
  end;
  h_CarMangInputExtraInfo.FirstEntryDate := 0;
  h_CarMangInputExtraInfo.FrameModel := '';
  h_CarMangInputExtraInfo.FrameNo := '';
  h_CarMangInputExtraInfo.FullModel := '';
//  h_CarMangInputExtraInfo.FullModelFixedNoAry := '';
  h_CarMangInputExtraInfo.InspectMaturityDate := 0;
  h_CarMangInputExtraInfo.LogicalDeleteCode := 0;
  h_CarMangInputExtraInfo.LTimeCiMatDate := 0;
  h_CarMangInputExtraInfo.MakerCode := 0;
  h_CarMangInputExtraInfo.MakerFullName := '';
  h_CarMangInputExtraInfo.MakerHalfName := '';
  h_CarMangInputExtraInfo.Mileage := 0;
  h_CarMangInputExtraInfo.ModelCode := 0;
  h_CarMangInputExtraInfo.ModelDesignationNo := 0;
  h_CarMangInputExtraInfo.ModelFullName := '';
  h_CarMangInputExtraInfo.ModelGradeNm := '';
  h_CarMangInputExtraInfo.ModelGradeSname := '';
  h_CarMangInputExtraInfo.ModelHalfName := '';
  h_CarMangInputExtraInfo.ModelSubCode := 0;
  h_CarMangInputExtraInfo.NumberPlate1Code := 0;
  h_CarMangInputExtraInfo.NumberPlate1Name := '';
  h_CarMangInputExtraInfo.NumberPlate2 := '';
  h_CarMangInputExtraInfo.NumberPlate3 := '';
  h_CarMangInputExtraInfo.NumberPlate4 := 0;
  h_CarMangInputExtraInfo.NumberPlateForGuide := '';
  h_CarMangInputExtraInfo.PartsDataOfferFlag := 0;
  h_CarMangInputExtraInfo.ProduceTypeOfYearCd := 0;
  h_CarMangInputExtraInfo.ProduceTypeOfYearInput := 0;
  h_CarMangInputExtraInfo.ProduceTypeOfYearNm := '';
  h_CarMangInputExtraInfo.RelevanceModel := '';
  h_CarMangInputExtraInfo.SearchFrameNo := 0;
  h_CarMangInputExtraInfo.SeriesModel := '';
  h_CarMangInputExtraInfo.ShiftNm := '';
  h_CarMangInputExtraInfo.StProduceFrameNo := 0;
  h_CarMangInputExtraInfo.StProduceTypeOfYear := 0;
  h_CarMangInputExtraInfo.SubCarNmCd := 0;
  h_CarMangInputExtraInfo.SystematicCode := 0;
  h_CarMangInputExtraInfo.SystematicName := '';
  h_CarMangInputExtraInfo.ThreeDIllustNo := 0;
  h_CarMangInputExtraInfo.TransmissionNm := '';
  h_CarMangInputExtraInfo.TrimCode := '';
  h_CarMangInputExtraInfo.TrimName := '';
  h_CarMangInputExtraInfo.UpdateDateTime := 0;
  h_CarMangInputExtraInfo.WheelDriveMethodNm := '';
  h_CarMangInputExtraInfo.DomesticForeignCode := 0; // ADD 2013/03/21
end;

// **********************************************************************//
// Module Name     :  車種部品フリー関数                        //
// :  ClearTModelNameU                            //
// 引数            :  １．車種名称マスタ                                      //
// 戻り値          :  無し                                              //
// Programer       :  自動生成                                            //
// Date            :  2010.03.16                                          //
// Note            :  車種部品フリーします                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
// **********************************************************************//
procedure ClearTModelNameU(var h_ModelNameU: TModelNameU);
var
  i: Integer;
  guidcleararray: array [0 .. 15] of AnsiChar;
begin
  h_ModelNameU.CreateDateTime := 0;
  h_ModelNameU.CreateDateTimeAdFormal := '';
  h_ModelNameU.CreateDateTimeAdInFormal := '';
  h_ModelNameU.CreateDateTimeJpFormal := '';
  h_ModelNameU.CreateDateTimeJpInFormal := '';
  h_ModelNameU.Division := 0;
  h_ModelNameU.DivisionName := '';
  h_ModelNameU.EnterpriseCode := '';
  h_ModelNameU.EnterpriseName := '';
  for i := 0 to Length(guidcleararray) - 1 do
  begin
    h_ModelNameU.FileHeaderGuid[i] := guidcleararray[i];
  end;
  h_ModelNameU.LogicalDeleteCode := 0;
  h_ModelNameU.MakerCode := 0;
  h_ModelNameU.ModelAliasName := '';
  h_ModelNameU.ModelCode := 0;
  h_ModelNameU.ModelFullName := '';
  h_ModelNameU.ModelHalfName := '';
  h_ModelNameU.ModelSubCode := 0;
  h_ModelNameU.ModelUniqueCode := 0;
  h_ModelNameU.OfferDataDiv := 0;
  h_ModelNameU.OfferDate := 0;
  h_ModelNameU.UpdAssemblyId1 := '';
  h_ModelNameU.UpdAssemblyId2 := '';
  h_ModelNameU.UpdateDateTime := 0;
  h_ModelNameU.UpdateDateTimeAdFormal := '';
  h_ModelNameU.UpdateDateTimeAdInFormal := '';
  h_ModelNameU.UpdateDateTimeJpFormal := '';
  h_ModelNameU.UpdateDateTimeJpInFormal := '';
  h_ModelNameU.UpdEmployeeCode := '';
  h_ModelNameU.UpdEmployeeName := '';
end;

// **********************************************************************//
// Module Name     :  返品理由部品フリー関数                        //
// :  ClearTUserGdHd                            //
// 引数            :  １．XXXX                                      //
// 戻り値          :  無し                                              //
// Programer       :  自動生成                                            //
// Date            :  2010.03.17                                          //
// Note            :  返品理由部品フリーします                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
// **********************************************************************//
procedure ClearTUserGdHd(var h_UserGdHd: TUserGdHd);
begin
  h_UserGdHd.CreateDateTime           := 0;
  h_UserGdHd.CreateDateTimeAdFormal   := '';
  h_UserGdHd.CreateDateTimeAdInFormal := '';
  h_UserGdHd.CreateDateTimeJpFormal   := '';
  h_UserGdHd.CreateDateTimeJpInFormal := '';
  h_UserGdHd.LogicalDeleteCode        := 0;
  h_UserGdHd.MasterOfferCd            := 0;
  h_UserGdHd.UpdateDateTime           := 0;
  h_UserGdHd.UpdateDateTimeAdFormal   := '';
  h_UserGdHd.UpdateDateTimeAdInFormal := '';
  h_UserGdHd.UpdateDateTimeJpFormal   := '';
  h_UserGdHd.UpdateDateTimeJpInFormal := '';
  h_UserGdHd.UserGuideDivCd           := '';
  h_UserGdHd.UserGuideDivNm           := '';
end;

// **********************************************************************//
// Module Name     :  返品理由部品フリー関数                        //
// :  ClearTUserGdBd                            //
// 引数            :  １．XXXX                                      //
// 戻り値          :  無し                                              //
// Programer       :  自動生成                                            //
// Date            :  2010.03.17                                          //
// Note            :  返品理由部品フリーします                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
// **********************************************************************//
procedure ClearTUserGdBd(var h_UserGdBd: TUserGdBd);
var
  i: Integer;
  guidcleararray: array [0 .. 15] of AnsiChar;
begin
  h_UserGdBd.CreateDateTime             := 0;
  h_UserGdBd.CreateDateTimeAdFormal     := '';
  h_UserGdBd.CreateDateTimeAdInFormal   := '';
  h_UserGdBd.CreateDateTimeJpFormal     := '';
  h_UserGdBd.CreateDateTimeJpInFormal   := '';
  h_UserGdBd.EnterpriseCode             := '';
  h_UserGdBd.EnterpriseName             := '';
  for i := 0 to Length(guidcleararray) - 1 do
  begin
    h_UserGdBd.FileHeaderGuid            [i] := guidcleararray[i];
  end;
  h_UserGdBd.GuideCode                  := 0;
  h_UserGdBd.GuideName                  := '';
  h_UserGdBd.GuideType                  := 0;
  h_UserGdBd.LogicalDeleteCode          := 0;
  h_UserGdBd.UpdAssemblyId1             := '';
  h_UserGdBd.UpdAssemblyId2             := '';
  h_UserGdBd.UpdateDateTime           := 0;
  h_UserGdBd.UpdateDateTimeAdFormal     := '';
  h_UserGdBd.UpdateDateTimeAdInFormal   := '';
  h_UserGdBd.UpdateDateTimeJpFormal     := '';
  h_UserGdBd.UpdateDateTimeJpInFormal   := '';
  h_UserGdBd.UpdEmployeeCode            := '';
  h_UserGdBd.UpdEmployeeName            := '';
  h_UserGdBd.UserGuideDivCd             := 0;
end;
// add by gaofeng end


// add by Lizc start

// **********************************************************************//
// Module Name     :  車両検索部品フリー関数                        //
// :  ClearTColorInfo                            //
// 引数            :  １．カラー情報                                      //
// 戻り値          :  無し                                              //
// Programer       :  自動生成                                            //
// Date            :  2010.03.30                                          //
// Note            :  車両検索部品フリーします                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
// **********************************************************************//
procedure ClearTColorInfo(var h_ColorInfo: TColorInfo);
begin
  h_ColorInfo.ColorCode := '';
  h_ColorInfo.ColorName := '';
  h_ColorInfo.MakerCode := 0;
  h_ColorInfo.ModelCode := 0;
  h_ColorInfo.ModelSubCode := 0;
  h_ColorInfo.SelectionState := False;
end;

// **********************************************************************//
// Module Name     :  車両検索部品フリー関数                        //
// :  ClearTTrimInfo                            //
// 引数            :  １．トリム情報                                      //
// 戻り値          :  無し                                              //
// Programer       :  自動生成                                            //
// Date            :  2010.03.30                                          //
// Note            :  車両検索部品フリーします                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
// **********************************************************************//
procedure ClearTTrimInfo(var h_TrimInfo: TTrimInfo);
begin
  h_TrimInfo.MakerCode := 0;
  h_TrimInfo.ModelCode := 0;
  h_TrimInfo.ModelSubCode := 0;
  h_TrimInfo.TrimCode := '';
  h_TrimInfo.TrimName := '';
  h_TrimInfo.SelectionState := False;
end;

// **********************************************************************//
// Module Name     :  車両検索部品フリー関数                        //
// :  ClearTCEqpDefDspInfo                            //
// 引数            :  １．装備情報                                      //
// 戻り値          :  無し                                              //
// Programer       :  自動生成                                            //
// Date            :  2010.03.30                                          //
// Note            :  車両検索部品フリーします                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
// **********************************************************************//
procedure ClearTCEqpDefDspInfo(var h_CEqpDefDspInfo: TCEqpDefDspInfo);
begin
  h_CEqpDefDspInfo.EquipmentCode := 0;
  h_CEqpDefDspInfo.EquipmentDispOrder := 0;
  h_CEqpDefDspInfo.EquipmentGenreCd := 0;
  h_CEqpDefDspInfo.EquipmentGenreNm := '';
  h_CEqpDefDspInfo.EquipmentIconCode := 0;
  h_CEqpDefDspInfo.EquipmentName := '';
  h_CEqpDefDspInfo.EquipmentShortName := '';
  h_CEqpDefDspInfo.MakerCode := 0;
  h_CEqpDefDspInfo.ModelCode := 0;
  h_CEqpDefDspInfo.ModelSubCode := 0;
  h_CEqpDefDspInfo.SelectionState := False;
  h_CEqpDefDspInfo.SystematicCode := 0;
end;

// **********************************************************************//
// Module Name     :  車両検索部品フリー関数                        //
// :  ClearTCarSpecInfo                            //
// 引数            :  １．諸元情報                                      //
// 戻り値          :  無し                                              //
// Programer       :  自動生成                                            //
// Date            :  2010.03.30                                          //
// Note            :  車両検索部品フリーします                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
// **********************************************************************//
procedure ClearTCarSpecInfo(var h_CarSpecInfo: TCarSpecInfo);
begin
  h_CarSpecInfo.ModelGradeNm := '';
  h_CarSpecInfo.BodyName := '';
  h_CarSpecInfo.DoorCount := 0;
  h_CarSpecInfo.EDivNm := '';
  h_CarSpecInfo.EngineDisplaceNm := '';
  h_CarSpecInfo.EngineModelNm := '';
  h_CarSpecInfo.ShiftNm := '';
  h_CarSpecInfo.TransmissionNm := '';
  h_CarSpecInfo.WheelDriveMethodNm := '';
  h_CarSpecInfo.AddiCarSpec1 := '';
  h_CarSpecInfo.AddiCarSpec2 := '';
  h_CarSpecInfo.AddiCarSpec3 := '';
  h_CarSpecInfo.AddiCarSpec4 := '';
  h_CarSpecInfo.AddiCarSpec5 := '';
  h_CarSpecInfo.AddiCarSpec6 := '';
end;

// **********************************************************************//
// Module Name     :  車両検索部品フリー関数                        //
// :  ClearTCarInfo                            //
// 引数            :  １．車両情報                                      //
// 戻り値          :  無し                                              //
// Programer       :  自動生成                                            //
// Date            :  2010.03.30                                          //
// Note            :  車両検索部品フリーします                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
// **********************************************************************//
procedure ClearTCarInfo(var h_CarInfo: TCarInfo);
begin
  h_CarInfo.CarRelationGuid := '';
  h_CarInfo.CustomerCode := 0;
  h_CarInfo.CarMngNo := 0;
  h_CarInfo.CarMngCode := '';
  h_CarInfo.NumberPlate1Code := 0;
  h_CarInfo.NumberPlate1Name := '';
  h_CarInfo.NumberPlate2 := '';
  h_CarInfo.NumberPlate3 := '';
  h_CarInfo.NumberPlate4 := 0;
  h_CarInfo.EntryDate := 0;
  h_CarInfo.FirstEntryDate := 0;
  h_CarInfo.MakerCode := 0;
  h_CarInfo.MakerFullName := '';
  h_CarInfo.MakerHalfName := '';
  h_CarInfo.ModelCode := 0;
  h_CarInfo.ModelSubCode := 0;
  h_CarInfo.ModelFullName := '';
  h_CarInfo.ModelHalfName := '';
  h_CarInfo.SystematicCode := 0;
  h_CarInfo.SystematicName := '';
  h_CarInfo.ProduceTypeOfYearCd := 0;
  h_CarInfo.ProduceTypeOfYearNm := '';
  h_CarInfo.StProduceTypeOfYear := 0;
  h_CarInfo.EdProduceTypeOfYear := 0;
  h_CarInfo.DoorCount := 0;
  h_CarInfo.BodyNameCode := 0;
  h_CarInfo.BodyName := '';
  h_CarInfo.ExhaustGasSign := '';
  h_CarInfo.SeriesModel := '';
  h_CarInfo.CategorySignModel := '';
  h_CarInfo.FullModel := '';
  h_CarInfo.ModelDesignationNo := 0;
  h_CarInfo.CategoryNo := 0;
  h_CarInfo.FrameModel := '';
  h_CarInfo.FrameNo := '';
  h_CarInfo.SearchFrameNo := 0;
  h_CarInfo.StProduceFrameNo := 0;
  h_CarInfo.EdProduceFrameNo := 0;
  h_CarInfo.ModelGradeNm := '';
  h_CarInfo.EngineModelNm := '';
  h_CarInfo.EngineDisplaceNm := '';
  h_CarInfo.EDivNm := '';
  h_CarInfo.TransmissionNm := '';
  h_CarInfo.ShiftNm := '';
  h_CarInfo.WheelDriveMethodNm := '';
  h_CarInfo.AddiCarSpec1 := '';
  h_CarInfo.AddiCarSpec2 := '';
  h_CarInfo.AddiCarSpec3 := '';
  h_CarInfo.AddiCarSpec4 := '';
  h_CarInfo.AddiCarSpec5 := '';
  h_CarInfo.AddiCarSpec6 := '';
  h_CarInfo.AddiCarSpecTitle1 := '';
  h_CarInfo.AddiCarSpecTitle2 := '';
  h_CarInfo.AddiCarSpecTitle3 := '';
  h_CarInfo.AddiCarSpecTitle4 := '';
  h_CarInfo.AddiCarSpecTitle5 := '';
  h_CarInfo.AddiCarSpecTitle6 := '';
  h_CarInfo.RelevanceModel := '';
  h_CarInfo.SubCarNmCd := 0;
  h_CarInfo.ModelGradeSname := '';
  h_CarInfo.BlockIllustrationCd := 0;
  h_CarInfo.ThreeDIllustNo := 0;
  h_CarInfo.PartsDataOfferFlag := 0;
  h_CarInfo.InspectMaturityDate := 0;
  h_CarInfo.LTimeCiMatDate := 0;
  h_CarInfo.CarInspectYear := 0;
  h_CarInfo.Mileage := 0;
  h_CarInfo.CarNo := '';
  h_CarInfo.FullModelFixedNoAry := '';
  h_CarInfo.CategoryObjAry := '';
  h_CarInfo.ProduceTypeOfYearInput := 0;
  h_CarInfo.ColorCode := '';
  h_CarInfo.ColorName1 := '';
  h_CarInfo.TrimCode := '';
  h_CarInfo.TrimName := '';
  h_CarInfo.AcceptAnOrderNo := 0;
  h_CarInfo.CarNote := '';
  h_CarInfo.CarAddInfo1 := '';
  h_CarInfo.CarAddInfo2 := '';
  h_CarInfo.EngineModel := '';
  h_CarInfo.ProduceTypeOfYearRange := '';
  h_CarInfo.ProduceFrameNoRange := '';
  h_CarInfo.DomesticForeignCode := 0; // ADD 2013/03/21
  h_CarInfo.CarNoteCode := 0; //ADD 2014/05/19 T.Miyamoto 仕掛一覧№2218
end;

// **********************************************************************//
// Module Name     :  車両検索部品フリー関数                        //
// :  ClearTCarModel                            //
// 引数            :  １．xxxxx                                      //
// 戻り値          :  無し                                              //
// Programer       :  自動生成                                            //
// Date            :  2010.03.30                                          //
// Note            :  車両検索部品フリーします                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
// **********************************************************************//
procedure ClearTCarModel(var h_CarModel: TCarModel);
begin
  h_CarModel.CategorySign := '';
  h_CarModel.ExhaustGasSign := '';
  h_CarModel.FullModel := '';
  h_CarModel.IsFullModel := True;
  h_CarModel.SeriesModel := '';
end;

// **********************************************************************//
// Module Name     :  車両検索部品フリー関数                        //
// :  ClearTEngineModel                            //
// 引数            :  １．xxxxx                                      //
// 戻り値          :  無し                                              //
// Programer       :  自動生成                                            //
// Date            :  2010.03.30                                          //
// Note            :  車両検索部品フリーします                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
// **********************************************************************//
procedure ClearTEngineModel(var h_EngineModel: TEngineModel);
begin
  h_EngineModel.FullModel := '';
  h_EngineModel.Model := '';
  h_EngineModel.ModelNm := '';
end;

// **********************************************************************//
// Module Name     :  車両検索部品フリー関数                        //
// :  ClearTCarSearchCondition                            //
// 引数            :  １．車両検索条件                                      //
// 戻り値          :  無し                                              //
// Programer       :  自動生成                                            //
// Date            :  2010.03.30                                          //
// Note            :  車両検索部品フリーします                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
// **********************************************************************//
procedure ClearTCarSearchCondition(var h_CarSearchCondition: TCarSearchCondition);
begin
  ClearTCarModel(h_CarSearchCondition.CarModel);
  h_CarSearchCondition.CategoryNo := 0;
  ClearTEngineModel(h_CarSearchCondition.EngineModel);
  h_CarSearchCondition.EraNameDispCd1 := 0;
  h_CarSearchCondition.IsReady := False;
  h_CarSearchCondition.MakerCode := 0;
  h_CarSearchCondition.ModelCode := 0;
  h_CarSearchCondition.ModelDesignationNo := 0;
  h_CarSearchCondition.ModelPlate := '';
  h_CarSearchCondition.ModelSubCode := 0;
end;


procedure ClearBeforeCarSearchBuffer(var h_BeforeCarSearchBuffer: BeforeCarSearchBuffer);
begin
  h_BeforeCarSearchBuffer.ProduceFrameNo := '';
  h_BeforeCarSearchBuffer.FirstEntryDate := 0;
  h_BeforeCarSearchBuffer.ColorNo := '';
  h_BeforeCarSearchBuffer.TrimNo := '';
end;

// **********************************************************************//
// Module Name     :  車両検索部品フリー関数                        //
// :  ClearTCustomerInfo                            //
// 引数            :  １．得意先情報                                      //
// 戻り値          :  無し                                              //
// Programer       :  自動生成                                            //
// Date            :  2010.04.19                                          //
// Note            :  車両検索部品フリーします                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
// **********************************************************************//
procedure ClearTCustomerInfo(var h_CustomerInfo: TCustomerInfo);
var
  i: Integer;
  guidcleararray: array [0 .. 15] of AnsiChar;
begin
  h_CustomerInfo.AcceptWholeSale := 0;
  h_CustomerInfo.AccountNoInfo1 := '';
  h_CustomerInfo.AccountNoInfo2 := '';
  h_CustomerInfo.AccountNoInfo3 := '';
  h_CustomerInfo.AccRecDivCd := 0;
  h_CustomerInfo.AcpOdrrSlipPrtDiv := 0;
  h_CustomerInfo.Address1 := '';
  h_CustomerInfo.Address3 := '';
  h_CustomerInfo.Address4 := '';
  h_CustomerInfo.BillCollecterCd := '';
  h_CustomerInfo.BillCollecterNm := '';
  h_CustomerInfo.BillHonorificTtl := '';
  h_CustomerInfo.BillHonorTtlPrtDiv := 0;
  h_CustomerInfo.BillOutputCode := 0;
  h_CustomerInfo.BillOutPutCodeNm := '';
  h_CustomerInfo.BillOutputName := '';
  h_CustomerInfo.BillPartsNoPrtCd := 0;
  h_CustomerInfo.BusinessTypeCode := 0;
  h_CustomerInfo.BusinessTypeName := '';
  h_CustomerInfo.CarMngDivCd := 0;
  h_CustomerInfo.ClaimCode := 0;
  h_CustomerInfo.ClaimName := '';
  h_CustomerInfo.ClaimName2 := '';
  h_CustomerInfo.ClaimSectionCode := '';
  h_CustomerInfo.ClaimSectionName := '';
  h_CustomerInfo.ClaimSnm := '';
  h_CustomerInfo.CollectCond := 0;
  h_CustomerInfo.CollectMoneyCode := 0;
  h_CustomerInfo.CollectMoneyDay := 0;
  h_CustomerInfo.CollectMoneyName := '';
  h_CustomerInfo.CollectSight := 0;
  h_CustomerInfo.ConsTaxLayMethod := 0;
  h_CustomerInfo.CorporateDivCode := 0;
  h_CustomerInfo.CreateDateTime := 0;
  h_CustomerInfo.CreateDateTimeAdFormal := '';
  h_CustomerInfo.CreateDateTimeAdInFormal := '';
  h_CustomerInfo.CreateDateTimeJpFormal := '';
  h_CustomerInfo.CreateDateTimeJpInFormal := '';
  h_CustomerInfo.CreditMngCode := 0;
  h_CustomerInfo.CustAgentChgDate := 0;
  h_CustomerInfo.CustAnalysCode1 := 0;
  h_CustomerInfo.CustAnalysCode2 := 0;
  h_CustomerInfo.CustAnalysCode3 := 0;
  h_CustomerInfo.CustAnalysCode4 := 0;
  h_CustomerInfo.CustAnalysCode5 := 0;
  h_CustomerInfo.CustAnalysCode6 := 0;
  h_CustomerInfo.CustCTaXLayRefCd := 0;
  h_CustomerInfo.CustomerAgent := '';
  h_CustomerInfo.CustomerAgentCd := '';
  h_CustomerInfo.CustomerAgentNm := '';
  h_CustomerInfo.CustomerAttributeDiv := 0;
  h_CustomerInfo.CustomerCode := 0;
  h_CustomerInfo.CustomerEpCode := '';
  h_CustomerInfo.CustomerSecCode := '';
  h_CustomerInfo.CustomerSlipNoDiv := 0;
  h_CustomerInfo.CustomerSnm := '';
  h_CustomerInfo.CustomerSubCode := '';
  h_CustomerInfo.CustSlipNoMngCd := 0;
  h_CustomerInfo.CustWarehouseCd := '';
  h_CustomerInfo.CustWarehouseName := '';
  h_CustomerInfo.DefSalesSlipCd := 0;
  h_CustomerInfo.DeliHonorificTtl := '';
  h_CustomerInfo.DeliHonorTtlPrtDiv := 0;
  h_CustomerInfo.DeliPartsNoPrtCd := 0;
  h_CustomerInfo.DepoBankCode := 0;
  h_CustomerInfo.DepoBankName := '';
  h_CustomerInfo.DepoDelCode := 0;
  h_CustomerInfo.DmOutCode := 0;
  h_CustomerInfo.DmOutName := '';
  h_CustomerInfo.EnterpriseCode := '';
  h_CustomerInfo.EnterpriseName := '';
  h_CustomerInfo.EstimatePrtDiv := 0;
  h_CustomerInfo.EstmHonorificTtl := '';
  h_CustomerInfo.EstmHonorTtlPrtDiv := 0;
//  for i := 0 to Length(guidcleararray) - 1 do
//  begin
//    h_CustomerInfo.GuidFileHeaderGuid[i] := guidcleararray[i];
//  end;
  h_CustomerInfo.HomeFaxNo := '';
  h_CustomerInfo.HomeFaxNoDspName := '';
  h_CustomerInfo.HomeTelNo := '';
  h_CustomerInfo.HomeTelNoDspName := '';
  h_CustomerInfo.HonorificTitle := '';
  h_CustomerInfo.InpSectionCode := '';
  h_CustomerInfo.InpSectionName := '';
  //h_CustomerInfo.IsCustomer := '';
  //h_CustomerInfo.IsReceiver := '';
  h_CustomerInfo.JobTypeCode := 0;
  h_CustomerInfo.JobTypeName := '';
  h_CustomerInfo.Kana := '';
  h_CustomerInfo.LavorRateRank := 0;
  h_CustomerInfo.LogicalDeleteCode := 0;
  h_CustomerInfo.MailAddress1 := '';
  h_CustomerInfo.MailAddress2 := '';
  h_CustomerInfo.MailAddrKindCode1 := 0;
  h_CustomerInfo.MailAddrKindCode2 := 0;
  h_CustomerInfo.MailAddrKindName1 := '';
  h_CustomerInfo.MailAddrKindName2 := '';
  h_CustomerInfo.MailSendCode1 := 0;
  h_CustomerInfo.MailSendCode2 := 0;
  h_CustomerInfo.MailSendName1 := '';
  h_CustomerInfo.MailSendName2 := '';
  h_CustomerInfo.MainContactCode := 0;
  h_CustomerInfo.MainContactName := '';
  h_CustomerInfo.MainSendMailAddrCd := 0;
  h_CustomerInfo.MngSectionCode := '';
  h_CustomerInfo.MngSectionName := '';
  h_CustomerInfo.MobileTelNoDspName := '';
  h_CustomerInfo.Name := '';
  h_CustomerInfo.Name2 := '';
  h_CustomerInfo.Note1 := '';
  h_CustomerInfo.Note10 := '';
  h_CustomerInfo.Note2 := '';
  h_CustomerInfo.Note3 := '';
  h_CustomerInfo.Note4 := '';
  h_CustomerInfo.Note5 := '';
  h_CustomerInfo.Note6 := '';
  h_CustomerInfo.Note7 := '';
  h_CustomerInfo.Note8 := '';
  h_CustomerInfo.Note9 := '';
  h_CustomerInfo.NTimeCalcStDate := 0;
  h_CustomerInfo.OfficeFaxNo := '';
  h_CustomerInfo.OfficeFaxNoDspName := '';
  h_CustomerInfo.OfficeTelNo := '';
  h_CustomerInfo.OfficeTelNoDspName := '';
  h_CustomerInfo.OldCustomerAgentCd := '';
  h_CustomerInfo.OldCustomerAgentNm := '';
  h_CustomerInfo.OnlineKindDiv := 0;
  h_CustomerInfo.OthersTelNo := '';
  h_CustomerInfo.OtherTelNoDspName := '';
  h_CustomerInfo.OutputName := '';
  h_CustomerInfo.OutputNameCode := 0;
  h_CustomerInfo.PortableTelNo := '';
  h_CustomerInfo.PostNo := '';
  h_CustomerInfo.PrslOrCorpDivNm := '';
  h_CustomerInfo.PureCode := 0;
  h_CustomerInfo.QrcodePrtCd := 0;
  h_CustomerInfo.ReceiptOutputCode := 0;
  h_CustomerInfo.RectHonorificTtl := '';
  h_CustomerInfo.RectHonorTtlPrtDiv := 0;
  h_CustomerInfo.SalesAreaCode := 0;
  h_CustomerInfo.SalesAreaName := '';
  h_CustomerInfo.SalesCnsTaxFrcProcCd := 0;
  h_CustomerInfo.SalesMoneyFrcProcCd := 0;
  h_CustomerInfo.SalesSlipPrtDiv := 0;
  h_CustomerInfo.SalesUnPrcFrcProcCd := 0;
  h_CustomerInfo.SearchTelNo := '';
  h_CustomerInfo.ShipmSlipPrtDiv := 0;
  h_CustomerInfo.SlipTtlPrn := 0;
  h_CustomerInfo.TotalAmntDspWayRef := 0;
  h_CustomerInfo.TotalAmountDispWayCd := 0;
  h_CustomerInfo.TotalDay := 0;
  h_CustomerInfo.TransStopDate := 0;
  h_CustomerInfo.UOESlipPrtDiv := 0;
  h_CustomerInfo.UpdAssemblyId1 := '';
  h_CustomerInfo.UpdAssemblyId2 := '';
  h_CustomerInfo.UpdateDateTime := 0;
  h_CustomerInfo.UpdateDateTimeAdFormal := '';
  h_CustomerInfo.UpdateDateTimeAdInFormal := '';
  h_CustomerInfo.UpdateDateTimeJpFormal := '';
  h_CustomerInfo.UpdateDateTimeJpInFormal := '';
  h_CustomerInfo.UpdEmployeeCode := '';
  h_CustomerInfo.UpdEmployeeName := '';
end;

// **********************************************************************//
// Module Name     :  車両検索部品フリー関数                        //
// :  ClearTHeaderFocusConstruction                            //
// 引数            :  １．ヘッダー部フォーカス移動設定クラス                                      //
// 戻り値          :  無し                                              //
// Programer       :  自動生成                                            //
// Date            :  2010.05.15                                          //
// Note            :  車両検索部品フリーします                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
// **********************************************************************//
procedure ClearTHeaderFocusConstruction(var h_HeaderFocusConstruction: THeaderFocusConstruction);
begin
  h_HeaderFocusConstruction.Key := '';
  h_HeaderFocusConstruction.Caption := '';
  h_HeaderFocusConstruction.EnterStop := '';
end;

// **********************************************************************//
// Module Name     :  車両検索部品フリー関数                        //
// :  ClearTFooterFocusConstruction                            //
// 引数            :  １．フッタ部フォーカス移動設定クラス                                      //
// 戻り値          :  無し                                              //
// Programer       :  自動生成                                            //
// Date            :  2010.05.15                                          //
// Note            :  車両検索部品フリーします                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
// **********************************************************************//
procedure ClearTFooterFocusConstruction(var h_FooterFocusConstruction: TFooterFocusConstruction);
begin
  h_FooterFocusConstruction.Key := '';
  h_FooterFocusConstruction.Caption := '';
  h_FooterFocusConstruction.EnterStop := '';
end;
// add by Lizc end

// add by Zhangkai start

// **********************************************************************//
// Module Name     :  品番検索部品フリー関数                        //
// :  ClearTSalesDetail                            //
// 引数            :  １．売上明細データ                                      //
// 戻り値          :  無し                                              //
// Programer       :  自動生成                                            //
// Date            :  2010.03.31                                          //
// Note            :  品番検索部品フリーします                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
// **********************************************************************//
procedure ClearTSalesDetail(var h_SalesDetail: TSalesDetail);
begin
  h_SalesDetail.AcptAnOdrStatus := 0;
  h_SalesDetail.SalesSlipNum := '';
  h_SalesDetail.SalesRowNo := 0;
  h_SalesDetail.SalesRowDerivNo := 0;
  h_SalesDetail.SectionCode := '';
  h_SalesDetail.SubSectionCode := 0;
  h_SalesDetail.SalesDate := 0;
  h_SalesDetail.CommonSeqNo := 0;
  h_SalesDetail.SalesSlipDtlNum := 0;
  h_SalesDetail.AcptAnOdrStatusSrc := 0;
  h_SalesDetail.SalesSlipDtlNumSrc := 0;
  h_SalesDetail.SupplierFormalSync := 0;
  h_SalesDetail.StockSlipDtlNumSync := 0;
  h_SalesDetail.SalesSlipCdDtl := 0;
  //h_SalesDetail.DeliGdsCmpltDueDate := 0;// DEL 2010/07/01
  h_SalesDetail.DeliGdsCmpltDueDate := '';// ADD 2010/07/01
  h_SalesDetail.GoodsKindCode := 0;
  h_SalesDetail.GoodsSearchDivCd := 0;
  h_SalesDetail.GoodsMakerCd := 0;
  h_SalesDetail.MakerName := '';
  h_SalesDetail.MakerKanaName := '';
  h_SalesDetail.GoodsNo := '';
  h_SalesDetail.GoodsName := '';
  h_SalesDetail.GoodsNameKana := '';
  h_SalesDetail.GoodsLGroup := 0;
  h_SalesDetail.GoodsLGroupName := '';
  h_SalesDetail.GoodsMGroup := 0;
  h_SalesDetail.GoodsMGroupName := '';
  h_SalesDetail.BLGroupCode := 0;
  h_SalesDetail.BLGroupName := '';
  h_SalesDetail.BLGoodsCode := 0;
  h_SalesDetail.BLGoodsFullName := '';
  h_SalesDetail.EnterpriseGanreCode := 0;
  h_SalesDetail.EnterpriseGanreName := '';
  h_SalesDetail.WarehouseCode := '';
  h_SalesDetail.WarehouseName := '';
  h_SalesDetail.WarehouseShelfNo := '';
  h_SalesDetail.SalesOrderDivCd := 0;
  h_SalesDetail.OpenPriceDiv := 0;
  h_SalesDetail.GoodsRateRank := '';
  h_SalesDetail.CustRateGrpCode := 0;
  h_SalesDetail.ListPriceRate := 0;
  h_SalesDetail.RateSectPriceUnPrc := '';
  h_SalesDetail.RateDivLPrice := '';
  h_SalesDetail.UnPrcCalcCdLPrice := 0;
  h_SalesDetail.PriceCdLPrice := 0;
  h_SalesDetail.StdUnPrcLPrice := 0;
  h_SalesDetail.FracProcUnitLPrice := 0;
  h_SalesDetail.FracProcLPrice := 0;
  h_SalesDetail.ListPriceTaxIncFl := 0;
  h_SalesDetail.ListPriceTaxExcFl := 0;
  h_SalesDetail.ListPriceChngCd := 0;
  h_SalesDetail.SalesRate := 0;
  h_SalesDetail.RateSectSalUnPrc := '';
  h_SalesDetail.RateDivSalUnPrc := '';
  h_SalesDetail.UnPrcCalcCdSalUnPrc := 0;
  h_SalesDetail.PriceCdSalUnPrc := 0;
  h_SalesDetail.StdUnPrcSalUnPrc := 0;
  h_SalesDetail.FracProcUnitSalUnPrc := 0;
  h_SalesDetail.FracProcSalUnPrc := 0;
  h_SalesDetail.SalesUnPrcTaxIncFl := 0;
  h_SalesDetail.SalesUnPrcTaxExcFl := 0;
  h_SalesDetail.SalesUnPrcChngCd := 0;
  h_SalesDetail.CostRate := 0;
  h_SalesDetail.RateSectCstUnPrc := '';
  h_SalesDetail.RateDivUnCst := '';
  h_SalesDetail.UnPrcCalcCdUnCst := 0;
  h_SalesDetail.PriceCdUnCst := 0;
  h_SalesDetail.StdUnPrcUnCst := 0;
  h_SalesDetail.FracProcUnitUnCst := 0;
  h_SalesDetail.FracProcUnCst := 0;
  h_SalesDetail.SalesUnitCost := 0;
  h_SalesDetail.SalesUnitCostChngDiv := 0;
  h_SalesDetail.RateBLGoodsCode := 0;
  h_SalesDetail.RateBLGoodsName := '';
  h_SalesDetail.RateGoodsRateGrpCd := 0;
  h_SalesDetail.RateGoodsRateGrpNm := '';
  h_SalesDetail.RateBLGroupCode := 0;
  h_SalesDetail.RateBLGroupName := '';
  h_SalesDetail.PrtBLGoodsCode := 0;
  h_SalesDetail.PrtBLGoodsName := '';
  h_SalesDetail.SalesCode := 0;
  h_SalesDetail.SalesCdNm := '';
  h_SalesDetail.WorkManHour := 0;
  h_SalesDetail.ShipmentCnt := 0;
  h_SalesDetail.AcceptAnOrderCnt := 0;
  h_SalesDetail.AcptAnOdrAdjustCnt := 0;
  h_SalesDetail.AcptAnOdrRemainCnt := 0;
  h_SalesDetail.RemainCntUpdDate := 0;
  h_SalesDetail.SalesMoneyTaxInc := 0;
  h_SalesDetail.SalesMoneyTaxExc := 0;
  h_SalesDetail.Cost := 0;
  h_SalesDetail.GrsProfitChkDiv := 0;
  h_SalesDetail.SalesGoodsCd := 0;
  h_SalesDetail.SalesPriceConsTax := 0;
  h_SalesDetail.TaxationDivCd := 0;
  h_SalesDetail.PartySlipNumDtl := '';
  h_SalesDetail.DtlNote := '';
  h_SalesDetail.SupplierCd := 0;
  h_SalesDetail.SupplierSnm := '';
  h_SalesDetail.OrderNumber := '';
  h_SalesDetail.WayToOrder := 0;
  h_SalesDetail.SlipMemo1 := '';
  h_SalesDetail.SlipMemo2 := '';
  h_SalesDetail.SlipMemo3 := '';
  h_SalesDetail.InsideMemo1 := '';
  h_SalesDetail.InsideMemo2 := '';
  h_SalesDetail.InsideMemo3 := '';
  h_SalesDetail.BfListPrice := 0;
  h_SalesDetail.BfSalesUnitPrice := 0;
  h_SalesDetail.BfUnitCost := 0;
  h_SalesDetail.CmpltSalesRowNo := 0;
  h_SalesDetail.CmpltGoodsMakerCd := 0;
  h_SalesDetail.CmpltMakerName := '';
  h_SalesDetail.CmpltMakerKanaName := '';
  h_SalesDetail.CmpltGoodsName := '';
  h_SalesDetail.CmpltShipmentCnt := 0;
  h_SalesDetail.CmpltSalesUnPrcFl := 0;
  h_SalesDetail.CmpltSalesMoney := 0;
  h_SalesDetail.CmpltSalesUnitCost := 0;
  h_SalesDetail.CmpltCost := 0;
  h_SalesDetail.CmpltPartySalSlNum := '';
  h_SalesDetail.CmpltNote := '';
  h_SalesDetail.PrtGoodsNo := '';
  h_SalesDetail.PrtMakerCode := 0;
  h_SalesDetail.PrtMakerName := '';
  h_SalesDetail.EditStatus := 0;
  h_SalesDetail.RowStatus := 0;
  h_SalesDetail.SalesMoneyInputDiv := 0;
  h_SalesDetail.ShipmentCntDisplay := 0;
  h_SalesDetail.SupplierStockDisplay := 0;
  h_SalesDetail.ListPriceDisplay := 0;
  h_SalesDetail.StockDate := 0;
  h_SalesDetail.BoCode := '';
  h_SalesDetail.SupplierCdForOrder := 0;
  h_SalesDetail.SupplierSnmForOrder := '';
  h_SalesDetail.DeliveredGoodsDivNm := '';
  h_SalesDetail.FollowDeliGoodsDivNm := '';
  h_SalesDetail.UOEResvdSectionNm := '';
  h_SalesDetail.UOEDeliGoodsDiv := '';
  h_SalesDetail.FollowDeliGoodsDiv := '';
  h_SalesDetail.UOEResvdSection := '';
  h_SalesDetail.PartySalesSlipNum := '';
  h_SalesDetail.AcceptAnOrderNo := 0;
  h_SalesDetail.SearchPartsModeState := 0;
  //>>>2010/05/30
//  h_SalesDetail.CampaignCode := 0;
//  h_SalesDetail.CampaignName := '';
//  h_SalesDetail.GoodsDivCd := 0;
//  h_SalesDetail.AnswerDelivDate := '';
  h_SalesDetail.RecycleDiv := 0;
  h_SalesDetail.RecycleDivNm := '';
//  h_SalesDetail.WayToAcptOdr := 0;
  h_SalesDetail.GoodsMngNo := 0;
//  h_SalesDetail.InqRowNumber := 0;
//  h_SalesDetail.InqRowNumDerivedNo := 0;
  //<<<2010/05/30
end;

// add by Zhangkai end

end.




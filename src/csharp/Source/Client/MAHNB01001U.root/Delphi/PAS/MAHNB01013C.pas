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
// 管理番号              作成担当 : 22018 鈴木 正臣
// 作 成 日  2010/06/12  修正内容 : 携帯メール機能の組込
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 作 成 日  2010/06/16  修正内容 : オフライン対応の組込
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
// 管理番号  10900269-00 作成担当 : FSI今野 利裕
// 作 成 日  2013/03/21  修正内容 : SPK車台番号文字列対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30744 湯上 千加子　
// 作 成 日  2013/03/28  修正内容 : SCM障害№192対応
//----------------------------------------------------------------------------//
// 管理番号  11070100-00 作成担当 : 宮本 利明
// 作 成 日  2014/07/15  修正内容 : 仕掛一覧 №1912
//----------------------------------------------------------------------------//
// 管理番号  11100713-00  作成担当 : 高騁
// 作 成 日  K2015/04/01  修正内容 : 森川部品個別依頼の改良作業全拠点在庫情報一覧機能追加
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

unit MAHNB01013C;

interface

Uses
    HDllCall, DBClient, HFSLLIB, MAHNB01012C;

type
  // add by gaofeng start

    //売上データデータ構造体
    TSalesSlipSearchResult = packed record
        AccRecConsTax: Int64;    //売掛消費税
        AccRecDivCd: LongInt;    //売掛区分
        AcptAnOdrStatus: LongInt;    //受注ステータス
        AddresseeAddr1: WideString;    //納品先住所1
        AddresseeAddr3: WideString;    //納品先住所3
        AddresseeAddr4: WideString;    //納品先住所4
        AddresseeCode: LongInt;    //納品先コード
        AddresseeFaxNo: WideString;    //納品先FAX番号
        AddresseeName: WideString;    //納品先名称
        AddresseeName2: WideString;    //納品先名称2
        AddresseePostNo: WideString;    //納品先郵便番号
        AddresseeTelNo: WideString;    //納品先電話番号
        AddUpADate: Int64;    //計上日付
        AddUpADateAdFormal: WideString;    //計上日付 西暦
        AddUpADateAdInFormal: WideString;    //計上日付 西暦(略)
        AddUpADateJpFormal: WideString;    //計上日付 和暦
        AddUpADateJpInFormal: WideString;    //計上日付 和暦(略)
        AutoDepositCd: LongInt;    //自動入金区分
        AutoDepositSlipNo: LongInt;    //自動入金伝票番号
        BusinessTypeCode: LongInt;    //業種コード
        BusinessTypeName: WideString;    //業種名称
        CarMngCode: WideString;    //車輌管理コード
        CashRegisterNo: LongInt;    //レジ番号
        CategoryNo: LongInt;    //類別番号
        ClaimCode: LongInt;    //請求先コード
        ClaimSnm: WideString;    //請求先略称
        CompleteCd: LongInt;    //一式伝票区分
        ConsTaxLayMethod: LongInt;    //消費税転嫁方式
        ConsTaxRate: Double;    //消費税税率
        CustomerCode: LongInt;    //得意先コード
        CustomerName: WideString;    //得意先名称
        CustomerName2: WideString;    //得意先名称2
        CustomerSnm: WideString;    //得意先略称
        CustSlipNo: LongInt;    //得意先伝票番号
        DebitNLnkSalesSlNum: WideString;    //赤黒連結売上伝票番号
        DebitNoteDiv: LongInt;    //赤伝区分
        DelayPaymentDiv: LongInt;    //来勘区分
        DeliveredGoodsDiv: LongInt;    //納品区分
        DeliveredGoodsDivNm: WideString;    //納品区分名称
        DemandAddUpSecCd: WideString;    //請求計上拠点コード
        DepositAllowanceTtl: Int64;    //入金引当合計額
        DepositAlwcBlnce: Int64;    //入金引当残高
        DetailRowCount: LongInt;    //明細行数
        EdiSendDate: Int64;    //ＥＤＩ送信日
        EdiTakeInDate: Int64;    //ＥＤＩ取込日
        EnterpriseCode: WideString;    //企業コード
        EnterpriseName: WideString;    //企業名称
        EraNameDispCd1: LongInt;    //元号表示区分１
        EstimaTaxDivCd: LongInt;    //見積消費税区分
        EstimateDivide: LongInt;    //見積区分
        EstimateFormNo: WideString;    //見積書番号
        EstimateFormPrtCd: LongInt;    //見積書印刷区分
        EstimateNote1: WideString;    //見積備考１
        EstimateNote2: WideString;    //見積備考2
        EstimateNote3: WideString;    //見積備考3
        EstimateNote4: WideString;    //見積備考4
        EstimateNote5: WideString;    //見積備考5
        EstimateSubject: WideString;    //見積件名
        EstimateTitle1: WideString;    //見積タイトル１
        EstimateTitle2: WideString;    //見積タイトル2
        EstimateTitle3: WideString;    //見積タイトル3
        EstimateTitle4: WideString;    //見積タイトル4
        EstimateTitle5: WideString;    //見積タイトル5
        EstimateValidityDate: Int64;    //見積有効期限
        EstimateValidityDateAdFormal: WideString;    //見積有効期限 西暦
        EstimateValidityDateAdInFormal: WideString;    //見積有効期限 西暦(略)
        EstimateValidityDateJpFormal: WideString;    //見積有効期限 和暦
        EstimateValidityDateJpInFormal: WideString;    //見積有効期限 和暦(略)
        Footnotes1: WideString;    //脚注１
        Footnotes2: WideString;    //脚注2
        FractionProcCd: LongInt;    //端数処理区分
        FrontEmployeeCd: WideString;    //受付従業員コード
        FrontEmployeeNm: WideString;    //受付従業員名称
        FullModel: WideString;    //型式（フル型）
        HonorificTitle: WideString;    //敬称
        InputAgenCd: WideString;    //入力担当者コード
        InputAgenNm: WideString;    //入力担当者名称
        ItdedPartsDisInTax: Int64;    //部品値引対象額合計（税込み）
        ItdedPartsDisOutTax: Int64;    //部品値引対象額合計（税抜き）
        ItdedSalesDisInTax: Int64;    //売上値引内税対象額合計
        ItdedSalesDisOutTax: Int64;    //売上値引外税対象額合計
        ItdedSalesDisTaxFre: Int64;    //売上値引非課税対象額合計
        ItdedSalesInTax: Int64;    //売上内税対象額
        ItdedSalesOutTax: Int64;    //売上外税対象額
        ItdedWorkDisInTax: Int64;    //作業値引対象額合計（税込み）
        ItdedWorkDisOutTax: Int64;    //作業値引対象額合計（税抜き）
        ListPricePrintDiv: LongInt;    //定価印刷区分
        LogicalDeleteCode: LongInt;    //論理削除区分
        MakerFullName: WideString;    //メーカー全角名称
        ModelDesignationNo: LongInt;    //型式指定番号
        ModelFullName: WideString;    //車種全角名称
        OptionPringDivCd: LongInt;    //オプション印字区分
        OrderNumber: WideString;    //発注番号
        OutputName: WideString;    //諸口名称
        PartsDiscountRate: Double;    //部品値引率
        PartsNoPrtCd: LongInt;    //品番印字区分
        PartySaleSlipNum: WideString;    //相手先伝票番号
        PosReceiptNo: LongInt;    //POSレシート番号
        PureGoodsTtlTaxExc: Int64;    //純正商品合計金額（税抜）
        RateUseCode: LongInt;    //掛率使用区分
        RavorDiscountRate: Double;    //工賃値引率
        ReconcileFlag: LongInt;    //消込フラグ
        RegiProcDate: Int64;    //レジ処理日
        RegiProcDateAdFormal: WideString;    //レジ処理日 西暦
        RegiProcDateAdInFormal: WideString;    //レジ処理日 西暦(略)
        RegiProcDateJpFormal: WideString;    //レジ処理日 和暦
        RegiProcDateJpInFormal: WideString;    //レジ処理日 和暦(略)
        ResultsAddUpSecCd: WideString;    //実績計上拠点コード
        ResultsAddUpSecNm: WideString;    //実績計上拠点名称
        RetGoodsReason: WideString;    //返品理由
        RetGoodsReasonDiv: LongInt;    //返品理由コード
        SalAmntConsTaxInclu: Int64;    //売上金額消費税額（内税）
        SalesAreaCode: LongInt;    //販売エリアコード
        SalesAreaName: WideString;    //販売エリア名称
        SalesDate: Int64;    //売上日付
        SalesDateAdFormal: WideString;    //売上日付 西暦
        SalesDateAdInFormal: WideString;    //売上日付 西暦(略)
        SalesDateJpFormal: WideString;    //売上日付 和暦
        SalesDateJpInFormal: WideString;    //売上日付 和暦(略)
        SalesDisOutTax: Int64;    //売上値引消費税額（外税）
        SalesDisTtlTaxExc: Int64;    //売上値引金額計（税抜き）
        SalesDisTtlTaxInclu: Int64;    //売上値引消費税額（内税）
        SalesEmployeeCd: WideString;    //販売従業員コード
        SalesEmployeeNm: WideString;    //販売従業員名称
        SalesGoodsCd: LongInt;    //売上商品区分
        SalesInpSecCd: WideString;    //売上入力拠点コード
        SalesInputCode: WideString;    //売上入力者コード
        SalesInputName: WideString;    //売上入力者名称
        SalesNetPrice: Int64;    //売上正価金額
        SalesOutTax: Int64;    //売上金額消費税額（外税）
        SalesPriceFracProcCd: LongInt;    //売上金額端数処理区分
        SalesPrtSubttlExc: Int64;    //売上部品小計（税抜き）
        SalesPrtSubttlInc: Int64;    //売上部品小計（税込み）
        SalesPrtTotalTaxExc: Int64;    //売上部品合計（税抜き）
        SalesPrtTotalTaxInc: Int64;    //売上部品合計（税込み）
        SalesSlipCd: LongInt;    //売上伝票区分
        SalesSlipNum: WideString;    //売上伝票番号
        SalesSlipPrintDate: Int64;    //売上伝票発行日
        SalesSubtotalTax: Int64;    //売上小計（税）
        SalesSubtotalTaxExc: Int64;    //売上小計（税抜き）
        SalesSubtotalTaxInc: Int64;    //売上小計（税込み）
        SalesTotalTaxExc: Int64;    //売上伝票合計（税抜き）
        SalesTotalTaxInc: Int64;    //売上伝票合計（税込み）
        SalesWorkSubttlExc: Int64;    //売上作業小計（税抜き）
        SalesWorkSubttlInc: Int64;    //売上作業小計（税込み）
        SalesWorkTotalTaxExc: Int64;    //売上作業合計（税抜き）
        SalesWorkTotalTaxInc: Int64;    //売上作業合計（税込み）
        SalSubttlSubToTaxFre: Int64;    //売上小計非課税対象額
        SearchSlipDate: Int64;    //伝票検索日付
        SearchSlipDateAdFormal: WideString;    //伝票検索日付 西暦
        SearchSlipDateAdInFormal: WideString;    //伝票検索日付 西暦(略)
        SearchSlipDateJpFormal: WideString;    //伝票検索日付 和暦
        SearchSlipDateJpInFormal: WideString;    //伝票検索日付 和暦(略)
        SectionCode: WideString;    //拠点コード
        SectionGuideNm: WideString;    //拠点ガイド名称
        ShipmentDay: Int64;    //出荷日付
        ShipmentDayAdFormal: WideString;    //出荷日付 西暦
        ShipmentDayAdInFormal: WideString;    //出荷日付 西暦(略)
        ShipmentDayJpFormal: WideString;    //出荷日付 和暦
        ShipmentDayJpInFormal: WideString;    //出荷日付 和暦(略)
        SlipAddressDiv: LongInt;    //伝票住所区分
        SlipNote: WideString;    //伝票備考
        SlipNote2: WideString;    //伝票備考2
        SlipNote3: WideString;    //伝票備考3
        SlipPrintDivCd: LongInt;    //伝票発行区分
        SlipPrintFinishCd: LongInt;    //伝票発行済区分
        SlipPrtSetPaperId: WideString;    //伝票印刷設定用帳票ID
        StockGoodsTtlTaxExc: Int64;    //在庫商品合計金額（税抜）
        SubSectionCode: LongInt;    //部門コード
        SubSectionName: WideString;    //部門名称
        TotalAmountDispWayCd: LongInt;    //総額表示方法区分
        TotalCost: Int64;    //原価金額計
        TtlAmntDispRateApy: LongInt;    //総額表示掛率適用区分
        UoeRemark1: WideString;    //ＵＯＥリマーク１
        UoeRemark2: WideString;    //ＵＯＥリマーク2
        UpdateSecCd: WideString;    //更新拠点コード
    end;

//    TSalesSlipInputCustomArrayA2 = packed record
//        Csafield1: PSalesDetail;
//        Csafield1Count: LongInt;
//    end;

    //売上伝票検索抽出結果データポインタ型
    PSalesSlipSearchResult = ^TSalesSlipSearchResult;

    //売上伝票検索抽出結果データ配列型
    TSalesSlipSearchResultArray = array of TSalesSlipSearchResult;

    //得意先検索結果データ構造体
    TCustomerSearchRet = packed record
        AcceptWholeSale: LongInt;    //業販先区分
        Address1: WideString;    //住所１（都道府県市区郡・町村・字）
        Address3: WideString;    //住所３（番地）
        Address4: WideString;    //住所４（アパート名称）
        CustomerCode: LongInt;    //得意先コード
        CustomerEpCode: WideString;    //得意先企業コード
        CustomerSecCode: WideString;    //得意先拠点コード
        CustomerSlipNoDiv: LongInt;    //得意先伝票番号区分
        CustomerSubCode: WideString;    //得意先サブコード
        EnterpriseCode: WideString;    //企業コード
        EnterpriseName: WideString;    //企業名称
        HomeTelNo: WideString;    //電話番号（自宅）
        HonorificTitle: WideString;    //敬称
        Kana: WideString;    //カナ
        LogicalDeleteCode: LongInt;    //得意先論理削除区分
        MngSectionCode: WideString;    //管理拠点コード
        Name: WideString;    //名称
        Name2: WideString;    //名称２
        OfficeTelNo: WideString;    //電話番号（勤務先）
        PortableTelNo: WideString;    //電話番号（携帯）
        PostNo: WideString;    //郵便番号
        SearchTelNo: WideString;    //電話番号（検索用下4桁）
        Snm: WideString;    //略称
        TotalDay: LongInt;    //締日
        UpdateDate: Int64;    //更新日付
    end;

    //得意先検索結果データポインタ型
    PCustomerSearchRet = ^TCustomerSearchRet;

    //得意先検索結果データ配列型
    TCustomerSearchRetArray = array of TCustomerSearchRet;

    PWideString = ^WideString;
    TWideStringArray = array of WideString;

    //xxxxデータ構造体
    TSalesSlipHeaderCopyData = packed record
        AcptAnOdrStatus: LongInt;    //xxxx
        AddresseeCode: LongInt;    //xxxx
        AddresseeName: WideString;    //xxxx
        AddresseeName2: WideString;    //xxxx
        CarAddInfo1: WideString;    //xxxx
        CarAddInfo2: WideString;    //xxxx
        CarInspectYear: LongInt;    //xxxx
        CarMngCode: WideString;    //xxxx
        CarMngNo: LongInt;    //xxxx
        CarNote: WideString;    //xxxx
        CategoryNo: LongInt;    //xxxx
        ColorCode: WideString;    //xxxx
        CustomerCode: LongInt;    //xxxx
        CustomerSnm: WideString;    //xxxx
        DeliveredGoodsDiv: LongInt;    //xxxx
        EngineModel: WideString;    //xxxx
        EngineModelNm: WideString;    //xxxx
        EntryDate: Int64;    //xxxx
        FirstEntryDate: LongInt;    //xxxx
        FrameNo: WideString;    //xxxx
        FrontEmployeeCd: WideString;    //xxxx
        FullModel: WideString;    //xxxx
        InspectMaturityDate: Int64;    //xxxx
        LTimeCiMatDate: Int64;    //xxxx
        MakerCode: LongInt;    //xxxx
        Mileage: LongInt;    //xxxx
        ModelCode: LongInt;    //xxxx
        ModelDesignationNo: LongInt;    //xxxx
        ModelFullName: WideString;    //xxxx
        ModelSubCode: LongInt;    //xxxx
        NumberPlate1Code: LongInt;    //xxxx
        NumberPlate1Name: WideString;    //xxxx
        NumberPlate2: WideString;    //xxxx
        NumberPlate3: WideString;    //xxxx
        NumberPlate4: LongInt;    //xxxx
        PartySaleSlipNum: WideString;    //xxxx
        SalesDate: LongInt;    //xxxx
        SalesInputCode: WideString;    //xxxx
        SalesRowNo: LongInt;    //xxxx
        SalesSlipCd: LongInt;    //xxxx
        SalesSlipNum: WideString;    //xxxx
        SectionCode: WideString;    //xxxx
        SlipNote: WideString;    //xxxx
        SlipNote2: WideString;    //xxxx
        SlipNote3: WideString;    //xxxx
        TrimCode: WideString;    //xxxx
        DomesticForeignCode: LongInt;    //国産/外車区分 // ADD 2013/03/21
    end;

    //xxxxデータポインタ型
    PSalesSlipHeaderCopyData = ^TSalesSlipHeaderCopyData;

    //xxxxデータ配列型
    TSalesSlipHeaderCopyDataArray = array of TSalesSlipHeaderCopyData;

    //---UPD 2010/07/06---------->>>>>
    //SetItemsDictionary関数定義
//    TxMAHNB01013B_SetItemsDictionary = function(headControlNames: WideString; footControlNames: WideString)
//    : Integer; stdcall;
    TxMAHNB01013B_SetItemsDictionary = function(headControlNames: WideString; footControlNames: WideString; functionControlNames: WideString; functionDetailControlNames: WideString)
    : Integer; stdcall;
    //---UPD 2010/07/06----------<<<<<

    //setColDisplayStatusList関数定義
    TxMAHNB01013B_setColDisplayStatusList = function()
    : Integer; stdcall;

    // --- ADD 2010/06/02 ---------->>>>>
    //GetReadSlipFlg関数定義
    TxMAHNB01013B_GetReadSlipFlg = function(var readSlipFlg: Boolean)
    : Integer; stdcall;
    // --- ADD 2010/06/02 ----------<<<<<

    // --- ADD 2010/07/08 ---------->>>>>
    //操作権限の制御関数定義
    TxMAHNB01013B_BeginControllingByOperationAuthority = function(var RevisionVisible: Boolean;
    var DeleteVisible: Boolean;
    var RedSlipVisible: Boolean;
    var SlipDiscountVisible: Boolean) // ADD 2013/01/24 鄧潘ハン REDMINE#34141
    : Integer; stdcall;
    // --- ADD 2010/07/08 ----------<<<<<

  // add by gaofeng end

    // --- ADD 2014/07/15 T.Miyamoto 仕掛一覧 №1912 ---------->>>>>
    TxMAHNB01013B_GetOperationSt = function(iOperationCode: Integer): Boolean; stdcall;
    // --- ADD 2014/07/15 T.Miyamoto 仕掛一覧 №1912 ----------<<<<<

    // --- ADD 2011/02/12 ---------->>>>>
    //調査用ログ出力クラス処理関数定義
    TxMAHNB01013B_DoAddLine = function(logNo: Integer;
    slipNo: Integer;
    acptAnOdrStatus: Integer)
    : Integer; stdcall;

    //調査用ログImage出力処理関数定義
    TxMAHNB01013B_DoCacheImage = function()
    : Integer; stdcall;

    //各種マスタチェック関数定義
    TxMAHNB01013B_GetErrorFlag = function(var errorFlag: Boolean)
    : Integer; stdcall;
    // --- ADD 2011/02/12 ----------<<<<<

    //---ADD 2011/11/22 --------------------->>>>>
    //連携判断処理関数定義
    TxMAHNB01013B_CooprtKindDiv = function(var CooprtFlag: Boolean)
    : Integer; stdcall;
    //---ADD 2011/11/22 ---------------------<<<<<

    // --- ADD 2011/04/13 ---------->>>>>
    //選択済み売上行番号リスト取得処理関数定義
    TxMAHNB01013B_DetailDeleteActionTable = function(startRowNo: Integer;
    endRowNo: Integer)
    : Integer; stdcall;
    // --- ADD 2011/04/13 ----------<<<<<

    // --- ADD 2011/05/30 ---------->>>>>
    //画面の拠点コード変化時（キャンペーン情報取得用）関数定義
    TxMAHNB01013B_SetSectionCode = function(sectionCode: WideString)
    : Integer; stdcall;
    // --- ADD 2011/05/30 ----------<<<<<

    // --- ADD 2011/07/18 ---------->>>>>
    //現在庫数を調整します関数定義
    TxMAHNB01013B_StockInfoAdjust = function()
    : Integer; stdcall;
    // --- ADD 2011/07/18 ----------<<<<<

    //保存用設定処理関数定義
    TxMAHNB01013B_SetAfterSaveData = function(resultData: Integer;
    carMngCode: WideString;
    printSlipFlag: Boolean;
    isMakeQR: Boolean;
    scmFlg: Boolean;
    cmtFlag: Boolean;
    // ----- ADD K2011/12/09 --------->>>>>
    slipNote2ErrFlag: Boolean;
    // UPD 2013/03/28 SCM障害№192対応 ------------------->>>>>
    //salesDateErrFlag: Boolean)
    salesDateErrFlag: Boolean;
    isSCMSave: Integer)
    // UPD 2013/03/28 SCM障害№192対応 -------------------<<<<<
    // ----- ADD K2011/12/09 ---------<<<<<
    : Integer; stdcall;

    // --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ---------->>>>>
    //第二売価ガイドの位置を設定します。
    TxMAHNB01013B_SetSecondSalesUnPrcGideLocation = function(locationLeft: Integer;
    locationTop: Integer)
    : Integer; stdcall;

    //水野商工㈱オプション判定関数定義
    TxMAHNB01013B_OptPermitForMizuno2ndSellPriceCtl = function(var optOptPermitForMizuno2ndSellPriceCtl: Boolean)
    : Integer; stdcall;
    // --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ----------<<<<<

    //保存用設定処理関数定義
    TxMAHNB01013B_GetAfterSaveData = function(var resultData: Integer;
    var isMakeQR: Boolean;
    var scmFlg: Boolean;
    var cmtFlag: Boolean;
    // ----- ADD K2011/12/09 --------->>>>>
    var slipNote2ErrFlag: Boolean;
    // UPD 2013/03/28 SCM障害№192対応 ------------------->>>>>
    //var salesDateErrFlag: Boolean)
    var salesDateErrFlag: Boolean;
    var isSCMSave: Integer)
    // UPD 2013/03/28 SCM障害№192対応 -------------------<<<<<
    // ----- ADD K2011/12/09 ---------<<<<<
    : Integer; stdcall;

    //保存用設定処理関数定義
    TxMAHNB01013B_DoAfterSave = function()
    : Integer; stdcall;

    // --- ADD 2012/10/15 ---------->>>>>
    //仕入日のエラーメッセージを表示処理
    TxMAHNB01013B_ShowStockDateMsg = function()
    : Integer; stdcall;
    // --- ADD 2012/10/15 ----------<<<<<

    //関数型定義

    // add by tanh
    //得意先ガイド処理関数定義
//>>>2010/05/30
//    TxMAHNB01013B_Clear = function(isConfirm: Boolean;
//    keepAcptAnOdrStatus: Boolean;
//    keepDate: Boolean;
//    keepFooterInfo: Boolean;
//    keepCustomer: Boolean;
//    keepSalesDate: Boolean)
//    : Boolean; stdcall;
    TxMAHNB01013B_Clear = function(isConfirm: Boolean;
    keepAcptAnOdrStatus: Boolean;
    keepDate: Boolean;
    keepFooterInfo: Boolean;
    keepCustomer: Boolean;
    keepSalesDate: Boolean;
    keepDetailRowCount: Boolean;
    customerCode: Integer)
    : Boolean; stdcall;
//<<<2010/05/30
    //備考設定処理関数定義
    TxMAHNB01013B_GetNoteGuidList = function(enterpriseCode: WideString)
    : Integer; stdcall;
    //伝票区分コンボエディタアイテム設定処理関数定義
    TxMAHNB01013B_GetItemtSalesSlipCd = function(var setItemtSalesSlipCdDisp: Integer;
    var setItemtSalesSlipCdFlg: Integer)
    : Integer; stdcall;
    //ファンクション明細制御取得処理関数定義
    TxMAHNB01013B_GetBitButtonCustomizeSetting = function(key: WideString;
    var bitButtonCustomizedVisible: Integer)
    : Integer; stdcall;

    //終了設定処理関数定義
    // --- UPD m.suzuki 2010/06/12 ---------->>>>>
    //TxMAHNB01013B_Close = function(isConfirmFlg: Boolean;
    //var canCloseFlg: Boolean)
    //: Integer; stdcall;
    TxMAHNB01013B_Close = function(isConfirmFlg: Boolean;
    var canCloseFlg: Boolean; var isMakeQR: Boolean)
    : Integer; stdcall;
    // --- UPD m.suzuki 2010/06/12 ----------<<<<<

    //追加情報タブ項目Visible設定関数定義
    TxMAHNB01013B_GetAddInfoVisible = function(var ctTabKeyAddInfo: Integer;
    var settingAddInfoVisibleFlg: Integer)
    : Integer; stdcall;

    //伝票区分コンボエディタアイテム設定処理関数定義
    TxMAHNB01013B_GetDisplayHeaderFooterInfo = function(
    var inputModeTitle: WideString;
    var defaultSalesSlipNumDf: WideString;
    var searchPartsModeFlg: Integer;
    var operationCodeFlg: Integer)
    : Integer; stdcall;

    //各種マスタチェック関数定義
    TxMAHNB01013B_InitMstCheck = function(var mstCheckFlg: Boolean)
    : Integer; stdcall;

    //元に戻す処理関数定義
    TxMAHNB01013B_Retry = function(isConfirm: Boolean;
    var dialogResultFlg: Boolean)
    : Integer; stdcall;

    //元に戻す処理関数定義
    TxMAHNB01013B_RetryResult = function(var statusFlg: Boolean)
    : Integer; stdcall;

    //得意先情報画面格納処理関数定義
    TxMAHNB01013B_GetDisplayCustomerInfo = function(var customerNameFlg: Integer;
    var totalDayDf: WideString;
    var collectMoneyDf: WideString)
    : Integer; stdcall;

    //HOMEキー設定処理関数定義
    TxMAHNB01013B_SetHomeKeyFlg = function(homeKeyFlg: Boolean)
    : Integer; stdcall;

    //明細データ取得関数定義
    TxMAHNB01013B_SetUserGdBdComboEditor = function(var guideCodeList: TWideStringArray;
    var guideNameList: TWideStringArray)
    : Integer; stdcall;

    //セルEnabled設定取得処理関数定義
    TxMAHNB01013B_GetCellEnabled = function(keyName: WideString)
    : Integer; stdcall;

    // --- ADD 黄興貴 2015/04/29 回答取込パタン追加 ---------------->>>>>
    //UOEデータ取込関数定義
    TxMAHNB01013B_ReadUoeData = function(salesRowNo: Integer)
    : Integer; stdcall;
    //富士ジーワイ商事㈱オプション判定関数定義
    TxMAHNB01013B_OptPermitForFuJi = function(var optPermitForFuJi: Boolean)
    : Integer; stdcall;
    // --- ADD 黄興貴 2015/04/29 回答取込パタン追加 ----------------<<<<<

    // --- ADD 紀飛 2015/06/18 WebUOE発注回答取込 ---------------->>>>>
    //㈱メイゴオプション判定関数定義
    TxMAHNB01013B_OptPermitForMeiGo = function(var optPermitForMeiGo: Boolean)
    : Integer; stdcall;
    // --- ADD 紀飛 2015/06/18 WebUOE発注回答取込 ----------------<<<<<
    // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応--->>>>>
    //電子帳簿連携オプション判定関数定義
    TxMAHNB01013B_OptPermitForEBooks = function(var optPermitForEBooks: Boolean)
    : Integer; stdcall;
    // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応---<<<<<

    //オプション情報処理関数定義
    TxMAHNB01013B_GetGrossProfitRateFlg = function(var grossProfitRateFlg: Boolean)
    : Integer; stdcall;
    // end add by tanh

    // add by zhangkai

    //明細データ取得関数定義
    TxMAHNB01013B_GetSalesAllDetailDataTable = function(var salesDetailList: TSalesSlipInputCustomArrayA2)
    : Integer; stdcall;

    //品番検索処理関数定義
    TxMAHNB01013B_AfterGoodsNoUpdate = function(rowIndex: Integer;
    cellValue: WideString;
    makerCd: Integer;         //ADD 連番729 2011/08/18
    salesRowNo: Integer)
    : Integer; stdcall;

    //行値引き処理関数定義
    TxMAHNB01013B_uButtonLineDiscountClick = function(parmRowIndex: Integer)
    : Integer; stdcall;

    //商品値引き処理関数定義
    TxMAHNB01013B_uButtonGoodsDiscountClick = function(parmRowIndex: Integer)
    : Integer; stdcall;

    //小数点表示区分処理関数定義
    TxMAHNB01013B_SmallPointProc = function(rowIndexParm: Integer)
    : Integer; stdcall;

    //注釈処理関数定義
    TxMAHNB01013B_uButtonAnnotationClick = function(parmRowIndex: Integer)
    : Integer; stdcall;

    //倉庫切替処理関数定義
    TxMAHNB01013B_uButtonChangeWarehouseClick = function(parmSalesRowNo: Integer)
    : Integer; stdcall;

    //在庫検索処理関数定義
    TxMAHNB01013B_uButtonStockSearchClick = function(parmRowIndex: Integer)
    : Integer; stdcall;

    //ＴＢＯ処理関数定義
    TxMAHNB01013B_uButtonTBOClick = function(parmRowIndex: Integer)
    : Integer; stdcall;

    //前行複写処理関数定義
    TxMAHNB01013B_uButtonCopyStockBefLineClick = function(parmRowIndex: Integer)
    : Integer; stdcall;

    //一括複写処理関数定義
    TxMAHNB01013B_uButtonCopyStockAllLineClick = function(parmRowIndex: Integer)
    : Integer; stdcall;

    //グリッドセルアップデート後処理関数定義
    TxMAHNB01013B_uGridDetailsAfterCellUpdate = function(rowIndexParm: Integer;
    cellValue: WideString;
    beforeCellValue: WideString;
    columnName: WideString)
    : Integer; stdcall;

    //グリッドセルアップデート後処理関数定義
    TxMAHNB01013B_uGridDetailsAfterCellUpdateProc = function(rowIndexParm: Integer;
    cellValue: WideString;
    beforeCellValue: WideString;
    columnName: WideString)
    : Integer; stdcall;

    //オプション情報処理関数定義
    TxMAHNB01013B_FormPosSerialize = function(topInt: Integer;
    leftInt: Integer;
    heightInt: Integer;
    widthInt: Integer)
    : Integer; stdcall;
    //オプション情報処理関数定義
    TxMAHNB01013B_FormPosDeserialize = function(var topInt: Integer;
    var leftInt: Integer;
    var heightInt: Integer;
    var widthInt: Integer)
    : Integer; stdcall;

    //グリッド関連チェック処理関数定義
    TxMAHNB01013B_GridJoinCheck = function(salesRowNo: Integer;
    rowIndex: Integer;
    operationCode: Integer;
    mode: Integer)
    : Integer; stdcall;

    //ガイドボタンクリックイベント処理関数定義
    TxMAHNB01013B_uButtonGuideClick = function(rowIndexParm: Integer;
    columnName: WideString)
    : Integer; stdcall;

    //Table処理関数定義
    TxMAHNB01013B_DeatilActionTable = function(salesRowNo: Integer;
    actionType: WideString)
    : Integer; stdcall;

    //チェック処理関数定義
    TxMAHNB01013B_CheckDetailAction = function(beforeRowIndex: Integer;
    parmRowIndex: Integer;
    checkType: Integer)
    : Integer; stdcall;

    //ユーザー設定処理関数定義
    TxMAHNB01013B_GetSalesSlipInputConstructionData = function(var data: Integer;
    inputType: Integer)
    : Integer; stdcall;

    //得意先注番のフォーカス処理関数定義
    TxMAHNB01013B_AfterPartySaleSlipNumFocus = function(var salesSlip: TSalesSlip;
    salesSlipCurrent: TSalesSlip;
    value: WideString;
    var dialogFlag: Boolean)
    : Integer; stdcall;

    //返品理由ガイド処理関数定義
    TxMAHNB01013B_retGoodsReason = function(enterpriseCode: WideString;
    var userGdHd: TUserGdHd;
    var userGdBd: TUserGdBd;
    var salesSlip: TSalesSlip)
    : Integer; stdcall;

    //伝票メモ情報設定処理関数定義
    TxMAHNB01013B_SetSlipMemo = function(slipMemo1: WideString;
    slipMemo2: WideString;
    slipMemo3: WideString;
    insideMemo1: WideString;
    insideMemo2: WideString;
    insideMemo3: WideString;
    salesRowNo: Integer)
    : Integer; stdcall;

    //数値入力チェック処理関数定義
    TxMAHNB01013B_KeyPressNumCheck = function(keta: Integer;
    priod: Integer;
    prevVal: WideString;
    key: WideString;
    selstart: Integer;
    sellength: Integer;
    minusFlg: Boolean)
    : Integer; stdcall;

    //CSV出力先が設定され、フォルダが存在しているかチェック処理関数定義
    TxMAHNB01013B_CsvPassCheck = function(var linkDir: WideString)
    : Integer; stdcall;

    //移動位置取得処理(Enterキー移動時)関数定義
    TxMAHNB01013B_GetNextMovePosition = function(p: WideString;
    var afterColKeyName: WideString)
    : Integer; stdcall;

    // --- ADD 2010/06/02 ---------->>>>>
    //移動位置取得処理(Enterキー移動時)関数定義
    TxMAHNB01013B_GetPreMovePosition = function(p: WideString;
    var afterColKeyName: WideString)
    : Integer; stdcall;
    // --- ADD 2010/06/02 ----------<<<<<

    //Param取得処理関数定義
    TxMAHNB01013B_GetParam = function(var startKeyName: WideString;
    var endKeyNameList: WideString)
    : Integer; stdcall;

    //フォーカス移動対象判定処理関数定義
    TxMAHNB01013B_GetEffectiveJudgment = function(keyName: WideString)
    : Integer; stdcall;
    // end add by zhangkai

// add by yangmj
    //出荷計上処理関数定義
    TxMAHNB01013B_ShipmentAddUp = function(isDataChanged: Boolean;
    var isSave: Integer)
    : Integer; stdcall;

    //出荷照会ボタンクリック処理関数定義
    TxMAHNB01013B_GetSalesHisGuide = function(count: Integer; customerCode: WideString)
    : Integer; stdcall;

    //受注照会(明細選択)関数定義
    TxMAHNB01013B_AcceptAnOrderReferenceSearch = function(rowCount: Integer; customerCode: WideString)
    : Integer; stdcall;

    //受注計上処理関数定義
    TxMAHNB01013B_AcceptAnOrderAddup = function(IsDataChanged: Boolean;
    var IsResult: Integer)
    : Integer; stdcall;

    //見積計上(明細選択)関数定義
    TxMAHNB01013B_EstimateReferenceSearch = function(rowCount: Integer; customerCode: WideString)
    : Integer; stdcall;

    //見積照会(伝票選択)関数定義
    TxMAHNB01013B_EstimateAddup = function(IsDataChanged: Boolean;
    var IsResult: Integer)
    : Integer; stdcall;

    //履歴照会(売上履歴データから明細選択) 関数定義
    TxMAHNB01013B_SalesReferenceSearch = function(rowCount: Integer; customerCode: WideString)
    : Integer; stdcall;

    //伝票複写関数定義
    TxMAHNB01013B_CopySlip = function(IsDataChanged: Boolean;
    var IsResult: Integer)
    : Integer; stdcall;

    //車両管理オプション取得処理関数定義
    TxMAHNB01013B_GetOptCarMng = function(var optCarMng: Integer)
    : Integer; stdcall;

    //伝票備考、伝票備考２、伝票備考３の入力桁数設定処理関数定義
    TxMAHNB01013B_SetNoteCharCnt = function(var slipNoteCharCnt: Integer;
    var slipNote2CharCnt: Integer;
    var slipNote3CharCnt: Integer)
    : Integer; stdcall;

    //返品処理関係関数定義
    TxMAHNB01013B_ReturnSlip = function(isDataChanged: Boolean;
    var isResult: Integer)
    : Integer; stdcall;

    //保存確認ダイアログ表示処理関数定義
    // --- UPD m.suzuki 2010/06/12 ---------->>>>>
    //TxMAHNB01013B_ShowSaveCheckDialog = function(isConfirm: Boolean;
    //var resultNum: Integer; carMngCode: WideString)
    //: Integer; stdcall;
    TxMAHNB01013B_ShowSaveCheckDialog = function(isConfirm: Boolean;
    var resultNum: Integer; carMngCode: WideString; var isMakeQR: Boolean)
    : Integer; stdcall;
    // --- UPD m.suzuki 2010/06/12 ----------<<<<<

    // --- UPD m.suzuki 2010/06/12 ---------->>>>>
    ////保存処理関数定義
    //TxMAHNB01013B_Save = function(isShowSaveCompletionDialog: Boolean;
    //isConfirm: Boolean)
    //: Boolean; stdcall;
    //保存処理関数定義
    TxMAHNB01013B_Save = function(isShowSaveCompletionDialog: Boolean;
    isConfirm: Boolean; var isMakeQR: Boolean )
    : Boolean; stdcall;
    // --- UPD m.suzuki 2010/06/12 ----------<<<<<

    //保存後処理関数定義
// 2011/01/31 >>>
//    // --- UPD m.suzuki 2010/06/12 ---------->>>>>
//    //TxMAHNB01013B_AfterSave = function(var result: Integer;
//    //carMngCode: WideString;
//    //printSlipFlag: Boolean)
//    //: Integer; stdcall;
//    TxMAHNB01013B_AfterSave = function(var result: Integer;
//    carMngCode: WideString;
//    printSlipFlag: Boolean; var isMakeQR: Boolean;
//    scmFlg: Boolean)
//    : Integer; stdcall;
//    // --- UPD m.suzuki 2010/06/12 ----------<<<<<

    TxMAHNB01013B_AfterSave = function(
        var result: Integer;
        carMngCode: WideString;
        printSlipFlag: Boolean;
        var isMakeQR: Boolean;
        var scmFlg: Boolean;
        var cmtFlg: Boolean;
        var slipNote2ErrFlag: Boolean; // ADD K2011/08/12
// UPD 2013/03/28 SCM障害№192対応 --------------------------->>>>>
//        var salesDateErrFlag: Boolean) // ADD K2011/09/01
        var salesDateErrFlag: Boolean;
        var isSCMSave: Integer)
// UPD 2013/03/28 SCM障害№192対応 ---------------------------<<<<<
    : Integer; stdcall;
// 2011/01/31 <<<
    //<<<2010/05/30

    //保存状態取得関数定義
    TxMAHNB01013B_GetSaveStatus = function(var status: Integer)
    : Integer; stdcall;
    // --- ADD 2015/12/09 T.Miyamoto リモ伝障害対応 Redmine#47670 ---------->>>>>
    //オンライン種別取得関数定義
    TxMAHNB01013B_GetOnlineKindDiv = function(var onlineKindDiv: Integer)
    : Integer; stdcall;
    // --- ADD 2015/12/09 T.Miyamoto リモ伝障害対応 Redmine#47670 ----------<<<<<

    //部品検索切替処理関数定義
    TxMAHNB01013B_ChangeSearchMode = function(clearCarFlag: Integer;
    CheckRowEffectiveFlg: Boolean;
    salesRowNo: Integer;
    ContainsFocusFlg: Boolean;
    var carMngCodeMode: Boolean)
    : Integer; stdcall;

    //部品検索モード取得関数定義
    TxMAHNB01013B_GetSearchPartsModeProperty = function(var searchPartsModeProperty: Integer)
    : Integer; stdcall;

    //----ADD 2010/06/17----->>>>>
    //売上データ設定関数定義
    TxMAHNB01013B_SetSalesSlip = function(Salesslip: TSalesSlip)
    : Integer; stdcall;
    //----ADD 2010/06/17-----<<<<<
    //----ADD 2010/11/02----->>>>>
    TxMAHNB01013B_SetSalesSlipByObj = function(Salesslip: TSalesSlip)
    : Integer; stdcall;
    //----ADD 2010/11/02-----<<<<<

    //各種起動データ関数定義
//    TxMAHNB01013B_SetInitData = function()     //DEL 連番729 2011/08/18
    TxMAHNB01013B_SetInitData = function(var existFlg: Boolean)  //ADD 連番729 2011/08/18
    : Integer; stdcall;

// end add by yangmj

// add by gaofeng start

    //初期データをＤＢより取得の処理関数定義
    TxMAHNB01013B_GetInitData = function()
    : Integer; stdcall;

    //売上伝票ガイド処理関数定義
    TxMAHNB01013B_salesSlipGuide = function(formName: WideString;
    enterpriseCode: WideString;
    acptAnOdrStatusDisplay: Integer;
    var acptAnOdrStatus: Integer;
    var estimateDivide: Integer;
    var searchResult: TSalesSlipSearchResult;
    var salesSlip: TSalesSlip;
    var outDialogResult: Boolean;
    var outStatus: Boolean;
    var consTaxLayMethodChangedFlg: Boolean;
    var isPCCUOESaleSlip: Boolean)  // ADD 2011/11/18
    : Integer; stdcall;

    //得意先ガイド処理関数定義
    TxMAHNB01013B_customerGuide = function(customerFlag: Boolean;
    addresseeCode: Integer;
    customerCode: Integer;
    var customerSearchRet: TCustomerSearchRet;
    var dialogResultFlag: Integer;
    var customerCodeChangedFlg: Boolean;
    var optCarMngFlg: Boolean)
    : Integer; stdcall;

    //設定処理関数定義
    TxMAHNB01013B_ShowSalesSlipInputSetup = function()
    : Integer; stdcall;

    //画面項目名称取得処理関数定義
    // UPD　譚洪 2020/02/24 PMKOBETSU-2912の対応 ---------->>>>>
    //TxMAHNB01013B_GetDisplayName = function(var rateName: WideString)
    TxMAHNB01013B_GetDisplayName = function(var rateName: WideString; var taxFlg: Boolean)
    // UPD　譚洪 2020/02/24 PMKOBETSU-2912の対応 ----------<<<<<
    : Integer; stdcall;

    //明細粗利率取得処理関数定義
    TxMAHNB01013B_GetDetailGrossProfitRate = function(rowNo: Integer; var detailGrossProfitRate: WideString;
    var addDetailGrossProfitRate: WideString)
    : Integer; stdcall;

    //削除処理関数定義
    TxMAHNB01013B_Delete = function(var outCheck: Boolean;
    var outDialogResult: Integer;
    var outStatus: Integer)
    : Integer; stdcall;

    //アイテム名の取得処理関数定義
    TxMAHNB01013B_GetItemName = function(var itemName: WideString;
    var tableName: WideString)
    : Integer; stdcall;

    TxMAHNB01013B_GetStatus = function(var status: Integer)
    : Integer; stdcall;

    TxMAHNB01013B_GetBeforeSalesSlipNumText = function(var beforeSalesSlipNumText: WideString)
    : Integer; stdcall;

    //フォーカス位置の取得処理関数定義
    TxMAHNB01013B_GetFocusPositionValue = function(var focusPositionValue: Integer)
    : Integer; stdcall;

    //赤伝処理関数定義
    TxMAHNB01013B_RedSlip = function(isConfirm: Boolean; canRed: Boolean)
    : Integer; stdcall;

    //赤伝できるかどうかフラグの取得処理関数定義
    TxMAHNB01013B_GetCanRed = function(var canRed: Boolean)
    : Integer; stdcall;

    TxMAHNB01013B_GetRedDialogResult = function(var redDialogResult: Integer)
    : Integer; stdcall;

    //見出貼付関数定義
    TxMAHNB01013B_CopySlipHeader = function(
    CarInfoEnabledFlg: Boolean;
    salesRowNo: Integer;
    addresseeName: WideString;
    var existSalesDetail: Boolean;
    var clearDetailFlg: Boolean;
    var searchPartsModeProperty: Integer;
    var fullModelFixedNoAryFlg: Boolean;
    var errorFlg: Boolean;
    var outSalesSlipHeaderCopyData: TSalesSlipHeaderCopyData;
    var copySlipHeaderClearFlg: Boolean)
    : Integer; stdcall;

//-------------- ADD 連番729 2011/08/18 ----------------->>>>>
    //明細貼付関数定義
    TxMAHNB01013B_CopySlipDetail = function(
    salesRowNo: Integer)
    : Integer; stdcall;
//-------------- ADD 連番729 2011/08/18 -----------------<<<<<

    //管理番号ガイド表示後の処理関数定義
    TxMAHNB01013B_AfterCarMngNoGuideReturn = function(status: Integer;
    selectedInfo: TCarMangInputExtraInfo;
    inputflag: Integer;
    salesRowNo: Integer;
    carMngCode: WideString;
    var returnFlag: Boolean;
    var clearCarInfoFlag: Boolean)
    : Integer; stdcall;

    //xxxx関数定義
    TxMAHNB01013B_setToolMenuCustomizeSetting = function(key: WideString)
    : Integer; stdcall;

    //xxxx関数定義
    TxMAHNB01013B_getToolMenuCustomizeSetting = function(var toolMenuCustomizeSettingNotNull: Boolean;
    var toolBarVisible: Boolean;
    var toolBarDockedRow: Integer;
    var toolBarDockedColumn: Integer;
    var toolBarDockedPosition: Integer)
    : Integer; stdcall;

    //xxxx関数定義
    TxMAHNB01013B_setToolButtonCustomizeSetting = function(key: WideString)
    : Integer; stdcall;

    //xxxx関数定義
    TxMAHNB01013B_getToolButtonCustomizeSetting = function(var toolButtonCustomizeSettingNotNull: Boolean;
    var toolBarCustomizedVisible: Integer)
    : Integer; stdcall;

    //xxxx関数定義
    TxMAHNB01013B_SaveToolbarCustomizeSetting = function(key: WideString;
    visible: Boolean)
    : Integer; stdcall;

    //xxxx関数定義
    TxMAHNB01013B_SaveToolManagerCustomizeInfo = function(key: WideString;
    visible: Boolean;
    dockedRow: Integer;
    dockedColumn: Integer;
    dockedPosition: Integer)
    : Integer; stdcall;

    //xxxx関数定義
    TxMAHNB01013B_SaveCustomizeXml = function()
    : Integer; stdcall;

    //xxxx関数定義
    TxMAHNB01013B_GetUltraOptionSetValue = function()
    : Integer; stdcall;

    TxMAHNB01013B_SlipNoteGuide = function(salesRowNo: Integer)
    : Integer; stdcall;

    //売上金額変更後発生イベント処理関数定義
    TxMAHNB01013B_SalesPriceChanged = function()
    : Integer; stdcall;

    //車両情報設定処理関数定義
    TxMAHNB01013B_CarInfoFormSetting = function(salesRowNo: Integer;
    var isGoodsFlg: Boolean;
    var carInfoRowFlg: Boolean)
    : Integer; stdcall;

    //保存確認ダイアログ表示処理関数定義
    // --- UPD m.suzuki 2010/06/12 ---------->>>>>
    //TxMAHNB01013B_ShowRedSaveCheckDialog = function(isConfirm: Boolean;
    //var afterSaveClearFlg: Boolean)
    //: Integer; stdcall;
    TxMAHNB01013B_ShowRedSaveCheckDialog = function(isConfirm: Boolean;
    var afterSaveClearFlg: Boolean; var isMakeQR: Boolean)
    : Integer; stdcall;
    // --- UPD m.suzuki 2010/06/12 ----------<<<<<

// add by gaofeng end

// add by lizc begin
//最新情報処理関数定義
    TxMAHNB01013B_ReNewalBtnClick = function(enterpriseCode: WideString;
    loginSectionCode: WideString)
    : Integer; stdcall;

    //xxxxx関数定義
    TxMAHNB01013B_ProcessingDialogDispose = function()
    : Integer; stdcall;
// add by lizc end

    // add by tanh begin
    //明細データ取得関数定義
    TxMAHNB01013B_GetSalesDetailDataTable = function(var salesDetailList: TSalesSlipInputCustomArrayA2;
    salesRowNo: Integer)
    : Integer; stdcall;

    //設定処理関数定義
    TxMAHNB01013B_SetSalesDetailData = function(inputdata: WideString;
    inputType: Integer)
    : Integer; stdcall;

    //>>>2010/05/30
    //SCM問合せ一覧選択関数定義
    TxMAHNB01013B_ReferenceList = function(isDataChanged: Boolean;
    var isSave: Integer)
    : Integer; stdcall;
    //----- ADD　2018/09/04 譚洪　履歴自動表示の対応------->>>>>   
    //履歴検索選択関数定義
    TxMAHNB01013B_HisSearch = function(salesRowNo: Integer)
    : Integer; stdcall;
    //----- ADD　2018/09/04 譚洪　履歴自動表示の対応-------<<<<<
    //----- ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応------->>>>>
    //税率入力関数定義
    TxMAHNB01013B_GetTaxRate = function()
    : Integer; stdcall;
    
    TxMAHNB01013B_GetTaxRateDialogResult = function(var taxRateDialogResult: Integer)
    : Integer; stdcall;

    TxMAHNB01013B_OrderCheck = function(mode: Integer; var orderFlg: Boolean)
    : Integer; stdcall;
    //----- ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応-------<<<<<
    // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応 ----->>>>>
    TxMAHNB01013B_StartEBooks = function()
    : Integer; stdcall;
    // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応 -----<<<<<
    //起動パラメータ設定処理関数定義
// 2011/01/31 >>>
//    TxMAHNB01013B_SettingParameter = function(param1: WideString;
//    param2: WideString)
    TxMAHNB01013B_SettingParameter =
        function(
        param1: WideString;
        param2: WideString;
        param3: WideString
        )
// 2011/01/31 <<<
    : Integer; stdcall;
    //SCM情報読込タイマー起動イベント処理関数定義
    TxMAHNB01013B_TimerSCMReadTick = function(var ret: Boolean; var customerCode: Integer)
    : Integer; stdcall;
    //相場価格情報取得処理関数定義
    TxMAHNB01013B_GetSobaInfo = function()
    : Integer; stdcall;
    //<<<2010/05/30

    //>>>2010/08/30
    //相場価格情報取得処理関数定義
    TxMAHNB01013B_ExistTaxRateRangeMethod = function(salesdate: Integer)
    : Integer; stdcall;
    //<<<2010/08/30

    //>>>2011/02/01
    //SCM情報存在チェック
    TxMAHNB01013B_ExistSCMInfo = function(var ret: Boolean; salesSlipNum:WideString; salesRowNo:Integer)
    : Integer; stdcall;
    //<<<2011/02/01

    //>>>2011/03/04
    //SCM情報存在チェック
    TxMAHNB01013B_SettingEmpInfo = procedure(); stdcall;
    //<<<2011/03/04

    // --- ADD 2010/05/31 ---------->>>>>
    //ESC処理関数定義
    TxMAHNB01013B_uButtonEscClick = function(var escFlg: Boolean)
    : Integer; stdcall;
    // --- ADD 2010/05/31 ----------<<<<<
    // add by tanh end

    // --- ADD 2012/05/31 No.282---------->>>>>
    //発注解除処理関数定義
    TxMAHNB01013B_uButtonEscClick2 = function(var escFlg: Boolean)
    : Integer; stdcall;
    //発注退避処理関数定義
    TxMAHNB01013B_SaveOrderInfo = function(var escFlg: Boolean)
    : Integer; stdcall;
    // --- ADD 2012/05/31 No.282----------<<<<<

    // --- ADD m.suzuki 2010/06/12 ---------->>>>>
    // QR作成スレッド起動処理
    // public void MakeQR()
    TxMAHNB01013B_MakeQR = procedure( sParam: WideString ); stdcall;
    // --- ADD m.suzuki 2010/06/12 ----------<<<<<
    // --- ADD m.suzuki 2010/06/16 ---------->>>>>
    // オンラインフラグ取得処理
    TxMAHNB01013B_GetOnlineFlag = function() : Boolean; stdcall;
    // --- ADD m.suzuki 2010/06/16 ----------<<<<<

// ------  ADD K2015/04/01 高騁 森川部品個別依頼------->>>>>
    //全拠点在庫情報一覧関数定義
    TxMAHNB01013B_ReadAllSecStockInfo = function(makerCd: Integer;
    goodsNo: WideString;
    goodsName: WideString;
    isOpenPressed: Boolean;
    isClosed: Boolean;
    var message: WideString)
    : Integer; stdcall;

    //森川個別オプション判定関数定義
    TxMAHNB01013B_OptPermitForMoriKawa = function(var optPermitForMoriKawa: Boolean)
    : Integer; stdcall;
// ------  ADD K2015/04/01 高騁 森川部品個別依頼------->>>>>

    // --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- >>>>>
    TxMAHNB01013B_OptPermitForKoei = function(var optPermitForKoei: Boolean)
    : Integer; stdcall;

    //売価算出処理関数定義
    TxMAHNB01013B_SalesUnPrcCalc = function(salesRowNo: Integer; var salesUnPrice: WideString)
    : Integer; stdcall;
    // --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- <<<<<

// 呼び出しＰＧは以下の関数をＰＧの開始と終わりに呼びます。
function LoadLibraryMAHNB01013B(HDllCALL1: THDLLCALL): Integer;
procedure FreeLibraryMAHNB01013B(HDllCALL1: THDLLCALL);
procedure ClearTSalesSlipSearchResult(var h_SalesSlipSearchResult: TSalesSlipSearchResult);
procedure ClearTCustomerSearchRet(var h_CustomerSearchRet: TCustomerSearchRet);
procedure ClearTSalesSlipHeaderCopyData(var h_SalesSlipHeaderCopyData: TSalesSlipHeaderCopyData);

// add by yangmj
//procedure ClearTSalesSlip(var h_SalesSlip: TSalesSlip);
// end add by yangmj

var
    //関数ポインタ宣言
    // add by tanh
    gpxMAHNB01013B_Clear : TxMAHNB01013B_Clear;
    gpxMAHNB01013B_GetItemtSalesSlipCd : TxMAHNB01013B_GetItemtSalesSlipCd;
    gpxMAHNB01013B_GetAddInfoVisible : TxMAHNB01013B_GetAddInfoVisible;
    gpxMAHNB01013B_GetDisplayHeaderFooterInfo : TxMAHNB01013B_GetDisplayHeaderFooterInfo;
    gpxMAHNB01013B_GetNoteGuidList : TxMAHNB01013B_GetNoteGuidList;
    gpxMAHNB01013B_GetGrossProfitRateFlg : TxMAHNB01013B_GetGrossProfitRateFlg;
    //関数ポインタ宣言
    gpxMAHNB01013B_GetDisplayCustomerInfo : TxMAHNB01013B_GetDisplayCustomerInfo;
    //関数ポインタ宣言
    gpxMAHNB01013B_InitMstCheck : TxMAHNB01013B_InitMstCheck;
    //関数ポインタ宣言
    gpxMAHNB01013B_SetUserGdBdComboEditor : TxMAHNB01013B_SetUserGdBdComboEditor;
    gpxMAHNB01013B_GetCellEnabled : TxMAHNB01013B_GetCellEnabled;
    gpxMAHNB01013B_Retry : TxMAHNB01013B_Retry;
    gpxMAHNB01013B_RetryResult : TxMAHNB01013B_RetryResult;
    gpxMAHNB01013B_Close : TxMAHNB01013B_Close;
    // --- ADD 2010/05/31 ---------->>>>>
    //関数ポインタ宣言
    gpxMAHNB01013B_uButtonEscClick : TxMAHNB01013B_uButtonEscClick;
    // --- ADD 2010/05/31 ----------<<<<<
    // --- ADD 2012/05/31 No.282---------->>>>>
    //関数ポインタ宣言（発注解除）
    gpxMAHNB01013B_uButtonEscClick2 : TxMAHNB01013B_uButtonEscClick2;
    //関数ポインタ宣言（発注退避）
    gpxMAHNB01013B_SaveOrderInfo : TxMAHNB01013B_SaveOrderInfo;
    // --- ADD 2012/05/31 No.282----------<<<<<
    // --- ADD 黄興貴 2015/04/29 回答取込パタン追加 ---------------->>>>>
    gpxMAHNB01013B_ReadUoeData : TxMAHNB01013B_ReadUoeData;
    gpxMAHNB01013B_OptPermitForFuJi : TxMAHNB01013B_OptPermitForFuJi;
    // --- ADD 黄興貴 2015/04/29 回答取込パタン追加 ----------------<<<<<

    // --- ADD 紀飛 2015/06/18 WebUOE発注回答取込 ---------------->>>>>
    //関数ポインタ宣言（WebUOE発注回答取込）
    gpxMAHNB01013B_OptPermitForMeiGo : TxMAHNB01013B_OptPermitForMeiGo;
    // --- ADD 紀飛 2015/06/18 WebUOE発注回答取込 ----------------<<<<<
    // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応--->>>>>
    //関数ポインタ宣言（電帳.DX）
    gpxMAHNB01013B_OptPermitForEBooks : TxMAHNB01013B_OptPermitForEBooks;
    // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応---<<<<<
    //関数ポインタ宣言
    gpxMAHNB01013B_FormPosSerialize : TxMAHNB01013B_FormPosSerialize;
    //関数ポインタ宣言
    gpxMAHNB01013B_FormPosDeserialize : TxMAHNB01013B_FormPosDeserialize;
    gpxMAHNB01013B_GetBitButtonCustomizeSetting : TxMAHNB01013B_GetBitButtonCustomizeSetting;
    gpxMAHNB01013B_SmallPointProc : TxMAHNB01013B_SmallPointProc;
    // end add by tanh

    //関数ポインタ宣言
    gpxMAHNB01013B_SetInitData : TxMAHNB01013B_SetInitData;

    // --- ADD 2011/02/12 ---------->>>>>
    //関数ポインタ宣言
    gpxMAHNB01013B_DoAddLine : TxMAHNB01013B_DoAddLine;
    gpxMAHNB01013B_DoCacheImage : TxMAHNB01013B_DoCacheImage;
    gpxMAHNB01013B_GetErrorFlag : TxMAHNB01013B_GetErrorFlag;
    // --- ADD 2011/02/12 ----------<<<<<

    gpxMAHNB01013B_CooprtKindDiv : TxMAHNB01013B_CooprtKindDiv; // ADD 2011/11/22

    // --- ADD 2011/04/13 ---------->>>>>
    //関数ポインタ宣言
    gpxMAHNB01013B_DetailDeleteActionTable : TxMAHNB01013B_DetailDeleteActionTable;
    // --- ADD 2011/04/13 ----------<<<<<

    // --- ADD 2011/05/30 ---------->>>>>
    //関数ポインタ宣言
    gpxMAHNB01013B_SetSectionCode : TxMAHNB01013B_SetSectionCode;
    // --- ADD 2011/05/30 ----------<<<<<

    // --- ADD 2011/07/18 ---------->>>>>
    //関数ポインタ宣言
    gpxMAHNB01013B_StockInfoAdjust : TxMAHNB01013B_StockInfoAdjust;
    // --- ADD 2011/07/18 ----------<<<<<

    // add by zhangkai
    gpxMAHNB01013B_uButtonGuideClick : TxMAHNB01013B_uButtonGuideClick;
    gpxMAHNB01013B_GetNextMovePosition : TxMAHNB01013B_GetNextMovePosition;
    // --- ADD 2010/06/02 ---------->>>>>
    gpxMAHNB01013B_GetPreMovePosition : TxMAHNB01013B_GetPreMovePosition;
    // --- ADD 2010/06/02 ----------<<<<<
    gpxMAHNB01013B_GetParam : TxMAHNB01013B_GetParam;
    gpxMAHNB01013B_GetEffectiveJudgment : TxMAHNB01013B_GetEffectiveJudgment;
    gpxMAHNB01013B_GetSalesDetailDataTable : TxMAHNB01013B_GetSalesDetailDataTable;
    gpxMAHNB01013B_GetSalesAllDetailDataTable : TxMAHNB01013B_GetSalesAllDetailDataTable;
    gpxMAHNB01013B_SetSalesDetailData : TxMAHNB01013B_SetSalesDetailData;
    gpxMAHNB01013B_AfterGoodsNoUpdate : TxMAHNB01013B_AfterGoodsNoUpdate;
    gpxMAHNB01013B_uButtonLineDiscountClick : TxMAHNB01013B_uButtonLineDiscountClick;
    gpxMAHNB01013B_uButtonGoodsDiscountClick : TxMAHNB01013B_uButtonGoodsDiscountClick;
    gpxMAHNB01013B_uButtonAnnotationClick : TxMAHNB01013B_uButtonAnnotationClick;
    gpxMAHNB01013B_uButtonChangeWarehouseClick : TxMAHNB01013B_uButtonChangeWarehouseClick;
    gpxMAHNB01013B_uButtonStockSearchClick : TxMAHNB01013B_uButtonStockSearchClick;
    gpxMAHNB01013B_uButtonTBOClick : TxMAHNB01013B_uButtonTBOClick;
    gpxMAHNB01013B_uButtonCopyStockBefLineClick : TxMAHNB01013B_uButtonCopyStockBefLineClick;
    gpxMAHNB01013B_uButtonCopyStockAllLineClick : TxMAHNB01013B_uButtonCopyStockAllLineClick;
    gpxMAHNB01013B_uGridDetailsAfterCellUpdate : TxMAHNB01013B_uGridDetailsAfterCellUpdate;
    gpxMAHNB01013B_uGridDetailsAfterCellUpdateProc : TxMAHNB01013B_uGridDetailsAfterCellUpdateProc;
    gpxMAHNB01013B_GridJoinCheck : TxMAHNB01013B_GridJoinCheck;
    gpxMAHNB01013B_DeatilActionTable : TxMAHNB01013B_DeatilActionTable;
    gpxMAHNB01013B_CheckDetailAction : TxMAHNB01013B_CheckDetailAction;
    gpxMAHNB01013B_GetSalesSlipInputConstructionData : TxMAHNB01013B_GetSalesSlipInputConstructionData;
    gpxMAHNB01013B_AfterPartySaleSlipNumFocus : TxMAHNB01013B_AfterPartySaleSlipNumFocus;
    gpxMAHNB01013B_retGoodsReason : TxMAHNB01013B_retGoodsReason;
    gpxMAHNB01013B_SetSlipMemo : TxMAHNB01013B_SetSlipMemo;
    gpxMAHNB01013B_KeyPressNumCheck : TxMAHNB01013B_KeyPressNumCheck;
    gpxMAHNB01013B_CsvPassCheck : TxMAHNB01013B_CsvPassCheck;
    gpxMAHNB01013B_SetHomeKeyFlg : TxMAHNB01013B_SetHomeKeyFlg;
    // end add by zhangkai

// add by yangmj
    gpxMAHNB01013B_ShipmentAddUp : TxMAHNB01013B_ShipmentAddUp;
    gpxMAHNB01013B_GetSalesHisGuide : TxMAHNB01013B_GetSalesHisGuide;
    gpxMAHNB01013B_AcceptAnOrderReferenceSearch : TxMAHNB01013B_AcceptAnOrderReferenceSearch;
    gpxMAHNB01013B_AcceptAnOrderAddup : TxMAHNB01013B_AcceptAnOrderAddup;
    gpxMAHNB01013B_EstimateReferenceSearch : TxMAHNB01013B_EstimateReferenceSearch;
    gpxMAHNB01013B_EstimateAddup : TxMAHNB01013B_EstimateAddup;
    gpxMAHNB01013B_SalesReferenceSearch : TxMAHNB01013B_SalesReferenceSearch;
    gpxMAHNB01013B_CopySlip : TxMAHNB01013B_CopySlip;
    gpxMAHNB01013B_GetOptCarMng : TxMAHNB01013B_GetOptCarMng;
    gpxMAHNB01013B_SetNoteCharCnt : TxMAHNB01013B_SetNoteCharCnt;
    gpxMAHNB01013B_ReturnSlip : TxMAHNB01013B_ReturnSlip;
    gpxMAHNB01013B_ShowSaveCheckDialog : TxMAHNB01013B_ShowSaveCheckDialog;
    gpxMAHNB01013B_Save : TxMAHNB01013B_Save;
    gpxMAHNB01013B_AfterSave : TxMAHNB01013B_AfterSave;
    gpxMAHNB01013B_GetSaveStatus : TxMAHNB01013B_GetSaveStatus;
    // --- ADD 2015/12/09 T.Miyamoto リモ伝障害対応 Redmine#47670 ---------->>>>>
    gpxMAHNB01013B_GetOnlineKindDiv : TxMAHNB01013B_GetOnlineKindDiv;
    // --- ADD 2015/12/09 T.Miyamoto リモ伝障害対応 Redmine#47670 ----------<<<<<
    gpxMAHNB01013B_ChangeSearchMode : TxMAHNB01013B_ChangeSearchMode;
    gpxMAHNB01013B_GetSearchPartsModeProperty : TxMAHNB01013B_GetSearchPartsModeProperty;
    //----ADD 2010/06/17----->>>>>
    gpxMAHNB01013B_SetSalesSlip : TxMAHNB01013B_SetSalesSlip;
    //----ADD 2010/06/17-----<<<<<
    //----ADD 2010/11/02----->>>>>
    gpxMAHNB01013B_SetSalesSlipByObj : TxMAHNB01013B_SetSalesSlipByObj;
    //----ADD 2010/11/02-----<<<<<

    gpxMAHNB01013B_SetAfterSaveData : TxMAHNB01013B_SetAfterSaveData;
    gpxMAHNB01013B_GetAfterSaveData : TxMAHNB01013B_GetAfterSaveData;
    gpxMAHNB01013B_DoAfterSave : TxMAHNB01013B_DoAfterSave;
    //----ADD 2012/10/15----->>>>>
    gpxMAHNB01013B_ShowStockDateMsg : TxMAHNB01013B_ShowStockDateMsg;
    //----ADD 2012/10/15-----<<<<<

    // --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ---------->>>>>
    //第二売価ガイドの位置を設定します。
    gpxMAHNB01013B_SetSecondSalesUnPrcGideLocation : TxMAHNB01013B_SetSecondSalesUnPrcGideLocation;
    //水野商工㈱オプション判定関数定義。
    gpxMAHNB01013B_OptPermitForMizuno2ndSellPriceCtl : TxMAHNB01013B_OptPermitForMizuno2ndSellPriceCtl;
    // --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ----------<<<<<

// end add by yangmj

// add by gaofeng start
    gpxMAHNB01013B_GetInitData : TxMAHNB01013B_GetInitData;
    gpxMAHNB01013B_salesSlipGuide : TxMAHNB01013B_salesSlipGuide;
    gpxMAHNB01013B_customerGuide : TxMAHNB01013B_customerGuide;
    gpxMAHNB01013B_ShowSalesSlipInputSetup : TxMAHNB01013B_ShowSalesSlipInputSetup;
    gpxMAHNB01013B_GetDisplayName : TxMAHNB01013B_GetDisplayName;
    gpxMAHNB01013B_GetDetailGrossProfitRate : TxMAHNB01013B_GetDetailGrossProfitRate;
    gpxMAHNB01013B_Delete : TxMAHNB01013B_Delete;
    gpxMAHNB01013B_GetItemName : TxMAHNB01013B_GetItemName;
    gpxMAHNB01013B_GetStatus : TxMAHNB01013B_GetStatus;
    gpxMAHNB01013B_GetBeforeSalesSlipNumText : TxMAHNB01013B_GetBeforeSalesSlipNumText;
    gpxMAHNB01013B_GetFocusPositionValue : TxMAHNB01013B_GetFocusPositionValue;
    gpxMAHNB01013B_RedSlip : TxMAHNB01013B_RedSlip;
    gpxMAHNB01013B_GetCanRed : TxMAHNB01013B_GetCanRed;
    gpxMAHNB01013B_GetRedDialogResult : TxMAHNB01013B_GetRedDialogResult;
    gpxMAHNB01013B_CopySlipHeader : TxMAHNB01013B_CopySlipHeader;
    gpxMAHNB01013B_CopySlipDetail : TxMAHNB01013B_CopySlipDetail;   // ADD 連番927 2011/08/18
    gpxMAHNB01013B_AfterCarMngNoGuideReturn : TxMAHNB01013B_AfterCarMngNoGuideReturn;
    gpxMAHNB01013B_setToolMenuCustomizeSetting : TxMAHNB01013B_setToolMenuCustomizeSetting;
    gpxMAHNB01013B_getToolMenuCustomizeSetting : TxMAHNB01013B_getToolMenuCustomizeSetting;
    gpxMAHNB01013B_setToolButtonCustomizeSetting : TxMAHNB01013B_setToolButtonCustomizeSetting;
    gpxMAHNB01013B_getToolButtonCustomizeSetting : TxMAHNB01013B_getToolButtonCustomizeSetting;
    gpxMAHNB01013B_SaveToolbarCustomizeSetting : TxMAHNB01013B_SaveToolbarCustomizeSetting;
    gpxMAHNB01013B_SaveToolManagerCustomizeInfo : TxMAHNB01013B_SaveToolManagerCustomizeInfo;
    gpxMAHNB01013B_SaveCustomizeXml : TxMAHNB01013B_SaveCustomizeXml;
    gpxMAHNB01013B_GetUltraOptionSetValue : TxMAHNB01013B_GetUltraOptionSetValue;
    gpxMAHNB01013B_SlipNoteGuide : TxMAHNB01013B_SlipNoteGuide;
    gpxMAHNB01013B_SalesPriceChanged : TxMAHNB01013B_SalesPriceChanged;
    gpxMAHNB01013B_CarInfoFormSetting : TxMAHNB01013B_CarInfoFormSetting;
    gpxMAHNB01013B_ShowRedSaveCheckDialog : TxMAHNB01013B_ShowRedSaveCheckDialog;
    gpxMAHNB01013B_SetItemsDictionary : TxMAHNB01013B_SetItemsDictionary;
    gpxMAHNB01013B_setColDisplayStatusList : TxMAHNB01013B_setColDisplayStatusList;

    // --- ADD 2010/06/02 ---------->>>>>
    gpxMAHNB01013B_GetReadSlipFlg : TxMAHNB01013B_GetReadSlipFlg;
    // --- ADD 2010/06/02----------<<<<<

    // --- ADD 2010/07/08 ---------->>>>>
    gpxMAHNB01013B_BeginControllingByOperationAuthority : TxMAHNB01013B_BeginControllingByOperationAuthority;
    // --- ADD 2010/07/08 ----------<<<<<

// add by gaofeng end

    // --- ADD 2014/07/15 T.Miyamoto 仕掛一覧 №1912 ---------->>>>>
    gpxMAHNB01013B_GetOperationSt : TxMAHNB01013B_GetOperationSt;
    // --- ADD 2014/07/15 T.Miyamoto 仕掛一覧 №1912 ----------<<<<<

// add by lizc begin
    gpxMAHNB01013B_ReNewalBtnClick : TxMAHNB01013B_ReNewalBtnClick;
    gpxMAHNB01013B_ProcessingDialogDispose : TxMAHNB01013B_ProcessingDialogDispose;
// add by lizc end

//>>>2010/05/30
    gpxMAHNB01013B_ReferenceList : TxMAHNB01013B_ReferenceList;
    gpxMAHNB01013B_HisSearch : TxMAHNB01013B_HisSearch;// ADD　2018/09/04 譚洪　履歴自動表示の対応
    // ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応 ------>>>>>
    gpxMAHNB01013B_GetTaxRateDialogResult : TxMAHNB01013B_GetTaxRateDialogResult;
    gpxMAHNB01013B_GetTaxRate : TxMAHNB01013B_GetTaxRate;
    gpxMAHNB01013B_OrderCheck : TxMAHNB01013B_OrderCheck;
    // ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応 ------<<<<<
    gpxMAHNB01013B_StartEBooks : TxMAHNB01013B_StartEBooks; //ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応
    gpxMAHNB01013B_SettingParameter : TxMAHNB01013B_SettingParameter;
    gpxMAHNB01013B_TimerSCMReadTick : TxMAHNB01013B_TimerSCMReadTick;
    gpxMAHNB01013B_GetSobaInfo : TxMAHNB01013B_GetSobaInfo;
//<<<2010/05/30

//>>>2010/08/30
    gpxMAHNB01013B_ExistTaxRateRangeMethod : TxMAHNB01013B_ExistTaxRateRangeMethod;
//<<<2010/08/30

//>>>2011/02/01
    gpxMAHNB01013B_ExistSCMInfo : TxMAHNB01013B_ExistSCMInfo;
//<<<2011/02/01

//>>>2011/03/04
    gpxMAHNB01013B_SettingEmpInfo : TxMAHNB01013B_SettingEmpInfo;
//<<<2011/03/04

    // --- ADD m.suzuki 2010/06/12 ---------->>>>>
    //関数ポインタ宣言
    gpxMAHNB01013B_MakeQR : TxMAHNB01013B_MakeQR;
    // --- ADD m.suzuki 2010/06/12 ----------<<<<<
    // --- ADD m.suzuki 2010/06/16 ---------->>>>>
    gpxMAHNB01013B_GetOnlineFlag : TxMAHNB01013B_GetOnlineFlag;
    // --- ADD m.suzuki 2010/06/16 ----------<<<<<
// ------  ADD K2015/04/01 高騁 森川部品個別依頼------->>>>>
    gpxMAHNB01013B_ReadAllSecStockInfo : TxMAHNB01013B_ReadAllSecStockInfo;
    gpxMAHNB01013B_OptPermitForMoriKawa : TxMAHNB01013B_OptPermitForMoriKawa;
// ------  ADD K2015/04/01 高騁 森川部品個別依頼------->>>>>

    // --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- >>>>>
    gpxMAHNB01013B_OptPermitForKoei : TxMAHNB01013B_OptPermitForKoei;
    gpxMAHNB01013B_SalesUnPrcCalc : TxMAHNB01013B_SalesUnPrcCalc;
    // --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- <<<<<

implementation

// **********************************************************************//
// Module Name     :  得意先部品ロード関数                            //
// :  LoadLibraryMAHNB01013B                            //
// 引数            :  １．HDLLCALL                                      //
// 戻り値          :  ステータス ctFNC_NORMAL : 成功                    //
// :             ctFNC_ERROR  : 失敗                    //
// Programer       :  自動生成                                            //
// Date            :  2010.04.01                                          //
// Note            :  得意先部品ロードします                          //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
// **********************************************************************//
function LoadLibraryMAHNB01013B(HDllCALL1: THDLLCALL): Integer;
var
    nSt: Integer;
begin
    Result := 4;
    HDllCALL1.DllName := 'MAHNB01013B.DLL';
    nSt := HDllCALL1.HLoadLibrary;

    //DLLロード
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '得意先部品',
            'LoadLibraryMAHNB01013B', 'LOADLIBRARY', '得意先部品のロードに失敗しました', nSt,
            nil, 0);
        Exit;
    end;


// add by tanh
    // --- ADD 2010/05/31 ---------->>>>>
    //オプション情報処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_uButtonEscClick';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_uButtonEscClick);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', 'ESC処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'ESC処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2012/05/31 No.282---------->>>>>
    //発注解除処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_uButtonEscClick2';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_uButtonEscClick2);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '発注解除処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '発注解除処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    //発注退避処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_SaveOrderInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_SaveOrderInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '発注退避処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '発注退避処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2012/05/31 No.282----------<<<<<

    //フォーム情報処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_FormPosSerialize';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_FormPosSerialize);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', 'フォーム',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'フォーム情報処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //オプション情報処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetGrossProfitRateFlg';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetGrossProfitRateFlg);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '車種部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '車種部品オプション情報処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //HOMEキー設定処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_SetHomeKeyFlg';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_SetHomeKeyFlg);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '得意先部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '得意先部品HOMEキー設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // --- ADD 2011/02/12 ---------->>>>>
    //調査用ログ出力クラス処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_DoAddLine';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_DoAddLine);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '調査用ログ',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '調査用ログ出力クラス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //調査用ログImage出力処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_DoCacheImage';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_DoCacheImage);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '調査用ログImage出力',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '調査用ログImage出力処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2011/02/12 ----------<<<<<

    // --- ADD 黄興貴 2015/04/29 回答取込パタン追加 ---------------->>>>>
     //UOEデータ取込関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_ReadUoeData';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_ReadUoeData);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', 'UOEデータ取込',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'UOEデータ取込関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    //富士ジーワイ商事㈱オプション判定関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_OptPermitForFuJi';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_OptPermitForFuJi);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', 'UOEデータ取込',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '富士ジーワイ商事㈱オプション判定関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 黄興貴 2015/04/29 回答取込パタン追加 ----------------<<<<<

    // --- ADD 紀飛 2015/06/18 WebUOE発注回答取込 ---------------->>>>>
    //㈱メイゴオプション判定関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_OptPermitForMeiGo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_OptPermitForMeiGo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', 'UOEデータ取込',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '㈱メイゴオプション判定関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 紀飛 2015/06/18 WebUOE発注回答取込 ----------------<<<<<
    /// --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応--->>>>>
    //電子帳簿連携オプション判定関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_OptPermitForEBooks';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_OptPermitForEBooks);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '電子帳簿',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '電子帳簿連携オプション判定関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応---<<<<<

    //---ADD 2011/11/22 ----------------------->>>>>
    //連携判断処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_CooprtKindDiv';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_CooprtKindDiv);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '連携判断',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '連携判断処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    //---ADD 2011/11/22 -----------------------<<<<<



    // --- ADD 2011/04/13 ---------->>>>>
    //選択済み売上行番号削除処理（多行削除場合用）関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_DetailDeleteActionTable';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_DetailDeleteActionTable);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '多行削除',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '選択済み売上行番号削除処理（多行削除場合用）関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2011/04/13 ----------<<<<<

    // --- ADD 2011/05/30 ---------->>>>>
    //画面の拠点コード変化時（キャンペーン情報取得用）関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_SetSectionCode';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_SetSectionCode);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '拠点コード変化',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '画面の拠点コード変化時（キャンペーン情報取得用）関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2011/05/30 ----------<<<<<

    // --- ADD 2011/07/18 ---------->>>>>
    //現在庫数を調整します関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_StockInfoAdjust';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_StockInfoAdjust);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '現在庫数調整',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '現在庫数を調整します関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2011/07/18 ----------<<<<<

    //フォーム情報処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_FormPosDeserialize';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_FormPosDeserialize);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '車種部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'フォーム情報処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //各種マスタチェック関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetErrorFlag';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetErrorFlag);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '車種部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '車種部品各種マスタチェック関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // --- ADD 2010/05/31 ----------<<<<<
    //品番検索処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_AfterGoodsNoUpdate';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_AfterGoodsNoUpdate);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '品番検索部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '品番検索部品品番検索処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //行値引き処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_uButtonLineDiscountClick';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_uButtonLineDiscountClick);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '行値引',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '行値引処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //得意先ガイド処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_Clear';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_Clear);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '得意先部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '得意先部品得意先ガイド処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //伝票区分コンボエディタアイテム設定処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetItemtSalesSlipCd';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetItemtSalesSlipCd);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '得意先部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '得意先部品伝票区分コンボエディタアイテム設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //得意先情報画面格納処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetDisplayCustomerInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetDisplayCustomerInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '車種部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '車種部品得意先情報画面格納処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //各種マスタチェック関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_InitMstCheck';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_InitMstCheck);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '車種部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '車種部品各種マスタチェック関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //追加情報タブ項目Visible設定関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetAddInfoVisible';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetAddInfoVisible);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '得意先部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '得意先部品追加情報タブ項目Visible設定関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //小数点表示区分処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_SmallPointProc';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_SmallPointProc);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '小数点表示区分',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '小数点表示区分処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //伝票区分コンボエディタアイテム設定処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetDisplayHeaderFooterInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetDisplayHeaderFooterInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '得意先部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '得意先部品伝票区分コンボエディタアイテム設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //明細データ取得関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_SetUserGdBdComboEditor';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_SetUserGdBdComboEditor);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '品番検索部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '品番検索部品明細データ取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //ファンクション明細制御取得処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetBitButtonCustomizeSetting';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetBitButtonCustomizeSetting);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', 'ファンクション明細制御',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'ファンクション明細制御取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //明細データ取得関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetSalesDetailDataTable';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetSalesDetailDataTable);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '明細データ取得',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '明細データ取得関数アドレス取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //明細データ取得関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetSalesAllDetailDataTable';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetSalesAllDetailDataTable);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '明細データ取得',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '明細データ取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //商品値引き処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_uButtonGoodsDiscountClick';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_uButtonGoodsDiscountClick);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '商品値引き処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '商品値引き処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //注釈処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_uButtonAnnotationClick';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_uButtonAnnotationClick);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '注釈処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '注釈処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //倉庫切替処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_uButtonChangeWarehouseClick';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_uButtonChangeWarehouseClick);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '倉庫切替処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '倉庫切替処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //在庫検索処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_uButtonStockSearchClick';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_uButtonStockSearchClick);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '在庫検索処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '在庫検索処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //ＴＢＯ処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_uButtonTBOClick';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_uButtonTBOClick);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', 'ＴＢＯ処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'ＴＢＯ処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //前行複写処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_uButtonCopyStockBefLineClick';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_uButtonCopyStockBefLineClick);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '前行複写処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '前行複写処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //一括複写処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_uButtonCopyStockAllLineClick';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_uButtonCopyStockAllLineClick);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '一括複写処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '一括複写処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //グリッドセルアップデート後処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_uGridDetailsAfterCellUpdate';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_uGridDetailsAfterCellUpdate);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', 'グリッドセルアップデート後処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'グリッドセルアップデート後処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //グリッドセルアップデート後処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_uGridDetailsAfterCellUpdateProc';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_uGridDetailsAfterCellUpdateProc);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', 'グリッドセルアップデート後処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'グリッドセルアップデート後処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //グリッド関連チェック処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GridJoinCheck';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GridJoinCheck);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', 'グリッド関連チェック処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'グリッド関連チェック処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //Table処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_DeatilActionTable';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_DeatilActionTable);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', 'Table処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'Table処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //ユーザー設定処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetSalesSlipInputConstructionData';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetSalesSlipInputConstructionData);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', 'ユーザー設定処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'ユーザー設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //得意先注番のフォーカス処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_AfterPartySaleSlipNumFocus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_AfterPartySaleSlipNumFocus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '得意先注番',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '得意先注番のフォーカス処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //設定処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_SetSalesDetailData';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_SetSalesDetailData);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '設定処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //備考設定処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetNoteGuidList';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetNoteGuidList);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '得意先部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '得意先部品備考設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //セルEnabled設定取得処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetCellEnabled';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetCellEnabled);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '品番検索部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '品番検索部品セルEnabled設定取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //元に戻す処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_Retry';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_Retry);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '車種部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '車種部品元に戻す処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //元に戻す処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_RetryResult';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_RetryResult);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '車種部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '車種部品元に戻す処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //終了設定処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_Close';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_Close);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '得意先部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '得意先部品終了設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
// end add by tanh

// add by zhangkai

    //ガイドボタンクリックイベント処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_uButtonGuideClick';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_uButtonGuideClick);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '品番検索部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '品番検索部品ガイドボタンクリックイベント処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //移動位置取得処理(Enterキー移動時)関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetNextMovePosition';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetNextMovePosition);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '品番検索部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '品番検索部品移動位置取得処理(Enterキー移動時)関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // --- ADD 2010/06/02 ---------->>>>>
    //移動位置取得処理(Enterキー移動時)関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetPreMovePosition';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetPreMovePosition);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '品番検索部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '品番検索部品移動位置取得処理(Enterキー移動時)関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2010/06/02 ----------<<<<<

    //Param取得処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetParam';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetParam);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '品番検索部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '品番検索部品Param取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //フォーカス移動対象判定処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetEffectiveJudgment';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetEffectiveJudgment);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '品番検索部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '品番検索部品フォーカス移動対象判定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //チェック処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_CheckDetailAction';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_CheckDetailAction);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', 'チェック処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'チェック処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //返品理由ガイド処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_retGoodsReason';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_retGoodsReason);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '返品理由ガイド操作',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '返品理由ガイド操作処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //伝票メモ情報設定処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_SetSlipMemo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_SetSlipMemo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '品番検索部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '品番検索部品伝票メモ情報設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //数値入力チェック処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_KeyPressNumCheck';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_KeyPressNumCheck);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '品番検索部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '品番検索部品数値入力チェック処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //CSV出力先が設定され、フォルダが存在しているかチェック処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_CsvPassCheck';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_CsvPassCheck);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '品番検索部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '品番検索部品CSV出力先が設定され、フォルダが存在しているかチェック処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

// end add by zhangkai

// add by yangmj
    //出荷計上処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_ShipmentAddUp';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_ShipmentAddUp);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '出荷照会部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '出荷照会部品出荷計上処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //出荷照会ボタンクリック処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetSalesHisGuide';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetSalesHisGuide);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '出荷照会部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '出荷照会部品出荷照会ボタンクリック処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //受注照会(明細選択)関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_AcceptAnOrderReferenceSearch';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_AcceptAnOrderReferenceSearch);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '出荷照会部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '出荷照会部品受注照会(明細選択)関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //受注計上処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_AcceptAnOrderAddup';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_AcceptAnOrderAddup);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '出荷照会部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '出荷照会部品受注計上処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //見積計上(明細選択)関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_EstimateReferenceSearch';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_EstimateReferenceSearch);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '出荷照会部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '出荷照会部品見積計上(明細選択)関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //見積照会(伝票選択)関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_EstimateAddup';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_EstimateAddup);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '出荷照会部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '出荷照会部品見積照会(伝票選択)関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //履歴照会(売上履歴データから明細選択) 関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_SalesReferenceSearch';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_SalesReferenceSearch);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '出荷照会部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '出荷照会部品履歴照会(売上履歴データから明細選択) 関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //伝票複写関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_CopySlip';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_CopySlip);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '出荷照会部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '出荷照会部品伝票複写関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //車両管理オプション取得処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetOptCarMng';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetOptCarMng);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '出荷照会部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '出荷照会部品車両管理オプション取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //伝票備考、伝票備考２、伝票備考３の入力桁数設定処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_SetNoteCharCnt';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_SetNoteCharCnt);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '出荷照会部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '出荷照会部品伝票備考、伝票備考２、伝票備考３の入力桁数設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //返品処理関係関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_ReturnSlip';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_ReturnSlip);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '出荷照会部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '出荷照会部品返品処理関係関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //保存確認ダイアログ表示処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_ShowSaveCheckDialog';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_ShowSaveCheckDialog);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '出荷照会部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '出荷照会部品保存確認ダイアログ表示処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //保存処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_Save';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_Save);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '出荷照会部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '出荷照会部品保存処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //保存後処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_AfterSave';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_AfterSave);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '出荷照会部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '出荷照会部品保存後処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //保存状態取得関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetSaveStatus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetSaveStatus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '出荷照会部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '出荷照会部品保存状態取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // --- ADD 2015/12/09 T.Miyamoto リモ伝障害対応 Redmine#47670 ---------->>>>>
    //オンライン種別取得関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetOnlineKindDiv';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetOnlineKindDiv);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '出荷照会部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '出荷照会部品オンライン種別取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2015/12/09 T.Miyamoto リモ伝障害対応 Redmine#47670 ----------<<<<<

     //部品検索切替処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_ChangeSearchMode';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_ChangeSearchMode);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '出荷照会部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '出荷照会部品部品検索切替処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //部品検索モード取得関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetSearchPartsModeProperty';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetSearchPartsModeProperty);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '出荷照会部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '出荷照会部品部品検索モード取得関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
     //----ADD 2010/06/17----->>>>>
    //売上データ設定関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_SetSalesSlip';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_SetSalesSlip);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '出荷照会部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '出荷照会部品売上データ設定関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
   //----ADD 2010/06/17-----<<<<<
   //----ADD 2010/11/02----->>>>>
   //売上データ設定関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_SetSalesSlipByObj';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_SetSalesSlipByObj);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '出荷照会部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '出荷照会部品売上データ設定関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    //----ADD 2010/11/02-----<<<<<
// end add by yangmj

// add by gaofeng start

  //初期データをＤＢより取得の処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetInitData';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetInitData);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '初期データ取得操作',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '初期データ取得操作の処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //売上伝票ガイド処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_salesSlipGuide';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_salesSlipGuide);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '売上伝票ガイド操作',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '売上伝票ガイド操作の処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //得意先ガイド処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_customerGuide';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_customerGuide);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '得意先ガイド操作',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '得意先ガイド操作の処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //設定処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_ShowSalesSlipInputSetup';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_ShowSalesSlipInputSetup);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '設定操作',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '設定操作の処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //画面項目名称取得処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetDisplayName';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetDisplayName);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '画面項目名称取得操作',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '画面項目名称取得操作の処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //明細粗利率取得処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetDetailGrossProfitRate';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetDetailGrossProfitRate);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '明細粗利率取得',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '明細粗利率取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //削除処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_Delete';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_Delete);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '削除処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '削除処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //アイテム名の取得処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetItemName';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetItemName);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', 'アイテム名の取得処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'アイテム名の取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //状態の取得処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetStatus';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetStatus);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '状態の取得処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '状態の取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //名称の取得処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetBeforeSalesSlipNumText';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetBeforeSalesSlipNumText);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '名称の取得処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '名称の取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //フォーカス位置の取得処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetFocusPositionValue';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetFocusPositionValue);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', 'フォーカス位置の取得処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'フォーカス位置の取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //赤伝処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_RedSlip';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_RedSlip);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '赤伝処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '赤伝処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //赤伝できるかどうかフラグの取得処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetCanRed';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetCanRed);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '赤伝できるかどうかフラグの取得処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '赤伝できるかどうかフラグの取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //各種起動データ関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_SetInitData';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_SetInitData);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '起動データ',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '各種起動データ関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    HDllCALL1.ProcName := 'MAHNB01013B_GetRedDialogResult';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetRedDialogResult);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', 'ダイアログの取得処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'ダイアログの取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //見出貼付関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_CopySlipHeader';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_CopySlipHeader);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '見出貼付',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '見出貼付関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

// ----------------- ADD 連番729 2011/08/18 -------------->>>>>
    //明細貼付関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_CopySlipDetail';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_CopySlipDetail);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '明細貼付',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '明細貼付関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
// ----------------- ADD 連番729 2011/08/18 --------------<<<<<

    //管理番号ガイド表示後の処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_AfterCarMngNoGuideReturn';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_AfterCarMngNoGuideReturn);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '管理番号ガイド表示後',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '管理番号ガイド表示後の処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //xxxx関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_setToolMenuCustomizeSetting';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_setToolMenuCustomizeSetting);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', 'setToolMenuCustomizeSetting関数',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'setToolMenuCustomizeSetting関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //xxxx関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_getToolMenuCustomizeSetting';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_getToolMenuCustomizeSetting);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', 'getToolMenuCustomizeSetting関数',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'getToolMenuCustomizeSetting関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //xxxx関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_setToolButtonCustomizeSetting';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_setToolButtonCustomizeSetting);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', 'setToolButtonCustomizeSetting関数',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'setToolButtonCustomizeSetting関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //xxxx関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_getToolButtonCustomizeSetting';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_getToolButtonCustomizeSetting);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', 'getToolButtonCustomizeSetting関数',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'getToolButtonCustomizeSetting関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ---------->>>>>
    //第二売価ガイドの位置を設定します。
    HDllCALL1.ProcName := 'MAHNB01013B_SetSecondSalesUnPrcGideLocation';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_SetSecondSalesUnPrcGideLocation);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '売伝画面設定用',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '売伝画面第二売価ガイドの位置設定用処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //水野商工㈱オプション判定関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_OptPermitForMizuno2ndSellPriceCtl';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_OptPermitForMizuno2ndSellPriceCtl);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '水野商工㈱オプション判定',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '水野商工㈱オプション判定関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ----------<<<<<

    //保存用設定処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_SetAfterSaveData';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_SetAfterSaveData);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '売伝画面保存用',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '売伝画面保存用設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //保存用設定処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetAfterSaveData';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetAfterSaveData);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '売伝画面保存用',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '売伝画面保存用設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //保存用設定処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_DoAfterSave';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_DoAfterSave);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '売伝画面保存用',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '売伝画面保存用設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //----ADD 2012/10/15----->>>>>
    //仕入日のエラーメッセージを表示処理
    HDllCALL1.ProcName := 'MAHNB01013B_ShowStockDateMsg';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_ShowStockDateMsg);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '売伝画面仕入日メッセージ用',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '売伝画面仕入日メッセージ用処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    //----ADD 2012/10/15-----<<<<<

    //SaveToolbarCustomizeSetting関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_SaveToolbarCustomizeSetting';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_SaveToolbarCustomizeSetting);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', 'SaveToolbarCustomizeSetting',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'SaveToolbarCustomizeSetting関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //SaveToolManagerCustomizeInfo関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_SaveToolManagerCustomizeInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_SaveToolManagerCustomizeInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', 'SaveToolManagerCustomizeInfo',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'SaveToolManagerCustomizeInfo関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //SaveCustomizeXml関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_SaveCustomizeXml';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_SaveCustomizeXml);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', 'SaveCustomizeXml',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'SaveCustomizeXml関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //GetUltraOptionSetValue関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetUltraOptionSetValue';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetUltraOptionSetValue);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', 'GetUltraOptionSetValue',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'GetUltraOptionSetValue関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //SlipNoteGuide関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_SlipNoteGuide';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_SlipNoteGuide);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', 'SlipNoteGuide',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'SlipNoteGuide関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //売上金額変更後発生イベント処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_SalesPriceChanged';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_SalesPriceChanged);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '品売上金額変更後発生イベント処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '品売上金額変更後発生イベント処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //車両情報設定処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_CarInfoFormSetting';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_CarInfoFormSetting);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '車両情報設定',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '車両情報設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //保存確認ダイアログ表示処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_ShowRedSaveCheckDialog';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_ShowRedSaveCheckDialog);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '保存確認ダイアログ表示',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '保存確認ダイアログ表示処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //SetItemsDictionary関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_SetItemsDictionary';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_SetItemsDictionary);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', 'SetItemsDictionary',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'SetItemsDictionary関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //setColDisplayStatusList関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_setColDisplayStatusList';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_setColDisplayStatusList);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', 'setColDisplayStatusList',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'setColDisplayStatusList関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    // --- ADD 2010/06/02 ---------->>>>>
    //GetReadSlipFlg関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetReadSlipFlg';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetReadSlipFlg);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', 'GetReadSlipFlg',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'GetReadSlipFlg関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2010/06/02----------<<<<<

    // --- ADD 2010/07/08 ---------->>>>>
    //操作権限の制御関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_BeginControllingByOperationAuthority';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_BeginControllingByOperationAuthority);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '操作権限の制御',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '操作権限の制御関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2010/07/08 ----------<<<<<


// add by gaofeng end

    // --- ADD 2014/07/15 T.Miyamoto 仕掛一覧 №1912 ---------->>>>>
    HDllCALL1.ProcName := 'MAHNB01013B_GetOperationSt';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetOperationSt);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '操作権限の判定',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '操作権限の判定関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 2014/07/15 T.Miyamoto 仕掛一覧 №1912 ----------<<<<<

// add by lizc begin
//最新情報処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_ReNewalBtnClick';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_ReNewalBtnClick);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '最新情報処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '最新情報処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

//最新情報処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_ProcessingDialogDispose';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_ProcessingDialogDispose);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '最新情報処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '最新情報処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
// add by lizc end

//>>>2010/05/30
    //SCM問合せ一覧選択関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_ReferenceList';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_ReferenceList);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', 'SCM問合せ一覧選択',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'bbbSCM問合せ一覧選択関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    //----- ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応------->>>>>
    //税率入力関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetTaxRateDialogResult';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetTaxRateDialogResult);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '税率入力',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '税率入力関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    
    HDllCALL1.ProcName := 'MAHNB01013B_GetTaxRate';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetTaxRate);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '税率入力',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'bbb税率入力選択関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    HDllCALL1.ProcName := 'MAHNB01013B_OrderCheck';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_OrderCheck);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '発注と仕入判断処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '発注と仕入判断処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    //----- ADD　 譚洪 2020/02/24 PMKOBETSU-2912の対応-------<<<<<
    // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応 ----->>>>>
    //電帳起動関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_StartEBooks';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_StartEBooks);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '税率入力',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '電帳起動関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応 -----<<<<<
    //----- ADD　2018/09/04 譚洪　履歴自動表示の対応------->>>>>   
    //履歴検索選択関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_HisSearch';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_HisSearch);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '履歴検索',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'bbb履歴検索選択関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    //----- ADD　2018/09/04 譚洪　履歴自動表示の対応-------<<<<<   

    //起動パラメータ設定処理関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_SettingParameter';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_SettingParameter);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '起動パラメータ設定処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '起動パラメータ設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //SCM情報読込タイマー起動イベント関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_TimerSCMReadTick';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_TimerSCMReadTick);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', 'SCM情報読込タイマー起動イベント処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'SCM情報読込タイマー起動イベント処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //相場価格情報取得関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_GetSobaInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetSobaInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '相場価格情報取得処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '相場価格情報取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
//<<<2010/05/30

//>>>2010/08/30
    //税率設定範囲チェック関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_ExistTaxRateRangeMethod';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_ExistTaxRateRangeMethod);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '税率設定範囲チェック処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '税率設定範囲チェック処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
//<<<2010/08/30

//>>>2011/02/01
    //SCM情報存在チェック関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_ExistSCMInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_ExistSCMInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', 'SCM情報存在チェック処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'SCM情報存在チェック処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
//<<<2011/02/01

//>>>2011/03/04
    //従業員情報設定関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_SettingEmpInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_SettingEmpInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '従業員情報設定処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '従業員情報設定処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
//<<<2011/03/04

    // --- ADD m.suzuki 2010/06/12 ---------->>>>>
    // QR作成スレッド起動
    HDllCALL1.ProcName := 'MAHNB01013B_MakeQR';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_MakeQR);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', 'QR作成スレッド起動',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'QR作成スレッド起動処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD m.suzuki 2010/06/12 ----------<<<<<
    // --- ADD m.suzuki 2010/06/16 ---------->>>>>
    // オンラインフラグ取得処理
    HDllCALL1.ProcName := 'MAHNB01013B_GetOnlineFlag';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_GetOnlineFlag);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', 'オンラインフラグ取得処理',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            'オンラインフラグ取得処理関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    // --- ADD m.suzuki 2010/06/16 ----------<<<<<
// ------  ADD K2015/04/01 高騁 森川部品個別依頼------->>>>>
    //全社在庫情報関数アド
    HDllCALL1.ProcName := 'MAHNB01013B_ReadAllSecStockInfo';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_ReadAllSecStockInfo);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '全社在庫情報一覧',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '全社在庫情報一覧関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
    //森川個別オプション判定関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_OptPermitForMoriKawa';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_OptPermitForMoriKawa);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '倉庫部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '倉庫部品森川個別オプション判定関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;
// ------  ADD K2015/04/01 高騁 森川部品個別依頼------->>>>>

    // --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- >>>>>
    HDllCALL1.ProcName := 'MAHNB01013B_OptPermitForKoei';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_OptPermitForKoei);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '㈱コーエイオプション判定',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '㈱コーエイオプション判定関数のアドレス取得に失敗しました', nSt, nil, 0);
        Exit;
    end;

    //売価算出関数アドレス取得
    HDllCALL1.ProcName := 'MAHNB01013B_SalesUnPrcCalc';
    nSt := HDllCALL1.HGetPAdr(@gpxMAHNB01013B_SalesUnPrcCalc);
    if nSt <> 0 then
    begin
        HDspMsg(ERR_LEVEL_STOPDISP, 'MAHNB01013C', '売価算出部品',
            'LoadLibraryMAHNB01013B', 'GETPROCADDRESS',
            '個別用売価算出関数のアドレス取得に失敗しました。', nSt, nil, 0);
        Exit;
    end;
    // --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- <<<<<

    Result := 0;

end;

// **********************************************************************//
// Module Name     :  得意先部品フリー関数                        //
// :  FreeLibraryMAHNB01013B                            //
// 引数            :  １．HDLLCALL                                      //
// 戻り値          :  無し                                              //
// Programer       :  自動生成                                            //
// Date            :  2010.04.01                                          //
// Note            :  得意先部品フリーします                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
// **********************************************************************//
procedure FreeLibraryMAHNB01013B(HDllCALL1: THDLLCALL);
begin
    HDllCALL1.DllName := 'MAHNB01013B.DLL';
    HDllCALL1.HFreeLibrary;
    // add by tanh
    gpxMAHNB01013B_Clear := nil;
    gpxMAHNB01013B_GetItemtSalesSlipCd := nil;
    gpxMAHNB01013B_InitMstCheck := nil;
    gpxMAHNB01013B_GetAddInfoVisible := nil;
    gpxMAHNB01013B_GetDisplayHeaderFooterInfo := nil;
    gpxMAHNB01013B_GetDisplayCustomerInfo := nil;
    gpxMAHNB01013B_SetUserGdBdComboEditor := nil;
    gpxMAHNB01013B_GetCellEnabled := nil;
    gpxMAHNB01013B_Retry := nil;
    gpxMAHNB01013B_RetryResult := nil;
    gpxMAHNB01013B_GetNoteGuidList := nil;
    gpxMAHNB01013B_FormPosSerialize := nil;
    gpxMAHNB01013B_FormPosDeserialize := nil;
    gpxMAHNB01013B_GetGrossProfitRateFlg := nil;
    gpxMAHNB01013B_GetBitButtonCustomizeSetting := nil;
    gpxMAHNB01013B_SmallPointProc := nil;
    gpxMAHNB01013B_SetHomeKeyFlg := nil;
    // end add by tanh

    // add by zhangkai
    gpxMAHNB01013B_uButtonGuideClick := nil;
    gpxMAHNB01013B_GetNextMovePosition := nil;
    // --- ADD 2010/06/02 ---------->>>>>
    gpxMAHNB01013B_GetPreMovePosition := nil;
    // --- ADD 2010/06/02 ----------<<<<<
    gpxMAHNB01013B_GetParam := nil;
    gpxMAHNB01013B_GetEffectiveJudgment := nil;
    gpxMAHNB01013B_GetSalesDetailDataTable := nil;
    gpxMAHNB01013B_GetSalesAllDetailDataTable := nil;
    gpxMAHNB01013B_SetSalesDetailData := nil;
    gpxMAHNB01013B_AfterGoodsNoUpdate := nil;
    gpxMAHNB01013B_uButtonLineDiscountClick := nil;
    gpxMAHNB01013B_uButtonGoodsDiscountClick := nil;
    gpxMAHNB01013B_uButtonAnnotationClick := nil;
    gpxMAHNB01013B_uButtonChangeWarehouseClick := nil;
    gpxMAHNB01013B_uButtonStockSearchClick := nil;
    gpxMAHNB01013B_uButtonTBOClick := nil;
    gpxMAHNB01013B_uButtonCopyStockBefLineClick := nil;
    gpxMAHNB01013B_uButtonCopyStockAllLineClick := nil;
    gpxMAHNB01013B_uGridDetailsAfterCellUpdate := nil;
    gpxMAHNB01013B_uGridDetailsAfterCellUpdateProc := nil;
    gpxMAHNB01013B_GridJoinCheck := nil;
    gpxMAHNB01013B_DeatilActionTable := nil;
    gpxMAHNB01013B_CheckDetailAction := nil;
    gpxMAHNB01013B_GetSalesSlipInputConstructionData := nil;
    gpxMAHNB01013B_AfterPartySaleSlipNumFocus := nil;
    gpxMAHNB01013B_SetSlipMemo := nil;
    gpxMAHNB01013B_KeyPressNumCheck := nil;
    gpxMAHNB01013B_CsvPassCheck := nil;
    // end add by zhangkai

// add by yangmj
    gpxMAHNB01013B_ShipmentAddUp := nil;
    gpxMAHNB01013B_GetSalesHisGuide := nil;
    gpxMAHNB01013B_AcceptAnOrderReferenceSearch := nil;
    gpxMAHNB01013B_AcceptAnOrderAddup := nil;
    gpxMAHNB01013B_EstimateReferenceSearch := nil;
    gpxMAHNB01013B_EstimateAddup := nil;
    gpxMAHNB01013B_SalesReferenceSearch := nil;
    gpxMAHNB01013B_CopySlip := nil;
    gpxMAHNB01013B_GetOptCarMng := nil;
    gpxMAHNB01013B_SetNoteCharCnt := nil;
    gpxMAHNB01013B_ReturnSlip := nil;
    gpxMAHNB01013B_ShowSaveCheckDialog := nil;
    gpxMAHNB01013B_Save := nil;
    gpxMAHNB01013B_AfterSave := nil;
    gpxMAHNB01013B_GetSaveStatus := nil;
    // --- ADD 2015/12/09 T.Miyamoto リモ伝障害対応 Redmine#47670 ---------->>>>>
    gpxMAHNB01013B_GetOnlineKindDiv := nil;
    // --- ADD 2015/12/09 T.Miyamoto リモ伝障害対応 Redmine#47670 ----------<<<<<
    gpxMAHNB01013B_ChangeSearchMode := nil;
    gpxMAHNB01013B_GetSearchPartsModeProperty := nil;
    //----ADD 2010/06/17----->>>>>
    gpxMAHNB01013B_SetSalesSlip := nil;
    //----ADD 2010/06/17-----<<<<<
    //----ADD 2010/11/02----->>>>>
    gpxMAHNB01013B_SetSalesSlipByObj := nil;
    //----ADD 2010/11/02-----<<<<<

// end add by yangmj

    // --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ---------->>>>>
    gpxMAHNB01013B_SetSecondSalesUnPrcGideLocation := nil;

    gpxMAHNB01013B_OptPermitForMizuno2ndSellPriceCtl := nil;
    // --- ADD K2016/12/30 譚洪 水野商工㈱　第二売価 ----------<<<<<

    gpxMAHNB01013B_SetAfterSaveData := nil;
    gpxMAHNB01013B_GetAfterSaveData := nil;
    gpxMAHNB01013B_DoAfterSave := nil;
    //----ADD 2012/10/15----->>>>>
    gpxMAHNB01013B_ShowStockDateMsg := nil;
    //----ADD 2012/10/15-----<<<<<

// add by gaofeng start
    gpxMAHNB01013B_GetInitData := nil;
    gpxMAHNB01013B_salesSlipGuide := nil;
    gpxMAHNB01013B_customerGuide := nil;
    gpxMAHNB01013B_ShowSalesSlipInputSetup := nil;
    gpxMAHNB01013B_GetDisplayName := nil;
    gpxMAHNB01013B_GetDetailGrossProfitRate := nil;
    gpxMAHNB01013B_Delete := nil;
    gpxMAHNB01013B_GetItemName := nil;
    gpxMAHNB01013B_GetStatus := nil;
    gpxMAHNB01013B_GetBeforeSalesSlipNumText := nil;
    gpxMAHNB01013B_GetFocusPositionValue := nil;
    gpxMAHNB01013B_RedSlip := nil;
    gpxMAHNB01013B_GetCanRed := nil;
    gpxMAHNB01013B_GetRedDialogResult := nil;
    gpxMAHNB01013B_CopySlipHeader := nil;
    gpxMAHNB01013B_CopySlipDetail := nil;          // ADD 連番729 2011/08/18
    gpxMAHNB01013B_AfterCarMngNoGuideReturn := nil;
    gpxMAHNB01013B_setToolMenuCustomizeSetting := nil;
    gpxMAHNB01013B_getToolMenuCustomizeSetting := nil;
    gpxMAHNB01013B_setToolButtonCustomizeSetting := nil;
    gpxMAHNB01013B_getToolButtonCustomizeSetting := nil;
    gpxMAHNB01013B_SaveToolbarCustomizeSetting := nil;
    gpxMAHNB01013B_SaveToolManagerCustomizeInfo := nil;
    gpxMAHNB01013B_SaveCustomizeXml := nil;
    gpxMAHNB01013B_GetUltraOptionSetValue := nil;
    gpxMAHNB01013B_SlipNoteGuide := nil;
    gpxMAHNB01013B_SalesPriceChanged := nil;
    gpxMAHNB01013B_CarInfoFormSetting := nil;
    gpxMAHNB01013B_ShowRedSaveCheckDialog := nil;
    gpxMAHNB01013B_SetItemsDictionary := nil;
    gpxMAHNB01013B_setColDisplayStatusList := nil;
    gpxMAHNB01013B_retGoodsReason := nil;
    //>>>2010/05/30
    gpxMAHNB01013B_ReferenceList := nil;
    gpxMAHNB01013B_HisSearch := nil;// ADD　2018/09/04 譚洪　履歴自動表示の対応
    gpxMAHNB01013B_GetTaxRateDialogResult := nil;  // ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応
    gpxMAHNB01013B_GetTaxRate := nil;  // ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応
    gpxMAHNB01013B_OrderCheck := nil;  // ADD 譚洪 2020/02/24 PMKOBETSU-2912の対応
    gpxMAHNB01013B_StartEBooks := nil; // ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応

    gpxMAHNB01013B_SettingParameter := nil;
    gpxMAHNB01013B_TimerSCMReadTick := nil;
    gpxMAHNB01013B_GetSobaInfo := nil;
    //<<<2010/05/30
    // --- ADD 2011/02/12 ---------->>>>>
    gpxMAHNB01013B_DoAddLine := nil;
    gpxMAHNB01013B_DoCacheImage := nil;
    gpxMAHNB01013B_GetErrorFlag := nil;
    // --- ADD 2011/02/12 ----------<<<<<
    gpxMAHNB01013B_CooprtKindDiv := nil;// ADD 2011/11/22
    // --- ADD 2011/04/13 ---------->>>>>
    gpxMAHNB01013B_DetailDeleteActionTable := nil;
    // --- ADD 2011/04/13 ----------<<<<<
    // --- ADD 2011/05/30 ---------->>>>>
    gpxMAHNB01013B_SetSectionCode := nil;
    // --- ADD 2011/05/30 ----------<<<<<
    // --- ADD 2011/07/18 ---------->>>>>
    gpxMAHNB01013B_StockInfoAdjust := nil;
    // --- ADD 2011/07/18 ----------<<<<<
    //>>>2010/08/30
    gpxMAHNB01013B_ExistTaxRateRangeMethod := nil;
    //<<<2010/08/30

    //>>>2011/02/01
    gpxMAHNB01013B_ExistSCMInfo := nil;
    //<<<2011/02/01
    //>>>2011/03/04
    gpxMAHNB01013B_SettingEmpInfo := nil;
    //<<<2011/03/04

    // --- ADD 2010/06/02 ---------->>>>>
    gpxMAHNB01013B_GetReadSlipFlg := nil;
    // --- ADD 2010/06/02----------<<<<<

    // --- ADD 2010/07/08 ---------->>>>>
    gpxMAHNB01013B_BeginControllingByOperationAuthority := nil;
    // --- ADD 2010/07/08 ----------<<<<<
// add by gaofeng end

    // --- ADD 2014/07/15 T.Miyamoto 仕掛一覧 №1912 ---------->>>>>
    gpxMAHNB01013B_GetOperationSt := nil;
    // --- ADD 2014/07/15 T.Miyamoto 仕掛一覧 №1912 ----------<<<<<

    // --- ADD m.suzuki 2010/06/12 ---------->>>>>
    gpxMAHNB01013B_MakeQR := nil;
    // --- ADD m.suzuki 2010/06/12 ----------<<<<<
    // --- ADD m.suzuki 2010/06/16 ---------->>>>>
    gpxMAHNB01013B_GetOnlineFlag := nil;
    // --- ADD m.suzuki 2010/06/16 ----------<<<<<
    gpxMAHNB01013B_SetInitData := nil;
    // ------  ADD K2015/04/01 高騁 森川部品個別依頼------->>>>>
    gpxMAHNB01013B_ReadAllSecStockInfo := nil;
    gpxMAHNB01013B_OptPermitForMoriKawa := nil;
    // ------  ADD K2015/04/01 高騁 森川部品個別依頼-------<<<<<
    // --- ADD 黄興貴 2015/04/29 回答取込パタン追加 ---------------->>>>>
    gpxMAHNB01013B_ReadUoeData := nil;
    gpxMAHNB01013B_OptPermitForFuJi := nil;
    // --- ADD 黄興貴 2015/04/29 回答取込パタン追加 ----------------<<<<<

    // --- ADD 紀飛 K2015/06/18 WebUOE発注回答取込 ---------------->>>>>
    gpxMAHNB01013B_OptPermitForMeiGo := nil;
    // --- ADD 紀飛 K2015/06/18 WebUOE発注回答取込 ----------------<<<<<
    // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応--->>>>>
    gpxMAHNB01013B_OptPermitForEBooks := nil;
    // --- ADD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応---<<<<<

    // --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- >>>>>
    gpxMAHNB01013B_OptPermitForKoei := nil;
    gpxMAHNB01013B_SalesUnPrcCalc := nil;
    // --- ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ --- <<<<<
end;

// add by gaofeng start

// **********************************************************************//
// Module Name     :  伝票呼出操作部品フリー関数                        //
// :  ClearTSalesSlipSearchResult                            //
// 引数            :  １．売上データ                                      //
// 戻り値          :  無し                                              //
// Programer       :  自動生成                                            //
// Date            :  2010.04.07                                          //
// Note            :  伝票呼出操作部品フリーします                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
// **********************************************************************//
procedure ClearTSalesSlipSearchResult(var h_SalesSlipSearchResult: TSalesSlipSearchResult);
begin
  h_SalesSlipSearchResult.AccRecConsTax := 0;
  h_SalesSlipSearchResult.AccRecDivCd := 0;
  h_SalesSlipSearchResult.AcptAnOdrStatus := 0;
  h_SalesSlipSearchResult.AddresseeAddr1 := '';
  h_SalesSlipSearchResult.AddresseeAddr3 := '';
  h_SalesSlipSearchResult.AddresseeAddr4 := '';
  h_SalesSlipSearchResult.AddresseeCode := 0;
  h_SalesSlipSearchResult.AddresseeFaxNo := '';
  h_SalesSlipSearchResult.AddresseeName := '';
  h_SalesSlipSearchResult.AddresseeName2 := '';
  h_SalesSlipSearchResult.AddresseePostNo := '';
  h_SalesSlipSearchResult.AddresseeTelNo := '';
  h_SalesSlipSearchResult.AddUpADate := 0;
  h_SalesSlipSearchResult.AddUpADateAdFormal := '';
  h_SalesSlipSearchResult.AddUpADateAdInFormal := '';
  h_SalesSlipSearchResult.AddUpADateJpFormal := '';
  h_SalesSlipSearchResult.AddUpADateJpInFormal := '';
  h_SalesSlipSearchResult.AutoDepositCd := 0;
  h_SalesSlipSearchResult.AutoDepositSlipNo := 0;
  h_SalesSlipSearchResult.BusinessTypeCode := 0;
  h_SalesSlipSearchResult.BusinessTypeName := '';
  h_SalesSlipSearchResult.CarMngCode := '';
  h_SalesSlipSearchResult.CashRegisterNo := 0;
  h_SalesSlipSearchResult.CategoryNo := 0;
  h_SalesSlipSearchResult.ClaimCode := 0;
  h_SalesSlipSearchResult.ClaimSnm := '';
  h_SalesSlipSearchResult.CompleteCd := 0;
  h_SalesSlipSearchResult.ConsTaxLayMethod := 0;
  h_SalesSlipSearchResult.ConsTaxRate := 0;
  h_SalesSlipSearchResult.CustomerCode := 0;
  h_SalesSlipSearchResult.CustomerName := '';
  h_SalesSlipSearchResult.CustomerName2 := '';
  h_SalesSlipSearchResult.CustomerSnm := '';
  h_SalesSlipSearchResult.CustSlipNo := 0;
  h_SalesSlipSearchResult.DebitNLnkSalesSlNum := '';
  h_SalesSlipSearchResult.DebitNoteDiv := 0;
  h_SalesSlipSearchResult.DelayPaymentDiv := 0;
  h_SalesSlipSearchResult.DeliveredGoodsDiv := 0;
  h_SalesSlipSearchResult.DeliveredGoodsDivNm := '';
  h_SalesSlipSearchResult.DemandAddUpSecCd := '';
  h_SalesSlipSearchResult.DepositAllowanceTtl := 0;
  h_SalesSlipSearchResult.DepositAlwcBlnce := 0;
  h_SalesSlipSearchResult.DetailRowCount := 0;
  h_SalesSlipSearchResult.EdiSendDate := 0;
  h_SalesSlipSearchResult.EdiTakeInDate := 0;
  h_SalesSlipSearchResult.EnterpriseCode := '';
  h_SalesSlipSearchResult.EnterpriseName := '';
  h_SalesSlipSearchResult.EraNameDispCd1 := 0;
  h_SalesSlipSearchResult.EstimaTaxDivCd := 0;
  h_SalesSlipSearchResult.EstimateDivide := 0;
  h_SalesSlipSearchResult.EstimateFormNo := '';
  h_SalesSlipSearchResult.EstimateFormPrtCd := 0;
  h_SalesSlipSearchResult.EstimateNote1 := '';
  h_SalesSlipSearchResult.EstimateNote2 := '';
  h_SalesSlipSearchResult.EstimateNote3 := '';
  h_SalesSlipSearchResult.EstimateNote4 := '';
  h_SalesSlipSearchResult.EstimateNote5 := '';
  h_SalesSlipSearchResult.EstimateSubject := '';
  h_SalesSlipSearchResult.EstimateTitle1 := '';
  h_SalesSlipSearchResult.EstimateTitle2 := '';
  h_SalesSlipSearchResult.EstimateTitle3 := '';
  h_SalesSlipSearchResult.EstimateTitle4 := '';
  h_SalesSlipSearchResult.EstimateTitle5 := '';
  h_SalesSlipSearchResult.EstimateValidityDate := 0;
  h_SalesSlipSearchResult.EstimateValidityDateAdFormal := '';
  h_SalesSlipSearchResult.EstimateValidityDateAdInFormal := '';
  h_SalesSlipSearchResult.EstimateValidityDateJpFormal := '';
  h_SalesSlipSearchResult.EstimateValidityDateJpInFormal := '';
  h_SalesSlipSearchResult.Footnotes1 := '';
  h_SalesSlipSearchResult.Footnotes2 := '';
  h_SalesSlipSearchResult.FractionProcCd := 0;
  h_SalesSlipSearchResult.FrontEmployeeCd := '';
  h_SalesSlipSearchResult.FrontEmployeeNm := '';
  h_SalesSlipSearchResult.FullModel := '';
  h_SalesSlipSearchResult.HonorificTitle := '';
  h_SalesSlipSearchResult.InputAgenCd := '';
  h_SalesSlipSearchResult.InputAgenNm := '';
  h_SalesSlipSearchResult.ItdedPartsDisInTax := 0;
  h_SalesSlipSearchResult.ItdedPartsDisOutTax := 0;
  h_SalesSlipSearchResult.ItdedSalesDisInTax := 0;
  h_SalesSlipSearchResult.ItdedSalesDisOutTax := 0;
  h_SalesSlipSearchResult.ItdedSalesDisTaxFre := 0;
  h_SalesSlipSearchResult.ItdedSalesInTax := 0;
  h_SalesSlipSearchResult.ItdedSalesOutTax := 0;
  h_SalesSlipSearchResult.ItdedWorkDisInTax := 0;
  h_SalesSlipSearchResult.ItdedWorkDisOutTax := 0;
  h_SalesSlipSearchResult.ListPricePrintDiv := 0;
  h_SalesSlipSearchResult.LogicalDeleteCode := 0;
  h_SalesSlipSearchResult.MakerFullName := '';
  h_SalesSlipSearchResult.ModelDesignationNo := 0;
  h_SalesSlipSearchResult.ModelFullName := '';
  h_SalesSlipSearchResult.OptionPringDivCd := 0;
  h_SalesSlipSearchResult.OrderNumber := '';
  h_SalesSlipSearchResult.OutputName := '';
  h_SalesSlipSearchResult.PartsDiscountRate := 0;
  h_SalesSlipSearchResult.PartsNoPrtCd := 0;
  h_SalesSlipSearchResult.PartySaleSlipNum := '';
  h_SalesSlipSearchResult.PosReceiptNo := 0;
  h_SalesSlipSearchResult.PureGoodsTtlTaxExc := 0;
  h_SalesSlipSearchResult.RateUseCode := 0;
  h_SalesSlipSearchResult.RavorDiscountRate := 0;
  h_SalesSlipSearchResult.ReconcileFlag := 0;
  h_SalesSlipSearchResult.RegiProcDate := 0;
  h_SalesSlipSearchResult.RegiProcDateAdFormal := '';
  h_SalesSlipSearchResult.RegiProcDateAdInFormal := '';
  h_SalesSlipSearchResult.RegiProcDateJpFormal := '';
  h_SalesSlipSearchResult.RegiProcDateJpInFormal := '';
  h_SalesSlipSearchResult.ResultsAddUpSecCd := '';
  h_SalesSlipSearchResult.ResultsAddUpSecNm := '';
  h_SalesSlipSearchResult.RetGoodsReason := '';
  h_SalesSlipSearchResult.RetGoodsReasonDiv := 0;
  h_SalesSlipSearchResult.SalAmntConsTaxInclu := 0;
  h_SalesSlipSearchResult.SalesAreaCode := 0;
  h_SalesSlipSearchResult.SalesAreaName := '';
  h_SalesSlipSearchResult.SalesDate := 0;
  h_SalesSlipSearchResult.SalesDateAdFormal := '';
  h_SalesSlipSearchResult.SalesDateAdInFormal := '';
  h_SalesSlipSearchResult.SalesDateJpFormal := '';
  h_SalesSlipSearchResult.SalesDateJpInFormal := '';
  h_SalesSlipSearchResult.SalesDisOutTax := 0;
  h_SalesSlipSearchResult.SalesDisTtlTaxExc := 0;
  h_SalesSlipSearchResult.SalesDisTtlTaxInclu := 0;
  h_SalesSlipSearchResult.SalesEmployeeCd := '';
  h_SalesSlipSearchResult.SalesEmployeeNm := '';
  h_SalesSlipSearchResult.SalesGoodsCd := 0;
  h_SalesSlipSearchResult.SalesInpSecCd := '';
  h_SalesSlipSearchResult.SalesInputCode := '';
  h_SalesSlipSearchResult.SalesInputName := '';
  h_SalesSlipSearchResult.SalesNetPrice := 0;
  h_SalesSlipSearchResult.SalesOutTax := 0;
  h_SalesSlipSearchResult.SalesPriceFracProcCd := 0;
  h_SalesSlipSearchResult.SalesPrtSubttlExc := 0;
  h_SalesSlipSearchResult.SalesPrtSubttlInc := 0;
  h_SalesSlipSearchResult.SalesPrtTotalTaxExc := 0;
  h_SalesSlipSearchResult.SalesPrtTotalTaxInc := 0;
  h_SalesSlipSearchResult.SalesSlipCd := 0;
  h_SalesSlipSearchResult.SalesSlipNum := '';
  h_SalesSlipSearchResult.SalesSlipPrintDate := 0;
  h_SalesSlipSearchResult.SalesSubtotalTax := 0;
  h_SalesSlipSearchResult.SalesSubtotalTaxExc := 0;
  h_SalesSlipSearchResult.SalesSubtotalTaxInc := 0;
  h_SalesSlipSearchResult.SalesTotalTaxExc := 0;
  h_SalesSlipSearchResult.SalesTotalTaxInc := 0;
  h_SalesSlipSearchResult.SalesWorkSubttlExc := 0;
  h_SalesSlipSearchResult.SalesWorkSubttlInc := 0;
  h_SalesSlipSearchResult.SalesWorkTotalTaxExc := 0;
  h_SalesSlipSearchResult.SalesWorkTotalTaxInc := 0;
  h_SalesSlipSearchResult.SalSubttlSubToTaxFre := 0;
  h_SalesSlipSearchResult.SearchSlipDate := 0;
  h_SalesSlipSearchResult.SearchSlipDateAdFormal := '';
  h_SalesSlipSearchResult.SearchSlipDateAdInFormal := '';
  h_SalesSlipSearchResult.SearchSlipDateJpFormal := '';
  h_SalesSlipSearchResult.SearchSlipDateJpInFormal := '';
  h_SalesSlipSearchResult.SectionCode := '';
  h_SalesSlipSearchResult.SectionGuideNm := '';
  h_SalesSlipSearchResult.ShipmentDay := 0;
  h_SalesSlipSearchResult.ShipmentDayAdFormal := '';
  h_SalesSlipSearchResult.ShipmentDayAdInFormal := '';
  h_SalesSlipSearchResult.ShipmentDayJpFormal := '';
  h_SalesSlipSearchResult.ShipmentDayJpInFormal := '';
  h_SalesSlipSearchResult.SlipAddressDiv := 0;
  h_SalesSlipSearchResult.SlipNote := '';
  h_SalesSlipSearchResult.SlipNote2 := '';
  h_SalesSlipSearchResult.SlipNote3 := '';
  h_SalesSlipSearchResult.SlipPrintDivCd := 0;
  h_SalesSlipSearchResult.SlipPrintFinishCd := 0;
  h_SalesSlipSearchResult.SlipPrtSetPaperId := '';
  h_SalesSlipSearchResult.StockGoodsTtlTaxExc := 0;
  h_SalesSlipSearchResult.SubSectionCode := 0;
  h_SalesSlipSearchResult.SubSectionName := '';
  h_SalesSlipSearchResult.TotalAmountDispWayCd := 0;
  h_SalesSlipSearchResult.TotalCost := 0;
  h_SalesSlipSearchResult.TtlAmntDispRateApy := 0;
  h_SalesSlipSearchResult.UoeRemark1 := '';
  h_SalesSlipSearchResult.UoeRemark2 := '';
  h_SalesSlipSearchResult.UpdateSecCd := '';
end;

// **********************************************************************//
// Module Name     :  得意先部品フリー関数                        //
// :  ClearTCustomerSearchRet                            //
// 引数            :  １．得意先検索結果                                      //
// 戻り値          :  無し                                              //
// Programer       :  自動生成                                            //
// Date            :  2010.03.18                                          //
// Note            :  得意先部品フリーします                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
// **********************************************************************//
procedure ClearTCustomerSearchRet(var h_CustomerSearchRet: TCustomerSearchRet);
begin
  h_CustomerSearchRet.AcceptWholeSale := 0;
  h_CustomerSearchRet.Address1 := '';
  h_CustomerSearchRet.Address3 := '';
  h_CustomerSearchRet.Address4 := '';
  h_CustomerSearchRet.CustomerCode := 0;
  h_CustomerSearchRet.CustomerEpCode := '';
  h_CustomerSearchRet.CustomerSecCode := '';
  h_CustomerSearchRet.CustomerSlipNoDiv := 0;
  h_CustomerSearchRet.CustomerSubCode := '';
  h_CustomerSearchRet.EnterpriseCode := '';
  h_CustomerSearchRet.EnterpriseName := '';
  h_CustomerSearchRet.HomeTelNo := '';
  h_CustomerSearchRet.HonorificTitle := '';
  h_CustomerSearchRet.Kana := '';
  h_CustomerSearchRet.LogicalDeleteCode := 0;
  h_CustomerSearchRet.MngSectionCode := '';
  h_CustomerSearchRet.Name := '';
  h_CustomerSearchRet.Name2 := '';
  h_CustomerSearchRet.OfficeTelNo := '';
  h_CustomerSearchRet.PortableTelNo := '';
  h_CustomerSearchRet.PostNo := '';
  h_CustomerSearchRet.SearchTelNo := '';
  h_CustomerSearchRet.Snm := '';
  h_CustomerSearchRet.TotalDay := 0;
  h_CustomerSearchRet.UpdateDate := 0;
end;

// **********************************************************************//
// Module Name     :  見出貼付部品フリー関数                        //
// :  ClearTSalesSlipHeaderCopyData                            //
// 引数            :  １．xxxx                                      //
// 戻り値          :  無し                                              //
// Programer       :  自動生成                                            //
// Date            :  2010.04.19                                          //
// Note            :  見出貼付部品フリーします                      //
// ----------------------------------------------------------------------//
// Update Note     :  xxxx.xx.xx  ｘｘ　ｘｘ                            //
// **********************************************************************//
procedure ClearTSalesSlipHeaderCopyData(var h_SalesSlipHeaderCopyData: TSalesSlipHeaderCopyData);
begin
  h_SalesSlipHeaderCopyData.AcptAnOdrStatus := 0;
  h_SalesSlipHeaderCopyData.AddresseeCode := 0;
  h_SalesSlipHeaderCopyData.AddresseeName := '';
  h_SalesSlipHeaderCopyData.AddresseeName2 := '';
  h_SalesSlipHeaderCopyData.CarAddInfo1 := '';
  h_SalesSlipHeaderCopyData.CarAddInfo2 := '';
  h_SalesSlipHeaderCopyData.CarInspectYear := 0;
  h_SalesSlipHeaderCopyData.CarMngCode := '';
  h_SalesSlipHeaderCopyData.CarMngNo := 0;
  h_SalesSlipHeaderCopyData.CarNote := '';
  h_SalesSlipHeaderCopyData.CategoryNo := 0;
  h_SalesSlipHeaderCopyData.ColorCode := '';
  h_SalesSlipHeaderCopyData.CustomerCode := 0;
  h_SalesSlipHeaderCopyData.CustomerSnm := '';
  h_SalesSlipHeaderCopyData.DeliveredGoodsDiv := 0;
  h_SalesSlipHeaderCopyData.EngineModel := '';
  h_SalesSlipHeaderCopyData.EngineModelNm := '';
  h_SalesSlipHeaderCopyData.EntryDate := 0;
  h_SalesSlipHeaderCopyData.FirstEntryDate := 0;
  h_SalesSlipHeaderCopyData.FrameNo := '';
  h_SalesSlipHeaderCopyData.FrontEmployeeCd := '';
  h_SalesSlipHeaderCopyData.FullModel := '';
  h_SalesSlipHeaderCopyData.InspectMaturityDate := 0;
  h_SalesSlipHeaderCopyData.LTimeCiMatDate := 0;
  h_SalesSlipHeaderCopyData.MakerCode := 0;
  h_SalesSlipHeaderCopyData.Mileage := 0;
  h_SalesSlipHeaderCopyData.ModelCode := 0;
  h_SalesSlipHeaderCopyData.ModelDesignationNo := 0;
  h_SalesSlipHeaderCopyData.ModelFullName := '';
  h_SalesSlipHeaderCopyData.ModelSubCode := 0;
  h_SalesSlipHeaderCopyData.NumberPlate1Code := 0;
  h_SalesSlipHeaderCopyData.NumberPlate1Name := '';
  h_SalesSlipHeaderCopyData.NumberPlate2 := '';
  h_SalesSlipHeaderCopyData.NumberPlate3 := '';
  h_SalesSlipHeaderCopyData.NumberPlate4 := 0;
  h_SalesSlipHeaderCopyData.PartySaleSlipNum := '';
  h_SalesSlipHeaderCopyData.SalesDate := 0;
  h_SalesSlipHeaderCopyData.SalesInputCode := '';
  h_SalesSlipHeaderCopyData.SalesRowNo := 0;
  h_SalesSlipHeaderCopyData.SalesSlipCd := 0;
  h_SalesSlipHeaderCopyData.SalesSlipNum := '';
  h_SalesSlipHeaderCopyData.SectionCode := '';
  h_SalesSlipHeaderCopyData.SlipNote := '';
  h_SalesSlipHeaderCopyData.SlipNote2 := '';
  h_SalesSlipHeaderCopyData.SlipNote3 := '';
  h_SalesSlipHeaderCopyData.TrimCode := '';
end;

// add by gaofeng end
end.

//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/05/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/05/26  修正内容 : テーブルレイアウト変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018　鈴木 正臣
// 作 成 日  2011/05/23  修正内容 : テーブルレイアウト変更対応
//----------------------------------------------------------------------------//
// 管理番号  10800003-00 作成担当 : 30517 夏野 駿希
// 作 成 日  2012/01/16  修正内容 : SCM改良対応・特記事項対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 20073 西 毅
// 作 成 日  2012/05/30  修正内容 : SCM改良対応・自動見積部品コード
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30745 吉岡
// 作 成 日  2013/05/08  修正内容 : 2013/06/18配信　SCM障害№10308,№10528
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30745 吉岡
// 作 成 日  2013/05/15  修正内容 : 2013/06/18配信　SCM障害№10410
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 修 正 日  2014/06/04  修正内容 : SCM仕掛一覧№10659対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上 千加子
// 修 正 日  2014/12/19  修正内容 : SCM高速化 PMNS対応 貸出区分、メーカー希望小売価格、オープン価格区分の追加
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 31065 豊沢 憲弘
// 修 正 日  2015/01/19  修正内容 : リコメンド対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上 千加子
// 修 正 日  2015/01/30  修正内容 : SCM高速化 生産年式、車台番号対応　項目追加　型式別部品採用年月、型式別部品廃止年月、型式別部品採用車台番号、型式別部品廃止車台番号
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30745 吉岡
// 修 正 日  2015/02/10  修正内容 : SCM高速化 回答納期区分対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30746 高川 悟
// 修 正 日  2015/02/20  修正内容 : SCM高速化 C向け種別・特記事項対応
//----------------------------------------------------------------------------//
// 管理番号  11470007-00 作成担当 : 田建委
// 修 正 日  2018/04/16  修正内容 : SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加
//----------------------------------------------------------------------------//
using System;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// SCM受注明細データ(回答)のレコードインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Update Note      :   2018/04/16 田建委</br>
    /// <br>管理番号         :   11470007-00</br>
    /// <br>                 :   SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加</br>
    /// </remarks>
    public interface ISCMOrderAnswerRecord
    {
        /// <summary>
        /// 問合せ元企業コードを取得または設定します。
        /// </summary>
        string InqOriginalEpCd { get; set; }

        /// <summary>
        /// 問合せ元拠点コードを取得または設定します。
        /// </summary>
        string InqOriginalSecCd { get; set; }

        /// <summary>
        /// 問合せ先企業コードを取得または設定します。
        /// </summary>
        string InqOtherEpCd { get; set; }

        /// <summary>
        /// 問合せ先拠点コードを取得または設定します。
        /// </summary>
        string InqOtherSecCd { get; set; }

        /// <summary>
        /// 問合せ番号を取得または設定します。
        /// </summary>
        long InquiryNumber { get; set; }

        /// <summary>
        /// 更新年月日を取得または設定します。
        /// </summary>
        DateTime UpdateDate { get; set; }

        /// <summary>
        /// 更新時分秒ミリ秒を取得または設定します。
        /// </summary>
        int UpdateTime { get; set; }

        /// <summary>
        /// 問合せ行番号を取得または設定します。
        /// </summary>
        int InqRowNumber { get; set; }

        /// <summary>
        /// 問合せ行番号枝番を取得または設定します。
        /// </summary>
        int InqRowNumDerivedNo { get; set; }

        /// <summary>
        /// 商品種別を取得または設定します。
        /// </summary>
        int GoodsDivCd { get; set; }

        /// <summary>
        /// BL商品コードを取得または設定します。
        /// </summary>
        int BLGoodsCode { get; set; }

        /// <summary>
        /// BL商品コード枝番を取得または設定します。
        /// </summary>
        int BLGoodsDrCode { get; set; }

        /// <summary>
        /// 問発商品名を取得または設定します。
        /// </summary>
        string InqGoodsName { get; set; }

        /// <summary>
        /// 回答商品名を取得または設定します。
        /// </summary>
        string AnsGoodsName { get; set; }

        /// <summary>
        /// 商品番号を取得または設定します。
        /// </summary>
        string GoodsNo { get; set; }

        /// <summary>
        /// 商品メーカーコードを取得または設定します。
        /// </summary>
        int GoodsMakerCd { get; set; }

        /// <summary>
        /// 発注数を取得または設定します。
        /// </summary>
        double SalesOrderCount { get; set; }

        /// <summary>
        /// 納品数を取得または設定します。
        /// </summary>
        double DeliveredGoodsCount { get; set; }

        /// <summary>
        /// 定価を取得または設定します。
        /// </summary>
        long ListPrice { get; set; }

        /// <summary>
        /// 単価を取得または設定します。
        /// </summary>
        long UnitPrice { get; set; }

        /// <summary>
        /// 棚番を取得または設定します。
        /// </summary>
        string ShelfNo { get; set; }

        /// <summary>
        /// 問合せ・発注種別を取得または設定します。
        /// </summary>
        int InqOrdDivCd { get; set; }

        /// <summary>
        /// リサイクル部品種別を取得または設定します。
        /// </summary>
        int RecyclePrtKindCode { get; set; }

        /// <summary>
        /// リサイクル部品種別名称を取得または設定します。
        /// </summary>
        string RecyclePrtKindName { get; set; }

        /// <summary>
        /// 回答納期を取得または設定します。
        /// </summary>
        string AnswerDeliveryDate { get; set; }

        /// <summary>
        /// 表示順位を取得または設定します。
        /// </summary>
        int DisplayOrder { get; set; }

        /// <summary>
        /// 企業コードを取得または設定します。
        /// </summary>
        string EnterpriseCode { get; set; }

        /// <summary>
        /// 受注ステータスを取得または設定します。
        /// </summary>
        int AcptAnOdrStatus { get; set; }

        /// <summary>
        /// 売上伝票番号を取得または設定します。
        /// </summary>
        string SalesSlipNum { get; set; }

        /// <summary>
        /// 売上行番号を取得または設定します。
        /// </summary>
        int SalesRowNo { get; set; }

        // 2010/05/26 Add >>>
        /// <summary>
        /// キャンセル状態区分を取得または設定します。
        /// </summary>
        /// <remarks>0:キャンセルなし 10:キャンセル要求 20:キャンセル却下 30:キャンセル確定</remarks>
        short CancelCndtinDiv { get;set;}
        // 2010/05/26 Add <<<

        // 2011/02/09 Add >>>
        /// <summary>
        /// 明細取込区分を取得または設定します。
        /// </summary>
        int DtlTakeinDivCd { get; set; }
        // 2011/02/09 Add <<<

        // --- ADD m.suzuki 2011/05/23 ---------->>>>>
        /// <summary>
        /// 備考(明細)を取得または設定します。
        /// </summary>
        string CommentDtl { get; set; }
        /// <summary>
        /// PM倉庫コードを取得または設定します。
        /// </summary>
        string PmWarehouseCd { get; set; }
        /// <summary>
        /// PM倉庫名称を取得または設定します。
        /// </summary>
        string PmWarehouseName { get; set; }
        /// <summary>
        /// PM棚番を取得または設定します。
        /// </summary>
        string PmShelfNo { get; set; }
        // --- ADD m.suzuki 2011/05/23 ----------<<<<<
        // --- ADD 2011/08/08 ---------->>>>>　　
        /// <summary>
        /// PMPM現在個数を取得または設定します。
        /// </summary>
        double PmPrsntCount { get; set; }
        // --- ADD 2011/08/08 ----------<<<<<<

        // --- ADD LDNS tanh 2011/10/10 ----------<<<<<
        /// <summary>
        /// キャンペーンコードを取得または設定します。
        /// </summary>
        int CampaignCode { get; set; }
        // --- ADD LDNS tanh 2011/10/10 ----------<<<<<

        // 2012/01/16 Add >>>
        /// <summary>
        /// 特記事項を取得または設定します。
        /// </summary>
        string GoodsSpecialNote { get; set; }
        // 2012/01/16 Add <<<
        // --- ADD T.Nishi 2012/05/30 ---------->>>>>
        /// <summary>
        /// 自動見積部品コードを取得または設定します。
        /// </summary>
        string AutoEstimatePartsCd { get; set; }
        // --- ADD T.Nishi 2012/05/30 ----------<<<<<

        // ADD 2013/05/08 吉岡 2013/06/18配信 SCM障害№10308,№10528 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 売上伝票合計（税込）を取得または設定します。
        /// </summary>
        long SalesTotalTaxInc { get; set; }
        /// <summary>
        /// 売上伝票合計（税抜）を取得または設定します。
        /// </summary>
        long SalesTotalTaxExc { get; set; }
        /// <summary>
        /// SCM消費税転嫁方式を取得または設定します。
        /// </summary>
        int ScmConsTaxLayMethod { get; set; }
        /// <summary>
        /// 消費税税率を取得または設定します。
        /// </summary>
        double ConsTaxRate { get; set; }
        /// <summary>
        /// SCM端数処理区分を取得または設定します。
        /// </summary>
        int ScmFractionProcCd { get; set; }
        /// <summary>
        /// 売掛消費税を取得または設定します。
        /// </summary>
        long AccRecConsTax { get; set; }
        /// <summary>
        /// PM売上日を取得または設定します。
        /// </summary>
        int PMSalesDate { get; set; }
        /// <summary>
        /// 仕入先伝票発行時刻を取得または設定します。
        /// </summary>
        int SuppSlpPrtTime { get; set; }
        /// <summary>
        /// 売上金額（税込み）を取得または設定します。
        /// </summary>
        long SalesMoneyTaxInc { get; set; }
        /// <summary>
        /// 売上金額（税抜き）を取得または設定します。
        /// </summary>
        long SalesMoneyTaxExc { get; set; }
        // ADD 2013/05/08 吉岡 2013/06/18配信 SCM障害№10308,№10528 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        // ADD 2013/05/15 吉岡 2013/06/18配信 SCM障害№10410 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary> データ入力システムを取得または設定します。 </summary>
        int DataInputSystem { get; set; }
        // ADD 2013/05/15 吉岡 2013/06/18配信 SCM障害№10410 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2014/06/04 SCM仕掛一覧№10659対応 ------------------------------------------------------->>>>>
        /// <summary> 
        /// 優良設定詳細コード２を取得または設定します。
        /// </summary>
        int PrmSetDtlNo2 { get; set; }
        /// <summary> 
        /// 優良設定詳細名称２を取得または設定します。
        /// </summary>
        string PrmSetDtlName2 { get; set; }
        /// <summary> 
        /// 在庫状況区分２を取得または設定します。
        /// </summary>
        short StockStatusDiv { get; set; }
        // ADD 2014/06/04 SCM仕掛一覧№10659対応 -------------------------------------------------------<<<<<

        // ADD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
        /// <summary> 
        /// 貸出区分を取得または設定します。
        /// </summary>
        short RentDiv { get; set; }
        /// <summary> 
        /// メーカー希望小売価格を取得または設定します。
        /// </summary>
        long MkrSuggestRtPric { get; set; }
        /// <summary> 
        /// オープン価格区分を取得または設定します。
        /// </summary>
        int OpenPriceDiv { get; set; }
        // ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<

        // ADD 2015/01/19 豊沢 リコメンド対応 --------------------->>>>>
        /// <summary> 
        /// お買得商品選択区分を取得または設定します。
        /// </summary>
        short BgnGoodsDiv { get; set; }
        // ADD 2015/01/19 豊沢 リコメンド対応 ---------------------<<<<<

        // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 ----------------------------->>>>>
        /// <summary> 
        /// 型式別部品採用年月を取得または設定します。
        /// </summary>
        int ModelPrtsAdptYm { get; set; }

        /// <summary> 
        /// 型式別部品廃止年月を取得または設定します。
        /// </summary>
        int ModelPrtsAblsYm { get; set; }

        /// <summary> 
        /// 型式別部品採用車台番号を取得または設定します。
        /// </summary>
        int ModelPrtsAdptFrameNo { get; set; }

        /// <summary> 
        /// 型式別部品廃止車台番号を取得または設定します。
        /// </summary>
        int ModelPrtsAblsFrameNo { get; set; }
        // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 -----------------------------<<<<<

        // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary> 回答納期区分を取得または設定します。</summary>
        short AnsDeliDateDiv { get; set; }
        // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ---------->>>>>>>>>>
        /// <summary>商品規格・特記事項(工場向け)を取得または設定します。</summary>
        string GoodsSpecialNtForFac { get; set; }

        /// <summary>商品規格・特記事項(カーオーナー向け)を取得または設定します。</summary>
        string GoodsSpecialNtForCOw { get; set; }

        /// <summary>優良設定詳細名称２(工場向け)を取得または設定します。</summary>
        string PrmSetDtlName2ForFac { get; set; }

        /// <summary>優良設定詳細名称２(カーオーナー向け)を取得または設定します。</summary>
        string PrmSetDtlName2ForCOw { get; set; }
        // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ----------<<<<<<<<<<

        // ADD 2018/04/16 田建委 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>問発BL統一部品コード(スリーコード版)を取得または設定します。</summary>
        string InqBlUtyPtThCd { get; set; }
       
        /// <summary>問発BL統一部品サブコードを取得または設定します。</summary>
        Int32 InqBlUtyPtSbCd { get; set; }

        /// <summary>回答BL統一部品コード(スリーコード版)を取得または設定します。</summary>
        string AnsBlUtyPtThCd { get; set; }

        /// <summary>回答BL統一部品サブコードを取得または設定します。</summary>
        Int32 AnsBlUtyPtSbCd { get; set; }

        /// <summary>回答BL商品コードを取得または設定します。</summary>
        Int32 AnsBLGoodsCode { get; set; }

        /// <summary>回答BL商品コード枝番を取得または設定します。</summary>
        Int32 AnsBLGoodsDrCode { get; set; }
        // ADD 2018/04/16 田建委 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// キーに変換します。
        /// </summary>
        /// <returns>キー</returns>
        string ToKey();

        /// <summary>
        /// SCM受注データの関連キーに変換します。
        /// </summary>
        /// <returns>SCM受注データの関連キー</returns>
        string ToRelationKey();

        /// <summary>
        /// 売上情報との関連GUID(売上情報との関連付けに用います)
        /// </summary>
        /// <remarks>テーブルレイアウトには存在しません。</remarks>
        Guid SalesRelationId { get; set; }

        /// <summary>
        /// CSVに変換します。
        /// </summary>
        /// <returns>CSV</returns>
        string ToCSV();
    }
}

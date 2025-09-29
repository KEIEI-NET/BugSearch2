//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30744 湯上 千加子
// 作 成 日  2013/05/09  修正内容 : SCM障害№10470対応・商品規格・特記事項追加
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 31065 豊沢 憲弘
// 修 正 日  2015/01/19  修正内容 : SCM高速化 PMNS対応 セット品にメーカー希望小売価格、オープン価格区分の追加
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30745 吉岡
// 修 正 日  2015/02/10  修正内容 : SCM高速化 回答納期区分対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30746 高川 悟
// 修 正 日  2015/02/20  修正内容 : SCM高速化 C向け種別・特記事項対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上 千加子
// 修 正 日  2015/02/27  修正内容 : SCM高速化 セット品に優良設定詳細コード２、優良設定詳細名称、在庫状況区分追加
//----------------------------------------------------------------------------//
// 管理番号  11470007-00 作成担当 : 田建委
// 修 正 日  2018/04/16  修正内容 : SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加
//----------------------------------------------------------------------------//
using System;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// SCM受注セット部品データのレコードインターフェース
    /// </summary>
    /// <remarks>
    /// <br>Update Note      :   2018/04/16 田建委</br>
    /// <br>管理番号         :   11470007-00</br>
    /// <br>                 :   SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加</br>
    /// </remarks>
    public interface ISCMAcOdSetDtRecord
    {
        /// <summary>
        /// 企業コードを取得または設定します。
        /// </summary>
        string EnterpriseCode { get; set; }

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
        /// セット部品メーカーコードを取得または設定します。
        /// </summary>
        int SetPartsMkrCd { get; set; }

        /// <summary>
        /// セット部品番号を取得または設定します。
        /// </summary>
        string SetPartsNumber { get; set; }

        /// <summary>
        /// セット部品親子番号を取得または設定します。
        /// </summary>
        int SetPartsMainSubNo { get; set; }

        /// <summary>
        /// 商品種別を取得または設定します。
        /// </summary>
        int GoodsDivCd { get; set; }

        /// <summary>
        /// リサイクル部品種別を取得または設定します。
        /// </summary>
        int RecyclePrtKindCode { get; set; }

        /// <summary>
        /// リサイクル部品種別名称を取得または設定します。
        /// </summary>
        string RecyclePrtKindName { get; set; }

        /// <summary>
        /// 納品区分を取得または設定します。
        /// </summary>
        int DeliveredGoodsDiv { get; set; }

        /// <summary>
        /// 取扱区分名称を取得または設定します。
        /// </summary>
        int HandleDivCode { get; set; }

        /// <summary>
        /// 商品形態を取得または設定します。
        /// </summary>
        int GoodsShape { get; set; }

        /// <summary>
        /// 納品確認区分を取得または設定します。
        /// </summary>
        int DelivrdGdsConfCd { get; set; }

        /// <summary>
        /// 回答納期を取得または設定します。
        /// </summary>
        string AnswerDeliveryDate { get; set; }

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
        /// 発注数を取得または設定します。
        /// </summary>
        double SalesOrderCount { get; set; }

        /// <summary>
        /// 納品数を取得または設定します。
        /// </summary>
        double DeliveredGoodsCount { get; set; }

        /// <summary>
        /// 商品番号を取得または設定します。
        /// </summary>
        string GoodsNo { get; set; }

        /// <summary>
        /// 商品メーカーコードを取得または設定します。
        /// </summary>
        int GoodsMakerCd { get; set; }

        /// <summary>
        /// 商品メーカー名称を取得または設定します。
        /// </summary>
        string GoodsMakerNm { get; set; }

        /// <summary>
        /// 純正商品メーカーコードを取得または設定します。
        /// </summary>
        int PureGoodsMakerCd { get; set; }

        /// <summary>
        /// 問発純正商品番号を取得または設定します。
        /// </summary>
        string InqPureGoodsNo { get; set; }

        /// <summary>
        /// 回答純正商品番号を取得または設定します。
        /// </summary>
        string AnsPureGoodsNo { get; set; }

        /// <summary>
        /// 定価を取得または設定します。
        /// </summary>
        long ListPrice { get; set; }

        /// <summary>
        /// 単価を取得または設定します。
        /// </summary>
        long UnitPrice { get; set; }

        /// <summary>
        /// 商品補足情報を取得または設定します。
        /// </summary>
        string GoodsAddInfo { get; set; }

        /// <summary>
        /// 粗利額を取得または設定します。
        /// </summary>
        long RoughRrofit { get; set; }

        /// <summary>
        /// 粗利率を取得または設定します。
        /// </summary>
        double RoughRate { get; set; }

        /// <summary>
        /// 回答期限を取得または設定します。
        /// </summary>
        DateTime AnswerLimitDate { get; set; }

        /// <summary>
        /// 備考(明細)を取得または設定します。
        /// </summary>
        string CommentDtl { get; set; }

        /// <summary>
        /// 棚番を取得または設定します。
        /// </summary>
        string ShelfNo { get; set; }

        /// <summary>
        /// PM受注ステータスを取得または設定します。
        /// </summary>
        int PMAcptAnOdrStatus { get; set; }

        /// <summary>
        /// PM売上伝票番号を取得または設定します。
        /// </summary>
        int PMSalesSlipNum { get; set; }

        /// <summary>
        /// PM売上行番号を取得または設定します。
        /// </summary>
        int PMSalesRowNo { get; set; }

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

        /// <summary>
        /// PM現在個数を取得または設定します。
        /// </summary>
        double PmPrsntCount { get; set; }

        /// <summary>
        /// 納品完了予定日を取得または設定します。
        /// </summary>
        DateTime DeliGdsCmpltDueDate { get; set; }
        
        // ADD 2013/05/09 SCM障害№10470対応 ----------------------------------------->>>>>
        /// <summary>
        /// 商品規格・特記事項を取得または設定します。
        /// </summary>
        string GoodsSpclInstruction { get; set; }

        // ADD 2013/05/09 SCM障害№10470対応 -----------------------------------------<<<<<

        // ADD 2015/01/19 豊沢 SCM高速化 PMNS対応 --------------------------------->>>>>
        /// <summary> 
        /// メーカー希望小売価格を取得または設定します。
        /// </summary>
        long MkrSuggestRtPric { get; set; }
        /// <summary> 
        /// オープン価格区分を取得または設定します。
        /// </summary>
        int OpenPriceDiv { get; set; }
        // ADD 2015/01/19 豊沢 SCM高速化 PMNS対応 ---------------------------------<<<<<

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

        // ADD 2015/02/27 SCM高速化 C向け種別対応 -------------------------------->>>>>
        /// <summary>優良設定詳細コード２を取得または設定します。</summary>
        int PrmSetDtlNo2 { get; set; }

        /// <summary>優良設定詳細名称２を取得または設定します。</summary>
        string PrmSetDtlName2 { get; set; }

        /// <summary>在庫状況区分を取得または設定します。</summary>
        short StockStatusDiv { get; set; }
        // ADD 2015/02/27 SCM高速化 C向け種別対応 --------------------------------<<<<<

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

        ///// <summary>
        ///// キーに変換します。
        ///// </summary>
        ///// <returns>キー</returns>
        //string ToKey();

        ///// <summary>
        ///// SCM受注データの関連キーに変換します。
        ///// </summary>
        ///// <returns>SCM受注データの関連キー</returns>
        //string ToRelationKey();

        ///// <summary>
        ///// 売上情報との関連GUID(売上情報との関連付けに用います)
        ///// </summary>
        ///// <remarks>テーブルレイアウトには存在しません。</remarks>
        //Guid SalesRelationId { get; set; }

        /// <summary>
        /// CSVに変換します。
        /// </summary>
        /// <returns>CSV</returns>
        string ToCSV();
    }
}

//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : qijh  
// 作 成 日  2013/02/27  修正内容 : Redmine#34752
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30744 湯上 千加子
// 作 成 日  2013/05/09  修正内容 : SCM障害№10470対応・商品規格・特記事項追加
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 31065 豊沢 憲弘
// 修 正 日  2015/01/19  修正内容 : SCM高速化 PMNS対応 項目追加 メーカー希望小売価格、オープン価格区分
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

using Broadleaf.Application.UIData.WebDB;
using Broadleaf.Application.UIData.Util;
using Broadleaf.Library.Text;

namespace Broadleaf.Application.UIData
{
    using RecordType = Broadleaf.Application.Remoting.ParamData.SCMAcOdSetDtWork;
    using RecordTypeWeb = Broadleaf.Application.UIData.ScmOdSetDt;
    using Broadleaf.Library.Globarization;

    /// <summary>
    /// ユーザーDB SCM受注セット部品データのレコードクラス
    /// </summary>
    public class UserSCMAcOdSetDtRecord : UserSCMAcOdSetDtWrapper
    {
        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public UserSCMAcOdSetDtRecord() : base() { }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="realRecord">本物のレコード</param>
        public UserSCMAcOdSetDtRecord(RecordType realRecord) : base(realRecord) { }

        #endregion // </Constructor>

        /// <summary>
        /// カスタムコンストラクタ(Web⇒User変換)
        /// </summary>
        /// <param name="webRecord">SCM受注セット部品データ</param>
        /// <remarks>
        /// <br>Update Note      :   2018/04/16 田建委</br>
        /// <br>管理番号         :   11470007-00</br>
        /// <br>                 :   SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加</br>
        /// </remarks>
        public UserSCMAcOdSetDtRecord(WebSCMAcOdSetDtRecord webRecord)
            : base(new RecordType())
        {
            RealRecord.CreateDateTime = webRecord.CreateDateTime; // 作成日時
            RealRecord.UpdateDateTime = webRecord.UpdateDateTime; // 更新日時
            RealRecord.LogicalDeleteCode = webRecord.LogicalDeleteCode; // 論理削除区分
            RealRecord.InqOriginalEpCd = webRecord.InqOriginalEpCd.Trim(); // 問合せ元企業コード//@@@@20230303
            RealRecord.InqOriginalSecCd = webRecord.InqOriginalSecCd; // 問合せ元拠点コード
            RealRecord.InqOtherEpCd = webRecord.InqOtherEpCd; // 問合せ先企業コード
            RealRecord.InqOtherSecCd = webRecord.InqOtherSecCd; // 問合せ先拠点コード
            RealRecord.InquiryNumber = webRecord.InquiryNumber; // 問合せ番号
            RealRecord.SetPartsMkrCd = webRecord.SetPartsMkrCd; // セット部品メーカーコード
            RealRecord.SetPartsNumber = webRecord.SetPartsNumber; // セット部品番号
            RealRecord.SetPartsMainSubNo = webRecord.SetPartsMainSubNo; // セット部品親子番号
            RealRecord.GoodsDivCd = webRecord.GoodsDivCd; // 商品種別
            RealRecord.RecyclePrtKindCode = webRecord.RecyclePrtKindCode; // リサイクル部品種別
            RealRecord.RecyclePrtKindName = webRecord.RecyclePrtKindName; // リサイクル部品種別名称
            RealRecord.DeliveredGoodsDiv = webRecord.DeliveredGoodsDiv; // 納品区分
            RealRecord.HandleDivCode = webRecord.HandleDivCode; // 取扱区分
            RealRecord.GoodsShape = webRecord.GoodsShape; // 商品形態
            RealRecord.DelivrdGdsConfCd = webRecord.DelivrdGdsConfCd; // 納品確認区分
            RealRecord.DeliGdsCmpltDueDate = webRecord.DeliGdsCmpltDueDate; // 納品完了予定日
            RealRecord.AnswerDeliveryDate = webRecord.AnswerDeliveryDate; // 回答納期
            RealRecord.BLGoodsCode = webRecord.BLGoodsCode; // BL商品コード
            RealRecord.BLGoodsDrCode = webRecord.BLGoodsDrCode; // BL商品コード枝番
            RealRecord.InqGoodsName = webRecord.InqGoodsName; // 問発商品名
            RealRecord.AnsGoodsName = webRecord.AnsGoodsName; // 回答商品名
            RealRecord.SalesOrderCount = webRecord.SalesOrderCount; // 発注数
            RealRecord.DeliveredGoodsCount = webRecord.DeliveredGoodsCount; // 納品数
            RealRecord.GoodsNo = webRecord.GoodsNo; // 商品番号
            RealRecord.GoodsMakerCd = webRecord.GoodsMakerCd; // 商品メーカーコード
            RealRecord.GoodsMakerNm = webRecord.GoodsMakerNm; // 商品メーカー名称
            RealRecord.PureGoodsMakerCd = webRecord.PureGoodsMakerCd; // 純正商品メーカーコード
            RealRecord.InqPureGoodsNo = webRecord.InqPureGoodsNo; // 問発純正商品番号
            RealRecord.AnsPureGoodsNo = webRecord.AnsPureGoodsNo; // 回答純正商品番号
            RealRecord.ListPrice = webRecord.ListPrice; // 定価
            RealRecord.UnitPrice = webRecord.UnitPrice; // 単価
            RealRecord.GoodsAddInfo = webRecord.GoodsAddInfo; // 商品補足情報
            RealRecord.RoughRrofit = webRecord.RoughRrofit; // 粗利額
            RealRecord.RoughRate = webRecord.RoughRate; // 粗利率
            RealRecord.AnswerLimitDate = webRecord.AnswerLimitDate; // 回答期限
            RealRecord.CommentDtl = webRecord.CommentDtl; // 備考(明細)
            RealRecord.ShelfNo = webRecord.ShelfNo; // 棚番
            RealRecord.PMAcptAnOdrStatus = webRecord.PMAcptAnOdrStatus; //PM受注ステータス
            RealRecord.PMSalesSlipNum = webRecord.PMSalesSlipNum; //PM売上伝票番号
            RealRecord.PMSalesRowNo = webRecord.PMSalesRowNo; //PM売上行番号
            RealRecord.PmWarehouseCd = webRecord.PmWarehouseCd; // PM倉庫コード
            RealRecord.PmWarehouseName = webRecord.PmWarehouseName; // PM倉庫名称
            RealRecord.PmShelfNo = webRecord.PmShelfNo; // PM棚番
            RealRecord.PmPrsntCount = webRecord.PmPrsntCount; //PM現在個数
            // ADD 2013/05/09 SCM障害№10470対応 ----------------------------------------->>>>>
            RealRecord.GoodsSpclInstruction = webRecord.GoodsSpclInstruction; //商品規格・特記事項
            // ADD 2013/05/09 SCM障害№10470対応 -----------------------------------------<<<<<
            // ADD 2015/01/19 豊沢 SCM高速化 PMNS対応 --------------------------------->>>>>
            RealRecord.MkrSuggestRtPric = webRecord.MkrSuggestRtPric; // メーカー希望小売価格
            RealRecord.OpenPriceDiv = webRecord.OpenPriceDiv; // オープン価格区分
            // ADD 2015/01/19 豊沢 SCM高速化 PMNS対応 ---------------------------------<<<<<
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            RealRecord.AnsDeliDateDiv = webRecord.AnsDeliDateDiv; // 回答納期区分
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ---------->>>>>>>>>>
            RealRecord.GoodsSpecialNtForFac = webRecord.GoodsSpecialNtForFac;   // 商品規格・特記事項(工場向け)
            RealRecord.GoodsSpecialNtForCOw = webRecord.GoodsSpecialNtForCOw;   // 商品規格・特記事項(カーオーナー向け)
            RealRecord.PrmSetDtlName2ForFac = webRecord.PrmSetDtlName2ForFac;   // 優良設定詳細名称２(工場向け)
            RealRecord.PrmSetDtlName2ForCOw = webRecord.PrmSetDtlName2ForCOw;   // 優良設定詳細名称２(カーオーナー向け)
            // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ----------<<<<<<<<<<
            // ADD 2015/02/27 SCM高速化 C向け種別対応 -------------------------------->>>>>
            RealRecord.PrmSetDtlNo2 = webRecord.PrmSetDtlNo2;   // 優良設定詳細コード２
            RealRecord.PrmSetDtlName2 = webRecord.PrmSetDtlName2;   // 優良設定詳細名称２
            RealRecord.StockStatusDiv = webRecord.StockStatusDiv;   // 在庫状況区分
            // ADD 2015/02/27 SCM高速化 C向け種別対応 --------------------------------<<<<<

            // ADD 2018/04/16 田建委 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            RealRecord.InqBlUtyPtThCd = webRecord.InqBlUtyPtThCd;   // 問発BL統一部品コード(スリーコード版)
            RealRecord.InqBlUtyPtSbCd = webRecord.InqBlUtyPtSbCd;   // 問発BL統一部品サブコード
            RealRecord.AnsBlUtyPtThCd = webRecord.AnsBlUtyPtThCd;   // 回答BL統一部品コード(スリーコード版)
            RealRecord.AnsBlUtyPtSbCd = webRecord.AnsBlUtyPtSbCd;   // 回答BL統一部品サブコード
            RealRecord.AnsBLGoodsCode = webRecord.AnsBLGoodsCode;   // 回答BL商品コード
            RealRecord.AnsBLGoodsDrCode = webRecord.AnsBLGoodsDrCode;   // 回答BL商品コード枝番
            // ADD 2018/04/16 田建委 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// コピーコンストラクタ
        /// </summary>
        /// <param name="other">コピー元</param>
        /// <remarks>
        /// <br>Update Note      :   2018/04/16 田建委</br>
        /// <br>管理番号         :   11470007-00</br>
        /// <br>                 :   SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加</br>
        /// </remarks>
        public UserSCMAcOdSetDtRecord(UserSCMAcOdSetDtRecord other)
        {
            if (other == null || other == this) return;

            RealRecord.CreateDateTime = other.CreateDateTime; // 作成日時
            RealRecord.UpdateDateTime = other.UpdateDateTime; // 更新日時
            RealRecord.EnterpriseCode = other.EnterpriseCode; // 企業コード
            RealRecord.FileHeaderGuid = other.FileHeaderGuid; // GUID
            RealRecord.UpdEmployeeCode = other.UpdEmployeeCode; // 更新従業員コード
            RealRecord.UpdAssemblyId1 = other.UpdAssemblyId1; // 更新アセンブリID1
            RealRecord.UpdAssemblyId2 = other.UpdAssemblyId2; // 更新アセンブリID2
            RealRecord.LogicalDeleteCode = other.LogicalDeleteCode; // 論理削除区分
            RealRecord.InqOriginalEpCd = other.InqOriginalEpCd.Trim(); // 問合せ元企業コード//@@@@20230303
            RealRecord.InqOriginalSecCd = other.InqOriginalSecCd; // 問合せ元拠点コード
            RealRecord.InqOtherEpCd = other.InqOtherEpCd; // 問合せ先企業コード
            RealRecord.InqOtherSecCd = other.InqOtherSecCd; // 問合せ先拠点コード
            RealRecord.InquiryNumber = other.InquiryNumber; // 問合せ番号
            RealRecord.SetPartsMkrCd = other.SetPartsMkrCd; // セット部品メーカーコード
            RealRecord.SetPartsNumber = other.SetPartsNumber; // セット部品番号
            RealRecord.SetPartsMainSubNo = other.SetPartsMainSubNo; // セット部品親子番号
            RealRecord.GoodsDivCd = other.GoodsDivCd; // 商品種別
            RealRecord.RecyclePrtKindCode = other.RecyclePrtKindCode; // リサイクル部品種別
            RealRecord.RecyclePrtKindName = other.RecyclePrtKindName; // リサイクル部品種別名称
            RealRecord.DeliveredGoodsDiv = other.DeliveredGoodsDiv; // 納品区分
            RealRecord.HandleDivCode = other.HandleDivCode; // 取扱区分
            RealRecord.GoodsShape = other.GoodsShape; // 商品形態
            RealRecord.DelivrdGdsConfCd = other.DelivrdGdsConfCd; // 納品確認区分
            RealRecord.DeliGdsCmpltDueDate = other.DeliGdsCmpltDueDate; // 納品完了予定日
            RealRecord.AnswerDeliveryDate = other.AnswerDeliveryDate; // 回答納期
            RealRecord.BLGoodsCode = other.BLGoodsCode; // BL商品コード
            RealRecord.BLGoodsDrCode = other.BLGoodsDrCode; // BL商品コード枝番
            RealRecord.InqGoodsName = other.InqGoodsName; // 問発商品名
            RealRecord.AnsGoodsName = other.AnsGoodsName; // 回答商品名
            RealRecord.SalesOrderCount = other.SalesOrderCount; // 発注数
            RealRecord.DeliveredGoodsCount = other.DeliveredGoodsCount; // 納品数
            RealRecord.GoodsNo = other.GoodsNo; // 商品番号
            RealRecord.GoodsMakerCd = other.GoodsMakerCd; // 商品メーカーコード
            RealRecord.GoodsMakerNm = other.GoodsMakerNm; // 商品メーカー名称
            RealRecord.PureGoodsMakerCd = other.PureGoodsMakerCd; // 純正商品メーカーコード
            RealRecord.InqPureGoodsNo = other.InqPureGoodsNo; // 問発純正商品番号
            RealRecord.AnsPureGoodsNo = other.AnsPureGoodsNo; // 回答純正商品番号
            RealRecord.ListPrice = other.ListPrice; // 定価
            RealRecord.UnitPrice = other.UnitPrice; // 単価
            RealRecord.GoodsAddInfo = other.GoodsAddInfo; // 商品補足情報
            RealRecord.RoughRrofit = other.RoughRrofit; // 粗利額
            RealRecord.RoughRate = other.RoughRate; // 粗利率
            RealRecord.AnswerLimitDate = other.AnswerLimitDate; // 回答期限
            RealRecord.CommentDtl = other.CommentDtl; // 備考(明細)
            RealRecord.ShelfNo = other.ShelfNo; // 棚番
            RealRecord.PMAcptAnOdrStatus = other.PMAcptAnOdrStatus; //PM受注ステータス
            RealRecord.PMSalesSlipNum = other.PMSalesSlipNum; //PM売上伝票番号
            RealRecord.PMSalesRowNo = other.PMSalesRowNo; //PM売上行番号
            RealRecord.PmWarehouseCd = other.PmWarehouseCd; // PM倉庫コード
            RealRecord.PmWarehouseName = other.PmWarehouseName; // PM倉庫名称
            RealRecord.PmShelfNo = other.PmShelfNo; // PM棚番
            RealRecord.PmPrsntCount = other.PmPrsntCount; //PM現在個数
            // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
            RealRecord.PmMainMngWarehouseCd = other.PmMainMngWarehouseCd; // PM倉庫コード
            RealRecord.PmMainMngWarehouseName = other.PmMainMngWarehouseName; // PM倉庫名称
            RealRecord.PmMainMngShelfNo = other.PmMainMngShelfNo; // PM棚番
            RealRecord.PmMainMngPrsntCount = other.PmMainMngPrsntCount; //PM現在個数
            // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
            // ADD 2013/05/09 SCM障害№10470対応 ----------------------------------------->>>>>
            RealRecord.GoodsSpclInstruction = other.GoodsSpclInstruction; //商品規格・特記事項
            // ADD 2013/05/09 SCM障害№10470対応 -----------------------------------------<<<<<
            // ADD 2015/01/19 豊沢 SCM高速化 PMNS対応 --------------------------------->>>>>
            RealRecord.MkrSuggestRtPric = other.MkrSuggestRtPric; // メーカー希望小売価格
            RealRecord.OpenPriceDiv = other.OpenPriceDiv; // オープン価格区分
            // ADD 2015/01/19 豊沢 SCM高速化 PMNS対応 ---------------------------------<<<<<
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            RealRecord.AnsDeliDateDiv = other.AnsDeliDateDiv; // 回答納期区分
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ---------->>>>>>>>>>
            RealRecord.GoodsSpecialNtForFac = other.GoodsSpecialNtForFac;   // 商品規格・特記事項(工場向け)
            RealRecord.GoodsSpecialNtForCOw = other.GoodsSpecialNtForCOw;   // 商品規格・特記事項(カーオーナー向け)
            RealRecord.PrmSetDtlName2ForFac = other.PrmSetDtlName2ForFac;   // 優良設定詳細名称２(工場向け)
            RealRecord.PrmSetDtlName2ForCOw = other.PrmSetDtlName2ForCOw;   // 優良設定詳細名称２(カーオーナー向け)
            // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ----------<<<<<<<<<<
            // ADD 2015/02/27 SCM高速化 C向け種別対応 -------------------------------->>>>>
            RealRecord.PrmSetDtlNo2 = other.PrmSetDtlNo2;   // 優良設定詳細コード２
            RealRecord.PrmSetDtlName2 = other.PrmSetDtlName2;   // 優良設定詳細名称２
            RealRecord.StockStatusDiv = other.StockStatusDiv;   // 在庫状況区分
            // ADD 2015/02/27 SCM高速化 C向け種別対応 --------------------------------<<<<<

            // ADD 2018/04/16 田建委 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            RealRecord.InqBlUtyPtThCd = other.InqBlUtyPtThCd;   // 問発BL統一部品コード(スリーコード版)
            RealRecord.InqBlUtyPtSbCd = other.InqBlUtyPtSbCd;   // 問発BL統一部品サブコード
            RealRecord.AnsBlUtyPtThCd = other.AnsBlUtyPtThCd;   // 回答BL統一部品コード(スリーコード版)
            RealRecord.AnsBlUtyPtSbCd = other.AnsBlUtyPtSbCd;   // 回答BL統一部品サブコード
            RealRecord.AnsBLGoodsCode = other.AnsBLGoodsCode;   // 回答BL商品コード
            RealRecord.AnsBLGoodsDrCode = other.AnsBLGoodsDrCode;   // 回答BL商品コード枝番
            // ADD 2018/04/16 田建委 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        #region <User⇒WEB変換>
        /// <summary>
        /// UserDBからWebDBへの詰替え処理(問合せ先企業、拠点は別途設定が必要)
        /// </summary>
        /// <returns>SCM受注セット部品データ</returns>
        /// <remarks>
        /// <br>Update Note      :   2018/04/16 田建委</br>
        /// <br>管理番号         :   11470007-00</br>
        /// <br>                 :   SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加</br>
        /// </remarks>
        public WebSCMAcOdSetDtRecord CopyToWebSCMAcOdSetDtRecord()
        {
            RecordTypeWeb webRecord = new RecordTypeWeb();
            {
                webRecord.CreateDateTime = RealRecord.CreateDateTime; // 作成日時
                webRecord.UpdateDateTime = RealRecord.UpdateDateTime; // 更新日時
                webRecord.LogicalDeleteCode = RealRecord.LogicalDeleteCode; // 論理削除区分
                webRecord.InqOriginalEpCd = RealRecord.InqOriginalEpCd.Trim(); // 問合せ元企業コード//@@@@20230303
                webRecord.InqOriginalSecCd = RealRecord.InqOriginalSecCd; // 問合せ元拠点コード
                webRecord.InqOtherEpCd = RealRecord.InqOtherEpCd; // 問合せ先企業コード
                webRecord.InqOtherSecCd = RealRecord.InqOtherSecCd; // 問合せ先拠点コード
                webRecord.InquiryNumber = RealRecord.InquiryNumber; // 問合せ番号
                webRecord.SetPartsMkrCd = RealRecord.SetPartsMkrCd; // セット部品メーカーコード
                webRecord.SetPartsNumber = RealRecord.SetPartsNumber; // セット部品番号
                webRecord.SetPartsMainSubNo = RealRecord.SetPartsMainSubNo; // セット部品親子番号
                webRecord.GoodsDivCd = RealRecord.GoodsDivCd; // 商品種別
                webRecord.RecyclePrtKindCode = RealRecord.RecyclePrtKindCode; // リサイクル部品種別
                webRecord.RecyclePrtKindName = RealRecord.RecyclePrtKindName; // リサイクル部品種別名称
                webRecord.DeliveredGoodsDiv = RealRecord.DeliveredGoodsDiv; // 納品区分
                webRecord.HandleDivCode = RealRecord.HandleDivCode; // 取扱区分
                webRecord.GoodsShape = RealRecord.GoodsShape; // 商品形態
                webRecord.DelivrdGdsConfCd = RealRecord.DelivrdGdsConfCd; // 納品確認区分
                webRecord.DeliGdsCmpltDueDate = RealRecord.DeliGdsCmpltDueDate; // 納品完了予定日
                webRecord.AnswerDeliveryDate = RealRecord.AnswerDeliveryDate; // 回答納期
                webRecord.BLGoodsCode = RealRecord.BLGoodsCode; // BL商品コード
                webRecord.BLGoodsDrCode = RealRecord.BLGoodsDrCode; // BL商品コード枝番
                webRecord.InqGoodsName = RealRecord.InqGoodsName; // 問発商品名
                webRecord.AnsGoodsName = RealRecord.AnsGoodsName; // 回答商品名
                webRecord.SalesOrderCount = RealRecord.SalesOrderCount; // 発注数
                webRecord.DeliveredGoodsCount = RealRecord.DeliveredGoodsCount; // 納品数
                webRecord.GoodsNo = RealRecord.GoodsNo; // 商品番号
                webRecord.GoodsMakerCd = RealRecord.GoodsMakerCd; // 商品メーカーコード
                webRecord.GoodsMakerNm = RealRecord.GoodsMakerNm; // 商品メーカー名称
                webRecord.PureGoodsMakerCd = RealRecord.PureGoodsMakerCd; // 純正商品メーカーコード
                webRecord.InqPureGoodsNo = RealRecord.InqPureGoodsNo; // 問発純正商品番号
                webRecord.AnsPureGoodsNo = RealRecord.AnsPureGoodsNo; // 回答純正商品番号
                webRecord.ListPrice = RealRecord.ListPrice; // 定価
                webRecord.UnitPrice = RealRecord.UnitPrice; // 単価
                webRecord.GoodsAddInfo = RealRecord.GoodsAddInfo; // 商品補足情報
                webRecord.RoughRrofit = RealRecord.RoughRrofit; // 粗利額
                webRecord.RoughRate = RealRecord.RoughRate; // 粗利率
                webRecord.AnswerLimitDate = RealRecord.AnswerLimitDate; // 回答期限
                webRecord.CommentDtl = RealRecord.CommentDtl; // 備考(明細)
                webRecord.ShelfNo = RealRecord.ShelfNo; // 棚番
                webRecord.PMAcptAnOdrStatus = RealRecord.PMAcptAnOdrStatus; //PM受注ステータス
                webRecord.PMSalesSlipNum = RealRecord.PMSalesSlipNum; // PM売上伝票番号
                webRecord.PMSalesRowNo = RealRecord.PMSalesRowNo; //PM売上行番号
                webRecord.PmWarehouseCd = RealRecord.PmWarehouseCd; // PM倉庫コード
                webRecord.PmWarehouseName = RealRecord.PmWarehouseName; //PM倉庫名称
                webRecord.PmShelfNo = RealRecord.PmShelfNo; //PM棚番
                webRecord.PmPrsntCount = RealRecord.PmPrsntCount; //PM現在個数
                webRecord.DeliGdsCmpltDueDate = RealRecord.DeliGdsCmpltDueDate; //納品完了予定日
                // ADD 2013/05/09 SCM障害№10470対応 ----------------------------------------->>>>>
                webRecord.GoodsSpclInstruction = RealRecord.GoodsSpclInstruction; //商品規格・特記事項
                // ADD 2013/05/09 SCM障害№10470対応 -----------------------------------------<<<<<
                // ADD 2015/01/19 豊沢 SCM高速化 PMNS対応 --------------------------------->>>>>
                webRecord.MkrSuggestRtPric = RealRecord.MkrSuggestRtPric; // メーカー希望小売価格
                webRecord.OpenPriceDiv = RealRecord.OpenPriceDiv; // オープン価格区分
                // ADD 2015/01/19 豊沢 SCM高速化 PMNS対応 ---------------------------------<<<<<
                // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                webRecord.AnsDeliDateDiv = RealRecord.AnsDeliDateDiv; // 回答納期区分
                // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ---------->>>>>>>>>>
                webRecord.GoodsSpecialNtForFac = RealRecord.GoodsSpecialNtForFac;   // 商品規格・特記事項(工場向け)
                webRecord.GoodsSpecialNtForCOw = RealRecord.GoodsSpecialNtForCOw;   // 商品規格・特記事項(カーオーナー向け)
                webRecord.PrmSetDtlName2ForFac = RealRecord.PrmSetDtlName2ForFac;   // 優良設定詳細名称２(工場向け)
                webRecord.PrmSetDtlName2ForCOw = RealRecord.PrmSetDtlName2ForCOw;   // 優良設定詳細名称２(カーオーナー向け)
                // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ----------<<<<<<<<<<
                // ADD 2015/02/27 SCM高速化 C向け種別対応 -------------------------------->>>>>
                webRecord.PrmSetDtlNo2 = RealRecord.PrmSetDtlNo2;   // 優良設定詳細コード２
                webRecord.PrmSetDtlName2 = RealRecord.PrmSetDtlName2;   // 優良設定詳細名称２
                webRecord.StockStatusDiv = RealRecord.StockStatusDiv;   // 在庫状況区分
                // ADD 2015/02/27 SCM高速化 C向け種別対応 --------------------------------<<<<<

                // ADD 2018/04/16 田建委 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                webRecord.InqBlUtyPtThCd = RealRecord.InqBlUtyPtThCd;   // 問発BL統一部品コード(スリーコード版)
                webRecord.InqBlUtyPtSbCd = RealRecord.InqBlUtyPtSbCd;   // 問発BL統一部品サブコード
                webRecord.AnsBlUtyPtThCd = RealRecord.AnsBlUtyPtThCd;   // 回答BL統一部品コード(スリーコード版)
                webRecord.AnsBlUtyPtSbCd = RealRecord.AnsBlUtyPtSbCd;   // 回答BL統一部品サブコード
                webRecord.AnsBLGoodsCode = RealRecord.AnsBLGoodsCode;   // 回答BL商品コード
                webRecord.AnsBLGoodsDrCode = RealRecord.AnsBLGoodsDrCode;   // 回答BL商品コード枝番
                // ADD 2018/04/16 田建委 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            return new WebSCMAcOdSetDtRecord(webRecord);
        }
        #endregion
    }
}

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
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2011/02/09  修正内容 :テーブルレイアウト変更対応(明細取込区分の追加)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018　鈴木 正臣
// 作 成 日  2011/05/23  修正内容 : テーブルレイアウト変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/08/10  修正内容 : PCCUOE自動回答対応
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
// 修 正 日  2014/12/19  修正内容 : SCM高速化 PMNS対応 項目追加　貸出区分、メーカー希望小売価格、オープン価格区分
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

using Broadleaf.Application.UIData.WebDB;
using Broadleaf.Application.UIData.Util;
using Broadleaf.Library.Text;   // 2010/05/26 Add

namespace Broadleaf.Application.UIData
{
    using RecordType    = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlIqWork;
    using RecordTypeWeb = Broadleaf.Application.UIData.ScmOdDtInq;

    /// <summary>
    /// ユーザーDB SCM受注明細データ(問合せ・発注)のレコードクラス
    /// </summary>
    public class UserSCMOrderDetailRecord : UserSCMOrderDetailWrapper
    {
        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public UserSCMOrderDetailRecord() : base() { }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="realRecord">本物のレコード</param>
        public UserSCMOrderDetailRecord(RecordType realRecord) : base(realRecord) { }

        #endregion // </Constructor>

        /// <summary>
        /// カスタムコンストラクタ(Web⇒User変換)
        /// </summary>
        /// <param name="webRecord">SCM受発注明細データ(問合せ・発注)</param>
        /// <remarks>
        /// <br>Update Note      :   2018/04/16 田建委</br>
        /// <br>管理番号         :   11470007-00</br>
        /// <br>                 :   SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加</br>
        /// </remarks>
        public UserSCMOrderDetailRecord(WebSCMOrderDetailRecord webRecord) : base(new RecordType())
        {
            RealRecord.CreateDateTime = webRecord.CreateDateTime; // 作成日時
            RealRecord.UpdateDateTime = webRecord.UpdateDateTime; // 更新日時
            RealRecord.EnterpriseCode = webRecord.EnterpriseCode; // 企業コード
            //RealRecord.FileHeaderGuid = webRecord.FileHeaderGuid; // GUID
            //RealRecord.UpdEmployeeCode = webRecord.UpdEmployeeCode; // 更新従業員コード
            //RealRecord.UpdAssemblyId1 = webRecord.UpdAssemblyId1; // 更新アセンブリID1
            //RealRecord.UpdAssemblyId2 = webRecord.UpdAssemblyId2; // 更新アセンブリID2
            RealRecord.LogicalDeleteCode = webRecord.LogicalDeleteCode; // 論理削除区分
            RealRecord.InqOriginalEpCd = webRecord.InqOriginalEpCd.Trim(); // 問合せ元企業コード//@@@@20230303
            RealRecord.InqOriginalSecCd = webRecord.InqOriginalSecCd; // 問合せ元拠点コード
            RealRecord.InqOtherEpCd = webRecord.InqOtherEpCd; // 問合せ先企業コード
            RealRecord.InqOtherSecCd = webRecord.InqOtherSecCd; // 問合せ先拠点コード
            RealRecord.InquiryNumber = webRecord.InquiryNumber; // 問合せ番号
            RealRecord.UpdateDate = webRecord.UpdateDate; // 更新年月日
            RealRecord.UpdateTime = webRecord.UpdateTime; // 更新時分秒ミリ秒
            RealRecord.InqRowNumber = webRecord.InqRowNumber; // 問合せ行番号
            RealRecord.InqRowNumDerivedNo = webRecord.InqRowNumDerivedNo; // 問合せ行番号枝番
            RealRecord.InqOrgDtlDiscGuid = webRecord.InqOrgDtlDiscGuid; // 問合せ元明細識別GUID
            RealRecord.InqOthDtlDiscGuid = webRecord.InqOthDtlDiscGuid; // 問合せ先明細識別GUID
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
            //RealRecord.GoodsName = webRecord.GoodsName; // 商品名（カナ）
            RealRecord.InqGoodsName = webRecord.InqGoodsName; // 問発商品名
            RealRecord.AnsGoodsName = webRecord.AnsGoodsName; // 回答商品名
            RealRecord.SalesOrderCount = webRecord.SalesOrderCount; // 発注数
            RealRecord.DeliveredGoodsCount = webRecord.DeliveredGoodsCount; // 納品数
            RealRecord.GoodsNo = webRecord.GoodsNo; // 商品番号
            RealRecord.GoodsMakerCd = webRecord.GoodsMakerCd; // 商品メーカーコード
            RealRecord.GoodsMakerNm = webRecord.GoodsMakerNm; // 商品メーカー名称
            RealRecord.PureGoodsMakerCd = webRecord.PureGoodsMakerCd; // 純正商品メーカーコード
            //RealRecord.PureGoodsNo = webRecord.PureGoodsNo; // 純正商品番号
            RealRecord.InqPureGoodsNo = webRecord.InqPureGoodsNo; // 問発純正商品番号
            RealRecord.AnsPureGoodsNo = webRecord.AnsPureGoodsNo; // 回答純正商品番号
            RealRecord.ListPrice = webRecord.ListPrice; // 定価
            RealRecord.UnitPrice = webRecord.UnitPrice; // 単価
            RealRecord.GoodsAddInfo = webRecord.GoodsAddInfo; // 商品補足情報
            RealRecord.RoughRrofit = webRecord.RoughRrofit; // 粗利額
            RealRecord.RoughRate = webRecord.RoughRate; // 粗利率
            RealRecord.AnswerLimitDate = webRecord.AnswerLimitDate; // 回答期限
            RealRecord.CommentDtl = webRecord.CommentDtl; // 備考(明細)
            //RealRecord.AppendingFileDtl = webRecord.AppendingFileDtl; // 添付ファイル(明細)
            //RealRecord.AppendingFileNmDtl = webRecord.AppendingFileNmDtl; // 添付ファイル名(明細)
            RealRecord.ShelfNo = webRecord.ShelfNo; // 棚番
            RealRecord.AdditionalDivCd = webRecord.AdditionalDivCd; // 追加区分
            RealRecord.CorrectDivCD = webRecord.CorrectDivCD; // 訂正区分
            //RealRecord.AcptAnOdrStatus = webRecord.AcptAnOdrStatus; // 受注ステータス
            //RealRecord.SalesSlipNum = webRecord.SalesSlipNum; // 売上伝票番号
            RealRecord.InqOrdDivCd = webRecord.InqOrdDivCd; // 問合せ・発注種別
            RealRecord.DisplayOrder = webRecord.DisplayOrder; // 表示順位

            // 2010/05/26 Add >>>
            RealRecord.CancelCndtinDiv = webRecord.CancelCndtinDiv; // キャンセル状態区分
            RealRecord.AcptAnOdrStatus = webRecord.AcptAnOdrStatus; // 受注ステータス
            RealRecord.SalesSlipNum = webRecord.SalesSlipNum; // 売上伝票番号
            RealRecord.SalesRowNo = webRecord.SalesRowNo; // 売上行番号
            // 2010/05/26 Add <<<
            // 2011/02/09 Add >>>
            RealRecord.DtlTakeinDivCd = webRecord.DtlTakeinDivCd; // 明細取込区分
            // 2011/02/09 Add <<<
            // --- ADD m.suzuki 2011/05/23 ---------->>>>>
            RealRecord.WarehouseCode = webRecord.PmWarehouseCd; // PM倉庫コード
            RealRecord.WarehouseName = webRecord.PmWarehouseName; // PM倉庫名称
            RealRecord.WarehouseShelfNo = webRecord.PmShelfNo; // 棚番
            // --- ADD m.suzuki 2011/05/23 ----------<<<<<

            // ----- ADD 2011/08/10 ----- >>>>>
            RealRecord.PmPrsntCount = webRecord.PmPrsntCount; // PM現在庫数
            RealRecord.SetPartsMkrCd = webRecord.SetPartsMkrCd; // セット部品メーカーコード
            RealRecord.SetPartsNumber = webRecord.SetPartsNumber; // セット部品番号
            RealRecord.SetPartsMainSubNo = webRecord.SetPartsMainSubNo; // セット部品親子番号
            // ----- ADD 2011/08/10 ----- <<<<<

            // ----- ADD 2011/10/10 ----- >>>>>
            RealRecord.CampaignCode = webRecord.CampaignCode;
            // ----- ADD 2011/10/10 ----- <<<<<

            // 2012/01/16 Add >>>
            RealRecord.GoodsSpecialNote = webRecord.GoodsSpecialNote;
            // 2012/01/16 Add <<<

            // --- ADD T.Nishi 2012/05/30 ---------->>>>>
            RealRecord.AutoEstimatePartsCd = webRecord.AutoEstimatePartsCd;
            // --- ADD T.Nishi 2012/05/30 ----------<<<<<

            // ADD 2013/05/08 吉岡 2013/06/18配信 SCM障害№10308,№10528 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            RealRecord.SalesTotalTaxInc = webRecord.SalesTotalTaxInc; // 売上伝票合計（税込）
            RealRecord.SalesTotalTaxExc = webRecord.SalesTotalTaxExc; // 売上伝票合計（税抜）
            RealRecord.ScmConsTaxLayMethod = webRecord.ScmConsTaxLayMethod; // SCM消費税転嫁方式
            RealRecord.ConsTaxRate = webRecord.ConsTaxRate; // 消費税税率
            RealRecord.ScmFractionProcCd = webRecord.ScmFractionProcCd; // SCM端数処理区分
            RealRecord.AccRecConsTax = webRecord.AccRecConsTax; // 売掛消費税
            RealRecord.PMSalesDate = webRecord.PMSalesDate; // PM売上日
            RealRecord.SuppSlpPrtTime = webRecord.SuppSlpPrtTime; // 仕入先伝票発行時刻
            RealRecord.SalesMoneyTaxInc = webRecord.SalesMoneyTaxInc; // 売上金額（税込み）
            RealRecord.SalesMoneyTaxExc = webRecord.SalesMoneyTaxExc; // 売上金額（税抜き）
            // ADD 2013/05/08 吉岡 2013/06/18配信 SCM障害№10308,№10528 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2013/05/15 吉岡 2013/06/18配信 SCM障害№10410 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            RealRecord.DataInputSystem = webRecord.DataInputSystem; // データ入力システム
            // ADD 2013/05/15 吉岡 2013/06/18配信 SCM障害№10410 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2014/06/04 SCM仕掛一覧№10659対応 ------------------------------------------------------->>>>>
            RealRecord.PrmSetDtlNo2 = webRecord.PrmSetDtlNo2; // 優良設定詳細コード２
            RealRecord.PrmSetDtlName2 = webRecord.PrmSetDtlName2; // 優良設定詳細名称２
            RealRecord.StockStatusDiv = webRecord.StockStatusDiv; // 在庫状況区分
            // ADD 2014/06/04 SCM仕掛一覧№10659対応 -------------------------------------------------------<<<<<
            // ADD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
            RealRecord.RentDiv = webRecord.RentDiv; // 貸出区分            
            RealRecord.MkrSuggestRtPric = webRecord.MkrSuggestRtPric; // メーカー希望小売価格
            RealRecord.OpenPriceDiv = webRecord.OpenPriceDiv; // オープン価格区分    
            // ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<
            // ADD 2015/01/19 豊沢 リコメンド対応 --------------------->>>>>
            RealRecord.BgnGoodsDiv = webRecord.BgnGoodsDiv; // お買得商品選択区分
            // ADD 2015/01/19 豊沢 リコメンド対応 ---------------------<<<<<
            // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 ----------------------------->>>>>
            RealRecord.ModelPrtsAdptYm = webRecord.ModelPrtsAdptYm; // 型式別部品採用年月
            RealRecord.ModelPrtsAblsYm = webRecord.ModelPrtsAblsYm; // 型式別部品廃止年月
            RealRecord.ModelPrtsAdptFrameNo = webRecord.ModelPrtsAdptFrameNo; // 型式別部品採用車台番号
            RealRecord.ModelPrtsAblsFrameNo = webRecord.ModelPrtsAblsFrameNo; // 型式別部品廃止車台番号
            // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 -----------------------------<<<<<
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            RealRecord.AnsDeliDateDiv = webRecord.AnsDeliDateDiv; // 回答納期区分
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ---------->>>>>>>>>>
            RealRecord.GoodsSpecialNtForFac = webRecord.GoodsSpecialNtForFac;   // 商品規格・特記事項(工場向け)
            RealRecord.GoodsSpecialNtForCOw = webRecord.GoodsSpecialNtForCOw;   // 商品規格・特記事項(カーオーナー向け)
            RealRecord.PrmSetDtlName2ForFac = webRecord.PrmSetDtlName2ForFac;   // 優良設定詳細名称２(工場向け)
            RealRecord.PrmSetDtlName2ForCOw = webRecord.PrmSetDtlName2ForCOw;   // 優良設定詳細名称２(カーオーナー向け)
            // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ----------<<<<<<<<<<

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
        public UserSCMOrderDetailRecord(UserSCMOrderDetailRecord other)
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
            RealRecord.UpdateDate = other.UpdateDate; // 更新年月日
            RealRecord.UpdateTime = other.UpdateTime; // 更新時分秒ミリ秒
            RealRecord.InqRowNumber = other.InqRowNumber; // 問合せ行番号
            RealRecord.InqRowNumDerivedNo = other.InqRowNumDerivedNo; // 問合せ行番号枝番
            RealRecord.InqOrgDtlDiscGuid = other.InqOrgDtlDiscGuid; // 問合せ元明細識別GUID
            RealRecord.InqOthDtlDiscGuid = other.InqOthDtlDiscGuid; // 問合せ先明細識別GUID
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
            //RealRecord.GoodsName = other.GoodsName; // 商品名（カナ）
            RealRecord.InqGoodsName = other.InqGoodsName; // 問発商品名
            RealRecord.AnsGoodsName = other.AnsGoodsName; // 回答商品名
            RealRecord.SalesOrderCount = other.SalesOrderCount; // 発注数
            RealRecord.DeliveredGoodsCount = other.DeliveredGoodsCount; // 納品数
            RealRecord.GoodsNo = other.GoodsNo; // 商品番号
            RealRecord.GoodsMakerCd = other.GoodsMakerCd; // 商品メーカーコード
            RealRecord.GoodsMakerNm = other.GoodsMakerNm; // 商品メーカー名称
            RealRecord.PureGoodsMakerCd = other.PureGoodsMakerCd; // 純正商品メーカーコード
            //RealRecord.PureGoodsNo = other.PureGoodsNo; // 純正商品番号
            RealRecord.InqPureGoodsNo = other.InqPureGoodsNo; // 純正商品番号
            RealRecord.AnsPureGoodsNo = other.AnsPureGoodsNo; // 純正商品番号
            RealRecord.ListPrice = other.ListPrice; // 定価
            RealRecord.UnitPrice = other.UnitPrice; // 単価
            RealRecord.GoodsAddInfo = other.GoodsAddInfo; // 商品補足情報
            RealRecord.RoughRrofit = other.RoughRrofit; // 粗利額
            RealRecord.RoughRate = other.RoughRate; // 粗利率
            RealRecord.AnswerLimitDate = other.AnswerLimitDate; // 回答期限
            RealRecord.CommentDtl = other.CommentDtl; // 備考(明細)
            RealRecord.AppendingFileDtl = other.AppendingFileDtl; // 添付ファイル(明細)
            RealRecord.AppendingFileNmDtl = other.AppendingFileNmDtl; // 添付ファイル名(明細)
            RealRecord.ShelfNo = other.ShelfNo; // 棚番
            RealRecord.AdditionalDivCd = other.AdditionalDivCd; // 追加区分
            RealRecord.CorrectDivCD = other.CorrectDivCD; // 訂正区分
            //RealRecord.AcptAnOdrStatus = other.AcptAnOdrStatus; // 受注ステータス
            //RealRecord.SalesSlipNum = other.SalesSlipNum; // 売上伝票番号
            RealRecord.InqOrdDivCd = other.InqOrdDivCd; // 問合せ・発注種別
            RealRecord.DisplayOrder = other.DisplayOrder; // 表示順位

            // 2010/05/26 Add >>>
            RealRecord.CancelCndtinDiv = other.CancelCndtinDiv; // キャンセル状態区分
            RealRecord.AcptAnOdrStatus = other.AcptAnOdrStatus; // 受注ステータス
            RealRecord.SalesSlipNum = other.SalesSlipNum; // 売上伝票番号
            RealRecord.SalesRowNo = other.SalesRowNo; // 売上行番号
            // 2010/05/26 Add <<<

            // 2011/02/09 Add >>>
            RealRecord.DtlTakeinDivCd = other.DtlTakeinDivCd; // 明細取込区分
            // 2011/02/09 Add <<<
            // --- ADD m.suzuki 2011/05/23 ---------->>>>>
            RealRecord.WarehouseCode = other.PmWarehouseCd; // PM倉庫コード
            RealRecord.WarehouseName = other.PmWarehouseName; // PM倉庫名称
            RealRecord.WarehouseShelfNo = other.PmShelfNo; // 棚番
            // --- ADD m.suzuki 2011/05/23 ----------<<<<<
            // 2011/10/10 Add >>>
            RealRecord.CampaignCode = other.CampaignCode; // キャンペーンコード
            // 2011/10/10 Add <<<

            // 2012/01/16 Add >>>
            RealRecord.GoodsSpecialNote = other.GoodsSpecialNote;
            // 2012/01/16 Add <<<

            // --- ADD T.Nishi 2012/05/30 ---------->>>>>
            RealRecord.AutoEstimatePartsCd = other.AutoEstimatePartsCd;
            // --- ADD T.Nishi 2012/05/30 ----------<<<<<

            // ADD 2013/05/08 吉岡 2013/06/18配信 SCM障害№10308,№10528 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            RealRecord.SalesTotalTaxInc = other.SalesTotalTaxInc; // 売上伝票合計（税込）
            RealRecord.SalesTotalTaxExc = other.SalesTotalTaxExc; // 売上伝票合計（税抜）
            RealRecord.ScmConsTaxLayMethod = other.ScmConsTaxLayMethod; // SCM消費税転嫁方式
            RealRecord.ConsTaxRate = other.ScmConsTaxLayMethod; // 消費税税率
            RealRecord.ScmFractionProcCd = other.ScmConsTaxLayMethod; // SCM端数処理区分
            RealRecord.AccRecConsTax = other.ScmConsTaxLayMethod; // 売掛消費税
            RealRecord.PMSalesDate = other.ScmConsTaxLayMethod; // PM売上日
            RealRecord.SuppSlpPrtTime = other.ScmConsTaxLayMethod; // 仕入先伝票発行時刻
            RealRecord.SalesMoneyTaxInc = other.SalesMoneyTaxInc; // 売上金額（税込み）
            RealRecord.SalesMoneyTaxExc = other.SalesMoneyTaxExc; // 売上金額（税抜き）
            // ADD 2013/05/08 吉岡 2013/06/18配信 SCM障害№10308,№10528 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2013/05/15 吉岡 2013/06/18配信 SCM障害№10410 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            RealRecord.DataInputSystem = other.DataInputSystem; // データ入力システム
            // ADD 2013/05/15 吉岡 2013/06/18配信 SCM障害№10410 ---------<<<<<<<<<<<<<<<<<<<<<<<<<        

            // ADD 2014/06/04 SCM仕掛一覧№10659対応 ------------------------------------------------------->>>>>
            RealRecord.PrmSetDtlNo2 = other.PrmSetDtlNo2; // 優良設定詳細コード２
            RealRecord.PrmSetDtlName2 = other.PrmSetDtlName2; // 優良設定詳細名称２
            RealRecord.StockStatusDiv = other.StockStatusDiv; // 在庫状況区分
            // ADD 2014/06/04 SCM仕掛一覧№10659対応 -------------------------------------------------------<<<<<

            // ADD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
            RealRecord.RentDiv = other.RentDiv; // 貸出区分            
            RealRecord.MkrSuggestRtPric = other.MkrSuggestRtPric; // メーカー希望小売価格
            RealRecord.OpenPriceDiv = other.OpenPriceDiv; // オープン価格区分    
            // ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<

            // ADD 2015/01/19 豊沢 リコメンド対応 --------------------->>>>>
            RealRecord.BgnGoodsDiv = other.BgnGoodsDiv; // お買得商品選択区分
            // ADD 2015/01/19 豊沢 リコメンド対応 ---------------------<<<<<

            // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 ----------------------------->>>>>
            RealRecord.ModelPrtsAdptYm = other.ModelPrtsAdptYm; // 型式別部品採用年月
            RealRecord.ModelPrtsAblsYm = other.ModelPrtsAblsYm; // 型式別部品廃止年月
            RealRecord.ModelPrtsAdptFrameNo = other.ModelPrtsAdptFrameNo; // 型式別部品採用車台番号
            RealRecord.ModelPrtsAblsFrameNo = other.ModelPrtsAblsFrameNo; // 型式別部品廃止車台番号
            // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 -----------------------------<<<<<
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            RealRecord.AnsDeliDateDiv = other.AnsDeliDateDiv; // 回答納期区分
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ---------->>>>>>>>>>
            RealRecord.GoodsSpecialNtForFac = other.GoodsSpecialNtForFac;    // 商品規格・特記事項(工場向け)
            RealRecord.GoodsSpecialNtForCOw = other.GoodsSpecialNtForCOw;    // 商品規格・特記事項(カーオーナー向け)
            RealRecord.PrmSetDtlName2ForFac = other.PrmSetDtlName2ForFac;    // 優良設定詳細名称２(工場向け)
            RealRecord.PrmSetDtlName2ForCOw = other.PrmSetDtlName2ForCOw;    // 優良設定詳細名称２(カーオーナー向け)
            // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ----------<<<<<<<<<<

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
        /// <returns>SCM受発注明細データ(問合せ・発注)</returns>
        /// <remarks>
        /// <br>Update Note      :   2018/04/16 田建委</br>
        /// <br>管理番号         :   11470007-00</br>
        /// <br>                 :   SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加</br>
        /// </remarks>
        public WebSCMOrderDetailRecord CopyToWebSCMOrderDetailRecord()
        {
            RecordTypeWeb webRecord = new RecordTypeWeb();
            {
                //webRecord.CreateDateTime = RealRecord.CreateDateTime; // 作成日時
                //webRecord.UpdateDateTime = RealRecord.UpdateDateTime; // 更新日時
                ////webRecord.EnterpriseCode = RealRecord.EnterpriseCode; // 企業コード
                ////webRecord.FileHeaderGuid = RealRecord.FileHeaderGuid; // GUID
                ////webRecord.UpdEmployeeCode = RealRecord.UpdEmployeeCode; // 更新従業員コード
                ////webRecord.UpdAssemblyId1 = RealRecord.UpdAssemblyId1; // 更新アセンブリID1
                ////webRecord.UpdAssemblyId2 = RealRecord.UpdAssemblyId2; // 更新アセンブリID2
                //webRecord.LogicalDeleteCode = RealRecord.LogicalDeleteCode; // 論理削除区分
                //webRecord.InqOriginalEpCd = RealRecord.InqOriginalEpCd; // 問合せ元企業コード
                //webRecord.InqOriginalSecCd = RealRecord.InqOriginalSecCd; // 問合せ元拠点コード
                //webRecord.InqOtherEpCd = RealRecord.InqOtherEpCd; // 問合せ先企業コード
                //webRecord.InqOtherSecCd = RealRecord.InqOtherSecCd; // 問合せ先拠点コード
                //webRecord.InquiryNumber = RealRecord.InquiryNumber; // 問合せ番号
                //webRecord.UpdateDate = RealRecord.UpdateDate; // 更新年月日
                //webRecord.UpdateTime = RealRecord.UpdateTime; // 更新時分秒ミリ秒
                //webRecord.InqRowNumber = RealRecord.InqRowNumber; // 問合せ行番号
                //webRecord.InqRowNumDerivedNo = RealRecord.InqRowNumDerivedNo; // 問合せ行番号枝番
                //webRecord.InqOrgDtlDiscGuid = RealRecord.InqOrgDtlDiscGuid; // 問合せ元明細識別GUID
                //webRecord.InqOthDtlDiscGuid = RealRecord.InqOthDtlDiscGuid; // 問合せ先明細識別GUID
                //webRecord.GoodsDivCd = RealRecord.GoodsDivCd; // 商品種別
                //webRecord.RecyclePrtKindCode = RealRecord.RecyclePrtKindCode; // リサイクル部品種別
                //webRecord.RecyclePrtKindName = RealRecord.RecyclePrtKindName; // リサイクル部品種別名称
                //webRecord.DeliveredGoodsDiv = RealRecord.DeliveredGoodsDiv; // 納品区分
                //webRecord.HandleDivCode = RealRecord.HandleDivCode; // 取扱区分
                //webRecord.GoodsShape = RealRecord.GoodsShape; // 商品形態
                //webRecord.DelivrdGdsConfCd = RealRecord.DelivrdGdsConfCd; // 納品確認区分
                //webRecord.DeliGdsCmpltDueDate = RealRecord.DeliGdsCmpltDueDate; // 納品完了予定日
                //webRecord.AnswerDeliveryDate = RealRecord.AnswerDeliveryDate; // 回答納期
                //webRecord.BLGoodsCode = RealRecord.BLGoodsCode; // BL商品コード
                //webRecord.BLGoodsDrCode = RealRecord.BLGoodsDrCode; // BL商品コード枝番
                //webRecord.GoodsName = RealRecord.GoodsName; // 商品名（カナ）
                //webRecord.SalesOrderCount = RealRecord.SalesOrderCount; // 発注数
                //webRecord.DeliveredGoodsCount = RealRecord.DeliveredGoodsCount; // 納品数
                //webRecord.GoodsNo = RealRecord.GoodsNo; // 商品番号
                //webRecord.GoodsMakerCd = RealRecord.GoodsMakerCd; // 商品メーカーコード
                //webRecord.PureGoodsMakerCd = RealRecord.PureGoodsMakerCd; // 純正商品メーカーコード
                //webRecord.PureGoodsNo = RealRecord.PureGoodsNo; // 純正商品番号
                //webRecord.ListPrice = RealRecord.ListPrice; // 定価
                //webRecord.UnitPrice = RealRecord.UnitPrice; // 単価
                //webRecord.GoodsAddInfo = RealRecord.GoodsAddInfo; // 商品補足情報
                //webRecord.RoughRrofit = RealRecord.RoughRrofit; // 粗利額
                //webRecord.RoughRate = RealRecord.RoughRate; // 粗利率
                ////webRecord.AnswerLimitDate = RealRecord.AnswerLimitDate; // 回答期限
                //webRecord.CommentDtl = RealRecord.CommentDtl; // 備考(明細)
                ////webRecord.AppendingFileDtl = RealRecord.AppendingFileDtl; // 添付ファイル(明細)
                ////webRecord.AppendingFileNmDtl = RealRecord.AppendingFileNmDtl; // 添付ファイル名(明細)
                //webRecord.ShelfNo = RealRecord.ShelfNo; // 棚番
                //webRecord.AdditionalDivCd = RealRecord.AdditionalDivCd; // 追加区分
                //webRecord.CorrectDivCD = RealRecord.CorrectDivCD; // 訂正区分
                ////webRecord.AcptAnOdrStatus = RealRecord.AcptAnOdrStatus; // 受注ステータス
                ////webRecord.SalesSlipNum = RealRecord.SalesSlipNum; // 売上伝票番号
                //webRecord.InqOrdDivCd = RealRecord.InqOrdDivCd; // 問合せ・発注種別
                //webRecord.DisplayOrder = RealRecord.DisplayOrder; // 表示順位

                webRecord.CreateDateTime = RealRecord.CreateDateTime; // 作成日時
                webRecord.UpdateDateTime = RealRecord.UpdateDateTime; // 更新日時
                //webRecord.EnterpriseCode = RealRecord.EnterpriseCode; // 企業コード
                //webRecord.FileHeaderGuid = RealRecord.FileHeaderGuid; // GUID
                //webRecord.UpdEmployeeCode = RealRecord.UpdEmployeeCode; // 更新従業員コード
                //webRecord.UpdAssemblyId1 = RealRecord.UpdAssemblyId1; // 更新アセンブリID1
                //webRecord.UpdAssemblyId2 = RealRecord.UpdAssemblyId2; // 更新アセンブリID2
                webRecord.LogicalDeleteCode = RealRecord.LogicalDeleteCode; // 論理削除区分
                webRecord.InqOriginalEpCd = RealRecord.InqOriginalEpCd.Trim(); // 問合せ元企業コード//@@@@20230303
                webRecord.InqOriginalSecCd = RealRecord.InqOriginalSecCd; // 問合せ元拠点コード
                webRecord.InqOtherEpCd = RealRecord.InqOtherEpCd; // 問合せ先企業コード
                webRecord.InqOtherSecCd = RealRecord.InqOtherSecCd; // 問合せ先拠点コード
                webRecord.InquiryNumber = RealRecord.InquiryNumber; // 問合せ番号
                webRecord.UpdateDate = RealRecord.UpdateDate; // 更新年月日
                webRecord.UpdateTime = RealRecord.UpdateTime; // 更新時分秒ミリ秒
                webRecord.InqRowNumber = RealRecord.InqRowNumber; // 問合せ行番号
                webRecord.InqRowNumDerivedNo = RealRecord.InqRowNumDerivedNo; // 問合せ行番号枝番
                webRecord.InqOrgDtlDiscGuid = RealRecord.InqOrgDtlDiscGuid; // 問合せ元明細識別GUID
                webRecord.InqOthDtlDiscGuid = RealRecord.InqOthDtlDiscGuid; // 問合せ先明細識別GUID
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
                //webRecord.GoodsName = RealRecord.GoodsName; // 商品名（カナ）
                webRecord.InqGoodsName = RealRecord.InqGoodsName; // 問発商品名
                webRecord.AnsGoodsName = RealRecord.AnsGoodsName; // 回答商品名
                webRecord.SalesOrderCount = RealRecord.SalesOrderCount; // 発注数
                webRecord.DeliveredGoodsCount = RealRecord.DeliveredGoodsCount; // 納品数
                webRecord.GoodsNo = RealRecord.GoodsNo; // 商品番号
                webRecord.GoodsMakerCd = RealRecord.GoodsMakerCd; // 商品メーカーコード
                webRecord.GoodsMakerNm = RealRecord.GoodsMakerNm; // 商品メーカー名称
                webRecord.PureGoodsMakerCd = RealRecord.PureGoodsMakerCd; // 純正商品メーカーコード
                //webRecord.PureGoodsNo = RealRecord.PureGoodsNo; // 純正商品番号
                webRecord.InqPureGoodsNo = RealRecord.InqPureGoodsNo; // 純正商品番号
                webRecord.AnsPureGoodsNo = RealRecord.AnsPureGoodsNo; // 純正商品番号
                webRecord.ListPrice = RealRecord.ListPrice; // 定価
                webRecord.UnitPrice = RealRecord.UnitPrice; // 単価
                webRecord.GoodsAddInfo = RealRecord.GoodsAddInfo; // 商品補足情報
                webRecord.RoughRrofit = RealRecord.RoughRrofit; // 粗利額
                webRecord.RoughRate = RealRecord.RoughRate; // 粗利率
                webRecord.AnswerLimitDate = RealRecord.AnswerLimitDate; // 回答期限
                webRecord.CommentDtl = RealRecord.CommentDtl; // 備考(明細)
                //webRecord.AppendingFileDtl = RealRecord.AppendingFileDtl; // 添付ファイル(明細)
                //webRecord.AppendingFileNmDtl = RealRecord.AppendingFileNmDtl; // 添付ファイル名(明細)
                webRecord.ShelfNo = RealRecord.ShelfNo; // 棚番
                webRecord.AdditionalDivCd = RealRecord.AdditionalDivCd; // 追加区分
                webRecord.CorrectDivCD = RealRecord.CorrectDivCD; // 訂正区分
                //webRecord.AcptAnOdrStatus = RealRecord.AcptAnOdrStatus; // 受注ステータス
                //webRecord.SalesSlipNum = RealRecord.SalesSlipNum; // 売上伝票番号
                webRecord.InqOrdDivCd = RealRecord.InqOrdDivCd; // 問合せ・発注種別
                webRecord.DisplayOrder = RealRecord.DisplayOrder; // 表示順位

                // 2010/05/26 Add >>>
                webRecord.CancelCndtinDiv = RealRecord.CancelCndtinDiv; // キャンセル状態区分
                webRecord.PMAcptAnOdrStatus = RealRecord.AcptAnOdrStatus; // 受注ステータス
                webRecord.PMSalesSlipNum = TStrConv.StrToIntDef(RealRecord.SalesSlipNum.Trim(), 0); // 売上伝票番号
                webRecord.PMSalesRowNo = RealRecord.SalesRowNo; // 売上行番号
                // 2010/05/26 Add <<<

                // 2011/02/09 Add >>>
                webRecord.DtlTakeinDivCd = RealRecord.DtlTakeinDivCd; // 明細取込区分
                // 2011/02/09 Add <<<
                // --- ADD m.suzuki 2011/05/23 ---------->>>>>
                webRecord.PmWarehouseCd = RealRecord.WarehouseCode; // PM倉庫コード
                webRecord.PmWarehouseName = RealRecord.WarehouseName; // PM倉庫名称
                webRecord.PmShelfNo = RealRecord.WarehouseShelfNo; // 棚番
                // --- ADD m.suzuki 2011/05/23 ----------<<<<<

                // ----- ADD 2011/10/10 ----- >>>>>
                webRecord.CampaignCode = RealRecord.CampaignCode;
                // ----- ADD 2011/10/10 ----- <<<<<

                // 2012/01/16 Add >>>
                webRecord.GoodsSpecialNote = RealRecord.GoodsSpecialNote;
                // 2012/01/16 Add <<<

                // --- ADD T.Nishi 2012/05/30 ---------->>>>>
                webRecord.AutoEstimatePartsCd = RealRecord.AutoEstimatePartsCd;
                // --- ADD T.Nishi 2012/05/30 ----------<<<<<

                // ADD 2013/05/08 吉岡 2013/06/18配信 SCM障害№10308,№10528 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                webRecord.SalesTotalTaxInc = RealRecord.SalesTotalTaxInc; // 売上伝票合計（税込）
                webRecord.SalesTotalTaxExc = RealRecord.SalesTotalTaxExc; // 売上伝票合計（税抜）
                webRecord.ScmConsTaxLayMethod = RealRecord.ScmConsTaxLayMethod; // SCM消費税転嫁方式
                webRecord.ConsTaxRate = RealRecord.ConsTaxRate; // 消費税税率
                webRecord.ScmFractionProcCd = RealRecord.ScmFractionProcCd; // SCM端数処理区分
                webRecord.AccRecConsTax = RealRecord.AccRecConsTax; // 売掛消費税
                //webRecord.PMSalesDate = DateTime.ParseExact(RealRecord.PMSalesDate.ToString(), "yyyyMMdd", null); // PM売上日
                DateTime PMSalesDate;
                if (DateTime.TryParseExact(RealRecord.PMSalesDate.ToString(), "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out PMSalesDate))
                {
                    webRecord.PMSalesDate = PMSalesDate;    // PM売上日
                }
                webRecord.SuppSlpPrtTime = RealRecord.SuppSlpPrtTime; // 仕入先伝票発行時刻
                webRecord.SalesMoneyTaxInc = RealRecord.SalesMoneyTaxInc; // 売上金額（税込み）
                webRecord.SalesMoneyTaxExc = RealRecord.SalesMoneyTaxExc; // 売上金額（税抜き）
                // ADD 2013/05/08 吉岡 2013/06/18配信 SCM障害№10308,№10528 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2013/05/15 吉岡 2013/06/18配信 SCM障害№10410 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                webRecord.DataInputSystem = RealRecord.DataInputSystem; // データ入力システム
                // ADD 2013/05/15 吉岡 2013/06/18配信 SCM障害№10410 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2014/06/04 SCM仕掛一覧№10659対応 ------------------------------------------------------->>>>>
                webRecord.PrmSetDtlNo2 = RealRecord.PrmSetDtlNo2; // 優良設定詳細コード２
                webRecord.PrmSetDtlName2 = RealRecord.PrmSetDtlName2; // 優良設定詳細名称２
                webRecord.StockStatusDiv = RealRecord.StockStatusDiv; // 在庫状況区分
                // ADD 2014/06/04 SCM仕掛一覧№10659対応 -------------------------------------------------------<<<<<
                // ADD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
                webRecord.RentDiv = RealRecord.RentDiv; // 貸出区分            
                webRecord.MkrSuggestRtPric = RealRecord.MkrSuggestRtPric; // メーカー希望小売価格
                webRecord.OpenPriceDiv = RealRecord.OpenPriceDiv; // オープン価格区分    
                // ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<
                // ADD 2015/01/19 豊沢 リコメンド対応 --------------------->>>>>
                webRecord.BgnGoodsDiv = RealRecord.BgnGoodsDiv; // お買得商品選択区分
                // ADD 2015/01/19 豊沢 リコメンド対応 ---------------------<<<<<
                // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 ----------------------------->>>>>
                webRecord.ModelPrtsAdptYm = SCMEntityUtil.ConvertModelPrtsAdptYm(RealRecord.ModelPrtsAdptYm); // 型式別部品採用年月
                webRecord.ModelPrtsAblsYm = SCMEntityUtil.ConvertModelPrtsAdptYm(RealRecord.ModelPrtsAblsYm); // 型式別部品廃止年月
                webRecord.ModelPrtsAdptFrameNo = RealRecord.ModelPrtsAdptFrameNo; // 型式別部品採用車台番号
                webRecord.ModelPrtsAblsFrameNo = RealRecord.ModelPrtsAblsFrameNo; // 型式別部品廃止車台番号
                // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 -----------------------------<<<<<
                // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                webRecord.AnsDeliDateDiv = RealRecord.AnsDeliDateDiv; // 回答納期区分
                // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ---------->>>>>>>>>>
                webRecord.GoodsSpecialNtForFac = RealRecord.GoodsSpecialNtForFac;   // 商品規格・特記事項(工場向け)
                webRecord.GoodsSpecialNtForCOw = RealRecord.GoodsSpecialNtForCOw;   // 商品規格・特記事項(カーオーナー向け)
                webRecord.PrmSetDtlName2ForFac = RealRecord.PrmSetDtlName2ForFac;   // 優良設定詳細名称２(工場向け)
                webRecord.PrmSetDtlName2ForCOw = RealRecord.PrmSetDtlName2ForCOw;   // 優良設定詳細名称２(カーオーナー向け)
                // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ----------<<<<<<<<<<

                // ADD 2018/04/16 田建委 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                webRecord.InqBlUtyPtThCd = RealRecord.InqBlUtyPtThCd;   // 問発BL統一部品コード(スリーコード版)
                webRecord.InqBlUtyPtSbCd = RealRecord.InqBlUtyPtSbCd;   // 問発BL統一部品サブコード
                webRecord.AnsBlUtyPtThCd = RealRecord.AnsBlUtyPtThCd;   // 回答BL統一部品コード(スリーコード版)
                webRecord.AnsBlUtyPtSbCd = RealRecord.AnsBlUtyPtSbCd;   // 回答BL統一部品サブコード
                webRecord.AnsBLGoodsCode = RealRecord.AnsBLGoodsCode;   // 回答BL商品コード
                webRecord.AnsBLGoodsDrCode = RealRecord.AnsBLGoodsDrCode;   // 回答BL商品コード枝番
                // ADD 2018/04/16 田建委 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            return new WebSCMOrderDetailRecord(webRecord);
        }
        #endregion
    }
}

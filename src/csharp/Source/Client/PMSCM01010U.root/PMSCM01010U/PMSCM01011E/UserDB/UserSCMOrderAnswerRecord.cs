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
// 作 成 日  2010/05/26  修正内容 :テーブルレイアウト変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2011/02/09  修正内容 :テーブルレイアウト変更対応(明細取込区分の追加)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018　鈴木 正臣
// 作 成 日  2011/05/23  修正内容 : テーブルレイアウト変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : LDNS wangqx
// 作 成 日  2011/08/08  修正内容 : テーブルレイアウト変更対応
//----------------------------------------------------------------------------//
// 管理番号  10800003-00 作成担当 : 30517 夏野 駿希
// 作 成 日  2012/01/16  修正内容 : SCM改良対応・特記事項対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30745 吉岡 孝憲
// 作 成 日  2012/04/12  修正内容 : 障害№170 PS管理番号項目追加
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
// 管理番号  10801804-00 作成担当 : 30745 吉岡
// 作 成 日  2013/05/08  修正内容 : 2013/06/18配信　SCM障害№10308,№10528
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30745 吉岡
// 作 成 日  2013/05/15  修正内容 : 2013/06/18配信　SCM障害№10410
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 脇田 靖之
// 作 成 日  2013/06/13  修正内容 : 2013/06/18配信　システムテスト障害№22
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
using Broadleaf.Library.Text;   // 2010/05/24 Add

namespace Broadleaf.Application.UIData
{
    using RecordType    = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlAsWork;
    using RecordTypeWeb = Broadleaf.Application.UIData.ScmOdDtAns;

    /// <summary>
    /// ユーザーDB SCM受注明細データ(回答)のレコードクラス
    /// </summary>
    public class UserSCMOrderAnswerRecord : UserSCMOrderAnswerWrapper
    {
        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public UserSCMOrderAnswerRecord() : base() { }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="realRecord">本物のレコード</param>
        public UserSCMOrderAnswerRecord(RecordType realRecord) : base(realRecord) { }

        #endregion // </Constructor>

        /// <summary>
        /// カスタムコンストラクタ(Web⇒User変換)
        /// </summary>
        /// <param name="webRecord">SCM受発注明細データ(回答)</param>
        /// <remarks>
        /// <br>Update Note      :   2018/04/16 田建委</br>
        /// <br>管理番号         :   11470007-00</br>
        /// <br>                 :   SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加</br>
        /// </remarks>
        public UserSCMOrderAnswerRecord(WebSCMOrderAnswerRecord webRecord) : base(new RecordType())
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
            RealRecord.InqPureGoodsNo = webRecord.InqPureGoodsNo; // 純正商品番号
            RealRecord.AnsPureGoodsNo = webRecord.AnsPureGoodsNo; // 純正商品番号
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
            RealRecord.AcptAnOdrStatus = webRecord.AcptAnOdrStatus; // 受注ステータス
            RealRecord.SalesSlipNum = webRecord.SalesSlipNum; // 売上伝票番号
            RealRecord.SalesRowNo = webRecord.SalesRowNo; // 売上行番号
            //RealRecord.CampaignCode = webRecord.CampaignCode; // キャンペーンコード
            //RealRecord.StockDiv = webRecord.StockDiv; // 在庫区分
            RealRecord.InqOrdDivCd = webRecord.InqOrdDivCd; // 問合せ・発注種別
            RealRecord.DisplayOrder = webRecord.DisplayOrder; // 表示順位
            //RealRecord.GoodsMngNo = webRecord.GoodsMngNo; // 商品管理番号

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
            RealRecord.WarehouseShelfNo= webRecord.PmShelfNo; // 棚番
            // --- ADD m.suzuki 2011/05/23 ----------<<<<<

            // --- ADD LDNS wangqx 2011/08/08 ---------->>>>>　　
            RealRecord.PmPrsntCount = webRecord.PmPrsntCount; // PM現在庫数
            RealRecord.SetPartsMkrCd = webRecord.SetPartsMkrCd; // セット部品メーカーコード
            RealRecord.SetPartsNumber = webRecord.SetPartsNumber; // セット部品番号
            RealRecord.SetPartsMainSubNo = webRecord.SetPartsMainSubNo; // セット部品親子番号
            // --- ADD LDNS wangqx 2011/08/08 ----------<<<<<
            RealRecord.CampaignCode = webRecord.CampaignCode; // キャンペーンコード  // ADD 2011/10/10

            // 2012/01/16 Add >>>
            RealRecord.GoodsSpecialNote = webRecord.GoodsSpecialNote; // 特記事項
            // 2012/01/16 Add <<<
            // --- ADD 吉岡 2012/04/12 №170 ---------->>>>>
            RealRecord.PSMngNo = webRecord.PsMngNo; // PS管理番号
            // --- ADD 吉岡 2012/04/12 №170 ----------<<<<<

            // --- ADD T.Nishi 2012/05/30 ---------->>>>>
            RealRecord.AutoEstimatePartsCd = webRecord.AutoEstimatePartsCd; // 自動見積部品コード
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
            RealRecord.DataInputSystem = webRecord.DataInputSystem; //データ入力システム
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
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)</param>
        /// <remarks>
        /// <br>Update Note      :   2018/04/16 田建委</br>
        /// <br>管理番号         :   11470007-00</br>
        /// <br>                 :   SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加</br>
        /// </remarks>
        public UserSCMOrderAnswerRecord(ISCMOrderDetailRecord detailRecord) : base(new RecordType())
        {
            UserSCMOrderDetailRecord userDetailRecord = detailRecord as UserSCMOrderDetailRecord;
            if (userDetailRecord == null) return;

            // 共通ファイルヘッダは何もしない
            //RealRecord.CreateDateTime = userDetailRecord.CreateDateTime; // 作成日時
            //RealRecord.UpdateDateTime = userDetailRecord.UpdateDateTime; // 更新日時
            //RealRecord.EnterpriseCode = userDetailRecord.EnterpriseCode; // 企業コード
            //RealRecord.FileHeaderGuid = userDetailRecord.FileHeaderGuid; // GUID
            //RealRecord.UpdEmployeeCode = userDetailRecord.UpdEmployeeCode; // 更新従業員コード
            //RealRecord.UpdAssemblyId1 = userDetailRecord.UpdAssemblyId1; // 更新アセンブリID1
            //RealRecord.UpdAssemblyId2 = userDetailRecord.UpdAssemblyId2; // 更新アセンブリID2
            //RealRecord.LogicalDeleteCode = userDetailRecord.LogicalDeleteCode; // 論理削除区分

            RealRecord.InqOriginalEpCd = userDetailRecord.InqOriginalEpCd.Trim(); // 問合せ元企業コード//@@@@20230303
            RealRecord.InqOriginalSecCd = userDetailRecord.InqOriginalSecCd; // 問合せ元拠点コード
            RealRecord.InqOtherEpCd = userDetailRecord.InqOtherEpCd; // 問合せ先企業コード
            RealRecord.InqOtherSecCd = userDetailRecord.InqOtherSecCd; // 問合せ先拠点コード
            RealRecord.InquiryNumber = userDetailRecord.InquiryNumber; // 問合せ番号
            RealRecord.UpdateDate = userDetailRecord.UpdateDate; // 更新年月日
            RealRecord.UpdateTime = userDetailRecord.UpdateTime; // 更新時分秒ミリ秒
            RealRecord.InqRowNumber = userDetailRecord.InqRowNumber; // 問合せ行番号
            RealRecord.InqRowNumDerivedNo = userDetailRecord.InqRowNumDerivedNo; // 問合せ行番号枝番
            RealRecord.InqOrgDtlDiscGuid = userDetailRecord.InqOrgDtlDiscGuid; // 問合せ元明細識別GUID
            RealRecord.InqOthDtlDiscGuid = userDetailRecord.InqOthDtlDiscGuid; // 問合せ先明細識別GUID
            RealRecord.GoodsDivCd = userDetailRecord.GoodsDivCd; // 商品種別
            RealRecord.RecyclePrtKindCode = userDetailRecord.RecyclePrtKindCode; // リサイクル部品種別
            RealRecord.RecyclePrtKindName = userDetailRecord.RecyclePrtKindName; // リサイクル部品種別名称
            RealRecord.DeliveredGoodsDiv = userDetailRecord.DeliveredGoodsDiv; // 納品区分
            RealRecord.HandleDivCode = userDetailRecord.HandleDivCode; // 取扱区分
            RealRecord.GoodsShape = userDetailRecord.GoodsShape; // 商品形態
            RealRecord.DelivrdGdsConfCd = userDetailRecord.DelivrdGdsConfCd; // 納品確認区分
            RealRecord.DeliGdsCmpltDueDate = userDetailRecord.DeliGdsCmpltDueDate; // 納品完了予定日
            RealRecord.AnswerDeliveryDate = userDetailRecord.AnswerDeliveryDate; // 回答納期
            RealRecord.BLGoodsCode = userDetailRecord.BLGoodsCode; // BL商品コード
            RealRecord.BLGoodsDrCode = userDetailRecord.BLGoodsDrCode; // BL商品コード枝番
            //RealRecord.GoodsName = userDetailRecord.GoodsName; // 商品名（カナ）
            RealRecord.InqGoodsName = userDetailRecord.InqGoodsName; // 問発商品名
            RealRecord.AnsGoodsName = userDetailRecord.AnsGoodsName; // 回答商品名
            RealRecord.SalesOrderCount = userDetailRecord.SalesOrderCount; // 発注数
            RealRecord.DeliveredGoodsCount = userDetailRecord.DeliveredGoodsCount; // 納品数
            RealRecord.GoodsNo = userDetailRecord.GoodsNo; // 商品番号
            RealRecord.GoodsMakerCd = userDetailRecord.GoodsMakerCd; // 商品メーカーコード
            RealRecord.GoodsMakerNm = userDetailRecord.GoodsMakerNm; // 商品メーカー名称
            RealRecord.PureGoodsMakerCd = userDetailRecord.PureGoodsMakerCd; // 純正商品メーカーコード
            //RealRecord.PureGoodsNo = userDetailRecord.PureGoodsNo; // 純正商品番号
            RealRecord.InqPureGoodsNo = userDetailRecord.InqPureGoodsNo; // 純正商品番号
            RealRecord.AnsPureGoodsNo = userDetailRecord.AnsPureGoodsNo; // 純正商品番号
            RealRecord.ListPrice = userDetailRecord.ListPrice; // 定価
            RealRecord.UnitPrice = userDetailRecord.UnitPrice; // 単価
            RealRecord.GoodsAddInfo = userDetailRecord.GoodsAddInfo; // 商品補足情報
            RealRecord.RoughRrofit = userDetailRecord.RoughRrofit; // 粗利額
            RealRecord.RoughRate = userDetailRecord.RoughRate; // 粗利率
            RealRecord.AnswerLimitDate = userDetailRecord.AnswerLimitDate; // 回答期限
            RealRecord.CommentDtl = userDetailRecord.CommentDtl; // 備考(明細)
            RealRecord.AppendingFileDtl = userDetailRecord.AppendingFileDtl; // 添付ファイル(明細)
            RealRecord.AppendingFileNmDtl = userDetailRecord.AppendingFileNmDtl; // 添付ファイル名(明細)
            RealRecord.ShelfNo = userDetailRecord.ShelfNo; // 棚番
            RealRecord.AdditionalDivCd = userDetailRecord.AdditionalDivCd; // 追加区分
            RealRecord.CorrectDivCD = userDetailRecord.CorrectDivCD; // 訂正区分
            //RealRecord.AcptAnOdrStatus = userDetailRecord.AcptAnOdrStatus; // 受注ステータス
            //RealRecord.SalesSlipNum = userDetailRecord.SalesSlipNum; // 売上伝票番号
            //RealRecord.SalesRowNo = userDetailRecord.SalesRowNo; // 売上行番号
            //RealRecord.CampaignCode = userDetailRecord.CampaignCode; // キャンペーンコード
            //RealRecord.StockDiv = userDetailRecord.StockDiv; // 在庫区分
            RealRecord.InqOrdDivCd = userDetailRecord.InqOrdDivCd; // 問合せ・発注種別
            RealRecord.DisplayOrder = userDetailRecord.DisplayOrder; // 表示順位
            //RealRecord.GoodsMngNo = userDetailRecord.GoodsMngNo; // 商品管理番号
            // 2010/05/26 Add >>>
            RealRecord.CancelCndtinDiv = userDetailRecord.CancelCndtinDiv; // キャンセル状態区分
            RealRecord.AcptAnOdrStatus = userDetailRecord.AcptAnOdrStatus; // 受注ステータス
            RealRecord.SalesSlipNum = userDetailRecord.SalesSlipNum; // 売上伝票番号
            RealRecord.SalesRowNo = userDetailRecord.SalesRowNo; // 売上行番号
            // 2010/05/26 Add <<<
            // 2011/02/09 Add >>>
            RealRecord.DtlTakeinDivCd = userDetailRecord.DtlTakeinDivCd; // 明細取込区分
            // 2011/02/09 Add <<<
            // --- ADD m.suzuki 2011/05/23 ---------->>>>>
            RealRecord.WarehouseCode = userDetailRecord.PmWarehouseCd; // PM倉庫コード
            RealRecord.WarehouseName = userDetailRecord.PmWarehouseName; // PM倉庫名称
            RealRecord.WarehouseShelfNo = userDetailRecord.PmShelfNo; // 棚番
            // --- ADD m.suzuki 2011/05/23 ----------<<<<<

            // --- ADD LDNS wangqx 2011/08/08 ---------->>>>>
            RealRecord.PmPrsntCount = userDetailRecord.PmPrsntCount; // PM現在個数
            RealRecord.SetPartsMkrCd = userDetailRecord.SetPartsMkrCd; // セット部品メーカーコード
            RealRecord.SetPartsNumber = userDetailRecord.SetPartsNumber; // セット部品番号
            RealRecord.SetPartsMainSubNo = userDetailRecord.SetPartsMainSubNo; // セット部品親子番号
            // --- ADD LDNS wangqx 2011/08/08 ----------<<<<<

            RealRecord.CampaignCode = userDetailRecord.CampaignCode; // キャンペーンコード  // ADD 2011/10/10

            // 2012/01/16 Add >>>
            RealRecord.GoodsSpecialNote = userDetailRecord.GoodsSpecialNote; // 特記事項
            // 2012/01/16 Add <<<
            // --- ADD 吉岡 2012/04/12 №170 ---------->>>>>
            RealRecord.PSMngNo = userDetailRecord.PsMngNo; // PS管理番号
            // --- ADD 吉岡 2012/04/12 №170 ----------<<<<<

            // --- ADD T.Nishi 2012/05/30 ---------->>>>>
            RealRecord.AutoEstimatePartsCd = userDetailRecord.AutoEstimatePartsCd; // 自動見積部品コード
            // --- ADD T.Nishi 2012/05/30 ----------<<<<<

            // ADD 2013/05/08 吉岡 2013/06/18配信 SCM障害№10308,№10528 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            RealRecord.SalesTotalTaxInc = userDetailRecord.SalesTotalTaxInc; // 売上伝票合計（税込）
            RealRecord.SalesTotalTaxExc = userDetailRecord.SalesTotalTaxExc; // 売上伝票合計（税抜）
            RealRecord.ScmConsTaxLayMethod = userDetailRecord.ScmConsTaxLayMethod; // SCM消費税転嫁方式
            RealRecord.ConsTaxRate = userDetailRecord.ConsTaxRate; // 消費税税率
            RealRecord.ScmFractionProcCd = userDetailRecord.ScmFractionProcCd; // SCM端数処理区分
            RealRecord.AccRecConsTax = userDetailRecord.AccRecConsTax; // 売掛消費税
            RealRecord.PMSalesDate = userDetailRecord.PMSalesDate; // PM売上日
            RealRecord.SuppSlpPrtTime = userDetailRecord.SuppSlpPrtTime; // 仕入先伝票発行時刻
            RealRecord.SalesMoneyTaxInc = userDetailRecord.SalesMoneyTaxInc; // 売上金額（税込み）
            RealRecord.SalesMoneyTaxExc = userDetailRecord.SalesMoneyTaxExc; // 売上金額（税抜き）
            // ADD 2013/05/08 吉岡 2013/06/18配信 SCM障害№10308,№10528 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2013/05/15 吉岡 2013/06/18配信 SCM障害№10410 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            RealRecord.DataInputSystem = userDetailRecord.DataInputSystem; // データ入力システム
            // ADD 2013/05/15 吉岡 2013/06/18配信 SCM障害№10410 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2014/06/04 SCM仕掛一覧№10659対応 ------------------------------------------------------->>>>>
            RealRecord.PrmSetDtlNo2 = userDetailRecord.PrmSetDtlNo2; // 優良設定詳細コード２
            RealRecord.PrmSetDtlName2 = userDetailRecord.PrmSetDtlName2; // 優良設定詳細名称２
            RealRecord.StockStatusDiv = userDetailRecord.StockStatusDiv; // 在庫状況区分
            // ADD 2014/06/04 SCM仕掛一覧№10659対応 -------------------------------------------------------<<<<<
            // ADD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
            RealRecord.RentDiv = userDetailRecord.RentDiv; // 貸出区分            
            RealRecord.MkrSuggestRtPric = userDetailRecord.MkrSuggestRtPric; // メーカー希望小売価格
            RealRecord.OpenPriceDiv = userDetailRecord.OpenPriceDiv; // オープン価格区分    
            // ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<
            // ADD 2015/01/19 豊沢 リコメンド対応 --------------------->>>>>
            RealRecord.BgnGoodsDiv = userDetailRecord.BgnGoodsDiv; // お買得商品選択区分
            // ADD 2015/01/19 豊沢 リコメンド対応 ---------------------<<<<<
            // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 ----------------------------->>>>>
            RealRecord.ModelPrtsAdptYm = userDetailRecord.ModelPrtsAdptYm; // 型式別部品採用年月
            RealRecord.ModelPrtsAblsYm = userDetailRecord.ModelPrtsAblsYm; // 型式別部品廃止年月
            RealRecord.ModelPrtsAdptFrameNo = userDetailRecord.ModelPrtsAdptFrameNo; // 型式別部品採用車台番号
            RealRecord.ModelPrtsAblsFrameNo = userDetailRecord.ModelPrtsAblsFrameNo; // 型式別部品廃止車台番号
            // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 -----------------------------<<<<<
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            RealRecord.AnsDeliDateDiv = userDetailRecord.AnsDeliDateDiv; // 回答納期区分
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ---------->>>>>>>>>>
            RealRecord.GoodsSpecialNtForFac = userDetailRecord.GoodsSpecialNtForFac;    // 商品規格・特記事項(工場向け)
            RealRecord.GoodsSpecialNtForCOw = userDetailRecord.GoodsSpecialNtForCOw;    // 商品規格・特記事項(カーオーナー向け)
            RealRecord.PrmSetDtlName2ForFac = userDetailRecord.PrmSetDtlName2ForFac;    // 優良設定詳細名称２(工場向け)
            RealRecord.PrmSetDtlName2ForCOw = userDetailRecord.PrmSetDtlName2ForCOw;    // 優良設定詳細名称２(カーオーナー向け)
            // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ----------<<<<<<<<<<

            // ADD 2018/04/16 田建委 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            RealRecord.InqBlUtyPtThCd = userDetailRecord.InqBlUtyPtThCd;   // 問発BL統一部品コード(スリーコード版)
            RealRecord.InqBlUtyPtSbCd = userDetailRecord.InqBlUtyPtSbCd;   // 問発BL統一部品サブコード
            RealRecord.AnsBlUtyPtThCd = userDetailRecord.AnsBlUtyPtThCd;   // 回答BL統一部品コード(スリーコード版)
            RealRecord.AnsBlUtyPtSbCd = userDetailRecord.AnsBlUtyPtSbCd;   // 回答BL統一部品サブコード
            RealRecord.AnsBLGoodsCode = userDetailRecord.AnsBLGoodsCode;   // 回答BL商品コード
            RealRecord.AnsBLGoodsDrCode = userDetailRecord.AnsBLGoodsDrCode;   // 回答BL商品コード枝番
            // ADD 2018/04/16 田建委 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            Initialize();
        }

        /// <summary>
        /// 初期化します。
        /// </summary>
        private void Initialize()
        {
            RealRecord.UpdateDate = DateTime.MinValue;  // 更新年月日
            RealRecord.UpdateTime = 0;                  // 更新時分秒ミリ秒
        }

        #region <User⇒WEB変換>
        /// <summary>
        /// UserDBからWebDBへの詰替え処理(問合せ先企業、拠点は別途設定が必要)
        /// </summary>
        /// <returns>SCM受発注明細データ(回答)</returns>
        /// <remarks>
        /// <br>Update Note      :   2018/04/16 田建委</br>
        /// <br>管理番号         :   11470007-00</br>
        /// <br>                 :   SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加</br>
        /// </remarks>
        public WebSCMOrderAnswerRecord CopyToWebSCMOrderAnswerRecord()
        {
            RecordTypeWeb webRecord = new RecordTypeWeb();
            {
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
                webRecord.InqPureGoodsNo = RealRecord.InqPureGoodsNo; // 問発純正商品番号
                webRecord.AnsPureGoodsNo = RealRecord.AnsPureGoodsNo; // 回答純正商品番号
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
                //webRecord.SalesRowNo = RealRecord.SalesRowNo; // 売上行番号
                //webRecord.CampaignCode = RealRecord.CampaignCode; // キャンペーンコード
                //webRecord.StockDiv = RealRecord.StockDiv; // 在庫区分
                webRecord.InqOrdDivCd = RealRecord.InqOrdDivCd; // 問合せ・発注種別
                webRecord.DisplayOrder = RealRecord.DisplayOrder; // 表示順位
                //webRecord.GoodsMngNo = RealRecord.GoodsMngNo; // 商品管理番号
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

                // --- ADD LDNS wangqx 2011/08/08 ---------->>>>>
                webRecord.PmPrsntCount = RealRecord.PmPrsntCount; // PM現在庫数
                webRecord.SetPartsMkrCd = RealRecord.SetPartsMkrCd; // セット部品メーカーコード
                webRecord.SetPartsNumber = RealRecord.SetPartsNumber; // セット部品番号
                webRecord.SetPartsMainSubNo = RealRecord.SetPartsMainSubNo; // セット部品親子番号
                //// --- ADD LDNS wangqx 2011/08/08 ----------<<<<<
                webRecord.CampaignCode = RealRecord.CampaignCode; // キャンペーンコード  // ADD 2011/10/10

                // 2012/01/16 Add >>>
                webRecord.GoodsSpecialNote = RealRecord.GoodsSpecialNote; // 特記事項
                // 2012/01/16 Add <<<
                // --- ADD T.Nishi 2012/05/30 ---------->>>>>
                webRecord.AutoEstimatePartsCd = RealRecord.AutoEstimatePartsCd; // 自動見積部品コード
                // --- ADD T.Nishi 2012/05/30 ----------<<<<<

                // ADD 2013/05/08 吉岡 2013/06/18配信 SCM障害№10308,№10528 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                webRecord.SalesTotalTaxInc = RealRecord.SalesTotalTaxInc; // 売上伝票合計（税込）
                // --- UPD 2013/06/13 Y.Wakita ---------->>>>>
                //webRecord.SalesTotalTaxInc = RealRecord.SalesTotalTaxExc; // 売上伝票合計（税抜）
                webRecord.SalesTotalTaxExc = RealRecord.SalesTotalTaxExc; // 売上伝票合計（税抜）
                // --- UPD 2013/06/13 Y.Wakita ----------<<<<<
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
                webRecord.ModelPrtsAblsYm = SCMEntityUtil.ConvertModelPrtsAblsYm(RealRecord.ModelPrtsAblsYm); // 型式別部品廃止年月
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
            return new WebSCMOrderAnswerRecord(webRecord);
        }
        #endregion
    }
}

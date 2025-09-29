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
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2010/06/17  修正内容 : テーブルのレイアウト変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2010/06/24  修正内容 : 「回答作成区分」が「0:自動」の場合、「CMT連携区分」を設定する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/09/19  修正内容 : Redmine#25216の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : yangyi
// 修 正 日  2011/10/11  修正内容 : Redmine#25763 手動回答／自動回答時の車台番号に関して
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 三戸　伸悟
// 作 成 日  2012/05/31  修正内容 : 障害№135 ＳＦ側に返すグレード名称を全角で返す
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30744 湯上 千加子
// 作 成 日  2012/11/09  修正内容 : SCM改良№10337,10338,10341,10364,10431対応 PCCforNS、BLPの自動回答判定処理統合
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30744 湯上 千加子
// 作 成 日  2013/02/13  修正内容 : SCM障害追加②対応　2013/03/06配信
//----------------------------------------------------------------------------//
// 管理番号 　　　　　　 作成担当 : 30745 吉岡 孝憲
// 作 成 日  2013/04/05  修正内容 : 2013/05/22配信 SCM障害№50 SPK対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/12/16  修正内容 : SCM仕掛一覧№10590対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 修 正 日  2014/06/04  修正内容 : SCM仕掛一覧№10659対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上 千加子
// 修 正 日  2015/01/19  修正内容 : リコメンド対応 お買い得商品区分の追加
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.Controller.Util
{
    using SCMOrderHeaderRecordType  = ISCMOrderHeaderRecord;    // SCM受注データ
    using SCMOrderCarRecordType     = ISCMOrderCarRecord;       // SCM受注データ(車両情報)
    using SCMOrderDetailRecordType  = ISCMOrderDetailRecord;    // SCM受注明細データ(問合せ・発注)
    using SCMOrderAnswerRecordType  = ISCMOrderAnswerRecord;    // SCM受注明細データ(回答)

    /// <summary>
    /// 自動回答区分列挙型
    /// </summary>
    public enum AutoAnswerDiv : int
    {
        /// <summary>0:しない</summary>
        None = 0,
        /// <summary>1:一部でも回答可能な場合する</summary>
        Part = 1,
        /// <summary>2:全て回答可能な場合のみする</summary>
        All = 2
    }

    // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
    /// <summary>
    /// 自動回答区分（問合せ）列挙型
    /// </summary>
    public enum AutoAnsInquiryDiv : int
    {
        /// <summary>0:しない(手動)</summary>
        None = 0,
        /// <summary>1:する(全て自動回答）</summary>
        All = 1,
        /// <summary>2:する(絞り込み時自動回答)</summary>
        SelectAuto = 2
    }
    /// <summary>
    /// 自動回答区分（発注）列挙型
    /// </summary>
    public enum AutoAnsOrderDiv : int
    {
        /// <summary>0:しない(手動)</summary>
        None = 0,
        /// <summary>1:する(全て自動回答)</summary>
        All = 1,
        /// <summary>2:する(委託在庫分のみ自動回答)</summary>
        TrustAuto = 2
    }
    // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<

    // ADD 2013/02/13 SCM障害追加②対応 2013/03/06配信-------------------------------------------->>>>>
    /// <summary>
    /// 該当無自動回答区列挙型
    /// </summary>
    public enum FuwioutAutoAnsDiv : int
    {
        /// <summary>0:しない(手動回答)</summary>
        None = 0,
        /// <summary>1:する(自動回答)</summary>
        Auto = 1
    }
    // ADD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<

    /// <summary>
    /// 商品種別列挙型
    /// </summary>
    public enum GoodsDivCd : int
    {
        /// <summary>0:純正部品</summary>
        Pure = 0,
        /// <summary>1:優良部品</summary>
        Prime = 1,
        /// <summary>2:リサイクル部品</summary>
        Recycle = 2,
        /// <summary>3:平均相場</summary>
        MarketPrice = 3
    }

    /// <summary>
    /// リサイクル部品種別列挙型
    /// </summary>
    public enum RecyclePrtKindCode : int
    {
        /// <summary>なし</summary>
        None = 0,
        /// <summary>リビルド</summary>
        Rebuild = 1,
        /// <summary>中古</summary>
        Used = 2
    }

    /// <summary>
    /// 在庫区分列挙型
    /// </summary>
    public enum StockDiv : int
    {
        /// <summary>0:非在庫</summary>
        None,
        /// <summary>1:委託在庫</summary>
        Trust,
        /// <summary>2:得意先在庫</summary>
        Customer,
        /// <summary>3:優先倉庫</summary>
        PriorityWarehouse,
        /// <summary>4:自社在庫</summary>
        OwnCompany
    }

    /// <summary>
    /// 受注ステータス列挙型
    /// </summary>
    public enum AcptAnOdrStatus : int
    {
        /// <summary>10:見積</summary>
        Estimate = 10,
        /// <summary>20:受注</summary>
        Order = 20,
        /// <summary>30:売上</summary>
        Sales = 30
    }

    // DEL 2010/06/24 「回答作成区分」が「0:自動」の場合、「CMT連携区分」を設定する ---------->>>>>
    #region PMSCM01011E::SCMEntityUtil.cs へ移設

    ///// <summary>
    ///// 問合せ・発注種別列挙型
    ///// </summary>
    //public enum InqOrdDivCd : int
    //{
    //    /// <summary>1:問合せ</summary>
    //    Inquiry = 1,
    //    /// <summary>2:発注</summary>
    //    Ordering = 2
    //}

    #endregion // PMSCM01011E::SCMEntityUtil.cs へ移設
    // DEL 2010/06/24 「回答作成区分」が「0:自動」の場合、「CMT連携区分」を設定する ----------<<<<<

    // 2011/02/14 Add >>>
    /// <summary>
    /// 最新識別区分
    /// </summary>
    public enum LatestDiscCode : int
    {
        /// <summary>指定無し</summary>
        All = -1,
        /// <summary>最新データ</summary>
        New = 0,
        /// <summary>回答</summary>
        Old = 1
    }
    // 2011/02/14 Add <<<

    /// <summary>
    /// 回答区分列挙型
    /// </summary>
    public enum AnswerDivCd : int
    {
        /// <summary>0:アクションなし</summary>
        NoAction = 0,
        /// <summary>10:一部回答</summary>
        PartAnswer = 10,
        /// <summary>20:回答完了</summary>
        AnswerCompletion = 20,
        /// <summary>30:承認</summary>
        Approve = 30,
        /// <summary>99:キャンセル</summary>
        Cancel = 99
    }

    /// <summary>
    /// 問発・回答種別列挙型
    /// </summary>
    public enum InqOrdAnsDivCd : int
    {
        /// <summary>1:問合せ・発注</summary>
        Inquiry = 1,
        /// <summary>2:回答</summary>
        Answer = 2
    }

    /// <summary>
    /// 伝票発行区分列挙型
    /// </summary>
    public enum SlipPrintDivCd : int
    {
        /// <summary>しない</summary>
        None = 0,
        /// <summary>する</summary>
        Do = 1
    }

    /// <summary>
    /// 消費税転嫁方式列挙型
    /// </summary>
    /// <remarks>売伝のソースより移植</remarks>
    public enum ConsTaxLayMethod : int
    {
        /// <summary>0:伝票単位</summary>
        Slip = 0,
        /// <summary>1:明細単位</summary>
        SlipDetail = 1,
        /// <summary>請求親</summary>
        ClaimParent = 2,
        /// <summary>請求子</summary>
        ClaimChild = 3,
        /// <summary>非課税</summary>
        TaxFree = 9,

        /// <summary>伝票転嫁</summary>
        SlipLay = 0,
        /// <summary>明細転嫁</summary>
        DetailLay = 1,
        /// <summary>請求親</summary>
        DemandParentLay = 2,
        /// <summary>請求子</summary>
        DemandChildLay = 3,
        /// <summary>非課税</summary>
        TaxExempt = 9
    }

    // ADD 2010/06/17 テーブルのレイアウト変更 ---------->>>>>
    /// <summary>
    /// キャンセル区分列挙型
    /// </summary>
    public enum CancelDiv : short
    {
        /// <summary>0:キャンセルなし</summary>
        None = 0,
        /// <summary>1:キャンセルあり</summary>
        ExistsCancel = 1
    }
    // ADD 2010/06/17 テーブルのレイアウト変更 ----------<<<<<

    // 2011/02/14 Add >>>
    /// <summary>
    /// キャンセル状態区分
    /// </summary>
    public enum CancelCndtinDiv : short
    {
        /// <summary>0:キャンセルなし</summary>
        None = 0,
        /// <summary>10:キャンセル要求</summary>
        Cancelling = 10,
        /// <summary>20:キャンセル却下</summary>
        Rejected = 20,
        /// <summary>30:キャンセル確定</summary>
        Cancelled = 30
    }

    /// <summary>
    /// 問合せ・発注種別
    /// </summary>
    public enum InqOrdDivCd : int
    {
        /// <summary>1:問合せ</summary>
        Inquiry = 1,
        /// <summary>2:発注</summary>
        Order = 2
    }
    // 2011/02/14 Add <<<

    // 2011/08/18 Add <<<
    /// <summary>
    /// 部品選択有無
    /// </summary>
    public enum SelectMode : int
    {
        /// <summary>1:あり</summary>
        On = 1,
        /// <summary>1:無し</summary>
        None = 2
    }


    // 2011/08/18 Add <<<
    /// <summary>
    /// 優先設定表示順
    /// </summary>
    public enum SCMPriorOrder : int
    {
        /// <summary>0:なし</summary>
        None = 0,
        /// <summary>1:粗利率</summary>
        RoughRate = 1,
        /// <summary>2:単価</summary>
        UnitPrice = 2,
        /// <summary>3:定価(高)</summary>
        ListPriceHigh = 3,
        /// <summary>4:定価(低)</summary>
        ListPriceLow = 4,
        /// <summary>5:キャンペーン</summary>
        Campaign = 5,
        // ----- UPD 2011/09/26 ----- >>>>> 
        // ----- UPD 2011/09/19 ----- >>>>>
        /// <summary>6:在庫</summary>
        StockOn = 6,
        /// <summary>7:委託</summary>
        Trust = 7,
        /// <summary>8:優先倉庫</summary>
        PriorityWarehouse = 8,

        ///// <summary>6:委託</summary>
        //Trust = 6,
        ///// <summary>7:優先倉庫</summary>
        //PriorityWarehouse = 7,
        // ----- UPD 2011/09/19 ----- <<<<<
        // ----- UPD 2011/09/26 ----- <<<<<

        // ADD 2013/12/16 SCM仕掛一覧№10590対応 -------------------------->>>>>
        /// <summary>9:優先設定</summary>
        PrioritySetting = 9,
        // ADD 2013/12/16 SCM仕掛一覧№10590対応 --------------------------<<<<<
    }

    // ----- ADD 2011/08/10 ----- >>>>>
    /// <summary>
    /// 受発注種別
    /// </summary>
    public enum EnumAcceptOrOrderKind : int
    {
        /// <summary>0:通常</summary>
        SCM = 0,
        /// <summary>1:PCC-UOE</summary>
        PCCUOE = 1
    }

    /// <summary>
    /// 優先適用区分
    /// </summary>
    public enum PriorappliDiv : int
    {
        /// <summary>0:通常</summary>
        ALL = 0,
        /// <summary>1:SCM</summary>
        SCM = 1,
        /// <summary>2:PCC-UOE</summary>
        PCCUOE = 2
    }
    // ----- ADD 2011/08/10 ----- <<<<<

    // 2011/08/18 Add <<<
    /// <summary>
    /// MODE
    /// </summary>
    public enum ItemSelectDiv : int
    {
        /// <summary>0:OFF</summary>
        OFF = 0,
        /// <summary>1:ON</summary>
        ON = 1
    }
    ////////////////////////////////////////////// 2012/04/25 TERASAKA ADD STA //
    /// <summary>
    /// 通知モード
    /// </summary>
    public enum NoticeMode : int
    {
        /// <summary>送信完了</summary>
        Send = 0,
        /// <summary>送信中</summary>
        Sending = 1,
        /// <summary>受信完了</summary>
        Received = 10,
        /// <summary>受信中</summary>
        Receive = 11,
        /// <summary>処理完了</summary>
        Processed = 20,
        /// <summary>処理中</summary>
        Processing = 21,
    }
    // 2012/04/25 TERASAKA ADD END //////////////////////////////////////////////

    // ADD 2014/06/04 SCM仕掛一覧№10659対応 ------------------------------------------------------->>>>>
    /// <summary>
    /// 在庫状況区分
    /// </summary>
    public enum StockStatusDiv : int
    {
        /// <summary>取り寄せ</summary>
        None = 0,
        /// <summary>在庫あり</summary>
        StockOn = 1,
        /// <summary>委託在庫</summary>
        Trust = 2
    }
    // ADD 2014/06/04 SCM仕掛一覧№10659対応 -------------------------------------------------------<<<<<

    // ADD 2015/01/19 リコメンド対応 --------------------------------->>>>>
    /// <summary>
    /// お買得商品選択区分
    /// </summary>
    public enum BgnGoodsDiv : short
    {
        /// <summary>通常</summary>
        Nomal = 0,
        /// <summary>お買い得商品選択</summary>
        BargainItem = 1
    }
    // ADD 2015/01/19 リコメンド対応 ---------------------------------<<<<<

    /// <summary>
    /// SCMデータのヘルパクラス
    /// </summary>
    public static class SCMDataHelper
    {
        /// <summary>
        /// 品番が存在するか判断します。
        /// </summary>
        /// <param name="scmOrderDetailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <returns>
        /// <c>true</c> :存在します。<br/>
        /// <c>false</c>:存在しません。
        /// </returns>
        public static bool ExistsGoodsNo(SCMOrderDetailRecordType scmOrderDetailRecord)
        {
            return !string.IsNullOrEmpty(scmOrderDetailRecord.GoodsNo.Trim());
        }

        // ----- 2011/08/10 ----- >>>>>
        /// <summary>
        /// BLコードが存在するか判断します。
        /// </summary>
        /// <param name="scmOrderDetailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <returns>
        /// <c>true</c> :存在します。<br/>
        /// <c>false</c>:存在しません。
        /// </returns>
        public static bool ExistsBLGoodsCd(SCMOrderDetailRecordType scmOrderDetailRecord)
        {
            return (scmOrderDetailRecord.BLGoodsCode != 0);
        }

        // ----- 2011/08/10 ----- <<<<<

        /// <summary>
        /// デフォルトの受注ステータスを取得します。
        /// </summary>
        /// <param name="inqOrdDivCd">問合せ・発注種別</param>
        /// <returns>
        /// 問合せ・発注種別が"1:問合せ"の場合、"10:見積"<br/>
        /// 問合せ・発注種別が"2:発注"の場合、"30:売上"
        /// </returns>
        public static int GetDefaultAcptAnOdrStatus(int inqOrdDivCd)
        {
            return inqOrdDivCd.Equals((int)InqOrdDivCdValue.Inquiry) ? (int)AcptAnOdrStatus.Estimate : (int)AcptAnOdrStatus.Sales;
        }

        /// <summary>
        /// 倉庫コードが<c>null</c>または空であるか判断します。(<c>0</c>は空と判断します)
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <returns>
        /// <c>true</c> :<c>null</c>または空です。<br/>
        /// <c>false</c>:<c>null</c>または空ではありません。
        /// </returns>
        public static bool IsNullOrEmptyWarehouseCode(string warehouseCode)
        {
            int warehouseCodeNumber = SCMEntityUtil.ConvertNumber(warehouseCode);
            return warehouseCodeNumber.Equals(0);
        }

        /// <summary>
        /// 相場回答であるか判断します。
        /// </summary>
        /// <param name="answerRecord">SCM受注明細データ(回答)のレコード</param>
        /// <returns>
        /// <c>true</c> :相場回答です。<br/>
        /// <c>false</c>:相場回答ではありません。
        /// </returns>
        public static bool IsMarketPrice(ISCMOrderAnswerRecord answerRecord)
        {
            return answerRecord.GoodsDivCd.Equals((int)GoodsDivCd.MarketPrice);
        }

        /// <summary>
        /// リサイクル部品種別名称を取得します。
        /// </summary>
        /// <param name="recyclePrtKindCode">リサイクル部品種別</param>
        /// <returns>該当するリサイクル部品種別名称</returns>
        public static string GetRecyclePrtKindName(int recyclePrtKindCode)
        {
            switch (recyclePrtKindCode)
            {
                case (int)RecyclePrtKindCode.Rebuild:
                    return "リビルド";  // LITERAL:
                case (int)RecyclePrtKindCode.Used:
                    return "中古";      // LITERAL:
                default:
                    return string.Empty;
            }
        }

        #region <車両検索結果>

        private const int SINGLE_ROW = 0;

        /// <summary>
        /// 登録年月日を取得します。
        /// </summary>
        /// <param name="searchedCarInfo">車両検索結果</param>
        /// <returns>登録年月日</returns>
        public static DateTime GetEntryDate(PMKEN01010E searchedCarInfo)
        {
            return DateTime.MinValue;   // UNDONE:車両検索結果.登録年月日
        }

        // 2010/03/17 >>>
        ///// <summary>
        ///// 初年度を取得します。
        ///// </summary>
        ///// <param name="searchedCarInfo">車両検索結果</param>
        ///// <returns>初年度</returns>
        //public static DateTime GetFirstEntryDate(PMKEN01010E searchedCarInfo)
        //{
        //    return DateTime.MinValue;   // UNDONE:車両検索結果.初年度
        //}

        /// <summary>
        /// 初年度を取得します。
        /// </summary>
        /// <param name="searchedCarInfo">車両検索結果</param>
        /// <returns>初年度</returns>
        public static int GetFirstEntryDate(PMKEN01010E searchedCarInfo)
        {
            if (searchedCarInfo.CarModelUIData.Count.Equals(0)) return 0;
            return searchedCarInfo.CarModelUIData[SINGLE_ROW].ProduceTypeOfYearInput;   //初年度
        }
        // 2010/03/17 <<<

        /// <summary>
        /// メーカー全角名称を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>メーカー全角名称</returns>
        public static string GetMakerFullName(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].MakerFullName;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].MakerFullName;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// メーカー半角名称を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>メーカー半角名称</returns>
        public static string GetMakerHalfName(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].MakerHalfName;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].MakerHalfName;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 車種コードを取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>車種コード</returns>
        public static int GetModelCode(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return 0;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].ModelCode;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return 0;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].ModelCode;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 車種サブコードを取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>車種サブコード</returns>
        public static int GetModelSubCode(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return 0;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].ModelSubCode;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return 0;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].ModelSubCode;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 車種全角名称を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>車種全角名称</returns>
        public static string GetModelFullName(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].ModelFullName;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].ModelFullName;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 車種半角名称を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>車種半角名称</returns>
        public static string GetModelHalfName(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].ModelHalfName;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].ModelHalfName;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 系統コードを取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>系統コード</returns>
        public static int GetSystematicCode(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return 0;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].SystematicCode;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return 0;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].SystematicCode;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 系統名称を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>系統名称</returns>
        public static string GetSystematicName(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].SystematicName;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].SystematicName;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 生産年式コードを取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>生産年式コード</returns>
        public static int GetProduceTypeOfYearCd(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return 0;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].ProduceTypeOfYearCd;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return 0;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].ProduceTypeOfYearCd;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 生産年式名称を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>生産年式名称</returns>
        public static string GetProduceTypeOfYearNm(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].ProduceTypeOfYearNm;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].ProduceTypeOfYearNm;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 開始生産年式を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>開始生産年式</returns>
        public static DateTime GetStProduceTypeOfYear(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return DateTime.MinValue;

            //string yyyyMM = seachedCarInfo.CarModelInfo[SINGLE_ROW].StProduceTypeOfYear.ToString("000000");
            //int yyyy = int.Parse(yyyyMM.Substring(0, 4));
            //int mm = int.Parse(yyyyMM.Substring(4, 2));

            //return new DateTime(yyyy, mm, 1);

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return DateTime.MinValue;

            DateTime sdt;
            int iyy = seachedCarInfo.CarModelInfoSummarized[0].StProduceTypeOfYear / 100;
            int imm = seachedCarInfo.CarModelInfoSummarized[0].StProduceTypeOfYear % 100;
            if (( iyy == 9999 ) || ( imm == 99 ))
            {
                sdt = DateTime.MinValue;
            }
            else
            {
                sdt = new DateTime(iyy, imm, 1);
            }
            return sdt;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 終了生産年式を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>終了生産年式</returns>
        public static DateTime GetEdProduceTypeOfYear(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return DateTime.MinValue;

            //string yyyyMM = seachedCarInfo.CarModelInfo[SINGLE_ROW].EdProduceTypeOfYear.ToString("000000");
            //int yyyy = int.Parse(yyyyMM.Substring(0, 4));
            //int mm = int.Parse(yyyyMM.Substring(4, 2));
            //if (mm > 12) return DateTime.MaxValue;

            //return new DateTime(yyyy, mm, 1);

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return DateTime.MinValue;

            DateTime edt;
            int iyy = seachedCarInfo.CarModelInfoSummarized[0].EdProduceTypeOfYear / 100;
            int imm = seachedCarInfo.CarModelInfoSummarized[0].EdProduceTypeOfYear % 100;
            if (( iyy == 9999 ) || ( imm == 99 ))
            {
                edt = DateTime.MinValue;
            }
            else
            {
                edt = new DateTime(iyy, imm, 1);
            }
            return edt;
            // 2011/03/08 <<<
        }

        

        /// <summary>
        /// ドア数を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>ドア数</returns>
        public static int GetDoorCount(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return 0;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].DoorCount;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return 0;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].DoorCount;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// ボディー名コードを取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>ボディー名コード</returns>
        public static int GetBodyNameCode(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return 0;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].BodyNameCode;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return 0;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].BodyNameCode;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// ボディー名称を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>ボディー名称</returns>
        public static string GetBodyName(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].BodyName;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].BodyName;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 排ガス記号を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>排ガス記号</returns>
        public static string GetExhaustGasSign(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].ExhaustGasSign;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].ExhaustGasSign;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// シリーズ型式を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>シリーズ型式</returns>
        public static string GetSeriesModel(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].SeriesModel;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].SeriesModel;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 型式(類別記号)を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>型式(類別記号)</returns>
        public static string GetCategorySignModel(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].CategorySignModel;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].CategorySignModel;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 型式(フル型)を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>型式(フル型)</returns>
        public static string GetFullModel(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].FullModel;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].FullModel;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 型式指定番号を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>型式指定番号</returns>
        public static int GetModelDesignationNo(PMKEN01010E seachedCarInfo)
        {
            if (seachedCarInfo.CarModelUIData.Count.Equals(0)) return 0;

            return seachedCarInfo.CarModelUIData[SINGLE_ROW].ModelDesignationNo;
        }

        /// <summary>
        /// 類別番号を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>類別番号</returns>
        public static int GetCategoryNo(PMKEN01010E seachedCarInfo)
        {
            if (seachedCarInfo.CarModelUIData.Count.Equals(0)) return 0;

            return seachedCarInfo.CarModelUIData[SINGLE_ROW].CategoryNo;
        }

        /// <summary>
        /// 車台型式を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>車台型式</returns>
        public static string GetFrameModel(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].FrameModel;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].FrameModel;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 車台番号を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>車台番号</returns>
        public static string GetFrameNo(PMKEN01010E seachedCarInfo)
        {
            #region----- DEL 2011/10/12 --------------------------->>>>>
            //if (seachedCarInfo.CarModelUIData.Count.Equals(0)) return string.Empty;

            //// ----- DEL 2011/10/11 --------------------------->>>>>
            ////return seachedCarInfo.CarModelUIData[SINGLE_ROW].FrameNo;
            //// ----- DEL 2011/10/11 ---------------------------<<<<<
            //// ----- ADD 2011/10/11 --------------------------->>>>>
            //string frameModel = "";
            //string chassisNo = "";
            //int status = GenerateChassisNoFrameFromFrameNo(seachedCarInfo.CarModelUIData[SINGLE_ROW].FrameNo, out  frameModel, out  chassisNo);
            //if (status == 0)
            //{
            //    return chassisNo;
            //}
            //else
            //{
            //    return seachedCarInfo.CarModelUIData[SINGLE_ROW].FrameNo;
            //}
            // ----- ADD 2011/10/11 ---------------------------<<<<<
            #endregion----- DEL 2011/10/12 ---------------------------<<<<<
            // ----- ADD 2011/10/12 --------------------------->>>>>
            if (seachedCarInfo.CarModelUIData.Count.Equals(0)) return string.Empty;

            return seachedCarInfo.CarModelUIData[SINGLE_ROW].FrameNo;
            // ----- ADD 2011/10/12 ---------------------------<<<<<            
        }

        // 2011/03/08 Add >>>
        /// <summary>
        /// 車台番号（検索用）を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>車台番号</returns>
        public static int GetSearchFrameNo(PMKEN01010E seachedCarInfo)
        {
            if (seachedCarInfo.CarModelUIData.Count.Equals(0)) return 0;
            return seachedCarInfo.CarModelUIData[SINGLE_ROW].SearchFrameNo;
        }
        // 2011/03/08 Add <<<

        /// <summary>
        /// 生産車台番号開始を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>生産車台番号開始</returns>
        public static int GetStProduceFrameNo(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelUIData.Count.Equals(0)) return 0;

            //return seachedCarInfo.CarModelUIData[SINGLE_ROW].StProduceFrameNo;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return 0;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].StProduceFrameNo;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 生産車台番号終了を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>生産車台番号終了</returns>
        public static int GetEdProduceFrameNo(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelUIData.Count.Equals(0)) return 0;

            //return seachedCarInfo.CarModelUIData[SINGLE_ROW].EdProduceFrameNo;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return 0;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].EdProduceFrameNo;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 原動機型式(エンジン)を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>原動機型式(エンジン)</returns>
        public static string GetEngineModel(PMKEN01010E seachedCarInfo)
        {
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].EngineModel;

            return string.Empty;    // UNDONE:車両検索結果.原動機型式(エンジン)
        }

        /// <summary>
        /// 型式グレード名称を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>型式グレード名称</returns>
        public static string GetModelGradeNm(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].ModelGradeNm;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].ModelGradeNm;
            // 2011/03/08 <<<
        }

        // --- ADD 三戸 2012/05/31 №135 ---------->>>>>
        /// <summary>
        /// グレード名称（全角）を取得します。
        /// </summary>
        /// <param name="seachedCarInfo"></param>
        /// <returns></returns>
        public static string GetGradeFullName(PMKEN01010E seachedCarInfo)
        {
            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].GradeFullName;
        }
        // --- ADD 三戸 2012/05/31 №135 ----------<<<<<

        /// <summary>
        /// エンジン型式名称を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>エンジン型式名称</returns>
        public static string GetEngineModelNm(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].EngineModelNm;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].EngineModelNm;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 排気量名称を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>排気量名称</returns>
        public static string GetEngineDisplaceNm(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].EngineDisplaceNm;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].EngineDisplaceNm;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// E区分名称を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>E区分名称</returns>
        public static string GetEDivNm(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].EDivNm;


            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].EDivNm;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// ミッション名称を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>ミッション名称</returns>
        public static string GetTransmissionNm(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].TransmissionNm;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].TransmissionNm;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// シフト名称を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>シフト名称</returns>
        public static string GetShiftNm(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].ShiftNm;


            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].ShiftNm;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 駆動方式名称を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>駆動方式名称</returns>
        public static string GetWheelDriveMethodNm(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].WheelDriveMethodNm;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].WheelDriveMethodNm;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 追加諸元1を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>追加諸元1</returns>
        public static string GetAddiCarSpec1(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 Add >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].AddiCarSpec1;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].AddiCarSpec1;
            // 2011/03/08 Add <<<
        }

        /// <summary>
        /// 追加諸元2を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>追加諸元2</returns>
        public static string GetAddiCarSpec2(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].AddiCarSpec2;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].AddiCarSpec2;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 追加諸元3を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>追加諸元3</returns>
        public static string GetAddiCarSpec3(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].AddiCarSpec3;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].AddiCarSpec3;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 追加諸元4を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>追加諸元4</returns>
        public static string GetAddiCarSpec4(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].AddiCarSpec4;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].AddiCarSpec4;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 追加諸元5を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>追加諸元5</returns>
        public static string GetAddiCarSpec5(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].AddiCarSpec5;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].AddiCarSpec5;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 追加諸元6を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>追加諸元6</returns>
        public static string GetAddiCarSpec6(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].AddiCarSpec6;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].AddiCarSpec6;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 追加諸元タイトル1を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>追加諸元タイトル1</returns>
        public static string GetAddiCarSpecTitle1(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].AddiCarSpecTitle1;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].AddiCarSpecTitle1;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 追加諸元タイトル2を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>追加諸元タイトル2</returns>
        public static string GetAddiCarSpecTitle2(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].AddiCarSpecTitle2;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].AddiCarSpecTitle2;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 追加諸元タイトル3を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>追加諸元タイトル3</returns>
        public static string GetAddiCarSpecTitle3(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].AddiCarSpecTitle3;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].AddiCarSpecTitle3;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 追加諸元タイトル4を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>追加諸元タイトル4</returns>
        public static string GetAddiCarSpecTitle4(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].AddiCarSpecTitle4;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].AddiCarSpecTitle4;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 追加諸元タイトル5を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>追加諸元タイトル5</returns>
        public static string GetAddiCarSpecTitle5(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].AddiCarSpecTitle5;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].AddiCarSpecTitle5;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 追加諸元タイトル6を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>追加諸元タイトル6</returns>
        public static string GetAddiCarSpecTitle6(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].AddiCarSpecTitle6;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].AddiCarSpecTitle6;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 関連型式を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>関連型式</returns>
        public static string GetRelevanceModel(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].RelevanceModel;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].RelevanceModel;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// サブ車名コード取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>サブ車名コード</returns>
        public static int GetSubCarNmCd(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return 0;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].SubCarNmCd;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return 0;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].SubCarNmCd;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 型式グレード略式を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>型式グレード略式</returns>
        public static string GetModelGradeSname(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return string.Empty;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].ModelGradeSname;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return string.Empty;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].ModelGradeSname;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// ブロックイラストコードを取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>ブロックイラストコード</returns>
        public static int GetBlockIllustrationCd(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return 0;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].BlockIllustrationCd;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return 0;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].BlockIllustrationCd;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 3DイラストNoを取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>3DイラストNo</returns>
        public static int GetThreeDIllustNo(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return 0;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].ThreeDIllustNo;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return 0;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].ThreeDIllustNo;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 部品データ提供フラグを取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>部品データ提供フラグ</returns>
        public static int GetPartsDataOfferFlag(PMKEN01010E seachedCarInfo)
        {
            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return 0;

            //return seachedCarInfo.CarModelInfo[SINGLE_ROW].PartsDataOfferFlag;

            if (seachedCarInfo.CarModelInfoSummarized == null || seachedCarInfo.CarModelInfoSummarized.Count.Equals(0)) return 0;
            return seachedCarInfo.CarModelInfoSummarized[SINGLE_ROW].PartsDataOfferFlag;
            // 2011/03/08 <<<
        }

        /// <summary>
        /// 部品データ提供フラグを取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <param name="fullModelFixedNoAry"></param>
        /// <param name="freeSrchMdlFxdNoAry"></param>
        /// <returns>部品データ提供フラグ</returns>
        // 2011/03/08 >>>
        //public static int[] GetFullModelFixedNoAry(PMKEN01010E seachedCarInfo)
        public static void GetFullModelFixedNoAry(PMKEN01010E seachedCarInfo, out int[] fullModelFixedNoAry, out string[] freeSrchMdlFxdNoAry)
        // 2011/03/08 <<<
        {

            // 2011/03/08 >>>
            //if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return new int[0];
            //int[] fullModelFixedNoAry = null;
            //CarSearchController carSearcher = new CarSearchController();
            //{
            //    fullModelFixedNoAry = carSearcher.GetFullModelFixedNoArray(seachedCarInfo.CarModelInfo);
            //}

            //return fullModelFixedNoAry;

            fullModelFixedNoAry = new int[0];
            freeSrchMdlFxdNoAry = new string[0];

            if (seachedCarInfo.CarModelInfo.Count.Equals(0)) return;
            CarSearchController carSearcher = new CarSearchController();
            {
                carSearcher.GetFullModelFixedNoArrayWithFreeSrchMdlFxdNo(seachedCarInfo.CarModelInfo, out fullModelFixedNoAry, out freeSrchMdlFxdNoAry);
            }
            // 2011/03/08 <<<
        }

        // 2011/03/08 Add >>>
        /// <summary>
        /// 装備情配列を取得します。
        /// </summary>
        /// <param name="seachedCarInfo">車両検索結果</param>
        /// <returns>装備情報配列</returns>
        public static byte[] GetCategoryObjAry(PMKEN01010E seachedCarInfo)
        {
            if (seachedCarInfo.CEqpDefDspInfo == null) return new byte[0];

            return seachedCarInfo.CEqpDefDspInfo.GetByteArray(true);
        }
        // 2011/03/08 Add <<<

        // ADD 2013/04/05 吉岡 2013/05/22配信 SCM障害№50 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 国産／外車区分
        /// </summary>
        /// <param name="searchedCarInfo">車両検索結果</param>
        /// <returns>国産／外車区分 1:国産 2:外車</returns>
        public static int GetDomesticForeignCode(PMKEN01010E searchedCarInfo)
        {
            if (searchedCarInfo.CarModelUIData == null) return 0;
            if (searchedCarInfo.CarModelUIData.Count.Equals(0)) return 0;
            return searchedCarInfo.CarModelUIData[SINGLE_ROW].DomesticForeignCode;
        }
        // ADD 2013/04/05 吉岡 2013/05/22配信 SCM障害№50 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        #endregion // </車両検索結果>

        #region <売上データのキー>

        /// <summary>
        /// 売上明細データのキーを取得します。
        /// </summary>
        /// <param name="salesDetail">売上明細データ</param>
        /// <returns>企業コード("0000000000000000") + 受注ステータス("00") + 売上明細通番("000000000000")</returns>
        public static string GetSalesDetailKey(SalesDetail salesDetail)
        {
            return SCMEntityUtil.FormatEnterpriseCode(salesDetail.EnterpriseCode)
                + salesDetail.AcptAnOdrStatus.ToString("00")
                + salesDetail.SalesSlipDtlNum.ToString("000000000000");
        }

        #endregion // </売上データのキー>

        #region <Profile>

        /// <summary>
        /// SCM受注明細データ(問合せ・発注)の簡易情報を取得します。
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <returns>SCM受注明細データ(問合せ・発注)の簡易情報</returns>
        public static string GetProfile(ISCMOrderDetailRecord detailRecord)
        {
            StringBuilder profile = new StringBuilder();
            {
                profile.Append("\t").Append("問合せ先企業コード：").Append(detailRecord.InqOtherEpCd).Append(Environment.NewLine);
                profile.Append("\t").Append("問合せ先拠点コード：").Append(detailRecord.InqOtherSecCd).Append(Environment.NewLine);
                profile.Append("\t").Append("問合せ番号：").Append(detailRecord.InquiryNumber).Append(Environment.NewLine);
                profile.Append("\t").Append("更新年月日：").Append(detailRecord.UpdateDate).Append(Environment.NewLine);
                profile.Append("\t").Append("更新時分秒ミリ秒：").Append(detailRecord.UpdateTime).Append(Environment.NewLine);
                profile.Append("\t").Append("問合せ行番号：").Append(detailRecord.InqRowNumber).Append(Environment.NewLine);
                profile.Append("\t").Append("問合せ行番号枝番：").Append(detailRecord.InqRowNumDerivedNo).Append(Environment.NewLine);
                profile.Append("\t").Append("商品番号：").Append(detailRecord.GoodsNo).Append(Environment.NewLine);
                profile.Append("\t").Append("BL商品コード：").Append(detailRecord.BLGoodsCode);
            }
            return profile.ToString();
        }

        /// <summary>
        /// SCM受注明細データ(問合せ・発注)の簡易情報を取得します。
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <returns>SCM受注明細データ(問合せ・発注)の簡易情報</returns>
        public static string GetLabel(ISCMOrderDetailRecord detailRecord)
        {
            StringBuilder profile = new StringBuilder();
            {
                profile.Append("問合せ番号：").Append(detailRecord.InquiryNumber).Append(Environment.NewLine);
                profile.Append("問合せ行番号：").Append(detailRecord.InqRowNumber).Append(Environment.NewLine);
                profile.Append("問合せ行番号枝番：").Append(detailRecord.InqRowNumDerivedNo).Append(Environment.NewLine);
                profile.Append("商品種別：").Append(detailRecord.GoodsDivCd);
            }
            return profile.ToString();
        }

        /// <summary>
        /// SCM受注明細データ(回答)の簡易情報を取得します。
        /// </summary>
        /// <param name="answerRecord">SCM受注明細データ(回答)のレコード</param>
        /// <returns>SCM受注明細データ(回答)の簡易情報</returns>
        public static string GetProfile(ISCMOrderAnswerRecord answerRecord)
        {
            StringBuilder profile = new StringBuilder();
            {
                profile.Append("問合せ番号：").Append(answerRecord.InquiryNumber).Append(Environment.NewLine);
                profile.Append("問合せ行番号：").Append(answerRecord.InqRowNumber).Append(Environment.NewLine);
                profile.Append("問合せ行番号枝番：").Append(answerRecord.InqRowNumDerivedNo).Append(Environment.NewLine);
                profile.Append("商品種別：").Append(answerRecord.GoodsDivCd).Append(Environment.NewLine);
                profile.Append("売上伝票番号：").Append(answerRecord.SalesSlipNum);
            }
            return profile.ToString();
        }

        /// <summary>
        /// SCM受注データ(リモート用ワーク)の簡易情報を取得します。
        /// </summary>
        /// <param name="scmAcOdrDataWork">SCM受注データ(リモート用ワーク)のレコード</param>
        /// <returns>SCM受注データ(リモート用ワーク)の簡易情報</returns>
        public static string GetProfile(SCMAcOdrDataWork scmAcOdrDataWork)
        {
            StringBuilder profile = new StringBuilder();
            {
                profile.Append("問合せ番号：").Append(scmAcOdrDataWork.InquiryNumber).Append(Environment.NewLine);
                profile.Append("受注ステータス：").Append(scmAcOdrDataWork.AcptAnOdrStatus);
            }
            return profile.ToString();
        }

        /// <summary>
        /// 商品連結データの簡易情報を取得します。
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <returns>商品連結データの簡易情報</returns>
        public static string GetProfile(GoodsUnitData goodsUnitData)
        {
            const char DELIM = ',';

            StringBuilder profile = new StringBuilder();
            {
                profile.Append("BLコード：").Append(goodsUnitData.BLGoodsCode).Append(DELIM);
                profile.Append("メーカーコード：").Append(goodsUnitData.GoodsMakerCd).Append(DELIM);
                profile.Append("中分類コード：").Append(goodsUnitData.GoodsMGroup).Append(DELIM);
                profile.Append("商品番号：").Append(goodsUnitData.GoodsNo).Append(DELIM);
                profile.Append("商品名称：").Append(goodsUnitData.GoodsName).Append(DELIM);
                profile.Append("BLグループコード：").Append(goodsUnitData.BLGroupCode).Append(DELIM);
                profile.Append("得意先コード：").Append("?").Append(DELIM);
                profile.Append("拠点コード：").Append(goodsUnitData.SectionCode).Append(DELIM);
                profile.Append("企業コード：").Append(goodsUnitData.EnterpriseCode);
            }
            return profile.ToString();
        }

        /// <summary>
        /// 商品連結データの簡易情報を取得します。
        /// </summary>
        /// <param name="goodsUnitDataList">商品連結データ</param>
        /// <returns>商品連結データの簡易情報</returns>
        public static string GetProfile(List<GoodsUnitData> goodsUnitDataList)
        {
            StringBuilder profile = new StringBuilder();
            {
                foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
                {
                    profile.Append(GetProfile(goodsUnitData)).Append(Environment.NewLine);
                }
            }
            return profile.ToString();
        }

        /// <summary>
        /// SCM商品連結データの簡易情報を取得します。
        /// </summary>
        /// <param name="scmGoodsUnitData">SCM商品連結データ</param>
        /// <returns>SCM商品連結データの簡易情報</returns>
        public static string GetProfile(SCMGoodsUnitData scmGoodsUnitData)
        {
            const char DELIM = ',';

            StringBuilder profile = new StringBuilder();
            {
                profile.Append("BLコード：").Append(scmGoodsUnitData.RealGoodsUnitData.BLGoodsCode).Append(DELIM);
                profile.Append("メーカーコード：").Append(scmGoodsUnitData.RealGoodsUnitData.GoodsMakerCd).Append(DELIM);
                profile.Append("中分類コード：").Append(scmGoodsUnitData.RealGoodsUnitData.GoodsMGroup).Append(DELIM);
                profile.Append("商品番号：").Append(scmGoodsUnitData.RealGoodsUnitData.GoodsNo).Append(DELIM);
                profile.Append("商品名称：").Append(scmGoodsUnitData.RealGoodsUnitData.GoodsName).Append(DELIM);
                profile.Append("BLグループコード：").Append(scmGoodsUnitData.RealGoodsUnitData.BLGroupCode).Append(DELIM);
                profile.Append("得意先コード：").Append(scmGoodsUnitData.CustomerCode).Append(DELIM);
                profile.Append("拠点コード：").Append(scmGoodsUnitData.RealGoodsUnitData.SectionCode).Append(DELIM);
                profile.Append("企業コード：").Append(scmGoodsUnitData.RealGoodsUnitData.EnterpriseCode).Append(DELIM);
                profile.Append("表示順位：").Append(scmGoodsUnitData.RealGoodsUnitData.PrimePartsDisplayOrder);
            }
            return profile.ToString();
        }

        /// <summary>
        /// SCM商品連結データの簡易情報を取得します。
        /// </summary>
        /// <param name="scmGoodsUnitDataList">SCM商品連結データのリスト</param>
        /// <returns>SCM商品連結データの簡易情報</returns>
        public static string GetProfile(IList<SCMGoodsUnitData> scmGoodsUnitDataList)
        {
            StringBuilder profile = new StringBuilder();
            {
                foreach (SCMGoodsUnitData scmGoodsUnitData in scmGoodsUnitDataList)
                {
                    profile.Append("\t").Append(GetProfile(scmGoodsUnitData)).Append(Environment.NewLine);
                }
            }
            return profile.ToString();
        }

        #endregion // </Profile>

        /// <summary>
        /// 更新時分秒ミリ秒を取得します。
        /// </summary>
        /// <param name="updateDate">更新年月日(システム日付を使用する場合、<c>DateTime.Now</c>を使用すること)</param>
        /// <returns>HHmmssxxx</returns>
        public static int GetUpdateTime(DateTime updateDate)
        {
            string HHmmss = updateDate.ToString("HHmmss");
            string msec = updateDate.Millisecond.ToString("000");
            return int.Parse(HHmmss + msec);
        }

        #region <有効なレコードであるかの判断>

        /// <summary>
        /// 有効なレコードであるか判断します。
        /// </summary>
        /// <param name="scmTtlSt">SCM全体設定マスタのレコード</param>
        /// <returns>
        /// <c>true</c> :有効です。<br/>
        /// <c>false</c>:無効です。
        /// </returns>
        public static bool IsAvailableRecord(SCMTtlSt scmTtlSt)
        {
            #region <Guard Phrase>

            if (scmTtlSt == null) return false;

            #endregion // </Guard Phrase>

            if (
                !string.IsNullOrEmpty(scmTtlSt.EnterpriseCode.Trim())
                    &&
                !string.IsNullOrEmpty(scmTtlSt.SectionCode.Trim())
                    &&
                scmTtlSt.LogicalDeleteCode.Equals(0)
            )
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 有効なレコードであるか判断します。
        /// </summary>
        /// <param name="scmMrktPriSt">SCM相場価格設定マスタのレコード</param>
        /// <returns>
        /// <c>true</c> :有効です。<br/>
        /// <c>false</c>:無効です。
        /// </returns>
        public static bool IsAvailableRecord(SCMMrktPriSt scmMrktPriSt)
        {
            #region <Guard Phrase>

            if (scmMrktPriSt == null) return false;

            #endregion // </Guard Phrase>

            if (
                !string.IsNullOrEmpty(scmMrktPriSt.EnterpriseCode.Trim())
                    &&
                !string.IsNullOrEmpty(scmMrktPriSt.SectionCode.Trim())
                    &&
                scmMrktPriSt.LogicalDeleteCode.Equals(0)
            )
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 有効なレコードであるか判断します。
        /// </summary>
        /// <param name="scmDeliDateSt">SCM納期設定マスタのレコード</param>
        /// <returns>
        /// <c>true</c> :有効です。<br/>
        /// <c>false</c>:無効です。
        /// </returns>
        public static bool IsAvailableRecord(SCMDeliDateSt scmDeliDateSt)
        {
            #region <Guard Phrase>

            if (scmDeliDateSt == null) return false;

            #endregion // </Guard Phrase>

            if (
                !string.IsNullOrEmpty(scmDeliDateSt.EnterpriseCode.Trim())
                //    &&
                //!string.IsNullOrEmpty(scmDeliDateSt.SectionCode.Trim())
                    &&
                scmDeliDateSt.LogicalDeleteCode.Equals(0)
            )
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 有効なレコードであるか判断します。
        /// </summary>
        /// <param name="scmPriorSt">SCM優先設定マスタのレコード</param>
        /// <returns>
        /// <c>true</c> :有効です。<br/>
        /// <c>false</c>:無効です。
        /// </returns>
        public static bool IsAvailableRecord(SCMPriorSt scmPriorSt)
        {
            #region <Guard Phrase>

            if (scmPriorSt == null) return false;

            #endregion // </Guard Phrase>

            if (
                !string.IsNullOrEmpty(scmPriorSt.EnterpriseCode.Trim())
                    &&
                !string.IsNullOrEmpty(scmPriorSt.SectionCode.Trim())
                    &&
                scmPriorSt.LogicalDeleteCode.Equals(0)
            )
            {
                return true;
            }
            return false;
        }

        #endregion // </有効なレコードであるかの判断>

        /// <summary>
        /// 値引適用区分の名称を取得します。
        /// </summary>
        /// <param name="scmTotalSetting">SCM全体設定</param>
        /// <returns>
        /// SCM全体設定.値引適用区分<br/>
        /// 0:しない/1:全て/2:外装品以外/3:重点品目
        /// </returns>
        public static string GetDiscountApplyName(SCMTtlSt scmTotalSetting)
        {
            if (scmTotalSetting == null) return string.Empty;

            switch (scmTotalSetting.DiscountApplyCd)
            {
                case 0: // しない
                    return "しない";
                case 1: // 全て
                    return "全て";
                case 2: // 外装品以外
                    return "外装品以外";
                case 3: // 重点品目
                    return "重点品目";
                default:
                    return string.Empty;
            }
        }

        #region <ログにダンプ>

        /// <summary>
        /// ログにダンプします。
        /// </summary>
        /// <param name="cachedImportantPrtStMap">重点品目設定のキャッシュデータ</param>
        public static void DumpToLog(Dictionary<ImportantPrtStAcs.DICKEY, ImportantPrtSt> cachedImportantPrtStMap)
        {
            const string TAB = "\t";
            const string COMMA = ",";

            StringBuilder dumpData = new StringBuilder();
            {
                if (cachedImportantPrtStMap != null)
                {
                    if (cachedImportantPrtStMap.Count > 0)
                    {
                        dumpData.Append("重点品目設定のキャッシュデータの件数=").Append(cachedImportantPrtStMap.Count).Append(Environment.NewLine);
                        dumpData.Append("得意先").Append(COMMA);
                        dumpData.Append("拠点").Append(COMMA);
                        dumpData.Append("メーカー").Append(COMMA);
                        dumpData.Append("中分類").Append(COMMA);
                        dumpData.Append("BL").Append(COMMA);
                        dumpData.Append("品番").Append(COMMA);
                        dumpData.Append("有効区分").Append(COMMA);
                        dumpData.Append("論理削除").Append(Environment.NewLine);
                    }
                    else
                    {
                        dumpData.Append(TAB).Append("重点品目設定のキャッシュデータの件数=0");
                    }
                    foreach (ImportantPrtSt importantPrtSt in cachedImportantPrtStMap.Values)
                    {
                        dumpData.Append(importantPrtSt.CustomerCode).Append(COMMA);
                        dumpData.Append(importantPrtSt.SectionCode).Append(COMMA);
                        dumpData.Append(importantPrtSt.GoodsMakerCd).Append(COMMA);
                        dumpData.Append(importantPrtSt.GoodsMGroup).Append(COMMA);
                        dumpData.Append(importantPrtSt.BLGoodsCode).Append(COMMA);
                        dumpData.Append(importantPrtSt.GoodsNo).Append(COMMA);
                        dumpData.Append(importantPrtSt.ValidDivCd).Append(COMMA);
                        dumpData.Append(importantPrtSt.LogicalDeleteCode).Append(Environment.NewLine);
                    }
                }
                else
                {
                    dumpData.Append(TAB).Append("重点品目設定のキャッシュデータが null です。");
                }
            }
            string msg = "重点品目設定のキャッシュデータ" + Environment.NewLine + dumpData.ToString();
            EasyLogger.WriteDebugLog("ImportantPrtStAcs", "GetImportantPrtSt()", LogHelper.GetDebugMsg(msg));
        }

        /// <summary>
        /// ログにダンプします。
        /// </summary>
        /// <param name="cachedCampaignMngMap">キャンペーン管理のキャッシュデータ</param>
        public static void DumpToLog(Dictionary<CampaignMngAcs.DICKEY, CampaignMng> cachedCampaignMngMap)
        {
            const string TAB = "\t";
            const string COMMA = ",";

            StringBuilder dumpData = new StringBuilder();
            {
                if (cachedCampaignMngMap != null)
                {
                    if (cachedCampaignMngMap.Count > 0)
                    {
                        dumpData.Append("キャンペーン管理のキャッシュデータの件数=").Append(cachedCampaignMngMap.Count).Append(Environment.NewLine);
                        //dumpData.Append("得意先").Append(COMMA);
                        dumpData.Append("拠点").Append(COMMA);
                        dumpData.Append("メーカー").Append(COMMA);
                        dumpData.Append("中分類").Append(COMMA);
                        dumpData.Append("BL").Append(COMMA);
                        dumpData.Append("品番").Append(COMMA);
                        dumpData.Append("掛率").Append(COMMA);
                        dumpData.Append("価格").Append(COMMA);
                        dumpData.Append("論理削除").Append(Environment.NewLine);
                    }
                    else
                    {
                        dumpData.Append(TAB).Append("キャンペーン管理のキャッシュデータの件数=0");
                    }
                    foreach (CampaignMng campaignMng in cachedCampaignMngMap.Values)
                    {
                        //dumpData.Append(importantPrtSt.CustomerCode).Append(COMMA);
                        dumpData.Append(campaignMng.SectionCode).Append(COMMA);
                        dumpData.Append(campaignMng.GoodsMakerCd).Append(COMMA);
                        dumpData.Append(campaignMng.GoodsMGroup).Append(COMMA);
                        dumpData.Append(campaignMng.BLGoodsCode).Append(COMMA);
                        dumpData.Append(campaignMng.GoodsNo).Append(COMMA);
                        dumpData.Append(campaignMng.RateVal).Append(COMMA);
                        dumpData.Append(campaignMng.PriceFl).Append(COMMA);
                        dumpData.Append(campaignMng.LogicalDeleteCode).Append(Environment.NewLine);
                    }
                }
                else
                {
                    dumpData.Append(TAB).Append("キャンペーン管理のキャッシュデータが null です。");
                }
            }
            string msg = "キャンペーン管理のキャッシュデータ" + Environment.NewLine + dumpData.ToString();
            EasyLogger.WriteDebugLog("CampaignMngAcs", "GetRatePriceOfCampaignMng()", LogHelper.GetDebugMsg(msg));
        }

        #endregion // </ログにダンプ>
        #region----- DEL 2011/10/12 --------------------------->>>>>
        //// ----- ADD 2011/10/11 --------------------------->>>>>
        ///// <summary>
        ///// 車台番号→シャシー№生成処理
        ///// </summary>
        ///// <param name="frameNo">車台番号</param>
        ///// <param name="frameModel">車台型式</param>
        ///// <param name="chassisNo">シャシNo</param>
        ///// <returns>STATUS [0:生成完了 0以外:生成失敗]</returns>
        //public static int GenerateChassisNoFrameFromFrameNo(string frameNo, out string frameModel, out string chassisNo)
        //{
        //    frameModel = "";
        //    chassisNo = "";

        //    if (frameNo == "")
        //    {
        //        frameModel = "";
        //        chassisNo = "";
        //        return 0;
        //    }

        //    // 全角文字列が含まれている場合は生成不能
        //    if (!IsOneByteChar(frameNo.Trim()))
        //    {
        //        frameModel = "";
        //        chassisNo = "";
        //        return 0;
        //    }

        //    int length = frameNo.Length;
        //    string[] split = frameNo.Split(new Char[] { '-' });

        //    if (split.Length < 0)
        //    {
        //        // 分割した結果の配列数が1以下の場合は算定不能
        //        return 1;
        //    }
        //    else if (split.Length == 1)
        //    {
        //        frameModel = split[0];					// 車台型式
        //        chassisNo = "";						// シャシーNo
        //    }
        //    else if (split.Length == 2)
        //    {
        //        frameModel = split[0];					// 車台型式
        //        chassisNo = split[1];					// シャシーNo
        //    }
        //    else
        //    {
        //        chassisNo = split[1];

        //        // 配列の２以降を合成する
        //        for (int i = 3; i < split.Length; i++)
        //        {
        //            chassisNo += "-" + split[i];
        //        }

        //        frameModel = split[0];					// 車台型式
        //    }

        //    // 桁数チェック
        //    if (frameModel.Length > 16)
        //    {
        //        frameModel = frameModel.Remove(16, frameModel.Length - 16);
        //    }
        //    if (chassisNo.Length > 18)
        //    {
        //        chassisNo = chassisNo.Remove(18, chassisNo.Length - 18);
        //    }

        //    return 0;
        //}

        ///// <summary>
        ///// 1バイト文字で構成された文字列であるか判定 
        ///// 1バイト文字のみで構成された文字列 : True 
        ///// 2バイト文字が含まれている文字列 : False
        ///// </summary>
        ///// <param name="str"></param>
        ///// <returns>status</returns>
        //private static bool IsOneByteChar(string str)
        //{
        //    byte[] byte_data = System.Text.Encoding.GetEncoding(932).GetBytes(str);
        //    if (byte_data.Length == str.Length)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        //// ----- ADD 2011/10/11 ---------------------------<<<<<
        #endregion----- DEL 2011/10/12 ---------------------------<<<<<
    }
}

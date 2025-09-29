//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//zz
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/05/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2010/04/05  修正内容 : 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2010/06/17  修正内容 : テーブルのレイアウト変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2010/06/24  修正内容 : 「回答作成区分」が「0:自動」の場合、「CMT連携区分」を設定する
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上 千加子
// 修 正 日  2015/01/30  修正内容 : SCM高速化 生産年式、車台番号対応　生産年式をDateTime型に変換する
//----------------------------------------------------------------------------//
// 管理番号  11470007-00 作成担当 : 田建委
// 修 正 日  2018/04/16  修正内容 : SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData.Util
{
    // ADD 2010/06/24 「回答作成区分」が「0:自動」の場合、「CMT連携区分」を設定する ---------->>>>>
    /// <summary>
    /// 回答作成区分列挙型
    /// </summary>
    /// <remarks>
    /// PMSCM01012A::SCMSalesDataMaker.cs より移設
    /// (列挙型名を AnswerCreateDiv → AnswerCreateDivValue に変更)
    /// </remarks>
    public enum AnswerCreateDivValue : int
    {
        /// <summary>0:自動</summary>
        Auto = 0,
        /// <summary>1:手動(Web)</summary>
        ManualWeb = 1,
        /// <summary>2:手動(その他)</summary>
        ManualEtc = 2
    }

    /// <summary>
    /// 問合せ・発注種別列挙型
    /// </summary>
    /// <remarks>
    /// PMSCM01012A::SCMDataHelper.cs より移設
    /// (列挙型名を InqOrdDivCd → InqOrdDivCdValue に変更)
    /// </remarks>
    public enum InqOrdDivCdValue : int
    {
        /// <summary>1:問合せ</summary>
        Inquiry = 1,
        /// <summary>2:発注</summary>
        Ordering = 2
    }

    /// <summary>
    /// CMT連携区分列挙型
    /// </summary>
    public enum CMTCooprtDivValue : short
    {
        /// <summary>0:連携なし</summary>
        None = 0,
        /// <summary>1:連携あり</summary>
        Cooperates = 1,
        /// <summary>11:問合せ(自動)</summary>
        MadeInquiriesAutomatically = 11,
        /// <summary>12:発注(自動)</summary>
        OrderedAutomatically = 12
    }
    // ADD 2010/06/24 「回答作成区分」が「0:自動」の場合、「CMT連携区分」を設定する ----------<<<<<

    /// <summary>
    /// SCM受注データユーティリティ
    /// </summary>
    public static class SCMEntityUtil
    {
        #region <日時>

        /// <summary>日付フォーマット</summary>
        public const string YYYYMMDD = "yyyyMMdd";
        /// <summary>日時フォーマット</summary>
        public const string YYYYMMDDHHMMSS = "yyyyMMddhhmmss";

        /// <summary>
        /// 日付を数値に変換します。
        /// </summary>
        /// <param name="date">日付</param>
        /// <returns>yyyyMMdd</returns>
        public static int ConvertToYYYYMMDD(DateTime date)
        {
            string yyyyMMdd = date.ToString(YYYYMMDD);
            return int.Parse(yyyyMMdd);
        }

        /// <summary>
        /// 日付に変換します。
        /// </summary>
        /// <param name="yyyyMMdd">日付数(yyyyMMdd)</param>
        /// <returns>"yyyy/MM/dd"</returns>
        public static DateTime ConvertToDate(int yyyyMMdd)
        {
            #region <Guard Phrase>

            if (yyyyMMdd <= 0) return DateTime.MinValue;

            #endregion // </Guard Phrase>

            string yyyy = yyyyMMdd.ToString().Substring(0, 4);
            string MM   = yyyyMMdd.ToString().Substring(4, 2);
            string dd   = yyyyMMdd.ToString().Substring(6, 2);

            return new DateTime(int.Parse(yyyy), int.Parse(MM), int.Parse(dd));
        }

        /// <summary>
        /// 日時に変換します。
        /// </summary>
        /// <param name="longNumber">日時数</param>
        /// <returns>"yyyy/MM/dd hh:mm:ss"</returns>
        public static DateTime ConvertToDateTime(long longNumber)
        {
            #region <Guard Phrase>

            if (longNumber <= 0) return DateTime.MinValue;

            #endregion // </Guard Phrase>

            return new DateTime(longNumber);
        }

        /// <summary>
        /// 日時を数値に変換します。
        /// </summary>
        /// <param name="dateTime">日時</param>
        /// <returns>Convert.ToInt64(dateTime)</returns>
        public static long ConvertToLong(DateTime dateTime)
        {
            return dateTime.Ticks;
        }

        #endregion // </日時>

        #region <キー>

        /// <summary>
        /// SCM受注データレコードのキーを取得します。
        /// </summary>
        /// <param name="headerRecord">SCM受注データレコード</param>
        /// <returns>
        /// 問合せ元企業コード + 問合せ元拠点コード + 問合せ先企業コード + 問合せ先拠点コード + 問合せ番号 + 更新年月日 + 更新時分秒ミリ秒 + 問合せ発注種別
        /// </returns>
        public static string GetHeaderRecordKey(ISCMOrderHeaderRecord headerRecord)
        {
            StringBuilder key = new StringBuilder();
            {
                key.Append(FormatEnterpriseCode(headerRecord.InqOriginalEpCd.Trim()));         // 問合せ元企業コード//@@@@20230303
                key.Append(FormatSectionCode(headerRecord.InqOriginalSecCd));           // 問合せ元拠点コード
                key.Append(FormatEnterpriseCode(headerRecord.InqOtherEpCd));            // 問合せ先企業コード
                key.Append(FormatSectionCode(headerRecord.InqOtherSecCd));              // 問合せ先拠点コード
                key.Append(headerRecord.InquiryNumber.ToString(INQUIRY_NUMBER_FORMAT)); // 問合せ番号
                key.Append(headerRecord.UpdateDate.ToString(UPDATE_DATE_FORMAT));       // 更新年月日
                key.Append(headerRecord.UpdateTime.ToString(UPDATE_TIME_FORMAT));       // 更新時分秒ミリ秒
                key.Append(headerRecord.AcptAnOdrStatus.ToString(ACPT_AN_ODR_STATUS));  // 受注ステータス
                key.Append(FormatSalseSlipNum(headerRecord.SalesSlipNum));              // 売上伝票番号

                key.Append(headerRecord.InqOrdDivCd.ToString(INQ_ORD_DIV_CD_FORMAT));   // 問合せ・発注種別
            }
            return key.ToString();
        }

        /// <summary>
        /// SCM受注データ(車両情報)レコードのキーを取得します。
        /// </summary>
        /// <param name="carRecord">SCM受注データ(車両情報)レコード</param>
        /// <returns>
        /// 受注ステータスおよび売上伝票番号は
        /// 自動回答処理のSCM受注系データの管理アルゴリズム上、不都合であるため、
        /// 含みません。
        /// </returns>
        public static string GetCarRecordKey(ISCMOrderCarRecord carRecord)
        {
            StringBuilder key = new StringBuilder();
            {
                key.Append(FormatEnterpriseCode(carRecord.InqOriginalEpCd.Trim()));            // 問合せ元企業コード//@@@@20230303
                key.Append(FormatSectionCode(carRecord.InqOriginalSecCd));              // 問合せ元拠点コード
                key.Append(carRecord.InquiryNumber.ToString(INQUIRY_NUMBER_FORMAT));    // 問合せ番号

                // ↓自動回答処理のSCM受注系データの管理アルゴリズム上、不都合であるため、含めない
                // key.Append(carRecord.AcptAnOdrStatus.ToString(ACPT_AN_ODR_STATUS));     // 受注ステータス
                // key.Append(FormatSalseSlipNum(carRecord.SalesSlipNum));                 // 売上伝票番号
            }
            return key.ToString();
        }

        /// <summary>
        /// SCM受注データ(車両情報)レコードのキーを取得します。
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)レコード</param>
        /// <returns></returns>
        public static string GetCarRecordKey(ISCMOrderDetailRecord detailRecord)
        {
            StringBuilder key = new StringBuilder();
            {
                key.Append(FormatEnterpriseCode(detailRecord.InqOriginalEpCd.Trim()));         // 問合せ元企業コード//@@@@20230303
                key.Append(FormatSectionCode(detailRecord.InqOriginalSecCd));           // 問合せ元拠点コード
                key.Append(detailRecord.InquiryNumber.ToString(INQUIRY_NUMBER_FORMAT)); // 問合せ番号
            }
            return key.ToString();
        }

        /// <summary>
        /// SCM受注明細データ(問合せ・発注)レコードのキーを取得します。
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)レコード</param>
        /// <returns></returns>
        public static string GetDetailRecordKey(ISCMOrderDetailRecord detailRecord)
        {
            StringBuilder key = new StringBuilder();
            {
                key.Append(FormatEnterpriseCode(detailRecord.InqOriginalEpCd.Trim()));         // 問合せ元企業コード//@@@@20230303
                key.Append(FormatSectionCode(detailRecord.InqOriginalSecCd));           // 問合せ元拠点コード
                key.Append(FormatEnterpriseCode(detailRecord.InqOtherEpCd));            // 問合せ先企業コード
                key.Append(FormatSectionCode(detailRecord.InqOtherSecCd));              // 問合せ先拠点コード
                key.Append(detailRecord.InquiryNumber.ToString(INQUIRY_NUMBER_FORMAT)); // 問合せ番号
                key.Append(detailRecord.UpdateDate.ToString(UPDATE_DATE_FORMAT));       // 更新年月日
                key.Append(detailRecord.UpdateTime.ToString(UPDATE_TIME_FORMAT));       // 更新時分秒ミリ秒
                key.Append(detailRecord.InqRowNumber.ToString(INQ_ROW_NUMBER_FORMAT));  // 問合せ行番号
                key.Append(detailRecord.InqRowNumDerivedNo.ToString(INQ_ROW_NUM_DERIVED_NO_FORMAT));    // 問合せ行番号枝番

                key.Append(detailRecord.InqOrdDivCd.ToString(INQ_ORD_DIV_CD_FORMAT));   // 問合せ・発注種別
            }
            return key.ToString();
        }

        /// <summary>
        /// SCM受注明細データ(回答)レコードのキーを取得します。
        /// </summary>
        /// <param name="answerRecord">SCM受注明細データ(回答)レコード</param>
        /// <returns></returns>
        public static string GetAnswerRecordKey(ISCMOrderAnswerRecord answerRecord)
        {
            StringBuilder key = new StringBuilder();
            {
                key.Append(FormatEnterpriseCode(answerRecord.InqOriginalEpCd.Trim()));         // 問合せ元企業コード//@@@@20230303
                key.Append(FormatSectionCode(answerRecord.InqOriginalSecCd));           // 問合せ元拠点コード
                key.Append(FormatEnterpriseCode(answerRecord.InqOtherEpCd));            // 問合せ先企業コード
                key.Append(FormatSectionCode(answerRecord.InqOtherSecCd));              // 問合せ先拠点コード
                key.Append(answerRecord.InquiryNumber.ToString(INQUIRY_NUMBER_FORMAT)); // 問合せ番号
                key.Append(answerRecord.UpdateDate.ToString(UPDATE_DATE_FORMAT));       // 更新年月日
                key.Append(answerRecord.UpdateTime.ToString(UPDATE_TIME_FORMAT));       // 更新時分秒ミリ秒
                key.Append(answerRecord.InqRowNumber.ToString(INQ_ROW_NUMBER_FORMAT));  // 問合せ行番号

                // 問合せ行番号枝番
                key.Append(
                    System.Math.Abs(answerRecord.InqRowNumDerivedNo).ToString(INQ_ROW_NUM_DERIVED_NO_FORMAT)
                );

                key.Append(answerRecord.InqOrdDivCd.ToString(INQ_ORD_DIV_CD_FORMAT));   // 問合せ・発注種別
            }
            return key.ToString();
        }

        /// <summary>
        /// SCM受注データレコードの関連キーを取得します。
        /// </summary>
        /// <param name="headerRecord">SCM受注データレコード</param>
        /// <returns>問合せ元企業コード + 問合せ元拠点コード + 問合せ番号</returns>
        public static string GetRelationKey(ISCMOrderHeaderRecord headerRecord)
        {
            StringBuilder key = new StringBuilder();
            {
                key.Append(FormatEnterpriseCode(headerRecord.InqOriginalEpCd.Trim()));         // 問合せ元企業コード//@@@@20230303
                key.Append(FormatSectionCode(headerRecord.InqOriginalSecCd));           // 問合せ元拠点コード
                key.Append(FormatEnterpriseCode(headerRecord.InqOtherEpCd));            // 問合せ先企業コード
                key.Append(FormatSectionCode(headerRecord.InqOtherSecCd));              // 問合せ先拠点コード
                key.Append(headerRecord.InquiryNumber.ToString(INQUIRY_NUMBER_FORMAT)); // 問合せ番号
            }
            return key.ToString();
        }

        /// <summary>
        /// SCM受注データレコードの関連キーを取得します。
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)レコード</param>
        /// <returns>問合せ元企業コード + 問合せ元拠点コード + 問合せ番号</returns>
        public static string GetRelationKey(ISCMOrderDetailRecord detailRecord)
        {
            StringBuilder key = new StringBuilder();
            {
                key.Append(FormatEnterpriseCode(detailRecord.InqOriginalEpCd.Trim()));         // 問合せ元企業コード//@@@@20230303
                key.Append(FormatSectionCode(detailRecord.InqOriginalSecCd));           // 問合せ元拠点コード
                key.Append(FormatEnterpriseCode(detailRecord.InqOtherEpCd));            // 問合せ先企業コード
                key.Append(FormatSectionCode(detailRecord.InqOtherSecCd));              // 問合せ先拠点コード
                key.Append(detailRecord.InquiryNumber.ToString(INQUIRY_NUMBER_FORMAT)); // 問合せ番号
            }
            return key.ToString();
        }

        /// <summary>
        /// SCM受注データレコードの関連キーを取得します。
        /// </summary>
        /// <param name="answerRecord">SCM受注明細データ(回答)レコード</param>
        /// <returns>問合せ元企業コード + 問合せ元拠点コード + 問合せ番号</returns>
        public static string GetRelationKey(ISCMOrderAnswerRecord answerRecord)
        {
            StringBuilder key = new StringBuilder();
            {
                key.Append(FormatEnterpriseCode(answerRecord.InqOriginalEpCd.Trim()));         // 問合せ元企業コード//@@@@20230303
                key.Append(FormatSectionCode(answerRecord.InqOriginalSecCd));           // 問合せ元拠点コード
                key.Append(FormatEnterpriseCode(answerRecord.InqOtherEpCd));            // 問合せ先企業コード
                key.Append(FormatSectionCode(answerRecord.InqOtherSecCd));              // 問合せ先拠点コード
                key.Append(answerRecord.InquiryNumber.ToString(INQUIRY_NUMBER_FORMAT)); // 問合せ番号
            }
            return key.ToString();
        }

        /// <summary>
        /// 問合せ行番号までのキーを取得します。
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)レコード</param>
        /// <returns></returns>
        public static string GetInqRowNumberKey(ISCMOrderDetailRecord detailRecord)
        {
            StringBuilder key = new StringBuilder();
            {
                key.Append(FormatEnterpriseCode(detailRecord.InqOriginalEpCd.Trim()));         // 問合せ元企業コード//@@@@20230303
                key.Append(FormatSectionCode(detailRecord.InqOriginalSecCd));           // 問合せ元拠点コード
                key.Append(FormatEnterpriseCode(detailRecord.InqOtherEpCd));            // 問合せ先企業コード
                key.Append(FormatSectionCode(detailRecord.InqOtherSecCd));              // 問合せ先拠点コード
                key.Append(detailRecord.InquiryNumber.ToString(INQUIRY_NUMBER_FORMAT)); // 問合せ番号
                key.Append(detailRecord.UpdateDate.ToString(UPDATE_DATE_FORMAT));       // 更新年月日
                key.Append(detailRecord.UpdateTime.ToString(UPDATE_TIME_FORMAT));       // 更新時分秒ミリ秒
                key.Append(detailRecord.InqRowNumber.ToString(INQ_ROW_NUMBER_FORMAT));  // 問合せ行番号
            }
            return key.ToString();
        }

        // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ---------->>>>>
        /// <summary>
        /// 回答済み関連キーを取得します。
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)レコード</param>
        /// <returns></returns>
        public static string GetAnsweredRelationKey(ISCMOrderDetailRecord detailRecord)
        {
            StringBuilder key = new StringBuilder();
            {
                key.Append(FormatEnterpriseCode(detailRecord.InqOriginalEpCd.Trim()));         // 問合せ元企業コード//@@@@20230303
                key.Append(FormatSectionCode(detailRecord.InqOriginalSecCd));           // 問合せ元拠点コード
                key.Append(FormatEnterpriseCode(detailRecord.InqOtherEpCd));            // 問合せ先企業コード
                key.Append(FormatSectionCode(detailRecord.InqOtherSecCd));              // 問合せ先拠点コード
                key.Append(detailRecord.InquiryNumber.ToString(INQUIRY_NUMBER_FORMAT)); // 問合せ番号
                key.Append(detailRecord.InqRowNumber.ToString(INQ_ROW_NUMBER_FORMAT));  // 問合せ行番号
                key.Append(detailRecord.InqRowNumDerivedNo.ToString(INQ_ROW_NUM_DERIVED_NO_FORMAT));    // 問合せ行番号枝番
            }
            return key.ToString();
        }

        /// <summary>
        /// 回答済み関連キーを取得します。
        /// </summary>
        /// <param name="answerRecord">SCM受注明細データ(回答)レコード</param>
        /// <returns></returns>
        public static string GetAnsweredRelationKey(ISCMOrderAnswerRecord answerRecord)
        {
            StringBuilder key = new StringBuilder();
            {
                key.Append(FormatEnterpriseCode(answerRecord.InqOriginalEpCd.Trim()));         // 問合せ元企業コード//@@@@20230303
                key.Append(FormatSectionCode(answerRecord.InqOriginalSecCd));           // 問合せ元拠点コード
                key.Append(FormatEnterpriseCode(answerRecord.InqOtherEpCd));            // 問合せ先企業コード
                key.Append(FormatSectionCode(answerRecord.InqOtherSecCd));              // 問合せ先拠点コード
                key.Append(answerRecord.InquiryNumber.ToString(INQUIRY_NUMBER_FORMAT)); // 問合せ番号
                key.Append(answerRecord.InqRowNumber.ToString(INQ_ROW_NUMBER_FORMAT));  // 問合せ行番号
                key.Append(answerRecord.InqRowNumDerivedNo.ToString(INQ_ROW_NUM_DERIVED_NO_FORMAT));    // 問合せ行番号枝番
            }
            return key.ToString();
        }
        // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ----------<<<<<

        #endregion // </キー>

        #region <書式付コード>

        /// <summary>企業コードのフォーマット</summary>
        private const string ENTERPRISE_CODE_FORMAT = "0000000000000000";
        /// <summary>拠点コードのフォーマット</summary>
        private const string SECTION_CODE_FORMAT = "00";
        /// <summary>問合せ番号のフォーマット</summary>
        private const string INQUIRY_NUMBER_FORMAT = ENTERPRISE_CODE_FORMAT;
        /// <summary>更新年月日のフォーマット</summary>
        private const string UPDATE_DATE_FORMAT = "yyyyMMdd";
        /// <summary>更新時分秒ミリ秒のフォーマット</summary>
        private const string UPDATE_TIME_FORMAT = "000000000";
        /// <summary>問合せ・発注種別のフォーマット</summary>
        private const string INQ_ORD_DIV_CD_FORMAT = "00";
        /// <summary>問合せ行番号のフォーマット</summary>
        private const string INQ_ROW_NUMBER_FORMAT = "00";
        /// <summary>問合せ行番号枝番のフォーマット</summary>
        private const string INQ_ROW_NUM_DERIVED_NO_FORMAT = "00";
        /// <summary>受注ステータスのフォーマット</summary>
        private const string ACPT_AN_ODR_STATUS = "00";
        /// <summary>売上伝票番号のフォーマット</summary>
        // 2011/02/09 >>>
        //private const string SALES_SLIP_NUM_FORMAT = "000000000";
        public const string SALES_SLIP_NUM_FORMAT = "000000000";
        // 2011/02/09 <<<
        /// <summary>従業員コードのフォーマット</summary>
        private const string EMPLOYEE_CODE_FORMAT = "000000000";

        /// <summary>
        /// 企業コードを書式付変換します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>enterpriseCodeNo.ToString("0000000000000000") ※16桁</returns>
        public static string FormatEnterpriseCode(string enterpriseCode)
        {
            return FormatCode(enterpriseCode, ENTERPRISE_CODE_FORMAT);
        }

        /// <summary>
        /// 拠点コードを書式付変換します。
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>sectionCodeNo.ToString("00") ※2桁</returns>
        public static string FormatSectionCode(string sectionCode)
        {
            return FormatCode(sectionCode, SECTION_CODE_FORMAT);
        }

        /// <summary>
        /// 売上伝票番号を書式付変換します。
        /// </summary>
        /// <param name="salseSlipNum">売上伝票番号</param>
        /// <returns>sectionCodeNo.ToString("00") ※9桁</returns>
        public static string FormatSalseSlipNum(string salseSlipNum)
        {
            return FormatCode(salseSlipNum, SALES_SLIP_NUM_FORMAT);
        }

        /// <summary>
        /// 従業員コードを書式付変換します。
        /// </summary>
        /// <param name="employeeCode">従業員コード</param>
        /// <returns>employeeCode.ToString("000000000") ※9桁</returns>
        public static string FormatEmployeeCode(string employeeCode)
        {
            return FormatCode(employeeCode, EMPLOYEE_CODE_FORMAT);
        }

        /// <summary>
        /// ○○コードを書式付変換します。
        /// </summary>
        /// <param name="code">○○コード値</param>
        /// <param name="format">書式</param>
        /// <returns>codeNo.ToString(format)</returns>
        private static string FormatCode(
            string code,
            string format
        )
        {
            long codeNo = 0;
            if (!long.TryParse(code.Trim(), out codeNo))
            {
                codeNo = 0;
            }
            return codeNo.ToString(format);
        }

        #endregion // </書式付コード>

        /// <summary>
        /// 数値に変換します。
        /// </summary>
        /// <param name="target">対象文字列</param>
        /// <returns>数値に変換できない場合、<c>0</c>を返します。</returns>
        public static int ConvertNumber(string target)
        {
            if (string.IsNullOrEmpty(target.Trim())) return 0;

            int number = 0;
            return int.TryParse(target.Trim(), out number) ? number : 0;
        }

        // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 ----------------------------->>>>>
        /// <summary>
        /// 開始生産年式を日付型(DateTime）に変換します。
        /// </summary>
        /// <param name="modelPrtsAdptYm">開始生産年式(yyyyMM)</param>
        /// <returns>開始生産年式(DateTime)</returns>
        public static DateTime ConvertModelPrtsAdptYm(int modelPrtsAdptYm)
        {
            if (modelPrtsAdptYm == 0) return DateTime.MinValue;
            DateTime sdt;
            int iyy = modelPrtsAdptYm / 100;
            int imm = modelPrtsAdptYm % 100;
            if ((iyy == 9999) || (imm == 99))
            {
                sdt = DateTime.MinValue;
            }
            else
            {
                sdt = new DateTime(iyy, imm, 1);
            }
            return sdt;
        }

        /// <summary>
        /// 終了生産年式を日付型(DateTime）に変換します。
        /// </summary>
        /// <param name="modelPrtsAblsYm">終了生産年式(yyyyMM)</param>
        /// <returns>終了生産年式(DateTime)</returns>
        public static DateTime ConvertModelPrtsAblsYm(int modelPrtsAblsYm)
        {
            if (modelPrtsAblsYm == 0) return DateTime.MinValue;
            DateTime edt;
            int iyy = modelPrtsAblsYm / 100;
            int imm = modelPrtsAblsYm % 100;
            if ((iyy == 9999) || (imm == 99))
            {
                edt = DateTime.MinValue;
            }
            else
            {
                edt = new DateTime(iyy, imm, 1);
            }
            return edt;
        }
        // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 -----------------------------<<<<<

        #region <CSV変換>

        /// <summary>カンマ</summary>
        public const string COMMA = ",";

        /// <summary>
        /// CSVに変換します。
        /// </summary>
        /// <param name="scmHeaderRecordList">SCM受注データのレコードリスト</param>
        /// <returns>CSV</returns>
        public static string ConvertCSV(IList<ISCMOrderHeaderRecord> scmHeaderRecordList)
        {
            StringBuilder csv = new StringBuilder();
            {
                #region <タイトル行>

                if (scmHeaderRecordList != null && scmHeaderRecordList.Count > 0)
                {
                    if (scmHeaderRecordList[0] is UserSCMOrderHeaderRecord)
                    {
                        #region <Userレコード>

                        csv.Append("01.作成日時").Append(COMMA);
                        csv.Append("02.更新日時").Append(COMMA);
                        csv.Append("03.企業コード").Append(COMMA);
                        csv.Append("04.GUID").Append(COMMA);
                        csv.Append("05.更新従業員コード").Append(COMMA);
                        csv.Append("06.更新アセンブリ1").Append(COMMA);
                        csv.Append("07.更新アセンブリ2").Append(COMMA);
                        csv.Append("08.論理削除区分").Append(COMMA);
                        csv.Append("09.問合せ元企業コード").Append(COMMA);
                        csv.Append("10.問合せ元拠点コード").Append(COMMA);
                        csv.Append("11.問合せ先企業コード").Append(COMMA);
                        csv.Append("12.問合せ先拠点コード").Append(COMMA);
                        csv.Append("13.問合せ番号").Append(COMMA);
                        csv.Append("14.得意先コード").Append(COMMA);
                        csv.Append("15.更新年月日").Append(COMMA);
                        csv.Append("16.更新時分秒ミリ秒").Append(COMMA);
                        csv.Append("17.回答区分").Append(COMMA);
                        csv.Append("18.確定日").Append(COMMA);
                        csv.Append("19.問合せ・発注備考").Append(COMMA);
                        csv.Append("20.添付ファイル").Append(COMMA);
                        csv.Append("21.添付ファイル名").Append(COMMA);
                        csv.Append("22.問合せ従業員コード").Append(COMMA);
                        csv.Append("23.問合せ従業員名称").Append(COMMA);
                        csv.Append("24.回答従業員コード").Append(COMMA);
                        csv.Append("25.回答従業員名称").Append(COMMA);
                        csv.Append("26.問合せ日").Append(COMMA);
                        csv.Append("27.受注ステータス").Append(COMMA);
                        csv.Append("28.売上伝票番号").Append(COMMA);
                        csv.Append("29.売上伝票合計(税込み)").Append(COMMA);
                        csv.Append("30.売上小計(税)").Append(COMMA);
                        csv.Append("31.問合せ・発注種別").Append(COMMA);
                        csv.Append("32.問発・回答種別").Append(COMMA);
                        csv.Append("33.受信日時").Append(COMMA);
                        // DEL 2010/06/17 テーブルのレイアウト変更 ---------->>>>>
                        //csv.Append("34.回答作成区分").Append(Environment.NewLine);
                        // DEL 2010/06/17 テーブルのレイアウト変更 ----------<<<<<
                        // ADD 2010/06/17 テーブルのレイアウト変更 ---------->>>>>
                        csv.Append("34.回答作成区分").Append(COMMA);
                        csv.Append("35.キャンセル区分").Append(COMMA);
                        csv.Append("36.CMT連携区分").Append(Environment.NewLine);
                        // ADD 2010/06/17 テーブルのレイアウト変更 ----------<<<<<

                        #endregion // </Userレコード>
                    }
                    else
                    {
                        #region <Webレコード>

                        csv.Append("01.作成日時").Append(COMMA);
                        csv.Append("02.更新日時").Append(COMMA);
                        csv.Append("03.論理削除区分").Append(COMMA);
                        csv.Append("04.問合せ元企業コード").Append(COMMA);
                        csv.Append("05.問合せ元拠点コード").Append(COMMA);
                        csv.Append("06.問合せ先企業コード").Append(COMMA);
                        csv.Append("07.問合せ先拠点コード").Append(COMMA);
                        csv.Append("08.問合せ番号").Append(COMMA);
                        csv.Append("09.更新年月日").Append(COMMA);
                        csv.Append("10.更新時分秒ミリ秒").Append(COMMA);
                        csv.Append("11.回答区分").Append(COMMA);
                        csv.Append("12.確定日").Append(COMMA);
                        csv.Append("13.問合せ・発注備考").Append(COMMA);
                        csv.Append("14.問合せ従業員コード").Append(COMMA);
                        csv.Append("15.問合せ従業員名称").Append(COMMA);
                        csv.Append("16.回答従業員コード").Append(COMMA);
                        csv.Append("17.回答従業員名称").Append(COMMA);
                        csv.Append("18.問合せ日").Append(COMMA);
                        csv.Append("19.問合せ・発注種別").Append(COMMA);
                        csv.Append("20.問発・回答種別").Append(COMMA);
                        csv.Append("21.受信日時").Append(COMMA);
                        // DEL 2010/06/17 テーブルのレイアウト変更 ---------->>>>>
                        //csv.Append("22.最新識別区分").Append(Environment.NewLine);
                        // DEL 2010/06/17 テーブルのレイアウト変更 ----------<<<<<
                        // ADD 2010/06/17 テーブルのレイアウト変更 ---------->>>>>
                        csv.Append("22.最新識別区分").Append(COMMA);
                        csv.Append("23.キャンセル区分").Append(COMMA);
                        csv.Append("25.CMT連携区分").Append(Environment.NewLine);
                        // ADD 2010/06/17 テーブルのレイアウト変更 ----------<<<<<

                        #endregion // </Webレコード>
                    }
                }

                #endregion // </タイトル行>

                foreach (ISCMOrderHeaderRecord scmHeaderRecord in scmHeaderRecordList)
                {
                    csv.Append(scmHeaderRecord.ToCSV()).Append(Environment.NewLine);
                }
            }
            return csv.ToString();
        }

        /// <summary>
        /// CSVに変換します。
        /// </summary>
        /// <param name="scmCarRecordList">SCM受注データ(車両情報)のレコードリスト</param>
        /// <returns>CSV</returns>
        public static string ConvertCSV(IList<ISCMOrderCarRecord> scmCarRecordList)
        {
            StringBuilder csv = new StringBuilder();
            {
                #region <タイトル行>

                if (scmCarRecordList != null && scmCarRecordList.Count > 0)
                {
                    if (scmCarRecordList[0] is UserSCMOrderCarRecord)
                    {
                        #region <Userレコード>

                        csv.Append("01.作成日時").Append(COMMA);
                        csv.Append("02.更新日時").Append(COMMA);
                        csv.Append("03.企業コード").Append(COMMA);
                        csv.Append("04.GUID").Append(COMMA);
                        csv.Append("05.更新従業員コード").Append(COMMA);
                        csv.Append("06.更新アセンブリ1").Append(COMMA);
                        csv.Append("07.更新アセンブリ2").Append(COMMA);
                        csv.Append("08.論理削除区分").Append(COMMA);
                        csv.Append("09.問合せ元企業コード").Append(COMMA);
                        csv.Append("10.問合せ元拠点コード").Append(COMMA);
                        csv.Append("11.問合せ番号").Append(COMMA);
                        csv.Append("12.陸運事務所番号").Append(COMMA);
                        csv.Append("13.陸運事務局名称").Append(COMMA);
                        csv.Append("14.車両登録番号(種別)").Append(COMMA);
                        csv.Append("15.車両登録番号(カナ)").Append(COMMA);
                        csv.Append("16.車両登録番号(プレート番号)").Append(COMMA);
                        csv.Append("17.型式指定番号").Append(COMMA);
                        csv.Append("18.類別番号").Append(COMMA);
                        csv.Append("19.メーカーコード").Append(COMMA);
                        csv.Append("20.車種コード").Append(COMMA);
                        csv.Append("21.車種サブコード").Append(COMMA);
                        csv.Append("22.車種名").Append(COMMA);
                        csv.Append("23.車検証型式").Append(COMMA);
                        csv.Append("24.型式(フル型)").Append(COMMA);
                        csv.Append("25.車台番号").Append(COMMA);
                        csv.Append("26.車台型式").Append(COMMA);
                        csv.Append("27.シャシーNo").Append(COMMA);
                        csv.Append("28.車両固有番号").Append(COMMA);
                        csv.Append("29.生産年式(NUMタイプ)").Append(COMMA);
                        csv.Append("30.コメント").Append(COMMA);
                        csv.Append("31.リペアカラーコード").Append(COMMA);
                        csv.Append("32.カラー名称1").Append(COMMA);
                        csv.Append("33.トリムコード").Append(COMMA);
                        csv.Append("34.トリム名称").Append(COMMA);
                        csv.Append("35.車両走行距離").Append(COMMA);
                        csv.Append("36.装備オブジェクト").Append(COMMA);
                        csv.Append("37.受注ステータス").Append(COMMA);
                        csv.Append("38.売上伝票番号").Append(Environment.NewLine);

                        #endregion // </Userレコード>
                    }
                    else
                    {
                        #region <Webレコード>

                        csv.Append("01.作成日時").Append(COMMA);
                        csv.Append("02.更新日時").Append(COMMA);
                        csv.Append("03.論理削除区分").Append(COMMA);
                        csv.Append("04.問合せ元企業コード").Append(COMMA);
                        csv.Append("05.問合せ元拠点コード").Append(COMMA);
                        csv.Append("06.問合せ番号").Append(COMMA);
                        csv.Append("07.陸運事務所番号").Append(COMMA);
                        csv.Append("08.陸運事務局名称").Append(COMMA);
                        csv.Append("09.車両登録番号(種別)").Append(COMMA);
                        csv.Append("10.車両登録番号(カナ)").Append(COMMA);
                        csv.Append("11.車両登録番号(プレート番号)").Append(COMMA);
                        csv.Append("12.型式指定番号").Append(COMMA);
                        csv.Append("13.類別番号").Append(COMMA);
                        csv.Append("14.メーカーコード").Append(COMMA);
                        csv.Append("15.車種コード").Append(COMMA);
                        csv.Append("16.車種サブコード").Append(COMMA);
                        csv.Append("17.車種名").Append(COMMA);
                        csv.Append("18.車検証型式").Append(COMMA);
                        csv.Append("19.型式(フル型)").Append(COMMA);
                        csv.Append("20.車台番号").Append(COMMA);
                        csv.Append("21.車台型式").Append(COMMA);
                        csv.Append("22.シャシーNo").Append(COMMA);
                        csv.Append("23.車両固有番号").Append(COMMA);
                        csv.Append("24.生産年式(NUMタイプ)").Append(COMMA);
                        csv.Append("25.コメント").Append(COMMA);
                        csv.Append("26.リペアカラーコード").Append(COMMA);
                        csv.Append("27.カラー名称1").Append(COMMA);
                        csv.Append("28.トリムコード").Append(COMMA);
                        csv.Append("29.トリム名称").Append(COMMA);
                        csv.Append("30.車両走行距離").Append(COMMA);
                        csv.Append("31.装備オブジェクト").Append(Environment.NewLine);

                        #endregion // </Webレコード>
                    }
                }

                #endregion // </タイトル行>

                foreach (ISCMOrderCarRecord scmCarRecord in scmCarRecordList)
                {
                    csv.Append(scmCarRecord.ToCSV()).Append(Environment.NewLine);
                }
            }
            return csv.ToString();
        }

        /// <summary>
        /// CSVに変換します。
        /// </summary>
        /// <param name="scmDetailRecordList">SCM受注明細データ(問合せ・発注)のレコードリスト</param>
        /// <returns>CSV</returns>
        /// <remarks>
        /// <br>Update Note      :   2018/04/16 田建委</br>
        /// <br>管理番号         :   11470007-00</br>
        /// <br>                 :   SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加</br>
        /// </remarks>
        public static string ConvertCSV(IList<ISCMOrderDetailRecord> scmDetailRecordList)
        {
            StringBuilder csv = new StringBuilder();
            {
                #region <タイトル行>

                if (scmDetailRecordList != null && scmDetailRecordList.Count > 0)
                {
                    if (scmDetailRecordList[0] is UserSCMOrderDetailRecord)
                    {
                        #region <Userレコード>

                        csv.Append("01.作成日時").Append(COMMA);
                        csv.Append("02.更新日時").Append(COMMA);
                        csv.Append("03.企業コード").Append(COMMA);
                        csv.Append("04.GUID").Append(COMMA);
                        csv.Append("05.更新従業員コード").Append(COMMA);
                        csv.Append("06.更新アセンブリ1").Append(COMMA);
                        csv.Append("07.更新アセンブリ2").Append(COMMA);
                        csv.Append("08.論理削除区分").Append(COMMA);
                        csv.Append("09.問合せ元企業コード").Append(COMMA);
                        csv.Append("10.問合せ元拠点コード").Append(COMMA);
                        csv.Append("11.問合せ先企業コード").Append(COMMA);
                        csv.Append("12.問合せ先拠点コード").Append(COMMA);
                        csv.Append("13.問合せ番号").Append(COMMA);
                        csv.Append("14.更新年月日").Append(COMMA);
                        csv.Append("15.更新時分秒ミリ秒").Append(COMMA);
                        csv.Append("16.問合せ行番号").Append(COMMA);
                        csv.Append("17.問合せ行番号枝番").Append(COMMA);
                        csv.Append("18.問合せ元明細識別GUID").Append(COMMA);
                        csv.Append("19.問合せ先名先識別GUID").Append(COMMA);
                        csv.Append("20.商品種別").Append(COMMA);
                        csv.Append("21.リサイクル部品種別").Append(COMMA);
                        csv.Append("22.リサイクル部品名称").Append(COMMA);
                        csv.Append("23.納品区分").Append(COMMA);
                        csv.Append("24.取扱区分").Append(COMMA);
                        csv.Append("25.商品形態").Append(COMMA);
                        csv.Append("26.納品確認区分").Append(COMMA);
                        csv.Append("27.納品完了予定日").Append(COMMA);
                        csv.Append("28.回答納期").Append(COMMA);
                        csv.Append("29.BL商品コード").Append(COMMA);
                        csv.Append("30.BL商品コード枝番").Append(COMMA);
                        csv.Append("31.問発商品名").Append(COMMA);
                        csv.Append("32.回答商品名").Append(COMMA);
                        csv.Append("33.発注数").Append(COMMA);
                        csv.Append("34.納品数").Append(COMMA);
                        csv.Append("35.商品番号").Append(COMMA);
                        csv.Append("36.商品メーカーコード").Append(COMMA);
                        csv.Append("37.商品メーカー名称").Append(COMMA);
                        csv.Append("38.純正商品メーカーコード").Append(COMMA);
                        csv.Append("39.問発純正商品番号").Append(COMMA);
                        csv.Append("40.回答純正商品番号").Append(COMMA);
                        csv.Append("41.定価").Append(COMMA);
                        csv.Append("42.単価").Append(COMMA);
                        csv.Append("43.商品補足情報").Append(COMMA);
                        csv.Append("44.粗利額").Append(COMMA);
                        csv.Append("45.粗利率").Append(COMMA);
                        csv.Append("46.回答期限").Append(COMMA);
                        csv.Append("47.備考(明細)").Append(COMMA);
                        csv.Append("48.添付ファイル(明細)").Append(COMMA);
                        csv.Append("49.添付ファイル名(明細)").Append(COMMA);
                        csv.Append("50.棚番").Append(COMMA);
                        csv.Append("51.追加区分").Append(COMMA);
                        csv.Append("52.訂正区分").Append(COMMA);
                        csv.Append("53.問合せ・発注種別").Append(COMMA);
                        // DEL 2010/06/17 テーブルのレイアウト変更 ---------->>>>>
                        //csv.Append("54.表示順位").Append(Environment.NewLine);
                        // DEL 2010/06/17 テーブルのレイアウト変更 ----------<<<<<
                        // ADD 2010/06/17 テーブルのレイアウト変更 ---------->>>>>
                        csv.Append("54.表示順位").Append(COMMA);
                        csv.Append("55.キャンセル状態区分").Append(COMMA);
                        csv.Append("56.受注ステータス").Append(COMMA);
                        csv.Append("57.売上伝票番号").Append(COMMA);
                        // UPD 2018/04/16 田建委 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        //csv.Append("58.売上行番号").Append(Environment.NewLine);
                        csv.Append("58.売上行番号").Append(COMMA);
                        csv.Append("59.問発BL統一部品コード(スリーコード版)").Append(COMMA);
                        csv.Append("60.問発BL統一部品サブコード").Append(COMMA);
                        csv.Append("61.回答BL統一部品コード(スリーコード版)").Append(COMMA);
                        csv.Append("62.回答BL統一部品サブコード").Append(COMMA);
                        csv.Append("63.回答BL商品コード").Append(COMMA);
                        csv.Append("64.回答BL商品コード枝番").Append(Environment.NewLine);
                        // UPD 2018/04/16 田建委 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        // ADD 2010/06/17 テーブルのレイアウト変更 ----------<<<<<

                        #endregion // </Userレコード>
                    }
                    else
                    {
                        #region <Webレコード>

                        csv.Append("01.作成日時").Append(COMMA);
                        csv.Append("02.更新日時").Append(COMMA);
                        csv.Append("03.論理削除区分").Append(COMMA);
                        csv.Append("04.問合せ元企業コード").Append(COMMA);
                        csv.Append("05.問合せ元拠点コード").Append(COMMA);
                        csv.Append("06.問合せ先企業コード").Append(COMMA);
                        csv.Append("07.問合せ先拠点コード").Append(COMMA);
                        csv.Append("08.問合せ番号").Append(COMMA);
                        csv.Append("09.更新年月日").Append(COMMA);
                        csv.Append("10.更新時分秒ミリ秒").Append(COMMA);
                        csv.Append("11.問合せ行番号").Append(COMMA);
                        csv.Append("12.問合せ行番号枝番").Append(COMMA);
                        csv.Append("13.問合せ元明細識別GUID").Append(COMMA);
                        csv.Append("14.問合せ先名先識別GUID").Append(COMMA);
                        csv.Append("15.商品種別").Append(COMMA);
                        csv.Append("16.リサイクル部品種別").Append(COMMA);
                        csv.Append("17.リサイクル部品名称").Append(COMMA);
                        csv.Append("18.納品区分").Append(COMMA);
                        csv.Append("19.取扱区分").Append(COMMA);
                        csv.Append("20.商品形態").Append(COMMA);
                        csv.Append("21.納品確認区分").Append(COMMA);
                        csv.Append("22.納品完了予定日").Append(COMMA);
                        csv.Append("23.回答納期").Append(COMMA);
                        csv.Append("24.BL商品コード").Append(COMMA);
                        csv.Append("25.BL商品コード枝番").Append(COMMA);
                        csv.Append("26.問発商品名").Append(COMMA);
                        csv.Append("27.回答商品名").Append(COMMA);
                        csv.Append("28.発注数").Append(COMMA);
                        csv.Append("29.納品数").Append(COMMA);
                        csv.Append("30.商品番号").Append(COMMA);
                        csv.Append("31.商品メーカーコード").Append(COMMA);
                        csv.Append("32.商品メーカー名称").Append(COMMA);
                        csv.Append("33.純正商品メーカーコード").Append(COMMA);
                        csv.Append("34.問発純正商品番号").Append(COMMA);
                        csv.Append("35.回答純正商品番号").Append(COMMA);
                        csv.Append("36.定価").Append(COMMA);
                        csv.Append("37.単価").Append(COMMA);
                        csv.Append("38.商品補足情報").Append(COMMA);
                        csv.Append("39.粗利額").Append(COMMA);
                        csv.Append("40.粗利率").Append(COMMA);
                        csv.Append("41.回答期限").Append(COMMA);
                        csv.Append("42.備考(明細)").Append(COMMA);
                        csv.Append("43.棚番").Append(COMMA);
                        csv.Append("44.追加区分").Append(COMMA);
                        csv.Append("45.訂正区分").Append(COMMA);
                        csv.Append("46.問合せ・発注種別").Append(COMMA);
                        csv.Append("47.表示順位").Append(COMMA);
                        // DEL 2010/06/17 テーブルのレイアウト変更 ---------->>>>>
                        //csv.Append("48.最新識別区分").Append(Environment.NewLine);
                        // DEL 2010/06/17 テーブルのレイアウト変更 ----------<<<<<
                        // ADD 2010/06/17 テーブルのレイアウト変更 ---------->>>>>
                        csv.Append("48.最新識別区分").Append(COMMA);
                        csv.Append("49.キャンセル状態区分").Append(COMMA);
                        csv.Append("50.PM受注ステータス").Append(COMMA);
                        csv.Append("51.PM売上伝票番号").Append(COMMA);
                        // UPD 2018/04/16 田建委 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        //csv.Append("52.PM売上行番号").Append(Environment.NewLine);
                        csv.Append("52.PM売上行番号").Append(COMMA);
                        csv.Append("53.問発BL統一部品コード(スリーコード版)").Append(COMMA);
                        csv.Append("54.問発BL統一部品サブコード").Append(COMMA);
                        csv.Append("55.回答BL統一部品コード(スリーコード版)").Append(COMMA);
                        csv.Append("56.回答BL統一部品サブコード").Append(COMMA);
                        csv.Append("57.回答BL商品コード").Append(COMMA);
                        csv.Append("58.回答BL商品コード枝番").Append(Environment.NewLine);
                        // UPD 2018/04/16 田建委 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        // ADD 2010/06/17 テーブルのレイアウト変更 ----------<<<<<

                        #endregion // </Webレコード>
                    }
                }

                #endregion // </タイトル行>

                foreach (ISCMOrderDetailRecord scmDetailRecord in scmDetailRecordList)
                {
                    csv.Append(scmDetailRecord.ToCSV()).Append(Environment.NewLine);
                }
            }
            return csv.ToString();
        }

        /// <summary>
        /// CSVに変換します。
        /// </summary>
        /// <param name="scmAnswerRecordList">SCM受注明細データ(回答)のレコードリスト</param>
        /// <returns>CSV</returns>
        /// <remarks>
        /// <br>Update Note      :   2018/04/16 田建委</br>
        /// <br>管理番号         :   11470007-00</br>
        /// <br>                 :   SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加</br>
        /// </remarks>
        public static string ConvertCSV(IList<ISCMOrderAnswerRecord> scmAnswerRecordList)
        {
            StringBuilder csv = new StringBuilder();
            {
                #region <タイトル行>

                if (scmAnswerRecordList != null && scmAnswerRecordList.Count > 0)
                {
                    if (scmAnswerRecordList[0] is ISCMOrderAnswerRecord)
                    {
                        #region <Userレコード>

                        csv.Append("01.作成日時").Append(COMMA);
                        csv.Append("02.更新日時").Append(COMMA);
                        csv.Append("03.企業コード").Append(COMMA);
                        csv.Append("04.GUID").Append(COMMA);
                        csv.Append("05.更新従業員コード").Append(COMMA);
                        csv.Append("06.更新アセンブリ1").Append(COMMA);
                        csv.Append("07.更新アセンブリ2").Append(COMMA);
                        csv.Append("08.論理削除区分").Append(COMMA);
                        csv.Append("09.問合せ元企業コード").Append(COMMA);
                        csv.Append("10.問合せ元拠点コード").Append(COMMA);
                        csv.Append("11.問合せ先企業コード").Append(COMMA);
                        csv.Append("12.問合せ先拠点コード").Append(COMMA);
                        csv.Append("13.問合せ番号").Append(COMMA);
                        csv.Append("14.更新年月日").Append(COMMA);
                        csv.Append("15.更新時分秒ミリ秒").Append(COMMA);
                        csv.Append("16.問合せ行番号").Append(COMMA);
                        csv.Append("17.問合せ行番号枝番").Append(COMMA);
                        csv.Append("18.問合せ元明細識別GUID").Append(COMMA);
                        csv.Append("19.問合せ先名先識別GUID").Append(COMMA);
                        csv.Append("20.商品種別").Append(COMMA);
                        csv.Append("21.リサイクル部品種別").Append(COMMA);
                        csv.Append("22.リサイクル部品名称").Append(COMMA);
                        csv.Append("23.納品区分").Append(COMMA);
                        csv.Append("24.取扱区分").Append(COMMA);
                        csv.Append("25.商品形態").Append(COMMA);
                        csv.Append("26.納品確認区分").Append(COMMA);
                        csv.Append("27.納品完了予定日").Append(COMMA);
                        csv.Append("28.回答納期").Append(COMMA);
                        csv.Append("29.BL商品コード").Append(COMMA);
                        csv.Append("30.BL商品コード枝番").Append(COMMA);
                        csv.Append("31.問発商品名").Append(COMMA);
                        csv.Append("32.回答商品名").Append(COMMA);
                        csv.Append("33.発注数").Append(COMMA);
                        csv.Append("34.納品数").Append(COMMA);
                        csv.Append("35.商品番号").Append(COMMA);
                        csv.Append("36.商品メーカーコード").Append(COMMA);
                        csv.Append("37.商品メーカー名称").Append(COMMA);
                        csv.Append("38.純正商品メーカーコード").Append(COMMA);
                        csv.Append("39.問発純正商品番号").Append(COMMA);
                        csv.Append("40.回答純正商品番号").Append(COMMA);
                        csv.Append("41.定価").Append(COMMA);
                        csv.Append("42.単価").Append(COMMA);
                        csv.Append("43.商品補足情報").Append(COMMA);
                        csv.Append("44.粗利額").Append(COMMA);
                        csv.Append("45.粗利率").Append(COMMA);
                        csv.Append("46.回答期限").Append(COMMA);
                        csv.Append("47.備考(明細)").Append(COMMA);
                        csv.Append("48.添付ファイル(明細)").Append(COMMA);
                        csv.Append("49.添付ファイル名(明細)").Append(COMMA);
                        csv.Append("50.棚番").Append(COMMA);
                        csv.Append("51.追加区分").Append(COMMA);
                        csv.Append("52.訂正区分").Append(COMMA);
                        csv.Append("53.受注ステータス").Append(COMMA);
                        csv.Append("54.売上伝票番号").Append(COMMA);
                        csv.Append("55.売上伝票行番号").Append(COMMA);
                        csv.Append("56.キャンペーンコード").Append(COMMA);
                        csv.Append("57.在庫区分").Append(COMMA);
                        csv.Append("58.問合せ・発注種別").Append(COMMA);
                        csv.Append("59.表示順位").Append(COMMA);
                        // DEL 2010/06/17 テーブルのレイアウト変更 ---------->>>>>
                        //csv.Append("60.商品管理番号").Append(Environment.NewLine);
                        // DEL 2010/06/17 テーブルのレイアウト変更 ----------<<<<<
                        // ADD 2010/06/17 テーブルのレイアウト変更 ---------->>>>>
                        csv.Append("60.商品管理番号").Append(COMMA);
                        // UPD 2018/04/16 田建委 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        //csv.Append("61.キャンセル状態区分").Append(Environment.NewLine);
                        csv.Append("61.キャンセル状態区分").Append(COMMA);
                        csv.Append("62.PM売上行番号").Append(COMMA);
                        csv.Append("63.問発BL統一部品コード(スリーコード版)").Append(COMMA);
                        csv.Append("64.問発BL統一部品サブコード").Append(COMMA);
                        csv.Append("65.回答BL統一部品コード(スリーコード版)").Append(COMMA);
                        csv.Append("66.回答BL統一部品サブコード").Append(COMMA);
                        csv.Append("67.回答BL商品コード").Append(COMMA);
                        csv.Append("68.回答BL商品コード枝番").Append(Environment.NewLine);
                        // UPD 2018/04/16 田建委 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        // ADD 2010/06/17 テーブルのレイアウト変更 ----------<<<<<
                        #endregion // </Userレコード>
                    }
                    else
                    {
                        #region <Webレコード>

                        csv.Append("01.作成日時").Append(COMMA);
                        csv.Append("02.更新日時").Append(COMMA);
                        csv.Append("03.論理削除区分").Append(COMMA);
                        csv.Append("04.問合せ元企業コード").Append(COMMA);
                        csv.Append("05.問合せ元拠点コード").Append(COMMA);
                        csv.Append("06.問合せ先企業コード").Append(COMMA);
                        csv.Append("07.問合せ先拠点コード").Append(COMMA);
                        csv.Append("08.問合せ番号").Append(COMMA);
                        csv.Append("09.更新年月日").Append(COMMA);
                        csv.Append("10.更新時分秒ミリ秒").Append(COMMA);
                        csv.Append("11.問合せ行番号").Append(COMMA);
                        csv.Append("12.問合せ行番号枝番").Append(COMMA);
                        csv.Append("13.問合せ元明細識別GUID").Append(COMMA);
                        csv.Append("14.問合せ先名先識別GUID").Append(COMMA);
                        csv.Append("15.商品種別").Append(COMMA);
                        csv.Append("16.リサイクル部品種別").Append(COMMA);
                        csv.Append("17.リサイクル部品名称").Append(COMMA);
                        csv.Append("18.納品区分").Append(COMMA);
                        csv.Append("19.取扱区分").Append(COMMA);
                        csv.Append("20.商品形態").Append(COMMA);
                        csv.Append("21.納品確認区分").Append(COMMA);
                        csv.Append("22.納品完了予定日").Append(COMMA);
                        csv.Append("23.回答納期").Append(COMMA);
                        csv.Append("24.BL商品コード").Append(COMMA);
                        csv.Append("25.BL商品コード枝番").Append(COMMA);
                        csv.Append("26.問発商品名").Append(COMMA);
                        csv.Append("27.回答商品名").Append(COMMA);
                        csv.Append("28.発注数").Append(COMMA);
                        csv.Append("29.納品数").Append(COMMA);
                        csv.Append("30.商品番号").Append(COMMA);
                        csv.Append("31.商品メーカーコード").Append(COMMA);
                        csv.Append("32.商品メーカー名称").Append(COMMA);
                        csv.Append("33.純正商品メーカーコード").Append(COMMA);
                        csv.Append("34.問発純正商品番号").Append(COMMA);
                        csv.Append("35.回答純正商品番号").Append(COMMA);
                        csv.Append("36.定価").Append(COMMA);
                        csv.Append("37.単価").Append(COMMA);
                        csv.Append("38.商品補足情報").Append(COMMA);
                        csv.Append("39.粗利額").Append(COMMA);
                        csv.Append("40.粗利率").Append(COMMA);
                        csv.Append("41.回答期限").Append(COMMA);
                        csv.Append("42.備考(明細)").Append(COMMA);
                        csv.Append("43.棚番").Append(COMMA);
                        csv.Append("44.追加区分").Append(COMMA);
                        csv.Append("45.訂正区分").Append(COMMA);
                        csv.Append("46.問合せ・発注種別").Append(COMMA);
                        csv.Append("47.表示順位").Append(COMMA);
                        // DEL 2010/06/17 テーブルのレイアウト変更 ---------->>>>>
                        //csv.Append("48.最新識別区分").Append(Environment.NewLine);
                        // DEL 2010/06/17 テーブルのレイアウト変更 ----------<<<<<
                        // ADD 2010/06/17 テーブルのレイアウト変更 ---------->>>>>
                        csv.Append("48.最新識別区分").Append(COMMA);
                        csv.Append("49.キャンセル状態区分").Append(COMMA);
                        csv.Append("50.PM受注ステータス").Append(COMMA);
                        csv.Append("51.PM売上伝票番号").Append(COMMA);
                        // UPD 2018/04/16 田建委 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        //csv.Append("52.PM売上行番号").Append(Environment.NewLine);
                        csv.Append("52.PM売上行番号").Append(COMMA);
                        csv.Append("53.問発BL統一部品コード(スリーコード版)").Append(COMMA);
                        csv.Append("54.問発BL統一部品サブコード").Append(COMMA);
                        csv.Append("55.回答BL統一部品コード(スリーコード版)").Append(COMMA);
                        csv.Append("56.回答BL統一部品サブコード").Append(COMMA);
                        csv.Append("57.回答BL商品コード").Append(COMMA);
                        csv.Append("58.回答BL商品コード枝番").Append(Environment.NewLine);
                        // UPD 2018/04/16 田建委 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        // ADD 2010/06/17 テーブルのレイアウト変更 ----------<<<<<

                        #endregion // </Webレコード>
                    }
                }

                #endregion // </タイトル行>

                foreach (ISCMOrderAnswerRecord scmAnswerRecord in scmAnswerRecordList)
                {
                    csv.Append(scmAnswerRecord.ToCSV()).Append(Environment.NewLine);
                }
            }
            return csv.ToString();
        }

        #endregion // </CSV変換>
    }
}

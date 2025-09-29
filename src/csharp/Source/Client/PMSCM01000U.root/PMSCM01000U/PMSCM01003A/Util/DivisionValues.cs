using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// 区分値保持クラス
    /// </summary>
    public static class DivisionValues
    {
        #region 受注データ
        /// <summary>
        /// 回答区分
        /// </summary>
        public enum AnswerDivCd : int
        {
            /// <summary>未回答</summary>
            NoAction = 0,
            /// <summary>回答中(Web側のみのステータス)</summary>
            OnAnswer = 1,
            //>>>2011/05/25
            /// <summary>受付済み</summary>
            AccComplete = 2,
            //<<<2011/05/25
            /// <summary>一部回答</summary>
            AnsParts = 10,
            /// <summary>回答完了</summary>
            AnsComplete = 20,
            /// <summary>キャンセル</summary>
            Cancel = 99
        }

        /// <summary>
        /// 受注ステータス
        /// </summary>
        public enum AcptAnOdrStatus : int
        {
            /// <summary>未設定</summary>
            NoSet = 0,
            /// <summary>見積</summary>
            Estimate = 10,
            /// <summary>受注</summary>
            Accept = 20,
            /// <summary>売上</summary>
            Sales = 30
        }

        /// <summary>
        /// 問発・回答種別
        /// </summary>
        public enum InqOrdAnsDivCd : int
        {
            /// <summary>問合せ発注</summary>
            Inquiry = 1,
            /// <summary>回答</summary>
            Answer = 2
        }

        /// <summary>
        /// 回答作成区分
        /// </summary>
        public enum AnswerCreateDiv : int
        {
            /// <summary>自動</summary>
            Auto = 0,
            /// <summary>手動(Web)</summary>
            ManualWeb = 1,
            /// <summary>手動(その他)</summary>
            ManualOther = 2
        }
        #endregion

        #region 受発注データ(Web)
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

        #endregion
    }
}

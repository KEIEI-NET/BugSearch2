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
// 作 成 日  2009/07/03  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// ログのヘルパクラス
    /// </summary>
    public static class MsgHelper
    {
        private const string RUN        = "≪起動≫";
        private const string START      = "【開始】";
        private const string END        = "【完了】";
        private const string ERROR      = "【異常】";
        private const string EXCEPTION  = "【例外】";
        private const string INFO       = "\t[情報]";
        private const string ALERT      = "\t<警告>";
        private const string DEBUG      = "\t(Debug)";
        private const string AT         = "：";

        #region <メッセージ>

        /// <summary>
        /// 起動メッセージを取得します。
        /// </summary>
        /// <param name="msg">メッセージ</param>
        /// <returns>起動メッセージ</returns>
        public static string GetRunMsg(string msg)
        {
            return RUN + msg;
        }

        /// <summary>
        /// 開始メッセージを取得します。
        /// </summary>
        /// <param name="msg">メッセージ</param>
        /// <returns>開始メッセージ</returns>
        public static string GetStartMsg(string msg)
        {
            return START + msg;
        }

        /// <summary>
        /// 完了メッセージを取得します。
        /// </summary>
        /// <param name="msg">メッセージ</param>
        /// <param name="status"></param>
        /// <returns>完了メッセージ</returns>
        public static string GetEndMsg(
            string msg,
            int status
        )
        {
            return END + msg + AT + status.ToString();
        }

        /// <summary>
        /// 異常メッセージを取得します。
        /// </summary>
        /// <param name="msg">メッセージ</param>
        /// <param name="status">処理ステータス</param>
        /// <returns>異常メッセージ + "：" + 処理ステータス</returns>
        public static string GetErrorMsg(
            string msg,
            int status
        )
        {
            return ERROR + msg + AT + status.ToString();
        }

        /// <summary>
        /// 例外メッセージを取得します。
        /// </summary>
        /// <param name="msg">メッセージ</param>
        /// <param name="ex">例外</param>
        /// <returns>例外メッセージ + <c>ex.Message</c></returns>
        public static string GetExceptionMsg(
            string msg,
            Exception ex
        )
        {
            if (ex == null) return EXCEPTION + msg;
            return EXCEPTION + msg + Environment.NewLine + ex.Message;
        }

        /// <summary>
        /// 情報メッセージを取得します。
        /// </summary>
        /// <param name="msg">メッセージ</param>
        /// <returns>情報メッセージ</returns>
        public static string GetInfoMsg(string msg)
        {
            return INFO + msg;
        }

        /// <summary>
        /// 警告メッセージを取得します。
        /// </summary>
        /// <param name="msg">メッセージ</param>
        /// <returns>警告メッセージ</returns>
        public static string GetAlertMsg(string msg)
        {
            return ALERT + msg;
        }

        /// <summary>
        /// デバッグメッセージを取得します。
        /// </summary>
        /// <param name="msg">メッセージ</param>
        /// <returns>デバッグメッセージ</returns>
        public static string GetDebugMsg(string msg)
        {
            return DEBUG + msg;
        }

        #endregion // </メッセージ>

        /// <summary>
        /// 例外ログを出力します。
        /// </summary>
        /// <param name="className">クラス名称</param>
        /// <param name="methodName">メソッド名称</param>
        /// <param name="msg">メッセージ</param>
        /// <param name="ex">例外</param>
        public static void WriteExceptionLog(
            string className,
            string methodName,
            string msg,
            Exception ex
        )
        {
            SimpleLogger.Write(className, methodName, GetExceptionMsg(msg, ex));

            string info = EXCEPTION + msg;
            if (ex != null) info = EXCEPTION + msg + Environment.NewLine + ex.ToString();
            SimpleLogger.WriteDebugLog(className, methodName, info);
        }

        /// <summary>
        /// データメッセージを取得します。
        /// </summary>
        /// <param name="title">タイトル</param>
        /// <param name="scmHeaderRecordList">SCM受注データのレコードリスト</param>
        /// <param name="scmCarRecordList">SCM受注データ(車両情報)のレコードリスト</param>
        /// <param name="scmDetailRecordList">SCM受注明細データ(問合せ・発注)のレコードリスト</param>
        /// <returns>レコードをCSVに変換</returns>
        public static string GetDataMsg(
            string title,
            IList<ISCMOrderHeaderRecord> scmHeaderRecordList,
            IList<ISCMOrderCarRecord> scmCarRecordList,
            IList<ISCMOrderDetailRecord> scmDetailRecordList
        )
        {
            return GetDataMsg(title, scmHeaderRecordList, scmCarRecordList, scmDetailRecordList, null);
        }

        /// <summary>
        /// データメッセージを取得します。
        /// </summary>
        /// <param name="title">タイトル</param>
        /// <param name="scmHeaderRecordList">SCM受注データのレコードリスト</param>
        /// <param name="scmCarRecordList">SCM受注データ(車両情報)のレコードリスト</param>
        /// <param name="scmDetailRecordList">SCM受注明細データ(問合せ・発注)のレコードリスト</param>
        /// <param name="scmAnswerRecordList">SCM受注明細データ(回答)のレコードリスト</param>
        /// <returns>レコードをCSVに変換</returns>
        public static string GetDataMsg(
            string title,
            IList<ISCMOrderHeaderRecord> scmHeaderRecordList,
            IList<ISCMOrderCarRecord> scmCarRecordList,
            IList<ISCMOrderDetailRecord> scmDetailRecordList,
            IList<ISCMOrderAnswerRecord> scmAnswerRecordList
        )
        {
            StringBuilder msg = new StringBuilder();
            {
                msg.Append(DEBUG).Append(title).Append(Environment.NewLine);
                msg.Append(Environment.NewLine);
                if (scmHeaderRecordList != null)
                {
                    msg.Append("[SCM受注データ]").Append(Environment.NewLine);
                    msg.Append(SCMEntityUtil.ConvertCSV(scmHeaderRecordList));
                }
                if (scmCarRecordList != null)
                {
                    msg.Append("[SCM受注データ(車両情報)]").Append(Environment.NewLine);
                    msg.Append(SCMEntityUtil.ConvertCSV(scmCarRecordList));
                }
                if (scmDetailRecordList != null)
                {
                    msg.Append("[SCM受注明細データ(問合せ・発注)]").Append(Environment.NewLine);
                    msg.Append(SCMEntityUtil.ConvertCSV(scmDetailRecordList));
                }
                if (scmAnswerRecordList != null)
                {
                    msg.Append("[SCM受注明細データ(回答)]").Append(Environment.NewLine);
                    msg.Append(SCMEntityUtil.ConvertCSV(scmAnswerRecordList));
                }
            }
            return msg.ToString();
        }
    }
}

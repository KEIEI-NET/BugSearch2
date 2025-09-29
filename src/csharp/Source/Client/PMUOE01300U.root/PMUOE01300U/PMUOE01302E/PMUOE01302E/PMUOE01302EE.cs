//****************************************************************************//
// システム         : 卸商仕入受信処理
// プログラム名称   : 卸商仕入受信処理Model
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/11/17  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024 佐々木 健
// 作 成 日  2009/10/09  修正内容 : 受信の該当データ無し対応
//----------------------------------------------------------------------------//

using System;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 結果ユーティリティ
    /// </summary>
    public static class Result
    {
        // UNDONE:共通定数を参照
        /// <summary>
        /// リモートの処理結果列挙体
        /// </summary>
        public enum RemoteStatus : int
        {
            /// <summary>正常</summary>
            Normal = 0,
            /// <summary>件数0</summary>
            NotFound = 4,

            /// <summary>企業ロック</summary>
            EnterpriseLock = 850,
            /// <summary>拠点ロック</summary>
            SectionLock = 851,
            /// <summary>倉庫ロック</summary>
            WarehouseLock = 852,

            /// <summary>異常</summary>
            Error = 1000
        }

        /// <summary>
        /// 結果コード
        /// </summary>
        public enum Code : int
        {
            /// <summary>正常</summary>
            Normal,
            /// <summary>異常</summary>
            Error,
            /// <summary>中止</summary>
            Abort,
            /// <summary>重複した仕入データ</summary>
            ExistSlip
        }

        // 2009/10/09 Add >>>
        /// <summary>
        /// 処理ID
        /// </summary>
        public enum ProcessID : int
        {
            /// <summary>処理無し(初期値)</summary>
            None,
            /// <summary>仕入受信</summary>
            ReceiveStock,
            /// <summary>仕入回答データ作成</summary>
            MakeStockAnswerData,
            /// <summary>計上データ作成</summary>
            MakeSumUpData,
            /// <summary>在庫調整作成</summary>
            MakeStockAdjust,
            /// <summary>回答表示</summary>
            ShowAnswer
        }
        // 2009/10/09 Add <<<

        /// <summary>
        /// エラーメッセージに変換します。
        /// </summary>
        /// <param name="status">結果コード</param>
        /// <param name="processID">処理ID</param>
        /// <returns>該当するメッセージ</returns>
        // 2009/10/09 Add >>>
        //public static string ToErrorMessage(int status)
        public static string ToErrorMessage(int status, Result.ProcessID processID)
        // 2009/10/09 Add <<<
        {
            const string PLEASE_RETRY = "再試行するか、しばらく待ってから再度処理を行ってください。";

            StringBuilder msg = new StringBuilder("処理に失敗しました。");
            switch (status)
            {
                case (int)Result.Code.ExistSlip:    // 仕入データの重複
                    msg.Append(Environment.NewLine).Append("重複した仕入データが存在します。");
                    break;
                case (int)Result.RemoteStatus.EnterpriseLock:   // 企業ロック
                {
                    msg.Append("シェアチェックエラー(企業ロック)です。").Append(Environment.NewLine);
                    msg.Append("月次処理か、その他の業務を行っているため本処理は行えません。").Append(Environment.NewLine);
                    msg.Append(PLEASE_RETRY);
                    break;
                }
                case (int)Result.RemoteStatus.SectionLock:      // 拠点ロック
                {
                    msg.Append("シェアチェックエラー(拠点ロック)です。").Append(Environment.NewLine);
                    msg.Append("締処理か、処理が込み合っているためタイムアウトしました。").Append(Environment.NewLine);
                    msg.Append(PLEASE_RETRY);
                    break;
                }
                case (int)Result.RemoteStatus.WarehouseLock:    // 倉庫ロック
                {
                    msg.Append("シェアチェックエラー(倉庫ロック)です。").Append(Environment.NewLine);
                    msg.Append("棚卸処理か、その他の在庫業務を行っているためタイムアウトしました。").Append(Environment.NewLine);
                    msg.Append(PLEASE_RETRY);
                    break;
                }
                // 2009/10/09 Add >>>
                case (int)Result.RemoteStatus.NotFound:         // 該当データ無し
                {
                    // 受信処理の場合のメッセージ
                    if (processID == ProcessID.ReceiveStock)
                    {
                        msg = new StringBuilder("受信対象のデータがありませんでした。");
                    }
                    break;
                }
                // 2009/10/09 Add <<<
            }
            return msg.ToString();
        }
    }
}

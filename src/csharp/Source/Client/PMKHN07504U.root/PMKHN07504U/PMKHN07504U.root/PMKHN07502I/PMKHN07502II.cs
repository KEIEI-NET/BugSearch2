//using System;
//using System.Collections.Generic;
//using System.Text;
using Broadleaf.Application.UIData;
 
namespace Broadleaf.Application.Common
{

    /// <summary>
    /// メール送信履歴作成ライブラリ操作インタフェース
    /// </summary>
    /// <remarks>
    /// メールの送信履歴作成に関する操作を定義します
    /// </remarks>
    public interface IMailSendingHistoryMaker
    {

        /// <summary>
        /// メール送信履歴作成
        /// </summary>
        /// <param name="mailSourceData">履歴作成対象メールデータ</param>
        /// <returns>履歴作成結果</returns>
        int InitializeSendingHistory(ref MailSourceData mailSourceData);

        /// <summary>
        /// メール送信履歴作成
        /// </summary>
        /// <param name="mailSourceData">履歴作成対象メールデータ</param>
        /// <returns>履歴作成結果</returns>
        int MakeSendingHistory(ref MailSourceData mailSourceData);

        /// <summary>
        /// メール送信履歴作成
        /// </summary>
        /// <param name="targetIndex">操作対象データインデックス</param>
        /// <param name="mailSourceData">履歴作成対象メールデータ</param>
        /// <returns>履歴作成結果</returns>
        int MakeSendingHistory(int targetIndex, ref MailSourceData mailSourceData);


        /// <summary>
        /// メール送信履歴削除
        /// </summary>
        /// <param name="mailSourceData">履歴削除対象メールデータ</param>
        /// <returns>履歴削除結果</returns>
        int DeleteSendingHistory(ref MailSourceData mailSourceData);

        /// <summary>
        /// メール送信履歴削除
        /// </summary>
        /// <param name="targetIndex">操作対象データインデックス</param>
        /// <param name="mailSourceData">履歴削除対象メールデータ</param>
        /// <returns>履歴削除結果</returns>
        int DeleteSendingHistory(int targetIndex, ref MailSourceData mailSourceData);


        /// <summary>
        /// メール送信履歴作成ライブラリバージョン
        /// </summary>
        string Version { get; }

    }

}

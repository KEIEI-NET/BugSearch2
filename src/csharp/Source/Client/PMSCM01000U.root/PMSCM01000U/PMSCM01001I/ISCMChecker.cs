using System;
using System.Collections.Generic;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// SCMチェッカーインターフェース
    /// </summary>
	/// <remarks>
	/// <br>Update Note	: 2012.04.10 22024 寺坂　誉志</br>
	/// <br>			: １．高速化対応</br>
	/// </remarks>
    public interface ISCMChecker
    {
        /// <summary>
        /// 基本情報のチェックを行う。
        /// </summary>
        /// <returns></returns>
        int CheckInitialInfo();
       
        /// <summary>
        /// 新着件数を取得します。
        /// </summary>
        /// <returns>新着件数</returns>
        int GetNewOrderCount();

        /// <summary>
        /// ダウンロードします。
        /// </summary>
        /// <returns>結果コード</returns>
        int DownloadWebDB();

////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
        /// <summary>
        /// ダウンロードします。
        /// </summary>
		/// <param name="isGetlastTime">前回処理日付を取得するか[true:取得する,false:取得しない]</param>
        /// <returns>結果コード</returns>
		int DownloadWebDB(bool isGetlastTime);
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////

        /// <summary>
        /// ローカルへコピーします。
        /// </summary>
        /// <returns>結果コード</returns>
        int CopyToLocal();

        /// <summary>
        /// ステータスを更新します。
        /// </summary>
        /// <returns>結果コード</returns>
        int UpdateWebDBStatus();

        // 2010/12/27 Del >>>
        //// 2010/03/30 Add >>>
        ///// <summary>
        ///// コミュニケーションツールで接続中リストを取得します。
        ///// </summary>
        ///// <returns></returns>
        //int GetSimplInqCnectInfoList();
        //// 2010/03/30 Add <<<
        // 2010/12/27 Del <<<

        ///// <summary>
        ///// 旧システム連携を判定します。
        ///// </summary>
        ///// <returns>
        ///// <c>true</c> :旧システム連携あり<br/>
        ///// <c>false</c>:旧システム連携なし
        ///// </returns>
        //bool ExistsLegacySystem();

        ///// <summary>
        ///// 旧システム連携CSVファイルを出力します。
        ///// </summary>
        ///// <returns>結果コード</returns>
        //int OutputCSVFileForLegacySystem();

        ///// <summary>
        ///// 問合せに回答します。
        ///// </summary>
        ///// <returns>結果コード</returns>
        //int ReplyToOrder();

        /// <summary>
        /// 旧システム連携区分により自動回答処理(連携なし)かCSVファイル出力(連携あり)を行います。
        /// </summary>
        /// <returns>結果コード</returns>
        int ExecuteAutoReplyOrCSVOutput();

        /// <summary>
        /// 端末へポップアップ命令を送信します。
        /// </summary>
        /// <returns>結果コード</returns>
        int SendShowingPopup();

        /// <summary>
        /// 受信日時が設定されていないSCM受注データ取得処理(User)
        /// </summary>
        /// <returns></returns>
        int SearchSCMAcOdrDataAtNoReceiveDate();

        /// <summary>
        /// SCM受発注データ取得処理(Web)
        /// </summary>
        /// <returns></returns>
        int SearchScmOdrDataAtNoReceiveDate();

        /// <summary>
        /// SCM受注データ更新処理(User)
        /// </summary>
        /// <returns></returns>
        int UpdateSCMAcOdrDataAtReceiveDate();
    }
}

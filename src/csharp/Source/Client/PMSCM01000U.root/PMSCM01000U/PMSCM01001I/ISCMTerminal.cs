using System;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// SCM端末インターフェース
    /// </summary>
    public interface ISCMTerminal : IDisposable
    {
        /// <summary>メッセージの受信者を取得します。</summary>
        ITextMessageReceivable MessageReceiver { get; }

        /// <summary>
        /// 受信を開始します。
        /// </summary>
        /// <returns>結果コード</returns>
        int StartReceiving();

        // 2010/04/19 Del >>>
        ///// <summary>
        ///// 新着件数を取得します。
        ///// </summary>
        ///// <returns>新着件数</returns>
        //int GetNewOrderCount();
        // 2010/04/19 Del <<<

        // 2010/04/19 >>>
        //// 2010/03/02 Add >>>
        ///// <summary>
        ///// 新着データリストを取得します。
        ///// </summary>
        ///// <returns>新着データリスト</returns>
        //object GetNewOrderList();
        //// 2010/03/02 Add <<<

        /// <summary>
        /// 新着データリストを取得します。
        /// </summary>
        /// <param name="lastUpdateDate">前回取得日付</param>
        /// <param name="lastUpdateTime">前回取得時間</param>
        /// <returns>新着データリスト</returns>
        object GetNewOrderList(DateTime lastUpdateDate, int lastUpdateTime);
        // 2010/04/19 <<<

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

        // 2010/12/27 Add >>>
        /// <summary>
        /// ＳＣＭデータを取得します。
        /// </summary>
        /// <param name="reardPara"></param>
        /// <param name="scmHeader"></param>
        /// <param name="scmCar"></param>
        /// <param name="scmDtlList"></param>
        /// <param name="scmAnsList"></param>
        /// <returns></returns>
        int GetSCMData(object reardPara, out object scmHeader, out object scmCar, out object scmDtlList, out object scmAnsList);

        /// <summary>
        /// 年式の文字列を取得します。
        /// </summary>
        /// <param name="produceTypeOfYear"></param>
        /// <returns></returns>
        string GetProduceTypeOfYearString(int produceTypeOfYear);

        /// <summary>
        /// キャンセル承認処理を行います。
        /// </summary>
        /// <param name="writePara"></param>
        /// <param name="cancelCndtionDiv"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        int ReturnedGoodsApproval(object writePara, short cancelCndtionDiv, out string errorMsg);
        // 2010/12/27 Add <<<

        // ADD 2015/08/28 譚洪 Redmine#47284 SCM仕掛一覧№10722対応  --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 新着データの最終取得日時を取得します。
        /// </summary>
        /// <param name="cashRegisterNo">端末番号</param>
        /// <param name="scmTimeData">SCM新着データ表示管理データ</param>
        /// <returns></returns>
        int SearchScmTimeData(int cashRegisterNo, out object scmTimeData);

        /// <summary>
        /// 新着データの最終取得日時更新処理
        /// </summary>
        /// <param name="cashRegisterNo">端末番号</param>
        /// <param name="lastUpdateDate">前回取得日付</param>
        /// <param name="lastUpdateTime">前回取得時間</param>
        /// <returns></returns>
        int UpdateScmTimeData(int cashRegisterNo, DateTime lastUpdateDate, int lastUpdateTime);
        // ADD 2015/08/28 譚洪 Redmine#47284 SCM仕掛一覧№10722対応  ---------<<<<<<<<<<<<<<<<<<<<<<<<<
    }
}

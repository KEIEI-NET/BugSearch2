//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 在庫履歴現在庫数設定
// プログラム概要   : 在庫マスタの現在庫数を元に、在庫履歴データの正しい現在庫数を再計算し更新する。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/12/24  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 :
// 修 正 日              修正内容 :
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 在庫履歴現在庫数設定スクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫履歴現在庫数設定です。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009/12/24</br>
    /// </remarks>
    public class StockHistoryUpdateAcs
    {
        # region ■ Constructor ■
        /// <summary>
        /// 在庫履歴現在庫数設定アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 在庫履歴現在庫数設定アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/12/24</br>
        /// </remarks>
        public StockHistoryUpdateAcs()
        {
            // データクリア処理インタフェース
            this._iStockHistoryUpdateDB = (IStockHistoryUpdateDB)MediationStockHistoryUpdateDB.GetStockHistoryUpdateDB();
        }
        # endregion ■ Constructor ■

        #region ■ Const Memebers ■
        // 画面機能ID
        private const string PROGRAM_ID = "PMZAI09152A";
        // 画面機能名称
        private const string PROGRAM_NAME = "在庫履歴現在庫数設定";
        #endregion ■ Const Memebers ■

        # region ■ Private Members ■

        // 在庫履歴現在庫数設定DBインターフェース
        private IStockHistoryUpdateDB _iStockHistoryUpdateDB;

        # endregion ■ Private Members ■

        #region ■ Private Method
        #region ■ 在庫履歴更新処理
        #region ◎ 更新処理
        /// <summary>
        /// 在庫履歴更新処理
        /// </summary>
        /// <param name="stockHistoryExtractInfo">在庫履歴現在庫数設定データクラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 在庫履歴更新処理を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/12/24</br>
        /// </remarks>
        public int Update(StockHistoryExtractInfo stockHistoryExtractInfo, out string errMsg)
        {
            return this.UpdateProc(stockHistoryExtractInfo, out errMsg);
        }

        /// <summary>
        ///在庫履歴更新処理
        /// </summary>
        /// <param name="stockHistoryExtractInfo">在庫履歴現在庫数設定データクラス</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 在庫履歴更新処理を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/12/24</br>
        /// </remarks>
        private int UpdateProc(StockHistoryExtractInfo stockHistoryExtractInfo, out string errMsg)
        {
            // 全てテーブル処理後の状態
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // 操作履歴ログ定義
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();

            // StockHistoryExtractInfo-->StockHistoryUpdateWork処理
            StockHistoryUpdateWork paraWork = this.CopyToWorkFromExtractInfo(stockHistoryExtractInfo);

            errMsg = string.Empty;
            // Remote削除処理
            // 処理コード＝0：無条件クリア
            try
            {
                status = this._iStockHistoryUpdateDB.ReCount(paraWork);

                // 操作履歴ログの書き込み
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

                    operationHistoryLog.WriteOperationLog(
                        this,
                        System.DateTime.Now,
                        LogDataKind.SystemLog,
                        PROGRAM_ID,
                        PROGRAM_NAME,
                        string.Empty,
                        0,
                        0,
                        "正常終了しました。",
                        string.Empty);
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }
                else
                {
                    errMsg = "処理中にエラーが発生しました。(" + status.ToString() + ")";

                    operationHistoryLog.WriteOperationLog
                        (this,
                        System.DateTime.Now,
                        LogDataKind.SystemLog,
                        PROGRAM_ID,
                        PROGRAM_NAME,
                        string.Empty,
                        0,
                        0,
                        "エラーが発生しました。(" + status.ToString() + ")",
                        string.Empty);
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }
        #endregion
        #endregion ◆ 在庫履歴更新処理

        /// <summary>
        ///StockHistoryExtractInfo-->StockHistoryUpdateWork処理
        /// </summary>
        /// <param name="stockHistoryExtractInfo">在庫履歴現在庫数設定データクラス</param>
        /// <returns>StockHistoryUpdateWork</returns>
        /// <remarks>
        /// <br>Note       : StockHistoryExtractInfo-->StockHistoryUpdateWork処理を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/12/24</br>
        /// </remarks>
        private StockHistoryUpdateWork CopyToWorkFromExtractInfo(StockHistoryExtractInfo stockHistoryExtractInfo)
        {
            StockHistoryUpdateWork work = new StockHistoryUpdateWork();

            work.EnterpriseCode = stockHistoryExtractInfo.EnterpriseCode;
            work.AddUpYearMonth = stockHistoryExtractInfo.AddUpYearMonthSt;

            return work;
        }
        #endregion ■ Private Method
    }
}

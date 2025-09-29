//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 在庫マスタコンバート
// プログラム概要   : 在庫管理全体設定の現在庫表示区分より、出荷可能数を更新する。
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2011/08/26  修正内容 : 連番No.1016 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 在庫マスタコンバート処理
    /// </summary>
    /// <remarks>
    /// Note       : 在庫マスタコンバート処理です。<br />
    /// Programmer : 李占川<br />
    /// Date       : 2011/08/26<br />
    /// </remarks>
    public class StockConvertAcs
    {
        #region ■ Const Memebers
        private const string PROGRAM_ID = "PMKHN01300U";
        private const string PROGRAM_NAME = "在庫マスタコンバートツール";
        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constructor

        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        private StockConvertAcs()
        {
            // 変数初期化
            this._iStockConvertDB = MediationStockConvertDB.GetStockConvertDB();
        }
        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region ■Properties
        /// <summary>
        /// 在庫マスタコンバートアクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>在庫マスタコンバート設定アクセスクラス インスタンス</returns>
        public static StockConvertAcs GetInstance()
        {
            if (_stockConvertAcsAcs == null)
            {
                _stockConvertAcsAcs = new StockConvertAcs();
            }

            return _stockConvertAcsAcs;
        }
        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region ■Private Members
        private static StockConvertAcs _stockConvertAcsAcs;
        IStockConvertDB _iStockConvertDB;
        # endregion

        // ===================================================================================== //
        // パブリックイベートメソッド
        // ===================================================================================== //
        #region ■public Methods
        /// <summary>
        /// 在庫マスタコンバート処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="preStckCntDspDiv">現在庫表示区分</param>
        /// <param name="stockCount">在庫マスタ　処理件数</param>
        /// <param name="stockAcPayHistCount">在庫受払履歴データ　処理件数</param>
        /// <returns>STATUS</returns>
        /// <remarks>		
        /// <br>Note		: 在庫マスタコンバート処理を行う。</br>
        /// <br>Programmer	: 李占川</br>	
        /// <br>Date		: 2011/08/26</br>
        /// </remarks>
        public int StockConvertProc(string enterpriseCode, int preStckCntDspDiv, out int stockCount, out int stockAcPayHistCount)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
            string logStr = string.Empty;

            stockCount = 0;
            stockAcPayHistCount = 0;

            try
            {
                StockConvertWork stockConvertWork = new StockConvertWork();
                stockConvertWork.EnterpriseCode = enterpriseCode;
                stockConvertWork.PreStckCntDspDiv = preStckCntDspDiv;

                object stockConvertWorkObj = (object)stockConvertWork;

                status = this._iStockConvertDB.ConvertShipmentPosCnt(stockConvertWorkObj, out stockCount, out stockAcPayHistCount);
                // 正常終了の場合：正常終了しました。 抽出件数：リモートからの抽出件数 削除件数：リモートからの削除件数
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    logStr = "正常終了しました。 在庫マスタ　処理件数：" + this.IntConvert(stockCount) + " 在庫受払履歴データ　処理件数：" + this.IntConvert(stockAcPayHistCount);
                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, logStr, string.Empty);
                }
                // エラーの場合：エラーが発生しました。
                else
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    logStr = "エラーが発生しました。";
                    operationHistoryLog.WriteOperationLog(this, System.DateTime.Now, LogDataKind.SystemLog, PROGRAM_ID, PROGRAM_NAME, string.Empty, 0, 0, logStr, string.Empty);
                }
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 件数フォーマット設定
        /// </summary>
        /// <remarks>		
        /// <br>Note		: 件数フォーマット設定処理を行う。</br>
        /// <br>Programmer	: 李占川</br>	
        /// <br>Date		: 2011/08/26</br>
        /// </remarks>
        private String IntConvert(Int32 searchCount)
        {
            return searchCount.ToString("N0");
        }
        # endregion

    }
}

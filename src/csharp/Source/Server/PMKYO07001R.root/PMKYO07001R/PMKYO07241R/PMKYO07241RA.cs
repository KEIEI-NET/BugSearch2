//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 在庫調整データ集計リモート
// プログラム概要   : 在庫調整データ受信時に在庫マスタの更新を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 孫東響
// 作 成 日  2011/08/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
///----------------------------------------------------------------------------//
// 管理番号              作成担当 : 西 毅
// 修 正 日  2012/03/16  修正内容 : タイムアウト対応(30秒⇒600秒)
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data.SqlClient;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 受信在庫調整データ集計リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 受信在庫調整データ集計操作を行うクラスです。</br>
    /// <br>Programmer : 孫東響</br>
    /// <br>Date       : 2011.8.10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class APTotalizeStockAdjustDB : RemoteDB
    {
        #region[パブリック方法]
        /// <summary>
        /// 在庫調整データ受信更新処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="paramStockAdjustList">受信した在庫調整データリスト</param>
        /// <param name="paramStockAdjustDetailList">受信した在庫調整データ明細リスト</param>
        /// <param name="sqlConnection">DB接続</param>
        /// <param name="sqlTransaction">DBトランザクション</param>
        /// <param name="retMsg">エラー情報</param>
        /// <returns>ステータス</returns>
        public int TotalizeStokAdjust(string enterpriseCode, ArrayList paramStockAdjustList, ArrayList paramStockAdjustDetailList, SqlConnection sqlConnection, SqlTransaction sqlTransaction, out string retMsg)
        {
            retMsg = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            // パラメータチェック
            if (!CheckParam(paramStockAdjustList, paramStockAdjustDetailList))
                return status;

            // 企業コードをバックアップ
            string enterpriseCodeBak = ((APStockAdjustWork)paramStockAdjustList[0]).EnterpriseCode;
            try
            {
                // 受信拠点側の企業コードをセット
                SetEnterpriseCodeToWorkList(enterpriseCode, paramStockAdjustList);
                SetEnterpriseCodeToWorkList(enterpriseCode, paramStockAdjustDetailList);
                // 在庫調整受信更新処理
                status = TotalizeStockAdjust(paramStockAdjustList, paramStockAdjustDetailList, sqlConnection, sqlTransaction,out retMsg);
            }
            finally
            {
                // 企業コードをリストア
                SetEnterpriseCodeToWorkList(enterpriseCodeBak, paramStockAdjustList);
                SetEnterpriseCodeToWorkList(enterpriseCodeBak, paramStockAdjustDetailList);
            }
            return status;
        }
        #endregion

        #region [プライベート方法]
        /// <summary>
        /// 在庫調整データ受信更新処理
        /// </summary>
        /// <param name="paramStockAdjustList">受信した在庫調整データリスト</param>
        /// <param name="paramStockAdjustDetailList">受信した在庫調整データ明細リスト</param>
        /// <param name="sqlConnection">DB接続</param>
        /// <param name="sqlTransaction">DBトランザクション</param>
        /// <param name="retMsg">エラー情報</param>
        /// <returns>ステータス</returns>
        private int TotalizeStockAdjust(ArrayList paramStockAdjustList, ArrayList paramStockAdjustDetailList, SqlConnection sqlConnection, SqlTransaction sqlTransaction, out string retMsg)
        {
            //エラー情報
            retMsg = string.Empty;
            //ステータス
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            

            //対象初期化
            StockAdjustDB _stockAdjustDB = new StockAdjustDB();
            ArrayList stockAdjustWorkList = new ArrayList();
            ArrayList stockAdjustDtlWorkList = new ArrayList();
            APStockAdjustInfoConverter apStockConverter = new APStockAdjustInfoConverter();

            // パラメータを利用して、在庫調整情報ワークリストを取得(後の処理に当該リストを使用)
            List<APStockAdjustInfoWork> apStockAdjustInfoWorkList = GetAPStockAdjustInfoList(paramStockAdjustList, paramStockAdjustDetailList);
            if (apStockAdjustInfoWorkList.Count == 0)
                return status;

            //伝票単位で繰り返し
            for (int i = 0; i < apStockAdjustInfoWorkList.Count; i++)
            {
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 受信した在庫調整データを受信拠点側在庫調整データに変換
                    APStockAdjustInfoWork stockAdjustInfo = apStockAdjustInfoWorkList[i] as APStockAdjustInfoWork;
                    StockAdjustWork stockAdjust = apStockConverter.GetSecStockAdjustWork(stockAdjustInfo.StockAdjustWork);
                    stockAdjustWorkList.Add(stockAdjust);

                    // 受信した在庫調整明細データを受信拠点側在庫調整明細データに変換
                    for (int j = 0; j < stockAdjustInfo.StockAdjustDtlWorkList.Count; j++)
                    {
                        StockAdjustDtlWork stockDtl = apStockConverter.GetSecStockAdjustDtlWork(stockAdjustInfo.StockAdjustDtlWorkList[j]);
                        stockAdjustDtlWorkList.Add(stockDtl);
                    }

                    // 在庫調整受信更新処理
                    if (stockAdjust.LogicalDeleteCode == 0)
                    {
                        status = _stockAdjustDB.WriteForReceiveData(stockAdjustWorkList, stockAdjustDtlWorkList, sqlConnection, sqlTransaction, out retMsg);
                    }
                    if (stockAdjust.LogicalDeleteCode == 1)
                    {
                        status = _stockAdjustDB.DeleteForReceiveData(stockAdjustWorkList, stockAdjustDtlWorkList, sqlConnection, sqlTransaction, out retMsg);
                    }

                    // メモリを釈放
                    stockAdjustWorkList.Clear();
                    stockAdjustDtlWorkList.Clear();
                }
                else
                {
                    //エラー発生
                    break;
                }
            }

            //戻り値
            return status;
        }

        /// <summary>
        /// 受信した在庫調整情報を組み合わせる
        /// </summary>
        /// <param name="paramStockAdjustList">在庫調整データリスト</param>
        /// <param name="paramStockAdjustDetailList">在庫調整明細データリスト</param>
        /// <returns>在庫調整情報リスト</returns>
        private List<APStockAdjustInfoWork> GetAPStockAdjustInfoList(ArrayList paramStockAdjustList, ArrayList paramStockAdjustDetailList)
        {
            //在庫調整データリスト
            List<APStockAdjustInfoWork> stockAdjustInfoList = new List<APStockAdjustInfoWork>();

            if (null == paramStockAdjustList || null == paramStockAdjustDetailList
                || paramStockAdjustList.Count == 0 || paramStockAdjustDetailList.Count == 0)
                return stockAdjustInfoList;

            for (int i = 0; i < paramStockAdjustList.Count; i++)
            {
                // 在庫調整情報ワークを作成
                APStockAdjustInfoWork stockAdjustInfoWork = new APStockAdjustInfoWork();

                APStockAdjustWork stockAdjustWork = (APStockAdjustWork)paramStockAdjustList[i];
                // 在庫調整データを追加
                stockAdjustInfoWork.StockAdjustWork = stockAdjustWork;

                for (int j = 0; j < paramStockAdjustDetailList.Count; j++)
                {
                    APStockAdjustDtlWork stockAdjustDetailWork = (APStockAdjustDtlWork)paramStockAdjustDetailList[j];
                    if (stockAdjustWork.EnterpriseCode == stockAdjustDetailWork.EnterpriseCode
                        && stockAdjustWork.StockAdjustSlipNo == stockAdjustDetailWork.StockAdjustSlipNo)
                        // 在庫調整明細データを追加
                        stockAdjustInfoWork.StockAdjustDtlWorkList.Add(stockAdjustDetailWork);
                }

                if (stockAdjustInfoWork.StockAdjustDtlWorkList.Count > 0)
                    // 在庫調整明細がない在庫調整をデータ対象外とする
                    stockAdjustInfoList.Add(stockAdjustInfoWork);
            }
            return stockAdjustInfoList;
        }

        /// <summary>
        /// パラメータをチェック
        /// </summary>
        /// <param name="paramStockAdjustList">在庫調整伝票リスト</param>
        /// <param name="paramStockAdjustDetailList">在庫調整明細リスト</param>
        /// <returns>true:チェックOK、false:チェックNG</returns>
        private bool CheckParam(ArrayList paramStockAdjustList, ArrayList paramStockAdjustDetailList)
        {
            if (null == paramStockAdjustList || null == paramStockAdjustDetailList || paramStockAdjustList.Count == 0 || paramStockAdjustDetailList.Count == 0)
                return false;
            return true;
        }

        /// <summary>
        /// 企業コードをワークリストにセット
        /// </summary>
        /// <param name="code">企業コード</param>
        /// <param name="paramWkList">ワークリスト</param>
        private void SetEnterpriseCodeToWorkList(string code, ArrayList paramWkList)
        {
            if (null == paramWkList || paramWkList.Count == 0)
                return;
            foreach (Broadleaf.Library.Data.IFileHeader header in paramWkList)
                header.EnterpriseCode = code;
        }
        #endregion
    }
}

//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 在庫移動データ集計リモート
// プログラム概要   : 在庫移動データ受信時に在庫マスタの更新を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 孫東響
// 作 成 日  2011/08/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 孫東響
// 修 正 日  2011/08/24  修正内容 : #23964 ソースレビュー結果①のNO.4　受信時更新処理では「入荷確定なし」固定
//----------------------------------------------------------------------------//
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

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 受信在庫移動データ集計リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 受信在庫移動データ集計操作を行うクラスです。</br>
    /// <br>Programmer : 孫東響</br>
    /// <br>Date       : 2011.8.10</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class APTotalizeStockMoveDB : RemoteDB
    {
        #region [変数定義]
        //受信側入荷確定区分
        //private int _stockMoveFixCode = 0;//DEL 2011/08/24 #23964 ソースレビュー結果①のNO.4　受信時更新処理では「入荷確定なし」固定
        #endregion

        #region[パブリック方法]
        /// <summary>
        /// 在庫移動データ受信更新処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="paramStockMoveList">受信した在庫移動データリスト</param>
        /// <param name="sqlConnection">DB接続</param>
        /// <param name="sqlTransaction">DBトランザクション</param>
        /// <param name="retMsg">エラー情報</param>
        /// <returns>ステータス</returns>
        public int TotalizeStokMove(string enterpriseCode, ArrayList paramStockMoveList, SqlConnection sqlConnection, SqlTransaction sqlTransaction, out string retMsg)
        {
            //エラー情報
            retMsg = string.Empty;

            //ステータス
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // パラメータチェック
            if (paramStockMoveList == null || paramStockMoveList.Count == 0)
                return status;

            // 企業コードをバックアップ
            string enterpriseCodeBak = ((APStockMoveWork)paramStockMoveList[0]).EnterpriseCode;
            try
            {
                // 受信拠点側の企業コードをセット
                SetEnterpriseCodeToWorkList(enterpriseCode, paramStockMoveList);

                //受信側入荷確定区分取得
                //_stockMoveFixCode = GetStockMoveFixCode(enterpriseCode);//DEL 2011/08/24 #23964 ソースレビュー結果①のNO.4　受信時更新処理では「入荷確定なし」固定

                // 在庫移動データ受信更新処理
                status = TotalizeStokMove(paramStockMoveList, sqlConnection, sqlTransaction, out retMsg);
            }
            finally
            {
                // 企業コードをリストア
                SetEnterpriseCodeToWorkList(enterpriseCodeBak, paramStockMoveList);
            }
            return status;
        }
        #endregion

        #region [プライベート方法]
        /// <summary>
        /// 在庫移動データ受信更新処理
        /// </summary>
        /// <param name="paramStockMoveList">受信した在庫移動データリスト</param>
        /// <param name="sqlConnection">DB接続</param>
        /// <param name="sqlTransaction">DBトランザクション</param>
        /// <param name="retMsg">エラー情報</param>
        /// <returns>ステータス</returns>
        private int TotalizeStokMove(ArrayList paramStockMoveList, SqlConnection sqlConnection, SqlTransaction sqlTransaction, out string retMsg)
        {
            //エラー情報
            retMsg = string.Empty;
            //ステータス
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            //在庫更新
            StockMoveDB _stockMoveDB = new StockMoveDB();
            APStockMoveInfoConverter converter = new APStockMoveInfoConverter();
            ArrayList stockList = new ArrayList();
            Hashtable slipNo = new Hashtable();

            //伝票単位で繰り返し
            for (int i = 0; i < paramStockMoveList.Count; i++)
            {
                //在庫更新データパラメータと在庫受払履歴更新パラメータを更新
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                
                    // 受信した在庫移動データを受信拠点側在庫移動データに変換
                    APStockMoveWork apStockMoveWork = paramStockMoveList[i] as APStockMoveWork;
                    if (slipNo.Contains(apStockMoveWork.StockMoveSlipNo))
                    {
                        continue;
                    }
                    else
                    {
                        slipNo.Add(apStockMoveWork.StockMoveSlipNo, i);
                        StockMoveWork stockMoveWork = converter.GetSecStockMoveWork(apStockMoveWork);
                        //stockMoveWork.StockMoveFixCode = _stockMoveFixCode;//DEL 2011/08/24 #23964 ソースレビュー結果①のNO.4　受信時更新処理では「入荷確定なし」固定
                        stockMoveWork.StockMoveFixCode = 2;//ADD 2011/08/24 #23964 ソースレビュー結果①のNO.4　受信時更新処理では「入荷確定なし」固定
                        stockList.Add(stockMoveWork);
                    }
                    for (int j = i + 1; j < paramStockMoveList.Count; j++)
                    {
                        APStockMoveWork apStockMoveWorkChild = paramStockMoveList[j] as APStockMoveWork;
                        if (apStockMoveWork.StockMoveSlipNo == apStockMoveWorkChild.StockMoveSlipNo)
                        {
                            StockMoveWork stockMoveWork = converter.GetSecStockMoveWork(apStockMoveWorkChild);
                            //stockMoveWork.StockMoveFixCode = _stockMoveFixCode;//DEL 2011/08/24 #23964 ソースレビュー結果①のNO.4　受信時更新処理では「入荷確定なし」固定
                            stockMoveWork.StockMoveFixCode = 2;//ADD 2011/08/24 #23964 ソースレビュー結果①のNO.4　受信時更新処理では「入荷確定なし」固定
                            stockList.Add(stockMoveWork);
                        }
                    }

                    if (apStockMoveWork.LogicalDeleteCode == 0)
                    {
                        status = _stockMoveDB.WriteForReceiveData(stockList, sqlConnection, sqlTransaction, out retMsg);
                    }
                    if (apStockMoveWork.LogicalDeleteCode == 1)
                    {
                        status = _stockMoveDB.DeleteForReceiveData(stockList, sqlConnection, sqlTransaction);
                    }

                    stockList.Clear();                    
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
        /// 受信側入荷確定区分取得
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns></returns>
        private int GetStockMoveFixCode(string enterpriseCode)
        {
            int stockMoveFixCode = 0;
            object obj = new object();
            ArrayList retList;
            StockMngTtlStDB stockMngTtlStDB = new StockMngTtlStDB();

            StockMngTtlStWork  stockMngTtlStWork = new StockMngTtlStWork();
            stockMngTtlStWork.EnterpriseCode = enterpriseCode;
            ArrayList stockMngTtlStWorkList = new ArrayList();
            stockMngTtlStWorkList.Add(stockMngTtlStWork);

            stockMoveFixCode = stockMngTtlStWork.StockMoveFixCode;

            int statusMngTtlSt = stockMngTtlStDB.Search(out obj, stockMngTtlStWorkList as object, 0, ConstantManagement.LogicalMode.GetData0);
            if (statusMngTtlSt == 0)
            {
                retList = obj as ArrayList;
                foreach (StockMngTtlStWork stockMngTtlSt in retList)
                {
                    if (stockMngTtlSt.SectionCode.Trim() == "00")
                    {
                        stockMoveFixCode = stockMngTtlSt.StockMoveFixCode;
                        break;
                    }
                }
            }

            return stockMoveFixCode;
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

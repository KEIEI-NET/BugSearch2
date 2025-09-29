//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ハンディターミナル検品照会リモートオブジェクト
// プログラム概要   : ハンディターミナル検品照会を行います
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 陳艶丹
// 作 成 日  2017/07/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 3H 張小磊                               
// 修 正 日  2017/09/07  修正内容 : 検品照会の変更対応
//----------------------------------------------------------------------------//
// 管理番号  11470154-00 作成担当 : 陳艶丹                              
// 修 正 日  2018/10/16  修正内容 : ハンディターミナル五次対応
//                                  取消機能とテキスト出力機能の追加
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ハンディターミナル検品照会リモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : ハンディターミナル検品照会リモートオブジェクトです。</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2017/07/20</br>
    /// <br>Update Note: 2017/09/07 3H 張小磊</br>
    /// <br>　　　　　 : 検品照会の変更対応</br>
    /// <br>Update Note: 2018/10/16 陳艶丹</br>
    /// <br>　　　　　 : ハンディターミナル五次対応</br>
    /// </remarks>
    [Serializable]
    public class HandyInspectRefDataDB : RemoteDB, IHandyInspectRefDataDB
    {
        #region const
        /// <summary>受注ステータス（30：売上）</summary>
        private const int SalesStatus = 30;
        /// <summary>受注ステータス（40：貸出）</summary>
        private const int RentStatus = 40;
        /// <summary>受払元伝票区分（20：売上）</summary>
        private const int SalesAcPaySlipCd = 20;
        /// <summary>受払元伝票区分（22：出荷）</summary>
        private const int ShipmSlipCd = 22;
        /// <summary>売上伝票区分(明細)（0：売上）</summary>
        private const int SalesSlipCdDtl = 0;
        /// <summary>売上伝票区分(明細)（1：返品）</summary>
        private const int RetSlipCdDtl = 1;
        /// <summary>ゼロ</summary>
        private const int Zero = 0;
        #endregion

        #region
        private InspectDataDB HandyInspectDataDB = null;

        /// <summary>
        /// 検品データ DBリモートプロパティ
        /// </summary>
        private InspectDataDB InspectDataObj
        {
            get
            {
                if (this.HandyInspectDataDB == null)
                {
                    // 検品データ DBリモートを生成
                    this.HandyInspectDataDB = new InspectDataDB();
                }

                return this.HandyInspectDataDB;
            }
        }
        #endregion

        #region [コンストラクタ]
        /// <summary>
        /// ハンディターミナル検品照会リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        public HandyInspectRefDataDB()
        {
            // なし
        }
        #endregion

        #region Search
        /// <summary>
        /// ハンディターミナル検品照会情報リストの取得処理
        /// </summary>
        /// <param name="inspectRefDataObj">検品照会情報</param>
        /// <param name="searchCondtObj">検索パラメータ</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディターミナル検品照会情報リストを取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note: 2017/09/07 3H 張小磊</br>
        /// <br>　　　　　 : 検品照会の変更対応</br>
        /// </remarks>
        public int Search(out object inspectRefDataObj, object searchCondtObj, out string errMessage)
        {
            SqlConnection Connection = null;
            errMessage = string.Empty;
            // 検索結果
            inspectRefDataObj = null;
            ArrayList RetList = null;
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // コネクション生成
            using (Connection = CreateSqlConnection(true))
            {
                try
                {
                    // 検索条件
                    HandyInspectParamWork cndtnWork = searchCondtObj as HandyInspectParamWork;
                    // --- DEL 3H 張小磊 2017/09/07---------->>>>>
                    //// 出庫検品と入庫検品のデータ抽出
                    //if (cndtnWork.Pattern == 0 || cndtnWork.Pattern == 1)
                    //{
                    //    // 売上データ検索処理
                    //    Status = SearchProc(out RetList, cndtnWork, out errMessage, ref Connection);
                    //}
                    //else if (cndtnWork.Pattern == 3)
                    //{
                    //    // 検品のみデータ抽出処理
                    //    Status = SearchInspectProc(out RetList, cndtnWork, out errMessage, ref Connection);
                    //}
                    // --- DEL 3H 張小磊 2017/09/07----------<<<<<
                    // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                    RetList = new ArrayList();
                    // パターン:「出庫検品」のデータ抽出
                    if (cndtnWork.Pattern == 0)
                    {
                        // 取引対象の「売上」1：選択有り や 取引対象の「貸出」1：選択有り
                        if (cndtnWork.TransSales == 1 || cndtnWork.TransLend == 1)
                        {
                            // 売上データ
                            ArrayList salesList = null;
                            // 売上データ検索処理
                            Status = SearchProc(out salesList, cndtnWork, out errMessage, ref Connection);
                            if (Status == ((int)ConstantManagement.DB_Status.ctDB_ERROR))
                            {
                                return Status;
                            }
                            if (salesList != null && salesList.Count > 0)
                            {
                                for (int i = 0; i < salesList.Count; i++)
                                {
                                    RetList.Add(salesList[i]);
                                }
                            }
                        }
                        // 取引対象の「仕入」1：選択有り
                        if (cndtnWork.TransStockSlip == 1)
                        {
                            // 仕入データ
                            ArrayList stockSlipList = null;
                            // 仕入データ抽出処理
                            Status = SearchStockSlipProc(out stockSlipList, cndtnWork, out errMessage, ref Connection);
                            if (Status == ((int)ConstantManagement.DB_Status.ctDB_ERROR))
                            {
                                return Status;
                            }
                            if (stockSlipList != null && stockSlipList.Count > 0)
                            {
                                for (int i = 0; i < stockSlipList.Count; i++)
                                {
                                    RetList.Add(stockSlipList[i]);
                                }
                            }
                        }
                        // 取引対象の「移動出庫」1：選択有り
                        if (cndtnWork.TransMoveOutWarehouse == 1)
                        {
                            // 在庫移動データ
                            ArrayList stockMoveList = null;
                            // 在庫移動データ抽出処理
                            Status = SearchStockMoveProc(out stockMoveList, cndtnWork, out errMessage, ref Connection);
                            if (Status == ((int)ConstantManagement.DB_Status.ctDB_ERROR))
                            {
                                return Status;
                            }
                            if (stockMoveList != null && stockMoveList.Count > 0)
                            {
                                for (int i = 0; i < stockMoveList.Count; i++)
                                {
                                    RetList.Add(stockMoveList[i]);
                                }
                            }
                        }
                        // 取引対象の「補充出庫」1：選択有り
                        if (cndtnWork.TransReplenishOutWarehouse == 1)
                        {
                            // 在庫調整データ
                            ArrayList stockAdjustList = null;
                            // 在庫調整データ抽出処理
                            Status = SearchStockAdjustProc(out stockAdjustList, cndtnWork, out errMessage, ref Connection, false);
                            if (Status == ((int)ConstantManagement.DB_Status.ctDB_ERROR))
                            {
                                return Status;
                            }
                            if (stockAdjustList != null && stockAdjustList.Count > 0)
                            {
                                for (int i = 0; i < stockAdjustList.Count; i++)
                                {
                                    RetList.Add(stockAdjustList[i]);
                                }
                            }
                        }
                        // 取引対象の「在庫仕入」1：選択有り
                        if (cndtnWork.TransStockStockSlip == 1)
                        {
                            // 在庫調整データ
                            ArrayList stockAdjustList = null;
                            // 在庫調整データ抽出処理
                            Status = SearchStockAdjustProc(out stockAdjustList, cndtnWork, out errMessage, ref Connection, true);
                            if (Status == ((int)ConstantManagement.DB_Status.ctDB_ERROR))
                            {
                                return Status;
                            }
                            if (stockAdjustList != null && stockAdjustList.Count > 0)
                            {
                                for (int i = 0; i < stockAdjustList.Count; i++)
                                {
                                    RetList.Add(stockAdjustList[i]);
                                }
                            }
                        }
                    }
                    // パターン:「入庫検品」のデータ抽出
                    else if (cndtnWork.Pattern == 1)
                    {
                        // 取引対象の「売上」1：選択有り や 取引対象の「貸出」1：選択有り
                        if (cndtnWork.TransSales == 1 || cndtnWork.TransLend == 1)
                        {
                            // 売上データ
                            ArrayList salesList = null;
                            // 売上データ検索処理
                            Status = SearchProc(out salesList, cndtnWork, out errMessage, ref Connection);
                            if (Status == ((int)ConstantManagement.DB_Status.ctDB_ERROR))
                            {
                                return Status;
                            }
                            if (salesList != null && salesList.Count > 0)
                            {
                                for (int i = 0; i < salesList.Count; i++)
                                {
                                    RetList.Add(salesList[i]);
                                }
                            }
                        }
                        // 取引対象の「仕入」1：選択有り
                        if (cndtnWork.TransStockSlip == 1)
                        {
                            // 仕入データ
                            ArrayList stockSlipList = null;
                            // 仕入データ抽出処理
                            Status = SearchStockSlipProc(out stockSlipList, cndtnWork, out errMessage, ref Connection);
                            if (Status == ((int)ConstantManagement.DB_Status.ctDB_ERROR))
                            {
                                return Status;
                            }
                            if (stockSlipList != null && stockSlipList.Count > 0)
                            {
                                for (int i = 0; i < stockSlipList.Count; i++)
                                {
                                    RetList.Add(stockSlipList[i]);
                                }
                            }
                        }
                        // 取引対象の「移動入庫」1：選択有り
                        if (cndtnWork.TransMoveInWarehouse == 1)
                        {
                            // 在庫移動データ
                            ArrayList stockMoveList = null;
                            // 在庫移動データ抽出処理
                            Status = SearchStockMoveProc(out stockMoveList, cndtnWork, out errMessage, ref Connection);
                            if (Status == ((int)ConstantManagement.DB_Status.ctDB_ERROR))
                            {
                                return Status;
                            }
                            if (stockMoveList != null && stockMoveList.Count > 0)
                            {
                                for (int i = 0; i < stockMoveList.Count; i++)
                                {
                                    RetList.Add(stockMoveList[i]);
                                }
                            }
                        }
                        // 取引対象の「在庫仕入」1：選択有り
                        if (cndtnWork.TransStockStockSlip == 1)
                        {
                            // 在庫調整データ
                            ArrayList stockAdjustList = null;
                            // 在庫調整データ抽出処理
                            Status = SearchStockAdjustProc(out stockAdjustList, cndtnWork, out errMessage, ref Connection, true);
                            if (Status == ((int)ConstantManagement.DB_Status.ctDB_ERROR))
                            {
                                return Status;
                            }
                            if (stockAdjustList != null && stockAdjustList.Count > 0)
                            {
                                for (int i = 0; i < stockAdjustList.Count; i++)
                                {
                                    RetList.Add(stockAdjustList[i]);
                                }
                            }
                        }
                    }
                    // パターン:「未入庫」のデータ抽出
                    else if (cndtnWork.Pattern == 2)
                    {
                        // 取引対象の「仕入」1：選択有り
                        if (cndtnWork.TransStockSlip == 1)
                        {
                            // 仕入データ抽出処理
                            Status = SearchStockSlipProc(out RetList, cndtnWork, out errMessage, ref Connection);
                            if (Status == ((int)ConstantManagement.DB_Status.ctDB_ERROR))
                            {
                                return Status;
                            }
                        }
                    }
                    // パターン:「検品のみ」のデータ抽出
                    else if (cndtnWork.Pattern == 3)
                    {
                        // 検品のみデータ抽出処理
                        Status = SearchInspectProc(out RetList, cndtnWork, out errMessage, ref Connection);
                        if (Status == ((int)ConstantManagement.DB_Status.ctDB_ERROR))
                        {
                            return Status;
                        }
                    }
                    // 検品照会情報データがある
                    if (RetList != null && RetList.Count > 0)
                    {
                        Status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        Status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                    // --- ADD 3H 張小磊 2017/09/07----------<<<<<
                    
                    // 検索結果の格納
                    inspectRefDataObj = RetList;
                }
                catch (Exception ex)
                {
                    Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "HandyInspectRefDataDB.Search Exception=" + ex.Message, Status);
                }
            }
            return Status;
        }
        #endregion

        #region 検品ガイド検索
        /// <summary>
        /// 検品ガイドデータの取得処理
        /// </summary>
        /// <param name="searchCondtObj">検索パラメータ</param>
        /// <param name="inspectDataObj">検品データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検品ガイドデータを取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note: 2017/09/07 3H 張小磊</br>
        /// <br>　　　　　 : 検品照会の変更対応</br>
        /// </remarks>
        public int SearchGuid(object searchCondtObj,out object inspectDataObj)
        {
            SqlConnection Connection = null;
            // 検索結果
            inspectDataObj = null;
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // コネクション生成
            using (Connection = CreateSqlConnection(true))
            {
                try
                {
                    // 検索条件
                    HandyInspectDataWork cndtnWork = searchCondtObj as HandyInspectDataWork;
                    // 検品データ検索処理
                    // --- DEL 3H 張小磊 2017/09/07---------->>>>>
                    //Status = this.InspectDataObj.SearchProc(cndtnWork, out inspectDataObj, ref Connection);
                    // --- DEL 3H 張小磊 2017/09/07----------<<<<<
                    // --- ADD 3H 張小磊 2017/09/07---------->>>>>
                    Status = this.InspectDataObj.SearchGuidProc(cndtnWork, out inspectDataObj, ref Connection);
                    // --- ADD 3H 張小磊 2017/09/07----------<<<<<
                }
                catch (Exception ex)
                {
                    Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "HandyInspectRefDataDB.SearchGuid Exception=" + ex.Message, Status);
                }
            }
            return Status;
        }
        #endregion

        #region [引当処理]
        /// <summary>
        /// 引当データ処理
        /// </summary>
        /// <param name="deleteDataObj">先行検品データ物理削除データ</param>
        /// <param name="insertDataObj">検品データ</param>
        /// <param name="type">0:手動検品データ登録処理,1:先行検品引当登録処理</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 引当データ処理を行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        public int WriteInspectData(object deleteDataObj, object insertDataObj, int type)
        {
            SqlConnection Connection = null;
            SqlTransaction Transaction = null;
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // コネクション生成
            using (Connection = CreateSqlConnection(true))
            {
                try
                {
                    // トランザクション開始
                    Transaction = Connection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
                    if (type == 0)
                    {
                        ArrayList insertDataList = insertDataObj as ArrayList;
                        // 手動検品データ登録処理
                        Status = this.InspectDataObj.WriteInspectDataProc(ref insertDataList, ref Connection, ref Transaction, type);
                    }
                    else
                    {
                        // 削除条件
                        ArrayList deleteDataList = deleteDataObj as ArrayList;
                        // 先行検品データ物理削除処理
                        Status = this.InspectDataObj.DeleteInspectData(ref deleteDataList, ref Connection, ref Transaction);
                        if (Status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            ArrayList insertDataList = insertDataObj as ArrayList;
                            // 登録処理
                            Status = this.InspectDataObj.WriteInspectDataProc(ref insertDataList, ref Connection, ref Transaction, 0);
                        }
                    }

                    if (Status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        // コミット
                        Transaction.Commit();
                    else
                    {
                        // ロールバック
                        if (Transaction.Connection != null) Transaction.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "HandyInspectRefDataDB.WriteInspectData Exception=" + ex.Message, Status);
                }
                finally
                {
                    if (Transaction != null) Transaction.Dispose();
                }
            }
            return Status;

        }
        #endregion

        // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
        #region [削除処理]
        /// <summary>
        /// 検品データ削除処理
        /// </summary>
        /// <param name="delInspectDataObj">検品データ</param>
        /// <param name="retMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 検品データ削除処理を行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2019/10/16</br>
        /// </remarks>
        public int DeleteInspectData(object delInspectDataObj, out string retMessage)
        {
            SqlConnection connection = null;
            SqlTransaction transaction = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMessage = string.Empty;
            // コネクション生成
            using (connection = CreateSqlConnection(true))
            {
                try
                {
                    // トランザクション開始
                    transaction = connection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                    // 削除条件
                    ArrayList deleteDataList = delInspectDataObj as ArrayList;
                    // 検品データ物理削除処理
                    status = this.InspectDataObj.DeleteInspectData(ref deleteDataList, ref connection, ref transaction);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        // コミット
                        transaction.Commit();
                    else
                    {
                        // ロールバック
                        if (transaction.Connection != null) transaction.Rollback();
                    }
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    retMessage = ex.Message;
                    base.WriteErrorLog(ex, "HandyInspectRefDataDB.WriteInspectData Exception=" + retMessage, status);
                }
                finally
                {
                    if (transaction != null) transaction.Dispose();
                }
            }
            return status;

        }
        #endregion
        // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<

        #region 売上データ検索
        /// <summary>
        /// 指定された企業コードの検品照会データの全て戻る処理
        /// </summary>
        /// <param name="retList">出力データ</param>
        /// <param name="cndtnWork">検索条件</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された企業コードの検品照会データLISTを全て戻します</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList,
            HandyInspectParamWork cndtnWork, out string errMessage, ref SqlConnection sqlConnection)
        {
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retList = new ArrayList();
            errMessage = string.Empty;
            // 売上データ一時テーブル
            string TableNameGuid = Guid.NewGuid().ToString();
            string TempTblName = "##SALES_" + TableNameGuid.Replace('-', '_');

            // 売上明細データ一時テーブル
            TableNameGuid = Guid.NewGuid().ToString();
            string TempDtlName = "##SALESDTL_" + TableNameGuid.Replace('-', '_');
            try
            {
                // 売上データ一時テーブルの作成
                Status = CreateSalesTempTbl(cndtnWork, TempTblName, ref sqlConnection);

                //  売上明細データ一時テーブルの作成
                if (Status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && cndtnWork.Pattern == 1 && cndtnWork.TransLend ==1)
                {
                    // 売上明細データの検索
                    Status = CreateSalesDtlTempTbl(cndtnWork, TempDtlName, ref sqlConnection);
                }

                // 売上データの検索
                if (Status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 入出庫検品データの検索
                    Status = SearchSalesProc(out retList, cndtnWork, TempTblName, TempDtlName, out errMessage, ref sqlConnection);
                }
            }
            catch (Exception ex)
            {
                retList = new ArrayList();
                errMessage = ex.Message;
                base.WriteErrorLog(ex, "HandyInspectRefDataDB.SearchProc Exception=" + ex.Message, Status);
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                // 売上データ一時テーブルの削除
                this.DropTempTable(TempTblName, ref sqlConnection);
                // 売上明細データ一時テーブルの削除
                this.DropTempTable(TempDtlName, ref sqlConnection);
            }

            return Status;
        }
        #endregion

        #region 一時テーブルの作成
        /// <summary>
        /// 売上データの一時テーブルの作成
        /// </summary>
        /// <param name="cndtnWork">検索条件</param>
        /// <param name="tempTblName">一時テーブル名</param>
        /// <param name="sqlConnection">コネション情報</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 売上データの一時テーブルの作成を行う</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2017/07/20</br>
        /// <br>Update Note : 2017/09/07 3H 張小磊</br>
        /// <br>　　　　　  : 11370074-00 受注ステータス列挙体速度改善</br>
        /// </remarks>
        private int CreateSalesTempTbl(HandyInspectParamWork cndtnWork, string tempTblName, ref SqlConnection sqlConnection)
        {
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand SqCommand = null;
            try
            {
                using (SqCommand = new SqlCommand("", sqlConnection))
                {
                    StringBuilder SqlText = new StringBuilder();

                    #region クエリ文の構築
                    SqlText.AppendLine(" SELECT ");
                    SqlText.AppendLine(" SALES.ENTERPRISECODERF ");
                    SqlText.AppendLine(" ,SALES.RESULTSADDUPSECCDRF  ");    // 売上明細データ.実績計上拠点コード
                    SqlText.AppendLine(" ,SALES.SALESSLIPNUMRF ");         // 売上明細データ.売上伝票番号
                    SqlText.AppendLine(" ,SALES.SALESROWNORF ");           // 売上明細データ.行番号
                    SqlText.AppendLine(" ,SALES.GOODSMAKERCDRF");         // 売上明細データ.商品メーカーコード
                    SqlText.AppendLine(" ,SALES.GOODSNORF");              // 売上明細データ.商品番号
                    SqlText.AppendLine(" ,SALES.SHIPMENTCNTRF ");           // 売上明細データ.出荷数
                    SqlText.AppendLine(" ,SALES.CUSTOMERSNMRF");          // 売上明細データ.得意先略称
                    SqlText.AppendLine(" ,SALES.WAREHOUSECODERF");              // 売上明細データ.倉庫コード
                    SqlText.AppendLine(" ,SALES.WAREHOUSENAMERF ");           // 売上明細データ.倉庫名称
                    SqlText.AppendLine(" ,SALES.WAREHOUSESHELFNORF");          // 売上明細データ.倉庫棚番
                    SqlText.AppendLine(" ,SALES.SHIPMENTDAYRF ");           // 売上データ.出荷日付
                    SqlText.AppendLine(" ,SALES.ACPTANODRSTATUSRF");          // 売上明細データ.受注ステータス
                    SqlText.AppendLine(" ,SALES.LOGICALDELETECODERF");              // 売上明細データ.論理削除区分
                    SqlText.AppendLine(" ,SALES.SECTIONCODERF");              // 売上明細データ.拠点コード
                    SqlText.AppendLine(" ,SALES.SALESSLIPDTLNUMRF ");           // 売上明細データ.売上明細通番
                    SqlText.AppendLine(" ,SALES.ACPTANODRSTATUSSRCRF");          // 売上明細データ.受注ステータス（元）
                    SqlText.AppendLine(" ,SALES.SALESSLIPDTLNUMSRCRF");              // 売上明細データ.売上明細通番（元）
                    SqlText.AppendLine(" ,SALES.SALESSLIPCDDTLRF");          // 売上明細データ.売上伝票区分（明細）
                    SqlText.AppendLine(" ,SALES.MAKERNAMERF");          // 売上明細データ.メーカー名称
                    SqlText.AppendLine(" ,SALES.GOODSNAMERF");          // 売上明細データ.商品名称
                    SqlText.AppendLine(" INTO " + tempTblName);
                    SqlText.AppendLine(" FROM ( ");
                    SqlText.AppendLine("  SELECT ");
                    SqlText.AppendLine(" SD.ENTERPRISECODERF ");
                    SqlText.AppendLine(" ,SL.RESULTSADDUPSECCDRF  ");    // 売上明細データ.実績計上拠点コード
                    SqlText.AppendLine(" ,SD.SALESSLIPNUMRF ");         // 売上明細データ.売上伝票番号
                    SqlText.AppendLine(" ,SD.SALESROWNORF ");           // 売上明細データ.行番号
                    SqlText.AppendLine(" ,SD.GOODSMAKERCDRF");         // 売上明細データ.商品メーカーコード
                    SqlText.AppendLine(" ,SD.GOODSNORF");              // 売上明細データ.商品番号
                    SqlText.AppendLine(" ,SD.SHIPMENTCNTRF ");           // 売上明細データ.出荷数
                    SqlText.AppendLine(" ,SL.CUSTOMERSNMRF");          // 売上明細データ.得意先略称
                    SqlText.AppendLine(" ,SD.WAREHOUSECODERF");              // 売上明細データ.倉庫コード
                    SqlText.AppendLine(" ,SD.WAREHOUSENAMERF ");           // 売上明細データ.倉庫名称
                    SqlText.AppendLine(" ,SD.WAREHOUSESHELFNORF");          // 売上明細データ.倉庫棚番
                    SqlText.AppendLine(" ,SL.SHIPMENTDAYRF ");           // 売上データ.出荷日付
                    SqlText.AppendLine(" ,SD.ACPTANODRSTATUSRF");          // 売上明細データ.受注ステータス
                    SqlText.AppendLine(" ,SD.LOGICALDELETECODERF");              // 売上明細データ.論理削除区分
                    SqlText.AppendLine(" ,SD.SECTIONCODERF");              // 売上明細データ.拠点コード
                    SqlText.AppendLine(" ,SD.SALESSLIPDTLNUMRF ");           // 売上明細データ.売上明細通番
                    SqlText.AppendLine(" ,SD.ACPTANODRSTATUSSRCRF");          // 売上明細データ.受注ステータス（元）
                    SqlText.AppendLine(" ,SD.SALESSLIPDTLNUMSRCRF");              // 売上明細データ.売上明細通番（元）
                    SqlText.AppendLine(" ,SD.SALESSLIPCDDTLRF");          // 売上明細データ.売上伝票区分（明細）
                    SqlText.AppendLine(" ,SD.MAKERNAMERF");          // 売上明細データ.メーカー名称
                    SqlText.AppendLine(" ,SD.GOODSNAMERF");          // 売上明細データ.商品名称
                    // 売上明細データ
                    SqlText.AppendLine(" FROM SALESDETAILRF AS SD WITH (READUNCOMMITTED)");
                    // INNER JOIN 売上データ
                    SqlText.AppendLine(" INNER JOIN SALESSLIPRF AS SL WITH (READUNCOMMITTED)");
                    SqlText.AppendLine(" ON SL.ENTERPRISECODERF = SD.ENTERPRISECODERF");
                    SqlText.AppendLine(" AND SL.ACPTANODRSTATUSRF = SD.ACPTANODRSTATUSRF");
                    SqlText.AppendLine(" AND SL.SALESSLIPNUMRF = SD.SALESSLIPNUMRF");
                    SqlText.AppendLine(" AND SL.LOGICALDELETECODERF = SD.LOGICALDELETECODERF");

                    // WHERE文
                    SqlText.AppendLine(MakeWhereString(cndtnWork, ref SqCommand, 0));

                    SqlText.AppendLine(" ) AS SALES ");

                    #endregion

                    SqCommand.CommandText = SqlText.ToString();
                    SqCommand.CommandTimeout = 3600;
                    SqCommand.ExecuteNonQuery();

                    Status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                Status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "HandyInspectRefDataDB.CreateSalesTempTbl Exception=" + ex.Message);
                Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return Status;
        }

        /// <summary>
        /// 売上明細データの一時テーブルの作成
        /// </summary>
        /// <param name="cndtnWork">検索条件</param>
        /// <param name="tempDtlName">一時テーブル名</param>
        /// <param name="sqlConnection">コネション情報</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 売上明細データの一時テーブルの作成を行う</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2017/07/20</br>
        /// </remarks>
        private int CreateSalesDtlTempTbl(HandyInspectParamWork cndtnWork, string tempDtlName, ref SqlConnection sqlConnection)
        {
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlCommand SqlCommandInfo = null;
            try
            {
                using (SqlCommandInfo = new SqlCommand("", sqlConnection))
                {
                    StringBuilder SqlText = new StringBuilder();

                    #region クエリ文の構築
                    SqlText.AppendLine(" SELECT ");
                    SqlText.AppendLine(" SDTL.ENTERPRISECODERF ");
                    SqlText.AppendLine(" ,SDTL.SALESSLIPNUMRF ");         // 売上明細データ.売上伝票番号
                    SqlText.AppendLine(" ,SDTL.SALESROWNORF ");           // 売上明細データ.行番号
                    SqlText.AppendLine(" ,SDTL.GOODSMAKERCDRF");         // 売上明細データ.商品メーカーコード
                    SqlText.AppendLine(" ,SDTL.GOODSNORF");              // 売上明細データ.商品番号
                    SqlText.AppendLine(" ,SDTL.SHIPMENTCNTRF ");           // 売上明細データ.出荷数
                    SqlText.AppendLine(" ,SDTL.WAREHOUSECODERF");              // 売上明細データ.倉庫コード
                    SqlText.AppendLine(" ,SDTL.WAREHOUSENAMERF ");           // 売上明細データ.倉庫名称
                    SqlText.AppendLine(" ,SDTL.WAREHOUSESHELFNORF");          // 売上明細データ.倉庫棚番
                    SqlText.AppendLine(" ,SDTL.ACPTANODRSTATUSRF");          // 売上明細データ.受注ステータス
                    SqlText.AppendLine(" ,SDTL.LOGICALDELETECODERF");              // 売上明細データ.論理削除区分
                    SqlText.AppendLine(" ,SDTL.SECTIONCODERF");              // 売上明細データ.拠点コード
                    SqlText.AppendLine(" ,SDTL.SALESSLIPDTLNUMRF ");           // 売上明細データ.売上明細通番
                    SqlText.AppendLine(" ,SDTL.ACPTANODRSTATUSSRCRF");          // 売上明細データ.受注ステータス（元）
                    SqlText.AppendLine(" ,SDTL.SALESSLIPDTLNUMSRCRF");              // 売上明細データ.売上明細通番（元）
                    SqlText.AppendLine(" ,SDTL.SALESSLIPCDDTLRF");          // 売上明細データ.売上伝票区分（明細）
                    SqlText.AppendLine(" ,SDTL.SALESDATERF");              // 売上明細データ.売上日付
                    SqlText.AppendLine(" ,SDTL.MAKERNAMERF");          // 売上明細データ.メーカー名称
                    SqlText.AppendLine(" ,SDTL.GOODSNAMERF");          // 売上明細データ.商品名称
                    SqlText.AppendLine(" INTO " + tempDtlName);
                    SqlText.AppendLine(" FROM ( ");
                    SqlText.AppendLine("  SELECT ");
                    SqlText.AppendLine(" SD.ENTERPRISECODERF ");
                    SqlText.AppendLine(" ,SD.SALESSLIPNUMRF ");         // 売上明細データ.売上伝票番号
                    SqlText.AppendLine(" ,SD.SALESROWNORF ");           // 売上明細データ.行番号
                    SqlText.AppendLine(" ,SD.GOODSMAKERCDRF");         // 売上明細データ.商品メーカーコード
                    SqlText.AppendLine(" ,SD.GOODSNORF");              // 売上明細データ.商品番号
                    SqlText.AppendLine(" ,SD.SHIPMENTCNTRF ");           // 売上明細データ.出荷数
                    SqlText.AppendLine(" ,SD.WAREHOUSECODERF");              // 売上明細データ.倉庫コード
                    SqlText.AppendLine(" ,SD.WAREHOUSENAMERF ");           // 売上明細データ.倉庫名称
                    SqlText.AppendLine(" ,SD.WAREHOUSESHELFNORF");          // 売上明細データ.倉庫棚番
                    SqlText.AppendLine(" ,SD.ACPTANODRSTATUSRF");          // 売上明細データ.受注ステータス
                    SqlText.AppendLine(" ,SD.LOGICALDELETECODERF");              // 売上明細データ.論理削除区分
                    SqlText.AppendLine(" ,SD.SECTIONCODERF");              // 売上明細データ.拠点コード
                    SqlText.AppendLine(" ,SD.SALESSLIPDTLNUMRF ");           // 売上明細データ.売上明細通番
                    SqlText.AppendLine(" ,SD.ACPTANODRSTATUSSRCRF");          // 売上明細データ.受注ステータス（元）
                    SqlText.AppendLine(" ,SD.SALESSLIPDTLNUMSRCRF");              // 売上明細データ.売上明細通番（元）
                    SqlText.AppendLine(" ,SD.SALESSLIPCDDTLRF");          // 売上明細データ.売上伝票区分（明細）
                    SqlText.AppendLine(" ,SD.SALESDATERF");              // 売上明細データ.売上日付
                    SqlText.AppendLine(" ,SD.MAKERNAMERF");          // 売上明細データ.メーカー名称
                    SqlText.AppendLine(" ,SD.GOODSNAMERF");          // 売上明細データ.商品名称
                    // 売上明細データ
                    SqlText.AppendLine(" FROM SALESDETAILRF AS SD WITH (READUNCOMMITTED)");
                    // WHERE文
                    SqlText.AppendLine(MakeWhereString(cndtnWork, ref SqlCommandInfo, 1));

                    SqlText.AppendLine(" ) AS SDTL ");

                    #endregion

                    SqlCommandInfo.CommandText = SqlText.ToString();
                    SqlCommandInfo.CommandTimeout = 3600;
                    SqlCommandInfo.ExecuteNonQuery();

                    Status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                Status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyInspectRefDataDB.CreateSalesDtlTempTbl Exception=" + ex.Message, Status);
            }

            return Status;
        }
        #endregion

        #region 一時テーブルの削除
        /// <summary>
        /// 一時テーブルの削除
        /// </summary>
        /// <param name="tempTblName">一時テーブル名</param>
        /// <param name="sqlConnection">コネクション情報</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 一時テーブルの削除を行う</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note : 2017/09/07 3H 張小磊</br>
        /// <br>　　　　　  : 11370074-00 一時テーブルを存在確認せずにDROPしている不具合対応</br>
        /// </remarks>
        private int DropTempTable(string tempTblName, ref SqlConnection sqlConnection)
        {
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                using (SqlCommand sqlCommand = new SqlCommand("", sqlConnection))
                {
                    StringBuilder SqlText = new StringBuilder();

                    #region クエリ文の構築
                    // --- UPD 3H 張小磊 2017/09/07---------->>>>>
                    //SqlText.AppendLine( " DROP TABLE " + tempTblName );
                    SqlText.AppendFormat( " IF OBJECT_ID(N'[tempdb].[dbo].{0}', N'U') IS NOT NULL " , tempTblName );
                    SqlText.AppendFormat( " BEGIN DROP TABLE {0} END " , tempTblName );
                    SqlText.AppendLine();
                    // --- UPD 3H 張小磊 2017/09/07----------<<<<<
                    #endregion

                    sqlCommand.CommandText = SqlText.ToString();

                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                Status = base.WriteSQLErrorLog(ex);
            }
            catch (Exception ex)
            {
                Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, "HandyInspectRefDataDB.DropTempTable Exception=" + ex.Message, Status);
            }

            return Status;
        }
        #endregion

        #region 一時テーブルのMakeWhereString
        /// <summary>
        /// 検索条件文字列生成＋条件値設定
        /// </summary>
        /// <param name="cndtnWork">検索条件格納クラス</param>
        /// <param name="sqlCommand">コマンド</param>
        /// <param name="type">0:売上分のデータ抽出　1:売上明細データ分のデータ抽出</param>
        /// <returns>Where条件文字列</returns>
        /// <remarks>
        /// <br>Note       : 検索条件文字列生成＋条件値設定</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private string MakeWhereString(HandyInspectParamWork cndtnWork, ref SqlCommand sqlCommand, int type)
        {
            StringBuilder SqlText = new StringBuilder();
            SqlText.AppendLine("WHERE ");

            // 売上分のデータ抽出
            if (type == 0)
            {
                // 企業コード
                SqlText.AppendLine(" SL.ENTERPRISECODERF=@ENTERPRISECODE");
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.EnterpriseCode);

                //拠点コード
                if (!String.IsNullOrEmpty(cndtnWork.SectionCode) && !"00".Equals(cndtnWork.SectionCode))
                {
                    SqlText.AppendLine(" AND SL.RESULTSADDUPSECCDRF=@FINDSECTIONCODE");
                    SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                    findParaSectionCode.Value = SqlDataMediator.SqlSetString(cndtnWork.SectionCode);
                }

                // 受注ステータス
                if (cndtnWork.TransSales == 1 && cndtnWork.TransLend == 1)
                {
                    SqlText.AppendLine(" AND (SL.ACPTANODRSTATUSRF = " + RentStatus);
                    SqlText.AppendLine(" OR (SL.ACPTANODRSTATUSRF = " + SalesStatus);
                    // 入出荷日(開始)
                    if (cndtnWork.St_SalesDate > DateTime.MinValue)
                    {
                        SqlText.AppendLine(" AND SL.SHIPMENTDAYRF >= @SALESDATEST ");
                        SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@SALESDATEST", SqlDbType.Int);
                        paraSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(cndtnWork.St_SalesDate);
                    }
                    // 入出荷日(終了)
                    if (cndtnWork.Ed_SalesDate > DateTime.MinValue)
                    {
                        SqlText.AppendLine(" AND SL.SHIPMENTDAYRF <= @SALESDATEED ");
                        SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@SALESDATEED", SqlDbType.Int);
                        paraSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(cndtnWork.Ed_SalesDate);
                    }
                    SqlText.AppendLine(" ))");
                }
                else if (cndtnWork.TransSales == 1)
                {
                    SqlText.AppendLine(" AND SL.ACPTANODRSTATUSRF = " + SalesStatus);
                    // 入出荷日(開始)
                    if (cndtnWork.St_SalesDate > DateTime.MinValue)
                    {
                        SqlText.AppendLine(" AND SL.SHIPMENTDAYRF >= @SALESDATEST ");
                        SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@SALESDATEST", SqlDbType.Int);
                        paraSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(cndtnWork.St_SalesDate);
                    }
                    // 入出荷日(終了)
                    if (cndtnWork.Ed_SalesDate > DateTime.MinValue)
                    {
                        SqlText.AppendLine(" AND SL.SHIPMENTDAYRF <= @SALESDATEED ");
                        SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@SALESDATEED", SqlDbType.Int);
                        paraSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(cndtnWork.Ed_SalesDate);
                    }
                }
                else if (cndtnWork.TransLend == 1)
                {
                    SqlText.AppendLine(" AND SL.ACPTANODRSTATUSRF = " + RentStatus);
                }
                
                // 赤伝区分
                SqlText.AppendLine(" AND SL.DEBITNOTEDIVRF = @FINDDEBITNOTEDIV");
                SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add("@FINDDEBITNOTEDIV", SqlDbType.Int);
                paraDebitNoteDiv.Value = SqlDataMediator.SqlSetInt32(Zero);
            }
            // 売上明細データ分のデータ抽出
            else
            {
                // 企業コード
                SqlText.AppendLine(" SD.ENTERPRISECODERF=@ENTERPRISECODE");
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.EnterpriseCode);

                // 論理削除区分
                SqlText.AppendLine(" AND SD.LOGICALDELETECODERF=@FINDLOGICALDELETECODE");
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);

                // 受注ステータス(元)
                SqlText.AppendLine(" AND SD.ACPTANODRSTATUSSRCRF = @FINDACPTANODRSTATUSSRC");
                SqlParameter paraAcptAnOdrStatusSrc = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUSSRC", SqlDbType.Int);
                paraAcptAnOdrStatusSrc.Value = SqlDataMediator.SqlSetInt32(RentStatus);

                // 受注ステータス
                SqlText.AppendLine(" AND SD.ACPTANODRSTATUSRF = @FINDACPTANODRSTATUS");
                SqlParameter paraAcptAnOdrStatus = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUS", SqlDbType.Int);
                paraAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(SalesStatus);

                // 売上日(開始)
                if (cndtnWork.St_SalesDate > DateTime.MinValue)
                {
                    SqlText.AppendLine(" AND SD.SALESDATERF >= @SALESDATEST ");
                    SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@SALESDATEST", SqlDbType.Int);
                    paraSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(cndtnWork.St_SalesDate);
                }
                // 売上日(終了)
                if (cndtnWork.Ed_SalesDate > DateTime.MinValue)
                {
                    SqlText.AppendLine(" AND SD.SALESDATERF <= @SALESDATEED ");
                    SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@SALESDATEED", SqlDbType.Int);
                    paraSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(cndtnWork.Ed_SalesDate);
                }
            }

            //商品番号
            if (!String.IsNullOrEmpty(cndtnWork.GoodsNo))
            {
                SqlText.AppendLine(" AND SD.GOODSNORF LIKE @GOODSNO");
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                //前方一致検索の場合
                if (cndtnWork.GoodsNoSrchTyp == 1) cndtnWork.GoodsNo = cndtnWork.GoodsNo + "%";
                //後方一致検索の場合
                if (cndtnWork.GoodsNoSrchTyp == 2) cndtnWork.GoodsNo = "%" + cndtnWork.GoodsNo;
                //あいまい検索の場合
                if (cndtnWork.GoodsNoSrchTyp == 3) cndtnWork.GoodsNo = "%" + cndtnWork.GoodsNo + "%";
                paraGoodsNo.Value = SqlDataMediator.SqlSetString(cndtnWork.GoodsNo);
            }

            // 商品メーカーコード
            if (cndtnWork.GoodsMakerCd > 0)
            {
                SqlText.AppendLine(" AND SD.GOODSMAKERCDRF=@FINDGOODSMAKERCD");
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(cndtnWork.GoodsMakerCd);
            }
            else 
            {
                SqlText.AppendLine(" AND SD.GOODSMAKERCDRF > " + Zero); 
            }

            // 取寄区分
            if (cndtnWork.OrderDivCd == 0)
            {
                if (!String.IsNullOrEmpty(cndtnWork.WarehouseCode))
                {
                    SqlText.AppendLine(" AND (SD.WAREHOUSECODERF=@FINDWAREHOUSECODE OR SD.WAREHOUSECODERF IS NULL)");
                    SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                    findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.WarehouseCode);
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(cndtnWork.WarehouseCode))
                {
                    SqlText.AppendLine(" AND SD.WAREHOUSECODERF=@FINDWAREHOUSECODE");
                    SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                    findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.WarehouseCode);
                }
                else
                {
                    SqlText.AppendLine(" AND SD.WAREHOUSECODERF IS NOT NULL ");
                }
            }

            return SqlText.ToString();
        }
        #endregion MakeWhereString

        #region 入出荷検品データの検索
        /// <summary>
        /// 入出荷検品データの検索
        /// </summary>
        /// <param name="retList">出力データ</param>
        /// <param name="cndtnWork">検索条件</param>
        /// <param name="tempTblName">売上一時テーブル名</param>
        /// <param name="tempDtlName">売上明細一時テーブル名</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 入出荷検品データの検索を行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private int SearchSalesProc(out ArrayList retList,
            HandyInspectParamWork cndtnWork, string tempTblName, string tempDtlName, out string errMessage, ref SqlConnection sqlConnection)
        {
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            errMessage = string.Empty;
            SqlCommand SqlCommandInfo = null;
            retList = new ArrayList();

            using (SqlCommandInfo = new SqlCommand("", sqlConnection))
            {
                try
                {
                    StringBuilder SqlText = new StringBuilder();
                    SqlText.AppendLine(SalesSqlText(cndtnWork, tempTblName, tempDtlName, ref SqlCommandInfo));
                    SqlCommandInfo.CommandText = SqlText.ToString();

                    // クエリ実行時のタイムアウト時間を3600秒に設定する
                    SqlCommandInfo.CommandTimeout = 3600;
                    using (SqlDataReader MyReader = SqlCommandInfo.ExecuteReader())
                    {
                        while (MyReader.Read())
                        {
                            // 検索結果の格納
                            retList.Add(CopyDataFromReader(MyReader, cndtnWork));

                            Status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }

                    if (retList.Count == 0)
                    {
                        // 検索結果なし場合、「NOT_FOUND」を戻す
                        Status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }

                }
                catch (SqlException ex)
                {
                    errMessage = ex.Message;
                    //基底クラスに例外を渡して処理してもらう
                    Status = base.WriteSQLErrorLog(ex);
                }
                catch (Exception ex)
                {
                    errMessage = ex.Message;
                    Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "HandyInspectRefDataDB.SearchSalesProc Exception=" + ex.Message, Status);
                }
            }

            return Status;
        }

        /// <summary>
        /// 入出荷検品データの検索
        /// </summary>
        /// <param name="cndtnWork">検索条件</param>
        /// <param name="tempTblName">売上一時テーブル名</param>
        /// <param name="tempDtlName">売上明細一時テーブル名</param>
        /// <param name="sqlCommand"></param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 入出荷検品データの検索を行う</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note : 2017/09/07 3H 張小磊</br>
        /// <br>　　　　　  : 11370074-00 出庫検品された貸出データを論理削除（≒返品）された場合、出庫検品データがJOINされる障害対応</br>
        /// </remarks>
        private string SalesSqlText(HandyInspectParamWork cndtnWork, string tempTblName, string tempDtlName, ref SqlCommand sqlCommand)
        {
            StringBuilder SqlText = new StringBuilder();

            SqlText.AppendLine(" SELECT ");
            SqlText.AppendLine(" SALES.SALESSLIPNUMRF ");   // 伝票番号
            SqlText.AppendLine(" ,SALES.SALESROWNORF");  // 行番号
            SqlText.AppendLine(" ,SALES.GOODSMAKERCDRF");         // 商品メーカーコード
            SqlText.AppendLine(" ,SALES.GOODSNORF");              // 商品番号
            SqlText.AppendLine(" ,SALES.MAKERNAMERF");          // メーカー名称
            SqlText.AppendLine(" ,SALES.GOODSNAMERF");          // 商品名称

            // 「入庫検品」の場合
            if (cndtnWork.Pattern == 1 && cndtnWork.TransLend == 1)
            {
                SqlText.AppendLine(" ,(CASE WHEN SALES.LOGICALDELETECODERF = 1 THEN DTL.SALESDATERF ELSE SALES.SHIPMENTDAYRF END) AS INPUTOUTDAYRF ");           //入出荷日
                SqlText.AppendLine(" ,(CASE WHEN SALES.LOGICALDELETECODERF = 1 THEN (SALES.SHIPMENTCNTRF- DTL.SHIPMENTCNTRF) ELSE SALES.SHIPMENTCNTRF*(-1) END) AS INPUTCNTRF ");           //入庫数
            }
            //「出庫検品」の場合
            else
            {
                SqlText.AppendLine(" ,SALES.SHIPMENTDAYRF AS INPUTOUTDAYRF ");           //入出荷日
                SqlText.AppendLine(" ,SALES.SHIPMENTCNTRF*(-1) AS INPUTCNTRF ");           //入庫数
            }
            SqlText.AppendLine(" ,SALES.SHIPMENTCNTRF AS SHIPMENTCNTRF ");           //出庫数
            SqlText.AppendLine(" ,SALES.CUSTOMERSNMRF  AS CUSTOMERSNM");          // 得意先略称
            SqlText.AppendLine(" ,SALES.WAREHOUSECODERF");              // 倉庫コード
            SqlText.AppendLine(" ,SALES.WAREHOUSENAMERF ");           // 倉庫名称
            SqlText.AppendLine(" ,SALES.WAREHOUSESHELFNORF");          // 倉庫棚番
            SqlText.AppendLine(" ,SALES.LOGICALDELETECODERF  ");    // 論理削除区分
            SqlText.AppendLine(" ,SALES.ACPTANODRSTATUSRF");          // 受注ステータス
            SqlText.AppendLine(" ,SALES.SALESSLIPCDDTLRF");          // 売上伝票区分（明細）
            SqlText.AppendLine(" ,I.ACPAYSLIPCDRF");          // 受払元伝票区分
            SqlText.AppendLine(" ,I.ACPAYTRANSCDRF");          // 受払元取引区分
            SqlText.AppendLine(" ,I.INSPECTSTATUSRF");          // 検品ステータス
            SqlText.AppendLine(" ,I.HANDTERMINALCODERF");          // ハンディターミナル区分
            SqlText.AppendLine(" ,I.INSPECTDATETIMERF ");   // 検品日時
            SqlText.AppendLine(" ,I.EMPLOYEECODERF ");   // 従業員コード

            SqlText.AppendLine(" FROM " + tempTblName + " AS SALES WITH (READUNCOMMITTED) ");
            // 「入庫検品」の場合
            if (cndtnWork.Pattern == 1 && cndtnWork.TransLend == 1)
            {
                SqlText.AppendLine(" LEFT JOIN " + tempDtlName + " AS DTL WITH (READUNCOMMITTED)");
                SqlText.AppendLine(" ON DTL.ENTERPRISECODERF = SALES.ENTERPRISECODERF");
                SqlText.AppendLine(" AND DTL.ACPTANODRSTATUSSRCRF = SALES.ACPTANODRSTATUSRF");
                SqlText.AppendLine(" AND DTL.SALESSLIPDTLNUMSRCRF = SALES.SALESSLIPDTLNUMRF");
            }
            SqlText.AppendLine(" LEFT JOIN INSPECTDATARF AS I WITH (READUNCOMMITTED)");
            SqlText.AppendLine(" ON SALES.ENTERPRISECODERF = I.ENTERPRISECODERF");
            SqlText.AppendLine(" AND SALES.SALESSLIPNUMRF = I.ACPAYSLIPNUMRF");
            SqlText.AppendLine(" AND SALES.SALESROWNORF = I.ACPAYSLIPROWNORF");
            SqlText.AppendLine(" AND ((SALES.ACPTANODRSTATUSRF = " + SalesStatus);
            SqlText.AppendLine(" AND I.ACPAYSLIPCDRF = " + SalesAcPaySlipCd + ")");
            SqlText.AppendLine(" OR (SALES.ACPTANODRSTATUSRF = " + RentStatus);
            // --- UPD 3H 張小磊 2017/09/07---------->>>>>
            //SqlText.AppendLine( " AND I.ACPAYSLIPCDRF = " + ShipmSlipCd + "))" );
            SqlText.AppendFormat( " AND I.ACPAYSLIPCDRF = {0}", HandyInspectRefDataDB.ShipmSlipCd );
            int acPayTransCd = 10; //通常伝票
            if (cndtnWork.Pattern == 1 && cndtnWork.TransLend == 1)
            {
                acPayTransCd = 11; //返品
            }
            SqlText.AppendFormat( " AND I.ACPAYTRANSCDRF = {0}", acPayTransCd );
            SqlText.AppendLine( " ))" );
            // --- UPD 3H 張小磊 2017/09/07---------->>>>>
            SqlText.AppendLine(" AND I.LOGICALDELETECODERF = " + (Int32)ConstantManagement.LogicalMode.GetData0);

            // WHERE文
            SqlText.AppendLine("WHERE ");

            // 企業コード
            SqlText.AppendLine(" SALES.ENTERPRISECODERF=@ENTERPRISECODE");

            // 従業員コード
            if (!String.IsNullOrEmpty(cndtnWork.EmployeeCode))
            {
                SqlText.AppendLine(" AND I.EMPLOYEECODERF = @FINDGEMPLOYEECODE");
            }
            // 検品日(開始)
            if (cndtnWork.St_InspectDate > DateTime.MinValue)
            {
                SqlText.AppendLine(" AND I.INSPECTDATETIMERF >= @INSPECTDATETIMEST ");
            }
            // 検品日(終了)
            if (cndtnWork.Ed_InspectDate > DateTime.MinValue)
            {
                if (cndtnWork.St_InspectDate == DateTime.MinValue)
                {
                    SqlText.AppendLine(" AND (I.INSPECTDATETIMERF < @INSPECTDATETIMEED OR I.INSPECTDATETIMERF IS NULL)");
                }
                else
                {
                    SqlText.AppendLine(" AND  I.INSPECTDATETIMERF < @INSPECTDATETIMEED ");
                }
            }
           
            // 出庫検品
            if (cndtnWork.Pattern ==0)
            {
                // 論理削除区分
                SqlText.AppendLine(" AND SALES.LOGICALDELETECODERF=@FINDLOGICALDELETECODE");
                SqlParameter ParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                ParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);

                // 入出荷日(開始)
                if (cndtnWork.St_SalesDate > DateTime.MinValue)
                {
                    SqlText.AppendLine(" AND SALES.SHIPMENTDAYRF >= @SHIPMENTDAYST ");
                }
                // 入出荷日(終了)
                if (cndtnWork.Ed_SalesDate > DateTime.MinValue)
                {
                    SqlText.AppendLine(" AND SALES.SHIPMENTDAYRF <= @SHIPMENTDAYED");
                }

                // 出荷数
                SqlText.AppendLine(" AND SALES.SHIPMENTCNTRF > @FINDSHIPMENTCNT");
                if (cndtnWork.TransSales == 1 && cndtnWork.TransLend == 1)
                {
                    // 受注ステータス
                    SqlText.AppendLine(" AND (SALES.ACPTANODRSTATUSRF = " + SalesStatus + " OR SALES.ACPTANODRSTATUSRF = " + RentStatus + " )");
                }
                else if (cndtnWork.TransSales == 1)
                { 
                    // 受注ステータス
                    SqlText.AppendLine(" AND SALES.ACPTANODRSTATUSRF = " + SalesStatus );
                }
                else if (cndtnWork.TransLend == 1)
                {
                    // 受注ステータス
                    SqlText.AppendLine(" AND SALES.ACPTANODRSTATUSRF = " + RentStatus);
                }
                // 売上伝票区分（明細）
                SqlText.AppendLine(" AND SALES.SALESSLIPCDDTLRF = @FINDSALESSLIPCDDTL" );
                SqlParameter ParaSalesSlipCdDtl = sqlCommand.Parameters.Add("@FINDSALESSLIPCDDTL", SqlDbType.Int);
                ParaSalesSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(SalesSlipCdDtl);
                // 受注ステータス(元)
                SqlText.AppendLine(" AND SALES.ACPTANODRSTATUSSRCRF <> @FINDACPTANODRSTATUSSRC");
                SqlParameter ParaAcptAnOdrStatusSrc = sqlCommand.Parameters.Add("@FINDACPTANODRSTATUSSRC", SqlDbType.Int);
                ParaAcptAnOdrStatusSrc.Value = SqlDataMediator.SqlSetInt32(RentStatus);
                SqlText.AppendLine("  ORDER BY INPUTOUTDAYRF, SALES.GOODSMAKERCDRF, SALES.GOODSNORF, SALES.SALESSLIPNUMRF, SALESROWNORF ASC");
            }
            // 入庫検品
            else if (cndtnWork.Pattern == 1)
            {
                // 論理削除区分
                SqlText.AppendLine(" AND SALES.LOGICALDELETECODERF=@FINDLOGICALDELETECODE");
                SqlParameter findParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                findParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);

                // 入出荷日(開始)
                if (cndtnWork.St_SalesDate > DateTime.MinValue)
                {
                    SqlText.AppendLine(" AND SALES.SHIPMENTDAYRF >= @SHIPMENTDAYST ");
                }
                // 入出荷日(終了)
                if (cndtnWork.Ed_SalesDate > DateTime.MinValue)
                {
                    SqlText.AppendLine(" AND SALES.SHIPMENTDAYRF <= @SHIPMENTDAYED");
                }
                // 出荷数
                SqlText.AppendLine(" AND SALES.SHIPMENTCNTRF*(-1) > @FINDSHIPMENTCNT");
                // 受注ステータス
                SqlText.AppendLine(" AND (SALES.ACPTANODRSTATUSRF = " + SalesStatus + " OR SALES.ACPTANODRSTATUSRF = " + RentStatus + " )");
                // 売上伝票区分（明細）
                SqlText.AppendLine(" AND SALES.SALESSLIPCDDTLRF = @FINDRETSLIPCDDTL");
                SqlParameter findParaRetSlipCdDtl = sqlCommand.Parameters.Add("@FINDRETSLIPCDDTL", SqlDbType.Int);
                findParaRetSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(RetSlipCdDtl);
                if (cndtnWork.TransLend == 1)
                {
                    SqlText.AppendLine("UNION ");
                    SqlText.AppendLine(" SELECT ");
                    SqlText.AppendLine(" SALES.SALESSLIPNUMRF ");   // 伝票番号
                    SqlText.AppendLine(" ,SALES.SALESROWNORF");  // 行番号
                    SqlText.AppendLine(" ,SALES.GOODSMAKERCDRF");         // 商品メーカーコード
                    SqlText.AppendLine(" ,SALES.GOODSNORF");              // 商品番号
                    SqlText.AppendLine(" ,SALES.MAKERNAMERF");          // メーカー名称
                    SqlText.AppendLine(" ,SALES.GOODSNAMERF");          // 商品名称
                    SqlText.AppendLine(" ,(CASE WHEN SALES.LOGICALDELETECODERF = 1 THEN DTL.SALESDATERF ELSE SALES.SHIPMENTDAYRF END) AS INPUTOUTDAYRF ");           //入出荷日
                    SqlText.AppendLine(" ,(CASE WHEN SALES.LOGICALDELETECODERF = 1 THEN (SALES.SHIPMENTCNTRF- DTL.SHIPMENTCNTRF) ELSE SALES.SHIPMENTCNTRF*(-1) END) AS INPUTCNTRF ");           //入庫数
                    SqlText.AppendLine(" ,SALES.SHIPMENTCNTRF ");           //出庫数
                    SqlText.AppendLine(" ,SALES.CUSTOMERSNMRF AS CUSTOMERSNM");          // 得意先略称
                    SqlText.AppendLine(" ,SALES.WAREHOUSECODERF");              // 倉庫コード
                    SqlText.AppendLine(" ,SALES.WAREHOUSENAMERF ");           // 倉庫名称
                    SqlText.AppendLine(" ,SALES.WAREHOUSESHELFNORF");          // 倉庫棚番
                    SqlText.AppendLine(" ,SALES.LOGICALDELETECODERF  ");    // 論理削除区分
                    SqlText.AppendLine(" ,SALES.ACPTANODRSTATUSRF");          // 受注ステータス
                    SqlText.AppendLine(" ,SALES.SALESSLIPCDDTLRF");          // 売上伝票区分（明細）
                    SqlText.AppendLine(" ,I.ACPAYSLIPCDRF");          // 受払元伝票区分
                    SqlText.AppendLine(" ,I.ACPAYTRANSCDRF");          // 受払元取引区分
                    SqlText.AppendLine(" ,I.INSPECTSTATUSRF");          // 検品ステータス
                    SqlText.AppendLine(" ,I.HANDTERMINALCODERF");          // ハンディターミナル区分
                    SqlText.AppendLine(" ,I.INSPECTDATETIMERF ");   // 検品日時
                    SqlText.AppendLine(" ,I.EMPLOYEECODERF ");   // 従業員コード
                    SqlText.AppendLine(" FROM " + tempTblName + " AS SALES WITH (READUNCOMMITTED) ");
                    SqlText.AppendLine(" LEFT JOIN " + tempDtlName + " AS DTL WITH (READUNCOMMITTED)");
                    SqlText.AppendLine(" ON DTL.ENTERPRISECODERF = SALES.ENTERPRISECODERF");
                    SqlText.AppendLine(" AND DTL.ACPTANODRSTATUSSRCRF = SALES.ACPTANODRSTATUSRF");
                    SqlText.AppendLine(" AND DTL.SALESSLIPDTLNUMSRCRF = SALES.SALESSLIPDTLNUMRF");
                    // 検品データ
                    SqlText.AppendLine(" LEFT JOIN INSPECTDATARF AS I WITH (READUNCOMMITTED)");
                    SqlText.AppendLine(" ON SALES.ENTERPRISECODERF = I.ENTERPRISECODERF");
                    SqlText.AppendLine(" AND SALES.SALESSLIPNUMRF = I.ACPAYSLIPNUMRF");
                    SqlText.AppendLine(" AND SALES.SALESROWNORF = I.ACPAYSLIPROWNORF");
                    SqlText.AppendLine(" AND ((SALES.ACPTANODRSTATUSRF = " + SalesStatus);
                    SqlText.AppendLine(" AND I.ACPAYSLIPCDRF = " + SalesAcPaySlipCd + ")");
                    SqlText.AppendLine(" OR (SALES.ACPTANODRSTATUSRF = " + RentStatus);
                    // --- UPD 3H 張小磊 2017/09/07---------->>>>>
                    //SqlText.AppendLine( " AND I.ACPAYSLIPCDRF = " + ShipmSlipCd + "))" );
                    SqlText.AppendFormat( " AND I.ACPAYSLIPCDRF = {0}", HandyInspectRefDataDB.ShipmSlipCd );
                    acPayTransCd = 11; //返品
                    SqlText.AppendFormat( " AND I.ACPAYTRANSCDRF = {0}", acPayTransCd );
                    SqlText.AppendLine( " ))" );
                    // --- UPD 3H 張小磊 2017/09/07---------->>>>>
                    SqlText.AppendLine( " AND I.LOGICALDELETECODERF = " + (Int32)ConstantManagement.LogicalMode.GetData0 );

                    // WHERE文
                    SqlText.AppendLine("WHERE ");
                    // 企業コード
                    SqlText.AppendLine(" SALES.ENTERPRISECODERF=@ENTERPRISECODE");

                    // 従業員コード
                    if (!String.IsNullOrEmpty(cndtnWork.EmployeeCode))
                    {
                        SqlText.AppendLine(" AND I.EMPLOYEECODERF = @FINDGEMPLOYEECODE");
                    }
                    // 検品日(開始)
                    if (cndtnWork.St_InspectDate > DateTime.MinValue)
                    {
                        SqlText.AppendLine(" AND I.INSPECTDATETIMERF >= @INSPECTDATETIMEST ");
                    }
                    // 検品日(終了)
                    if (cndtnWork.Ed_InspectDate > DateTime.MinValue)
                    {
                        if (cndtnWork.St_InspectDate == DateTime.MinValue)
                        {
                            SqlText.AppendLine(" AND (I.INSPECTDATETIMERF < @INSPECTDATETIMEED OR I.INSPECTDATETIMERF IS NULL)");
                        }
                        else
                        {
                            SqlText.AppendLine(" AND  I.INSPECTDATETIMERF < @INSPECTDATETIMEED ");
                        }
                    }
                    // 論理削除区分:1
                    SqlText.AppendLine(" AND SALES.LOGICALDELETECODERF=@FINDLOGICALDELETECD");
                    SqlParameter ParaLogicalDeleteCd = sqlCommand.Parameters.Add("@FINDLOGICALDELETECD", SqlDbType.Int);
                    ParaLogicalDeleteCd.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData1);

                    // 売上日(開始)
                    if (cndtnWork.St_SalesDate > DateTime.MinValue)
                    {
                        SqlText.AppendLine(" AND DTL.SALESDATERF >= @SHIPMENTDAYST ");
                    }
                    // 売上日(終了)
                    if (cndtnWork.Ed_SalesDate > DateTime.MinValue)
                    {
                        SqlText.AppendLine(" AND DTL.SALESDATERF <= @SHIPMENTDAYED");
                    }

                    // 受注ステータス
                    SqlText.AppendLine(" AND SALES.ACPTANODRSTATUSRF = @ACPTANODRSTATUS");
                    SqlParameter ParaAcptAnOdrStatus = sqlCommand.Parameters.Add("@ACPTANODRSTATUS", SqlDbType.Int);
                    ParaAcptAnOdrStatus.Value = SqlDataMediator.SqlSetInt32(RentStatus);
                    // 売上伝票区分（明細）
                    SqlText.AppendLine(" AND SALES.SALESSLIPCDDTLRF = @FINDSALESSLIPCDDTL");
                    SqlParameter ParaSalesSlipCdDtl = sqlCommand.Parameters.Add("@FINDSALESSLIPCDDTL", SqlDbType.Int);
                    ParaSalesSlipCdDtl.Value = SqlDataMediator.SqlSetInt32(SalesSlipCdDtl);

                    // 出荷数
                    SqlText.AppendLine(" AND (SALES.SHIPMENTCNTRF -DTL.SHIPMENTCNTRF) > @FINDSHIPMENTCNT");

                    // 貸出計上時に削除された貸出データ分の取得クエリの追加
                    SqlText.AppendLine( "" );
                    SqlText.AppendLine( "UNION " );
                    SqlText.AppendLine( this.CreateGetDelRentDataQuery( cndtnWork, ref sqlCommand ) );
                }
                SqlText.AppendLine("  ORDER BY INPUTOUTDAYRF, SALES.GOODSMAKERCDRF, SALES.GOODSNORF, SALES.SALESSLIPNUMRF, SALESROWNORF ASC");
                
            }

            // 企業コード
            SqlParameter ParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            ParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.EnterpriseCode);

            // 従業員コード
            if (!String.IsNullOrEmpty(cndtnWork.EmployeeCode))
            {
                SqlParameter ParaEmployeeCode = sqlCommand.Parameters.Add("@FINDGEMPLOYEECODE", SqlDbType.NChar);
                ParaEmployeeCode.Value = SqlDataMediator.SqlSetString(cndtnWork.EmployeeCode);
            }
            // 検品日(開始)
            if (cndtnWork.St_InspectDate > DateTime.MinValue)
            {
                SqlParameter ParaInspectDateTimeSt = sqlCommand.Parameters.Add("@INSPECTDATETIMEST", SqlDbType.BigInt);
                ParaInspectDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(cndtnWork.St_InspectDate);
            }
            // 検品日(終了)
            if (cndtnWork.Ed_InspectDate > DateTime.MinValue)
            {
                SqlParameter ParaInspectDateTimeEd = sqlCommand.Parameters.Add("@INSPECTDATETIMEED", SqlDbType.BigInt);
                ParaInspectDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(cndtnWork.Ed_InspectDate);
            }
           
            // 出荷数
            SqlParameter ParaShipmentCnt = sqlCommand.Parameters.Add("@FINDSHIPMENTCNT", SqlDbType.Float);
            ParaShipmentCnt.Value = SqlDataMediator.SqlSetDouble(Zero);

            // 入出荷日(開始)
            if (cndtnWork.St_SalesDate > DateTime.MinValue)
            {
                SqlParameter ParaShipmentDaySt = sqlCommand.Parameters.Add("@SHIPMENTDAYST", SqlDbType.Int);
                ParaShipmentDaySt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(cndtnWork.St_SalesDate);
            }
            // 入出荷日(終了)
            if (cndtnWork.Ed_SalesDate > DateTime.MinValue)
            {
                SqlParameter ParaShipmentDayEd = sqlCommand.Parameters.Add("@SHIPMENTDAYED", SqlDbType.Int);
                ParaShipmentDayEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(cndtnWork.Ed_SalesDate);
            }
            return SqlText.ToString();
        }

        /// <summary>
        /// 貸出計上時に削除された貸出データ分の取得クエリ文生成
        /// </summary>
        /// <param name="cndtnWork">検索条件</param>
        /// <param name="sqlCommand">パラメータセット先SQL実行コマンド格納クラス</param>
        /// <returns>貸出計上時に削除された貸出データ分の取得クエリ文</returns>
        /// <remarks>
        /// <br>Note       : 貸出計上時に削除された貸出データ分の取得クエリ文を生成</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note : 2017/09/07 3H 張小磊</br>
        /// <br>　　　　　  : 11370074-00 貸出計上されずに削除された貸出データを含める仕様変更対応</br>
        /// <br>　　　　　                出庫検品された貸出データを論理削除（≒返品）された場合、出庫検品データがJOINされる障害対応</br>
        /// </remarks>
        private string CreateGetDelRentDataQuery( HandyInspectParamWork cndtnWork, ref SqlCommand sqlCommand )
        {
            StringBuilder sqlTextStrings = new StringBuilder();

            #region SELECT句
            sqlTextStrings.AppendLine("SELECT ");
            sqlTextStrings.AppendLine("   RentSS.SALESSLIPNUMRF ");
            sqlTextStrings.AppendLine(" , RentSD.SALESROWNORF ");
            sqlTextStrings.AppendLine(" , RentSD.GOODSMAKERCDRF ");
            sqlTextStrings.AppendLine(" , RentSD.GOODSNORF ");
            sqlTextStrings.AppendLine(" , RentSD.MAKERNAMERF ");
            sqlTextStrings.AppendLine(" , RentSD.GOODSNAMERF ");
            sqlTextStrings.AppendLine(" , RentSS.SALESDTLSALESDATE AS INPUTOUTDAYRF --入庫日 ");
            sqlTextStrings.AppendLine(" , CASE ");
            sqlTextStrings.AppendLine("     WHEN SalesSD.SHIPMENTCNTRF is null THEN RentSD.SHIPMENTCNTRF ");
            sqlTextStrings.AppendLine("     ELSE                                    RentSD.SHIPMENTCNTRF - SalesSD.SHIPMENTCNTRF ");
            sqlTextStrings.AppendLine("   END AS INPUTCNTRF  --入庫数 ");
            sqlTextStrings.AppendLine(" , 0 AS SHIPMENTCNTRF --出庫数 ");
            sqlTextStrings.AppendLine(" , RentSS.CUSTOMERSNMRF AS CUSTOMERSNM ");
            sqlTextStrings.AppendLine(" , RentSD.WAREHOUSECODERF ");
            sqlTextStrings.AppendLine(" , RentSD.WAREHOUSENAMERF ");
            sqlTextStrings.AppendLine(" , RentSD.WAREHOUSESHELFNORF " );
            sqlTextStrings.AppendLine(" , RentSS.LOGICALDELETECODERF ");
            sqlTextStrings.AppendLine(" , RentSS.ACPTANODRSTATUSRF ");
            sqlTextStrings.AppendLine(" , RentSD.SALESSLIPCDDTLRF ");
            sqlTextStrings.AppendLine(" , InspDT.ACPAYSLIPCDRF      -- 検品データ 受払元伝票区分 ");
            sqlTextStrings.AppendLine(" , InspDT.ACPAYTRANSCDRF     -- 検品データ 受払元取引区分 ");
            sqlTextStrings.AppendLine(" , InspDT.INSPECTSTATUSRF    -- 検品データ 検品ステータス ");
            sqlTextStrings.AppendLine(" , InspDT.HANDTERMINALCODERF -- 検品データ ハンディターミナル区分 ");
            sqlTextStrings.AppendLine(" , InspDT.INSPECTDATETIMERF  -- 検品データ 検品日時 ");
            sqlTextStrings.AppendLine(" , InspDT.EMPLOYEECODERF     -- 検品データ 従業員コード ");
            #endregion //SELECT句

            #region FROM句

            #region 貸出計上時に計上されなかった削除済貸出データ
            sqlTextStrings.AppendLine("FROM ( ");
            CreateGetDelRentSlipQuery( cndtnWork, ref sqlTextStrings, ref sqlCommand, "    " );
            // --- ADD 3H 張小磊 2017/09/07---------->>>>>
            sqlTextStrings.AppendLine( "    UNION" );
            this.CreateGetLogicalDelRentSlipQuery( cndtnWork, ref sqlTextStrings, ref sqlCommand, "    " );
            // --- ADD 3H 張小磊 2017/09/07----------<<<<<
            sqlTextStrings.AppendLine( "	) AS RentSS " );
            #endregion //貸出計上時に計上されなかった削除済貸出データ
            
            #region 貸出計上時に計上されなかった分の削除済貸出明細データ
            sqlTextStrings.AppendLine("INNER JOIN SALESDETAILRF AS RentSD WITH (READUNCOMMITTED) ON ");
            sqlTextStrings.AppendLine("	        RentSS.ENTERPRISECODERF = RentSD.ENTERPRISECODERF ");
            sqlTextStrings.AppendLine("		AND RentSD.ACPTANODRSTATUSRF = RentSS.ACPTANODRSTATUSRF ");
            sqlTextStrings.AppendLine("		AND RentSS.SALESSLIPNUMRF = RentSD.SALESSLIPNUMRF ");
            sqlTextStrings.AppendLine("		AND	RentSD.LOGICALDELETECODERF = 1 ");
            #endregion //貸出計上時に計上されなかった分の削除済貸出明細データ
            
            #region 貸出計上時に計上された分の売上明細データ
            sqlTextStrings.AppendLine("LEFT JOIN SALESDETAILRF AS SalesSD WITH (READUNCOMMITTED) ON "); 
            sqlTextStrings.AppendLine("	        SalesSD.ENTERPRISECODERF = RentSD.ENTERPRISECODERF ");
            sqlTextStrings.AppendLine("	    AND SalesSD.ACPTANODRSTATUSRF = 30 ");
            sqlTextStrings.AppendLine("		AND SalesSD.SALESSLIPDTLNUMSRCRF = RentSD.SALESSLIPDTLNUMRF ");
            sqlTextStrings.AppendLine("		AND SalesSD.ACPTANODRSTATUSSRCRF = RentSD.ACPTANODRSTATUSRF ");
            sqlTextStrings.AppendLine("		AND SalesSD.LOGICALDELETECODERF = 0 ");
            #endregion //貸出計上時に計上された分の売上明細データ

            #region 検品データ
            sqlTextStrings.AppendLine("LEFT JOIN INSPECTDATARF AS InspDT WITH (READUNCOMMITTED) ON ");
            sqlTextStrings.AppendLine("	        InspDT.ENTERPRISECODERF = RentSS.ENTERPRISECODERF ");
            sqlTextStrings.AppendLine("	    AND InspDT.ACPAYSLIPNUMRF = RentSS.SALESSLIPNUMRF ");
            sqlTextStrings.AppendLine("	    AND InspDT.ACPAYSLIPROWNORF = RentSD.SALESROWNORF ");
            sqlTextStrings.AppendLine("	    AND RentSS.ACPTANODRSTATUSRF = RentSD.ACPTANODRSTATUSRF ");
            sqlTextStrings.AppendLine("		AND InspDT.ACPAYSLIPCDRF = 22 ");
            // --- ADD 3H 張小磊 2017/09/07---------->>>>>
            sqlTextStrings.AppendLine( "     AND InspDT.ACPAYTRANSCDRF = 11 " );
            // --- ADD 3H 張小磊 2017/09/07----------<<<<<
            sqlTextStrings.AppendLine( "     AND InspDT.LOGICALDELETECODERF = 0 " );
            #endregion //検品データ

            #endregion //FROM句

            #region WHERE句
            this.CreateGetDelRentDataWhere( cndtnWork, ref sqlTextStrings, ref sqlCommand, string.Empty );
            #endregion //WHERE句

            return sqlTextStrings.ToString();
        }

        /// <summary>
        /// 貸出計上時に計上されなかった削除済貸出データ取得条件文生成
        /// </summary>
        /// <param name="cndtnWork">検索条件</param>
        /// <param name="sqlTextStrings">生成条件文の格納先</param>
        /// <param name="sqlCommand">パラメータセット先SQL実行コマンド格納クラス</param>
        /// <param name="prefixString">各行のインデント文字列</param>
        /// <remarks>
        /// <br>Note       : 貸出計上時に計上されなかった削除済貸出データ取得条件文を生成し格納先へ格納する</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void CreateGetDelRentDataWhere( HandyInspectParamWork cndtnWork, ref StringBuilder sqlTextStrings, ref SqlCommand sqlCommand, string prefixString )
        {
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "WHERE  " );

            #region 企業コード
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "     RentSS.ENTERPRISECODERF = @ENTERPRISECODE " );
            #endregion //企業コード

            #region 受注ステータス
            //貸出データを取得するので40固定
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( " AND RentSS.ACPTANODRSTATUSRF = 40 " );
            #endregion //受注ステータス

            #region 売上伝票区分
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( " AND RentSD.SALESSLIPCDDTLRF = @FINDSALESSLIPCDDTL " );
            #endregion //売上伝票区分

            #region 検品対象数
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( " AND CASE " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "         WHEN SalesSD.SHIPMENTCNTRF IS NULL THEN RentSD.SHIPMENTCNTRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "         ELSE                                    RentSD.SHIPMENTCNTRF - SalesSD.SHIPMENTCNTRF  " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    END > @FINDSHIPMENTCNT" );
            sqlTextStrings.Append( prefixString );
            #endregion //検品対象数

            #region 貸出計上対象行判定
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( " AND SalesSD.ENTERPRISECODERF IS NULL " );
            #endregion //貸出計上対象行判定

            #region 入荷日
            //貸出計上売上データの売上日を入荷日として扱う
            if (cndtnWork.St_SalesDate > DateTime.MinValue)
            {
                sqlTextStrings.Append( prefixString );
                sqlTextStrings.AppendLine( "    AND RentSS.SALESDTLSALESDATE >= @SHIPMENTDAYST " );
            }
            if (cndtnWork.Ed_SalesDate > DateTime.MinValue)
            {
                sqlTextStrings.Append( prefixString );
                sqlTextStrings.AppendLine( "    AND RentSS.SALESDTLSALESDATE <= @SHIPMENTDAYED " );
            }
            #endregion //入荷日

            #region 実績計上拠点コード
            if (!String.IsNullOrEmpty( cndtnWork.SectionCode ) && !"00".Equals( cndtnWork.SectionCode ))
            {
                sqlTextStrings.Append( prefixString );
                sqlTextStrings.AppendLine( "    AND RentSS.RESULTSADDUPSECCDRF=@FINDSECTIONCODE" );
                SqlParameter findParaSectionCode = sqlCommand.Parameters.Add( "@FINDSECTIONCODE", SqlDbType.NChar );
                findParaSectionCode.Value = SqlDataMediator.SqlSetString( cndtnWork.SectionCode );
            }
            #endregion //実績計上拠点コード

            #region 商品番号
            if (!String.IsNullOrEmpty( cndtnWork.GoodsNo ))
            {
                sqlTextStrings.Append( prefixString );
                sqlTextStrings.AppendLine( "    AND RentSD.GOODSNORF LIKE @GOODSNO" );
                SqlParameter paraGoodsNo = sqlCommand.Parameters.Add( "@GOODSNO", SqlDbType.NChar );
                //前方一致検索の場合
                if (cndtnWork.GoodsNoSrchTyp == 1) cndtnWork.GoodsNo = cndtnWork.GoodsNo + "%";
                //後方一致検索の場合
                if (cndtnWork.GoodsNoSrchTyp == 2) cndtnWork.GoodsNo = "%" + cndtnWork.GoodsNo;
                //あいまい検索の場合
                if (cndtnWork.GoodsNoSrchTyp == 3) cndtnWork.GoodsNo = "%" + cndtnWork.GoodsNo + "%";
                paraGoodsNo.Value = SqlDataMediator.SqlSetString( cndtnWork.GoodsNo );
            }
            #endregion //商品番号

            #region 商品メーカーコード
            if (cndtnWork.GoodsMakerCd > 0)
            {
                sqlTextStrings.Append( prefixString );
                sqlTextStrings.AppendLine( "    AND RentSD.GOODSMAKERCDRF=@FINDGOODSMAKERCD" );
                SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add( "@FINDGOODSMAKERCD", SqlDbType.Int );
                findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32( cndtnWork.GoodsMakerCd );
            }
            else
            {
                sqlTextStrings.Append( prefixString );
                sqlTextStrings.AppendLine( "    AND RentSD.GOODSMAKERCDRF > 0 " );
            }
            #endregion //商品メーカーコード

            #region 倉庫コード
            if (!String.IsNullOrEmpty( cndtnWork.WarehouseCode ))
            {
                sqlTextStrings.Append( prefixString );
                sqlTextStrings.Append( "    AND (" );

                // 倉庫が指定されている場合、指定コードを条件に追加する
                sqlTextStrings.Append( "RentSD.WAREHOUSECODERF=@FINDWAREHOUSECODE " );
                SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add( "@FINDWAREHOUSECODE", SqlDbType.NChar );
                findParaWarehouseCode.Value = SqlDataMediator.SqlSetString( cndtnWork.WarehouseCode );

                if (cndtnWork.OrderDivCd == 0)
                {
                    // 倉庫が指定されており、かつ取寄を含む場合、倉庫コードがNULLのレコードも抽出される条件を追加する
                    sqlTextStrings.Append( "OR RentSD.WAREHOUSECODERF IS NULL" );
                }
                sqlTextStrings.AppendLine( " ) " );
            }
            else if (cndtnWork.OrderDivCd != 0)
            {
                // 倉庫が指定されておらず、かつ取寄を含まない場合、倉庫コードがNULLのレコードは抽出されない条件を追加する
                sqlTextStrings.Append( prefixString );
                sqlTextStrings.AppendLine( "    AND RentSD.WAREHOUSECODERF IS NOT NULL " );
            }
            #endregion //倉庫コード

            #region 検品担当者コード
            if (!String.IsNullOrEmpty( cndtnWork.EmployeeCode ))
            {
                sqlTextStrings.AppendLine( " AND InspDT.EMPLOYEECODERF = @FINDGEMPLOYEECODE " );
            }
            #endregion //検品担当者コード

            #region 検品日(開始)
            if (cndtnWork.St_InspectDate > DateTime.MinValue)
            {
                sqlTextStrings.AppendLine( " AND InspDT.INSPECTDATETIMERF >= @INSPECTDATETIMEST " );
            }
            #endregion //検品日(開始)

            #region 検品日(終了)
            if (cndtnWork.Ed_InspectDate > DateTime.MinValue)
            {
                if (cndtnWork.St_InspectDate == DateTime.MinValue)
                {
                    sqlTextStrings.AppendLine( " AND (InspDT.INSPECTDATETIMERF < @INSPECTDATETIMEED OR InspDT.INSPECTDATETIMERF IS NULL)" );
                }
                else
                {

                    sqlTextStrings.AppendLine( " AND InspDT.INSPECTDATETIMERF < @INSPECTDATETIMEED " );
                }
            }
            #endregion //検品日(終了)

        }

        /// <summary>
        /// 貸出計上時に計上されなかった削除済貸出データ取得クエリ生成
        /// </summary>
        /// <param name="cndtnWork">検索条件</param>
        /// <param name="sqlTextStrings">生成クエリの格納先</param>
        /// <param name="sqlCommand">パラメータセット先SQL実行コマンド格納クラス</param>
        /// <param name="prefixString">各行のインデント文字列</param>
        /// <remarks>
        /// <br>Note       : 貸出計上時に計上されなかった削除済貸出データ取得クエリを生成し格納先へ格納する</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void CreateGetDelRentSlipQuery( HandyInspectParamWork cndtnWork, ref StringBuilder sqlTextStrings, ref SqlCommand sqlCommand, string prefixString )
        {
            #region SELECT句
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "SELECT " );

            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "      SS.ENTERPRISECODERF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.ACPTANODRSTATUSRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.SALESSLIPNUMRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , SD.SALESDATERF AS SALESDTLSALESDATE --入庫日＝貸出計上の売上日 " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.CUSTOMERSNMRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.LOGICALDELETECODERF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.RESULTSADDUPSECCDRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "FROM SALESSLIPRF AS SS WITH (READUNCOMMITTED) " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "INNER JOIN SALESDETAILRF AS SD WITH (READUNCOMMITTED) ON " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "        SD.ENTERPRISECODERF = SS.ENTERPRISECODERF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND SD.ACPTANODRSTATUSRF = SS.ACPTANODRSTATUSRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND	SD.LOGICALDELETECODERF = 0  " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "INNER JOIN SALESDETAILRF AS RSD WITH (READUNCOMMITTED) ON " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "        RSD.ENTERPRISECODERF = SD.ENTERPRISECODERF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND RSD.ACPTANODRSTATUSRF = SD.ACPTANODRSTATUSSRCRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND RSD.SALESSLIPDTLNUMRF = SD.SALESSLIPDTLNUMSRCRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND	RSD.LOGICALDELETECODERF = 1  " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "INNER JOIN SALESSLIPRF AS RSS WITH (READUNCOMMITTED) ON " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "        RSS.ENTERPRISECODERF = RSD.ENTERPRISECODERF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND RSS.ACPTANODRSTATUSRF = RSD.ACPTANODRSTATUSRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND RSS.SALESSLIPNUMRF = RSD.SALESSLIPNUMRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND RSS.LOGICALDELETECODERF = RSD.LOGICALDELETECODERF " );
            #endregion //SELECT句

            #region WHERE句
            this.CreateGetDelRentSlipWhere( cndtnWork, ref sqlTextStrings, ref sqlCommand, prefixString );
            #endregion //WHERE句

            #region GROUP BY句
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "GROUP BY " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "      SS.ENTERPRISECODERF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.ACPTANODRSTATUSRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , SD.SALESDATERF  " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.LOGICALDELETECODERF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.SALESSLIPNUMRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.RESULTSADDUPSECCDRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.CUSTOMERSNMRF " );
            #endregion //GROUP BY句

        
        
        }

        /// <summary>
        /// 貸出計上時に計上されなかった削除済貸出データ取得条件文生成
        /// </summary>
        /// <param name="cndtnWork">検索条件</param>
        /// <param name="sqlTextStrings">生成条件文の格納先</param>
        /// <param name="sqlCommand">パラメータセット先SQL実行コマンド格納クラス</param>
        /// <param name="prefixString">各行のインデント文字列</param>
        /// <remarks>
        /// <br>Note       : 貸出計上時に計上されなかった削除済貸出データ取得条件文を生成し格納先へ格納する</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private void CreateGetDelRentSlipWhere( HandyInspectParamWork cndtnWork, ref StringBuilder sqlTextStrings, ref SqlCommand sqlCommand, string prefixString )
        {
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "WHERE  " );

            #region 企業コード
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "        SS.ENTERPRISECODERF = @ENTERPRISECODE " );
            #endregion //企業コード

            #region 論理削除区分
            //貸出計上済の売上データを取得するので、0固定
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND SS.LOGICALDELETECODERF = 0 " );
            #endregion //論理削除区分

            #region 受注ステータス
            //貸出計上済の売上データを取得するので、30固定
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND SS.ACPTANODRSTATUSRF = 30 " );
            #endregion //受注ステータス

            #region 入荷日
            //貸出計上売上データの売上日を入荷日として扱う
            if (cndtnWork.St_SalesDate > DateTime.MinValue)
            {
                sqlTextStrings.Append( prefixString );
                sqlTextStrings.AppendLine( "    AND SS.SALESDATERF >= @SHIPMENTDAYST " );
            }
            if (cndtnWork.Ed_SalesDate > DateTime.MinValue)
            {
                sqlTextStrings.Append( prefixString );
                sqlTextStrings.AppendLine( "    AND SS.SALESDATERF <= @SHIPMENTDAYED " );
            }
            #endregion //入荷日

            #region 赤伝区分
            //貸出計上済の売上データを取得するので、0固定
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "   AND SS.DEBITNOTEDIVRF = 0" );
            #endregion //赤伝区分
        }

        /// <summary>
        /// 貸出計上されずに論理削除された貸出データ取得クエリ生成
        /// </summary>
        /// <param name="cndtnWork">検索条件</param>
        /// <param name="sqlTextStrings">生成クエリの格納先</param>
        /// <param name="sqlCommand">パラメータセット先SQL実行コマンド格納クラス</param>
        /// <param name="prefixString">各行のインデント文字列</param>
        /// <remarks>
        /// <br>Note       : 貸出計上されずに論理削除された貸出データ取得クエリを生成し格納先へ格納する</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/09/07</br>
        /// </remarks>
        private void CreateGetLogicalDelRentSlipQuery( HandyInspectParamWork cndtnWork, ref StringBuilder sqlTextStrings, ref SqlCommand sqlCommand, string prefixString )
        {
            #region SELECT句
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "SELECT " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "      RSS.ENTERPRISECODERF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.ACPTANODRSTATUSRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.SALESSLIPNUMRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.SHIPMENTDAYRF AS SALESDTLSALESDATE --入庫日＝貸出の出庫日 " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.CUSTOMERSNMRF  " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.LOGICALDELETECODERF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.RESULTSADDUPSECCDRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "FROM SALESSLIPRF AS RSS WITH (READUNCOMMITTED) " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "INNER JOIN SALESDETAILRF AS RSD WITH (READUNCOMMITTED) ON " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "        RSS.ENTERPRISECODERF = RSD.ENTERPRISECODERF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND RSS.ACPTANODRSTATUSRF = RSD.ACPTANODRSTATUSRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND	RSS.SALESSLIPNUMRF = RSD.SALESSLIPNUMRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND RSD.SALESROWNORF > 0 " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND	RSD.ACPTANODRSTATUSSRCRF = 0 " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND	RSD.SALESSLIPDTLNUMSRCRF = 0 " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND	RSS.LOGICALDELETECODERF = RSD.LOGICALDELETECODERF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "LEFT JOIN SALESDETAILRF AS SD WITH (READUNCOMMITTED) ON " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "        SD.ENTERPRISECODERF = RSD.ENTERPRISECODERF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND SD.ACPTANODRSTATUSSRCRF = RSD.ACPTANODRSTATUSRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND SD.SALESSLIPDTLNUMSRCRF = RSD.SALESSLIPDTLNUMRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND SD.LOGICALDELETECODERF = 0 " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND SD.ACPTANODRSTATUSRF = 30 " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "LEFT JOIN SALESSLIPRF AS SS WITH (READUNCOMMITTED) ON " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "        SD.ENTERPRISECODERF = SS.ENTERPRISECODERF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND SD.SALESSLIPNUMRF = SS.SALESSLIPNUMRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND SD.ACPTANODRSTATUSRF = SS.ACPTANODRSTATUSRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND SD.LOGICALDELETECODERF = SS.LOGICALDELETECODERF " );
            #endregion //SELECT句

            #region WHERE句
            this.CreateGetLogicalDelRentSlipWhere( cndtnWork, ref sqlTextStrings, ref sqlCommand, prefixString );
            #endregion //WHERE句

            #region GROUP BY句
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "GROUP BY " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "      RSS.ENTERPRISECODERF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.SALESSLIPNUMRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.SHIPMENTDAYRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.CUSTOMERSNMRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.LOGICALDELETECODERF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.ACPTANODRSTATUSRF " );
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    , RSS.RESULTSADDUPSECCDRF " );	
            #endregion //GROUP BY句
        }

        /// <summary>
        /// 貸出計上されずに論理削除された貸出データ取得条件文生成
        /// </summary>
        /// <param name="cndtnWork">検索条件</param>
        /// <param name="sqlTextStrings">生成条件文の格納先</param>
        /// <param name="sqlCommand">パラメータセット先SQL実行コマンド格納クラス</param>
        /// <param name="prefixString">各行のインデント文字列</param>
        /// <remarks>
        /// <br>Note       : 貸出計上されずに論理削除された貸出データ取得条件文を生成し格納先へ格納する</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/09/07</br>
        /// </remarks>
        private void CreateGetLogicalDelRentSlipWhere( HandyInspectParamWork cndtnWork, ref StringBuilder sqlTextStrings, ref SqlCommand sqlCommand, string prefixString )
        {
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "WHERE  " );

            #region 企業コード
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "        RSS.ENTERPRISECODERF = @ENTERPRISECODE " );
            #endregion //企業コード

            #region 論理削除区分
            //論理削除済の貸出データを取得するので、1固定
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND RSS.LOGICALDELETECODERF = 1 " );
            #endregion //論理削除区分

            #region 受注ステータス
            //貸出データを取得するので、40固定
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND RSS.ACPTANODRSTATUSRF = 40 " );
            #endregion //受注ステータス

            #region 売上日
            // 計上されていない貸出データを取得するので、NULL固定
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "    AND RSS.SALESDATERF IS NULL  " );
            #endregion //売上日

            #region 入荷日
            //貸出データの出荷日を入荷日として扱う
            if (cndtnWork.St_SalesDate > DateTime.MinValue)
            {
                sqlTextStrings.Append( prefixString );
                sqlTextStrings.AppendLine( "    AND RSS.SHIPMENTDAYRF >= @SHIPMENTDAYST " );
            }
            if (cndtnWork.Ed_SalesDate > DateTime.MinValue)
            {
                sqlTextStrings.Append( prefixString );
                sqlTextStrings.AppendLine( "    AND RSS.SHIPMENTDAYRF <= @SHIPMENTDAYED " );
            }
            #endregion //入荷日

            #region 計上先売上データ企業コード
            //計上されていない貸出データを取得するので、NULL固定
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "   AND SS.ENTERPRISECODERF IS NULL " );
            #endregion //計上先売上データ企業コード

            #region 赤伝区分
            //論理削除された貸出データを取得するので、0固定
            sqlTextStrings.Append( prefixString );
            sqlTextStrings.AppendLine( "   AND RSS.DEBITNOTEDIVRF = 0" );
            #endregion //赤伝区分
        }

        /// <summary>
        /// 売上データの格納
        /// </summary>
        /// <param name="myReader">検索結果</param>
        /// <param name="cndtnWork">出力条件</param>
        /// <returns>出力データ</returns>
        /// <remarks>
        /// <br>Note       : 売上データの格納を行う。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note: 2017/09/07 3H 張小磊</br>
        /// <br>　　　　　 : 検品照会の変更対応</br>
        /// <br>Update Note: 2018/10/16 陳艶丹</br>
        /// <br>　　　　　 : ハンディターミナル五次対応</br>
        /// </remarks>
        private InspectRefDataWork CopyDataFromReader(SqlDataReader myReader, HandyInspectParamWork cndtnWork)
        {
            InspectRefDataWork ResultWork = new InspectRefDataWork();
            ResultWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
            if (cndtnWork.Pattern != 3)
            {
                ResultWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                ResultWork.SalesSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF"));
                ResultWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                ResultWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
                ResultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNM"));
            }
            // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
            else
            {
                // 検品のみの場合
                ResultWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ACPAYSLIPNUMRF"));
                ResultWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPROWNORF"));
            }
            // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
            ResultWork.ShipmentDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INPUTOUTDAYRF"));
            ResultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            ResultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            ResultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
            ResultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            ResultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            ResultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            ResultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            // 「入庫検品」の場合はゼロ固定
            if (cndtnWork.Pattern == 1)
            {
                ResultWork.ShipmentCnt = 0;
            }
            else
            {
                ResultWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
            }
            // 「出庫検品」の場合はゼロ固定
            if (cndtnWork.Pattern == 0)
            {
                ResultWork.InputCnt = 0;
            }
            else
            {
                ResultWork.InputCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("INPUTCNTRF"));
            }
            ResultWork.AcPaySlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPCDRF"));
            ResultWork.AcPayTransCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYTRANSCDRF"));
            ResultWork.InspectStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INSPECTSTATUSRF"));
            ResultWork.HandTerminalCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HANDTERMINALCODERF"));
            ResultWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
            ResultWork.InspectDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("INSPECTDATETIMERF"));
            // --- ADD 3H 張小磊 2017/09/07---------->>>>>
            // データソース区分 1:売上データ 2:仕入データ 3:在庫移動データ 4:在庫調整データ
            ResultWork.DataSourceDiv = 1;
            // --- ADD 3H 張小磊 2017/09/07----------<<<<<
            
            return ResultWork;
        }
        #endregion

        // --- ADD 3H 張小磊 2017/09/07---------->>>>>
        #region 仕入データの抽出処理
        /// <summary>
        /// 仕入データの抽出処理
        /// </summary>
        /// <param name="retList">抽出データ</param>
        /// <param name="cndtnWork">検索条件</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 仕入データを抽出処理します</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/09/07</br>
        /// </remarks>
        private int SearchStockSlipProc(out ArrayList retList,
            HandyInspectParamWork cndtnWork, out string errMessage, ref SqlConnection sqlConnection)
        {
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            errMessage = string.Empty;
            SqlCommand sqlCommand = null;
            retList = new ArrayList();

            using (sqlCommand = new SqlCommand("", sqlConnection))
            {
                try
                {
                    StringBuilder sqlText = new StringBuilder();

                    sqlText.AppendLine(" SELECT ");
                    sqlText.AppendLine("  STOCK.SUPPLIERSLIPNORF ");          // 仕入伝票番号
                    sqlText.AppendLine(" ,STOCK.STOCKROWNORF ");          // 仕入行番号
                    sqlText.AppendLine(" ,STOCK.ARRIVALGOODSDAYRF ");          // 入荷日
                    sqlText.AppendLine(" ,STOCK.GOODSMAKERCDRF ");          // 商品メーカーコード
                    sqlText.AppendLine(" ,STOCK.MAKERNAMERF ");          // 商品メーカー名
                    sqlText.AppendLine(" ,STOCK.GOODSNORF ");          // 商品番号
                    sqlText.AppendLine(" ,STOCK.GOODSNAMERF ");          // 商品名称
                    sqlText.AppendLine(" ,STOCK.STOCKCOUNTRF ");          // 仕入数
                    sqlText.AppendLine(" ,STOCK.SUPPLIERSNMRF ");          // 仕入先略称
                    sqlText.AppendLine(" ,STOCK.WAREHOUSECODERF ");          // 倉庫コード
                    sqlText.AppendLine(" ,STOCK.WAREHOUSENAMERF ");          // 倉庫名称
                    sqlText.AppendLine(" ,STOCK.WAREHOUSESHELFNORF ");          // 倉庫棚番
                    sqlText.AppendLine(" ,STOCK.SUPPLIERFORMALRF ");          // 仕入形式
                    sqlText.AppendLine(" ,STOCK.STOCKSLIPCDDTLRF ");          // 仕入伝票区分（明細）
                    sqlText.AppendLine(" ,I.ACPAYSLIPCDRF ");          // 受払元伝票区分
                    sqlText.AppendLine(" ,I.ACPAYTRANSCDRF ");          // 受払元取引区分
                    sqlText.AppendLine(" ,I.INSPECTSTATUSRF ");          // 検品ステータス
                    sqlText.AppendLine(" ,I.HANDTERMINALCODERF ");          // ハンディターミナル区分
                    sqlText.AppendLine(" ,I.INSPECTDATETIMERF ");          // 検品日時
                    sqlText.AppendLine(" ,I.EMPLOYEECODERF ");          // 従業員コード
                    sqlText.AppendLine(" FROM ");
                    sqlText.AppendLine(" (SELECT SL.ENTERPRISECODERF ");
                    sqlText.AppendLine(" ,SL.STOCKSECTIONCDRF ");
                    sqlText.AppendLine(" ,SD.SUPPLIERSLIPNORF ");
                    sqlText.AppendLine(" ,SD.STOCKROWNORF ");
                    sqlText.AppendLine(" ,SD.GOODSMAKERCDRF ");
                    sqlText.AppendLine(" ,SD.MAKERNAMERF ");
                    sqlText.AppendLine(" ,SD.GOODSNORF ");
                    sqlText.AppendLine(" ,SD.GOODSNAMERF ");
                    // パターンが「出庫検品」の場合
                    if (cndtnWork.Pattern == 0)
                    {
                        sqlText.AppendLine(" ,SD.STOCKCOUNTRF *(-1) AS STOCKCOUNTRF ");
                    }
                    // パターンが「入庫検品」OR「未入庫」の場合
                    else
                    {
                        sqlText.AppendLine(" ,SD.STOCKCOUNTRF ");
                    }
                    sqlText.AppendLine(" ,SL.SUPPLIERSNMRF ");
                    sqlText.AppendLine(" ,SD.WAREHOUSECODERF ");
                    sqlText.AppendLine(" ,SD.WAREHOUSENAMERF ");
                    sqlText.AppendLine(" ,SD.WAREHOUSESHELFNORF ");
                    sqlText.AppendLine(" ,SL.ARRIVALGOODSDAYRF ");
                    sqlText.AppendLine(" ,SD.SUPPLIERFORMALRF ");
                    sqlText.AppendLine(" ,SD.STOCKSLIPCDDTLRF ");
                    sqlText.AppendLine("FROM STOCKSLIPRF AS SL WITH (READUNCOMMITTED) ");
                    sqlText.AppendLine("INNER JOIN STOCKDETAILRF AS SD WITH (READUNCOMMITTED) ");
                    sqlText.AppendLine("ON SD.ENTERPRISECODERF=SL.ENTERPRISECODERF ");
                    sqlText.AppendLine("AND SD.SUPPLIERSLIPNORF =SL.SUPPLIERSLIPNORF ");
                    sqlText.AppendLine("AND SD.SUPPLIERFORMALRF =SL.SUPPLIERFORMALRF ");
                    // WHERE文
                    sqlText.AppendLine("WHERE ");

                    // 企業コード
                    sqlText.AppendLine(" SL.ENTERPRISECODERF=@FINDENTERPRISECODE ");
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.EnterpriseCode);

                    // 論理削除区分「0:有効」固定
                    sqlText.AppendLine(" AND SD.LOGICALDELETECODERF = 0 ");

                    //拠点コード
                    if (!String.IsNullOrEmpty(cndtnWork.SectionCode) && !"00".Equals(cndtnWork.SectionCode))
                    {
                        sqlText.AppendLine(" AND SL.STOCKSECTIONCDRF=@FINDSTOCKSECTIONCDRF ");
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSTOCKSECTIONCDRF", SqlDbType.NChar);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(cndtnWork.SectionCode);
                    }

                    // 赤伝区分 0:黒伝
                    sqlText.AppendLine(" AND SL.DEBITNOTEDIVRF=0 ");

                    // パターンが「出庫検品」の場合
                    if (cndtnWork.Pattern == 0)
                    {
                        // 仕入形式 0：仕入
                        sqlText.AppendLine(" AND SL.SUPPLIERFORMALRF=0 ");
                        // 仕入伝票区分（明細）1:返品
                        sqlText.AppendLine(" AND SD.STOCKSLIPCDDTLRF=1 ");
                    }
                    // パターンが「入庫検品」の場合
                    else if (cndtnWork.Pattern == 1)
                    {
                        // 仕入形式 0：仕入
                        sqlText.AppendLine(" AND SL.SUPPLIERFORMALRF=0 ");
                        // 仕入伝票区分（明細）0:仕入
                        sqlText.AppendLine(" AND SD.STOCKSLIPCDDTLRF=0 ");
                    }
                    // パターンが「未入庫」の場合
                    else if (cndtnWork.Pattern == 2)
                    {
                        // 仕入形式 1：入荷
                        sqlText.AppendLine(" AND SL.SUPPLIERFORMALRF=1 ");
                        // 仕入伝票区分（明細）0:仕入
                        sqlText.AppendLine(" AND SD.STOCKSLIPCDDTLRF=0 ");
                    }

                    // 取寄区分「0:含む」
                    if (cndtnWork.OrderDivCd == 0)
                    {
                        // 倉庫コード
                        if (!String.IsNullOrEmpty(cndtnWork.WarehouseCode))
                        {
                            sqlText.AppendLine(" AND (SD.WAREHOUSECODERF=@FINDWAREHOUSECODE OR SD.WAREHOUSECODERF IS NULL)");
                            SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                            findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.WarehouseCode);
                        }
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(cndtnWork.WarehouseCode))
                        {
                            sqlText.AppendLine(" AND SD.WAREHOUSECODERF=@FINDWAREHOUSECODE");
                            SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                            findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.WarehouseCode);
                        }
                        else
                        {
                            sqlText.AppendLine(" AND SD.WAREHOUSECODERF IS NOT NULL ");
                        }
                    }

                    // 入出荷日(開始)
                    if (cndtnWork.St_SalesDate > DateTime.MinValue)
                    {
                        sqlText.AppendLine(" AND SL.ARRIVALGOODSDAYRF >= @SALESDATEST ");
                        SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@SALESDATEST", SqlDbType.Int);
                        paraSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(cndtnWork.St_SalesDate);
                    }

                    // 入出荷日(終了)
                    if (cndtnWork.Ed_SalesDate > DateTime.MinValue)
                    {
                        sqlText.AppendLine(" AND SL.ARRIVALGOODSDAYRF <= @SALESDATEED ");
                        SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@SALESDATEED", SqlDbType.Int);
                        paraSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(cndtnWork.Ed_SalesDate);
                    }

                    // 商品メーカーコード
                    if (cndtnWork.GoodsMakerCd > 0)
                    {
                        sqlText.AppendLine(" AND SD.GOODSMAKERCDRF=@FINDGOODSMAKERCD");
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(cndtnWork.GoodsMakerCd);
                    }
                    else
                    {
                        sqlText.AppendLine(" AND SD.GOODSMAKERCDRF > " + Zero);
                    }

                    //商品番号
                    if (!String.IsNullOrEmpty(cndtnWork.GoodsNo))
                    {
                        sqlText.AppendLine(" AND SD.GOODSNORF LIKE @FINDGOODSNO");
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);
                        //前方一致検索の場合
                        if (cndtnWork.GoodsNoSrchTyp == 1) cndtnWork.GoodsNo = cndtnWork.GoodsNo + "%";
                        //後方一致検索の場合
                        if (cndtnWork.GoodsNoSrchTyp == 2) cndtnWork.GoodsNo = "%" + cndtnWork.GoodsNo;
                        //あいまい検索の場合
                        if (cndtnWork.GoodsNoSrchTyp == 3) cndtnWork.GoodsNo = "%" + cndtnWork.GoodsNo + "%";
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(cndtnWork.GoodsNo);
                    }

                    sqlText.AppendLine(" ) AS STOCK ");
                    sqlText.AppendLine(" LEFT JOIN INSPECTDATARF AS I WITH (READUNCOMMITTED) ");
                    sqlText.AppendLine(" ON STOCK.ENTERPRISECODERF = I.ENTERPRISECODERF ");
                    sqlText.AppendLine(" AND STOCK.SUPPLIERSLIPNORF = I.ACPAYSLIPNUMRF ");
                    sqlText.AppendLine(" AND STOCK.STOCKROWNORF = I.ACPAYSLIPROWNORF ");
                    // 仕入明細データ.仕入形式＝0：仕入　AND　検品データ.受払元伝票区分＝10：仕入
                    sqlText.AppendLine(" AND (STOCK.SUPPLIERFORMALRF = 0 AND I.ACPAYSLIPCDRF =10) ");
                    // 論理削除区分＝0
                    sqlText.AppendLine(" AND I.LOGICALDELETECODERF = 0 ");

                    // 仕入数
                    sqlText.AppendLine(" WHERE STOCK.STOCKCOUNTRF>0 ");

                    // 従業員コード
                    if (!String.IsNullOrEmpty(cndtnWork.EmployeeCode))
                    {
                        sqlText.AppendLine(" AND I.EMPLOYEECODERF =@FINDEMPLOYEECODE ");
                        SqlParameter ParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                        ParaEmployeeCode.Value = SqlDataMediator.SqlSetString(cndtnWork.EmployeeCode);
                    }

                    // 検品日(開始)
                    if (cndtnWork.St_InspectDate > DateTime.MinValue)
                    {
                        sqlText.AppendLine(" AND I.INSPECTDATETIMERF >= @INSPECTDATETIMEST ");
                        SqlParameter ParaInspectDateTimeSt = sqlCommand.Parameters.Add("@INSPECTDATETIMEST", SqlDbType.BigInt);
                        ParaInspectDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(cndtnWork.St_InspectDate);
                    }

                    // 検品日(終了)
                    if (cndtnWork.Ed_InspectDate > DateTime.MinValue)
                    {
                        if (cndtnWork.St_InspectDate == DateTime.MinValue)
                        {
                            sqlText.AppendLine(" AND (I.INSPECTDATETIMERF < @INSPECTDATETIMEED OR I.INSPECTDATETIMERF IS NULL)");
                        }
                        else
                        {
                            sqlText.AppendLine(" AND  I.INSPECTDATETIMERF < @INSPECTDATETIMEED ");
                        }
                        SqlParameter ParaInspectDateTimeEd = sqlCommand.Parameters.Add("@INSPECTDATETIMEED", SqlDbType.BigInt);
                        ParaInspectDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(cndtnWork.Ed_InspectDate);
                    }

                    sqlText.AppendLine(" ORDER BY ");
                    sqlText.AppendLine("  STOCK.ARRIVALGOODSDAYRF ");
                    sqlText.AppendLine(" ,STOCK.GOODSMAKERCDRF ");
                    sqlText.AppendLine(" ,STOCK.GOODSNORF ");
                    sqlText.AppendLine(" ,STOCK.SUPPLIERSLIPNORF ");
                    sqlText.AppendLine(" ,STOCK.STOCKROWNORF ");

                    sqlCommand.CommandText = sqlText.ToString();

                    // クエリ実行時のタイムアウト時間を3600秒に設定する
                    sqlCommand.CommandTimeout = 3600;
                    using (SqlDataReader MyReader = sqlCommand.ExecuteReader())
                    {
                        while (MyReader.Read())
                        {
                            // 検索結果仕入データの格納
                            retList.Add(CopyStockSlipDataFromReader(MyReader, cndtnWork));
                        }
                    }
                    if (retList != null && retList.Count > 0)
                    {
                        // 検索結果あり場合、「ctDB_NORMAL」を戻す
                        Status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        // 検索結果なし場合、「NOT_FOUND」を戻す
                        Status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }

                }
                catch (SqlException ex)
                {
                    errMessage = ex.Message;
                    //基底クラスに例外を渡して処理してもらう
                    Status = base.WriteSQLErrorLog(ex);
                }
                catch (Exception ex)
                {
                    errMessage = ex.Message;
                    Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "HandyInspectRefDataDB.SearchStockSlipProc Exception=" + ex.Message, Status);
                }
            }

            return Status;
        }

        /// <summary>
        /// 仕入データの格納
        /// </summary>
        /// <param name="myReader">検索結果</param>
        /// <param name="cndtnWork">検索条件</param>
        /// <returns>検品照会抽出結果</returns>
        /// <remarks>
        /// <br>Note       : 仕入データの格納を行う。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/09/07</br>
        /// <br>Update Note: 2017/10/13 3H 張小磊</br>
        /// <br>　　　　　 : 検品照会の変更対応</br>
        /// </remarks>
        private InspectRefDataWork CopyStockSlipDataFromReader(SqlDataReader myReader, HandyInspectParamWork cndtnWork)
        {
            InspectRefDataWork resultWork = new InspectRefDataWork();
            // 伝票番号
            resultWork.SalesSlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF")).ToString();
            // 行番号
            resultWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNORF"));
            // 入出荷日
            resultWork.ShipmentDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
            // 商品番号
            resultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            // 商品名称
            resultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            // 商品メーカーコード
            resultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            // メーカー名称
            resultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));

            // パターンが「出庫検品」の場合
            if (cndtnWork.Pattern == 0)
            {
                // 入庫数:ゼロ固定
                resultWork.InputCnt = 0;
            }
            // パターンが「入庫検品」OR「未入庫」の場合
            else
            {
                // 入庫数:仕入数
                resultWork.InputCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
            }

            // パターンが「出庫検品」の場合
            if (cndtnWork.Pattern == 0)
            {
                // 出庫数:仕入数
                resultWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
            }
            // パターンが「入庫検品」OR「未入庫」の場合
            else
            {
                // 出庫数:ゼロ固定
                resultWork.ShipmentCnt = 0;
            }

            // 取引先名称
            resultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
            // 倉庫コード
            resultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            // 倉庫名称
            resultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            // 倉庫棚番
            resultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            // 仕入形式
            resultWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
            // 仕入伝票区分（明細）
            resultWork.StockSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCDDTLRF"));
            // 受払元伝票区分
            resultWork.AcPaySlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPCDRF"));
            // 受払元取引区分
            resultWork.AcPayTransCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYTRANSCDRF"));
            // 検品担当者コード
            resultWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
            // 検品日時
            resultWork.InspectDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("INSPECTDATETIMERF"));
            // 検品ステータス
            resultWork.InspectStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INSPECTSTATUSRF"));
            // ハンディターミナル区分
            resultWork.HandTerminalCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HANDTERMINALCODERF"));
            // データソース区分 1:売上データ 2:仕入データ 3:在庫移動データ 4:在庫調整データ
            resultWork.DataSourceDiv = 2;

            return resultWork;
        }
        #endregion

        #region 在庫移動データの抽出処理
        /// <summary>
        /// 在庫移動データの抽出処理
        /// </summary>
        /// <param name="retList">抽出データ</param>
        /// <param name="cndtnWork">検索条件</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 在庫移動データを抽出処理します</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/09/07</br>
        /// </remarks>
        private int SearchStockMoveProc(out ArrayList retList,
            HandyInspectParamWork cndtnWork, out string errMessage, ref SqlConnection sqlConnection)
        {
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            errMessage = string.Empty;
            SqlCommand sqlCommand = null;
            retList = new ArrayList();

            using (sqlCommand = new SqlCommand("", sqlConnection))
            {
                try
                {
                    StringBuilder sqlText = new StringBuilder();

                    sqlText.AppendLine(" SELECT ");
                    sqlText.AppendLine("  SM.STOCKMOVESLIPNORF ");          // 在庫移動伝票番号
                    sqlText.AppendLine(" ,SM.STOCKMOVEROWNORF ");          // 在庫移動行番号

                    sqlText.AppendLine(" ,SM.SHIPMENTFIXDAYRF ");          // 出荷確定日
                    sqlText.AppendLine(" ,SM.ARRIVALGOODSDAYRF ");          // 入荷日

                    sqlText.AppendLine(" ,SM.GOODSMAKERCDRF ");          // 商品メーカーコード
                    sqlText.AppendLine(" ,SM.MAKERNAMERF ");          // 商品メーカー名
                    sqlText.AppendLine(" ,SM.GOODSNORF ");          // 商品番号
                    sqlText.AppendLine(" ,SM.GOODSNAMERF ");          // 商品名称
                    sqlText.AppendLine(" ,SM.MOVECOUNTRF ");          // 移動数

                    sqlText.AppendLine(" ,SM.AFSECTIONGUIDESNMRF ");          // 移動先拠点ガイド略称
                    sqlText.AppendLine(" ,SM.BFSECTIONGUIDESNMRF ");          // 移動元拠点ガイド略称

                    sqlText.AppendLine(" ,SM.BFENTERWAREHCODERF ");          // 移動元倉庫コード
                    sqlText.AppendLine(" ,SM.BFENTERWAREHNAMERF ");          // 移動元倉庫名称
                    sqlText.AppendLine(" ,SM.AFENTERWAREHCODERF ");          // 移動先倉庫コード
                    sqlText.AppendLine(" ,SM.AFENTERWAREHNAMERF ");          // 移動先倉庫名称

                    sqlText.AppendLine(" ,SM.BFSHELFNORF ");          // 移動元棚番
                    sqlText.AppendLine(" ,SM.AFSHELFNORF ");          // 移動先棚番


                    sqlText.AppendLine(" ,SM.STOCKMOVEFORMALRF ");          // 在庫移動形式
                    sqlText.AppendLine(" ,I.ACPAYSLIPCDRF ");          // 受払元伝票区分
                    sqlText.AppendLine(" ,I.ACPAYTRANSCDRF ");          // 受払元取引区分
                    sqlText.AppendLine(" ,I.INSPECTSTATUSRF ");          // 検品ステータス
                    sqlText.AppendLine(" ,I.HANDTERMINALCODERF ");          // ハンディターミナル区分
                    sqlText.AppendLine(" ,I.INSPECTDATETIMERF ");          // 検品日時
                    sqlText.AppendLine(" ,I.EMPLOYEECODERF ");          // 従業員コード
                    sqlText.AppendLine(" FROM ");
                    sqlText.AppendLine(" (SELECT ENTERPRISECODERF ");

                    sqlText.AppendLine(" ,BFSECTIONCODERF ");
                    sqlText.AppendLine(" ,AFSECTIONCODERF ");

                    sqlText.AppendLine(" ,STOCKMOVESLIPNORF ");
                    sqlText.AppendLine(" ,STOCKMOVEROWNORF ");
                    sqlText.AppendLine(" ,GOODSMAKERCDRF ");
                    sqlText.AppendLine(" ,MAKERNAMERF ");
                    sqlText.AppendLine(" ,GOODSNORF ");
                    sqlText.AppendLine(" ,GOODSNAMERF ");
                    sqlText.AppendLine(" ,MOVECOUNTRF ");

                    sqlText.AppendLine(" ,AFSECTIONGUIDESNMRF ");
                    sqlText.AppendLine(" ,BFSECTIONGUIDESNMRF ");

                    sqlText.AppendLine(" ,BFENTERWAREHCODERF ");
                    sqlText.AppendLine(" ,BFENTERWAREHNAMERF ");
                    sqlText.AppendLine(" ,AFENTERWAREHCODERF ");
                    sqlText.AppendLine(" ,AFENTERWAREHNAMERF ");

                    sqlText.AppendLine(" ,AFSHELFNORF ");
                    sqlText.AppendLine(" ,ARRIVALGOODSDAYRF ");

                    sqlText.AppendLine(" ,BFSHELFNORF ");
                    sqlText.AppendLine(" ,SHIPMENTFIXDAYRF ");

                    sqlText.AppendLine(" ,STOCKMOVEFORMALRF ");
                    sqlText.AppendLine("FROM STOCKMOVERF  WITH (READUNCOMMITTED) ");
                    // WHERE文
                    sqlText.AppendLine("WHERE ");

                    // 企業コード
                    sqlText.AppendLine(" STOCKMOVERF.ENTERPRISECODERF=@FINDENTERPRISECODE ");
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.EnterpriseCode);

                    // 論理削除区分「0:有効」固定
                    sqlText.AppendLine(" AND STOCKMOVERF.LOGICALDELETECODERF = 0 ");

                    // パターンが「出庫検品」の場合
                    if (cndtnWork.Pattern == 0)
                    {
                        // 拠点コード
                        if (!String.IsNullOrEmpty(cndtnWork.SectionCode) && !"00".Equals(cndtnWork.SectionCode))
                        {
                            sqlText.AppendLine(" AND STOCKMOVERF.BFSECTIONCODERF=@FINDSTOCKSECTIONCDRF ");
                        }
                        // 移動形式 1:在庫出庫 OR 2：倉庫出庫
                        sqlText.AppendLine(" AND STOCKMOVERF.STOCKMOVEFORMALRF IN(1,2) ");
                        // 倉庫コード
                        if (!String.IsNullOrEmpty(cndtnWork.WarehouseCode))
                        {
                            sqlText.AppendLine(" AND STOCKMOVERF.BFENTERWAREHCODERF=@FINDWAREHOUSECODE ");
                        }
                        // 入出荷日(開始)
                        if (cndtnWork.St_SalesDate > DateTime.MinValue)
                        {
                            sqlText.AppendLine(" AND STOCKMOVERF.SHIPMENTFIXDAYRF >= @SALESDATEST ");
                        }
                        // 入出荷日(終了)
                        if (cndtnWork.Ed_SalesDate > DateTime.MinValue)
                        {
                            sqlText.AppendLine(" AND STOCKMOVERF.SHIPMENTFIXDAYRF <= @SALESDATEED ");
                        }
                    }
                    // パターンが「入庫検品」の場合
                    else
                    {
                        // 拠点コード
                        if (!String.IsNullOrEmpty(cndtnWork.SectionCode) && !"00".Equals(cndtnWork.SectionCode))
                        {
                            sqlText.AppendLine(" AND STOCKMOVERF.AFSECTIONCODERF=@FINDSTOCKSECTIONCDRF ");
                        }
                        // 移動形式 3:在庫入庫 OR 4：倉庫出庫
                        sqlText.AppendLine(" AND STOCKMOVERF.STOCKMOVEFORMALRF IN(3,4) ");
                        // 倉庫コード
                        if (!String.IsNullOrEmpty(cndtnWork.WarehouseCode))
                        {
                            sqlText.AppendLine(" AND STOCKMOVERF.AFENTERWAREHCODERF=@FINDWAREHOUSECODE ");
                        }
                        // 入出荷日(開始)
                        if (cndtnWork.St_SalesDate > DateTime.MinValue)
                        {
                            sqlText.AppendLine(" AND STOCKMOVERF.ARRIVALGOODSDAYRF >= @SALESDATEST ");
                        }
                        // 入出荷日(終了)
                        if (cndtnWork.Ed_SalesDate > DateTime.MinValue)
                        {
                            sqlText.AppendLine(" AND STOCKMOVERF.ARRIVALGOODSDAYRF <= @SALESDATEED ");
                        }
                    }

                    //拠点コード
                    if (!String.IsNullOrEmpty(cndtnWork.SectionCode) && !"00".Equals(cndtnWork.SectionCode))
                    {
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSTOCKSECTIONCDRF", SqlDbType.NChar);
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString(cndtnWork.SectionCode);
                    }

                    // 倉庫コード
                    if (!String.IsNullOrEmpty(cndtnWork.WarehouseCode))
                    {
                        SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                        findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.WarehouseCode);
                    }

                    // 入出荷日(開始)
                    if (cndtnWork.St_SalesDate > DateTime.MinValue)
                    {
                        SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add("@SALESDATEST", SqlDbType.Int);
                        paraSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(cndtnWork.St_SalesDate);
                    }

                    // 入出荷日(終了)
                    if (cndtnWork.Ed_SalesDate > DateTime.MinValue)
                    {
                        SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add("@SALESDATEED", SqlDbType.Int);
                        paraSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(cndtnWork.Ed_SalesDate);
                    }

                    // 商品メーカーコード
                    if (cndtnWork.GoodsMakerCd > 0)
                    {
                        sqlText.AppendLine(" AND STOCKMOVERF.GOODSMAKERCDRF=@FINDGOODSMAKERCD");
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(cndtnWork.GoodsMakerCd);
                    }
                    else
                    {
                        sqlText.AppendLine(" AND STOCKMOVERF.GOODSMAKERCDRF > " + Zero);
                    }

                    //商品番号
                    if (!String.IsNullOrEmpty(cndtnWork.GoodsNo))
                    {
                        sqlText.AppendLine(" AND STOCKMOVERF.GOODSNORF LIKE @FINDGOODSNO");
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);
                        //前方一致検索の場合
                        if (cndtnWork.GoodsNoSrchTyp == 1) cndtnWork.GoodsNo = cndtnWork.GoodsNo + "%";
                        //後方一致検索の場合
                        if (cndtnWork.GoodsNoSrchTyp == 2) cndtnWork.GoodsNo = "%" + cndtnWork.GoodsNo;
                        //あいまい検索の場合
                        if (cndtnWork.GoodsNoSrchTyp == 3) cndtnWork.GoodsNo = "%" + cndtnWork.GoodsNo + "%";
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(cndtnWork.GoodsNo);
                    }

                    sqlText.AppendLine(" ) AS SM ");
                    sqlText.AppendLine(" LEFT JOIN INSPECTDATARF AS I WITH (READUNCOMMITTED) ");
                    sqlText.AppendLine(" ON SM.ENTERPRISECODERF = I.ENTERPRISECODERF ");
                    sqlText.AppendLine(" AND SM.STOCKMOVESLIPNORF = I.ACPAYSLIPNUMRF ");
                    sqlText.AppendLine(" AND SM.STOCKMOVEROWNORF = I.ACPAYSLIPROWNORF ");
                    // 在庫移動データ.在庫移動形式 IN (1:在庫出庫,2:倉庫出庫) AND 検品データ.受払元伝票区分＝30：移動出荷
                    sqlText.AppendLine(" AND ((SM.STOCKMOVEFORMALRF IN(1,2)  AND I.ACPAYSLIPCDRF =30) ");
                    // 在庫移動データ.在庫移動形式 IN (3:在庫入庫,4:倉庫入庫) AND 検品データ.受払元伝票区分＝31：移動入荷
                    sqlText.AppendLine("   OR (SM.STOCKMOVEFORMALRF IN(3,4)  AND I.ACPAYSLIPCDRF =31)) ");
                    // 受払元取引区分＝10
                    sqlText.AppendLine(" AND I.ACPAYTRANSCDRF = 10 ");
                    // 論理削除区分＝0
                    sqlText.AppendLine(" AND I.LOGICALDELETECODERF = 0 ");
                    // 移動数＞0
                    sqlText.AppendLine(" WHERE   SM.MOVECOUNTRF>0 ");

                    // 従業員コード
                    if (!String.IsNullOrEmpty(cndtnWork.EmployeeCode))
                    {
                        sqlText.AppendLine(" AND I.EMPLOYEECODERF =@FINDEMPLOYEECODE ");
                        SqlParameter ParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                        ParaEmployeeCode.Value = SqlDataMediator.SqlSetString(cndtnWork.EmployeeCode);
                    }

                    // 検品日(開始)
                    if (cndtnWork.St_InspectDate > DateTime.MinValue)
                    {
                        sqlText.AppendLine(" AND I.INSPECTDATETIMERF >= @INSPECTDATETIMEST ");
                        SqlParameter ParaInspectDateTimeSt = sqlCommand.Parameters.Add("@INSPECTDATETIMEST", SqlDbType.BigInt);
                        ParaInspectDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(cndtnWork.St_InspectDate);
                    }

                    // 検品日(終了)
                    if (cndtnWork.Ed_InspectDate > DateTime.MinValue)
                    {
                        if (cndtnWork.St_InspectDate == DateTime.MinValue)
                        {
                            sqlText.AppendLine(" AND (I.INSPECTDATETIMERF < @INSPECTDATETIMEED OR I.INSPECTDATETIMERF IS NULL)");
                        }
                        else
                        {
                            sqlText.AppendLine(" AND  I.INSPECTDATETIMERF < @INSPECTDATETIMEED ");
                        }
                        SqlParameter ParaInspectDateTimeEd = sqlCommand.Parameters.Add("@INSPECTDATETIMEED", SqlDbType.BigInt);
                        ParaInspectDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(cndtnWork.Ed_InspectDate);
                    }

                    sqlText.AppendLine(" ORDER BY ");
                    // パターンが「出庫検品」の場合
                    if (cndtnWork.Pattern == 0)
                    {
                        sqlText.AppendLine("  SM.SHIPMENTFIXDAYRF ");
                    }
                    else
                    {
                        sqlText.AppendLine("  SM.ARRIVALGOODSDAYRF ");
                    }
                    sqlText.AppendLine(" ,SM.GOODSMAKERCDRF ");
                    sqlText.AppendLine(" ,SM.GOODSNORF ");
                    sqlText.AppendLine(" ,SM.STOCKMOVESLIPNORF ");
                    sqlText.AppendLine(" ,SM.STOCKMOVEROWNORF ");

                    sqlCommand.CommandText = sqlText.ToString();

                    // クエリ実行時のタイムアウト時間を3600秒に設定する
                    sqlCommand.CommandTimeout = 3600;
                    using (SqlDataReader MyReader = sqlCommand.ExecuteReader())
                    {
                        while (MyReader.Read())
                        {
                            // 検索結果在庫移動データの格納
                            retList.Add(CopyStockMoveDataFromReader(MyReader, cndtnWork));
                        }
                    }

                    if (retList != null && retList.Count > 0)
                    {
                        // 検索結果あり場合、「ctDB_NORMAL」を戻す
                        Status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        // 検索結果なし場合、「NOT_FOUND」を戻す
                        Status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }

                }
                catch (SqlException ex)
                {
                    errMessage = ex.Message;
                    //基底クラスに例外を渡して処理してもらう
                    Status = base.WriteSQLErrorLog(ex);
                }
                catch (Exception ex)
                {
                    errMessage = ex.Message;
                    Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "HandyInspectRefDataDB.SearchStockMoveProc Exception=" + ex.Message, Status);
                }
            }

            return Status;
        }

        /// <summary>
        /// 在庫移動データの格納
        /// </summary>
        /// <param name="myReader">検索結果</param>
        /// <param name="cndtnWork">検索条件</param>
        /// <returns>検品照会抽出結果</returns>
        /// <remarks>
        /// <br>Note       : 在庫移動データの格納を行う。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/09/07</br>
        /// </remarks>
        private InspectRefDataWork CopyStockMoveDataFromReader(SqlDataReader myReader, HandyInspectParamWork cndtnWork)
        {
            InspectRefDataWork resultWork = new InspectRefDataWork();
            // 伝票番号
            resultWork.SalesSlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVESLIPNORF")).ToString();
            // 行番号
            resultWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVEROWNORF"));
            // パターンが「出庫検品」の場合
            if (cndtnWork.Pattern == 0)
            {
                // 入出荷日:出荷確定日
                resultWork.ShipmentDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SHIPMENTFIXDAYRF"));
            }
            else
            {
                // 入出荷日:入荷日
                resultWork.ShipmentDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
            }
            // 商品番号
            resultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            // 商品名称
            resultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            // 商品メーカーコード
            resultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            // メーカー名称
            resultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));

            // パターンが「出庫検品」の場合
            if (cndtnWork.Pattern == 0)
            {
                // 入庫数:ゼロ固定
                resultWork.InputCnt = 0;
                // 出庫数:移動数
                resultWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVECOUNTRF"));
                // 取引先名称
                resultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSECTIONGUIDESNMRF")) + ":" + SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHNAMERF"));
                // 倉庫コード
                resultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHCODERF"));
                // 倉庫名称
                resultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHNAMERF"));
                // 倉庫棚番
                resultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSHELFNORF"));
            }
            // パターンが「入庫検品」の場合
            else
            {
                // 入庫数:移動数
                resultWork.InputCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("MOVECOUNTRF"));
                // 出庫数:ゼロ固定
                resultWork.ShipmentCnt = 0;
                // 取引先名称
                resultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFSECTIONGUIDESNMRF")) + ":" + SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BFENTERWAREHNAMERF"));
                // 倉庫コード
                resultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHCODERF"));
                // 倉庫名称
                resultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFENTERWAREHNAMERF"));
                // 倉庫棚番
                resultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("AFSHELFNORF"));
            }
            // 移動形式
            resultWork.StockMoveFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKMOVEFORMALRF"));

            // 受払元伝票区分
            resultWork.AcPaySlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPCDRF"));
            // 受払元取引区分
            resultWork.AcPayTransCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYTRANSCDRF"));
            // 検品担当者コード
            resultWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
            // 検品日時
            resultWork.InspectDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("INSPECTDATETIMERF"));
            // 検品ステータス
            resultWork.InspectStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INSPECTSTATUSRF"));
            // ハンディターミナル区分
            resultWork.HandTerminalCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HANDTERMINALCODERF"));
            // データソース区分 1:売上データ 2:仕入データ 3:在庫移動データ 4:在庫調整データ
            resultWork.DataSourceDiv = 3;

            return resultWork;
        }
        #endregion

        #region 在庫調整データ抽出処理
        /// <summary>
        /// 在庫調整データ抽出処理
        /// </summary>
        /// <param name="retList">抽出データ</param>
        /// <param name="cndtnWork">検索条件</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="stockSlipFlg">在庫仕入フラグ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 在庫調整データを抽出処理します</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/09/07</br>
        /// </remarks>
        private int SearchStockAdjustProc(out ArrayList retList,
            HandyInspectParamWork cndtnWork, out string errMessage, ref SqlConnection sqlConnection, bool stockSlipFlg)
        {
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            errMessage = string.Empty;
            SqlCommand sqlCommand = null;
            retList = new ArrayList();

            using (sqlCommand = new SqlCommand("", sqlConnection))
            {
                try
                {
                    StringBuilder sqlText = new StringBuilder();

                    sqlText.AppendLine(" SELECT ");
                    sqlText.AppendLine("  ST.STOCKSECTIONCDRF ");             // 仕入拠点コード
                    sqlText.AppendLine(" ,ST.STOCKADJUSTSLIPNORF ");          // 在庫調整伝票番号
                    sqlText.AppendLine(" ,ST.STOCKADJUSTROWNORF ");           // 在庫調整行番号
                    sqlText.AppendLine(" ,ST.GOODSMAKERCDRF ");               // 商品メーカーコード
                    sqlText.AppendLine(" ,ST.MAKERNAMERF ");                  // 商品メーカー名
                    sqlText.AppendLine(" ,ST.GOODSNORF ");                    // 商品番号
                    sqlText.AppendLine(" ,ST.GOODSNAMERF ");                  // 商品名称
                    if (stockSlipFlg)
                    {
                        // 在庫仕入 1：選択有り
                        if (cndtnWork.TransStockStockSlip == 1)
                        {
                            // パターン 0:出庫検品
                            if (cndtnWork.Pattern == 0)
                            {
                                sqlText.AppendLine(" ,ST.ADJUSTCOUNTRF*(-1) AS ADJUSTCOUNTRF");                // 調整数
                            }
                            // パターン 1:入庫検品
                            else if (cndtnWork.Pattern == 1)
                            {
                                sqlText.AppendLine(" ,ST.ADJUSTCOUNTRF ");                // 調整数
                            }
                        }
                    }
                    else
                    {
                        // 補充出庫 1：選択有り
                        if (cndtnWork.TransReplenishOutWarehouse == 1)
                        {
                            sqlText.AppendLine(" ,ST.ADJUSTCOUNTRF ");                // 調整数
                        }
                    }
                    sqlText.AppendLine(" ,ST.SUPPLIERSNMRF ");                // 仕入先略称
                    sqlText.AppendLine(" ,ST.WAREHOUSECODERF ");              // 倉庫コード
                    sqlText.AppendLine(" ,ST.WAREHOUSENAMERF ");              // 倉庫名称
                    sqlText.AppendLine(" ,ST.WAREHOUSESHELFNORF ");           // 倉庫棚番
                    sqlText.AppendLine(" ,ST.ADJUSTDATERF ");                 // 調整日付
                    sqlText.AppendLine(" ,ST.ACPAYSLIPCDRF ");                // 受払元伝票区分
                    sqlText.AppendLine(" ,ST.ACPAYTRANSCDRF ");               // 受払元取引区分
                    sqlText.AppendLine(" ,I.INSPECTSTATUSRF ");               // 検品ステータス
                    sqlText.AppendLine(" ,I.HANDTERMINALCODERF ");            // ハンディターミナル区分
                    sqlText.AppendLine(" ,I.INSPECTDATETIMERF ");             // 検品日時
                    sqlText.AppendLine(" ,I.EMPLOYEECODERF ");                // 従業員コード
                    sqlText.AppendLine(" FROM ( ");
                    sqlText.AppendLine(" SELECT ");
                    sqlText.AppendLine("  SA.ENTERPRISECODERF ");
                    sqlText.AppendLine(" ,SA.STOCKSECTIONCDRF ");
                    sqlText.AppendLine(" ,SD.STOCKADJUSTSLIPNORF ");
                    sqlText.AppendLine(" ,SD.STOCKADJUSTROWNORF ");
                    sqlText.AppendLine(" ,SD.GOODSMAKERCDRF ");
                    sqlText.AppendLine(" ,SD.MAKERNAMERF ");
                    sqlText.AppendLine(" ,SD.GOODSNORF ");
                    sqlText.AppendLine(" ,SD.GOODSNAMERF ");
                    sqlText.AppendLine(" ,SD.ADJUSTCOUNTRF ");
                    if (stockSlipFlg)
                    {
                        // 在庫仕入 1：選択有り
                        if (cndtnWork.TransStockStockSlip == 1)
                        {
                            sqlText.AppendLine(" ,SH.SUPPLIERSNMRF ");
                        }
                    }
                    else
                    {
                        // 補充出庫 1：選択有り
                        if (cndtnWork.TransReplenishOutWarehouse == 1)
                        {
                            sqlText.AppendLine(" ,NULL AS SUPPLIERSNMRF ");
                        }
                    }
                    sqlText.AppendLine(" ,SD.WAREHOUSECODERF ");
                    sqlText.AppendLine(" ,SD.WAREHOUSENAMERF ");
                    if (stockSlipFlg)
                    {
                        // 在庫仕入 1：選択有り
                        if (cndtnWork.TransStockStockSlip == 1)
                        {
                            sqlText.AppendLine(" ,SD.WAREHOUSESHELFNORF "); // 倉庫棚番
                        }
                    }
                    else
                    {
                        // 補充出庫 1：選択有り
                        if (cndtnWork.TransReplenishOutWarehouse == 1)
                        {
                            sqlText.AppendLine(" ,SS.WAREHOUSESHELFNORF "); // 倉庫棚番
                        }
                    }
                    sqlText.AppendLine(" ,SD.ADJUSTDATERF ");
                    sqlText.AppendLine(" ,SD.ACPAYSLIPCDRF ");
                    sqlText.AppendLine(" ,SD.ACPAYTRANSCDRF ");
                    sqlText.AppendLine(" FROM STOCKADJUSTRF AS SA WITH (READUNCOMMITTED) ");
                    sqlText.AppendLine(" INNER JOIN STOCKADJUSTDTLRF AS SD WITH (READUNCOMMITTED) ");// 在庫調整明細データ[INNER JOIN]==> 在庫調整データ   
                    sqlText.AppendLine(" ON SD.ENTERPRISECODERF = SA.ENTERPRISECODERF ");
                    sqlText.AppendLine(" AND SD.STOCKADJUSTSLIPNORF = SA.STOCKADJUSTSLIPNORF ");

                    if (stockSlipFlg)
                    {
                        // 在庫仕入 1：選択有り
                        if (cndtnWork.TransStockStockSlip == 1)
                        {
                            sqlText.AppendLine(" LEFT JOIN STOCKACPAYHISTRF AS SH  WITH (READUNCOMMITTED) ");
                            sqlText.AppendLine(" ON SH.ENTERPRISECODERF=SD.ENTERPRISECODERF ");        // 企業コード
                            sqlText.AppendLine( " AND SH.LOGICALDELETECODERF=0 " );                    // 論理削除区分
                            sqlText.AppendLine( " AND SH.ACPAYTRANSCDRF=SD.ACPAYTRANSCDRF " );         // 受払元取引区分
                            sqlText.AppendLine( " AND SH.ACPAYSLIPCDRF=SD.ACPAYSLIPCDRF " );           // 受払元伝票区分
                            sqlText.AppendLine(" AND SH.ACPAYSLIPNUMRF=SD.STOCKADJUSTSLIPNORF ");      // 受払元伝票番号
                            sqlText.AppendLine(" AND SH.ACPAYSLIPROWNORF=SD.STOCKADJUSTROWNORF ");     // 受払元行番号
                            //sqlText.AppendLine(" AND SH.ACPAYTRANSCDRF=SD.ACPAYTRANSCDRF ");         // 受払元取引区分
                            sqlText.AppendLine(" AND SH.GOODSNORF=SD.GOODSNORF ");                     // 商品番号
                            sqlText.AppendLine(" AND SH.GOODSMAKERCDRF=SD.GOODSMAKERCDRF ");           // 商品メーカーコード
                            sqlText.AppendLine(" AND SH.WAREHOUSECODERF=SD.WAREHOUSECODERF ");         // 倉庫コード
                        }
                    }
                    else
                    {
                        // 補充出庫 1：選択有り
                        if (cndtnWork.TransReplenishOutWarehouse == 1)
                        {
                            sqlText.AppendLine(" INNER JOIN WAREHOUSERF AS WH  WITH (READUNCOMMITTED) ");
                            sqlText.AppendLine(" ON WH.ENTERPRISECODERF=SD.ENTERPRISECODERF ");        // 企業コード
                            sqlText.AppendLine(" AND WH.WAREHOUSECODERF=SD.WAREHOUSECODERF ");         // 倉庫コード
                            sqlText.AppendLine(" AND WH.LOGICALDELETECODERF=0 ");                      // 論理削除区分
                            sqlText.AppendLine(" LEFT JOIN STOCKRF AS SS  WITH (READUNCOMMITTED) ");
                            sqlText.AppendLine(" ON SS.ENTERPRISECODERF=SD.ENTERPRISECODERF ");        // 企業コード                        
                            sqlText.AppendLine(" AND SS.GOODSMAKERCDRF=SD.GOODSMAKERCDRF ");           // 商品メーカーコード
                            sqlText.AppendLine(" AND SS.GOODSNORF=SD.GOODSNORF ");                     // 商品番号
                            sqlText.AppendLine(" AND SS.WAREHOUSECODERF=WH.MAINMNGWAREHOUSECDRF ");    // 倉庫コード
                        }
                    }
                    // WHERE文
                    sqlText.AppendLine("WHERE ");
                    // 企業コード
                    sqlText.AppendLine(" SA.ENTERPRISECODERF=@FINDENTERPRISECODE ");
                    SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.EnterpriseCode);

                    // 論理削除区分「0:有効」固定
//                    sqlText.AppendLine(" AND SD.LOGICALDELETECODERF = 0 ");
                    sqlText.AppendLine(" AND SA.LOGICALDELETECODERF = 0 ");

                    //拠点コード
                    if (!String.IsNullOrEmpty( cndtnWork.SectionCode ) && !"00".Equals( cndtnWork.SectionCode ))
                    {
                        sqlText.AppendLine( " AND SA.STOCKSECTIONCDRF=@FINDSTOCKSECTIONCDRF " );
                        SqlParameter findParaSectionCode = sqlCommand.Parameters.Add( "@FINDSTOCKSECTIONCDRF", SqlDbType.NChar );
                        findParaSectionCode.Value = SqlDataMediator.SqlSetString( cndtnWork.SectionCode );
                    }
                    else
                    {
                        sqlText.AppendLine( " AND SA.STOCKSECTIONCDRF IS NOT NULL " );
                    }

                    if (stockSlipFlg)
                    {
                        // 在庫仕入 1：選択有り
                        if (cndtnWork.TransStockStockSlip == 1)
                        {
                            //sqlText.AppendLine( " AND SD.ACPAYSLIPCDRF=13 " );
                            sqlText.AppendLine( " AND SA.ACPAYSLIPCDRF=13 " );
                            sqlText.AppendLine(" AND SD.ACPAYTRANSCDRF IN(10,30) ");
                        }
                    }
                    else
                    {
                        // 補充出庫 1：選択有り
                        if (cndtnWork.TransReplenishOutWarehouse == 1)
                        {
                            //sqlText.AppendLine(" AND SD.ACPAYSLIPCDRF=70 ");
                            sqlText.AppendLine( " AND SA.ACPAYSLIPCDRF=70 " );
                            sqlText.AppendLine( " AND SD.ACPAYTRANSCDRF=30 " );
                        }
                    }

                    if (stockSlipFlg)
                    {
                        // 倉庫コード
                        #region [倉庫コード]
                        // 在庫仕入 1：選択有り、 倉庫コード入力の場合
                        if (cndtnWork.TransStockStockSlip == 1)
                        {
                            // 倉庫コード入力の場合
                            if (!String.IsNullOrEmpty(cndtnWork.WarehouseCode))
                            {
                                sqlText.AppendLine(" AND SD.WAREHOUSECODERF=@FINDWAREHOUSECODE ");
                                SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                                findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.WarehouseCode);
                            }
                        }
                    }
                    else
                    {
                        // 補充出庫 1：選択有りの場合
                        if ((cndtnWork.TransReplenishOutWarehouse == 1))
                        {
                            // 委託先倉庫コード入力の場合
                            if (!String.IsNullOrEmpty(cndtnWork.AfWarehouseCd))
                            {
                                sqlText.AppendLine(" AND SD.WAREHOUSECODERF=@FINDWAREHOUSECODE ");
                                SqlParameter findParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                                findParaWarehouseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.AfWarehouseCd);
                            }

                            // 倉庫コード入力の場合
                            if (!String.IsNullOrEmpty(cndtnWork.WarehouseCode))
                            {
                                sqlText.AppendLine(" AND WH.MAINMNGWAREHOUSECDRF=@MAINMNGWAREHOUSECD ");
                                SqlParameter findParaMainmngwarehouseCd = sqlCommand.Parameters.Add("@MAINMNGWAREHOUSECD", SqlDbType.NChar);
                                findParaMainmngwarehouseCd.Value = SqlDataMediator.SqlSetString(cndtnWork.WarehouseCode);
                            }
                        }
                    }
                    #endregion

                    // 入出荷日(開始)
                    if (cndtnWork.St_SalesDate > DateTime.MinValue)
                    {
                        //sqlText.AppendLine(" AND SD.ADJUSTDATERF >= @SALESDATEST ");
                        sqlText.AppendLine(" AND SA.ADJUSTDATERF >= @SALESDATEST ");
                        SqlParameter paraSalesDateSt = sqlCommand.Parameters.Add( "@SALESDATEST", SqlDbType.Int );
                        paraSalesDateSt.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(cndtnWork.St_SalesDate);
                    }

                    // 入出荷日(終了)
                    if (cndtnWork.Ed_SalesDate > DateTime.MinValue)
                    {
                        //sqlText.AppendLine(" AND SD.ADJUSTDATERF <= @SALESDATEED ");
                        sqlText.AppendLine(" AND SA.ADJUSTDATERF <= @SALESDATEED ");
                        SqlParameter paraSalesDateEd = sqlCommand.Parameters.Add( "@SALESDATEED", SqlDbType.Int );
                        paraSalesDateEd.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMMDD(cndtnWork.Ed_SalesDate);
                    }

                    // 商品メーカーコード
                    if (cndtnWork.GoodsMakerCd > 0)
                    {
                        sqlText.AppendLine(" AND SD.GOODSMAKERCDRF=@FINDGOODSMAKERCD");
                        SqlParameter findParaGoodsMakerCd = sqlCommand.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);
                        findParaGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(cndtnWork.GoodsMakerCd);
                    }
                    else
                    {
                        sqlText.AppendLine(" AND SD.GOODSMAKERCDRF > " + Zero);
                    }

                    //商品番号
                    if (!String.IsNullOrEmpty(cndtnWork.GoodsNo))
                    {
                        sqlText.AppendLine(" AND SD.GOODSNORF LIKE @FINDGOODSNO");
                        SqlParameter paraGoodsNo = sqlCommand.Parameters.Add("@FINDGOODSNO", SqlDbType.NChar);
                        //前方一致検索の場合
                        if (cndtnWork.GoodsNoSrchTyp == 1) cndtnWork.GoodsNo = cndtnWork.GoodsNo + "%";
                        //後方一致検索の場合
                        if (cndtnWork.GoodsNoSrchTyp == 2) cndtnWork.GoodsNo = "%" + cndtnWork.GoodsNo;
                        //あいまい検索の場合
                        if (cndtnWork.GoodsNoSrchTyp == 3) cndtnWork.GoodsNo = "%" + cndtnWork.GoodsNo + "%";
                        paraGoodsNo.Value = SqlDataMediator.SqlSetString(cndtnWork.GoodsNo);
                    }

                    sqlText.AppendLine(" ) AS ST ");
                    sqlText.AppendLine(" LEFT JOIN INSPECTDATARF AS I WITH (READUNCOMMITTED) ");
                    sqlText.AppendLine(" ON ST.ENTERPRISECODERF = I.ENTERPRISECODERF ");
                    sqlText.AppendLine(" AND ST.STOCKADJUSTSLIPNORF = I.ACPAYSLIPNUMRF ");
                    sqlText.AppendLine(" AND ST.STOCKADJUSTROWNORF = I.ACPAYSLIPROWNORF ");
                    sqlText.AppendLine(" AND ST.ACPAYSLIPCDRF  =I.ACPAYSLIPCDRF ");
                    sqlText.AppendLine(" AND ST.ACPAYTRANSCDRF =I.ACPAYTRANSCDRF ");
                    // 論理削除区分＝0
                    sqlText.AppendLine(" AND I.LOGICALDELETECODERF = 0 ");

                    if (stockSlipFlg)
                    {
                        // 在庫仕入 1：選択有り
                        if (cndtnWork.TransStockStockSlip == 1)
                        {
                            // パターン 0:出庫検品
                            if (cndtnWork.Pattern == 0)
                            {
                                // 調整数>0
                                sqlText.AppendLine(" WHERE ST.ADJUSTCOUNTRF <0 ");
                            }
                            // パターン 1:入庫検品
                            else if (cndtnWork.Pattern == 1)
                            {
                                // 調整数>0
                                sqlText.AppendLine(" WHERE ST.ADJUSTCOUNTRF >0 ");
                            }
                        }
                    }
                    else
                    {
                        // 補充出庫 1：選択有り
                        if (cndtnWork.TransReplenishOutWarehouse == 1)
                        {
                            // 調整数>0
                            sqlText.AppendLine(" WHERE ST.ADJUSTCOUNTRF >0 ");
                        }
                    }

                    // 従業員コード
                    if (!String.IsNullOrEmpty(cndtnWork.EmployeeCode))
                    {
                        sqlText.AppendLine(" AND I.EMPLOYEECODERF =@FINDEMPLOYEECODE ");
                        SqlParameter ParaEmployeeCode = sqlCommand.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);
                        ParaEmployeeCode.Value = SqlDataMediator.SqlSetString(cndtnWork.EmployeeCode);
                    }

                    // 検品日(開始)
                    if (cndtnWork.St_InspectDate > DateTime.MinValue)
                    {
                        sqlText.AppendLine(" AND I.INSPECTDATETIMERF >= @INSPECTDATETIMEST ");
                        SqlParameter ParaInspectDateTimeSt = sqlCommand.Parameters.Add("@INSPECTDATETIMEST", SqlDbType.BigInt);
                        ParaInspectDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(cndtnWork.St_InspectDate);
                    }

                    // 検品日(終了)
                    if (cndtnWork.Ed_InspectDate > DateTime.MinValue)
                    {
                        if (cndtnWork.St_InspectDate == DateTime.MinValue)
                        {
                            sqlText.AppendLine(" AND (I.INSPECTDATETIMERF < @INSPECTDATETIMEED OR I.INSPECTDATETIMERF IS NULL)");
                        }
                        else
                        {
                            sqlText.AppendLine(" AND  I.INSPECTDATETIMERF < @INSPECTDATETIMEED ");
                        }
                        SqlParameter ParaInspectDateTimeEd = sqlCommand.Parameters.Add("@INSPECTDATETIMEED", SqlDbType.BigInt);
                        ParaInspectDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(cndtnWork.Ed_InspectDate);
                    }

                    sqlText.AppendLine(" ORDER BY ");
                    sqlText.AppendLine("  ST.ADJUSTDATERF ");
                    sqlText.AppendLine(" ,ST.GOODSMAKERCDRF ");
                    sqlText.AppendLine(" ,ST.GOODSNORF ");
                    sqlText.AppendLine(" ,ST.STOCKADJUSTSLIPNORF ");
                    sqlText.AppendLine(" ,ST.STOCKADJUSTROWNORF ");

                    sqlCommand.CommandText = sqlText.ToString();

                    // クエリ実行時のタイムアウト時間を3600秒に設定する
                    sqlCommand.CommandTimeout = 3600;
                    using (SqlDataReader MyReader = sqlCommand.ExecuteReader())
                    {
                        while (MyReader.Read())
                        {
                            // 検索結果在庫調整データの格納
                            retList.Add(CopyStockAdjustDataFromReader(MyReader, cndtnWork));
                        }
                    }
                    if (retList != null && retList.Count > 0)
                    {
                        // 検索結果あり場合、「ctDB_NORMAL」を戻す
                        Status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                    else
                    {
                        // 検索結果なし場合、「NOT_FOUND」を戻す
                        Status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }

                }
                catch (SqlException ex)
                {
                    errMessage = ex.Message;
                    //基底クラスに例外を渡して処理してもらう
                    Status = base.WriteSQLErrorLog(ex);
                }
                catch (Exception ex)
                {
                    errMessage = ex.Message;
                    Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "HandyInspectRefDataDB.SearchStockSlipProc Exception=" + ex.Message, Status);
                }
            }

            return Status;
        }

        /// <summary>
        /// 在庫調整データの格納
        /// </summary>
        /// <param name="myReader">検索結果</param>
        /// <param name="cndtnWork">検索条件</param>
        /// <returns>検品照会抽出結果</returns>
        /// <remarks>
        /// <br>Note       : 在庫調整データの格納を行う。</br>
        /// <br>Programmer : 3H 張小磊</br>
        /// <br>Date       : 2017/09/07</br>
        /// </remarks>
        private InspectRefDataWork CopyStockAdjustDataFromReader(SqlDataReader myReader, HandyInspectParamWork cndtnWork)
        {
            InspectRefDataWork resultWork = new InspectRefDataWork();
            // 伝票番号
            resultWork.SalesSlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKADJUSTSLIPNORF")).ToString();
            // 行番号
            resultWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKADJUSTROWNORF"));
            // 入出荷日
            resultWork.ShipmentDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADJUSTDATERF"));
            // 商品番号
            resultWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
            // 商品名称
            resultWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
            // 商品メーカーコード
            resultWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
            // メーカー名称
            resultWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));

            // 在庫仕入 1：選択有り
            if (cndtnWork.TransStockStockSlip == 1)
            {
                if (cndtnWork.Pattern == 0)
                {
                    // 入庫数:ゼロ固定
                    resultWork.InputCnt = 0;
                    // 出庫数:調整数
                    resultWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ADJUSTCOUNTRF")); ;
                    // 取引先名称
                    resultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                }
                else if (cndtnWork.Pattern == 1)
                {
                    // 入庫数:調整数
                    resultWork.InputCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ADJUSTCOUNTRF"));
                    // 出庫数:ゼロ固定
                    resultWork.ShipmentCnt = 0;
                    // 取引先名称
                    resultWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                }   
            }
            // 補充出庫 1：選択有り
            else if (cndtnWork.TransReplenishOutWarehouse == 1)
            {
                // 入庫数:ゼロ固定
                resultWork.InputCnt = 0;
                // 出庫数:調整数
                resultWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ADJUSTCOUNTRF"));
                // 取引先名称
                resultWork.CustomerSnm = "";
            }

            // 倉庫コード
            resultWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
            // 倉庫名称
            resultWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
            // 倉庫棚番
            resultWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
            // 受払元伝票区分
            resultWork.AcPaySlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYSLIPCDRF"));
            // 受払元取引区分
            resultWork.AcPayTransCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPAYTRANSCDRF"));
            // 検品担当者コード
            resultWork.EmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("EMPLOYEECODERF"));
            // 検品日時
            resultWork.InspectDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("INSPECTDATETIMERF"));
            // 検品ステータス
            resultWork.InspectStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("INSPECTSTATUSRF"));
            // ハンディターミナル区分
            resultWork.HandTerminalCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("HANDTERMINALCODERF"));
            // データソース区分 1:売上データ 2:仕入データ 3:在庫移動データ 4:在庫調整データ
            resultWork.DataSourceDiv = 4;

            return resultWork;
        }
        #endregion
        // --- ADD 3H 張小磊 2017/09/07----------<<<<<

        #region 検品のみデータ抽出処理
        /// <summary>
        /// 検品のみデータ抽出処理
        /// </summary>
        /// <param name="retList">出力データ</param>
        /// <param name="cndtnWork">検索条件</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 検品のみデータ抽出処理を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private int SearchInspectProc(out ArrayList retList,
            HandyInspectParamWork cndtnWork, out string errMessage, ref SqlConnection sqlConnection)
        {
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            errMessage = string.Empty;
            SqlCommand SqlCommandInfo = null;
            retList = new ArrayList();

            using (SqlCommandInfo = new SqlCommand("", sqlConnection))
            {
                try
                {
                    StringBuilder SqlText = new StringBuilder();
                    SqlText.AppendLine(InspectSqlText(cndtnWork, ref SqlCommandInfo));
                    SqlCommandInfo.CommandText = SqlText.ToString();

                    // クエリ実行時のタイムアウト時間を3600秒に設定する
                    SqlCommandInfo.CommandTimeout = 3600;
                    using (SqlDataReader myReader = SqlCommandInfo.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            // 検索結果の格納
                            retList.Add(CopyDataFromReader(myReader, cndtnWork));

                            Status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }

                    if (retList.Count == 0)
                    {
                        // 検索結果なし場合、「NOT_FOUND」を戻す
                        Status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
                catch (SqlException ex)
                {
                    errMessage = ex.Message;
                    //基底クラスに例外を渡して処理してもらう
                    Status = base.WriteSQLErrorLog(ex);
                }
                catch (Exception ex)
                {
                    errMessage = ex.Message;
                    Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    base.WriteErrorLog(ex, "HandyInspectRefDataDB.SearchInspectProc Exception=" + ex.Message, Status);
                }
            }

            return Status;
        }

        /// <summary>
        /// 検品のみデータ抽出処理
        /// </summary>
        /// <param name="cndtnWork">検索条件</param>
        /// <param name="sqlCommand"></param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 検品のみデータの検索を行う</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private string InspectSqlText(HandyInspectParamWork cndtnWork, ref SqlCommand sqlCommand)
        {
            StringBuilder SqlText = new StringBuilder();

            SqlText.AppendLine(" SELECT ");
            SqlText.AppendLine(" I.ACPAYSLIPNUMRF ");   // 伝票番号
            SqlText.AppendLine(" ,I.ACPAYSLIPROWNORF");  // 行番号
            SqlText.AppendLine(" ,I.GOODSMAKERCDRF");         // 商品メーカーコード
            SqlText.AppendLine(" ,I.GOODSNORF");              // 商品番号
            SqlText.AppendLine(" ,G.GOODSNAMERF");              // 商品名称
            SqlText.AppendLine(" ,M.MAKERNAMERF");              // 商品メーカー名称
            SqlText.AppendLine(" ,(CASE WHEN I.ACPAYTRANSCDRF = 10 THEN I.INSPECTCNTRF ELSE 0 END) AS SHIPMENTCNTRF ");           //出庫数
            SqlText.AppendLine(" ,(CASE WHEN I.ACPAYTRANSCDRF = 11 THEN I.INSPECTCNTRF ELSE 0 END) AS INPUTCNTRF ");           //入庫数
            SqlText.AppendLine(" ,0 AS INPUTOUTDAYRF ");           //入出荷日
            SqlText.AppendLine(" ,I.WAREHOUSECODERF");              // 倉庫コード
            SqlText.AppendLine(" ,W.WAREHOUSENAMERF ");           // 倉庫名称
            SqlText.AppendLine(" ,S.WAREHOUSESHELFNORF");          // 倉庫棚番
            SqlText.AppendLine(" ,I.ACPAYSLIPCDRF");          // 受払元伝票区分
            SqlText.AppendLine(" ,I.ACPAYTRANSCDRF");          // 受払元取引区分
            SqlText.AppendLine(" ,I.INSPECTSTATUSRF");          // 検品ステータス
            SqlText.AppendLine(" ,I.HANDTERMINALCODERF");          // ハンディターミナル区分
            SqlText.AppendLine(" ,I.LOGICALDELETECODERF ");   // 論理削除区分
            SqlText.AppendLine(" ,I.INSPECTDATETIMERF ");   // 検品日時
            SqlText.AppendLine(" ,I.EMPLOYEECODERF ");   // 従業員コード
            // 検品データ
            SqlText.AppendLine(" FROM INSPECTDATARF AS I WITH (READUNCOMMITTED) ");
            // 倉庫マスタ
            SqlText.AppendLine(" LEFT JOIN WAREHOUSERF AS W WITH (READUNCOMMITTED) ");
            SqlText.AppendLine(" ON  W.ENTERPRISECODERF=I.ENTERPRISECODERF ");
            SqlText.AppendLine(" AND W.WAREHOUSECODERF=I.WAREHOUSECODERF ");
            // 在庫マスタ
            SqlText.AppendLine(" LEFT JOIN STOCKRF AS S WITH (READUNCOMMITTED) ");
            SqlText.AppendLine(" ON  S.ENTERPRISECODERF=I.ENTERPRISECODERF ");
            SqlText.AppendLine(" AND S.WAREHOUSECODERF=I.WAREHOUSECODERF ");
            SqlText.AppendLine(" AND S.GOODSMAKERCDRF = I.GOODSMAKERCDRF");
            SqlText.AppendLine(" AND S.GOODSNORF = I.GOODSNORF");
            // 商品マスタ（ユーザー登録分）
            SqlText.Append(" LEFT JOIN GOODSURF AS G WITH (READUNCOMMITTED) ");
            SqlText.AppendLine(" ON  G.ENTERPRISECODERF=I.ENTERPRISECODERF ");
            SqlText.AppendLine(" AND G.GOODSMAKERCDRF = I.GOODSMAKERCDRF");
            SqlText.AppendLine(" AND G.GOODSNORF = I.GOODSNORF");
            // メーカーマスタ（ユーザー登録分）
            SqlText.Append(" LEFT JOIN MAKERURF AS M WITH (READUNCOMMITTED) ");
            SqlText.AppendLine(" ON  M.ENTERPRISECODERF=I.ENTERPRISECODERF ");
            SqlText.AppendLine(" AND M.GOODSMAKERCDRF = I.GOODSMAKERCDRF");
            SqlText.AppendLine(" WHERE");
            // 企業コード
            SqlText.AppendLine(" I.ENTERPRISECODERF=@ENTERPRISECODE");
            SqlParameter ParaEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
            ParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.EnterpriseCode);

            //拠点コード
            if (!String.IsNullOrEmpty(cndtnWork.SectionCode) && !"00".Equals(cndtnWork.SectionCode))
            {
                SqlText.AppendLine(" AND W.SECTIONCODERF=@FINDSECTIONCODE");
                SqlParameter ParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODE", SqlDbType.NChar);
                ParaSectionCode.Value = SqlDataMediator.SqlSetString(cndtnWork.SectionCode);
            }

            // 取寄区分
            if (cndtnWork.OrderDivCd == 0)
            {
                if (!String.IsNullOrEmpty(cndtnWork.WarehouseCode))
                {
                    SqlText.AppendLine(" AND (I.WAREHOUSECODERF=@FINDWAREHOUSECODE OR I.WAREHOUSECODERF = " + Zero.ToString() + ")");
                    SqlParameter ParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                    ParaWarehouseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.WarehouseCode);
                }
            }
            else
            {
                if (!String.IsNullOrEmpty(cndtnWork.WarehouseCode))
                {
                    SqlText.AppendLine(" AND I.WAREHOUSECODERF=@FINDWAREHOUSECODE");
                    SqlParameter ParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                    ParaWarehouseCode.Value = SqlDataMediator.SqlSetString(cndtnWork.WarehouseCode);
                }
                else
                {
                    SqlText.AppendLine(" AND (I.WAREHOUSECODERF IS NOT NULL AND I.WAREHOUSECODERF <> @FINDWAREHOUSECODE )");
                    SqlParameter ParaWarehouseCode = sqlCommand.Parameters.Add("@FINDWAREHOUSECODE", SqlDbType.NChar);
                    ParaWarehouseCode.Value = SqlDataMediator.SqlSetString(Zero.ToString());
                }
            }

            //商品番号
            if (!String.IsNullOrEmpty(cndtnWork.GoodsNo))
            {
                SqlText.AppendLine(" AND I.GOODSNORF LIKE @GOODSNO");
                SqlParameter ParaGoodsNo = sqlCommand.Parameters.Add("@GOODSNO", SqlDbType.NChar);
                //前方一致検索の場合
                if (cndtnWork.GoodsNoSrchTyp == 1) cndtnWork.GoodsNo = cndtnWork.GoodsNo + "%";
                //後方一致検索の場合
                if (cndtnWork.GoodsNoSrchTyp == 2) cndtnWork.GoodsNo = "%" + cndtnWork.GoodsNo;
                //あいまい検索の場合
                if (cndtnWork.GoodsNoSrchTyp == 3) cndtnWork.GoodsNo = "%" + cndtnWork.GoodsNo + "%";
                ParaGoodsNo.Value = SqlDataMediator.SqlSetString(cndtnWork.GoodsNo);
            }

            // 従業員コード
            if (!String.IsNullOrEmpty(cndtnWork.EmployeeCode))
            {
                SqlText.AppendLine(" AND I.EMPLOYEECODERF = @FINDGEMPLOYEECODE");
                SqlParameter ParaEmployeeCode = sqlCommand.Parameters.Add("@FINDGEMPLOYEECODE", SqlDbType.NChar);
                ParaEmployeeCode.Value = SqlDataMediator.SqlSetString(cndtnWork.EmployeeCode);
            }

            // 商品メーカーコード
            if (cndtnWork.GoodsMakerCd > 0)
            {
                SqlText.AppendLine(" AND I.GOODSMAKERCDRF = @FINDGGOODSMAKERCD");
                SqlParameter ParaGoodsMakerCode = sqlCommand.Parameters.Add("@FINDGGOODSMAKERCD", SqlDbType.Int);
                ParaGoodsMakerCode.Value = SqlDataMediator.SqlSetInt32(cndtnWork.GoodsMakerCd);
            }

            // 受払元行番号
            SqlText.AppendLine(" AND I.ACPAYSLIPROWNORF = @FINDACPAYSLIPROWNORF");
            SqlParameter ParaAcPaySlipRowNo = sqlCommand.Parameters.Add("@FINDACPAYSLIPROWNORF", SqlDbType.Int);
            ParaAcPaySlipRowNo.Value = SqlDataMediator.SqlSetInt32(Zero);
            // 論理削除区分
            SqlText.AppendLine(" AND I.LOGICALDELETECODERF=@FINDLOGICALDELETECODE");
            SqlParameter ParaLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
            ParaLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32((Int32)ConstantManagement.LogicalMode.GetData0);

            // 検品日(開始)
            if (cndtnWork.St_InspectDate > DateTime.MinValue)
            {
                SqlText.AppendLine(" AND I.INSPECTDATETIMERF >= @INSPECTDATETIMEST ");
                SqlParameter ParaInspectDateTimeSt = sqlCommand.Parameters.Add("@INSPECTDATETIMEST", SqlDbType.BigInt);
                ParaInspectDateTimeSt.Value = SqlDataMediator.SqlSetDateTimeFromTicks(cndtnWork.St_InspectDate);
            }
            // 検品日(終了)
            if (cndtnWork.Ed_InspectDate > DateTime.MinValue)
            {
                SqlText.AppendLine(" AND  I.INSPECTDATETIMERF < @INSPECTDATETIMEED ");
                SqlParameter ParaInspectDateTimeEd = sqlCommand.Parameters.Add("@INSPECTDATETIMEED", SqlDbType.BigInt);
                ParaInspectDateTimeEd.Value = SqlDataMediator.SqlSetDateTimeFromTicks(cndtnWork.Ed_InspectDate);
            }
            SqlText.AppendLine(" ORDER BY I.INSPECTDATETIMERF ASC ");

            return SqlText.ToString();
        }
        #endregion

        #region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Note        : SqlConnection生成処理。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2017/07/20</br>
        /// </remarks>
        private SqlConnection CreateSqlConnection(bool open)
        {
            SqlConnection RetSqlConnection = null;

            // SqlConnection生成
            SqlConnectionInfo ConnectionInfo = new SqlConnectionInfo();

            // SqlConnection接続
            string ConnectionText = ConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);

            if (!string.IsNullOrEmpty(ConnectionText))
            {
                RetSqlConnection = new SqlConnection(ConnectionText);

                if (open)
                {
                    RetSqlConnection.Open();
                }
            }
            else
            {
                base.WriteErrorLog("HandyInspectRefDataDB.CreateSqlConnection" + "コネクション取得失敗");
            }

            // SqlConnection返す
            return RetSqlConnection;
        }
        #endregion  // コネクション生成処理
    }
}

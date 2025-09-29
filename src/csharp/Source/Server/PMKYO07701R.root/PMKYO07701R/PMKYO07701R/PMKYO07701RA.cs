//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/04/29  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using System.Data.SqlClient;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using System.Data;
using Broadleaf.Library.Data.SqlTypes;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// 集計機コントロールDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : 集計機コントロールDBの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.4.29</br>
    /// <br></br>
    /// <br>Update Note: 劉学智　2009.04.28 ４データを追加</br>
    /// </remarks>
    [Serializable]
    public class SKControlDB : RemoteWithAppLockDB, ISKControlDB
    {
        #region [定数]
        private DCSalesSlipDB _salesslipDB = null;
        private DCSalesDetailDB _salesDetailDB = null;
        private DCSalesHistoryDB _salesHistoryDB = null;
        private DCSalesHistDtlDB _salesHistDtlDB = null;
        private DCDepsitMainDB _depsitMainDB = null;
        private DCDepsitDtlDB _depsitDtlDB = null;
        private DCStockSlipDB _stockSlipDB = null;
        private DCStockDetailDB _stockDetailDB = null;
        private DCStockSlipHistDB _stockSlipHistDB = null;
        private DCStockSlHistDtlDB _stockSlHistDtlDB = null;
        private DCPaymentSlpDB _paymentSlpDB = null;
        private DCPaymentDtlDB _paymentDtlDB = null;
        private DCAcceptOdrDB _acceptOdrDB = null;
        private DCAcceptOdrCarDB _acceptOdrCarDB = null;
        private DCMTtlSalesSlipDB _mTtlSalesSlipDB = null;
        private DCGoodsMTtlSaSlipDB _goodsMTtlSaSlipDB = null;
        private DCMTtlStockSlipDB _mTtlStockSlipDB = null;
        // ↓ 2009.04.28 liuyang add
        private DCStockAdjustDB _stockAdjustDB = null;
        private DCStockAdjustDtlDB _stockAdjustDtlDB = null;
        private DCStockMoveDB _stockMoveDB = null;
        private DCStockAcPayHistDB _stockAcPayHistDB = null;
        // ↑ 2009.04.28 liuyang add
        #endregion

        /// <summary>
        /// 集計機コントロールリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2008.4.24</br>
        /// </remarks>
        public SKControlDB()
        {
            // 変数初期化
            _salesslipDB = new DCSalesSlipDB();
            _salesDetailDB = new DCSalesDetailDB();
            _salesHistoryDB = new DCSalesHistoryDB();
            _salesHistDtlDB = new DCSalesHistDtlDB();
            _depsitMainDB = new DCDepsitMainDB();
            _depsitDtlDB = new DCDepsitDtlDB();
            _stockSlipDB = new DCStockSlipDB();
            _stockDetailDB = new DCStockDetailDB();
            _stockSlipHistDB = new DCStockSlipHistDB();
            _stockSlHistDtlDB = new DCStockSlHistDtlDB();
            _paymentSlpDB = new DCPaymentSlpDB();
            _paymentDtlDB = new DCPaymentDtlDB();
            _acceptOdrDB = new DCAcceptOdrDB();
            _acceptOdrCarDB = new DCAcceptOdrCarDB();
            _mTtlSalesSlipDB = new DCMTtlSalesSlipDB();
            _goodsMTtlSaSlipDB = new DCGoodsMTtlSaSlipDB();
            _mTtlStockSlipDB = new DCMTtlStockSlipDB();
            // ↓ 2009.04.28 liuyang add
            _stockAdjustDB = new DCStockAdjustDB();
            _stockAdjustDtlDB = new DCStockAdjustDtlDB();
            _stockMoveDB = new DCStockMoveDB();
            _stockAcPayHistDB = new DCStockAcPayHistDB();
            // ↑ 2009.04.28 liuyang add
        }

        #region 抽出
        /// <summary>
        /// データを取得します。
        /// </summary>
        /// <param name="outreceiveList">検索結果</param>
        /// <param name="parareceiveWork">検索条件</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="fileIds">検索データ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ取得</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.3.31</br>
        public int Search(out object outreceiveList, DCReceiveDataWork parareceiveWork, string sectionCode, string[] fileIds)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            ArrayList _salesSlipList = null;                       // 売上データ
            ArrayList _salesDetailList = null;                     // 売上明細データ
            ArrayList _salesHistoryList = null;                    // 売上履歴データ
            ArrayList _salesHistDtlList = null;                    // 売上履歴明細データ
            ArrayList _depsitMainList = null;                      // 入金データ
            ArrayList _depsitDtlList = null;                       // 入金明細データ
            ArrayList _stockSlipList = null;                       // 仕入データ
            ArrayList _stockDetailList = null;                     // 仕入明細データ
            ArrayList _stockSlipHistList = null;                   // 仕入履歴データ
            ArrayList _stockSlHistDtlList = null;                  // 仕入履歴明細データ
            ArrayList _paymentSlpList = null;                      // 支払伝票マスタ
            ArrayList _paymentDtlList = null;                      // 支払明細データ
            ArrayList _acceptOdrList = null;                       // 受注マスタ
            ArrayList _acceptOdrCarList = null;                    // 受注マスタ（車両）
            ArrayList _mTtlSalesSlipList = null;                   // 売上月次集計データ
            ArrayList _goodsMTtlSaSlipList = null;                 // 商品別売上月次集計データ
            ArrayList _mTtlStockSlipList = null;                   // 仕入月次集計データ
            // ↓ 2009.04.28 liuyang add
            ArrayList _stockAdjustList = null;                     // 在庫調整データ
            ArrayList _stockAdjustDtlList = null;                  // 在庫調整明細データ
            ArrayList _stockMoveList = null;                       // 在庫移動データ
            ArrayList _stockAcPayHistList = null;                  // 在庫受払履歴データ
            // ↑ 2009.04.28 liuyang add

            DCReceiveDataWork receiveDataWork = parareceiveWork;


            outreceiveList = new CustomSerializeArrayList();

            try
            {
                if (parareceiveWork != null)
                {
                    // コネクション生成
                    sqlConnection = this.CreateSqlConnectionData(true);

                    sqlTransaction = this.CreateTransactionData(ref sqlConnection);

                    foreach (string fileId in fileIds)
                    {
                        switch (fileId)
                        {
                            case "SalesSlipRF":
                                {
                                    // 売上データ
                                    status = _salesslipDB.Search(out _salesSlipList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_salesSlipList != null && _salesSlipList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_salesSlipList);
                                    }
                                }
                                break;

                            case "SalesDetailRF":
                                {
                                    // 売上明細データ
                                    status = _salesDetailDB.Search(out _salesDetailList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_salesDetailList != null && _salesDetailList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_salesDetailList);
                                    }
                                }
                                break;

                            case "SalesHistoryRF":
                                {
                                    // 売上履歴データ
                                    status = _salesHistoryDB.Search(out _salesHistoryList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_salesHistoryList != null && _salesHistoryList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_salesHistoryList);
                                    }
                                }
                                break;

                            case "SalesHistDtlRF":
                                {
                                    // 売上履歴明細データ
                                    status = _salesHistDtlDB.Search(out _salesHistDtlList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_salesHistDtlList != null && _salesHistDtlList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_salesHistDtlList);
                                    }
                                }
                                break;

                            case "DepsitMainRF":
                                {
                                    // 入金データ
                                    status = _depsitMainDB.Search(out _depsitMainList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_depsitMainList != null && _depsitMainList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_depsitMainList);
                                    }
                                }
                                break;

                            case "DepsitDtlRF":
                                {
                                    // 入金明細データ
                                    status = _depsitDtlDB.Search(out _depsitDtlList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_depsitDtlList != null && _depsitDtlList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_depsitDtlList);
                                    }
                                }
                                break;

                            case "StockSlipRF":
                                {
                                    // 仕入データ
                                    status = _stockSlipDB.Search(out _stockSlipList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_stockSlipList != null && _stockSlipList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_stockSlipList);
                                    }
                                }
                                break;

                            case "StockDetailRF":
                                {
                                    // 仕入明細データ
                                    status = _stockDetailDB.Search(out _stockDetailList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_stockDetailList != null && _stockDetailList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_stockDetailList);
                                    }
                                }
                                break;

                            case "StockSlipHistRF":
                                {
                                    // 仕入履歴データ
                                    status = _stockSlipHistDB.Search(out _stockSlipHistList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_stockSlipHistList != null && _stockSlipHistList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_stockSlipHistList);
                                    }
                                }
                                break;

                            case "StockSlHistDtlRF":
                                {
                                    // 仕入履歴明細データ
                                    status = _stockSlHistDtlDB.Search(out _stockSlHistDtlList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_stockSlHistDtlList != null && _stockSlHistDtlList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_stockSlHistDtlList);
                                    }
                                }
                                break;

                            case "PaymentSlpRF":
                                {
                                    // 支払伝票マスタ
                                    status = _paymentSlpDB.Search(out _paymentSlpList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_paymentSlpList != null && _paymentSlpList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_paymentSlpList);
                                    }
                                }
                                break;

                            case "PaymentDtlRF":
                                {
                                    // 支払明細データ
                                    status = _paymentDtlDB.Search(out _paymentDtlList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_paymentDtlList != null && _paymentDtlList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_paymentDtlList);
                                    }
                                }
                                break;

                            case "AcceptOdrRF":
                                {
                                    // 受注マスタ
                                    status = _acceptOdrDB.Search(out _acceptOdrList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_acceptOdrList != null && _acceptOdrList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_acceptOdrList);
                                    }
                                }
                                break;

                            case "AcceptOdrCarRF":
                                {
                                    // 受注マスタ（車両）
                                    status = _acceptOdrCarDB.Search(out _acceptOdrCarList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_acceptOdrCarList != null && _acceptOdrCarList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_acceptOdrCarList);
                                    }
                                }
                                break;

                            case "MTtlSalesSlipRF":
                                {
                                    // 売上月次集計データ
                                    status = _mTtlSalesSlipDB.Search(out _mTtlSalesSlipList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_mTtlSalesSlipList != null && _mTtlSalesSlipList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_mTtlSalesSlipList);
                                    }
                                }
                                break;

                            case "GoodsMTtlSaSlipRF":
                                {
                                    // 商品別売上月次集計データ
                                    status = _goodsMTtlSaSlipDB.Search(out _goodsMTtlSaSlipList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_goodsMTtlSaSlipList != null && _goodsMTtlSaSlipList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_goodsMTtlSaSlipList);
                                    }
                                }
                                break;

                            case "MTtlStockSlipRF":
                                {
                                    // 仕入月次集計データ
                                    status = _mTtlStockSlipDB.Search(out _mTtlStockSlipList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_mTtlStockSlipList != null && _mTtlStockSlipList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_mTtlStockSlipList);
                                    }
                                }
                                break;

                            case "StockAdjustRF":
                                {
                                    // ↓ 2009.04.28 liuyang add
                                    // 在庫調整データ
                                    status = _stockAdjustDB.Search(out _stockAdjustList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_stockAdjustList != null && _stockAdjustList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_stockAdjustList);
                                    }
                                }
                                break;

                            case "StockAdjustDtlRF":
                                {
                                    // 在庫調整明細データ
                                    status = _stockAdjustDtlDB.Search(out _stockAdjustDtlList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_stockAdjustDtlList != null && _stockAdjustDtlList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_stockAdjustDtlList);
                                    }
                                }
                                break;

                            case "StockMoveRF":
                                {
                                    // 在庫移動データ
                                    status = _stockMoveDB.Search(out _stockMoveList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_stockMoveList != null && _stockMoveList.Count > 0)
                                    {
                                        (outreceiveList as CustomSerializeArrayList).Add(_stockMoveList);
                                    }
                                }
                                break;

                            case "StockAcPayHistRF":
                                {
                                    // 在庫受払履歴データ
                                    status = _stockAcPayHistDB.Search(out _stockAcPayHistList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
                                    if (_stockAcPayHistList != null && _stockAcPayHistList.Count > 0)
                                    {
                                        // 対象外情報を判断
                                        ArrayList result = new ArrayList();
                                        foreach (DCStockAcPayHistWork stockAcPayHistWork in _stockAcPayHistList)
                                        {
                                            // 受払元伝票区分が30:移動出荷,31:移動入荷の場合
                                            if (stockAcPayHistWork.AcPaySlipCd == 30 || stockAcPayHistWork.AcPaySlipCd == 31)
                                            {
                                                // 拠点一致の場合
                                                if (stockAcPayHistWork.SectionCode == sectionCode)
                                                {
                                                    result.Add(stockAcPayHistWork);
                                                }
                                            }
                                            else
                                            {
                                                result.Add(stockAcPayHistWork);
                                            }
                                        }

                                        (outreceiveList as CustomSerializeArrayList).Add(result);
                                    }
                                }
                                break;

                            default :
                                break;
                        }
                    }

                    // ↑ 2009.04.28 liuyang add
                }

                // ステータス
                if (outreceiveList != null)
                {
                    CustomSerializeArrayList dataList = (CustomSerializeArrayList)outreceiveList;
                    if (dataList.Count == 0)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch (SqlException e)
            {
                base.WriteErrorLog(e, "DCControlDB.Search(out object outreceiveList, object parareceiveWork)", status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DCControlDB.Search(out object outreceiveList, object parareceiveWork)", status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        sqlTransaction.Commit();
                    }

                    sqlTransaction.Dispose();
                }

                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        #endregion

        #region 更新
        /// <summary>
        /// DCコントロールリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        public int Update(ref CustomSerializeArrayList retCSAList, string enterpriseCode, out string retMessage)
        {
            //●STATUS初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retMessage = string.Empty;
            SqlTransaction sqlTransaction = null;
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            string resNm = "";

            try
            {
                //●パラメータチェック
                if (retCSAList == null || retCSAList.Count <= 0)
                {
                    base.WriteErrorLog(null, "プログラムエラー。パラメータが未設定です");
                    return status;
                }

                // コネクション生成
                sqlConnection = this.CreateSqlConnectionData(true);

#if DEBUG
                // トランザクション
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_ReadUnCommitted);
#else
                                // トランザクション
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
#endif

                resNm = GetResourceName(enterpriseCode);
                //ＡＰロック
                status = Lock(resNm, sqlConnection, sqlTransaction);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                for (int i = 0; i < retCSAList.Count; i++)
                {
                    ArrayList retCSATemList = (ArrayList)retCSAList[i];

                    if (retCSATemList.Count == 0) continue;

                    // DC売上データ更新処理
                    if (retCSATemList[0] is DCSalesSlipWork)
                    {
                        DCSalesSlipDB _salesSlipDB = new DCSalesSlipDB();
                        // 存在するデータを削除する。
                        _salesSlipDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // 抽出したデータを登録する。
                        _salesSlipDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC売上明細データ更新処理
                    if (retCSATemList[0] is DCSalesDetailWork)
                    {
                        DCSalesDetailDB _salesDetailDB = new DCSalesDetailDB();
                        // 存在するデータを削除する。
                        _salesDetailDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // 抽出したデータを登録する。
                        _salesDetailDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC売上履歴データ更新処理
                    if (retCSATemList[0] is DCSalesHistoryWork)
                    {
                        DCSalesHistoryDB _salesHistoryDB = new DCSalesHistoryDB();
                        // 存在するデータを削除する。
                        _salesHistoryDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // 抽出したデータを登録する。
                        _salesHistoryDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC売上履歴明細データ更新処理
                    if (retCSATemList[0] is DCSalesHistDtlWork)
                    {
                        DCSalesHistDtlDB _salesHistDtlDB = new DCSalesHistDtlDB();
                        // 存在するデータを削除する。
                        _salesHistDtlDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // 抽出したデータを登録する。
                        _salesHistDtlDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC入金データ更新処理
                    if (retCSATemList[0] is DCDepsitMainWork)
                    {
                        DCDepsitMainDB _depsitMainDB = new DCDepsitMainDB();
                        // 存在するデータを削除する。
                        _depsitMainDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // 抽出したデータを登録する。
                        _depsitMainDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC入金明細データ更新処理
                    if (retCSATemList[0] is DCDepsitDtlWork)
                    {
                        DCDepsitDtlDB _depsitDtlDB = new DCDepsitDtlDB();
                        // 存在するデータを削除する。
                        _depsitDtlDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // 抽出したデータを登録する。
                        _depsitDtlDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC仕入データ更新処理
                    if (retCSATemList[0] is DCStockSlipWork)
                    {
                        DCStockSlipDB _stockSlipDB = new DCStockSlipDB();
                        // 存在するデータを削除する。
                        _stockSlipDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // 抽出したデータを登録する。
                        _stockSlipDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC仕入明細データ更新処理
                    if (retCSATemList[0] is DCStockDetailWork)
                    {
                        DCStockDetailDB _stockDetailDB = new DCStockDetailDB();
                        // 存在するデータを削除する。
                        _stockDetailDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // 抽出したデータを登録する。
                        _stockDetailDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC仕入履歴データ更新処理
                    if (retCSATemList[0] is DCStockSlipHistWork)
                    {
                        DCStockSlipHistDB _stockSlipHistDB = new DCStockSlipHistDB();
                        // 存在するデータを削除する。
                        _stockSlipHistDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // 抽出したデータを登録する。
                        _stockSlipHistDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC仕入履歴明細データ更新処理
                    if (retCSATemList[0] is DCStockSlHistDtlWork)
                    {
                        DCStockSlHistDtlDB _stockSlHistDtlDB = new DCStockSlHistDtlDB();
                        // 存在するデータを削除する。
                        _stockSlHistDtlDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // 抽出したデータを登録する。
                        _stockSlHistDtlDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC支払伝票マスタ更新処理
                    if (retCSATemList[0] is DCPaymentSlpWork)
                    {
                        DCPaymentSlpDB _paymentSlpDB = new DCPaymentSlpDB();
                        // 存在するデータを削除する。
                        _paymentSlpDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // 抽出したデータを登録する。
                        _paymentSlpDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC支払明細データ更新処理
                    if (retCSATemList[0] is DCPaymentDtlWork)
                    {
                        DCPaymentDtlDB _paymentDtlDB = new DCPaymentDtlDB();
                        // 存在するデータを削除する。
                        _paymentDtlDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // 抽出したデータを登録する。
                        _paymentDtlDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC受注マスタ更新処理
                    if (retCSATemList[0] is DCAcceptOdrWork)
                    {
                        DCAcceptOdrDB _acceptOdrDB = new DCAcceptOdrDB();
                        // 存在するデータを削除する。
                        _acceptOdrDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // 抽出したデータを登録する。
                        _acceptOdrDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC受注マスタ（車両）更新処理
                    if (retCSATemList[0] is DCAcceptOdrCarWork)
                    {
                        DCAcceptOdrCarDB _acceptOdrCarDB = new DCAcceptOdrCarDB();
                        // 存在するデータを削除する。
                        _acceptOdrCarDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // 抽出したデータを登録する。
                        _acceptOdrCarDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC売上月次集計データ更新処理
                    if (retCSATemList[0] is DCMTtlSalesSlipWork)
                    {
                        DCMTtlSalesSlipDB _mTtlSalesSlipDB = new DCMTtlSalesSlipDB();
                        // 存在するデータを削除する。
                        _mTtlSalesSlipDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // 抽出したデータを登録する。
                        _mTtlSalesSlipDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC商品別売上月次集計データ更新処理
                    if (retCSATemList[0] is DCGoodsMTtlSaSlipWork)
                    {
                        DCGoodsMTtlSaSlipDB _goodsMTtlSaSlipDB = new DCGoodsMTtlSaSlipDB();
                        // 存在するデータを削除する。
                        _goodsMTtlSaSlipDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // 抽出したデータを登録する。
                        _goodsMTtlSaSlipDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC仕入月次集計データ更新処理
                    if (retCSATemList[0] is DCMTtlStockSlipWork)
                    {
                        DCMTtlStockSlipDB _mTtlStockSlipDB = new DCMTtlStockSlipDB();
                        // 存在するデータを削除する。
                        _mTtlStockSlipDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // 抽出したデータを登録する。
                        _mTtlStockSlipDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC在庫調整データ更新処理
                    if (retCSATemList[0] is DCStockAdjustWork)
                    {
                        DCStockAdjustDB _stockAdjustDB = new DCStockAdjustDB();
                        // 存在するデータを削除する。
                        _stockAdjustDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // 抽出したデータを登録する。
                        _stockAdjustDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC在庫調整明細データ更新処理
                    if (retCSATemList[0] is DCStockAdjustDtlWork)
                    {
                        DCStockAdjustDtlDB _stockAdjustDtlDB = new DCStockAdjustDtlDB();
                        // 存在するデータを削除する。
                        _stockAdjustDtlDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // 抽出したデータを登録する。
                        _stockAdjustDtlDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // DC在庫移動データ更新処理
                    if (retCSATemList[0] is DCStockMoveWork)
                    {
                        DCStockMoveDB _stockMoveDB = new DCStockMoveDB();
                        // 存在するデータを削除する。
                        _stockMoveDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // 抽出したデータを登録する。
                        _stockMoveDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                    // // DC在庫受払履歴データ更新処理
                    if (retCSATemList[0] is DCStockAcPayHistWork)
                    {
                        DCStockAcPayHistDB _stockAcPayHistDB = new DCStockAcPayHistDB();
                        // 存在するデータを削除する。
                        _stockAcPayHistDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // 抽出したデータを登録する。
                        _stockAcPayHistDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                    }
                }

                sqlTransaction.Commit();

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException ex)
            {
                if (sqlTransaction != null && sqlTransaction.Connection != null) sqlTransaction.Rollback();
                // 基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "SKControlDB.Update(Connection付) SqlException=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                if (sqlTransaction != null && sqlTransaction.Connection != null) sqlTransaction.Rollback();
                // 基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "SKControlDB.Update(Connection付) Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                //ＡＰアンロック
                Release(resNm, sqlConnection, sqlTransaction);

                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                if (sqlCommand != null)
                {
                    sqlCommand.Cancel();
                    sqlCommand.Dispose();
                }
            }
            //STATUSを戻す
            return status;
        }

        #endregion

        # region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private SqlConnection CreateSqlConnectionData(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Summary_DB);

            if (!string.IsNullOrEmpty(connectionText))
            {
                retSqlConnection = new SqlConnection(connectionText);

                if (open)
                {
                    retSqlConnection.Open();
                }
            }

            return retSqlConnection;
        }

        /// <summary>
        /// SqlTransaction生成処理
        /// </summary>
        /// <param name="sqlconnection"></param>
        /// <returns>生成されたSqlTransaction、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private SqlTransaction CreateTransactionData(ref SqlConnection sqlconnection)
        {
            SqlTransaction retSqlTransaction = null;

            if (sqlconnection != null)
            {
                // DBに接続されていない場合はここで接続する
                if ((sqlconnection.State & ConnectionState.Open) == 0)
                {
                    sqlconnection.Open();
                }

                // トランザクションの生成(開始)
                retSqlTransaction = sqlconnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);
            }

            return retSqlTransaction;
        }
        # endregion
    }
}

//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/04/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 修 正 日  2009/04/29  修正内容 : 在庫系データと集計機対応の追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 修 正 日  2009/07/06  修正内容 : マスタ送受信処理のＡＰＰロックについて
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/07/21  修正内容 : SCM対応‐拠点管理（10704767-00）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/08/26  修正内容 : DC履歴ログとDC各データのクリア処理を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : Liangsd
// 修 正 日  2011/09/06 修正内容 :  Redmine#23918拠点管理改良PG変更追加依頼を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/09/08  修正内容 : Redmine #24562 仕入明細データの送信について
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : Liangsd
// 修 正 日  2011/09/09 修正内容 :  Redmine#246331伝票6明細のエラー詳細が表示されるを追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 修 正 日  2011/09/15  修正内容 : Redmine #24562 仕入明細データの送信について
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21112 久保田
// 修 正 日  2011/09/28  修正内容 : 入金引当済みの売上データを締めチェック対象外とする処理を追加
//                                 元黒の売上・仕入データを締めチェック対象外とする処理を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2011/11/29  修正内容 : Redmine #8136 拠点管理／受信処理の締チェック処理変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2011/12/07  修正内容 : Redmine #8136 拠点管理／受信処理の締チェック処理変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 西 毅
// 修 正 日  2012/03/16  修正内容 : タイムアウト対応(30秒⇒600秒)
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 姚学剛
// 修 正 日  2012/07/24  修正内容 : 拠点管理DCログ時間追加改良
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 修 正 日  2012/09/05  修正内容 : APアンロック時の条件変更（ロック出来なかった場合はアンロックしない）
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 李亜博
// 作 成 日  2012/10/16  修正内容 : 拠点管理ログ参照ツール不具合の対応
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
    /// DCコントロールDBリモートオブジェクト
    /// </summary>
    /// <remarks>
    /// <br>Note       : DCコントロールDBの実データ操作を行うクラスです。</br>
    /// <br>Programmer : 劉洋</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: 劉洋　2009.04.28 ４データを追加</br>
    /// </remarks>
    [Serializable]
    public class DCControlDB : RemoteWithAppLockDB, IDCControlDB
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
		// DEl 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
		//private DCMTtlSalesSlipDB _mTtlSalesSlipDB = null;
		//private DCGoodsMTtlSaSlipDB _goodsMTtlSaSlipDB = null;
		//private DCMTtlStockSlipDB _mTtlStockSlipDB = null;
		//private DCStockAcPayHistDB _stockAcPayHistDB = null;
		// DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
        // ↓ 2009.04.28 liuyang add
        private DCStockAdjustDB _stockAdjustDB = null;
        private DCStockAdjustDtlDB _stockAdjustDtlDB = null;       
		private DCStockMoveDB _stockMoveDB = null;
        // ↑ 2009.04.28 liuyang add
		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
		private DCDepositAlwDB _depositAlwDB = null;
		private DCRcvDraftDataDB _rcvDraftDataDB = null;
		private DCPayDraftDataDB _payDraftDataDB = null;
		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
        private ArrayList keylist = new ArrayList();//ADD by Liangsd   2011/09/09 Redmine #24633
        #endregion
        // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
        #region ■ Const Memebers ■
        private const String SALESSLIPRF = "SalesSlipRF";            //売上データ
        private const String SALESDETAILRF = "SalesDetailRF";        //売上明細データ
        private const String ACCEPTODRRF = "AcceptOdrRF";            //受注マスタ
        private const String ACCEPTODRCARRF = "AcceptOdrCarRF";      //受注マスタ（車両）
        private const String SALESHISTORYRF = "SalesHistoryRF";      //売上履歴データ
        private const String SALESHISTDTLRF = "SalesHistDtlRF";      //売上履歴明細データ
        private const String DEPSITMAINRF = "DepsitMainRF";          //入金データ
        private const String DEPSITDTLRF = "DepsitDtlRF";            //入金明細データ
        private const String STOCKSLIPRF = "StockSlipRF";            //仕入データ
        private const String STOCKDETAILRF = "StockDetailRF";        //仕入明細データ
        private const String STOCKADJUSTRF = "StockAdjustRF";        //在庫調整データ
        private const String STOCKSLIPHISTRF = "StockSlipHistRF";    //仕入履歴データ
        private const String STOCKSLHISTDTLRF = "StockSlHistDtlRF";  //仕入履歴明細データ
        private const String PAYMENTSLPRF = "PaymentSlpRF";          //支払伝票マスタ
        private const String PAYMENTDTLRF = "PaymentDtlRF";          //支払明細データ
        private const String STOCKADJUSTDTLRF = "StockAdjustDtlRF";  //在庫調整明細データ
        private const String STOCKMOVERF = "StockMoveRF";            //在庫移動データ
        private const String DEPOSITALWRF = "DepositAlwRF";          //入金引当マスタ
        private const String RCVDRAFTDATARF = "RcvDraftDataRF";      //受取手形データ
        private const String PAYDRAFTDATARF = "PayDraftDataRF";      //支払手形データ
        #endregion ■ Const Memebers ■
        // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<

        /// <summary>
        /// DCコントロールリモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 特になし</br>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2008.4.24</br>
        /// </remarks>
        public DCControlDB()
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
			// DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
			//_mTtlSalesSlipDB = new DCMTtlSalesSlipDB();
			//_goodsMTtlSaSlipDB = new DCGoodsMTtlSaSlipDB();
			//_mTtlStockSlipDB = new DCMTtlStockSlipDB();
			//_stockAcPayHistDB = new DCStockAcPayHistDB();
			// DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
            // ↓ 2009.04.28 liuyang add
            _stockAdjustDB = new DCStockAdjustDB();
            _stockAdjustDtlDB = new DCStockAdjustDtlDB();
            _stockMoveDB = new DCStockMoveDB();
            // ↑ 2009.04.28 liuyang add
			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
			_depositAlwDB = new DCDepositAlwDB();
			_rcvDraftDataDB = new DCRcvDraftDataDB();
			_payDraftDataDB = new DCPayDraftDataDB();
			// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
        }

        #region 抽出
        #region [--- DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）---]
        // DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
        /*
        /// <summary>
        /// データを取得します。
        /// </summary>
        /// <param name="outreceiveList">検索結果</param>
        /// <param name="parareceiveWork">検索条件</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="fileIds">検索データ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ取得</br>
        /// <br>Programmer : 劉洋</br>
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

                            default:
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

		*/
        // DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
        #endregion

        // ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
		 /// <summary>
        /// データを取得します。
        /// </summary>
        /// <param name="outreceiveList">検索結果</param>
        /// <param name="parareceiveWork">検索条件</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="fileIds">検索データ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : データ取得</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2011.7.26</br>
        /// <br>Update Note : 2012/07/24 姚学剛 </br>
        /// <br>            : 10801804-00、Redmine#31026 拠点管理ＤＣログ時間追加改良</br>
        /// <br>Update Note: 2012/10/16 李亜博</br>
        ///	<br>			 10801804-00、Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
		public int SearchSCM(out object outreceiveList, DCReceiveDataWork parareceiveWork, string sectionCode, string[] fileIds)
		{
            // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
            //// ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026-------->>>>>
            //// 処理開始日時を取得する。
            //DateTime startCurrentTime = new DateTime();
            //startCurrentTime = DateTime.Now;
            //string retMessage = string.Empty;
            //// ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026---------<<<<<
            // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
            string retMessage = string.Empty;
            string tempSndRcvFileID = string.Empty;
            Dictionary<string, string> tempSndRcvDic = new Dictionary<string, string>();
            ArrayList tempSndRcvHisResWorkList = new ArrayList();
            SndRcvHisTableWork tempSndRcvHisTableWork = new SndRcvHisTableWork();

            // 企業コード
            tempSndRcvHisTableWork.EnterpriseCode = parareceiveWork.PmEnterpriseCode;
            // 拠点コード
            tempSndRcvHisTableWork.SectionCode = sectionCode;
            // 送受信履歴ログ送信番号
            tempSndRcvHisTableWork.SndRcvHisConsNo = parareceiveWork.SndRcvHisConsNo;
            // 送受信区分:受信処理（開始）
            tempSndRcvHisTableWork.SendOrReceiveDivCd = 3;
            // 送受信日時
            tempSndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
            // 種別
            tempSndRcvHisTableWork.Kind = 0;
            // 送受信ログ抽出条件区分
            tempSndRcvHisTableWork.SndLogExtraCondDiv = parareceiveWork.SndLogExtraCondDiv;
            // 送信先企業コード
            tempSndRcvHisTableWork.SendDestEpCode = parareceiveWork.SendDestEpCode;
            // 送信先拠点コード
            tempSndRcvHisTableWork.SendDestSecCode = parareceiveWork.SendDestSecCode;
            // 送受信状態
            tempSndRcvHisTableWork.SndRcvCondition = 0;
            if (tempSndRcvHisTableWork.Kind == 0 && tempSndRcvHisTableWork.SndLogExtraCondDiv == 1)
            {
                if (parareceiveWork.StartDateTime.ToString().Length >= 8)
                {
                    //送信対象開始日時
                    DateTime sndObjStartDate = new DateTime(int.Parse(parareceiveWork.StartDateTime.ToString().Substring(0, 4)), int.Parse(parareceiveWork.StartDateTime.ToString().Substring(4, 2)), int.Parse(parareceiveWork.StartDateTime.ToString().Substring(6, 2)));
                    tempSndRcvHisTableWork.SndObjStartDate = sndObjStartDate.Ticks;
                }
                else
                {
                    tempSndRcvHisTableWork.SndObjStartDate = 0;
                }
                //送信対象終了日時
                tempSndRcvHisTableWork.SndObjEndDate = parareceiveWork.EndDateTimeTicks;
            }
            else
            {
                //送信対象開始日時
                tempSndRcvHisTableWork.SndObjStartDate = parareceiveWork.StartDateTime;
                //送信対象終了日時
                tempSndRcvHisTableWork.SndObjEndDate = parareceiveWork.EndDateTime;
            }
            // 仮受信区分
            if (parareceiveWork.TempReceiveDiv == 2)
            {
                tempSndRcvHisTableWork.TempReceiveDiv = 2;
            }
            else
            {
                tempSndRcvHisTableWork.TempReceiveDiv = 1;
            }
            // エラー内容
            tempSndRcvHisTableWork.SndRcvErrContents = retMessage;
            // 送受信ファイルＩＤ
            tempSndRcvHisTableWork.SndRcvFileID = tempSndRcvFileID;

            SndRcvHisTableDB tempSndRcvHisTableDB = new SndRcvHisTableDB();
            tempSndRcvHisResWorkList.Add(tempSndRcvHisTableWork);
            object tempObjSndRcvHisResWorkList = tempSndRcvHisResWorkList as object;
            tempSndRcvHisTableDB.Write(ref tempObjSndRcvHisResWorkList);
            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<

			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

			DCReceiveDataWork receiveDataWork = parareceiveWork;


            outreceiveList = new CustomSerializeArrayList();
			ArrayList resultList = new ArrayList();
			ArrayList saleAcpOdrList = new ArrayList();
			ArrayList stockAcpOdrList = new ArrayList();
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
									// 売上データ、売上明細データ、受注マスタ、受注マスタ（車両）
									receiveDataWork.DoSalesSlipFlg = true;
									receiveDataWork.DoStockDetailFlg = true;
									receiveDataWork.DoAcceptOdrFlg = true;
									receiveDataWork.DoAcceptOdrCarFlg = true;
									status = _salesslipDB.SearchSCM(out resultList, out saleAcpOdrList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
									if (resultList != null && resultList.Count > 0)
									{
										for (int i = 0; i < resultList.Count; i++)
										{
											(outreceiveList as CustomSerializeArrayList).Add(resultList[i]);
										}
									}
								}
                                // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                                if (!tempSndRcvDic.ContainsKey(SALESSLIPRF))
                                {
                                    tempSndRcvDic.Add(SALESSLIPRF, SALESSLIPRF);
                                }
                                if (!tempSndRcvDic.ContainsKey(SALESDETAILRF))
                                {
                                    tempSndRcvDic.Add(SALESDETAILRF, SALESDETAILRF);
                                }
                                if (!tempSndRcvDic.ContainsKey(ACCEPTODRRF))
                                {
                                    tempSndRcvDic.Add(ACCEPTODRRF, ACCEPTODRRF);
                                }
                                if (!tempSndRcvDic.ContainsKey(ACCEPTODRCARRF))
                                {
                                    tempSndRcvDic.Add(ACCEPTODRCARRF, ACCEPTODRCARRF);
                                }
                                // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
								break;
							case "SalesHistoryRF":
								{
									// 売上履歴データ、売上履歴明細データ
									receiveDataWork.DoSalesHistoryFlg = true;
									receiveDataWork.DoSalesHistDtlFlg = true;
									status = _salesHistoryDB.SearchSCM(out resultList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
									if (resultList != null && resultList.Count > 0)
									{
										for (int i = 0; i < resultList.Count; i++)
										{
											(outreceiveList as CustomSerializeArrayList).Add(resultList[i]);
										}
									}
								}
                                // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                                if (!tempSndRcvDic.ContainsKey(SALESHISTORYRF))
                                {
                                    tempSndRcvDic.Add(SALESHISTORYRF, SALESHISTORYRF);
                                }
                                if (!tempSndRcvDic.ContainsKey(SALESHISTDTLRF))
                                {
                                    tempSndRcvDic.Add(SALESHISTDTLRF, SALESHISTDTLRF);
                                }
                                // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
								break;
							case "DepsitMainRF":
								{
									// 入金データ、入金明細データ
									receiveDataWork.DoDepsitMainFlg = true;
									receiveDataWork.DoDepsitDtlFlg = true;
									status = _depsitMainDB.SearchSCM(out resultList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
									if (resultList != null && resultList.Count > 0)
									{
										for (int i = 0; i < resultList.Count; i++)
										{
											(outreceiveList as CustomSerializeArrayList).Add(resultList[i]);
										}
									}
								}
                                // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                                if (!tempSndRcvDic.ContainsKey(DEPSITMAINRF))
                                {
                                    tempSndRcvDic.Add(DEPSITMAINRF, DEPSITMAINRF);
                                }
                                if (!tempSndRcvDic.ContainsKey(DEPSITDTLRF))
                                {
                                    tempSndRcvDic.Add(DEPSITDTLRF, DEPSITDTLRF);
                                }
                                // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
								break;
							case "StockSlipRF":
								{
									// 仕入データ、仕入明細データ,受注マスタ
									receiveDataWork.DoStockSlipFlg = true;
									receiveDataWork.DoStockDetailFlg = true;
									receiveDataWork.DoAcceptOdrFlg = true;
									//ArrayList newStockDtlList = new ArrayList();// DEL 2011/09/15
									//status = _stockSlipDB.SearchSCM(out resultList,out newStockDtlList, out stockAcpOdrList, receiveDataWork, ref sqlConnection, ref sqlTransaction);// DEL 2011/09/15
									status = _stockSlipDB.SearchSCM(out resultList, out stockAcpOdrList, receiveDataWork, ref sqlConnection, ref sqlTransaction);// ADD 2011/09/15
									if (resultList != null && resultList.Count > 0)
									{
										for (int i = 0; i < resultList.Count; i++)
										{
											(outreceiveList as CustomSerializeArrayList).Add(resultList[i]);
										}
									}
									// DEL 2011/09/15 ----------- >>>>>
									//// ADD 2011.09.08 ----------- >>>>>
									//// 仕入明細のみの場合
									//ArrayList onlyStockDtlList = new ArrayList();
									//string retMsg = string.Empty;
									//status = _stockDetailDB.Search(out onlyStockDtlList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
									//if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
									//{
									//    if (onlyStockDtlList != null && onlyStockDtlList.Count > 0)
									//    {
									//        foreach (DCStockDetailWork tmpWork in onlyStockDtlList)
									//        {
									//            newStockDtlList.Add(tmpWork);
									//        }
									//    }
									//}
									//(outreceiveList as CustomSerializeArrayList).Add(newStockDtlList);
									//// ADD 2011.09.08 ----------- <<<<<
									// DEL 2011/09/15 ----------- <<<<<
								}
                                // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                                if (!tempSndRcvDic.ContainsKey(STOCKSLIPRF))
                                {
                                    tempSndRcvDic.Add(STOCKSLIPRF, STOCKSLIPRF);
                                }
                                if (!tempSndRcvDic.ContainsKey(STOCKDETAILRF))
                                {
                                    tempSndRcvDic.Add(STOCKDETAILRF, STOCKDETAILRF);
                                }
                                if (!tempSndRcvDic.ContainsKey(ACCEPTODRRF))
                                {
                                    tempSndRcvDic.Add(ACCEPTODRRF, ACCEPTODRRF);
                                }
                                // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
								break;
							case "StockSlipHistRF":
								{
									// 仕入履歴データ、仕入履歴明細データ
									receiveDataWork.DoStockSlipHistFlg = true;
									receiveDataWork.DoStockSlHistDtlFlg = true;
									status = _stockSlipHistDB.SearchSCM(out resultList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
									if (resultList != null && resultList.Count > 0)
									{
										for (int i = 0; i < resultList.Count; i++)
										{
											(outreceiveList as CustomSerializeArrayList).Add(resultList[i]);
										}
									}
								}
                                // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                                if (!tempSndRcvDic.ContainsKey(STOCKSLIPHISTRF))
                                {
                                    tempSndRcvDic.Add(STOCKSLIPHISTRF, STOCKSLIPHISTRF);
                                }
                                if (!tempSndRcvDic.ContainsKey(STOCKSLHISTDTLRF))
                                {
                                    tempSndRcvDic.Add(STOCKSLHISTDTLRF, STOCKSLHISTDTLRF);
                                }
                                // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
								break;
							case "PaymentSlpRF":
								{
									// 支払伝票マスタ,、支払明細データ
									receiveDataWork.DoPaymentSlpFlg = true;
									receiveDataWork.DoPaymentDtlFlg = true;
									status = _paymentSlpDB.SearchSCM(out resultList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
									if (resultList != null && resultList.Count > 0)
									{
										for (int i = 0; i < resultList.Count; i++)
										{
											(outreceiveList as CustomSerializeArrayList).Add(resultList[i]);
										}
									}
								}
                                // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                                if (!tempSndRcvDic.ContainsKey(PAYMENTSLPRF))
                                {
                                    tempSndRcvDic.Add(PAYMENTSLPRF, PAYMENTSLPRF);
                                }
                                if (!tempSndRcvDic.ContainsKey(PAYMENTDTLRF))
                                {
                                    tempSndRcvDic.Add(PAYMENTDTLRF, PAYMENTDTLRF);
                                }
                                // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
								break;
							case "StockAdjustRF":
								{
									// 在庫調整データ
									status = _stockAdjustDB.Search(out resultList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
									if (resultList != null && resultList.Count > 0)
									{
										(outreceiveList as CustomSerializeArrayList).Add(resultList);
									}
								}
                                // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                                if (!tempSndRcvDic.ContainsKey(STOCKADJUSTRF))
                                {
                                    tempSndRcvDic.Add(STOCKADJUSTRF, STOCKADJUSTRF);
                                }
                                // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
								break;
							case "StockAdjustDtlRF":
								{
									// 在庫調整明細データ
									status = _stockAdjustDtlDB.Search(out resultList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
									if (resultList != null && resultList.Count > 0)
									{
										(outreceiveList as CustomSerializeArrayList).Add(resultList);
									}
								}
                                // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                                if (!tempSndRcvDic.ContainsKey(STOCKADJUSTDTLRF))
                                {
                                    tempSndRcvDic.Add(STOCKADJUSTDTLRF, STOCKADJUSTDTLRF);
                                }
                                // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
								break;

							case "StockMoveRF":
								{
									// 在庫移動データ
									status = _stockMoveDB.Search(out resultList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
									if (resultList != null && resultList.Count > 0)
									{
										(outreceiveList as CustomSerializeArrayList).Add(resultList);
									}
								}
                                // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                                if (!tempSndRcvDic.ContainsKey(STOCKMOVERF))
                                {
                                    tempSndRcvDic.Add(STOCKMOVERF, STOCKMOVERF);
                                }
                                // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
								break;
							case "DepositAlwRF":
								{
									// 入金引当マスタ
									status = _depositAlwDB.Search(out resultList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
									if (resultList != null && resultList.Count > 0)
									{
										(outreceiveList as CustomSerializeArrayList).Add(resultList);
									}
								}
                                // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                                if (!tempSndRcvDic.ContainsKey(DEPOSITALWRF))
                                {
                                    tempSndRcvDic.Add(DEPOSITALWRF, DEPOSITALWRF);
                                }
                                // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
								break;
							case "RcvDraftDataRF":
								{
									// 受取手形データ
									status = _rcvDraftDataDB.Search(out resultList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
									if (resultList != null && resultList.Count > 0)
									{
										(outreceiveList as CustomSerializeArrayList).Add(resultList);
									}
								}
                                // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                                if (!tempSndRcvDic.ContainsKey(RCVDRAFTDATARF))
                                {
                                    tempSndRcvDic.Add(RCVDRAFTDATARF, RCVDRAFTDATARF);
                                }
                                // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
								break;
							case "PayDraftDataRF":
								{
									// 支払手形データ
									status = _payDraftDataDB.Search(out resultList, receiveDataWork, ref sqlConnection, ref sqlTransaction);
									if (resultList != null && resultList.Count > 0)
									{
										(outreceiveList as CustomSerializeArrayList).Add(resultList);
									}
								}
                                // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                                if (!tempSndRcvDic.ContainsKey(PAYDRAFTDATARF))
                                {
                                    tempSndRcvDic.Add(PAYDRAFTDATARF, PAYDRAFTDATARF);
                                }
                                // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
								break;

							default:
								break;

						}
					}
				}
				if (receiveDataWork.DoAcceptOdrFlg)
				{
					for (int cnt = 0; cnt < stockAcpOdrList.Count; cnt++)
					{
						saleAcpOdrList.Add(stockAcpOdrList[cnt]);
					}

					(outreceiveList as CustomSerializeArrayList).Add(saleAcpOdrList);
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
                retMessage = e.Message;    // ADD 2012/07/24 姚学剛
			}
			catch (Exception ex)
			{
				base.WriteErrorLog(ex, "DCControlDB.Search(out object outreceiveList, object parareceiveWork)", status);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                retMessage = ex.Message;    // ADD 2012/07/24 姚学剛
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

            // ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026-------->>>>>
            // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
            //// 処理終了日付を取得する。
            //DateTime endCurrentTime = new DateTime();
            //endCurrentTime = DateTime.Now;
            // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
            foreach (KeyValuePair<string, string> tempFileId in tempSndRcvDic)
            {
                if (string.IsNullOrEmpty(tempSndRcvFileID))
                {
                    tempSndRcvFileID = tempSndRcvFileID + tempFileId.Key;
                }
                else
                {
                    tempSndRcvFileID = tempSndRcvFileID + "," + tempFileId.Key;
                }

            }
            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<

            ArrayList sndRcvHisResWorkList = new ArrayList();
            SndRcvHisTableWork sndRcvHisTableWork = new SndRcvHisTableWork();

            // 企業コード
            sndRcvHisTableWork.EnterpriseCode = receiveDataWork.PmEnterpriseCode;
            // 拠点コード
            //sndRcvHisTableWork.SectionCode = receiveDataWork.PmSectionCode;//DEL 2012/10/16 李亜博 for redmine#31026
            sndRcvHisTableWork.SectionCode = sectionCode;//ADD 2012/10/16 李亜博 for redmine#31026
            // 送受信履歴ログ送信番号
            sndRcvHisTableWork.SndRcvHisConsNo = receiveDataWork.SndRcvHisConsNo;
            // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
            //// 送受信区分
            //sndRcvHisTableWork.SendOrReceiveDivCd = 1;
            // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
            // 送受信区分:受信処理（終了）
            sndRcvHisTableWork.SendOrReceiveDivCd = 4;
            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
            // 送受信日時
            //sndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmm"));//DEL 2012/10/16 李亜博 for redmine#31026
            sndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));//ADD 2012/10/16 李亜博 for redmine#31026
            // 種別
            sndRcvHisTableWork.Kind = 0;
            // 送受信ログ抽出条件区分
            sndRcvHisTableWork.SndLogExtraCondDiv = receiveDataWork.SndLogExtraCondDiv;
            // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
            //// 処理開始日時
            //sndRcvHisTableWork.ProcStartDateTime = startCurrentTime.Ticks;
            //// 処理終了日時
            //sndRcvHisTableWork.ProcEndDateTime = endCurrentTime.Ticks;
            // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
            // 送信先企業コード
            sndRcvHisTableWork.SendDestEpCode = receiveDataWork.SendDestEpCode;
            // 送信先拠点コード
            sndRcvHisTableWork.SendDestSecCode = receiveDataWork.SendDestSecCode;
            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
            if (sndRcvHisTableWork.Kind == 0 && sndRcvHisTableWork.SndLogExtraCondDiv == 1)
            {
                if (receiveDataWork.StartDateTime.ToString().Length >= 8)
                {
                    //送信対象開始日時
                    DateTime sndObjStartDate = new DateTime(int.Parse(receiveDataWork.StartDateTime.ToString().Substring(0, 4)), int.Parse(receiveDataWork.StartDateTime.ToString().Substring(4, 2)), int.Parse(receiveDataWork.StartDateTime.ToString().Substring(6, 2)));
                    sndRcvHisTableWork.SndObjStartDate = sndObjStartDate.Ticks;
                }
                else
                {
                    sndRcvHisTableWork.SndObjStartDate = 0;
                }
                //送信対象終了日時
                sndRcvHisTableWork.SndObjEndDate = receiveDataWork.EndDateTimeTicks;
            }
            else
            {
                //送信対象開始日時
                sndRcvHisTableWork.SndObjStartDate = receiveDataWork.StartDateTime;
                //送信対象終了日時
                sndRcvHisTableWork.SndObjEndDate = receiveDataWork.EndDateTime;
            }
            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
            // 送受信状態
            if (status == 0)
            {
                sndRcvHisTableWork.SndRcvCondition = 0;
            }
            else
            {
                sndRcvHisTableWork.SndRcvCondition = 1;
            }
            // 仮受信区分
            if (receiveDataWork.TempReceiveDiv == 2)
            {
                sndRcvHisTableWork.TempReceiveDiv = 2;
            }
            else
            {
                sndRcvHisTableWork.TempReceiveDiv = 1;
            }
            // エラー内容
            sndRcvHisTableWork.SndRcvErrContents = retMessage;
            // 送受信ファイルＩＤ
            //sndRcvHisTableWork.SndRcvFileID = receiveDataWork.SndRcvFileID;//DEL 2012/10/16 李亜博 for redmine#31026
            sndRcvHisTableWork.SndRcvFileID = tempSndRcvFileID;//ADD 2012/10/16 李亜博 for redmine#31026
            
            SndRcvHisTableDB sndRcvHisTableDB = new SndRcvHisTableDB();
            sndRcvHisResWorkList.Add(sndRcvHisTableWork);
            object objSndRcvHisResWorkList = sndRcvHisResWorkList as object;
            sndRcvHisTableDB.Write(ref objSndRcvHisResWorkList);
            // ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026---------<<<<<
            return status;
		}

		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
        #endregion

        #region 更新
        #region [--- DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）---]
        // DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
        /*
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
                // MOD 2009/07/06 --->>>
                //ＡＰロック
                //status = Lock(resNm, sqlConnection, sqlTransaction);
                status = Lock(resNm, 1, sqlConnection, sqlTransaction);
                // MOD 2009/07/06 ---<<<

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                for ( int i = 0; i < retCSAList.Count; i++ )
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

                // DEL 2009/07/06--->>>
                // sqlTransaction.Commit();
                // DEL 2009/07/06---<<<

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (SqlException ex)
            {
                // DEL 2009/07/06--->>>
                // if (sqlTransaction != null && sqlTransaction.Connection != null) sqlTransaction.Rollback();
                // DEL 2009/07/06---<<<
                // 基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DCControlDB.Update(Connection付) SqlException=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                // DEL 2009/07/06--->>>
                // if (sqlTransaction != null && sqlTransaction.Connection != null) sqlTransaction.Rollback();
                // DEL 2009/07/06---<<<
                // 基底クラスに例外を渡して処理してもらう
                base.WriteErrorLog(ex, "DCControlDB.Update(Connection付) Exception=" + ex.Message);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                // MOD 2009/07/06--->>>
                
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

                if (resNm != "")
                {
                    //ＡＰアンロック
                    status = Release(resNm, sqlConnection, sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                }

                if (sqlTransaction != null)
                {
                    if (sqlTransaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            sqlTransaction.Commit();
                        }
                        else
                        {
                            sqlTransaction.Rollback();
                        }
                    }

                    sqlTransaction.Dispose();
                }

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
                // MOD 2009/07/06---<<<
            }
            //STATUSを戻す
            return status;
        }		
        */
        // DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
        #endregion [--- DEL 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）---]

        // ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
		/// <summary>
		/// DCコントロールリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特になし</br>
		/// <br>Programmer : 譚洪</br>
		/// <br>Date       : 2009.04.02</br>
        /// <br>Update Note : 2012/07/24 姚学剛 </br>
        /// <br>            : 10801804-00、Redmine#31026 拠点管理ＤＣログ時間追加改良</br>
        /// <br>Update Note: 2012/10/16 李亜博</br>
        ///	<br>			 10801804-00、Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
		/// </remarks>
		public int UpdateSCM(ref CustomSerializeArrayList retCSAList, string enterpriseCode, ArrayList logList, out string retMessage)
		{
            // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
            //// ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026-------->>>>>
            //// 処理開始日付を取得する。
            //DateTime startCurrentTime = new DateTime();
            //startCurrentTime = DateTime.Now;
            //// ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026---------<<<<<
            // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
            string tempSndRcvFileID = string.Empty;
            Dictionary<string, string> tempSndRcvDic = new Dictionary<string, string>();
            ArrayList tempSndRcvHisResWorkList = new ArrayList();
            SndRcvHisTableWork tempSndRcvHisTableWork = null;

            for (int i = 0; i < logList.Count; i++)
            {
                if (logList[i].GetType() == typeof(ArrayList))
                {
                    ArrayList tempLogList = logList[i] as ArrayList;

                    for (int j = 0; j < tempLogList.Count; j++)
                    {
                        if (tempLogList[j].GetType() == typeof(SndRcvHisWork))
                        {
                            tempSndRcvHisTableWork = new SndRcvHisTableWork();
                            // 企業コード
                            tempSndRcvHisTableWork.EnterpriseCode = ((SndRcvHisWork)tempLogList[j]).EnterpriseCode;
                            // 拠点コード
                            tempSndRcvHisTableWork.SectionCode = ((SndRcvHisWork)tempLogList[j]).SectionCode;
                            // 送受信履歴送信番号
                            tempSndRcvHisTableWork.SndRcvHisConsNo = ((SndRcvHisWork)tempLogList[j]).SndRcvHisConsNo;
                            // 送受信区分:送信処理（開始）
                            tempSndRcvHisTableWork.SendOrReceiveDivCd = 0;
                            // 送受信日時
                            tempSndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
                            // 種別
                            tempSndRcvHisTableWork.Kind = 0;
                            // 送受信ログ抽出条件区分
                            tempSndRcvHisTableWork.SndLogExtraCondDiv = ((SndRcvHisWork)tempLogList[j]).SndLogExtraCondDiv;
                            // 送信先企業コード
                            tempSndRcvHisTableWork.SendDestEpCode = ((SndRcvHisWork)tempLogList[j]).SendDestEpCode;
                            // 送信先拠点コード
                            tempSndRcvHisTableWork.SendDestSecCode = ((SndRcvHisWork)tempLogList[j]).SendDestSecCode;
                            //送信対象開始日時
                            tempSndRcvHisTableWork.SndObjStartDate = ((SndRcvHisWork)tempLogList[j]).SndObjStartDate.Ticks;
                            //送信対象終了日時
                            tempSndRcvHisTableWork.SndObjEndDate = ((SndRcvHisWork)tempLogList[j]).SndObjEndDate.Ticks;
                            // 送受信状態
                            tempSndRcvHisTableWork.SndRcvCondition = 0;
                            // 仮受信区分
                            tempSndRcvHisTableWork.TempReceiveDiv = 0;
                            // 送受信ファイルＩＤ
                            tempSndRcvHisTableWork.SndRcvFileID = tempSndRcvFileID;

                            tempSndRcvHisResWorkList.Add(tempSndRcvHisTableWork);
                        }
                    }
                }
            }

            SndRcvHisTableDB tempSndRcvHisTableDB = new SndRcvHisTableDB();
            object tempObjSndRcvHisResWorkList = tempSndRcvHisResWorkList as object;
            tempSndRcvHisTableDB.Write(ref tempObjSndRcvHisResWorkList);
            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
            
			//●STATUS初期化
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			int status2 = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			int status3 = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			retMessage = string.Empty;
			SqlTransaction sqlTransaction = null;
			SqlConnection sqlConnection = null;
			SqlCommand sqlCommand = null;
			string resNm = "";
			//送受信抽出条件履歴ログ
			SndRcvHisDB _logDB = new SndRcvHisDB();

#if !DEBUG
            IntentExclusiveLockComponent intentLockObj = null;
#endif
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
                // del 2012/09/05 >>>
                //status = Lock(resNm, 1, sqlConnection, sqlTransaction);

                //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    return status;
                //}
                // del 2012/09/05 <<<
                // add 2012/09/05 >>>
                status2 = Lock(resNm, 1, sqlConnection, sqlTransaction);

                if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    return status2;
				}
                status2 = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                // add 2012/09/05 <<<
                // ADD 2011/08/22 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>
#if !DEBUG
                // インテントロックを行う
                intentLockObj = new IntentExclusiveLockComponent(); // ロック部品をインスタンス
                // インテントロック対象を設定
                string[] targetTables = new string[]{"SALESSLIPRF", "ACCEPTODRCARRF", "SALESDETAILRF", "SALESHISTORYRF"       // 売上データ、受注マスタ（車両）、売上明細データ、売上履歴データ
                                    ,"SALESHISTDTLRF","STOCKSLIPRF", "STOCKDETAILRF","STOCKSLIPHISTRF"                        // 売上履歴明細データ、仕入データ、仕入明細データ、仕入履歴データ
                                    ,"STOCKSLHISTDTLRF", "STOCKADJUSTRF", "STOCKADJUSTDTLRF", "STOCKMOVERF", "ACCEPTODRRF"};  // 仕入履歴明細データ、在庫調整データ、在庫調整明細データ、在庫移動データ、受注マスタ
                status = intentLockObj.IntentLock(targetTables);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    return status;
#endif
                // ADD 2011/08/22 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<

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
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(SALESSLIPRF))
                        {
                            tempSndRcvDic.Add(SALESSLIPRF, SALESSLIPRF);
                        }
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
					}
					// DC売上明細データ更新処理
					if (retCSATemList[0] is DCSalesDetailWork)
					{
						DCSalesDetailDB _salesDetailDB = new DCSalesDetailDB();
						// 存在するデータを削除する。
						_salesDetailDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// 抽出したデータを登録する。
						_salesDetailDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(SALESDETAILRF))
                        {
                            tempSndRcvDic.Add(SALESDETAILRF, SALESDETAILRF);
                        }
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
					}
					// DC売上履歴データ更新処理
					if (retCSATemList[0] is DCSalesHistoryWork)
					{
						DCSalesHistoryDB _salesHistoryDB = new DCSalesHistoryDB();
						// 存在するデータを削除する。
						_salesHistoryDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// 抽出したデータを登録する。
						_salesHistoryDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(SALESHISTORYRF))
                        {
                            tempSndRcvDic.Add(SALESHISTORYRF, SALESHISTORYRF);
                        }
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
					}
					// DC売上履歴明細データ更新処理
					if (retCSATemList[0] is DCSalesHistDtlWork)
					{
						DCSalesHistDtlDB _salesHistDtlDB = new DCSalesHistDtlDB();
						// 存在するデータを削除する。
						_salesHistDtlDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// 抽出したデータを登録する。
						_salesHistDtlDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(SALESHISTDTLRF))
                        {
                            tempSndRcvDic.Add(SALESHISTDTLRF, SALESHISTDTLRF);
                        }
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
					}
					// DC入金データ更新処理
					if (retCSATemList[0] is DCDepsitMainWork)
					{
						DCDepsitMainDB _depsitMainDB = new DCDepsitMainDB();
						// 存在するデータを削除する。
						_depsitMainDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// 抽出したデータを登録する。
						_depsitMainDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(DEPSITMAINRF))
                        {
                            tempSndRcvDic.Add(DEPSITMAINRF, DEPSITMAINRF);
                        }
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
					}
					// DC入金明細データ更新処理
					if (retCSATemList[0] is DCDepsitDtlWork)
					{
						DCDepsitDtlDB _depsitDtlDB = new DCDepsitDtlDB();
						// 存在するデータを削除する。
						_depsitDtlDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// 抽出したデータを登録する。
						_depsitDtlDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(DEPSITDTLRF))
                        {
                            tempSndRcvDic.Add(DEPSITDTLRF, DEPSITDTLRF);
                        }
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
					}
					// DC仕入データ更新処理
					if (retCSATemList[0] is DCStockSlipWork)
					{
						DCStockSlipDB _stockSlipDB = new DCStockSlipDB();
						// 存在するデータを削除する。
						_stockSlipDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// 抽出したデータを登録する。
						_stockSlipDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(STOCKSLIPRF))
                        {
                            tempSndRcvDic.Add(STOCKSLIPRF, STOCKSLIPRF);
                        }
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
					}
					// DC仕入明細データ更新処理
					if (retCSATemList[0] is DCStockDetailWork)
					{
						DCStockDetailDB _stockDetailDB = new DCStockDetailDB();
						// 存在するデータを削除する。
						_stockDetailDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// 抽出したデータを登録する。
						_stockDetailDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(STOCKDETAILRF))
                        {
                            tempSndRcvDic.Add(STOCKDETAILRF, STOCKDETAILRF);
                        }
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
					}
					// DC仕入履歴データ更新処理
					if (retCSATemList[0] is DCStockSlipHistWork)
					{
						DCStockSlipHistDB _stockSlipHistDB = new DCStockSlipHistDB();
						// 存在するデータを削除する。
						_stockSlipHistDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// 抽出したデータを登録する。
						_stockSlipHistDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(STOCKSLIPHISTRF))
                        {
                            tempSndRcvDic.Add(STOCKSLIPHISTRF, STOCKSLIPHISTRF);
                        }
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
					}
					// DC仕入履歴明細データ更新処理
					if (retCSATemList[0] is DCStockSlHistDtlWork)
					{
						DCStockSlHistDtlDB _stockSlHistDtlDB = new DCStockSlHistDtlDB();
						// 存在するデータを削除する。
						_stockSlHistDtlDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// 抽出したデータを登録する。
						_stockSlHistDtlDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(STOCKSLHISTDTLRF))
                        {
                            tempSndRcvDic.Add(STOCKSLHISTDTLRF, STOCKSLHISTDTLRF);
                        }
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
					}
					// DC支払伝票マスタ更新処理
					if (retCSATemList[0] is DCPaymentSlpWork)
					{
						DCPaymentSlpDB _paymentSlpDB = new DCPaymentSlpDB();
						// 存在するデータを削除する。
						_paymentSlpDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// 抽出したデータを登録する。
						_paymentSlpDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(PAYMENTSLPRF))
                        {
                            tempSndRcvDic.Add(PAYMENTSLPRF, PAYMENTSLPRF);
                        }
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
					}
					// DC支払明細データ更新処理
					if (retCSATemList[0] is DCPaymentDtlWork)
					{
						DCPaymentDtlDB _paymentDtlDB = new DCPaymentDtlDB();
						// 存在するデータを削除する。
						_paymentDtlDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// 抽出したデータを登録する。
						_paymentDtlDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(PAYMENTDTLRF))
                        {
                            tempSndRcvDic.Add(PAYMENTDTLRF, PAYMENTDTLRF);
                        }
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
					}
					// DC受注マスタ更新処理
					if (retCSATemList[0] is DCAcceptOdrWork)
					{
						DCAcceptOdrDB _acceptOdrDB = new DCAcceptOdrDB();
						// 存在するデータを削除する。
						_acceptOdrDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// 抽出したデータを登録する。
						_acceptOdrDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(ACCEPTODRRF))
                        {
                            tempSndRcvDic.Add(ACCEPTODRRF, ACCEPTODRRF);
                        }
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
					}
					// DC受注マスタ（車両）更新処理
					if (retCSATemList[0] is DCAcceptOdrCarWork)
					{
						DCAcceptOdrCarDB _acceptOdrCarDB = new DCAcceptOdrCarDB();
						// 存在するデータを削除する。
						_acceptOdrCarDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// 抽出したデータを登録する。
						_acceptOdrCarDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(ACCEPTODRCARRF))
                        {
                            tempSndRcvDic.Add(ACCEPTODRCARRF, ACCEPTODRCARRF);
                        }
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
					}
					
					// DC在庫調整データ更新処理
					if (retCSATemList[0] is DCStockAdjustWork)
					{
						DCStockAdjustDB _stockAdjustDB = new DCStockAdjustDB();
						// 存在するデータを削除する。
						_stockAdjustDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// 抽出したデータを登録する。
						_stockAdjustDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(STOCKADJUSTRF))
                        {
                            tempSndRcvDic.Add(STOCKADJUSTRF, STOCKADJUSTRF);
                        }
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
					}
					// DC在庫調整明細データ更新処理
					if (retCSATemList[0] is DCStockAdjustDtlWork)
					{
						DCStockAdjustDtlDB _stockAdjustDtlDB = new DCStockAdjustDtlDB();
						// 存在するデータを削除する。
						_stockAdjustDtlDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// 抽出したデータを登録する。
						_stockAdjustDtlDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(STOCKADJUSTDTLRF))
                        {
                            tempSndRcvDic.Add(STOCKADJUSTDTLRF, STOCKADJUSTDTLRF);
                        }
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
					}
					// DC在庫移動データ更新処理
					if (retCSATemList[0] is DCStockMoveWork)
					{
						DCStockMoveDB _stockMoveDB = new DCStockMoveDB();
						// 存在するデータを削除する。
						_stockMoveDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// 抽出したデータを登録する。
						_stockMoveDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(STOCKMOVERF))
                        {
                            tempSndRcvDic.Add(STOCKMOVERF, STOCKMOVERF);
                        }
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
					}
					
					// 入金引当マスタ
					if (retCSATemList[0] is DCDepositAlwWork)
					{
						DCDepositAlwDB _depositAlwDB = new DCDepositAlwDB();
						// 存在するデータを削除する。
						_depositAlwDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// 抽出したデータを登録する。
						_depositAlwDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(DEPOSITALWRF))
                        {
                            tempSndRcvDic.Add(DEPOSITALWRF, DEPOSITALWRF);
                        }
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
					}
					// 受取手形データ
					if (retCSATemList[0] is DCRcvDraftDataWork)
					{
						DCRcvDraftDataDB _rcvDraftDataDB = new DCRcvDraftDataDB();
						// 存在するデータを削除する。
						_rcvDraftDataDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// 抽出したデータを登録する。
						_rcvDraftDataDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(RCVDRAFTDATARF))
                        {
                            tempSndRcvDic.Add(RCVDRAFTDATARF, RCVDRAFTDATARF);
                        }
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
					}
					// 支払手形データ
					if (retCSATemList[0] is DCPayDraftDataWork)
					{
						DCPayDraftDataDB _payDraftDataDB = new DCPayDraftDataDB();
						// 存在するデータを削除する。
						_payDraftDataDB.Delete(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
						// 抽出したデータを登録する。
						_payDraftDataDB.Insert(retCSATemList, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                        if (!tempSndRcvDic.ContainsKey(PAYDRAFTDATARF))
                        {
                            tempSndRcvDic.Add(PAYDRAFTDATARF, PAYDRAFTDATARF);
                        }
                        // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
					}
				}

                // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                foreach (KeyValuePair<string, string> tempFileId in tempSndRcvDic)
                {
                    if (string.IsNullOrEmpty(tempSndRcvFileID))
                    {
                        tempSndRcvFileID = tempSndRcvFileID + tempFileId.Key;
                    }
                    else
                    {
                        tempSndRcvFileID = tempSndRcvFileID + "," + tempFileId.Key;
                    }

                }
                ArrayList temSndRcvHisTableWorkList = new ArrayList();
                SndRcvHisTableWork temSndRcvHisTableWork = null;

                for (int i = 0; i < logList.Count; i++)
                {
                    if (logList[i].GetType() == typeof(ArrayList))
                    {
                        ArrayList temLogList = logList[i] as ArrayList;

                        for (int j = 0; j < temLogList.Count; j++)
                        {
                            if (temLogList[j].GetType() == typeof(SndRcvHisWork))
                            {
                                temSndRcvHisTableWork = new SndRcvHisTableWork();
                                // 企業コード
                                temSndRcvHisTableWork.EnterpriseCode = ((SndRcvHisWork)temLogList[j]).EnterpriseCode;
                                // 拠点コード
                                temSndRcvHisTableWork.SectionCode = ((SndRcvHisWork)temLogList[j]).SectionCode;
                                // 送受信履歴送信番号
                                temSndRcvHisTableWork.SndRcvHisConsNo = ((SndRcvHisWork)temLogList[j]).SndRcvHisConsNo;
                                // 送受信区分:送信処理（終了）
                                temSndRcvHisTableWork.SendOrReceiveDivCd = 1;
                                // 送受信日時
                                temSndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
                                // 種別
                                temSndRcvHisTableWork.Kind = 0;
                                // 送受信ログ抽出条件区分
                                temSndRcvHisTableWork.SndLogExtraCondDiv = ((SndRcvHisWork)temLogList[j]).SndLogExtraCondDiv;
                                // 送信先企業コード
                                temSndRcvHisTableWork.SendDestEpCode = ((SndRcvHisWork)temLogList[j]).SendDestEpCode;
                                // 送信先拠点コード
                                temSndRcvHisTableWork.SendDestSecCode = ((SndRcvHisWork)temLogList[j]).SendDestSecCode;
                                //送信対象開始日時
                                temSndRcvHisTableWork.SndObjStartDate = ((SndRcvHisWork)temLogList[j]).SndObjStartDate.Ticks;
                                //送信対象終了日時
                                temSndRcvHisTableWork.SndObjEndDate = ((SndRcvHisWork)temLogList[j]).SndObjEndDate.Ticks;
                                // 送受信状態
                                temSndRcvHisTableWork.SndRcvCondition = 0;
                                // 仮受信区分
                                temSndRcvHisTableWork.TempReceiveDiv = 0;
                                // 送受信ファイルＩＤ
                                temSndRcvHisTableWork.SndRcvFileID = tempSndRcvFileID;

                                temSndRcvHisTableWorkList.Add(temSndRcvHisTableWork);
                            }
                        }
                    }
                }

                SndRcvHisTableDB temSndRcvHisTableDB = new SndRcvHisTableDB();
                object temObjSndRcvHisTableWorkList = temSndRcvHisTableWorkList as object;
                temSndRcvHisTableDB.Write(ref temObjSndRcvHisTableWorkList);
                // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
				//履歴ログ
				status3 = _logDB.WriteProc(logList, ref sqlConnection, ref sqlTransaction);

				if (status3 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					status = status3;
				}
				else
				{
					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}

			}
			catch (SqlException ex)
			{
				// 基底クラスに例外を渡して処理してもらう
				base.WriteErrorLog(ex, "DCControlDB.Update(Connection付) SqlException=" + ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                retMessage = ex.Message;    // ADD 2012/07/24 姚学剛
			}
			catch (Exception ex)
			{
				// 基底クラスに例外を渡して処理してもらう
				base.WriteErrorLog(ex, "DCControlDB.Update(Connection付) Exception=" + ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                retMessage = ex.Message;    // ADD 2012/07/24 姚学剛
			}
			finally
			{
                // ADD 2011/08/22 qijh SCM対応 - 拠点管理(10704767-00) --------->>>>>
#if !DEBUG
                if (null != intentLockObj)
                {
                    // インテントロック解除
                    intentLockObj.UnLock();
                }
#endif
                // ADD 2011/08/22 qijh SCM対応 - 拠点管理(10704767-00) ---------<<<<<

                // upd 2012/09/05 >>>
                //if (resNm != "")
                if (resNm != "" && status2 == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                // upd 2012/09/05 <<<
				{
					//ＡＰアンロック
					status2 = Release(resNm, sqlConnection, sqlTransaction);
					if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
					}
				}

				if (sqlTransaction != null)
				{
					if (sqlTransaction.Connection != null)
					{
						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						{
							sqlTransaction.Commit();
						}
						else
						{
							sqlTransaction.Rollback();
						}
					}

					sqlTransaction.Dispose();
				}

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
            // ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026-------->>>>>
            // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
            //// 処理終了日付を取得する。
            //DateTime endCurrentTime = new DateTime();
            //endCurrentTime = DateTime.Now;
            // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<

            ArrayList sndRcvHisResWorkList = new ArrayList();
            SndRcvHisTableWork sndRcvHisTableWork = new SndRcvHisTableWork();

            for (int i = 0; i < logList.Count; i++)
            {
                if (logList[i].GetType() == typeof(ArrayList))
                {
                     ArrayList al= logList[i] as ArrayList;

                     for (int j = 0; j < al.Count; j++)
                    {
                        if (al[j].GetType() == typeof(SndRcvHisWork))
                        {
                            // 企業コード
                            sndRcvHisTableWork.EnterpriseCode = ((SndRcvHisWork)al[j]).EnterpriseCode;
                            // 拠点コード
                            sndRcvHisTableWork.SectionCode = ((SndRcvHisWork)al[j]).SectionCode;
                            // 送受信履歴送信番号
                            sndRcvHisTableWork.SndRcvHisConsNo = ((SndRcvHisWork)al[j]).SndRcvHisConsNo;
                            // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            //// 送受信区分
                            //sndRcvHisTableWork.SendOrReceiveDivCd = 0;
                            // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            // 送受信区分:送信処理（送受信履歴更新）
                            sndRcvHisTableWork.SendOrReceiveDivCd = 2;
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                            // 送受信日時
                            //sndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmm"));//DEL 2012/10/16 李亜博 for redmine#31026
                            sndRcvHisTableWork.SndRcvDateTime = long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));//ADD 2012/10/16 李亜博 for redmine#31026
                            // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            //// 処理開始日時
                            //sndRcvHisTableWork.ProcStartDateTime = startCurrentTime.Ticks;
                            //// 処理終了日時
                            //sndRcvHisTableWork.ProcEndDateTime = endCurrentTime.Ticks;
                            // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                            // 種別
                            sndRcvHisTableWork.Kind = 0;
                            // 送受信ログ抽出条件区分
                            sndRcvHisTableWork.SndLogExtraCondDiv = ((SndRcvHisWork)al[j]).SndLogExtraCondDiv;
                            // 送信先企業コード
                            sndRcvHisTableWork.SendDestEpCode = ((SndRcvHisWork)al[j]).SendDestEpCode;
                            // 送信先拠点コード
                            sndRcvHisTableWork.SendDestSecCode = ((SndRcvHisWork)al[j]).SendDestSecCode;
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            //送信対象開始日時
                            sndRcvHisTableWork.SndObjStartDate = ((SndRcvHisWork)al[j]).SndObjStartDate.Ticks;
                            //送信対象終了日時
                            sndRcvHisTableWork.SndObjEndDate = ((SndRcvHisWork)al[j]).SndObjEndDate.Ticks;
                            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                            // 送受信状態
                            if (status == 0)
                            {
                                sndRcvHisTableWork.SndRcvCondition = 0;
                            }
                            else
                            {
                                sndRcvHisTableWork.SndRcvCondition = 1;
                                // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                                // エラー内容
                                if (string.IsNullOrEmpty(retMessage))
                                {
                                    sndRcvHisTableWork.SndRcvErrContents = "履歴ログ更新失敗しました。";
                                }
                                else
                                {
                                    sndRcvHisTableWork.SndRcvErrContents = retMessage;
                                }
                                // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                            }
                            // 仮受信区分
                            sndRcvHisTableWork.TempReceiveDiv = 0;
                            // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                            //// エラー内容
                            //sndRcvHisTableWork.SndRcvErrContents = retMessage;
                            // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                            // 送受信ファイルＩＤ
                            //sndRcvHisTableWork.SndRcvFileID = ((SndRcvHisWork)al[j]).SndRcvFileID;//DEL 2012/10/16 李亜博 for redmine#31026 
                            sndRcvHisTableWork.SndRcvFileID = tempSndRcvFileID;//ADD 2012/10/16 李亜博 for redmine#31026
                        }
                    }
                }
            }

            SndRcvHisTableDB sndRcvHisTableDB = new SndRcvHisTableDB();
            sndRcvHisResWorkList.Add(sndRcvHisTableWork);
            object objSndRcvHisResWorkList = sndRcvHisResWorkList as object;
            sndRcvHisTableDB.Write(ref objSndRcvHisResWorkList);

            // ------------ADD 姚学剛 2012/07/24 FOR Redmine#31026---------<<<<<

			//STATUSを戻す
			return status;
		}
		// ADD 2011/07/21 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<

        #endregion

        # region [コネクション生成処理]
        /// <summary>
        /// SqlConnection生成処理
        /// </summary>
        /// <param name="open">true:DBへ接続する　false:DBへ接続しない</param>
        /// <returns>生成されたSqlConnection、生成に失敗した場合はNullを返す。</returns>
        /// <remarks>
        /// <br>Programmer : 劉洋</br>
        /// <br>Date       : 2009.3.31</br>
        /// </remarks>
        private SqlConnection CreateSqlConnectionData(bool open)
        {
            SqlConnection retSqlConnection = null;

            SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();

            string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_Center_UserDB);

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
        /// <br>Programmer : 劉洋</br>
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

		#region [締めチェック]
		// ADD 2011/07/26 張莉莉　SCM対応‐拠点管理（10704767-00）------->>>>>>>
		/// <summary>
		/// 締めチェックします。
		/// </summary>
		/// <param name="outErrorList">検索結果</param>
		/// <param name="parareceiveWork">検索条件</param>
		/// <param name="salesSimeDate">売上締め日</param>
		/// <param name="StockSimeDate">仕入締め日</param>
		/// <param name="saleCheckFlg">売上チェックフラグ</param>
		/// <param name="depsitCheckFlg">入金チェックフラグ</param>
		/// <param name="stockCheckFlg">仕入チェックフラグ</param>
		/// <param name="paymentCheckFlg">支払いチェックフラグ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 締めチェック</br>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.07.21</br>
		public int SimeCheckSCM(out ArrayList outErrorList, DCReceiveDataWork parareceiveWork,
            Int64 salesSimeDate, Int64 StockSimeDate, bool saleCheckFlg, bool depsitCheckFlg, bool stockCheckFlg, bool paymentCheckFlg)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			SqlConnection sqlConnection = null;
			SqlTransaction sqlTransaction = null;

			DCReceiveDataWork receiveDataWork = parareceiveWork;
            outErrorList = new ArrayList();
			try
			{
				if (parareceiveWork != null)
				{
					// コネクション生成
					sqlConnection = this.CreateSqlConnectionData(true);
					sqlTransaction = this.CreateTransactionData(ref sqlConnection);

                    status = this.SimeCheckProcSCM(out outErrorList, parareceiveWork, salesSimeDate, StockSimeDate,
						saleCheckFlg, depsitCheckFlg, stockCheckFlg, paymentCheckFlg, ref sqlConnection, ref sqlTransaction);

				}
			}
			catch (SqlException e)
			{
				base.WriteErrorLog(e, "DCControlDB.simeCheckSCM(out object outerrorList, object parareceiveWork)", status);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			catch (Exception ex)
			{
				base.WriteErrorLog(ex, "DCControlDB.simeCheckSCM(out object outerrorList, object parareceiveWork)", status);
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

        /// <summary>
        /// 締めチェックします。
        /// </summary>
        /// <param name="outErrorList">検索結果</param>
        /// <param name="parareceiveWorkList">検索条件</param>
        /// <param name="salesSimeDate">売上締め日</param>
        /// <param name="StockSimeDate">仕入締め日</param>
        /// <param name="saleCheckFlg">売上チェックフラグ</param>
        /// <param name="depsitCheckFlg">入金チェックフラグ</param>
        /// <param name="stockCheckFlg">仕入チェックフラグ</param>
        /// <param name="paymentCheckFlg">支払いチェックフラグ</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 締めチェック</br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2011.07.21</br>
        public int SimeCheckSCM(out ArrayList outErrorList, ArrayList parareceiveWorkList,
            Int64 salesSimeDate, Int64 StockSimeDate, bool saleCheckFlg, bool depsitCheckFlg, bool stockCheckFlg, bool paymentCheckFlg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;

            outErrorList = new ArrayList();
            try
            {
                if (parareceiveWorkList != null && parareceiveWorkList.Count > 0)
                {
                    // コネクション生成
                    sqlConnection = this.CreateSqlConnectionData(true);
                    sqlTransaction = this.CreateTransactionData(ref sqlConnection);

                    for (int i = 0; i < parareceiveWorkList.Count; i++)
                    {
                        DCReceiveDataWork parareceiveWork = (DCReceiveDataWork)parareceiveWorkList[i];
                        ArrayList errList;
                        status = this.SimeCheckProcSCM(out errList, parareceiveWork, salesSimeDate, StockSimeDate,
                            saleCheckFlg, depsitCheckFlg, stockCheckFlg, paymentCheckFlg, ref sqlConnection, ref sqlTransaction);
                        outErrorList.AddRange(errList);
                    }
                    keylist.Clear();//ADD by Liangsd   2011/09/09 Redmine #24633

                }
            }
            catch (SqlException e)
            {
                base.WriteErrorLog(e, "DCControlDB.simeCheckSCM(out object outerrorList, object parareceiveWork)", status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "DCControlDB.simeCheckSCM(out object outerrorList, object parareceiveWork)", status);
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

		/// <summary>
		/// 締めチェックします。
		/// </summary>
		/// <param name="outErrorList">検索結果</param>
		/// <param name="parareceiveWork">検索条件</param>
		/// <param name="salesSimeDate">売上締め日</param>
		/// <param name="StockSimeDate">仕入締め日</param>
		/// <param name="saleCheckFlg">売上チェックフラグ</param>
		/// <param name="depsitCheckFlg">入金チェックフラグ</param>
		/// <param name="stockCheckFlg">仕入チェックフラグ</param>
		/// <param name="paymentCheckFlg">支払いチェックフラグ</param>
		/// <param name="sqlConnection">sqlConnection</param>
		/// <param name="sqlTransaction">sqlTransaction</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 締めチェック</br>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.07.21</br>
		private int SimeCheckProcSCM(out ArrayList outErrorList, DCReceiveDataWork parareceiveWork, Int64 salesSimeDate, Int64 StockSimeDate,
			bool saleCheckFlg, bool depsitCheckFlg, bool stockCheckFlg, bool paymentCheckFlg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			SqlDataReader myReader = null;
			SqlCommand sqlCommand = null;

			outErrorList = new ArrayList();

			string sqlText = string.Empty;
			SqlParameter findParaUpdateEndDateTime = new SqlParameter();
			SqlParameter findParaUpdateStartDateTime = new SqlParameter();
			SqlParameter findParaSectionCode = new SqlParameter();
			SqlParameter findParaSaleSimeDate = new SqlParameter();
			SqlParameter findParaStockSimeDate = new SqlParameter();
            SqlParameter findParaFindEnterPriseCode = new SqlParameter();
            if (saleCheckFlg)
			{
				sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);
				//売上データ-------------------------------------------
				StringBuilder sb = new StringBuilder();
				sb.Append("SELECT A.ENTERPRISECODERF as ENTERPRISECODERF").Append(Environment.NewLine);
				sb.Append(" ,A.ACPTANODRSTATUSRF as ACPTANODRSTATUSRF ").Append(Environment.NewLine);
				sb.Append(" ,A.SALESSLIPNUMRF as SALESSLIPNUMRF").Append(Environment.NewLine);
				sb.Append(" ,A.ADDUPADATERF as ADDUPADATERF").Append(Environment.NewLine);
				sb.Append(" ,A.RESULTSADDUPSECCDRF as RESULTSADDUPSECCDRF").Append(Environment.NewLine);
				sb.Append(" ,A.CUSTOMERCODERF as CUSTOMERCODERF").Append(Environment.NewLine);
				sb.Append(" ,A.CUSTOMERNAMERF as CUSTOMERNAMERF").Append(Environment.NewLine);
                sb.Append(" ,A.FILEHEADERGUIDRF as FILEHEADERGUIDRF").Append(Environment.NewLine);//ADD by Liangsd   2011/09/09 Redmine #24633
                sb.Append(" ,B.SECTIONGUIDENMRF as SECTIONGUIDENMRF").Append(Environment.NewLine);

				sb.Append(" FROM SALESSLIPRF A WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
				sb.Append(" LEFT JOIN SECINFOSETRF B WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
				//	売上データ.実績計上拠点コード　＝　拠点情報設定マスタ.拠点コード
				sb.Append(" ON A.RESULTSADDUPSECCDRF = B.SECTIONCODERF ").Append(Environment.NewLine);
				//	売上データ.実績計上拠点コード　＝　パラメータ.受信情報.拠点コード
				sb.Append(" WHERE A.RESULTSADDUPSECCDRF = @FINDRESULTSADDUPSECCD ").Append(Environment.NewLine);

                // --- UPD 2011/11/29 ---------------- >>>>>
                //差分送信の場合
                if (parareceiveWork.SndLogExtraCondDiv == 0)
                {
                    //	売上データ.更新日時　>　パラメータ.受信情報.開始日付
                    sb.Append(" AND A.UPDATEDATETIMERF > @FINDTIMEST ").Append(Environment.NewLine);
                    //	売上データ.更新日時　≦　パラメータ.受信情報.終了日付
                    sb.Append(" AND A.UPDATEDATETIMERF <= @FINDTIMEED ").Append(Environment.NewLine);
                }
                //伝票日付送信の場合
                else
                {
                    //	売上明細データ.売上日付(受注ステータスが40、売上明細データ.売上日付が抽出条件としないで、売上データ.入荷日付です)
                    //sb.Append("    AND(((A.ACPTANODRSTATUSRF = 40) ").Append(Environment.NewLine);  // DEL 2011/12/07
                    sb.Append("    AND ((((A.ACPTANODRSTATUSRF = 40) ").Append(Environment.NewLine);  // ADD 2011/12/07
                    sb.Append("    AND (A.SHIPMENTDAYRF>=@FINDTIMEST) ").Append(Environment.NewLine);
                    sb.Append("    AND (A.SHIPMENTDAYRF<=@FINDTIMEED)) ").Append(Environment.NewLine);
                    sb.Append("    OR ((A.ACPTANODRSTATUSRF<>40) ").Append(Environment.NewLine);
                    sb.Append("    AND (A.SALESDATERF>=@FINDTIMEST) ").Append(Environment.NewLine);
                    sb.Append("    AND (A.SALESDATERF<=@FINDTIMEED)))").Append(Environment.NewLine);

                    // ADD 2011/12/07   ----------- >>>>>>>>>>>>
                    sb.Append("    OR ((A.UPDATEDATETIMERF >= @FINDTIME) ").Append(Environment.NewLine);
                    sb.Append("        AND (A.UPDATEDATETIMERF <= @FINDTIMETICKSED) ").Append(Environment.NewLine);
                    sb.Append("        AND (((A.ACPTANODRSTATUSRF = 40) ").Append(Environment.NewLine);
                    sb.Append("        AND (A.SHIPMENTDAYRF<=@FINDTIMEED)) ").Append(Environment.NewLine);
                    sb.Append("        OR ((A.ACPTANODRSTATUSRF <> 40) ").Append(Environment.NewLine);
                    sb.Append("        AND (A.SALESDATERF<=@FINDTIMEED))))) ").Append(Environment.NewLine);
                    // ADD 2011/12/07   ----------- <<<<<<<<<<<<
                }
                // --- UPD 2011/11/29 ---------------- <<<<<

				//	売上データ.計上日付　≦　パラメータ.売上締め日
				sb.Append(" AND A.ADDUPADATERF <= @FINDSALESIMEDATE ").Append(Environment.NewLine);
                //売上データ.企業コード = パラメータ.受信情報.送信元企業コード
                sb.Append(" AND  A.ENTERPRISECODERF = @FINDENTERPRISECODERF ").Append(Environment.NewLine);//ADD by Liangsd    2011/09/09 Redmine #24633
                //売上データ.入金引当合計額 != 0
                sb.Append(" AND  A.DEPOSITALLOWANCETTLRF = 0 ").Append(Environment.NewLine);  //ADD 2011/09/28 M.Kubota
                //売上データ.赤伝区分 != 2
                sb.Append(" AND  A.DEBITNOTEDIVRF != 2 ").Append(Environment.NewLine);        //ADD 2011/09/28 M.Kubota
                
				sqlText = sb.ToString();

				//Prameterオブジェクトの作成
				findParaUpdateEndDateTime = sqlCommand.Parameters.Add("@FINDTIMEST", SqlDbType.BigInt);
				findParaUpdateStartDateTime = sqlCommand.Parameters.Add("@FINDTIMEED", SqlDbType.BigInt);
				findParaSectionCode = sqlCommand.Parameters.Add("@FINDRESULTSADDUPSECCD", SqlDbType.NChar);
                findParaSaleSimeDate = sqlCommand.Parameters.Add("@FINDSALESIMEDATE", SqlDbType.BigInt);
                findParaFindEnterPriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);//ADD by Liangsd    2011/09/09 Redmine #24633

				//Parameterオブジェクトへ値設定

                // --- DEL 2011/11/29 ---------------- >>>>>
                //findParaUpdateEndDateTime.Value = parareceiveWork.StartDateTime;
                //findParaUpdateStartDateTime.Value = parareceiveWork.EndDateTime;
                // --- DEL 2011/11/29 ---------------- <<<<<

                // --- ADD 2011/11/29 ---------------- >>>>>
                //差分送信の場合
                if (parareceiveWork.SndLogExtraCondDiv == 0)
                {
                    findParaUpdateEndDateTime.Value = parareceiveWork.StartDateTime;
                    findParaUpdateStartDateTime.Value = parareceiveWork.EndDateTime;
                }
                else
                {
                    DateTime tempDateTimeSt = new DateTime(parareceiveWork.StartDateTime);
                    DateTime tempDateTimeEd = new DateTime(parareceiveWork.EndDateTime);
                    findParaUpdateEndDateTime.Value = Convert.ToInt32(tempDateTimeSt.ToString("yyyyMMdd"));
                    findParaUpdateStartDateTime.Value = Convert.ToInt32(tempDateTimeEd.ToString("yyyyMMdd"));

                    // ADD 2011/12/07   ----------- >>>>>>>>>>>>
                    SqlParameter findParaDateTime = new SqlParameter();
                    findParaDateTime = sqlCommand.Parameters.Add("@FINDTIME", SqlDbType.BigInt);
                    findParaDateTime.Value = parareceiveWork.EndDateTimeTicks;
                    SqlParameter findParaEndDateTime = new SqlParameter();
                    findParaEndDateTime = sqlCommand.Parameters.Add("@FINDTIMETICKSED", SqlDbType.BigInt);
                    findParaEndDateTime.Value = parareceiveWork.EndDateTime;
                    // ADD 2011/12/07   ----------- <<<<<<<<<<<<
                }
                // --- ADD 2011/11/29 ---------------- <<<<<


				findParaSectionCode.Value = parareceiveWork.PmSectionCode;
				findParaSaleSimeDate.Value = salesSimeDate;
                findParaFindEnterPriseCode.Value = parareceiveWork.PmEnterpriseCode;//ADD by Liangsd    2011/09/09 Redmine #24633

				// SQL文
				sqlCommand.CommandText = sqlText;
                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                myReader = sqlCommand.ExecuteReader();
				while (myReader.Read())
				{
                    //outErrorList.Add(this.CopyToErrorDataWorkFromReader(ref myReader, 0));//DEL by Liangsd    2011/09/09 Redmine #24633
                    //ADD by Liangsd   2011/09/09 Redmine #24633----------------->>>>>>>>>>
                    string hKey = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF")).ToString();
                    if (keylist.Contains(hKey) == false)
                    {
                        outErrorList.Add(this.CopyToErrorDataWorkFromReader(ref myReader, 0));
                        keylist.Add(hKey);
                    }
                    //ADD by Liangsd   2011/09/09 Redmine #24633-----------------<<<<<<<<<<
				}
			}

            if (myReader != null)
            {
                if (!myReader.IsClosed)
                {
                    myReader.Close();
                }

                myReader.Dispose();
            }

            if (sqlCommand != null)
            {
                sqlCommand.Cancel();
                sqlCommand.Dispose();
            }

            if (depsitCheckFlg)
			{
				// 入金データ-------------------------------------------
				sqlText = string.Empty;
				sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

				StringBuilder sb = new StringBuilder();
				sb.Append("SELECT A.ENTERPRISECODERF as ENTERPRISECODERF").Append(Environment.NewLine);
				sb.Append(" ,A.ACPTANODRSTATUSRF as ACPTANODRSTATUSRF ").Append(Environment.NewLine);
				sb.Append(" ,A.DEPOSITSLIPNORF as SALESSLIPNUMRF").Append(Environment.NewLine);
				sb.Append(" ,A.ADDUPADATERF as ADDUPADATERF").Append(Environment.NewLine);
				sb.Append(" ,A.ADDUPSECCODERF as RESULTSADDUPSECCDRF").Append(Environment.NewLine);
				sb.Append(" ,A.CUSTOMERCODERF as CUSTOMERCODERF").Append(Environment.NewLine);
                sb.Append(" ,A.CUSTOMERNAMERF as CUSTOMERNAMERF").Append(Environment.NewLine);
                sb.Append(" ,A.FILEHEADERGUIDRF as FILEHEADERGUIDRF").Append(Environment.NewLine);//ADD by Liangsd   2011/09/09 Redmine #24633
				sb.Append(" ,B.SECTIONGUIDENMRF as SECTIONGUIDENMRF").Append(Environment.NewLine);

				sb.Append(" FROM DEPSITMAINRF A WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
				sb.Append(" LEFT JOIN SECINFOSETRF B WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
				// 入金データ.計上拠点コード　＝　拠点情報設定マスタ.拠点コード
				sb.Append(" ON A.ADDUPSECCODERF = B.SECTIONCODERF ").Append(Environment.NewLine);
				//	入金データ.計上拠点コード　＝　パラメータ.受信情報.拠点コード
				sb.Append(" WHERE A.ADDUPSECCODERF = @FINDRESULTSADDUPSECCD ").Append(Environment.NewLine);

                // --- DEL 2011/11/29 ---------------- >>>>>

                ////	入金データ.更新日時　>　パラメータ.受信情報.開始日付
                //sb.Append(" AND A.UPDATEDATETIMERF > @FINDTIMEST ").Append(Environment.NewLine);
                ////	入金データ.更新日時　≦　パラメータ.受信情報.終了日付
                //sb.Append(" AND A.UPDATEDATETIMERF <= @FINDTIMEED ").Append(Environment.NewLine);
                // --- DEL 2011/11/29 ---------------- <<<<<<

                // --- ADD 2011/11/29 ---------------- >>>>>
                //差分送信の場合
                if (parareceiveWork.SndLogExtraCondDiv == 0)
                {
                    //	入金データ.更新日時　>　パラメータ.受信情報.開始日付
                    sb.Append(" AND A.UPDATEDATETIMERF > @FINDTIMEST ").Append(Environment.NewLine);
                    //	入金データ.更新日時　≦　パラメータ.受信情報.終了日付
                    sb.Append(" AND A.UPDATEDATETIMERF <= @FINDTIMEED ").Append(Environment.NewLine);
                }
                //伝票日付送信の場合
                else
                {
                    //	入金データ.入金日付　>=　パラメータ.開始日付
                    //sb.Append(" AND A.DEPOSITDATERF >= @FINDTIMEST ").Append(Environment.NewLine);  // DEL 2011/12/07
                    ////	入金データ.入金日付　≦　パラメータ.受信情報.終了日付
                    //sb.Append(" AND A.DEPOSITDATERF <= @FINDTIMEED ").Append(Environment.NewLine);  // DEL 2011/12/07

                    // ADD 2011/12/07   ----------- >>>>>>>>>>>>
                    //	入金データ.入金日付　>=　パラメータ.開始日付
                    sb.Append(" AND ((A.DEPOSITDATERF >= @FINDTIMEST ").Append(Environment.NewLine);
                    //	入金データ.入金日付　≦　パラメータ.受信情報.終了日付
                    sb.Append(" AND A.DEPOSITDATERF <= @FINDTIMEED) ").Append(Environment.NewLine);

                    sb.Append("    OR ((A.UPDATEDATETIMERF >= @FINDTIME) ").Append(Environment.NewLine);
                    sb.Append("        AND (A.UPDATEDATETIMERF <= @FINDTIMETICKSED) ").Append(Environment.NewLine);
                    sb.Append("        AND (A.DEPOSITDATERF<=@FINDTIMEED))) ").Append(Environment.NewLine);
                    // ADD 2011/12/07   ----------- <<<<<<<<<<<<
                }
                // --- ADD 2011/11/29 ---------------- <<<<<


				//	入金データ.計上日付　≦　パラメータ.売上締め日
				sb.Append(" AND A.ADDUPADATERF <= @FINDSALESIMEDATE ").Append(Environment.NewLine);
                sb.Append(" AND A.ENTERPRISECODERF = @FINDENTERPRISECODERF ").Append(Environment.NewLine);//ADD by Liangsd    2011/09/09 Redmine #24633
				sqlText = sb.ToString();

				//Prameterオブジェクトの作成

                findParaUpdateEndDateTime = sqlCommand.Parameters.Add("@FINDTIMEST", SqlDbType.BigInt);
                findParaUpdateStartDateTime = sqlCommand.Parameters.Add("@FINDTIMEED", SqlDbType.BigInt);
				findParaSectionCode = sqlCommand.Parameters.Add("@FINDRESULTSADDUPSECCD", SqlDbType.NChar);
                findParaSaleSimeDate = sqlCommand.Parameters.Add("@FINDSALESIMEDATE", SqlDbType.BigInt);
                findParaFindEnterPriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);//ADD by Liangsd    2011/09/09 Redmine #24633

				//Parameterオブジェクトへ値設定

                // --- DEL 2011/11/29 ---------------- >>>>>
                //findParaUpdateEndDateTime.Value = parareceiveWork.StartDateTime;
                //findParaUpdateStartDateTime.Value = parareceiveWork.EndDateTime;
                // --- DEL 2011/11/29 ---------------- <<<<<

                // --- ADD 2011/11/29 ---------------- >>>>>
                //差分送信の場合
                if (parareceiveWork.SndLogExtraCondDiv == 0)
                {
                    findParaUpdateEndDateTime.Value = parareceiveWork.StartDateTime;
                    findParaUpdateStartDateTime.Value = parareceiveWork.EndDateTime;
                }
                else
                {
                    DateTime tempDateTimeSt = new DateTime(parareceiveWork.StartDateTime);
                    DateTime tempDateTimeEd = new DateTime(parareceiveWork.EndDateTime);
                    findParaUpdateEndDateTime.Value = Convert.ToInt32(tempDateTimeSt.ToString("yyyyMMdd"));
                    findParaUpdateStartDateTime.Value = Convert.ToInt32(tempDateTimeEd.ToString("yyyyMMdd"));

                    // ADD 2011/12/07   ----------- >>>>>>>>>>>>
                    SqlParameter findParaDateTime = new SqlParameter();
                    findParaDateTime = sqlCommand.Parameters.Add("@FINDTIME", SqlDbType.BigInt);
                    findParaDateTime.Value = parareceiveWork.EndDateTimeTicks;
                    SqlParameter findParaEndDateTime = new SqlParameter();
                    findParaEndDateTime = sqlCommand.Parameters.Add("@FINDTIMETICKSED", SqlDbType.BigInt);
                    findParaEndDateTime.Value = parareceiveWork.EndDateTime;
                    // ADD 2011/12/07   ----------- <<<<<<<<<<<<
                }
                // --- ADD 2011/11/29 ---------------- <<<<<

				findParaSectionCode.Value = parareceiveWork.PmSectionCode;
                findParaSaleSimeDate.Value = salesSimeDate;
                findParaFindEnterPriseCode.Value = parareceiveWork.PmEnterpriseCode;//ADD by Liangsd   2011/09/09 Redmine #24633

				// SQL文
				sqlCommand.CommandText = sqlText;
                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                myReader = sqlCommand.ExecuteReader();
				while (myReader.Read())
				{
                    //outErrorList.Add(this.CopyToErrorDataWorkFromReader(ref myReader, 1));//DEL by Liangsd    2011/09/09 Redmine #24633
                    //ADD by Liangsd   2011/09/09 Redmine #24633----------------->>>>>>>>>>
                    string hKey = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF")).ToString();
                    if (keylist.Contains(hKey) == false)
                    {
                        outErrorList.Add(this.CopyToErrorDataWorkFromReader(ref myReader, 1));
                        keylist.Add(hKey);
                    }
                    //ADD by Liangsd   2011/09/09 Redmine #24633-----------------<<<<<<<<<<
				}
			}

            if (myReader != null)
            {
                if (!myReader.IsClosed)
                {
                    myReader.Close();
                }

                myReader.Dispose();
            }

            if (sqlCommand != null)
            {
                sqlCommand.Cancel();
                sqlCommand.Dispose();
            }

			if (stockCheckFlg)
			{
				// 仕入データ-------------------------------------------
				sqlText = string.Empty;
				sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

				StringBuilder sb = new StringBuilder();
				sb.Append("SELECT A.ENTERPRISECODERF as ENTERPRISECODERF").Append(Environment.NewLine);
				sb.Append(" ,A.SUPPLIERFORMALRF as ACPTANODRSTATUSRF ").Append(Environment.NewLine);
				sb.Append(" ,A.SUPPLIERSLIPNORF as SALESSLIPNUMRF").Append(Environment.NewLine);
				sb.Append(" ,A.STOCKADDUPADATERF as ADDUPADATERF").Append(Environment.NewLine);
				//sb.Append(" ,A.STOCKADDUPSECTIONCDRF as RESULTSADDUPSECCDRF").Append(Environment.NewLine);  // DEL 2011/11/29
                sb.Append(" ,A.STOCKSECTIONCDRF as RESULTSADDUPSECCDRF").Append(Environment.NewLine);   // ADD 2011/11/29
				sb.Append(" ,A.SUPPLIERCDRF as CUSTOMERCODERF").Append(Environment.NewLine);
                sb.Append(" ,A.SUPPLIERSNMRF as CUSTOMERNAMERF").Append(Environment.NewLine);
                sb.Append(" ,A.FILEHEADERGUIDRF as FILEHEADERGUIDRF").Append(Environment.NewLine);//ADD by Liangsd   2011/09/09 Redmine #24633
				sb.Append(" ,B.SECTIONGUIDENMRF as SECTIONGUIDENMRF").Append(Environment.NewLine);

				sb.Append(" FROM STOCKSLIPRF A WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
				sb.Append(" LEFT JOIN SECINFOSETRF B WITH (READUNCOMMITTED) ").Append(Environment.NewLine);

                // --- DEL 2011/11/29 ---------------- >>>>>

                ////	仕入データ.仕入計上拠点コード　＝　拠点情報設定マスタ.拠点コード
                //sb.Append(" ON A.STOCKADDUPSECTIONCDRF = B.SECTIONCODERF ").Append(Environment.NewLine);
                ////	仕入データ.仕入計上拠点コード　＝　パラメータ.受信情報.拠点コード
                //sb.Append(" WHERE A.STOCKADDUPSECTIONCDRF = @FINDRESULTSADDUPSECCD ").Append(Environment.NewLine);
                

                ////	仕入データ.更新日時　>　パラメータ.受信情報.開始日付
                //sb.Append(" AND A.UPDATEDATETIMERF > @FINDTIMEST ").Append(Environment.NewLine);
                ////	仕入データ.更新日時　≦　パラメータ.受信情報.終了日付
                //sb.Append(" AND A.UPDATEDATETIMERF <= @FINDTIMEED ").Append(Environment.NewLine);
                // --- DEL 2011/11/29 ---------------- <<<<<

                // --- ADD 2011/11/29 ---------------- >>>>>
                //	仕入データ.仕入拠点コード　＝　拠点情報設定マスタ.拠点コード
                sb.Append(" ON A.STOCKSECTIONCDRF = B.SECTIONCODERF ").Append(Environment.NewLine);
                //	仕入データ.仕入拠点コード　＝　パラメータ.受信情報.拠点コード
                sb.Append(" WHERE A.STOCKSECTIONCDRF = @FINDRESULTSADDUPSECCD ").Append(Environment.NewLine);

                //差分送信の場合
                if (parareceiveWork.SndLogExtraCondDiv == 0)
                {
                    //	仕入データ.更新日時　>　パラメータ.受信情報.開始日付
                    sb.Append(" AND A.UPDATEDATETIMERF >= @FINDTIMEST ").Append(Environment.NewLine);
                    //	仕入データ.更新日時　≦　パラメータ.受信情報.終了日付
                    sb.Append(" AND A.UPDATEDATETIMERF <= @FINDTIMEED ").Append(Environment.NewLine);
                }
                //伝票日付送信の場合
                else
                {
                    //1:入荷=>入荷日付
                    //sb.Append(" AND ((A.SUPPLIERFORMALRF=1 ").Append(Environment.NewLine);  // DEL 2011/12/07
                    sb.Append(" AND (((A.SUPPLIERFORMALRF=1 ").Append(Environment.NewLine);    // ADD 2011/12/07
                    //	仕入データ.入荷日付　≧　パラメータ.開始日付
                    sb.Append(" AND A.ARRIVALGOODSDAYRF>=@FINDTIMEST").Append(Environment.NewLine);
                    //	仕入データ.入荷日付　≦　パラメータ.終了日付
                    sb.Append(" AND A.ARRIVALGOODSDAYRF<=@FINDTIMEED ").Append(Environment.NewLine);
                    sb.Append(" ) OR ").Append(Environment.NewLine);
                    //0:仕入,2:発注=>仕入日付
                    sb.Append(" (A.SUPPLIERFORMALRF<>1 ").Append(Environment.NewLine);
                    //-----Add 2011/11/01 陳建明 for #26228 end-----<<<<<<    
                    //	仕入データ.仕入日　≧　パラメータ.開始日付
                    sb.Append(" AND A.STOCKDATERF>=@FINDTIMEST ").Append(Environment.NewLine);
                    //	仕入データ.仕入日　≦　パラメータ.終了日付
                    sb.Append(" AND A.STOCKDATERF<=@FINDTIMEED ").Append(Environment.NewLine);
                    sb.Append(" ))");

                    // ADD 2011/12/07   ----------- >>>>>>>>>>>>
                    sb.Append("    OR ((A.UPDATEDATETIMERF >= @FINDTIME) ").Append(Environment.NewLine);
                    sb.Append("        AND (A.UPDATEDATETIMERF <= @FINDTIMETICKSED) ").Append(Environment.NewLine);
                    sb.Append("        AND (((A.SUPPLIERFORMALRF = 1) ").Append(Environment.NewLine);
                    sb.Append("        AND (A.ARRIVALGOODSDAYRF<=@FINDTIMEED)) ").Append(Environment.NewLine);
                    sb.Append("        OR ((A.SUPPLIERFORMALRF <> 1) ").Append(Environment.NewLine);
                    sb.Append("        AND (A.STOCKDATERF<=@FINDTIMEED))))) ").Append(Environment.NewLine);
                    // ADD 2011/12/07   ----------- <<<<<<<<<<<<
                }
                // --- ADD 2011/11/29 ---------------- <<<<<


				//	仕入データ.仕入計上日付　≦　パラメータ.仕入締め日
				sb.Append(" AND A.STOCKADDUPADATERF <= @FINDSTOCKSIMEDATE ").Append(Environment.NewLine);
                sb.Append(" AND A.ENTERPRISECODERF = @FINDENTERPRISECODERF ").Append(Environment.NewLine);//ADD by Liangsd    2011/09/09 Redmine #24633
                //  仕入データ.赤伝区分 != 2
                sb.Append(" AND A.DEBITNOTEDIVRF != 2 ").Append(Environment.NewLine);  //ADD 2011/09/28 M.Kubota

				sqlText = sb.ToString();

				//Prameterオブジェクトの作成
				findParaUpdateEndDateTime = sqlCommand.Parameters.Add("@FINDTIMEST", SqlDbType.BigInt);
				findParaUpdateStartDateTime = sqlCommand.Parameters.Add("@FINDTIMEED", SqlDbType.BigInt);
				findParaSectionCode = sqlCommand.Parameters.Add("@FINDRESULTSADDUPSECCD", SqlDbType.NChar);
                findParaStockSimeDate = sqlCommand.Parameters.Add("@FINDSTOCKSIMEDATE", SqlDbType.BigInt);
                findParaFindEnterPriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);//ADD by Liangsd    2011/09/09 Redmine #24633

				//Parameterオブジェクトへ値設定

                // --- DEL 2011/11/29 ---------------- >>>>>
                //findParaUpdateEndDateTime.Value = parareceiveWork.StartDateTime;
                //findParaUpdateStartDateTime.Value = parareceiveWork.EndDateTime;
                // --- DEL 2011/11/29 ---------------- <<<<<
                // --- ADD 2011/11/29 ---------------- >>>>>
                //差分送信の場合
                if (parareceiveWork.SndLogExtraCondDiv == 0)
                {
                    findParaUpdateEndDateTime.Value = parareceiveWork.StartDateTime;
                    findParaUpdateStartDateTime.Value = parareceiveWork.EndDateTime;
                }
                else
                {
                    DateTime tempDateTimeSt = new DateTime(parareceiveWork.StartDateTime);
                    DateTime tempDateTimeEd = new DateTime(parareceiveWork.EndDateTime);
                    findParaUpdateEndDateTime.Value = Convert.ToInt32(tempDateTimeSt.ToString("yyyyMMdd"));
                    findParaUpdateStartDateTime.Value = Convert.ToInt32(tempDateTimeEd.ToString("yyyyMMdd"));

                    // ADD 2011/12/07   ----------- >>>>>>>>>>>>
                    SqlParameter findParaDateTime = new SqlParameter();
                    findParaDateTime = sqlCommand.Parameters.Add("@FINDTIME", SqlDbType.BigInt);
                    findParaDateTime.Value = parareceiveWork.EndDateTimeTicks;
                    SqlParameter findParaEndDateTime = new SqlParameter();
                    findParaEndDateTime = sqlCommand.Parameters.Add("@FINDTIMETICKSED", SqlDbType.BigInt);
                    findParaEndDateTime.Value = parareceiveWork.EndDateTime;
                    // ADD 2011/12/07   ----------- <<<<<<<<<<<<
                }
                // --- ADD 2011/11/29 ---------------- <<<<<

				findParaSectionCode.Value = parareceiveWork.PmSectionCode;
				findParaStockSimeDate.Value = StockSimeDate;
                findParaFindEnterPriseCode.Value = parareceiveWork.PmEnterpriseCode;//ADD by Liangsd    2011/09/09 Redmine #24633

				// SQL文
				sqlCommand.CommandText = sqlText;
                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                myReader = sqlCommand.ExecuteReader();
				while (myReader.Read())
				{
                    //outErrorList.Add(this.CopyToErrorDataWorkFromReader(ref myReader, 2));//DEL by Liangsd    2011/09/09 Redmine #24633
                    //ADD by Liangsd   2011/09/09 Redmine #24633----------------->>>>>>>>>>
                    string hKey = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF")).ToString();
                    if (keylist.Contains(hKey) == false)
                    {
                        outErrorList.Add(this.CopyToErrorDataWorkFromReader(ref myReader, 2));
                        keylist.Add(hKey);
                    }
                    //ADD by Liangsd   2011/09/09 Redmine #24633-----------------<<<<<<<<<<
				}
			}

            if (myReader != null)
            {
                if (!myReader.IsClosed)
                {
                    myReader.Close();
                }

                myReader.Dispose();
            }

            if (sqlCommand != null)
            {
                sqlCommand.Cancel();
                sqlCommand.Dispose();
            }

			if (paymentCheckFlg)
			{
				// 支払伝票データ-------------------------------------------
				sqlText = string.Empty;
				sqlCommand = new SqlCommand(sqlText, sqlConnection, sqlTransaction);

				StringBuilder sb = new StringBuilder();
				sb.Append("SELECT A.ENTERPRISECODERF as ENTERPRISECODERF").Append(Environment.NewLine);
				sb.Append(" ,A.SUPPLIERFORMALRF as ACPTANODRSTATUSRF ").Append(Environment.NewLine);
				sb.Append(" ,A.PAYMENTSLIPNORF as SALESSLIPNUMRF").Append(Environment.NewLine);
				sb.Append(" ,A.ADDUPADATERF as ADDUPADATERF").Append(Environment.NewLine);
				sb.Append(" ,A.ADDUPSECCODERF as RESULTSADDUPSECCDRF").Append(Environment.NewLine);
				sb.Append(" ,A.SUPPLIERCDRF as CUSTOMERCODERF").Append(Environment.NewLine);
                sb.Append(" ,A.SUPPLIERSNMRF as CUSTOMERNAMERF").Append(Environment.NewLine);
                sb.Append(" ,A.FILEHEADERGUIDRF as FILEHEADERGUIDRF").Append(Environment.NewLine);//ADD by Liangsd   2011/09/09 Redmine #24633
				sb.Append(" ,B.SECTIONGUIDENMRF as SECTIONGUIDENMRF").Append(Environment.NewLine);

				sb.Append(" FROM PAYMENTSLPRF A WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
				sb.Append(" LEFT JOIN SECINFOSETRF B WITH (READUNCOMMITTED) ").Append(Environment.NewLine);
				//	支払伝票データ.計上拠点コード　＝　拠点情報設定マスタ.拠点コード
				sb.Append(" ON A.ADDUPSECCODERF = B.SECTIONCODERF ").Append(Environment.NewLine);
				//	支払伝票データ.計上拠点コード　＝　パラメータ.受信情報.拠点コード
				sb.Append(" WHERE A.ADDUPSECCODERF = @FINDRESULTSADDUPSECCD ").Append(Environment.NewLine);

                // --- DEL 2011/11/29 ---------------- >>>>>
                ////	支払伝票データ.更新日時　>　パラメータ.受信情報.開始日付
                //sb.Append(" AND A.UPDATEDATETIMERF > @FINDTIMEST ").Append(Environment.NewLine);
                ////	支払伝票データ.更新日時　≦　パラメータ.受信情報.終了日付
                //sb.Append(" AND A.UPDATEDATETIMERF <= @FINDTIMEED ").Append(Environment.NewLine);
                // --- DEL 2011/11/29 ---------------- <<<<<

                // --- ADD 2011/11/29 ---------------- >>>>>
                //差分送信の場合
                if (parareceiveWork.SndLogExtraCondDiv == 0)
                {
                    //	支払伝票データ.更新日時　>　パラメータ.受信情報.開始日付
                    sb.Append(" AND A.UPDATEDATETIMERF > @FINDTIMEST ").Append(Environment.NewLine);
                    //	支払伝票データ.更新日時　≦　パラメータ.受信情報.終了日付
                    sb.Append(" AND A.UPDATEDATETIMERF <= @FINDTIMEED ").Append(Environment.NewLine);
                }
                //伝票日付送信の場合
                else
                {
                    //	支払伝票データ.支払日付　>=　パラメータ.開始日付
                    //sb.Append(" AND A.PAYMENTDATERF>=@FINDTIMEST ").Append(Environment.NewLine);
                    ////	支払伝票データ.支払日付　≦　パラメータ.終了日付
                    //sb.Append(" AND A.PAYMENTDATERF<=@FINDTIMEED  ").Append(Environment.NewLine);

                    // ADD 2011/12/07   ----------- >>>>>>>>>>>>
                    //	支払伝票データ.支払日付　>=　パラメータ.開始日付
                    sb.Append(" AND ((A.PAYMENTDATERF>=@FINDTIMEST ").Append(Environment.NewLine);
                    //	支払伝票データ.支払日付　≦　パラメータ.終了日付
                    sb.Append(" AND A.PAYMENTDATERF<=@FINDTIMEED)  ").Append(Environment.NewLine);

                    sb.Append("    OR ((A.UPDATEDATETIMERF >= @FINDTIME) ").Append(Environment.NewLine);
                    sb.Append("        AND (A.UPDATEDATETIMERF <= @FINDTIMETICKSED) ").Append(Environment.NewLine);
                    sb.Append("        AND (A.PAYMENTDATERF<=@FINDTIMEED))) ").Append(Environment.NewLine);
                    // ADD 2011/12/07   ----------- <<<<<<<<<<<<
                }
                // --- ADD 2011/11/29 ---------------- <<<<<<

				//	支払伝票データ.計上日付　≦　パラメータ.仕入締め日
				sb.Append(" AND A.ADDUPADATERF <= @FINDSTOCKSIMEDATE ").Append(Environment.NewLine);
                sb.Append(" AND A.ENTERPRISECODERF = @FINDENTERPRISECODERF ").Append(Environment.NewLine);//ADD by Liangsd    2011/09/09 Redmine #24633
				sqlText = sb.ToString();

				//Prameterオブジェクトの作成
				findParaUpdateEndDateTime = sqlCommand.Parameters.Add("@FINDTIMEST", SqlDbType.BigInt);
				findParaUpdateStartDateTime = sqlCommand.Parameters.Add("@FINDTIMEED", SqlDbType.BigInt);
				findParaSectionCode = sqlCommand.Parameters.Add("@FINDRESULTSADDUPSECCD", SqlDbType.NChar);
                findParaStockSimeDate = sqlCommand.Parameters.Add("@FINDSTOCKSIMEDATE", SqlDbType.BigInt);
                findParaFindEnterPriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODERF", SqlDbType.NChar);//ADD by Liangsd    2011/09/09 Redmine #24633

				//Parameterオブジェクトへ値設定

                // --- DEL 2011/11/29 ---------------- >>>>>
                //findParaUpdateEndDateTime.Value = parareceiveWork.StartDateTime;
                //findParaUpdateStartDateTime.Value = parareceiveWork.EndDateTime;
                // --- DEL 2011/11/29 ---------------- <<<<<

                // --- ADD 2011/11/29 ---------------- >>>>>
                //差分送信の場合
                if (parareceiveWork.SndLogExtraCondDiv == 0)
                {
                    findParaUpdateEndDateTime.Value = parareceiveWork.StartDateTime;
                    findParaUpdateStartDateTime.Value = parareceiveWork.EndDateTime;
                }
                else
                {
                    DateTime tempDateTimeSt = new DateTime(parareceiveWork.StartDateTime);
                    DateTime tempDateTimeEd = new DateTime(parareceiveWork.EndDateTime);
                    findParaUpdateEndDateTime.Value = Convert.ToInt32(tempDateTimeSt.ToString("yyyyMMdd"));
                    findParaUpdateStartDateTime.Value = Convert.ToInt32(tempDateTimeEd.ToString("yyyyMMdd"));

                    // ADD 2011/12/07   ----------- >>>>>>>>>>>>
                    SqlParameter findParaDateTime = new SqlParameter();
                    findParaDateTime = sqlCommand.Parameters.Add("@FINDTIME", SqlDbType.BigInt);
                    findParaDateTime.Value = parareceiveWork.EndDateTimeTicks;
                    SqlParameter findParaEndDateTime = new SqlParameter();
                    findParaEndDateTime = sqlCommand.Parameters.Add("@FINDTIMETICKSED", SqlDbType.BigInt);
                    findParaEndDateTime.Value = parareceiveWork.EndDateTime;
                    // ADD 2011/12/07   ----------- <<<<<<<<<<<<
                }
                // --- ADD 2011/11/29 ---------------- <<<<<

				findParaSectionCode.Value = parareceiveWork.PmSectionCode;
				findParaStockSimeDate.Value = StockSimeDate;
                findParaFindEnterPriseCode.Value = parareceiveWork.PmEnterpriseCode;//ADD by Liangsd    2011/09/09 Redmine #24633

				// SQL文
				sqlCommand.CommandText = sqlText;
                //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
                sqlCommand.CommandTimeout = 600;
                //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
                myReader = sqlCommand.ExecuteReader();
				while (myReader.Read())
				{
                    //outErrorList.Add(this.CopyToErrorDataWorkFromReader(ref myReader, 3));//DEL by Liangsd    2011/09/09 Redmine #24633
                    //ADD by Liangsd   2011/09/09 Redmine #24633----------------->>>>>>>>>>
                    string hKey = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF")).ToString();
                    if (keylist.Contains(hKey) == false)
                    {
                        outErrorList.Add(this.CopyToErrorDataWorkFromReader(ref myReader, 3));
                        keylist.Add(hKey);
                    }
                    //ADD by Liangsd   2011/09/09 Redmine #24633-----------------<<<<<<<<<<
				}
			}

			if (outErrorList.Count > 0)
			{
				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			else
			{
				status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}

			if (myReader != null)
			{
				if (!myReader.IsClosed)
				{
					myReader.Close();
				}

				myReader.Dispose();
			}

			if (sqlCommand != null)
			{
				sqlCommand.Cancel();
				sqlCommand.Dispose();
			}

			return status;
		}

		/// <summary>
		/// クラス格納処理 Reader → eRInfoDataWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="mode">mode</param>
		/// <returns>オブジェクト</returns>
		/// <remarks>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.7.26</br>
		/// </remarks>
		private ERInfoDataWork CopyToErrorDataWorkFromReader(ref SqlDataReader myReader, int mode)
		{
			ERInfoDataWork eRInfoDataWork = new ERInfoDataWork();

			this.CopyToErrorDataWorkFromReader(ref myReader, ref eRInfoDataWork, mode);

			return eRInfoDataWork;
		}

		/// <summary>
		/// クラス格納処理 Reader → eRInfoDataWork
		/// </summary>
		/// <param name="myReader">SqlDataReader</param>
		/// <param name="eRInfoDataWork">eRInfoDataWork オブジェクト</param>
		/// <param name="mode">mode</param>
		/// <returns>void</returns>
		/// <remarks>
		/// <br>Programmer : 張莉莉</br>
		/// <br>Date       : 2011.7.26</br>
		/// </remarks>
		private void CopyToErrorDataWorkFromReader(ref SqlDataReader myReader, ref ERInfoDataWork eRInfoDataWork, int mode)
		{
			if (myReader != null && eRInfoDataWork != null)
			{
				# region クラスへ格納
				switch (mode)
				{
					case 0:
						eRInfoDataWork.ErSlipNm = "売上";
                        eRInfoDataWork.ErSalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
						break;
					case 1:
						eRInfoDataWork.ErSlipNm = "入金";
                        eRInfoDataWork.ErSalesSlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPNUMRF")).ToString();
						break;
					case 2:
						eRInfoDataWork.ErSlipNm = "仕入";
                        eRInfoDataWork.ErSalesSlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPNUMRF")).ToString();
						break;
					case 3:
						eRInfoDataWork.ErSlipNm = "支払";
                        eRInfoDataWork.ErSalesSlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPNUMRF")).ToString();
						break;
					default:
						break;
				}
				eRInfoDataWork.ErDateTime = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDUPADATERF"));
				eRInfoDataWork.ErSectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
				eRInfoDataWork.ErSectionNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONGUIDENMRF"));
				eRInfoDataWork.ErCustCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
				eRInfoDataWork.ErCustName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
				eRInfoDataWork.ErInfo = string.Empty;
				# endregion
			}
		}

		// ADD 2011/07/26 張莉莉　SCM対応‐拠点管理（10704767-00）-------<<<<<<<
		#endregion

		#region [Clear]
		/// <summary>
		/// DC履歴ログとDC各データのクリア処理を行う
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 張莉莉</br>
        /// <br>Date       : 2011.08.26</br>
        // public int DCDataClear(string enterpriseCode)                                 //DEL by Liangsd     2011/09/06
        public int DCDataClear(string sectionCode, string enterpriseCode) //ADD by Liangsd    2011/09/06
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			int status2 = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			SqlTransaction sqlTransaction = null;
			SqlConnection sqlConnection = null;
			SqlCommand sqlCommand = null;
			string resNm = "";

#if !DEBUG
            IntentExclusiveLockComponent intentLockObj = null;
#endif
			try
			{
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
				status = Lock(resNm, 1, sqlConnection, sqlTransaction);

				if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					return status;
				}
#if !DEBUG
                // インテントロックを行う
                intentLockObj = new IntentExclusiveLockComponent(); // ロック部品をインスタンス
                // インテントロック対象を設定
                string[] targetTables = new string[]{"SALESSLIPRF", "ACCEPTODRCARRF", "SALESDETAILRF", "SALESHISTORYRF"       // 売上データ、受注マスタ（車両）、売上明細データ、売上履歴データ
                                    ,"SALESHISTDTLRF","STOCKSLIPRF", "STOCKDETAILRF","STOCKSLIPHISTRF"                        // 売上履歴明細データ、仕入データ、仕入明細データ、仕入履歴データ
                                    ,"STOCKSLHISTDTLRF", "STOCKADJUSTRF", "STOCKADJUSTDTLRF", "STOCKMOVERF", "ACCEPTODRRF"};  // 仕入履歴明細データ、在庫調整データ、在庫調整明細データ、在庫移動データ、受注マスタ
                status = intentLockObj.IntentLock(targetTables);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    return status;
#endif
                #region DEL by Liangsd     2011/09/06
                //DEL by Liangsd   2011/09/06----------------->>>>>>>>>>
                //// DC売上データ更新処理
                //DCSalesSlipDB _salesSlipDB = new DCSalesSlipDB();
                //_salesSlipDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// DC売上明細データ更新処理
                //DCSalesDetailDB _salesDetailDB = new DCSalesDetailDB();
                //_salesDetailDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// DC売上履歴データ更新処理
                //DCSalesHistoryDB _salesHistoryDB = new DCSalesHistoryDB();
                //_salesHistoryDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// DC売上履歴明細データ更新処理
                //DCSalesHistDtlDB _salesHistDtlDB = new DCSalesHistDtlDB();
                //_salesHistDtlDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// DC入金データ更新処理
                //DCDepsitMainDB _depsitMainDB = new DCDepsitMainDB();
                //_depsitMainDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// DC入金明細データ更新処理
                //DCDepsitDtlDB _depsitDtlDB = new DCDepsitDtlDB();
                //_depsitDtlDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// DC仕入データ更新処理
                //DCStockSlipDB _stockSlipDB = new DCStockSlipDB();
                //_stockSlipDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// DC仕入明細データ更新処理
                //DCStockDetailDB _stockDetailDB = new DCStockDetailDB();
                //_stockDetailDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// DC仕入履歴データ更新処理
                //DCStockSlipHistDB _stockSlipHistDB = new DCStockSlipHistDB();
                //_stockSlipHistDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// DC仕入履歴明細データ更新処理
                //DCStockSlHistDtlDB _stockSlHistDtlDB = new DCStockSlHistDtlDB();
                //_stockSlHistDtlDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// DC支払伝票マスタ更新処理
                //DCPaymentSlpDB _paymentSlpDB = new DCPaymentSlpDB();
                //_paymentSlpDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// DC支払明細データ更新処理
                //DCPaymentDtlDB _paymentDtlDB = new DCPaymentDtlDB();
                //_paymentDtlDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// DC受注マスタ更新処理
                //DCAcceptOdrDB _acceptOdrDB = new DCAcceptOdrDB();
                //_acceptOdrDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// DC受注マスタ（車両）更新処理
                //DCAcceptOdrCarDB _acceptOdrCarDB = new DCAcceptOdrCarDB();
                //_acceptOdrCarDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// DC在庫調整データ更新処理
                //DCStockAdjustDB _stockAdjustDB = new DCStockAdjustDB();
                //_stockAdjustDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// DC在庫調整明細データ更新処理
                //DCStockAdjustDtlDB _stockAdjustDtlDB = new DCStockAdjustDtlDB();
                //_stockAdjustDtlDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// DC在庫移動データ更新処理
                //DCStockMoveDB _stockMoveDB = new DCStockMoveDB();
                //_stockMoveDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// 入金引当マスタ
                //DCDepositAlwDB _depositAlwDB = new DCDepositAlwDB();
                //_depositAlwDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// 受取手形データ
                //DCRcvDraftDataDB _rcvDraftDataDB = new DCRcvDraftDataDB();
                //_rcvDraftDataDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// 支払手形データ
                //DCPayDraftDataDB _payDraftDataDB = new DCPayDraftDataDB();
                //_payDraftDataDB.Clear(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                //// 送信履歴ログ
                //this.ClearSndRcvhis(enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                //DEL by Liangsd   2011/09/06-----------------<<<<<<<<<<
                #endregion

                //ADD by Liangsd   2011/09/06----------------->>>>>>>>>>
                // DC受注マスタ（車両）更新処理
                DCAcceptOdrCarDB _acceptOdrCarDB = new DCAcceptOdrCarDB();
                _acceptOdrCarDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                // DC受注マスタ更新処理
                DCAcceptOdrDB _acceptOdrDB = new DCAcceptOdrDB();
                _acceptOdrDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                _acceptOdrDB.StockClear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // DC売上明細データ更新処理
                DCSalesDetailDB _salesDetailDB = new DCSalesDetailDB();
                _salesDetailDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // DC売上データ更新処理
                DCSalesSlipDB _salesSlipDB = new DCSalesSlipDB();
                _salesSlipDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // DC売上履歴明細データ更新処理
                DCSalesHistDtlDB _salesHistDtlDB = new DCSalesHistDtlDB();
                _salesHistDtlDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // DC売上履歴データ更新処理
                DCSalesHistoryDB _salesHistoryDB = new DCSalesHistoryDB();
                _salesHistoryDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // DC入金明細データ更新処理
                DCDepsitDtlDB _depsitDtlDB = new DCDepsitDtlDB();
                _depsitDtlDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // DC入金データ更新処理
                DCDepsitMainDB _depsitMainDB = new DCDepsitMainDB();
                _depsitMainDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // DC仕入明細データ更新処理
                DCStockDetailDB _stockDetailDB = new DCStockDetailDB();
                _stockDetailDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // DC仕入データ更新処理
                DCStockSlipDB _stockSlipDB = new DCStockSlipDB();
                _stockSlipDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // DC仕入履歴明細データ更新処理
                DCStockSlHistDtlDB _stockSlHistDtlDB = new DCStockSlHistDtlDB();
                _stockSlHistDtlDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // DC仕入履歴データ更新処理
                DCStockSlipHistDB _stockSlipHistDB = new DCStockSlipHistDB();
                _stockSlipHistDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // DC支払明細データ更新処理
                DCPaymentDtlDB _paymentDtlDB = new DCPaymentDtlDB();
                _paymentDtlDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // DC支払伝票マスタ更新処理
                DCPaymentSlpDB _paymentSlpDB = new DCPaymentSlpDB();
                _paymentSlpDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // DC在庫調整データ更新処理
                DCStockAdjustDB _stockAdjustDB = new DCStockAdjustDB();
                _stockAdjustDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // DC在庫調整明細データ更新処理
                DCStockAdjustDtlDB _stockAdjustDtlDB = new DCStockAdjustDtlDB();
                _stockAdjustDtlDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // DC在庫移動データ更新処理
                DCStockMoveDB _stockMoveDB = new DCStockMoveDB();
                _stockMoveDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // 入金引当マスタ
                DCDepositAlwDB _depositAlwDB = new DCDepositAlwDB();
                _depositAlwDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // 受取手形データ
                DCRcvDraftDataDB _rcvDraftDataDB = new DCRcvDraftDataDB();
                _rcvDraftDataDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);

                // 支払手形データ
                DCPayDraftDataDB _payDraftDataDB = new DCPayDraftDataDB();
                _payDraftDataDB.Clear(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                
                ClearSndRcvEtr(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
				// 送信履歴ログ
                this.ClearSndRcvhis(sectionCode, enterpriseCode, ref sqlConnection, ref sqlTransaction, ref sqlCommand);
                //ADD by Liangsd   2011/09/06-----------------<<<<<<<<<<
				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (SqlException ex)
			{
				// 基底クラスに例外を渡して処理してもらう
				base.WriteErrorLog(ex, "DCControlDB.DCDataClear(Connection付) SqlException=" + ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			catch (Exception ex)
			{
				// 基底クラスに例外を渡して処理してもらう
				base.WriteErrorLog(ex, "DCControlDB.DCDataClear(Connection付) Exception=" + ex.Message);
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}
			finally
			{
#if !DEBUG
                if (null != intentLockObj)
                {
                    // インテントロック解除
                    intentLockObj.UnLock();
                }
#endif

				if (resNm != "")
				{
					//ＡＰアンロック
					status2 = Release(resNm, sqlConnection, sqlTransaction);
					if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
					}
				}

				if (sqlTransaction != null)
				{
					if (sqlTransaction.Connection != null)
					{
						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						{
							sqlTransaction.Commit();
                        }
						else
						{
							sqlTransaction.Rollback();
						}
					}

					sqlTransaction.Dispose();
				}

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

		// ADD 2011.08.26 張莉莉 ---------->>>>>
		# region [ClearSndRcvhis]
		// Rクラスの MethodでSQL文字が駄目
		/// <summary>
		/// データクリア
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
        // private void ClearSndRcvhis(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)                                  //DEL by Liangsd    2011/09/06
        private void ClearSndRcvhis(string sectionCode, string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand) //ADD by Liangsd    2011/09/06
		{
            //ClearSndRcvhisProc(enterpriseCode, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand); //DEL by Liangsd    2011/09/06
            ClearSndRcvhisProc(sectionCode,enterpriseCode, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);    //ADD by Liangsd    2011/09/06
		}
		/// <summary>
		/// データクリア
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sqlConnection">データベース接続情報</param>
		/// <param name="sqlTransaction">トランザクション情報</param>
		/// <param name="sqlCommand">SQLコメント</param>
		/// <returns></returns>
        //private void ClearSndRcvhisProc(string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)//DEL by Liangsd    2011/09/06
        private void ClearSndRcvhisProc(string sectionCode,string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)   //ADD by Liangsd    2011/09/06
		{
			sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

			// Deleteコマンドの生成
            //sqlCommand.CommandText = "DELETE FROM SNDRCVHISRF WHERE ( ENTERPRISECODERF=@FINDENTERPRISECODE OR SENDDESTEPCODERF=@FINDSENDDESTEPCODE) AND KINDRF=@FINDKINDRF ";
            sqlCommand.CommandText = "DELETE FROM SNDRCVHISRF WHERE ( ENTERPRISECODERF=@FINDENTERPRISECODE OR SENDDESTEPCODERF=@FINDSENDDESTEPCODE)  AND (SNDRCVHISRF.SECTIONCODERF =  @FINDSECTIONCODERF OR SNDRCVHISRF.SENDDESTSECCODERF = @FINDSECTIONCODERF )";
			//Prameterオブジェクトの作成
			SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
			SqlParameter findParaSendEstEpCode = sqlCommand.Parameters.Add("@FINDSENDDESTEPCODE", SqlDbType.NChar);
			SqlParameter paraKind = sqlCommand.Parameters.Add("@FINDKINDRF", SqlDbType.Int);
            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.NChar);//ADD by Liangsd    2011/09/06
			//Parameterオブジェクトへ値設定
			findParaEnterpriseCode.Value = enterpriseCode;
			findParaSendEstEpCode.Value = enterpriseCode;
            paraKind.Value = SqlDataMediator.SqlSetInt32(0);
            findParaSectionCode.Value = sectionCode;//ADD by Liangsd    2011/09/06

            //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
            sqlCommand.CommandTimeout = 600;
            //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
            // 売上データを削除する
			sqlCommand.ExecuteNonQuery();

		}
		#endregion
        # region [ClearSndRcvEtr]
        // Rクラスの MethodでSQL文字が駄目
        /// <summary>
        /// データクリア
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        private void ClearSndRcvEtr(string sectionCode,string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            ClearSndRcvEtrProc(sectionCode,enterpriseCode, ref  sqlConnection, ref  sqlTransaction, ref  sqlCommand);
        }
        /// <summary>
        /// データクリア
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sqlConnection">データベース接続情報</param>
        /// <param name="sqlTransaction">トランザクション情報</param>
        /// <param name="sqlCommand">SQLコメント</param>
        /// <returns></returns>
        private void ClearSndRcvEtrProc(string sectionCode, string enterpriseCode, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction, ref SqlCommand sqlCommand)
        {
            sqlCommand = new SqlCommand("", sqlConnection, sqlTransaction);

            // Deleteコマンドの生成
            sqlCommand.CommandText = "DELETE FROM SNDRCVETRRF WHERE EXISTS ( SELECT * FROM SNDRCVHISRF WHERE (SNDRCVHISRF.ENTERPRISECODERF = @FINFENTERPRISECODE OR SNDRCVHISRF.SENDDESTEPCODERF = @FINDSENDDESTEPCODE )  AND (SNDRCVHISRF.SECTIONCODERF =  @FINDSECTIONCODERF OR SNDRCVHISRF.SENDDESTSECCODERF = @FINDSECTIONCODERF ) AND SNDRCVHISRF.KINDRF=@FINDKINDRF  AND SNDRCVHISRF.ENTERPRISECODERF = SNDRCVETRRF.ENTERPRISECODERF AND SNDRCVHISRF.SECTIONCODERF = SNDRCVETRRF.SECTIONCODERF AND SNDRCVHISRF.SNDRCVHISCONSNORF = SNDRCVETRRF.SNDRCVHISCONSNORF ) ";
            
            //Prameterオブジェクトの作成
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINFENTERPRISECODE", SqlDbType.NChar);
            SqlParameter findParaSendEstEpCode = sqlCommand.Parameters.Add("@FINDSENDDESTEPCODE", SqlDbType.NChar);
            SqlParameter paraKind = sqlCommand.Parameters.Add("@FINDKINDRF", SqlDbType.Int);
            SqlParameter findParaSectionCode = sqlCommand.Parameters.Add("@FINDSECTIONCODERF", SqlDbType.NChar);//ADD by Liangsd    2011/09/06
            //Parameterオブジェクトへ値設定
            findParaEnterpriseCode.Value = enterpriseCode;
            findParaSendEstEpCode.Value = enterpriseCode;
            paraKind.Value = SqlDataMediator.SqlSetInt32(1);
            findParaSectionCode.Value = sectionCode;//ADD by Liangsd    2011/09/06
            //  ADD T.Nishi  2012/03/16  ---------------->>>>>>
            sqlCommand.CommandTimeout = 600;
            //  ADD T.Nishi  2012/03/16  ----------------<<<<<<
            // データを削除する
            sqlCommand.ExecuteNonQuery();

        }
        #endregion
        // ADD 2011.08.26 張莉莉 ----------<<<<<
	}
}

//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 自由帳票（請求書）
// プログラム概要   : 自由帳票（請求書）　リモートオブジェクト
//----------------------------------------------------------------------------//
//                (c)Copyright  2022 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11570183-00   作成担当 : 陳艶丹
// 作 成 日  2022/03/07    修正内容 : 請求書発行(電子帳簿連携)新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32;

using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
	/// 自由帳票（請求書）　リモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : 自由帳票印字位置設定マスタ取得を行うクラスです。</br>
    /// <br>Programmer  : 陳艶丹</br>
    /// <br>Date        : 2022/03/07</br>
    /// </remarks>
	[Serializable]
    public class EBooksFrePBillDB : RemoteDB, IEBooksFrePBillDB
    {
        /// <summary>
        /// 自由帳票（請求書）　リモートオブジェクトクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 自由帳票（請求書）　リモートオブジェクトクラスコンストラクタ</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public EBooksFrePBillDB()
		{
        }

        #region [Search]
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="frePrtCmnExtPrmWork">抽出パラメータ</param>
        /// <param name="frePSalesSlipRetWorkList">抽出結果リスト</param>
        /// <param name="frePMasterList">関連マスタリスト</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 指定された自由帳票検索結果クラスワークLISTを取得します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        public int Search( object frePrtCmnExtPrmWork, out object frePSalesSlipRetWorkList, out object frePMasterList, out bool msgDiv, out string errMsg )
        {
            return SearchProc( frePrtCmnExtPrmWork, out frePSalesSlipRetWorkList, out frePMasterList, out msgDiv, out errMsg );
        }
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="frePrtCmnExtPrmWork">抽出パラメータ</param>
        /// <param name="frePSalesSlipRetWorkList">抽出結果リスト</param>
        /// <param name="frePMasterList">関連マスタリスト</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 検索処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private int SearchProc( object frePrtCmnExtPrmWork, out object frePSalesSlipRetWorkList, out object frePMasterList, out bool msgDiv, out string errMsg )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlEncryptInfo sqlEncryptInfo = null;
            msgDiv = false;
            errMsg = string.Empty;
            frePSalesSlipRetWorkList = null;
            frePMasterList = null;
            string logExceptionMsg = string.Empty;
            // デシリアライズ
            EBooksFrePBillParaWork extPrm = (EBooksFrePBillParaWork)XmlByteSerializer.Deserialize( (byte[])frePrtCmnExtPrmWork, typeof( EBooksFrePBillParaWork ) );

            SqlConnection sqlConnection = null;

            try
            {
                SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
                string connectionText = sqlConnectionInfo.GetConnectionInfo( ConstantManagement_SF_PRO.IndexCode_UserDB );
                if ( connectionText == null || connectionText == "" ) return status;

                //SQL文生成
                sqlConnection = new SqlConnection( connectionText );
                sqlConnection.Open();

                // 関連マスタ抽出
                status = SearchSetInfos( extPrm, out frePMasterList, ref sqlConnection );

                // データ抽出
                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    status = SearchProc(extPrm, out frePSalesSlipRetWorkList, ref sqlConnection, ref logExceptionMsg);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && (logExceptionMsg != string.Empty))
                    {
                        errMsg = logExceptionMsg;
                    }
                }

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    frePSalesSlipRetWorkList = null;
                    frePMasterList = null;
                }
            }
            catch (SqlException ex)
            {
                //基底クラスに例外を渡して処理してもらう
                status = base.WriteSQLErrorLog(ex, "EBooksFrePBillDB_Search\n" + ex.Message, status);
                if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    msgDiv = true;
                    errMsg = "自由帳票（請求書）抽出処理中にタイムアウトが発生しました。";
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "EBooksFrePBillDB_Search\n"+ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                //暗号化キークローズ
                if ( sqlEncryptInfo != null )
                {
                    if ( sqlEncryptInfo.IsOpen )
                    {
                        sqlEncryptInfo.CloseSymKey( ref sqlConnection );
                    }
                }
                if ( sqlConnection != null )
                {
                    sqlConnection.Close();
                }
            }

            return status;
        }

        /// <summary>
        /// データ抽出処理
        /// </summary>
        /// <param name="extPrm">検索条件</param>
        /// <param name="frePBillRetWorkList">検索結果リスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="logExceptionMsg">例外メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : データ抽出処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private int SearchProc(EBooksFrePBillParaWork extPrm, out object frePBillRetWorkList, ref SqlConnection sqlConnection, ref string logExceptionMsg)
        {
            // 得意先(総括設定)のディクショナリ（親→子）  Dictionary<総括得意先, List<KeyValuePair<請求拠点,請求得意先>>>
            Dictionary<int, List<KeyValuePair<string,int>>> _sumCustChildDic =  new Dictionary<int, List<KeyValuePair<string, int>>>();
            // 総括拠点ディクショナリ（総括得意先→総括拠点）
            Dictionary<int, int> _sumCustParentDic = new Dictionary<int,int>();
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            frePBillRetWorkList = null;

            # region [抽出メイン]
            // 対象リストを分割する
            List<List<EBooksFrePBillParaWork.FrePBillParaKey>> list = DevelopFrePBillParaKeyList( extPrm.FrePBillParaKeyList );

            // 分割した分繰り返し
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            for ( int index = 0; index < list.Count; index++ )
            {
                // 分割した抽出条件を生成
                EBooksFrePBillParaWork newExtPrm = new EBooksFrePBillParaWork();
                newExtPrm.EnterpriseCode = extPrm.EnterpriseCode;
                newExtPrm.SlipPrtKind = extPrm.SlipPrtKind;
                newExtPrm.FrePBillParaKeyList = list[index];
                newExtPrm.UseSumCust = extPrm.UseSumCust;

                // 結果
                object retObj;

                // 抽出処理
                status = SearchProcMain(newExtPrm, out retObj, ref sqlConnection, _sumCustChildDic, _sumCustParentDic, ref logExceptionMsg);
                if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL ) break;

                retList.AddRange( (retObj as CustomSerializeArrayList) );
            }
            # endregion


            // 結果を格納
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                frePBillRetWorkList = retList;
            }
            return status;
        }
        /// <summary>
        /// 対象リストから対象リストのリストを生成
        /// </summary>
        /// <param name="list">対象リスト</param>
        /// <returns>対象リストのリスト</returns>
        /// <remarks>
        /// <br>Note        : 対象リストから対象リストのリストを生成</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private List<List<EBooksFrePBillParaWork.FrePBillParaKey>> DevelopFrePBillParaKeyList( List<EBooksFrePBillParaWork.FrePBillParaKey> list )
        {
            const int ct_DevideCount = 100;
            List<List<EBooksFrePBillParaWork.FrePBillParaKey>> listList = new List<List<EBooksFrePBillParaWork.FrePBillParaKey>>();

            int rangeStart = 0;
            int rangeCount = ct_DevideCount;

            while ( rangeStart < list.Count )
            {
                listList.Add( new List<EBooksFrePBillParaWork.FrePBillParaKey>() );
                if ( rangeStart + rangeCount > list.Count )
                {
                    rangeCount = list.Count - rangeStart;
                }
                listList[listList.Count - 1].AddRange( list.GetRange( rangeStart, rangeCount ) );
                rangeStart += ct_DevideCount;
            }

            return listList;
        }
        /// <summary>
        /// データ抽出処理（メイン）
        /// </summary>
        /// <param name="extPrm">検索条件</param>
        /// <param name="frePBillRetWorkList">検索結果リスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="_sumCustChildDic">子集計Dic</param>
        /// <param name="_sumCustParentDic">親集計Dic</param>
        /// <param name="logExceptionMsg">例外メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : データ抽出処理（メイン）</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private int SearchProcMain(EBooksFrePBillParaWork extPrm, out object frePBillRetWorkList, ref SqlConnection sqlConnection, Dictionary<int, List<KeyValuePair<string, int>>> _sumCustChildDic, Dictionary<int, int> _sumCustParentDic, ref string logExceptionMsg)
        {
            // 請求先別締範囲ディクショナリ（KEY→情報）
            Dictionary<string, DmdRangeEachClaim> _dmdRangeEachClaimDic = new Dictionary<string, DmdRangeEachClaim>();

            // 子得意先ディクショナリ（親→子）
            Dictionary<int, List<int>> _childCustomerDic = new Dictionary<int, List<int>>();

            Dictionary<string, object> requestMessage = new Dictionary<string, object>();
            frePBillRetWorkList = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            List<EBooksFrePBillHeadWork> billList = null;
            Dictionary<string, List<EBooksFrePBillDetailWork>> salesListDic = null;
            Dictionary<string, List<EBooksFrePBillDetailWork>> depositListDic = null;

            // 請求書ヘッダ抽出処理
            status = SearchProcOfBill(extPrm, out billList, sqlConnection, ref _dmdRangeEachClaimDic, _sumCustChildDic, _sumCustParentDic, ref requestMessage);
            // 締範囲の算出
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = SearchProcOfDmdRangeSt(extPrm, billList, sqlConnection, ref _dmdRangeEachClaimDic, ref requestMessage);
            }
            // 対象得意先の取得
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (extPrm != null && extPrm.FrePBillParaKeyList != null && extPrm.FrePBillParaKeyList.Count > 0)
                {
                    status = SearchProcOfTargetCustomers(extPrm, extPrm.FrePBillParaKeyList[0].GetAddUpDateLongDate(), sqlConnection, ref _childCustomerDic);
                }
            }

                // 請求書売上明細抽出処理
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = SearchProcOfSales(extPrm, out salesListDic, sqlConnection, _childCustomerDic, _dmdRangeEachClaimDic, _sumCustChildDic, ref requestMessage);
                    if (salesListDic == null)
                    {
                        salesListDic = new Dictionary<string, List<EBooksFrePBillDetailWork>>();
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_ERROR)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }
                // 請求書入金明細抽出処理
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = SearchProcOfDeposit(extPrm, out depositListDic, sqlConnection, _childCustomerDic, _dmdRangeEachClaimDic, _sumCustChildDic, ref requestMessage);
                    if (depositListDic == null)
                    {
                        depositListDic = new Dictionary<string, List<EBooksFrePBillDetailWork>>();
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_ERROR)
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    }
                }

                // 返却データ生成
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    CustomSerializeArrayList retList = new CustomSerializeArrayList();
                    foreach (EBooksFrePBillHeadWork billWork in billList)
                    {
                        CustomSerializeArrayList newBillList = new CustomSerializeArrayList();
                        newBillList.Add(billWork);

                        EBooksFrePBillParaWork.FrePBillParaKey key = new EBooksFrePBillParaWork.FrePBillParaKey(
                                                                        billWork.CUSTDMDPRCRF_ADDUPSECCODERF.Trim(),
                                                                        billWork.CUSTDMDPRCRF_CLAIMCODERF,
                                                                        billWork.CUSTDMDPRCRF_RESULTSSECTCDRF.Trim(),
                                                                        billWork.CUSTDMDPRCRF_CUSTOMERCODERF,
                                                                        billWork.CUSTDMDPRCRF_ADDUPDATERF);

                        string keyString = key.CreateKey();
                        // 売上明細に同一キーのリストがあれば、請求書リストに追加
                        if (salesListDic.ContainsKey(keyString))
                        {
                            newBillList.Add(salesListDic[keyString]);
                        }
                        else
                        {
                            newBillList.Add(new List<EBooksFrePBillDetailWork>());
                        }
                        // 入金明細に同一キーのリストがあれば、請求書リストに追加
                        if (depositListDic.ContainsKey(keyString))
                        {
                            newBillList.Add(depositListDic[keyString]);
                        }
                        else
                        {
                            newBillList.Add(new List<EBooksFrePBillDetailWork>());
                        }

                        retList.Add(newBillList);
                    }
                    frePBillRetWorkList = retList;
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //明細請求書発行時、鑑部分の今回売上額と明細合計（入金を含まない）を比較して、違いがあった場合はＬＯＧ出力する
                    //返却データの処理
                    CustomSerializeArrayList requestInfo = new CustomSerializeArrayList();
                    requestInfo = (CustomSerializeArrayList)frePBillRetWorkList;

                    // 請求書情報リスト
                    List<RequestLogData> requestLogDataList = new List<RequestLogData>();
                    //ログフラグ
                    int logFlag = 0;

                    foreach (CustomSerializeArrayList item in requestInfo)
                    {
                        CustomSerializeArrayList requestInfoDetail = item;

                        EBooksFrePBillHeadWork frePBillHeadWork = new EBooksFrePBillHeadWork();
                        List<EBooksFrePBillDetailWork> frePBillSalesDetailWorkList = new List<EBooksFrePBillDetailWork>();
                        List<EBooksFrePBillDetailWork> frePBillDemandDetailWorkList = new List<EBooksFrePBillDetailWork>();

                        if (requestInfoDetail[0] != null)
                        {
                            // 自由帳票請求書ヘッダ（ヘッダ）
                            frePBillHeadWork = (EBooksFrePBillHeadWork)requestInfoDetail[0];
                        }

                        if (requestInfoDetail[1] != null)
                        {
                            // 自由帳票請求書明細（売上）
                            frePBillSalesDetailWorkList = (List<EBooksFrePBillDetailWork>)requestInfoDetail[1];
                        }

                        if (requestInfoDetail[2] != null)
                        {
                            frePBillDemandDetailWorkList = (List<EBooksFrePBillDetailWork>)requestInfoDetail[2];
                        }

                        //得意先の今回売上金額
                        Int64 thisTimeSalesPrice = 0;
                        //明細合計金額（入金を含まない）
                        Int64 salesTotalPrice = 0;
                        //差額
                        Int64 differentPrice = 0;

                        // 得意先の今回入金額
                        Int64 thisTimeDmdNrml = 0;
                        // 明細合計金額（入金のみ）
                        Int64 demandTotalPrice = 0;
                        // 前回締日
                        int startCAddUpUpdDate = 0;

                        DmdRangeEachClaimKey key = new DmdRangeEachClaimKey(
                                        frePBillHeadWork.CUSTDMDPRCRF_ADDUPSECCODERF.Trim(),
                                        frePBillHeadWork.CUSTDMDPRCRF_CLAIMCODERF,
                                        frePBillHeadWork.CUSTDMDPRCRF_RESULTSSECTCDRF.Trim(),
                                        frePBillHeadWork.CUSTDMDPRCRF_CUSTOMERCODERF);
                        string keyString = key.CreateKey();
                        startCAddUpUpdDate = _dmdRangeEachClaimDic[keyString].DmdRangeSt;

                        // 得意先の今回売上金額(今回売上金額-今回返品金額-今回値引金金額)
                        thisTimeSalesPrice = frePBillHeadWork.CUSTDMDPRCRF_OFSTHISTIMESALESRF;

                        // 得意先の今回入金額（今回入金額（通常））
                        thisTimeDmdNrml = frePBillHeadWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF;

                        // 明細合計金額（入金を含まない）
                        foreach (EBooksFrePBillDetailWork frePBillDetailWork in frePBillSalesDetailWorkList)
                        {

                            salesTotalPrice += frePBillDetailWork.SALESDETAILRF_SALESMONEYTAXEXCRF;
                        }

                        // 明細合計金額（入金のみ）
                        if (frePBillHeadWork.CUSTDMDPRCRF_RESULTSSECTCDRF.Trim() == "00" &&
                            frePBillHeadWork.CUSTDMDPRCRF_CUSTOMERCODERF == 0)
                        {
                            if (frePBillDemandDetailWorkList.Count != 0)
                            {
                                // 手数料・値引加算のキー
                                List<string> keyList = new List<string>();
                                foreach (EBooksFrePBillDetailWork frePBillDemandWork in frePBillDemandDetailWorkList)
                                {
                                    demandTotalPrice += frePBillDemandWork.DEPSITDTLRF_DEPOSITRF;
                                    string depKey = string.Format("{0}{1}", frePBillDemandWork.DEPSITMAINRF_ACPTANODRSTATUSRF, frePBillDemandWork.DEPSITMAINRF_DEPOSITSLIPNORF);
                                    if (!keyList.Contains(depKey))
                                    {
                                        demandTotalPrice += frePBillDemandWork.DEPSITMAINRF_DISCOUNTDEPOSITRF;
                                        demandTotalPrice += frePBillDemandWork.DEPSITMAINRF_FEEDEPOSITRF;
                                        // キー更新
                                        keyList.Add(depKey);
                                    }
                                }
                            }

                        }
                        else
                        {
                            // 集計レコード以外は0
                            demandTotalPrice = 0;
                        }

                        // 得意先の今回売上金額と、明細合計（入金を含まない）を比較して、違いがあった場合ＬＯＧ出力する。
                        // または得意先の今回入金額と明細合計（入金のみ）を比較して、違いがあった場合、LOG出力する。
                        if (thisTimeSalesPrice != salesTotalPrice || thisTimeDmdNrml != demandTotalPrice)
                        {
                            RequestLogData requestLogData = new RequestLogData();
                            // 得意先CD
                            int customerCode = frePBillHeadWork.CADD_CUSTOMERCODERF;
                            requestLogData.CustomerCode = customerCode;
                            if (customerCode == 0)
                            {
                                requestLogData.CustomerCode = frePBillHeadWork.CUSTDMDPRCRF_CLAIMCODERF;
                            }

                            //前回請求処理日
                            DateTime forwardRequestDay = new DateTime();
                            try
                            {
                                forwardRequestDay = new DateTime(startCAddUpUpdDate / 10000, startCAddUpUpdDate % 10000 / 100, startCAddUpUpdDate % 100);
                            }
                            catch
                            {
                                forwardRequestDay = DateTime.MinValue;
                            }
                            requestLogData.AddupDate = forwardRequestDay;

                            //今回金額
                            requestLogData.ThisTimeSalesPrice = thisTimeSalesPrice;

                            //明細合計金額
                            requestLogData.TotalPrice = salesTotalPrice;

                            // 差額
                            differentPrice = salesTotalPrice - thisTimeSalesPrice;
                            requestLogData.DifferentPrice = differentPrice;

                            //今回入金額
                            requestLogData.ThisTimeDemandPrice = thisTimeDmdNrml;

                            //明細合計金額（入金）
                            requestLogData.TotalDemandPrice = demandTotalPrice;

                            // 入金差額
                            differentPrice = demandTotalPrice - thisTimeDmdNrml;
                            requestLogData.DifferentDemandPrice = differentPrice;

                            requestLogDataList.Add(requestLogData);

                            logFlag++;
                        }

                    }

                    // LOGが有る
                    if (logFlag > 0)
                    {
                        LogWrite(requestLogDataList, requestMessage, ref logExceptionMsg);
                    }
                }

                return status;
            }

        #endregion

        #region [private メソッド]

        # region [マスタ抽出]
        /// <summary>
        /// 自由帳票（請求書）関連マスタ検索処理
        /// </summary>
        /// <param name="extPrm">検索条件</param>
        /// <param name="frePMasterList">検索結果リスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 請求書発行に必要な各種マスタを格納して返します。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private int SearchSetInfos( EBooksFrePBillParaWork extPrm, out object frePMasterList, ref SqlConnection sqlConnection )
        {
            CustomSerializeArrayList retList = new CustomSerializeArrayList();
            CustomSerializeArrayList dmdPrtPtnList = new CustomSerializeArrayList();
            int status;

            // 請求書印刷パターン設定 (MAKAU09154R.DmdPrtPtnDB)
            status = SearchDmdPrtPtn( extPrm, ref dmdPrtPtnList, ref sqlConnection );
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && dmdPrtPtnList.Count > 0 )
            {
                retList.Add( dmdPrtPtnList[0] );
            }

            // 自由帳票印字位置設定 (SFANL08124R.FrePrtPSetDB)
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                try
                {
                    status = SearchFrePrtPSet( extPrm, (DmdPrtPtnWork[])dmdPrtPtnList[0], ref retList, ref sqlConnection );
                    if ( status != (int)ConstantManagement.DB_Status.ctDB_ERROR ) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch
                {
                }
            }
            // 得意先マスタ（請求書）設定　(PMKHN09084R.CustDmdSetDB)
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                try
                {
                    status = SearchCustDmdSet( extPrm, ref retList, ref sqlConnection );
                    if ( status != (int)ConstantManagement.DB_Status.ctDB_ERROR ) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch
                {
                }
            }
            // 伝票出力先設定 (DCKHN09264R.SlipOutputSetDB)
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                try
                {
                    status = SearchSlipOutputSet( extPrm, ref retList, ref sqlConnection );
                    if ( status != (int)ConstantManagement.DB_Status.ctDB_ERROR ) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch
                {
                }
            }
            // 請求全体設定 (SFUKK09104R.BillAllStDB)
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                try
                {
                    status = SearchBillAllSt( extPrm, ref retList, ref sqlConnection );
                    if ( status != (int)ConstantManagement.DB_Status.ctDB_ERROR ) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch
                {
                }
            }
            // 請求印刷設定 (SFUKK09084R.BillPrtStDB)
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                try
                {
                    status = SearchBillPrtSt( extPrm, ref retList, ref sqlConnection );
                    if ( status != (int)ConstantManagement.DB_Status.ctDB_ERROR ) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch
                {
                }
            }
            // 全体初期値設定 (SFCMN09084R.AllDefSetDB)
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                try
                {
                    status = SearchAllDefSet( extPrm, ref retList, ref sqlConnection );
                    if ( status != (int)ConstantManagement.DB_Status.ctDB_ERROR ) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch
                {
                }
            }
            // --- ADD START 田村顕成 2022/10/18 ----->>>>>
            //売上金額処理区分設定 (MAHNB09134R.SalesProcMoneyDB)
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                try
                {
                    status = SearchSalesProcMoney(extPrm, ref retList, ref sqlConnection);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_ERROR) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch
                {
                }
            }
            // --- ADD END 田村顕成 2022/10/18 -----<<<<<

            frePMasterList = retList;
            return status;
        }

        /// <summary>
        /// Search 請求書印刷パターン設定
        /// </summary>
        /// <param name="extPrm">検索条件</param>
        /// <param name="refRetList">検索結果リスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : Search 請求書印刷パターン設定</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private int SearchDmdPrtPtn( EBooksFrePBillParaWork extPrm, ref CustomSerializeArrayList refRetList, ref SqlConnection sqlConnection )
        {
            DmdPrtPtnDB dmdPrtPtnDB = new DmdPrtPtnDB();
            
            // 検索
            DmdPrtPtnWork paraWork = new DmdPrtPtnWork();
            paraWork.EnterpriseCode = extPrm.EnterpriseCode;
            paraWork.DataInputSystem = 0;
            paraWork.SlipPrtKind = 0;
            paraWork.SlipPrtSetPaperId = string.Empty;

            object retObj;
            int status = dmdPrtPtnDB.Search( out retObj, paraWork, 0, ConstantManagement.LogicalMode.GetData0 );

            // 取得結果
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retObj != null && (retObj as ArrayList).Count > 0 )
            {
                refRetList.Add( (retObj as ArrayList).ToArray( typeof( DmdPrtPtnWork ) ) );
            }
            return status;
        }

        /// <summary>
        /// Search 伝票出力先設定
        /// </summary>
        /// <param name="extPrm">検索条件</param>
        /// <param name="refRetList">検索結果リスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : Search 伝票出力先設定</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private int SearchSlipOutputSet( EBooksFrePBillParaWork extPrm, ref CustomSerializeArrayList refRetList, ref SqlConnection sqlConnection )
        {
            SlipOutputSetDB slipOutputSetDB = new SlipOutputSetDB();

            // 検索
            ArrayList retList;
            SearchSlipOutputSetParaWork paraWork = new SearchSlipOutputSetParaWork();
            paraWork.EnterpriseCode = extPrm.EnterpriseCode;
            paraWork.CashRegisterNo = -1;
            paraWork.DataInputSystem = 0;
            paraWork.SlipPrtKind = -1;
            int status = slipOutputSetDB.SearchSlipOutputSetProc( out retList, paraWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection );

            // 取得結果
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retList != null )
            {
                refRetList.Add( retList.ToArray( typeof( SlipOutputSetWork ) ) );
            }
            return status;
        }
        /// <summary>
        /// Search 得意先マスタ(請求書管理)設定
        /// </summary>
        /// <param name="extPrm">検索条件</param>
        /// <param name="refRetList">検索結果リスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : Search 得意先マスタ(請求書管理)設定</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private int SearchCustDmdSet( EBooksFrePBillParaWork extPrm, ref CustomSerializeArrayList refRetList, ref SqlConnection sqlConnection )
        {
            CustDmdSetDB custDmdSetDB = new CustDmdSetDB();

            // 検索
            ArrayList retList = new ArrayList();
            CustDmdSetWork paraWork = new CustDmdSetWork();
            paraWork.EnterpriseCode = extPrm.EnterpriseCode;

            // SQLトランザクション開始
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

            int status = custDmdSetDB.Search( ref retList, paraWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection, ref sqlTransaction );

            // 取得結果
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retList != null )
            {
                // コミット
                sqlTransaction.Commit();

                refRetList.Add( retList.ToArray( typeof( CustDmdSetWork ) ) );
            }
            else
            {
                // ロールバック
                sqlTransaction.Rollback();
            }
            sqlTransaction.Dispose();

            return status;
        }
        /// <summary>
        /// Search 請求全体設定
        /// </summary>
        /// <param name="extPrm">検索条件</param>
        /// <param name="refRetList">検索結果リスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : Search 請求全体設定</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private int SearchBillAllSt( EBooksFrePBillParaWork extPrm, ref CustomSerializeArrayList refRetList, ref SqlConnection sqlConnection )
        {
            BillAllStDB billAllStDB = new BillAllStDB();

            // 検索
            ArrayList retList = new ArrayList();
            BillAllStWork paraWork = new BillAllStWork();
            paraWork.EnterpriseCode = extPrm.EnterpriseCode;
            SqlTransaction sqlTransaction = null;
            int status = billAllStDB.Search( ref retList, paraWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection, ref sqlTransaction );

            // 取得結果
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retList != null )
            {
                refRetList.Add( retList.ToArray( typeof( BillAllStWork ) ) );
            }
            return status;
        }
        /// <summary>
        /// Search 請求印刷設定
        /// </summary>
        /// <param name="extPrm">検索条件</param>
        /// <param name="refRetList">検索結果リスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : Search 請求印刷設定</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private int SearchBillPrtSt( EBooksFrePBillParaWork extPrm, ref CustomSerializeArrayList refRetList, ref SqlConnection sqlConnection )
        {
            BillPrtStDB billPrtStDB = new BillPrtStDB();

            // 検索
            BillPrtStWork paraWork = new BillPrtStWork();
            paraWork.EnterpriseCode = extPrm.EnterpriseCode;
            object retObj;
            ArrayList retList;
            int status = billPrtStDB.SearchProc( out retObj, paraWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection );

            // 取得結果
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retObj != null )
            {
                if ( retObj != null )
                {
                    retList = (retObj as ArrayList);
                    refRetList.Add( retList.ToArray( typeof( BillPrtStWork ) ) );
                }
            }
            return status;
        }
        /// <summary>
        /// Search 全体初期値設定
        /// </summary>
        /// <param name="extPrm">検索条件</param>
        /// <param name="refRetList">検索結果リスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : Search 全体初期値設定</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private int SearchAllDefSet( EBooksFrePBillParaWork extPrm, ref CustomSerializeArrayList refRetList, ref SqlConnection sqlConnection )
        {
            AllDefSetDB allDefSetDB = new AllDefSetDB();

            // 検索
            AllDefSetWork paraWork = new AllDefSetWork();
            paraWork.EnterpriseCode = extPrm.EnterpriseCode;
            ArrayList retList;
            int status = allDefSetDB.Search( out retList, paraWork, ref sqlConnection, ConstantManagement.LogicalMode.GetData0 );

            // 取得結果
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retList != null )
            {
                refRetList.Add( retList.ToArray( typeof( AllDefSetWork ) ) );
            }
            return status;
        }

        // --- ADD START 田村顕成 2022/10/18 ----->>>>>
        /// <summary>
        /// Search 売上金額処理区分設定
        /// </summary>
        /// <param name="extPrm"></param>
        /// <param name="refRetList"></param>
        /// <param name="sqlConnection"></param>
        /// <returns></returns>
        private int SearchSalesProcMoney(EBooksFrePBillParaWork extPrm, ref CustomSerializeArrayList refRetList, ref SqlConnection sqlConnection)
        {
            SalesProcMoneyDB salesProcMoneyDB = new SalesProcMoneyDB();

            //検索
            SalesProcMoneyWork paraWork = new SalesProcMoneyWork();
            paraWork.EnterpriseCode = extPrm.EnterpriseCode;
            paraWork.FracProcMoneyDiv = -1;
            paraWork.FractionProcCode = -1;
            ArrayList retList;
            int status = salesProcMoneyDB.SearchSalesProcMoneyProc(out retList, paraWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection);

            //取得結果
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retList != null)
            {
                refRetList.Add(retList.ToArray(typeof(SalesProcMoneyWork)));
            }
            return status;
            
        }
        // --- ADD END 田村顕成 2022/10/18 -----<<<<<

        /// <summary>
        /// Search 自由帳票印字位置設定
        /// </summary>
        /// <param name="extPrm">検索条件</param>
        /// <param name="dmdPrtPtnWorkList">請求金額ワークリスト</param>
        /// <param name="retList">検索結果リスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : Search 自由帳票印字位置設定</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private int SearchFrePrtPSet( EBooksFrePBillParaWork extPrm, DmdPrtPtnWork[] dmdPrtPtnWorkList, ref CustomSerializeArrayList retList, ref SqlConnection sqlConnection )
        {
            List<FrePrtPSetDB.FrePrtPSetReadKey> keyList = new List<FrePrtPSetDB.FrePrtPSetReadKey>();
            foreach ( DmdPrtPtnWork dmdPrtPtnWork in dmdPrtPtnWorkList )
            {
                keyList.Add( GetFrePrtPSetKey( dmdPrtPtnWork ) );
            }

            // ユーザーＤＢ検索
            FrePrtPSetDB frePrtPSetDB = new FrePrtPSetDB();
            List<FrePrtPSetWork> frePrtPSetWorkList;
            int status = frePrtPSetDB.SearchFrePrtPSetProc( extPrm.EnterpriseCode, keyList, out frePrtPSetWorkList, ref sqlConnection );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && frePrtPSetWorkList != null )
            {
                retList.Add( frePrtPSetWorkList.ToArray() );
            }
            return status;
        }
        /// <summary>
        /// 自由帳票印字位置設定Readキー取得処理
        /// </summary>
        /// <param name="dmdPrtPtnWork">請求書印刷パターン設定</param>
        /// <returns>自由帳票印字位置設定Readキー</returns>
        /// <remarks>
        /// <br>Note        : 自由帳票印字位置設定Readキー取得処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private FrePrtPSetDB.FrePrtPSetReadKey GetFrePrtPSetKey( DmdPrtPtnWork dmdPrtPtnWork )
        {
            FrePrtPSetDB.FrePrtPSetReadKey key = new FrePrtPSetDB.FrePrtPSetReadKey();
            key.OutputFormFileName = dmdPrtPtnWork.OutputFormFileName;

            if ( dmdPrtPtnWork.SlipPrtSetPaperId.StartsWith( dmdPrtPtnWork.OutputFormFileName ) )
            {
                string DerivNoText = dmdPrtPtnWork.SlipPrtSetPaperId.Substring( dmdPrtPtnWork.OutputFormFileName.Length, dmdPrtPtnWork.SlipPrtSetPaperId.Length - dmdPrtPtnWork.OutputFormFileName.Length );
                try
                {
                    key.UserPrtPprIdDerivNo = Int32.Parse( DerivNoText );
                }
                catch
                {
                    key.UserPrtPprIdDerivNo = 0;
                }
            }

            return key;
        }

        /// <summary>
        /// 得意先マスタ(総括設定)の取得
        /// </summary>
        /// <param name="extPrm">検索条件</param>
        /// <param name="list">検索結果リスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 得意先マスタ(総括設定)の取得</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private int SearchSumCustSt( EBooksFrePBillParaWork extPrm, out ArrayList list, ref SqlConnection sqlConnection )
        {
            SumCustStWork paraWork = new SumCustStWork();
            paraWork.EnterpriseCode = extPrm.EnterpriseCode;

            SqlTransaction sqlTransaction = null;
            list = new ArrayList();

            SumCustStDB sumCustStDB = new SumCustStDB();
            int status = sumCustStDB.Search( ref list, paraWork, 0, ConstantManagement.LogicalMode.GetData0, ref sqlConnection, ref sqlTransaction );

            return status;
        }

        # endregion

        # region [請求書ヘッダデータ抽出]
        /// <summary>
        /// Search 請求書ヘッダ
        /// </summary>
        /// <param name="extPrm">検索条件</param>
        /// <param name="retObj">検索結果リスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="_dmdRangeEachClaimDic">請求先単位Dic</param>
        /// <param name="_sumCustChildDic">子集計Dic</param>
        /// <param name="_sumCustParentDic">親集計Dic</param>
        /// <param name="requestMessage">請求書ログ出力用メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : Search 請求書ヘッダ</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private int SearchProcOfBill(EBooksFrePBillParaWork extPrm, out List<EBooksFrePBillHeadWork> retObj, SqlConnection sqlConnection, ref Dictionary<string, DmdRangeEachClaim> _dmdRangeEachClaimDic, Dictionary<int, List<KeyValuePair<string, int>>> _sumCustChildDic, Dictionary<int, int> _sumCustParentDic, ref Dictionary<string, object> requestMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            List<EBooksFrePBillHeadWork> frePBillHeadWorkList = new List<EBooksFrePBillHeadWork>();
            retObj = null;

            try
            {
                //-------------------------------------------------------------------
                // 対象テーブル
                //   得意先請求金額マスタ　　　CustDmdPrcRF
                //   　拠点情報設定マスタ①　　SecInfoSetRF As SECHED
                //   　　自社名称マスタ　　　　CompanyNmRF
                //   　　　画像情報マスタ　　　ImageInfoRF
                //     得意先マスタ①　　　　　CustomerRF As CSTCST
                //     得意先マスタ②　　　　　CustomerRF As CSTCLM
                //     自社情報マスタ　　　　　CompanyInfRF
                //     入金設定マスタ　　　　　DepositStRF
                //     　請求入金集計データ①　DmdDepoTotalRF As DEPT01
                //     　請求入金集計データ②　DmdDepoTotalRF As DEPT02
                //     　請求入金集計データ③　DmdDepoTotalRF As DEPT03
                //     　請求入金集計データ④　DmdDepoTotalRF As DEPT04
                //     　請求入金集計データ⑤　DmdDepoTotalRF As DEPT05
                //     　請求入金集計データ⑥　DmdDepoTotalRF As DEPT06
                //     　請求入金集計データ⑦　DmdDepoTotalRF As DEPT07
                //     　請求入金集計データ⑧　DmdDepoTotalRF As DEPT08
                //     　請求入金集計データ⑨　DmdDepoTotalRF As DEPT09
                //     　請求入金集計データ⑩　DmdDepoTotalRF As DEPT10
                //     全体表示名称マスタ      AlItmDspNmRF
                //-------------------------------------------------------------------
                SqlCommand sqlCommand = new SqlCommand( "SELECT " + this.GetSelectItemsForHead( extPrm )
                    + Environment.NewLine
                    + " FROM CUSTDMDPRCRF " + Environment.NewLine
                    + LeftJoin( "CUSTDMDPRCRF", "SECINFOSETRF", "SECHED", new string[] { }, new string[] { GetJoinForHeadSection() } )  // 企業cd,拠点cd
                    + LeftJoin( "SECHED", "COMPANYNMRF", string.Empty, new string[] { }, new string[] { "SECHED.COMPANYNAMECD1RF=COMPANYNMRF.COMPANYNAMECDRF" } )    // 企業cd,自社名称cd
                    + LeftJoin( "COMPANYNMRF", "IMAGEINFORF", string.Empty, new string[] { "IMAGEINFOCODERF" }, new string[] { "IMAGEINFORF.IMAGEINFODIVRF='10'" } )    // 企業cd,画像情報cd,区分=10
                    + LeftJoin( "CUSTDMDPRCRF", "CUSTOMERRF", "CSTCST", new string[] { }, new string[] { "CUSTDMDPRCRF.CUSTOMERCODERF=CSTCST.CUSTOMERCODERF" } )    // 企業cd,得意先cd
                    + LeftJoin( "CUSTDMDPRCRF", "CUSTOMERRF", "CSTCLM", new string[] { }, new string[] { "CUSTDMDPRCRF.CLAIMCODERF=CSTCLM.CUSTOMERCODERF" } )    // 企業cd,得意先cd
                    + LeftJoin( "CUSTDMDPRCRF", "COMPANYINFRF", string.Empty, new string[] { }, new string[] { "COMPANYINFRF.COMPANYCODERF='0'" } )    // 企業cd,自社コード=0固定
                    + LeftJoin( "CUSTDMDPRCRF", "DEPOSITSTRF", string.Empty, new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTMNGCDRF='0'" } )    // 企業cd,入金設定管理コード=0固定
                    + LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT01", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD1RF=DEPT01.MONEYKINDCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT01.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT01.CLAIMCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT01.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT01.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    + LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT02", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD2RF=DEPT02.MONEYKINDCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT02.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT02.CLAIMCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT02.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT02.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    + LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT03", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD3RF=DEPT03.MONEYKINDCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT03.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT03.CLAIMCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT03.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT03.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    + LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT04", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD4RF=DEPT04.MONEYKINDCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT04.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT04.CLAIMCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT04.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT04.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    + LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT05", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD5RF=DEPT05.MONEYKINDCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT05.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT05.CLAIMCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT05.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT05.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    + LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT06", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD6RF=DEPT06.MONEYKINDCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT06.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT06.CLAIMCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT06.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT06.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    + LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT07", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD7RF=DEPT07.MONEYKINDCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT07.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT07.CLAIMCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT07.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT07.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    + LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT08", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD8RF=DEPT08.MONEYKINDCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT08.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT08.CLAIMCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT08.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT08.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    + LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT09", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD9RF=DEPT09.MONEYKINDCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT09.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT09.CLAIMCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT09.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT09.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    + LeftJoin( "DEPOSITSTRF", "DMDDEPOTOTALRF", "DEPT10", new string[] { }, new string[] { "DEPOSITSTRF.DEPOSITSTKINDCD10RF=DEPT10.MONEYKINDCODERF", "CUSTDMDPRCRF.ADDUPSECCODERF=DEPT10.ADDUPSECCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT10.CLAIMCODERF", "CUSTDMDPRCRF.CLAIMCODERF=DEPT10.CUSTOMERCODERF", "CUSTDMDPRCRF.ADDUPDATERF=DEPT10.ADDUPDATERF" } )    // 企業cd,計上拠点cd,請求先cd,得意先cd,計上年月日,金種cd
                    + LeftJoin( "CUSTDMDPRCRF", "ALITMDSPNMRF", string.Empty, new string[] { }, new string[] { } )    // 企業cd
                    , sqlConnection );

                // WHERE文を生成
                sqlCommand.CommandText += MakeWhereStringForHead(ref sqlCommand, extPrm, _sumCustChildDic);
                // タイムアウト時間設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut(RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide);

                //請求書ログ出力用
                if (requestMessage.ContainsKey("売上ヘッダ取得クエリ") == false)
                {
                    requestMessage.Add("売上ヘッダ取得クエリ", sqlCommand.CommandText);
                }

                myReader = sqlCommand.ExecuteReader();

                    //---------------------------------------------------
                    // 請求書
                    //---------------------------------------------------
                    # region [請求書]
                    while ( myReader.Read() )
                    {
                        // クエリ結果から結果クラスへ移行
                        EBooksFrePBillHeadWork frePBillHeadWork = CopyFromReader( myReader );
                        frePBillHeadWorkList.Add( frePBillHeadWork );

                        # region [請求先別締範囲ディクショナリ]
                        DmdRangeEachClaimKey key = new DmdRangeEachClaimKey(
                                                            frePBillHeadWork.CUSTDMDPRCRF_ADDUPSECCODERF.Trim(),
                                                            frePBillHeadWork.CUSTDMDPRCRF_CLAIMCODERF,
                                                            frePBillHeadWork.CUSTDMDPRCRF_RESULTSSECTCDRF.Trim(),
                                                            frePBillHeadWork.CUSTDMDPRCRF_CUSTOMERCODERF );

                        string keyString = key.CreateKey();
                        if ( !_dmdRangeEachClaimDic.ContainsKey( keyString ) )
                        {
                            DmdRangeEachClaim dmdRangeEachClaim = new DmdRangeEachClaim();
                            dmdRangeEachClaim.DmdRangeSt = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "STARTCADDUPUPDDATERF" ) );
                            dmdRangeEachClaim.DmdRangeEd = frePBillHeadWork.CUSTDMDPRCRF_ADDUPDATERF;
                            _dmdRangeEachClaimDic.Add( keyString, dmdRangeEachClaim );
                        }
                        //-------------------------------------------------------
                        // ※このあと、
                        //   SearchProcOfDmdRangeStで、DmdRangeStを書き換える。
                        //-------------------------------------------------------
                        # endregion
                    }
                    # endregion

                if ( frePBillHeadWorkList.Count > 0 ) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                retObj = frePBillHeadWorkList;
            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "SearchProc\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR );
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if ( myReader != null )
                {
                    if ( !myReader.IsClosed )
                        myReader.Close();
                }
            }
            return status;
        }

        /// <summary>
        /// SQLDataReaderからの結果クラス取得処理（Head）
        /// </summary>
        /// <param name="myReader">リーダー</param>
        /// <returns>検出ヘッダワーク</returns>
        /// <remarks>
        /// <br>Note        : SQLDataReaderからの結果クラス取得処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Update Note  : 2022/10/18 田村顕成</br>
        /// <br>管理番号     : 11870141-00 インボイス残対応（軽減税率対応）</br>
        /// </remarks>
        private EBooksFrePBillHeadWork CopyFromReader( SqlDataReader myReader )
        {
            EBooksFrePBillHeadWork frePBillHeadWork = new EBooksFrePBillHeadWork();

            #region データのコピー
            frePBillHeadWork.CUSTDMDPRCRF_ADDUPSECCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDUPSECCODERF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_CLAIMCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CLAIMCODERF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_CLAIMNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CLAIMNAMERF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_CLAIMNAME2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CLAIMNAME2RF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_CLAIMSNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CLAIMSNMRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_CUSTOMERCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CUSTOMERCODERF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_CUSTOMERNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CUSTOMERNAMERF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_CUSTOMERNAME2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CUSTOMERNAME2RF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_CUSTOMERSNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CUSTOMERSNMRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_ADDUPDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ADDUPDATERF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_ADDUPYEARMONTHRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ADDUPYEARMONTHRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_LASTTIMEDEMANDRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "LASTTIMEDEMANDRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "THISTIMEFEEDMDNRMLRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_THISTIMEDISDMDNRMLRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "THISTIMEDISDMDNRMLRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "THISTIMEDMDNRMLRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_THISTIMETTLBLCDMDRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "THISTIMETTLBLCDMDRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_OFSTHISTIMESALESRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "OFSTHISTIMESALESRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_OFSTHISSALESTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "OFSTHISSALESTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_ITDEDOFFSETOUTTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ITDEDOFFSETOUTTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_ITDEDOFFSETINTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ITDEDOFFSETINTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_ITDEDOFFSETTAXFREERF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ITDEDOFFSETTAXFREERF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_OFFSETOUTTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "OFFSETOUTTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_OFFSETINTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "OFFSETINTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_THISTIMESALESRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "THISTIMESALESRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_THISSALESTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "THISSALESTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_ITDEDSALESOUTTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ITDEDSALESOUTTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_ITDEDSALESINTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ITDEDSALESINTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_ITDEDSALESTAXFREERF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ITDEDSALESTAXFREERF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_SALESOUTTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESOUTTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_SALESINTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESINTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_THISSALESPRICRGDSRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "THISSALESPRICRGDSRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_THISSALESPRCTAXRGDSRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "THISSALESPRCTAXRGDSRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_TTLITDEDRETOUTTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TTLITDEDRETOUTTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_TTLITDEDRETINTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TTLITDEDRETINTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_TTLITDEDRETTAXFREERF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TTLITDEDRETTAXFREERF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_TTLRETOUTERTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TTLRETOUTERTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_TTLRETINNERTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TTLRETINNERTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_THISSALESPRICDISRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "THISSALESPRICDISRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_THISSALESPRCTAXDISRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "THISSALESPRCTAXDISRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_TTLITDEDDISOUTTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TTLITDEDDISOUTTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_TTLITDEDDISINTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TTLITDEDDISINTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_TTLITDEDDISTAXFREERF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TTLITDEDDISTAXFREERF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_TTLDISOUTERTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TTLDISOUTERTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_TTLDISINNERTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TTLDISINNERTAXRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_TAXADJUSTRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TAXADJUSTRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_BALANCEADJUSTRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "BALANCEADJUSTRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_AFCALDEMANDPRICERF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "AFCALDEMANDPRICERF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ACPODRTTL2TMBFBLDMDRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ACPODRTTL3TMBFBLDMDRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_STARTCADDUPUPDDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "STARTCADDUPUPDDATERF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_SALESSLIPCOUNTRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESSLIPCOUNTRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_BILLPRINTDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "BILLPRINTDATERF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_EXPECTEDDEPOSITDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "EXPECTEDDEPOSITDATERF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_COLLECTCONDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "COLLECTCONDRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_CONSTAXLAYMETHODRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CONSTAXLAYMETHODRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_CONSTAXRATERF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "CONSTAXRATERF" ) );
            frePBillHeadWork.SECHED_SECTIONGUIDENMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SECHEDSECTIONGUIDENMRF" ) );
            frePBillHeadWork.SECHED_SECTIONGUIDESNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SECHEDSECTIONGUIDESNMRF" ) );
            frePBillHeadWork.SECHED_COMPANYNAMECD1RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SECHEDCOMPANYNAMECD1RF" ) );
            frePBillHeadWork.COMPANYNMRF_COMPANYPRRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYPRRF" ) );
            frePBillHeadWork.COMPANYNMRF_COMPANYNAME1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYNAME1RF" ) );
            frePBillHeadWork.COMPANYNMRF_COMPANYNAME2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYNAME2RF" ) );
            frePBillHeadWork.COMPANYNMRF_POSTNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "POSTNORF" ) );
            frePBillHeadWork.COMPANYNMRF_ADDRESS1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESS1RF" ) );
            frePBillHeadWork.COMPANYNMRF_ADDRESS3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESS3RF" ) );
            frePBillHeadWork.COMPANYNMRF_ADDRESS4RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESS4RF" ) );
            frePBillHeadWork.COMPANYNMRF_COMPANYTELNO1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELNO1RF" ) );
            frePBillHeadWork.COMPANYNMRF_COMPANYTELNO2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELNO2RF" ) );
            frePBillHeadWork.COMPANYNMRF_COMPANYTELNO3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELNO3RF" ) );
            frePBillHeadWork.COMPANYNMRF_COMPANYTELTITLE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELTITLE1RF" ) );
            frePBillHeadWork.COMPANYNMRF_COMPANYTELTITLE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELTITLE2RF" ) );
            frePBillHeadWork.COMPANYNMRF_COMPANYTELTITLE3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYTELTITLE3RF" ) );
            frePBillHeadWork.COMPANYNMRF_TRANSFERGUIDANCERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "TRANSFERGUIDANCERF" ) );
            frePBillHeadWork.COMPANYNMRF_ACCOUNTNOINFO1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ACCOUNTNOINFO1RF" ) );
            frePBillHeadWork.COMPANYNMRF_ACCOUNTNOINFO2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ACCOUNTNOINFO2RF" ) );
            frePBillHeadWork.COMPANYNMRF_ACCOUNTNOINFO3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ACCOUNTNOINFO3RF" ) );
            frePBillHeadWork.COMPANYNMRF_COMPANYSETNOTE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYSETNOTE1RF" ) );
            frePBillHeadWork.COMPANYNMRF_COMPANYSETNOTE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYSETNOTE2RF" ) );
            frePBillHeadWork.COMPANYNMRF_IMAGEINFOCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "IMAGEINFOCODERF" ) );
            frePBillHeadWork.COMPANYNMRF_COMPANYURLRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYURLRF" ) );
            frePBillHeadWork.COMPANYNMRF_COMPANYPRSENTENCE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYPRSENTENCE2RF" ) );
            frePBillHeadWork.COMPANYNMRF_IMAGECOMMENTFORPRT1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "IMAGECOMMENTFORPRT1RF" ) );
            frePBillHeadWork.COMPANYNMRF_IMAGECOMMENTFORPRT2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "IMAGECOMMENTFORPRT2RF" ) );
            frePBillHeadWork.IMAGEINFORF_IMAGEINFODATARF = SqlDataMediator.SqlGetBinaly( myReader, myReader.GetOrdinal( "IMAGEINFODATARF" ) );
            frePBillHeadWork.CSTCST_CUSTOMERSUBCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTCUSTOMERSUBCODERF" ) );
            frePBillHeadWork.CSTCST_NAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNAMERF" ) );
            frePBillHeadWork.CSTCST_NAME2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNAME2RF" ) );
            frePBillHeadWork.CSTCST_HONORIFICTITLERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTHONORIFICTITLERF" ) );
            frePBillHeadWork.CSTCST_KANARF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTKANARF" ) );
            frePBillHeadWork.CSTCST_CUSTOMERSNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTCUSTOMERSNMRF" ) );
            frePBillHeadWork.CSTCST_OUTPUTNAMECODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCSTOUTPUTNAMECODERF" ) );
            frePBillHeadWork.CSTCST_POSTNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTPOSTNORF" ) );
            frePBillHeadWork.CSTCST_ADDRESS1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTADDRESS1RF" ) );
            frePBillHeadWork.CSTCST_ADDRESS3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTADDRESS3RF" ) );
            frePBillHeadWork.CSTCST_ADDRESS4RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTADDRESS4RF" ) );
            frePBillHeadWork.CSTCST_CUSTANALYSCODE1RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCSTCUSTANALYSCODE1RF" ) );
            frePBillHeadWork.CSTCST_CUSTANALYSCODE2RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCSTCUSTANALYSCODE2RF" ) );
            frePBillHeadWork.CSTCST_CUSTANALYSCODE3RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCSTCUSTANALYSCODE3RF" ) );
            frePBillHeadWork.CSTCST_CUSTANALYSCODE4RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCSTCUSTANALYSCODE4RF" ) );
            frePBillHeadWork.CSTCST_CUSTANALYSCODE5RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCSTCUSTANALYSCODE5RF" ) );
            frePBillHeadWork.CSTCST_CUSTANALYSCODE6RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCSTCUSTANALYSCODE6RF" ) );
            frePBillHeadWork.CSTCST_NOTE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE1RF" ) );
            frePBillHeadWork.CSTCST_NOTE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE2RF" ) );
            frePBillHeadWork.CSTCST_NOTE3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE3RF" ) );
            frePBillHeadWork.CSTCST_NOTE4RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE4RF" ) );
            frePBillHeadWork.CSTCST_NOTE5RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE5RF" ) );
            frePBillHeadWork.CSTCST_NOTE6RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE6RF" ) );
            frePBillHeadWork.CSTCST_NOTE7RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE7RF" ) );
            frePBillHeadWork.CSTCST_NOTE8RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE8RF" ) );
            frePBillHeadWork.CSTCST_NOTE9RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE9RF" ) );
            frePBillHeadWork.CSTCST_NOTE10RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTNOTE10RF" ) );
            frePBillHeadWork.CSTCLM_CUSTOMERSUBCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMCUSTOMERSUBCODERF" ) );
            // --- ADD START 田村顕成 2022/10/18 ----->>>>>
            frePBillHeadWork.CSTCLM_SALESCNSTAXFRCPROCCDRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCLMSALESCNSTAXFRCPROCCDRF"));
            // --- ADD END 田村顕成 2022/10/18 -----<<<<<
            frePBillHeadWork.CSTCLM_NAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNAMERF" ) );
            frePBillHeadWork.CSTCLM_NAME2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNAME2RF" ) );
            frePBillHeadWork.CSTCLM_HONORIFICTITLERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMHONORIFICTITLERF" ) );
            frePBillHeadWork.CSTCLM_KANARF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMKANARF" ) );
            frePBillHeadWork.CSTCLM_CUSTOMERSNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMCUSTOMERSNMRF" ) );
            frePBillHeadWork.CSTCLM_OUTPUTNAMECODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMOUTPUTNAMECODERF" ) );
            frePBillHeadWork.CSTCLM_POSTNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMPOSTNORF" ) );
            frePBillHeadWork.CSTCLM_ADDRESS1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMADDRESS1RF" ) );
            frePBillHeadWork.CSTCLM_ADDRESS3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMADDRESS3RF" ) );
            frePBillHeadWork.CSTCLM_ADDRESS4RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMADDRESS4RF" ) );
            frePBillHeadWork.CSTCLM_CUSTANALYSCODE1RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMCUSTANALYSCODE1RF" ) );
            frePBillHeadWork.CSTCLM_CUSTANALYSCODE2RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMCUSTANALYSCODE2RF" ) );
            frePBillHeadWork.CSTCLM_CUSTANALYSCODE3RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMCUSTANALYSCODE3RF" ) );
            frePBillHeadWork.CSTCLM_CUSTANALYSCODE4RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMCUSTANALYSCODE4RF" ) );
            frePBillHeadWork.CSTCLM_CUSTANALYSCODE5RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMCUSTANALYSCODE5RF" ) );
            frePBillHeadWork.CSTCLM_CUSTANALYSCODE6RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMCUSTANALYSCODE6RF" ) );
            frePBillHeadWork.CSTCLM_NOTE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE1RF" ) );
            frePBillHeadWork.CSTCLM_NOTE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE2RF" ) );
            frePBillHeadWork.CSTCLM_NOTE3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE3RF" ) );
            frePBillHeadWork.CSTCLM_NOTE4RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE4RF" ) );
            frePBillHeadWork.CSTCLM_NOTE5RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE5RF" ) );
            frePBillHeadWork.CSTCLM_NOTE6RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE6RF" ) );
            frePBillHeadWork.CSTCLM_NOTE7RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE7RF" ) );
            frePBillHeadWork.CSTCLM_NOTE8RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE8RF" ) );
            frePBillHeadWork.CSTCLM_NOTE9RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE9RF" ) );
            frePBillHeadWork.CSTCLM_NOTE10RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMNOTE10RF" ) );
            frePBillHeadWork.COMPANYINFRF_COMPANYNAME1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFCOMPANYNAME1RF" ) );
            frePBillHeadWork.COMPANYINFRF_COMPANYNAME2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFCOMPANYNAME2RF" ) );
            frePBillHeadWork.COMPANYINFRF_POSTNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFPOSTNORF" ) );
            frePBillHeadWork.COMPANYINFRF_ADDRESS1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFADDRESS1RF" ) );
            frePBillHeadWork.COMPANYINFRF_ADDRESS3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFADDRESS3RF" ) );
            frePBillHeadWork.COMPANYINFRF_ADDRESS4RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFADDRESS4RF" ) );
            frePBillHeadWork.COMPANYINFRF_COMPANYTELNO1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFCOMPANYTELNO1RF" ) );
            frePBillHeadWork.COMPANYINFRF_COMPANYTELNO2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFCOMPANYTELNO2RF" ) );
            frePBillHeadWork.COMPANYINFRF_COMPANYTELNO3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFCOMPANYTELNO3RF" ) );
            frePBillHeadWork.COMPANYINFRF_COMPANYTELTITLE1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFCOMPANYTELTITLE1RF" ) );
            frePBillHeadWork.COMPANYINFRF_COMPANYTELTITLE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFCOMPANYTELTITLE2RF" ) );
            frePBillHeadWork.COMPANYINFRF_COMPANYTELTITLE3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COMPANYINFRFCOMPANYTELTITLE3RF" ) );
            frePBillHeadWork.DEPOSITSTRF_DEPOSITSTKINDCD1RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITSTKINDCD1RF" ) );
            frePBillHeadWork.DEPOSITSTRF_DEPOSITSTKINDCD2RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITSTKINDCD2RF" ) );
            frePBillHeadWork.DEPOSITSTRF_DEPOSITSTKINDCD3RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITSTKINDCD3RF" ) );
            frePBillHeadWork.DEPOSITSTRF_DEPOSITSTKINDCD4RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITSTKINDCD4RF" ) );
            frePBillHeadWork.DEPOSITSTRF_DEPOSITSTKINDCD5RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITSTKINDCD5RF" ) );
            frePBillHeadWork.DEPOSITSTRF_DEPOSITSTKINDCD6RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITSTKINDCD6RF" ) );
            frePBillHeadWork.DEPOSITSTRF_DEPOSITSTKINDCD7RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITSTKINDCD7RF" ) );
            frePBillHeadWork.DEPOSITSTRF_DEPOSITSTKINDCD8RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITSTKINDCD8RF" ) );
            frePBillHeadWork.DEPOSITSTRF_DEPOSITSTKINDCD9RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITSTKINDCD9RF" ) );
            frePBillHeadWork.DEPOSITSTRF_DEPOSITSTKINDCD10RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITSTKINDCD10RF" ) );
            frePBillHeadWork.DEPT01_MONEYKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEPT01MONEYKINDNAMERF" ) );
            frePBillHeadWork.DEPT01_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPT01DEPOSITRF" ) );
            frePBillHeadWork.DEPT02_MONEYKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEPT02MONEYKINDNAMERF" ) );
            frePBillHeadWork.DEPT02_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPT02DEPOSITRF" ) );
            frePBillHeadWork.DEPT03_MONEYKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEPT03MONEYKINDNAMERF" ) );
            frePBillHeadWork.DEPT03_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPT03DEPOSITRF" ) );
            frePBillHeadWork.DEPT04_MONEYKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEPT04MONEYKINDNAMERF" ) );
            frePBillHeadWork.DEPT04_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPT04DEPOSITRF" ) );
            frePBillHeadWork.DEPT05_MONEYKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEPT05MONEYKINDNAMERF" ) );
            frePBillHeadWork.DEPT05_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPT05DEPOSITRF" ) );
            frePBillHeadWork.DEPT06_MONEYKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEPT06MONEYKINDNAMERF" ) );
            frePBillHeadWork.DEPT06_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPT06DEPOSITRF" ) );
            frePBillHeadWork.DEPT07_MONEYKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEPT07MONEYKINDNAMERF" ) );
            frePBillHeadWork.DEPT07_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPT07DEPOSITRF" ) );
            frePBillHeadWork.DEPT08_MONEYKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEPT08MONEYKINDNAMERF" ) );
            frePBillHeadWork.DEPT08_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPT08DEPOSITRF" ) );
            frePBillHeadWork.DEPT09_MONEYKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEPT09MONEYKINDNAMERF" ) );
            frePBillHeadWork.DEPT09_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPT09DEPOSITRF" ) );
            frePBillHeadWork.DEPT10_MONEYKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEPT10MONEYKINDNAMERF" ) );
            frePBillHeadWork.DEPT10_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPT10DEPOSITRF" ) );
            frePBillHeadWork.CSTCST_COLLECTMONEYNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTCOLLECTMONEYNAMERF" ) );
            frePBillHeadWork.CSTCST_COLLECTMONEYDAYRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCSTCOLLECTMONEYDAYRF" ) );
            frePBillHeadWork.CSTCST_HOMETELNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTHOMETELNORF" ) );
            frePBillHeadWork.CSTCST_OFFICETELNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTOFFICETELNORF" ) );
            frePBillHeadWork.CSTCST_PORTABLETELNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTPORTABLETELNORF" ) );
            frePBillHeadWork.CSTCST_HOMEFAXNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTHOMEFAXNORF" ) );
            frePBillHeadWork.CSTCST_OFFICEFAXNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTOFFICEFAXNORF" ) );
            frePBillHeadWork.CSTCST_OTHERSTELNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCSTOTHERSTELNORF" ) );
            frePBillHeadWork.CSTCLM_HOMETELNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMHOMETELNORF" ) );
            frePBillHeadWork.CSTCLM_OFFICETELNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMOFFICETELNORF" ) );
            frePBillHeadWork.CSTCLM_PORTABLETELNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMPORTABLETELNORF" ) );
            frePBillHeadWork.CSTCLM_HOMEFAXNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMHOMEFAXNORF" ) );
            frePBillHeadWork.CSTCLM_OFFICEFAXNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMOFFICEFAXNORF" ) );
            frePBillHeadWork.CSTCLM_OTHERSTELNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMOTHERSTELNORF" ) );
            frePBillHeadWork.CSTCLM_COLLECTMONEYNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMCOLLECTMONEYNAMERF" ) );
            frePBillHeadWork.CSTCLM_COLLECTMONEYDAYRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMCOLLECTMONEYDAYRF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_RESULTSSECTCDRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "RESULTSSECTCDRF" ) );
            frePBillHeadWork.ALITMDSPNMRF_HOMETELNODSPNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "HOMETELNODSPNAMERF" ) );
            frePBillHeadWork.ALITMDSPNMRF_OFFICETELNODSPNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "OFFICETELNODSPNAMERF" ) );
            frePBillHeadWork.ALITMDSPNMRF_MOBILETELNODSPNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MOBILETELNODSPNAMERF" ) );
            frePBillHeadWork.ALITMDSPNMRF_HOMEFAXNODSPNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "HOMEFAXNODSPNAMERF" ) );
            frePBillHeadWork.ALITMDSPNMRF_OFFICEFAXNODSPNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "OFFICEFAXNODSPNAMERF" ) );
            frePBillHeadWork.ALITMDSPNMRF_OTHERTELNODSPNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "OTHERTELNODSPNAMERF" ) );
            frePBillHeadWork.CSTCLM_SALESAREACODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMSALESAREACODERF" ) );
            frePBillHeadWork.CSTCLM_CUSTOMERAGENTCDRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMCUSTOMERAGENTCDRF" ) );
            frePBillHeadWork.CSTCLM_BILLCOLLECTERCDRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMBILLCOLLECTERCDRF" ) );
            frePBillHeadWork.CSTCLM_OLDCUSTOMERAGENTCDRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CSTCLMOLDCUSTOMERAGENTCDRF" ) );
            frePBillHeadWork.CSTCLM_CUSTAGENTCHGDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CSTCLMCUSTAGENTCHGDATERF" ) );
            frePBillHeadWork.CUSTDMDPRCRF_BILLNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "BILLNORF" ) );
            frePBillHeadWork.CSTCST_COLLECTMONEYCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCSTCOLLECTMONEYCODERF"));
            frePBillHeadWork.CSTCLM_COLLECTMONEYCODERF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCLMCOLLECTMONEYCODERF"));
            frePBillHeadWork.CSTCLM_TOTALDAYRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CSTCLMTOTALDAYRF"));
            # endregion

            return frePBillHeadWork;
        }
        /// <summary>
        /// 総括親への合算処理（親←親＋子）
        /// </summary>
        /// <param name="headWork"></param>
        /// <param name="childWork"></param>
         /// <remarks>
        /// <br>Note        : SQLDataReaderからの結果クラス取得処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void AddToSumCustParent( ref EBooksFrePBillHeadWork headWork, EBooksFrePBillHeadWork childWork )
        {
            # region [合算（親←親＋子）]
            headWork.CUSTDMDPRCRF_LASTTIMEDEMANDRF += childWork.CUSTDMDPRCRF_LASTTIMEDEMANDRF; // 前回請求金額
            headWork.CUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF += childWork.CUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF; // 今回手数料額（通常入金）
            headWork.CUSTDMDPRCRF_THISTIMEDISDMDNRMLRF += childWork.CUSTDMDPRCRF_THISTIMEDISDMDNRMLRF; // 今回値引額（通常入金）
            headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF += childWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF; // 今回入金金額（通常入金）
            headWork.CUSTDMDPRCRF_THISTIMETTLBLCDMDRF += childWork.CUSTDMDPRCRF_THISTIMETTLBLCDMDRF; // 今回繰越残高（請求計）
            headWork.CUSTDMDPRCRF_OFSTHISTIMESALESRF += childWork.CUSTDMDPRCRF_OFSTHISTIMESALESRF; // 相殺後今回売上金額
            headWork.CUSTDMDPRCRF_OFSTHISSALESTAXRF += childWork.CUSTDMDPRCRF_OFSTHISSALESTAXRF; // 相殺後今回売上消費税
            headWork.CUSTDMDPRCRF_ITDEDOFFSETOUTTAXRF += childWork.CUSTDMDPRCRF_ITDEDOFFSETOUTTAXRF; // 相殺後外税対象額
            headWork.CUSTDMDPRCRF_ITDEDOFFSETINTAXRF += childWork.CUSTDMDPRCRF_ITDEDOFFSETINTAXRF; // 相殺後内税対象額
            headWork.CUSTDMDPRCRF_ITDEDOFFSETTAXFREERF += childWork.CUSTDMDPRCRF_ITDEDOFFSETTAXFREERF; // 相殺後非課税対象額
            headWork.CUSTDMDPRCRF_OFFSETOUTTAXRF += childWork.CUSTDMDPRCRF_OFFSETOUTTAXRF; // 相殺後外税消費税
            headWork.CUSTDMDPRCRF_OFFSETINTAXRF += childWork.CUSTDMDPRCRF_OFFSETINTAXRF; // 相殺後内税消費税
            headWork.CUSTDMDPRCRF_THISTIMESALESRF += childWork.CUSTDMDPRCRF_THISTIMESALESRF; // 今回売上金額
            headWork.CUSTDMDPRCRF_THISSALESTAXRF += childWork.CUSTDMDPRCRF_THISSALESTAXRF; // 今回売上消費税
            headWork.CUSTDMDPRCRF_ITDEDSALESOUTTAXRF += childWork.CUSTDMDPRCRF_ITDEDSALESOUTTAXRF; // 売上外税対象額
            headWork.CUSTDMDPRCRF_ITDEDSALESINTAXRF += childWork.CUSTDMDPRCRF_ITDEDSALESINTAXRF; // 売上内税対象額
            headWork.CUSTDMDPRCRF_ITDEDSALESTAXFREERF += childWork.CUSTDMDPRCRF_ITDEDSALESTAXFREERF; // 売上非課税対象額
            headWork.CUSTDMDPRCRF_SALESOUTTAXRF += childWork.CUSTDMDPRCRF_SALESOUTTAXRF; // 売上外税額
            headWork.CUSTDMDPRCRF_SALESINTAXRF += childWork.CUSTDMDPRCRF_SALESINTAXRF; // 売上内税額
            headWork.CUSTDMDPRCRF_THISSALESPRICRGDSRF += childWork.CUSTDMDPRCRF_THISSALESPRICRGDSRF; // 今回売上返品金額
            headWork.CUSTDMDPRCRF_THISSALESPRCTAXRGDSRF += childWork.CUSTDMDPRCRF_THISSALESPRCTAXRGDSRF; // 今回売上返品消費税
            headWork.CUSTDMDPRCRF_TTLITDEDRETOUTTAXRF += childWork.CUSTDMDPRCRF_TTLITDEDRETOUTTAXRF; // 返品外税対象額合計
            headWork.CUSTDMDPRCRF_TTLITDEDRETINTAXRF += childWork.CUSTDMDPRCRF_TTLITDEDRETINTAXRF; // 返品内税対象額合計
            headWork.CUSTDMDPRCRF_TTLITDEDRETTAXFREERF += childWork.CUSTDMDPRCRF_TTLITDEDRETTAXFREERF; // 返品非課税対象額合計
            headWork.CUSTDMDPRCRF_TTLRETOUTERTAXRF += childWork.CUSTDMDPRCRF_TTLRETOUTERTAXRF; // 返品外税額合計
            headWork.CUSTDMDPRCRF_TTLRETINNERTAXRF += childWork.CUSTDMDPRCRF_TTLRETINNERTAXRF; // 返品内税額合計
            headWork.CUSTDMDPRCRF_THISSALESPRICDISRF += childWork.CUSTDMDPRCRF_THISSALESPRICDISRF; // 今回売上値引金額
            headWork.CUSTDMDPRCRF_THISSALESPRCTAXDISRF += childWork.CUSTDMDPRCRF_THISSALESPRCTAXDISRF; // 今回売上値引消費税
            headWork.CUSTDMDPRCRF_TTLITDEDDISOUTTAXRF += childWork.CUSTDMDPRCRF_TTLITDEDDISOUTTAXRF; // 値引外税対象額合計
            headWork.CUSTDMDPRCRF_TTLITDEDDISINTAXRF += childWork.CUSTDMDPRCRF_TTLITDEDDISINTAXRF; // 値引内税対象額合計
            headWork.CUSTDMDPRCRF_TTLITDEDDISTAXFREERF += childWork.CUSTDMDPRCRF_TTLITDEDDISTAXFREERF; // 値引非課税対象額合計
            headWork.CUSTDMDPRCRF_TTLDISOUTERTAXRF += childWork.CUSTDMDPRCRF_TTLDISOUTERTAXRF; // 値引外税額合計
            headWork.CUSTDMDPRCRF_TTLDISINNERTAXRF += childWork.CUSTDMDPRCRF_TTLDISINNERTAXRF; // 値引内税額合計
            headWork.CUSTDMDPRCRF_TAXADJUSTRF += childWork.CUSTDMDPRCRF_TAXADJUSTRF; // 消費税調整額
            headWork.CUSTDMDPRCRF_BALANCEADJUSTRF += childWork.CUSTDMDPRCRF_BALANCEADJUSTRF; // 残高調整額
            headWork.CUSTDMDPRCRF_AFCALDEMANDPRICERF += childWork.CUSTDMDPRCRF_AFCALDEMANDPRICERF; // 計算後請求金額
            headWork.CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF += childWork.CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF; // 受注2回前残高（請求計）
            headWork.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF += childWork.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF; // 受注3回前残高（請求計）
            headWork.CUSTDMDPRCRF_SALESSLIPCOUNTRF += childWork.CUSTDMDPRCRF_SALESSLIPCOUNTRF; // 売上伝票枚数
            headWork.DEPT01_DEPOSITRF += childWork.DEPT01_DEPOSITRF; // 入金金額１
            headWork.DEPT02_DEPOSITRF += childWork.DEPT02_DEPOSITRF; // 入金金額２
            headWork.DEPT03_DEPOSITRF += childWork.DEPT03_DEPOSITRF; // 入金金額３
            headWork.DEPT04_DEPOSITRF += childWork.DEPT04_DEPOSITRF; // 入金金額４
            headWork.DEPT05_DEPOSITRF += childWork.DEPT05_DEPOSITRF; // 入金金額５
            headWork.DEPT06_DEPOSITRF += childWork.DEPT06_DEPOSITRF; // 入金金額６
            headWork.DEPT07_DEPOSITRF += childWork.DEPT07_DEPOSITRF; // 入金金額７
            headWork.DEPT08_DEPOSITRF += childWork.DEPT08_DEPOSITRF; // 入金金額８
            headWork.DEPT09_DEPOSITRF += childWork.DEPT09_DEPOSITRF; // 入金金額９
            headWork.DEPT10_DEPOSITRF += childWork.DEPT10_DEPOSITRF; // 入金金額１０
            # endregion
        }
        /// <summary>
        /// 総括親の集計項目クリア用
        /// </summary>
        /// <param name="headWork"></param>
         /// <remarks>
        /// <br>Note        : SQLDataReaderからの結果クラス取得処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void ClearSumCustParent( ref EBooksFrePBillHeadWork headWork )
        {
            //---------------------------------------------------------
            // ※得意先総括設定に、親自身のコードが登録されていない時、
            //   親の分の金額等を除外する為に、ゼロクリアします。
            //---------------------------------------------------------
            # region [ゼロクリア]
            headWork.CUSTDMDPRCRF_LASTTIMEDEMANDRF = 0; // 前回請求金額
            headWork.CUSTDMDPRCRF_THISTIMEFEEDMDNRMLRF = 0; // 今回手数料額（通常入金）
            headWork.CUSTDMDPRCRF_THISTIMEDISDMDNRMLRF = 0; // 今回値引額（通常入金）
            headWork.CUSTDMDPRCRF_THISTIMEDMDNRMLRF = 0; // 今回入金金額（通常入金）
            headWork.CUSTDMDPRCRF_THISTIMETTLBLCDMDRF = 0; // 今回繰越残高（請求計）
            headWork.CUSTDMDPRCRF_OFSTHISTIMESALESRF = 0; // 相殺後今回売上金額
            headWork.CUSTDMDPRCRF_OFSTHISSALESTAXRF = 0; // 相殺後今回売上消費税
            headWork.CUSTDMDPRCRF_ITDEDOFFSETOUTTAXRF = 0; // 相殺後外税対象額
            headWork.CUSTDMDPRCRF_ITDEDOFFSETINTAXRF = 0; // 相殺後内税対象額
            headWork.CUSTDMDPRCRF_ITDEDOFFSETTAXFREERF = 0; // 相殺後非課税対象額
            headWork.CUSTDMDPRCRF_OFFSETOUTTAXRF = 0; // 相殺後外税消費税
            headWork.CUSTDMDPRCRF_OFFSETINTAXRF = 0; // 相殺後内税消費税
            headWork.CUSTDMDPRCRF_THISTIMESALESRF = 0; // 今回売上金額
            headWork.CUSTDMDPRCRF_THISSALESTAXRF = 0; // 今回売上消費税
            headWork.CUSTDMDPRCRF_ITDEDSALESOUTTAXRF = 0; // 売上外税対象額
            headWork.CUSTDMDPRCRF_ITDEDSALESINTAXRF = 0; // 売上内税対象額
            headWork.CUSTDMDPRCRF_ITDEDSALESTAXFREERF = 0; // 売上非課税対象額
            headWork.CUSTDMDPRCRF_SALESOUTTAXRF = 0; // 売上外税額
            headWork.CUSTDMDPRCRF_SALESINTAXRF = 0; // 売上内税額
            headWork.CUSTDMDPRCRF_THISSALESPRICRGDSRF = 0; // 今回売上返品金額
            headWork.CUSTDMDPRCRF_THISSALESPRCTAXRGDSRF = 0; // 今回売上返品消費税
            headWork.CUSTDMDPRCRF_TTLITDEDRETOUTTAXRF = 0; // 返品外税対象額合計
            headWork.CUSTDMDPRCRF_TTLITDEDRETINTAXRF = 0; // 返品内税対象額合計
            headWork.CUSTDMDPRCRF_TTLITDEDRETTAXFREERF = 0; // 返品非課税対象額合計
            headWork.CUSTDMDPRCRF_TTLRETOUTERTAXRF = 0; // 返品外税額合計
            headWork.CUSTDMDPRCRF_TTLRETINNERTAXRF = 0; // 返品内税額合計
            headWork.CUSTDMDPRCRF_THISSALESPRICDISRF = 0; // 今回売上値引金額
            headWork.CUSTDMDPRCRF_THISSALESPRCTAXDISRF = 0; // 今回売上値引消費税
            headWork.CUSTDMDPRCRF_TTLITDEDDISOUTTAXRF = 0; // 値引外税対象額合計
            headWork.CUSTDMDPRCRF_TTLITDEDDISINTAXRF = 0; // 値引内税対象額合計
            headWork.CUSTDMDPRCRF_TTLITDEDDISTAXFREERF = 0; // 値引非課税対象額合計
            headWork.CUSTDMDPRCRF_TTLDISOUTERTAXRF = 0; // 値引外税額合計
            headWork.CUSTDMDPRCRF_TTLDISINNERTAXRF = 0; // 値引内税額合計
            headWork.CUSTDMDPRCRF_TAXADJUSTRF = 0; // 消費税調整額
            headWork.CUSTDMDPRCRF_BALANCEADJUSTRF = 0; // 残高調整額
            headWork.CUSTDMDPRCRF_AFCALDEMANDPRICERF = 0; // 計算後請求金額
            headWork.CUSTDMDPRCRF_ACPODRTTL2TMBFBLDMDRF = 0; // 受注2回前残高（請求計）
            headWork.CUSTDMDPRCRF_ACPODRTTL3TMBFBLDMDRF = 0; // 受注3回前残高（請求計）
            headWork.CUSTDMDPRCRF_SALESSLIPCOUNTRF = 0; // 売上伝票枚数
            headWork.DEPT01_DEPOSITRF = 0; // 入金金額１
            headWork.DEPT02_DEPOSITRF = 0; // 入金金額２
            headWork.DEPT03_DEPOSITRF = 0; // 入金金額３
            headWork.DEPT04_DEPOSITRF = 0; // 入金金額４
            headWork.DEPT05_DEPOSITRF = 0; // 入金金額５
            headWork.DEPT06_DEPOSITRF = 0; // 入金金額６
            headWork.DEPT07_DEPOSITRF = 0; // 入金金額７
            headWork.DEPT08_DEPOSITRF = 0; // 入金金額８
            headWork.DEPT09_DEPOSITRF = 0; // 入金金額９
            headWork.DEPT10_DEPOSITRF = 0; // 入金金額１０
            # endregion
        }

        /// <summary>
        /// JOIN 条件生成
        /// </summary>
        /// <returns></returns>
        static private string GetJoinForHeadSection()
        {
            return "(( CUSTDMDPRCRF.CUSTOMERCODERF<>'0' AND CUSTDMDPRCRF.RESULTSSECTCDRF=SECHED.SECTIONCODERF ) "
                   + " OR ( CUSTDMDPRCRF.CUSTOMERCODERF='0' AND CUSTDMDPRCRF.ADDUPSECCODERF=SECHED.SECTIONCODERF )) ";
        }
        /// <summary>
        /// SELECT項目 取得処理（ヘッダ）
        /// </summary>
        /// <param name="extPrm">検索条件</param>
        /// <returns>ヘッダ取得項目</returns>
        /// <remarks>
        /// <br>Note        : SELECT項目 取得処理（ヘッダ）</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// <br>Update Note  : 2022/10/18 田村顕成</br>
        /// <br>管理番号     : 11870141-00 インボイス残対応（軽減税率対応）</br>
        /// </remarks>
        private string GetSelectItemsForHead( EBooksFrePBillParaWork extPrm )
        {
            //---------------------------------------------------------------------------------
            // 注意：同じテーブルを複数回JOINする場合は、Selectに与える項目名称もAsで別名にする。
            //       最後の項目は後ろにカンマ(,)を付けない。
            //---------------------------------------------------------------------------------
            StringBuilder sb = new StringBuilder();

            // 自由帳票レイアウトとは別に制御用に取得が必要
            sb.Append( "CUSTDMDPRCRF.STARTCADDUPUPDDATERF, " + Environment.NewLine );

            # region [項目名]
            sb.Append( "CUSTDMDPRCRF.BILLNORF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.ADDUPSECCODERF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.CLAIMCODERF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.CLAIMNAMERF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.CLAIMNAME2RF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.CLAIMSNMRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.CUSTOMERCODERF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.CUSTOMERNAMERF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.CUSTOMERNAME2RF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.CUSTOMERSNMRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.ADDUPDATERF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.ADDUPYEARMONTHRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.LASTTIMEDEMANDRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.THISTIMEFEEDMDNRMLRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.THISTIMEDISDMDNRMLRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.THISTIMEDMDNRMLRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.THISTIMETTLBLCDMDRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.OFSTHISTIMESALESRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.OFSTHISSALESTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.ITDEDOFFSETOUTTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.ITDEDOFFSETINTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.ITDEDOFFSETTAXFREERF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.OFFSETOUTTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.OFFSETINTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.THISTIMESALESRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.THISSALESTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.ITDEDSALESOUTTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.ITDEDSALESINTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.ITDEDSALESTAXFREERF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.SALESOUTTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.SALESINTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.THISSALESPRICRGDSRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.THISSALESPRCTAXRGDSRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.TTLITDEDRETOUTTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.TTLITDEDRETINTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.TTLITDEDRETTAXFREERF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.TTLRETOUTERTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.TTLRETINNERTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.THISSALESPRICDISRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.THISSALESPRCTAXDISRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.TTLITDEDDISOUTTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.TTLITDEDDISINTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.TTLITDEDDISTAXFREERF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.TTLDISOUTERTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.TTLDISINNERTAXRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.TAXADJUSTRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.BALANCEADJUSTRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.AFCALDEMANDPRICERF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.ACPODRTTL2TMBFBLDMDRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.ACPODRTTL3TMBFBLDMDRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.STARTCADDUPUPDDATERF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.SALESSLIPCOUNTRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.BILLPRINTDATERF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.EXPECTEDDEPOSITDATERF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.COLLECTCONDRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.CONSTAXLAYMETHODRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.CONSTAXRATERF, " + Environment.NewLine );
            sb.Append( "SECHED.SECTIONGUIDENMRF AS SECHEDSECTIONGUIDENMRF, " + Environment.NewLine );
            sb.Append( "SECHED.SECTIONGUIDESNMRF AS SECHEDSECTIONGUIDESNMRF, " + Environment.NewLine );
            sb.Append( "SECHED.COMPANYNAMECD1RF AS SECHEDCOMPANYNAMECD1RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.COMPANYPRRF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.COMPANYNAME1RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.COMPANYNAME2RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.POSTNORF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.ADDRESS1RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.ADDRESS3RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.ADDRESS4RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.COMPANYTELNO1RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.COMPANYTELNO2RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.COMPANYTELNO3RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.COMPANYTELTITLE1RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.COMPANYTELTITLE2RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.COMPANYTELTITLE3RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.TRANSFERGUIDANCERF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.ACCOUNTNOINFO1RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.ACCOUNTNOINFO2RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.ACCOUNTNOINFO3RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.COMPANYSETNOTE1RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.COMPANYSETNOTE2RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.IMAGEINFOCODERF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.COMPANYURLRF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.COMPANYPRSENTENCE2RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.IMAGECOMMENTFORPRT1RF, " + Environment.NewLine );
            sb.Append( "COMPANYNMRF.IMAGECOMMENTFORPRT2RF, " + Environment.NewLine );
            sb.Append( "IMAGEINFORF.IMAGEINFODATARF, " + Environment.NewLine );
            sb.Append( "CSTCST.CUSTOMERSUBCODERF AS CSTCSTCUSTOMERSUBCODERF, " + Environment.NewLine );
            sb.Append( "CSTCST.NAMERF AS CSTCSTNAMERF, " + Environment.NewLine );
            sb.Append( "CSTCST.NAME2RF AS CSTCSTNAME2RF, " + Environment.NewLine );
            sb.Append( "CSTCST.HONORIFICTITLERF AS CSTCSTHONORIFICTITLERF, " + Environment.NewLine );
            sb.Append( "CSTCST.KANARF AS CSTCSTKANARF, " + Environment.NewLine );
            sb.Append( "CSTCST.CUSTOMERSNMRF AS CSTCSTCUSTOMERSNMRF, " + Environment.NewLine );
            sb.Append( "CSTCST.OUTPUTNAMECODERF AS CSTCSTOUTPUTNAMECODERF, " + Environment.NewLine );
            sb.Append( "CSTCST.POSTNORF AS CSTCSTPOSTNORF, " + Environment.NewLine );
            sb.Append( "CSTCST.ADDRESS1RF AS CSTCSTADDRESS1RF, " + Environment.NewLine );
            sb.Append( "CSTCST.ADDRESS3RF AS CSTCSTADDRESS3RF, " + Environment.NewLine );
            sb.Append( "CSTCST.ADDRESS4RF AS CSTCSTADDRESS4RF, " + Environment.NewLine );
            sb.Append( "CSTCST.CUSTANALYSCODE1RF AS CSTCSTCUSTANALYSCODE1RF, " + Environment.NewLine );
            sb.Append( "CSTCST.CUSTANALYSCODE2RF AS CSTCSTCUSTANALYSCODE2RF, " + Environment.NewLine );
            sb.Append( "CSTCST.CUSTANALYSCODE3RF AS CSTCSTCUSTANALYSCODE3RF, " + Environment.NewLine );
            sb.Append( "CSTCST.CUSTANALYSCODE4RF AS CSTCSTCUSTANALYSCODE4RF, " + Environment.NewLine );
            sb.Append( "CSTCST.CUSTANALYSCODE5RF AS CSTCSTCUSTANALYSCODE5RF, " + Environment.NewLine );
            sb.Append( "CSTCST.CUSTANALYSCODE6RF AS CSTCSTCUSTANALYSCODE6RF, " + Environment.NewLine );
            sb.Append( "CSTCST.NOTE1RF AS CSTCSTNOTE1RF, " + Environment.NewLine );
            sb.Append( "CSTCST.NOTE2RF AS CSTCSTNOTE2RF, " + Environment.NewLine );
            sb.Append( "CSTCST.NOTE3RF AS CSTCSTNOTE3RF, " + Environment.NewLine );
            sb.Append( "CSTCST.NOTE4RF AS CSTCSTNOTE4RF, " + Environment.NewLine );
            sb.Append( "CSTCST.NOTE5RF AS CSTCSTNOTE5RF, " + Environment.NewLine );
            sb.Append( "CSTCST.NOTE6RF AS CSTCSTNOTE6RF, " + Environment.NewLine );
            sb.Append( "CSTCST.NOTE7RF AS CSTCSTNOTE7RF, " + Environment.NewLine );
            sb.Append( "CSTCST.NOTE8RF AS CSTCSTNOTE8RF, " + Environment.NewLine );
            sb.Append( "CSTCST.NOTE9RF AS CSTCSTNOTE9RF, " + Environment.NewLine );
            sb.Append( "CSTCST.NOTE10RF AS CSTCSTNOTE10RF, " + Environment.NewLine );
            // --- ADD START 田村顕成 2022/10/18 ----->>>>>
            sb.Append("CSTCLM.SALESCNSTAXFRCPROCCDRF AS CSTCLMSALESCNSTAXFRCPROCCDRF, " + Environment.NewLine);
            // --- ADD END 田村顕成 2022/10/18 -----<<<<<
            sb.Append( "CSTCLM.CUSTOMERSUBCODERF AS CSTCLMCUSTOMERSUBCODERF, " + Environment.NewLine );
            sb.Append( "CSTCLM.NAMERF AS CSTCLMNAMERF, " + Environment.NewLine );
            sb.Append( "CSTCLM.NAME2RF AS CSTCLMNAME2RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.HONORIFICTITLERF AS CSTCLMHONORIFICTITLERF, " + Environment.NewLine );
            sb.Append( "CSTCLM.KANARF AS CSTCLMKANARF, " + Environment.NewLine );
            sb.Append( "CSTCLM.CUSTOMERSNMRF AS CSTCLMCUSTOMERSNMRF, " + Environment.NewLine );
            sb.Append( "CSTCLM.OUTPUTNAMECODERF AS CSTCLMOUTPUTNAMECODERF, " + Environment.NewLine );
            sb.Append( "CSTCLM.POSTNORF AS CSTCLMPOSTNORF, " + Environment.NewLine );
            sb.Append( "CSTCLM.ADDRESS1RF AS CSTCLMADDRESS1RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.ADDRESS3RF AS CSTCLMADDRESS3RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.ADDRESS4RF AS CSTCLMADDRESS4RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.CUSTANALYSCODE1RF AS CSTCLMCUSTANALYSCODE1RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.CUSTANALYSCODE2RF AS CSTCLMCUSTANALYSCODE2RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.CUSTANALYSCODE3RF AS CSTCLMCUSTANALYSCODE3RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.CUSTANALYSCODE4RF AS CSTCLMCUSTANALYSCODE4RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.CUSTANALYSCODE5RF AS CSTCLMCUSTANALYSCODE5RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.CUSTANALYSCODE6RF AS CSTCLMCUSTANALYSCODE6RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.NOTE1RF AS CSTCLMNOTE1RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.NOTE2RF AS CSTCLMNOTE2RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.NOTE3RF AS CSTCLMNOTE3RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.NOTE4RF AS CSTCLMNOTE4RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.NOTE5RF AS CSTCLMNOTE5RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.NOTE6RF AS CSTCLMNOTE6RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.NOTE7RF AS CSTCLMNOTE7RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.NOTE8RF AS CSTCLMNOTE8RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.NOTE9RF AS CSTCLMNOTE9RF, " + Environment.NewLine );
            sb.Append( "CSTCLM.NOTE10RF AS CSTCLMNOTE10RF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.COMPANYNAME1RF AS COMPANYINFRFCOMPANYNAME1RF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.COMPANYNAME2RF AS COMPANYINFRFCOMPANYNAME2RF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.POSTNORF AS COMPANYINFRFPOSTNORF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.ADDRESS1RF AS COMPANYINFRFADDRESS1RF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.ADDRESS3RF AS COMPANYINFRFADDRESS3RF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.ADDRESS4RF AS COMPANYINFRFADDRESS4RF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.COMPANYTELNO1RF AS COMPANYINFRFCOMPANYTELNO1RF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.COMPANYTELNO2RF AS COMPANYINFRFCOMPANYTELNO2RF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.COMPANYTELNO3RF AS COMPANYINFRFCOMPANYTELNO3RF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.COMPANYTELTITLE1RF AS COMPANYINFRFCOMPANYTELTITLE1RF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.COMPANYTELTITLE2RF AS COMPANYINFRFCOMPANYTELTITLE2RF, " + Environment.NewLine );
            sb.Append( "COMPANYINFRF.COMPANYTELTITLE3RF AS COMPANYINFRFCOMPANYTELTITLE3RF, " + Environment.NewLine );
            sb.Append( "DEPOSITSTRF.DEPOSITSTKINDCD1RF, " + Environment.NewLine );
            sb.Append( "DEPOSITSTRF.DEPOSITSTKINDCD2RF, " + Environment.NewLine );
            sb.Append( "DEPOSITSTRF.DEPOSITSTKINDCD3RF, " + Environment.NewLine );
            sb.Append( "DEPOSITSTRF.DEPOSITSTKINDCD4RF, " + Environment.NewLine );
            sb.Append( "DEPOSITSTRF.DEPOSITSTKINDCD5RF, " + Environment.NewLine );
            sb.Append( "DEPOSITSTRF.DEPOSITSTKINDCD6RF, " + Environment.NewLine );
            sb.Append( "DEPOSITSTRF.DEPOSITSTKINDCD7RF, " + Environment.NewLine );
            sb.Append( "DEPOSITSTRF.DEPOSITSTKINDCD8RF, " + Environment.NewLine );
            sb.Append( "DEPOSITSTRF.DEPOSITSTKINDCD9RF, " + Environment.NewLine );
            sb.Append( "DEPOSITSTRF.DEPOSITSTKINDCD10RF, " + Environment.NewLine );
            sb.Append( "DEPT01.MONEYKINDNAMERF AS DEPT01MONEYKINDNAMERF, " + Environment.NewLine );
            sb.Append( "DEPT01.DEPOSITRF AS DEPT01DEPOSITRF, " + Environment.NewLine );
            sb.Append( "DEPT02.MONEYKINDNAMERF AS DEPT02MONEYKINDNAMERF, " + Environment.NewLine );
            sb.Append( "DEPT02.DEPOSITRF AS DEPT02DEPOSITRF, " + Environment.NewLine );
            sb.Append( "DEPT03.MONEYKINDNAMERF AS DEPT03MONEYKINDNAMERF, " + Environment.NewLine );
            sb.Append( "DEPT03.DEPOSITRF AS DEPT03DEPOSITRF, " + Environment.NewLine );
            sb.Append( "DEPT04.MONEYKINDNAMERF AS DEPT04MONEYKINDNAMERF, " + Environment.NewLine );
            sb.Append( "DEPT04.DEPOSITRF AS DEPT04DEPOSITRF, " + Environment.NewLine );
            sb.Append( "DEPT05.MONEYKINDNAMERF AS DEPT05MONEYKINDNAMERF, " + Environment.NewLine );
            sb.Append( "DEPT05.DEPOSITRF AS DEPT05DEPOSITRF, " + Environment.NewLine );
            sb.Append( "DEPT06.MONEYKINDNAMERF AS DEPT06MONEYKINDNAMERF, " + Environment.NewLine );
            sb.Append( "DEPT06.DEPOSITRF AS DEPT06DEPOSITRF, " + Environment.NewLine );
            sb.Append( "DEPT07.MONEYKINDNAMERF AS DEPT07MONEYKINDNAMERF, " + Environment.NewLine );
            sb.Append( "DEPT07.DEPOSITRF AS DEPT07DEPOSITRF, " + Environment.NewLine );
            sb.Append( "DEPT08.MONEYKINDNAMERF AS DEPT08MONEYKINDNAMERF, " + Environment.NewLine );
            sb.Append( "DEPT08.DEPOSITRF AS DEPT08DEPOSITRF, " + Environment.NewLine );
            sb.Append( "DEPT09.MONEYKINDNAMERF AS DEPT09MONEYKINDNAMERF, " + Environment.NewLine );
            sb.Append( "DEPT09.DEPOSITRF AS DEPT09DEPOSITRF, " + Environment.NewLine );
            sb.Append( "DEPT10.MONEYKINDNAMERF AS DEPT10MONEYKINDNAMERF, " + Environment.NewLine );
            sb.Append( "DEPT10.DEPOSITRF AS DEPT10DEPOSITRF, " + Environment.NewLine );
            sb.Append( "CSTCST.COLLECTMONEYNAMERF AS CSTCSTCOLLECTMONEYNAMERF, " + Environment.NewLine );
            sb.Append( "CSTCST.COLLECTMONEYDAYRF AS CSTCSTCOLLECTMONEYDAYRF, " + Environment.NewLine );
            sb.Append("CSTCST.COLLECTMONEYCODERF AS CSTCSTCOLLECTMONEYCODERF, " + Environment.NewLine);
            sb.Append("CSTCLM.COLLECTMONEYCODERF AS CSTCLMCOLLECTMONEYCODERF, " + Environment.NewLine);
            sb.Append("CSTCLM.TOTALDAYRF AS CSTCLMTOTALDAYRF, " + Environment.NewLine);
            sb.Append( "CSTCST.HOMETELNORF AS CSTCSTHOMETELNORF, " + Environment.NewLine );
            sb.Append( "CSTCST.OFFICETELNORF AS CSTCSTOFFICETELNORF, " + Environment.NewLine );
            sb.Append( "CSTCST.PORTABLETELNORF AS CSTCSTPORTABLETELNORF, " + Environment.NewLine );
            sb.Append( "CSTCST.HOMEFAXNORF AS CSTCSTHOMEFAXNORF, " + Environment.NewLine );
            sb.Append( "CSTCST.OFFICEFAXNORF AS CSTCSTOFFICEFAXNORF, " + Environment.NewLine );
            sb.Append( "CSTCST.OTHERSTELNORF AS CSTCSTOTHERSTELNORF, " + Environment.NewLine );
            sb.Append( "CSTCLM.HOMETELNORF AS CSTCLMHOMETELNORF, " + Environment.NewLine );
            sb.Append( "CSTCLM.OFFICETELNORF AS CSTCLMOFFICETELNORF, " + Environment.NewLine );
            sb.Append( "CSTCLM.PORTABLETELNORF AS CSTCLMPORTABLETELNORF, " + Environment.NewLine );
            sb.Append( "CSTCLM.HOMEFAXNORF AS CSTCLMHOMEFAXNORF, " + Environment.NewLine );
            sb.Append( "CSTCLM.OFFICEFAXNORF AS CSTCLMOFFICEFAXNORF, " + Environment.NewLine );
            sb.Append( "CSTCLM.OTHERSTELNORF AS CSTCLMOTHERSTELNORF, " + Environment.NewLine );
            sb.Append( "CSTCLM.COLLECTMONEYNAMERF AS CSTCLMCOLLECTMONEYNAMERF, " + Environment.NewLine );
            sb.Append( "CSTCLM.COLLECTMONEYDAYRF AS CSTCLMCOLLECTMONEYDAYRF, " + Environment.NewLine );
            sb.Append( "CUSTDMDPRCRF.RESULTSSECTCDRF, " + Environment.NewLine );
            sb.Append( "ALITMDSPNMRF.HOMETELNODSPNAMERF, " + Environment.NewLine );
            sb.Append( "ALITMDSPNMRF.OFFICETELNODSPNAMERF, " + Environment.NewLine );
            sb.Append( "ALITMDSPNMRF.MOBILETELNODSPNAMERF, " + Environment.NewLine );
            sb.Append( "ALITMDSPNMRF.HOMEFAXNODSPNAMERF, " + Environment.NewLine );
            sb.Append( "ALITMDSPNMRF.OFFICEFAXNODSPNAMERF, " + Environment.NewLine );
            sb.Append( "ALITMDSPNMRF.OTHERTELNODSPNAMERF, " + Environment.NewLine );
            sb.Append( "CSTCLM.SALESAREACODERF AS CSTCLMSALESAREACODERF, " + Environment.NewLine );
            sb.Append( "CSTCLM.CUSTOMERAGENTCDRF AS CSTCLMCUSTOMERAGENTCDRF, " + Environment.NewLine );
            sb.Append( "CSTCLM.BILLCOLLECTERCDRF AS CSTCLMBILLCOLLECTERCDRF, " + Environment.NewLine );
            sb.Append( "CSTCLM.OLDCUSTOMERAGENTCDRF AS CSTCLMOLDCUSTOMERAGENTCDRF, " + Environment.NewLine );
            sb.Append("CSTCLM.CUSTAGENTCHGDATERF AS CSTCLMCUSTAGENTCHGDATERF " + Environment.NewLine);// ←最後の項目はカンマなし
            # endregion

            return sb.ToString();
        }

        /// <summary>
        /// WHERE文作成処理
        /// </summary>
        /// <param name="sqlCommand">SQLコマンド</param>
        /// <param name="extPrm">自由帳票共通抽出条件クラス</param>
        /// <param name="_sumCustChildDic">子集計Dic</param>
        /// <returns>WHERE文</returns>
        /// <remarks>
        /// <br>Note        : WHERE文作成処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private string MakeWhereStringForHead(ref SqlCommand sqlCommand, EBooksFrePBillParaWork extPrm, Dictionary<int, List<KeyValuePair<string, int>>> _sumCustChildDic)
        {
            StringBuilder whereString = new StringBuilder();

            // 企業コードは必須条件
            whereString.Append( " WHERE CUSTDMDPRCRF.ENTERPRISECODERF=@FINDENTERPRISECODE " );
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
            findParaEnterpriseCode.Value = extPrm.EnterpriseCode;

            whereString.Append( " AND ( " );
            for ( int index = 0; index < extPrm.FrePBillParaKeyList.Count; index++ )
            {
                if ( index > 0 )
                {
                    whereString.Append( " OR " );
                }


                    //--------------------------------------------------
                    // 請求書
                    //--------------------------------------------------
                    # region [請求書]
                    // WHERE
                    whereString.Append( string.Format( "(CUSTDMDPRCRF.ADDUPSECCODERF=@FINDADDUPSECCODE{0} "
                                                     + " AND CUSTDMDPRCRF.CLAIMCODERF=@FINDCLAIMCODE{0} "
                                                     + " AND CUSTDMDPRCRF.RESULTSSECTCDRF=@FINDRESULTSSECTCD{0} "
                                                     + " AND CUSTDMDPRCRF.CUSTOMERCODERF=@FINDCUSTOMERCODE{0} " 
                                                     + " AND CUSTDMDPRCRF.ADDUPDATERF=@FINDADDUPDATE{0})", index ) );

                    // 計上拠点コード
                    SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add( string.Format( "@FINDADDUPSECCODE{0}", index ), SqlDbType.NChar );
                    paraAddUpSecCode.Value = extPrm.FrePBillParaKeyList[index].AddUpSecCode;

                    // 請求先コード
                    SqlParameter paraClaimCode = sqlCommand.Parameters.Add( string.Format( "@FINDCLAIMCODE{0}", index ), SqlDbType.Int );
                    paraClaimCode.Value = extPrm.FrePBillParaKeyList[index].ClaimCode;

                    // 実績拠点コード
                    SqlParameter paraResultsSectCd = sqlCommand.Parameters.Add( string.Format( "@FINDRESULTSSECTCD{0}", index ), SqlDbType.NChar );
                    paraResultsSectCd.Value = extPrm.FrePBillParaKeyList[index].ResultsSectCd;

                    // 得意先コード
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add( string.Format( "@FINDCUSTOMERCODE{0}", index ), SqlDbType.Int );
                    paraCustomerCode.Value = extPrm.FrePBillParaKeyList[index].CustomerCode;

                    // 計上年月日
                    SqlParameter paraAddUpDate = sqlCommand.Parameters.Add( string.Format( "@FINDADDUPDATE{0}", index ), SqlDbType.Int );
                    paraAddUpDate.Value = extPrm.FrePBillParaKeyList[index].GetAddUpDateLongDate();
                    # endregion

                whereString.Append( Environment.NewLine );
            }
            whereString.Append( " ) " + Environment.NewLine );

            return whereString.ToString();
        }

        /// <summary>
        /// 締範囲取得処理
        /// </summary>
        /// <param name="extPrm">検索条件</param>
        /// <param name="billList">請求ヘッダリスト</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="_dmdRangeEachClaimDic">請求単位Dic</param>
        /// <param name="requestMessage">請求書ログ出力用メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 締範囲取得処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private int SearchProcOfDmdRangeSt(EBooksFrePBillParaWork extPrm, List<EBooksFrePBillHeadWork> billList, SqlConnection sqlConnection, ref Dictionary<string, DmdRangeEachClaim> _dmdRangeEachClaimDic, ref Dictionary<string, object> requestMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            foreach ( EBooksFrePBillHeadWork headWork in billList )
            {
                status = SearchProcOfDmdRangeStProc(extPrm, headWork, sqlConnection, ref  _dmdRangeEachClaimDic, ref requestMessage);
                if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL ) break;
            }

            return status;
        }
        /// <summary>
        /// 締範囲取得処理
        /// </summary>
        /// <param name="extPrm">検索条件</param>
        /// <param name="headWork">ヘッダワーク</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="_dmdRangeEachClaimDic">請求単位Dic</param>
        /// <param name="requestMessage">請求書ログ出力用メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 締範囲取得処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private int SearchProcOfDmdRangeStProc(EBooksFrePBillParaWork extPrm, EBooksFrePBillHeadWork headWork, SqlConnection sqlConnection, ref Dictionary<string, DmdRangeEachClaim> _dmdRangeEachClaimDic, ref Dictionary<string, object> requestMessage)
        {
            //----------------------------------------------------------------
            // ※SearchProcOfBillですでに締開始日を取得済みだが、
            //   ここではテーブル上のレコードを参照して前回レコード内容より
            //   再セットを行う。
            //----------------------------------------------------------------


            SqlDataReader myReader = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // キー生成
            DmdRangeEachClaimKey key = new DmdRangeEachClaimKey( headWork.CUSTDMDPRCRF_ADDUPSECCODERF.Trim(), headWork.CUSTDMDPRCRF_CLAIMCODERF,
                                                                 headWork.CUSTDMDPRCRF_RESULTSSECTCDRF.Trim(), headWork.CUSTDMDPRCRF_CUSTOMERCODERF );

            // ディクショナリに無い or ディクショナリにあるが初期値以外である場合は迂回
            string keyString = key.CreateKey();

            //請求書ログ出力用
            if (requestMessage.ContainsKey("締め範囲取得前開始日付") == false)
            {
                requestMessage.Add("締め範囲取得前開始日付", _dmdRangeEachClaimDic[keyString].DmdRangeSt);
            }

            if ( !_dmdRangeEachClaimDic.ContainsKey( keyString ) || _dmdRangeEachClaimDic[keyString].DmdRangeSt != 0 )
            {
                return status;
            }

            try
            {
                //-------------------------------------------------------------------
                // 対象テーブル
                //   得意先請求金額マスタ　　　CustDmdPrcRF
                //-------------------------------------------------------------------
                SqlCommand sqlCommand = new SqlCommand(
                    "SELECT " + Environment.NewLine
                    + " ENTERPRISECODERF, ADDUPSECCODERF, CLAIMCODERF, RESULTSSECTCDRF, CUSTOMERCODERF, MAX(ADDUPDATERF) AS MAXADDUPDATERF " + Environment.NewLine
                    + "FROM CUSTDMDPRCRF " + Environment.NewLine
                    + "WHERE " + Environment.NewLine
                    + "  ENTERPRISECODERF=@FINDENTERPRISECODE AND " + Environment.NewLine
                    + "  ADDUPSECCODERF=@FINDADDUPSECCODE AND " + Environment.NewLine
                    + "  CLAIMCODERF=@FINDCLAIMCODE AND " + Environment.NewLine
                    + "  RESULTSSECTCDRF=@FINDRESULTSSECTCD AND " + Environment.NewLine
                    + "  CUSTOMERCODERF=@FINDCUSTOMERCODE AND " + Environment.NewLine
                    + "  ADDUPDATERF<@FINDADDUPDATE " + Environment.NewLine
                    + "GROUP BY " + Environment.NewLine
                    + "  ENTERPRISECODERF, ADDUPSECCODERF, CLAIMCODERF, RESULTSSECTCDRF, CUSTOMERCODERF " + Environment.NewLine
                    , sqlConnection );

                // WHEREの条件
                // (企業コード)
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
                findParaEnterpriseCode.Value = extPrm.EnterpriseCode;
                // (計上拠点コード)
                SqlParameter findParaAddUpSecCode = sqlCommand.Parameters.Add( "@FINDADDUPSECCODE", SqlDbType.NChar );
                findParaAddUpSecCode.Value = headWork.CUSTDMDPRCRF_ADDUPSECCODERF;
                // (請求先コード)
                SqlParameter findParaClaimCode = sqlCommand.Parameters.Add( "@FINDCLAIMCODE", SqlDbType.Int );
                findParaClaimCode.Value = headWork.CUSTDMDPRCRF_CLAIMCODERF;
                // (実績拠点コード)
                SqlParameter findParaResultsSectCd = sqlCommand.Parameters.Add( "@FINDRESULTSSECTCD", SqlDbType.NChar );
                findParaResultsSectCd.Value = headWork.CUSTDMDPRCRF_RESULTSSECTCDRF;
                // (得意先コード)
                SqlParameter findParaCustomerCode = sqlCommand.Parameters.Add( "@FINDCUSTOMERCODE", SqlDbType.Int );
                findParaCustomerCode.Value = headWork.CUSTDMDPRCRF_CUSTOMERCODERF;
                // (計上日終了...今回の１つ前を得る為"<"指定)
                SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add( "@FINDADDUPDATE", SqlDbType.Int );
                findParaAddUpDate.Value = headWork.CUSTDMDPRCRF_ADDUPDATERF;


                // タイムアウト時間設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut( RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide );

                //請求書ログ出力用
                if (requestMessage.ContainsKey("前回締日取得クエリ") == false)
                {
                    requestMessage.Add("前回締日取得クエリ", sqlCommand.CommandText);
                }
                myReader = sqlCommand.ExecuteReader();


                while ( myReader.Read() )
                {
                    // 前回締日取得
                    int dmdRangeSt = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MAXADDUPDATERF" ) );

                    if ( dmdRangeSt != 0 )
                    {
                        DateTime dmdRangeStDate;
                        try
                        {
                            // 前回締日＋１の日付にする（今回締開始日）
                            dmdRangeStDate = new DateTime( dmdRangeSt / 10000, (dmdRangeSt / 100) % 100, dmdRangeSt % 100 );
                            dmdRangeStDate = dmdRangeStDate.AddDays( 1 );
                            dmdRangeSt = (dmdRangeStDate.Year * 10000) + (dmdRangeStDate.Month * 100) + dmdRangeStDate.Day;
                            //請求書ログ出力用
                            if (requestMessage.ContainsKey("前回締日＋１") == false)
                            {
                                requestMessage.Add("前回締日＋１", dmdRangeSt);
                            }
                        }
                        catch
                        {
                            break;
                        }

                        string currKeyString = key.CreateKey();
                        if ( _dmdRangeEachClaimDic.ContainsKey( currKeyString ) )
                        {
                            // 今回締開始日の書き換え（値型なので一度削除して再度追加）
                            DmdRangeEachClaim dmdRangeEachClaim = _dmdRangeEachClaimDic[currKeyString];
                            dmdRangeEachClaim.DmdRangeSt = dmdRangeSt;
                            _dmdRangeEachClaimDic.Remove( currKeyString );
                            _dmdRangeEachClaimDic.Add( currKeyString, dmdRangeEachClaim );
                        }
                    }

                    break;
                }

            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "SearchProc\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR );
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if ( myReader != null )
                {
                    if ( !myReader.IsClosed )
                        myReader.Close();
                }
            }

            return status;
        }

        /// <summary>
        /// Search 対象得意先
        /// </summary>
        /// <param name="extPrm">検索条件</param>
        /// <param name="targetDate">計上日</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="_childCustomerDic">子集計Dic</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : Search 対象得意先</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private int SearchProcOfTargetCustomers(EBooksFrePBillParaWork extPrm, int targetDate, SqlConnection sqlConnection, ref Dictionary<int, List<int>> _childCustomerDic)
        {
            SqlDataReader myReader = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // ディクショナリのクリア
            // 親得意先ディクショナリ（子→親）
            Dictionary<int, List<DmdSummaryKey>> _parentCustomerDic = new Dictionary<int, List<DmdSummaryKey>>();

            try
            {
                //-------------------------------------------------------------------
                // 対象テーブル
                //   得意先請求金額マスタ　　　CustDmdPrcRF
                //-------------------------------------------------------------------
                SqlCommand sqlCommand = new SqlCommand(
                    "SELECT " + Environment.NewLine
                    + "  ADDUPSECCODERF, CLAIMCODERF, CUSTOMERCODERF " + Environment.NewLine
                    + "FROM CUSTDMDPRCRF " + Environment.NewLine
                    + "WHERE " + Environment.NewLine
                    + "  ENTERPRISECODERF=@FINDENTERPRISECODE " + Environment.NewLine
                    + "  AND ADDUPDATERF=@FINDADDUPDATE " + Environment.NewLine
                    + "  AND CUSTOMERCODERF<>'0'" + Environment.NewLine
                    + "GROUP BY " + Environment.NewLine
                    + "  ADDUPSECCODERF, CLAIMCODERF, CUSTOMERCODERF " + Environment.NewLine
                    , sqlConnection );

                // WHEREの条件
                // (企業コード)
                SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
                findParaEnterpriseCode.Value = extPrm.EnterpriseCode;
                // (計上日)
                SqlParameter findParaAddUpDate = sqlCommand.Parameters.Add( "@FINDADDUPDATE", SqlDbType.Int );
                findParaAddUpDate.Value = targetDate;


                // タイムアウト時間設定
                sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut( RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide );
                myReader = sqlCommand.ExecuteReader();


                while ( myReader.Read() )
                {
                    // 計上拠点コード
                    string addUpSecCode = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDUPSECCODERF" ) );
                    // 請求先(親)
                    int claimCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CLAIMCODERF" ) );
                    // 得意先(子)
                    int customerCode = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CUSTOMERCODERF" ) );


                    // 【子→親】ディクショナリに追加
                    // （念の為、親は複数持てる構造にしておく。
                    //   通常の運用では子→親で該当は１つのみだが、得意先実績修正での手入力など可能性はある為。）
                    if ( !_parentCustomerDic.ContainsKey( customerCode ) )
                    {
                        _parentCustomerDic.Add( customerCode, new List<DmdSummaryKey>() );
                    }
                    _parentCustomerDic[customerCode].Add( new DmdSummaryKey( addUpSecCode, claimCode ) );


                    // 【親→子】ディクショナリに追加
                    if ( !_childCustomerDic.ContainsKey( claimCode ) )
                    {
                        _childCustomerDic.Add( claimCode, new List<int>() );
                    }
                    _childCustomerDic[claimCode].Add( customerCode );
                }

            }
            catch ( Exception ex )
            {
                base.WriteErrorLog( ex, "SearchProc\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR );
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if ( myReader != null )
                {
                    if ( !myReader.IsClosed )
                        myReader.Close();
                }
            }

            return status;
        }

        # endregion

        # region [請求書売上明細データ抽出]
        /// <summary>
        /// Search 請求書明細（売上）
        /// </summary>
        /// <param name="extPrm">検索条件</param>
        /// <param name="retObj">検索結果Dic</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="_childCustomerDic">得意先Dic</param>
        /// <param name="_dmdRangeEachClaimDic">請求単位Dic</param>
        /// <param name="_sumCustChildDic">子集計Dic</param>
        /// <param name="requestMessage">請求書ログ出力用メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : Search 請求書明細（売上）</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private int SearchProcOfSales(EBooksFrePBillParaWork extPrm, out Dictionary<string, List<EBooksFrePBillDetailWork>> retObj, SqlConnection sqlConnection,
            Dictionary<int, List<int>> _childCustomerDic, Dictionary<string, DmdRangeEachClaim> _dmdRangeEachClaimDic, Dictionary<int, List<KeyValuePair<string, int>>> _sumCustChildDic, ref Dictionary<string, object> requestMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            Dictionary<string, List<EBooksFrePBillDetailWork>> frePBillDetailWorkList = new Dictionary<string, List<EBooksFrePBillDetailWork>>();
            retObj = null;

            foreach ( EBooksFrePBillParaWork.FrePBillParaKey frePBillParaKey in extPrm.FrePBillParaKeyList )
            {
                try
                {
                    //-------------------------------------------------------------------
                    // 対象テーブル
                    //   売上データ　　　　　　　　×SalesSlipRF→○SALESHISTORYRF // 売上履歴データに変更
                    //     拠点情報設定マスタ②　　SecInfoSetRF As SECDTL
                    //     部門マスタ①　　　　　　SubsectionRF As SUBSAL
                    //     売上明細データ　　　　　×SalesDetailRF→○SALESHISTDTLRF // 売上履歴明細データに変更
                    //       受注マスタ(車両)　　　AcceptOdrCarRF
                    //-------------------------------------------------------------------
                    SqlCommand sqlCommand = new SqlCommand( "SELECT " + this.GetSelectItemsForSales( extPrm )
                        + Environment.NewLine
                        + " FROM SALESHISTORYRF " + Environment.NewLine
                        + LeftJoin( "SALESHISTORYRF", "SECINFOSETRF", "SECDTL", new string[] { "SECTIONCODERF" }, new string[] { } )  // 企業cd,拠点cd
                        + LeftJoin( "SALESHISTORYRF", "SUBSECTIONRF", "SUBSAL", new string[] { "SUBSECTIONCODERF" }, new string[] { } )  // 企業cd,部門cd
                        + LeftJoin( "SALESHISTORYRF", "SALESHISTDTLRF", string.Empty, new string[] { "ACPTANODRSTATUSRF", "SALESSLIPNUMRF" }, new string[] { } )  // 企業cd,受注ステータス,伝票番号
                        + LeftJoin( "SALESHISTDTLRF", "ACCEPTODRCARRF", string.Empty, new string[] { "ACCEPTANORDERNORF" }, new string[] { "ACCEPTODRCARRF.DATAINPUTSYSTEMRF='10'", GetAcceptOdrCarJoinCndtn() } )
                        , sqlConnection );

                    // WHERE文を生成
                    sqlCommand.CommandText += MakeWhereStringForSales(ref sqlCommand, extPrm, frePBillParaKey, _childCustomerDic, _dmdRangeEachClaimDic, _sumCustChildDic);
                    sqlCommand.CommandText += " ORDER BY " + Environment.NewLine
                                              + " SALESHISTORYRF.ADDUPADATERF, SALESHISTORYRF.SALESSLIPNUMRF, SALESHISTDTLRF.SALESROWNORF " + Environment.NewLine;

                    // タイムアウト時間設定
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut( RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide );

                    //請求書ログ出力用
                    if (requestMessage.ContainsKey("売上明細取得クエリ") == false)
                    {
                        requestMessage.Add("売上明細取得クエリ", sqlCommand.CommandText);
                    }
                    myReader = sqlCommand.ExecuteReader();

                    while ( myReader.Read() )
                    {
                        EBooksFrePBillDetailWork frePBillDetailWork = new EBooksFrePBillDetailWork();

                        # region データのコピー
                        frePBillDetailWork.SALESSLIPRF_ACPTANODRSTATUSRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ACPTANODRSTATUSRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESSLIPNUMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SALESSLIPNUMRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SECTIONCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SECTIONCODERF" ) );
                        frePBillDetailWork.SALESSLIPRF_SUBSECTIONCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SUBSECTIONCODERF" ) );
                        frePBillDetailWork.SALESSLIPRF_DEBITNOTEDIVRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEBITNOTEDIVRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESSLIPCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESSLIPCDRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESGOODSCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESGOODSCDRF" ) );
                        frePBillDetailWork.SALESSLIPRF_ACCRECDIVCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ACCRECDIVCDRF" ) );
                        frePBillDetailWork.SALESSLIPRF_DEMANDADDUPSECCDRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEMANDADDUPSECCDRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESDATERF" ) );
                        frePBillDetailWork.SALESSLIPRF_ADDUPADATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ADDUPADATERF" ) );
                        frePBillDetailWork.SALESSLIPRF_INPUTAGENCDRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "INPUTAGENCDRF" ) );
                        frePBillDetailWork.SALESSLIPRF_INPUTAGENNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "INPUTAGENNMRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESINPUTCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SALESINPUTCODERF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESINPUTNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SALESINPUTNAMERF" ) );
                        frePBillDetailWork.SALESSLIPRF_FRONTEMPLOYEECDRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FRONTEMPLOYEECDRF" ) );
                        frePBillDetailWork.SALESSLIPRF_FRONTEMPLOYEENMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FRONTEMPLOYEENMRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESEMPLOYEECDRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SALESEMPLOYEECDRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESEMPLOYEENMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SALESEMPLOYEENMRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESTOTALTAXINCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESTOTALTAXINCRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESTOTALTAXEXCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESTOTALTAXEXCRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESPRTTOTALTAXINCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESPRTTOTALTAXINCRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESPRTTOTALTAXEXCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESPRTTOTALTAXEXCRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESWORKTOTALTAXINCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESWORKTOTALTAXINCRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESWORKTOTALTAXEXCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESWORKTOTALTAXEXCRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESSUBTOTALTAXINCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESSUBTOTALTAXINCRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESSUBTOTALTAXEXCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESSUBTOTALTAXEXCRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESPRTSUBTTLINCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESPRTSUBTTLINCRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESPRTSUBTTLEXCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESPRTSUBTTLEXCRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESWORKSUBTTLINCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESWORKSUBTTLINCRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESWORKSUBTTLEXCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESWORKSUBTTLEXCRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SALESSUBTOTALTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESSUBTOTALTAXRF" ) );
                        frePBillDetailWork.SALESSLIPRF_ITDEDPARTSDISOUTTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ITDEDPARTSDISOUTTAXRF" ) );
                        frePBillDetailWork.SALESSLIPRF_ITDEDPARTSDISINTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ITDEDPARTSDISINTAXRF" ) );
                        frePBillDetailWork.SALESSLIPRF_ITDEDWORKDISOUTTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ITDEDWORKDISOUTTAXRF" ) );
                        frePBillDetailWork.SALESSLIPRF_ITDEDWORKDISINTAXRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "ITDEDWORKDISINTAXRF" ) );
                        frePBillDetailWork.SALESSLIPRF_PARTSDISCOUNTRATERF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "PARTSDISCOUNTRATERF" ) );
                        frePBillDetailWork.SALESSLIPRF_RAVORDISCOUNTRATERF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "RAVORDISCOUNTRATERF" ) );
                        frePBillDetailWork.SALESSLIPRF_TOTALCOSTRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "TOTALCOSTRF" ) );
                        frePBillDetailWork.SALESSLIPRF_CONSTAXRATERF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "CONSTAXRATERF" ) );
                        frePBillDetailWork.SALESSLIPRF_AUTODEPOSITCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "AUTODEPOSITCDRF" ) );
                        frePBillDetailWork.SALESSLIPRF_AUTODEPOSITSLIPNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "AUTODEPOSITSLIPNORF" ) );
                        frePBillDetailWork.SALESSLIPRF_DEPOSITALLOWANCETTLRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPOSITALLOWANCETTLRF" ) );
                        frePBillDetailWork.SALESSLIPRF_DEPOSITALWCBLNCERF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPOSITALWCBLNCERF" ) );
                        frePBillDetailWork.SALESSLIPRF_CLAIMCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CLAIMCODERF" ) );
                        frePBillDetailWork.SALESSLIPRF_CUSTOMERCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CUSTOMERCODERF" ) );
                        frePBillDetailWork.SALESSLIPRF_ADDRESSEECODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ADDRESSEECODERF" ) );
                        frePBillDetailWork.SALESSLIPRF_ADDRESSEENAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESSEENAMERF" ) );
                        frePBillDetailWork.SALESSLIPRF_ADDRESSEENAME2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDRESSEENAME2RF" ) );
                        frePBillDetailWork.SALESSLIPRF_PARTYSALESLIPNUMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PARTYSALESLIPNUMRF" ) );
                        frePBillDetailWork.SALESSLIPRF_SLIPNOTERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SLIPNOTERF" ) );
                        frePBillDetailWork.SALESSLIPRF_SLIPNOTE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SLIPNOTE2RF" ) );
                        frePBillDetailWork.SALESSLIPRF_SLIPNOTE3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SLIPNOTE3RF" ) );
                        frePBillDetailWork.SALESSLIPRF_RETGOODSREASONDIVRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "RETGOODSREASONDIVRF" ) );
                        frePBillDetailWork.SALESSLIPRF_RETGOODSREASONRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "RETGOODSREASONRF" ) );
                        frePBillDetailWork.SALESSLIPRF_DETAILROWCOUNTRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DETAILROWCOUNTRF" ) );
                        frePBillDetailWork.SALESSLIPRF_UOEREMARK1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "UOEREMARK1RF" ) );
                        frePBillDetailWork.SALESSLIPRF_UOEREMARK2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "UOEREMARK2RF" ) );
                        frePBillDetailWork.SALESSLIPRF_DELIVEREDGOODSDIVRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DELIVEREDGOODSDIVRF" ) );
                        frePBillDetailWork.SALESSLIPRF_DELIVEREDGOODSDIVNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DELIVEREDGOODSDIVNMRF" ) );
                        frePBillDetailWork.SALESSLIPRF_STOCKGOODSTTLTAXEXCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "STOCKGOODSTTLTAXEXCRF" ) );
                        frePBillDetailWork.SALESSLIPRF_PUREGOODSTTLTAXEXCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "PUREGOODSTTLTAXEXCRF" ) );
                        frePBillDetailWork.SECDTL_SECTIONGUIDENMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SECDTLSECTIONGUIDENMRF" ) );
                        frePBillDetailWork.SECDTL_SECTIONGUIDESNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SECDTLSECTIONGUIDESNMRF" ) );
                        frePBillDetailWork.SECDTL_COMPANYNAMECD1RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SECDTLCOMPANYNAMECD1RF" ) );
                        frePBillDetailWork.SUBSAL_SUBSECTIONNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SUBSALSUBSECTIONNAMERF" ) );
                        frePBillDetailWork.SALESDETAILRF_ACCEPTANORDERNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ACCEPTANORDERNORF" ) );
                        frePBillDetailWork.SALESDETAILRF_SALESROWNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESROWNORF" ) );
                        frePBillDetailWork.SALESDETAILRF_GOODSKINDCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "GOODSKINDCODERF" ) );
                        frePBillDetailWork.SALESDETAILRF_GOODSMAKERCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "GOODSMAKERCDRF" ) );
                        frePBillDetailWork.SALESDETAILRF_MAKERNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MAKERNAMERF" ) );
                        frePBillDetailWork.SALESDETAILRF_GOODSNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSNORF" ) );
                        frePBillDetailWork.SALESDETAILRF_GOODSNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSNAMERF" ) );
                        frePBillDetailWork.SALESDETAILRF_GOODSLGROUPRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "GOODSLGROUPRF" ) );
                        frePBillDetailWork.SALESDETAILRF_GOODSLGROUPNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSLGROUPNAMERF" ) );
                        frePBillDetailWork.SALESDETAILRF_GOODSMGROUPRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "GOODSMGROUPRF" ) );
                        frePBillDetailWork.SALESDETAILRF_GOODSMGROUPNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSMGROUPNAMERF" ) );
                        frePBillDetailWork.SALESDETAILRF_BLGROUPCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "BLGROUPCODERF" ) );
                        frePBillDetailWork.SALESDETAILRF_BLGROUPNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "BLGROUPNAMERF" ) );
                        frePBillDetailWork.SALESDETAILRF_BLGOODSCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "BLGOODSCODERF" ) );
                        frePBillDetailWork.SALESDETAILRF_BLGOODSFULLNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "BLGOODSFULLNAMERF" ) );
                        frePBillDetailWork.SALESDETAILRF_ENTERPRISEGANRECODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ENTERPRISEGANRECODERF" ) );
                        frePBillDetailWork.SALESDETAILRF_ENTERPRISEGANRENAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ENTERPRISEGANRENAMERF" ) );
                        frePBillDetailWork.SALESDETAILRF_WAREHOUSECODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "WAREHOUSECODERF" ) );
                        frePBillDetailWork.SALESDETAILRF_WAREHOUSENAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "WAREHOUSENAMERF" ) );
                        frePBillDetailWork.SALESDETAILRF_WAREHOUSESHELFNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "WAREHOUSESHELFNORF" ) );
                        frePBillDetailWork.SALESDETAILRF_SALESORDERDIVCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESORDERDIVCDRF" ) );
                        frePBillDetailWork.SALESDETAILRF_OPENPRICEDIVRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "OPENPRICEDIVRF" ) );
                        frePBillDetailWork.SALESDETAILRF_GOODSRATERANKRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSRATERANKRF" ) );
                        frePBillDetailWork.SALESDETAILRF_LISTPRICERATERF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "LISTPRICERATERF" ) );
                        frePBillDetailWork.SALESDETAILRF_LISTPRICETAXINCFLRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "LISTPRICETAXINCFLRF" ) );
                        frePBillDetailWork.SALESDETAILRF_LISTPRICETAXEXCFLRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "LISTPRICETAXEXCFLRF" ) );
                        frePBillDetailWork.SALESDETAILRF_SALESRATERF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "SALESRATERF" ) );
                        frePBillDetailWork.SALESDETAILRF_SALESUNPRCTAXINCFLRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "SALESUNPRCTAXINCFLRF" ) );
                        frePBillDetailWork.SALESDETAILRF_SALESUNPRCTAXEXCFLRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "SALESUNPRCTAXEXCFLRF" ) );
                        frePBillDetailWork.SALESDETAILRF_COSTRATERF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "COSTRATERF" ) );
                        frePBillDetailWork.SALESDETAILRF_SALESUNITCOSTRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "SALESUNITCOSTRF" ) );
                        frePBillDetailWork.SALESDETAILRF_PRTBLGOODSCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "PRTBLGOODSCODERF" ) );
                        frePBillDetailWork.SALESDETAILRF_PRTBLGOODSNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PRTBLGOODSNAMERF" ) );
                        frePBillDetailWork.SALESDETAILRF_WORKMANHOURRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "WORKMANHOURRF" ) );
                        frePBillDetailWork.SALESDETAILRF_SHIPMENTCNTRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "SHIPMENTCNTRF" ) );
                        frePBillDetailWork.SALESDETAILRF_SALESMONEYTAXINCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESMONEYTAXINCRF" ) );
                        frePBillDetailWork.SALESDETAILRF_SALESMONEYTAXEXCRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "SALESMONEYTAXEXCRF" ) );
                        frePBillDetailWork.SALESDETAILRF_COSTRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "COSTRF" ) );
                        frePBillDetailWork.SALESDETAILRF_TAXATIONDIVCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "TAXATIONDIVCDRF" ) );
                        frePBillDetailWork.SALESDETAILRF_PARTYSLIPNUMDTLRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PARTYSLIPNUMDTLRF" ) );
                        frePBillDetailWork.SALESDETAILRF_DTLNOTERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DTLNOTERF" ) );
                        frePBillDetailWork.SALESDETAILRF_SUPPLIERCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SUPPLIERCDRF" ) );
                        frePBillDetailWork.SALESDETAILRF_SUPPLIERSNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SUPPLIERSNMRF" ) );
                        frePBillDetailWork.SALESDETAILRF_SLIPMEMO1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SLIPMEMO1RF" ) );
                        frePBillDetailWork.SALESDETAILRF_SLIPMEMO2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SLIPMEMO2RF" ) );
                        frePBillDetailWork.SALESDETAILRF_SLIPMEMO3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SLIPMEMO3RF" ) );
                        frePBillDetailWork.SALESDETAILRF_INSIDEMEMO1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "INSIDEMEMO1RF" ) );
                        frePBillDetailWork.SALESDETAILRF_INSIDEMEMO2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "INSIDEMEMO2RF" ) );
                        frePBillDetailWork.SALESDETAILRF_INSIDEMEMO3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "INSIDEMEMO3RF" ) );
                        frePBillDetailWork.SALESDETAILRF_BFLISTPRICERF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "BFLISTPRICERF" ) );
                        frePBillDetailWork.SALESDETAILRF_BFSALESUNITPRICERF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "BFSALESUNITPRICERF" ) );
                        frePBillDetailWork.SALESDETAILRF_BFUNITCOSTRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "BFUNITCOSTRF" ) );
                        frePBillDetailWork.SALESDETAILRF_CMPLTSALESROWNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CMPLTSALESROWNORF" ) );
                        frePBillDetailWork.SALESDETAILRF_CMPLTGOODSMAKERCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CMPLTGOODSMAKERCDRF" ) );
                        frePBillDetailWork.SALESDETAILRF_CMPLTMAKERNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMPLTMAKERNAMERF" ) );
                        frePBillDetailWork.SALESDETAILRF_CMPLTGOODSNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMPLTGOODSNAMERF" ) );
                        frePBillDetailWork.SALESDETAILRF_CMPLTSHIPMENTCNTRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "CMPLTSHIPMENTCNTRF" ) );
                        frePBillDetailWork.SALESDETAILRF_CMPLTSALESUNPRCFLRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "CMPLTSALESUNPRCFLRF" ) );
                        frePBillDetailWork.SALESDETAILRF_CMPLTSALESMONEYRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "CMPLTSALESMONEYRF" ) );
                        frePBillDetailWork.SALESDETAILRF_CMPLTSALESUNITCOSTRF = SqlDataMediator.SqlGetDouble( myReader, myReader.GetOrdinal( "CMPLTSALESUNITCOSTRF" ) );
                        frePBillDetailWork.SALESDETAILRF_CMPLTCOSTRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "CMPLTCOSTRF" ) );
                        frePBillDetailWork.SALESDETAILRF_CMPLTPARTYSALSLNUMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMPLTPARTYSALSLNUMRF" ) );
                        frePBillDetailWork.SALESDETAILRF_CMPLTNOTERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CMPLTNOTERF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_CARMNGNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CARMNGNORF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_CARMNGCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CARMNGCODERF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_NUMBERPLATE1CODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "NUMBERPLATE1CODERF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_NUMBERPLATE1NAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "NUMBERPLATE1NAMERF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_NUMBERPLATE2RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "NUMBERPLATE2RF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_NUMBERPLATE3RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "NUMBERPLATE3RF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_NUMBERPLATE4RF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "NUMBERPLATE4RF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_FIRSTENTRYDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "FIRSTENTRYDATERF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_MAKERCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MAKERCODERF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_MAKERFULLNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MAKERFULLNAMERF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_MODELCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MODELCODERF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_MODELSUBCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MODELSUBCODERF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_MODELFULLNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MODELFULLNAMERF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_EXHAUSTGASSIGNRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "EXHAUSTGASSIGNRF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_SERIESMODELRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SERIESMODELRF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_CATEGORYSIGNMODELRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "CATEGORYSIGNMODELRF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_FULLMODELRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FULLMODELRF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_MODELDESIGNATIONNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MODELDESIGNATIONNORF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_CATEGORYNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CATEGORYNORF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_FRAMEMODELRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FRAMEMODELRF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_FRAMENORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "FRAMENORF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_SEARCHFRAMENORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SEARCHFRAMENORF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_ENGINEMODELNMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ENGINEMODELNMRF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_RELEVANCEMODELRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "RELEVANCEMODELRF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_SUBCARNMCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SUBCARNMCDRF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_MODELGRADESNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MODELGRADESNAMERF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_COLORCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COLORCODERF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_COLORNAME1RF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "COLORNAME1RF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_TRIMCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "TRIMCODERF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_TRIMNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "TRIMNAMERF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_MILEAGERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "MILEAGERF" ) );
                        frePBillDetailWork.SALESDETAILRF_SALESSLIPCDDTLRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SALESSLIPCDDTLRF" ) );
                        frePBillDetailWork.SALESSLIPRF_RESULTSADDUPSECCDRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "RESULTSADDUPSECCDRF" ) );
                        frePBillDetailWork.SALESDETAILRF_GOODSNAMEKANARF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "GOODSNAMEKANARF" ) );
                        frePBillDetailWork.SALESDETAILRF_MAKERKANANAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MAKERKANANAMERF" ) );
                        frePBillDetailWork.ACCEPTODRCARRF_MODELHALFNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "MODELHALFNAMERF" ) );
                        frePBillDetailWork.SALESDETAILRF_PRTGOODSNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PRTGOODSNORF" ) );
                        frePBillDetailWork.SALESDETAILRF_PRTMAKERCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "PRTMAKERCODERF" ) );
                        frePBillDetailWork.SALESDETAILRF_PRTMAKERNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "PRTMAKERNAMERF" ) );
                        frePBillDetailWork.SALESSLIPRF_CONSTAXLAYMETHODRF = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
                        # endregion

                        # region [ディクショナリへの追加]
                        int totalDay = frePBillParaKey.GetAddUpDateLongDate();

                        # region [計上日差し替え]
                        // 締範囲キー生成
                        DmdRangeEachClaimKey claimkey = new DmdRangeEachClaimKey(
                                                            frePBillParaKey.AddUpSecCode.Trim(),
                                                            frePBillParaKey.ClaimCode,
                                                            frePBillParaKey.ResultsSectCd.Trim(),
                                                            frePBillParaKey.CustomerCode);

                        // 締範囲キーがあれば計上日を差し替える(請求日で書きかえる)
                        string claimKeyString = claimkey.CreateKey();
                        if ( _dmdRangeEachClaimDic.ContainsKey( claimKeyString ) )
                        {
                            totalDay = _dmdRangeEachClaimDic[claimKeyString].DmdRangeEd;
                        }
                        # endregion

                        // 親/子レコード用のKEY
                        EBooksFrePBillParaWork.FrePBillParaKey key = new EBooksFrePBillParaWork.FrePBillParaKey(
                                                                    frePBillParaKey.AddUpSecCode.Trim(),
                                                                    frePBillParaKey.ClaimCode,
                                                                    frePBillParaKey.ResultsSectCd.Trim(),
                                                                    frePBillParaKey.CustomerCode,
                                                                    totalDay );

                        string keyString = key.CreateKey();
                        if ( !frePBillDetailWorkList.ContainsKey( keyString ) )
                        {
                            frePBillDetailWorkList.Add( keyString, new List<EBooksFrePBillDetailWork>() );
                        }
                        frePBillDetailWorkList[keyString].Add( frePBillDetailWork );
                        # endregion
                    }

                    if ( frePBillDetailWorkList.Count > 0 ) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    retObj = frePBillDetailWorkList;
                }
                catch ( Exception ex )
                {
                    base.WriteErrorLog( ex, "SearchProc\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR );
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
                finally
                {
                    if ( myReader != null )
                    {
                        if ( !myReader.IsClosed )
                            myReader.Close();
                    }
                }
            }

            return status;
        }
        /// <summary>
        /// 受注マスタ（車輌）のjoin条件
        /// </summary>
        /// <returns>WHERE文</returns>
        /// <remarks>
        /// <br>Note        : 受注マスタ（車輌）のjoin条件</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private string GetAcceptOdrCarJoinCndtn()
        {
            // "SALESHISTDTLRF"  : 10:見積,20:受注,30:売上,40:出荷,70:指示書,80:クレーム,99:一時保管  
            // "ACCEPTODRCARRF" : 1:見積 2:発注 3:受注 4:入荷 5:出荷 6:仕入 7:売上 8:返品 9:入金 10:支払
            StringBuilder text = new StringBuilder();

            // 売上
            text.Append( " SALESHISTDTLRF.ACPTANODRSTATUSRF='30' AND ACCEPTODRCARRF.ACPTANODRSTATUSRF='7'" );

            return text.ToString();
        }

        /// <summary>
        /// SELECT項目 取得処理（売上明細）
        /// </summary>
        /// <param name="extPrm">検索条件</param>
        /// <returns>取得項目文字列</returns>
        /// <remarks>
        /// <br>Note        : SELECT項目 取得処理（売上明細）</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private string GetSelectItemsForSales( EBooksFrePBillParaWork extPrm )
        {
            //---------------------------------------------------------------------------------
            // 注意：同じテーブルを複数回JOINする場合は、Selectに与える項目名称もAsで別名にする。
            //       最後の項目は後ろにカンマ(,)を付けない。
            //---------------------------------------------------------------------------------
            StringBuilder sb = new StringBuilder();

            # region [項目名]
            sb.Append( "SALESHISTORYRF.ACPTANODRSTATUSRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESSLIPNUMRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SECTIONCODERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SUBSECTIONCODERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.DEBITNOTEDIVRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESSLIPCDRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESGOODSCDRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.ACCRECDIVCDRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.DEMANDADDUPSECCDRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESDATERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.ADDUPADATERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.INPUTAGENCDRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.INPUTAGENNMRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESINPUTCODERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESINPUTNAMERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.FRONTEMPLOYEECDRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.FRONTEMPLOYEENMRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESEMPLOYEECDRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESEMPLOYEENMRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESTOTALTAXINCRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESTOTALTAXEXCRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESPRTTOTALTAXINCRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESPRTTOTALTAXEXCRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESWORKTOTALTAXINCRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESWORKTOTALTAXEXCRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESSUBTOTALTAXINCRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESSUBTOTALTAXEXCRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESPRTSUBTTLINCRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESPRTSUBTTLEXCRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESWORKSUBTTLINCRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESWORKSUBTTLEXCRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SALESSUBTOTALTAXRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.ITDEDPARTSDISOUTTAXRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.ITDEDPARTSDISINTAXRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.ITDEDWORKDISOUTTAXRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.ITDEDWORKDISINTAXRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.PARTSDISCOUNTRATERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.RAVORDISCOUNTRATERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.TOTALCOSTRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.CONSTAXRATERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.AUTODEPOSITCDRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.AUTODEPOSITSLIPNORF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.DEPOSITALLOWANCETTLRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.DEPOSITALWCBLNCERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.CLAIMCODERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.CUSTOMERCODERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.CUSTOMERNAMERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.CUSTOMERNAME2RF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.CUSTOMERSNMRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.HONORIFICTITLERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.ADDRESSEECODERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.ADDRESSEENAMERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.ADDRESSEENAME2RF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.PARTYSALESLIPNUMRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SLIPNOTERF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SLIPNOTE2RF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.SLIPNOTE3RF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.RETGOODSREASONDIVRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.RETGOODSREASONRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.DETAILROWCOUNTRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.UOEREMARK1RF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.UOEREMARK2RF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.DELIVEREDGOODSDIVRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.DELIVEREDGOODSDIVNMRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.STOCKGOODSTTLTAXEXCRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.PUREGOODSTTLTAXEXCRF, " + Environment.NewLine );
            sb.Append( "SECDTL.SECTIONGUIDENMRF AS SECDTLSECTIONGUIDENMRF, " + Environment.NewLine );
            sb.Append( "SECDTL.SECTIONGUIDESNMRF AS SECDTLSECTIONGUIDESNMRF, " + Environment.NewLine );
            sb.Append( "SECDTL.COMPANYNAMECD1RF AS SECDTLCOMPANYNAMECD1RF, " + Environment.NewLine );
            sb.Append( "SUBSAL.SUBSECTIONNAMERF AS SUBSALSUBSECTIONNAMERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.ACCEPTANORDERNORF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.SALESROWNORF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.GOODSKINDCODERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.GOODSMAKERCDRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.MAKERNAMERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.GOODSNORF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.GOODSNAMERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.GOODSLGROUPRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.GOODSLGROUPNAMERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.GOODSMGROUPRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.GOODSMGROUPNAMERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.BLGROUPCODERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.BLGROUPNAMERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.BLGOODSCODERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.BLGOODSFULLNAMERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.ENTERPRISEGANRECODERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.ENTERPRISEGANRENAMERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.WAREHOUSECODERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.WAREHOUSENAMERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.WAREHOUSESHELFNORF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.SALESORDERDIVCDRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.OPENPRICEDIVRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.GOODSRATERANKRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.LISTPRICERATERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.LISTPRICETAXINCFLRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.LISTPRICETAXEXCFLRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.SALESRATERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.SALESUNPRCTAXINCFLRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.SALESUNPRCTAXEXCFLRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.COSTRATERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.SALESUNITCOSTRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.PRTBLGOODSCODERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.PRTBLGOODSNAMERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.WORKMANHOURRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.SHIPMENTCNTRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.SALESMONEYTAXINCRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.SALESMONEYTAXEXCRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.COSTRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.TAXATIONDIVCDRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.PARTYSLIPNUMDTLRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.DTLNOTERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.SUPPLIERCDRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.SUPPLIERSNMRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.SLIPMEMO1RF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.SLIPMEMO2RF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.SLIPMEMO3RF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.INSIDEMEMO1RF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.INSIDEMEMO2RF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.INSIDEMEMO3RF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.BFLISTPRICERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.BFSALESUNITPRICERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.BFUNITCOSTRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.CMPLTSALESROWNORF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.CMPLTGOODSMAKERCDRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.CMPLTMAKERNAMERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.CMPLTGOODSNAMERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.CMPLTSHIPMENTCNTRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.CMPLTSALESUNPRCFLRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.CMPLTSALESMONEYRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.CMPLTSALESUNITCOSTRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.CMPLTCOSTRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.CMPLTPARTYSALSLNUMRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.CMPLTNOTERF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.CARMNGNORF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.CARMNGCODERF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.NUMBERPLATE1CODERF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.NUMBERPLATE1NAMERF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.NUMBERPLATE2RF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.NUMBERPLATE3RF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.NUMBERPLATE4RF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.FIRSTENTRYDATERF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.MAKERCODERF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.MAKERFULLNAMERF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.MODELCODERF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.MODELSUBCODERF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.MODELFULLNAMERF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.EXHAUSTGASSIGNRF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.SERIESMODELRF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.CATEGORYSIGNMODELRF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.FULLMODELRF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.MODELDESIGNATIONNORF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.CATEGORYNORF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.FRAMEMODELRF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.FRAMENORF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.SEARCHFRAMENORF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.ENGINEMODELNMRF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.RELEVANCEMODELRF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.SUBCARNMCDRF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.MODELGRADESNAMERF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.COLORCODERF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.COLORNAME1RF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.TRIMCODERF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.TRIMNAMERF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.MILEAGERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.SALESSLIPCDDTLRF, " + Environment.NewLine );
            sb.Append( "SALESHISTORYRF.RESULTSADDUPSECCDRF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.GOODSNAMEKANARF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.MAKERKANANAMERF, " + Environment.NewLine );
            sb.Append( "ACCEPTODRCARRF.MODELHALFNAMERF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.PRTGOODSNORF, " + Environment.NewLine );
            sb.Append( "SALESHISTDTLRF.PRTMAKERCODERF, " + Environment.NewLine );
            sb.Append("SALESHISTORYRF.CONSTAXLAYMETHODRF, " + Environment.NewLine);
            sb.Append( "SALESHISTDTLRF.PRTMAKERNAMERF " + Environment.NewLine );// ←最後の項目はカンマなし
            # endregion

            return sb.ToString();
        }

        /// <summary>
        /// WHERE文作成処理（売上明細）
        /// </summary>
        /// <param name="sqlCommand">SQLコマンド</param>
        /// <param name="extPrm">自由帳票共通抽出条件クラス</param>
        /// <param name="paraKey">パラメータキー</param>
        /// <param name="_childCustomerDic">得意先Dic</param>
        /// <param name="_dmdRangeEachClaimDic">請求単位Dic</param>
        /// <param name="_sumCustChildDic">子集計Dic</param>
        /// <returns>WHERE文</returns>
        /// <remarks>
        /// <br>Note        : WHERE文作成処理（売上明細）</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private string MakeWhereStringForSales(ref SqlCommand sqlCommand, EBooksFrePBillParaWork extPrm, EBooksFrePBillParaWork.FrePBillParaKey paraKey, Dictionary<int, List<int>> _childCustomerDic, Dictionary<string, DmdRangeEachClaim> _dmdRangeEachClaimDic, Dictionary<int, List<KeyValuePair<string, int>>> _sumCustChildDic) 
        {
            StringBuilder whereString = new StringBuilder();

            // 企業コードは必須条件
            whereString.Append( " WHERE SALESHISTORYRF.ENTERPRISECODERF=@FINDENTERPRISECODE " );
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
            findParaEnterpriseCode.Value = extPrm.EnterpriseCode;

            // 受注ステータス 30=売上 のみ
            whereString.Append( " AND SALESHISTORYRF.ACPTANODRSTATUSRF='30' " );

            whereString.Append( " AND " );

                //--------------------------------------------------------
                // 請求書
                //--------------------------------------------------------
                // 得意先コード
                if ( paraKey.CustomerCode != 0 )
                {
                    // 集計レコード以外はそのまま指定(１コードのみ)
                    whereString.Append( string.Format( "SALESHISTORYRF.CUSTOMERCODERF=@FINDCUSTOMERCODE{0} ", 0 ) );
                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add( string.Format( "@FINDCUSTOMERCODE{0}", 0 ), SqlDbType.Int );
                    paraCustomerCode.Value = paraKey.CustomerCode;

                    // 計上拠点コード
                    whereString.Append(string.Format("AND SALESHISTORYRF.DEMANDADDUPSECCDRF =@FINDDEMANDADDUPSECCD{0} ", 0));
                    SqlParameter paraDemandAddUpSecCd = sqlCommand.Parameters.Add(string.Format("@FINDDEMANDADDUPSECCD{0}", 0), SqlDbType.NChar);
                    paraDemandAddUpSecCd.Value = paraKey.AddUpSecCode;

                    // 実績拠点コード
                    whereString.Append(string.Format("AND SALESHISTORYRF.RESULTSADDUPSECCDRF =@FINDRESULTSADDUPSECCD{0} ", 0));
                    SqlParameter paraResultSecCode = sqlCommand.Parameters.Add(string.Format("@FINDRESULTSADDUPSECCD{0}", 0), SqlDbType.NChar);
                    paraResultSecCode.Value = paraKey.ResultsSectCd;
                }
                else
                {
                    // 集計レコードの場合は属する得意先コードを全て指定(複数コード)
                    if ( _childCustomerDic.ContainsKey( paraKey.ClaimCode ) )
                    {
                        whereString.Append( " ( " );
                        int index = 0;

                        foreach ( int customerCode in _childCustomerDic[paraKey.ClaimCode] )
                        {
                            if ( index > 0 )
                            {
                                whereString.Append( " OR " );
                            }
                            whereString.Append( string.Format( "SALESHISTORYRF.CUSTOMERCODERF=@FINDCUSTOMERCODE{0} ", index ) );
                            SqlParameter paraCustomerCode = sqlCommand.Parameters.Add( string.Format( "@FINDCUSTOMERCODE{0}", index ), SqlDbType.Int );
                            paraCustomerCode.Value = customerCode;
                            index++;
                        }

                        whereString.Append( " ) " );
                    }
                    else
                    {
                        // 集計レコード以外はそのまま指定(１コードのみ)
                        whereString.Append( string.Format( "SALESHISTORYRF.CUSTOMERCODERF=@FINDCUSTOMERCODE{0} ", 0 ) );
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add( string.Format( "@FINDCUSTOMERCODE{0}", 0 ), SqlDbType.Int );
                        paraCustomerCode.Value = paraKey.ClaimCode;
                    }
                }

            // 計上年月日
            // 伝票発行時と集計時で異なる可能性があるのでWHERE句にはAddUpSecCode,ClaimCodeを含めないが、
            // 抽出範囲の取得ではKEYとして指定する。
            DmdRangeEachClaimKey key = new DmdRangeEachClaimKey(
                                                paraKey.AddUpSecCode.Trim(),
                                                paraKey.ClaimCode,
                                                paraKey.ResultsSectCd.Trim(),
                                                paraKey.CustomerCode );

            DmdRangeEachClaim dmdRangeEachClaim;
            string keyString = key.CreateKey();
            if ( _dmdRangeEachClaimDic.ContainsKey( keyString ) )
            {
                dmdRangeEachClaim = _dmdRangeEachClaimDic[keyString];
            }
            else
            {
                dmdRangeEachClaim = new DmdRangeEachClaim( 0, paraKey.GetAddUpDateLongDate() );
            }

            whereString.Append( string.Format( " AND SALESHISTORYRF.ADDUPADATERF>=@FINDADDUPADATEST{0} AND SALESHISTORYRF.ADDUPADATERF<=@FINDADDUPADATEED{0}", 0 ) );
            SqlParameter paraAddUpDateSt = sqlCommand.Parameters.Add( string.Format( "@FINDADDUPADATEST{0}", 0 ), SqlDbType.Int );
            paraAddUpDateSt.Value = dmdRangeEachClaim.DmdRangeSt;
            SqlParameter paraAddUpDateEd = sqlCommand.Parameters.Add( string.Format( "@FINDADDUPADATEED{0}", 0 ), SqlDbType.Int );
            paraAddUpDateEd.Value = dmdRangeEachClaim.DmdRangeEd;

            // 売掛区分 AccRecDivCdRF（0:売掛なし,1:売掛）→1:売掛のみを対象とする
            // 論理削除分は除外
            whereString.Append( " AND SALESHISTORYRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE " + Environment.NewLine );
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add( "@FINDLOGICALDELETECODE", SqlDbType.Int );
            paraLogicalDeleteCode.Value = 0;

            // 赤伝と元黒は除外(0:黒のみ)
            whereString.Append( " AND SALESHISTORYRF.DEBITNOTEDIVRF=@FINDDEBITNOTEDIV " + Environment.NewLine );
            SqlParameter paraDebitNoteDiv = sqlCommand.Parameters.Add( "@FINDDEBITNOTEDIV", SqlDbType.Int );
            paraDebitNoteDiv.Value = 0;

            return whereString.ToString();
        }

        # endregion

        # region [請求書入金明細データ抽出]
        /// <summary>
        /// Search 請求書明細（入金）
        /// </summary>
        /// <param name="extPrm">検索条件</param>
        /// <param name="retObj">検索結果Dic</param>
        /// <param name="sqlConnection">コネクション</param>
        /// <param name="_childCustomerDic">得意先Dic</param>
        /// <param name="_dmdRangeEachClaimDic">請求単位Dic</param>
        /// <param name="_sumCustChildDic">子集計Dic</param>
        /// <param name="requestMessage">請求書ログ出力用メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : Search 請求書明細（入金）</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private int SearchProcOfDeposit(EBooksFrePBillParaWork extPrm, out Dictionary<string, List<EBooksFrePBillDetailWork>> retObj, SqlConnection sqlConnection
            , Dictionary<int, List<int>> _childCustomerDic, Dictionary<string, DmdRangeEachClaim> _dmdRangeEachClaimDic, Dictionary<int, List<KeyValuePair<string, int>>> _sumCustChildDic, ref Dictionary<string, object> requestMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            Dictionary<string, List<EBooksFrePBillDetailWork>> frePBillDetailWorkList = new Dictionary<string, List<EBooksFrePBillDetailWork>>();
            retObj = null;

            foreach ( EBooksFrePBillParaWork.FrePBillParaKey frePBillParaKey in extPrm.FrePBillParaKeyList )
            {
                if (frePBillParaKey.CustomerCode != 0 && (frePBillParaKey.AddUpSecCode != frePBillParaKey.ResultsSectCd || frePBillParaKey.ClaimCode != frePBillParaKey.CustomerCode))
                {
                    continue;
                }
                try
                {
                    //-------------------------------------------------------------------
                    // 対象テーブル
                    //   入金マスタ　　　　DepsitMainRF
                    //     部門マスタ②　　SubsectionRF As SUBDEP
                    //     入金明細データ　DepositDtlRF
                    //-------------------------------------------------------------------
                    SqlCommand sqlCommand = new SqlCommand( "SELECT " + this.GetSelectItemsForDeposit( extPrm )
                        + Environment.NewLine
                        + " FROM DEPSITMAINRF " + Environment.NewLine
                        + LeftJoin( "DEPSITMAINRF", "SUBSECTIONRF", "SUBDEP", new string[] { "SUBSECTIONCODERF" }, new string[] { } )  // 企業cd,部門cd
                        + LeftJoin( "DEPSITMAINRF", "DEPSITDTLRF", string.Empty, new string[] { "ACPTANODRSTATUSRF", "DEPOSITSLIPNORF" }, new string[] { } )  // 企業cd,受注ステータス,入金伝票番号
                        , sqlConnection );

                    // WHERE文を生成
                    sqlCommand.CommandText += MakeWhereStringForDeposit(ref sqlCommand, extPrm, frePBillParaKey, _childCustomerDic, _dmdRangeEachClaimDic, _sumCustChildDic);
                    // タイムアウト時間設定
                    sqlCommand.CommandTimeout = RemotingSettingInfo.GetCommandTimeOut( RemotingConstantManagement.TimeOutType.RefernceType.SelectLimitGuide );
                    //請求書ログ出力用
                    if (requestMessage.ContainsKey("入金明細取得クエリ") == false)
                    {
                        requestMessage.Add("入金明細取得クエリ", sqlCommand.CommandText);
                    }
                    myReader = sqlCommand.ExecuteReader();

                    while ( myReader.Read() )
                    {
                        EBooksFrePBillDetailWork frePBillDetailWork = new EBooksFrePBillDetailWork();

                        # region データのコピー
                        frePBillDetailWork.DEPSITMAINRF_ACPTANODRSTATUSRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ACPTANODRSTATUSRF" ) );
                        frePBillDetailWork.DEPSITMAINRF_DEPOSITSLIPNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITSLIPNORF" ) );
                        frePBillDetailWork.DEPSITMAINRF_SALESSLIPNUMRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SALESSLIPNUMRF" ) );
                        frePBillDetailWork.DEPSITMAINRF_ADDUPSECCODERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "ADDUPSECCODERF" ) );
                        frePBillDetailWork.DEPSITMAINRF_SUBSECTIONCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "SUBSECTIONCODERF" ) );
                        frePBillDetailWork.DEPSITMAINRF_DEPOSITDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPOSITDATERF" ) );
                        frePBillDetailWork.DEPSITMAINRF_ADDUPADATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "ADDUPADATERF" ) );
                        frePBillDetailWork.DEPSITMAINRF_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPOSITRF" ) );
                        frePBillDetailWork.DEPSITMAINRF_FEEDEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "FEEDEPOSITRF" ) );
                        frePBillDetailWork.DEPSITMAINRF_DISCOUNTDEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DISCOUNTDEPOSITRF" ) );
                        frePBillDetailWork.DEPSITMAINRF_AUTODEPOSITCDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "AUTODEPOSITCDRF" ) );
                        frePBillDetailWork.DEPSITMAINRF_DRAFTDRAWINGDATERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DRAFTDRAWINGDATERF" ) );
                        frePBillDetailWork.DEPSITMAINRF_DRAFTKINDRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DRAFTKINDRF" ) );
                        frePBillDetailWork.DEPSITMAINRF_DRAFTKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DRAFTKINDNAMERF" ) );
                        frePBillDetailWork.DEPSITMAINRF_DRAFTDIVIDENAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DRAFTDIVIDENAMERF" ) );
                        frePBillDetailWork.DEPSITMAINRF_DRAFTNORF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DRAFTNORF" ) );
                        frePBillDetailWork.DEPSITMAINRF_CUSTOMERCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CUSTOMERCODERF" ) );
                        frePBillDetailWork.DEPSITMAINRF_CLAIMCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "CLAIMCODERF" ) );
                        frePBillDetailWork.DEPSITMAINRF_OUTLINERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "OUTLINERF" ) );
                        frePBillDetailWork.SUBDEP_SUBSECTIONNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "SUBDEPSUBSECTIONNAMERF" ) );
                        frePBillDetailWork.DEPSITDTLRF_DEPOSITSLIPNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPSITDTLRFDEPOSITSLIPNORF" ) );
                        frePBillDetailWork.DEPSITDTLRF_DEPOSITROWNORF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPSITDTLRFDEPOSITROWNORF" ) );
                        frePBillDetailWork.DEPSITDTLRF_MONEYKINDCODERF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPSITDTLRFMONEYKINDCODERF" ) );
                        frePBillDetailWork.DEPSITDTLRF_MONEYKINDNAMERF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "DEPSITDTLRFMONEYKINDNAMERF" ) );
                        frePBillDetailWork.DEPSITDTLRF_MONEYKINDDIVRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPSITDTLRFMONEYKINDDIVRF" ) );
                        frePBillDetailWork.DEPSITDTLRF_DEPOSITRF = SqlDataMediator.SqlGetInt64( myReader, myReader.GetOrdinal( "DEPSITDTLRFDEPOSITRF" ) );
                        frePBillDetailWork.DEPSITDTLRF_VALIDITYTERMRF = SqlDataMediator.SqlGetInt32( myReader, myReader.GetOrdinal( "DEPSITDTLRFVALIDITYTERMRF" ) );
                        frePBillDetailWork.DEPSITMAINRF_INPUTDEPOSITSECCDRF = SqlDataMediator.SqlGetString( myReader, myReader.GetOrdinal( "INPUTDEPOSITSECCDRF" ) );
                        # endregion

                        # region [ディクショナリへの追加]
                        int totalDay = frePBillParaKey.GetAddUpDateLongDate();

                        # region [計上日差し替え]
                        // 締範囲キー生成
                        DmdRangeEachClaimKey claimkey = new DmdRangeEachClaimKey(
                                                            frePBillParaKey.AddUpSecCode.Trim(),
                                                            frePBillParaKey.ClaimCode,
                                                            frePBillParaKey.ResultsSectCd.Trim(),
                                                            frePBillParaKey.CustomerCode);

                        // 締範囲キーがあれば計上日を差し替える(請求日で書きかえる)
                        string claimKeyString = claimkey.CreateKey();
                        if ( _dmdRangeEachClaimDic.ContainsKey( claimKeyString ) )
                        {
                            totalDay = _dmdRangeEachClaimDic[claimKeyString].DmdRangeEd;
                        }
                        # endregion

                        // 親/子レコード用のKEY
                        EBooksFrePBillParaWork.FrePBillParaKey key = new EBooksFrePBillParaWork.FrePBillParaKey(
                                                                        frePBillParaKey.AddUpSecCode.Trim(),
                                                                        frePBillParaKey.ClaimCode,
                                                                        frePBillParaKey.ResultsSectCd.Trim(),
                                                                        frePBillParaKey.CustomerCode,
                                                                        totalDay );
                        // ディクショナリに追加
                        string keyString = key.CreateKey();
                        if ( !frePBillDetailWorkList.ContainsKey( keyString ) )
                        {
                            frePBillDetailWorkList.Add(keyString, new List<EBooksFrePBillDetailWork>());
                        }
                        frePBillDetailWorkList[keyString].Add(frePBillDetailWork);
                        # endregion
                    }

                    if ( frePBillDetailWorkList.Count > 0 ) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    retObj = frePBillDetailWorkList;
                }
                catch ( Exception ex )
                {
                    base.WriteErrorLog( ex, "SearchProc\n" + ex.Message, (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
                finally
                {
                    if ( myReader != null )
                    {
                        if ( !myReader.IsClosed )
                            myReader.Close();
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// SELECT項目 取得処理（入金明細）
        /// </summary>
        /// <param name="extPrm">検索条件</param>
        /// <returns>取得項目文字列</returns>
        /// <remarks>
        /// <br>Note        : SELECT項目 取得処理（入金明細）</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private string GetSelectItemsForDeposit( EBooksFrePBillParaWork extPrm )
        {
            //---------------------------------------------------------------------------------
            // 注意：同じテーブルを複数回JOINする場合は、Selectに与える項目名称もAsで別名にする。
            //       最後の項目は後ろにカンマ(,)を付けない。
            //---------------------------------------------------------------------------------
            StringBuilder sb = new StringBuilder();

            # region [項目名]
            sb.Append( "DEPSITMAINRF.ACPTANODRSTATUSRF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.DEPOSITSLIPNORF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.SALESSLIPNUMRF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.ADDUPSECCODERF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.SUBSECTIONCODERF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.DEPOSITDATERF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.ADDUPADATERF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.DEPOSITRF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.FEEDEPOSITRF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.DISCOUNTDEPOSITRF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.AUTODEPOSITCDRF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.DRAFTDRAWINGDATERF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.DRAFTKINDRF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.DRAFTKINDNAMERF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.DRAFTDIVIDENAMERF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.DRAFTNORF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.CUSTOMERCODERF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.CLAIMCODERF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.OUTLINERF, " + Environment.NewLine );
            sb.Append( "SUBDEP.SUBSECTIONNAMERF AS SUBDEPSUBSECTIONNAMERF, " + Environment.NewLine );
            sb.Append( "DEPSITDTLRF.DEPOSITSLIPNORF AS DEPSITDTLRFDEPOSITSLIPNORF, " + Environment.NewLine );
            sb.Append( "DEPSITDTLRF.DEPOSITROWNORF AS DEPSITDTLRFDEPOSITROWNORF, " + Environment.NewLine );
            sb.Append( "DEPSITDTLRF.MONEYKINDCODERF AS DEPSITDTLRFMONEYKINDCODERF, " + Environment.NewLine );
            sb.Append( "DEPSITDTLRF.MONEYKINDNAMERF AS DEPSITDTLRFMONEYKINDNAMERF, " + Environment.NewLine );
            sb.Append( "DEPSITDTLRF.MONEYKINDDIVRF AS DEPSITDTLRFMONEYKINDDIVRF, " + Environment.NewLine );
            sb.Append( "DEPSITDTLRF.DEPOSITRF AS DEPSITDTLRFDEPOSITRF, " + Environment.NewLine );
            sb.Append( "DEPSITDTLRF.VALIDITYTERMRF AS DEPSITDTLRFVALIDITYTERMRF, " + Environment.NewLine );
            sb.Append( "DEPSITMAINRF.INPUTDEPOSITSECCDRF " + Environment.NewLine );  // ←最後の項目はカンマなし
            # endregion

            return sb.ToString();
        }

        /// <summary>
        /// WHERE文作成処理（入金明細）
        /// </summary>
        /// <param name="sqlCommand">SQLコマンド</param>
        /// <param name="extPrm">自由帳票共通抽出条件クラス</param>
        /// <param name="paraKey">条件キー</param>
        /// <param name="_childCustomerDic">得意先Dic</param>
        /// <param name="_dmdRangeEachClaimDic">請求単位Dic</param>
        /// <param name="_sumCustChildDic">子集計Dic</param>
        /// <returns>WHERE文</returns>
        /// <remarks>
        /// <br>Note        : WHERE文作成処理（入金明細）</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private string MakeWhereStringForDeposit(ref SqlCommand sqlCommand, EBooksFrePBillParaWork extPrm, EBooksFrePBillParaWork.FrePBillParaKey paraKey, Dictionary<int, List<int>> _childCustomerDic, Dictionary<string, DmdRangeEachClaim> _dmdRangeEachClaimDic, Dictionary<int, List<KeyValuePair<string, int>>> _sumCustChildDic)         
        {
            StringBuilder whereString = new StringBuilder();

            // 企業コードは必須条件
            whereString.Append( " WHERE DEPSITMAINRF.ENTERPRISECODERF=@FINDENTERPRISECODE " );
            SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add( "@FINDENTERPRISECODE", SqlDbType.NChar );
            findParaEnterpriseCode.Value = extPrm.EnterpriseCode;

            whereString.Append( " AND " );

                //--------------------------------------------------
                // 請求書
                //--------------------------------------------------
            // 集計レコード以外はそのまま指定(１コードのみ)
                        whereString.Append( string.Format( "DEPSITMAINRF.CUSTOMERCODERF=@FINDCUSTOMERCODE{0} ", 0 ) );
                        SqlParameter paraCustomerCode = sqlCommand.Parameters.Add( string.Format( "@FINDCUSTOMERCODE{0}", 0 ), SqlDbType.Int );
                        paraCustomerCode.Value = paraKey.ClaimCode;

            // 計上年月日
            // 伝票発行時と集計時で異なる可能性があるのでWHERE句にはAddUpSecCode,ClaimCodeを含めないが、
            // 抽出範囲の取得ではKEYとして指定する。
            DmdRangeEachClaimKey key = new DmdRangeEachClaimKey(
                                                paraKey.AddUpSecCode.Trim(),
                                                paraKey.ClaimCode,
                                                paraKey.ResultsSectCd.Trim(),
                                                paraKey.CustomerCode );

            DmdRangeEachClaim dmdRangeEachClaim;
            string keyString = key.CreateKey();
            if ( _dmdRangeEachClaimDic.ContainsKey( keyString ) )
            {
                dmdRangeEachClaim = _dmdRangeEachClaimDic[keyString];
            }
            else
            {
                dmdRangeEachClaim = new DmdRangeEachClaim( 0, paraKey.GetAddUpDateLongDate() );
            }

            whereString.Append( string.Format( "AND DEPSITMAINRF.ADDUPADATERF>=@FINDADDUPADATEST{0} AND DEPSITMAINRF.ADDUPADATERF<=@FINDADDUPADATEED{0} ", 0) );
            SqlParameter paraAddUpDateSt = sqlCommand.Parameters.Add( string.Format( "@FINDADDUPADATEST{0}", 0 ), SqlDbType.Int );
            paraAddUpDateSt.Value = dmdRangeEachClaim.DmdRangeSt;
            SqlParameter paraAddUpDateEd = sqlCommand.Parameters.Add( string.Format( "@FINDADDUPADATEED{0}", 0 ), SqlDbType.Int );
            paraAddUpDateEd.Value = dmdRangeEachClaim.DmdRangeEd;
            // 論理削除分は除外
            whereString.Append( " AND DEPSITMAINRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE " + Environment.NewLine );
            SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add( "@FINDLOGICALDELETECODE", SqlDbType.Int );
            paraLogicalDeleteCode.Value = 0;

            return whereString.ToString();
        }
        # endregion

        # region [自動生成系処理]
        /// <summary>
        /// LeftJoin生成処理
        /// </summary>
        /// <param name="leftTable">左テーブル</param>
        /// <param name="rightTable">右テーブル</param>
        /// <param name="rightAs">右条件</param>
        /// <param name="items">一致条件項目リスト</param>
        /// <param name="andMore">追加条件リスト</param>
        /// <returns>LEFT JOIN 文</returns>
        /// <remarks>
        /// <br>Note        : LeftJoin生成処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private string LeftJoin( string leftTable, string rightTable, string rightAs, string[] items, string[] andMore )
        {
            StringBuilder sb = new StringBuilder();

            // LEFT JOIN
            if ( rightAs == string.Empty )
            {
                sb.Append( string.Format( "  LEFT JOIN {0} ON ", rightTable ) );
                rightAs = rightTable;
            }
            else
            {
                sb.Append( string.Format( "  LEFT JOIN {0} AS {1} ON ", rightTable, rightAs ) );
            }

            // 企業コードは必須
            sb.Append( string.Format( "{0}.{2}={1}.{2} ", leftTable, rightAs, "ENTERPRISECODERF" ) );

            // その他Joinの条件
            for ( int index = 0; index < items.Length; index++ )
            {
                sb.Append( string.Format( "AND {0}.{2}={1}.{2} ", leftTable, rightAs, items[index] ) );
            }
            // 追加条件
            for ( int index = 0; index < andMore.Length; index++ )
            {
                sb.Append( string.Format( "AND {0} ", andMore[index] ) );
            }

            // 改行
            sb.Append( Environment.NewLine );

            return sb.ToString();
        }
        # endregion

        # region [請求書ログ出力]
        /// <summary>
        /// ログ出力処理
        /// </summary>
        /// <param name="requestLogDataList">請求書ログデータ</param>
        /// <param name="requestMessage">請求書メッセージ</param>
        /// <param name="logExceptionMsg">例外メッセージ</param>
        /// <remarks>
        /// <br>Note        : ログ出力処理</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private void LogWrite(List<RequestLogData> requestLogDataList, Dictionary<string, object> requestMessage, ref string logExceptionMsg)
        {
            try
            {
                FileStream _fs;										// ファイルストリーム
                StreamWriter _sw;                                     // ストリームwriter

                //ファールのパスを取得する(regedit表から)
                string registData;
                RegistryKey hkml = Registry.LocalMachine;
                RegistryKey software = hkml.OpenSubKey("SOFTWARE", true);
                RegistryKey broadleaf = software.OpenSubKey("BroadLeaf", true);
                RegistryKey service = broadleaf.OpenSubKey("Service", true);
                RegistryKey partsMan = service.OpenSubKey("Partsman", true);
                RegistryKey userAP =partsMan.OpenSubKey("USER_AP",true);
                registData = userAP.GetValue("InstallDirectory").ToString();


                //フォーだあるのかの判断
                string folderPath = registData + "\\LOG\\";
                if (!Directory.Exists(folderPath))
                {
                    DirectoryInfo di = Directory.CreateDirectory(folderPath);
                    DirectoryInfo dis = di.CreateSubdirectory("PMKAU01004R\\");
                }
                else
                {

                    if (!Directory.Exists(folderPath + "PMKAU01004R\\"))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(folderPath + "PMKAU01004R\\");
                    }
                }

                DateTime edt = DateTime.Now;
                //ファイルを作成する
                _fs = new FileStream(registData + "\\LOG\\" + "PMKAU01004R\\" + "PMKAU01004R_" + edt.ToString("yyyyMMdd") + ".Log", FileMode.Append, FileAccess.Write, FileShare.Write);
                _sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));

                //ファイルにログを書くことがあるのかの判断
                FileInfo fi = new FileInfo(@_fs.Name);  
                if(fi.Length == 0)
                {
                    _sw.WriteLine("\"LOGﾌｧｲﾙ得意先CD\"," + "\"前回請求処理日\"," + "\"今回金額\"," + "\"明細合計金額\"," + "\"売上差額\"," + "\"今回入金額\"," + "\"明細合計金額（入金）\"," + "\"入金差額\"," + "\"メッセージ\"," + "\"出力値\"");
                }

                //請求書メッセージのソート requestMessage --> requestSortedMessage
                string str1 = "売上ヘッダ取得クエリ";
                string str2 = "売上明細取得クエリ";
                string str3 = "入金明細取得クエリ";
                string str4 = "前回締日取得クエリ";
                string str5 = "締め範囲取得前開始日付";
                string str6 = "前回締日＋１";
                Dictionary<string, object> requestSortedMessage = new Dictionary<string, object>();
                if (requestMessage.ContainsKey(str1))
                {
                    requestSortedMessage.Add(str1, requestMessage[str1]);
                }
                if (requestMessage.ContainsKey(str2))
                {
                    requestSortedMessage.Add(str2, requestMessage[str2]);
                }
                if (requestMessage.ContainsKey(str3))
                {
                    requestSortedMessage.Add(str3, requestMessage[str3]);
                }
                if (requestMessage.ContainsKey(str4))
                {
                    requestSortedMessage.Add(str4, requestMessage[str4]);
                }
                if (requestMessage.ContainsKey(str5)) 
                {
                    requestSortedMessage.Add(str5, requestMessage[str5]);
                }
                if (requestMessage.ContainsKey(str6)) 
                {
                    requestSortedMessage.Add(str6, requestMessage[str6]);
                }

                //請求書メッセージをログファイルに書きます
                foreach(RequestLogData reld in requestLogDataList )
                {
                    foreach (KeyValuePair<string, object> item in requestSortedMessage)
                    {
                        _sw.WriteLine("\"" + reld.CustomerCode + "\",\"" + TDateTime.DateTimeToString("YYYY/MM/DD", reld.AddupDate) 
                                        + "\",\"" + reld.ThisTimeSalesPrice + "\",\"" + reld.TotalPrice + "\",\"" + reld.DifferentPrice 
                                        + "\",\"" + reld.ThisTimeDemandPrice + "\",\"" + reld.TotalDemandPrice + "\",\"" + reld.DifferentDemandPrice
                                        + "\",\"" + item.Key + "\",\"" + item.Value + "\"");
                        _sw.WriteLine(string.Empty);
                    }

                }
               

                if (_sw != null)
                    _sw.Close();
                if (_fs != null)
                    _fs.Close();
                
            }
            catch (Exception ex)
            {
                logExceptionMsg = ex.Message;
            }
        }
        #endregion
        #endregion

        # region [請求先別締範囲キー　構造体]
        /// <summary>
        /// 請求先別締範囲キー　構造体
        /// </summary>
        /// <remarks>
        /// <br>Note        : 請求先別締範囲キー　構造体</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private struct DmdRangeEachClaimKey
        {
            /// <summary>計上拠点コード</summary>
            private string _addUpSecCode;
            /// <summary>請求先コード</summary>
            private int _claimCode;
            /// <summary>実績拠点コード</summary>
            private string _resultsSectCd;
            /// <summary>得意先コード</summary>
            private int _customerCode;
            /// <summary>
            /// 計上拠点コード
            /// </summary>
            public string AddUpSecCode
            {
                get { return _addUpSecCode; }
                set { _addUpSecCode = value; }
            }
            /// <summary>
            /// 請求先コード
            /// </summary>
            public int ClaimCode
            {
                get { return _claimCode; }
                set { _claimCode = value; }
            }
            /// <summary>
            /// 実績拠点コード
            /// </summary>
            public string ResultsSectCd
            {
                get { return _resultsSectCd; }
                set { _resultsSectCd = value; }
            }
            /// <summary>
            /// 得意先コード
            /// </summary>
            public int CustomerCode
            {
                get { return _customerCode; }
                set { _customerCode = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="addUpSecCode">計上拠点コード</param>
            /// <param name="claimCode">請求先コード</param>
            /// <param name="resultsSectCd">実績拠点コード</param>
            /// <param name="customerCode">得意先コード</param>
            public DmdRangeEachClaimKey(string addUpSecCode , int claimCode, string resultsSectCd, int customerCode )
            {
                _addUpSecCode = addUpSecCode;
                _claimCode = claimCode;
                _resultsSectCd = resultsSectCd;
                _customerCode = customerCode;
            }
            /// <summary>
            /// KEY文字列生成(Dictionary格納時の高速化を図る為)
            /// </summary>
            /// <returns></returns>
            public string CreateKey()
            {
                return string.Format( "{0}-{1:D8}-{2}-{3:D8}", _addUpSecCode, _claimCode, _resultsSectCd, _customerCode );
            }
        }
        # endregion

        # region [請求先別締範囲　構造体]
        /// <summary>
        /// 請求先別締範囲　構造体
        /// </summary>
        private struct DmdRangeEachClaim
        {
            /// <summary>締開始日</summary>
            private int _dmdRangeSt;
            /// <summary>締終了日</summary>
            private int _dmdRangeEd;
            /// <summary>
            /// 締開始日
            /// </summary>
            public int DmdRangeSt
            {
                get { return _dmdRangeSt; }
                set { _dmdRangeSt = value; }
            }
            /// <summary>
            /// 締終了日
            /// </summary>
            public int DmdRangeEd
            {
                get { return _dmdRangeEd; }
                set { _dmdRangeEd = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="dmdRangeSt">締開始日</param>
            /// <param name="dmdRangeEd">締終了日</param>
            public DmdRangeEachClaim( int dmdRangeSt, int dmdRangeEd )
            {
                _dmdRangeSt = dmdRangeSt;
                _dmdRangeEd = dmdRangeEd;
            }
        }
        # endregion

        # region [請求集計キー]
        /// <summary>
        /// 請求集計キー
        /// </summary>
        /// <remarks>
        /// <br>Note        : 請求集計キー</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        private struct DmdSummaryKey
        {
            /// <summary>計上拠点コード</summary>
            private string _addUpSecCode;
            /// <summary>請求先コード</summary>
            private int _claimCode;
            /// <summary>
            /// 計上拠点コード
            /// </summary>
            /// <remarks>拠点</remarks>
            public string AddUpSecCode
            {
                get { return _addUpSecCode; }
                set { _addUpSecCode = value; }
            }
            /// <summary>
            /// 請求先コード
            /// </summary>
            /// <remarks>得意先</remarks>
            public int ClaimCode
            {
                get { return _claimCode; }
                set { _claimCode = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="addUpSecCode">計上拠点コード</param>
            /// <param name="claimCode">請求先コード</param>
            public DmdSummaryKey( string addUpSecCode, int claimCode )
            {
                _addUpSecCode = addUpSecCode;
                _claimCode = claimCode;
            }
            /// <summary>
            /// KEY文字列生成(Dictionary格納時の高速化を図る為)
            /// </summary>
            /// <returns></returns>
            public string CreateKey()
            {
                return string.Format( "{0}-{1:D8}", _addUpSecCode, _claimCode);
            }
        }
        # endregion

        #region 請求書ログ出力データのクラス
        internal class RequestLogData
        {
            # region ■ private field ■
            /// <summary>LOGﾌｧｲﾙ得意先CD</summary>
            private int customerCode;
            /// <summary>前回請求処理日</summary>
            private DateTime addupDate;
            /// <summary>今回金額</summary>
            private long thisTimeSalesPrice;
            /// <summary>明細合計金額</summary>
            private long totalPrice;
            /// <summary>差額</summary>
            private long DifferentPriceVar;
            /// <summary>今回入金額</summary>
            private long thisTimeDemandPrice;
            /// <summary>明細合計金額（入金</summary>
            private long totalDemandPrice;
            /// <summary>入金差額</summary>
            private long differentDemandPrice;

            # endregion ■ private field ■

            # region ■ public propaty ■

            /// public propaty name  :  CustomerCode
            /// <summary>LOGﾌｧｲﾙ得意先CDプロパティ</summary>
            public int CustomerCode
            {
                get { return customerCode; }
                set { customerCode = value; }
            }

            /// public propaty name  :  AddupDate
            /// <summary>前回請求処理日プロパティ</summary>
            public DateTime AddupDate
            {
                get { return addupDate; }
                set { addupDate = value; }
            }

            /// public propaty name  :  ThisTimeSalesPrice
            /// <summary>今回金額プロパティ</summary>
            public long ThisTimeSalesPrice
            {
                get { return thisTimeSalesPrice; }
                set { thisTimeSalesPrice = value; }
            }

            /// public propaty name  :  TotalPrice
            /// <summary>明細合計金額プロパティ</summary>
            public long TotalPrice
            {
                get { return totalPrice; }
                set { totalPrice = value; }
            }

            /// public propaty name  :  DifferentPrice
            /// <summary>差額プロパティ</summary>
            public long DifferentPrice
            {
                get { return DifferentPriceVar; }
                set { DifferentPriceVar = value; }
            }

            /// public propaty name  :  ThisTimeDemandPrice
            /// <summary>今回入金額プロパティ</summary>
            public long ThisTimeDemandPrice
            {
                get { return thisTimeDemandPrice; }
                set { thisTimeDemandPrice = value; }
            }

            /// public propaty name  :  TotalDemandPrice
            /// <summary>明細合計金額（入金）プロパティ</summary>
            public long TotalDemandPrice
            {
                get { return totalDemandPrice; }
                set { totalDemandPrice = value; }
            }

            /// public propaty name  :  DifferentDemandPrice
            /// <summary>入金差額プロパティ</summary>
            public long DifferentDemandPrice
            {
                get { return differentDemandPrice; }
                set { differentDemandPrice = value; }
            }

            # endregion ■ public propaty ■

            # region ■ Constructor ■
            /// <summary>
            /// 請求書出力データのクラス
            /// </summary>
            /// <returns>RequestInfoクラスのインスタンス</returns>
            public RequestLogData()
            {
            }
            # endregion ■ Constructor ■
        }
        #endregion
    }
}
//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 受信売上データ集計リモート
// プログラム概要   : 売上データ受信時「売上月次集計データ、
//                    商品別売上月次集計データ」を集計する
//                    売上データ受信時に在庫マスタの更新を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 斉建華
// 作 成 日  2011/08/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 斉建華
// 修 正 日  2011/09/07   修正内容 : redmine#24343
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 孫東響
// 修 正 日  2011/09/21   修正内容 : redmine#25379
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
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 受信売上データ集計リモートオブジェクト
	/// </summary>
	/// <remarks>
    /// <br>Note       : 受信売上データ集計操作を行うクラスです。</br>
	/// <br>Programmer : 斉建華</br>
	/// <br>Date       : 2011.8.5</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class APTotalizeSalesSlip : RemoteDB
    {
        #region [定数定義]
        /// <summary>
        /// クラス名称
        /// </summary>
        private const string ctCLASS_NAME = "APTotalizeSalesSlip";

        /// <summary>
        /// 全社拠点コード
        /// </summary>
        private const string ctSECTIONCODE_00 = "00";
        #endregion [定数定義]
        #region [プロパティー定義]
        private APSalesInfoConverter _salesInfoConverter = null;
        /// <summary>
        /// 売上情報ワークコンバーター
        /// </summary>
        private APSalesInfoConverter SalesInfoConverter
        {
            get
            {
                if (null == _salesInfoConverter)
                    _salesInfoConverter = new APSalesInfoConverter();
                return _salesInfoConverter;
            }
        }

        private SalesSlipDB _salesSlipDB = null;
        /// <summary>
        /// 売上データDBリモートオブジェクト
        /// </summary>
        private SalesSlipDB SalesSlipDB
        {
            get
            {
                if (null == _salesSlipDB)
                    _salesSlipDB = new SalesSlipDB();
                return _salesSlipDB;
            }
        }

        private MonthlyTtlSalesUpdDB _monthlyTtlSalesUpdDB = null;
        /// <summary>
        /// 売上月次集計データ更新リモートオブジェクト
        /// </summary>
        private MonthlyTtlSalesUpdDB MonthlyTtlSalesUpdDB
        {
            get
            {
                if (null == _monthlyTtlSalesUpdDB)
                    _monthlyTtlSalesUpdDB = new MonthlyTtlSalesUpdDB();
                return _monthlyTtlSalesUpdDB;
            }
        }

        private IOWriteMAHNBStockUpdateDB _stockUpdateDB = null;
        /// <summary>
        /// 在庫更新リモートオブジェクト
        /// </summary>
        private IOWriteMAHNBStockUpdateDB StockUpdateDB
        {
            get
            {
                if (null == this._stockUpdateDB)
                {
                    IOWriteCtrlOptWork ctrlOptWork = new IOWriteCtrlOptWork();
                    ctrlOptWork.CtrlStartingPoint = (int)IOWriteCtrlOptCtrlStartingPoint.Sales;
                    this._stockUpdateDB = new IOWriteMAHNBStockUpdateDB(ctrlOptWork);
                }
                return this._stockUpdateDB;
            }
        }
        #endregion [プロパティー定義]

        #region [パブリック方法]
        /// <summary>
		/// 受信売上データ集計リモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 特になし</br>
		/// <br>Programmer : 斉建華</br>
		/// <br>Date       : 2011.8.5</br>
		/// </remarks>
        public APTotalizeSalesSlip()
		{
		}

        /// <summary>
        /// 売上受信更新処理
        /// </summary>
        /// <param name="enterpriseCode">受信拠点側の企業コード</param>
        /// <param name="paramSalesSlipList">受信した売上データリスト</param>
        /// <param name="paramSalesDetailList">受信した売上明細データリスト</param>
        /// <param name="salesSlipRecvDiv">売上データの受信区分</param>
        /// <param name="sqlConnection">DB接続</param>
        /// <param name="sqlTransaction">DBトランザクション</param>
        /// <returns>ステータス</returns>
        public int TotalizeReceivedSalesSlip(string enterpriseCode, ArrayList paramSalesSlipList, ArrayList paramSalesDetailList, int salesSlipRecvDiv, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            // パラメータチェック
            if (!CheckParam(paramSalesSlipList, paramSalesDetailList))
                return status;

            // 企業コードをバックアップ
            string enterpriseCodeBak = ((APSalesSlipWork)paramSalesSlipList[0]).EnterpriseCode;
            try
            {
                // 受信拠点側の企業コードをセット
                SetEnterpriseCodeToWorkList(enterpriseCode, paramSalesSlipList);
                SetEnterpriseCodeToWorkList(enterpriseCode, paramSalesDetailList);
                // 売上受信更新処理
                status = TotalizeReceivedSalesSlipProc(paramSalesSlipList, paramSalesDetailList, salesSlipRecvDiv, sqlConnection, sqlTransaction);
            }
            finally
            {
                // 企業コードをリストア
                SetEnterpriseCodeToWorkList(enterpriseCodeBak, paramSalesSlipList);
                SetEnterpriseCodeToWorkList(enterpriseCodeBak, paramSalesDetailList);
            }
            return status;
        }
        
        /// <summary>
        /// 売上受信更新処理
        /// </summary>
        /// <param name="paramSalesSlipList">受信した売上データリスト</param>
        /// <param name="paramSalesDetailList">受信した売上明細データリスト</param>
        /// <param name="salesSlipRecvDiv">売上データの受信区分</param>
        /// <param name="sqlConnection">DB接続</param>
        /// <param name="sqlTransaction">DBトランザクション</param>
        /// <returns>ステータス</returns>
        private int TotalizeReceivedSalesSlipProc(ArrayList paramSalesSlipList, ArrayList paramSalesDetailList, int salesSlipRecvDiv, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            // パラメータを利用して、売上情報ワークリストを取得(後の処理に当該リストを使用)
            List<APSalesInfoWork> salesInfoList = GetAPSalesInfoList(paramSalesSlipList, paramSalesDetailList);
            if (salesInfoList.Count == 0)
                return status;

            // 受信した売上明細のディクショナリーを取得
            Dictionary<string, APSalesDetailWork> salesDetailDic = GetSalesDetailDic(paramSalesDetailList);
            Dictionary<string, SalesTtlStWork> salesTtlStDic = null;
            if (2 == salesSlipRecvDiv)
            {
                // 売上全体設定マスタのディクショナリーを取得
                status = GetSalesTtlStWorkDic(((APSalesSlipWork)paramSalesSlipList[0]).EnterpriseCode, out salesTtlStDic);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    return status;
            }

            SqlEncryptInfo sqlEncryptInfo = null;
            bool isHaveSalesSlip = false;
            string sectionCodeKey = ctSECTIONCODE_00; // 売上全体設定マスタ取得用の拠点コード
            foreach (APSalesInfoWork salesInfoWork in salesInfoList)
            {
                SalesSlipWork recvdSalesSlipWork = null;
                ArrayList recvdSalesDetailList = null;
                SalesSlipWork secSalesSlipWork = null;
                ArrayList secSalesDetailList = null;
                // 受信した売上と売上明細データと受信拠点側売上と売上明細データを取得
                status = GetSecSalesInfo(salesInfoWork, out recvdSalesSlipWork, out recvdSalesDetailList, out secSalesSlipWork, out secSalesDetailList, sqlConnection, sqlTransaction);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    // エラーが発生
                    return status;

                isHaveSalesSlip = (null != secSalesSlipWork); // 拠点側売上ありか

                if (isHaveSalesSlip && recvdSalesSlipWork.DebitNoteDiv == 0 && secSalesSlipWork.DebitNoteDiv == 2) // ADD 2011/08/30 qijh #24209
                    // 2:元黒 -> 0:黒伝の場合、集計在庫対象外
                    continue;

                // 集計在庫更新前に処理(出荷差分数などの設定)
                TotalizeInitial(recvdSalesSlipWork, recvdSalesDetailList, secSalesDetailList);
                
                if (IsTtlObj(recvdSalesSlipWork, secSalesSlipWork, isHaveSalesSlip))
                {
                    // 集計する
                    status = TotalizeProc(salesInfoWork, recvdSalesSlipWork, recvdSalesDetailList, secSalesSlipWork, secSalesDetailList, sqlConnection, sqlTransaction);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        return status;
                }
                if (2 != salesSlipRecvDiv)
                    continue;
                
                // 在庫更新ありの場合
                // 在庫マスタ、在庫受払履歴データを更新 --------------------------------------------->
                if (salesTtlStDic.ContainsKey(recvdSalesSlipWork.SectionCode.Trim()))
                    sectionCodeKey = recvdSalesSlipWork.SectionCode.Trim();
                else if (salesTtlStDic.ContainsKey(ctSECTIONCODE_00))
                    sectionCodeKey = ctSECTIONCODE_00;
                else
                    // 計上残区分が取得できない場合、不正の結果になる可能性があるので、終了にする
                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;

                // 売上全体設定マスタより計上残区分を設定
                StockUpdateDB.IOWriteCtrlOptWork.EstimateAddUpRemDiv = salesTtlStDic[sectionCodeKey].EstmateAddUpRemDiv; // 見積データ計上残区分
                StockUpdateDB.IOWriteCtrlOptWork.AcpOdrrAddUpRemDiv = salesTtlStDic[sectionCodeKey].AcpOdrrAddUpRemDiv; // 受注データ計上残区分
                StockUpdateDB.IOWriteCtrlOptWork.ShipmAddUpRemDiv = salesTtlStDic[sectionCodeKey].ShipmAddUpRemDiv; // 出荷データ計上残区分
                StockUpdateDB.IOWriteCtrlOptWork.RetGoodsStockEtyDiv = salesTtlStDic[sectionCodeKey].RetGoodsStockEtyDiv;// 返品時在庫登録区分
                StockUpdateDB.IOWriteCtrlOptWork.SupplierSlipDelDiv = salesTtlStDic[sectionCodeKey].SupplierSlipDelDiv;// 仕入伝票削除区分

                CustomSerializeArrayList cstSecList = new CustomSerializeArrayList();
                cstSecList.Add(secSalesSlipWork);
                cstSecList.Add(secSalesDetailList);

                CustomSerializeArrayList cstRecvdList = new CustomSerializeArrayList();
                cstRecvdList.Add(recvdSalesSlipWork);
                cstRecvdList.Add(recvdSalesDetailList);
                cstRecvdList.Add(GetAddUpOrgDetailList(salesDetailDic, recvdSalesDetailList)); // 計上元明細リストを取得
                cstRecvdList.Add(GetSlipDetailAddInfoList(recvdSalesSlipWork, recvdSalesDetailList, isHaveSalesSlip, salesDetailDic)); // 売上明細追加情報の取得

                object freeParam = null;
                string retMsg = null;
                string retItemInfo = null;

                //add zhujc 20110916 ------>>>>>>
                // 貸出伝票、論理削除、出荷データ計上残さない、受信側存在しない
                int logicDelFlg = salesInfoWork.SalesSlipWork.LogicalDeleteCode;

                if (40 == recvdSalesSlipWork.AcptAnOdrStatus && 1 == recvdSalesSlipWork.LogicalDeleteCode && 1 == salesTtlStDic[sectionCodeKey].ShipmAddUpRemDiv && !isHaveSalesSlip)
                {
                    ArrayList salesDetailList = null;
                    if(null != cstRecvdList && cstRecvdList.Count > 2)
                    {
                        salesDetailList = (ArrayList)cstRecvdList[1];
                    }

                    int i = 0;
                    int logicDeleteCode = 0;//ADD 2011/09/21 sundx #25379
                    foreach (APSalesDetailWork salesDetailWork in salesInfoWork.SalesDetailWorkList)
                    {
                        // 計上元明細です
                        //if (IsAddUpOrgData(salesDetailWork, paramSalesDetailList))//DEL 2011/09/21 sundx #25379
                        if (IsAddUpOrgData(salesDetailWork, paramSalesDetailList, out logicDeleteCode) && logicDeleteCode == 0)//ADD 2011/09/21 sundx #25379
                        {
                            logicDelFlg = 0;

                            ((SalesSlipWork)cstRecvdList[0]).LogicalDeleteCode = 0;

                            ((SalesDetailWork)salesDetailList[i]).AcptAnOdrRemainCnt = ((SalesDetailWork)salesDetailList[i]).ShipmentCnt;
                        }
                        i++;
                    }
                    cstRecvdList[1] = salesDetailList;

                    TotalizeInitial((SalesSlipWork)cstRecvdList[0], (ArrayList)cstRecvdList[1], secSalesDetailList);
                }
                //add zhujc 20110916 ------<<<<<<

                //if (0 == salesInfoWork.SalesSlipWork.LogicalDeleteCode)  //del zhujc 20110916
                if (0 == logicDelFlg)  //add zhujc 20110916
                {
                    // 在庫マスタ更新前準備処理を行い
                    status = StockUpdateDB.WriteInitial(ctCLASS_NAME, ref cstSecList, ref cstRecvdList, 0, string.Empty, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        return status;

                    // 在庫マスタ更新処理を行い
                    status = StockUpdateDB.Write(ctCLASS_NAME, ref cstSecList, ref cstRecvdList, 0, string.Empty, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        return status;

                }
                else
                {
                    if (isHaveSalesSlip && 0 == secSalesSlipWork.LogicalDeleteCode)
                    {
                        // 売上削除情報を追加
                        cstRecvdList.Add(GetSalesSlipDeleteWork(secSalesSlipWork));  // ADD 2011/08/30 qijh #24175 #24209

                        // 受信した計上元明細データより、拠点側の計上元売上明細データの受注残数を設定
                        SetAcptAnOdrRemainCntForAddUpOrgDetail(secSalesDetailList, recvdSalesDetailList); // ADD 2011/09/07 qijh #24343

                        // 在庫マスタ更新前準備処理を行い
                        status = StockUpdateDB.DeleteInitial(ctCLASS_NAME, ref cstSecList, ref cstRecvdList, 0, string.Empty, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            return status;

                        // 在庫マスタ更新処理を行い
                        status = StockUpdateDB.Delete(ctCLASS_NAME, ref cstSecList, ref cstRecvdList, 0, string.Empty, ref freeParam, out retMsg, out retItemInfo, ref sqlConnection, ref sqlTransaction, ref sqlEncryptInfo);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            return status;
                    }
                }
                // 在庫マスタ、在庫受払履歴データを更新 ---------------------------------------------<
            }
            return status;
        }
        #endregion [パブリック方法]

        #region [プライベート方法]
        // ------------------------- ADD 2011/09/07 qijh #24343 ----------------------- >>>>>
        /// <summary>
        /// 受信した計上元明細データより、拠点側の計上元売上明細データの受注残数を設定
        /// </summary>
        /// <param name="secSalesDetailList">拠点側の売上明細リスト</param>
        /// <param name="recvdSalesDetailList">受信した明細リスト</param>
        private void SetAcptAnOdrRemainCntForAddUpOrgDetail(ArrayList secSalesDetailList, ArrayList recvdSalesDetailList)
        {
            // 計上元明細を削除する場合、受信した受注残数を利用して在庫削除を行う為に、当該処理を行う(エントリをまねる)
            foreach (SalesDetailWork oldDtlWork in secSalesDetailList)
            {
                if (oldDtlWork.AcptAnOdrStatus != 40)
                    continue;
                foreach (SalesDetailWork newDtlWork in recvdSalesDetailList)
                {
                    if (newDtlWork.SalesSlipDtlNum == oldDtlWork.SalesSlipDtlNum && newDtlWork.AcptAnOdrStatus == oldDtlWork.AcptAnOdrStatus)
                    {
                        oldDtlWork.AcptAnOdrRemainCnt = newDtlWork.AcptAnOdrRemainCnt;
                        break;
                    }
                }
            }
        }
        // ------------------------- ADD 2011/09/07 qijh #24343 ----------------------- <<<<<

        // ------------------------- ADD 2011/08/30 qijh #24175 #24209 ----------------------- >>>>>
        /// <summary>
        /// 売上削除情報を取得
        /// </summary>
        /// <param name="paramSalesSlipWork">売上伝票データ</param>
        /// <returns>売上削除情報</returns>
        private SalesSlipDeleteWork GetSalesSlipDeleteWork(SalesSlipWork paramSalesSlipWork)
        {
            // 売上削除情報を作成
            SalesSlipDeleteWork salesSlipDeleteWork = new SalesSlipDeleteWork();
            salesSlipDeleteWork.AcptAnOdrStatus = paramSalesSlipWork.AcptAnOdrStatus;
            salesSlipDeleteWork.DebitNoteDiv = paramSalesSlipWork.DebitNoteDiv;
            salesSlipDeleteWork.EnterpriseCode = paramSalesSlipWork.EnterpriseCode;
            salesSlipDeleteWork.SalesSlipNum = paramSalesSlipWork.SalesSlipNum;
            salesSlipDeleteWork.UpdateDateTime = paramSalesSlipWork.UpdateDateTime;
            return salesSlipDeleteWork;
        }
        // ------------------------- ADD 2011/08/30 qijh #24175 #24209 ----------------------- <<<<<

        /// <summary>
        /// 売上集計在庫更新の初期処理を行う
        /// </summary>
        /// <param name="recvdSalesSlipWork">受信した売上データ</param>
        /// <param name="recvdSalesDetailList">受信した売上明細リスト</param>
        /// <param name="secSalesDetailList">拠点側の売上明細リスト</param>
        private void TotalizeInitial(SalesSlipWork recvdSalesSlipWork, ArrayList recvdSalesDetailList, ArrayList secSalesDetailList)
        {
            if (recvdSalesSlipWork.LogicalDeleteCode == 0)
            {
                // 新規更新の場合
                foreach (SalesDetailWork newDtlWork in recvdSalesDetailList)
                {
                    // 出荷差分数、受注残数、残数更新日の初期値を設定
                    newDtlWork.ShipmCntDifference = newDtlWork.ShipmentCnt;
                    newDtlWork.AcptAnOdrRemainCnt = newDtlWork.ShipmentCnt;
                    newDtlWork.RemainCntUpdDate = DateTime.Now;

                    if (recvdSalesSlipWork.DebitNoteDiv == 1 || null == secSalesDetailList || 0 == secSalesDetailList.Count)
                        // 赤伝又は拠点側の売上明細存在しない
                        continue;
                    foreach (SalesDetailWork oldDtlWork in secSalesDetailList)
                    {

                        // 同一明細の判断に品番、メーカーも追加
                        if (newDtlWork.EnterpriseCode == oldDtlWork.EnterpriseCode
                            && newDtlWork.AcptAnOdrStatus == oldDtlWork.AcptAnOdrStatus
                            && newDtlWork.SalesSlipDtlNum == oldDtlWork.SalesSlipDtlNum
                            && newDtlWork.GoodsNo == oldDtlWork.GoodsNo
                            && newDtlWork.GoodsMakerCd == oldDtlWork.GoodsMakerCd)
                        {
                            // 出荷差分数の設定
                            newDtlWork.ShipmCntDifference = newDtlWork.ShipmentCnt - oldDtlWork.ShipmentCnt;

                            // 受注残数の設定 (更新前受注残数＋更新後出荷差分数)
                            newDtlWork.AcptAnOdrRemainCnt = oldDtlWork.AcptAnOdrRemainCnt + newDtlWork.ShipmCntDifference;

                            // 出荷差分数が 0 の場合、更新前の残数更新日を設定する
                            if (newDtlWork.ShipmCntDifference == 0)
                                newDtlWork.RemainCntUpdDate = oldDtlWork.RemainCntUpdDate;

                            break;
                        }
                    }
                }
            }
            else
            {
                // 削除の場合
                if (null != secSalesDetailList && secSalesDetailList.Count > 0)
                    foreach (SalesDetailWork oldDtlWork in secSalesDetailList)
                        oldDtlWork.ShipmCntDifference = oldDtlWork.ShipmentCnt;
            }
        }

        /// <summary>
        /// 売上明細追加情報リストを作成
        /// </summary>
        /// <param name="recvdSalesSlipWork">受信した売上データ</param>
        /// <param name="recvdSalesDetailList">受信した売上明細リスト</param>
        /// <param name="isHaveSalesSlip">拠点側に売上データがあるか</param>
        /// <param name="dic">受信した売上明細のディクショナリー</param>
        /// <returns></returns>
        private ArrayList GetSlipDetailAddInfoList(SalesSlipWork recvdSalesSlipWork, ArrayList recvdSalesDetailList, bool isHaveSalesSlip, Dictionary<string, APSalesDetailWork> dic)
        {
            ArrayList retAddInfoList = new ArrayList();
            foreach (SalesDetailWork rvdDetailWk in recvdSalesDetailList)
            {
                SlipDetailAddInfoWork addInfoWk = new SlipDetailAddInfoWork();
                retAddInfoList.Add(addInfoWk);
                // 関連Guidを設定
                rvdDetailWk.DtlRelationGuid = rvdDetailWk.FileHeaderGuid;
                addInfoWk.DtlRelationGuid = rvdDetailWk.DtlRelationGuid;
                // 計上残区分を設定 -------------------------------------->
                addInfoWk.AddUpRemDiv = 0;
                if (recvdSalesSlipWork.LogicalDeleteCode == 0 && isHaveSalesSlip == false 
                    && rvdDetailWk.AcptAnOdrStatusSrc == 20 
                    && dic.ContainsKey(GetSalesDetailKey(rvdDetailWk.AcptAnOdrStatusSrc, rvdDetailWk.SalesSlipDtlNumSrc)))
                {
                    // 新規の売上伝票の場合で、拠点側のデータがなしの場合で
                    // 受信した売上伝票の計上元伝票がありの場合、計上残＝残す
                    addInfoWk.AddUpRemDiv = 1;     // 受注データ計上残区分　0:伝票追加情報参照,1:残す,2:残さない
                }   
                // TODO:UOE伝票について(#23475)
                // 計上残区分を設定 --------------------------------------<
            }
            return retAddInfoList;
        }

        /// <summary>
        /// パラメータをチェック
        /// </summary>
        /// <param name="paramSalesSlipList">売上伝票リスト</param>
        /// <param name="paramSalesDetailList">売上明細リスト</param>
        /// <returns>true:チェックOK、false:チェックNG</returns>
        private bool CheckParam(ArrayList paramSalesSlipList, ArrayList paramSalesDetailList)
        {
            if (null == paramSalesSlipList || null == paramSalesDetailList || paramSalesSlipList.Count == 0 || paramSalesDetailList.Count == 0)
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

        /// <summary>
        /// 計上元明細リストを取得
        /// </summary>
        /// <param name="dic">売上明細のディクショナリー</param>
        /// <param name="recvdSalesDetailList">受信した売上明細データリスト</param>
        /// <returns>計上元明細リスト</returns>
        private ArrayList GetAddUpOrgDetailList(Dictionary<string, APSalesDetailWork> dic, ArrayList recvdSalesDetailList)
        {
            ArrayList addUpOrgList = new ArrayList();
            if (null == recvdSalesDetailList || recvdSalesDetailList.Count == 0)
                return addUpOrgList;

            foreach (SalesDetailWork detailwk in recvdSalesDetailList)
            {
                if (detailwk.AcptAnOdrStatusSrc > 0 && detailwk.SalesSlipDtlNumSrc > 0)
                {
                    string key = GetSalesDetailKey(detailwk.AcptAnOdrStatusSrc, detailwk.SalesSlipDtlNumSrc);
                    if (dic.ContainsKey(key))
                    {
                        // 計上元明細あり
                        APSalesDetailWork addUpOrgwk = dic[key];
                        if (null != addUpOrgwk)
                        {
                            AddUpOrgSalesDetailWork addUpOrgSalesDetailWork = SalesInfoConverter.GetAddUpOrgSalesDetailWork(addUpOrgwk);
                            // 明細関連付けGUIDを設定
                            detailwk.DtlRelationGuid = detailwk.FileHeaderGuid;
                            addUpOrgSalesDetailWork.DtlRelationGuid = detailwk.FileHeaderGuid;
                            if (addUpOrgSalesDetailWork.AcptAnOdrStatus == 40)
                                addUpOrgSalesDetailWork.LogicalDeleteCode = 0; // add qijh 2011/09/07 #24343 エントリ側に在庫更新時に計上元が有効で、在庫更新後で計上元を削除
                            addUpOrgList.Add(addUpOrgSalesDetailWork);
                        }
                    }
                }
            }
            return addUpOrgList;
        }

        /// <summary>
        /// 売上明細のキーを作成
        /// </summary>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="salesSlipDtlNum">売上明細通番</param>
        /// <returns>売上明細のキー</returns>
        private String GetSalesDetailKey(int acptAnOdrStatus, long salesSlipDtlNum)
        {
            StringBuilder sbKey = new StringBuilder();
            sbKey.Append(acptAnOdrStatus.ToString().PadLeft(2, '0'));
            sbKey.Append(salesSlipDtlNum.ToString().PadLeft(12, '0'));
            return sbKey.ToString();
        }

        /// <summary>
        /// 受信した売上明細のディクショナリーを取得
        /// </summary>
        /// <param name="paramSalesDetailList">受信した売上明細データリスト</param>
        /// <returns>ディクショナリー</returns>
        private Dictionary<string, APSalesDetailWork> GetSalesDetailDic(ArrayList paramSalesDetailList)
        {
            Dictionary<string, APSalesDetailWork> dic = new Dictionary<string, APSalesDetailWork>();
            string key = string.Empty;
            foreach (APSalesDetailWork detailwk in paramSalesDetailList)
            {
                key = GetSalesDetailKey(detailwk.AcptAnOdrStatus, detailwk.SalesSlipDtlNum);
                if (!dic.ContainsKey(key))
                    dic.Add(key, detailwk);
            }
            return dic;
        }

        /// <summary>
        /// 集計対象を判断する
        /// </summary>
        /// <param name="recvdSalesSlipWork">受信した売上データ</param>
        /// <param name="secSalesSlipWork">拠点側の売上データ</param>
        /// <param name="isHaveSalesSlip">拠点側の売上データありかどうか</param>
        /// <returns>true:集計対象 false:集計対象でない</returns>
        private bool IsTtlObj(SalesSlipWork recvdSalesSlipWork, SalesSlipWork secSalesSlipWork, bool isHaveSalesSlip)
        {
            bool doTotalFlg = false;
            // 集計対象かを判断
            if (recvdSalesSlipWork.LogicalDeleteCode == 0)
            {
                // 新規又は更新の場合
                if (recvdSalesSlipWork.DebitNoteDiv == 1)
                {
                    // 1:赤伝
                    if (!isHaveSalesSlip)
                        doTotalFlg = true;
                }
                else if (recvdSalesSlipWork.DebitNoteDiv == 2)
                {
                    // 2:元黒
                    if (!isHaveSalesSlip)
                        doTotalFlg = true;
                }
                else
                {
                    // 0:黒伝
                    if (isHaveSalesSlip == false || 
                        (isHaveSalesSlip && secSalesSlipWork.DebitNoteDiv != 2))
                        doTotalFlg = true;
                }
            }
            else
            {
                // 伝票削除の場合
                if (isHaveSalesSlip && secSalesSlipWork.LogicalDeleteCode == 0)
                    doTotalFlg = true;
            }
            return doTotalFlg;
        }

        /// <summary>
        /// 受信した売上と売上明細データと
        /// 受信拠点側売上と売上明細データを取得
        /// </summary>
        /// <param name="paramSalesInfoWork">受信した売上情報</param>
        /// <param name="recvdSalesSlipWork">転化した受信の売上</param>
        /// <param name="recvdSalesDetailList">転化した受信の売上明細リスト</param>
        /// <param name="secSalesSlipWork">拠点の売上</param>
        /// <param name="secSalesDetailList">拠点の売上明細リスト</param>
        /// <param name="sqlConnection">DBの接続</param>
        /// <param name="sqlTransaction">DBトランザクション</param>
        /// <returns>ステータス</returns>
        private int GetSecSalesInfo(APSalesInfoWork paramSalesInfoWork, out SalesSlipWork recvdSalesSlipWork, out ArrayList recvdSalesDetailList,
            out SalesSlipWork secSalesSlipWork, out ArrayList secSalesDetailList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            secSalesSlipWork = null;
            secSalesDetailList = new ArrayList();

            recvdSalesSlipWork = SalesInfoConverter.GetSecSalesSlipWork(paramSalesInfoWork.SalesSlipWork); // 受信した売上データ
            recvdSalesDetailList = new ArrayList(); // 受信した売上明細データリスト
            foreach (APSalesDetailWork apDetailWork in paramSalesInfoWork.SalesDetailWorkList)
            {
                // 受信した売上明細リストを集計用のパラメータリストにセット
                recvdSalesDetailList.Add(SalesInfoConverter.GetSecSalesDetailWork(apDetailWork));
            }

            // 受信拠点側売上を取得
            SalesSlipReadWork salesSlipReadWork = GetSalesSlipReadWork(paramSalesInfoWork.SalesSlipWork);
            status = SalesSlipDB.ReadSalesSlipWorkIgnoreDel(out secSalesSlipWork, salesSlipReadWork, sqlConnection, sqlTransaction);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                // エラーが発生
                return status;

            // 受信拠点側に伝票がない
            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                secSalesSlipWork = null;
                return status;
            }

            // 受信拠点の明細データリストを取得
            status = SalesSlipDB.ReadSalesDetailWorkIgnoreDel(out secSalesDetailList, salesSlipReadWork, sqlConnection, sqlTransaction);
            return status;
        }


        /// <summary>
        /// 集計処理を行う
        /// </summary>
        /// <param name="paramSalesInfoWork">受信した売上情報</param>
        /// <param name="recvdSalesSlipWork">受信した売上データ</param>
        /// <param name="recvdSalesDetailList">受信した売上明細リスト</param>
        /// <param name="secSalesSlipWork">拠点売上データ</param>
        /// <param name="secSalesDetailList">拠点売上明細リスト</param>
        /// <param name="sqlConnection">DB接続</param>
        /// <param name="sqlTransaction">DBトランザクション</param>
        /// <returns>ステータス</returns>
        private int TotalizeProc(APSalesInfoWork paramSalesInfoWork, SalesSlipWork recvdSalesSlipWork, ArrayList recvdSalesDetailList,
            SalesSlipWork secSalesSlipWork, ArrayList secSalesDetailList, SqlConnection sqlConnection, SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // 集計用のパラメータを作成
            ArrayList newSlipList = new ArrayList(); // 受信した売上リスト
            ArrayList newItemList = new ArrayList();
            newSlipList.Add(newItemList);
            if (recvdSalesSlipWork.LogicalDeleteCode == 0)
                newItemList.Add(recvdSalesSlipWork);
            newItemList.Add(recvdSalesDetailList);

            ArrayList oldSlipList = new ArrayList(); // 拠点の売上リスト
            ArrayList oldItemList = new ArrayList();
            oldSlipList.Add(oldItemList);
            oldItemList.Add(secSalesSlipWork);
            oldItemList.Add(secSalesDetailList);

            // 集計リモートをコール
            status = MonthlyTtlSalesUpdDB.Write(GetMTtlSalesUpdParaWork(paramSalesInfoWork.SalesSlipWork), newSlipList, oldSlipList, sqlConnection, sqlTransaction);
            return status;
        }

        /// <summary>
        /// 売上月次集計データ更新パラメータを取得する
        /// </summary>
        /// <param name="paramSalesSlipWork">受信した売上データ</param>
        /// <returns>売上月次集計更新パラメータ</returns>
        private MTtlSalesUpdParaWork GetMTtlSalesUpdParaWork(APSalesSlipWork paramSalesSlipWork)
        {
            MTtlSalesUpdParaWork mTtlSalesUpdParaWork = new MTtlSalesUpdParaWork();
            mTtlSalesUpdParaWork.EnterpriseCode = paramSalesSlipWork.EnterpriseCode;  // 企業コード
            // TODO:拠点コード又は実績計上拠点コードを設定？
            mTtlSalesUpdParaWork.AddUpSecCode = paramSalesSlipWork.SectionCode;       // 計上拠点コード(拠点コード)
            mTtlSalesUpdParaWork.AddUpYearMonthSt = 0;                                // 計上年月(開始) 0:未指定
            mTtlSalesUpdParaWork.AddUpYearMonthEd = 0;                                // 計上年月(終了) 0:未指定
            if (0 == paramSalesSlipWork.LogicalDeleteCode)
                mTtlSalesUpdParaWork.SlipRegDiv = 1;                                  // 伝票登録区分 1:登録
            else
                mTtlSalesUpdParaWork.SlipRegDiv = 0;                                  // 伝票登録区分 0:削除
            mTtlSalesUpdParaWork.MTtlSalesPrcFlg = 1;                                 // 売上月次集計データ処理対象フラグ 1:対象
            mTtlSalesUpdParaWork.GoodsMTtlSaPrcFlg = 1;                               // 商品別売上月次集計データ処理対象フラグ 1:対象
            return mTtlSalesUpdParaWork;            
        }

        /// <summary>
        /// 売上検索条件ワークを取得
        /// </summary>
        /// <param name="paramSalesSlipWork">受信した売上データ</param>
        /// <returns>売上データ読み込みワーク</returns>
        private SalesSlipReadWork GetSalesSlipReadWork(APSalesSlipWork paramSalesSlipWork)
        {
            SalesSlipReadWork salesSlipReadWork = new SalesSlipReadWork();
            salesSlipReadWork.EnterpriseCode = paramSalesSlipWork.EnterpriseCode;
            salesSlipReadWork.AcptAnOdrStatus = paramSalesSlipWork.AcptAnOdrStatus;
            salesSlipReadWork.SalesSlipNum = paramSalesSlipWork.SalesSlipNum;
            return salesSlipReadWork;
        }

        /// <summary>
        /// 計上元明細かどうかを判断する
        /// </summary>
        /// <param name="paramSalesDetailWork">受信した売上明細データ</param>
        /// <param name="paramSalesDetailList">受信した売上明細データリスト</param>
        /// <returns>true : 計上元明細だ false:計上元明細でない</returns>
        private bool IsAddUpOrgData(APSalesDetailWork paramSalesDetailWork, ArrayList paramSalesDetailList)
        {
            bool isOrgFlg = false;
            for (int i = 0; i < paramSalesDetailList.Count; i++)
            {
                APSalesDetailWork salesDetailWork = (APSalesDetailWork)paramSalesDetailList[i];

                if (paramSalesDetailWork.AcptAnOdrStatus == salesDetailWork.AcptAnOdrStatusSrc
                    && paramSalesDetailWork.SalesSlipDtlNum == salesDetailWork.SalesSlipDtlNumSrc)
                {
                    isOrgFlg = true;
                    return isOrgFlg;
                }
            }
            return isOrgFlg;
        }

        /// <summary>
        /// 計上元明細かどうかを判断する
        /// </summary>
        /// <param name="paramSalesDetailWork">受信した売上明細データ</param>
        /// <param name="paramSalesDetailList">受信した売上明細データリスト</param>
        /// <param name="logicDeleteCode">論理削除フラグ</param>
        /// <returns>true : 計上元明細だ false:計上元明細でない</returns>
        private bool IsAddUpOrgData(APSalesDetailWork paramSalesDetailWork, ArrayList paramSalesDetailList, out int logicDeleteCode)
        {
            bool isOrgFlg = false;
            logicDeleteCode = 0;
            for (int i = 0; i < paramSalesDetailList.Count; i++)
            {
                APSalesDetailWork salesDetailWork = (APSalesDetailWork)paramSalesDetailList[i];

                if (paramSalesDetailWork.AcptAnOdrStatus == salesDetailWork.AcptAnOdrStatusSrc
                    && paramSalesDetailWork.SalesSlipDtlNum == salesDetailWork.SalesSlipDtlNumSrc)
                {
                    isOrgFlg = true;
                    logicDeleteCode = salesDetailWork.LogicalDeleteCode;
                    return isOrgFlg;
                }
            }
            return isOrgFlg;
        }

        /// <summary>
        /// 受信した売上情報を組み合わせる
        /// </summary>
        /// <param name="paramSalesSlipList">受信した売上データリスト</param>
        /// <param name="paramSalesDetailList">受信した売上明細データリスト</param>
        /// <returns>組み合わせの売上情報</returns>
        private List<APSalesInfoWork> GetAPSalesInfoList(ArrayList paramSalesSlipList, ArrayList paramSalesDetailList)
        {
            List<APSalesInfoWork> salesInfoList = new List<APSalesInfoWork>();

            if (null == paramSalesSlipList || null == paramSalesDetailList
                || paramSalesSlipList.Count == 0 || paramSalesDetailList.Count == 0)
                return salesInfoList;

            for (int i = 0; i < paramSalesSlipList.Count; i++)
            {
                // 売上情報ワークを作成
                APSalesInfoWork salesInfoWork = new APSalesInfoWork();

                APSalesSlipWork salesSlipWork = (APSalesSlipWork)paramSalesSlipList[i];
                // 売上データを追加
                salesInfoWork.SalesSlipWork = salesSlipWork;

                for (int j = 0; j < paramSalesDetailList.Count; j++)
                {
                    APSalesDetailWork salesDetailWork = (APSalesDetailWork)paramSalesDetailList[j];
                    if (salesSlipWork.EnterpriseCode == salesDetailWork.EnterpriseCode
                        && salesSlipWork.AcptAnOdrStatus == salesDetailWork.AcptAnOdrStatus
                        && salesSlipWork.SalesSlipNum == salesDetailWork.SalesSlipNum)
                        // 売上明細データを追加
                        salesInfoWork.SalesDetailWorkList.Add(salesDetailWork);
                }

                if (salesInfoWork.SalesDetailWorkList.Count > 0)
                    // 売上明細がない売上を対象外とする
                    salesInfoList.Add(salesInfoWork);
            }
            return salesInfoList;
        }

        /// <summary>
        /// 売上全体設定マスタを取得
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="dic">戻り値の売上全体設定マスタ</param>
        /// <returns>ステータス</returns>
        private int GetSalesTtlStWorkDic(string enterpriseCode, out Dictionary<string, SalesTtlStWork> dic)
        {
            dic = new Dictionary<string, SalesTtlStWork>();
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            object salesTtlStWorkList = null;
            SalesTtlStWork paraSalesTtlStWork = new SalesTtlStWork();
            paraSalesTtlStWork.EnterpriseCode = enterpriseCode;

            // 売上全体設定マスタのリモート
            status = new SalesTtlStDB().Search(out salesTtlStWorkList, (object)paraSalesTtlStWork, 0, ConstantManagement.LogicalMode.GetData0);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                return status;

            ArrayList retSalesTtlStWorkList = salesTtlStWorkList as ArrayList;
            foreach (SalesTtlStWork item in retSalesTtlStWorkList)
            {
                string key = item.SectionCode.Trim();
                if (dic.ContainsKey(key))
                    continue;
                dic[key] = item;
            }
            return status;
        }
        #endregion [プライベート方法]
    }
}

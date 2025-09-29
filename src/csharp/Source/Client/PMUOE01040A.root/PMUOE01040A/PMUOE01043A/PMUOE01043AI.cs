//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 売上明細アクセスクラス
// プログラム概要   : 売上明細アクセスを行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2008/05/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 作 成 日  2011/01/19  修正内容 : Mantis.16772 SCM項目が送信処理で売上データにセットされない件の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 作 成 日  2011/07/28  修正内容 : 自動回答区分追加対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 作 成 日  2012/01/16  修正内容 : SCM改良・特記事項対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/12/06  修正内容 : SCM障害№10447対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 売上明細アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 売上明細アクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 新規作成</br>
	/// </remarks>
    public partial class UoeSndRcvJnlAcs
	{
        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        # region Public Methods

        # region ●売上明細
        # region 売上明細作成＜データリスト→データーテーブル＞
        /// <summary>
        /// 売上明細＜データリスト→データーテーブル＞
        /// </summary>
        /// <param name="tbl">データテーブル</param>
        /// <param name="list">売上明細データリスト</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int ToDataTableFromSalesDetailWork(DataTable tbl, List<SalesDetailWork> list, out string message)
        {
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                tbl.Clear();

                foreach (SalesDetailWork rst in list)
                {
                    //送受信ＪＮＬの保存
                    DataRow dr = tbl.NewRow();
                    CreateSalesDetailSchema(ref dr, rst);
                    tbl.Rows.Add(dr);
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }

            return (status);
        }
        # endregion

        # region 売上明細更新＜ArrayList→データーテーブル＞
        /// <summary>
        /// 売上明細更新＜ArrayList→データーテーブル＞
        /// </summary>
        /// <param name="tbl">データテーブル</param>
        /// <param name="list">売上明細データリスト</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int UpdateTableFromSalesDetailList(DataTable tbl, ArrayList list, out string message)
        {
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                foreach (SalesDetailWork rst in list)
                {
                    status = UpdateTableFromSalesDetailWork(tbl, rst, out message);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }

            return (status);
        }
        # endregion

        # region 売上明細更新＜売上明細→データーテーブル＞
        /// <summary>
        /// 売上明細更新＜売上明細→データーテーブル＞
        /// </summary>
        /// <param name="tbl">データテーブル</param>
        /// <param name="salesDetailWork">売上明細</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int UpdateTableFromSalesDetailWork(DataTable tbl, SalesDetailWork salesDetailWork, out string message)
        {
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                //Findパラメータ設定
                object[] findSalesDetail = new object[2];
                findSalesDetail[0] = salesDetailWork.AcptAnOdrStatus;
                findSalesDetail[1] = salesDetailWork.DtlRelationGuid;

                DataRow salesDetailRow = tbl.Rows.Find(findSalesDetail);

                //売上明細更新の更新
                if (salesDetailRow != null)
                {
                    CreateSalesDetailSchema(ref salesDetailRow, salesDetailWork);
                }
                //売上明細更新の追加
                else
                {
                    DataRow dr = tbl.NewRow();
                    CreateSalesDetailSchema(ref dr, salesDetailWork);
                    tbl.Rows.Add(dr);
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }

            return (status);
        }
        # endregion

        # region 売上伝票番号（仮）の取得
        /// <summary>
        /// 売上伝票番号（仮）の取得
        /// </summary>
        /// <param name="tbl">データテーブル</param>
        /// <param name="salesDetailWork">売上明細</param>
        /// <returns>売上伝票番号（仮）</returns>
        public string GetTempSalesSlipNumFromSalesDetailWork(DataTable tbl, SalesDetailWork salesDetailWork)
        {
            //変数の初期化
            string tempSalesSlipNum = String.Empty;

            try
            {
                //Findパラメータ設定
                object[] findSalesDetail = new object[2];
                findSalesDetail[0] = salesDetailWork.AcptAnOdrStatus;
                findSalesDetail[1] = salesDetailWork.DtlRelationGuid;
                DataRow salesDetailRow = tbl.Rows.Find(findSalesDetail);

                tempSalesSlipNum = (string)salesDetailRow[SalesDetailSchema.ct_Col_TempSalesSlipNum];

            }
            catch (Exception)
            {
                tempSalesSlipNum = String.Empty;
            }

            return (tempSalesSlipNum);
        }
        # endregion

        # region 売上明細＜DataRow → クラス＞作成
        /// <summary>
        /// 売上明細＜DataRow → クラス＞作成
        /// </summary>
        /// <param name="dr">テーブルRow</param>
        /// <returns>売上明細</returns>
        public SalesDetailWork CreateSalesDetailWorkFromSchema(DataRow dr)
        {
            return(CreateSalesDetailWorkFromSchemaProc(dr));
        }

        # endregion

        # region 売上明細検索＜DataRow → ArrayList<SalesDetailWork>＞
        /// <summary>
        /// 売上明細検索＜DataRow → ArrayList<SalesDetailWork>＞
        /// </summary>
        /// <param name="tbl">データテーブル</param>
        /// <param name="acptAnOdrStatus">売上形式</param>
        /// <param name="tempSalesSlipNum">売上伝票番号</param>
        /// <param name="chkCount">0:全て 1:出荷数が１以上</param>
        /// <returns>売上明細</returns>
        public ArrayList SearchSalesDetailDataTable(DataTable tbl, Int32 acptAnOdrStatus, string tempSalesSlipNum, Int32 chkCount)
        {
            ArrayList returnSalesDetailAry = new ArrayList();
            try
            {
                DataView viewSalesDetail = SearchSalesDetailCreateView(tbl, acptAnOdrStatus, tempSalesSlipNum, chkCount);

                if (viewSalesDetail.Count > 0)
                {
                    foreach (DataRowView rowSalesDetail in viewSalesDetail)
                    {
                        SalesDetailWork salesDetailWork = CreateSalesDetailWorkFromSchema(rowSalesDetail.Row);
                        returnSalesDetailAry.Add(salesDetailWork);
                    }
                }
            }
            catch (Exception)
            {
                returnSalesDetailAry = null;
            }
            return (returnSalesDetailAry);
        }
        # endregion

        # region 売上明細に行番号を設定
        /// <summary>
        /// 売上明細に行番号を設定
        /// </summary>
        /// <param name="acptAnOdrStatus">売上形式</param>
        /// <param name="tempSalesSlipNum">売上伝票番号</param>
        /// <param name="chkCount">0:全て 1:出荷数が１以上</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int SetRowNoFromSalesDetail(Int32 acptAnOdrStatus, string tempSalesSlipNum, Int32 chkCount, out string message)
        {
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                DataView viewSalesDetail = SearchSalesDetailCreateView(SalesDetailTable, acptAnOdrStatus, tempSalesSlipNum, chkCount);
                status = SetRowNoFromSalesDetail(viewSalesDetail, out message);
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }

        /// <summary>
        /// 売上明細に行番号を設定
        /// </summary>
        /// <param name="viewSalesDetail">(DataView)売上明細</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int SetRowNoFromSalesDetail(DataView viewSalesDetail, out string message)
        {
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                if (viewSalesDetail == null) return (status);
                if (viewSalesDetail.Count == 0) return (status);

                Int32 salesRowNo = 0;
                foreach (DataRowView rowSalesDetail in viewSalesDetail)
                {
                    salesRowNo++;
                    rowSalesDetail[SalesDetailSchema.ct_Col_SalesRowNo] = salesRowNo;
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        # endregion

        # region 売上明細検索＜DataRow → List<UoeSalesDetail>＞
        /// <summary>
        /// 売上明細検索＜DataRow → List<SalesDetailWork>＞
        /// </summary>
        /// <param name="tbl">データテーブル</param>
        /// <param name="acptAnOdrStatus">売上形式</param>
        /// <param name="tempSalesSlipNum">売上伝票番号</param>
        /// <param name="chkCount">0:全て 1:出荷数が１以上</param>
        /// <returns>売上明細</returns>
        public List<UoeSalesDetail> SearchUoeSalesDetailDataTable(DataTable tbl, Int32 acptAnOdrStatus, string tempSalesSlipNum, Int32 chkCount)
        {
            List<UoeSalesDetail> uoeSalesDetailList = new List<UoeSalesDetail>();
            try
            {
                DataView viewSalesDetail = SearchSalesDetailCreateView(tbl, acptAnOdrStatus, tempSalesSlipNum, chkCount);

                if (viewSalesDetail.Count > 0)
                {
                    foreach (DataRowView rowSalesDetail in viewSalesDetail)
                    {
                        UoeSalesDetail uoeSalesDetail = new UoeSalesDetail();
                        uoeSalesDetail.salesDetailWork = CreateSalesDetailWorkFromSchemaProc(rowSalesDetail.Row);
                        uoeSalesDetail.prtSalesDetail = CreatePrtSalesDetailFromSchemaProc(rowSalesDetail.Row);
                         
                        uoeSalesDetailList.Add(uoeSalesDetail);
                    }
                }
            }
            catch (Exception)
            {
                uoeSalesDetailList = null;
            }
            return (uoeSalesDetailList);
        }
        # endregion

        # region 売上明細追加＜SalesDetailWork→AcptDetailTable＞
        /// <summary>
        /// 売上明細追加＜SalesDetailWork→AcptDetailTable＞
        /// </summary>
        /// <param name="salesDetailWork">売上明細</param>
        /// <param name="tempSalesSlipNum">売上伝票番号（仮）</param>
        /// <param name="tempSalesSlipDtlNum">売上明細通番（仮）</param>
        /// <param name="prtSalesDetail"></param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int InsertSalesDetailDataTable(SalesDetailWork salesDetailWork, string tempSalesSlipNum, Int64 tempSalesSlipDtlNum, PrtSalesDetail prtSalesDetail, out string message)
        {
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                DataRow dr = SalesDetailTable.NewRow();
                CreateSalesDetailSchema(ref dr, salesDetailWork, tempSalesSlipNum, tempSalesSlipDtlNum, prtSalesDetail);
                SalesDetailTable.Rows.Add(dr);
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        # endregion

        # endregion

        # region ●受注明細
        # region 受注明細リスト追加＜ArrayList→AcptDetailTable＞
        /// <summary>
        /// 受注明細リスト追加＜ArrayList→AcptDetailTable＞
        /// </summary>
        /// <param name="list">受注明細リスト</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int InsertAcptDtlTblFromSalesDetailAry(ArrayList list, out string message)
        {
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                foreach (SalesDetailWork salesDetailWork in list)
                {
                    status = InsertAcptDtlTblFromSalesDetailWork(salesDetailWork, out message);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }

            return (status);
        }
        # endregion

        # region 受注明細追加＜SalesDetailWork→AcptDetailTable＞
        /// <summary>
        /// 受注明細追加＜SalesDetailWork→AcptDetailTable＞
        /// </summary>
        /// <param name="salesDetailWork">受注明細</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int InsertAcptDtlTblFromSalesDetailWork(SalesDetailWork salesDetailWork, out string message)
        {
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                DataRow dr = AcptDetailTable.NewRow();
                CreateSalesDetailSchema(ref dr, salesDetailWork);
                AcptDetailTable.Rows.Add(dr);
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }

            return (status);
        }
        # endregion

        # region 受注明細ＲＥＡＤ
        /// <summary>
        /// 受注明細ＲＥＡＤ
        /// </summary>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="salesSlipDtlNum">売上明細通番</param>
        /// <returns>売上明細クラス</returns>
        public SalesDetailWork ReadSalesDetailDataTable(Int32 acptAnOdrStatus, Int64 salesSlipDtlNum)
        {
            SalesDetailWork salesDetail = null;

            try
            {
                object[] findSalesDetail = new object[2];
                findSalesDetail[0] = acptAnOdrStatus;
                findSalesDetail[1] = salesSlipDtlNum;
                DataRow salesDetailRow = AcptDetailTable.Rows.Find(findSalesDetail);
                salesDetail = CreateSalesDetailWorkFromSchemaProc(salesDetailRow);
            }
            catch (Exception)
            {
                salesDetail = null;
            }

            return (salesDetail);
        }
        # endregion
        # endregion

        # endregion

        // ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods
        # region 売上明細検索DataView作成
        /// <summary>
        /// 売上明細検索DataView作成
        /// </summary>
        /// <param name="tbl">データテーブル</param>
        /// <param name="acptAnOdrStatus">売上形式</param>
        /// <param name="tempSalesSlipNum">売上伝票番号</param>
        /// <param name="chkCount">0:全て 1:出荷数が１以上</param>
        /// <returns>売上明細検索DataView</returns>
        public DataView SearchSalesDetailCreateView(DataTable tbl, Int32 acptAnOdrStatus, string tempSalesSlipNum, int chkCount)
        {
            DataView viewSalesDetail = new DataView(tbl);
            try
            {
                string rowFilterText = String.Empty;


                if (chkCount != 0)
                {
                    rowFilterText = string.Format("{0} = {1} AND {2} = '{3}' AND {4} <> {5}",
                                                    SalesDetailSchema.ct_Col_AcptAnOdrStatus, acptAnOdrStatus,
                                                    SalesDetailSchema.ct_Col_TempSalesSlipNum, tempSalesSlipNum,
                                                    SalesDetailSchema.ct_Col_PrtShipmentCnt, 0);
                }
                else
                {
                    rowFilterText = string.Format("{0} = {1} AND {2} = '{3}'",
                                                    SalesDetailSchema.ct_Col_AcptAnOdrStatus, acptAnOdrStatus,
                                                    SalesDetailSchema.ct_Col_TempSalesSlipNum, tempSalesSlipNum);
                }

                string sortText = string.Format("{0}, {1}, {2}, {3}",
                    SalesDetailSchema.ct_Col_EnterpriseCode,
                    SalesDetailSchema.ct_Col_AcptAnOdrStatus,
                    SalesDetailSchema.ct_Col_TempSalesSlipNum,
                    SalesDetailSchema.ct_Col_TempSalesSlipDtlNum);

                viewSalesDetail.Sort = sortText;
                viewSalesDetail.RowFilter = rowFilterText;

            }
            catch (Exception)
            {
                viewSalesDetail = null;
            }
            return (viewSalesDetail);
        }
        # endregion

        # region 売上明細テーブルRow作成
        /// <summary>
        /// 売上明細テーブルRow作成
        /// </summary>
        /// <param name="dr">テーブルRow</param>
        /// <param name="rst">売上明細クラス</param>
        private void CreateSalesDetailSchema(ref DataRow dr, SalesDetailWork rst, string tempSalesSlipNum, Int64 tempSalesSlipDtlNum, PrtSalesDetail prtSalesDetail)
        {
            CreateSalesDetailSchema(ref dr, rst);

            dr[SalesDetailSchema.ct_Col_TempSalesSlipNum] = tempSalesSlipNum;	                        // 売上伝票番号（仮）
            dr[SalesDetailSchema.ct_Col_TempSalesSlipDtlNum] = tempSalesSlipDtlNum;	                    // 売上明細通番（仮）


            dr[SalesDetailSchema.ct_Col_PrtReceiveTime] = prtSalesDetail.prtReceiveTime;                    // (印刷用)受信時刻
            dr[SalesDetailSchema.ct_Col_PrtBoCode] = prtSalesDetail.prtBoCode;                              // (印刷用)BO区分
            dr[SalesDetailSchema.ct_Col_PrtUOEDeliGoodsDiv] = prtSalesDetail.prtUOEDeliGoodsDiv;            // (印刷用)UOE納品区分
            dr[SalesDetailSchema.ct_Col_PrtDeliveredGoodsDivNm] = prtSalesDetail.prtDeliveredGoodsDivNm;    // (印刷用)納品区分名称
            dr[SalesDetailSchema.ct_Col_PrtFollowDeliGoodsDiv] = prtSalesDetail.prtFollowDeliGoodsDiv;      // (印刷用)フォロー納品区分
            dr[SalesDetailSchema.ct_Col_PrtFollowDeliGoodsDivNm] = prtSalesDetail.prtFollowDeliGoodsDivNm;  // (印刷用)フォロー納品区分名称
            dr[SalesDetailSchema.ct_Col_PrtAcceptAnOrderCnt] = prtSalesDetail.prtAcceptAnOrderCnt;	        // (印刷用)受注数
            dr[SalesDetailSchema.ct_Col_PrtShipmentCnt] = prtSalesDetail.prtShipmentCnt;	                // (印刷用)出庫数
            dr[SalesDetailSchema.ct_Col_PrtUOESectOutGoodsCnt] = prtSalesDetail.prtUOESectOutGoodsCnt;	    // (印刷用)拠点出庫数
            dr[SalesDetailSchema.ct_Col_PrtBOShipmentCnt] = prtSalesDetail.prtBOShipmentCnt;	            // (印刷用)BO出庫数
            dr[SalesDetailSchema.ct_Col_DetailCd] = prtSalesDetail.detailCd;	                            // 明細種別
        }

        /// <summary>
        /// 売上明細テーブルRow作成
        /// </summary>
        /// <param name="dr">テーブルRow</param>
        /// <param name="rst">売上明細クラス</param>
        private void CreateSalesDetailSchema(ref DataRow dr, SalesDetailWork rst)
        {
            //dr[SalesDetailSchema.ct_Col_CreateDateTime] = rst.CreateDateTime;	// 作成日時
            //dr[SalesDetailSchema.ct_Col_UpdateDateTime] = rst.UpdateDateTime;	// 更新日時
            dr[SalesDetailSchema.ct_Col_EnterpriseCode] = rst.EnterpriseCode;	// 企業コード
            //dr[SalesDetailSchema.ct_Col_FileHeaderGuid] = rst.FileHeaderGuid;	// GUID
            //dr[SalesDetailSchema.ct_Col_UpdEmployeeCode] = rst.UpdEmployeeCode;	// 更新従業員コード
            //dr[SalesDetailSchema.ct_Col_UpdAssemblyId1] = rst.UpdAssemblyId1;	// 更新アセンブリID1
            //dr[SalesDetailSchema.ct_Col_UpdAssemblyId2] = rst.UpdAssemblyId2;	// 更新アセンブリID2
            dr[SalesDetailSchema.ct_Col_LogicalDeleteCode] = rst.LogicalDeleteCode;	// 論理削除区分
            dr[SalesDetailSchema.ct_Col_AcceptAnOrderNo] = rst.AcceptAnOrderNo;	// 受注番号
            dr[SalesDetailSchema.ct_Col_AcptAnOdrStatus] = rst.AcptAnOdrStatus;	// 受注ステータス
            dr[SalesDetailSchema.ct_Col_SalesSlipNum] = rst.SalesSlipNum;	// 売上伝票番号
            dr[SalesDetailSchema.ct_Col_SalesRowNo] = rst.SalesRowNo;	// 売上行番号
            dr[SalesDetailSchema.ct_Col_SalesRowDerivNo] = rst.SalesRowDerivNo;	// 売上行番号枝番
            dr[SalesDetailSchema.ct_Col_SectionCode] = rst.SectionCode;	// 拠点コード
            dr[SalesDetailSchema.ct_Col_SubSectionCode] = rst.SubSectionCode;	// 部門コード
            dr[SalesDetailSchema.ct_Col_SalesDate] = rst.SalesDate;	// 売上日付
            dr[SalesDetailSchema.ct_Col_CommonSeqNo] = rst.CommonSeqNo;	// 共通通番
            dr[SalesDetailSchema.ct_Col_SalesSlipDtlNum] = rst.SalesSlipDtlNum;	// 売上明細通番
            dr[SalesDetailSchema.ct_Col_AcptAnOdrStatusSrc] = rst.AcptAnOdrStatusSrc;	// 受注ステータス（元）
            dr[SalesDetailSchema.ct_Col_SalesSlipDtlNumSrc] = rst.SalesSlipDtlNumSrc;	// 売上明細通番（元）
            dr[SalesDetailSchema.ct_Col_SupplierFormalSync] = rst.SupplierFormalSync;	// 仕入形式（同時）
            dr[SalesDetailSchema.ct_Col_StockSlipDtlNumSync] = rst.StockSlipDtlNumSync;	// 仕入明細通番（同時）
            dr[SalesDetailSchema.ct_Col_SalesSlipCdDtl] = rst.SalesSlipCdDtl;	// 売上伝票区分（明細）
            dr[SalesDetailSchema.ct_Col_DeliGdsCmpltDueDate] = rst.DeliGdsCmpltDueDate;	// 納品完了予定日
            dr[SalesDetailSchema.ct_Col_GoodsKindCode] = rst.GoodsKindCode;	// 商品属性
            dr[SalesDetailSchema.ct_Col_GoodsSearchDivCd] = rst.GoodsSearchDivCd;	// 商品検索区分
            dr[SalesDetailSchema.ct_Col_GoodsMakerCd] = rst.GoodsMakerCd;	// 商品メーカーコード
            dr[SalesDetailSchema.ct_Col_MakerName] = rst.MakerName;	// メーカー名称
            dr[SalesDetailSchema.ct_Col_MakerKanaName] = rst.MakerKanaName;	// メーカーカナ名称
            dr[SalesDetailSchema.ct_Col_GoodsNo] = rst.GoodsNo;	// 商品番号
            dr[SalesDetailSchema.ct_Col_GoodsName] = rst.GoodsName;	// 商品名称
            dr[SalesDetailSchema.ct_Col_GoodsNameKana] = rst.GoodsNameKana;	// 商品名称カナ
            dr[SalesDetailSchema.ct_Col_GoodsLGroup] = rst.GoodsLGroup;	// 商品大分類コード
            dr[SalesDetailSchema.ct_Col_GoodsLGroupName] = rst.GoodsLGroupName;	// 商品大分類名称
            dr[SalesDetailSchema.ct_Col_GoodsMGroup] = rst.GoodsMGroup;	// 商品中分類コード
            dr[SalesDetailSchema.ct_Col_GoodsMGroupName] = rst.GoodsMGroupName;	// 商品中分類名称
            dr[SalesDetailSchema.ct_Col_BLGroupCode] = rst.BLGroupCode;	// BLグループコード
            dr[SalesDetailSchema.ct_Col_BLGroupName] = rst.BLGroupName;	// BLグループコード名称
            dr[SalesDetailSchema.ct_Col_BLGoodsCode] = rst.BLGoodsCode;	// BL商品コード
            dr[SalesDetailSchema.ct_Col_BLGoodsFullName] = rst.BLGoodsFullName;	// BL商品コード名称（全角）
            dr[SalesDetailSchema.ct_Col_EnterpriseGanreCode] = rst.EnterpriseGanreCode;	// 自社分類コード
            dr[SalesDetailSchema.ct_Col_EnterpriseGanreName] = rst.EnterpriseGanreName;	// 自社分類名称
            dr[SalesDetailSchema.ct_Col_WarehouseCode] = rst.WarehouseCode;	// 倉庫コード
            dr[SalesDetailSchema.ct_Col_WarehouseName] = rst.WarehouseName;	// 倉庫名称
            dr[SalesDetailSchema.ct_Col_WarehouseShelfNo] = rst.WarehouseShelfNo;	// 倉庫棚番
            dr[SalesDetailSchema.ct_Col_SalesOrderDivCd] = rst.SalesOrderDivCd;	// 売上在庫取寄せ区分
            dr[SalesDetailSchema.ct_Col_OpenPriceDiv] = rst.OpenPriceDiv;	// オープン価格区分
            dr[SalesDetailSchema.ct_Col_GoodsRateRank] = rst.GoodsRateRank;	// 商品掛率ランク
            dr[SalesDetailSchema.ct_Col_CustRateGrpCode] = rst.CustRateGrpCode;	// 得意先掛率グループコード
            dr[SalesDetailSchema.ct_Col_ListPriceRate] = rst.ListPriceRate;	// 定価率
            dr[SalesDetailSchema.ct_Col_RateSectPriceUnPrc] = rst.RateSectPriceUnPrc;	// 掛率設定拠点（定価）
            dr[SalesDetailSchema.ct_Col_RateDivLPrice] = rst.RateDivLPrice;	// 掛率設定区分（定価）
            dr[SalesDetailSchema.ct_Col_UnPrcCalcCdLPrice] = rst.UnPrcCalcCdLPrice;	// 単価算出区分（定価）
            dr[SalesDetailSchema.ct_Col_PriceCdLPrice] = rst.PriceCdLPrice;	// 価格区分（定価）
            dr[SalesDetailSchema.ct_Col_StdUnPrcLPrice] = rst.StdUnPrcLPrice;	// 基準単価（定価）
            dr[SalesDetailSchema.ct_Col_FracProcUnitLPrice] = rst.FracProcUnitLPrice;	// 端数処理単位（定価）
            dr[SalesDetailSchema.ct_Col_FracProcLPrice] = rst.FracProcLPrice;	// 端数処理（定価）
            dr[SalesDetailSchema.ct_Col_ListPriceTaxIncFl] = rst.ListPriceTaxIncFl;	// 定価（税込，浮動）
            dr[SalesDetailSchema.ct_Col_ListPriceTaxExcFl] = rst.ListPriceTaxExcFl;	// 定価（税抜，浮動）
            dr[SalesDetailSchema.ct_Col_ListPriceChngCd] = rst.ListPriceChngCd;	// 定価変更区分
            dr[SalesDetailSchema.ct_Col_SalesRate] = rst.SalesRate;	// 売価率
            dr[SalesDetailSchema.ct_Col_RateSectSalUnPrc] = rst.RateSectSalUnPrc;	// 掛率設定拠点（売上単価）
            dr[SalesDetailSchema.ct_Col_RateDivSalUnPrc] = rst.RateDivSalUnPrc;	// 掛率設定区分（売上単価）
            dr[SalesDetailSchema.ct_Col_UnPrcCalcCdSalUnPrc] = rst.UnPrcCalcCdSalUnPrc;	// 単価算出区分（売上単価）
            dr[SalesDetailSchema.ct_Col_PriceCdSalUnPrc] = rst.PriceCdSalUnPrc;	// 価格区分（売上単価）
            dr[SalesDetailSchema.ct_Col_StdUnPrcSalUnPrc] = rst.StdUnPrcSalUnPrc;	// 基準単価（売上単価）
            dr[SalesDetailSchema.ct_Col_FracProcUnitSalUnPrc] = rst.FracProcUnitSalUnPrc;	// 端数処理単位（売上単価）
            dr[SalesDetailSchema.ct_Col_FracProcSalUnPrc] = rst.FracProcSalUnPrc;	// 端数処理（売上単価）
            dr[SalesDetailSchema.ct_Col_SalesUnPrcTaxIncFl] = rst.SalesUnPrcTaxIncFl;	// 売上単価（税込，浮動）
            dr[SalesDetailSchema.ct_Col_SalesUnPrcTaxExcFl] = rst.SalesUnPrcTaxExcFl;	// 売上単価（税抜，浮動）
            dr[SalesDetailSchema.ct_Col_SalesUnPrcChngCd] = rst.SalesUnPrcChngCd;	// 売上単価変更区分
            dr[SalesDetailSchema.ct_Col_CostRate] = rst.CostRate;	// 原価率
            dr[SalesDetailSchema.ct_Col_RateSectCstUnPrc] = rst.RateSectCstUnPrc;	// 掛率設定拠点（原価単価）
            dr[SalesDetailSchema.ct_Col_RateDivUnCst] = rst.RateDivUnCst;	// 掛率設定区分（原価単価）
            dr[SalesDetailSchema.ct_Col_UnPrcCalcCdUnCst] = rst.UnPrcCalcCdUnCst;	// 単価算出区分（原価単価）
            dr[SalesDetailSchema.ct_Col_PriceCdUnCst] = rst.PriceCdUnCst;	// 価格区分（原価単価）
            dr[SalesDetailSchema.ct_Col_StdUnPrcUnCst] = rst.StdUnPrcUnCst;	// 基準単価（原価単価）
            dr[SalesDetailSchema.ct_Col_FracProcUnitUnCst] = rst.FracProcUnitUnCst;	// 端数処理単位（原価単価）
            dr[SalesDetailSchema.ct_Col_FracProcUnCst] = rst.FracProcUnCst;	// 端数処理（原価単価）
            dr[SalesDetailSchema.ct_Col_SalesUnitCost] = rst.SalesUnitCost;	// 原価単価
            dr[SalesDetailSchema.ct_Col_SalesUnitCostChngDiv] = rst.SalesUnitCostChngDiv;	// 原価単価変更区分
            dr[SalesDetailSchema.ct_Col_RateBLGoodsCode] = rst.RateBLGoodsCode;	// BL商品コード（掛率）
            dr[SalesDetailSchema.ct_Col_RateBLGoodsName] = rst.RateBLGoodsName;	// BL商品コード名称（掛率）
            dr[SalesDetailSchema.ct_Col_RateGoodsRateGrpCd] = rst.RateGoodsRateGrpCd;	// 商品掛率グループコード（掛率）
            dr[SalesDetailSchema.ct_Col_RateGoodsRateGrpNm] = rst.RateGoodsRateGrpNm;	// 商品掛率グループ名称（掛率）
            dr[SalesDetailSchema.ct_Col_RateBLGroupCode] = rst.RateBLGroupCode;	// BLグループコード（掛率）
            dr[SalesDetailSchema.ct_Col_RateBLGroupName] = rst.RateBLGroupName;	// BLグループ名称（掛率）
            dr[SalesDetailSchema.ct_Col_PrtBLGoodsCode] = rst.PrtBLGoodsCode;	// BL商品コード（印刷）
            dr[SalesDetailSchema.ct_Col_PrtBLGoodsName] = rst.PrtBLGoodsName;	// BL商品コード名称（印刷）
            dr[SalesDetailSchema.ct_Col_SalesCode] = rst.SalesCode;	// 販売区分コード
            dr[SalesDetailSchema.ct_Col_SalesCdNm] = rst.SalesCdNm;	// 販売区分名称
            dr[SalesDetailSchema.ct_Col_WorkManHour] = rst.WorkManHour;	// 作業工数
            dr[SalesDetailSchema.ct_Col_ShipmentCnt] = rst.ShipmentCnt;	// 出荷数
            dr[SalesDetailSchema.ct_Col_AcceptAnOrderCnt] = rst.AcceptAnOrderCnt;	// 受注数量
            dr[SalesDetailSchema.ct_Col_AcptAnOdrAdjustCnt] = rst.AcptAnOdrAdjustCnt;	// 受注調整数
            dr[SalesDetailSchema.ct_Col_AcptAnOdrRemainCnt] = rst.AcptAnOdrRemainCnt;	// 受注残数
            dr[SalesDetailSchema.ct_Col_RemainCntUpdDate] = rst.RemainCntUpdDate;	// 残数更新日
            dr[SalesDetailSchema.ct_Col_SalesMoneyTaxInc] = rst.SalesMoneyTaxInc;	// 売上金額（税込み）
            dr[SalesDetailSchema.ct_Col_SalesMoneyTaxExc] = rst.SalesMoneyTaxExc;	// 売上金額（税抜き）
            dr[SalesDetailSchema.ct_Col_Cost] = rst.Cost;	// 原価
            dr[SalesDetailSchema.ct_Col_GrsProfitChkDiv] = rst.GrsProfitChkDiv;	// 粗利チェック区分
            dr[SalesDetailSchema.ct_Col_SalesGoodsCd] = rst.SalesGoodsCd;	// 売上商品区分
            dr[SalesDetailSchema.ct_Col_SalesPriceConsTax] = rst.SalesPriceConsTax;	// 売上金額消費税額
            dr[SalesDetailSchema.ct_Col_TaxationDivCd] = rst.TaxationDivCd;	// 課税区分
            dr[SalesDetailSchema.ct_Col_PartySlipNumDtl] = rst.PartySlipNumDtl;	// 相手先伝票番号（明細）
            dr[SalesDetailSchema.ct_Col_DtlNote] = rst.DtlNote;	// 明細備考
            dr[SalesDetailSchema.ct_Col_SupplierCd] = rst.SupplierCd;	// 仕入先コード
            dr[SalesDetailSchema.ct_Col_SupplierSnm] = rst.SupplierSnm;	// 仕入先略称
            dr[SalesDetailSchema.ct_Col_OrderNumber] = rst.OrderNumber;	// 発注番号
            dr[SalesDetailSchema.ct_Col_WayToOrder] = rst.WayToOrder;	// 注文方法
            dr[SalesDetailSchema.ct_Col_SlipMemo1] = rst.SlipMemo1;	// 伝票メモ１
            dr[SalesDetailSchema.ct_Col_SlipMemo2] = rst.SlipMemo2;	// 伝票メモ２
            dr[SalesDetailSchema.ct_Col_SlipMemo3] = rst.SlipMemo3;	// 伝票メモ３
            dr[SalesDetailSchema.ct_Col_InsideMemo1] = rst.InsideMemo1;	// 社内メモ１
            dr[SalesDetailSchema.ct_Col_InsideMemo2] = rst.InsideMemo2;	// 社内メモ２
            dr[SalesDetailSchema.ct_Col_InsideMemo3] = rst.InsideMemo3;	// 社内メモ３
            dr[SalesDetailSchema.ct_Col_BfListPrice] = rst.BfListPrice;	// 変更前定価
            dr[SalesDetailSchema.ct_Col_BfSalesUnitPrice] = rst.BfSalesUnitPrice;	// 変更前売価
            dr[SalesDetailSchema.ct_Col_BfUnitCost] = rst.BfUnitCost;	// 変更前原価
            dr[SalesDetailSchema.ct_Col_CmpltSalesRowNo] = rst.CmpltSalesRowNo;	// 一式明細番号
            dr[SalesDetailSchema.ct_Col_CmpltGoodsMakerCd] = rst.CmpltGoodsMakerCd;	// メーカーコード（一式）
            dr[SalesDetailSchema.ct_Col_CmpltMakerName] = rst.CmpltMakerName;	// メーカー名称（一式）
            dr[SalesDetailSchema.ct_Col_CmpltMakerKanaName] = rst.CmpltMakerKanaName;	// メーカーカナ名称（一式）
            dr[SalesDetailSchema.ct_Col_CmpltGoodsName] = rst.CmpltGoodsName;	// 商品名称（一式）
            dr[SalesDetailSchema.ct_Col_CmpltShipmentCnt] = rst.CmpltShipmentCnt;	// 数量（一式）
            dr[SalesDetailSchema.ct_Col_CmpltSalesUnPrcFl] = rst.CmpltSalesUnPrcFl;	// 売上単価（一式）
            dr[SalesDetailSchema.ct_Col_CmpltSalesMoney] = rst.CmpltSalesMoney;	// 売上金額（一式）
            dr[SalesDetailSchema.ct_Col_CmpltSalesUnitCost] = rst.CmpltSalesUnitCost;	// 原価単価（一式）
            dr[SalesDetailSchema.ct_Col_CmpltCost] = rst.CmpltCost;	// 原価金額（一式）
            dr[SalesDetailSchema.ct_Col_CmpltPartySalSlNum] = rst.CmpltPartySalSlNum;	// 相手先伝票番号（一式）
            dr[SalesDetailSchema.ct_Col_CmpltNote] = rst.CmpltNote;	// 一式備考
            dr[SalesDetailSchema.ct_Col_PrtGoodsNo] = rst.PrtGoodsNo;	// 印刷用品番
            dr[SalesDetailSchema.ct_Col_PrtMakerCode] = rst.PrtMakerCode;	// 印刷用メーカーコード
            dr[SalesDetailSchema.ct_Col_PrtMakerName] = rst.PrtMakerName;	// 印刷用メーカー名称
            dr[SalesDetailSchema.ct_Col_ShipmCntDifference] = rst.ShipmCntDifference;	// 出荷差分数
            dr[SalesDetailSchema.ct_Col_DtlRelationGuid] = rst.DtlRelationGuid;	// 明細関連付けGUID

            // 2011/01/19 Add >>>
            dr[SalesDetailSchema.ct_Col_CampaignCode] = rst.CampaignCode;   // キャンペーンコード
            dr[SalesDetailSchema.ct_Col_CampaignName] = rst.CampaignName;   // キャンペーン名称
            dr[SalesDetailSchema.ct_Col_GoodsDivCd] = rst.GoodsDivCd;   // 商品種別
            dr[SalesDetailSchema.ct_Col_AnswerDelivDate] = rst.AnswerDelivDate; // 回答納期
            dr[SalesDetailSchema.ct_Col_RecycleDiv] = rst.RecycleDiv;   // リサイクル区分
            dr[SalesDetailSchema.ct_Col_RecycleDivNm] = rst.RecycleDivNm;   // リサイクル区分名称
            dr[SalesDetailSchema.ct_Col_WayToAcptOdr] = rst.WayToAcptOdr;   // 受注方法
            // 2011/01/19 Add <<<
            dr[SalesDetailSchema.ct_Col_AutoAnswerDivSCM] = rst.AutoAnswerDivSCM;   // 自動回答区分//add 2011/07/28

            // 2012/01/16 Add >>>
            dr[SalesDetailSchema.ct_Col_GoodsSpecialNote] = rst.GoodsSpecialNote;
            // 2012/01/16 Add <<<

            // ADD 2012/12/06 2012/12/12配信予定 SCM障害№10447対応 ----------------------------------->>>>>
            dr[SalesDetailSchema.ct_Col_AcceptOrOrderKind] = rst.AcceptOrOrderKind;
            // ADD 2012/12/06 2012/12/12配信予定 SCM障害№10447対応 -----------------------------------<<<<<

        }
        # endregion

        # region (印刷用)UOE売上明細クラスの取得＜DataRow → クラス＞作成
        /// <summary>
        /// (印刷用)UOE売上明細クラスの取得＜DataRow → クラス＞作成
        /// </summary>
        /// <param name="dr">テーブル</param>
        /// <returns>売上明細(印刷)</returns>
        private PrtSalesDetail CreatePrtSalesDetailFromSchemaProc(DataRow dr)
        {
            PrtSalesDetail rst = new PrtSalesDetail();

            try
            {
                rst.prtReceiveTime = (Int32)dr[SalesDetailSchema.ct_Col_PrtReceiveTime];                    //(印刷用)受信時刻
                rst.prtBoCode = (string)dr[SalesDetailSchema.ct_Col_PrtBoCode];                             //(印刷用)BO区分
                rst.prtUOEDeliGoodsDiv = (string)dr[SalesDetailSchema.ct_Col_PrtUOEDeliGoodsDiv];           //(印刷用)UOE納品区分
                rst.prtDeliveredGoodsDivNm = (string)dr[SalesDetailSchema.ct_Col_PrtDeliveredGoodsDivNm];   //(印刷用)納品区分名称
                rst.prtFollowDeliGoodsDiv = (string)dr[SalesDetailSchema.ct_Col_PrtFollowDeliGoodsDiv];     //(印刷用)フォロー納品区分
                rst.prtFollowDeliGoodsDivNm = (string)dr[SalesDetailSchema.ct_Col_PrtFollowDeliGoodsDivNm]; //(印刷用)フォロー納品区分名称
                rst.prtAcceptAnOrderCnt = (double)dr[SalesDetailSchema.ct_Col_PrtAcceptAnOrderCnt];         //(印刷用)受注数
                rst.prtShipmentCnt = (Int32)dr[SalesDetailSchema.ct_Col_PrtShipmentCnt];                    //(印刷用)出庫数
                rst.prtUOESectOutGoodsCnt = (Int32)dr[SalesDetailSchema.ct_Col_PrtUOESectOutGoodsCnt];      //(印刷用)拠点出庫数
                rst.prtBOShipmentCnt = (Int32)dr[SalesDetailSchema.ct_Col_PrtBOShipmentCnt];                //(印刷用)BO出庫数
                rst.detailCd = (Int32)dr[SalesDetailSchema.ct_Col_DetailCd];                                //明細種別
            }
            catch (Exception)
            {
                rst = null;
            }
            return (rst);
        }
        # endregion

        # region 売上明細＜DataRow → クラス＞作成
        /// <summary>
        /// 売上明細＜DataRow → クラス＞作成
        /// </summary>
        /// <param name="dr">テーブルRow</param>
        /// <returns>売上明細</returns>
        private SalesDetailWork CreateSalesDetailWorkFromSchemaProc(DataRow dr)
        {
            SalesDetailWork rst = new SalesDetailWork();

            try
            {
                //rst.CreateDateTime = (Int64)dr[SalesDetailSchema.ct_Col_CreateDateTime];	// 作成日時
                //rst.UpdateDateTime = (Int64)dr[SalesDetailSchema.ct_Col_UpdateDateTime];	// 更新日時
                rst.EnterpriseCode = (string)dr[SalesDetailSchema.ct_Col_EnterpriseCode];	// 企業コード
                rst.FileHeaderGuid = (Guid)dr[SalesDetailSchema.ct_Col_FileHeaderGuid];	// GUID
                rst.UpdEmployeeCode = (string)dr[SalesDetailSchema.ct_Col_UpdEmployeeCode];	// 更新従業員コード
                rst.UpdAssemblyId1 = (string)dr[SalesDetailSchema.ct_Col_UpdAssemblyId1];	// 更新アセンブリID1
                rst.UpdAssemblyId2 = (string)dr[SalesDetailSchema.ct_Col_UpdAssemblyId2];	// 更新アセンブリID2
                rst.LogicalDeleteCode = (Int32)dr[SalesDetailSchema.ct_Col_LogicalDeleteCode];	// 論理削除区分
                rst.AcceptAnOrderNo = (Int32)dr[SalesDetailSchema.ct_Col_AcceptAnOrderNo];	// 受注番号
                rst.AcptAnOdrStatus = (Int32)dr[SalesDetailSchema.ct_Col_AcptAnOdrStatus];	// 受注ステータス
                rst.SalesSlipNum = (string)dr[SalesDetailSchema.ct_Col_SalesSlipNum];	// 売上伝票番号
                rst.SalesRowNo = (Int32)dr[SalesDetailSchema.ct_Col_SalesRowNo];	// 売上行番号
                rst.SalesRowDerivNo = (Int32)dr[SalesDetailSchema.ct_Col_SalesRowDerivNo];	// 売上行番号枝番
                rst.SectionCode = (string)dr[SalesDetailSchema.ct_Col_SectionCode];	// 拠点コード
                rst.SubSectionCode = (Int32)dr[SalesDetailSchema.ct_Col_SubSectionCode];	// 部門コード
                rst.SalesDate = (DateTime)dr[SalesDetailSchema.ct_Col_SalesDate];	// 売上日付
                rst.CommonSeqNo = (Int64)dr[SalesDetailSchema.ct_Col_CommonSeqNo];	// 共通通番
                rst.SalesSlipDtlNum = (Int64)dr[SalesDetailSchema.ct_Col_SalesSlipDtlNum];	// 売上明細通番
                rst.AcptAnOdrStatusSrc = (Int32)dr[SalesDetailSchema.ct_Col_AcptAnOdrStatusSrc];	// 受注ステータス（元）
                rst.SalesSlipDtlNumSrc = (Int64)dr[SalesDetailSchema.ct_Col_SalesSlipDtlNumSrc];	// 売上明細通番（元）
                rst.SupplierFormalSync = (Int32)dr[SalesDetailSchema.ct_Col_SupplierFormalSync];	// 仕入形式（同時）
                rst.StockSlipDtlNumSync = (Int64)dr[SalesDetailSchema.ct_Col_StockSlipDtlNumSync];	// 仕入明細通番（同時）
                rst.SalesSlipCdDtl = (Int32)dr[SalesDetailSchema.ct_Col_SalesSlipCdDtl];	// 売上伝票区分（明細）
                rst.DeliGdsCmpltDueDate = (DateTime)dr[SalesDetailSchema.ct_Col_DeliGdsCmpltDueDate];	// 納品完了予定日
                rst.GoodsKindCode = (Int32)dr[SalesDetailSchema.ct_Col_GoodsKindCode];	// 商品属性
                rst.GoodsSearchDivCd = (Int32)dr[SalesDetailSchema.ct_Col_GoodsSearchDivCd];	// 商品検索区分
                rst.GoodsMakerCd = (Int32)dr[SalesDetailSchema.ct_Col_GoodsMakerCd];	// 商品メーカーコード
                rst.MakerName = (string)dr[SalesDetailSchema.ct_Col_MakerName];	// メーカー名称
                rst.MakerKanaName = (string)dr[SalesDetailSchema.ct_Col_MakerKanaName];	// メーカーカナ名称
                rst.GoodsNo = (string)dr[SalesDetailSchema.ct_Col_GoodsNo];	// 商品番号
                rst.GoodsName = (string)dr[SalesDetailSchema.ct_Col_GoodsName];	// 商品名称
                rst.GoodsNameKana = (string)dr[SalesDetailSchema.ct_Col_GoodsNameKana];	// 商品名称カナ
                rst.GoodsLGroup = (Int32)dr[SalesDetailSchema.ct_Col_GoodsLGroup];	// 商品大分類コード
                rst.GoodsLGroupName = (string)dr[SalesDetailSchema.ct_Col_GoodsLGroupName];	// 商品大分類名称
                rst.GoodsMGroup = (Int32)dr[SalesDetailSchema.ct_Col_GoodsMGroup];	// 商品中分類コード
                rst.GoodsMGroupName = (string)dr[SalesDetailSchema.ct_Col_GoodsMGroupName];	// 商品中分類名称
                rst.BLGroupCode = (Int32)dr[SalesDetailSchema.ct_Col_BLGroupCode];	// BLグループコード
                rst.BLGroupName = (string)dr[SalesDetailSchema.ct_Col_BLGroupName];	// BLグループコード名称
                rst.BLGoodsCode = (Int32)dr[SalesDetailSchema.ct_Col_BLGoodsCode];	// BL商品コード
                rst.BLGoodsFullName = (string)dr[SalesDetailSchema.ct_Col_BLGoodsFullName];	// BL商品コード名称（全角）
                rst.EnterpriseGanreCode = (Int32)dr[SalesDetailSchema.ct_Col_EnterpriseGanreCode];	// 自社分類コード
                rst.EnterpriseGanreName = (string)dr[SalesDetailSchema.ct_Col_EnterpriseGanreName];	// 自社分類名称
                rst.WarehouseCode = (string)dr[SalesDetailSchema.ct_Col_WarehouseCode];	// 倉庫コード
                rst.WarehouseName = (string)dr[SalesDetailSchema.ct_Col_WarehouseName];	// 倉庫名称
                rst.WarehouseShelfNo = (string)dr[SalesDetailSchema.ct_Col_WarehouseShelfNo];	// 倉庫棚番
                rst.SalesOrderDivCd = (Int32)dr[SalesDetailSchema.ct_Col_SalesOrderDivCd];	// 売上在庫取寄せ区分
                rst.OpenPriceDiv = (Int32)dr[SalesDetailSchema.ct_Col_OpenPriceDiv];	// オープン価格区分
                rst.GoodsRateRank = (string)dr[SalesDetailSchema.ct_Col_GoodsRateRank];	// 商品掛率ランク
                rst.CustRateGrpCode = (Int32)dr[SalesDetailSchema.ct_Col_CustRateGrpCode];	// 得意先掛率グループコード
                rst.ListPriceRate = (Double)dr[SalesDetailSchema.ct_Col_ListPriceRate];	// 定価率
                rst.RateSectPriceUnPrc = (string)dr[SalesDetailSchema.ct_Col_RateSectPriceUnPrc];	// 掛率設定拠点（定価）
                rst.RateDivLPrice = (string)dr[SalesDetailSchema.ct_Col_RateDivLPrice];	// 掛率設定区分（定価）
                rst.UnPrcCalcCdLPrice = (Int32)dr[SalesDetailSchema.ct_Col_UnPrcCalcCdLPrice];	// 単価算出区分（定価）
                rst.PriceCdLPrice = (Int32)dr[SalesDetailSchema.ct_Col_PriceCdLPrice];	// 価格区分（定価）
                rst.StdUnPrcLPrice = (Double)dr[SalesDetailSchema.ct_Col_StdUnPrcLPrice];	// 基準単価（定価）
                rst.FracProcUnitLPrice = (Double)dr[SalesDetailSchema.ct_Col_FracProcUnitLPrice];	// 端数処理単位（定価）
                rst.FracProcLPrice = (Int32)dr[SalesDetailSchema.ct_Col_FracProcLPrice];	// 端数処理（定価）
                rst.ListPriceTaxIncFl = (Double)dr[SalesDetailSchema.ct_Col_ListPriceTaxIncFl];	// 定価（税込，浮動）
                rst.ListPriceTaxExcFl = (Double)dr[SalesDetailSchema.ct_Col_ListPriceTaxExcFl];	// 定価（税抜，浮動）
                rst.ListPriceChngCd = (Int32)dr[SalesDetailSchema.ct_Col_ListPriceChngCd];	// 定価変更区分
                rst.SalesRate = (Double)dr[SalesDetailSchema.ct_Col_SalesRate];	// 売価率
                rst.RateSectSalUnPrc = (string)dr[SalesDetailSchema.ct_Col_RateSectSalUnPrc];	// 掛率設定拠点（売上単価）
                rst.RateDivSalUnPrc = (string)dr[SalesDetailSchema.ct_Col_RateDivSalUnPrc];	// 掛率設定区分（売上単価）
                rst.UnPrcCalcCdSalUnPrc = (Int32)dr[SalesDetailSchema.ct_Col_UnPrcCalcCdSalUnPrc];	// 単価算出区分（売上単価）
                rst.PriceCdSalUnPrc = (Int32)dr[SalesDetailSchema.ct_Col_PriceCdSalUnPrc];	// 価格区分（売上単価）
                rst.StdUnPrcSalUnPrc = (Double)dr[SalesDetailSchema.ct_Col_StdUnPrcSalUnPrc];	// 基準単価（売上単価）
                rst.FracProcUnitSalUnPrc = (Double)dr[SalesDetailSchema.ct_Col_FracProcUnitSalUnPrc];	// 端数処理単位（売上単価）
                rst.FracProcSalUnPrc = (Int32)dr[SalesDetailSchema.ct_Col_FracProcSalUnPrc];	// 端数処理（売上単価）
                rst.SalesUnPrcTaxIncFl = (Double)dr[SalesDetailSchema.ct_Col_SalesUnPrcTaxIncFl];	// 売上単価（税込，浮動）
                rst.SalesUnPrcTaxExcFl = (Double)dr[SalesDetailSchema.ct_Col_SalesUnPrcTaxExcFl];	// 売上単価（税抜，浮動）
                rst.SalesUnPrcChngCd = (Int32)dr[SalesDetailSchema.ct_Col_SalesUnPrcChngCd];	// 売上単価変更区分
                rst.CostRate = (Double)dr[SalesDetailSchema.ct_Col_CostRate];	// 原価率
                rst.RateSectCstUnPrc = (string)dr[SalesDetailSchema.ct_Col_RateSectCstUnPrc];	// 掛率設定拠点（原価単価）
                rst.RateDivUnCst = (string)dr[SalesDetailSchema.ct_Col_RateDivUnCst];	// 掛率設定区分（原価単価）
                rst.UnPrcCalcCdUnCst = (Int32)dr[SalesDetailSchema.ct_Col_UnPrcCalcCdUnCst];	// 単価算出区分（原価単価）
                rst.PriceCdUnCst = (Int32)dr[SalesDetailSchema.ct_Col_PriceCdUnCst];	// 価格区分（原価単価）
                rst.StdUnPrcUnCst = (Double)dr[SalesDetailSchema.ct_Col_StdUnPrcUnCst];	// 基準単価（原価単価）
                rst.FracProcUnitUnCst = (Double)dr[SalesDetailSchema.ct_Col_FracProcUnitUnCst];	// 端数処理単位（原価単価）
                rst.FracProcUnCst = (Int32)dr[SalesDetailSchema.ct_Col_FracProcUnCst];	// 端数処理（原価単価）
                rst.SalesUnitCost = (Double)dr[SalesDetailSchema.ct_Col_SalesUnitCost];	// 原価単価
                rst.SalesUnitCostChngDiv = (Int32)dr[SalesDetailSchema.ct_Col_SalesUnitCostChngDiv];	// 原価単価変更区分
                rst.RateBLGoodsCode = (Int32)dr[SalesDetailSchema.ct_Col_RateBLGoodsCode];	// BL商品コード（掛率）
                rst.RateBLGoodsName = (string)dr[SalesDetailSchema.ct_Col_RateBLGoodsName];	// BL商品コード名称（掛率）
                rst.RateGoodsRateGrpCd = (Int32)dr[SalesDetailSchema.ct_Col_RateGoodsRateGrpCd];	// 商品掛率グループコード（掛率）
                rst.RateGoodsRateGrpNm = (string)dr[SalesDetailSchema.ct_Col_RateGoodsRateGrpNm];	// 商品掛率グループ名称（掛率）
                rst.RateBLGroupCode = (Int32)dr[SalesDetailSchema.ct_Col_RateBLGroupCode];	// BLグループコード（掛率）
                rst.RateBLGroupName = (string)dr[SalesDetailSchema.ct_Col_RateBLGroupName];	// BLグループ名称（掛率）
                rst.PrtBLGoodsCode = (Int32)dr[SalesDetailSchema.ct_Col_PrtBLGoodsCode];	// BL商品コード（印刷）
                rst.PrtBLGoodsName = (string)dr[SalesDetailSchema.ct_Col_PrtBLGoodsName];	// BL商品コード名称（印刷）
                rst.SalesCode = (Int32)dr[SalesDetailSchema.ct_Col_SalesCode];	// 販売区分コード
                rst.SalesCdNm = (string)dr[SalesDetailSchema.ct_Col_SalesCdNm];	// 販売区分名称
                rst.WorkManHour = (Double)dr[SalesDetailSchema.ct_Col_WorkManHour];	// 作業工数
                rst.ShipmentCnt = (Double)dr[SalesDetailSchema.ct_Col_ShipmentCnt];	// 出荷数
                rst.AcceptAnOrderCnt = (Double)dr[SalesDetailSchema.ct_Col_AcceptAnOrderCnt];	// 受注数量
                rst.AcptAnOdrAdjustCnt = (Double)dr[SalesDetailSchema.ct_Col_AcptAnOdrAdjustCnt];	// 受注調整数
                rst.AcptAnOdrRemainCnt = (Double)dr[SalesDetailSchema.ct_Col_AcptAnOdrRemainCnt];	// 受注残数
                rst.RemainCntUpdDate = (DateTime)dr[SalesDetailSchema.ct_Col_RemainCntUpdDate];	// 残数更新日
                rst.SalesMoneyTaxInc = (Int64)dr[SalesDetailSchema.ct_Col_SalesMoneyTaxInc];	// 売上金額（税込み）
                rst.SalesMoneyTaxExc = (Int64)dr[SalesDetailSchema.ct_Col_SalesMoneyTaxExc];	// 売上金額（税抜き）
                rst.Cost = (Int64)dr[SalesDetailSchema.ct_Col_Cost];	// 原価
                rst.GrsProfitChkDiv = (Int32)dr[SalesDetailSchema.ct_Col_GrsProfitChkDiv];	// 粗利チェック区分
                rst.SalesGoodsCd = (Int32)dr[SalesDetailSchema.ct_Col_SalesGoodsCd];	// 売上商品区分
                rst.SalesPriceConsTax = (Int64)dr[SalesDetailSchema.ct_Col_SalesPriceConsTax];	// 売上金額消費税額
                rst.TaxationDivCd = (Int32)dr[SalesDetailSchema.ct_Col_TaxationDivCd];	// 課税区分
                rst.PartySlipNumDtl = (string)dr[SalesDetailSchema.ct_Col_PartySlipNumDtl];	// 相手先伝票番号（明細）
                rst.DtlNote = (string)dr[SalesDetailSchema.ct_Col_DtlNote];	// 明細備考
                rst.SupplierCd = (Int32)dr[SalesDetailSchema.ct_Col_SupplierCd];	// 仕入先コード
                rst.SupplierSnm = (string)dr[SalesDetailSchema.ct_Col_SupplierSnm];	// 仕入先略称
                rst.OrderNumber = (string)dr[SalesDetailSchema.ct_Col_OrderNumber];	// 発注番号
                rst.WayToOrder = (Int32)dr[SalesDetailSchema.ct_Col_WayToOrder];	// 注文方法
                rst.SlipMemo1 = (string)dr[SalesDetailSchema.ct_Col_SlipMemo1];	// 伝票メモ１
                rst.SlipMemo2 = (string)dr[SalesDetailSchema.ct_Col_SlipMemo2];	// 伝票メモ２
                rst.SlipMemo3 = (string)dr[SalesDetailSchema.ct_Col_SlipMemo3];	// 伝票メモ３
                rst.InsideMemo1 = (string)dr[SalesDetailSchema.ct_Col_InsideMemo1];	// 社内メモ１
                rst.InsideMemo2 = (string)dr[SalesDetailSchema.ct_Col_InsideMemo2];	// 社内メモ２
                rst.InsideMemo3 = (string)dr[SalesDetailSchema.ct_Col_InsideMemo3];	// 社内メモ３
                rst.BfListPrice = (Double)dr[SalesDetailSchema.ct_Col_BfListPrice];	// 変更前定価
                rst.BfSalesUnitPrice = (Double)dr[SalesDetailSchema.ct_Col_BfSalesUnitPrice];	// 変更前売価
                rst.BfUnitCost = (Double)dr[SalesDetailSchema.ct_Col_BfUnitCost];	// 変更前原価
                rst.CmpltSalesRowNo = (Int32)dr[SalesDetailSchema.ct_Col_CmpltSalesRowNo];	// 一式明細番号
                rst.CmpltGoodsMakerCd = (Int32)dr[SalesDetailSchema.ct_Col_CmpltGoodsMakerCd];	// メーカーコード（一式）
                rst.CmpltMakerName = (string)dr[SalesDetailSchema.ct_Col_CmpltMakerName];	// メーカー名称（一式）
                rst.CmpltMakerKanaName = (string)dr[SalesDetailSchema.ct_Col_CmpltMakerKanaName];	// メーカーカナ名称（一式）
                rst.CmpltGoodsName = (string)dr[SalesDetailSchema.ct_Col_CmpltGoodsName];	// 商品名称（一式）
                rst.CmpltShipmentCnt = (Double)dr[SalesDetailSchema.ct_Col_CmpltShipmentCnt];	// 数量（一式）
                rst.CmpltSalesUnPrcFl = (Double)dr[SalesDetailSchema.ct_Col_CmpltSalesUnPrcFl];	// 売上単価（一式）
                rst.CmpltSalesMoney = (Int64)dr[SalesDetailSchema.ct_Col_CmpltSalesMoney];	// 売上金額（一式）
                rst.CmpltSalesUnitCost = (Double)dr[SalesDetailSchema.ct_Col_CmpltSalesUnitCost];	// 原価単価（一式）
                rst.CmpltCost = (Int64)dr[SalesDetailSchema.ct_Col_CmpltCost];	// 原価金額（一式）
                rst.CmpltPartySalSlNum = (string)dr[SalesDetailSchema.ct_Col_CmpltPartySalSlNum];	// 相手先伝票番号（一式）
                rst.CmpltNote = (string)dr[SalesDetailSchema.ct_Col_CmpltNote];	// 一式備考
                rst.PrtGoodsNo = (string)dr[SalesDetailSchema.ct_Col_PrtGoodsNo];	// 印刷用品番
                rst.PrtMakerCode = (Int32)dr[SalesDetailSchema.ct_Col_PrtMakerCode];	// 印刷用メーカーコード
                rst.PrtMakerName = (string)dr[SalesDetailSchema.ct_Col_PrtMakerName];	// 印刷用メーカー名称
                rst.ShipmCntDifference = (Double)dr[SalesDetailSchema.ct_Col_ShipmCntDifference];	// 出荷差分数
                rst.DtlRelationGuid = (Guid)dr[SalesDetailSchema.ct_Col_DtlRelationGuid];	// 明細関連付けGUID
                // 2011/01/19 Add >>>
                rst.CampaignCode = (Int32)dr[SalesDetailSchema.ct_Col_CampaignCode];   // キャンペーンコード
                rst.CampaignName = (string)dr[SalesDetailSchema.ct_Col_CampaignName];   // キャンペーン名称
                rst.GoodsDivCd = (Int32)dr[SalesDetailSchema.ct_Col_GoodsDivCd];   // 商品種別
                rst.AnswerDelivDate = (string)dr[SalesDetailSchema.ct_Col_AnswerDelivDate]; // 回答納期
                rst.RecycleDiv = (Int32)dr[SalesDetailSchema.ct_Col_RecycleDiv];   // リサイクル区分
                rst.RecycleDivNm = (string)dr[SalesDetailSchema.ct_Col_RecycleDivNm];   // リサイクル区分名称
                rst.WayToAcptOdr = (Int32)dr[SalesDetailSchema.ct_Col_WayToAcptOdr];   // 受注方法
                // 2011/01/19 Add <<<
                rst.AutoAnswerDivSCM = (Int32)dr[SalesDetailSchema.ct_Col_AutoAnswerDivSCM];   // 自動回答区分//add 2011/07/28
                // 2012/01/16 Add >>>
                rst.GoodsSpecialNote = (string)dr[SalesDetailSchema.ct_Col_GoodsSpecialNote];   // 特記事項
                // 2012/01/16 Add <<<

                // ADD 2012/12/06 2012/12/12配信予定 SCM障害№10447対応 ----------------------------------->>>>>
                rst.AcceptOrOrderKind = (short)dr[SalesDetailSchema.ct_Col_AcceptOrOrderKind];  // 受発注種別
                // ADD 2012/12/06 2012/12/12配信予定 SCM障害№10447対応 -----------------------------------<<<<<

            }
            catch (Exception)
            {
                rst = null;
            }
            return (rst);
        }
        # endregion
        # endregion
	}
}

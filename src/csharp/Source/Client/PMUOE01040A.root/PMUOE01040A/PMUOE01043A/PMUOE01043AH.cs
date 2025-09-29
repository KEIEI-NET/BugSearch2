//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 仕入明細アクセスクラス
// プログラム概要   : 仕入明細アクセスを行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2008/05/26  修正内容 : 新規作成
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
	/// 仕入明細アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 仕入明細アクセスクラス</br>
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
        # region 仕入明細の追加＜StockDetailWork→データーテーブル＞
        /// <summary>
        /// 仕入明細の追加＜StockDetailWork→データーテーブル＞
        /// </summary>
        /// <param name="tbl">データテーブル</param>
        /// <param name="stockDetailWork">仕入明細データ</param>
        /// <param name="commonSlipNo">共通伝票番号</param>
        /// <param name="commonSlipRowNo">共通伝票行番号</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int InsertTableFromStockDetailWork(DataTable tbl, StockDetailWork stockDetailWork, string commonSlipNo, Int32 commonSlipRowNo, out string message)
        {
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                DataRow dr = tbl.NewRow();
                CreateStockDetailSchema(ref dr, stockDetailWork, commonSlipNo, commonSlipRowNo);
                tbl.Rows.Add(dr);
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }

            return (status);
        }
        # endregion

        # region 仕入明細の更新＜仕入明細→データーテーブル＞
        /// <summary>
        /// 仕入明細更新＜仕入明細→データーテーブル＞
        /// </summary>
        /// <param name="tbl">データーテーブル</param>
        /// <param name="stockDetailWork">仕入明細</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int UpdateTableFromStockDetailWork(DataTable tbl, StockDetailWork stockDetailWork, out string message)
        {
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                DataRow stockDetailRow = FindStockDetailDataTable(tbl, stockDetailWork.SupplierFormal, stockDetailWork.DtlRelationGuid, out message);

                //仕入明細更新の更新
                if (stockDetailRow != null)
                {
                    CreateStockDetailSchema(ref stockDetailRow, stockDetailWork);
                }
                else
                {
                    message = "該当の仕入明細が存在しません。";
                    status = -1;
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }

            return (status);
        }

        /// <summary>
        /// 仕入明細の更新＜StockDetailWork→データーテーブル＞
        /// </summary>
        /// <param name="tbl">データテーブル</param>
        /// <param name="stockDetailWork">仕入明細データ</param>
        /// <param name="commonSlipNo">共通伝票番号</param>
        /// <param name="commonSlipRowNo">共通伝票行番号</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int UpdateTableFromStockDetailWork(DataTable tbl, StockDetailWork stockDetailWork, string commonSlipNo, Int32 commonSlipRowNo, out string message)
        {
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                DataRow stockDetailRow = FindStockDetailDataTable(tbl, stockDetailWork.SupplierFormal, stockDetailWork.DtlRelationGuid, out message);

                //仕入明細更新の更新
                if (stockDetailRow != null)
                {
                    CreateStockDetailSchema(ref stockDetailRow, stockDetailWork, commonSlipNo, commonSlipRowNo);
                }
                else
                {
                    status = InsertTableFromStockDetailWork(tbl, stockDetailWork, commonSlipNo, commonSlipRowNo, out message);
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

        # region 仕入明細の更新＜共通伝票番号・共通伝票行番号＞
        /// <summary>
        /// 仕入明細の更新＜共通伝票番号・共通伝票行番号＞
        /// </summary>
        /// <param name="tbl">データテーブル</param>
        /// <param name="stockDetailWork">仕入明細データ</param>
        /// <param name="commonSlipNo">共通伝票番号</param>
        /// <param name="commonSlipRowNo">共通伝票行番号</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int UpdateTableFromStockDetailWork(DataTable tbl, Int32 supplierFormal, Guid dtlRelationGuid, string commonSlipNo, Int32 commonSlipRowNo, out string message)
        {
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                DataRow stockDetailRow = FindStockDetailDataTable(tbl, supplierFormal, dtlRelationGuid, out message);

                //仕入明細更新の更新
                if (stockDetailRow != null)
                {
                    CreateStockDetailSchema(ref stockDetailRow, commonSlipNo, commonSlipRowNo);
                }
                else
                {
                    message = "該当の仕入明細が存在しません。";
                    status = -1;
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

        # region 仕入明細リストの更新＜List<StockDetailWork>→データーテーブル＞
        /// <summary>
        /// 仕入明細リストの更新＜List<StockDetailWork>→データーテーブル＞
        /// </summary>
        /// <param name="tbl">データテーブル</param>
        /// <param name="list">仕入明細データリスト</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int UpdateTableFromStockDetailList(DataTable tbl, List<StockDetailWork> list, out string message)
        {
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                foreach (StockDetailWork stockDetailWork in list)
                {
                    status = UpdateTableFromStockDetailWork(tbl, stockDetailWork, out message);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) break;
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

        # region 仕入明細リストの更新＜ArrayList→データーテーブル＞
        /// <summary>
        /// 仕入明細リストの更新＜ArrayList→データーテーブル＞
        /// </summary>
        /// <param name="tbl">データテーブル</param>
        /// <param name="list">仕入明細データリスト</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int UpdateTableFromStockDetailList(DataTable tbl, ArrayList list, out string message)
        {
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                foreach (StockDetailWork stockDetailWork in list)
                {
                    status = UpdateTableFromStockDetailWork(tbl, stockDetailWork, out message);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) break;
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

        # region 仕入明細の読込
        /// <summary>
        /// 仕入明細の読込
        /// </summary>
        /// <param name="tbl">データーテーブル</param>
        /// <param name="supplierFormal">仕入形式</param>
        /// <param name="dtlRelationGuid">明細関連付けGUID</param>
        /// <param name="stockDetailWork">仕入明細オブジェクト</param>
        /// <param name="commonSlipNo">共通伝票番号</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public  int ReadStockDetailWork(DataTable tbl, int supplierFormal, Guid dtlRelationGuid, out StockDetailWork stockDetailWork, out string commonSlipNo, out string message)
        {
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            stockDetailWork = null;
            commonSlipNo = "";

            try
            {
                DataRow stockDetailRow = FindStockDetailDataTable(tbl, supplierFormal, dtlRelationGuid, out message);
                stockDetailWork = CreateStockDetailWorkFromSchemaProc(stockDetailRow);
                commonSlipNo = (string)stockDetailRow[StockDetailSchema.ct_Col_CommonSlipNo];
            }
            catch (Exception ex)
            {
                stockDetailWork = null;
                commonSlipNo = "";
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        # endregion

        # region 仕入明細＜DataRow → クラス＞作成
        /// <summary>
        /// 仕入明細＜DataRow → クラス＞作成
        /// </summary>
        /// <param name="dr">テーブルRow</param>
        /// <returns>仕入明細</returns>
        public StockDetailWork CreateStockDetailWorkFromSchema(DataRow dr)
        {
            return(CreateStockDetailWorkFromSchemaProc(dr));
        }
        # endregion

        # region 仕入明細リストの取得：ArrayList<StockDetailWork>
        /// <summary>
        /// 仕入明細リストの取得：ArrayList<StockDetailWork>
        /// </summary>
        /// <param name="tbl">データテーブル</param>
        /// <param name="supplierFormal">仕入形式</param>
        /// <param name="commonSlipNo">仕入伝票番号</param>
        /// <returns>仕入明細リスト</returns>
        public ArrayList SearchStockDetailDataTable(DataTable tbl, Int32 supplierFormal, string commonSlipNo)
        {
            ArrayList returnStockDetailAry = new ArrayList();
            try
            {
                string rowFilterText = string.Format("{0} = {1} AND {2} = '{3}'",
                                                StockDetailSchema.ct_Col_SupplierFormal, supplierFormal,
                                                StockDetailSchema.ct_Col_CommonSlipNo, commonSlipNo);

                string sortText = string.Format("{0}, {1}, {2}, {3}",
                    StockDetailSchema.ct_Col_EnterpriseCode,
                    StockDetailSchema.ct_Col_SupplierFormal,
                    StockDetailSchema.ct_Col_CommonSlipNo,
                    StockDetailSchema.ct_Col_CommonSlipRowNo);

                DataView viewStockDetail = new DataView(tbl);
                viewStockDetail.Sort = sortText;
                viewStockDetail.RowFilter = rowFilterText;

                if (viewStockDetail.Count > 0)
                {
                    foreach (DataRowView rowStockDetail in viewStockDetail)
                    {
                        StockDetailWork stockDetailWork = CreateStockDetailWorkFromSchema(rowStockDetail.Row);
                        returnStockDetailAry.Add(stockDetailWork);
                    }
                }
            }
            catch (Exception)
            {
                returnStockDetailAry = null;
            }
            return (returnStockDetailAry);
        }
        # endregion

        # region 仕入明細に行番号を設定
        /// <summary>
        /// 仕入明細に行番号を設定
        /// </summary>
        /// <param name="tbl">データテーブル</param>
        /// <param name="supplierFormal">仕入形式</param>
        /// <param name="commonSlipNo">仕入伝票番号</param>
        /// <param name="message"></param>
        /// <returns></returns>
        public int SetRowNoFromStockDetail(DataTable tbl, Int32 supplierFormal, string commonSlipNo, out string message)
        {
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                //DataViewの作成
                string rowFilterText = string.Format("{0} = {1} AND {2} = '{3}'",
                                                StockDetailSchema.ct_Col_SupplierFormal, supplierFormal,
                                                StockDetailSchema.ct_Col_CommonSlipNo, commonSlipNo);

                string sortText = string.Format("{0}, {1}, {2}, {3}",
                    StockDetailSchema.ct_Col_EnterpriseCode,
                    StockDetailSchema.ct_Col_SupplierFormal,
                    StockDetailSchema.ct_Col_CommonSlipNo,
                    StockDetailSchema.ct_Col_CommonSlipRowNo);

                DataView viewStockDetail = new DataView(tbl);
                viewStockDetail.Sort = sortText;
                viewStockDetail.RowFilter = rowFilterText;

                if (viewStockDetail.Count == 0) return (status);


                Int32 stockRowNo = 0;
                foreach (DataRowView rowStockDetail in viewStockDetail)
                {
                    stockRowNo++;
                    rowStockDetail[StockDetailSchema.ct_Col_StockRowNo] = stockRowNo;
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

        # endregion

        // ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods
        # region 仕入明細の検索
        /// <summary>
        /// 仕入明細の検索
        /// </summary>
        /// <param name="tbl">データーテーブル</param>
        /// <param name="supplierFormal">仕入形式</param>
        /// <param name="dtlRelationGuid">明細関連付けGUID</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>DataRow</returns>
        private DataRow FindStockDetailDataTable(DataTable tbl, int supplierFormal, Guid dtlRelationGuid, out string message)
        {
            //変数の初期化
            DataRow stockDetailRow = null;
            message = "";

            try
            {
                //Findパラメータ設定
                object[] findStockDetail = new object[2];
                findStockDetail[0] = supplierFormal;
                findStockDetail[1] = dtlRelationGuid;
                stockDetailRow = tbl.Rows.Find(findStockDetail);
            }
            catch (Exception ex)
            {
                stockDetailRow = null;
                message = ex.Message;
            }

            return (stockDetailRow);
        }
        # endregion

        # region 仕入明細テーブルRow作成
        /// <summary>
        /// 仕入明細テーブルRow作成
        /// </summary>
        /// <param name="dr">テーブルRow</param>
        /// <param name="rst">仕入明細クラス</param>
        /// <param name="commonSlipNo">共通伝票番号</param>
        /// <param name="commonSlipRowNo">共通伝票行番号</param>
        private void CreateStockDetailSchema(ref DataRow dr, StockDetailWork rst, string commonSlipNo, Int32 commonSlipRowNo)
        {
            CreateStockDetailSchema(ref dr, rst);
            CreateStockDetailSchema(ref dr, commonSlipNo, commonSlipRowNo);
        }

        /// <summary>
        /// 仕入明細テーブルRow作成
        /// </summary>
        /// <param name="dr">テーブルRow</param>
        /// <param name="commonSlipNo">共通伝票番号</param>
        /// <param name="commonSlipRowNo">共通伝票行番号</param>
        private void CreateStockDetailSchema(ref DataRow dr, string commonSlipNo, Int32 commonSlipRowNo)
        {
            dr[StockDetailSchema.ct_Col_CommonSlipNo] = commonSlipNo;
            dr[StockDetailSchema.ct_Col_CommonSlipRowNo] = commonSlipRowNo;
        }

        /// <summary>
        /// 仕入明細テーブルRow作成
        /// </summary>
        /// <param name="dr">テーブルRow</param>
        /// <param name="rst">仕入明細クラス</param>
        private void CreateStockDetailSchema(ref DataRow dr, StockDetailWork rst)
        {
            dr[StockDetailSchema.ct_Col_CreateDateTime] = rst.CreateDateTime;	// 作成日時
            dr[StockDetailSchema.ct_Col_UpdateDateTime] = rst.UpdateDateTime;	// 更新日時
            dr[StockDetailSchema.ct_Col_EnterpriseCode] = rst.EnterpriseCode;	// 企業コード
            dr[StockDetailSchema.ct_Col_FileHeaderGuid] = rst.FileHeaderGuid;	// GUID
            dr[StockDetailSchema.ct_Col_UpdEmployeeCode] = rst.UpdEmployeeCode;	// 更新従業員コード
            dr[StockDetailSchema.ct_Col_UpdAssemblyId1] = rst.UpdAssemblyId1;	// 更新アセンブリID1
            dr[StockDetailSchema.ct_Col_UpdAssemblyId2] = rst.UpdAssemblyId2;	// 更新アセンブリID2
            dr[StockDetailSchema.ct_Col_LogicalDeleteCode] = rst.LogicalDeleteCode;	// 論理削除区分
            dr[StockDetailSchema.ct_Col_AcceptAnOrderNo] = rst.AcceptAnOrderNo;	// 受注番号
            dr[StockDetailSchema.ct_Col_SupplierFormal] = rst.SupplierFormal;	// 仕入形式
            dr[StockDetailSchema.ct_Col_SupplierSlipNo] = rst.SupplierSlipNo;	// 仕入伝票番号
            dr[StockDetailSchema.ct_Col_StockRowNo] = rst.StockRowNo;	// 仕入行番号
            dr[StockDetailSchema.ct_Col_SectionCode] = rst.SectionCode;	// 拠点コード
            dr[StockDetailSchema.ct_Col_SubSectionCode] = rst.SubSectionCode;	// 部門コード
            dr[StockDetailSchema.ct_Col_CommonSeqNo] = rst.CommonSeqNo;	// 共通通番
            dr[StockDetailSchema.ct_Col_StockSlipDtlNum] = rst.StockSlipDtlNum;	// 仕入明細通番
            dr[StockDetailSchema.ct_Col_SupplierFormalSrc] = rst.SupplierFormalSrc;	// 仕入形式（元）
            dr[StockDetailSchema.ct_Col_StockSlipDtlNumSrc] = rst.StockSlipDtlNumSrc;	// 仕入明細通番（元）
            dr[StockDetailSchema.ct_Col_AcptAnOdrStatusSync] = rst.AcptAnOdrStatusSync;	// 受注ステータス（同時）
            dr[StockDetailSchema.ct_Col_SalesSlipDtlNumSync] = rst.SalesSlipDtlNumSync;	// 売上明細通番（同時）
            dr[StockDetailSchema.ct_Col_StockSlipCdDtl] = rst.StockSlipCdDtl;	// 仕入伝票区分（明細）
            dr[StockDetailSchema.ct_Col_StockInputCode] = rst.StockInputCode;	// 仕入入力者コード
            dr[StockDetailSchema.ct_Col_StockInputName] = rst.StockInputName;	// 仕入入力者名称
            dr[StockDetailSchema.ct_Col_StockAgentCode] = rst.StockAgentCode;	// 仕入担当者コード
            dr[StockDetailSchema.ct_Col_StockAgentName] = rst.StockAgentName;	// 仕入担当者名称
            dr[StockDetailSchema.ct_Col_GoodsKindCode] = rst.GoodsKindCode;	// 商品属性
            dr[StockDetailSchema.ct_Col_GoodsMakerCd] = rst.GoodsMakerCd;	// 商品メーカーコード
            dr[StockDetailSchema.ct_Col_MakerName] = rst.MakerName;	// メーカー名称
            dr[StockDetailSchema.ct_Col_MakerKanaName] = rst.MakerKanaName;	// メーカーカナ名称
            dr[StockDetailSchema.ct_Col_CmpltMakerKanaName] = rst.CmpltMakerKanaName;	// メーカーカナ名称（一式）
            dr[StockDetailSchema.ct_Col_GoodsNo] = rst.GoodsNo;	// 商品番号
            dr[StockDetailSchema.ct_Col_GoodsName] = rst.GoodsName;	// 商品名称
            dr[StockDetailSchema.ct_Col_GoodsNameKana] = rst.GoodsNameKana;	// 商品名称カナ
            dr[StockDetailSchema.ct_Col_GoodsLGroup] = rst.GoodsLGroup;	// 商品大分類コード
            dr[StockDetailSchema.ct_Col_GoodsLGroupName] = rst.GoodsLGroupName;	// 商品大分類名称
            dr[StockDetailSchema.ct_Col_GoodsMGroup] = rst.GoodsMGroup;	// 商品中分類コード
            dr[StockDetailSchema.ct_Col_GoodsMGroupName] = rst.GoodsMGroupName;	// 商品中分類名称
            dr[StockDetailSchema.ct_Col_BLGroupCode] = rst.BLGroupCode;	// BLグループコード
            dr[StockDetailSchema.ct_Col_BLGroupName] = rst.BLGroupName;	// BLグループコード名称
            dr[StockDetailSchema.ct_Col_BLGoodsCode] = rst.BLGoodsCode;	// BL商品コード
            dr[StockDetailSchema.ct_Col_BLGoodsFullName] = rst.BLGoodsFullName;	// BL商品コード名称（全角）
            dr[StockDetailSchema.ct_Col_EnterpriseGanreCode] = rst.EnterpriseGanreCode;	// 自社分類コード
            dr[StockDetailSchema.ct_Col_EnterpriseGanreName] = rst.EnterpriseGanreName;	// 自社分類名称
            dr[StockDetailSchema.ct_Col_WarehouseCode] = rst.WarehouseCode;	// 倉庫コード
            dr[StockDetailSchema.ct_Col_WarehouseName] = rst.WarehouseName;	// 倉庫名称
            dr[StockDetailSchema.ct_Col_WarehouseShelfNo] = rst.WarehouseShelfNo;	// 倉庫棚番
            dr[StockDetailSchema.ct_Col_StockOrderDivCd] = rst.StockOrderDivCd;	// 仕入在庫取寄せ区分
            dr[StockDetailSchema.ct_Col_OpenPriceDiv] = rst.OpenPriceDiv;	// オープン価格区分
            dr[StockDetailSchema.ct_Col_GoodsRateRank] = rst.GoodsRateRank;	// 商品掛率ランク
            dr[StockDetailSchema.ct_Col_CustRateGrpCode] = rst.CustRateGrpCode;	// 得意先掛率グループコード
            dr[StockDetailSchema.ct_Col_SuppRateGrpCode] = rst.SuppRateGrpCode;	// 仕入先掛率グループコード
            dr[StockDetailSchema.ct_Col_ListPriceTaxExcFl] = rst.ListPriceTaxExcFl;	// 定価（税抜，浮動）
            dr[StockDetailSchema.ct_Col_ListPriceTaxIncFl] = rst.ListPriceTaxIncFl;	// 定価（税込，浮動）
            dr[StockDetailSchema.ct_Col_StockRate] = rst.StockRate;	// 仕入率
            dr[StockDetailSchema.ct_Col_RateSectStckUnPrc] = rst.RateSectStckUnPrc;	// 掛率設定拠点（仕入単価）
            dr[StockDetailSchema.ct_Col_RateDivStckUnPrc] = rst.RateDivStckUnPrc;	// 掛率設定区分（仕入単価）
            dr[StockDetailSchema.ct_Col_UnPrcCalcCdStckUnPrc] = rst.UnPrcCalcCdStckUnPrc;	// 単価算出区分（仕入単価）
            dr[StockDetailSchema.ct_Col_PriceCdStckUnPrc] = rst.PriceCdStckUnPrc;	// 価格区分（仕入単価）
            dr[StockDetailSchema.ct_Col_StdUnPrcStckUnPrc] = rst.StdUnPrcStckUnPrc;	// 基準単価（仕入単価）
            dr[StockDetailSchema.ct_Col_FracProcUnitStcUnPrc] = rst.FracProcUnitStcUnPrc;	// 端数処理単位（仕入単価）
            dr[StockDetailSchema.ct_Col_FracProcStckUnPrc] = rst.FracProcStckUnPrc;	// 端数処理（仕入単価）
            dr[StockDetailSchema.ct_Col_StockUnitPriceFl] = rst.StockUnitPriceFl;	// 仕入単価（税抜，浮動）
            dr[StockDetailSchema.ct_Col_StockUnitTaxPriceFl] = rst.StockUnitTaxPriceFl;	// 仕入単価（税込，浮動）
            dr[StockDetailSchema.ct_Col_StockUnitChngDiv] = rst.StockUnitChngDiv;	// 仕入単価変更区分
            dr[StockDetailSchema.ct_Col_BfStockUnitPriceFl] = rst.BfStockUnitPriceFl;	// 変更前仕入単価（浮動）
            dr[StockDetailSchema.ct_Col_BfListPrice] = rst.BfListPrice;	// 変更前定価
            dr[StockDetailSchema.ct_Col_RateBLGoodsCode] = rst.RateBLGoodsCode;	// BL商品コード（掛率）
            dr[StockDetailSchema.ct_Col_RateBLGoodsName] = rst.RateBLGoodsName;	// BL商品コード名称（掛率）
            dr[StockDetailSchema.ct_Col_RateGoodsRateGrpCd] = rst.RateGoodsRateGrpCd;	// 商品掛率グループコード（掛率）
            dr[StockDetailSchema.ct_Col_RateGoodsRateGrpNm] = rst.RateGoodsRateGrpNm;	// 商品掛率グループ名称（掛率）
            dr[StockDetailSchema.ct_Col_RateBLGroupCode] = rst.RateBLGroupCode;	// BLグループコード（掛率）
            dr[StockDetailSchema.ct_Col_RateBLGroupName] = rst.RateBLGroupName;	// BLグループ名称（掛率）
            dr[StockDetailSchema.ct_Col_StockCount] = rst.StockCount;	// 仕入数
            dr[StockDetailSchema.ct_Col_OrderCnt] = rst.OrderCnt;	// 発注数量
            dr[StockDetailSchema.ct_Col_OrderAdjustCnt] = rst.OrderAdjustCnt;	// 発注調整数
            dr[StockDetailSchema.ct_Col_OrderRemainCnt] = rst.OrderRemainCnt;	// 発注残数
            dr[StockDetailSchema.ct_Col_RemainCntUpdDate] = rst.RemainCntUpdDate;	// 残数更新日
            dr[StockDetailSchema.ct_Col_StockPriceTaxExc] = rst.StockPriceTaxExc;	// 仕入金額（税抜き）
            dr[StockDetailSchema.ct_Col_StockPriceTaxInc] = rst.StockPriceTaxInc;	// 仕入金額（税込み）
            dr[StockDetailSchema.ct_Col_StockGoodsCd] = rst.StockGoodsCd;	// 仕入商品区分
            dr[StockDetailSchema.ct_Col_StockPriceConsTax] = rst.StockPriceConsTax;	// 仕入金額消費税額
            dr[StockDetailSchema.ct_Col_TaxationCode] = rst.TaxationCode;	// 課税区分
            dr[StockDetailSchema.ct_Col_StockDtiSlipNote1] = rst.StockDtiSlipNote1;	// 仕入伝票明細備考1
            dr[StockDetailSchema.ct_Col_SalesCustomerCode] = rst.SalesCustomerCode;	// 販売先コード
            dr[StockDetailSchema.ct_Col_SalesCustomerSnm] = rst.SalesCustomerSnm;	// 販売先略称
            dr[StockDetailSchema.ct_Col_SlipMemo1] = rst.SlipMemo1;	// 伝票メモ１
            dr[StockDetailSchema.ct_Col_SlipMemo2] = rst.SlipMemo2;	// 伝票メモ２
            dr[StockDetailSchema.ct_Col_SlipMemo3] = rst.SlipMemo3;	// 伝票メモ３
            dr[StockDetailSchema.ct_Col_InsideMemo1] = rst.InsideMemo1;	// 社内メモ１
            dr[StockDetailSchema.ct_Col_InsideMemo2] = rst.InsideMemo2;	// 社内メモ２
            dr[StockDetailSchema.ct_Col_InsideMemo3] = rst.InsideMemo3;	// 社内メモ３
            dr[StockDetailSchema.ct_Col_SupplierCd] = rst.SupplierCd;	// 仕入先コード
            dr[StockDetailSchema.ct_Col_SupplierSnm] = rst.SupplierSnm;	// 仕入先略称
            dr[StockDetailSchema.ct_Col_AddresseeCode] = rst.AddresseeCode;	// 納品先コード
            dr[StockDetailSchema.ct_Col_AddresseeName] = rst.AddresseeName;	// 納品先名称
            dr[StockDetailSchema.ct_Col_DirectSendingCd] = rst.DirectSendingCd;	// 直送区分
            dr[StockDetailSchema.ct_Col_OrderNumber] = rst.OrderNumber;	// 発注番号
            dr[StockDetailSchema.ct_Col_WayToOrder] = rst.WayToOrder;	// 注文方法
            dr[StockDetailSchema.ct_Col_DeliGdsCmpltDueDate] = rst.DeliGdsCmpltDueDate;	// 納品完了予定日
            dr[StockDetailSchema.ct_Col_ExpectDeliveryDate] = rst.ExpectDeliveryDate;	// 希望納期
            dr[StockDetailSchema.ct_Col_OrderDataCreateDiv] = rst.OrderDataCreateDiv;	// 発注データ作成区分
            dr[StockDetailSchema.ct_Col_OrderDataCreateDate] = rst.OrderDataCreateDate;	// 発注データ作成日
            dr[StockDetailSchema.ct_Col_OrderFormIssuedDiv] = rst.OrderFormIssuedDiv;	// 発注書発行済区分
            dr[StockDetailSchema.ct_Col_StockCountDifference] = rst.StockCountDifference;	// 仕入差分数
            dr[StockDetailSchema.ct_Col_DtlRelationGuid] = rst.DtlRelationGuid;	// 明細関連付けGUID
        }
        # endregion

        # region 仕入明細＜DataRow → クラス＞作成
        /// <summary>
        /// 仕入明細＜DataRow → クラス＞作成
        /// </summary>
        /// <param name="dr">テーブルRow</param>
        /// <returns>仕入明細</returns>
        private StockDetailWork CreateStockDetailWorkFromSchemaProc(DataRow dr)
        {
            StockDetailWork rst = new StockDetailWork();

            try
            {
                rst.CreateDateTime = (DateTime)dr[StockDetailSchema.ct_Col_CreateDateTime];	// 作成日時
                rst.UpdateDateTime = (DateTime)dr[StockDetailSchema.ct_Col_UpdateDateTime];	// 更新日時
                rst.EnterpriseCode = (string)dr[StockDetailSchema.ct_Col_EnterpriseCode];	// 企業コード
                rst.FileHeaderGuid = (Guid)dr[StockDetailSchema.ct_Col_FileHeaderGuid];	// GUID
                rst.UpdEmployeeCode = (string)dr[StockDetailSchema.ct_Col_UpdEmployeeCode];	// 更新従業員コード
                rst.UpdAssemblyId1 = (string)dr[StockDetailSchema.ct_Col_UpdAssemblyId1];	// 更新アセンブリID1
                rst.UpdAssemblyId2 = (string)dr[StockDetailSchema.ct_Col_UpdAssemblyId2];	// 更新アセンブリID2
                rst.LogicalDeleteCode = (Int32)dr[StockDetailSchema.ct_Col_LogicalDeleteCode];	// 論理削除区分
                rst.AcceptAnOrderNo = (Int32)dr[StockDetailSchema.ct_Col_AcceptAnOrderNo];	// 受注番号
                rst.SupplierFormal = (Int32)dr[StockDetailSchema.ct_Col_SupplierFormal];	// 仕入形式
                rst.SupplierSlipNo = (Int32)dr[StockDetailSchema.ct_Col_SupplierSlipNo];	// 仕入伝票番号
                rst.StockRowNo = (Int32)dr[StockDetailSchema.ct_Col_StockRowNo];	// 仕入行番号
                rst.SectionCode = (string)dr[StockDetailSchema.ct_Col_SectionCode];	// 拠点コード
                rst.SubSectionCode = (Int32)dr[StockDetailSchema.ct_Col_SubSectionCode];	// 部門コード
                rst.CommonSeqNo = (Int64)dr[StockDetailSchema.ct_Col_CommonSeqNo];	// 共通通番
                rst.StockSlipDtlNum = (Int64)dr[StockDetailSchema.ct_Col_StockSlipDtlNum];	// 仕入明細通番
                rst.SupplierFormalSrc = (Int32)dr[StockDetailSchema.ct_Col_SupplierFormalSrc];	// 仕入形式（元）
                rst.StockSlipDtlNumSrc = (Int64)dr[StockDetailSchema.ct_Col_StockSlipDtlNumSrc];	// 仕入明細通番（元）
                rst.AcptAnOdrStatusSync = (Int32)dr[StockDetailSchema.ct_Col_AcptAnOdrStatusSync];	// 受注ステータス（同時）
                rst.SalesSlipDtlNumSync = (Int64)dr[StockDetailSchema.ct_Col_SalesSlipDtlNumSync];	// 売上明細通番（同時）
                rst.StockSlipCdDtl = (Int32)dr[StockDetailSchema.ct_Col_StockSlipCdDtl];	// 仕入伝票区分（明細）
                rst.StockInputCode = (string)dr[StockDetailSchema.ct_Col_StockInputCode];	// 仕入入力者コード
                rst.StockInputName = (string)dr[StockDetailSchema.ct_Col_StockInputName];	// 仕入入力者名称
                rst.StockAgentCode = (string)dr[StockDetailSchema.ct_Col_StockAgentCode];	// 仕入担当者コード
                rst.StockAgentName = (string)dr[StockDetailSchema.ct_Col_StockAgentName];	// 仕入担当者名称
                rst.GoodsKindCode = (Int32)dr[StockDetailSchema.ct_Col_GoodsKindCode];	// 商品属性
                rst.GoodsMakerCd = (Int32)dr[StockDetailSchema.ct_Col_GoodsMakerCd];	// 商品メーカーコード
                rst.MakerName = (string)dr[StockDetailSchema.ct_Col_MakerName];	// メーカー名称
                rst.MakerKanaName = (string)dr[StockDetailSchema.ct_Col_MakerKanaName];	// メーカーカナ名称
                rst.CmpltMakerKanaName = (string)dr[StockDetailSchema.ct_Col_CmpltMakerKanaName];	// メーカーカナ名称（一式）
                rst.GoodsNo = (string)dr[StockDetailSchema.ct_Col_GoodsNo];	// 商品番号
                rst.GoodsName = (string)dr[StockDetailSchema.ct_Col_GoodsName];	// 商品名称
                rst.GoodsNameKana = (string)dr[StockDetailSchema.ct_Col_GoodsNameKana];	// 商品名称カナ
                rst.GoodsLGroup = (Int32)dr[StockDetailSchema.ct_Col_GoodsLGroup];	// 商品大分類コード
                rst.GoodsLGroupName = (string)dr[StockDetailSchema.ct_Col_GoodsLGroupName];	// 商品大分類名称
                rst.GoodsMGroup = (Int32)dr[StockDetailSchema.ct_Col_GoodsMGroup];	// 商品中分類コード
                rst.GoodsMGroupName = (string)dr[StockDetailSchema.ct_Col_GoodsMGroupName];	// 商品中分類名称
                rst.BLGroupCode = (Int32)dr[StockDetailSchema.ct_Col_BLGroupCode];	// BLグループコード
                rst.BLGroupName = (string)dr[StockDetailSchema.ct_Col_BLGroupName];	// BLグループコード名称
                rst.BLGoodsCode = (Int32)dr[StockDetailSchema.ct_Col_BLGoodsCode];	// BL商品コード
                rst.BLGoodsFullName = (string)dr[StockDetailSchema.ct_Col_BLGoodsFullName];	// BL商品コード名称（全角）
                rst.EnterpriseGanreCode = (Int32)dr[StockDetailSchema.ct_Col_EnterpriseGanreCode];	// 自社分類コード
                rst.EnterpriseGanreName = (string)dr[StockDetailSchema.ct_Col_EnterpriseGanreName];	// 自社分類名称
                rst.WarehouseCode = (string)dr[StockDetailSchema.ct_Col_WarehouseCode];	// 倉庫コード
                rst.WarehouseName = (string)dr[StockDetailSchema.ct_Col_WarehouseName];	// 倉庫名称
                rst.WarehouseShelfNo = (string)dr[StockDetailSchema.ct_Col_WarehouseShelfNo];	// 倉庫棚番
                rst.StockOrderDivCd = (Int32)dr[StockDetailSchema.ct_Col_StockOrderDivCd];	// 仕入在庫取寄せ区分
                rst.OpenPriceDiv = (Int32)dr[StockDetailSchema.ct_Col_OpenPriceDiv];	// オープン価格区分
                rst.GoodsRateRank = (string)dr[StockDetailSchema.ct_Col_GoodsRateRank];	// 商品掛率ランク
                rst.CustRateGrpCode = (Int32)dr[StockDetailSchema.ct_Col_CustRateGrpCode];	// 得意先掛率グループコード
                rst.SuppRateGrpCode = (Int32)dr[StockDetailSchema.ct_Col_SuppRateGrpCode];	// 仕入先掛率グループコード
                rst.ListPriceTaxExcFl = (Double)dr[StockDetailSchema.ct_Col_ListPriceTaxExcFl];	// 定価（税抜，浮動）
                rst.ListPriceTaxIncFl = (Double)dr[StockDetailSchema.ct_Col_ListPriceTaxIncFl];	// 定価（税込，浮動）
                rst.StockRate = (Double)dr[StockDetailSchema.ct_Col_StockRate];	// 仕入率
                rst.RateSectStckUnPrc = (string)dr[StockDetailSchema.ct_Col_RateSectStckUnPrc];	// 掛率設定拠点（仕入単価）
                rst.RateDivStckUnPrc = (string)dr[StockDetailSchema.ct_Col_RateDivStckUnPrc];	// 掛率設定区分（仕入単価）
                rst.UnPrcCalcCdStckUnPrc = (Int32)dr[StockDetailSchema.ct_Col_UnPrcCalcCdStckUnPrc];	// 単価算出区分（仕入単価）
                rst.PriceCdStckUnPrc = (Int32)dr[StockDetailSchema.ct_Col_PriceCdStckUnPrc];	// 価格区分（仕入単価）
                rst.StdUnPrcStckUnPrc = (Double)dr[StockDetailSchema.ct_Col_StdUnPrcStckUnPrc];	// 基準単価（仕入単価）
                rst.FracProcUnitStcUnPrc = (Double)dr[StockDetailSchema.ct_Col_FracProcUnitStcUnPrc];	// 端数処理単位（仕入単価）
                rst.FracProcStckUnPrc = (Int32)dr[StockDetailSchema.ct_Col_FracProcStckUnPrc];	// 端数処理（仕入単価）
                rst.StockUnitPriceFl = (Double)dr[StockDetailSchema.ct_Col_StockUnitPriceFl];	// 仕入単価（税抜，浮動）
                rst.StockUnitTaxPriceFl = (Double)dr[StockDetailSchema.ct_Col_StockUnitTaxPriceFl];	// 仕入単価（税込，浮動）
                rst.StockUnitChngDiv = (Int32)dr[StockDetailSchema.ct_Col_StockUnitChngDiv];	// 仕入単価変更区分
                rst.BfStockUnitPriceFl = (Double)dr[StockDetailSchema.ct_Col_BfStockUnitPriceFl];	// 変更前仕入単価（浮動）
                rst.BfListPrice = (Double)dr[StockDetailSchema.ct_Col_BfListPrice];	// 変更前定価
                rst.RateBLGoodsCode = (Int32)dr[StockDetailSchema.ct_Col_RateBLGoodsCode];	// BL商品コード（掛率）
                rst.RateBLGoodsName = (string)dr[StockDetailSchema.ct_Col_RateBLGoodsName];	// BL商品コード名称（掛率）
                rst.RateGoodsRateGrpCd = (Int32)dr[StockDetailSchema.ct_Col_RateGoodsRateGrpCd];	// 商品掛率グループコード（掛率）
                rst.RateGoodsRateGrpNm = (string)dr[StockDetailSchema.ct_Col_RateGoodsRateGrpNm];	// 商品掛率グループ名称（掛率）
                rst.RateBLGroupCode = (Int32)dr[StockDetailSchema.ct_Col_RateBLGroupCode];	// BLグループコード（掛率）
                rst.RateBLGroupName = (string)dr[StockDetailSchema.ct_Col_RateBLGroupName];	// BLグループ名称（掛率）
                rst.StockCount = (Double)dr[StockDetailSchema.ct_Col_StockCount];	// 仕入数
                rst.OrderCnt = (Double)dr[StockDetailSchema.ct_Col_OrderCnt];	// 発注数量
                rst.OrderAdjustCnt = (Double)dr[StockDetailSchema.ct_Col_OrderAdjustCnt];	// 発注調整数
                rst.OrderRemainCnt = (Double)dr[StockDetailSchema.ct_Col_OrderRemainCnt];	// 発注残数
                rst.RemainCntUpdDate = (DateTime)dr[StockDetailSchema.ct_Col_RemainCntUpdDate];	// 残数更新日
                rst.StockPriceTaxExc = (Int64)dr[StockDetailSchema.ct_Col_StockPriceTaxExc];	// 仕入金額（税抜き）
                rst.StockPriceTaxInc = (Int64)dr[StockDetailSchema.ct_Col_StockPriceTaxInc];	// 仕入金額（税込み）
                rst.StockGoodsCd = (Int32)dr[StockDetailSchema.ct_Col_StockGoodsCd];	// 仕入商品区分
                rst.StockPriceConsTax = (Int64)dr[StockDetailSchema.ct_Col_StockPriceConsTax];	// 仕入金額消費税額
                rst.TaxationCode = (Int32)dr[StockDetailSchema.ct_Col_TaxationCode];	// 課税区分
                rst.StockDtiSlipNote1 = (string)dr[StockDetailSchema.ct_Col_StockDtiSlipNote1];	// 仕入伝票明細備考1
                rst.SalesCustomerCode = (Int32)dr[StockDetailSchema.ct_Col_SalesCustomerCode];	// 販売先コード
                rst.SalesCustomerSnm = (string)dr[StockDetailSchema.ct_Col_SalesCustomerSnm];	// 販売先略称
                rst.SlipMemo1 = (string)dr[StockDetailSchema.ct_Col_SlipMemo1];	// 伝票メモ１
                rst.SlipMemo2 = (string)dr[StockDetailSchema.ct_Col_SlipMemo2];	// 伝票メモ２
                rst.SlipMemo3 = (string)dr[StockDetailSchema.ct_Col_SlipMemo3];	// 伝票メモ３
                rst.InsideMemo1 = (string)dr[StockDetailSchema.ct_Col_InsideMemo1];	// 社内メモ１
                rst.InsideMemo2 = (string)dr[StockDetailSchema.ct_Col_InsideMemo2];	// 社内メモ２
                rst.InsideMemo3 = (string)dr[StockDetailSchema.ct_Col_InsideMemo3];	// 社内メモ３
                rst.SupplierCd = (Int32)dr[StockDetailSchema.ct_Col_SupplierCd];	// 仕入先コード
                rst.SupplierSnm = (string)dr[StockDetailSchema.ct_Col_SupplierSnm];	// 仕入先略称
                rst.AddresseeCode = (Int32)dr[StockDetailSchema.ct_Col_AddresseeCode];	// 納品先コード
                rst.AddresseeName = (string)dr[StockDetailSchema.ct_Col_AddresseeName];	// 納品先名称
                rst.DirectSendingCd = (Int32)dr[StockDetailSchema.ct_Col_DirectSendingCd];	// 直送区分
                rst.OrderNumber = (string)dr[StockDetailSchema.ct_Col_OrderNumber];	// 発注番号
                rst.WayToOrder = (Int32)dr[StockDetailSchema.ct_Col_WayToOrder];	// 注文方法
                rst.DeliGdsCmpltDueDate = (DateTime)dr[StockDetailSchema.ct_Col_DeliGdsCmpltDueDate];	// 納品完了予定日
                rst.ExpectDeliveryDate = (DateTime)dr[StockDetailSchema.ct_Col_ExpectDeliveryDate];	// 希望納期
                rst.OrderDataCreateDiv = (Int32)dr[StockDetailSchema.ct_Col_OrderDataCreateDiv];	// 発注データ作成区分
                rst.OrderDataCreateDate = (DateTime)dr[StockDetailSchema.ct_Col_OrderDataCreateDate];	// 発注データ作成日
                rst.OrderFormIssuedDiv = (Int32)dr[StockDetailSchema.ct_Col_OrderFormIssuedDiv];	// 発注書発行済区分
                rst.StockCountDifference = (Double)dr[StockDetailSchema.ct_Col_StockCountDifference];	// 仕入差分数
                rst.DtlRelationGuid = (Guid)dr[StockDetailSchema.ct_Col_DtlRelationGuid];	// 明細関連付けGUID
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

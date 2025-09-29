//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 仕入データアクセスクラス
// プログラム概要   : 仕入データアクセスを行う
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
	/// 仕入データアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 仕入データアクセスクラス</br>
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
        # region 仕入データ追加＜データクラス→データーテーブル＞
        /// <summary>
        /// 仕入データ追加＜データクラス→データーテーブル＞
        /// </summary>
        /// <param name="tbl">データーテーブル</param>
        /// <param name="rst">仕入データ</param>
        /// <param name="commonSlipNo">共通伝票番号</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int InsertTableFromStockSlipWork(DataTable tbl, StockSlipWork stockSlipWork, string commonSlipNo, out string message)
        {
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                DataRow dr = tbl.NewRow();
                CreateStockSlipSchema(ref dr, stockSlipWork, commonSlipNo);
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

        # region 仕入データ更新＜データクラス→データーテーブル＞
        /// <summary>
        /// 仕入データ更新＜データクラス→データーテーブル＞
        /// </summary>
        /// <param name="tbl">データーテーブル</param>
        /// <param name="rst">仕入データ</param>
        /// <param name="commonSlipNo">共通伝票番号</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int UpdateTableFromStockSlipWork(DataTable tbl, StockSlipWork stockSlipWork, string commonSlipNo, out string message)
        {
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                DataRow stockSlipRow = FindStockSlipDataTable(tbl, stockSlipWork.SupplierFormal, commonSlipNo, out message);

                //仕入データDataTableの更新
                if (stockSlipRow != null)
                {
                    CreateStockSlipSchema(ref stockSlipRow, stockSlipWork);
                }
                //仕入データDataTableの追加
                else
                {
                    status = InsertTableFromStockSlipWork(tbl, stockSlipWork, commonSlipNo, out message);
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

        # region 仕入データの読込
        /// <summary>
        /// 仕入データの読込
        /// </summary>
        /// <param name="tbl">データーテーブル</param>
        /// <param name="supplierFormal">仕入形式</param>
        /// <param name="commonSlipNo">共通伝票番号</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>仕入データ</returns>
        public StockSlipWork ReadStockSlipWork(DataTable tbl, int supplierFormal, string commonSlipNo, out string message)
        {
            //変数の初期化
            StockSlipWork stockSlipWork = null;
            message = "";

            try
            {
                DataRow stockSlipRow = FindStockSlipDataTable(tbl, supplierFormal, commonSlipNo, out message);

                stockSlipWork = CreateStockSlipWorkFromSchema(stockSlipRow);
            }
            catch (Exception ex)
            {
                stockSlipWork = null;
                message = ex.Message;
            }

            return (stockSlipWork);
        }
        # endregion

        # region 仕入データ＜DataRow → クラス＞作成
        /// <summary>
        /// 仕入データ＜DataRow → クラス＞作成
        /// </summary>
        /// <param name="dr">テーブルRow</param>
        /// <returns>仕入データクラス</returns>
        public StockSlipWork CreateStockSlipWorkFromSchema(DataRow dr)
        {
            StockSlipWork rst = new StockSlipWork();

            try
            {
                rst.CreateDateTime = (DateTime)dr[StockSlipSchema.ct_Col_CreateDateTime];	// 作成日時
                rst.UpdateDateTime = (DateTime)dr[StockSlipSchema.ct_Col_UpdateDateTime];	// 更新日時
                rst.EnterpriseCode = (string)dr[StockSlipSchema.ct_Col_EnterpriseCode];	// 企業コード
                rst.FileHeaderGuid = (Guid)dr[StockSlipSchema.ct_Col_FileHeaderGuid];	// GUID
                rst.UpdEmployeeCode = (string)dr[StockSlipSchema.ct_Col_UpdEmployeeCode];	// 更新従業員コード
                rst.UpdAssemblyId1 = (string)dr[StockSlipSchema.ct_Col_UpdAssemblyId1];	// 更新アセンブリID1
                rst.UpdAssemblyId2 = (string)dr[StockSlipSchema.ct_Col_UpdAssemblyId2];	// 更新アセンブリID2
                rst.LogicalDeleteCode = (Int32)dr[StockSlipSchema.ct_Col_LogicalDeleteCode];	// 論理削除区分
                rst.SupplierFormal = (Int32)dr[StockSlipSchema.ct_Col_SupplierFormal];	// 仕入形式
                rst.SupplierSlipNo = (Int32)dr[StockSlipSchema.ct_Col_SupplierSlipNo];	// 仕入伝票番号
                rst.SectionCode = (string)dr[StockSlipSchema.ct_Col_SectionCode];	// 拠点コード
                rst.SubSectionCode = (Int32)dr[StockSlipSchema.ct_Col_SubSectionCode];	// 部門コード
                rst.DebitNoteDiv = (Int32)dr[StockSlipSchema.ct_Col_DebitNoteDiv];	// 赤伝区分
                rst.DebitNLnkSuppSlipNo = (Int32)dr[StockSlipSchema.ct_Col_DebitNLnkSuppSlipNo];	// 赤黒連結仕入伝票番号
                rst.SupplierSlipCd = (Int32)dr[StockSlipSchema.ct_Col_SupplierSlipCd];	// 仕入伝票区分
                rst.StockGoodsCd = (Int32)dr[StockSlipSchema.ct_Col_StockGoodsCd];	// 仕入商品区分
                rst.AccPayDivCd = (Int32)dr[StockSlipSchema.ct_Col_AccPayDivCd];	// 買掛区分
                rst.StockSectionCd = (string)dr[StockSlipSchema.ct_Col_StockSectionCd];	// 仕入拠点コード
                rst.StockAddUpSectionCd = (string)dr[StockSlipSchema.ct_Col_StockAddUpSectionCd];	// 仕入計上拠点コード
                rst.StockSlipUpdateCd = (Int32)dr[StockSlipSchema.ct_Col_StockSlipUpdateCd];	// 仕入伝票更新区分
                rst.InputDay = (DateTime)dr[StockSlipSchema.ct_Col_InputDay];	// 入力日
                rst.ArrivalGoodsDay = (DateTime)dr[StockSlipSchema.ct_Col_ArrivalGoodsDay];	// 入荷日
                rst.StockDate = (DateTime)dr[StockSlipSchema.ct_Col_StockDate];	// 仕入日
                rst.StockAddUpADate = (DateTime)dr[StockSlipSchema.ct_Col_StockAddUpADate];	// 仕入計上日付
                rst.DelayPaymentDiv = (Int32)dr[StockSlipSchema.ct_Col_DelayPaymentDiv];	// 来勘区分
                rst.PayeeCode = (Int32)dr[StockSlipSchema.ct_Col_PayeeCode];	// 支払先コード
                rst.PayeeSnm = (string)dr[StockSlipSchema.ct_Col_PayeeSnm];	// 支払先略称
                rst.SupplierCd = (Int32)dr[StockSlipSchema.ct_Col_SupplierCd];	// 仕入先コード
                rst.SupplierNm1 = (string)dr[StockSlipSchema.ct_Col_SupplierNm1];	// 仕入先名1
                rst.SupplierNm2 = (string)dr[StockSlipSchema.ct_Col_SupplierNm2];	// 仕入先名2
                rst.SupplierSnm = (string)dr[StockSlipSchema.ct_Col_SupplierSnm];	// 仕入先略称
                rst.BusinessTypeCode = (Int32)dr[StockSlipSchema.ct_Col_BusinessTypeCode];	// 業種コード
                rst.BusinessTypeName = (string)dr[StockSlipSchema.ct_Col_BusinessTypeName];	// 業種名称
                rst.SalesAreaCode = (Int32)dr[StockSlipSchema.ct_Col_SalesAreaCode];	// 販売エリアコード
                rst.SalesAreaName = (string)dr[StockSlipSchema.ct_Col_SalesAreaName];	// 販売エリア名称
                rst.StockInputCode = (string)dr[StockSlipSchema.ct_Col_StockInputCode];	// 仕入入力者コード
                rst.StockInputName = (string)dr[StockSlipSchema.ct_Col_StockInputName];	// 仕入入力者名称
                rst.StockAgentCode = (string)dr[StockSlipSchema.ct_Col_StockAgentCode];	// 仕入担当者コード
                rst.StockAgentName = (string)dr[StockSlipSchema.ct_Col_StockAgentName];	// 仕入担当者名称
                rst.SuppTtlAmntDspWayCd = (Int32)dr[StockSlipSchema.ct_Col_SuppTtlAmntDspWayCd];	// 仕入先総額表示方法区分
                rst.TtlAmntDispRateApy = (Int32)dr[StockSlipSchema.ct_Col_TtlAmntDispRateApy];	// 総額表示掛率適用区分
                rst.StockTotalPrice = (Int64)dr[StockSlipSchema.ct_Col_StockTotalPrice];	// 仕入金額合計
                rst.StockSubttlPrice = (Int64)dr[StockSlipSchema.ct_Col_StockSubttlPrice];	// 仕入金額小計
                rst.StockTtlPricTaxInc = (Int64)dr[StockSlipSchema.ct_Col_StockTtlPricTaxInc];	// 仕入金額計（税込み）
                rst.StockTtlPricTaxExc = (Int64)dr[StockSlipSchema.ct_Col_StockTtlPricTaxExc];	// 仕入金額計（税抜き）
                rst.StockNetPrice = (Int64)dr[StockSlipSchema.ct_Col_StockNetPrice];	// 仕入正価金額
                rst.StockPriceConsTax = (Int64)dr[StockSlipSchema.ct_Col_StockPriceConsTax];	// 仕入金額消費税額
                rst.TtlItdedStcOutTax = (Int64)dr[StockSlipSchema.ct_Col_TtlItdedStcOutTax];	// 仕入外税対象額合計
                rst.TtlItdedStcInTax = (Int64)dr[StockSlipSchema.ct_Col_TtlItdedStcInTax];	// 仕入内税対象額合計
                rst.TtlItdedStcTaxFree = (Int64)dr[StockSlipSchema.ct_Col_TtlItdedStcTaxFree];	// 仕入非課税対象額合計
                rst.StockOutTax = (Int64)dr[StockSlipSchema.ct_Col_StockOutTax];	// 仕入金額消費税額（外税）
                rst.StckPrcConsTaxInclu = (Int64)dr[StockSlipSchema.ct_Col_StckPrcConsTaxInclu];	// 仕入金額消費税額（内税）
                rst.StckDisTtlTaxExc = (Int64)dr[StockSlipSchema.ct_Col_StckDisTtlTaxExc];	// 仕入値引金額計（税抜き）
                rst.ItdedStockDisOutTax = (Int64)dr[StockSlipSchema.ct_Col_ItdedStockDisOutTax];	// 仕入値引外税対象額合計
                rst.ItdedStockDisInTax = (Int64)dr[StockSlipSchema.ct_Col_ItdedStockDisInTax];	// 仕入値引内税対象額合計
                rst.ItdedStockDisTaxFre = (Int64)dr[StockSlipSchema.ct_Col_ItdedStockDisTaxFre];	// 仕入値引非課税対象額合計
                rst.StockDisOutTax = (Int64)dr[StockSlipSchema.ct_Col_StockDisOutTax];	// 仕入値引消費税額（外税）
                rst.StckDisTtlTaxInclu = (Int64)dr[StockSlipSchema.ct_Col_StckDisTtlTaxInclu];	// 仕入値引消費税額（内税）
                rst.TaxAdjust = (Int64)dr[StockSlipSchema.ct_Col_TaxAdjust];	// 消費税調整額
                rst.BalanceAdjust = (Int64)dr[StockSlipSchema.ct_Col_BalanceAdjust];	// 残高調整額
                rst.SuppCTaxLayCd = (Int32)dr[StockSlipSchema.ct_Col_SuppCTaxLayCd];	// 仕入先消費税転嫁方式コード
                rst.SupplierConsTaxRate = (Double)dr[StockSlipSchema.ct_Col_SupplierConsTaxRate];	// 仕入先消費税税率
                rst.AccPayConsTax = (Int64)dr[StockSlipSchema.ct_Col_AccPayConsTax];	// 買掛消費税
                rst.StockFractionProcCd = (Int32)dr[StockSlipSchema.ct_Col_StockFractionProcCd];	// 仕入端数処理区分
                rst.AutoPayment = (Int32)dr[StockSlipSchema.ct_Col_AutoPayment];	// 自動支払区分
                rst.AutoPaySlipNum = (Int32)dr[StockSlipSchema.ct_Col_AutoPaySlipNum];	// 自動支払伝票番号
                rst.RetGoodsReasonDiv = (Int32)dr[StockSlipSchema.ct_Col_RetGoodsReasonDiv];	// 返品理由コード
                rst.RetGoodsReason = (string)dr[StockSlipSchema.ct_Col_RetGoodsReason];	// 返品理由
                rst.PartySaleSlipNum = (string)dr[StockSlipSchema.ct_Col_PartySaleSlipNum];	// 相手先伝票番号
                rst.SupplierSlipNote1 = (string)dr[StockSlipSchema.ct_Col_SupplierSlipNote1];	// 仕入伝票備考1
                rst.SupplierSlipNote2 = (string)dr[StockSlipSchema.ct_Col_SupplierSlipNote2];	// 仕入伝票備考2
                rst.DetailRowCount = (Int32)dr[StockSlipSchema.ct_Col_DetailRowCount];	// 明細行数
                rst.EdiSendDate = (DateTime)dr[StockSlipSchema.ct_Col_EdiSendDate];	// ＥＤＩ送信日
                rst.EdiTakeInDate = (DateTime)dr[StockSlipSchema.ct_Col_EdiTakeInDate];	// ＥＤＩ取込日
                rst.UoeRemark1 = (string)dr[StockSlipSchema.ct_Col_UoeRemark1];	// ＵＯＥリマーク１
                rst.UoeRemark2 = (string)dr[StockSlipSchema.ct_Col_UoeRemark2];	// ＵＯＥリマーク２
                rst.SlipPrintDivCd = (Int32)dr[StockSlipSchema.ct_Col_SlipPrintDivCd];	// 伝票発行区分
                rst.SlipPrintFinishCd = (Int32)dr[StockSlipSchema.ct_Col_SlipPrintFinishCd];	// 伝票発行済区分
                rst.StockSlipPrintDate = (DateTime)dr[StockSlipSchema.ct_Col_StockSlipPrintDate];	// 仕入伝票発行日
                rst.SlipPrtSetPaperId = (string)dr[StockSlipSchema.ct_Col_SlipPrtSetPaperId];	// 伝票印刷設定用帳票ID
                rst.SlipAddressDiv = (Int32)dr[StockSlipSchema.ct_Col_SlipAddressDiv];	// 伝票住所区分
                rst.AddresseeCode = (Int32)dr[StockSlipSchema.ct_Col_AddresseeCode];	// 納品先コード
                rst.AddresseeName = (string)dr[StockSlipSchema.ct_Col_AddresseeName];	// 納品先名称
                rst.AddresseeName2 = (string)dr[StockSlipSchema.ct_Col_AddresseeName2];	// 納品先名称2
                rst.AddresseePostNo = (string)dr[StockSlipSchema.ct_Col_AddresseePostNo];	// 納品先郵便番号
                rst.AddresseeAddr1 = (string)dr[StockSlipSchema.ct_Col_AddresseeAddr1];	// 納品先住所1(都道府県市区郡・町村・字)
                rst.AddresseeAddr3 = (string)dr[StockSlipSchema.ct_Col_AddresseeAddr3];	// 納品先住所3(番地)
                rst.AddresseeAddr4 = (string)dr[StockSlipSchema.ct_Col_AddresseeAddr4];	// 納品先住所4(アパート名称)
                rst.AddresseeTelNo = (string)dr[StockSlipSchema.ct_Col_AddresseeTelNo];	// 納品先電話番号
                rst.AddresseeFaxNo = (string)dr[StockSlipSchema.ct_Col_AddresseeFaxNo];	// 納品先FAX番号
                rst.DirectSendingCd = (Int32)dr[StockSlipSchema.ct_Col_DirectSendingCd];	// 直送区分
            }
            catch (Exception)
            {
                rst = null;
            }
            return (rst);
        }
        # endregion
        # endregion

        // ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods
        # region 仕入データの検索
        /// <summary>
        /// 仕入明細の検索
        /// </summary>
        /// <param name="tbl">データーテーブル</param>
        /// <param name="supplierFormal">仕入形式</param>
        /// <param name="commonSlipNo">共通伝票番号</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>DataRow</returns>
        private DataRow FindStockSlipDataTable(DataTable tbl, int supplierFormal, string commonSlipNo, out string message)
        {
            //変数の初期化
            DataRow stockSlipRow = null;
            message = "";

            try
            {
                object[] findStockSlip = new object[2];
                findStockSlip[0] = supplierFormal;
                findStockSlip[1] = commonSlipNo;
                stockSlipRow = tbl.Rows.Find(findStockSlip);
            }
            catch (Exception ex)
            {
                stockSlipRow = null;
                message = ex.Message;
            }

            return (stockSlipRow);
        }
        # endregion

        # region 仕入データテーブルRow作成＜UOE発注番号(ユーニーク番号)更新あり＞
        /// <summary>
        /// 仕入データテーブルRow作成＜UOE発注番号(ユーニーク番号)更新あり＞
        /// </summary>
        /// <param name="dr">テーブルRow</param>
        /// <param name="rst">仕入データクラス</param>
        /// <param name="commonSlipNo">共通伝票番号</param>
        private void CreateStockSlipSchema(ref DataRow dr, StockSlipWork rst, string commonSlipNo)
        {
            CreateStockSlipSchema(ref dr, rst);

            dr[StockSlipSchema.ct_Col_CommonSlipNo] = commonSlipNo;   //共通伝票番号
        }
        # endregion

        # region 仕入データテーブルRow作成
        /// <summary>
        /// 仕入データテーブルRow作成
        /// </summary>
        /// <param name="dr">テーブルRow</param>
        /// <param name="rst">仕入データクラス</param>
        private void CreateStockSlipSchema(ref DataRow dr, StockSlipWork rst)
        {
            dr[StockSlipSchema.ct_Col_CreateDateTime] = rst.CreateDateTime;	// 作成日時
            dr[StockSlipSchema.ct_Col_UpdateDateTime] = rst.UpdateDateTime;	// 更新日時
            dr[StockSlipSchema.ct_Col_EnterpriseCode] = rst.EnterpriseCode;	// 企業コード
            dr[StockSlipSchema.ct_Col_FileHeaderGuid] = rst.FileHeaderGuid;	// GUID
            dr[StockSlipSchema.ct_Col_UpdEmployeeCode] = rst.UpdEmployeeCode;	// 更新従業員コード
            dr[StockSlipSchema.ct_Col_UpdAssemblyId1] = rst.UpdAssemblyId1;	// 更新アセンブリID1
            dr[StockSlipSchema.ct_Col_UpdAssemblyId2] = rst.UpdAssemblyId2;	// 更新アセンブリID2
            dr[StockSlipSchema.ct_Col_LogicalDeleteCode] = rst.LogicalDeleteCode;	// 論理削除区分
            dr[StockSlipSchema.ct_Col_SupplierFormal] = rst.SupplierFormal;	// 仕入形式
            dr[StockSlipSchema.ct_Col_SupplierSlipNo] = rst.SupplierSlipNo;	// 仕入伝票番号
            dr[StockSlipSchema.ct_Col_SectionCode] = rst.SectionCode;	// 拠点コード
            dr[StockSlipSchema.ct_Col_SubSectionCode] = rst.SubSectionCode;	// 部門コード
            dr[StockSlipSchema.ct_Col_DebitNoteDiv] = rst.DebitNoteDiv;	// 赤伝区分
            dr[StockSlipSchema.ct_Col_DebitNLnkSuppSlipNo] = rst.DebitNLnkSuppSlipNo;	// 赤黒連結仕入伝票番号
            dr[StockSlipSchema.ct_Col_SupplierSlipCd] = rst.SupplierSlipCd;	// 仕入伝票区分
            dr[StockSlipSchema.ct_Col_StockGoodsCd] = rst.StockGoodsCd;	// 仕入商品区分
            dr[StockSlipSchema.ct_Col_AccPayDivCd] = rst.AccPayDivCd;	// 買掛区分
            dr[StockSlipSchema.ct_Col_StockSectionCd] = rst.StockSectionCd;	// 仕入拠点コード
            dr[StockSlipSchema.ct_Col_StockAddUpSectionCd] = rst.StockAddUpSectionCd;	// 仕入計上拠点コード
            dr[StockSlipSchema.ct_Col_StockSlipUpdateCd] = rst.StockSlipUpdateCd;	// 仕入伝票更新区分
            dr[StockSlipSchema.ct_Col_InputDay] = rst.InputDay;	// 入力日
            dr[StockSlipSchema.ct_Col_ArrivalGoodsDay] = rst.ArrivalGoodsDay;	// 入荷日
            dr[StockSlipSchema.ct_Col_StockDate] = rst.StockDate;	// 仕入日
            dr[StockSlipSchema.ct_Col_StockAddUpADate] = rst.StockAddUpADate;	// 仕入計上日付
            dr[StockSlipSchema.ct_Col_DelayPaymentDiv] = rst.DelayPaymentDiv;	// 来勘区分
            dr[StockSlipSchema.ct_Col_PayeeCode] = rst.PayeeCode;	// 支払先コード
            dr[StockSlipSchema.ct_Col_PayeeSnm] = rst.PayeeSnm;	// 支払先略称
            dr[StockSlipSchema.ct_Col_SupplierCd] = rst.SupplierCd;	// 仕入先コード
            dr[StockSlipSchema.ct_Col_SupplierNm1] = rst.SupplierNm1;	// 仕入先名1
            dr[StockSlipSchema.ct_Col_SupplierNm2] = rst.SupplierNm2;	// 仕入先名2
            dr[StockSlipSchema.ct_Col_SupplierSnm] = rst.SupplierSnm;	// 仕入先略称
            dr[StockSlipSchema.ct_Col_BusinessTypeCode] = rst.BusinessTypeCode;	// 業種コード
            dr[StockSlipSchema.ct_Col_BusinessTypeName] = rst.BusinessTypeName;	// 業種名称
            dr[StockSlipSchema.ct_Col_SalesAreaCode] = rst.SalesAreaCode;	// 販売エリアコード
            dr[StockSlipSchema.ct_Col_SalesAreaName] = rst.SalesAreaName;	// 販売エリア名称
            dr[StockSlipSchema.ct_Col_StockInputCode] = rst.StockInputCode;	// 仕入入力者コード
            dr[StockSlipSchema.ct_Col_StockInputName] = rst.StockInputName;	// 仕入入力者名称
            dr[StockSlipSchema.ct_Col_StockAgentCode] = rst.StockAgentCode;	// 仕入担当者コード
            dr[StockSlipSchema.ct_Col_StockAgentName] = rst.StockAgentName;	// 仕入担当者名称
            dr[StockSlipSchema.ct_Col_SuppTtlAmntDspWayCd] = rst.SuppTtlAmntDspWayCd;	// 仕入先総額表示方法区分
            dr[StockSlipSchema.ct_Col_TtlAmntDispRateApy] = rst.TtlAmntDispRateApy;	// 総額表示掛率適用区分
            dr[StockSlipSchema.ct_Col_StockTotalPrice] = rst.StockTotalPrice;	// 仕入金額合計
            dr[StockSlipSchema.ct_Col_StockSubttlPrice] = rst.StockSubttlPrice;	// 仕入金額小計
            dr[StockSlipSchema.ct_Col_StockTtlPricTaxInc] = rst.StockTtlPricTaxInc;	// 仕入金額計（税込み）
            dr[StockSlipSchema.ct_Col_StockTtlPricTaxExc] = rst.StockTtlPricTaxExc;	// 仕入金額計（税抜き）
            dr[StockSlipSchema.ct_Col_StockNetPrice] = rst.StockNetPrice;	// 仕入正価金額
            dr[StockSlipSchema.ct_Col_StockPriceConsTax] = rst.StockPriceConsTax;	// 仕入金額消費税額
            dr[StockSlipSchema.ct_Col_TtlItdedStcOutTax] = rst.TtlItdedStcOutTax;	// 仕入外税対象額合計
            dr[StockSlipSchema.ct_Col_TtlItdedStcInTax] = rst.TtlItdedStcInTax;	// 仕入内税対象額合計
            dr[StockSlipSchema.ct_Col_TtlItdedStcTaxFree] = rst.TtlItdedStcTaxFree;	// 仕入非課税対象額合計
            dr[StockSlipSchema.ct_Col_StockOutTax] = rst.StockOutTax;	// 仕入金額消費税額（外税）
            dr[StockSlipSchema.ct_Col_StckPrcConsTaxInclu] = rst.StckPrcConsTaxInclu;	// 仕入金額消費税額（内税）
            dr[StockSlipSchema.ct_Col_StckDisTtlTaxExc] = rst.StckDisTtlTaxExc;	// 仕入値引金額計（税抜き）
            dr[StockSlipSchema.ct_Col_ItdedStockDisOutTax] = rst.ItdedStockDisOutTax;	// 仕入値引外税対象額合計
            dr[StockSlipSchema.ct_Col_ItdedStockDisInTax] = rst.ItdedStockDisInTax;	// 仕入値引内税対象額合計
            dr[StockSlipSchema.ct_Col_ItdedStockDisTaxFre] = rst.ItdedStockDisTaxFre;	// 仕入値引非課税対象額合計
            dr[StockSlipSchema.ct_Col_StockDisOutTax] = rst.StockDisOutTax;	// 仕入値引消費税額（外税）
            dr[StockSlipSchema.ct_Col_StckDisTtlTaxInclu] = rst.StckDisTtlTaxInclu;	// 仕入値引消費税額（内税）
            dr[StockSlipSchema.ct_Col_TaxAdjust] = rst.TaxAdjust;	// 消費税調整額
            dr[StockSlipSchema.ct_Col_BalanceAdjust] = rst.BalanceAdjust;	// 残高調整額
            dr[StockSlipSchema.ct_Col_SuppCTaxLayCd] = rst.SuppCTaxLayCd;	// 仕入先消費税転嫁方式コード
            dr[StockSlipSchema.ct_Col_SupplierConsTaxRate] = rst.SupplierConsTaxRate;	// 仕入先消費税税率
            dr[StockSlipSchema.ct_Col_AccPayConsTax] = rst.AccPayConsTax;	// 買掛消費税
            dr[StockSlipSchema.ct_Col_StockFractionProcCd] = rst.StockFractionProcCd;	// 仕入端数処理区分
            dr[StockSlipSchema.ct_Col_AutoPayment] = rst.AutoPayment;	// 自動支払区分
            dr[StockSlipSchema.ct_Col_AutoPaySlipNum] = rst.AutoPaySlipNum;	// 自動支払伝票番号
            dr[StockSlipSchema.ct_Col_RetGoodsReasonDiv] = rst.RetGoodsReasonDiv;	// 返品理由コード
            dr[StockSlipSchema.ct_Col_RetGoodsReason] = rst.RetGoodsReason;	// 返品理由
            dr[StockSlipSchema.ct_Col_PartySaleSlipNum] = rst.PartySaleSlipNum;	// 相手先伝票番号
            dr[StockSlipSchema.ct_Col_SupplierSlipNote1] = rst.SupplierSlipNote1;	// 仕入伝票備考1
            dr[StockSlipSchema.ct_Col_SupplierSlipNote2] = rst.SupplierSlipNote2;	// 仕入伝票備考2
            dr[StockSlipSchema.ct_Col_DetailRowCount] = rst.DetailRowCount;	// 明細行数
            dr[StockSlipSchema.ct_Col_EdiSendDate] = rst.EdiSendDate;	// ＥＤＩ送信日
            dr[StockSlipSchema.ct_Col_EdiTakeInDate] = rst.EdiTakeInDate;	// ＥＤＩ取込日
            dr[StockSlipSchema.ct_Col_UoeRemark1] = rst.UoeRemark1;	// ＵＯＥリマーク１
            dr[StockSlipSchema.ct_Col_UoeRemark2] = rst.UoeRemark2;	// ＵＯＥリマーク２
            dr[StockSlipSchema.ct_Col_SlipPrintDivCd] = rst.SlipPrintDivCd;	// 伝票発行区分
            dr[StockSlipSchema.ct_Col_SlipPrintFinishCd] = rst.SlipPrintFinishCd;	// 伝票発行済区分
            dr[StockSlipSchema.ct_Col_StockSlipPrintDate] = rst.StockSlipPrintDate;	// 仕入伝票発行日
            dr[StockSlipSchema.ct_Col_SlipPrtSetPaperId] = rst.SlipPrtSetPaperId;	// 伝票印刷設定用帳票ID
            dr[StockSlipSchema.ct_Col_SlipAddressDiv] = rst.SlipAddressDiv;	// 伝票住所区分
            dr[StockSlipSchema.ct_Col_AddresseeCode] = rst.AddresseeCode;	// 納品先コード
            dr[StockSlipSchema.ct_Col_AddresseeName] = rst.AddresseeName;	// 納品先名称
            dr[StockSlipSchema.ct_Col_AddresseeName2] = rst.AddresseeName2;	// 納品先名称2
            dr[StockSlipSchema.ct_Col_AddresseePostNo] = rst.AddresseePostNo;	// 納品先郵便番号
            dr[StockSlipSchema.ct_Col_AddresseeAddr1] = rst.AddresseeAddr1;	// 納品先住所1(都道府県市区郡・町村・字)
            dr[StockSlipSchema.ct_Col_AddresseeAddr3] = rst.AddresseeAddr3;	// 納品先住所3(番地)
            dr[StockSlipSchema.ct_Col_AddresseeAddr4] = rst.AddresseeAddr4;	// 納品先住所4(アパート名称)
            dr[StockSlipSchema.ct_Col_AddresseeTelNo] = rst.AddresseeTelNo;	// 納品先電話番号
            dr[StockSlipSchema.ct_Col_AddresseeFaxNo] = rst.AddresseeFaxNo;	// 納品先FAX番号
            dr[StockSlipSchema.ct_Col_DirectSendingCd] = rst.DirectSendingCd;	// 直送区分
        }
        # endregion
        # endregion
	}
}

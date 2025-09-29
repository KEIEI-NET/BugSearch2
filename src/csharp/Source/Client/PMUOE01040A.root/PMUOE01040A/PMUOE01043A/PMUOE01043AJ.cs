//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 売上データアクセスクラス
// プログラム概要   : 売上データアクセスを行う
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
	/// 売上データアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 売上データアクセスクラス</br>
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

        # region ●売上データ
        # region 売上データ更新＜データリスト→データーテーブル＞
        /// <summary>
        /// 売上データ更新＜データリスト→データーテーブル＞
        /// </summary>
        /// <param name="tbl">データテーブル</param>
        /// <param name="list">売上データデータリスト</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int UpdateTableFromSalesSlipList(DataTable tbl, List<SalesSlipWork> list, out string message)
        {
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                foreach (SalesSlipWork salesSlipWork in list)
                {
                    status = UpdateTableFromSalesSlipWork(tbl, salesSlipWork, salesSlipWork.SalesSlipNum, out message);
                    if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) break;
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

        # region 売上データ更新＜売上データ→データーテーブル＞
        /// <summary>
        /// 売上データ更新＜売上データ→データーテーブル＞
        /// </summary>
        /// <param name="tbl">データーテーブル</param>
        /// <param name="salesSlipWork">売上データ(仮)</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int UpdateTableFromSalesSlipWork(DataTable tbl, SalesSlipWork salesSlipWork, string tempSalesSlipNum, out string message)
        {
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                //Findパラメータ設定
                object[] findSalesSlip = new object[2];
                findSalesSlip[0] = salesSlipWork.AcptAnOdrStatus;
                findSalesSlip[1] = tempSalesSlipNum;
                DataRow salesSlipRow = tbl.Rows.Find(findSalesSlip);

                //売上データ更新の更新
                if (salesSlipRow != null)
                {
                    CreateSalesSlipSchema(ref salesSlipRow, salesSlipWork);
                }
                //売上データ更新の追加
                else
                {
                    DataRow dr = tbl.NewRow();
                    CreateSalesSlipSchema(ref dr, salesSlipWork);
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

        # region 売上データ追加処理＜SalesSlipWork→SalesSlipTable＞
        /// <summary>
        /// 売上データ追加処理＜SalesSlipWork→SalesSlipTable＞
        /// </summary>
        /// <param name="salesSlipWork">売上データ</param>
        /// <param name="tempSalesSlipNum">売上伝票番号(仮)</param>
        /// <param name="totalCnt">出庫数合計</param>
        /// <param name="slipCd">UOE伝票種別</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int InsertSalesSlipDataTable(SalesSlipWork salesSlipWork, string tempSalesSlipNum, Int32 totalCnt, Int32 slipCd, out string message)
        {
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                //送受信ＪＮＬの保存
                DataRow dr = SalesSlipTable.NewRow();
                CreateSalesSlipSchema(ref dr, salesSlipWork, tempSalesSlipNum, totalCnt, slipCd);
                SalesSlipTable.Rows.Add(dr);
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }

            return (status);
        }
        # endregion

        # region 売上データＲＥＡＤ
        /// <summary>
        /// 売上データＲＥＡＤ
        /// </summary>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="salesSlipNum">売上伝票番号(仮)</param>
        /// <param name="slipCd">UOE伝票種別</param>
        /// <returns>ステータス</returns>
        public DataRow ReadSalesSlipDataTable(Int32 acptAnOdrStatus, string tempSalesSlipNum)
        {
            //変数の初期化
            DataRow salesSlipRow = null;

            try
            {
                object[] findSalesSlip = new object[2];
                findSalesSlip[0] = acptAnOdrStatus;
                findSalesSlip[1] = tempSalesSlipNum;
                salesSlipRow = SalesSlipTable.Rows.Find(findSalesSlip);
            }
            catch (Exception)
            {
                salesSlipRow = null;
            }

            return (salesSlipRow);
        }
        # endregion


        # endregion

        # region ●受注データ
        # region 受注データ追加処理＜SalesSlipWork→AcptSlipTable＞
        /// <summary>
        /// 受注データ追加処理＜SalesSlipWork→AcptSlipTable＞
        /// </summary>
        /// <param name="list">受注データ</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int InsertAcptTblFromSalesSlipWork(SalesSlipWork salesSlipWork, out string message)
        {
            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                //送受信ＪＮＬの保存
                DataRow dr = AcptSlipTable.NewRow();
                CreateSalesSlipSchema(ref dr, salesSlipWork);
                AcptSlipTable.Rows.Add(dr);
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }

            return (status);
        }
        # endregion

        # region 受注データＲＥＡＤ
        /// <summary>
        /// 受注データＲＥＡＤ
        /// </summary>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <returns>売上データクラス</returns>
        public SalesSlipWork ReadAcptSlipDataTable(Int32 acptAnOdrStatus, string salesSlipNum)
        {
            SalesSlipWork salesSlipWork = null;

            try
            {
                object[] findSalesSlip = new object[2];
                findSalesSlip[0] = acptAnOdrStatus;
                findSalesSlip[1] = salesSlipNum;
                DataRow salesSlipRow = AcptSlipTable.Rows.Find(findSalesSlip);
                salesSlipWork = CreateSalesSlipWorkFromSchemaProc(salesSlipRow);
            }
            catch (Exception)
            {
                salesSlipWork = null;
            }

            return (salesSlipWork);
        }
        # endregion
        # endregion

        # region ●共通
        # region 売上(受注)データ＜DataRow → クラス＞作成
        /// <summary>
        /// 売上(受注)データ＜DataRow → クラス＞作成
        /// </summary>
        /// <param name="dr">テーブルRow</param>
        /// <returns>売上データ</returns>
        public SalesSlipWork CreateSalesSlipWorkFromSchema(DataRow dr)
        {
            return (CreateSalesSlipWorkFromSchemaProc(dr));
        }

        # endregion
        # endregion

        # endregion
        // ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods
        # region 売上(受注)データテーブルRow作成
        /// <summary>
        /// 売上(受注)データテーブルRow作成
        /// </summary>
        /// <param name="dr">テーブルRow</param>
        /// <param name="rst">売上(受注)データクラス</param>
        /// <param name="tempSalesSlipNum">売上伝票番号(仮)</param>
        /// <param name="totalCnt">出庫数合計</param>
        /// <param name="slipCd">UOE伝票種別</param>
        private void CreateSalesSlipSchema(ref DataRow dr, SalesSlipWork rst, string tempSalesSlipNum, Int32 totalCnt, Int32 slipCd)
        {
            CreateSalesSlipSchema(ref dr, rst);

            dr[SalesSlipSchema.ct_Col_TempSalesSlipNum] = tempSalesSlipNum;
            dr[SalesSlipSchema.ct_Col_TotalCnt] = totalCnt;
            dr[SalesSlipSchema.ct_Col_SlipCd] = slipCd;
        }

        /// <summary>
        /// 売上(受注)データテーブルRow作成
        /// </summary>
        /// <param name="dr">テーブルRow</param>
        /// <param name="rst">売上(受注)データクラス</param>
        private void CreateSalesSlipSchema(ref DataRow dr, SalesSlipWork rst)
        {
            //dr[SalesSlipSchema.ct_Col_CreateDateTime] = rst.CreateDateTime;	// 作成日時
            //dr[SalesSlipSchema.ct_Col_UpdateDateTime] = rst.UpdateDateTime;	// 更新日時
            dr[SalesSlipSchema.ct_Col_EnterpriseCode] = rst.EnterpriseCode;	// 企業コード
            //dr[SalesSlipSchema.ct_Col_FileHeaderGuid] = rst.FileHeaderGuid;	// GUID
            //dr[SalesSlipSchema.ct_Col_UpdEmployeeCode] = rst.UpdEmployeeCode;	// 更新従業員コード
            //dr[SalesSlipSchema.ct_Col_UpdAssemblyId1] = rst.UpdAssemblyId1;	// 更新アセンブリID1
            //dr[SalesSlipSchema.ct_Col_UpdAssemblyId2] = rst.UpdAssemblyId2;	// 更新アセンブリID2
            dr[SalesSlipSchema.ct_Col_LogicalDeleteCode] = rst.LogicalDeleteCode;	// 論理削除区分
            dr[SalesSlipSchema.ct_Col_AcptAnOdrStatus] = rst.AcptAnOdrStatus;	// 受注ステータス
            dr[SalesSlipSchema.ct_Col_SalesSlipNum] = rst.SalesSlipNum;	// 売上伝票番号
            dr[SalesSlipSchema.ct_Col_SectionCode] = rst.SectionCode;	// 拠点コード
            dr[SalesSlipSchema.ct_Col_SubSectionCode] = rst.SubSectionCode;	// 部門コード
            dr[SalesSlipSchema.ct_Col_DebitNoteDiv] = rst.DebitNoteDiv;	// 赤伝区分
            dr[SalesSlipSchema.ct_Col_DebitNLnkSalesSlNum] = rst.DebitNLnkSalesSlNum;	// 赤黒連結売上伝票番号
            dr[SalesSlipSchema.ct_Col_SalesSlipCd] = rst.SalesSlipCd;	// 売上伝票区分
            dr[SalesSlipSchema.ct_Col_SalesGoodsCd] = rst.SalesGoodsCd;	// 売上商品区分
            dr[SalesSlipSchema.ct_Col_AccRecDivCd] = rst.AccRecDivCd;	// 売掛区分
            dr[SalesSlipSchema.ct_Col_SalesInpSecCd] = rst.SalesInpSecCd;	// 売上入力拠点コード
            dr[SalesSlipSchema.ct_Col_DemandAddUpSecCd] = rst.DemandAddUpSecCd;	// 請求計上拠点コード
            dr[SalesSlipSchema.ct_Col_ResultsAddUpSecCd] = rst.ResultsAddUpSecCd;	// 実績計上拠点コード
            dr[SalesSlipSchema.ct_Col_UpdateSecCd] = rst.UpdateSecCd;	// 更新拠点コード
            dr[SalesSlipSchema.ct_Col_SalesSlipUpdateCd] = rst.SalesSlipUpdateCd;	// 売上伝票更新区分
            dr[SalesSlipSchema.ct_Col_SearchSlipDate] = rst.SearchSlipDate;	// 伝票検索日付
            dr[SalesSlipSchema.ct_Col_ShipmentDay] = rst.ShipmentDay;	// 出荷日付
            dr[SalesSlipSchema.ct_Col_SalesDate] = rst.SalesDate;	// 売上日付
            dr[SalesSlipSchema.ct_Col_AddUpADate] = rst.AddUpADate;	// 計上日付
            dr[SalesSlipSchema.ct_Col_DelayPaymentDiv] = rst.DelayPaymentDiv;	// 来勘区分
            dr[SalesSlipSchema.ct_Col_EstimateFormNo] = rst.EstimateFormNo;	// 見積書番号
            dr[SalesSlipSchema.ct_Col_EstimateDivide] = rst.EstimateDivide;	// 見積区分
            dr[SalesSlipSchema.ct_Col_InputAgenCd] = rst.InputAgenCd;	// 入力担当者コード
            dr[SalesSlipSchema.ct_Col_InputAgenNm] = rst.InputAgenNm;	// 入力担当者名称
            dr[SalesSlipSchema.ct_Col_SalesInputCode] = rst.SalesInputCode;	// 売上入力者コード
            dr[SalesSlipSchema.ct_Col_SalesInputName] = rst.SalesInputName;	// 売上入力者名称
            dr[SalesSlipSchema.ct_Col_FrontEmployeeCd] = rst.FrontEmployeeCd;	// 受付従業員コード
            dr[SalesSlipSchema.ct_Col_FrontEmployeeNm] = rst.FrontEmployeeNm;	// 受付従業員名称
            dr[SalesSlipSchema.ct_Col_SalesEmployeeCd] = rst.SalesEmployeeCd;	// 販売従業員コード
            dr[SalesSlipSchema.ct_Col_SalesEmployeeNm] = rst.SalesEmployeeNm;	// 販売従業員名称
            dr[SalesSlipSchema.ct_Col_TotalAmountDispWayCd] = rst.TotalAmountDispWayCd;	// 総額表示方法区分
            dr[SalesSlipSchema.ct_Col_TtlAmntDispRateApy] = rst.TtlAmntDispRateApy;	// 総額表示掛率適用区分
            dr[SalesSlipSchema.ct_Col_SalesTotalTaxInc] = rst.SalesTotalTaxInc;	// 売上伝票合計（税込み）
            dr[SalesSlipSchema.ct_Col_SalesTotalTaxExc] = rst.SalesTotalTaxExc;	// 売上伝票合計（税抜き）
            dr[SalesSlipSchema.ct_Col_SalesPrtTotalTaxInc] = rst.SalesPrtTotalTaxInc;	// 売上部品合計（税込み）
            dr[SalesSlipSchema.ct_Col_SalesPrtTotalTaxExc] = rst.SalesPrtTotalTaxExc;	// 売上部品合計（税抜き）
            dr[SalesSlipSchema.ct_Col_SalesWorkTotalTaxInc] = rst.SalesWorkTotalTaxInc;	// 売上作業合計（税込み）
            dr[SalesSlipSchema.ct_Col_SalesWorkTotalTaxExc] = rst.SalesWorkTotalTaxExc;	// 売上作業合計（税抜き）
            dr[SalesSlipSchema.ct_Col_SalesSubtotalTaxInc] = rst.SalesSubtotalTaxInc;	// 売上小計（税込み）
            dr[SalesSlipSchema.ct_Col_SalesSubtotalTaxExc] = rst.SalesSubtotalTaxExc;	// 売上小計（税抜き）
            dr[SalesSlipSchema.ct_Col_SalesPrtSubttlInc] = rst.SalesPrtSubttlInc;	// 売上部品小計（税込み）
            dr[SalesSlipSchema.ct_Col_SalesPrtSubttlExc] = rst.SalesPrtSubttlExc;	// 売上部品小計（税抜き）
            dr[SalesSlipSchema.ct_Col_SalesWorkSubttlInc] = rst.SalesWorkSubttlInc;	// 売上作業小計（税込み）
            dr[SalesSlipSchema.ct_Col_SalesWorkSubttlExc] = rst.SalesWorkSubttlExc;	// 売上作業小計（税抜き）
            dr[SalesSlipSchema.ct_Col_SalesNetPrice] = rst.SalesNetPrice;	// 売上正価金額
            dr[SalesSlipSchema.ct_Col_SalesSubtotalTax] = rst.SalesSubtotalTax;	// 売上小計（税）
            dr[SalesSlipSchema.ct_Col_ItdedSalesOutTax] = rst.ItdedSalesOutTax;	// 売上外税対象額
            dr[SalesSlipSchema.ct_Col_ItdedSalesInTax] = rst.ItdedSalesInTax;	// 売上内税対象額
            dr[SalesSlipSchema.ct_Col_SalSubttlSubToTaxFre] = rst.SalSubttlSubToTaxFre;	// 売上小計非課税対象額
            dr[SalesSlipSchema.ct_Col_SalesOutTax] = rst.SalesOutTax;	// 売上金額消費税額（外税）
            dr[SalesSlipSchema.ct_Col_SalAmntConsTaxInclu] = rst.SalAmntConsTaxInclu;	// 売上金額消費税額（内税）
            dr[SalesSlipSchema.ct_Col_SalesDisTtlTaxExc] = rst.SalesDisTtlTaxExc;	// 売上値引金額計（税抜き）
            dr[SalesSlipSchema.ct_Col_ItdedSalesDisOutTax] = rst.ItdedSalesDisOutTax;	// 売上値引外税対象額合計
            dr[SalesSlipSchema.ct_Col_ItdedSalesDisInTax] = rst.ItdedSalesDisInTax;	// 売上値引内税対象額合計
            dr[SalesSlipSchema.ct_Col_ItdedPartsDisOutTax] = rst.ItdedPartsDisOutTax;	// 部品値引対象額合計（税抜き）
            dr[SalesSlipSchema.ct_Col_ItdedPartsDisInTax] = rst.ItdedPartsDisInTax;	// 部品値引対象額合計（税込み）
            dr[SalesSlipSchema.ct_Col_ItdedWorkDisOutTax] = rst.ItdedWorkDisOutTax;	// 作業値引対象額合計（税抜き）
            dr[SalesSlipSchema.ct_Col_ItdedWorkDisInTax] = rst.ItdedWorkDisInTax;	// 作業値引対象額合計（税込み）
            dr[SalesSlipSchema.ct_Col_ItdedSalesDisTaxFre] = rst.ItdedSalesDisTaxFre;	// 売上値引非課税対象額合計
            dr[SalesSlipSchema.ct_Col_SalesDisOutTax] = rst.SalesDisOutTax;	// 売上値引消費税額（外税）
            dr[SalesSlipSchema.ct_Col_SalesDisTtlTaxInclu] = rst.SalesDisTtlTaxInclu;	// 売上値引消費税額（内税）
            dr[SalesSlipSchema.ct_Col_PartsDiscountRate] = rst.PartsDiscountRate;	// 部品値引率
            dr[SalesSlipSchema.ct_Col_RavorDiscountRate] = rst.RavorDiscountRate;	// 工賃値引率
            dr[SalesSlipSchema.ct_Col_TotalCost] = rst.TotalCost;	// 原価金額計
            dr[SalesSlipSchema.ct_Col_ConsTaxLayMethod] = rst.ConsTaxLayMethod;	// 消費税転嫁方式
            dr[SalesSlipSchema.ct_Col_ConsTaxRate] = rst.ConsTaxRate;	// 消費税税率
            dr[SalesSlipSchema.ct_Col_FractionProcCd] = rst.FractionProcCd;	// 端数処理区分
            dr[SalesSlipSchema.ct_Col_AccRecConsTax] = rst.AccRecConsTax;	// 売掛消費税
            dr[SalesSlipSchema.ct_Col_AutoDepositCd] = rst.AutoDepositCd;	// 自動入金区分
            dr[SalesSlipSchema.ct_Col_AutoDepositSlipNo] = rst.AutoDepositSlipNo;	// 自動入金伝票番号
            dr[SalesSlipSchema.ct_Col_DepositAllowanceTtl] = rst.DepositAllowanceTtl;	// 入金引当合計額
            dr[SalesSlipSchema.ct_Col_DepositAlwcBlnce] = rst.DepositAlwcBlnce;	// 入金引当残高
            dr[SalesSlipSchema.ct_Col_ClaimCode] = rst.ClaimCode;	// 請求先コード
            dr[SalesSlipSchema.ct_Col_ClaimSnm] = rst.ClaimSnm;	// 請求先略称
            dr[SalesSlipSchema.ct_Col_CustomerCode] = rst.CustomerCode;	// 得意先コード
            dr[SalesSlipSchema.ct_Col_CustomerName] = rst.CustomerName;	// 得意先名称
            dr[SalesSlipSchema.ct_Col_CustomerName2] = rst.CustomerName2;	// 得意先名称2
            dr[SalesSlipSchema.ct_Col_CustomerSnm] = rst.CustomerSnm;	// 得意先略称
            dr[SalesSlipSchema.ct_Col_HonorificTitle] = rst.HonorificTitle;	// 敬称
            dr[SalesSlipSchema.ct_Col_OutputNameCode] = rst.OutputNameCode;	// 諸口コード
            dr[SalesSlipSchema.ct_Col_OutputName] = rst.OutputName;	// 諸口名称
            dr[SalesSlipSchema.ct_Col_CustSlipNo] = rst.CustSlipNo;	// 得意先伝票番号
            dr[SalesSlipSchema.ct_Col_SlipAddressDiv] = rst.SlipAddressDiv;	// 伝票住所区分
            dr[SalesSlipSchema.ct_Col_AddresseeCode] = rst.AddresseeCode;	// 納品先コード
            dr[SalesSlipSchema.ct_Col_AddresseeName] = rst.AddresseeName;	// 納品先名称
            dr[SalesSlipSchema.ct_Col_AddresseeName2] = rst.AddresseeName2;	// 納品先名称2
            dr[SalesSlipSchema.ct_Col_AddresseePostNo] = rst.AddresseePostNo;	// 納品先郵便番号
            dr[SalesSlipSchema.ct_Col_AddresseeAddr1] = rst.AddresseeAddr1;	// 納品先住所1(都道府県市区郡・町村・字)
            dr[SalesSlipSchema.ct_Col_AddresseeAddr3] = rst.AddresseeAddr3;	// 納品先住所3(番地)
            dr[SalesSlipSchema.ct_Col_AddresseeAddr4] = rst.AddresseeAddr4;	// 納品先住所4(アパート名称)
            dr[SalesSlipSchema.ct_Col_AddresseeTelNo] = rst.AddresseeTelNo;	// 納品先電話番号
            dr[SalesSlipSchema.ct_Col_AddresseeFaxNo] = rst.AddresseeFaxNo;	// 納品先FAX番号
            dr[SalesSlipSchema.ct_Col_PartySaleSlipNum] = rst.PartySaleSlipNum;	// 相手先伝票番号
            dr[SalesSlipSchema.ct_Col_SlipNote] = rst.SlipNote;	// 伝票備考
            dr[SalesSlipSchema.ct_Col_SlipNote2] = rst.SlipNote2;	// 伝票備考２
            dr[SalesSlipSchema.ct_Col_SlipNote3] = rst.SlipNote3;	// 伝票備考３
            dr[SalesSlipSchema.ct_Col_RetGoodsReasonDiv] = rst.RetGoodsReasonDiv;	// 返品理由コード
            dr[SalesSlipSchema.ct_Col_RetGoodsReason] = rst.RetGoodsReason;	// 返品理由
            dr[SalesSlipSchema.ct_Col_RegiProcDate] = rst.RegiProcDate;	// レジ処理日
            dr[SalesSlipSchema.ct_Col_CashRegisterNo] = rst.CashRegisterNo;	// レジ番号
            dr[SalesSlipSchema.ct_Col_PosReceiptNo] = rst.PosReceiptNo;	// POSレシート番号
            dr[SalesSlipSchema.ct_Col_DetailRowCount] = rst.DetailRowCount;	// 明細行数
            dr[SalesSlipSchema.ct_Col_EdiSendDate] = rst.EdiSendDate;	// ＥＤＩ送信日
            dr[SalesSlipSchema.ct_Col_EdiTakeInDate] = rst.EdiTakeInDate;	// ＥＤＩ取込日
            dr[SalesSlipSchema.ct_Col_UoeRemark1] = rst.UoeRemark1;	// ＵＯＥリマーク１
            dr[SalesSlipSchema.ct_Col_UoeRemark2] = rst.UoeRemark2;	// ＵＯＥリマーク２
            dr[SalesSlipSchema.ct_Col_SlipPrintDivCd] = rst.SlipPrintDivCd;	// 伝票発行区分
            dr[SalesSlipSchema.ct_Col_SlipPrintFinishCd] = rst.SlipPrintFinishCd;	// 伝票発行済区分
            dr[SalesSlipSchema.ct_Col_SalesSlipPrintDate] = rst.SalesSlipPrintDate;	// 売上伝票発行日
            dr[SalesSlipSchema.ct_Col_BusinessTypeCode] = rst.BusinessTypeCode;	// 業種コード
            dr[SalesSlipSchema.ct_Col_BusinessTypeName] = rst.BusinessTypeName;	// 業種名称
            dr[SalesSlipSchema.ct_Col_OrderNumber] = rst.OrderNumber;	// 発注番号
            dr[SalesSlipSchema.ct_Col_DeliveredGoodsDiv] = rst.DeliveredGoodsDiv;	// 納品区分
            dr[SalesSlipSchema.ct_Col_DeliveredGoodsDivNm] = rst.DeliveredGoodsDivNm;	// 納品区分名称
            dr[SalesSlipSchema.ct_Col_SalesAreaCode] = rst.SalesAreaCode;	// 販売エリアコード
            dr[SalesSlipSchema.ct_Col_SalesAreaName] = rst.SalesAreaName;	// 販売エリア名称
            dr[SalesSlipSchema.ct_Col_ReconcileFlag] = rst.ReconcileFlag;	// 消込フラグ
            dr[SalesSlipSchema.ct_Col_SlipPrtSetPaperId] = rst.SlipPrtSetPaperId;	// 伝票印刷設定用帳票ID
            dr[SalesSlipSchema.ct_Col_CompleteCd] = rst.CompleteCd;	// 一式伝票区分
            dr[SalesSlipSchema.ct_Col_SalesPriceFracProcCd] = rst.SalesPriceFracProcCd;	// 売上金額端数処理区分
            dr[SalesSlipSchema.ct_Col_StockGoodsTtlTaxExc] = rst.StockGoodsTtlTaxExc;	// 在庫商品合計金額（税抜）
            dr[SalesSlipSchema.ct_Col_PureGoodsTtlTaxExc] = rst.PureGoodsTtlTaxExc;	// 純正商品合計金額（税抜）
            dr[SalesSlipSchema.ct_Col_ListPricePrintDiv] = rst.ListPricePrintDiv;	// 定価印刷区分
            dr[SalesSlipSchema.ct_Col_EraNameDispCd1] = rst.EraNameDispCd1;	// 元号表示区分１
            dr[SalesSlipSchema.ct_Col_EstimaTaxDivCd] = rst.EstimaTaxDivCd;	// 見積消費税区分
            dr[SalesSlipSchema.ct_Col_EstimateFormPrtCd] = rst.EstimateFormPrtCd;	// 見積書印刷区分
            dr[SalesSlipSchema.ct_Col_EstimateSubject] = rst.EstimateSubject;	// 見積件名
            dr[SalesSlipSchema.ct_Col_Footnotes1] = rst.Footnotes1;	// 脚注１
            dr[SalesSlipSchema.ct_Col_Footnotes2] = rst.Footnotes2;	// 脚注２
            dr[SalesSlipSchema.ct_Col_EstimateTitle1] = rst.EstimateTitle1;	// 見積タイトル１
            dr[SalesSlipSchema.ct_Col_EstimateTitle2] = rst.EstimateTitle2;	// 見積タイトル２
            dr[SalesSlipSchema.ct_Col_EstimateTitle3] = rst.EstimateTitle3;	// 見積タイトル３
            dr[SalesSlipSchema.ct_Col_EstimateTitle4] = rst.EstimateTitle4;	// 見積タイトル４
            dr[SalesSlipSchema.ct_Col_EstimateTitle5] = rst.EstimateTitle5;	// 見積タイトル５
            dr[SalesSlipSchema.ct_Col_EstimateNote1] = rst.EstimateNote1;	// 見積備考１
            dr[SalesSlipSchema.ct_Col_EstimateNote2] = rst.EstimateNote2;	// 見積備考２
            dr[SalesSlipSchema.ct_Col_EstimateNote3] = rst.EstimateNote3;	// 見積備考３
            dr[SalesSlipSchema.ct_Col_EstimateNote4] = rst.EstimateNote4;	// 見積備考４
            dr[SalesSlipSchema.ct_Col_EstimateNote5] = rst.EstimateNote5;	// 見積備考５
            dr[SalesSlipSchema.ct_Col_EstimateValidityDate] = rst.EstimateValidityDate;	// 見積有効期限
            dr[SalesSlipSchema.ct_Col_PartsNoPrtCd] = rst.PartsNoPrtCd;	// 品番印字区分
            dr[SalesSlipSchema.ct_Col_OptionPringDivCd] = rst.OptionPringDivCd;	// オプション印字区分
            dr[SalesSlipSchema.ct_Col_RateUseCode] = rst.RateUseCode;	// 掛率使用区分
        }
        # endregion

        # region 売上(受注)データ＜DataRow → クラス＞作成
        /// <summary>
        /// 売上(受注)データ＜DataRow → クラス＞作成
        /// </summary>
        /// <param name="dr">テーブルRow</param>
        /// <returns>売上(受注)データ</returns>
        private SalesSlipWork CreateSalesSlipWorkFromSchemaProc(DataRow dr)
        {
            SalesSlipWork rst = new SalesSlipWork();

            try
            {
                //rst.CreateDateTime = (Int64)dr[SalesSlipSchema.ct_Col_CreateDateTime];	// 作成日時
                //rst.UpdateDateTime = (Int64)dr[SalesSlipSchema.ct_Col_UpdateDateTime];	// 更新日時
                rst.EnterpriseCode = (string)dr[SalesSlipSchema.ct_Col_EnterpriseCode];	// 企業コード
                rst.FileHeaderGuid = (Guid)dr[SalesSlipSchema.ct_Col_FileHeaderGuid];	// GUID
                rst.UpdEmployeeCode = (string)dr[SalesSlipSchema.ct_Col_UpdEmployeeCode];	// 更新従業員コード
                rst.UpdAssemblyId1 = (string)dr[SalesSlipSchema.ct_Col_UpdAssemblyId1];	// 更新アセンブリID1
                rst.UpdAssemblyId2 = (string)dr[SalesSlipSchema.ct_Col_UpdAssemblyId2];	// 更新アセンブリID2
                rst.LogicalDeleteCode = (Int32)dr[SalesSlipSchema.ct_Col_LogicalDeleteCode];	// 論理削除区分
                rst.AcptAnOdrStatus = (Int32)dr[SalesSlipSchema.ct_Col_AcptAnOdrStatus];	// 受注ステータス
                rst.SalesSlipNum = (string)dr[SalesSlipSchema.ct_Col_SalesSlipNum];	// 売上伝票番号
                rst.SectionCode = (string)dr[SalesSlipSchema.ct_Col_SectionCode];	// 拠点コード
                rst.SubSectionCode = (Int32)dr[SalesSlipSchema.ct_Col_SubSectionCode];	// 部門コード
                rst.DebitNoteDiv = (Int32)dr[SalesSlipSchema.ct_Col_DebitNoteDiv];	// 赤伝区分
                rst.DebitNLnkSalesSlNum = (string)dr[SalesSlipSchema.ct_Col_DebitNLnkSalesSlNum];	// 赤黒連結売上伝票番号
                rst.SalesSlipCd = (Int32)dr[SalesSlipSchema.ct_Col_SalesSlipCd];	// 売上伝票区分
                rst.SalesGoodsCd = (Int32)dr[SalesSlipSchema.ct_Col_SalesGoodsCd];	// 売上商品区分
                rst.AccRecDivCd = (Int32)dr[SalesSlipSchema.ct_Col_AccRecDivCd];	// 売掛区分
                rst.SalesInpSecCd = (string)dr[SalesSlipSchema.ct_Col_SalesInpSecCd];	// 売上入力拠点コード
                rst.DemandAddUpSecCd = (string)dr[SalesSlipSchema.ct_Col_DemandAddUpSecCd];	// 請求計上拠点コード
                rst.ResultsAddUpSecCd = (string)dr[SalesSlipSchema.ct_Col_ResultsAddUpSecCd];	// 実績計上拠点コード
                rst.UpdateSecCd = (string)dr[SalesSlipSchema.ct_Col_UpdateSecCd];	// 更新拠点コード
                rst.SalesSlipUpdateCd = (Int32)dr[SalesSlipSchema.ct_Col_SalesSlipUpdateCd];	// 売上伝票更新区分
                rst.SearchSlipDate = (DateTime)dr[SalesSlipSchema.ct_Col_SearchSlipDate];	// 伝票検索日付
                rst.ShipmentDay = (DateTime)dr[SalesSlipSchema.ct_Col_ShipmentDay];	// 出荷日付
                rst.SalesDate = (DateTime)dr[SalesSlipSchema.ct_Col_SalesDate];	// 売上日付
                rst.AddUpADate = (DateTime)dr[SalesSlipSchema.ct_Col_AddUpADate];	// 計上日付
                rst.DelayPaymentDiv = (Int32)dr[SalesSlipSchema.ct_Col_DelayPaymentDiv];	// 来勘区分
                rst.EstimateFormNo = (string)dr[SalesSlipSchema.ct_Col_EstimateFormNo];	// 見積書番号
                rst.EstimateDivide = (Int32)dr[SalesSlipSchema.ct_Col_EstimateDivide];	// 見積区分
                rst.InputAgenCd = (string)dr[SalesSlipSchema.ct_Col_InputAgenCd];	// 入力担当者コード
                rst.InputAgenNm = (string)dr[SalesSlipSchema.ct_Col_InputAgenNm];	// 入力担当者名称
                rst.SalesInputCode = (string)dr[SalesSlipSchema.ct_Col_SalesInputCode];	// 売上入力者コード
                rst.SalesInputName = (string)dr[SalesSlipSchema.ct_Col_SalesInputName];	// 売上入力者名称
                rst.FrontEmployeeCd = (string)dr[SalesSlipSchema.ct_Col_FrontEmployeeCd];	// 受付従業員コード
                rst.FrontEmployeeNm = (string)dr[SalesSlipSchema.ct_Col_FrontEmployeeNm];	// 受付従業員名称
                rst.SalesEmployeeCd = (string)dr[SalesSlipSchema.ct_Col_SalesEmployeeCd];	// 販売従業員コード
                rst.SalesEmployeeNm = (string)dr[SalesSlipSchema.ct_Col_SalesEmployeeNm];	// 販売従業員名称
                rst.TotalAmountDispWayCd = (Int32)dr[SalesSlipSchema.ct_Col_TotalAmountDispWayCd];	// 総額表示方法区分
                rst.TtlAmntDispRateApy = (Int32)dr[SalesSlipSchema.ct_Col_TtlAmntDispRateApy];	// 総額表示掛率適用区分
                rst.SalesTotalTaxInc = (Int64)dr[SalesSlipSchema.ct_Col_SalesTotalTaxInc];	// 売上伝票合計（税込み）
                rst.SalesTotalTaxExc = (Int64)dr[SalesSlipSchema.ct_Col_SalesTotalTaxExc];	// 売上伝票合計（税抜き）
                rst.SalesPrtTotalTaxInc = (Int64)dr[SalesSlipSchema.ct_Col_SalesPrtTotalTaxInc];	// 売上部品合計（税込み）
                rst.SalesPrtTotalTaxExc = (Int64)dr[SalesSlipSchema.ct_Col_SalesPrtTotalTaxExc];	// 売上部品合計（税抜き）
                rst.SalesWorkTotalTaxInc = (Int64)dr[SalesSlipSchema.ct_Col_SalesWorkTotalTaxInc];	// 売上作業合計（税込み）
                rst.SalesWorkTotalTaxExc = (Int64)dr[SalesSlipSchema.ct_Col_SalesWorkTotalTaxExc];	// 売上作業合計（税抜き）
                rst.SalesSubtotalTaxInc = (Int64)dr[SalesSlipSchema.ct_Col_SalesSubtotalTaxInc];	// 売上小計（税込み）
                rst.SalesSubtotalTaxExc = (Int64)dr[SalesSlipSchema.ct_Col_SalesSubtotalTaxExc];	// 売上小計（税抜き）
                rst.SalesPrtSubttlInc = (Int64)dr[SalesSlipSchema.ct_Col_SalesPrtSubttlInc];	// 売上部品小計（税込み）
                rst.SalesPrtSubttlExc = (Int64)dr[SalesSlipSchema.ct_Col_SalesPrtSubttlExc];	// 売上部品小計（税抜き）
                rst.SalesWorkSubttlInc = (Int64)dr[SalesSlipSchema.ct_Col_SalesWorkSubttlInc];	// 売上作業小計（税込み）
                rst.SalesWorkSubttlExc = (Int64)dr[SalesSlipSchema.ct_Col_SalesWorkSubttlExc];	// 売上作業小計（税抜き）
                rst.SalesNetPrice = (Int64)dr[SalesSlipSchema.ct_Col_SalesNetPrice];	// 売上正価金額
                rst.SalesSubtotalTax = (Int64)dr[SalesSlipSchema.ct_Col_SalesSubtotalTax];	// 売上小計（税）
                rst.ItdedSalesOutTax = (Int64)dr[SalesSlipSchema.ct_Col_ItdedSalesOutTax];	// 売上外税対象額
                rst.ItdedSalesInTax = (Int64)dr[SalesSlipSchema.ct_Col_ItdedSalesInTax];	// 売上内税対象額
                rst.SalSubttlSubToTaxFre = (Int64)dr[SalesSlipSchema.ct_Col_SalSubttlSubToTaxFre];	// 売上小計非課税対象額
                rst.SalesOutTax = (Int64)dr[SalesSlipSchema.ct_Col_SalesOutTax];	// 売上金額消費税額（外税）
                rst.SalAmntConsTaxInclu = (Int64)dr[SalesSlipSchema.ct_Col_SalAmntConsTaxInclu];	// 売上金額消費税額（内税）
                rst.SalesDisTtlTaxExc = (Int64)dr[SalesSlipSchema.ct_Col_SalesDisTtlTaxExc];	// 売上値引金額計（税抜き）
                rst.ItdedSalesDisOutTax = (Int64)dr[SalesSlipSchema.ct_Col_ItdedSalesDisOutTax];	// 売上値引外税対象額合計
                rst.ItdedSalesDisInTax = (Int64)dr[SalesSlipSchema.ct_Col_ItdedSalesDisInTax];	// 売上値引内税対象額合計
                rst.ItdedPartsDisOutTax = (Int64)dr[SalesSlipSchema.ct_Col_ItdedPartsDisOutTax];	// 部品値引対象額合計（税抜き）
                rst.ItdedPartsDisInTax = (Int64)dr[SalesSlipSchema.ct_Col_ItdedPartsDisInTax];	// 部品値引対象額合計（税込み）
                rst.ItdedWorkDisOutTax = (Int64)dr[SalesSlipSchema.ct_Col_ItdedWorkDisOutTax];	// 作業値引対象額合計（税抜き）
                rst.ItdedWorkDisInTax = (Int64)dr[SalesSlipSchema.ct_Col_ItdedWorkDisInTax];	// 作業値引対象額合計（税込み）
                rst.ItdedSalesDisTaxFre = (Int64)dr[SalesSlipSchema.ct_Col_ItdedSalesDisTaxFre];	// 売上値引非課税対象額合計
                rst.SalesDisOutTax = (Int64)dr[SalesSlipSchema.ct_Col_SalesDisOutTax];	// 売上値引消費税額（外税）
                rst.SalesDisTtlTaxInclu = (Int64)dr[SalesSlipSchema.ct_Col_SalesDisTtlTaxInclu];	// 売上値引消費税額（内税）
                rst.PartsDiscountRate = (Double)dr[SalesSlipSchema.ct_Col_PartsDiscountRate];	// 部品値引率
                rst.RavorDiscountRate = (Double)dr[SalesSlipSchema.ct_Col_RavorDiscountRate];	// 工賃値引率
                rst.TotalCost = (Int64)dr[SalesSlipSchema.ct_Col_TotalCost];	// 原価金額計
                rst.ConsTaxLayMethod = (Int32)dr[SalesSlipSchema.ct_Col_ConsTaxLayMethod];	// 消費税転嫁方式
                rst.ConsTaxRate = (Double)dr[SalesSlipSchema.ct_Col_ConsTaxRate];	// 消費税税率
                rst.FractionProcCd = (Int32)dr[SalesSlipSchema.ct_Col_FractionProcCd];	// 端数処理区分
                rst.AccRecConsTax = (Int64)dr[SalesSlipSchema.ct_Col_AccRecConsTax];	// 売掛消費税
                rst.AutoDepositCd = (Int32)dr[SalesSlipSchema.ct_Col_AutoDepositCd];	// 自動入金区分
                rst.AutoDepositSlipNo = (Int32)dr[SalesSlipSchema.ct_Col_AutoDepositSlipNo];	// 自動入金伝票番号
                rst.DepositAllowanceTtl = (Int64)dr[SalesSlipSchema.ct_Col_DepositAllowanceTtl];	// 入金引当合計額
                rst.DepositAlwcBlnce = (Int64)dr[SalesSlipSchema.ct_Col_DepositAlwcBlnce];	// 入金引当残高
                rst.ClaimCode = (Int32)dr[SalesSlipSchema.ct_Col_ClaimCode];	// 請求先コード
                rst.ClaimSnm = (string)dr[SalesSlipSchema.ct_Col_ClaimSnm];	// 請求先略称
                rst.CustomerCode = (Int32)dr[SalesSlipSchema.ct_Col_CustomerCode];	// 得意先コード
                rst.CustomerName = (string)dr[SalesSlipSchema.ct_Col_CustomerName];	// 得意先名称
                rst.CustomerName2 = (string)dr[SalesSlipSchema.ct_Col_CustomerName2];	// 得意先名称2
                rst.CustomerSnm = (string)dr[SalesSlipSchema.ct_Col_CustomerSnm];	// 得意先略称
                rst.HonorificTitle = (string)dr[SalesSlipSchema.ct_Col_HonorificTitle];	// 敬称
                rst.OutputNameCode = (Int32)dr[SalesSlipSchema.ct_Col_OutputNameCode];	// 諸口コード
                rst.OutputName = (string)dr[SalesSlipSchema.ct_Col_OutputName];	// 諸口名称
                rst.CustSlipNo = (Int32)dr[SalesSlipSchema.ct_Col_CustSlipNo];	// 得意先伝票番号
                rst.SlipAddressDiv = (Int32)dr[SalesSlipSchema.ct_Col_SlipAddressDiv];	// 伝票住所区分
                rst.AddresseeCode = (Int32)dr[SalesSlipSchema.ct_Col_AddresseeCode];	// 納品先コード
                rst.AddresseeName = (string)dr[SalesSlipSchema.ct_Col_AddresseeName];	// 納品先名称
                rst.AddresseeName2 = (string)dr[SalesSlipSchema.ct_Col_AddresseeName2];	// 納品先名称2
                rst.AddresseePostNo = (string)dr[SalesSlipSchema.ct_Col_AddresseePostNo];	// 納品先郵便番号
                rst.AddresseeAddr1 = (string)dr[SalesSlipSchema.ct_Col_AddresseeAddr1];	// 納品先住所1(都道府県市区郡・町村・字)
                rst.AddresseeAddr3 = (string)dr[SalesSlipSchema.ct_Col_AddresseeAddr3];	// 納品先住所3(番地)
                rst.AddresseeAddr4 = (string)dr[SalesSlipSchema.ct_Col_AddresseeAddr4];	// 納品先住所4(アパート名称)
                rst.AddresseeTelNo = (string)dr[SalesSlipSchema.ct_Col_AddresseeTelNo];	// 納品先電話番号
                rst.AddresseeFaxNo = (string)dr[SalesSlipSchema.ct_Col_AddresseeFaxNo];	// 納品先FAX番号
                rst.PartySaleSlipNum = (string)dr[SalesSlipSchema.ct_Col_PartySaleSlipNum];	// 相手先伝票番号
                rst.SlipNote = (string)dr[SalesSlipSchema.ct_Col_SlipNote];	// 伝票備考
                rst.SlipNote2 = (string)dr[SalesSlipSchema.ct_Col_SlipNote2];	// 伝票備考２
                rst.SlipNote3 = (string)dr[SalesSlipSchema.ct_Col_SlipNote3];	// 伝票備考３
                rst.RetGoodsReasonDiv = (Int32)dr[SalesSlipSchema.ct_Col_RetGoodsReasonDiv];	// 返品理由コード
                rst.RetGoodsReason = (string)dr[SalesSlipSchema.ct_Col_RetGoodsReason];	// 返品理由
                rst.RegiProcDate = (DateTime)dr[SalesSlipSchema.ct_Col_RegiProcDate];	// レジ処理日
                rst.CashRegisterNo = (Int32)dr[SalesSlipSchema.ct_Col_CashRegisterNo];	// レジ番号
                rst.PosReceiptNo = (Int32)dr[SalesSlipSchema.ct_Col_PosReceiptNo];	// POSレシート番号
                rst.DetailRowCount = (Int32)dr[SalesSlipSchema.ct_Col_DetailRowCount];	// 明細行数
                rst.EdiSendDate = (DateTime)dr[SalesSlipSchema.ct_Col_EdiSendDate];	// ＥＤＩ送信日
                rst.EdiTakeInDate = (DateTime)dr[SalesSlipSchema.ct_Col_EdiTakeInDate];	// ＥＤＩ取込日
                rst.UoeRemark1 = (string)dr[SalesSlipSchema.ct_Col_UoeRemark1];	// ＵＯＥリマーク１
                rst.UoeRemark2 = (string)dr[SalesSlipSchema.ct_Col_UoeRemark2];	// ＵＯＥリマーク２
                rst.SlipPrintDivCd = (Int32)dr[SalesSlipSchema.ct_Col_SlipPrintDivCd];	// 伝票発行区分
                rst.SlipPrintFinishCd = (Int32)dr[SalesSlipSchema.ct_Col_SlipPrintFinishCd];	// 伝票発行済区分
                rst.SalesSlipPrintDate = (DateTime)dr[SalesSlipSchema.ct_Col_SalesSlipPrintDate];	// 売上伝票発行日
                rst.BusinessTypeCode = (Int32)dr[SalesSlipSchema.ct_Col_BusinessTypeCode];	// 業種コード
                rst.BusinessTypeName = (string)dr[SalesSlipSchema.ct_Col_BusinessTypeName];	// 業種名称
                rst.OrderNumber = (string)dr[SalesSlipSchema.ct_Col_OrderNumber];	// 発注番号
                rst.DeliveredGoodsDiv = (Int32)dr[SalesSlipSchema.ct_Col_DeliveredGoodsDiv];	// 納品区分
                rst.DeliveredGoodsDivNm = (string)dr[SalesSlipSchema.ct_Col_DeliveredGoodsDivNm];	// 納品区分名称
                rst.SalesAreaCode = (Int32)dr[SalesSlipSchema.ct_Col_SalesAreaCode];	// 販売エリアコード
                rst.SalesAreaName = (string)dr[SalesSlipSchema.ct_Col_SalesAreaName];	// 販売エリア名称
                rst.ReconcileFlag = (Int32)dr[SalesSlipSchema.ct_Col_ReconcileFlag];	// 消込フラグ
                rst.SlipPrtSetPaperId = (string)dr[SalesSlipSchema.ct_Col_SlipPrtSetPaperId];	// 伝票印刷設定用帳票ID
                rst.CompleteCd = (Int32)dr[SalesSlipSchema.ct_Col_CompleteCd];	// 一式伝票区分
                rst.SalesPriceFracProcCd = (Int32)dr[SalesSlipSchema.ct_Col_SalesPriceFracProcCd];	// 売上金額端数処理区分
                rst.StockGoodsTtlTaxExc = (Int64)dr[SalesSlipSchema.ct_Col_StockGoodsTtlTaxExc];	// 在庫商品合計金額（税抜）
                rst.PureGoodsTtlTaxExc = (Int64)dr[SalesSlipSchema.ct_Col_PureGoodsTtlTaxExc];	// 純正商品合計金額（税抜）
                rst.ListPricePrintDiv = (Int32)dr[SalesSlipSchema.ct_Col_ListPricePrintDiv];	// 定価印刷区分
                rst.EraNameDispCd1 = (Int32)dr[SalesSlipSchema.ct_Col_EraNameDispCd1];	// 元号表示区分１
                rst.EstimaTaxDivCd = (Int32)dr[SalesSlipSchema.ct_Col_EstimaTaxDivCd];	// 見積消費税区分
                rst.EstimateFormPrtCd = (Int32)dr[SalesSlipSchema.ct_Col_EstimateFormPrtCd];	// 見積書印刷区分
                rst.EstimateSubject = (string)dr[SalesSlipSchema.ct_Col_EstimateSubject];	// 見積件名
                rst.Footnotes1 = (string)dr[SalesSlipSchema.ct_Col_Footnotes1];	// 脚注１
                rst.Footnotes2 = (string)dr[SalesSlipSchema.ct_Col_Footnotes2];	// 脚注２
                rst.EstimateTitle1 = (string)dr[SalesSlipSchema.ct_Col_EstimateTitle1];	// 見積タイトル１
                rst.EstimateTitle2 = (string)dr[SalesSlipSchema.ct_Col_EstimateTitle2];	// 見積タイトル２
                rst.EstimateTitle3 = (string)dr[SalesSlipSchema.ct_Col_EstimateTitle3];	// 見積タイトル３
                rst.EstimateTitle4 = (string)dr[SalesSlipSchema.ct_Col_EstimateTitle4];	// 見積タイトル４
                rst.EstimateTitle5 = (string)dr[SalesSlipSchema.ct_Col_EstimateTitle5];	// 見積タイトル５
                rst.EstimateNote1 = (string)dr[SalesSlipSchema.ct_Col_EstimateNote1];	// 見積備考１
                rst.EstimateNote2 = (string)dr[SalesSlipSchema.ct_Col_EstimateNote2];	// 見積備考２
                rst.EstimateNote3 = (string)dr[SalesSlipSchema.ct_Col_EstimateNote3];	// 見積備考３
                rst.EstimateNote4 = (string)dr[SalesSlipSchema.ct_Col_EstimateNote4];	// 見積備考４
                rst.EstimateNote5 = (string)dr[SalesSlipSchema.ct_Col_EstimateNote5];	// 見積備考５
                rst.EstimateValidityDate = (DateTime)dr[SalesSlipSchema.ct_Col_EstimateValidityDate];	// 見積有効期限
                rst.PartsNoPrtCd = (Int32)dr[SalesSlipSchema.ct_Col_PartsNoPrtCd];	// 品番印字区分
                rst.OptionPringDivCd = (Int32)dr[SalesSlipSchema.ct_Col_OptionPringDivCd];	// オプション印字区分
                rst.RateUseCode = (Int32)dr[SalesSlipSchema.ct_Col_RateUseCode];	// 掛率使用区分
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

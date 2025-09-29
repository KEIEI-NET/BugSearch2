using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.UIData
{

    /// <summary>
	/// 発注残一覧データ変換クラス
    /// </summary>
    /// <remarks>
	/// <br>Note       : 発注残一覧データ変換クラス</br>
    /// <br>Programmer : 21024 佐々木 健</br>
	/// <br>Date       : 2007.10.15</br>
    /// <br></br>
    /// <br>UpdateNote : </br>
    /// <br>           : </br>
    /// </remarks>
    public class DCHAT04111EA : IExtrProc
    {
        #region ■ Constructor
		/// <summary>
		/// 発注残一覧データ変換クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 発注残一覧データ変換クラス</br>
		/// <br>Programmer : 21024 佐々木 健</br>
		/// <br>Date       : 2007.10.15</br>
		/// <br></br>
		/// </remarks>
        public DCHAT04111EA( object printInfo )
        {
            // 印刷情報
            this._printInfo = printInfo as SFCMN06002C;
        }

		static DCHAT04111EA()
		{
			stc_Employee = null;

			stc_SecInfoAcs = new SecInfoAcs(1);    // 拠点アクセスクラス
			stc_SectionDic = new Dictionary<string, SecInfoSet>();  // 拠点Dictionary

			// ログイン拠点取得
		    Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
		    if (loginEmployee != null)
		    {
				stc_Employee = loginEmployee.Clone();
		    }

            // 拠点Dictionary生成
            SecInfoSet[] secInfoSetList = stc_SecInfoAcs.SecInfoSetList;

            foreach ( SecInfoSet secInfoSet in secInfoSetList ) {
                // 既存でなければ
                if ( !stc_SectionDic.ContainsKey(secInfoSet.SectionCode) ) {
                    // 追加
                    stc_SectionDic.Add(secInfoSet.SectionCode, secInfoSet);
                }
            }
		}
        #endregion ■ Constructor

        #region ■ private member
        private SFCMN06002C _printInfo = null;			// 印刷情報クラス

		private static Employee stc_Employee;
		private static SecInfoAcs stc_SecInfoAcs;               // 拠点アクセスクラス
		private static Dictionary<string, SecInfoSet> stc_SectionDic;   // 拠点Dictionary
		#endregion ■ private member

        #region ■ private const
		private const string ct_PGID = "DCHAT04111E";
        #endregion ■ private const

        #region ■ IExtrProc メンバ
		#region ◆ Public Property
		/// <summary>
		/// 印刷情報クラスプロパティ
		/// </summary>
		public SFCMN06002C Printinfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
		}
		#endregion ◆ Public Property

		#region ◆ Public Method
		#region ◎ 抽出処理
		/// <summary>
        /// 抽出処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 印刷のメイン処理を行います。</br>
        /// <br>Programmer : 22018 鈴木 正臣</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        public int ExtrPrintData()
        {
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // 抽出中画面部品のインスタンスを作成
            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // 表示文字を設定
            form.Title = "抽出中";
            form.Message = "現在、データを抽出中です。";
            
			try
			{
                form.Show();			// ダイアログ表示
                status = this.ExtraProc();	// 抽出処理実行
            }
            finally
            {
                // ダイアログを閉じる
                form.Close();
                this._printInfo.status = status;
            }

            return status;
		}
		#endregion
		#endregion ◆ Public Method
		#endregion ■ IExtrProc メンバ

		#region ■ Private Method
		#region ◆ 抽出メイン処理
		/// <summary>
        /// 抽出メイン処理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 抽出のメイン処理を行います。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
		/// <br>Date       : 2007.10.15</br>
        /// </remarks>
        private int ExtraProc()
        {
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			string errMsg = "";

			DataTable printTable = null;

			OrderListCndtn orderListCndtn = new OrderListCndtn();

			try
			{
				// 抽出条件クラスの変換
				if (this._printInfo.jyoken is OrderListCndtnWork)
				{
					OrderListCndtnWork orderListCndtnWork = (OrderListCndtnWork)this._printInfo.jyoken;

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 DEL
                    //orderListCndtn.ArrivalStateDiv = orderListCndtnWork.ArrivalStateDivs;
                    ////orderListCndtn.ArrivalStateDivTitle = "";
                    //orderListCndtn.DebitNoteDivs = orderListCndtnWork.DebitNoteDivs;
                    //orderListCndtn.Ed_ExpectDeliveryDate = orderListCndtnWork.Ed_ExpectDeliveryDate;
                    //orderListCndtn.Ed_GoodsMakerCd = orderListCndtnWork.Ed_GoodsMakerCd;
                    //orderListCndtn.Ed_GoodsNo = orderListCndtnWork.Ed_GoodsNo;
                    //orderListCndtn.Ed_OrderDataCreateDate = orderListCndtnWork.Ed_OrderDataCreateDate;
                    //orderListCndtn.Ed_OrderFormPrintDate = orderListCndtnWork.Ed_OrderFormPrintDate;
                    //orderListCndtn.Ed_StockAgentCode = orderListCndtnWork.Ed_StockAgentCode;
                    //orderListCndtn.Ed_StockAgentCode = orderListCndtnWork.Ed_StockAgentCode;
                    //orderListCndtn.Ed_SupplierCd = orderListCndtnWork.Ed_SupplierCd;
                    //orderListCndtn.Ed_WarehouseCode = orderListCndtnWork.Ed_WarehouseCode;
                    //orderListCndtn.EnterpriseCode = orderListCndtnWork.EnterpriseCode;
                    //orderListCndtn.OrderFormIssuedDivs = orderListCndtnWork.OrderFormIssuedDivs;
                    ////orderListCndtn.PrintSortDiv = ;
                    ////orderListCndtn.PrintSortDivTitle = "";
                    //orderListCndtn.SectionCodes = orderListCndtnWork.SectionCodes;
                    //orderListCndtn.St_ExpectDeliveryDate = orderListCndtnWork.St_ExpectDeliveryDate;
                    //orderListCndtn.St_GoodsMakerCd = orderListCndtnWork.St_GoodsMakerCd;
                    //orderListCndtn.St_GoodsNo = orderListCndtnWork.St_GoodsNo;
                    //orderListCndtn.St_OrderDataCreateDate = orderListCndtnWork.St_OrderDataCreateDate;
                    //orderListCndtn.St_OrderFormPrintDate = orderListCndtnWork.St_OrderFormPrintDate;
                    //orderListCndtn.St_StockAgentCode = orderListCndtnWork.St_StockAgentCode;
                    //orderListCndtn.St_StockInputCode = orderListCndtnWork.St_StockInputCode;
                    //orderListCndtn.St_SupplierCd = orderListCndtnWork.St_SupplierCd;
                    //orderListCndtn.St_WarehouseCode = orderListCndtnWork.St_WarehouseCode;
                    //orderListCndtn.StockOrderDivCds = orderListCndtnWork.StockOrderDivCds;
                    //orderListCndtn.SupplierSlipCds = orderListCndtnWork.SupplierSlipCds;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 DEL

				}
				this._printInfo.jyoken = orderListCndtn;

				// 印字テーブルの変換
				if (this._printInfo.rdData is OrderRemainDataSet.OrderListResultDataTable)
				{
					DCHAT02104EA.CreateDataTable(ref printTable);
					DataRow printTableRow;

					foreach (OrderRemainDataSet.OrderListResultRow orderListResultRow in (OrderRemainDataSet.OrderListResultDataTable)this._printInfo.rdData)
					{
						printTableRow = printTable.NewRow();

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 DEL
                        //printTableRow[DCHAT02104EA.ct_Col_DebitNoteDiv] = orderListResultRow.DebitNoteDiv;							// 赤伝区分
                        //printTableRow[DCHAT02104EA.ct_Col_SupplierSlipCd] = orderListResultRow.SupplierSlipCd;						// 仕入伝票区分
                        //printTableRow[DCHAT02104EA.ct_Col_OrderDataCreateDate] = orderListResultRow.OrderDataCreateDateDisplay;		// 入力日
                        //printTableRow[DCHAT02104EA.ct_Col_StockAgentCode] = orderListResultRow.StockAgentCode;						// 仕入担当者コード
                        //printTableRow[DCHAT02104EA.ct_Col_StockAgentName] = orderListResultRow.StockAgentName;						// 仕入担当者名称
                        //printTableRow[DCHAT02104EA.ct_Col_OrderFormPrintDate] = orderListResultRow.OrderFormPrintDateDisplay;		// 発注書発行日
                        //printTableRow[DCHAT02104EA.ct_Col_AcceptAnOrderNo] = orderListResultRow.AcceptAnOrderNo;					// 受注番号
                        //printTableRow[DCHAT02104EA.ct_Col_SupplierFormal] = orderListResultRow.SupplierFormal;						// 仕入形式
                        //printTableRow[DCHAT02104EA.ct_Col_SupplierSlipNo] = orderListResultRow.SupplierSlipNo;						// 仕入伝票番号
                        //printTableRow[DCHAT02104EA.ct_Col_StockRowNo] = orderListResultRow.StockRowNo;								// 仕入行番号
                        //printTableRow[DCHAT02104EA.ct_Col_SectionCode] = orderListResultRow.SectionCode;							// 拠点コード
                        //printTableRow[DCHAT02104EA.ct_Col_SectionGuideNm] = this.GetSectionGuideNm(orderListResultRow.SectionCode);	// 拠点ガイド名称
                        //printTableRow[DCHAT02104EA.ct_Col_StockInputCode] = orderListResultRow.StockInputCode;						// 仕入入力者コード
                        //printTableRow[DCHAT02104EA.ct_Col_StockInputName] = orderListResultRow.StockInputName;						// 仕入入力者名称
                        //printTableRow[DCHAT02104EA.ct_Col_GoodsMakerCd] = orderListResultRow.GoodsMakerCd;							// 商品メーカーコード
                        //printTableRow[DCHAT02104EA.ct_Col_MakerName] = orderListResultRow.MakerName;								// メーカー名称
                        //printTableRow[DCHAT02104EA.ct_Col_GoodsNo] = orderListResultRow.GoodsNo;									// 商品番号
                        //printTableRow[DCHAT02104EA.ct_Col_GoodsName] = orderListResultRow.GoodsName;								// 商品名称
                        //printTableRow[DCHAT02104EA.ct_Col_WarehouseCode] = orderListResultRow.WarehouseCode;						// 倉庫コード
                        //printTableRow[DCHAT02104EA.ct_Col_WarehouseName] = orderListResultRow.WarehouseName;						// 倉庫名称
                        //printTableRow[DCHAT02104EA.ct_Col_StockOrderDivCd] = orderListResultRow.StockOrderDivCd;					// 仕入在庫取寄せ区分
                        //printTableRow[DCHAT02104EA.ct_Col_UnitCode] = orderListResultRow.UnitCode;									// 単位コード
                        //printTableRow[DCHAT02104EA.ct_Col_UnitName] = orderListResultRow.UnitName;									// 単位名称
                        //printTableRow[DCHAT02104EA.ct_Col_StockUnitPriceFl] = orderListResultRow.StockUnitPriceFl;					// 仕入単価（税抜，浮動）
                        //printTableRow[DCHAT02104EA.ct_Col_StockUnitTaxPriceFl] = orderListResultRow.StockUnitTaxPriceFl;			// 仕入単価（税込，浮動）
                        //printTableRow[DCHAT02104EA.ct_Col_BargainCd] = orderListResultRow.BargainCd;								// 特売区分コード
                        //printTableRow[DCHAT02104EA.ct_Col_BargainNm] = orderListResultRow.BargainNm;								// 特売区分名称
                        //printTableRow[DCHAT02104EA.ct_Col_StockCount] = orderListResultRow.StockCount;								// 仕入数
                        //printTableRow[DCHAT02104EA.ct_Col_StockDtiSlipNote1] = orderListResultRow.StockDtiSlipNote1;				// 仕入伝票明細備考1
                        //printTableRow[DCHAT02104EA.ct_Col_SalesCustomerCode] = orderListResultRow.SalesCustomerCode;				// 販売先コード
                        //printTableRow[DCHAT02104EA.ct_Col_SalesCustomerSnm] = orderListResultRow.SalesCustomerSnm;					// 販売先名称
                        //printTableRow[DCHAT02104EA.ct_Col_SupplierCd] = orderListResultRow.SupplierCd;								// 仕入先コード
                        //printTableRow[DCHAT02104EA.ct_Col_SupplierSnm] = orderListResultRow.SupplierSnm;							// 仕入先略称
                        //printTableRow[DCHAT02104EA.ct_Col_AddresseeCode] = orderListResultRow.AddresseeCode;						// 納品先コード
                        //printTableRow[DCHAT02104EA.ct_Col_AddresseeName] = orderListResultRow.AddresseeName;						// 納品先名称
                        //printTableRow[DCHAT02104EA.ct_Col_RemainCntUpdDate] = orderListResultRow.RemainCntUpdDate;					// 残数更新日
                        //printTableRow[DCHAT02104EA.ct_Col_DirectSendingCd] = orderListResultRow.DirectSendingCd;					// 直送区分
                        //printTableRow[DCHAT02104EA.ct_Col_OrderNumber] = orderListResultRow.OrderNumber;							// 発注番号
                        //printTableRow[DCHAT02104EA.ct_Col_WayToOrder] = orderListResultRow.WayToOrder;								// 注文方法
                        //printTableRow[DCHAT02104EA.ct_Col_DeliGdsCmpltDueDate] = orderListResultRow.DeliGdsCmpltDueDateDisplay;		// 納品完了予定日
                        //printTableRow[DCHAT02104EA.ct_Col_ExpectDeliveryDate] = orderListResultRow.ExpectDeliveryDateDisplay;		// 希望納期
                        //printTableRow[DCHAT02104EA.ct_Col_OrderCnt] = orderListResultRow.OrderCnt;									// 発注数量
                        //printTableRow[DCHAT02104EA.ct_Col_OrderAdjustCnt] = orderListResultRow.OrderAdjustCnt;						// 発注調整数
                        //printTableRow[DCHAT02104EA.ct_Col_OrderRemainCnt] = orderListResultRow.OrderRemainCnt;						// 発注残数
                        //printTableRow[DCHAT02104EA.ct_Col_ReconcileFlag] = orderListResultRow.ReconcileFlag;						// 消込フラグ
                        //printTableRow[DCHAT02104EA.ct_Col_OrderFormIssuedDiv] = orderListResultRow.OrderFormIssuedDiv;				// 発注書発行済区分
                        //printTableRow[DCHAT02104EA.ct_Col_SlipMemo1] = orderListResultRow.SlipMemo1;								// 伝票メモ１
                        //printTableRow[DCHAT02104EA.ct_Col_SlipMemo2] = orderListResultRow.SlipMemo2;								// 伝票メモ２
                        //printTableRow[DCHAT02104EA.ct_Col_SlipMemo3] = orderListResultRow.SlipMemo3;								// 伝票メモ３
                        //printTableRow[DCHAT02104EA.ct_Col_SlipMemo4] = orderListResultRow.SlipMemo4;								// 伝票メモ４
                        //printTableRow[DCHAT02104EA.ct_Col_SlipMemo5] = orderListResultRow.SlipMemo5;								// 伝票メモ５
                        //printTableRow[DCHAT02104EA.ct_Col_SlipMemo6] = orderListResultRow.SlipMemo6;								// 伝票メモ６
                        //printTableRow[DCHAT02104EA.ct_Col_InsideMemo1] = orderListResultRow.InsideMemo1;							// 社内メモ１
                        //printTableRow[DCHAT02104EA.ct_Col_InsideMemo2] = orderListResultRow.InsideMemo2;							// 社内メモ２
                        //printTableRow[DCHAT02104EA.ct_Col_InsideMemo3] = orderListResultRow.InsideMemo3;							// 社内メモ３
                        //printTableRow[DCHAT02104EA.ct_Col_InsideMemo4] = orderListResultRow.InsideMemo4;							// 社内メモ４
                        //printTableRow[DCHAT02104EA.ct_Col_InsideMemo5] = orderListResultRow.InsideMemo5;							// 社内メモ５
                        //printTableRow[DCHAT02104EA.ct_Col_InsideMemo6] = orderListResultRow.InsideMemo6;							// 社内メモ６

                        //printTableRow[DCHAT02104EA.ct_Col_StockPriceTaxExc] = orderListResultRow.StockPriceTaxExc;    // 税抜金額
                        //printTableRow[DCHAT02104EA.ct_Col_StockPriceTaxInc] = orderListResultRow.StockPriceTaxInc;    // 税込金額

						
                        //printTableRow[DCHAT02104EA.ct_Col_OrderRemainPrice] = GetOrderRemainPrice(orderListResultRow.StockUnitPriceFl, orderListResultRow.OrderRemainCnt);	// 発注残金額
                        //printTableRow[DCHAT02104EA.ct_Col_DebitNoteDivNm] = OrderListCndtn.GetDebitNoteDivNm(orderListResultRow.DebitNoteDiv);								// 赤伝区分名称
                        //printTableRow[DCHAT02104EA.ct_Col_SupplierSlipCdNm] = OrderListCndtn.GetSupplierSlipCdNm(orderListResultRow.SupplierSlipCd);						// 仕入伝票区分名称
                        //printTableRow[DCHAT02104EA.ct_Col_StockOrderDivNm] = OrderListCndtn.GetStockOrderDivCdNm(orderListResultRow.StockOrderDivCd);						// 仕入在庫取寄せ区分名称
                        //printTableRow[DCHAT02104EA.ct_Col_OrderFormIssuedDivNm] = OrderListCndtn.GetOrderFormIssuedDivNm(orderListResultRow.OrderFormIssuedDiv);			// 発注書発行済み区分名称

                        //printTableRow[DCHAT02104EA.ct_Col_OrderAndAdjustCnt] = orderListResultRow.OrderCnt;																	// 印刷用　発注数（発注数）

                        //printTableRow[DCHAT02104EA.ct_Col_Sort_SectionCode] = orderListResultRow.SectionCode;					// ソート用　拠点コード
                        //printTableRow[DCHAT02104EA.ct_Col_Sort_OrderFormPrintDate] = orderListResultRow.OrderFormPrintDate;		// ソート用　発注書発行日
                        //printTableRow[DCHAT02104EA.ct_Col_Sort_GoodsMakerCd] = orderListResultRow.GoodsMakerCd;					// ソート用　商品メーカーコード
                        //printTableRow[DCHAT02104EA.ct_Col_Sort_GoodsNo] = orderListResultRow.GoodsNo;							// ソート用　商品番号
                        //printTableRow[DCHAT02104EA.ct_Col_Sort_SupplierCd] = orderListResultRow.SupplierCd;						// ソート用　仕入先コード
                        //printTableRow[DCHAT02104EA.ct_Col_Sort_OrderDataCreateDate] = orderListResultRow.OrderDataCreateDate;	// ソート用　入力日
                        //printTableRow[DCHAT02104EA.ct_Col_Sort_ExpectDeliveryDate] = orderListResultRow.ExpectDeliveryDate;		// ソート用　希望納期
                        //printTableRow[DCHAT02104EA.ct_Col_Sort_SupplierSlipNo] = orderListResultRow.SupplierSlipNo;				// ソート用　仕入伝票番号
                        //printTableRow[DCHAT02104EA.ct_Col_Sort_StockRowNo] = orderListResultRow.StockRowNo;						// ソート用　仕入行番号
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 DEL

						printTable.Rows.Add(printTableRow);
					}
				}

				if (printTable == null)
				{
					status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
				}
				else
				{
					this._printInfo.rdData = new DataView(printTable, "", GetSortOrder(), DataViewRowState.CurrentRows);
					status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
				}
			}
			catch (Exception ex)
			{
				MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, ex.Message, status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}
            finally
            {
                // 戻り値を設定。異常の場合はメッセージを表示
                switch ( status )
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                        {
                            break;
                        }
                    default:
                        {
							// ステータスが以上のときはメッセージを表示
                            TMsgDisp.Show( emErrorLevel.ERR_LEVEL_STOPDISP, ct_PGID, errMsg, status,
                                        MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
                            break;
                        }
                }
            }
            return status;
		}
		#endregion ◆ 抽出メイン処理

		/// <summary>
		/// 発注残金額取得処理
		/// </summary>
		/// <param name="stockUnitPriceFl">単価</param>
		/// <param name="orderRemainCount">発注残数</param>
		/// <returns></returns>
		private Int64 GetOrderRemainPrice( double stockUnitPriceFl, double orderRemainCount )
		{
			return (Int64)Math.Floor(stockUnitPriceFl * orderRemainCount);
		}

		#region ◎ ソート順作成
		/// <summary>
		/// ソート順作成
		/// </summary>
		/// <returns>ソート文字列</returns>
		private string GetSortOrder()
		{
			StringBuilder strSortOrder = new StringBuilder();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 DEL
//            strSortOrder.Append(string.Format("{0},", DCHAT02104EA.ct_Col_Sort_SectionCode));			// 拠点コード
//            strSortOrder.Append(string.Format("{0},", DCHAT02104EA.ct_Col_Sort_OrderDataCreateDate));	// 発注日
////			strSortOrder.Append(string.Format("{0},", DCHAT02104EA.ct_Col_Sort_SupplierCd));			// 発注先
//            strSortOrder.Append(string.Format("{0},", DCHAT02104EA.ct_Col_Sort_SupplierSlipNo));		// 仕入伝票番号
//            strSortOrder.Append(string.Format("{0}", DCHAT02104EA.ct_Col_Sort_StockRowNo));				// 仕入伝票行№
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 DEL

			return strSortOrder.ToString();
		}
		#endregion

		/// <summary>
		/// 拠点ガイド名称取得
		/// </summary>
		/// <param name="sectionCode">拠点コード</param>
		/// <returns>拠点ガイド名称</returns>
		private string GetSectionGuideNm( string sectionCode )
		{
			if (stc_SectionDic.ContainsKey(sectionCode))
			{
				return stc_SectionDic[sectionCode].SectionGuideNm;
			}
			else
			{
				return string.Empty;
			}
		}


		#region ◆ エラーメッセージ表示
		/// <summary>
        /// エラーメッセージ表示
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="iMsg">エラーメッセージ</param>
        /// <param name="iSt">エラーステータス</param>
        /// <param name="iButton">表示ボタン</param>
        /// <param name="iDefButton">初期フォーカスボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : エラーメッセージを表示します。</br>
        /// <br>Programmer : 21024 佐々木 健</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
        {
            return TMsgDisp.Show(iLevel, ct_PGID, iMsg, iSt, iButton, iDefButton);
        }
		#endregion ◆ エラーメッセージ表示
        #endregion
	}
}

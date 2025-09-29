using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// 見積確認表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 見積確認表で使用するデータを取得する。</br>
    /// <br>Programmer   : 22018 鈴木 正臣</br>
    /// <br>Date         : 2007.09.19</br>
    /// <br>-----------------------------------------------------</br>
	/// <br>UpdateNote   : 2008.07.31 30413 犬飼</br>
	/// <br>             : PM.NS対応</br>
    /// <br>UpdateNote   : 2009.02.02 30452 上野 俊治</br>
    /// <br>             : 障害対応10579(見積残数追加。数量、見積残数によるフィルタ処理を追加。)</br>
    /// <br>UpdateNote   : 2009.02.13 30452 上野 俊治</br>
    /// <br>             : 障害対応10579(受注数量、受注調整数追加。フィルタ処理を修正)</br>
    /// <br>UpdateNote   : 2009/04/02 30452 上野 俊治</br>
    /// <br>             : 障害対応10232</br>
    /// <br>UpdateNote   : 2011/11/11 x_zhuxk</br>
    /// <br>             : ＃redmine26537</br>
    /// <br>UpdateNote   : 2021/10/04 鈴木創</br>
    /// <br>             : 内部発見　伝票行番号でソートされずに見積確認表が出力されるバグの修正</br>
    /// </remarks>
	public class EstimateListAcs
	{
		#region ■ Constructor
		/// <summary>
		/// 見積確認表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 見積確認表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.09.19</br>
		/// </remarks>
		public EstimateListAcs()
		{
            this._iEstimateListWorkDB = (IEstimateListWorkDB)MediationEstimateListWorkDB.GetEstimateListWorkDB();
		}

		/// <summary>
		/// 見積確認表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 見積確認表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.09.19</br>
		/// </remarks>
        static EstimateListAcs ()
		{
			stc_Employee		= null;
			stc_PrtOutSet		= null;					// 帳票出力設定データクラス
			stc_PrtOutSetAcs	= new PrtOutSetAcs();	// 帳票出力設定アクセスクラス

            stc_SecInfoAcs      = new SecInfoAcs(1);    // 拠点アクセスクラス
            stc_SectionDic      = new Dictionary<string,SecInfoSet>();  // 拠点Dictionary

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
                if (! stc_SectionDic.ContainsKey( secInfoSet.SectionCode ) ) {
                    // 追加
                    stc_SectionDic.Add( secInfoSet.SectionCode, secInfoSet );
                }
            }
		}
		#endregion ■ Constructor

		#region ■ Static Member
		private static Employee stc_Employee;
		private static PrtOutSet stc_PrtOutSet;			// 帳票出力設定データクラス
		private static PrtOutSetAcs stc_PrtOutSetAcs;	// 帳票出力設定アクセスクラス

        private static SecInfoAcs stc_SecInfoAcs;               // 拠点アクセスクラス
        private static Dictionary<string,SecInfoSet> stc_SectionDic;   // 拠点Dictionary
		#endregion ■ Static Member

		#region ■ Private Member
        IEstimateListWorkDB _iEstimateListWorkDB;

		private DataTable _stockManagementListDt;			// 印刷DataTable
		private DataView _stockManagementListDataView;	// 印刷DataView

		#endregion ■ Private Member

		#region ■ Public Property
		/// <summary>
		/// 印刷データセット(読み取り専用)
		/// </summary>
		public DataView StockManagementListDataView
		{
			get{ return this._stockManagementListDataView; }
		}
		#endregion ■ Public Property

		#region ■ Public Method
		#region ◆ 出力データ取得
		#region ◎ 入金データ取得
		/// <summary>
		/// データ取得
		/// </summary>
		/// <param name="estimateListCndtn">抽出条件</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷するデータを取得する。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.09.19</br>
		/// </remarks>
        public int SearchMain ( EstimateListCndtn estimateListCndtn, out string errMsg )
		{
            return this.SearchProc(estimateListCndtn, out errMsg);
		}
		#endregion
		#endregion ◆ 出力データ取得
		#endregion ■ Public Method

		#region ■ Private Method
		#region ◆ 帳票データ取得
		#region ◎ 在庫移動データ取得
		/// <summary>
		/// 在庫移動データ取得
		/// </summary>
		/// <param name="estimateListCndtn"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する在庫移動データを取得する。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.09.19</br>
		/// </remarks>
        private int SearchProc ( EstimateListCndtn estimateListCndtn, out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

			try
			{
				// DataTable Create ----------------------------------------------------------
				DCMIT02104EA.CreateDataTable( ref this._stockManagementListDt );
				
				EstimateListCndtnWork estimateListCndtnWork = new EstimateListCndtnWork();
				// 抽出条件展開  --------------------------------------------------------------
				status = this.DevStockMoveCndtn( estimateListCndtn, out estimateListCndtnWork, out errMsg );
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

				// データ取得  ----------------------------------------------------------------
				object retStockMoveList = null;

                status = this._iEstimateListWorkDB.Search( out retStockMoveList, estimateListCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);
				switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						// データ展開処理
						DevStockMoveData( estimateListCndtn, (ArrayList)retStockMoveList );
                        // --- ADD 2009/02/02 -------------------------------->>>>>
                        if (this._stockManagementListDt.Rows.Count == 0)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        // --- ADD 2009/02/02 --------------------------------<<<<<
						break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
					default:
						// 2008.07.31 30413 犬飼 エラーメッセージを変更 >>>>>>START
                        //errMsg = "在庫履歴データの取得に失敗しました。";
                        errMsg = "見積データの取得に失敗しました。";
                        // 2008.07.31 30413 犬飼 エラーメッセージを変更 <<<<<<END
                        break;
				}
			}
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
		#endregion
		#endregion ◆ 帳票データ取得

		#region ◆ データ展開処理
		#region ◎ 抽出条件展開処理
		/// <summary>
		/// 抽出条件展開処理
		/// </summary>
		/// <param name="estimateListCndtn">UI抽出条件クラス</param>
		/// <param name="estimateListCndtnWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
        private int DevStockMoveCndtn ( EstimateListCndtn estimateListCndtn, out EstimateListCndtnWork estimateListCndtnWork, out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;
			estimateListCndtnWork = new EstimateListCndtnWork();
			try
			{
                estimateListCndtnWork.EnterpriseCode = estimateListCndtn.EnterpriseCode;  // 企業コード
				// 抽出条件パラメータセット
				if ( estimateListCndtn.SectionCodes.Length != 0 )
				{
				    if ( estimateListCndtn.IsSelectAllSection )
				    {
				        // 全社の時
                        estimateListCndtnWork.SectionCodes = null;
				    }
				    else
				    {
                        estimateListCndtnWork.SectionCodes = estimateListCndtn.SectionCodes;
				    }
				}
				else
				{
                    estimateListCndtnWork.SectionCodes = null;
				}

                estimateListCndtnWork.EnterpriseCode = estimateListCndtn.EnterpriseCode;            // 企業コード
                estimateListCndtnWork.SectionCodes = estimateListCndtn.SectionCodes;                // 拠点コード（複数指定）
                estimateListCndtnWork.St_SalesDate = estimateListCndtn.St_SalesDate;                // 開始見積日付
                estimateListCndtnWork.Ed_SalesDate = estimateListCndtn.Ed_SalesDate;                // 終了見積日付
                estimateListCndtnWork.St_SearchSlipDate = estimateListCndtn.St_SearchSlipDate;      // 開始入力日付
                estimateListCndtnWork.Ed_SearchSlipDate = estimateListCndtn.Ed_SearchSlipDate;      // 終了入力日付
                estimateListCndtnWork.St_CustomerCode = estimateListCndtn.St_CustomerCode;          // 開始得意先コード
                // 2008.09.26 30413 犬飼 抽出条件の出力制御のため終了はそのまま返す >>>>>>START
                //estimateListCndtnWork.Ed_CustomerCode = estimateListCndtn.Ed_CustomerCode;          // 終了得意先コード
                if (estimateListCndtn.Ed_CustomerCode == 0)
                {
                    // 未入力の場合は、最大値を設定
                    estimateListCndtnWork.Ed_CustomerCode = 99999999;
                }
                else
                {
                    estimateListCndtnWork.Ed_CustomerCode = estimateListCndtn.Ed_CustomerCode;
                }
                // 2008.09.26 30413 犬飼 抽出条件の出力制御のため終了はそのまま返す <<<<<<END
                estimateListCndtnWork.St_SalesEmployeeCd = estimateListCndtn.St_SalesEmployeeCd;    // 開始販売従業員コード
                estimateListCndtnWork.Ed_SalesEmployeeCd = estimateListCndtn.Ed_SalesEmployeeCd;    // 終了販売従業員コード
                
                // 2008.07.31 30413 犬飼 見積タイプと発行タイプを追加 >>>>>>START
                estimateListCndtnWork.EstimateDivide = estimateListCndtn.EstimateDivide;            // 見積タイプ
                estimateListCndtnWork.PrintDiv = estimateListCndtn.PrintDiv;                        // 発行タイプ
                // 2008.07.31 30413 犬飼 見積タイプと発行タイプを追加 <<<<<<END

                // 2011/11/11 x_zhuxk ＃redmine26537 >>>>>>START
                estimateListCndtnWork.AutoAnswerDivSCMRF = estimateListCndtn.AutoAnswerDivSCMRF;    //連携伝票出力区分
                estimateListCndtnWork.AcceptOrOrderKindRF = estimateListCndtn.AcceptOrOrderKindRF; //連携伝票対象区分
                // 2011/11/11 x_zhuxk ＃redmine26537 <<<<<<END

                
			}
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
		#endregion

		#region ◎ 取得データ展開処理
		/// <summary>
		/// 取得データ展開処理
		/// </summary>
		/// <param name="estimateListCndtn">UI抽出条件クラス</param>
		/// <param name="stockMoveWork">取得データ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 取得データを展開する。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.09.19</br>
		/// </remarks>
		private void DevStockMoveData ( EstimateListCndtn estimateListCndtn, ArrayList stockMoveWork )
		{
			DataRow dr;

            foreach ( EstimateListResultWork estimateListResultWork in stockMoveWork )
			{
				dr = this._stockManagementListDt.NewRow();
				// 取得データ展開
				#region 取得データ展開
                dr[DCMIT02104EA.ct_Col_ResultsAddUpSecCd] = estimateListResultWork.ResultsAddUpSecCd;   // 実績計上拠点コード
                dr[DCMIT02104EA.ct_Col_ResultsAddUpSecNm] = estimateListResultWork.ResultsAddUpSecNm;   // 実績計上拠点ガイド名称
                dr[DCMIT02104EA.ct_Col_CustomerCode] = estimateListResultWork.CustomerCode;             // 得意先コード
                dr[DCMIT02104EA.ct_Col_CustomerSnm] = estimateListResultWork.CustomerSnm;               // 得意先略称
                dr[DCMIT02104EA.ct_Col_SearchSlipDate] = estimateListResultWork.SearchSlipDate;         // 入力日付
                dr[DCMIT02104EA.ct_Col_SalesDate] = estimateListResultWork.SalesDate;                   // 見積日付
                dr[DCMIT02104EA.ct_Col_SalesSlipNum] = estimateListResultWork.SalesSlipNum;             // 見積伝票番号
                // INS 2021/10/24 --------------------------------------------------->>>>>
                dr[DCMIT02104EA.ct_Col_SalesRowNo] = estimateListResultWork.SalesRowNo;                 // 見積伝票行番号
                // INS 2021/10/24 --------------------------------------------------->>>>>
                dr[DCMIT02104EA.ct_Col_EstimateFormNo] = estimateListResultWork.EstimateFormNo;         // 見積書番号
                dr[DCMIT02104EA.ct_Col_SalesEmployeeCd] = estimateListResultWork.SalesEmployeeCd;       // 販売従業員コード
                dr[DCMIT02104EA.ct_Col_SalesEmployeeNm] = estimateListResultWork.SalesEmployeeNm;       // 販売従業員名称
                dr[DCMIT02104EA.ct_Col_SlipNote] = estimateListResultWork.SlipNote;                     // 伝票備考
                dr[DCMIT02104EA.ct_Col_GoodsMakerCd] = estimateListResultWork.GoodsMakerCd;             // 商品メーカーコード
                dr[DCMIT02104EA.ct_Col_MakerName] = estimateListResultWork.MakerName;                   // メーカー名称
                dr[DCMIT02104EA.ct_Col_GoodsNo] = estimateListResultWork.GoodsNo;                       // 商品番号
                dr[DCMIT02104EA.ct_Col_GoodsName] = estimateListResultWork.GoodsName;                   // 商品名称
                dr[DCMIT02104EA.ct_Col_ListPriceTaxExcFl] = estimateListResultWork.ListPriceTaxExcFl;   // 定価（税抜，浮動）
                dr[DCMIT02104EA.ct_Col_ShipmentCnt] = estimateListResultWork.ShipmentCnt;               // 出荷数
                dr[DCMIT02104EA.ct_Col_AcceptAnOrderCnt] = estimateListResultWork.AcceptAnOrderCnt;     // 受注数量 // ADD 2009/02/13
                dr[DCMIT02104EA.ct_Col_AcptAnOdrAdjustCnt] = estimateListResultWork.AcptAnOdrAdjustCnt; // 受注調整数 // ADD 2009/02/13
                dr[DCMIT02104EA.ct_Col_AcceptAnOrderCntPlusAdjustCnt]
                    = estimateListResultWork.AcceptAnOrderCnt + estimateListResultWork.AcptAnOdrAdjustCnt; // 現在の受注数 // ADD 2009/02/13
                dr[DCMIT02104EA.ct_Col_AcptAnOdrRemainCnt] = estimateListResultWork.AcptAnOdrRemainCnt; // 見積残数 // ADD 2009/02/02
                dr[DCMIT02104EA.ct_Col_SalesUnitCost] = estimateListResultWork.SalesUnitCost;           // 原価単価
                dr[DCMIT02104EA.ct_Col_SalesUnPrcTaxExcFl] = estimateListResultWork.SalesUnPrcTaxExcFl; // 売上単価（税抜，浮動）
                dr[DCMIT02104EA.ct_Col_SalesMoneyTaxExc] = estimateListResultWork.SalesMoneyTaxExc;     // 売上金額（税抜き）
                dr[DCMIT02104EA.ct_Col_SupplierCd] = estimateListResultWork.SupplierCd;                 // 仕入先コード
                dr[DCMIT02104EA.ct_Col_SupplierSnm] = estimateListResultWork.SupplierSnm;               // 仕入先略称
                dr[DCMIT02104EA.ct_Col_WarehouseCode] = estimateListResultWork.WarehouseCode;           // 倉庫コード
                dr[DCMIT02104EA.ct_Col_WarehouseName] = estimateListResultWork.WarehouseName;           // 倉庫名称
                dr[DCMIT02104EA.ct_Col_SalesSlipCdDtl] = estimateListResultWork.SalesSlipCdDtl;         // 売上伝票区分（明細）
                dr[DCMIT02104EA.ct_Col_SlipMemo1] = estimateListResultWork.SlipMemo1;                   // 伝票メモ１
                dr[DCMIT02104EA.ct_Col_SlipMemo2] = estimateListResultWork.SlipMemo2;                   // 伝票メモ２
                dr[DCMIT02104EA.ct_Col_SlipMemo3] = estimateListResultWork.SlipMemo3;                   // 伝票メモ３
                // 2008.07.31 30413 犬飼 未取得データを削除 >>>>>>START
                //dr[DCMIT02104EA.ct_Col_SlipMemo4] = estimateListResultWork.SlipMemo4; // 伝票メモ４
                //dr[DCMIT02104EA.ct_Col_SlipMemo5] = estimateListResultWork.SlipMemo5; // 伝票メモ５
                //dr[DCMIT02104EA.ct_Col_SlipMemo6] = estimateListResultWork.SlipMemo6; // 伝票メモ６
                // 2008.07.31 30413 犬飼 未取得データを削除 <<<<<<END
                dr[DCMIT02104EA.ct_Col_InsideMemo1] = estimateListResultWork.InsideMemo1;               // 社内メモ１
                dr[DCMIT02104EA.ct_Col_InsideMemo2] = estimateListResultWork.InsideMemo2;               // 社内メモ２
                dr[DCMIT02104EA.ct_Col_InsideMemo3] = estimateListResultWork.InsideMemo3;               // 社内メモ３
                // 2008.07.31 30413 犬飼 未取得データを削除 >>>>>>START
                //dr[DCMIT02104EA.ct_Col_InsideMemo4] = estimateListResultWork.InsideMemo4; // 社内メモ４
                //dr[DCMIT02104EA.ct_Col_InsideMemo5] = estimateListResultWork.InsideMemo5; // 社内メモ５
                //dr[DCMIT02104EA.ct_Col_InsideMemo6] = estimateListResultWork.InsideMemo6; // 社内メモ６
                // 2008.07.31 30413 犬飼 未取得データを削除 <<<<<<END
                dr[DCMIT02104EA.ct_Col_EstimateNote1] = estimateListResultWork.EstimateNote1;           // 見積備考１
                dr[DCMIT02104EA.ct_Col_EstimateNote2] = estimateListResultWork.EstimateNote2;           // 見積備考２
                dr[DCMIT02104EA.ct_Col_EstimateNote3] = estimateListResultWork.EstimateNote3;           // 見積備考３
                dr[DCMIT02104EA.ct_Col_EstimateNote4] = estimateListResultWork.EstimateNote4;           // 見積備考４
                dr[DCMIT02104EA.ct_Col_EstimateNote5] = estimateListResultWork.EstimateNote5;           // 見積備考５

                // 2008.07.31 30413 犬飼 取得データ項目の追加 >>>>>>START
                dr[DCMIT02104EA.ct_Col_SlipNote2] = estimateListResultWork.SlipNote2;                   // 伝票備考２
                dr[DCMIT02104EA.ct_Col_SlipNote3] = estimateListResultWork.SlipNote3;                   // 伝票備考３
                dr[DCMIT02104EA.ct_Col_EstimateDivide] = estimateListResultWork.EstimateDivide;         // 見積区分
                dr[DCMIT02104EA.ct_Col_BLGoodsCode] = estimateListResultWork.BLGoodsCode;               // BL商品コード
                dr[DCMIT02104EA.ct_Col_BLGoodsFullName] = estimateListResultWork.BLGoodsFullName;       // BL商品コード名称（全角）
                dr[DCMIT02104EA.ct_Col_SalesCode] = estimateListResultWork.SalesCode.ToString("d04");                   // 販売区分コード
                dr[DCMIT02104EA.ct_Col_SalesCdNm] = estimateListResultWork.SalesCdNm;                   // 販売区分名称
                dr[DCMIT02104EA.ct_Col_EstimateValidityDate] = estimateListResultWork.EstimateValidityDate; // 見積有効期限
                dr[DCMIT02104EA.ct_Col_ModelFullName] = estimateListResultWork.ModelFullName;           // 車種全角名称
                dr[DCMIT02104EA.ct_Col_ModelHalfName] = estimateListResultWork.ModelHalfName;           // 車種半角名称
                dr[DCMIT02104EA.ct_Col_FullModel] = estimateListResultWork.FullModel;                   // 型式（フル型）
                dr[DCMIT02104EA.ct_Col_ModelDesignationNo] = estimateListResultWork.ModelDesignationNo; // 型式指定番号
                dr[DCMIT02104EA.ct_Col_CategoryNo] = estimateListResultWork.CategoryNo;                 // 類別番号

                dr[DCMIT02104EA.ct_Col_CarMngCode] = estimateListResultWork.CarMngCode;                 // 車輌管理コード
                // 2008.10.31 30413 犬飼 初年度のチェックを追加 >>>>>>START
                if (estimateListResultWork.FirstEntryDate != DateTime.MinValue)
                {
                    dr[DCMIT02104EA.ct_Col_FirstEntryDate] = TDateTime.DateTimeToString("YYYY/MM", estimateListResultWork.FirstEntryDate);     // 初年度[明細](String)
                }
                else
                {
                    dr[DCMIT02104EA.ct_Col_FirstEntryDate] = "";                                        // 初年度
                }
                // 2008.10.31 30413 犬飼 初年度のチェックを追加 <<<<<<END

                // 2008.10.30 30413 犬飼 類別(明細)を追加 >>>>>>START
                // 類別(明細)の設定
                if ((estimateListResultWork.ModelDesignationNo == 0) && (estimateListResultWork.CategoryNo == 0))
                {
                    // 型式指定番号と類別番号が未設定の場合は、類別は設定しない
                    dr[DCMIT02104EA.ct_Col_CategoryDtl] = "";
                }
                else
                {
                    dr[DCMIT02104EA.ct_Col_CategoryDtl] = estimateListResultWork.ModelDesignationNo.ToString("d05") + "-" + estimateListResultWork.CategoryNo.ToString("d04");
                }
                // 2008.10.30 30413 犬飼 類別(明細)を追加 <<<<<<END
                
                if (estimateListResultWork.EstimateDivide == 3)
                {
                    dr[DCMIT02104EA.ct_Col_EstimateDivideNm] = "検索見積分";                            // 見積区分名称
                }
                else
                {
                    dr[DCMIT02104EA.ct_Col_EstimateDivideNm] = "売上入力分";                            // 見積区分名称
                }                
                // 2008.07.31 30413 犬飼 取得データ項目の追加 <<<<<<END

                // 2008.09.26 30413 犬飼 印字用の項目を追加 >>>>>>START
                // 2009.01.06 30413 犬飼 得意先コードの未設定処理を追加 >>>>>>START
                //dr[DCMIT02104EA.ct_Col_PrtCustomerCode] = estimateListResultWork.CustomerCode.ToString("d08");      // 得意先コード(印字用)
                // 得意先コード(印字用)
                if (estimateListResultWork.CustomerCode == 0)
                {
                    // 得意先コードが未設定
                    dr[DCMIT02104EA.ct_Col_PrtCustomerCode] = "";
                }
                else
                {
                    // 得意先コードが設定済
                    dr[DCMIT02104EA.ct_Col_PrtCustomerCode] = estimateListResultWork.CustomerCode.ToString("d08");
                }
                // 2009.01.06 30413 犬飼 得意先コードの未設定処理を追加 <<<<<<END
                
                // 仕入先コード(印字用)
                if (estimateListResultWork.SupplierCd == 0)
                {
                    // 仕入先コードが未設定
                    dr[DCMIT02104EA.ct_Col_PrtSupplierCd] = "";
                }
                else
                {
                    // 仕入先コードが設定済
                    dr[DCMIT02104EA.ct_Col_PrtSupplierCd] = estimateListResultWork.SupplierCd.ToString("d06");
                }

                // 販売区分コード(印字用)
                if (estimateListResultWork.SalesCode == 0)
                {
                    dr[DCMIT02104EA.ct_Col_PrtSalesCode] = "";
                }
                else
                {
                    dr[DCMIT02104EA.ct_Col_PrtSalesCode] = estimateListResultWork.SalesCode.ToString("d04");
                }

                // BLコード(印字用)
                if (estimateListResultWork.BLGoodsCode == 0)
                {
                    dr[DCMIT02104EA.ct_Col_PrtBLGoodsCode] = "";
                }
                else
                {
                    dr[DCMIT02104EA.ct_Col_PrtBLGoodsCode] = estimateListResultWork.BLGoodsCode.ToString("d05");
                }
                // 2008.09.26 30413 犬飼 印字用の項目を追加 <<<<<<END

                // 2011/11/11 x_zhuxk　＃redmine26537 >>>>>>START
                // 連携伝票出力区分
                if (estimateListResultWork.AutoAnswerDivSCMRF == 0)
                {

                    dr[DCMIT02104EA.ct_Col_AutoAnswerDivSCMRF] = "通常";
                    // 連携伝票対象区分
                    dr[DCMIT02104EA.ct_Col_AcceptOrOrderKindRF] = "通常";
                }
                else if (estimateListResultWork.AutoAnswerDivSCMRF == 1)
                {
                    dr[DCMIT02104EA.ct_Col_AutoAnswerDivSCMRF] = "手動回答";
                    // 連携伝票対象区分
                    if (estimateListResultWork.AcceptOrOrderKindRF == 0)
                    {
                        dr[DCMIT02104EA.ct_Col_AcceptOrOrderKindRF] = "PCCforNS";
                    }
                    else if (estimateListResultWork.AcceptOrOrderKindRF == 1)
                    {
                        dr[DCMIT02104EA.ct_Col_AcceptOrOrderKindRF] = "BLﾊﾟｰﾂｵｰﾀﾞｰ";
                    }
                    else
                    {
                        dr[DCMIT02104EA.ct_Col_AcceptOrOrderKindRF] = "";
                    }

                }
                else if (estimateListResultWork.AutoAnswerDivSCMRF == 2)
                {
                    dr[DCMIT02104EA.ct_Col_AutoAnswerDivSCMRF] = "自動回答";
                    // 連携伝票対象区分
                    if (estimateListResultWork.AcceptOrOrderKindRF == 0)
                    {
                        dr[DCMIT02104EA.ct_Col_AcceptOrOrderKindRF] = "PCCforNS";
                    }
                    else if (estimateListResultWork.AcceptOrOrderKindRF == 1)
                    {
                        dr[DCMIT02104EA.ct_Col_AcceptOrOrderKindRF] = "BLﾊﾟｰﾂｵｰﾀﾞｰ";
                    }
                    else
                    {
                        dr[DCMIT02104EA.ct_Col_AcceptOrOrderKindRF] = "";
                    }
                }
                else
                {
                    dr[DCMIT02104EA.ct_Col_AutoAnswerDivSCMRF] = "";
                }            
                // 2011/11/11 x_zhuxk　＃redmine26537 <<<<<<END

                
                #endregion

				// TableにAdd
				this._stockManagementListDt.Rows.Add( dr );
			}

            // --- ADD 2009/02/02 -------------------------------->>>>>
            // 発行タイプ「見積計上」の場合、見積残数によるフィルタ処理
            if (estimateListCndtn.PrintDiv == 0)
            {
                FilterByAcptAnOdrRemainCnt();
            }
            // --- ADD 2009/02/02 -------------------------------->>>>>

			// DataView作成
			this._stockManagementListDataView = new DataView( this._stockManagementListDt, "", GetSortOrder(estimateListCndtn), DataViewRowState.CurrentRows );
		}

        // --- ADD ADD 2009/02/02 -------------------------------->>>>>
        /// <summary>
        /// 見積残数フィルタ処理
        /// </summary>
        /// <remarks>
        /// <br>明細の数量と見積残数が全て同じ伝票を削除する</br>
        /// </remarks>
        private void FilterByAcptAnOdrRemainCnt()
        {
            // 伝票番号順にソート
            DataTable copyTable = this._stockManagementListDt.Copy();

            DataRow[] drList = copyTable.Select("", DCMIT02104EA.ct_Col_SalesSlipNum);

            this._stockManagementListDt.Rows.Clear();

            foreach (DataRow sortedRow in drList)
            {
                this._stockManagementListDt.ImportRow(sortedRow);
            }


            bool isOK = false; // 印字対象フラグ
            DataRow dr;
            List<int> sameSlipRowIndex = new List<int>();
            // 前回処理伝票番号
            string beforeSalesSlip = string.Empty;
            for (int i = this._stockManagementListDt.Rows.Count - 1; i >= 0; i--)
            {
                dr = this._stockManagementListDt.Rows[i];

                if (dr[DCMIT02104EA.ct_Col_SalesSlipNum].ToString() == beforeSalesSlip)
                {
                    if (!isOK)
                    {
                        // チェック
                        isOK = this.CheckByAcptAnOdrRemainCnt(dr);
                    }

                    sameSlipRowIndex.Add(i);
                }
                else
                {
                    if (beforeSalesSlip != string.Empty
                        && !isOK)
                    {
                        // 削除処理実行
                        foreach (int delIndex in sameSlipRowIndex)
                        {
                            this._stockManagementListDt.Rows.RemoveAt(delIndex);
                        }
                    }

                    // 初期化
                    isOK = false;
                    sameSlipRowIndex.Clear();
                    beforeSalesSlip = dr[DCMIT02104EA.ct_Col_SalesSlipNum].ToString();

                    // チェック
                    isOK = this.CheckByAcptAnOdrRemainCnt(dr);

                    sameSlipRowIndex.Add(i);
                }

                if (i == 0)
                {
                    if (!isOK)
                    {
                        // 削除処理実行
                        foreach (int delIndex in sameSlipRowIndex)
                        {
                            this._stockManagementListDt.Rows.RemoveAt(delIndex);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 1明細の受注残数チェック
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private bool CheckByAcptAnOdrRemainCnt(DataRow dr)
        {
            //if ((double)dr[DCMIT02104EA.ct_Col_ShipmentCnt] != (double)dr[DCMIT02104EA.ct_Col_AcptAnOdrRemainCnt]) // DEL 2009/02/13
            if ((double)dr[DCMIT02104EA.ct_Col_AcceptAnOrderCntPlusAdjustCnt] != (double)dr[DCMIT02104EA.ct_Col_AcptAnOdrRemainCnt]) // ADD 2009/02/13
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // --- ADD 2009/02/02 -------------------------------->>>>>

        /// <summary>
        /// 拠点ガイド名称取得
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点ガイド名称</returns>
        private string GetSectionGuideNm( string sectionCode )
        {
            if ( stc_SectionDic.ContainsKey( sectionCode ) ) {
                return stc_SectionDic[sectionCode].SectionGuideNm;
            }
            else {
                return string.Empty;
            }
        }
		#endregion

		#region ◎ ソート順作成
		/// <summary>
		/// ソート順作成
		/// </summary>
		/// <returns>ソート文字列</returns>
		private string GetSortOrder( EstimateListCndtn estimateListCndtn )
		{
			StringBuilder strSortOrder = new StringBuilder();

            //if ( !estimateListCndtn.IsSelectAllSection )
            //{
            //    // 全社選択されてないとき
            //    // 主拠点
            //    strSortOrder.Append( string.Format("{0},", DCMIT02104EA.ct_Col_SectionCode ) );
            //}

            // 2008.10.30 30413 犬飼 ソートのキー順序を変更 >>>>>>START
            // 拠点コード
            strSortOrder.Append( string.Format( "{0},", DCMIT02104EA.ct_Col_ResultsAddUpSecCd ) );
            //// 倉庫コード
            //strSortOrder.Append( string.Format( "{0},", DCMIT02104EA.ct_Col_WarehouseCode ) );
            // 得意先
            strSortOrder.Append( string.Format( "{0},", DCMIT02104EA.ct_Col_CustomerCode ) );
            // --- ADD 2009/04/01 -------------------------------->>>>>
            // 見積日
            strSortOrder.Append( string.Format( "{0},", DCMIT02104EA.ct_Col_SalesDate ) );
            // --- ADD 2009/04/01 --------------------------------<<<<<
            // 伝票番号
            strSortOrder.Append( string.Format( "{0},", DCMIT02104EA.ct_Col_SalesSlipNum ) );
            // 伝票行番号
            strSortOrder.Append( string.Format( "{0}", DCMIT02104EA.ct_Col_SalesRowNo ) );
            // 2008.10.30 30413 犬飼 ソートのキー順序を変更 <<<<<<END
            
			return strSortOrder.ToString();
		}
		#endregion

		#endregion ◆ データ展開処理

		#region ◆ 帳票設定データ取得
		#region ◎ 帳票出力設定取得処理
		/// <summary>
		/// 帳票出力設定読込
		/// </summary>
		/// <param name="retPrtOutSet">帳票出力設定データクラス</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>status</returns>
		/// <remarks>
		/// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
		/// <br>Programmer : 22018 kubo</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		static public int ReadPrtOutSet(out PrtOutSet retPrtOutSet, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			retPrtOutSet = new PrtOutSet();
			errMsg = "";	

			try
			{
				// データは読込済みか？
				if (stc_PrtOutSet != null)
				{
					retPrtOutSet = stc_PrtOutSet.Clone(); 
					status    = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
				} 
				else 
				{
					status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

					switch(status)
					{
						case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
							retPrtOutSet = stc_PrtOutSet.Clone();
							status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
							break;
						case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
						case (int)ConstantManagement.DB_Status.ctDB_EOF      :
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                            break;
						default:
							errMsg = "帳票出力設定の読込に失敗しました";
							status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
							break;
					}
				}
			}
			catch(Exception ex)
			{
				errMsg = ex.Message;
				retPrtOutSet = new PrtOutSet();
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
		#endregion
		#endregion ◆ 帳票設定データ取得
		#endregion ■ Private Method

	}
}

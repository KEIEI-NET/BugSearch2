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
    /// 売上推移表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 売上推移表で使用するデータを取得する。</br>
    /// <br>Programmer   : 22018 鈴木 正臣</br>
    /// <br>Date         : 2007.11.26</br>
    /// <br>Update Note  : 2008.10.16 30452 上野 俊治</br>
    /// <br>              ・PM.NS対応</br>
    /// <br>Update Note  : 2008.12.09 30452 上野 俊治</br>
    /// <br>              ・障害対応(ID:8960)</br>
    /// <br>Update Note  : 2009/04/01 30452 上野 俊治</br>
    /// <br>              ・障害対応12870</br>
    /// <br>Update Note  : 2009/04/15 張莉莉</br>
    /// <br>              ・売上推移表（仕入先別）の追加</br>
    /// <br>Update Note  : 2009/06/24 張莉莉</br>
    /// <br>              ・仕入コードは「0」の場合、仕入名は「未登録」へ変更</br>
    /// <br>Update Note  : 2010/05/13　長内 数馬</br>
    /// <br>             ・明細単位「品番」以外で品名取得を行わないように修正</br>
    /// <br>Update Note  : 2014/12/16 劉超</br>
    /// <br>管理番号     : 11070263-00</br>
    /// <br>             :・明治産業様Seiken品番変更</br>
    /// <br>             : </br>
    /// </remarks>
	public class SalesTransListAcs
	{
		#region ■ Constructor
		/// <summary>
		/// 売上推移表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 売上推移表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.11.26</br>
		/// </remarks>
		public SalesTransListAcs()
		{
            // 2009.02.09 30413 犬飼 商品マスタアクセスクラスは未使用 >>>>>>START
            //this._goodsAcs = new GoodsAcs();                 // 商品マスタアクセスクラス    // ADD 2008/11/06 不具合対応[7301]
            // 2009.02.09 30413 犬飼 商品マスタアクセスクラスは未使用 <<<<<<END
            this._iSalesTransListResultDB = (ISalesTransListResultDB)MediationSalesTransListResultDB.GetSalesTransListResultDB();
		}

		/// <summary>
		/// 売上推移表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 売上推移表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.11.26</br>
		/// </remarks>
        static SalesTransListAcs ()
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

            foreach ( SecInfoSet secInfoSet in secInfoSetList )
            {
                // 既存でなければ
                if ( !stc_SectionDic.ContainsKey( secInfoSet.SectionCode ) )
                {
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
        ISalesTransListResultDB _iSalesTransListResultDB;

        private DataTable _salesTransListDt;			// 印刷DataTable
		private DataView _salesTransListDataView;	// 印刷DataView

        // 2009.02.09 30413 犬飼 商品マスタアクセスクラスは未使用 >>>>>>START
        //private GoodsAcs _goodsAcs;                     // 商品マスタアクセスクラス     // ADD 2008/11/06 不具合対応[7301]
        // 2009.02.09 30413 犬飼 商品マスタアクセスクラスは未使用 <<<<<<END
		#endregion ■ Private Member

		#region ■ Public Property
		/// <summary>
		/// 印刷データセット(読み取り専用)
		/// </summary>
		public DataView StockManagementListDataView
		{
			get{ return this._salesTransListDataView; }
		}
		#endregion ■ Public Property

		#region ■ Public Method
		#region ◆ 出力データ取得
		#region ◎ 入金データ取得
		/// <summary>
		/// データ取得
		/// </summary>
		/// <param name="salesTransListCndtn">抽出条件</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷するデータを取得する。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.11.26</br>
		/// </remarks>
        public int SearchMain ( SalesTransListCndtn salesTransListCndtn, out string errMsg )
		{
            return this.SearchProc(salesTransListCndtn, out errMsg);
		}
		#endregion
		#endregion ◆ 出力データ取得
		#endregion ■ Public Method

		#region ■ Private Method
		#region ◆ 帳票データ取得
		#region ◎ 売上月次集計データ取得
		/// <summary>
		/// 売上月次集計データ取得
		/// </summary>
		/// <param name="salesTransListCndtn"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する売上月次集計データを取得する。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.11.26</br>
		/// </remarks>
        private int SearchProc ( SalesTransListCndtn salesTransListCndtn, out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

			try
			{
				// DataTable Create ----------------------------------------------------------
				DCTOK02134EA.CreateDataTable( ref this._salesTransListDt );
				
				SalesTransListCndtnWork salesTransListCndtnWork = new SalesTransListCndtnWork();
				// 抽出条件展開  --------------------------------------------------------------
				status = this.DevListCndtn( salesTransListCndtn, out salesTransListCndtnWork, out errMsg );
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

				// データ取得  ----------------------------------------------------------------
				object retWorkList = null;

                status = this._iSalesTransListResultDB.Search( out retWorkList, salesTransListCndtnWork );

                // テスト用
                //status = this.testproc(out retWorkList); // ADD 2008/10/16

                switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						// データ展開処理
						DevStockMoveData( salesTransListCndtn, (ArrayList)retWorkList );
                        //status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL; // DEL 2008/11/04 不具合対応[7303]
                        // ADD 2008/11/04 不具合対応[7303] ---------->>>>>
                        if (this._salesTransListDataView.Count > 0)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        // ADD 2008/11/04 不具合対応[7303] ----------<<<<<
						break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
					default:
						errMsg = "売上月次集計データの取得に失敗しました。";
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
		/// <param name="salesTransListCndtn">UI抽出条件クラス</param>
		/// <param name="salesTransListCndtnWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
        /// <remarks>
        /// <br>Update Note : 2014/12/16 劉超</br>
        /// <br>管理番号    : 11070263-00</br>
        /// <br>            :・明治産業様Seiken品番変更</br>
        /// </remarks>
        private int DevListCndtn ( SalesTransListCndtn salesTransListCndtn, out SalesTransListCndtnWork salesTransListCndtnWork, out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;
			salesTransListCndtnWork = new SalesTransListCndtnWork();
			try
			{
                salesTransListCndtnWork.EnterpriseCode = salesTransListCndtn.EnterpriseCode;  // 企業コード
				
                // 抽出条件パラメータセット
				if ( salesTransListCndtn.AddUpSecCodes.Length != 0 )
				{
				    if ( salesTransListCndtn.IsSelectAllSection )
				    {
				        // 全社の時
                        //salesTransListCndtnWork.AddUpSecCodes = null; // DEL 2008/10/16
                        salesTransListCndtnWork.SectionCodes = null; // ADD 2008/10/16
				    }
				    else
				    {
                        //salesTransListCndtnWork.AddUpSecCodes = salesTransListCndtn.AddUpSecCodes; // DEL 2008/10/16
                        salesTransListCndtnWork.SectionCodes = salesTransListCndtn.AddUpSecCodes; // ADD 2008/10/16
				    }
				}
				else
				{
                    //salesTransListCndtnWork.AddUpSecCodes = null; // DEL 2008/10/16
                    salesTransListCndtnWork.SectionCodes = null; // ADD 2008/10/16
				}
                // --- DEL 2008/10/16 -------------------------------->>>>>
                //salesTransListCndtnWork.GroupBySectionDiv = (int)salesTransListCndtn.GroupBySectionDiv; // 拠点別集計区分
                //salesTransListCndtnWork.PrintSelectDiv = (int)salesTransListCndtn.PrintSelectDiv; // 帳票集計区分
                //salesTransListCndtnWork.St_ThisYearMonth = GetYearMonthFromDateTime(salesTransListCndtn.St_ThisYearMonth); // 開始当期月
                //salesTransListCndtnWork.Ed_ThisYearMonth = GetYearMonthFromDateTime(salesTransListCndtn.Ed_ThisYearMonth); // 終了当期月
                //salesTransListCndtnWork.StockOrderDiv = (int)salesTransListCndtn.StockOrderDiv; // 在庫取寄区分
                //salesTransListCndtnWork.St_SubSectionCode = salesTransListCndtn.St_SubSectionCode; // 開始部門コード
                //salesTransListCndtnWork.Ed_SubSectionCode = salesTransListCndtn.Ed_SubSectionCode; // 終了部門コード
                //salesTransListCndtnWork.St_MinSectionCode = salesTransListCndtn.St_MinSectionCode; // 開始課コード
                //salesTransListCndtnWork.Ed_MinSectionCode = salesTransListCndtn.Ed_MinSectionCode; // 終了課コード
                //salesTransListCndtnWork.St_EmployeeCode = salesTransListCndtn.St_EmployeeCode; // 開始従業員コード
                //salesTransListCndtnWork.Ed_EmployeeCode = salesTransListCndtn.Ed_EmployeeCode; // 終了従業員コード
                //salesTransListCndtnWork.St_CustomerCode = salesTransListCndtn.St_CustomerCode; // 開始得意先コード
                //salesTransListCndtnWork.Ed_CustomerCode = salesTransListCndtn.Ed_CustomerCode; // 終了得意先コード
                //salesTransListCndtnWork.St_GoodsMakerCd = salesTransListCndtn.St_GoodsMakerCd; // 開始商品メーカーコード
                //salesTransListCndtnWork.Ed_GoodsMakerCd = salesTransListCndtn.Ed_GoodsMakerCd; // 終了商品メーカーコード
                //salesTransListCndtnWork.St_GoodsNo = salesTransListCndtn.St_GoodsNo; // 開始商品番号
                //salesTransListCndtnWork.Ed_GoodsNo = salesTransListCndtn.Ed_GoodsNo; // 終了商品番号
                //salesTransListCndtnWork.St_BLGoodsCode = salesTransListCndtn.St_BLGoodsCode; // 開始BL商品コード
                //salesTransListCndtnWork.Ed_BLGoodsCode = salesTransListCndtn.Ed_BLGoodsCode; // 終了BL商品コード
                //salesTransListCndtnWork.St_LargeGoodsGanreCode = salesTransListCndtn.St_LargeGoodsGanreCode; // 開始商品区分グループコード
                //salesTransListCndtnWork.Ed_LargeGoodsGanreCode = salesTransListCndtn.Ed_LargeGoodsGanreCode; // 終了商品区分グループコード
                //salesTransListCndtnWork.St_MediumGoodsGanreCode = salesTransListCndtn.St_MediumGoodsGanreCode; // 開始商品区分コード
                //salesTransListCndtnWork.Ed_MediumGoodsGanreCode = salesTransListCndtn.Ed_MediumGoodsGanreCode; // 終了商品区分コード
                //salesTransListCndtnWork.St_DetailGoodsGanreCode = salesTransListCndtn.St_DetailGoodsGanreCode; // 開始商品区分詳細コード
                //salesTransListCndtnWork.Ed_DetailGoodsGanreCode = salesTransListCndtn.Ed_DetailGoodsGanreCode; // 終了商品区分詳細コード
                //salesTransListCndtnWork.St_EnterpriseGanreCode = salesTransListCndtn.St_EnterpriseGanreCode; // 開始自社分類コード
                //salesTransListCndtnWork.Ed_EnterpriseGanreCode = salesTransListCndtn.Ed_EnterpriseGanreCode; // 終了自社分類コード
                //salesTransListCndtnWork.St_SupplierCd = salesTransListCndtn.St_SupplierCd; // 開始仕入先コード
                //salesTransListCndtnWork.Ed_SupplierCd = salesTransListCndtn.Ed_SupplierCd; // 終了仕入先コード

                //salesTransListCndtnWork.St_TotalSalesCount = salesTransListCndtn.St_ShipmentCnt;  // 開始出荷数
                //salesTransListCndtnWork.Ed_TotalSalesCount = salesTransListCndtn.Ed_ShipmentCnt;  // 終了出荷数
                
                //// 集計単位は固定
                //salesTransListCndtnWork.SummaryUnit = 0;
                // --- DEL 2008/10/16 --------------------------------<<<<<
                // --- ADD 2008/10/16 -------------------------------->>>>>
                salesTransListCndtnWork.EnterpriseCode = salesTransListCndtn.EnterpriseCode; // 企業コード
                salesTransListCndtnWork.TotalType = (int)salesTransListCndtn.TotalType; // 帳票集計区分
                salesTransListCndtnWork.TtlType = (int)salesTransListCndtn.TtlType; // 拠点集計区分
                salesTransListCndtnWork.RsltTtlDivCd = (int)salesTransListCndtn.StockOrderDiv; // 在庫取寄区分
                salesTransListCndtnWork.MakerPrintDiv = (int)salesTransListCndtn.MakerPrintDiv; // メーカー別印刷区分
                salesTransListCndtnWork.Detail = salesTransListCndtn.Detail; // 明細単位
                //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
                // 帳票集計区分が「商品別」、且つ明細単位が「品番」場合
                if (((int)salesTransListCndtn.TotalType == 0) && (salesTransListCndtn.Detail == 0))
                {
                    salesTransListCndtnWork.GoodsNoTtlDiv = (int)salesTransListCndtn.GoodsNoTtlDiv; // 品番集計区分
                    // 品番集計区分が「合算」時
                    if ((int)salesTransListCndtn.GoodsNoTtlDiv == 1)
                    {
                        salesTransListCndtnWork.GoodsNoShowDiv = (int)salesTransListCndtn.GoodsNoShowDiv; // 品番表示区分
                    }
                }
                //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<
                salesTransListCndtnWork.AddUpYearMonthSt = salesTransListCndtn.St_ThisYearMonth; // 開始年月
                salesTransListCndtnWork.AddUpYearMonthEd = salesTransListCndtn.Ed_ThisYearMonth; // 終了年月
                salesTransListCndtnWork.PrintRangeSt = salesTransListCndtn.St_ShipmentCnt; // 開始出荷数
                salesTransListCndtnWork.PrintRangeEd = salesTransListCndtn.Ed_ShipmentCnt; // 終了出荷数
                salesTransListCndtnWork.CustomerCodeSt = salesTransListCndtn.St_CustomerCode; // 開始得意先コード
                salesTransListCndtnWork.CustomerCodeEd = salesTransListCndtn.Ed_CustomerCode; // 終了得意先コード
                salesTransListCndtnWork.SupplierCodeSt = salesTransListCndtn.St_SupplierCode; // 開始仕入先コード  // ADD 2009/04/15
                salesTransListCndtnWork.SupplierCodeEd = salesTransListCndtn.Ed_SupplierCode; // 終了仕入先コード  // ADD 2009/04/15
                salesTransListCndtnWork.EmployeeCodeSt = salesTransListCndtn.St_EmployeeCode; // 開始担当者コード
                salesTransListCndtnWork.EmployeeCodeEd = salesTransListCndtn.Ed_EmployeeCode; // 終了担当者コード
                salesTransListCndtnWork.GoodsMakerCdSt = salesTransListCndtn.St_GoodsMakerCd; // 開始メーカーコード
                salesTransListCndtnWork.GoodsMakerCdEd = salesTransListCndtn.Ed_GoodsMakerCd; // 終了メーカーコード
                salesTransListCndtnWork.GoodsLGroupSt = salesTransListCndtn.St_GoodsLGroup; // 開始商品大分類コード
                salesTransListCndtnWork.GoodsLGroupEd = salesTransListCndtn.Ed_GoodsLGroup; // 終了商品大分類コード
                salesTransListCndtnWork.GoodsMGroupSt = salesTransListCndtn.St_GoodsMGroup; // 開始商品中分類コード
                salesTransListCndtnWork.GoodsMGroupEd = salesTransListCndtn.Ed_GoodsMGroup; // 終了商品中分類コード
                salesTransListCndtnWork.BLGroupCodeSt = salesTransListCndtn.St_BLGroupCode; // 開始BLグループコード
                salesTransListCndtnWork.BLGroupCodeEd = salesTransListCndtn.Ed_BLGroupCode; // 終了BLグループコード
                salesTransListCndtnWork.BLGoodsCodeSt = salesTransListCndtn.St_BLGoodsCode; // 開始BLコード
                salesTransListCndtnWork.BLGoodsCodeEd = salesTransListCndtn.Ed_BLGoodsCode; // 終了BLコード
                salesTransListCndtnWork.GoodsNoSt = salesTransListCndtn.St_GoodsNo; // 開始品番
                salesTransListCndtnWork.GoodsNoEd = salesTransListCndtn.Ed_GoodsNo; // 終了品番
                // --- ADD 2008/10/16 --------------------------------<<<<<
			}
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
        /// <summary>
        /// 年月取得処理（YYYYMM ← DateTime）
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private int GetYearMonthFromDateTime(DateTime dateTime)
        {
            // 年月をYYYYMMのintで返す
            return (dateTime.Year * 100 + dateTime.Month);
        }
		#endregion

		#region ◎ 取得データ展開処理
		/// <summary>
		/// 取得データ展開処理
		/// </summary>
		/// <param name="salesTransListCndtn">UI抽出条件クラス</param>
        /// <param name="resultWork">取得データ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 取得データを展開する。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.11.26</br>
		/// </remarks>
		private void DevStockMoveData ( SalesTransListCndtn salesTransListCndtn, ArrayList resultWork )
		{
			DataRow dr;

            foreach ( SalesTransListResultWork salesTransListResultWork in resultWork )
			{
				dr = this._salesTransListDt.NewRow();
				// 取得データ展開
				#region 取得データ展開
                dr[DCTOK02134EA.ct_Col_AddUpSecCode] = salesTransListResultWork.AddUpSecCode; // 計上拠点コード
                dr[DCTOK02134EA.ct_Col_CompanyName1] = salesTransListResultWork.CompanyName1; // 自社名称1
                // --- DEL 2008/10/16 -------------------------------->>>>>
                //dr[DCTOK02134EA.ct_Col_CompanyName2] = salesTransListResultWork.CompanyName2; // 自社名称2
                //dr[DCTOK02134EA.ct_Col_SectionGuideNm] = salesTransListResultWork.SectionGuideNm; // 拠点ガイド名称
                //dr[DCTOK02134EA.ct_Col_SubSectionCode] = salesTransListResultWork.SubSectionCode; // 部門コード
                //dr[DCTOK02134EA.ct_Col_SubSectionName] = salesTransListResultWork.SubSectionName; // 部門名称
                //dr[DCTOK02134EA.ct_Col_MinSectionCode] = salesTransListResultWork.MinSectionCode; // 課コード
                //dr[DCTOK02134EA.ct_Col_MinSectionName] = salesTransListResultWork.MinSectionName; // 課名称
                // --- DEL 2008/10/16 --------------------------------<<<<<
                dr[DCTOK02134EA.ct_Col_EmployeeCode] = salesTransListResultWork.EmployeeCode; // 従業員コード
                //dr[DCTOK02134EA.ct_Col_EmployeeName] = salesTransListResultWork.EmployeeName; // 従業員名称 // DEL 2008/10/16
                dr[DCTOK02134EA.ct_Col_EmployeeName] = salesTransListResultWork.Name; // 従業員名称 // ADD 2008/10/16
                dr[DCTOK02134EA.ct_Col_CustomerCode] = salesTransListResultWork.CustomerCode; // 得意先コード
                dr[DCTOK02134EA.ct_Col_CustomerSnm] = salesTransListResultWork.CustomerSnm; // 得意先略称

                dr[DCTOK02134EA.ct_Col_SupplierCode] = salesTransListResultWork.SupplierCode; // 仕入先コード　 // ADD 2009/04/15
                if (salesTransListResultWork.SupplierCode == 0 || string.Empty.Equals(salesTransListResultWork.SupplierSnm))    // ADD 2009/06/24
                {
                    dr[DCTOK02134EA.ct_Col_SupplierSnm] = "未登録"; // 仕入先略称   
                }
                else
                {
                    dr[DCTOK02134EA.ct_Col_SupplierSnm] = salesTransListResultWork.SupplierSnm; // 仕入先略称   // ADD 2009/04/15
                }
                dr[DCTOK02134EA.ct_Col_GoodsMakerCd] = salesTransListResultWork.GoodsMakerCd; // 商品メーカーコード
                //dr[DCTOK02134EA.ct_Col_MakerName] = salesTransListResultWork.MakerName; // メーカー名称
                dr[DCTOK02134EA.ct_Col_MakerShortName] = salesTransListResultWork.MakerShortName; // メーカー名称
                // --- DEL 2008/10/16 -------------------------------->>>>>
                //dr[DCTOK02134EA.ct_Col_LargeGoodsGanreCode] = salesTransListResultWork.LargeGoodsGanreCode; // 商品区分グループコード
                //dr[DCTOK02134EA.ct_Col_LargeGoodsGanreName] = salesTransListResultWork.LargeGoodsGanreName; // 商品区分グループ名称
                //dr[DCTOK02134EA.ct_Col_MediumGoodsGanreCode] = salesTransListResultWork.MediumGoodsGanreCode; // 商品区分コード
                //dr[DCTOK02134EA.ct_Col_MediumGoodsGanreName] = salesTransListResultWork.MediumGoodsGanreName; // 商品区分名称
                //dr[DCTOK02134EA.ct_Col_DetailGoodsGanreCode] = salesTransListResultWork.DetailGoodsGanreCode; // 商品区分詳細コード
                //dr[DCTOK02134EA.ct_Col_DetailGoodsGanreName] = salesTransListResultWork.DetailGoodsGanreName; // 商品区分詳細名称
                // --- DEL 2008/10/16 --------------------------------<<<<<
                // --- ADD 2008/10/16 -------------------------------->>>>>
                dr[DCTOK02134EA.ct_Col_GoodsLGroup] = salesTransListResultWork.GoodsLGroup; // 商品大分類コード
                dr[DCTOK02134EA.ct_Col_GoodsLGroupName] = salesTransListResultWork.GoodsLGroupName; // 商品大分類名称
                dr[DCTOK02134EA.ct_Col_GoodsMGroup] = salesTransListResultWork.GoodsMGroup; // 商品中分類コード
                dr[DCTOK02134EA.ct_Col_GoodsMGroupName] = salesTransListResultWork.GoodsMGroupName; // 商品中分類名称
                dr[DCTOK02134EA.ct_Col_BLGroupCode] = salesTransListResultWork.BLGroupCode; // ＢＬグループコード
                dr[DCTOK02134EA.ct_Col_BLGroupKanaName] = salesTransListResultWork.BLGroupKanaName; // ＢＬグループコード名称
                // --- ADD 2008/10/16 --------------------------------<<<<<
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //dr[DCTOK02134EA.ct_Col_EnterpriseGanreCode] = salesTransListResultWork.EnterpriseGanreCode; // 自社分類コード // DEL 2008/10/16
                //dr[DCTOK02134EA.ct_Col_EnterpriseGanreName] = salesTransListResultWork.EnterpriseGanreName; // 自社分類名称 // DEL 2008/10/16
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                dr[DCTOK02134EA.ct_Col_BLGoodsCode] = salesTransListResultWork.BLGoodsCode; // BL商品コード
                //dr[DCTOK02134EA.ct_Col_BLGoodsFullName] = salesTransListResultWork.BLGoodsFullName; // BL商品コード名称（全角） // DEL 2008/10/16
                dr[DCTOK02134EA.ct_Col_BLGoodsHalfName] = salesTransListResultWork.BLGoodsHalfName; // BL商品コード名称（半角） // ADD 2008/10/16
                dr[DCTOK02134EA.ct_Col_GoodsNo] = salesTransListResultWork.GoodsNo; // 商品番号
                //dr[DCTOK02134EA.ct_Col_GoodsShortName] = salesTransListResultWork.GoodsShortName; // 商品名略称 // DEL 2008/10/16
                // DEL 2008/11/06 不具合対応[7301] ↓
                //dr[DCTOK02134EA.ct_Col_GoodsNameKana] = salesTransListResultWork.GoodsNameKana; // 商品名略称 // ADD 2008/10/16

                // ADD 2008/11/06 不具合対応[7301] ---------->>>>>
                // 品名取得
                if (!string.IsNullOrEmpty(salesTransListResultWork.GoodsNo))  // ADD 2010/05/13 //明細単位が品番の場合のみ品名の取得を行う
                {  // ADD 2010/05/13
                    if (string.IsNullOrEmpty(salesTransListResultWork.GoodsNameKana.Trim()) == false)
                    {
                        dr[DCTOK02134EA.ct_Col_GoodsNameKana] = salesTransListResultWork.GoodsNameKana;                      // 商品名称カナ
                    }
                    else
                    {
                        // 商品マスタ（提供）の名称取得

                        // 2009.02.09 30413 犬飼 速度アップ対応 >>>>>>START
                        //List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
                        //GoodsUnitData goodsUnitData = new GoodsUnitData();
                        //string msg = string.Empty;
                        //GoodsCndtn cndtn = new GoodsCndtn();
                        //cndtn.EnterpriseCode = salesTransListCndtn.EnterpriseCode;           // 企業コード
                        //cndtn.GoodsMakerCd = salesTransListResultWork.GoodsMakerCd;          // メーカーコード
                        //cndtn.GoodsNo = salesTransListResultWork.GoodsNo;                    // 品番
                        //cndtn.SectionCode = salesTransListResultWork.AddUpSecCode;           // 拠点コード
                        //int status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(cndtn, false, out goodsUnitDataList, out msg);
                        //if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        //{
                        //    if (goodsUnitDataList.Count > 0)
                        //    {
                        //        //取得できた場合
                        //        goodsUnitData = goodsUnitDataList[0];
                        //        if (goodsUnitData.OfferKubun == 0)
                        //        {
                        //            // 提供データ以外
                        //            dr[DCTOK02134EA.ct_Col_GoodsNameKana] = salesTransListResultWork.BLGoodsHalfName;        // BL商品コード名称（半角）
                        //        }
                        //        else
                        //        {
                        //            // 提供データ
                        //            dr[DCTOK02134EA.ct_Col_GoodsNameKana] = goodsUnitData.GoodsNameKana;                    // 提供データの名称カナ
                        //        }
                        //    }
                        //    else
                        //    {
                        //        // 取得できなかった場合
                        //        dr[DCTOK02134EA.ct_Col_GoodsNameKana] = salesTransListResultWork.BLGoodsHalfName;            // BL商品コード名称（半角）
                        //    }
                        //}
                        //else
                        //{
                        //    // 取得できなかった場合
                        //    dr[DCTOK02134EA.ct_Col_GoodsNameKana] = salesTransListResultWork.BLGoodsHalfName;                // BL商品コード名称（半角）
                        //}

                        string goodsNameKana = string.Empty;
                        // -- UPD 2010/05/13 -------------------------------------------------------->>>
                        //int status = GoodsAcs.GetGoodsNameKana(salesTransListResultWork.GoodsMakerCd, salesTransListResultWork.GoodsNo, out goodsNameKana);
                        int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        if (salesTransListResultWork.GoodsMakerCd != 0)
                        {
                            status = GoodsAcs.GetGoodsNameKana(salesTransListResultWork.GoodsMakerCd, salesTransListResultWork.GoodsNo, out goodsNameKana);
                        }
                        // -- UPD 2010/05/13 --------------------------------------------------------<<<

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            if (!string.IsNullOrEmpty(goodsNameKana))
                            {
                                dr[DCTOK02134EA.ct_Col_GoodsNameKana] = goodsNameKana;      // 品名
                            }
                            else
                            {
                                dr[DCTOK02134EA.ct_Col_GoodsNameKana] = salesTransListResultWork.BLGoodsHalfName;            // BL商品コード名称（半角）
                            }
                        }
                        else
                        {
                            // 取得できなかった場合
                            dr[DCTOK02134EA.ct_Col_GoodsNameKana] = salesTransListResultWork.BLGoodsHalfName;                // BL商品コード名称（半角）
                        }
                        // 2009.02.09 30413 犬飼 速度アップ対応 <<<<<<END
                    }
                }  // ADD 2010/05/13

                // ADD 2008/11/06 不具合対応[7301] ----------<<<<<

                dr[DCTOK02134EA.ct_Col_TotalSalesCount1] = salesTransListResultWork.TotalSalesCount1; // 月売上数計1
                dr[DCTOK02134EA.ct_Col_TotalSalesCount2] = salesTransListResultWork.TotalSalesCount2; // 月売上数計2
                dr[DCTOK02134EA.ct_Col_TotalSalesCount3] = salesTransListResultWork.TotalSalesCount3; // 月売上数計3
                dr[DCTOK02134EA.ct_Col_TotalSalesCount4] = salesTransListResultWork.TotalSalesCount4; // 月売上数計4
                dr[DCTOK02134EA.ct_Col_TotalSalesCount5] = salesTransListResultWork.TotalSalesCount5; // 月売上数計5
                dr[DCTOK02134EA.ct_Col_TotalSalesCount6] = salesTransListResultWork.TotalSalesCount6; // 月売上数計6
                dr[DCTOK02134EA.ct_Col_TotalSalesCount7] = salesTransListResultWork.TotalSalesCount7; // 月売上数計7
                dr[DCTOK02134EA.ct_Col_TotalSalesCount8] = salesTransListResultWork.TotalSalesCount8; // 月売上数計8
                dr[DCTOK02134EA.ct_Col_TotalSalesCount9] = salesTransListResultWork.TotalSalesCount9; // 月売上数計9
                dr[DCTOK02134EA.ct_Col_TotalSalesCount10] = salesTransListResultWork.TotalSalesCount10; // 月売上数計10
                dr[DCTOK02134EA.ct_Col_TotalSalesCount11] = salesTransListResultWork.TotalSalesCount11; // 月売上数計11
                dr[DCTOK02134EA.ct_Col_TotalSalesCount12] = salesTransListResultWork.TotalSalesCount12; // 月売上数計12
                // --- DEL 2008/10/16 -------------------------------->>>>>
                //dr[DCTOK02134EA.ct_Col_SalesTotalTaxExc1] = salesTransListResultWork.SalesTotalTaxExc1; // 月売上伝票合計1（税抜き）
                //dr[DCTOK02134EA.ct_Col_SalesTotalTaxExc2] = salesTransListResultWork.SalesTotalTaxExc2; // 月売上伝票合計2（税抜き）
                //dr[DCTOK02134EA.ct_Col_SalesTotalTaxExc3] = salesTransListResultWork.SalesTotalTaxExc3; // 月売上伝票合計3（税抜き）
                //dr[DCTOK02134EA.ct_Col_SalesTotalTaxExc4] = salesTransListResultWork.SalesTotalTaxExc4; // 月売上伝票合計4（税抜き）
                //dr[DCTOK02134EA.ct_Col_SalesTotalTaxExc5] = salesTransListResultWork.SalesTotalTaxExc5; // 月売上伝票合計5（税抜き）
                //dr[DCTOK02134EA.ct_Col_SalesTotalTaxExc6] = salesTransListResultWork.SalesTotalTaxExc6; // 月売上伝票合計6（税抜き）
                //dr[DCTOK02134EA.ct_Col_SalesTotalTaxExc7] = salesTransListResultWork.SalesTotalTaxExc7; // 月売上伝票合計7（税抜き）
                //dr[DCTOK02134EA.ct_Col_SalesTotalTaxExc8] = salesTransListResultWork.SalesTotalTaxExc8; // 月売上伝票合計8（税抜き）
                //dr[DCTOK02134EA.ct_Col_SalesTotalTaxExc9] = salesTransListResultWork.SalesTotalTaxExc9; // 月売上伝票合計9（税抜き）
                //dr[DCTOK02134EA.ct_Col_SalesTotalTaxExc10] = salesTransListResultWork.SalesTotalTaxExc10; // 月売上伝票合計10（税抜き）
                //dr[DCTOK02134EA.ct_Col_SalesTotalTaxExc11] = salesTransListResultWork.SalesTotalTaxExc11; // 月売上伝票合計11（税抜き）
                //dr[DCTOK02134EA.ct_Col_SalesTotalTaxExc12] = salesTransListResultWork.SalesTotalTaxExc12; // 月売上伝票合計12（税抜き）
                //dr[DCTOK02134EA.ct_Col_SalesRetGoodsPrice1] = salesTransListResultWork.SalesRetGoodsPrice1; // 月返品額1
                //dr[DCTOK02134EA.ct_Col_SalesRetGoodsPrice2] = salesTransListResultWork.SalesRetGoodsPrice2; // 月返品額2
                //dr[DCTOK02134EA.ct_Col_SalesRetGoodsPrice3] = salesTransListResultWork.SalesRetGoodsPrice3; // 月返品額3
                //dr[DCTOK02134EA.ct_Col_SalesRetGoodsPrice4] = salesTransListResultWork.SalesRetGoodsPrice4; // 月返品額4
                //dr[DCTOK02134EA.ct_Col_SalesRetGoodsPrice5] = salesTransListResultWork.SalesRetGoodsPrice5; // 月返品額5
                //dr[DCTOK02134EA.ct_Col_SalesRetGoodsPrice6] = salesTransListResultWork.SalesRetGoodsPrice6; // 月返品額6
                //dr[DCTOK02134EA.ct_Col_SalesRetGoodsPrice7] = salesTransListResultWork.SalesRetGoodsPrice7; // 月返品額7
                //dr[DCTOK02134EA.ct_Col_SalesRetGoodsPrice8] = salesTransListResultWork.SalesRetGoodsPrice8; // 月返品額8
                //dr[DCTOK02134EA.ct_Col_SalesRetGoodsPrice9] = salesTransListResultWork.SalesRetGoodsPrice9; // 月返品額9
                //dr[DCTOK02134EA.ct_Col_SalesRetGoodsPrice10] = salesTransListResultWork.SalesRetGoodsPrice10; // 月返品額10
                //dr[DCTOK02134EA.ct_Col_SalesRetGoodsPrice11] = salesTransListResultWork.SalesRetGoodsPrice11; // 月返品額11
                //dr[DCTOK02134EA.ct_Col_SalesRetGoodsPrice12] = salesTransListResultWork.SalesRetGoodsPrice12; // 月返品額12
                //dr[DCTOK02134EA.ct_Col_SalesPrice1] = 0; // 月純売上金額1 (別途算出)
                //dr[DCTOK02134EA.ct_Col_SalesPrice2] = 0; // 月純売上金額2 (別途算出)
                //dr[DCTOK02134EA.ct_Col_SalesPrice3] = 0; // 月純売上金額3 (別途算出)
                //dr[DCTOK02134EA.ct_Col_SalesPrice4] = 0; // 月純売上金額4 (別途算出)
                //dr[DCTOK02134EA.ct_Col_SalesPrice5] = 0; // 月純売上金額5 (別途算出)
                //dr[DCTOK02134EA.ct_Col_SalesPrice6] = 0; // 月純売上金額6 (別途算出)
                //dr[DCTOK02134EA.ct_Col_SalesPrice7] = 0; // 月純売上金額7 (別途算出)
                //dr[DCTOK02134EA.ct_Col_SalesPrice8] = 0; // 月純売上金額8 (別途算出)
                //dr[DCTOK02134EA.ct_Col_SalesPrice9] = 0; // 月純売上金額9 (別途算出)
                //dr[DCTOK02134EA.ct_Col_SalesPrice10] = 0; // 月純売上金額10 (別途算出)
                //dr[DCTOK02134EA.ct_Col_SalesPrice11] = 0; // 月純売上金額11 (別途算出)
                //dr[DCTOK02134EA.ct_Col_SalesPrice12] = 0; // 月純売上金額12 (別途算出)
                //dr[DCTOK02134EA.ct_Col_TtlTotalSalesCount] = 0; // 売上数合計 (別途算出)
                //dr[DCTOK02134EA.ct_Col_TtlSalesPrice] = 0; // 純売上金額合計 (別途算出)
                // --- DEL 2008/10/16 --------------------------------<<<<<
                // --- ADD 2008/10/16 -------------------------------->>>>>
                dr[DCTOK02134EA.ct_Col_SalesMoney1] = salesTransListResultWork.SalesMoney1; // 売上金額1
                dr[DCTOK02134EA.ct_Col_SalesMoney2] = salesTransListResultWork.SalesMoney2; // 売上金額2
                dr[DCTOK02134EA.ct_Col_SalesMoney3] = salesTransListResultWork.SalesMoney3; // 売上金額3
                dr[DCTOK02134EA.ct_Col_SalesMoney4] = salesTransListResultWork.SalesMoney4; // 売上金額4
                dr[DCTOK02134EA.ct_Col_SalesMoney5] = salesTransListResultWork.SalesMoney5; // 売上金額5
                dr[DCTOK02134EA.ct_Col_SalesMoney6] = salesTransListResultWork.SalesMoney6; // 売上金額6
                dr[DCTOK02134EA.ct_Col_SalesMoney7] = salesTransListResultWork.SalesMoney7; // 売上金額7
                dr[DCTOK02134EA.ct_Col_SalesMoney8] = salesTransListResultWork.SalesMoney8; // 売上金額8
                dr[DCTOK02134EA.ct_Col_SalesMoney9] = salesTransListResultWork.SalesMoney9; // 売上金額9
                dr[DCTOK02134EA.ct_Col_SalesMoney10] = salesTransListResultWork.SalesMoney10; // 売上金額10
                dr[DCTOK02134EA.ct_Col_SalesMoney11] = salesTransListResultWork.SalesMoney11; // 売上金額11
                dr[DCTOK02134EA.ct_Col_SalesMoney12] = salesTransListResultWork.SalesMoney12; // 売上金額12
                // --- ADD 2008/10/16 --------------------------------<<<<<
                #endregion

                // 金額の計算とセット
                SetPriceAndCount( ref dr );

                // 金額単位の適用
                ReflectPriceUnit( salesTransListCndtn, ref dr );

                // --- DEL 2009/04/01 -------------------------------->>>>>
                //// ADD 2008/11/04 不具合対応[7303] ---------->>>>>
                //if (((double)dr[DCTOK02134EA.ct_Col_TotalSalesCount1]
                //          + (double)dr[DCTOK02134EA.ct_Col_TotalSalesCount2]
                //          + (double)dr[DCTOK02134EA.ct_Col_TotalSalesCount3]
                //          + (double)dr[DCTOK02134EA.ct_Col_TotalSalesCount4]
                //          + (double)dr[DCTOK02134EA.ct_Col_TotalSalesCount5]
                //          + (double)dr[DCTOK02134EA.ct_Col_TotalSalesCount6]
                //          + (double)dr[DCTOK02134EA.ct_Col_TotalSalesCount7]
                //          + (double)dr[DCTOK02134EA.ct_Col_TotalSalesCount8]
                //          + (double)dr[DCTOK02134EA.ct_Col_TotalSalesCount9]
                //          + (double)dr[DCTOK02134EA.ct_Col_TotalSalesCount10]
                //          + (double)dr[DCTOK02134EA.ct_Col_TotalSalesCount11]
                //          + (double)dr[DCTOK02134EA.ct_Col_TotalSalesCount12]) != 0 ||
                //    ((Int64)dr[DCTOK02134EA.ct_Col_SalesMoney1]
                //        + (Int64)dr[DCTOK02134EA.ct_Col_SalesMoney2]
                //        + (Int64)dr[DCTOK02134EA.ct_Col_SalesMoney3]
                //        + (Int64)dr[DCTOK02134EA.ct_Col_SalesMoney4]
                //        + (Int64)dr[DCTOK02134EA.ct_Col_SalesMoney5]
                //        + (Int64)dr[DCTOK02134EA.ct_Col_SalesMoney6]
                //        + (Int64)dr[DCTOK02134EA.ct_Col_SalesMoney7]
                //        + (Int64)dr[DCTOK02134EA.ct_Col_SalesMoney8]
                //        + (Int64)dr[DCTOK02134EA.ct_Col_SalesMoney9]
                //        + (Int64)dr[DCTOK02134EA.ct_Col_SalesMoney10]
                //        + (Int64)dr[DCTOK02134EA.ct_Col_SalesMoney11]
                //        + (Int64)dr[DCTOK02134EA.ct_Col_SalesMoney12]) != 0)
                //{
                //// ADD 2008/11/04 不具合対応[7303] ----------<<<<<
                // --- DEL 2009/04/01 --------------------------------<<<<<
                // --- ADD 2009/04/01 -------------------------------->>>>>
                if (
                    (double)dr[DCTOK02134EA.ct_Col_TotalSalesCount1] != 0
                    || (double)dr[DCTOK02134EA.ct_Col_TotalSalesCount2] != 0
                    || (double)dr[DCTOK02134EA.ct_Col_TotalSalesCount3] != 0
                    || (double)dr[DCTOK02134EA.ct_Col_TotalSalesCount4] != 0
                    || (double)dr[DCTOK02134EA.ct_Col_TotalSalesCount5] != 0
                    || (double)dr[DCTOK02134EA.ct_Col_TotalSalesCount6] != 0
                    || (double)dr[DCTOK02134EA.ct_Col_TotalSalesCount7] != 0
                    || (double)dr[DCTOK02134EA.ct_Col_TotalSalesCount8] != 0
                    || (double)dr[DCTOK02134EA.ct_Col_TotalSalesCount9] != 0
                    || (double)dr[DCTOK02134EA.ct_Col_TotalSalesCount10] != 0
                    || (double)dr[DCTOK02134EA.ct_Col_TotalSalesCount11] != 0
                    || (double)dr[DCTOK02134EA.ct_Col_TotalSalesCount12] != 0
                    || (Int64)dr[DCTOK02134EA.ct_Col_SalesMoney1] != 0
                    || (Int64)dr[DCTOK02134EA.ct_Col_SalesMoney2] != 0
                    || (Int64)dr[DCTOK02134EA.ct_Col_SalesMoney3] != 0
                    || (Int64)dr[DCTOK02134EA.ct_Col_SalesMoney4] != 0
                    || (Int64)dr[DCTOK02134EA.ct_Col_SalesMoney5] != 0
                    || (Int64)dr[DCTOK02134EA.ct_Col_SalesMoney6] != 0
                    || (Int64)dr[DCTOK02134EA.ct_Col_SalesMoney7] != 0
                    || (Int64)dr[DCTOK02134EA.ct_Col_SalesMoney8] != 0
                    || (Int64)dr[DCTOK02134EA.ct_Col_SalesMoney9] != 0
                    || (Int64)dr[DCTOK02134EA.ct_Col_SalesMoney10] != 0
                    || (Int64)dr[DCTOK02134EA.ct_Col_SalesMoney11] != 0
                    || (Int64)dr[DCTOK02134EA.ct_Col_SalesMoney12] != 0
                    )
                {
                // --- ADD 2009/04/01 --------------------------------<<<<<
                    // TableにAdd
                    this._salesTransListDt.Rows.Add(dr);
                // ADD 2008/11/04 不具合対応[7303] ---------->>>>>
                }
                // ADD 2008/11/04 不具合対応[7303] ----------<<<<<
			}

			// DataView作成
			this._salesTransListDataView = new DataView( this._salesTransListDt, "", GetSortOrder(salesTransListCndtn), DataViewRowState.CurrentRows );
		}
        /// <summary>
        /// 金額・数量　計算処理
        /// </summary>
        private void SetPriceAndCount (ref DataRow row)
        {
            // --- DEL 2008/10/16 -------------------------------->>>>>
            //// 純売上金額
            //row[DCTOK02134EA.ct_Col_SalesPrice1] = (Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc1] + (Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice1];
            //row[DCTOK02134EA.ct_Col_SalesPrice2] = (Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc2] + (Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice2];
            //row[DCTOK02134EA.ct_Col_SalesPrice3] = (Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc3] + (Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice3];
            //row[DCTOK02134EA.ct_Col_SalesPrice4] = (Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc4] + (Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice4];
            //row[DCTOK02134EA.ct_Col_SalesPrice5] = (Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc5] + (Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice5];
            //row[DCTOK02134EA.ct_Col_SalesPrice6] = (Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc6] + (Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice6];
            //row[DCTOK02134EA.ct_Col_SalesPrice7] = (Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc7] + (Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice7];
            //row[DCTOK02134EA.ct_Col_SalesPrice8] = (Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc8] + (Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice8];
            //row[DCTOK02134EA.ct_Col_SalesPrice9] = (Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc9] + (Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice9];
            //row[DCTOK02134EA.ct_Col_SalesPrice10] = (Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc10] + (Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice10];
            //row[DCTOK02134EA.ct_Col_SalesPrice11] = (Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc11] + (Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice11];
            //row[DCTOK02134EA.ct_Col_SalesPrice12] = (Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc12] + (Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice12];
            // --- DEL 2008/10/16 --------------------------------<<<<<

            // １２か月合計（横計）
            // 　売上数計
            row[DCTOK02134EA.ct_Col_TtlTotalSalesCount] = (double)row[DCTOK02134EA.ct_Col_TotalSalesCount1]
                                                          + (double)row[DCTOK02134EA.ct_Col_TotalSalesCount2]
                                                          + (double)row[DCTOK02134EA.ct_Col_TotalSalesCount3]
                                                          + (double)row[DCTOK02134EA.ct_Col_TotalSalesCount4]
                                                          + (double)row[DCTOK02134EA.ct_Col_TotalSalesCount5]
                                                          + (double)row[DCTOK02134EA.ct_Col_TotalSalesCount6]
                                                          + (double)row[DCTOK02134EA.ct_Col_TotalSalesCount7]
                                                          + (double)row[DCTOK02134EA.ct_Col_TotalSalesCount8]
                                                          + (double)row[DCTOK02134EA.ct_Col_TotalSalesCount9]
                                                          + (double)row[DCTOK02134EA.ct_Col_TotalSalesCount10]
                                                          + (double)row[DCTOK02134EA.ct_Col_TotalSalesCount11]
                                                          + (double)row[DCTOK02134EA.ct_Col_TotalSalesCount12];
            
            // --- DEL 2008/10/16 -------------------------------->>>>>
            //// 　純売上金額計
            //row[DCTOK02134EA.ct_Col_TtlSalesPrice] = (Int64)row[DCTOK02134EA.ct_Col_SalesPrice1]
            //                                         + (Int64)row[DCTOK02134EA.ct_Col_SalesPrice2]
            //                                         + (Int64)row[DCTOK02134EA.ct_Col_SalesPrice3]
            //                                         + (Int64)row[DCTOK02134EA.ct_Col_SalesPrice4]
            //                                         + (Int64)row[DCTOK02134EA.ct_Col_SalesPrice5]
            //                                         + (Int64)row[DCTOK02134EA.ct_Col_SalesPrice6]
            //                                         + (Int64)row[DCTOK02134EA.ct_Col_SalesPrice7]
            //                                         + (Int64)row[DCTOK02134EA.ct_Col_SalesPrice8]
            //                                         + (Int64)row[DCTOK02134EA.ct_Col_SalesPrice9]
            //                                         + (Int64)row[DCTOK02134EA.ct_Col_SalesPrice10]
            //                                         + (Int64)row[DCTOK02134EA.ct_Col_SalesPrice11]
            //                                         + (Int64)row[DCTOK02134EA.ct_Col_SalesPrice12];
            // --- DEL 2008/10/16 --------------------------------<<<<<
            // --- ADD 2008/10/16 -------------------------------->>>>>
            row[DCTOK02134EA.ct_Col_TtlSalesMoney] = (Int64)row[DCTOK02134EA.ct_Col_SalesMoney1]
                                                        + (Int64)row[DCTOK02134EA.ct_Col_SalesMoney2]
                                                        + (Int64)row[DCTOK02134EA.ct_Col_SalesMoney3]
                                                        + (Int64)row[DCTOK02134EA.ct_Col_SalesMoney4]
                                                        + (Int64)row[DCTOK02134EA.ct_Col_SalesMoney5]
                                                        + (Int64)row[DCTOK02134EA.ct_Col_SalesMoney6]
                                                        + (Int64)row[DCTOK02134EA.ct_Col_SalesMoney7]
                                                        + (Int64)row[DCTOK02134EA.ct_Col_SalesMoney8]
                                                        + (Int64)row[DCTOK02134EA.ct_Col_SalesMoney9]
                                                        + (Int64)row[DCTOK02134EA.ct_Col_SalesMoney10]
                                                        + (Int64)row[DCTOK02134EA.ct_Col_SalesMoney11]
                                                        + (Int64)row[DCTOK02134EA.ct_Col_SalesMoney12];
            // --- ADD 2008/10/16 --------------------------------<<<<<

        }
        /// <summary>
        /// 金額単位　適用処理
        /// </summary>
        /// <param name="salesTransListCndtn"></param>
        /// <param name="row"></param>
        /// <remarks>
        /// <br>各種金額項目に金額単位によるまるめ処理を適用します。（切り捨て固定）</br>
        /// <br>※注意：本メソッド実行前に全ての金額計算・率計算が終了している事を前提とします。</br>
		/// ------------------------------------------------------------------------------------------------------
		/// <br>UpDateNote : 円単位→千円単位の計算を、「÷1000」ではなく「÷1000して小数点を四捨五入」に変更</br>
		/// <br>Programmer : 30191 馬淵 愛</br>
		/// <br>Date       : 2008.04.07</br>
		/// </remarks>
        private void ReflectPriceUnit (SalesTransListCndtn salesTransListCndtn, ref DataRow row)
        {
			//08.04.07 Mabuchi Delete & Add START---------------------------------------------------------------------------------------------------------------------
				//int priceUnit = 1;

				//if ( salesTransListCndtn.PriceUnitDiv == SalesTransListCndtn.PriceUnitDivState.One )
				//{
				//    // 処理は不要
				//    return;
				//}
				//else if ( salesTransListCndtn.PriceUnitDiv == SalesTransListCndtn.PriceUnitDivState.Thousand )
				//{
				//    // 千円単位
				//    priceUnit = 1000;
				//}

            // 各種金額項目を丸める (金額 / 金額単位)

            //SalesTransListResultWork salesTransListResultWork = new SalesTransListResultWork(); // DEL 2008/10/16

            
			if (salesTransListCndtn.PriceUnitDiv == SalesTransListCndtn.PriceUnitDivState.One)
			{
				// 処理は不要
				return;
			}
			else if (salesTransListCndtn.PriceUnitDiv == SalesTransListCndtn.PriceUnitDivState.Thousand)
			{
                // --- DEL 2008/10/16 -------------------------------->>>>>
                //decimal SalesTotalTaxExc1; decimal SalesTotalTaxExc2; decimal SalesTotalTaxExc3; decimal SalesTotalTaxExc4; decimal SalesTotalTaxExc5; decimal SalesTotalTaxExc6;
                //decimal SalesTotalTaxExc7; decimal SalesTotalTaxExc8; decimal SalesTotalTaxExc9; decimal SalesTotalTaxExc10; decimal SalesTotalTaxExc11; decimal SalesTotalTaxExc12;

                //decimal SalesRetGoodsPrice1; decimal SalesRetGoodsPrice2; decimal SalesRetGoodsPrice3; decimal SalesRetGoodsPrice4; decimal SalesRetGoodsPrice5; decimal SalesRetGoodsPrice6;
                //decimal SalesRetGoodsPrice7; decimal SalesRetGoodsPrice8; decimal SalesRetGoodsPrice9; decimal SalesRetGoodsPrice10; decimal SalesRetGoodsPrice11; decimal SalesRetGoodsPrice12;

                //decimal SalesPrice1; decimal SalesPrice2; decimal SalesPrice3; decimal SalesPrice4; decimal SalesPrice5; decimal SalesPrice6;
                //decimal SalesPrice7; decimal SalesPrice8; decimal SalesPrice9; decimal SalesPrice10; decimal SalesPrice11; decimal SalesPrice12;

                //decimal TtlSalesPrice;
                // --- DEL 2008/10/16 --------------------------------<<<<<

				//売上
                // --- DEL 2008/10/16 -------------------------------->>>>>
                //SalesTotalTaxExc1 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc1]) / 1000m;
                //SalesTotalTaxExc2 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc2]) / 1000m;
                //SalesTotalTaxExc3 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc3]) / 1000m;
                //SalesTotalTaxExc4 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc4]) / 1000m;
                //SalesTotalTaxExc5 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc5]) / 1000m;
                //SalesTotalTaxExc6 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc6]) / 1000m;
                //SalesTotalTaxExc7 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc7]) / 1000m;
                //SalesTotalTaxExc8 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc8]) / 1000m;
                //SalesTotalTaxExc9 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc9]) / 1000m;
                //SalesTotalTaxExc10 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc10]) / 1000m;
                //SalesTotalTaxExc11 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc11]) / 1000m;
                //SalesTotalTaxExc12 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc12]) / 1000m;
                //row[DCTOK02134EA.ct_Col_SalesTotalTaxExc1] = (Int64)(Math.Round(SalesTotalTaxExc1, 0, MidpointRounding.AwayFromZero));
                //row[DCTOK02134EA.ct_Col_SalesTotalTaxExc2] = (Int64)(Math.Round(SalesTotalTaxExc2, 0, MidpointRounding.AwayFromZero));
                //row[DCTOK02134EA.ct_Col_SalesTotalTaxExc3] = (Int64)(Math.Round(SalesTotalTaxExc3, 0, MidpointRounding.AwayFromZero));
                //row[DCTOK02134EA.ct_Col_SalesTotalTaxExc4] = (Int64)(Math.Round(SalesTotalTaxExc4, 0, MidpointRounding.AwayFromZero));
                //row[DCTOK02134EA.ct_Col_SalesTotalTaxExc5] = (Int64)(Math.Round(SalesTotalTaxExc5, 0, MidpointRounding.AwayFromZero));
                //row[DCTOK02134EA.ct_Col_SalesTotalTaxExc6] = (Int64)(Math.Round(SalesTotalTaxExc6, 0, MidpointRounding.AwayFromZero));
                //row[DCTOK02134EA.ct_Col_SalesTotalTaxExc7] = (Int64)(Math.Round(SalesTotalTaxExc7, 0, MidpointRounding.AwayFromZero));
                //row[DCTOK02134EA.ct_Col_SalesTotalTaxExc8] = (Int64)(Math.Round(SalesTotalTaxExc8, 0, MidpointRounding.AwayFromZero));
                //row[DCTOK02134EA.ct_Col_SalesTotalTaxExc9] = (Int64)(Math.Round(SalesTotalTaxExc9, 0, MidpointRounding.AwayFromZero));
                //row[DCTOK02134EA.ct_Col_SalesTotalTaxExc10] = (Int64)(Math.Round(SalesTotalTaxExc10, 0, MidpointRounding.AwayFromZero));
                //row[DCTOK02134EA.ct_Col_SalesTotalTaxExc11] = (Int64)(Math.Round(SalesTotalTaxExc11, 0, MidpointRounding.AwayFromZero));
                //row[DCTOK02134EA.ct_Col_SalesTotalTaxExc12] = (Int64)(Math.Round(SalesTotalTaxExc12, 0, MidpointRounding.AwayFromZero));

                ////返品
                //SalesRetGoodsPrice1 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice1]) / 1000m;
                //SalesRetGoodsPrice2 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice2]) / 1000m;
                //SalesRetGoodsPrice3 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice3]) / 1000m;
                //SalesRetGoodsPrice4 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice4]) / 1000m;
                //SalesRetGoodsPrice5 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice5]) / 1000m;
                //SalesRetGoodsPrice6 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice6]) / 1000m;
                //SalesRetGoodsPrice7 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice7]) / 1000m;
                //SalesRetGoodsPrice8 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice8]) / 1000m;
                //SalesRetGoodsPrice9 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice9]) / 1000m;
                //SalesRetGoodsPrice10 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice10]) / 1000m;
                //SalesRetGoodsPrice11 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice11]) / 1000m;
                //SalesRetGoodsPrice12 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice12]) / 1000m;
                //row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice1] = (Int64)(Math.Round(SalesRetGoodsPrice1, 0, MidpointRounding.AwayFromZero));
                //row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice2] = (Int64)(Math.Round(SalesRetGoodsPrice2, 0, MidpointRounding.AwayFromZero));
                //row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice3] = (Int64)(Math.Round(SalesRetGoodsPrice3, 0, MidpointRounding.AwayFromZero));
                //row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice4] = (Int64)(Math.Round(SalesRetGoodsPrice4, 0, MidpointRounding.AwayFromZero));
                //row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice5] = (Int64)(Math.Round(SalesRetGoodsPrice5, 0, MidpointRounding.AwayFromZero));
                //row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice6] = (Int64)(Math.Round(SalesRetGoodsPrice6, 0, MidpointRounding.AwayFromZero));
                //row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice7] = (Int64)(Math.Round(SalesRetGoodsPrice7, 0, MidpointRounding.AwayFromZero));
                //row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice8] = (Int64)(Math.Round(SalesRetGoodsPrice8, 0, MidpointRounding.AwayFromZero));
                //row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice9] = (Int64)(Math.Round(SalesRetGoodsPrice9, 0, MidpointRounding.AwayFromZero));
                //row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice10] = (Int64)(Math.Round(SalesRetGoodsPrice10, 0, MidpointRounding.AwayFromZero));
                //row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice11] = (Int64)(Math.Round(SalesRetGoodsPrice11, 0, MidpointRounding.AwayFromZero));
                //row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice12] = (Int64)(Math.Round(SalesRetGoodsPrice12, 0, MidpointRounding.AwayFromZero));
                
				// 純売上
                //SalesPrice1 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesPrice1]) / 1000m;
                //SalesPrice2 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesPrice2]) / 1000m;
                //SalesPrice3 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesPrice3]) / 1000m;
                //SalesPrice4 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesPrice4]) / 1000m;
                //SalesPrice5 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesPrice5]) / 1000m;
                //SalesPrice6 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesPrice6]) / 1000m;
                //SalesPrice7 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesPrice7]) / 1000m;
                //SalesPrice8 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesPrice8]) / 1000m;
                //SalesPrice9 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesPrice9]) / 1000m;
                //SalesPrice10 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesPrice10]) / 1000m;
                //SalesPrice11 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesPrice11]) / 1000m;
                //SalesPrice12 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesPrice12]) / 1000m;
                //row[DCTOK02134EA.ct_Col_SalesPrice1] = (Int64)(Math.Round(SalesPrice1, 0, MidpointRounding.AwayFromZero));
                //row[DCTOK02134EA.ct_Col_SalesPrice2] = (Int64)(Math.Round(SalesPrice2, 0, MidpointRounding.AwayFromZero));
                //row[DCTOK02134EA.ct_Col_SalesPrice3] = (Int64)(Math.Round(SalesPrice3, 0, MidpointRounding.AwayFromZero));
                //row[DCTOK02134EA.ct_Col_SalesPrice4] = (Int64)(Math.Round(SalesPrice4, 0, MidpointRounding.AwayFromZero));
                //row[DCTOK02134EA.ct_Col_SalesPrice5] = (Int64)(Math.Round(SalesPrice5, 0, MidpointRounding.AwayFromZero));
                //row[DCTOK02134EA.ct_Col_SalesPrice6] = (Int64)(Math.Round(SalesPrice6, 0, MidpointRounding.AwayFromZero));
                //row[DCTOK02134EA.ct_Col_SalesPrice7] = (Int64)(Math.Round(SalesPrice7, 0, MidpointRounding.AwayFromZero));
                //row[DCTOK02134EA.ct_Col_SalesPrice8] = (Int64)(Math.Round(SalesPrice8, 0, MidpointRounding.AwayFromZero));
                //row[DCTOK02134EA.ct_Col_SalesPrice9] = (Int64)(Math.Round(SalesPrice9, 0, MidpointRounding.AwayFromZero));
                //row[DCTOK02134EA.ct_Col_SalesPrice10] = (Int64)(Math.Round(SalesPrice10, 0, MidpointRounding.AwayFromZero));
                //row[DCTOK02134EA.ct_Col_SalesPrice11] = (Int64)(Math.Round(SalesPrice11, 0, MidpointRounding.AwayFromZero));
                //row[DCTOK02134EA.ct_Col_SalesPrice12] = (Int64)(Math.Round(SalesPrice12, 0, MidpointRounding.AwayFromZero));    

                //// 純売上合計（横計）
                //TtlSalesPrice = (decimal)((Int64)row[DCTOK02134EA.ct_Col_TtlSalesPrice]) / 1000m;
                //row[DCTOK02134EA.ct_Col_TtlSalesPrice] = (Int64)(Math.Round(TtlSalesPrice, 0, MidpointRounding.AwayFromZero));
                // --- DEL 2008/10/16 --------------------------------<<<<<


				//// 売上
				//row[DCTOK02134EA.ct_Col_SalesTotalTaxExc1] = (Int64)((decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc1]) / (decimal)priceUnit);
				//row[DCTOK02134EA.ct_Col_SalesTotalTaxExc2] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc2] ) / (decimal)priceUnit );
				//row[DCTOK02134EA.ct_Col_SalesTotalTaxExc3] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc3] ) / (decimal)priceUnit );
				//row[DCTOK02134EA.ct_Col_SalesTotalTaxExc4] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc4] ) / (decimal)priceUnit );
				//row[DCTOK02134EA.ct_Col_SalesTotalTaxExc5] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc5] ) / (decimal)priceUnit );
				//row[DCTOK02134EA.ct_Col_SalesTotalTaxExc6] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc6] ) / (decimal)priceUnit );
				//row[DCTOK02134EA.ct_Col_SalesTotalTaxExc7] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc7] ) / (decimal)priceUnit );
				//row[DCTOK02134EA.ct_Col_SalesTotalTaxExc8] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc8] ) / (decimal)priceUnit );
				//row[DCTOK02134EA.ct_Col_SalesTotalTaxExc9] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc9] ) / (decimal)priceUnit );
				//row[DCTOK02134EA.ct_Col_SalesTotalTaxExc10] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc10] ) / (decimal)priceUnit );
				//row[DCTOK02134EA.ct_Col_SalesTotalTaxExc11] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc11] ) / (decimal)priceUnit );
				//row[DCTOK02134EA.ct_Col_SalesTotalTaxExc12] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesTotalTaxExc12] ) / (decimal)priceUnit );

				//// 返品
				//row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice1] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice1] ) / (decimal)priceUnit );
				//row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice2] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice2] ) / (decimal)priceUnit );
				//row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice3] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice3] ) / (decimal)priceUnit );
				//row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice4] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice4] ) / (decimal)priceUnit );
				//row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice5] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice5] ) / (decimal)priceUnit );
				//row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice6] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice6] ) / (decimal)priceUnit );
				//row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice7] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice7] ) / (decimal)priceUnit );
				//row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice8] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice8] ) / (decimal)priceUnit );
				//row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice9] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice9] ) / (decimal)priceUnit );
				//row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice10] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice10] ) / (decimal)priceUnit );
				//row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice11] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice11] ) / (decimal)priceUnit );
				//row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice12] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesRetGoodsPrice12] ) / (decimal)priceUnit );

				//// 純売上
				//row[DCTOK02134EA.ct_Col_SalesPrice1] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesPrice1] ) / (decimal)priceUnit );
				//row[DCTOK02134EA.ct_Col_SalesPrice2] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesPrice2] ) / (decimal)priceUnit );
				//row[DCTOK02134EA.ct_Col_SalesPrice3] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesPrice3] ) / (decimal)priceUnit );
				//row[DCTOK02134EA.ct_Col_SalesPrice4] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesPrice4] ) / (decimal)priceUnit );
				//row[DCTOK02134EA.ct_Col_SalesPrice5] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesPrice5] ) / (decimal)priceUnit );
				//row[DCTOK02134EA.ct_Col_SalesPrice6] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesPrice6] ) / (decimal)priceUnit );
				//row[DCTOK02134EA.ct_Col_SalesPrice7] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesPrice7] ) / (decimal)priceUnit );
				//row[DCTOK02134EA.ct_Col_SalesPrice8] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesPrice8] ) / (decimal)priceUnit );
				//row[DCTOK02134EA.ct_Col_SalesPrice9] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesPrice9] ) / (decimal)priceUnit );
				//row[DCTOK02134EA.ct_Col_SalesPrice10] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesPrice10] ) / (decimal)priceUnit );
				//row[DCTOK02134EA.ct_Col_SalesPrice11] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesPrice11] ) / (decimal)priceUnit );
				//row[DCTOK02134EA.ct_Col_SalesPrice12] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_SalesPrice12] ) / (decimal)priceUnit );    

				//// 純売上合計（横計）
				//row[DCTOK02134EA.ct_Col_TtlSalesPrice] = (Int64)( (decimal)( (Int64)row[DCTOK02134EA.ct_Col_TtlSalesPrice] ) / (decimal)priceUnit );
				//08.04.07 Mabuchi Delete & Add END--------------------------------------------------------------------------------------------------------------------
                // --- ADD 2008/10/16 -------------------------------->>>>>
                decimal SalesMoney1; decimal SalesMoney2; decimal SalesMoney3; decimal SalesMoney4; decimal SalesMoney5; decimal SalesMoney6;
                decimal SalesMoney7; decimal SalesMoney8; decimal SalesMoney9; decimal SalesMoney10; decimal SalesMoney11; decimal SalesMoney12;

                decimal TtlSalesMoney;

                // 売上金額
                SalesMoney1 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesMoney1]) / 1000m;
                SalesMoney2 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesMoney2]) / 1000m;
                SalesMoney3 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesMoney3]) / 1000m;
                SalesMoney4 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesMoney4]) / 1000m;
                SalesMoney5 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesMoney5]) / 1000m;
                SalesMoney6 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesMoney6]) / 1000m;
                SalesMoney7 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesMoney7]) / 1000m;
                SalesMoney8 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesMoney8]) / 1000m;
                SalesMoney9 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesMoney9]) / 1000m;
                SalesMoney10 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesMoney10]) / 1000m;
                SalesMoney11 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesMoney11]) / 1000m;
                SalesMoney12 = (decimal)((Int64)row[DCTOK02134EA.ct_Col_SalesMoney12]) / 1000m;
                row[DCTOK02134EA.ct_Col_SalesMoney1] = (Int64)(Math.Round(SalesMoney1, 0, MidpointRounding.AwayFromZero));
                row[DCTOK02134EA.ct_Col_SalesMoney2] = (Int64)(Math.Round(SalesMoney2, 0, MidpointRounding.AwayFromZero));
                row[DCTOK02134EA.ct_Col_SalesMoney3] = (Int64)(Math.Round(SalesMoney3, 0, MidpointRounding.AwayFromZero));
                row[DCTOK02134EA.ct_Col_SalesMoney4] = (Int64)(Math.Round(SalesMoney4, 0, MidpointRounding.AwayFromZero));
                row[DCTOK02134EA.ct_Col_SalesMoney5] = (Int64)(Math.Round(SalesMoney5, 0, MidpointRounding.AwayFromZero));
                row[DCTOK02134EA.ct_Col_SalesMoney6] = (Int64)(Math.Round(SalesMoney6, 0, MidpointRounding.AwayFromZero));
                row[DCTOK02134EA.ct_Col_SalesMoney7] = (Int64)(Math.Round(SalesMoney7, 0, MidpointRounding.AwayFromZero));
                row[DCTOK02134EA.ct_Col_SalesMoney8] = (Int64)(Math.Round(SalesMoney8, 0, MidpointRounding.AwayFromZero));
                row[DCTOK02134EA.ct_Col_SalesMoney9] = (Int64)(Math.Round(SalesMoney9, 0, MidpointRounding.AwayFromZero));
                row[DCTOK02134EA.ct_Col_SalesMoney10] = (Int64)(Math.Round(SalesMoney10, 0, MidpointRounding.AwayFromZero));
                row[DCTOK02134EA.ct_Col_SalesMoney11] = (Int64)(Math.Round(SalesMoney11, 0, MidpointRounding.AwayFromZero));
                row[DCTOK02134EA.ct_Col_SalesMoney12] = (Int64)(Math.Round(SalesMoney12, 0, MidpointRounding.AwayFromZero)); 


                // 売上金額合計
                TtlSalesMoney = (decimal)((Int64)row[DCTOK02134EA.ct_Col_TtlSalesMoney]) / 1000m;
                row[DCTOK02134EA.ct_Col_TtlSalesMoney] = (Int64)(Math.Round(TtlSalesMoney, 0, MidpointRounding.AwayFromZero));
                // --- ADD 2008/10/16 --------------------------------<<<<<
			}
        }
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
		private string GetSortOrder( SalesTransListCndtn salesTransListCndtn )
		{
			StringBuilder strSortOrder = new StringBuilder();


            // 拠点別・全社集計により変動
            //if ( salesTransListCndtn.GroupBySectionDiv == SalesTransListCndtn.GroupBySectionDivState.BySection ) // DEL 2008/10/16
            if (salesTransListCndtn.TtlType == SalesTransListCndtn.TtlTypeState.BySection) // ADD 2008/10/16
            {
                // 拠点コード
                strSortOrder.Append( string.Format( "{0},", DCTOK02134EA.ct_Col_AddUpSecCode ) );
            }


            // 印刷タイプ別のソート順設定
            //switch ( salesTransListCndtn.PrintSelectDiv ) // DEL 2008/10/16
            switch (salesTransListCndtn.TotalType) // ADD 2008/10/16
            {
                // 得意先別
                //case SalesTransListCndtn.PrintSelectDivState.EachCustomer: // DEL 2008/10/16
                case SalesTransListCndtn.TotalTypeState.EachCustomer: // ADD 2008/10/16
                    {
                        // --- DEL 2008/10/16 -------------------------------->>>>>
                        //// 得意先
                        //strSortOrder.Append( string.Format( "{0},", DCTOK02134EA.ct_Col_CustomerCode ) );
                        //// メーカー
                        //strSortOrder.Append( string.Format( "{0},", DCTOK02134EA.ct_Col_GoodsMakerCd ) );
                        //// BL商品コード
                        //strSortOrder.Append( string.Format( "{0}", DCTOK02134EA.ct_Col_BLGoodsCode ) );
                        // --- DEL 2008/10/16 --------------------------------<<<<<
                        // --- ADD 2008/10/16 -------------------------------->>>>>
                        if (salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.GoosNo
                            || salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.BLGoodsCode
                            || salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.BLGroupCode
                            || salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.GoodsMGroup
                            || salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.GoodsLGroup
                            || salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.GoodsMaker
                            || salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.Customer)
                        {
                            strSortOrder.Append(string.Format("{0},", DCTOK02134EA.ct_Col_CustomerCode));
                        }
                        // --- ADD 2008/10/16 --------------------------------<<<<<
                    }
                    break;

                // --- ADD 2009/04/15 -------------------------------->>>>>
                // 仕入先別
                case SalesTransListCndtn.TotalTypeState.EachSupplier:
                    {
                       if (salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.GoosNo
                            || salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.BLGoodsCode
                            || salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.BLGroupCode
                            || salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.GoodsMGroup
                            || salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.GoodsLGroup
                            || salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.GoodsMaker
                            || salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.Supplier)
                        {
                            strSortOrder.Append(string.Format("{0},", DCTOK02134EA.ct_Col_SupplierCode));
                        }
                    }
                    break;
                // --- ADD 2009/04/15 --------------------------------<<<<<

                // 担当者別
                //case SalesTransListCndtn.PrintSelectDivState.EachEmployee: // DEL 2008/10/16
                case SalesTransListCndtn.TotalTypeState.EachEmployee: // ADD 2008/10/16
                    {
                        // --- DEL 2008/10/16 -------------------------------->>>>>
                        //// 担当者
                        //strSortOrder.Append( string.Format( "{0},", DCTOK02134EA.ct_Col_EmployeeCode ) );
                        //// メーカー
                        //strSortOrder.Append( string.Format( "{0},", DCTOK02134EA.ct_Col_GoodsMakerCd ) );
                        //// BL商品コード
                        //strSortOrder.Append( string.Format( "{0}", DCTOK02134EA.ct_Col_BLGoodsCode ) );
                        // --- DEL 2008/10/16 --------------------------------<<<<<
                        // --- ADD 2008/10/16 -------------------------------->>>>>
                        if (salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.GoosNo
                            || salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.BLGoodsCode
                            || salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.BLGroupCode
                            || salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.GoodsMGroup
                            || salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.GoodsLGroup
                            || salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.GoodsMaker
                            || salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.Employee)
                        {
                            strSortOrder.Append(string.Format("{0},", DCTOK02134EA.ct_Col_EmployeeCode));
                        }
                        // --- ADD 2008/10/16 --------------------------------<<<<<
                    }
                    break;
                // 商品別
                //case SalesTransListCndtn.PrintSelectDivState.EachGoods: // DEL 2008/10/16
                case SalesTransListCndtn.TotalTypeState.EachGoods: // ADD 2008/10/16
                    {
                        // --- DEL 2008/10/16 -------------------------------->>>>>
                        //// メーカー
                        //if ( salesTransListCndtn.MakerSumPrintDiv == SalesTransListCndtn.SumPrintDivState.Print )
                        //{
                        //    strSortOrder.Append( string.Format( "{0},", DCTOK02134EA.ct_Col_GoodsMakerCd ) );
                        //}
                        //// 商品区分グループ
                        //if ( salesTransListCndtn.LGoodsGanreSumPrintDiv == SalesTransListCndtn.SumPrintDivState.Print )
                        //{
                        //    strSortOrder.Append( string.Format( "{0},", DCTOK02134EA.ct_Col_LargeGoodsGanreCode ) );
                        //}
                        //// 商品区分
                        //if ( salesTransListCndtn.MGoodsGanreSumPrintDiv == SalesTransListCndtn.SumPrintDivState.Print )
                        //{
                        //    strSortOrder.Append( string.Format( "{0},", DCTOK02134EA.ct_Col_MediumGoodsGanreCode ) );
                        //}
                        //// 商品区分詳細
                        //if ( salesTransListCndtn.DGoodsGanreSumPrintDiv == SalesTransListCndtn.SumPrintDivState.Print )
                        //{
                        //    strSortOrder.Append( string.Format( "{0},", DCTOK02134EA.ct_Col_DetailGoodsGanreCode ) );
                        //}
                        //// 自社分類
                        //if ( salesTransListCndtn.EnterpriseGanreSumPrintDiv == SalesTransListCndtn.SumPrintDivState.Print )
                        //{
                        //    strSortOrder.Append( string.Format( "{0},", DCTOK02134EA.ct_Col_EnterpriseGanreCode ) );
                        //}
                        //// BL商品コード
                        //if ( salesTransListCndtn.BLCodeSumPrintDiv == SalesTransListCndtn.SumPrintDivState.Print )
                        //{
                        //    strSortOrder.Append( string.Format( "{0},", DCTOK02134EA.ct_Col_BLGoodsCode ) );
                        //}

                        //// 商品番号
                        //strSortOrder.Append( string.Format( "{0}", DCTOK02134EA.ct_Col_GoodsNo ) );
                        // --- DEL 2008/10/16 --------------------------------<<<<<
                    }
                    break;
                // (想定外)
                default:
                    // --- DEL 2008/10/16 -------------------------------->>>>>
                    //// メーカー
                    //strSortOrder.Append( string.Format( "{0},", DCTOK02134EA.ct_Col_GoodsMakerCd ) );
                    //// 商品番号
                    //strSortOrder.Append( string.Format( "{0}", DCTOK02134EA.ct_Col_GoodsNo ) );
                    // --- DEL 2008/10/16 -------------------------------->>>>>
                    break;
            }

            // --- ADD 2008/10/16 -------------------------------->>>>>
            //　メーカー以下は共通
            if (salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.GoosNo
                            || salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.BLGoodsCode
                            || salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.BLGroupCode
                            || salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.GoodsMGroup
                            || salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.GoodsLGroup
                            || salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.GoodsMaker)
            {
                strSortOrder.Append(string.Format("{0},", DCTOK02134EA.ct_Col_GoodsMakerCd));
            }

            if (salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.GoosNo
                || salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.BLGoodsCode
                || salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.BLGroupCode
                || salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.GoodsMGroup
                || salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.GoodsLGroup)
            {
                strSortOrder.Append(string.Format("{0},", DCTOK02134EA.ct_Col_GoodsLGroup));
            }

            if (salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.GoosNo
                || salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.BLGoodsCode
                || salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.BLGroupCode
                || salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.GoodsMGroup)
            {
                strSortOrder.Append(string.Format("{0},", DCTOK02134EA.ct_Col_GoodsMGroup));
            }

            if (salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.GoosNo
                || salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.BLGoodsCode
                || salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.BLGroupCode)
            {
                strSortOrder.Append(string.Format("{0},", DCTOK02134EA.ct_Col_BLGroupCode));
            }

            if (salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.GoosNo
                || salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.BLGoodsCode)
            {
                strSortOrder.Append(string.Format("{0},", DCTOK02134EA.ct_Col_BLGoodsCode));
            }

            if (salesTransListCndtn.DetailDataValue == SalesTransListCndtn.DetailDataValueState.GoosNo)
            {
                strSortOrder.Append(string.Format("{0},", DCTOK02134EA.ct_Col_GoodsNo));
            }

            // 余分な"," を削除
            if (strSortOrder.Length != 0) // ADD 2008/12/09
            {
                strSortOrder.Remove(strSortOrder.Length - 1, 1);
            }
            // --- ADD 2008/10/16 --------------------------------<<<<<
            
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
		/// <br>Date       : 2007.11.26</br>
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

        #region ◆　テストデータ
        private int testproc(out object retList)
        {
            ArrayList paramlist = new ArrayList();

            //SalesTransListResultWork param1 = new SalesTransListResultWork();

            //param1.AddUpSecCode = "99";
            //param1.CompanyName1 = "拠点名称は最大桁１桁";
            //param1.GoodsMakerCd = 9999;
            //param1.MakerShortName = "メーカーは最大１０桁";
            //param1.GoodsLGroup = 9999;
            //param1.GoodsLGroupName = "商品大分類は最低１桁";
            //param1.GoodsMGroup = 9999;
            //param1.GoodsMGroupName = "商品中分類は最低１桁";
            //param1.BLGroupCode = 99999;
            //param1.BLGroupKanaName = "0BLｸﾞﾙｰﾌﾟｺｰﾄﾞﾊﾊﾝｶｸｹﾀ";
            //param1.BLGoodsCode = 99999;
            //param1.BLGoodsHalfName = "0BLｺｰﾄﾞﾊﾊﾝｶｸ20ｹﾀﾃﾞｹﾀ";
            //param1.GoodsNo = "111112222233333444445555";
            //param1.GoodsNameKana = "12345678901234567890";
            //param1.CustomerCode = 99999999;
            //param1.CustomerSnm = "得意先名称は最大２０桁かな４５６７８９桁";
            //param1.EmployeeCode = "9999";
            //param1.Name = "従業員名称は最大１桁";

            //param1.SalesMoney1 = 9999999;
            //param1.SalesMoney2 = 9999999;
            //param1.SalesMoney3 = 9999999;
            //param1.SalesMoney4 = 9999999;
            //param1.SalesMoney5 = 9999999;
            //param1.SalesMoney6 = 9999999;
            //param1.SalesMoney7 = 9999999;
            //param1.SalesMoney8 = 9999999;
            //param1.SalesMoney9 = 9999999;
            //param1.SalesMoney10 = 9999999;
            //param1.SalesMoney11 = 9999999;
            //param1.SalesMoney12 = 9999999;

            //param1.TotalSalesCount1 = 8888888;
            //param1.TotalSalesCount2 = 8888888;
            //param1.TotalSalesCount3 = 8888888;
            //param1.TotalSalesCount4 = 8888888;
            //param1.TotalSalesCount5 = 8888888;
            //param1.TotalSalesCount6 = 8888888;
            //param1.TotalSalesCount7 = 8888888;
            //param1.TotalSalesCount8 = 8888888;
            //param1.TotalSalesCount9 = 8888888;
            //param1.TotalSalesCount10 = 8888888;
            //param1.TotalSalesCount11 = 8888888;
            //param1.TotalSalesCount12 = 8888888;

            //paramlist.Add(param1);

            //SalesTransListResultWork param2 = new SalesTransListResultWork();

            //param2.AddUpSecCode = "";
            //param2.CompanyName1 = "";
            //param2.GoodsMakerCd = 0;
            //param2.MakerShortName = "";
            //param2.GoodsLGroup = 0;
            //param2.GoodsLGroupName = "";
            //param2.GoodsMGroup = 0;
            //param2.GoodsMGroupName = "";
            //param2.BLGroupCode = 0;
            //param2.BLGroupKanaName = "";
            //param2.BLGoodsCode = 0;
            //param2.BLGoodsHalfName = "";
            //param2.GoodsNo = "";
            //param2.GoodsNameKana = "";
            //param2.CustomerCode = 0;
            //param2.CustomerSnm = "";
            //param2.EmployeeCode = "";
            //param2.Name = "";

            //param2.SalesMoney1 = 0;
            //param2.SalesMoney2 = 0;
            //param2.SalesMoney3 = 0;
            //param2.SalesMoney4 = 0;
            //param2.SalesMoney5 = 0;
            //param2.SalesMoney6 = 0;
            //param2.SalesMoney7 = 0;
            //param2.SalesMoney8 = 0;
            //param2.SalesMoney9 = 0;
            //param2.SalesMoney10 = 0;
            //param2.SalesMoney11 = 0;
            //param2.SalesMoney12 = 0;

            //param2.TotalSalesCount1 = 0;
            //param2.TotalSalesCount2 = 0;
            //param2.TotalSalesCount3 = 0;
            //param2.TotalSalesCount4 = 0;
            //param2.TotalSalesCount5 = 0;
            //param2.TotalSalesCount6 = 0;
            //param2.TotalSalesCount7 = 0;
            //param2.TotalSalesCount8 = 0;
            //param2.TotalSalesCount9 = 0;
            //param2.TotalSalesCount10 = 0;
            //param2.TotalSalesCount11 = 0;
            //param2.TotalSalesCount12 = 0;

            //paramlist.Add(param2);

            retList = (object)paramlist;

            return 0;
        }
        #endregion
        #endregion ■ Private Method
    }
}

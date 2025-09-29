//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 売上順位表
// プログラム概要   : 売上順位表の印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30452 上野 俊治
// 作 成 日  2008/09/24  修正内容 : PM.NS対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30307 照田 貴志
// 修 正 日  2008/10/27  修正内容 : バグ修正、仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30452 上野 俊治
// 修 正 日  2008/12/09  修正内容 : 粗利金額によるソートと昇順、降順の修正(障害ID8867,8840,8866,8841)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30452 上野 俊治
// 修 正 日  2009/02/09  修正内容 : 障害対応11179(速度アップ対応)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/04/13  修正内容 : Mantis【8788】残案件No.19 端数処理
//----------------------------------------------------------------------------//
// 管理番号  10504551-00 作成担当 : 30517 夏野 駿希
// 修 正 日  2009/12/29  修正内容 : Mantis.14838：順位指定した場合でも全件抽出される
//                                  ランク外は印字されない様にフィルタをかける
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22008 長内 数馬
// 修 正 日  2010/05/13  修正内容 : 品名の取得方法を変更
//----------------------------------------------------------------------------//
// 管理番号  11070263-00 作成担当 : 劉超
// 修 正 日  2014/12/16  修正内容 : 明治産業　Seiken品番変更ＰＧ開発 帳票改良分対応
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using System.Text;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// 売上順位表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 売上順位表で使用するデータを取得する。</br>
    /// <br>Programmer	: 96186 立花 裕輔</br>
    /// <br>Date		: 2007.09.03</br>
    /// <br>Update Note : 2008.09.24 30452 上野 俊治</br>
    /// <br>            ・PM.NS対応</br>
    /// <br>            : 2008/10/27       照田 貴志</br>
    /// <br>            ・バグ修正、仕様変更対応</br>
    /// <br>            : 2008/12/9       上野 俊治</br>
    /// <br>            ・バグ修正、仕様変更対応</br>
    /// <br>            ・粗利金額によるソートと昇順、降順の修正(障害ID8867,8840,8866,8841)</br>
    /// <br>Update Note : 2009/02/09      上野 俊治</br>
    /// <br>            ・障害対応11179(速度アップ対応)</br>
    /// <br>Update Note : 2014/12/16 劉超</br>
    /// <br>管理番号    : 11070263-00</br>
    /// <br>            : 明治産業様Seiken品番変更</br>
    /// </remarks>
	public class ShipmGoodsOdrReportAcs
	{
		#region ■ Constructor
		/// <summary>
		/// 売上順位表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 売上順位表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 96186 立花 裕輔</br>
	    /// <br>Date       : 2007.09.03</br>
		/// </remarks>
		public ShipmGoodsOdrReportAcs()
		{
			this._iShipmGoodsOdrReportResultDB = (IShipmGoodsOdrReportResultDB)MediationShipmGoodsOdrReportResultDB.GetShipmGoodsOdrReportResultDB();
		}

		/// <summary>
		/// 売上順位表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 売上順位表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 96186 立花 裕輔</br>
	    /// <br>Date       : 2007.09.03</br>
		/// </remarks>
		static ShipmGoodsOdrReportAcs()
		{
			stc_Employee		= null;
			stc_PrtOutSet		= null;					// 帳票出力設定データクラス
			stc_PrtOutSetAcs	= new PrtOutSetAcs();	// 帳票出力設定アクセスクラス

			// ログイン拠点取得
		    Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
		    if (loginEmployee != null)
		    {
				stc_Employee = loginEmployee.Clone();
		    }
		}
		#endregion ■ Constructor

		#region ■ Static Member
		private static Employee stc_Employee;
		private static PrtOutSet stc_PrtOutSet;			// 帳票出力設定データクラス
		private static PrtOutSetAcs stc_PrtOutSetAcs;	// 帳票出力設定アクセスクラス
		#endregion ■ Static Member

		#region ■ Private Member
		IShipmGoodsOdrReportResultDB _iShipmGoodsOdrReportResultDB;

		private DataTable _shipmGoodsOdrReportDt;			// 印刷DataTable
		private DataView _shipmGoodsOdrReportView;	// 印刷DataView

		#endregion ■ Private Member

		#region ■ Public Property
		/// <summary>
		/// 印刷データセット(読み取り専用)
		/// </summary>
		public DataView ShipmGoodsOdrReportView
		{
			get{ return this._shipmGoodsOdrReportView; }
		}
		#endregion ■ Public Property

		#region ■ Public Method
		#region ◆ 出力データ取得
		#region ◎ 入金データ取得
		/// <summary>
		/// 入金データ取得
		/// </summary>
		/// <param name="shipmGoodsOdrReport">抽出条件</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する入金データを取得する。</br>
	    /// <br>Programmer : 96186 立花 裕輔</br>
	    /// <br>Date       : 2007.09.03</br>
		/// </remarks>
		public int SearchShipmGoodsOdrReportProcMain(ShipmGoodsOdrReport shipmGoodsOdrReport, out string errMsg)
		{
			return this.SearchShipmGoodsOdrReportProc(shipmGoodsOdrReport, out errMsg);
		}
		#endregion
		#endregion ◆ 出力データ取得
		#endregion ■ Public Method

		#region ■ Private Method
		#region ◆ 帳票データ取得
		#region ◎ データ取得
		/// <summary>
		/// データ取得
		/// </summary>
		/// <param name="shipmGoodsOdrReport"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する在庫移動データを取得する。</br>
	    /// <br>Programmer : 96186 立花 裕輔</br>
	    /// <br>Date       : 2007.09.03</br>
		/// </remarks>
		private int SearchShipmGoodsOdrReportProc(ShipmGoodsOdrReport shipmGoodsOdrReport, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

			try
			{
				// DataTable Create ----------------------------------------------------------
				DCHNB02054EA.CreateDataTable(ref this._shipmGoodsOdrReportDt);
				
				// 抽出条件展開  --------------------------------------------------------------
				ShipmGoodsOdrReportParamWork shipmGoodsOdrReportParamWork = new ShipmGoodsOdrReportParamWork();
				status = this.DevSalesDayMonthReport(shipmGoodsOdrReport, out shipmGoodsOdrReportParamWork, out errMsg);
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

				// データ取得  ----------------------------------------------------------------
				object shipmGoodsOdrReportResultWork = null;
				status = _iShipmGoodsOdrReportResultDB.Search(out shipmGoodsOdrReportResultWork, shipmGoodsOdrReportParamWork);

                //TODO テスト用
                //status = this.testProc(out shipmGoodsOdrReportResultWork, shipmGoodsOdrReportParamWork);

				switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						// データ展開処理
						DevStockMoveData( shipmGoodsOdrReport, (ArrayList)shipmGoodsOdrReportResultWork );
						status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
						break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
					default:
						errMsg = "売上履歴データの取得に失敗しました。";
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
		/// <param name="shipmGoodsOdrReport">UI抽出条件クラス</param>
		/// <param name="stockMoveListCndtnWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
        /// <remarks>
        /// <br>Update Note: 2014/12/16 劉超</br>
        /// <br>管理番号   : 11070263-00</br>
        /// <br>           :・明治産業様Seiken品番変更</br>
        /// </remarks>
		private int DevSalesDayMonthReport ( ShipmGoodsOdrReport shipmGoodsOdrReport, out ShipmGoodsOdrReportParamWork shipmGoodsOdrReportParamWork, out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;
			shipmGoodsOdrReportParamWork = new ShipmGoodsOdrReportParamWork();
			try
			{
				shipmGoodsOdrReportParamWork.EnterpriseCode = shipmGoodsOdrReport.EnterpriseCode; // 企業コード
				shipmGoodsOdrReportParamWork.SectionCodes = shipmGoodsOdrReport.SectionCodes; // 拠点コード
                shipmGoodsOdrReportParamWork.TotalType = shipmGoodsOdrReport.TotalType; // 集計単位
				shipmGoodsOdrReportParamWork.TtlType = shipmGoodsOdrReport.TtlType; // 集計方法
                //shipmGoodsOdrReportParamWork.RsltTtlDivCd = shipmGoodsOdrReport.RsltTtlDivCd;     // 在取区分 // ADD 2008/09/24   → DEL 2008/10/27 項目違い(RsltTtlDivCdに値はセットされていない)
                shipmGoodsOdrReportParamWork.RsltTtlDivCd = shipmGoodsOdrReport.SalesOrderDivCd;    // 在取区分 // ADD 2008/10/27
                shipmGoodsOdrReportParamWork.Detail = shipmGoodsOdrReport.Detail; // 明細単位 // ADD 2008/09/24
                //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
                shipmGoodsOdrReportParamWork.GoodsNoTtlDiv = shipmGoodsOdrReport.GoodsNoTtlDiv; // 品番集計区分
                if (shipmGoodsOdrReportParamWork.GoodsNoTtlDiv == 1)
                {
                    shipmGoodsOdrReportParamWork.GoodsNoShowDiv = shipmGoodsOdrReport.GoodsNoShowDiv; // 品番表示区分
                }
                //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<
                shipmGoodsOdrReportParamWork.Order = shipmGoodsOdrReport.SortItem; // 順位設定
				shipmGoodsOdrReportParamWork.SalesDateSt = shipmGoodsOdrReport.SalesDateSt; // 開始対象年月
				shipmGoodsOdrReportParamWork.SalesDateEd = shipmGoodsOdrReport.SalesDateEd; // 終了対象年月
                /* --- DEL 2008/10/27 終了コードを変換する必要がある為 --------------------------------------------------------------->>>>>
                shipmGoodsOdrReportParamWork.PrintRangeSt = shipmGoodsOdrReport.PrintRangeSt; // 開始印刷範囲指定
                shipmGoodsOdrReportParamWork.PrintRangeEd = shipmGoodsOdrReport.PrintRangeEd; // 終了印刷範囲指定
                shipmGoodsOdrReportParamWork.SupplierCdSt = shipmGoodsOdrReport.SupplierCdSt; // 開始仕入先コード // ADD 2008/09/24
                shipmGoodsOdrReportParamWork.SupplierCdEd = shipmGoodsOdrReport.SupplierCdEd; // 終了仕入先コード // ADD 2008/09/24
                shipmGoodsOdrReportParamWork.CustomerCodeSt = shipmGoodsOdrReport.CustomerCodeSt; // 開始得意先コード
                shipmGoodsOdrReportParamWork.CustomerCodeEd = shipmGoodsOdrReport.CustomerCodeEd; // 終了得意先コード
                shipmGoodsOdrReportParamWork.EmployeeCodeSt = shipmGoodsOdrReport.EmployeeCodeSt; // 開始従業員コード // ADD 2008/09/24
                shipmGoodsOdrReportParamWork.EmployeeCodeEd = shipmGoodsOdrReport.EmployeeCodeEd; // 終了従業員コード // ADD 2008/09/24
				shipmGoodsOdrReportParamWork.GoodsMakerCdSt = shipmGoodsOdrReport.GoodsMakerCdSt; // 開始メーカーコード
				shipmGoodsOdrReportParamWork.GoodsMakerCdEd = shipmGoodsOdrReport.GoodsMakerCdEd; // 終了メーカーコード
                shipmGoodsOdrReportParamWork.GoodsLGroupSt = shipmGoodsOdrReport.GoodsLGroupSt; // 開始商品大分類コード // ADD 2008/09/24
                shipmGoodsOdrReportParamWork.GoodsLGroupEd = shipmGoodsOdrReport.GoodsLGroupEd; // 終了商品大分類コード // ADD 2008/09/24
                shipmGoodsOdrReportParamWork.GoodsMGroupSt = shipmGoodsOdrReport.GoodsMGroupSt; // 開始商品中分類コード // ADD 2008/09/24
                shipmGoodsOdrReportParamWork.GoodsMGroupEd = shipmGoodsOdrReport.GoodsMGroupEd; // 終了商品中分類コード // ADD 2008/09/24
                shipmGoodsOdrReportParamWork.BLGroupCodeSt = shipmGoodsOdrReport.BLGroupCodeSt; // 開始BLグループコード
                shipmGoodsOdrReportParamWork.BLGroupCodeEd = shipmGoodsOdrReport.BLGroupCodeEd; // 終了BLグループコード
                shipmGoodsOdrReportParamWork.BLGroupCodeAry = shipmGoodsOdrReport.BLGroupCodeAry; // 単体BLグループコード
                shipmGoodsOdrReportParamWork.BLGoodsCodeSt = shipmGoodsOdrReport.BLGoodsCodeSt; // 開始BL商品コード // ADD 2008/09/24
                shipmGoodsOdrReportParamWork.BLGoodsCodeEd = shipmGoodsOdrReport.BLGoodsCodeEd; // 終了BL商品コード // ADD 2008/09/24
                shipmGoodsOdrReportParamWork.GoodsNoSt = shipmGoodsOdrReport.GoodsNoSt; // 開始商品番号
                shipmGoodsOdrReportParamWork.GoodsNoEd = shipmGoodsOdrReport.GoodsNoEd; // 終了商品番号
                   --- DEL 2008/10/27 終了コードを変換する必要がある為 ---------------------------------------------------------------<<<<< */
                // --- ADD 2008/10/27 ------------------------------------------------------------------------------------------------>>>>>
                shipmGoodsOdrReportParamWork.PrintRangeSt = shipmGoodsOdrReport.PrintRangeSt;                           // 開始印刷範囲指定
                //shipmGoodsOdrReportParamWork.PrintRangeEd = this.GetEndCode(shipmGoodsOdrReport.PrintRangeEd, 9);     // 終了印刷範囲指定 // DEL 2009/02/10
                shipmGoodsOdrReportParamWork.PrintRangeEd = shipmGoodsOdrReport.PrintRangeEd;                           // 終了印刷範囲指定 // ADD 2009/02/10
                shipmGoodsOdrReportParamWork.SupplierCdSt = shipmGoodsOdrReport.SupplierCdSt;                           // 開始仕入先コード
                shipmGoodsOdrReportParamWork.SupplierCdEd = this.GetEndCode(shipmGoodsOdrReport.SupplierCdEd, 6);       // 終了仕入先コード
                shipmGoodsOdrReportParamWork.CustomerCodeSt = shipmGoodsOdrReport.CustomerCodeSt;                       // 開始得意先コード
                shipmGoodsOdrReportParamWork.CustomerCodeEd = this.GetEndCode(shipmGoodsOdrReport.CustomerCodeEd, 8);   // 終了得意先コード
                shipmGoodsOdrReportParamWork.EmployeeCodeSt = shipmGoodsOdrReport.EmployeeCodeSt;                       // 開始従業員コード
                shipmGoodsOdrReportParamWork.EmployeeCodeEd = this.GetEndCode(shipmGoodsOdrReport.EmployeeCodeEd, 4);   // 終了従業員コード
                shipmGoodsOdrReportParamWork.GoodsMakerCdSt = shipmGoodsOdrReport.GoodsMakerCdSt;                       // 開始メーカーコード
                shipmGoodsOdrReportParamWork.GoodsMakerCdEd = this.GetEndCode(shipmGoodsOdrReport.GoodsMakerCdEd, 4);   // 終了メーカーコード
                shipmGoodsOdrReportParamWork.GoodsLGroupSt = shipmGoodsOdrReport.GoodsLGroupSt;                         // 開始商品大分類コード
                shipmGoodsOdrReportParamWork.GoodsLGroupEd = this.GetEndCode(shipmGoodsOdrReport.GoodsLGroupEd, 4);     // 終了商品大分類コード
                shipmGoodsOdrReportParamWork.GoodsMGroupSt = shipmGoodsOdrReport.GoodsMGroupSt;                         // 開始商品中分類コード
                shipmGoodsOdrReportParamWork.GoodsMGroupEd = this.GetEndCode(shipmGoodsOdrReport.GoodsMGroupEd, 4);     // 終了商品中分類コード
                shipmGoodsOdrReportParamWork.BLGroupCodeSt = shipmGoodsOdrReport.BLGroupCodeSt;                         // 開始BLグループコード
                shipmGoodsOdrReportParamWork.BLGroupCodeEd = this.GetEndCode(shipmGoodsOdrReport.BLGroupCodeEd, 5);     // 終了BLグループコード
                shipmGoodsOdrReportParamWork.BLGroupCodeAry = shipmGoodsOdrReport.BLGroupCodeAry;                       // 単体BLグループコード
                shipmGoodsOdrReportParamWork.BLGoodsCodeSt = shipmGoodsOdrReport.BLGoodsCodeSt;                         // 開始BL商品コード
                shipmGoodsOdrReportParamWork.BLGoodsCodeEd = this.GetEndCode(shipmGoodsOdrReport.BLGoodsCodeEd, 5);     // 終了BL商品コード
                shipmGoodsOdrReportParamWork.GoodsNoSt = shipmGoodsOdrReport.GoodsNoSt;                                 // 開始商品番号
                shipmGoodsOdrReportParamWork.GoodsNoEd = shipmGoodsOdrReport.GoodsNoEd;                                 // 終了商品番号
                // --- ADD 2008/10/27 ------------------------------------------------------------------------------------------------<<<<<
                // --- DEL 2008/09/24 -------------------------------->>>>>
                //shipmGoodsOdrReportParamWork.LargeGoodsGanreCodeSt = shipmGoodsOdrReport.LargeGoodsGanreCodeSt;
                //shipmGoodsOdrReportParamWork.LargeGoodsGanreCodeEd = shipmGoodsOdrReport.LargeGoodsGanreCodeEd;
                //shipmGoodsOdrReportParamWork.MediumGoodsGanreCodeSt = shipmGoodsOdrReport.MediumGoodsGanreCodeSt;
                //shipmGoodsOdrReportParamWork.MediumGoodsGanreCodeEd = shipmGoodsOdrReport.MediumGoodsGanreCodeEd;
                //shipmGoodsOdrReportParamWork.DetailGoodsGanreCodeSt = shipmGoodsOdrReport.DetailGoodsGanreCodeSt;
                //shipmGoodsOdrReportParamWork.DetailGoodsGanreCodeEd = shipmGoodsOdrReport.DetailGoodsGanreCodeEd;
                // --- DEL 2008/09/24 --------------------------------<<<<<
                // --- DEL 2008/09/24 -------------------------------->>>>>
                //shipmGoodsOdrReportParamWork.SalesEmployeeCdSt = shipmGoodsOdrReport.SalesEmployeeCdSt;
                //shipmGoodsOdrReportParamWork.SalesEmployeeCdEd = shipmGoodsOdrReport.SalesEmployeeCdEd;
                // --- DEL 2008/09/24 --------------------------------<<<<<    
                // --- DEL 2008/09/24 -------------------------------->>>>>
                //shipmGoodsOdrReportParamWork.SalesOrderDivCd = shipmGoodsOdrReport.SalesOrderDivCd;
                //shipmGoodsOdrReportParamWork.Order1 = shipmGoodsOdrReport.Order1;
                //shipmGoodsOdrReportParamWork.Order2 = shipmGoodsOdrReport.Order2;
                //shipmGoodsOdrReportParamWork.Order3 = shipmGoodsOdrReport.Order3;
                // --- DEL 2008/09/24 --------------------------------<<<<<
                // --- DEL 2008/09/24 -------------------------------->>>>>
				//shipmGoodsOdrReportParamWork.SortItem = shipmGoodsOdrReport.SortItem;
                // --- DEL 2008/09/24 --------------------------------<<<<<
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
		/// <param name="shipmGoodsOdrReport">UI抽出条件クラス</param>
		/// <param name="stockMoveWork">取得データ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 取得データを展開する。</br>
	    /// <br>Programmer : 96186 立花 裕輔</br>
	    /// <br>Date       : 2007.09.03</br>
		/// ---------------------------------------------------------------------------------------------
		/// <br>UpDateNote : 円単位→千円単位の計算を、「÷1000」ではなく「÷1000して小数点を四捨五入」に変更</br>
		/// <br>Programmer : 30191 馬淵 愛</br>
		/// <br>Date       : 2008.04.07</br>
		/// </remarks>
        private void DevStockMoveData(ShipmGoodsOdrReport shipmGoodsOdrReport, ArrayList list)
        {
            DataRow dr;

            int month = GetMonthRange(shipmGoodsOdrReport.SalesDateSt, shipmGoodsOdrReport.SalesDateEd);

            //08.04.07 Mabuchi Delete & Add START---------------------
            //int moneyUnit;
            //if (shipmGoodsOdrReport.MoneyUnit == 1)
            //{
            //    moneyUnit = 1000;
            //}
            //else
            //{
            //    moneyUnit = 1;
            //}
            // --- DEL 2008/09/24 -------------------------------->>>>>
            //decimal TotalProceeds1; decimal TotalProceeds2; decimal TotalProceeds3; decimal TotalProceeds4; decimal TotalProceeds5; decimal TotalProceeds6;
            //decimal TotalProceeds7; decimal TotalProceeds8; decimal TotalProceeds9; decimal TotalProceeds10; decimal TotalProceeds11; decimal TotalProceeds12;
            //decimal dbl_totalProceedsTotal; decimal dbl_TotalProceedsAve;
            // --- DEL 2008/09/24 --------------------------------<<<<<
            // --- ADD 2008/09/24 -------------------------------->>>>>
            decimal SalesMoney1; decimal SalesMoney2; decimal SalesMoney3; decimal SalesMoney4; decimal SalesMoney5; decimal SalesMoney6;
            decimal SalesMoney7; decimal SalesMoney8; decimal SalesMoney9; decimal SalesMoney10; decimal SalesMoney11; decimal SalesMoney12;
            decimal TotalSalesMoney; decimal GrossProfit;
            // 構成比算出用合計値保持項目
            double totalSalesMoneySum = 0;
            Dictionary<string, double> totalSalesMoneyDic = new Dictionary<string, double>();
            double grossProfitSum = 0;
            Dictionary<string, double> grossProfitDic = new Dictionary<string, double>();
            // --- ADD 2008/09/24 --------------------------------<<<<<
            //08.04.07 Mabuchi Delete & Add END---------------------

            //Int32 order = 0;

            foreach (ShipmGoodsOdrReportResultWork shipmGoodsOdrReportResultWork in list)
            {
                dr = this._shipmGoodsOdrReportDt.NewRow();
                // 取得データ展開
                #region 取得データ展開
                dr[DCHNB02054EA.ct_Col_AddUpSecCode] = shipmGoodsOdrReportResultWork.AddUpSecCode; // 拠点コード
                dr[DCHNB02054EA.ct_Col_SectionGuideNm] = shipmGoodsOdrReportResultWork.CompanyName1; // 拠点名称
                dr[DCHNB02054EA.ct_Col_SupplierCd] = shipmGoodsOdrReportResultWork.SupplierCd; // 仕入先コード // ADD 2008/09/24
                dr[DCHNB02054EA.ct_Col_SupplierNm] = shipmGoodsOdrReportResultWork.SupplierSnm; // 仕入先名称
                dr[DCHNB02054EA.ct_Col_CustomerCode] = shipmGoodsOdrReportResultWork.CustomerCode; // 得意先コード
                dr[DCHNB02054EA.ct_Col_CustomerSnm] = shipmGoodsOdrReportResultWork.CustomerSnm; // 得意先名称
                dr[DCHNB02054EA.ct_Col_EmployeeCode] = shipmGoodsOdrReportResultWork.EmployeeCode; // 従業員コード
                dr[DCHNB02054EA.ct_Col_EmployeeName] = shipmGoodsOdrReportResultWork.Name; // 従業員名称
                dr[DCHNB02054EA.ct_Col_GoodsNo] = shipmGoodsOdrReportResultWork.GoodsNo; // 商品番号
                //dr[DCHNB02054EA.ct_Col_GoodsName] = shipmGoodsOdrReportResultWork.GoodsName; // 商品名称 // ADD 2008/09/24 // DEL 2009/02/09
                dr[DCHNB02054EA.ct_Col_BLGoodsCode] = shipmGoodsOdrReportResultWork.BLGoodsCode; // BL商品コード
                dr[DCHNB02054EA.ct_Col_BLGoodsHalfName] = shipmGoodsOdrReportResultWork.BLGoodsHalfName; // BL商品コード名称
                dr[DCHNB02054EA.ct_Col_GoodsLGroup] = shipmGoodsOdrReportResultWork.GoodsLGroup; // 商品大分類コード // ADD 2008/09/24
                dr[DCHNB02054EA.ct_Col_GoodsLGroupName] = shipmGoodsOdrReportResultWork.GoodsLGroupName; // 商品大分類コード // ADD 2008/09/24
                dr[DCHNB02054EA.ct_Col_GoodsMGroup] = shipmGoodsOdrReportResultWork.GoodsMGroup; // 商品大分類コード // ADD 2008/09/24
                dr[DCHNB02054EA.ct_Col_GoodsMGroupName] = shipmGoodsOdrReportResultWork.GoodsMGroupName; // 商品大分類コード // ADD 2008/09/24
                dr[DCHNB02054EA.ct_Col_BLGroupCode] = shipmGoodsOdrReportResultWork.BLGroupCode; // BLグループコード // ADD 2008/09/24
                dr[DCHNB02054EA.ct_Col_BLGroupKanaName] = shipmGoodsOdrReportResultWork.BLGroupKanaName; // BLグループコード名称 // ADD 2008/09/24
                dr[DCHNB02054EA.ct_Col_GoodsMakerCd] = shipmGoodsOdrReportResultWork.GoodsMakerCd; // 商品メーカーコード
                dr[DCHNB02054EA.ct_Col_MakerShortName] = shipmGoodsOdrReportResultWork.MakerShortName; // 商品メーカー略称 // ADD 2008/09/24
                dr[DCHNB02054EA.ct_Col_TotalSalesCount] = shipmGoodsOdrReportResultWork.TotalSalesCount; // 売上数計 // ADD 2008/09/24

                // --- ADD 2009/02/09 -------------------------------->>>>>
                if (!string.IsNullOrEmpty(shipmGoodsOdrReportResultWork.GoodsNo))  // ADD 2010/05/13 品番が設定されていない場合は取得しない。
                {  // ADD 2010/05/13
                    // 品名取得
                    if (!string.IsNullOrEmpty(shipmGoodsOdrReportResultWork.GoodsName))
                    {
                        dr[DCHNB02054EA.ct_Col_GoodsName] = shipmGoodsOdrReportResultWork.GoodsName; // 商品名称
                    }
                    else
                    {
                        string goodsName = string.Empty;

                        // -- UPD 2010/05/13 -------------------------------------------------------->>>
                        //int status = GoodsAcs.GetGoodsNameKana(shipmGoodsOdrReportResultWork.GoodsMakerCd, shipmGoodsOdrReportResultWork.GoodsNo, out goodsName);
                        int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        if (shipmGoodsOdrReportResultWork.GoodsMakerCd != 0)
                        {
                            status = GoodsAcs.GetGoodsNameKana(shipmGoodsOdrReportResultWork.GoodsMakerCd, shipmGoodsOdrReportResultWork.GoodsNo, out goodsName);
                        }
                        // -- UPD 2010/05/13 --------------------------------------------------------<<<

                        if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            if (!string.IsNullOrEmpty(goodsName))
                            {
                                dr[DCHNB02054EA.ct_Col_GoodsName] = goodsName;
                            }
                            else
                            {
                                dr[DCHNB02054EA.ct_Col_GoodsName] = shipmGoodsOdrReportResultWork.BLGoodsHalfName;
                            }
                        }
                        else
                        {
                            dr[DCHNB02054EA.ct_Col_GoodsName] = shipmGoodsOdrReportResultWork.BLGoodsHalfName;
                        }
                    }
                }  // ADD 2010/05/13
                // --- ADD 2009/02/09 --------------------------------<<<<<

                // --- ADD 2008/09/24 -------------------------------->>>>>
                // DEL 2009/04/13 ------>>>
                //if (shipmGoodsOdrReport.MoneyUnit == 1)
                //{
                //    TotalSalesMoney = shipmGoodsOdrReportResultWork.TotalSalesMoney / 1000m;
                //    dr[DCHNB02054EA.ct_Col_TotalSalesMoney] = Math.Round(TotalSalesMoney, 0, MidpointRounding.AwayFromZero); // 純売上
                //}
                //else
                //{
                //    dr[DCHNB02054EA.ct_Col_TotalSalesMoney] = shipmGoodsOdrReportResultWork.TotalSalesMoney; // 純売上
                //}
                // DEL 2009/04/13 ------<<<
                // 純売上
                dr[DCHNB02054EA.ct_Col_TotalSalesMoney] = shipmGoodsOdrReportResultWork.TotalSalesMoney;    // ADD 2009/04/13

                // 率計算用の純売上
                dr[DCHNB02054EA.ct_Col_TotalSalesMoneyOrg] = shipmGoodsOdrReportResultWork.TotalSalesMoney;

                // DEL 2009/04/13 ------>>>
                //if (shipmGoodsOdrReport.MoneyUnit == 1)
                //{
                //    GrossProfit = shipmGoodsOdrReportResultWork.GrossProfit / 1000m;
                //    dr[DCHNB02054EA.ct_Col_GrossProfit] = Math.Round(GrossProfit, 0, MidpointRounding.AwayFromZero); // 粗利金額
                //}
                //else
                //{
                //    dr[DCHNB02054EA.ct_Col_GrossProfit] = shipmGoodsOdrReportResultWork.GrossProfit; // 粗利金額
                //}
                // DEL 2009/04/13 ------<<<
                // 粗利金額
                dr[DCHNB02054EA.ct_Col_GrossProfit] = shipmGoodsOdrReportResultWork.GrossProfit;    // ADD 2009/04/13
                
                // 率計算用の粗利
                dr[DCHNB02054EA.ct_Col_GrossProfitOrg] = shipmGoodsOdrReportResultWork.GrossProfit;
                // --- ADD 2008/09/24 --------------------------------<<<<<

                dr[DCHNB02054EA.ct_Col_TotalSalesCount1] = shipmGoodsOdrReportResultWork.TotalSalesCount1; // 売上数計
                dr[DCHNB02054EA.ct_Col_TotalSalesCount2] = shipmGoodsOdrReportResultWork.TotalSalesCount2;
                dr[DCHNB02054EA.ct_Col_TotalSalesCount3] = shipmGoodsOdrReportResultWork.TotalSalesCount3;
                dr[DCHNB02054EA.ct_Col_TotalSalesCount4] = shipmGoodsOdrReportResultWork.TotalSalesCount4;
                dr[DCHNB02054EA.ct_Col_TotalSalesCount5] = shipmGoodsOdrReportResultWork.TotalSalesCount5;
                dr[DCHNB02054EA.ct_Col_TotalSalesCount6] = shipmGoodsOdrReportResultWork.TotalSalesCount6;
                dr[DCHNB02054EA.ct_Col_TotalSalesCount7] = shipmGoodsOdrReportResultWork.TotalSalesCount7;
                dr[DCHNB02054EA.ct_Col_TotalSalesCount8] = shipmGoodsOdrReportResultWork.TotalSalesCount8;
                dr[DCHNB02054EA.ct_Col_TotalSalesCount9] = shipmGoodsOdrReportResultWork.TotalSalesCount9;
                dr[DCHNB02054EA.ct_Col_TotalSalesCount10] = shipmGoodsOdrReportResultWork.TotalSalesCount10;
                dr[DCHNB02054EA.ct_Col_TotalSalesCount11] = shipmGoodsOdrReportResultWork.TotalSalesCount11;
                dr[DCHNB02054EA.ct_Col_TotalSalesCount12] = shipmGoodsOdrReportResultWork.TotalSalesCount12;

                dr[DCHNB02054EA.ct_Col_SalesTimes1] = shipmGoodsOdrReportResultWork.SalesTimes1; // 売上回数
                dr[DCHNB02054EA.ct_Col_SalesTimes2] = shipmGoodsOdrReportResultWork.SalesTimes2;
                dr[DCHNB02054EA.ct_Col_SalesTimes3] = shipmGoodsOdrReportResultWork.SalesTimes3;
                dr[DCHNB02054EA.ct_Col_SalesTimes4] = shipmGoodsOdrReportResultWork.SalesTimes4;
                dr[DCHNB02054EA.ct_Col_SalesTimes5] = shipmGoodsOdrReportResultWork.SalesTimes5;
                dr[DCHNB02054EA.ct_Col_SalesTimes6] = shipmGoodsOdrReportResultWork.SalesTimes6;
                dr[DCHNB02054EA.ct_Col_SalesTimes7] = shipmGoodsOdrReportResultWork.SalesTimes7;
                dr[DCHNB02054EA.ct_Col_SalesTimes8] = shipmGoodsOdrReportResultWork.SalesTimes8;
                dr[DCHNB02054EA.ct_Col_SalesTimes9] = shipmGoodsOdrReportResultWork.SalesTimes9;
                dr[DCHNB02054EA.ct_Col_SalesTimes10] = shipmGoodsOdrReportResultWork.SalesTimes10;
                dr[DCHNB02054EA.ct_Col_SalesTimes11] = shipmGoodsOdrReportResultWork.SalesTimes11;
                dr[DCHNB02054EA.ct_Col_SalesTimes12] = shipmGoodsOdrReportResultWork.SalesTimes12;

                // --- ADD 2008/09/24 -------------------------------->>>>>
                // DEL 2009/04/13 ------>>>
                //if (shipmGoodsOdrReport.MoneyUnit == 1)
                //{
                //    SalesMoney1 = Convert.ToDecimal(shipmGoodsOdrReportResultWork.SalesMoney1) / 1000m;
                //    SalesMoney2 = Convert.ToDecimal(shipmGoodsOdrReportResultWork.SalesMoney2) / 1000m;
                //    SalesMoney3 = Convert.ToDecimal(shipmGoodsOdrReportResultWork.SalesMoney3) / 1000m;
                //    SalesMoney4 = Convert.ToDecimal(shipmGoodsOdrReportResultWork.SalesMoney4) / 1000m;
                //    SalesMoney5 = Convert.ToDecimal(shipmGoodsOdrReportResultWork.SalesMoney5) / 1000m;
                //    SalesMoney6 = Convert.ToDecimal(shipmGoodsOdrReportResultWork.SalesMoney6) / 1000m;
                //    SalesMoney7 = Convert.ToDecimal(shipmGoodsOdrReportResultWork.SalesMoney7) / 1000m;
                //    SalesMoney8 = Convert.ToDecimal(shipmGoodsOdrReportResultWork.SalesMoney8) / 1000m;
                //    SalesMoney9 = Convert.ToDecimal(shipmGoodsOdrReportResultWork.SalesMoney9) / 1000m;
                //    SalesMoney10 = Convert.ToDecimal(shipmGoodsOdrReportResultWork.SalesMoney10) / 1000m;
                //    SalesMoney11 = Convert.ToDecimal(shipmGoodsOdrReportResultWork.SalesMoney11) / 1000m;
                //    SalesMoney12 = Convert.ToDecimal(shipmGoodsOdrReportResultWork.SalesMoney12) / 1000m;

                //    dr[DCHNB02054EA.ct_Col_SalesMoney1] = Math.Round(SalesMoney1, 0, MidpointRounding.AwayFromZero); // 売上金額 (千円単位)
                //    dr[DCHNB02054EA.ct_Col_SalesMoney2] = Math.Round(SalesMoney2, 0, MidpointRounding.AwayFromZero);
                //    dr[DCHNB02054EA.ct_Col_SalesMoney3] = Math.Round(SalesMoney3, 0, MidpointRounding.AwayFromZero);
                //    dr[DCHNB02054EA.ct_Col_SalesMoney4] = Math.Round(SalesMoney4, 0, MidpointRounding.AwayFromZero);
                //    dr[DCHNB02054EA.ct_Col_SalesMoney5] = Math.Round(SalesMoney5, 0, MidpointRounding.AwayFromZero);
                //    dr[DCHNB02054EA.ct_Col_SalesMoney6] = Math.Round(SalesMoney6, 0, MidpointRounding.AwayFromZero);
                //    dr[DCHNB02054EA.ct_Col_SalesMoney7] = Math.Round(SalesMoney7, 0, MidpointRounding.AwayFromZero);
                //    dr[DCHNB02054EA.ct_Col_SalesMoney8] = Math.Round(SalesMoney8, 0, MidpointRounding.AwayFromZero);
                //    dr[DCHNB02054EA.ct_Col_SalesMoney9] = Math.Round(SalesMoney9, 0, MidpointRounding.AwayFromZero);
                //    dr[DCHNB02054EA.ct_Col_SalesMoney10] = Math.Round(SalesMoney10, 0, MidpointRounding.AwayFromZero);
                //    dr[DCHNB02054EA.ct_Col_SalesMoney11] = Math.Round(SalesMoney11, 0, MidpointRounding.AwayFromZero);
                //    dr[DCHNB02054EA.ct_Col_SalesMoney12] = Math.Round(SalesMoney12, 0, MidpointRounding.AwayFromZero);
                //}
                //else
                //{
                //    dr[DCHNB02054EA.ct_Col_SalesMoney1] = shipmGoodsOdrReportResultWork.SalesMoney1; // 売上金額 (円単位)
                //    dr[DCHNB02054EA.ct_Col_SalesMoney2] = shipmGoodsOdrReportResultWork.SalesMoney2;
                //    dr[DCHNB02054EA.ct_Col_SalesMoney3] = shipmGoodsOdrReportResultWork.SalesMoney3;
                //    dr[DCHNB02054EA.ct_Col_SalesMoney4] = shipmGoodsOdrReportResultWork.SalesMoney4;
                //    dr[DCHNB02054EA.ct_Col_SalesMoney5] = shipmGoodsOdrReportResultWork.SalesMoney5;
                //    dr[DCHNB02054EA.ct_Col_SalesMoney6] = shipmGoodsOdrReportResultWork.SalesMoney6;
                //    dr[DCHNB02054EA.ct_Col_SalesMoney7] = shipmGoodsOdrReportResultWork.SalesMoney7;
                //    dr[DCHNB02054EA.ct_Col_SalesMoney8] = shipmGoodsOdrReportResultWork.SalesMoney8;
                //    dr[DCHNB02054EA.ct_Col_SalesMoney9] = shipmGoodsOdrReportResultWork.SalesMoney9;
                //    dr[DCHNB02054EA.ct_Col_SalesMoney10] = shipmGoodsOdrReportResultWork.SalesMoney10;
                //    dr[DCHNB02054EA.ct_Col_SalesMoney11] = shipmGoodsOdrReportResultWork.SalesMoney11;
                //    dr[DCHNB02054EA.ct_Col_SalesMoney12] = shipmGoodsOdrReportResultWork.SalesMoney12;
                //}
                // DEL 2009/04/13 ------<<<
                // ADD 2009/04/13 ------>>>
                dr[DCHNB02054EA.ct_Col_SalesMoney1] = shipmGoodsOdrReportResultWork.SalesMoney1; // 売上金額 (円単位)
                dr[DCHNB02054EA.ct_Col_SalesMoney2] = shipmGoodsOdrReportResultWork.SalesMoney2;
                dr[DCHNB02054EA.ct_Col_SalesMoney3] = shipmGoodsOdrReportResultWork.SalesMoney3;
                dr[DCHNB02054EA.ct_Col_SalesMoney4] = shipmGoodsOdrReportResultWork.SalesMoney4;
                dr[DCHNB02054EA.ct_Col_SalesMoney5] = shipmGoodsOdrReportResultWork.SalesMoney5;
                dr[DCHNB02054EA.ct_Col_SalesMoney6] = shipmGoodsOdrReportResultWork.SalesMoney6;
                dr[DCHNB02054EA.ct_Col_SalesMoney7] = shipmGoodsOdrReportResultWork.SalesMoney7;
                dr[DCHNB02054EA.ct_Col_SalesMoney8] = shipmGoodsOdrReportResultWork.SalesMoney8;
                dr[DCHNB02054EA.ct_Col_SalesMoney9] = shipmGoodsOdrReportResultWork.SalesMoney9;
                dr[DCHNB02054EA.ct_Col_SalesMoney10] = shipmGoodsOdrReportResultWork.SalesMoney10;
                dr[DCHNB02054EA.ct_Col_SalesMoney11] = shipmGoodsOdrReportResultWork.SalesMoney11;
                dr[DCHNB02054EA.ct_Col_SalesMoney12] = shipmGoodsOdrReportResultWork.SalesMoney12;
                // ADD 2009/04/13 ------<<<
                
                // 合計
                dr[DCHNB02054EA.ct_Col_TotalSalesCountSum] = shipmGoodsOdrReportResultWork.TotalSalesCount1
                                                            + shipmGoodsOdrReportResultWork.TotalSalesCount2
                                                            + shipmGoodsOdrReportResultWork.TotalSalesCount3
                                                            + shipmGoodsOdrReportResultWork.TotalSalesCount4
                                                            + shipmGoodsOdrReportResultWork.TotalSalesCount5
                                                            + shipmGoodsOdrReportResultWork.TotalSalesCount6
                                                            + shipmGoodsOdrReportResultWork.TotalSalesCount7
                                                            + shipmGoodsOdrReportResultWork.TotalSalesCount8
                                                            + shipmGoodsOdrReportResultWork.TotalSalesCount9
                                                            + shipmGoodsOdrReportResultWork.TotalSalesCount10
                                                            + shipmGoodsOdrReportResultWork.TotalSalesCount11
                                                            + shipmGoodsOdrReportResultWork.TotalSalesCount12;

                dr[DCHNB02054EA.ct_Col_SalesTimesSum] = shipmGoodsOdrReportResultWork.SalesTimes1
                                                            + shipmGoodsOdrReportResultWork.SalesTimes2
                                                            + shipmGoodsOdrReportResultWork.SalesTimes3
                                                            + shipmGoodsOdrReportResultWork.SalesTimes4
                                                            + shipmGoodsOdrReportResultWork.SalesTimes5
                                                            + shipmGoodsOdrReportResultWork.SalesTimes6
                                                            + shipmGoodsOdrReportResultWork.SalesTimes7
                                                            + shipmGoodsOdrReportResultWork.SalesTimes8
                                                            + shipmGoodsOdrReportResultWork.SalesTimes9
                                                            + shipmGoodsOdrReportResultWork.SalesTimes10
                                                            + shipmGoodsOdrReportResultWork.SalesTimes11
                                                            + shipmGoodsOdrReportResultWork.SalesTimes12;

                long tmpSalesMoneySum = shipmGoodsOdrReportResultWork.SalesMoney1
                                                            + shipmGoodsOdrReportResultWork.SalesMoney2
                                                            + shipmGoodsOdrReportResultWork.SalesMoney3
                                                            + shipmGoodsOdrReportResultWork.SalesMoney4
                                                            + shipmGoodsOdrReportResultWork.SalesMoney5
                                                            + shipmGoodsOdrReportResultWork.SalesMoney6
                                                            + shipmGoodsOdrReportResultWork.SalesMoney7
                                                            + shipmGoodsOdrReportResultWork.SalesMoney8
                                                            + shipmGoodsOdrReportResultWork.SalesMoney9
                                                            + shipmGoodsOdrReportResultWork.SalesMoney10
                                                            + shipmGoodsOdrReportResultWork.SalesMoney11
                                                            + shipmGoodsOdrReportResultWork.SalesMoney12;

                // DEL 2009/04/13 ------>>>
                //if (shipmGoodsOdrReport.MoneyUnit == 1)
                //{
                //    decimal tmpSalesMoneySum2 = Convert.ToDecimal(tmpSalesMoneySum) / 1000m;
                //    dr[DCHNB02054EA.ct_Col_SalesMoneySum] = Math.Round(tmpSalesMoneySum2, 0, MidpointRounding.AwayFromZero);
                //}
                //else
                //{
                //    dr[DCHNB02054EA.ct_Col_SalesMoneySum] = tmpSalesMoneySum;
                //}
                // DEL 2009/04/13 ------<<<
                // 合計金額
                dr[DCHNB02054EA.ct_Col_SalesMoneySum] = tmpSalesMoneySum;   // ADD 2009/04/13
                
                dr[DCHNB02054EA.ct_Col_SalesMoneySumOrg] = tmpSalesMoneySum;

                // 平均
                // 売上数計平均
                dr[DCHNB02054EA.ct_Col_TotalSalesCountAve] = Convert.ToDouble(dr[DCHNB02054EA.ct_Col_TotalSalesCountSum]) / month;

                // 売上回数平均
                dr[DCHNB02054EA.ct_Col_SalesTimesAve] = Convert.ToDouble(dr[DCHNB02054EA.ct_Col_SalesTimesSum]) / month;

                // 売上金額平均
                dr[DCHNB02054EA.ct_Col_SalesMoneyAve] = Convert.ToDouble(dr[DCHNB02054EA.ct_Col_SalesMoneySum]) / month;

                // 粗利率
                //dr[DCHNB02054EA.ct_Col_ProfitRatio] = this.GetRatio(Convert.ToDouble(dr[DCHNB02054EA.ct_Col_GrossProfit]),
                //    Convert.ToDouble(dr[DCHNB02054EA.ct_Col_TotalSalesMoney]));
                dr[DCHNB02054EA.ct_Col_ProfitRatio] = this.GetRatio(Convert.ToDouble(dr[DCHNB02054EA.ct_Col_GrossProfitOrg]),
                    Convert.ToDouble(dr[DCHNB02054EA.ct_Col_TotalSalesMoneyOrg]));

                // 構成比算出用合計値
                //totalSalesMoneySum += Convert.ToDouble(dr[DCHNB02054EA.ct_Col_TotalSalesMoney]);
                //grossProfitSum += Convert.ToDouble(dr[DCHNB02054EA.ct_Col_GrossProfit]);
                totalSalesMoneySum += Convert.ToDouble(dr[DCHNB02054EA.ct_Col_TotalSalesMoneyOrg]);
                grossProfitSum += Convert.ToDouble(dr[DCHNB02054EA.ct_Col_GrossProfitOrg]);

                if (totalSalesMoneyDic.ContainsKey(shipmGoodsOdrReportResultWork.AddUpSecCode))
                {
                    totalSalesMoneyDic[shipmGoodsOdrReportResultWork.AddUpSecCode] =
                        totalSalesMoneyDic[shipmGoodsOdrReportResultWork.AddUpSecCode] + Convert.ToDouble(dr[DCHNB02054EA.ct_Col_TotalSalesMoneyOrg]);

                    grossProfitDic[shipmGoodsOdrReportResultWork.AddUpSecCode] =
                        grossProfitDic[shipmGoodsOdrReportResultWork.AddUpSecCode] + Convert.ToDouble(dr[DCHNB02054EA.ct_Col_GrossProfitOrg]);
                }
                else
                {
                    totalSalesMoneyDic.Add(shipmGoodsOdrReportResultWork.AddUpSecCode, Convert.ToDouble(dr[DCHNB02054EA.ct_Col_TotalSalesMoneyOrg]));

                    grossProfitDic.Add(shipmGoodsOdrReportResultWork.AddUpSecCode, Convert.ToDouble(dr[DCHNB02054EA.ct_Col_GrossProfitOrg]));
                }

                // --- ADD 2008/09/24 --------------------------------<<<<<

                /* --- DEL 2008/09/24 -------------------------------->>>>>
                //dr[DCHNB02054EA.ct_Col_SectionGuideNm] = shipmGoodsOdrReportResultWork.SectionGuideNm;
                //dr[DCHNB02054EA.ct_Col_SubSectionCode] = shipmGoodsOdrReportResultWork.SubSectionCode;
                //dr[DCHNB02054EA.ct_Col_SubSectionName] = shipmGoodsOdrReportResultWork.SubSectionName;
                //dr[DCHNB02054EA.ct_Col_MinSectionCode] = shipmGoodsOdrReportResultWork.MinSectionCode;
                //dr[DCHNB02054EA.ct_Col_MinSectionName] = shipmGoodsOdrReportResultWork.MinSectionName;
                //dr[DCHNB02054EA.ct_Col_EmployeeName] = shipmGoodsOdrReportResultWork.EmployeeName;
                //dr[DCHNB02054EA.ct_Col_CustomerSnm] = shipmGoodsOdrReportResultWork.CustomerSnm;
                //dr[DCHNB02054EA.ct_Col_MakerName] = shipmGoodsOdrReportResultWork.MakerName;
                //dr[DCHNB02054EA.ct_Col_LargeGoodsGanreCode] = shipmGoodsOdrReportResultWork.LargeGoodsGanreCode;
                //dr[DCHNB02054EA.ct_Col_LargeGoodsGanreName] = shipmGoodsOdrReportResultWork.LargeGoodsGanreName;
                //dr[DCHNB02054EA.ct_Col_MediumGoodsGanreCode] = shipmGoodsOdrReportResultWork.MediumGoodsGanreCode;
                //dr[DCHNB02054EA.ct_Col_MediumGoodsGanreName] = shipmGoodsOdrReportResultWork.MediumGoodsGanreName;
                //dr[DCHNB02054EA.ct_Col_DetailGoodsGanreCode] = shipmGoodsOdrReportResultWork.DetailGoodsGanreCode;
                //dr[DCHNB02054EA.ct_Col_DetailGoodsGanreName] = shipmGoodsOdrReportResultWork.DetailGoodsGanreName;

                //dr[DCHNB02054EA.ct_Col_GoodsShortName] = shipmGoodsOdrReportResultWork.GoodsShortName; // DEL 2008/09/24

                //08.04.07 Mabuchi  Delete & Add START-------------------------------------------------------------------------
                //dr[DCHNB02054EA.ct_Col_TotalProceeds1] = shipmGoodsOdrReportResultWork.TotalProceeds1 / moneyUnit;
                //dr[DCHNB02054EA.ct_Col_TotalProceeds2] = shipmGoodsOdrReportResultWork.TotalProceeds2 / moneyUnit;
                //dr[DCHNB02054EA.ct_Col_TotalProceeds3] = shipmGoodsOdrReportResultWork.TotalProceeds3 / moneyUnit;
                //dr[DCHNB02054EA.ct_Col_TotalProceeds4] = shipmGoodsOdrReportResultWork.TotalProceeds4 / moneyUnit;
                //dr[DCHNB02054EA.ct_Col_TotalProceeds5] = shipmGoodsOdrReportResultWork.TotalProceeds5 / moneyUnit;
                //dr[DCHNB02054EA.ct_Col_TotalProceeds6] = shipmGoodsOdrReportResultWork.TotalProceeds6 / moneyUnit;
                //dr[DCHNB02054EA.ct_Col_TotalProceeds7] = shipmGoodsOdrReportResultWork.TotalProceeds7 / moneyUnit;
                //dr[DCHNB02054EA.ct_Col_TotalProceeds8] = shipmGoodsOdrReportResultWork.TotalProceeds8 / moneyUnit;
                //dr[DCHNB02054EA.ct_Col_TotalProceeds9] = shipmGoodsOdrReportResultWork.TotalProceeds9 / moneyUnit;
                //dr[DCHNB02054EA.ct_Col_TotalProceeds10] = shipmGoodsOdrReportResultWork.TotalProceeds10 / moneyUnit;
                //dr[DCHNB02054EA.ct_Col_TotalProceeds11] = shipmGoodsOdrReportResultWork.TotalProceeds11 / moneyUnit;
                //dr[DCHNB02054EA.ct_Col_TotalProceeds12] = shipmGoodsOdrReportResultWork.TotalProceeds12 / moneyUnit;

                    if (shipmGoodsOdrReport.MoneyUnit == 1)
                    {
                        //TotalProceeds1 = Convert.ToDecimal(shipmGoodsOdrReportResultWork.TotalProceeds1) / 1000m;
                        //TotalProceeds2 = Convert.ToDecimal(shipmGoodsOdrReportResultWork.TotalProceeds2) / 1000m;
                        //TotalProceeds3 = Convert.ToDecimal(shipmGoodsOdrReportResultWork.TotalProceeds3) / 1000m;
                        //TotalProceeds4 = Convert.ToDecimal(shipmGoodsOdrReportResultWork.TotalProceeds4) / 1000m;
                        //TotalProceeds5 = Convert.ToDecimal(shipmGoodsOdrReportResultWork.TotalProceeds5) / 1000m;
                        //TotalProceeds6 = Convert.ToDecimal(shipmGoodsOdrReportResultWork.TotalProceeds6) / 1000m;
                        //TotalProceeds7 = Convert.ToDecimal(shipmGoodsOdrReportResultWork.TotalProceeds7) / 1000m;
                        //TotalProceeds8 = Convert.ToDecimal(shipmGoodsOdrReportResultWork.TotalProceeds8) / 1000m;
                        //TotalProceeds9 = Convert.ToDecimal(shipmGoodsOdrReportResultWork.TotalProceeds9) / 1000m;
                        //TotalProceeds10 = Convert.ToDecimal(shipmGoodsOdrReportResultWork.TotalProceeds10) / 1000m;
                        //TotalProceeds11 = Convert.ToDecimal(shipmGoodsOdrReportResultWork.TotalProceeds11) / 1000m;
                        //TotalProceeds12 = Convert.ToDecimal(shipmGoodsOdrReportResultWork.TotalProceeds12) / 1000m;
        
                        //dr[DCHNB02054EA.ct_Col_TotalProceeds1] = Math.Round(TotalProceeds1, 0, MidpointRounding.AwayFromZero);
                        //dr[DCHNB02054EA.ct_Col_TotalProceeds2] = Math.Round(TotalProceeds2, 0, MidpointRounding.AwayFromZero);
                        //dr[DCHNB02054EA.ct_Col_TotalProceeds3] = Math.Round(TotalProceeds3, 0, MidpointRounding.AwayFromZero);
                        //dr[DCHNB02054EA.ct_Col_TotalProceeds4] = Math.Round(TotalProceeds4, 0, MidpointRounding.AwayFromZero);
                        //dr[DCHNB02054EA.ct_Col_TotalProceeds5] = Math.Round(TotalProceeds5, 0, MidpointRounding.AwayFromZero);
                        //dr[DCHNB02054EA.ct_Col_TotalProceeds6] = Math.Round(TotalProceeds6, 0, MidpointRounding.AwayFromZero);
                        //dr[DCHNB02054EA.ct_Col_TotalProceeds7] = Math.Round(TotalProceeds7, 0, MidpointRounding.AwayFromZero);
                        //dr[DCHNB02054EA.ct_Col_TotalProceeds8] = Math.Round(TotalProceeds8, 0, MidpointRounding.AwayFromZero);
                        //dr[DCHNB02054EA.ct_Col_TotalProceeds9] = Math.Round(TotalProceeds9, 0, MidpointRounding.AwayFromZero);
                        //dr[DCHNB02054EA.ct_Col_TotalProceeds10] = Math.Round(TotalProceeds10, 0, MidpointRounding.AwayFromZero);
                        //dr[DCHNB02054EA.ct_Col_TotalProceeds11] = Math.Round(TotalProceeds11, 0, MidpointRounding.AwayFromZero);
                        //dr[DCHNB02054EA.ct_Col_TotalProceeds12] = Math.Round(TotalProceeds12, 0, MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        //dr[DCHNB02054EA.ct_Col_TotalProceeds1] = shipmGoodsOdrReportResultWork.TotalProceeds1 ;
                        //dr[DCHNB02054EA.ct_Col_TotalProceeds2] = shipmGoodsOdrReportResultWork.TotalProceeds2 ;
                        //dr[DCHNB02054EA.ct_Col_TotalProceeds3] = shipmGoodsOdrReportResultWork.TotalProceeds3 ;
                        //dr[DCHNB02054EA.ct_Col_TotalProceeds4] = shipmGoodsOdrReportResultWork.TotalProceeds4 ;
                        //dr[DCHNB02054EA.ct_Col_TotalProceeds5] = shipmGoodsOdrReportResultWork.TotalProceeds5 ;
                        //dr[DCHNB02054EA.ct_Col_TotalProceeds6] = shipmGoodsOdrReportResultWork.TotalProceeds6 ;
                        //dr[DCHNB02054EA.ct_Col_TotalProceeds7] = shipmGoodsOdrReportResultWork.TotalProceeds7 ;
                        //dr[DCHNB02054EA.ct_Col_TotalProceeds8] = shipmGoodsOdrReportResultWork.TotalProceeds8 ;
                        //dr[DCHNB02054EA.ct_Col_TotalProceeds9] = shipmGoodsOdrReportResultWork.TotalProceeds9 ;
                        //dr[DCHNB02054EA.ct_Col_TotalProceeds10] = shipmGoodsOdrReportResultWork.TotalProceeds10 ;
                        //dr[DCHNB02054EA.ct_Col_TotalProceeds11] = shipmGoodsOdrReportResultWork.TotalProceeds11 ;
                        //dr[DCHNB02054EA.ct_Col_TotalProceeds12] = shipmGoodsOdrReportResultWork.TotalProceeds12 ;
                    }
                //08.04.07 Mabuchi  Delete & Add END----------------------------------------------------------------------------

                //dr[DCHNB02054EA.ct_Col_GrossProfit1] = shipmGoodsOdrReportResultWork.GrossProfit1;
                //dr[DCHNB02054EA.ct_Col_GrossProfit2] = shipmGoodsOdrReportResultWork.GrossProfit2;
                //dr[DCHNB02054EA.ct_Col_GrossProfit3] = shipmGoodsOdrReportResultWork.GrossProfit3;
                //dr[DCHNB02054EA.ct_Col_GrossProfit4] = shipmGoodsOdrReportResultWork.GrossProfit4;
                //dr[DCHNB02054EA.ct_Col_GrossProfit5] = shipmGoodsOdrReportResultWork.GrossProfit5;
                //dr[DCHNB02054EA.ct_Col_GrossProfit6] = shipmGoodsOdrReportResultWork.GrossProfit6;
                //dr[DCHNB02054EA.ct_Col_GrossProfit7] = shipmGoodsOdrReportResultWork.GrossProfit7;
                //dr[DCHNB02054EA.ct_Col_GrossProfit8] = shipmGoodsOdrReportResultWork.GrossProfit8;
                //dr[DCHNB02054EA.ct_Col_GrossProfit9] = shipmGoodsOdrReportResultWork.GrossProfit9;
                //dr[DCHNB02054EA.ct_Col_GrossProfit10] = shipmGoodsOdrReportResultWork.GrossProfit10;
                //dr[DCHNB02054EA.ct_Col_GrossProfit11] = shipmGoodsOdrReportResultWork.GrossProfit11;
                //dr[DCHNB02054EA.ct_Col_GrossProfit12] = shipmGoodsOdrReportResultWork.GrossProfit12;
                //dr[DCHNB02054EA.ct_Col_Tag] = shipmGoodsOdrReportResultWork.Tag;

                //売上数計合計
                double totalSalesCountTotal = shipmGoodsOdrReportResultWork.TotalSalesCount1
                                        +  shipmGoodsOdrReportResultWork.TotalSalesCount2
                                        +  shipmGoodsOdrReportResultWork.TotalSalesCount3
                                        +  shipmGoodsOdrReportResultWork.TotalSalesCount4
                                        +  shipmGoodsOdrReportResultWork.TotalSalesCount5
                                        +  shipmGoodsOdrReportResultWork.TotalSalesCount6
                                        +  shipmGoodsOdrReportResultWork.TotalSalesCount7
                                        +  shipmGoodsOdrReportResultWork.TotalSalesCount8
                                        +  shipmGoodsOdrReportResultWork.TotalSalesCount9
                                        +  shipmGoodsOdrReportResultWork.TotalSalesCount10
                                        +  shipmGoodsOdrReportResultWork.TotalSalesCount11
                                        +  shipmGoodsOdrReportResultWork.TotalSalesCount12;
                dr[DCHNB02054EA.ct_Col_TotalSalesCountTotal] = totalSalesCountTotal;

                //売上数計平均
                dr[DCHNB02054EA.ct_Col_TotalSalesCountAve] = (double)totalSalesCountTotal / month;

                //売上回数合計
                Int32 salesTimesTotal = shipmGoodsOdrReportResultWork.SalesTimes1
                                    + shipmGoodsOdrReportResultWork.SalesTimes2
                                    + shipmGoodsOdrReportResultWork.SalesTimes3
                                    + shipmGoodsOdrReportResultWork.SalesTimes4
                                    + shipmGoodsOdrReportResultWork.SalesTimes5
                                    + shipmGoodsOdrReportResultWork.SalesTimes6
                                    + shipmGoodsOdrReportResultWork.SalesTimes7
                                    + shipmGoodsOdrReportResultWork.SalesTimes8
                                    + shipmGoodsOdrReportResultWork.SalesTimes9
                                    + shipmGoodsOdrReportResultWork.SalesTimes10
                                    + shipmGoodsOdrReportResultWork.SalesTimes11
                                    + shipmGoodsOdrReportResultWork.SalesTimes12;
                dr[DCHNB02054EA.ct_Col_SalesTimesTotal] = salesTimesTotal;


                //売上回数平均
                dr[DCHNB02054EA.ct_Col_SalesTimesAve] = (double)salesTimesTotal / month;

                //純売上合計合計（税抜き）
                Int64 totalProceedsTotal = shipmGoodsOdrReportResultWork.TotalProceeds1
                                        + shipmGoodsOdrReportResultWork.TotalProceeds2
                                        + shipmGoodsOdrReportResultWork.TotalProceeds3
                                        + shipmGoodsOdrReportResultWork.TotalProceeds4
                                        + shipmGoodsOdrReportResultWork.TotalProceeds5
                                        + shipmGoodsOdrReportResultWork.TotalProceeds6
                                        + shipmGoodsOdrReportResultWork.TotalProceeds7
                                        + shipmGoodsOdrReportResultWork.TotalProceeds8
                                        + shipmGoodsOdrReportResultWork.TotalProceeds9
                                        + shipmGoodsOdrReportResultWork.TotalProceeds10
                                        + shipmGoodsOdrReportResultWork.TotalProceeds11
                                        + shipmGoodsOdrReportResultWork.TotalProceeds12;

                //08.04.07 Mabuchi  Delete & Add START-----------------------------------------------------------------------------				
                //dr[DCHNB02054EA.ct_Col_TotalProceedsTotal] = totalProceedsTotal / moneyUnit;

                    if (shipmGoodsOdrReport.MoneyUnit == 1)
                    {
                        dbl_totalProceedsTotal = totalProceedsTotal / 1000m;
                        dr[DCHNB02054EA.ct_Col_TotalProceedsTotal] = Math.Round(dbl_totalProceedsTotal, 0, MidpointRounding.AwayFromZero);
		
                    }
                    else
                    {
                        dr[DCHNB02054EA.ct_Col_TotalProceedsTotal] = totalProceedsTotal;
                    }

                ////純売上合計平均（税抜き）
                //dr[DCHNB02054EA.ct_Col_TotalProceedsAve] = ((double)totalProceedsTotal / month) / moneyUnit;

                //純売上合計平均（税抜き）
                    if (shipmGoodsOdrReport.MoneyUnit == 1)
                    {
                        dbl_TotalProceedsAve = ((decimal)totalProceedsTotal / month) / 1000m;
                        dr[DCHNB02054EA.ct_Col_TotalProceedsAve] = Math.Round(dbl_TotalProceedsAve, 0, MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        dr[DCHNB02054EA.ct_Col_TotalProceedsAve] = ((double)totalProceedsTotal / month);
                    }

                //08.04.07 Mabuchi  Delete & Add END----------------------------------------------------------------------------

                //粗利金額合計（税抜き）
                Int64 grossProfitTotal = shipmGoodsOdrReportResultWork.GrossProfit1
                                    + shipmGoodsOdrReportResultWork.GrossProfit2
                                    + shipmGoodsOdrReportResultWork.GrossProfit3
                                    + shipmGoodsOdrReportResultWork.GrossProfit4
                                    + shipmGoodsOdrReportResultWork.GrossProfit5
                                    + shipmGoodsOdrReportResultWork.GrossProfit6
                                    + shipmGoodsOdrReportResultWork.GrossProfit7
                                    + shipmGoodsOdrReportResultWork.GrossProfit8
                                    + shipmGoodsOdrReportResultWork.GrossProfit9
                                    + shipmGoodsOdrReportResultWork.GrossProfit10
                                    + shipmGoodsOdrReportResultWork.GrossProfit11
                                    + shipmGoodsOdrReportResultWork.GrossProfit12;

                dr[DCHNB02054EA.ct_Col_GrossProfitTotal] = grossProfitTotal;

                //粗利金額平均（税抜き）
                dr[DCHNB02054EA.ct_Col_GrossProfitAve] = (double)grossProfitTotal / month;

                //出荷平均ロット
                dr[DCHNB02054EA.ct_Col_AveLot1] = shipmGoodsOdrReportResultWork.TotalSalesCount1  / shipmGoodsOdrReportResultWork.SalesTimes1;
                dr[DCHNB02054EA.ct_Col_AveLot1] = shipmGoodsOdrReportResultWork.TotalSalesCount2  / shipmGoodsOdrReportResultWork.SalesTimes2;
                dr[DCHNB02054EA.ct_Col_AveLot1] = shipmGoodsOdrReportResultWork.TotalSalesCount3  / shipmGoodsOdrReportResultWork.SalesTimes3;
                dr[DCHNB02054EA.ct_Col_AveLot1] = shipmGoodsOdrReportResultWork.TotalSalesCount4  / shipmGoodsOdrReportResultWork.SalesTimes4;
                dr[DCHNB02054EA.ct_Col_AveLot1] = shipmGoodsOdrReportResultWork.TotalSalesCount5  / shipmGoodsOdrReportResultWork.SalesTimes5;
                dr[DCHNB02054EA.ct_Col_AveLot1] = shipmGoodsOdrReportResultWork.TotalSalesCount6  / shipmGoodsOdrReportResultWork.SalesTimes6;
                dr[DCHNB02054EA.ct_Col_AveLot1] = shipmGoodsOdrReportResultWork.TotalSalesCount7  / shipmGoodsOdrReportResultWork.SalesTimes7;
                dr[DCHNB02054EA.ct_Col_AveLot1] = shipmGoodsOdrReportResultWork.TotalSalesCount8  / shipmGoodsOdrReportResultWork.SalesTimes8;
                dr[DCHNB02054EA.ct_Col_AveLot1] = shipmGoodsOdrReportResultWork.TotalSalesCount9  / shipmGoodsOdrReportResultWork.SalesTimes9;
                dr[DCHNB02054EA.ct_Col_AveLot1] = shipmGoodsOdrReportResultWork.TotalSalesCount10 / shipmGoodsOdrReportResultWork.SalesTimes10;
                dr[DCHNB02054EA.ct_Col_AveLot1] = shipmGoodsOdrReportResultWork.TotalSalesCount11 / shipmGoodsOdrReportResultWork.SalesTimes11;
                dr[DCHNB02054EA.ct_Col_AveLot1] = shipmGoodsOdrReportResultWork.TotalSalesCount12 / shipmGoodsOdrReportResultWork.SalesTimes12;

                dr[DCHNB02054EA.ct_Col_AveLotTotal] = totalSalesCountTotal / salesTimesTotal;
                dr[DCHNB02054EA.ct_Col_AveLotAve] = (totalSalesCountTotal / salesTimesTotal) / month;

                //順位
                //dr[DCHNB02054EA.ct_Col_OrderNo] = ++order;
                 --- DEL 2008/09/24 --------------------------------*/

                //Field値設定

                // --- DEL 2008/09/24 --------------------------------<<<<<
                ////集計方法
                //string sectionHeaderField = "";
                //if (shipmGoodsOdrReport.TtlType == 1)
                //{
                //    //拠点Field
                //    sectionHeaderField = shipmGoodsOdrReportResultWork.AddUpSecCode;
                //    dr[DCHNB02054EA.ct_Col_SectionHeaderField] = shipmGoodsOdrReportResultWork.AddUpSecCode;
                //}
                //else
                //{
                //    //拠点Field
                //    sectionHeaderField = "";
                //    dr[DCHNB02054EA.ct_Col_SectionHeaderField] = "";
                //}

                // --- DEL 2008/09/24 --------------------------------<<<<<

                //拠点Field
                string sectionHeaderField = "";
                sectionHeaderField = shipmGoodsOdrReportResultWork.AddUpSecCode;
                dr[DCHNB02054EA.ct_Col_SectionHeaderField] = shipmGoodsOdrReportResultWork.AddUpSecCode;

                //集計単位
                switch (shipmGoodsOdrReport.TotalType)
                {
                    //0:商品別
                    case 0:
                        //明細単位
                        switch (shipmGoodsOdrReport.Detail)
                        {
                            //0:仕入先＋メーカーコード＋商品中分類＋ＢＬコード＋品番
                            case 0:
                                // --- DEL 2008/09/24 -------------------------------->>>>>
                                ////メーカーField
                                //dr[DCHNB02054EA.ct_Col_MakerField] = sectionHeaderField
                                //                                + shipmGoodsOdrReportResultWork.GoodsMakerCd.ToString("d6");

                                ////商品区分Field
                                //dr[DCHNB02054EA.ct_Col_GoodsField] = sectionHeaderField
                                //                                    + shipmGoodsOdrReportResultWork.GoodsMakerCd.ToString("d6")
                                //                                    + shipmGoodsOdrReportResultWork.LargeGoodsGanreCode
                                //                                    + shipmGoodsOdrReportResultWork.MediumGoodsGanreCode;
                                ////BL商品Field
                                //dr[DCHNB02054EA.ct_Col_BlField] = sectionHeaderField
                                //                                    + shipmGoodsOdrReportResultWork.GoodsMakerCd.ToString("d6")
                                //                                    + shipmGoodsOdrReportResultWork.LargeGoodsGanreCode
                                //                                    + shipmGoodsOdrReportResultWork.MediumGoodsGanreCode
                                //                                    + shipmGoodsOdrReportResultWork.BLGoodsCode.ToString("d8");
                                // --- DEL 2008/09/24 --------------------------------<<<<<

                                // --- ADD 2008/09/24 -------------------------------->>>>>
                                // 仕入先Field
                                dr[DCHNB02054EA.ct_Col_SuplierField] = sectionHeaderField
                                                                + shipmGoodsOdrReportResultWork.SupplierCd.ToString("d5");

                                // メーカーField
                                dr[DCHNB02054EA.ct_Col_MakerField] = sectionHeaderField
                                                                + shipmGoodsOdrReportResultWork.SupplierCd.ToString("d5")
                                                                + shipmGoodsOdrReportResultWork.GoodsMakerCd.ToString("d4");

                                // 商品中分類Field
                                dr[DCHNB02054EA.ct_Col_GoodsMGroupField] = sectionHeaderField
                                                                + shipmGoodsOdrReportResultWork.SupplierCd.ToString("d5")
                                                                + shipmGoodsOdrReportResultWork.GoodsMakerCd.ToString("d4")
                                                                + shipmGoodsOdrReportResultWork.GoodsMGroup.ToString("d4");


                                // BLコードField
                                dr[DCHNB02054EA.ct_Col_BLGoodsField] = sectionHeaderField
                                                                + shipmGoodsOdrReportResultWork.SupplierCd.ToString("d5")
                                                                + shipmGoodsOdrReportResultWork.GoodsMakerCd.ToString("d4")
                                                                + shipmGoodsOdrReportResultWork.GoodsMGroup.ToString("d4")
                                                                + shipmGoodsOdrReportResultWork.BLGoodsCode.ToString("d5");
                                // --- ADD 2008/09/24 --------------------------------<<<<<
                                break;
                            //1:メーカー＋商品中分類＋ＢＬコード＋品番
                            case 1:
                                // --- ADD 2008/09/24 -------------------------------->>>>>
                                //メーカーField
                                dr[DCHNB02054EA.ct_Col_MakerField] = sectionHeaderField
                                    + shipmGoodsOdrReportResultWork.GoodsMakerCd.ToString("d4");

                                // 商品中分類Field
                                dr[DCHNB02054EA.ct_Col_GoodsMGroupField] = sectionHeaderField
                                                                + shipmGoodsOdrReportResultWork.GoodsMakerCd.ToString("d4")
                                                                + shipmGoodsOdrReportResultWork.GoodsMGroup.ToString("d4");

                                // BLコードField
                                dr[DCHNB02054EA.ct_Col_BLGoodsField] = sectionHeaderField
                                                                + shipmGoodsOdrReportResultWork.GoodsMakerCd.ToString("d4")
                                                                + shipmGoodsOdrReportResultWork.GoodsMGroup.ToString("d4")
                                                                + shipmGoodsOdrReportResultWork.BLGoodsCode.ToString("d5");

                                // 仕入先Field
                                dr[DCHNB02054EA.ct_Col_SuplierField] = "";

                                // --- ADD 2008/09/24 --------------------------------<<<<<
                                //// --- DEL 2008/09/24 -------------------------------->>>>>
                                ////メーカーField
                                //dr[DCHNB02054EA.ct_Col_MakerField] = "";

                                ////商品区分Field
                                //dr[DCHNB02054EA.ct_Col_GoodsField] = sectionHeaderField
                                //                                    + shipmGoodsOdrReportResultWork.LargeGoodsGanreCode
                                //                                    + shipmGoodsOdrReportResultWork.MediumGoodsGanreCode;
                                ////BL商品Field
                                //dr[DCHNB02054EA.ct_Col_BlField] = sectionHeaderField
                                //                                    + shipmGoodsOdrReportResultWork.LargeGoodsGanreCode
                                //                                    + shipmGoodsOdrReportResultWork.MediumGoodsGanreCode
                                //                                    + shipmGoodsOdrReportResultWork.BLGoodsCode.ToString("d8");
                                // --- DEL 2008/09/24 --------------------------------<<<<<

                                break;
                            //2:仕入先＋メーカーコード＋品番
                            case 2:
                                // --- ADD 2008/09/24 -------------------------------->>>>>
                                // 仕入先Field
                                dr[DCHNB02054EA.ct_Col_SuplierField] = sectionHeaderField
                                                                + shipmGoodsOdrReportResultWork.SupplierCd.ToString("d5");

                                // メーカーField
                                dr[DCHNB02054EA.ct_Col_MakerField] = sectionHeaderField
                                                                + shipmGoodsOdrReportResultWork.SupplierCd.ToString("d5")
                                                                + shipmGoodsOdrReportResultWork.GoodsMakerCd.ToString("d4");

                                // 商品中分類Field
                                dr[DCHNB02054EA.ct_Col_GoodsMGroupField] = "";

                                // BLコードField
                                dr[DCHNB02054EA.ct_Col_BLGoodsField] = "";

                                // --- ADD 2008/09/24 --------------------------------<<<<<
                                //// --- DEL 2008/09/24 -------------------------------->>>>>
                                //メーカーField
                                //dr[DCHNB02054EA.ct_Col_MakerField] = sectionHeaderField
                                //                                + shipmGoodsOdrReportResultWork.GoodsMakerCd.ToString("d6");

                                //商品区分Field
                                //dr[DCHNB02054EA.ct_Col_GoodsField] = "";

                                ////BL商品Field
                                //dr[DCHNB02054EA.ct_Col_BlField] = "";
                                //// --- DEL 2008/09/24 --------------------------------<<<<<
                                break;
                            //3:メーカー＋品番
                            case 3:
                                // --- ADD 2008/09/24 -------------------------------->>>>>
                                //メーカーField
                                dr[DCHNB02054EA.ct_Col_MakerField] = sectionHeaderField
                                    + shipmGoodsOdrReportResultWork.GoodsMakerCd.ToString("d4");

                                // 仕入先Field
                                dr[DCHNB02054EA.ct_Col_SuplierField] = "";

                                // 商品中分類Field
                                dr[DCHNB02054EA.ct_Col_GoodsMGroupField] = "";

                                // BLコードField
                                dr[DCHNB02054EA.ct_Col_BLGoodsField] = "";
                                // --- ADD 2008/09/24 --------------------------------<<<<<
                                // --- DEL 2008/09/24 -------------------------------->>>>>
                                ////メーカーField
                                //dr[DCHNB02054EA.ct_Col_MakerField] = "";

                                ////商品区分Field
                                //dr[DCHNB02054EA.ct_Col_GoodsField] = sectionHeaderField
                                //                                    + shipmGoodsOdrReportResultWork.LargeGoodsGanreCode
                                //                                    + shipmGoodsOdrReportResultWork.MediumGoodsGanreCode;

                                ////BL商品Field
                                //dr[DCHNB02054EA.ct_Col_BLGoodsField] = "";
                                // --- DEL 2008/09/24 --------------------------------<<<<<

                                break;
                            //4:メーカー＋商品中分類＋品番
                            case 4:
                                // --- ADD 2008/09/24 -------------------------------->>>>>
                                //メーカーField
                                dr[DCHNB02054EA.ct_Col_MakerField] = sectionHeaderField
                                    + shipmGoodsOdrReportResultWork.GoodsMakerCd.ToString("d4");

                                // 商品中分類Field
                                dr[DCHNB02054EA.ct_Col_GoodsMGroupField] = sectionHeaderField
                                                                + shipmGoodsOdrReportResultWork.GoodsMakerCd.ToString("d4")
                                + shipmGoodsOdrReportResultWork.GoodsMGroup.ToString("d4");

                                // 仕入先Field
                                dr[DCHNB02054EA.ct_Col_SuplierField] = "";

                                // BLコードField
                                dr[DCHNB02054EA.ct_Col_BLGoodsField] = "";

                                // --- ADD 2008/09/24 --------------------------------<<<<<

                                // --- DEL 2008/09/24 -------------------------------->>>>>
                                ////メーカーField
                                //dr[DCHNB02054EA.ct_Col_MakerField] = "";

                                ////商品区分Field
                                ////dr[DCHNB02054EA.ct_Col_GoodsField] = ""; // DEL 2008/09/24

                                ////BL商品Field
                                //dr[DCHNB02054EA.ct_Col_BLGoodsField] = "";
                                //// --- DEL 2008/09/24 --------------------------------<<<<<
                                break;
                        }
                        //商品大分類Field
                        dr[DCHNB02054EA.ct_Col_GoodsLGroupField] = "";
                        //グループコードField
                        dr[DCHNB02054EA.ct_Col_BLGroupField] = "";
                        //得意先Field
                        dr[DCHNB02054EA.ct_Col_CustomerField] = "";
                        //担当者Field
                        dr[DCHNB02054EA.ct_Col_SalesEmployeeField] = "";
                        break;
                    //1:BLコード別 
                    case 1:
                        // 仕入先Field
                        dr[DCHNB02054EA.ct_Col_SuplierField] = sectionHeaderField
                                                        + shipmGoodsOdrReportResultWork.SupplierCd.ToString("d5");
                        // メーカーField
                        dr[DCHNB02054EA.ct_Col_MakerField] = sectionHeaderField
                                                        + shipmGoodsOdrReportResultWork.SupplierCd.ToString("d5")
                                                        + shipmGoodsOdrReportResultWork.GoodsMakerCd.ToString("d4");

                        // 商品大分類Field
                        dr[DCHNB02054EA.ct_Col_GoodsLGroupField] = sectionHeaderField
                                                        + shipmGoodsOdrReportResultWork.SupplierCd.ToString("d5")
                                                        + shipmGoodsOdrReportResultWork.GoodsMakerCd.ToString("d4")
                                                        + shipmGoodsOdrReportResultWork.GoodsLGroup.ToString("d4");

                        // 商品中分類Field
                        dr[DCHNB02054EA.ct_Col_GoodsMGroupField] = sectionHeaderField
                                                        + shipmGoodsOdrReportResultWork.SupplierCd.ToString("d5")
                                                        + shipmGoodsOdrReportResultWork.GoodsMakerCd.ToString("d4")
                                                        + shipmGoodsOdrReportResultWork.GoodsLGroup.ToString("d4")
                                                        + shipmGoodsOdrReportResultWork.GoodsMGroup.ToString("d4");

                        //グループコードField
                        dr[DCHNB02054EA.ct_Col_BLGroupField] = sectionHeaderField
                                                        + shipmGoodsOdrReportResultWork.SupplierCd.ToString("d5")
                                                        + shipmGoodsOdrReportResultWork.GoodsMakerCd.ToString("d4")
                                                        + shipmGoodsOdrReportResultWork.GoodsLGroup.ToString("d4")
                                                        + shipmGoodsOdrReportResultWork.GoodsMGroup.ToString("d4")
                                                        + shipmGoodsOdrReportResultWork.BLGroupCode.ToString("d5");

                        break;
                    //2:得意先別
                    case 2:

                        //得意先Field
                        dr[DCHNB02054EA.ct_Col_CustomerField] = sectionHeaderField
                                                            + shipmGoodsOdrReportResultWork.CustomerCode.ToString("d8");

                        //メーカーField
                        dr[DCHNB02054EA.ct_Col_MakerField] = sectionHeaderField
                                                            + shipmGoodsOdrReportResultWork.CustomerCode.ToString("d8")
                                                            + shipmGoodsOdrReportResultWork.GoodsMakerCd.ToString("d6");

                        //グループコードField
                        dr[DCHNB02054EA.ct_Col_BLGroupField] = sectionHeaderField
                                                            + shipmGoodsOdrReportResultWork.CustomerCode.ToString("d8")
                                                            + shipmGoodsOdrReportResultWork.GoodsMakerCd.ToString("d6")
                                                            + shipmGoodsOdrReportResultWork.BLGroupCode.ToString("d5");

                        //仕入先Field
                        dr[DCHNB02054EA.ct_Col_SuplierField] = "";
                        //担当者Field
                        dr[DCHNB02054EA.ct_Col_SalesEmployeeField] = "";
                        //商品大分類Field
                        dr[DCHNB02054EA.ct_Col_GoodsLGroupField] = "";
                        //商品中分類Field
                        dr[DCHNB02054EA.ct_Col_GoodsMGroupField] = "";
                        //BLコードField
                        dr[DCHNB02054EA.ct_Col_BLGoodsField] = "";

                        // --- DEL 2008/09/24 -------------------------------->>>>>
                        ////商品区分Field
                        //dr[DCHNB02054EA.ct_Col_GoodsField] = "";
                        ////BL商品Field
                        //dr[DCHNB02054EA.ct_Col_BlField] = "";
                        // --- DEL 2008/09/24 -------------------------------->>>>>
                        break;
                    //3:担当者別
                    case 3:
                        //担当者Field
                        dr[DCHNB02054EA.ct_Col_SalesEmployeeField] = sectionHeaderField
                                                            + shipmGoodsOdrReportResultWork.EmployeeCode.ToString();
                        //メーカーField
                        dr[DCHNB02054EA.ct_Col_MakerField] = sectionHeaderField
                                                            + shipmGoodsOdrReportResultWork.EmployeeCode
                                                            + shipmGoodsOdrReportResultWork.GoodsMakerCd.ToString("d6");

                        // --- DEL 2008/09/24 -------------------------------->>>>>
                        ////商品区分Field
                        //dr[DCHNB02054EA.ct_Col_GoodsField] = "";
                        ////BL商品Field
                        //dr[DCHNB02054EA.ct_Col_BlField] = "";
                        // --- DEL 2008/09/24 --------------------------------<<<<<
                        //仕入先Field
                        dr[DCHNB02054EA.ct_Col_SuplierField] = "";
                        //得意先Field
                        dr[DCHNB02054EA.ct_Col_CustomerField] = "";
                        //商品大分類Field
                        dr[DCHNB02054EA.ct_Col_GoodsLGroupField] = "";
                        //商品中分類Field
                        dr[DCHNB02054EA.ct_Col_GoodsMGroupField] = "";
                        //BLコードField
                        dr[DCHNB02054EA.ct_Col_BLGoodsField] = "";
                        //グループコードField
                        dr[DCHNB02054EA.ct_Col_BLGroupField] = "";
                        break;
                }
                // --- DEL 2008/09/24 -------------------------------->>>>>
                ////SectionHeaderLine
                //dr[DCHNB02054EA.ct_Col_SectionHeaderLine] = shipmGoodsOdrReportResultWork.AddUpSecCode;
                //dr[DCHNB02054EA.ct_Col_SectionHeaderLineName] = shipmGoodsOdrReportResultWork.SectionGuideNm;
                // --- DEL 2008/09/24 -------------------------------->>>>>
                #endregion

                // TableにAdd
                this._shipmGoodsOdrReportDt.Rows.Add(dr);
            }

            // 構成比の設定
            if (shipmGoodsOdrReport.TotalType == 1)
            {
                foreach (DataRow dro in _shipmGoodsOdrReportDt.Rows)
                {
                    if (shipmGoodsOdrReport.ConstUnit == 0)
                    {
                        // 全社
                        // 明細の売上構成比
                        dro[DCHNB02054EA.ct_Col_CmpPureSalesRatio] = this.GetRatio(Convert.ToDouble(dro[DCHNB02054EA.ct_Col_TotalSalesMoneyOrg]), totalSalesMoneySum);
                        // 小計計算用の売上合計値
                        dro[DCHNB02054EA.ct_Col_TotalSalesMoneySum] = totalSalesMoneySum;

                        // 明細の粗利構成比
                        dro[DCHNB02054EA.ct_Col_CmpProfitRatio] = this.GetRatio(Convert.ToDouble(dro[DCHNB02054EA.ct_Col_GrossProfitOrg]), grossProfitSum);
                        // 小計計算用の粗利合計値
                        dro[DCHNB02054EA.ct_Col_GrossProfitSum] = grossProfitSum;
                    }
                    else
                    {
                        // 拠点
                        // 明細の売上構成比
                        dro[DCHNB02054EA.ct_Col_CmpPureSalesRatio] = this.GetRatio(Convert.ToDouble(dro[DCHNB02054EA.ct_Col_TotalSalesMoneyOrg]),
                                                                totalSalesMoneyDic[dro[DCHNB02054EA.ct_Col_AddUpSecCode].ToString()]);
                        // 小計計算用の売上合計値
                        dro[DCHNB02054EA.ct_Col_TotalSalesMoneySum] = totalSalesMoneyDic[dro[DCHNB02054EA.ct_Col_AddUpSecCode].ToString()];

                        // 明細の粗利構成比
                        dro[DCHNB02054EA.ct_Col_CmpProfitRatio] = this.GetRatio(Convert.ToDouble(dro[DCHNB02054EA.ct_Col_GrossProfitOrg]),
                                                                grossProfitDic[dro[DCHNB02054EA.ct_Col_AddUpSecCode].ToString()]);
                        // 小計計算用の粗利合計値
                        dro[DCHNB02054EA.ct_Col_GrossProfitSum] = grossProfitDic[dro[DCHNB02054EA.ct_Col_AddUpSecCode].ToString()];
                    }
                }
            }

            //順位付け

            // DataView作成（順位用）
            string savAddUpSecCode = "";
            int orderNo = 0;
            int orderNoPls = 0;
            double savTotls = -1;
            double nowTotls = 0;

            this._shipmGoodsOdrReportView = new DataView(this._shipmGoodsOdrReportDt, "", GetSortOrder1(shipmGoodsOdrReport), DataViewRowState.CurrentRows);
            
            if (shipmGoodsOdrReport.SortItem != 4) // ADD 2008/09/24
            {
                for (int i = 0; i < this._shipmGoodsOdrReportView.Count; i++)
                {
                    //拠点管理する場合
                    if (shipmGoodsOdrReport.Order1 == 1)
                    {
                        string tmpAddUpSecCode = (string)this._shipmGoodsOdrReportView[i][DCHNB02054EA.ct_Col_AddUpSecCode];
                        if (savAddUpSecCode.Trim() != tmpAddUpSecCode.Trim())
                        {
                            savAddUpSecCode = tmpAddUpSecCode;
                            orderNo = 0;
                            orderNoPls = 0;
                            savTotls = -1;
                        }
                    }

                    //0:売上数量 1:売上回数 2:売上金額 3:粗利金額 4:品番(順位なし)
                    switch (shipmGoodsOdrReport.SortItem)
                    {
                        case 0:
                            if (shipmGoodsOdrReport.TotalType != 1)
                            {
                                nowTotls = (double)this._shipmGoodsOdrReportView[i][DCHNB02054EA.ct_Col_TotalSalesCountSum];
                            }
                            else
                            {
                                nowTotls = (double)this._shipmGoodsOdrReportView[i][DCHNB02054EA.ct_Col_TotalSalesCount];
                            }
                            break;
                        case 1:
                            nowTotls = (double)(this._shipmGoodsOdrReportView[i][DCHNB02054EA.ct_Col_SalesTimesSum]);
                            break;
                        case 2:
                            if (shipmGoodsOdrReport.TotalType != 1)
                            {
                                nowTotls = (double)(this._shipmGoodsOdrReportView[i][DCHNB02054EA.ct_Col_SalesMoneySumOrg]);
                            }
                            else
                            {
                                nowTotls = (double)((Int64)this._shipmGoodsOdrReportView[i][DCHNB02054EA.ct_Col_TotalSalesMoneyOrg]);
                            }
                            break;
                        case 3:
                            if (shipmGoodsOdrReport.TotalType != 1)
                            {
                                nowTotls = (double)(this._shipmGoodsOdrReportView[i][DCHNB02054EA.ct_Col_SalesMoneySumOrg]);
                            }
                            else
                            {
                                nowTotls = (double)((Int64)this._shipmGoodsOdrReportView[i][DCHNB02054EA.ct_Col_GrossProfitOrg]);
                            }
                            break;
                    }

                    if (savTotls == nowTotls)
                    {
                        orderNoPls++;
                    }
                    else
                    {
                        // 設定される値が順位の最大値設定を超えていないかチェック
                        if (orderNo + orderNoPls + 1 <= shipmGoodsOdrReport.Order3)
                        {
                            savTotls = nowTotls;
                            orderNo += orderNoPls;
                            orderNoPls = 0;
                        }
                        else
                        {
                            orderNo = 99999999; // 最大値以上を設定(帳票側で表示しないよう制御)
                            orderNoPls = 0;
                        }
                    }

                    if (orderNoPls == 0)
                    {
                        orderNo++;
                    }

                    this._shipmGoodsOdrReportView[i][DCHNB02054EA.ct_Col_OrderNo] = orderNo; // DEL 2008/09/24
                }
            }

            // DataView作成（印字用）
            this._shipmGoodsOdrReportView.Sort = GetSortOrder2(shipmGoodsOdrReport);

            // 2009/12/29 Add ランク外は印字されない様にフィルタをかける >>>
            this._shipmGoodsOdrReportView.RowFilter = "OrderNo < 99999999 + 1";
            // 2009/12/29 Add <<<

        }

		/// <summary>
		/// 範囲月数の取得処理
		/// </summary>
		/// <returns>範囲月数（ex.４月～６月ならば３）</returns>
		private int GetMonthRange(DateTime stYearMonth, DateTime edYearMonth)
		{
			int stMonth = stYearMonth.Month;
			int edMonth = edYearMonth.Month;

			if (edYearMonth.Year > stYearMonth.Year)
			{
				edMonth += 12;
			}

			return (edMonth - stMonth + 1);
		}
		#endregion

		#region ◎ ソート順作成
		/// <summary>
		/// ソート順作成（順位用）
		/// </summary>
		/// <returns>ソート文字列</returns>
		private string GetSortOrder1( ShipmGoodsOdrReport shipmGoodsOdrReport )
		{
			StringBuilder strSortOrder = new StringBuilder();

            if (shipmGoodsOdrReport.SortItem == 4)
            {
                // 順位指定なし
                return "";
            }

			// 順位付
            //if (shipmGoodsOdrReport.TtlType == 1)// DEL 2008/09/24
            if (shipmGoodsOdrReport.Order1 == 1)
			{
				//計上拠点コード
				strSortOrder.Append(string.Format("{0} ASC ,", DCHNB02054EA.ct_Col_AddUpSecCode));
			}

            string strAscDesc;

            if (shipmGoodsOdrReport.Order2 == 0)
            {
                strAscDesc = "DESC";
            }
            else
            {
                strAscDesc = "ASC";
            }

			//0:売上数量 1:売上回数 2:売上金額 3:粗利金額 4:順位なし
            switch (shipmGoodsOdrReport.SortItem)
            {
                // --- ADD 2008/09/24 -------------------------------->>>>>
                case 0:
                    if (shipmGoodsOdrReport.TotalType != 1)
                    {
                        strSortOrder.Append(string.Format("{0} {1}", DCHNB02054EA.ct_Col_TotalSalesCountSum, strAscDesc));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format("{0} {1}", DCHNB02054EA.ct_Col_TotalSalesCount, strAscDesc));
                    }

                    break;
                case 1:
                    strSortOrder.Append(string.Format("{0} {1}", DCHNB02054EA.ct_Col_SalesTimesSum, strAscDesc));
                    break;
                case 2:
                    if (shipmGoodsOdrReport.TotalType != 1)
                    {
                        strSortOrder.Append(string.Format("{0} {1}", DCHNB02054EA.ct_Col_SalesMoneySumOrg, strAscDesc));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format("{0} {1}", DCHNB02054EA.ct_Col_TotalSalesMoneyOrg, strAscDesc));
                    }

                    break;
                case 3:
                    if (shipmGoodsOdrReport.TotalType != 1)
                    {
                        strSortOrder.Append(string.Format("{0} {1}", DCHNB02054EA.ct_Col_SalesMoneySumOrg, strAscDesc));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format("{0} {1}", DCHNB02054EA.ct_Col_GrossProfitOrg, strAscDesc));
                    }
                    
                    break;
                // --- ADD 2008/09/24 --------------------------------<<<<<
            }

			return strSortOrder.ToString();
		}

		/// <summary>
		/// ソート順作成（印字用）
		/// </summary>
		/// <returns>ソート文字列</returns>
		private string GetSortOrder2(ShipmGoodsOdrReport shipmGoodsOdrReport)
		{
			StringBuilder strSortOrder = new StringBuilder();

            // --- DEL 2008/09/24 -------------------------------->>>>>
			//集計方法
            //if (shipmGoodsOdrReport.TtlType == 1)
            //{
            //    //計上拠点コード
            //    strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_AddUpSecCode));
            //}
            // --- DEL 2008/09/24 --------------------------------<<<<<

            //計上拠点コード
            strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_AddUpSecCode));
			
            //集計単位
			switch (shipmGoodsOdrReport.TotalType)
			{
				//0:商品別
				case 0:
					//明細単位
					switch (shipmGoodsOdrReport.Detail)
					{
						//0:仕入先＋メーカーコード＋商品中分類＋ＢＬコード＋品番
						case 0:
                            //strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_LargeGoodsGanreCode)); // DEL 2008/09/24
                            //strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_MediumGoodsGanreCode)); // DEL 2008/09/24
                            //strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_DetailGoodsGanreCode)); // DEL 2008/09/24
                            strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_SupplierCd));
                            strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_GoodsMakerCd));
                            strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_GoodsMGroup));
                            strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_BLGoodsCode));
                            break;
						//1:メーカー＋商品中分類＋ＢＬコード＋品番
						case 1:
                            //strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_LargeGoodsGanreCode)); // DEL 2008/09/24
                            //strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_MediumGoodsGanreCode)); // DEL 2008/09/24
							//strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_DetailGoodsGanreCode));
                            strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_GoodsMakerCd));
                            strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_GoodsMGroup));
                            strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_BLGoodsCode));
							break;
						//2:仕入先＋メーカーコード＋品番
						case 2:
                            strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_SupplierCd));
							strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_GoodsMakerCd));
							break;
						//3:メーカー＋品番
						case 3:
                            strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_GoodsMakerCd));
                            //strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_LargeGoodsGanreCode)); // DEL 2008/09/24
                            //strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_MediumGoodsGanreCode)); // DEL 2008/09/24
							//strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_DetailGoodsGanreCode));
							break;
						//4:メーカー＋商品中分類＋品番
						case 4:
                            strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_GoodsMakerCd));
                            strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_GoodsMGroup));
							break;
					}
					break;
                // BLコード別
                case 1:
                    strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_SupplierCd));
                    strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_GoodsMakerCd));
                    strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_GoodsLGroup));
                    strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_GoodsMGroup));
                    strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_BLGroupCode));
                    break;
				//2:得意先別
				case 2:
                    //明細単位
                    switch (shipmGoodsOdrReport.Detail)
                    {
                        // 品番
                        case 0:
                            strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_CustomerCode));
                            strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_GoodsMakerCd));
                            strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_BLGroupCode));
                            break;
                        // グループコード
                        case 1:
                            strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_CustomerCode));
                            strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_GoodsMakerCd));
                            break;
                    }
                    //strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_CustomerCode)); // DEL 2008/09/24
                    //strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_GoodsMakerCd)); // DEL 2008/09/24
					break;
				//3:担当者別
				case 3:
					strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_EmployeeCode));
					strSortOrder.Append(string.Format("{0},", DCHNB02054EA.ct_Col_GoodsMakerCd));
					break;
			}

            // --- ADD 2008/12/09 -------------------------------->>>>>
            // 昇順か降順か
            string order;

            if (shipmGoodsOdrReport.Order2 == 0)
            {
                order = "DESC";
            }
            else
            {
                order = "ASC";
            }
            // --- ADD 2008/12/09 --------------------------------<<<<<

			//ソート項目
			switch (shipmGoodsOdrReport.SortItem)
			{
                //0:売上数量
                case 0:
                    if (shipmGoodsOdrReport.TotalType != 1)
                    {
                        //strSortOrder.Append(string.Format("{0} DESC", DCHNB02054EA.ct_Col_TotalSalesCountSum)); // DEL 2008/12/09
                        strSortOrder.Append(string.Format("{0} {1}", DCHNB02054EA.ct_Col_TotalSalesCountSum, order)); // ADD 2008/12/09
                    }
                    else
                    {
                        //strSortOrder.Append(string.Format("{0} DESC", DCHNB02054EA.ct_Col_TotalSalesCount)); // DEL 2008/12/09
                        strSortOrder.Append(string.Format("{0} {1}", DCHNB02054EA.ct_Col_TotalSalesCount, order)); // ADD 2008/12/09
                    }
                    break;
                //1:売上回数
                case 1:
                    //strSortOrder.Append(string.Format("{0} DESC", DCHNB02054EA.ct_Col_SalesTimesSum)); // DEL 2008/12/09
                    strSortOrder.Append(string.Format("{0} {1}", DCHNB02054EA.ct_Col_SalesTimesSum, order)); // ADD 2008/12/09
                    break;
                //2:売上金額
                case 2:
                    if (shipmGoodsOdrReport.TotalType != 1)
                    {
                        //strSortOrder.Append(string.Format("{0} DESC", DCHNB02054EA.ct_Col_SalesMoneySum)); // DEL 2008/12/09
                        strSortOrder.Append(string.Format("{0} {1}", DCHNB02054EA.ct_Col_SalesMoneySum, order)); // ADD 2008/12/09
                    }
                    else
                    {
                        //strSortOrder.Append(string.Format("{0} DESC", DCHNB02054EA.ct_Col_TotalSalesMoney)); // DEL 2008/12/09
                        strSortOrder.Append(string.Format("{0} {1}", DCHNB02054EA.ct_Col_TotalSalesMoney, order)); // ADD 2008/12/09
                    }
                    break;
                //3:粗利金額
                case 3:
                    //strSortOrder.Append(string.Format("{0} DESC", DCHNB02054EA.ct_Col_GrossProfit)); // DEL 2008/12/09
                    // --- ADD 2008/12/09 -------------------------------->>>>>
                    if (shipmGoodsOdrReport.TotalType != 1)
                    {
                        // BLコード別以外は、売上金額に粗利金額が設定されている
                        strSortOrder.Append(string.Format("{0} {1}", DCHNB02054EA.ct_Col_SalesMoneySum, order));
                    }
                    else
                    {
                        strSortOrder.Append(string.Format("{0} {1}", DCHNB02054EA.ct_Col_GrossProfit, order));
                    }
                    // --- ADD 2008/12/09 --------------------------------<<<<<
                    break;
                //4:品番（順位無し）
                case 4:
                    switch (shipmGoodsOdrReport.TotalType)
                    {
                        // 商品別
                        case 0:
                            //strSortOrder.Append(string.Format("{0} DESC", DCHNB02054EA.ct_Col_GoodsNo)); // DEL 2008/12/09
                            strSortOrder.Append(string.Format("{0}", DCHNB02054EA.ct_Col_GoodsNo)); // ADD 2008/12/09
                            break;
                        // 得意先別
                        case 2:
                            if (shipmGoodsOdrReport.Detail == 0)
                            {
                                // 品番
                                //strSortOrder.Append(string.Format("{0} DESC", DCHNB02054EA.ct_Col_GoodsNo)); // DEL 2008/12/09
                                strSortOrder.Append(string.Format("{0}", DCHNB02054EA.ct_Col_GoodsNo)); // ADD 2008/12/09
                            }
                            else
                            {
                                // グループコード
                                //strSortOrder.Append(string.Format("{0} DESC", DCHNB02054EA.ct_Col_BLGroupCode)); // DEL 2008/12/09
                                strSortOrder.Append(string.Format("{0}", DCHNB02054EA.ct_Col_BLGroupCode)); // ADD 2008/12/09
                            }
                            break;
                        // 担当者別
                        case 3:
                            //strSortOrder.Append(string.Format("{0} DESC", DCHNB02054EA.ct_Col_BLGoodsCode)); // DEL 2008/12/09
                            strSortOrder.Append(string.Format("{0}", DCHNB02054EA.ct_Col_BLGoodsCode)); // ADD 2008/12/09
                            break;
                    }
                    break;
			}
			return strSortOrder.ToString();
		}
		#endregion

        #region 率取得
        /// <summary>
        /// 率取得処理
        /// </summary>
        /// <param name="numerator">分子</param>
        /// <param name="denominator">分母</param>
        private double GetRatio(double numerator, double denominator)
        {
            double workRate;

            if (denominator == 0)
            {
                workRate = 0.00;
            }
            else
            {
                workRate = (numerator / denominator) * 100;
            }
            //if (workRate < 0) workRate = workRate * -1; // DEL 2009/02/13

            return workRate;
        }
        #endregion

        // --- ADD 2008/10/27 -------------------------------------------->>>>>
        /// <summary>
        /// 終了コード取得処理
        /// </summary>
        /// <param name="value">値</param>
        /// <param name="length">桁数</param>
        /// <returns></returns>
        private int GetEndCode(int value, int length)
        {
            if ((value == 0) || (string.IsNullOrEmpty(value.ToString())))
            {
                return Int32.Parse(new string('9', (length)));
            }
            else
            {
                return value;
            }
        }
        private string GetEndCode(string value, int length)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value.PadLeft(length, '9');
            }
            else
            {
                return value.PadLeft(length, '0');
            }
        }
        // --- ADD 2008/10/27 --------------------------------------------<<<<<

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
		/// <br>Programmer : 96186 kubo</br>
		/// <br>Date       : 2007.09.03</br>
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
							retPrtOutSet = stc_PrtOutSet.Clone();		// 2007.06.27 kubo add
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

        #region ■ testProc

        private int testProc(out object resultParam, ShipmGoodsOdrReportParamWork shipmGoodsOdrReportParamWork)
        {
            ArrayList paramlist = new ArrayList();

            // 最大桁
            ShipmGoodsOdrReportResultWork param1 = new ShipmGoodsOdrReportResultWork();
                        
            param1.AddUpSecCode = "01";
            param1.CompanyName1 = "拠点名称は最大桁１０";
            param1.SupplierCd = 123456;
            param1.SupplierSnm = "仕入先名称は最大２０桁かな４５６７８９０";
            param1.CustomerCode = 12345678;
            param1.CustomerSnm = "得意先名称は最大２０桁かな４５６７８９０";
            param1.EmployeeCode = "1234";
            param1.Name = "従業員名称は最大１０";
            param1.GoodsNo = "111112222233333444445555";
            param1.GoodsName = "1234567890123456";
            param1.BLGoodsCode = 1234;
            param1.BLGoodsHalfName = "0BLｺｰﾄﾞﾊﾊﾝｶｸ20ｹﾀﾃﾞｼﾀ";
            param1.GoodsLGroup = 1234;
            param1.GoodsLGroupName = "商品大分類は最低１０";
            param1.GoodsMGroup = 1234;
            param1.GoodsMGroupName = "商品中分類は最低１０";
            param1.BLGroupCode = 1234;
            param1.BLGroupKanaName = "0BLｸﾞﾙｰﾌﾟｺｰﾄﾞﾊﾊﾝｶｸ20";
            param1.GoodsMakerCd = 1234;
            param1.MakerShortName = "メーカーは最大１０桁";
            param1.TotalSalesCount = 9999999999;
            param1.TotalSalesMoney = 8888888888;
            param1.GrossProfit = 7777777777;
            param1.TotalSalesCount1 = 9999999;
            param1.TotalSalesCount2 = 9999999;
            param1.TotalSalesCount3 = 9999999;
            param1.TotalSalesCount4 = 9999999;
            param1.TotalSalesCount5 = 9999999;
            param1.TotalSalesCount6 = 9999999;
            param1.TotalSalesCount7 = 9999999;
            param1.TotalSalesCount8 = 9999999;
            param1.TotalSalesCount9 = 9999999;
            param1.TotalSalesCount10 = 9999999;
            param1.TotalSalesCount11 = 9999999;
            param1.TotalSalesCount12 = 9999999;
            param1.SalesTimes1 = 8888888;
            param1.SalesTimes2 = 8888888;
            param1.SalesTimes3 = 8888888;
            param1.SalesTimes4 = 8888888;
            param1.SalesTimes5 = 8888888;
            param1.SalesTimes6 = 8888888;
            param1.SalesTimes7 = 8888888;
            param1.SalesTimes8 = 8888888;
            param1.SalesTimes9 = 8888888;
            param1.SalesTimes10 = 8888888;
            param1.SalesTimes11 = 8888888;
            param1.SalesTimes12 = 8888888;
            param1.SalesMoney1 = 7654321;
            param1.SalesMoney2 = 7654321;
            param1.SalesMoney3 = 7654321;
            param1.SalesMoney4 = 7654321;
            param1.SalesMoney5 = 7654321;
            param1.SalesMoney6 = 7654321;
            param1.SalesMoney7 = 7654321;
            param1.SalesMoney8 = 7654321;
            param1.SalesMoney9 = 7654321;
            param1.SalesMoney10 = 7654321;
            param1.SalesMoney11 = 7654321;
            param1.SalesMoney12 = 7654321;

            paramlist.Add(param1);
            

            ShipmGoodsOdrReportResultWork param2 = new ShipmGoodsOdrReportResultWork();

            param2.AddUpSecCode = "01";
            param2.CompanyName1 = "拠点01";
            param2.SupplierCd = 1;
            param2.SupplierSnm = "仕入先1";
            param2.CustomerCode = 1;
            param2.CustomerSnm = "得意先1";
            param2.EmployeeCode = "0001";
            param2.Name = "担当者1";
            param2.GoodsNo = "00000000000000000001";
            param2.GoodsName = "ｼﾅﾊﾞﾝ1";
            param2.BLGoodsCode = 1;
            param2.BLGoodsHalfName = "BLｺｰﾄﾞ1";
            param2.GoodsLGroup = 1;
            param2.GoodsLGroupName = "商品大分類１";
            param2.GoodsMGroup = 1;
            param2.GoodsMGroupName = "商品中分類１";
            param2.BLGroupCode = 1;
            param2.BLGroupKanaName = "BLｸﾞﾙｰﾌﾟｺｰﾄﾞ1";
            param2.GoodsMakerCd = 1;
            param2.MakerShortName = "メーカー１";
            param2.TotalSalesCount = 100;
            param2.TotalSalesMoney = 200;
            param2.GrossProfit = 300;
            param2.TotalSalesCount1 = 10;
            param2.TotalSalesCount2 = 10;
            param2.TotalSalesCount3 = 10;
            param2.TotalSalesCount4 = 10;
            param2.TotalSalesCount5 = 10;
            param2.TotalSalesCount6 = 10;
            param2.TotalSalesCount7 = 10;
            param2.TotalSalesCount8 = 10;
            param2.TotalSalesCount9 = 10;
            param2.TotalSalesCount10 = 10;
            param2.TotalSalesCount11 = 10;
            param2.TotalSalesCount12 = 10;
            param2.SalesTimes1 = 20;
            param2.SalesTimes2 = 20;
            param2.SalesTimes3 = 20;
            param2.SalesTimes4 = 20;
            param2.SalesTimes5 = 20;
            param2.SalesTimes6 = 20;
            param2.SalesTimes7 = 20;
            param2.SalesTimes8 = 20;
            param2.SalesTimes9 = 20;
            param2.SalesTimes10 = 20;
            param2.SalesTimes11 = 20;
            param2.SalesTimes12 = 20;
            param2.SalesMoney1 = 3000000;
            param2.SalesMoney2 = 3000000;
            param2.SalesMoney3 = 3000000;
            param2.SalesMoney4 = 3000000;
            param2.SalesMoney5 = 3000000;
            param2.SalesMoney6 = 3000000;
            param2.SalesMoney7 = 3000000;
            param2.SalesMoney8 = 3000000;
            param2.SalesMoney9 = 3000000;
            param2.SalesMoney10 = 3000000;
            param2.SalesMoney11 = 3000000;
            param2.SalesMoney12 = 3000000;

            paramlist.Add(param2);

            ShipmGoodsOdrReportResultWork param3 = new ShipmGoodsOdrReportResultWork();

            param3.AddUpSecCode = "01";
            param3.CompanyName1 = "拠点01";
            param3.SupplierCd = 1;
            param3.SupplierSnm = "仕入先1";
            param3.CustomerCode = 1;
            param3.CustomerSnm = "得意先1";
            param3.EmployeeCode = "0001";
            param3.Name = "担当者1";
            param3.GoodsNo = "00000000000000000001";
            param3.GoodsName = "ｼﾅﾊﾞﾝ1 BLｺｰﾄﾞ2";
            param3.BLGoodsCode = 2;
            param3.BLGoodsHalfName = "BLｺｰﾄﾞ2";
            param3.GoodsLGroup = 1;
            param3.GoodsLGroupName = "商品大分類１";
            param3.GoodsMGroup = 1;
            param3.GoodsMGroupName = "商品中分類１";
            param3.BLGroupCode = 1;
            param3.BLGroupKanaName = "BLｸﾞﾙｰﾌﾟｺｰﾄﾞ1";
            param3.GoodsMakerCd = 1;
            param3.MakerShortName = "メーカー１";
            param3.TotalSalesCount = 300;
            param3.TotalSalesMoney = 100;
            param3.GrossProfit = 200;
            param3.TotalSalesCount1 = 20;
            param3.TotalSalesCount2 = 20;
            param3.TotalSalesCount3 = 20;
            param3.TotalSalesCount4 = 20;
            param3.TotalSalesCount5 = 20;
            param3.TotalSalesCount6 = 20;
            param3.TotalSalesCount7 = 20;
            param3.TotalSalesCount8 = 20;
            param3.TotalSalesCount9 = 20;
            param3.TotalSalesCount10 = 20;
            param3.TotalSalesCount11 = 20;
            param3.TotalSalesCount12 = 20;
            param3.SalesTimes1 = 20;
            param3.SalesTimes2 = 20;
            param3.SalesTimes3 = 20;
            param3.SalesTimes4 = 20;
            param3.SalesTimes5 = 20;
            param3.SalesTimes6 = 20;
            param3.SalesTimes7 = 20;
            param3.SalesTimes8 = 20;
            param3.SalesTimes9 = 20;
            param3.SalesTimes10 = 20;
            param3.SalesTimes11 = 20;
            param3.SalesTimes12 = 20;
            param3.SalesMoney1 = 10;
            param3.SalesMoney2 = 10;
            param3.SalesMoney3 = 10;
            param3.SalesMoney4 = 10;
            param3.SalesMoney5 = 10;
            param3.SalesMoney6 = 10;
            param3.SalesMoney7 = 10;
            param3.SalesMoney8 = 10;
            param3.SalesMoney9 = 10;
            param3.SalesMoney10 = 10;
            param3.SalesMoney11 = 10;
            param3.SalesMoney12 = 10;

            paramlist.Add(param3);

            resultParam = (object)paramlist;

            return 0;
        }
        #endregion
    }
}

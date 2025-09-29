//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫月報年報
// プログラム概要   : 在庫月報年報で使用するデータを取得する。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30416 長沼 賢二
// 作 成 日  2008/08/06  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/10/10  修正内容 : バグ修正、仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/12/24  修正内容 : バグ修正、仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍　幸史
// 修 正 日  2009/02/02  修正内容 : 障害ID:10911対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30452 上野 俊治
// 修 正 日  2009/02/17  修正内容 : 障害対応11471(当期の設定方を修正)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30452 上野 俊治
// 修 正 日  2009/02/25  修正内容 : 障害対応11905(大分類、中分類、グループコードの開始項目に入力が無い場合の抽出条件を修正)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30452 上野 俊治
// 修 正 日  2009/02/26  修正内容 : 障害対応11994(仕入先コードの取得処理とフィルタ処理を追加)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30452 上野 俊治
// 修 正 日  2009/02/27  修正内容 : 障害対応11994(仕入先コードの取得処理とフィルタ処理を修正)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/24  修正内容 : 不具合対応[12679]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/27  修正内容 : 不具合対応[12802]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/31  修正内容 : 不具合対応[12873]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/04/02  修正内容 : 不具合対応[13025]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/06/03  修正内容 : 不具合対応[12679]　数値のまるめはActiveReportにゆだねる
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/06/12  修正内容 : 不具合対応[13448]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 長内 数馬
// 修 正 日  2010/05/07  修正内容 : 不要な処理を削除
//----------------------------------------------------------------------------//
// 管理番号  11175324-00 作成担当 : 凌偉志
// 修 正 日  2015/09/08  修正内容 : Redmine#47299 MKアシスト　在庫月報年報 回転率の計算不正の対応。
//----------------------------------------------------------------------------//
// 管理番号  11175324-00 作成担当 : 李侠
// 修 正 日  2015/10/08  修正内容 : Redmine#47391の#16 MKアシスト 在庫月報年報マークの判定が不正の障害対応。
//----------------------------------------------------------------------------//

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
    /// 在庫月報年報アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 在庫月報年報で使用するデータを取得する。</br>
    /// <br>Programmer   : 30416 長沼 賢二</br>
    /// <br>Date         : 2008.08.06</br>
	/// <br>Updatenote   : 2008/10/10 照田 貴志　バグ修正、仕様変更対応</br>
    /// <br>               2008/12/24 照田 貴志　バグ修正、仕様変更対応</br>
    /// <br>Updatenote   : 2009/02/02 忍　幸史　障害ID:10911対応</br>
    /// <br>Update Note  : 2009.02.17 30452 上野 俊治</br>
    /// <br>              ・障害対応11471(当期の設定方を修正)</br>
    /// <br>Update Note  : 2009/02/25 30452 上野 俊治</br>
    /// <br>              ・障害対応11905(大分類、中分類、グループコードの開始項目に入力が無い場合の抽出条件を修正)</br>
    /// <br>Update Note  : 2009/02/26 30452 上野 俊治</br>
    /// <br>              ・障害対応11994(仕入先コードの取得処理とフィルタ処理を追加)</br>
    /// <br>Update Note  : 2009/02/27 30452 上野 俊治</br>
    /// <br>              ・障害対応11994(仕入先コードの取得処理とフィルタ処理を修正)</br>
    /// <br>             : 2009/03/24       照田 貴志　不具合対応[12679]</br>
    /// <br>             : 2009/03/27       照田 貴志　不具合対応[12802]</br>
    /// <br>             : 2009/03/31       照田 貴志　不具合対応[12873]</br>
    /// <br>             : 2009/04/02       照田 貴志　不具合対応[13025]</br>
    /// <br>             : 2009/06/03       照田 貴志　不具合対応[12679]　数値のまるめはActiveReportにゆだねる</br>
    /// <br>             : 2009/06/12       照田 貴志　不具合対応[13448]</br>
    /// <br>             : 2010/05/07       長内 数馬　不要な処理を削除</br>
    /// <br>Update Note  : 2015/09/08 凌偉志</br>
    /// <br>管理番号     : 11175324-00</br>
    /// <br>               Redmine#47299 MKアシスト 在庫月報年報回転率の計算が不正の障害対応</br>
    /// <br>Update Note　: 2015/10/08 李侠</br>
    /// <br>管理番号   　: 11175324-00</br>
    /// <br>             　Redmine#47391の#16 MKアシスト 在庫月報年報マークの判定が不正の障害対応</br>
    /// </remarks>
	public class StockMonthYearReportAcs
	{
		#region ■ Constructor
		/// <summary>
		/// 在庫月報年報アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 在庫月報年報アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.08.06</br>
		/// </remarks>
		public StockMonthYearReportAcs()
		{
            this._iStockMonthYearReportDataWorkDB = (IStockMonthYearReportDataWorkDB)MediationStockMonthYearReportDataWorkDB.GetStockMonthYearReportDataWorkDB();

            this._dateGetAcs = DateGetAcs.GetInstance();        //ADD 2008/10/10
		}

		/// <summary>
        /// 在庫月報年報アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 在庫月報年報アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.08.06</br>
		/// </remarks>
        static StockMonthYearReportAcs()
		{
			stc_Employee		= null;
			stc_PrtOutSet		= null;					// 帳票出力設定データクラス
			stc_PrtOutSetAcs	= new PrtOutSetAcs();	// 帳票出力設定アクセスクラス

            stc_SecInfoAcs = new SecInfoAcs(1);         // 拠点アクセスクラス
            stc_SectionDic = new Dictionary<string, SecInfoSet>();  // 拠点Dictionary
            stc_GoodsAcs = new GoodsAcs();              // 商品アクセスクラス
            
            Employee loginWorker = null;
            string ownSectionCode = "";
            string msg;

            if (LoginInfoAcquisition.Employee != null)
            {
                loginWorker = LoginInfoAcquisition.Employee.Clone();
                ownSectionCode = loginWorker.BelongSectionCode;
            }

            stc_GoodsAcs.SearchInitial(LoginInfoAcquisition.EnterpriseCode, ownSectionCode, out msg);

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

		#region ■ Static Member
		private static Employee stc_Employee;
		private static PrtOutSet stc_PrtOutSet;			                // 帳票出力設定データクラス
		private static PrtOutSetAcs stc_PrtOutSetAcs;	                // 帳票出力設定アクセスクラス
        private static SecInfoAcs stc_SecInfoAcs;                       // 拠点アクセスクラス
        private static Dictionary<string, SecInfoSet> stc_SectionDic;   // 拠点Dictionary
        private static GoodsAcs stc_GoodsAcs;                           // 商品アクセスクラス
		#endregion ■ Static Member

		#region ■ Private Member
        IStockMonthYearReportDataWorkDB _iStockMonthYearReportDataWorkDB;

        private DateGetAcs _dateGetAcs;

        private DataTable _stockNoShipmentListDt;			// 印刷DataTable
		private DataView _stockNoShipmentListDataView;	    // 印刷DataView

		#endregion ■ Private Member

		#region ■ Public Property
		/// <summary>
		/// 印刷データセット(読み取り専用)
		/// </summary>
		public DataView StockNoShipmentListDataView
		{
			get{ return this._stockNoShipmentListDataView; }
		}
		#endregion ■ Public Property

		#region ■ Public Method
		#region ◆ 出力データ取得
		#region ◎ 入金データ取得
		/// <summary>
		/// データ取得
		/// </summary>
        /// <param name="stockMonthYearReportCndtn">抽出条件</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷するデータを取得する。</br>
	    /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.08.06</br>
		/// </remarks>
        public int SearchMain(StockMonthYearReportCndtn stockMonthYearReportCndtn, out string errMsg)
		{
            return this.SearchProc(stockMonthYearReportCndtn, out errMsg);
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
		/// <param name="stockNoShipmentListCndtn"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する在庫移動データを取得する。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.08.06</br>
		/// </remarks>
        private int SearchProc(StockMonthYearReportCndtn stockNoShipmentListCndtn, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

			try
			{
				// DataTable Create ----------------------------------------------------------
                PMZAI02014EA.CreateDataTable(ref this._stockNoShipmentListDt);

                StockMonthYearReportWork stockMonthYearReportWork = new StockMonthYearReportWork();
				// 抽出条件展開  --------------------------------------------------------------
                status = this.DevStockMoveCndtn(stockNoShipmentListCndtn, out stockMonthYearReportWork, out errMsg);
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

				// データ取得  ----------------------------------------------------------------
				object retStockMoveList = null;

                status = this._iStockMonthYearReportDataWorkDB.Search(out retStockMoveList, stockMonthYearReportWork, 0, ConstantManagement.LogicalMode.GetData0);
                //--- TEST --------->>>>>
                //retStockMoveList = this.GetTestData();
                //status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //--- TEST ---------<<<<<

                switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						// データ展開処理
						DevStockMoveData( stockNoShipmentListCndtn, (ArrayList)retStockMoveList );
						//status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;       //DEL 2008/10/06 0件でも帳票が出力される為
                        // --- ADD 2008/10/06 ------------------------------------------------------------------------------------>>>>>
                        if (this._stockNoShipmentListDataView.Count == 0)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        // --- ADD 2008/10/06 ------------------------------------------------------------------------------------<<<<<
                        break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
					default:
						errMsg = "在庫履歴データの取得に失敗しました。";
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

        # region テスト用

        private object GetTestData()
        {
            ArrayList list = new ArrayList();

            StockMonthYearReportDataWork work = new StockMonthYearReportDataWork();

            work.WarehouseCode      = "0001";		// 倉庫コード
            work.WarehouseName      = "倉庫１";		// 倉庫名称
            work.StockSupplierCode  = 11;		    // 在庫発注先コード
            work.SupplierSnm        = "仕入先11";   // 仕入先略称
            work.GoodsNo            = "22";		    // 商品番号
            work.GoodsName          = "品名22";		// 商品名称
            work.WarehouseShelfNo   = "33";		    // 倉庫棚番
            work.LMonthStockCnt     = 111;		    // 前月末在庫数
            work.StockCount         = 44;		    // 仕入数
            work.MoveArrivalCnt     = 55;		    // 移動入荷数
            work.TotalArrivalCnt    = 66;		    // 総入荷数
            work.SalesCount         = 222;	    	// 売上数
            work.MoveShipmentCnt    = 77;			// 移動出荷数
            work.TotalShipmentCnt   = 333;          // 総出荷数
            work.MaximumStockCnt    = 444;          // 最高在庫数
            work.MinimumStockCnt    = 1;            // 最低在庫数
            work.SalesCost          = 11111;        // 原価
            work.LMonthStockPrice   = 2;            // 前月末在庫額
            work.StockPriceTaxExc   = 1111;         // 仕入金額(税抜き)
            work.MoveArrivalPrice   = 2222;         // 移動入荷額
            work.TotalArrivalPrice  = 11111;        // 総入荷金額
            work.SalesMoneyTaxExc   = 3333;         // 売上金額(税抜き)
            work.MoveShipmentPrice  = 4444;         // 移動出荷額
            work.TotalShipmentPrice = 5555;         // 総出荷金額
            work.GrossProfit        = 6666;         // 粗利金額
            work.GrossProfitRate    = 7777;         // 粗利率
            work.StockTotal         = 8888;         // 在庫総数
            work.StockMashinePrice  = 9099;         // マシン在庫額
            work.BLGoodsCode        = 9000;         // BLコード

            list.Add(work);

            StockMonthYearReportDataWork work1 = new StockMonthYearReportDataWork();

            work1.WarehouseCode = "0002";		// 倉庫コード
            work1.WarehouseName = "倉庫２";		// 倉庫名称
            work1.StockSupplierCode = 12;		// 在庫発注先コード
            work1.SupplierSnm = "仕入先12";		// 仕入先略称
            work1.GoodsNo = "23";		        // 商品番号
            work1.GoodsName = "品名23";		    // 商品名称
            work1.WarehouseShelfNo = "34";		// 倉庫棚番
            work1.LMonthStockCnt = 111;		    // 前月末在庫数
            work1.StockCount = 44;		        // 仕入数
            work1.MoveArrivalCnt = 55;		    // 移動入荷数
            work1.TotalArrivalCnt = 66;		    // 総入荷数
            work1.SalesCount = 222;	    	    // 売上数
            work1.MoveShipmentCnt = 77;			// 移動出荷数
            work1.TotalShipmentCnt = 333;       // 総出荷数
            work1.MaximumStockCnt = 444;        // 最高在庫数
            work1.MinimumStockCnt = 1;          // 最低在庫数
            work1.SalesCost = 11111;            // 原価
            work1.LMonthStockPrice = 2;         // 前月末在庫額
            work1.StockPriceTaxExc = 1111;      // 仕入金額(税抜き)
            work1.MoveArrivalPrice = 2222;      // 移動入荷額
            work1.TotalArrivalPrice = 11111;    // 総入荷金額
            work1.SalesMoneyTaxExc = 3333;      // 売上金額(税抜き)
            work1.MoveShipmentPrice = 4444;     // 移動出荷額
            work1.TotalShipmentPrice = 5555;    // 総出荷金額
            work1.GrossProfit = 6666;           // 粗利金額
            work1.GrossProfitRate = 7777;       // 粗利率
            work1.StockTotal = 8888;            // 在庫総数
            work1.StockMashinePrice = 9099;     // マシン在庫額
            work1.BLGoodsCode = 9000;           // BLコード

            list.Add(work1);

            //StockMonthYearReportDataWork work2 = new StockMonthYearReportDataWork();

            //list.Add(work2);


            //StockMonthYearReportDataWork work3 = new StockMonthYearReportDataWork();

            //list.Add(work3);


            //StockAdjustResultWork work4 = new StockAdjustResultWork();

            //work4.SectionCode = "01";				// 拠点コード
            //work4.SectionGuideNm = "拠点01";		// 拠点ガイド名称
            //work4.AcPaySlipCd = 0;					// 受払元伝票区分 10:仕入,11:受託,12:受計上,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,50:棚卸
            //work4.AcPayTransCd = 0;					// 受払元取引区分 10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消
            //work4.AdjustDate = TDateTime.LongDateToDateTime(20070314);		// 調整日付
            //work4.StockAdjustSlipNo = 4000;			// 在庫調整伝票番号
            //work4.StockAdjustRowNo = 4;				// 在庫調整行番号
            ////work4.MakerCode = 30;					// メーカーコード
            //work4.MakerName = "ソニー";				// メーカー名称
            ////work4.GoodsCode = "50";					// 商品コード
            //work4.GoodsName = "SO901_レッド";		// 商品名称
            ////work4.ProductNumber = "S100000100";		// 製造番号
            ////work4.BfProductNumber = "S10000000";	// 変更前製造番号
            ////work4.StockTelNo1 = "090-4568-1000";	// 商品電話番号1
            ////work4.BfStockTelNo1 = "090-5555-1111";	// 変更前商品電話番号1
            //work4.InputAgenCd = "30";				// 入力担当者コード
            //work4.InputAgenNm = "福岡 太郎";		// 入力担当者名称
            //work4.StockUnitPriceFl = 45000;			// 仕入単価
            //work4.BfStockUnitPriceFl = 35000;		// 変更前仕入単価
            //work4.DtlNote = "明細備考・・・・";		// 明細備考
            //work4.AdjustCount = -1.0;				// 調整数
            //work4.SlipNote = "伝票備考・・・・";	// 伝票備考
            ////work4.StockTelNo2 = "";					// 商品電話番号2
            ////work4.BfStockTelNo2 = "";				// 変更前商品電話番号2
            ////work4.PrdNumMngDiv = 1;					// 製番管理区分 0:無,1:有
            //work4.SupplierStock = 1.0;				// 仕入在庫数
            //work4.TrustCount = 0.0;					// 受託数
            ////work4.StockState = 0;					// 在庫状態 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
            ////work4.BfStockState = 10;				// 変更前在庫状態
            //work4.StockDiv = 0;						// 在庫区分 0:自社、1:受託
            ////work4.GoodsCodeStatus = 0;				// 商品状態 0:正常,1:不良品
            //work4.WarehouseCode = "0001";
            //work4.WarehouseName = "倉庫01";

            //list.Add(work4);

            //StockAdjustResultWork work5 = new StockAdjustResultWork();

            //work5.SectionCode = "01";				// 拠点コード
            //work5.SectionGuideNm = "拠点01";		// 拠点ガイド名称
            //work5.AcPaySlipCd = 0;					// 受払元伝票区分 10:仕入,11:受託,12:受計上,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,50:棚卸
            //work5.AcPayTransCd = 0;					// 受払元取引区分 10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消
            //work5.AdjustDate = TDateTime.LongDateToDateTime(20070314);		// 調整日付
            //work5.StockAdjustSlipNo = 4000;			// 在庫調整伝票番号
            //work5.StockAdjustRowNo = 0;				// 在庫調整行番号
            ////work5.MakerCode = 30;					// メーカーコード
            //work5.MakerName = "ソニー";				// メーカー名称
            ////work5.GoodsCode = "50";					// 商品コード
            //work5.GoodsName = "SO901_レッド";		// 商品名称
            ////work5.ProductNumber = "S100000100";		// 製造番号
            ////work5.BfProductNumber = "S10000000";	// 変更前製造番号
            ////work5.StockTelNo1 = "090-4568-1000";	// 商品電話番号1
            ////work5.BfStockTelNo1 = "090-5555-1111";	// 変更前商品電話番号1
            //work5.InputAgenCd = "30";				// 入力担当者コード
            //work5.InputAgenNm = "福岡 太郎";		// 入力担当者名称
            //work5.StockUnitPriceFl = 45000;			// 仕入単価
            //work5.BfStockUnitPriceFl = 35000;		// 変更前仕入単価
            //work5.DtlNote = "明細備考・・・・";		// 明細備考
            //work5.AdjustCount = -1.0;				// 調整数
            //work5.SlipNote = "伝票備考・・・・";	// 伝票備考
            ////work5.StockTelNo2 = "";					// 商品電話番号2
            ////work5.BfStockTelNo2 = "";				// 変更前商品電話番号2
            ////work5.PrdNumMngDiv = 1;					// 製番管理区分 0:無,1:有
            //work5.SupplierStock = 1.0;				// 仕入在庫数
            //work5.TrustCount = 0.0;					// 受託数
            ////work5.StockState = 0;					// 在庫状態 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
            ////work5.BfStockState = 10;				// 変更前在庫状態
            //work5.StockDiv = 0;						// 在庫区分 0:自社、1:受託
            ////work5.GoodsCodeStatus = 0;				// 商品状態 0:正常,1:不良品
            //work5.WarehouseCode = "0001";
            //work5.WarehouseName = "倉庫01";

            //list.Add(work5);

            //StockAdjustResultWork work6 = new StockAdjustResultWork();

            //work6.SectionCode = "03";				// 拠点コード
            //work6.SectionGuideNm = "拠点03";		// 拠点ガイド名称
            //work6.AcPaySlipCd = 0;					// 受払元伝票区分 10:仕入,11:受託,12:受計上,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,50:棚卸
            //work6.AcPayTransCd = 0;					// 受払元取引区分 10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消
            //work6.AdjustDate = TDateTime.LongDateToDateTime(20070314);		// 調整日付
            //work6.StockAdjustSlipNo = 3000;			// 在庫調整伝票番号
            //work6.StockAdjustRowNo = 0;				// 在庫調整行番号
            ////work6.MakerCode = 30;					// メーカーコード
            //work6.MakerName = "ソニー";				// メーカー名称
            ////work6.GoodsCode = "50";					// 商品コード
            //work6.GoodsName = "SO901_レッド";		// 商品名称
            ////work6.ProductNumber = "S100000100";		// 製造番号
            ////work6.BfProductNumber = "S10000000";	// 変更前製造番号
            ////work6.StockTelNo1 = "090-4568-1000";	// 商品電話番号1
            ////work6.BfStockTelNo1 = "090-5555-1111";	// 変更前商品電話番号1
            //work6.InputAgenCd = "30";				// 入力担当者コード
            //work6.InputAgenNm = "福岡 太郎";		// 入力担当者名称
            //work6.StockUnitPriceFl = 45000;			// 仕入単価
            //work6.BfStockUnitPriceFl = 35000;		// 変更前仕入単価
            //work6.DtlNote = "明細備考・・・・";		// 明細備考
            //work6.AdjustCount = -1.0;				// 調整数
            //work6.SlipNote = "";					// 伝票備考
            ////work6.StockTelNo2 = "";					// 商品電話番号2
            ////work6.BfStockTelNo2 = "";				// 変更前商品電話番号2
            ////work6.PrdNumMngDiv = 1;					// 製番管理区分 0:無,1:有
            //work6.SupplierStock = 1.0;				// 仕入在庫数
            //work6.TrustCount = 0.0;					// 受託数
            ////work6.StockState = 0;					// 在庫状態 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
            ////work6.BfStockState = 10;				// 変更前在庫状態
            //work6.StockDiv = 0;						// 在庫区分 0:自社、1:受託
            ////work6.GoodsCodeStatus = 0;				// 商品状態 0:正常,1:不良品
            //work6.WarehouseCode = "0001";
            //work6.WarehouseName = "倉庫01";

            //list.Add(work6);

            //StockAdjustResultWork work7 = new StockAdjustResultWork();

            //work7.SectionCode = "03";				// 拠点コード
            //work7.SectionGuideNm = "拠点03";		// 拠点ガイド名称
            //work7.AcPaySlipCd = 0;					// 受払元伝票区分 10:仕入,11:受託,12:受計上,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,50:棚卸
            //work7.AcPayTransCd = 0;					// 受払元取引区分 10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消
            //work7.AdjustDate = TDateTime.LongDateToDateTime(20070316);		// 調整日付
            //work7.StockAdjustSlipNo = 4000;			// 在庫調整伝票番号
            //work7.StockAdjustRowNo = 0;				// 在庫調整行番号
            ////work7.MakerCode = 10;					// メーカーコード
            //work7.MakerName = "パナソニック";		// メーカー名称
            ////work7.GoodsCode = "20";					// 商品コード
            //work7.GoodsName = "P901_ブルー";		// 商品名称
            ////work7.ProductNumber = "P100000005";		// 製造番号
            ////work7.BfProductNumber = "P10000000";	// 変更前製造番号
            ////work7.StockTelNo1 = "090-8919-0000";	// 商品電話番号1
            ////work7.BfStockTelNo1 = "090-1111-2222";	// 変更前商品電話番号1
            //work7.InputAgenCd = "30";				// 入力担当者コード
            //work7.InputAgenNm = "福岡 太郎";		// 入力担当者名称
            //work7.StockUnitPriceFl = 45000;			// 仕入単価
            //work7.BfStockUnitPriceFl = 35000;		// 変更前仕入単価
            //work7.DtlNote = "明細備考・・・・";		// 明細備考
            //work7.AdjustCount = -1.0;				// 調整数
            //work7.SlipNote = "";					// 伝票備考
            ////work7.StockTelNo2 = "";					// 商品電話番号2
            ////work7.BfStockTelNo2 = "";				// 変更前商品電話番号2
            ////work7.PrdNumMngDiv = 1;					// 製番管理区分 0:無,1:有
            //work7.SupplierStock = 1.0;				// 仕入在庫数
            //work7.TrustCount = 0.0;					// 受託数
            ////work7.StockState = 0;					// 在庫状態 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
            ////work7.BfStockState = 10;				// 変更前在庫状態
            //work7.StockDiv = 0;						// 在庫区分 0:自社、1:受託
            ////work7.GoodsCodeStatus = 0;				// 商品状態 0:正常,1:不良品
            //work7.WarehouseCode = "0001";
            //work7.WarehouseName = "倉庫01";

            //list.Add(work7);

            //StockAdjustResultWork work8 = new StockAdjustResultWork();

            //work8.SectionCode = "03";				// 拠点コード
            //work8.SectionGuideNm = "拠点03";		// 拠点ガイド名称
            //work8.AcPaySlipCd = 0;					// 受払元伝票区分 10:仕入,11:受託,12:受計上,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,50:棚卸
            //work8.AcPayTransCd = 0;					// 受払元取引区分 10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消
            //work8.AdjustDate = TDateTime.LongDateToDateTime(20070316);		// 調整日付
            //work8.StockAdjustSlipNo = 4000;			// 在庫調整伝票番号
            //work8.StockAdjustRowNo = 1;				// 在庫調整行番号
            ////work8.MakerCode = 10;					// メーカーコード
            //work8.MakerName = "パナソニック";		// メーカー名称
            ////work8.GoodsCode = "20";					// 商品コード
            //work8.GoodsName = "P901_ブルー";		// 商品名称
            ////work8.ProductNumber = "P100000100";		// 製造番号
            ////work8.BfProductNumber = "P10000000";	// 変更前製造番号
            ////work8.StockTelNo1 = "090-8919-1000";	// 商品電話番号1
            ////work8.BfStockTelNo1 = "090-1111-3333";	// 変更前商品電話番号1
            //work8.InputAgenCd = "30";				// 入力担当者コード
            //work8.InputAgenNm = "福岡 太郎";		// 入力担当者名称
            //work8.StockUnitPriceFl = 45000;			// 仕入単価
            //work8.BfStockUnitPriceFl = 35000;		// 変更前仕入単価
            //work8.DtlNote = "明細備考・・・・";		// 明細備考
            //work8.AdjustCount = -1.0;				// 調整数
            //work8.SlipNote = "伝票備考・・・・";	// 伝票備考
            ////work8.StockTelNo2 = "";					// 商品電話番号2
            ////work8.BfStockTelNo2 = "";				// 変更前商品電話番号2
            ////work8.PrdNumMngDiv = 1;					// 製番管理区分 0:無,1:有
            //work8.SupplierStock = 1.0;				// 仕入在庫数
            //work8.TrustCount = 0.0;					// 受託数
            ////work8.StockState = 0;					// 在庫状態 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
            ////work8.BfStockState = 10;				// 変更前在庫状態
            //work8.StockDiv = 0;						// 在庫区分 0:自社、1:受託
            ////work8.GoodsCodeStatus = 0;				// 商品状態 0:正常,1:不良品
            //work8.WarehouseCode = "0001";
            //work8.WarehouseName = "倉庫01";

            //list.Add(work8);

            //StockAdjustResultWork work9 = new StockAdjustResultWork();

            //work9.SectionCode = "03";				// 拠点コード
            //work9.SectionGuideNm = "拠点03";		// 拠点ガイド名称
            //work9.AcPaySlipCd = 0;					// 受払元伝票区分 10:仕入,11:受託,12:受計上,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,50:棚卸
            //work9.AcPayTransCd = 0;					// 受払元取引区分 10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消
            //work9.AdjustDate = TDateTime.LongDateToDateTime(20070316);		// 調整日付
            //work9.StockAdjustSlipNo = 4000;			// 在庫調整伝票番号
            //work9.StockAdjustRowNo = 2;				// 在庫調整行番号
            ////work9.MakerCode = 20;					// メーカーコード
            //work9.MakerName = "富士通";				// メーカー名称
            ////work9.GoodsCode = "30";					// 商品コード
            //work9.GoodsName = "F901_レッド";		// 商品名称
            ////work9.ProductNumber = "F100000100";		// 製造番号
            ////work9.BfProductNumber = "F10000000";	// 変更前製造番号
            ////work9.StockTelNo1 = "090-6534-1000";	// 商品電話番号1
            ////work9.BfStockTelNo1 = "090-8888-1111";	// 変更前商品電話番号1
            //work9.InputAgenCd = "30";				// 入力担当者コード
            //work9.InputAgenNm = "福岡 太郎";		// 入力担当者名称
            //work9.StockUnitPriceFl = 45000;			// 仕入単価
            //work9.BfStockUnitPriceFl = 35000;		// 変更前仕入単価
            //work9.DtlNote = "明細備考・・・・";		// 明細備考
            //work9.AdjustCount = -1.0;				// 調整数
            //work9.SlipNote = "伝票備考・・・・";	// 伝票備考
            ////work9.StockTelNo2 = "";					// 商品電話番号2
            ////work9.BfStockTelNo2 = "";				// 変更前商品電話番号2
            ////work9.PrdNumMngDiv = 1;					// 製番管理区分 0:無,1:有
            //work9.SupplierStock = 1.0;				// 仕入在庫数
            //work9.TrustCount = 0.0;					// 受託数
            ////work9.StockState = 0;					// 在庫状態 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
            ////work9.BfStockState = 10;				// 変更前在庫状態
            //work9.StockDiv = 0;						// 在庫区分 0:自社、1:受託
            ////work9.GoodsCodeStatus = 0;				// 商品状態 0:正常,1:不良品
            //work9.WarehouseCode = "0002";
            //work9.WarehouseName = "倉庫02";

            //list.Add(work9);

            //StockAdjustResultWork work10 = new StockAdjustResultWork();

            //work10.SectionCode = "03";				// 拠点コード
            //work10.SectionGuideNm = "拠点03";		// 拠点ガイド名称
            //work10.AcPaySlipCd = 0;					// 受払元伝票区分 10:仕入,11:受託,12:受計上,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,50:棚卸
            //work10.AcPayTransCd = 0;				// 受払元取引区分 10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消
            //work10.AdjustDate = TDateTime.LongDateToDateTime(20070316);		// 調整日付
            //work10.StockAdjustSlipNo = 4000;		// 在庫調整伝票番号
            //work10.StockAdjustRowNo = 3;			// 在庫調整行番号
            ////work10.MakerCode = 30;					// メーカーコード
            //work10.MakerName = "ソニー";			// メーカー名称
            ////work10.GoodsCode = "50";				// 商品コード
            //work10.GoodsName = "SO901_レッド";		// 商品名称
            ////work10.ProductNumber = "S100000100";	// 製造番号
            ////work10.BfProductNumber = "S10000000";	// 変更前製造番号
            ////work10.StockTelNo1 = "090-4568-1000";	// 商品電話番号1
            ////work10.BfStockTelNo1 = "090-5555-1111";	// 変更前商品電話番号1
            //work10.InputAgenCd = "30";				// 入力担当者コード
            //work10.InputAgenNm = "福岡 太郎";		// 入力担当者名称
            //work10.StockUnitPriceFl = 45000;		// 仕入単価
            //work10.BfStockUnitPriceFl = 35000;		// 変更前仕入単価
            //work10.DtlNote = "明細備考・・・・";	// 明細備考
            //work10.AdjustCount = -1.0;				// 調整数
            //work10.SlipNote = "伝票備考・・・・";	// 伝票備考
            ////work10.StockTelNo2 = "";				// 商品電話番号2
            ////work10.BfStockTelNo2 = "";				// 変更前商品電話番号2
            ////work10.PrdNumMngDiv = 1;				// 製番管理区分 0:無,1:有
            //work10.SupplierStock = 1.0;				// 仕入在庫数
            //work10.TrustCount = 0.0;				// 受託数
            ////work10.StockState = 0;					// 在庫状態 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
            ////work10.BfStockState = 10;				// 変更前在庫状態
            //work10.StockDiv = 0;					// 在庫区分 0:自社、1:受託
            ////work10.GoodsCodeStatus = 0;				// 商品状態 0:正常,1:不良品
            //work10.WarehouseCode = "0002";
            //work10.WarehouseName = "倉庫02";

            //list.Add(work10);

            //StockAdjustResultWork work11 = new StockAdjustResultWork();

            //work11.SectionCode = "03";				// 拠点コード
            //work11.SectionGuideNm = "拠点03";		// 拠点ガイド名称
            //work11.AcPaySlipCd = 0;					// 受払元伝票区分 10:仕入,11:受託,12:受計上,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,50:棚卸
            //work11.AcPayTransCd = 0;				// 受払元取引区分 10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消
            //work11.AdjustDate = TDateTime.LongDateToDateTime(20070315);		// 調整日付
            //work11.StockAdjustSlipNo = 5000;		// 在庫調整伝票番号
            //work11.StockAdjustRowNo = 0;			// 在庫調整行番号
            ////work11.MakerCode = 30;					// メーカーコード
            //work11.MakerName = "ソニー";			// メーカー名称
            ////work11.GoodsCode = "50";				// 商品コード
            //work11.GoodsName = "SO901_レッド";		// 商品名称
            ////work11.ProductNumber = "S100000100";	// 製造番号
            ////work11.BfProductNumber = "S10000000";	// 変更前製造番号
            ////work11.StockTelNo1 = "090-4568-1000";	// 商品電話番号1
            ////work11.BfStockTelNo1 = "090-5555-1111";	// 変更前商品電話番号1
            //work11.InputAgenCd = "30";				// 入力担当者コード
            //work11.InputAgenNm = "福岡 太郎";		// 入力担当者名称
            //work11.StockUnitPriceFl = 45000;		// 仕入単価
            //work11.BfStockUnitPriceFl = 35000;		// 変更前仕入単価
            //work11.DtlNote = "明細備考・・・・";	// 明細備考
            //work11.AdjustCount = -1.0;				// 調整数
            //work11.SlipNote = "伝票備考・・・・";	// 伝票備考
            ////work11.StockTelNo2 = "";				// 商品電話番号2
            ////work11.BfStockTelNo2 = "";				// 変更前商品電話番号2
            ////work11.PrdNumMngDiv = 1;				// 製番管理区分 0:無,1:有
            //work11.SupplierStock = 1.0;				// 仕入在庫数
            //work11.TrustCount = 0.0;				// 受託数
            ////work11.StockState = 0;					// 在庫状態 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
            ////work11.BfStockState = 10;				// 変更前在庫状態
            //work11.StockDiv = 0;					// 在庫区分 0:自社、1:受託
            ////work11.GoodsCodeStatus = 0;				// 商品状態 0:正常,1:不良品
            //work11.WarehouseCode = "0002";
            //work11.WarehouseName = "倉庫02";

            //list.Add(work11);

            return (object)list;
        }

        # endregion

		#region ◆ データ展開処理
		#region ◎ 抽出条件展開処理
		/// <summary>
		/// 抽出条件展開処理
		/// </summary>
        /// <param name="stockMonthYearReportCndtn">UI抽出条件クラス</param>
        /// <param name="stockMonthYearReportWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
        private int DevStockMoveCndtn(StockMonthYearReportCndtn stockMonthYearReportCndtn, out StockMonthYearReportWork stockMonthYearReportWork, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;
            stockMonthYearReportWork = new StockMonthYearReportWork();
			try
			{
                stockMonthYearReportWork.EnterpriseCode = stockMonthYearReportCndtn.EnterpriseCode;  // 企業コード
				// 抽出条件パラメータセット
                if (stockMonthYearReportCndtn.SectionCodes.Length != 0)
				{
                    if (stockMonthYearReportCndtn.IsSelectAllSection)
				    {
				        // 全社の時
                        stockMonthYearReportWork.SectionCodes = null;
				    }
				    else
				    {
                        stockMonthYearReportWork.SectionCodes = stockMonthYearReportCndtn.SectionCodes;
				    }
				}
				else
				{
                    stockMonthYearReportWork.SectionCodes = null;
				}

                stockMonthYearReportWork.EnterpriseCode = stockMonthYearReportCndtn.EnterpriseCode;                     // 企業コード
                stockMonthYearReportWork.SectionCodes = stockMonthYearReportCndtn.SectionCodes;                         // 拠点コード
                //stockMonthYearReportWork.St_AddUpYearMonth = stockMonthYearReportCndtn.St_AddUpYearMonth;               // 開始年月度     //DEL 2008/10/10 帳票の条件には画面の入力値を印字する為
                // --- ADD 2008/10/10 ----------------------------------------------------------------------------------------------------------------->>>>>
                // 開始年月度
                if (stockMonthYearReportCndtn.PrintType == StockMonthYearReportCndtn.PrintTypeState.ThisMonth)
                {
                    // 発行タイプ：当月
                    stockMonthYearReportWork.St_AddUpYearMonth = stockMonthYearReportCndtn.St_AddUpYearMonth;
                }
                else
                {
                    // --- DEL 2009/02/17 -------------------------------->>>>>
                    //// 発行タイプ：当期
                    //int year;
                    //List<DateTime> startMonthDate;
                    //List<DateTime> endMonthDate;
                    //List<DateTime> yearMonth;

                    //this._dateGetAcs.GetFinancialYearTable(0, out startMonthDate, out endMonthDate, out yearMonth, out year);
                    //stockMonthYearReportWork.St_AddUpYearMonth = startMonthDate[0];
                    // --- DEL 2009/02/17 --------------------------------<<<<<
                    // --- ADD 2009/02/17 -------------------------------->>>>>
                    int year;
                    int addYears;
                    DateTime stYMonth;
                    DateTime edYMonth;
                    this._dateGetAcs.GetYearFromMonth(stockMonthYearReportCndtn.Ed_AddUpYearMonth, out year, out addYears, out stYMonth, out edYMonth);

                    stockMonthYearReportWork.St_AddUpYearMonth = stYMonth;
                    // --- ADD 2009/02/17 --------------------------------<<<<<
                }
                // --- ADD 2008/10/10 -----------------------------------------------------------------------------------------------------------------<<<<<
                stockMonthYearReportWork.Ed_AddUpYearMonth = stockMonthYearReportCndtn.Ed_AddUpYearMonth;               // 終了年月度
                stockMonthYearReportWork.PartsManagementDivide1 = stockMonthYearReportCndtn.PartsManagementDivide1;     // 部品管理区分１
                stockMonthYearReportWork.PartsManagementDivide2 = stockMonthYearReportCndtn.PartsManagementDivide2;     // 部品管理区分２
                stockMonthYearReportWork.St_WarehouseCode = stockMonthYearReportCndtn.St_WarehouseCode;                 // 開始倉庫コード
                stockMonthYearReportWork.Ed_WarehouseCode = stockMonthYearReportCndtn.Ed_WarehouseCode;                 // 終了倉庫コード
                stockMonthYearReportWork.St_SupplierCd = stockMonthYearReportCndtn.St_SupplierCd;                       // 開始仕入先コード
                stockMonthYearReportWork.Ed_SupplierCd = stockMonthYearReportCndtn.Ed_SupplierCd;                       // 終了仕入先コード
                stockMonthYearReportWork.St_GoodsMakerCd = stockMonthYearReportCndtn.St_GoodsMakerCd;                   // 開始商品メーカーコード
                stockMonthYearReportWork.Ed_GoodsMakerCd = stockMonthYearReportCndtn.Ed_GoodsMakerCd;                   // 終了商品メーカーコード
                stockMonthYearReportWork.St_GoodsNo = stockMonthYearReportCndtn.St_GoodsNo;                             // 開始商品番号
                stockMonthYearReportWork.Ed_GoodsNo = stockMonthYearReportCndtn.Ed_GoodsNo;                             // 終了商品番号

                stockMonthYearReportWork.PartsManagementDivide1 = stockMonthYearReportCndtn.PartsManagementDivide1;
                stockMonthYearReportWork.PartsManagementDivide2 = stockMonthYearReportCndtn.PartsManagementDivide2;
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
        /// <param name="stockMonthYearReportCndtn">UI抽出条件クラス</param>
		/// <param name="stockMoveWork">取得データ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 取得データを展開する。</br>
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.07.17</br>
        /// <br>Update Note: 2015/09/08 凌偉志</br>
        /// <br>管理番号   : 11175324-00</br>
        /// <br>             Redmine#47299 MKアシスト 在庫月報年報回転率の計算が不正の障害対応</br>
        /// <br>Update Note: 2015/10/08 李侠</br>
        /// <br>管理番号   : 11175324-00</br>
        /// <br>             Redmine#47391 MKアシスト 在庫月報年報マークの判定が不正の障害対応</br>
		/// </remarks>
        private void DevStockMoveData(StockMonthYearReportCndtn stockMonthYearReportCndtn, ArrayList stockMoveWork)
		{
			DataRow dr;

            // --- DEL 2009/02/27 -------------------------------->>>>>
            //GoodsCndtn goodsCndtn = new GoodsCndtn(); // ADD 2009/02/26
            //List<GoodsUnitData> goodsUnitDataList; // ADD 2009/02/26
            //string errMsg; // ADD 2009/02/26
            // --- DEL 2009/02/27 --------------------------------<<<<<

            foreach (StockMonthYearReportDataWork stockMonthYearReportDataWork in stockMoveWork)
			{ 
                int status = 0;
                int goodsLGroup = 0;
                int goodsMGroup = 0;
                int bLGroupCode = 0;
                string bLGroupName = "";
                status = GoodsGanreCheck(stockMonthYearReportCndtn, stockMonthYearReportDataWork.BLGoodsCode, out goodsLGroup, out goodsMGroup, out bLGroupCode, out bLGroupName);
                if (status == 0)
                {

                    dr = this._stockNoShipmentListDt.NewRow();
                    // 取得データ展開
                    #region 取得データ展開
                    //dr[PMZAI02014EA.ct_Col_WarehouseCode] = stockMonthYearReportDataWork.WarehouseCode;             // 倉庫コード                         //DEL 2009/03/24 不具合対応[12679]
                    dr[PMZAI02014EA.ct_Col_WarehouseCode] = stockMonthYearReportDataWork.WarehouseCode.Trim().PadLeft(4, '0');              // 倉庫コード   //ADD 2009/03/24 不具合対応[12679]
                    dr[PMZAI02014EA.ct_Col_WarehouseName] = stockMonthYearReportDataWork.WarehouseName;             // 倉庫名称
                    dr[PMZAI02014EA.ct_Col_StockSupplierCode] = stockMonthYearReportDataWork.StockSupplierCode;     // 在庫発注先コード
                    dr[PMZAI02014EA.ct_Col_SupplierSnm] = stockMonthYearReportDataWork.SupplierSnm;                 // 仕入先略称
                    dr[PMZAI02014EA.ct_Col_GoodsNo] = stockMonthYearReportDataWork.GoodsNo;                         // 商品番号
                    dr[PMZAI02014EA.ct_Col_GoodsName] = stockMonthYearReportDataWork.GoodsName;                     // 商品名称
                    dr[PMZAI02014EA.ct_Col_WarehouseShelfNo] = stockMonthYearReportDataWork.WarehouseShelfNo;       // 倉庫棚番
                    // ---DEL 2009/06/03 不具合対応[12679] まるめ処理はActiveReportにゆだねる --------------------------------------->>>>>
                    //// ---DEL 2009/03/24 不具合対応[12679] -------------------------------------------------------------------------->>>>>
                    ////dr[PMZAI02014EA.ct_Col_LMonthStockCnt] = stockMonthYearReportDataWork.LMonthStockCnt;           // 前月末在庫数
                    ////dr[PMZAI02014EA.ct_Col_StockCount] = stockMonthYearReportDataWork.StockCount;                   // 仕入数
                    ////dr[PMZAI02014EA.ct_Col_MoveArrivalCnt] = stockMonthYearReportDataWork.MoveArrivalCnt;           // 移動入荷数
                    //////dr[PMZAI02014EA.ct_Col_TotalArrivalCnt] = stockMonthYearReportDataWork.TotalArrivalCnt;         // 総入荷数   //DEL 2008/12/24 不具合対応[9417]
                    ////// --- ADD 2008/12/24 総入荷数(仕入数＋移動入荷数) ---------------------------------------------------->>>>>
                    ////dr[PMZAI02014EA.ct_Col_TotalArrivalCnt] = stockMonthYearReportDataWork.StockCount
                    ////                                        + stockMonthYearReportDataWork.MoveArrivalCnt;
                    ////// --- ADD 2008/12/24 ---------------------------------------------------------------------------------<<<<<
                    ////dr[PMZAI02014EA.ct_Col_SalesCount] = stockMonthYearReportDataWork.SalesCount;                   // 売上数
                    ////dr[PMZAI02014EA.ct_Col_MoveShipmentCnt] = stockMonthYearReportDataWork.MoveShipmentCnt;         // 移動出荷数
                    //////dr[PMZAI02014EA.ct_Col_TotalShipmentCnt] = stockMonthYearReportDataWork.TotalShipmentCnt;       // 総出荷数   //DEL 2008/12/24 不具合対応[9417]
                    ////// --- ADD 2008/12/24 総出荷数(売上数＋移動出荷数) ---------------------------------------------------->>>>>
                    ////dr[PMZAI02014EA.ct_Col_TotalShipmentCnt] = stockMonthYearReportDataWork.SalesCount
                    ////                                        + stockMonthYearReportDataWork.MoveShipmentCnt;
                    ////// --- ADD 2008/12/24 ---------------------------------------------------------------------------------<<<<<
                    ////dr[PMZAI02014EA.ct_Col_MaximumStockCnt] = stockMonthYearReportDataWork.MaximumStockCnt;         // 最高在庫数
                    //// ---DEL 2009/03/24 不具合対応[12679] --------------------------------------------------------------------------<<<<<
                    //// ---ADD 2009/03/24 不具合対応[12679] -------------------------------------------------------------------------->>>>>
                    //dr[PMZAI02014EA.ct_Col_LMonthStockCnt] = Math.Truncate(stockMonthYearReportDataWork.LMonthStockCnt);           // 前月末在庫数
                    //dr[PMZAI02014EA.ct_Col_StockCount] = Math.Truncate(stockMonthYearReportDataWork.StockCount);                   // 仕入数
                    //dr[PMZAI02014EA.ct_Col_MoveArrivalCnt] = Math.Truncate(stockMonthYearReportDataWork.MoveArrivalCnt);           // 移動入荷数
                    //dr[PMZAI02014EA.ct_Col_TotalArrivalCnt] = Math.Truncate(stockMonthYearReportDataWork.StockCount
                    //                                        + stockMonthYearReportDataWork.MoveArrivalCnt);
                    //dr[PMZAI02014EA.ct_Col_SalesCount] = Math.Truncate(stockMonthYearReportDataWork.SalesCount);                   // 売上数
                    //dr[PMZAI02014EA.ct_Col_MoveShipmentCnt] = Math.Truncate(stockMonthYearReportDataWork.MoveShipmentCnt);         // 移動出荷数
                    //dr[PMZAI02014EA.ct_Col_TotalShipmentCnt] = Math.Truncate(stockMonthYearReportDataWork.SalesCount
                    //                                        + stockMonthYearReportDataWork.MoveShipmentCnt);
                    //dr[PMZAI02014EA.ct_Col_MaximumStockCnt] = Math.Truncate(stockMonthYearReportDataWork.MaximumStockCnt);         // 最高在庫数
                    //// ---ADD 2009/03/24 不具合対応[12679] --------------------------------------------------------------------------<<<<<
                    // ---DEL 2009/06/03 不具合対応[12679] まるめ処理はActiveReportにゆだねる ---------------------------------------<<<<<
                    // ---ADD 2009/06/03 不具合対応[12679] まるめ処理はActiveReportにゆだねる --------------------------------------->>>>>
                    dr[PMZAI02014EA.ct_Col_LMonthStockCnt] = stockMonthYearReportDataWork.LMonthStockCnt;           // 前月末在庫数
                    dr[PMZAI02014EA.ct_Col_StockCount] = stockMonthYearReportDataWork.StockCount;                   // 仕入数
                    dr[PMZAI02014EA.ct_Col_MoveArrivalCnt] = stockMonthYearReportDataWork.MoveArrivalCnt;           // 移動入荷数
                    dr[PMZAI02014EA.ct_Col_TotalArrivalCnt] = stockMonthYearReportDataWork.StockCount
                                                            + stockMonthYearReportDataWork.MoveArrivalCnt;
                    dr[PMZAI02014EA.ct_Col_SalesCount] = stockMonthYearReportDataWork.SalesCount;                   // 売上数
                    dr[PMZAI02014EA.ct_Col_MoveShipmentCnt] = stockMonthYearReportDataWork.MoveShipmentCnt;         // 移動出荷数
                    dr[PMZAI02014EA.ct_Col_TotalShipmentCnt] = stockMonthYearReportDataWork.SalesCount
                                                            + stockMonthYearReportDataWork.MoveShipmentCnt;
                    dr[PMZAI02014EA.ct_Col_MaximumStockCnt] = stockMonthYearReportDataWork.MaximumStockCnt;         // 最高在庫数
                    // ---ADD 2009/06/03 不具合対応[12679] まるめ処理はActiveReportにゆだねる ---------------------------------------<<<<<
                    
                    dr[PMZAI02014EA.ct_Col_MinimumStockCnt] = stockMonthYearReportDataWork.MinimumStockCnt;         // 最低在庫数
                    dr[PMZAI02014EA.ct_Col_SalesCost] = stockMonthYearReportDataWork.SalesCost;                     // 原価
                    dr[PMZAI02014EA.ct_Col_LMonthStockPrice] = stockMonthYearReportDataWork.LMonthStockPrice;       // 前月末在庫額
                    dr[PMZAI02014EA.ct_Col_StockPriceTaxExc] = stockMonthYearReportDataWork.StockPriceTaxExc;       // 仕入金額(税抜き)
                    dr[PMZAI02014EA.ct_Col_MoveArrivalPrice] = stockMonthYearReportDataWork.MoveArrivalPrice;       // 移動入荷額
                    //dr[PMZAI02014EA.ct_Col_TotalArrivalPrice] = stockMonthYearReportDataWork.TotalArrivalPrice;     // 総入荷金額 //DEL 2008/12/24 不具合対応[9417]
                    // --- ADD 2008/12/24 総入荷金額(仕入金額(税抜き)＋移動入荷額) ---------------------------------------->>>>>
                    dr[PMZAI02014EA.ct_Col_TotalArrivalPrice] = stockMonthYearReportDataWork.StockPriceTaxExc
                                                            + stockMonthYearReportDataWork.MoveArrivalPrice;
                    // --- ADD 2008/12/24 ---------------------------------------------------------------------------------<<<<<
                    dr[PMZAI02014EA.ct_Col_SalesMoneyTaxExc] = stockMonthYearReportDataWork.SalesMoneyTaxExc;       // 売上金額(税抜き)
                    dr[PMZAI02014EA.ct_Col_MoveShipmentPrice] = stockMonthYearReportDataWork.MoveShipmentPrice;     // 移動出荷額
                    //dr[PMZAI02014EA.ct_Col_TotalShipmentPrice] = stockMonthYearReportDataWork.TotalShipmentPrice;   // 総出荷金額 //DEL 2008/12/24 不具合対応[9417]
                    // --- ADD 2008/12/24 総出荷金額(売上金額(税抜き)＋移動出荷額) ---------------------------------------->>>>>
                    dr[PMZAI02014EA.ct_Col_TotalShipmentPrice] = stockMonthYearReportDataWork.SalesMoneyTaxExc
                                                            + stockMonthYearReportDataWork.MoveShipmentPrice;
                    // --- ADD 2008/12/24 ---------------------------------------------------------------------------------<<<<<
                    dr[PMZAI02014EA.ct_Col_GrossProfit] = stockMonthYearReportDataWork.GrossProfit;                 // 粗利金額
                    // ---DEL 2009/06/03 不具合対応[12679] まるめ処理はActiveReportにゆだねる --------------------------------------->>>>>
                    ////dr[PMZAI02014EA.ct_Col_GrossProfitRate] = stockMonthYearReportDataWork.GrossProfitRate;         // 粗利率                     //DEL 2008/10/10 小数点以下表示の為
                    ////dr[PMZAI02014EA.ct_Col_GrossProfitRate] = Math.Floor(stockMonthYearReportDataWork.GrossProfitRate * 100) / 100; // 粗利率       //ADD 2008/10/10　→　DEL 2009/03/24 不具合対応[12679]
                    //dr[PMZAI02014EA.ct_Col_GrossProfitRate] = Math.Round(stockMonthYearReportDataWork.GrossProfitRate, 2);          // 粗利率       //ADD 2009/03/24 不具合対応[12679]
                    // ---DEL 2009/06/03 不具合対応[12679] まるめ処理はActiveReportにゆだねる ---------------------------------------<<<<<
                    dr[PMZAI02014EA.ct_Col_GrossProfitRate] = stockMonthYearReportDataWork.GrossProfitRate;     // 粗利率   //ADD 2009/06/03 不具合対応[12679]　まるめ処理はActiveReportにゆだねる

                    dr[PMZAI02014EA.ct_Col_StockTotal] = stockMonthYearReportDataWork.StockTotal;                   // 在庫総数
                    dr[PMZAI02014EA.ct_Col_StockMashinePrice] = stockMonthYearReportDataWork.StockMashinePrice;     // マシン在庫額
                    dr[PMZAI02014EA.ct_Col_GoodsMakerCd] = stockMonthYearReportDataWork.GoodsMakerCd;               // メーカーコード
                    //dr[PMZAI02014EA.ct_Col_MakerName] = stockMonthYearReportDataWork.MakerShortName;                // メーカー名称       //DEL 2009/03/27 不具合対応[12802]
                    // ---ADD 2009/03/27 不具合対応[12802] ------------------------------------------------------>>>>>
                    // メーカー名称
                    if ((stockMonthYearReportDataWork.GoodsMakerCd == 0) || (string.IsNullOrEmpty(stockMonthYearReportDataWork.MakerShortName.Trim())))
                    {
                        dr[PMZAI02014EA.ct_Col_MakerName] = "未登録";
                    }
                    else
                    {
                        dr[PMZAI02014EA.ct_Col_MakerName] = stockMonthYearReportDataWork.MakerShortName;
                    }
                    // ---ADD 2009/03/27 不具合対応[12802] ------------------------------------------------------<<<<<

                    double stockCntAve = 0;         // 平均在庫数
                    double normalShipmentCnt = 0;   // 期間内標準出荷数
                    double turnOver = 0;            // 回転率
                    DateTime stMonth;
                    DateTime edMonth;
                    int selectMonth = 0;

                    // 平均在庫数
                    stockCntAve = Math.Ceiling((stockMonthYearReportDataWork.MaximumStockCnt - stockMonthYearReportDataWork.MinimumStockCnt) / 2) + stockMonthYearReportDataWork.MinimumStockCnt;
                    // 指定期間数
                    //stMonth = stockMonthYearReportCndtn.St_AddUpYearMonth;                            //DEL 2008/10/10　帳票の条件には画面の入力値を印字する為
                    // --- ADD 2008/10/10 ----------------------------------------------------------------------------------------------------------------->>>>>
                    if (stockMonthYearReportCndtn.PrintType == StockMonthYearReportCndtn.PrintTypeState.ThisMonth)
                    {
                        // 発行タイプ：当月
                        stMonth = stockMonthYearReportCndtn.St_AddUpYearMonth;
                    }
                    else
                    {
                        // 発行タイプ：当期
                        // --- DEL 2009/02/17 -------------------------------->>>>>
                        //int year;
                        //List<DateTime> startMonthDate;
                        //List<DateTime> endMonthDate;
                        //List<DateTime> yearMonth;

                        //this._dateGetAcs.GetFinancialYearTable(0, out startMonthDate, out endMonthDate, out yearMonth, out year);
                        //stMonth = startMonthDate[0];
                        // --- DEL 2009/02/17 --------------------------------<<<<<
                        // --- ADD 2009/02/17 -------------------------------->>>>>
                        int year;
                        int addYears;
                        DateTime stYMonth;
                        DateTime edYMonth;
                        this._dateGetAcs.GetYearFromMonth(stockMonthYearReportCndtn.Ed_AddUpYearMonth, out year, out addYears, out stYMonth, out edYMonth);

                        stMonth = stYMonth;
                        // --- ADD 2009/02/17 --------------------------------<<<<<
                    }
                    // --- ADD 2008/10/10 -----------------------------------------------------------------------------------------------------------------<<<<<
                    edMonth = stockMonthYearReportCndtn.Ed_AddUpYearMonth.AddMonths(1);
                    // --- DEL 2015/09/08 #47299  凌偉志 ----------------->>>>>
                    //selectMonth = (TDateTime.DateTimeToLongDate(edMonth) - TDateTime.DateTimeToLongDate(stMonth)) / 100;
                    // --- DEL 2015/09/08 #47299  凌偉志 -----------------<<<<<

                    // --- ADD 2015/09/08 #47299  凌偉志 ----------------->>>>>
                    selectMonth = edMonth.Month - stMonth.Month;
                    if (selectMonth <= 0)
                    {
                        selectMonth = selectMonth + 12;
                    }
                    // --- ADD 2015/09/08 #47299  凌偉志-----------------<<<<<

                    // 期間内標準出荷数
                    normalShipmentCnt = stockCntAve * selectMonth;
                    // 回転率
                    //turnOver = Math.Floor(stockMonthYearReportDataWork.TotalShipmentCnt / normalShipmentCnt);     //DEL 2008/10/10 ゼロ割時、＋∞が表示される為
                    // --- ADD 2008/10/10 ------------------------------------------------------------------------------------------------------------------>>>>>
                    if (normalShipmentCnt == 0)
                    {
                        turnOver = 0;
                    }
                    else
                    {
                        //turnOver = Math.Floor(stockMonthYearReportDataWork.TotalShipmentCnt / normalShipmentCnt);                 //DEL 2008/10/10 小数点以下2桁表示の為
                        // --- DEL 2015/09/08 #47299  凌偉志 ----------------->>>>>
                        //turnOver = Math.Floor(stockMonthYearReportDataWork.TotalShipmentCnt / normalShipmentCnt * 100) / 100;       //ADD 2008/10/10
                        // --- DEL 2015/09/08 #47299  凌偉志 -----------------<<<<<
                        // --- ADD 2015/09/08 #47299  凌偉志 ----------------->>>>>
                        turnOver = Math.Floor(stockMonthYearReportDataWork.TotalShipmentCnt * 100 * 100 / normalShipmentCnt) / 100;
                        // --- ADD 2015/09/08 #47299  凌偉志-----------------<<<<<
                    }
                    // --- ADD 2008/10/10 ------------------------------------------------------------------------------------------------------------------<<<<<

                    dr[PMZAI02014EA.ct_Col_TurnOver] = turnOver;                                                    // 回転率

                    //dr[PMZAI02014EA.ct_Col_Sort_WarehouseCode] = stockMonthYearReportDataWork.WarehouseCode;        // ソート用　倉庫コード               //DEL 2009/03/24 不具合対応[12679]
                    dr[PMZAI02014EA.ct_Col_Sort_WarehouseCode] = stockMonthYearReportDataWork.WarehouseCode.Trim().PadLeft(4, '0'); // ソート用　倉庫コード //ADD 2009/03/24 不具合対応[12679]
                    dr[PMZAI02014EA.ct_Col_Sort_GoodsNo] = stockMonthYearReportDataWork.GoodsNo;                    // ソート用　商品番号
                    dr[PMZAI02014EA.ct_Col_Sort_WarehouseShelfNo] = stockMonthYearReportDataWork.WarehouseShelfNo;  // ソート用　倉庫棚番

                    // --- ADD 2008/10/10 ---------------------------------------------------------------------------------------->>>>>
                    //dr[PMZAI02014EA.ct_Col_Sort_CustomerCode] = stockMonthYearReportDataWork.StockSupplierCode;     // ソート用　仕入先                   //DEL 2009/03/27 不具合対応[12802]
                    dr[PMZAI02014EA.ct_Col_Sort_GoodsMakerCd] = stockMonthYearReportDataWork.GoodsMakerCd;          // ソート用　メーカー
                    // --- ADD 2008/10/10 ----------------------------------------------------------------------------------------<<<<<

                    dr[PMZAI02014EA.ct_Col_Sort_BLGroupCode] = bLGroupCode;
                    dr[PMZAI02014EA.ct_Col_Sort_GoodsLGroupCode] = goodsLGroup;
                    dr[PMZAI02014EA.ct_Col_Sort_GoodsMGroupCode] = goodsMGroup;

                    UserGdBdU goodsLGroupU;
                    GoodsGroupU goodsMGroupU;
                    /* ---DEL 2009/03/27 不具合対応[12802] ----------------------------------------------------->>>>>
                    stc_GoodsAcs.GetGoodsLGroup(LoginInfoAcquisition.EnterpriseCode, goodsLGroup, out goodsLGroupU);
                    dr[PMZAI02014EA.ct_Col_Sort_GoodsLGroupName] = goodsLGroupU.GuideName;

                    stc_GoodsAcs.GetGoodsMGroup(LoginInfoAcquisition.EnterpriseCode, goodsMGroup, out goodsMGroupU);
                    dr[PMZAI02014EA.ct_Col_Sort_GoodsMGroupName] = goodsMGroupU.GoodsMGroupName;
                    dr[PMZAI02014EA.ct_Col_Sort_BLGroupName] = bLGroupName;
                       ---DEL 2009/03/27 不具合対応[12802] -----------------------------------------------------<<<<< */
                    // ---ADD 2009/03/27 不具合対応[12802] ----------------------------------------------------->>>>>
                    int ret = 0;
                    ret = stc_GoodsAcs.GetGoodsLGroup(LoginInfoAcquisition.EnterpriseCode, goodsLGroup, out goodsLGroupU);
                    if (ret == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        dr[PMZAI02014EA.ct_Col_Sort_GoodsLGroupName] = goodsLGroupU.GuideName;
                    }
                    else
                    {
                        dr[PMZAI02014EA.ct_Col_Sort_GoodsLGroupName] = "未登録";
                    }

                    ret = stc_GoodsAcs.GetGoodsMGroup(LoginInfoAcquisition.EnterpriseCode, goodsMGroup, out goodsMGroupU);
                    if (ret == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        dr[PMZAI02014EA.ct_Col_Sort_GoodsMGroupName] = goodsMGroupU.GoodsMGroupName;
                        dr[PMZAI02014EA.ct_Col_Sort_BLGroupName] = bLGroupName;
                    }
                    else
                    {
                        dr[PMZAI02014EA.ct_Col_Sort_GoodsMGroupName] = "未登録";
                        dr[PMZAI02014EA.ct_Col_Sort_BLGroupName] = "未登録";
                    }
                    // ---ADD 2009/03/27 不具合対応[12802] -----------------------------------------------------<<<<<
                    
                    if (stockMonthYearReportCndtn.GrsProfitCheckLower > stockMonthYearReportDataWork.GrossProfitRate)
                    {
                        dr[PMZAI02014EA.ct_Col_Mark] = stockMonthYearReportCndtn.GrsProfitChkLowSign;
                    }
                    // --- ADD 2015/10/08 Redmine#47391の#16不具合対応 --------------------------------------->>>>>
                    else if (stockMonthYearReportCndtn.GrsProfitCheckBest > stockMonthYearReportDataWork.GrossProfitRate)
                    {
                        dr[PMZAI02014EA.ct_Col_Mark] = stockMonthYearReportCndtn.GrsProfitChkBestSign;
                    }
                    else if (stockMonthYearReportCndtn.GrsProfitCheckUpper > stockMonthYearReportDataWork.GrossProfitRate)
                    {
                        dr[PMZAI02014EA.ct_Col_Mark] = stockMonthYearReportCndtn.GrsProfitChkUprSign;
                    }
                    else if (stockMonthYearReportCndtn.GrsProfitCheckUpper <= stockMonthYearReportDataWork.GrossProfitRate)
                    {
                        dr[PMZAI02014EA.ct_Col_Mark] = stockMonthYearReportCndtn.GrsProfitChkMaxSign;
                    }
                    // --- ADD 2015/10/08 Redmine#47391の#16不具合対応 ---------------------------------------<<<<<
                    // --- DEL 2015/10/08 Redmine#47391の#16不具合対応 --------------------------------------->>>>>
                    ////else if (stockMonthYearReportCndtn.GrsProfitCheckLower <= stockMonthYearReportDataWork.GrossProfitRate && stockMonthYearReportCndtn.GrsProfitCheckBest >= stockMonthYearReportDataWork.GrossProfit)   //DEL 2008/10/10 粗利金額(GrossProfit)となっている為
                    //// --- ADD 2008/10/10 --------------------------------------------------------------------------------->>>>>
                    //else if ((stockMonthYearReportCndtn.GrsProfitCheckLower <= stockMonthYearReportDataWork.GrossProfitRate) &&
                    //         (stockMonthYearReportCndtn.GrsProfitCheckBest > stockMonthYearReportDataWork.GrossProfitRate))
                    //// --- ADD 2008/10/10 ---------------------------------------------------------------------------------<<<<<
                    //{
                    //    dr[PMZAI02014EA.ct_Col_Mark] = stockMonthYearReportCndtn.GrsProfitChkBestSign;
                    //}
                    ////else if (stockMonthYearReportCndtn.GrsProfitCheckBest < stockMonthYearReportDataWork.GrossProfitRate && stockMonthYearReportCndtn.GrsProfitCheckUpper >= stockMonthYearReportDataWork.GrossProfit)    //DEL 2008/10/10 粗利金額(GrossProfit)となっている為
                    //// --- ADD 2008/10/10 --------------------------------------------------------------------------------->>>>>
                    //else if ((stockMonthYearReportCndtn.GrsProfitCheckBest < stockMonthYearReportDataWork.GrossProfitRate) &&
                    //         (stockMonthYearReportCndtn.GrsProfitCheckUpper >= stockMonthYearReportDataWork.GrossProfitRate))
                    //// --- ADD 2008/10/10 ---------------------------------------------------------------------------------<<<<<
                    //{
                    //    dr[PMZAI02014EA.ct_Col_Mark] = stockMonthYearReportCndtn.GrsProfitChkUprSign;
                    //}
                    //else if (stockMonthYearReportCndtn.GrsProfitCheckUpper < stockMonthYearReportDataWork.GrossProfitRate)
                    //{
                    //    dr[PMZAI02014EA.ct_Col_Mark] = stockMonthYearReportCndtn.GrsProfitChkMaxSign;
                    //}
                    // --- DEL 2015/10/08 Redmine#47391の#16不具合対応 ---------------------------------------<<<<<

                    // --- DEL 2009/02/27 -------------------------------->>>>>
                    //// --- ADD 2009/02/26 -------------------------------->>>>>
                    //// 仕入先取得(商品管理情報マスタより取得）
                    //if (stockMonthYearReportDataWork.StockSupplierCode == 0)
                    //{
                    //    goodsCndtn.EnterpriseCode = stockMonthYearReportCndtn.EnterpriseCode;
                    //    goodsCndtn.GoodsNo = stockMonthYearReportDataWork.GoodsNo;
                    //    goodsCndtn.GoodsMakerCd = stockMonthYearReportDataWork.GoodsMakerCd;

                    //    goodsCndtn.IsSettingSupplier = 1;
                    //    goodsCndtn.IsSettingVariousMst = 1;

                    //    int stat = stc_GoodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtn, false, out goodsUnitDataList, out errMsg);

                    //    if (stat == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //    {
                    //        GoodsUnitData goodsUnitData = goodsUnitDataList[0];

                    //        stc_GoodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData);

                    //        if (goodsUnitData.SupplierCd != 0)
                    //        {
                    //            dr[PMZAI02014EA.ct_Col_StockSupplierCode] = goodsUnitData.SupplierCd; // 仕入先コード
                    //            dr[PMZAI02014EA.ct_Col_SupplierSnm] = goodsUnitData.SupplierSnm; // 仕入先名称

                    //            dr[PMZAI02014EA.ct_Col_Sort_CustomerCode] = goodsUnitData.SupplierCd; // ソート用　仕入先コード
                    //        }
                    //    }
                    //}
                    //// --- ADD 2009/02/26 --------------------------------<<<<<
                    // --- DEL 2009/02/27 --------------------------------<<<<<
                    // --- ADD 2009/02/27 -------------------------------->>>>>
                    if (stockMonthYearReportDataWork.StockSupplierCode == 0)
                    {
                        int supplierCd;
                        string supplierSnm;
                        GetGoodsMngInfo(stockMonthYearReportDataWork, out supplierCd, out supplierSnm);
                        dr[PMZAI02014EA.ct_Col_StockSupplierCode] = supplierCd;             // 仕入先コード
                        dr[PMZAI02014EA.ct_Col_SupplierSnm] = supplierSnm;                  // 仕入先略称
                        dr[PMZAI02014EA.ct_Col_Sort_CustomerCode] = supplierCd;             // ソート用　仕入先コード
                    }
                    // --- ADD 2009/02/27 --------------------------------<<<<<

                    #endregion

                    // TableにAdd
                    this._stockNoShipmentListDt.Rows.Add(dr);
                }
			}

            #region 順位付け処理・金額単位処理

            // 金額単位取得
            double moneyUnit = GetMoneyUnit(stockMonthYearReportCndtn);

            for (int index = 0; index < this._stockNoShipmentListDt.Rows.Count; index++)
            {
                dr = this._stockNoShipmentListDt.Rows[index];

                // 金額単位処理
                // ---DEL 2009/06/03 不具合対応[12679] まるめ処理はActiveReportにゆだねる --------------------------------------->>>>>
                //dr[PMZAI02014EA.ct_Col_SalesCost] = Math.Floor((double)dr[PMZAI02014EA.ct_Col_SalesCost] / moneyUnit);                  // 原価
                //dr[PMZAI02014EA.ct_Col_LMonthStockPrice] = Math.Floor((double)dr[PMZAI02014EA.ct_Col_LMonthStockPrice] / moneyUnit);    // 前月末在庫額
                //dr[PMZAI02014EA.ct_Col_StockPriceTaxExc] = Math.Floor((double)dr[PMZAI02014EA.ct_Col_StockPriceTaxExc] / moneyUnit);    // 仕入金額(税抜き)
                //dr[PMZAI02014EA.ct_Col_MoveArrivalPrice] = Math.Floor((double)dr[PMZAI02014EA.ct_Col_MoveArrivalPrice] / moneyUnit);    // 移動入荷額
                //dr[PMZAI02014EA.ct_Col_TotalArrivalPrice] = Math.Floor((double)dr[PMZAI02014EA.ct_Col_TotalArrivalPrice] / moneyUnit);  // 総入荷金額
                //dr[PMZAI02014EA.ct_Col_SalesMoneyTaxExc] = Math.Floor((double)dr[PMZAI02014EA.ct_Col_SalesMoneyTaxExc] / moneyUnit);    // 売上金額(税抜き)
                //dr[PMZAI02014EA.ct_Col_MoveShipmentPrice] = Math.Floor((double)dr[PMZAI02014EA.ct_Col_MoveShipmentPrice] / moneyUnit);  // 移動出荷額
                //dr[PMZAI02014EA.ct_Col_TotalShipmentPrice] = Math.Floor((double)dr[PMZAI02014EA.ct_Col_TotalShipmentPrice] / moneyUnit);// 総出荷金額
                //dr[PMZAI02014EA.ct_Col_GrossProfit] = Math.Floor((double)dr[PMZAI02014EA.ct_Col_GrossProfit] / moneyUnit);              // 粗利金額
                //dr[PMZAI02014EA.ct_Col_StockMashinePrice] = Math.Floor((double)dr[PMZAI02014EA.ct_Col_StockMashinePrice] / moneyUnit);  // マシン在庫額
                // ---DEL 2009/06/03 不具合対応[12679] まるめ処理はActiveReportにゆだねる ---------------------------------------<<<<<
                // ---ADD 2009/06/03 不具合対応[12679] まるめ処理はActiveReportにゆだねる --------------------------------------->>>>>
                dr[PMZAI02014EA.ct_Col_SalesCost] = (double)dr[PMZAI02014EA.ct_Col_SalesCost] / moneyUnit;                      // 原価
                dr[PMZAI02014EA.ct_Col_LMonthStockPrice] = (double)dr[PMZAI02014EA.ct_Col_LMonthStockPrice] / moneyUnit;        // 前月末在庫額
                dr[PMZAI02014EA.ct_Col_StockPriceTaxExc] = (double)dr[PMZAI02014EA.ct_Col_StockPriceTaxExc] / moneyUnit;        // 仕入金額(税抜き)
                dr[PMZAI02014EA.ct_Col_MoveArrivalPrice] = (double)dr[PMZAI02014EA.ct_Col_MoveArrivalPrice] / moneyUnit;        // 移動入荷額
                dr[PMZAI02014EA.ct_Col_TotalArrivalPrice] = (double)dr[PMZAI02014EA.ct_Col_TotalArrivalPrice] / moneyUnit;      // 総入荷金額
                dr[PMZAI02014EA.ct_Col_SalesMoneyTaxExc] = (double)dr[PMZAI02014EA.ct_Col_SalesMoneyTaxExc] / moneyUnit;        // 売上金額(税抜き)
                dr[PMZAI02014EA.ct_Col_MoveShipmentPrice] = (double)dr[PMZAI02014EA.ct_Col_MoveShipmentPrice] / moneyUnit;      // 移動出荷額
                dr[PMZAI02014EA.ct_Col_TotalShipmentPrice] = (double)dr[PMZAI02014EA.ct_Col_TotalShipmentPrice] / moneyUnit;    // 総出荷金額
                dr[PMZAI02014EA.ct_Col_GrossProfit] = (double)dr[PMZAI02014EA.ct_Col_GrossProfit] / moneyUnit;                  // 粗利金額
                dr[PMZAI02014EA.ct_Col_StockMashinePrice] = (double)dr[PMZAI02014EA.ct_Col_StockMashinePrice] / moneyUnit;      // マシン在庫額
                // ---ADD 2009/06/03 不具合対応[12679] まるめ処理はActiveReportにゆだねる ---------------------------------------<<<<<
            }

            #endregion

            this._stockNoShipmentListDt.CaseSensitive = true;       //ADD 2009/03/31 不具合対応[12873]

			// DataView作成
            //this._stockNoShipmentListDataView = new DataView(this._stockNoShipmentListDt, "", GetSortOrder(stockMonthYearReportCndtn), DataViewRowState.CurrentRows);
            this._stockNoShipmentListDataView = new DataView(this._stockNoShipmentListDt, GetFilter(stockMonthYearReportCndtn), GetSortOrder(stockMonthYearReportCndtn), DataViewRowState.CurrentRows); // ADD 2009/02/26
        }

        #region ◎ 金額単位取得処理
        /// <summary>
        /// 金額単位取得処理
        /// </summary>
        /// <param name="stockMonthYearReportCndtn"></param>
        /// <returns></returns>
        private double GetMoneyUnit(StockMonthYearReportCndtn stockMonthYearReportCndtn)
        {
            double moneyUnit;

            switch (stockMonthYearReportCndtn.MoneyUnit)
            {
                case StockMonthYearReportCndtn.MoneyUnitState.One:
                    moneyUnit = 1;
                    break;
                case StockMonthYearReportCndtn.MoneyUnitState.Thousand:
                    moneyUnit = 1000;
                    break;
                default:
                    moneyUnit = 1;
                    break;
            }
            return moneyUnit;
        }
        #endregion

        /// <summary>
        /// 商品区分絞込処理
        /// </summary>
        /// <param name="stockMonthYearReportCndtn"></param>
        /// <param name="BLGoodsCode"></param>
        /// <param name="goodsLGroup"></param>
        /// <param name="goodsMGroup"></param>
        /// <param name="bLGroupCode"></param>
        /// <param name="bLGroupName"></param>
        /// <returns></returns>
        private int GoodsGanreCheck(StockMonthYearReportCndtn stockMonthYearReportCndtn, int BLGoodsCode, out int goodsLGroup, out int goodsMGroup, out int bLGroupCode, out string bLGroupName)
        {
            int status = 0;
            BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();

            // BLコードマスタ取得
            stc_GoodsAcs.GetBLGoodsCd(BLGoodsCode, out bLGoodsCdUMnt);

            // --- ADD 2008/10/06 ------------------------------------------->>>>>
            BLGoodsCode = 0;
            goodsLGroup = 0;
            goodsMGroup = 0;
            bLGroupCode = 0;
            bLGroupName = string.Empty;
            if (bLGoodsCdUMnt == null)
            {
                //// BLコード情報が取得できなかった場合、グループコードが「最初から最後まで」の時のみ対象とする
                //if ((string.IsNullOrEmpty(stockMonthYearReportCndtn.St_DetailGoodsGanreCode)) &&
                //    (string.IsNullOrEmpty(stockMonthYearReportCndtn.Ed_DetailGoodsGanreCode))) // DEL 2009/02/25
                // BLコード情報が取得できなかった場合、
                // 商品大分類、商品中分類、グループコードが「最初から」の時のみ対象とする
                if ((string.IsNullOrEmpty(stockMonthYearReportCndtn.St_LargeGoodsGanreCode))
                    &&
                    (string.IsNullOrEmpty(stockMonthYearReportCndtn.St_MediumGoodsGanreCode))
                    &&
                    (string.IsNullOrEmpty(stockMonthYearReportCndtn.St_DetailGoodsGanreCode))) // ADD 2009/02/25
                {
                    return 0;       //対象
                }
                else
                {
                    return 1;       //対象外
                }
            }
            // --- ADD 2008/10/06 -------------------------------------------<<<<<

            // --- CHG 2009/02/02 障害ID:10911対応------------------------------------------------------>>>>>
            //bLGroupCode = bLGoodsCdUMnt.BLGoodsCode;
            bLGroupCode = bLGoodsCdUMnt.BLGloupCode;
            // --- CHG 2009/02/02 障害ID:10911対応------------------------------------------------------<<<<<

            BLGroupU bLGroupU = new BLGroupU();

            // BLグループマスタ取得
            stc_GoodsAcs.GetBLGroup(stockMonthYearReportCndtn.EnterpriseCode, bLGoodsCdUMnt.BLGloupCode, out bLGroupU);
            // --- ADD 2008/10/06 ------------------------------------------->>>>>
            if (bLGroupU == null)
            {
                //// BLグループコード情報が取得できなかった場合、グループコードが「最初から最後まで」の時のみ対象とする
                //if ((string.IsNullOrEmpty(stockMonthYearReportCndtn.St_DetailGoodsGanreCode)) &&
                //    (string.IsNullOrEmpty(stockMonthYearReportCndtn.Ed_DetailGoodsGanreCode))) // DEL 2009/02/25
                //// BLグループコード情報が取得できなかった場合、グループコードが「最初から」の時のみ対象とする
                //if (string.IsNullOrEmpty(stockMonthYearReportCndtn.St_DetailGoodsGanreCode)) // ADD 2009/02/25// DEL 2009/02/27
                // BLグループコード情報が取得できなかった場合
                // 商品大分類、商品中分類が「最初から」の時のみ対象とする
                if (
                    (string.IsNullOrEmpty(stockMonthYearReportCndtn.St_LargeGoodsGanreCode))
                    &&
                    (string.IsNullOrEmpty(stockMonthYearReportCndtn.St_MediumGoodsGanreCode))
                   ) // ADD 2009/02/27
                {
                    return 0;       //対象
                }
                else
                {
                    return 1;       //対象外
                }
            }
            // --- ADD 2008/10/06 -------------------------------------------<<<<<

            goodsLGroup = bLGroupU.GoodsLGroup;
            goodsMGroup = bLGroupU.GoodsMGroup;
            bLGroupName = bLGroupU.BLGroupName;

            // グループコードチェック
            if (stockMonthYearReportCndtn.St_DetailGoodsGanreCode != string.Empty && stockMonthYearReportCndtn.Ed_DetailGoodsGanreCode != string.Empty)
            {
                // 開始<=終了 範囲内か？
                // --- CHG 2009/02/02 障害ID:10911対応------------------------------------------------------>>>>>
                //if (int.Parse(stockMonthYearReportCndtn.St_DetailGoodsGanreCode) >= bLGoodsCdUMnt.BLGloupCode ||
                //   int.Parse(stockMonthYearReportCndtn.Ed_DetailGoodsGanreCode) <= bLGoodsCdUMnt.BLGloupCode)
                if (int.Parse(stockMonthYearReportCndtn.St_DetailGoodsGanreCode) > bLGoodsCdUMnt.BLGloupCode ||
                   int.Parse(stockMonthYearReportCndtn.Ed_DetailGoodsGanreCode) < bLGoodsCdUMnt.BLGloupCode)
                // --- CHG 2009/02/02 障害ID:10911対応------------------------------------------------------<<<<<
                {
                    status = 1;
                    return status;
                }
            }
            else if (stockMonthYearReportCndtn.St_DetailGoodsGanreCode != string.Empty && stockMonthYearReportCndtn.Ed_DetailGoodsGanreCode == string.Empty)
            {
                // 開始<=最後まで 範囲内か？
                // --- CHG 2009/02/02 障害ID:10911対応------------------------------------------------------>>>>>
                //if (int.Parse(stockMonthYearReportCndtn.St_DetailGoodsGanreCode) >= bLGoodsCdUMnt.BLGloupCode)
                if (int.Parse(stockMonthYearReportCndtn.St_DetailGoodsGanreCode) > bLGoodsCdUMnt.BLGloupCode)
                // --- CHG 2009/02/02 障害ID:10911対応------------------------------------------------------<<<<<
                {
                    status = 1;
                    return status;
                }
            }
            else if (stockMonthYearReportCndtn.St_DetailGoodsGanreCode == string.Empty && stockMonthYearReportCndtn.Ed_DetailGoodsGanreCode != string.Empty)
            {
                // 最初から<=終了 範囲内か？
                // --- CHG 2009/02/02 障害ID:10911対応------------------------------------------------------>>>>>
                //if (int.Parse(stockMonthYearReportCndtn.Ed_DetailGoodsGanreCode) <= bLGoodsCdUMnt.BLGloupCode)
                if (int.Parse(stockMonthYearReportCndtn.Ed_DetailGoodsGanreCode) < bLGoodsCdUMnt.BLGloupCode)
                // --- CHG 2009/02/02 障害ID:10911対応------------------------------------------------------<<<<<
                {
                    status = 1;
                    return status;
                }
            }

            // 商品中分類チェック
            if (stockMonthYearReportCndtn.St_MediumGoodsGanreCode != string.Empty && stockMonthYearReportCndtn.Ed_MediumGoodsGanreCode != string.Empty)
            {
                // 開始<=終了 範囲内か？
                // --- CHG 2009/02/02 障害ID:10911対応------------------------------------------------------>>>>>
                //if (int.Parse(stockMonthYearReportCndtn.St_MediumGoodsGanreCode) >= bLGroupU.GoodsMGroup ||
                //   int.Parse(stockMonthYearReportCndtn.Ed_MediumGoodsGanreCode) <= bLGroupU.GoodsMGroup)
                if (int.Parse(stockMonthYearReportCndtn.St_MediumGoodsGanreCode) > bLGroupU.GoodsMGroup ||
                   int.Parse(stockMonthYearReportCndtn.Ed_MediumGoodsGanreCode) < bLGroupU.GoodsMGroup)
                // --- CHG 2009/02/02 障害ID:10911対応------------------------------------------------------<<<<<
                {
                    status = 1;
                    return status;
                }
            }
            else if (stockMonthYearReportCndtn.St_MediumGoodsGanreCode != string.Empty && stockMonthYearReportCndtn.Ed_MediumGoodsGanreCode == string.Empty)
            {
                // 開始<=最後まで 範囲内か？
                // --- CHG 2009/02/02 障害ID:10911対応------------------------------------------------------>>>>>
                //if (int.Parse(stockMonthYearReportCndtn.St_MediumGoodsGanreCode) >= bLGroupU.GoodsMGroup)
                if (int.Parse(stockMonthYearReportCndtn.St_MediumGoodsGanreCode) > bLGroupU.GoodsMGroup)
                // --- CHG 2009/02/02 障害ID:10911対応------------------------------------------------------<<<<<
                {
                    status = 1;
                    return status;
                }
            }
            else if (stockMonthYearReportCndtn.St_MediumGoodsGanreCode == string.Empty && stockMonthYearReportCndtn.Ed_MediumGoodsGanreCode != string.Empty)
            {
                // 最初から<=終了 範囲内か？
                // --- CHG 2009/02/02 障害ID:10911対応------------------------------------------------------>>>>>
                //if (int.Parse(stockMonthYearReportCndtn.Ed_MediumGoodsGanreCode) <= bLGroupU.GoodsMGroup)
                if (int.Parse(stockMonthYearReportCndtn.Ed_MediumGoodsGanreCode) < bLGroupU.GoodsMGroup)
                // --- CHG 2009/02/02 障害ID:10911対応------------------------------------------------------<<<<<
                {
                    status = 1;
                    return status;
                }
            }

            // 商品大分類チェック
            if (stockMonthYearReportCndtn.St_LargeGoodsGanreCode != string.Empty && stockMonthYearReportCndtn.Ed_LargeGoodsGanreCode != string.Empty)
            {
                // 開始<=終了 範囲内か？
                // --- CHG 2009/02/02 障害ID:10911対応------------------------------------------------------>>>>>
                //if (int.Parse(stockMonthYearReportCndtn.St_LargeGoodsGanreCode) >= bLGroupU.GoodsLGroup ||
                //   int.Parse(stockMonthYearReportCndtn.Ed_LargeGoodsGanreCode) <= bLGroupU.GoodsLGroup)
                if (int.Parse(stockMonthYearReportCndtn.St_LargeGoodsGanreCode) > bLGroupU.GoodsLGroup ||
                   int.Parse(stockMonthYearReportCndtn.Ed_LargeGoodsGanreCode) < bLGroupU.GoodsLGroup)
                // --- CHG 2009/02/02 障害ID:10911対応------------------------------------------------------<<<<<
                {
                    status = 1;
                    return status;
                }
            }
            else if (stockMonthYearReportCndtn.St_LargeGoodsGanreCode != string.Empty && stockMonthYearReportCndtn.Ed_LargeGoodsGanreCode == string.Empty)
            {
                // 開始<=最後まで 範囲内か？
                // --- CHG 2009/02/02 障害ID:10911対応------------------------------------------------------>>>>>
                //if (int.Parse(stockMonthYearReportCndtn.St_LargeGoodsGanreCode) >= bLGroupU.GoodsLGroup)
                if (int.Parse(stockMonthYearReportCndtn.St_LargeGoodsGanreCode) > bLGroupU.GoodsLGroup)
                // --- CHG 2009/02/02 障害ID:10911対応------------------------------------------------------<<<<<
                {
                    status = 1;
                    return status;
                }
            }
            else if (stockMonthYearReportCndtn.St_LargeGoodsGanreCode == string.Empty && stockMonthYearReportCndtn.Ed_LargeGoodsGanreCode != string.Empty)
            {
                // 最初から<=終了 範囲内か？
                //if (int.Parse(stockMonthYearReportCndtn.St_LargeGoodsGanreCode) <= bLGroupU.GoodsLGroup)          //DEL 2008/10/10 商品大分類Toに入力時エラーとなる為
                // --- CHG 2009/02/02 障害ID:10911対応------------------------------------------------------>>>>>
                //if (int.Parse(stockMonthYearReportCndtn.Ed_LargeGoodsGanreCode) <= bLGroupU.GoodsLGroup)
                if (int.Parse(stockMonthYearReportCndtn.Ed_LargeGoodsGanreCode) < bLGroupU.GoodsLGroup)
                // --- CHG 2009/02/02 障害ID:10911対応------------------------------------------------------<<<<<
                {
                    status = 1;
                    return status;
                }
            }

            return status;
        }

        /// <summary>
        /// 拠点ガイド名称取得
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点ガイド名称</returns>
        private string GetSectionGuideNm ( string sectionCode )
        {
            if ( stc_SectionDic.ContainsKey(sectionCode) ) {
                return stc_SectionDic[sectionCode].SectionGuideNm;
            }
            else {
                return string.Empty;
            }
        }
        /// <summary>
        /// 日付文字列取得
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private string GetDateText ( DateTime dateTime ) 
        {
            if (dateTime != DateTime.MinValue) {
                return dateTime.ToString("yy/MM/dd");
            }
            else {
                return string.Empty;
            }
        }

        // --- ADD 2009/02/27 -------------------------------->>>>>
        /// <summary>
        /// 商品管理情報マスタ取得処理
        /// </summary>
        /// <param name="stockMonthYearReportDataWork"></param>
        /// <param name="supplierCd"></param>
        /// <param name="supplierSnm"></param>
        /// <returns></returns>
        private void GetGoodsMngInfo(StockMonthYearReportDataWork stockMonthYearReportDataWork, out int supplierCd, out string supplierSnm)
        {
            supplierCd = 0;
            supplierSnm = "";

            GoodsUnitData goodsUnitData = new GoodsUnitData();
            goodsUnitData.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            goodsUnitData.GoodsMakerCd = stockMonthYearReportDataWork.GoodsMakerCd;
            goodsUnitData.GoodsNo = stockMonthYearReportDataWork.GoodsNo;
            //goodsUnitData.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;        //ADD 2009/04/02 不具合対応[13025] → DEL 2009/06/12 不具合対応[13448]
            goodsUnitData.SectionCode = stockMonthYearReportDataWork.SectionCode;               //ADD 2009/06/12 不具合対応[13448]
            goodsUnitData.GoodsLGroup = stockMonthYearReportDataWork.GoodsLGroup;
            goodsUnitData.GoodsMGroup = stockMonthYearReportDataWork.GoodsMGroup;
            goodsUnitData.BLGroupCode = stockMonthYearReportDataWork.BLGroupCode;
            goodsUnitData.BLGoodsCode = stockMonthYearReportDataWork.BLGoodsCode;

            stc_GoodsAcs.GetGoodsMngInfo(ref goodsUnitData);
            // -- DEL 2010/05/07 -------------------------------->>>
            //stc_GoodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData);
            // -- DEL 2010/05/07 --------------------------------<<<

            supplierCd = goodsUnitData.SupplierCd;
            //supplierSnm = goodsUnitData.SupplierSnm;          //DEL 2009/03/27　不具合対応[12802]
            // ---ADD 2009/03/27 不具合対応[12802] ------------------------------------->>>>>
            if (supplierCd == 0)
            {
                supplierSnm = "未登録";
            }
            else
            {
                supplierSnm = goodsUnitData.SupplierSnm;
            }
            // ---ADD 2009/03/27 不具合対応[12802] -------------------------------------<<<<<
        }
        // --- ADD 2009/02/27 --------------------------------<<<<<

		#endregion

        // --- ADD 2009/02/26 -------------------------------->>>>>
        #region ◎ フィルタ作成
        /// <summary>
        /// フィルタ作成
        /// </summary>
        /// <returns>フィルタ文字列</returns>
        private string GetFilter(StockMonthYearReportCndtn stockGetuNenCndtn)
        {
            string strQuery = "";

            if ((stockGetuNenCndtn.St_SupplierCd != 0) && (stockGetuNenCndtn.Ed_SupplierCd != 0))
            {
                strQuery = String.Format("{0} <= {1} AND {2} <= {3}",
                stockGetuNenCndtn.St_SupplierCd.ToString(),
                PMZAI02014EA.ct_Col_StockSupplierCode,
                PMZAI02014EA.ct_Col_StockSupplierCode,
                stockGetuNenCndtn.Ed_SupplierCd.ToString());
            }

            if ((stockGetuNenCndtn.St_SupplierCd != 0) && (stockGetuNenCndtn.Ed_SupplierCd == 0))
            {
                strQuery = String.Format("{0} <= {1}",
                stockGetuNenCndtn.St_SupplierCd.ToString(),
                PMZAI02014EA.ct_Col_StockSupplierCode);
            }

            if ((stockGetuNenCndtn.St_SupplierCd == 0) && (stockGetuNenCndtn.Ed_SupplierCd != 0))
            {
                strQuery = String.Format("{0} <= {1}",
                PMZAI02014EA.ct_Col_StockSupplierCode,
                stockGetuNenCndtn.Ed_SupplierCd.ToString());
            }

            return strQuery;
        }
        #endregion
        // --- ADD 2009/02/26 --------------------------------<<<<<

		#region ◎ ソート順作成
		/// <summary>
		/// ソート順作成
		/// </summary>
		/// <returns>ソート文字列</returns>
        private string GetSortOrder(StockMonthYearReportCndtn stockGetuNenCndtn)
        {
            StringBuilder strSortOrder = new StringBuilder();

            /* ---DEL 2009/03/24 不具合対応[12679] ----------------------------------------->>>>>
            // 拠点コード
            strSortOrder.Append(string.Format("{0},", PMZAI02014EA.ct_Col_Sort_SectionCode));
               ---DEL 2009/03/24 不具合対応[12679] -----------------------------------------<<<<< */
            // 倉庫コード
            strSortOrder.Append(string.Format("{0},", PMZAI02014EA.ct_Col_Sort_WarehouseCode));
            // 仕入先コード
            strSortOrder.Append(string.Format("{0},", PMZAI02014EA.ct_Col_Sort_CustomerCode));
            // メーカーコード
            strSortOrder.Append(string.Format("{0},", PMZAI02014EA.ct_Col_Sort_GoodsMakerCd));
            // --- ADD 2008/10/10 ---------------------------------------------------------->>>>>
            // 商品大分類
            strSortOrder.Append(string.Format("{0},", PMZAI02014EA.ct_Col_Sort_GoodsLGroupCode));
            // 商品中分類
            strSortOrder.Append(string.Format("{0},", PMZAI02014EA.ct_Col_Sort_GoodsMGroupCode));
            // グループコード
            strSortOrder.Append(string.Format("{0},", PMZAI02014EA.ct_Col_Sort_BLGroupCode));
            // --- ADD 2008/10/10 ----------------------------------------------------------<<<<<
            // 商品コード
            strSortOrder.Append(string.Format("{0}", PMZAI02014EA.ct_Col_Sort_GoodsNo));

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
        /// <br>Programmer : 30416 長沼 賢二</br>
        /// <br>Date       : 2008.07.17</br>
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

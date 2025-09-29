//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫未出荷一覧表
// プログラム概要   : 在庫未出荷一覧表で使用するデータを取得
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鈴木 正臣
// 作 成 日  2007/09/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 長沼 賢二
// 修 正 日  2008/07/17  修正内容 :
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/02/27  修正内容 : 不具合対応[12009]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/18  修正内容 : 不具合対応[12544]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/04/24  修正内容 : 不具合対応[12872][12996][13022]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/05/01  修正内容 : 不具合対応[12801]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 長内 数馬
// 修 正 日  2011/05/18  修正内容 : 速度チューニング
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
using Broadleaf.Application.Controller.Util;        //ADD 2009/02/27 不具合対応[12009]

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// 在庫未出荷一覧表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 在庫未出荷一覧表で使用するデータを取得する。</br>
    /// <br>Programmer   : 22018 鈴木 正臣</br>
    /// <br>Date         : 2007.09.19</br>
    /// <br></br>
    /// <br>UpdateNote   : 2008.07.17 30416 長沼 賢二</br>
    /// <br>             : 2009/02/27       照田 貴志　不具合対応[12009]</br>
    /// <br>             : 2009/03/18       照田 貴志　不具合対応[12544]</br>
    /// <br>             : 2009/04/24       照田 貴志　不具合対応[12872][12996][13022]</br>
    /// <br>             : 2009/05/01       照田 貴志　不具合対応[12801]</br>
    /// </remarks>
	public class StockNoShipmentListAcs
	{
		#region ■ Constructor
		/// <summary>
		/// 在庫未出荷一覧表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫未出荷一覧表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.09.19</br>
		/// </remarks>
		public StockNoShipmentListAcs()
		{
            this._iStockNoShipmentListWorkDB = ( IStockNoShipmentListWorkDB ) MediationStockNoShipmentListWorkDB.GetStockNoShipmentListWorkDB();

            // ---ADD 2009/05/01 不具合対応[12801] ----------------------------------->>>>>
            this._taxRateSetAcs = new TaxRateSetAcs();                  //税率設定マスタアクセス
            this._unitPriceCalculation = new UnitPriceCalculation();    //単価算出モジュール
            this._stockMngTtlStAcs = new StockMngTtlStAcs();            //在庫全体設定マスタアクセス

            // 税率取得           
            TaxRateSet taxRateSet = null;
            if (this.TaxRateSetRead(out taxRateSet) == 0)
            {
                this._taxRate = this.GetTaxRate(taxRateSet, DateTime.Now);
            }

            // 単価算出モジュールの初期データ設定
            this.ReadInitData();

            // 在庫全体設定情報取得
            this.ReadStockMngTtlSt();
            // ---ADD 2009/05/01 不具合対応[12801] -----------------------------------<<<<<

		}

		/// <summary>
		/// 在庫未出荷一覧表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫未出荷一覧表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.09.19</br>
		/// </remarks>
        static StockNoShipmentListAcs ()
		{
			stc_Employee		= null;
			stc_PrtOutSet		= null;					// 帳票出力設定データクラス
			stc_PrtOutSetAcs	= new PrtOutSetAcs();	// 帳票出力設定アクセスクラス

            stc_SecInfoAcs = new SecInfoAcs(1);         // 拠点アクセスクラス
            stc_SectionDic = new Dictionary<string, SecInfoSet>();  // 拠点Dictionary
            //--- ADD 2008/07/22 ---------->>>>>
            stc_GoodsAcs = new GoodsAcs();              // 商品アクセスクラス

            Employee loginWorker = null;
            string ownSectionCode = "";
            string msg;

            if (LoginInfoAcquisition.Employee != null)
            {
                loginWorker = LoginInfoAcquisition.Employee.Clone();
                ownSectionCode = loginWorker.BelongSectionCode;
            }

            stc_GoodsAcs.IsGetSupplier = true;          //ADD 2009/04/24 不具合対応[13022]
            stc_GoodsAcs.SearchInitial(LoginInfoAcquisition.EnterpriseCode, ownSectionCode, out msg);
            //--- ADD 2008/07/22 ----------<<<<<

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
		private static PrtOutSet stc_PrtOutSet;			// 帳票出力設定データクラス
		private static PrtOutSetAcs stc_PrtOutSetAcs;	// 帳票出力設定アクセスクラス
        private static SecInfoAcs stc_SecInfoAcs;               // 拠点アクセスクラス
        private static Dictionary<string, SecInfoSet> stc_SectionDic;   // 拠点Dictionary
        //--- ADD 2008/07/22 ---------->>>>>
        private static GoodsAcs stc_GoodsAcs;                   // 商品アクセスクラス
        //--- ADD 2008/07/22 ----------<<<<<
		#endregion ■ Static Member

		#region ■ Private Member
        IStockNoShipmentListWorkDB _iStockNoShipmentListWorkDB;

		private DataTable _stockNoShipmentListDt;			// 印刷DataTable
		private DataView _stockNoShipmentListDataView;	// 印刷DataView
        // ---ADD 2009/05/01 不具合対応[12801] ------------------------------------------------->>>>>
        private TaxRateSetAcs _taxRateSetAcs = null;                    //税率設定マスタアクセス
        private UnitPriceCalculation _unitPriceCalculation = null;      //単価算出モジュール
        private StockMngTtlStAcs _stockMngTtlStAcs = null;              //在庫全体設定マスタアクセス
        private StockMngTtlSt _stockMngTtlSt = null;                    //在庫管理全体設定
        private double _taxRate = 0.0;                                  //税率
        // ---ADD 2009/05/01 不具合対応[12801] -------------------------------------------------<<<<<
        
        // -- ADD 2011/05/18 --------------------------->>>
        private Dictionary<string, GoodsUnitData> goodsUnitDataDic = null;
        private Dictionary<string, UnitPriceCalcRet> unitPriceCalcRetDic = null;
        // -- ADD 2011/05/18 ---------------------------<<<
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
		/// <param name="stockNoShipmentListCndtn">抽出条件</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷するデータを取得する。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.09.19</br>
		/// </remarks>
        public int SearchMain ( StockNoShipmentListCndtn stockNoShipmentListCndtn, out string errMsg )
		{
            return this.SearchProc(stockNoShipmentListCndtn, out errMsg);
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
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.09.19</br>
		/// </remarks>
        private int SearchProc ( StockNoShipmentListCndtn stockNoShipmentListCndtn, out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

			try
			{
				// DataTable Create ----------------------------------------------------------
				DCZAI02165EA.CreateDataTable( ref this._stockNoShipmentListDt );
				
				StockNoShipmentListCndtnWork stockNoShipmentListCndtnWork = new StockNoShipmentListCndtnWork();
				// 抽出条件展開  --------------------------------------------------------------
				status = this.DevStockMoveCndtn( stockNoShipmentListCndtn, out stockNoShipmentListCndtnWork, out errMsg );
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

				// データ取得  ----------------------------------------------------------------
				object retStockMoveList = null;
                
                status = this._iStockNoShipmentListWorkDB.Search( out retStockMoveList, stockNoShipmentListCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);
                //--- TEST --------->>>>>
                //retStockMoveList = this.GetTestData();
                //status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //--- TEST ---------<<<<<

                switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						// データ展開処理
						DevStockMoveData( stockNoShipmentListCndtn, (ArrayList)retStockMoveList );
                        // DEL 2008/09/30 不具合対応[5728]↓
                        //status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        // ADD 2008/09/30 不具合対応[5728] ---------->>>>>
                        if (this._stockNoShipmentListDataView.Count > 0)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        // ADD 2008/09/30 不具合対応[5728] ----------<<<<<
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

            StockNoShipmentListWork work = new StockNoShipmentListWork();

            work.SectionCode = "01";				// 拠点コード
            work.SectionGuideNm = "拠点01";		    // 拠点ガイド名称
            work.WarehouseCode = "0001";            // 倉庫コード
            work.WarehouseName = "倉庫01";          // 倉庫名称
            work.SupplierCd = 1;                    // 仕入先コード
            work.SupplierSnm = "";                  // 仕入先略称
            work.GoodsMakerCd = 1;                  // メーカーコード
            work.PartsManagementDivide1 = "1";
            work.PartsManagementDivide2 = "2";
            work.BLGoodsCode = 1;                   // BLコード
            work.GoodsNo = "20";					// 品番
            work.GoodsName = "P901_ブルー";			// 品名
            work.WarehouseShelfNo = "02";           // 棚番
            work.MinimumStockCnt = 1;
            work.MaximumStockCnt = 100;

            list.Add(work);

            StockNoShipmentListWork work1 = new StockNoShipmentListWork();

            work1.SectionCode = "02";				// 拠点コード
            work1.SectionGuideNm = "拠点02";		// 拠点ガイド名称
            work1.GoodsNo = "20";					// 商品コード
            work1.GoodsName = "P901_ブルー";	    // 商品名称
            work1.WarehouseCode = "0001";           // 倉庫コード
            work1.WarehouseName = "倉庫01";         // 倉庫名称
            work1.WarehouseShelfNo = "02";          // 棚番
            work1.BLGoodsCode = 1;                  // BLコード
            work1.GoodsMakerCd = 1;                 // 品番

            list.Add(work1);

            StockNoShipmentListWork work2 = new StockNoShipmentListWork();

            work2.SectionCode = "01";				// 拠点コード
            work2.SectionGuideNm = "拠点01";		// 拠点ガイド名称
            work2.GoodsNo = "20";					// 商品コード
            work2.GoodsName = "P901_ブルー";	    // 商品名称
            work2.WarehouseCode = "0001";           // 倉庫コード
            work2.WarehouseName = "倉庫01";         // 倉庫名称
            work2.WarehouseShelfNo = "01";          // 棚番
            work2.BLGoodsCode = 1;                  // BLコード
            work2.GoodsMakerCd = 1;                 // 品番

            list.Add(work2);


            StockNoShipmentListWork work3 = new StockNoShipmentListWork();

            work3.SectionCode = "02";				// 拠点コード
            work3.SectionGuideNm = "拠点02";		// 拠点ガイド名称
            work3.GoodsNo = "20";					// 商品コード
            work3.GoodsName = "P901_ブルー";	    // 商品名称
            work3.WarehouseCode = "0001";           // 倉庫コード
            work3.WarehouseName = "倉庫01";         // 倉庫名称
            work3.WarehouseShelfNo = "01";          // 棚番
            work3.BLGoodsCode = 1;                  // BLコード
            work3.GoodsMakerCd = 1;                 // 品番

            list.Add(work3);


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
		/// <param name="stockNoShipmentListCndtn">UI抽出条件クラス</param>
		/// <param name="stockNoShipmentListCndtnWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
        private int DevStockMoveCndtn ( StockNoShipmentListCndtn stockNoShipmentListCndtn, out StockNoShipmentListCndtnWork stockNoShipmentListCndtnWork, out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;
			stockNoShipmentListCndtnWork = new StockNoShipmentListCndtnWork();
			try
			{
                stockNoShipmentListCndtnWork.EnterpriseCode = stockNoShipmentListCndtn.EnterpriseCode;  // 企業コード
				// 抽出条件パラメータセット
				if ( stockNoShipmentListCndtn.SectionCodes.Length != 0 )
				{
				    if ( stockNoShipmentListCndtn.IsSelectAllSection )
				    {
				        // 全社の時
                        stockNoShipmentListCndtnWork.SectionCodes = null;
				    }
				    else
				    {
                        stockNoShipmentListCndtnWork.SectionCodes = stockNoShipmentListCndtn.SectionCodes;
				    }
				}
				else
				{
                    stockNoShipmentListCndtnWork.SectionCodes = null;
				}

                stockNoShipmentListCndtnWork.EnterpriseCode = stockNoShipmentListCndtn.EnterpriseCode;
                stockNoShipmentListCndtnWork.St_AddUpYearMonth = stockNoShipmentListCndtn.St_AddUpYearMonth;
                stockNoShipmentListCndtnWork.Ed_AddUpYearMonth = stockNoShipmentListCndtn.Ed_AddUpYearMonth;
                stockNoShipmentListCndtnWork.SectionCodes = stockNoShipmentListCndtn.SectionCodes;
                stockNoShipmentListCndtnWork.St_WarehouseCode = stockNoShipmentListCndtn.St_WarehouseCode;
                stockNoShipmentListCndtnWork.Ed_WarehouseCode = stockNoShipmentListCndtn.Ed_WarehouseCode;
                //--- DEL 2008/07/17 ---------->>>>>
                //stockNoShipmentListCndtnWork.St_CustomerCode = stockNoShipmentListCndtn.St_CustomerCode;
                //stockNoShipmentListCndtnWork.Ed_CustomerCode = stockNoShipmentListCndtn.Ed_CustomerCode;
                //--- DEL 2008/07/17 ----------<<<<<
                //--- ADD 2008/07/17 ---------->>>>>
                stockNoShipmentListCndtnWork.St_SupplierCd = stockNoShipmentListCndtn.St_CustomerCode;
                stockNoShipmentListCndtnWork.Ed_SupplierCd = stockNoShipmentListCndtn.Ed_CustomerCode;
                //--- ADD 2008/07/17 ----------<<<<<
                stockNoShipmentListCndtnWork.St_GoodsMakerCd = stockNoShipmentListCndtn.St_GoodsMakerCd;
                stockNoShipmentListCndtnWork.Ed_GoodsMakerCd = stockNoShipmentListCndtn.Ed_GoodsMakerCd;
                //--- DEL 2008/07/17 ---------->>>>>
                //stockNoShipmentListCndtnWork.St_LargeGoodsGanreCode = stockNoShipmentListCndtn.St_LargeGoodsGanreCode;
                //stockNoShipmentListCndtnWork.Ed_LargeGoodsGanreCode = stockNoShipmentListCndtn.Ed_LargeGoodsGanreCode;
                //stockNoShipmentListCndtnWork.St_MediumGoodsGanreCode = stockNoShipmentListCndtn.St_MediumGoodsGanreCode;
                //stockNoShipmentListCndtnWork.Ed_MediumGoodsGanreCode = stockNoShipmentListCndtn.Ed_MediumGoodsGanreCode;
                //stockNoShipmentListCndtnWork.St_DetailGoodsGanreCode = stockNoShipmentListCndtn.St_DetailGoodsGanreCode;
                //stockNoShipmentListCndtnWork.Ed_DetailGoodsGanreCode = stockNoShipmentListCndtn.Ed_DetailGoodsGanreCode;
                //--- DEL 2008/07/17 ----------<<<<<
                stockNoShipmentListCndtnWork.St_EnterpriseGanreCode = stockNoShipmentListCndtn.St_EnterpriseGanreCode;
                stockNoShipmentListCndtnWork.Ed_EnterpriseGanreCode = stockNoShipmentListCndtn.Ed_EnterpriseGanreCode;
                stockNoShipmentListCndtnWork.St_BLGoodsCode = stockNoShipmentListCndtn.St_BLGoodsCode;
                stockNoShipmentListCndtnWork.Ed_BLGoodsCode = stockNoShipmentListCndtn.Ed_BLGoodsCode;
                stockNoShipmentListCndtnWork.St_GoodsNo = stockNoShipmentListCndtn.St_GoodsNo;
                stockNoShipmentListCndtnWork.Ed_GoodsNo = stockNoShipmentListCndtn.Ed_GoodsNo;
                stockNoShipmentListCndtnWork.St_WarehouseShelfNo = stockNoShipmentListCndtn.St_WarehouseShelfNo;
                stockNoShipmentListCndtnWork.Ed_WarehouseShelfNo = stockNoShipmentListCndtn.Ed_WarehouseShelfNo;
                stockNoShipmentListCndtnWork.StockCreateDate = stockNoShipmentListCndtn.StockCreateDate;
                stockNoShipmentListCndtnWork.StockCreateDateDiv = (int)stockNoShipmentListCndtn.StockCreateDateDiv;
                //--- ADD 2008/07/17 ---------->>>>>
                stockNoShipmentListCndtnWork.PartsManagementDivide1 = stockNoShipmentListCndtn.PartsManagementDivide1;
                stockNoShipmentListCndtnWork.PartsManagementDivide2 = stockNoShipmentListCndtn.PartsManagementDivide2;
                //--- ADD 2008/07/17 ----------<<<<<

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
		/// <param name="stockNoShipmentListCndtn">UI抽出条件クラス</param>
		/// <param name="stockMoveWork">取得データ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 取得データを展開する。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.09.19</br>
		/// </remarks>
		private void DevStockMoveData ( StockNoShipmentListCndtn stockNoShipmentListCndtn, ArrayList stockMoveWork )
		{
			DataRow dr;
            GoodsUnitData goodsUnitData = null;         //ADD 2009/05/01 不具合対応[12801]

            goodsUnitDataDic = new Dictionary<string, GoodsUnitData>();   // ADD 2011/05/18
            unitPriceCalcRetDic = new Dictionary<string, UnitPriceCalcRet>(); // ADD 2011/05/18 

            int goodsMGroup = 0;

            // 棚番ブレイク桁数
            int breakLength = stockNoShipmentListCndtn.WarehouseShelfNoBreakLength;

			foreach ( StockNoShipmentListWork stockNoShipmentListWork in stockMoveWork )
			{
                //--- ADD 2008/07/22 ---------->>>>>
                int status = 0;
                //status = GoodsGanreCheck(stockNoShipmentListCndtn, stockNoShipmentListWork.BLGoodsCode);                  //DEL 2009/04/24 不具合対応[13022]
                status = GoodsGanreCheck(stockNoShipmentListCndtn, stockNoShipmentListWork.BLGoodsCode, out goodsMGroup);   //ADD 2009/04/24 不具合対応[13022]
                if (status == 0)
                {
                //--- ADD 2008/07/22 ----------<<<<<

                    dr = this._stockNoShipmentListDt.NewRow();
                    // 取得データ展開
                    #region 取得データ展開

                    // ---DEL 2009/04/24 不具合対応[12996] ------------------------------------------------------>>>>>
                    ////dr[DCZAI02165EA.ct_Col_SectionCode] = stockNoShipmentListWork.SectionCode;              // 拠点コード         //DEL 2009/03/18 不具合対応[12544]
                    //dr[DCZAI02165EA.ct_Col_SectionCode] = stockNoShipmentListWork.SectionCode.Trim();       // 拠点コード           //ADD 2009/03/18 不具合対応[12544]
                    //dr[DCZAI02165EA.ct_Col_SectionGuideNm] = this.GetSectionGuideNm(stockNoShipmentListWork.SectionCode); // 拠点ガイド名称
                    // ---DEL 2009/04/24 不具合対応[12996] ------------------------------------------------------<<<<<

                    //dr[DCZAI02165EA.ct_Col_WarehouseCode] = stockNoShipmentListWork.WarehouseCode;          // 倉庫コード         //DEL 2009/03/18 不具合対応[12544]
                    dr[DCZAI02165EA.ct_Col_WarehouseCode] = stockNoShipmentListWork.WarehouseCode.Trim();   // 倉庫コード           //ADD 2009/03/18 不具合対応[12544]
                    dr[DCZAI02165EA.ct_Col_WarehouseName] = stockNoShipmentListWork.WarehouseName;          // 倉庫名称
                    // ---ADD 2009/04/24 不具合対応[13022] ------------------------------------------------------>>>>>
                    if ((stockNoShipmentListWork.WarehouseCode.Trim().PadLeft(4, '0') == "0") ||
                        (string.IsNullOrEmpty(stockNoShipmentListWork.WarehouseName.Trim())))
                    {
                        dr[DCZAI02165EA.ct_Col_WarehouseName] = "未登録";
                    }
                    // ---ADD 2009/04/24 不具合対応[13022] ------------------------------------------------------<<<<<
                    //--- DEL 2008/07/17 ---------->>>>>
                    //dr[DCZAI02165EA.ct_Col_CustomerCode] = stockNoShipmentListWork.CustomerCode;          // 仕入先コード
                    //dr[DCZAI02165EA.ct_Col_CustomerName] = stockNoShipmentListWork.CustomerName;          // 仕入先名称
                    //--- DEL 2008/07/17 ----------<<<<<
                    //--- ADD 2008/07/17 ---------->>>>>
                    dr[DCZAI02165EA.ct_Col_CustomerCode] = stockNoShipmentListWork.SupplierCd;              // 仕入先コード
                    dr[DCZAI02165EA.ct_Col_CustomerName] = stockNoShipmentListWork.SupplierSnm;             // 仕入先略称
                    //--- ADD 2008/07/17 ----------<<<<<
                    //dr[DCZAI02165EA.ct_Col_CustomerSnm] = stockNoShipmentListWork.CustomerSnm;            // 仕入先略称
                    dr[DCZAI02165EA.ct_Col_GoodsMakerCd] = stockNoShipmentListWork.GoodsMakerCd;            // 商品メーカーコード
                    dr[DCZAI02165EA.ct_Col_MakerName] = stockNoShipmentListWork.MakerName;                  // メーカー名称
                    // ---ADD 2009/04/24 不具合対応[13022] ------------------------------------------------------>>>>>
                    if ((stockNoShipmentListWork.GoodsMakerCd == 0) ||
                        (string.IsNullOrEmpty(stockNoShipmentListWork.MakerName.Trim())))
                    {
                        dr[DCZAI02165EA.ct_Col_MakerName] = "未登録";
                    }
                    // ---ADD 2009/04/24 不具合対応[13022] ------------------------------------------------------<<<<<
                    dr[DCZAI02165EA.ct_Col_WarehouseShelfNo] = stockNoShipmentListWork.WarehouseShelfNo;    // 倉庫棚番
                    dr[DCZAI02165EA.ct_Col_BLGoodsCode] = stockNoShipmentListWork.BLGoodsCode;              // ＢＬ商品コード
                    //dr[DCZAI02165EA.ct_Col_BLGoodsFullName] = stockNoShipmentListWork.BLGoodsFullName;    // ＢＬ商品コード名称(全角)    // DEL 2008.07.17
                    dr[DCZAI02165EA.ct_Col_GoodsNo] = stockNoShipmentListWork.GoodsNo;                      // 商品番号
                    dr[DCZAI02165EA.ct_Col_GoodsName] = stockNoShipmentListWork.GoodsName;                  // 商品名称
                    dr[DCZAI02165EA.ct_Col_MinimumStockCnt] = stockNoShipmentListWork.MinimumStockCnt;      // 最低在庫数
                    dr[DCZAI02165EA.ct_Col_MaximumStockCnt] = stockNoShipmentListWork.MaximumStockCnt;      // 最高在庫数
                    dr[DCZAI02165EA.ct_Col_StockTotal] = stockNoShipmentListWork.StockTotal;                // 在庫総数
                    //dr[DCZAI02165EA.ct_Col_ShipmentCnt] = stockNoShipmentListWork.ShipmentCnt;            // 出荷数          // DEL 2008.07.17
                    dr[DCZAI02165EA.ct_Col_ShipmentCnt] = stockNoShipmentListWork.TotalShipmentCnt;         // 総出荷数        // ADD 2008.07.17
                    //dr[DCZAI02165EA.ct_Col_StockMashinePrice] = stockNoShipmentListWork.StockMashinePrice;  // マシン在庫額               //DEL 2009/05/01 不具合対応[12801]
                    dr[DCZAI02165EA.ct_Col_StockCreateDate] = this.GetDateText(stockNoShipmentListWork.StockCreateDate); // 在庫登録日
                    dr[DCZAI02165EA.ct_Col_LastSalesDate] = this.GetDateText(stockNoShipmentListWork.LastSalesDate); // 最終売上日
                    /* ---DEL 2009/03/18 不具合対応[12544] --------------------------------------------------------------->>>>>
                    dr[DCZAI02165EA.ct_Col_Sort_SectionCode] = stockNoShipmentListWork.SectionCode;         // ソート用　拠点コード
                    dr[DCZAI02165EA.ct_Col_Sort_WarehouseCode] = stockNoShipmentListWork.WarehouseCode;     // ソート用　倉庫コード
                       ---DEL 2009/03/18 不具合対応[12544] ---------------------------------------------------------------<<<<< */
                    // ---ADD 2009/03/18 不具合対応[12544] --------------------------------------------------------------->>>>>
                    //dr[DCZAI02165EA.ct_Col_Sort_SectionCode] = stockNoShipmentListWork.SectionCode.Trim();      // ソート用　拠点コード   //DEL 2009/04/24 不具合対応[12996]
                    dr[DCZAI02165EA.ct_Col_Sort_WarehouseCode] = stockNoShipmentListWork.WarehouseCode.Trim();  // ソート用　倉庫コード
                    // ---ADD 2009/03/18 不具合対応[12544] ---------------------------------------------------------------<<<<<
                    //dr[DCZAI02165EA.ct_Col_Sort_CustomerCode] = stockNoShipmentListWork.CustomerCode;     // ソート用　仕入先コード       // DEL 2008.07.17
                    dr[DCZAI02165EA.ct_Col_Sort_CustomerCode] = stockNoShipmentListWork.SupplierCd;         // ソート用　仕入先コード       // ADD 2008.07.17
                    dr[DCZAI02165EA.ct_Col_Sort_GoodsMakerCd] = stockNoShipmentListWork.GoodsMakerCd;       // ソート用　商品メーカーコード
                    dr[DCZAI02165EA.ct_Col_Sort_GoodsNo] = stockNoShipmentListWork.GoodsNo;                 // ソート用　商品番号
                    dr[DCZAI02165EA.ct_Col_Sort_WarehouseShelfNo] = stockNoShipmentListWork.WarehouseShelfNo; // ソート用　倉庫棚番
                    dr[DCZAI02165EA.ct_Col_Sort_BLGoodsCode] = stockNoShipmentListWork.BLGoodsCode;         // ソート用　ＢＬ商品コード     //ADD 2009/03/18 不具合対応[12544]

                    // 棚番ブレイク設定
                    string warehouseShelfNoBreak = stockNoShipmentListWork.WarehouseShelfNo.PadRight(8, ' ').Substring(0, breakLength);
                    dr[DCZAI02165EA.ct_Col_WarehouseShelfNoBreak] = warehouseShelfNoBreak; // 倉庫棚番ブレイク
                    dr[DCZAI02165EA.ct_Col_Sort_WarehouseShelfNoBreak] = warehouseShelfNoBreak; // ソート用　倉庫棚番ブレイク

                    //--- ADD 2008.07.22 ---------->>>>>
                    dr[DCZAI02165EA.ct_Col_PartsManagementDivide1] = stockNoShipmentListWork.PartsManagementDivide1;
                    dr[DCZAI02165EA.ct_Col_PartsManagementDivide2] = stockNoShipmentListWork.PartsManagementDivide2;
                    //--- ADD 2008.07.22 ----------<<<<<

                    // ---DEL 2009/05/01 不具合対応[12801] ----------------------------------------------------------------->>>>>
                    //// ---ADD 2009/04/24 不具合対応[13022] ------------------------------------------------------------->>>>>
                    //if (stockNoShipmentListWork.SupplierCd == 0)
                    //{
                    //    int supplierCd = 0;
                    //    string supplierSnm = string.Empty;
                    //    this.GetGoodsMngInfo(stockNoShipmentListWork, goodsMGroup, out supplierCd, out supplierSnm);

                    //    dr[DCZAI02165EA.ct_Col_CustomerCode] = supplierCd;              // 仕入先コード
                    //    dr[DCZAI02165EA.ct_Col_CustomerName] = supplierSnm;             // 仕入先略称
                    //    dr[DCZAI02165EA.ct_Col_Sort_CustomerCode] = supplierCd;         // ソート用　仕入先コード
                    //}
                    //// ---ADD 2009/04/24 不具合対応[13022] -------------------------------------------------------------<<<<<
                    // ---DEL 2009/05/01 不具合対応[12801] -----------------------------------------------------------------<<<<<
                    // ---ADD 2009/05/01 不具合対応[12801] ----------------------------------------------------------------->>>>>
                    // -- UPD 2011/05/18 -------------------------------------->>>
                    //goodsUnitData = this.GetGoodsUnitData(stockNoShipmentListWork.GoodsMakerCd,
                    //                  stockNoShipmentListWork.GoodsNo,
                    //                  goodsMGroup,
                    //                  stockNoShipmentListWork.BLGoodsCode);

                    string keyString = stockNoShipmentListWork.GoodsNo + '-' + stockNoShipmentListWork.GoodsMakerCd.ToString("0000");

                    if (goodsUnitDataDic.ContainsKey(keyString))
                    {
                        //既に一度検索されていた場合は、退避した検索結果を使用する
                        goodsUnitData = goodsUnitDataDic[keyString] as GoodsUnitData;
                    }
                    else
                    {
                        //検索処理
                        goodsUnitData = this.GetGoodsUnitData(stockNoShipmentListWork.GoodsMakerCd,
                                          stockNoShipmentListWork.GoodsNo,
                                          goodsMGroup,
                                          stockNoShipmentListWork.BLGoodsCode);

                        goodsUnitDataDic.Add(keyString, goodsUnitData);
                    }
                    // -- UPD 2011/05/18 --------------------------------------<<<

                    // -- ADD 2011/03/16 ------------------------------>>>
                    //仕入先の絞り込みをここで追加して、単価取得ロジックを最小限にする。
                    int stSupplierCd = 0;
                    int edSupplierCd = 999999;
                    if (stockNoShipmentListCndtn.St_CustomerCode != 0)
                    {
                        stSupplierCd = stockNoShipmentListCndtn.St_CustomerCode;
                    }
                    if (stockNoShipmentListCndtn.Ed_CustomerCode != 0)
                    {
                        edSupplierCd = stockNoShipmentListCndtn.Ed_CustomerCode;
                    }

                    if ((goodsUnitData.SupplierCd < stSupplierCd) || (goodsUnitData.SupplierCd > edSupplierCd)) continue;
                    // -- ADD 2011/03/16 ------------------------------<<<

                    //仕入先情報取得
                    //if (stockNoShipmentListWork.SupplierCd == 0)  // DEL 2011/05/18
                    //{  // DEL 2011/05/18
                        dr[DCZAI02165EA.ct_Col_CustomerCode] = goodsUnitData.SupplierCd;           // 仕入先コード
                        dr[DCZAI02165EA.ct_Col_Sort_CustomerCode] = goodsUnitData.SupplierCd;      // ソート用　仕入先コード
                        if (string.IsNullOrEmpty(goodsUnitData.SupplierSnm.Trim()))
                        {
                            dr[DCZAI02165EA.ct_Col_CustomerName] = "未登録";
                        }
                        else
                        {
                            dr[DCZAI02165EA.ct_Col_CustomerName] = goodsUnitData.SupplierSnm;          // 仕入先略称
                        }
                    //} // DEL 2011/05/18

                    //価格情報取得
                    double salesUnitCost = 0.0;
                    // -- UPD 2011/05/18 --------------------------------->>>
                    //GoodsPrice goodsPrice = stc_GoodsAcs.GetGoodsPriceFromGoodsPriceList(DateTime.Now, goodsUnitData.GoodsPriceList);
                    //if (goodsPrice != null)
                    //{
                    //    if (goodsPrice.PriceStartDate != DateTime.MinValue)
                    //    {
                    //        UnitPriceCalcRet unitPriceCalcRet = null;
                    //        this.CalculateUnitCost(goodsUnitData, this._taxRate, out unitPriceCalcRet);

                    //        salesUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;
                    //    }
                    //    else
                    //    {
                    //        salesUnitCost = goodsPrice.SalesUnitCost;
                    //    }
                    //}

                    UnitPriceCalcRet unitPriceCalcRet = null;

                    if (unitPriceCalcRetDic.ContainsKey(keyString))
                    {
                        //一度、原価取得を行った商品は退避した結果を使用する。
                        unitPriceCalcRet = unitPriceCalcRetDic[keyString] as UnitPriceCalcRet;
                    }
                    else
                    {
                        //原価取得処理
                        this.CalculateUnitCost(goodsUnitData, this._taxRate, out unitPriceCalcRet);
                        unitPriceCalcRetDic.Add(keyString, unitPriceCalcRet);
                    }
                    salesUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;
                    // -- UPD 2011/05/18 ---------------------------------<<<

                    dr[DCZAI02165EA.ct_Col_StockMashinePrice] = this.StockTotalPriceToLong(stockNoShipmentListWork.StockTotal, salesUnitCost); // 在庫金額
                    // ---ADD 2009/05/01 不具合対応[12801] -----------------------------------------------------------------<<<<<
                    #endregion

                    // TableにAdd
                    this._stockNoShipmentListDt.Rows.Add(dr);
                //--- ADD 2008/07/22 ---------->>>>>
                }
                //--- ADD 2008/07/22 ----------<<<<<
            }

            this._stockNoShipmentListDt.CaseSensitive = true;       //ADD 2009/04/24 不具合対応[12872]

			// DataView作成
			//this._stockNoShipmentListDataView = new DataView( this._stockNoShipmentListDt, "", GetSortOrder(stockNoShipmentListCndtn), DataViewRowState.CurrentRows );    //DEL 2009/04/24 不具合対応[13022]
            // ---ADD 2009/04/24 不具合対応[13022] -------------------------------------------------------->>>>>
            this._stockNoShipmentListDataView = new DataView(this._stockNoShipmentListDt,
                                                             this.GetFilter(stockNoShipmentListCndtn),
                                                             this.GetSortOrder(stockNoShipmentListCndtn),
                                                             DataViewRowState.CurrentRows);
            // ---ADD 2009/04/24 不具合対応[13022] --------------------------------------------------------<<<<<
        }

        //--- ADD 2008/07/22 ---------->>>>>
        /// <summary>
        /// 商品区分絞込処理
        /// </summary>
        /// <param name="stockNoShipmentListCndtn"></param>
        /// <param name="BLGoodsCode"></param>
        /// <param name="goodsMGroup"></param>
        /// <returns></returns>
        //private int GoodsGanreCheck(StockNoShipmentListCndtn stockNoShipmentListCndtn, int BLGoodsCode)                       //DEL 2009/04/24 不具合対応[13022]
        private int GoodsGanreCheck(StockNoShipmentListCndtn stockNoShipmentListCndtn, int BLGoodsCode, out int goodsMGroup)    //ADD 2009/04/24 不具合対応[13022]
        {
            int status = 0;
            BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();

            goodsMGroup = 0;        //ADD 2009/04/24 不具合対応[13022]

            // BLコードマスタ取得
            status = stc_GoodsAcs.GetBLGoodsCd(BLGoodsCode, out bLGoodsCdUMnt);

            if (status == 0)
            {
                // グループコードチェック
                if (stockNoShipmentListCndtn.St_DetailGoodsGanreCode != string.Empty && stockNoShipmentListCndtn.Ed_DetailGoodsGanreCode != string.Empty)
                {
                    // 開始<=終了 範囲内か？
                    //if (int.Parse(stockNoShipmentListCndtn.St_DetailGoodsGanreCode) >= bLGoodsCdUMnt.BLGloupCode ||   //DEL 2009/02/27 不具合対応[12009]
                    //   int.Parse(stockNoShipmentListCndtn.Ed_DetailGoodsGanreCode) <= bLGoodsCdUMnt.BLGloupCode)      //DEL 2009/02/27 不具合対応[12009]
                    if (int.Parse(stockNoShipmentListCndtn.St_DetailGoodsGanreCode) > bLGoodsCdUMnt.BLGloupCode ||      //ADD 2009/02/27 不具合対応[12009]
                       int.Parse(stockNoShipmentListCndtn.Ed_DetailGoodsGanreCode) < bLGoodsCdUMnt.BLGloupCode)         //ADD 2009/02/27 不具合対応[12009]
                    {
                        status = 1;
                        return status;
                    }
                }
                else if (stockNoShipmentListCndtn.St_DetailGoodsGanreCode != string.Empty && stockNoShipmentListCndtn.Ed_DetailGoodsGanreCode == string.Empty)
                {
                    // 開始<=最後まで 範囲内か？
                    //if (int.Parse(stockNoShipmentListCndtn.St_DetailGoodsGanreCode) >= bLGoodsCdUMnt.BLGloupCode)     //DEL 2009/02/27 不具合対応[12009]
                    if (int.Parse(stockNoShipmentListCndtn.St_DetailGoodsGanreCode) > bLGoodsCdUMnt.BLGloupCode)        //ADD 2009/02/27 不具合対応[12009]
                    {
                        status = 1;
                        return status;
                    }
                }
                else if (stockNoShipmentListCndtn.St_DetailGoodsGanreCode == string.Empty && stockNoShipmentListCndtn.Ed_DetailGoodsGanreCode != string.Empty)
                {
                    // 最初から<=終了 範囲内か？
                    //if (int.Parse(stockNoShipmentListCndtn.Ed_DetailGoodsGanreCode) <= bLGoodsCdUMnt.BLGloupCode)     //DEL 2009/02/27 不具合対応[12009]
                    if (int.Parse(stockNoShipmentListCndtn.Ed_DetailGoodsGanreCode) < bLGoodsCdUMnt.BLGloupCode)        //ADD 2009/02/27 不具合対応[12009]
                    {
                        status = 1;
                        return status;
                    }
                }

                BLGroupU bLGroupU = new BLGroupU();

                // BLグループマスタ取得
                stc_GoodsAcs.GetBLGroup(stockNoShipmentListCndtn.EnterpriseCode, bLGoodsCdUMnt.BLGloupCode, out bLGroupU);
                // ---ADD 2009/02/27 不具合対応[12009] -------------------------------->>>>>
                if (bLGroupU == null)
                {
                    // 大分類、中分類に条件が入ってる場合は抽出対象外とする
                    if ((!RangeUtil.GoodsMGroupCode.IsAllRange(stockNoShipmentListCndtn.St_MediumGoodsGanreCode, stockNoShipmentListCndtn.Ed_MediumGoodsGanreCode)) ||
                        (!RangeUtil.GoodsLGroupCode.IsAllRange(stockNoShipmentListCndtn.St_LargeGoodsGanreCode, stockNoShipmentListCndtn.Ed_LargeGoodsGanreCode)))
                    {
                        status = 1;
                    }
                    else
                    {
                        status = 0;
                    }
                    return status;
                }
                // ---ADD 2009/02/27 不具合対応[12009] --------------------------------<<<<<

                goodsMGroup = bLGroupU.GoodsMGroup;         //ADD 2009/04/24 不具合対応[13022]

                // 商品中分類チェック
                if (stockNoShipmentListCndtn.St_MediumGoodsGanreCode != string.Empty && stockNoShipmentListCndtn.Ed_MediumGoodsGanreCode != string.Empty)
                {
                    // 開始<=終了 範囲内か？
                    //if (int.Parse(stockNoShipmentListCndtn.St_MediumGoodsGanreCode) >= bLGroupU.GoodsMGroup ||        //DEL 2009/02/27 不具合対応[12009]
                    //   int.Parse(stockNoShipmentListCndtn.Ed_MediumGoodsGanreCode) <= bLGroupU.GoodsMGroup)           //DEL 2009/02/27 不具合対応[12009]
                    if (int.Parse(stockNoShipmentListCndtn.St_MediumGoodsGanreCode) > bLGroupU.GoodsMGroup ||           //ADD 2009/02/27 不具合対応[12009]
                       int.Parse(stockNoShipmentListCndtn.Ed_MediumGoodsGanreCode) < bLGroupU.GoodsMGroup)              //ADD 2009/02/27 不具合対応[12009]
                    {
                        status = 1;
                        return status;
                    }
                }
                else if (stockNoShipmentListCndtn.St_MediumGoodsGanreCode != string.Empty && stockNoShipmentListCndtn.Ed_MediumGoodsGanreCode == string.Empty)
                {
                    // 開始<=最後まで 範囲内か？
                    //if (int.Parse(stockNoShipmentListCndtn.St_MediumGoodsGanreCode) >= bLGroupU.GoodsMGroup)          //DEL 2009/02/27 不具合対応[12009]
                    if (int.Parse(stockNoShipmentListCndtn.St_MediumGoodsGanreCode) > bLGroupU.GoodsMGroup)             //ADD 2009/02/27 不具合対応[12009]
                    {
                        status = 1;
                        return status;
                    }
                }
                else if (stockNoShipmentListCndtn.St_MediumGoodsGanreCode == string.Empty && stockNoShipmentListCndtn.Ed_MediumGoodsGanreCode != string.Empty)
                {
                    // 最初から<=終了 範囲内か？
                    //if (int.Parse(stockNoShipmentListCndtn.Ed_MediumGoodsGanreCode) <= bLGroupU.GoodsMGroup)          //DEL 2009/02/27 不具合対応[12009]
                    if (int.Parse(stockNoShipmentListCndtn.Ed_MediumGoodsGanreCode) < bLGroupU.GoodsMGroup)             //ADD 2009/02/27 不具合対応[12009]
                    {
                        status = 1;
                        return status;
                    }
                }

                // 商品大分類チェック
                if (stockNoShipmentListCndtn.St_LargeGoodsGanreCode != string.Empty && stockNoShipmentListCndtn.Ed_LargeGoodsGanreCode != string.Empty)
                {
                    // 開始<=終了 範囲内か？
                    //if (int.Parse(stockNoShipmentListCndtn.St_LargeGoodsGanreCode) >= bLGroupU.GoodsLGroup ||         //DEL 2009/02/27 不具合対応[12009]
                    //   int.Parse(stockNoShipmentListCndtn.Ed_LargeGoodsGanreCode) <= bLGroupU.GoodsLGroup)            //DEL 2009/02/27 不具合対応[12009]
                    if (int.Parse(stockNoShipmentListCndtn.St_LargeGoodsGanreCode) > bLGroupU.GoodsLGroup ||            //ADD 2009/02/27 不具合対応[12009]
                       int.Parse(stockNoShipmentListCndtn.Ed_LargeGoodsGanreCode) < bLGroupU.GoodsLGroup)               //ADD 2009/02/27 不具合対応[12009]
                    {
                        status = 1;
                        return status;
                    }
                }
                else if (stockNoShipmentListCndtn.St_LargeGoodsGanreCode != string.Empty && stockNoShipmentListCndtn.Ed_LargeGoodsGanreCode == string.Empty)
                {
                    // 開始<=最後まで 範囲内か？
                    //if (int.Parse(stockNoShipmentListCndtn.St_LargeGoodsGanreCode) >= bLGroupU.GoodsLGroup)           //DEL 2009/02/27 不具合対応[12009]
                    if (int.Parse(stockNoShipmentListCndtn.St_LargeGoodsGanreCode) > bLGroupU.GoodsLGroup)              //ADD 2009/02/27 不具合対応[12009]
                    {
                        status = 1;
                        return status;
                    }
                }
                else if (stockNoShipmentListCndtn.St_LargeGoodsGanreCode == string.Empty && stockNoShipmentListCndtn.Ed_LargeGoodsGanreCode != string.Empty)
                {
                    // 最初から<=終了 範囲内か？
                    //if (int.Parse(stockNoShipmentListCndtn.Ed_LargeGoodsGanreCode) <= bLGroupU.GoodsLGroup)           //DEL 2009/02/27 不具合対応[12009]
                    if (int.Parse(stockNoShipmentListCndtn.Ed_LargeGoodsGanreCode) < bLGroupU.GoodsLGroup)              //ADD 2009/02/27 不具合対応[12009]
                    {
                        status = 1;
                        return status;
                    }
                }
            }
            else
            {
                //status = 1;               //DEL 2009/02/27 不具合対応[12009]
                // ---ADD 2009/02/27 不具合対応[12009] -------------------------------->>>>>
                // グループ、大分類、中分類に条件が入ってる場合は抽出対象外とする
                if ((!RangeUtil.BLGroupCode.IsAllRange(stockNoShipmentListCndtn.St_DetailGoodsGanreCode, stockNoShipmentListCndtn.Ed_DetailGoodsGanreCode)) ||
                    (!RangeUtil.GoodsMGroupCode.IsAllRange(stockNoShipmentListCndtn.St_MediumGoodsGanreCode, stockNoShipmentListCndtn.Ed_MediumGoodsGanreCode)) ||
                    (!RangeUtil.GoodsLGroupCode.IsAllRange(stockNoShipmentListCndtn.St_LargeGoodsGanreCode, stockNoShipmentListCndtn.Ed_LargeGoodsGanreCode)))
                {
                    status = 1;
                }
                else
                {
                    status = 0;
                }
                // ---ADD 2009/02/27 不具合対応[12009] --------------------------------<<<<<
            }

            return status;
        }
        //--- ADD 2008/07/22 ----------<<<<<

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

        // ---DEL 2009/05/01 不具合対応[12801] ------------------------------------->>>>>
        //// --- ADD 2009/04/24 不具合対応[13022] -------------------------------->>>>>
        ///// <summary>
        ///// 商品管理情報マスタ取得処理
        ///// </summary>
        ///// <param name="goodsMGroup"></param>
        ///// <param name="stockNoShipmentListWork"></param>
        ///// <param name="supplierCd"></param>
        ///// <param name="supplierSnm"></param>
        ///// <returns></returns>
        //private void GetGoodsMngInfo(StockNoShipmentListWork stockNoShipmentListWork, int goodsMGroup, out int supplierCd, out string supplierSnm)
        //{
        //    supplierCd = 0;
        //    supplierSnm = "";

        //    GoodsUnitData goodsUnitData = new GoodsUnitData();
        //    goodsUnitData.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        //    goodsUnitData.GoodsMakerCd = stockNoShipmentListWork.GoodsMakerCd;
        //    goodsUnitData.GoodsNo = stockNoShipmentListWork.GoodsNo;
        //    goodsUnitData.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
        //    goodsUnitData.GoodsMGroup = goodsMGroup;
        //    goodsUnitData.BLGoodsCode = stockNoShipmentListWork.BLGoodsCode;

        //    stc_GoodsAcs.GetGoodsMngInfo(ref goodsUnitData);

        //    supplierCd = goodsUnitData.SupplierCd;
        //    if (supplierCd == 0)
        //    {
        //        supplierSnm = "未登録";
        //    }
        //    else
        //    {
        //        SupplierWork supplierWork = null;
        //        int status = stc_GoodsAcs.GetSupplier(LoginInfoAcquisition.EnterpriseCode, goodsUnitData.SupplierCd, out supplierWork);
        //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            supplierSnm = supplierWork.SupplierSnm;
        //        }
        //        else
        //        {
        //            supplierSnm = "未登録";
        //        }
        //    }
        //}
        //// --- ADD 2009/04/24 不具合対応[13022] --------------------------------<<<<<
        // ---DEL 2009/05/01 不具合対応[12801] -------------------------------------<<<<<
        // ---ADD 2009/05/01 不具合対応[12801] ------------------------------------->>>>>
        /// <summary>
        /// 商品情報取得処理
        /// </summary>
        /// <param name="goodsMakerCd">メーカー</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="goodsMGroup">中分類</param>
        /// <param name="blGoodsCode">ＢＬコード</param>
        /// <returns>商品情報</returns>
        /// <remarks>
        /// <br>Note       : 商品アクセスクラスから商品情報を取得します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/05/01</br>
        /// </remarks>
        private GoodsUnitData GetGoodsUnitData(int goodsMakerCd, string goodsNo, int goodsMGroup, int blGoodsCode)
        {
            GoodsUnitData goodsUnitData = new GoodsUnitData();

            //抽出条件設定
            GoodsCndtn goodsCndtn = new GoodsCndtn();
            goodsCndtn.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            goodsCndtn.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
            goodsCndtn.GoodsNoSrchTyp = 0;
            goodsCndtn.GoodsMakerCd = goodsMakerCd;
            goodsCndtn.GoodsNo = goodsNo;
            goodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;

            goodsCndtn.GoodsKindCode = 9; // 商品属性 9:全て // ADD 2011/05/18

            //抽出
            string msg = string.Empty;
            List<GoodsUnitData> goodsUnitDataList = null;
            // -- UPD 2011/05/18 ---------------------->>>
            //int status = stc_GoodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtn, out goodsUnitDataList, out msg);
            int status = stc_GoodsAcs.GoodsOnlySearch(goodsCndtn, out goodsUnitDataList, out msg);
            // -- UPD 2011/05/18 ----------------------<<<
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                goodsUnitData = goodsUnitDataList[0];
            }

            return goodsUnitData;
        }
        // ---ADD 2009/05/01 不具合対応[12801] -------------------------------------<<<<<
        #endregion

        // --- ADD 2009/04/24 不具合対応[13022] -------------------------------->>>>>
        #region ◎ フィルタ作成
        /// <summary>
        /// フィルタ作成
        /// </summary>
        /// <returns>フィルタ文字列</returns>
        private string GetFilter(StockNoShipmentListCndtn stockNoShipmentListCndtn)
        {
            string strQuery = "";

            if ((stockNoShipmentListCndtn.St_CustomerCode != 0) && (stockNoShipmentListCndtn.Ed_CustomerCode != 0))
            {
                strQuery = String.Format("{0} <= {1} AND {2} <= {3}",
                stockNoShipmentListCndtn.St_CustomerCode.ToString(),
                DCZAI02165EA.ct_Col_CustomerCode,
                DCZAI02165EA.ct_Col_CustomerCode,
                stockNoShipmentListCndtn.Ed_CustomerCode.ToString());
            }

            if ((stockNoShipmentListCndtn.St_CustomerCode != 0) && (stockNoShipmentListCndtn.Ed_CustomerCode == 0))
            {
                strQuery = String.Format("{0} <= {1}",
                stockNoShipmentListCndtn.St_CustomerCode.ToString(),
                DCZAI02165EA.ct_Col_CustomerCode);
            }

            if ((stockNoShipmentListCndtn.St_CustomerCode == 0) && (stockNoShipmentListCndtn.Ed_CustomerCode != 0))
            {
                strQuery = String.Format("{0} <= {1}",
                DCZAI02165EA.ct_Col_CustomerCode,
                stockNoShipmentListCndtn.Ed_CustomerCode.ToString());
            }

            return strQuery;
        }
        #endregion
        // --- ADD 2009/04/24 不具合対応[13022] --------------------------------<<<<<

		#region ◎ ソート順作成
		/// <summary>
		/// ソート順作成
		/// </summary>
		/// <returns>ソート文字列</returns>
		private string GetSortOrder( StockNoShipmentListCndtn stockNoShipmentListCndtn )
		{
			StringBuilder strSortOrder = new StringBuilder();

            //if ( !stockNoShipmentListCndtn.IsSelectAllSection )
            //{
            //    // 全社選択されてないとき
            //    // 主拠点
            //    strSortOrder.Append( string.Format("{0},", DCZAI02165EA.ct_Col_SectionCode ) );
            //}

            if ( stockNoShipmentListCndtn.PrintSortDiv == StockNoShipmentListCndtn.PrintSortDivState.ByCustomer ) {
                // ＜＜　仕入先順　＞＞
                // 拠点コード
                //strSortOrder.Append(string.Format("{0},", DCZAI02165EA.ct_Col_Sort_SectionCode));         //DEL 2009/04/24 不具合対応[12996]
                // 倉庫コード
                strSortOrder.Append(string.Format("{0},", DCZAI02165EA.ct_Col_Sort_WarehouseCode));
                // 仕入先コード
                strSortOrder.Append(string.Format("{0},", DCZAI02165EA.ct_Col_Sort_CustomerCode));
			    // メーカーコード
                strSortOrder.Append(string.Format("{0},", DCZAI02165EA.ct_Col_Sort_GoodsMakerCd));
                // ---ADD 2009/03/18 不具合対応[12544] ------------------------------------>>>>>
                // BLコード
                strSortOrder.Append(string.Format("{0},", DCZAI02165EA.ct_Col_Sort_BLGoodsCode));
                // ---ADD 2009/03/18 不具合対応[12544] ------------------------------------<<<<<
			    // 商品コード
                strSortOrder.Append(string.Format("{0}", DCZAI02165EA.ct_Col_Sort_GoodsNo));
            }
            else if ( stockNoShipmentListCndtn.PrintSortDiv == StockNoShipmentListCndtn.PrintSortDivState.ByWarehouseShelfNo ) {
                // ＜＜　棚番順　＞＞
                // 拠点コード
                //strSortOrder.Append(string.Format("{0},", DCZAI02165EA.ct_Col_Sort_SectionCode));         //DEL 2009/04/24 不具合対応[12996]
                // 倉庫コード
                strSortOrder.Append(string.Format("{0},", DCZAI02165EA.ct_Col_Sort_WarehouseCode));
                // 棚番ブレイク
                strSortOrder.Append(string.Format("{0},", DCZAI02165EA.ct_Col_Sort_WarehouseShelfNoBreak));
                // 棚番
                strSortOrder.Append(string.Format("{0},", DCZAI02165EA.ct_Col_Sort_WarehouseShelfNo));
                // ---ADD 2009/03/18 不具合対応[12544] ------------------------------------>>>>>
                // BLコード
                strSortOrder.Append(string.Format("{0},", DCZAI02165EA.ct_Col_Sort_BLGoodsCode));
                // ---ADD 2009/03/18 不具合対応[12544] ------------------------------------<<<<<
                // 商品コード
                strSortOrder.Append(string.Format("{0},", DCZAI02165EA.ct_Col_Sort_GoodsNo));
                /* ---DEL 2009/03/18 不具合対応[12544] ------------------------------------>>>>>
                // メーカーコード
                strSortOrder.Append(string.Format("{0}", DCZAI02165EA.ct_Col_Sort_GoodsMakerCd));
                   ---DEL 2009/03/18 不具合対応[12544] ------------------------------------<<<<< */
                // ---ADD 2009/03/18 不具合対応[12544] ------------------------------------>>>>>
                // 仕入先コード
                strSortOrder.Append(string.Format("{0},", DCZAI02165EA.ct_Col_Sort_CustomerCode));
                // メーカーコード
                strSortOrder.Append(string.Format("{0}", DCZAI02165EA.ct_Col_Sort_GoodsMakerCd));
                // ---ADD 2009/03/18 不具合対応[12544] ------------------------------------<<<<<
            }

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

        // ---ADD 2009/05/01 不具合対応[12801] ------------------------>>>>>
        #region ◆ 計算原価額取得関連
        #region 初期設定
        #region TaxRateSetRead(税率設定マスタアクセスクラス(Read))
        /// <summary>
        /// 税率設定マスタアクセスクラス(Read)
        /// </summary>
        /// <param name="taxRateSet">税率設定情報クラス</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 税率設定マスタアクセスクラスから税率設定情報を取得します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/05/01</br>
        /// </remarks>
        private int TaxRateSetRead(out TaxRateSet taxRateSet)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 税率設定情報を取得
            status = this._taxRateSetAcs.Read(out taxRateSet, LoginInfoAcquisition.EnterpriseCode, 0);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                taxRateSet = new TaxRateSet();
            }

            return status;
        }
        #endregion

        #region GetTaxRate(税率取得(税率設定マスタ))
        /// <summary>
        /// 税率取得(税率設定マスタ)
        /// </summary>
        /// <param name="taxRateSet">税率設定情報</param>
        /// <param name="targetDate">税率適用日</param>
        /// <returns>TtlAmntDspRateDivCd</returns>
        /// <remarks>
        /// <br>Note       : 税率取得情報から税率を取得します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/05/01</br>
        /// </remarks>
        private double GetTaxRate(TaxRateSet taxRateSet, DateTime targetDate)
        {
            return TaxRateSetAcs.GetTaxRate(taxRateSet, targetDate);
        }
        #endregion

        #region ReadInitData(初期データ設定処理(単価算出モジュール))
        /// <summary>
        /// 初期データ設定処理(単価算出モジュール)
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 単価算出モジュールの初期データを設定をします。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/05/01</br>
        /// </remarks>
        private void ReadInitData()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            StockProcMoneyAcs stockProcMoneyAcs = new StockProcMoneyAcs();
            List<StockProcMoney> stockProcMoneyList = new List<StockProcMoney>();

            // 仕入金額データの取得
            ArrayList returnStockProcMoney = null;
            status = stockProcMoneyAcs.Search(out returnStockProcMoney, LoginInfoAcquisition.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (StockProcMoney stockProcMoney in (ArrayList)returnStockProcMoney)
                {
                    stockProcMoneyList.Add(stockProcMoney.Clone());
                }
            }

            // 仕入金額端数処理区分設定マスタキャッシュ処理
            this._unitPriceCalculation.CacheStockProcMoneyList(stockProcMoneyList);
        }
        #endregion
        #endregion

        #region 計算原価額取得
        #region CalculateUnitCost(原価単価計算処理(単価算出モジュール))
        /// <summary>
        /// 原価単価計算処理(単価算出モジュール)
        /// </summary>
        /// <param name="goodsUnitData">商品連結データ</param>
        /// <param name="taxRate">税率</param>
        /// <param name="unitPriceCalcRet">単価計算結果</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 原価単価計算を行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/05/01</br>
        /// </remarks>
        private void CalculateUnitCost(GoodsUnitData goodsUnitData, double taxRate, out UnitPriceCalcRet unitPriceCalcRet)
        {
            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
            unitPriceCalcRet = new UnitPriceCalcRet();

            // パラメータ設定
            unitPriceCalcParam.SectionCode = goodsUnitData.SectionCode.TrimEnd();           // 拠点コード
            unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                   // 商品メーカーコード
            unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                             // 品番
            unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                 // 商品掛率ランク
            unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsRateGrpCode;           // 商品掛率グループコード
            unitPriceCalcParam.BLGroupCode = goodsUnitData.BLGroupCode;                     // BLグループコード
            unitPriceCalcParam.BLGoodsCode = goodsUnitData.BLGoodsCode;                     // BL商品コード
            unitPriceCalcParam.SupplierCd = goodsUnitData.SupplierCd;                       // 仕入先コード
            unitPriceCalcParam.PriceApplyDate = DateTime.Now;                               // 価格適用日
            unitPriceCalcParam.CountFl = 1.0;                                               // 数量            
            unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;                 // 課税区分
            unitPriceCalcParam.TaxRate = taxRate;                                           // 税率
            unitPriceCalcParam.StockCnsTaxFrcProcCd = goodsUnitData.StockCnsTaxFrcProcCd;   // 仕入消費税端数処理コード
            unitPriceCalcParam.StockUnPrcFrcProcCd = goodsUnitData.StockUnPrcFrcProcCd;     // 仕入単価端数処理コード

            // 原価単価計算処理
            List<UnitPriceCalcRet> unitPriceCalcRetList = null;
            this._unitPriceCalculation.CalculateUnitCost(unitPriceCalcParam, goodsUnitData, out unitPriceCalcRetList);
            foreach (UnitPriceCalcRet unitPriceCalcRetWk in unitPriceCalcRetList)
            {
                if (unitPriceCalcRetWk.UnitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
                {
                    // 原価単価を取得
                    unitPriceCalcRet = unitPriceCalcRetWk;
                    return;
                }
            }
        }
        #endregion
        #endregion

        #region 在庫管理全体設定
        #region ReadStockMngTtlSt(在庫全体管理設定読み込み)
        /// <summary>
        /// 在庫全体管理設定読み込み
        /// </summary>
        /// <remarks>
        /// <br>Note       : 在庫管理全体設定情報を取得します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/05/01</br>
        /// </remarks>
        private void ReadStockMngTtlSt()
        {
            ArrayList retList;

            int statusMngTtlSt = _stockMngTtlStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
            if (statusMngTtlSt == 0)
            {
                foreach (StockMngTtlSt stockMngTtlSt in retList)
                {
                    if ((stockMngTtlSt.LogicalDeleteCode == 0) && (stockMngTtlSt.SectionCode.Trim() == "00"))
                    {
                        this._stockMngTtlSt = stockMngTtlSt;
                        break;
                    }
                }
            }
            else
            {
                this._stockMngTtlSt = new StockMngTtlSt();
            }
        }
        #endregion

        #region StockTotalPriceToLong(在庫金額算出)
        /// <summary>
        /// 在庫金額算出(Long型で返す)
        /// </summary>
        /// <param name="unitCount">数量</param>
        /// <param name="unitCost">原価</param>
        /// <returns>在庫金額</returns>
        /// <remarks>
        /// <br>Note       : 在庫金額を算出します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/05/01</br>
        /// </remarks>
        private long StockTotalPriceToLong(double unitCount, double unitCost)
        {
            long longStockTotalPrice = 0;
            double doubleStockTotalPrice = unitCost * unitCount;       // 原単価×現在庫数

            // 在庫全体管理設定の端数処理区分に従う
            switch (this._stockMngTtlSt.FractionProcCd)
            {
                case 1:
                    {
                        // 切り捨て
                        longStockTotalPrice = (long)(doubleStockTotalPrice / 1);
                        break;
                    }
                case 2:
                    {
                        // 四捨五入
                        if (doubleStockTotalPrice >= 0)
                        {
                            longStockTotalPrice = (long)((doubleStockTotalPrice + 0.5) / 1);
                        }
                        else
                        {
                            longStockTotalPrice = (long)((doubleStockTotalPrice - 0.5) / 1);
                        }
                        break;
                    }
                case 3:
                    {
                        // 切り上げ
                        if (doubleStockTotalPrice % 1 == 0)
                        {
                            longStockTotalPrice = (long)(doubleStockTotalPrice);
                        }
                        else
                        {
                            if (doubleStockTotalPrice >= 0)
                            {
                                longStockTotalPrice = (long)((doubleStockTotalPrice + 1) / 1);
                            }
                            else
                            {
                                longStockTotalPrice = (long)((doubleStockTotalPrice - 1) / 1);
                            }
                        }
                        break;
                    }
                default:
                    {
                        longStockTotalPrice = (long)(doubleStockTotalPrice);
                        break;
                    }
            }

            return longStockTotalPrice;
        }
        #endregion
        #endregion
        #endregion ◆ 計算原価額取得関連
        // ---ADD 2009/05/01 不具合対応[12801] ------------------------<<<<<

		#endregion ■ Private Method
	}
}

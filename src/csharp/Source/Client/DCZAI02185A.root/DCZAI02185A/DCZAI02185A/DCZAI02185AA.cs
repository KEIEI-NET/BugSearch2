//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 過剰在庫一覧表
// プログラム概要   : 過剰在庫一覧表で使用するデータの取得を行う。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 疋田 勇人
// 作 成 日  2007/11/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/10/01  修正内容 : バグ修正、仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 行澤 仁美
// 修 正 日  2008/10/03  修正内容 : バグ修正、仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/02/24  修正内容 : 障害対応11758,11806 仕入先コードの取得処理を追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/02/27  修正内容 : 障害対応12031 抽出条件不正の修正
//----------------------------------------------------------------------------//
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/04/23  修正内容 : 不具合対応[12778][12999]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/04/30  修正内容 : 不具合対応[11972]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/05/01  修正内容 : 不具合対応[12778] マイナス時、端数処理不正となる為、修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 長内 数馬
// 修 正 日  2011/03/16  修正内容 : 速度チューニング
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
    /// 在庫過剰一覧表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 在庫過剰一覧表で使用するデータを取得する。</br>
    /// <br>Programmer   : 20081 疋田 勇人</br>
    /// <br>Date         : 2007.11.13</br>
    /// <br></br>
    /// <br>UpdateNote   : 2008.07.15 30416 長沼 賢二</br>
    /// <br>UpdateNote   : 2008/10/01       照田 貴志　バグ修正、仕様変更対応</br>
    /// <br>UpdateNote   : 2008/10/03 30462 行澤 仁美　バグ修正、仕様変更対応</br>
    /// <br>Update Note  : 2009/02/24 30452 上野 俊治</br>
    /// <br>               ・障害対応11758,11806 仕入先コードの取得処理を追加</br>
    /// <br>Update Note  : 2009/02/27 30452 上野 俊治</br>
    /// <br>               ・障害対応12031 抽出条件不正の修正</br>
    /// <br>             : 2009/04/23       照田 貴志　不具合対応[12778]</br>
    /// <br>             : 2009/04/30       照田 貴志　不具合対応[11972]</br>
    /// <br>             : 2009/05/01       照田 貴志　不具合対応[12778] マイナス時、端数処理不正となる為、修正</br>
    /// </remarks>
	public class StockOverListAcs
	{
		#region ■ Constructor
		/// <summary>
		/// 在庫過剰一覧表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫過剰一覧表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.11.13</br>
		/// </remarks>
		public StockOverListAcs()
		{
            this._iStockOverListWorkDB = (IStockOverListWorkDB)MediationStockOverListWorkDB.GetStockOverListWorkDB();

            // ---ADD 2009/04/30 不具合対応[11972] ----------------------------------->>>>>
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
            // ---ADD 2009/04/30 不具合対応[11972] -----------------------------------<<<<<
		}

		/// <summary>
		/// 在庫過剰一覧表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫過剰一覧表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.11.13</br>
		/// </remarks>
        static StockOverListAcs ()
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

            stc_GoodsAcs.IsGetSupplier = true;          //ADD 2009/04/23 不具合対応[12778]
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
		private static PrtOutSet stc_PrtOutSet;			        // 帳票出力設定データクラス
		private static PrtOutSetAcs stc_PrtOutSetAcs;	        // 帳票出力設定アクセスクラス
        private static SecInfoAcs stc_SecInfoAcs;               // 拠点アクセスクラス
        private static Dictionary<string, SecInfoSet> stc_SectionDic;   // 拠点Dictionary
        //--- ADD 2008/07/22 ---------->>>>>
        private static GoodsAcs stc_GoodsAcs;                   // 商品アクセスクラス
        //--- ADD 2008/07/22 ----------<<<<<
        #endregion ■ Static Member

		#region ■ Private Member
        IStockOverListWorkDB _iStockOverListWorkDB;

		private DataTable _stockOverListDt;		  // 印刷DataTable
		private DataView _stockOverListDataView;  // 印刷DataView

        // ---ADD 2009/04/30 不具合対応[11972] ------------------------------------------------->>>>>
        private TaxRateSetAcs _taxRateSetAcs = null;                    //税率設定マスタアクセス
        private UnitPriceCalculation _unitPriceCalculation = null;      //単価算出モジュール
        private StockMngTtlStAcs _stockMngTtlStAcs = null;              //在庫全体設定マスタアクセス
        private StockMngTtlSt _stockMngTtlSt = null;                    //在庫管理全体設定
        private double _taxRate = 0.0;                                  //税率
        // ---ADD 2009/04/30 不具合対応[11972] -------------------------------------------------<<<<<

        // -- ADD 2011/03/16 --------------------------->>>
        private Dictionary<string,GoodsUnitData> goodsUnitDataDic = null;
        private Dictionary<string,UnitPriceCalcRet> unitPriceCalcRetDic = null;
        // -- ADD 2011/03/16 ---------------------------<<<
        #endregion ■ Private Member

		#region ■ Public Property
		/// <summary>
		/// 印刷データセット(読み取り専用)
		/// </summary>
		public DataView StockOverListDataView
		{
			get{ return this._stockOverListDataView; }
		}
		#endregion ■ Public Property

		#region ■ Public Method
		#region ◆ 出力データ取得
		#region ◎ 入金データ取得
		/// <summary>
		/// データ取得
		/// </summary>
		/// <param name="stockOverListCndtn">抽出条件</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷するデータを取得する。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.11.13</br>
		/// </remarks>
        public int SearchMain( StockOverListCndtn stockOverListCndtn, out string errMsg)
		{
            return this.SearchProc(stockOverListCndtn, out errMsg);
		}
		#endregion
		#endregion ◆ 出力データ取得
		#endregion ■ Public Method

		#region ■ Private Method
		#region ◆ 帳票データ取得
		#region ◎ 在庫データ取得
		/// <summary>
		/// 在庫データ取得
		/// </summary>
		/// <param name="stockOverListCndtn"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する在庫データを取得する。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.11.13</br>
		/// </remarks>
        private int SearchProc( StockOverListCndtn stockOverListCndtn, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

			try
			{
				// DataTable Create ----------------------------------------------------------
				DCZAI02184EA.CreateDataTable( ref this._stockOverListDt );

                StockOverListCndtnWork stockOverListCndtnWork = new StockOverListCndtnWork();
				// 抽出条件展開  --------------------------------------------------------------
				status = this.DevStockMoveCndtn( stockOverListCndtn, out stockOverListCndtnWork, out errMsg );
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

				// データ取得  ----------------------------------------------------------------
				object retStockMoveList = null;
                
                status = this._iStockOverListWorkDB.Search( out retStockMoveList, stockOverListCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);
                //--- TEST --------->>>>>
                //retStockMoveList = this.GetTestData();
                //status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //--- TEST ---------<<<<<

                switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						// データ展開処理
                        DevStockMoveData(stockOverListCndtn, (ArrayList)retStockMoveList);
                        //status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;       //DEL 2008/10/01 データが無い状態でもNORMALで返る為
                        // --- ADD 2008/10/01 --------------------------------------------------------->>>>>
                        if (this._stockOverListDataView.Count == 0)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        // --- ADD 2008/10/01 ---------------------------------------------------------<<<<<
                        break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
					default:
						errMsg = "在庫データの取得に失敗しました。";
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

            StockOverListResultWork work = new StockOverListResultWork();

            work.SectionCode = "01";				// 拠点コード
            work.SectionGuideNm = "拠点01";		    // 拠点ガイド名称
            work.GoodsNo = "20";					// 商品コード
            work.GoodsName = "P901_ブルー";			// 商品名称
            work.StockUnitPriceFl = 45000;			// 仕入単価
            work.WarehouseCode = "0001";            // 倉庫コード
            work.WarehouseName = "倉庫01";          // 倉庫名称
            work.WarehouseShelfNo = "02";           // 棚番
            work.BLGoodsCode = 1;                   // BLコード
            //--- DEL 2008/10/03 不具合対応[6057] ---------->>>>>
            //work.DuplicationShelfNo1 = "7";         // 管理区分1
            //work.DuplicationShelfNo2 = "8";         // 管理区分2
            //--- DEL 2008/10/03 不具合対応[6057] ----------<<<<<
            //--- ADD 2008/10/03 不具合対応[6057] ---------->>>>>
            work.PartsManagementDivide1 = "7";         // 管理区分1
            work.PartsManagementDivide2 = "8";         // 管理区分2
            //--- ADD 2008/10/03 不具合対応[6057] ----------<<<<<
            work.GoodsMakerCd = 1;                  // 品番
            work.MaximumStockCnt = 100;             //
            work.MinimumStockCnt = 1;               //
            work.SalesOrderCount = 2;               //
            work.SupplierCd = 123;                  // 仕入先コード
            work.SupplierSnm = "仕入先１";          // 仕入先略称
            work.ShipmentCnt = 10;
            work.ShipmentPosCnt = 100;

            list.Add(work);

            StockOverListResultWork work1 = new StockOverListResultWork();

            work1.SectionCode = "02";				// 拠点コード
            work1.SectionGuideNm = "拠点02";		// 拠点ガイド名称
            work1.GoodsNo = "20";					// 商品コード
            work1.GoodsName = "P901_ブルー";	    // 商品名称
            work1.StockUnitPriceFl = 45000;			// 仕入単価
            work1.WarehouseCode = "0001";           // 倉庫コード
            work1.WarehouseName = "倉庫01";         // 倉庫名称
            work1.WarehouseShelfNo = "02";          // 棚番
            work1.BLGoodsCode = 1;                  // BLコード
            //--- DEL 2008/10/03 不具合対応[6057] ---------->>>>>
            //work1.DuplicationShelfNo1 = "7";        // 管理区分1
            //work1.DuplicationShelfNo2 = "8";        // 管理区分2
            //--- DEL 2008/10/03 不具合対応[6057] ----------<<<<<
            //--- ADD 2008/10/03 不具合対応[6057] ---------->>>>>
            work1.PartsManagementDivide1 = "7";        // 管理区分1
            work1.PartsManagementDivide2 = "8";        // 管理区分2
            //--- ADD 2008/10/03 不具合対応[6057] ----------<<<<<
            work1.GoodsMakerCd = 1;                 // 品番
            work1.MaximumStockCnt = 100;            //
            work1.MinimumStockCnt = 1;              //
            work1.SalesOrderCount = 2;              //
            work1.SupplierCd = 122;                 // 仕入先コード
            work1.SupplierSnm = "仕入先０";         // 仕入先略称
            work1.ShipmentCnt = 10;
            work1.ShipmentPosCnt = 100;

            list.Add(work1);

            StockOverListResultWork work2 = new StockOverListResultWork();

            work2.SectionCode = "01";				// 拠点コード
            work2.SectionGuideNm = "拠点01";		// 拠点ガイド名称
            work2.GoodsNo = "20";					// 商品コード
            work2.GoodsName = "P901_ブルー";	    // 商品名称
            work2.StockUnitPriceFl = 45000;			// 仕入単価
            work2.WarehouseCode = "0001";           // 倉庫コード
            work2.WarehouseName = "倉庫01";         // 倉庫名称
            work2.WarehouseShelfNo = "01";          // 棚番
            work2.BLGoodsCode = 1;                  // BLコード
            //--- DEL 2008/10/03 不具合対応[6057] ---------->>>>>
            //work2.DuplicationShelfNo1 = "7";        // 管理区分1
            //work2.DuplicationShelfNo2 = "8";        // 管理区分2
            //--- DEL 2008/10/03 不具合対応[6057] ----------<<<<<
            //--- ADD 2008/10/03 不具合対応[6057] ---------->>>>>
            work2.PartsManagementDivide1 = "7";        // 管理区分1
            work2.PartsManagementDivide2 = "8";        // 管理区分2
            //--- ADD 2008/10/03 不具合対応[6057] ----------<<<<<
            work2.GoodsMakerCd = 1;                 // 品番
            work2.MaximumStockCnt = 100;            //
            work2.MinimumStockCnt = 1;              //
            work2.SalesOrderCount = 2;              //
            work2.SupplierCd = 122;                 // 仕入先コード
            work2.SupplierSnm = "仕入先０";         // 仕入先略称
            work2.ShipmentCnt = 10;
            work2.ShipmentPosCnt = 100;

            list.Add(work2);


            StockOverListResultWork work3 = new StockOverListResultWork();

            work3.SectionCode = "02";				// 拠点コード
            work3.SectionGuideNm = "拠点02";		// 拠点ガイド名称
            work3.GoodsNo = "20";					// 商品コード
            work3.GoodsName = "P901_ブルー";	    // 商品名称
            work3.StockUnitPriceFl = 45000;			// 仕入単価
            work3.WarehouseCode = "0001";           // 倉庫コード
            work3.WarehouseName = "倉庫01";         // 倉庫名称
            work3.WarehouseShelfNo = "01";          // 棚番
            work3.BLGoodsCode = 1;                  // BLコード
            //--- DEL 2008/10/03 不具合対応[6057] ---------->>>>>
            //work3.DuplicationShelfNo1 = "7";        // 管理区分1
            //work3.DuplicationShelfNo2 = "8";        // 管理区分2
            //--- DEL 2008/10/03 不具合対応[6057] ----------<<<<<
            //--- ADD 2008/10/03 不具合対応[6057] ---------->>>>>
            work3.PartsManagementDivide1 = "7";        // 管理区分1
            work3.PartsManagementDivide2 = "8";        // 管理区分2
            //--- ADD 2008/10/03 不具合対応[6057] ----------<<<<<
            work3.GoodsMakerCd = 1;                 // 品番
            work3.MaximumStockCnt = 100;            //
            work3.MinimumStockCnt = 1;              //
            work3.SalesOrderCount = 2;              //
            work3.SupplierCd = 123;                 // 仕入先コード
            work3.SupplierSnm = "仕入先１";         // 仕入先略称
            work3.ShipmentCnt = 10;
            work3.ShipmentPosCnt = 100;

            list.Add(work3);


            StockOverListResultWork work4 = new StockOverListResultWork();

            work4.SectionCode = "02";				// 拠点コード
            work4.SectionGuideNm = "拠点02";		// 拠点ガイド名称
            work4.GoodsNo = "20";					// 商品コード
            work4.GoodsName = "P901_ブルー";	    // 商品名称
            work4.StockUnitPriceFl = 45000;			// 仕入単価
            work4.WarehouseCode = "0001";           // 倉庫コード
            work4.WarehouseName = "倉庫01";         // 倉庫名称
            work4.WarehouseShelfNo = "01";          // 棚番
            work4.BLGoodsCode = 1;                  // BLコード
            //--- DEL 2008/10/03 不具合対応[6057] ---------->>>>>
            //work4.DuplicationShelfNo1 = "7";        // 管理区分1
            //work4.DuplicationShelfNo2 = "8";        // 管理区分2
            //--- DEL 2008/10/03 不具合対応[6057] ----------<<<<<
            //--- ADD 2008/10/03 不具合対応[6057] ---------->>>>>
            work4.PartsManagementDivide1 = "7";        // 管理区分1
            work4.PartsManagementDivide2 = "8";        // 管理区分2
            //--- ADD 2008/10/03 不具合対応[6057] ----------<<<<<
            work4.GoodsMakerCd = 1;                 // 品番
            work4.MaximumStockCnt = 100;            //
            work4.MinimumStockCnt = 1;              //
            work4.SalesOrderCount = 2;              //
            work4.SupplierCd = 123;                 // 仕入先コード
            work4.SupplierSnm = "仕入先１";         // 仕入先略称
            work4.ShipmentCnt = 10;
            work4.ShipmentPosCnt = 100;

            list.Add(work4);

            StockOverListResultWork work5 = new StockOverListResultWork();

            work5.SectionCode = "02";				// 拠点コード
            work5.SectionGuideNm = "拠点02";		// 拠点ガイド名称
            work5.GoodsNo = "20";					// 商品コード
            work5.GoodsName = "P901_ブルー";	    // 商品名称
            work5.StockUnitPriceFl = 45000;			// 仕入単価
            work5.WarehouseCode = "0001";           // 倉庫コード
            work5.WarehouseName = "倉庫01";         // 倉庫名称
            work5.WarehouseShelfNo = "01";          // 棚番
            work5.BLGoodsCode = 1;                  // BLコード
            //--- DEL 2008/10/03 不具合対応[6057] ---------->>>>>
            //work5.DuplicationShelfNo1 = "7";        // 管理区分1
            //work5.DuplicationShelfNo2 = "8";        // 管理区分2
            //--- DEL 2008/10/03 不具合対応[6057] ----------<<<<<
            //--- ADD 2008/10/03 不具合対応[6057] ---------->>>>>
            work5.PartsManagementDivide1 = "7";        // 管理区分1
            work5.PartsManagementDivide2 = "8";        // 管理区分2
            //--- ADD 2008/10/03 不具合対応[6057] ----------<<<<<
            work5.GoodsMakerCd = 1;                 // 品番
            work5.MaximumStockCnt = 100;            //
            work5.MinimumStockCnt = 1;              //
            work5.SalesOrderCount = 2;              //
            work5.SupplierCd = 123;                 // 仕入先コード
            work5.SupplierSnm = "仕入先１";         // 仕入先略称
            work5.ShipmentCnt = 10;
            work5.ShipmentPosCnt = 100;

            list.Add(work5);

            StockOverListResultWork work6 = new StockOverListResultWork();

            work6.SectionCode = "02";				// 拠点コード
            work6.SectionGuideNm = "拠点02";		// 拠点ガイド名称
            work6.GoodsNo = "20";					// 商品コード
            work6.GoodsName = "P901_ブルー";	    // 商品名称
            work6.StockUnitPriceFl = 45000;			// 仕入単価
            work6.WarehouseCode = "0001";           // 倉庫コード
            work6.WarehouseName = "倉庫01";         // 倉庫名称
            work6.WarehouseShelfNo = "01";          // 棚番
            work6.BLGoodsCode = 1;                  // BLコード
            //--- DEL 2008/10/03 不具合対応[6057] ---------->>>>>
            //work6.DuplicationShelfNo1 = "7";        // 管理区分1
            //work6.DuplicationShelfNo2 = "8";        // 管理区分2
            //--- DEL 2008/10/03 不具合対応[6057] ----------<<<<<
            //--- ADD 2008/10/03 不具合対応[6057] ---------->>>>>
            work6.PartsManagementDivide1 = "7";        // 管理区分1
            work6.PartsManagementDivide2 = "8";        // 管理区分2
            //--- ADD 2008/10/03 不具合対応[6057] ----------<<<<<
            work6.GoodsMakerCd = 1;                 // 品番
            work6.MaximumStockCnt = 100;            //
            work6.MinimumStockCnt = 1;              //
            work6.SalesOrderCount = 2;              //
            work6.SupplierCd = 123;                 // 仕入先コード
            work6.SupplierSnm = "仕入先１";         // 仕入先略称
            work6.ShipmentCnt = 10;
            work6.ShipmentPosCnt = 100;

            list.Add(work6);

            StockOverListResultWork work7 = new StockOverListResultWork();

            work7.SectionCode = "02";				// 拠点コード
            work7.SectionGuideNm = "拠点02";		// 拠点ガイド名称
            work7.GoodsNo = "20";					// 商品コード
            work7.GoodsName = "P901_ブルー";	    // 商品名称
            work7.StockUnitPriceFl = 45000;			// 仕入単価
            work7.WarehouseCode = "0001";           // 倉庫コード
            work7.WarehouseName = "倉庫01";         // 倉庫名称
            work7.WarehouseShelfNo = "01";          // 棚番
            work7.BLGoodsCode = 1;                  // BLコード
            //--- DEL 2008/10/03 不具合対応[6057] ---------->>>>>
            //work7.DuplicationShelfNo1 = "7";        // 管理区分1
            //work7.DuplicationShelfNo2 = "8";        // 管理区分2
            //--- DEL 2008/10/03 不具合対応[6057] ----------<<<<<
            //--- ADD 2008/10/03 不具合対応[6057] ---------->>>>>
            work7.PartsManagementDivide1 = "7";        // 管理区分1
            work7.PartsManagementDivide1 = "8";        // 管理区分2
            //--- ADD 2008/10/03 不具合対応[6057] ----------<<<<<
            work7.GoodsMakerCd = 1;                 // 品番
            work7.MaximumStockCnt = 100;            //
            work7.MinimumStockCnt = 1;              //
            work7.SalesOrderCount = 2;              //
            work7.SupplierCd = 123;                 // 仕入先コード
            work7.SupplierSnm = "仕入先１";         // 仕入先略称
            work7.ShipmentCnt = 10;
            work7.ShipmentPosCnt = 100;

            list.Add(work7);

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
		/// <param name="stockOverListCndtn">UI抽出条件クラス</param>
		/// <param name="stockOverListCndtnWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
        private int DevStockMoveCndtn(StockOverListCndtn stockOverListCndtn, out StockOverListCndtnWork stockOverListCndtnWork, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;
			stockOverListCndtnWork = new StockOverListCndtnWork();
			try
			{
                stockOverListCndtnWork.EnterpriseCode = stockOverListCndtn.EnterpriseCode;  // 企業コード
				// 抽出条件パラメータセット
				if ( stockOverListCndtn.SectionCodes.Length != 0 )
				{
				    if ( stockOverListCndtn.IsSelectAllSection )
				    {
				        // 全社の時
                        stockOverListCndtnWork.SectionCodes = null;
				    }
				    else
				    {
                        stockOverListCndtnWork.SectionCodes = stockOverListCndtn.SectionCodes;
				    }
				}
				else
				{
                    stockOverListCndtnWork.SectionCodes = null;
				}

                stockOverListCndtnWork.EnterpriseCode = stockOverListCndtn.EnterpriseCode;
                stockOverListCndtnWork.St_AddUpYearMonth = stockOverListCndtn.St_AddUpYearMonth;
                stockOverListCndtnWork.Ed_AddUpYearMonth = stockOverListCndtn.Ed_AddUpYearMonth;
                stockOverListCndtnWork.NoShipmentDiv = stockOverListCndtn.NoShipmentDiv;
                stockOverListCndtnWork.St_WarehouseCode = stockOverListCndtn.St_WarehouseCode;
                stockOverListCndtnWork.Ed_WarehouseCode = stockOverListCndtn.Ed_WarehouseCode;
                stockOverListCndtnWork.St_SupplierCd = stockOverListCndtn.St_SupplierCd;
                stockOverListCndtnWork.Ed_SupplierCd = stockOverListCndtn.Ed_SupplierCd;
                stockOverListCndtnWork.St_GoodsMakerCd = stockOverListCndtn.St_GoodsMakerCd;
                stockOverListCndtnWork.Ed_GoodsMakerCd = stockOverListCndtn.Ed_GoodsMakerCd;
                //--- DEL 2008/07/15 ---------->>>>>
                //stockOverListCndtnWork.St_LargeGoodsGanreCode = stockOverListCndtn.St_LargeGoodsGanreCode;
                //stockOverListCndtnWork.Ed_LargeGoodsGanreCode = stockOverListCndtn.Ed_LargeGoodsGanreCode;
                //stockOverListCndtnWork.St_MediumGoodsGanreCode = stockOverListCndtn.St_MediumGoodsGanreCode;
                //stockOverListCndtnWork.Ed_MediumGoodsGanreCode = stockOverListCndtn.Ed_MediumGoodsGanreCode;
                //stockOverListCndtnWork.St_DetailGoodsGanreCode = stockOverListCndtn.St_DetailGoodsGanreCode;
                //stockOverListCndtnWork.Ed_DetailGoodsGanreCode = stockOverListCndtn.Ed_DetailGoodsGanreCode;
                //--- DEL 2008/07/15 ----------<<<<<
                stockOverListCndtnWork.St_EnterpriseGanreCode = stockOverListCndtn.St_EnterpriseGanreCode;
                stockOverListCndtnWork.Ed_EnterpriseGanreCode = stockOverListCndtn.Ed_EnterpriseGanreCode;
                stockOverListCndtnWork.St_GoodsNo = stockOverListCndtn.St_GoodsNo;
                stockOverListCndtnWork.Ed_GoodsNo = stockOverListCndtn.Ed_GoodsNo;
                stockOverListCndtnWork.St_WarehouseShelfNo = stockOverListCndtn.St_WarehouseShelfNo;
                stockOverListCndtnWork.Ed_WarehouseShelfNo = stockOverListCndtn.Ed_WarehouseShelfNo;
                stockOverListCndtnWork.StockCreateDate = stockOverListCndtn.StockCreateDate;
                stockOverListCndtnWork.StockCreateDateDiv = (int)stockOverListCndtn.StockCreateDateDiv;
                //--- ADD 2008/07/15 ---------->>>>>
                stockOverListCndtnWork.St_BLGoodsCode = stockOverListCndtn.St_BLGoodsCode;
                stockOverListCndtnWork.Ed_BLGoodsCode = stockOverListCndtn.Ed_BLGoodsCode;
                stockOverListCndtnWork.PartsManagementDivide1 = stockOverListCndtn.PartsManagementDivide1;
                stockOverListCndtnWork.PartsManagementDivide2 = stockOverListCndtn.PartsManagementDivide2;
                //--- ADD 2008/07/15 ---------->>>>>
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
		/// <param name="stockOverListCndtn">UI抽出条件クラス</param>
		/// <param name="stockMoveWork">取得データ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 取得データを展開する。</br>
	    /// <br>Programmer : 20081 疋田 勇人</br>
	    /// <br>Date       : 2007.11.13</br>
		/// </remarks>
        private void DevStockMoveData( StockOverListCndtn stockOverListCndtn, ArrayList stockMoveWork)
		{
			DataRow dr;
            GoodsUnitData goodsUnitData = null;         //ADD 2009/04/30 不具合対応[11972]

            goodsUnitDataDic = new Dictionary<string,GoodsUnitData>();   // ADD 2011/03/16 
            unitPriceCalcRetDic = new Dictionary<string,UnitPriceCalcRet>(); // ADD 2011/03/16 

            // 棚番ブレイク桁数
            int breakLength = stockOverListCndtn.WarehouseShelfNoBreakLength;

            // --- DEL 2009/02/27 -------------------------------->>>>>
            //GoodsCndtn goodsCndtn = new GoodsCndtn(); // ADD 2009/02/24
            //List<GoodsUnitData> goodsUnitDataList; // ADD 2009/02/24
            //string errMsg;
            // --- DEL 2009/02/27 --------------------------------<<<<<

            foreach ( StockOverListResultWork stockOverListResultWork in stockMoveWork)
			{
                //--- ADD 2008/07/22 ---------->>>>>
                int status = 0;

                int goodsLGroup = 0; // ADD 2009/02/27
                int goodsMGroup = 0; // ADD 2009/02/27
                int bLGroupCode = 0; // ADD 2009/02/27

                //status = GoodsGanreCheck(stockOverListCndtn,stockOverListResultWork.BLGoodsCode);
                status = GoodsGanreCheck(stockOverListCndtn, stockOverListResultWork.BLGoodsCode, out goodsLGroup, out goodsMGroup, out bLGroupCode); // ADD 2009/02/27

                if (status == 0)
                {
                //--- ADD 2008/07/22 ----------<<<<<

                    dr = this._stockOverListDt.NewRow();
                    // 取得データ展開
                    #region 取得データ展開

                    //dr[DCZAI02184EA.ct_Col_SectionCode] = stockOverListResultWork.SectionCode; // 拠点コード                                  //DEL 2009/04/23 不具合対応[12999]
                    //dr[DCZAI02184EA.ct_Col_SectionGuideNm] = this.GetSectionGuideNm(stockOverListResultWork.SectionCode); // 拠点ガイド名称   //DEL 2009/04/23 不具合対応[12999]
                    dr[DCZAI02184EA.ct_Col_WarehouseCode] = stockOverListResultWork.WarehouseCode;       // 倉庫コード
                    dr[DCZAI02184EA.ct_Col_WarehouseName] = stockOverListResultWork.WarehouseName;       // 倉庫名称                            //DEL 2009/04/23 不具合対応[12778]
                    // ---ADD 2009/04/23 不具合対応[12778] ---------------------------------------------------------------------->>>>>
                    if ((stockOverListResultWork.WarehouseCode.Trim().PadLeft(4, '0') == "0000") ||
                        (string.IsNullOrEmpty(stockOverListResultWork.WarehouseName.Trim())))
                    {
                        dr[DCZAI02184EA.ct_Col_WarehouseName] = "未登録";
                    }
                    // ---ADD 2009/04/23 不具合対応[12778] ----------------------------------------------------------------------<<<<<
                    dr[DCZAI02184EA.ct_Col_CustomerCode] = stockOverListResultWork.SupplierCd;           // 仕入先コード
                    //dr[DCZAI02184EA.ct_Col_CustomerName] = stockOverListResultWork.SupplierName;       // 仕入先名称        // DEL 2008.07.16
                    dr[DCZAI02184EA.ct_Col_CustomerName] = stockOverListResultWork.SupplierSnm;          // 仕入先略称        // ADD 2008.07.16
                    dr[DCZAI02184EA.ct_Col_GoodsMakerCd] = stockOverListResultWork.GoodsMakerCd;         // 商品メーカーコード
                    //dr[DCZAI02184EA.ct_Col_MakerName] = stockOverListResultWork.MakerName;             // メーカー名称      // DEL 2008.07.16
                    dr[DCZAI02184EA.ct_Col_MakerName] = GetMakerNm(stockOverListCndtn.EnterpriseCode,stockOverListResultWork.GoodsMakerCd);  // メーカー名称      // ADD 2008.07.16
                    dr[DCZAI02184EA.ct_Col_GoodsNo] = stockOverListResultWork.GoodsNo;                   // 商品番号
                    dr[DCZAI02184EA.ct_Col_GoodsName] = stockOverListResultWork.GoodsName;               // 商品名称
                    dr[DCZAI02184EA.ct_Col_WarehouseShelfNo] = stockOverListResultWork.WarehouseShelfNo; // 倉庫棚番
                    dr[DCZAI02184EA.ct_Col_MinimumStockCnt] = stockOverListResultWork.MinimumStockCnt;   // 最低在庫数
                    dr[DCZAI02184EA.ct_Col_MaximumStockCnt] = stockOverListResultWork.MaximumStockCnt;   // 最高在庫数
                    dr[DCZAI02184EA.ct_Col_ShipmentPosCnt] = stockOverListResultWork.ShipmentPosCnt;     // 出荷可能数
                    dr[DCZAI02184EA.ct_Col_ShipmentCnt] = stockOverListResultWork.ShipmentCnt;           // 出荷数
                    dr[DCZAI02184EA.ct_Col_SalesOrderCount] = stockOverListResultWork.SalesOrderCount;   // 発注数
                    Double dOverCount = stockOverListResultWork.ShipmentPosCnt - stockOverListResultWork.MaximumStockCnt;
                    dr[DCZAI02184EA.ct_Col_StockOverCount] = dOverCount;                                 // 過剰数
                    dr[DCZAI02184EA.ct_Col_StockPrice] = dOverCount * stockOverListResultWork.StockUnitPriceFl; // 在庫金額
                    dr[DCZAI02184EA.ct_Col_LastStockDate] = this.GetDateText(stockOverListResultWork.LastStockDate); // 最終仕入年月日
                    //dr[DCZAI02184EA.ct_Col_Sort_SectionCode] = stockOverListResultWork.SectionCode;      // ソート用　拠点コード              //DEL 2009/04/23 不具合対応[12999]
                    dr[DCZAI02184EA.ct_Col_Sort_WarehouseCode] = stockOverListResultWork.WarehouseCode;  // ソート用　倉庫コード
                    //dr[DCZAI02184EA.ct_Col_Sort_CustomerCode] = stockOverListResultWork.SupplierCd;      // ソート用　仕入先コード            //DEL 2009/04/23 不具合対応[12778]
                    dr[DCZAI02184EA.ct_Col_Sort_GoodsMakerCd] = stockOverListResultWork.GoodsMakerCd;    // ソート用　商品メーカーコード
                    dr[DCZAI02184EA.ct_Col_Sort_GoodsNo] = stockOverListResultWork.GoodsNo;              // ソート用　商品番号
                    dr[DCZAI02184EA.ct_Col_Sort_WarehouseShelfNo] = stockOverListResultWork.WarehouseShelfNo; // ソート用　倉庫棚番

                    // 棚番ブレイク設定
                    string warehouseShelfNoBreak = stockOverListResultWork.WarehouseShelfNo.PadRight(8, ' ').Substring(0, breakLength);
                    dr[DCZAI02184EA.ct_Col_WarehouseShelfNoBreak] = warehouseShelfNoBreak;      // 倉庫棚番ブレイク
                    dr[DCZAI02184EA.ct_Col_Sort_WarehouseShelfNoBreak] = warehouseShelfNoBreak; // ソート用　倉庫棚番ブレイク
                    
                    //--- ADD 2008/07/15 ---------->>>>>
                    dr[DCZAI02184EA.ct_Col_BLGoodsCode] = stockOverListResultWork.BLGoodsCode;                      // BLコード
                    //--- DEL 2008/10/03 不具合対応[6057] ---------->>>>>
                    //dr[DCZAI02184EA.ct_Col_PartsManagementDivide1] = stockOverListResultWork.DuplicationShelfNo1;   // 部品管理区分１
                    //dr[DCZAI02184EA.ct_Col_PartsManagementDivide2] = stockOverListResultWork.DuplicationShelfNo2;   // 部品管理区分２
                    //--- DEL 2008/10/03 不具合対応[6057] ----------<<<<<
                    //--- ADD 2008/10/03 不具合対応[6057] ---------->>>>>
                    dr[DCZAI02184EA.ct_Col_PartsManagementDivide1] = stockOverListResultWork.PartsManagementDivide1;   // 部品管理区分１
                    dr[DCZAI02184EA.ct_Col_PartsManagementDivide2] = stockOverListResultWork.PartsManagementDivide2;   // 部品管理区分２
                    //--- ADD 2008/10/03 不具合対応[6057] ----------<<<<<
                    //--- ADD 2008/07/15 ----------<<<<<

                    dr[DCZAI02184EA.ct_Col_Sort_BLGoodsCode] = stockOverListResultWork.BLGoodsCode;         // ソート用　BLコード   //ADD 2009/04/23 不具合対応[12778]

                    // ---DEL 2009/04/30 不具合対応[11972] ------------------------------------------------------>>>>>
                    //// --- DEL 2009/02/27 -------------------------------->>>>>
                    //// --- ADD 2009/02/24 -------------------------------->>>>>
                    ////// 仕入先の取得
                    ////if (stockOverListResultWork.SupplierCd == 0)
                    ////{
                    ////    goodsCndtn.EnterpriseCode = stockOverListCndtn.EnterpriseCode;
                    ////    goodsCndtn.GoodsNo = stockOverListResultWork.GoodsNo;
                    ////    goodsCndtn.GoodsMakerCd = stockOverListResultWork.GoodsMakerCd;

                    ////    goodsCndtn.IsSettingSupplier = 1;
                    ////    goodsCndtn.IsSettingVariousMst = 1;

                    ////    int stat = stc_GoodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtn, false, out goodsUnitDataList, out errMsg);

                    ////    if (stat == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    ////    {
                    ////        GoodsUnitData goodsUnitData = goodsUnitDataList[0];

                    ////        stc_GoodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData);

                    ////        if (goodsUnitData.SupplierCd != 0)
                    ////        {
                    ////            dr[DCZAI02184EA.ct_Col_CustomerCode] = goodsUnitData.SupplierCd; // 仕入先コード
                    ////            dr[DCZAI02184EA.ct_Col_CustomerName] = goodsUnitData.SupplierSnm; // 仕入先名称

                    ////            dr[DCZAI02184EA.ct_Col_Sort_CustomerCode] = goodsUnitData.SupplierCd;      // ソート用　仕入先コード
                    ////        }
                    ////    }
                    ////}
                    ////// --- ADD 2009/02/24 --------------------------------<<<<<
                    //// --- DEL 2009/02/27 --------------------------------<<<<<
                    //// --- ADD 2009/02/27 -------------------------------->>>>>
                    //if (stockOverListResultWork.SupplierCd == 0)
                    //{
                    //    int supplierCd;
                    //    string supplierSnm;
                    //    GetGoodsMngInfo(stockOverListResultWork, goodsLGroup, goodsMGroup, bLGroupCode, out supplierCd, out supplierSnm);
                    //    dr[DCZAI02184EA.ct_Col_CustomerCode] = supplierCd;           // 仕入先コード
                    //    dr[DCZAI02184EA.ct_Col_CustomerName] = supplierSnm;          // 仕入先略称
                    //    dr[DCZAI02184EA.ct_Col_Sort_CustomerCode] = supplierCd;      // ソート用　仕入先コード      //ADD 2009/04/23 不具合対応[12778]
                    //}
                    //// --- ADD 2009/02/27 --------------------------------<<<<<
                    // ---DEL 2009/04/30 不具合対応[11972] ------------------------------------------------------<<<<<
                    // ---ADD 2009/04/30 不具合対応[11972] ------------------------------------------------------>>>>>
                    // -- UPD 2011/03/16 --------------------------------->>>
                    //goodsUnitData = this.GetGoodsUnitData(stockOverListResultWork.GoodsMakerCd,
                    //                                      stockOverListResultWork.GoodsNo,
                    //                                      goodsMGroup,
                    //                                      stockOverListResultWork.BLGoodsCode);

                    string keyString = stockOverListResultWork.GoodsNo + '-' + stockOverListResultWork.GoodsMakerCd.ToString("0000");

                    if (goodsUnitDataDic.ContainsKey(keyString))
                    {
                        //既に一度検索されていた場合は、退避した検索結果を使用する
                        goodsUnitData = goodsUnitDataDic[keyString] as GoodsUnitData;
                    }
                    else
                    {
                        //検索処理
                        goodsUnitData = this.GetGoodsUnitData(stockOverListResultWork.GoodsMakerCd,
                                                              stockOverListResultWork.GoodsNo,
                                                              goodsMGroup,
                                                              stockOverListResultWork.BLGoodsCode);

                        goodsUnitDataDic.Add(keyString,goodsUnitData);
                    }
                    // -- UPD 2011/03/16 ---------------------------------<<<

                    // -- ADD 2011/03/16 ------------------------------>>>
                    //仕入先の絞り込みをここで追加して、単価取得ロジックを最小限にする。
                    int stSupplierCd = 0;
                    int edSupplierCd = 999999;
                    if (stockOverListCndtn.St_SupplierCd != 0)
                    {
                        stSupplierCd = stockOverListCndtn.St_SupplierCd;
                    }
                    if (stockOverListCndtn.Ed_SupplierCd != 0)
                    {
                        edSupplierCd = stockOverListCndtn.Ed_SupplierCd;
                    }

                    if ((goodsUnitData.SupplierCd < stSupplierCd) || (goodsUnitData.SupplierCd > edSupplierCd)) continue;
                    // -- ADD 2011/03/16 ------------------------------<<<

                    //仕入先情報取得
                    //if (stockOverListResultWork.SupplierCd == 0)  //DEL 2011/03/16
                    //{  // DEL 2011/03/16
                        dr[DCZAI02184EA.ct_Col_CustomerCode] = goodsUnitData.SupplierCd;           // 仕入先コード
                        dr[DCZAI02184EA.ct_Col_Sort_CustomerCode] = goodsUnitData.SupplierCd;      // ソート用　仕入先コード
                        if (string.IsNullOrEmpty(goodsUnitData.SupplierSnm.Trim()))
                        {
                            dr[DCZAI02184EA.ct_Col_CustomerName] = "未登録";
                        }
                        else
                        {
                            dr[DCZAI02184EA.ct_Col_CustomerName] = goodsUnitData.SupplierSnm;          // 仕入先略称
                        }
                    //} // DEL 2011/03/16

                    //価格情報取得
                    double salesUnitCost = 0.0;
                    // -- UPD 2011/03/16 ---------------------------->>>
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
                    // -- UPD 2011/03/16 ----------------------------<<<

                    dr[DCZAI02184EA.ct_Col_StockPrice] = this.StockTotalPriceToLong(dOverCount, salesUnitCost); // 在庫金額
                    // ---ADD 2009/04/30 不具合対応[11972] ------------------------------------------------------<<<<<
                    #endregion

                    // TableにAdd
                    this._stockOverListDt.Rows.Add(dr);
                //--- ADD 2008/07/22 ---------->>>>>
                }
                //--- ADD 2008/07/22 ----------<<<<<
			}

            this._stockOverListDt.CaseSensitive = true;     //ADD 2009/04/23 不具合対応[12778]

			// DataView作成
            this._stockOverListDataView = new DataView(this._stockOverListDt, GetFilter(stockOverListCndtn), GetSortOrder(stockOverListCndtn), DataViewRowState.CurrentRows);
		}

        //--- ADD 2008/07/22 ---------->>>>>
        /// <summary>
        /// 商品区分絞込処理
        /// </summary>
        /// <param name="stockOverListCndtn"></param>
        /// <param name="BLGoodsCode"></param>
        /// <param name="goodsLGroup"></param>
        /// <param name="goodsMGroup"></param>
        /// <param name="bLGroupCode"></param>
        /// <returns></returns>
        //private int GoodsGanreCheck(StockOverListCndtn stockOverListCndtn, int BLGoodsCode)
        private int GoodsGanreCheck(StockOverListCndtn stockOverListCndtn, int BLGoodsCode,
            out int goodsLGroup, out int goodsMGroup, out int bLGroupCode)
        {
            int status = 0;
            
            goodsLGroup = 0; // ADD 2009/02/27
            goodsMGroup = 0; // ADD 2009/02/27
            bLGroupCode = 0; // ADD 2009/02/27

            BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();

            // BLコードマスタ取得
            stc_GoodsAcs.GetBLGoodsCd(BLGoodsCode, out bLGoodsCdUMnt);
            // ---ADD 2008/10/01 ------------------------------------------------------------------------------------------------------------------------->>>>>
            if (bLGoodsCdUMnt == null)
            {
                //// BLコード情報が取得できなかった場合、BLコードが「最初から最後まで」、グループコードが「最初から最後まで」の時のみ対象とする
                //if (((stockOverListCndtn.St_BLGoodsCode == 0) && (stockOverListCndtn.Ed_BLGoodsCode == 99999)) &&
                //    ((string.IsNullOrEmpty(stockOverListCndtn.St_DetailGoodsGanreCode) && (string.IsNullOrEmpty(stockOverListCndtn.Ed_DetailGoodsGanreCode))))) // DEL 2009/02/27
                // BLコード情報が取得できなかった場合、
                // グループコード、商品大分類、商品中分類が「最初から」の時のみ対象とする
                if (
                    (string.IsNullOrEmpty(stockOverListCndtn.St_LargeGoodsGanreCode))
                    &&
                    (string.IsNullOrEmpty(stockOverListCndtn.St_MediumGoodsGanreCode))
                    &&
                    (string.IsNullOrEmpty(stockOverListCndtn.St_DetailGoodsGanreCode))
                   ) // ADD 2009/02/27
                {
                    return 0;       //対象
                }
                else
                {
                    return 1;       //対象外
                }
            }
            // ---ADD 2008/10/01 -------------------------------------------------------------------------------------------------------------------------<<<<<

            bLGroupCode = bLGoodsCdUMnt.BLGloupCode; // ADD 2009/02/27

            // グループコードチェック
            if (stockOverListCndtn.St_DetailGoodsGanreCode != string.Empty && stockOverListCndtn.Ed_DetailGoodsGanreCode != string.Empty)
            {
                // 開始<=終了 範囲内か？
                //--- DEL 2008/10/03 不具合対応[6090] ---------->>>>>
                //if (int.Parse(stockOverListCndtn.St_DetailGoodsGanreCode) >= bLGoodsCdUMnt.BLGloupCode ||
                //   int.Parse(stockOverListCndtn.Ed_DetailGoodsGanreCode) <= bLGoodsCdUMnt.BLGloupCode)
                //--- DEL 2008/10/03 不具合対応[6090] ----------<<<<<
                //--- ADD 2008/10/03 不具合対応[6090] ---------->>>>>
                if (int.Parse(stockOverListCndtn.St_DetailGoodsGanreCode) > bLGoodsCdUMnt.BLGloupCode ||
                   int.Parse(stockOverListCndtn.Ed_DetailGoodsGanreCode) < bLGoodsCdUMnt.BLGloupCode)
                //--- ADD 2008/10/03 不具合対応[6090] ----------<<<<<
                {
                    status = 1;
                    return status;
                }
            }
            else if (stockOverListCndtn.St_DetailGoodsGanreCode != string.Empty && stockOverListCndtn.Ed_DetailGoodsGanreCode == string.Empty)
            {
                // 開始<=最後まで 範囲内か？
                //--- DEL 2008/10/03 不具合対応[6090] ---------->>>>>
                //if (int.Parse(stockOverListCndtn.St_DetailGoodsGanreCode) >= bLGoodsCdUMnt.BLGloupCode)
                //--- DEL 2008/10/03 不具合対応[6090] ----------<<<<<
                //--- ADD 2008/10/03 不具合対応[6090] ---------->>>>>
                if (int.Parse(stockOverListCndtn.St_DetailGoodsGanreCode) > bLGoodsCdUMnt.BLGloupCode)
                //--- ADD 2008/10/03 不具合対応[6090] ----------<<<<<
                {
                    status = 1;
                    return status;
                }
            }
            else if (stockOverListCndtn.St_DetailGoodsGanreCode == string.Empty && stockOverListCndtn.Ed_DetailGoodsGanreCode != string.Empty)
            {
                // 最初から<=終了 範囲内か？
                //--- DEL 2008/10/03 不具合対応[6090] ---------->>>>>
                //if (int.Parse(stockOverListCndtn.Ed_DetailGoodsGanreCode) <= bLGoodsCdUMnt.BLGloupCode)
                //--- DEL 2008/10/03 不具合対応[6090] ----------<<<<<
                //--- ADD 2008/10/03 不具合対応[6090] ---------->>>>>
                if (int.Parse(stockOverListCndtn.Ed_DetailGoodsGanreCode) < bLGoodsCdUMnt.BLGloupCode)
                //--- ADD 2008/10/03 不具合対応[6090] ----------<<<<<
                {
                    status = 1;
                    return status;
                }
            }

            BLGroupU bLGroupU = new BLGroupU();

            // BLグループマスタ取得
            stc_GoodsAcs.GetBLGroup(stockOverListCndtn.EnterpriseCode, bLGoodsCdUMnt.BLGloupCode, out bLGroupU);
            // --- DEL 2009/02/27 -------------------------------->>>>>
            //// ---ADD 2008/10/01 ------------------------------------------------------------------------------------------------------------------------->>>>>
            //if (bLGroupU == null)
            //{
            //    // BLグループコード情報が取得できなかった場合、グループコードが「最初から最後まで」の時のみ対象とする
            //    if ((string.IsNullOrEmpty(stockOverListCndtn.St_DetailGoodsGanreCode) && (string.IsNullOrEmpty(stockOverListCndtn.Ed_DetailGoodsGanreCode))))
            //    {
            //        return 0;       //対象
            //    }
            //    else
            //    {
            //        return 1;       //対象外
            //    }
            //}
            //// ---ADD 2008/10/01 -------------------------------------------------------------------------------------------------------------------------<<<<<
            // --- DEL 2009/02/27 --------------------------------<<<<<
            // --- ADD 2009/02/27 -------------------------------->>>>>
            if (bLGroupU == null)
            {
                // BLグループコード情報が取得できなかった場合
                // 商品大分類、商品中分類が「最初から」の時のみ対象とする
                if (
                    (string.IsNullOrEmpty(stockOverListCndtn.St_LargeGoodsGanreCode))
                    &&
                    (string.IsNullOrEmpty(stockOverListCndtn.St_MediumGoodsGanreCode))
                   )
                {
                    return 0;       //対象
                }
                else
                {
                    return 1;       //対象外
                }
            }

            goodsLGroup = bLGroupU.GoodsLGroup;
            goodsMGroup = bLGroupU.GoodsMGroup;
            // --- ADD 2009/02/27 --------------------------------<<<<<

            // 商品中分類チェック
            if (stockOverListCndtn.St_MediumGoodsGanreCode != string.Empty && stockOverListCndtn.Ed_MediumGoodsGanreCode != string.Empty)
            {
                // 開始<=終了 範囲内か？
                //--- DEL 2008/10/03 不具合対応[6090] ---------->>>>>
                //if (int.Parse(stockOverListCndtn.St_MediumGoodsGanreCode) >= bLGroupU.GoodsMGroup ||
                //   int.Parse(stockOverListCndtn.Ed_MediumGoodsGanreCode) <= bLGroupU.GoodsMGroup)
                //--- DEL 2008/10/03 不具合対応[6090] ----------<<<<<
                //--- ADD 2008/10/03 不具合対応[6090] ---------->>>>>
                if (int.Parse(stockOverListCndtn.St_MediumGoodsGanreCode) > bLGroupU.GoodsMGroup ||
                   int.Parse(stockOverListCndtn.Ed_MediumGoodsGanreCode) < bLGroupU.GoodsMGroup)
                //--- ADD 2008/10/03 不具合対応[6090] ----------<<<<<                
                {
                    status = 1;
                    return status;
                }
            }
            else if (stockOverListCndtn.St_MediumGoodsGanreCode != string.Empty && stockOverListCndtn.Ed_MediumGoodsGanreCode == string.Empty)
            {
                // 開始<=最後まで 範囲内か？
                //--- DEL 2008/10/03 不具合対応[6090] ---------->>>>>
                //if (int.Parse(stockOverListCndtn.St_MediumGoodsGanreCode) >= bLGroupU.GoodsMGroup)
                //--- DEL 2008/10/03 不具合対応[6090] ----------<<<<<
                //--- ADD 2008/10/03 不具合対応[6090] ---------->>>>>
                if (int.Parse(stockOverListCndtn.St_MediumGoodsGanreCode) > bLGroupU.GoodsMGroup)
                //--- ADD 2008/10/03 不具合対応[6090] ----------<<<<<                
                {
                    status = 1;
                    return status;
                }
            }
            else if (stockOverListCndtn.St_MediumGoodsGanreCode == string.Empty && stockOverListCndtn.Ed_MediumGoodsGanreCode != string.Empty)
            {
                // 最初から<=終了 範囲内か？
                //--- DEL 2008/10/03 不具合対応[6090] ---------->>>>>
                //if (int.Parse(stockOverListCndtn.Ed_MediumGoodsGanreCode) <= bLGroupU.GoodsMGroup)
                //--- DEL 2008/10/03 不具合対応[6090] ----------<<<<<
                //--- ADD 2008/10/03 不具合対応[6090] ---------->>>>>
                if (int.Parse(stockOverListCndtn.Ed_MediumGoodsGanreCode) < bLGroupU.GoodsMGroup)
                //--- ADD 2008/10/03 不具合対応[6090] ----------<<<<<
                {
                    status = 1;
                    return status;
                }
            }

            // 商品大分類チェック
            if (stockOverListCndtn.St_LargeGoodsGanreCode != string.Empty && stockOverListCndtn.Ed_LargeGoodsGanreCode != string.Empty)
            {
                // 開始<=終了 範囲内か？
                //--- DEL 2008/10/03 不具合対応[6090] ---------->>>>>
                //if (int.Parse(stockOverListCndtn.St_LargeGoodsGanreCode) >= bLGroupU.GoodsLGroup ||
                //   int.Parse(stockOverListCndtn.Ed_LargeGoodsGanreCode) <= bLGroupU.GoodsLGroup)
                //--- DEL 2008/10/03 不具合対応[6090] ----------<<<<<
                //--- ADD 2008/10/03 不具合対応[6090] ---------->>>>>
                if (int.Parse(stockOverListCndtn.St_LargeGoodsGanreCode) > bLGroupU.GoodsLGroup ||
                   int.Parse(stockOverListCndtn.Ed_LargeGoodsGanreCode) < bLGroupU.GoodsLGroup)
                //--- ADD 2008/10/03 不具合対応[6090] ----------<<<<<                
                {
                    status = 1;
                    return status;
                }
            }
            else if (stockOverListCndtn.St_LargeGoodsGanreCode != string.Empty && stockOverListCndtn.Ed_LargeGoodsGanreCode == string.Empty)
            {
                // 開始<=最後まで 範囲内か？
                //--- DEL 2008/10/03 不具合対応[6090] ---------->>>>>
                //if (int.Parse(stockOverListCndtn.St_LargeGoodsGanreCode) >= bLGroupU.GoodsLGroup)
                //--- DEL 2008/10/03 不具合対応[6090] ----------<<<<<
                //--- ADD 2008/10/03 不具合対応[6090] ---------->>>>>
                if (int.Parse(stockOverListCndtn.St_LargeGoodsGanreCode) > bLGroupU.GoodsLGroup)
                //--- ADD 2008/10/03 不具合対応[6090] ----------<<<<<
                {
                    status = 1;
                    return status;
                }
            }
            else if (stockOverListCndtn.St_LargeGoodsGanreCode == string.Empty && stockOverListCndtn.Ed_LargeGoodsGanreCode != string.Empty)
            {
                // 最初から<=終了 範囲内か？
                //--- DEL 2008/10/03 不具合対応[6090] ---------->>>>>
                //if (int.Parse(stockOverListCndtn.Ed_LargeGoodsGanreCode) <= bLGroupU.GoodsLGroup)
                //--- DEL 2008/10/03 不具合対応[6090] ----------<<<<<
                //--- ADD 2008/10/03 不具合対応[6090] ---------->>>>>
                if (int.Parse(stockOverListCndtn.Ed_LargeGoodsGanreCode) < bLGroupU.GoodsLGroup)
                //--- ADD 2008/10/03 不具合対応[6090] ----------<<<<<
                {
                    status = 1;
                    return status;
                }
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

        //--- ADD 2008/07/22 ---------->>>>>
        /// <summary>
        /// メーカー名称取得処理
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="makerCode"></param>
        /// <returns></returns>
        private string GetMakerNm(string enterpriseCode, int makerCode)
        {
            //string makerName = "";
            string makerName = "未登録";

            int status;

            MakerUMnt makerUMnt = new MakerUMnt();
            //MakerAcs makerAcs = new MakerAcs();

            try
            {
                status = stc_GoodsAcs.GetMaker(enterpriseCode, makerCode, out makerUMnt);

                if (status == 0)
                {
                    makerName = makerUMnt.MakerName.Trim();
                }
            }
            catch
            {
                //makerName = "";           //DEL 2009/04/23 不具合対応[12778]
                makerName = "未登録";       //ADD 2009/04/23 不具合対応[12778]
            }

            return makerName;
        }
        //--- ADD 2008/07/22 ----------<<<<<

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

        // ---DEL 2009/04/30 不具合対応[11972] ----------------------------------------------------------------->>>>>
        #region DEL 2009/04/30 不具合対応[11972]
        //// --- ADD 2009/02/27 -------------------------------->>>>>
        ///// <summary>
        ///// 商品管理情報マスタ取得処理
        ///// </summary>
        ///// <param name="bLGroupCode"></param>
        ///// <param name="goodsLGroup"></param>
        ///// <param name="goodsMGroup"></param>
        ///// <param name="stockOverListResultWork"></param>
        ///// <param name="supplierCd"></param>
        ///// <param name="supplierSnm"></param>
        ///// <returns></returns>
        //private void GetGoodsMngInfo(StockOverListResultWork stockOverListResultWork, 
        //    int goodsLGroup, int goodsMGroup, int bLGroupCode, out int supplierCd, out string supplierSnm)
        //{
        //    supplierCd = 0;
        //    supplierSnm = "";

        //    GoodsUnitData goodsUnitData = new GoodsUnitData();
        //    goodsUnitData.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        //    goodsUnitData.GoodsMakerCd = stockOverListResultWork.GoodsMakerCd;
        //    goodsUnitData.GoodsNo = stockOverListResultWork.GoodsNo;
        //    //goodsUnitData.SectionCode = stockOverListResultWork.SectionCode;              //DEL 2009/04/23 不具合対応[12778]
        //    goodsUnitData.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;    //ADD 2009/04/23 不具合対応[12778]
        //    //goodsUnitData.GoodsLGroup = goodsLGroup;                                      //DEL 2009/04/23 不具合対応[12778]
        //    goodsUnitData.GoodsMGroup = goodsMGroup;
        //    //goodsUnitData.BLGroupCode = bLGroupCode;                                      //DEL 2009/04/23 不具合対応[12778]
        //    goodsUnitData.BLGoodsCode = stockOverListResultWork.BLGoodsCode;

        //    stc_GoodsAcs.GetGoodsMngInfo(ref goodsUnitData);
        //    //stc_GoodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData);           //DEL 2009/04/23 不具合対応[12778]

        //    supplierCd = goodsUnitData.SupplierCd;
        //    //supplierSnm = goodsUnitData.SupplierSnm;                  //DEL 2009/04/23 不具合対応[12778]
        //    // ---ADD 2009/04/23 不具合対応[12778] ----------------------------------------------->>>>>
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
        //    // ---ADD 2009/04/23 不具合対応[12778] -----------------------------------------------<<<<<
        //}
        //// --- ADD 2009/02/27 --------------------------------<<<<<
        #endregion
        // ---DEL 2009/04/30 不具合対応[11972] -----------------------------------------------------------------<<<<<
        // ---ADD 2009/04/30 不具合対応[11972] ----------------------------------------------------------------->>>>>
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
        /// <br>Date       : 2009/04/30</br>
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

            goodsCndtn.GoodsKindCode = 9; // 商品属性 9:全て // ADD 2011/03/16

            //抽出
            string msg = string.Empty;
            List<GoodsUnitData> goodsUnitDataList = null;
            // -- UPD 2011/03/16 ---------------------->>>
            //int status = stc_GoodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtn, out goodsUnitDataList, out msg);
            int status = stc_GoodsAcs.GoodsOnlySearch(goodsCndtn, out goodsUnitDataList, out msg);
            // -- UPD 2011/03/16 ----------------------<<<
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                goodsUnitData = goodsUnitDataList[0];
            }

            return goodsUnitData;
        }
        // ---ADD 2009/04/30 不具合対応[11972] -----------------------------------------------------------------<<<<<
		#endregion

        #region ◎ フィルタ作成
        /// <summary>
        /// フィルタ作成
        /// </summary>
        /// <returns>フィルタ文字列</returns>
        private string GetFilter(StockOverListCndtn stockOverListCndtn)
        {
            string strQuery = "";

            if ((stockOverListCndtn.St_SupplierCd != 0) && (stockOverListCndtn.Ed_SupplierCd != 0)) 
            {
                strQuery = String.Format("{0} <= {1} AND {2} <= {3}",
                stockOverListCndtn.St_SupplierCd.ToString(),
                DCZAI02184EA.ct_Col_CustomerCode,
                DCZAI02184EA.ct_Col_CustomerCode,
                stockOverListCndtn.Ed_SupplierCd.ToString());
            }

            if ((stockOverListCndtn.St_SupplierCd != 0) && (stockOverListCndtn.Ed_SupplierCd == 0))
            {
                strQuery = String.Format("{0} <= {1}",
                stockOverListCndtn.St_SupplierCd.ToString(),
                DCZAI02184EA.ct_Col_CustomerCode);
            }

            if ((stockOverListCndtn.St_SupplierCd == 0) && (stockOverListCndtn.Ed_SupplierCd != 0))
            {
                strQuery = String.Format("{0} <= {1}",
                DCZAI02184EA.ct_Col_CustomerCode,
                stockOverListCndtn.Ed_SupplierCd.ToString());
            }

            return strQuery;
        }
        #endregion

		#region ◎ ソート順作成
		/// <summary>
		/// ソート順作成
		/// </summary>
		/// <returns>ソート文字列</returns>
        private string GetSortOrder( StockOverListCndtn stockOverListCndtn)
		{
			StringBuilder strSortOrder = new StringBuilder();

            // ---DEL 2009/04/23 不具合対応[12778] ------------------------------------------------>>>>>
            //if (!stockOverListCndtn.IsSelectAllSection)
            //{
                
            //    // 全社選択されてないとき
            //    // 主拠点
            //    strSortOrder.Append(string.Format("{0},", DCZAI02184EA.ct_Col_SectionCode));
            //}
            // ---DEL 2009/04/23 不具合対応[12778] ------------------------------------------------<<<<<

            if (stockOverListCndtn.PrintSortDiv == StockOverListCndtn.PrintSortDivState.ByCustomer)
            {
                // ＜＜　仕入先順　＞＞
                // ---DEL 2009/04/23 不具合対応[12778] -------------------------------------------->>>>>
                //// 拠点コード
                //strSortOrder.Append(string.Format("{0},", DCZAI02184EA.ct_Col_Sort_SectionCode));
                // ---DEL 2009/04/23 不具合対応[12778] --------------------------------------------<<<<<
                // 倉庫コード
                strSortOrder.Append(string.Format("{0},", DCZAI02184EA.ct_Col_Sort_WarehouseCode));
                // 仕入先コード
                strSortOrder.Append(string.Format("{0},", DCZAI02184EA.ct_Col_Sort_CustomerCode));
			    // メーカーコード
                strSortOrder.Append(string.Format("{0},", DCZAI02184EA.ct_Col_Sort_GoodsMakerCd));
                // ---ADD 2009/04/23 不具合対応[12778] -------------------------------------------->>>>>
                // BLコード
                strSortOrder.Append(string.Format("{0},", DCZAI02184EA.ct_Col_Sort_BLGoodsCode));
                // ---ADD 2009/04/23 不具合対応[12778] --------------------------------------------<<<<<
			    // 商品コード
                strSortOrder.Append(string.Format("{0}", DCZAI02184EA.ct_Col_Sort_GoodsNo));
            }
            else if (stockOverListCndtn.PrintSortDiv == StockOverListCndtn.PrintSortDivState.ByWarehouseShelfNo)
            {
                // ＜＜　棚番順　＞＞                
                // ---DEL 2009/04/23 不具合対応[12778] -------------------------------------------->>>>>
                //// 拠点コード
                //strSortOrder.Append(string.Format("{0},", DCZAI02184EA.ct_Col_Sort_SectionCode));
                // ---DEL 2009/04/23 不具合対応[12778] --------------------------------------------<<<<<
                // 倉庫コード
                strSortOrder.Append(string.Format("{0},", DCZAI02184EA.ct_Col_Sort_WarehouseCode));
                // 棚番ブレイク
                strSortOrder.Append(string.Format("{0},", DCZAI02184EA.ct_Col_Sort_WarehouseShelfNoBreak));
                // 棚番
                strSortOrder.Append(string.Format("{0},", DCZAI02184EA.ct_Col_Sort_WarehouseShelfNo));
                // ---ADD 2009/04/23 不具合対応[12778] -------------------------------------------->>>>>
                // BLコード
                strSortOrder.Append(string.Format("{0},", DCZAI02184EA.ct_Col_Sort_BLGoodsCode));
                // ---ADD 2009/04/23 不具合対応[12778] --------------------------------------------<<<<<
                // 商品コード
                strSortOrder.Append(string.Format("{0},", DCZAI02184EA.ct_Col_Sort_GoodsNo));
                // メーカーコード
                strSortOrder.Append(string.Format("{0}", DCZAI02184EA.ct_Col_Sort_GoodsMakerCd));
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
		/// <br>Programmer : 20081 疋田 勇人</br>
		/// <br>Date       : 2007.11.13</br>
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

        // ---ADD 2009/04/30 不具合対応[11972] ------------------------>>>>>
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
        /// <br>Date       : 2009/04/30</br>
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
        /// <br>Date       : 2009/04/30</br>
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
        /// <br>Date       : 2009/04/30</br>
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
        /// <br>Date       : 2009/04/30</br>
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
        /// <br>Date       : 2009/04/30</br>
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
        /// <br>Date       : 2009/04/30</br>
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
                        //longStockTotalPrice = (long)((doubleStockTotalPrice + 0.5) / 1);      //DEL 2009/05/01 マイナス時、端数処理不正となる為
                        // ---ADD 2009/05/01 マイナス時、端数処理不正となる為 -------------------------------------->>>>>
                        if (doubleStockTotalPrice >= 0)
                        {
                            longStockTotalPrice = (long)((doubleStockTotalPrice + 0.5) / 1);
                        }
                        else
                        {
                            longStockTotalPrice = (long)((doubleStockTotalPrice - 0.5) / 1);
                        }
                        // ---ADD 2009/05/01 マイナス時、端数処理不正となる為 --------------------------------------<<<<<
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
                            //longStockTotalPrice = (long)((doubleStockTotalPrice + 1) / 1);    //DEL 2009/05/01 マイナス時、端数処理不正となる為
                            // ---ADD 2009/05/01 マイナス時、端数処理不正となる為 -------------------------------------->>>>>
                            if (doubleStockTotalPrice >= 0)
                            {
                                longStockTotalPrice = (long)((doubleStockTotalPrice + 1) / 1);
                            }
                            else
                            {
                                longStockTotalPrice = (long)((doubleStockTotalPrice - 1) / 1);
                            }
                            // ---ADD 2009/05/01 マイナス時、端数処理不正となる為 --------------------------------------<<<<<
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
        // ---ADD 2009/04/30 不具合対応[11972] ------------------------<<<<<

		#endregion ■ Private Method
	}
}

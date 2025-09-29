//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫入出荷一覧表
// プログラム概要   : 在庫入出荷一覧表で使用するデータの取得を行う。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鈴木 正臣
// 作 成 日  2007/09/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/12/17  修正内容 : 印刷時、エラーとなるバグ修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/02/26  修正内容 : 不具合対応[11965]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/02/27  修正内容 : 不具合対応[12008]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/18  修正内容 : 不具合対応[12542]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/26  修正内容 : 不具合対応[12800]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/30  修正内容 : 不具合対応[12874]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/04/02  修正内容 : 不具合対応[12998][13023]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王君
// 修 正 日  2012/12/24  修正内容 : Redmine#33977の対応
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
using Broadleaf.Application.Controller.Util;        //ADD 2009/02/27　不具合対応[12008]

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// 在庫入出荷一覧表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 在庫入出荷一覧表で使用するデータを取得する。</br>
    /// <br>Programmer   : 22018 鈴木 正臣</br>
    /// <br>Date         : 2007.09.19</br>
	/// <br>Updatenote   : 2008/12/17 照田 貴志　印刷時、エラーとなるバグ修正</br>
    /// <br>             : 2009/02/26 照田 貴志　不具合対応[11965]</br>
    /// <br>             : 2009/02/27 照田 貴志　不具合対応[12008]</br>
    /// <br>             : 2009/03/18 照田 貴志　不具合対応[12542]</br>
	/// <br>             : 2009/03/26 照田 貴志　不具合対応[12800]</br>
    /// <br>             : 2009/03/30 照田 貴志　不具合対応[12874]</br>
    /// <br>             : 2009/04/02 照田 貴志　不具合対応[12998][13023]</br>
    /// <br>Update Note  : 2012/12/24 王君</br>
    /// <br>             : Redmine#33977の対応</br>
    /// </remarks>
	public class StockShipArrivalListAcs
	{
		#region ■ Constructor
		/// <summary>
		/// 在庫入出荷一覧表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫入出荷一覧表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.09.19</br>
		/// </remarks>
		public StockShipArrivalListAcs()
		{
            this._iStockShipArrivalListWorkDB = ( IStockShipArrivalListWorkDB ) MediationStockShipArrivalListWorkDB.GetStockShipArrivalListWorkDB();
		}

		/// <summary>
		/// 在庫入出荷一覧表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫入出荷一覧表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.09.19</br>
		/// </remarks>
        static StockShipArrivalListAcs ()
		{
			stc_Employee		= null;
			stc_PrtOutSet		= null;					// 帳票出力設定データクラス
			stc_PrtOutSetAcs	= new PrtOutSetAcs();	// 帳票出力設定アクセスクラス

            stc_SecInfoAcs      = new SecInfoAcs(1);    // 拠点マスタアクセスクラス
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

            stc_GoodsAcs.IsGetSupplier = true;          //ADD 2009/03/26 不具合対応[12800]
            stc_GoodsAcs.SearchInitial(LoginInfoAcquisition.EnterpriseCode, ownSectionCode, out msg);
            //--- ADD 2008/07/22 ----------<<<<<

			// ログイン拠点取得
		    Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
		    if (loginEmployee != null)
		    {
				stc_Employee = loginEmployee.Clone();
		    }

            // 拠点Dictionary生成
            stc_SectionDic = new Dictionary<string,SecInfoSet>();

            SecInfoSet[] secInfoSetList = stc_SecInfoAcs.SecInfoSetList;
            /* ---DEL 2009/02/26 不具合対応[11965] --------------------------->>>>>
            foreach( SecInfoSet secInfoSet in secInfoSetList ) {
                // 既存でなければ
                if ( ! stc_SectionDic.ContainsKey( secInfoSet.SectionCode ) ) {
                    // 追加
                    stc_SectionDic.Add( secInfoSet.SectionCode, secInfoSet );
                }
            }
               ---DEL 2009/02/26 不具合対応[11965] ---------------------------<<<<< */
            // ---ADD 2009/02/26 不具合対応[11965] --------------------------->>>>>
            foreach (SecInfoSet secInfoSet in secInfoSetList)
            {
                // 既存でなければ
                if (!stc_SectionDic.ContainsKey(secInfoSet.SectionCode.Trim()))
                {
                    // 追加
                    stc_SectionDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                }
            }
            // ---ADD 2009/02/26 不具合対応[11965] ---------------------------<<<<<
		}
		#endregion ■ Constructor

		#region ■ Static Member
		private static Employee stc_Employee;
		private static PrtOutSet stc_PrtOutSet;			// 帳票出力設定データクラス
		private static PrtOutSetAcs stc_PrtOutSetAcs;	// 帳票出力設定アクセスクラス
        
        private static SecInfoAcs stc_SecInfoAcs;       // 拠点マスタアクセスクラス
		private static Dictionary<string,SecInfoSet> stc_SectionDic;   // 拠点マスタDictionary
        //--- ADD 2008/07/22 ---------->>>>>
        private static GoodsAcs stc_GoodsAcs;           // 商品アクセスクラス
        //--- ADD 2008/07/22 ----------<<<<<
        #endregion ■ Static Member

		#region ■ Private Member
        IStockShipArrivalListWorkDB _iStockShipArrivalListWorkDB;

		private DataTable _stockShipArrivalListDt;			// 印刷DataTable
		private DataView _stockShipArrivalListDataView;	// 印刷DataView
		#endregion ■ Private Member

		#region ■ Public Property
		/// <summary>
		/// 印刷データセット(読み取り専用)
		/// </summary>
		public DataView StockShipArrivalListDataView
		{
			get{ return this._stockShipArrivalListDataView; }
		}
		#endregion ■ Public Property

		#region ■ Public Method
		#region ◆ 出力データ取得
		#region ◎ 入金データ取得
		/// <summary>
		/// データ取得
		/// </summary>
		/// <param name="stockShipArrivalListCndtn">抽出条件</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷するデータを取得する。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.09.19</br>
		/// </remarks>
        public int SearchMain ( StockShipArrivalListCndtn stockShipArrivalListCndtn, out string errMsg )
		{
            return this.SearchProc(stockShipArrivalListCndtn, out errMsg);
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
		/// <param name="stockShipArrivalListCndtn"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する在庫移動データを取得する。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.09.19</br>
		/// </remarks>
        private int SearchProc ( StockShipArrivalListCndtn stockShipArrivalListCndtn, out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

			try
			{
				// DataTable Create ----------------------------------------------------------
				DCZAI02125EA.CreateDataTable( ref this._stockShipArrivalListDt );
				
				StockShipArrivalListCndtnWork stockShipArrivalListCndtnWork = new StockShipArrivalListCndtnWork();
				// 抽出条件展開  --------------------------------------------------------------
				status = this.DevStockMoveCndtn( stockShipArrivalListCndtn, out stockShipArrivalListCndtnWork, out errMsg );
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

				// データ取得  ----------------------------------------------------------------
				object retStockMoveList = null;

                status = this._iStockShipArrivalListWorkDB.Search( out retStockMoveList, stockShipArrivalListCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);
                //--- TEST --------->>>>>
                //retStockMoveList = this.GetTestData();
                //status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //--- TEST ---------<<<<<

				switch ( status )
				{
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // データ展開処理
                        DevStockMoveData(stockShipArrivalListCndtn, (ArrayList)retStockMoveList);
                        // DEL 2008/09/24 不具合対応[5647]↓
                        //status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        // ADD 2008/09/24 不具合対応[5647] ---------->>>>>
                        if (this._stockShipArrivalListDataView.Count > 0)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        // ADD 2008/09/24 不具合対応[5647] ----------<<<<<
                        break;
                    }
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

            StockShipArrivalListWork work = new StockShipArrivalListWork();

            work.SectionCode = "01";				// 拠点コード
            work.SectionGuideNm = "拠点01";		    // 拠点ガイド名称
            work.GoodsNo = "20";					// 商品コード
            work.GoodsName = "P901_ブルー";			// 商品名称
            work.WarehouseCode = "0001";            // 倉庫コード
            work.WarehouseName = "倉庫01";          // 倉庫名称
            work.WarehouseShelfNo = "02";           // 棚番
            work.BLGoodsCode = 1;                   // BLコード
            work.GoodsMakerCd = 1;                  // 品番
            
            work.ArrivalCnt1 = 10;
            work.ShipmentCnt1 = 100;
            work.ArrivalCnt2 = 20;
            work.ShipmentCnt2 = 200;
            work.ArrivalCnt3 = 30;
            work.ShipmentCnt3 = 300;
            work.ArrivalCnt4 = 40;
            work.ShipmentCnt4 = 400;
            work.ArrivalCnt5 = 50;
            work.ShipmentCnt5 = 500;
            work.ArrivalCnt6 = 60;
            work.ShipmentCnt6 = 600;
            work.ArrivalCnt7 = 70;
            work.ShipmentCnt7 = 700;
            work.ArrivalCnt8 = 80;
            work.ShipmentCnt8 = 800;
            work.ArrivalCnt9 = 90;
            work.ShipmentCnt9 = 900;
            work.ArrivalCnt10 = 100;
            work.ShipmentCnt10 = 1000;
            work.ArrivalCnt11 = 110;
            work.ShipmentCnt11 = 1100;
            work.ArrivalCnt12 = 120;
            work.ShipmentCnt12 = 1200;
            work.SUM_ArrivalCnt = 780;
            work.SUM_ShipmentCnt = 7800;
            work.AVG_ArrivalCnt = 65;
            work.AVG_ShipmentCnt = 650;

            list.Add(work);

            StockShipArrivalListWork work1 = new StockShipArrivalListWork();

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

            StockShipArrivalListWork work2 = new StockShipArrivalListWork();

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


            StockShipArrivalListWork work3 = new StockShipArrivalListWork();

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
		/// <param name="stockShipArrivalListCndtn">UI抽出条件クラス</param>
		/// <param name="stockShipArrivalListCndtnWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
        private int DevStockMoveCndtn ( StockShipArrivalListCndtn stockShipArrivalListCndtn, out StockShipArrivalListCndtnWork stockShipArrivalListCndtnWork, out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;
			stockShipArrivalListCndtnWork = new StockShipArrivalListCndtnWork();
			try
			{
                stockShipArrivalListCndtnWork.EnterpriseCode = stockShipArrivalListCndtn.EnterpriseCode;  // 企業コード
				// 抽出条件パラメータセット
				if ( stockShipArrivalListCndtn.SectionCodes.Length != 0 )
				{
				    if ( stockShipArrivalListCndtn.IsSelectAllSection )
				    {
				        // 全社の時
                        stockShipArrivalListCndtnWork.SectionCodes = null;
				    }
				    else
				    {
                        stockShipArrivalListCndtnWork.SectionCodes = stockShipArrivalListCndtn.SectionCodes;
				    }
				}
				else
				{
                    stockShipArrivalListCndtnWork.SectionCodes = null;
				}

                stockShipArrivalListCndtnWork.St_AddUpYearMonth         = stockShipArrivalListCndtn.St_AddUpYearMonth;          // 開始年月度
                stockShipArrivalListCndtnWork.Ed_AddUpYearMonth         = stockShipArrivalListCndtn.Ed_AddUpYearMonth;          // 終了年月度
                stockShipArrivalListCndtnWork.SectionCodes              = stockShipArrivalListCndtn.SectionCodes;               // 拠点コード
                stockShipArrivalListCndtnWork.St_WarehouseCode          = stockShipArrivalListCndtn.St_WarehouseCode;           // 開始倉庫コード
                stockShipArrivalListCndtnWork.Ed_WarehouseCode          = stockShipArrivalListCndtn.Ed_WarehouseCode;           // 終了倉庫コード
                //--- DEL 2008/07/16 ---------->>>>>
                //stockShipArrivalListCndtnWork.St_CustomerCode           = stockShipArrivalListCndtn.St_CustomerCode;          // 開始仕入先コード
                //stockShipArrivalListCndtnWork.Ed_CustomerCode           = stockShipArrivalListCndtn.Ed_CustomerCode;          // 終了仕入先コード
                //--- DEL 2008/07/16 ----------<<<<<
                //--- ADD 2008/07/16 ---------->>>>>
                stockShipArrivalListCndtnWork.St_SupplierCd             = stockShipArrivalListCndtn.St_CustomerCode;            // 開始仕入先コード
                stockShipArrivalListCndtnWork.Ed_SupplierCd             = stockShipArrivalListCndtn.Ed_CustomerCode;            // 終了仕入先コード
                //--- ADD 2008/07/16 ----------<<<<<
                stockShipArrivalListCndtnWork.St_GoodsMakerCd           = stockShipArrivalListCndtn.St_GoodsMakerCd;            // 開始商品メーカーコード
                stockShipArrivalListCndtnWork.Ed_GoodsMakerCd           = stockShipArrivalListCndtn.Ed_GoodsMakerCd;            // 終了商品メーカーコード
                //--- DEL 2008/07/16 ---------->>>>>
                //stockShipArrivalListCndtnWork.St_LargeGoodsGanreCode = stockShipArrivalListCndtn.St_LargeGoodsGanreCode;      // 開始商品区分グループコード
                //stockShipArrivalListCndtnWork.Ed_LargeGoodsGanreCode    = stockShipArrivalListCndtn.Ed_LargeGoodsGanreCode;   // 終了商品区分グループコード
                //stockShipArrivalListCndtnWork.St_MediumGoodsGanreCode   = stockShipArrivalListCndtn.St_MediumGoodsGanreCode;  // 開始商品区分コード
                //stockShipArrivalListCndtnWork.Ed_MediumGoodsGanreCode   = stockShipArrivalListCndtn.Ed_MediumGoodsGanreCode;  // 終了商品区分コード
                //stockShipArrivalListCndtnWork.St_DetailGoodsGanreCode   = stockShipArrivalListCndtn.St_DetailGoodsGanreCode;  // 開始商品区分詳細コード
                //stockShipArrivalListCndtnWork.Ed_DetailGoodsGanreCode   = stockShipArrivalListCndtn.Ed_DetailGoodsGanreCode;  // 終了商品区分詳細コード
                //--- DEL 2008/07/16 ----------<<<<<
                stockShipArrivalListCndtnWork.St_EnterpriseGanreCode    = stockShipArrivalListCndtn.St_EnterpriseGanreCode;     // 開始自社分類コード
                stockShipArrivalListCndtnWork.Ed_EnterpriseGanreCode    = stockShipArrivalListCndtn.Ed_EnterpriseGanreCode;     // 終了自社分類コード
                stockShipArrivalListCndtnWork.St_BLGoodsCode            = stockShipArrivalListCndtn.St_BLGoodsCode;             // 開始ＢＬ商品コード
                stockShipArrivalListCndtnWork.Ed_BLGoodsCode            = stockShipArrivalListCndtn.Ed_BLGoodsCode;             // 終了ＢＬ商品コード
                stockShipArrivalListCndtnWork.St_GoodsNo                = stockShipArrivalListCndtn.St_GoodsNo;                 // 開始商品番号
                stockShipArrivalListCndtnWork.Ed_GoodsNo                = stockShipArrivalListCndtn.Ed_GoodsNo;                 // 終了商品番号
                //--- DEL 2008/07/16 ---------->>>>>
                //stockShipArrivalListCndtnWork.St_WarehouseShelfNo       = stockShipArrivalListCndtn.St_WarehouseShelfNo;      // 開始倉庫棚番
                //stockShipArrivalListCndtnWork.Ed_WarehouseShelfNo       = stockShipArrivalListCndtn.Ed_WarehouseShelfNo;      // 終了倉庫棚番
                //--- DEL 2008/07/16 ----------<<<<<
                stockShipArrivalListCndtnWork.ShipArrivalPrintDiv = (int)stockShipArrivalListCndtn.ShipArrivalPrintDiv;         // 印刷タイプ
                stockShipArrivalListCndtnWork.StockCreateDate           = stockShipArrivalListCndtn.StockCreateDate;            // 在庫登録日
                stockShipArrivalListCndtnWork.StockCreateDateDiv        = (int)stockShipArrivalListCndtn.StockCreateDateDiv;    // 在庫登録日指定区分
                stockShipArrivalListCndtnWork.ShipArrivalCntDiv         = (int)stockShipArrivalListCndtn.ShipArrivalCntDiv;     // 出荷数指定区分
                stockShipArrivalListCndtnWork.St_ShipArrivalCnt         = stockShipArrivalListCndtn.St_ShipArrivalCnt;          // 開始入出荷数
                stockShipArrivalListCndtnWork.Ed_ShipArrivalCnt         = stockShipArrivalListCndtn.Ed_ShipArrivalCnt;          // 終了入出荷数


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
		/// <param name="stockShipArrivalListCndtn">UI抽出条件クラス</param>
		/// <param name="stockMoveWork">取得データ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 取得データを展開する。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.09.19</br>
        /// <br>Update Note: 2012/12/24 王君</br>
        /// <br>             Redmine#33977の対応</br>
		/// </remarks>
		private void DevStockMoveData ( StockShipArrivalListCndtn stockShipArrivalListCndtn, ArrayList stockMoveWork )
		{
			DataRow dr;

			foreach ( StockShipArrivalListWork stockShipArrivalListWork in stockMoveWork )
			{
                //--- ADD 2008/07/22 ---------->>>>>
                int status = 0;
                int BLGloupCode = 0;
                int GoodsMGroup = 0;
                int GoodsLGroup = 0;

                // ---DEL 2009/03/18 不具合対応[12542] ---------------------->>>>>
                //status = GoodsGanreCheck(stockShipArrivalListCndtn, stockShipArrivalListWork.BLGoodsCode, out BLGloupCode, out GoodsMGroup, out GoodsLGroup);
                // ---DEL 2009/03/18 不具合対応[12542] ----------------------<<<<<
                // ---ADD 2009/03/18 不具合対応[12542] ---------------------->>>>>
                string BLGroupName = string.Empty;
                string GoodsMGroupName = string.Empty;
                string GoodsLGroupName = string.Empty;
                status = GoodsGanreCheck(stockShipArrivalListCndtn, stockShipArrivalListWork.BLGoodsCode,
                                        out BLGloupCode,out BLGroupName,
                                        out GoodsMGroup,out GoodsMGroupName,
                                        out GoodsLGroup,out GoodsLGroupName);

                // ---ADD 2009/03/18 不具合対応[12542] ----------------------<<<<<
                
                if (status == 0)
                {
                //--- ADD 2008/07/22 ----------<<<<<

                    dr = this._stockShipArrivalListDt.NewRow();
                    // 取得データ展開
                    #region 取得データ展開
                    /* ---DEL 2009/04/02 不具合対応[12998] ---------------------------------------------------------------------------------------------->>>>> 
                    //dr[DCZAI02125EA.ct_Col_SectionCode] = stockShipArrivalListWork.SectionCode;             // 拠点コード             //DEL 2009/03/18 不具合対応[12542]
                    dr[DCZAI02125EA.ct_Col_SectionCode] = stockShipArrivalListWork.SectionCode.Trim().PadLeft(2, '0');  // 拠点コード   //ADD 2009/03/18 不具合対応[12542]
                    //dr[DCZAI02125EA.ct_Col_SectionGuideNm] = this.GetSectionGuideNm(stockShipArrivalListWork.SectionCode); // 拠点ガイド名称          //DEL 2009/02/26 不具合対応[11965]
                    dr[DCZAI02125EA.ct_Col_SectionGuideNm] = this.GetSectionGuideNm(stockShipArrivalListWork.SectionCode.Trim()); // 拠点ガイド名称     //ADD 2009/02/26 不具合対応[11965]
                       ---DEL 2009/04/02 不具合対応[12998] ----------------------------------------------------------------------------------------------<<<<< */
                    //--- DEL 2008/07/16 ---------->>>>>
                    //dr[DCZAI02125EA.ct_Col_CustomerCode] = stockShipArrivalListWork.CustomerCode;         // 仕入先コード
                    //dr[DCZAI02125EA.ct_Col_CustomerName] = stockShipArrivalListWork.CustomerName;         // 仕入先名称
                    //dr[DCZAI02125EA.ct_Col_CustomerName2] = stockShipArrivalListWork.CustomerName2;       // 仕入先名称2
                    //--- DEL 2008/07/16 ----------<<<<<
                    //dr[DCZAI02125EA.ct_Col_CustomerSnm] = stockShipArrivalListWork.CustomerSnm;           // 仕入先略称
                    dr[DCZAI02125EA.ct_Col_GoodsMakerCd] = stockShipArrivalListWork.GoodsMakerCd;           // 商品メーカーコード
                    dr[DCZAI02125EA.ct_Col_MakerName] = stockShipArrivalListWork.MakerName;                 // メーカー名称
                    // ---ADD 2009/03/26 不具合対応[12800] ----------------------------------------------------->>>>>
                    if ((stockShipArrivalListWork.GoodsMakerCd == 0) || (string.IsNullOrEmpty(stockShipArrivalListWork.MakerName.Trim())))
                    {
                        dr[DCZAI02125EA.ct_Col_MakerName] = "未登録";
                    }
                    // ---ADD 2009/03/26 不具合対応[12800] -----------------------------------------------------<<<<<
                    //dr[DCZAI02125EA.ct_Col_WarehouseCode] = stockShipArrivalListWork.WarehouseCode;         // 倉庫コード                 //DEL 2009/03/18 不具合対応[12542]
                    dr[DCZAI02125EA.ct_Col_WarehouseCode] = stockShipArrivalListWork.WarehouseCode.Trim().PadLeft(4, '0');  // 倉庫コード   //ADD 2009/03/18 不具合対応[12542]
                    dr[DCZAI02125EA.ct_Col_WarehouseName] = stockShipArrivalListWork.WarehouseName;         // 倉庫名称
                    // ---ADD 2009/03/26 不具合対応[12800] ----------------------------------------------------->>>>>
                    if ((stockShipArrivalListWork.WarehouseCode.Trim().PadLeft(4, '0') == "0000") ||
                        (string.IsNullOrEmpty(stockShipArrivalListWork.WarehouseName.Trim())))
                    {
                        dr[DCZAI02125EA.ct_Col_WarehouseName] = "未登録";
                    }
                    // ---ADD 2009/03/26 不具合対応[12800] -----------------------------------------------------<<<<<

                    dr[DCZAI02125EA.ct_Col_GoodsNo] = stockShipArrivalListWork.GoodsNo;                     // 商品番号
                    dr[DCZAI02125EA.ct_Col_GoodsName] = stockShipArrivalListWork.GoodsName;                 // 商品名称
                    dr[DCZAI02125EA.ct_Col_WarehouseShelfNo] = stockShipArrivalListWork.WarehouseShelfNo;   // 倉庫棚番
                    //dr[DCZAI02125EA.ct_Col_StockCreateDate] = stockShipArrivalListWork.StockCreateDate.ToString("yy/MM/dd"); // 在庫登録日 //DEL 2012/12/24 王君 Redmine#33977
                    dr[DCZAI02125EA.ct_Col_StockCreateDate] = TDateTime.DateTimeToString("YY/MM/DD", stockShipArrivalListWork.StockCreateDate);// ADD 2012/12/24 王君 Redmine#33977 
                    dr[DCZAI02125EA.ct_Col_ShipmentCnt1] = stockShipArrivalListWork.ShipmentCnt1;           // 出荷数1
                    dr[DCZAI02125EA.ct_Col_ArrivalCnt1] = stockShipArrivalListWork.ArrivalCnt1;             // 入荷数1
                    dr[DCZAI02125EA.ct_Col_ShipmentCnt2] = stockShipArrivalListWork.ShipmentCnt2;           // 出荷数2
                    dr[DCZAI02125EA.ct_Col_ArrivalCnt2] = stockShipArrivalListWork.ArrivalCnt2;             // 入荷数2
                    dr[DCZAI02125EA.ct_Col_ShipmentCnt3] = stockShipArrivalListWork.ShipmentCnt3;           // 出荷数3
                    dr[DCZAI02125EA.ct_Col_ArrivalCnt3] = stockShipArrivalListWork.ArrivalCnt3;             // 入荷数3
                    dr[DCZAI02125EA.ct_Col_ShipmentCnt4] = stockShipArrivalListWork.ShipmentCnt4;           // 出荷数4
                    dr[DCZAI02125EA.ct_Col_ArrivalCnt4] = stockShipArrivalListWork.ArrivalCnt4;             // 入荷数4
                    dr[DCZAI02125EA.ct_Col_ShipmentCnt5] = stockShipArrivalListWork.ShipmentCnt5;           // 出荷数5
                    dr[DCZAI02125EA.ct_Col_ArrivalCnt5] = stockShipArrivalListWork.ArrivalCnt5;             // 入荷数5
                    dr[DCZAI02125EA.ct_Col_ShipmentCnt6] = stockShipArrivalListWork.ShipmentCnt6;           // 出荷数6
                    dr[DCZAI02125EA.ct_Col_ArrivalCnt6] = stockShipArrivalListWork.ArrivalCnt6;             // 入荷数6
                    dr[DCZAI02125EA.ct_Col_ShipmentCnt7] = stockShipArrivalListWork.ShipmentCnt7;           // 出荷数7
                    dr[DCZAI02125EA.ct_Col_ArrivalCnt7] = stockShipArrivalListWork.ArrivalCnt7;             // 入荷数7
                    dr[DCZAI02125EA.ct_Col_ShipmentCnt8] = stockShipArrivalListWork.ShipmentCnt8;           // 出荷数8
                    dr[DCZAI02125EA.ct_Col_ArrivalCnt8] = stockShipArrivalListWork.ArrivalCnt8;             // 入荷数8
                    dr[DCZAI02125EA.ct_Col_ShipmentCnt9] = stockShipArrivalListWork.ShipmentCnt9;           // 出荷数9
                    dr[DCZAI02125EA.ct_Col_ArrivalCnt9] = stockShipArrivalListWork.ArrivalCnt9;             // 入荷数9
                    dr[DCZAI02125EA.ct_Col_ShipmentCnt10] = stockShipArrivalListWork.ShipmentCnt10;         // 出荷数10
                    dr[DCZAI02125EA.ct_Col_ArrivalCnt10] = stockShipArrivalListWork.ArrivalCnt10;           // 入荷数10
                    dr[DCZAI02125EA.ct_Col_ShipmentCnt11] = stockShipArrivalListWork.ShipmentCnt11;         // 出荷数11
                    dr[DCZAI02125EA.ct_Col_ArrivalCnt11] = stockShipArrivalListWork.ArrivalCnt11;           // 入荷数11
                    dr[DCZAI02125EA.ct_Col_ShipmentCnt12] = stockShipArrivalListWork.ShipmentCnt12;         // 出荷数12
                    dr[DCZAI02125EA.ct_Col_ArrivalCnt12] = stockShipArrivalListWork.ArrivalCnt12;           // 入荷数12
                    dr[DCZAI02125EA.ct_Col_Avg_ShipmentCnt] = stockShipArrivalListWork.AVG_ShipmentCnt;     // 平均出荷数
                    dr[DCZAI02125EA.ct_Col_Avg_ArrivalCnt] = stockShipArrivalListWork.AVG_ArrivalCnt;       // 平均入荷数
                    dr[DCZAI02125EA.ct_Col_Sum_ShipmentCnt] = stockShipArrivalListWork.SUM_ShipmentCnt;     // 合計出荷数
                    dr[DCZAI02125EA.ct_Col_Sum_ArrivalCnt] = stockShipArrivalListWork.SUM_ArrivalCnt;       // 合計入荷数

                    //dr[DCZAI02125EA.ct_Col_Sort_SectionCode] = stockShipArrivalListWork.SectionCode.Trim().PadLeft(2, '0');     // 拠点コード   // ADD 2009/03/18 → //DEL 2009/04/02 不具合対応[12998]
                    /* ---DEL 2009/03/18 不具合対応[12542] ------------------------------------>>>>>
                    //dr[DCZAI02125EA.ct_Col_Sort_CustomerCode] = stockShipArrivalListWork.CustomerCode;    // 仕入先コード    // DEL 2008/07/16
                    dr[DCZAI02125EA.ct_Col_Sort_CustomerCode] = stockShipArrivalListWork.StockSupplierCode; // 仕入先コード    // ADD 2008/07/16　→　DEL 2009/03/18
                       ---DEL 2009/03/18 不具合対応[12542] ------------------------------------<<<<< */
                    dr[DCZAI02125EA.ct_Col_Sort_GoodsMakerCd] = stockShipArrivalListWork.GoodsMakerCd;      // 商品メーカーコード
                    //dr[DCZAI02125EA.ct_Col_Sort_WarehouseCode] = stockShipArrivalListWork.WarehouseCode;    // 倉庫コード                     //DEL 2009/03/18 不具合対応[12542]
                    dr[DCZAI02125EA.ct_Col_Sort_WarehouseCode] = stockShipArrivalListWork.WarehouseCode.Trim().PadLeft(4, '0'); // 倉庫コード   //ADD 2009/03/18 不具合対応[12542]
                    dr[DCZAI02125EA.ct_Col_Sort_GoodsNo] = stockShipArrivalListWork.GoodsNo;                // 商品番号

                    dr[DCZAI02125EA.ct_Col_Sort_LargeGoodsGanre] = GoodsLGroup;
                    dr[DCZAI02125EA.ct_Col_Sort_MediumGoodsGanre] = GoodsMGroup;
                    dr[DCZAI02125EA.ct_Col_Sort_DetailGoodsGanre] = BLGloupCode;

                    dr[DCZAI02125EA.ct_Col_Sort_LargeGoodsGanre] = GoodsLGroup;
                    dr[DCZAI02125EA.ct_Col_Sort_MediumGoodsGanre] = GoodsMGroup;
                    dr[DCZAI02125EA.ct_Col_Sort_DetailGoodsGanre] = BLGloupCode;

                    // ---ADD 2009/03/18 不具合対応[12542] ------------------------------------>>>>>
                    dr[DCZAI02125EA.ct_Col_LargeGoodsGanreName] = GoodsLGroupName;                          // 商品大分類名称
                    dr[DCZAI02125EA.ct_Col_MediumGoodsGanreName] = GoodsMGroupName;                         // 商品中分類名称
                    dr[DCZAI02125EA.ct_Col_DetailGoodsGanreName] = BLGroupName;                             // BLグループ名称

                    // 商品管理情報マスタより仕入先コード、仕入先略称取得
                    if (stockShipArrivalListWork.StockSupplierCode == 0)
                    {
                        int supplierCd;
                        string supplierName;
                        this.GetGoodsMngInfo(dr,stockShipArrivalListWork.BLGoodsCode, out supplierCd, out supplierName);
                        dr[DCZAI02125EA.ct_Col_CustomerCode] = supplierCd;          // 仕入先コード
                        dr[DCZAI02125EA.ct_Col_CustomerName] = supplierName;        // 仕入先名称１
                        dr[DCZAI02125EA.ct_Col_Sort_CustomerCode] = supplierCd;     // ソート用仕入先コード
                    }
                    else
                    {
                        dr[DCZAI02125EA.ct_Col_CustomerCode] = stockShipArrivalListWork.StockSupplierCode;          // 仕入先コード
                        dr[DCZAI02125EA.ct_Col_CustomerName] = string.Empty;                                        // 仕入先名称１
                    }
                    // ---ADD 2009/03/18 不具合対応[12542] ------------------------------------<<<<<
                    #endregion

                    // TableにAdd
                    this._stockShipArrivalListDt.Rows.Add(dr);
                }
			}

            this._stockShipArrivalListDt.CaseSensitive = true;          //ADD 2009/03/30 不具合対応[12874]

			// DataView作成
			//this._stockShipArrivalListDataView = new DataView( this._stockShipArrivalListDt, "", GetSortOrder(stockShipArrivalListCndtn), DataViewRowState.CurrentRows );     //DEL 2009/04/02 不具合対応[13023]
            this._stockShipArrivalListDataView = new DataView(this._stockShipArrivalListDt, this.GetFilter(stockShipArrivalListCndtn), GetSortOrder(stockShipArrivalListCndtn), DataViewRowState.CurrentRows);       //ADD 2009/04/02 不具合対応[13023]
        }

        // ---ADD 2009/04/02 不具合対応[13023] ------------------------------->>>>>
        #region ◎ フィルタ作成
        /// <summary>
        /// フィルタ作成
        /// </summary>
        /// <returns>フィルタ文字列</returns>
        private string GetFilter(StockShipArrivalListCndtn stockShipArrivalListCndtn)
        {
            string strQuery = "";

            if ((stockShipArrivalListCndtn.St_CustomerCode != 0) && (stockShipArrivalListCndtn.Ed_CustomerCode != 0))
            {
                strQuery = String.Format("{0} <= {1} AND {2} <= {3}",
                stockShipArrivalListCndtn.St_CustomerCode.ToString(),
                DCZAI02125EA.ct_Col_CustomerCode,
                DCZAI02125EA.ct_Col_CustomerCode,
                stockShipArrivalListCndtn.Ed_CustomerCode.ToString());
            }

            if ((stockShipArrivalListCndtn.St_CustomerCode != 0) && (stockShipArrivalListCndtn.Ed_CustomerCode == 0))
            {
                strQuery = String.Format("{0} <= {1}",
                stockShipArrivalListCndtn.St_CustomerCode.ToString(),
                DCZAI02125EA.ct_Col_CustomerCode);
            }

            if ((stockShipArrivalListCndtn.St_CustomerCode == 0) && (stockShipArrivalListCndtn.Ed_CustomerCode != 0))
            {
                strQuery = String.Format("{0} <= {1}",
                DCZAI02125EA.ct_Col_CustomerCode,
                stockShipArrivalListCndtn.Ed_CustomerCode.ToString());
            }

            return strQuery;
        }
        #endregion
        // ---ADD 2009/04/02 不具合対応[13023] -------------------------------<<<<<

        // ---ADD 2009/03/18 不具合対応[12542] -------------------------------------------------->>>>>
        /// <summary>
        /// 仕入先情報取得
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="BLGoodsCode">BLコード</param>
        /// <param name="supplierCd">仕入先(返却値)</param>
        /// <param name="supplierName">仕入先略称(返却値)</param>
        /// <remarks>
        /// <br>Note       : 商品管理情報マスタより仕入先情報を取得する。</br>
        /// <br>Programmer :       照田 貴志</br>
        /// <br>Date       : 2009/03/18</br>
        /// </remarks>
        private void GetGoodsMngInfo(DataRow dr, int BLGoodsCode, out int supplierCd, out string supplierName)
        {
            supplierCd = 0;
            supplierName = "";

            GoodsUnitData goodsUnitData = new GoodsUnitData();
            goodsUnitData.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            goodsUnitData.GoodsMakerCd = (int)dr[DCZAI02125EA.ct_Col_GoodsMakerCd];
            goodsUnitData.GoodsNo = dr[DCZAI02125EA.ct_Col_GoodsNo].ToString();
            //goodsUnitData.SectionCode = dr[DCZAI02125EA.ct_Col_SectionCode].ToString();           //DEL 2009/04/02 不具合対応[13023]
            goodsUnitData.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;            //ADD 2009/04/02 不具合対応[13023]
            //goodsUnitData.GoodsLGroup = int.Parse(dr[DCZAI02125EA.ct_Col_Sort_LargeGoodsGanre].ToString());   //DEL 2009/03/26 不具合対応[12800]
            goodsUnitData.GoodsMGroup = int.Parse(dr[DCZAI02125EA.ct_Col_Sort_MediumGoodsGanre].ToString());
            //goodsUnitData.BLGroupCode = int.Parse(dr[DCZAI02125EA.ct_Col_Sort_DetailGoodsGanre].ToString());  //DEL 2009/03/26 不具合対応[12800]
            goodsUnitData.BLGoodsCode = BLGoodsCode;
            
            stc_GoodsAcs.GetGoodsMngInfo(ref goodsUnitData);
            //stc_GoodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData);                   //DEL 2009/03/26 不具合対応[12800]

            supplierCd = goodsUnitData.SupplierCd;
            //supplierName = goodsUnitData.SupplierNm1;         //DEL 2009/03/26 不具合対応[12800]
            // ---ADD 2009/03/26 不具合対応[12800] ---------------------->>>>>
            if (supplierCd == 0)
            {
                supplierName = "未登録";
            }
            else
            {
                SupplierWork supplierWork = null;
                int status = stc_GoodsAcs.GetSupplier(LoginInfoAcquisition.EnterpriseCode, goodsUnitData.SupplierCd, out supplierWork);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    supplierName = supplierWork.SupplierNm1;
                }
                else
                {
                    supplierName = "未登録";
                }

            }
            // ---ADD 2009/03/26 不具合対応[12800] ----------------------<<<<<
        }
        // ---ADD 2009/03/18 不具合対応[12542] --------------------------------------------------<<<<<

        //--- ADD 2008/07/22 ---------->>>>>
        /// <summary>
        /// 商品区分絞込処理
        /// </summary>
        /// <param name="stockShipArrivalListCndtn"></param>
        /// <param name="BLGoodsCode"></param>
        /// <param name="BLGloupCode"></param>
        /// <param name="BLGroupName"></param>
        /// <param name="GoodsMGroup"></param>
        /// <param name="GoodsMGroupName"></param>
        /// <param name="GoodsLGroup"></param>
        /// <param name="GoodsLGroupName"></param>
        /// <returns></returns>
        // ---DEL 2009/03/18 不具合対応[12542] ------------------------------------------------------------------------------------------------------------------->>>>>
        //private int GoodsGanreCheck(StockShipArrivalListCndtn stockShipArrivalListCndtn, int BLGoodsCode, out int BLGloupCode, out int GoodsMGroup, out int GoodsLGroup)
        // ---DEL 2009/03/18 不具合対応[12542] -------------------------------------------------------------------------------------------------------------------<<<<<
        // ---ADD 2009/03/18 不具合対応[12542] ------------------------------------------------------------------------------------------------------------------->>>>>
        private int GoodsGanreCheck(StockShipArrivalListCndtn stockShipArrivalListCndtn, int BLGoodsCode,
                                    out int BLGloupCode, out string BLGroupName,
                                    out int GoodsMGroup, out string GoodsMGroupName,
                                    out int GoodsLGroup, out string GoodsLGroupName)
        // ---ADD 2009/03/18 不具合対応[12542] -------------------------------------------------------------------------------------------------------------------<<<<<
        {
            int status = 0;
            BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();

            BLGloupCode = 0;
            GoodsMGroup = 0;
            GoodsLGroup = 0;

            /* ---DEL 2009/03/26 不具合対応[12800] --------------------->>>>>
            // ---ADD 2009/03/18 不具合対応[12542] --------------------->>>>>
            BLGroupName = string.Empty;
            GoodsMGroupName = string.Empty;
            GoodsLGroupName = string.Empty;
            // ---ADD 2009/03/18 不具合対応[12542] ---------------------<<<<<
               ---DEL 2009/03/26 不具合対応[12800] ---------------------<<<<< */
            // ---ADD 2009/03/26 不具合対応[12800] --------------------->>>>>
            BLGroupName = "未登録";
            GoodsMGroupName = "未登録";
            GoodsLGroupName = "未登録";
            // ---ADD 2009/03/26 不具合対応[12800] ---------------------<<<<<

            // BLコードマスタ取得
            status = stc_GoodsAcs.GetBLGoodsCd(BLGoodsCode, out bLGoodsCdUMnt);

            // ---ADD 2008/12/17 不具合対応[9308] ----------------------------------------------------------------------------------------------------->>>>>
            if (bLGoodsCdUMnt == null)
            {
                // ---DEL 2009/02/27 不具合対応[12008] ------------------------------------------------------------>>>>>
                //// BLコード情報が取得できなかった場合、BLコードが「最初から最後まで」、グループコードが「最初から最後まで」の時のみ対象とする
                //if (((stockShipArrivalListCndtn.St_BLGoodsCode == 0) && (stockShipArrivalListCndtn.Ed_BLGoodsCode > 99999)) &&
                //    ((string.IsNullOrEmpty(stockShipArrivalListCndtn.St_DetailGoodsGanreCode) && (string.IsNullOrEmpty(stockShipArrivalListCndtn.Ed_DetailGoodsGanreCode)))))
                //{
                //    return 0;       //対象
                //}
                //else
                //{
                //    return 1;       //対象外
                //}
                // ---DEL 2009/02/27 不具合対応[12008] ------------------------------------------------------------<<<<<
                // ---ADD 2009/02/27 不具合対応[12008] ------------------------------------------------------------>>>>>
                // グループ、大分類、中分類に条件が入ってる場合は抽出対象外とする
                if ((!RangeUtil.BLGroupCode.IsAllRange(stockShipArrivalListCndtn.St_DetailGoodsGanreCode, stockShipArrivalListCndtn.Ed_DetailGoodsGanreCode)) ||
                    (!RangeUtil.GoodsMGroupCode.IsAllRange(stockShipArrivalListCndtn.St_MediumGoodsGanreCode, stockShipArrivalListCndtn.Ed_MediumGoodsGanreCode)) ||
                    (!RangeUtil.GoodsLGroupCode.IsAllRange(stockShipArrivalListCndtn.St_LargeGoodsGanreCode, stockShipArrivalListCndtn.Ed_LargeGoodsGanreCode)))
                {
                    return 1;       //対象外
                }
                else
                {
                    return 0;       //対象
                }
                // ---ADD 2009/02/27 不具合対応[12008] ------------------------------------------------------------<<<<<
            }
            // ---ADD 2008/12/17 不具合対応[9308] -----------------------------------------------------------------------------------------------------<<<<<

            if (status == 0)
            {
                BLGloupCode = bLGoodsCdUMnt.BLGloupCode;

                // グループコードチェック
                if (stockShipArrivalListCndtn.St_DetailGoodsGanreCode != string.Empty && stockShipArrivalListCndtn.Ed_DetailGoodsGanreCode != string.Empty)
                {
                    // 開始<=終了 範囲内か？
                    //if (int.Parse(stockShipArrivalListCndtn.St_DetailGoodsGanreCode) >= bLGoodsCdUMnt.BLGloupCode ||          //DEL 2009/02/27　不具合対応[12008]
                    //   int.Parse(stockShipArrivalListCndtn.Ed_DetailGoodsGanreCode) <= bLGoodsCdUMnt.BLGloupCode)             //DEL 2009/02/27　不具合対応[12008]
                    if (int.Parse(stockShipArrivalListCndtn.St_DetailGoodsGanreCode) > bLGoodsCdUMnt.BLGloupCode ||             //ADD 2009/02/27　不具合対応[12008]
                       int.Parse(stockShipArrivalListCndtn.Ed_DetailGoodsGanreCode) < bLGoodsCdUMnt.BLGloupCode)                //ADD 2009/02/27　不具合対応[12008]
                    {
                        status = 1;
                        return status;
                    }
                }
                else if (stockShipArrivalListCndtn.St_DetailGoodsGanreCode != string.Empty && stockShipArrivalListCndtn.Ed_DetailGoodsGanreCode == string.Empty)
                {
                    // 開始<=最後まで 範囲内か？
                    //if (int.Parse(stockShipArrivalListCndtn.St_DetailGoodsGanreCode) >= bLGoodsCdUMnt.BLGloupCode)            //DEL 2009/02/27　不具合対応[12008]
                    if (int.Parse(stockShipArrivalListCndtn.St_DetailGoodsGanreCode) > bLGoodsCdUMnt.BLGloupCode)               //ADD 2009/02/27　不具合対応[12008]
                    {
                        status = 1;
                        return status;
                    }
                }
                else if (stockShipArrivalListCndtn.St_DetailGoodsGanreCode == string.Empty && stockShipArrivalListCndtn.Ed_DetailGoodsGanreCode != string.Empty)
                {
                    // 最初から<=終了 範囲内か？
                    //if (int.Parse(stockShipArrivalListCndtn.Ed_DetailGoodsGanreCode) <= bLGoodsCdUMnt.BLGloupCode)            //DEL 2009/02/27　不具合対応[12008]
                    if (int.Parse(stockShipArrivalListCndtn.Ed_DetailGoodsGanreCode) < bLGoodsCdUMnt.BLGloupCode)               //ADD 2009/02/27　不具合対応[12008]
                    {
                        status = 1;
                        return status;
                    }
                }

                BLGroupU bLGroupU = new BLGroupU();

                // BLグループマスタ取得
                //stc_GoodsAcs.GetBLGroup(stockShipArrivalListCndtn.EnterpriseCode, bLGoodsCdUMnt.BLGloupCode, out bLGroupU);       //DEL 2009/03/26 不具合対応[12800]
                // ---ADD 2009/03/26 不具合対応[12800] --------------------->>>>>
                int ret = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                ret = stc_GoodsAcs.GetBLGroup(stockShipArrivalListCndtn.EnterpriseCode, bLGoodsCdUMnt.BLGloupCode, out bLGroupU);
                if (ret == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    BLGroupName =   bLGroupU.BLGroupName;
                }
                // ---ADD 2009/03/26 不具合対応[12800] ---------------------<<<<<
                // ---DEL 2009/02/27 不具合対応[12008] ------------------------------------------------------------>>>>>
                //// ---ADD 2008/12/17 不具合対応[9308] ----------------------------------------------------------------------------------------------------->>>>>
                //if (bLGroupU == null)
                //{
                //    // BLグループコード情報が取得できなかった場合、グループコードが「最初から最後まで」の時のみ対象とする
                //    if ((string.IsNullOrEmpty(stockShipArrivalListCndtn.St_DetailGoodsGanreCode) && (string.IsNullOrEmpty(stockShipArrivalListCndtn.Ed_DetailGoodsGanreCode))))
                //    {
                //        return 0;       //対象
                //    }
                //    else
                //    {
                //        return 1;       //対象外
                //    }
                //}
                //// ---ADD 2008/12/17 不具合対応[9308] -----------------------------------------------------------------------------------------------------<<<<<
                // ---DEL 2009/02/27 不具合対応[12008] ------------------------------------------------------------<<<<<
                // ---ADD 2009/02/27 不具合対応[12008] ------------------------------------------------------------>>>>>
                if (bLGroupU == null)
                {
                    // 大分類、中分類に条件が入ってる場合は抽出対象外とする
                    if ((!RangeUtil.GoodsMGroupCode.IsAllRange(stockShipArrivalListCndtn.St_MediumGoodsGanreCode, stockShipArrivalListCndtn.Ed_MediumGoodsGanreCode)) ||
                        (!RangeUtil.GoodsLGroupCode.IsAllRange(stockShipArrivalListCndtn.St_LargeGoodsGanreCode, stockShipArrivalListCndtn.Ed_LargeGoodsGanreCode)))
                    {
                        status = 1;
                    }
                    else
                    {
                        status = 0;
                    }
                    return status;
                }
                // ---ADD 2009/02/27 不具合対応[12008] ------------------------------------------------------------<<<<<

                GoodsMGroup = bLGroupU.GoodsMGroup;
                GoodsLGroup = bLGroupU.GoodsLGroup;
                /* ---DEL 2009/03/26 不具合対応[12800] --------------------->>>>>
                // ---ADD 2009/03/18 不具合対応[12542] --------------------->>>>>
                BLGroupName = bLGroupU.BLGroupName;

                UserGdBdU goodsLGroupU;
                GoodsGroupU goodsMGroupU;

                stc_GoodsAcs.GetGoodsMGroup(LoginInfoAcquisition.EnterpriseCode, GoodsMGroup, out goodsMGroupU);
                GoodsMGroupName = goodsMGroupU.GoodsMGroupName;

                stc_GoodsAcs.GetGoodsLGroup(LoginInfoAcquisition.EnterpriseCode, GoodsLGroup, out goodsLGroupU);
                GoodsLGroupName = goodsLGroupU.GuideName;
                // ---ADD 2009/03/18 不具合対応[12542] ---------------------<<<<<
                   ---DEL 2009/03/26 不具合対応[12800] ---------------------<<<<< */
                // ---ADD 2009/03/26 不具合対応[12800] --------------------->>>>>
                UserGdBdU goodsLGroupU;
                GoodsGroupU goodsMGroupU;

                ret = stc_GoodsAcs.GetGoodsMGroup(LoginInfoAcquisition.EnterpriseCode, GoodsMGroup, out goodsMGroupU);
                if (ret == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    GoodsMGroupName = goodsMGroupU.GoodsMGroupName;
                }

                ret = stc_GoodsAcs.GetGoodsLGroup(LoginInfoAcquisition.EnterpriseCode, GoodsLGroup, out goodsLGroupU);
                if (ret == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    GoodsLGroupName = goodsLGroupU.GuideName;
                }
                // ---ADD 2009/03/26 不具合対応[12800] ---------------------<<<<<

                // 商品中分類チェック
                if (stockShipArrivalListCndtn.St_MediumGoodsGanreCode != string.Empty && stockShipArrivalListCndtn.Ed_MediumGoodsGanreCode != string.Empty)
                {
                    // 開始<=終了 範囲内か？
                    //if (int.Parse(stockShipArrivalListCndtn.St_MediumGoodsGanreCode) >= bLGroupU.GoodsMGroup ||               //DEL 2009/02/27　不具合対応[12008]
                    //   int.Parse(stockShipArrivalListCndtn.Ed_MediumGoodsGanreCode) <= bLGroupU.GoodsMGroup)                  //DEL 2009/02/27　不具合対応[12008]
                    if (int.Parse(stockShipArrivalListCndtn.St_MediumGoodsGanreCode) > bLGroupU.GoodsMGroup ||                  //ADD 2009/02/27　不具合対応[12008]
                       int.Parse(stockShipArrivalListCndtn.Ed_MediumGoodsGanreCode) < bLGroupU.GoodsMGroup)                     //ADD 2009/02/27　不具合対応[12008]
                    {
                        status = 1;
                        return status;
                    }
                }
                else if (stockShipArrivalListCndtn.St_MediumGoodsGanreCode != string.Empty && stockShipArrivalListCndtn.Ed_MediumGoodsGanreCode == string.Empty)
                {
                    // 開始<=最後まで 範囲内か？
                    //if (int.Parse(stockShipArrivalListCndtn.St_MediumGoodsGanreCode) >= bLGroupU.GoodsMGroup)                 //DEL 2009/02/27　不具合対応[12008]
                    if (int.Parse(stockShipArrivalListCndtn.St_MediumGoodsGanreCode) > bLGroupU.GoodsMGroup)                    //ADD 2009/02/27　不具合対応[12008]
                    {
                        status = 1;
                        return status;
                    }
                }
                else if (stockShipArrivalListCndtn.St_MediumGoodsGanreCode == string.Empty && stockShipArrivalListCndtn.Ed_MediumGoodsGanreCode != string.Empty)
                {
                    // 最初から<=終了 範囲内か？
                    //if (int.Parse(stockShipArrivalListCndtn.Ed_MediumGoodsGanreCode) <= bLGroupU.GoodsMGroup)                 //DEL 2009/02/27　不具合対応[12008]
                    if (int.Parse(stockShipArrivalListCndtn.Ed_MediumGoodsGanreCode) < bLGroupU.GoodsMGroup)                    //ADD 2009/02/27　不具合対応[12008]
                    {
                        status = 1;
                        return status;
                    }
                }

                // 商品大分類チェック
                if (stockShipArrivalListCndtn.St_LargeGoodsGanreCode != string.Empty && stockShipArrivalListCndtn.Ed_LargeGoodsGanreCode != string.Empty)
                {
                    // 開始<=終了 範囲内か？
                    //if (int.Parse(stockShipArrivalListCndtn.St_LargeGoodsGanreCode) >= bLGroupU.GoodsLGroup ||                //DEL 2009/02/27　不具合対応[12008]
                    //   int.Parse(stockShipArrivalListCndtn.Ed_LargeGoodsGanreCode) <= bLGroupU.GoodsLGroup)                   //DEL 2009/02/27　不具合対応[12008]
                    if (int.Parse(stockShipArrivalListCndtn.St_LargeGoodsGanreCode) > bLGroupU.GoodsLGroup ||                   //ADD 2009/02/27　不具合対応[12008]
                       int.Parse(stockShipArrivalListCndtn.Ed_LargeGoodsGanreCode) < bLGroupU.GoodsLGroup)                      //ADD 2009/02/27　不具合対応[12008]
                    {
                        status = 1;
                        return status;
                    }
                }
                else if (stockShipArrivalListCndtn.St_LargeGoodsGanreCode != string.Empty && stockShipArrivalListCndtn.Ed_LargeGoodsGanreCode == string.Empty)
                {
                    // 開始<=最後まで 範囲内か？
                    //if (int.Parse(stockShipArrivalListCndtn.St_LargeGoodsGanreCode) >= bLGroupU.GoodsLGroup)                  //DEL 2009/02/27　不具合対応[12008]
                    if (int.Parse(stockShipArrivalListCndtn.St_LargeGoodsGanreCode) > bLGroupU.GoodsLGroup)                     //ADD 2009/02/27　不具合対応[12008]
                    {
                        status = 1;
                        return status;
                    }
                }
                else if (stockShipArrivalListCndtn.St_LargeGoodsGanreCode == string.Empty && stockShipArrivalListCndtn.Ed_LargeGoodsGanreCode != string.Empty)
                {
                    // 最初から<=終了 範囲内か？
                    //if (int.Parse(stockShipArrivalListCndtn.Ed_LargeGoodsGanreCode) <= bLGroupU.GoodsLGroup)                  //DEL 2009/02/27　不具合対応[12008]
                    if (int.Parse(stockShipArrivalListCndtn.Ed_LargeGoodsGanreCode) < bLGroupU.GoodsLGroup)                     //ADD 2009/02/27　不具合対応[12008]
                    {
                        status = 1;
                        return status;
                    }
                }
            }
            else
            {
                status = 1;
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
            if (stc_SectionDic.ContainsKey(sectionCode)) {
                return stc_SectionDic[sectionCode].SectionGuideNm;
            }
            else {
                //return String.Empty;          //DEL 2009/03/26 不具合対応[12800]
                return "未登録";                //ADD 2009/03/26 不具合対応[12800]
            }
        }
		#endregion

		#region ◎ ソート順作成
		/// <summary>
		/// ソート順作成
		/// </summary>
		/// <returns>ソート文字列</returns>
		private string GetSortOrder( StockShipArrivalListCndtn stockShipArrivalListCndtn )
		{
			StringBuilder strSortOrder = new StringBuilder();

            //if ( !stockShipArrivalListCndtn.IsSelectAllSection )
            //{
            //    // 全社選択されてないとき
            //    // 主拠点
            //    strSortOrder.Append( string.Format("{0},", DCZAI02125EA.ct_Col_SectionCode ) );
            //}
            /* ---DEL 2009/03/18 不具合対応[12542] ------------------------------------->>>>>
            // 拠点コード
            strSortOrder.Append(string.Format("{0},", DCZAI02125EA.ct_Col_SectionCode));
            // 倉庫コード
            strSortOrder.Append(string.Format("{0},", DCZAI02125EA.ct_Col_WarehouseCode));
            // 仕入先コード
			strSortOrder.Append( string.Format("{0},", DCZAI02125EA.ct_Col_CustomerCode ) );
			// メーカーコード
			strSortOrder.Append( string.Format("{0},", DCZAI02125EA.ct_Col_GoodsMakerCd ) );
			// 商品コード
			strSortOrder.Append( string.Format("{0}", DCZAI02125EA.ct_Col_GoodsNo ) );
               ---DEL 2009/03/18 不具合対応[12542] -------------------------------------<<<<< */
            // ---ADD 2009/03/18 不具合対応[12542] ------------------------------------->>>>>
            // 拠点コード
            //strSortOrder.Append(string.Format("{0},", DCZAI02125EA.ct_Col_Sort_SectionCode));         //DEL 2009/04/02 不具合対応[12998]
            // 倉庫コード
            strSortOrder.Append(string.Format("{0},", DCZAI02125EA.ct_Col_Sort_WarehouseCode));
            // 仕入先コード
            strSortOrder.Append(string.Format("{0},", DCZAI02125EA.ct_Col_Sort_CustomerCode));
            // メーカーコード
            strSortOrder.Append(string.Format("{0},", DCZAI02125EA.ct_Col_Sort_GoodsMakerCd));
            // 商品大分類
            strSortOrder.Append(string.Format("{0},", DCZAI02125EA.ct_Col_Sort_LargeGoodsGanre));
            // 商品中分類
            strSortOrder.Append(string.Format("{0},", DCZAI02125EA.ct_Col_Sort_MediumGoodsGanre));
            // グループコード
            strSortOrder.Append(string.Format("{0},", DCZAI02125EA.ct_Col_Sort_DetailGoodsGanre));
            // 商品コード
            strSortOrder.Append(string.Format("{0}", DCZAI02125EA.ct_Col_GoodsNo));
            // ---ADD 2009/03/18 不具合対応[12542] -------------------------------------<<<<<


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

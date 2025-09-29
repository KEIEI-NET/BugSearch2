//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫分析順位表
// プログラム概要   : 在庫分析順位表で使用するデータの取得を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2006 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鈴木 正臣
// 作 成 日  2007/09/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/09/30  修正内容 : バグ修正、仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 修 正 日  2006/02/26  修正内容 : バグ修正[11975]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/02/27  修正内容 : バグ修正[12033]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/03  修正内容 : 不具合対応[12050]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/03/09  修正内容 : バグ修正[12033]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/27  修正内容 : 不具合対応[12783]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/04/06  修正内容 : 不具合対応[13001]
//----------------------------------------------------------------------------//  
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/06/05  修正内容 : 不具合対応[13395]
//----------------------------------------------------------------------------//  
// 管理番号              作成担当 : 長内 数馬
// 修 正 日  2010/05/07  修正内容 : 不要な処理を削除
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

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// 在庫分析順位表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 在庫分析順位表で使用するデータを取得する。</br>
    /// <br>Programmer   : 22018 鈴木 正臣</br>
    /// <br>Date         : 2007.09.19</br>
    /// <br>Updatenote   : 2008/09/30 照田 貴志　バグ修正、仕様変更対応</br>
    /// <br>Updatenote   : 2006/02/26 忍 幸史　バグ修正[11975]</br>
    /// <br>Updatenote   : 2009/02/27 上野 俊治　バグ修正[12033]</br>
    /// <br>             : 2009/03/03 照田 貴志　不具合対応[12050]</br>
    /// <br>Updatenote   : 2009/03/09 上野 俊治　バグ修正[12033]</br>
    /// <br>             : 2009/03/27 照田 貴志　不具合対応[12783]</br>
	/// <br>             : 2009/04/06 照田 貴志　不具合対応[13001]</br>
    /// <br>             : 2009/06/05 照田 貴志　不具合対応[13395]</br>
    /// <br>             : 2010/05/07 長内 数馬　不要な処理を削除</br>
    /// <br>Updatenote   : 2012/12/24 王君</br>
    /// <br>             : Redmine#33977の対応</br>
    /// </remarks>
	public class StockAnalysisOrderListAcs
	{
		#region ■ Constructor
		/// <summary>
		/// 在庫分析順位表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫分析順位表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.09.19</br>
		/// </remarks>
		public StockAnalysisOrderListAcs()
		{
            this._iStockAnalysisOrderListWorkDB = ( IStockAnalysisOrderListWorkDB ) MediationStockAnalysisOrderListWorkDB.GetStockAnalysisOrderListWorkDB();
		}

		/// <summary>
		/// 在庫分析順位表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫分析順位表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.09.19</br>
		/// </remarks>
        static StockAnalysisOrderListAcs ()
		{
			stc_Employee		= null;
			stc_PrtOutSet		= null;					// 帳票出力設定データクラス
			stc_PrtOutSetAcs	= new PrtOutSetAcs();	// 帳票出力設定アクセスクラス

            stc_SecInfoAcs      = new SecInfoAcs(1);    // 拠点アクセスクラス
            stc_SectionDic      = new Dictionary<string,SecInfoSet>();
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

            stc_GoodsAcs.SearchInitial(LoginInfoAcquisition.EnterpriseCode, ownSectionCode, out msg);
            //--- ADD 2008/07/22 ----------<<<<<

			// ログイン拠点取得
		    Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
		    if (loginEmployee != null)
		    {
				stc_Employee = loginEmployee.Clone();
		    }

            // 拠点Dictionary生成
            SecInfoSet[] secInfoSecList = stc_SecInfoAcs.SecInfoSetList;

            foreach ( SecInfoSet secInfoSet in secInfoSecList ) {
                // 既存でなければ
                // --- CHG 2009/02/26 障害ID:11975対応------------------------------------------------------>>>>>
                //if (!stc_SectionDic.ContainsKey(secInfoSet.SectionCode))
                if (!stc_SectionDic.ContainsKey(secInfoSet.SectionCode.Trim()))
                // --- CHG 2009/02/26 障害ID:11975対応------------------------------------------------------<<<<<
                {
                    // 追加
                    // --- CHG 2009/02/26 障害ID:11975対応------------------------------------------------------>>>>>
                    //stc_SectionDic.Add(secInfoSet.SectionCode, secInfoSet);
                    stc_SectionDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                    // --- CHG 2009/02/26 障害ID:11975対応------------------------------------------------------<<<<<
                }
            }
		}
		#endregion ■ Constructor

		#region ■ Static Member
		private static Employee stc_Employee;
		private static PrtOutSet stc_PrtOutSet;			// 帳票出力設定データクラス
		private static PrtOutSetAcs stc_PrtOutSetAcs;	// 帳票出力設定アクセスクラス

        private static SecInfoAcs stc_SecInfoAcs;                       // 拠点アクセスクラス
        private static Dictionary<string,SecInfoSet> stc_SectionDic;    // 拠点Dictionary
        //--- ADD 2008/07/22 ---------->>>>>
        private static GoodsAcs stc_GoodsAcs;                   // 商品アクセスクラス
        //--- ADD 2008/07/22 ----------<<<<<
		#endregion ■ Static Member

		#region ■ Private Member
        IStockAnalysisOrderListWorkDB _iStockAnalysisOrderListWorkDB;

		private DataTable _stockAnalysisOrderListDt;			// 印刷DataTable
		private DataView _stockAnalysisOrderListDataView;	// 印刷DataView

		#endregion ■ Private Member

		#region ■ Public Property
		/// <summary>
		/// 印刷データセット(読み取り専用)
		/// </summary>
		public DataView StockAnalysisOrderListDataView
		{
			get{ return this._stockAnalysisOrderListDataView; }
		}
		#endregion ■ Public Property

		#region ■ Public Method
		#region ◆ 出力データ取得
		#region ◎ 入金データ取得
		/// <summary>
		/// データ取得
		/// </summary>
		/// <param name="stockAnalysisOrderListCndtn">抽出条件</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷するデータを取得する。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.09.19</br>
		/// </remarks>
        public int SearchMain ( StockAnalysisOrderListCndtn stockAnalysisOrderListCndtn, out string errMsg )
		{
            return this.SearchProc(stockAnalysisOrderListCndtn, out errMsg);
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
		/// <param name="stockAnalysisOrderListCndtn"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する在庫移動データを取得する。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.09.19</br>
		/// </remarks>
        private int SearchProc ( StockAnalysisOrderListCndtn stockAnalysisOrderListCndtn, out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

			try
			{
				// DataTable Create ----------------------------------------------------------
				DCZAI02145EA.CreateDataTable( ref this._stockAnalysisOrderListDt );
				
				StockAnalysisOrderListCndtnWork stockAnalysisOrderListCndtnWork = new StockAnalysisOrderListCndtnWork();
				// 抽出条件展開  --------------------------------------------------------------
				status = this.DevStockMoveCndtn( stockAnalysisOrderListCndtn, out stockAnalysisOrderListCndtnWork, out errMsg );
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

				// データ取得  ----------------------------------------------------------------
				object retStockMoveList = null;
                
                status = this._iStockAnalysisOrderListWorkDB.Search(
                                    out retStockMoveList, stockAnalysisOrderListCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);
                //--- TEST --------->>>>>
                //retStockMoveList = this.GetTestData();
                //status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //--- TEST ---------<<<<<

				switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						// データ展開処理
						DevStockMoveData( stockAnalysisOrderListCndtn, (ArrayList)retStockMoveList );
                        //status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;       //DEL 2008/09/30 データが無い状態でもNORMALで返る為
                        // --- ADD 2008/09/30 --------------------------------------------------------->>>>>
                        if (this._stockAnalysisOrderListDataView.Count == 0)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        // --- ADD 2008/09/30 ---------------------------------------------------------<<<<<
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

            StockAnalysisOrderListWork work = new StockAnalysisOrderListWork();

            work.SectionCode = "01";				// 拠点コード
            work.SectionGuideNm = "拠点01";		    // 拠点ガイド名称
            work.WarehouseCode = "0001";            // 倉庫コード
            work.WarehouseName = "倉庫01";          // 倉庫名称
            work.SupplierCd = 1;                    // 仕入先コード
            work.SupplierSnm = "シイレサキ１";      // 仕入先略称
            work.BLGoodsCode = 1;                   // BLコード
            work.GoodsNo = "20";					// 品番
            work.GoodsName = "ヒンメイ１";			// 品名
            work.WarehouseShelfNo = "01";           // 棚番
            work.MinimumStockCnt = 1;
            work.MaximumStockCnt = 100;
            work.SalesMoneyTaxExc = 10000;
            work.ShipmentCnt = 200;
            work.ShipmentPosCnt = 300;
            work.GrossProfit = 70000;

            list.Add(work);

            StockAnalysisOrderListWork work1 = new StockAnalysisOrderListWork();

            work1.SectionCode = "01";				// 拠点コード
            work1.SectionGuideNm = "拠点01";		// 拠点ガイド名称
            work1.WarehouseCode = "0002";           // 倉庫コード
            work1.WarehouseName = "倉庫02";         // 倉庫名称
            work1.SupplierCd = 2;                   // 仕入先コード
            work1.SupplierSnm = "シイレサキ２";     // 仕入先略称
            work1.BLGoodsCode = 2;                  // BLコード
            work1.GoodsNo = "30";					// 品番
            work1.GoodsName = "ヒンメイ２";		    // 品名
            work1.WarehouseShelfNo = "02";          // 棚番
            work1.MinimumStockCnt = 1;
            work1.MaximumStockCnt = 100;
            work1.SalesMoneyTaxExc = 11000;
            work1.ShipmentCnt = 210;
            work1.ShipmentPosCnt = 310;
            work1.GrossProfit = 70000;

            list.Add(work1);

            StockAnalysisOrderListWork work2 = new StockAnalysisOrderListWork();

            work2.SectionCode = "02";				// 拠点コード
            work2.SectionGuideNm = "拠点02";		// 拠点ガイド名称
            work2.WarehouseCode = "0001";           // 倉庫コード
            work2.WarehouseName = "倉庫01";         // 倉庫名称
            work2.SupplierCd = 3;                   // 仕入先コード
            work2.SupplierSnm = "シイレサキ３";     // 仕入先略称
            work2.BLGoodsCode = 3;                  // BLコード
            work2.GoodsNo = "40";					// 品番
            work2.GoodsName = "ヒンメイ３";			// 品名
            work2.WarehouseShelfNo = "02";          // 棚番
            work2.MinimumStockCnt = 1;
            work2.MaximumStockCnt = 120;
            work2.SalesMoneyTaxExc = 12000;
            work2.ShipmentCnt = 220;
            work2.ShipmentPosCnt = 320;
            work2.GrossProfit = 72000;

            list.Add(work2);


            StockAnalysisOrderListWork work3 = new StockAnalysisOrderListWork();

            work3.SectionCode = "02";				// 拠点コード
            work3.SectionGuideNm = "拠点02";		// 拠点ガイド名称
            work3.WarehouseCode = "0002";           // 倉庫コード
            work3.WarehouseName = "倉庫02";         // 倉庫名称
            work3.SupplierCd = 4;                   // 仕入先コード
            work3.SupplierSnm = "シイレサキ４";     // 仕入先略称
            work3.BLGoodsCode = 4;                  // BLコード
            work3.GoodsNo = "50";					// 品番
            work3.GoodsName = "ヒンメイ４";			// 品名
            work3.WarehouseShelfNo = "02";          // 棚番
            work3.MinimumStockCnt = 1;
            work3.MaximumStockCnt = 130;
            work3.SalesMoneyTaxExc = 13000;
            work3.ShipmentCnt = 230;
            work3.ShipmentPosCnt = 330;
            work3.GrossProfit = 73000;

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
		/// <param name="stockAnalysisOrderListCndtn">UI抽出条件クラス</param>
		/// <param name="stockAnalysisOrderListCndtnWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
        private int DevStockMoveCndtn ( StockAnalysisOrderListCndtn stockAnalysisOrderListCndtn, out StockAnalysisOrderListCndtnWork stockAnalysisOrderListCndtnWork, out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;
			stockAnalysisOrderListCndtnWork = new StockAnalysisOrderListCndtnWork();
			try
			{
                stockAnalysisOrderListCndtnWork.EnterpriseCode = stockAnalysisOrderListCndtn.EnterpriseCode;  // 企業コード
				// 抽出条件パラメータセット
				if ( stockAnalysisOrderListCndtn.SectionCodes.Length != 0 )
				{
				    if ( stockAnalysisOrderListCndtn.IsSelectAllSection )
				    {
				        // 全社の時
                        stockAnalysisOrderListCndtnWork.SectionCodes = null;
				    }
				    else
				    {
                        stockAnalysisOrderListCndtnWork.SectionCodes = stockAnalysisOrderListCndtn.SectionCodes;
				    }
				}
				else
				{
                    stockAnalysisOrderListCndtnWork.SectionCodes = null;
				}

                stockAnalysisOrderListCndtnWork.St_AddUpYearMonth           = stockAnalysisOrderListCndtn.St_AddUpYearMonth;        // 開始年月度
                stockAnalysisOrderListCndtnWork.Ed_AddUpYearMonth           = stockAnalysisOrderListCndtn.Ed_AddUpYearMonth;        // 終了年月度
                stockAnalysisOrderListCndtnWork.SectionCodes                = stockAnalysisOrderListCndtn.SectionCodes;             // 拠点コード
                stockAnalysisOrderListCndtnWork.St_WarehouseCode            = stockAnalysisOrderListCndtn.St_WarehouseCode;         // 開始倉庫コード
                stockAnalysisOrderListCndtnWork.Ed_WarehouseCode            = stockAnalysisOrderListCndtn.Ed_WarehouseCode;         // 終了倉庫コード
                //--- DEL 2008/07/17 ---------->>>>>
                //stockAnalysisOrderListCndtnWork.St_CustomerCode             = stockAnalysisOrderListCndtn.St_CustomerCode;          // 開始仕入先コード
                //stockAnalysisOrderListCndtnWork.Ed_CustomerCode             = stockAnalysisOrderListCndtn.Ed_CustomerCode;          // 終了仕入先コード
                //--- DEL 2008/07/17 ----------<<<<<
                //--- ADD 2008/07/17 ---------->>>>>
                stockAnalysisOrderListCndtnWork.St_SupplierCd               = stockAnalysisOrderListCndtn.St_CustomerCode;          // 開始仕入先コード
                stockAnalysisOrderListCndtnWork.Ed_SupplierCd               = stockAnalysisOrderListCndtn.Ed_CustomerCode;          // 終了仕入先コード
                //--- ADD 2008/07/17 ----------<<<<<
                stockAnalysisOrderListCndtnWork.St_GoodsMakerCd             = stockAnalysisOrderListCndtn.St_GoodsMakerCd;          // 開始商品メーカーコード
                stockAnalysisOrderListCndtnWork.Ed_GoodsMakerCd             = stockAnalysisOrderListCndtn.Ed_GoodsMakerCd;          // 終了商品メーカーコード
                //--- DEL 2008/07/17 ---------->>>>>
                //stockAnalysisOrderListCndtnWork.St_LargeGoodsGanreCode      = stockAnalysisOrderListCndtn.St_LargeGoodsGanreCode;   // 開始商品区分グループコード
                //stockAnalysisOrderListCndtnWork.Ed_LargeGoodsGanreCode      = stockAnalysisOrderListCndtn.Ed_LargeGoodsGanreCode;   // 終了商品区分グループコード
                //stockAnalysisOrderListCndtnWork.St_MediumGoodsGanreCode     = stockAnalysisOrderListCndtn.St_MediumGoodsGanreCode;  // 開始商品区分コード
                //stockAnalysisOrderListCndtnWork.Ed_MediumGoodsGanreCode     = stockAnalysisOrderListCndtn.Ed_MediumGoodsGanreCode;  // 終了商品区分コード
                //stockAnalysisOrderListCndtnWork.St_DetailGoodsGanreCode     = stockAnalysisOrderListCndtn.St_DetailGoodsGanreCode;  // 開始商品区分詳細コード
                //stockAnalysisOrderListCndtnWork.Ed_DetailGoodsGanreCode     = stockAnalysisOrderListCndtn.Ed_DetailGoodsGanreCode;  // 終了商品区分詳細コード
                //stockAnalysisOrderListCndtnWork.St_EnterpriseGanreCode      = stockAnalysisOrderListCndtn.St_EnterpriseGanreCode;   // 開始自社分類コード
                //stockAnalysisOrderListCndtnWork.Ed_EnterpriseGanreCode      = stockAnalysisOrderListCndtn.Ed_EnterpriseGanreCode;   // 終了自社分類コード
                //--- DEL 2008/07/17 ----------<<<<<
                stockAnalysisOrderListCndtnWork.St_BLGoodsCode              = stockAnalysisOrderListCndtn.St_BLGoodsCode;           // 開始ＢＬ商品コード
                stockAnalysisOrderListCndtnWork.Ed_BLGoodsCode              = stockAnalysisOrderListCndtn.Ed_BLGoodsCode;           // 終了ＢＬ商品コード
                stockAnalysisOrderListCndtnWork.St_GoodsNo                  = stockAnalysisOrderListCndtn.St_GoodsNo;               // 開始商品番号
                stockAnalysisOrderListCndtnWork.Ed_GoodsNo                  = stockAnalysisOrderListCndtn.Ed_GoodsNo;               // 終了商品番号
                stockAnalysisOrderListCndtnWork.St_WarehouseShelfNo         = stockAnalysisOrderListCndtn.St_WarehouseShelfNo;      // 開始倉庫棚番
                stockAnalysisOrderListCndtnWork.Ed_WarehouseShelfNo         = stockAnalysisOrderListCndtn.Ed_WarehouseShelfNo;      // 終了倉庫棚番
                //stockAnalysisOrderListCndtnWork.ShipArrivalPrintDiv         = stockAnalysisOrderListCndtn.ShipArrivalPrintDiv;    // 印刷タイプ(予備項目)   // DEL 2008/07/17
                stockAnalysisOrderListCndtnWork.StockCreateDate             = stockAnalysisOrderListCndtn.StockCreateDate;          // 在庫登録日
                stockAnalysisOrderListCndtnWork.StockCreateDateDiv          = (int)stockAnalysisOrderListCndtn.StockCreateDateDiv;  // 在庫登録日指定区分
                stockAnalysisOrderListCndtnWork.St_ShipmentCnt              = stockAnalysisOrderListCndtn.St_ShipmentCnt;           // 開始出荷数
                stockAnalysisOrderListCndtnWork.Ed_ShipmentCnt              = stockAnalysisOrderListCndtn.Ed_ShipmentCnt;           // 終了出荷数

                //--- ADD 2008/07/22 ---------->>>>>
                stockAnalysisOrderListCndtnWork.PartsManagementDivide1      = stockAnalysisOrderListCndtn.PartsManagementDivide1;   // 部品管理区分１
                stockAnalysisOrderListCndtnWork.PartsManagementDivide2      = stockAnalysisOrderListCndtn.PartsManagementDivide2;   // 部品管理区分２
                //--- ADD 2008/07/22 ----------<<<<<
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
		/// <param name="stockAnalysisOrderListCndtn">UI抽出条件クラス</param>
		/// <param name="listWork">取得データ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 取得データを展開する。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.09.19</br>
        /// <br>Note       : Redmine#33977の対応</br>
        /// <br>Programmer : 王君</br>
        /// <br>Date       : 2012/12/24</br>
		/// </remarks>
		private void DevStockMoveData ( StockAnalysisOrderListCndtn stockAnalysisOrderListCndtn, ArrayList listWork )
		{
			DataRow dr;

            // 順位付け用
            List<double> SalesMoneyTaxExcList = new List<double>();
            List<double> GrossProfitList = new List<double>();
            List<double> ShipmentCntList = new List<double>();

            foreach (StockAnalysisOrderListWork stockAnalysisOrderListWork in listWork)
            {
                //--- ADD 2008/07/25 ---------->>>>>
                int status = 0;

                int goodsLGroup = 0; // ADD 2009/02/27
                int goodsMGroup = 0; // ADD 2009/02/27
                int bLGroupCode = 0; // ADD 2009/02/27

                //status = GoodsGanreCheck(stockAnalysisOrderListCndtn, stockAnalysisOrderListWork.BLGoodsCode); // DEL 2009/02/27
                status = GoodsGanreCheck(stockAnalysisOrderListCndtn, stockAnalysisOrderListWork.BLGoodsCode, out goodsLGroup, out goodsMGroup, out bLGroupCode); // ADD 2009/02/27

                if (status == 0)
                {
                //--- ADD 2008/07/25 ----------<<<<<

                    dr = this._stockAnalysisOrderListDt.NewRow();
                    // 取得データ展開
                    #region 取得データ展開
                    /* ---DEL 2009/04/06 不具合対応[13001] ------------------------------------------------------------------------>>>>>
                    dr[DCZAI02145EA.ct_Col_SectionCode] = stockAnalysisOrderListWork.SectionCode;           // 拠点コード
                    dr[DCZAI02145EA.ct_Col_SectionGuideNm] = this.GetSectionGuideNm(stockAnalysisOrderListWork.SectionCode); // 拠点ガイド名称
                       ---DEL 2009/04/06 不具合対応[13001] ------------------------------------------------------------------------<<<<< */
                    //--- DEL 2008/07/22 ---------->>>>>
                    //dr[DCZAI02145EA.ct_Col_CustomerCode] = stockAnalysisOrderListWork.CustomerCode;       // 仕入先コード
                    //dr[DCZAI02145EA.ct_Col_CustomerName] = stockAnalysisOrderListWork.CustomerName;       // 仕入先名称
                    //dr[DCZAI02145EA.ct_Col_CustomerName2] = stockAnalysisOrderListWork.CustomerName2;     // 仕入先名称2
                    //--- DEL 2008/07/22 ----------<<<<<
                    //dr[DCZAI02145EA.ct_Col_CustomerSnm] = stockAnalysisOrderListWork.CustomerSnm;         // 仕入先略称

                    // --- CHG 2009/02/26 障害ID:11973対応------------------------------------------------------>>>>>
                    ////--- ADD 2008/07/22 ---------->>>>>
                    //dr[DCZAI02145EA.ct_Col_CustomerCode] = stockAnalysisOrderListWork.SupplierCd;           // 仕入先コード
                    //dr[DCZAI02145EA.ct_Col_CustomerName] = stockAnalysisOrderListWork.SupplierSnm;          // 仕入先略称
                    ////--- ADD 2008/07/22 ----------<<<<<
                    // 商品管理情報マスタより仕入先コード、仕入先略称取得
                    if (stockAnalysisOrderListWork.SupplierCd == 0) // ADD 2009/02/27
                    {
                        int supplierCd;
                        string supplierSnm;
                        GetGoodsMngInfo(stockAnalysisOrderListWork, out supplierCd, out supplierSnm);
                        dr[DCZAI02145EA.ct_Col_CustomerCode] = supplierCd;          // 仕入先コード
                        dr[DCZAI02145EA.ct_Col_CustomerName] = supplierSnm;         // 仕入先略称
                        dr[DCZAI02145EA.ct_Col_Sort_CustomerCode] = supplierCd;     // ソート用　仕入先コード
                    }
                    else
                    {
                        dr[DCZAI02145EA.ct_Col_CustomerCode] = stockAnalysisOrderListWork.SupplierCd;           // 仕入先コード
                        dr[DCZAI02145EA.ct_Col_CustomerName] = stockAnalysisOrderListWork.SupplierSnm;          // 仕入先略称
                        dr[DCZAI02145EA.ct_Col_Sort_CustomerCode] = stockAnalysisOrderListWork.SupplierCd;      // ソート用　仕入先コード
                    }
                    // --- CHG 2009/02/26 障害ID:11973対応------------------------------------------------------<<<<<

                    //--- DEL 2008/07/22 ---------->>>>>
                    //dr[DCZAI02145EA.ct_Col_GoodsMakerCd] = stockAnalysisOrderListWork.GoodsMakerCd;       // 商品メーカーコード
                    //dr[DCZAI02145EA.ct_Col_MakerName] = stockAnalysisOrderListWork.MakerName;             // メーカー名称
                    //--- DEL 2008/07/22 ----------<<<<<
                    dr[DCZAI02145EA.ct_Col_GoodsMakerCd] = stockAnalysisOrderListWork.GoodsMakerCd;       // 商品メーカーコード         //ADD 2009/03/27 不具合対応[12783]

                    
                    dr[DCZAI02145EA.ct_Col_WarehouseCode] = stockAnalysisOrderListWork.WarehouseCode;       // 倉庫コード
                    dr[DCZAI02145EA.ct_Col_WarehouseName] = stockAnalysisOrderListWork.WarehouseName;       // 倉庫名称
                    dr[DCZAI02145EA.ct_Col_GoodsNo] = stockAnalysisOrderListWork.GoodsNo;                   // 商品番号
                    dr[DCZAI02145EA.ct_Col_GoodsName] = stockAnalysisOrderListWork.GoodsName;               // 商品名称
                    dr[DCZAI02145EA.ct_Col_SalesMoneyTaxExc] = stockAnalysisOrderListWork.SalesMoneyTaxExc; // 売上金額（税抜き）
                    dr[DCZAI02145EA.ct_Col_GrossProfit] = stockAnalysisOrderListWork.GrossProfit;           // 粗利金額
                    dr[DCZAI02145EA.ct_Col_ShipmentCnt] = stockAnalysisOrderListWork.ShipmentCnt;           // 出荷数
                    dr[DCZAI02145EA.ct_Col_WarehouseShelfNo] = stockAnalysisOrderListWork.WarehouseShelfNo; // 倉庫棚番
                    dr[DCZAI02145EA.ct_Col_ShipmentPosCnt] = stockAnalysisOrderListWork.ShipmentPosCnt;     // 出荷可能数
                    dr[DCZAI02145EA.ct_Col_MinimumStockCnt] = stockAnalysisOrderListWork.MinimumStockCnt;   // 最低在庫数
                    dr[DCZAI02145EA.ct_Col_MaximumStockCnt] = stockAnalysisOrderListWork.MaximumStockCnt;   // 最高在庫数
                    //dr[DCZAI02145EA.ct_Col_StockCreateDate] = stockAnalysisOrderListWork.StockCreateDate.ToString("yy/MM/dd"); // 在庫登録日 // DEL 2012/12/24 王君 Redmine#33977
                    dr[DCZAI02145EA.ct_Col_StockCreateDate] = TDateTime.DateTimeToString("YY/MM/DD", stockAnalysisOrderListWork.StockCreateDate);// 在庫登録日 //ADD 2012/12/24 王君 Redmine#33977
                    //--- DEL 2008/07/22 ---------->>>>>
                    //dr[DCZAI02145EA.ct_Col_LargeGoodsGanreCode] = stockAnalysisOrderListWork.LargeGoodsGanreCode;     // 商品区分グループコード
                    //dr[DCZAI02145EA.ct_Col_LargeGoodsGanreName] = stockAnalysisOrderListWork.LargeGoodsGanreName;     // 商品区分グループ名称
                    //dr[DCZAI02145EA.ct_Col_MediumGoodsGanreCode] = stockAnalysisOrderListWork.MediumGoodsGanreCode;   // 商品区分コード
                    //dr[DCZAI02145EA.ct_Col_MediumGoodsGanreName] = stockAnalysisOrderListWork.MediumGoodsGanreName;   // 商品区分名称
                    //dr[DCZAI02145EA.ct_Col_DetailGoodsGanreCode] = stockAnalysisOrderListWork.DetailGoodsGanreCode;   // 商品区分詳細コード
                    //dr[DCZAI02145EA.ct_Col_DetailGoodsGanreName] = stockAnalysisOrderListWork.DetailGoodsGanreName;   // 商品区分詳細名称
                    //--- DEL 2008/07/22 ----------<<<<<

                    // --- ADD 2009/02/27 -------------------------------->>>>>
                    dr[DCZAI02145EA.ct_Col_LargeGoodsGanreCode] = goodsLGroup;     // 商品大分類
                    dr[DCZAI02145EA.ct_Col_MediumGoodsGanreCode] = goodsMGroup;   // 商品中分類
                    dr[DCZAI02145EA.ct_Col_DetailGoodsGanreCode] = bLGroupCode;   // グループコード
                    // --- ADD 2009/02/27 --------------------------------<<<<<

                    /* ---DEL 2009/03/03 不具合対応[12050] ---------------------------------------------------------------->>>>>

                    dr[DCZAI02145EA.ct_Col_Sort_SectionCode] = stockAnalysisOrderListWork.SectionCode;      // 拠点コード
                    dr[DCZAI02145EA.ct_Col_Sort_WarehouseCode] = stockAnalysisOrderListWork.WarehouseCode;  // 倉庫コード
                    //dr[DCZAI02145EA.ct_Col_Sort_GoodsMakerCd] = stockAnalysisOrderListWork.GoodsMakerCd;  // 商品メーカーコード    // DEL 2008/07/17
                    dr[DCZAI02145EA.ct_Col_Sort_GoodsNo] = stockAnalysisOrderListWork.GoodsNo;              // 商品番号
                       ---DEL 2009/03/03 不具合対応[12050] ----------------------------------------------------------------<<<<< */
                    // ---ADD 2009/03/03 不具合対応[12050] ---------------------------------------------------------------->>>>>
                    //dr[DCZAI02145EA.ct_Col_Sort_SectionCode] = stockAnalysisOrderListWork.SectionCode.Trim();       // 拠点コード     //DEL 2009/04/06 不具合対応[13001]
                    dr[DCZAI02145EA.ct_Col_Sort_WarehouseCode] = stockAnalysisOrderListWork.WarehouseCode.Trim();   // 倉庫コード
                    dr[DCZAI02145EA.ct_Col_Sort_GoodsNo] = stockAnalysisOrderListWork.GoodsNo.Trim();               // 商品番号
                    // ---ADD 2009/03/03 不具合対応[12050] ----------------------------------------------------------------<<<<<
                    dr[DCZAI02145EA.ct_Col_Sort_GoodsMakerCd] = stockAnalysisOrderListWork.GoodsMakerCd;    // 商品メーカーコード    //ADD 2009/03/27 不具合対応[12783]

                    // 順位付け初期値セット
                    dr[DCZAI02145EA.ct_Col_Sort_SalesMoneyTaxExcOrder] = 0; // 売上金額順位
                    dr[DCZAI02145EA.ct_Col_Sort_GrossProfitOrder] = 0;      // 粗利額順位
                    dr[DCZAI02145EA.ct_Col_Sort_ShipmentCntOrder] = 0;      // 出荷数順位

                    #endregion

                    #region 順位付けの為の準備
                    SalesMoneyTaxExcList.Add(stockAnalysisOrderListWork.SalesMoneyTaxExc);  // 売上金額を登録
                    GrossProfitList.Add(stockAnalysisOrderListWork.GrossProfit);    // 粗利金額を登録
                    ShipmentCntList.Add(stockAnalysisOrderListWork.ShipmentCnt);    // 出荷数を登録
                    #endregion

                    // TableにAdd
                    this._stockAnalysisOrderListDt.Rows.Add(dr);
                    //--- ADD 2008/07/25 ---------->>>>>
                }
                //--- ADD 2008/07/25 ----------<<<<<

            }

            #region ADD 2009/06/05　仕入先で抽出後に順位付けをするように修正。また、全社計の時はグループに倉庫を含めないように修正
            // ---ADD 2009/06/05 ---------------------------------------------------------------------------->>>>>
            // 画面の仕入先で抽出
            string sort = DCZAI02145EA.ct_Col_Sort_CustomerCode + ","           //仕入先コード
                        + DCZAI02145EA.ct_Col_Sort_GoodsMakerCd + ","           //メーカーコード
                        + DCZAI02145EA.ct_Col_Sort_LargeGoodsGanreCode + ","    //商品大分類
                        + DCZAI02145EA.ct_Col_Sort_MediumGoodsGanreCode + ","   //商品中分類
                        + DCZAI02145EA.ct_Col_Sort_DetailGoodsGanreCode + ","   //グループコード
                        + DCZAI02145EA.ct_Col_Sort_GoodsNo;                     //商品番号
            DataView dv = new DataView(this._stockAnalysisOrderListDt, this.GetFilter(stockAnalysisOrderListCndtn), sort, DataViewRowState.CurrentRows);
            DataTable dt = dv.ToTable();                    //抽出後のデータ

            //各種クリア
            this._stockAnalysisOrderListDt.Rows.Clear();    //リモートから抽出したデータ
            SalesMoneyTaxExcList.Clear();                   //売上金額リスト
            GrossProfitList.Clear();                        //粗利金額リスト
            ShipmentCntList.Clear();                        //出荷数リスト

            DataRow dataRow = null;
            double salesMoneyTaxExc = 0;                    //売上金額（税抜き）
            double grossProfit = 0;                         //粗利金額
            double shipmentCnt = 0;                         //出荷数
            if (stockAnalysisOrderListCndtn.PrintTypeDiv == StockAnalysisOrderListCndtn.PrintTypeDivState.Total)
            {
                //全社計の場合
                //※仕入先、メーカー、大分類、中分類、グループ、品番単位にグループ化を行い、
                //　グループ化後のデータに対して順番を振る準備を行う

                Object[] currentItem = null;
                Object[] beforeItem = null;
                string currentKey = string.Empty;
                string beforeKey = string.Empty;

                dataRow = this._stockAnalysisOrderListDt.NewRow();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    currentItem = dt.Rows[i].ItemArray;
                    currentKey = dt.Rows[i][DCZAI02145EA.ct_Col_Sort_CustomerCode].ToString().PadLeft(6, '0')
                                + dt.Rows[i][DCZAI02145EA.ct_Col_Sort_GoodsMakerCd].ToString().PadLeft(4, '0')
                                + dt.Rows[i][DCZAI02145EA.ct_Col_Sort_LargeGoodsGanreCode].ToString().PadLeft(4, '0')
                                + dt.Rows[i][DCZAI02145EA.ct_Col_Sort_MediumGoodsGanreCode].ToString().PadLeft(4, '0')
                                + dt.Rows[i][DCZAI02145EA.ct_Col_Sort_DetailGoodsGanreCode].ToString().PadLeft(5, '0')
                                + dt.Rows[i][DCZAI02145EA.ct_Col_Sort_GoodsNo].ToString();

                    if ((string.IsNullOrEmpty(beforeKey) == false) && (currentKey != beforeKey))
                    {
                        //キーが異なる場合、前のグループデータを登録
                        dataRow.ItemArray = beforeItem;
                        dataRow[DCZAI02145EA.ct_Col_SalesMoneyTaxExc] = salesMoneyTaxExc;       //売上金額（税抜き）
                        dataRow[DCZAI02145EA.ct_Col_GrossProfit] = grossProfit;                 //粗利金額
                        dataRow[DCZAI02145EA.ct_Col_ShipmentCnt] = shipmentCnt;                 //出荷数

                        this._stockAnalysisOrderListDt.Rows.Add(dataRow);
                        dataRow = this._stockAnalysisOrderListDt.NewRow();

                        //各種金額を順位付けリストに登録
                        SalesMoneyTaxExcList.Add(salesMoneyTaxExc);
                        GrossProfitList.Add(grossProfit);
                        ShipmentCntList.Add(shipmentCnt);

                        salesMoneyTaxExc = 0;
                        grossProfit = 0;
                        shipmentCnt = 0;
                    }

                    //数値の足し込み
                    salesMoneyTaxExc += (double)dt.Rows[i][DCZAI02145EA.ct_Col_SalesMoneyTaxExc];  //売上金額（税抜き）
                    grossProfit += (double)dt.Rows[i][DCZAI02145EA.ct_Col_GrossProfit];            //粗利金額
                    shipmentCnt += (double)dt.Rows[i][DCZAI02145EA.ct_Col_ShipmentCnt];            //出荷数

                    beforeKey = currentKey;
                    beforeItem = currentItem;
                }

                // 最後のグループデータを登録
                dataRow.ItemArray = beforeItem;
                dataRow[DCZAI02145EA.ct_Col_SalesMoneyTaxExc] = salesMoneyTaxExc;       //売上金額（税抜き）
                dataRow[DCZAI02145EA.ct_Col_GrossProfit] = grossProfit;                 //粗利金額
                dataRow[DCZAI02145EA.ct_Col_ShipmentCnt] = shipmentCnt;                 //出荷数
                this._stockAnalysisOrderListDt.Rows.Add(dataRow);

                //各種金額を順位付けリストに登録
                SalesMoneyTaxExcList.Add(salesMoneyTaxExc);
                GrossProfitList.Add(grossProfit);
                ShipmentCntList.Add(shipmentCnt);

            }
            else
            {
                //倉庫別の場合
                //※仕入先で抽出後のデータに対して順位を振る為の準備を行う
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //データはそのまま登録
                    dataRow = this._stockAnalysisOrderListDt.NewRow();
                    dataRow.ItemArray = dt.Rows[i].ItemArray;
                    this._stockAnalysisOrderListDt.Rows.Add(dataRow);

                    //各種金額を順位付けリストに登録
                    salesMoneyTaxExc = (double)dt.Rows[i][DCZAI02145EA.ct_Col_SalesMoneyTaxExc];    //売上金額（税抜き）
                    SalesMoneyTaxExcList.Add(salesMoneyTaxExc);

                    grossProfit = (double)dt.Rows[i][DCZAI02145EA.ct_Col_GrossProfit];              //粗利金額
                    GrossProfitList.Add(grossProfit);

                    shipmentCnt = (double)dt.Rows[i][DCZAI02145EA.ct_Col_ShipmentCnt];              //出荷数
                    ShipmentCntList.Add(shipmentCnt);
                }
            }
            // ---ADD 2009/06/05 ----------------------------------------------------------------------------<<<<<
            #endregion

            #region 順位付け処理・金額単位処理

            // 金額単位取得
            double moneyUnit = GetMoneyUnit(stockAnalysisOrderListCndtn);

            // ソート (ソートすると、(index+1)が順位になる)
            Comparer<double> comparer = AnalysisOrderComparerCreater.GetComparer(stockAnalysisOrderListCndtn);
            SalesMoneyTaxExcList.Sort(comparer);
            GrossProfitList.Sort(comparer);
            ShipmentCntList.Sort(comparer);

            // 各レコードに順位をセット
            for (int index = 0; index < this._stockAnalysisOrderListDt.Rows.Count; index++)
            {
                dr = this._stockAnalysisOrderListDt.Rows[index];

                // 順位のセット
                dr[DCZAI02145EA.ct_Col_SalesMoneyTaxExcOrder] = SalesMoneyTaxExcList.IndexOf(( double ) dr[DCZAI02145EA.ct_Col_SalesMoneyTaxExc]) + 1; // 売上金額順位
                dr[DCZAI02145EA.ct_Col_GrossProfitOrder] = GrossProfitList.IndexOf(( double ) dr[DCZAI02145EA.ct_Col_GrossProfit]) + 1;  // 粗利額順位
                dr[DCZAI02145EA.ct_Col_ShipmentCntOrder] = ShipmentCntList.IndexOf(( double ) dr[DCZAI02145EA.ct_Col_ShipmentCnt]) + 1;  // 出荷数順位
                
                dr[DCZAI02145EA.ct_Col_Sort_SalesMoneyTaxExcOrder] = dr[DCZAI02145EA.ct_Col_SalesMoneyTaxExcOrder];
                dr[DCZAI02145EA.ct_Col_Sort_GrossProfitOrder] = dr[DCZAI02145EA.ct_Col_GrossProfitOrder];
                dr[DCZAI02145EA.ct_Col_Sort_ShipmentCntOrder] = dr[DCZAI02145EA.ct_Col_ShipmentCntOrder];

                // 金額単位処理
                dr[DCZAI02145EA.ct_Col_SalesMoneyTaxExc] = Math.Floor(( double ) dr[DCZAI02145EA.ct_Col_SalesMoneyTaxExc] / moneyUnit); // 売上金額
                dr[DCZAI02145EA.ct_Col_GrossProfit] = Math.Floor(( double ) dr[DCZAI02145EA.ct_Col_GrossProfit] / moneyUnit);   // 粗利額
            }

            #endregion

            this._stockAnalysisOrderListDt.CaseSensitive = true;            //ADD 2009/03/27 不具合対応[12783]

            // DataView作成
            this._stockAnalysisOrderListDataView = new DataView(this._stockAnalysisOrderListDt, 
                                                              GetFilter(stockAnalysisOrderListCndtn), 
                                                              GetSortOrder(stockAnalysisOrderListCndtn), 
                                                              DataViewRowState.CurrentRows);
		}

        /// <summary>
        /// 商品管理情報マスタ取得処理
        /// </summary>
        /// <param name="stockAnalysisOrderListWork"></param>
        /// <param name="supplierCd"></param>
        /// <param name="supplierSnm"></param>
        /// <returns></returns>
        private void GetGoodsMngInfo(StockAnalysisOrderListWork stockAnalysisOrderListWork, out int supplierCd, out string supplierSnm)
        {
            supplierCd = 0;
            supplierSnm = "";

            GoodsUnitData goodsUnitData = new GoodsUnitData();
            goodsUnitData.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            goodsUnitData.GoodsMakerCd = stockAnalysisOrderListWork.GoodsMakerCd;
            goodsUnitData.GoodsNo = stockAnalysisOrderListWork.GoodsNo;
            //goodsUnitData.SectionCode = stockAnalysisOrderListWork.SectionCode;           //DEL 2009/04/06 不具合対応[13001]
            goodsUnitData.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;     //ADD 2009/04/06 不具合対応[13001]
            goodsUnitData.GoodsLGroup = stockAnalysisOrderListWork.GoodsLGroup;
            goodsUnitData.GoodsMGroup = stockAnalysisOrderListWork.GoodsMGroup;
            goodsUnitData.BLGroupCode = stockAnalysisOrderListWork.BLGroupCode;
            goodsUnitData.BLGoodsCode = stockAnalysisOrderListWork.BLGoodsCode;

            stc_GoodsAcs.GetGoodsMngInfo(ref goodsUnitData);
            // -- DEL 2010/05/07 -------------------------------------->>>
            //stc_GoodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData);
            // -- DEL 2010/05/07 --------------------------------------<<<

            supplierCd = goodsUnitData.SupplierCd;
            //supplierSnm = goodsUnitData.SupplierSnm;              //DEL 2009/03/27 不具合対応[12783]
            // ---ADD 2009/03/27 不具合対応[12783] -------------->>>>>
            if (supplierCd == 0)
            {
                supplierSnm = "未登録";
            }
            else
            {
                supplierSnm = goodsUnitData.SupplierSnm;
            }
            // ---ADD 2009/03/27 不具合対応[12783] --------------<<<<<
        }

        //--- ADD 2008/07/25 ---------->>>>>
        /// <summary>
        /// 商品区分絞込処理
        /// </summary>
        /// <param name="stockAnalysisOrderListCndtn"></param>
        /// <param name="BLGoodsCode"></param>
        /// <param name="goodsLGroup"></param>
        /// <param name="goodsMGroup"></param>
        /// <param name="bLGroupCode"></param>
        /// <returns></returns>
        //private int GoodsGanreCheck(StockAnalysisOrderListCndtn stockAnalysisOrderListCndtn, int BLGoodsCode) // DEL 2009/02/27
        private int GoodsGanreCheck(StockAnalysisOrderListCndtn stockAnalysisOrderListCndtn, int BLGoodsCode,
            out int goodsLGroup, out int goodsMGroup, out int bLGroupCode) // ADD 2009/02/27
        {
            int status = 0;

            goodsLGroup = 0; // ADD 2009/02/27
            goodsMGroup = 0; // ADD 2009/02/27
            bLGroupCode = 0; // ADD 2009/02/27

            BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();

            // BLコードマスタ取得
            status = stc_GoodsAcs.GetBLGoodsCd(BLGoodsCode, out bLGoodsCdUMnt);

            // --- ADD 2009/02/27 -------------------------------->>>>>
            if (bLGoodsCdUMnt == null)
            {
                // BLコード情報が取得できなかった場合、
                // 商品大分類、商品中分類、グループコードが「最初から」の時のみ対象とする

                if (
                    (string.IsNullOrEmpty(stockAnalysisOrderListCndtn.St_LargeGoodsGanreCode))
                    &&
                    (string.IsNullOrEmpty(stockAnalysisOrderListCndtn.St_MediumGoodsGanreCode))
                    &&
                    (string.IsNullOrEmpty(stockAnalysisOrderListCndtn.St_DetailGoodsGanreCode))
                   )
                {
                    return 0;       //対象
                }
                else
                {
                    return 1;       //対象外
                }
            }

            bLGroupCode = bLGoodsCdUMnt.BLGloupCode;
            // --- ADD 2009/02/27 --------------------------------<<<<<

            if (status == 0)
            {
                // グループコードチェック
                if (stockAnalysisOrderListCndtn.St_DetailGoodsGanreCode != string.Empty && stockAnalysisOrderListCndtn.Ed_DetailGoodsGanreCode != string.Empty)
                {
                    // 開始<=終了 範囲内か？
                    //if (int.Parse(stockAnalysisOrderListCndtn.St_DetailGoodsGanreCode) >= bLGoodsCdUMnt.BLGloupCode ||
                    //   int.Parse(stockAnalysisOrderListCndtn.Ed_DetailGoodsGanreCode) <= bLGoodsCdUMnt.BLGloupCode) // DEL 2009/03/09
                    if (int.Parse(stockAnalysisOrderListCndtn.St_DetailGoodsGanreCode) > bLGoodsCdUMnt.BLGloupCode ||
                       int.Parse(stockAnalysisOrderListCndtn.Ed_DetailGoodsGanreCode) < bLGoodsCdUMnt.BLGloupCode) // ADD 2009/03/09
                    {
                        status = 1;
                        return status;
                    }
                }
                else if (stockAnalysisOrderListCndtn.St_DetailGoodsGanreCode != string.Empty && stockAnalysisOrderListCndtn.Ed_DetailGoodsGanreCode == string.Empty)
                {
                    // 開始<=最後まで 範囲内か？
                    //if (int.Parse(stockAnalysisOrderListCndtn.St_DetailGoodsGanreCode) >= bLGoodsCdUMnt.BLGloupCode) // DEL 2009/03/09
                    if (int.Parse(stockAnalysisOrderListCndtn.St_DetailGoodsGanreCode) > bLGoodsCdUMnt.BLGloupCode) // ADD 2009/03/09
                    {
                        status = 1;
                        return status;
                    }
                }
                else if (stockAnalysisOrderListCndtn.St_DetailGoodsGanreCode == string.Empty && stockAnalysisOrderListCndtn.Ed_DetailGoodsGanreCode != string.Empty)
                {
                    // 最初から<=終了 範囲内か？
                    //if (int.Parse(stockAnalysisOrderListCndtn.Ed_DetailGoodsGanreCode) <= bLGoodsCdUMnt.BLGloupCode) // DEL 2009/03/09
                    if (int.Parse(stockAnalysisOrderListCndtn.Ed_DetailGoodsGanreCode) < bLGoodsCdUMnt.BLGloupCode) // ADD 2009/03/09
                    {
                        status = 1;
                        return status;
                    }
                }

                BLGroupU bLGroupU = new BLGroupU();

                // BLグループマスタ取得
                stc_GoodsAcs.GetBLGroup(stockAnalysisOrderListCndtn.EnterpriseCode, bLGoodsCdUMnt.BLGloupCode, out bLGroupU);

                // --- ADD 2009/02/27 -------------------------------->>>>>
                if (bLGroupU == null)
                {
                    // BLグループコード情報が取得できなかった場合
                    // 商品大分類、商品中分類が「最初から」の時のみ対象とする
                    if (
                        (string.IsNullOrEmpty(stockAnalysisOrderListCndtn.St_LargeGoodsGanreCode))
                        &&
                        (string.IsNullOrEmpty(stockAnalysisOrderListCndtn.St_MediumGoodsGanreCode))
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
                if (stockAnalysisOrderListCndtn.St_MediumGoodsGanreCode != string.Empty && stockAnalysisOrderListCndtn.Ed_MediumGoodsGanreCode != string.Empty)
                {
                    // 開始<=終了 範囲内か？
                    //if (int.Parse(stockAnalysisOrderListCndtn.St_MediumGoodsGanreCode) >= bLGroupU.GoodsMGroup ||
                    //   int.Parse(stockAnalysisOrderListCndtn.Ed_MediumGoodsGanreCode) <= bLGroupU.GoodsMGroup) // DEL 2009/03/09
                    if (int.Parse(stockAnalysisOrderListCndtn.St_MediumGoodsGanreCode) > bLGroupU.GoodsMGroup ||
                       int.Parse(stockAnalysisOrderListCndtn.Ed_MediumGoodsGanreCode) < bLGroupU.GoodsMGroup) // ADD 2009/03/09
                    {
                        status = 1;
                        return status;
                    }
                }
                else if (stockAnalysisOrderListCndtn.St_MediumGoodsGanreCode != string.Empty && stockAnalysisOrderListCndtn.Ed_MediumGoodsGanreCode == string.Empty)
                {
                    // 開始<=最後まで 範囲内か？
                    //if (int.Parse(stockAnalysisOrderListCndtn.St_MediumGoodsGanreCode) >= bLGroupU.GoodsMGroup) // DEL 2009/03/09
                    if (int.Parse(stockAnalysisOrderListCndtn.St_MediumGoodsGanreCode) > bLGroupU.GoodsMGroup) // ADD 2009/03/09
                    {
                        status = 1;
                        return status;
                    }
                }
                else if (stockAnalysisOrderListCndtn.St_MediumGoodsGanreCode == string.Empty && stockAnalysisOrderListCndtn.Ed_MediumGoodsGanreCode != string.Empty)
                {
                    // 最初から<=終了 範囲内か？
                    //if (int.Parse(stockAnalysisOrderListCndtn.Ed_MediumGoodsGanreCode) <= bLGroupU.GoodsMGroup) // DEL 2009/03/09
                    if (int.Parse(stockAnalysisOrderListCndtn.Ed_MediumGoodsGanreCode) < bLGroupU.GoodsMGroup) // ADD 2009/03/09
                    {
                        status = 1;
                        return status;
                    }
                }

                // 商品大分類チェック
                if (stockAnalysisOrderListCndtn.St_LargeGoodsGanreCode != string.Empty && stockAnalysisOrderListCndtn.Ed_LargeGoodsGanreCode != string.Empty)
                {
                    // 開始<=終了 範囲内か？
                    //if (int.Parse(stockAnalysisOrderListCndtn.St_LargeGoodsGanreCode) >= bLGroupU.GoodsLGroup ||
                    //   int.Parse(stockAnalysisOrderListCndtn.Ed_LargeGoodsGanreCode) <= bLGroupU.GoodsLGroup) // DEL 2009/03/09
                    if (int.Parse(stockAnalysisOrderListCndtn.St_LargeGoodsGanreCode) > bLGroupU.GoodsLGroup ||
                       int.Parse(stockAnalysisOrderListCndtn.Ed_LargeGoodsGanreCode) < bLGroupU.GoodsLGroup) // ADD 2009/03/09
                    {
                        status = 1;
                        return status;
                    }
                }
                else if (stockAnalysisOrderListCndtn.St_LargeGoodsGanreCode != string.Empty && stockAnalysisOrderListCndtn.Ed_LargeGoodsGanreCode == string.Empty)
                {
                    // 開始<=最後まで 範囲内か？
                    //if (int.Parse(stockAnalysisOrderListCndtn.St_LargeGoodsGanreCode) >= bLGroupU.GoodsLGroup) // DEL 2009/03/09
                    if (int.Parse(stockAnalysisOrderListCndtn.St_LargeGoodsGanreCode) > bLGroupU.GoodsLGroup) // ADD 2009/03/09
                    {
                        status = 1;
                        return status;
                    }
                }
                else if (stockAnalysisOrderListCndtn.St_LargeGoodsGanreCode == string.Empty && stockAnalysisOrderListCndtn.Ed_LargeGoodsGanreCode != string.Empty)
                {
                    // 最初から<=終了 範囲内か？
                    //if (int.Parse(stockAnalysisOrderListCndtn.Ed_LargeGoodsGanreCode) <= bLGroupU.GoodsLGroup) // DEL 2009/03/09
                    if (int.Parse(stockAnalysisOrderListCndtn.Ed_LargeGoodsGanreCode) < bLGroupU.GoodsLGroup) // ADD 2009/03/09
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
        //--- ADD 2008/07/25 ----------<<<<<

        /// <summary>
        /// 拠点ガイド名称取得
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        private string GetSectionGuideNm( string sectionCode )
        {
            // --- CHG 2009/02/26 障害ID:11975対応------------------------------------------------------>>>>>
            //if (stc_SectionDic.ContainsKey(sectionCode))
            if (stc_SectionDic.ContainsKey(sectionCode.Trim()))
            // --- CHG 2009/02/26 障害ID:11975対応------------------------------------------------------<<<<<
            {
                // --- CHG 2009/02/26 障害ID:11975対応------------------------------------------------------>>>>>
                //return stc_SectionDic[sectionCode].SectionGuideNm;
                return stc_SectionDic[sectionCode.Trim()].SectionGuideSnm;
                // --- CHG 2009/02/26 障害ID:11975対応------------------------------------------------------<<<<<
            }
            else 
            {
                //return string.Empty;          //DEL 2009/03/27 不具合対応[12783]
                return "未登録";                //ADD 2009/03/27 不具合対応[12783]
            }
        }
		#endregion


		#region ◎ ソート順作成
		/// <summary>
		/// ソート順作成
		/// </summary>
		/// <returns>ソート文字列</returns>
		private string GetSortOrder( StockAnalysisOrderListCndtn stockAnalysisOrderListCndtn )
		{
			StringBuilder strSortOrder = new StringBuilder();

            //if ( !stockAnalysisOrderListCndtn.IsSelectAllSection )
            //{
            //    // 全社選択されてないとき
            //    // 主拠点
            //    strSortOrder.Append( string.Format("{0},", DCZAI02145EA.ct_Col_SectionCode ) );
            //}

            if (stockAnalysisOrderListCndtn.PrintTypeDiv == StockAnalysisOrderListCndtn.PrintTypeDivState.ByWarehouse)
            {
                // 拠点コード
                //strSortOrder.Append(string.Format("{0}" + ",", DCZAI02145EA.ct_Col_Sort_SectionCode));        //DEL 2009/04/06 不具合対応[13001]
                // 倉庫コード
                strSortOrder.Append(string.Format("{0}" + ",", DCZAI02145EA.ct_Col_Sort_WarehouseCode));

                // 画面指定内容により印刷順を制御
                switch (stockAnalysisOrderListCndtn.OrderPrintType)
                {
                    // 売上金額順
                    case StockAnalysisOrderListCndtn.OrderPrintTypeState.SalesMoneyTaxExcOrder:
                        strSortOrder.Append(string.Format("{0}" + ",", DCZAI02145EA.ct_Col_Sort_SalesMoneyTaxExcOrder));
                        break;
                    // 粗利額順
                    case StockAnalysisOrderListCndtn.OrderPrintTypeState.GrossProfitOrder:
                        strSortOrder.Append(string.Format("{0}" + ",", DCZAI02145EA.ct_Col_Sort_GrossProfitOrder));
                        break;
                    // 出荷数順
                    case StockAnalysisOrderListCndtn.OrderPrintTypeState.ShipmentCntOrder:
                        strSortOrder.Append(string.Format("{0}" + ",", DCZAI02145EA.ct_Col_Sort_ShipmentCntOrder));
                        break;
                    default:
                        break;
                }

                /* ---DEL 2009/03/27 不具合対応[12783] ---------------------------------------->>>>>
                // 商品番号
                strSortOrder.Append(string.Format("{0}" + ",", DCZAI02145EA.ct_Col_Sort_GoodsNo));
                // メーカーコード
                strSortOrder.Append(string.Format("{0}", DCZAI02145EA.ct_Col_Sort_GoodsMakerCd));
                   ---DEL 2009/03/27 不具合対応[12783] ----------------------------------------<<<<< */
                // ---ADD 2009/03/27 不具合対応[12783] ---------------------------------------->>>>>
                // 仕入先コード
                strSortOrder.Append(string.Format("{0}" + ",", DCZAI02145EA.ct_Col_Sort_CustomerCode));
                // メーカーコード
                strSortOrder.Append(string.Format("{0}" + ",", DCZAI02145EA.ct_Col_Sort_GoodsMakerCd));
                // 商品大分類
                strSortOrder.Append(string.Format("{0}" + ",", DCZAI02145EA.ct_Col_Sort_LargeGoodsGanreCode));
                // 商品中分類
                strSortOrder.Append(string.Format("{0}" + ",", DCZAI02145EA.ct_Col_Sort_MediumGoodsGanreCode));
                // グループコード
                strSortOrder.Append(string.Format("{0}" + ",", DCZAI02145EA.ct_Col_Sort_DetailGoodsGanreCode));
                // 商品番号
                strSortOrder.Append(string.Format("{0}", DCZAI02145EA.ct_Col_Sort_GoodsNo));
                // ---ADD 2009/03/27 不具合対応[12783] ----------------------------------------<<<<<
            }
            else
            {
                // 画面指定内容により印刷順を制御
                switch (stockAnalysisOrderListCndtn.OrderPrintType)
                {
                    // 売上金額順
                    case StockAnalysisOrderListCndtn.OrderPrintTypeState.SalesMoneyTaxExcOrder:
                        strSortOrder.Append(string.Format("{0}" + ",", DCZAI02145EA.ct_Col_Sort_SalesMoneyTaxExcOrder));
                        break;
                    // 粗利額順
                    case StockAnalysisOrderListCndtn.OrderPrintTypeState.GrossProfitOrder:
                        strSortOrder.Append(string.Format("{0}" + ",", DCZAI02145EA.ct_Col_Sort_GrossProfitOrder));
                        break;
                    // 出荷数順
                    case StockAnalysisOrderListCndtn.OrderPrintTypeState.ShipmentCntOrder:
                        strSortOrder.Append(string.Format("{0}" + ",", DCZAI02145EA.ct_Col_Sort_ShipmentCntOrder));
                        break;
                    default:
                        break;
                }

                /* ---DEL 2009/03/27 不具合対応[12783] ---------------------------------------->>>>>
                // 商品番号
                strSortOrder.Append(string.Format("{0}" + ",", DCZAI02145EA.ct_Col_Sort_GoodsNo));
                // メーカーコード
                strSortOrder.Append(string.Format("{0}", DCZAI02145EA.ct_Col_Sort_GoodsMakerCd));
                   ---DEL 2009/03/27 不具合対応[12783] ----------------------------------------<<<<< */
                // ---ADD 2009/03/27 不具合対応[12783] ---------------------------------------->>>>>
                // 仕入先コード
                strSortOrder.Append(string.Format("{0}" + ",", DCZAI02145EA.ct_Col_Sort_CustomerCode));
                // メーカーコード
                strSortOrder.Append(string.Format("{0}" + ",", DCZAI02145EA.ct_Col_Sort_GoodsMakerCd));
                // 商品大分類
                strSortOrder.Append(string.Format("{0}" + ",", DCZAI02145EA.ct_Col_Sort_LargeGoodsGanreCode));
                // 商品中分類
                strSortOrder.Append(string.Format("{0}" + ",", DCZAI02145EA.ct_Col_Sort_MediumGoodsGanreCode));
                // グループコード
                strSortOrder.Append(string.Format("{0}" + ",", DCZAI02145EA.ct_Col_Sort_DetailGoodsGanreCode));
                // 商品番号
                strSortOrder.Append(string.Format("{0}", DCZAI02145EA.ct_Col_Sort_GoodsNo));
                // ---ADD 2009/03/27 不具合対応[12783] ----------------------------------------<<<<<
            }

			return strSortOrder.ToString();
		}
		#endregion

        #region ◎ フィルタ作成
        /// <summary>
        /// フィルタ作成
        /// </summary>
        /// <param name="stockAnalysisOrderListCndtn">条件パラメータ</param>
        /// <returns>フィルタ文字列</returns>
        private string GetFilter( StockAnalysisOrderListCndtn stockAnalysisOrderListCndtn )
		{
            string filterText = string.Empty;

            // 何順タイプかを取得
            switch (stockAnalysisOrderListCndtn.OrderPrintType) {
                case StockAnalysisOrderListCndtn.OrderPrintTypeState.SalesMoneyTaxExcOrder :
                    filterText = DCZAI02145EA.ct_Col_SalesMoneyTaxExcOrder;
                    break;
                case StockAnalysisOrderListCndtn.OrderPrintTypeState.GrossProfitOrder :
                    filterText = DCZAI02145EA.ct_Col_GrossProfitOrder;
                    break;
                case StockAnalysisOrderListCndtn.OrderPrintTypeState.ShipmentCntOrder :
                    filterText = DCZAI02145EA.ct_Col_ShipmentCntOrder;
                    break;
                default :
                    return string.Empty;
            }

            // 第何位まで印字するか設定
            filterText += string.Format(" <= {0}",stockAnalysisOrderListCndtn.StockOrderMax);

            // --- ADD 2009/02/27 -------------------------------->>>>>
            // 仕入先を再フィルタ
            filterText += " AND ";

            if ((stockAnalysisOrderListCndtn.St_CustomerCode != 0) && (stockAnalysisOrderListCndtn.Ed_CustomerCode != 0))
            {
                filterText += String.Format("{0} <= {1} AND {2} <= {3}",
                stockAnalysisOrderListCndtn.St_CustomerCode.ToString(),
                DCZAI02145EA.ct_Col_CustomerCode,
                DCZAI02145EA.ct_Col_CustomerCode,
                stockAnalysisOrderListCndtn.Ed_CustomerCode.ToString());
            }

            if ((stockAnalysisOrderListCndtn.St_CustomerCode != 0) && (stockAnalysisOrderListCndtn.Ed_CustomerCode == 0))
            {
                filterText += String.Format("{0} <= {1}",
                stockAnalysisOrderListCndtn.St_CustomerCode.ToString(),
                DCZAI02145EA.ct_Col_CustomerCode);
            }

            if ((stockAnalysisOrderListCndtn.St_CustomerCode == 0) && (stockAnalysisOrderListCndtn.Ed_CustomerCode != 0))
            {
                filterText += String.Format("{0} <= {1}",
                DCZAI02145EA.ct_Col_CustomerCode,
                stockAnalysisOrderListCndtn.Ed_CustomerCode.ToString());
            }
            // --- ADD 2009/02/27 --------------------------------<<<<<

            return filterText;
        }
        #endregion 

        #region ◎ 金額単位取得処理
        /// <summary>
        /// 金額単位取得処理
        /// </summary>
        /// <param name="stockAnalysisOrderListCndtn"></param>
        /// <returns></returns>
        private double GetMoneyUnit( StockAnalysisOrderListCndtn stockAnalysisOrderListCndtn )
        {
            double moneyUnit;

            switch (stockAnalysisOrderListCndtn.MoneyUnit) {
                case StockAnalysisOrderListCndtn.MoneyUnitState.One : 
                    moneyUnit = 1; 
                    break;
                case StockAnalysisOrderListCndtn.MoneyUnitState.Thousand :
                    moneyUnit = 1000;
                    break;
                case StockAnalysisOrderListCndtn.MoneyUnitState.TenThousand :
                    moneyUnit = 10000;
                    break;
                default :
                    moneyUnit = 1;
                    break;
            }
            return moneyUnit;
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

    #region ■　Sort用 比較クラス関連　■
    /// <summary>
    /// 降順比較クラス（順位付けの為に使用）DEC:降順
    /// </summary>
    internal class DecreasingAnalysisOrderComparer : Comparer<double>
    {
        public override int Compare ( double x, double y )
        {
            return y.CompareTo(x);
        }
    }
    /// <summary>
    /// 昇順比較クラス（順位付けの為に使用）ASC:昇順
    /// </summary>
    internal class AscendingAnalysisOrderComparer : Comparer<double>
    {
        public override int Compare ( double x, double y )
        {
            return x.CompareTo(y);
        }
    }
    /// <summary>
    /// 比較クラス生成クラス
    /// </summary>
    internal class AnalysisOrderComparerCreater
    {
        public static Comparer<double> GetComparer( StockAnalysisOrderListCndtn cndtn )
        {
            // 上位　→　降順比較クラス
            if (cndtn.StockOrderDiv == StockAnalysisOrderListCndtn.StockOrderDivState.High) {
                return new DecreasingAnalysisOrderComparer();
            }
            // 下位　→　昇順比較クラス
            else if (cndtn.StockOrderDiv == StockAnalysisOrderListCndtn.StockOrderDivState.Low) {
                return new AscendingAnalysisOrderComparer();
            }
            else {
                return null;
            }
        }
    }
    #endregion
}

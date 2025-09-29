//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 在庫移動確認表
// プログラム概要   : 在庫移動確認表の印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/10/02  修正内容 : バグ修正、仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/11/12  修正内容 : バグ修正、仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/11/20  修正内容 : 在庫管理全体設定マスタの端数処理区分に従って端数処理を行うように修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2008/11/27  修正内容 : 出力順が対象日順または入力日順の場合、ソート条件から倉庫コードを削除
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/01/26  修正内容 : 不具合対応[10397]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/02/03  修正内容 : 不具合対応[10807]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/10  修正内容 : 不具合対応[12185][12213]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/16  修正内容 : 不具合対応[12331]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/06/11  修正内容 : 移動データ拠点管理対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 脇田 靖之
// 修 正 日  2012/11/06  修正内容 : ※発行タイプ「出庫」追加
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
    /// 在庫・倉庫移動確認表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 在庫・倉庫移動確認表で使用するデータを取得する。</br>
    /// <br>Programmer	: 22013 久保 将太</br>
    /// <br>Date		: 2007.03.15</br>
	/// <br>Updatenote	:	・2007.06.27 22013 kubo</br>
	/// <br>			:		初回印刷時、帳票フッターが印刷されない現象を修正</br>
    /// <br>Updatenote	: 2008/10/02       照田 貴志　バグ修正、仕様変更対応</br>
    /// <br>         	: 2008/11/12       照田 貴志　バグ修正、仕様変更対応</br>
    /// <br>            : 2008/11/20       照田 貴志　在庫管理全体設定マスタの端数処理区分に従って端数処理を行うように修正</br>
    /// <br>            : 2008/11/27       上野 俊治　出力順が対象日順または入力日順の場合、ソート条件から倉庫コードを削除</br>
    /// <br>            : 2009/01/26       照田 貴志　不具合対応[10397]</br>
    /// <br>            : 2009/02/03       照田 貴志　不具合対応[10807]</br>
    /// <br>            : 2009/03/10       照田 貴志　不具合対応[12185][12213]</br>
    /// <br>            : 2009/03/16       照田 貴志　不具合対応[12331]</br>
    /// <br>            : 2012/11/06       脇田 靖之　仕様変更対応</br>
    /// <br>                               ※発行タイプ「出庫」追加</br>
    /// </remarks>
	public class StockMoveAcs
	{
		#region ■ Constructor
		/// <summary>
		/// 在庫・倉庫移動確認表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫・倉庫移動確認表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 22013 久保 将太</br>
	    /// <br>Date       : 2007.03.15</br>
		/// </remarks>
		public StockMoveAcs()
		{
			this._iStockMoveListWorkDB = (IStockMoveListWorkDB)MediationStockMoveListWorkDB.GetStockMoveListWorkDB();
            this._iStockMngTtlStDB = MediationStockMngTtlStDB.GetStockMngTtlStDB();     //ADD 2008/11/20
		}

		/// <summary>
		/// 在庫・倉庫移動確認表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫・倉庫移動確認表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 22013 久保 将太</br>
	    /// <br>Date       : 2007.03.15</br>
		/// </remarks>
		static StockMoveAcs()
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
		IStockMoveListWorkDB _iStockMoveListWorkDB;
        private IStockMngTtlStDB _iStockMngTtlStDB = null;                          //ADD 2008/11/20
        private int _fractionProcCd;                            //端数処理区分      //ADD 2008/11/20

		private DataTable _stockMoveDt;			// 印刷DataTable
		private DataView _stockMoveDataView;	// 印刷DataView

		#endregion ■ Private Member

		#region ■ Public Property
		/// <summary>
		/// 印刷データセット(読み取り専用)
		/// </summary>
		public DataView StockMoveDataView
		{
			get{ return this._stockMoveDataView; }
		}
		#endregion ■ Public Property

		#region ■ Public Method
		#region ◆ 出力データ取得
		#region ◎ 入金データ取得
		/// <summary>
		/// 入金データ取得
		/// </summary>
		/// <param name="stockMoveCndtn">抽出条件</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する入金データを取得する。</br>
	    /// <br>Programmer : 22013 久保 将太</br>
	    /// <br>Date       : 2007.03.15</br>
		/// </remarks>
		public int SearchStockMoveMain( StockMoveCndtn stockMoveCndtn, out string errMsg )
		{
			return this.SearchStockMoveProc( stockMoveCndtn, out errMsg );
		}
		#endregion
		#endregion ◆ 出力データ取得
        #region ◆ 出力データ更新   ADD 2009/03/16 不具合対応[12331]
        /// <summary>
        /// 在庫移動データ更新
        /// </summary>
        /// <param name="dataView">印刷データ</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 印刷した在庫移動データの出力済フラグを更新する。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/03/16</br>
        /// </remarks>
        public int UpdateStockMoveMain(DataView dataView, out string errMsg)
        {
            return this.UpdateStockMoveMainProc(dataView,out errMsg);
        }
        #endregion ◆ 出力データ更新
        #endregion ■ Public Method

        #region ■ Private Method
        #region ◆ 帳票データ取得
        #region ◎ 在庫移動データ取得
        /// <summary>
		/// 在庫移動データ取得
		/// </summary>
		/// <param name="stockMoveCndtn"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する在庫移動データを取得する。</br>
	    /// <br>Programmer : 22013 久保 将太</br>
	    /// <br>Date       : 2007.03.15</br>
		/// </remarks>
		private int SearchStockMoveProc( StockMoveCndtn stockMoveCndtn, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

			try
			{
				// DataTable Create ----------------------------------------------------------
				MAZAI02034EA.CreateDataTable( ref this._stockMoveDt );
				
				StockMoveListCndtnWork stockMoveListCndtnWork = new StockMoveListCndtnWork();
                stockMoveCndtn.Ed_CustomerCode = 999999;
				// 抽出条件展開  --------------------------------------------------------------
				status = this.DevStockMoveCndtn( stockMoveCndtn, out stockMoveListCndtnWork, out errMsg );
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

				// データ取得  ----------------------------------------------------------------
				object retStockMoveList = null;
                //--- DEL 2008/08/12 ---------->>>>>
                //// 帳票によって呼び先が異なる
                //if ( stockMoveCndtn.StockMoveFormalDiv == StockMoveCndtn.StockMoveFormalDivState.StockMove )
                //{
                //    status = this._iStockMoveListWorkDB.SearchStock( 
                //        out retStockMoveList, stockMoveListCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);
                //}
                //else
                //{
                //    status = this._iStockMoveListWorkDB.SearchEnterWareh( 
                //        out retStockMoveList, stockMoveListCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);
                //}
                //--- DEL 2008/08/12 ----------<<<<<
                //--- ADD 2008/08/12 ---------->>>>>
                status = this._iStockMoveListWorkDB.SearchStock(
                    out retStockMoveList, stockMoveListCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);
                //--- ADD 2008/08/12 ----------<<<<<
                //--- TEST --------->>>>>
                //retStockMoveList = this.GetTestData();
                //status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //--- TEST ---------<<<<<

				switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        //--- DEL 2008.08.12 ---------->>>>>
                        // データ展開処理
                        //DevStockMoveData(stockMoveCndtn, (ArrayList)retStockMoveList);
                        //--- DEL 2008.08.12 ---------->>>>>
                        //--- ADD 2008.08.12 ---------->>>>>

                        // 端数処理区分取得
                        this._fractionProcCd = this.GetFractionProcCd();        //ADD 2008/11/20

                        if (stockMoveCndtn.PrintDiv == 13)      // 13：在庫移動確認表（集計）
                        {
                            // データ展開処理
                            DevStockMoveDataTotal(stockMoveCndtn, (ArrayList)retStockMoveList);
                        }
                        else
                        {
                            // データ展開処理
                            DevStockMoveData(stockMoveCndtn, (ArrayList)retStockMoveList); 
                        }
                        //--- ADD 2008.08.12 ----------<<<<<
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
						break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
					default:
						errMsg = "在庫移動データの取得に失敗しました。";
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

            StockMoveListResultWork work = new StockMoveListResultWork();

            work.ShipmentScdlDay    = TDateTime.LongDateToDateTime(20080801);   // 出荷予定日
            work.ShipmentFixDay     = TDateTime.LongDateToDateTime(20080802);   // 出荷確定日
            work.ArrivalGoodsDay    = TDateTime.LongDateToDateTime(20080803);	// 入荷日
            work.BfSectionCode      = "01";		        // 移動元拠点コード
            work.BfSectionGuideSnm  = "AAAAA";		    // 移動元拠点ガイド略称
            work.BfEnterWarehCode   = "11";		        // 移動元倉庫コード
            work.BfEnterWarehName   = "BBBBB";		    // 移動元倉庫名称
            work.AfSectionCode      = "22";		        // 移動先拠点コード
            work.AfSectionGuideSnm  = "CCCCC";		    // 移動先拠点ガイド略称
            work.AfEnterWarehCode   = "33";		        // 移動先倉庫コード
            work.AfEnterWarehName   = "DDDDD";		    // 移動先倉庫名称
            work.BfShelfNo          = "44";		        // 移動元棚番
            work.AfShelfNo          = "99";		        // 移動先棚番
            work.StockMoveSlipNo    = 55;		        // 在庫移動伝票番号
            work.GoodsMakerCd       = 66;		        // メーカーコード
            work.MakerName          = "EEEEE";		    // メーカー名称
            work.GoodsNo            = "77";			    // 品番
            work.GoodsName          = "FFFFF";          // 品名
            work.BLGoodsCode        = 88;               // ＢＬ商品コード
            work.BLGoodsFullName    = "GGGGG";          // ＢＬ商品名称
            work.StockUnitPriceFl   = 11111;            // 仕入単価 (浮動)
            work.MoveCount          = 2;                // 移動数
            work.ListPriceFl        = 10000;            // 定価 (浮動)
            work.InputDay           = TDateTime.LongDateToDateTime(20080804);   // 入力日付
            list.Add(work);

            StockMoveListResultWork work1 = new StockMoveListResultWork();

            work1.ShipmentScdlDay    = TDateTime.LongDateToDateTime(20080804);  // 出荷予定日
            work1.ShipmentFixDay     = TDateTime.LongDateToDateTime(20080805);	// 出荷確定日
            work1.ArrivalGoodsDay    = TDateTime.LongDateToDateTime(20080806);	// 入荷日
            work1.BfSectionCode     = "01";		    // 移動元拠点コード
            work1.BfSectionGuideSnm = "AAAAA";		// 移動元拠点ガイド略称
            work1.BfEnterWarehCode  = "12";		    // 移動元倉庫コード
            work1.BfEnterWarehName  = "HHHHH";		// 移動元倉庫名称
            work1.AfSectionCode     = "22";		    // 移動先拠点コード
            work1.AfSectionGuideSnm = "CCCCC";		// 移動先拠点ガイド略称
            work1.AfEnterWarehCode  = "33";		    // 移動先倉庫コード
            work1.AfEnterWarehName  = "DDDDD";		// 移動先倉庫名称
            work1.BfShelfNo         = "44";		    // 移動元棚番
            work1.AfShelfNo         = "99";		    // 移動先棚番
            work1.StockMoveSlipNo   = 55;		    // 在庫移動伝票番号
            work1.GoodsMakerCd      = 66;		    // メーカーコード
            work1.MakerName         = "EEEEE";		// メーカー名称
            work1.GoodsNo           = "77";			// 品番
            work1.GoodsName         = "FFFFF";      // 品名
            work1.BLGoodsCode       = 88;           // ＢＬ商品コード
            work1.BLGoodsFullName   = "GGGGG";      // ＢＬ商品名称
            work1.StockUnitPriceFl  = 11111;        // 仕入単価 (浮動)
            work1.MoveCount         = 2;            // 移動数
            work1.ListPriceFl       = 10000;        // 定価 (浮動)
            work1.InputDay          = TDateTime.LongDateToDateTime(20080807);   // 入力日付
            work1.WarehouseNote1    = "備考１１１１１１１１１１１";
            list.Add(work1);

            StockMoveListResultWork work2 = new StockMoveListResultWork();

            work2.ShipmentScdlDay    = TDateTime.LongDateToDateTime(20080807);  // 出荷予定日
            work2.ShipmentFixDay     = TDateTime.LongDateToDateTime(20080808);	// 出荷確定日
            work2.ArrivalGoodsDay    = TDateTime.LongDateToDateTime(20080809);	// 入荷日
            work2.BfSectionCode     = "01";		    // 移動元拠点コード
            work2.BfSectionGuideSnm = "AAAAA";		// 移動元拠点ガイド略称
            work2.BfEnterWarehCode  = "12";		    // 移動元倉庫コード
            work2.BfEnterWarehName  = "HHHHH";		// 移動元倉庫名称
            work2.AfSectionCode     = "22";		    // 移動先拠点コード
            work2.AfSectionGuideSnm = "CCCCC";		// 移動先拠点ガイド略称
            work2.AfEnterWarehCode  = "33";		    // 移動先倉庫コード
            work2.AfEnterWarehName  = "DDDDD";		// 移動先倉庫名称
            work2.BfShelfNo         = "44";		    // 移動元棚番
            work2.AfShelfNo         = "99";		    // 移動先棚番
            work2.StockMoveSlipNo   = 56;		    // 在庫移動伝票番号
            work2.GoodsMakerCd      = 66;		    // メーカーコード
            work2.MakerName         = "EEEEE";		// メーカー名称
            work2.GoodsNo           = "77";			// 品番
            work2.GoodsName         = "FFFFF";      // 品名
            work2.BLGoodsCode       = 88;           // ＢＬ商品コード
            work2.BLGoodsFullName   = "GGGGG";      // ＢＬ商品名称
            work2.StockUnitPriceFl  = 11111;        // 仕入単価 (浮動)
            work2.MoveCount         = 2;            // 移動数
            work2.ListPriceFl       = 10000;        // 定価 (浮動)
            work2.InputDay          = TDateTime.LongDateToDateTime(20080810);   // 入力日付

            list.Add(work2);


            StockMoveListResultWork work3 = new StockMoveListResultWork();

            work3.ShipmentScdlDay   = TDateTime.LongDateToDateTime(20080810);   // 出荷予定日
            work3.ShipmentFixDay    = TDateTime.LongDateToDateTime(20080811);	// 出荷確定日
            work3.ArrivalGoodsDay   = TDateTime.LongDateToDateTime(20080812);	// 入荷日
            work3.BfSectionCode = "02";		    // 移動元拠点コード
            work3.BfSectionGuideSnm = "AAAAA";		// 移動元拠点ガイド略称
            work3.BfEnterWarehCode  = "11";		    // 移動元倉庫コード
            work3.BfEnterWarehName  = "BBBBB";		// 移動元倉庫名称
            work3.AfSectionCode     = "22";		    // 移動先拠点コード
            work3.AfSectionGuideSnm = "CCCCC";		// 移動先拠点ガイド略称
            work3.AfEnterWarehCode  = "33";		    // 移動先倉庫コード
            work3.AfEnterWarehName  = "DDDDD";		// 移動先倉庫名称
            work3.BfShelfNo         = "44";		    // 移動元棚番
            work3.AfShelfNo         = "99";		    // 移動先棚番
            work3.StockMoveSlipNo   = 55;		    // 在庫移動伝票番号
            work3.GoodsMakerCd      = 66;		    // メーカーコード
            work3.MakerName         = "EEEEE";		// メーカー名称
            work3.GoodsNo           = "77";			// 品番
            work3.GoodsName         = "FFFFF";      // 品名
            work3.BLGoodsCode       = 88;           // ＢＬ商品コード
            work3.BLGoodsFullName   = "GGGGG";      // ＢＬ商品名称
            work3.StockUnitPriceFl  = 11111;        // 仕入単価 (浮動)
            work3.MoveCount         = 2;            // 移動数
            work3.InputDay          = TDateTime.LongDateToDateTime(20080813);   // 入力日付

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
		/// <param name="stockMoveCndtn">UI抽出条件クラス</param>
		/// <param name="stockMoveListCndtnWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
		private int DevStockMoveCndtn ( StockMoveCndtn stockMoveCndtn, out StockMoveListCndtnWork stockMoveListCndtnWork, out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;
			stockMoveListCndtnWork = new StockMoveListCndtnWork();
			try
			{
                stockMoveListCndtnWork.EnterpriseCode = stockMoveCndtn.EnterpriseCode;  // 企業コード
				// 抽出条件パラメータセット
				if ( stockMoveCndtn.BfAfSectionCd.Length != 0 )
				{
				    if ( stockMoveCndtn.IsSelectAllSection )
				    {
				        // 全社の時
				        stockMoveListCndtnWork.BfAfSectionCd = null;
				    }
				    else
				    {
				        stockMoveListCndtnWork.BfAfSectionCd = stockMoveCndtn.BfAfSectionCd;
				    }
				}
				else
				{
				    stockMoveListCndtnWork.BfAfSectionCd = null;
				}

                //stockMoveListCndtnWork.StockMoveFormalDiv			= (int)stockMoveCndtn.StockMoveFormalDiv;	// 印刷区分     // DEL 2008.08.12
				stockMoveListCndtnWork.St_MainBfAfEnterWarehCd		= stockMoveCndtn.St_MainBfAfEnterWarehCd;	// 主開始入出荷倉庫コード　     →出庫倉庫From
				stockMoveListCndtnWork.Ed_MainBfAfEnterWarehCd		= stockMoveCndtn.Ed_MainBfAfEnterWarehCd;	// 主終了入出荷倉庫コード　     →出庫倉庫To
                //stockMoveListCndtnWork.ShipmentArrivalDiv			= (int)stockMoveCndtn.ShipmentArrivalDiv;	// 処理区分     // DEL 2008.08.12
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //stockMoveListCndtnWork.SummaryPrintDiv			= (int)stockMoveCndtn.GrossPrintDiv;	    // 集計単位
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                stockMoveListCndtnWork.StockMoveFormalDiv = (int)stockMoveCndtn.StockMoveFormalDiv;	            // 在庫移動形式
				stockMoveListCndtnWork.St_ShipArrivalDate			= stockMoveCndtn.St_ShipArrivalDate;		// 開始入出荷日付　　　　　     →出荷日From
				stockMoveListCndtnWork.Ed_ShipArrivalDate			= stockMoveCndtn.Ed_ShipArrivalDate;		// 終了入出荷日付　　　　　     →出荷日To
                //stockMoveListCndtnWork.St_ShipArrivalSectionCd      = stockMoveCndtn.St_ShipArrivalSectionCd;	// 開始入出荷拠点コード         //DEL 2008/10/02
                //stockMoveListCndtnWork.Ed_ShipArrivalSectionCd      = stockMoveCndtn.Ed_ShipArrivalSectionCd;	// 終了入出荷拠点コード         //DEL 2008/10/02
                stockMoveListCndtnWork.St_ShipArrivalEnterWarehCd   = stockMoveCndtn.St_ShipArrivalEnterWarehCd;// 開始入出荷倉庫コード         →入庫倉庫From
                stockMoveListCndtnWork.Ed_ShipArrivalEnterWarehCd   = stockMoveCndtn.Ed_ShipArrivalEnterWarehCd;// 終了入出荷倉庫コード         →入庫倉庫To
                //--- DEL 2008/08/12 ---------->>>>>
                //stockMoveListCndtnWork.St_StockMoveSlipNo			= stockMoveCndtn.St_StockMoveSlipNo;		// 開始在庫移動伝票番号
                //stockMoveListCndtnWork.Ed_StockMoveSlipNo			= stockMoveCndtn.Ed_StockMoveSlipNo;		// 終了在庫移動伝票番号
                //stockMoveListCndtnWork.St_GoodsMakerCd            = stockMoveCndtn.St_GoodsMakerCd;  			// 開始メーカーコード
                //stockMoveListCndtnWork.Ed_GoodsMakerCd            = stockMoveCndtn.Ed_GoodsMakerCd;  			// 終了メーカーコード
                //stockMoveListCndtnWork.St_GoodsNo                 = stockMoveCndtn.St_GoodsNo;  				// 開始商品コード
                //stockMoveListCndtnWork.Ed_GoodsNo                 = stockMoveCndtn.Ed_GoodsNo;  				// 終了商品コード
                //stockMoveListCndtnWork.St_UpdateSecCd             = stockMoveCndtn.St_UpdateSecCd;			// 開始更新拠点コード
                //stockMoveListCndtnWork.Ed_UpdateSecCd				= stockMoveCndtn.Ed_UpdateSecCd;			// 終了更新拠点コード
                //--- DEL 2008/08/12 ----------<<<<<
                stockMoveListCndtnWork.St_StockMvEmpCode            = stockMoveCndtn.St_StockMvEmpCode;			// 開始在庫移動入力従業員コード →担当者From
                stockMoveListCndtnWork.Ed_StockMvEmpCode            = stockMoveCndtn.Ed_StockMvEmpCode;			// 終了在庫移動入力従業員コード →担当者To
                //--- DEL 2008/08/12 ---------->>>>>
                //stockMoveListCndtnWork.St_ShipAgentCd             = stockMoveCndtn.St_ShipAgentCd;			// 開始出荷担当従業員コード
                //stockMoveListCndtnWork.Ed_ShipAgentCd				= stockMoveCndtn.Ed_ShipAgentCd;			// 終了出荷担当従業員コード
                //stockMoveListCndtnWork.St_ReceiveAgentCd			= stockMoveCndtn.St_ReceiveAgentCd;  		// 開始引取担当従業員コード
                //stockMoveListCndtnWork.Ed_ReceiveAgentCd			= stockMoveCndtn.Ed_ReceiveAgentCd;  		// 終了引取担当従業員コード
                //--- DEL 2008/08/12 ----------<<<<<
                //stockMoveListCndtnWork.StockDiv                     = stockMoveCndtn.StockDiv;					// 在庫区分         //DEL 2008/10/02 不要
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //stockMoveListCndtnWork.St_CarrierEpCd				= stockMoveCndtn.St_CarrierEpCd;			// 開始事業者コード
                //stockMoveListCndtnWork.Ed_CarrierEpCd				= stockMoveCndtn.Ed_CarrierEpCd;			// 終了事業者コード
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                //--- DEL 2008/08/12 ---------->>>>>
                //stockMoveListCndtnWork.St_CustomerCode = stockMoveCndtn.St_CustomerCode;			            // 開始仕入先コード
                //stockMoveListCndtnWork.Ed_CustomerCode            = stockMoveCndtn.Ed_CustomerCode;			// 終了仕入先コード
                //--- DEL 2008/08/12 ----------<<<<<
                //--- ADD 2008/08/12 ---------->>>>>
                stockMoveListCndtnWork.St_SupplierCd                = stockMoveCndtn.St_CustomerCode;			// 開始仕入先コード
                stockMoveListCndtnWork.Ed_SupplierCd                = stockMoveCndtn.Ed_CustomerCode;			// 終了仕入先コード
                //--- ADD 2008/08/12 ----------<<<<<

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                stockMoveListCndtnWork.St_CreateDate                = stockMoveCndtn.St_CreateDate;             // 開始入力日付（予備項目）
                stockMoveListCndtnWork.Ed_CreateDate                = stockMoveCndtn.Ed_CreateDate;             // 終了入力日付（予備項目）
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                //--- ADD 2008/08/12 ---------->>>>>
                stockMoveListCndtnWork.PrintType                    = (int)stockMoveCndtn.PrintType;            // 発行タイプ
                stockMoveListCndtnWork.OutputDesignat               = (int)stockMoveCndtn.OutputDesignat;       // 出力指定
                //--- ADD 2008/08/12 ----------<<<<<

                // ADD 2009/06/11 ------>>>
                stockMoveListCndtnWork.StockMoveFixCode = stockMoveCndtn.StockMoveFixCode;                      // 在庫移動確定区分
                // ADD 2009/06/11 ------<<<
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
		/// <param name="stockMoveCndtn">UI抽出条件クラス</param>
		/// <param name="stockMoveWork">取得データ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 取得データを展開する。</br>
	    /// <br>Programmer : 22013 久保 将太</br>
	    /// <br>Date       : 2007.03.15</br>
		/// </remarks>
		private void DevStockMoveData ( StockMoveCndtn stockMoveCndtn, ArrayList stockMoveWork )
		{
			DataRow dr;

			foreach ( StockMoveListResultWork stockMoveListResultWork in stockMoveWork )
			{
				dr = this._stockMoveDt.NewRow();
				// 取得データ展開
				#region 取得データ展開
				dr[MAZAI02034EA.ct_Col_ShipmentScdlDay		] = TDateTime.DateTimeToString( StockMoveCndtn.ct_DateFomat, stockMoveListResultWork.ShipmentScdlDay );     // 出荷予定日
				dr[MAZAI02034EA.ct_Col_Sort_ShipmentScdlDay	] = TDateTime.DateTimeToLongDate( stockMoveListResultWork.ShipmentScdlDay );    // 出荷予定日(ソート)
				dr[MAZAI02034EA.ct_Col_ShipmentFixDay		] = TDateTime.DateTimeToString( StockMoveCndtn.ct_DateFomat, stockMoveListResultWork.ShipmentFixDay );      // 出荷確定日
				dr[MAZAI02034EA.ct_Col_Sort_ShipmentFixDay	] = TDateTime.DateTimeToLongDate( stockMoveListResultWork.ShipmentFixDay );     // 出荷確定日(ソート)
				dr[MAZAI02034EA.ct_Col_ArrivalGoodsDay		] = TDateTime.DateTimeToString( StockMoveCndtn.ct_DateFomat,  stockMoveListResultWork.ArrivalGoodsDay );    // 入荷日
				dr[MAZAI02034EA.ct_Col_Sort_ArrivalGoodsDay	] = TDateTime.DateTimeToLongDate( stockMoveListResultWork.ArrivalGoodsDay );    // 入荷日(ソート)
				//dr[MAZAI02034EA.ct_Col_BfSectionCode		] = stockMoveListResultWork.BfSectionCode;          // 移動元拠点コード             //DEL 2009/03/10 不具合対応[12185]
                dr[MAZAI02034EA.ct_Col_BfSectionCode] = stockMoveListResultWork.BfSectionCode.Trim().PadLeft(2,'0');    // 移動元拠点コード     //ADD 2009/03/10 不具合対応[12185]
                //dr[MAZAI02034EA.ct_Col_BfSectionGuideNm	] = stockMoveListResultWork.BfSectionGuideNm;       // 移動元拠点ガイド名称   // DEL 2008.08.08
				//dr[MAZAI02034EA.ct_Col_BfEnterWarehCode		] = stockMoveListResultWork.BfEnterWarehCode;       // 移動元倉庫コード         //DEL 2009/03/10 不具合対応[12185]
                dr[MAZAI02034EA.ct_Col_BfEnterWarehCode] = stockMoveListResultWork.BfEnterWarehCode.Trim().PadLeft(4,'0');  // 移動元倉庫コード //ADD 2009/03/10 不具合対応[12185]
                dr[MAZAI02034EA.ct_Col_BfEnterWarehName] = stockMoveListResultWork.BfEnterWarehName;       // 移動元倉庫名称
				//dr[MAZAI02034EA.ct_Col_AfSectionCode		] = stockMoveListResultWork.AfSectionCode;          // 移動先拠点コード             //DEL 2009/03/10 不具合対応[12185]
                dr[MAZAI02034EA.ct_Col_AfSectionCode] = stockMoveListResultWork.AfSectionCode.Trim().PadLeft(2, '0');   // 移動先拠点コード     //ADD 2009/03/10 不具合対応[12185]
                //dr[MAZAI02034EA.ct_Col_AfSectionGuideNm	] = stockMoveListResultWork.AfSectionGuideNm;       // 移動先拠点ガイド名称   // DEL 2008.08.08
				//dr[MAZAI02034EA.ct_Col_AfEnterWarehCode		] = stockMoveListResultWork.AfEnterWarehCode;       // 移動先倉庫コード         //DEL 2009/03/10 不具合対応[12185]
                dr[MAZAI02034EA.ct_Col_AfEnterWarehCode] = stockMoveListResultWork.AfEnterWarehCode.Trim().PadLeft(4, '0'); // 移動先倉庫コード //ADD 2009/03/10 不具合対応[12185]
                dr[MAZAI02034EA.ct_Col_AfEnterWarehName] = stockMoveListResultWork.AfEnterWarehName;       // 移動先倉庫名称
				dr[MAZAI02034EA.ct_Col_StockMoveSlipNo		] = stockMoveListResultWork.StockMoveSlipNo;        // 在庫移動伝票番号
                dr[MAZAI02034EA.ct_Col_StockMoveRowNo		] = stockMoveListResultWork.StockMoveRowNo;         // 在庫移動行番号         // DEL 2008.08.08　→　2008/10/02復活
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //dr[MAZAI02034EA.ct_Col_StockMoveExpNum	] = stockMoveListResultWork.StockMoveExpNum;        // 在庫移動行詳細番号
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                //--- DEL 2008/08/12 ---------->>>>>
                //dr[MAZAI02034EA.ct_Col_CustomerCode		] = stockMoveListResultWork.CustomerCode;           // 仕入先コード
                //dr[MAZAI02034EA.ct_Col_CustomerName		] = stockMoveListResultWork.CustomerName;           // 得意先名称
                //dr[MAZAI02034EA.ct_Col_CustomerName2		] = stockMoveListResultWork.CustomerName2;          // 得意先名称2
                //--- DEL 2008/08/12 ----------<<<<<
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //dr[MAZAI02034EA.ct_Col_CustomerSnm        ] = stockMoveListResultWork.CustomerSnm;            // 得意先略称             // DEL 2008.08.08
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                dr[MAZAI02034EA.ct_Col_GoodsMakerCd         ] = stockMoveListResultWork.GoodsMakerCd;           // メーカーコード
				dr[MAZAI02034EA.ct_Col_MakerName			] = stockMoveListResultWork.MakerName;              // メーカー名称
				dr[MAZAI02034EA.ct_Col_GoodsNo  			] = stockMoveListResultWork.GoodsNo;                // 商品コード
				dr[MAZAI02034EA.ct_Col_GoodsName			] = stockMoveListResultWork.GoodsName;              // 商品名称
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //dr[MAZAI02034EA.ct_Col_ProDuctNumber		] = stockMoveListResultWork.ProDuctNumber;          // 製造番号
                //dr[MAZAI02034EA.ct_Col_StockTelNo1		] = stockMoveListResultWork.StockTelNo1;            // 商品電話番号1
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //dr[MAZAI02034EA.ct_Col_MovingSupliStock   ] = stockMoveListResultWork.MovingSupliStock;       // 移動中仕入在庫数
                //dr[MAZAI02034EA.ct_Col_MovingTrustStock	] = stockMoveListResultWork.MovingTrustStock;       // 移動中受託在庫数
                //dr[MAZAI02034EA.ct_Col_MovingTotalStock	] = stockMoveListResultWork.MovingTotalStock;       // 移動在庫数
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                //--- DEL 2008/08/12 ---------->>>>>
                //dr[MAZAI02034EA.ct_Col_StockMvEmpCode     ] = stockMoveListResultWork.StockMvEmpCode;         // 在庫移動従業員コード
                //dr[MAZAI02034EA.ct_Col_StockMvEmpName		] = stockMoveListResultWork.StockMvEmpName;         // 在庫移動従業員名称
                //dr[MAZAI02034EA.ct_Col_ShipAgentCd		] = stockMoveListResultWork.ShipAgentCd;            // 出荷担当従業員コード
                //dr[MAZAI02034EA.ct_Col_ShipAgentNm		] = stockMoveListResultWork.ShipAgentNm;            // 出荷担当従業員名称
                //dr[MAZAI02034EA.ct_Col_ReceiveAgentCd		] = stockMoveListResultWork.ReceiveAgentCd;         // 引取担当従業員コード
                //dr[MAZAI02034EA.ct_Col_ReceiveAgentNm		] = stockMoveListResultWork.ReceiveAgentNm;         // 引取担当従業員名称
                //dr[MAZAI02034EA.ct_Col_StockDiv			] = stockMoveListResultWork.StockDiv;               // 在庫区分
                //if ( stockMoveListResultWork.StockDiv == 0 )										            // 在庫区分名称
                //    dr[MAZAI02034EA.ct_Col_StockDivName			] = "自社"; 
                //else
                //    dr[MAZAI02034EA.ct_Col_StockDivName			] = "受託";
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                ////dr[MAZAI02034EA.ct_Col_StockTelNo2		] = stockMoveListResultWork.StockTelNo2;            // 商品電話番号2
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                //dr[MAZAI02034EA.ct_Col_MoveStatus			] = stockMoveListResultWork.MoveStatus;             // 移動状態
                //switch ( stockMoveListResultWork.MoveStatus )
                //{
                //    case 0:	dr[MAZAI02034EA.ct_Col_MoveStatusName		] = "移動対象外";	break;
                //    case 1:	dr[MAZAI02034EA.ct_Col_MoveStatusName		] = "未出荷状態";	break;
                //    case 2:	dr[MAZAI02034EA.ct_Col_MoveStatusName		] = "移動中";		break;
                //    case 3:	dr[MAZAI02034EA.ct_Col_MoveStatusName		] = "入荷済み";		break;
                //}
                //--- DEL 2008/08/12 ----------<<<<<
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                //dr[MAZAI02034EA.ct_Col_StockUnitPrice		] = stockMoveListResultWork.StockUnitPrice;         // 仕入単価
                //dr[MAZAI02034EA.ct_Col_StockPrice			] = stockMoveListResultWork.StockPrice;             // 仕入金額

                dr[MAZAI02034EA.ct_Col_StockUnitPriceFl     ] = stockMoveListResultWork.StockUnitPriceFl;       // 仕入単価 (浮動)
//                dr[MAZAI02034EA.ct_Col_StockPrice           ] = stockMoveListResultWork.StockUnitPriceFl * stockMoveListResultWork.MoveCount;   // 移動金額           //DEL 2008/11/20 端数処理を端数処理区分に委ねる為
                //dr[MAZAI02034EA.ct_Col_StockPrice] = this.FractionProc(stockMoveListResultWork.StockUnitPriceFl * stockMoveListResultWork.MoveCount);   // 移動金額     //ADD 2008/11/20→DEL 2009/01/26 不具合対応[10397]
                dr[MAZAI02034EA.ct_Col_StockPrice] = stockMoveListResultWork.StockMovePrice;                    //ADD 2009/01/26 不具合対応[10397]
                dr[MAZAI02034EA.ct_Col_MoveCount] = stockMoveListResultWork.MoveCount;              // 移動数
                dr[MAZAI02034EA.ct_Col_ListPriceFl          ] = stockMoveListResultWork.ListPriceFl;            // 定価 (浮動)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                dr[MAZAI02034EA.ct_Col_BLGoodsCode          ] = stockMoveListResultWork.BLGoodsCode;            // ＢＬ商品コード
                //dr[MAZAI02034EA.ct_Col_BLGoodsCdDerivedNo ] = stockMoveListResultWork.BLGoodsCdDerivedNo;     // ＢＬ商品コード枝番
                dr[MAZAI02034EA.ct_Col_BLGoodsFullName      ] = stockMoveListResultWork.BLGoodsFullName;        // ＢＬ商品名称
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                //--- ADD 2008.08.12 ---------->>>>>
                dr[MAZAI02034EA.ct_Col_BfSectionGuideSnm    ] = stockMoveListResultWork.BfSectionGuideSnm;      // 移動元拠点ガイド略称
                dr[MAZAI02034EA.ct_Col_AfSectionGuideSnm    ] = stockMoveListResultWork.AfSectionGuideSnm;      // 移動先拠点ガイド略称
                dr[MAZAI02034EA.ct_Col_BfShelfNo            ] = stockMoveListResultWork.BfShelfNo;              // 移動元棚番
                dr[MAZAI02034EA.ct_Col_AfShelfNo            ] = stockMoveListResultWork.AfShelfNo;              // 移動先棚番

                dr[MAZAI02034EA.ct_Col_InputDay             ] = TDateTime.DateTimeToString(StockMoveCndtn.ct_DateFomat, stockMoveListResultWork.InputDay);   // 入力日付
                //dr[MAZAI02034EA.ct_Col_SlipNote1            ] = stockMoveListResultWork.WarehouseNote1;         // 備考       //DEL 2008/11/12 備考は「伝票適用」から取得の為
                dr[MAZAI02034EA.ct_Col_SlipNote1] = stockMoveListResultWork.Outline;                            // 備考         //ADD 2008/11/12
                //--- ADD 2008.08.12 ---------->>>>>

                // ---ADD 2009/03/16 不具合対応[12331] ------------------------------------------------------------------->>>>>
                dr[MAZAI02034EA.ct_Col_SlipPrintFinishCd] = stockMoveListResultWork.SlipPrintFinishCd;          // 帳票発行済区分
                dr[MAZAI02034EA.ct_Col_StockMoveFormal] = stockMoveListResultWork.StockMoveFormal;              // 在庫移動形式
                // ---ADD 2009/03/16 不具合対応[12331] -------------------------------------------------------------------<<<<<

				DivSectionWhareHouse( ref dr, stockMoveCndtn, stockMoveListResultWork );	// 主･絞込み拠点･倉庫データ展開
                //DivSlipNote( ref dr, stockMoveCndtn, stockMoveListResultWork );			    // 備考展開     // DEL 2008.08.12

                // ADD 2009/06/11 ------>>>
                if (stockMoveCndtn.StockMoveFixCode == 2)
                {
                    if ((stockMoveListResultWork.StockMoveFormal == 1) ||
                        (stockMoveListResultWork.StockMoveFormal == 2))
                    {
                        dr[MAZAI02034EA.ct_Col_SlipDivName] = "出庫";
                    }
                    else if ((stockMoveListResultWork.StockMoveFormal == 3) ||
                             (stockMoveListResultWork.StockMoveFormal == 4))
                    {
                        dr[MAZAI02034EA.ct_Col_SlipDivName] = "入庫";
                    }
                }
                // ADD 2009/06/11 ------<<<
				#endregion

                // TableにAdd
				this._stockMoveDt.Rows.Add( dr );
			}

			// DataView作成
			this._stockMoveDataView = new DataView( this._stockMoveDt, "", GetSortOrder(stockMoveCndtn), DataViewRowState.CurrentRows );
		}
		#endregion

        
        //--- ADD 2008.08.12 ---------->>>>>
        #region ◎ 取得データ展開処理　DEL 2009/03/10 不具合対応[12213]
        /// <summary>
        /// 取得データ展開処理
        /// </summary>
        /// <param name="stockMoveCndtn">UI抽出条件クラス</param>
        /// <param name="stockMoveWork">取得データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 取得データを展開する。</br>
        /// <br>Programmer : 22013 久保 将太</br>
        /// <br>Date       : 2007.03.15</br>
        /// </remarks>
        private void DevStockMoveDataTotal(StockMoveCndtn stockMoveCndtn, ArrayList stockMoveWork)
        {
            DataRow dr = null;

            string BfSectionCode = "";
            string BfEnterWarehCode = "";
            string AfSectionCode = "";
            string AfEnterWarehCode = "";
            int StockMoveSlipNo = 0;
            int StockMoveSlipCnt = 0;
            //double StockPrice = 0;        //DEL 2009/01/26 不具合対応[10397]

            // ---ADD 2009/03/10 不具合対応[12213] ---------------------------------------------------------------------->>>>>
            // SortedListを使用して「元拠点、元倉庫、先拠点、先倉庫、伝票番号、行番号」順にソートをかける
            string key = string.Empty;
            SortedList<string, StockMoveListResultWork> stockMoveWorkSList = new SortedList<string, StockMoveListResultWork>();
            foreach (StockMoveListResultWork stockMoveListResultWork in stockMoveWork)
            {
                // 発行タイプ
                // DEL 2009/06/11 ------>>>
                //if (stockMoveCndtn.PrintType == StockMoveCndtn.PrintTypeDivState.PrintTypeBf)           // 未出荷
                // DEL 2009/06/11 ------<<<
                // --- UPD 2012/11/06 Y.Wakita ---------->>>>>
                //// ADD 2009/06/11 ------>>>
                //if ((stockMoveCndtn.PrintType == 0) ||      // 未入荷(出庫) or 全て
                //    (stockMoveCndtn.PrintType == -1))
                //// ADD 2009/06/11 ------<<<
                if ((stockMoveCndtn.PrintType == 0) ||      // 未入荷(出庫) or 全て
                    (stockMoveCndtn.PrintType == -1) ||
                    (stockMoveCndtn.PrintType == 2))
                // --- UPD 2012/11/06 Y.Wakita ----------<<<<<
                {
                    key = stockMoveListResultWork.BfSectionCode.Trim().PadLeft(2, '0') +
                        stockMoveListResultWork.BfEnterWarehCode.Trim().PadLeft(4, '0') +
                        stockMoveListResultWork.AfSectionCode.Trim().PadLeft(2, '0') +
                        stockMoveListResultWork.AfEnterWarehCode.Trim().PadLeft(4, '0') +
                        stockMoveListResultWork.StockMoveSlipNo.ToString("000000000") +
                        stockMoveListResultWork.StockMoveRowNo.ToString("000000");
                }
                // DEL 2009/06/11 ------>>>
                //else if (stockMoveCndtn.PrintType == StockMoveCndtn.PrintTypeDivState.PrintTypeAf)      // 出荷済
                // DEL 2009/06/11 ------<<<
                // ADD 2009/06/11 ------>>>
                else if (stockMoveCndtn.PrintType == 1)     // 入荷済(入庫)
                // ADD 2009/06/11 ------<<<
                {
                    key = stockMoveListResultWork.AfSectionCode.Trim().PadLeft(2, '0') +
                        stockMoveListResultWork.AfEnterWarehCode.Trim().PadLeft(4, '0') +
                        stockMoveListResultWork.BfSectionCode.Trim().PadLeft(2, '0') +
                        stockMoveListResultWork.BfEnterWarehCode.Trim().PadLeft(4, '0') +
                        stockMoveListResultWork.StockMoveSlipNo.ToString("000000000") +
                        stockMoveListResultWork.StockMoveRowNo.ToString("000000");
                }
                stockMoveWorkSList.Add(key, stockMoveListResultWork);
            }
            // ---ADD 2009/03/10 不具合対応[12213] ----------------------------------------------------------------------<<<<<

            //foreach (StockMoveListResultWork stockMoveListResultWork in stockMoveWork)                    //DEL 2009/03/10 不具合対応[12213]
            foreach (StockMoveListResultWork stockMoveListResultWork in stockMoveWorkSList.Values)          //ADD 2009/03/10 不具合対応[12213]
            {
                /* ---DEL 2009/03/10 不具合対応[12213] ---------------------------------------------------------------------->>>>>
                if (BfSectionCode != stockMoveListResultWork.BfSectionCode || BfEnterWarehCode != stockMoveListResultWork.BfEnterWarehCode ||
                    AfSectionCode != stockMoveListResultWork.AfSectionCode || AfEnterWarehCode != stockMoveListResultWork.AfEnterWarehCode)
                   ---DEL 2009/03/10 不具合対応[12213] ----------------------------------------------------------------------<<<<< */
                // ---ADD 2009/03/10 不具合対応[12213] ---------------------------------------------------------------------->>>>>
                if (BfSectionCode.Trim().PadLeft(2,'0') != stockMoveListResultWork.BfSectionCode.Trim().PadLeft(2,'0') ||
                    BfEnterWarehCode.Trim().PadLeft(4,'0') != stockMoveListResultWork.BfEnterWarehCode.Trim().PadLeft(4,'0') ||
                    AfSectionCode.Trim().PadLeft(2, '0') != stockMoveListResultWork.AfSectionCode.Trim().PadLeft(2, '0') ||
                    AfEnterWarehCode.Trim().PadLeft(4, '0') != stockMoveListResultWork.AfEnterWarehCode.Trim().PadLeft(4, '0'))
                // ---ADD 2009/03/10 不具合対応[12213] ----------------------------------------------------------------------<<<<<
                {
                    if (BfSectionCode != "")
                    {
                        // TableにAdd
                        this._stockMoveDt.Rows.Add(dr);
                    }

                    dr = this._stockMoveDt.NewRow();
                    /* ---DEL 2009/03/10 不具合対応[12213] ---------------------------------------------------------------------->>>>>
                    BfSectionCode = stockMoveListResultWork.BfSectionCode;
                    BfEnterWarehCode = stockMoveListResultWork.BfEnterWarehCode;
                    AfSectionCode = stockMoveListResultWork.AfSectionCode;
                    AfEnterWarehCode = stockMoveListResultWork.AfEnterWarehCode;
                       ---DEL 2009/03/10 不具合対応[12213] ----------------------------------------------------------------------<<<<< */
                    // ---ADD 2009/03/10 不具合対応[12213] ---------------------------------------------------------------------->>>>>
                    BfSectionCode = stockMoveListResultWork.BfSectionCode.Trim().PadLeft(2,'0');
                    BfEnterWarehCode = stockMoveListResultWork.BfEnterWarehCode.Trim().PadLeft(4, '0');
                    AfSectionCode = stockMoveListResultWork.AfSectionCode.Trim().PadLeft(2, '0');
                    AfEnterWarehCode = stockMoveListResultWork.AfEnterWarehCode.Trim().PadLeft(4, '0');
                    // ---ADD 2009/03/10 不具合対応[12213] ----------------------------------------------------------------------<<<<<

                    StockMoveSlipCnt = 0;
                }
                // 取得データ展開
                #region 取得データ展開
                /* ---DEL 2009/03/10 不具合対応[12213] ---------------------------------------------------------------------->>>>>
                dr[MAZAI02034EA.ct_Col_BfSectionCode] = stockMoveListResultWork.BfSectionCode;                  // 移動元拠点コード
                dr[MAZAI02034EA.ct_Col_BfEnterWarehCode] = stockMoveListResultWork.BfEnterWarehCode;            // 移動元倉庫コード
                dr[MAZAI02034EA.ct_Col_BfEnterWarehName] = stockMoveListResultWork.BfEnterWarehName;            // 移動元倉庫名称
                dr[MAZAI02034EA.ct_Col_AfSectionCode] = stockMoveListResultWork.AfSectionCode;                  // 移動先拠点コード
                dr[MAZAI02034EA.ct_Col_AfEnterWarehCode] = stockMoveListResultWork.AfEnterWarehCode;            // 移動先倉庫コード
                   ---DEL 2009/03/10 不具合対応[12213] ----------------------------------------------------------------------<<<<< */
                // ---ADD 2009/03/10 不具合対応[12213] ---------------------------------------------------------------------->>>>>
                dr[MAZAI02034EA.ct_Col_BfSectionCode] = stockMoveListResultWork.BfSectionCode.Trim();           // 移動元拠点コード
                dr[MAZAI02034EA.ct_Col_BfEnterWarehCode] = stockMoveListResultWork.BfEnterWarehCode.Trim();     // 移動元倉庫コード
                dr[MAZAI02034EA.ct_Col_BfEnterWarehName] = stockMoveListResultWork.BfEnterWarehName;            // 移動元倉庫名称
                dr[MAZAI02034EA.ct_Col_AfSectionCode] = stockMoveListResultWork.AfSectionCode.Trim();           // 移動先拠点コード
                dr[MAZAI02034EA.ct_Col_AfEnterWarehCode] = stockMoveListResultWork.AfEnterWarehCode.Trim();     // 移動先倉庫コード
                // ---ADD 2009/03/10 不具合対応[12213] ----------------------------------------------------------------------<<<<<
                dr[MAZAI02034EA.ct_Col_AfEnterWarehName] = stockMoveListResultWork.AfEnterWarehName;            // 移動先倉庫名称
                dr[MAZAI02034EA.ct_Col_StockMoveSlipNo] = stockMoveListResultWork.StockMoveSlipNo;              // 在庫移動伝票番号

                dr[MAZAI02034EA.ct_Col_StockUnitPriceFl] = stockMoveListResultWork.StockUnitPriceFl;            // 仕入単価 (浮動)

                //StockPrice = stockMoveListResultWork.StockUnitPriceFl * stockMoveListResultWork.MoveCount;                        //DEL 2008/11/20 端数処理を端数処理区分に委ねる
                //StockPrice = this.FractionProc(stockMoveListResultWork.StockUnitPriceFl * stockMoveListResultWork.MoveCount);             //ADD 2008/11/20 →DEL 2009/01/26 不具合対応[10397]
                //dr[MAZAI02034EA.ct_Col_StockPrice] = (double)dr[MAZAI02034EA.ct_Col_StockPrice] + StockPrice;           // 移動金額       //DEL 2009/01/26 不具合対応[10397]
                dr[MAZAI02034EA.ct_Col_StockPrice] = (double)dr[MAZAI02034EA.ct_Col_StockPrice] + stockMoveListResultWork.StockMovePrice;   //ADD 2009/01/26 不具合対応[10397]

                dr[MAZAI02034EA.ct_Col_MoveCount] = (double)dr[MAZAI02034EA.ct_Col_MoveCount] + stockMoveListResultWork.MoveCount;                          // 移動数
                dr[MAZAI02034EA.ct_Col_ListPriceFl] = stockMoveListResultWork.ListPriceFl;                      // 定価 (浮動)

                dr[MAZAI02034EA.ct_Col_BfSectionGuideSnm] = stockMoveListResultWork.BfSectionGuideSnm;          // 移動元拠点ガイド略称
                dr[MAZAI02034EA.ct_Col_AfSectionGuideSnm] = stockMoveListResultWork.AfSectionGuideSnm;          // 移動先拠点ガイド略称
                dr[MAZAI02034EA.ct_Col_BfShelfNo] = stockMoveListResultWork.BfShelfNo;                          // 移動元棚番
                dr[MAZAI02034EA.ct_Col_AfShelfNo] = stockMoveListResultWork.AfShelfNo;                          // 移動先棚番

                if (StockMoveSlipNo != stockMoveListResultWork.StockMoveSlipNo)
                {
                    StockMoveSlipCnt++;
                    StockMoveSlipNo = stockMoveListResultWork.StockMoveSlipNo;
                }
                dr[MAZAI02034EA.ct_Col_StockMoveSlipCnt] = StockMoveSlipCnt;                                    // 移動枚数

                dr[MAZAI02034EA.ct_Col_InputDay] = TDateTime.DateTimeToString(StockMoveCndtn.ct_DateFomat, stockMoveListResultWork.InputDay);   // 入力日付
                dr[MAZAI02034EA.ct_Col_SlipNote1] = stockMoveListResultWork.WarehouseNote1;                     // 備考

                DivSectionWhareHouse(ref dr, stockMoveCndtn, stockMoveListResultWork);	        // 主･絞込み拠点･倉庫データ展開
                #endregion

            }
            // TableにAdd
            this._stockMoveDt.Rows.Add(dr);

            // DataView作成
            this._stockMoveDataView = new DataView(this._stockMoveDt, "", GetSortOrder(stockMoveCndtn), DataViewRowState.CurrentRows);
        }
        #endregion
        //--- ADD 2008.08.12 ----------<<<<<

		#region ◎ 主･絞込みデータ展開(倉庫移動)
		/// <summary>
		/// 主･絞込みデータ展開(倉庫移動)
		/// </summary>
		/// <param name="dr">展開対象DataRow</param>
		/// <param name="stockMoveCndtn">抽出条件</param>
		/// <param name="stockMoveListResultWork">取得データ</param>
		private void DivSectionWhareHouse( ref DataRow dr, StockMoveCndtn stockMoveCndtn, StockMoveListResultWork stockMoveListResultWork )
		{
			string mainSectionCode = "";        // 主拠点コード
			string mainSectionName = "";        // 主拠点名称
			string mainWhareHouseCode = "";     // 主倉庫コード
			string mainWhareHouseName = "";     // 主倉庫名称
			string extractSectionCode = "";     // 絞込拠点コード
			string extractSectionName = "";     // 絞込拠点名称
			string extractWhareHouseCode = "";  // 絞込倉庫コード
			string extractWhareHouseName = "";  // 絞込倉庫名称
			DateTime extractDate = TDateTime.GetSFDateNow(); // 絞込み日付

            //--- DEL 2008.08.12 ---------->>>>>
            //// 拠点･倉庫
            //switch ( stockMoveCndtn.ShipmentArrivalDiv )
            //{
            //    case StockMoveCndtn.ShipmentArrivalDivState.UnShipment:
            //    case StockMoveCndtn.ShipmentArrivalDivState.Shipment:
            //        {
            //            // main:移動元、extract:移動先
            //            mainSectionCode			= stockMoveListResultWork.BfSectionCode;		// 主拠点コード
            //            //mainSectionName			= stockMoveListResultWork.BfSectionGuideNm;	// 主拠点拠点名     // DEL 2008.08.08
            //            mainWhareHouseCode		= stockMoveListResultWork.BfEnterWarehCode;	// 主倉庫コード
            //            mainWhareHouseName		= stockMoveListResultWork.BfEnterWarehName;	// 主倉庫名称
            //            extractSectionCode		= stockMoveListResultWork.AfSectionCode;		// 絞込拠点コード
            //            //extractSectionName		= stockMoveListResultWork.AfSectionGuideNm;	// 絞込拠点名称     // DEL 2008.08.08
            //            extractWhareHouseCode	= stockMoveListResultWork.AfEnterWarehCode;	// 絞込倉庫コード
            //            extractWhareHouseName	= stockMoveListResultWork.AfEnterWarehName;	// 絞込倉庫名称
            //            break;
            //        }
            //    case StockMoveCndtn.ShipmentArrivalDivState.UnArrival:
            //    case StockMoveCndtn.ShipmentArrivalDivState.Arrival:
            //        {
            //            // main:移動先、extract:移動元
            //            mainSectionCode			= stockMoveListResultWork.AfSectionCode;	// 絞込拠点コード
            //            //mainSectionName			= stockMoveListResultWork.AfSectionGuideNm;	// 絞込拠点拠点名   // DEL 2008.08.08
            //            mainWhareHouseCode		= stockMoveListResultWork.AfEnterWarehCode;	// 主倉庫コード
            //            mainWhareHouseName		= stockMoveListResultWork.AfEnterWarehName;	// 主倉庫名称
            //            extractSectionCode		= stockMoveListResultWork.BfSectionCode;		// 絞込拠点コード
            //            //extractSectionName		= stockMoveListResultWork.BfSectionGuideNm;	// 絞込拠点名称     // DEL 2008.08.08
            //            extractWhareHouseCode	= stockMoveListResultWork.BfEnterWarehCode;	// 絞込倉庫コード
            //            extractWhareHouseName	= stockMoveListResultWork.BfEnterWarehName;	// 絞込倉庫名称
            //            break;
            //        }
            //}

            //// 日付展開
            //switch ( stockMoveCndtn.ShipmentArrivalDiv )
            //{
            //    case StockMoveCndtn.ShipmentArrivalDivState.UnShipment:
            //        {
            //            extractDate	= stockMoveListResultWork.ShipmentScdlDay;				// 出荷予定日
            //            break;
            //        }
            //    case StockMoveCndtn.ShipmentArrivalDivState.Shipment:
            //    case StockMoveCndtn.ShipmentArrivalDivState.UnArrival:
            //        {
            //            extractDate	= stockMoveListResultWork.ShipmentFixDay;				// 出荷日
            //            break;
            //        }
            //    case StockMoveCndtn.ShipmentArrivalDivState.Arrival:
            //        {
            //            extractDate	= stockMoveListResultWork.ArrivalGoodsDay;				// 入荷日
            //            break;
            //        }
            //}
            //--- DEL 2008.08.12 ----------<<<<<

			dr[MAZAI02034EA.ct_Col_MainSectionCode]			= mainSectionCode;			// 主拠点コード
			dr[MAZAI02034EA.ct_Col_MainSectionName]			= mainSectionName;			// 主拠点名称
			dr[MAZAI02034EA.ct_Col_MainWhareHouseCode]		= mainWhareHouseCode;		// 主倉庫コード
			dr[MAZAI02034EA.ct_Col_MainWhareHouseName]		= mainWhareHouseName;		// 主倉庫名称
			dr[MAZAI02034EA.ct_Col_ExtractSectionCode]		= extractSectionCode;		// 絞込拠点コード
			dr[MAZAI02034EA.ct_Col_ExtractSectionName]		= extractSectionName;		// 絞込拠点名称
			dr[MAZAI02034EA.ct_Col_ExtractWhareHouseCode]	= extractWhareHouseCode;	// 絞込倉庫コード
			dr[MAZAI02034EA.ct_Col_ExtractWhareHouseName]	= extractWhareHouseName;	// 絞込倉庫名称
			// 絞込み日付
			dr[MAZAI02034EA.ct_Col_ExtractDate]				= TDateTime.DateTimeToString( StockMoveCndtn.ct_DateFomat, extractDate );
			// ソート用絞込み日付
			dr[MAZAI02034EA.ct_Col_Sort_ExtractDate]		= TDateTime.DateTimeToLongDate( extractDate );
		}
		#endregion

		#region ◎ 備考展開
		/// <summary>
		/// 備考展開
		/// </summary>
		/// <param name="dr">展開対象DataRow</param>
		/// <param name="stockMoveCndtn">抽出条件</param>
		/// <param name="stockMoveListResultWork">取得データ</param>
		private void DivSlipNote( ref DataRow dr, StockMoveCndtn stockMoveCndtn, StockMoveListResultWork stockMoveListResultWork )
		{
			ArrayList slipNoteList = new ArrayList();

			// 取得結果の伝票適用と備考をリストに展開
			// 伝票適用
			if ( ( stockMoveListResultWork.Outline.CompareTo( string.Empty ) != 0 ) && (stockMoveListResultWork.Outline != null) )
			    slipNoteList.Add( stockMoveListResultWork.Outline );
			// 倉庫備考1
			if ( ( stockMoveListResultWork.WarehouseNote1.CompareTo( string.Empty ) != 0 ) && (stockMoveListResultWork.WarehouseNote1 != null) )
			    slipNoteList.Add( stockMoveListResultWork.WarehouseNote1 );
			// 倉庫備考2
			if ( ( stockMoveListResultWork.WarehouseNote2.CompareTo( string.Empty ) != 0 ) && (stockMoveListResultWork.WarehouseNote2 != null) )
			    slipNoteList.Add( stockMoveListResultWork.WarehouseNote2 );
            //--- DEL 2008/08/08 ---------->>>>>
            //// 倉庫備考3
            //if ( ( stockMoveListResultWork.WarehouseNote3.CompareTo( string.Empty ) != 0 ) && (stockMoveListResultWork.WarehouseNote3 != null) )
            //    slipNoteList.Add( stockMoveListResultWork.WarehouseNote3 );
            //// 倉庫備考4
            //if ( ( stockMoveListResultWork.WarehouseNote4.CompareTo( string.Empty ) != 0 ) && (stockMoveListResultWork.WarehouseNote4 != null) )
            //    slipNoteList.Add( stockMoveListResultWork.WarehouseNote4 );
            //// 倉庫備考5
            //if ( ( stockMoveListResultWork.WarehouseNote5.CompareTo( string.Empty ) != 0 ) && (stockMoveListResultWork.WarehouseNote5 != null) )
            //    slipNoteList.Add( stockMoveListResultWork.WarehouseNote5 );
            //--- DEL 2008/08/08 ----------<<<<<

			int slipNoteCounter = 0;	// 展開用カウンタ
			foreach ( string slipNote in slipNoteList )
			{
			    switch ( slipNoteCounter )
			    {
			        case 0:
			            dr[MAZAI02034EA.ct_Col_SlipNote1] = slipNote;
			            break;
			        case 1:
			            dr[MAZAI02034EA.ct_Col_SlipNote2] = slipNote;
			            break;
			        case 2:
			            dr[MAZAI02034EA.ct_Col_SlipNote3] = slipNote;
			            break;
			        case 3:
			            dr[MAZAI02034EA.ct_Col_SlipNote4] = slipNote;
			            break;
			        case 4:
			            dr[MAZAI02034EA.ct_Col_SlipNote5] = slipNote;
			            break;
			        case 5:
			            dr[MAZAI02034EA.ct_Col_SlipNote6] = slipNote;
			            break;
			        default:
			            break;
			    }

			    slipNoteCounter++;		// カウンタをインクリメント
			}
		}
		#endregion

		#region ◎ ソート順作成
		/// <summary>
		/// ソート順作成
		/// </summary>
		/// <returns>ソート文字列</returns>
		private string GetSortOrder( StockMoveCndtn stockMoveCndtn )
		{
			StringBuilder strSortOrder = new StringBuilder();
            /* --- DEL 2008/10/02 出力順追加の為------------------------------------------------------>>>>>
			// 2007.06.01 kubo change ------------------------>
			if ( !stockMoveCndtn.IsSelectAllSection )
			{
				// 全社選択されてないとき
				// 主拠点
				strSortOrder.Append( string.Format("{0},", MAZAI02034EA.ct_Col_MainSectionCode ) );
			}
			// 2007.06.01 kubo change <------------------------

			// 主倉庫
			strSortOrder.Append( string.Format("{0},", MAZAI02034EA.ct_Col_MainWhareHouseCode ) );
			// 絞り込み日付
			strSortOrder.Append( string.Format("{0},", MAZAI02034EA.ct_Col_ExtractDate ) );
			// 絞り込み拠点
			strSortOrder.Append( string.Format("{0},", MAZAI02034EA.ct_Col_ExtractSectionCode ) );
			// 絞り込み倉庫
			strSortOrder.Append( string.Format("{0},", MAZAI02034EA.ct_Col_ExtractWhareHouseCode ) );
			// 移動伝票番号
			strSortOrder.Append( string.Format("{0},", MAZAI02034EA.ct_Col_StockMoveSlipNo ) );
			#region // 2007.06.01 kubo del
			//// 移動行番号
			//strSortOrder.Append( string.Format("{0},", MAZAI02034EA.ct_Col_StockMoveRowNo ) );
			//// 移動行詳細番号
			//strSortOrder.Append( string.Format("{0}", MAZAI02034EA.ct_Col_StockMoveExpNum ) );
			#endregion
			// 仕入先コード
			strSortOrder.Append( string.Format("{0},", MAZAI02034EA.ct_Col_CustomerCode ) );	// 2007.06.01 kubo add
			// メーカーコード
			strSortOrder.Append( string.Format("{0},", MAZAI02034EA.ct_Col_GoodsMakerCd ) );
			// 商品コード
			strSortOrder.Append( string.Format("{0}", MAZAI02034EA.ct_Col_GoodsNo ) );
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// 製造番号
            //strSortOrder.Append( string.Format("{0}", MAZAI02034EA.ct_Col_ProDuctNumber ) );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
               --- DEL 2008/10/02 --------------------------------------------------------------------<<<<< */
            // --- ADD 2008/10/02 -------------------------------------------------------------------->>>>>
            String mainSectionCode = string.Empty;          // 主拠点
            String mainWharehouseCode = string.Empty;       // 主倉庫
            String extractSectionCode = string.Empty;       // 絞込拠点
            String extractWharehouseCode = string.Empty;    // 絞込倉庫
            String date = string.Empty;                     // 日付

            // 発行タイプ
            // DEL 2009/06/11 ------>>>
            //if ((stockMoveCndtn.PrintType == StockMoveCndtn.PrintTypeDivState.PrintTypeBf) ||
            //    (stockMoveCndtn.PrintType == StockMoveCndtn.PrintTypeDivState.PrintTypeAll))            // 出庫 or 全て
            // DEL 2009/06/11 ------<<<
            // --- UPD 2012/11/06 Y.Wakita ---------->>>>>
            //// ADD 2009/06/11 ------>>>
            //if ((stockMoveCndtn.PrintType == 0) ||
            //    (stockMoveCndtn.PrintType == -1))       // 未入荷(出庫) or 全て
            //// ADD 2009/06/11 ------<<<
            if ((stockMoveCndtn.PrintType == 0) ||
                (stockMoveCndtn.PrintType == -1) ||
                (stockMoveCndtn.PrintType == 2))       // 未入荷(出庫) or 全て
            // --- UPD 2012/11/06 Y.Wakita ----------<<<<<
            {
                mainSectionCode = MAZAI02034EA.ct_Col_BfSectionCode;            // 出庫拠点
                mainWharehouseCode = MAZAI02034EA.ct_Col_BfEnterWarehCode;      // 出庫倉庫
                extractSectionCode = MAZAI02034EA.ct_Col_AfSectionCode;         // 入庫拠点
                extractWharehouseCode = MAZAI02034EA.ct_Col_AfEnterWarehCode;   // 入庫倉庫
                date = MAZAI02034EA.ct_Col_Sort_ShipmentFixDay;                 // 出荷確定日
            }
            // DEL 2009/06/11 ------>>>
            //else if (stockMoveCndtn.PrintType == StockMoveCndtn.PrintTypeDivState.PrintTypeAf)          // 入庫
            // DEL 2009/06/11 ------<<<
            // ADD 2009/06/11 ------>>>
            else if (stockMoveCndtn.PrintType == 1)     // 入荷済(入庫)
            // ADD 2009/06/11 ------<<<
            {
                mainSectionCode = MAZAI02034EA.ct_Col_AfSectionCode;            // 入庫拠点
                mainWharehouseCode = MAZAI02034EA.ct_Col_AfEnterWarehCode;      // 入庫倉庫
                extractSectionCode = MAZAI02034EA.ct_Col_BfSectionCode;         // 出庫拠点
                extractWharehouseCode = MAZAI02034EA.ct_Col_BfEnterWarehCode;   // 出庫倉庫
                date = MAZAI02034EA.ct_Col_Sort_ArrivalGoodsDay;                // 入荷日
            }

            // ソート順作成            
            strSortOrder.Append(string.Format("{0},", mainSectionCode));                        // 拠点
            strSortOrder.Append(string.Format("{0},", mainWharehouseCode));                     // 倉庫     //ADD 2009/02/03　不具合対応[10807]

            // ---ADD 2009/03/10 不具合対応[12213] ------------------------------------------------->>>>>
            if (stockMoveCndtn.PrintDiv == 13)      // 13：在庫移動確認表（集計）
            {
                strSortOrder.Append(string.Format("{0},", extractSectionCode));                 // 拠点
                strSortOrder.Append(string.Format("{0}", extractWharehouseCode));               // 倉庫

                return strSortOrder.ToString();
            }
            // ---ADD 2009/03/10 不具合対応[12213] -------------------------------------------------<<<<<

            if (stockMoveCndtn.OutputOrder == StockMoveCndtn.OutputOrderDivState.ShipArrivalDate)       // 出力順：対象日順
            {
                //strSortOrder.Append(string.Format("{0},", mainWharehouseCode));                 // 倉庫 // DEL 2008/11/27
                strSortOrder.Append(string.Format("{0},", date));                               // 出荷確定日(印刷タイプ：出庫 or 全て)、入荷日(印刷タイプ：入庫)
            }
            else if (stockMoveCndtn.OutputOrder == StockMoveCndtn.OutputOrderDivState.CreateDate)       // 出力順：入力日順
            {
                //strSortOrder.Append(string.Format("{0},", mainWharehouseCode));                 // 倉庫 // DEL 2008/11/27
                strSortOrder.Append(string.Format("{0},", MAZAI02034EA.ct_Col_InputDay));       // 入力日
            }
            else if (stockMoveCndtn.OutputOrder == StockMoveCndtn.OutputOrderDivState.Warehouse)        // 出力順：相手倉庫順
            {
                //strSortOrder.Append(string.Format("{0},", mainWharehouseCode));                 // 倉庫1  //DEL 2009/02/03　不具合対応[10807]
                strSortOrder.Append(string.Format("{0},", extractWharehouseCode));              // 倉庫2
                strSortOrder.Append(string.Format("{0},", date));                               // 出荷確定日(印刷タイプ：出庫 or 全て)、入荷日(印刷タイプ：入庫)   //ADD 2009/02/03　不具合対応[10807]
            }
            strSortOrder.Append(string.Format("{0},", MAZAI02034EA.ct_Col_StockMoveSlipNo));    // 伝票番号
            strSortOrder.Append(string.Format("{0}", MAZAI02034EA.ct_Col_StockMoveRowNo));      // 行番号
            // --- ADD 2008/10/02 --------------------------------------------------------------------<<<<<

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
		/// <br>Programmer : 22013 kubo</br>
		/// <br>Date       : 2007.03.15</br>
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

        // --- ADD 2008/11/20 ------------------------------------------------------->>>>>
        /// <summary>
        /// 端数処理区分取得
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 在庫管理全体設定マスタ(全社)より端数処理区分の取得を行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        private int GetFractionProcCd()
        {
            int fractionProcCd = -1;

            ArrayList retList = new ArrayList();
            retList.Clear();

            StockMngTtlStWork stockMngTtlStWork = new StockMngTtlStWork();
            stockMngTtlStWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;		// 企業コード
            stockMngTtlStWork.SectionCode = "00";                                       // 拠点コード：全社

            ArrayList wkList = new ArrayList();
            wkList.Clear();

            object paraobj = stockMngTtlStWork;
            object retobj = null;

            // 在庫管理全体設定全件検索
            int status = this._iStockMngTtlStDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData0);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return fractionProcCd;
            }
            wkList = retobj as ArrayList;
            if (wkList == null)
            {
                return fractionProcCd;
            }

            foreach (StockMngTtlStWork wkStockMngTtlStWork in wkList)
            {
                fractionProcCd = wkStockMngTtlStWork.FractionProcCd;        // 端数処理区分
            }

            return fractionProcCd;
        }

        /// <summary>
        /// 端数処理
        /// </summary>
        /// <param name="parameter">端数処理対象となる値</param>
        /// <returns>端数処理後の値</returns>
        /// <remarks>
        /// <br>Note       : 端数処理区分を元に端数処理を行います。※戻り値は整数となることが必須</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        private double FractionProc(double parameter)
        {
            switch (this._fractionProcCd)
            {
                case 1:
                    {
                        // 切り捨て
                        return Math.Floor(parameter);
                    }
                case 2:
                    {
                        // 四捨五入
                        return Round(parameter);
                    }
                case 3:
                    {
                        // 切り上げ
                        return Math.Ceiling(parameter);
                    }
                default:
                    return parameter;
            }
        }

        /// <summary>
        /// 四捨五入処理
        /// </summary>
        /// <param name="parameter">端数処理するDouble値</param>
        /// <returns>四捨五入されたdouble</returns>
        private static Int64 Round(double parameter)
        {
            // 整数部　四捨五入
            return (Int64)Round(parameter, 0, 5);
        }
        /// <summary>
        /// 四捨五入処理
        /// </summary>
        /// <param name="parameter">端数処理するDouble値</param>
        /// <param name="digits">小数点以下の有効桁数</param>
        /// <returns>四捨五入されたdouble</returns>
        public static double Round(double parameter, int digits)
        {
            // 四捨五入
            return Round(parameter, digits, 5);
        }
        /// <summary>
        /// 四捨五入処理
        /// </summary>
        /// <param name="parameter">端数処理するDouble値</param>
        /// <param name="digits">小数点以下の有効桁数</param>
        /// <param name="divide">切り上げる境界の値 1～9　(ex. 5→四捨五入)</param>
        /// <returns>四捨五入されたdouble</returns>
        public static double Round(double parameter, int digits, int divide)
        {
            decimal param = (decimal)parameter;
            decimal dCoef = (decimal)Math.Pow(10, digits);
            decimal dDiv = 1.0m - ((decimal)divide / 10);

            if (param > 0)
            {
                // 0.5を足して「＋のときの切り捨て」（ゼロに近づける）
                param = Math.Floor((param * dCoef) + dDiv) / dCoef;
            }
            else
            {
                // -0.5を足して「－のときの切り捨て」（ゼロに近づける）
                param = Math.Ceiling((param * dCoef) - dDiv) / dCoef;
            }
            return (double)param;
        }
        // --- ADD 2008/11/20 ------------------------------------------------------->>>>>

		#endregion ◆ 帳票設定データ取得

        #region ◆ データ更新処理   ADD 2009/03/16 不具合対応[12331]
        /// <summary>
        /// データ更新処理
        /// </summary>
        /// <param name="dataView">印刷データ</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>Status(NORMAL or その他)</returns>
        /// <remarks>
        /// <br>Note       : データ更新を行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/03/16</br>
        /// </remarks>
        private int UpdateStockMoveMainProc(DataView dataView, out string errMsg)
        {
            int status = 0;
            errMsg = string.Empty;
            StockMoveWork stockMoveWork = null;
            ArrayList arrayList = new ArrayList();

            #region 更新データ取得
            // 更新データ取得
            DataRow dataRow = null;
            DataTable dataTable = dataView.Table;
            for (int i = 0; i <= dataTable.Rows.Count - 1; i++)
            {
                dataRow = dataTable.Rows[i];
                if ((int)dataRow[MAZAI02034EA.ct_Col_SlipPrintFinishCd] == 1)
                {
                    continue;
                }

                stockMoveWork = new StockMoveWork();
                stockMoveWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;                 // 企業コード
                stockMoveWork.StockMoveFormal = (int)dataRow[MAZAI02034EA.ct_Col_StockMoveFormal];  // 在庫移動形式
                stockMoveWork.StockMoveSlipNo = (int)dataRow[MAZAI02034EA.ct_Col_StockMoveSlipNo];  // 在庫移動伝票番号
                stockMoveWork.StockMoveRowNo = (int)dataRow[MAZAI02034EA.ct_Col_StockMoveRowNo];    // 在庫移動行番号
                stockMoveWork.SlipPrintFinishCd = 1;                                                // 伝票発行済区分「1:発行済」

                arrayList.Add(stockMoveWork);
            }

            if (arrayList.Count == 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            #endregion

            #region 更新処理
            // 更新処理
            IStockMoveDB iStockMoveDB = null;
            iStockMoveDB = MediationStockMoveDB.GetStockMoveDB();

            Object stockMoveWorkObj = (object)arrayList;
            status = iStockMoveDB.WriteSlipPrintFinishCd(ref stockMoveWorkObj);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        break;
                    }
                default:
                    {
                        errMsg = "在庫移動データの更新でエラーが発生しました。";
                        break;
                    }
            }
            #endregion

            return status;
        }
        #endregion ◆ データ更新処理
        #endregion ■ Private Method
    }
}

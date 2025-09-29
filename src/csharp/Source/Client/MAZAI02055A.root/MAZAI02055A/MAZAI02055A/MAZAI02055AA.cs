using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Collections;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{

    /// <summary>
    /// 在庫調整確認表アクセスクラス
    /// </summary>
    /// <remarks>
	/// <br>Note       : 在庫調整確認表アクセスクラス</br>
    /// <br>Programmer : 97036 amami</br>
    /// <br>Date       : 2007.03.14</br>
    /// <br></br>
    /// <br>UpdateNote : 2007.07.13  20031 古賀　小百合</br>
    /// <br>           :    ・「不良品確認表」帳票出力を追加</br>
    /// <br>UpdateNote : 2007.10.04 980035 金沢 貞義</br>
    /// <br>                ・ DC.NS対応</br>
    /// <br>UpdateNote : 2008.03.03 980035 金沢 貞義</br>
    /// <br>			    ・ DC.NS対応（不具合対応）</br>
    /// <br>           : 2008/11/20        照田 貴志</br>
    /// <br>　　　　　　　　・ 在庫管理全体設定マスタの端数処理区分に従って端数処理を行うように修正</br>
    /// <br>           : 2009/01/26        照田 貴志　不具合対応[10505]</br>
    /// <br>           : 2009/03/09        照田 貴志　不具合対応[12040]</br>
    /// <br>           : 2011/11/15        許培珠　redmine#26559</br>
    /// </remarks>
    public class StockAdjustListAcs
    {
		# region Constractor
		/// <summary>
		/// 在庫調整確認表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫調整確認表アクセスクラス</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.14</br>
		/// <br></br>
		/// </remarks>
		public StockAdjustListAcs()
        {
			this._iStockAdjustWorkDB = (IStockAdjustWorkDB)MediationStockAdjustWorkDB.GetStockAdjustWorkDB();
            this._iStockMngTtlStDB = MediationStockMngTtlStDB.GetStockMngTtlStDB();     //ADD 2008/11/20
		}
		# endregion

		# region Static Constractor
		/// <summary>
		/// 入金一覧表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 入金一覧表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 22013 久保 将太</br>
	    /// <br>Date       : 2007.03.06</br>
		/// </remarks>
		static StockAdjustListAcs()
		{
			// 従業員情報
			stc_Employee		= null;

			// 帳票出力設定データクラス
			stc_PrtOutSet		= null;
			
			// 帳票出力設定アクセスクラス
			stc_PrtOutSetAcs	= new PrtOutSetAcs();

			// ログイン拠点取得
		    Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
		    if (loginEmployee != null) stc_Employee = loginEmployee.Clone();
		}
		# endregion

		# region Private Menbers
		/// <summary> 在庫調整確認表リモートインターフェース </summary>
		IStockAdjustWorkDB _iStockAdjustWorkDB;
		/// <summary> 在庫調整確認データセット </summary>
		private DataSet _stockAdjustDs;

        /// <summary> 在庫管理全体設定リモートインターフェース </summary>
        private IStockMngTtlStDB _iStockMngTtlStDB = null;                          //ADD 2008/11/20
        /// <summary> 在庫管理全体設定マスタの端数処理区分 </summary>
        private int _fractionProcCd;                            //端数処理区分      //ADD 2008/11/20


        # endregion

		# region Static Private Member
		/// <summary> 従業員情報 </summary>
		private static Employee stc_Employee;
		/// <summary> 帳票出力設定データクラス </summary>
		private static PrtOutSet stc_PrtOutSet;
		/// <summary> 帳票出力設定アクセスクラス </summary>
		private static PrtOutSetAcs stc_PrtOutSetAcs;
		# endregion

		# region Public Property
		/// <summary>
		/// 在庫調整確認データセット(get)
		/// </summary>
		public DataSet StockAdjustDs
		{
			get { return this._stockAdjustDs; }
		}
		# endregion

		# region Public Method
		/// <summary>
		/// 在庫調整確認データ取得
		/// </summary>
		/// <param name="confirmStockAdjustListCndtn">抽出条件</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する在庫調整確認データを取得する。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.14</br>
		/// </remarks>
		public int SearchConfirmStockAdjust(ConfirmStockAdjustListCndtn confirmStockAdjustListCndtn, out string errMsg)
		{
			return this.SearchConfirmStockAdjustProc(confirmStockAdjustListCndtn, out errMsg);
		}
		# endregion

		# region Public static Method
		/// <summary>
		/// 帳票出力設定読込
		/// </summary>
		/// <param name="retPrtOutSet">帳票出力設定データクラス</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>status</returns>
		/// <remarks>
		/// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.14</br>
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
					status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
				}
				else
				{
					status = stc_PrtOutSetAcs.Read(out stc_PrtOutSet, LoginInfoAcquisition.EnterpriseCode, stc_Employee.BelongSectionCode);

					switch (status)
					{
						case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
							retPrtOutSet = stc_PrtOutSet.Clone();
							status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
							break;
						case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
						case (int)ConstantManagement.DB_Status.ctDB_EOF:
							status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
							break;
						default:
							errMsg = "帳票出力設定の読込に失敗しました";
							status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
							break;
					}
				}
			}
			catch (Exception ex)
			{
				errMsg = ex.Message;
				retPrtOutSet = new PrtOutSet();
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
		# endregion

		# region Private Method
		/// <summary>
		/// 在庫調整確認データ取得
		/// </summary>
		/// <param name="confirmStockAdjustListCndtn"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する在庫調整確認データを取得する。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.14</br>
		/// </remarks>
		private int SearchConfirmStockAdjustProc(ConfirmStockAdjustListCndtn confirmStockAdjustListCndtn, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

			try
			{
				MAZAI02054EA.CreateDataTableStockAdjustDtl(ref this._stockAdjustDs);
				StockAdjustCndtnWork stockAdjustCndtnWork = new StockAdjustCndtnWork();

				// 抽出条件展開処理
				status = this.DevConfirmStockAdjustCndtn(confirmStockAdjustListCndtn, out stockAdjustCndtnWork, out errMsg);
				if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
				{
					return status;
				}

				// データ取得  ----------------------------------------------------------------
				object retStockAdjustList = null;
				status = this._iStockAdjustWorkDB.Search(out retStockAdjustList, (object)stockAdjustCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);
                //--- TEST --------->>>>>
                //retStockAdjustList = this.GetTestData();
                //status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //--- TEST ---------<<<<<

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // 端数処理区分取得
                        this._fractionProcCd = this.GetFractionProcCd();        //ADD 2008/11/20

						// 在庫調整確認データ展開処理
						this.DevStockAdjustData(confirmStockAdjustListCndtn, this._stockAdjustDs.Tables[MAZAI02054EA.ct_Tbl_StockAdjustDtl], (ArrayList)retStockAdjustList);
						status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
						break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
					default:
						errMsg = "在庫調整データの取得に失敗しました。";
						break;
				}
			}
			catch (Exception ex)
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}

		# region テスト用
        
		private object GetTestData()
		{
			ArrayList list = new ArrayList();

			StockAdjustResultWork work = new StockAdjustResultWork();

			work.SectionCode = "01";				// 拠点コード
			work.SectionGuideNm = "拠点01";		    // 拠点ガイド名称
			work.AcPaySlipCd = 0;					// 受払元伝票区分 10:仕入,11:受託,12:受計上,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,50:棚卸
			work.AcPayTransCd = 0;					// 受払元取引区分 10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消
			work.AdjustDate = TDateTime.LongDateToDateTime(20070314);		// 調整日付
			work.StockAdjustSlipNo = 1000;			// 在庫調整伝票番号
			work.StockAdjustRowNo = 0;				// 在庫調整行番号
			work.GoodsMakerCd = 10;					// メーカーコード
			work.MakerName = "パナソニック";		// メーカー名称
			work.GoodsNo = "20";					// 商品コード
			work.GoodsName = "P901_ブルー";			// 商品名称
            //work.ProductNumber = "P100000005";		// 製造番号
            //work.BfProductNumber = "P10000000";		// 変更前製造番号
            //work.StockTelNo1 = "090-8919-0000";		// 商品電話番号1
            //work.BfStockTelNo1 = "090-1111-2222";	// 変更前商品電話番号1
            // ----- DEL 2011/11/15 xupz---------->>>>>
            //work.StockInputCode = "30";				// 入力担当者コード
            //work.StockInputName = "福岡 太郎";			// 入力担当者名称
            // ----- DEL 2011/11/15 xupz----------<<<<<
            // ----- ADD 2011/11/15 xupz---------->>>>>
            work.StockAgentCode = "30";				// 仕入担当者コード
            work.StockAgentName = "福岡 太郎";			// 仕入担当者名称
            // ----- ADD 2011/11/15 xupz----------<<<<<
            work.StockUnitPriceFl = 45000;			// 仕入単価
            work.BfStockUnitPriceFl = 35000;		// 変更前仕入単価
            work.DtlNote = "明細備考・・・・";		// 明細備考
			work.AdjustCount = 1.0;					// 調整数
			work.SlipNote = "伝票備考・・・・";		// 伝票備考
            //work.StockTelNo2 = "";					// 商品電話番号2
            //work.BfStockTelNo2 = "";				// 変更前商品電話番号2
            //work.PrdNumMngDiv = 1;					// 製番管理区分 0:無,1:有
			//work.SupplierStock = 1.0;				// 仕入在庫数
			//work.TrustCount = 0.0;					// 受託数
            //work.StockState = 0;					// 在庫状態 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
            //work.BfStockState = 10;					// 変更前在庫状態
			//work.StockDiv = 0;						// 在庫区分 0:自社、1:受託
            //work.GoodsCodeStatus = 0;				// 商品状態 0:正常,1:不良品
            work.WarehouseCode = "0001";
            work.WarehouseName = "倉庫01";
            work.WarehouseShelfNo = "01";
            work.ListPriceFl = 10000;

			list.Add(work);

			StockAdjustResultWork work1 = new StockAdjustResultWork();

            work1.SectionCode = "01";				// 拠点コード
            work1.SectionGuideNm = "拠点01";		// 拠点ガイド名称
			work1.AcPaySlipCd = 0;					// 受払元伝票区分 10:仕入,11:受託,12:受計上,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,50:棚卸
			work1.AcPayTransCd = 0;					// 受払元取引区分 10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消
			work1.AdjustDate = TDateTime.LongDateToDateTime(20070314);		// 調整日付
			work1.StockAdjustSlipNo = 2000;			// 在庫調整伝票番号
			work1.StockAdjustRowNo = 1;				// 在庫調整行番号
			work1.GoodsMakerCd = 10;					// メーカーコード
			work1.MakerName = "パナソニック";		// メーカー名称
			work1.GoodsNo = "20";					// 商品コード
			work1.GoodsName = "P901_ブルー";		// 商品名称
            //work1.ProductNumber = "P100000100";		// 製造番号
            //work1.BfProductNumber = "P10000000";	// 変更前製造番号
            //work1.StockTelNo1 = "090-8919-1000";	// 商品電話番号1
            //work1.BfStockTelNo1 = "090-1111-3333";	// 変更前商品電話番号1
            // ----- DEL 2011/11/15 xupz---------->>>>>
            //work1.StockInputCode = "30";				// 入力担当者コード
            //work1.StockInputName = "福岡 太郎";		// 入力担当者名称
            // ----- DEL 2011/11/15 xupz----------<<<<<
            // ----- ADD 2011/11/15 xupz---------->>>>>
            work1.StockAgentCode = "30";				// 仕入担当者コード
            work1.StockAgentName = "福岡 太郎";			// 仕入担当者名称
            // ----- ADD 2011/11/15 xupz----------<<<<<
            work1.StockUnitPriceFl = 45000;			// 仕入単価
            work1.BfStockUnitPriceFl = 35000;		// 変更前仕入単価
			work1.DtlNote = "明細備考・・・・";		// 明細備考
			work1.AdjustCount = -1.0;				// 調整数
			work1.SlipNote = "伝票備考・・・・";	// 伝票備考
            //work1.StockTelNo2 = "";					// 商品電話番号2
            //work1.BfStockTelNo2 = "";				// 変更前商品電話番号2
            //work1.PrdNumMngDiv = 1;					// 製番管理区分 0:無,1:有
			//work1.SupplierStock = 1.0;				// 仕入在庫数
			//work1.TrustCount = 0.0;					// 受託数
            //work1.StockState = 0;					// 在庫状態 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
            //work1.BfStockState = 10;				// 変更前在庫状態
			//work1.StockDiv = 0;						// 在庫区分 0:自社、1:受託
            //work1.GoodsCodeStatus = 0;				// 商品状態 0:正常,1:不良品
            work1.WarehouseCode = "0001";
            work1.WarehouseName = "倉庫01";

			list.Add(work1);

			StockAdjustResultWork work2 = new StockAdjustResultWork();

            work2.SectionCode = "01";				    // 拠点コード
            work2.SectionGuideNm = "拠点01";		    // 拠点ガイド名称
			work2.AcPaySlipCd = 0;					    // 受払元伝票区分 10:仕入,11:受託,12:受計上,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,50:棚卸
			work2.AcPayTransCd = 0;					    // 受払元取引区分 10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消
			work2.AdjustDate = TDateTime.LongDateToDateTime(20070314);		// 調整日付
			work2.StockAdjustSlipNo = 2000;			    // 在庫調整伝票番号
			work2.StockAdjustRowNo = 2;				    // 在庫調整行番号
			work2.GoodsMakerCd = 10;					// メーカーコード
			work2.MakerName = "パナソニック";		    // メーカー名称
			work2.GoodsNo = "123456789012345678901234";	// 商品コード
			work2.GoodsName = "あいうえおかきくけこさしすせそたちつてと";   // 商品名称
            //work2.ProductNumber = "P2345678901234567890";		// 製造番号
            //work2.BfProductNumber = "P10000000";	    // 変更前製造番号
            //work2.StockTelNo1 = "090-8919-1000";	    // 商品電話番号1
            //work2.BfStockTelNo1 = "090-1111-3333";	// 変更前商品電話番号1
            // ----- DEL 2011/11/15 xupz---------->>>>>
            //work2.StockInputCode = "30";				    // 入力担当者コード
            //work2.StockInputName = "福岡 太郎";		    // 入力担当者名称
            // ----- DEL 2011/11/15 xupz----------<<<<<
            // ----- ADD 2011/11/15 xupz---------->>>>>
            work2.StockAgentCode = "30";				// 仕入担当者コード
            work2.StockAgentName = "福岡 太郎";			// 仕入担当者名称
            // ----- ADD 2011/11/15 xupz----------<<<<<
            work2.StockUnitPriceFl = 1000;		        // 仕入単価
            work2.BfStockUnitPriceFl = 1001;		    // 変更前仕入単価
			work2.DtlNote = "明細備考・・・・・・・・・・・・・・・・";		// 明細備考
			work2.AdjustCount = 10;				        // 調整数
			work2.SlipNote = "伝票備考・・・・・・・・・・・・・・・・・・・・・・・・・・・・";	// 伝票備考
            //work2.StockTelNo2 = "";					// 商品電話番号2
            //work2.BfStockTelNo2 = "";				    // 変更前商品電話番号2
            //work2.PrdNumMngDiv = 1;					// 製番管理区分 0:無,1:有
			//work2.SupplierStock = 1.0;				    // 仕入在庫数
			//work2.TrustCount = 0.0;					    // 受託数
            //work2.StockState = 0;					    // 在庫状態 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
            //work2.BfStockState = 10;				    // 変更前在庫状態
			//work2.StockDiv = 0;						    // 在庫区分 0:自社、1:受託
            //work2.GoodsCodeStatus = 0;				// 商品状態 0:正常,1:不良品
            work2.WarehouseCode = "0001";
            work2.WarehouseName = "倉庫01";

			list.Add(work2);

			StockAdjustResultWork work3 = new StockAdjustResultWork();

            work3.SectionCode = "01";				// 拠点コード
            work3.SectionGuideNm = "拠点01";		// 拠点ガイド名称
			work3.AcPaySlipCd = 0;					// 受払元伝票区分 10:仕入,11:受託,12:受計上,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,50:棚卸
			work3.AcPayTransCd = 0;					// 受払元取引区分 10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消
			work3.AdjustDate = TDateTime.LongDateToDateTime(20070314);		// 調整日付
			work3.StockAdjustSlipNo = 3000;			// 在庫調整伝票番号
			work3.StockAdjustRowNo = 3;				// 在庫調整行番号
			work3.GoodsMakerCd = 20;					// メーカーコード
			work3.MakerName = "富士通";				// メーカー名称
			work3.GoodsNo = "30";					// 商品コード
			work3.GoodsName = "F901_レッド";		// 商品名称
            //work3.ProductNumber = "F100000100";		// 製造番号
            //work3.BfProductNumber = "F10000000";	// 変更前製造番号
            //work3.StockTelNo1 = "090-6534-1000";	// 商品電話番号1
            //work3.BfStockTelNo1 = "090-8888-1111";	// 変更前商品電話番号1
            // ----- DEL 2011/11/15 xupz---------->>>>>
            //work3.StockInputCode = "30";				// 入力担当者コード
            //work3.StockInputName = "福岡 太郎";		// 入力担当者名称
            // ----- DEL 2011/11/15 xupz----------<<<<<
            // ----- ADD 2011/11/15 xupz---------->>>>>
            work3.StockAgentCode = "30";				// 仕入担当者コード
            work3.StockAgentName = "福岡 太郎";			// 仕入担当者名称
            // ----- ADD 2011/11/15 xupz----------<<<<<
            work3.StockUnitPriceFl = 10;			// 仕入単価
            work3.BfStockUnitPriceFl = 100;			// 変更前仕入単価
			work3.DtlNote = "明細備考・・・・";		// 明細備考
			work3.AdjustCount = -123.0;				// 調整数
			work3.SlipNote = "伝票備考・・・・";	// 伝票備考
            //work3.StockTelNo2 = "";					// 商品電話番号2
            //work3.BfStockTelNo2 = "";				// 変更前商品電話番号2
            //work3.PrdNumMngDiv = 1;					// 製番管理区分 0:無,1:有
			//work3.SupplierStock = 1.0;				// 仕入在庫数
			//work3.TrustCount = 0.0;					// 受託数
            //work3.StockState = 0;					// 在庫状態 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
            //work3.BfStockState = 10;				// 変更前在庫状態
			//work3.StockDiv = 0;						// 在庫区分 0:自社、1:受託
            //work3.GoodsCodeStatus = 0;				// 商品状態 0:正常,1:不良品
            work3.WarehouseCode = "0001";
            work3.WarehouseName = "倉庫01";

			list.Add(work3);

			StockAdjustResultWork work4 = new StockAdjustResultWork();

            work4.SectionCode = "01";				// 拠点コード
            work4.SectionGuideNm = "拠点01";		// 拠点ガイド名称
			work4.AcPaySlipCd = 0;					// 受払元伝票区分 10:仕入,11:受託,12:受計上,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,50:棚卸
			work4.AcPayTransCd = 0;					// 受払元取引区分 10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消
			work4.AdjustDate = TDateTime.LongDateToDateTime(20070314);		// 調整日付
			work4.StockAdjustSlipNo = 4000;			// 在庫調整伝票番号
			work4.StockAdjustRowNo = 4;				// 在庫調整行番号
            //work4.MakerCode = 30;					// メーカーコード
			work4.MakerName = "ソニー";				// メーカー名称
            //work4.GoodsCode = "50";					// 商品コード
			work4.GoodsName = "SO901_レッド";		// 商品名称
            //work4.ProductNumber = "S100000100";		// 製造番号
            //work4.BfProductNumber = "S10000000";	// 変更前製造番号
            //work4.StockTelNo1 = "090-4568-1000";	// 商品電話番号1
            //work4.BfStockTelNo1 = "090-5555-1111";	// 変更前商品電話番号1
            // ----- DEL 2011/11/15 xupz---------->>>>>
            //work4.StockInputCode = "30";				// 入力担当者コード
            //work4.StockInputName = "福岡 太郎";		// 入力担当者名称
            // ----- DEL 2011/11/15 xupz----------<<<<<
            // ----- ADD 2011/11/15 xupz---------->>>>>
            work4.StockAgentCode = "30";				// 仕入担当者コード
            work4.StockAgentName = "福岡 太郎";			// 仕入担当者名称
            // ----- ADD 2011/11/15 xupz----------<<<<<
            work4.StockUnitPriceFl = 45000;			// 仕入単価
            work4.BfStockUnitPriceFl = 35000;		// 変更前仕入単価
			work4.DtlNote = "明細備考・・・・";		// 明細備考
			work4.AdjustCount = -1.0;				// 調整数
			work4.SlipNote = "伝票備考・・・・";	// 伝票備考
            //work4.StockTelNo2 = "";					// 商品電話番号2
            //work4.BfStockTelNo2 = "";				// 変更前商品電話番号2
            //work4.PrdNumMngDiv = 1;					// 製番管理区分 0:無,1:有
            //work4.SupplierStock = 1.0;				// 仕入在庫数
            //work4.TrustCount = 0.0;					// 受託数
            //work4.StockState = 0;					// 在庫状態 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
            //work4.BfStockState = 10;				// 変更前在庫状態
            //work4.StockDiv = 0;						// 在庫区分 0:自社、1:受託
            //work4.GoodsCodeStatus = 0;				// 商品状態 0:正常,1:不良品
            work4.WarehouseCode = "0001";
            work4.WarehouseName = "倉庫01";

			list.Add(work4);

			StockAdjustResultWork work5 = new StockAdjustResultWork();

            work5.SectionCode = "01";				// 拠点コード
            work5.SectionGuideNm = "拠点01";		// 拠点ガイド名称
			work5.AcPaySlipCd = 0;					// 受払元伝票区分 10:仕入,11:受託,12:受計上,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,50:棚卸
			work5.AcPayTransCd = 0;					// 受払元取引区分 10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消
			work5.AdjustDate = TDateTime.LongDateToDateTime(20070314);		// 調整日付
			work5.StockAdjustSlipNo = 4000;			// 在庫調整伝票番号
			work5.StockAdjustRowNo = 0;				// 在庫調整行番号
            //work5.MakerCode = 30;					// メーカーコード
			work5.MakerName = "ソニー";				// メーカー名称
            //work5.GoodsCode = "50";					// 商品コード
			work5.GoodsName = "SO901_レッド";		// 商品名称
            //work5.ProductNumber = "S100000100";		// 製造番号
            //work5.BfProductNumber = "S10000000";	// 変更前製造番号
            //work5.StockTelNo1 = "090-4568-1000";	// 商品電話番号1
            //work5.BfStockTelNo1 = "090-5555-1111";	// 変更前商品電話番号1
            // ----- DEL 2011/11/15 xupz---------->>>>>
            //work5.StockInputCode = "30";				// 入力担当者コード
            //work5.StockInputName = "福岡 太郎";		// 入力担当者名称
            // ----- DEL 2011/11/15 xupz----------<<<<<
            // ----- ADD 2011/11/15 xupz---------->>>>>
            work5.StockAgentCode = "30";				// 仕入担当者コード
            work5.StockAgentName = "福岡 太郎";			// 仕入担当者名称
            // ----- ADD 2011/11/15 xupz----------<<<<<
            work5.StockUnitPriceFl = 45000;			// 仕入単価
            work5.BfStockUnitPriceFl = 35000;		// 変更前仕入単価
			work5.DtlNote = "明細備考・・・・";		// 明細備考
			work5.AdjustCount = -1.0;				// 調整数
			work5.SlipNote = "伝票備考・・・・";	// 伝票備考
            //work5.StockTelNo2 = "";					// 商品電話番号2
            //work5.BfStockTelNo2 = "";				// 変更前商品電話番号2
            //work5.PrdNumMngDiv = 1;					// 製番管理区分 0:無,1:有
            //work5.SupplierStock = 1.0;				// 仕入在庫数
            //work5.TrustCount = 0.0;					// 受託数
            //work5.StockState = 0;					// 在庫状態 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
            //work5.BfStockState = 10;				// 変更前在庫状態
            //work5.StockDiv = 0;						// 在庫区分 0:自社、1:受託
            //work5.GoodsCodeStatus = 0;				// 商品状態 0:正常,1:不良品
            work5.WarehouseCode = "0001";
            work5.WarehouseName = "倉庫01";

			list.Add(work5);

			StockAdjustResultWork work6 = new StockAdjustResultWork();

            work6.SectionCode = "03";				// 拠点コード
            work6.SectionGuideNm = "拠点03";		// 拠点ガイド名称
			work6.AcPaySlipCd = 0;					// 受払元伝票区分 10:仕入,11:受託,12:受計上,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,50:棚卸
			work6.AcPayTransCd = 0;					// 受払元取引区分 10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消
			work6.AdjustDate = TDateTime.LongDateToDateTime(20070314);		// 調整日付
			work6.StockAdjustSlipNo = 3000;			// 在庫調整伝票番号
			work6.StockAdjustRowNo = 0;				// 在庫調整行番号
            //work6.MakerCode = 30;					// メーカーコード
			work6.MakerName = "ソニー";				// メーカー名称
            //work6.GoodsCode = "50";					// 商品コード
			work6.GoodsName = "SO901_レッド";		// 商品名称
            //work6.ProductNumber = "S100000100";		// 製造番号
            //work6.BfProductNumber = "S10000000";	// 変更前製造番号
            //work6.StockTelNo1 = "090-4568-1000";	// 商品電話番号1
            //work6.BfStockTelNo1 = "090-5555-1111";	// 変更前商品電話番号1
            // ----- DEL 2011/11/15 xupz---------->>>>>
            //work6.StockInputCode = "30";				// 入力担当者コード
            //work6.StockInputName = "福岡 太郎";		// 入力担当者名称
            // ----- DEL 2011/11/15 xupz----------<<<<<
            // ----- ADD 2011/11/15 xupz---------->>>>>
            work6.StockAgentCode = "30";				// 仕入担当者コード
            work6.StockAgentName = "福岡 太郎";			// 仕入担当者名称
            // ----- ADD 2011/11/15 xupz----------<<<<<
            work6.StockUnitPriceFl = 45000;			// 仕入単価
            work6.BfStockUnitPriceFl = 35000;		// 変更前仕入単価
			work6.DtlNote = "明細備考・・・・";		// 明細備考
			work6.AdjustCount = -1.0;				// 調整数
			work6.SlipNote = "";					// 伝票備考
            //work6.StockTelNo2 = "";					// 商品電話番号2
            //work6.BfStockTelNo2 = "";				// 変更前商品電話番号2
            //work6.PrdNumMngDiv = 1;					// 製番管理区分 0:無,1:有
            //work6.SupplierStock = 1.0;				// 仕入在庫数
            //work6.TrustCount = 0.0;					// 受託数
            //work6.StockState = 0;					// 在庫状態 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
            //work6.BfStockState = 10;				// 変更前在庫状態
            //work6.StockDiv = 0;						// 在庫区分 0:自社、1:受託
            //work6.GoodsCodeStatus = 0;				// 商品状態 0:正常,1:不良品
            work6.WarehouseCode = "0001";
            work6.WarehouseName = "倉庫01";

			list.Add(work6);

			StockAdjustResultWork work7 = new StockAdjustResultWork();

            work7.SectionCode = "03";				// 拠点コード
            work7.SectionGuideNm = "拠点03";		// 拠点ガイド名称
			work7.AcPaySlipCd = 0;					// 受払元伝票区分 10:仕入,11:受託,12:受計上,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,50:棚卸
			work7.AcPayTransCd = 0;					// 受払元取引区分 10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消
			work7.AdjustDate = TDateTime.LongDateToDateTime(20070316);		// 調整日付
			work7.StockAdjustSlipNo = 4000;			// 在庫調整伝票番号
			work7.StockAdjustRowNo = 0;				// 在庫調整行番号
            //work7.MakerCode = 10;					// メーカーコード
			work7.MakerName = "パナソニック";		// メーカー名称
            //work7.GoodsCode = "20";					// 商品コード
			work7.GoodsName = "P901_ブルー";		// 商品名称
            //work7.ProductNumber = "P100000005";		// 製造番号
            //work7.BfProductNumber = "P10000000";	// 変更前製造番号
            //work7.StockTelNo1 = "090-8919-0000";	// 商品電話番号1
            //work7.BfStockTelNo1 = "090-1111-2222";	// 変更前商品電話番号1
            // ----- DEL 2011/11/15 xupz---------->>>>>
            //work7.StockInputCode = "30";				// 入力担当者コード
            //work7.StockInputName = "福岡 太郎";		// 入力担当者名称
            // ----- DEL 2011/11/15 xupz----------<<<<<
            // ----- ADD 2011/11/15 xupz---------->>>>>
            work7.StockAgentCode = "30";				// 仕入担当者コード
            work7.StockAgentName = "福岡 太郎";			// 仕入担当者名称
            // ----- ADD 2011/11/15 xupz----------<<<<<
            work7.StockUnitPriceFl = 45000;			// 仕入単価
            work7.BfStockUnitPriceFl = 35000;		// 変更前仕入単価
			work7.DtlNote = "明細備考・・・・";		// 明細備考
			work7.AdjustCount = -1.0;				// 調整数
			work7.SlipNote = "";					// 伝票備考
            //work7.StockTelNo2 = "";					// 商品電話番号2
            //work7.BfStockTelNo2 = "";				// 変更前商品電話番号2
            //work7.PrdNumMngDiv = 1;					// 製番管理区分 0:無,1:有
            //work7.SupplierStock = 1.0;				// 仕入在庫数
            //work7.TrustCount = 0.0;					// 受託数
            //work7.StockState = 0;					// 在庫状態 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
            //work7.BfStockState = 10;				// 変更前在庫状態
            //work7.StockDiv = 0;						// 在庫区分 0:自社、1:受託
            //work7.GoodsCodeStatus = 0;				// 商品状態 0:正常,1:不良品
            work7.WarehouseCode = "0001";
            work7.WarehouseName = "倉庫01";

			list.Add(work7);

			StockAdjustResultWork work8 = new StockAdjustResultWork();

            work8.SectionCode = "03";				// 拠点コード
            work8.SectionGuideNm = "拠点03";		// 拠点ガイド名称
			work8.AcPaySlipCd = 0;					// 受払元伝票区分 10:仕入,11:受託,12:受計上,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,50:棚卸
			work8.AcPayTransCd = 0;					// 受払元取引区分 10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消
			work8.AdjustDate = TDateTime.LongDateToDateTime(20070316);		// 調整日付
			work8.StockAdjustSlipNo = 4000;			// 在庫調整伝票番号
			work8.StockAdjustRowNo = 1;				// 在庫調整行番号
            //work8.MakerCode = 10;					// メーカーコード
			work8.MakerName = "パナソニック";		// メーカー名称
            //work8.GoodsCode = "20";					// 商品コード
			work8.GoodsName = "P901_ブルー";		// 商品名称
            //work8.ProductNumber = "P100000100";		// 製造番号
            //work8.BfProductNumber = "P10000000";	// 変更前製造番号
            //work8.StockTelNo1 = "090-8919-1000";	// 商品電話番号1
            //work8.BfStockTelNo1 = "090-1111-3333";	// 変更前商品電話番号1
            // ----- DEL 2011/11/15 xupz---------->>>>>
            //work8.StockInputCode = "30";				// 入力担当者コード
            //work8.StockInputName = "福岡 太郎";		// 入力担当者名称
            // ----- DEL 2011/11/15 xupz----------<<<<<
            // ----- ADD 2011/11/15 xupz---------->>>>>
            work8.StockAgentCode = "30";				// 仕入担当者コード
            work8.StockAgentName = "福岡 太郎";			// 仕入担当者名称
            // ----- ADD 2011/11/15 xupz----------<<<<<
            work8.StockUnitPriceFl = 45000;			// 仕入単価
            work8.BfStockUnitPriceFl = 35000;		// 変更前仕入単価
			work8.DtlNote = "明細備考・・・・";		// 明細備考
			work8.AdjustCount = -1.0;				// 調整数
			work8.SlipNote = "伝票備考・・・・";	// 伝票備考
            //work8.StockTelNo2 = "";					// 商品電話番号2
            //work8.BfStockTelNo2 = "";				// 変更前商品電話番号2
            //work8.PrdNumMngDiv = 1;					// 製番管理区分 0:無,1:有
            //work8.SupplierStock = 1.0;				// 仕入在庫数
            //work8.TrustCount = 0.0;					// 受託数
            //work8.StockState = 0;					// 在庫状態 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
            //work8.BfStockState = 10;				// 変更前在庫状態
            //work8.StockDiv = 0;						// 在庫区分 0:自社、1:受託
            //work8.GoodsCodeStatus = 0;				// 商品状態 0:正常,1:不良品
            work8.WarehouseCode = "0001";
            work8.WarehouseName = "倉庫01";

			list.Add(work8);

			StockAdjustResultWork work9 = new StockAdjustResultWork();

            work9.SectionCode = "03";				// 拠点コード
            work9.SectionGuideNm = "拠点03";		// 拠点ガイド名称
			work9.AcPaySlipCd = 0;					// 受払元伝票区分 10:仕入,11:受託,12:受計上,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,50:棚卸
			work9.AcPayTransCd = 0;					// 受払元取引区分 10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消
			work9.AdjustDate = TDateTime.LongDateToDateTime(20070316);		// 調整日付
			work9.StockAdjustSlipNo = 4000;			// 在庫調整伝票番号
			work9.StockAdjustRowNo = 2;				// 在庫調整行番号
            //work9.MakerCode = 20;					// メーカーコード
			work9.MakerName = "富士通";				// メーカー名称
            //work9.GoodsCode = "30";					// 商品コード
			work9.GoodsName = "F901_レッド";		// 商品名称
            //work9.ProductNumber = "F100000100";		// 製造番号
            //work9.BfProductNumber = "F10000000";	// 変更前製造番号
            //work9.StockTelNo1 = "090-6534-1000";	// 商品電話番号1
            //work9.BfStockTelNo1 = "090-8888-1111";	// 変更前商品電話番号1
            // ----- DEL 2011/11/15 xupz---------->>>>>
            //work9.StockInputCode = "30";				// 入力担当者コード
            //work9.StockInputName = "福岡 太郎";		// 入力担当者名称
            // ----- DEL 2011/11/15 xupz----------<<<<<
            // ----- ADD 2011/11/15 xupz---------->>>>>
            work9.StockAgentCode = "30";				// 仕入担当者コード
            work9.StockAgentName = "福岡 太郎";			// 仕入担当者名称
            // ----- ADD 2011/11/15 xupz----------<<<<<
            work9.StockUnitPriceFl = 45000;			// 仕入単価
            work9.BfStockUnitPriceFl = 35000;		// 変更前仕入単価
			work9.DtlNote = "明細備考・・・・";		// 明細備考
			work9.AdjustCount = -1.0;				// 調整数
			work9.SlipNote = "伝票備考・・・・";	// 伝票備考
            //work9.StockTelNo2 = "";					// 商品電話番号2
            //work9.BfStockTelNo2 = "";				// 変更前商品電話番号2
            //work9.PrdNumMngDiv = 1;					// 製番管理区分 0:無,1:有
            //work9.SupplierStock = 1.0;				// 仕入在庫数
            //work9.TrustCount = 0.0;					// 受託数
            //work9.StockState = 0;					// 在庫状態 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
            //work9.BfStockState = 10;				// 変更前在庫状態
            //work9.StockDiv = 0;						// 在庫区分 0:自社、1:受託
            //work9.GoodsCodeStatus = 0;				// 商品状態 0:正常,1:不良品
            work9.WarehouseCode = "0002";
            work9.WarehouseName = "倉庫02";

			list.Add(work9);

			StockAdjustResultWork work10 = new StockAdjustResultWork();

            work10.SectionCode = "03";				// 拠点コード
            work10.SectionGuideNm = "拠点03";		// 拠点ガイド名称
			work10.AcPaySlipCd = 0;					// 受払元伝票区分 10:仕入,11:受託,12:受計上,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,50:棚卸
			work10.AcPayTransCd = 0;				// 受払元取引区分 10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消
			work10.AdjustDate = TDateTime.LongDateToDateTime(20070316);		// 調整日付
			work10.StockAdjustSlipNo = 4000;		// 在庫調整伝票番号
			work10.StockAdjustRowNo = 3;			// 在庫調整行番号
            //work10.MakerCode = 30;					// メーカーコード
			work10.MakerName = "ソニー";			// メーカー名称
            //work10.GoodsCode = "50";				// 商品コード
			work10.GoodsName = "SO901_レッド";		// 商品名称
            //work10.ProductNumber = "S100000100";	// 製造番号
            //work10.BfProductNumber = "S10000000";	// 変更前製造番号
            //work10.StockTelNo1 = "090-4568-1000";	// 商品電話番号1
            //work10.BfStockTelNo1 = "090-5555-1111";	// 変更前商品電話番号1
            // ----- DEL 2011/11/15 xupz---------->>>>>
            //work10.StockInputCode = "30";				// 入力担当者コード
            //work10.StockInputName = "福岡 太郎";		// 入力担当者名称
            // ----- DEL 2011/11/15 xupz----------<<<<<
            // ----- ADD 2011/11/15 xupz---------->>>>>
            work10.StockAgentCode = "30";				// 仕入担当者コード
            work10.StockAgentName = "福岡 太郎";			// 仕入担当者名称
            // ----- ADD 2011/11/15 xupz----------<<<<<
            work10.StockUnitPriceFl = 45000;		// 仕入単価
            work10.BfStockUnitPriceFl = 35000;		// 変更前仕入単価
			work10.DtlNote = "明細備考・・・・";	// 明細備考
			work10.AdjustCount = -1.0;				// 調整数
			work10.SlipNote = "伝票備考・・・・";	// 伝票備考
            //work10.StockTelNo2 = "";				// 商品電話番号2
            //work10.BfStockTelNo2 = "";				// 変更前商品電話番号2
            //work10.PrdNumMngDiv = 1;				// 製番管理区分 0:無,1:有
            //work10.SupplierStock = 1.0;				// 仕入在庫数
            //work10.TrustCount = 0.0;				// 受託数
            //work10.StockState = 0;					// 在庫状態 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
            //work10.BfStockState = 10;				// 変更前在庫状態
            //work10.StockDiv = 0;					// 在庫区分 0:自社、1:受託
            //work10.GoodsCodeStatus = 0;				// 商品状態 0:正常,1:不良品
            work10.WarehouseCode = "0002";
            work10.WarehouseName = "倉庫02";

			list.Add(work10);

			StockAdjustResultWork work11 = new StockAdjustResultWork();

            work11.SectionCode = "03";				// 拠点コード
            work11.SectionGuideNm = "拠点03";		// 拠点ガイド名称
			work11.AcPaySlipCd = 0;					// 受払元伝票区分 10:仕入,11:受託,12:受計上,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,50:棚卸
			work11.AcPayTransCd = 0;				// 受払元取引区分 10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消
			work11.AdjustDate = TDateTime.LongDateToDateTime(20070315);		// 調整日付
			work11.StockAdjustSlipNo = 5000;		// 在庫調整伝票番号
			work11.StockAdjustRowNo = 0;			// 在庫調整行番号
            //work11.MakerCode = 30;					// メーカーコード
			work11.MakerName = "ソニー";			// メーカー名称
            //work11.GoodsCode = "50";				// 商品コード
			work11.GoodsName = "SO901_レッド";		// 商品名称
            //work11.ProductNumber = "S100000100";	// 製造番号
            //work11.BfProductNumber = "S10000000";	// 変更前製造番号
            //work11.StockTelNo1 = "090-4568-1000";	// 商品電話番号1
            //work11.BfStockTelNo1 = "090-5555-1111";	// 変更前商品電話番号1
            // ----- DEL 2011/11/15 xupz---------->>>>>
            //work11.StockInputCode = "30";				// 入力担当者コード
            //work11.StockInputName = "福岡 太郎";		// 入力担当者名称
            // ----- DEL 2011/11/15 xupz----------<<<<<
            // ----- ADD 2011/11/15 xupz---------->>>>>
            work11.StockAgentCode = "30";				// 仕入担当者コード
            work11.StockAgentName = "福岡 太郎";			// 仕入担当者名称
            // ----- ADD 2011/11/15 xupz----------<<<<<
            work11.StockUnitPriceFl = 45000;		// 仕入単価
            work11.BfStockUnitPriceFl = 35000;		// 変更前仕入単価
			work11.DtlNote = "明細備考・・・・";	// 明細備考
			work11.AdjustCount = -1.0;				// 調整数
			work11.SlipNote = "伝票備考・・・・";	// 伝票備考
            //work11.StockTelNo2 = "";				// 商品電話番号2
            //work11.BfStockTelNo2 = "";				// 変更前商品電話番号2
            //work11.PrdNumMngDiv = 1;				// 製番管理区分 0:無,1:有
            //work11.SupplierStock = 1.0;				// 仕入在庫数
            //work11.TrustCount = 0.0;				// 受託数
            //work11.StockState = 0;					// 在庫状態 0:在庫,10:受託中,20:委託中,30:売切,50:売上計上済,60:予約中,70:返品,80:抜出,81:消去
            //work11.BfStockState = 10;				// 変更前在庫状態
            //work11.StockDiv = 0;					// 在庫区分 0:自社、1:受託
            //work11.GoodsCodeStatus = 0;				// 商品状態 0:正常,1:不良品
            work11.WarehouseCode = "0002";
            work11.WarehouseName = "倉庫02";

			list.Add(work11);

			return (object)list;
		}
        
		# endregion

		/// <summary>
		/// 抽出条件展開処理
		/// </summary>
		/// <param name="confirmStockAdjustListCndtn">UI抽出条件クラス</param>
		/// <param name="stockAdjustCndtnWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>SortOrder</returns>
		/// <remarks>
		/// <br>Note       : リモート用の抽出条件に展開します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.14</br>
		/// </remarks>
		private int DevConfirmStockAdjustCndtn(ConfirmStockAdjustListCndtn confirmStockAdjustListCndtn, out StockAdjustCndtnWork stockAdjustCndtnWork, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			errMsg = string.Empty;
			stockAdjustCndtnWork = new StockAdjustCndtnWork();

			try
			{
				// 企業コード
                // 2007.10.04 修正 >>>>>>>>>>>>>>>>>>>>
                //stockAdjustCndtnWork.EnterPriseCode = confirmStockAdjustListCndtn.EnterpriseCode;
                stockAdjustCndtnWork.EnterpriseCode = confirmStockAdjustListCndtn.EnterpriseCode;
                // 2007.10.04 修正 <<<<<<<<<<<<<<<<<<<<

                // 2007.10.04 修正 >>>>>>>>>>>>>>>>>>>>
                //// 選択拠点
				//if (confirmStockAdjustListCndtn.SecCodeList.Length != 0)
				//{
				//	if (confirmStockAdjustListCndtn.IsSelectAllSection)
				//	{
				//		// 全社の時
				//		stockAdjustCndtnWork.SectionCodeList = null;
				//	}
				//	else
				//	{
				//		stockAdjustCndtnWork.SectionCodeList = confirmStockAdjustListCndtn.SecCodeList;
				//	}
				//}
                // 選択拠点
                if (confirmStockAdjustListCndtn.SectionCodeList.Length != 0)
                {
                    if (confirmStockAdjustListCndtn.IsSelectAllSection)
                    {
                    	// 全社の時
                        //stockAdjustCndtnWork.SectionCodeList = null;          // DEL 2008.07.04
                    }
                    else
                    {
                        //stockAdjustCndtnWork.SectionCodeList = confirmStockAdjustListCndtn.SectionCodeList;   // DEL 2008.07.04
                        stockAdjustCndtnWork.SectionCodes = confirmStockAdjustListCndtn.SectionCodeList;        // ADD 2008.07.04
                    }
                }
                // 2007.10.04 修正 <<<<<<<<<<<<<<<<<<<<
                else
				{
                    //stockAdjustCndtnWork.SectionCodeList = null;      // DEL 2008.07.04
				}

                /* ---DEL 2009/01/26 不具合対応[10505] ※未使用の為 ----------------------------------------------------->>>>>
				// 出力タイプ
				switch (confirmStockAdjustListCndtn.PrintDiv)
				{
                    // 2007.10.04 削除 >>>>>>>>>>>>>>>>>>>>
                    //// 半黒作成確認表
                    //case 0:
                    //	{
                    //		stockAdjustCndtnWork.AcPaySlipCd	= 41;		// 受払元伝票区分 41:半黒
                    //		stockAdjustCndtnWork.AcPayTransCd	= 10;		// 受払元取引区分 10:通常伝票
                    //		break;
                    //	}
                    //// 半黒解除確認表
                    //case 10:
                    //	{
                    //		stockAdjustCndtnWork.AcPaySlipCd	= 41;		// 受払元伝票区分 41:半黒
                    //		stockAdjustCndtnWork.AcPayTransCd	= 22;		// 受払元取引区分 22:解除
                    //		break;
                    //	}
                    // 2007.10.04 削除 <<<<<<<<<<<<<<<<<<<<
                    // 在庫数調整確認表
					case 20:
						{
							stockAdjustCndtnWork.AcPaySlipCd	= 40;		// 受払元伝票区分 40:調整
							stockAdjustCndtnWork.AcPayTransCd	= 30;		// 受払元取引区分 30:在庫数調整
							break;
						}
					// 原価訂正確認表
					case 30:
						{
							stockAdjustCndtnWork.AcPaySlipCd	= 40;		// 受払元伝票区分 40:調整
							stockAdjustCndtnWork.AcPayTransCd	= 31;		// 受払元取引区分 31:原価調整
							break;
						}
                    // 2007.10.04 削除 >>>>>>>>>>>>>>>>>>>>
                    //// 製造番号修正確認表
                    //case 40:
                    //	{
                    //		stockAdjustCndtnWork.AcPaySlipCd	= 40;		// 受払元伝票区分 40:調整
                    //		stockAdjustCndtnWork.AcPayTransCd	= 32;		// 受払元取引区分 32:製番調整
                    //		break;
                    //	}
                    //// 2007.07.13  S.Koga  ADD --------------------------------
                    //// 不良品確認表
                    //case 50:
                    //    {
                    //        stockAdjustCndtnWork.AcPaySlipCd = 40;		// 受払元伝票区分 40:調整
                    //        stockAdjustCndtnWork.AcPayTransCd = 33;		// 受払元取引区分 33:不良品
                    //        break;
                    //    }
                    //// --------------------------------------------------------
                    // 2007.10.04 削除 <<<<<<<<<<<<<<<<<<<<
                    // 2007.10.04 修正 >>>>>>>>>>>>>>>>>>>>
                    // 棚卸調整確認表
                    case 60:
                        {
                            stockAdjustCndtnWork.AcPaySlipCd = 50;		// 受払元伝票区分 50:棚卸
                            stockAdjustCndtnWork.AcPayTransCd = 40;		// 受払元取引区分 40:過不足更新
                            break;
                        }
                    // 2007.10.04 修正 <<<<<<<<<<<<<<<<<<<<
                }
                   ---DEL 2009/01/26 不具合対応[10505] ※未使用の為 -----------------------------------------------------<<<<< */

                //--- ADD 2008/07/07 ---------->>>>>
                //stockAdjustCndtnWork.AcPaySlipCd = confirmStockAdjustListCndtn.AcPaySlipCd;                         // 受払元伝票区分     //DEL 2009/01/26 不具合対応[10505]
                stockAdjustCndtnWork.AcPaySlipCds = confirmStockAdjustListCndtn.AcPaySlipCd;                        // 受払元伝票区分       //ADD 2009/01/26 不具合対応[10505]
                stockAdjustCndtnWork.AcPayTransCd = -1;                                                             // 受払元取引区分
                //--- ADD 2008/07/07 ----------<<<<<

                stockAdjustCndtnWork.St_AdjustDate			= confirmStockAdjustListCndtn.St_AdjustDate;			// 開始調整日付
				stockAdjustCndtnWork.Ed_AdjustDate			= confirmStockAdjustListCndtn.Ed_AdjustDate;			// 終了調整日付
                //--- ADD 2008.07.07 ---------->>>>>
                stockAdjustCndtnWork.St_InputDay            = confirmStockAdjustListCndtn.St_InputDay;  			// 開始入力日付
                stockAdjustCndtnWork.Ed_InputDay            = confirmStockAdjustListCndtn.Ed_InputDay;  			// 終了入力日付                
                //--- ADD 2008.07.07 ----------<<<<<
                //--- DEL 2008/07/04 ---------->>>>>
                //stockAdjustCndtnWork.St_StockAdjustSlipNo	= confirmStockAdjustListCndtn.St_StockAdjustSlipNo;		// 開始在庫調整伝票番号
                //stockAdjustCndtnWork.Ed_StockAdjustSlipNo	= confirmStockAdjustListCndtn.Ed_StockAdjustSlipNo;		// 終了在庫調整伝票番号
                //--- DEL 2008/07/04 ---------->>>>>
                // 2007.10.04 修正 >>>>>>>>>>>>>>>>>>>>
                //stockAdjustCndtnWork.St_MakerCode           = confirmStockAdjustListCndtn.St_MakerCode;				// 開始メーカーコード
				//stockAdjustCndtnWork.Ed_MakerCode			= confirmStockAdjustListCndtn.Ed_MakerCode;				// 終了メーカーコード
				//stockAdjustCndtnWork.St_GoodsCode			= confirmStockAdjustListCndtn.St_GoodsCode;				// 開始商品コード
				//stockAdjustCndtnWork.Ed_GoodsCode			= confirmStockAdjustListCndtn.Ed_GoodsCode;				// 終了商品コード
				//stockAdjustCndtnWork.St_ProductNumber		= confirmStockAdjustListCndtn.St_ProductNumber;			// 開始製造番号
				//stockAdjustCndtnWork.Ed_ProductNumber		= confirmStockAdjustListCndtn.Ed_ProductNumber;			// 終了製造番号
				//stockAdjustCndtnWork.St_StockTelNo1		= confirmStockAdjustListCndtn.St_StockTelNo1;			// 開始商品電話番号1
				//stockAdjustCndtnWork.Ed_StockTelNo1		= confirmStockAdjustListCndtn.Ed_StockTelNo1;			// 終了商品電話番号1
                //--- DEL 2008/07/04 ---------->>>>>
                //stockAdjustCndtnWork.St_GoodsMakerCd        = confirmStockAdjustListCndtn.St_GoodsMakerCd;			// 開始メーカーコード
                //stockAdjustCndtnWork.Ed_GoodsMakerCd        = confirmStockAdjustListCndtn.Ed_GoodsMakerCd;			// 終了メーカーコード
                //stockAdjustCndtnWork.St_GoodsNo             = confirmStockAdjustListCndtn.St_GoodsNo;				// 開始商品コード
                //stockAdjustCndtnWork.Ed_GoodsNo             = confirmStockAdjustListCndtn.Ed_GoodsNo;				// 終了商品コード
                //--- DEL 2008/07/04 ----------<<<<<
                // 2007.10.04 修正 <<<<<<<<<<<<<<<<<<<<
                stockAdjustCndtnWork.St_InputAgenCd			= confirmStockAdjustListCndtn.St_InputAgenCd;			// 開始入力担当者コード
                stockAdjustCndtnWork.Ed_InputAgenCd			= confirmStockAdjustListCndtn.Ed_InputAgenCd;			// 終了入力担当者コード
                // 2007.10.04 削除 >>>>>>>>>>>>>>>>>>>>
                //stockAdjustCndtnWork.PrdNumMngDiv           = -1;													// 製番管理区分
				//stockAdjustCndtnWork.StockState				= -1;													// 在庫状態
                // 2007.10.04 削除 <<<<<<<<<<<<<<<<<<<<
				stockAdjustCndtnWork.StockDiv				= -1;													// 在庫区分
                // 2007.10.04 削除 >>>>>>>>>>>>>>>>>>>>
				//stockAdjustCndtnWork.GoodsCodeStatus		= -1;													// 商品状態
                // 2007.10.04 削除 <<<<<<<<<<<<<<<<<<<<
                // 2008.03.03 追加 >>>>>>>>>>>>>>>>>>>>
                stockAdjustCndtnWork.St_WarehouseCode       = confirmStockAdjustListCndtn.St_WarehouseCode;         // 開始倉庫コード
                stockAdjustCndtnWork.Ed_WarehouseCode       = confirmStockAdjustListCndtn.Ed_WarehouseCode;         // 終了倉庫コード
                // 2008.03.03 追加 <<<<<<<<<<<<<<<<<<<<

            }
			catch (Exception ex)
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}

		/// <summary>
		/// 在庫調整確認データ展開処理
		/// </summary>
		/// <param name="confirmStockAdjustListCndtn">UI抽出条件クラス</param>
		/// <param name="stockAdjustDt">展開対象DataTable</param>
		/// <param name="stockAdjustWork">取得データ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 在庫調整確認データを展開します。</br>
		/// <br>Programmer : 97036 amami</br>
        /// <br>Date       : 2007.03.14</br>
        /// <br>Update Note: 2010/11/15 tianjw</br>
        /// <br>            ＰＭ．ＮＳ　機能改良Ｑ４</br>
		/// </remarks>
		private void DevStockAdjustData(ConfirmStockAdjustListCndtn confirmStockAdjustListCndtn, DataTable stockAdjustDt, ArrayList stockAdjustWork)
		{
			DataRow dr;

			foreach (StockAdjustResultWork stockAdjustResultWork in stockAdjustWork)
			{
				dr = stockAdjustDt.NewRow();

				#region 在庫調整データ展開

				// 拠点コード
				dr[MAZAI02054EA.ct_Col_SectionCode]				= stockAdjustResultWork.SectionCode;

				// 拠点ガイド名称
				dr[MAZAI02054EA.ct_Col_SectionGuideNm]			= stockAdjustResultWork.SectionGuideNm;

				// 受払元伝票区分
				dr[MAZAI02054EA.ct_Col_AcPaySlipCd]				= stockAdjustResultWork.AcPaySlipCd;

				// 受払元伝票名称
				dr[MAZAI02054EA.ct_Col_AcPaySlipNm]				= MAZAI02054EA.GetAcPaySlipNm(stockAdjustResultWork.AcPaySlipCd);

				// 受払元取引区分
				dr[MAZAI02054EA.ct_Col_AcPayTransCd]			= stockAdjustResultWork.AcPayTransCd;

				// 受払元取引名称
				dr[MAZAI02054EA.ct_Col_AcPayTransNm]			= MAZAI02054EA.GetAcPayTransCdNm(stockAdjustResultWork.AcPayTransCd);

				// 調整日付
				dr[MAZAI02054EA.ct_Col_AdjustDate]				= TDateTime.DateTimeToString(MAZAI02054EA.ct_DateFomat, stockAdjustResultWork.AdjustDate);

				// ソート用調整日付
				dr[MAZAI02054EA.ct_Col_Sort_AdjustDate]			= TDateTime.DateTimeToLongDate(stockAdjustResultWork.AdjustDate);

                // --- ADD 2008/09/26 -------------------------------->>>>>
                dr[MAZAI02054EA.ct_Col_InputDay]                = TDateTime.DateTimeToString(MAZAI02054EA.ct_DateFomat, stockAdjustResultWork.InputDay);
                // --- ADD 2008/09/26 --------------------------------<<<<<

				// 在庫調整伝票番号
				dr[MAZAI02054EA.ct_Col_StockAdjustSlipNo]		= stockAdjustResultWork.StockAdjustSlipNo;

				// 在庫調整行番号
				dr[MAZAI02054EA.ct_Col_StockAdjustRowNo]		= stockAdjustResultWork.StockAdjustRowNo;

				// メーカーコード
                // 2007.10.04 修正 >>>>>>>>>>>>>>>>>>>>
                //dr[MAZAI02054EA.ct_Col_MakerCode] = stockAdjustResultWork.MakerCode;
                dr[MAZAI02054EA.ct_Col_MakerCode] = stockAdjustResultWork.GoodsMakerCd;
                // 2007.10.04 修正 <<<<<<<<<<<<<<<<<<<<

				// メーカー名称
				dr[MAZAI02054EA.ct_Col_MakerName]				= stockAdjustResultWork.MakerName;

				// 商品コード
                // 2007.10.04 修正 >>>>>>>>>>>>>>>>>>>>
                //dr[MAZAI02054EA.ct_Col_GoodsCode] = stockAdjustResultWork.GoodsCode;
                dr[MAZAI02054EA.ct_Col_GoodsCode] = stockAdjustResultWork.GoodsNo;
                // 2007.10.04 修正 <<<<<<<<<<<<<<<<<<<<

				// 商品名称
				dr[MAZAI02054EA.ct_Col_GoodsName]				= stockAdjustResultWork.GoodsName;

                // 2007.10.04 削除 >>>>>>>>>>>>>>>>>>>>
                //// 製造番号
				//dr[MAZAI02054EA.ct_Col_ProductNumber]			= stockAdjustResultWork.ProductNumber;
                //
				//// 変更前製造番号
				//dr[MAZAI02054EA.ct_Col_BfProductNumber]			= stockAdjustResultWork.BfProductNumber;
                //
				//// 商品電話番号1
				//dr[MAZAI02054EA.ct_Col_StockTelNo1]				= stockAdjustResultWork.StockTelNo1;
                //
				//// 変更前商品電話番号1
				//dr[MAZAI02054EA.ct_Col_BfStockTelNo1]			= stockAdjustResultWork.BfStockTelNo1;
                // 2007.10.04 削除 <<<<<<<<<<<<<<<<<<<<

                // --- DEL 2008/09/11 -------------------------------->>>>>
                // 入力担当者コード
				//dr[MAZAI02054EA.ct_Col_InputAgenCd]				= stockAdjustResultWork.InputAgenCd;

				// 入力担当者名称
				//dr[MAZAI02054EA.ct_Col_InputAgenNm]				= stockAdjustResultWork.InputAgenNm;
                // --- DEL 2008/09/11 --------------------------------<<<<<
                // --- ADD 2008/09/11 -------------------------------->>>>>

                // ----- DEL 2011/11/15 xupz---------->>>>>
                //// 入力担当者コード
                //dr[MAZAI02054EA.ct_Col_InputAgenCd] = stockAdjustResultWork.StockInputCode;

                //// 入力担当者名称
                //dr[MAZAI02054EA.ct_Col_InputAgenNm] = stockAdjustResultWork.StockInputName;
                // ----- DEL 2011/11/15 xupz----------<<<<<

                // ----- ADD 2011/11/15 xupz---------->>>>>
                // 仕入担当者コード
                dr[MAZAI02054EA.ct_Col_StockAgenCd] = stockAdjustResultWork.StockAgentCode;

                // 仕入担当者名称	
                dr[MAZAI02054EA.ct_Col_StockAgenNm] = stockAdjustResultWork.StockAgentName;
                // ----- ADD 2011/11/15 xupz----------<<<<<

                // --- ADD 2008/09/11 --------------------------------<<<<<
                
				// 仕入単価
                // 2007.10.04 修正 >>>>>>>>>>>>>>>>>>>>
                //dr[MAZAI02054EA.ct_Col_StockUnitPrice]        = stockAdjustResultWork.StockUnitPrice;
                dr[MAZAI02054EA.ct_Col_StockUnitPrice]          = stockAdjustResultWork.StockUnitPriceFl;
                // 2007.10.04 修正 <<<<<<<<<<<<<<<<<<<<

				// 変更前仕入単価
                // 2007.10.04 修正 >>>>>>>>>>>>>>>>>>>>
                //dr[MAZAI02054EA.ct_Col_BfStockUnitPrice]      = stockAdjustResultWork.BfStockUnitPrice;
                dr[MAZAI02054EA.ct_Col_BfStockUnitPrice]        = stockAdjustResultWork.BfStockUnitPriceFl;
                // 2007.10.04 修正 <<<<<<<<<<<<<<<<<<<<

				// 調整数
				dr[MAZAI02054EA.ct_Col_AdjustCount]				= stockAdjustResultWork.AdjustCount;

				// 仕入単価(合計)
                /* --- DEL 2008/11/20 端数処理を端数処理区分に委ねる --------------------------------------------------------------------->>>>>
                // 2007.10.04 修正 >>>>>>>>>>>>>>>>>>>>
                //dr[MAZAI02054EA.ct_Col_TotalStockUnitPrice]   = stockAdjustResultWork.StockUnitPrice * stockAdjustResultWork.AdjustCount;
                dr[MAZAI02054EA.ct_Col_TotalStockUnitPrice]     = stockAdjustResultWork.StockUnitPriceFl * stockAdjustResultWork.AdjustCount;
                // 2007.10.04 修正 <<<<<<<<<<<<<<<<<<<<
                   --- DEL 2008/11/20 ----------------------------------------------------------------------------------------------------<<<<< */
                //dr[MAZAI02054EA.ct_Col_TotalStockUnitPrice] = this.FractionProc(stockAdjustResultWork.StockUnitPriceFl * stockAdjustResultWork.AdjustCount);      //ADD 2008/11/20　→　DEL 2009/03/09 不具合対応[12040]
                dr[MAZAI02054EA.ct_Col_TotalStockUnitPrice] = stockAdjustResultWork.StockPriceTaxExc;       //仕入金額                                              //ADD 2009/03/09 不具合対応[12040]

                if (stockAdjustResultWork.AdjustCount >= 0)
				{
					// 調整数(プラス)
					dr[MAZAI02054EA.ct_Col_AdjustCountPlus]				= stockAdjustResultWork.AdjustCount;

					// 仕入単価(合計)(プラス)
                    /* --- DEL 2008/11/20 端数処理を端数処理区分に委ねる --------------------------------------------------------------------->>>>>
                    // 2007.10.04 修正 >>>>>>>>>>>>>>>>>>>>
                    //dr[MAZAI02054EA.ct_Col_TotalStockUnitPricePlus] = stockAdjustResultWork.StockUnitPrice * stockAdjustResultWork.AdjustCount;
                    dr[MAZAI02054EA.ct_Col_TotalStockUnitPricePlus] = stockAdjustResultWork.StockUnitPriceFl * stockAdjustResultWork.AdjustCount;
                    // 2007.10.04 修正 <<<<<<<<<<<<<<<<<<<<
                       --- DEL 2008/11/20 ----------------------------------------------------------------------------------------------------<<<<< */
                    //dr[MAZAI02054EA.ct_Col_TotalStockUnitPricePlus] = this.FractionProc(stockAdjustResultWork.StockUnitPriceFl * stockAdjustResultWork.AdjustCount);  //ADD 2008/11/20　→　DEL 2009/03/09 不具合対応[12040]
                    dr[MAZAI02054EA.ct_Col_TotalStockUnitPricePlus] = stockAdjustResultWork.StockPriceTaxExc;                                                           //ADD 2009/03/09 不具合対応[12040]

					// 調整数(マイナス)
					dr[MAZAI02054EA.ct_Col_AdjustCountMinus]			= DBNull.Value;

					// 仕入単価(合計)(マイナス)
					dr[MAZAI02054EA.ct_Col_TotalStockUnitPriceMinus]	= DBNull.Value;
				}
				else
				{
					// 調整数(プラス)
					dr[MAZAI02054EA.ct_Col_AdjustCountPlus]				= DBNull.Value;

					// 仕入単価(合計)(プラス)
					dr[MAZAI02054EA.ct_Col_TotalStockUnitPricePlus]		= DBNull.Value;

					// 調整数(マイナス)
					dr[MAZAI02054EA.ct_Col_AdjustCountMinus]			= stockAdjustResultWork.AdjustCount;

					// 仕入単価(合計)(マイナス)
                    /* --- DEL 2008/11/20 端数処理を端数処理区分に委ねる --------------------------------------------------------------------->>>>>
                    // 2007.10.04 修正 >>>>>>>>>>>>>>>>>>>>
                    //dr[MAZAI02054EA.ct_Col_TotalStockUnitPriceMinus] = stockAdjustResultWork.StockUnitPrice * stockAdjustResultWork.AdjustCount;
                    dr[MAZAI02054EA.ct_Col_TotalStockUnitPriceMinus] = stockAdjustResultWork.StockUnitPriceFl * stockAdjustResultWork.AdjustCount;
                    // 2007.10.04 修正 <<<<<<<<<<<<<<<<<<<<
                       --- DEL 2008/11/20 ----------------------------------------------------------------------------------------------------<<<<< */
                    //dr[MAZAI02054EA.ct_Col_TotalStockUnitPriceMinus] = this.FractionProc(stockAdjustResultWork.StockUnitPriceFl * stockAdjustResultWork.AdjustCount); //ADD 2008/11/20　→　DEL 2009/03/09 不具合対応[12040]
                    dr[MAZAI02054EA.ct_Col_TotalStockUnitPriceMinus] = stockAdjustResultWork.StockPriceTaxExc;                                                          //ADD 2009/03/09 不具合対応[12040]
                }

				// 明細備考
				dr[MAZAI02054EA.ct_Col_DtlNote]					= stockAdjustResultWork.DtlNote;

				// 伝票備考
				dr[MAZAI02054EA.ct_Col_SlipNote]				= stockAdjustResultWork.SlipNote;

                // 2007.10.04 削除 >>>>>>>>>>>>>>>>>>>>
                //// 商品電話番号2
                //dr[MAZAI02054EA.ct_Col_StockTelNo2]				= stockAdjustResultWork.StockTelNo2;
                //
                //// 変更前商品電話番号2
                //dr[MAZAI02054EA.ct_Col_BfStockTelNo2]			= stockAdjustResultWork.BfStockTelNo2;
                //
                //// 製番管理区分
                //dr[MAZAI02054EA.ct_Col_PrdNumMngDiv]			= stockAdjustResultWork.PrdNumMngDiv;
                //
                //// 製番管理区分名称
                //dr[MAZAI02054EA.ct_Col_PrdNumMngDivNm]			= MAZAI02054EA.GetPrdNumMngDivNm(stockAdjustResultWork.PrdNumMngDiv);
                // 2007.10.04 削除 <<<<<<<<<<<<<<<<<<<<

                // --- DEL 2008/09/11 -------------------------------->>>>>
				// 仕入在庫数
				//dr[MAZAI02054EA.ct_Col_SupplierStock]			= stockAdjustResultWork.SupplierStock;

				// 受託数
				//dr[MAZAI02054EA.ct_Col_TrustCount]				= stockAdjustResultWork.TrustCount;
                // --- DEL 2008/09/11 --------------------------------<<<<<

                // 2007.10.04 削除 >>>>>>>>>>>>>>>>>>>>
                //// 在庫状態
                //dr[MAZAI02054EA.ct_Col_StockState]				= stockAdjustResultWork.StockState;
                //
                //// 在庫状態名称
                //dr[MAZAI02054EA.ct_Col_StockStateNm]			= MAZAI02054EA.GetStockStateNm(stockAdjustResultWork.StockState);
                //
                //// 変更前在庫状態
                //dr[MAZAI02054EA.ct_Col_BfStockState]			= stockAdjustResultWork.BfStockState;
                //
                //// 変更前在庫状態名称
                //dr[MAZAI02054EA.ct_Col_BfStockStateNm]			= MAZAI02054EA.GetStockStateNm(stockAdjustResultWork.BfStockState);
                // 2007.10.04 削除 <<<<<<<<<<<<<<<<<<<<

                // --- DEL 2008/09/11 -------------------------------->>>>>
				// 在庫区分
				//dr[MAZAI02054EA.ct_Col_StockDiv]				= stockAdjustResultWork.StockDiv;
                
				// 在庫区分名称
				//dr[MAZAI02054EA.ct_Col_StockDivNm]				= MAZAI02054EA.GetStockDivNm(stockAdjustResultWork.StockDiv);
                // --- DEL 2008/09/11 -------------------------------->>>>>
                // 2007.10.04 削除 >>>>>>>>>>>>>>>>>>>>
                //// 商品状態
                //dr[MAZAI02054EA.ct_Col_GoodsCodeStatus]			= stockAdjustResultWork.GoodsCodeStatus;
                //
                //// 商品状態名称
                //dr[MAZAI02054EA.ct_Col_GoodsCodeStatusNm]		= MAZAI02054EA.GetGoodsCodeStatusNm(stockAdjustResultWork.GoodsCodeStatus);
                // 2007.10.04 削除 <<<<<<<<<<<<<<<<<<<<

                // 2007.10.04 追加 >>>>>>>>>>>>>>>>>>>>
                // 倉庫コード
                dr[MAZAI02054EA.ct_Col_WarehouseCode]           = stockAdjustResultWork.WarehouseCode;

                // 倉庫名称
                dr[MAZAI02054EA.ct_Col_WarehouseName]           = stockAdjustResultWork.WarehouseName;

                // 棚番
                dr[MAZAI02054EA.ct_Col_WarehouseShelfNo]        = stockAdjustResultWork.WarehouseShelfNo;
                // 2007.10.04 追加 <<<<<<<<<<<<<<<<<<<<

                // -------- ADD 2010/11/15 -------------------->>>>>
                // 品番
                dr[MAZAI02054EA.ct_Col_GoodsNo]                 = stockAdjustResultWork.GoodsNo;
                // -------- ADD 2010/11/15 --------------------<<<<<

                //--- ADD 2008/07/04 ---------->>>>>
                // 標準価格(定価)
                dr[MAZAI02054EA.ct_Col_ListPrice]               = stockAdjustResultWork.ListPriceFl;
                //--- ADD 2008/07/04 ----------<<<<<

                // 2007.10.04 削除 >>>>>>>>>>>>>>>>>>>>
                //// 出力タイプにより項目を作成
				//switch (confirmStockAdjustListCndtn.PrintDiv)
				//{
				//	// --- 半黒作成確認表 --- //
                //    case 0:
                //    // 2007.07.13  S.Koga  ADD --------------------------------
                //    // --- 不良品確認表 --- //
                //    case 50:
                //    // --------------------------------------------------------
                //        {
				//			// 製造番号
				//			dr[MAZAI02054EA.ct_Col_FreeColumn1] = stockAdjustResultWork.ProductNumber;
				//			dr[MAZAI02054EA.ct_Col_FreeColumn1Nm] = "製造番号";
				//			// 商品電話番号
				//			dr[MAZAI02054EA.ct_Col_FreeColumn2] = stockAdjustResultWork.StockTelNo1;
				//			dr[MAZAI02054EA.ct_Col_FreeColumn2Nm] = "携帯電話番号";
				//			break;
				//		}
				//	// --- 半黒解除確認表 --- //
				//	case 10:
				//		{
				//			// 製造番号
				//			dr[MAZAI02054EA.ct_Col_FreeColumn1] = stockAdjustResultWork.ProductNumber;
				//			dr[MAZAI02054EA.ct_Col_FreeColumn1Nm] = "製造番号";
				//			// 変更前商品電話番号1
				//			dr[MAZAI02054EA.ct_Col_FreeColumn2] = stockAdjustResultWork.BfStockTelNo1;
				//			dr[MAZAI02054EA.ct_Col_FreeColumn2Nm] = "携帯電話番号(解除前)";
				//			break;
				//		}
				//	// --- 製造番号修正確認表 --- //
				//	case 40:
				//		{
				//			// 変更前製造番号
				//			dr[MAZAI02054EA.ct_Col_FreeColumn1] = stockAdjustResultWork.BfProductNumber;
				//			dr[MAZAI02054EA.ct_Col_FreeColumn1Nm] = "製造番号(修正前)";
                //			// 製造番号
                //			dr[MAZAI02054EA.ct_Col_FreeColumn2] = stockAdjustResultWork.ProductNumber;
                //			dr[MAZAI02054EA.ct_Col_FreeColumn2Nm] = "製造番号(修正後)";
                //			break;
                //		}
                //}
                // 2007.10.04 削除 <<<<<<<<<<<<<<<<<<<<
                #endregion

				// TableにAdd
				stockAdjustDt.Rows.Add(dr);

			}
		}

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
		# endregion
	}
}

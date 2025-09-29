//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫入出庫確認表
// プログラム概要   : 在庫入出庫確認表で使用するデータを取得する。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鈴木　正臣
// 作 成 日  2007/09/19  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/12/09  修正内容 : バグ修正、仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/12/11  修正内容 : 伝票区分「13:在庫仕入」追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/12/15  修正内容 : 1.コンバートデータで伝票区分「31:移動入荷」の
//                                    入出庫先表示時、見切れるバグ修正
//                                  2.入庫金額、出庫金額追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/01/08  修正内容 : 単価を入庫単価、出庫単価に分割
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/01/23  修正内容 : 不具合対応[6581]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/01/28  修正内容 : 不具合対応[10622]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/09  修正内容 : 不具合対応[12240][12241][12244]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/10  修正内容 : 不具合対応[12239]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/04/07  修正内容 : 不具合対応[12997]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/05/26  修正内容 : 不具合対応[12856]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : liyp
// 修 正 日  2010/11/15  修正内容 : PM.NS 機能改良Ｑ４
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : yangmj
// 修 正 日  2010/12/09  修正内容 : redmine #17944 在庫入出庫確認表の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI厚川 宏
// 修 正 日  2013/01/15  修正内容 :  管理No.541 買掛オプション追加対応
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
using Broadleaf.Library.Collections;
using Broadleaf.Application.Resources; // ---ADD 2013/01/15

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// 在庫受払確認表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 在庫受払確認表で使用するデータを取得する。</br>
    /// <br>Programmer   : 22018 鈴木 正臣</br>
    /// <br>Date         : 2007.09.19</br>
	/// <br>Updatenote   : 2008/12/09 照田 貴志　バグ修正、仕様変更対応</br>
    /// <br>             : 2008/12/11 照田 貴志　伝票区分「13:在庫仕入」追加</br>
    /// <br>             : 2008/12/15 照田 貴志　</br>
    /// <br>                ・コンバートデータで伝票区分「31:移動入荷」の入出庫先表示時、見切れるバグ修正</br>
    /// <br>                ・入庫金額、出庫金額追加</br>
    /// <br>             : 2009/01/08 照田 貴志　単価を入庫単価、出庫単価に分割</br>
    /// <br>             : 2009/01/23 照田 貴志　不具合対応[6581]</br>
    /// <br>             : 2009/01/28 照田 貴志　不具合対応[10622]</br>
    /// <br>             : 2009/03/09 照田 貴志　不具合対応[12240][12241][12244]</br>
    /// <br>             : 2009/03/10 照田 貴志　不具合対応[12239]</br>
    /// <br>             : 2009/04/07 照田 貴志　不具合対応[12997]</br>
    /// <br>             : 2009/04/07 照田 貴志　不具合対応[12856]</br>
    /// <br>UpdateNote   : 2010/11/15 yangmj　機能改良Ｑ４</br>
    /// <br>UpdateNote   : 2010/12/09 yangmj</br>
    /// <br>               redmine #17944 在庫入出庫確認表の修正</br>
    /// </remarks>
	public class StockAcPayListAcs
	{
		#region ■ Constructor
		/// <summary>
		/// 在庫受払確認表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫受払確認表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.09.19</br>
		/// </remarks>
		public StockAcPayListAcs()
		{
            this._iStockAcPayHisSearchDB = (IStockAcPayHisSearchDB)MediationStockAcPayHisSearchDB.GetStockAcPayHisSearchDB();

            this._acPaySlipNmDic = CreateAcPaySlipNmDictionary();
            this._acPayTransNmDic = CreateAcPayTransNmDictionary();

            // ---ADD 2009/05/26 不具合対応[12856] ----------------------------------------------------------------->>>>>
            // 入荷数を印字する伝票区分のリスト
            // 10：仕入、11：入荷、13：在庫仕入、31：移動入荷、40：調整、42：マスタメンテ、50：棚卸、60：組立、61：分解、70：補充入庫
            this._stockAcPaySlipOfArrivalList = new List<int>();
            this._stockAcPaySlipOfArrivalList.AddRange(new int[] { 10, 11, 13, 31, 40, 42, 50, 60, 61, 70 });
            // 出荷数を印字する伝票区分のリスト
            // 12：受計上、20：売上、21：売計上、22：出荷、23：売切、30：移動出荷、41：半黒、71：補充出庫
            this._stockAcPaySlipOfShipmentList = new List<int>();
            this._stockAcPaySlipOfShipmentList.AddRange(new int[] { 12, 20, 21, 22, 23, 30, 41, 71 });
            // ---ADD 2009/05/26 不具合対応[12856] -----------------------------------------------------------------<<<<<
        }

		/// <summary>
		/// 在庫受払確認表アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 在庫受払確認表アクセスクラスの初期化を行う。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.09.19</br>
		/// </remarks>
        static StockAcPayListAcs ()
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
        IStockAcPayHisSearchDB _iStockAcPayHisSearchDB;
		private DataTable _stockAcPayListDt;			// 印刷DataTable
		private DataView _stockAcPayListDataView;	// 印刷DataView
        private Dictionary<int, string> _acPaySlipNmDic;    // 伝票区分名称ディクショナリ
        private Dictionary<int, string> _acPayTransNmDic;   // 取引区分名称ディクショナリ
        private List<int> _stockAcPaySlipOfArrivalList;     // 入荷数を印字する伝票区分のリスト //ADD 2009/05/26 不具合対応[12856]
        private List<int> _stockAcPaySlipOfShipmentList;    // 出荷数を印字する伝票区分のリスト //ADD 2009/05/26 不具合対応[12856]
		#endregion ■ Private Member

		#region ■ Public Property
		/// <summary>
		/// 印刷データセット(読み取り専用)
		/// </summary>
		public DataView StockAcPayListDataView
		{
			get{ return this._stockAcPayListDataView; }
		}
		#endregion ■ Public Property

		#region ■ Public Method
		#region ◆ 出力データ取得
		#region ◎ 入金データ取得
		/// <summary>
		/// データ取得
		/// </summary>
		/// <param name="stockAcPayListCndtn">抽出条件</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷するデータを取得する。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.09.19</br>
		/// </remarks>
        public int SearchMain ( StockAcPayListCndtn stockAcPayListCndtn, out string errMsg )
		{
            return this.SearchProc(stockAcPayListCndtn, out errMsg);
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
		/// <param name="stockAcPayListCndtn"></param>
		/// <param name="errMsg"></param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 印刷する在庫移動データを取得する。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.09.19</br>
		/// </remarks>
        private int SearchProc ( StockAcPayListCndtn stockAcPayListCndtn, out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = "";

			try
			{
				// DataTable Create ----------------------------------------------------------
				DCZAI02204EA.CreateDataTable( ref this._stockAcPayListDt );
				
				StockAcPayHisSearchParaWork stockAcPayHisSearchParaWork = new StockAcPayHisSearchParaWork();
				// 抽出条件展開  --------------------------------------------------------------
				status = this.DevStockMoveCndtn( stockAcPayListCndtn, out stockAcPayHisSearchParaWork, out errMsg );
				if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
				{
					return status;
				}

				// データ取得  ----------------------------------------------------------------
				object retWorkList = null;
                status = this._iStockAcPayHisSearchDB.Search( out retWorkList, stockAcPayHisSearchParaWork, 0, ConstantManagement.LogicalMode.GetData0);

                //--- TEST ---------->>>>>
                //retWorkList = this.GetTestData();
                //status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //--- TEST ----------<<<<<
				switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						// データ展開処理
						DevStockMoveData( stockAcPayListCndtn, (CustomSerializeArrayList)retWorkList );
						status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
						break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
					default:
						errMsg = "在庫受払履歴データの取得に失敗しました。";
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
        //private object GetTestData()
        //{
        //    ArrayList list = new ArrayList();
        //    CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

        //    for (int a = 0; a < 35; a++)
        //    {
        //        StockAcPayHisSearchRetWork work = new StockAcPayHisSearchRetWork();

        //        work.GoodsMakerCd = 10;					// メーカーコード
        //        work.MakerName = "トヨタ";		        // メーカー名称
        //        work.GoodsNo = "20";					// 商品コード
        //        work.GoodsName = "12345";   			// 商品名称
        //        work.IoGoodsDay = TDateTime.LongDateToDateTime(20080702);   // 入出荷日
        //        work.AcPaySlipNum = "000000001";        // 受払元伝票番号
        //        work.AcPaySlipRowNo = 1;                // 受払元行番号
        //        work.AcPayTransCd = 40;					// 受払元取引区分 10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,90:取消

        //        work.ArrivalCnt = 10001 + a;            // 入荷数
        //        work.ShipmentCnt = 10000 + a;           // 出荷数
        //        work.ListPriceTaxExcFl = 10000 + a;     // 定価（税抜，浮動）
        //        work.StockUnitPriceFl = 1000 + a;       // 仕入単価（税抜，浮動）

        //        if (a >= 0 && a < 5)
        //        {
        //            work.SectionCode = "01";				// 拠点コード 
        //            work.SectionGuideNm = "拠点01";  		// 拠点ガイド名称
        //            work.WarehouseCode = "0001";            // 倉庫コード
        //            work.WarehouseName = "倉庫01";          // 倉庫名称
        //            work.AcPaySlipCd = 10;					// 受払元伝票区分 10:仕入,11:受託,12:受計上,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,50:棚卸
        //        }
        //        else if (a >= 5 && a < 10)
        //        {
        //            work.SectionCode = "01";				// 拠点コード
        //            work.SectionGuideNm = "拠点02";  		// 拠点ガイド名称
        //            work.WarehouseCode = "0002";            // 倉庫コード
        //            work.WarehouseName = "倉庫02";          // 倉庫名称
        //            work.AcPaySlipCd = 20;					// 受払元伝票区分 10:仕入,11:受託,12:受計上,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,50:棚卸
        //        }
        //        else if (a >= 10 && a < 15)
        //        {
        //            work.SectionCode = "02";				// 拠点コード
        //            work.SectionGuideNm = "拠点02";  		// 拠点ガイド名称
        //            work.WarehouseCode = "0001";            // 倉庫コード
        //            work.WarehouseName = "倉庫01";          // 倉庫名称
        //            work.AcPaySlipCd = 20;					// 受払元伝票区分 10:仕入,11:受託,12:受計上,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,50:棚卸
        //        }
        //        else if (a >= 15 && a < 20)
        //        {
        //            work.SectionCode = "02";				// 拠点コード
        //            work.SectionGuideNm = "拠点02";  		// 拠点ガイド名称
        //            work.WarehouseCode = "0002";            // 倉庫コード
        //            work.WarehouseName = "倉庫02";          // 倉庫名称
        //            work.AcPaySlipCd = 10;					// 受払元伝票区分 10:仕入,11:受託,12:受計上,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,50:棚卸
        //        }
        //        else if (a >= 20 && a < 25)
        //        {
        //            work.SectionCode = "03";				// 拠点コード
        //            work.SectionGuideNm = "拠点03";  		// 拠点ガイド名称
        //            work.WarehouseCode = "0001";            // 倉庫コード
        //            work.WarehouseName = "倉庫01";          // 倉庫名称
        //            work.AcPaySlipCd = 42;					// 受払元伝票区分 10:仕入,11:受託,12:受計上,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,50:棚卸
        //        }
        //        else if (a >= 25 && a < 30)
        //        {
        //            work.SectionCode = "03";				// 拠点コード
        //            work.SectionGuideNm = "拠点03";  		// 拠点ガイド名称
        //            work.WarehouseCode = "0002";            // 倉庫コード
        //            work.WarehouseName = "倉庫02";          // 倉庫名称
        //            work.AcPaySlipCd = 30;					// 受払元伝票区分 10:仕入,11:受託,12:受計上,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,50:棚卸
        //            work.AfSectionCode = "99";
        //            work.AfSectionGuideNm = "拠点９９９９";
        //            work.AfEnterWarehCode = "9999";
        //            work.AfEnterWarehName = "倉庫９９９９９９９９９９９９９９９９９９";
        //        }
        //        else if (a >= 30 && a < 35)
        //        {
        //            work.SectionCode = "03";				// 拠点コード
        //            work.SectionGuideNm = "拠点03";  		// 拠点ガイド名称
        //            work.WarehouseCode = "0003";            // 倉庫コード
        //            work.WarehouseName = "倉庫03";          // 倉庫名称
        //            work.AcPaySlipCd = 10;					// 受払元伝票区分 10:仕入,11:受託,12:受計上,20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,50:棚卸
        //        }

        //        list.Add(work);
        //    }

        //    customSerializeArrayList.Add(list);

        //    return (object)customSerializeArrayList;
        //}
        # endregion

		#region ◆ データ展開処理
		#region ◎ 抽出条件展開処理
		/// <summary>
		/// 抽出条件展開処理
		/// </summary>
		/// <param name="stockAcPayListCndtn">UI抽出条件クラス</param>
		/// <param name="stockAcPayHisSearchParaWork">リモート抽出条件クラス</param>
		/// <param name="errMsg">errMsg</param>
		/// <returns>Status</returns>
        /// <br>UpdateNote : 2010/11/15 yangmj　機能改良Ｑ４</br>
		/// <br>UpdateNote : 2013/01/15 FSI厚川 宏　管理No.541 買掛オプション追加対応</br>
        private int DevStockMoveCndtn(StockAcPayListCndtn stockAcPayListCndtn, out StockAcPayHisSearchParaWork stockAcPayHisSearchParaWork, out string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			errMsg = string.Empty;
			stockAcPayHisSearchParaWork = new StockAcPayHisSearchParaWork();
			try
			{
                stockAcPayHisSearchParaWork.EnterpriseCode = stockAcPayListCndtn.EnterpriseCode;  // 企業コード
				// 抽出条件パラメータセット
				if ( stockAcPayListCndtn.SectionCodes.Length != 0 )
				{
				    if ( stockAcPayListCndtn.IsSelectAllSection )
				    {
				        // 全社の時
                        stockAcPayHisSearchParaWork.SectionCodes = null;
				    }
				    else
				    {
                        stockAcPayHisSearchParaWork.SectionCodes = stockAcPayListCndtn.SectionCodes;
				    }
				}
				else
				{
                    stockAcPayHisSearchParaWork.SectionCodes = null;
				}

                //stockAcPayHisSearchParaWork.ValidDivCd = stockAcPayListCndtn.ValidDivCd; // 有効区分  // DEL 2008/07/02
                stockAcPayHisSearchParaWork.St_IoGoodsDay = GetLongDateFromDateTime(stockAcPayListCndtn.St_IoGoodsDay); // 開始入出荷日
                stockAcPayHisSearchParaWork.Ed_IoGoodsDay = GetLongDateFromDateTime(stockAcPayListCndtn.Ed_IoGoodsDay); // 終了入出荷日
                stockAcPayHisSearchParaWork.St_AddUpADate = GetLongDateFromDateTime(stockAcPayListCndtn.St_AddUpADate); // 開始計上日付
                stockAcPayHisSearchParaWork.Ed_AddUpADate = GetLongDateFromDateTime(stockAcPayListCndtn.Ed_AddUpADate); // 終了計上日付
                stockAcPayHisSearchParaWork.AcPaySlipCd = stockAcPayListCndtn.AcPaySlipCd; // 受払元伝票区分
                stockAcPayHisSearchParaWork.St_WarehouseCode = stockAcPayListCndtn.St_WarehouseCode; // 開始倉庫コード
                stockAcPayHisSearchParaWork.Ed_WarehouseCode = stockAcPayListCndtn.Ed_WarehouseCode; // 終了倉庫コード
                stockAcPayHisSearchParaWork.St_GoodsMakerCd = stockAcPayListCndtn.St_GoodsMakerCd; // 開始商品メーカーコード
                stockAcPayHisSearchParaWork.Ed_GoodsMakerCd = stockAcPayListCndtn.Ed_GoodsMakerCd; // 終了商品メーカーコード
                stockAcPayHisSearchParaWork.St_AcPaySlipNum = stockAcPayListCndtn.St_AcPaySlipNum; // 開始受払元伝票番号
                stockAcPayHisSearchParaWork.Ed_AcPaySlipNum = stockAcPayListCndtn.Ed_AcPaySlipNum; // 終了受払元伝票番号
                stockAcPayHisSearchParaWork.St_GoodsNo = stockAcPayListCndtn.St_GoodsNo; // 開始商品番号
                stockAcPayHisSearchParaWork.Ed_GoodsNo = stockAcPayListCndtn.Ed_GoodsNo; // 終了商品番号
                
                // ---ADD 2010/11/15 ------------------------>>>>>
                stockAcPayHisSearchParaWork.St_detInputDay = stockAcPayListCndtn.St_detInputDay;
                stockAcPayHisSearchParaWork.Ed_detInputDay = stockAcPayListCndtn.Ed_detInputDay;
                stockAcPayHisSearchParaWork.GroupCnt = stockAcPayListCndtn.GroupCnt;
                stockAcPayHisSearchParaWork.Sort = stockAcPayListCndtn.Sort;
                stockAcPayHisSearchParaWork.SlipKuben = stockAcPayListCndtn.SlipKuben;
                // ---ADD 2010/11/15 ------------------------<<<<<

                // ---ADD 2013/01/15 ------------------------>>>>>
                stockAcPayHisSearchParaWork.HasStkPay = HasStockingPayment(); //買掛オプション
                // ---ADD 2013/01/15 ------------------------<<<<<

			}
			catch ( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
        /// <summary>
        /// YYYYMMDD日付取得処理 (但しDateTime.MinValueならば0に変換)
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private int GetLongDateFromDateTime ( DateTime dateTime )
        {
            if ( dateTime == DateTime.MinValue )
            {
                return 0;
            }
            else
            {
                return ( dateTime.Year * 10000 ) + ( dateTime.Month * 100 ) + dateTime.Day;
            }
        }
		#endregion

		#region ◎ 取得データ展開処理
		/// <summary>
		/// 取得データ展開処理
		/// </summary>
		/// <param name="stockAcPayListCndtn">UI抽出条件クラス</param>
        /// <param name="retList">取得データ</param>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : 取得データを展開する。</br>
	    /// <br>Programmer : 22018 鈴木 正臣</br>
	    /// <br>Date       : 2007.09.19</br>
        /// <br>Update Note: 2010/11/15 liyp</br>
        /// <br>            ＰＭ．ＮＳ　機能改良Ｑ４</br>
        /// <br>Update Note: 2010/12/09 yangmj</br>
        /// <br>             redmine #17944 在庫入出庫確認表の修正</br>
        /// </remarks>
		private void DevStockMoveData ( StockAcPayListCndtn stockAcPayListCndtn, CustomSerializeArrayList retList )
		{
			DataRow dr;

            ArrayList workList;

            if ( retList.Count > 0 && retList[0] is ArrayList )
            {
                workList = (ArrayList)retList[0];
            }
            else
            {
                workList = new ArrayList();
            }

            foreach ( StockAcPayHisSearchRetWork stockAcPayHisSearchRetWork in workList )
			{
				dr = this._stockAcPayListDt.NewRow();
				// 取得データ展開
				#region 取得データ展開
                //dr[DCZAI02204EA.ct_Col_SectionCode] = stockAcPayHisSearchRetWork.SectionCode;       // 拠点コード             //DEL 2009/04/07 不具合対応[12997]
                //dr[DCZAI02204EA.ct_Col_SectionGuideNm] = stockAcPayHisSearchRetWork.SectionGuideNm; // 拠点ガイド名称         //DEL 2009/04/07 不具合対応[12997]
                dr[DCZAI02204EA.ct_Col_WarehouseCode] = stockAcPayHisSearchRetWork.WarehouseCode;   // 倉庫コード
                dr[DCZAI02204EA.ct_Col_WarehouseName] = stockAcPayHisSearchRetWork.WarehouseName;   // 倉庫名称
                dr[DCZAI02204EA.ct_Col_GoodsMakerCd] = stockAcPayHisSearchRetWork.GoodsMakerCd;     // 商品メーカーコード
                dr[DCZAI02204EA.ct_Col_MakerName] = stockAcPayHisSearchRetWork.MakerName;           // メーカー名称
                dr[DCZAI02204EA.ct_Col_GoodsNo] = stockAcPayHisSearchRetWork.GoodsNo;               // 商品番号
                dr[DCZAI02204EA.ct_Col_GoodsName] = stockAcPayHisSearchRetWork.GoodsName;           // 商品名称
                //dr[DCZAI02204EA.ct_Col_IoGoodsDay] = stockAcPayHisSearchRetWork.IoGoodsDay.ToString("yy/MM/dd"); // 入出荷日  //DEL 2009/03/09 不具合対応[12240]
                // ---ADD 2009/03/09 不具合対応[12240] ------------------------------------------------------>>>>>
                if (((stockAcPayHisSearchRetWork.AcPaySlipCd == 10) || (stockAcPayHisSearchRetWork.AcPaySlipCd == 20)) &&
                    (stockAcPayHisSearchRetWork.IoGoodsDay == DateTime.MinValue))
                {
                    dr[DCZAI02204EA.ct_Col_IoGoodsDay] = stockAcPayHisSearchRetWork.AddUpADate.ToString("yy/MM/dd"); // 計上日
                }
                else
                {
                    dr[DCZAI02204EA.ct_Col_IoGoodsDay] = stockAcPayHisSearchRetWork.IoGoodsDay.ToString("yy/MM/dd"); // 入出荷日
                }
                // ---ADD 2009/03/09 不具合対応[12240] ------------------------------------------------------>>>>>

                //dr[DCZAI02204EA.ct_Col_AcPaySlipNum] = stockAcPayHisSearchRetWork.AcPaySlipNum;     // 受払元伝票番号         //DEL 2009/03/09 不具合対応[12244]
                // ---ADD 2009/03/09 不具合対応[12244] ------------------------------------------------------>>>>>
                try
                {
                    dr[DCZAI02204EA.ct_Col_AcPaySlipNum] = int.Parse(stockAcPayHisSearchRetWork.AcPaySlipNum).ToString("000000000");
                }
                catch
                {
                    dr[DCZAI02204EA.ct_Col_AcPaySlipNum] = stockAcPayHisSearchRetWork.AcPaySlipNum;     // 受払元伝票番号
                }
                // ---ADD 2009/03/09 不具合対応[12244] ------------------------------------------------------<<<<<

                dr[DCZAI02204EA.ct_Col_AcPaySlipRowNo] = stockAcPayHisSearchRetWork.AcPaySlipRowNo; // 受払元行番号
                dr[DCZAI02204EA.ct_Col_AcPaySlipCd] = stockAcPayHisSearchRetWork.AcPaySlipCd;       // 受払元伝票区分
                dr[DCZAI02204EA.ct_Col_AcPayTransCd] = stockAcPayHisSearchRetWork.AcPayTransCd;     // 受払元取引区分
                dr[DCZAI02204EA.ct_Col_AcPayOtherPartyCd] = string.Empty;                           // 受払先コード（印刷用）
                dr[DCZAI02204EA.ct_Col_AcPayOtherPartyNm] = string.Empty;                           // 受払先名称（印刷用）
                

                // ---UPD 2010/11/15 ------------------------------------------------------------------------>>>>>
                //dr[DCZAI02204EA.ct_Col_ArrivalCnt] = stockAcPayHisSearchRetWork.ArrivalCnt;         // 入荷数
                //sdr[DCZAI02204EA.ct_Col_ShipmentCnt] = stockAcPayHisSearchRetWork.ShipmentCnt;       // 出荷数
                // 入荷数・出荷数
                // ※受払元伝票区分が10:仕入 or 20:売上 且つ入出荷日に値がセットされていない場合、()で囲んで表示し、
                //   繰越数の計算対象外とする
                if (((stockAcPayHisSearchRetWork.AcPaySlipCd == 10) || (stockAcPayHisSearchRetWork.AcPaySlipCd == 20)) &&
                    (stockAcPayHisSearchRetWork.IoGoodsDay == DateTime.MinValue))
                // ---ADD 2009/02/09 不具合対応[11007] -------------------------------------------------<<<<<
                {
                    dr[DCZAI02204EA.ct_Col_ArrivalCnt] = string.Format("({0}", stockAcPayHisSearchRetWork.ArrivalCnt.ToString("#,##0.00"));    // 入荷数
                    dr[DCZAI02204EA.ct_Col_ShipmentCnt] = string.Format("({0}", stockAcPayHisSearchRetWork.ShipmentCnt.ToString("#,##0.00")); // 出荷数
                    dr[DCZAI02204EA.ct_Col_Bracker] = ")";
                }
                else
                {
                    dr[DCZAI02204EA.ct_Col_ArrivalCnt] = stockAcPayHisSearchRetWork.ArrivalCnt.ToString("#,##0.00");       // 入荷数
                    dr[DCZAI02204EA.ct_Col_ShipmentCnt] = stockAcPayHisSearchRetWork.ShipmentCnt.ToString("#,##0.00");     // 出荷数
                    dr[DCZAI02204EA.ct_Col_Bracker] = "";
                }
                // ---UPD 2010/11/15 ------------------------------------------------------------------------<<<<<


                dr[DCZAI02204EA.ct_Col_ListPriceTaxExcFl] = stockAcPayHisSearchRetWork.ListPriceTaxExcFl;   // 定価（税抜，浮動）
                dr[DCZAI02204EA.ct_Col_StockUnitPriceFl] = stockAcPayHisSearchRetWork.StockUnitPriceFl;     // 仕入単価（税抜，浮動）
                dr[DCZAI02204EA.ct_Col_AcPaySlipNm] = string.Empty;                                 // 受払元伝票区分
                dr[DCZAI02204EA.ct_Col_AcPayTransNm] = string.Empty;                                // 受払元取引区分

                // ---DEL 2009/05/26 不具合対応[12856] ------------------------------------------------------------->>>>>
                //// --- ADD 2008/12/15 --------------------------------------------------------------------------->>>>>
                //dr[DCZAI02204EA.ct_Col_StockPrice] = stockAcPayHisSearchRetWork.StockPrice;         // 入庫金額
                //dr[DCZAI02204EA.ct_Col_SalesMoney] = stockAcPayHisSearchRetWork.SalesMoney;         // 出庫金額
                //// --- ADD 2008/12/15 ---------------------------------------------------------------------------<<<<<
                // ---DEL 2009/05/26 不具合対応[12856] -------------------------------------------------------------<<<<<
                // ---ADD 2009/05/26 不具合対応[12856] ------------------------------------------------------------->>>>>
                // 入荷数の印字有無
                if (_stockAcPaySlipOfArrivalList.Contains(stockAcPayHisSearchRetWork.AcPaySlipCd))
                {
                    // ---ADD 2010/11/15 ------------------------>>>>>
                    // ※受払元伝票区分が10:仕入 or 20:売上 且つ入出荷日に値がセットされていない場合、()で囲んで表示し
                    if (((stockAcPayHisSearchRetWork.AcPaySlipCd == 10) || (stockAcPayHisSearchRetWork.AcPaySlipCd == 20)) &&
                        (stockAcPayHisSearchRetWork.IoGoodsDay == DateTime.MinValue))
                    {
                        //-----UPD 2010/12/09----->>>>>
                        //dr[DCZAI02204EA.ct_Col_StockPrice] = string.Format("({0}", stockAcPayHisSearchRetWork.StockPrice.ToString("#,##0.00"));// 入庫金額
                        dr[DCZAI02204EA.ct_Col_StockPrice] = string.Format("({0}", stockAcPayHisSearchRetWork.StockPrice.ToString("#,##0"));// 入庫金額
                        //-----UPD 2010/12/09-----<<<<<
                        dr[DCZAI02204EA.ct_Col_BrackerPrice] = ")";
                    }
                    else
                    {
                    // ---ADD 2010/11/15 ------------------------<<<<<
                        dr[DCZAI02204EA.ct_Col_StockPrice] = stockAcPayHisSearchRetWork.StockPrice;         // 入庫金額
                    // ---ADD 2010/11/15 ------------------------>>>>>
                        dr[DCZAI02204EA.ct_Col_BrackerPrice] = "";
                    }
                    // ---ADD 2010/11/15 ------------------------<<<<<
                    dr[DCZAI02204EA.ct_Col_SalesMoney] = 0;                                             // 出庫金額
                }
                // 出荷数の印字有無
                else if (_stockAcPaySlipOfShipmentList.Contains(stockAcPayHisSearchRetWork.AcPaySlipCd))
                {
                    dr[DCZAI02204EA.ct_Col_StockPrice] = 0;                                             // 入庫金額

                    // ---ADD 2010/11/15 ------------------------>>>>>
                    // ※受払元伝票区分が10:仕入 or 20:売上 且つ入出荷日に値がセットされていない場合、()で囲んで表示し
                    if (((stockAcPayHisSearchRetWork.AcPaySlipCd == 10) || (stockAcPayHisSearchRetWork.AcPaySlipCd == 20)) &&
                        (stockAcPayHisSearchRetWork.IoGoodsDay == DateTime.MinValue))
                    {
                        //-----UPD 2010/12/09----->>>>>
                        //dr[DCZAI02204EA.ct_Col_SalesMoney] = string.Format("({0}", stockAcPayHisSearchRetWork.SalesMoney.ToString("#,##0.00"));// 入庫金額
                        dr[DCZAI02204EA.ct_Col_SalesMoney] = string.Format("({0}", stockAcPayHisSearchRetWork.SalesMoney.ToString("#,##0"));// 入庫金額
                        //-----UPD 2010/12/09-----<<<<<
                        dr[DCZAI02204EA.ct_Col_BrackerPrice] = ")";
                    }
                    else
                    {
                    // ---ADD 2010/11/15 ------------------------<<<<<
                        dr[DCZAI02204EA.ct_Col_SalesMoney] = stockAcPayHisSearchRetWork.SalesMoney;         // 出庫金額
                    // ---ADD 2010/11/15 ------------------------>>>>>
                        dr[DCZAI02204EA.ct_Col_BrackerPrice] = "";
                    }
                    // ---ADD 2010/11/15 ------------------------<<<<<
                }
                else
                {
                    // ---ADD 2010/11/15 ------------------------>>>>>
                    // ※受払元伝票区分が10:仕入 or 20:売上 且つ入出荷日に値がセットされていない場合、()で囲んで表示し
                    if (((stockAcPayHisSearchRetWork.AcPaySlipCd == 10) || (stockAcPayHisSearchRetWork.AcPaySlipCd == 20)) &&
                        (stockAcPayHisSearchRetWork.IoGoodsDay == DateTime.MinValue))
                    {
                        //-----UPD 2010/12/09----->>>>>
                        //dr[DCZAI02204EA.ct_Col_StockPrice] = string.Format("({0}", stockAcPayHisSearchRetWork.StockPrice.ToString("#,##0.00"));// 入庫金額
                        dr[DCZAI02204EA.ct_Col_StockPrice] = string.Format("({0}", stockAcPayHisSearchRetWork.StockPrice.ToString("#,##0"));// 入庫金額
                        //dr[DCZAI02204EA.ct_Col_SalesMoney] = string.Format("({0}", stockAcPayHisSearchRetWork.SalesMoney.ToString("#,##0.00"));// 入庫金額
                        dr[DCZAI02204EA.ct_Col_SalesMoney] = string.Format("({0}", stockAcPayHisSearchRetWork.SalesMoney.ToString("#,##0"));// 入庫金額
                        //-----UPD 2010/12/09-----<<<<<
                        dr[DCZAI02204EA.ct_Col_BrackerPrice] = ")";
                    }
                    else
                    {
                    // ---ADD 2010/11/15 ------------------------<<<<<
                        dr[DCZAI02204EA.ct_Col_StockPrice] = stockAcPayHisSearchRetWork.StockPrice;         // 入庫金額
                        dr[DCZAI02204EA.ct_Col_SalesMoney] = stockAcPayHisSearchRetWork.SalesMoney;         // 出庫金額
                    // ---ADD 2010/11/15 ------------------------>>>>>
                        dr[DCZAI02204EA.ct_Col_BrackerPrice] = "";
                    }
                    // ---ADD 2010/11/15 ------------------------<<<<<
                }
                // ---ADD 2009/05/26 不具合対応[12856] -------------------------------------------------------------<<<<<

                // --- ADD 2009/01/08 --------------------------------------------------------------------------->>>>>
                dr[DCZAI02204EA.ct_Col_SalesUnPrcTaxExcFl] = stockAcPayHisSearchRetWork.SalesUnPrcTaxExcFl;     // 売上単価（税抜，浮動）
                // --- ADD 2009/01/08 ---------------------------------------------------------------------------<<<<<
                // --- ADD 2009/01/28 不具合対応[10622] --------------------------------------------------------->>>>>
                dr[DCZAI02204EA.ct_Col_AcPayHistDateTime] = stockAcPayHisSearchRetWork.AcPayHistDateTime;       // 受払履歴作成日時
                // --- ADD 2009/01/08 不具合対応[10622] ---------------------------------------------------------<<<<<

                //--- ADD 2010/11/15 ------------------------------------------>>>>>
                // <summary> 前月末残 </summary>
                dr[DCZAI02204EA.ct_Col_StockTotal] = stockAcPayHisSearchRetWork.StockTotal;
                dr[DCZAI02204EA.ct_Col_GoodsNoMaker] = stockAcPayHisSearchRetWork.GoodsNo + stockAcPayHisSearchRetWork.GoodsMakerCd;
                try
                {
                    dr[DCZAI02204EA.ct_Col_ShelfNo] = int.Parse(stockAcPayHisSearchRetWork.ShelfNo).ToString("00000000");
                }
                catch
                {
                    dr[DCZAI02204EA.ct_Col_ShelfNo] = stockAcPayHisSearchRetWork.ShelfNo;     // 受払元伝票番号
                }
                dr[DCZAI02204EA.ct_Col_AcPayHistDateTimeView] = stockAcPayHisSearchRetWork.AcPayHistDateTime.ToString("yy/MM/dd");
                //--- ADD 2010/11/15 ------------------------------------------<<<<<

                #endregion

                // 受払先コード・名称セット処理
                SetRecordAcPayOtherParty( ref dr, stockAcPayHisSearchRetWork );
                // 区分名称セット処理
                SetRecordDivName( ref dr, stockAcPayHisSearchRetWork);

				// TableにAdd
				this._stockAcPayListDt.Rows.Add( dr );
			}

			// DataView作成
			this._stockAcPayListDataView = new DataView( this._stockAcPayListDt, "", GetSortOrder(stockAcPayListCndtn), DataViewRowState.CurrentRows );
		}
        /// <summary>
        /// 受払先コード・名称セット処理
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="stockAcPayHisSearchRetWork"></param>
        /// <remarks>
        /// <br>DataRowに受払先コード・名称を設定します。</br>
        /// </remarks>
        private void SetRecordAcPayOtherParty ( ref DataRow dr, StockAcPayHisSearchRetWork stockAcPayHisSearchRetWork )
        {
            string code = string.Empty;
            string name = string.Empty;

            switch ( stockAcPayHisSearchRetWork.AcPaySlipCd )
            {
                // 30:移動出荷
                case 30:
                    {
                        // 移動先拠点＋移動先倉庫
                        //--- DEL 2008/07/03 ---------->>>>>
                        //code = string.Format( "{0}：{1}", 
                        //                        stockAcPayHisSearchRetWork.AfSectionCode,
                        //                        stockAcPayHisSearchRetWork.AfEnterWarehCode );
                        //--- DEL 2008/07/03 ----------<<<<<
                        //--- ADD 2008/07/03 ---------->>>>>
                        code = string.Format("{0}：{1}",
                                                stockAcPayHisSearchRetWork.AfSectionCode.Trim(),
                                                stockAcPayHisSearchRetWork.AfEnterWarehCode.Trim());
                        //--- ADD 2008/07/03 ----------<<<<<
                        name = string.Format("{0}：{1}", 
                                                stockAcPayHisSearchRetWork.AfSectionGuideNm,
                                                stockAcPayHisSearchRetWork.AfEnterWarehName );
                    }
                    break;
                // 31:移動入荷
                case 31:
                    {
                        // 移動元拠点＋移動元倉庫
                        /* --- DEL 2008/12/15 見切れる為------------------------------------------------>>>>>
                        code = string.Format("{0}：{1}",
                                                stockAcPayHisSearchRetWork.BfSectionCode,
                                                stockAcPayHisSearchRetWork.BfEnterWarehCode );
                           --- DEL 2008/12/15 ----------------------------------------------------------<<<<< */
                        //--- ADD 2008/12/15 ----------------------------------------------------------->>>>>
                        code = string.Format("{0}：{1}",
                                                stockAcPayHisSearchRetWork.BfSectionCode.Trim(),
                                                stockAcPayHisSearchRetWork.BfEnterWarehCode.Trim());
                        //--- ADD 2008/12/15 -----------------------------------------------------------<<<<<
                        name = string.Format("{0}：{1}",
                                                stockAcPayHisSearchRetWork.BfSectionGuideNm,
                                                stockAcPayHisSearchRetWork.BfEnterWarehName );
                    }
                    break;
                /* --- DEL 2009/03/10 不具合対応[12239] ------------------------------------------------------------------->>>>>
                //--- ADD 2008/12/11 ------------------------------------------------------------------->>>>>
                case 10:
                    {
                        // 仕入先
                        code = stockAcPayHisSearchRetWork.SupplierCd.ToString("000000");    // 仕入先コード
                        name = stockAcPayHisSearchRetWork.SupplierSnm;                      // 仕入先名称
                    }
                    break;
                //--- ADD 2008/12/11 -------------------------------------------------------------------<<<<<
                // その他
                default:
                    {
                        // 得意先
                        //code = stockAcPayHisSearchRetWork.CustomerCode.ToString("000000000"); // 得意先コード     //DEL 2009/03/09 不具合対応[12241]
                        code = stockAcPayHisSearchRetWork.CustomerCode.ToString("00000000");    // 得意先コード     //ADD 2009/03/09 不具合対応[12241]
                        name = stockAcPayHisSearchRetWork.CustomerSnm;  // 得意先名称
                    }
                    break;
                   --- DEL 2009/03/10 不具合対応[12239] -------------------------------------------------------------------<<<<< */
                // --- ADD 2009/03/10 不具合対応[12239] ------------------------------------------------------------------->>>>>
                case 10:        //10:仕入
                case 11:        //11:入荷
                    {
                        // 仕入先
                        code = stockAcPayHisSearchRetWork.SupplierCd.ToString("000000");        // 仕入先コード
                        name = stockAcPayHisSearchRetWork.SupplierSnm;                          // 仕入先名称
                    }
                    break;
                case 20:        //20:売上
                case 22:        //22:出荷
                    {
                        // 得意先
                        code = stockAcPayHisSearchRetWork.CustomerCode.ToString("00000000");    // 得意先コード     //ADD 2009/03/09 不具合対応[12241]
                        name = stockAcPayHisSearchRetWork.CustomerSnm;                          // 得意先名称
                    }
                    break;
                default:        //その他
                    {
                        //なし
                    }
                    break;
                // --- ADD 2009/03/10 不具合対応[12239] -------------------------------------------------------------------<<<<<
            }

            dr[DCZAI02204EA.ct_Col_AcPayOtherPartyCd] = code;
            dr[DCZAI02204EA.ct_Col_AcPayOtherPartyNm] = name;
        }
        /// <summary>
        /// 区分名称セット処理
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="stockAcPayHisSearchRetWork"></param>
        private void SetRecordDivName ( ref DataRow dr, StockAcPayHisSearchRetWork stockAcPayHisSearchRetWork )
        {
            dr[DCZAI02204EA.ct_Col_AcPaySlipNm] = GetAcPaySlipNm( stockAcPayHisSearchRetWork.AcPaySlipCd ); // 受払元伝票区分
            dr[DCZAI02204EA.ct_Col_AcPayTransNm] = GetAcPayTransNm( stockAcPayHisSearchRetWork.AcPayTransCd ); // 受払元取引区分
        }
        /// <summary>
        /// 伝票区分名称取得
        /// </summary>
        /// <param name="acPaySlipCd"></param>
        /// <returns></returns>
        private string GetAcPaySlipNm(int acPaySlipCd)
        {
            if ( this._acPaySlipNmDic.ContainsKey( acPaySlipCd ) )
            {
                return this._acPaySlipNmDic[acPaySlipCd];
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// 取引区分名称取得
        /// </summary>
        /// <param name="acPayTransCd"></param>
        /// <returns></returns>
        private string GetAcPayTransNm ( int acPayTransCd )
        {
            if ( this._acPayTransNmDic.ContainsKey( acPayTransCd ) )
            {
                return this._acPayTransNmDic[acPayTransCd];
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 伝票区分名称ディクショナリ生成
        /// </summary>
        /// <returns></returns>
        /// <br>Update Note : liyp 2010/11/15 </br>
        /// <br>            PM.NS 機能改良Ｑ４</br>
        private Dictionary<int, string> CreateAcPaySlipNmDictionary ()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();

            dic.Add( 10, "仕入" );
            dic.Add( 11, "入荷" );
            dic.Add( 12, "受計上" );
            dic.Add( 13, "在庫仕入");           //ADD 2008/12/11
            dic.Add( 20, "売上" );
            dic.Add( 21, "売計上" );
            //dic.Add( 22, "出荷" );//DEL 2010/11/15
            dic.Add(22, "貸出");//ADD 2010/11/15
            dic.Add( 23, "売切" );
            dic.Add( 30, "移動出荷" );
            dic.Add( 31, "移動入荷" );
            dic.Add( 40, "調整" );
            dic.Add( 41, "半黒" );
            //--- ADD 2008/07/03 ---------->>>>>
            dic.Add( 42, "マスタメンテ" );
            //--- ADD 2008/07/03 ----------<<<<<
            dic.Add( 50, "棚卸");
            // --- ADD 2009/01/23 不具合対応[6581] --------->>>>>
            dic.Add( 60, "組立");
            dic.Add( 61, "分解");
            dic.Add( 70, "補充入庫");
            dic.Add( 71, "補充出庫");
            // --- ADD 2009/01/23 不具合対応[6581] ---------<<<<<

            return dic;
        }
        /// <summary>
        /// 取引区分名称ディクショナリ生成
        /// </summary>
        /// <returns></returns>
        private Dictionary<int, string> CreateAcPayTransNmDictionary ()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();

            dic.Add( 10, "通常" );
            dic.Add( 11, "返品" );
            dic.Add( 12, "値引" );
            dic.Add( 20, "赤伝" );
            dic.Add( 21, "削除" );
            dic.Add( 22, "解除" );
            dic.Add( 30, "在庫数調整" );
            dic.Add( 31, "原価調整" );
            dic.Add( 32, "製番調整" );
            dic.Add( 33, "不良品" );
            dic.Add( 34, "抜出" );
            dic.Add( 35, "消去" );
            dic.Add( 36, "一括登録" );
            dic.Add( 40, "過不足更新" );
            //dic.Add( 90, "取消" );            //DEL 2009/01/28 不具合対応[10622]
            dic.Add( 90, "相殺");               //ADD 2009/01/28 不具合対応[10622]

            return dic;
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
        /// <br>UpdateNote : 2010/11/15 yangmj　機能改良Ｑ４</br>
        private string GetSortOrder(StockAcPayListCndtn stockAcPayListCndtn)
		{
			StringBuilder strSortOrder = new StringBuilder();

            //if ( !stockAcPayListCndtn.IsSelectAllSection )
            //{
            //    // 全社選択されてないとき
            //    // 主拠点
            //    strSortOrder.Append( string.Format("{0},", DCZAI02204EA.ct_Col_SectionCode ) );
            //}

            /* ---DEL 2008/12/09 不具合対応[8895]------------------------------------------->>>>>
            // 拠点コード
            strSortOrder.Append( string.Format( "{0} ASC,", DCZAI02204EA.ct_Col_SectionCode ) );
            // 倉庫コード
            strSortOrder.Append( string.Format( "{0} ASC,", DCZAI02204EA.ct_Col_WarehouseCode ) );
            // メーカー
            strSortOrder.Append( string.Format( "{0} ASC,", DCZAI02204EA.ct_Col_GoodsMakerCd ) );
            // 商品番号
            strSortOrder.Append( string.Format( "{0} ASC,", DCZAI02204EA.ct_Col_GoodsNo ) );
            // 入出荷日（降順）
            strSortOrder.Append( string.Format( "{0} DESC,", DCZAI02204EA.ct_Col_IoGoodsDay ) );
            // 伝票番号（降順）
            strSortOrder.Append( string.Format( "{0} DESC,", DCZAI02204EA.ct_Col_AcPaySlipNum ) );
            // 行番号
            strSortOrder.Append( string.Format( "{0} ASC", DCZAI02204EA.ct_Col_AcPaySlipRowNo ) );
               ---DEL 2008/12/09 不具合対応[8895]-------------------------------------------<<<<< */
            /* ---DEL 2008/12/09 不具合対応[10622]----------------------------------------------->>>>>
            // ---ADD 2008/12/09 不具合対応[8895]------------------------------------------->>>>> 
            strSortOrder.Append(string.Format("{0},", DCZAI02204EA.ct_Col_SectionCode));        // 拠点コード
            strSortOrder.Append(string.Format("{0},", DCZAI02204EA.ct_Col_WarehouseCode));      // 倉庫コード
            strSortOrder.Append(string.Format("{0},", DCZAI02204EA.ct_Col_GoodsNo));            // 商品番号
            strSortOrder.Append(string.Format("{0},", DCZAI02204EA.ct_Col_IoGoodsDay));         // 入出荷日
            strSortOrder.Append(string.Format("{0},", DCZAI02204EA.ct_Col_AcPaySlipCd));        // 伝票区分
            strSortOrder.Append(string.Format("{0}",  DCZAI02204EA.ct_Col_AcPaySlipNum));       // 伝票番号
            // ---ADD 2008/12/09 不具合対応[8895]-------------------------------------------<<<<<
               ---DEL 2008/12/09 不具合対応[10622]-----------------------------------------------<<<<< */

            // ---UPD 2010/11/15 ------------------------>>>>>
            if (stockAcPayListCndtn.Sort == 0)
            {
                // ---ADD 2008/12/09 不具合対応[10622]----------------------------------------------->>>>> 
                //strSortOrder.Append(string.Format("{0},", DCZAI02204EA.ct_Col_SectionCode));        // 拠点コード         //DEL 2009/04/07 不具合対応[12997]
                strSortOrder.Append(string.Format("{0},", DCZAI02204EA.ct_Col_WarehouseCode));      // 倉庫コード
                strSortOrder.Append(string.Format("{0},", DCZAI02204EA.ct_Col_GoodsNo));            // 商品番号
                strSortOrder.Append(string.Format("{0},", DCZAI02204EA.ct_Col_GoodsMakerCd)); // メーカー
                strSortOrder.Append(string.Format("{0},", DCZAI02204EA.ct_Col_AcPayHistDateTime));  // 受払履歴作成日時
                strSortOrder.Append(string.Format("{0},", DCZAI02204EA.ct_Col_AcPaySlipNum));     // 受払元伝票番号
                strSortOrder.Append(string.Format("{0}", DCZAI02204EA.ct_Col_AcPaySlipRowNo));     // 受払元行番号
                // ---ADD 2008/12/09 不具合対応[10622]-----------------------------------------------<<<<<
            }
            else if (stockAcPayListCndtn.Sort == 1)
            {
                // 倉庫→メーカー→品番→作成日時→受払元伝票番号→受払元行番号
                strSortOrder.Append(string.Format("{0},", DCZAI02204EA.ct_Col_WarehouseCode));      // 倉庫コード
                strSortOrder.Append(string.Format("{0},", DCZAI02204EA.ct_Col_GoodsMakerCd)); // メーカー
                strSortOrder.Append(string.Format("{0},", DCZAI02204EA.ct_Col_GoodsNo));            // 商品番号
                strSortOrder.Append(string.Format("{0},", DCZAI02204EA.ct_Col_AcPayHistDateTime));  // 受払履歴作成日時
                strSortOrder.Append(string.Format("{0},", DCZAI02204EA.ct_Col_AcPaySlipNum));     // 受払元伝票番号
                strSortOrder.Append(string.Format("{0}", DCZAI02204EA.ct_Col_AcPaySlipRowNo));     // 受払元行番号
            }
                
            // ---UPD 2010/11/15 ------------------------<<<<<
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

		// ---ADD 2013/01/15 ------------------------>>>>>
        /// <summary>
        /// 買掛管理ありか判定します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :買掛管理あり<br/>
        /// <c>false</c>:買掛管理なし
        /// </returns>
        /// <remarks>
        /// <br>Note       : USBから買掛オプション有無を読込んで、bool型で返します。</br>
        /// <br>Programer  : FSI厚川 宏</br>
        /// <br>Date       : 2013/01/15</br>
        /// </remarks>
        private static bool HasStockingPayment()
        {
            PurchaseStatus purchaseStatus = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(
                ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment
            );
            return purchaseStatus >= PurchaseStatus.Contract;
        }
		// ---ADD 2013/01/15 ------------------------<<<<<
	}
}

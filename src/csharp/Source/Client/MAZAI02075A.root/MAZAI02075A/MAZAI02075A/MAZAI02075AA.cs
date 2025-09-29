//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 在庫一覧表
// プログラム概要   : 在庫一覧表で使用するデータを取得する。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 中村　仁
// 作 成 日  2007/03/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2007/10/05  修正内容 : DC.NS対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2008/01/24  修正内容 : DC.NS対応（不具合対応）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/10/08  修正内容 : バグ修正、仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2009/01/29  修正内容 : 障害対応10566(リモート抽出結果のソート処理追加、xヵ月項目は同キーの場合加算する)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/13  修正内容 : 不具合対応[12371][12480]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/25  修正内容 : 不具合対応[12797]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/04/03  修正内容 : 不具合対応[12373]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/04/13  修正内容 : 不具合対応[13162]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/06/12  修正内容 : 不具合対応[13447]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/06/17  修正内容 : 不具合対応[13530]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22008 長内 数馬
// 修 正 日  2011/03/14  修正内容 : 速度チューニング
//----------------------------------------------------------------------------//
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// 在庫一覧表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 在庫一覧表にアクセスするクラスです。</br>
    /// <br>Programer  : 23010　中村　仁</br>
    /// <br>Date       : 2007.03.22</br>
    /// <br>Update Note: 2007.10.05 980035 金沢 貞義</br>
    /// <br>			 ・DC.NS対応</br>
    /// <br>Update Note: 2008.01.24 980035 金沢 貞義</br>
    /// <br>			 ・DC.NS対応（不具合対応）</br>
    /// <br>Update Note: 2008/10/08        照田 貴志</br>
    /// <br>			 ・バグ修正、仕様変更対応</br>
    /// <br>Update Note: 2009/01/29 30452 上野 俊治</br>
    /// <br>			 ・障害対応10566(リモート抽出結果のソート処理追加、xヵ月項目は同キーの場合加算する)</br>
    /// <br>           : 2009/03/13       照田 貴志　不具合対応[12371][12480]</br>
    /// <br>           : 2009/03/25       照田 貴志　不具合対応[12797]</br>
    /// <br>           : 2009/04/03       照田 貴志　不具合対応[12373]</br>
    /// <br>           : 2009/04/13       照田 貴志　不具合対応[13162]</br>
    /// <br>           : 2009/06/12       照田 貴志　不具合対応[13447]</br>
    /// <br>           : 2009/06/17       照田 貴志　不具合対応[13530]</br>
    /// </remarks>
	public class StockListAcs
	{
  	    // ===================================================================================== //
        //  外部提供定数
        // ===================================================================================== //
	    #region public constant
	    /// <summary>全拠点レコード用拠点コード</summary>
        public const string CT_AllSectionCode = "000000";
	    #endregion
    
	    // ===================================================================================== //
        //  スタティック変数
        // ===================================================================================== //
        #region static variable

        /// <summary>自拠点コード</summary>
        private static string mySectionCode               = "";
		/// <summary>帳票出力設定データクラス</summary>
		private static PrtOutSet prtOutSetData            = null;
        /// <summary>在庫管理全体設定データクラス</summary>
        private static StockMngTtlSt stockMngTtlStData        = null; 
		
	    #endregion

        // ===================================================================================== //
        //  内部使用変数
        // ===================================================================================== //
        #region private member
		
	    /// <summary>帳票出力設定アクセスクラス</summary>
	    private static PrtOutSetAcs prtOutSetAcs         = null;
		/// <summary>印刷用DateSet</summary>
		public DataSet _printDataSet;
        /// <summary>在庫管理全体設定アクセスクラス</summary>
	    private static StockMngTtlStAcs stockMngTtlStAcs = null;
        /// <summary>メーカーマスタアクセスクラス</summary>
        private MakerAcs _makerAcs = null;
        /// <summary>商品マスタアクセスクラス</summary>
        private GoodsAcs _goodsAcs = null;
	    #endregion
        
        // ===================================================================================== //
        //  内部使用定数
        // ===================================================================================== //
        #region private constant

        /// <summary>在庫一覧表データテーブル名</summary>
        private const string StockListDataTable = MAZAI02074EA.StockListDataTable;
        /// <summary>在庫一覧表バッファデータテーブル名</summary>
        public const string StockListCommonBuffDataTable = MAZAI02074EA.StockListCommonBuffDataTable;
        
        #endregion
        
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region コンストラクター
        /// <summary>
        /// 在庫一覧表アクセスクラスコンストラクター
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programer  : 23010 中村　仁</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        public StockListAcs()
        {
			// 印刷用DataSet
		    this._printDataSet	= new DataSet();
		    DataSetColumnConstruction(ref this._printDataSet);

            // ---ADD 2009/03/25 不具合対応[12797] -------------------------------------->>>>>
            string msg = string.Empty;
            _goodsAcs = new GoodsAcs();
            _goodsAcs.IsGetSupplier = true;         //ADD 2009/04/13 不具合対応[13162]
            _goodsAcs.SearchInitial(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode, out msg);
            // ---ADD 2009/03/25 不具合対応[12797] --------------------------------------<<<<<
        }
        #endregion

        // ===================================================================================== //
        // 静的コンストラクタ
        // ===================================================================================== //
        #region 静的コンストラクター

		/// <summary>
        /// 在庫一覧表アクセスクラス静的コンストラクター
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programer  : 23010　中村　仁</br>
        /// <br>Date       : 2007.03.22</br>
        /// </remarks>
        static StockListAcs()
        {
		    // 帳票出力設定アクセスクラスインスタンス化
		    prtOutSetAcs       = new PrtOutSetAcs();
			
            stockMngTtlStAcs   = new StockMngTtlStAcs();
		    // ログイン拠点取得
		    Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
		    if (loginEmployee != null)
		    {
				mySectionCode = loginEmployee.BelongSectionCode;
		    }
	    }

        #endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        #region プロパティ
          
      	#endregion

        // ===================================================================================== //
        // 外部提供関数
        // ===================================================================================== //
        #region public method
		
		/// <summary>
		/// 帳票出力設定読込
		/// </summary>
		/// <param name="prtOutSet">帳票出力設定データクラス</param>
		/// <param name="message">エラーメッセージ</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note       : 自拠点の帳票出力設定の読込を行います。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.03.22</br>
		/// </remarks>
		public int ReadPrtOutSet(out PrtOutSet prtOutSet, out string message)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			prtOutSet  = null;
			message = "";	
			try
			{
				// データは読込済みか？
				if (prtOutSetData != null)
				{
					prtOutSet = prtOutSetData.Clone(); 
					status    = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				} 
				else 
				{
					status = prtOutSetAcs.Read(out prtOutSetData, LoginInfoAcquisition.EnterpriseCode, mySectionCode);

					switch(status)
					{
						case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
							prtOutSet = prtOutSetData.Clone();	
							break;
						case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
						case (int)ConstantManagement.DB_Status.ctDB_EOF      :
							prtOutSet = new PrtOutSet();
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            break;
						default:
							prtOutSet = new PrtOutSet();
							message = "帳票出力設定の読込に失敗しました。";
							break;
					}
				}
			}
			catch(Exception ex)
			{
				message = ex.Message;
			}
			return status;
		}

        /// <summary>
		/// 在庫管理全体設定マスタ読込
		/// </summary>
		/// <param name="stockMngTtlSt">在庫管理全体設定マスタデータクラス</param>
		/// <param name="message">エラーメッセージ</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note       : 自拠点の在庫管理全体設定の読込を行います。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.03.22</br>
		/// </remarks>
        public int ReadStockMngTtlSt(out StockMngTtlSt stockMngTtlSt, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			stockMngTtlSt  = null;
			message = "";
	        try
			{
				// データは読込済みか？
				if (stockMngTtlStData != null)
				{
					stockMngTtlSt = stockMngTtlStData.Clone(); 
					status    = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				} 
				else 
				{
					status = stockMngTtlStAcs.Read(out stockMngTtlSt, LoginInfoAcquisition.EnterpriseCode,0);

					switch(status)
					{
						case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
							stockMngTtlSt = stockMngTtlSt.Clone();
							break;
						case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
						case (int)ConstantManagement.DB_Status.ctDB_EOF      :
							stockMngTtlSt = new StockMngTtlSt();
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            break;
						default:
							stockMngTtlSt = new StockMngTtlSt();
							message = "在庫管理全体設定の読込に失敗しました。";
							break;
					}
				}
			}
			catch(Exception ex)
			{
				message = ex.Message;
			}
			return status;
        }

		/// <summary>
        /// 在庫一覧表データ初期化処理
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : Static情報を初期化します。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.03.22</br>
		/// </remarks>
		public void InitializeCustomerLedger()
		{
     		// --テーブル行初期化-----------------------
			// 抽出結果データテーブルをクリア
            if (this._printDataSet.Tables[StockListDataTable] != null)
			{
                this._printDataSet.Tables[StockListDataTable].Rows.Clear();
			}
			// 抽出結果バッファデータテーブルをクリア
            if (this._printDataSet.Tables[StockListCommonBuffDataTable] != null)
			{
                this._printDataSet.Tables[StockListCommonBuffDataTable].Rows.Clear();
			}
		}
	
	    /// <summary>
        /// 在庫一覧表データ取得処理
		/// </summary>
        /// <param name="stockListCndtn"></param>
		/// <param name="message">エラーメッセージ</param>
		/// <returns></returns>
		/// <remarks>
        /// <br>Note       : 対象範囲の在庫一覧表データを取得します。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.03.22</br>
		/// </remarks>
        public int Search(StockListCndtn stockListCndtn, out string message)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message    = "";
            ConstantManagement.LogicalMode logicalmode = new ConstantManagement.LogicalMode();
            IStockListWorkDB _iStockListWorkDB = (IStockListWorkDB)MediationStockListWorkDB.GetStockListWorkDB();
            object stockListRltWorkObj = null;

			try
			{           
				//StaticMemory　初期化
				InitializeCustomerLedger();
                StockListCndtnWork stockListCndtnWork = new StockListCndtnWork();
                /* --- DEL 2008/10/08 大幅変更(追加項目が多い＆分かり難い為) --------------------------------------------------------------->>>>>
                // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
                //stockListCndtnWork.EnterPriseCode = stockListCndtn.EnterPriseCode;    // 企業コード
                stockListCndtnWork.EnterpriseCode = stockListCndtn.EnterpriseCode;      // 企業コード
                // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
                stockListCndtnWork.DepositStockSecCodeList = stockListCndtn.DepositStockSecCodeList;  // 選択在庫計上拠点コード
                // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
                //stockListCndtnWork.St_MakerCode = stockListCndtn.St_MakerCode;        // 開始メーカーコード
                //stockListCndtnWork.Ed_MakerCode = stockListCndtn.Ed_MakerCode;        // 終了メーカーコード
                //stockListCndtnWork.St_GoodsCode = stockListCndtn.St_GoodsCode;        // 開始商品コード
                //stockListCndtnWork.Ed_GoodsCode = stockListCndtn.Ed_GoodsCode;        // 終了商品コード
                stockListCndtnWork.St_GoodsMakerCd = stockListCndtn.St_GoodsMakerCd;    // 開始メーカーコード
                stockListCndtnWork.Ed_GoodsMakerCd = stockListCndtn.Ed_GoodsMakerCd;    // 終了メーカーコード
                stockListCndtnWork.St_GoodsNo = stockListCndtn.St_GoodsNo;              // 開始商品コード
                stockListCndtnWork.Ed_GoodsNo = stockListCndtn.Ed_GoodsNo;              // 終了商品コード
                // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
                //--- DEL 2008/08/01 ---------->>>>>
                //stockListCndtnWork.St_SupplierStock = stockListCndtn.St_SupplierStock;  // 開始仕入在庫数
                //stockListCndtnWork.Ed_SupplierStock = stockListCndtn.Ed_SupplierStock;  // 終了仕入在庫数
                //stockListCndtnWork.St_TrustCount = stockListCndtn.St_TrustCount;      // 開始受託数
                //stockListCndtnWork.Ed_TrustCount = stockListCndtn.Ed_TrustCount;      // 終了受託数
                //--- DEL 2008/08/01 ----------<<<<<
                stockListCndtnWork.St_ShipmentPosCnt = stockListCndtn.St_ShipmentPosCnt;  // 開始出荷可能数
                stockListCndtnWork.Ed_ShipmentPosCnt = stockListCndtn.Ed_ShipmentPosCnt;  // 終了出荷可能数
                //--- DEL 2008/08/01 ---------->>>>>
                //stockListCndtnWork.St_LargeGoodsGanreCode = stockListCndtn.St_LargeGoodsGanreCode;    // 開始商品区分グループコード
                //stockListCndtnWork.Ed_LargeGoodsGanreCode = stockListCndtn.Ed_LargeGoodsGanreCode;    // 終了商品区分グループコード
                //stockListCndtnWork.St_MediumGoodsGanreCode = stockListCndtn.St_MediumGoodsGanreCode;  // 開始商品区分コード
                //stockListCndtnWork.Ed_MediumGoodsGanreCode = stockListCndtn.Ed_MediumGoodsGanreCode;  // 終了商品区分コード
                //--- DEL 2008/08/01 ----------<<<<<
                // 2007.10.05 追加 >>>>>>>>>>>>>>>>>>>>
                //--- DEL 2008/08/01 ---------->>>>>
                //stockListCndtnWork.St_DetailGoodsGanreCode = stockListCndtn.St_DetailGoodsGanreCode;  // 開始商品区分詳細コード
                //stockListCndtnWork.Ed_DetailGoodsGanreCode = stockListCndtn.Ed_DetailGoodsGanreCode;  // 終了商品区分詳細コード
                //stockListCndtnWork.St_EnterpriseGanreCode = stockListCndtn.St_EnterpriseGanreCode;    // 開始自社分類コード
                //stockListCndtnWork.Ed_EnterpriseGanreCode = stockListCndtn.Ed_EnterpriseGanreCode;    // 終了自社分類コード
                //--- DEL 2008/08/01 ----------<<<<<
                stockListCndtnWork.St_BLGoodsCode = stockListCndtn.St_BLGoodsCode;      // 開始ＢＬ商品コード
                stockListCndtnWork.Ed_BLGoodsCode = stockListCndtn.Ed_BLGoodsCode;      // 終了ＢＬ商品コード
                stockListCndtnWork.St_WarehouseCode = stockListCndtn.St_WarehouseCode;  // 開始倉庫コード
                stockListCndtnWork.Ed_WarehouseCode = stockListCndtn.Ed_WarehouseCode;  // 終了倉庫コード
                // 2007.10.05 追加 <<<<<<<<<<<<<<<<<<<<
                stockListCndtnWork.St_LastStockDate = stockListCndtn.St_LastStockDate;  // 開始最終仕入年月日
                stockListCndtnWork.Ed_LastStockDate = stockListCndtn.Ed_LastStockDate;  // 終了最終仕入年月日
                //--- DEL 2008/08/01 ---------->>>>>
                //stockListCndtnWork.St_LastSalesDate = stockListCndtn.St_LastSalesDate;  // 開始最終売上日
                //stockListCndtnWork.Ed_LastSalesDate = stockListCndtn.Ed_LastSalesDate;  // 終了最終売上日
                //--- DEL 2008/08/01 ----------<<<<<
                // 2007.10.05 削除 >>>>>>>>>>>>>>>>>>>>
                //stockListCndtnWork.St_CarrierCode = stockListCndtn.St_CarrierCode;    // 開始キャリアコード
                //stockListCndtnWork.Ed_CarrierCode = stockListCndtn.Ed_CarrierCode;    // 終了キャリアコード
                // 2007.10.05 削除 <<<<<<<<<<<<<<<<<<<<
                // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
                //stockListCndtnWork.St_LastInventoryUpDate = stockListCndtn.St_LastInventoryUpDate;  // 開始最終棚卸更新日
                //stockListCndtnWork.Ed_LastInventoryUpDate = stockListCndtn.Ed_LastInventoryUpDate;  // 終了最終棚卸更新日
                //--- DEL 2008/08/01 ---------->>>>>
                //stockListCndtnWork.St_LastInventoryUpdate = stockListCndtn.St_LastInventoryUpdate;  // 開始最終棚卸更新日
                //stockListCndtnWork.Ed_LastInventoryUpdate = stockListCndtn.Ed_LastInventoryUpdate;  // 終了最終棚卸更新日
                //--- DEL 2008/08/01 ----------<<<<<
                // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
                // 2007.10.05 削除 >>>>>>>>>>>>>>>>>>>>
                //stockListCndtnWork.St_CellphoneModelCode = stockListCndtn.St_CellphoneModelCode;    // 開始機種コード
                //stockListCndtnWork.Ed_CellphoneModelCode = stockListCndtn.Ed_CellphoneModelCode;    // 終了機種コード
                // 2007.10.05 削除 <<<<<<<<<<<<<<<<<<<<
                //stockListCndtnWork.StockDiv = stockListCndtn.StockDiv;  // 在庫状態   // DEL 2008.08.01
                   --- DEL 2008/10/08 ------------------------------------------------------------------------------------------------------<<<<< */
                // --- ADD 2008/10/08 ------------------------------------------------------------------------------------------------------>>>>>
                stockListCndtnWork.EnterpriseCode = stockListCndtn.EnterpriseCode;                      // 企業コード
                stockListCndtnWork.DepositStockSecCodeList = stockListCndtn.DepositStockSecCodeList;    // 拠点コードリスト

                stockListCndtnWork.St_LastStockDate = stockListCndtn.St_LastStockDate;                  // 対象年月From
                stockListCndtnWork.Ed_LastStockDate = stockListCndtn.Ed_LastStockDate;                  // 対象年月To
                stockListCndtnWork.StockCreateDate = stockListCndtn.StockCreateDate;                    // 在庫登録日
                stockListCndtnWork.StockCreateDateFlg = (int)stockListCndtn.StockCreateDateFlg;         // 在庫登録日　　"以前"等
                stockListCndtnWork.St_ShipmentPosCnt = stockListCndtn.St_ShipmentPosCnt;                // 出荷数From
                stockListCndtnWork.Ed_ShipmentPosCnt = stockListCndtn.Ed_ShipmentPosCnt;                // 出荷数To
                stockListCndtnWork.PartsManagementDivide1 = stockListCndtn.PartsManagementDivide1;      // 管理区分1
                stockListCndtnWork.PartsManagementDivide2 = stockListCndtn.PartsManagementDivide2;      // 管理区分2

                stockListCndtnWork.St_WarehouseCode = stockListCndtn.St_WarehouseCode;                  // 倉庫From
                stockListCndtnWork.Ed_WarehouseCode = stockListCndtn.Ed_WarehouseCode;                  // 倉庫To
                stockListCndtnWork.St_StockSupplierCode = stockListCndtn.St_StockSupplierCode;          // 仕入先From
                //stockListCndtnWork.Ed_StockSupplierCode = stockListCndtn.Ed_StockSupplierCode;          // 仕入先To       //DEL　""とALL9入力の区別をつける必要がある為
                stockListCndtnWork.Ed_StockSupplierCode = this.GetEndCode(stockListCndtn.Ed_StockSupplierCode, 6);  // 仕入先To               
                stockListCndtnWork.St_WarehouseShelfNo = stockListCndtn.St_WarehouseShelfNo;            // 棚番From
                stockListCndtnWork.Ed_WarehouseShelfNo = stockListCndtn.Ed_WarehouseShelfNo;            // 棚番To
                stockListCndtnWork.St_GoodsMakerCd = stockListCndtn.St_GoodsMakerCd;                    // メーカーFrom
                //stockListCndtnWork.Ed_GoodsMakerCd = stockListCndtn.Ed_GoodsMakerCd;                    // メーカーTo     //DEL　""とALL9入力の区別をつける必要がある為
                stockListCndtnWork.Ed_GoodsMakerCd = this.GetEndCode(stockListCndtn.Ed_GoodsMakerCd, 4);            // メーカーTo
                stockListCndtnWork.St_BLGoodsCode = stockListCndtn.St_BLGoodsCode;                      // BLコードFrom
                //stockListCndtnWork.Ed_BLGoodsCode = stockListCndtn.Ed_BLGoodsCode;                      // BLコードTo     //DEL　""とALL9入力の区別をつける必要がある為
                stockListCndtnWork.Ed_BLGoodsCode = this.GetEndCode(stockListCndtn.Ed_BLGoodsCode, 5);              // BLコードTo
                stockListCndtnWork.St_GoodsNo = stockListCndtn.St_GoodsNo;                              // 品番From
                stockListCndtnWork.Ed_GoodsNo = stockListCndtn.Ed_GoodsNo;                              // 品番To
                // --- ADD 2008/10/08 ------------------------------------------------------------------------------------------------------<<<<<

                //データ取得
                status = _iStockListWorkDB.Search(out stockListRltWorkObj, stockListCndtnWork, 0, logicalmode);
                //--- TEST --------->>>>>
                //stockListRltWorkObj = this.GetTestData();
                //status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //--- TEST ---------<<<<<

                // リモートからデータの取得              
                #region
               
                if (status == 0)
                {
                    ArrayList retObjArr = new ArrayList();
                    ArrayList margeList = new ArrayList();
                    retObjArr = (ArrayList)stockListRltWorkObj;   
                    //TODO:2007.06.01 H.NAKAMURA ADD
                    // -- DEL 2011/03/14 ---------------------------->>>
                    ////在庫全体設定マスタを読込(在庫保有総額の項目にセットする金額を評価法毎に変更するため)
                    //StockMngTtlSt stockMngTtlSt = null;
                    //string mess = string.Empty;
                    ////int st = this.ReadStockMngTtlSt(out stockMngTtlSt,out mess);
                    //if(st != 0)
                    //{
                    //    //読込失敗
                    //    status  = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    //    message = "在庫管理全体設定の読込に失敗しました。";
                    //    return status;
                    //}
                    // -- DEL 2011/03/14 ----------------------------<<<

                    // 棚番ブレイク桁数
                    int breakLength = stockListCndtn.WarehouseShelfNoBreakLength;
                    /* --- DEL 2008/10/08 値が未入力の場合(0で登録された場合)、最初のデータが作成されない為 -->>>>>
                    int supplierCode = 0;
                    int makerCode = 0;
                       --- DEL 2008/10/08 --------------------------------------------------------------------<<<<< */
                    // --- ADD 2008/10/08 -------------------------------------------------------------------->>>>>
                    string warehouseCode = string.Empty;        // 倉庫コード
                    string supplierCode = string.Empty;         // 仕入先コード
                    string makerCode = string.Empty;            // メーカーコード
                    string goodsNo = string.Empty;              // 品番
                    // --- ADD 2008/10/08 --------------------------------------------------------------------<<<<<
                    // --- ADD 2009/01/29 -------------------------------->>>>>
                    // 総出荷数計算項目
                    double shipmentCnt = 0;
                    double shipmentCntBefore1 = 0;
                    double shipmentCntBefore2 = 0;
                    double shipmentCntBefore3 = 0;

                    // 総出荷金額計算項目
                    double shipmentPrice = 0;
                    double shipmentPriceBefore1 = 0;
                    double shipmentPriceBefore2 = 0;
                    double shipmentPriceBefore3 = 0;
                    // --- ADD 2009/01/29 --------------------------------<<<<<
                    double stockTotalCnt = 0;
                    double stockTotalPrice = 0;
                    double cnt = 0;         //ADD 2009/04/03 不具合対応[12373]

                    DataRow dr = null;

                    /* ---DEL 2009/03/13 不具合対応[12371] -------------------->>>>>
                    // --- ADD 2009/01/29 -------------------------------->>>>>
                    // キー順にソート
                    List<StockListResultWork> retObjGenArr = new List<StockListResultWork>();

                    foreach (StockListResultWork stockListResultWork in retObjArr)
                    {
                        retObjGenArr.Add(stockListResultWork);
                    }

                    retObjGenArr.Sort(this.ComparisonByKey);
                    // --- ADD 2009/01/29 -------------------------------->>>>>
                       ---DEL 2009/03/13 不具合対応[12371] --------------------<<<<< */
                    /* ---DEL 2009/04/03 不具合対応[12373] ------------------------->>>>>
                    // ---ADD 2009/03/13 不具合対応[12371] -------------------->>>>>
                    string key = string.Empty;
                    SortedList<string, StockListResultWork> retObjArrList = new SortedList<string, StockListResultWork>();
                    foreach (StockListResultWork stockListResultWork in retObjArr)
                    {
                        key = stockListResultWork.WarehouseCode.Trim().PadLeft(4, '0') +        // 倉庫コード
                              stockListResultWork.StockSupplierCode.ToString("000000") +        // 仕入先コード
                              stockListResultWork.GoodsMakerCd.ToString("0000") +               // メーカーコード
                              stockListResultWork.GoodsNo +                                     // 品番
                              stockListResultWork.AddUpYearMonth.ToString() +                   // 計上年月
                              stockListResultWork.StockCreateDate.ToString() +
                              stockListResultWork.WarehouseShelfNo.ToString() +
                              stockListResultWork.WarehouseName;
                        
                        retObjArrList.Add(key, stockListResultWork);
                    }
                    // ---ADD 2009/03/13 不具合対応[12371] --------------------<<<<<
                       ---DEL 2009/04/03 不具合対応[12373] -------------------------<<<<< */
                    // ---ADD 2009/04/03 不具合対応[12373] ------------------------->>>>>
                    //※上記ソート方法では大文字、小文字がうまく区別されない為、不十分！
                    //  例えばabc0013、ABC0013、abc0014、ABC0014とあった場合、左記の順番(大文字、小文字関係なし)で並ぶ為、abcとABCでまとめる事ができない。
                    //  下記ではABC0013、ABC0014、abc0013、abc0014の順(大文字、小文字の順)に並ぶ為、ABCとabcでまとめる事ができる。
                    List<StockListResultWork> retObjGenArr = new List<StockListResultWork>();

                    foreach (StockListResultWork stockListResultWork in retObjArr)
                    {
                        retObjGenArr.Add(stockListResultWork);
                    }

                    retObjGenArr.Sort(this.ComparisonByKey1);
                    // ---DEL 2009/04/03 不具合対応[12373] -------------------------<<<<<

                    //foreach (StockListResultWork stockListResultWork in retObjGenArr)         //DEL 2009/03/13 不具合対応[12371]
                    //foreach (StockListResultWork stockListResultWork in retObjArrList.Values)   //ADD 2009/03/13 不具合対応[12371] → DEL 2009/04/03 不具合対応[12373]
                    foreach (StockListResultWork stockListResultWork in retObjGenArr)               //ADD 2009/04/03 不具合対応[12373]
                    {
                        /* --- DEL 2008/10/08 1明細作成の条件変更の為(仕入先、メーカー　→　倉庫、仕入先、メーカー、品番) ------------>>>>>
                        if (stockListResultWork.StockSupplierCode != supplierCode || stockListResultWork.GoodsMakerCd != makerCode) 
                        {
                            if (supplierCode != 0)
                            {
                                this._printDataSet.Tables[StockListDataTable].Rows.Add(dr);
                            }

                            dr = this._printDataSet.Tables[StockListDataTable].NewRow();

                            supplierCode = stockListResultWork.StockSupplierCode;
                            makerCode = stockListResultWork.GoodsMakerCd;

                            stockTotalCnt = 0;
                            stockTotalPrice = 0;
                        }
                           --- DEL 2008/10/08 ----------------------------------------------------------------------------------------<<<<< */
                        // --- ADD 2008/10/08 ---------------------------------------------------------------------------------------->>>>>
                        if ((stockListResultWork.WarehouseCode.Trim().PadLeft(4,'0') != warehouseCode) ||
                            (stockListResultWork.StockSupplierCode.ToString("000000") != supplierCode) ||
                            (stockListResultWork.GoodsMakerCd.ToString("0000") != makerCode) ||
                            (stockListResultWork.GoodsNo != goodsNo))
                        {
                            // 最初のデータ以外
                            if (warehouseCode != string.Empty)
                            {
                                /* ---DEL 2009/04/03 不具合対応[12373] ----------------------------------------->>>>>
                                // 作成した明細を追加
                                this._printDataSet.Tables[StockListDataTable].Rows.Add(dr);
                                   ---DEL 2009/04/03 不具合対応[12373] -----------------------------------------<<<<< */
                                // ---ADD 2009/04/03 不具合対応[12373] ----------------------------------------->>>>>
                                cnt = double.Parse(dr[MAZAI02074EA.ctCol_ShipmentCnt].ToString());
                                if (stockListCndtn.St_ShipmentPosCnt <= cnt && cnt <= stockListCndtn.Ed_ShipmentPosCnt)
                                {
                                    // 作成した明細を追加
                                    this._printDataSet.Tables[StockListDataTable].Rows.Add(dr);
                                }
                                // ---ADD 2009/04/03 不具合対応[12373] -----------------------------------------<<<<<
                            }

                            dr = this._printDataSet.Tables[StockListDataTable].NewRow();
                            
                            warehouseCode = stockListResultWork.WarehouseCode.Trim().PadLeft(4, '0');       // 倉庫コード
                            supplierCode = stockListResultWork.StockSupplierCode.ToString("000000");        // 仕入先コード
                            makerCode = stockListResultWork.GoodsMakerCd.ToString("0000");                  // メーカーコード
                            goodsNo = stockListResultWork.GoodsNo;                                          // 品番

                            // --- ADD 2009/01/29 -------------------------------->>>>>
                            shipmentCnt = 0;
                            shipmentCntBefore1 = 0;
                            shipmentCntBefore2 = 0;
                            shipmentCntBefore3 = 0;

                            shipmentPrice = 0;
                            shipmentPriceBefore1 = 0;
                            shipmentPriceBefore2 = 0;
                            shipmentPriceBefore3 = 0;
                            // --- ADD 2009/01/29 --------------------------------<<<<<

                            stockTotalCnt = 0;
                            stockTotalPrice = 0;
                        }
                        // --- ADD 2008/10/08 ----------------------------------------------------------------------------------------<<<<<

                        //dr[MAZAI02074EA.ctCol_SectionCode]          = stockListResultWork.SectionCode;	        // 拠点コード       // DEL 2008.08.01
                        // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
                        //dr[MAZAI02074EA.ctCol_SectionName]        = stockListResultWork.SectionName;	            // 拠点名称
                        //dr[MAZAI02074EA.ctCol_MakerCode]          = stockListResultWork.MakerCode;	            // メーカーコード
                        //dr[MAZAI02074EA.ctCol_SectionName]          = stockListResultWork.SectionGuideNm;	        // 拠点ガイド名称   // DEL 2008.08.01
                        dr[MAZAI02074EA.ctCol_GoodsMakerCd]         = stockListResultWork.GoodsMakerCd;	            // メーカーコード
                        // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
                        //dr[MAZAI02074EA.ctCol_MakerName]            = stockListResultWork.MakerName;	            // メーカー名称     // DEL 2008.08.01
                        dr[MAZAI02074EA.ctCol_MakerName]            = this.GetMakerName(stockListCndtn.EnterpriseCode, stockListResultWork.GoodsMakerCd);   // メーカー名称     //ADD 2008/10/08 復活
                        // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
                        //dr[MAZAI02074EA.ctCol_GoodsCode]          = stockListResultWork.GoodsCode;	            // 商品コード
                        dr[MAZAI02074EA.ctCol_GoodsNo]              = stockListResultWork.GoodsNo;	                // 商品コード
                        // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
                        dr[MAZAI02074EA.ctCol_GoodsName]            = stockListResultWork.GoodsName;	            // 商品名称
                        // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
                        //dr[MAZAI02074EA.ctCol_StockUnitPrice]     = stockListResultWork.StockUnitPrice;	        // 仕入単価
                        //dr[MAZAI02074EA.ctCol_StockUnitPrice]       = stockListResultWork.StockUnitPriceFl;	    // 仕入単価         // DEL 2008.08.01
                        // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
                        //dr[MAZAI02074EA.ctCol_SupplierStock]        = stockListResultWork.SupplierStock;	        // 仕入在庫数       // DEL 2008.08.01
                        // 2008.01.24 削除 >>>>>>>>>>>>>>>>>>>>
                        //dr[MAZAI02074EA.ctCol_TrustCount]           = stockListResultWork.TrustCount;	            // 受託数
                        // 2008.01.24 削除 <<<<<<<<<<<<<<<<<<<<
                        // 2007.10.05 削除 >>>>>>>>>>>>>>>>>>>>
                        //dr[MAZAI02074EA.ctCol_ReservedCount]      = stockListResultWork.ReservedCount;	        // 予約数
                        //dr[MAZAI02074EA.ctCol_AllowStockCnt]      = stockListResultWork.AllowStockCnt;	        // 引当在庫数
                        // 2007.10.05 削除 <<<<<<<<<<<<<<<<<<<<
                        //--- DEL 2008/08/01 ---------->>>>>
                        //dr[MAZAI02074EA.ctCol_AcpOdrCount]          = stockListResultWork.AcpOdrCount;	        // 受注数
                        //dr[MAZAI02074EA.ctCol_SalesOrderCount]      = stockListResultWork.SalesOrderCount;	    // 発注数
                        //dr[MAZAI02074EA.ctCol_EntrustCnt]           = stockListResultWork.EntrustCnt;	            // 仕入在庫分委託数
                        //--- DEL 2008/08/01 ----------<<<<<
                        // 2007.10.05 削除 >>>>>>>>>>>>>>>>>>>>
                        //dr[MAZAI02074EA.ctCol_TrustEntrustCnt]    = stockListResultWork.TrustEntrustCnt;	        // 受託分委託数
                        //dr[MAZAI02074EA.ctCol_SoldCnt]            = stockListResultWork.SoldCnt;	                // 売切数
                        // 2007.10.05 削除 <<<<<<<<<<<<<<<<<<<<
                        //dr[MAZAI02074EA.ctCol_MovingSupliStock]     = stockListResultWork.MovingSupliStock;	    // 移動中仕入在庫数     // DEL 2008.08.01
                        // 2008.01.24 修正 >>>>>>>>>>>>>>>>>>>>
                        //dr[MAZAI02074EA.ctCol_MovingTrustStock]   = stockListResultWork.MovingTrustStock;	        // 移動中受託在庫数
                        //dr[MAZAI02074EA.ctCol_ShipmentPosCnt]       = stockListResultWork.ShipmentPosCnt;	        // 出荷可能数           // DEL 2008.08.01
                        dr[MAZAI02074EA.ctCol_ShipmentPosCnt]       = stockListResultWork.ShipmentPosCnt;	        // 出荷可能数           //ADD 2008/10/08 復活
                        //dr[MAZAI02074EA.ctCol_ShipmentCnt]          = stockListResultWork.ShipmentCnt;            // 出荷数(未計上)
                        //dr[MAZAI02074EA.ctCol_ArrivalCnt]           = stockListResultWork.ArrivalCnt;             // 入荷数(未計上)       // DEL 2008.08.01

                        // 出荷可能数取得（出荷可能数 = 仕入在庫数 + 入荷数(未計上) - 出荷数(未計上) - 移動中仕入在庫数 - 受注数）
                        //--- DEL 2008/08/01 ---------->>>>>
                        //double shipmentPosCnt = stockListResultWork.SupplierStock + stockListResultWork.ArrivalCnt - stockListResultWork.ShipmentCnt - stockListResultWork.MovingSupliStock - stockListResultWork.AcpOdrCount;
                        //dr[MAZAI02074EA.ctCol_ShipmentPosCnt]       = shipmentPosCnt;	                            // 出荷可能数
                        //--- DEL 2008/08/01 ----------<<<<<
                        // 2008.01.24 修正 <<<<<<<<<<<<<<<<<<<<
                        // 2007.10.05 削除 >>>>>>>>>>>>>>>>>>>>
                        //dr[MAZAI02074EA.ctCol_PrdNumMngDiv]       = stockListResultWork.PrdNumMngDiv;	                                        // 製番管理区分
                        //dr[MAZAI02074EA.ctCol_PrdNumMngDivName]   = StockListCndtn.GetPrdNumMngDivName(stockListResultWork.PrdNumMngDiv);	    // 製番管理区分名称
                        // 2007.10.05 削除 <<<<<<<<<<<<<<<<<<<<
                        //--- DEL 2008/08/01 ---------->>>>>
                        //dr[MAZAI02074EA.ctCol_LastStockDate]        = stockListResultWork.LastStockDate;	        // 最終仕入年月日
                        //dr[MAZAI02074EA.ctCol_LastSalesDate]        = stockListResultWork.LastSalesDate;	        // 最終売上日
                        //dr[MAZAI02074EA.ctCol_LastInventoryUpdate]  = stockListResultWork.LastInventoryUpdate;	// 最終棚卸更新日
                        //--- DEL 2008/08/01 ----------<<<<<
                        // 2007.10.05 削除 >>>>>>>>>>>>>>>>>>>>
                        //dr[MAZAI02074EA.ctCol_CellphoneModelCode] = stockListResultWork.CellphoneModelCode;	    // 機種コード
                        //dr[MAZAI02074EA.ctCol_CellphoneModelName] = stockListResultWork.CellphoneModelName;	    // 機種名称
                        //dr[MAZAI02074EA.ctCol_CarrierCode]        = stockListResultWork.CarrierCode;	            // キャリアコード
                        //dr[MAZAI02074EA.ctCol_CarrierName]        = stockListResultWork.CarrierName;	            // キャリア名称
                        //dr[MAZAI02074EA.ctCol_SystematicColorCd]  = stockListResultWork.SystematicColorCd;	    // 系統色コード
                        //dr[MAZAI02074EA.ctCol_SystematicColorNm]  = stockListResultWork.SystematicColorNm;	    // 系統色名称
                        // 2007.10.05 削除 <<<<<<<<<<<<<<<<<<<<
                        //--- DEL 2008/08/01 ---------->>>>>
                        //dr[MAZAI02074EA.ctCol_LargeGoodsGanreCode]  = stockListResultWork.LargeGoodsGanreCode;	// 商品区分グループコード
                        //dr[MAZAI02074EA.ctCol_LargeGoodsGanreName]  = stockListResultWork.LargeGoodsGanreName;	// 商品区分グループ名称
                        //dr[MAZAI02074EA.ctCol_MediumGoodsGanreCode] = stockListResultWork.MediumGoodsGanreCode;	// 商品区分コード
                        //dr[MAZAI02074EA.ctCol_MediumGoodsGanreName] = stockListResultWork.MediumGoodsGanreName;	// 商品区分名称
                        //--- DEL 2008/08/01 ----------<<<<<
                        // 2007.10.05 追加 >>>>>>>>>>>>>>>>>>>>
                        //--- DEL 2008/08/01 ---------->>>>>
                        //dr[MAZAI02074EA.ctCol_DetailGoodsGanreCode] = stockListResultWork.DetailGoodsGanreCode;   // 商品区分詳細コード
                        //dr[MAZAI02074EA.ctCol_DetailGoodsGanreName] = stockListResultWork.DetailGoodsGanreName;   // 商品区分詳細コード
                        //dr[MAZAI02074EA.ctCol_EnterpriseGanreCode]  = stockListResultWork.EnterpriseGanreCode;    // 自社分類コード
                        //dr[MAZAI02074EA.ctCol_EnterpriseGanreName]  = stockListResultWork.EnterpriseGanreName;    // 自社分類コード
                        //--- DEL 2008/08/01 ----------<<<<<
                        dr[MAZAI02074EA.ctCol_BLGoodsCode] = stockListResultWork.BLGoodsCode;                       // ＢＬ商品コード
                        //dr[MAZAI02074EA.ctCol_BLGoodsName]          = stockListResultWork.BLGoodsFullName;        // ＢＬ商品コード       // DEL 2008.08.01
                        dr[MAZAI02074EA.ctCol_WarehouseCode]        = stockListResultWork.WarehouseCode;            // 倉庫コード
                        dr[MAZAI02074EA.ctCol_WarehouseName]        = stockListResultWork.WarehouseName;            // 倉庫コード
                        // 2008.01.24 追加 >>>>>>>>>>>>>>>>>>>>
                        dr[MAZAI02074EA.ctCol_WarehouseShelfNo]     = stockListResultWork.WarehouseShelfNo;         // 倉庫棚番
                        // 2008.01.24 追加 <<<<<<<<<<<<<<<<<<<<
                        // 2007.10.05 追加 <<<<<<<<<<<<<<<<<<<<
                        dr[MAZAI02074EA.ctCol_MinimumStockCnt]      = stockListResultWork.MinimumStockCnt;	        // 最低在庫数
                        dr[MAZAI02074EA.ctCol_MaximumStockCnt]      = stockListResultWork.MaximumStockCnt;	        // 最高在庫数
                        //dr[MAZAI02074EA.ctCol_NmlSalOdrCount]       = stockListResultWork.NmlSalOdrCount;	        // 基準発注数       // DEL 2008.08.01
                        // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
                        //dr[MAZAI02074EA.ctCol_SalOdrLot]          = stockListResultWork.SalOdrLot;	            // 発注単位
                        //dr[MAZAI02074EA.ctCol_SalOdrLot]            = stockListResultWork.SalesOrderUnit;         // 発注単位         // DEL 2008.08.01
                        // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<

                        //在庫評価法(1:最終仕入原価法,2:移動平均法,3:個別単価法)により判定
                        //最終仕入原価法の時は仕入在庫数×個数を代入する
                        //--- DEL 2008/08/01 ---------->>>>>
                        //if(stockMngTtlSt.StockPointWay == 1)
                        //{
                        //    // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
                        //    //dr[MAZAI02074EA.ctCol_StockTotalPrice] = stockListResultWork.StockUnitPrice * (long)stockListResultWork.SupplierStock;
                        //    dr[MAZAI02074EA.ctCol_StockTotalPrice] = stockListResultWork.StockUnitPriceFl * (long)stockListResultWork.SupplierStock;
                        //    // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
                        //}
                        //else
                        //{
                        //    //個別評価法の場合はレポート側で表示を消している。
                        //    dr[MAZAI02074EA.ctCol_StockTotalPrice]          = stockListResultWork.StockTotalPrice;  // 在庫保有総額
                        //}
                        //--- DEL 2008/08/01 ----------<<<<<

                        // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
                        //dr[MAZAI02074EA.ctCol_SectionName_Detail] = stockListResultWork.SectionName;	            // 拠点名称(明細)    
                        //dr[MAZAI02074EA.ctCol_SectionName_Detail] = stockListResultWork.SectionGuideNm;	        // 拠点名称(明細)    // DEL 2008.08.01
                        // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
                        //ソート用(最終仕入年月日)
                        //dr[MAZAI02074EA.ctCol_LastStockDate_sort]   = TDateTime.DateTimeToLongDate(stockListResultWork.LastStockDate);    // DEL 2008.08.01

                        //--- DEL 2008/08/01 ---------->>>>>
                        ////メーカーコード(印刷用)
                        //// 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
                        ////if (stockListResultWork.MakerCode == 0)
                        //if (stockListResultWork.GoodsMakerCd == 0)
                        //// 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
                        //{
                        //    //０の場合は印刷しない
                        //    dr[MAZAI02074EA.ctCol_MakerCode_Print] = "";
                        //}
                        //else
                        //{
                        //    // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
                        //    //dr[MAZAI02074EA.ctCol_MakerCode_Print] = stockListResultWork.MakerCode.ToString();
                        //    dr[MAZAI02074EA.ctCol_MakerCode_Print] = stockListResultWork.GoodsMakerCd.ToString();
                        //    // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
                        //}
                        //--- DEL 2008/08/01 ----------<<<<<
                        // 2007.10.05 削除 >>>>>>>>>>>>>>>>>>>>
                        ////キャリアコード(印刷用)
                        //if(stockListResultWork.CarrierCode == 0)
                        //{
                        //    //０の場合は印刷しない
                        //    dr[MAZAI02074EA.ctCol_CarrierCode_Print] = "";
                        //}
                        //else
                        //{
                        //    dr[MAZAI02074EA.ctCol_CarrierCode_Print] = stockListResultWork.CarrierCode.ToString();
                        //}
                        ////系統色コード(印刷用)
                        //if(stockListResultWork.SystematicColorCd == 0)
                        //{
                        //    //０の場合は印刷しない
                        //    dr[MAZAI02074EA.ctCol_SystematicColorCd_Print] = "";
                        //
                        //}
                        //else
                        //{
                        //    dr[MAZAI02074EA.ctCol_SystematicColorCd_Print] = stockListResultWork.SystematicColorCd.ToString();
                        //}
                        // 2007.10.05 削除 <<<<<<<<<<<<<<<<<<<<

                        //商品区分グループコード(印刷用)
                        //dr[MAZAI02074EA.ctCol_LargeGoodsGanreCode_Print] = stockListResultWork.LargeGoodsGanreCode;       // DEL 2008.08.01
                        
                        //商品区分コード(印刷用)                                           
                        //dr[MAZAI02074EA.ctCol_MediumGoodsGanreCode_Print] = stockListResultWork.MediumGoodsGanreCode;     // DEL 2008.08.01

                        // 2007.10.05 追加 >>>>>>>>>>>>>>>>>>>>
                        //商品区分詳細コード(印刷用)                                           
                        //dr[MAZAI02074EA.ctCol_DetailGoodsGanreCode_Print] = stockListResultWork.DetailGoodsGanreCode;     // DEL 2008.08.01
                        // 2007.10.05 追加 <<<<<<<<<<<<<<<<<<<<

                        //最終仕入日(印刷用)
                        //--- DEL 2008/08/01 ---------->>>>>
                        //if(stockListResultWork.LastStockDate == DateTime.MinValue)
                        //{
                        //    dr[MAZAI02074EA.ctCol_LastStockDate_print] = "";
                        //}
                        //else
                        //{
                        //    dr[MAZAI02074EA.ctCol_LastStockDate_print]  = TDateTime.DateTimeToString("YYYY/MM/DD",stockListResultWork.LastStockDate);
                        //}
                        //--- DEL 2008/08/01 ----------<<<<<
                        // 最終売上日(印刷用)
                        //--- DEL 2008/08/01 ---------->>>>>
                        //if(stockListResultWork.LastSalesDate == DateTime.MinValue)
                        //{
                        //    dr[MAZAI02074EA.ctCol_LastSalesDate_print] = "";
                        //}
                        //else
                        //{
                        //    dr[MAZAI02074EA.ctCol_LastSalesDate_print] = TDateTime.DateTimeToString("YYYY/MM/DD",stockListResultWork.LastSalesDate);
                        //}
                        //--- DEL 2008/08/01 ----------<<<<<
                        // 最終棚卸更新日(印刷用)
                        //--- DEL 2008/08/01 ---------->>>>>
                        //if(stockListResultWork.LastInventoryUpdate == DateTime.MinValue)
                        //{
                        //    dr[MAZAI02074EA.ctCol_LastInventoryUpdate_print] = "";
                        //}
                        //else
                        //{
                        //    dr[MAZAI02074EA.ctCol_LastInventoryUpdate_print] = TDateTime.DateTimeToString("YYYY/MM/DD",stockListResultWork.LastInventoryUpdate);
                        //}
                        //--- DEL 2008/08/01 ----------<<<<<

                        //--- ADD 2008/08/01 ---------->>>>>
                        /* ---DEL 2009/03/25 不具合対応[12797] -------------------------------------------->>>>>
                        // 在庫発注先コード
                        dr[MAZAI02074EA.ctCol_StockSupplierCode] = stockListResultWork.StockSupplierCode;
                        // 仕入先略称
                        dr[MAZAI02074EA.ctCol_SupplierSnm] = stockListResultWork.SupplierSnm;
                           ---DEL 2009/03/25 不具合対応[12797] --------------------------------------------<<<<< */
                        // ---ADD 2009/03/25 不具合対応[12797] -------------------------------------------->>>>>
                        if (stockListResultWork.StockSupplierCode == 0)
                        {
                            int supplierCd;
                            string supplierSnm;
                            this.GetGoodsMngInfo(stockListResultWork, out supplierCd, out supplierSnm);
                            dr[MAZAI02074EA.ctCol_StockSupplierCode] = supplierCd;                                  // 仕入先コード
                            dr[MAZAI02074EA.ctCol_SupplierSnm] = supplierSnm;                                       // 仕入先略称
                            dr[MAZAI02074EA.ctCol_Sort_CustomerCode] = supplierCd.ToString("000000");               // ソート用　仕入先コード
                        }
                        else
                        {
                            dr[MAZAI02074EA.ctCol_StockSupplierCode] = stockListResultWork.StockSupplierCode;                       //仕入先コード
                            dr[MAZAI02074EA.ctCol_SupplierSnm] = stockListResultWork.SupplierSnm;                                   //仕入先略称
                            dr[MAZAI02074EA.ctCol_Sort_CustomerCode] = stockListResultWork.StockSupplierCode.ToString("000000");    // ソート用　仕入先コード
                        }
                        // ---ADD 2009/03/25 不具合対応[12797] --------------------------------------------<<<<<

                        // 部品管理区分１
                        //dr[MAZAI02074EA.ctCol_DuplicationShelfNo1] = stockListResultWork.DuplicationShelfNo1;         //DEL 2008/10/08 ID変更
                        dr[MAZAI02074EA.ctCol_PartsManagementDivide1] = stockListResultWork.PartsManagementDivide1;     //ADD 2008/10/08

                        // 部品管理区分２
                        //dr[MAZAI02074EA.ctCol_DuplicationShelfNo2] = stockListResultWork.DuplicationShelfNo2;         //DEL 2008/10/08 ID変更
                        dr[MAZAI02074EA.ctCol_PartsManagementDivide2] = stockListResultWork.PartsManagementDivide2;     //ADD 2008/10/08
                        // 計上年月
                        dr[MAZAI02074EA.ctCol_AddUpYearMonth] = TDateTime.DateTimeToLongDate(stockListResultWork.AddUpYearMonth);

                        // --- DEL 2009/01/29 -------------------------------->>>>>
                        //if (stockListCndtn.PublicationType == StockListCndtn.PublicationTypeState.ByShipmentCnt)
                        //{
                        //    if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate && stockListResultWork.AddUpYearMonth < stockListCndtn.Ed_LastStockDate.AddMonths(1))
                        //    {
                        //        dr[MAZAI02074EA.ctCol_ShipmentCnt] = stockListResultWork.ShipmentCnt;            // 出荷数 
                        //    }
                        //    else if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate.AddMonths(-1))
                        //    {
                        //        dr[MAZAI02074EA.ctCol_ShipmentCntBefore1] = stockListResultWork.ShipmentCnt;
                        //    }
                        //    else if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate.AddMonths(-2))
                        //    {
                        //        dr[MAZAI02074EA.ctCol_ShipmentCntBefore2] = stockListResultWork.ShipmentCnt;
                        //    }
                        //    else if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate.AddMonths(-3))
                        //    {
                        //        dr[MAZAI02074EA.ctCol_ShipmentCntBefore3] = stockListResultWork.ShipmentCnt;
                        //    }
                        //}
                        //else
                        //{
                        //    if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate && stockListResultWork.AddUpYearMonth < stockListCndtn.Ed_LastStockDate.AddMonths(1))
                        //    {
                        //        dr[MAZAI02074EA.ctCol_ShipmentPrice] = stockListResultWork.ShipmentPrice;            // 出荷金額 
                        //    }
                        //    else if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate.AddMonths(-1))
                        //    {
                        //        dr[MAZAI02074EA.ctCol_ShipmentPriceBefore1] = stockListResultWork.ShipmentPrice;
                        //    }
                        //    else if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate.AddMonths(-2))
                        //    {
                        //        dr[MAZAI02074EA.ctCol_ShipmentPriceBefore2] = stockListResultWork.ShipmentPrice;
                        //    }
                        //    else if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate.AddMonths(-3))
                        //    {
                        //        dr[MAZAI02074EA.ctCol_ShipmentPriceBefore3] = stockListResultWork.ShipmentPrice;
                        //    }
                        //}
                        // --- DEL 2009/01/29 --------------------------------<<<<<
                        // --- ADD 2009/01/29 -------------------------------->>>>>
                        if (stockListCndtn.PublicationType == StockListCndtn.PublicationTypeState.ByShipmentCnt)
                        {
                            if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate && stockListResultWork.AddUpYearMonth < stockListCndtn.Ed_LastStockDate.AddMonths(1))
                            {
                                shipmentCnt += stockListResultWork.ShipmentCnt;
                                dr[MAZAI02074EA.ctCol_ShipmentCnt] = shipmentCnt; // 出荷数
                            }
                            else if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate.AddMonths(-1))
                            {
                                shipmentCntBefore1 += stockListResultWork.ShipmentCnt;
                                dr[MAZAI02074EA.ctCol_ShipmentCntBefore1] = shipmentCntBefore1;
                            }
                            else if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate.AddMonths(-2))
                            {
                                shipmentCntBefore2 += stockListResultWork.ShipmentCnt;
                                dr[MAZAI02074EA.ctCol_ShipmentCntBefore2] = shipmentCntBefore2;
                            }
                            else if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate.AddMonths(-3))
                            {
                                shipmentCntBefore3 += stockListResultWork.ShipmentCnt;
                                dr[MAZAI02074EA.ctCol_ShipmentCntBefore3] = shipmentCntBefore3;
                            }
                        }
                        else
                        {
                            if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate && stockListResultWork.AddUpYearMonth < stockListCndtn.Ed_LastStockDate.AddMonths(1))
                            {
                                // ---ADD 2009/04/03 不具合対応[12373] --------------------------------->>>>>
                                shipmentCnt += stockListResultWork.ShipmentCnt;
                                dr[MAZAI02074EA.ctCol_ShipmentCnt] = shipmentCnt; // 出荷数
                                // ---ADD 2009/04/03 不具合対応[12373] ---------------------------------<<<<<
                                shipmentPrice += stockListResultWork.ShipmentPrice;
                                dr[MAZAI02074EA.ctCol_ShipmentPrice] = shipmentPrice; // 出荷金額
                            }
                            else if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate.AddMonths(-1))
                            {
                                shipmentPriceBefore1 += stockListResultWork.ShipmentPrice;
                                dr[MAZAI02074EA.ctCol_ShipmentPriceBefore1] = shipmentPriceBefore1;
                            }
                            else if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate.AddMonths(-2))
                            {
                                shipmentPriceBefore2 += stockListResultWork.ShipmentPrice;
                                dr[MAZAI02074EA.ctCol_ShipmentPriceBefore2] = shipmentPriceBefore2;
                            }
                            else if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate.AddMonths(-3))
                            {
                                shipmentPriceBefore3 += stockListResultWork.ShipmentPrice;
                                dr[MAZAI02074EA.ctCol_ShipmentPriceBefore3] = shipmentPriceBefore3;
                            }
                        }
                        // --- ADD 2009/01/29 --------------------------------<<<<<

                        if (stockListResultWork.AddUpYearMonth >= stockListCndtn.St_LastStockDate.AddMonths(-6)) // ADD 2009/01/29
                        {
                            stockTotalCnt += stockListResultWork.ShipmentCnt;
                            stockTotalPrice += stockListResultWork.ShipmentPrice;

                            dr[MAZAI02074EA.ctCol_ShipmentCntBeforeTotal] = stockTotalCnt;
                            dr[MAZAI02074EA.ctCol_ShipmentPriceBeforeTotal] = stockTotalPrice;
                        }

                        dr[MAZAI02074EA.ctCol_StockCreateDate] = this.GetDateText(stockListResultWork.StockCreateDate); // 在庫登録日
                        /* ---DEL 2009/03/13 不具合対応[12371] ---------------------------------------------------------------->>>>>
                        dr[MAZAI02074EA.ctCol_Sort_WarehouseCode] = stockListResultWork.WarehouseCode;       // ソート用　倉庫コード
                        dr[MAZAI02074EA.ctCol_Sort_GoodsMakerCd] = stockListResultWork.GoodsMakerCd;         // ソート用　商品メーカーコード
                           ---DEL 2009/03/13 不具合対応[12371] ----------------------------------------------------------------<<<<< */
                        // ---ADD 2009/03/13 不具合対応[12371] ---------------------------------------------------------------->>>>>
                        dr[MAZAI02074EA.ctCol_Sort_WarehouseCode] = stockListResultWork.WarehouseCode.Trim().PadLeft(4,'0');    // ソート用　倉庫コード
                        dr[MAZAI02074EA.ctCol_Sort_GoodsMakerCd] = stockListResultWork.GoodsMakerCd.ToString("0000");           // ソート用　商品メーカーコード
                        //dr[MAZAI02074EA.ctCol_Sort_CustomerCode] = stockListResultWork.StockSupplierCode.ToString("000000");    // ソート用　仕入先コード         //DEL 2009/03/25 不具合対応[12797]
                        // ---ADD 2009/03/13 不具合対応[12371] ----------------------------------------------------------------<<<<<

                        dr[MAZAI02074EA.ctCol_Sort_GoodsNo] = stockListResultWork.GoodsNo;                   // ソート用　商品番号
                        dr[MAZAI02074EA.ctCol_Sort_WarehouseShelfNo] = stockListResultWork.WarehouseShelfNo; // ソート用　倉庫棚番

                        // 棚番ブレイク設定
                        string warehouseShelfNoBreak = stockListResultWork.WarehouseShelfNo.PadRight(8, ' ').Substring(0, breakLength);
                        dr[MAZAI02074EA.ctCol_WarehouseShelfNoBreak] = warehouseShelfNoBreak;      // 倉庫棚番ブレイク
                        dr[MAZAI02074EA.ctCol_Sort_WarehouseShelfNoBreak] = warehouseShelfNoBreak; // ソート用　倉庫棚番ブレイク
                        //--- ADD 2008/08/01 ----------<<<<<
                    }

                    //this._printDataSet.Tables[StockListDataTable].Rows.Add(dr);           //DEL 2009/04/03 不具合対応[12373]
                    // ---ADD 2009/04/03 不具合対応[12373] ----------------------------------------->>>>>
                    cnt = double.Parse(dr[MAZAI02074EA.ctCol_ShipmentCnt].ToString());
                    if (stockListCndtn.St_ShipmentPosCnt <= cnt && cnt <= stockListCndtn.Ed_ShipmentPosCnt)
                    {
                        // 作成した明細を追加
                        this._printDataSet.Tables[StockListDataTable].Rows.Add(dr);
                    }
                    // ---ADD 2009/04/03 不具合対応[12373] -----------------------------------------<<<<<

                    this._printDataSet.Tables[StockListDataTable].CaseSensitive = true;             //ADD 2009/03/13 不具合対応[12480]

                    status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL;
                }             
                else
                {
                    status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                #endregion
            }			
			catch (Exception ex)
			{
				status  = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				message = ex.Message;
			}

      		return status;    
		}
		
		#endregion

        # region テスト用

        private object GetTestData()
        {
            ArrayList list = new ArrayList();

            StockListResultWork work = new StockListResultWork();

            work.GoodsMakerCd           = 0001;                                     // メーカーコード
            work.GoodsNo                = "0002";                                   // 商品コード
            work.GoodsName              = "ABCD";                                   // 商品名称
            work.ShipmentPosCnt         = 100;                                      // 出荷可能数
            work.ShipmentCnt            = 50;                                       // 出荷数(未計上)
            work.BLGoodsCode            = 0003;                                     // ＢＬ商品コード
            work.WarehouseCode          = "01";		                                // 倉庫コード
            work.WarehouseName          = "AAAAA";		                            // 倉庫名称
            work.WarehouseShelfNo       = "777";                                    // 倉庫棚番
            work.MinimumStockCnt        = 1;                                        // 最低在庫数
            work.MaximumStockCnt        = 300;                                      // 最高在庫数
            work.StockSupplierCode      = 11;		                                // 在庫発注先コード
            work.SupplierSnm            = "BBBBB";		                            // 仕入先略称
            //work.DuplicationShelfNo1    = "1";                                      // 部品管理区分１
            //work.DuplicationShelfNo2    = "2";                                      // 部品管理区分２
            work.PartsManagementDivide1 = "1";                                      // 部品管理区分１
            work.PartsManagementDivide2 = "2";                                      // 部品管理区分２
            work.AddUpYearMonth = TDateTime.LongDateToDateTime(20080801);   // 計上年月
            work.ShipmentPrice          = 10000;                                    // 出荷金額
            work.StockCreateDate        = TDateTime.LongDateToDateTime(20080801);   // 在庫登録日

            list.Add(work);

            StockListResultWork work1 = new StockListResultWork();

            work1.GoodsMakerCd          = 0001;                                     // メーカーコード
            work1.GoodsNo               = "0002";                                   // 商品コード
            work1.GoodsName             = "ABCD";                                   // 商品名称
            work1.ShipmentPosCnt        = 100;                                      // 出荷可能数
            work1.ShipmentCnt           = 50;                                       // 出荷数(未計上)
            work1.BLGoodsCode           = 0003;                                     // ＢＬ商品コード
            work1.WarehouseCode         = "01";		                                // 倉庫コード
            work1.WarehouseName         = "AAAAA";		                            // 倉庫名称
            work1.WarehouseShelfNo      = "777";                                    // 倉庫棚番
            work1.MinimumStockCnt       = 1;                                        // 最低在庫数
            work1.MaximumStockCnt       = 300;                                      // 最高在庫数
            work1.StockSupplierCode     = 11;		                                // 在庫発注先コード
            work1.SupplierSnm           = "BBBBB";		                            // 仕入先略称
            //work1.DuplicationShelfNo1   = "1";                                      // 部品管理区分１
            //work1.DuplicationShelfNo2   = "2";                                      // 部品管理区分２
            work1.PartsManagementDivide1 = "1";                                     // 部品管理区分１
            work1.PartsManagementDivide2 = "2";                                     // 部品管理区分２
            work1.AddUpYearMonth = TDateTime.LongDateToDateTime(20080701);   // 計上年月
            work1.ShipmentPrice         = 10000;                                    // 出荷金額
            work1.StockCreateDate       = TDateTime.LongDateToDateTime(20080701);   // 在庫登録日

            list.Add(work1);

            StockListResultWork work2 = new StockListResultWork();

            work2.GoodsMakerCd          = 0001;                                     // メーカーコード
            work2.GoodsNo               = "0002";                                   // 商品コード
            work2.GoodsName             = "ABCD";                                   // 商品名称
            work2.ShipmentPosCnt        = 100;                                      // 出荷可能数
            work2.ShipmentCnt           = 50;                                       // 出荷数(未計上)
            work2.BLGoodsCode           = 0003;                                     // ＢＬ商品コード
            work2.WarehouseCode         = "02";		                                // 倉庫コード
            work2.WarehouseName         = "VWXYZ";		                            // 倉庫名称
            work2.WarehouseShelfNo      = "777";                                    // 倉庫棚番
            work2.MinimumStockCnt       = 1;                                        // 最低在庫数
            work2.MaximumStockCnt       = 300;                                      // 最高在庫数
            work2.StockSupplierCode     = 11;		                                // 在庫発注先コード
            work2.SupplierSnm           = "BBBBB";		                            // 仕入先略称
            //work2.DuplicationShelfNo1   = "1";                                      // 部品管理区分１
            //work2.DuplicationShelfNo2   = "2";                                      // 部品管理区分２
            work2.PartsManagementDivide1 = "1";                                     // 部品管理区分１
            work2.PartsManagementDivide2 = "2";                                     // 部品管理区分２
            work2.AddUpYearMonth = TDateTime.LongDateToDateTime(20080601);   // 計上年月
            work2.ShipmentPrice         = 10000;                                    // 出荷金額
            work2.StockCreateDate       = TDateTime.LongDateToDateTime(20080701);   // 在庫登録日

            list.Add(work2);


            StockListResultWork work3 = new StockListResultWork();

            work3.GoodsMakerCd          = 0002;                                     // メーカーコード
            work3.GoodsNo               = "0003";                                   // 商品コード
            work3.GoodsName             = "BCDE";                                   // 商品名称
            work3.ShipmentPosCnt        = 100;                                      // 出荷可能数
            work3.ShipmentCnt           = 50;                                       // 出荷数(未計上)
            work3.BLGoodsCode           = 0004;                                     // ＢＬ商品コード
            work3.WarehouseCode         = "03";		                                // 倉庫コード
            work3.WarehouseName         = "VWXYZ";		                            // 倉庫名称
            work3.WarehouseShelfNo      = "777";                                    // 倉庫棚番
            work3.MinimumStockCnt       = 1;                                        // 最低在庫数
            work3.MaximumStockCnt       = 300;                                      // 最高在庫数
            work3.StockSupplierCode     = 12;		                                // 在庫発注先コード
            work3.SupplierSnm           = "CCCC";		                            // 仕入先略称
            //work3.DuplicationShelfNo1   = "1";                                      // 部品管理区分１
            //work3.DuplicationShelfNo2   = "2";                                      // 部品管理区分２
            work3.PartsManagementDivide1 = "1";                                     // 部品管理区分１
            work3.PartsManagementDivide2 = "2";                                     // 部品管理区分２
            work3.AddUpYearMonth = TDateTime.LongDateToDateTime(20080601);   // 計上年月
            work3.ShipmentPrice         = 10000;                                    // 出荷金額
            work3.StockCreateDate       = TDateTime.LongDateToDateTime(20080701);   // 在庫登録日

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

        // ===================================================================================== //
        // 内部使用関数
        // ===================================================================================== //
        #region private method
		
		private void DataSetColumnConstruction(ref DataSet ds)
		{
			// 抽出基本データセットスキーマ設定
            Broadleaf.Application.UIData.MAZAI02074EA.SettingDataSet(ref ds);
        }

        /// <summary>
        /// 日付文字列取得
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private string GetDateText(DateTime dateTime)
        {
            if (dateTime != DateTime.MinValue)
            {
                //return dateTime.ToString("yy/MM/dd");         //DEL 2008/10/08 書式変更
                return dateTime.ToString("yyyy/MM/dd");         //ADD 2008/10/08
            }
            else
            {
                return string.Empty;
            }
        }

        // ---ADD 2009/04/03 不具合対応[12373] -------------------------------------------------------->>>>>
        /// <summary>
        /// ソート設定
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int ComparisonByKey1(object x, object y)
        {
            //※string.CompareOrdinal：大文字、小文字を区別する

            StockListResultWork stockListResultWork1 = (StockListResultWork)x;
            StockListResultWork stockListResultWork2 = (StockListResultWork)y;

            int ret;

            // 倉庫
            ret = string.CompareOrdinal(stockListResultWork1.WarehouseCode.Trim().PadLeft(4, '0'),
                                        stockListResultWork2.WarehouseCode.Trim().PadLeft(4, '0'));
            if (ret != 0)
            {
                return ret;
            }
            // 仕入先
            ret = string.CompareOrdinal(stockListResultWork1.StockSupplierCode.ToString("000000"),
                                        stockListResultWork2.StockSupplierCode.ToString("000000"));
            if (ret != 0)
            {
                return ret;
            }
            // メーカー
            ret = string.CompareOrdinal(stockListResultWork1.GoodsMakerCd.ToString("0000"),
                                        stockListResultWork2.GoodsMakerCd.ToString("0000"));
            if (ret != 0)
            {
                return ret;
            }

            // 品番
            return string.CompareOrdinal(stockListResultWork1.GoodsNo, stockListResultWork2.GoodsNo);

        }
        // ---ADD 2009/04/03 不具合対応[12373] --------------------------------------------------------<<<<<

        /* ---DEL 2009/04/03 不具合対応[12373] -------------------------------------------------------->>>>>
        // --- ADD 2009/01/29 -------------------------------->>>>>
        /// <summary>
        /// ソート設定
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int ComparisonByKey(object x, object y)
        {
            // 印字用のソート設定は2071Eでやっているので、キー項目順は適当でよい
            StockListResultWork stockListResultWork1 = (StockListResultWork)x;
            StockListResultWork stockListResultWork2 = (StockListResultWork)y;

            if (stockListResultWork1.WarehouseCode.Trim().PadLeft(4, '0')
                .CompareTo(stockListResultWork2.WarehouseCode.Trim().PadLeft(4, '0')) == 0)
            {
                if (stockListResultWork1.StockSupplierCode.ToString("000000")
                    .CompareTo(stockListResultWork2.StockSupplierCode.ToString("000000")) == 0)
                {
                    if (stockListResultWork1.GoodsMakerCd.ToString("0000")
                        .CompareTo(stockListResultWork2.GoodsMakerCd.ToString("0000")) == 0)
                    {
                        return stockListResultWork1.GoodsNo
                        .CompareTo(stockListResultWork2.GoodsNo);
                    }
                    else
                    {
                        return stockListResultWork1.GoodsMakerCd.ToString("0000")
                        .CompareTo(stockListResultWork2.GoodsMakerCd.ToString("0000"));
                    }
                }
                else
                {
                    return stockListResultWork1.StockSupplierCode.ToString("000000")
                    .CompareTo(stockListResultWork2.StockSupplierCode.ToString("000000"));
                }
            }
            else
            {
                return stockListResultWork1.WarehouseCode.Trim().PadLeft(4, '0')
                .CompareTo(stockListResultWork2.WarehouseCode.Trim().PadLeft(4, '0'));
            }
        }
        // --- ADD 2009/01/29 --------------------------------<<<<<
           ---DEL 2009/04/03 不具合対応[12373] --------------------------------------------------------<<<<< */
        #endregion

        // --- ADD 2008/10/08 ---------------------------------------------------->>>>>
        /// <summary>
        /// メーカー名称取得
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>メーカー名称</returns>
        private string GetMakerName(string enterpriseCode, int makerCode)
        {
            if (makerCode == 0)
            {
                //return string.Empty;      //DEL 2009/03/25 不具合対応[12797]
                return "未登録";            //ADD 2009/03/25 不具合対応[12797]
            }

            // アクセスクラスインスタンス化
            if (this._makerAcs == null)
            {
                this._makerAcs = new MakerAcs();
            }

            // 読み込み
            MakerUMnt makerUMnt = null;
            //int status = this._makerAcs.Read(out makerUMnt, enterpriseCode, makerCode);       //DEL 2009/04/13 不具合対応[13162]
            int status = this._goodsAcs.GetMaker(enterpriseCode, makerCode, out makerUMnt);     //ADD 2009/04/13 不具合対応[13162]
            if (status == 0)
            {
                //return makerUMnt.MakerShortName.TrimEnd();        //DEL 2009/03/25 不具合対応[12797]
                return makerUMnt.MakerName.TrimEnd();               //ADD 2009/03/25 不具合対応[12797]
            }
            else
            {
                //return string.Empty;      //DEL 2009/03/25 不具合対応[12797]
                return "未登録";            //ADD 2009/03/25 不具合対応[12797]
            }
        }

        // ---ADD 2009/03/25 不具合対応[12797] --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 商品管理情報マスタ取得
        /// </summary>
        /// <param name="stockListResultWork"></param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="supplierSnm">仕入先略称</param>
        private void GetGoodsMngInfo(StockListResultWork stockListResultWork, out int supplierCd, out string supplierSnm)
        {
            supplierCd = 0;
            supplierSnm = "";

            // ---ADD 2009/06/17 不具合対応[13530] --------------------------------->>>>>
            //中分類取得
            int goodsMGroup = 0;
            BLGoodsCdUMnt blGoodsCdUMnt = null;
            this._goodsAcs.GetBLGoodsCd(stockListResultWork.BLGoodsCode, out blGoodsCdUMnt);
            if (blGoodsCdUMnt != null)
            {
                BLGroupU blGroupU = null;
                this._goodsAcs.GetBLGroup(LoginInfoAcquisition.EnterpriseCode, blGoodsCdUMnt.BLGloupCode, out blGroupU);
                if (blGroupU != null)
                {
                    goodsMGroup = blGroupU.GoodsMGroup;
                }
            }
            // ---ADD 2009/06/17 不具合対応[13530] ---------------------------------<<<<<

            GoodsUnitData goodsUnitData = new GoodsUnitData();
            goodsUnitData.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            //goodsUnitData.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;      //DEL 2009/06/12 不具合対応[13447]
            goodsUnitData.SectionCode = stockListResultWork.SectionCode;                        //ADD 2009/06/12 不具合対応[13447]
            goodsUnitData.GoodsMakerCd = stockListResultWork.GoodsMakerCd;
            goodsUnitData.GoodsNo = stockListResultWork.GoodsNo;
            goodsUnitData.BLGoodsCode = stockListResultWork.BLGoodsCode;
            goodsUnitData.GoodsMGroup = goodsMGroup;                                            //ADD 2009/06/17 不具合対応[13530]

            this._goodsAcs.GetGoodsMngInfo(ref goodsUnitData);
            //this._goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData);         //DEL 2009/04/13 不具合対応[13162]

            supplierCd = goodsUnitData.SupplierCd;
            if (supplierCd == 0)
            {
                supplierSnm = "未登録";
            }
            else
            {
                //supplierSnm = goodsUnitData.SupplierSnm;                                  //DEL 2009/04/13 不具合対応[13162]
                // ---ADD 2009/04/13 不具合対応[13162] -------------------------------------------------------------------->>>>>
                SupplierWork supplierWork = null;
                int status = this._goodsAcs.GetSupplier(LoginInfoAcquisition.EnterpriseCode, goodsUnitData.SupplierCd, out supplierWork);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    supplierSnm = supplierWork.SupplierSnm;
                }
                else
                {
                    supplierSnm = string.Empty;
                }
                // ---ADD 2009/04/13 不具合対応[13162] --------------------------------------------------------------------<<<<<
            }
        }
        // ---ADD 2009/03/25 不具合対応[12797] ---------------------------------------------------------------------<<<<<

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
        // --- ADD 2008/10/08 ----------------------------------------------------<<<<<
    }
}

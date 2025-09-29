//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：棚卸関連一覧表(0：棚卸調査表、1：棚卸差異表、2：棚卸表)
// プログラム概要   ：棚卸関連一覧表を印刷・PDF出力を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2008/10/08     修正内容：Partsman用に変更
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：忍 幸史
// 修正日    2009/03/06     修正内容：障害ID:12229対応　棚卸数・棚卸金額は四捨五入に変更
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/16     修正内容：Mantis【13141】残案件No.19 端数処理
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：照田 貴志
// 修正日    2009/05/13     修正内容：不具合対応[13259]
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：照田 貴志
// 修正日    2009/05/21     修正内容：不具合対応[13261][13262]
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：長内 数馬
// 修正日    2009/09/15     修正内容：不具合対応[13918]
// ---------------------------------------------------------------------//
// 管理番号                 作成担当 : 呉元嘯
// 修 正 日  2009/12/04     修正内容 : 不具合対応(PM.NS保守依頼③対応)
// ---------------------------------------------------------------------//
// 管理番号                 作成担当 : 張凱
// 修 正 日  2009/12/07     修正内容 : 不具合対応(PM.NS保守依頼③対応)
// ---------------------------------------------------------------------//
// 管理番号  10600008-00    作成担当 : 呉元嘯
// 修 正 日  2010/02/20     修正内容 : 不具合対応(PM1005)
// ---------------------------------------------------------------------//
// 管理番号  10600008-00    作成担当 : 呉元嘯
// 修 正 日  2010/03/02     修正内容 : 不具合対応(PM1005)
// ---------------------------------------------------------------------//
// 管理番号  10600008-00    作成担当 : liyp
// 修 正 日  2011/01/11     修正内容 : 不具合対応(PM1101B)
// ---------------------------------------------------------------------//
// 管理番号                 作成担当 : 田建委
// 修 正 日  2011/02/10     修正内容 : redmine#18865 棚卸障害対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当 : liyp
// 修 正 日  2011/02/10     修正内容 : redmine#18871 棚卸障害対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当 : 田建委
// 修 正 日  2011/02/17     修正内容 : redmine#19025 抽出時間について
// ---------------------------------------------------------------------//
// 管理番号                 作成担当 : 陳建明
// 修 正 日  2011/11/28     修正内容 : Redmine #8073 棚卸障害対応
// ---------------------------------------------------------------------//
// 管理番号                 作成担当 : 李小路
// 修 正 日  2012/07/20     修正内容 : redmine#31158 「棚卸差異表」のサーバー負荷軽減と速度アップの調査
// ---------------------------------------------------------------------//
// 管理番号  10801804-00    作成担当 : yangyi
// 修 正 日  2013/03/01     修正内容 : 20130326配信分の対応、Redmine#34175
//                                     棚卸業務のサーバー負荷軽減
//----------------------------------------------------------------------------//
// 管理番号  11000606-00 作成担当 : licb
// 作 成 日  K2014/03/10 修正内容 : 信越自動車商会個別開発 テキスト出力機能を追加する                                 
//----------------------------------------------------------------------------//
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;//add 2011/11/28 陳建明 Redmine #8073
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// 棚卸関連一覧表アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 棚卸関連一覧表にアクセスするクラスです。</br>
    /// <br>Programer  : 23010　中村　仁</br>
    /// <br>Date       : 2007.04.09</br>
    /// <br>Update Note: 2007.09.14 980035 金沢 貞義</br>
    /// <br>			 ・DC.NS対応</br>
    /// <br>Update Note: 2008.02.13 980035 金沢 貞義</br>
    /// <br>			 ・棚卸実施日対応（DC.NS対応）</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : PM.NS対応</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date	   : 2008.10.08</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : 障害ID:12229対応　棚卸数・棚卸金額は四捨五入に変更</br>
    /// <br>Programmer : 30414 忍</br>
    /// <br>Date	   : 2009.03.06</br>
    /// <br>           : 2009/04/16 犬飼 　　　不具合対応[13141]</br>
    /// <br>           : 2009/05/13 照田 貴志　不具合対応[13259]</br>
    /// <br>           : 2009/05/21 照田 貴志　不具合対応[13261][13262]</br>
    /// <br>Update Note: 2009/12/04 呉元嘯</br>
    /// <br>			 不具合対応(PM.NS保守依頼③対応)</br>
    /// <br>Update Note: 2009/12/07 張凱</br>
    /// <br>			 不具合対応(PM.NS保守依頼③対応)</br>
    /// <br>Update Note: 2010/02/20 呉元嘯</br>
    /// <br>			 不具合対応(PM1005)</br>
    /// <br>Update Note: 2010/03/02 呉元嘯</br>
    /// <br>			 不具合対応(PM1005)</br>
    /// <br>Update Note: 2011/01/11 liyp</br>
    /// <br>			 不具合対応(PM1101B)</br>
    /// <br>Update Note: 2011/02/10 田建委</br>
    /// <br>             redmine#18865 棚卸障害対応</br>
    /// <br>Update Note: 2011/02/17 田建委</br>
    /// <br>             redmine#19025 抽出時間について</br>
    /// <br>Update Note: 2011/11/28 陳建明</br>
    /// <br>             Redmine #8073 棚卸障害対応</br>
    /// <br>Update Note: 2012/07/20 李小路</br>
    /// <br>             redmine#31158 「棚卸差異表」のサーバー負荷軽減と速度アップの調査</br>
    /// <br>Update Note: K2014/03/10 licb</br>
    ///	<br>			 信越自動車商会個別開発 テキスト出力機能を追加する</br>
    /// </remarks>
	public class InventoryListCmnAcs
	{
  	    // ===================================================================================== //
        //  外部提供定数
        // ===================================================================================== //
        // 2008.10.14 30413 犬飼 未使用のため削除 >>>>>>START
	    #region public constant
        ///// <summary>全拠点レコード用拠点コード</summary>
        //public const string CT_AllSectionCode = "000000";
	    #endregion
        // 2008.10.14 30413 犬飼 未使用のため削除 <<<<<<END
	    
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

        ///// <summary>価格情報マスタキャッシュ</summary>// DEL 2010/03/02
        //private static List<List<GoodsUnitData>> _goodsUnitDataListList;// DEL 2010/03/02

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
        private StockMngTtlSt _stockMngTtlSt = null;                    //在庫管理全体設定 //ADD 2011/01/11
        // ---ADD 2009/05/13 不具合対応[13259] ----------------->>>>>
        /// <summary>拠点情報設定アクセスクラス</summary>
        private SecInfoSetAcs _secInfoSetAcs = null;
        // ---ADD 2009/05/13 不具合対応[13259] -----------------<<<<<

        private GoodsAcs _goodsAcs; //ADD yangyi 2013/03/01 Redmine#34175 

        #endregion
        
        // ===================================================================================== //
        //  内部使用定数
        // ===================================================================================== //
        #region private constant

        /// <summary>棚卸関連一覧表データテーブル名</summary>
        private const string InventoryListDataTable = MAZAI02114EA.InventoryListDataTable;
        /// <summary>棚卸関連一覧表バッファデータテーブル名</summary>
        public const string InventoryListCommonBuffDataTable = MAZAI02114EA.InventoryListCommonBuffDataTable;
              
        #endregion
        
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region コンストラクター
        /// <summary>
        /// 棚卸関連一覧表アクセスクラスコンストラクター
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programer  : 23010 中村　仁</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        public InventoryListCmnAcs()
        {
			// 印刷用DataSet
		    this._printDataSet	= new DataSet();
		    DataSetColumnConstruction(ref this._printDataSet);

            //拠点情報設定アクセスクラス
            this._secInfoSetAcs = new SecInfoSetAcs();          //ADD 2009/05/13 不具合対応[13259]
            this._goodsAcs = null;                              //ADD yangyi 2013/03/01 Redmine#34175

        }
        #endregion

        // ===================================================================================== //
        // 静的コンストラクタ
        // ===================================================================================== //
        #region 静的コンストラクター

		/// <summary>
        /// 棚卸関連一覧表アクセスクラス静的コンストラクター
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programer  : 23010　中村　仁</br>
        /// <br>Date       : 2007.04.09</br>
        /// </remarks>
        static InventoryListCmnAcs()
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
		/// <br>Date       : 2007.04.09</br>
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
		/// <br>Date       : 2007.04.09</br>
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
        /// 棚卸関連一覧表データ初期化処理
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : Static情報を初期化します。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.04.09</br>
		/// </remarks>
		public void InitializeCustomerLedger()
		{
     		// --テーブル行初期化-----------------------
			// 抽出結果データテーブルをクリア
            if (this._printDataSet.Tables[InventoryListDataTable] != null)
			{
                this._printDataSet.Tables[InventoryListDataTable].Rows.Clear();
			}
			// 抽出結果バッファデータテーブルをクリア
            if (this._printDataSet.Tables[InventoryListCommonBuffDataTable] != null)
			{
                this._printDataSet.Tables[InventoryListCommonBuffDataTable].Rows.Clear();
			}
		}

        // 2008.10.14 30413 犬飼 抽出メソッドを変更 >>>>>>START
        #region 既存のSearchメソッドを削除
        ///// <summary>
        ///// 棚卸関連一覧表データ取得処理
        ///// </summary>
        ///// <param name="inventSearchCndtnUI"></param>
        ///// <param name="message">エラーメッセージ</param>
        ///// <returns></returns>
        ///// <remarks>
        ///// <br>Note       : 対象範囲の棚卸関連一覧表データを取得します。</br>
        ///// <br>Programmer : 23010 中村　仁</br>
        ///// <br>Date       : 2007.04.09</br>
        ///// </remarks>
        //public int Search(InventSearchCndtnUI inventSearchCndtnUI, out string message)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    message    = "";
        //    ConstantManagement.LogicalMode logicalmode = new ConstantManagement.LogicalMode();
        //    IInventInputSearchDB _iInventInputSearchDB = (IInventInputSearchDB)MediationInventInputSearchDB.GetInventInputSearchDB();
        //    object inventInputRltWorkObj = null;
				
        //    try
        //    {           
        //        //StaticMemory　初期化
        //        InitializeCustomerLedger();

        //        //TODO:リモートができたら実装
        //        InventInputSearchCndtnWork inventInputSearchCndtnWork = new InventInputSearchCndtnWork();
				
        //        inventInputSearchCndtnWork.EnterpriseCode = inventSearchCndtnUI.EnterpriseCode;                     // 企業コード
        //        inventInputSearchCndtnWork.SectionCode = inventSearchCndtnUI.SectionCode;                           // 拠点コード
        //        inventInputSearchCndtnWork.St_MakerCode = inventSearchCndtnUI.St_MakerCode;                         // メーカーコード開始
        //        inventInputSearchCndtnWork.Ed_MakerCode = inventSearchCndtnUI.Ed_MakerCode;                         // メーカーコード終了
        //        inventInputSearchCndtnWork.St_GoodsNo = inventSearchCndtnUI.St_GoodsNo;                             // 商品コード開始
        //        inventInputSearchCndtnWork.Ed_GoodsNo = inventSearchCndtnUI.Ed_GoodsNo;                             // 商品コード終了
        //        // 2007.09.14 削除 >>>>>>>>>>>>>>>>>>>>
        //        //inventInputSearchCndtnWork.St_CellphoneModelCode = inventSearchCndtnUI.St_CellphoneModelCode;       // 機種コード開始
        //        //inventInputSearchCndtnWork.Ed_CellphoneModelCode = inventSearchCndtnUI.Ed_CellphoneModelCode;       // 機種コード終了
        //        //inventInputSearchCndtnWork.St_CarrierCode        = inventSearchCndtnUI.St_CarrierCode;              // キャリアコード
        //        //inventInputSearchCndtnWork.Ed_CarrierCode        = inventSearchCndtnUI.Ed_CarrierCode;              // キャリアコード
        //        // 2007.09.14 削除 <<<<<<<<<<<<<<<<<<<<
        //        inventInputSearchCndtnWork.TargetDateExtraDiv = inventSearchCndtnUI.TargetDateExtraDiv;             // 抽出対象日付区分
        //        inventInputSearchCndtnWork.St_LargeGoodsGanreCode = inventSearchCndtnUI.St_LargeGoodsGanreCode;     // 商品大分類コード開始
        //        inventInputSearchCndtnWork.Ed_LargeGoodsGanreCode = inventSearchCndtnUI.Ed_LargeGoodsGanreCode;     // 商品大分類コード終了
        //        inventInputSearchCndtnWork.St_MediumGoodsGanreCode = inventSearchCndtnUI.St_MediumGoodsGanreCode;   // 商品中分類コード開始
        //        inventInputSearchCndtnWork.Ed_MediumGoodsGanreCode = inventSearchCndtnUI.Ed_MediumGoodsGanreCode;   // 商品中分類コード終了
        //        inventInputSearchCndtnWork.St_WarehouseCode = inventSearchCndtnUI.St_WarehouseCode;                 // 倉庫コード開始
        //        inventInputSearchCndtnWork.Ed_WarehouseCode = inventSearchCndtnUI.Ed_WarehouseCode;                 // 倉庫コード終了
        //        // 2007.09.14 修正 >>>>>>>>>>>>>>>>>>>>
        //        //inventInputSearchCndtnWork.CompanyStockExtraDiv = inventSearchCndtnUI.CompanyStockExtraDiv;         // 自社在庫抽出区分
        //        //inventInputSearchCndtnWork.TrustStockExtraDiv = inventSearchCndtnUI.TrustStockExtraDiv;             // 受託在庫抽出区分
        //        //inventInputSearchCndtnWork.EntrustCmpStockExtraDiv = inventSearchCndtnUI.EntrustCmpStockExtraDiv;   // 委託（自社）在庫抽出区分
        //        //inventInputSearchCndtnWork.EntrustTrtStockExtraDiv = inventSearchCndtnUI.EntrustTrtStockExtraDiv;   // 委託（受託）在庫抽出区分
        //        //inventInputSearchCndtnWork.St_CarrierEpCode = inventSearchCndtnUI.St_CarrierEpCode;                 // 事業者コード開始
        //        //inventInputSearchCndtnWork.Ed_CarrierEpCode = inventSearchCndtnUI.Ed_CarrierEpCode;                 // 事業者コード終了
        //        inventInputSearchCndtnWork.St_WarehouseShelfNo = inventSearchCndtnUI.St_WarehouseShelfNo;           // 棚番開始
        //        inventInputSearchCndtnWork.Ed_WarehouseShelfNo = inventSearchCndtnUI.Ed_WarehouseShelfNo;           // 棚番終了
        //        inventInputSearchCndtnWork.St_DetailGoodsGanreCode = inventSearchCndtnUI.St_DetailGoodsGanreCode;   // 商品区分詳細コード開始
        //        inventInputSearchCndtnWork.Ed_DetailGoodsGanreCode = inventSearchCndtnUI.Ed_DetailGoodsGanreCode;   // 商品区分詳細コード終了
        //        inventInputSearchCndtnWork.St_EnterpriseGanreCode = inventSearchCndtnUI.St_EnterpriseGanreCode;     // 自社分類コード開始
        //        inventInputSearchCndtnWork.Ed_EnterpriseGanreCode = inventSearchCndtnUI.Ed_EnterpriseGanreCode;     // 自社分類コード終了
        //        inventInputSearchCndtnWork.St_BLGoodsCode = inventSearchCndtnUI.St_BLGoodsCode;                     // ＢＬ商品コード開始
        //        inventInputSearchCndtnWork.Ed_BLGoodsCode = inventSearchCndtnUI.Ed_BLGoodsCode;                     // ＢＬ商品コード終了
        //        // 2007.09.14 修正 <<<<<<<<<<<<<<<<<<<<
        //        inventInputSearchCndtnWork.St_CustomerCode = inventSearchCndtnUI.St_CustomerCode;                   // 得意先(仕入先)コード開始
        //        inventInputSearchCndtnWork.Ed_CustomerCode = inventSearchCndtnUI.Ed_CustomerCode;                   // 得意先(仕入先)コード終了
        //        inventInputSearchCndtnWork.St_ShipCustomerCode = inventSearchCndtnUI.St_ShipCustomerCode;           // 出荷先得意先(委託先)コード開始
        //        inventInputSearchCndtnWork.Ed_ShipCustomerCode = inventSearchCndtnUI.Ed_ShipCustomerCode;           // 出荷先得意先(委託先)コード終了
        //        inventInputSearchCndtnWork.St_InventoryPreprDay = TDateTime.LongDateToDateTime(inventSearchCndtnUI.St_InventoryPreprDay);   // 開始棚卸準備処理日付
        //        inventInputSearchCndtnWork.Ed_InventoryPreprDay = TDateTime.LongDateToDateTime(inventSearchCndtnUI.Ed_InventoryPreprDay);   // 終了棚卸準備処理日付
        //        // 2007.09.14 修正 >>>>>>>>>>>>>>>>>>>>
        //        //inventInputSearchCndtnWork.St_InventoryDay = TDateTime.LongDateToDateTime(inventSearchCndtnUI.St_InventoryDay);             // 開始棚卸実施日
        //        //inventInputSearchCndtnWork.Ed_InventoryDay = TDateTime.LongDateToDateTime(inventSearchCndtnUI.Ed_InventoryDay);             // 終了棚卸実施日
        //        inventInputSearchCndtnWork.InventoryDate = TDateTime.LongDateToDateTime(inventSearchCndtnUI.St_InventoryDay);               // 棚卸日
        //        // 2007.09.14 修正 <<<<<<<<<<<<<<<<<<<<
        //        inventInputSearchCndtnWork.St_InventorySeqNo = inventSearchCndtnUI.St_InventorySeqNo;               // 開始棚卸通番
        //        inventInputSearchCndtnWork.Ed_InventorySeqNo = inventSearchCndtnUI.Ed_InventorySeqNo;               // 終了棚卸通番
        //        inventInputSearchCndtnWork.DifCntExtraDiv = inventSearchCndtnUI.DifCntExtraDiv;                     // 差異分抽出区分
        //        inventInputSearchCndtnWork.StockCntZeroExtraDiv = inventSearchCndtnUI.StockCntZeroExtraDiv;         // 在庫数0抽出区分
        //        inventInputSearchCndtnWork.IvtStkCntZeroExtraDiv = inventSearchCndtnUI.IvtStkCntZeroExtraDiv;       // 棚卸在庫数0抽出区分
        //        // 2007.09.14 修正 >>>>>>>>>>>>>>>>>>>>
        //        //inventInputSearchCndtnWork.GrossPrintDiv = inventSearchCndtnUI.GrossPrintDiv;                       // 集計単位
        //        //inventInputSearchCndtnWork.SelectedPaperKind = inventSearchCndtnUI.SelctedPaperKindDiv;             // 帳票種類
        //        inventInputSearchCndtnWork.SelectedPaperKind = inventSearchCndtnUI.SelectedPaperKind;               // 帳票種類
        //        inventInputSearchCndtnWork.OutputAppointDiv = inventSearchCndtnUI.OutputAppointDiv;                 // 出力指定区分
        //        inventInputSearchCndtnWork.TargetDateExtraDiv = inventSearchCndtnUI.TargetDateExtraDiv;             // 抽出対象日付区分
        //        inventInputSearchCndtnWork.WarehouseDiv = 0;                                                        // 倉庫指定区分
        //        // 2007.09.14 修正 <<<<<<<<<<<<<<<<<<<<

        //        // 2008.02.13 修正 >>>>>>>>>>>>>>>>>>>>
        //        // 棚卸差異表
        //        if (inventSearchCndtnUI.SelectedPaperKind == 1)
        //        {
        //            inventInputSearchCndtnWork.CalcStockAmountDiv  = 1;                 // 在庫数算出フラグ
        //            inventInputSearchCndtnWork.CalcStockAmountDate = DateTime.MinValue; // 在庫数算出日付
        //        }
        //        // 2008.02.13 修正 <<<<<<<<<<<<<<<<<<<<
        //        object ob = inventInputSearchCndtnWork;
        //        //データ取得
        //        status = _iInventInputSearchDB.SearchPrint(out inventInputRltWorkObj, ob, 0, logicalmode);                      

        //        // リモートからデータの取得              
        //        #region
                             
                

        //        if (status == 0)
        //        {
        //            ArrayList retObjArr = new ArrayList();
        //            //棚卸データ検索結果をセット
        //            CustomSerializeArrayList cstmAl = inventInputRltWorkObj as  CustomSerializeArrayList;

        //            foreach (ArrayList workList in cstmAl)
        //            {                       
        //                if ((workList != null) && (workList.Count != 0))
        //                {
        //                    if (workList[0].GetType() == typeof(InventInputSearchResultWork))
        //                    {
        //                        foreach (InventInputSearchResultWork work in workList)
        //                        {
        //                            // 2008.02.13 修正 >>>>>>>>>>>>>>>>>>>>
        //                            // 出力指定区分チェック(棚卸調査表)
        //                            if (inventSearchCndtnUI.SelectedPaperKind == 0)
        //                            {
        //                                switch (inventSearchCndtnUI.OutputAppointDiv)
        //                                {
        //                                    case 0: // 全て
        //                                        {
        //                                            break;
        //                                        }
        //                                    case 1: // 棚卸未入力分のみ
        //                                        {
        //                                            if (work.InventoryDay != DateTime.MinValue) continue;
        //                                            break;
        //                                        }
        //                                    case 2: // 差異分のみ
        //                                        {
        //                                            if (work.InventoryTolerancCnt == 0) continue;
        //                                            break;
        //                                        }
        //                                    case 3: // 重複棚版有りのみ
        //                                        {
        //                                            if ((work.DuplicationShelfNo1 == string.Empty) &&
        //                                                (work.DuplicationShelfNo2 == string.Empty)) continue;
        //                                            break;
        //                                        }
        //                                }
        //                            }
        //                            // 2008.02.13 修正 <<<<<<<<<<<<<<<<<<<<
        //                            retObjArr.Add(work);
        //                        }
        //                    }
        //                }
        //            }

        //            //件数が0ならreturn
        //            if (retObjArr.Count == 0)
        //            {
        //                status = (int)ConstantManagement.DB_Status.ctDB_EOF;
        //                return status;
        //            }
                          
        //            //データセットへ展開                     
        //            foreach (InventInputSearchResultWork inventInputSearchResultWork in retObjArr)
        //            {
        //                DataRow dr = this._printDataSet.Tables[InventoryListDataTable].NewRow();
	                                     
        //                dr[MAZAI02114EA.ctCol_SectionCode] = inventInputSearchResultWork.SectionCode;　                 // 拠点コード
        //                dr[MAZAI02114EA.ctCol_SectionGuideNm] = inventInputSearchResultWork.SectionGuideNm;　           // 拠点ガイド名称
        //                dr[MAZAI02114EA.ctCol_InventorySeqNo] = inventInputSearchResultWork.InventorySeqNo;　           // 棚卸通番
        //                dr[MAZAI02114EA.ctCol_MakerCode] = inventInputSearchResultWork.GoodsMakerCd;　                  // メーカーコード
        //                dr[MAZAI02114EA.ctCol_MakerName] = inventInputSearchResultWork.MakerName;　                     // メーカー名称
        //                dr[MAZAI02114EA.ctCol_GoodsCode] = inventInputSearchResultWork.GoodsNo;　                       // 商品コード
        //                dr[MAZAI02114EA.ctCol_GoodsName] = inventInputSearchResultWork.GoodsName;　                     // 商品名称
        //                // 2007.09.14 削除 >>>>>>>>>>>>>>>>>>>>
        //                //dr[MAZAI02114EA.ctCol_CellphoneModelCode] = inventInputSearchResultWork.CellphoneModelCode;　   // 機種コード
        //                //dr[MAZAI02114EA.ctCol_CellphoneModelName] = inventInputSearchResultWork.CellphoneModelName;　   // 機種名称
        //                //dr[MAZAI02114EA.ctCol_CarrierCode] = inventInputSearchResultWork.CarrierCode;　                 // キャリアコード
        //                //dr[MAZAI02114EA.ctCol_CarrierName] = inventInputSearchResultWork.CarrierName;　                 // キャリア名称
        //                //dr[MAZAI02114EA.ctCol_SystematicColorCd] = inventInputSearchResultWork.SystematicColorCd;　     // 系統色コード
        //                //dr[MAZAI02114EA.ctCol_SystematicColorNm] = inventInputSearchResultWork.SystematicColorNm;　     // 系統色名称
        //                // 2007.09.14 削除 <<<<<<<<<<<<<<<<<<<<
        //                dr[MAZAI02114EA.ctCol_LargeGoodsGanreCode] = inventInputSearchResultWork.LargeGoodsGanreCode;　 // 商品大分類コード
        //                dr[MAZAI02114EA.ctCol_LargeGoodsGanreName] = inventInputSearchResultWork.LargeGoodsGanreName;　 // 商品大分類名称
        //                dr[MAZAI02114EA.ctCol_MediumGoodsGanreCode] = inventInputSearchResultWork.MediumGoodsGanreCode; // 商品中分類コード
        //                dr[MAZAI02114EA.ctCol_MediumGoodsGanreName] = inventInputSearchResultWork.MediumGoodsGanreName; // 商品中分類名称
        //                dr[MAZAI02114EA.ctCol_Jan] = inventInputSearchResultWork.Jan;　                                 // JANコード
        //                dr[MAZAI02114EA.ctCol_StockUnitPrice] = inventInputSearchResultWork.StockUnitPriceFl;　         // 仕入単価
        //                dr[MAZAI02114EA.ctCol_BfStockUnitPrice] = inventInputSearchResultWork.BfStockUnitPriceFl;　     // 変更前仕入単価
        //                dr[MAZAI02114EA.ctCol_StkUnitPriceChgFlg] = inventInputSearchResultWork.StkUnitPriceChgFlg;　   // 仕入単価変更フラグ
        //                dr[MAZAI02114EA.ctCol_InventoryStkCnt] = inventInputSearchResultWork.InventoryStockCnt;　       // 棚卸在庫数
        //                dr[MAZAI02114EA.ctCol_InventoryTolerancCnt] = inventInputSearchResultWork.InventoryTolerancCnt; // 棚卸過不足数
        //                dr[MAZAI02114EA.ctCol_InventoryPreprDay] = TDateTime.DateTimeToLongDate(inventInputSearchResultWork.InventoryPreprDay); // 棚卸準備処理日付
        //                dr[MAZAI02114EA.ctCol_InventoryDay] = TDateTime.DateTimeToLongDate(inventInputSearchResultWork.InventoryDay);　         // 棚卸実施日
        //                dr[MAZAI02114EA.ctCol_InventoryUpDate] = TDateTime.DateTimeToLongDate(inventInputSearchResultWork.LastInventoryUpdate); // 最終棚卸更新日
        //                dr[MAZAI02114EA.ctCol_InventoryNewDiv] = inventInputSearchResultWork.InventoryNewDiv;　         // 棚卸新規追加区分
        //                // 2007.09.14 削除 >>>>>>>>>>>>>>>>>>>>
        //                //dr[MAZAI02114EA.ctCol_PrdNumMngDiv] = inventInputSearchResultWork.PrdNumMngDiv;　               // 製番管理区分
        //                // 2007.09.14 削除 <<<<<<<<<<<<<<<<<<<<
        //                dr[MAZAI02114EA.ctCol_LastStockDate] = TDateTime.DateTimeToLongDate(inventInputSearchResultWork.LastStockDate);　       // 最終仕入年月日
        //                dr[MAZAI02114EA.ctCol_StockCnt] = inventInputSearchResultWork.StockTotal;　                     // 在庫総数
        //                // 2008.02.13 修正 >>>>>>>>>>>>>>>>>>>>
        //                //dr[MAZAI02114EA.ctCol_StockTotalExec] = inventInputSearchResultWork.StockTotalExec;             // 実施日帳簿数
        //                dr[MAZAI02114EA.ctCol_StockTotalExec] = inventInputSearchResultWork.StockAmount;                // 実施日帳簿数
        //                dr[MAZAI02114EA.ctCol_InventoryDate] = TDateTime.DateTimeToLongDate(inventInputSearchResultWork.InventoryDate);         // 棚卸日
        //                // 2008.02.13 修正 <<<<<<<<<<<<<<<<<<<<
        //                // 2007.09.14 削除 >>>>>>>>>>>>>>>>>>>>
        //                //dr[MAZAI02114EA.ctCol_ProductStockGuid] = inventInputSearchResultWork.ProductStockGuid;　       // 製番在庫マスタGUID
        //                // 2007.09.14 削除 <<<<<<<<<<<<<<<<<<<<
        //                dr[MAZAI02114EA.ctCol_WarehouseCode] = inventInputSearchResultWork.WarehouseCode;　             // 倉庫コード
        //                dr[MAZAI02114EA.ctCol_WarehouseName] = inventInputSearchResultWork.WarehouseName;　             // 倉庫名称
        //                // 2007.09.14 修正 >>>>>>>>>>>>>>>>>>>>
        //                //dr[MAZAI02114EA.ctCol_CarrierEpCode] = inventInputSearchResultWork.CarrierEpCode;　             // 事業者コード
        //                //dr[MAZAI02114EA.ctCol_CarrierEpName] = inventInputSearchResultWork.CarrierEpName;　             // 事業者名称
        //                //dr[MAZAI02114EA.ctCol_StockDate] = TDateTime.DateTimeToLongDate(inventInputSearchResultWork.StockDate);　          // 仕入日
        //                //dr[MAZAI02114EA.ctCol_ArrivalGoodsDay] = TDateTime.DateTimeToLongDate(inventInputSearchResultWork.ArrivalGoodsDay);// 入荷日
        //                //dr[MAZAI02114EA.ctCol_ProductNumber] = inventInputSearchResultWork.ProductNumber;　             // 製造番号
        //                //dr[MAZAI02114EA.ctCol_StockTelNo1] = inventInputSearchResultWork.StockTelNo1;　                 // 商品電話番号1
        //                //dr[MAZAI02114EA.ctCol_BfStockTelNo1] = inventInputSearchResultWork.BfStockTelNo1;　             // 変更前商品電話番号1
        //                //dr[MAZAI02114EA.ctCol_StkTelNo1ChgFlg] = inventInputSearchResultWork.StkTelNo1ChgFlg;　         // 商品電話番号1変更フラグ
        //                //dr[MAZAI02114EA.ctCol_StockTelNo2] = inventInputSearchResultWork.StockTelNo2;　                 // 商品電話番号2
        //                //dr[MAZAI02114EA.ctCol_BfStockTelNo2] = inventInputSearchResultWork.BfStockTelNo2;　             // 変更前商品電話番号2
        //                //dr[MAZAI02114EA.ctCol_StkTelNo2ChgFlg] = inventInputSearchResultWork.StkTelNo2ChgFlg;　         // 商品電話番号2変更フラグ
        //                dr[MAZAI02114EA.ctCol_WarehouseShelfNo] = inventInputSearchResultWork.WarehouseShelfNo;　       // 棚番
        //                dr[MAZAI02114EA.ctCol_DuplicationShelfNo1] = inventInputSearchResultWork.DuplicationShelfNo1;　 // 重複棚番1
        //                dr[MAZAI02114EA.ctCol_DuplicationShelfNo2] = inventInputSearchResultWork.DuplicationShelfNo2;　 // 重複棚番2
        //                dr[MAZAI02114EA.ctCol_DetailGoodsGanreCode] = inventInputSearchResultWork.DetailGoodsGanreCode; // 商品区分詳細コード
        //                dr[MAZAI02114EA.ctCol_DetailGoodsGanreName] = inventInputSearchResultWork.DetailGoodsGanreName; // 商品区分詳細名称
        //                dr[MAZAI02114EA.ctCol_EnterpriseGanreCode] = inventInputSearchResultWork.EnterpriseGanreCode;　 // 自社分類コード
        //                dr[MAZAI02114EA.ctCol_EnterpriseGanreName] = inventInputSearchResultWork.EnterpriseGanreName;　 // 自社分類名称
        //                dr[MAZAI02114EA.ctCol_BLGoodsCode] = inventInputSearchResultWork.BLGoodsCode;　                 // ＢＬ商品コード
        //                dr[MAZAI02114EA.ctCol_BLGoodsName] = inventInputSearchResultWork.BLGoodsName;　                 // ＢＬ商品名称
        //                // 2007.09.14 修正 <<<<<<<<<<<<<<<<<<<<
        //                dr[MAZAI02114EA.ctCol_CustomerCode]    = inventInputSearchResultWork.CustomerCode;              // 得意先(仕入先)コード
        //                dr[MAZAI02114EA.ctCol_CustomerName]    = inventInputSearchResultWork.CustomerName;              // 得意先(仕入先)名称
        //                dr[MAZAI02114EA.ctCol_CustomerName2]    = inventInputSearchResultWork.CustomerName2;            // 得意先(仕入先)名称2
        //                dr[MAZAI02114EA.ctCol_ShipCustomerCode]    = inventInputSearchResultWork.ShipCustomerCode;      // 得意先(委託先)コード
        //                dr[MAZAI02114EA.ctCol_ShipCustomerName]    = inventInputSearchResultWork.ShipCustomerName;      // 得意先(委託先)名称
        //                dr[MAZAI02114EA.ctCol_ShipCustomerName2]   = inventInputSearchResultWork.ShipCustomerName2;     // 得意先(委託先)名称2
        //                // 2007.09.14 修正 >>>>>>>>>>>>>>>>>>>>
        //                //dr[MAZAI02114EA.ctCol_StockDiv_Print] = InventSearchCndtnUI.GetTargetStockDivName(inventInputSearchResultWork.StockDiv, inventInputSearchResultWork.StockState); //在庫区分  
        //                // 2008.02.13 修正 >>>>>>>>>>>>>>>>>>>>
        //                //dr[MAZAI02114EA.ctCol_StockDiv_Print] = 0;                                                      // 在庫区分  
        //                if (inventInputSearchResultWork.StockDiv == 0)                                                  // 在庫区分  
        //                {
        //                    dr[MAZAI02114EA.ctCol_StockDiv_Print] = "自社";
        //                }
        //                else
        //                {
        //                    dr[MAZAI02114EA.ctCol_StockDiv_Print] = "受託";
        //                }
        //                // 2008.02.13 修正 <<<<<<<<<<<<<<<<<<<<
        //                // 2007.09.14 修正 <<<<<<<<<<<<<<<<<<<<

        //                //ソート用
        //                // 2007.09.14 削除 >>>>>>>>>>>>>>>>>>>>
        //                ////在庫区分UI用
        //                //dr[MAZAI02114EA.ctCol_UiSotckDiv] = InventSearchCndtnUI.GetUiStockDiv(inventInputSearchResultWork.StockDiv,inventInputSearchResultWork.StockState);
        //                // 2007.09.14 削除 <<<<<<<<<<<<<<<<<<<<

        //                // 差異金額(在庫原単価×在庫過不足数を代入する(仮))
        //                dr[MAZAI02114EA.ctCol_TolerancPrice] = inventInputSearchResultWork.StockUnitPriceFl * (long)inventInputSearchResultWork.InventoryTolerancCnt ;                 
        //                //在庫金額(棚卸数×在庫原単価(仮))
        //                dr[MAZAI02114EA.ctCol_StockPrice] = inventInputSearchResultWork.StockUnitPriceFl * (long)inventInputSearchResultWork.InventoryStockCnt ;                
          
        //                //最終仕入日(印刷用)
        //                if(inventInputSearchResultWork.LastStockDate == DateTime.MinValue)
        //                {
        //                    dr[MAZAI02114EA.ctCol_LastStockDate_Print] = "";
        //                }
        //                else
        //                {
        //                    dr[MAZAI02114EA.ctCol_LastStockDate_Print]  = TDateTime.DateTimeToString("YYYY/MM/DD",inventInputSearchResultWork.LastStockDate);
        //                }
        //                //棚卸準備処理日付
        //                if(inventInputSearchResultWork.InventoryPreprDay == DateTime.MinValue)
        //                {
        //                    dr[MAZAI02114EA.ctCol_InventoryPreprDay_Print] = "";
        //                }
        //                else
        //                {
        //                    dr[MAZAI02114EA.ctCol_InventoryPreprDay_Print]  = TDateTime.DateTimeToString("YYYY/MM/DD",inventInputSearchResultWork.InventoryPreprDay);
        //                }
        //                //棚卸実施日
        //                if(inventInputSearchResultWork.InventoryDay == DateTime.MinValue)
        //                {
        //                    dr[MAZAI02114EA.ctCol_InventoryDay_Print] = "";
        //                }
        //                else
        //                {
        //                    dr[MAZAI02114EA.ctCol_InventoryDay_Print]  = TDateTime.DateTimeToString("YYYY/MM/DD",inventInputSearchResultWork.InventoryDay);
        //                }
        //                 //最終棚卸更新日
        //                if(inventInputSearchResultWork.LastInventoryUpdate == DateTime.MinValue)
        //                {
        //                    dr[MAZAI02114EA.ctCol_InventoryUpDate_Print] = "";
        //                }
        //                else
        //                {
        //                    dr[MAZAI02114EA.ctCol_InventoryUpDate_Print]  = TDateTime.DateTimeToString("YYYY/MM/DD",inventInputSearchResultWork.LastInventoryUpdate);
        //                }
        //                // 2007.09.14 削除 >>>>>>>>>>>>>>>>>>>>
        //                ////仕入日
        //                //if(inventInputSearchResultWork.StockDate == DateTime.MinValue)
        //                //{
        //                //    dr[MAZAI02114EA.ctCol_StockDate_Print] = "";
        //                //}
        //                //else
        //                //{
        //                //    dr[MAZAI02114EA.ctCol_StockDate_Print]  = TDateTime.DateTimeToString("YYYY/MM/DD",inventInputSearchResultWork.StockDate);
        //                //}
        //                ////入荷日
        //                //if(inventInputSearchResultWork.ArrivalGoodsDay == DateTime.MinValue)
        //                //{
        //                //    dr[MAZAI02114EA.ctCol_ArrivalGoodsDay_Print] = "";
        //                //}
        //                //else
        //                //{
        //                //    dr[MAZAI02114EA.ctCol_ArrivalGoodsDay_Print]  = TDateTime.DateTimeToString("YYYY/MM/DD",inventInputSearchResultWork.ArrivalGoodsDay);
        //                //}
        //                ////事業者コード
        //                //if(inventInputSearchResultWork.CarrierEpCode == 0)
        //                //{
        //                //    dr[MAZAI02114EA.ctCol_CarrierEpCode_Print] = "";
        //                //}
        //                //else
        //                //{
        //                //    dr[MAZAI02114EA.ctCol_CarrierEpCode_Print] = inventInputSearchResultWork.CarrierEpCode.ToString();
        //                //}
        //                // 2007.09.14 削除 <<<<<<<<<<<<<<<<<<<<
        //                //倉庫コード
        //                if(inventInputSearchResultWork.WarehouseCode == null)
        //                {
        //                    dr[MAZAI02114EA.ctCol_WarehouseCode_Print] = "";
        //                }
        //                else
        //                {
        //                    dr[MAZAI02114EA.ctCol_WarehouseCode_Print] = inventInputSearchResultWork.WarehouseCode;
        //                }
        //                // 2007.09.14 追加 >>>>>>>>>>>>>>>>>>>>
        //                //棚番ブレイク処理
        //                dr[MAZAI02114EA.ctCol_WarehouseShelfNo_Print] = "";
        //                if (inventSearchCndtnUI.TurnOoverThePagesDiv == 1)
        //                {
        //                    // 出力順
        //                    // 倉庫→棚番 or 倉庫→仕入先→棚番
        //                    if ((inventSearchCndtnUI.SortDiv == 0) || (inventSearchCndtnUI.SortDiv == 4))
        //                    {
        //                        String wkcode = inventInputSearchResultWork.WarehouseShelfNo.TrimEnd();
        //                        if (wkcode.Length > inventSearchCndtnUI.ShelfNoBreakDiv)
        //                        {
        //                            // 棚番ブレイク桁数以上の時は桁数で削る
        //                            wkcode = wkcode.Substring(0, inventSearchCndtnUI.ShelfNoBreakDiv + 1);
        //                        }
        //                        dr[MAZAI02114EA.ctCol_WarehouseShelfNo_Print] = wkcode;
        //                    }
        //                }
        //                // 2007.09.14 追加 <<<<<<<<<<<<<<<<<<<<
        //                // 2008.02.13 追加 >>>>>>>>>>>>>>>>>>>>
        //                //棚卸日
        //                if (inventInputSearchResultWork.InventoryDate == DateTime.MinValue)
        //                {
        //                    dr[MAZAI02114EA.ctCol_InventoryDate_Print] = "";
        //                }
        //                else
        //                {
        //                    dr[MAZAI02114EA.ctCol_InventoryDate_Print] = TDateTime.DateTimeToString("YYYY/MM/DD", inventInputSearchResultWork.InventoryDate);
        //                }
        //                // 2008.02.13 追加 <<<<<<<<<<<<<<<<<<<<
                        
                         
        //                this._printDataSet.Tables[InventoryListDataTable].Rows.Add(dr);

        //            }
        //            status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL;                   
        //        }                
        //        else
        //        {
        //            status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NOT_FOUND;
        //        }

        //        #endregion
        //    }			
        //    catch (Exception ex)
        //    {
        //        status  = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //        message = ex.Message;
        //    }

        //    return status;
        //}
        #endregion

        #region 変更後のSearchメソッド
        /// <summary>
        /// 棚卸関連一覧表データ取得処理
		/// </summary>
        /// <param name="inventSearchCndtnUI"></param>
		/// <param name="message">エラーメッセージ</param>
		/// <returns></returns>
		/// <remarks>
        /// <br>Note       : 対象範囲の棚卸関連一覧表データを取得します。</br>
		/// <br>Programmer : 30413 犬飼</br>
		/// <br>Date       : 2008.10.14</br>
        /// <br>Update Note: 2010/03/02 呉元嘯</br>
        /// <br>             棚卸表速度向上対応</br>
        /// <br>Update Note: 2011/02/10 田建委</br>
        /// <br>             redmine#18865 棚卸障害対応</br>
		/// </remarks>
        public int Search(InventSearchCndtnUI inventSearchCndtnUI, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";
            ConstantManagement.LogicalMode logicalmode = new ConstantManagement.LogicalMode();
            IInventInputSearchDB _iInventInputSearchDB = (IInventInputSearchDB)MediationInventInputSearchDB.GetInventInputSearchDB();
            object inventInputRltWorkObj = null;

            try
            {
                //StaticMemory　初期化
				InitializeCustomerLedger();

                // 抽出条件格納
                InventInputSearchCndtnWork inventInputSearchCndtnWork;

                // 抽出条件パラメータセット
                status = this.SearchParaSet(inventSearchCndtnUI, out inventInputSearchCndtnWork, out message);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                object ob = inventInputSearchCndtnWork;
                //データ取得
                status = _iInventInputSearchDB.SearchPrint(out inventInputRltWorkObj, ob, 0, logicalmode);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // データ展開処理
                        //SetTebleRowFromRetList(inventSearchCndtnUI, (ArrayList)inventInputRltWorkObj);
                        // ----- ADD 2011/02/10 ------------------------------->>>>>
                        if (((ArrayList)inventInputRltWorkObj).Count == 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            break;
                        }
                        // ----- ADD 2011/02/10 -------------------------------<<<<<
                        ArrayList retList = (ArrayList)inventInputRltWorkObj;

                        // ------------DEL 2010/03/02----------->>>>>
                        //if (inventSearchCndtnUI.SelectedPaperKind == 2)
                        //{
                        //    // 棚卸表の場合、価格情報取得のため商品アクセスクラスから商品連結データを取得
                        //    SetCacheGoodsUnitDataList((ArrayList)retList[0]);
                        //}
                        // ------------DEL 2010/03/02-----------<<<<<

                        SetTebleRowFromRetList(inventSearchCndtnUI, (ArrayList)retList[0]);
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        // 2008.12.02 30413 犬飼 該当データ無しの場合、statusをそのまま返す >>>>>>START
                        //status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        // 2008.12.02 30413 犬飼 該当データ無しの場合、statusをそのまま返す <<<<<<END
                        break;
                    default:
                        message = "棚卸検索データの取得に失敗しました。";
                        break;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion

        #region ◎ 抽出条件展開処理
        /// <summary>
        /// 抽出条件展開処理
        /// </summary>
        /// <param name="inventSearchCndtnUI">UI抽出条件クラス</param>
        /// <param name="inventInputSearchCndtnWork">リモート抽出条件クラス</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <br>Update Note : liyp 2011/01/11</br>
        /// <br>              出力条件に数量と棚番に関する条件指定を追加する（要望）</br>
        private int SearchParaSet(InventSearchCndtnUI inventSearchCndtnUI, out InventInputSearchCndtnWork inventInputSearchCndtnWork, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;
            inventInputSearchCndtnWork = new InventInputSearchCndtnWork();

            try
            {
                // 企業コード
                inventInputSearchCndtnWork.EnterpriseCode = inventSearchCndtnUI.EnterpriseCode;                     // 企業コード

                // 2008.10.31 30413 犬飼 拠点コード設定を削除 >>>>>>START
                //// 抽出条件パラメータセット
                //if (inventSearchCndtnUI.CollectAddupSecCodeList.Length != 0)
                //{
                //    if (inventSearchCndtnUI.IsSelectAllSection)
                //    {
                //        // 全社の時
                //        inventInputSearchCndtnWork.SectionCodes = null;
                //    }
                //    else
                //    {
                //        inventInputSearchCndtnWork.SectionCodes = inventSearchCndtnUI.CollectAddupSecCodeList;
                //    }
                //}
                //else
                //{
                //    inventInputSearchCndtnWork.SectionCodes = null;
                //}
                // 2008.10.31 30413 犬飼 拠点コード設定を削除 <<<<<<END
                
                // 2008.10.14 30413 犬飼 抽出条件の拠点コードの設定は？ >>>>>>START
                //inventInputSearchCndtnWork.SectionCode = inventSearchCndtnUI.SectionCode;                           // 拠点コード
                // 2008.10.14 30413 犬飼 抽出条件の拠点コードの設定は？ <<<<<<END

                // 2008.10.31 30413 犬飼 抽出条件の設定を修正 >>>>>>START
                //inventInputSearchCndtnWork.St_MakerCode = inventSearchCndtnUI.St_MakerCode;                         // メーカーコード開始
                //inventInputSearchCndtnWork.Ed_MakerCode = inventSearchCndtnUI.Ed_MakerCode;                         // メーカーコード終了
                //inventInputSearchCndtnWork.St_GoodsNo = inventSearchCndtnUI.St_GoodsNo;                             // 商品コード開始
                //inventInputSearchCndtnWork.Ed_GoodsNo = inventSearchCndtnUI.Ed_GoodsNo;                             // 商品コード終了
                //inventInputSearchCndtnWork.TargetDateExtraDiv = inventSearchCndtnUI.TargetDateExtraDiv;             // 抽出対象日付区分
                //inventInputSearchCndtnWork.St_WarehouseCode = inventSearchCndtnUI.St_WarehouseCode;                 // 倉庫コード開始
                //inventInputSearchCndtnWork.Ed_WarehouseCode = inventSearchCndtnUI.Ed_WarehouseCode;                 // 倉庫コード終了
                //inventInputSearchCndtnWork.St_WarehouseShelfNo = inventSearchCndtnUI.St_WarehouseShelfNo;           // 棚番開始
                //inventInputSearchCndtnWork.Ed_WarehouseShelfNo = inventSearchCndtnUI.Ed_WarehouseShelfNo;           // 棚番終了
                //inventInputSearchCndtnWork.St_EnterpriseGanreCode = inventSearchCndtnUI.St_EnterpriseGanreCode;     // 自社分類コード開始
                //inventInputSearchCndtnWork.Ed_EnterpriseGanreCode = inventSearchCndtnUI.Ed_EnterpriseGanreCode;     // 自社分類コード終了
                //inventInputSearchCndtnWork.St_BLGoodsCode = inventSearchCndtnUI.St_BLGoodsCode;                     // ＢＬ商品コード開始
                //inventInputSearchCndtnWork.Ed_BLGoodsCode = inventSearchCndtnUI.Ed_BLGoodsCode;                     // ＢＬ商品コード終了
                //inventInputSearchCndtnWork.St_InventoryPreprDay = TDateTime.LongDateToDateTime(inventSearchCndtnUI.St_InventoryPreprDay);   // 開始棚卸準備処理日付
                //inventInputSearchCndtnWork.Ed_InventoryPreprDay = TDateTime.LongDateToDateTime(inventSearchCndtnUI.Ed_InventoryPreprDay);   // 終了棚卸準備処理日付
                //inventInputSearchCndtnWork.InventoryDate = TDateTime.LongDateToDateTime(inventSearchCndtnUI.St_InventoryDay);               // 棚卸日
                //inventInputSearchCndtnWork.InventoryDate = inventSearchCndtnUI.St_InventoryPreprDayDateTime;               // 棚卸日
                //inventInputSearchCndtnWork.St_InventorySeqNo = inventSearchCndtnUI.St_InventorySeqNo;               // 開始棚卸通番
                //inventInputSearchCndtnWork.Ed_InventorySeqNo = inventSearchCndtnUI.Ed_InventorySeqNo;               // 終了棚卸通番
                //inventInputSearchCndtnWork.DifCntExtraDiv = inventSearchCndtnUI.DifCntExtraDiv;                     // 差異分抽出区分
                //inventInputSearchCndtnWork.StockCntZeroExtraDiv = inventSearchCndtnUI.StockCntZeroExtraDiv;         // 在庫数0抽出区分
                //inventInputSearchCndtnWork.IvtStkCntZeroExtraDiv = inventSearchCndtnUI.IvtStkCntZeroExtraDiv;       // 棚卸在庫数0抽出区分
                //inventInputSearchCndtnWork.SelectedPaperKind = inventSearchCndtnUI.SelectedPaperKind;               // 帳票種類
                //inventInputSearchCndtnWork.OutputAppointDiv = inventSearchCndtnUI.OutputAppointDiv;                 // 出力指定区分
                //inventInputSearchCndtnWork.TargetDateExtraDiv = inventSearchCndtnUI.TargetDateExtraDiv;             // 抽出対象日付区分
                //inventInputSearchCndtnWork.WarehouseDiv = 0;                                                        // 倉庫指定区分

                // PM.NS設定
                inventInputSearchCndtnWork.St_MakerCode = inventSearchCndtnUI.St_MakerCode;                         // メーカーコード開始
                if (inventSearchCndtnUI.Ed_MakerCode != 0)
                {
                    inventInputSearchCndtnWork.Ed_MakerCode = inventSearchCndtnUI.Ed_MakerCode;                         // メーカーコード終了
                }
                else
                {
                    inventInputSearchCndtnWork.Ed_MakerCode = 9999;
                }

                inventInputSearchCndtnWork.WarehouseDiv = 0;                                                        // 倉庫指定区分
                inventInputSearchCndtnWork.St_WarehouseCode = inventSearchCndtnUI.St_WarehouseCode;                 // 倉庫コード開始
                inventInputSearchCndtnWork.Ed_WarehouseCode = inventSearchCndtnUI.Ed_WarehouseCode;                 // 倉庫コード終了
                inventInputSearchCndtnWork.St_WarehouseShelfNo = inventSearchCndtnUI.St_WarehouseShelfNo;           // 棚番開始
                inventInputSearchCndtnWork.Ed_WarehouseShelfNo = inventSearchCndtnUI.Ed_WarehouseShelfNo;           // 棚番終了
                inventInputSearchCndtnWork.St_EnterpriseGanreCode = inventSearchCndtnUI.St_EnterpriseGanreCode;     // 自社分類コード開始
                if (inventSearchCndtnUI.Ed_EnterpriseGanreCode != 0)
                {
                    inventInputSearchCndtnWork.Ed_EnterpriseGanreCode = inventSearchCndtnUI.Ed_EnterpriseGanreCode;     // 自社分類コード終了
                }
                else
                {
                    inventInputSearchCndtnWork.Ed_EnterpriseGanreCode = 9999;
                }

                inventInputSearchCndtnWork.St_BLGoodsCode = inventSearchCndtnUI.St_BLGoodsCode;                     // ＢＬ商品コード開始
                if (inventSearchCndtnUI.Ed_BLGoodsCode != 0)
                {
                    inventInputSearchCndtnWork.Ed_BLGoodsCode = inventSearchCndtnUI.Ed_BLGoodsCode;                     // ＢＬ商品コード終了
                }
                else
                {
                    inventInputSearchCndtnWork.Ed_BLGoodsCode = 99999;
                }

                inventInputSearchCndtnWork.St_SupplierCd = inventSearchCndtnUI.St_SupplierCd;                       // 開始仕入先コード
                if (inventSearchCndtnUI.Ed_SupplierCd != 0)
                {
                    inventInputSearchCndtnWork.Ed_SupplierCd = inventSearchCndtnUI.Ed_SupplierCd;                       // 終了仕入先コード
                }
                else
                {
                    inventInputSearchCndtnWork.Ed_SupplierCd = 999999;
                }

                // 2008.12.10 30413 犬飼 画面の棚卸日を設定するように修正 >>>>>>START
                //inventInputSearchCndtnWork.InventoryDate = inventSearchCndtnUI.St_InventoryPreprDayDateTime;        // 棚卸日
                inventInputSearchCndtnWork.InventoryDate = inventSearchCndtnUI.InventoryDate;        // 棚卸日
                // 2008.12.10 30413 犬飼 画面の棚卸日を設定するように修正 <<<<<<END
                
                inventInputSearchCndtnWork.St_InventorySeqNo = inventSearchCndtnUI.St_InventorySeqNo;               // 開始棚卸通番
                if (inventSearchCndtnUI.Ed_InventorySeqNo != 0)
                {
                    inventInputSearchCndtnWork.Ed_InventorySeqNo = inventSearchCndtnUI.Ed_InventorySeqNo;               // 終了棚卸通番
                }
                else
                {
                    inventInputSearchCndtnWork.Ed_InventorySeqNo = 99999999;
                }

                inventInputSearchCndtnWork.St_BLGroupCode = inventSearchCndtnUI.St_BLGroupCode;                     // 開始BLグループコード
                if (inventSearchCndtnUI.Ed_BLGroupCode != 0)
                {
                    inventInputSearchCndtnWork.Ed_BLGroupCode = inventSearchCndtnUI.Ed_BLGroupCode;                     // 終了BLグループコード
                }
                else
                {
                    inventInputSearchCndtnWork.Ed_BLGroupCode = 99999;
                }
                
                inventInputSearchCndtnWork.SelectedPaperKind = inventSearchCndtnUI.SelectedPaperKind;               // 帳票種類
                inventInputSearchCndtnWork.OutputAppointDiv = inventSearchCndtnUI.OutputAppointDiv;                 // 出力指定区分
                inventInputSearchCndtnWork.TargetDateExtraDiv = inventSearchCndtnUI.TargetDateExtraDiv;             // 抽出対象日付区分
                // 2008.10.31 30413 犬飼 抽出条件の設定を修正 <<<<<<END
                
                // -----------------------ADD 2011/01/11 -------------------------->>>>>
                inventInputSearchCndtnWork.NumOutputDiv = inventSearchCndtnUI.NumOutputDiv;                         // 数量出力区分
                inventInputSearchCndtnWork.WarehouseShelfOutputDiv = inventSearchCndtnUI.WarehouseShelfOutputDiv;   // 棚番出力区分
                // -----------------------ADD 2011/01/11 --------------------------<<<<<

                // 2008.10.31 30413 犬飼 追加設定項目 >>>>>>START
                inventInputSearchCndtnWork.StockDiv = inventSearchCndtnUI.StockDiv;                                 // 在庫区分
                inventInputSearchCndtnWork.LendExtraDiv = inventSearchCndtnUI.LendExtraDiv;                         // 貸出抽出区分
                inventInputSearchCndtnWork.DelayPaymentDiv = inventSearchCndtnUI.DelayPaymentDiv;                   // 来勘計上抽出区分
                // 2008.10.31 30413 犬飼 追加設定項目 <<<<<<END
                
                // 棚卸差異表
                if (inventSearchCndtnUI.SelectedPaperKind == 1)
                {
                    inventInputSearchCndtnWork.CalcStockAmountDiv = 1;                 // 在庫数算出フラグ
                    inventInputSearchCndtnWork.CalcStockAmountDate = DateTime.MinValue; // 在庫数算出日付
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion

        #region ◎ 棚卸検索データ展開処理
		/// <summary>
        /// 棚卸検索データ展開処理
		/// </summary>
        /// <param name="inventSearchCndtnUI">UI抽出条件クラス</param>
        /// <param name="inventInputRltList">棚卸検索データ結果リスト</param>
		/// <returns>Status</returns>
		/// <remarks>
        /// <br>Note       : 棚卸検索データを展開する。</br>
	    /// <br>Programmer : 30413 犬飼</br>
	    /// <br>Date       : 2008.10.14</br>
        /// <br>Update Note: 2009/12/04 呉元嘯</br>
        /// <br>             小計印刷の障害修正</br>
        /// <br>Update Note: 2009/12/07 張凱</br>
        /// <br>             重複棚番ありのみを指定時に、棚番下に「重複棚番１」と「重複棚番２」を印刷する修正</br>
        /// <br>Update Note: 2010/03/02 呉元嘯</br>
        /// <br>             棚卸表速度向上対応</br>
        /// <br>Update Note: 2011/01/11 liyp</br>
        /// <br>             １、棚卸数の印字仕様変更　２、出力条件に数量と棚番に関する条件指定を追加する（要望）</br>
        /// <br>Update Note: 2011/02/10 liyp</br>
        /// <br>             帳簿数採用時の未入力分のデータについて</br>
        /// <br>Update Note: 2011/02/17 田建委</br>
        /// <br>             redmine#19025 抽出時間について</br>
        /// <br>Update Note: 2011/11/28 陳建明</br>
        /// <br>             棚卸調査表/棚番の印刷順について</br>
        /// <br>Update Note: 2012/07/20 李小路</br>
        /// <br>             redmine#31158 「棚卸差異表」のサーバー負荷軽減と速度アップの調査</br>
        /// <br>Update Note: K2014/03/10 licb</br>
        ///	<br>			 信越自動車商会個別開発 テキスト出力機能を追加する</br>
        /// </remarks>
        private void SetTebleRowFromRetList(InventSearchCndtnUI inventSearchCndtnUI, ArrayList inventInputRltList)
        {
            // ----- ADD 2011/02/17 ---------->>>>>
            //ArrayList retList;    //DEL 2012/07/20 李小路 Redmine#31158
            //int statusMngTtlSt = stockMngTtlStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);    //DEL 2012/07/20 李小路 Redmine#31158
            // ----- ADD 2011/02/17 ----------<<<<<
            // ----- ADD 2012/07/20 李小路 Redmine#31158  ---------->>>>>
            ArrayList retList = new ArrayList();
            int statusMngTtlSt = (int)ConstantManagement.DB_Status.ctDB_EOF;
            if (inventSearchCndtnUI.SelectedPaperKind == 2)
            {
                statusMngTtlSt = stockMngTtlStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
            }
            // ----- ADD 2012/07/20 李小路 Redmine#31158 ----------<<<<<

            DataRow dr;
            //add 2011/11/28 陳建明 Redmine #8073----->>>>>
            Array arr=  inventInputRltList.ToArray();
		    MyStringComparer myComp = new MyStringComparer(CompareInfo.GetCompareInfo("en-US"), CompareOptions.Ordinal,inventSearchCndtnUI.SortDiv);
		    Array.Sort(arr,myComp);
            foreach (InventInputSearchResultWork inventInputSearchResultWork in arr)
            //add 2011/11/28 陳建明 Redmine #8073-----<<<<<    
            //foreach (InventInputSearchResultWork inventInputSearchResultWork in inventInputRltList)//del 2011/11/28 陳建明 Redmine #8073
            {
                // --- ADD yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
                if (string.IsNullOrEmpty(inventInputSearchResultWork.GoodsName))
                {
                    inventInputSearchResultWork.GoodsName = GetGoodsName(inventInputSearchResultWork.GoodsMakerCd, inventInputSearchResultWork.GoodsNo);

                    if (inventSearchCndtnUI.SelectedPaperKind == 2)
                    {
                        inventInputSearchResultWork.ListPriceFl = GetListPriceFl(inventInputSearchResultWork.GoodsMakerCd, inventInputSearchResultWork.GoodsNo, inventInputSearchResultWork.InventoryDate);
                    }
                }
                // --- ADD yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<

                // 2009.01.30 30413 犬飼 棚卸差異表の場合、差異数がゼロのデータは非印字 >>>>>>START
                // 棚卸差異表
                if (inventSearchCndtnUI.SelectedPaperKind == 1)
                {
                    // 差異数がゼロの場合は非印字
                    if (inventInputSearchResultWork.InventoryTolerancCnt == 0)
                    {
                        continue;
                    }
                }
                // 2009.01.30 30413 犬飼 棚卸差異表の場合、差異数がゼロのデータは非印字 <<<<<<END
                
                dr = this._printDataSet.Tables[InventoryListDataTable].NewRow();

                dr[MAZAI02114EA.ctCol_SectionCode] = inventInputSearchResultWork.SectionCode;                   // 拠点コード
                dr[MAZAI02114EA.ctCol_SectionGuideNm] = inventInputSearchResultWork.SectionGuideNm;             // 拠点ガイド名称
                dr[MAZAI02114EA.ctCol_InventorySeqNo] = inventInputSearchResultWork.InventorySeqNo;             // 棚卸通番
                dr[MAZAI02114EA.ctCol_WarehouseCode] = inventInputSearchResultWork.WarehouseCode;               // 倉庫コード
                dr[MAZAI02114EA.ctCol_WarehouseName] = inventInputSearchResultWork.WarehouseName;               // 倉庫名称
                dr[MAZAI02114EA.ctCol_GoodsMakerCd] = inventInputSearchResultWork.GoodsMakerCd;                 // 商品メーカーコード
                dr[MAZAI02114EA.ctCol_MakerName] = inventInputSearchResultWork.MakerName;                       // メーカー名称
                dr[MAZAI02114EA.ctCol_GoodsNo] = inventInputSearchResultWork.GoodsNo;                           // 商品番号
                dr[MAZAI02114EA.ctCol_GoodsName] = inventInputSearchResultWork.GoodsName;                       // 商品名称
                dr[MAZAI02114EA.ctCol_WarehouseShelfNo] = inventInputSearchResultWork.WarehouseShelfNo;         // 倉庫棚番
                dr[MAZAI02114EA.ctCol_DuplicationShelfNo1] = inventInputSearchResultWork.DuplicationShelfNo1;   // 重複棚番1
                dr[MAZAI02114EA.ctCol_DuplicationShelfNo2] = inventInputSearchResultWork.DuplicationShelfNo2;   // 重複棚番2
                dr[MAZAI02114EA.ctCol_GoodsLGroup] = inventInputSearchResultWork.GoodsLGroup;                   // 商品大分類コード
                dr[MAZAI02114EA.ctCol_GoodsLGroupName] = inventInputSearchResultWork.GoodsLGroupName;           // 商品大分類コード名称
                dr[MAZAI02114EA.ctCol_GoodsMGroup] = inventInputSearchResultWork.GoodsMGroup;                   // 商品中分類コード
                dr[MAZAI02114EA.ctCol_GoodsMGroupName] = inventInputSearchResultWork.GoodsMGroupName;           // 商品中分類コード名称
                dr[MAZAI02114EA.ctCol_BLGroupCode] = inventInputSearchResultWork.BLGroupCode;                   // BLグループコード
                dr[MAZAI02114EA.ctCol_BLGroupName] = inventInputSearchResultWork.BLGroupName;                   // BLグループコード名称
                dr[MAZAI02114EA.ctCol_EnterpriseGanreCode] = inventInputSearchResultWork.EnterpriseGanreCode;   // 自社分類コード
                dr[MAZAI02114EA.ctCol_EnterpriseGanreName] = inventInputSearchResultWork.EnterpriseGanreName;   // 自社分類名称
                dr[MAZAI02114EA.ctCol_BLGoodsCode] = inventInputSearchResultWork.BLGoodsCode;                   // ＢＬ商品コード
                dr[MAZAI02114EA.ctCol_BLGoodsCdDerivedNo] = inventInputSearchResultWork.BLGoodsCdDerivedNo;     // ＢＬ商品コード枝番
                dr[MAZAI02114EA.ctCol_BLGoodsName] = inventInputSearchResultWork.BLGoodsName;                   // ＢＬ商品名称
                dr[MAZAI02114EA.ctCol_SupplierCd] = inventInputSearchResultWork.SupplierCd;                     // 仕入先コード
                dr[MAZAI02114EA.ctCol_Jan] = inventInputSearchResultWork.Jan;                                   // ＪＡＮコード
                dr[MAZAI02114EA.ctCol_StockUnitPriceFl] = inventInputSearchResultWork.StockUnitPriceFl;         // 仕入単価
                dr[MAZAI02114EA.ctCol_BfStockUnitPriceFl] = inventInputSearchResultWork.BfStockUnitPriceFl;     // 変更前仕入単価
                dr[MAZAI02114EA.ctCol_StkUnitPriceChgFlg] = inventInputSearchResultWork.StkUnitPriceChgFlg;     // 仕入単価変更フラグ
                dr[MAZAI02114EA.ctCol_StockDiv] = inventInputSearchResultWork.StockDiv;                         // 在庫区分
                dr[MAZAI02114EA.ctCol_LastStockDate] = TDateTime.DateTimeToLongDate(inventInputSearchResultWork.LastStockDate);               // 最終仕入年月日
                dr[MAZAI02114EA.ctCol_StockTotal] = inventInputSearchResultWork.StockTotal;                     // 在庫総数
                dr[MAZAI02114EA.ctCol_ShipCustomerCode] = inventInputSearchResultWork.ShipCustomerCode;         // 出荷先得意先コード
                dr[MAZAI02114EA.ctCol_ShipCustomerName] = inventInputSearchResultWork.ShipCustomerName;         // 出荷先得意先名称
                dr[MAZAI02114EA.ctCol_ShipCustomerName2] = inventInputSearchResultWork.ShipCustomerName2;       // 出荷得意先名称2
                // ------------DEL 2010/02/20----------->>>>>
                //dr[MAZAI02114EA.ctCol_InventoryStockCnt] = inventInputSearchResultWork.InventoryStockCnt;       // 棚卸在庫数
                // ------------DEL 2010/02/20-----------<<<<<
                // --- ADD licb K2014/03/10 FOR 信越自動車商会個別開発 テキスト出力機能を追加する --- >>>>>
                dr[MAZAI02114EA.ctCol_InventoryStockCntTextOut] = inventInputSearchResultWork.InventoryStockCnt;       // 棚卸在庫数
                dr[MAZAI02114EA.ctCol_ListPriceTextOut] = inventInputSearchResultWork.ListPrice;       // 標準価格
                // --- ADD licb K2014/03/10 FRO 信越自動車商会個別開発 テキスト出力機能を追加する --- <<<<<
                dr[MAZAI02114EA.ctCol_InventoryTolerancCnt] = inventInputSearchResultWork.InventoryTolerancCnt; // 棚卸過不足数
                dr[MAZAI02114EA.ctCol_InventoryPreprDay] = TDateTime.DateTimeToLongDate(inventInputSearchResultWork.InventoryPreprDay);       // 棚卸準備処理日付
                dr[MAZAI02114EA.ctCol_InventoryPreprTim] = inventInputSearchResultWork.InventoryPreprTim;       // 棚卸準備処理時間
                dr[MAZAI02114EA.ctCol_InventoryDay] = TDateTime.DateTimeToLongDate(inventInputSearchResultWork.InventoryDay);                 // 棚卸実施日
                dr[MAZAI02114EA.ctCol_LastInventoryUpdate] = TDateTime.DateTimeToLongDate(inventInputSearchResultWork.LastInventoryUpdate);   // 最終棚卸更新日
                dr[MAZAI02114EA.ctCol_InventoryNewDiv] = inventInputSearchResultWork.InventoryNewDiv;           // 棚卸新規追加区分
                dr[MAZAI02114EA.ctCol_StockMashinePrice] = inventInputSearchResultWork.StockMashinePrice;       // マシン在庫額
                dr[MAZAI02114EA.ctCol_InventoryStockPrice] = inventInputSearchResultWork.InventoryStockPrice;   // 棚卸在庫額
                dr[MAZAI02114EA.ctCol_InventoryTlrncPrice] = inventInputSearchResultWork.InventoryTlrncPrice;   // 棚卸過不足金額
                dr[MAZAI02114EA.ctCol_ListPriceFl] = inventInputSearchResultWork.ListPriceFl;                   // 定価（浮動）
                dr[MAZAI02114EA.ctCol_InventoryDate] = TDateTime.DateTimeToLongDate(inventInputSearchResultWork.InventoryDate);               // 棚卸日
                dr[MAZAI02114EA.ctCol_StockTotalExec] = inventInputSearchResultWork.StockTotalExec;             // 在庫総数（実施日）
                dr[MAZAI02114EA.ctCol_ToleranceUpdateCd] = inventInputSearchResultWork.ToleranceUpdateCd;       // 過不足更新区分
                dr[MAZAI02114EA.ctCol_StockAmount] = inventInputSearchResultWork.StockAmount;                   // 算出在庫数

                if (inventInputSearchResultWork.StockDiv == 0)                                                  // 在庫区分  
                {
                    dr[MAZAI02114EA.ctCol_StockDiv_Print] = "自社";
                }
                else
                {
                    dr[MAZAI02114EA.ctCol_StockDiv_Print] = "受託";
                }
                
                //// 差異金額(在庫原単価×在庫過不足数を代入する(仮))
                //dr[MAZAI02114EA.ctCol_TolerancPrice] = inventInputSearchResultWork.StockUnitPriceFl * (long)inventInputSearchResultWork.InventoryTolerancCnt;
                ////在庫金額(棚卸数×在庫原単価(仮))
                //dr[MAZAI02114EA.ctCol_StockPrice] = inventInputSearchResultWork.StockUnitPriceFl * (long)inventInputSearchResultWork.InventoryStockCnt;

                //最終仕入日(印刷用)
                if (inventInputSearchResultWork.LastStockDate == DateTime.MinValue)
                {
                    dr[MAZAI02114EA.ctCol_LastStockDate_Print] = "";
                }
                else
                {
                    dr[MAZAI02114EA.ctCol_LastStockDate_Print] = TDateTime.DateTimeToString("YYYY/MM/DD", inventInputSearchResultWork.LastStockDate);
                }
                //棚卸準備処理日付
                if (inventInputSearchResultWork.InventoryPreprDay == DateTime.MinValue)
                {
                    dr[MAZAI02114EA.ctCol_InventoryPreprDay_Print] = "";
                }
                else
                {
                    dr[MAZAI02114EA.ctCol_InventoryPreprDay_Print] = TDateTime.DateTimeToString("YYYY/MM/DD", inventInputSearchResultWork.InventoryPreprDay);
                }
                //棚卸実施日
                if (inventInputSearchResultWork.InventoryDay == DateTime.MinValue)
                {
                    dr[MAZAI02114EA.ctCol_InventoryDay_Print] = "";
                    // ------------ADD 2010/02/20------------->>>>>
                    // 棚卸実施日(InventoryDayRF)＝NULLの場合、棚卸数を印刷しない（空白）
                    dr[MAZAI02114EA.ctCol_InvStockCntFlag_Print] = 1;
                    dr[MAZAI02114EA.ctCol_InventoryStockCnt] = 0.0;       // 棚卸在庫数
                    // ------------ADD 2010/02/20-------------<<<<<
                }
                else
                {
                    dr[MAZAI02114EA.ctCol_InventoryDay_Print] = TDateTime.DateTimeToString("YYYY/MM/DD", inventInputSearchResultWork.InventoryDay);
                    // ------------ADD 2010/02/20------------->>>>>
                    // 棚卸実施日(InventoryDayRF)≠NULLの場合、棚卸数を印刷
                    dr[MAZAI02114EA.ctCol_InvStockCntFlag_Print] = 0;
                    dr[MAZAI02114EA.ctCol_InventoryStockCnt] = inventInputSearchResultWork.InventoryStockCnt;       // 棚卸在庫数
                    // ------------ADD 2010/02/20-------------<<<<<

                }
                //最終棚卸更新日
                if (inventInputSearchResultWork.LastInventoryUpdate == DateTime.MinValue)
                {
                    dr[MAZAI02114EA.ctCol_InventoryUpDate_Print] = "";
                }
                else
                {
                    dr[MAZAI02114EA.ctCol_InventoryUpDate_Print] = TDateTime.DateTimeToString("YYYY/MM/DD", inventInputSearchResultWork.LastInventoryUpdate);
                }
                //倉庫コード
                if (inventInputSearchResultWork.WarehouseCode == "")
                {
                    dr[MAZAI02114EA.ctCol_WarehouseCode_Print] = "";
                }
                else
                {
                    dr[MAZAI02114EA.ctCol_WarehouseCode_Print] = inventInputSearchResultWork.WarehouseCode.TrimEnd().PadLeft(4, '0');
                }

                //倉庫コード有無チェック(無い場合は拠点情報設定マスタの優先倉庫を取得)
                this.CheckWarehouseCode(inventInputSearchResultWork, ref dr);               //ADD 2009/05/13 不具合対応[13259]

                // 2008.10.31 30413 犬飼 仕入先コード、BLコード、グループコード、メーカーコードを印字用に0詰め対応 >>>>>>START
                // 仕入先コード
                if (inventInputSearchResultWork.SupplierCd == 0)
                {
                    dr[MAZAI02114EA.ctCol_SupplierCd_Print] = "";
                }
                else
                {
                    dr[MAZAI02114EA.ctCol_SupplierCd_Print] = inventInputSearchResultWork.SupplierCd.ToString("d06");
                }
                // BLコード
                if (inventInputSearchResultWork.BLGoodsCode == 0)
                {
                    dr[MAZAI02114EA.ctCol_BLGoodsCode_Print] = "";
                }
                else
                {
                    dr[MAZAI02114EA.ctCol_BLGoodsCode_Print] = inventInputSearchResultWork.BLGoodsCode.ToString("d05");
                }
                // グループコード
                if (inventInputSearchResultWork.BLGroupCode == 0)
                {
                    dr[MAZAI02114EA.ctCol_BLGroupCode_Print] = "";
                }
                else
                {
                    dr[MAZAI02114EA.ctCol_BLGroupCode_Print] = inventInputSearchResultWork.BLGroupCode.ToString("d05");
                }
                // メーカーコード
                if (inventInputSearchResultWork.GoodsMakerCd == 0)
                {
                    dr[MAZAI02114EA.ctCol_MakerCode_Print] = "";
                }
                else
                {
                    dr[MAZAI02114EA.ctCol_MakerCode_Print] = inventInputSearchResultWork.GoodsMakerCd.ToString("d04");
                }
                // 2008.10.31 30413 犬飼 仕入先コード、BLコード、グループコード、メーカーコードを印字用に0詰め対応 <<<<<<END
                
                //棚番ブレイク処理
                // ----------UPD 2009/12/04 --------->>>>>
                dr[MAZAI02114EA.ctCol_WarehouseShelfNo_Print] = "";
                // 棚卸差異表 ＋小計あり＋出力順(棚番順)
                if ((inventSearchCndtnUI.SelectedPaperKind == 1) && (inventSearchCndtnUI.SubtotalPrintDiv == 0) && (inventSearchCndtnUI.SortDiv == 0))
                {

                        String wkcode = inventInputSearchResultWork.WarehouseShelfNo.TrimEnd();
                        if (wkcode.Length > inventSearchCndtnUI.ShelfNoBreakDiv)
                        {
                            // 棚番ブレイク桁数以上の時は桁数で削る
                            wkcode = wkcode.Substring(0, inventSearchCndtnUI.ShelfNoBreakDiv + 1);
                        }
                        dr[MAZAI02114EA.ctCol_WarehouseShelfNo_Print] = wkcode;
 
                }
                // 棚卸表 ＋小計あり＋出力順(棚番順)
                else if ((inventSearchCndtnUI.SelectedPaperKind == 2) && (inventSearchCndtnUI.SubtotalPrintDiv == 0) && (inventSearchCndtnUI.SortDiv == 0))
                {
                    String wkcode = inventInputSearchResultWork.WarehouseShelfNo.TrimEnd();
                    if (wkcode.Length > inventSearchCndtnUI.ShelfNoBreakDiv)
                    {
                        // 棚番ブレイク桁数以上の時は桁数で削る
                        wkcode = wkcode.Substring(0, inventSearchCndtnUI.ShelfNoBreakDiv + 1);
                    }
                    dr[MAZAI02114EA.ctCol_WarehouseShelfNo_Print] = wkcode;
                }
                else if (inventSearchCndtnUI.TurnOoverThePagesDiv == 1)
                {
                    // 出力順
                    //// 倉庫→棚番 or 倉庫→仕入先→棚番
                    //if ((inventSearchCndtnUI.SortDiv == 0) || (inventSearchCndtnUI.SortDiv == 4))
                    // 倉庫→棚番
                    if (inventSearchCndtnUI.SortDiv == 0)
                    {
                        String wkcode = inventInputSearchResultWork.WarehouseShelfNo.TrimEnd();
                        if (wkcode.Length > inventSearchCndtnUI.ShelfNoBreakDiv)
                        {
                            // 棚番ブレイク桁数以上の時は桁数で削る
                            wkcode = wkcode.Substring(0, inventSearchCndtnUI.ShelfNoBreakDiv + 1);
                        }
                        dr[MAZAI02114EA.ctCol_WarehouseShelfNo_Print] = wkcode;
                    }
                }
                //if (inventSearchCndtnUI.TurnOoverThePagesDiv == 1)
                //{
                //    // 出力順
                //    //// 倉庫→棚番 or 倉庫→仕入先→棚番
                //    //if ((inventSearchCndtnUI.SortDiv == 0) || (inventSearchCndtnUI.SortDiv == 4))
                //    // 倉庫→棚番
                //    if (inventSearchCndtnUI.SortDiv == 0)
                //    {
                //        String wkcode = inventInputSearchResultWork.WarehouseShelfNo.TrimEnd();
                //        if (wkcode.Length > inventSearchCndtnUI.ShelfNoBreakDiv)
                //        {
                //            // 棚番ブレイク桁数以上の時は桁数で削る
                //            wkcode = wkcode.Substring(0, inventSearchCndtnUI.ShelfNoBreakDiv + 1);
                //        }
                //        dr[MAZAI02114EA.ctCol_WarehouseShelfNo_Print] = wkcode;
                //    }
                //}
                // 2009.02.16 30413 犬飼 棚卸表の棚番ブレイク設定を追加 >>>>>>START
                else if ((inventSearchCndtnUI.SelectedPaperKind == 2) && (inventSearchCndtnUI.TurnOoverThePagesDiv == 0) && (inventSearchCndtnUI.SubtotalPrintDiv == 0))
                {
                    // 棚卸表＋改頁(倉庫順)＋小計あり
                    // 倉庫→棚番
                    if (inventSearchCndtnUI.SortDiv == 0)
                    {
                        String wkcode = inventInputSearchResultWork.WarehouseShelfNo.TrimEnd();
                        if (wkcode.Length > inventSearchCndtnUI.ShelfNoBreakDiv)
                        {
                            // 棚番ブレイク桁数以上の時は桁数で削る
                            wkcode = wkcode.Substring(0, inventSearchCndtnUI.ShelfNoBreakDiv + 1);
                        }
                        dr[MAZAI02114EA.ctCol_WarehouseShelfNo_Print] = wkcode;
                    }
                }
                // 2009.02.16 30413 犬飼 棚卸表の棚番ブレイク設定を追加 <<<<<<END
                // 2008.11.27 30413 犬飼 改頁が"倉庫"または"しない"場合の小計印字に対応 >>>>>>START
                else
                {
                    dr[MAZAI02114EA.ctCol_WarehouseShelfNo_Print] = inventInputSearchResultWork.WarehouseShelfNo;   // 棚番
                }
                // 2008.11.27 30413 犬飼 改頁が"倉庫"または"しない"場合の小計印字に対応 <<<<<<END
                // ----------UPD 2009/12/04 ---------<<<<<
                //棚卸日
                if (inventInputSearchResultWork.InventoryDate == DateTime.MinValue)
                {
                    dr[MAZAI02114EA.ctCol_InventoryDate_Print] = "";
                }
                else
                {
                    dr[MAZAI02114EA.ctCol_InventoryDate_Print] = TDateTime.DateTimeToString("YYYY/MM/DD", inventInputSearchResultWork.InventoryDate);
                }
                
                // 2008.11.04 30413 犬飼 棚卸差異表の差異小計印字 >>>>>>START
                // 差異数
                if (inventInputSearchResultWork.InventoryTolerancCnt >= 0)
                {
                    dr[MAZAI02114EA.ctCol_PlusInventoryTolerancCnt] = inventInputSearchResultWork.InventoryTolerancCnt;     // プラスの差異数
                }
                else
                {
                    dr[MAZAI02114EA.ctCol_MinusInventoryTolerancCnt] = Math.Abs(inventInputSearchResultWork.InventoryTolerancCnt);      // マイナスの差異数
                }
                // 差異金額
                if (inventInputSearchResultWork.InventoryTlrncPrice >= 0)
                {
                    dr[MAZAI02114EA.ctCol_PlusInventoryTlrncPrice] = inventInputSearchResultWork.InventoryTlrncPrice;       // プラスの差異金額
                }
                else
                {
                    dr[MAZAI02114EA.ctCol_MinusInventoryTlrncPrice] = Math.Abs(inventInputSearchResultWork.InventoryTlrncPrice);        // マイナスの差異金額
                }
                // 2008.11.04 30413 犬飼 棚卸差異表の差異小計印字 <<<<<<END

                // ------------UPD 2010/03/02------------->>>>>
                //// 2008.11.04 30413 犬飼 商品アクセスクラスから価格情報の取得 >>>>>>START
                //// ローカルキャッシュの商品連結データから価格情報を取得
                //double listPrice = GetListPrice(inventInputSearchResultWork);
                //dr[MAZAI02114EA.ctCol_ListPrice_Print] = listPrice.ToString();
                double stockCount = 0;//ADD 2011/01/11
                //// 算出後の棚卸金額
                ////dr[MAZAI02114EA.ctCol_StockAmountPrice_Print] = ((long)(inventInputSearchResultWork.StockTotalExec * listPrice)).ToString();
                //// 2008.11.04 30413 犬飼 商品アクセスクラスから価格情報の取得 <<<<<<END
                // 価格情報
                dr[MAZAI02114EA.ctCol_ListPrice_Print] = inventInputSearchResultWork.ListPrice;
                // ------------UPD 2010/03/02-------------<<<<<
                // 2008.12.10 30413 犬飼 棚卸未入力区分の処理を修正 >>>>>>START
                // 2008.11.04 30413 犬飼 棚卸未入力区分の処理 >>>>>>START
                //棚卸表
                if (inventSearchCndtnUI.SelectedPaperKind == 2)
                {
                    // 2009.02.16 30413 犬飼 棚卸数の算出を修正 >>>>>>START
                    // 棚卸数(在庫総数(実施日)＋棚卸過不足数)
                    //long stockCount = (long)(inventInputSearchResultWork.StockTotalExec + inventInputSearchResultWork.InventoryTolerancCnt);
                    // 棚卸数(在庫総数＋棚卸過不足数)

                    // -- UPD 2009/09/15 ---------------------->>>
                    //// --- CHG 2009/03/06 障害ID:12229対応------------------------------------------------------>>>>>
                    ////long stockCount = (long)(inventInputSearchResultWork.StockTotal + inventInputSearchResultWork.InventoryTolerancCnt);
                    //// 棚卸数は四捨五入
                    //long stockCount = (long)Math.Floor(inventInputSearchResultWork.StockTotal + inventInputSearchResultWork.InventoryTolerancCnt + 0.5);
                    //// --- CHG 2009/03/06 障害ID:12229対応------------------------------------------------------<<<<<
                    
                    //double stockCount = inventInputSearchResultWork.StockTotal + inventInputSearchResultWork.InventoryTolerancCnt; //DEL 2011/01/11
                    // -- UPD 2009/09/15 ----------------------<<<
                    
                    // 2009.02.16 30413 犬飼 棚卸数の算出を修正 <<<<<<END

                    // ---------------ADD 2011/01/11 ------------->>>>>
                    // ----- DEL 2011/02/17 ---------->>>>>
                    //string message = "" ;
                    //ArrayList retList;
                    //int statusMngTtlSt = stockMngTtlStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                    // ----- DEL 2011/02/17 ----------<<<<<
                    if (statusMngTtlSt == 0)
                    {
                        foreach (StockMngTtlSt stockMngTtlSt in retList)
                        {
                            if ((stockMngTtlSt.LogicalDeleteCode == 0) && (stockMngTtlSt.SectionCode.Trim() == "00"))
                            {
                                _stockMngTtlSt = stockMngTtlSt;
                                break;
                            }
                        }
                    }
                    else
                    {
                        _stockMngTtlSt = new StockMngTtlSt();
                    }

                    if (_stockMngTtlSt.InventoryMngDiv == 1) // 棚卸運用区分＝PM7
                    {
                        //棚卸数 = 棚卸在庫数（InventoryStockCnt）
                        stockCount = inventInputSearchResultWork.InventoryStockCnt;
                        // ------------------------ADD 2011/02/10------------------>>>>
                        if ((inventSearchCndtnUI.InventoryNonInputDiv == 0) &&                     // 帳簿数採用
                            (inventInputSearchResultWork.InventoryDay == DateTime.MinValue)           // 棚卸未入力のレコード
                           )
                        {
                         //棚卸数 = 在庫総数（StockTotal）
                         stockCount = inventInputSearchResultWork.StockTotal;
                        }
                        // ------------------------ADD 2011/02/10------------------<<<<
                    }
                    else                                        // 棚卸運用区分＝PM.NS
                    {
                        //棚卸数 = 在庫総数（StockTotal） + 棚卸差異数（InventoryTolerancCnt）
                        stockCount = inventInputSearchResultWork.StockTotal + inventInputSearchResultWork.InventoryTolerancCnt;
                    }
                    // ---------------ADD 2011/01/11 -------------<<<<<
                    // DEL 2009/04/16 ------>>>
                    //// --- CHG 2009/03/06 障害ID:12229対応------------------------------------------------------>>>>>
                    ////long stockAmountPrice = (long)(stockCount * inventInputSearchResultWork.StockUnitPriceFl);
                    //// 棚卸金額は四捨五入
                    //long stockAmountPrice = (long)Math.Floor(stockCount * inventInputSearchResultWork.StockUnitPriceFl + 0.5);
                    //// --- CHG 2009/03/06 障害ID:12229対応------------------------------------------------------<<<<<
                    // DEL 2009/04/16 ------<<<

                    // ADD 2009/04/16 ------>>>
                    // 棚卸数は四捨五入前の値とする
                    // ---------------UPD 2011/01/11 ------------->>>>>
                    //long stockAmountPrice = (long)Math.Floor((inventInputSearchResultWork.StockTotal + inventInputSearchResultWork.InventoryTolerancCnt) *
                                                             //inventInputSearchResultWork.StockUnitPriceFl + 0.5);
                    // 計算後棚卸数*仕入単価
                    long stockAmountPrice = (long)Math.Floor(stockCount * inventInputSearchResultWork.StockUnitPriceFl + 0.5);
                    // ---------------UPD 2011/01/11 -------------<<<<<
                    // ADD 2009/04/16 ------<<<

                    // ---DEL 2009/05/21 不具合対応[13262] -------------------------------------------->>>>>
                    ////if ((inventSearchCndtnUI.InventoryNonInputDiv == 1) &&
                    ////    (inventInputSearchResultWork.InventoryDay == DateTime.MinValue))
                    ////if ((inventSearchCndtnUI.InventoryNonInputDiv == 1) &&
                    ////    (inventInputSearchResultWork.InventoryStockCnt == 0))
                    //if ((inventSearchCndtnUI.InventoryNonInputDiv == 1) && (stockCount == 0))
                    // ---DEL 2009/05/21 不具合対応[13262] -------------------------------------------->>>>>
                    if ((inventSearchCndtnUI.InventoryNonInputDiv == 1) &&                      //ADD 2009/05/21 不具合対応[13262]
                        (inventInputSearchResultWork.InventoryDay == DateTime.MinValue)         //ADD 2009/05/21 不具合対応[13262]
                       )
                    {
                        // 未入力扱い、棚卸未入力データ
                        dr[MAZAI02114EA.ctCol_StockCount_Print] = "未入力";
                        dr[MAZAI02114EA.ctCol_ListPrice_Print] = "";
                        dr[MAZAI02114EA.ctCol_StockUnitPriceFl_Print] = "";
                        dr[MAZAI02114EA.ctCol_StockAmountPrice_Print] = "";
                    }
                    else
                    {
                        // 未入力扱い、棚卸未入力データ以外
                        //dr[MAZAI02114EA.ctCol_StockCount_Print] = inventInputSearchResultWork.StockTotalExec.ToString();             // 在庫総数（実施日）
                        //dr[MAZAI02114EA.ctCol_StockUnitPriceFl_Print] = inventInputSearchResultWork.StockUnitPriceFl.ToString();         // 仕入単価;
                        //long stockCount = (long)(inventInputSearchResultWork.StockTotalExec + inventInputSearchResultWork.InventoryTolerancCnt);
                        //long stockAmountPrice = (long)(stockCount * inventInputSearchResultWork.StockUnitPriceFl);
                        dr[MAZAI02114EA.ctCol_StockCount_Print] = stockCount.ToString();                                                // 帳簿数+棚卸過不足数
                        dr[MAZAI02114EA.ctCol_StockUnitPriceFl_Print] = inventInputSearchResultWork.StockUnitPriceFl.ToString();        // 仕入単価
                        dr[MAZAI02114EA.ctCol_StockAmountPrice_Print] = stockAmountPrice.ToString();                                    // 計算後棚卸数*仕入単価
                    }
                }
                // 2008.11.04 30413 犬飼 棚卸未入力区分の処理 <<<<<<END
                // 2008.12.10 30413 犬飼 棚卸未入力区分の処理を修正 <<<<<<END

                this._printDataSet.CaseSensitive = true;        //ADD 2009/05/13 不具合対応[13259][13261][13262]　※大文字・小文字を区別

                dr[MAZAI02114EA.ctCol_BlankShowFlag_Print] = 0;//ADD 2009/12/07
                
                // ------------ADD 2011/01/11 ---------------->>>>>
                if (inventSearchCndtnUI.NumOutputDiv != 0 && inventSearchCndtnUI.SelectedPaperKind == 2)
                {
                    if (inventSearchCndtnUI.InventoryNonInputDiv == 0)
                    {

                        if (inventSearchCndtnUI.NumOutputDiv == 1 && (stockCount > 1 || stockCount == 1))
                        {
                            this._printDataSet.Tables[InventoryListDataTable].Rows.Add(dr);
                        }
                        else if (inventSearchCndtnUI.NumOutputDiv == 2 && (stockCount < 0 || stockCount == 0))
                        {
                            this._printDataSet.Tables[InventoryListDataTable].Rows.Add(dr);
                        }
                        else if (inventSearchCndtnUI.NumOutputDiv == 3 && stockCount == 0)
                        {
                            this._printDataSet.Tables[InventoryListDataTable].Rows.Add(dr);
                        }
                    }
                    else if (inventSearchCndtnUI.InventoryNonInputDiv == 1)
                    {
                        if (inventSearchCndtnUI.NumOutputDiv == 4 && inventInputSearchResultWork.InventoryDay == DateTime.MinValue)
                        {
                            this._printDataSet.Tables[InventoryListDataTable].Rows.Add(dr);
                        }
                        else if (inventSearchCndtnUI.NumOutputDiv == 5 && inventInputSearchResultWork.InventoryDay != DateTime.MinValue)
                        {
                            this._printDataSet.Tables[InventoryListDataTable].Rows.Add(dr);
                        }
                    }
                }
                else
                {
                    this._printDataSet.Tables[InventoryListDataTable].Rows.Add(dr);
                }
               // ------------ADD 2011/01/11 ----------------<<<<<

                //this._printDataSet.Tables[InventoryListDataTable].Rows.Add(dr);//DEL 2011/01/11
            }

            // -------ADD 2009/12/07------->>>>>
            //棚卸調査表、重複棚番ありのみ場合
            if (inventSearchCndtnUI.SelectedPaperKind == 0 && inventSearchCndtnUI.OutputAppointDiv == 3)
            {
                // フィルター文字列
                string strFilter = "";
                // ソート文字列を取得
                string strSort = this.MakeSortingOrderString(inventSearchCndtnUI.SortDiv);

                DataView dv = new DataView(this._printDataSet.Tables[InventoryListDataTable], strFilter, strSort, DataViewRowState.CurrentRows);

                DataTable dt = new DataTable();
                dt = dv.ToTable();

                this._printDataSet.Tables[InventoryListDataTable].Rows.Clear();

                foreach (DataRow dataRow in dt.Rows)
                {
                    #region
                    DataRow drNo = this._printDataSet.Tables[InventoryListDataTable].NewRow();
                    for (int i = 0; i < dataRow.Table.Columns.Count; i++ )
                    {
                        drNo[i] = dataRow[i];
                    }

                    this._printDataSet.Tables[InventoryListDataTable].Rows.Add(drNo);
                    #endregion
                    // 重複棚番1
                    if (!string.IsNullOrEmpty(dataRow[MAZAI02114EA.ctCol_DuplicationShelfNo1].ToString().Trim()))
                    {
                        DataRow drShelfNo = this._printDataSet.Tables[InventoryListDataTable].NewRow();

                        drShelfNo[MAZAI02114EA.ctCol_SectionCode] = dataRow[MAZAI02114EA.ctCol_SectionCode];                   // 拠点コード
                        drShelfNo[MAZAI02114EA.ctCol_SectionGuideNm] = dataRow[MAZAI02114EA.ctCol_SectionGuideNm];             // 拠点ガイド名称
                        drShelfNo[MAZAI02114EA.ctCol_WarehouseCode] = dataRow[MAZAI02114EA.ctCol_WarehouseCode];               // 倉庫コード
                        drShelfNo[MAZAI02114EA.ctCol_WarehouseShelfNo] = dataRow[MAZAI02114EA.ctCol_DuplicationShelfNo1];      // 倉庫棚番
                        drShelfNo[MAZAI02114EA.ctCol_GoodsNo] = dataRow[MAZAI02114EA.ctCol_GoodsNo];      // 品番
                        drShelfNo[MAZAI02114EA.ctCol_GoodsMakerCd] = dataRow[MAZAI02114EA.ctCol_GoodsMakerCd];      // メーカー
                        drShelfNo[MAZAI02114EA.ctCol_SupplierCd] = dataRow[MAZAI02114EA.ctCol_SupplierCd];      // 仕入先
                        drShelfNo[MAZAI02114EA.ctCol_BLGoodsCode] = dataRow[MAZAI02114EA.ctCol_BLGoodsCode];      // ＢＬコード
                        drShelfNo[MAZAI02114EA.ctCol_BLGroupCode] = dataRow[MAZAI02114EA.ctCol_BLGroupCode];      // グループコード
                        drShelfNo[MAZAI02114EA.ctCol_WarehouseShelfNo_Print] = dataRow[MAZAI02114EA.ctCol_WarehouseShelfNo_Print];   // 棚番

                        drShelfNo[MAZAI02114EA.ctCol_BlankShowFlag_Print] = 1;

                        this._printDataSet.Tables[InventoryListDataTable].Rows.Add(drShelfNo);
                    }

                    // 重複棚番2
                    if (!string.IsNullOrEmpty(dataRow[MAZAI02114EA.ctCol_DuplicationShelfNo2].ToString().Trim()))
                    {
                        DataRow drShelfNo = this._printDataSet.Tables[InventoryListDataTable].NewRow();

                        drShelfNo[MAZAI02114EA.ctCol_SectionCode] = dataRow[MAZAI02114EA.ctCol_SectionCode];                   // 拠点コード
                        drShelfNo[MAZAI02114EA.ctCol_SectionGuideNm] = dataRow[MAZAI02114EA.ctCol_SectionGuideNm];             // 拠点ガイド名称
                        drShelfNo[MAZAI02114EA.ctCol_WarehouseCode] = dataRow[MAZAI02114EA.ctCol_WarehouseCode];               // 倉庫コード
                        drShelfNo[MAZAI02114EA.ctCol_WarehouseShelfNo] = dataRow[MAZAI02114EA.ctCol_DuplicationShelfNo2];      // 倉庫棚番
                        drShelfNo[MAZAI02114EA.ctCol_GoodsNo] = dataRow[MAZAI02114EA.ctCol_GoodsNo];      // 品番
                        drShelfNo[MAZAI02114EA.ctCol_GoodsMakerCd] = dataRow[MAZAI02114EA.ctCol_GoodsMakerCd];      // メーカー
                        drShelfNo[MAZAI02114EA.ctCol_SupplierCd] = dataRow[MAZAI02114EA.ctCol_SupplierCd];      // 仕入先
                        drShelfNo[MAZAI02114EA.ctCol_BLGoodsCode] = dataRow[MAZAI02114EA.ctCol_BLGoodsCode];      // ＢＬコード
                        drShelfNo[MAZAI02114EA.ctCol_BLGroupCode] = dataRow[MAZAI02114EA.ctCol_BLGroupCode];      // グループコード
                        drShelfNo[MAZAI02114EA.ctCol_WarehouseShelfNo_Print] = dataRow[MAZAI02114EA.ctCol_WarehouseShelfNo_Print];   // 棚番
                        drShelfNo[MAZAI02114EA.ctCol_BlankShowFlag_Print] = 1;

                        this._printDataSet.Tables[InventoryListDataTable].Rows.Add(drShelfNo);
                    }
                }
            }
            // -------ADD 2009/12/07-------<<<<<
        }
        #endregion

        #region
        // ---------------DEL 2010/03/02-------------->>>>>
        //private void SetCacheGoodsUnitDataList(ArrayList inventInputRltList)
        //{
        //    GoodsAcs goodsAcs = new GoodsAcs();
        //    List<GoodsCndtn> goodsCndtnList = new List<GoodsCndtn>();
            
        //    string message = "";
        //    goodsAcs.SearchInitial(LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd(), out message);
            
        //    foreach (InventInputSearchResultWork inventInputSearchResultWork in inventInputRltList)
        //    {
        //        // 商品アクセスクラスの抽出条件を設定
        //        GoodsCndtn workGoodsCndtn = new GoodsCndtn();
        //        workGoodsCndtn.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        //        workGoodsCndtn.SectionCode = inventInputSearchResultWork.SectionCode.Trim();
        //        workGoodsCndtn.MakerName = inventInputSearchResultWork.MakerName;
        //        workGoodsCndtn.GoodsNoSrchTyp = 0;
        //        workGoodsCndtn.GoodsMakerCd = inventInputSearchResultWork.GoodsMakerCd;
        //        workGoodsCndtn.GoodsNo = inventInputSearchResultWork.GoodsNo;
        //        workGoodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;

        //        goodsCndtnList.Add(workGoodsCndtn);
        //    }

        //    // ローカルキャッシュ初期化
        //    _goodsUnitDataListList = new List<List<GoodsUnitData>>();

        //    // 結合検索無し完全一致で商品情報を取得
        //    int status = goodsAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out _goodsUnitDataListList, out message);
        //    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        _goodsUnitDataListList = null;
        //    }

        //}
        // ---------------DEL 2010/03/02--------------<<<<<
        #endregion

        #region
        // ---------------DEL 2010/03/02-------------->>>>>
        //private double GetListPrice(InventInputSearchResultWork inventInputSearchResultWork)
        //{
        //    double listPrice = 0;

        //    if (_goodsUnitDataListList == null)
        //    {
        //        return listPrice;
        //    }

        //    // 2009.02.03 30413 犬飼 システム日付で価格開始日をチェック >>>>>>START
        //    string nowDate = TDateTime.DateTimeToString("YYYY/MM/DD", DateTime.Now);
        //    // 2009.02.03 30413 犬飼 システム日付で価格開始日をチェック <<<<<<END
            
        //    foreach (List<GoodsUnitData> wkGoodsUnitDataList in _goodsUnitDataListList)
        //    {
        //        foreach (GoodsUnitData wkGoodsUnitData in wkGoodsUnitDataList)
        //        {
        //            List<GoodsPrice> wkGoodsPriceList = wkGoodsUnitData.GoodsPriceList;

        //            foreach (GoodsPrice wkGoodsPrice in wkGoodsPriceList)
        //            {
        //                // 2009.02.03 30413 犬飼 システム日付で価格開始日をチェック >>>>>>START
        //                if ((wkGoodsPrice.PriceStartDateAdFormal.CompareTo(nowDate) <= 0) &&
        //                    (wkGoodsPrice.GoodsMakerCd == inventInputSearchResultWork.GoodsMakerCd) &&
        //                    (wkGoodsPrice.GoodsNo == inventInputSearchResultWork.GoodsNo))
        //                {
        //                    listPrice = wkGoodsPrice.ListPrice;
        //                    return listPrice;
        //                }
        //                // 2009.02.03 30413 犬飼 システム日付で価格開始日をチェック <<<<<<END
        //            }
        //        }
        //    }
        //    return listPrice;
        //}
        // ---------------DEL 2010/03/02--------------<<<<<
        #endregion

        #endregion

        // ===================================================================================== //
        // 内部使用関数
        // ===================================================================================== //
        #region private method

        // --- ADD yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
        private GoodsAcs GetGoodsAcs()
        {
            if (this._goodsAcs == null)
            {
                this._goodsAcs = new GoodsAcs();
            }
            return this._goodsAcs;
        }

        /// <summary>
        /// 品名取得処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="goodsNo">品番</param>
        /// <returns>品名</returns>
        public string GetGoodsName(int makerCode, string goodsNo)
        {
            string goodsName = "";

            try
            {
                GoodsUnitData goodsUnitData;

                int status = GetGoodsAcs().Read(LoginInfoAcquisition.EnterpriseCode, makerCode, goodsNo, out goodsUnitData);
                if (status == 0)
                {
                    goodsName = goodsUnitData.GoodsName.Trim();
                }
            }
            catch
            {
                goodsName = "";
            }

            return goodsName;
        }

        private double GetListPriceFl(int makerCode, string goodsNo, DateTime targetDate)
        {
            double listPriceFl = 0;
      
            try
            {
                GoodsUnitData goodsUnitData;

                int status = this.GetGoodsAcs().Read(LoginInfoAcquisition.EnterpriseCode, makerCode, goodsNo, out goodsUnitData);
                if (status == 0)
                {
                    GoodsPrice goodsPrice = this.GetGoodsAcs().GetGoodsPriceFromGoodsPriceList(targetDate, goodsUnitData.GoodsPriceList);
                    listPriceFl = goodsPrice.ListPrice;
                }
            }
            catch
            {
                listPriceFl = 0;
            }
     
            return listPriceFl;
        }
        // --- ADD yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<

        #region 抽出基本データセットスキーマ設定
        /// <summary>
        /// 抽出基本データセットスキーマ設定
		/// </summary>
		/// <param name="ds">データセット</param>
		/// <returns></returns>
		/// <remarks>
        /// <br>Note       : 抽出基本データセットのスキーマ設定を行います</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.04.20</br>
		/// </remarks>
		private void DataSetColumnConstruction(ref DataSet ds)
		{
			// 抽出基本データセットスキーマ設定
            Broadleaf.Application.UIData.MAZAI02114EA.SettingDataSet(ref ds);
        }

        #endregion

        // ---ADD 2009/05/13 不具合対応[13259] ------------------->>>>>
        #region CheckWarehouseCode(倉庫コード有無チェック)
        /// <summary>
        /// 倉庫コード有無チェック
        /// </summary>
        /// <param name="inventInputSearchResultWork">抽出結果(明細)</param>
        /// <param name="dr">InventoryListDataTableのDataRow</param>
        /// <remarks>
        /// <br>Note       : 倉庫コードをチェックし、無い場合は拠点情報の優先倉庫を取得します。</br>
        /// <br>             ※特に分岐を入れてない為、棚卸調査表、棚卸差異表、棚卸表の全てでこの処理を通りますが、</br>
        /// <br>             　棚卸差異表、棚卸表には必ず倉庫コードが入っている為、実際に優先倉庫を取得するのは</br>
        /// <br>             　棚卸調査表だけとなります。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/05/13</br>
        /// </remarks>
        private void CheckWarehouseCode(InventInputSearchResultWork inventInputSearchResultWork, ref DataRow dr)
        {
            //倉庫コードあり
            if (string.IsNullOrEmpty(inventInputSearchResultWork.WarehouseCode.Trim()) == false)
            {
                return;
            }

            //拠点情報の優先倉庫を取得
            SecInfoSet secInfoSet = null;
            this._secInfoSetAcs.Read(out secInfoSet, LoginInfoAcquisition.EnterpriseCode, inventInputSearchResultWork.SectionCode);
            if (string.IsNullOrEmpty(secInfoSet.SectWarehouseCd1.Trim()) == false)
            {
                dr[MAZAI02114EA.ctCol_WarehouseCode] = secInfoSet.SectWarehouseCd1;                                   // 倉庫コード
                dr[MAZAI02114EA.ctCol_WarehouseName] = secInfoSet.SectWarehouseNm1;                                   // 倉庫名称
                dr[MAZAI02114EA.ctCol_WarehouseCode_Print] = secInfoSet.SectWarehouseCd1.TrimEnd().PadLeft(4, '0');   // 倉庫コード(印刷用)
                return;
            }
        }
        #endregion
        // ---ADD 2009/05/13 不具合対応[13259] -------------------<<<<<
        #endregion

        /// <summary>
        /// ソート文字列作成処理
        /// </summary>
        /// <returns>ソート文字列</returns>
        /// <remarks>
        /// <br>Note       : ソート文字列を作成します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.12.07</br>
        /// </remarks>
        private string MakeSortingOrderString(int sortDiv)
        {
            string sortStr = "";

            //選択されたソート条件により処理を分ける倉庫
            switch (sortDiv)
            {
                case 0:             // 棚番順
                    {
                        //倉庫
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                        //棚番
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseShelfNo, 0);
                        //品番
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsNo, 0);
                        //メーカー
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsMakerCd, 0);
                        break;
                    }
                case 1:             // 仕入先順
                    {
                        //倉庫
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                        //仕入先
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_SupplierCd, 0);
                        //品番
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsNo, 0);
                        //メーカー
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsMakerCd, 0);
                        break;
                    }
                case 2:             // ＢＬコード順
                    {
                        //倉庫
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                        //ＢＬコード
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_BLGoodsCode, 0);
                        //品番
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsNo, 0);
                        //メーカー
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsMakerCd, 0);
                        break;
                    }
                case 3:             // グループコード順
                    {
                        //倉庫
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                        //グループコード
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_BLGroupCode, 0);
                        //品番
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsNo, 0);
                        //メーカー
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsMakerCd, 0);
                        break;
                    }
                case 4:             // メーカー順
                    {
                        //倉庫
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                        //メーカー
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsMakerCd, 0);
                        //品番
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsNo, 0);
                        break;
                    }
                case 5:             // 仕入先・棚番順
                    {
                        //倉庫
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                        //仕入先
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_SupplierCd, 0);
                        //棚番
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseShelfNo, 0);
                        //品番
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsNo, 0);
                        //メーカー
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsMakerCd, 0);
                        break;
                    }
                case 6:             // 仕入先・メーカー順
                    {
                        //倉庫
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_WarehouseCode, 0);
                        //仕入先
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_SupplierCd, 0);
                        //メーカー
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsMakerCd, 0);
                        //品番
                        this.MakeSortQuery(ref sortStr, MAZAI02114EA.ctCol_GoodsNo, 0);
                        break;
                    }
            }

            return sortStr;
        }

        /// <summary>
        /// ソート用文字列作成処理
        /// </summary>
        /// <param name="colName">列名称</param>
        /// <param name="ascDescDiv">昇順・降順区分[0:昇順, 1:降順]</param>
        /// <param name="strQuery">ソート用文字列</param>
        /// <remarks>
        /// <br>Note       : ソート用の文字列の作成を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.12.07</br>
        /// </remarks>
        private void MakeSortQuery(ref string strQuery, string colName, int ascDescDiv)
        {
            if (strQuery == null)
            {
                strQuery = "";
            }

            if (strQuery == "")
            {
                strQuery += String.Format("{0} {1}", colName, (ascDescDiv == 0 ? "ASC" : "DESC"));
            }
            else
            {
                strQuery += String.Format(", {0} {1}", colName, (ascDescDiv == 0 ? "ASC" : "DESC"));
            }
        }

        //add 2011/11/28 陳建明 Redmine #8073----->>>>>
        /// <summary>
        /// 棚卸調査表序列用クラス
        /// </summary>
        private class MyStringComparer : IComparer
        {
            private CompareInfo myComp;
            private CompareOptions myOptions = CompareOptions.None;
            private int sortDiv = -1;
            public MyStringComparer(CompareInfo cmpi, CompareOptions options, int sortDiv)
            {
                myComp = cmpi;
                this.myOptions = options;
                this.sortDiv = sortDiv;
            }
            public int Compare(Object a, Object b)
            {
                if (a == b) return 0;
                if (a == null) return -1;
                if (b == null) return 1;
                string stringA = "";
                string stringB = "";
                if (sortDiv == 0)// 棚番順
                {
                    //倉庫
                    stringA = ((InventInputSearchResultWork)a).WarehouseCode;
                    stringB = ((InventInputSearchResultWork)b).WarehouseCode;
                    int comePareWarehouseCode = myComp.Compare(stringA, stringB, myOptions);
                    if (comePareWarehouseCode != 0)
                    {
                        return comePareWarehouseCode;
                    }
                    //棚番
                    stringA = ((InventInputSearchResultWork)a).WarehouseShelfNo;
                    stringB = ((InventInputSearchResultWork)b).WarehouseShelfNo;
                    int comePareWarehouseShelfNo = myComp.Compare(stringA, stringB, myOptions);
                    if (comePareWarehouseShelfNo != 0)
                    {
                        return comePareWarehouseShelfNo;
                    }
                    //品番
                    stringA = ((InventInputSearchResultWork)a).GoodsNo;
                    stringB = ((InventInputSearchResultWork)b).GoodsNo;
                    int comePareGoodsNo = myComp.Compare(stringA, stringB, myOptions);
                    if (comePareGoodsNo != 0)
                    {
                        return comePareGoodsNo;
                    }
                    //メーカー
                    int intC = ((InventInputSearchResultWork)a).GoodsMakerCd;
                    int intD = ((InventInputSearchResultWork)b).GoodsMakerCd;
                    int comePareGoodsMakerCd = intC.CompareTo(intD);
                    return comePareGoodsMakerCd;
                }
                else if (sortDiv == 5)// 仕入先・棚番順
                {
                    //倉庫
                    stringA = ((InventInputSearchResultWork)a).WarehouseCode;
                    stringB = ((InventInputSearchResultWork)b).WarehouseCode;
                    int comePareWarehouseCode = myComp.Compare(stringA, stringB, myOptions);
                    if (comePareWarehouseCode != 0)
                    {
                        return comePareWarehouseCode;
                    }
                    //仕入先
                    int intA = ((InventInputSearchResultWork)a).SupplierCd;
                    int intB = ((InventInputSearchResultWork)b).SupplierCd;
                    int comePareSupplierCd = intA.CompareTo(intB);
                    if (comePareSupplierCd != 0)
                    {
                        return comePareSupplierCd;
                    }
                    //棚番
                    stringA = ((InventInputSearchResultWork)a).WarehouseShelfNo;
                    stringB = ((InventInputSearchResultWork)b).WarehouseShelfNo;
                    int comePareWarehouseShelfNo = myComp.Compare(stringA, stringB, myOptions);
                    if (comePareWarehouseShelfNo != 0)
                    {
                        return comePareWarehouseShelfNo;
                    }
                    //品番
                    stringA = ((InventInputSearchResultWork)a).GoodsNo;
                    stringB = ((InventInputSearchResultWork)b).GoodsNo;
                    int comePareGoodsNo = myComp.Compare(stringA, stringB, myOptions);
                    if (comePareGoodsNo != 0)
                    {
                        return comePareGoodsNo;
                    }
                    //メーカー
                    int intC = ((InventInputSearchResultWork)a).GoodsMakerCd;
                    int intD = ((InventInputSearchResultWork)b).GoodsMakerCd;
                    int comePareGoodsMakerCd = intC.CompareTo(intD);
                    return comePareGoodsMakerCd;
                }
                return 0;
            }
            //add 2011/11/28 陳建明 Redmine #8073-----<<<<<<
        }
    }
}

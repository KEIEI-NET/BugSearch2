using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 棚卸準備処理アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 棚卸準備処理アクセスクラスの機能を実装する。</br>
	/// <br>Programmer : 23010 中村　仁</br>
	/// <br>Date       : 2007.04.11</br>
    /// <br>Update Note: 2007.09.10 980035 金沢 貞義</br>
    /// <br>			 ・DC.NS対応</br>
    /// <br>Update Note: 2008.02.25 980035 金沢 貞義</br>
    /// <br>			 ・仕様変更対応（DC.NS対応）</br>
    /// <br>UpdateNote : 2008/08/28 30414 忍 幸史</br>
    /// <br>             ・Partsman用に変更</br>
    /// <br>Update Note : 2009/11/30 張凱 保守依頼③対応</br>
    /// <br>             既存データ存在時の処理内容を変更</br>
    /// <br>Update Note : 2011/01/30 yangmj readmine#18780の修正対応</br>
    /// <br>              2012/06/27配信分、Redmine#30282</br>
    /// <br>Update Note : 2012/06/08 yangyi 2012/06/27配信分、Redmine#30282の修正対応</br>
    /// </remarks>
	public class InventoryPrepareAcs
	{
		# region Constructor
		/// <summary>
		/// 棚卸準備処理アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 棚卸準備処理アクセスクラスのインスタンスを生成する。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.04.11</br>
		/// </remarks>
		public InventoryPrepareAcs()
		{			
			// ログイン情報生成 //			
			// 企業コード
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            //ログイン拠点コード
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;			
			
			//リモートオブジェクト取得 //	
			try
			{
                //棚卸準備処理リモートオブジェクトインターフェイス
				this._iInventoryExtDB = (IInventoryExtDB)MediationInventoryExtDB.GetInventoryExtDB();
                //棚卸検索リモートオブジェクトインターフェイス
                this._iInventInputSearchDB = (IInventInputSearchDB)MediationInventInputSearchDB.GetInventInputSearchDB();
			}
			catch (Exception)
			{
				this._iInventoryExtDB = null;
                this._iInventInputSearchDB = null;
			}

			//棚卸準備履歴取得
			this.PrtIvntHisAcquire();

			//棚卸準備履歴データセット格納
			this.PrtIvntHisDataSetting();

            /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
            //在庫管理全体設定マスタアクセスクラス
            _stockMngTtlStAcs   = new StockMngTtlStAcs();
               --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/

            ////TODO：
            ////列情報格納Hash
            //this._columnList = new Hashtable();
		}
		# endregion

        # region Public Const

        // テーブル設定		
        /// <summary>データソース名称（棚卸準備履歴）</summary>
        public const string ctPrtIvntHis_Table = "PrtIvntHis_Table";
        /// <summary>テーブル名称（棚卸準備履歴）</summary>
        public const string ctM_PrtIvntHis_Table = "m_PrtIvntHis_Table";

        #region DEL 2008/08/28 Partsman用に変更
        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
        // テーブル（棚卸準備履歴）カラム設定
        /// <summary>処理日</summary>
        public const string ctInventoryPreprDate = "InventoryPreprDate";
        /// <summary>処理時間</summary>
        public const string ctInventoryPreprTime = "InventoryPreprTime";
        /// <sunnary>処理区分(非表示)</sunnary>
        public const string ctInventoryProcDiv_Hidden = "InventoryProcDiv_Hidden";
        /// <sunnary>処理区分</sunnary>
        public const string ctInventoryProcDiv = "InventoryProcDiv";
        /// <summary>抽出在庫区分</summary>
        public const string ctStockExtraDiv = "StockExtraDiv";
        /// <summary>倉庫コード</summary>
        public const string ctWareHouseCode = "StartWareHouseCode";
        /// <summary>メーカーコード</summary>
        public const string ctMakerCode = "MakerCode";
        /// <summary>キャリア</summary>
        public const string ctCarrierName = "CarrierName";
        /// <summary>商品区分グループコード</summary>
        public const string ctLargeGoodsCode = "LargeGoodsCode";
        /// <summary>商品区分コード</summary>
        public const string ctMediumGoodsCode = "MediumGoodsCode";
        /// <summary>商品種別</summary>
        public const string ctGoodsKind = "GoodsKind";
        /// <summary>商品コード</summary>
        public const string ctGoodsCode = "GoodsCode";
        /// <summary>機種（開始）</summary>
        public const string ctCellphoneModelCode = "CellphoneModelCode";
        /// <summary>最終棚卸更新日</summary>
        public const string ctLastInventoryUpd = "LastInventoryUpd";
        // 2007.09.10 追加 >>>>>>>>>>>>>>>>>>>>
        public const string ctInventoryDate = "InventoryDate";
        public const string ctDetailGoodsCode = "DetailGoodsCode";
        public const string ctBLGoodsCode = "BLGoodsCode";
        public const string ctEnterpriseGanreCode = "EnterpriseGanreCode";
        public const string ctCustomerCode = "CustomerCode";
        public const string ctShelfNo = "ShelfNo";
        // 2007.09.10 追加 <<<<<<<<<<<<<<<<<<<<
        // 2008.02.25 追加 >>>>>>>>>>>>>>>>>>>>
        public const string ctInventoryDate_Int = "InventoryDate_Int";
        public const string ctInventoryPreprDate_Int = "InventoryPreprDate_Int";
        public const string ctInventoryPreprTime_Int = "InventoryPreprTime_Int";
        // 2008.02.25 追加 <<<<<<<<<<<<<<<<<<<<
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/28 Partsman用に変更

        // --- ADD 2008/08/28 --------------------------------------------------------------------->>>>>
        // テーブル（棚卸準備履歴）カラム設定
        /// <summary>処理日</summary>
        public const string ctInventoryPreprDate = "InventoryPreprDate";
        /// <summary>処理時間</summary>
        public const string ctInventoryPreprTime = "InventoryPreprTime";
        /// <sunnary>処理区分(非表示)</sunnary>
        public const string ctInventoryProcDiv_Hidden = "InventoryProcDiv_Hidden";
        /// <sunnary>処理区分</sunnary>
        public const string ctInventoryProcDiv = "InventoryProcDiv";
        /// <summary>棚卸日</summary>
        public const string ctInventoryDate = "InventoryDate";
        /// <summary>棚卸実施日</summary>
        public const string ctInventoryDate_Int = "InventoryDate_Int";
        /// <summary>倉庫コード</summary>
        public const string ctWareHouseCode = "StartWareHouseCode";
        /// <summary>棚番</summary>
        public const string ctShelfNo = "ShelfNo";
        /// <summary>仕入先コード</summary>
        public const string ctSupplierCode = "SupplierCode";
        /// <summary>BLコード</summary>
        public const string ctBLGoodsCode = "BLGoodsCode";
        /// <summary>グループコード</summary>
        public const string ctBLGroupCode = "BLGroupCode";
        /// <summary>メーカーコード</summary>
        public const string ctMakerCode = "MakerCode";
        // --- ADD 2008/08/28 ---------------------------------------------------------------------<<<<<
        // -------ADD 2009/11/30------->>>>>
        /// <summary>拠点</summary>
        public const string ctSectionCode = "SectionCode";
        // -------ADD 2009/11/30-------<<<<<
        // -------ADD 2011/01/30------->>>>>
        /// <summary>管理拠点</summary>
        public const string ctMngSectionCode = "MngSectionCode";
        // -------ADD 2011/01/30------->>>>>
        #endregion

        #region DEL 2008/08/28 使用していないのでコメントアウト
        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
        #region Private Const

        //在庫抽出区分
        private const string ctCompStockExtraDivName = "自社";
        private const string ctTrstStockExtraDivName = "受託";
        private const string ctEnTrustCmpStockExtraDivName = "委託(自社)";
        private const string ctEnTrustTrsStockExtraDivName = "委託(受託)";
        //商品種別
        private const string ctGeneralGoodsExtDivName = "一般";
        private const string ctMobileGoodsExtDivName = "携帯電話";
        private const string ctAcsryGoodsExtDivName = "付属品";

        # endregion
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/28 使用していないのでコメントアウト

        # region Private Members

        // 変数 //		
		// ログイン情報
		private string _enterpriseCode;
        private string _loginSectionCode;
		private ArrayList _prtIvntHisWorkList;
		private DataSet _prtIvntHisDataSet;
        
        //TODO:
        //private Hashtable _columnList;
		
		// パラメータクラス //
		private InventoryExtCndtnWork _inventoryExtCndtnWork = null;
			
		// リモートインターフェース //
        //棚卸準備処理
		private IInventoryExtDB _iInventoryExtDB = null;
        //棚卸検索
        private IInventInputSearchDB _iInventInputSearchDB = null;

        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
        ///在庫管理全体設定アクセスクラス</summary>
	    private static StockMngTtlStAcs _stockMngTtlStAcs = null;
        ///在庫管理全体設定データクラス
        private static StockMngTtlSt _stockMngTtlStData        = null;
        
        // 2008.02.25 追加 >>>>>>>>>>>>>>>>>>>>
        /// <summary>在庫受払履歴データ格納バッファ</summary>        
        private IStockAcPayHisSearchDB _iStockAcPayHisSearchDB = null;
        // 2008.02.25 追加 <<<<<<<<<<<<<<<<<<<<
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/

        # endregion

        # region Private Methods

        #region 棚卸準備履歴取得処理
        /// <summary>
		/// 棚卸準備履歴取得処理
		/// </summary>
		/// <returns>Status - 0: 成功, それ以外: NG</returns>
		private int PrtIvntHisAcquire()
		{
			int status = 0;
			this._prtIvntHisWorkList = new ArrayList();
			this._prtIvntHisWorkList.Clear();

			try
			{
                //棚卸履歴結果クラス
				InventoryExtCndtnWork inventoryExtCndtnWork = new InventoryExtCndtnWork();
                //企業コード
                inventoryExtCndtnWork.EnterpriseCode = this._enterpriseCode;
              　//自拠点コード
                inventoryExtCndtnWork.SectionCode = this._loginSectionCode;

                ArrayList wkList = new ArrayList();
                wkList.Clear();
                object paraobj = inventoryExtCndtnWork;
                object retobj = null;
                
                status = this._iInventoryExtDB.Search(out retobj, paraobj, 0, 0);

                #region TEST
                ////TEST
                //InventDataPreWork test = new InventDataPreWork();
                //test.AcsryGoodsExtDiv = 1;
                //test.CarrierCdSt = 1;
                //test.CarrierCdEd = 5;
                //test.CmpStkExtraDiv = 0;
                //test.CellphoneModelCdSt = "AAAAA";
                //test.CellphoneModelCdEd = "ZZZZZ";
                //test.MakerCodeSt = 0;
                //test.MakerCodeEd = 500;
                //test.InventoryPreprDay = DateTime.Now;
                //test.InventoryPreprTim = TDateTime.DateTimeToLongDate(DateTime.Now);

                //this._prtIvntHisWorkList.Add(test);

                //InventDataPreWork tes = new InventDataPreWork();
                //tes.AcsryGoodsExtDiv = 1;
                //test.CarrierCdSt = 1;
                //test.CarrierCdEd = 5;
                //tes.CmpStkExtraDiv = 0;
                //tes.CellphoneModelCdSt = "BBBBB";
                //tes.CellphoneModelCdEd = "ZZZZZ";
                //tes.MakerCodeSt = 0;
                //tes.MakerCodeEd = 500;
                //tes.InventoryPreprDay = DateTime.Now;
                //tes.InventoryPreprTim = TDateTime.DateTimeToLongDate(DateTime.Now);

                //this._prtIvntHisWorkList.Add(tes);

                #endregion

                if (status == 0)
                {
                    wkList = retobj as ArrayList;

                    if (wkList != null)
                    {
                        foreach (InventDataPreWork wkInventoryHisWork in wkList)
                        {
                            this._prtIvntHisWorkList.Add(wkInventoryHisWork);
                        }                            
                    }			
                }
			}
			catch (Exception)
			{
				// オフライン時はnullをセット
                this._iInventoryExtDB = null;
				// 通信エラー時は-1を返す
				status = -1;
			}

			return status;
		}
		#endregion

		#region 棚卸準備履歴データセット格納
        // --- ADD 2008/08/28 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 棚卸準備履歴データセット格納
        /// </summary>	
        /// <br>Update Note: 2012/06/08 yangyi</br>
        /// <br>管理番号   ：10801804-00 2012/06/27配信分</br>
        /// <br>             Redmine#30282 №1002 棚卸準備処理の改良の対応</br>
        private void PrtIvntHisDataSetting()
        {
            DataSet dataSet = null;
            DataTable dt;
            DataRow dr;

            if (this._prtIvntHisDataSet == null)
            {
                this._prtIvntHisDataSet = new DataSet(ctPrtIvntHis_Table);
            }

            dataSet = this._prtIvntHisDataSet;

            //既にデータテーブルが存在するか？
            if (dataSet.Tables.Contains(ctM_PrtIvntHis_Table))
            {
                dt = dataSet.Tables[ctM_PrtIvntHis_Table];
            }
            else
            {
                //テーブル作成
                dt = dataSet.Tables.Add(ctM_PrtIvntHis_Table);

                dt.Columns.Add(new DataColumn(ctInventoryPreprDate, typeof(string)));		// 処理日
                dt.Columns.Add(new DataColumn(ctInventoryPreprTime, typeof(string)));		// 処理時間	
                dt.Columns.Add(new DataColumn(ctInventoryProcDiv_Hidden, typeof(int)));     // 処理区分(非表示)
                dt.Columns.Add(new DataColumn(ctInventoryProcDiv, typeof(string)));         // 処理区分名称
                dt.Columns.Add(new DataColumn(ctInventoryDate, typeof(string)));	        // 棚卸日
                dt.Columns.Add(new DataColumn(ctInventoryDate_Int, typeof(int)));           // 棚卸実施日
                dt.Columns.Add(new DataColumn(ctWareHouseCode, typeof(string)));	        // 倉庫
                dt.Columns.Add(new DataColumn(ctMngSectionCode, typeof(string)));           // 管理拠点 ADD 2011/01/30
                dt.Columns.Add(new DataColumn(ctShelfNo, typeof(string)));	                // 棚番
                dt.Columns.Add(new DataColumn(ctSupplierCode, typeof(string)));	            // 仕入先
                dt.Columns.Add(new DataColumn(ctBLGoodsCode, typeof(string)));	            // BLコード
                dt.Columns.Add(new DataColumn(ctBLGroupCode, typeof(string)));	            // グループコード
                dt.Columns.Add(new DataColumn(ctMakerCode, typeof(string)));		        // メーカー
                dt.Columns.Add(new DataColumn(ctSectionCode, typeof(string)));              // 拠点 ADD 2009/11/30

                dt.Columns[ctInventoryPreprDate].Caption = "処理日";				        // 処理日
                dt.Columns[ctInventoryPreprTime].Caption = "処理時間";				        // 処理時間
                dt.Columns[ctInventoryProcDiv_Hidden].Caption = "処理区分(非表示)";		    // 処理区分(非表示)
                dt.Columns[ctInventoryProcDiv].Caption = "処理区分";                        // 処理区分
                dt.Columns[ctInventoryDate].Caption = "棚卸日";				                // 棚卸日
                dt.Columns[ctInventoryDate_Int].Caption = "棚卸実施日";                     // 棚卸実施日
                dt.Columns[ctWareHouseCode].Caption = "倉庫";					            // 倉庫
                dt.Columns[ctMngSectionCode].Caption = "管理拠点";                          // 管理拠点 ADD 2011/01/30
                dt.Columns[ctShelfNo].Caption = "棚番";					                    // 棚番
                dt.Columns[ctSupplierCode].Caption = "仕入先";					            // 仕入先
                dt.Columns[ctBLGoodsCode].Caption = "BLｺｰﾄﾞ";					            // BLコード
                dt.Columns[ctBLGroupCode].Caption = "ｸﾞﾙｰﾌﾟｺｰﾄﾞ";					        // グループコード
                dt.Columns[ctMakerCode].Caption = "メーカー";				                // メーカー
                dt.Columns[ctSectionCode].Caption = "拠点";                                 // 拠点 ADD 2009/11/30
            }

            dt.Clear();

            //データセット格納処理
            InventDataPreWork targetInventDataPreWork;
            
            for (int workCounter = this._prtIvntHisWorkList.Count; workCounter > 0; workCounter--)
            {
                targetInventDataPreWork = (InventDataPreWork)this._prtIvntHisWorkList[workCounter - 1];
                
                // DataRowを作成
                dr = dt.NewRow();

                //データテーブル作成
                string start = "";
                string end = "";

                // 処理日付
                if (targetInventDataPreWork.InventoryPreprDay != DateTime.MinValue)
                {
                    dr[ctInventoryPreprDate] = TDateTime.DateTimeToString("YYYY/MM/DD", targetInventDataPreWork.InventoryPreprDay);
                }
                // 処理時間
                dr[ctInventoryPreprTime] = targetInventDataPreWork.InventoryPreprTim.ToString("0#:0#:0#");

                //処理区分(非表示)
                dr[ctInventoryProcDiv_Hidden] = targetInventDataPreWork.InventoryProcDiv;

                //処理区分
                if (targetInventDataPreWork.InventoryProcDiv == 3)
                {
                    //棚卸データ削除
                    dr[ctInventoryProcDiv] = "棚卸データ削除";
                }
                else
                {
                    //棚卸準備処理
                    dr[ctInventoryProcDiv] = "棚卸準備処理";
                }

                //棚卸日
                dr[ctInventoryDate] = TDateTime.DateTimeToString("YYYY/MM/DD", targetInventDataPreWork.InventoryDate);
                //棚卸実施日（数値）
                dr[ctInventoryDate_Int] = TDateTime.DateTimeToLongDate(targetInventDataPreWork.InventoryDate);

                // ADD yangyi 2012/06/08 Redmine#30282 ------------->>>>>
                        if (!string.IsNullOrEmpty(targetInventDataPreWork.MngSectionCodeSt) || !string.IsNullOrEmpty(targetInventDataPreWork.MngSectionCodeEd))
                        {
                            // 管理拠点             
                            dr[ctMngSectionCode] = String.Format("{0} ～ {1}",
                            targetInventDataPreWork.MngSectionCodeSt.Trim(), targetInventDataPreWork.MngSectionCodeEd.Trim());
                        }
                // 拠点
                dr[ctSectionCode] = targetInventDataPreWork.SectionCode.Trim();
                // ADD yangyi 2012/06/08 Redmine#30282 -------------<<<<<

                //処理区分が削除の時は条件はいらない
                if (targetInventDataPreWork.InventoryProcDiv != 3)
                {
                    // 倉庫               
                    if ((targetInventDataPreWork.WarehouseCodeSt != "") || (targetInventDataPreWork.WarehouseCodeEd != ""))
                    {
                        if (targetInventDataPreWork.WarehouseCodeSt == "")
                        {
                            start = "ＴＯＰ";
                        }
                        else
                        {
                            start = targetInventDataPreWork.WarehouseCodeSt.Trim().PadRight(6, ' ');
                        }
                        if (targetInventDataPreWork.WarehouseCodeEd == "")
                        {
                            end = "ＥＮＤ";
                        }
                        else
                        {
                            end = targetInventDataPreWork.WarehouseCodeEd;
                        }
                        dr[ctWareHouseCode] = String.Format("{0} ～ {1}", start, end);
                    }
                    else
                    {
                        if (targetInventDataPreWork.SelWarehouseCode1.Trim() != "")
                        {
                            start += targetInventDataPreWork.SelWarehouseCode1.Trim().PadLeft(4, '0') + ",";
                        }
                        if (targetInventDataPreWork.SelWarehouseCode2.Trim() != "")
                        {
                            start += targetInventDataPreWork.SelWarehouseCode2.Trim().PadLeft(4, '0') + ",";
                        }
                        if (targetInventDataPreWork.SelWarehouseCode3.Trim() != "")
                        {
                            start += targetInventDataPreWork.SelWarehouseCode3.Trim().PadLeft(4, '0') + ",";
                        }
                        if (targetInventDataPreWork.SelWarehouseCode4.Trim() != "")
                        {
                            start += targetInventDataPreWork.SelWarehouseCode4.Trim().PadLeft(4, '0') + ",";
                        }
                        if (targetInventDataPreWork.SelWarehouseCode5.Trim() != "")
                        {
                            start += targetInventDataPreWork.SelWarehouseCode5.Trim().PadLeft(4, '0') + ",";
                        }
                        if (targetInventDataPreWork.SelWarehouseCode6.Trim() != "")
                        {
                            start += targetInventDataPreWork.SelWarehouseCode6.Trim().PadLeft(4, '0') + ",";
                        }
                        if (targetInventDataPreWork.SelWarehouseCode7.Trim() != "")
                        {
                            start += targetInventDataPreWork.SelWarehouseCode7.Trim().PadLeft(4, '0') + ",";
                        }
                        if (targetInventDataPreWork.SelWarehouseCode8.Trim() != "")
                        {
                            start += targetInventDataPreWork.SelWarehouseCode8.Trim().PadLeft(4, '0') + ",";
                        }
                        if (targetInventDataPreWork.SelWarehouseCode9.Trim() != "")
                        {
                            start += targetInventDataPreWork.SelWarehouseCode9.Trim().PadLeft(4, '0') + ",";
                        }
                        if (targetInventDataPreWork.SelWarehouseCode10.Trim() != "")
                        {
                            start += targetInventDataPreWork.SelWarehouseCode10.Trim().PadLeft(4, '0') + ",";
                        }

                        if (start.Length > 0)
                        {
                            start = start.Remove(start.Length - 1);
                        }

                        dr[ctWareHouseCode] = start;
                    }

                    // -------ADD 2011/01/30------->>>>>
                    if (!string.IsNullOrEmpty(targetInventDataPreWork.MngSectionCodeSt) || !string.IsNullOrEmpty(targetInventDataPreWork.MngSectionCodeEd))
                    {
                        // 管理拠点             
                        dr[ctMngSectionCode] = String.Format("{0} ～ {1}",
                        targetInventDataPreWork.MngSectionCodeSt.Trim(), targetInventDataPreWork.MngSectionCodeEd.Trim());
                    }
                    // -------ADD 2011/01/30------->>>>>

                    // 棚番
                    if ((targetInventDataPreWork.ShelfNoSt != "") || (targetInventDataPreWork.ShelfNoEd != ""))
                    {
                        if (targetInventDataPreWork.ShelfNoSt == "")
                        {
                            start = "ＴＯＰ  ";
                        }
                        else
                        {
                            start = targetInventDataPreWork.ShelfNoSt.PadRight(8, ' ');
                        }
                        if (targetInventDataPreWork.ShelfNoEd == "")
                        {
                            end = "ＥＮＤ";
                        }
                        else
                        {
                            end = targetInventDataPreWork.ShelfNoEd;
                        }
                        dr[ctShelfNo] = String.Format("{0} ～ {1}", start, end);
                    }

                    // 仕入先             
                    dr[ctSupplierCode] = String.Format("{0} ～ {1}",
                    targetInventDataPreWork.StartSupplierCode.ToString(), targetInventDataPreWork.EndSupplierCode.ToString());

                    // BLコード             
                    dr[ctBLGoodsCode] = String.Format("{0} ～ {1}",
                    targetInventDataPreWork.BLGoodsCodeSt.ToString(), targetInventDataPreWork.BLGoodsCodeEd.ToString());

                    // グループコード             
                    dr[ctBLGroupCode] = String.Format("{0} ～ {1}",
                    targetInventDataPreWork.BLGroupCodeSt.ToString(), targetInventDataPreWork.BLGroupCodeEd.ToString());

                    // メーカー             
                    dr[ctMakerCode] = String.Format("{0} ～ {1}",
                    targetInventDataPreWork.GoodsMakerCdSt.ToString(), targetInventDataPreWork.GoodsMakerCdEd.ToString());
                    // DEL yangyi 2012/06/08 Redmine#30282 ------------->>>>>
                    //// ----------ADD 2009/11/30------------>>>>>>
                    //// 拠点
                    //dr[ctSectionCode] = targetInventDataPreWork.SectionCode.Trim();
                    //// ----------ADD 2009/11/30------------<<<<<
                    // DEL yangyi 2012/06/08 Redmine#30282 -------------<<<<<

                }

                dt.Rows.Add(dr);
            }
        }
        // --- ADD 2008/08/28 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/08/28 Partsman用に変更
        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 棚卸準備履歴データセット格納
		/// </summary>	
		private void PrtIvntHisDataSetting()
		{
			DataSet dataSet = null;
			DataTable dt;
			DataRow dr;

			if (this._prtIvntHisDataSet == null)
			{
				this._prtIvntHisDataSet = new DataSet(ctPrtIvntHis_Table);
			}

			dataSet = this._prtIvntHisDataSet;

            //既にデータテーブルが存在するか？
			if (dataSet.Tables.Contains(ctM_PrtIvntHis_Table))
            {
                dt = dataSet.Tables[ctM_PrtIvntHis_Table];
            }		
			else
			{
        	    //テーブル作成
				dt = dataSet.Tables.Add(ctM_PrtIvntHis_Table);

				dt.Columns.Add(new DataColumn(ctInventoryPreprDate	    , typeof(string)));		// 処理日
				dt.Columns.Add(new DataColumn(ctInventoryPreprTime	    , typeof(string)));		// 処理時間	
                dt.Columns.Add(new DataColumn(ctInventoryProcDiv_Hidden , typeof(int   )));     // 処理区分(非表示)
			    dt.Columns.Add(new DataColumn(ctInventoryProcDiv        , typeof(string)));     // 処理区分名称
                // 2007.09.10 追加 >>>>>>>>>>>>>>>>>>>>
                dt.Columns.Add(new DataColumn(ctInventoryDate           , typeof(string)));	    // 棚卸日
                // 2007.09.10 追加 <<<<<<<<<<<<<<<<<<<<
                // 2008.02.25 追加 >>>>>>>>>>>>>>>>>>>>
                dt.Columns.Add(new DataColumn(ctInventoryDate_Int       , typeof(int   )));
                dt.Columns.Add(new DataColumn(ctInventoryPreprDate_Int  , typeof(int   )));
                dt.Columns.Add(new DataColumn(ctInventoryPreprTime_Int  , typeof(int   )));
                // 2008.02.25 追加 <<<<<<<<<<<<<<<<<<<<
                dt.Columns.Add(new DataColumn(ctWareHouseCode           , typeof(string)));	    // 倉庫
                dt.Columns.Add(new DataColumn(ctMakerCode               , typeof(string)));		// メーカー
                // 2007.09.10 削除 >>>>>>>>>>>>>>>>>>>>
                //dt.Columns.Add(new DataColumn(ctCarrierName           , typeof(string)));		// キャリア
                // 2007.09.10 削除 <<<<<<<<<<<<<<<<<<<<
                dt.Columns.Add(new DataColumn(ctLargeGoodsCode          , typeof(string)));		// 商品区分グループ
                dt.Columns.Add(new DataColumn(ctMediumGoodsCode         , typeof(string)));		// 商品区分
                dt.Columns.Add(new DataColumn(ctGoodsKind               , typeof(string)));		// 商品種別
                dt.Columns.Add(new DataColumn(ctGoodsCode               , typeof(string)));		// 商品
                // 2007.09.10 削除 >>>>>>>>>>>>>>>>>>>>
                //dt.Columns.Add(new DataColumn(ctCellphoneModelCode    , typeof(string)));	    // 機種
                // 2007.09.10 削除 <<<<<<<<<<<<<<<<<<<<
                dt.Columns.Add(new DataColumn(ctStockExtraDiv           , typeof(string)));		// 在庫区分
				dt.Columns.Add(new DataColumn(ctLastInventoryUpd		, typeof(string)));		// 最終棚卸更新日

				dt.Columns[ctInventoryPreprDate	            ].Caption = "処理日";				// 処理日
				dt.Columns[ctInventoryPreprTime	            ].Caption = "処理時間";				// 処理時間
                dt.Columns[ctInventoryProcDiv_Hidden	    ].Caption = "処理区分(非表示)";		// 処理区分(非表示)
			    dt.Columns[ctInventoryProcDiv               ].Caption = "処理区分";             // 処理区分
                // 2007.09.10 追加 >>>>>>>>>>>>>>>>>>>>
                dt.Columns[ctInventoryDate                  ].Caption = "棚卸日";				// 棚卸日
                // 2007.09.10 追加 <<<<<<<<<<<<<<<<<<<<
                // 2008.02.25 追加 >>>>>>>>>>>>>>>>>>>>
                dt.Columns[ctInventoryDate_Int              ].Caption = "棚卸実施日";           // 棚卸実施日
                dt.Columns[ctInventoryPreprDate_Int         ].Caption = "棚卸準備処理日";       // 棚卸準備処理日
                dt.Columns[ctInventoryPreprTime_Int         ].Caption = "棚卸準備処理時間";     // 棚卸準備処理時間
                // 2008.02.25 追加 <<<<<<<<<<<<<<<<<<<<
                dt.Columns[ctWareHouseCode                  ].Caption = "倉庫";					// 倉庫
				dt.Columns[ctMakerCode		                ].Caption = "メーカー";				// メーカー
                // 2007.09.10 削除 >>>>>>>>>>>>>>>>>>>>
                //dt.Columns[ctCarrierName                      ].Caption = "キャリア";				// キャリア
                // 2007.09.10 削除 <<<<<<<<<<<<<<<<<<<<
                dt.Columns[ctLargeGoodsCode                 ].Caption = "商品区分グループ";		// 商品区分グループ
                // 2007.09.10 削除 >>>>>>>>>>>>>>>>>>>>
                dt.Columns[ctMediumGoodsCode                ].Caption = "商品区分";		        // 商品区分
                // 2007.09.10 削除 >>>>>>>>>>>>>>>>>>>>
                dt.Columns[ctGoodsKind                      ].Caption = "商品種別";	            // 商品種別
                // 2007.09.10 削除 <<<<<<<<<<<<<<<<<<<<
                dt.Columns[ctGoodsCode                      ].Caption = "商品";	　              // 商品
                // 2007.09.10 削除 >>>>>>>>>>>>>>>>>>>>
                //dt.Columns[ctCellphoneModelCode           ].Caption = "機種";			        // 機種	
                // 2007.09.10 削除 <<<<<<<<<<<<<<<<<<<<
                dt.Columns[ctStockExtraDiv                  ].Caption = "在庫区分";				// 在庫区分
				dt.Columns[ctLastInventoryUpd		        ].Caption = "最終棚卸更新日";		// 最終棚卸更新日              
            }

			dt.Clear();

            //データセット格納処理
			InventDataPreWork targetInventDataPreWork;
			for ( int workCounter = this._prtIvntHisWorkList.Count; workCounter > 0; workCounter-- )
			{
                targetInventDataPreWork = (InventDataPreWork)this._prtIvntHisWorkList[ workCounter - 1 ];
                // DataRowを作成
                dr = dt.NewRow();

                //データテーブル作成
                string start ="";
                string end ="";
                ArrayList workList = new ArrayList();

                // 処理日付
                if (targetInventDataPreWork.InventoryPreprDay != DateTime.MinValue)
                {
                    dr[ctInventoryPreprDate] = TDateTime.DateTimeToString("YYYY/MM/DD", targetInventDataPreWork.InventoryPreprDay);
                }                   
                // 処理時間
                dr[ctInventoryPreprTime] = targetInventDataPreWork.InventoryPreprTim.ToString("0#:0#:0#");
                     
                //処理区分(非表示)
                dr[ctInventoryProcDiv_Hidden] = targetInventDataPreWork.InventoryProcDiv;

                //処理区分
                if(targetInventDataPreWork.InventoryProcDiv == 3)
                {
                    //棚卸データ削除
                    dr[ctInventoryProcDiv] = "棚卸データ削除";
                }
                else
                {
                    //棚卸準備処理
                    dr[ctInventoryProcDiv] = "棚卸準備処理";
                }

                // 2007.09.10 追加 >>>>>>>>>>>>>>>>>>>>
                //棚卸日
                dr[ctInventoryDate] = TDateTime.DateTimeToString("YYYY/MM/DD", targetInventDataPreWork.InventoryDate);
                // 2007.09.10 追加 <<<<<<<<<<<<<<<<<<<<

                // 2008.02.25 追加 >>>>>>>>>>>>>>>>>>>>
                //棚卸実施日（数値）
                dr[ctInventoryDate_Int]      = TDateTime.DateTimeToLongDate(targetInventDataPreWork.InventoryDate);
                //棚卸準備処理日（数値）
                dr[ctInventoryPreprDate_Int] = TDateTime.DateTimeToLongDate(targetInventDataPreWork.InventoryPreprDay);
                //棚卸準備処理時間（数値）
                dr[ctInventoryPreprTime_Int] = targetInventDataPreWork.InventoryPreprTim;
                // 2008.02.25 追加 <<<<<<<<<<<<<<<<<<<<

                //処理区分が削除の時は条件はいらない
                if(targetInventDataPreWork.InventoryProcDiv != 3)
                {
                    // 倉庫               
			        if( (targetInventDataPreWork.WarehouseCodeSt != "" ) || (targetInventDataPreWork.WarehouseCodeEd != "" ) ) 
                    {              
                        if(targetInventDataPreWork.WarehouseCodeSt == "")
                        {
                            start = "ＴＯＰ";
                        }
                        else
                        {
                            start = targetInventDataPreWork.WarehouseCodeSt;
                        }
                        if(targetInventDataPreWork.WarehouseCodeEd == "")
                        {
                            end   = "ＥＮＤ";
                        }
                        else
                        {
                            end = targetInventDataPreWork.WarehouseCodeEd;
                        }
				        dr[ctWareHouseCode] = String.Format("{0} ～ {1}", 
				        start, end );				    
			        }

                    // メーカー             
				    dr[ctMakerCode] = String.Format("{0} ～ {1}", 
                    targetInventDataPreWork.GoodsMakerCdSt.ToString(),targetInventDataPreWork.GoodsMakerCdEd.ToString());
                    // 2007.09.10 削除 >>>>>>>>>>>>>>>>>>>>
                    ////キャリア
                    //dr[ctCarrierName] =  String.Format("{0} ～ {1}", 
                    //targetInventDataPreWork.CarrierCdSt.ToString(),targetInventDataPreWork.CarrierCdEd.ToString());
                    // 2007.09.10 削除 <<<<<<<<<<<<<<<<<<<<
                   
                    //商品区分グループ
                    if( (targetInventDataPreWork.LgGoodsGanreCdSt != "" ) || (targetInventDataPreWork.LgGoodsGanreCdEd != "" ) ) 
                    {      
                        start = "";
                        end = "";
                        if(targetInventDataPreWork.LgGoodsGanreCdSt == "")
                        {
                            start = "ＴＯＰ";
                        }
                        else
                        {
                            start = targetInventDataPreWork.LgGoodsGanreCdSt;
                        }
                        if(targetInventDataPreWork.LgGoodsGanreCdEd == "")
                        {
                            end   = "ＥＮＤ";
                        }
                        else
                        {
                            end = targetInventDataPreWork.LgGoodsGanreCdEd;
                        }
				        dr[ctLargeGoodsCode] = String.Format("{0} ～ {1}", 
				        start, end );				    
			        }

                    //商品区分
                    if( (targetInventDataPreWork.MdGoodsGanreCdSt != "" ) || (targetInventDataPreWork.MdGoodsGanreCdEd != "" ) ) 
                    {      
                        start = "";
                        end = "";
                        if(targetInventDataPreWork.MdGoodsGanreCdSt == "")
                        {
                            start = "ＴＯＰ";
                        }
                        else
                        {
                            start = targetInventDataPreWork.MdGoodsGanreCdSt;
                        }
                        if(targetInventDataPreWork.MdGoodsGanreCdEd == "")
                        {
                            end   = "ＥＮＤ";
                        }
                        else
                        {
                            end = targetInventDataPreWork.MdGoodsGanreCdEd;
                        }
				        dr[ctMediumGoodsCode] = String.Format("{0} ～ {1}", 
				        start, end );				    
			        }

                    // 2007.09.10 削除 >>>>>>>>>>>>>>>>>>>>
                    ////商品種別
                    //workList.Clear();
                    ////一般               
                    //switch(targetInventDataPreWork.GeneralGoodsExtDiv)
                    //{
                    //    case 0:
                    //    {
                    //        //抽出する
                    //        workList.Add(ctGeneralGoodsExtDivName);
                    //        break;
                    //    }
                    //    case 1:
                    //    {
                    //        //抽出しない
                    //        break;
                    //    }
                    //}
                    ////携帯電話               
                    //switch(targetInventDataPreWork.MobileGoodsExtDiv)
                    //{
                    //    case 0:
                    //    {
                    //        //抽出する
                    //        workList.Add(ctMobileGoodsExtDivName);
                    //        break;
                    //    }
                    //    case 1:
                    //    {
                    //        //抽出しない
                    //        break;
                    //    }
                    //}
                    ////付属品               
                    //switch(targetInventDataPreWork.AcsryGoodsExtDiv)
                    //{
                    //    case 0:
                    //    {
                    //        //抽出する
                    //        workList.Add(ctAcsryGoodsExtDivName);
                    //        break;
                    //    }
                    //    case 1:
                    //    {
                    //        //抽出しない
                    //        break;
                    //    }
                    //}
                    ////少なくとも一つは入っているので
                    //string[] goodsList = (string[])workList.ToArray(typeof(string));
                    //dr[ctGoodsKind] = String.Join(",",goodsList);
                    //
                    ////商品
                    //if( (targetInventDataPreWork.KtGoodsCdSt != "" ) || (targetInventDataPreWork.KtGoodsCdEd != "" ) ) 
                    //{         
                    //    start = "";
                    //    end = "";
                    //    if(targetInventDataPreWork.KtGoodsCdSt == "")
                    //    {
                    //        start = "ＴＯＰ";
                    //    }
                    //    else
                    //    {
                    //        start = targetInventDataPreWork.KtGoodsCdSt;
                    //    }
                    //    if(targetInventDataPreWork.KtGoodsCdEd == "")
                    //    {
                    //        end   = "ＥＮＤ";
                    //    }
                    //    else
                    //    {
                    //        end = targetInventDataPreWork.KtGoodsCdEd;
                    //    }
                    //    dr[ctGoodsCode] = String.Format("{0} ～ {1}", 
                    //    start, end );				    
                    //}
                    //
                    ////機種
                    //if( (targetInventDataPreWork.CellphoneModelCdSt != "" ) || (targetInventDataPreWork.CellphoneModelCdEd != "" ) ) 
                    //{              
                    //    if(targetInventDataPreWork.CellphoneModelCdSt == "")
                    //    {
                    //        start = "ＴＯＰ";
                    //    }
                    //    else
                    //    {
                    //        start = targetInventDataPreWork.CellphoneModelCdSt;
                    //    }
                    //    if(targetInventDataPreWork.CellphoneModelCdEd == "")
                    //    {
                    //        end   = "ＥＮＤ";
                    //    }
                    //    else
                    //    {
                    //        end = targetInventDataPreWork.CellphoneModelCdEd;
                    //    }
				    //    dr[ctCellphoneModelCode] = String.Format("{0} ～ {1}", 
				    //    start, end );				    
			        //}
                    // 2007.09.10 削除 <<<<<<<<<<<<<<<<<<<<

                    // 最終棚卸更新日
                    if ((targetInventDataPreWork.LtInventoryUpdateSt != DateTime.MinValue) || (targetInventDataPreWork.LtInventoryUpdateEd != DateTime.MinValue))
                    {
                        if(targetInventDataPreWork.LtInventoryUpdateSt == DateTime.MinValue)
                        {
                            start = "ＴＯＰ";
                        }
                        else
                        {
                            start = TDateTime.DateTimeToString("YYYY/MM/DD", targetInventDataPreWork.LtInventoryUpdateSt);
                        }

                        if(targetInventDataPreWork.LtInventoryUpdateEd == DateTime.MinValue)
                        {
                            end   = "ＥＮＤ";
                        }
                        else
                        {
                            end = TDateTime.DateTimeToString("YYYY/MM/DD", targetInventDataPreWork.LtInventoryUpdateEd);
                        }

				        dr[ctLastInventoryUpd] = String.Format("{0} ～ {1}", 
				        start, end );				    
              
                    }

                    // 2007.09.10 削除 >>>>>>>>>>>>>>>>>>>>
                    ////抽出在庫
                    //workList.Clear();
                    ////自社在庫抽出区分
                    //switch(targetInventDataPreWork.CmpStkExtraDiv)
                    //{
                    //    case 0:
                    //    {
                    //        //抽出する
                    //        workList.Add(ctCompStockExtraDivName);
                    //        break;
                    //    }
                    //    case 1:
                    //    {
                    //        //抽出しない
                    //        break;
                    //    }
                    //}
                    ////受託在庫抽出区分
                    //switch(targetInventDataPreWork.TrtStkExtraDiv)
                    //{
                    //    case 0:
                    //    {
                    //        //抽出する
                    //        workList.Add(ctTrstStockExtraDivName);
                    //        break;
                    //    }
                    //    case 1:
                    //    {
                    //        //抽出しない
                    //        break;
                    //    }
                    //}
                    ////委託(自社)在庫抽出区分
                    //switch(targetInventDataPreWork.EntCmpStkExtraDiv)
                    //{
                    //    case 0:
                    //    {
                    //        //抽出する
                    //        workList.Add(ctEnTrustCmpStockExtraDivName);
                    //        break;
                    //    }
                    //    case 1:
                    //    {
                    //        //抽出しない
                    //        break;
                    //    }
                    //}
                    ////委託(受託)在庫抽出区分
                    //switch(targetInventDataPreWork.EntTrtStkExtraDiv)
                    //{
                    //    case 0:
                    //    {
                    //        //抽出する
                    //        workList.Add(ctEnTrustTrsStockExtraDivName);
                    //        break;
                    //    }
                    //    case 1:
                    //    {
                    //        //抽出しない
                    //        break;
                    //    }
                    //}
                    //少なくとも一つは入っているので
                    string[] list = (string[])workList.ToArray(typeof(string));
                    dr[ctStockExtraDiv] = String.Join(",",list);
                    // 2007.09.10 削除 <<<<<<<<<<<<<<<<<<<<

                }

                dt.Rows.Add(dr);
			}
		}
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/28 Partsman用に変更

        #endregion

        # endregion

        # region Public Methods

        #region 登録前処理
        /// <summary>
		/// 登録前処理
		/// </summary>
		/// <param name="retCount">重複件数</param>
		/// <param name="inventorySearchCndtnWork">棚卸データ検索用抽出条件</param>
		/// <returns>Status</returns>
		public int SearchCnt( out int retCount, InventInputSearchCndtnWork inventInputSearchCndtnWork)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            object paraobj = inventInputSearchCndtnWork;
            try
            {
                //棚卸データマスタの件数確認 
                status = this._iInventInputSearchDB.SearchCount(out retCount,paraobj,0,ConstantManagement.LogicalMode.GetData0);
               
                // StatusとretCount
                // 件数無：EOF、ゼロ
                // 件数有：Nomal、1以上
                if ( ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL ) &&
                    ( status != (int)ConstantManagement.DB_Status.ctDB_EOF) )
                {
                    // NomalでもEOFでもなければエラーとみなして後続の処理を行わない。
                    retCount = 0;
                    return status;
                }

                //retCount = 1;
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
 
            }
            catch( Exception )
            {
                retCount = -1;
                // 通信エラー時は-1を返す
                status = -1;
            }

			return status;
		}

        // --- ADD 2009/11/30 ---------->>>>>
        /// <summary>
		/// 登録前処理
		/// </summary>
        /// <param name="al">棚卸データ</param>
        /// <param name="inventoryExtCndtnWork">棚卸データ検索用抽出条件</param>
		/// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 登録前処理します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.11.30</br>
        /// </remarks>
        public int SearchRepateDate(InventoryExtCndtnWork inventoryExtCndtnWork, out string retMsg,ref bool repateFlag)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            retMsg = "";		// エラー時メッセージ

            try
            {
                object retObj = null;
                status = this._iInventoryExtDB.SearchRepateDate(out retObj, (object)inventoryExtCndtnWork, 0, ConstantManagement.LogicalMode.GetData0, out retMsg);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    repateFlag = (bool)retObj;
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iInventoryExtDB = null;
                // 通信エラー時は-1を返す
                status = -1;
            }

            return status;
        }
        // --- ADD 2009/11/30 ----------<<<<<
		#endregion

		#region 登録処理
		/// <summary>
		/// 登録処理
		/// </summary>
		/// <param name="inventoryExtCndtnWork">棚卸準備処理抽出条件クラスワーク</param>
		/// <param name="retMsg">エラー時メッセージ</param>
		/// <returns>Status</returns>
		public int WriteDBData(InventoryExtCndtnWork inventoryExtCndtnWork, out string retMsg)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			retMsg = "";		// エラー時メッセージ

			try
			{
				object retObj = null;
                status = this._iInventoryExtDB.SearchWrite(out retObj, (object)inventoryExtCndtnWork, 0, ConstantManagement.LogicalMode.GetData0, out retMsg);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// 書き込んだ抽出条件クラスをPublicで宣言している抽出条件クラスにコピーしておく
					this._inventoryExtCndtnWork = inventoryExtCndtnWork;
					
                    // 戻ってきた履歴を履歴リストにAdd
                    ArrayList list = retObj as ArrayList;

                    //１件しかないので
                    InventDataPreWork work = (InventDataPreWork)list[0];
                    this._prtIvntHisWorkList.Add(work);

                    // データセット再構築(例外はCatchステートメントで取る。)
					PrtIvntHisDataSetting();
				}
                
			}
			catch (Exception)
			{
				// オフライン時はnullをセット
				this._iInventoryExtDB = null;
				// 通信エラー時は-1を返す
				status = -1;
			}

			return status;
		}
		#endregion

		#region 棚卸準備処理抽出条件ワーククラス取得
        
		/// <summary>
		/// 棚卸準備処理抽出条件クラスワークを返します
		/// </summary>
		/// <param name="inventoryExtCndtnWork">部品棚卸準備処理抽出条件クラスワーク</param>
		/// <returns>0: 成功</returns>
		public int Read(out InventoryExtCndtnWork inventoryExtCndtnWork)
		{
            if (this._inventoryExtCndtnWork == null)
            {
                this._inventoryExtCndtnWork = new InventoryExtCndtnWork();
                //企業コード
                this._inventoryExtCndtnWork.EnterpriseCode = this._enterpriseCode;
                //自拠点コード           
                this._inventoryExtCndtnWork.SectionCode = this._loginSectionCode;               
            }

            inventoryExtCndtnWork = this._inventoryExtCndtnWork;

			return 0;
		}
        
		#endregion

		#region 棚卸準備履歴DataSet取得
		/// <summary>
		/// 棚卸準備履歴ワークを返します
		/// </summary>
		/// <param name="dataSet">棚卸準備履歴ワーク（DataSet）</param>
		/// <returns>0: 成功</returns>
		public int Read(out DataSet dataSet)
		{
			if (this._prtIvntHisDataSet == null)
				this._prtIvntHisDataSet = new DataSet(ctPrtIvntHis_Table);

			dataSet = this._prtIvntHisDataSet;

			return 0;
		}
		# endregion

        #region 棚卸データ削除

        /// <summary>
		/// 削除処理
		/// </summary>
		/// <param name="inventoryDataWork">棚卸準備処理抽出条件クラスワーク</param>
		/// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 棚卸データの削除を行います</br>
	    /// <br>Programmer : 23010 中村　仁</br>
	    /// <br>Date       : 2007.04.13</br>
        /// </remarks>
        public int Delete(InventoryDataWork inventoryDataWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                //棚卸データの削除
                byte[] retbyte; 
                byte[] parabyte = XmlByteSerializer.Serialize(inventoryDataWork);

                status = this._iInventoryExtDB.DeleteInvent(parabyte,out retbyte);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
                    InventDataPreWork work = (InventDataPreWork)XmlByteSerializer.Deserialize(retbyte,typeof(InventDataPreWork));
					//履歴リストに追加					
                    this._prtIvntHisWorkList.Add(work);//this._prtIvntHisWorkList = (ArrayList)((ArrayList)retObj).Clone();
					// データセット再構築(例外はCatchステートメントで取る。)
					PrtIvntHisDataSetting();
				}

                //ステータスはフレーム側で処理するので特に処理は入れない              
            }
            catch(Exception)
            {
                // オフライン時はnullをセット
				this._iInventoryExtDB = null;
				// 通信エラー時は-1を返す
				status = -1;
            }
            return status;
        }

        #endregion

        #region DEL 2008/08/28 使用していないのでコメントアウト
        /* --- DEL 2008/08/28 --------------------------------------------------------------------->>>>>
        #region 在庫管理全体設定マスタ読込
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
				if (_stockMngTtlStData != null)
				{
					stockMngTtlSt = _stockMngTtlStData.Clone(); 
					status    = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				} 
				else 
				{
					status = _stockMngTtlStAcs.Read(out stockMngTtlSt, LoginInfoAcquisition.EnterpriseCode,0);

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
        #endregion

        // 2008.02.25 追加 >>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 在庫受払履歴データ読込
		/// </summary>
        /// <param name="inventoryExtCndtnWork">棚卸準備処理抽出条件クラスワーク</param>
        /// <param name="message">エラーメッセージ</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
        /// <br>Note       : 在庫受払履歴データの読込を行います。</br>
		/// <br>Programmer : 980035 金沢　貞義</br>
		/// <br>Date       : 2008.02.25</br>
		/// </remarks>
        public int ReadStockAcPayHist(ref InventoryExtCndtnWork inventoryExtCndtnWork, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

			if (this._iStockAcPayHisSearchDB == null)
			{
                this._iStockAcPayHisSearchDB = (IStockAcPayHisSearchDB)MediationStockAcPayHisSearchDB.GetStockAcPayHisSearchDB();
			}

            try
            {
                object objectStockAcPayListWork = null;
                object objectStockAcPayPara = CopyToSearchParaWorkFromSearchPara(inventoryExtCndtnWork);

                // 在庫受払履歴検索
                status = this._iStockAcPayHisSearchDB.Search(out objectStockAcPayListWork, objectStockAcPayPara, 0, ConstantManagement.LogicalMode.GetData0);
                if (status == 0)
                {
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
			return status;
        }

        /// <summary>
        /// データ変換（SearchPara→SearchParaWork）
        /// </summary>
        /// <param name="inventoryExtCndtnWork"></param>
        /// <returns></returns>
        private StockAcPayHisSearchParaWork CopyToSearchParaWorkFromSearchPara(InventoryExtCndtnWork inventoryExtCndtnWork)
        {
            StockAcPayHisSearchParaWork paraWork = new StockAcPayHisSearchParaWork();

            paraWork.EnterpriseCode     = inventoryExtCndtnWork.EnterpriseCode; // 企業コード
            //paraWork.ValidDivCd         = 0;                                    // 有効区分
            paraWork.St_IoGoodsDay      = 0;                                    // 開始入出荷日
            paraWork.Ed_IoGoodsDay      = 99999999;                             // 終了入出荷日
            //paraWork.St_AddUpADate      = GetLongDateFromDateTime(inventoryExtCndtnWork.St_AddUpADate); // 開始計上日付

            // --- CHG 2008/08/28 --------------------------------------------------------------------->>>>>
            //paraWork.Ed_AddUpADate = GetLongDateFromDateTime(inventoryExtCndtnWork.InventoryDate); // 終了計上日付
            paraWork.Ed_AddUpADate = TDateTime.DateTimeToLongDate(inventoryExtCndtnWork.InventoryDate); // 終了計上日付
            // --- CHG 2008/08/28 ---------------------------------------------------------------------<<<<<
            
            //paraWork.AcPaySlipCd        = inventoryExtCndtnWork.AcPaySlipCd; // 受払元伝票区分
            paraWork.SectionCodes[0]    = inventoryExtCndtnWork.SectionCode;    // 拠点コード（複数指定）
            paraWork.St_WarehouseCode   = inventoryExtCndtnWork.StWarehouseCd;  // 開始倉庫コード
            paraWork.Ed_WarehouseCode   = inventoryExtCndtnWork.EdWarehouseCd;  // 終了倉庫コード
            paraWork.St_GoodsMakerCd    = inventoryExtCndtnWork.StMakerCd;      // 開始商品メーカーコード
            paraWork.Ed_GoodsMakerCd    = inventoryExtCndtnWork.EdMakerCd;      // 終了商品メーカーコード
            paraWork.St_AcPaySlipNum    = string.Empty;                         // 開始受払元伝票番号
            paraWork.Ed_AcPaySlipNum    = string.Empty;                         // 終了受払元伝票番号
            paraWork.St_GoodsNo         = string.Empty;                         // 開始商品番号
            paraWork.Ed_GoodsNo         = string.Empty;                         // 終了商品番号

            return paraWork;
        }

        /// <summary>
        /// YYYYMMDD日付取得処理 (但しDateTime.MinValueならば0に変換)
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private int GetLongDateFromDateTime(DateTime dateTime)
        {
            if (dateTime == DateTime.MinValue)
            {
                return 0;
            }
            else
            {
                return (dateTime.Year * 10000) + (dateTime.Month * 100) + dateTime.Day;
            }
        }
        /// <summary>
        
        // 2008.02.25 追加 <<<<<<<<<<<<<<<<<<<<
           --- DEL 2008/08/28 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/28 使用していないのでコメントアウト
        // ADD yangyi 2012/06/08 Redmine#30282 ------------->>>>>
        /// <summary>
        /// 棚卸データ戻します
        /// </summary>
        /// <param name="retCount">件数</param>
        /// <param name="inventorySearchCndtnWork">棚卸データ検索用抽出条件</param>
        /// <returns>Status</returns>
        public int SearchInventoryData(out object retobj, InventoryDataWork inventoryDataWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            object paraobj = inventoryDataWork;
            retobj = null;
            try
            {
                //棚卸データマスタの件数確認 
                status = this._iInventoryExtDB.SearchInventoryData(out retobj, paraobj, ConstantManagement.LogicalMode.GetData0);

                // StatusとretCount
                // 件数無：EOF、ゼロ
                // 件数有：Nomal、1以上
                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    // NomalでもEOFでもなければエラーとみなして後続の処理を行わない。
                    return status;
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            }
            catch (Exception)
            {
                // 通信エラー時は-1を返す
                status = -1;
            }

            return status;
        }
        // ADD yangyi 2012/06/08 Redmine#30282 -------------<<<<<

        #endregion
    }
}

//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 棚卸過不足更新
// プログラム概要   : 棚卸過不足更新で使用するデータの取得・更新を行う。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 妻鳥　謙一郎
// 作 成 日  2007/07/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2008/02/26  修正内容 : 仕様変更対応（DC.NS対応）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2008/03/26  修正内容 : NetAdvantageバージョンアップ対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 修 正 日  2008/09/10  修正内容 : 仕様変更対応（Partsman対応）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/04/28  修正内容 : 不具合対応[13091]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/05/22  修正内容 : 不具合対応[13243][13263]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 長内 数馬
// 修 正 日  2009/09/14  修正内容 : 不具合対応[13921]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/12/03  修正内容 : PM.NS　保守対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 作 成 日  2010/01/28  修正内容 : Mantis:14949 同一拠点同一通番で棚番違いのデータがあると不具合が起こる件についての修正
//----------------------------------------------------------------------------//
// 管理番号  10600008-00 作成担当 : 楊明俊
// 作 成 日  2010/02/23  修正内容 : PM1005の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : LDNS
// 作 成 日  2011/01/11  修正内容 : 棚卸障害対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : yangyi
// 修 正 日  2012/07/19  修正内容 : redmine#31106 「棚卸過不足更新」の負荷軽減と処理時間短縮の調査
// ---------------------------------------------------------------------//
// 管理番号  10904597-00 作成担当 : yangyi
// 修 正 日  2013/10/09  修正内容 : redmine#31106 「棚卸過不足更新」の負荷軽減と処理時間短縮の調査
// ---------------------------------------------------------------------//
// 管理番号  11070149-00 作成担当 : 陳嘯
// 修 正 日  K2015/08/21  修正内容 : redmine#46790  棚卸過不足更新　メモリアウトの修正
// ---------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;

using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
//using Broadleaf.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 棚卸過不足更新アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 棚卸過不足更新のアクセスクラスです。</br>
	/// <br>Programmer : 980076 妻鳥　謙一郎</br>
	/// <br>Date       : 2007.07.10</br>
    /// <br>Update Note: 2008.02.26 980035 金沢 貞義</br>
    /// <br>			 ・仕様変更対応（DC.NS対応）</br>
    /// <br>Update Note: 2008.03.26 980035 金沢 貞義</br>
    /// <br>			 ・NetAdvantageバージョンアップ対応</br>
    /// <br>Update Note: 2008/09/10 30414 忍 幸史</br>
    /// <br>			 ・仕様変更対応（Partsman対応）</br>
    /// <br>           : 2009/04/28       照田 貴志　不具合対応[13091]</br>
    /// <br>           : 2009/05/22       照田 貴志　不具合対応[13243][13263]</br>
    /// <br>UpdateNote : 2009/12/03 李占川 PM.NS　保守対応</br>
    /// <br>UpdateNote : 2010/02/23 楊明俊 PM1005</br>
    /// <br>Update Note: 2012/07/19 yangyi</br>
    /// <br>             redmine#31106 「棚卸過不足更新」の負荷軽減と処理時間短縮の調査</br>
    /// <br>Update Note: K2015/08/21 陳嘯</br>
    /// <br>             redmine#46790 棚卸過不足更新　メモリアウトの修正</br>
    /// </remarks>
	public partial class InventoryUpdateAcs
	{
		public InventoryUpdateAcs()
		{
			this._iInventInputSearchDB = MediationInventInputSearchDB.GetInventInputSearchDB();
			this._iStockAdjustDB = MediationStockAdjustDB.GetStockAdjustDB();
			this._dataSet = new InventoryUpdateDataSet();
			this._inventoryDataDictionary = new Dictionary<string, InventoryDataUpdateWork>();

            /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
			this._searchStochAch = new SearchStockAcs();
               --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/

            // --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
            this._warehouseAcs = new WarehouseAcs();
            this._goodsAcs = new GoodsAcs();
            this._secInfoAcs = new SecInfoAcs();
            this._makerAcs = new MakerAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            // ----- ADD 2012/07/19 ---------->>>>>
            this._totalDayDic = new Dictionary<string, DateTime>();
            this._goodsUnitDataDic = new Dictionary<string, GoodsUnitData>();
            // ----- ADD 2012/07/19 ----------<<<<<

            // マスタ読込
            LoadSecInfoSet();
            LoadWarehouse();
            LoadMakerUMnt();
            LoadBLGoodsCdUMnt();

            this._totalDayCalculator = TotalDayCalculator.GetInstance();
            this._totalDayCalculator.InitializeHisMonthly();
            // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<

            // ---ADD 2009/05/22 不具合対応[13263] -------------------------------------->>>>>
            this._stockMngTtlStAcs = new StockMngTtlStAcs();        //在庫全体設定マスタアクセス

            // 在庫全体設定情報取得
            this.ReadStockMngTtlSt();
            // ---ADD 2009/05/22 不具合対応[13263] --------------------------------------<<<<<
        }

		IInventInputSearchDB _iInventInputSearchDB;
		IStockAdjustDB _iStockAdjustDB;
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		private static StockMngTtlSt _stockMngTtlSt;
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        private InventoryUpdateDataSet _dataSet;
		private Dictionary<string, InventoryDataUpdateWork> _inventoryDataDictionary;

        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		private SearchStockAcs _searchStochAch;
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        
        // --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
        private WarehouseAcs _warehouseAcs;
        private GoodsAcs _goodsAcs;
        private SecInfoAcs _secInfoAcs;
        private MakerAcs _makerAcs;
        private BLGoodsCdAcs _blGoodsCdAcs;

        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<string, Warehouse> _warehouseDic;
        private Dictionary<int, MakerUMnt> _makerUMntDic;
        private Dictionary<int, BLGoodsCdUMnt> _blGoodsCdUMntDic;
        // ----- ADD 2012/07/19 ---------->>>>>
        private Dictionary<string, DateTime> _totalDayDic;
        private Dictionary<string, GoodsUnitData> _goodsUnitDataDic;
        // ----- ADD 2012/07/19 ----------<<<<<

        /// <summary>締日算出モジュール</summary>
        private TotalDayCalculator _totalDayCalculator = null;
        // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<

        // ---ADD 2009/05/22 不具合対応[13263] -------------------------------------->>>>>
        private StockMngTtlStAcs _stockMngTtlStAcs = null;              //在庫全体設定マスタアクセス
        private StockMngTtlSt _stockMngTtlSt = null;                    //在庫管理全体設定
        // ---ADD 2009/05/22 不具合対応[13263] -------------------------------------->>>>>

        private Dictionary<string, List<GoodsPriceUWork>> _dicPriceList;  //ADD yangyi 2013/10/09 Redmine#31106 

        public InventoryUpdateDataSet DataSet
		{
			get { return _dataSet; }
		}

		public DataView DataView
		{
			get
			{
				return this._dataSet.Inventory.DefaultView; 
			}
		}

		public DataView ErrorDataView
		{
			get
			{
				return this._dataSet.ErrorData.DefaultView;
			}
        }

        #region DEL 2008/09/10 Partsman用に変更
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 棚卸データを検索し、検索結果をデータテーブルにキャッシュします。
		/// </summary>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="inventoryDay">実施日</param>
		/// <param name="difCntExtraDiv">0:全て表示 1:過不足発生分のみ表示</param>
		/// <returns>STATUS</returns>
        // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
        //public int Search(string sectionCode, DateTime inventoryDaySta, DateTime inventoryDayEnd, int difCntExtraDiv)
        public int Search(string sectionCode, DateTime inventoryDaySta, DateTime inventoryDayEnd, int difCntExtraDiv, 
                          string warehouseCdSta, string warehouseCdEnd, string shelfNoSta, string shelfNoEnd)
        // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<
		{
			this._dataSet.Inventory.DefaultView.RowFilter = "";
			this._dataSet.Inventory.Rows.Clear();
			
			this._dataSet.ErrorData.Rows.Clear();
			this._dataSet.ErrorData.DefaultView.RowFilter = "";

			this._dataSet.InventoryNumberInfo.Rows.Clear();

			this._inventoryDataDictionary.Clear();

			InventInputSearchCndtnWork para = new InventInputSearchCndtnWork();
			para.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // 2008.02.26 修正 >>>>>>>>>>>>>>>>>>>>
            //para.St_InventoryDay = inventoryDaySta;
            para.InventoryDate = inventoryDaySta;
            // 2008.02.26 修正 <<<<<<<<<<<<<<<<<<<<

            // 2008.02.26 削除 >>>>>>>>>>>>>>>>>>>>
            //if (para.St_InventoryDay == DateTime.MinValue)
            //{
            //    para.St_InventoryDay = para.St_InventoryDay.AddDays(1);
            //}

            //para.Ed_InventoryDay = inventoryDayEnd;
            // 2008.02.26 削除 <<<<<<<<<<<<<<<<<<<<
            para.SectionCode = sectionCode;
			para.DifCntExtraDiv = 0;
			para.St_InventorySeqNo = 0;
			para.Ed_InventorySeqNo = 999999;
            // 2007.09.20 削除 >>>>>>>>>>>>>>>>>>>>
            //para.CompanyStockExtraDiv = (int)InventInputSearchCndtn.StockExtraDivState.Extra;
			//para.TrustStockExtraDiv = (int)InventInputSearchCndtn.StockExtraDivState.Extra;
			//para.EntrustCmpStockExtraDiv = (int)InventInputSearchCndtn.StockExtraDivState.Extra;
			//para.EntrustTrtStockExtraDiv = (int)InventInputSearchCndtn.StockExtraDivState.Extra;
            // 2007.09.20 削除 <<<<<<<<<<<<<<<<<<<<

            // 2007.09.20 削除 >>>>>>>>>>>>>>>>>>>>
            //para.Ed_CarrierCode = Int32.MaxValue;
			//para.Ed_CarrierEpCode = Int32.MaxValue;
            // 2007.09.20 削除 <<<<<<<<<<<<<<<<<<<<
            para.Ed_MakerCode = Int32.MaxValue;
			para.Ed_CustomerCode = Int32.MaxValue;
			para.Ed_ShipCustomerCode = Int32.MaxValue;

			para.Ed_LargeGoodsGanreCode = "";
			para.Ed_MediumGoodsGanreCode = "";
			para.St_LargeGoodsGanreCode = "";
			para.St_MediumGoodsGanreCode = "";

			para.StockCntZeroExtraDiv = 0;
			para.St_InventoryPreprDay = DateTime.MinValue;
			para.Ed_InventoryPreprDay = DateTime.MinValue;
			para.IvtStkCntZeroExtraDiv = 0;	// 全て
            // 2007.09.20 削除 >>>>>>>>>>>>>>>>>>>>
            //para.GrossPrintDiv = 0;			// 製番単位
            // 2007.09.20 削除 <<<<<<<<<<<<<<<<<<<<
            para.SelectedPaperKind = -1;	// 棚卸記入表
			para.TargetDateExtraDiv = -1;	// 棚卸準備処理日付

            // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
            para.St_WarehouseCode = warehouseCdSta;
			para.Ed_WarehouseCode = warehouseCdEnd;
			para.St_WarehouseShelfNo = shelfNoSta;
			para.Ed_WarehouseShelfNo = shelfNoEnd;
            para.St_DetailGoodsGanreCode = "";
            para.Ed_DetailGoodsGanreCode = "";

            para.Ed_EnterpriseGanreCode = Int32.MaxValue;
            para.Ed_BLGoodsCode = Int32.MaxValue;
            // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<

            // 2008.02.26 追加 >>>>>>>>>>>>>>>>>>>>
            para.CalcStockAmountDiv  = 1;                   // 在庫数算出フラグ
            para.CalcStockAmountDate = DateTime.MinValue;   // 在庫数算出日付
            // 2008.02.26 追加 <<<<<<<<<<<<<<<<<<<<

			object retObj;
            int status = this._iInventInputSearchDB.Search(out retObj, (object)para, 0, ConstantManagement.LogicalMode.GetData0);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				foreach (ArrayList retArray in (ArrayList)retObj)
				{
					// 戻りリストの要素の型がInventoryDataUpdateWorkならばデータ展開
					if ((retArray.Count > 0) && (retArray[0] is InventoryDataUpdateWork))
					{
						foreach (InventoryDataUpdateWork data in retArray)
						{
							this.Cache(data);
						}
					}
				}

				this.Filtering(difCntExtraDiv);
                // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
                //this._dataSet.Inventory.DefaultView.Sort = this._dataSet.Inventory.WarehouseCodeColumn.ColumnName + " , " + this._dataSet.Inventory.GoodsCodeColumn.ColumnName + " , " + this._dataSet.Inventory.ProductNumberColumn.ColumnName;
                this._dataSet.Inventory.DefaultView.Sort = this._dataSet.Inventory.WarehouseCodeColumn.ColumnName + " , " + this._dataSet.Inventory.GoodsNoColumn.ColumnName + " , " + this._dataSet.Inventory.InventorySeqNoColumn.ColumnName;
                // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<
            }
			return status;
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 Partsman用に変更

        // --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 拠点マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/10</br>
        /// </remarks>
        private void LoadSecInfoSet()
        {
            try
            {
                this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

                foreach (SecInfoSet secInfoSet in _secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.LogicalDeleteCode == 0)
                    {
                        this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                    }
                }
            }
            catch
            {
                this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
            }
        }

        /// <summary>
        /// 倉庫マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 倉庫マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/10</br>
        /// </remarks>
        private void LoadWarehouse()
        {
            try
            {
                this._warehouseDic = new Dictionary<string, Warehouse>();

                ArrayList retList;

                int status = this._warehouseAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (Warehouse warehouse in retList)
                    {
                        if (warehouse.LogicalDeleteCode == 0)
                        {
                            this._warehouseDic.Add(warehouse.WarehouseCode.Trim(), warehouse);
                        }
                    }
                }
            }
            catch
            {
                this._warehouseDic = new Dictionary<string, Warehouse>();
            }
        }

        /// <summary>
        /// メーカーマスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : メーカーマスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/10</br>
        /// </remarks>
        private void LoadMakerUMnt()
        {
            try
            {
                this._makerUMntDic = new Dictionary<int, MakerUMnt>();

                ArrayList retList;

                int status = this._makerAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retList)
                    {
                        if (makerUMnt.LogicalDeleteCode == 0)
                        {
                            this._makerUMntDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._makerUMntDic = new Dictionary<int, MakerUMnt>();
            }
        }

        /// <summary>
        /// BLコードマスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : BLコードマスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/10</br>
        /// </remarks>
        private void LoadBLGoodsCdUMnt()
        {
            try
            {
                this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();

                ArrayList retList;

                int status = this._blGoodsCdAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (BLGoodsCdUMnt blGoodsCdUMnt in retList)
                    {
                        if (blGoodsCdUMnt.LogicalDeleteCode == 0)
                        {
                            this._blGoodsCdUMntDic.Add(blGoodsCdUMnt.BLGoodsCode, blGoodsCdUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();
            }
        }

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/10</br>
        /// </remarks>
        public string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            if (this._secInfoSetDic.ContainsKey(sectionCode.PadLeft(2, '0')))
            {
                sectionName = this._secInfoSetDic[sectionCode.PadLeft(2, '0')].SectionGuideNm.Trim();
            }

            return sectionName;
        }

        /// <summary>
        /// 倉庫名称取得処理
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <returns>倉庫名称</returns>
        /// <remarks>
        /// <br>Note       : 倉庫名称を取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/10</br>
        /// </remarks>
        public string GetWarehouseName(string warehouseCode)
        {
            string warehouseName = "";

            if (this._warehouseDic.ContainsKey(warehouseCode))
            {
                warehouseName = this._warehouseDic[warehouseCode].WarehouseName.Trim();
            }

            return warehouseName;
        }

        /// <summary>
        /// メーカー名称取得処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>メーカー名称</returns>
        /// <remarks>
        /// <br>Note       : メーカー名称を取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/10</br>
        /// </remarks>
        private string GetMakerName(int makerCode)
        {
            string makerName = "";

            if (this._makerUMntDic.ContainsKey(makerCode))
            {
                makerName = this._makerUMntDic[makerCode].MakerName.Trim();
            }

            return makerName;
        }

        /// <summary>
        /// BLコード名称取得処理
        /// </summary>
        /// <param name="blGoodsCode">BLコード</param>
        /// <returns>BKコード名称</returns>
        /// <remarks>
        /// <br>Note       : BLコード名称を取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/10</br>
        /// </remarks>
        private string GetBLGoodsName(int blGoodsCode)
        {
            string blGoodsName = "";

            if (this._blGoodsCdUMntDic.ContainsKey(blGoodsCode))
            {
                blGoodsName = this._blGoodsCdUMntDic[blGoodsCode].BLGoodsFullName.Trim();
            }

            return blGoodsName;
        }

        /// <summary>
        /// 品名取得処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="goodsNo">品番</param>
        /// <returns>品名</returns>
        /// <remarks>
        /// <br>Note       : 品名を取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/10</br>
        /// <br>Update Note: 2012/07/19 yangyi</br>
        /// <br>             redmine#31106 「棚卸過不足更新」の負荷軽減と処理時間短縮の調査</br>
        /// </remarks>
        private string GetGoodsName(int makerCode, string goodsNo)
        {
            // ----- ADD 2012/07/19 ---------->>>>>
            string goodsName = "";
            string key = LoginInfoAcquisition.EnterpriseCode + "_" + makerCode.ToString() + "_" + goodsNo;
            if (this._goodsUnitDataDic.ContainsKey(key))
            {
                goodsName = this._goodsUnitDataDic[key].GoodsName.Trim();
            }
            else
            {
            // ----- ADD 2012/07/19 ----------<<<<<
                try
                {
                    GoodsUnitData goodsUnitData;

                    int status = this._goodsAcs.Read(LoginInfoAcquisition.EnterpriseCode, makerCode, goodsNo, out goodsUnitData);
                    if (status == 0)
                    {
                        goodsName = goodsUnitData.GoodsName.Trim();
                        _goodsUnitDataDic.Add(key, goodsUnitData); // ADD 2012/07/19
                    }
                }
                catch
                {
                    goodsName = "";
                }
            }   // ADD 2012/07/19

            return goodsName;
        }

        private double GetListPriceFl(int makerCode, string goodsNo, DateTime targetDate)
        {
            double listPriceFl = 0;
            // ----- ADD 2012/07/19 ---------->>>>>
            string key = LoginInfoAcquisition.EnterpriseCode + "_" + makerCode.ToString() + "_" + goodsNo;
            if (this._goodsUnitDataDic.ContainsKey(key))
            {
                GoodsUnitData goodsUnitData = null;
                goodsUnitData = this._goodsUnitDataDic[key];
                GoodsPrice goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(targetDate, goodsUnitData.GoodsPriceList);
                listPriceFl = goodsPrice.ListPrice;
            }
            else
            {
            // ----- ADD 2012/07/19 ----------<<<<<
                try
                {
                    GoodsUnitData goodsUnitData;

                    int status = this._goodsAcs.Read(LoginInfoAcquisition.EnterpriseCode, makerCode, goodsNo, out goodsUnitData);
                    if (status == 0)
                    {
                        GoodsPrice goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(targetDate, goodsUnitData.GoodsPriceList);
                        listPriceFl = goodsPrice.ListPrice;
                        _goodsUnitDataDic.Add(key, goodsUnitData); // ADD 2012/07/19
                    }
                }
                catch
                {
                    listPriceFl = 0;
                }
            }       // ADD 2012/07/19

            return listPriceFl;
        }

        // --- ADD yangyi 2013/10/09 for Redmine#31106 ------->>>>>>>>>>>
        private double GetListPriceFl2(int makerCode, string goodsNo, DateTime targetDate)
        {
            double listPriceFl = 0;

            string keyStr = goodsNo + "," + makerCode.ToString();

            List<GoodsPrice> goodsPriceList = new List<GoodsPrice>();

            if (this._dicPriceList.ContainsKey(keyStr))
            {
                foreach (GoodsPriceUWork work in _dicPriceList[keyStr])
                {
                    GoodsPrice goodsPrice = new GoodsPrice();
                    goodsPrice.ListPrice = work.ListPrice;
                    goodsPrice.PriceStartDate = work.PriceStartDate;
                    goodsPriceList.Add(goodsPrice);
                }
                GoodsPrice retGoodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(targetDate, goodsPriceList);
                if (retGoodsPrice !=null)
                {
                    listPriceFl = retGoodsPrice.ListPrice;
                }
            }
            else
            {
                listPriceFl = 0;
            }

            return listPriceFl;
        }
        // --- ADD yangyi 2013/10/09 for Redmine#31106 -------<<<<<<<<<<<

        /// <summary>
        /// 棚卸データ検索処理
        /// </summary>
        /// <param name="inventInputSearchCndtn">棚卸データ検索条件クラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 棚卸データを検索し、検索結果をデータテーブルにキャッシュします。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/10</br>
        /// <br>UpdateNote : 2009/12/03 李占川 PM.NS　保守対応</br>
        /// <br>UpdateNote : 2010/02/23 楊明俊 データ抽出時に、商品マスタの存在チェックを行い処理対象外とするように変更する</br>
        /// <br>Update Note: 2013/10/09 yangyi</br>
        /// <br>管理番号   : 10904597-00 PM1301E(速度調査）</br>
        /// <br>           : Redmine#31106 「棚卸過不足更新」の負荷軽減と処理時間短縮の調査
        /// </remarks>
        public int Search(InventInputSearchCndtn inventInputSearchCndtn)
        {
            this._dataSet.Inventory.DefaultView.RowFilter = "";
            this._dataSet.Inventory.Rows.Clear();

            this._dataSet.ErrorData.Rows.Clear();
            this._dataSet.ErrorData.DefaultView.RowFilter = "";

            this._dataSet.InventoryNumberInfo.Rows.Clear();

            this._inventoryDataDictionary.Clear();

            // クラスメンバコピー処理
            InventInputSearchCndtnWork para = CopyToInventInputSearchCndtnWorkFromInventInputSearchCndtn(inventInputSearchCndtn);

            object retObj;
            //int status = this._iInventInputSearchDB.Search(out retObj, (object)para, 0, ConstantManagement.LogicalMode.GetData0); //DEL yangyi 2013/10/09 Redmine#31106

            // --- ADD yangyi 2013/10/09 for Redmine#31106 ------->>>>>>>>>>>
            object retObjDic;
            int status = this._iInventInputSearchDB.SearchInvent(out retObj, (object)para, 0, ConstantManagement.LogicalMode.GetData0, out retObjDic);

            this._dicPriceList = new Dictionary<string,List<GoodsPriceUWork>>();
            if (retObjDic != null)
            {
                this._dicPriceList = retObjDic as Dictionary<string, List<GoodsPriceUWork>>;
            }
            // --- ADD yangyi 2013/10/09 for Redmine#31106 -------<<<<<<<<<<<

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (ArrayList retArray in (ArrayList)retObj)
                {
                    // 戻りリストの要素の型がInventoryDataUpdateWorkならばデータ展開
                    if ((retArray.Count > 0) && (retArray[0] is InventoryDataUpdateWork))
                    {
                        foreach (InventoryDataUpdateWork data in retArray)
                        {
                            //Cache(data); // DEL 2009/12/03

                            // --- ADD 2009/12/03 ---------->>>>>
                            // --- UPD 2010/02/23 ----------<<<<<
                            // 過不足更新区分=0:未更新場合
                            // 商品マスタが未登録又は、論理削除の場合
                            //if (data.ToleranceUpdateCd == 0)
                            //if (data.ToleranceUpdateCd == 0 && data.GoodsDiv == 0) // DEL 2011/01/11
                            // --- UPD 2010/02/23 ----------<<<<<
                            if (data.ToleranceUpdateCd == 0 && data.GoodsDiv == 0 && !"ｶｼﾀﾞｼ".Equals(data.WarehouseShelfNo) && !"ｻｷﾀﾞｼ".Equals(data.WarehouseShelfNo)) // ADD 2011/01/11
                            {
                                // データテーブルキャッシュ
                                Cache(data);
                            }
                            // --- ADD 2009/12/03 ----------<<<<<
                        }
                    }
                }

                // フィルタリング
                Filtering(inventInputSearchCndtn.DifCntExtraDiv);
                this._dataSet.Inventory.DefaultView.Sort = this._dataSet.Inventory.WarehouseCodeColumn.ColumnName + " , " + 
                                                           this._dataSet.Inventory.GoodsNoColumn.ColumnName + " , " + 
                                                           this._dataSet.Inventory.InventorySeqNoColumn.ColumnName;
            }
            return status;
        }
        // --- ADD 陳嘯 K2015/08/21 Redmine#46790 棚卸過不足更新　メモリアウトの修正 ----->>>>>
        /// <summary>
        /// 棚卸データ検索と過不足更新処理
        /// </summary>
        /// <param name="inventInputSearchCndtn">棚卸データ検索条件クラス</param>
        /// <param name="shelfNoDiv">棚番更新区分</param>
        /// <param name="isSaved">保存フラグ</param>
        /// <param name="message">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 棚卸データを検索し、検索結果をデータテーブルにキャッシュします。</br>
        /// <br>Programmer : 陳嘯</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        public int SearchAndUpdate(InventInputSearchCndtn inventInputSearchCndtn, int shelfNoDiv, out bool isSaved, out string message)
        {
            isSaved = false;
            message = string.Empty;
            // クラスメンバ作成処理
            InventInputUpdateCndtnWork inventInputUpdateCndtnWork = CreateInventInputUpdateCndtnWork(shelfNoDiv);
            int status = -1;
            // クラスメンバコピー処理
            InventInputSearchCndtnWork para = CopyToInventInputSearchCndtnWorkFromInventInputSearchCndtn(inventInputSearchCndtn);

            Dictionary<string, string> secDic = new Dictionary<string,string>();
            Dictionary<string, string> wareDic = new Dictionary<string, string>();
            Dictionary<int, string> makerDic = new Dictionary<int, string>();
            Dictionary<int, string> blGoodsDic = new Dictionary<int, string>();
            //拠点名称を取得
            foreach (string key in _secInfoSetDic.Keys)
            {
                secDic.Add(key, _secInfoSetDic[key].SectionGuideNm.Trim());
            }
            //倉庫名称を取得
            foreach (string key in _warehouseDic.Keys)
            {
                wareDic.Add(key, _warehouseDic[key].WarehouseName.Trim());
            }

            //メーカ名称を取得
            foreach (int key in _makerUMntDic.Keys)
            {
                makerDic.Add(key, _makerUMntDic[key].MakerName.Trim());
            }

            //BL商品名称を取得
            foreach (int key in _blGoodsCdUMntDic.Keys)
            {
                blGoodsDic.Add(key, _blGoodsCdUMntDic[key].BLGoodsFullName.Trim());
            }
            // 棚卸データ検索と過不足更新処理
            status = this._iStockAdjustDB.SearchInventAndUpdate((object)para, (object)inventInputUpdateCndtnWork, out isSaved, (object)secDic, (object)wareDic, (object)makerDic, (object)blGoodsDic, out message);           
            return status;            
        }

        /// <summary>
        /// 過不足更新条件クラスメンバ作成処理
        /// </summary>
        /// <returns>inventUpdateWork</returns>
        /// <remarks>
        /// <br>Note       : 過不足更新条件クラスメンバ作成</br>
        /// <br>Programmer : 陳嘯</br>
        /// <br>Date       : K2015/08/21</br>
        /// </remarks>
        private InventInputUpdateCndtnWork CreateInventInputUpdateCndtnWork(int shelfNoDiv)
        {
            InventInputUpdateCndtnWork inventUpdateWork = new InventInputUpdateCndtnWork();
            // 棚卸運用区分
            inventUpdateWork.InventoryMngDiv = _stockMngTtlSt.InventoryMngDiv;
            // 端数処理区分
            inventUpdateWork.FractionProcCd = _stockMngTtlSt.FractionProcCd;
            // 企業コード
            inventUpdateWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // 従業員名称
            inventUpdateWork.EmployeeName = LoginInfoAcquisition.Employee.Name;
            // 拠点コード
            inventUpdateWork.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            // 従業員コード
            inventUpdateWork.EmployeeCode = LoginInfoAcquisition.Employee.EmployeeCode;
            // 棚番更新区分
            inventUpdateWork.ShelfNoDiv = shelfNoDiv;

            return inventUpdateWork;
        }
        // --- ADD 陳嘯 K2015/08/21 Redmine#46790 棚卸過不足更新　メモリアウトの修正 -----<<<<<

        /// <summary>
        /// クラスメンバコピー処理(E→D)
        /// </summary>
        /// <param name="extrInfo">棚卸データ検索条件クラス</param>
        /// <returns>棚卸データ検索条件ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 棚卸データ検索条件クラスを棚卸データ検索条件ワーククラスにコピーします。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/10</br>
        /// </remarks>
        private InventInputSearchCndtnWork CopyToInventInputSearchCndtnWorkFromInventInputSearchCndtn(InventInputSearchCndtn extrInfo)
        {
            InventInputSearchCndtnWork inventInputSearchCndtnWork = new InventInputSearchCndtnWork();
            // 企業コード
            inventInputSearchCndtnWork.EnterpriseCode = extrInfo.EnterpriseCode;
            // 差異分抽出区分        
            inventInputSearchCndtnWork.DifCntExtraDiv = 2;
            // 拠点コード
            inventInputSearchCndtnWork.St_SectionCode = extrInfo.St_SectionCode;
            inventInputSearchCndtnWork.Ed_SectionCode = extrInfo.Ed_SectionCode;
            // 倉庫コード
            inventInputSearchCndtnWork.St_WarehouseCode = extrInfo.St_WarehouseCode;
            inventInputSearchCndtnWork.Ed_WarehouseCode = extrInfo.Ed_WarehouseCode;
            // 棚番
            inventInputSearchCndtnWork.St_WarehouseShelfNo = extrInfo.St_WarehouseShelfNo;
            inventInputSearchCndtnWork.Ed_WarehouseShelfNo = extrInfo.Ed_WarehouseShelfNo;
            // 仕入先コード
            inventInputSearchCndtnWork.St_SupplierCd = extrInfo.St_SupplierCd;
            inventInputSearchCndtnWork.Ed_SupplierCd = extrInfo.Ed_SupplierCd;
            // BLコード
            inventInputSearchCndtnWork.St_BLGoodsCode = extrInfo.St_BLGoodsCode;
            inventInputSearchCndtnWork.Ed_BLGoodsCode = extrInfo.Ed_BLGoodsCode;
            // グループコード
            inventInputSearchCndtnWork.St_BLGroupCode = extrInfo.St_BLGroupCode;
            inventInputSearchCndtnWork.Ed_BLGroupCode = extrInfo.Ed_BLGroupCode;
            // メーカーコード
            inventInputSearchCndtnWork.St_MakerCode = extrInfo.St_MakerCode;
            inventInputSearchCndtnWork.Ed_MakerCode = extrInfo.Ed_MakerCode;
            // 通番
            inventInputSearchCndtnWork.St_InventorySeqNo = extrInfo.St_InventorySeqNo;
            inventInputSearchCndtnWork.Ed_InventorySeqNo = extrInfo.Ed_InventorySeqNo;
            // 棚卸日
            inventInputSearchCndtnWork.InventoryDate = extrInfo.InventoryDate;
            // 在庫数算出フラグ
            inventInputSearchCndtnWork.CalcStockAmountDiv = 1;
            //
            // 固定項目 (リモートでは無視される) ------------------------------------------------------------
            //
            // 帳簿数ゼロ抽出区分
            inventInputSearchCndtnWork.StockCntZeroExtraDiv = 0;
            // 準備処理日付
            inventInputSearchCndtnWork.St_InventoryPreprDay = DateTime.MinValue;
            inventInputSearchCndtnWork.Ed_InventoryPreprDay = DateTime.MinValue;
            // 棚卸数抽出区分(全て)
            inventInputSearchCndtnWork.IvtStkCntZeroExtraDiv = 0;
            // 帳票種別(棚卸記入表)
            //inventInputSearchCndtnWork.SelectedPaperKind = -1;        //DEL 2009/05/22 不具合対応[13263]
            inventInputSearchCndtnWork.SelectedPaperKind = 0;           //ADD 2009/05/22 不具合対応[13263]
            // 抽出対象日付区分(棚卸準備処理日付)
            inventInputSearchCndtnWork.TargetDateExtraDiv = -1;

            return inventInputSearchCndtnWork;
        }
        // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<

		/// <summary>
		/// 棚卸データを保存します。
		/// </summary>
		/// <returns>STATUS</returns>
		public int Save(out bool isSaved, out string message, int shelfNoDiv)
		{
			isSaved = false;
			int status = -1;
			message = "";

			CustomSerializeArrayList saveData = this.CreateSaveData();
			object objSaveData = (object)saveData;

			if (saveData.Count == 0)
			{
				status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}
			else
			{
                //status = this._iStockAdjustDB.WriteInventory(ref objSaveData, out message, shelfNoDiv); // 陳嘯 DEL
                // --- ADD 陳嘯 K2015/08/21 Redmine#46790 棚卸過不足更新　メモリアウトの修正 ----->>>>>
                try
                {
                    status = this._iStockAdjustDB.WriteInventory(objSaveData, out message, shelfNoDiv);
                }
                catch (OutOfMemoryException)
                {
                    status = -100; // OutOfMemoryException
                }
                // --- ADD 陳嘯 K2015/08/21 Redmine#46790 棚卸過不足更新　メモリアウトの修正 -----<<<<<
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    isSaved = true;
                }

                // --- DEL 陳嘯 K2015/08/21 Redmine#46790 棚卸過不足更新　メモリアウトの修正 ----->>>>>
                // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
                //else if (status == (int)ConstantManagement.DB_Status.ctDB_WARNING)
                //{
                //    foreach (Object data in (CustomSerializeArrayList)objSaveData)
                //    {
                //        if ((data is ArrayList) && ((ArrayList)data).Count > 0)
                //        {
                //            // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
                //            //if (((ArrayList)data)[0] is ProductStockCommonPara)
                //            if (((ArrayList)data)[0] is InventoryUpdateDataSet.InventoryRow)
                //            // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<
                //            {
                //                ArrayList productStockCommonParaList = (ArrayList)data;
                //                this.Cache(productStockCommonParaList);
                //            }
                //        }
                //    }

                //    status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                //}
                // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<
                // --- DEL 陳嘯 K2015/08/21 Redmine#46790 棚卸過不足更新　メモリアウトの修正 -----<<<<<
            }

			return status;
        }

               #region DEL 2008/09/10 使用していないのでコメントアウト
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 過不足更新のエラーチェックを行います。
		/// </summary>
		/// <returns>STATUS</returns>
		public int ErrorCheck()
		{
			int status = -1;
			string message;

			CustomSerializeArrayList saveData = this.CreateSaveData();
			object objSaveData = (object)saveData;

			if (saveData.Count == 0)
			{
				status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}
			else
			{
                //status = this._iStockAdjustDB.CheckInventory(ref objSaveData, out message);

				if (status == (int)ConstantManagement.DB_Status.ctDB_WARNING)
				{
					foreach (Object data in (CustomSerializeArrayList)objSaveData)
					{
						if ((data is ArrayList) && ((ArrayList)data).Count > 0)
						{
                            // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
                            //if (((ArrayList)data)[0] is ProductStockCommonPara)
                            if (((ArrayList)data)[0] is InventoryUpdateDataSet.InventoryRow)
                            // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<
                            {
								ArrayList productStockCommonParaList = (ArrayList)data;
								this.Cache(productStockCommonParaList);
							}
						}
					}
				}
				else
				{
					ArrayList productStockCommonParaList = new ArrayList();
					this.Cache(productStockCommonParaList);

					if (this._dataSet.ErrorData.Rows.Count > 0)
					{
						status = (int)ConstantManagement.DB_Status.ctDB_WARNING;
					}
				}
			}

			return status;
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 使用していないのでコメントアウト

        /// <summary>
		/// 棚卸しデータテーブルの行を初期化します。
		/// </summary>
		public void Clear()
		{
			this._dataSet.Inventory.Rows.Clear();
			this._dataSet.ErrorData.Rows.Clear();
		}

		/// <summary>
		/// フィルタリング処理
		/// </summary>
		/// <param name="difCntExtraDiv">0:全て表示 1:過不足発生分のみ表示</param>
		public void Filtering(int difCntExtraDiv)
		{
			if (difCntExtraDiv == 0)
			{
				this._dataSet.Inventory.DefaultView.RowFilter = "";
			}
			else
			{
				this._dataSet.Inventory.DefaultView.RowFilter = this._dataSet.Inventory.InventoryTolerancCntColumn.ColumnName + " <> 0";
			}
		}

		/// <summary>
		/// 表示行数を取得します。
		/// </summary>
		/// <returns>表示行数</returns>
		public int GetViewRowCount()
		{
			return this._dataSet.Inventory.DefaultView.Count;
		}

		/// <summary>
		/// 行数を取得します。
		/// </summary>
		/// <returns>表示行数</returns>
		public int GetRowCount()
		{
			return this._dataSet.Inventory.Rows.Count;
        }

        #region DEL 2008/09/10 Partsman用に変更
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 棚卸データ検索結果オブジェクトをデータテーブルにキャッシュします。
		/// </summary>
		/// <param name="data">棚卸データ検索結果オブジェクト</param>
		private void Cache(InventoryDataUpdateWork data)
		{
            // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
            //this._inventoryDataDictionary.Add(data.ProductStockGuid.ToString(), data);
            this._inventoryDataDictionary.Add(data.InventorySeqNo.ToString(), data);
            // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<

			bool isNew = false;
			InventoryUpdateDataSet.InventoryRow row = this.RowFromUIData(data, out isNew);

			if (isNew)
			{
				_dataSet.Inventory.AddInventoryRow(row);
			}

            // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
            //if (data.ProductNumber.Trim() != "")
            if (data.InventorySeqNo != 0)
            // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<
            {
                // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
                //InventoryUpdateDataSet.ProductNumberInfoRow productNumberInfoRow = this._dataSet.ProductNumberInfo.FindByMakerCodeGoodsCodeProductNumber(data.GoodsMakerCd, data.GoodsNo, data.ProductNumber);
                InventoryUpdateDataSet.InventoryNumberInfoRow inventoryNumberInfoRow = this._dataSet.InventoryNumberInfo.FindByGoodsMakerCdGoodsNoInventorySeqNo(data.GoodsMakerCd, data.GoodsNo, data.InventorySeqNo);
                // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<

				if (inventoryNumberInfoRow == null)
				{
                    // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
                    //InventoryUpdateDataSet.ProductNumberInfoRow newRow = this._dataSet.ProductNumberInfo.NewProductNumberInfoRow();
                    InventoryUpdateDataSet.InventoryNumberInfoRow newRow = this._dataSet.InventoryNumberInfo.NewInventoryNumberInfoRow();
                    // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<
                    newRow.GoodsMakerCd = data.GoodsMakerCd;
					newRow.GoodsNo = data.GoodsNo;
					newRow.GoodsName = data.GoodsName;
                    // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
                    //newRow.ProductNumber = data.ProductNumber;
                    newRow.InventorySeqNo = data.InventorySeqNo;
                    // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<
                    newRow.WarehouseCode = data.WarehouseCode;
					newRow.WarehouseName = data.WarehouseName;
                    // 2007.09.20 削除 >>>>>>>>>>>>>>>>>>>>
                    //newRow.ProductStockGuid = data.ProductStockGuid.ToString();
                    newRow.WarehouseShelfNo = data.WarehouseShelfNo;
                    // 2007.09.20 削除 <<<<<<<<<<<<<<<<<<<<
                    newRow.ProcResultState = 1;
					newRow.SectionCode = data.SectionCode;
//					newRow.SectionName = data.SectionGuideNm;

					string inventoryDayString = "";
					if (data.InventoryDay != DateTime.MinValue)
					{
						inventoryDayString = data.InventoryDay.ToString("yyyy/MM/dd");
					}
					newRow.InventoryDayString = inventoryDayString;

                    // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
                    //this._dataSet.ProductNumberInfo.AddProductNumberInfoRow(newRow);
                    this._dataSet.InventoryNumberInfo.AddInventoryNumberInfoRow(newRow);
                    // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<
                }
				else
				{
					inventoryNumberInfoRow.IsOverlap = true;
				}
			}
		}

		private void Cache(ArrayList productStockCommonParaList)
		{
			this._dataSet.ErrorData.Rows.Clear();
			this._dataSet.ErrorData.DefaultView.Sort = "";

			if (productStockCommonParaList != null)
			{
                // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
                //foreach (ProductStockCommonPara para in productStockCommonParaList)
                foreach (InventoryUpdateDataSet.InventoryRow para in productStockCommonParaList)
                // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<
                {
					string warehouseCode = "";
					string warehouseName = "";
					string goodsName = "";
                    // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
					//if (this._inventoryDataDictionary.ContainsKey(para.ProductStockGuid.ToString()))
                    //{
                    //    warehouseCode = this._inventoryDataDictionary[para.ProductStockGuid.ToString()].WarehouseCode;
                    //    warehouseName = this._inventoryDataDictionary[para.ProductStockGuid.ToString()].WarehouseName;
                    //    goodsName = this._inventoryDataDictionary[para.ProductStockGuid.ToString()].GoodsName;
                    //}
                    if (this._inventoryDataDictionary.ContainsKey(para.InventorySeqNo.ToString()))
					{
                        warehouseCode = this._inventoryDataDictionary[para.InventorySeqNo.ToString()].WarehouseCode;
                        warehouseName = this._inventoryDataDictionary[para.InventorySeqNo.ToString()].WarehouseName;
                        goodsName = this._inventoryDataDictionary[para.InventorySeqNo.ToString()].GoodsName;
					}
                    // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<

					bool isNew = false;
                    // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
                    //InventoryUpdateDataSet.ErrorDataRow row = this._dataSet.ErrorData.FindByMakerCodeGoodsCodeProductNumberWarehouseCodeProcResultState(
					//	para.GoodsMakerCd, para.GoodsNo, para.ProductNumber, warehouseCode, para.ProcResultState);
                    InventoryUpdateDataSet.ErrorDataRow row = this._dataSet.ErrorData.FindByGoodsMakerCdGoodsNoInventorySeqNoWarehouseCodeProcResultState(
                        para.GoodsMakerCd, para.GoodsNo, para.InventorySeqNo, warehouseCode, para.ProcResultState);
                    // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<

					if (row == null)
					{
						row = this._dataSet.ErrorData.NewErrorDataRow();
						isNew = true;
					}

					if (isNew)
					{
						InventoryUpdateDataSet.InventoryRow inventoryRow = null;
                        // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
                        //DataRow[] rows = this._dataSet.Inventory.Select(
						//	this._dataSet.Inventory.MakerCodeColumn.ColumnName + " = " + para.GoodsMakerCd.ToString() + " and " +
						//	this._dataSet.Inventory.GoodsCodeColumn.ColumnName + " = " + "'" + para.GoodsNo + "'");
                        DataRow[] rows = this._dataSet.Inventory.Select(
                            this._dataSet.Inventory.GoodsMakerCdColumn.ColumnName + " = " + para.GoodsMakerCd.ToString() + " and " +
                            this._dataSet.Inventory.GoodsNoColumn.ColumnName + " = " + "'" + para.GoodsNo + "'");
                        // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<

						if ((rows != null) && (rows.Length > 0))
						{
							inventoryRow = (InventoryUpdateDataSet.InventoryRow)rows[0];
						}

						row.GoodsMakerCd = para.GoodsMakerCd;
						row.GoodsNo = para.GoodsNo;
                        // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
                        //row.ProductNumber = para.ProductNumber;
						//row.ProductStockGuid = para.ProductStockGuid.ToString();
                        row.InventorySeqNo = para.InventorySeqNo;
                        row.WarehouseShelfNo = para.WarehouseShelfNo;
                        // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<
						row.Error = this.CreateErrorMessage(para);
						row.ProcResultState = para.ProcResultState;
						//row.SectionCode = sectionCode;					// 印刷処理実行前に設定
						//row.SectionName = sectionName;					// 印刷処理実行前に設定
						//row.InventoryDayString = inventoryDayString;		// 印刷処理実行前に設定
						row.WarehouseCode = warehouseCode;
						row.WarehouseName = warehouseName;
						row.GoodsName = goodsName;
						this._dataSet.ErrorData.AddErrorDataRow(row);
					}
				}
			}

            // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
            //DataRow[] checkRows = this._dataSet.ProductNumberInfo.Select(this._dataSet.ProductNumberInfo.IsOverlapColumn.ColumnName + " = " + Boolean.TrueString);
            DataRow[] checkRows = this._dataSet.InventoryNumberInfo.Select(this._dataSet.InventoryNumberInfo.IsOverlapColumn.ColumnName + " = " + Boolean.TrueString);
            // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<
            if ((checkRows != null) && (checkRows.Length > 0))
			{
                // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
                //InventoryUpdateDataSet.ProductNumberInfoRow[] inventoryNumberInfoRows = (InventoryUpdateDataSet.ProductNumberInfoRow[])checkRows;
				//foreach (InventoryUpdateDataSet.ProductNumberInfoRow inventoryNumberInfoRow in inventoryNumberInfoRows)
                InventoryUpdateDataSet.InventoryNumberInfoRow[] inventoryNumberInfoRows = (InventoryUpdateDataSet.InventoryNumberInfoRow[])checkRows;
				foreach (InventoryUpdateDataSet.InventoryNumberInfoRow inventoryNumberInfoRow in inventoryNumberInfoRows)
                // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<
                {
					bool isNew = false;
                    // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
                    //InventoryUpdateDataSet.ErrorDataRow row = this._dataSet.ErrorData.FindByMakerCodeGoodsCodeProductNumberWarehouseCodeProcResultState(
					//	inventoryNumberInfoRow.MakerCode, inventoryNumberInfoRow.GoodsCode, inventoryNumberInfoRow.ProductNumber, inventoryNumberInfoRow.WarehouseCode, inventoryNumberInfoRow.ProcResultState);
                    InventoryUpdateDataSet.ErrorDataRow row = this._dataSet.ErrorData.FindByGoodsMakerCdGoodsNoInventorySeqNoWarehouseCodeProcResultState(
                        inventoryNumberInfoRow.GoodsMakerCd, inventoryNumberInfoRow.GoodsNo, inventoryNumberInfoRow.InventorySeqNo, inventoryNumberInfoRow.WarehouseCode, inventoryNumberInfoRow.ProcResultState);
                    // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<

					if (row == null)
					{
						row = this._dataSet.ErrorData.NewErrorDataRow();
						isNew = true;
					}

					if (isNew)
					{
						row.GoodsMakerCd = inventoryNumberInfoRow.GoodsMakerCd;
						row.GoodsNo = inventoryNumberInfoRow.GoodsNo;
                        // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
                        //row.ProductNumber = inventoryNumberInfoRow.ProductNumber;
						//row.ProductStockGuid = inventoryNumberInfoRow.ProductStockGuid.ToString();
						//row.Error = "製造番号が重複しています。";
						//row.ProcResultState = inventoryNumberInfoRow.ProcResultState;
                        row.InventorySeqNo = inventoryNumberInfoRow.InventorySeqNo;
                        row.WarehouseShelfNo = inventoryNumberInfoRow.WarehouseShelfNo;
                        row.Error = "棚卸通番が重複しています。";
                        row.ProcResultState = inventoryNumberInfoRow.ProcResultState;
                        // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<
                        //row.SectionCode = sectionCode;					// 印刷処理実行前に設定
						//row.SectionName = sectionName;					// 印刷処理実行前に設定
						//row.InventoryDayString = inventoryDayString;		// 印刷処理実行前に設定
						row.WarehouseCode = inventoryNumberInfoRow.WarehouseCode;
						row.WarehouseName = inventoryNumberInfoRow.WarehouseName;
						row.GoodsName = inventoryNumberInfoRow.GoodsName;
						this._dataSet.ErrorData.AddErrorDataRow(row);
					}
				}
			}

            // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
            //this._dataSet.ErrorData.DefaultView.Sort = this._dataSet.Inventory.GoodsCodeColumn.ColumnName + " , " + this._dataSet.Inventory.ProductNumberColumn.ColumnName;
            this._dataSet.ErrorData.DefaultView.Sort = this._dataSet.Inventory.GoodsNoColumn.ColumnName + " , " + this._dataSet.Inventory.InventorySeqNoColumn.ColumnName;
            // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<
        }
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 Partsman用に変更

        // --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// データテーブルキャッシュ処理
        /// </summary>
        /// <param name="inventoryDataUpdateWork">棚卸データ検索結果オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 棚卸データ検索結果オブジェクトをデータテーブルにキャッシュします。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/10</br>
        /// <br>UpdateNote : 2010/02/23 楊明俊 ＰＭ７同等以上の処理速度へ改良する。</br>
        /// </remarks>
        private void Cache(InventoryDataUpdateWork inventoryDataUpdateWork)
        {
            //this._inventoryDataDictionary.Add(inventoryDataUpdateWork.InventorySeqNo.ToString(), inventoryDataUpdateWork);
            this._inventoryDataDictionary.Add(CreatKey(inventoryDataUpdateWork), inventoryDataUpdateWork);

            InventoryUpdateDataSet.InventoryRow row = RowFromUIData(inventoryDataUpdateWork);

            _dataSet.Inventory.AddInventoryRow(row);

            if (inventoryDataUpdateWork.InventorySeqNo != 0)
            {
                InventoryUpdateDataSet.InventoryNumberInfoRow inventoryNumberInfoRow = this._dataSet.InventoryNumberInfo.FindByGoodsMakerCdGoodsNoInventorySeqNo(inventoryDataUpdateWork.GoodsMakerCd, inventoryDataUpdateWork.GoodsNo, inventoryDataUpdateWork.InventorySeqNo);

                if (inventoryNumberInfoRow == null)
                {
                    InventoryUpdateDataSet.InventoryNumberInfoRow newRow = this._dataSet.InventoryNumberInfo.NewInventoryNumberInfoRow();
                    // メーカーコード
                    newRow.GoodsMakerCd = inventoryDataUpdateWork.GoodsMakerCd;
                    // 品番
                    newRow.GoodsNo = inventoryDataUpdateWork.GoodsNo;
                    // 品名
                    // --- UPD 2010/02/23 ----------<<<<<
                    //newRow.GoodsName = GetGoodsName(inventoryDataUpdateWork.GoodsMakerCd, inventoryDataUpdateWork.GoodsNo.Trim());
                    newRow.GoodsName = inventoryDataUpdateWork.GoodsName;
                    // --- UPD 2010/02/23 ---------->>>>>
                    // 棚卸通番
                    newRow.InventorySeqNo = inventoryDataUpdateWork.InventorySeqNo;
                    // 倉庫コード
                    newRow.WarehouseCode = inventoryDataUpdateWork.WarehouseCode;
                    // 倉庫名
                    newRow.WarehouseName = GetWarehouseName(inventoryDataUpdateWork.WarehouseCode.Trim());
                    // 倉庫棚番
                    newRow.WarehouseShelfNo = inventoryDataUpdateWork.WarehouseShelfNo;
                    // 
                    newRow.ProcResultState = 1;
                    // 拠点コード
                    newRow.SectionCode = inventoryDataUpdateWork.SectionCode;

                    string inventoryDayString = "";
                    if (inventoryDataUpdateWork.InventoryDay != DateTime.MinValue)
                    {
                        inventoryDayString = inventoryDataUpdateWork.InventoryDay.ToString("yyyy/MM/dd");
                    }
                    // 棚卸実施日
                    newRow.InventoryDayString = inventoryDayString;

                    this._dataSet.InventoryNumberInfo.AddInventoryNumberInfoRow(newRow);
                }
                else
                {
                    inventoryNumberInfoRow.IsOverlap = true;
                }
            }
        }
        /// <summary>
        /// データテーブルキャッシュ処理
        /// </summary>
        /// <param name="productStockCommonParaList">棚卸データリスト</param>
        /// <remarks>
        /// <br>Note       : 棚卸データをデータテーブルにキャッシュします。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/10</br>
        /// </remarks>
        private void Cache(ArrayList productStockCommonParaList)
        {
            this._dataSet.ErrorData.Rows.Clear();
            this._dataSet.ErrorData.DefaultView.Sort = "";

            if (productStockCommonParaList != null)
            {
                foreach (InventoryUpdateDataSet.InventoryRow para in productStockCommonParaList)
                {
                    string warehouseCode = "";
                    string warehouseName = "";
                    string goodsName = "";
                    //if (this._inventoryDataDictionary.ContainsKey(para.InventorySeqNo.ToString())
                    if (this._inventoryDataDictionary.ContainsKey(CreatKey(para)))
                    {
                        //warehouseCode = this._inventoryDataDictionary[para.InventorySeqNo.ToString()].WarehouseCode;
                        warehouseCode = this._inventoryDataDictionary[CreatKey(para)].WarehouseCode;
                        warehouseName = GetWarehouseName(warehouseCode.Trim());
                        //goodsName = GetGoodsName(this._inventoryDataDictionary[para.InventorySeqNo.ToString()].GoodsMakerCd,
                        //                         this._inventoryDataDictionary[para.InventorySeqNo.ToString()].GoodsNo.Trim());
                        goodsName = GetGoodsName(this._inventoryDataDictionary[CreatKey(para)].GoodsMakerCd,
                         this._inventoryDataDictionary[CreatKey(para)].GoodsNo.Trim());
                    }

                    bool isNew = false;
                    InventoryUpdateDataSet.ErrorDataRow row = this._dataSet.ErrorData.FindByGoodsMakerCdGoodsNoInventorySeqNoWarehouseCodeProcResultState(
                        para.GoodsMakerCd, para.GoodsNo, para.InventorySeqNo, warehouseCode, para.ProcResultState);

                    if (row == null)
                    {
                        row = this._dataSet.ErrorData.NewErrorDataRow();
                        isNew = true;
                    }

                    if (isNew)
                    {
                        InventoryUpdateDataSet.InventoryRow inventoryRow = null;
                        DataRow[] rows = this._dataSet.Inventory.Select(
                            this._dataSet.Inventory.GoodsMakerCdColumn.ColumnName + " = " + para.GoodsMakerCd.ToString() + " and " +
                            this._dataSet.Inventory.GoodsNoColumn.ColumnName + " = " + "'" + para.GoodsNo + "'");

                        if ((rows != null) && (rows.Length > 0))
                        {
                            inventoryRow = (InventoryUpdateDataSet.InventoryRow)rows[0];
                        }

                        row.GoodsMakerCd = para.GoodsMakerCd;
                        row.GoodsNo = para.GoodsNo;
                        row.InventorySeqNo = para.InventorySeqNo;
                        row.WarehouseShelfNo = para.WarehouseShelfNo;
                        row.Error = this.CreateErrorMessage(para);
                        row.ProcResultState = para.ProcResultState;
                        row.WarehouseCode = warehouseCode;
                        row.WarehouseName = warehouseName;
                        row.GoodsName = goodsName;
                        this._dataSet.ErrorData.AddErrorDataRow(row);
                    }
                }
            }

            DataRow[] checkRows = this._dataSet.InventoryNumberInfo.Select(this._dataSet.InventoryNumberInfo.IsOverlapColumn.ColumnName + " = " + Boolean.TrueString);
            if ((checkRows != null) && (checkRows.Length > 0))
            {
                InventoryUpdateDataSet.InventoryNumberInfoRow[] inventoryNumberInfoRows = (InventoryUpdateDataSet.InventoryNumberInfoRow[])checkRows;
                foreach (InventoryUpdateDataSet.InventoryNumberInfoRow inventoryNumberInfoRow in inventoryNumberInfoRows)
                {
                    bool isNew = false;
                    InventoryUpdateDataSet.ErrorDataRow row = this._dataSet.ErrorData.FindByGoodsMakerCdGoodsNoInventorySeqNoWarehouseCodeProcResultState(
                        inventoryNumberInfoRow.GoodsMakerCd, inventoryNumberInfoRow.GoodsNo, inventoryNumberInfoRow.InventorySeqNo, inventoryNumberInfoRow.WarehouseCode, inventoryNumberInfoRow.ProcResultState);

                    if (row == null)
                    {
                        row = this._dataSet.ErrorData.NewErrorDataRow();
                        isNew = true;
                    }

                    if (isNew)
                    {
                        row.GoodsMakerCd = inventoryNumberInfoRow.GoodsMakerCd;
                        row.GoodsNo = inventoryNumberInfoRow.GoodsNo;
                        row.InventorySeqNo = inventoryNumberInfoRow.InventorySeqNo;
                        row.WarehouseShelfNo = inventoryNumberInfoRow.WarehouseShelfNo;
                        row.Error = "棚卸通番が重複しています。";
                        row.ProcResultState = inventoryNumberInfoRow.ProcResultState;
                        row.WarehouseCode = inventoryNumberInfoRow.WarehouseCode;
                        row.WarehouseName = inventoryNumberInfoRow.WarehouseName;
                        row.GoodsName = inventoryNumberInfoRow.GoodsName;
                        this._dataSet.ErrorData.AddErrorDataRow(row);
                    }
                }
            }

            this._dataSet.ErrorData.DefaultView.Sort = this._dataSet.Inventory.GoodsNoColumn.ColumnName + " , " + this._dataSet.Inventory.InventorySeqNoColumn.ColumnName;
        }
        // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/10 使用していないのでコメントアウト
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		public void SettingErrorDataHeaderInfo(string sectionCode, string sectionName, DateTime inventoryDaySta, DateTime inventoryDayEnd)
		{
			foreach (InventoryUpdateDataSet.ErrorDataRow row in this.DataSet.ErrorData.Rows)
			{
				row.SectionCode = sectionCode;
				row.SectionName = sectionName;

				string inventoryDayString = "";
				if (inventoryDaySta != DateTime.MinValue)
				{
					inventoryDayString = inventoryDayString + inventoryDaySta.ToString("yyyy/MM/dd");
				}

				inventoryDayString = inventoryDayString + " ～ ";
				inventoryDayString = inventoryDayString + inventoryDayEnd.ToString("yyyy/MM/dd"); ;

				row.InventoryDayString = inventoryDayString;
			}
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 使用していないのでコメントアウト

        /// <summary>
		/// エラーメッセージを生成します。
		/// </summary>
		/// <param name="para">製番在庫共通パラメータオブジェクト</param>
		/// <returns>エラーメッセージ</returns>
        // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
		//private string CreateErrorMessage(ProductStockCommonPara para)
        private string CreateErrorMessage(InventoryUpdateDataSet.InventoryRow para)
        // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<
		{
            // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
            //// 0:正常,1:製番重複,2:計上済,10:在庫区分変更済,11:在庫状態変更済,12:移動状態変更済,13:商品状態変更済,20:製番在庫データ削除済
            // 0:正常,1:棚卸通番重複,2:計上済,10:在庫区分変更済,11:在庫状態変更済,12:移動状態変更済,13:商品状態変更済
            // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<

            string message = "";

			switch (para.ProcResultState)
			{
				case 0:
				{
					break;
				}
				case 1:
				{
                    // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
                    //message = "製造番号が重複しています。";
                    message = "棚卸通番が重複しています。";
                    // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<
                    break;
				}
				case 2:
				{
					message = "計上済みです。";
					break;
				}
				case 10:
				{
					message = "在庫区分（自社／受託）が変更されています。";
					break;
				}
				case 11:
				{
					message = "在庫状態が変更されています。";
					break;
				}
				case 12:
				{
					message = "在庫の移動状態が変更されています。";
					break;
				}
				case 13:
				{
					message = "在庫の商品状態（正常／不良品）が変更されています。";
					break;
				}
				case 20:
				{
					message = "既に削除されています。";
					break;
				}
			}

			return message;
		}

        #region DEL 2008/09/10 Partsman用に変更
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 保存用データ生成処理
		/// </summary>
		/// <returns>保存用データ(CustomSerializeArrayList)</returns>
		private CustomSerializeArrayList CreateSaveData()
		{
			CustomSerializeArrayList saveDataList = new CustomSerializeArrayList();
			ArrayList stockAdjustWorkList = new ArrayList();
			ArrayList eachWarehouseStockAdjustDtlWorkList = new ArrayList();
			ArrayList stockWorkList = new ArrayList();
            // 2007.09.20 削除 >>>>>>>>>>>>>>>>>>>>
            //ArrayList productStockWorkList = new ArrayList();
            // 2007.09.20 削除 <<<<<<<<<<<<<<<<<<<<
            ArrayList inventoryDataList = new ArrayList();
			Dictionary<string, StockWork> stockDictionary = new Dictionary<string, StockWork>();

			DataRow[] rows = this._dataSet.Inventory.Select(this._dataSet.Inventory.InventoryTolerancCntColumn.ColumnName + " <> 0");

			if ((rows == null) || (rows.Length == 0))
			{
				if (this._dataSet.Inventory.Count > 0)
				{
					InventoryUpdateDataSet.InventoryRow[] inventoryRows = (InventoryUpdateDataSet.InventoryRow[])rows;

					Dictionary<DateTime, InventoryDataUpdateWork> inventoryDayDictionary = new Dictionary<DateTime, InventoryDataUpdateWork>();

					// 棚卸データオブジェクトリストを生成する（棚卸日につき１件毎）
					foreach (InventoryDataUpdateWork workData in this._inventoryDataDictionary.Values)
					{
						if (!inventoryDayDictionary.ContainsKey(workData.InventoryDay))
						{
							inventoryDayDictionary.Add(workData.InventoryDay, workData);
						}
					}

					foreach (InventoryDataUpdateWork workData in inventoryDayDictionary.Values)
					{
						workData.LastInventoryUpdate = DateTime.Today;
						inventoryDataList.Add(workData);
					}

					if (inventoryDataList.Count > 0)
					{
						saveDataList.Add(inventoryDataList);
					}
				}
			}
			else
			{
				InventoryUpdateDataSet.InventoryRow[] inventoryRows = (InventoryUpdateDataSet.InventoryRow[])rows;

				Dictionary<DateTime, InventoryDataUpdateWork> inventoryDayDictionary = new Dictionary<DateTime, InventoryDataUpdateWork>();

				// 棚卸データオブジェクトリストを生成する（棚卸日につき１件毎）
				foreach (InventoryDataUpdateWork workData in this._inventoryDataDictionary.Values)
				{
					if (!inventoryDayDictionary.ContainsKey(workData.InventoryDay))
					{
						inventoryDayDictionary.Add(workData.InventoryDay, workData);
					}
				}

				foreach (InventoryDataUpdateWork workData in inventoryDayDictionary.Values)
				{
					workData.LastInventoryUpdate = DateTime.Today;
					inventoryDataList.Add(workData);
				}

				// 在庫調整明細データワークオブジェクトを生成する。
				if (((ArrayList)inventoryRows[0].InventoryDataUpdateWork).Count > 0)
				{
					// 在庫調整データを生成する
					stockAdjustWorkList.Add(this.CreateStockAdjust((InventoryDataUpdateWork)((ArrayList)inventoryRows[0].InventoryDataUpdateWork)[0]));
				}

				foreach (InventoryUpdateDataSet.InventoryRow row in inventoryRows)
				{
					ArrayList inventoryDataUpdateWorkList = (ArrayList)row.InventoryDataUpdateWork;

					if (inventoryDataUpdateWorkList.Count > 0)
					{
						InventoryDataUpdateWork inventoryDataUpdateWork = (InventoryDataUpdateWork)inventoryDataUpdateWorkList[0];
						inventoryDataUpdateWork.InventoryTolerancCnt = row.InventoryTolerancCnt;

						// 在庫マスタオブジェクトを生成する。
						this.CreateStock(inventoryDataUpdateWork, ref stockDictionary);

						foreach (InventoryDataUpdateWork data in inventoryDataUpdateWorkList)
						{
                            // 2007.09.20 削除 >>>>>>>>>>>>>>>>>>>>
                            //// 製番在庫マスタワークオブジェクトを格納したArrayListを生成する。
							//this.CreateProductStockList(data, ref productStockWorkList);
                            // 2007.09.20 削除 <<<<<<<<<<<<<<<<<<<<

							// 在庫調整明細データを生成する。
							this.CreateStockAdjustDtl(data, ref eachWarehouseStockAdjustDtlWorkList);
						}

                        // 2007.09.20 削除 >>>>>>>>>>>>>>>>>>>>
                        //if (((InventoryDataUpdateWork)inventoryDataUpdateWorkList[0]).ProductNumber != "")
						//{
						//	InventoryDataUpdateWork data = (InventoryDataUpdateWork)inventoryDataUpdateWorkList[0];
						//}
                        //else
                        //{
                        //	// 製番が入力されていない場合（グロス）
                        //}
                        // 2007.09.20 削除 <<<<<<<<<<<<<<<<<<<<
                    }
				}

				if (inventoryDataList.Count > 0)
				{
					saveDataList.Add(inventoryDataList);
				}

				if (stockAdjustWorkList.Count > 0)
				{
					saveDataList.Add(stockAdjustWorkList);
				}

				if (eachWarehouseStockAdjustDtlWorkList.Count > 0)
				{
					saveDataList.Add(eachWarehouseStockAdjustDtlWorkList);
				}

				if (stockDictionary.Values.Count > 0)
				{
					foreach (StockWork stockWork in stockDictionary.Values)
					{
						stockWorkList.Add(stockWork);
					}

					saveDataList.Add(stockWorkList);
				}

                // 2007.09.20 削除 >>>>>>>>>>>>>>>>>>>>
                //if (productStockWorkList.Count > 0)
				//{
				//	saveDataList.Add(productStockWorkList);
				//}
                // 2007.09.20 削除 <<<<<<<<<<<<<<<<<<<<
            }

			return saveDataList;
		}

		/// <summary>
		/// 棚卸データ検索結果オブジェクトから棚卸データ検索結果行クラスを取得します。
		/// </summary>
		/// <param name="data">棚卸データ検索結果オブジェクト</param>
		/// <returns>棚卸データ検索結果行クラス</returns>
		private InventoryUpdateDataSet.InventoryRow RowFromUIData(InventoryDataUpdateWork data, out bool isNew)
		{
			InventoryUpdateDataSet.InventoryRow row = null;
			isNew = false;

            // 2007.09.20 削除 >>>>>>>>>>>>>>>>>>>>
            //bool createGrossData = false;
			//if (data.ProductNumber.Trim() != "")
			//{
			//	createGrossData = false;
			//}
			//else
			//{
			//	createGrossData = true;
			//}
            //
			//if (createGrossData)
			//{
			//	row = this._dataSet.Inventory.FindByEnterpriseCodeMakerCodeGoodsCodeProductNumberStockUnitPriceSectionCodeWarehouseCodeCarrierEpCodeCustomerCodeShipCustomerCodeStockDivStockStateInventoryNewDivProductStockGuid(
			//		data.EnterpriseCode,
			//		data.GoodsMakerCd,
			//		data.GoodsNo,
			//		"",
			//		data.StockUnitPriceFl,
			//		data.SectionCode,
			//		data.WarehouseCode,
			//		data.CarrierEpCode,
			//		data.CustomerCode,
			//		data.ShipCustomerCode,
			//		data.StockDiv,
			//		data.StockState,
			//		data.InventoryNewDiv,
			//		Guid.Empty.ToString());
            //
			//	if (row == null)
			//	{
			//		row = _dataSet.Inventory.NewInventoryRow();
			//		isNew = true;
			//	}
            //
			//	this.SetRowFromUIData(ref row, data, true);
			//}
			//else
			//{
            // 2007.09.20 削除 <<<<<<<<<<<<<<<<<<<<
                row = _dataSet.Inventory.NewInventoryRow();
				isNew = true;
				this.SetRowFromUIData(ref row, data, false);
			//}

			return row;
        }

		/// <summary>
		/// 棚卸データ検索結果ワーク→棚卸データ行クラス設定処理
		/// </summary>
		/// <param name="row">棚卸データ行クラス</param>
		/// <param name="data">棚卸データ検索結果ワークオブジェクト</param>
		private void SetRowFromUIData(ref InventoryUpdateDataSet.InventoryRow row, InventoryDataUpdateWork data, bool isGrossData)
		{
			if (row.InventoryDataUpdateWork is System.DBNull)
			{
				ArrayList list = new ArrayList();
				row.InventoryDataUpdateWork = list;
			}

			//row.RowNo             = data.RowNo;
			row.EnterpriseCode      = data.EnterpriseCode;
			row.GoodsMakerCd        = data.GoodsMakerCd;
			row.GoodsName           = data.GoodsName;
			row.GoodsNo             = data.GoodsNo;
            // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
            //row.ProductNumber     = data.ProductNumber;
            row.InventorySeqNo      = data.InventorySeqNo;
            row.WarehouseShelfNo    = data.WarehouseShelfNo;
            // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<
            row.StockUnitPrice      = data.StockUnitPriceFl;
            // 2008.02.26 修正 >>>>>>>>>>>>>>>>>>>>
            row.InventoryStockTotal = data.StockAmount;
            // 2008.02.26 修正 <<<<<<<<<<<<<<<<<<<<

            // 帳簿数／差異数
            // 2008.02.26 削除 >>>>>>>>>>>>>>>>>>>>
            //if (isGrossData)
            //{
            //    row.StockTotal = row.StockTotal + data.StockTotal;
            //    row.InventoryStockCnt = row.InventoryStockCnt + data.InventoryStockCnt;
            //    row.InventoryTolerancCnt = row.InventoryTolerancCnt + data.InventoryTolerancCnt;
            //    // 2007.09.20 削除 >>>>>>>>>>>>>>>>>>>>
            //    //row.ProductStockGuid = Guid.Empty.ToString();
            //    // 2007.09.20 削除 <<<<<<<<<<<<<<<<<<<<

            //    if (data.InventoryTolerancCnt != 0)
            //    {
            //        ArrayList inventoryDataUpdateWorkList = (ArrayList)row.InventoryDataUpdateWork;
            //        inventoryDataUpdateWorkList.Add(data);
            //    }
            //}
            //else
            //{
            // 2008.02.26 削除 <<<<<<<<<<<<<<<<<<<<
				row.StockTotal              = data.StockTotal;
				row.InventoryStockCnt       = data.InventoryStockCnt;
				row.InventoryTolerancCnt    = data.InventoryTolerancCnt;
                // 2007.09.20 削除 >>>>>>>>>>>>>>>>>>>>
                //row.ProductStockGuid      = data.ProductStockGuid.ToString();
                // 2007.09.20 削除 <<<<<<<<<<<<<<<<<<<<

				ArrayList inventoryDataUpdateWorkList = (ArrayList)row.InventoryDataUpdateWork;
				inventoryDataUpdateWorkList.Add(data);
            // 2008.02.26 削除 >>>>>>>>>>>>>>>>>>>>
			//}
            // 2008.02.26 削除 <<<<<<<<<<<<<<<<<<<<

			row.SectionCode = data.SectionCode;
			row.WarehouseCode = data.WarehouseCode;
            // 2007.09.20 削除 >>>>>>>>>>>>>>>>>>>>
            //row.CarrierEpCode = data.CarrierEpCode;
            // 2007.09.20 削除 <<<<<<<<<<<<<<<<<<<<
            row.CustomerCode = data.CustomerCode;
			row.ShipCustomerCode = data.ShipCustomerCode;
			row.StockDiv = data.StockDiv;
			if (data.StockDiv == 0)
			{
				row.StockDivName = "自社";
			}
			else
			{
				row.StockDivName = "受託";
			}

            // 2007.09.20 削除 >>>>>>>>>>>>>>>>>>>>
            //row.StockState = data.StockState;
            // 2007.09.20 削除 <<<<<<<<<<<<<<<<<<<<
            row.InventoryNewDiv = data.InventoryNewDiv;
			row.WarehouseName = data.WarehouseName;
        }
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 Partsman用に変更

        #region DEL 2009/05/22 不具合対応[13243]
        //// --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
        ///// <summary>
        ///// 保存用データ生成処理
        ///// </summary>
        ///// <returns>保存用データ(CustomSerializeArrayList)</returns>
        ///// <remarks>
        ///// <br>Note       : 保存用データを作成します。</br>
        ///// <br>Programmer : 30414 忍 幸史</br>
        ///// <br>Date       : 2008/09/10</br>
        ///// </remarks>
        //private CustomSerializeArrayList CreateSaveData()
        //{
        //    CustomSerializeArrayList saveDataList = new CustomSerializeArrayList();
        //    ArrayList stockAdjustWorkList = new ArrayList();
        //    ArrayList stockAdjustDtlWorkList = new ArrayList();
        //    ArrayList stockWorkList = new ArrayList();
        //    ArrayList inventoryDataList = new ArrayList();
        //    Dictionary<string, StockWork> stockDictionary = new Dictionary<string, StockWork>();

        //    DataRow[] rows = this._dataSet.Inventory.Select(this._dataSet.Inventory.InventoryTolerancCntColumn.ColumnName + " <> 0");

        //    if ((rows == null) || (rows.Length == 0))
        //    {
        //        if (this._dataSet.Inventory.Count > 0)
        //        {
        //            InventoryUpdateDataSet.InventoryRow[] inventoryRows = (InventoryUpdateDataSet.InventoryRow[])rows;

        //            Dictionary<DateTime, InventoryDataUpdateWork> inventoryDayDictionary = new Dictionary<DateTime, InventoryDataUpdateWork>();

        //            // 棚卸データオブジェクトリストを生成する（棚卸日につき１件毎）
        //            foreach (InventoryDataUpdateWork workData in this._inventoryDataDictionary.Values)
        //            {
        //                if (!inventoryDayDictionary.ContainsKey(workData.InventoryDay))
        //                {
        //                    inventoryDayDictionary.Add(workData.InventoryDay, workData);
        //                }
        //            }

        //            foreach (InventoryDataUpdateWork workData in inventoryDayDictionary.Values)
        //            {
        //                // 最終棚卸更新日
        //                workData.LastInventoryUpdate = DateTime.Today;
        //                // 過不足数(棚卸数－実施日帳簿数)
        //                workData.InventoryTolerancCnt = workData.InventoryStockCnt - workData.StockAmount;

        //                inventoryDataList.Add(workData);
        //            }

        //            if (inventoryDataList.Count > 0)
        //            {
        //                saveDataList.Add(inventoryDataList);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        InventoryUpdateDataSet.InventoryRow[] inventoryRows = (InventoryUpdateDataSet.InventoryRow[])rows;

        //        //Dictionary<DateTime, InventoryDataUpdateWork> inventoryDayDictionary = new Dictionary<DateTime, InventoryDataUpdateWork>();

        //        //// 棚卸データオブジェクトリストを生成する（棚卸日につき１件毎）
        //        //foreach (InventoryDataUpdateWork workData in this._inventoryDataDictionary.Values)
        //        //{
        //        //    if (!inventoryDayDictionary.ContainsKey(workData.InventoryDay))
        //        //    {
        //        //        inventoryDayDictionary.Add(workData.InventoryDay, workData);
        //        //    }
        //        //}

        //        //foreach (InventoryDataUpdateWork workData in inventoryDayDictionary.Values)
        //        foreach (InventoryDataUpdateWork workData in this._inventoryDataDictionary.Values)
        //        {
        //            // 最終棚卸更新日
        //            workData.LastInventoryUpdate = DateTime.Today;
        //            // 過不足数(棚卸数－実施日帳簿数)
        //            workData.InventoryTolerancCnt = workData.InventoryStockCnt - workData.StockAmount;

        //            inventoryDataList.Add(workData);
        //        }

        //        // 在庫調整明細データワークオブジェクトを生成する。
        //        if (((ArrayList)inventoryRows[0].InventoryDataUpdateWork).Count > 0)
        //        {
        //            // 在庫調整データを生成する
        //            stockAdjustWorkList.Add(CreateStockAdjust((InventoryDataUpdateWork)((ArrayList)inventoryRows[0].InventoryDataUpdateWork)[0]));
        //        }

        //        foreach (InventoryUpdateDataSet.InventoryRow row in inventoryRows)
        //        {
        //            ArrayList inventoryDataUpdateWorkList = (ArrayList)row.InventoryDataUpdateWork;

        //            if (inventoryDataUpdateWorkList.Count > 0)
        //            {
        //                InventoryDataUpdateWork inventoryDataUpdateWork = (InventoryDataUpdateWork)inventoryDataUpdateWorkList[0];

        //                // 過不足数(棚卸数－実施日帳簿数)
        //                inventoryDataUpdateWork.InventoryTolerancCnt = row.InventoryStockCnt - row.InventoryStockTotal;

        //                // 在庫マスタオブジェクトを生成する。
        //                CreateStock(inventoryDataUpdateWork, ref stockDictionary);

        //                foreach (InventoryDataUpdateWork data in inventoryDataUpdateWorkList)
        //                {
        //                    // 在庫調整明細データを生成する。
        //                    CreateStockAdjustDtl(data, ref stockAdjustDtlWorkList);
        //                }
        //            }
        //        }

        //        if (stockAdjustDtlWorkList.Count > 0)
        //        {
        //            long stockPriceTaxExec = 0;

        //            foreach (StockAdjustDtlWork work in stockAdjustDtlWorkList)
        //            {
        //                stockPriceTaxExec += work.StockPriceTaxExc;
        //            }

        //            foreach (StockAdjustWork work in stockAdjustWorkList)
        //            {
        //                work.StockSubttlPrice = stockPriceTaxExec;
        //            }
        //        }
                
        //        if (inventoryDataList.Count > 0)
        //        {
        //            // 棚卸データ更新クラス追加
        //            saveDataList.Add(inventoryDataList);
        //        }

        //        if (stockAdjustWorkList.Count > 0)
        //        {
        //            // 在庫調整データ追加
        //            saveDataList.Add(stockAdjustWorkList);
        //        }

        //        if (stockAdjustDtlWorkList.Count > 0)
        //        {
        //            // 在庫調整明細データ追加
        //            saveDataList.Add(stockAdjustDtlWorkList);
        //        }

        //        if (stockDictionary.Values.Count > 0)
        //        {
        //            foreach (StockWork stockWork in stockDictionary.Values)
        //            {
        //                // 在庫マスタ追加
        //                stockWorkList.Add(stockWork);
        //            }

        //            saveDataList.Add(stockWorkList);
        //        }
        //    }

        //    return saveDataList;
        //}
        #endregion

        // --- ADD 2009/05/22 不具合対応[13243] ---------------->>>>>
        #region 保存用データ生成処理
        /// <summary>
        /// 保存用データ生成処理
        /// </summary>
        /// <returns>保存用データ(CustomSerializeArrayList)</returns>
        /// <remarks>
        /// <br>Note       : 保存用データを作成します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/10</br>
        /// <br>UpdateNote : 2009/12/03 李占川 PM.NS　保守対応</br>
        /// <br>             実施日帳簿数の算出方法を変更するように変更</br>
        /// </remarks>
        private CustomSerializeArrayList CreateSaveData()
        {
            CustomSerializeArrayList saveDataList = new CustomSerializeArrayList();
            ArrayList stockAdjustWorkList = new ArrayList();
            ArrayList stockAdjustDtlWorkList = new ArrayList();
            ArrayList stockWorkList = new ArrayList();
            ArrayList inventoryDataList = new ArrayList();
            Dictionary<string, StockWork> stockDictionary = new Dictionary<string, StockWork>();

            // --- ADD yangyi 2013/10/09 for Redmine#31106 ------->>>>>>>>>>>
            Dictionary<string, List<DataRow>> dataTableDic= new Dictionary<string, List<DataRow>>();

            foreach (DataRow dr in this._dataSet.Inventory)
            {
                string strKey = dr["EnterpriseCode"].ToString() + "," +dr["SectionCode"].ToString() + ","+
                                dr["InventorySeqNo"].ToString() + "," +dr["WarehouseCode"].ToString() ;

                if (dataTableDic.ContainsKey(strKey))
                {
                    dataTableDic[strKey].Add(dr);
                }
                else
                {
                    List<DataRow> list = new List<DataRow>();
                    list.Add(dr);
                    dataTableDic.Add(strKey, list);

                }
            }
            // --- ADD yangyi 2013/10/09 for Redmine#31106 -------<<<<<<<<<<<

            // グリッドの明細が無い場合、処理を抜ける
            if (this._dataSet.Inventory.Count <= 0)
            {
                return saveDataList;
            }

            foreach (InventoryDataUpdateWork workData in this._inventoryDataDictionary.Values)
            {
                CustomSerializeArrayList csArrayList = new CustomSerializeArrayList();


                // 棚卸データ作成
                inventoryDataList.Clear();

                // --- DEL 2009/12/03 ---------->>>>>
                //workData.InventoryTolerancCnt = workData.InventoryStockCnt - workData.StockAmount;          //棚卸過不足数(棚卸数－実施日帳簿数)
                //workData.InventoryTlrncPrice
                //    = this.GetTotalPriceToLong(workData.InventoryTolerancCnt, workData.StockUnitPriceFl);   //棚卸過不足金額(棚卸過不足数×仕入単価(浮動))
                //workData.LastInventoryUpdate = DateTime.Today;                                              //棚卸最終更新日
                //workData.StockTotalExec = workData.StockAmount;                                             //在庫総数(実施日)
                //workData.ToleranceUpdateCd = 1;                                                             //過不足更新区分　1:更新
                // --- DEL 2009/12/03 ----------<<<<<

                // --- ADD 2009/12/03 ---------->>>>>
                // 棚卸運用区分＝ＰＭ．ＮＳ
                if (this._stockMngTtlSt.InventoryMngDiv == 0)
                {
                    workData.InventoryTolerancCnt = workData.InventoryStockCnt - workData.StockAmount;          //棚卸過不足数(棚卸数－実施日帳簿数)
                    workData.InventoryTlrncPrice
                        = this.GetTotalPriceToLong(workData.InventoryTolerancCnt, workData.StockUnitPriceFl);   //棚卸過不足金額(棚卸過不足数×仕入単価(浮動))
                    workData.LastInventoryUpdate = DateTime.Today;                                              //棚卸最終更新日
                    workData.StockTotalExec = workData.StockAmount;                                             //在庫総数(実施日)
                    workData.ToleranceUpdateCd = 1;                                                             //過不足更新区分　1:更新
                }
                // 棚卸運用区分＝ＰＭ７
                else
                {
                    workData.LastInventoryUpdate = DateTime.Today;                                              //棚卸最終更新日
                    workData.StockTotalExec = workData.StockTotal;                                              //在庫総数(実施日) = 在庫総数
                    workData.InventoryTolerancCnt = workData.InventoryStockCnt - workData.StockTotalExec;       //棚卸過不足数(棚卸数－在庫総数（実施日）)
                    workData.InventoryTlrncPrice
                        = this.GetTotalPriceToLong(workData.InventoryTolerancCnt, workData.StockUnitPriceFl);   //棚卸過不足金額(棚卸過不足数×仕入単価(浮動))
                    workData.ToleranceUpdateCd = 1;                                                             //過不足更新区分　1:更新
                }
                // --- ADD 2009/12/03 ----------<<<<<

                inventoryDataList.Add(workData);
                csArrayList.Add(inventoryDataList.Clone());

                // 在庫調整関連データ作成
                // 2010/01/28 >>>
                //string filter = this._dataSet.Inventory.EnterpriseCodeColumn.ColumnName + " = " + workData.EnterpriseCode + " AND " +
                //                this._dataSet.Inventory.SectionCodeColumn.ColumnName + " = " + workData.SectionCode + " AND " +
                //                this._dataSet.Inventory.InventorySeqNoColumn.ColumnName + " = " + workData.InventorySeqNo;
                // 2010/01/28 <<<
                // --- DEL yangyi 2013/10/09 for Redmine#31106 ------->>>>>>>>>>>
                //string filter = this._dataSet.Inventory.EnterpriseCodeColumn.ColumnName + " = " + workData.EnterpriseCode + " AND " +
                //this._dataSet.Inventory.SectionCodeColumn.ColumnName + " = " + workData.SectionCode + " AND " +
                //this._dataSet.Inventory.InventorySeqNoColumn.ColumnName + " = " + workData.InventorySeqNo + " AND " +
                //this._dataSet.Inventory.WarehouseCodeColumn.ColumnName + " = " + workData.WarehouseCode;
                // --- DEL yangyi 2013/10/09 for Redmine#31106 -------<<<<<<<<<<<
                // --- ADD yangyi 2013/10/09 for Redmine#31106 ------->>>>>>>>>>>
                //string strKey = workData.EnterpriseCode + "," + workData.SectionCode + "," + workData.InventorySeqNo.ToString() + "," + workData.WarehouseCode;

                //不正データの対応
                string wareHouseCodeStr = workData.WarehouseCode;
                if (wareHouseCodeStr.Trim().Length <4)
                {
                    wareHouseCodeStr = wareHouseCodeStr.Trim().PadLeft(4,'0').PadRight(6,' ');
                }
                string strKey = workData.EnterpriseCode + "," + workData.SectionCode + "," + workData.InventorySeqNo.ToString() + "," + wareHouseCodeStr;

                List<DataRow> rows = new List<DataRow>();

                if (dataTableDic.ContainsKey(strKey))
                {
                    rows = dataTableDic[strKey];
                }
                // --- ADD yangyi 2013/08/02 for Redmine#31106 -------<<<<<<<<<<<

                // DataRow[] rows = this._dataSet.Inventory.Select(filter);  //DEL yangyi 2013/10/09 Redmine#31106
                //if (rows.Length == 0) //DEL yangyi 2013/10/09 Redmine#31106
                if (rows.Count == 0)    //ADD yangyi 2013/10/09 Redmine#31106 
                {
                    saveDataList.Add(csArrayList);      //棚卸データのみ
                    continue;
                }

                InventoryUpdateDataSet.InventoryRow row = (InventoryUpdateDataSet.InventoryRow)rows[0];

                ArrayList inventoryDataUpdateWorkList = (ArrayList)row.InventoryDataUpdateWork;
                if (inventoryDataUpdateWorkList.Count > 0)
                {
                    InventoryDataUpdateWork inventoryDataUpdateWork = (InventoryDataUpdateWork)inventoryDataUpdateWorkList[0];

                    // 初期化
                    stockAdjustWorkList.Clear();            //在庫調整
                    stockAdjustDtlWorkList.Clear();         //在庫調整明細
                    stockDictionary.Clear();                //在庫1
                    stockWorkList.Clear();                  //在庫2

                    // 過不足数チェック
                    if (row.InventoryTolerancCnt != 0)
                    {
                        // 在庫調整明細データ作成
                        this.CreateStockAdjustDtl(inventoryDataUpdateWork, ref stockAdjustDtlWorkList);


                        // 在庫調整データ作成
                        StockAdjustWork stockAdjustWork = this.CreateStockAdjust(inventoryDataUpdateWork);

                        // --[在庫調整データ]仕入金額小計を求める
                        long stockPriceTaxExec = 0;
                        foreach (StockAdjustDtlWork work in stockAdjustDtlWorkList)
                        {
                            stockPriceTaxExec += work.StockPriceTaxExc;
                        }
                        stockAdjustWork.StockSubttlPrice = stockPriceTaxExec;

                        stockAdjustWorkList.Add(stockAdjustWork);


                        // 作成したデータを追加
                        csArrayList.Add(stockAdjustWorkList.Clone());       //在庫調整
                        csArrayList.Add(stockAdjustDtlWorkList.Clone());    //在庫調整明細                        
                    }

                    // 在庫データ作成
                    inventoryDataUpdateWork.InventoryTolerancCnt = row.InventoryStockCnt - row.InventoryStockTotal;     //仕入在庫数(棚卸過不足数：棚卸数－実施日帳簿数)
                    this.CreateStock(inventoryDataUpdateWork, ref stockDictionary);

                    foreach (StockWork stockWork in stockDictionary.Values)
                    {
                        stockWorkList.Add(stockWork);
                    }

                    // 作成したデータを追加
                    csArrayList.Add(stockWorkList.Clone());             //在庫
                }

                saveDataList.Add(csArrayList);
            }

            return saveDataList;
        }
        #endregion
        // --- ADD 2009/05/22 不具合対応[13243] ----------------<<<<<

        /// <summary>
        /// 棚卸データ検索結果行クラス取得処理
        /// </summary>
        /// <param name="data">棚卸データ更新ワーククラス</param>
        /// <returns>棚卸データ検索結果行クラス</returns>
        /// <remarks>
        /// <br>Note       : 棚卸データ更新クラスから棚卸データ検索結果行クラスを取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/10</br>
        /// </remarks>
        private InventoryUpdateDataSet.InventoryRow RowFromUIData(InventoryDataUpdateWork data)
        {
            InventoryUpdateDataSet.InventoryRow row = null;

            row = _dataSet.Inventory.NewInventoryRow();

            // 棚卸データ行クラス設定処理
            SetRowFromUIData(ref row, data);

            return row;
        }

        /// <summary>
        /// 棚卸データ行クラス設定処理
        /// </summary>
        /// <param name="row">棚卸データ行クラス</param>
        /// <param name="data">棚卸データ更新ワーククラス</param>
        /// <remarks>
        /// <br>Note       : 棚卸データ行クラスに棚卸データ更新ワーククラスを設定します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/10</br>
        /// <br>UpdateNote : 2010/02/23 楊明俊 ＰＭ７同等以上の処理速度へ改良する。</br>
        /// </remarks>
        private void SetRowFromUIData(ref InventoryUpdateDataSet.InventoryRow row, InventoryDataUpdateWork data)
        {
            if (row.InventoryDataUpdateWork is System.DBNull)
            {
                ArrayList list = new ArrayList();
                row.InventoryDataUpdateWork = list;
            }

            // 企業コード
            row.EnterpriseCode = data.EnterpriseCode;
            // メーカーコード
            row.GoodsMakerCd = data.GoodsMakerCd;
            // 品名
            // --- UPD 2010/02/23 ----------<<<<<
            //row.GoodsName = GetGoodsName(data.GoodsMakerCd, data.GoodsNo.Trim());
            row.GoodsName = data.GoodsName;
            // --- UPD 2010/02/23 ---------->>>>>
            // 品番
            row.GoodsNo = data.GoodsNo;
            // 棚卸通番
            row.InventorySeqNo = data.InventorySeqNo;
            // 倉庫棚番
            row.WarehouseShelfNo = data.WarehouseShelfNo;
            // 仕入単価
            row.StockUnitPrice = data.StockUnitPriceFl;
            // 実施日帳簿数
            //row.InventoryStockTotal = data.StockAmount; // DEL 2009/12/03
            // --- ADD 2009/12/03 ---------->>>>>
            // 棚卸運用区分＝ＰＭ．ＮＳ
            if (this._stockMngTtlSt.InventoryMngDiv == 0)
            {
                row.InventoryStockTotal = data.StockAmount;
                // 過不足数
                row.InventoryTolerancCnt = data.InventoryStockCnt - data.StockAmount;
            }
            else
            {
                row.InventoryStockTotal = data.StockTotal;
                // 過不足数
                row.InventoryTolerancCnt = data.InventoryStockCnt - data.StockTotal;
            }
            // --- ADD 2009/12/03 ----------<<<<<
            // 帳簿数
            row.StockTotal = data.StockTotal;
            // 棚卸数
            row.InventoryStockCnt = data.InventoryStockCnt;
            // 過不足数
            //row.InventoryTolerancCnt = data.InventoryStockCnt - data.StockTotal;
            //row.InventoryTolerancCnt = data.InventoryStockCnt - data.StockAmount; // DEL 2009/12/03

            ArrayList inventoryDataUpdateWorkList = (ArrayList)row.InventoryDataUpdateWork;
            inventoryDataUpdateWorkList.Add(data);

            // 拠点コード
            row.SectionCode = data.SectionCode;
            // 倉庫コード
            row.WarehouseCode = data.WarehouseCode;
            // 仕入先コード
            row.CustomerCode = data.SupplierCd;
            // 委託先コード
            row.ShipCustomerCode = data.ShipCustomerCode;
            // 在庫区分
            row.StockDiv = data.StockDiv;
            if (data.StockDiv == 0)
            {
                row.StockDivName = "自社";
            }
            else
            {
                row.StockDivName = "受託";
            }
            // 棚卸新規追加区分
            row.InventoryNewDiv = data.InventoryNewDiv;
            // 倉庫名
            row.WarehouseName = GetWarehouseName(data.WarehouseCode.Trim());
        }
        // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<

        #region DEL 2007.09.20 削除
        // 2007.09.20 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
		///// 製番在庫マスタワークオブジェクトを格納したArrayListを生成します。
		///// </summary>
		///// <param name="data"></param>
		///// <param name="retList">製番在庫マスタワークオブジェクトを格納したArrayList</param>
		//private void CreateProductStockList(InventoryDataUpdateWork data, ref ArrayList retList)
		//{
		//	ProductStockWork workData = new ProductStockWork();
        //    //workData.CreateDateTime = 
		//	//workData.UpdateDateTime = 
		//	workData.EnterpriseCode = data.EnterpriseCode;
		//	//workData.FileHeaderGuid = 
		//	//workData.UpdEmployeeCode = 
		//	//workData.UpdAssemblyId1 = 
		//	//workData.UpdAssemblyId2 = 
		//	workData.LogicalDeleteCode = 0;
		//	workData.SectionCode = data.SectionCode;
		//	workData.MakerCode = data.GoodsMakerCd;
		//	workData.GoodsCode = data.GoodsNo;
		//	workData.GoodsName = data.GoodsName;
        //    // 2007.09.20 削除 >>>>>>>>>>>>>>>>>>>>
        //    //workData.ProductNumber = data.ProductNumber;
        //    //workData.ProductStockGuid = data.ProductStockGuid;
        //    //workData.StockState = data.StockState;
        //    // 2007.09.20 削除 <<<<<<<<<<<<<<<<<<<<
        //    workData.StockDiv = data.StockDiv;
		//	workData.WarehouseCode = data.WarehouseCode;
		//	workData.WarehouseName = data.WarehouseName;
        //    // 2007.09.20 削除 >>>>>>>>>>>>>>>>>>>>
        //    //workData.CarrierEpCode = data.CarrierEpCode;
		//	//workData.CarrierEpName = data.CarrierEpName;
        //    // 2007.09.20 削除 <<<<<<<<<<<<<<<<<<<<
        //    workData.CustomerCode = data.CustomerCode;
		//	workData.CustomerName = data.CustomerName;
		//	workData.CustomerName2 = data.CustomerName2;
        //    // 2007.09.20 削除 >>>>>>>>>>>>>>>>>>>>
        //    //workData.StockDate = data.StockDate;
		//	//workData.ArrivalGoodsDay = data.ArrivalGoodsDay;
        //    // 2007.09.20 削除 <<<<<<<<<<<<<<<<<<<<
        //    workData.StockUnitPrice = data.StockUnitPriceFl;
        //    workData.TaxationCode = 0;
        //    // 2007.09.20 削除 >>>>>>>>>>>>>>>>>>>>
        //    //workData.MoveStatus = data.MoveStatus;
        //    //workData.GoodsCodeStatus = data.GoodsCodeStatus;
        //    //workData.StockTelNo1 = data.StockTelNo1;
        //    //workData.StockTelNo2 = data.StockTelNo2;
		//	//if (String.IsNullOrEmpty(data.StockTelNo1))
		//	//{
		//	//	workData.RomDiv = 1;
		//	//}
        //    //else
        //    //{
        //    //	workData.RomDiv = 2;
        //    //}
        //    //workData.CellphoneModelCode = data.CellphoneModelCode;
        //    //workData.CellphoneModelName = data.CellphoneModelName;
        //    //workData.CarrierCode = data.CarrierCode;
        //    //workData.CarrierName = data.CarrierName;
        //    // 2007.09.20 削除 <<<<<<<<<<<<<<<<<<<<
        //    workData.MakerName = data.MakerName;
        //    // 2007.09.20 削除 >>>>>>>>>>>>>>>>>>>>
        //    //workData.SystematicColorCd = data.SystematicColorCd;
        //    //workData.SystematicColorNm = data.SystematicColorNm;
        //    // 2007.09.20 削除 <<<<<<<<<<<<<<<<<<<<
        //    workData.LargeGoodsGanreCode = data.LargeGoodsGanreCode;
        //    workData.MediumGoodsGanreCode = data.MediumGoodsGanreCode;
        //    workData.ShipCustomerCode = data.ShipCustomerCode;
        //	workData.ShipCustomerName = data.ShipCustomerName;
        //	workData.ShipCustomerName2 = data.ShipCustomerName2;
        //
        //	retList.Add(workData);
        //}
        // 2007.09.20 削除 <<<<<<<<<<<<<<<<<<<<
        #endregion DEL 2007.09.20 削除

        #region DEL 2008/09/10 Partsman用に変更
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// 在庫マスタオブジェクトを生成します。
		/// </summary>
		/// <param name="workData"></param>
		/// <returns>在庫マスタワークオブジェクト</returns>
		private void CreateStock(InventoryDataUpdateWork data, ref Dictionary<string, StockWork> stockDictionary)
		{
			string stockKey = CreateStockKey(data);

			bool isNew = false;
			StockWork workData = null;
			if (stockDictionary.ContainsKey(stockKey))
			{
				workData = stockDictionary[stockKey];
			}
			else
			{
				workData = new StockWork();
				isNew = true;
			}

			//workData.CreateDateTime = 
			//workData.UpdateDateTime = 
			workData.EnterpriseCode = data.EnterpriseCode;
			//workData.FileHeaderGuid = 
			//workData.UpdEmployeeCode = 
			//workData.UpdAssemblyId1 = 
			//workData.UpdAssemblyId2 = 
			workData.LogicalDeleteCode = 0;
			workData.SectionCode = data.SectionCode;
			workData.GoodsMakerCd = data.GoodsMakerCd;
            workData.GoodsNo = data.GoodsNo;
			workData.GoodsName = data.GoodsName;

			if (data.StockDiv == 0)
			{
				workData.StockUnitPriceFl = data.StockUnitPriceFl;
				workData.SupplierStock = workData.SupplierStock + data.InventoryTolerancCnt;
				workData.TrustCount = 0;
			}
			else
			{
				workData.StockUnitPriceFl = 0;
				workData.SupplierStock = 0;
				workData.TrustCount = workData.TrustCount + data.InventoryTolerancCnt;
			}

            // 2007.09.20 削除 >>>>>>>>>>>>>>>>>>>>
            //workData.ReservedCount = 0;
			//workData.AllowStockCnt = 0;
            // 2007.09.20 削除 <<<<<<<<<<<<<<<<<<<<
            workData.AcpOdrCount = 0;
			workData.SalesOrderCount = 0;
			workData.EntrustCnt = 0;
            // 2007.09.20 削除 >>>>>>>>>>>>>>>>>>>>
            //workData.TrustEntrustCnt = 0;
            // 2007.09.20 削除 <<<<<<<<<<<<<<<<<<<<
            workData.SoldCnt = 0;
			workData.MovingSupliStock = 0;
			workData.MovingTrustStock = 0;
			workData.ShipmentPosCnt = workData.SupplierStock + workData.TrustCount;

			if (data.InventoryTolerancCnt < 0)
			{
                // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
                //workData.StockTotalPrice = workData.StockTotalPrice - data.StockUnitPrice;
                Int64 longint;
                Int64.TryParse(data.StockUnitPriceFl.ToString(), out longint);
                workData.StockTotalPrice = workData.StockTotalPrice - longint;
                // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<
            }
			else if (data.InventoryTolerancCnt > 0)
			{
                // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
                //workData.StockTotalPrice = workData.StockTotalPrice + data.StockUnitPrice;
                Int64 longint;
                Int64.TryParse(data.StockUnitPriceFl.ToString(), out longint);
                workData.StockTotalPrice = workData.StockTotalPrice + longint;
                // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<
            }

            // 2007.09.20 削除 >>>>>>>>>>>>>>>>>>>>
            //workData.PrdNumMngDiv = data.PrdNumMngDiv;
            // 2007.09.20 削除 <<<<<<<<<<<<<<<<<<<<
            if (data.InventoryNewDiv == 1)
			{
                // 2007.09.20 修正 >>>>>>>>>>>>>>>>>>>>
                //if (workData.LastStockDate < data.StockDate)
				//{
				//	workData.LastStockDate = data.StockDate;
				//}
                if (workData.LastStockDate < data.LastStockDate)
                {
                    workData.LastStockDate = data.LastStockDate;
                }
                // 2007.09.20 修正 <<<<<<<<<<<<<<<<<<<<

			}
			else
			{
				if (workData.LastStockDate < data.LastStockDate)
				{
					workData.LastStockDate = data.LastStockDate;
				}
			}
			//workData.LastSalesDate = ;
			workData.LastInventoryUpdate = DateTime.Today;
            // 2007.09.20 削除 >>>>>>>>>>>>>>>>>>>>
            //workData.CellphoneModelCode = data.CellphoneModelCode;
			//workData.CellphoneModelName = data.CellphoneModelName;
			//workData.CarrierCode = data.CarrierCode;
			//workData.CarrierName = data.CarrierName;
            // 2007.09.20 削除 <<<<<<<<<<<<<<<<<<<<
            workData.MakerName = data.MakerName;
			//workData.SystematicColorCd = data.SystematicColorCd;
            // 2007.09.20 削除 >>>>>>>>>>>>>>>>>>>>
            //workData.SystematicColorNm = data.SystematicColorNm;
            // 2007.09.20 削除 <<<<<<<<<<<<<<<<<<<<
//            workData.LargeGoodsGanreCode = data.LargeGoodsGanreCode;
//			workData.MediumGoodsGanreCode = data.MediumGoodsGanreCode;
            workData.LargeGoodsGanreCode = data.LargeGoodsGanreCode.TrimEnd();
            workData.MediumGoodsGanreCode = data.MediumGoodsGanreCode.TrimEnd();
            workData.MinimumStockCnt = 0;
			workData.MaximumStockCnt = 0;
			workData.NmlSalOdrCount = 0;
            // 2007.09.20 削除 >>>>>>>>>>>>>>>>>>>>
            //workData.SalOdrLot = 0;
            // 2007.09.20 削除 <<<<<<<<<<<<<<<<<<<<

            // 2007.09.20 追加 >>>>>>>>>>>>>>>>>>>>
            workData.SalesOrderUnit = 0;
//            workData.WarehouseCode = data.WarehouseCode;
            workData.WarehouseCode = data.WarehouseCode.TrimEnd();
            workData.WarehouseName = data.WarehouseName;
            workData.GoodsNoNoneHyphen = "";
            workData.StockAssessmentRate = 0;
            workData.WarehouseShelfNo = data.WarehouseShelfNo;
            workData.DuplicationShelfNo1 = data.DuplicationShelfNo1;
            workData.DuplicationShelfNo2 = data.DuplicationShelfNo2;
            workData.PartsManagementDivide1 = "";
            workData.PartsManagementDivide2 = "";
            workData.StockNote1 = "";
            workData.StockNote2 = "";
            workData.ShipmentCnt = 0;
            workData.ArrivalCnt = 0;
            workData.StockCreateDate = DateTime.Today;
            workData.LargeGoodsGanreName = data.LargeGoodsGanreName;
            workData.MediumGoodsGanreName = data.MediumGoodsGanreName;
//            workData.DetailGoodsGanreCode = data.DetailGoodsGanreCode;
            workData.DetailGoodsGanreCode = data.DetailGoodsGanreCode.TrimEnd();
            workData.DetailGoodsGanreName = data.DetailGoodsGanreName;
            workData.BLGoodsCode = data.BLGoodsCode;
            workData.BLGoodsFullName = data.BLGoodsName;
            workData.GoodsShortName = "";
            workData.GoodsNameKana = "";
            workData.EnterpriseGanreCode = data.EnterpriseGanreCode;
            workData.EnterpriseGanreName = data.EnterpriseGanreName;
            workData.Jan = data.Jan;
            // 2007.09.20 追加 <<<<<<<<<<<<<<<<<<<<
            
            if (isNew)
			{
				stockDictionary.Add(stockKey, workData);
			}
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 Partsman用に変更

        // --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 在庫マスタクラス生成処理
        /// </summary>
        /// <param name="data">棚卸更新データワーククラス</param>
        /// <param name="stockDictionary">在庫マスタDictionary</param>
        /// <remarks>
        /// <br>Note       : 在庫マスタクラスを生成します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/10</br>
        /// </remarks>
        private void CreateStock(InventoryDataUpdateWork data, ref Dictionary<string, StockWork> stockDictionary)
        {
            string stockKey = CreateStockKey(data);

            bool isNew = false;
            StockWork workData = null;
            if (stockDictionary.ContainsKey(stockKey))
            {
                workData = stockDictionary[stockKey];
            }
            else
            {
                workData = new StockWork();
                isNew = true;
            }

            // 企業コード
            workData.EnterpriseCode = data.EnterpriseCode;
            // 論理削除区分
            workData.LogicalDeleteCode = 0;
            // 拠点コード
            workData.SectionCode = data.SectionCode;
            // メーカーコード
            workData.GoodsMakerCd = data.GoodsMakerCd;
            // 品番
            workData.GoodsNo = data.GoodsNo;

            //if (data.StockDiv == 0)
            //{
            //    // 仕入単価
            //    workData.StockUnitPriceFl = data.StockUnitPriceFl;
            //    // 仕入在庫数
            //    workData.SupplierStock = workData.SupplierStock + data.InventoryTolerancCnt;
            //}
            //else
            //{
            //    // 仕入単価
            //    workData.StockUnitPriceFl = 0;
            //    // 仕入在庫数
            //    workData.SupplierStock = 0;
            //}
            // 仕入単価
            workData.StockUnitPriceFl = data.StockUnitPriceFl;
            // 仕入在庫数
            workData.SupplierStock = data.InventoryTolerancCnt;
            // 出荷可能数
            workData.ShipmentPosCnt = workData.SupplierStock;

            if (data.InventoryTolerancCnt < 0)
            {
                Int64 longint;
                Int64.TryParse(data.StockUnitPriceFl.ToString(), out longint);
                // 出庫保有総額
                workData.StockTotalPrice = workData.StockTotalPrice - longint;
            }
            else if (data.InventoryTolerancCnt > 0)
            {
                Int64 longint;
                Int64.TryParse(data.StockUnitPriceFl.ToString(), out longint);
                // 出庫保有総額
                workData.StockTotalPrice = workData.StockTotalPrice + longint;
            }
            if (data.InventoryNewDiv == 1)
            {
                if (workData.LastStockDate < data.LastStockDate)
                {
                    // 最終仕入年月日
                    workData.LastStockDate = data.LastStockDate;
                }
            }
            else
            {
                if (workData.LastStockDate < data.LastStockDate)
                {
                    // 最終仕入年月日
                    workData.LastStockDate = data.LastStockDate;
                }
            }
            // 最終棚卸更新日
            workData.LastInventoryUpdate = data.InventoryDay;
            // 倉庫コード
            workData.WarehouseCode = data.WarehouseCode.TrimEnd();
            // 倉庫名
            workData.WarehouseName = GetWarehouseName(data.WarehouseCode.Trim());
            // ハイフン無商品番号
            workData.GoodsNoNoneHyphen = "";
            // 倉庫棚番
            workData.WarehouseShelfNo = data.WarehouseShelfNo;
            // 重複棚番1
            workData.DuplicationShelfNo1 = data.DuplicationShelfNo1;
            // 重複棚番2
            workData.DuplicationShelfNo2 = data.DuplicationShelfNo2;
            // 在庫登録日
            workData.StockCreateDate = DateTime.Today;
            // 更新年月日
            workData.UpdateDate = DateTime.Today;
            if (isNew)
            {
                stockDictionary.Add(stockKey, workData);
            }
        }
        // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<

		/// <summary>
		/// 在庫情報キー文字列生成処理
		/// </summary>
		/// <param name="data">棚卸更新データワーククラス</param>
		/// <returns>在庫情報キー文字列</returns>
        /// <remarks>
        /// <br>Note       : 在庫情報キー文字列を生成します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/10</br>
        /// </remarks>
		private string CreateStockKey(InventoryDataUpdateWork data)
		{
			return data.SectionCode.Trim() + data.GoodsMakerCd + "-" + data.GoodsNo.Trim();
        }

        #region DEL 2008/09/10 Partsman用に変更
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 在庫調整データワークオブジェクトを生成します。
		/// </summary>
		/// <param name="data"></param>
		/// <returns>在庫調整データワークオブジェクト</returns>
		private StockAdjustWork CreateStockAdjust(InventoryDataUpdateWork data)
		{
			StockAdjustWork workData = new StockAdjustWork();

			workData.EnterpriseCode = data.EnterpriseCode;
			workData.SectionCode = data.SectionCode;
			workData.AcPaySlipCd = 50;		// 50:棚卸
			workData.AcPayTransCd = 40;		// 40:過不足更新
			workData.AdjustDate = data.InventoryDay;
            workData.InputAgenCd = LoginInfoAcquisition.Employee.EmployeeCode;
            workData.InputAgenNm = LoginInfoAcquisition.Employee.Name;

			return workData;
        }
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 Partsman用に変更

        // --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 最終月次更新日取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>最終月次更新日</returns>
        /// <remarks>
        /// <br>Note       : 最終月次更新日を取得します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/10</br>
        /// <br>UpdateNote : 2009/12/16 李占川 ＰＭ．ＮＳ保守依頼③</br>
        /// <br>             前回月次更新日付の取得を変更する</br>
        /// <br>Update Note: 2012/07/19 yangyi</br>
        /// <br>             redmine#31106 「棚卸過不足更新」の負荷軽減と処理時間短縮の調査</br>
        /// </remarks>
        private DateTime GetPrevTotalDay(string sectionCode)
        {
            DateTime prevTotalDay = new DateTime();

            int status = 0;
            // ----- ADD 2012/07/19 ---------->>>>>
            if (this._totalDayDic.ContainsKey(sectionCode))
            {
                prevTotalDay = _totalDayDic[sectionCode];
            }
            else
            {
            // ----- ADD 2012/07/19 ----------<<<<<
                try
                {
                    status = this._totalDayCalculator.GetHisTotalDayMonthly(sectionCode, out prevTotalDay);

                    // --- ADD 2009/12/03 ---------->>>>>
                    if (prevTotalDay == DateTime.MinValue)
                    {
                        status = this._totalDayCalculator.GetHisTotalDayMonthly(string.Empty, out prevTotalDay);
                    }
                    // --- ADD 2009/12/03 ----------<<<<<

                    if (status != 0)
                    {
                        prevTotalDay = new DateTime();
                    }
                    this._totalDayDic.Add(sectionCode, prevTotalDay);  //ADD 2012/07/19 
                }
                catch
                {
                    prevTotalDay = new DateTime();
                }
            }   //ADD 2012/07/19
            return prevTotalDay;
        }

        /// <summary>
        /// 在庫調整データワーククラス生成処理
        /// </summary>
        /// <param name="data">棚卸更新データワーククラス</param>
        /// <returns>在庫調整データワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 在庫調整データワーククラスを生成します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/10</br>
        /// <br>UpdateNote : 2009/12/03 李占川 PM.NS　保守対応</br>
        /// <br>             在庫調整データ作成時の障害の修正</br>
        /// </remarks>
        private StockAdjustWork CreateStockAdjust(InventoryDataUpdateWork data)
        {
            StockAdjustWork workData = new StockAdjustWork();

            // 企業コード
            workData.EnterpriseCode = data.EnterpriseCode;
            // 拠点コード
            //workData.SectionCode = data.SectionCode;                                  //DEL 2009/04/28 不具合対応[13091]
            workData.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;     //ADD 2009/04/28 不具合対応[13091]
            // 拠点名
            //workData.SectionGuideNm = GetSectionName(data.SectionCode.Trim());        //DEL 2009/04/28 不具合対応[13091]
            workData.SectionGuideNm = GetSectionName(workData.SectionCode.Trim());      //ADD 2009/04/28 不具合対応[13091]
            // 受払元伝票区分(50：棚卸)
            workData.AcPaySlipCd = 50;
            // 受払元取引区分(40：過不足更新)
            workData.AcPayTransCd = 40;
            // 調整日付
            // 前回締処理日取得
            DateTime prevTotalDay = GetPrevTotalDay(data.SectionCode);
            if (data.InventoryDate <= prevTotalDay)
            {
                // 棚卸実施日をセット
                //workData.AdjustDate = data.InventoryDay; // DEL 2009/12/03
                workData.AdjustDate = prevTotalDay.AddDays(1); // ADD 2009/12/03
            }
            else
            {
                // 棚卸日をセット
                workData.AdjustDate = data.InventoryDate;
            }
            // 入力日付
            //workData.InputDay = data.InventoryDay; // DEL 2009/12/03
            workData.InputDay = DateTime.Now; // ADD 2009/12/03
            // 仕入拠点コード
            workData.StockSectionCd = data.SectionCode;
            // 仕入拠点名称
            workData.StockSectionGuideNm = GetSectionName(data.SectionCode.Trim());
            // 仕入入力者コード
            workData.StockInputCode = LoginInfoAcquisition.Employee.EmployeeCode;
            // 仕入入力者名称
            workData.StockInputName = LoginInfoAcquisition.Employee.Name;
            // 仕入担当者コード
            workData.StockAgentCode = LoginInfoAcquisition.Employee.EmployeeCode;
            // 仕入担当者名称
            workData.StockAgentName = LoginInfoAcquisition.Employee.Name;

            return workData;
        }
        // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/10 Partsman用に変更
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 在庫調整明細データを生成します。
        /// </summary>
        /// <param name="workData"></param>
        /// <returns>在庫調整明細データオブジェクト</returns>
        private void CreateStockAdjustDtl(InventoryDataUpdateWork data, ref ArrayList retList)
        {
            EachWarehouseStockAdjustDtlWork workData = new EachWarehouseStockAdjustDtlWork();

            // 作成日時
            workData.CreateDateTime = DateTime.MinValue;

            // 更新日時
            workData.UpdateDateTime = DateTime.MinValue;
			
            // 企業コード
            workData.EnterpriseCode = data.EnterpriseCode;

            // GUID
            workData.FileHeaderGuid = Guid.Empty;

            // 更新従業員コード
            workData.UpdEmployeeCode = "";
			
            // 更新アセンブリID1
            workData.UpdAssemblyId1 = "";
			
            // 更新アセンブリID2
            workData.UpdAssemblyId2 = "";
			
            // 論理削除区分
            workData.LogicalDeleteCode = 0;
			
            // 拠点コード
            workData.SectionCode = data.SectionCode;
			
            // 在庫調整伝票番号
            workData.StockAdjustSlipNo = 0;
			
            // 在庫調整行番号
            workData.StockAdjustRowNo = retList.Count + 1;
			
            // 受払元伝票区分
            workData.AcPaySlipCd = 50;		// 50:棚卸し
			
            // 受払元取引区分
            workData.AcPayTransCd = 40;		// 40:過不足更新

            // 調整日付
            workData.AdjustDate = data.InventoryDay;

            // メーカーコード
            workData.GoodsMakerCd = data.GoodsMakerCd;
			
            // メーカー名称
            workData.MakerName = data.MakerName;
			
            // 商品コード
            workData.GoodsNo = data.GoodsNo;
			
            // 商品名称
            workData.GoodsName = data.GoodsName;

            // 2007.09.20 削除 >>>>>>>>>>>>>>>>>>>>
            //// 製番管理区分                        
            //workData.PrdNumMngDiv = data.PrdNumMngDiv;
            //
            //// 製造番号
            //workData.ProductNumber = data.ProductNumber;
            //
            //// 変更前製造番号            
            //workData.BfProductNumber = data.ProductNumber;
            // 2007.09.20 削除 <<<<<<<<<<<<<<<<<<<<
            
            // 仕入単価
            workData.StockUnitPriceFl = data.StockUnitPriceFl;
            
            // 変更前仕入単価
            workData.BfStockUnitPriceFl = data.BfStockUnitPriceFl;

            // 2007.09.20 削除 >>>>>>>>>>>>>>>>>>>>
            //// 商品電話番号1
            //workData.StockTelNo1 = data.StockTelNo1;
            //
            //// 変更前商品電話番号1 変更なし
            //
            //// 商品電話番号2
            //workData.StockTelNo2 = data.StockTelNo2;
            //
            //// 変更前商品伝票番号2 変更なし
            // 2007.09.20 削除 <<<<<<<<<<<<<<<<<<<<

            // 仕入在庫数
            if (data.StockDiv == 0)			// 在庫区分 0:自社
            {
                workData.SupplierStock = data.InventoryStockCnt;
                workData.TrustCount = 0;
            }
            else if (data.StockDiv == 1)	// 在庫区分 1:受託
            {
                workData.SupplierStock = 0;
                workData.TrustCount = data.InventoryStockCnt;
            }

            // 2007.09.20 削除 >>>>>>>>>>>>>>>>>>>>
            //// 在庫状態
            //workData.StockState = data.StockState;
            // 2007.09.20 削除 <<<<<<<<<<<<<<<<<<<<

            // 在庫区分
            workData.StockDiv = data.StockDiv;

            // 調整数
            workData.AdjustCount = data.InventoryTolerancCnt;

            // 変更前在庫状態
            workData.BfStockState = data.StockDiv;
            
            //// 2007.09.20 削除 >>>>>>>>>>>>>>>>>>>>
            //// 商品状態
            //workData.GoodsCodeStatus = data.GoodsCodeStatus;
            //
            //// 製造番号マスタGUID
            //workData.ProductStockGuid = data.ProductStockGuid;
            //
            //// 自動引き当て区分
            //workData.AutoProductStockDrawingDiv = 0;			// 自動引き当てしない
            // 2007.09.20 削除 <<<<<<<<<<<<<<<<<<<<

            // 倉庫コード
            workData.WarehouseCode = data.WarehouseCode;
			
            // 倉庫名称
            workData.WarehouseName = data.WarehouseName;

            // 2007.09.20 追加 >>>>>>>>>>>>>>>>>>>>
            // 明細備考
            workData.DtlNote = "";

            // ＢＬ商品コード
            workData.BLGoodsCode = data.BLGoodsCode;

            // ＢＬ商品コード枝番
            workData.BLGoodsCdDerivedNo = data.BLGoodsCdDerivedNo;

            // 倉庫棚番
            workData.WarehouseShelfNo = data.WarehouseShelfNo;
            // 2007.09.20 追加 <<<<<<<<<<<<<<<<<<<<

            retList.Add(workData);
        }
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 Partsman用に変更

        // --- ADD 2008/09/10 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 在庫調整明細データワーククラス生成処理
        /// </summary>
        /// <param name="data">棚卸更新データワーククラス</param>
        /// <param name="retList">在庫調整明細データリスト</param>
        /// <returns>在庫調整明細データワーククラス</returns>
        /// <remarks>
        /// <br>Note       : 在庫調整明細データワーククラスを生成します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2008/09/10</br>
        /// <br>UpdateNote : 2009/12/03 李占川 PM.NS　保守対応</br>
        /// <br>             在庫調整明細データの仕入金額（税抜き）は「原単価×仕入数」となるように変更する　</br>
        /// <br>UpdateNote : 2010/02/23 楊明俊 ＰＭ７同等以上の処理速度へ改良する。</br>
        /// </remarks>
        private void CreateStockAdjustDtl(InventoryDataUpdateWork data, ref ArrayList retList)
        {
            StockAdjustDtlWork workData = new StockAdjustDtlWork();

            // 企業コード
            workData.EnterpriseCode = data.EnterpriseCode;
            // 拠点コード
            //workData.SectionCode = data.SectionCode;                                  //DEL 2009/04/28 不具合対応[13091]
            workData.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;     //ADD 2009/04/28 不具合対応[13091]
            // 拠点名
            //workData.SectionGuideNm = GetSectionName(data.SectionCode.Trim());        //DEL 2009/04/28 不具合対応[13091]
            workData.SectionGuideNm = GetSectionName(workData.SectionCode.Trim());      //ADD 2009/04/28 不具合対応[13091]
            // 在庫調整伝票番号
            workData.StockAdjustSlipNo = 0;
            // 在庫調整行番号
            workData.StockAdjustRowNo = retList.Count + 1;
            // 受払元伝票区分(50:棚卸)
            workData.AcPaySlipCd = 50;
            // 受払元取引区分(40:過不足更新)
            workData.AcPayTransCd = 40;
            // 調整日付
            // 前回締処理日取得
            DateTime prevTotalDay = GetPrevTotalDay(data.SectionCode);
            if (data.InventoryDate <= prevTotalDay)
            {
                // 棚卸実施日をセット
                //workData.AdjustDate = data.InventoryDay; // DEL 2009/12/03
                workData.AdjustDate = prevTotalDay.AddDays(1); // ADD 2009/12/03
            }
            else
            {
                // 棚卸日をセット
                workData.AdjustDate = data.InventoryDate;
            }
            // 入力日付
            //workData.InputDay = data.InventoryDay; // DEL 2009/12/03
            workData.InputDay = DateTime.Now; // ADD 2009/12/03
            // メーカーコード
            workData.GoodsMakerCd = data.GoodsMakerCd;
            // メーカー名称
            workData.MakerName = GetMakerName(data.GoodsMakerCd);
            // 商品コード
            workData.GoodsNo = data.GoodsNo;
            // 商品名称
            // --- UPD 2010/02/23 ----------<<<<<
            //workData.GoodsName = GetGoodsName(data.GoodsMakerCd, data.GoodsNo.Trim());
            workData.GoodsName = data.GoodsName;
            // --- UPD 2010/02/23 ---------->>>>>
            // 仕入単価
            //workData.StockUnitPriceFl = data.StockUnitPriceFl;                                        //DEL 2009/05/22 不具合対応[13263]
            workData.StockUnitPriceFl = data.AdjstCalcCost;                                             //ADD 2009/05/22 不具合対応[13263]
            // 変更前仕入単価
            //workData.BfStockUnitPriceFl = data.BfStockUnitPriceFl; // DEL 2009/12/03
            workData.BfStockUnitPriceFl = workData.StockUnitPriceFl; // ADD 2009/12/03
            // 調整数
            workData.AdjustCount = data.InventoryTolerancCnt;
            // 明細備考
            workData.DtlNote = "";
            // 倉庫コード
            workData.WarehouseCode = data.WarehouseCode;
            // 倉庫名称
            workData.WarehouseName = GetWarehouseName(data.WarehouseCode.Trim());
            // BLコード
            workData.BLGoodsCode = data.BLGoodsCode;
            // BLコード名称
            workData.BLGoodsFullName = GetBLGoodsName(data.BLGoodsCode);
            // 倉庫棚番
            workData.WarehouseShelfNo = data.WarehouseShelfNo;
            // 仕入金額
            //workData.StockPriceTaxExc = (long)(data.InventoryTolerancCnt * data.StockUnitPriceFl);    //DEL 2009/05/22 不具合対応[13263]
            //workData.StockPriceTaxExc = (long)(data.InventoryTolerancCnt * data.AdjstCalcCost);         //ADD 2009/05/22 不具合対応[13263] DEL 2009/09/14
            // -- ADD 2009/09/14 --------------------------->>>
            //在庫管理全体設定の端数処理区分を使用するように修正
            long retMoney;
            //FractionCalculate.FracCalcMoney(data.InventoryTolerancCnt * data.StockUnitPriceFl, 1.00, this._stockMngTtlSt.FractionProcCd, out retMoney); // DEL 2009/12/03
            FractionCalculate.FracCalcMoney(data.InventoryTolerancCnt * data.AdjstCalcCost, 1.00, this._stockMngTtlSt.FractionProcCd, out retMoney); // ADD 2009/12/03
            workData.StockPriceTaxExc = retMoney;
            // -- ADD 2009/09/14 ---------------------------<<<

            // 定価
            if (data.InventoryDate <= prevTotalDay)
            {
                // 棚卸実施日をセット
                //workData.ListPriceFl = GetListPriceFl(data.GoodsMakerCd, data.GoodsNo, workData.AdjustDate); //DEL yangyi 2013/10/09 Redmine#31106 
                workData.ListPriceFl = GetListPriceFl2(data.GoodsMakerCd, data.GoodsNo, workData.AdjustDate);  //ADD yangyi 2013/10/09 Redmine#31106 
            }
            else
            {
                // 棚卸日をセット
                //workData.ListPriceFl = GetListPriceFl(data.GoodsMakerCd, data.GoodsNo, workData.AdjustDate); //DEL yangyi 2013/10/09 Redmine#31106 
                workData.ListPriceFl = GetListPriceFl2(data.GoodsMakerCd, data.GoodsNo, workData.AdjustDate);  //ADD yangyi 2013/10/09 Redmine#31106 
            }

            retList.Add(workData);
        }
        // --- ADD 2008/09/10 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/10 使用していないのでコメントアウト
        /* --- DEL 2008/09/10 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 日付文字列を取得します。
		/// </summary>
		/// <param name="date">日付</param>
		/// <param name="format">フォーマット文字列</param>
		/// <returns>日付文字列</returns>
		public static string GetDateTimeString(DateTime date, string format)
		{
			if (date == DateTime.MinValue)
			{
				return "";
			}
			else
			{
				return date.ToString(format);
			}
		}
        
        /// <summary>
		/// 文字列右埋処理
		/// </summary>
		/// <param name="sjisEnc">エンコード</param>
		/// <param name="totalLength">最大レングス</param>
		/// <param name="sourceString">元文字列</param>
		/// <param name="paddingChar">追加文字</param>
		/// <returns>編集後文字列</returns>
		private string PadRight(Encoding sjisEnc, int totalLength, string sourceString, char paddingChar)
		{
			int currentLength = sjisEnc.GetByteCount(sourceString.Trim());

			StringBuilder builder = new StringBuilder(sourceString);

			for (int i = currentLength; i < totalLength; i++)
			{
				builder.Append(paddingChar);
			}

			return builder.ToString();
		}
        
        /// <summary>
		/// 在庫管理全体設定マスタをリードし、オブジェクトをにキャッシュします。
		/// </summary>
		private void ReadStockMngTtlSt()
		{
			if (_stockMngTtlSt == null)
			{
				// 仕入全体設定マスタ
				StockMngTtlSt stockMngTtlSt;
				StockMngTtlStAcs stockMngTtlStAcs = new StockMngTtlStAcs();
				int status = stockMngTtlStAcs.Read(out stockMngTtlSt, LoginInfoAcquisition.EnterpriseCode, 0);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					this.CacheStockMngTtlSt(stockMngTtlSt);
				}
			}
		}
        
        /// <summary>
		/// 在庫管理全体設定マスタオブジェクトをキャッシュします。
		/// </summary>
		/// <param name="stockMngTtlSt">在庫管理全体設定マスタクラス</param>
		private void CacheStockMngTtlSt(StockMngTtlSt stockMngTtlSt)
		{
			_stockMngTtlSt = stockMngTtlSt;
		}
        
        /// <summary>
		/// ログ出力(DEBUG)処理
		/// </summary>
		/// <param name="pMsg">メッセージ</param>
		public static void LogWrite(string pMsg)
		{
#if DEBUG
			System.IO.FileStream _fs;										// ファイルストリーム
			System.IO.StreamWriter _sw;										// ストリームwriter
			_fs = new System.IO.FileStream("MAZAI09992A.Log", System.IO.FileMode.Append, System.IO.FileAccess.Write, System.IO.FileShare.Write);
			_sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
			DateTime edt = DateTime.Now;
			//yyyy/MM/dd hh:mm:ss
			_sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2}", edt, edt.Millisecond, pMsg));
			if (_sw != null)
				_sw.Close();
			if (_fs != null)
				_fs.Close();
#endif
		}
           --- DEL 2008/09/10 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/10 使用していないのでコメントアウト

        #region 在庫管理全体設定 ADD 2009/05/22 不具合対応[13263]
        // ---ADD 2009/05/22 不具合対応[13263] ---------------------------------->>>>>
        #region ReadStockMngTtlSt(在庫全体管理設定読み込み)
        /// <summary>
        /// 在庫全体管理設定読み込み
        /// </summary>
        /// <remarks>
        /// <br>Note       : 在庫管理全体設定情報を取得します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/05/22</br>
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
        /// 金額算出(Long型で返す)
        /// </summary>
        /// <param name="unitCount">数量</param>
        /// <param name="unitCost">原価</param>
        /// <returns>合計金額</returns>
        /// <remarks>
        /// <br>Note       : 金額を算出し、在庫管理全体設定の端数処理区分に従って端数処理を行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2009/05/22</br>
        /// </remarks>
        public long GetTotalPriceToLong(double unitCount, double unitCost)
        {
            long longStockTotalPrice = 0;
            double doubleStockTotalPrice = unitCost * unitCount;       // 原単価×数量

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
        // ---ADD 2009/05/22 不具合対応[13263] ----------------------------------<<<<<

        // --- ADD 2009/12/03 ---------->>>>>
        #region keyの設定
        /// <summary>
        /// keyの設定
        /// </summary>
        /// <param name="row">row</param>
        /// <returns>key</returns>
        /// <remarks>
        /// <br>Note       : keyの設定を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/12/03</br>
        /// </remarks>
        private string CreatKey(InventoryUpdateDataSet.InventoryRow row)
        {
            StringBuilder key = new StringBuilder();

            if (row != null)
            {
                // 拠点コード
                key.Append(row.SectionCode);
                // 棚卸通番
                key.Append(row.InventorySeqNo.ToString());
                // 倉庫コード
                key.Append(row.WarehouseCode);
            }

            return key.ToString();
        }

        /// <summary>
        /// keyの設定
        /// </summary>
        /// <param name="work">work</param>
        /// <returns>key</returns>
        /// <remarks>
        /// <br>Note       : keyの設定を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/12/03</br>
        /// </remarks>
        private string CreatKey(InventoryDataUpdateWork work)
        {
            StringBuilder key = new StringBuilder();

            if (work != null)
            {
                // 拠点コード
                key.Append(work.SectionCode);
                // 棚卸通番
                key.Append(work.InventorySeqNo.ToString());
                // 倉庫コード
                key.Append(work.WarehouseCode);
            }

            return key.ToString();
        }
        #endregion keyの設定
        // --- ADD 2009/12/03 ----------<<<<<
        #endregion
    }
}

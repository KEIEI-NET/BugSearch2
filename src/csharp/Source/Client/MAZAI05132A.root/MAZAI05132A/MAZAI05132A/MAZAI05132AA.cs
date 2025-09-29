//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 棚卸入力
// プログラム概要   : 棚卸入力で使用するデータの取得・更新を行う。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : kubo
// 作 成 日  2007/04/10  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : kubo
// 修 正 日  2007/07/19  修正内容 : 抽出、一括設定、保存時の速度向上
//　　　　　　　　　　　　　　　　　テーブルのプライマリキーを変更に伴い、親データの検索はFindメソッドを用いて行うよう変更
//　　　　　　　　　　　　　　　　　プライマリキー変更に伴いキー作成メソッド追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : kubo
// 修 正 日  2007/07/20  修正内容 : 差異数のみ抽出対応
//　　　　　　　　　　　　　　　　　差異数のあるデータのみ出力する場合にうまくいっていなかったところを修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2007/09/11  修正内容 : DC.NS対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 金沢 貞義
// 修 正 日  2008/02/14  修正内容 : 棚卸実施日対応（DC.NS対応）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 忍 幸史
// 修 正 日  2008/09/01  修正内容 : Partsman用に変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/04/14  修正内容 : 不具合対応[13075]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/05/14  修正内容 : 不具合対応[13260]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 長内 数馬
// 修 正 日  2009/09/11  修正内容 : MANTIS対応[13914]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/12/03  修正内容 : PM.NS　保守対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鄧潘ハン
// 修 正 日  2011/01/11  修正内容 : 貸出分の印刷がされない不具合の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鄧潘ハン
// 修 正 日  2011/01/30  修正内容 : 障害報告 #18764
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : yangyi
// 作 成 日  2012/10/29  修正内容 : 2012/11/14配信分 #32868 No.1198 棚卸表 棚卸入力/表示順が違う
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : yangyi
// 修 正 日  2013/03/01  修正内容 : 20130326配信分の対応、Redmine#34175
//                                  棚卸業務のサーバー負荷軽減
//----------------------------------------------------------------------------//
// 管理番号  1002677-00  作成担当 : xuyb
// 修 正 日  2014/10/31  修正内容 : 仕掛№2133 Redmine#40336
//                                  障害現象② 原価を修正して新規作成すると棚卸データ．棚卸在庫額が0になる
//----------------------------------------------------------------------------//
// 管理番号  1002677-00  作成担当 : xuyb
// 修 正 日  2014/12/11  修正内容 : 仕掛№2133 Redmine#40336 #70
//                                  棚卸入力でESCキーを押下して入力内容をクリアした場合、棚卸在庫額が正しく算出されていません。
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using System.Windows.Forms;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 棚卸数入力アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 棚卸数入力 アクセスクラス</br>
	/// <br>Programmer : 22013 kubo</br>
	/// <br>Date       : 2007.04.10</br>
	/// <br>Update Note: 2007.07.19 22013 kubo</br>
	/// <br>			:	・抽出、一括設定、保存時の速度向上</br>
	/// <br>			:	　　テーブルのプライマリキーを変更に伴い、親データの検索はFindメソッドを用いて行うよう変更</br>
	/// <br>			:	　　プライマリキー変更に伴いキー作成メソッド追加</br>
	/// <br>Update Note: 2007.07.20 22013 kubo</br>
	/// <br>			:	・差異数のみ抽出対応</br>
	/// <br>			:	　　差異数のあるデータのみ出力する場合にうまくいっていなかったところを修正</br>
    /// <br>Update Note : 2007.09.11 980035 金沢 貞義</br>
    /// <br>			    ・DC.NS対応</br>
    /// <br>Update Note : 2008.02.14 980035 金沢 貞義</br>
    /// <br>			    ・棚卸実施日対応（DC.NS対応）</br>
    /// <br>Update Note : 2008/09/01 30414 忍 幸史</br>
    /// <br>			    ・Partsman用に変更</br>
    /// <br>            : 2009/04/14        照田 貴志　不具合対応[13075]</br>
    /// <br>            : 2009/05/14        照田 貴志　不具合対応[13260]</br>
    /// <br>UpdateNote  : 2009/12/03 李占川 PM.NS　保守対応</br>
    /// <br>UpdateNote : 2011/01/11 鄧潘ハン</br>
    /// <br>             貸出分の印刷がされない不具合の修正</br>
    /// <br>UpdateNote  : 2011/01/30 鄧潘ハン </br>
    /// <br>              障害報告 #18764</br>
    /// <br>UpdateNote  : 2014/10/31 xuyb</br>
    /// <br>              仕掛№2133 Redmine#40336 障害現象② 原価を修正して新規作成すると棚卸データ．棚卸在庫額が0になる</br>
    /// <br>UpdateNote  : 2014/12/11 xuyb</br>
    /// <br>              仕掛№2133 Redmine#40336 #70 棚卸入力でESCキーを押下して入力内容をクリアした場合、棚卸在庫額が正しく算出されていません。</br>
    /// </remarks>
	public class InventInputAcs
	{
		#region ■ Constructor
		/// <summary>
		/// 棚卸数入力アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 棚卸数入力 アクセスクラスコンストラクタ</br>
		/// <br>Programmer : 22013 kubo</br>
		/// <br>Date       : 2007.04.10</br>
		/// <br>Update Note: </br>
		/// </remarks>
		public InventInputAcs()
		{
            this._warehouseAcs = new WarehouseAcs();
            this._makerAcs = new MakerAcs();
            this._blGroupUAcs = new BLGroupUAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._supplierAcs = new SupplierAcs();
            this._customerInfoAcs = new CustomerInfoAcs();
            // this._goodsAcs = new GoodsAcs();             //DEL yangyi 2013/03/01 Redmine#34175
            this._goodsAcs = null;                          //ADD yangyi 2013/03/01 Redmine#34175 
            this._secInfoAcs = new SecInfoAcs();
            this._goodsGroupUAcs = new GoodsGroupUAcs();
            this._userGuideAcs = new UserGuideAcs();

            // 各種マスタ読込
            ReadWarehouse();
            ReadMakerUMnt();
            ReadBLGroupU();
            ReadBLGoodsCdU();
            ReadSupplier();
            ReadGoodsLGroup();
            ReadGoodsMGroup();
            ReadSecInfoSet();

            // ---ADD 2009/05/14 不具合対応[13260] ----------------------------------->>>>>
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
            // ---ADD 2009/05/14 不具合対応[13260] -----------------------------------<<<<<
		}
		/// <summary>
		/// 棚卸数入力アクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 棚卸数入力 アクセスクラスコンストラクタ</br>
		/// <br>Programmer : 22013 kubo</br>
		/// <br>Date       : 2007.04.10</br>
		/// <br>Update Note: </br>
		/// </remarks>
		static InventInputAcs()
		{
			InventInputResult.CreateDataTable( ref _sta_InventDataTable_Buf );
			_sta_InventDataTable = _sta_InventDataTable_Buf.Clone();
		}
		#endregion ■ Constructor

        #region ■ Private Member

        private WarehouseAcs _warehouseAcs;
        private MakerAcs _makerAcs;
        private BLGroupUAcs _blGroupUAcs;
        private BLGoodsCdAcs _blGoodsCdAcs;
        private SupplierAcs _supplierAcs;
        private CustomerInfoAcs _customerInfoAcs;
        private GoodsAcs _goodsAcs;
        private SecInfoAcs _secInfoAcs;
        private GoodsGroupUAcs _goodsGroupUAcs;
        private UserGuideAcs _userGuideAcs;

        private Dictionary<string, Warehouse> _warehouseDic;
        private Dictionary<int, MakerUMnt> _makerUMntDic;
        private Dictionary<int, BLGroupU> _blGroupUDic;
        private Dictionary<int, BLGoodsCdUMnt> _blGoodsCdUMntDic;
        private Dictionary<int, Supplier> _supplierDic;
        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<int, GoodsGroupU> _goodsGroupUDic;
        private Dictionary<int, UserGdBd> _userGdBdDic;

        // ---ADD 2009/05/14 不具合対応[13260] ------------------------------------------------->>>>>
        private TaxRateSetAcs _taxRateSetAcs = null;                    //税率設定マスタアクセス
        private UnitPriceCalculation _unitPriceCalculation = null;      //単価算出モジュール
        private StockMngTtlStAcs _stockMngTtlStAcs = null;              //在庫全体設定マスタアクセス
        private StockMngTtlSt _stockMngTtlSt = null;                    //在庫管理全体設定
        private double _taxRate = 0.0;                                  //税率
        // ---ADD 2009/05/14 不具合対応[13260] -------------------------------------------------<<<<<
        private StockMngTtlSt _stockMngTtlStLogin = null; // ADD 2009/12/03
        #endregion ■ Private Member

        #region ■ Private static Member
        // 棚卸データテーブル
		private static DataTable _sta_InventDataTable;	
	
		// 棚卸データテーブルバッファ
		// 抽出前、終了前などにデータの更新確認を行う際に使用する。
		// 抽出直後、保存直後のデータを保持する。
		private static DataTable _sta_InventDataTable_Buf;

        private static List<InventoryDataUpdateWork> _inventoryDataUpdateWorkList;

		#endregion

		#region ■ Public Property
		/// <summary> 棚卸データテーブルプロパティ </summary>
		public DataTable InventDataTable
		{
			get { return _sta_InventDataTable; }
            set { _sta_InventDataTable = value; }  // ADD 2012/10/29 yangyi redmine #32868
		}

		/// <summary> 棚卸バッファデータテーブルプロパティ </summary>
		public DataTable InventDataTable_Buf
		{
			get { return _sta_InventDataTable_Buf; }
            set { _sta_InventDataTable_Buf = value; }  //ADD yangyi 2013/03/01 Redmine#34175 
		}

        // --- ADD 2009/12/03 ---------->>>>>
        /// <summary> 表示順 </summary>
        public int SortOrde
        {
            get { return this._stockMngTtlStLogin.InvntryPrtOdrIniDiv; }
        }
        // --- ADD 2009/12/03 ----------<<<<<

		#endregion

		#region ■ Public Method
		#region ◆ 棚卸データSearch処理
		/// <summary>
		/// 棚卸データSearch処理
		/// </summary>
		/// <param name="inventInputSearchCndtn">棚卸数入力抽出条件クラス</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status(ConstantManagement.MethodResult)</returns>
        /// <remarks>
        /// <br>Note		: 棚卸データの取得を行う</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.04.10</br>
        /// </remarks>
		public int SearchInvent( InventInputSearchCndtn inventInputSearchCndtn, out string errMsg)
		{
			return SearchInventProc( inventInputSearchCndtn, out errMsg );
		}
		#endregion ◆ 棚卸データSearch処理

		#region ◆ 棚卸データWirte処理
		/// <summary>
		/// 棚卸データSearch処理
		/// </summary>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>Status(ConstantManagement.MethodResult)</returns>
        /// <remarks>
        /// <br>Note		: 棚卸データの取得を行う</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.04.10</br>
        /// </remarks>
        public int WriteInvent(int difCntExtraDiv, out string errMsg)
        {
            return WriteInventProc(difCntExtraDiv, out errMsg);
        }
		#endregion ◆ 棚卸データSearch処理

		#region ◆ 元に戻す処理
		/// <summary>
		/// 元に戻す
		/// </summary>
		public void Remove()
		{
			//_sta_InventDataTable.Rows.Clear();
			CopyTableToTable( ref _sta_InventDataTable_Buf, ref _sta_InventDataTable );
			//_sta_InventDataTable = _sta_InventDataTable_Buf.Copy();
		}
		#endregion

        #region ◆ 名称取得処理
        /// <summary>
        /// 倉庫名称取得処理
        /// </summary>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <returns>倉庫名称</returns>
        public string GetWarehouseName(string warehouseCode)
        {
            string warehouseName = "";

            if (this._warehouseDic.ContainsKey(warehouseCode.Trim()))
            {
                warehouseName = this._warehouseDic[warehouseCode.Trim()].WarehouseName.Trim();
            }

            return warehouseName;
        }

        /// <summary>
        /// メーカー名称取得処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>メーカー名称</returns>
        public string GetMakerName(int makerCode)
        {
            string makerName = "";

            if (this._makerUMntDic.ContainsKey(makerCode))
            {
                makerName = this._makerUMntDic[makerCode].MakerName.Trim();
            }

            return makerName;
        }

        /// <summary>
        /// グループコード名称取得処理
        /// </summary>
        /// <param name="blGroupCode">グループコード</param>
        /// <returns>グループコード名称</returns>
        public string GetBLGroupName(int blGroupCode)
        {
            string blGroupName = "";

            if (this._blGroupUDic.ContainsKey(blGroupCode))
            {
                blGroupName = this._blGroupUDic[blGroupCode].BLGroupName.Trim();
            }

            return blGroupName;
        }

        /// <summary>
        /// BLコード名称取得処理
        /// </summary>
        /// <param name="blGoodsCode">BLコード</param>
        /// <returns>BLコード名称</returns>
        public string GetBLGoodsName(int blGoodsCode)
        {
            string blGoodsName = "";

            if (this._blGoodsCdUMntDic.ContainsKey(blGoodsCode))
            {
                blGoodsName = this._blGoodsCdUMntDic[blGoodsCode].BLGoodsFullName.Trim();
            }

            return blGoodsName;
        }

        /// <summary>
        /// 仕入先名称取得処理
        /// </summary>
        /// <param name="supplierCode">仕入先コード</param>
        /// <returns>仕入先名称</returns>
        public string GetSupplierName(int supplierCode)
        {
            string supplierName = "";

            if (this._supplierDic.ContainsKey(supplierCode))
            {
                supplierName = this._supplierDic[supplierCode].SupplierNm1.Trim() + " " + this._supplierDic[supplierCode].SupplierNm2.Trim();
            }

            return supplierName;
        }

        /// <summary>
        /// 仕入先名称取得処理
        /// </summary>
        /// <param name="supplierCode">仕入先コード</param>
        /// <param name="supplierName1">仕入先名1</param>
        /// <param name="supplierName2">仕入先名2</param>
        /// <returns>ステータス</returns>
        public int GetSupplierName(int supplierCode, out string supplierName1, out string supplierName2)
        {
            int status = -1;

            supplierName1 = "";
            supplierName2 = "";

            if (this._supplierDic.ContainsKey(supplierCode))
            {
                status = 0;
                supplierName1 = this._supplierDic[supplierCode].SupplierNm1.Trim();
                supplierName2 = this._supplierDic[supplierCode].SupplierNm2.Trim();
            }

            return (status);
        }

        /// <summary>
        /// 得意先名称取得処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>得意先名称</returns>
        public string GetCustomerName(int customerCode)
        {
            string customerName = "";

            try
            {
                int[] customerCodeArray = new int[1];
                customerCodeArray[0] = customerCode;

                Hashtable nameTable;
                Hashtable nameTable2;

                int status = this._customerInfoAcs.GetName(LoginInfoAcquisition.EnterpriseCode, customerCodeArray, out nameTable, out nameTable2);
                if (status == 0)
                {
                    customerName = (string)nameTable[customerCode] + " " + (string)nameTable2[customerCode];
                }
            }
            catch
            {
                customerName = "";
            }

            return customerName;
        }

        /// <summary>
        /// 得意先名称取得処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="customerName1">得意先名1</param>
        /// <param name="customerName2">得意先名2</param>
        /// <returns>ステータス</returns>
        public int GetCustomerName(int customerCode, out string customerName1, out string customerName2)
        {
            int status = -1;

            customerName1 = "";
            customerName2 = "";

            try
            {
                int[] customerCodeArray = new int[1];
                customerCodeArray[0] = customerCode;

                Hashtable nameTable;
                Hashtable nameTable2;

                status = this._customerInfoAcs.GetName(LoginInfoAcquisition.EnterpriseCode, customerCodeArray, out nameTable, out nameTable2);
                if (status == 0)
                {
                    customerName1 = (string)nameTable[customerCode];
                    customerName2 = (string)nameTable2[customerCode];
                }
            }
            catch
            {
                status = -1;
                customerName1 = "";
                customerName2 = "";
            }

            return (status);
        }

        // --- ADD yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
        private GoodsAcs GetGoodsAcs()
        {
            if (this._goodsAcs == null)
            {
                this._goodsAcs = new GoodsAcs();
            }
            return this._goodsAcs;
        }
        // --- ADD yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<

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
                //int status = this._goodsAcs.Read(LoginInfoAcquisition.EnterpriseCode, makerCode, goodsNo, out goodsUnitData);  //DEL yangyi 2013/03/01 Redmine#34175
                int status = GetGoodsAcs().Read(LoginInfoAcquisition.EnterpriseCode, makerCode, goodsNo, out goodsUnitData);     //ADD yangyi 2013/03/01 Redmine#34175 
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

        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        public string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            try
            {
                if (this._secInfoSetDic.ContainsKey(sectionCode))
                {
                    sectionName = this._secInfoSetDic[sectionCode].SectionGuideNm.Trim();
                }
            }
            catch
            {
                sectionName = "";
            }

            return sectionName;
        }

        /// <summary>
        /// 商品中分類名称取得処理
        /// </summary>
        /// <param name="goodsMGroup">商品中分類コード</param>
        /// <returns>商品中分類名称</returns>
        public string GetGoodsMGroupName(int goodsMGroup)
        {
            string goodsMGroupName = "";

            try
            {
                if (this._goodsGroupUDic.ContainsKey(goodsMGroup))
                {
                    goodsMGroupName = this._goodsGroupUDic[goodsMGroup].GoodsMGroupName.Trim();
                }
            }
            catch
            {
                goodsMGroupName = "";
            }

            return goodsMGroupName;
        }

        /// <summary>
        /// 商品大分類
        /// </summary>
        /// <param name="goodsLGroup">商品大分類コード</param>
        /// <returns>商品大分類名称</returns>
        public string GetGoodsLGroupName(int goodsLGroup)
        {
            string goodsLGroupName = "";

            try
            {
                if (this._userGdBdDic.ContainsKey(goodsLGroup))
                {
                    goodsLGroupName = this._userGdBdDic[goodsLGroup].GuideName.Trim();
                }
            }
            catch
            {
                goodsLGroupName = "";
            }

            return goodsLGroupName;
        }

        #endregion ◆ 名称取得処理

        // ---ADD 2009/05/14 不具合対応[13260] ------------->>>>>
        #region ◆ 端数処理
        public long a(double value)
        {
            return 0;
        }
        #endregion ◆ 端数処理End
        // ---ADD 2009/05/14 不具合対応[13260] -------------<<<<<

        // --- ADD 2009/12/03 ---------->>>>>
        #region ◆ 在庫総数取得処理
        /// <summary>
        /// 在庫総数取得処理
        /// </summary>
        /// <param name="stock">在庫情報</param>
        /// <param name="inventoryDay">棚卸実施日</param>
        /// <returns>在庫総数</returns>
        /// <remarks>
        /// <br>Note       : 在庫総数取得処理を行います</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/12/03</br>
        /// </remarks>
        public double GetStockTotal(Stock stock, DateTime inventoryDay)
        {
            double retStockTatal = 0.0;
            double stockTotal = 0.0;
            double arrivalCnt = 0.0;
            double shipmentCnt = 0.0;

            InventoryDataUpdateWork ivtDataWork = new InventoryDataUpdateWork();
            ivtDataWork.EnterpriseCode = stock.EnterpriseCode;
            ivtDataWork.WarehouseCode = stock.WarehouseCode;
            ivtDataWork.GoodsNo = stock.GoodsNo;
            ivtDataWork.GoodsMakerCd = stock.GoodsMakerCd;
            ivtDataWork.InventoryDate = inventoryDay;

            object objIvtDataWork = (object)ivtDataWork;

            IInventoryDataUpdateDB iInventoryDataUpdateDB = MediationInventoryDataUpdateDB.GetInventoryDataUpdateDB();
            iInventoryDataUpdateDB.GetStockTotal(objIvtDataWork, ref stockTotal, ref arrivalCnt, ref shipmentCnt);

            // 棚卸運用区分=ＰＭ．ＮＳ
            if (this._stockMngTtlSt.InventoryMngDiv == 0)
            {
                retStockTatal = stockTotal + arrivalCnt - shipmentCnt;
            }
            // 棚卸運用区分=ＰＭ７　
            else
            {
                retStockTatal = stock.ShipmentPosCnt + stock.AcpOdrCount;
            }

            return retStockTatal;
        }
        #endregion
        // --- ADD 2009/12/03 ----------<<<<<
        #endregion ■ Public Method

        #region ■ Private Method
        #region ◆ マスタ読込処理
        /// <summary>
        /// 商品大分類マスタ読込処理
        /// </summary>
        private void ReadGoodsLGroup()
        {
            try
            {
                this._userGdBdDic = new Dictionary<int, UserGdBd>();

                ArrayList retList;

                int status = this._userGuideAcs.SearchAllDivCodeBody(out retList, LoginInfoAcquisition.EnterpriseCode,
                                                             70, UserGuideAcsData.UserBodyData);
                if (status == 0)
                {
                    foreach (UserGdBd userGdBd in retList)
                    {
                        if (userGdBd.LogicalDeleteCode == 0)
                        {
                            this._userGdBdDic.Add(userGdBd.GuideCode, userGdBd);
                        }
                    }
                }
            }
            catch
            {
                this._userGdBdDic = new Dictionary<int, UserGdBd>();
            }
        }

        /// <summary>
        /// 商品中分類マスタ読込処理
        /// </summary>
        private void ReadGoodsMGroup()
        {
            try
            {
                this._goodsGroupUDic = new Dictionary<int, GoodsGroupU>();

                ArrayList retList;

                int status = this._goodsGroupUAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (GoodsGroupU goodsGroupU in retList)
                    {
                        if (goodsGroupU.LogicalDeleteCode == 0)
                        {
                            this._goodsGroupUDic.Add(goodsGroupU.GoodsMGroup, goodsGroupU);
                        }
                    }
                }
            }
            catch
            {
                this._goodsGroupUDic = new Dictionary<int, GoodsGroupU>();
            }
        }

        /// <summary>
        /// 倉庫マスタ読込処理
        /// </summary>
        private void ReadWarehouse()
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
        private void ReadMakerUMnt()
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
        /// グループコードマスタ読込処理
        /// </summary>
        private void ReadBLGroupU()
        {
            try
            {
                this._blGroupUDic = new Dictionary<int, BLGroupU>();

                ArrayList retList;

                int status = this._blGroupUAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (BLGroupU blGroupU in retList)
                    {
                        if (blGroupU.LogicalDeleteCode == 0)
                        {
                            this._blGroupUDic.Add(blGroupU.BLGroupCode, blGroupU);
                        }
                    }
                }
            }
            catch
            {
                this._blGroupUDic = new Dictionary<int, BLGroupU>();
            }
        }

        /// <summary>
        /// BLコードマスタ読込処理
        /// </summary>
        private void ReadBLGoodsCdU()
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
        /// 仕入先マスタ読込処理
        /// </summary>
        private void ReadSupplier()
        {
            try
            {
                this._supplierDic = new Dictionary<int, Supplier>();

                ArrayList retList;

                int status = this._supplierAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (Supplier supplier in retList)
                    {
                        if (supplier.LogicalDeleteCode == 0)
                        {
                            this._supplierDic.Add(supplier.SupplierCd, supplier);
                        }
                    }
                }
            }
            catch
            {
                this._supplierDic = new Dictionary<int, Supplier>();
            }
        }

        /// <summary>
        /// 拠点情報設定マスタ読込処理
        /// </summary>
        private void ReadSecInfoSet()
        {
            try
            {
                this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                }
            }
            catch
            {
                this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
            }
        }
        #endregion ◆ マスタ読込処理

        #region ◆ 棚卸データSearch処理
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        public int SearchAll(out List<InventoryDataUpdateWork> inventoryDataUpdateWorkList, string enterpriseCode, DateTime inventoryDate)
        {
            inventoryDataUpdateWorkList = new List<InventoryDataUpdateWork>();

            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            inventoryDataUpdateWorkList = new List<InventoryDataUpdateWork>();
            try
            {
                // 棚卸アクセスクラスインスタンス生成
                IInventInputSearchDB iInventInputSearchDB = MediationInventInputSearchDB.GetInventInputSearchDB();

                InventInputSearchCndtn inventInputSearchCndtn = new InventInputSearchCndtn();
                inventInputSearchCndtn.EnterpriseCode = enterpriseCode;
                inventInputSearchCndtn.InventoryDate = inventoryDate;
                inventInputSearchCndtn.DifCntExtraDiv = 0;
                inventInputSearchCndtn.St_WarehouseCode = "";
                inventInputSearchCndtn.Ed_WarehouseCode = "";
                inventInputSearchCndtn.St_SupplierCd = 0;
                inventInputSearchCndtn.Ed_SupplierCd = 999999;
                inventInputSearchCndtn.St_BLGoodsCode = 0;
                inventInputSearchCndtn.Ed_BLGoodsCode = 99999;
                inventInputSearchCndtn.St_BLGroupCode = 0;
                inventInputSearchCndtn.Ed_BLGroupCode = 99999;
                inventInputSearchCndtn.St_MakerCode = 0;
                inventInputSearchCndtn.Ed_MakerCode = 9999;
                inventInputSearchCndtn.St_InventorySeqNo = 0;
                inventInputSearchCndtn.Ed_InventorySeqNo = 999999;
                inventInputSearchCndtn.StockCntZeroExtraDiv = 0;
                inventInputSearchCndtn.St_InventoryPreprDay = DateTime.MinValue;
                inventInputSearchCndtn.Ed_InventoryPreprDay = DateTime.MinValue;
                inventInputSearchCndtn.IvtStkCntZeroExtraDiv = 0;
                inventInputSearchCndtn.SelectedPaperKind = -1;
                inventInputSearchCndtn.TargetDateExtraDiv = -1;

                // リモート抽出条件クラスに抽出条件展開
                InventInputSearchCndtnWork iisCndtnWork;
                iisCndtnWork = CopyToInventInputSearchCndtnWorkFromInventInputSearchCndtn(inventInputSearchCndtn);

                // 棚卸データ取得
                object retObj;
                status = iInventInputSearchDB.Search(out retObj, (object)iisCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        foreach (ArrayList retArray in (ArrayList)retObj)
                        {
                            // 戻りリストの要素の型がInventoryDataUpdateWorkならばデータ展開
                            if ((retArray.Count > 0) && (retArray[0] is InventoryDataUpdateWork))
                            {
                                foreach (InventoryDataUpdateWork retWork in retArray)
                                {
                                    inventoryDataUpdateWorkList.Add((InventoryDataUpdateWork)retWork);
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            catch
            {

            }

            return 0;
        }
		/// <summary>
		/// 棚卸データSearch処理
		/// </summary>
		/// <returns>Status(ConstantManagement.MethodResult)</returns>
        /// <remarks>
        /// <br>Note		: 棚卸データの取得を行う</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/09/01</br>
        /// <br>Update Note: 2013/03/01 yangyi</br>
        /// <br>管理番号   : 10801804-00 2013/03/06配信分の緊急対応</br>
        /// <br>           : Redmine#34175 　棚卸業務のサーバー負荷軽減対策</br>
        /// </remarks>
		private int SearchInventProc( InventInputSearchCndtn inventInputSearchCndtn, out string errMsg )
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			errMsg = string.Empty;
			try
			{
				// 棚卸アクセスクラスインスタンス生成
                //IInventInputSearchDB iInventInputSearchDB = MediationInventInputSearchDB.GetInventInputSearchDB(); //DEL yangyi 2013/03/01 Redmine#34175
                IInventoryDataUpdateDB iInventoryDataUpdateDB = MediationInventoryDataUpdateDB.GetInventoryDataUpdateDB();//ADD yangyi 2013/03/01 Redmine#34175 
				
                // リモート抽出条件クラスに抽出条件展開
				InventInputSearchCndtnWork iisCndtnWork;
                iisCndtnWork = CopyToInventInputSearchCndtnWorkFromInventInputSearchCndtn(inventInputSearchCndtn);

				// 棚卸データ取得
				object retObj;
                //status = iInventInputSearchDB.Search(out retObj, (object)iisCndtnWork, 1, ConstantManagement.LogicalMode.GetData0); //DEL yangyi 2013/03/01 Redmine#34175
                status = iInventoryDataUpdateDB.Search(out retObj, (object)iisCndtnWork, 1, ConstantManagement.LogicalMode.GetData0); //ADD yangyi 2013/03/01 Redmine#34175 

				switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

						// テーブル初期化
						InventInputResult.CreateDataTable(ref _sta_InventDataTable_Buf);
						InventInputResult.CreateDataTable(ref _sta_InventDataTable);
                        _sta_InventDataTable_Buf.CaseSensitive = true;
                        _sta_InventDataTable.CaseSensitive = true;
                        InventInputResult.CreateDataTable(ref _sta_InventDataTable);
						foreach(ArrayList retArray in (ArrayList)retObj)
						{
							// 戻りリストの要素の型がInventoryDataUpdateWorkならばデータ展開
							if ((retArray.Count > 0 ) && (retArray[0] is InventoryDataUpdateWork))
							{
                                _inventoryDataUpdateWorkList = new List<InventoryDataUpdateWork>();

                                foreach (InventoryDataUpdateWork retWork in retArray)
                                {
                                    // --- ADD yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
                                    if (string.IsNullOrEmpty(retWork.GoodsName))
                                    {
                                        retWork.GoodsName = GetGoodsName(retWork.GoodsMakerCd, retWork.GoodsNo);
                                    }
                                    // --- ADD yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<
                                    _inventoryDataUpdateWorkList.Add((InventoryDataUpdateWork)retWork);
                                }

                                // 検索結果展開処理
								status = DevSearchResult(retArray, ref _sta_InventDataTable_Buf, (int)InventInputSearchCndtn.ChangeFlagState.NotChange, ref errMsg, false , true);
							}
						}
						if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
						{
							_sta_InventDataTable_Buf.Clear();

							return status;
						}

                        // バッファからコピー
						CopyTableToTable(ref _sta_InventDataTable_Buf, ref _sta_InventDataTable);

						errMsg = "";
						status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
						break;
					case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
						errMsg = "該当データが存在しません。";
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
					default:
						status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
						errMsg = "棚卸データの検索に失敗しました。";
						break;
				}
			}
			catch( Exception ex )
			{
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
				errMsg = ex.Message;
			}

			return status;
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 棚卸データSearch処理
        /// </summary>
        /// <returns>Status(ConstantManagement.MethodResult)</returns>
        /// <remarks>
        /// <br>Note		: 棚卸データの取得を行う</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.04.10</br>
        /// </remarks>
        private int SearchInventProc(InventInputSearchCndtn inventInputSearchCndtn, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;
            try
            {
                // Todo:棚卸アクセスクラスインスタンス生成
                IInventInputSearchDB iInventInputSearchDB = MediationInventInputSearchDB.GetInventInputSearchDB();
                // Todo:リモート抽出条件クラスに抽出条件展開
                InventInputSearchCndtnWork iisCndtnWork;
                DevSearchCondition(inventInputSearchCndtn, out iisCndtnWork);

                // Todo:棚卸データ取得
                object retObj;
                //				status = iInventInputSearchDB.Search( out retObj, (object)iisCndtnWork, 0, ConstantManagement.LogicalMode.GetData0 );
                status = iInventInputSearchDB.Search(out retObj, (object)iisCndtnWork, 1, ConstantManagement.LogicalMode.GetData0);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // テーブル初期化
                        InventInputResult.CreateDataTable(ref _sta_InventDataTable_Buf);
                        InventInputResult.CreateDataTable(ref _sta_InventDataTable);	// 2007.07.20 kubo add
                        // 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
                        _sta_InventDataTable_Buf.CaseSensitive = true;
                        _sta_InventDataTable.CaseSensitive = true;
                        // 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<
                        InventInputResult.CreateDataTable(ref _sta_InventDataTable);	// 2007.07.20 kubo add
                        foreach (ArrayList retArray in (ArrayList)retObj)
                        {
                            // 戻りリストの要素の型がInventoryDataUpdateWorkならばデータ展開
                            if ((retArray.Count > 0) && (retArray[0] is InventoryDataUpdateWork))
                            {
                                status = DevSearchResult(retArray, ref _sta_InventDataTable_Buf, (int)InventInputSearchCndtn.ChangeFlagState.NotChange, ref errMsg, false, true);
                            }
                        }
                        if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            _sta_InventDataTable_Buf.Clear();

                            return status;
                        }

                        // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
                        //// 差異分のみ抽出の場合
                        //if ( inventInputSearchCndtn.DifCntExtraDiv == (int)InventInputSearchCndtn.DifCntExtraDivState.NotExtra )
                        //{
                        //    status = DifCntExtraDelteProc(ref errMsg);
                        //    // 処理が正常に終了したか？
                        //    if ( status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
                        //        break;

                        //    // テーブルにRowがあるか
                        //    if ( _sta_InventDataTable_Buf.Rows.Count <= 0 )
                        //    {
                        //        CopyTableToTable( ref _sta_InventDataTable_Buf, ref _sta_InventDataTable );
                        //        errMsg = "対象データがありません";
                        //        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        //        break;
                        //    }

                        //}
                        // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
                        // バッファからコピー
                        CopyTableToTable(ref _sta_InventDataTable_Buf, ref _sta_InventDataTable);

                        errMsg = "";
                        status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        errMsg = "対象データがありません";
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                        errMsg = "棚卸データの検索に失敗しました";
                        break;

                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                errMsg = ex.Message;
            }

            return status;
        }	
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion ◆ 棚卸データSearch処理

        #region ◆ 抽出条件展開処理
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// クラスメンバコピー処理(棚卸検索抽出条件クラス→棚卸検索抽出条件ワーククラス)
        /// </summary>
        /// <param name="inventInputSearchCndtn">棚卸検索抽出条件クラス</param>
        /// <returns>棚卸検索抽出条件ワーククラス</returns>
        /// <remarks>
        /// <br>Note		: クラスメンバをコピーします。</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/09/01</br>
        /// <br>UpdateNote : 2011/01/11 鄧潘ハン</br>
        /// <br>             貸出分の印刷がされない不具合の修正</br>
        /// </remarks>
        private InventInputSearchCndtnWork CopyToInventInputSearchCndtnWorkFromInventInputSearchCndtn(InventInputSearchCndtn inventInputSearchCndtn)
        {
            InventInputSearchCndtnWork inventInputSearchCndtnWork = new InventInputSearchCndtnWork();

            inventInputSearchCndtnWork.EnterpriseCode = inventInputSearchCndtn.EnterpriseCode;			        // 企業コード
            inventInputSearchCndtnWork.St_SectionCode = inventInputSearchCndtn.St_SectionCode;				    // 開始拠点コード
            inventInputSearchCndtnWork.Ed_SectionCode = inventInputSearchCndtn.Ed_SectionCode;				    // 終了拠点コード
            inventInputSearchCndtnWork.St_MakerCode = inventInputSearchCndtn.St_MakerCode;			            // 開始メーカーコード
            inventInputSearchCndtnWork.Ed_MakerCode = inventInputSearchCndtn.Ed_MakerCode;			            // 終了メーカーコード
            inventInputSearchCndtnWork.St_GoodsNo = inventInputSearchCndtn.St_GoodsNo;		    	            // 開始品番
            inventInputSearchCndtnWork.Ed_GoodsNo = inventInputSearchCndtn.Ed_GoodsNo;			                // 終了品番
            inventInputSearchCndtnWork.WarehouseDiv = inventInputSearchCndtn.WarehouseDiv;                      // 倉庫指定範囲
            inventInputSearchCndtnWork.St_WarehouseCode = inventInputSearchCndtn.St_WarehouseCode;		        // 開始倉庫コード
            inventInputSearchCndtnWork.Ed_WarehouseCode = inventInputSearchCndtn.Ed_WarehouseCode;		        // 終了倉庫コード
            inventInputSearchCndtnWork.WarehouseCd01 = inventInputSearchCndtn.WarehouseCd01;                    // 倉庫コード01
            inventInputSearchCndtnWork.WarehouseCd02 = inventInputSearchCndtn.WarehouseCd02;                    // 倉庫コード02
            inventInputSearchCndtnWork.WarehouseCd03 = inventInputSearchCndtn.WarehouseCd03;                    // 倉庫コード03
            inventInputSearchCndtnWork.WarehouseCd04 = inventInputSearchCndtn.WarehouseCd04;                    // 倉庫コード04
            inventInputSearchCndtnWork.WarehouseCd05 = inventInputSearchCndtn.WarehouseCd05;                    // 倉庫コード05
            inventInputSearchCndtnWork.WarehouseCd06 = inventInputSearchCndtn.WarehouseCd06;                    // 倉庫コード06
            inventInputSearchCndtnWork.WarehouseCd07 = inventInputSearchCndtn.WarehouseCd07;                    // 倉庫コード07
            inventInputSearchCndtnWork.WarehouseCd08 = inventInputSearchCndtn.WarehouseCd08;                    // 倉庫コード08
            inventInputSearchCndtnWork.WarehouseCd09 = inventInputSearchCndtn.WarehouseCd09;                    // 倉庫コード09
            inventInputSearchCndtnWork.WarehouseCd10 = inventInputSearchCndtn.WarehouseCd10;                    // 倉庫コード10
            inventInputSearchCndtnWork.St_WarehouseShelfNo = inventInputSearchCndtn.St_WarehouseShelfNo;		// 開始棚番
            inventInputSearchCndtnWork.Ed_WarehouseShelfNo = inventInputSearchCndtn.Ed_WarehouseShelfNo;	    // 終了棚番
            inventInputSearchCndtnWork.St_EnterpriseGanreCode = inventInputSearchCndtn.St_EnterpriseGanreCode;  // 開始自社分類コード
            inventInputSearchCndtnWork.Ed_EnterpriseGanreCode = inventInputSearchCndtn.Ed_EnterpriseGanreCode;  // 終了自社分類コード
            inventInputSearchCndtnWork.St_BLGoodsCode = inventInputSearchCndtn.St_BLGoodsCode;                  // 開始BLコード
            inventInputSearchCndtnWork.Ed_BLGoodsCode = inventInputSearchCndtn.Ed_BLGoodsCode;                  // 終了BLコード
            inventInputSearchCndtnWork.St_SupplierCd = inventInputSearchCndtn.St_SupplierCd;			        // 開始仕入先コード
            inventInputSearchCndtnWork.Ed_SupplierCd = inventInputSearchCndtn.Ed_SupplierCd;			        // 終了仕入先コード
            inventInputSearchCndtnWork.St_InventoryPreprDay = inventInputSearchCndtn.St_InventoryPreprDay;	    // 開始棚卸準備処理日付
            inventInputSearchCndtnWork.Ed_InventoryPreprDay = inventInputSearchCndtn.Ed_InventoryPreprDay;	    // 終了棚卸準備処理日付
            inventInputSearchCndtnWork.InventoryDate = inventInputSearchCndtn.InventoryDate;			        // 棚卸日
            inventInputSearchCndtnWork.St_InventorySeqNo = inventInputSearchCndtn.St_InventorySeqNo;		    // 開始棚卸通番
            inventInputSearchCndtnWork.Ed_InventorySeqNo = inventInputSearchCndtn.Ed_InventorySeqNo;		    // 終了棚卸通番
            inventInputSearchCndtnWork.St_BLGroupCode = inventInputSearchCndtn.St_BLGroupCode;                  // 開始グループコード
            inventInputSearchCndtnWork.Ed_BLGroupCode = inventInputSearchCndtn.Ed_BLGroupCode;                  // 終了グループコード
            inventInputSearchCndtnWork.DifCntExtraDiv = inventInputSearchCndtn.DifCntExtraDiv;	                // 差異分抽出区分
            inventInputSearchCndtnWork.StockCntZeroExtraDiv = inventInputSearchCndtn.StockCntZeroExtraDiv;	    // 在庫数0抽出区分
            inventInputSearchCndtnWork.IvtStkCntZeroExtraDiv = inventInputSearchCndtn.IvtStkCntZeroExtraDiv;	// 棚卸在庫数0抽出区分
            inventInputSearchCndtnWork.SelectedPaperKind = inventInputSearchCndtn.SelectedPaperKind;		    // 帳票種別
            inventInputSearchCndtnWork.OutputAppointDiv = inventInputSearchCndtn.OutputAppointDiv;              // 帳票種別
            inventInputSearchCndtnWork.TargetDateExtraDiv = inventInputSearchCndtn.TargetDateExtraDiv;		    // 抽出対象日付区分
            inventInputSearchCndtnWork.CalcStockAmountDiv = inventInputSearchCndtn.CalcStockAmountDiv;          // 在庫数算出フラグ
            inventInputSearchCndtnWork.CalcStockAmountDate = inventInputSearchCndtn.CalcStockAmountDate;        // 在庫数算出日付
            inventInputSearchCndtnWork.StockDiv = inventInputSearchCndtn.StockDiv;                              // 在庫区分
            //---ADD 2011/01/11------------------------------------------------------------>>>>>
            inventInputSearchCndtnWork.LendExtraDiv = inventInputSearchCndtn.LendExtraDiv;
            inventInputSearchCndtnWork.DelayPaymentDiv = inventInputSearchCndtn.DelayPaymentDiv;
            //---ADD 2011/01/11------------------------------------------------------------<<<<<
            return inventInputSearchCndtnWork;
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 抽出条件展開処理
        /// </summary>
        /// <param name="iisCndtn">検索結果ArrayList</param>
        /// <param name="iisCndtnWork">展開対象DataTable</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: 検索結果のDataTableへの展開を行う</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.04.10</br>
        /// </remarks>
        private void DevSearchCondition(InventInputSearchCndtn iisCndtn, out InventInputSearchCndtnWork iisCndtnWork)
        {
            iisCndtnWork = new InventInputSearchCndtnWork();	// リモート抽出条件クラス

            iisCndtnWork.EnterpriseCode = iisCndtn.EnterpriseCode;			// 企業コード
            iisCndtnWork.SectionCode = iisCndtn.SectionCode;				// 拠点コード
            #region // 2007.07.19 kubo del 差異分のみ抽出の仕様変更に伴い削除
            //iisCndtnWork.DifCntExtraDiv				= iisCndtn.DifCntExtraDiv;			// 差異分抽出区分
            #endregion
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //iisCndtnWork.DifCntExtraDiv				= (int)InventInputSearchCndtn.DifCntExtraDivState.Extra;	// 差異分抽出区分 全て
            iisCndtnWork.DifCntExtraDiv = iisCndtn.DifCntExtraDiv;	        // 差異分抽出区分
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            iisCndtnWork.StockCntZeroExtraDiv = iisCndtn.StockCntZeroExtraDiv;	// 在庫数0抽出区分
            iisCndtnWork.St_InventorySeqNo = iisCndtn.St_InventorySeqNo;		// 開始棚卸通番
            iisCndtnWork.Ed_InventorySeqNo = iisCndtn.Ed_InventorySeqNo;		// 終了棚卸通番
            iisCndtnWork.St_WarehouseCode = iisCndtn.St_WarehouseCode;		// 倉庫コード開始
            iisCndtnWork.Ed_WarehouseCode = iisCndtn.Ed_WarehouseCode;		// 倉庫コード終了
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //iisCndtnWork.St_GoodsCode             = iisCndtn.St_GoodsCode;			// 品番開始
            //iisCndtnWork.Ed_GoodsCode				= iisCndtn.Ed_GoodsCode;			// 品番終了
            //iisCndtnWork.St_CarrierCode			= iisCndtn.St_CarrierCode;			// 開始キャリアコード
            //iisCndtnWork.Ed_CarrierCode			= iisCndtn.Ed_CarrierCode;			// 終了キャリアコード
            //iisCndtnWork.St_CarrierEpCode			= iisCndtn.St_CarrierEpCode;		// 事業者コード開始
            //iisCndtnWork.Ed_CarrierEpCode			= iisCndtn.Ed_CarrierEpCode;		// 事業者コード終了
            iisCndtnWork.St_GoodsNo = iisCndtn.St_GoodsNo;		    	// 品番開始
            iisCndtnWork.Ed_GoodsNo = iisCndtn.Ed_GoodsNo;			    // 品番終了
            iisCndtnWork.St_WarehouseShelfNo = iisCndtn.St_WarehouseShelfNo;		// 棚番開始
            iisCndtnWork.Ed_WarehouseShelfNo = iisCndtn.Ed_WarehouseShelfNo;	    // 棚番終了
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
            iisCndtnWork.St_MakerCode = iisCndtn.St_MakerCode;			// メーカーコード開始
            iisCndtnWork.Ed_MakerCode = iisCndtn.Ed_MakerCode;			// メーカーコード終了
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //iisCndtnWork.St_CellphoneModelCode        = iisCndtn.St_CellphoneModelCode;	// 機種コード開始
            //iisCndtnWork.Ed_CellphoneModelCode		= iisCndtn.Ed_CellphoneModelCode;	// 機種コード終了
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            iisCndtnWork.St_LargeGoodsGanreCode = iisCndtn.St_LargeGoodsGanreCode;	// 商品大分類コード開始
            iisCndtnWork.Ed_LargeGoodsGanreCode = iisCndtn.Ed_LargeGoodsGanreCode;	// 商品大分類コード終了
            iisCndtnWork.St_MediumGoodsGanreCode = iisCndtn.St_MediumGoodsGanreCode; // 商品中分類コード開始
            iisCndtnWork.Ed_MediumGoodsGanreCode = iisCndtn.Ed_MediumGoodsGanreCode; // 商品中分類コード終了
            // 2007.09.11 追加 >>>>>>>>>>>>>>>>>>>>
            iisCndtnWork.St_DetailGoodsGanreCode = iisCndtn.St_DetailGoodsGanreCode; // 商品分類詳細コード開始
            iisCndtnWork.Ed_DetailGoodsGanreCode = iisCndtn.Ed_DetailGoodsGanreCode; // 商品分類詳細コード終了
            iisCndtnWork.St_BLGoodsCode = iisCndtn.St_BLGoodsCode;          // ＢＬコード開始
            iisCndtnWork.Ed_BLGoodsCode = iisCndtn.Ed_BLGoodsCode;          // ＢＬコード終了
            iisCndtnWork.St_EnterpriseGanreCode = iisCndtn.St_EnterpriseGanreCode;  // 自社分類コード開始
            iisCndtnWork.Ed_EnterpriseGanreCode = iisCndtn.Ed_EnterpriseGanreCode;  // 自社分類コード終了
            // 2007.09.11 追加 <<<<<<<<<<<<<<<<<<<<
            iisCndtnWork.St_CustomerCode = iisCndtn.St_CustomerCode;			// 得意先コード開始
            iisCndtnWork.Ed_CustomerCode = iisCndtn.Ed_CustomerCode;			// 得意先コード終了
            iisCndtnWork.St_ShipCustomerCode = iisCndtn.St_ShipCustomerCode;		// 開始出荷先得意先コード
            iisCndtnWork.Ed_ShipCustomerCode = iisCndtn.Ed_ShipCustomerCode;		// 終了出荷先得意先コード
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //iisCndtnWork.St_InventoryDay          = iisCndtn.St_InventoryDay;			// 開始棚卸実施日
            //iisCndtnWork.Ed_InventoryDay			= iisCndtn.Ed_InventoryDay;			// 終了棚卸実施日
            iisCndtnWork.InventoryDate = iisCndtn.InventoryDate;			// 棚卸日
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //iisCndtnWork.CompanyStockExtraDiv         = iisCndtn.CompanyStockExtraDiv;	// 自社在庫抽出区分
            //iisCndtnWork.TrustStockExtraDiv			= iisCndtn.TrustStockExtraDiv;		// 受託在庫抽出区分
            //iisCndtnWork.EntrustCmpStockExtraDiv	    = iisCndtn.EntrustCmpStockExtraDiv; // 委託（自社）在庫抽出区分
            //iisCndtnWork.EntrustTrtStockExtraDiv	    = iisCndtn.EntrustTrtStockExtraDiv; // 委託（受託）在庫抽出区分
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

            iisCndtnWork.St_InventoryPreprDay = iisCndtn.St_InventoryPreprDay;	// 開始棚卸準備処理日付
            iisCndtnWork.Ed_InventoryPreprDay = iisCndtn.Ed_InventoryPreprDay;	// 終了棚卸準備処理日付
            iisCndtnWork.IvtStkCntZeroExtraDiv = iisCndtn.IvtStkCntZeroExtraDiv;	// 棚卸在庫数0抽出区分
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //iisCndtnWork.GrossPrintDiv            = iisCndtn.GrossPrintDiv;			// 集計単位
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            iisCndtnWork.SelectedPaperKind = iisCndtn.SelectedPaperKind;		// 帳票種別
            iisCndtnWork.TargetDateExtraDiv = iisCndtn.TargetDateExtraDiv;		// 抽出対象日付区分
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        public int CheckRecord(InventoryDataUpdateWork inventoryDataUpdateWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            string sectionCode;         // 拠点コード
            string warehouseCode;       // 倉庫コード
            int makerCode;              // メーカーコード
            string goodsNo;             // 品番
            int supplierCode;           // 仕入先コード
            int shipCustomerCode;       // 委託先コード
            double stockUnitPriceFl;    // 仕入単価
            int stockDiv;               // 在庫区分
            int grossDiv;               // グロス区分

            foreach (DataRow dataRow in _sta_InventDataTable.Rows)
            {
                if (dataRow[InventInputResult.ct_Col_SectionCode] == DBNull.Value)
                {
                    sectionCode = "";
                }
                else
                {
                    sectionCode = (string)dataRow[InventInputResult.ct_Col_SectionCode];
                }
                if (dataRow[InventInputResult.ct_Col_WarehouseCode] == DBNull.Value)
                {
                    warehouseCode = "";
                }
                else
                {
                    warehouseCode = (string)dataRow[InventInputResult.ct_Col_WarehouseCode];
                }
                if (dataRow[InventInputResult.ct_Col_MakerCode] == DBNull.Value)
                {
                    makerCode = 0;
                }
                else
                {
                    makerCode = (int)dataRow[InventInputResult.ct_Col_MakerCode];
                }
                if (dataRow[InventInputResult.ct_Col_GoodsNo] == DBNull.Value)
                {
                    goodsNo = "";
                }
                else
                {
                    goodsNo = (string)dataRow[InventInputResult.ct_Col_GoodsNo];
                }
                if (dataRow[InventInputResult.ct_Col_SupplierCode] == DBNull.Value)
                {
                    supplierCode = 0;
                }
                else
                {
                    supplierCode = (int)dataRow[InventInputResult.ct_Col_SupplierCode];
                }
                if (dataRow[InventInputResult.ct_Col_ShipCustomerCode] == DBNull.Value)
                {
                    shipCustomerCode = 0;
                }
                else
                {
                    shipCustomerCode = (int)dataRow[InventInputResult.ct_Col_ShipCustomerCode];
                }
                if (dataRow[InventInputResult.ct_Col_StockUnitPrice] == DBNull.Value)
                {
                    stockUnitPriceFl = 0;
                }
                else
                {
                    stockUnitPriceFl = (double)dataRow[InventInputResult.ct_Col_StockUnitPrice];
                }
                if (dataRow[InventInputResult.ct_Col_StockDiv] == DBNull.Value)
                {
                    stockDiv = 0;
                }
                else
                {
                    stockDiv = (int)dataRow[InventInputResult.ct_Col_StockDiv];
                }
                if (dataRow[InventInputResult.ct_Col_GrossDiv] == DBNull.Value)
                {
                    grossDiv = 0;
                }
                else
                {
                    grossDiv = (int)dataRow[InventInputResult.ct_Col_GrossDiv];
                }

                if ((sectionCode.Trim() == inventoryDataUpdateWork.SectionCode.Trim()) &&
                    (warehouseCode.Trim() == inventoryDataUpdateWork.WarehouseCode.Trim()) &&
                    (makerCode == inventoryDataUpdateWork.GoodsMakerCd) &&
                    (goodsNo.Trim() == inventoryDataUpdateWork.GoodsNo.Trim()) &&
                    (supplierCode == inventoryDataUpdateWork.SupplierCd) &&
                    (shipCustomerCode == inventoryDataUpdateWork.ShipCustomerCode) &&
                    (stockUnitPriceFl == inventoryDataUpdateWork.StockUnitPriceFl) &&
                    (stockDiv == inventoryDataUpdateWork.StockDiv) &&
                    (grossDiv == (int)InventInputSearchCndtn.GrossDivState.Goods))
                {
                    return (status);
                }
            }

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        #region ◆ 検索結果展開処理メイン
        /// <summary>
		/// 検索結果展開処理メイン
		/// </summary>
		/// <param name="retArray">検索結果ArrayList</param>
		/// <param name="changeDiv">変更区分</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <param name="isSumToleCnt">差異数計算区分</param>
		/// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: 検索結果のDataTableへの展開を行う</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.04.10</br>
        /// </remarks>
		public int DevSearchResult( ArrayList retArray, int changeDiv, ref string errMsg, bool isSumToleCnt )
		{
			return this.DevSearchResult( retArray, ref _sta_InventDataTable, changeDiv, ref errMsg, isSumToleCnt, false );
		}

		/// <summary>
		/// 検索結果展開処理メイン
		/// </summary>
		/// <param name="retArray">検索結果ArrayList</param>
		/// <param name="workTable">展開対象DataTable</param>
		/// <param name="changeDiv">変更区分</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <param name="isSumToleCnt">差異数計算区分</param>
		/// <param name="isAddSortPrd"></param>
		/// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: 検索結果のDataTableへの展開を行う</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.04.10</br>
        /// <br>Update Note : 2013/03/01 yangyi</br>
        /// <br>管理番号    : 10801804-00 2013/03/06配信分の緊急対応</br>
        /// <br>            : Redmine#34175 　棚卸業務のサーバー負荷軽減対策</br>
        /// </remarks>
		public int DevSearchResult( ArrayList retArray, ref DataTable workTable, int changeDiv, ref string errMsg, bool isSumToleCnt, bool isAddSortPrd )
		{
            DataRow dr;
			errMsg = "";
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            Dictionary<string, DataRow> dataRowDic = new Dictionary<string, DataRow>(); //ADD yangyi 2013/03/01 Redmine#34175

			try
			{
				// データ展開処理
				foreach( InventoryDataUpdateWork retWork in retArray )
				{
                    // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
                    //// 製番在庫データ作成
                    //dr = workTable.NewRow();
                    //if ( retWork.PrdNumMngDiv == (int)InventInputSearchCndtn.PrdNumMngDivState.Product )
                    //	DevSearchResultProc( retWork, dr, true, changeDiv );
                    //else
					//	DevSearchResultProc( retWork, dr, false, changeDiv );
                    //
					// 2007.07.31 kubo add
                    //if (isAddSortPrd)
					//	dr[InventInputResult.ct_Col_SortProductNumber] = retWork.ProductNumber.TrimEnd();

                    dr = workTable.NewRow();

                    // DataRow展開処理
                    DevSearchResultProc(retWork, dr, true, changeDiv);

                    workTable.Rows.Add(dr);
                    // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<

                    dataRowDic.Add(GetPrimaryKeyList2(retWork,(int)InventInputSearchCndtn.GrossDivState.Product), dr); //ADD yangyi 2013/03/01 Redmine#34175 

					#region // 2007.07.24 kubo del
					// 製番管理データは全て表示にするため削除
					// 製番管理データの製番無し分グロスデータ作成
					//if ( retWork.PrdNumMngDiv == (int)InventInputSearchCndtn.PrdNumMngDivState.Product )
					//{
					//    MakeGrossData( ref workTable, retWork, true );
					//}
					#endregion

                    // グロスデータ作成
                    MakeGrossData(ref workTable, dataRowDic, retWork, false, isSumToleCnt); //ADD yangyi 2013/03/01 Redmine#34175 
                    //MakeGrossData(ref workTable, retWork, false, isSumToleCnt);           //DEL yangyi 2013/03/01 Redmine#34175
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

		#region ◆ DataRow展開処理
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// DataRow展開処理
		/// </summary>
		/// <param name="retWork">検索結果ArrayList</param>
		/// <param name="dr">展開対象DataRow</param>
		/// <param name="isView"></param>
		/// <param name="changeDiv">変更区分</param>
		/// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: DataRowにデータを展開する</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/09/01</br>
        /// <br>UpdateNote  : 2009/12/03 李占川 PM.NS　保守対応</br>
        /// <br>              過不足更新済みデータの場合、区分へ「過不足更新済」と表示する</br>
        /// <br>UpdateNote  : 2011/01/30 鄧潘ハン </br>
        /// <br>              障害報告 #18764</br>
        /// <br>UpdateNote  : 2014/10/31 xuyb</br>
        /// <br>              Redmine#40336 障害現象② 原価を修正して新規作成すると棚卸データ．棚卸在庫額が0になる</br>
        /// </remarks>
		public void DevSearchResultProc( InventoryDataUpdateWork retWork, DataRow dr, bool isView, int changeDiv )
		{
			#region
			// 作成日時
			dr[InventInputResult.ct_Col_CreateDateTime] = retWork.CreateDateTime;
			// 更新日時
			dr[InventInputResult.ct_Col_UpdateDateTime] = retWork.UpdateDateTime;
			// 企業コード
			dr[InventInputResult.ct_Col_EnterpriseCode] = retWork.EnterpriseCode;
			// GUID
			dr[InventInputResult.ct_Col_FileHeaderGuid] = retWork.FileHeaderGuid;
			// 更新従業員コード
			dr[InventInputResult.ct_Col_UpdEmployeeCode] = retWork.UpdEmployeeCode;
			// 更新アセンブリID1
			dr[InventInputResult.ct_Col_UpdAssemblyId1] = retWork.UpdAssemblyId1;
			// 更新アセンブリID2
			dr[InventInputResult.ct_Col_UpdAssemblyId2] = retWork.UpdAssemblyId2;
			// 論理削除区分
			dr[InventInputResult.ct_Col_LogicalDeleteCode] = retWork.LogicalDeleteCode;
			// 拠点コード
			dr[InventInputResult.ct_Col_SectionCode] = retWork.SectionCode;
			// 棚卸通番
			dr[InventInputResult.ct_Col_InventorySeqNo] = retWork.InventorySeqNo;
            // 倉庫コード
			dr[InventInputResult.ct_Col_WarehouseCode] = retWork.WarehouseCode;
            // 倉庫名称
            dr[InventInputResult.ct_Col_WarehouseName] = GetWarehouseName(retWork.WarehouseCode);
			// メーカーコード
			dr[InventInputResult.ct_Col_MakerCode] = retWork.GoodsMakerCd;
            // メーカー名称
            dr[InventInputResult.ct_Col_MakerName] = GetMakerName(retWork.GoodsMakerCd);
			// 品番
            dr[InventInputResult.ct_Col_GoodsNo] = retWork.GoodsNo;
            // 品名
            //dr[InventInputResult.ct_Col_GoodsName] = GetGoodsName(retWork.GoodsMakerCd, retWork.GoodsNo);         //DEL 2009/04/14 不具合対応[13075]
            dr[InventInputResult.ct_Col_GoodsName] = retWork.GoodsName;                                             //ADD 2009/04/14 不具合対応[13075]
            // 棚番
            dr[InventInputResult.ct_Col_WarehouseShelfNo] = retWork.WarehouseShelfNo;
            // 重複棚番１
            dr[InventInputResult.ct_Col_DuplicationShelfNo1] = retWork.DuplicationShelfNo1;
            // 重複棚番２
            dr[InventInputResult.ct_Col_DuplicationShelfNo2] = retWork.DuplicationShelfNo2;
            // 商品大分類コード
			dr[InventInputResult.ct_Col_LargeGoodsGanreCode] = retWork.GoodsLGroup;
			// 商品中分類コード
			dr[InventInputResult.ct_Col_MediumGoodsGanreCode] = retWork.GoodsMGroup;
            // グループコード
            dr[InventInputResult.ct_Col_BLGroupCode] = retWork.BLGroupCode;
            // グループコード名称
            dr[InventInputResult.ct_Col_BLGroupName] = GetBLGroupName(retWork.BLGroupCode);
            // 自社分類コード
            dr[InventInputResult.ct_Col_EnterpriseGanreCode] = retWork.EnterpriseGanreCode;
            // ＢＬ品番
            dr[InventInputResult.ct_Col_BLGoodsCode] = retWork.BLGoodsCode;
            // 仕入先コード
            dr[InventInputResult.ct_Col_SupplierCode] = retWork.SupplierCd;
            // 仕入先名称
            // 仕入先名称2
            string supplierName1;
            string supplierName2;
            int status = GetSupplierName(retWork.SupplierCd, out supplierName1, out supplierName2);
            if (status == 0)
            {
                dr[InventInputResult.ct_Col_SupplierName] = supplierName1;
                dr[InventInputResult.ct_Col_SupplierName2] = supplierName2;
            }
            else
            {
                dr[InventInputResult.ct_Col_SupplierName] = "";
                dr[InventInputResult.ct_Col_SupplierName2] = "";
            }
            // JANコード
			dr[InventInputResult.ct_Col_Jan] = retWork.Jan;
			// 仕入単価
			dr[InventInputResult.ct_Col_StockUnitPrice] = retWork.StockUnitPriceFl;
			// 変更前仕入単価
			dr[InventInputResult.ct_Col_BfStockUnitPrice] = retWork.BfStockUnitPriceFl;
			// 仕入単価変更フラグ
			dr[InventInputResult.ct_Col_StkUnitPriceChgFlg] = retWork.StkUnitPriceChgFlg;
			// 在庫区分
			dr[InventInputResult.ct_Col_StockDiv] = retWork.StockDiv;
            // 在庫委託受託区分
            dr[InventInputResult.ct_Col_StockTrtEntDiv] = (int)InventInputSearchCndtn.StockDivState.Company;
            // 在庫委託受託区分名称
            dr[InventInputResult.ct_Col_StockTrtEntDivName] = "自社";
            // 最終仕入年月日
			dr[InventInputResult.ct_Col_LastStockDate] = retWork.LastStockDate;
			// 在庫数
			dr[InventInputResult.ct_Col_StockTotal] = retWork.StockTotal;
			// 出荷先得意先コード
			dr[InventInputResult.ct_Col_ShipCustomerCode] = retWork.ShipCustomerCode;
			// 棚卸在庫数
            if (retWork.InventoryStockCnt == 0)
            {
                dr[InventInputResult.ct_Col_InventoryStockCnt] = DBNull.Value;
            }
            else
            {
                dr[InventInputResult.ct_Col_InventoryStockCnt] = retWork.InventoryStockCnt;
            }
			// 差異数
            if (retWork.InventoryTolerancCnt == 0)
            {
                dr[InventInputResult.ct_Col_InventoryTolerancCnt] = DBNull.Value;
            }
            else
            {
                dr[InventInputResult.ct_Col_InventoryTolerancCnt] = retWork.InventoryTolerancCnt;
            }
			// 変更前差異数
			dr[InventInputResult.ct_Col_BfChgInventoryToleCnt] = retWork.InventoryTolerancCnt;
            // 棚卸日
            dr[InventInputResult.ct_Col_InventoryExeDay_Datetime] = retWork.InventoryDate;
            // 棚卸準備処理日付
            dr[InventInputResult.ct_Col_InventoryPreprDay_Datetime] = retWork.InventoryPreprDay;
			// 棚卸準備処理時間
			dr[InventInputResult.ct_Col_InventoryPreprTim] = retWork.InventoryPreprTim;
			// 棚卸実施日
            DevInventoryDay(dr, retWork.InventoryDay);
			// 棚卸更新日
			dr[InventInputResult.ct_Col_LastInventoryUpdate] = retWork.LastInventoryUpdate;
			// 棚卸新規追加区分
			dr[InventInputResult.ct_Col_InventoryNewDiv] = retWork.InventoryNewDiv;
			// 新規区分名称
			dr[InventInputResult.ct_Col_InventoryNewDivName] = InventoryNewDivName( (int)dr[InventInputResult.ct_Col_InventoryNewDiv] );
            // --- ADD 2009/12/03 ---------->>>>>
            if (retWork.ToleranceUpdateCd == 1)
            {
                dr[InventInputResult.ct_Col_InventoryNewDivName] = "過不足更新済";
            }
            // --- ADD 2009/12/03 ----------<<<<<
			// 集計区分
			dr[InventInputResult.ct_Col_GrossDiv] = (int)InventInputSearchCndtn.GrossDivState.Product;
            dr[InventInputResult.ct_Col_ViewDiv] = (int)InventInputSearchCndtn.ViewState.View;	// 表示
			// 更新対象区分
			dr[InventInputResult.ct_Col_UpdateDiv] = 0;	// 更新対象
			// 変更区分
			dr[InventInputResult.ct_Col_ChangeDiv] = changeDiv;
			// 自行
			dr[InventInputResult.ct_Col_RowSelf] = dr;

            // ---ADD 2009/05/14 不具合対応[13260] ----------------------------------------->>>>>
            // マシン在庫額
            dr[InventInputResult.ct_Col_StockMashinePrice] = retWork.StockMashinePrice;
            // 棚卸在庫額
            dr[InventInputResult.ct_Col_InventoryStockPrice] = retWork.InventoryStockPrice; // ADD 2014/10/31 xuyb FOR Redmine#40336 障害現象②の対応
            //在庫総数(実施日)
            dr[InventInputResult.ct_Col_StockTotalExec] = retWork.StockTotalExec;
            //過不足更新区分
            dr[InventInputResult.ct_Col_ToleranceUpdateCd] = retWork.ToleranceUpdateCd;
            //調整用計算原価
            dr[InventInputResult.ct_Col_AdjustCalcCost] = retWork.AdjstCalcCost;
            // ---ADD 2009/05/14 不具合対応[13260] -----------------------------------------<<<<<
           
            // ---ADD 2011/01/30  ----------------------------------------->>>>>
            //定価
            dr[InventInputResult.ct_Col_ListPrice] = retWork.ListPrice; 
            // ---ADD 2011/01/30  -----------------------------------------<<<<<
            #endregion
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// DataRow展開処理
        /// </summary>
        /// <param name="retWork">検索結果ArrayList</param>
        /// <param name="dr">展開対象DataRow</param>
        /// <param name="isView"></param>
        /// <param name="changeDiv">変更区分</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: DataRowにデータを展開する</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.04.10</br>
        /// </remarks>
        public void DevSearchResultProc(InventoryDataUpdateWork retWork, DataRow dr, bool isView, int changeDiv)
        {
            #region
            // 作成日時
            dr[InventInputResult.ct_Col_CreateDateTime] = retWork.CreateDateTime;
            // 更新日時
            dr[InventInputResult.ct_Col_UpdateDateTime] = retWork.UpdateDateTime;
            // 企業コード
            dr[InventInputResult.ct_Col_EnterpriseCode] = retWork.EnterpriseCode;
            // GUID
            dr[InventInputResult.ct_Col_FileHeaderGuid] = retWork.FileHeaderGuid;
            // 更新従業員コード
            dr[InventInputResult.ct_Col_UpdEmployeeCode] = retWork.UpdEmployeeCode;
            // 更新アセンブリID1
            dr[InventInputResult.ct_Col_UpdAssemblyId1] = retWork.UpdAssemblyId1;
            // 更新アセンブリID2
            dr[InventInputResult.ct_Col_UpdAssemblyId2] = retWork.UpdAssemblyId2;
            // 論理削除区分
            dr[InventInputResult.ct_Col_LogicalDeleteCode] = retWork.LogicalDeleteCode;
            // 拠点コード
            dr[InventInputResult.ct_Col_SectionCode] = retWork.SectionCode;
            // 拠点ガイド名称
            //			dr[InventInputResult.ct_Col_SectionGuideNm] = retWork.SectionGuideNm;
            // 棚卸通番
            dr[InventInputResult.ct_Col_InventorySeqNo] = retWork.InventorySeqNo;
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 製番在庫マスタGUID
            //dr[InventInputResult.ct_Col_ProductStockGuid] = retWork.ProductStockGuid;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            // 倉庫コード
            dr[InventInputResult.ct_Col_WarehouseCode] = retWork.WarehouseCode;
            // 倉庫名称
            dr[InventInputResult.ct_Col_WarehouseName] = retWork.WarehouseName;
            // メーカーコード
            dr[InventInputResult.ct_Col_MakerCode] = retWork.GoodsMakerCd;
            // メーカー名称
            dr[InventInputResult.ct_Col_MakerName] = retWork.MakerName;
            // 品番
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //dr[InventInputResult.ct_Col_GoodsCode] = retWork.GoodsCode;
            dr[InventInputResult.ct_Col_GoodsNo] = retWork.GoodsNo;
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
            // 品名
            dr[InventInputResult.ct_Col_GoodsName] = retWork.GoodsName;
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //// 機種コード
            //dr[InventInputResult.ct_Col_CellphoneModelCode] = retWork.CellphoneModelCode;
            //// 機種名称
            //dr[InventInputResult.ct_Col_CellphoneModelName] = retWork.CellphoneModelName;
            //// キャリアコード
            //dr[InventInputResult.ct_Col_CarrierCode] = retWork.CarrierCode;
            //// キャリア名称
            //dr[InventInputResult.ct_Col_CarrierName] = retWork.CarrierName;
            //// 系統色コード
            //dr[InventInputResult.ct_Col_SystematicColorCd] = retWork.SystematicColorCd;
            //// 系統色名称
            //dr[InventInputResult.ct_Col_SystematicColorNm] = retWork.SystematicColorNm;
            // 棚番
            dr[InventInputResult.ct_Col_WarehouseShelfNo] = retWork.WarehouseShelfNo;
            // 重複棚番１
            dr[InventInputResult.ct_Col_DuplicationShelfNo1] = retWork.DuplicationShelfNo1;
            // 重複棚番２
            dr[InventInputResult.ct_Col_DuplicationShelfNo2] = retWork.DuplicationShelfNo2;
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
            // 商品大分類コード
            dr[InventInputResult.ct_Col_LargeGoodsGanreCode] = retWork.LargeGoodsGanreCode;
            // 商品大分類名称
            dr[InventInputResult.ct_Col_LargeGoodsGanreName] = retWork.LargeGoodsGanreName;
            // 商品中分類コード
            dr[InventInputResult.ct_Col_MediumGoodsGanreCode] = retWork.MediumGoodsGanreCode;
            // 商品中分類名称
            dr[InventInputResult.ct_Col_MediumGoodsGanreName] = retWork.MediumGoodsGanreName;
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //// 事業者コード
            //dr[InventInputResult.ct_Col_CarrierEpCode] = retWork.CarrierEpCode;
            //// 事業者名称
            //dr[InventInputResult.ct_Col_CarrierEpName] = retWork.CarrierEpName;
            // グループコード
            dr[InventInputResult.ct_Col_DetailGoodsGanreCode] = retWork.DetailGoodsGanreCode;
            // グループコード名称
            dr[InventInputResult.ct_Col_DetailGoodsGanreName] = retWork.DetailGoodsGanreName;
            // 自社分類コード
            dr[InventInputResult.ct_Col_EnterpriseGanreCode] = retWork.EnterpriseGanreCode;
            // 自社分類名称
            dr[InventInputResult.ct_Col_EnterpriseGanreName] = retWork.EnterpriseGanreName;
            // ＢＬ品番
            dr[InventInputResult.ct_Col_BLGoodsCode] = retWork.BLGoodsCode;
            // ＢＬ品名
            //            dr[InventInputResult.ct_Col_BLGoodsName] = retWork.BLGoodsName;
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
            // 得意先コード
            dr[InventInputResult.ct_Col_CustomerCode] = retWork.CustomerCode;
            // 得意先名称
            dr[InventInputResult.ct_Col_CustomerName] = retWork.CustomerName;
            // 得意先名称2
            dr[InventInputResult.ct_Col_CustomerName2] = retWork.CustomerName2;
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 仕入日
            //dr[InventInputResult.ct_Col_StockDate] = retWork.StockDate;
            //// 入荷日
            //dr[InventInputResult.ct_Col_ArrivalGoodsDay] = retWork.ArrivalGoodsDay;
            //// 製造番号
            //dr[InventInputResult.ct_Col_ProductNumber] = retWork.ProductNumber.TrimEnd();
            //// 商品電話番号1
            //dr[InventInputResult.ct_Col_StockTelNo1] = retWork.StockTelNo1.TrimEnd();
            //// 変更前商品電話番号1
            //dr[InventInputResult.ct_Col_BfStockTelNo1] = retWork.BfStockTelNo1.TrimEnd();
            //// 商品電話番号1変更フラグ
            //dr[InventInputResult.ct_Col_StkTelNo1ChgFlg] = retWork.StkTelNo1ChgFlg;
            //// 商品電話番号2
            //dr[InventInputResult.ct_Col_StockTelNo2] = retWork.StockTelNo2.TrimEnd();
            //// 変更前商品電話番号2
            //dr[InventInputResult.ct_Col_BfStockTelNo2] = retWork.BfStockTelNo2.TrimEnd();
            //// 商品電話番号2変更フラグ
            //dr[InventInputResult.ct_Col_StkTelNo2ChgFlg] = retWork.StkTelNo2ChgFlg;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            // JANコード
            dr[InventInputResult.ct_Col_Jan] = retWork.Jan;
            // 仕入単価
            dr[InventInputResult.ct_Col_StockUnitPrice] = retWork.StockUnitPriceFl;
            // 変更前仕入単価
            dr[InventInputResult.ct_Col_BfStockUnitPrice] = retWork.BfStockUnitPriceFl;
            // 仕入単価変更フラグ
            dr[InventInputResult.ct_Col_StkUnitPriceChgFlg] = retWork.StkUnitPriceChgFlg;
            // 在庫区分
            dr[InventInputResult.ct_Col_StockDiv] = retWork.StockDiv;
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 在庫状態
            //dr[InventInputResult.ct_Col_StockState] = retWork.StockState;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<


            // 在庫委託受託区分を設定
            SetStockDivState(dr, retWork);

            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 移動状態
            //dr[InventInputResult.ct_Col_MoveStatus] = retWork.MoveStatus;
            //if ( retWork.MoveStatus == 2 )// 移動中
            //{
            //	dr[InventInputResult.ct_Col_MoveStockCount] = (int)dr[InventInputResult.ct_Col_MoveStockCount] + 1;
            //}
            //// 商品状態
            //dr[InventInputResult.ct_Col_GoodsCodeStatus] = retWork.GoodsCodeStatus;
            //// 製番管理区分
            //dr[InventInputResult.ct_Col_PrdNumMngDiv] = retWork.PrdNumMngDiv;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            // 最終仕入年月日
            dr[InventInputResult.ct_Col_LastStockDate] = retWork.LastStockDate;
            // 在庫数
            dr[InventInputResult.ct_Col_StockTotal] = retWork.StockTotal;
            // 出荷先得意先コード
            dr[InventInputResult.ct_Col_ShipCustomerCode] = retWork.ShipCustomerCode;
            // 出荷先得意先名称
            dr[InventInputResult.ct_Col_ShipCustomerName] = retWork.ShipCustomerName;
            // 出荷先得意先名称2
            dr[InventInputResult.ct_Col_ShipCustomerName2] = retWork.ShipCustomerName2;
            // 棚卸在庫数
            dr[InventInputResult.ct_Col_InventoryStockCnt] = retWork.InventoryStockCnt;
            // 差異数
            dr[InventInputResult.ct_Col_InventoryTolerancCnt] = retWork.InventoryTolerancCnt;
            // 変更前差異数
            dr[InventInputResult.ct_Col_BfChgInventoryToleCnt] = retWork.InventoryTolerancCnt;

            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            // 棚卸日
            dr[InventInputResult.ct_Col_InventoryExeDay] = TDateTime.DateTimeToLongDate(retWork.InventoryDate);
            dr[InventInputResult.ct_Col_InventoryExeDay_Datetime] = retWork.InventoryDate;
            int yy = TDateTime.DateTimeToLongDate(retWork.InventoryDate) / 10000;
            int mm = (TDateTime.DateTimeToLongDate(retWork.InventoryDate) % 10000) / 100;
            int dd = TDateTime.DateTimeToLongDate(retWork.InventoryDate) % 100;
            dr[InventInputResult.ct_Col_InventoryExeDay_Str] = string.Format("{0}年{1}月{2}日", yy.ToString("d4"), mm.ToString("00"), dd.ToString("00"));
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<

            // 棚卸準備処理日付
            DevDate(
                dr,
                retWork.InventoryPreprDay,
                InventInputResult.ct_Col_InventoryPreprDay,
                InventInputResult.ct_Col_InventoryPreprDay_Datetime,
                InventInputResult.ct_Col_InventoryPreprDay_Year,
                InventInputResult.ct_Col_InventoryPreprDay_Month,
                InventInputResult.ct_Col_InventoryPreprDay_Day);
            // 棚卸準備処理時間
            dr[InventInputResult.ct_Col_InventoryPreprTim] = retWork.InventoryPreprTim;

            // 棚卸実施日
            DevDate(
                dr,
                retWork.InventoryDay,
                InventInputResult.ct_Col_InventoryDay,
                InventInputResult.ct_Col_InventoryDay_Datetime,
                InventInputResult.ct_Col_InventoryDay_Year,
                InventInputResult.ct_Col_InventoryDay_Month,
                InventInputResult.ct_Col_InventoryDay_Day);

            // 棚卸更新日
            dr[InventInputResult.ct_Col_LastInventoryUpdate] = retWork.LastInventoryUpdate;
            // 棚卸新規追加区分
            dr[InventInputResult.ct_Col_InventoryNewDiv] = retWork.InventoryNewDiv;
            // 新規区分名称
            dr[InventInputResult.ct_Col_InventoryNewDivName] = InventoryNewDivName((int)dr[InventInputResult.ct_Col_InventoryNewDiv]);
            // 集計区分
            dr[InventInputResult.ct_Col_GrossDiv] = (int)InventInputSearchCndtn.GrossDivState.Product;
            // ボタン用カラム
            //			dr[InventInputResult.ct_Col_Button] = "";
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// キー
            //dr[InventInputResult.ct_Col_key] = retWork.ProductStockGuid;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

            // 表示区分
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //// 製番管理無しデータの棚データは非表示にする
            //if ( !isView )
            //{
            //	dr[InventInputResult.ct_Col_ViewDiv] = (int)InventInputSearchCndtn.ViewState.NotView;	// 非表示
            //}
            //else
            //{
            //	// 製番が入力されているかどうか判断
            #region // 2007.07.24 kubo del
            // 製番管理するデータは全て表示にするため削除
            //if ( dr[InventInputResult.ct_Col_ProductNumber].ToString().CompareTo("") == 0 )
            //    dr[InventInputResult.ct_Col_ViewDiv] = (int)InventInputSearchCndtn.ViewState.NotView;	// 非表示(製番管理ありでも製番が入っていないデータはグロスして表示)
            //else
            //    dr[InventInputResult.ct_Col_ViewDiv] = (int)InventInputSearchCndtn.ViewState.View;	// 表示
            #endregion
            //	// 2007.07.24 kubo add
            //	dr[InventInputResult.ct_Col_ViewDiv] = (int)InventInputSearchCndtn.ViewState.View;	// 表示
            //}
            dr[InventInputResult.ct_Col_ViewDiv] = (int)InventInputSearchCndtn.ViewState.View;	// 表示
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<

            // 更新対象区分
            dr[InventInputResult.ct_Col_UpdateDiv] = 0;	// 更新対象
            // 変更区分
            dr[InventInputResult.ct_Col_ChangeDiv] = changeDiv;
            // 自行
            dr[InventInputResult.ct_Col_RowSelf] = dr;
            #endregion
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #region ◆ グロスデータ作成処理(public)
        /// <summary>
		/// グロスデータ作成処理(public)
		/// </summary>
		/// <param name="targetRow"></param>
		/// <param name="isMakeParentGrossData"></param>
		/// <returns></returns>
        /// <remarks>
        /// <br>Note		: グロスデータを作成する</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.04.10</br>
        /// </remarks>
		public void MakeGrossData( DataRow targetRow, bool isMakeParentGrossData )
		{
            // 更新クラス作成処理
			InventoryDataUpdateWork idUpdateWork = MakeWriteClass( targetRow );

			#region // 2007.07.24 kubo del
			//// 製番管理データの製番無し分グロスデータ作成
			//if ( idUpdateWork.PrdNumMngDiv == (int)InventInputSearchCndtn.PrdNumMngDivState.Product )
			//{
			//    MakeGrossData( ref _sta_InventDataTable, idUpdateWork, true );
			//}
			#endregion
			// グロスデータ作成
            if (isMakeParentGrossData)
            {
                MakeGrossData(ref _sta_InventDataTable, idUpdateWork, false, false);
            }
		}
		#endregion

		#region ◆ グロスデータ作成処理
		/// <summary>
		/// グロスデータ作成処理
		/// </summary>
		/// <param name="searchResultTable"></param>
		/// <param name="retWork"></param>
		/// <param name="isView"></param>
		/// <param name="isSumToleCnt"></param>
		/// <returns></returns>
        /// <remarks>
        /// <br>Note		: グロスデータを作成する</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.04.10</br>
        /// </remarks>
		private void MakeGrossData( ref DataTable searchResultTable, InventoryDataUpdateWork retWork, bool isView, bool isSumToleCnt )
		{
            int grossDiv = (int)InventInputSearchCndtn.GrossDivState.Product;
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //if ( isView )
			//{
			//	if ( retWork.ProductNumber.CompareTo("") != 0 )
			//	{
			//		// 製番が入っている場合はグロスデータを作らない
			//		return;
			//	}
			//	grossDiv = (int)InventInputSearchCndtn.GrossDivState.Product;
			//}
			//else
			//{
			//	grossDiv = (int)InventInputSearchCndtn.GrossDivState.Goods;
			//}
            grossDiv = (int)InventInputSearchCndtn.GrossDivState.Goods;
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
            bool isNewRow = false;
			DataRow dr;
			// グロス行があるかどうかの確認
			#region // 2007.07.19 kubo del
			//if ( !searchResultTable.Rows.Contains( MakeKey( retWork, isView, grossDiv ) ) )
			//{
			//    // グロス行が無い場合は新規に行を作成
			//    dr = searchResultTable.NewRow();
			//    isNewRow = true;
			//}
			//else
			//{
			//    // グロス行が有る場合は取得
			//    dr = searchResultTable.Rows.Find( MakeKey( retWork, isView, grossDiv ) );	// 指定キーで取得

			//    //if ( (int)dr[InventInputResult.ct_Col_GrossDiv] == (int)InventInputSearchCndtn.GrossDivState.Product )
			//    //{
			//    //    // グロス行が無い場合は新規に行を作成
			//    //    dr = searchResultTable.NewRow();
			//    //    isNewRow = true;
			//    //}
			//} 
			#endregion

			// 2007.07.19 kubo add -------------------------->
			object[] keyObjects = GetPrimaryKeyList( retWork, "", grossDiv, Guid.Empty );
			
            // グロス行が有る場合は取得
			dr = searchResultTable.Rows.Find( keyObjects );	// 指定キーで取得
			if ( dr == null )
			{
				// グロス行が無い場合は新規に行を作成
				dr = searchResultTable.NewRow();
				isNewRow = true;
			}
			// 2007.07.19 kubo add <--------------------------

			// グロスデータ作成
			MakeGrossDataProc( retWork, dr, isNewRow, isView, grossDiv, isSumToleCnt );

			if ( isNewRow )
			{
                // ---ADD 2009/05/14 不具合対応[13260] ---------->>>>>
                // グロスデータの件数を取得して、Noの最大を振る
                int no = (searchResultTable.Rows.Count + 1) / 2;
                dr[InventInputResult.ct_Col_No] = no;
                // ---ADD 2009/05/14 不具合対応[13260] ----------<<<<<

				searchResultTable.Rows.Add(dr);
			}
		}

		#endregion

        #region ◆ グロスデータ作成処理
        // --- ADD yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
        /// <summary>
        /// グロスデータ作成処理
        /// </summary>
        /// <param name="searchResultTable"></param>
        /// <param name="retWork"></param>
        /// <param name="isView"></param>
        /// <param name="isSumToleCnt"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: グロスデータを作成する</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.04.10</br>
        /// </remarks>
        private void MakeGrossData(ref DataTable searchResultTable, Dictionary<string, DataRow> dataRowDic, InventoryDataUpdateWork retWork, bool isView, bool isSumToleCnt)
        {
            int grossDiv = (int)InventInputSearchCndtn.GrossDivState.Product;
    
            grossDiv = (int)InventInputSearchCndtn.GrossDivState.Goods;

            bool isNewRow = false;
            DataRow dr;
            // グロス行があるかどうかの確認


            // 2007.07.19 kubo add -------------------------->

            string keyStr = GetPrimaryKeyList2(retWork,grossDiv);
            //---------- ADD 2013/02/21 #34175 yangyi------------------->>>>>
            // グロス行が有る場合は取得
            if (dataRowDic.ContainsKey(keyStr))
            {
                dr = dataRowDic[keyStr];
            }
            else
            {
                dr = null;
            }

            if (dr == null)
            {
                // グロス行が無い場合は新規に行を作成
                dr = searchResultTable.NewRow();
                isNewRow = true;
            }
            //---------- ADD 2013/02/21 #34175 yangyi-------------------<<<<<

            // グロスデータ作成
            MakeGrossDataProc(retWork, dr, isNewRow, isView, grossDiv, isSumToleCnt);

            if (isNewRow)
            {
                // ---ADD 2009/05/14 不具合対応[13260] ---------->>>>>
                // グロスデータの件数を取得して、Noの最大を振る
                int no = (searchResultTable.Rows.Count + 1) / 2;
                dr[InventInputResult.ct_Col_No] = no;
                // ---ADD 2009/05/14 不具合対応[13260] ----------<<<<<

                searchResultTable.Rows.Add(dr);
                dataRowDic.Add(GetPrimaryKeyList2(retWork, grossDiv), dr);
            }
        }
        // --- ADD yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<
		#endregion

		#region ◆ グロスデータ作成
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// グロスデータ作成
		/// </summary>
		/// <param name="retWork">抽出結果クラス</param>
		/// <param name="dr">展開対象DataRow</param>
		/// <param name="isNewRow">新規行フラグ(true:新規行, false:既存行)</param>
		/// <param name="isView">製番区分(true:製番をキーに含む, false:製番をキーに含まない</param>
		/// <param name="grossDiv">グロス区分</param>
		/// <param name="isSumToleCnt">差異数計算区分</param>
		/// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: DataRowにデータを展開する</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/09/01</br>
        /// <br>UpdateNote  : 2009/12/03 李占川 PM.NS　保守対応</br>
        /// <br>              過不足更新済みデータの場合、区分へ「過不足更新済」と表示する</br>
        /// <br>UpdateNote  : 2011/01/30 鄧潘ハン </br>
        /// <br>              障害報告 #18764</br>
        /// </remarks>
		private void MakeGrossDataProc( InventoryDataUpdateWork retWork, DataRow dr, bool isNewRow, bool isView, int grossDiv, bool isSumToleCnt )
		{
			Guid productStockGuid = Guid.NewGuid();
			#region
			if ( isNewRow )
			{
                // 拠点コード
				dr[InventInputResult.ct_Col_SectionCode] = retWork.SectionCode;
				// 棚卸通番
				dr[InventInputResult.ct_Col_InventorySeqNo] = retWork.InventorySeqNo;
                // 倉庫コード
				dr[InventInputResult.ct_Col_WarehouseCode] = retWork.WarehouseCode;
                // 倉庫名称
                dr[InventInputResult.ct_Col_WarehouseName] = GetWarehouseName(retWork.WarehouseCode);
				// メーカーコード
				dr[InventInputResult.ct_Col_MakerCode] = retWork.GoodsMakerCd;
                // メーカー名称
                dr[InventInputResult.ct_Col_MakerName] = GetMakerName(retWork.GoodsMakerCd);
				// 品番
                dr[InventInputResult.ct_Col_GoodsNo] = retWork.GoodsNo;
                // ---ADD 2011/01/30  -------------------------------------------------->>>>>
                // 定価
                dr[InventInputResult.ct_Col_ListPrice] = retWork.ListPrice;
                // ---ADD 2011/01/30  --------------------------------------------------<<<<<
                // 品名
                //dr[InventInputResult.ct_Col_GoodsName] = GetGoodsName(retWork.GoodsMakerCd, retWork.GoodsNo);         //DEL 2009/04/14 不具合対応[13075]
                dr[InventInputResult.ct_Col_GoodsName] = retWork.GoodsName;                                             //ADD 2009/04/14 不具合対応[13075]
                // 棚番
                dr[InventInputResult.ct_Col_WarehouseShelfNo] = retWork.WarehouseShelfNo;
                // 重複棚番１
                dr[InventInputResult.ct_Col_DuplicationShelfNo1] = retWork.DuplicationShelfNo1;
                // 重複棚番２
                dr[InventInputResult.ct_Col_DuplicationShelfNo2] = retWork.DuplicationShelfNo2;
                // 商品大分類コード
				dr[InventInputResult.ct_Col_LargeGoodsGanreCode] = retWork.GoodsLGroup;
				// 商品中分類コード
				dr[InventInputResult.ct_Col_MediumGoodsGanreCode] = retWork.GoodsMGroup;
                // グループコード
                dr[InventInputResult.ct_Col_BLGroupCode] = retWork.BLGroupCode;
                // グループコード名称
                dr[InventInputResult.ct_Col_BLGroupName] = GetBLGroupName(retWork.BLGroupCode);
                // 自社分類コード
                dr[InventInputResult.ct_Col_EnterpriseGanreCode] = retWork.EnterpriseGanreCode;
                // ＢＬ品番
                dr[InventInputResult.ct_Col_BLGoodsCode] = retWork.BLGoodsCode;
                // JANコード
				dr[InventInputResult.ct_Col_Jan] = retWork.Jan;
                // 仕入先コード
                dr[InventInputResult.ct_Col_SupplierCode] = retWork.SupplierCd;
                // 仕入先名称
                // 仕入先名称2
                int status;
                string supplierName1;
                string supplierName2;
                status = GetSupplierName(retWork.SupplierCd, out supplierName1, out supplierName2);
                if (status == 0)
                {
                    dr[InventInputResult.ct_Col_SupplierName] = supplierName1;
                    dr[InventInputResult.ct_Col_SupplierName2] = supplierName2;
                }
                else
                {
                    dr[InventInputResult.ct_Col_SupplierName] = "";
                    dr[InventInputResult.ct_Col_SupplierName2] = "";
                }
				// 出荷先得意先コード
				dr[InventInputResult.ct_Col_ShipCustomerCode] = retWork.ShipCustomerCode;
				// 在庫区分
				dr[InventInputResult.ct_Col_StockDiv] = retWork.StockDiv;
                // 在庫委託受託区分
                dr[InventInputResult.ct_Col_StockTrtEntDiv] = (int)InventInputSearchCndtn.StockDivState.Company;
                // 在庫委託受託区分名称
                dr[InventInputResult.ct_Col_StockTrtEntDivName] = "自社";
                // 仕入単価
				dr[InventInputResult.ct_Col_StockUnitPrice] = retWork.StockUnitPriceFl;
				// 変更前仕入単価
				dr[InventInputResult.ct_Col_BfStockUnitPrice] = retWork.StockUnitPriceFl;
				// 集計区分
				dr[InventInputResult.ct_Col_GrossDiv] = grossDiv;
				// 棚卸新規追加区分
				dr[InventInputResult.ct_Col_InventoryNewDiv] = retWork.InventoryNewDiv;
				// 新規区分名称
				dr[InventInputResult.ct_Col_InventoryNewDivName] = InventoryNewDivName( (int)dr[InventInputResult.ct_Col_InventoryNewDiv] );
                // --- ADD 2009/12/03 ---------->>>>>
                if (retWork.ToleranceUpdateCd == 1)
                {
                    dr[InventInputResult.ct_Col_InventoryNewDivName] = "過不足更新済";
                }
                // --- ADD 2009/12/03 ----------<<<<<
				dr[InventInputResult.ct_Col_key] = Guid.NewGuid();
				// 自行
				dr[InventInputResult.ct_Col_RowSelf] = dr;
				// 表示区分
				dr[InventInputResult.ct_Col_ViewDiv] = (int)InventInputSearchCndtn.ViewState.View;	// 表示
				// 更新対象区分
				dr[InventInputResult.ct_Col_UpdateDiv] = 1;	// 更新対象外
                // 棚卸日
                dr[InventInputResult.ct_Col_InventoryExeDay_Datetime] = retWork.InventoryDate;

                // ---ADD 2009/05/14 不具合対応[13260] -------------------------------------------------->>>>>
                //マシン在庫額
                dr[InventInputResult.ct_Col_StockMashinePrice] = retWork.StockMashinePrice;
                //在庫総数(実施日)
                dr[InventInputResult.ct_Col_StockTotalExec] = retWork.StockTotalExec;
                //過不足更新区分
                dr[InventInputResult.ct_Col_ToleranceUpdateCd] = retWork.ToleranceUpdateCd;
                //調整用計算原価
                dr[InventInputResult.ct_Col_AdjustCalcCost] = retWork.AdjstCalcCost;
                // ---ADD 2009/05/14 不具合対応[13260] --------------------------------------------------<<<<<
            }

			// 既存の親行に対する編集で、追加データの新規区分が既存で、グロスデータの新規区分が新規なら
			// 追加データの新規区分でグロスデータの新規区分を上書きする
			if ( isNewRow == false && 
				retWork.InventoryNewDiv == (int)InventInputSearchCndtn.NewRowState.Old && 
				(int)dr[InventInputResult.ct_Col_InventoryNewDiv] == (int)InventInputSearchCndtn.NewRowState.New )
			{
				// 棚卸新規追加区分
				dr[InventInputResult.ct_Col_InventoryNewDiv] = retWork.InventoryNewDiv;
				// 新規区分名称
				dr[InventInputResult.ct_Col_InventoryNewDivName] = InventoryNewDivName( (int)dr[InventInputResult.ct_Col_InventoryNewDiv] );
                // --- ADD 2009/12/03 ---------->>>>>
                if (retWork.ToleranceUpdateCd == 1)
                {
                    dr[InventInputResult.ct_Col_InventoryNewDivName] = "過不足更新済";
                }
                // --- ADD 2009/12/03 ----------<<<<<
			}

            // 最新日付かどうかを判定して格納する
            if ((DateTime)dr[InventInputResult.ct_Col_InventoryPreprDay_Datetime] < retWork.InventoryPreprDay)
			{
                dr[InventInputResult.ct_Col_InventoryPreprDay_Datetime] = retWork.InventoryPreprDay;
			}
			// 棚卸準備処理時間
			dr[InventInputResult.ct_Col_InventoryPreprTim] = retWork.InventoryPreprTim;
			// 棚卸実施日
			if( ( dr[InventInputResult.ct_Col_InventoryDay] == DBNull.Value ) ||
				(int)dr[InventInputResult.ct_Col_InventoryDay] < TDateTime.DateTimeToLongDate( retWork.InventoryDay ) )
			{
                // 棚卸実施日展開
                DevInventoryDay(dr, retWork.InventoryDay);
			}
			// 最終仕入年月日
            if ((DateTime)dr[InventInputResult.ct_Col_LastStockDate] < retWork.LastStockDate)
            {
                dr[InventInputResult.ct_Col_LastStockDate] = retWork.LastStockDate;
            }
            // 棚卸更新日
            if ((DateTime)dr[InventInputResult.ct_Col_LastInventoryUpdate] < retWork.LastInventoryUpdate)
            {
                dr[InventInputResult.ct_Col_LastInventoryUpdate] = retWork.LastInventoryUpdate;
            }
			// 仕入単価変更フラグ
            if ((int)dr[InventInputResult.ct_Col_StkUnitPriceChgFlg] != 1)
            {
                dr[InventInputResult.ct_Col_StkUnitPriceChgFlg] = 0;
            }
			// 在庫数
            if (dr[InventInputResult.ct_Col_StockTotal] == DBNull.Value)
            {
                dr[InventInputResult.ct_Col_StockTotal] = retWork.StockTotal;
            }
            else
            {
                dr[InventInputResult.ct_Col_StockTotal] = (double)dr[InventInputResult.ct_Col_StockTotal] + retWork.StockTotal;
            }
			// 棚卸在庫数
            if (dr[InventInputResult.ct_Col_InventoryStockCnt] != DBNull.Value)
            {
                dr[InventInputResult.ct_Col_InventoryStockCnt] = (double)dr[InventInputResult.ct_Col_InventoryStockCnt] + retWork.InventoryStockCnt;

                if ((dr[InventInputResult.ct_Col_InventoryDay_Datetime] == DBNull.Value) ||
                    ((DateTime)dr[InventInputResult.ct_Col_InventoryDay_Datetime] == DateTime.MinValue))
                {
                    if ((double)dr[InventInputResult.ct_Col_InventoryStockCnt] == 0)
                    {
                        dr[InventInputResult.ct_Col_InventoryStockCnt] = DBNull.Value;
                    }
                }
            }
            else
            {
                if (retWork.InventoryStockCnt == 0)
                {
                    dr[InventInputResult.ct_Col_InventoryStockCnt] = DBNull.Value;
                }
                else
                {
                    dr[InventInputResult.ct_Col_InventoryStockCnt] = retWork.InventoryStockCnt;
                }
            }
			// 差異数
			if ((dr[InventInputResult.ct_Col_InventoryTolerancCnt] != DBNull.Value) && 
                (DateTime)dr[InventInputResult.ct_Col_InventoryDay_Datetime] != DateTime.MinValue)
			{
                if (dr[InventInputResult.ct_Col_InventoryStockCnt] == DBNull.Value)
                {
                    dr[InventInputResult.ct_Col_InventoryTolerancCnt] = 0 - (double)dr[InventInputResult.ct_Col_StockTotal];
                }
                else
                {
                    dr[InventInputResult.ct_Col_InventoryTolerancCnt] = (double)dr[InventInputResult.ct_Col_InventoryStockCnt] - (double)dr[InventInputResult.ct_Col_StockTotal];
                }
                dr[InventInputResult.ct_Col_BfChgInventoryToleCnt] = (double)dr[InventInputResult.ct_Col_InventoryTolerancCnt];
            }
			else
			{
                if (isSumToleCnt)
                {
                    if (dr[InventInputResult.ct_Col_InventoryStockCnt] == DBNull.Value)
                    {
                        dr[InventInputResult.ct_Col_InventoryTolerancCnt] = 0 - (double)dr[InventInputResult.ct_Col_StockTotal];
                    }
                    else
                    {
                        dr[InventInputResult.ct_Col_InventoryTolerancCnt] = (double)dr[InventInputResult.ct_Col_InventoryStockCnt] - (double)dr[InventInputResult.ct_Col_StockTotal];
                    }
                    dr[InventInputResult.ct_Col_BfChgInventoryToleCnt] = (double)dr[InventInputResult.ct_Col_InventoryTolerancCnt];
                }
                else
                {
                    dr[InventInputResult.ct_Col_InventoryTolerancCnt] = DBNull.Value;
                    dr[InventInputResult.ct_Col_BfChgInventoryToleCnt] = DBNull.Value;
                }
			}

			// エラーステータス
			if ( retWork.Status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
			{
				// リストのステータスが正常の場合
				if ( (int)dr[InventInputResult.ct_Col_Status] == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
				{
					dr[InventInputResult.ct_Col_Status] = (int)ConstantManagement.DB_Status.ctDB_WARNING;
					dr[InventInputResult.ct_Col_StatusDetail] = GetStatusDetail( (int)ConstantManagement.DB_Status.ctDB_WARNING );
				}
			}

            #endregion
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<
        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// グロスデータ作成
        /// </summary>
        /// <param name="retWork">抽出結果クラス</param>
        /// <param name="dr">展開対象DataRow</param>
        /// <param name="isNewRow">新規行フラグ(true:新規行, false:既存行)</param>
        /// <param name="isView">製番区分(true:製番をキーに含む, false:製番をキーに含まない</param>
        /// <param name="grossDiv">グロス区分</param>
        /// <param name="isSumToleCnt">差異数計算区分</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: DataRowにデータを展開する</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.04.10</br>
        /// </remarks>
        private void MakeGrossDataProc(InventoryDataUpdateWork retWork, DataRow dr, bool isNewRow, bool isView, int grossDiv, bool isSumToleCnt)
        {
            Guid productStockGuid = Guid.NewGuid();
            #region
            if (isNewRow)
            {
                // 拠点コード
                dr[InventInputResult.ct_Col_SectionCode] = retWork.SectionCode;
                // 拠点ガイド名称
                //				dr[InventInputResult.ct_Col_SectionGuideNm] = retWork.SectionGuideNm;
                // 棚卸通番
                dr[InventInputResult.ct_Col_InventorySeqNo] = retWork.InventorySeqNo;
                #region // 2007.07.19 kubo del
                //// 製番在庫マスタGUID
                //dr[InventInputResult.ct_Col_ProductStockGuid] = productStockGuid;
                #endregion
                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                //// 製番在庫マスタGUID
                //dr[InventInputResult.ct_Col_ProductStockGuid] = Guid.Empty;
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                // 倉庫コード
                dr[InventInputResult.ct_Col_WarehouseCode] = retWork.WarehouseCode;
                // 倉庫名称
                dr[InventInputResult.ct_Col_WarehouseName] = retWork.WarehouseName;
                // メーカーコード
                dr[InventInputResult.ct_Col_MakerCode] = retWork.GoodsMakerCd;
                // メーカー名称
                dr[InventInputResult.ct_Col_MakerName] = retWork.MakerName;
                // 品番
                // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
                //dr[InventInputResult.ct_Col_GoodsCode] = retWork.GoodsCode;
                dr[InventInputResult.ct_Col_GoodsNo] = retWork.GoodsNo;
                // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
                // 品名
                dr[InventInputResult.ct_Col_GoodsName] = retWork.GoodsName;
                // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
                //// 機種コード
                //dr[InventInputResult.ct_Col_CellphoneModelCode] = retWork.CellphoneModelCode;
                //// 機種名称
                //dr[InventInputResult.ct_Col_CellphoneModelName] = retWork.CellphoneModelName;
                //// キャリアコード
                //dr[InventInputResult.ct_Col_CarrierCode] = retWork.CarrierCode;
                //// キャリア名称
                //dr[InventInputResult.ct_Col_CarrierName] = retWork.CarrierName;
                //// 系統色コード
                //dr[InventInputResult.ct_Col_SystematicColorCd] = retWork.SystematicColorCd;
                //// 系統色名称
                //dr[InventInputResult.ct_Col_SystematicColorNm] = retWork.SystematicColorNm;
                // 棚番
                dr[InventInputResult.ct_Col_WarehouseShelfNo] = retWork.WarehouseShelfNo;
                // 重複棚番１
                dr[InventInputResult.ct_Col_DuplicationShelfNo1] = retWork.DuplicationShelfNo1;
                // 重複棚番２
                dr[InventInputResult.ct_Col_DuplicationShelfNo2] = retWork.DuplicationShelfNo2;
                // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
                // 商品大分類コード
                dr[InventInputResult.ct_Col_LargeGoodsGanreCode] = retWork.LargeGoodsGanreCode;
                // 商品大分類名称
                dr[InventInputResult.ct_Col_LargeGoodsGanreName] = retWork.LargeGoodsGanreName;
                // 商品中分類コード
                dr[InventInputResult.ct_Col_MediumGoodsGanreCode] = retWork.MediumGoodsGanreCode;
                // 商品中分類名称
                dr[InventInputResult.ct_Col_MediumGoodsGanreName] = retWork.MediumGoodsGanreName;
                // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
                //// 事業者コード
                //dr[InventInputResult.ct_Col_CarrierEpCode] = retWork.CarrierEpCode;
                //// 事業者名称
                //dr[InventInputResult.ct_Col_CarrierEpName] = retWork.CarrierEpName;
                //// 製造番号
                //dr[InventInputResult.ct_Col_ProductNumber] = "";
                //// 商品電話番号1
                //dr[InventInputResult.ct_Col_StockTelNo1] = "";
                //// 変更前商品電話番号1
                //dr[InventInputResult.ct_Col_BfStockTelNo1] = "";
                //// 商品電話番号1変更フラグ
                //dr[InventInputResult.ct_Col_StkTelNo1ChgFlg] = (int)InventInputSearchCndtn.ChangeFlagState.NotChange;
                //// 商品電話番号2
                //dr[InventInputResult.ct_Col_StockTelNo2] = "";
                //// 変更前商品電話番号2
                //dr[InventInputResult.ct_Col_BfStockTelNo2] = "";
                //// 商品電話番号2変更フラグ
                //dr[InventInputResult.ct_Col_StkTelNo2ChgFlg] = (int)InventInputSearchCndtn.ChangeFlagState.NotChange;
                // グループコード
                dr[InventInputResult.ct_Col_DetailGoodsGanreCode] = retWork.DetailGoodsGanreCode;
                // グループコード名称
                dr[InventInputResult.ct_Col_DetailGoodsGanreName] = retWork.DetailGoodsGanreName;
                // 自社分類コード
                dr[InventInputResult.ct_Col_EnterpriseGanreCode] = retWork.EnterpriseGanreCode;
                // 自社分類名称
                dr[InventInputResult.ct_Col_EnterpriseGanreName] = retWork.EnterpriseGanreName;
                // ＢＬ品番
                dr[InventInputResult.ct_Col_BLGoodsCode] = retWork.BLGoodsCode;
                // ＢＬ品名
                //                dr[InventInputResult.ct_Col_BLGoodsName] = retWork.BLGoodsName;
                // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
                // JANコード
                dr[InventInputResult.ct_Col_Jan] = retWork.Jan;
                // 得意先コード
                dr[InventInputResult.ct_Col_CustomerCode] = retWork.CustomerCode;
                // 得意先名称
                dr[InventInputResult.ct_Col_CustomerName] = retWork.CustomerName;
                // 得意先名称2
                dr[InventInputResult.ct_Col_CustomerName2] = retWork.CustomerName2;
                // 出荷先得意先コード
                dr[InventInputResult.ct_Col_ShipCustomerCode] = retWork.ShipCustomerCode;
                // 出荷先得意先名称
                dr[InventInputResult.ct_Col_ShipCustomerName] = retWork.ShipCustomerName;
                // 出荷先得意先名称2
                dr[InventInputResult.ct_Col_ShipCustomerName2] = retWork.ShipCustomerName2;
                // 在庫区分
                dr[InventInputResult.ct_Col_StockDiv] = retWork.StockDiv;
                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                //// 在庫状態
                //dr[InventInputResult.ct_Col_StockState] = retWork.StockState;
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<


                // 在庫委託受託区分を設定
                SetStockDivState(dr, retWork);

                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                //// 商品状態
                //dr[InventInputResult.ct_Col_GoodsCodeStatus] = retWork.GoodsCodeStatus;
                //// 製番管理区分
                //dr[InventInputResult.ct_Col_PrdNumMngDiv] = retWork.PrdNumMngDiv;
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                // 仕入単価
                dr[InventInputResult.ct_Col_StockUnitPrice] = retWork.StockUnitPriceFl;
                // 変更前仕入単価
                dr[InventInputResult.ct_Col_BfStockUnitPrice] = retWork.StockUnitPriceFl;
                // 集計区分
                dr[InventInputResult.ct_Col_GrossDiv] = grossDiv;
                // 棚卸新規追加区分
                dr[InventInputResult.ct_Col_InventoryNewDiv] = retWork.InventoryNewDiv;
                // 新規区分名称
                dr[InventInputResult.ct_Col_InventoryNewDivName] = InventoryNewDivName((int)dr[InventInputResult.ct_Col_InventoryNewDiv]);
                // ボタン用カラム
                //				dr[InventInputResult.ct_Col_Button] = "";
                // キー
                #region // 2007.07.19 kubo del
                //dr[InventInputResult.ct_Col_key] = MakeKey( dr, isView, grossDiv);	// 2007.07.19 kubo del
                #endregion
                dr[InventInputResult.ct_Col_key] = Guid.NewGuid();	// 2007.07.19 kubo add
                // 自行
                dr[InventInputResult.ct_Col_RowSelf] = dr;
                // 表示区分
                dr[InventInputResult.ct_Col_ViewDiv] = (int)InventInputSearchCndtn.ViewState.View;	// 表示
                // 更新対象区分
                dr[InventInputResult.ct_Col_UpdateDiv] = 1;	// 更新対象外

                // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
                // 棚卸日
                dr[InventInputResult.ct_Col_InventoryExeDay] = TDateTime.DateTimeToLongDate(retWork.InventoryDate);
                dr[InventInputResult.ct_Col_InventoryExeDay_Datetime] = retWork.InventoryDate;
                int yy = TDateTime.DateTimeToLongDate(retWork.InventoryDate) / 10000;
                int mm = (TDateTime.DateTimeToLongDate(retWork.InventoryDate) % 10000) / 100;
                int dd = TDateTime.DateTimeToLongDate(retWork.InventoryDate) % 100;
                dr[InventInputResult.ct_Col_InventoryExeDay_Str] = string.Format("{0}年{1}月{2}日", yy.ToString("d4"), mm.ToString("00"), dd.ToString("00"));
                // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            }

            // 既存の親行に対する編集で、追加データの新規区分が既存で、グロスデータの新規区分が新規なら
            // 追加データの新規区分でグロスデータの新規区分を上書きする
            if (isNewRow == false &&
                retWork.InventoryNewDiv == (int)InventInputSearchCndtn.NewRowState.Old &&
                (int)dr[InventInputResult.ct_Col_InventoryNewDiv] == (int)InventInputSearchCndtn.NewRowState.New)
            {
                // 棚卸新規追加区分
                dr[InventInputResult.ct_Col_InventoryNewDiv] = retWork.InventoryNewDiv;
                // 新規区分名称
                dr[InventInputResult.ct_Col_InventoryNewDivName] = InventoryNewDivName((int)dr[InventInputResult.ct_Col_InventoryNewDiv]);
            }



            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 移動状態 (Statusがすでに2:移動中になっていたら更新しない
            //if ( (int)dr[InventInputResult.ct_Col_MoveStatus] != 2 )
            //	dr[InventInputResult.ct_Col_MoveStatus] = retWork.MoveStatus;
            //// 移動状態
            //if ( retWork.MoveStatus == 2 )// 移動中
            //{
            //	dr[InventInputResult.ct_Col_MoveStockCount] = (int)dr[InventInputResult.ct_Col_MoveStockCount] + 1;
            //}
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<


            // 最新日付かどうかを判定して格納する
            if ((int)dr[InventInputResult.ct_Col_InventoryPreprDay] < TDateTime.DateTimeToLongDate(retWork.InventoryPreprDay))
            {
                DevDate(
                    dr,
                    retWork.InventoryPreprDay,
                    InventInputResult.ct_Col_InventoryPreprDay,
                    InventInputResult.ct_Col_InventoryPreprDay_Datetime,
                    InventInputResult.ct_Col_InventoryPreprDay_Year,
                    InventInputResult.ct_Col_InventoryPreprDay_Month,
                    InventInputResult.ct_Col_InventoryPreprDay_Day);
            }
            // 棚卸準備処理時間
            dr[InventInputResult.ct_Col_InventoryPreprTim] = retWork.InventoryPreprTim;
            // 棚卸実施日
            if ((dr[InventInputResult.ct_Col_InventoryDay] == DBNull.Value) ||
                (int)dr[InventInputResult.ct_Col_InventoryDay] < TDateTime.DateTimeToLongDate(retWork.InventoryDay))
            {
                DevDate(
                    dr,
                    retWork.InventoryDay,
                    InventInputResult.ct_Col_InventoryDay,
                    InventInputResult.ct_Col_InventoryDay_Datetime,
                    InventInputResult.ct_Col_InventoryDay_Year,
                    InventInputResult.ct_Col_InventoryDay_Month,
                    InventInputResult.ct_Col_InventoryDay_Day);
            }
            // 最終仕入年月日
            if ((DateTime)dr[InventInputResult.ct_Col_LastStockDate] < retWork.LastStockDate)
                dr[InventInputResult.ct_Col_LastStockDate] = retWork.LastStockDate;
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 仕入日
            //if ( (DateTime)dr[InventInputResult.ct_Col_StockDate] < retWork.StockDate )
            //	dr[InventInputResult.ct_Col_StockDate] = retWork.StockDate;
            //// 入荷日
            //if ( (DateTime)dr[InventInputResult.ct_Col_ArrivalGoodsDay] < retWork.ArrivalGoodsDay )
            //	dr[InventInputResult.ct_Col_ArrivalGoodsDay] = retWork.ArrivalGoodsDay;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            // 棚卸更新日
            if ((DateTime)dr[InventInputResult.ct_Col_LastInventoryUpdate] < retWork.LastInventoryUpdate)
                dr[InventInputResult.ct_Col_LastInventoryUpdate] = retWork.LastInventoryUpdate;
            // 仕入単価変更フラグ
            if ((int)dr[InventInputResult.ct_Col_StkUnitPriceChgFlg] != 1)
                dr[InventInputResult.ct_Col_StkUnitPriceChgFlg] = 0;
            // 在庫数
            dr[InventInputResult.ct_Col_StockTotal] = (double)dr[InventInputResult.ct_Col_StockTotal] + retWork.StockTotal;
            // 棚卸在庫数
            if (dr[InventInputResult.ct_Col_InventoryStockCnt] != DBNull.Value)
                dr[InventInputResult.ct_Col_InventoryStockCnt] = (double)dr[InventInputResult.ct_Col_InventoryStockCnt] + retWork.InventoryStockCnt;
            else
                dr[InventInputResult.ct_Col_InventoryStockCnt] = retWork.InventoryStockCnt;

            // 差異数
            if (dr[InventInputResult.ct_Col_InventoryTolerancCnt] != DBNull.Value && (DateTime)dr[InventInputResult.ct_Col_InventoryDay_Datetime] != DateTime.MinValue)
            {
                //dr[InventInputResult.ct_Col_InventoryTolerancCnt] = (double)dr[InventInputResult.ct_Col_InventoryTolerancCnt] + retWork.InventoryTolerancCnt;
                dr[InventInputResult.ct_Col_InventoryTolerancCnt] = (double)dr[InventInputResult.ct_Col_InventoryStockCnt] - (double)dr[InventInputResult.ct_Col_StockTotal];
                dr[InventInputResult.ct_Col_BfChgInventoryToleCnt] = (double)dr[InventInputResult.ct_Col_InventoryTolerancCnt];
            }
            else
            {
                if (isSumToleCnt)
                {
                    dr[InventInputResult.ct_Col_InventoryTolerancCnt] = (double)dr[InventInputResult.ct_Col_InventoryStockCnt] - (double)dr[InventInputResult.ct_Col_StockTotal];
                    dr[InventInputResult.ct_Col_BfChgInventoryToleCnt] = (double)dr[InventInputResult.ct_Col_InventoryTolerancCnt];
                }
            }

            #region // 2007.07.27 kubo del
            //// 差異数
            //if ( dr[InventInputResult.ct_Col_InventoryTolerancCnt] != DBNull.Value )
            //    dr[InventInputResult.ct_Col_InventoryTolerancCnt] = (double)dr[InventInputResult.ct_Col_InventoryTolerancCnt] + retWork.InventoryTolerancCnt;
            //else
            //    dr[InventInputResult.ct_Col_InventoryTolerancCnt] = retWork.InventoryTolerancCnt;
            //// 変更前差異数
            //if ( dr[InventInputResult.ct_Col_BfChgInventoryToleCnt] != DBNull.Value )
            //    dr[InventInputResult.ct_Col_BfChgInventoryToleCnt] = (double)dr[InventInputResult.ct_Col_BfChgInventoryToleCnt] + retWork.InventoryTolerancCnt;
            //else
            //    dr[InventInputResult.ct_Col_BfChgInventoryToleCnt] = retWork.InventoryTolerancCnt;
            #endregion

            // エラーステータス
            if (retWork.Status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // リストのステータスが正常の場合
                if ((int)dr[InventInputResult.ct_Col_Status] == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    dr[InventInputResult.ct_Col_Status] = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                    dr[InventInputResult.ct_Col_StatusDetail] = GetStatusDetail((int)ConstantManagement.DB_Status.ctDB_WARNING);
                }
            }

            #endregion
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #region ◆ キー作成処理
        /// <summary>
		/// グロスデータキー作成処理
		/// </summary>
		/// <param name="dr">対象DataRow</param>
		/// <param name="isProduct">製番区分(true:製番をキーに含む, false:製番をキーに含まない</param>
		/// <param name="grossDiv">グロス区分</param>
		/// <returns></returns>
        /// <remarks>
        /// <br>Note		: グロスデータのキーを作成する</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.04.10</br>
        /// </remarks>
		public string MakeKey( DataRow dr, bool isProduct, int grossDiv )
		{
			// キーを作成するための抽出結果クラスを作成
			InventoryDataUpdateWork invUpdWork = new InventoryDataUpdateWork();
			invUpdWork.SectionCode			= dr[InventInputResult.ct_Col_SectionCode].ToString();			// 拠点コード
			invUpdWork.WarehouseCode		= dr[InventInputResult.ct_Col_WarehouseCode].ToString();		// 倉庫コード
			invUpdWork.GoodsMakerCd			= (int)dr[InventInputResult.ct_Col_MakerCode];					// メーカーコード
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //invUpdWork.GoodsCode = dr[InventInputResult.ct_Col_GoodsCode].ToString();			            // 品番
			//invUpdWork.CarrierEpCode		= (int)dr[InventInputResult.ct_Col_CarrierEpCode];				// 事業者コード
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            //invUpdWork.CustomerCode = (int)dr[InventInputResult.ct_Col_CustomerCode];				        // 得意先コード
			invUpdWork.ShipCustomerCode		= (int)dr[InventInputResult.ct_Col_ShipCustomerCode];			// 委託先コード
			invUpdWork.StockUnitPriceFl		= (long)dr[InventInputResult.ct_Col_StockUnitPrice];			// 仕入単価
			invUpdWork.StockDiv				= (int)dr[InventInputResult.ct_Col_StockDiv];					// 在庫区分
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //invUpdWork.StockState = (int)dr[InventInputResult.ct_Col_StockState];					            // 在庫状態
			////invUpdWork.InventoryNewDiv		= (int)dr[InventInputResult.ct_Col_InventoryNewDiv];			// 新規区分
            //
			//invUpdWork.ProductNumber		= dr[InventInputResult.ct_Col_ProductNumber].ToString().TrimEnd();	// 製番
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<

			//invUpdWork.CarrierCode			= (int)dr[InventInputResult.ct_Col_CarrierCode];				// キャリアコード
			//invUpdWork.CellphoneModelCode	= dr[InventInputResult.ct_Col_CellphoneModelCode].ToString();	// 機種コード
			//invUpdWork.SystematicColorCd	= (int)dr[InventInputResult.ct_Col_SystematicColorCd];			// 系統色コード
			//invUpdWork.LargeGoodsGanreCode	= (int)dr[InventInputResult.ct_Col_LargeGoodsGanreCode];		// 商品大分類コード
			//invUpdWork.MediumGoodsGanreCode	= (int)dr[InventInputResult.ct_Col_MediumGoodsGanreCode];		// 商品中分類コード
			//invUpdWork.InventorySeqNo		= (int)dr[InventInputResult.ct_Col_InventorySeqNo];				// 通番
			return MakeKey( invUpdWork, isProduct, grossDiv );
		}

		/// <summary>
		/// グロスデータキー作成処理
		/// </summary>
		/// <param name="retWork"></param>
		/// <param name="isProduct">製番区分(true:製番をキーに含む, false:製番をキーに含まない</param>
		/// <param name="grossDiv">グロス区分</param>
		/// <returns></returns>
        /// <remarks>
        /// <br>Note		: グロスデータのキーを作成する</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.04.10</br>
        /// </remarks>
		private string MakeKey( InventoryDataUpdateWork retWork, bool isProduct, int grossDiv )
		{
			// キー項目をリストに登録。
			object[] queryObjList = new object[]{
				retWork.SectionCode,			// 拠点コード
				retWork.WarehouseCode,			// 倉庫コード
				retWork.GoodsMakerCd,				// メーカーコード
				retWork.GoodsNo,				// 品番
                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
				//retWork.CarrierEpCode,			// 事業者コード
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                //retWork.CustomerCode,			// 得意先コード
				retWork.ShipCustomerCode,		// 委託先コード
				retWork.StockUnitPriceFl,			// 仕入単価
				retWork.StockDiv,				// 在庫区分
                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
				//retWork.StockState,				// 在庫状態
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
				retWork.InventoryNewDiv			// 新規区分
				//retWork.CarrierCode,			// キャリアコード
				//retWork.CellphoneModelCode,		// 機種コード
				//retWork.SystematicColorCd,		// 系統色コード
				//retWork.LargeGoodsGanreCode,	// 商品大分類コード
				//retWork.MediumGoodsGanreCode,	// 商品中分類コード
				};

			// Key格納文字列
			StringBuilder strKey = new StringBuilder();

			foreach( object queryObj in queryObjList )
			{
				if ( strKey.ToString().CompareTo("") != 0 )
				{
					strKey.Append("_");
				}
				strKey.Append( queryObj.ToString() );
			}

			if ( (grossDiv == (int)InventInputSearchCndtn.GrossDivState.Product) && ( isProduct ) )
			{
				if ( strKey.ToString().CompareTo("") != 0 )
				{
					strKey.Append("_");
				}
                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                //// 製番
				//strKey.Append( retWork.ProductNumber.ToString() );
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            }

			//if ( strKey.ToString().CompareTo("") != 0 )
			//{
			//    strKey.Append("_");
			//}
			//// 通番
			//strKey.Append( retWork.InventorySeqNo.ToString() );

			// グロス区分
			if ( strKey.ToString().CompareTo("") != 0 )
			{
			    strKey.Append("_");
			}
			strKey.Append( grossDiv.ToString() );

			return strKey.ToString();
		}
		#endregion

        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 棚卸実施日展開処理
        /// </summary>
        /// <param name="dataRow">展開対象DataRow</param>
        /// <param name="inventoryDay">棚卸実施日</param>
        public void DevInventoryDay(DataRow dataRow, DateTime inventoryDay)
        {
            dataRow[InventInputResult.ct_Col_InventoryDay] = TDateTime.DateTimeToLongDate(inventoryDay);
            dataRow[InventInputResult.ct_Col_InventoryDay_Datetime] = inventoryDay;

            if (inventoryDay == DateTime.MinValue)
            {
                dataRow[InventInputResult.ct_Col_InventoryDay_Year] = DBNull.Value;
                dataRow[InventInputResult.ct_Col_InventoryDay_Month] = DBNull.Value;
                dataRow[InventInputResult.ct_Col_InventoryDay_Day] = DBNull.Value;
            }
            else
            {
                dataRow[InventInputResult.ct_Col_InventoryDay_Year] = inventoryDay.Year;
                dataRow[InventInputResult.ct_Col_InventoryDay_Month] = inventoryDay.Month;
                dataRow[InventInputResult.ct_Col_InventoryDay_Day] = inventoryDay.Day;
            }
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 使用していないのでコメントアウト
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		#region ◆ 日付展開処理
		/// <summary>
		/// 日付展開処理
		/// </summary>
		/// <param name="dr">展開対象DataRow</param>
		/// <param name="targetDate">展開元日付</param>
		/// <param name="col_BaseInt">展開対象カラム名(基本 int)</param>
		/// <param name="col_BaseDateTime">展開対象カラム名(基本 Datetime)</param>
		/// <param name="col_Year">展開対象カラム名(年 入力)</param>
		/// <param name="col_Month">展開対象カラム名(月 入力)</param>
		/// <param name="col_Day">展開対象カラム名(日 入力)</param>
		public void DevDate(
			DataRow dr, DateTime targetDate, string col_BaseInt, string col_BaseDateTime, 
			string col_Year, string col_Month, string col_Day )
		{
			int yy = 0;
			int mm = 0;
			int dd = 0;
			string strGengo = "";
			int status;

			//if ( targetDate == DateTime.MinValue )
			//{
			//    dr[col_BaseInt]			= TDateTime.DateTimeToLongDate( targetDate );	// int型日付
			//    dr[col_BaseDateTime]	= targetDate;	// DateTime型日付
			//    dr[col_Year]			= DBNull.Value;	// 年 入力
			//    dr[col_Month]			= DBNull.Value;	// 月 入力
			//    dr[col_Day]				= DBNull.Value;	// 日 入力
			//}
			//else
			//{
				status = TDateTime.SplitDate("YYYYMMDD", targetDate,
					ref strGengo, 
					ref yy, 
					ref mm, 
					ref dd);
				if (status == 0)
				{
					dr[col_BaseInt]			= TDateTime.DateTimeToLongDate( targetDate );	// int型日付
					dr[col_BaseDateTime]	= targetDate;	// DateTime型日付
					dr[col_Year]			= yy;	// 年 入力
					dr[col_Month]			= mm;	// 月 入力
					dr[col_Day]				= dd;	// 日 入力
				}
			//}

		}
		#endregion
        
		#region ◆ 在庫委託受託区分設定処理
		/// <summary>
		/// 在庫委託受託区分設定処理
		/// </summary>
		/// <param name="dr">展開対象DataRow</param>
		/// <param name="retWork">抽出条件クラス</param>
		/// <returns>委託受託区分</returns>
		private void SetStockDivState( DataRow dr, InventoryDataUpdateWork retWork)
		{
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 在庫区分を判定
			//if ( retWork.StockDiv == 0 )
			//{
			//	// 在庫区分 0:自社
            //
			//	// 在庫状態を判断
			//	if ( retWork.StockState == 0 )
			//	{
			//		// 0:在庫
			//		dr[InventInputResult.ct_Col_StockTrtEntDiv] = (int)InventInputSearchCndtn.StockDivState.Company;// 在庫委託受託区分
			//		dr[InventInputResult.ct_Col_StockTrtEntDivName] = "自社";// 在庫委託受託区分
			//	}
			//	else if ( retWork.StockState == 20 )
			//	{
			//		// 20:委託
			//		dr[InventInputResult.ct_Col_StockTrtEntDiv] = (int)InventInputSearchCndtn.StockDivState.Consignment_Company;// 在庫委託受託区分
			//		dr[InventInputResult.ct_Col_StockTrtEntDivName] = "委託(自社)";// 在庫委託受託区分
			//	}
			//}
			//else if ( retWork.StockDiv == 1 )
			//{
			//	// 在庫区分 1:受託
			//	if ( retWork.StockState == 10 )
			//	{
			//		// 10:受託
			//		dr[InventInputResult.ct_Col_StockTrtEntDiv] = (int)InventInputSearchCndtn.StockDivState.Trust;// 在庫委託受託区分
			//		dr[InventInputResult.ct_Col_StockTrtEntDivName] = "受託";// 在庫委託受託区分
			//	}
			//	else if ( retWork.StockState == 20 )
			//	{
			//		// 20:委託
			//		dr[InventInputResult.ct_Col_StockTrtEntDiv] = (int)InventInputSearchCndtn.StockDivState.Consignment_Trust;// 在庫委託受託区分
			//		dr[InventInputResult.ct_Col_StockTrtEntDivName] = "委託(受託)";// 在庫委託受託区分
			//	}
			//}
			//else
			//{
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                    dr[InventInputResult.ct_Col_StockTrtEntDiv] = (int)InventInputSearchCndtn.StockDivState.Company;// 在庫委託受託区分
					dr[InventInputResult.ct_Col_StockTrtEntDivName] = "自社";// 在庫委託受託区分
			//}
		}
		#endregion ◆ 在庫委託受託区分設定処理
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 使用していないのでコメントアウト

        #region ◆ 棚卸マスタ更新処理メイン
        /// <summary>
		/// 棚卸マスタ更新処理メイン
		/// </summary>
		/// <param name="errMsg"></param>
		/// <returns></returns>
        /// <remarks>
        /// <br>Note		: 棚卸マスタ更新処理メイン</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.04.19</br>
        /// </remarks>
        private int WriteInventProc(int difCntExtraDiv, out string errMsg )
		{
			errMsg = "";
			int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			try
			{
				//2007.07.20 kubo add -------------------->
				// テーブルに対する変更のコミット
				_sta_InventDataTable.AcceptChanges();
				//2007.07.20 kubo add <--------------------


				// 書き込み用ArrayList作成
                ArrayList updateList = MakeWriteList(difCntExtraDiv);
				ArrayList beforeUpdateList = (ArrayList)updateList.Clone();

				if ( updateList.Count <= 0 )
				{
                    // 親行削除処理
					RemoveNewParentRow( false, DialogResult.No );	// 親行削除処理
					errMsg = "更新対象データがありません";
					return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
				}

				object writeObj = updateList;
				// 更新処理
				IInventoryDataUpdateDB iInventoryDataUpdateDB = MediationInventoryDataUpdateDB.GetInventoryDataUpdateDB();
				// リモートで更新した後に帰ってくるのは次のパターン
				//		・更新した行(更新日付が変更されている)
				//		・更新でエラーが発生した行(ステータスがゼロ以外)
				//		・新規に追加した行(新規で、ステータスはゼロ。ヘッダ項目が更新されている)
				//		・削除した行(新規でステータスはゼロ。論理削除区分が3。ローカルテーブルから削除する)
				status = iInventoryDataUpdateDB.Write( ref writeObj );

				// エラーステータス反映
				switch ( status )
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						errMsg = "保存しました。";
						status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
						break;
					//case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					//case (int)ConstantManagement.DB_Status.ctDB_EOF:
					//    errMsg = "更新に失敗した商品があります";
					//    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
					//    break;
					default:
                        errMsg = "棚卸データの更新に失敗しました";
                        //errMsg = "更新に失敗した商品があります。画面で確認してください。";
						status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
						break;
				}

                // 更新後処理
				AfterWriteInvent( (ArrayList)writeObj );
                // データテーブルコピー処理
				CopyTableToTable( ref _sta_InventDataTable, ref _sta_InventDataTable_Buf );	// バッファテーブルに保持
			}
			catch( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}

			return status;
		}
		#endregion

		#region ◆ 書き込み用ArrayList作成
        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 書き込み用ArrayList作成
		/// </summary>
		/// <returns></returns>
        /// <remarks>
        /// <br>Note		: 書き込み用ArrayList作成</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.04.19</br>
        /// </remarks>
		public ArrayList MakeWriteList( )
		{
			ArrayList updateDataList = new ArrayList();
			#region // 2007.07.19 kubo del
			//string ct_UpdateFilter = 
			//    string.Format("{0}={1}",InventInputResult.ct_Col_ChangeDiv, (int)InventInputSearchCndtn.ChangeFlagState.Change ) +
			//    string.Format(" and {0}=0",InventInputResult.ct_Col_UpdateDiv) + 
			//    string.Format(" and {0}={1}",InventInputResult.ct_Col_GrossDiv, (int)InventInputSearchCndtn.GrossDivState.Product);
			#endregion

			// 2007.07.19 kubo add ------------------->
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //string ct_UpdateFilter = string.Format("{0}={1} and {2}=0 and {3}={4}",
			//	InventInputResult.ct_Col_ChangeDiv, (int)InventInputSearchCndtn.ChangeFlagState.Change,
			//	InventInputResult.ct_Col_UpdateDiv, InventInputResult.ct_Col_GrossDiv, (int)InventInputSearchCndtn.GrossDivState.Product );
            string ct_UpdateFilter = string.Format("{0}={1} and {2}=0",
                InventInputResult.ct_Col_ChangeDiv, (int)InventInputSearchCndtn.ChangeFlagState.Change,
                InventInputResult.ct_Col_UpdateDiv);
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
            // 2007.07.19 kubo add <-------------------

			// 更新対象DataView作成
			DataView updateDataView = new DataView( _sta_InventDataTable, ct_UpdateFilter, "", DataViewRowState.CurrentRows );

			ArrayList delRowList = new ArrayList();

			// List作成
			if ( updateDataView.Count > 0 )
			{
				for( int index = 0; index < updateDataView.Count; index++ )
				{
					// 更新の判断を行う
					// 新規データか？
//					if ( (int)updateDataView[index][InventInputResult.ct_Col_InventoryNewDiv] == (int)InventInputSearchCndtn.NewRowState.New )
					if ( (double)updateDataView[index][InventInputResult.ct_Col_StockTotal] == 0 )
					{
						// 帳簿数がゼロ又は棚卸日も未入力か？
						if ( ( (updateDataView[index][InventInputResult.ct_Col_InventoryStockCnt] == DBNull.Value ) ||
							   ((double)updateDataView[index][InventInputResult.ct_Col_InventoryStockCnt] == 0 )
							 ) ||
							 ( (updateDataView[index][InventInputResult.ct_Col_InventoryDay_Datetime] == DBNull.Value ) ||
							   ((DateTime)updateDataView[index][InventInputResult.ct_Col_InventoryDay_Datetime] == DateTime.MinValue )
							 )
						   )
						{
							if ( (DateTime)updateDataView[index][InventInputResult.ct_Col_CreateDateTime] == DateTime.MinValue )
							{
								// 新規行で、作成日未入力(棚マスタに登録前)で、棚卸数がゼロのデータは更新対象外
								delRowList.Add( updateDataView[index].Row );
								continue;
							}
							else
							{
								// 新規行で、作成日入力済(棚マスタに登録済)で、棚卸数がゼロのデータは削除行とする
								updateDataView[index][InventInputResult.ct_Col_LogicalDeleteCode] = (int)ConstantManagement.LogicalMode.GetData3;
								delRowList.Add( updateDataView[index].Row );
							}
						}
						// 2007.07.25 kubo add ---------->
						else if ( (int)updateDataView[index][InventInputResult.ct_Col_LogicalDeleteCode] == (int)ConstantManagement.LogicalMode.GetData3 )
						{
							delRowList.Add( updateDataView[index].Row );
						}
						// 2007.07.25 kubo add <----------

					}
					// 書き込み用リストに追加
					updateDataList.Add( MakeWriteClass( updateDataView[index].Row ));

					#region // 2007.07.19 kubo del
					//if ( ( (int)updateDataView[index][InventInputResult.ct_Col_InventoryNewDiv] == (int)InventInputSearchCndtn.NewRowState.New ) &&
					//    ( (updateDataView[index][InventInputResult.ct_Col_InventoryStockCnt] == DBNull.Value ) ||
					//    ( (double)updateDataView[index][InventInputResult.ct_Col_InventoryStockCnt] == 0 ) ) )
					//{
					//    if ( (DateTime)updateDataView[index][InventInputResult.ct_Col_CreateDateTime] == DateTime.MinValue )
					//    {
					//        // 新規行で、作成日未入力(棚マスタに登録前)で、棚卸数がゼロのデータは更新対象外
					//        delRowList.Add( updateDataView[index].Row );
					//        continue;
					//    }
					//    else
					//    {
					//        // 新規行で、作成日入力済(棚マスタに登録済)で、棚卸数がゼロのデータは削除行とする
					//        updateDataView[index][InventInputResult.ct_Col_LogicalDeleteCode] = (int)ConstantManagement.LogicalMode.GetData3;
					//    }
					//}
					//// 書き込み用リストに追加
					//updateDataList.Add( MakeWriteClass( updateDataView[index].Row ));
					#endregion
				}
			}

			// 更新対象外の行を削除
			if ( delRowList.Count != 0 )
			{
				foreach( DataRow delRow in delRowList )
				{
					_sta_InventDataTable.Rows.Remove( delRow );
				}
			}

			return updateDataList;
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 書き込み用ArrayList作成
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: 書き込み用ArrayList作成</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/09/01</br>
        /// <br>UpdateNote  : 2009/12/03 李占川 PM.NS　保守対応</br>
        /// <br>              新規入力時の棚卸通番の付番方法を変更する</br>
        /// </remarks>
        public ArrayList MakeWriteList(int difCntExtraDiv)
        {
            ArrayList updateDataList = new ArrayList();

            string ct_UpdateFilter = string.Format("{0}={1} and {2}=0",
                InventInputResult.ct_Col_ChangeDiv, (int)InventInputSearchCndtn.ChangeFlagState.Change,
                InventInputResult.ct_Col_UpdateDiv);

            string sort = this.MakeSortInvntryPrtOdr(this._stockMngTtlStLogin.InvntryPrtOdrIniDiv); // ADD 2009/12/03

            // 更新対象DataView作成
            //DataView updateDataView = new DataView(_sta_InventDataTable, ct_UpdateFilter, "", DataViewRowState.CurrentRows);
            DataView updateDataView = new DataView(_sta_InventDataTable, ct_UpdateFilter, sort , DataViewRowState.CurrentRows);
            
            ArrayList delRowList = new ArrayList();

            Dictionary<string, InventoryDataUpdateWork> inventoryDataUpdateWorkDic = new Dictionary<string, InventoryDataUpdateWork>();

            // List作成
            if (updateDataView.Count > 0)
            {
                for (int index = 0; index < updateDataView.Count; index++)
                {
                    //
                    // 画面読込時のデータと一緒だった場合は更新対象外
                    //
                    double inventoryStockCnt;
                    DateTime inventoryDay;

                    if (updateDataView[index][InventInputResult.ct_Col_InventoryStockCnt] == DBNull.Value)
                    {
                        inventoryStockCnt = 0;
                    }
                    else
                    {
                        inventoryStockCnt = (double)updateDataView[index][InventInputResult.ct_Col_InventoryStockCnt];
                    }
                    if (updateDataView[index][InventInputResult.ct_Col_InventoryDay_Datetime] == DBNull.Value)
                    {
                        inventoryDay = DateTime.MinValue;
                    }
                    else
                    {
                        inventoryDay = (DateTime)updateDataView[index][InventInputResult.ct_Col_InventoryDay_Datetime];
                    }

                    object[] keyObjects = GetPrimaryKeyList(updateDataView[index].Row, "", (int)updateDataView[index][InventInputResult.ct_Col_GrossDiv], Guid.Empty);

                    DataRow dr = _sta_InventDataTable_Buf.Rows.Find(keyObjects);
                    DataRow dr2 = _sta_InventDataTable.Rows.Find(keyObjects);
                    if (dr != null)
                    {
                        double inventoryStockCnt2;
                        DateTime inventoryDay2;

                        if (dr[InventInputResult.ct_Col_InventoryStockCnt] == DBNull.Value)
                        {
                            inventoryStockCnt2 = 0;
                        }
                        else
                        {
                            inventoryStockCnt2 = (double)dr[InventInputResult.ct_Col_InventoryStockCnt];
                        }
                        if (dr[InventInputResult.ct_Col_InventoryDay_Datetime] == DBNull.Value)
                        {
                            inventoryDay2 = DateTime.MinValue;
                        }
                        else
                        {
                            inventoryDay2 = (DateTime)dr[InventInputResult.ct_Col_InventoryDay_Datetime];
                        }

                        if ((inventoryStockCnt == inventoryStockCnt2) && (inventoryDay == inventoryDay2))
                        {
                            if ((int)dr2[InventInputResult.ct_Col_DeleteDiv] == 0)
                            {
                                continue;
                            }
                        }
                    }

                    // 更新の判断を行う
                    // 新規データか？
                    if ((double)updateDataView[index][InventInputResult.ct_Col_StockTotal] == 0)
                    {
                        // 帳簿数がゼロ又は棚卸日も未入力か？
                        if (((updateDataView[index][InventInputResult.ct_Col_InventoryStockCnt] == DBNull.Value) ||
                               ((double)updateDataView[index][InventInputResult.ct_Col_InventoryStockCnt] == 0)) ||
                             ((updateDataView[index][InventInputResult.ct_Col_InventoryDay_Datetime] == DBNull.Value) ||
                               ((DateTime)updateDataView[index][InventInputResult.ct_Col_InventoryDay_Datetime] == DateTime.MinValue)))
                        {
                            if ((DateTime)updateDataView[index][InventInputResult.ct_Col_CreateDateTime] == DateTime.MinValue)
                            {
                                // 新規行で、作成日未入力(棚卸マスタに登録前)で、棚卸数がゼロのデータは更新対象外
                                //delRowList.Add(updateDataView[index].Row);
                                if ((int)dr2[InventInputResult.ct_Col_DeleteDiv] == 0)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                // 新規行で、作成日入力済(棚卸マスタに登録済)で、棚卸数がゼロのデータは削除行とする
                                //updateDataView[index][InventInputResult.ct_Col_LogicalDeleteCode] = (int)ConstantManagement.LogicalMode.GetData3;
                                //delRowList.Add(updateDataView[index].Row);
                            }
                        }
                        else if ((int)updateDataView[index][InventInputResult.ct_Col_LogicalDeleteCode] == (int)ConstantManagement.LogicalMode.GetData3)
                        {
                            //delRowList.Add(updateDataView[index].Row);
                        }
                    }
                    else
                    {
                        //// 帳簿数がゼロ又は棚卸日も未入力か？
                        //if (((updateDataView[index][InventInputResult.ct_Col_InventoryStockCnt] == DBNull.Value) ||
                        //       ((double)updateDataView[index][InventInputResult.ct_Col_InventoryStockCnt] == 0)) ||
                        //     ((updateDataView[index][InventInputResult.ct_Col_InventoryDay_Datetime] == DBNull.Value) ||
                        //       ((DateTime)updateDataView[index][InventInputResult.ct_Col_InventoryDay_Datetime] == DateTime.MinValue)))
                        //{
                        //    delRowList.Add(updateDataView[index].Row);
                        //}
                    }

                    // 書き込み用リストに追加
                    InventoryDataUpdateWork paraWork = MakeWriteClass(updateDataView[index].Row);
                    if ((int)dr2[InventInputResult.ct_Col_DeleteDiv] != 0)
                    {
                        InventoryDataUpdateWork work = _inventoryDataUpdateWorkList.Find(delegate(InventoryDataUpdateWork target)
                        {
                            if ((target.SectionCode.Trim() == paraWork.SectionCode.Trim()) &&
                                (target.WarehouseCode.Trim() == paraWork.WarehouseCode.Trim()) &&
                                (target.GoodsMakerCd == paraWork.GoodsMakerCd) &&
                                (target.GoodsNo.Trim() == paraWork.GoodsNo.Trim()))
                            {
                                return (true);
                            }
                            else
                            {
                                return (false);
                            }
                        });

                        if (work != null)
                        {
                            paraWork.CreateDateTime = work.CreateDateTime;
                            paraWork.UpdateDateTime = work.UpdateDateTime;
                            paraWork.FileHeaderGuid = work.FileHeaderGuid;
                            paraWork.UpdEmployeeCode = work.UpdEmployeeCode;
                            paraWork.UpdAssemblyId1 = work.UpdAssemblyId1;
                            paraWork.UpdAssemblyId2 = work.UpdAssemblyId2;
                            paraWork.LogicalDeleteCode = 3;
                            paraWork.EnterpriseCode = work.EnterpriseCode;
                        }

                        delRowList.Add(updateDataView[index].Row);
                    }

                    string key = paraWork.SectionCode.Trim().PadLeft(2, '0') +
                                 paraWork.WarehouseCode.Trim().PadLeft(4, '0') +
                                 paraWork.GoodsMakerCd.ToString("0000") +
                                 paraWork.GoodsNo.Trim();

                    if (!inventoryDataUpdateWorkDic.ContainsKey(key))
                    {
                        inventoryDataUpdateWorkDic.Add(key, paraWork);

                        updateDataList.Add(paraWork);
                    }

                    //keyObjects = GetPrimaryKeyList(updateDataView[index].Row, "", (int)updateDataView[index][InventInputResult.ct_Col_GrossDiv], Guid.Empty);
                    //dr = _sta_InventDataTable_Buf.Rows.Find(keyObjects);
                    //if (dr != null)
                    //{
                    //    // 未入力
                    //    if (difCntExtraDiv == 1)
                    //    {
                    //        delRowList.Add(updateDataView[index].Row);
                    //    }
                    //    // 全て、入力
                    //    else if ((difCntExtraDiv == 0) || (difCntExtraDiv == 2))
                    //    {

                    //    }
                    //    // 差異
                    //    else if (difCntExtraDiv == 3)
                    //    {
                    //        if (paraWork.InventoryStockCnt == paraWork.StockTotal)
                    //        {
                    //            delRowList.Add(updateDataView[index].Row);
                    //        }
                    //    }
                    //}
                }

                // 更新対象外の行を削除
                if (delRowList.Count != 0)
                {
                    foreach (DataRow delRow in delRowList)
                    {
                        try
                        {
                            //if ((target.SectionCode.Trim() == paraWork.SectionCode.Trim()) &&
                            //    (target.WarehouseCode.Trim() == paraWork.WarehouseCode.Trim()) &&
                            //    (target.GoodsMakerCd == paraWork.GoodsMakerCd) &&
                            //    (target.GoodsNo.Trim() == paraWork.GoodsNo.Trim()))

                            string sectionCode = delRow[InventInputResult.ct_Col_SectionCode].ToString().Trim();
                            string warehouseCode = delRow[InventInputResult.ct_Col_WarehouseCode].ToString().Trim();
                            string goodsNo = delRow[InventInputResult.ct_Col_GoodsNo].ToString().Trim();
                            int makerCode = int.Parse(delRow[InventInputResult.ct_Col_MakerCode].ToString().Trim());

                            for (int rowIndex = _sta_InventDataTable.Rows.Count - 1; rowIndex >= 0; rowIndex--)
                            {
                                DataRow dr = _sta_InventDataTable.Rows[rowIndex];

                                if ((dr[InventInputResult.ct_Col_SectionCode].ToString().Trim() == sectionCode) &&
                                    (dr[InventInputResult.ct_Col_WarehouseCode].ToString().Trim() == warehouseCode) &&
                                    (dr[InventInputResult.ct_Col_GoodsNo].ToString().Trim() == goodsNo) &&
                                    (int.Parse(dr[InventInputResult.ct_Col_MakerCode].ToString().Trim()) == makerCode))
                                {
                                    _sta_InventDataTable.Rows.RemoveAt(rowIndex);
                                }
                            }
                            //object[] keyObjects = GetPrimaryKeyList(delRow, "", (int)InventInputSearchCndtn.GrossDivState.Goods, Guid.Empty);

                            //DataRow dataRow = _sta_InventDataTable.Rows.Find(keyObjects);

                            //try
                            //{
                            //    _sta_InventDataTable.Rows.Remove(delRow);
                            //}
                            //catch
                            //{
                            //}

                            //try
                            //{
                            //    if ((int)delRow[InventInputResult.ct_Col_DeleteDiv] == 0)
                            //    {
                            //        if (_sta_InventDataTable.Rows.Contains(keyObjects))
                            //        {
                            //            _sta_InventDataTable.Rows.Remove(dataRow);
                            //        }
                            //    }
                            //}
                            //catch
                            //{
                            //}
                        }
                        catch
                        {
                        }
                    }
                }
            }

            return updateDataList;
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<
        #endregion

		#region ◆ 更新クラス作成処理
        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 更新クラス作成処理
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: 書き込み用ArrayList作成</br>
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2008/09/01</br>
        /// <br>UpdateNote  : 2011/01/30 鄧潘ハン </br>
        /// <br>              障害報告 #18764</br>
        /// <br>UpdateNote  : 2014/12/11 xuyb</br>
        /// <br>              仕掛№2133 Redmine#40336 #70 棚卸入力でESCキーを押下して入力内容をクリアした場合、棚卸在庫額が正しく算出されていません。</br>
        /// </remarks>
        public InventoryDataUpdateWork MakeWriteClass(DataRow dr)
        {
            InventoryDataUpdateWork writeWork = new InventoryDataUpdateWork();

            if ((dr[InventInputResult.ct_Col_FileHeaderGuid] != DBNull.Value) &&
                ((Guid)dr[InventInputResult.ct_Col_FileHeaderGuid] != Guid.Empty))
            {
                //
                // 更新時
                //
                // 作成日時
                writeWork.CreateDateTime = (DateTime)dr[InventInputResult.ct_Col_CreateDateTime];
                // 更新日時
                writeWork.UpdateDateTime = (DateTime)dr[InventInputResult.ct_Col_UpdateDateTime];
                // GUID
                writeWork.FileHeaderGuid = (Guid)dr[InventInputResult.ct_Col_FileHeaderGuid];
                // 更新従業員コード
                writeWork.UpdEmployeeCode = dr[InventInputResult.ct_Col_UpdEmployeeCode].ToString();
                // 更新アセンブリID1
                writeWork.UpdAssemblyId1 = dr[InventInputResult.ct_Col_UpdAssemblyId1].ToString();
                // 更新アセンブリID2
                writeWork.UpdAssemblyId2 = dr[InventInputResult.ct_Col_UpdAssemblyId2].ToString();
                // 論理削除区分
                if ((int)dr[InventInputResult.ct_Col_DeleteDiv] == 0)
                {
                    writeWork.LogicalDeleteCode = (int)dr[InventInputResult.ct_Col_LogicalDeleteCode];
                }
                else
                {
                    writeWork.LogicalDeleteCode = 3;
                }
            }

            // 企業コード
            writeWork.EnterpriseCode = dr[InventInputResult.ct_Col_EnterpriseCode].ToString();
            // 拠点コード
            writeWork.SectionCode = dr[InventInputResult.ct_Col_SectionCode].ToString();
            // 棚卸通番
            writeWork.InventorySeqNo = (int)dr[InventInputResult.ct_Col_InventorySeqNo];
            // 倉庫コード
            writeWork.WarehouseCode = dr[InventInputResult.ct_Col_WarehouseCode].ToString();
            // メーカーコード
            writeWork.GoodsMakerCd = (int)dr[InventInputResult.ct_Col_MakerCode];
            // 品番
            writeWork.GoodsNo = dr[InventInputResult.ct_Col_GoodsNo].ToString();
            // ---ADD 2011/01/30  -------------------------------------------------->>>>>
            // 品名
            writeWork.GoodsName = dr[InventInputResult.ct_Col_GoodsName].ToString();
            // 定価
            writeWork.ListPrice = (double)dr[InventInputResult.ct_Col_ListPrice];
            // ---ADD 2011/01/30  --------------------------------------------------<<<<<
            // 棚番
            writeWork.WarehouseShelfNo = dr[InventInputResult.ct_Col_WarehouseShelfNo].ToString();
            // 重複棚番１
            writeWork.DuplicationShelfNo1 = dr[InventInputResult.ct_Col_DuplicationShelfNo1].ToString();
            // 重複棚番２
            writeWork.DuplicationShelfNo2 = dr[InventInputResult.ct_Col_DuplicationShelfNo2].ToString();
            // 商品大分類コード
            writeWork.GoodsLGroup = (int)dr[InventInputResult.ct_Col_LargeGoodsGanreCode];
            // 商品中分類コード
            writeWork.GoodsMGroup = (int)dr[InventInputResult.ct_Col_MediumGoodsGanreCode];
            // グループコード
            writeWork.BLGroupCode = (int)dr[InventInputResult.ct_Col_BLGroupCode];
            // 自社分類コード
            writeWork.EnterpriseGanreCode = (int)dr[InventInputResult.ct_Col_EnterpriseGanreCode];
            // ＢＬ品番
            writeWork.BLGoodsCode = (int)dr[InventInputResult.ct_Col_BLGoodsCode];
            // 仕入先コード
            writeWork.SupplierCd = (int)dr[InventInputResult.ct_Col_SupplierCode];
            // JANコード
            writeWork.Jan = dr[InventInputResult.ct_Col_Jan].ToString();
            // 仕入単価
            writeWork.StockUnitPriceFl = (double)dr[InventInputResult.ct_Col_StockUnitPrice];
            // 変更前仕入単価
            writeWork.BfStockUnitPriceFl = (double)dr[InventInputResult.ct_Col_BfStockUnitPrice];
            // 仕入単価変更フラグ
            writeWork.StkUnitPriceChgFlg = (int)dr[InventInputResult.ct_Col_StkUnitPriceChgFlg];
            // 在庫区分
            writeWork.StockDiv = (int)dr[InventInputResult.ct_Col_StockDiv];
            // 最終仕入年月日
            writeWork.LastStockDate = (DateTime)dr[InventInputResult.ct_Col_LastStockDate];
            // 出荷先得意先コード
            writeWork.ShipCustomerCode = (int)dr[InventInputResult.ct_Col_ShipCustomerCode];
            // 帳簿数
            writeWork.StockTotal = (double)dr[InventInputResult.ct_Col_StockTotal];
            // 棚卸在庫数
            if (dr[InventInputResult.ct_Col_InventoryStockCnt] == DBNull.Value)
            {
                writeWork.InventoryStockCnt = 0;
            }
            else
            {
                writeWork.InventoryStockCnt = (double)dr[InventInputResult.ct_Col_InventoryStockCnt];
            }
            //棚卸過不足数
            writeWork.InventoryTolerancCnt = (double)dr[InventInputResult.ct_Col_InventoryTolerancCntBf];   //ADD 2009/05/14 不具合対応[13260]
            // 棚卸日
            if (dr[InventInputResult.ct_Col_InventoryExeDay_Datetime] == DBNull.Value)
            {
                writeWork.InventoryDate = DateTime.MinValue;
            }
            else
            {
                writeWork.InventoryDate = (DateTime)dr[InventInputResult.ct_Col_InventoryExeDay_Datetime];
            }
            // 棚卸準備処理日付
            writeWork.InventoryPreprDay = (DateTime)dr[InventInputResult.ct_Col_InventoryPreprDay_Datetime];
            // 棚卸準備処理時間
            writeWork.InventoryPreprTim = (int)dr[InventInputResult.ct_Col_InventoryPreprTim];
            // 棚卸実施日
            if (dr[InventInputResult.ct_Col_InventoryDay_Datetime] == DBNull.Value)
            {
                writeWork.InventoryDay = DateTime.MinValue;
            }
            else
            {
                writeWork.InventoryDay = (DateTime)dr[InventInputResult.ct_Col_InventoryDay_Datetime];
            }
            // 最終棚卸更新日
            //writeWork.LastInventoryUpdate = (DateTime)dr[InventInputResult.ct_Col_LastInventoryUpdate];   //DEL 2009/05/14 不具合対応[13260]
            writeWork.LastInventoryUpdate = DateTime.Today;                                                 //ADD 2009/05/14 不具合対応[13260]
            // 棚卸新規追加区分
            writeWork.InventoryNewDiv = (int)dr[InventInputResult.ct_Col_InventoryNewDiv];
            // 新規区分名称
            dr[InventInputResult.ct_Col_InventoryNewDivName] = InventoryNewDivName((int)dr[InventInputResult.ct_Col_InventoryNewDiv]);
            // ---ADD 2009/05/14 不具合対応[13260] ---------------------------------------------------->>>>>
            //マシン在庫額
            writeWork.StockMashinePrice = (Int64)dr[InventInputResult.ct_Col_StockMashinePrice];
            //棚卸在庫額    
            //writeWork.InventoryStockPrice = (Int64)dr[InventInputResult.ct_Col_InventoryStockPrice]; // DEL 2014/12/11 xuyb FOR Redmine#40336 #70障害の対応
            writeWork.InventoryStockPrice = this.GetTotalPriceToLong(writeWork.InventoryStockCnt, writeWork.StockUnitPriceFl); // ADD 2014/12/11 xuyb FOR Redmine#40336 #70障害の対応
            //棚卸過不足金額
            writeWork.InventoryTlrncPrice = (Int64)dr[InventInputResult.ct_Col_InventoryTlrncPrice];
            //在庫総数(実施日)
            writeWork.StockTotalExec = (double)dr[InventInputResult.ct_Col_StockTotalExec];
            //過不足更新区分
            writeWork.ToleranceUpdateCd = (int)dr[InventInputResult.ct_Col_ToleranceUpdateCd];
            //調整用計算原価
            writeWork.AdjstCalcCost = (double)dr[InventInputResult.ct_Col_AdjustCalcCost];
            // ---ADD 2009/05/14 不具合対応[13260] ---------------------------------------------------->>>>>

            return writeWork;
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// 更新クラス作成処理
		/// </summary>
		/// <param name="dr"></param>
		/// <returns></returns>
        /// <remarks>
        /// <br>Note		: 書き込み用ArrayList作成</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.04.19</br>
        /// </remarks>
		public InventoryDataUpdateWork MakeWriteClass( DataRow dr )
		{
			InventoryDataUpdateWork writeWork = new InventoryDataUpdateWork();

			// 作成日時
			writeWork.CreateDateTime = (DateTime)dr[InventInputResult.ct_Col_CreateDateTime];
			// 更新日時
			writeWork.UpdateDateTime = (DateTime)dr[InventInputResult.ct_Col_UpdateDateTime];
			// 企業コード
			writeWork.EnterpriseCode = dr[InventInputResult.ct_Col_EnterpriseCode].ToString();
			// GUID
			writeWork.FileHeaderGuid = (Guid)dr[InventInputResult.ct_Col_FileHeaderGuid];
			// 更新従業員コード
			writeWork.UpdEmployeeCode = dr[InventInputResult.ct_Col_UpdEmployeeCode].ToString();
			// 更新アセンブリID1
			writeWork.UpdAssemblyId1 = dr[InventInputResult.ct_Col_UpdAssemblyId1].ToString();
			// 更新アセンブリID2
			writeWork.UpdAssemblyId2 = dr[InventInputResult.ct_Col_UpdAssemblyId2].ToString();
			// 論理削除区分
			writeWork.LogicalDeleteCode = (int)dr[InventInputResult.ct_Col_LogicalDeleteCode];
			// 拠点コード
			writeWork.SectionCode = dr[InventInputResult.ct_Col_SectionCode].ToString();
			// 拠点ガイド名称
//			writeWork.SectionGuideNm = dr[InventInputResult.ct_Col_SectionGuideNm].ToString();
			// 棚卸通番
			writeWork.InventorySeqNo = (int)dr[InventInputResult.ct_Col_InventorySeqNo];
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 製番在庫マスタGUID
			//writeWork.ProductStockGuid = (Guid)dr[InventInputResult.ct_Col_ProductStockGuid];
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            // 倉庫コード
			writeWork.WarehouseCode = dr[InventInputResult.ct_Col_WarehouseCode].ToString();
			// 倉庫名称
			writeWork.WarehouseName = dr[InventInputResult.ct_Col_WarehouseName].ToString();
			// メーカーコード
			writeWork.GoodsMakerCd = (int)dr[InventInputResult.ct_Col_MakerCode];
			// メーカー名称
			writeWork.MakerName = dr[InventInputResult.ct_Col_MakerName].ToString();
			// 品番
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //writeWork.GoodsCode = dr[InventInputResult.ct_Col_GoodsCode].ToString();
            writeWork.GoodsNo = dr[InventInputResult.ct_Col_GoodsNo].ToString();
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
            // 品名
			writeWork.GoodsName = dr[InventInputResult.ct_Col_GoodsName].ToString();
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //// 機種コード
            //writeWork.CellphoneModelCode = dr[InventInputResult.ct_Col_CellphoneModelCode].ToString();
            //// 機種名称
            //writeWork.CellphoneModelName = dr[InventInputResult.ct_Col_CellphoneModelName].ToString();
            //// キャリアコード
            //writeWork.CarrierCode = (int)dr[InventInputResult.ct_Col_CarrierCode];
            //// キャリア名称
            //writeWork.CarrierName = dr[InventInputResult.ct_Col_CarrierName].ToString();
            //// 系統色コード
            //writeWork.SystematicColorCd = (int)dr[InventInputResult.ct_Col_SystematicColorCd];
            //// 系統色名称
            //writeWork.SystematicColorNm = dr[InventInputResult.ct_Col_SystematicColorNm].ToString();
            // 棚番
            writeWork.WarehouseShelfNo = dr[InventInputResult.ct_Col_WarehouseShelfNo].ToString();
            // 重複棚番１
            writeWork.DuplicationShelfNo1 = dr[InventInputResult.ct_Col_DuplicationShelfNo1].ToString();
            // 重複棚番２
            writeWork.DuplicationShelfNo2 = dr[InventInputResult.ct_Col_DuplicationShelfNo2].ToString();
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
            // 商品大分類コード
			writeWork.LargeGoodsGanreCode = dr[InventInputResult.ct_Col_LargeGoodsGanreCode].ToString();
			// 商品大分類名称
			writeWork.LargeGoodsGanreName = dr[InventInputResult.ct_Col_LargeGoodsGanreName].ToString();
			// 商品中分類コード
			writeWork.MediumGoodsGanreCode = dr[InventInputResult.ct_Col_MediumGoodsGanreCode].ToString();
			// 商品中分類名称
			writeWork.MediumGoodsGanreName = dr[InventInputResult.ct_Col_MediumGoodsGanreName].ToString();
            // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
            //// 事業者コード
            //writeWork.CarrierEpCode = (int)dr[InventInputResult.ct_Col_CarrierEpCode];
            //// 事業者名称
            //writeWork.CarrierEpName = dr[InventInputResult.ct_Col_CarrierEpName].ToString();
            // グループコード
            writeWork.DetailGoodsGanreCode = dr[InventInputResult.ct_Col_DetailGoodsGanreCode].ToString();
            // グループコード名称
            writeWork.DetailGoodsGanreName = dr[InventInputResult.ct_Col_DetailGoodsGanreName].ToString();
            // 自社分類コード
            writeWork.EnterpriseGanreCode = (int)dr[InventInputResult.ct_Col_EnterpriseGanreCode];
            // 自社分類名称
            writeWork.EnterpriseGanreName = dr[InventInputResult.ct_Col_EnterpriseGanreName].ToString();
            // ＢＬ品番
            writeWork.BLGoodsCode = (int)dr[InventInputResult.ct_Col_BLGoodsCode];
            // ＢＬ品名
//            writeWork.BLGoodsName = dr[InventInputResult.ct_Col_BLGoodsName].ToString();
            // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<
            // 得意先コード
			writeWork.CustomerCode = (int)dr[InventInputResult.ct_Col_CustomerCode];
			// 得意先名称
			writeWork.CustomerName = dr[InventInputResult.ct_Col_CustomerName].ToString();
			// 得意先名称2
			writeWork.CustomerName2 = dr[InventInputResult.ct_Col_CustomerName2].ToString();
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 仕入日
            //writeWork.StockDate = (DateTime)dr[InventInputResult.ct_Col_StockDate];
            //// 入荷日
            //writeWork.ArrivalGoodsDay = (DateTime)dr[InventInputResult.ct_Col_ArrivalGoodsDay];
            //// 製造番号
            //writeWork.ProductNumber = dr[InventInputResult.ct_Col_ProductNumber].ToString().TrimEnd();
            //// 商品電話番号1
            //writeWork.StockTelNo1 = dr[InventInputResult.ct_Col_StockTelNo1].ToString().TrimEnd();
            //// 変更前商品電話番号1
            //writeWork.BfStockTelNo1 = dr[InventInputResult.ct_Col_BfStockTelNo1].ToString().TrimEnd();
            //// 商品電話番号1変更フラグ
            //writeWork.StkTelNo1ChgFlg = (int)dr[InventInputResult.ct_Col_StkTelNo1ChgFlg];
            //// 商品電話番号2
            //writeWork.StockTelNo2 = dr[InventInputResult.ct_Col_StockTelNo2].ToString().TrimEnd();
            //// 変更前商品電話番号2
            //writeWork.BfStockTelNo2 = dr[InventInputResult.ct_Col_BfStockTelNo2].ToString().TrimEnd();
			//// 商品電話番号2変更フラグ
			//writeWork.StkTelNo2ChgFlg = (int)dr[InventInputResult.ct_Col_StkTelNo2ChgFlg];
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            // JANコード
			writeWork.Jan = dr[InventInputResult.ct_Col_Jan].ToString();
            // 2008.02.14 修正 >>>>>>>>>>>>>>>>>>>>
            //// 仕入単価
            //writeWork.StockUnitPriceFl = (long)dr[InventInputResult.ct_Col_StockUnitPrice];
            //// 変更前仕入単価
            //writeWork.BfStockUnitPriceFl = (long)dr[InventInputResult.ct_Col_BfStockUnitPrice];
            // 仕入単価
            writeWork.StockUnitPriceFl   = (double)dr[InventInputResult.ct_Col_StockUnitPrice];
            // 変更前仕入単価
			writeWork.BfStockUnitPriceFl = (double)dr[InventInputResult.ct_Col_BfStockUnitPrice];
            // 2008.02.14 修正 <<<<<<<<<<<<<<<<<<<<
            // 仕入単価変更フラグ
			writeWork.StkUnitPriceChgFlg = (int)dr[InventInputResult.ct_Col_StkUnitPriceChgFlg];
			// 在庫区分
			writeWork.StockDiv = (int)dr[InventInputResult.ct_Col_StockDiv];
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 在庫状態
            //writeWork.StockState = (int)dr[InventInputResult.ct_Col_StockState];
            //// 移動状態
            //writeWork.MoveStatus = (int)dr[InventInputResult.ct_Col_MoveStatus];
            //// 商品状態
            //writeWork.GoodsCodeStatus = (int)dr[InventInputResult.ct_Col_GoodsCodeStatus];
            //// 製番管理区分
            //writeWork.PrdNumMngDiv = (int)dr[InventInputResult.ct_Col_PrdNumMngDiv];
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            // 最終仕入年月日
			writeWork.LastStockDate = (DateTime)dr[InventInputResult.ct_Col_LastStockDate];
			// 在庫数
			writeWork.StockTotal = (double)dr[InventInputResult.ct_Col_StockTotal];
			// 出荷先得意先コード
			writeWork.ShipCustomerCode = (int)dr[InventInputResult.ct_Col_ShipCustomerCode];
			// 出荷先得意先名称
			writeWork.ShipCustomerName = dr[InventInputResult.ct_Col_ShipCustomerName].ToString();
			// 出荷先得意先名称2
			writeWork.ShipCustomerName2 = dr[InventInputResult.ct_Col_ShipCustomerName2].ToString();
			// 棚卸在庫数
			if ( dr[InventInputResult.ct_Col_InventoryStockCnt] == DBNull.Value )
				writeWork.InventoryStockCnt = 0;
			else
				writeWork.InventoryStockCnt = (double)dr[InventInputResult.ct_Col_InventoryStockCnt];
			// 差異数
			if ( dr[InventInputResult.ct_Col_InventoryTolerancCnt] == DBNull.Value )
				writeWork.InventoryTolerancCnt = 0;
			else
				writeWork.InventoryTolerancCnt = (double)dr[InventInputResult.ct_Col_InventoryTolerancCnt];

            // 2008.02.14 追加 >>>>>>>>>>>>>>>>>>>>
            // 棚卸日
            if (dr[InventInputResult.ct_Col_InventoryExeDay_Datetime] == DBNull.Value)
                writeWork.InventoryDate = DateTime.MinValue;
            else
                writeWork.InventoryDate = (DateTime)dr[InventInputResult.ct_Col_InventoryExeDay_Datetime];
            // 2008.02.14 追加 <<<<<<<<<<<<<<<<<<<<

            // 棚卸準備処理日付
			writeWork.InventoryPreprDay = (DateTime)dr[InventInputResult.ct_Col_InventoryPreprDay_Datetime];
			// 棚卸準備処理時間
			writeWork.InventoryPreprTim = (int)dr[InventInputResult.ct_Col_InventoryPreprTim];

			// 棚卸実施日
			if ( dr[InventInputResult.ct_Col_InventoryDay_Datetime] == DBNull.Value )
				writeWork.InventoryDay = DateTime.MinValue;
			else
				writeWork.InventoryDay = (DateTime)dr[InventInputResult.ct_Col_InventoryDay_Datetime];

			// 棚卸更新日
			writeWork.LastInventoryUpdate = (DateTime)dr[InventInputResult.ct_Col_LastInventoryUpdate];
			// 棚卸新規追加区分
			writeWork.InventoryNewDiv = (int)dr[InventInputResult.ct_Col_InventoryNewDiv];
			// 新規区分名称
			dr[InventInputResult.ct_Col_InventoryNewDivName] = InventoryNewDivName( (int)dr[InventInputResult.ct_Col_InventoryNewDiv] );


			return writeWork;
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        #endregion

        #region ◆ 更新後処理

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
		/// 更新後処理
		/// </summary>
		/// <param name="afterWriteList">更新結果リスト</param>
		private void AfterWriteInvent( ArrayList afterWriteList )
		{
			// リモートで更新した後に帰ってくるのは次のパターンのいずれかの行
			//		・更新した行(更新日付が変更されている)
			// 　 ・更新でエラーが発生した行(ステータスがゼロ以外)
			//    ・新規に追加した行(新規で、ステータスはゼロ。ヘッダ項目が更新されている)
			//    ・削除した行(新規でステータスはゼロ。論理削除区分が3。ローカルテーブルから削除する)

			// 戻りがない場合は終了
			if ( afterWriteList.Count == 0 )
			{
				return;
			}
			// 削除行リスト
			ArrayList delRowList = new ArrayList();

			// DataView updateDv; // 2007.07.20 kubo del
			DataRow targetRow;
			// データの更新
			foreach ( InventoryDataUpdateWork updateWork in afterWriteList )
			{
				// GetData3は新規登録済みデータの時しか入らない
				#region // 2007.07.19 kubo del
				//// Rowを取得してテーブルから削除
				//updateDv = new DataView( 
				//    _sta_InventDataTable, 
				//    string.Format( "{0}='{1}'",InventInputResult.ct_Col_ProductStockGuid, updateWork.ProductStockGuid ),
				//    "",
				//    DataViewRowState.CurrentRows );
				//if ( updateDv.Count > 0 )
				//{
				//    // Guidで指定しているからCountは1にしかならない。
				//    targetRow = updateDv[0].Row;
				//}
				//else
				//{
				//    continue;
				//}
				#endregion
				// 2007.07.19 kubo add -------------------------->
                // 2007.09.11 修正 >>>>>>>>>>>>>>>>>>>>
                //object[] keyObjects = GetPrimaryKeyList( 
				//	updateWork, 
				//	updateWork.ProductNumber, 
				//	(int)InventInputSearchCndtn.GrossDivState.Product, 
				//	updateWork.ProductStockGuid );
                object[] keyObjects = GetPrimaryKeyList(
                    updateWork,
                    "",
                    (int)InventInputSearchCndtn.GrossDivState.Product,
                    Guid.Empty);
                // 2007.09.11 修正 <<<<<<<<<<<<<<<<<<<<

				// 取得
				targetRow = _sta_InventDataTable.Rows.Find( keyObjects );	// 指定キーで取得
				if ( targetRow == null )
				{
					// 行が無い場合は新規に行を作成
					continue;
				}
				// 2007.07.19 kubo add <--------------------------


				// ステータス == ctDB_NORMAL
				// 論理削除区分を見る
				if ( updateWork.LogicalDeleteCode == (int)ConstantManagement.LogicalMode.GetData0 )
				{
					// ステータスを判断
					if ( updateWork.Status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
					{
						// ヘッダの更新
						// 作成日時
						targetRow[InventInputResult.ct_Col_CreateDateTime] = updateWork.CreateDateTime;
						// 更新日時
						targetRow[InventInputResult.ct_Col_UpdateDateTime] = updateWork.UpdateDateTime;
						// 企業コード
						targetRow[InventInputResult.ct_Col_EnterpriseCode] = updateWork.EnterpriseCode;
						// GUID
						targetRow[InventInputResult.ct_Col_FileHeaderGuid] = updateWork.FileHeaderGuid;
						// 更新従業員コード
						targetRow[InventInputResult.ct_Col_UpdEmployeeCode] = updateWork.UpdEmployeeCode;
						// 更新アセンブリID1
						targetRow[InventInputResult.ct_Col_UpdAssemblyId1] = updateWork.UpdAssemblyId1;
						// 更新アセンブリID2
						targetRow[InventInputResult.ct_Col_UpdAssemblyId2] = updateWork.UpdAssemblyId2;
						// 論理削除区分
						targetRow[InventInputResult.ct_Col_LogicalDeleteCode] = updateWork.LogicalDeleteCode;
						// 変更区分
						targetRow[InventInputResult.ct_Col_ChangeDiv] = 0;
					}

					// Rowを取得してステータスの更新
					targetRow[InventInputResult.ct_Col_Status] = updateWork.Status;
					targetRow[InventInputResult.ct_Col_StatusDetail] = GetStatusDetail( updateWork.Status );

					// ステータス異常なら親行に反映
					if ( updateWork.Status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
					{
						#region // 2007.07.24 kubo del
						//// 製番管理データの製番無し分グロスデータ作成
						//if ( updateWork.PrdNumMngDiv == (int)InventInputSearchCndtn.PrdNumMngDivState.Product )
						//{
						//    SetParentRowStatus( ref _sta_InventDataTable, updateWork, true );
						//}
						#endregion
						// グロスデータ作成
						SetParentRowStatus( ref _sta_InventDataTable, updateWork, false );

					}
				}
				else
				{
					// Rowを指定して削除
					_sta_InventDataTable.Rows.Remove(targetRow);
				}
			}

			// 親行削除
			RemoveNewParentRow( true, System.Windows.Forms.DialogResult.Yes );
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// 更新後処理
        /// </summary>
        /// <param name="afterWriteList">更新結果リスト</param>
        private void AfterWriteInvent(ArrayList afterWriteList)
        {
            // リモートで更新した後に帰ってくるのは次のパターンのいずれかの行
            //		・更新した行(更新日付が変更されている)
            // 　 ・更新でエラーが発生した行(ステータスがゼロ以外)
            //    ・新規に追加した行(新規で、ステータスはゼロ。ヘッダ項目が更新されている)
            //    ・削除した行(新規でステータスはゼロ。論理削除区分が3。ローカルテーブルから削除する)

            // 戻りがない場合は終了
            if (afterWriteList.Count == 0)
            {
                return;
            }
            // 削除行リスト
            ArrayList delRowList = new ArrayList();

            DataRow targetRow;
            // データの更新
            foreach (InventoryDataUpdateWork updateWork in afterWriteList)
            {
                object[] keyObjects = GetPrimaryKeyList(
                    updateWork,
                    "",
                    (int)InventInputSearchCndtn.GrossDivState.Product,
                    Guid.Empty);

                // 取得
                targetRow = _sta_InventDataTable.Rows.Find(keyObjects);	// 指定キーで取得
                if (targetRow == null)
                {
                    // 行が無い場合は新規に行を作成
                    continue;
                }

                int index = _inventoryDataUpdateWorkList.FindIndex(delegate(InventoryDataUpdateWork target)
                {
                    if ((target.SectionCode.Trim() == updateWork.SectionCode.Trim()) &&
                        (target.WarehouseCode.Trim() == updateWork.WarehouseCode.Trim()) &&
                        (target.GoodsMakerCd == updateWork.GoodsMakerCd) &&
                        (target.GoodsNo.Trim() == updateWork.GoodsNo.Trim()))
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                });

                if (index >= 0)
                {

                    _inventoryDataUpdateWorkList[index].CreateDateTime = updateWork.CreateDateTime;
                    _inventoryDataUpdateWorkList[index].UpdateDateTime = updateWork.UpdateDateTime;
                    _inventoryDataUpdateWorkList[index].FileHeaderGuid = updateWork.FileHeaderGuid;
                    _inventoryDataUpdateWorkList[index].UpdEmployeeCode = updateWork.UpdEmployeeCode;
                    _inventoryDataUpdateWorkList[index].UpdAssemblyId1 = updateWork.UpdAssemblyId1;
                    _inventoryDataUpdateWorkList[index].UpdAssemblyId2 = updateWork.UpdAssemblyId2;
                    _inventoryDataUpdateWorkList[index].LogicalDeleteCode = updateWork.LogicalDeleteCode;
                    _inventoryDataUpdateWorkList[index].EnterpriseCode = updateWork.EnterpriseCode;
                }

                // 論理削除区分を見る
                if (updateWork.LogicalDeleteCode == (int)ConstantManagement.LogicalMode.GetData0)
                {
                    // ステータスを判断
                    if (updateWork.Status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // ヘッダの更新
                        // 作成日時
                        targetRow[InventInputResult.ct_Col_CreateDateTime] = updateWork.CreateDateTime;
                        // 更新日時
                        targetRow[InventInputResult.ct_Col_UpdateDateTime] = updateWork.UpdateDateTime;
                        // 企業コード
                        targetRow[InventInputResult.ct_Col_EnterpriseCode] = updateWork.EnterpriseCode;
                        // GUID
                        targetRow[InventInputResult.ct_Col_FileHeaderGuid] = updateWork.FileHeaderGuid;
                        // 更新従業員コード
                        targetRow[InventInputResult.ct_Col_UpdEmployeeCode] = updateWork.UpdEmployeeCode;
                        // 更新アセンブリID1
                        targetRow[InventInputResult.ct_Col_UpdAssemblyId1] = updateWork.UpdAssemblyId1;
                        // 更新アセンブリID2
                        targetRow[InventInputResult.ct_Col_UpdAssemblyId2] = updateWork.UpdAssemblyId2;
                        // 論理削除区分
                        targetRow[InventInputResult.ct_Col_LogicalDeleteCode] = updateWork.LogicalDeleteCode;
                        // 変更区分
                        targetRow[InventInputResult.ct_Col_ChangeDiv] = 0;
                    }

                    // Rowを取得してステータスの更新
                    targetRow[InventInputResult.ct_Col_Status] = updateWork.Status;
                    targetRow[InventInputResult.ct_Col_StatusDetail] = GetStatusDetail(updateWork.Status);

                    // ステータス異常なら親行に反映
                    if (updateWork.Status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // グロスデータ作成
                        SetParentRowStatus(ref _sta_InventDataTable, updateWork, false);
                    }
                }
                else
                {
                    //// Rowを指定して削除
                    //_sta_InventDataTable.Rows.Remove(targetRow);
                }
            }

            //// 親行削除
            //RemoveNewParentRow(true, DialogResult.Yes);
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<
        #endregion

		#region ◆ ステータス反映処理

        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// ステータス反映処理
		/// </summary>
		/// <param name="searchResultTable"></param>
		/// <param name="retWork"></param>
		/// <param name="isView"></param>
		private void SetParentRowStatus( ref DataTable searchResultTable, InventoryDataUpdateWork retWork, bool isView )
		{
            int grossDiv = (int)InventInputSearchCndtn.GrossDivState.Product;
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //if ( isView )
            //{
            //	if ( retWork.ProductNumber.CompareTo("") != 0 )
            //	{
            //		// 製番が入っている場合はグロスデータを作らない
            //		return;
            //	}
            //	grossDiv = (int)InventInputSearchCndtn.GrossDivState.Product;
            //}
            //else
            //{
            //	grossDiv = (int)InventInputSearchCndtn.GrossDivState.Goods;
            //}
            grossDiv = (int)InventInputSearchCndtn.GrossDivState.Goods;
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            DataRow dr;
			#region // 2007.07.19 kubo del -------------------------->
			// グロス行があるかどうかの確認
			//if ( !searchResultTable.Rows.Contains( MakeKey( retWork, isView, grossDiv ) ) )
			//{
			//    return;
			//}
			//else
			//{
			//    // グロス行が有る場合は取得
			//    dr = searchResultTable.Rows.Find( MakeKey( retWork, isView, grossDiv ) );	// 指定キーで取得
			//}
			#endregion // 2007.07.19 kubo del <--------------------------

			// TODO
			// 2007.07.19 kubo add -------------------------->
			// グロス行が有る場合は取得
			dr = searchResultTable.Rows.Find( GetPrimaryKeyList( retWork, "", grossDiv, Guid.Empty ) );	// 指定キーで取得
			if ( dr == null )
			{
				// グロス行が無い場合は新規に行を作成
				dr = searchResultTable.NewRow();
			}
			// 2007.07.19 kubo add <--------------------------

			// エラーステータス
			if ( retWork.Status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
			{
				// リストのステータスが正常の場合
				if ( (int)dr[InventInputResult.ct_Col_Status] == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
				{
					dr[InventInputResult.ct_Col_Status] = (int)ConstantManagement.DB_Status.ctDB_WARNING;
					dr[InventInputResult.ct_Col_StatusDetail] = GetStatusDetail( (int)ConstantManagement.DB_Status.ctDB_WARNING );
				}
			}
		}
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ステータス反映処理
        /// </summary>
        /// <param name="searchResultTable"></param>
        /// <param name="retWork"></param>
        /// <param name="isView"></param>
        private void SetParentRowStatus(ref DataTable searchResultTable, InventoryDataUpdateWork retWork, bool isView)
        {
            int grossDiv = (int)InventInputSearchCndtn.GrossDivState.Product;

            grossDiv = (int)InventInputSearchCndtn.GrossDivState.Goods;

            // グロス行が有る場合は取得
            DataRow dr = searchResultTable.Rows.Find(GetPrimaryKeyList(retWork, "", grossDiv, Guid.Empty));	// 指定キーで取得
            if (dr == null)
            {
                // グロス行が無い場合は新規に行を作成
                dr = searchResultTable.NewRow();
            }

            // エラーステータス
            if (retWork.Status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // リストのステータスが正常の場合
                if ((int)dr[InventInputResult.ct_Col_Status] == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    dr[InventInputResult.ct_Col_Status] = (int)ConstantManagement.DB_Status.ctDB_WARNING;
                    dr[InventInputResult.ct_Col_StatusDetail] = GetStatusDetail((int)ConstantManagement.DB_Status.ctDB_WARNING);
                }
            }
        }
        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<
        #endregion

		#region ◆ 親行削除処理
		/// <summary>
		/// 親行削除処理
		/// </summary>
		/// <param name="isMessage"></param>
		/// <param name="iniRes">DiarogResult初期値</param>
		private void RemoveNewParentRow( bool isMessage, DialogResult iniRes)
		{
			bool isShowMessage = false;
			DialogResult delRes = iniRes;

			// 削除する親データの取得
			// 新規フラグが立っていて在庫数がゼロ、棚卸日が無いものはテーブルから削除
			// この時点で製版単位データは削除されている
			//string strFilter = string.Format( "{0}=0", InventInputResult.ct_Col_StockTotal, (int)InventInputSearchCndtn.NewRowState.New );
			string strFilter = string.Format( "{0}=0", InventInputResult.ct_Col_StockTotal );
			DataView delView = new DataView( _sta_InventDataTable, strFilter, "", DataViewRowState.CurrentRows );
			ArrayList delRowList = new ArrayList();

			for ( int viewIndex = 0; viewIndex < delView.Count; viewIndex++ )
			{
			    // 帳簿数がゼロで棚卸日も未入力か？
				if ( (	delView[viewIndex][InventInputResult.ct_Col_InventoryStockCnt] == DBNull.Value || 
						(double)delView[viewIndex][InventInputResult.ct_Col_InventoryStockCnt] == 0 ) 
					&&
					 (	delView[viewIndex][InventInputResult.ct_Col_InventoryDay_Datetime] == DBNull.Value || 
						(DateTime)delView[viewIndex][InventInputResult.ct_Col_InventoryDay_Datetime] == DateTime.MinValue ))
				{
			        // 新規行で、作成日未入力(棚マスタに登録前)で、棚卸数がゼロのデータは更新対象外
                    //delRowList.Add(delView[viewIndex].Row);
			    }
				// 2007.07.30 kubo add ----------->
				else
				if ( ( delView[viewIndex][InventInputResult.ct_Col_InventoryStockCnt] == DBNull.Value ||
				       (double)delView[viewIndex][InventInputResult.ct_Col_InventoryStockCnt] == 0
					 )
					 &&
				     ( delView[viewIndex][InventInputResult.ct_Col_InventoryTolerancCnt] == DBNull.Value ||
					   (double)delView[viewIndex][InventInputResult.ct_Col_InventoryTolerancCnt] == 0
					 )
				   )
				{
					// メッセージ表示区分:表示, 削除Viewがゼロ件より多く、メッセージ未表示ならメッセージ表示
					if ( isMessage && delView.Count > 0 && !isShowMessage )
					{
						delRes = TMsgDisp.Show( 
							emErrorLevel.ERR_LEVEL_INFO, 
							"MAZAI05132A",
							"新規登録で棚卸数ゼロの商品毎データも削除しますか？",
							0,
							MessageBoxButtons.YesNo,
							MessageBoxDefaultButton.Button1);
						isShowMessage = true;
					}

			        // 新規行で、削除確認メッセージで「はい」にして棚卸数がゼロ、差異数がゼロの行は削除
					if ( delRes == DialogResult.Yes )
				        delRowList.Add( delView[viewIndex].Row );
				}
				// 2007.07.30 kubo add <-----------
			}
			// 更新対象外の行を削除
			if ( delRowList.Count != 0 )
			{
			    foreach( DataRow delRow in delRowList )
			    {
			        _sta_InventDataTable.Rows.Remove( delRow );
			    }
			}
		}
		#endregion

		#region ◆ 新規行作成処理
		/// <summary>
		/// 新規行作成処理
		/// </summary>
		/// <param name="parentRow">コピー元行</param>
		/// <param name="childRow">新規行</param>
		/// <param name="isView">製番管理区分</param>
		/// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		: データコピーを行う</br>
        /// <br>			: 固定項目(通番=0, </br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.04.10</br>
        /// </remarks>
		public void CopyRowToRow( DataRow parentRow, ref DataRow childRow, bool isView )
		{
			Guid productStockGuid = Guid.NewGuid();
			int changeDiv = (int)InventInputSearchCndtn.ChangeFlagState.Change;
			InventoryDataUpdateWork inventoryDataUpdateWork = MakeWriteClass( parentRow );
			DevSearchResultProc( inventoryDataUpdateWork, childRow, isView, changeDiv);

			// 新規データなので変更するところは変更
			// 作成日時
			childRow[InventInputResult.ct_Col_CreateDateTime] = DateTime.MinValue;
			// 更新日時
			childRow[InventInputResult.ct_Col_UpdateDateTime] = DateTime.MinValue;
			// GUID
			childRow[InventInputResult.ct_Col_FileHeaderGuid] = Guid.NewGuid();
			// 更新従業員コード
			childRow[InventInputResult.ct_Col_UpdEmployeeCode] = "";
			// 更新アセンブリID1
			childRow[InventInputResult.ct_Col_UpdAssemblyId1] = "";
			// 更新アセンブリID2
			childRow[InventInputResult.ct_Col_UpdAssemblyId2] = "";
			// 論理削除区分
			childRow[InventInputResult.ct_Col_LogicalDeleteCode] = 0;
			// 棚卸通番
			childRow[InventInputResult.ct_Col_InventorySeqNo] = 0;
            // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
            //// 製番在庫マスタGUID
			//childRow[InventInputResult.ct_Col_ProductStockGuid] = productStockGuid;
			//// 製番
			//childRow[InventInputResult.ct_Col_ProductNumber] = "";
            // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
            // 在庫数
			childRow[InventInputResult.ct_Col_StockTotal] = 0;
			// 棚卸在庫数
			childRow[InventInputResult.ct_Col_InventoryStockCnt] = 1;
			// 差異数
			childRow[InventInputResult.ct_Col_InventoryTolerancCnt] = 1;
			// 変更前差異数
			childRow[InventInputResult.ct_Col_InventoryTolerancCnt] = 1;
			//// 仕入日
			//childRow[InventInputResult.ct_Col_StockDate] = DateTime.MinValue;
			//// 最終仕入日
			//childRow[InventInputResult.ct_Col_LastStockDate] = DateTime.MinValue;
			//// 入荷日
			//childRow[InventInputResult.ct_Col_ArrivalGoodsDay] = DateTime.MinValue;
			// 棚卸更新日
			childRow[InventInputResult.ct_Col_LastInventoryUpdate] = DateTime.MinValue;
			// 棚卸準備処理日付
            // --- CHG 2008/09/01 --------------------------------------------------------------------->>>>>
            //DevDate( 
            //    childRow, 
            //    DateTime.MinValue, 
            //    InventInputResult.ct_Col_InventoryPreprDay, 
            //    InventInputResult.ct_Col_InventoryPreprDay_Datetime, 
            //    InventInputResult.ct_Col_InventoryPreprDay_Year, 
            //    InventInputResult.ct_Col_InventoryPreprDay_Month, 
            //    InventInputResult.ct_Col_InventoryPreprDay_Day );
            childRow[InventInputResult.ct_Col_InventoryPreprDay_Datetime] = DateTime.MinValue;
            // --- CHG 2008/09/01 ---------------------------------------------------------------------<<<<<
            // 棚卸準備処理時間
			childRow[InventInputResult.ct_Col_InventoryPreprTim] = 0;
			// 棚卸新規追加区分
			childRow[InventInputResult.ct_Col_InventoryNewDiv] = (int)InventInputSearchCndtn.NewRowState.New;
			// 新規区分名称
			childRow[InventInputResult.ct_Col_InventoryNewDivName] = InventoryNewDivName( (int)childRow[InventInputResult.ct_Col_InventoryNewDiv] );
			// Key
			childRow[InventInputResult.ct_Col_key] = productStockGuid;
		}

		#region ◎ 新規区分名称取得
		/// <summary>
		/// 新規区分名称取得
		/// </summary>
		/// <param name="newDiv">新規区分</param>
		/// <returns>新規区分名称</returns>
		private string InventoryNewDivName(int newDiv)
		{
			string newDivName = "";
			switch ( newDiv )
			{
				case (int)InventInputSearchCndtn.NewRowState.Old:
					// 既存
					newDivName = "";
					break;
				case (int)InventInputSearchCndtn.NewRowState.New:
					newDivName = "新規";
					break;
				default:
					// 既存
					newDivName = "";
					break;
			}

			return newDivName;
		}
		#endregion
		#endregion

		#region ◆ ステータス内容取得
		/// <summary>
		/// ステータス内容取得
		/// </summary>
		/// <param name="status"></param>
		/// <returns></returns>
		private string GetStatusDetail( int status )
		{
			string statusDetail = "";

			switch ( status )
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:	// 正常
					statusDetail = "";
					break;
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:	// 重複
					statusDetail = "すでに登録されています";
					break;
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:	// 排他(更新済み)
					statusDetail = "他端末で更新されています";
					break;
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:	// 排他(削除済み)
					statusDetail = "他端末で削除されています";
					break;
				case (int)ConstantManagement.DB_Status.ctDB_ERROR:	// 例外
					statusDetail = "更新に失敗しました";
					break;
				case (int)ConstantManagement.DB_Status.ctDB_WARNING:	// 親行のエラーステータス
					statusDetail = "更新に失敗したデータがあります。";
					break;
				default:	// その他
					statusDetail = "更新に失敗しました";
					break;
			}

			return statusDetail;
		}
		#endregion

		#region ◆ データテーブルコピー処理
		/// <summary>
		/// データテーブルコピー処理
		/// </summary>
		/// <param name="defaultTable">コピー元テーブル</param>
		/// <param name="copyTable">コピー先テーブル</param>
        /// <br>Update Note: 2013/03/01 yangyi</br>
        /// <br>管理番号   : 10801804-00 2013/03/06配信分の緊急対応</br>
        /// <br>           : Redmine#34175 　棚卸業務のサーバー負荷軽減対策</br>
		private void CopyTableToTable( ref DataTable defaultTable, ref DataTable copyTable )
		{
			copyTable.Clear();

			// Rowのコピー
            copyTable.BeginLoadData();   //ADD yangyi 2013/03/01 Redmine#34175 
			foreach( DataRow defaultRow in defaultTable.Rows )
			{
				copyTable.ImportRow( defaultRow );
			}
            copyTable.EndLoadData();    //ADD yangyi 2013/03/01 Redmine#34175 

            // --- DEL yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
            //// Rowのカラムを自分自身に設定
            //foreach( DataRow copyRow in copyTable.Rows )
            //{
            //    copyRow[InventInputResult.ct_Col_RowSelf] = copyRow;
            //}
            // --- DEL yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<
		}
		#endregion

		// TODO
		#region GetPrimaryKeyList // 2007.07.19 kubo add
        
        #region DEL 2008/09/01 Partsman用に変更
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// GetPrimaryKeyList
		/// </summary>
		/// <param name="iduWork"></param>
		/// <param name="productCode"></param>
		/// <param name="grossDiv"></param>
		/// <param name="guid"></param>
		/// <returns></returns>
		public object[] GetPrimaryKeyList( InventoryDataUpdateWork iduWork, string productCode, int grossDiv, Guid guid )
		{
			// キー項目をリストに登録。
			object[] primaryKeyObjList = new object[]{
				iduWork.SectionCode,			// 拠点コード
				iduWork.WarehouseCode,			// 倉庫コード
				iduWork.GoodsMakerCd,			// メーカーコード
				iduWork.GoodsNo,				// 品番
                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
				//iduWork.CarrierEpCode,			// 事業者コード
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                //iduWork.CustomerCode,			// 得意先コード
				iduWork.ShipCustomerCode,		// 委託先コード
				iduWork.StockUnitPriceFl,		// 仕入単価
				iduWork.StockDiv,				// 在庫区分
                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
				//iduWork.StockState,				// 在庫状態
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
				//iduWork.InventoryNewDiv,		// 新規区分
                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
				//productCode,					// 製造番号
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
				grossDiv,						// グロス区分
                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
				//guid,							// 製番在庫GUID (グロスデータのGUIDはGuid.Empty
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
				};

			return primaryKeyObjList;
		}

		/// <summary>
		/// GetPrimaryKeyList
		/// </summary>
		/// <param name="dr"></param>
		/// <param name="productCode"></param>
		/// <param name="grossDiv"></param>
		/// <param name="guid"></param>
		/// <returns></returns>
		public object[] GetPrimaryKeyList( DataRow dr, string productCode, int grossDiv, Guid guid )
		{
			// キー項目をリストに登録。
			object[] primaryKeyObjList = new object[]{
				dr[InventInputResult.ct_Col_SectionCode],			// 拠点コード
				dr[InventInputResult.ct_Col_WarehouseCode],			// 倉庫コード
				dr[InventInputResult.ct_Col_MakerCode],				// メーカーコード
				dr[InventInputResult.ct_Col_GoodsNo],				// 品番
                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
				//dr[InventInputResult.ct_Col_CarrierEpCode],			// 事業者コード
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                dr[InventInputResult.ct_Col_CustomerCode],			// 得意先コード
				dr[InventInputResult.ct_Col_ShipCustomerCode],		// 委託先コード
				dr[InventInputResult.ct_Col_StockUnitPrice],		// 仕入単価
				dr[InventInputResult.ct_Col_StockDiv],				// 在庫区分
                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
			    //dr[InventInputResult.ct_Col_StockState],			// 在庫状態
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
				//dr[InventInputResult.ct_Col_InventoryNewDiv],		// 新規区分
                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
				//productCode,										// 製造番号
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
				grossDiv,											// グロス区分
                // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
				//guid,												// 製番在庫GUID (グロスデータのGUIDはGuid.Empty
                // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
				};

			return primaryKeyObjList;
        }
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 Partsman用に変更

        // --- ADD 2008/09/01 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// GetPrimaryKeyList
        /// </summary>
        /// <param name="iduWork"></param>
        /// <param name="productCode"></param>
        /// <param name="grossDiv"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        public object[] GetPrimaryKeyList(InventoryDataUpdateWork iduWork, string productCode, int grossDiv, Guid guid)
        {
            // キー項目をリストに登録。
            object[] primaryKeyObjList = new object[]{
				iduWork.SectionCode,			// 拠点コード
				iduWork.WarehouseCode,			// 倉庫コード
				iduWork.GoodsMakerCd,			// メーカーコード
				iduWork.GoodsNo,				// 品番
                iduWork.SupplierCd,             // 仕入先コード
				iduWork.ShipCustomerCode,		// 委託先コード
				iduWork.StockUnitPriceFl,		// 仕入単価
				iduWork.StockDiv,				// 在庫区分
				grossDiv,						// グロス区分
                iduWork.WarehouseShelfNo,       // 棚番 ADD 2009/09/11
				};

            return primaryKeyObjList;
        }

        /// <summary>
        /// GetPrimaryKeyList
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="productCode"></param>
        /// <param name="grossDiv"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        public object[] GetPrimaryKeyList(DataRow dr, string productCode, int grossDiv, Guid guid)
        {
            // キー項目をリストに登録。
            object[] primaryKeyObjList = new object[]{
				dr[InventInputResult.ct_Col_SectionCode],			// 拠点コード
				dr[InventInputResult.ct_Col_WarehouseCode],			// 倉庫コード
				dr[InventInputResult.ct_Col_MakerCode],				// メーカーコード
				dr[InventInputResult.ct_Col_GoodsNo],				// 品番
				dr[InventInputResult.ct_Col_SupplierCode],			// 得意先コード
				dr[InventInputResult.ct_Col_ShipCustomerCode],		// 委託先コード
				dr[InventInputResult.ct_Col_StockUnitPrice],		// 仕入単価
				dr[InventInputResult.ct_Col_StockDiv],				// 在庫区分
				grossDiv,											// グロス区分
                dr[InventInputResult.ct_Col_WarehouseShelfNo],      // 棚番 ADD 2009/09/11
				};

            return primaryKeyObjList;
        }

        // --- ADD yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
        /// <summary>
        /// GetPrimaryKeyList2
        /// </summary>
        /// <param name="iduWork"></param>
        /// <param name="productCode"></param>
        /// <param name="grossDiv"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        public string GetPrimaryKeyList2(InventoryDataUpdateWork iduWork, int grossDiv)
        {
            string str = "";
            // キー項目をstringに登録。
            str = iduWork.SectionCode + "," +			            // 拠点コード
				  iduWork.WarehouseCode+","+			            // 倉庫コード
				  iduWork.GoodsMakerCd.ToString()+","+			    // メーカーコード
				  iduWork.GoodsNo+","+				                // 品番
                  iduWork.SupplierCd.ToString() + "," +             // 仕入先コード
                  iduWork.ShipCustomerCode.ToString() + "," +		// 委託先コード
                  iduWork.StockUnitPriceFl.ToString() + "," +		// 仕入単価
                  iduWork.StockDiv.ToString() + "," +				// 在庫区分
                  grossDiv.ToString() + "," +						// グロス区分
                  iduWork.WarehouseShelfNo;                         // 棚番 

            return str;
        }
        // --- ADD yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<

        // --- ADD 2008/09/01 ---------------------------------------------------------------------<<<<<

        # region DEL 2008/09/01 使用していないのでコメントアウト
        ///// <summary>
        ///// GetPrimaryKeyList
        ///// </summary>
        ///// <param name="sectionCode"></param>
        ///// <param name="warehouseCode"></param>
        ///// <param name="makerCode"></param>
        ///// <param name="goodsNo"></param>
        ///// <param name="carrierEpCode"></param>
        ///// <param name="customerCode"></param>
        ///// <param name="shipCustomerCode"></param>
        ///// <param name="stockUnitPrice"></param>
        ///// <param name="stockDiv"></param>
        ///// <param name="stockState"></param>
        ///// <param name="productCode"></param>
        ///// <param name="grossDiv"></param>
        ///// <param name="guid"></param>
        ///// <returns></returns>
        //private object[] GetPrimaryKeyList( object sectionCode, object warehouseCode, object makerCode, object goodsNo,
        //    object carrierEpCode, object customerCode, object shipCustomerCode, object stockUnitPrice, object stockDiv,
        //    object stockState, /*object inventoryNewDiv,*/ string productCode, int grossDiv, Guid guid)
        //{
        //    // キー項目をリストに登録。
        //    object[] primaryKeyObjList = new object[]{
        //        sectionCode,			// 拠点コード
        //        warehouseCode,			// 倉庫コード
        //        makerCode,				// メーカーコード
        //        goodsNo,				// 品番
        //        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
        //        //carrierEpCode,			// 事業者コード
        //        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
        //        customerCode,			// 得意先コード
        //        shipCustomerCode,		// 委託先コード
        //        stockUnitPrice,			// 仕入単価
        //        stockDiv,				// 在庫区分
        //        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
        //        //stockState,				// 在庫状態
        //        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
        //        // inventoryNewDiv,		// 新規区分
        //        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
        //        //productCode,			// 製造番号
        //        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
        //        grossDiv,				// グロス区分
        //        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
        //        //guid,					// 製番在庫GUID (グロスデータのGUIDはGuid.Empty
        //        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
        //        };

        //    return primaryKeyObjList;
        //}
        #endregion DEL 2008/09/01 使用していないのでコメントアウト

        #endregion

        #region DEL 2008/09/01 使用していないのでコメントアウト
        /* --- DEL 2008/09/01 --------------------------------------------------------------------->>>>>
        #region DifCntExtraDelteProc
        /// <summary>
		/// DifCntExtraDelteProc
		/// </summary>
		/// <returns></returns>
        /// <remarks>
        /// <br>Note		: 差異数無データ削除処理</br>
        /// <br>Programmer	: 22013 久保 将太</br>
        /// <br>Date		: 2007.07.20</br>
        /// </remarks>
		private int DifCntExtraDelteProc(ref string errMsg)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
			try
			{
				// 差異数がゼロの商品データを取得
				string str_ParentFilter = string.Format("{0}={1} and {2}=0",
					InventInputResult.ct_Col_GrossDiv, (int)InventInputSearchCndtn.GrossDivState.Goods, InventInputResult.ct_Col_InventoryTolerancCnt);

				DataRow[] parentRows = _sta_InventDataTable_Buf.Select(str_ParentFilter);

				if ( parentRows == null ) return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;

				// 差異数がゼロの商品データと同じ品番等の製番データを削除する。
				DataRow[] childRows = null;
				string str_ChildFilter = "";
				bool isNotDelete = false;	// 削除フラグ true:削除しない、false削除する


				// 取得した親行から子行を取得して削除する
				foreach ( DataRow parentRow in parentRows )
				{
					str_ChildFilter = string.Format("{0}='{1}' and {2}='{3}' and {4}={5} and {6}='{7}' and {8}={9} and {10}={11} and {12}={13} and {14}={15} and {16}={17} and {18}={19} and {20}={21}",// and {22}={23}",
						InventInputResult.ct_Col_SectionCode		, parentRow[InventInputResult.ct_Col_SectionCode],			// 拠点コード
						InventInputResult.ct_Col_WarehouseCode		, parentRow[InventInputResult.ct_Col_WarehouseCode],		// 倉庫コード
						InventInputResult.ct_Col_MakerCode			, parentRow[InventInputResult.ct_Col_MakerCode],			// メーカーコード
                        InventInputResult.ct_Col_GoodsNo            , parentRow[InventInputResult.ct_Col_GoodsNo],				// 品番
                        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                        //InventInputResult.ct_Col_CarrierEpCode	, parentRow[InventInputResult.ct_Col_CarrierEpCode],			// 事業者コード
                        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                        InventInputResult.ct_Col_CustomerCode, parentRow[InventInputResult.ct_Col_CustomerCode],			// 得意先コード
						InventInputResult.ct_Col_ShipCustomerCode	, parentRow[InventInputResult.ct_Col_ShipCustomerCode],		// 委託先コード
						InventInputResult.ct_Col_StockUnitPrice		, parentRow[InventInputResult.ct_Col_StockUnitPrice],		// 仕入単価
						InventInputResult.ct_Col_StockDiv			, parentRow[InventInputResult.ct_Col_StockDiv],				// 在庫区分
                        // 2007.09.11 削除 >>>>>>>>>>>>>>>>>>>>
                        //InventInputResult.ct_Col_StockState       , parentRow[InventInputResult.ct_Col_StockState],			// 在庫状態
                        // 2007.09.11 削除 <<<<<<<<<<<<<<<<<<<<
                        //InventInputResult.ct_Col_InventoryNewDiv	, parentRow[InventInputResult.ct_Col_InventoryNewDiv],		// 新規区分
						InventInputResult.ct_Col_GrossDiv			, (int)InventInputSearchCndtn.GrossDivState.Product			// グロス区分(製番在庫ごと)
					);

					childRows = _sta_InventDataTable_Buf.Select(str_ChildFilter);

					if ( childRows == null || childRows.Length <= 0 ) continue;

					// 削除チェック
					foreach ( DataRow childRow in childRows )
					{
						// 全てのマシン在庫数と棚卸入力数が等く、かつ棚卸入力数がゼロより大きい場合のみは削除対象外
						if ( ( (Double)childRow[InventInputResult.ct_Col_StockTotal] != (Double)childRow[InventInputResult.ct_Col_InventoryStockCnt] ) &&
							(Double)childRow[InventInputResult.ct_Col_InventoryStockCnt] > 0 )
						{
							isNotDelete = true;
							break;
						}
					}

					if ( isNotDelete )
					{
						isNotDelete = false;
						continue;
					}

					// 子行の削除
					foreach ( DataRow childRow in childRows )
					{
						_sta_InventDataTable_Buf.Rows.Remove( childRow );
					}

					// 親行削除
					_sta_InventDataTable_Buf.Rows.Remove( parentRow );
				}
			}
			catch( Exception ex )
			{
				errMsg = ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
			}
			return status;
		}
		#endregion
           --- DEL 2008/09/01 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/09/01 使用していないのでコメントアウト


        // ---ADD 2009/05/14 不具合対応[13260] ------------------------>>>>>
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
        /// <br>Date       : 2009/05/14</br>
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
        /// <br>Date       : 2009/05/14</br>
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
        /// <br>Date       : 2009/05/14</br>
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
        public double GetAdjustCalcCost(GoodsUnitData goodsUnitData)
        {
            double adjustCalcCost = 0.0;
            //GoodsPrice goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(DateTime.Now, goodsUnitData.GoodsPriceList); //DEL yangyi 2013/03/01 Redmine#34175
            GoodsPrice goodsPrice = GetGoodsAcs().GetGoodsPriceFromGoodsPriceList(DateTime.Now, goodsUnitData.GoodsPriceList);    //ADD yangyi 2013/03/01 Redmine#34175 
            if (goodsPrice != null)
            {
                if (goodsPrice.PriceStartDate != DateTime.MinValue)
                {
                    UnitPriceCalcRet unitPriceCalcRet = null;
                    this.CalculateUnitCost(goodsUnitData, this._taxRate, out unitPriceCalcRet);

                    adjustCalcCost = unitPriceCalcRet.UnitPriceTaxExcFl;
                }
                else
                {
                    adjustCalcCost = goodsPrice.SalesUnitCost;
                }
            }

            return adjustCalcCost;
        }

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
        /// <br>Date       : 2009/05/14</br>
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
        /// <br>Date       : 2009/05/14</br>
        /// <br>UpdateNote : 2009/12/03 李占川 PM.NS　保守対応</br>
        /// </remarks>
        private void ReadStockMngTtlSt()
        {
            ArrayList retList;

            int statusMngTtlSt = _stockMngTtlStAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
            if (statusMngTtlSt == 0)
            {
                // --- ADD 2009/12/03 ---------->>>>>
                string section = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
                foreach (StockMngTtlSt stockMngTtlStLogin in retList)
                {
                    if (stockMngTtlStLogin.LogicalDeleteCode == 0 && stockMngTtlStLogin.SectionCode.Trim() == section)
                    {
                        this._stockMngTtlStLogin = stockMngTtlStLogin;
                        break;
                    }
                }
                // --- ADD 2009/12/03 ----------<<<<<

                foreach (StockMngTtlSt stockMngTtlSt in retList)
                {
                    if ((stockMngTtlSt.LogicalDeleteCode == 0) && (stockMngTtlSt.SectionCode.Trim() == "00"))
                    {
                        this._stockMngTtlSt = stockMngTtlSt;

                        // --- ADD 2009/12/03 ---------->>>>>
                        if (this._stockMngTtlStLogin == null)
                        {
                            this._stockMngTtlStLogin = this._stockMngTtlSt;
                        }
                        // --- ADD 2009/12/03 ----------<<<<<
                        break;
                    }
                }
            }
            else
            {
                this._stockMngTtlSt = new StockMngTtlSt();
                this._stockMngTtlStLogin = new StockMngTtlSt(); // ADD 2009/12/03
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
        /// <br>Date       : 2009/05/14</br>
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
        #endregion
        #endregion ◆ 計算原価額取得関連
        // ---ADD 2009/05/14 不具合対応[13260] ------------------------<<<<<

        // --- ADD 2009/12/03 ---------->>>>>
        /// <summary>
        /// 棚卸通番の付番順の設定
        /// </summary>
        /// <param name="InvntryPrtOdrIniDiv">棚卸印刷順初期設定区分</param>
        /// <returns>付番順</returns>
        /// <remarks>
        /// <br>Note       : 棚卸通番の付番順を設定します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/12/03</br>
        /// </remarks>
        private string MakeSortInvntryPrtOdr(int InvntryPrtOdrIniDiv)
        {
            string sort = string.Empty;

            switch (InvntryPrtOdrIniDiv)
            {
                // 0:棚番順
                case 0:
                    {
                        sort = InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_WarehouseShelfNo + "," +
                            InventInputResult.ct_Col_GoodsNo + "," + InventInputResult.ct_Col_MakerCode;
                        break;
                    }
                // 1:仕入先順
                case 1:
                    {
                        sort = InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_SupplierCode + "," +
                            InventInputResult.ct_Col_GoodsNo + "," + InventInputResult.ct_Col_MakerCode;
                        break;
                    }
                // 2:BLｺｰﾄﾞ順
                case 2:
                    {
                        sort = InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_BLGoodsCode + "," +
                            InventInputResult.ct_Col_GoodsNo + "," + InventInputResult.ct_Col_MakerCode;
                        break;
                    }
                // 3:グループコード順
                case 3:
                    {
                        sort = InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_BLGroupCode + "," +
                            InventInputResult.ct_Col_GoodsNo + "," + InventInputResult.ct_Col_MakerCode;
                        break;
                    }
                // 4:ﾒｰｶｰｺｰﾄﾞ順
                case 4:
                    {
                        sort = InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_MakerCode + "," +
                            InventInputResult.ct_Col_GoodsNo;
                        break;
                    }
                // 5:仕入先･棚番順
                case 5:
                    {
                        sort = InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_SupplierCode + "," + InventInputResult.ct_Col_WarehouseShelfNo + "," +
                             InventInputResult.ct_Col_GoodsNo + "," + InventInputResult.ct_Col_MakerCode;
                        break;
                    }
                // 6:仕入先･ﾒｰｶｰ順
                case 6:
                    {
                        sort = InventInputResult.ct_Col_WarehouseCode + "," + InventInputResult.ct_Col_SupplierCode + "," +
                              InventInputResult.ct_Col_MakerCode + "," + InventInputResult.ct_Col_GoodsNo;
                        break;
                    }
            }

            return sort;
        }
        // --- ADD 2009/12/03 ----------<<<<<
        #endregion ■ Private Method
    }
}

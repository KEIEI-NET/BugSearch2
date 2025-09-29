using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   StockListCndtn
	/// <summary>
	///                      在庫一覧表抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   在庫一覧表抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/10/10  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class StockListCndtn
	{
        #region enum

        /// <summary>
        /// ソート順
        /// </summary>
        public enum PageChangeDiv
        {
            // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
            /////<summary>メーカーコード順</summary>
            //Sort_MakerCode = 0,
            /////<summary>キャリア順</summary>
            //Sort_CarrierCode = 1,
            /////<summary>最終仕入日順</summary>
            //Sort_StockDate = 2,
            /////<summary>商品区分グループ・区分順</summary>
            //Sort_LargeGoodsGanreCode = 3,
            /////<summary>機種順</summary>
            //Sort_CellPhoneModeleCode = 4,
            /////<summary>出荷可能数</summary>
            //Sort_ShipmentPosCnt = 5

            //--- DEL 2008/08/01 ---------->>>>>
            /////<summary>倉庫コード順</summary>
            //Sort_WarehouseCode = 0,
            /////<summary>メーカーコード順</summary>
            //Sort_MakerCode = 1,
            /////<summary>最終仕入日順</summary>
            //Sort_StockDate = 2,
            /////<summary>出荷可能数順</summary>
            //Sort_ShipmentPosCnt = 3,
            /////<summary>商品区分グループ・区分・詳細区分順</summary>
            //Sort_LargeGoodsGanreCode = 4,
            /////<summary>自社分類順</summary>
            //Sort_EnterpriseGanreCode = 5,
            /////<summary>ＢＬ商品コード順</summary>
            //Sort_BLGoodsCode = 6
            //--- DEL 2008/08/01 ----------<<<<<
            // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<

            //--- ADD 2008/08/01 ---------->>>>>
            /////<summary>仕入先順</summary>
            Sort_SupplierCode = 0,
            /////<summary>棚番順</summary>
            Sort_WarehouseCode = 1
            //--- ADD 2008/08/01 ----------<<<<<
        }

        /// <summary>
        /// ソート計
        /// </summary>
        public enum PageChangeDivTitle
        {
            // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
            /////<summary>メーカーコード順</summary>
            //Sort_MakerTitle = 0,
            /////<summary>キャリア順</summary>
            //Sort_CarrierTitle = 1,
            /////<summary>最終仕入日計</summary>
            //Sort_StockDateTitle = 2,
            /////<summary>商品区分グループ計</summary>
            //Sort_LargeGoodsGanreTitle = 3,
            /////<summary>機種順計</summary>
            //Sort_CellPhoneModeleCodeTitle = 4,
            /////<summary>出荷可能数</summary>
            //Sort_ShipmentPosCntTitle = 5,
            /////<summary>商品区分計</summary>
            //Sort_MediumGoodsGanreTitle = 6

            ///<summary>倉庫コード順</summary>
            Sort_WarehouseTitle = 0,
            ///<summary>メーカーコード順</summary>
            Sort_MakerTitle = 1,
            ///<summary>最終仕入日順</summary>
            Sort_StockDateTitle = 2,
            ///<summary>出荷可能数順</summary>
            Sort_ShipmentPosCntTitle = 3,
            ///<summary>商品区分グループ・区分・詳細区分順</summary>
            Sort_LargeGoodsGanreTitle = 4,
            ///<summary>自社分類順</summary>
            Sort_EnterpriseGanreTitle = 5,
            ///<summary>ＢＬ商品コード順</summary>
            Sort_BLGoodsTitle = 6,
            ///<summary>商品区分計</summary>
            Sort_MediumGoodsGanreTitle = 7,
            ///<summary>商品区分詳細計</summary>
            Sort_DetailGoodsGanreTitle = 8
            // 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// 在庫区分
        /// </summary>
        public enum StockDivStatus
        {
            ///<summary>仕入在庫分</summary>
            StockDiv_MyStock = 0,
            ///<summary>受託在庫分</summary>
            StockDiv_TrustStock = 1,
            ///<summary>全て</summary>
            StockDiv_ALLStock = 2
        }

        #endregion

        #region Private Member
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>選択在庫計上拠点コード</summary>
        /// <remarks>（配列）</remarks>
        private string[] _depositStockSecCodeList;

        /// <summary>開始メーカーコード</summary>
        private Int32 _st_GoodsMakerCd;

        /// <summary>終了メーカーコード</summary>
        private Int32 _ed_GoodsMakerCd;

        /// <summary>開始商品番号</summary>
        private string _st_GoodsNo = "";

        /// <summary>終了商品番号</summary>
        private string _ed_GoodsNo = "";

        /// <summary>開始倉庫コード</summary>
        private string _st_WarehouseCode = "";

        /// <summary>終了倉庫コード</summary>
        private string _ed_WarehouseCode = "";

        //--- DEL 2008.08.01 ---------->>>>>
        ///// <summary>開始仕入在庫数</summary>
        //private Double _st_SupplierStock;

        ///// <summary>終了仕入在庫数</summary>
        //private Double _ed_SupplierStock;

        ///// <summary>開始受託数</summary>
        //private Double _st_TrustCount;

        ///// <summary>終了受託数</summary>
        //private Double _ed_TrustCount;
        //--- DEL 2008.08.01 ----------<<<<<

        /// <summary>開始出荷可能数</summary>
        private Double _st_ShipmentPosCnt;

        /// <summary>終了出荷可能数</summary>
        private Double _ed_ShipmentPosCnt;

        //--- DEL 2008.08.01 ---------->>>>>
        ///// <summary>開始商品区分グループコード</summary>
        //private string _st_LargeGoodsGanreCode = "";

        ///// <summary>終了商品区分グループコード</summary>
        //private string _ed_LargeGoodsGanreCode = "";

        ///// <summary>開始商品区分コード</summary>
        //private string _st_MediumGoodsGanreCode = "";

        ///// <summary>終了商品区分コード</summary>
        //private string _ed_MediumGoodsGanreCode = "";

        ///// <summary>開始商品区分詳細コード</summary>
        //private string _st_DetailGoodsGanreCode = "";

        ///// <summary>終了商品区分詳細コード</summary>
        //private string _ed_DetailGoodsGanreCode = "";

        ///// <summary>自社分類コード開始</summary>
        //private Int32 _st_EnterpriseGanreCode;

        ///// <summary>自社分類コード終了</summary>
        //private Int32 _ed_EnterpriseGanreCode;
        //--- DEL 2008.08.01 ----------<<<<<

        /// <summary>ＢＬ商品コード開始</summary>
        private Int32 _st_BLGoodsCode;

        /// <summary>ＢＬ商品コード終了</summary>
        private Int32 _ed_BLGoodsCode;

        /// <summary>開始最終仕入年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _st_LastStockDate;

        /// <summary>終了最終仕入年月日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ed_LastStockDate;

        //--- DEL 2008.08.01 ---------->>>>>
        ///// <summary>開始最終売上日</summary>
        ///// <remarks>YYYYMMDD</remarks>
        //private DateTime _st_LastSalesDate;

        ///// <summary>終了最終売上日</summary>
        ///// <remarks>YYYYMMDD</remarks>
        //private DateTime _ed_LastSalesDate;

        ///// <summary>開始最終棚卸更新日</summary>
        ///// <remarks>YYYYMMDD</remarks>
        //private DateTime _st_LastInventoryUpdate;

        ///// <summary>終了最終棚卸更新日</summary>
        ///// <remarks>YYYYMMDD</remarks>
        //private DateTime _ed_LastInventoryUpdate;

        ///// <summary>開始在庫登録日</summary>
        ///// <remarks>YYYYMMDD</remarks>
        //private DateTime _st_StockCreateDate;

        ///// <summary>終了在庫登録日</summary>
        ///// <remarks>YYYYMMDD</remarks>
        //private DateTime _ed_StockCreateDate;
        //--- DEL 2008.08.01 ----------<<<<<

        /// <summary>在庫区分</summary>
        /// <remarks>0:全て,1:仕入在庫分(自社),2受託在庫分(受託)</remarks>
        private Int32 _stockDiv;

        /// <summary>出力順</summary>
        private Int32 _changePageDiv;

        /// <summary>出力順名称</summary>
        private string _changePageDivName = "";

        /// <summary>在庫評価方法</summary>
        /// <remarks>1:最終仕入原価法,2:移動平均法,3:個別単価法</remarks>
        private Int32 _stockPointWay;

        //--- ADD 2008/08/01 ---------->>>>>
        /// <summary>在庫登録日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _stockCreateDate;
        /// <summary>在庫登録日検索フラグ</summary>
        /// <remarks>YYYYMMDD</remarks>
        private StockCreateDateDivState _stockCreateDateFlg;

        /// <summary>部品管理区分１</summary>
        private string[] _partsManagementDivide1;
        /// <summary>部品管理区分２</summary>
        private string[] _partsManagementDivide2;

        /// <summary>開始仕入先コード</summary>
        private Int32 _st_StockSupplierCode;
        /// <summary>開始仕入先コード</summary>
        private Int32 _ed_StockSupplierCode;

        /// <summary>開始倉庫棚番</summary>
        private string _st_WarehouseShelfNo = "";
        /// <summary>終了倉庫棚番</summary>
        private string _ed_WarehouseShelfNo = "";
        //--- ADD 2008/08/01 ----------<<<<<
        #endregion

        #region public propaty
        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  DepositStockSecCodeList
        /// <summary>選択在庫計上拠点コードプロパティ</summary>
        /// <value>（配列）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   選択在庫計上拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] DepositStockSecCodeList
        {
            get { return _depositStockSecCodeList; }
            set { _depositStockSecCodeList = value; }
        }

        /// public propaty name  :  St_GoodsMakerCd
        /// <summary>開始メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_GoodsMakerCd
        {
            get { return _st_GoodsMakerCd; }
            set { _st_GoodsMakerCd = value; }
        }

        /// public propaty name  :  Ed_GoodsMakerCd
        /// <summary>終了メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_GoodsMakerCd
        {
            get { return _ed_GoodsMakerCd; }
            set { _ed_GoodsMakerCd = value; }
        }

        /// public propaty name  :  St_GoodsNo
        /// <summary>開始商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_GoodsNo
        {
            get { return _st_GoodsNo; }
            set { _st_GoodsNo = value; }
        }

        /// public propaty name  :  Ed_GoodsNo
        /// <summary>終了商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_GoodsNo
        {
            get { return _ed_GoodsNo; }
            set { _ed_GoodsNo = value; }
        }

        /// public propaty name  :  St_WarehouseCode
        /// <summary>開始倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_WarehouseCode
        {
            get { return _st_WarehouseCode; }
            set { _st_WarehouseCode = value; }
        }

        /// public propaty name  :  Ed_WarehouseCode
        /// <summary>終了倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_WarehouseCode
        {
            get { return _ed_WarehouseCode; }
            set { _ed_WarehouseCode = value; }
        }

        //--- DEL 2008.08.01 ---------->>>>>
        ///// public propaty name  :  St_SupplierStock
        ///// <summary>開始仕入在庫数プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   開始仕入在庫数プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Double St_SupplierStock
        //{
        //    get { return _st_SupplierStock; }
        //    set { _st_SupplierStock = value; }
        //}

        ///// public propaty name  :  Ed_SupplierStock
        ///// <summary>終了仕入在庫数プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   終了仕入在庫数プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Double Ed_SupplierStock
        //{
        //    get { return _ed_SupplierStock; }
        //    set { _ed_SupplierStock = value; }
        //}

        ///// public propaty name  :  St_TrustCount
        ///// <summary>開始受託数プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   開始受託数プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Double St_TrustCount
        //{
        //    get { return _st_TrustCount; }
        //    set { _st_TrustCount = value; }
        //}

        ///// public propaty name  :  Ed_TrustCount
        ///// <summary>終了受託数プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   終了受託数プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Double Ed_TrustCount
        //{
        //    get { return _ed_TrustCount; }
        //    set { _ed_TrustCount = value; }
        //}
        //--- DEL 2008.08.01 ----------<<<<<

        /// public propaty name  :  St_ShipmentPosCnt
        /// <summary>開始出荷可能数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始出荷可能数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double St_ShipmentPosCnt
        {
            get { return _st_ShipmentPosCnt; }
            set { _st_ShipmentPosCnt = value; }
        }

        /// public propaty name  :  Ed_ShipmentPosCnt
        /// <summary>終了出荷可能数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了出荷可能数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double Ed_ShipmentPosCnt
        {
            get { return _ed_ShipmentPosCnt; }
            set { _ed_ShipmentPosCnt = value; }
        }

        //--- DEL 2008.08.01 ---------->>>>>
        ///// public propaty name  :  St_LargeGoodsGanreCode
        ///// <summary>開始商品区分グループコードプロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   開始商品区分グループコードプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string St_LargeGoodsGanreCode
        //{
        //    get { return _st_LargeGoodsGanreCode; }
        //    set { _st_LargeGoodsGanreCode = value; }
        //}

        ///// public propaty name  :  Ed_LargeGoodsGanreCode
        ///// <summary>終了商品区分グループコードプロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   終了商品区分グループコードプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string Ed_LargeGoodsGanreCode
        //{
        //    get { return _ed_LargeGoodsGanreCode; }
        //    set { _ed_LargeGoodsGanreCode = value; }
        //}

        ///// public propaty name  :  St_MediumGoodsGanreCode
        ///// <summary>開始商品区分コードプロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   開始商品区分コードプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string St_MediumGoodsGanreCode
        //{
        //    get { return _st_MediumGoodsGanreCode; }
        //    set { _st_MediumGoodsGanreCode = value; }
        //}

        ///// public propaty name  :  Ed_MediumGoodsGanreCode
        ///// <summary>終了商品区分コードプロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   終了商品区分コードプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string Ed_MediumGoodsGanreCode
        //{
        //    get { return _ed_MediumGoodsGanreCode; }
        //    set { _ed_MediumGoodsGanreCode = value; }
        //}

        ///// public propaty name  :  St_DetailGoodsGanreCode
        ///// <summary>開始商品区分詳細コードプロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   開始商品区分詳細コードプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string St_DetailGoodsGanreCode
        //{
        //    get { return _st_DetailGoodsGanreCode; }
        //    set { _st_DetailGoodsGanreCode = value; }
        //}

        ///// public propaty name  :  Ed_DetailGoodsGanreCode
        ///// <summary>終了商品区分詳細コードプロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   終了商品区分詳細コードプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string Ed_DetailGoodsGanreCode
        //{
        //    get { return _ed_DetailGoodsGanreCode; }
        //    set { _ed_DetailGoodsGanreCode = value; }
        //}

        ///// public propaty name  :  St_EnterpriseGanreCode
        ///// <summary>自社分類コード開始プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   自社分類コード開始プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 St_EnterpriseGanreCode
        //{
        //    get { return _st_EnterpriseGanreCode; }
        //    set { _st_EnterpriseGanreCode = value; }
        //}

        ///// public propaty name  :  Ed_EnterpriseGanreCode
        ///// <summary>自社分類コード終了プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   自社分類コード終了プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 Ed_EnterpriseGanreCode
        //{
        //    get { return _ed_EnterpriseGanreCode; }
        //    set { _ed_EnterpriseGanreCode = value; }
        //}
        //--- DEL 2008.08.01 ----------<<<<<

        /// public propaty name  :  St_BLGoodsCode
        /// <summary>ＢＬ商品コード開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＢＬ商品コード開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_BLGoodsCode
        {
            get { return _st_BLGoodsCode; }
            set { _st_BLGoodsCode = value; }
        }

        /// public propaty name  :  Ed_BLGoodsCode
        /// <summary>ＢＬ商品コード終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＢＬ商品コード終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_BLGoodsCode
        {
            get { return _ed_BLGoodsCode; }
            set { _ed_BLGoodsCode = value; }
        }

        /// public propaty name  :  St_LastStockDate
        /// <summary>開始最終仕入年月日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始最終仕入年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime St_LastStockDate
        {
            get { return _st_LastStockDate; }
            set { _st_LastStockDate = value; }
        }

        /// public propaty name  :  Ed_LastStockDate
        /// <summary>終了最終仕入年月日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了最終仕入年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Ed_LastStockDate
        {
            get { return _ed_LastStockDate; }
            set { _ed_LastStockDate = value; }
        }

        //--- DEL 2008.08.01 ---------->>>>>
        ///// public propaty name  :  St_LastSalesDate
        ///// <summary>開始最終売上日プロパティ</summary>
        ///// <value>YYYYMMDD</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   開始最終売上日プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public DateTime St_LastSalesDate
        //{
        //    get { return _st_LastSalesDate; }
        //    set { _st_LastSalesDate = value; }
        //}

        ///// public propaty name  :  Ed_LastSalesDate
        ///// <summary>終了最終売上日プロパティ</summary>
        ///// <value>YYYYMMDD</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   終了最終売上日プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public DateTime Ed_LastSalesDate
        //{
        //    get { return _ed_LastSalesDate; }
        //    set { _ed_LastSalesDate = value; }
        //}

        ///// public propaty name  :  St_LastInventoryUpdate
        ///// <summary>開始最終棚卸更新日プロパティ</summary>
        ///// <value>YYYYMMDD</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   開始最終棚卸更新日プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public DateTime St_LastInventoryUpdate
        //{
        //    get { return _st_LastInventoryUpdate; }
        //    set { _st_LastInventoryUpdate = value; }
        //}

        ///// public propaty name  :  Ed_LastInventoryUpdate
        ///// <summary>終了最終棚卸更新日プロパティ</summary>
        ///// <value>YYYYMMDD</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   終了最終棚卸更新日プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public DateTime Ed_LastInventoryUpdate
        //{
        //    get { return _ed_LastInventoryUpdate; }
        //    set { _ed_LastInventoryUpdate = value; }
        //}

        ///// public propaty name  :  St_StockCreateDate
        ///// <summary>開始在庫登録日プロパティ</summary>
        ///// <value>YYYYMMDD</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   開始在庫登録日プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public DateTime St_StockCreateDate
        //{
        //    get { return _st_StockCreateDate; }
        //    set { _st_StockCreateDate = value; }
        //}

        ///// public propaty name  :  Ed_StockCreateDate
        ///// <summary>終了在庫登録日プロパティ</summary>
        ///// <value>YYYYMMDD</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   終了在庫登録日プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public DateTime Ed_StockCreateDate
        //{
        //    get { return _ed_StockCreateDate; }
        //    set { _ed_StockCreateDate = value; }
        //}
        //--- DEL 2008.08.01 ----------<<<<<

        /// public propaty name  :  StockDiv
        /// <summary>在庫区分プロパティ</summary>
        /// <value>0:全て,1:仕入在庫分(自社),2受託在庫分(受託)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockDiv
        {
            get { return _stockDiv; }
            set { _stockDiv = value; }
        }

        /// public propaty name  :  ChangePageDiv
        /// <summary>出力順プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力順プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ChangePageDiv
        {
            get { return _changePageDiv; }
            set { _changePageDiv = value; }
        }

        /// public propaty name  :  ChangePageDivName
        /// <summary>出力順名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力順名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ChangePageDivName
        {
            get { return _changePageDivName; }
            set { _changePageDivName = value; }
        }

        /// public propaty name  :  StockPointWay
        /// <summary>在庫評価方法プロパティ</summary>
        /// <value>1:最終仕入原価法,2:移動平均法,3:個別単価法</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫評価方法プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockPointWay
        {
            get { return _stockPointWay; }
            set { _stockPointWay = value; }
        }

        //--- ADD 2008/08/01 ---------->>>>>

        /// public propaty name  :  StockCreateDate
        /// <summary>在庫登録日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫登録日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime StockCreateDate
        {
            get { return _stockCreateDate; }
            set { _stockCreateDate = value; }
        }

        /// public propaty name  :  StockCreateDate
        /// <summary>在庫登録日検索フラグプロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫登録日検索フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockCreateDateDivState StockCreateDateFlg
        {
            get { return _stockCreateDateFlg; }
            set { _stockCreateDateFlg = value; }
        }

        /// public propaty name  :  PartsManagementDivide1
        /// <summary>部品管理区分１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品管理区分１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] PartsManagementDivide1
        {
            get { return _partsManagementDivide1; }
            set { _partsManagementDivide1 = value; }
        }

        /// public propaty name  :  PartsManagementDivide2
        /// <summary>部品管理区分２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品管理区分２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] PartsManagementDivide2
        {
            get { return _partsManagementDivide2; }
            set { _partsManagementDivide2 = value; }
        }

        /// public propaty name  :  St_StockSupplierCode
        /// <summary>開始仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始在庫発注先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_StockSupplierCode
        {
            get { return _st_StockSupplierCode; }
            set { _st_StockSupplierCode = value; }
        }

        /// public propaty name  :  Ed_StockSupplierCode
        /// <summary>終了仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了在庫発注先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_StockSupplierCode
        {
            get { return _ed_StockSupplierCode; }
            set { _ed_StockSupplierCode = value; }
        }

        /// public propaty name  :  St_WarehouseShelfNo
        /// <summary>開始商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始倉庫棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_WarehouseShelfNo
        {
            get { return _st_WarehouseShelfNo; }
            set { _st_WarehouseShelfNo = value; }
        }

        /// public propaty name  :  Ed_WarehouseShelfNo
        /// <summary>開始商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了倉庫棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_WarehouseShelfNo
        {
            get { return _ed_WarehouseShelfNo; }
            set { _ed_WarehouseShelfNo = value; }
        }

        //--- ADD 2008/08/01 ----------<<<<<

        #endregion

        //--- ADD 2008/08/01 ---------->>>>>
        # region ■ private field (自動生成以外) ■
        /// <summary>
        /// 棚番ブレイク区分
        /// </summary>
        private WarehouseShelfNoBreakDivState _warehouseShelfNoBreakDiv;
        /// <summary>
        /// 改頁区分
        /// </summary>
        private NewPageDivState _newPageDiv;
        /// <summary>
        /// 発行タイプ区分
        /// </summary>
        private PublicationTypeState _publicationType;
        # endregion ■ private field (自動生成以外) ■
        //--- ADD 2008/08/01 ----------<<<<<

        //--- ADD 2008/08/01 ---------->>>>>
        # region ■ public propaty (自動生成以外) ■
        /// <summary>
        /// <summary>
        /// 棚番ブレイク区分プロパティ
        /// </summary>
        public WarehouseShelfNoBreakDivState WarehouseShelfNoBreakDiv
        {
            get { return this._warehouseShelfNoBreakDiv; }
            set { this._warehouseShelfNoBreakDiv = value; }
        }
        /// <summary>
        /// 棚番ブレイク桁数
        /// </summary>
        public Int32 WarehouseShelfNoBreakLength
        {
            // ReadOnly
            get
            {
                return ((int)this._warehouseShelfNoBreakDiv + 1);
            }
        }
        /// <summary>
        /// 改ページ区分　プロパティ
        /// </summary>
        public NewPageDivState NewPageDiv
        {
            get { return this._newPageDiv; }
            set { this._newPageDiv = value; }
        }
        /// <summary>
        /// 発行タイプ区分　プロパティ
        /// </summary>
        public PublicationTypeState PublicationType
        {
            get { return this._publicationType; }
            set { this._publicationType = value; }
        }
        /// <summary>
        /// 在庫登録日指定区分　名称取得プロパティ
        /// </summary>
        public string StockCreateDateDivStateTitle
        {
            get
            {
                switch (this._stockCreateDateFlg)
                {
                    case StockCreateDateDivState.Before: return ct_StockCreateDateDivState_Before;
                    case StockCreateDateDivState.After: return ct_StockCreateDateDivState_After;
                    default: return string.Empty;
                }
            }
        }
        /// <summary>
        /// 棚番ブレイク区分　名称取得プロパティ
        /// </summary>
        public string WarehouseShelfNoBreakDivStateTitle
        {
            get
            {
                switch (this._warehouseShelfNoBreakDiv)
                {
                    case WarehouseShelfNoBreakDivState.Length1: return ct_WarehouseShelfNoBreakDivState_Length1;
                    case WarehouseShelfNoBreakDivState.Length2: return ct_WarehouseShelfNoBreakDivState_Length2;
                    case WarehouseShelfNoBreakDivState.Length3: return ct_WarehouseShelfNoBreakDivState_Length3;
                    case WarehouseShelfNoBreakDivState.Length4: return ct_WarehouseShelfNoBreakDivState_Length4;
                    case WarehouseShelfNoBreakDivState.Length5: return ct_WarehouseShelfNoBreakDivState_Length5;
                    case WarehouseShelfNoBreakDivState.Length6: return ct_WarehouseShelfNoBreakDivState_Length6;
                    case WarehouseShelfNoBreakDivState.Length7: return ct_WarehouseShelfNoBreakDivState_Length7;
                    case WarehouseShelfNoBreakDivState.Length8: return ct_WarehouseShelfNoBreakDivState_Length8;
                    default: return string.Empty;
                }
            }
        }
        # endregion ■ public propaty (自動生成以外) ■
        //--- ADD 2008/08/01 ----------<<<<<

        //--- ADD 2008/08/01 ---------->>>>>
        # region ■ public Enum (自動生成以外) ■
        /// <summary>
        /// 棚番ブレイク区分　列挙体
        /// </summary>
        public enum WarehouseShelfNoBreakDivState
        {
            /// <summary>１桁</summary>
            Length1 = 0,
            /// <summary>２桁</summary>
            Length2 = 1,
            /// <summary>３桁</summary>
            Length3 = 2,
            /// <summary>４桁</summary>
            Length4 = 3,
            /// <summary>５桁</summary>
            Length5 = 4,
            /// <summary>６桁</summary>
            Length6 = 5,
            /// <summary>７桁</summary>
            Length7 = 6,
            /// <summary>８桁</summary>
            Length8 = 7,
        }
        /// <summary>
        /// 改ページ区分　列挙体
        /// </summary>
        public enum NewPageDivState
        {
            /// <summary>小計毎</summary>
            EachSummaly = 0,
            /// <summary>しない</summary>
            None = 1,
        }
        /// <summary>
        /// 在庫登録日指定区分　列挙体
        /// </summary>
        public enum StockCreateDateDivState
        {
            /// <summary>以前</summary>
            Before = 0,
            /// <summary>以後</summary>
            After = 1,
        }
        /// <summary>
        /// 出力順区分
        /// </summary>
        public enum PrintSortDivState
        {
            /// <summary>仕入先順</summary>
            ByCustomer = 0,
            /// <summary>倉庫棚番順</summary>
            ByWarehouseShelfNo = 1,
        }
        /// <summary>
        /// 発行タイプ区分
        /// </summary>
        public enum PublicationTypeState
        {
            /// <summary>数量</summary>
            ByShipmentCnt = 0,
            /// <summary>金額</summary>
            ByShipmentPrice = 1,
        }
        # endregion ■ public Enum (自動生成以外) ■
        //--- ADD 2008/08/01 ----------<<<<<

        //--- ADD 2008/08/01 ---------->>>>>
        #region ■ public const (自動生成以外) ■
        /// <summary>共通 日付フォーマット</summary>
        public const string ct_DateFomat = "YYYY/MM/DD";

        /// <summary>共通 全て コード</summary>
        public const int ct_All_Code = -1;
        /// <summary>共通 全て 名称</summary>
        public const string ct_All_Name = "全て";

        /// <summary>棚番ブレイク区分　１桁</summary>
        public const string ct_WarehouseShelfNoBreakDivState_Length1 = "１桁";
        /// <summary>棚番ブレイク区分　２桁</summary>
        public const string ct_WarehouseShelfNoBreakDivState_Length2 = "２桁";
        /// <summary>棚番ブレイク区分　３桁</summary>
        public const string ct_WarehouseShelfNoBreakDivState_Length3 = "３桁";
        /// <summary>棚番ブレイク区分　４桁</summary>
        public const string ct_WarehouseShelfNoBreakDivState_Length4 = "４桁";
        /// <summary>棚番ブレイク区分　５桁</summary>
        public const string ct_WarehouseShelfNoBreakDivState_Length5 = "５桁";
        /// <summary>棚番ブレイク区分　６桁</summary>
        public const string ct_WarehouseShelfNoBreakDivState_Length6 = "６桁";
        /// <summary>棚番ブレイク区分　７桁</summary>
        public const string ct_WarehouseShelfNoBreakDivState_Length7 = "７桁";
        /// <summary>棚番ブレイク区分　８桁</summary>
        public const string ct_WarehouseShelfNoBreakDivState_Length8 = "８桁";

        /// <summary>改ページ区分　小計毎</summary>
        public const string ct_NewPageDivState_EachSummaly = "小計毎";
        /// <summary>改ページ区分　印刷しない</summary>
        public const string ct_NewPageDivState_None = "印刷しない";

        /// <summary>在庫登録日指定区分　以前</summary>
        public const string ct_StockCreateDateDivState_Before = "以前";
        /// <summary>在庫登録日指定区分　以後</summary>
        public const string ct_StockCreateDateDivState_After = "以後";

        /// <summary>出力順区分　仕入先順</summary>
        public const string ct_PrintSortDivState_ByCustomer = "仕入先順";
        /// <summary>出力順区分　棚番順</summary>
        public const string ct_PrintSortDivState_ByWarehouseShelfNo = "棚番順";

        #endregion
        //--- ADD 2008/08/01 ----------<<<<<

        #region Constructor
		/// <summary>
		/// 在庫一覧表抽出条件クラスコンストラクタ
		/// </summary>
		/// <returns>StockListCndtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockListCndtnクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockListCndtn()
		{
		}

        //--- DEL 2008.08.01 ---------->>>>>
        ///// <summary>
        ///// 在庫一覧表抽出条件クラスコンストラクタ
        ///// </summary>
        ///// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        ///// <param name="depositStockSecCodeList">選択在庫計上拠点コード(（配列）)</param>
        ///// <param name="st_GoodsMakerCd">開始メーカーコード</param>
        ///// <param name="ed_GoodsMakerCd">終了メーカーコード</param>
        ///// <param name="st_GoodsNo">開始商品番号</param>
        ///// <param name="ed_GoodsNo">終了商品番号</param>
        ///// <param name="st_WarehouseCode">開始倉庫コード</param>
        ///// <param name="ed_WarehouseCode">終了倉庫コード</param>
        ///// <param name="st_SupplierStock">開始仕入在庫数</param>
        ///// <param name="ed_SupplierStock">終了仕入在庫数</param>
        ///// <param name="st_TrustCount">開始受託数</param>
        ///// <param name="ed_TrustCount">終了受託数</param>
        ///// <param name="st_ShipmentPosCnt">開始出荷可能数</param>
        ///// <param name="ed_ShipmentPosCnt">終了出荷可能数</param>
        ///// <param name="st_LargeGoodsGanreCode">開始商品区分グループコード</param>
        ///// <param name="ed_LargeGoodsGanreCode">終了商品区分グループコード</param>
        ///// <param name="st_MediumGoodsGanreCode">開始商品区分コード</param>
        ///// <param name="ed_MediumGoodsGanreCode">終了商品区分コード</param>
        ///// <param name="st_DetailGoodsGanreCode">開始商品区分詳細コード</param>
        ///// <param name="ed_DetailGoodsGanreCode">終了商品区分詳細コード</param>
        ///// <param name="st_EnterpriseGanreCode">自社分類コード開始</param>
        ///// <param name="ed_EnterpriseGanreCode">自社分類コード終了</param>
        ///// <param name="st_BLGoodsCode">ＢＬ商品コード開始</param>
        ///// <param name="ed_BLGoodsCode">ＢＬ商品コード終了</param>
        ///// <param name="st_LastStockDate">開始最終仕入年月日(YYYYMMDD)</param>
        ///// <param name="ed_LastStockDate">終了最終仕入年月日(YYYYMMDD)</param>
        ///// <param name="st_LastSalesDate">開始最終売上日(YYYYMMDD)</param>
        ///// <param name="ed_LastSalesDate">終了最終売上日(YYYYMMDD)</param>
        ///// <param name="st_LastInventoryUpdate">開始最終棚卸更新日(YYYYMMDD)</param>
        ///// <param name="ed_LastInventoryUpdate">終了最終棚卸更新日(YYYYMMDD)</param>
        ///// <param name="st_StockCreateDate">開始在庫登録日(YYYYMMDD)</param>
        ///// <param name="ed_StockCreateDate">終了在庫登録日(YYYYMMDD)</param>
        ///// <param name="stockDiv">在庫区分(0:全て,1:仕入在庫分(自社),2受託在庫分(受託))</param>
        ///// <param name="changePageDiv">出力順</param>
        ///// <param name="changePageDivName">出力順名称</param>
        ///// <param name="stockPointWay">在庫評価方法(1:最終仕入原価法,2:移動平均法,3:個別単価法)</param>
        ///// <returns>StockListCndtnクラスのインスタンス</returns>
        ///// <remarks>
        ///// <br>Note　　　　　　 :   StockListCndtnクラスの新しいインスタンスを生成します</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public StockListCndtn(string enterpriseCode,string[] depositStockSecCodeList,Int32 st_GoodsMakerCd,Int32 ed_GoodsMakerCd,string st_GoodsNo,string ed_GoodsNo,string st_WarehouseCode,string ed_WarehouseCode,Double st_SupplierStock,Double ed_SupplierStock,Double st_TrustCount,Double ed_TrustCount,Double st_ShipmentPosCnt,Double ed_ShipmentPosCnt,string st_LargeGoodsGanreCode,string ed_LargeGoodsGanreCode,string st_MediumGoodsGanreCode,string ed_MediumGoodsGanreCode,string st_DetailGoodsGanreCode,string ed_DetailGoodsGanreCode,Int32 st_EnterpriseGanreCode,Int32 ed_EnterpriseGanreCode,Int32 st_BLGoodsCode,Int32 ed_BLGoodsCode,DateTime st_LastStockDate,DateTime ed_LastStockDate,DateTime st_LastSalesDate,DateTime ed_LastSalesDate,DateTime st_LastInventoryUpdate,DateTime ed_LastInventoryUpdate,DateTime st_StockCreateDate,DateTime ed_StockCreateDate,Int32 stockDiv,Int32 changePageDiv,string changePageDivName,Int32 stockPointWay)
        //{
        //    this._enterpriseCode = enterpriseCode;
        //    this._depositStockSecCodeList = depositStockSecCodeList;
        //    this._st_GoodsMakerCd = st_GoodsMakerCd;
        //    this._ed_GoodsMakerCd = ed_GoodsMakerCd;
        //    this._st_GoodsNo = st_GoodsNo;
        //    this._ed_GoodsNo = ed_GoodsNo;
        //    this._st_WarehouseCode = st_WarehouseCode;
        //    this._ed_WarehouseCode = ed_WarehouseCode;
        //    this._st_SupplierStock = st_SupplierStock;
        //    this._ed_SupplierStock = ed_SupplierStock;
        //    this._st_TrustCount = st_TrustCount;
        //    this._ed_TrustCount = ed_TrustCount;
        //    this._st_ShipmentPosCnt = st_ShipmentPosCnt;
        //    this._ed_ShipmentPosCnt = ed_ShipmentPosCnt;
        //    this._st_LargeGoodsGanreCode = st_LargeGoodsGanreCode;
        //    this._ed_LargeGoodsGanreCode = ed_LargeGoodsGanreCode;
        //    this._st_MediumGoodsGanreCode = st_MediumGoodsGanreCode;
        //    this._ed_MediumGoodsGanreCode = ed_MediumGoodsGanreCode;
        //    this._st_DetailGoodsGanreCode = st_DetailGoodsGanreCode;
        //    this._ed_DetailGoodsGanreCode = ed_DetailGoodsGanreCode;
        //    this._st_EnterpriseGanreCode = st_EnterpriseGanreCode;
        //    this._ed_EnterpriseGanreCode = ed_EnterpriseGanreCode;
        //    this._st_BLGoodsCode = st_BLGoodsCode;
        //    this._ed_BLGoodsCode = ed_BLGoodsCode;
        //    this._st_LastStockDate = st_LastStockDate;
        //    this._ed_LastStockDate = ed_LastStockDate;
        //    this._st_LastSalesDate = st_LastSalesDate;
        //    this._ed_LastSalesDate = ed_LastSalesDate;
        //    this._st_LastInventoryUpdate = st_LastInventoryUpdate;
        //    this._ed_LastInventoryUpdate = ed_LastInventoryUpdate;
        //    this._st_StockCreateDate = st_StockCreateDate;
        //    this._ed_StockCreateDate = ed_StockCreateDate;
        //    this._stockDiv = stockDiv;
        //    this._changePageDiv = changePageDiv;
        //    this._changePageDivName = changePageDivName;
        //    this._stockPointWay = stockPointWay;

        //}
        //--- DEL 2008.08.01 ----------<<<<<

        //--- DEL 2008.08.01 ---------->>>>>
        ///// <summary>
        ///// 在庫一覧表抽出条件クラス複製処理
        ///// </summary>
        ///// <returns>StockListCndtnクラスのインスタンス</returns>
        ///// <remarks>
        ///// <br>Note　　　　　　 :   自身の内容と等しいStockListCndtnクラスのインスタンスを返します</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public StockListCndtn Clone()
        //{
        //    return new StockListCndtn(this._enterpriseCode,this._depositStockSecCodeList,this._st_GoodsMakerCd,this._ed_GoodsMakerCd,this._st_GoodsNo,this._ed_GoodsNo,this._st_WarehouseCode,this._ed_WarehouseCode,this._st_SupplierStock,this._ed_SupplierStock,this._st_TrustCount,this._ed_TrustCount,this._st_ShipmentPosCnt,this._ed_ShipmentPosCnt,this._st_LargeGoodsGanreCode,this._ed_LargeGoodsGanreCode,this._st_MediumGoodsGanreCode,this._ed_MediumGoodsGanreCode,this._st_DetailGoodsGanreCode,this._ed_DetailGoodsGanreCode,this._st_EnterpriseGanreCode,this._ed_EnterpriseGanreCode,this._st_BLGoodsCode,this._ed_BLGoodsCode,this._st_LastStockDate,this._ed_LastStockDate,this._st_LastSalesDate,this._ed_LastSalesDate,this._st_LastInventoryUpdate,this._ed_LastInventoryUpdate,this._st_StockCreateDate,this._ed_StockCreateDate,this._stockDiv,this._changePageDiv,this._changePageDivName,this._stockPointWay);
        //}
        //--- DEL 2008.08.01 ----------<<<<<

        //--- DEL 2008.08.01 ---------->>>>>
        ///// <summary>
        ///// 在庫一覧表抽出条件クラス比較処理
        ///// </summary>
        ///// <param name="target">比較対象のStockListCndtnクラスのインスタンス</param>
        ///// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        ///// <remarks>
        ///// <br>Note　　　　　　 :   StockListCndtnクラスの内容が一致するか比較します</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public bool Equals(StockListCndtn target)
        //{
        //    return ((this.EnterpriseCode == target.EnterpriseCode)
        //         && (this.DepositStockSecCodeList == target.DepositStockSecCodeList)
        //         && (this.St_GoodsMakerCd == target.St_GoodsMakerCd)
        //         && (this.Ed_GoodsMakerCd == target.Ed_GoodsMakerCd)
        //         && (this.St_GoodsNo == target.St_GoodsNo)
        //         && (this.Ed_GoodsNo == target.Ed_GoodsNo)
        //         && (this.St_WarehouseCode == target.St_WarehouseCode)
        //         && (this.Ed_WarehouseCode == target.Ed_WarehouseCode)
        //         && (this.St_SupplierStock == target.St_SupplierStock)
        //         && (this.Ed_SupplierStock == target.Ed_SupplierStock)
        //         && (this.St_TrustCount == target.St_TrustCount)
        //         && (this.Ed_TrustCount == target.Ed_TrustCount)
        //         && (this.St_ShipmentPosCnt == target.St_ShipmentPosCnt)
        //         && (this.Ed_ShipmentPosCnt == target.Ed_ShipmentPosCnt)
        //         && (this.St_LargeGoodsGanreCode == target.St_LargeGoodsGanreCode)
        //         && (this.Ed_LargeGoodsGanreCode == target.Ed_LargeGoodsGanreCode)
        //         && (this.St_MediumGoodsGanreCode == target.St_MediumGoodsGanreCode)
        //         && (this.Ed_MediumGoodsGanreCode == target.Ed_MediumGoodsGanreCode)
        //         && (this.St_DetailGoodsGanreCode == target.St_DetailGoodsGanreCode)
        //         && (this.Ed_DetailGoodsGanreCode == target.Ed_DetailGoodsGanreCode)
        //         && (this.St_EnterpriseGanreCode == target.St_EnterpriseGanreCode)
        //         && (this.Ed_EnterpriseGanreCode == target.Ed_EnterpriseGanreCode)
        //         && (this.St_BLGoodsCode == target.St_BLGoodsCode)
        //         && (this.Ed_BLGoodsCode == target.Ed_BLGoodsCode)
        //         && (this.St_LastStockDate == target.St_LastStockDate)
        //         && (this.Ed_LastStockDate == target.Ed_LastStockDate)
        //         && (this.St_LastSalesDate == target.St_LastSalesDate)
        //         && (this.Ed_LastSalesDate == target.Ed_LastSalesDate)
        //         && (this.St_LastInventoryUpdate == target.St_LastInventoryUpdate)
        //         && (this.Ed_LastInventoryUpdate == target.Ed_LastInventoryUpdate)
        //         && (this.St_StockCreateDate == target.St_StockCreateDate)
        //         && (this.Ed_StockCreateDate == target.Ed_StockCreateDate)
        //         && (this.StockDiv == target.StockDiv)
        //         && (this.ChangePageDiv == target.ChangePageDiv)
        //         && (this.ChangePageDivName == target.ChangePageDivName)
        //         && (this.StockPointWay == target.StockPointWay));
        //}
        //--- DEL 2008.08.01 ----------<<<<<

        //--- DEL 2008.08.01 ---------->>>>>
        ///// <summary>
        ///// 在庫一覧表抽出条件クラス比較処理
        ///// </summary>
        ///// <param name="stockListCndtn1">
        /////                    比較するStockListCndtnクラスのインスタンス
        ///// </param>
        ///// <param name="stockListCndtn2">比較するStockListCndtnクラスのインスタンス</param>
        ///// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        ///// <remarks>
        ///// <br>Note　　　　　　 :   StockListCndtnクラスの内容が一致するか比較します</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public static bool Equals(StockListCndtn stockListCndtn1, StockListCndtn stockListCndtn2)
        //{
        //    return ((stockListCndtn1.EnterpriseCode == stockListCndtn2.EnterpriseCode)
        //         && (stockListCndtn1.DepositStockSecCodeList == stockListCndtn2.DepositStockSecCodeList)
        //         && (stockListCndtn1.St_GoodsMakerCd == stockListCndtn2.St_GoodsMakerCd)
        //         && (stockListCndtn1.Ed_GoodsMakerCd == stockListCndtn2.Ed_GoodsMakerCd)
        //         && (stockListCndtn1.St_GoodsNo == stockListCndtn2.St_GoodsNo)
        //         && (stockListCndtn1.Ed_GoodsNo == stockListCndtn2.Ed_GoodsNo)
        //         && (stockListCndtn1.St_WarehouseCode == stockListCndtn2.St_WarehouseCode)
        //         && (stockListCndtn1.Ed_WarehouseCode == stockListCndtn2.Ed_WarehouseCode)
        //         && (stockListCndtn1.St_SupplierStock == stockListCndtn2.St_SupplierStock)
        //         && (stockListCndtn1.Ed_SupplierStock == stockListCndtn2.Ed_SupplierStock)
        //         && (stockListCndtn1.St_TrustCount == stockListCndtn2.St_TrustCount)
        //         && (stockListCndtn1.Ed_TrustCount == stockListCndtn2.Ed_TrustCount)
        //         && (stockListCndtn1.St_ShipmentPosCnt == stockListCndtn2.St_ShipmentPosCnt)
        //         && (stockListCndtn1.Ed_ShipmentPosCnt == stockListCndtn2.Ed_ShipmentPosCnt)
        //         && (stockListCndtn1.St_LargeGoodsGanreCode == stockListCndtn2.St_LargeGoodsGanreCode)
        //         && (stockListCndtn1.Ed_LargeGoodsGanreCode == stockListCndtn2.Ed_LargeGoodsGanreCode)
        //         && (stockListCndtn1.St_MediumGoodsGanreCode == stockListCndtn2.St_MediumGoodsGanreCode)
        //         && (stockListCndtn1.Ed_MediumGoodsGanreCode == stockListCndtn2.Ed_MediumGoodsGanreCode)
        //         && (stockListCndtn1.St_DetailGoodsGanreCode == stockListCndtn2.St_DetailGoodsGanreCode)
        //         && (stockListCndtn1.Ed_DetailGoodsGanreCode == stockListCndtn2.Ed_DetailGoodsGanreCode)
        //         && (stockListCndtn1.St_EnterpriseGanreCode == stockListCndtn2.St_EnterpriseGanreCode)
        //         && (stockListCndtn1.Ed_EnterpriseGanreCode == stockListCndtn2.Ed_EnterpriseGanreCode)
        //         && (stockListCndtn1.St_BLGoodsCode == stockListCndtn2.St_BLGoodsCode)
        //         && (stockListCndtn1.Ed_BLGoodsCode == stockListCndtn2.Ed_BLGoodsCode)
        //         && (stockListCndtn1.St_LastStockDate == stockListCndtn2.St_LastStockDate)
        //         && (stockListCndtn1.Ed_LastStockDate == stockListCndtn2.Ed_LastStockDate)
        //         && (stockListCndtn1.St_LastSalesDate == stockListCndtn2.St_LastSalesDate)
        //         && (stockListCndtn1.Ed_LastSalesDate == stockListCndtn2.Ed_LastSalesDate)
        //         && (stockListCndtn1.St_LastInventoryUpdate == stockListCndtn2.St_LastInventoryUpdate)
        //         && (stockListCndtn1.Ed_LastInventoryUpdate == stockListCndtn2.Ed_LastInventoryUpdate)
        //         && (stockListCndtn1.St_StockCreateDate == stockListCndtn2.St_StockCreateDate)
        //         && (stockListCndtn1.Ed_StockCreateDate == stockListCndtn2.Ed_StockCreateDate)
        //         && (stockListCndtn1.StockDiv == stockListCndtn2.StockDiv)
        //         && (stockListCndtn1.ChangePageDiv == stockListCndtn2.ChangePageDiv)
        //         && (stockListCndtn1.ChangePageDivName == stockListCndtn2.ChangePageDivName)
        //         && (stockListCndtn1.StockPointWay == stockListCndtn2.StockPointWay));
        //}
        //--- DEL 2008.08.01 ----------<<<<<

        //--- DEL 2008.08.01 ---------->>>>>
        ///// <summary>
        ///// 在庫一覧表抽出条件クラス比較処理
        ///// </summary>
        ///// <param name="target">比較対象のStockListCndtnクラスのインスタンス</param>
        ///// <returns>一致しない項目のリスト</returns>
        ///// <remarks>
        ///// <br>Note　　　　　　 :   StockListCndtnクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public ArrayList Compare(StockListCndtn target)
        //{
        //    ArrayList resList = new ArrayList();
        //    if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
        //    if(this.DepositStockSecCodeList != target.DepositStockSecCodeList)resList.Add("DepositStockSecCodeList");
        //    if(this.St_GoodsMakerCd != target.St_GoodsMakerCd)resList.Add("St_GoodsMakerCd");
        //    if(this.Ed_GoodsMakerCd != target.Ed_GoodsMakerCd)resList.Add("Ed_GoodsMakerCd");
        //    if(this.St_GoodsNo != target.St_GoodsNo)resList.Add("St_GoodsNo");
        //    if(this.Ed_GoodsNo != target.Ed_GoodsNo)resList.Add("Ed_GoodsNo");
        //    if(this.St_WarehouseCode != target.St_WarehouseCode)resList.Add("St_WarehouseCode");
        //    if(this.Ed_WarehouseCode != target.Ed_WarehouseCode)resList.Add("Ed_WarehouseCode");
        //    if(this.St_SupplierStock != target.St_SupplierStock)resList.Add("St_SupplierStock");
        //    if(this.Ed_SupplierStock != target.Ed_SupplierStock)resList.Add("Ed_SupplierStock");
        //    if(this.St_TrustCount != target.St_TrustCount)resList.Add("St_TrustCount");
        //    if(this.Ed_TrustCount != target.Ed_TrustCount)resList.Add("Ed_TrustCount");
        //    if(this.St_ShipmentPosCnt != target.St_ShipmentPosCnt)resList.Add("St_ShipmentPosCnt");
        //    if(this.Ed_ShipmentPosCnt != target.Ed_ShipmentPosCnt)resList.Add("Ed_ShipmentPosCnt");
        //    if(this.St_LargeGoodsGanreCode != target.St_LargeGoodsGanreCode)resList.Add("St_LargeGoodsGanreCode");
        //    if(this.Ed_LargeGoodsGanreCode != target.Ed_LargeGoodsGanreCode)resList.Add("Ed_LargeGoodsGanreCode");
        //    if(this.St_MediumGoodsGanreCode != target.St_MediumGoodsGanreCode)resList.Add("St_MediumGoodsGanreCode");
        //    if(this.Ed_MediumGoodsGanreCode != target.Ed_MediumGoodsGanreCode)resList.Add("Ed_MediumGoodsGanreCode");
        //    if(this.St_DetailGoodsGanreCode != target.St_DetailGoodsGanreCode)resList.Add("St_DetailGoodsGanreCode");
        //    if(this.Ed_DetailGoodsGanreCode != target.Ed_DetailGoodsGanreCode)resList.Add("Ed_DetailGoodsGanreCode");
        //    if(this.St_EnterpriseGanreCode != target.St_EnterpriseGanreCode)resList.Add("St_EnterpriseGanreCode");
        //    if(this.Ed_EnterpriseGanreCode != target.Ed_EnterpriseGanreCode)resList.Add("Ed_EnterpriseGanreCode");
        //    if(this.St_BLGoodsCode != target.St_BLGoodsCode)resList.Add("St_BLGoodsCode");
        //    if(this.Ed_BLGoodsCode != target.Ed_BLGoodsCode)resList.Add("Ed_BLGoodsCode");
        //    if(this.St_LastStockDate != target.St_LastStockDate)resList.Add("St_LastStockDate");
        //    if(this.Ed_LastStockDate != target.Ed_LastStockDate)resList.Add("Ed_LastStockDate");
        //    if(this.St_LastSalesDate != target.St_LastSalesDate)resList.Add("St_LastSalesDate");
        //    if(this.Ed_LastSalesDate != target.Ed_LastSalesDate)resList.Add("Ed_LastSalesDate");
        //    if(this.St_LastInventoryUpdate != target.St_LastInventoryUpdate)resList.Add("St_LastInventoryUpdate");
        //    if(this.Ed_LastInventoryUpdate != target.Ed_LastInventoryUpdate)resList.Add("Ed_LastInventoryUpdate");
        //    if(this.St_StockCreateDate != target.St_StockCreateDate)resList.Add("St_StockCreateDate");
        //    if(this.Ed_StockCreateDate != target.Ed_StockCreateDate)resList.Add("Ed_StockCreateDate");
        //    if(this.StockDiv != target.StockDiv)resList.Add("StockDiv");
        //    if(this.ChangePageDiv != target.ChangePageDiv)resList.Add("ChangePageDiv");
        //    if(this.ChangePageDivName != target.ChangePageDivName)resList.Add("ChangePageDivName");
        //    if(this.StockPointWay != target.StockPointWay)resList.Add("StockPointWay");

        //    return resList;
        //}
        //--- DEL 2008.08.01 ----------<<<<<

        //--- DEL 2008.08.01 ---------->>>>>
        ///// <summary>
        ///// 在庫一覧表抽出条件クラス比較処理
        ///// </summary>
        ///// <param name="stockListCndtn1">比較するStockListCndtnクラスのインスタンス</param>
        ///// <param name="stockListCndtn2">比較するStockListCndtnクラスのインスタンス</param>
        ///// <returns>一致しない項目のリスト</returns>
        ///// <remarks>
        ///// <br>Note　　　　　　 :   StockListCndtnクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public static ArrayList Compare(StockListCndtn stockListCndtn1, StockListCndtn stockListCndtn2)
        //{
        //    ArrayList resList = new ArrayList();
        //    if(stockListCndtn1.EnterpriseCode != stockListCndtn2.EnterpriseCode)resList.Add("EnterpriseCode");
        //    if(stockListCndtn1.DepositStockSecCodeList != stockListCndtn2.DepositStockSecCodeList)resList.Add("DepositStockSecCodeList");
        //    if(stockListCndtn1.St_GoodsMakerCd != stockListCndtn2.St_GoodsMakerCd)resList.Add("St_GoodsMakerCd");
        //    if(stockListCndtn1.Ed_GoodsMakerCd != stockListCndtn2.Ed_GoodsMakerCd)resList.Add("Ed_GoodsMakerCd");
        //    if(stockListCndtn1.St_GoodsNo != stockListCndtn2.St_GoodsNo)resList.Add("St_GoodsNo");
        //    if(stockListCndtn1.Ed_GoodsNo != stockListCndtn2.Ed_GoodsNo)resList.Add("Ed_GoodsNo");
        //    if(stockListCndtn1.St_WarehouseCode != stockListCndtn2.St_WarehouseCode)resList.Add("St_WarehouseCode");
        //    if(stockListCndtn1.Ed_WarehouseCode != stockListCndtn2.Ed_WarehouseCode)resList.Add("Ed_WarehouseCode");
        //    if(stockListCndtn1.St_SupplierStock != stockListCndtn2.St_SupplierStock)resList.Add("St_SupplierStock");
        //    if(stockListCndtn1.Ed_SupplierStock != stockListCndtn2.Ed_SupplierStock)resList.Add("Ed_SupplierStock");
        //    if(stockListCndtn1.St_TrustCount != stockListCndtn2.St_TrustCount)resList.Add("St_TrustCount");
        //    if(stockListCndtn1.Ed_TrustCount != stockListCndtn2.Ed_TrustCount)resList.Add("Ed_TrustCount");
        //    if(stockListCndtn1.St_ShipmentPosCnt != stockListCndtn2.St_ShipmentPosCnt)resList.Add("St_ShipmentPosCnt");
        //    if(stockListCndtn1.Ed_ShipmentPosCnt != stockListCndtn2.Ed_ShipmentPosCnt)resList.Add("Ed_ShipmentPosCnt");
        //    if(stockListCndtn1.St_LargeGoodsGanreCode != stockListCndtn2.St_LargeGoodsGanreCode)resList.Add("St_LargeGoodsGanreCode");
        //    if(stockListCndtn1.Ed_LargeGoodsGanreCode != stockListCndtn2.Ed_LargeGoodsGanreCode)resList.Add("Ed_LargeGoodsGanreCode");
        //    if(stockListCndtn1.St_MediumGoodsGanreCode != stockListCndtn2.St_MediumGoodsGanreCode)resList.Add("St_MediumGoodsGanreCode");
        //    if(stockListCndtn1.Ed_MediumGoodsGanreCode != stockListCndtn2.Ed_MediumGoodsGanreCode)resList.Add("Ed_MediumGoodsGanreCode");
        //    if(stockListCndtn1.St_DetailGoodsGanreCode != stockListCndtn2.St_DetailGoodsGanreCode)resList.Add("St_DetailGoodsGanreCode");
        //    if(stockListCndtn1.Ed_DetailGoodsGanreCode != stockListCndtn2.Ed_DetailGoodsGanreCode)resList.Add("Ed_DetailGoodsGanreCode");
        //    if(stockListCndtn1.St_EnterpriseGanreCode != stockListCndtn2.St_EnterpriseGanreCode)resList.Add("St_EnterpriseGanreCode");
        //    if(stockListCndtn1.Ed_EnterpriseGanreCode != stockListCndtn2.Ed_EnterpriseGanreCode)resList.Add("Ed_EnterpriseGanreCode");
        //    if(stockListCndtn1.St_BLGoodsCode != stockListCndtn2.St_BLGoodsCode)resList.Add("St_BLGoodsCode");
        //    if(stockListCndtn1.Ed_BLGoodsCode != stockListCndtn2.Ed_BLGoodsCode)resList.Add("Ed_BLGoodsCode");
        //    if(stockListCndtn1.St_LastStockDate != stockListCndtn2.St_LastStockDate)resList.Add("St_LastStockDate");
        //    if(stockListCndtn1.Ed_LastStockDate != stockListCndtn2.Ed_LastStockDate)resList.Add("Ed_LastStockDate");
        //    if(stockListCndtn1.St_LastSalesDate != stockListCndtn2.St_LastSalesDate)resList.Add("St_LastSalesDate");
        //    if(stockListCndtn1.Ed_LastSalesDate != stockListCndtn2.Ed_LastSalesDate)resList.Add("Ed_LastSalesDate");
        //    if(stockListCndtn1.St_LastInventoryUpdate != stockListCndtn2.St_LastInventoryUpdate)resList.Add("St_LastInventoryUpdate");
        //    if(stockListCndtn1.Ed_LastInventoryUpdate != stockListCndtn2.Ed_LastInventoryUpdate)resList.Add("Ed_LastInventoryUpdate");
        //    if(stockListCndtn1.St_StockCreateDate != stockListCndtn2.St_StockCreateDate)resList.Add("St_StockCreateDate");
        //    if(stockListCndtn1.Ed_StockCreateDate != stockListCndtn2.Ed_StockCreateDate)resList.Add("Ed_StockCreateDate");
        //    if(stockListCndtn1.StockDiv != stockListCndtn2.StockDiv)resList.Add("StockDiv");
        //    if(stockListCndtn1.ChangePageDiv != stockListCndtn2.ChangePageDiv)resList.Add("ChangePageDiv");
        //    if(stockListCndtn1.ChangePageDivName != stockListCndtn2.ChangePageDivName)resList.Add("ChangePageDivName");
        //    if(stockListCndtn1.StockPointWay != stockListCndtn2.StockPointWay)resList.Add("StockPointWay");

        //    return resList;
        //}
        //--- DEL 2008.08.01 ----------<<<<<


        // 2007.10.05 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// 製番管理有無名称取得処理
        ///// </summary>
        ///// <param name="targetDateState">製番管理有無名称ステータス</param>
        ///// <returns>製番管理有無名称</returns>
        ///// <remarks>
        ///// <br>Note       : 製番管理有無名称の取得を行います。</br>
        ///// <br>Programmer : 23010 中村　仁</br>
        ///// <br>Date       : 2007.03.20</br>
        ///// </remarks>
        //public static string GetPrdNumMngDivName( int targetDateState )
        //{
        //    string targetDateName = "";
        //    switch( targetDateState ) {
        //        case 0:
        //        {
        //            targetDateName = "無";
        //            break;
        //        }
        //        case 1:
        //        {
        //            targetDateName = "有";
        //            break;
        //        }
        //    }
        //    return targetDateName;
        //}
        // 2007.10.05 削除 <<<<<<<<<<<<<<<<<<<<

        /// <summary>
		/// ソート名称取得処理
		/// </summary>
		/// <param name="targetDateState">ソート名称ステータス</param>
		/// <returns>ソート名称</returns>
		/// <remarks>
		/// <br>Note       : ソート名称の取得を行います。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.03.15</br>
		/// </remarks>
		public static string GetSortName( int targetDateState )
		{
			string targetDateName = "";
			switch( targetDateState ) {
                //--- DEL 2008/08/01 ---------->>>>>
                //case ( int )PageChangeDiv.Sort_StockDate:
                //{
                //    targetDateName = "最終仕入日順";
                //    break;
                //}
                //--- DEL 2008/08/01 ----------<<<<<
                // 2007.10.05 修正 >>>>>>>>>>>>>>>>>>>>
				//case ( int )PageChangeDiv.Sort_CarrierCode:
				//{
				//	targetDateName = "キャリア順";
				//	break;
				//}
                //case ( int )PageChangeDiv.Sort_LargeMediumGoodsGanreCode:
				//{
				//	targetDateName = "商品区分グループ・区分順";
				//	break;
				//}
                //--- DEL 2008/08/01 ---------->>>>>
                //case (int)PageChangeDiv.Sort_LargeGoodsGanreCode:
                //{
                //    targetDateName = "商品区分グループ・区分・詳細区分順";
                //    break;
                //}
                //case (int)PageChangeDiv.Sort_WarehouseCode:
                //{
                //    targetDateName = "倉庫順";
                //    break;
                //}
                //case ( int )PageChangeDiv.Sort_EnterpriseGanreCode:
                //{
                //    targetDateName = "自社分類順";
                //    break;
                //}
                //case ( int )PageChangeDiv.Sort_BLGoodsCode:
                //{
                //    targetDateName = "ＢＬコード順";
                //    break;
                //}
                //// 2007.10.05 修正 <<<<<<<<<<<<<<<<<<<<
                //case ( int )PageChangeDiv.Sort_MakerCode:
                //{
                //    targetDateName = "メーカー順";
                //    break;
                //}
                //case ( int )PageChangeDiv.Sort_ShipmentPosCnt:
                //{
                //    targetDateName = "出荷可能数順";
                //    break;
                //}
                //--- DEL 2008/08/01 ----------<<<<<
                // 2007.10.05 削除 >>>>>>>>>>>>>>>>>>>>
                //case ( int )PageChangeDiv.Sort_CellPhoneModeleCode:
				//{
				//	targetDateName = "機種順";
				//	break;
				//}
                // 2007.10.05 削除 <<<<<<<<<<<<<<<<<<<<
                //--- ADD 2008/08/01 ---------->>>>>
                case (int)PageChangeDiv.Sort_SupplierCode:
                {
                    targetDateName = "仕入先順";
                    break;
                }
                case (int)PageChangeDiv.Sort_WarehouseCode:
                {
                    targetDateName = "棚番順";
                    break;
                }
                //--- ADD 2008/08/01 ----------<<<<<

			}
			return targetDateName;
		}
                                   
        /// <summary>
		/// ソート計名称取得処理
		/// </summary>
		/// <param name="targetDateState">ソート名称ステータス</param>
		/// <returns>ソート計名称</returns>
		/// <remarks>
		/// <br>Note       : ソート計名称の取得を行います。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.03.15</br>
		/// </remarks>
		public static string GetSortTotalName( int targetDateState )
		{
			string targetDateName = "";
			switch( targetDateState ) {
				case ( int )PageChangeDivTitle.Sort_StockDateTitle:
				{
					targetDateName = "最終仕入日計";
					break;
				}
                // 2007.10.05 削除 >>>>>>>>>>>>>>>>>>>>
                //case (int)PageChangeDivTitle.Sort_CarrierTitle:
                //{
                //	targetDateName = "キャリア計";
                //	break;
                //}
                // 2007.10.05 削除 <<<<<<<<<<<<<<<<<<<<
                case (int)PageChangeDivTitle.Sort_LargeGoodsGanreTitle:
				{
					targetDateName = "商品区分グループ計";
					break;
				}
                case ( int )PageChangeDivTitle.Sort_MakerTitle:
				{
					targetDateName = "メーカー計";
					break;
				}
                // 2007.10.05 削除 >>>>>>>>>>>>>>>>>>>>
                //case (int)PageChangeDivTitle.Sort_CellPhoneModeleCodeTitle:
                //{
                //	targetDateName = "機種計";
                //	break;
                //}
                // 2007.10.05 削除 <<<<<<<<<<<<<<<<<<<<
                case (int)PageChangeDivTitle.Sort_ShipmentPosCntTitle:
				{
					targetDateName = "出荷可能数計";
					break;
				}
                case ( int )PageChangeDivTitle.Sort_MediumGoodsGanreTitle:
				{
					targetDateName = "商品区分計";
					break;
				}
                // 2007.10.05 追加 >>>>>>>>>>>>>>>>>>>>
                case (int)PageChangeDivTitle.Sort_DetailGoodsGanreTitle:
                {
                    targetDateName = "商品区分詳細計";
                    break;
                }
                case (int)PageChangeDivTitle.Sort_EnterpriseGanreTitle:
                {
                    targetDateName = "自社分類計";
                    break;
                }
                case (int)PageChangeDivTitle.Sort_BLGoodsTitle:
                {
                    targetDateName = "ＢＬコード計";
                    break;
                }
                case (int)PageChangeDivTitle.Sort_WarehouseTitle:
                {
                    targetDateName = "倉庫計";
                    break;
                }
                // 2007.10.05 追加 <<<<<<<<<<<<<<<<<<<<
        }
			return targetDateName;
		}


        // 2007.10.05 削除 >>>>>>>>>>>>>>>>>>>>
        ///// <summary>
		///// 在庫状態取得処理
		///// </summary>
		///// <param name="targetDateState">在庫状態ステータス</param>
		///// <returns>在庫状態</returns>
		///// <remarks>
		///// <br>Note       : 在庫状態の取得を行います。</br>
		///// <br>Programmer : 23010 中村　仁</br>
		///// <br>Date       : 2007.03.16</br>
		///// </remarks>
		//public static int GetStockDiv( int targetDateState )
		//{
		//	int targetStockDiv = -1;
		//	switch( targetDateState ) {
		//		case 0:
		//		{
        //            //全て
		//			targetStockDiv = (int)StockDivStatus.StockDiv_ALLStock;
		//			break;
		//		}
		//		case 1:
		//		{
        //            //仕入在庫分
		//			targetStockDiv = (int)StockDivStatus.StockDiv_MyStock;
		//			break;
		//		}
        //        case 2:
		//		{
        //            //受託在庫分
        //			targetStockDiv = (int)StockDivStatus.StockDiv_TrustStock;
        //			break;
        //		}               
        //	}
        //	return targetStockDiv;
        //}
        // 2007.10.05 削除 <<<<<<<<<<<<<<<<<<<<

        /// <summary>
		/// 在庫区分名称取得処理
		/// </summary>
		/// <param name="targetDateState">在庫区分名称ステータス</param>
		/// <returns>在庫区分名称</returns>
		/// <remarks>
		/// <br>Note       : 在庫区分名称の取得を行います。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.03.16</br>
		/// </remarks>
		public static string GetStockDivName( int targetDateState )
		{
			string targetDateName = "";
			switch( targetDateState ) {
				case ( int )StockDivStatus.StockDiv_ALLStock:
				{
					targetDateName = "全て";
					break;
				}
				case ( int )StockDivStatus.StockDiv_MyStock:
				{
					targetDateName = "仕入在庫分";
					break;
				}
                case ( int )StockDivStatus.StockDiv_TrustStock:
				{
					targetDateName = "受託在庫分";
					break;
				}              
			}
			return targetDateName;
		}

        #endregion
    }
}

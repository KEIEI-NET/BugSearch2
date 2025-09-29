using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   InventoryExtCndtnWork
    /// <summary>
    ///                      棚卸データ(準備処理履歴)検索条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   棚卸データ(準備処理履歴)検索条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/03/19  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2009/11/30 張凱 保守依頼③対応</br>
    /// <br>                     棚卸印刷順初期設定区分、棚卸運用区分を追加</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class InventoryExtCndtnWork
    {
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		private string _sectionCode = "";

        //-----ADD 2011/01/11----->>>>>
        /// <summary>開始管理拠点コード</summary>
        private string _sectionCodeSt = "";

        /// <summary>終了管理拠点コード</summary>
        private string _sectionCodeEd = "";
        //-----ADD 2011/01/11-----<<<<<

		/// <summary>棚卸準備処理日付</summary>
		private DateTime _inventoryPreprDay;

		/// <summary>棚卸準備処理時間</summary>
		private Int32 _inventoryPreprTim;

		/// <summary>棚卸処理区分</summary>
		private Int32 _inventoryProcDiv;

		/// <summary>棚卸日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _inventoryDate;

		/// <summary>倉庫指定区分</summary>
		/// <remarks>0:範囲,1:単独</remarks>
		private Int32 _warehouseDiv;

		/// <summary>倉庫コード開始</summary>
		private string _stWarehouseCd = "";

		/// <summary>倉庫コード終了</summary>
		private string _edWarehouseCd = "";

		/// <summary>倉庫コード01</summary>
		private string _warehouseCd01 = "";

		/// <summary>倉庫コード02</summary>
		private string _warehouseCd02 = "";

		/// <summary>倉庫コード03</summary>
		private string _warehouseCd03 = "";

		/// <summary>倉庫コード04</summary>
		private string _warehouseCd04 = "";

		/// <summary>倉庫コード05</summary>
		private string _warehouseCd05 = "";

		/// <summary>倉庫コード06</summary>
		private string _warehouseCd06 = "";

		/// <summary>倉庫コード07</summary>
		private string _warehouseCd07 = "";

		/// <summary>倉庫コード08</summary>
		private string _warehouseCd08 = "";

		/// <summary>倉庫コード09</summary>
		private string _warehouseCd09 = "";

		/// <summary>倉庫コード10</summary>
		private string _warehouseCd10 = "";

		/// <summary>棚番開始</summary>
		private string _stWarehouseShelfNo = "";

		/// <summary>棚番終了</summary>
		private string _edWarehouseShelfNo = "";

		/// <summary>メーカーコード開始</summary>
		/// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
		private Int32 _stMakerCd;

		/// <summary>メーカーコード終了</summary>
		/// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
		private Int32 _edMakerCd;

		/// <summary>ＢＬ商品コード開始</summary>
		private Int32 _stBLGoodsCd;

		/// <summary>ＢＬ商品コード終了</summary>
		private Int32 _edBLGoodsCd;

		/// <summary>グループコード開始</summary>
		private Int32 _stBLGroupCode;

		/// <summary>グループコード終了</summary>
		private Int32 _edBLGroupCode;

		/// <summary>得意先コード開始</summary>
		/// <remarks>※仕入先コードとして使用</remarks>
		private Int32 _stCustomerCd;

		/// <summary>得意先コード終了</summary>
		/// <remarks>※仕入先コードとして使用</remarks>
		private Int32 _edCustomerCd;

		/// <summary>最終棚卸更新日開始</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _stLtInventoryUpdate;

		/// <summary>最終棚卸更新日終了</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _edLtInventoryUpdate;

		/// <summary>在庫評価方法</summary>
		/// <remarks>1:最終仕入原価法,2:移動平均法,3:個別単価法</remarks>
		private Int32 _stockPointWay;

        // --- ADD 2009/11/30 ---------->>>>>
        /// <summary>棚卸印刷順初期設定区分</summary>
        /// <remarks>0:棚番順,1:仕入先順,2:BLｺｰﾄﾞ順,3:ｸﾞﾙｰﾌﾟｺｰﾄﾞ順,4:ﾒｰｶｰ順,5:仕入先･棚番順,6:仕入先･ﾒｰｶｰ順</remarks>
        private Int32 _invntryPrtOdrIniDiv;

        /// <summary>棚卸運用区分</summary>
        /// <remarks>0：ＰＭ．ＮＳ　1：ＰＭ７</remarks>
        private Int32 _inventoryMngDiv;
        // --- ADD 2009/11/30 ----------<<<<<


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
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
		}

		/// public propaty name  :  SectionCode
		/// <summary>拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
		}

        //-----ADD 2011/01/11----->>>>>
        /// public propaty name  :  SectionCodeSt
        /// <summary>開始管理拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始管理拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCodeSt
        {
            get { return _sectionCodeSt; }
            set { _sectionCodeSt = value; }
        }

        /// public propaty name  :  SectionCodeEd
        /// <summary>終了管理拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了管理拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCodeEd
        {
            get { return _sectionCodeEd; }
            set { _sectionCodeEd = value; }
        }
        //-----ADD 2011/01/11-----<<<<<

		/// public propaty name  :  InventoryPreprDay
		/// <summary>棚卸準備処理日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   棚卸準備処理日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime InventoryPreprDay
		{
			get{return _inventoryPreprDay;}
			set{_inventoryPreprDay = value;}
		}

		/// public propaty name  :  InventoryPreprTim
		/// <summary>棚卸準備処理時間プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   棚卸準備処理時間プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InventoryPreprTim
		{
			get{return _inventoryPreprTim;}
			set{_inventoryPreprTim = value;}
		}

		/// public propaty name  :  InventoryProcDiv
		/// <summary>棚卸処理区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   棚卸処理区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InventoryProcDiv
		{
			get{return _inventoryProcDiv;}
			set{_inventoryProcDiv = value;}
		}

		/// public propaty name  :  InventoryDate
		/// <summary>棚卸日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   棚卸日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime InventoryDate
		{
			get{return _inventoryDate;}
			set{_inventoryDate = value;}
		}

		/// public propaty name  :  WarehouseDiv
		/// <summary>倉庫指定区分プロパティ</summary>
		/// <value>0:範囲,1:単独</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫指定区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 WarehouseDiv
		{
			get{return _warehouseDiv;}
			set{_warehouseDiv = value;}
		}

		/// public propaty name  :  StWarehouseCd
		/// <summary>倉庫コード開始プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫コード開始プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StWarehouseCd
		{
			get{return _stWarehouseCd;}
			set{_stWarehouseCd = value;}
		}

		/// public propaty name  :  EdWarehouseCd
		/// <summary>倉庫コード終了プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫コード終了プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EdWarehouseCd
		{
			get{return _edWarehouseCd;}
			set{_edWarehouseCd = value;}
		}

		/// public propaty name  :  WarehouseCd01
		/// <summary>倉庫コード01プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫コード01プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string WarehouseCd01
		{
			get{return _warehouseCd01;}
			set{_warehouseCd01 = value;}
		}

		/// public propaty name  :  WarehouseCd02
		/// <summary>倉庫コード02プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫コード02プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string WarehouseCd02
		{
			get{return _warehouseCd02;}
			set{_warehouseCd02 = value;}
		}

		/// public propaty name  :  WarehouseCd03
		/// <summary>倉庫コード03プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫コード03プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string WarehouseCd03
		{
			get{return _warehouseCd03;}
			set{_warehouseCd03 = value;}
		}

		/// public propaty name  :  WarehouseCd04
		/// <summary>倉庫コード04プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫コード04プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string WarehouseCd04
		{
			get{return _warehouseCd04;}
			set{_warehouseCd04 = value;}
		}

		/// public propaty name  :  WarehouseCd05
		/// <summary>倉庫コード05プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫コード05プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string WarehouseCd05
		{
			get{return _warehouseCd05;}
			set{_warehouseCd05 = value;}
		}

		/// public propaty name  :  WarehouseCd06
		/// <summary>倉庫コード06プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫コード06プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string WarehouseCd06
		{
			get{return _warehouseCd06;}
			set{_warehouseCd06 = value;}
		}

		/// public propaty name  :  WarehouseCd07
		/// <summary>倉庫コード07プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫コード07プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string WarehouseCd07
		{
			get{return _warehouseCd07;}
			set{_warehouseCd07 = value;}
		}

		/// public propaty name  :  WarehouseCd08
		/// <summary>倉庫コード08プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫コード08プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string WarehouseCd08
		{
			get{return _warehouseCd08;}
			set{_warehouseCd08 = value;}
		}

		/// public propaty name  :  WarehouseCd09
		/// <summary>倉庫コード09プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫コード09プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string WarehouseCd09
		{
			get{return _warehouseCd09;}
			set{_warehouseCd09 = value;}
		}

		/// public propaty name  :  WarehouseCd10
		/// <summary>倉庫コード10プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫コード10プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string WarehouseCd10
		{
			get{return _warehouseCd10;}
			set{_warehouseCd10 = value;}
		}

		/// public propaty name  :  StWarehouseShelfNo
		/// <summary>棚番開始プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   棚番開始プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StWarehouseShelfNo
		{
			get{return _stWarehouseShelfNo;}
			set{_stWarehouseShelfNo = value;}
		}

		/// public propaty name  :  EdWarehouseShelfNo
		/// <summary>棚番終了プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   棚番終了プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EdWarehouseShelfNo
		{
			get{return _edWarehouseShelfNo;}
			set{_edWarehouseShelfNo = value;}
		}

		/// public propaty name  :  StMakerCd
		/// <summary>メーカーコード開始プロパティ</summary>
		/// <value>1～899:提供分, 900～ユーザー登録</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカーコード開始プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StMakerCd
		{
			get{return _stMakerCd;}
			set{_stMakerCd = value;}
		}

		/// public propaty name  :  EdMakerCd
		/// <summary>メーカーコード終了プロパティ</summary>
		/// <value>1～899:提供分, 900～ユーザー登録</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカーコード終了プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EdMakerCd
		{
			get{return _edMakerCd;}
			set{_edMakerCd = value;}
		}

		/// public propaty name  :  StBLGoodsCd
		/// <summary>ＢＬ商品コード開始プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ＢＬ商品コード開始プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StBLGoodsCd
		{
			get{return _stBLGoodsCd;}
			set{_stBLGoodsCd = value;}
		}

		/// public propaty name  :  EdBLGoodsCd
		/// <summary>ＢＬ商品コード終了プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ＢＬ商品コード終了プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EdBLGoodsCd
		{
			get{return _edBLGoodsCd;}
			set{_edBLGoodsCd = value;}
		}

		/// public propaty name  :  StBLGroupCode
		/// <summary>グループコード開始プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   グループコード開始プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StBLGroupCode
		{
			get{return _stBLGroupCode;}
			set{_stBLGroupCode = value;}
		}

		/// public propaty name  :  EdBLGroupCode
		/// <summary>グループコード終了プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   グループコード終了プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EdBLGroupCode
		{
			get{return _edBLGroupCode;}
			set{_edBLGroupCode = value;}
		}

		/// public propaty name  :  StCustomerCd
		/// <summary>得意先コード開始プロパティ</summary>
		/// <value>※仕入先コードとして使用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先コード開始プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StCustomerCd
		{
			get{return _stCustomerCd;}
			set{_stCustomerCd = value;}
		}

		/// public propaty name  :  EdCustomerCd
		/// <summary>得意先コード終了プロパティ</summary>
		/// <value>※仕入先コードとして使用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先コード終了プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EdCustomerCd
		{
			get{return _edCustomerCd;}
			set{_edCustomerCd = value;}
		}

		/// public propaty name  :  StLtInventoryUpdate
		/// <summary>最終棚卸更新日開始プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   最終棚卸更新日開始プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime StLtInventoryUpdate
		{
			get{return _stLtInventoryUpdate;}
			set{_stLtInventoryUpdate = value;}
		}

		/// public propaty name  :  EdLtInventoryUpdate
		/// <summary>最終棚卸更新日終了プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   最終棚卸更新日終了プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime EdLtInventoryUpdate
		{
			get{return _edLtInventoryUpdate;}
			set{_edLtInventoryUpdate = value;}
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
			get{return _stockPointWay;}
			set{_stockPointWay = value;}
		}

        // --- ADD 2009/11/30 ---------->>>>>
        /// public propaty name  :  InvntryPrtOdrIniDiv
        /// <summary>棚卸印刷順初期設定区分プロパティ</summary>
        /// <value>0:棚番順,1:仕入先順,2:BLｺｰﾄﾞ順,3:ｸﾞﾙｰﾌﾟｺｰﾄﾞ順,4:ﾒｰｶｰ順,5:仕入先･棚番順,6:仕入先･ﾒｰｶｰ順</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸印刷順初期設定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InvntryPrtOdrIniDiv
        {
            get { return _invntryPrtOdrIniDiv; }
            set { _invntryPrtOdrIniDiv = value; }
        }

        /// public propaty name  :  InventoryMngDiv
        /// <summary>棚卸運用区分プロパティ</summary>
        /// <value>0：ＰＭ．ＮＳ　1：ＰＭ７</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸運用区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InventoryMngDiv
        {
            get { return _inventoryMngDiv; }
            set { _inventoryMngDiv = value; }
        }
        // --- ADD 2009/11/30 ----------<<<<<

		/// <summary>
		/// 棚卸データ(準備処理履歴)検索条件ワークコンストラクタ
		/// </summary>
		/// <returns>InventoryExtCndtnWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   InventoryExtCndtnWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public InventoryExtCndtnWork()
		{
		}
    }
}

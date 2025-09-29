using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   InventSearchCndtnUI
	/// <summary>
	///                      棚卸関連帳票抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   棚卸関連帳票抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/09/14  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2010/02/20 呉元嘯</br>
    /// <br>			         不具合対応(PM1005)</br>
    /// <br>Update Note      :   2011/01/11 liyp</br>
    /// <br>			         出力条件に数量と棚番に関する条件指定を追加する（要望）</br>
    /// <br>Update Note      :   2012/11/14 李亜博</br>
    ///	<br>			         2013/01/16配信分、Redmine#33271 印字制御の区分の追加</br> 
    /// </remarks>
	public class InventSearchCndtnUI
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>拠点コード</summary>
		private string _sectionCode = "";

		/// <summary>在庫更新拠点名称</summary>
		private string _inventorySectionName = "";

		/// <summary>メーカーコード開始</summary>
		/// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
		private Int32 _st_MakerCode;

		/// <summary>メーカーコード終了</summary>
		/// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
		private Int32 _ed_MakerCode;

		/// <summary>商品番号開始</summary>
		private string _st_GoodsNo = "";

		/// <summary>商品番号終了</summary>
		private string _ed_GoodsNo = "";

        ///// <summary>商品区分グループコード開始</summary>
        //private string _st_LargeGoodsGanreCode = "";

        ///// <summary>商品区分グループコード終了</summary>
        //private string _ed_LargeGoodsGanreCode = "";

        ///// <summary>商品区分コード開始</summary>
        //private string _st_MediumGoodsGanreCode = "";

        ///// <summary>商品区分コード終了</summary>
        //private string _ed_MediumGoodsGanreCode = "";

        ///// <summary>商品区分詳細コード開始</summary>
        //private string _st_DetailGoodsGanreCode = "";

        ///// <summary>商品区分詳細コード終了</summary>
        //private string _ed_DetailGoodsGanreCode = "";

		/// <summary>倉庫コード開始</summary>
		private string _st_WarehouseCode = "";

		/// <summary>倉庫コード終了</summary>
		private string _ed_WarehouseCode = "";

		/// <summary>棚番開始</summary>
		private string _st_WarehouseShelfNo = "";

		/// <summary>棚番終了</summary>
		private string _ed_WarehouseShelfNo = "";

		/// <summary>自社分類コード開始</summary>
		private Int32 _st_EnterpriseGanreCode;

		/// <summary>自社分類コード終了</summary>
		private Int32 _ed_EnterpriseGanreCode;

		/// <summary>ＢＬ商品コード開始</summary>
		private Int32 _st_BLGoodsCode;

		/// <summary>ＢＬ商品コード終了</summary>
		private Int32 _ed_BLGoodsCode;

        ///// <summary>得意先コード開始</summary>
        //private Int32 _st_CustomerCode;

        ///// <summary>得意先コード終了</summary>
        //private Int32 _ed_CustomerCode;

        ///// <summary>出荷先得意先コード開始</summary>
        //private Int32 _st_ShipCustomerCode;

        ///// <summary>出荷先得意先コード終了</summary>
        //private Int32 _ed_ShipCustomerCode;

        /// <summary>開始仕入先コード</summary>
        private Int32 _st_SupplierCd;

        /// <summary>終了仕入先コード</summary>
        private Int32 _ed_SupplierCd;

		/// <summary>開始棚卸準備処理日付(Int)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _st_InventoryPreprDay;

		/// <summary>開始棚卸準備処理日付(DateTime)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _st_InventoryPreprDayDateTime;

		/// <summary>終了棚卸準備処理日付(Int)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _ed_InventoryPreprDay;

		/// <summary>終了棚卸準備処理日付(DateTime)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _ed_InventoryPreprDayDateTime;

		/// <summary>開始棚卸実施日(Int)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _st_InventoryDay;

		/// <summary>開始棚卸実施日(DateTime)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _st_InventoryDayDateTime;

		/// <summary>終了棚卸実施日(Int)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _ed_InventoryDay;

		/// <summary>終了棚卸実施日(DateTime)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _ed_InventoryDayDateTime;

        /// <summary>棚卸日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _inventoryDate;


		/// <summary>開始棚卸通番</summary>
		private Int32 _st_InventorySeqNo;

		/// <summary>終了棚卸通番</summary>
		private Int32 _ed_InventorySeqNo;

        /// <summary>開始グループコード</summary>
        private Int32 _st_BLGroupCode;

        /// <summary>終了グループコード</summary>
        private Int32 _ed_BLGroupCode;

		/// <summary>差異分抽出区分</summary>
		/// <remarks>0:全て,1:数未入力分のみ,2:数入力分のみ,3:差異分のみ</remarks>
		private Int32 _difCntExtraDiv;

		/// <summary>在庫数0抽出区分</summary>
		/// <remarks>0:抽出する,1:抽出しない</remarks>
		private Int32 _stockCntZeroExtraDiv;

		/// <summary>棚卸在庫数0抽出区分</summary>
		/// <remarks>0:抽出する,1:抽出しない</remarks>
		private Int32 _ivtStkCntZeroExtraDiv;

		/// <summary>帳票種別</summary>
		/// <remarks>0:棚卸記入表、1:棚卸差異表、2:棚卸表</remarks>
		private Int32 _selectedPaperKind;

		/// <summary>出力指定区分</summary>
		/// <remarks>0:全て,1:棚卸未入力のみ,2:差異分のみ,3:重複棚番ありのみ</remarks>
		private Int32 _outputAppointDiv;

		/// <summary>抽出対象日付区分</summary>
		/// <remarks>0:棚卸準備処理日,1:棚卸実施日,2:棚卸更新日</remarks>
		private Int32 _targetDateExtraDiv;

        /// <summary>在庫数算出フラグ</summary>
        /// <remarks>0:在庫数算出しない, 1:在庫数算出する</remarks>
        private Int32 _calcStockAmountDiv;

        /// <summary>在庫数算出日付</summary>
        /// <remarks>在庫数算出フラグ=1のときの在庫数算出日付</remarks>
        private DateTime _calcStockAmountDate;

        /// <summary>在庫区分</summary>
        /// <remarks>0:全て,1:自社,2:受託</remarks>
        private Int32 _stockDiv;

        /// <summary>貸出抽出区分</summary>
        /// <remarks>0:印刷しない,1:印刷する</remarks>
        private Int32 _lendExtraDiv;

        /// <summary>来勘計上抽出区分</summary>
        /// <remarks>0:印刷しない,1:印刷する</remarks>
        private Int32 _delayPaymentDiv;

		/// <summary>ソート順</summary>
		private Int32 _sortDiv;

        ///// <summary>帳簿在庫印字区分</summary>
        ///// <remarks>0:印字する、1:印字しない</remarks>
        //private Int32 _stockCntPrintDiv;

        ///// <summary>得意先印字区分</summary>
        ///// <remarks>0:仕入先,1:委託先</remarks>
        //private Int32 _customerPrintDiv;

        ///// <summary>棚卸未入力区分</summary>
        ///// <remarks>0:未入力扱い,1:帳簿数と同じ</remarks>
        //private Int32 _inventoryInputDiv;

		/// <summary>改ページ指定区分</summary>
		/// <remarks>0:倉庫,1:印刷順,2:しない</remarks>
		private Int32 _turnOoverThePagesDiv;

		/// <summary>棚番ブレイク区分</summary>
		private Int32 _shelfNoBreakDiv;

        /// <summary>棚卸未入力区分</summary>
        private Int32 _inventoryNonInputDiv;

        /// <summary>小計印字区分</summary>
        private Int32 _subtotalPrintDiv;

        // -----------ADD 2010/02/20----------->>>>>
        /// <summary>計印字区分</summary>
        private Int32 _subtotalPrintDivTemp;
        // -----------ADD 2010/02/20-----------<<<<<

        // -----------ADD 2011/01/11----------->>>>>
        /// <summary>数量出力区分</summary>
        private Int32 _numOutputDiv;

        /// <summary>棚番出力区分</summary>
        private Int32 _warehouseShelfOutputDiv;
        // -----------ADD 2011/01/11-----------<<<<<
        // --- ADD 李亜博 2012/11/14 for Redmine#33271---------->>>>>
        /// <summary>罫線印字区分</summary>
        private Int32 _lineMaSqOfChDiv;
        // --- ADD 李亜博 2012/11/14 for Redmine#33271----------<<<<<

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

		/// public propaty name  :  EnterpriseName
		/// <summary>企業名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   企業名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EnterpriseName
		{
			get{return _enterpriseName;}
			set{_enterpriseName = value;}
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

		/// public propaty name  :  InventorySectionName
		/// <summary>在庫更新拠点名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫更新拠点名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InventorySectionName
		{
			get{return _inventorySectionName;}
			set{_inventorySectionName = value;}
		}

		/// public propaty name  :  St_MakerCode
		/// <summary>メーカーコード開始プロパティ</summary>
		/// <value>1～899:提供分, 900～ユーザー登録</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカーコード開始プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_MakerCode
		{
			get{return _st_MakerCode;}
			set{_st_MakerCode = value;}
		}

		/// public propaty name  :  Ed_MakerCode
		/// <summary>メーカーコード終了プロパティ</summary>
		/// <value>1～899:提供分, 900～ユーザー登録</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカーコード終了プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_MakerCode
		{
			get{return _ed_MakerCode;}
			set{_ed_MakerCode = value;}
		}

		/// public propaty name  :  St_GoodsNo
		/// <summary>商品番号開始プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品番号開始プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_GoodsNo
		{
			get{return _st_GoodsNo;}
			set{_st_GoodsNo = value;}
		}

		/// public propaty name  :  Ed_GoodsNo
		/// <summary>商品番号終了プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品番号終了プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_GoodsNo
		{
			get{return _ed_GoodsNo;}
			set{_ed_GoodsNo = value;}
		}

        ///// public propaty name  :  St_LargeGoodsGanreCode
        ///// <summary>商品区分グループコード開始プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   商品区分グループコード開始プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string St_LargeGoodsGanreCode
        //{
        //    get{return _st_LargeGoodsGanreCode;}
        //    set{_st_LargeGoodsGanreCode = value;}
        //}

        ///// public propaty name  :  Ed_LargeGoodsGanreCode
        ///// <summary>商品区分グループコード終了プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   商品区分グループコード終了プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string Ed_LargeGoodsGanreCode
        //{
        //    get{return _ed_LargeGoodsGanreCode;}
        //    set{_ed_LargeGoodsGanreCode = value;}
        //}

        ///// public propaty name  :  St_MediumGoodsGanreCode
        ///// <summary>商品区分コード開始プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   商品区分コード開始プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string St_MediumGoodsGanreCode
        //{
        //    get{return _st_MediumGoodsGanreCode;}
        //    set{_st_MediumGoodsGanreCode = value;}
        //}

        ///// public propaty name  :  Ed_MediumGoodsGanreCode
        ///// <summary>商品区分コード終了プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   商品区分コード終了プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string Ed_MediumGoodsGanreCode
        //{
        //    get{return _ed_MediumGoodsGanreCode;}
        //    set{_ed_MediumGoodsGanreCode = value;}
        //}

        ///// public propaty name  :  St_DetailGoodsGanreCode
        ///// <summary>商品区分詳細コード開始プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   商品区分詳細コード開始プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string St_DetailGoodsGanreCode
        //{
        //    get{return _st_DetailGoodsGanreCode;}
        //    set{_st_DetailGoodsGanreCode = value;}
        //}

        ///// public propaty name  :  Ed_DetailGoodsGanreCode
        ///// <summary>商品区分詳細コード終了プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   商品区分詳細コード終了プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string Ed_DetailGoodsGanreCode
        //{
        //    get{return _ed_DetailGoodsGanreCode;}
        //    set{_ed_DetailGoodsGanreCode = value;}
        //}

		/// public propaty name  :  St_WarehouseCode
		/// <summary>倉庫コード開始プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫コード開始プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_WarehouseCode
		{
			get{return _st_WarehouseCode;}
			set{_st_WarehouseCode = value;}
		}

		/// public propaty name  :  Ed_WarehouseCode
		/// <summary>倉庫コード終了プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫コード終了プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_WarehouseCode
		{
			get{return _ed_WarehouseCode;}
			set{_ed_WarehouseCode = value;}
		}

		/// public propaty name  :  St_WarehouseShelfNo
		/// <summary>棚番開始プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   棚番開始プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string St_WarehouseShelfNo
		{
			get{return _st_WarehouseShelfNo;}
			set{_st_WarehouseShelfNo = value;}
		}

		/// public propaty name  :  Ed_WarehouseShelfNo
		/// <summary>棚番終了プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   棚番終了プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Ed_WarehouseShelfNo
		{
			get{return _ed_WarehouseShelfNo;}
			set{_ed_WarehouseShelfNo = value;}
		}

		/// public propaty name  :  St_EnterpriseGanreCode
		/// <summary>自社分類コード開始プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自社分類コード開始プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_EnterpriseGanreCode
		{
			get{return _st_EnterpriseGanreCode;}
			set{_st_EnterpriseGanreCode = value;}
		}

		/// public propaty name  :  Ed_EnterpriseGanreCode
		/// <summary>自社分類コード終了プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自社分類コード終了プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_EnterpriseGanreCode
		{
			get{return _ed_EnterpriseGanreCode;}
			set{_ed_EnterpriseGanreCode = value;}
		}

		/// public propaty name  :  St_BLGoodsCode
		/// <summary>ＢＬ商品コード開始プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ＢＬ商品コード開始プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_BLGoodsCode
		{
			get{return _st_BLGoodsCode;}
			set{_st_BLGoodsCode = value;}
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
			get{return _ed_BLGoodsCode;}
			set{_ed_BLGoodsCode = value;}
		}

        ///// public propaty name  :  St_CustomerCode
        ///// <summary>得意先コード開始プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   得意先コード開始プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 St_CustomerCode
        //{
        //    get{return _st_CustomerCode;}
        //    set{_st_CustomerCode = value;}
        //}

        ///// public propaty name  :  Ed_CustomerCode
        ///// <summary>得意先コード終了プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   得意先コード終了プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 Ed_CustomerCode
        //{
        //    get{return _ed_CustomerCode;}
        //    set{_ed_CustomerCode = value;}
        //}

        ///// public propaty name  :  St_ShipCustomerCode
        ///// <summary>出荷先得意先コード開始プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   出荷先得意先コード開始プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 St_ShipCustomerCode
        //{
        //    get{return _st_ShipCustomerCode;}
        //    set{_st_ShipCustomerCode = value;}
        //}

        ///// public propaty name  :  Ed_ShipCustomerCode
        ///// <summary>出荷先得意先コード終了プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   出荷先得意先コード終了プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 Ed_ShipCustomerCode
        //{
        //    get{return _ed_ShipCustomerCode;}
        //    set{_ed_ShipCustomerCode = value;}
        //}

        /// public propaty name  :  St_SupplierCd
        /// <summary>開始仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_SupplierCd
        {
            get { return _st_SupplierCd; }
            set { _st_SupplierCd = value; }
        }

        /// public propaty name  :  Ed_SupplierCd
        /// <summary>終了仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_SupplierCd
        {
            get { return _ed_SupplierCd; }
            set { _ed_SupplierCd = value; }
        }

		/// public propaty name  :  St_InventoryPreprDay
		/// <summary>開始棚卸準備処理日付(Int)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始棚卸準備処理日付(Int)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_InventoryPreprDay
		{
			get{return _st_InventoryPreprDay;}
			set{_st_InventoryPreprDay = value;}
		}

		/// public propaty name  :  St_InventoryPreprDayDateTime
		/// <summary>開始棚卸準備処理日付(DateTime)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始棚卸準備処理日付(DateTime)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime St_InventoryPreprDayDateTime
		{
			get{return _st_InventoryPreprDayDateTime;}
			set{_st_InventoryPreprDayDateTime = value;}
		}

		/// public propaty name  :  Ed_InventoryPreprDay
		/// <summary>終了棚卸準備処理日付(Int)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了棚卸準備処理日付(Int)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_InventoryPreprDay
		{
			get{return _ed_InventoryPreprDay;}
			set{_ed_InventoryPreprDay = value;}
		}

		/// public propaty name  :  Ed_InventoryPreprDayDateTime
		/// <summary>終了棚卸準備処理日付(DateTime)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了棚卸準備処理日付(DateTime)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime Ed_InventoryPreprDayDateTime
		{
			get{return _ed_InventoryPreprDayDateTime;}
			set{_ed_InventoryPreprDayDateTime = value;}
		}

		/// public propaty name  :  St_InventoryDay
		/// <summary>開始棚卸実施日(Int)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始棚卸実施日(Int)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_InventoryDay
		{
			get{return _st_InventoryDay;}
			set{_st_InventoryDay = value;}
		}

		/// public propaty name  :  St_InventoryDayDateTime
		/// <summary>開始棚卸実施日(DateTime)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始棚卸実施日(DateTime)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime St_InventoryDayDateTime
		{
			get{return _st_InventoryDayDateTime;}
			set{_st_InventoryDayDateTime = value;}
		}

		/// public propaty name  :  Ed_InventoryDay
		/// <summary>終了棚卸実施日(Int)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了棚卸実施日(Int)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_InventoryDay
		{
			get{return _ed_InventoryDay;}
			set{_ed_InventoryDay = value;}
		}

		/// public propaty name  :  Ed_InventoryDayDateTime
		/// <summary>終了棚卸実施日(DateTime)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了棚卸実施日(DateTime)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime Ed_InventoryDayDateTime
		{
			get{return _ed_InventoryDayDateTime;}
			set{_ed_InventoryDayDateTime = value;}
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
            get { return _inventoryDate; }
            set { _inventoryDate = value; }
        }

		/// public propaty name  :  St_InventorySeqNo
		/// <summary>開始棚卸通番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始棚卸通番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_InventorySeqNo
		{
			get{return _st_InventorySeqNo;}
			set{_st_InventorySeqNo = value;}
		}

		/// public propaty name  :  Ed_InventorySeqNo
		/// <summary>終了棚卸通番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了棚卸通番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_InventorySeqNo
		{
			get{return _ed_InventorySeqNo;}
			set{_ed_InventorySeqNo = value;}
		}

        /// public propaty name  :  St_BLGroupCode
        /// <summary>開始グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_BLGroupCode
        {
            get { return _st_BLGroupCode; }
            set { _st_BLGroupCode = value; }
        }

        /// public propaty name  :  Ed_BLGroupCode
        /// <summary>終了グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_BLGroupCode
        {
            get { return _ed_BLGroupCode; }
            set { _ed_BLGroupCode = value; }
        }

		/// public propaty name  :  DifCntExtraDiv
		/// <summary>差異分抽出区分プロパティ</summary>
		/// <value>0:全て,1:数未入力分のみ,2:数入力分のみ,3:差異分のみ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   差異分抽出区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DifCntExtraDiv
		{
			get{return _difCntExtraDiv;}
			set{_difCntExtraDiv = value;}
		}

		/// public propaty name  :  StockCntZeroExtraDiv
		/// <summary>在庫数0抽出区分プロパティ</summary>
		/// <value>0:抽出する,1:抽出しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫数0抽出区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockCntZeroExtraDiv
		{
			get{return _stockCntZeroExtraDiv;}
			set{_stockCntZeroExtraDiv = value;}
		}

		/// public propaty name  :  IvtStkCntZeroExtraDiv
		/// <summary>棚卸在庫数0抽出区分プロパティ</summary>
		/// <value>0:抽出する,1:抽出しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   棚卸在庫数0抽出区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 IvtStkCntZeroExtraDiv
		{
			get{return _ivtStkCntZeroExtraDiv;}
			set{_ivtStkCntZeroExtraDiv = value;}
		}

		/// public propaty name  :  SelectedPaperKind
		/// <summary>帳票種別プロパティ</summary>
		/// <value>0:棚卸記入表、1:棚卸差異表、2:棚卸表</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   帳票種別プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SelectedPaperKind
		{
			get{return _selectedPaperKind;}
			set{_selectedPaperKind = value;}
		}

		/// public propaty name  :  OutputAppointDiv
		/// <summary>出力指定区分プロパティ</summary>
		/// <value>0:全て,1:棚卸未入力のみ,2:差異分のみ,3:重複棚番ありのみ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力指定区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OutputAppointDiv
		{
			get{return _outputAppointDiv;}
			set{_outputAppointDiv = value;}
		}

		/// public propaty name  :  TargetDateExtraDiv
		/// <summary>抽出対象日付区分プロパティ</summary>
		/// <value>0:棚卸準備処理日,1:棚卸実施日,2:棚卸更新日</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出対象日付区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TargetDateExtraDiv
		{
			get{return _targetDateExtraDiv;}
			set{_targetDateExtraDiv = value;}
		}

        /// public propaty name  :  CalcStockAmountDiv
		/// <summary>在庫数算出フラグプロパティ</summary>
		/// <value>0:在庫数算出しない, 1:在庫数算出する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫数算出フラグプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CalcStockAmountDiv
		{
			get{return _calcStockAmountDiv;}
			set{_calcStockAmountDiv = value;}
		}

		/// public propaty name  :  CalcStockAmountDate
		/// <summary>在庫数算出日付プロパティ</summary>
		/// <value>在庫数算出フラグ=1のときの在庫数算出日付</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫数算出日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime CalcStockAmountDate
		{
			get{return _calcStockAmountDate;}
			set{_calcStockAmountDate = value;}
		}

		/// public propaty name  :  StockDiv
		/// <summary>在庫区分プロパティ</summary>
		/// <value>0:全て,1:自社,2:受託</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockDiv
		{
			get{return _stockDiv;}
			set{_stockDiv = value;}
		}

        /// public propaty name  :  LendExtraDiv
		/// <summary>貸出抽出区分プロパティ</summary>
		/// <value>0:印刷しない,1:印刷する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   貸出抽出区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 LendExtraDiv
		{
			get{return _lendExtraDiv;}
			set{_lendExtraDiv = value;}
		}

		/// public propaty name  :  DelayPaymentDiv
		/// <summary>来勘計上抽出区分プロパティ</summary>
		/// <value>0:印刷しない,1:印刷する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   来勘計上抽出区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DelayPaymentDiv
		{
			get{return _delayPaymentDiv;}
			set{_delayPaymentDiv = value;}
		}

		/// public propaty name  :  SortDiv
		/// <summary>ソート順プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ソート順プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SortDiv
		{
			get{return _sortDiv;}
			set{_sortDiv = value;}
		}

        ///// public propaty name  :  StockCntPrintDiv
        ///// <summary>帳簿在庫印字区分プロパティ</summary>
        ///// <value>0:印字する、1:印字しない</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   帳簿在庫印字区分プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 StockCntPrintDiv
        //{
        //    get{return _stockCntPrintDiv;}
        //    set{_stockCntPrintDiv = value;}
        //}

        ///// public propaty name  :  CustomerPrintDiv
        ///// <summary>得意先印字区分プロパティ</summary>
        ///// <value>0:仕入先,1:委託先</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   得意先印字区分プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 CustomerPrintDiv
        //{
        //    get{return _customerPrintDiv;}
        //    set{_customerPrintDiv = value;}
        //}

        ///// public propaty name  :  InventoryInputDiv
        ///// <summary>棚卸未入力区分プロパティ</summary>
        ///// <value>0:未入力扱い,1:帳簿数と同じ</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   棚卸未入力区分プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 InventoryInputDiv
        //{
        //    get{return _inventoryInputDiv;}
        //    set{_inventoryInputDiv = value;}
        //}

		/// public propaty name  :  TurnOoverThePagesDiv
		/// <summary>改ページ指定区分プロパティ</summary>
		/// <value>0:倉庫,1:印刷順,2:しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   改ページ指定区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TurnOoverThePagesDiv
		{
			get{return _turnOoverThePagesDiv;}
			set{_turnOoverThePagesDiv = value;}
		}

		/// public propaty name  :  ShelfNoBreakDiv
		/// <summary>棚番ブレイク区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   棚番ブレイク区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ShelfNoBreakDiv
		{
			get{return _shelfNoBreakDiv;}
			set{_shelfNoBreakDiv = value;}
		}

        /// public propaty name  :  InventoryNonInputDiv
        /// <summary>棚卸未入力区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸未入力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InventoryNonInputDiv
        {
            get { return _inventoryNonInputDiv; }
            set { _inventoryNonInputDiv = value; }
        }

        /// public propaty name  :  SubtotalPrintDiv
        /// <summary>小計印字区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  小計印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubtotalPrintDiv
        {
            get { return _subtotalPrintDiv; }
            set { _subtotalPrintDiv = value; }
        }

        /// public propaty name  :  SubtotalPrintDivTemp
        /// <summary>計印字区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  計印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubtotalPrintDivTemp
        {
            get { return _subtotalPrintDivTemp; }
            set { _subtotalPrintDivTemp = value; }
        }
        
        //--------------ADD 2011/01/11 -------------->>>>>
        /// public propaty name  :  NumOutputDiv
        /// <summary>数量出力区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  数量出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NumOutputDiv
        {
            get { return _numOutputDiv; }
            set { _numOutputDiv = value; }
        }

        /// public propaty name  :  WarehouseShelfOutputDiv
        /// <summary>棚番出力区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  棚番出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 WarehouseShelfOutputDiv
        {
            get { return _warehouseShelfOutputDiv; }
            set { _warehouseShelfOutputDiv = value; }
        }
        //--------------ADD 2011/01/11 --------------<<<<<
        // --- ADD 李亜博 2012/11/14 for Redmine#33271---------->>>>>
        /// public propaty name  :  LineMaSqOfChDiv
        /// <summary>罫線印字区分プロパティ名称</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   罫線印字区分プロパティ名称</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int LineMaSqOfChDiv
        {
            get { return _lineMaSqOfChDiv; }
            set { _lineMaSqOfChDiv = value; }
        }
        // --- ADD 李亜博 2012/11/14 for Redmine#33271----------<<<<<


		/// <summary>
		/// 棚卸関連帳票抽出条件クラスコンストラクタ
		/// </summary>
		/// <returns>InventSearchCndtnUIクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   InventSearchCndtnUIクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public InventSearchCndtnUI()
		{
		}

        ///// <summary>
        ///// 棚卸関連帳票抽出条件クラスコンストラクタ
        ///// </summary>
        ///// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        ///// <param name="enterpriseName">企業名称</param>
        ///// <param name="sectionCode">拠点コード</param>
        ///// <param name="inventorySectionName">在庫更新拠点名称</param>
        ///// <param name="st_MakerCode">メーカーコード開始(1～899:提供分, 900～ユーザー登録)</param>
        ///// <param name="ed_MakerCode">メーカーコード終了(1～899:提供分, 900～ユーザー登録)</param>
        ///// <param name="st_GoodsNo">商品番号開始</param>
        ///// <param name="ed_GoodsNo">商品番号終了</param>
        ///// <param name="st_LargeGoodsGanreCode">商品区分グループコード開始</param>
        ///// <param name="ed_LargeGoodsGanreCode">商品区分グループコード終了</param>
        ///// <param name="st_MediumGoodsGanreCode">商品区分コード開始</param>
        ///// <param name="ed_MediumGoodsGanreCode">商品区分コード終了</param>
        ///// <param name="st_DetailGoodsGanreCode">商品区分詳細コード開始</param>
        ///// <param name="ed_DetailGoodsGanreCode">商品区分詳細コード終了</param>
        ///// <param name="st_WarehouseCode">倉庫コード開始</param>
        ///// <param name="ed_WarehouseCode">倉庫コード終了</param>
        ///// <param name="st_WarehouseShelfNo">棚番開始</param>
        ///// <param name="ed_WarehouseShelfNo">棚番終了</param>
        ///// <param name="st_EnterpriseGanreCode">自社分類コード開始</param>
        ///// <param name="ed_EnterpriseGanreCode">自社分類コード終了</param>
        ///// <param name="st_BLGoodsCode">ＢＬ商品コード開始</param>
        ///// <param name="ed_BLGoodsCode">ＢＬ商品コード終了</param>
        ///// <param name="st_CustomerCode">得意先コード開始</param>
        ///// <param name="ed_CustomerCode">得意先コード終了</param>
        ///// <param name="st_ShipCustomerCode">出荷先得意先コード開始</param>
        ///// <param name="ed_ShipCustomerCode">出荷先得意先コード終了</param>
        ///// <param name="st_InventoryPreprDay">開始棚卸準備処理日付(Int)(YYYYMMDD)</param>
        ///// <param name="st_InventoryPreprDayDateTime">開始棚卸準備処理日付(DateTime)(YYYYMMDD)</param>
        ///// <param name="ed_InventoryPreprDay">終了棚卸準備処理日付(Int)(YYYYMMDD)</param>
        ///// <param name="ed_InventoryPreprDayDateTime">終了棚卸準備処理日付(DateTime)(YYYYMMDD)</param>
        ///// <param name="st_InventoryDay">開始棚卸実施日(Int)(YYYYMMDD)</param>
        ///// <param name="st_InventoryDayDateTime">開始棚卸実施日(DateTime)(YYYYMMDD)</param>
        ///// <param name="ed_InventoryDay">終了棚卸実施日(Int)(YYYYMMDD)</param>
        ///// <param name="ed_InventoryDayDateTime">終了棚卸実施日(DateTime)(YYYYMMDD)</param>
        ///// <param name="st_InventorySeqNo">開始棚卸通番</param>
        ///// <param name="ed_InventorySeqNo">終了棚卸通番</param>
        ///// <param name="difCntExtraDiv">差異分抽出区分(0:全て,1:数未入力分のみ,2:数入力分のみ,3:差異分のみ)</param>
        ///// <param name="stockCntZeroExtraDiv">在庫数0抽出区分(0:抽出する,1:抽出しない)</param>
        ///// <param name="ivtStkCntZeroExtraDiv">棚卸在庫数0抽出区分(0:抽出する,1:抽出しない)</param>
        ///// <param name="selectedPaperKind">帳票種別(0:棚卸記入表、1:棚卸差異表、2:棚卸表)</param>
        ///// <param name="outputAppointDiv">出力指定区分(0:全て,1:棚卸未入力のみ,2:差異分のみ,3:重複棚番ありのみ)</param>
        ///// <param name="targetDateExtraDiv">抽出対象日付区分(0:棚卸準備処理日,1:棚卸実施日,2:棚卸更新日)</param>
        ///// <param name="sortDiv">ソート順</param>
        ///// <param name="stockCntPrintDiv">帳簿在庫印字区分(0:印字する、1:印字しない)</param>
        ///// <param name="customerPrintDiv">得意先印字区分(0:仕入先,1:委託先)</param>
        ///// <param name="inventoryInputDiv">棚卸未入力区分(0:未入力扱い,1:帳簿数と同じ)</param>
        ///// <param name="turnOoverThePagesDiv">改ページ指定区分(0:倉庫,1:印刷順,2:しない)</param>
        ///// <param name="shelfNoBreakDiv">棚番ブレイク区分</param>
        ///// <returns>InventSearchCndtnUIクラスのインスタンス</returns>
        ///// <remarks>
        ///// <br>Note　　　　　　 :   InventSearchCndtnUIクラスの新しいインスタンスを生成します</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public InventSearchCndtnUI(string enterpriseCode,string enterpriseName,string sectionCode,string inventorySectionName,Int32 st_MakerCode,Int32 ed_MakerCode,string st_GoodsNo,string ed_GoodsNo,string st_LargeGoodsGanreCode,string ed_LargeGoodsGanreCode,string st_MediumGoodsGanreCode,string ed_MediumGoodsGanreCode,string st_DetailGoodsGanreCode,string ed_DetailGoodsGanreCode,string st_WarehouseCode,string ed_WarehouseCode,string st_WarehouseShelfNo,string ed_WarehouseShelfNo,Int32 st_EnterpriseGanreCode,Int32 ed_EnterpriseGanreCode,Int32 st_BLGoodsCode,Int32 ed_BLGoodsCode,Int32 st_CustomerCode,Int32 ed_CustomerCode,Int32 st_ShipCustomerCode,Int32 ed_ShipCustomerCode,Int32 st_InventoryPreprDay,DateTime st_InventoryPreprDayDateTime,Int32 ed_InventoryPreprDay,DateTime ed_InventoryPreprDayDateTime,Int32 st_InventoryDay,DateTime st_InventoryDayDateTime,Int32 ed_InventoryDay,DateTime ed_InventoryDayDateTime,Int32 st_InventorySeqNo,Int32 ed_InventorySeqNo,Int32 difCntExtraDiv,Int32 stockCntZeroExtraDiv,Int32 ivtStkCntZeroExtraDiv,Int32 selectedPaperKind,Int32 outputAppointDiv,Int32 targetDateExtraDiv,Int32 sortDiv,Int32 stockCntPrintDiv,Int32 customerPrintDiv,Int32 inventoryInputDiv,Int32 turnOoverThePagesDiv,Int32 shelfNoBreakDiv)
        //{
        //    this._enterpriseCode = enterpriseCode;
        //    this._enterpriseName = enterpriseName;
        //    this._sectionCode = sectionCode;
        //    this._inventorySectionName = inventorySectionName;
        //    this._st_MakerCode = st_MakerCode;
        //    this._ed_MakerCode = ed_MakerCode;
        //    this._st_GoodsNo = st_GoodsNo;
        //    this._ed_GoodsNo = ed_GoodsNo;
        //    this._st_LargeGoodsGanreCode = st_LargeGoodsGanreCode;
        //    this._ed_LargeGoodsGanreCode = ed_LargeGoodsGanreCode;
        //    this._st_MediumGoodsGanreCode = st_MediumGoodsGanreCode;
        //    this._ed_MediumGoodsGanreCode = ed_MediumGoodsGanreCode;
        //    this._st_DetailGoodsGanreCode = st_DetailGoodsGanreCode;
        //    this._ed_DetailGoodsGanreCode = ed_DetailGoodsGanreCode;
        //    this._st_WarehouseCode = st_WarehouseCode;
        //    this._ed_WarehouseCode = ed_WarehouseCode;
        //    this._st_WarehouseShelfNo = st_WarehouseShelfNo;
        //    this._ed_WarehouseShelfNo = ed_WarehouseShelfNo;
        //    this._st_EnterpriseGanreCode = st_EnterpriseGanreCode;
        //    this._ed_EnterpriseGanreCode = ed_EnterpriseGanreCode;
        //    this._st_BLGoodsCode = st_BLGoodsCode;
        //    this._ed_BLGoodsCode = ed_BLGoodsCode;
        //    this._st_CustomerCode = st_CustomerCode;
        //    this._ed_CustomerCode = ed_CustomerCode;
        //    this._st_ShipCustomerCode = st_ShipCustomerCode;
        //    this._ed_ShipCustomerCode = ed_ShipCustomerCode;
        //    this._st_InventoryPreprDay = st_InventoryPreprDay;
        //    this._st_InventoryPreprDayDateTime = st_InventoryPreprDayDateTime;
        //    this._ed_InventoryPreprDay = ed_InventoryPreprDay;
        //    this._ed_InventoryPreprDayDateTime = ed_InventoryPreprDayDateTime;
        //    this._st_InventoryDay = st_InventoryDay;
        //    this._st_InventoryDayDateTime = st_InventoryDayDateTime;
        //    this._ed_InventoryDay = ed_InventoryDay;
        //    this._ed_InventoryDayDateTime = ed_InventoryDayDateTime;
        //    this._st_InventorySeqNo = st_InventorySeqNo;
        //    this._ed_InventorySeqNo = ed_InventorySeqNo;
        //    this._difCntExtraDiv = difCntExtraDiv;
        //    this._stockCntZeroExtraDiv = stockCntZeroExtraDiv;
        //    this._ivtStkCntZeroExtraDiv = ivtStkCntZeroExtraDiv;
        //    this._selectedPaperKind = selectedPaperKind;
        //    this._outputAppointDiv = outputAppointDiv;
        //    this._targetDateExtraDiv = targetDateExtraDiv;
        //    this._sortDiv = sortDiv;
        //    this._stockCntPrintDiv = stockCntPrintDiv;
        //    this._customerPrintDiv = customerPrintDiv;
        //    this._inventoryInputDiv = inventoryInputDiv;
        //    this._turnOoverThePagesDiv = turnOoverThePagesDiv;
        //    this._shelfNoBreakDiv = shelfNoBreakDiv;

        //}

        ///// <summary>
        ///// 棚卸関連帳票抽出条件クラス複製処理
        ///// </summary>
        ///// <returns>InventSearchCndtnUIクラスのインスタンス</returns>
        ///// <remarks>
        ///// <br>Note　　　　　　 :   自身の内容と等しいInventSearchCndtnUIクラスのインスタンスを返します</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public InventSearchCndtnUI Clone()
        //{
        //    return new InventSearchCndtnUI(this._enterpriseCode,this._enterpriseName,this._sectionCode,this._inventorySectionName,this._st_MakerCode,this._ed_MakerCode,this._st_GoodsNo,this._ed_GoodsNo,this._st_LargeGoodsGanreCode,this._ed_LargeGoodsGanreCode,this._st_MediumGoodsGanreCode,this._ed_MediumGoodsGanreCode,this._st_DetailGoodsGanreCode,this._ed_DetailGoodsGanreCode,this._st_WarehouseCode,this._ed_WarehouseCode,this._st_WarehouseShelfNo,this._ed_WarehouseShelfNo,this._st_EnterpriseGanreCode,this._ed_EnterpriseGanreCode,this._st_BLGoodsCode,this._ed_BLGoodsCode,this._st_CustomerCode,this._ed_CustomerCode,this._st_ShipCustomerCode,this._ed_ShipCustomerCode,this._st_InventoryPreprDay,this._st_InventoryPreprDayDateTime,this._ed_InventoryPreprDay,this._ed_InventoryPreprDayDateTime,this._st_InventoryDay,this._st_InventoryDayDateTime,this._ed_InventoryDay,this._ed_InventoryDayDateTime,this._st_InventorySeqNo,this._ed_InventorySeqNo,this._difCntExtraDiv,this._stockCntZeroExtraDiv,this._ivtStkCntZeroExtraDiv,this._selectedPaperKind,this._outputAppointDiv,this._targetDateExtraDiv,this._sortDiv,this._stockCntPrintDiv,this._customerPrintDiv,this._inventoryInputDiv,this._turnOoverThePagesDiv,this._shelfNoBreakDiv);
        //}

        ///// <summary>
        ///// 棚卸関連帳票抽出条件クラス比較処理
        ///// </summary>
        ///// <param name="target">比較対象のInventSearchCndtnUIクラスのインスタンス</param>
        ///// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        ///// <remarks>
        ///// <br>Note　　　　　　 :   InventSearchCndtnUIクラスの内容が一致するか比較します</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public bool Equals(InventSearchCndtnUI target)
        //{
        //    return ((this.EnterpriseCode == target.EnterpriseCode)
        //         && (this.EnterpriseName == target.EnterpriseName)
        //         && (this.SectionCode == target.SectionCode)
        //         && (this.InventorySectionName == target.InventorySectionName)
        //         && (this.St_MakerCode == target.St_MakerCode)
        //         && (this.Ed_MakerCode == target.Ed_MakerCode)
        //         && (this.St_GoodsNo == target.St_GoodsNo)
        //         && (this.Ed_GoodsNo == target.Ed_GoodsNo)
        //         && (this.St_LargeGoodsGanreCode == target.St_LargeGoodsGanreCode)
        //         && (this.Ed_LargeGoodsGanreCode == target.Ed_LargeGoodsGanreCode)
        //         && (this.St_MediumGoodsGanreCode == target.St_MediumGoodsGanreCode)
        //         && (this.Ed_MediumGoodsGanreCode == target.Ed_MediumGoodsGanreCode)
        //         && (this.St_DetailGoodsGanreCode == target.St_DetailGoodsGanreCode)
        //         && (this.Ed_DetailGoodsGanreCode == target.Ed_DetailGoodsGanreCode)
        //         && (this.St_WarehouseCode == target.St_WarehouseCode)
        //         && (this.Ed_WarehouseCode == target.Ed_WarehouseCode)
        //         && (this.St_WarehouseShelfNo == target.St_WarehouseShelfNo)
        //         && (this.Ed_WarehouseShelfNo == target.Ed_WarehouseShelfNo)
        //         && (this.St_EnterpriseGanreCode == target.St_EnterpriseGanreCode)
        //         && (this.Ed_EnterpriseGanreCode == target.Ed_EnterpriseGanreCode)
        //         && (this.St_BLGoodsCode == target.St_BLGoodsCode)
        //         && (this.Ed_BLGoodsCode == target.Ed_BLGoodsCode)
        //         && (this.St_CustomerCode == target.St_CustomerCode)
        //         && (this.Ed_CustomerCode == target.Ed_CustomerCode)
        //         && (this.St_ShipCustomerCode == target.St_ShipCustomerCode)
        //         && (this.Ed_ShipCustomerCode == target.Ed_ShipCustomerCode)
        //         && (this.St_InventoryPreprDay == target.St_InventoryPreprDay)
        //         && (this.St_InventoryPreprDayDateTime == target.St_InventoryPreprDayDateTime)
        //         && (this.Ed_InventoryPreprDay == target.Ed_InventoryPreprDay)
        //         && (this.Ed_InventoryPreprDayDateTime == target.Ed_InventoryPreprDayDateTime)
        //         && (this.St_InventoryDay == target.St_InventoryDay)
        //         && (this.St_InventoryDayDateTime == target.St_InventoryDayDateTime)
        //         && (this.Ed_InventoryDay == target.Ed_InventoryDay)
        //         && (this.Ed_InventoryDayDateTime == target.Ed_InventoryDayDateTime)
        //         && (this.St_InventorySeqNo == target.St_InventorySeqNo)
        //         && (this.Ed_InventorySeqNo == target.Ed_InventorySeqNo)
        //         && (this.DifCntExtraDiv == target.DifCntExtraDiv)
        //         && (this.StockCntZeroExtraDiv == target.StockCntZeroExtraDiv)
        //         && (this.IvtStkCntZeroExtraDiv == target.IvtStkCntZeroExtraDiv)
        //         && (this.SelectedPaperKind == target.SelectedPaperKind)
        //         && (this.OutputAppointDiv == target.OutputAppointDiv)
        //         && (this.TargetDateExtraDiv == target.TargetDateExtraDiv)
        //         && (this.SortDiv == target.SortDiv)
        //         && (this.StockCntPrintDiv == target.StockCntPrintDiv)
        //         && (this.CustomerPrintDiv == target.CustomerPrintDiv)
        //         && (this.InventoryInputDiv == target.InventoryInputDiv)
        //         && (this.TurnOoverThePagesDiv == target.TurnOoverThePagesDiv)
        //         && (this.ShelfNoBreakDiv == target.ShelfNoBreakDiv));
        //}

        ///// <summary>
        ///// 棚卸関連帳票抽出条件クラス比較処理
        ///// </summary>
        ///// <param name="inventSearchCndtnUI1">
        /////                    比較するInventSearchCndtnUIクラスのインスタンス
        ///// </param>
        ///// <param name="inventSearchCndtnUI2">比較するInventSearchCndtnUIクラスのインスタンス</param>
        ///// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        ///// <remarks>
        ///// <br>Note　　　　　　 :   InventSearchCndtnUIクラスの内容が一致するか比較します</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public static bool Equals(InventSearchCndtnUI inventSearchCndtnUI1, InventSearchCndtnUI inventSearchCndtnUI2)
        //{
        //    return ((inventSearchCndtnUI1.EnterpriseCode == inventSearchCndtnUI2.EnterpriseCode)
        //         && (inventSearchCndtnUI1.EnterpriseName == inventSearchCndtnUI2.EnterpriseName)
        //         && (inventSearchCndtnUI1.SectionCode == inventSearchCndtnUI2.SectionCode)
        //         && (inventSearchCndtnUI1.InventorySectionName == inventSearchCndtnUI2.InventorySectionName)
        //         && (inventSearchCndtnUI1.St_MakerCode == inventSearchCndtnUI2.St_MakerCode)
        //         && (inventSearchCndtnUI1.Ed_MakerCode == inventSearchCndtnUI2.Ed_MakerCode)
        //         && (inventSearchCndtnUI1.St_GoodsNo == inventSearchCndtnUI2.St_GoodsNo)
        //         && (inventSearchCndtnUI1.Ed_GoodsNo == inventSearchCndtnUI2.Ed_GoodsNo)
        //         && (inventSearchCndtnUI1.St_LargeGoodsGanreCode == inventSearchCndtnUI2.St_LargeGoodsGanreCode)
        //         && (inventSearchCndtnUI1.Ed_LargeGoodsGanreCode == inventSearchCndtnUI2.Ed_LargeGoodsGanreCode)
        //         && (inventSearchCndtnUI1.St_MediumGoodsGanreCode == inventSearchCndtnUI2.St_MediumGoodsGanreCode)
        //         && (inventSearchCndtnUI1.Ed_MediumGoodsGanreCode == inventSearchCndtnUI2.Ed_MediumGoodsGanreCode)
        //         && (inventSearchCndtnUI1.St_DetailGoodsGanreCode == inventSearchCndtnUI2.St_DetailGoodsGanreCode)
        //         && (inventSearchCndtnUI1.Ed_DetailGoodsGanreCode == inventSearchCndtnUI2.Ed_DetailGoodsGanreCode)
        //         && (inventSearchCndtnUI1.St_WarehouseCode == inventSearchCndtnUI2.St_WarehouseCode)
        //         && (inventSearchCndtnUI1.Ed_WarehouseCode == inventSearchCndtnUI2.Ed_WarehouseCode)
        //         && (inventSearchCndtnUI1.St_WarehouseShelfNo == inventSearchCndtnUI2.St_WarehouseShelfNo)
        //         && (inventSearchCndtnUI1.Ed_WarehouseShelfNo == inventSearchCndtnUI2.Ed_WarehouseShelfNo)
        //         && (inventSearchCndtnUI1.St_EnterpriseGanreCode == inventSearchCndtnUI2.St_EnterpriseGanreCode)
        //         && (inventSearchCndtnUI1.Ed_EnterpriseGanreCode == inventSearchCndtnUI2.Ed_EnterpriseGanreCode)
        //         && (inventSearchCndtnUI1.St_BLGoodsCode == inventSearchCndtnUI2.St_BLGoodsCode)
        //         && (inventSearchCndtnUI1.Ed_BLGoodsCode == inventSearchCndtnUI2.Ed_BLGoodsCode)
        //         && (inventSearchCndtnUI1.St_CustomerCode == inventSearchCndtnUI2.St_CustomerCode)
        //         && (inventSearchCndtnUI1.Ed_CustomerCode == inventSearchCndtnUI2.Ed_CustomerCode)
        //         && (inventSearchCndtnUI1.St_ShipCustomerCode == inventSearchCndtnUI2.St_ShipCustomerCode)
        //         && (inventSearchCndtnUI1.Ed_ShipCustomerCode == inventSearchCndtnUI2.Ed_ShipCustomerCode)
        //         && (inventSearchCndtnUI1.St_InventoryPreprDay == inventSearchCndtnUI2.St_InventoryPreprDay)
        //         && (inventSearchCndtnUI1.St_InventoryPreprDayDateTime == inventSearchCndtnUI2.St_InventoryPreprDayDateTime)
        //         && (inventSearchCndtnUI1.Ed_InventoryPreprDay == inventSearchCndtnUI2.Ed_InventoryPreprDay)
        //         && (inventSearchCndtnUI1.Ed_InventoryPreprDayDateTime == inventSearchCndtnUI2.Ed_InventoryPreprDayDateTime)
        //         && (inventSearchCndtnUI1.St_InventoryDay == inventSearchCndtnUI2.St_InventoryDay)
        //         && (inventSearchCndtnUI1.St_InventoryDayDateTime == inventSearchCndtnUI2.St_InventoryDayDateTime)
        //         && (inventSearchCndtnUI1.Ed_InventoryDay == inventSearchCndtnUI2.Ed_InventoryDay)
        //         && (inventSearchCndtnUI1.Ed_InventoryDayDateTime == inventSearchCndtnUI2.Ed_InventoryDayDateTime)
        //         && (inventSearchCndtnUI1.St_InventorySeqNo == inventSearchCndtnUI2.St_InventorySeqNo)
        //         && (inventSearchCndtnUI1.Ed_InventorySeqNo == inventSearchCndtnUI2.Ed_InventorySeqNo)
        //         && (inventSearchCndtnUI1.DifCntExtraDiv == inventSearchCndtnUI2.DifCntExtraDiv)
        //         && (inventSearchCndtnUI1.StockCntZeroExtraDiv == inventSearchCndtnUI2.StockCntZeroExtraDiv)
        //         && (inventSearchCndtnUI1.IvtStkCntZeroExtraDiv == inventSearchCndtnUI2.IvtStkCntZeroExtraDiv)
        //         && (inventSearchCndtnUI1.SelectedPaperKind == inventSearchCndtnUI2.SelectedPaperKind)
        //         && (inventSearchCndtnUI1.OutputAppointDiv == inventSearchCndtnUI2.OutputAppointDiv)
        //         && (inventSearchCndtnUI1.TargetDateExtraDiv == inventSearchCndtnUI2.TargetDateExtraDiv)
        //         && (inventSearchCndtnUI1.SortDiv == inventSearchCndtnUI2.SortDiv)
        //         && (inventSearchCndtnUI1.StockCntPrintDiv == inventSearchCndtnUI2.StockCntPrintDiv)
        //         && (inventSearchCndtnUI1.CustomerPrintDiv == inventSearchCndtnUI2.CustomerPrintDiv)
        //         && (inventSearchCndtnUI1.InventoryInputDiv == inventSearchCndtnUI2.InventoryInputDiv)
        //         && (inventSearchCndtnUI1.TurnOoverThePagesDiv == inventSearchCndtnUI2.TurnOoverThePagesDiv)
        //         && (inventSearchCndtnUI1.ShelfNoBreakDiv == inventSearchCndtnUI2.ShelfNoBreakDiv));
        //}
        ///// <summary>
        ///// 棚卸関連帳票抽出条件クラス比較処理
        ///// </summary>
        ///// <param name="target">比較対象のInventSearchCndtnUIクラスのインスタンス</param>
        ///// <returns>一致しない項目のリスト</returns>
        ///// <remarks>
        ///// <br>Note　　　　　　 :   InventSearchCndtnUIクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public ArrayList Compare(InventSearchCndtnUI target)
        //{
        //    ArrayList resList = new ArrayList();
        //    if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
        //    if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
        //    if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
        //    if(this.InventorySectionName != target.InventorySectionName)resList.Add("InventorySectionName");
        //    if(this.St_MakerCode != target.St_MakerCode)resList.Add("St_MakerCode");
        //    if(this.Ed_MakerCode != target.Ed_MakerCode)resList.Add("Ed_MakerCode");
        //    if(this.St_GoodsNo != target.St_GoodsNo)resList.Add("St_GoodsNo");
        //    if(this.Ed_GoodsNo != target.Ed_GoodsNo)resList.Add("Ed_GoodsNo");
        //    if(this.St_LargeGoodsGanreCode != target.St_LargeGoodsGanreCode)resList.Add("St_LargeGoodsGanreCode");
        //    if(this.Ed_LargeGoodsGanreCode != target.Ed_LargeGoodsGanreCode)resList.Add("Ed_LargeGoodsGanreCode");
        //    if(this.St_MediumGoodsGanreCode != target.St_MediumGoodsGanreCode)resList.Add("St_MediumGoodsGanreCode");
        //    if(this.Ed_MediumGoodsGanreCode != target.Ed_MediumGoodsGanreCode)resList.Add("Ed_MediumGoodsGanreCode");
        //    if(this.St_DetailGoodsGanreCode != target.St_DetailGoodsGanreCode)resList.Add("St_DetailGoodsGanreCode");
        //    if(this.Ed_DetailGoodsGanreCode != target.Ed_DetailGoodsGanreCode)resList.Add("Ed_DetailGoodsGanreCode");
        //    if(this.St_WarehouseCode != target.St_WarehouseCode)resList.Add("St_WarehouseCode");
        //    if(this.Ed_WarehouseCode != target.Ed_WarehouseCode)resList.Add("Ed_WarehouseCode");
        //    if(this.St_WarehouseShelfNo != target.St_WarehouseShelfNo)resList.Add("St_WarehouseShelfNo");
        //    if(this.Ed_WarehouseShelfNo != target.Ed_WarehouseShelfNo)resList.Add("Ed_WarehouseShelfNo");
        //    if(this.St_EnterpriseGanreCode != target.St_EnterpriseGanreCode)resList.Add("St_EnterpriseGanreCode");
        //    if(this.Ed_EnterpriseGanreCode != target.Ed_EnterpriseGanreCode)resList.Add("Ed_EnterpriseGanreCode");
        //    if(this.St_BLGoodsCode != target.St_BLGoodsCode)resList.Add("St_BLGoodsCode");
        //    if(this.Ed_BLGoodsCode != target.Ed_BLGoodsCode)resList.Add("Ed_BLGoodsCode");
        //    if(this.St_CustomerCode != target.St_CustomerCode)resList.Add("St_CustomerCode");
        //    if(this.Ed_CustomerCode != target.Ed_CustomerCode)resList.Add("Ed_CustomerCode");
        //    if(this.St_ShipCustomerCode != target.St_ShipCustomerCode)resList.Add("St_ShipCustomerCode");
        //    if(this.Ed_ShipCustomerCode != target.Ed_ShipCustomerCode)resList.Add("Ed_ShipCustomerCode");
        //    if(this.St_InventoryPreprDay != target.St_InventoryPreprDay)resList.Add("St_InventoryPreprDay");
        //    if(this.St_InventoryPreprDayDateTime != target.St_InventoryPreprDayDateTime)resList.Add("St_InventoryPreprDayDateTime");
        //    if(this.Ed_InventoryPreprDay != target.Ed_InventoryPreprDay)resList.Add("Ed_InventoryPreprDay");
        //    if(this.Ed_InventoryPreprDayDateTime != target.Ed_InventoryPreprDayDateTime)resList.Add("Ed_InventoryPreprDayDateTime");
        //    if(this.St_InventoryDay != target.St_InventoryDay)resList.Add("St_InventoryDay");
        //    if(this.St_InventoryDayDateTime != target.St_InventoryDayDateTime)resList.Add("St_InventoryDayDateTime");
        //    if(this.Ed_InventoryDay != target.Ed_InventoryDay)resList.Add("Ed_InventoryDay");
        //    if(this.Ed_InventoryDayDateTime != target.Ed_InventoryDayDateTime)resList.Add("Ed_InventoryDayDateTime");
        //    if(this.St_InventorySeqNo != target.St_InventorySeqNo)resList.Add("St_InventorySeqNo");
        //    if(this.Ed_InventorySeqNo != target.Ed_InventorySeqNo)resList.Add("Ed_InventorySeqNo");
        //    if(this.DifCntExtraDiv != target.DifCntExtraDiv)resList.Add("DifCntExtraDiv");
        //    if(this.StockCntZeroExtraDiv != target.StockCntZeroExtraDiv)resList.Add("StockCntZeroExtraDiv");
        //    if(this.IvtStkCntZeroExtraDiv != target.IvtStkCntZeroExtraDiv)resList.Add("IvtStkCntZeroExtraDiv");
        //    if(this.SelectedPaperKind != target.SelectedPaperKind)resList.Add("SelectedPaperKind");
        //    if(this.OutputAppointDiv != target.OutputAppointDiv)resList.Add("OutputAppointDiv");
        //    if(this.TargetDateExtraDiv != target.TargetDateExtraDiv)resList.Add("TargetDateExtraDiv");
        //    if(this.SortDiv != target.SortDiv)resList.Add("SortDiv");
        //    if(this.StockCntPrintDiv != target.StockCntPrintDiv)resList.Add("StockCntPrintDiv");
        //    if(this.CustomerPrintDiv != target.CustomerPrintDiv)resList.Add("CustomerPrintDiv");
        //    if(this.InventoryInputDiv != target.InventoryInputDiv)resList.Add("InventoryInputDiv");
        //    if(this.TurnOoverThePagesDiv != target.TurnOoverThePagesDiv)resList.Add("TurnOoverThePagesDiv");
        //    if(this.ShelfNoBreakDiv != target.ShelfNoBreakDiv)resList.Add("ShelfNoBreakDiv");

        //    return resList;
        //}

        ///// <summary>
        ///// 棚卸関連帳票抽出条件クラス比較処理
        ///// </summary>
        ///// <param name="inventSearchCndtnUI1">比較するInventSearchCndtnUIクラスのインスタンス</param>
        ///// <param name="inventSearchCndtnUI2">比較するInventSearchCndtnUIクラスのインスタンス</param>
        ///// <returns>一致しない項目のリスト</returns>
        ///// <remarks>
        ///// <br>Note　　　　　　 :   InventSearchCndtnUIクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public static ArrayList Compare(InventSearchCndtnUI inventSearchCndtnUI1, InventSearchCndtnUI inventSearchCndtnUI2)
        //{
        //    ArrayList resList = new ArrayList();
        //    if(inventSearchCndtnUI1.EnterpriseCode != inventSearchCndtnUI2.EnterpriseCode)resList.Add("EnterpriseCode");
        //    if(inventSearchCndtnUI1.EnterpriseName != inventSearchCndtnUI2.EnterpriseName)resList.Add("EnterpriseName");
        //    if(inventSearchCndtnUI1.SectionCode != inventSearchCndtnUI2.SectionCode)resList.Add("SectionCode");
        //    if(inventSearchCndtnUI1.InventorySectionName != inventSearchCndtnUI2.InventorySectionName)resList.Add("InventorySectionName");
        //    if(inventSearchCndtnUI1.St_MakerCode != inventSearchCndtnUI2.St_MakerCode)resList.Add("St_MakerCode");
        //    if(inventSearchCndtnUI1.Ed_MakerCode != inventSearchCndtnUI2.Ed_MakerCode)resList.Add("Ed_MakerCode");
        //    if(inventSearchCndtnUI1.St_GoodsNo != inventSearchCndtnUI2.St_GoodsNo)resList.Add("St_GoodsNo");
        //    if(inventSearchCndtnUI1.Ed_GoodsNo != inventSearchCndtnUI2.Ed_GoodsNo)resList.Add("Ed_GoodsNo");
        //    if(inventSearchCndtnUI1.St_LargeGoodsGanreCode != inventSearchCndtnUI2.St_LargeGoodsGanreCode)resList.Add("St_LargeGoodsGanreCode");
        //    if(inventSearchCndtnUI1.Ed_LargeGoodsGanreCode != inventSearchCndtnUI2.Ed_LargeGoodsGanreCode)resList.Add("Ed_LargeGoodsGanreCode");
        //    if(inventSearchCndtnUI1.St_MediumGoodsGanreCode != inventSearchCndtnUI2.St_MediumGoodsGanreCode)resList.Add("St_MediumGoodsGanreCode");
        //    if(inventSearchCndtnUI1.Ed_MediumGoodsGanreCode != inventSearchCndtnUI2.Ed_MediumGoodsGanreCode)resList.Add("Ed_MediumGoodsGanreCode");
        //    if(inventSearchCndtnUI1.St_DetailGoodsGanreCode != inventSearchCndtnUI2.St_DetailGoodsGanreCode)resList.Add("St_DetailGoodsGanreCode");
        //    if(inventSearchCndtnUI1.Ed_DetailGoodsGanreCode != inventSearchCndtnUI2.Ed_DetailGoodsGanreCode)resList.Add("Ed_DetailGoodsGanreCode");
        //    if(inventSearchCndtnUI1.St_WarehouseCode != inventSearchCndtnUI2.St_WarehouseCode)resList.Add("St_WarehouseCode");
        //    if(inventSearchCndtnUI1.Ed_WarehouseCode != inventSearchCndtnUI2.Ed_WarehouseCode)resList.Add("Ed_WarehouseCode");
        //    if(inventSearchCndtnUI1.St_WarehouseShelfNo != inventSearchCndtnUI2.St_WarehouseShelfNo)resList.Add("St_WarehouseShelfNo");
        //    if(inventSearchCndtnUI1.Ed_WarehouseShelfNo != inventSearchCndtnUI2.Ed_WarehouseShelfNo)resList.Add("Ed_WarehouseShelfNo");
        //    if(inventSearchCndtnUI1.St_EnterpriseGanreCode != inventSearchCndtnUI2.St_EnterpriseGanreCode)resList.Add("St_EnterpriseGanreCode");
        //    if(inventSearchCndtnUI1.Ed_EnterpriseGanreCode != inventSearchCndtnUI2.Ed_EnterpriseGanreCode)resList.Add("Ed_EnterpriseGanreCode");
        //    if(inventSearchCndtnUI1.St_BLGoodsCode != inventSearchCndtnUI2.St_BLGoodsCode)resList.Add("St_BLGoodsCode");
        //    if(inventSearchCndtnUI1.Ed_BLGoodsCode != inventSearchCndtnUI2.Ed_BLGoodsCode)resList.Add("Ed_BLGoodsCode");
        //    if(inventSearchCndtnUI1.St_CustomerCode != inventSearchCndtnUI2.St_CustomerCode)resList.Add("St_CustomerCode");
        //    if(inventSearchCndtnUI1.Ed_CustomerCode != inventSearchCndtnUI2.Ed_CustomerCode)resList.Add("Ed_CustomerCode");
        //    if(inventSearchCndtnUI1.St_ShipCustomerCode != inventSearchCndtnUI2.St_ShipCustomerCode)resList.Add("St_ShipCustomerCode");
        //    if(inventSearchCndtnUI1.Ed_ShipCustomerCode != inventSearchCndtnUI2.Ed_ShipCustomerCode)resList.Add("Ed_ShipCustomerCode");
        //    if(inventSearchCndtnUI1.St_InventoryPreprDay != inventSearchCndtnUI2.St_InventoryPreprDay)resList.Add("St_InventoryPreprDay");
        //    if(inventSearchCndtnUI1.St_InventoryPreprDayDateTime != inventSearchCndtnUI2.St_InventoryPreprDayDateTime)resList.Add("St_InventoryPreprDayDateTime");
        //    if(inventSearchCndtnUI1.Ed_InventoryPreprDay != inventSearchCndtnUI2.Ed_InventoryPreprDay)resList.Add("Ed_InventoryPreprDay");
        //    if(inventSearchCndtnUI1.Ed_InventoryPreprDayDateTime != inventSearchCndtnUI2.Ed_InventoryPreprDayDateTime)resList.Add("Ed_InventoryPreprDayDateTime");
        //    if(inventSearchCndtnUI1.St_InventoryDay != inventSearchCndtnUI2.St_InventoryDay)resList.Add("St_InventoryDay");
        //    if(inventSearchCndtnUI1.St_InventoryDayDateTime != inventSearchCndtnUI2.St_InventoryDayDateTime)resList.Add("St_InventoryDayDateTime");
        //    if(inventSearchCndtnUI1.Ed_InventoryDay != inventSearchCndtnUI2.Ed_InventoryDay)resList.Add("Ed_InventoryDay");
        //    if(inventSearchCndtnUI1.Ed_InventoryDayDateTime != inventSearchCndtnUI2.Ed_InventoryDayDateTime)resList.Add("Ed_InventoryDayDateTime");
        //    if(inventSearchCndtnUI1.St_InventorySeqNo != inventSearchCndtnUI2.St_InventorySeqNo)resList.Add("St_InventorySeqNo");
        //    if(inventSearchCndtnUI1.Ed_InventorySeqNo != inventSearchCndtnUI2.Ed_InventorySeqNo)resList.Add("Ed_InventorySeqNo");
        //    if(inventSearchCndtnUI1.DifCntExtraDiv != inventSearchCndtnUI2.DifCntExtraDiv)resList.Add("DifCntExtraDiv");
        //    if(inventSearchCndtnUI1.StockCntZeroExtraDiv != inventSearchCndtnUI2.StockCntZeroExtraDiv)resList.Add("StockCntZeroExtraDiv");
        //    if(inventSearchCndtnUI1.IvtStkCntZeroExtraDiv != inventSearchCndtnUI2.IvtStkCntZeroExtraDiv)resList.Add("IvtStkCntZeroExtraDiv");
        //    if(inventSearchCndtnUI1.SelectedPaperKind != inventSearchCndtnUI2.SelectedPaperKind)resList.Add("SelectedPaperKind");
        //    if(inventSearchCndtnUI1.OutputAppointDiv != inventSearchCndtnUI2.OutputAppointDiv)resList.Add("OutputAppointDiv");
        //    if(inventSearchCndtnUI1.TargetDateExtraDiv != inventSearchCndtnUI2.TargetDateExtraDiv)resList.Add("TargetDateExtraDiv");
        //    if(inventSearchCndtnUI1.SortDiv != inventSearchCndtnUI2.SortDiv)resList.Add("SortDiv");
        //    if(inventSearchCndtnUI1.StockCntPrintDiv != inventSearchCndtnUI2.StockCntPrintDiv)resList.Add("StockCntPrintDiv");
        //    if(inventSearchCndtnUI1.CustomerPrintDiv != inventSearchCndtnUI2.CustomerPrintDiv)resList.Add("CustomerPrintDiv");
        //    if(inventSearchCndtnUI1.InventoryInputDiv != inventSearchCndtnUI2.InventoryInputDiv)resList.Add("InventoryInputDiv");
        //    if(inventSearchCndtnUI1.TurnOoverThePagesDiv != inventSearchCndtnUI2.TurnOoverThePagesDiv)resList.Add("TurnOoverThePagesDiv");
        //    if(inventSearchCndtnUI1.ShelfNoBreakDiv != inventSearchCndtnUI2.ShelfNoBreakDiv)resList.Add("ShelfNoBreakDiv");

        //    return resList;
        //}


        #region コード取得

        public enum SortOrder
        {
            // 2008.10.31 30413 犬飼 ソート順の修正 >>>>>>START
            // 2007.09.14 修正 >>>>>>>>>>>>>>>>>>>>
            ///// <summary>倉庫→商品</summary>
            //Warehouce_Goods = 0,
            ///// <summary>倉庫→仕入先→商品</summary>
            //Warehouce_Customer_Goods = 1,
            ///// <summary>倉庫→委託先→商品</summary>
            //Warehouce_ShipCustomer_Goods = 2,
            ///// <summary>倉庫→事業者→商品</summary>
            //Warehouce_CarrierEp_Goods = 3,
            ///// <summary>通番</summary>
            //SequenceNumber = 4
            // 2008.02.13 修正 >>>>>>>>>>>>>>>>>>>>
            ///// <summary>倉庫→棚番</summary>
            //Warehouce_ShelfNo = 0,
            ///// <summary>倉庫→仕入先</summary>
            //Warehouce_Customer = 1,
            ///// <summary>倉庫→ＢＬコード</summary>
            //Warehouce_BLCode = 2,
            ///// <summary>倉庫→メーカー</summary>
            //Warehouce_Maker = 3,
            ///// <summary>倉庫→仕入先→棚番</summary>
            //Warehouce_Customer_ShelfNo = 4,
            ///// <summary>倉庫→仕入先→メーカー</summary>
            //Warehouce_Customer_Maker = 5,
            ///// <summary>倉庫→棚番→メーカー→商品区分→商品</summary>
            //Warehouce_ShelfNo_GoodsDiv = 0,
            ///// <summary>倉庫→棚番→メーカー→商品</summary>
            //Warehouce_ShelfNo = 1,
            ///// <summary>倉庫→仕入先</summary>
            //Warehouce_Customer = 2,
            ///// <summary>倉庫→ＢＬコード</summary>
            //Warehouce_BLCode = 3,
            ///// <summary>倉庫→メーカー</summary>
            //Warehouce_Maker = 4,
            ///// <summary>倉庫→仕入先→棚番</summary>
            //Warehouce_Customer_ShelfNo = 5,
            ///// <summary>倉庫→仕入先→メーカー</summary>
            //Warehouce_Customer_Maker = 6,
            // 2008.02.13 修正 <<<<<<<<<<<<<<<<<<<<
            // 2007.09.14 修正 <<<<<<<<<<<<<<<<<<<<

            /// <summary>棚番順</summary>
            ShelfNo = 0,
            /// <summary>仕入先順</summary>
            Supplier = 1,
            /// <summary>ＢＬコード</summary>
            BLCode = 2,
            /// <summary>グループコード順</summary>
            GroupCode = 3,
            /// <summary>メーカー順</summary>
            Maker = 4,
            /// <summary>仕入先・棚番順</summary>
            Supplier_ShelfNo = 5,
            /// <summary>仕入先・メーカー順</summary>
            Supplier_Maker = 6,
            // 2008.10.31 30413 犬飼 ソート順の修正 <<<<<<END
            
        }

        public enum StockStateDiv
        {
            /// <summary>自社</summary>
            MyStock = 0,
            /// <summary>受託</summary>
            TrustStock = 1,
        }

        public enum StockState
        {
            /// <summary>在庫</summary>
            Stock = 0,
            /// <summary>受託中</summary>
            Trust = 10,
            /// <summary>委託中</summary>
            EnTrust = 20,
        }

        public enum StockUiDiv
        {
            /// <summary>自社</summary>
            UiStock = 0,
            /// <summary>受託</summary>
            UiTrust = 1,
            /// <summary>委託(自社)</summary>
            UiEnTrustStock = 2,
            /// <summary>委託(受託)</summary>
            UiEnTrustTrust = 3,
        }

        #endregion

        #region 名称取得

        /// <summary>
		/// ソート名称取得処理
		/// </summary>
		/// <param name="targetSortTitleState">ソート名称ステータス</param>
		/// <returns>ソート名称</returns>
		/// <remarks>
		/// <br>Note       : ソート名称の取得を行います。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.04.09</br>
        /// <br>Update Note: 2007.09.14 980035 金沢 貞義</br>
        /// <br>			 ・DC.NS対応</br>
        /// </remarks>
		public static string GetTargetSortTitle( int targetSortTitleState )
		{
			string SortTitle = "";
			switch( targetSortTitleState ) {
                // 2008.10.31 30413 犬飼 ソート名称の修正 >>>>>>START
                // 2007.09.14 修正 >>>>>>>>>>>>>>>>>>>>
				//case ( int )SortOrder.SequenceNumber:
				//{
				//	SortTitle = "通番";
				//	break;
				//}
                //case ( int )SortOrder.Warehouce_Goods:
                //{
                //	SortTitle = "倉庫→商品";
                //	break;
                //}
                //case ( int )SortOrder.Warehouce_Customer_Goods:
                //{
                //	SortTitle = "倉庫→仕入先→商品";
                //	break;
                //}
                //case ( int )SortOrder.Warehouce_ShipCustomer_Goods:
                //{
                //    SortTitle = "倉庫→委託先→商品";
                //    break;
                //}
                //case ( int )SortOrder.Warehouce_CarrierEp_Goods:
                //{
                //    SortTitle = "倉庫→事業者→商品";
                //    break;
                //}
                // 2008.02.13 修正 >>>>>>>>>>>>>>>>>>>>
                //case (int)SortOrder.Warehouce_ShelfNo:
                //{
                //    SortTitle = "倉庫→棚番";
                //    break;
                //}
                //case (int)SortOrder.ShelfNo:
                //{
                //    SortTitle = "倉庫→棚番→メーカー→商品区分→商品";
                //    break;
                //}
                //case (int)SortOrder.Supplier:
                //{
                //    SortTitle = "倉庫→棚番→メーカー→商品";
                //    break;
                //}
                //// 2008.02.13 修正 <<<<<<<<<<<<<<<<<<<<
                //case (int)SortOrder.BLCode:
                //{
                //    SortTitle = "倉庫→仕入先";
                //    break;
                //}
                //case (int)SortOrder.GroupCode:
                //{
                //    SortTitle = "倉庫→ＢＬコード";
                //    break;
                //}
                //case (int)SortOrder.Maker:
                //{
                //    SortTitle = "倉庫→メーカー";
                //    break;
                //}
                //case (int)SortOrder.Supplier_ShelfNo:
                //{
                //    SortTitle = "倉庫→仕入先→棚番";
                //    break;
                //}
                //case (int)SortOrder.Supplier_Maker:
                //{
                //    SortTitle = "倉庫→仕入先→メーカー";
                //    break;
                //}
            // 2007.09.14 修正 <<<<<<<<<<<<<<<<<<<<

            case (int)SortOrder.ShelfNo:
                {
                    SortTitle = "棚番";
                    break;
                }
            case (int)SortOrder.Supplier:
                {
                    SortTitle = "仕入先";
                    break;
                }
            case (int)SortOrder.BLCode:
                {
                    SortTitle = "ＢＬコード";
                    break;
                }
            case (int)SortOrder.GroupCode:
                {
                    SortTitle = "グループコード";
                    break;
                }
            case (int)SortOrder.Maker:
                {
                    SortTitle = "メーカー";
                    break;
                }
            case (int)SortOrder.Supplier_ShelfNo:
                {
                    SortTitle = "仕入先・棚番";
                    break;
                }
            case (int)SortOrder.Supplier_Maker:
                {
                    SortTitle = "仕入先・メーカー";
                    break;
                }
            // 2008.10.31 30413 犬飼 ソート名称の修正 >>>>>>START
            }
			return SortTitle;
		}

        /// <summary>
		/// 在庫区分名称取得処理
		/// </summary>
		/// <param name="targetStockDiv">在庫区分ステータス</param>
        /// <param name="targetStockState">在庫状態ステータス</param>
		/// <returns>在庫区分名称</returns>
		/// <remarks>
		/// <br>Note       : 在庫区分名称の取得を行います。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.04.20</br>
		/// </remarks>
		public static string GetTargetStockDivName( int targetStockDiv,int targetStockState )
		{
			string stockDivName = "";

			 switch(targetStockDiv)
            {
                //自社
                case (int)StockStateDiv.MyStock:
                {
                    switch(targetStockState)
                    {
                        //在庫
                        case (int)StockState.Stock:
                        {
                            stockDivName = "自社";
                            break;
                        }
                        //委託中
                        case (int)StockState.EnTrust:
                        {
                            stockDivName = "委託(自社)";
                            break;
                        }
                    }
                    break;
                }
                //受託
                case (int)StockStateDiv.TrustStock:
                {
                    switch(targetStockState)
                    {
                        //受託中
                        case (int)StockState.Trust:
                        {
                            stockDivName = "受託";
                            break;
                        }
                        //委託中
                        case (int)StockState.EnTrust:
                        {
                            stockDivName = "委託(受託)";
                            break;
                        }
                    }
                    break;
                }
            }
			return stockDivName;
		}

        /// <summary>
		/// 在庫区分UI連番取得処理
		/// </summary>
		/// <param name="targetStockDiv">在庫区分ステータス</param>
        /// <param name="targetStockState">在庫状態ステータス</param>
		/// <returns>在庫区分UI連番</returns>
		/// <remarks>
		/// <br>Note       : UI側で使用している在庫区分UI連番を取得します</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2007.04.23</br>
		/// </remarks>
		public static int GetUiStockDiv( int targetStockDiv,int targetStockState )
		{
			int stockUiDiv = 0;

			 switch(targetStockDiv)
            {
                //自社
                case (int)StockStateDiv.MyStock:
                {
                    switch(targetStockState)
                    {
                        //在庫
                        case (int)StockState.Stock:
                        {
                            stockUiDiv = (int)StockUiDiv.UiStock;
                            break;
                        }
                        //委託中
                        case (int)StockState.EnTrust:
                        {
                            stockUiDiv = (int)StockUiDiv.UiEnTrustStock;
                            break;
                        }
                    }
                    break;
                }
                //受託
                case (int)StockStateDiv.TrustStock:
                {
                    switch(targetStockState)
                    {
                        //受託中
                        case (int)StockState.Trust:
                        {
                            stockUiDiv = (int)StockUiDiv.UiTrust;
                            break;
                        }
                        //委託中
                        case (int)StockState.EnTrust:
                        {
                            stockUiDiv = (int)StockUiDiv.UiEnTrustTrust;
                            break;
                        }
                    }
                    break;
                }
            }
			return stockUiDiv;
		}

        #endregion
    }
}

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   StockShipArrivalListCndtnWork
	/// <summary>
	///                      在庫入出荷一覧表抽出条件クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   在庫入出荷一覧表抽出条件クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/07/15  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class StockShipArrivalListCndtnWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		/// <remarks>(配列)　全社指定は{""}</remarks>
		private string[] _sectionCodes;

		/// <summary>在庫登録日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _stockCreateDate;

		/// <summary>在庫登録日指定区分</summary>
		/// <remarks>0:以前 1:以降</remarks>
		private Int32 _stockCreateDateDiv;

		/// <summary>印刷タイプ</summary>
		/// <remarks>0:出荷＆入荷, 1:出荷, 2:入荷</remarks>
		private Int32 _shipArrivalPrintDiv;

		/// <summary>出荷数指定区分</summary>
		/// <remarks>0:出荷＆入荷, 1:出荷, 2:入荷</remarks>
		private Int32 _shipArrivalCntDiv;

		/// <summary>開始入出荷数</summary>
		/// <remarks>(以上)</remarks>
		private Int32 _st_ShipArrivalCnt;

		/// <summary>終了入出荷数</summary>
		/// <remarks>(以下)</remarks>
		private Int32 _ed_ShipArrivalCnt;

		/// <summary>開始年月度</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _st_AddUpYearMonth;

		/// <summary>終了年月度</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _ed_AddUpYearMonth;

		/// <summary>開始倉庫コード</summary>
		private string _st_WarehouseCode = "";

		/// <summary>終了倉庫コード</summary>
		private string _ed_WarehouseCode = "";

		/// <summary>開始仕入先コード</summary>
		private Int32 _st_SupplierCd;

		/// <summary>終了仕入先コード</summary>
		private Int32 _ed_SupplierCd;

		/// <summary>開始商品メーカーコード</summary>
		private Int32 _st_GoodsMakerCd;

		/// <summary>終了商品メーカーコード</summary>
		private Int32 _ed_GoodsMakerCd;

		/// <summary>開始BL商品コード</summary>
		private Int32 _st_BLGoodsCode;

		/// <summary>終了BL商品コード</summary>
		private Int32 _ed_BLGoodsCode;

		/// <summary>開始商品番号</summary>
		private string _st_GoodsNo = "";

		/// <summary>終了商品番号</summary>
		private string _ed_GoodsNo = "";

		/// <summary>開始商品区分</summary>
		private Int32 _st_EnterpriseGanreCode;

		/// <summary>終了商品区分</summary>
		private Int32 _ed_EnterpriseGanreCode;

        /// <summary>開始商品大分類</summary>
        private Int32 _st_GoodsLGroup;

        /// <summary>終了商品大分類</summary>
        private Int32 _ed_GoodsLGroup;

        /// <summary>開始商品中分類</summary>
        private Int32 _st_GoodsMGroup;

        /// <summary>終了商品中分類</summary>
        private Int32 _ed_GoodsMGroup;

        /// <summary>開始グループコード</summary>
        private Int32 _st_BLGroupCode;

        /// <summary>終了グループコード</summary>
        private Int32 _ed_BLGroupCode;


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

		/// public propaty name  :  SectionCodes
		/// <summary>拠点コードプロパティ</summary>
		/// <value>(配列)　全社指定は{""}</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] SectionCodes
		{
			get{return _sectionCodes;}
			set{_sectionCodes = value;}
		}

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
			get{return _stockCreateDate;}
			set{_stockCreateDate = value;}
		}

		/// public propaty name  :  StockCreateDateDiv
		/// <summary>在庫登録日指定区分プロパティ</summary>
		/// <value>0:以前 1:以降</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫登録日指定区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockCreateDateDiv
		{
			get{return _stockCreateDateDiv;}
			set{_stockCreateDateDiv = value;}
		}

		/// public propaty name  :  ShipArrivalPrintDiv
		/// <summary>印刷タイププロパティ</summary>
		/// <value>0:出荷＆入荷, 1:出荷, 2:入荷</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   印刷タイププロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ShipArrivalPrintDiv
		{
			get{return _shipArrivalPrintDiv;}
			set{_shipArrivalPrintDiv = value;}
		}

		/// public propaty name  :  ShipArrivalCntDiv
		/// <summary>出荷数指定区分プロパティ</summary>
		/// <value>0:出荷＆入荷, 1:出荷, 2:入荷</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出荷数指定区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ShipArrivalCntDiv
		{
			get{return _shipArrivalCntDiv;}
			set{_shipArrivalCntDiv = value;}
		}

		/// public propaty name  :  St_ShipArrivalCnt
		/// <summary>開始入出荷数プロパティ</summary>
		/// <value>(以上)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始入出荷数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_ShipArrivalCnt
		{
			get{return _st_ShipArrivalCnt;}
			set{_st_ShipArrivalCnt = value;}
		}

		/// public propaty name  :  Ed_ShipArrivalCnt
		/// <summary>終了入出荷数プロパティ</summary>
		/// <value>(以下)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了入出荷数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_ShipArrivalCnt
		{
			get{return _ed_ShipArrivalCnt;}
			set{_ed_ShipArrivalCnt = value;}
		}

		/// public propaty name  :  St_AddUpYearMonth
		/// <summary>開始年月度プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始年月度プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime St_AddUpYearMonth
		{
			get{return _st_AddUpYearMonth;}
			set{_st_AddUpYearMonth = value;}
		}

		/// public propaty name  :  Ed_AddUpYearMonth
		/// <summary>終了年月度プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了年月度プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime Ed_AddUpYearMonth
		{
			get{return _ed_AddUpYearMonth;}
			set{_ed_AddUpYearMonth = value;}
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
			get{return _st_WarehouseCode;}
			set{_st_WarehouseCode = value;}
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
			get{return _ed_WarehouseCode;}
			set{_ed_WarehouseCode = value;}
		}

		/// public propaty name  :  St_SupplierCd
		/// <summary>開始仕入先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始仕入先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_SupplierCd
		{
			get{return _st_SupplierCd;}
			set{_st_SupplierCd = value;}
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
			get{return _ed_SupplierCd;}
			set{_ed_SupplierCd = value;}
		}

		/// public propaty name  :  St_GoodsMakerCd
		/// <summary>開始商品メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始商品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_GoodsMakerCd
		{
			get{return _st_GoodsMakerCd;}
			set{_st_GoodsMakerCd = value;}
		}

		/// public propaty name  :  Ed_GoodsMakerCd
		/// <summary>終了商品メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了商品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_GoodsMakerCd
		{
			get{return _ed_GoodsMakerCd;}
			set{_ed_GoodsMakerCd = value;}
		}

		/// public propaty name  :  St_BLGoodsCode
		/// <summary>開始BL商品コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始BL商品コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_BLGoodsCode
		{
			get{return _st_BLGoodsCode;}
			set{_st_BLGoodsCode = value;}
		}

		/// public propaty name  :  Ed_BLGoodsCode
		/// <summary>終了BL商品コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了BL商品コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_BLGoodsCode
		{
			get{return _ed_BLGoodsCode;}
			set{_ed_BLGoodsCode = value;}
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
			get{return _st_GoodsNo;}
			set{_st_GoodsNo = value;}
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
			get{return _ed_GoodsNo;}
			set{_ed_GoodsNo = value;}
		}

		/// public propaty name  :  St_EnterpriseGanreCode
		/// <summary>開始商品区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始商品区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 St_EnterpriseGanreCode
		{
			get{return _st_EnterpriseGanreCode;}
			set{_st_EnterpriseGanreCode = value;}
		}

		/// public propaty name  :  Ed_EnterpriseGanreCode
		/// <summary>終了商品区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了商品区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Ed_EnterpriseGanreCode
		{
			get{return _ed_EnterpriseGanreCode;}
			set{_ed_EnterpriseGanreCode = value;}
		}


        /// public propaty name  :  St_GoodsLGroup
        /// <summary>開始商品大分類プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品大分類プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_GoodsLGroup
        {
            get { return _st_GoodsLGroup; }
            set { _st_GoodsLGroup = value; }
        }

        /// public propaty name  :  Ed_GoodsLGroup
        /// <summary>終了商品大分類プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品大分類プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_GoodsLGroup
        {
            get { return _ed_GoodsLGroup; }
            set { _ed_GoodsLGroup = value; }
        }

        /// public propaty name  :  St_GoodsMGroup
        /// <summary>開始商品中分類プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品中分類プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_GoodsMGroup
        {
            get { return _st_GoodsMGroup; }
            set { _st_GoodsMGroup = value; }
        }

        /// public propaty name  :  Ed_GoodsMGroup
        /// <summary>終了商品中分類プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品中分類プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_GoodsMGroup
        {
            get { return _ed_GoodsMGroup; }
            set { _ed_GoodsMGroup = value; }
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

		/// <summary>
		/// 在庫入出荷一覧表抽出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>StockShipArrivalListCndtnWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockShipArrivalListCndtnWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockShipArrivalListCndtnWork()
		{
		}

	}
}
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   StockSearchParaWork
	/// <summary>
	///                      在庫検索抽出条件クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   在庫検索抽出条件クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/07/10  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class StockSearchParaWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		private string _sectionCode = "";

		/// <summary>メーカーコード</summary>
		private Int32 _goodsMakerCd;

		/// <summary>品番</summary>
		private string _goodsNo = "";

		/// <summary>品番検索タイプ</summary>
		/// <remarks>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</remarks>
		private Int32 _goodsNoSrchTyp;

		/// <summary>品名</summary>
		private string _goodsName = "";

		/// <summary>品名検索タイプ</summary>
		/// <remarks>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</remarks>
		private Int32 _goodsNameSrchTyp;

		/// <summary>品名カナ</summary>
		private string _goodsNameKana = "";

		/// <summary>品名検索タイプ</summary>
		/// <remarks>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</remarks>
		private Int32 _goodsNameKanaSrchTyp;

		/// <summary>自社分類コード</summary>
		private Int32 _enterpriseGanreCode;

		/// <summary>BL商品コード</summary>
		private Int32 _bLGoodsCode;

		/// <summary>倉庫コード</summary>
		private string _warehouseCode = "";

		/// <summary>ゼロ在庫表示区分</summary>
		/// <remarks>0:する,1:しない</remarks>
		private Int32 _zeroStckDsp;

		/// <summary>商品番号(複数)</summary>
		/// <remarks>(配列)複数商品番号指定時に使用</remarks>
		private string[] _goodsNos;

		/// <summary>メーカーコード(複数)</summary>
		/// <remarks>(配列)複数メーカーコード指定時に使用</remarks>
		private Int32[] _goodsMakerCds;

		/// <summary>倉庫コード(複数)</summary>
		/// <remarks>(配列)複数倉庫コード指定時に使用</remarks>
		private string[] _warehouseCodes;

		/// <summary>倉庫棚番</summary>
		private string _warehouseShelfNo = "";

		/// <summary>倉庫棚番検索タイプ</summary>
		/// <remarks>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</remarks>
		private Int32 _warehouseShelfNoSrchTyp;

		/// <summary>対象日付区分</summary>
		/// <remarks>0:更新日付、1:登録日付</remarks>
		private Int32 _dateDiv;

		/// <summary>開始対象日付</summary>
		private DateTime _st_Date;

		/// <summary>終了対象日付</summary>
		private DateTime _ed_Date;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
        /// <summary>計上日付</summary>
        private DateTime _pricestartdate;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD


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

		/// public propaty name  :  GoodsMakerCd
		/// <summary>メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsMakerCd
		{
			get{return _goodsMakerCd;}
			set{_goodsMakerCd = value;}
		}

		/// public propaty name  :  GoodsNo
		/// <summary>品番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   品番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNo
		{
			get{return _goodsNo;}
			set{_goodsNo = value;}
		}

		/// public propaty name  :  GoodsNoSrchTyp
		/// <summary>品番検索タイププロパティ</summary>
		/// <value>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   品番検索タイププロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsNoSrchTyp
		{
			get{return _goodsNoSrchTyp;}
			set{_goodsNoSrchTyp = value;}
		}

		/// public propaty name  :  GoodsName
		/// <summary>品名プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   品名プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsName
		{
			get{return _goodsName;}
			set{_goodsName = value;}
		}

		/// public propaty name  :  GoodsNameSrchTyp
		/// <summary>品名検索タイププロパティ</summary>
		/// <value>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   品名検索タイププロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsNameSrchTyp
		{
			get{return _goodsNameSrchTyp;}
			set{_goodsNameSrchTyp = value;}
		}

		/// public propaty name  :  GoodsNameKana
		/// <summary>品名カナプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   品名カナプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNameKana
		{
			get{return _goodsNameKana;}
			set{_goodsNameKana = value;}
		}

		/// public propaty name  :  GoodsNameKanaSrchTyp
		/// <summary>品名検索タイププロパティ</summary>
		/// <value>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   品名検索タイププロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsNameKanaSrchTyp
		{
			get{return _goodsNameKanaSrchTyp;}
			set{_goodsNameKanaSrchTyp = value;}
		}

		/// public propaty name  :  EnterpriseGanreCode
		/// <summary>自社分類コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自社分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EnterpriseGanreCode
		{
			get{return _enterpriseGanreCode;}
			set{_enterpriseGanreCode = value;}
		}

		/// public propaty name  :  BLGoodsCode
		/// <summary>BL商品コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL商品コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BLGoodsCode
		{
			get{return _bLGoodsCode;}
			set{_bLGoodsCode = value;}
		}

		/// public propaty name  :  WarehouseCode
		/// <summary>倉庫コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string WarehouseCode
		{
			get{return _warehouseCode;}
			set{_warehouseCode = value;}
		}

		/// public propaty name  :  ZeroStckDsp
		/// <summary>ゼロ在庫表示区分プロパティ</summary>
		/// <value>0:する,1:しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ゼロ在庫表示区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ZeroStckDsp
		{
			get{return _zeroStckDsp;}
			set{_zeroStckDsp = value;}
		}

		/// public propaty name  :  GoodsNos
		/// <summary>商品番号(複数)プロパティ</summary>
		/// <value>(配列)複数商品番号指定時に使用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品番号(複数)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] GoodsNos
		{
			get{return _goodsNos;}
			set{_goodsNos = value;}
		}

		/// public propaty name  :  GoodsMakerCds
		/// <summary>メーカーコード(複数)プロパティ</summary>
		/// <value>(配列)複数メーカーコード指定時に使用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカーコード(複数)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32[] GoodsMakerCds
		{
			get{return _goodsMakerCds;}
			set{_goodsMakerCds = value;}
		}

		/// public propaty name  :  WarehouseCodes
		/// <summary>倉庫コード(複数)プロパティ</summary>
		/// <value>(配列)複数倉庫コード指定時に使用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫コード(複数)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] WarehouseCodes
		{
			get{return _warehouseCodes;}
			set{_warehouseCodes = value;}
		}

		/// public propaty name  :  WarehouseShelfNo
		/// <summary>倉庫棚番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫棚番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string WarehouseShelfNo
		{
			get{return _warehouseShelfNo;}
			set{_warehouseShelfNo = value;}
		}

		/// public propaty name  :  WarehouseShelfNoSrchTyp
		/// <summary>倉庫棚番検索タイププロパティ</summary>
		/// <value>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫棚番検索タイププロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 WarehouseShelfNoSrchTyp
		{
			get{return _warehouseShelfNoSrchTyp;}
			set{_warehouseShelfNoSrchTyp = value;}
		}

		/// public propaty name  :  DateDiv
		/// <summary>対象日付区分プロパティ</summary>
		/// <value>0:更新日付、1:登録日付</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   対象日付区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DateDiv
		{
			get{return _dateDiv;}
			set{_dateDiv = value;}
		}

		/// public propaty name  :  St_Date
		/// <summary>開始対象日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始対象日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime St_Date
		{
			get{return _st_Date;}
			set{_st_Date = value;}
		}

		/// public propaty name  :  Ed_Date
		/// <summary>終了対象日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了対象日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime Ed_Date
		{
			get{return _ed_Date;}
			set{_ed_Date = value;}
		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  T.Nishi 2012/04/10 ADD
        /// public propaty name  :  pricestartdate
        /// <summary>計上対象日付プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上対象日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime pricestartdate
        {
            get { return _pricestartdate; }
            set { _pricestartdate = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  T.Nishi 2012/04/10 ADD

		/// <summary>
		/// 在庫検索抽出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>StockSearchParaWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockSearchParaWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockSearchParaWork()
		{
		}

	}
}

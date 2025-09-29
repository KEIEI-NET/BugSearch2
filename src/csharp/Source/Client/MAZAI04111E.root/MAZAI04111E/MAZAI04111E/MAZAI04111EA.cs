using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   StockSearchPara
	/// <summary>
	///                      在庫検索抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   在庫検索抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/08/01  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class StockSearchPara
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
		private Int32 _st_Date;

		/// <summary>終了対象日付</summary>
		private Int32 _ed_Date;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>BL商品コード名称</summary>
		private string _bLGoodsName = "";

		/// <summary>倉庫名称</summary>
		private string _warehouseName = "";

        private Int32 _supplierCd;

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
		public Int32 St_Date
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
		public Int32 Ed_Date
		{
			get{return _ed_Date;}
			set{_ed_Date = value;}
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

		/// public propaty name  :  BLGoodsName
		/// <summary>BL商品コード名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL商品コード名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BLGoodsName
		{
			get{return _bLGoodsName;}
			set{_bLGoodsName = value;}
		}

		/// public propaty name  :  WarehouseName
		/// <summary>倉庫名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string WarehouseName
		{
			get{return _warehouseName;}
			set{_warehouseName = value;}
		}

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

		/// <summary>
		/// 在庫検索抽出条件クラスコンストラクタ
		/// </summary>
		/// <returns>StockSearchParaクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockSearchParaクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockSearchPara()
		{
		}

		/// <summary>
		/// 在庫検索抽出条件クラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="goodsMakerCd">メーカーコード</param>
		/// <param name="goodsNo">品番</param>
		/// <param name="goodsNoSrchTyp">品番検索タイプ(0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索)</param>
		/// <param name="goodsName">品名</param>
		/// <param name="goodsNameSrchTyp">品名検索タイプ(0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索)</param>
		/// <param name="goodsNameKana">品名カナ</param>
		/// <param name="goodsNameKanaSrchTyp">品名検索タイプ(0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索)</param>
		/// <param name="enterpriseGanreCode">自社分類コード</param>
		/// <param name="bLGoodsCode">BL商品コード</param>
		/// <param name="warehouseCode">倉庫コード</param>
		/// <param name="zeroStckDsp">ゼロ在庫表示区分(0:する,1:しない)</param>
		/// <param name="goodsNos">商品番号(複数)((配列)複数商品番号指定時に使用)</param>
		/// <param name="goodsMakerCds">メーカーコード(複数)((配列)複数メーカーコード指定時に使用)</param>
		/// <param name="warehouseCodes">倉庫コード(複数)((配列)複数倉庫コード指定時に使用)</param>
		/// <param name="warehouseShelfNo">倉庫棚番</param>
		/// <param name="warehouseShelfNoSrchTyp">倉庫棚番検索タイプ(0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索)</param>
		/// <param name="dateDiv">対象日付区分(0:更新日付、1:登録日付)</param>
		/// <param name="st_Date">開始対象日付</param>
		/// <param name="ed_Date">終了対象日付</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="bLGoodsName">BL商品コード名称</param>
		/// <param name="warehouseName">倉庫名称</param>
        /// <param name="supplierCd">仕入先コード</param>
		/// <returns>StockSearchParaクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockSearchParaクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockSearchPara(string enterpriseCode,string sectionCode,Int32 goodsMakerCd,string goodsNo,Int32 goodsNoSrchTyp,string goodsName,Int32 goodsNameSrchTyp,string goodsNameKana,Int32 goodsNameKanaSrchTyp,Int32 enterpriseGanreCode,Int32 bLGoodsCode,string warehouseCode,Int32 zeroStckDsp,string[] goodsNos,Int32[] goodsMakerCds,string[] warehouseCodes,string warehouseShelfNo,Int32 warehouseShelfNoSrchTyp,Int32 dateDiv,Int32 st_Date,Int32 ed_Date,string enterpriseName,string bLGoodsName,string warehouseName, Int32 supplierCd)
		{
			this._enterpriseCode = enterpriseCode;
			this._sectionCode = sectionCode;
			this._goodsMakerCd = goodsMakerCd;
			this._goodsNo = goodsNo;
			this._goodsNoSrchTyp = goodsNoSrchTyp;
			this._goodsName = goodsName;
			this._goodsNameSrchTyp = goodsNameSrchTyp;
			this._goodsNameKana = goodsNameKana;
			this._goodsNameKanaSrchTyp = goodsNameKanaSrchTyp;
			this._enterpriseGanreCode = enterpriseGanreCode;
			this._bLGoodsCode = bLGoodsCode;
			this._warehouseCode = warehouseCode;
			this._zeroStckDsp = zeroStckDsp;
			this._goodsNos = goodsNos;
			this._goodsMakerCds = goodsMakerCds;
			this._warehouseCodes = warehouseCodes;
			this._warehouseShelfNo = warehouseShelfNo;
			this._warehouseShelfNoSrchTyp = warehouseShelfNoSrchTyp;
			this._dateDiv = dateDiv;
			this._st_Date = st_Date;
			this._ed_Date = ed_Date;
			this._enterpriseName = enterpriseName;
			this._bLGoodsName = bLGoodsName;
			this._warehouseName = warehouseName;
            this._supplierCd = supplierCd;
		}

		/// <summary>
		/// 在庫検索抽出条件クラス複製処理
		/// </summary>
		/// <returns>StockSearchParaクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいStockSearchParaクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockSearchPara Clone()
		{
			return new StockSearchPara(this._enterpriseCode,this._sectionCode,this._goodsMakerCd,this._goodsNo,this._goodsNoSrchTyp,this._goodsName,this._goodsNameSrchTyp,this._goodsNameKana,this._goodsNameKanaSrchTyp,this._enterpriseGanreCode,this._bLGoodsCode,this._warehouseCode,this._zeroStckDsp,this._goodsNos,this._goodsMakerCds,this._warehouseCodes,this._warehouseShelfNo,this._warehouseShelfNoSrchTyp,this._dateDiv,this._st_Date,this._ed_Date,this._enterpriseName,this._bLGoodsName,this._warehouseName, this._supplierCd);
		}

		/// <summary>
		/// 在庫検索抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のStockSearchParaクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockSearchParaクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(StockSearchPara target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SectionCode == target.SectionCode)
				 && (this.GoodsMakerCd == target.GoodsMakerCd)
				 && (this.GoodsNo == target.GoodsNo)
				 && (this.GoodsNoSrchTyp == target.GoodsNoSrchTyp)
				 && (this.GoodsName == target.GoodsName)
				 && (this.GoodsNameSrchTyp == target.GoodsNameSrchTyp)
				 && (this.GoodsNameKana == target.GoodsNameKana)
				 && (this.GoodsNameKanaSrchTyp == target.GoodsNameKanaSrchTyp)
				 && (this.EnterpriseGanreCode == target.EnterpriseGanreCode)
				 && (this.BLGoodsCode == target.BLGoodsCode)
				 && (this.WarehouseCode == target.WarehouseCode)
				 && (this.ZeroStckDsp == target.ZeroStckDsp)
				 && (this.GoodsNos == target.GoodsNos)
				 && (this.GoodsMakerCds == target.GoodsMakerCds)
				 && (this.WarehouseCodes == target.WarehouseCodes)
				 && (this.WarehouseShelfNo == target.WarehouseShelfNo)
				 && (this.WarehouseShelfNoSrchTyp == target.WarehouseShelfNoSrchTyp)
				 && (this.DateDiv == target.DateDiv)
				 && (this.St_Date == target.St_Date)
				 && (this.Ed_Date == target.Ed_Date)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.BLGoodsName == target.BLGoodsName)
                 && (this.WarehouseName == target.WarehouseName)
                 && (this.SupplierCd == target.SupplierCd)
                 );
		}

		/// <summary>
		/// 在庫検索抽出条件クラス比較処理
		/// </summary>
		/// <param name="stockSearchPara1">
		///                    比較するStockSearchParaクラスのインスタンス
		/// </param>
		/// <param name="stockSearchPara2">比較するStockSearchParaクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockSearchParaクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(StockSearchPara stockSearchPara1, StockSearchPara stockSearchPara2)
		{
			return ((stockSearchPara1.EnterpriseCode == stockSearchPara2.EnterpriseCode)
				 && (stockSearchPara1.SectionCode == stockSearchPara2.SectionCode)
				 && (stockSearchPara1.GoodsMakerCd == stockSearchPara2.GoodsMakerCd)
				 && (stockSearchPara1.GoodsNo == stockSearchPara2.GoodsNo)
				 && (stockSearchPara1.GoodsNoSrchTyp == stockSearchPara2.GoodsNoSrchTyp)
				 && (stockSearchPara1.GoodsName == stockSearchPara2.GoodsName)
				 && (stockSearchPara1.GoodsNameSrchTyp == stockSearchPara2.GoodsNameSrchTyp)
				 && (stockSearchPara1.GoodsNameKana == stockSearchPara2.GoodsNameKana)
				 && (stockSearchPara1.GoodsNameKanaSrchTyp == stockSearchPara2.GoodsNameKanaSrchTyp)
				 && (stockSearchPara1.EnterpriseGanreCode == stockSearchPara2.EnterpriseGanreCode)
				 && (stockSearchPara1.BLGoodsCode == stockSearchPara2.BLGoodsCode)
				 && (stockSearchPara1.WarehouseCode == stockSearchPara2.WarehouseCode)
				 && (stockSearchPara1.ZeroStckDsp == stockSearchPara2.ZeroStckDsp)
				 && (stockSearchPara1.GoodsNos == stockSearchPara2.GoodsNos)
				 && (stockSearchPara1.GoodsMakerCds == stockSearchPara2.GoodsMakerCds)
				 && (stockSearchPara1.WarehouseCodes == stockSearchPara2.WarehouseCodes)
				 && (stockSearchPara1.WarehouseShelfNo == stockSearchPara2.WarehouseShelfNo)
				 && (stockSearchPara1.WarehouseShelfNoSrchTyp == stockSearchPara2.WarehouseShelfNoSrchTyp)
				 && (stockSearchPara1.DateDiv == stockSearchPara2.DateDiv)
				 && (stockSearchPara1.St_Date == stockSearchPara2.St_Date)
				 && (stockSearchPara1.Ed_Date == stockSearchPara2.Ed_Date)
				 && (stockSearchPara1.EnterpriseName == stockSearchPara2.EnterpriseName)
				 && (stockSearchPara1.BLGoodsName == stockSearchPara2.BLGoodsName)
                 && (stockSearchPara1.WarehouseName == stockSearchPara2.WarehouseName)
                 && (stockSearchPara1.SupplierCd == stockSearchPara2.SupplierCd)
                 );
		}
		/// <summary>
		/// 在庫検索抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のStockSearchParaクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockSearchParaクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(StockSearchPara target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.GoodsMakerCd != target.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(this.GoodsNo != target.GoodsNo)resList.Add("GoodsNo");
			if(this.GoodsNoSrchTyp != target.GoodsNoSrchTyp)resList.Add("GoodsNoSrchTyp");
			if(this.GoodsName != target.GoodsName)resList.Add("GoodsName");
			if(this.GoodsNameSrchTyp != target.GoodsNameSrchTyp)resList.Add("GoodsNameSrchTyp");
			if(this.GoodsNameKana != target.GoodsNameKana)resList.Add("GoodsNameKana");
			if(this.GoodsNameKanaSrchTyp != target.GoodsNameKanaSrchTyp)resList.Add("GoodsNameKanaSrchTyp");
			if(this.EnterpriseGanreCode != target.EnterpriseGanreCode)resList.Add("EnterpriseGanreCode");
			if(this.BLGoodsCode != target.BLGoodsCode)resList.Add("BLGoodsCode");
			if(this.WarehouseCode != target.WarehouseCode)resList.Add("WarehouseCode");
			if(this.ZeroStckDsp != target.ZeroStckDsp)resList.Add("ZeroStckDsp");
			if(this.GoodsNos != target.GoodsNos)resList.Add("GoodsNos");
			if(this.GoodsMakerCds != target.GoodsMakerCds)resList.Add("GoodsMakerCds");
			if(this.WarehouseCodes != target.WarehouseCodes)resList.Add("WarehouseCodes");
			if(this.WarehouseShelfNo != target.WarehouseShelfNo)resList.Add("WarehouseShelfNo");
			if(this.WarehouseShelfNoSrchTyp != target.WarehouseShelfNoSrchTyp)resList.Add("WarehouseShelfNoSrchTyp");
			if(this.DateDiv != target.DateDiv)resList.Add("DateDiv");
			if(this.St_Date != target.St_Date)resList.Add("St_Date");
			if(this.Ed_Date != target.Ed_Date)resList.Add("Ed_Date");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.BLGoodsName != target.BLGoodsName)resList.Add("BLGoodsName");
            if (this.WarehouseName != target.WarehouseName) resList.Add("WarehouseName");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");

            // 商品コード(複数指定)
            if (this.GoodsNos.Length != target.GoodsNos.Length)
            {
                resList.Add("GoodsNos");
            }
            else
            {
                bool isExsist = false;

                foreach (string wk1 in target.GoodsNos)
                {
                    isExsist = false;
                    foreach (string wk2 in this.GoodsNos)
                    {
                        if (wk1.Equals(wk2))
                        {
                            isExsist = true;
                            break;
                        }
                    }
                    if (!isExsist)
                    {
                        resList.Add("GoodsNos");
                        break;
                    }
                }
            }

            // メーカーコード(複数指定)
            if (this.GoodsMakerCds.Length != target.GoodsMakerCds.Length)
            {
                resList.Add("GoodsMakerCds");
            }
            else
            {
                bool isExsist = false;

                foreach (int wk1 in target.GoodsMakerCds)
                {
                    isExsist = false;
                    foreach (int wk2 in this.GoodsMakerCds)
                    {
                        if (wk1.Equals(wk2))
                        {
                            isExsist = true;
                            break;
                        }
                    }
                    if (!isExsist)
                    {
                        resList.Add("GoodsMakerCds");
                        break;
                    }
                }
            }

            // 倉庫コード(複数指定)
            if (this.WarehouseCodes.Length != target.WarehouseCodes.Length)
            {
                resList.Add("WarehouseCodes");
            }
            else
            {
                bool isExsist = false;

                foreach (string wk1 in target.WarehouseCodes)
                {
                    isExsist = false;
                    foreach (string wk2 in this.WarehouseCodes)
                    {
                        if (wk1.Equals(wk2))
                        {
                            isExsist = true;
                            break;
                        }
                    }
                    if (!isExsist)
                    {
                        resList.Add("WarehouseCodes");
                        break;
                    }
                }
            }
			return resList;
		}

		/// <summary>
		/// 在庫検索抽出条件クラス比較処理
		/// </summary>
		/// <param name="stockSearchPara1">比較するStockSearchParaクラスのインスタンス</param>
		/// <param name="stockSearchPara2">比較するStockSearchParaクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockSearchParaクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(StockSearchPara stockSearchPara1, StockSearchPara stockSearchPara2)
		{
			ArrayList resList = new ArrayList();
			if(stockSearchPara1.EnterpriseCode != stockSearchPara2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(stockSearchPara1.SectionCode != stockSearchPara2.SectionCode)resList.Add("SectionCode");
			if(stockSearchPara1.GoodsMakerCd != stockSearchPara2.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(stockSearchPara1.GoodsNo != stockSearchPara2.GoodsNo)resList.Add("GoodsNo");
			if(stockSearchPara1.GoodsNoSrchTyp != stockSearchPara2.GoodsNoSrchTyp)resList.Add("GoodsNoSrchTyp");
			if(stockSearchPara1.GoodsName != stockSearchPara2.GoodsName)resList.Add("GoodsName");
			if(stockSearchPara1.GoodsNameSrchTyp != stockSearchPara2.GoodsNameSrchTyp)resList.Add("GoodsNameSrchTyp");
			if(stockSearchPara1.GoodsNameKana != stockSearchPara2.GoodsNameKana)resList.Add("GoodsNameKana");
			if(stockSearchPara1.GoodsNameKanaSrchTyp != stockSearchPara2.GoodsNameKanaSrchTyp)resList.Add("GoodsNameKanaSrchTyp");
			if(stockSearchPara1.EnterpriseGanreCode != stockSearchPara2.EnterpriseGanreCode)resList.Add("EnterpriseGanreCode");
			if(stockSearchPara1.BLGoodsCode != stockSearchPara2.BLGoodsCode)resList.Add("BLGoodsCode");
			if(stockSearchPara1.WarehouseCode != stockSearchPara2.WarehouseCode)resList.Add("WarehouseCode");
			if(stockSearchPara1.ZeroStckDsp != stockSearchPara2.ZeroStckDsp)resList.Add("ZeroStckDsp");
			if(stockSearchPara1.GoodsNos != stockSearchPara2.GoodsNos)resList.Add("GoodsNos");
			if(stockSearchPara1.GoodsMakerCds != stockSearchPara2.GoodsMakerCds)resList.Add("GoodsMakerCds");
			if(stockSearchPara1.WarehouseCodes != stockSearchPara2.WarehouseCodes)resList.Add("WarehouseCodes");
			if(stockSearchPara1.WarehouseShelfNo != stockSearchPara2.WarehouseShelfNo)resList.Add("WarehouseShelfNo");
			if(stockSearchPara1.WarehouseShelfNoSrchTyp != stockSearchPara2.WarehouseShelfNoSrchTyp)resList.Add("WarehouseShelfNoSrchTyp");
			if(stockSearchPara1.DateDiv != stockSearchPara2.DateDiv)resList.Add("DateDiv");
			if(stockSearchPara1.St_Date != stockSearchPara2.St_Date)resList.Add("St_Date");
			if(stockSearchPara1.Ed_Date != stockSearchPara2.Ed_Date)resList.Add("Ed_Date");
			if(stockSearchPara1.EnterpriseName != stockSearchPara2.EnterpriseName)resList.Add("EnterpriseName");
			if(stockSearchPara1.BLGoodsName != stockSearchPara2.BLGoodsName)resList.Add("BLGoodsName");
            if (stockSearchPara1.WarehouseName != stockSearchPara2.WarehouseName) resList.Add("WarehouseName");
            if (stockSearchPara1.SupplierCd != stockSearchPara2.SupplierCd) resList.Add("SupplierCd");

            // 商品コード(複数指定)
            if (stockSearchPara1.GoodsNos.Length != stockSearchPara2.GoodsNos.Length)
            {
                resList.Add("GoodsNos");
            }
            else
            {
                bool isExsist = false;

                foreach (string wk1 in stockSearchPara2.GoodsNos)
                {
                    isExsist = false;
                    foreach (string wk2 in stockSearchPara1.GoodsNos)
                    {
                        if (wk1.Equals(wk2))
                        {
                            isExsist = true;
                            break;
                        }
                    }
                    if (!isExsist)
                    {
                        resList.Add("GoodsNos");
                        break;
                    }
                }
            }

            // メーカーコード(複数指定)
            if (stockSearchPara1.GoodsMakerCds.Length != stockSearchPara2.GoodsMakerCds.Length)
            {
                resList.Add("GoodsMakerCds");
            }
            else
            {
                bool isExsist = false;

                foreach (int wk1 in stockSearchPara2.GoodsMakerCds)
                {
                    isExsist = false;
                    foreach (int wk2 in stockSearchPara1.GoodsMakerCds)
                    {
                        if (wk1.Equals(wk2))
                        {
                            isExsist = true;
                            break;
                        }
                    }
                    if (!isExsist)
                    {
                        resList.Add("GoodsMakerCds");
                        break;
                    }
                }
            }

            // 倉庫コード(複数指定)
            if (stockSearchPara1.WarehouseCodes.Length != stockSearchPara2.WarehouseCodes.Length)
            {
                resList.Add("WarehouseCodes");
            }
            else
            {
                bool isExsist = false;

                foreach (string wk1 in stockSearchPara2.WarehouseCodes)
                {
                    isExsist = false;
                    foreach (string wk2 in stockSearchPara1.WarehouseCodes)
                    {
                        if (wk1.Equals(wk2))
                        {
                            isExsist = true;
                            break;
                        }
                    }
                    if (!isExsist)
                    {
                        resList.Add("WarehouseCodes");
                        break;
                    }
                }
            }
			return resList;
		}
	}
}


//using System;
//using System.Collections;

//namespace Broadleaf.Application.UIData
//{
//    /// public class name:   StockSearchPara
//    /// <summary>
//    ///                      在庫検索抽出条件ワーク
//    /// </summary>
//    /// <remarks>
//    /// <br>note             :   在庫検索抽出条件ワークヘッダファイル</br>
//    /// <br>Programmer       :   自動生成</br>
//    /// <br>Date             :   </br>
//    /// <br>Genarated Date   :   2007/09/07  (CSharp File Generated Date)</br>
//    /// <br></br>
//    /// <br>Update Note      :   2007/09/07 鈴木正臣</br>
//    /// <br>                 :   流通.NS用に作成。配列項目はツール非対応の為,手で修正。</br>
//    /// </remarks>
//    public class StockSearchPara
//    {
//        /// <summary>企業コード</summary>
//        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
//        private string _enterpriseCode = "";

//        /// <summary>拠点コード</summary>
//        private string _sectionCode = "";

//        /// <summary>メーカーコード</summary>
//        private Int32 _goodsMakerCd;

//        /// <summary>メーカー名称</summary>
//        private string _makerName = "";

//        /// <summary>商品コード</summary>
//        private string _goodsNo = "";

//        /// <summary>商品コード検索タイプ</summary>
//        /// <remarks>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</remarks>
//        private Int32 _goodsNoSrchTyp;

//        /// <summary>商品名称</summary>
//        private string _goodsName = "";

//        /// <summary>商品名称カナ</summary>
//        private string _goodsNameKana = "";

//        /// <summary>商品区分グループコード</summary>
//        /// <remarks>旧：商品大分類コード</remarks>
//        private string _largeGoodsGanreCode = "";

//        /// <summary>商品区分グループ名称</summary>
//        /// <remarks>旧：商品大分類名称</remarks>
//        private string _largeGoodsGanreName = "";

//        /// <summary>商品区分コード</summary>
//        /// <remarks>旧：商品中分類コード</remarks>
//        private string _mediumGoodsGanreCode = "";

//        /// <summary>商品区分名称</summary>
//        /// <remarks>旧：商品中分類名称</remarks>
//        private string _mediumGoodsGanreName = "";

//        /// <summary>商品区分詳細コード</summary>
//        private string _detailGoodsGanreCode = "";

//        /// <summary>商品区分詳細名称</summary>
//        private string _detailGoodsGanreName = "";

//        /// <summary>自社分類コード</summary>
//        private Int32 _enterpriseGanreCode;

//        /// <summary>自社分類名称</summary>
//        private string _enterpriseGanreName = "";

//        /// <summary>BL商品コード</summary>
//        private Int32 _bLGoodsCode;

//        /// <summary>BL商品コード名称（全角）</summary>
//        private string _bLGoodsFullName = "";

//        /// <summary>倉庫コード</summary>
//        private string _warehouseCode;

//        /// <summary>倉庫名称</summary>
//        private string _warehouseName = "";

//        /// <summary>得意先コード</summary>
//        private Int32 _customerCode;

//        /// <summary>得意先名称</summary>
//        private string _customerName = "";

//        /// <summary>ゼロ在庫表示区分</summary>
//        /// <remarks>0:する,1:しない</remarks>
//        private Int32 _zeroStckDsp;

//        /// <summary>商品番号(複数)</summary>
//        /// <remarks>(配列)複数商品番号指定時に使用</remarks>
//        private string[] _goodsNos;

//        /// <summary>メーカーコード(複数)</summary>
//        /// <remarks>(配列)複数メーカーコード指定時に使用</remarks>
//        private Int32[] _goodsMakerCds;

//        /// <summary>倉庫コード(複数)</summary>
//        /// <remarks>(配列)複数倉庫コード指定時に使用</remarks>
//        private string[] _warehouseCodes;

//        /// <summary>企業名称</summary>
//        private string _enterpriseName = "";

//        /// <summary>BL商品コード名称</summary>
//        private string _bLGoodsName = "";


//        /// public propaty name  :  EnterpriseCode
//        /// <summary>企業コードプロパティ</summary>
//        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   企業コードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string EnterpriseCode
//        {
//            get { return _enterpriseCode; }
//            set { _enterpriseCode = value; }
//        }

//        /// public propaty name  :  SectionCode
//        /// <summary>拠点コードプロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   拠点コードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string SectionCode
//        {
//            get { return _sectionCode; }
//            set { _sectionCode = value; }
//        }

//        /// public propaty name  :  GoodsMakerCd
//        /// <summary>メーカーコードプロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   メーカーコードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 GoodsMakerCd
//        {
//            get { return _goodsMakerCd; }
//            set { _goodsMakerCd = value; }
//        }

//        /// public propaty name  :  MakerName
//        /// <summary>メーカー名称プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   メーカー名称プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string MakerName
//        {
//            get { return _makerName; }
//            set { _makerName = value; }
//        }

//        /// public propaty name  :  GoodsNo
//        /// <summary>商品コードプロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   商品コードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string GoodsNo
//        {
//            get { return _goodsNo; }
//            set { _goodsNo = value; }
//        }

//        /// public propaty name  :  GoodsNoSrchTyp
//        /// <summary>商品コード検索タイププロパティ</summary>
//        /// <value>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   商品コード検索タイププロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 GoodsNoSrchTyp
//        {
//            get { return _goodsNoSrchTyp; }
//            set { _goodsNoSrchTyp = value; }
//        }

//        /// public propaty name  :  GoodsName
//        /// <summary>商品名称プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   商品名称プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string GoodsName
//        {
//            get { return _goodsName; }
//            set { _goodsName = value; }
//        }

//        /// public propaty name  :  GoodsNameKana
//        /// <summary>商品名称カナプロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   商品名称カナプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string GoodsNameKana
//        {
//            get { return _goodsNameKana; }
//            set { _goodsNameKana = value; }
//        }

//        /// public propaty name  :  LargeGoodsGanreCode
//        /// <summary>商品区分グループコードプロパティ</summary>
//        /// <value>旧：商品大分類コード</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   商品区分グループコードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string LargeGoodsGanreCode
//        {
//            get { return _largeGoodsGanreCode; }
//            set { _largeGoodsGanreCode = value; }
//        }

//        /// public propaty name  :  LargeGoodsGanreName
//        /// <summary>商品区分グループ名称プロパティ</summary>
//        /// <value>旧：商品大分類名称</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   商品区分グループ名称プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string LargeGoodsGanreName
//        {
//            get { return _largeGoodsGanreName; }
//            set { _largeGoodsGanreName = value; }
//        }

//        /// public propaty name  :  MediumGoodsGanreCode
//        /// <summary>商品区分コードプロパティ</summary>
//        /// <value>旧：商品中分類コード</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   商品区分コードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string MediumGoodsGanreCode
//        {
//            get { return _mediumGoodsGanreCode; }
//            set { _mediumGoodsGanreCode = value; }
//        }

//        /// public propaty name  :  MediumGoodsGanreName
//        /// <summary>商品区分名称プロパティ</summary>
//        /// <value>旧：商品中分類名称</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   商品区分名称プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string MediumGoodsGanreName
//        {
//            get { return _mediumGoodsGanreName; }
//            set { _mediumGoodsGanreName = value; }
//        }

//        /// public propaty name  :  DetailGoodsGanreCode
//        /// <summary>商品区分詳細コードプロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   商品区分詳細コードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string DetailGoodsGanreCode
//        {
//            get { return _detailGoodsGanreCode; }
//            set { _detailGoodsGanreCode = value; }
//        }

//        /// public propaty name  :  DetailGoodsGanreName
//        /// <summary>商品区分詳細名称プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   商品区分詳細名称プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string DetailGoodsGanreName
//        {
//            get { return _detailGoodsGanreName; }
//            set { _detailGoodsGanreName = value; }
//        }

//        /// public propaty name  :  EnterpriseGanreCode
//        /// <summary>自社分類コードプロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   自社分類コードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 EnterpriseGanreCode
//        {
//            get { return _enterpriseGanreCode; }
//            set { _enterpriseGanreCode = value; }
//        }

//        /// public propaty name  :  EnterpriseGanreName
//        /// <summary>自社分類名称プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   自社分類名称プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string EnterpriseGanreName
//        {
//            get { return _enterpriseGanreName; }
//            set { _enterpriseGanreName = value; }
//        }

//        /// public propaty name  :  BLGoodsCode
//        /// <summary>BL商品コードプロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   BL商品コードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 BLGoodsCode
//        {
//            get { return _bLGoodsCode; }
//            set { _bLGoodsCode = value; }
//        }

//        /// public propaty name  :  BLGoodsFullName
//        /// <summary>BL商品コード名称（全角）プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   BL商品コード名称（全角）プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string BLGoodsFullName
//        {
//            get { return _bLGoodsFullName; }
//            set { _bLGoodsFullName = value; }
//        }

//        /// public propaty name  :  WarehouseCode
//        /// <summary>倉庫コードプロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   倉庫コードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string WarehouseCode
//        {
//            get { return _warehouseCode; }
//            set { _warehouseCode = value; }
//        }

//        /// public propaty name  :  WarehouseName
//        /// <summary>倉庫名称プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   倉庫名称プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string WarehouseName
//        {
//            get { return _warehouseName; }
//            set { _warehouseName = value; }
//        }

//        /// public propaty name  :  CustomerCode
//        /// <summary>得意先コードプロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   得意先コードプロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 CustomerCode
//        {
//            get { return _customerCode; }
//            set { _customerCode = value; }
//        }

//        /// public propaty name  :  CustomerName
//        /// <summary>得意先名称プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   得意先名称プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string CustomerName
//        {
//            get { return _customerName; }
//            set { _customerName = value; }
//        }

//        /// public propaty name  :  ZeroStckDsp
//        /// <summary>ゼロ在庫表示区分プロパティ</summary>
//        /// <value>0:する,1:しない</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   ゼロ在庫表示区分プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32 ZeroStckDsp
//        {
//            get { return _zeroStckDsp; }
//            set { _zeroStckDsp = value; }
//        }

//        /// public propaty name  :  GoodsNos
//        /// <summary>商品番号(複数)プロパティ</summary>
//        /// <value>(配列)複数商品番号指定時に使用</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   商品番号(複数)プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string[] GoodsNos
//        {
//            get { return _goodsNos; }
//            set { _goodsNos = value; }
//        }

//        /// public propaty name  :  GoodsMakerCds
//        /// <summary>メーカーコード(複数)プロパティ</summary>
//        /// <value>(配列)複数メーカーコード指定時に使用</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   メーカーコード(複数)プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public Int32[] GoodsMakerCds
//        {
//            get { return _goodsMakerCds; }
//            set { _goodsMakerCds = value; }
//        }

//        /// public propaty name  :  WarehouseCodes
//        /// <summary>倉庫コード(複数)プロパティ</summary>
//        /// <value>(配列)複数倉庫コード指定時に使用</value>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   倉庫コード(複数)プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string[] WarehouseCodes
//        {
//            get { return _warehouseCodes; }
//            set { _warehouseCodes = value; }
//        }

//        /// public propaty name  :  EnterpriseName
//        /// <summary>企業名称プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   企業名称プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string EnterpriseName
//        {
//            get { return _enterpriseName; }
//            set { _enterpriseName = value; }
//        }

//        /// public propaty name  :  BLGoodsName
//        /// <summary>BL商品コード名称プロパティ</summary>
//        /// ----------------------------------------------------------------------
//        /// <remarks>
//        /// <br>note             :   BL商品コード名称プロパティ</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public string BLGoodsName
//        {
//            get { return _bLGoodsName; }
//            set { _bLGoodsName = value; }
//        }


//        /// <summary>
//        /// 在庫検索抽出条件ワークコンストラクタ
//        /// </summary>
//        /// <returns>StockSearchParaクラスのインスタンス</returns>
//        /// <remarks>
//        /// <br>Note　　　　　　 :   StockSearchParaクラスの新しいインスタンスを生成します</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public StockSearchPara ()
//        {
//        }

//        /// <summary>
//        /// 在庫検索抽出条件ワークコンストラクタ
//        /// </summary>
//        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
//        /// <param name="sectionCode">拠点コード</param>
//        /// <param name="GoodsMakerCd">メーカーコード</param>
//        /// <param name="makerName">メーカー名称</param>
//        /// <param name="goodsNo">商品コード</param>
//        /// <param name="goodsNoSrchTyp">商品コード検索タイプ(0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索)</param>
//        /// <param name="goodsName">商品名称</param>
//        /// <param name="goodsNameKana">商品名称カナ</param>
//        /// <param name="largeGoodsGanreCode">商品区分グループコード(旧：商品大分類コード)</param>
//        /// <param name="largeGoodsGanreName">商品区分グループ名称(旧：商品大分類名称)</param>
//        /// <param name="mediumGoodsGanreCode">商品区分コード(旧：商品中分類コード)</param>
//        /// <param name="mediumGoodsGanreName">商品区分名称(旧：商品中分類名称)</param>
//        /// <param name="detailGoodsGanreCode">商品区分詳細コード</param>
//        /// <param name="detailGoodsGanreName">商品区分詳細名称</param>
//        /// <param name="enterpriseGanreCode">自社分類コード</param>
//        /// <param name="enterpriseGanreName">自社分類名称</param>
//        /// <param name="bLGoodsCode">BL商品コード</param>
//        /// <param name="bLGoodsFullName">BL商品コード名称（全角）</param>
//        /// <param name="warehouseCode">倉庫コード</param>
//        /// <param name="warehouseName">倉庫名称</param>
//        /// <param name="customerCode">得意先コード</param>
//        /// <param name="customerName">得意先名称</param>
//        /// <param name="zeroStckDsp">ゼロ在庫表示区分(0:する,1:しない)</param>
//        /// <param name="goodsNos">商品番号(複数)((配列)複数商品番号指定時に使用)</param>
//        /// <param name="GoodsMakerCds">メーカーコード(複数)((配列)複数メーカーコード指定時に使用)</param>
//        /// <param name="warehouseCodes">倉庫コード(複数)((配列)複数倉庫コード指定時に使用)</param>
//        /// <param name="enterpriseName">企業名称</param>
//        /// <param name="bLGoodsName">BL商品コード名称</param>
//        /// <returns>StockSearchParaクラスのインスタンス</returns>
//        /// <remarks>
//        /// <br>Note　　　　　　 :   StockSearchParaクラスの新しいインスタンスを生成します</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public StockSearchPara ( string enterpriseCode, string sectionCode, Int32 goodsMakerCd, string makerName, string goodsNo, Int32 goodsNoSrchTyp, string goodsName, string goodsNameKana, string largeGoodsGanreCode, string largeGoodsGanreName, string mediumGoodsGanreCode, string mediumGoodsGanreName, string detailGoodsGanreCode, string detailGoodsGanreName, Int32 enterpriseGanreCode, string enterpriseGanreName, Int32 bLGoodsCode, string bLGoodsFullName, string warehouseCode, string warehouseName, Int32 customerCode, string customerName, Int32 zeroStckDsp, string[] goodsNos, Int32[] goodsMakerCds, string[] warehouseCodes, string enterpriseName, string bLGoodsName )
//        {
//            this._enterpriseCode = enterpriseCode;
//            this._sectionCode = sectionCode;
//            this._goodsMakerCd = goodsMakerCd;
//            this._makerName = makerName;
//            this._goodsNo = goodsNo;
//            this._goodsNoSrchTyp = goodsNoSrchTyp;
//            this._goodsName = goodsName;
//            this._goodsNameKana = goodsNameKana;
//            this._largeGoodsGanreCode = largeGoodsGanreCode;
//            this._largeGoodsGanreName = largeGoodsGanreName;
//            this._mediumGoodsGanreCode = mediumGoodsGanreCode;
//            this._mediumGoodsGanreName = mediumGoodsGanreName;
//            this._detailGoodsGanreCode = detailGoodsGanreCode;
//            this._detailGoodsGanreName = detailGoodsGanreName;
//            this._enterpriseGanreCode = enterpriseGanreCode;
//            this._enterpriseGanreName = enterpriseGanreName;
//            this._bLGoodsCode = bLGoodsCode;
//            this._bLGoodsFullName = bLGoodsFullName;
//            this._warehouseCode = warehouseCode;
//            this._warehouseName = warehouseName;
//            this._customerCode = customerCode;
//            this._customerName = customerName;
//            this._zeroStckDsp = zeroStckDsp;
//            this._goodsNos = goodsNos;
//            this._goodsMakerCds = goodsMakerCds;
//            this._warehouseCodes = warehouseCodes;
//            this._enterpriseName = enterpriseName;
//            this._bLGoodsName = bLGoodsName;

//        }

//        /// <summary>
//        /// 在庫検索抽出条件ワーク複製処理
//        /// </summary>
//        /// <returns>StockSearchParaクラスのインスタンス</returns>
//        /// <remarks>
//        /// <br>Note　　　　　　 :   自身の内容と等しいStockSearchParaクラスのインスタンスを返します</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public StockSearchPara Clone ()
//        {
//            return new StockSearchPara(this._enterpriseCode, this._sectionCode, this._goodsMakerCd, this._makerName, this._goodsNo, this._goodsNoSrchTyp, this._goodsName, this._goodsNameKana, this._largeGoodsGanreCode, this._largeGoodsGanreName, this._mediumGoodsGanreCode, this._mediumGoodsGanreName, this._detailGoodsGanreCode, this._detailGoodsGanreName, this._enterpriseGanreCode, this._enterpriseGanreName, this._bLGoodsCode, this._bLGoodsFullName, this._warehouseCode, this._warehouseName, this._customerCode, this._customerName, this._zeroStckDsp, this._goodsNos, this._goodsMakerCds, this._warehouseCodes, this._enterpriseName, this._bLGoodsName);
//        }

//        /// <summary>
//        /// 在庫検索抽出条件ワーク比較処理
//        /// </summary>
//        /// <param name="target">比較対象のStockSearchParaクラスのインスタンス</param>
//        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
//        /// <remarks>
//        /// <br>Note　　　　　　 :   StockSearchParaクラスの内容が一致するか比較します</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public bool Equals ( StockSearchPara target )
//        {
//            bool equal = 
//                (this.EnterpriseCode == target.EnterpriseCode)
//                 && (this.SectionCode == target.SectionCode)
//                 && (this.GoodsMakerCd == target.GoodsMakerCd)
//                 && (this.MakerName == target.MakerName)
//                 && (this.GoodsNo == target.GoodsNo)
//                 && (this.GoodsNoSrchTyp == target.GoodsNoSrchTyp)
//                 && (this.GoodsName == target.GoodsName)
//                 && (this.GoodsNameKana == target.GoodsNameKana)
//                 && (this.LargeGoodsGanreCode == target.LargeGoodsGanreCode)
//                 && (this.LargeGoodsGanreName == target.LargeGoodsGanreName)
//                 && (this.MediumGoodsGanreCode == target.MediumGoodsGanreCode)
//                 && (this.MediumGoodsGanreName == target.MediumGoodsGanreName)
//                 && (this.DetailGoodsGanreCode == target.DetailGoodsGanreCode)
//                 && (this.DetailGoodsGanreName == target.DetailGoodsGanreName)
//                 && (this.EnterpriseGanreCode == target.EnterpriseGanreCode)
//                 && (this.EnterpriseGanreName == target.EnterpriseGanreName)
//                 && (this.BLGoodsCode == target.BLGoodsCode)
//                 && (this.BLGoodsFullName == target.BLGoodsFullName)
//                 && (this.WarehouseCode == target.WarehouseCode)
//                 && (this.WarehouseName == target.WarehouseName)
//                 && (this.CustomerCode == target.CustomerCode)
//                 && (this.CustomerName == target.CustomerName)
//                 && (this.ZeroStckDsp == target.ZeroStckDsp)
//                 && (this.GoodsNos == target.GoodsNos)
//                 && (this.GoodsMakerCds == target.GoodsMakerCds)
//                 && (this.WarehouseCodes == target.WarehouseCodes)
//                 && (this.EnterpriseName == target.EnterpriseName)
//                 && (this.BLGoodsName == target.BLGoodsName);
//            if (!equal) return false;

//            bool isExist;

//            // 商品コード（複数指定）
//            if ( this.GoodsNos.Length != target.GoodsNos.Length ) {
//                return false;
//            }

//            foreach ( string wk1 in target.GoodsNos ) {
//                isExist = false;
//                foreach ( string wk2 in this.GoodsNos ) {
//                    if ( wk1.Equals(wk2) ) {
//                        isExist = true;
//                        break;
//                    }
//                }
//                if ( !isExist ) return false;
//            }
//            // メーカーコード（複数指定）
//            if ( this.GoodsMakerCds.Length != target.GoodsMakerCds.Length ) {
//                return false;
//            }

//            foreach ( int wk1 in target.GoodsMakerCds ) {
//                isExist = false;
//                foreach ( int wk2 in this.GoodsMakerCds ) {
//                    if ( wk1.Equals(wk2) ) {
//                        isExist = true;
//                        break;
//                    }
//                }
//                if ( !isExist ) return false;
//            }

//            // 倉庫コード（複数指定）
//            if ( this.WarehouseCodes.Length != target.WarehouseCodes.Length ) {
//                return false;
//            }

//            foreach ( string wk1 in target.WarehouseCodes ) {
//                isExist = false;
//                foreach ( string wk2 in this.WarehouseCodes ) {
//                    if ( wk1.Equals(wk2) ) {
//                        isExist = true;
//                        break;
//                    }
//                }
//                if ( !isExist ) return false;
//            }

//            return true;

//        }

//        /// <summary>
//        /// 在庫検索抽出条件ワーク比較処理
//        /// </summary>
//        /// <param name="stockSearchPara1">
//        ///                    比較するStockSearchParaクラスのインスタンス
//        /// </param>
//        /// <param name="stockSearchPara2">比較するStockSearchParaクラスのインスタンス</param>
//        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
//        /// <remarks>
//        /// <br>Note　　　　　　 :   StockSearchParaクラスの内容が一致するか比較します</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public static bool Equals ( StockSearchPara stockSearchPara1, StockSearchPara stockSearchPara2 )
//        {
//            bool equal = ( ( stockSearchPara1.EnterpriseCode == stockSearchPara2.EnterpriseCode )
//                 && ( stockSearchPara1.SectionCode == stockSearchPara2.SectionCode )
//                 && ( stockSearchPara1.GoodsMakerCd == stockSearchPara2.GoodsMakerCd )
//                 && ( stockSearchPara1.MakerName == stockSearchPara2.MakerName )
//                 && ( stockSearchPara1.GoodsNo == stockSearchPara2.GoodsNo )
//                 && ( stockSearchPara1.GoodsNoSrchTyp == stockSearchPara2.GoodsNoSrchTyp )
//                 && ( stockSearchPara1.GoodsName == stockSearchPara2.GoodsName )
//                 && ( stockSearchPara1.GoodsNameKana == stockSearchPara2.GoodsNameKana )
//                 && ( stockSearchPara1.LargeGoodsGanreCode == stockSearchPara2.LargeGoodsGanreCode )
//                 && ( stockSearchPara1.LargeGoodsGanreName == stockSearchPara2.LargeGoodsGanreName )
//                 && ( stockSearchPara1.MediumGoodsGanreCode == stockSearchPara2.MediumGoodsGanreCode )
//                 && ( stockSearchPara1.MediumGoodsGanreName == stockSearchPara2.MediumGoodsGanreName )
//                 && ( stockSearchPara1.DetailGoodsGanreCode == stockSearchPara2.DetailGoodsGanreCode )
//                 && ( stockSearchPara1.DetailGoodsGanreName == stockSearchPara2.DetailGoodsGanreName )
//                 && ( stockSearchPara1.EnterpriseGanreCode == stockSearchPara2.EnterpriseGanreCode )
//                 && ( stockSearchPara1.EnterpriseGanreName == stockSearchPara2.EnterpriseGanreName )
//                 && ( stockSearchPara1.BLGoodsCode == stockSearchPara2.BLGoodsCode )
//                 && ( stockSearchPara1.BLGoodsFullName == stockSearchPara2.BLGoodsFullName )
//                 && ( stockSearchPara1.WarehouseCode == stockSearchPara2.WarehouseCode )
//                 && ( stockSearchPara1.WarehouseName == stockSearchPara2.WarehouseName )
//                 && ( stockSearchPara1.CustomerCode == stockSearchPara2.CustomerCode )
//                 && ( stockSearchPara1.CustomerName == stockSearchPara2.CustomerName )
//                 && ( stockSearchPara1.ZeroStckDsp == stockSearchPara2.ZeroStckDsp )
//                 && ( stockSearchPara1.GoodsNos == stockSearchPara2.GoodsNos )
//                 && ( stockSearchPara1.GoodsMakerCds == stockSearchPara2.GoodsMakerCds )
//                 && ( stockSearchPara1.WarehouseCodes == stockSearchPara2.WarehouseCodes )
//                 && ( stockSearchPara1.EnterpriseName == stockSearchPara2.EnterpriseName )
//                 && ( stockSearchPara1.BLGoodsName == stockSearchPara2.BLGoodsName ) );
//            if (!equal) return false;
//            bool isExist;

//            // 商品コード（複数指定）
//            if ( stockSearchPara1.GoodsNos.Length != stockSearchPara2.GoodsNos.Length ) {
//                return false;
//            }

//            foreach ( string wk1 in stockSearchPara2.GoodsNos ) {
//                isExist = false;
//                foreach ( string wk2 in stockSearchPara1.GoodsNos ) {
//                    if ( wk1.Equals(wk2) ) {
//                        isExist = true;
//                        break;
//                    }
//                }
//                if ( !isExist ) return false;
//            }
//            // メーカーコード（複数指定）
//            if ( stockSearchPara1.GoodsMakerCds.Length != stockSearchPara2.GoodsMakerCds.Length ) {
//                return false;
//            }

//            foreach ( int wk1 in stockSearchPara2.GoodsMakerCds ) {
//                isExist = false;
//                foreach ( int wk2 in stockSearchPara1.GoodsMakerCds ) {
//                    if ( wk1.Equals(wk2) ) {
//                        isExist = true;
//                        break;
//                    }
//                }
//                if ( !isExist ) return false;
//            }

//            // 倉庫コード（複数指定）
//            if ( stockSearchPara1.WarehouseCodes.Length != stockSearchPara2.WarehouseCodes.Length ) {
//                return false;
//            }

//            foreach ( string wk1 in stockSearchPara2.WarehouseCodes ) {
//                isExist = false;
//                foreach ( string wk2 in stockSearchPara1.WarehouseCodes ) {
//                    if ( wk1.Equals(wk2) ) {
//                        isExist = true;
//                        break;
//                    }
//                }
//                if ( !isExist ) return false;
//            }

//            return true;
//        }
//        /// <summary>
//        /// 在庫検索抽出条件ワーク比較処理
//        /// </summary>
//        /// <param name="target">比較対象のStockSearchParaクラスのインスタンス</param>
//        /// <returns>一致しない項目のリスト</returns>
//        /// <remarks>
//        /// <br>Note　　　　　　 :   StockSearchParaクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public ArrayList Compare ( StockSearchPara target )
//        {
//            ArrayList resList = new ArrayList();
//            if ( this.EnterpriseCode != target.EnterpriseCode ) resList.Add("EnterpriseCode");
//            if ( this.SectionCode != target.SectionCode ) resList.Add("SectionCode");
//            if ( this.GoodsMakerCd != target.GoodsMakerCd ) resList.Add("GoodsMakerCd");
//            if ( this.MakerName != target.MakerName ) resList.Add("MakerName");
//            if ( this.GoodsNo != target.GoodsNo ) resList.Add("GoodsNo");
//            if ( this.GoodsNoSrchTyp != target.GoodsNoSrchTyp ) resList.Add("GoodsNoSrchTyp");
//            if ( this.GoodsName != target.GoodsName ) resList.Add("GoodsName");
//            if ( this.GoodsNameKana != target.GoodsNameKana ) resList.Add("GoodsNameKana");
//            if ( this.LargeGoodsGanreCode != target.LargeGoodsGanreCode ) resList.Add("LargeGoodsGanreCode");
//            if ( this.LargeGoodsGanreName != target.LargeGoodsGanreName ) resList.Add("LargeGoodsGanreName");
//            if ( this.MediumGoodsGanreCode != target.MediumGoodsGanreCode ) resList.Add("MediumGoodsGanreCode");
//            if ( this.MediumGoodsGanreName != target.MediumGoodsGanreName ) resList.Add("MediumGoodsGanreName");
//            if ( this.DetailGoodsGanreCode != target.DetailGoodsGanreCode ) resList.Add("DetailGoodsGanreCode");
//            if ( this.DetailGoodsGanreName != target.DetailGoodsGanreName ) resList.Add("DetailGoodsGanreName");
//            if ( this.EnterpriseGanreCode != target.EnterpriseGanreCode ) resList.Add("EnterpriseGanreCode");
//            if ( this.EnterpriseGanreName != target.EnterpriseGanreName ) resList.Add("EnterpriseGanreName");
//            if ( this.BLGoodsCode != target.BLGoodsCode ) resList.Add("BLGoodsCode");
//            if ( this.BLGoodsFullName != target.BLGoodsFullName ) resList.Add("BLGoodsFullName");
//            if ( this.WarehouseCode != target.WarehouseCode ) resList.Add("WarehouseCode");
//            if ( this.WarehouseName != target.WarehouseName ) resList.Add("WarehouseName");
//            if ( this.CustomerCode != target.CustomerCode ) resList.Add("CustomerCode");
//            if ( this.CustomerName != target.CustomerName ) resList.Add("CustomerName");
//            if ( this.ZeroStckDsp != target.ZeroStckDsp ) resList.Add("ZeroStckDsp");
//            if ( this.GoodsNos != target.GoodsNos ) resList.Add("GoodsNos");
//            if ( this.GoodsMakerCds != target.GoodsMakerCds ) resList.Add("GoodsMakerCds");
//            if ( this.WarehouseCodes != target.WarehouseCodes ) resList.Add("WarehouseCodes");
//            if ( this.EnterpriseName != target.EnterpriseName ) resList.Add("EnterpriseName");
//            if ( this.BLGoodsName != target.BLGoodsName ) resList.Add("BLGoodsName");

//            // 商品コード(複数指定)
//            if ( this.GoodsNos.Length != target.GoodsNos.Length ) {
//                resList.Add("GoodsNos");
//            }
//            else {
//                bool isExsist = false;

//                foreach ( string wk1 in target.GoodsNos ) {
//                    isExsist = false;
//                    foreach ( string wk2 in this.GoodsNos ) {
//                        if ( wk1.Equals(wk2) ) {
//                            isExsist = true;
//                            break;
//                        }
//                    }
//                    if ( !isExsist ) {
//                        resList.Add("GoodsNos");
//                        break;
//                    }
//                }
//            }

//            // メーカーコード(複数指定)
//            if ( this.GoodsMakerCds.Length != target.GoodsMakerCds.Length ) {
//                resList.Add("GoodsMakerCds");
//            }
//            else {
//                bool isExsist = false;

//                foreach ( int wk1 in target.GoodsMakerCds ) {
//                    isExsist = false;
//                    foreach ( int wk2 in this.GoodsMakerCds ) {
//                        if ( wk1.Equals(wk2) ) {
//                            isExsist = true;
//                            break;
//                        }
//                    }
//                    if ( !isExsist ) {
//                        resList.Add("GoodsMakerCds");
//                        break;
//                    }
//                }
//            }

//            // 倉庫コード(複数指定)
//            if ( this.WarehouseCodes.Length != target.WarehouseCodes.Length ) {
//                resList.Add("WarehouseCodes");
//            }
//            else {
//                bool isExsist = false;

//                foreach ( string wk1 in target.WarehouseCodes ) {
//                    isExsist = false;
//                    foreach ( string wk2 in this.WarehouseCodes ) {
//                        if ( wk1.Equals(wk2) ) {
//                            isExsist = true;
//                            break;
//                        }
//                    }
//                    if ( !isExsist ) {
//                        resList.Add("WarehouseCodes");
//                        break;
//                    }
//                }
//            }


//            return resList;
//        }

//        /// <summary>
//        /// 在庫検索抽出条件ワーク比較処理
//        /// </summary>
//        /// <param name="stockSearchPara1">比較するStockSearchParaクラスのインスタンス</param>
//        /// <param name="stockSearchPara2">比較するStockSearchParaクラスのインスタンス</param>
//        /// <returns>一致しない項目のリスト</returns>
//        /// <remarks>
//        /// <br>Note　　　　　　 :   StockSearchParaクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
//        /// <br>Programer        :   自動生成</br>
//        /// </remarks>
//        public static ArrayList Compare ( StockSearchPara stockSearchPara1, StockSearchPara stockSearchPara2 )
//        {
//            ArrayList resList = new ArrayList();
//            if ( stockSearchPara1.EnterpriseCode != stockSearchPara2.EnterpriseCode ) resList.Add("EnterpriseCode");
//            if ( stockSearchPara1.SectionCode != stockSearchPara2.SectionCode ) resList.Add("SectionCode");
//            if ( stockSearchPara1.GoodsMakerCd != stockSearchPara2.GoodsMakerCd ) resList.Add("GoodsMakerCd");
//            if ( stockSearchPara1.MakerName != stockSearchPara2.MakerName ) resList.Add("MakerName");
//            if ( stockSearchPara1.GoodsNo != stockSearchPara2.GoodsNo ) resList.Add("GoodsNo");
//            if ( stockSearchPara1.GoodsNoSrchTyp != stockSearchPara2.GoodsNoSrchTyp ) resList.Add("GoodsNoSrchTyp");
//            if ( stockSearchPara1.GoodsName != stockSearchPara2.GoodsName ) resList.Add("GoodsName");
//            if ( stockSearchPara1.GoodsNameKana != stockSearchPara2.GoodsNameKana ) resList.Add("GoodsNameKana");
//            if ( stockSearchPara1.LargeGoodsGanreCode != stockSearchPara2.LargeGoodsGanreCode ) resList.Add("LargeGoodsGanreCode");
//            if ( stockSearchPara1.LargeGoodsGanreName != stockSearchPara2.LargeGoodsGanreName ) resList.Add("LargeGoodsGanreName");
//            if ( stockSearchPara1.MediumGoodsGanreCode != stockSearchPara2.MediumGoodsGanreCode ) resList.Add("MediumGoodsGanreCode");
//            if ( stockSearchPara1.MediumGoodsGanreName != stockSearchPara2.MediumGoodsGanreName ) resList.Add("MediumGoodsGanreName");
//            if ( stockSearchPara1.DetailGoodsGanreCode != stockSearchPara2.DetailGoodsGanreCode ) resList.Add("DetailGoodsGanreCode");
//            if ( stockSearchPara1.DetailGoodsGanreName != stockSearchPara2.DetailGoodsGanreName ) resList.Add("DetailGoodsGanreName");
//            if ( stockSearchPara1.EnterpriseGanreCode != stockSearchPara2.EnterpriseGanreCode ) resList.Add("EnterpriseGanreCode");
//            if ( stockSearchPara1.EnterpriseGanreName != stockSearchPara2.EnterpriseGanreName ) resList.Add("EnterpriseGanreName");
//            if ( stockSearchPara1.BLGoodsCode != stockSearchPara2.BLGoodsCode ) resList.Add("BLGoodsCode");
//            if ( stockSearchPara1.BLGoodsFullName != stockSearchPara2.BLGoodsFullName ) resList.Add("BLGoodsFullName");
//            if ( stockSearchPara1.WarehouseCode != stockSearchPara2.WarehouseCode ) resList.Add("WarehouseCode");
//            if ( stockSearchPara1.WarehouseName != stockSearchPara2.WarehouseName ) resList.Add("WarehouseName");
//            if ( stockSearchPara1.CustomerCode != stockSearchPara2.CustomerCode ) resList.Add("CustomerCode");
//            if ( stockSearchPara1.CustomerName != stockSearchPara2.CustomerName ) resList.Add("CustomerName");
//            if ( stockSearchPara1.ZeroStckDsp != stockSearchPara2.ZeroStckDsp ) resList.Add("ZeroStckDsp");
//            if ( stockSearchPara1.GoodsNos != stockSearchPara2.GoodsNos ) resList.Add("GoodsNos");
//            if ( stockSearchPara1.GoodsMakerCds != stockSearchPara2.GoodsMakerCds ) resList.Add("GoodsMakerCds");
//            if ( stockSearchPara1.WarehouseCodes != stockSearchPara2.WarehouseCodes ) resList.Add("WarehouseCodes");
//            if ( stockSearchPara1.EnterpriseName != stockSearchPara2.EnterpriseName ) resList.Add("EnterpriseName");
//            if ( stockSearchPara1.BLGoodsName != stockSearchPara2.BLGoodsName ) resList.Add("BLGoodsName");

//            // 商品コード(複数指定)
//            if ( stockSearchPara1.GoodsNos.Length != stockSearchPara2.GoodsNos.Length ) {
//                resList.Add("GoodsNos");
//            }
//            else {
//                bool isExsist = false;

//                foreach ( string wk1 in stockSearchPara2.GoodsNos ) {
//                    isExsist = false;
//                    foreach ( string wk2 in stockSearchPara1.GoodsNos ) {
//                        if ( wk1.Equals(wk2) ) {
//                            isExsist = true;
//                            break;
//                        }
//                    }
//                    if ( !isExsist ) {
//                        resList.Add("GoodsNos");
//                        break;
//                    }
//                }
//            }

//            // メーカーコード(複数指定)
//            if ( stockSearchPara1.GoodsMakerCds.Length != stockSearchPara2.GoodsMakerCds.Length ) {
//                resList.Add("GoodsMakerCds");
//            }
//            else {
//                bool isExsist = false;

//                foreach ( int wk1 in stockSearchPara2.GoodsMakerCds ) {
//                    isExsist = false;
//                    foreach ( int wk2 in stockSearchPara1.GoodsMakerCds ) {
//                        if ( wk1.Equals(wk2) ) {
//                            isExsist = true;
//                            break;
//                        }
//                    }
//                    if ( !isExsist ) {
//                        resList.Add("GoodsMakerCds");
//                        break;
//                    }
//                }
//            }

//            // 倉庫コード(複数指定)
//            if ( stockSearchPara1.WarehouseCodes.Length != stockSearchPara2.WarehouseCodes.Length ) {
//                resList.Add("WarehouseCodes");
//            }
//            else {
//                bool isExsist = false;

//                foreach ( string wk1 in stockSearchPara2.WarehouseCodes ) {
//                    isExsist = false;
//                    foreach ( string wk2 in stockSearchPara1.WarehouseCodes ) {
//                        if ( wk1.Equals(wk2) ) {
//                            isExsist = true;
//                            break;
//                        }
//                    }
//                    if ( !isExsist ) {
//                        resList.Add("WarehouseCodes");
//                        break;
//                    }
//                }
//            }
//            return resList;
//        }
//    }
//}

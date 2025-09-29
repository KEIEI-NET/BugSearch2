using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   OrderListCndtnWork
	/// <summary>
	///                      発注残照会抽出条件クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   発注残照会抽出条件クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/10/27  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class OrderListCndtnWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード（複数指定）</summary>
		/// <remarks>（配列）（仕入明細）</remarks>
		private string[] _sectionCodes;

		/// <summary>開始発注データ作成日</summary>
		/// <remarks>YYYYMMDD　（更新年月日）(仕入明細)</remarks>
		private DateTime _st_OrderDataCreateDate;

		/// <summary>終了発注データ作成日</summary>
		/// <remarks>YYYYMMDD　（更新年月日）(仕入明細)</remarks>
        private DateTime _ed_OrderDataCreateDate;

		/// <summary>開始入力日</summary>
		/// <remarks>YYYYMMDD　（更新年月日）(仕入)</remarks>
        private DateTime _st_InputDay;

		/// <summary>終了入力日</summary>
		/// <remarks>YYYYMMDD　（更新年月日）(仕入)</remarks>
        private DateTime _ed_InputDay;

		/// <summary>仕入担当者コード</summary>
		/// <remarks>（仕入明細）</remarks>
		private string _stockAgentCode = "";

		/// <summary>仕入入力者コード</summary>
		/// <remarks>（仕入明細）</remarks>
		private string _stockInputCode = "";

		/// <summary>仕入先コード</summary>
		/// <remarks>（仕入明細）</remarks>
		private Int32 _supplierCd;

		/// <summary>倉庫コード</summary>
		/// <remarks>（仕入明細）</remarks>
		private string _warehouseCode = "";

		/// <summary>商品メーカーコード</summary>
		/// <remarks>（仕入明細）</remarks>
		private Int32 _goodsMakerCd;

		/// <summary>発注番号</summary>
		private string _orderNumber = "";

		/// <summary>計上残区分</summary>
		/// <remarks>0:全て,1:残あり,2:計上済み</remarks>
		private Int32 _addUpRemDiv;

		/// <summary>品番</summary>
		/// <remarks>（仕入明細）</remarks>
		private string _goodsNo = "";

		/// <summary>品番検索タイプ</summary>
		/// <remarks>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</remarks>
		private Int32 _goodsNoSrchTyp;

		/// <summary>品名</summary>
		private string _goodsName = "";

		/// <summary>品名検索タイプ</summary>
		/// <remarks>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索</remarks>
		private Int32 _goodsNameSrchTyp;

        /// <summary>抽出対象区分</summary>
        /// <remarks>0:全て,1:非オンライン分 在庫仕入入力から呼ばれた場合は1を指定</remarks>
        private Int32 _searchDiv;

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
		/// <summary>拠点コード（複数指定）プロパティ</summary>
		/// <value>（配列）（仕入明細）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コード（複数指定）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] SectionCodes
		{
			get{return _sectionCodes;}
			set{_sectionCodes = value;}
		}

		/// public propaty name  :  St_OrderDataCreateDate
		/// <summary>開始発注データ作成日プロパティ</summary>
		/// <value>YYYYMMDD　（更新年月日）(仕入明細)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始発注データ作成日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime St_OrderDataCreateDate
		{
			get{return _st_OrderDataCreateDate;}
			set{_st_OrderDataCreateDate = value;}
		}

		/// public propaty name  :  Ed_OrderDataCreateDate
		/// <summary>終了発注データ作成日プロパティ</summary>
		/// <value>YYYYMMDD　（更新年月日）(仕入明細)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了発注データ作成日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime Ed_OrderDataCreateDate
		{
			get{return _ed_OrderDataCreateDate;}
			set{_ed_OrderDataCreateDate = value;}
		}

		/// public propaty name  :  St_InputDay
		/// <summary>開始入力日プロパティ</summary>
		/// <value>YYYYMMDD　（更新年月日）(仕入)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始入力日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime St_InputDay
		{
			get{return _st_InputDay;}
			set{_st_InputDay = value;}
		}

		/// public propaty name  :  Ed_InputDay
		/// <summary>終了入力日プロパティ</summary>
		/// <value>YYYYMMDD　（更新年月日）(仕入)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了入力日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public DateTime Ed_InputDay
		{
			get{return _ed_InputDay;}
			set{_ed_InputDay = value;}
		}

		/// public propaty name  :  StockAgentCode
		/// <summary>仕入担当者コードプロパティ</summary>
		/// <value>（仕入明細）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入担当者コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockAgentCode
		{
			get{return _stockAgentCode;}
			set{_stockAgentCode = value;}
		}

		/// public propaty name  :  StockInputCode
		/// <summary>仕入入力者コードプロパティ</summary>
		/// <value>（仕入明細）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入入力者コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StockInputCode
		{
			get{return _stockInputCode;}
			set{_stockInputCode = value;}
		}

		/// public propaty name  :  SupplierCd
		/// <summary>仕入先コードプロパティ</summary>
		/// <value>（仕入明細）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierCd
		{
			get{return _supplierCd;}
			set{_supplierCd = value;}
		}

		/// public propaty name  :  WarehouseCode
		/// <summary>倉庫コードプロパティ</summary>
		/// <value>（仕入明細）</value>
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

		/// public propaty name  :  GoodsMakerCd
		/// <summary>商品メーカーコードプロパティ</summary>
		/// <value>（仕入明細）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsMakerCd
		{
			get{return _goodsMakerCd;}
			set{_goodsMakerCd = value;}
		}

		/// public propaty name  :  OrderNumber
		/// <summary>発注番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OrderNumber
		{
			get{return _orderNumber;}
			set{_orderNumber = value;}
		}

		/// public propaty name  :  AddUpRemDiv
		/// <summary>計上残区分プロパティ</summary>
		/// <value>0:全て,1:残あり,2:計上済み</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上残区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AddUpRemDiv
		{
			get{return _addUpRemDiv;}
			set{_addUpRemDiv = value;}
		}

		/// public propaty name  :  GoodsNo
		/// <summary>品番プロパティ</summary>
		/// <value>（仕入明細）</value>
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

        /// public propaty name  :  SearchDiv
        /// <summary>抽出対象区分プロパティ</summary>
        /// <value>0:全て,1:非オンライン分 在庫仕入入力から呼ばれた場合は1を指定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品名検索タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchDiv
        {
            get { return _searchDiv; }
            set { _searchDiv = value; }
        }

		/// <summary>
		/// 発注残照会抽出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>OrderListCndtnWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   OrderListCndtnWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public OrderListCndtnWork()
		{
		}

	}
}





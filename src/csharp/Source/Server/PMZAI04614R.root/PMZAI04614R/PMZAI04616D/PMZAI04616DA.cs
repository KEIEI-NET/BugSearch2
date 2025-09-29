using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockMovePrtWork
    /// <summary>
    ///                      在庫移動電子元帳検索条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫移動電子元帳検索条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockMovePrtWork
    {
        /// <summary>検索上限</summary>
		/// <remarks>検索上限数+1をセット</remarks>
		private Int64 _searchCnt;
        
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

        /// <summary>出力区分</summary>
        private Int32 _outputDiv;

        /// <summary>入力拠点コード</summary>
        private string _inputSectionCode;

        /// <summary>拠点コード</summary>
        private string _sectionCode;

        /// <summary>倉庫コード</summary>
        private string _warehouseCode;

        /// <summary>開始出荷日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _st_Date;

        /// <summary>終了出荷日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ed_Date;

        /// <summary>伝票番号</summary>
        /// <remarks>在庫移動確定区分</remarks>
        private string _salesSlipNum = "";

        /// <summary>開始入力日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _st_AddUpADate;

        /// <summary>終了入力日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ed_AddUpADate;

        /// <summary>担当者</summary>
        /// <remarks>販売従業員コード</remarks>
        private string _salesEmployeeCd = "";

        /// <summary>仕入先</summary>
        /// <remarks>仕入先コード</remarks>
        private Int32 _supplierCd;

        /// <summary>メーカーコード</summary>
        /// <remarks>商品メーカーコード</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>ＢＬコード</summary>
        /// <remarks>BL商品コード</remarks>
        private Int32 _bLGoodsCode;

        /// <summary>品番</summary>
        /// <remarks>商品番号</remarks>
        private string _goodsNo = "";

        /// <summary>品名</summary>
        /// <remarks>商品名称</remarks>
        private string _goodsName = "";

        /// <summary>倉庫棚番[明細]</summary>
        private string _warehouseShelfNo = "";

        /// <summary>相手拠点</summary>
        /// <remarks>受付従業員コード</remarks>
        private string _afSectionCode = "";

        /// <summary>相手倉庫</summary>
        /// <remarks>売上入力者コード</remarks>
        private string _afEnterWarehCode = "";

        /// <summary>入荷区分</summary>
        private Int32 _arrivalGoodsFlag;

        /// <summary>備考１</summary>
        /// <remarks>伝票備考</remarks>
        private string _slipNote = "";

        /// <summary>削除指定区分</summary>
        /// <remarks>車台番号（検索用）</remarks>
        private Int32 _deleteFlag;

        /// <summary>在庫移動確定区分</summary>
        private Int32 _stockMoveFixCode;

        /// <remarks>伝票区分</remarks>
        private Int32 _salesSlipDiv;


		/// public propaty name  :  SearchCnt
		/// <summary>検索上限プロパティ</summary>
		/// <value>検索上限数+1をセット</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   検索上限プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SearchCnt
		{
			get{return _searchCnt;}
			set{_searchCnt = value;}
		}

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

        /// public propaty name  :  InputSectionCode
        /// <summary>出力区分プロパティ</summary>
        /// <value>出力区分</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>  
        public Int32 OutputDiv
        {
            get { return _outputDiv; }
            set { _outputDiv = value; }
        }

        /// public propaty name  :  InputSectionCode
        /// <summary>入力拠点コードプロパティ</summary>
        /// <value>入力拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>  
        public string InputSectionCode
        {
            get { return _inputSectionCode; }
            set { _inputSectionCode = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>  
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }
 
        /// public propaty name  :  WarehouseCode
        /// <summary>倉庫コードプロパティ</summary>
        /// <value>倉庫コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

		/// public propaty name  :  CustomerCode
		/// <summary>得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustomerCode
		{
			get{return _outputDiv;}
			set{_outputDiv = value;}
		}

		/// public propaty name  :  ArrivalGoodsFlag
		/// <summary>請求先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ArrivalGoodsFlag
		{
			get{return _arrivalGoodsFlag;}
			set{_arrivalGoodsFlag = value;}
		}

		/// public propaty name  :  St_Date
		/// <summary>開始売上日付プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始売上日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime St_Date
		{
			get{return _st_Date;}
			set{_st_Date = value;}
		}

		/// public propaty name  :  Ed_Date
		/// <summary>終了売上日付プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了売上日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime Ed_Date
		{
			get{return _ed_Date;}
			set{_ed_Date = value;}
		}

		/// public propaty name  :  St_AddUpADate
		/// <summary>開始入力日付プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始入力日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime St_AddUpADate
		{
			get{return _st_AddUpADate;}
			set{_st_AddUpADate = value;}
		}

		/// public propaty name  :  Ed_AddUpADate
		/// <summary>終了入力日付プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了入力日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime Ed_AddUpADate
		{
			get{return _ed_AddUpADate;}
			set{_ed_AddUpADate = value;}
		}

		/// public propaty name  :  SalesSlipNum
		/// <summary>伝票番号プロパティ</summary>
		/// <value>在庫移動確定区分</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesSlipNum
		{
			get{return _salesSlipNum;}
			set{_salesSlipNum = value;}
		}

		/// public propaty name  :  SalesEmployeeCd
		/// <summary>担当者プロパティ</summary>
		/// <value>販売従業員コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   担当者プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesEmployeeCd
		{
			get{return _salesEmployeeCd;}
			set{_salesEmployeeCd = value;}
		}

		/// public propaty name  :  AfSectionCode
		/// <summary>相手拠点プロパティ</summary>
		/// <value>受付従業員コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   相手拠点プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AfSectionCode
		{
			get{return _afSectionCode;}
			set{_afSectionCode = value;}
		}

		/// public propaty name  :  AfEnterWarehCode
		/// <summary>相手倉庫プロパティ</summary>
		/// <value>売上入力者コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   相手倉庫プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AfEnterWarehCode
		{
			get{return _afEnterWarehCode;}
			set{_afEnterWarehCode = value;}
		}

		/// public propaty name  :  DeleteFlag
		/// <summary>削除指定区分プロパティ</summary>
        /// <value>削除指定区分（検索用）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   削除指定区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DeleteFlag
		{
			get{return _deleteFlag;}
			set{_deleteFlag = value;}
		}

       	/// public propaty name  :  SlipNote
		/// <summary>備考１プロパティ</summary>
		/// <value>伝票備考</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   備考１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SlipNote
		{
			get{return _slipNote;}
			set{_slipNote = value;}
		}

		/// public propaty name  :  BLGoodsCode
		/// <summary>ＢＬコードプロパティ</summary>
		/// <value>BL商品コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ＢＬコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BLGoodsCode
		{
			get{return _bLGoodsCode;}
			set{_bLGoodsCode = value;}
		}

		/// public propaty name  :  GoodsName
		/// <summary>品名プロパティ</summary>
		/// <value>商品名称</value>
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

		/// public propaty name  :  GoodsNo
		/// <summary>品番プロパティ</summary>
		/// <value>商品番号</value>
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

		/// public propaty name  :  GoodsMakerCd
		/// <summary>メーカーコードプロパティ</summary>
		/// <value>商品メーカーコード</value>
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

		/// public propaty name  :  SupplierCd
		/// <summary>仕入先プロパティ</summary>
		/// <value>仕入先コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierCd
		{
			get{return _supplierCd;}
			set{_supplierCd = value;}
		}

		/// public propaty name  :  WarehouseShelfNo
		/// <summary>倉庫棚番[明細]プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   倉庫棚番[明細]プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string WarehouseShelfNo
		{
			get{return _warehouseShelfNo;}
			set{_warehouseShelfNo = value;}
		}

        /// public propaty name  :  StockMoveFixCode
        /// <summary>在庫移動確定区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫移動確定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockMoveFixCode
        {
            get { return _stockMoveFixCode; }
            set { _stockMoveFixCode = value; }
        }

        /// public propaty name  :  SalesSlipDiv
        /// <summary>伝票区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesSlipDiv
        {
            get { return _salesSlipDiv; }
            set { _salesSlipDiv = value; }
        }

        /// <summary>
        /// 在庫移動電子元帳検索条件(残高・伝票・明細)ワークコンストラクタ
        /// </summary>
        /// <returns>StockMovePrtWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMovePrtWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockMovePrtWork()
        {
        }

    }

}
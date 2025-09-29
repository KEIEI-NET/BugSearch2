//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 在庫移動電子元帳
// プログラム概要   : 在庫移動電子元帳検索条件
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : yangmj
// 作 成 日  2011/04/06  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   StockMovePpr
	/// <summary>
	///                      在庫移動電子元帳検索条件
	/// </summary>
	/// <remarks>
	/// <br>note             :   在庫移動電子元帳検索条件ヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// </remarks>
	public class StockMovePpr
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
		/// 在庫移動電子元帳検索条件コンストラクタ
		/// </summary>
		/// <returns>StockMovePprクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockMovePprクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockMovePpr()
		{
           
		}

        /// <summary>
        /// 在庫移動電子元帳検索条件コンストラクタ
        /// </summary>
        /// <param name="searchCnt">検索上限(検索上限数+1をセット)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="outputDiv">出力区分</param>
        /// <param name="inputSectionCode">入力拠点</param>
        /// <param name="sectionCode">拠点</param>
        /// <param name="warehouseCode">倉庫</param>
        /// <param name="st_Date">開始入荷日付(YYYYMMDD)</param>
        /// <param name="ed_Date">終了入荷日付(YYYYMMDD)</param>
        /// <param name="salesSlipNum">伝票番号(在庫移動確定区分)</param>
        /// <param name="st_AddUpADate">開始入力日付(YYYYMMDD)</param>
        /// <param name="ed_AddUpADate">終了入力日付(YYYYMMDD)</param>
        /// <param name="salesEmployeeCd">担当者(販売従業員コード)</param>
        /// <param name="supplierCd">仕入先(仕入先コード)</param>
        /// <param name="goodsMakerCd">メーカーコード(商品メーカーコード)</param>
        /// <param name="bLGoodsCode">ＢＬコード(BL商品コード)</param>
        /// <param name="goodsNo">品番(商品番号)</param>
        /// <param name="goodsName">名(商品名称)</param>
        /// <param name="warehouseShelfNo">倉庫棚番[明細]</param>
        /// <param name="afSectionCode">相手拠点(受付従業員コード)</param>
        /// <param name="afEnterWarehCode">相手倉庫(売上入力者コード)</param>
        /// <param name="arrivalGoodsFlag">入荷区分</param>
        /// <param name="slipNote">備考１</param>
        /// <param name="deleteFlag">削除指定区分</param>
        /// <param name="stockMoveFixCode">在庫移動確定区分</param>
        /// <param name="salesSlipDiv">伝票区分</param>
        public StockMovePpr(Int64 searchCnt, string enterpriseCode, Int32 outputDiv, string inputSectionCode, string sectionCode, string warehouseCode, DateTime st_Date, DateTime ed_Date, string salesSlipNum, DateTime st_AddUpADate, DateTime ed_AddUpADate, string salesEmployeeCd, Int32 supplierCd, Int32 goodsMakerCd, Int32 bLGoodsCode, string goodsNo, string goodsName, string warehouseShelfNo, string afSectionCode, string afEnterWarehCode, Int32 arrivalGoodsFlag, string slipNote, Int32 deleteFlag, Int32 stockMoveFixCode, Int32 salesSlipDiv)
        {
            this._searchCnt = searchCnt;
            this._enterpriseCode = enterpriseCode;
            this._outputDiv = outputDiv;
            this._inputSectionCode = inputSectionCode;
            this._sectionCode = sectionCode;
            this._warehouseCode = warehouseCode;
            this._st_Date = st_Date;
            this._ed_Date = ed_Date;
            this._salesSlipNum = salesSlipNum;
            this._st_AddUpADate = st_AddUpADate;
            this._ed_AddUpADate = ed_AddUpADate;
            this._salesEmployeeCd = salesEmployeeCd;
            this._supplierCd = supplierCd;
            this._goodsMakerCd = goodsMakerCd;
            this._bLGoodsCode = bLGoodsCode;
            this._goodsNo = goodsNo;
            this._goodsName = goodsName;
            this._warehouseShelfNo = warehouseShelfNo;
            this._afSectionCode = afSectionCode;
            this._afEnterWarehCode = afEnterWarehCode;
            this._arrivalGoodsFlag = arrivalGoodsFlag;
            this._slipNote = slipNote;
            this._deleteFlag = deleteFlag;
            this._stockMoveFixCode = stockMoveFixCode;
            this._salesSlipDiv = salesSlipDiv;
		}

		/// <summary>
		/// 在庫移動電子元帳検索条件複製処理
		/// </summary>
		/// <returns>StockMovePprクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいStockMovePprクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public StockMovePpr Clone()
		{
            return new StockMovePpr(_searchCnt, _enterpriseCode, _outputDiv, _inputSectionCode, _sectionCode, _warehouseCode, _st_Date, _ed_Date, _salesSlipNum, _st_AddUpADate, _ed_AddUpADate, _salesEmployeeCd, _supplierCd, _goodsMakerCd, _bLGoodsCode, _goodsNo, _goodsName, _warehouseShelfNo, _afSectionCode, _afEnterWarehCode, _arrivalGoodsFlag, _slipNote, _deleteFlag, _stockMoveFixCode, _salesSlipDiv);
		}

		/// <summary>
		/// 在庫移動電子元帳検索条件比較処理
		/// </summary>
		/// <param name="target">比較対象のStockMovePprクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockMovePprクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(StockMovePpr target)
		{
            return ((this.SearchCnt == target.SearchCnt)
                && (this.EnterpriseCode == target.EnterpriseCode)
                && (this.OutputDiv == target.OutputDiv)
                && (this.InputSectionCode == target.InputSectionCode)
                && (this.SectionCode == target.SectionCode)
                && (this.WarehouseCode == target.WarehouseCode)
                && (this.St_Date == target.St_Date)
                && (this.Ed_Date == target.Ed_Date)
                && (this.SalesSlipNum == target.SalesSlipNum)
                && (this.St_AddUpADate == target.St_AddUpADate)
                && (this.Ed_AddUpADate == target.Ed_AddUpADate)
                && (this.SalesEmployeeCd == target.SalesEmployeeCd)
                && (this.SupplierCd == target.SupplierCd)
                && (this.GoodsMakerCd == target.GoodsMakerCd)
                && (this.BLGoodsCode == target.BLGoodsCode)
                && (this.GoodsNo == target.GoodsNo)
                && (this.GoodsName == target.GoodsName)
                && (this.WarehouseShelfNo == target.WarehouseShelfNo)
                && (this.AfSectionCode == target.AfSectionCode)
                && (this.AfEnterWarehCode == target.AfEnterWarehCode)
                && (this.ArrivalGoodsFlag == target.ArrivalGoodsFlag)
                && (this.SlipNote == target.SlipNote)
                && (this.DeleteFlag == target.DeleteFlag)
                && (this.StockMoveFixCode == target.StockMoveFixCode)
                && (this.SalesSlipDiv == target.SalesSlipDiv));
		}

		/// <summary>
		/// 在庫移動電子元帳検索条件比較処理
		/// </summary>
		/// <param name="stockMovePpr1">
		///                    比較するStockMovePprクラスのインスタンス
		/// </param>
		/// <param name="stockMovePpr2">比較するStockMovePprクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockMovePprクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(StockMovePpr stockMovePpr1, StockMovePpr stockMovePpr2)
		{
            return ((stockMovePpr1.SearchCnt == stockMovePpr2.SearchCnt)
                && (stockMovePpr1.EnterpriseCode == stockMovePpr2.EnterpriseCode)
                && (stockMovePpr1.OutputDiv == stockMovePpr2.OutputDiv)
                && (stockMovePpr1.InputSectionCode == stockMovePpr2.InputSectionCode)
                && (stockMovePpr1.SectionCode == stockMovePpr2.SectionCode)
                && (stockMovePpr1.WarehouseCode == stockMovePpr2.WarehouseCode)
                && (stockMovePpr1.St_Date == stockMovePpr2.St_Date)
                && (stockMovePpr1.Ed_Date == stockMovePpr2.Ed_Date)
                && (stockMovePpr1.SalesSlipNum == stockMovePpr2.SalesSlipNum)
                && (stockMovePpr1.St_AddUpADate == stockMovePpr2.St_AddUpADate)
                && (stockMovePpr1.Ed_AddUpADate == stockMovePpr2.Ed_AddUpADate)
                && (stockMovePpr1.SalesEmployeeCd == stockMovePpr2.SalesEmployeeCd)
                && (stockMovePpr1.SupplierCd == stockMovePpr2.SupplierCd)
                && (stockMovePpr1.GoodsMakerCd == stockMovePpr2.GoodsMakerCd)
                && (stockMovePpr1.BLGoodsCode == stockMovePpr2.BLGoodsCode)
                && (stockMovePpr1.GoodsNo == stockMovePpr2.GoodsNo)
                && (stockMovePpr1.GoodsName == stockMovePpr2.GoodsName)
                && (stockMovePpr1.WarehouseShelfNo == stockMovePpr2.WarehouseShelfNo)
                && (stockMovePpr1.AfSectionCode == stockMovePpr2.AfSectionCode)
                && (stockMovePpr1.AfEnterWarehCode == stockMovePpr2.AfEnterWarehCode)
                && (stockMovePpr1.ArrivalGoodsFlag == stockMovePpr2.ArrivalGoodsFlag)
                && (stockMovePpr1.SlipNote == stockMovePpr2.SlipNote)
                && (stockMovePpr1.DeleteFlag == stockMovePpr2.DeleteFlag)
                && (stockMovePpr1.StockMoveFixCode == stockMovePpr2.StockMoveFixCode)
                && (stockMovePpr1.SalesSlipDiv == stockMovePpr2.SalesSlipDiv));
		}
		/// <summary>
		/// 在庫移動電子元帳検索条件比較処理
		/// </summary>
		/// <param name="target">比較対象のStockMovePprクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockMovePprクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(StockMovePpr target)
		{
			ArrayList resList = new ArrayList();
            if (this.SearchCnt != target.SearchCnt) resList.Add("SearchCnt");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.OutputDiv != target.OutputDiv) resList.Add("OutputDiv");
            if (this.InputSectionCode != target.InputSectionCode) resList.Add("InputSectionCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.WarehouseCode != target.WarehouseCode) resList.Add("WarehouseCode");
            if (this.St_Date != target.St_Date) resList.Add("St_Date");
            if (this.Ed_Date != target.Ed_Date) resList.Add("Ed_Date");
            if (this.SalesSlipNum != target.SalesSlipNum) resList.Add("SalesSlipNum");
            if (this.St_AddUpADate != target.St_AddUpADate) resList.Add("St_AddUpADate");
            if (this.Ed_AddUpADate != target.Ed_AddUpADate) resList.Add("Ed_AddUpADate");
            if (this.SalesEmployeeCd != target.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.WarehouseShelfNo != target.WarehouseShelfNo) resList.Add("WarehouseShelfNo");
            if (this.AfSectionCode != target.AfSectionCode) resList.Add("AfSectionCode");
            if (this.AfEnterWarehCode != target.AfEnterWarehCode) resList.Add("AfEnterWarehCode");
            if (this.ArrivalGoodsFlag != target.ArrivalGoodsFlag) resList.Add("ArrivalGoodsFlag");
            if (this.SlipNote != target.SlipNote) resList.Add("SlipNote");
            if (this.DeleteFlag != target.DeleteFlag) resList.Add("DeleteFlag");
            if (this.StockMoveFixCode != target.StockMoveFixCode) resList.Add("StockMoveFixCode");
            if (this.SalesSlipDiv != target.SalesSlipDiv) resList.Add("SalesSlipDiv");

			return resList;
		}

		/// <summary>
		/// 在庫移動電子元帳検索条件比較処理
		/// </summary>
		/// <param name="stockMovePpr1">比較するStockMovePprクラスのインスタンス</param>
		/// <param name="stockMovePpr2">比較するStockMovePprクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockMovePprクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(StockMovePpr stockMovePpr1, StockMovePpr stockMovePpr2)
		{
			ArrayList resList = new ArrayList();
            if (stockMovePpr1.SearchCnt != stockMovePpr2.SearchCnt) resList.Add("SearchCnt");
            if (stockMovePpr1.EnterpriseCode != stockMovePpr2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (stockMovePpr1.OutputDiv != stockMovePpr2.OutputDiv) resList.Add("OutputDiv");
            if (stockMovePpr1.InputSectionCode != stockMovePpr2.InputSectionCode) resList.Add("InputSectionCode");
            if (stockMovePpr1.SectionCode != stockMovePpr2.SectionCode) resList.Add("SectionCode");
            if (stockMovePpr1.WarehouseCode != stockMovePpr2.WarehouseCode) resList.Add("WarehouseCode");
            if (stockMovePpr1.St_Date != stockMovePpr2.St_Date) resList.Add("St_Date");
            if (stockMovePpr1.Ed_Date != stockMovePpr2.Ed_Date) resList.Add("Ed_Date");
            if (stockMovePpr1.SalesSlipNum != stockMovePpr2.SalesSlipNum) resList.Add("SalesSlipNum");
            if (stockMovePpr1.St_AddUpADate != stockMovePpr2.St_AddUpADate) resList.Add("St_AddUpADate");
            if (stockMovePpr1.Ed_AddUpADate != stockMovePpr2.Ed_AddUpADate) resList.Add("Ed_AddUpADate");
            if (stockMovePpr1.SalesEmployeeCd != stockMovePpr2.SalesEmployeeCd) resList.Add("SalesEmployeeCd");
            if (stockMovePpr1.SupplierCd != stockMovePpr2.SupplierCd) resList.Add("SupplierCd");
            if (stockMovePpr1.GoodsMakerCd != stockMovePpr2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (stockMovePpr1.BLGoodsCode != stockMovePpr2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (stockMovePpr1.GoodsNo != stockMovePpr2.GoodsNo) resList.Add("GoodsNo");
            if (stockMovePpr1.GoodsName != stockMovePpr2.GoodsName) resList.Add("GoodsName");
            if (stockMovePpr1.WarehouseShelfNo != stockMovePpr2.WarehouseShelfNo) resList.Add("WarehouseShelfNo");
            if (stockMovePpr1.AfSectionCode != stockMovePpr2.AfSectionCode) resList.Add("AfSectionCode");
            if (stockMovePpr1.AfEnterWarehCode != stockMovePpr2.AfEnterWarehCode) resList.Add("AfEnterWarehCode");
            if (stockMovePpr1.ArrivalGoodsFlag != stockMovePpr2.ArrivalGoodsFlag) resList.Add("ArrivalGoodsFlag");
            if (stockMovePpr1.SlipNote != stockMovePpr2.SlipNote) resList.Add("SlipNote");
            if (stockMovePpr1.DeleteFlag != stockMovePpr2.DeleteFlag) resList.Add("DeleteFlag");
            if (stockMovePpr1.StockMoveFixCode != stockMovePpr2.StockMoveFixCode) resList.Add("StockMoveFixCode");
            if (stockMovePpr1.SalesSlipDiv != stockMovePpr2.SalesSlipDiv) resList.Add("SalesSlipDiv"); return resList;
		}
	}
}

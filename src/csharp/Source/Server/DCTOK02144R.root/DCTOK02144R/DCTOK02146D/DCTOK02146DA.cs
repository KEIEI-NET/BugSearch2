using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SalesTransListCndtnWork
	/// <summary>
	///                      売上推移表抽出条件クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   売上推移表抽出条件クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/09/05  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
    /// <br>Update Note      :   2014/12/16 劉超</br>
    /// <br>管理番号         :   11070263-00</br>
    /// <br>                 :   明治産業様Seiken品番変更</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SalesTransListCndtnWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		/// <remarks>(配列)　全社指定は{""}</remarks>
		private string[] _sectionCodes;

		/// <summary>集計単位</summary>
		/// <remarks>0:商品別 1:得意先別 2:担当者別 3:仕入先</remarks>
		private Int32 _totalType;

		/// <summary>集計方法</summary>
		/// <remarks>0:全社 1:拠点毎</remarks>
		private Int32 _ttlType;

		/// <summary>在庫取寄せ区分</summary>
		/// <remarks>0:合計 1:在庫, 2:取寄せ</remarks>
		private Int32 _rsltTtlDivCd;

		/// <summary>メーカー別印刷</summary>
		/// <remarks>0:しない 1:する</remarks>
		private Int32 _makerPrintDiv;

		/// <summary>明細単位</summary>
		private Int32 _detail;

        //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
        /// <summary>品番集計区分</summary>
        /// <remarks>0:別々 1:合算</remarks>
        private Int32 _goodsNoTtlDiv;
        /// <summary>品番表示区分</summary>
        /// <remarks>0:新品番 1:旧品番</remarks>
        private Int32 _goodsNoShowDiv;
        //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<

		/// <summary>開始対象年月</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _addUpYearMonthSt;

		/// <summary>終了対象年月</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _addUpYearMonthEd;

		/// <summary>開始印刷範囲指定</summary>
		private Int32 _printRangeSt;

		/// <summary>終了印刷範囲指定</summary>
		private Int32 _printRangeEd;

		/// <summary>開始得意先コード</summary>
		private Int32 _customerCodeSt;

		/// <summary>終了得意先コード</summary>
		private Int32 _customerCodeEd;

        /// <summary>開始仕入先コード</summary>
        private Int32 _supplierCodeSt;　　　　　// ADD 2009/04/15

        /// <summary>終了仕入先コード</summary>
        private Int32 _supplierCodeEd;　　　　　// ADD 2009/04/15

		/// <summary>開始従業員コード</summary>
		private string _employeeCodeSt = "";

		/// <summary>終了従業員コード</summary>
		private string _employeeCodeEd = "";

		/// <summary>開始商品メーカーコード</summary>
		private Int32 _goodsMakerCdSt;

		/// <summary>終了商品メーカーコード</summary>
		private Int32 _goodsMakerCdEd;

		/// <summary>開始商品大分類コード</summary>
		private Int32 _goodsLGroupSt;

		/// <summary>終了商品大分類コード</summary>
		private Int32 _goodsLGroupEd;

		/// <summary>開始商品中分類コード</summary>
		private Int32 _goodsMGroupSt;

		/// <summary>終了商品中分類コード</summary>
		private Int32 _goodsMGroupEd;

		/// <summary>開始BLグループコード</summary>
		private Int32 _bLGroupCodeSt;

		/// <summary>終了BLグループコード</summary>
		private Int32 _bLGroupCodeEd;

		/// <summary>開始BL商品コード</summary>
		private Int32 _bLGoodsCodeSt;

		/// <summary>終了BL商品コード</summary>
		private Int32 _bLGoodsCodeEd;

		/// <summary>開始商品番号</summary>
		private string _goodsNoSt = "";

		/// <summary>終了商品番号</summary>
		private string _goodsNoEd = "";


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

		/// public propaty name  :  TotalType
		/// <summary>集計単位プロパティ</summary>
		/// <value>0:商品別 1:得意先別 2:担当者別 3:仕入先</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   集計単位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TotalType
		{
			get{return _totalType;}
			set{_totalType = value;}
		}

		/// public propaty name  :  TtlType
		/// <summary>集計方法プロパティ</summary>
		/// <value>0:全社 1:拠点毎</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   集計方法プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TtlType
		{
			get{return _ttlType;}
			set{_ttlType = value;}
		}

		/// public propaty name  :  RsltTtlDivCd
		/// <summary>在庫取寄せ区分プロパティ</summary>
		/// <value>0:合計 1:在庫, 2:取寄せ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫取寄せ区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 RsltTtlDivCd
		{
			get{return _rsltTtlDivCd;}
			set{_rsltTtlDivCd = value;}
		}

		/// public propaty name  :  MakerPrintDiv
		/// <summary>メーカー別印刷プロパティ</summary>
		/// <value>0:しない 1:する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカー別印刷プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MakerPrintDiv
		{
			get{return _makerPrintDiv;}
			set{_makerPrintDiv = value;}
		}

		/// public propaty name  :  Detail
		/// <summary>明細単位プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   明細単位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 Detail
		{
			get{return _detail;}
			set{_detail = value;}
		}

        //------ ADD START 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------>>>>>
        /// public propaty name  :  GoodsNoTtlDiv
        /// <summary>品番集計区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番集計区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsNoTtlDiv
        {
            get { return _goodsNoTtlDiv; }
            set { _goodsNoTtlDiv = value; }
        }

        /// public propaty name  :  GoodsNoShowDiv
        /// <summary>品番表示区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsNoShowDiv
        {
            get { return _goodsNoShowDiv; }
            set { _goodsNoShowDiv = value; }
        }
        //------ ADD END 2014/12/16 劉超 FOR Redmine#44209明治産業様Seiken品番変更 ------<<<<<

		/// public propaty name  :  AddUpYearMonthSt
		/// <summary>開始対象年月プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始対象年月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime AddUpYearMonthSt
		{
			get{return _addUpYearMonthSt;}
			set{_addUpYearMonthSt = value;}
		}

		/// public propaty name  :  AddUpYearMonthEd
		/// <summary>終了対象年月プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了対象年月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime AddUpYearMonthEd
		{
			get{return _addUpYearMonthEd;}
			set{_addUpYearMonthEd = value;}
		}

		/// public propaty name  :  PrintRangeSt
		/// <summary>開始印刷範囲指定プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始印刷範囲指定プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrintRangeSt
		{
			get{return _printRangeSt;}
			set{_printRangeSt = value;}
		}

		/// public propaty name  :  PrintRangeEd
		/// <summary>終了印刷範囲指定プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了印刷範囲指定プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrintRangeEd
		{
			get{return _printRangeEd;}
			set{_printRangeEd = value;}
		}

		/// public propaty name  :  CustomerCodeSt
		/// <summary>開始得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustomerCodeSt
		{
			get{return _customerCodeSt;}
			set{_customerCodeSt = value;}
		}

		/// public propaty name  :  CustomerCodeEd
		/// <summary>終了得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了得意先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustomerCodeEd
		{
			get{return _customerCodeEd;}
			set{_customerCodeEd = value;}
		}

        // --- ADD 2009/04/15 -------------------------------->>>>>
        /// public propaty name  :  SupplierCodeSt
        /// <summary>開始仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCodeSt
        {
            get { return _supplierCodeSt; }
            set { _supplierCodeSt = value; }
        }

        /// public propaty name  :  SupplierCodeEd
        /// <summary>終了仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCodeEd
        {
            get { return _supplierCodeEd; }
            set { _supplierCodeEd = value; }
        }
        // --- ADD 2009/04/15 --------------------------------<<<<<

		/// public propaty name  :  EmployeeCodeSt
		/// <summary>開始従業員コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EmployeeCodeSt
		{
			get{return _employeeCodeSt;}
			set{_employeeCodeSt = value;}
		}

		/// public propaty name  :  EmployeeCodeEd
		/// <summary>終了従業員コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EmployeeCodeEd
		{
			get{return _employeeCodeEd;}
			set{_employeeCodeEd = value;}
		}

		/// public propaty name  :  GoodsMakerCdSt
		/// <summary>開始商品メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始商品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsMakerCdSt
		{
			get{return _goodsMakerCdSt;}
			set{_goodsMakerCdSt = value;}
		}

		/// public propaty name  :  GoodsMakerCdEd
		/// <summary>終了商品メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了商品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsMakerCdEd
		{
			get{return _goodsMakerCdEd;}
			set{_goodsMakerCdEd = value;}
		}

		/// public propaty name  :  GoodsLGroupSt
		/// <summary>開始商品大分類コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始商品大分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsLGroupSt
		{
			get{return _goodsLGroupSt;}
			set{_goodsLGroupSt = value;}
		}

		/// public propaty name  :  GoodsLGroupEd
		/// <summary>終了商品大分類コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了商品大分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsLGroupEd
		{
			get{return _goodsLGroupEd;}
			set{_goodsLGroupEd = value;}
		}

		/// public propaty name  :  GoodsMGroupSt
		/// <summary>開始商品中分類コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始商品中分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsMGroupSt
		{
			get{return _goodsMGroupSt;}
			set{_goodsMGroupSt = value;}
		}

		/// public propaty name  :  GoodsMGroupEd
		/// <summary>終了商品中分類コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了商品中分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsMGroupEd
		{
			get{return _goodsMGroupEd;}
			set{_goodsMGroupEd = value;}
		}

		/// public propaty name  :  BLGroupCodeSt
		/// <summary>開始BLグループコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始BLグループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BLGroupCodeSt
		{
			get{return _bLGroupCodeSt;}
			set{_bLGroupCodeSt = value;}
		}

		/// public propaty name  :  BLGroupCodeEd
		/// <summary>終了BLグループコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了BLグループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BLGroupCodeEd
		{
			get{return _bLGroupCodeEd;}
			set{_bLGroupCodeEd = value;}
		}

		/// public propaty name  :  BLGoodsCodeSt
		/// <summary>開始BL商品コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始BL商品コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BLGoodsCodeSt
		{
			get{return _bLGoodsCodeSt;}
			set{_bLGoodsCodeSt = value;}
		}

		/// public propaty name  :  BLGoodsCodeEd
		/// <summary>終了BL商品コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了BL商品コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BLGoodsCodeEd
		{
			get{return _bLGoodsCodeEd;}
			set{_bLGoodsCodeEd = value;}
		}

		/// public propaty name  :  GoodsNoSt
		/// <summary>開始商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNoSt
		{
			get{return _goodsNoSt;}
			set{_goodsNoSt = value;}
		}

		/// public propaty name  :  GoodsNoEd
		/// <summary>終了商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNoEd
		{
			get{return _goodsNoEd;}
			set{_goodsNoEd = value;}
		}


		/// <summary>
		/// 売上推移表抽出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>SalesTransListCndtnWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesTransListCndtnWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SalesTransListCndtnWork()
		{
		}

	}
}

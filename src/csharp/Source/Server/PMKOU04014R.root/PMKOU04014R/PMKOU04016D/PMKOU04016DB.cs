using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SuppPrtPprBlnceWork
	/// <summary>
	///                      仕入先電子元帳検索条件(残高一覧)ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   仕入先電子元帳検索条件(残高一覧)ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/08/18  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2010/07/20 chenyd</br>
    /// <br>           　        テキスト出力対応</br>
    /// <br>Update Note      :   2012/09/13 FSI上北田 秀樹</br>
    /// <br>           　        仕入先総括対応の追加</br> 
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SuppPrtPprBlnceWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>拠点コード</summary>
		/// <remarks>(配列)　全社指定は{""}</remarks>
		private string[] _sectionCode;

		/// <summary>仕入先コード</summary>
		private Int32 _supplierCd;

		/// <summary>支払先コード</summary>
		private Int32 _payeeCode;

        // ---------------------- ADD 2010/07/20 -------------->>>>>
        /// <summary>開始仕入先コード</summary>
        private Int32 _st_supplierCd;

        /// <summary>終了仕入先コード</summary>
        private Int32 _ed_supplierCd;

        // ---------------------- ADD 2010/07/20 ---------------<<<<<
        /// <summary>検索区分</summary>
        private Int32 _searchDiv;

		/// <summary>開始対象年月</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _st_AddUpYearMonth;

		/// <summary>終了対象年月</summary>
		/// <remarks>YYYYMM</remarks>
		private DateTime _ed_AddUpYearMonth;

        // --- ADD 2012/09/13 ---------->>>>>
        /// <summary>仕入先総括オプションフラグ</summary>
        private bool _opt_SupplierSummary;
        // --- ADD 2012/09/13 ----------<<<<<

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
		/// <value>(配列)　全社指定は{""}</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
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
			get{return _supplierCd;}
			set{_supplierCd = value;}
		}
        // ---------------------- ADD 2010/07/20 --------------------------------->>>>>
        /// public propaty name  :  St_SupplierCd
        /// <summary>開始仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_SupplierCd
        {
            get { return _st_supplierCd; }
            set { _st_supplierCd = value; }
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
            get { return _ed_supplierCd; }
            set { _ed_supplierCd = value; }
        }
        // ---------------------- ADD 2010/07/20 ---------------------------------<<<<<
        /// public propaty name  :  SearchDiv
        /// <summary>検索区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchDiv
        {
            get { return _searchDiv; }
            set { _searchDiv = value; }
        }

		/// public propaty name  :  PayeeCode
		/// <summary>支払先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PayeeCode
		{
			get{return _payeeCode;}
			set{_payeeCode = value;}
		}

		/// public propaty name  :  St_AddUpYearMonth
		/// <summary>開始対象年月プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始対象年月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime St_AddUpYearMonth
		{
			get{return _st_AddUpYearMonth;}
			set{_st_AddUpYearMonth = value;}
		}

		/// public propaty name  :  Ed_AddUpYearMonth
		/// <summary>終了対象年月プロパティ</summary>
		/// <value>YYYYMM</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了対象年月プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime Ed_AddUpYearMonth
		{
			get{return _ed_AddUpYearMonth;}
			set{_ed_AddUpYearMonth = value;}
		}

        // --- ADD 2012/09/13 ---------->>>>>
        /// public propaty name  :  OptSupplierSummary
        /// <summary>仕入先総括オプションプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先総括オプションプロパティ</br>
        /// <br>Programer        :   FSI上北田 秀樹</br>
        /// </remarks>
        public bool OptSupplierSummary
        {
            get { return _opt_SupplierSummary; }
            set { _opt_SupplierSummary = value; }
        }
        // --- ADD 2012/09/13 ----------<<<<<

		/// <summary>
		/// 仕入先電子元帳検索条件(残高一覧)ワークコンストラクタ
		/// </summary>
		/// <returns>SuppPrtPprBlnceWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SuppPrtPprBlnceWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SuppPrtPprBlnceWork()
		{
		}

	}
}

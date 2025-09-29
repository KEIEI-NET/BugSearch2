using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:	 TrgtCompSalesRslt
    /// <summary>
    /// 					 目標用売上実績データ
    /// </summary>
    /// <remarks>
    /// <br>note			 :	 目標用売上実績データファイル</br>
    /// <br>Programmer		 :	 NEPCO</br>
    /// <br>Date			 :	 </br>
    /// <br>Genarated Date	 :	 2007/04/27  (CSharp File Generated Date)</br>
	/// <br>Update Note		 :   2007.11.21 上野 弘貴</br>
	/// <br>                     流通.DC用に変更（項目追加・削除）</br>
    /// <br></br>
    /// </remarks>
    public class TrgtCompSalesRslt
    {
        #region Private Member

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>目標対比区分</summary>
        private Int32 _targetContrastCd;

        /// <summary>売上日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _salesDate;

        /// <summary>従業員コード</summary>
        private string _employeeCode = "";

//----- ueno add---------- start 2007.11.21
		/// <summary>従業員区分</summary>
		private Int32 _employeeDivCd;

		/// <summary>部門コード</summary>
		private Int32 _subSectionCode;

		/// <summary>課コード</summary>
		private Int32 _minSectionCode;

		/// <summary>業種コード</summary>
		private Int32 _businessTypeCode;

		/// <summary>販売エリアコード</summary>
		private Int32 _salesAreaCode;

		/// <summary>得意先コード</summary>
		private Int32 _customerCode;
//----- ueno add---------- end   2007.11.21

		//----- ueno del---------- start 2007.11.21
		///// <summary>売上形式</summary>
		//private Int32 _salesFormal;

		///// <summary>販売形態コード</summary>
		//private Int32 _salesFormCode;

		///// <summary>キャリアコード</summary>
		//private Int32 _carrierCode;

		///// <summary>機種コード</summary>
		//private string _cellphoneModelCode = "";
		//----- ueno del---------- end   2007.11.21

        /// <summary>メーカーコード</summary>
        private Int32 _makerCode;

        /// <summary>商品コード</summary>
        private string _goodsCode = "";

        /// <summary>売上金額</summary>
        private Int64 _salesmonyTaxExc;

        /// <summary>売上原価</summary>
        private Int64 _cost;

		//----- ueno del---------- start 2007.11.21
		///// <summary>受取インセンティブ</summary>
		//private Int64 _insentiveRecv;

		///// <summary>支払インセンティブ</summary>
		//private Int64 _insentiveDtbt;
		//----- ueno del---------- end   2007.11.21

        /// <summary>売上数量</summary>
        private Double _salesCount;

        #endregion Private Member

        #region Public Propaty

        /// public propaty name  :	EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 企業コードプロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get
            {
                return _enterpriseCode;
            }
            set
            {
                _enterpriseCode = value;
            }
        }

        /// public propaty name  :	SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 拠点コードプロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string SectionCode
        {
            get
            {
                return _sectionCode;
            }
            set
            {
                _sectionCode = value;
            }
        }

        /// public propaty name  :	TargetContrastCd
        /// <summary>目標対比区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 目標対比区分プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Int32 TargetContrastCd
        {
            get
            {
                return _targetContrastCd;
            }
            set
            {
                _targetContrastCd = value;
            }
        }

        /// public propaty name  :	SalesDate
        /// <summary>売上日プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 売上日プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public DateTime SalesDate
        {
            get
            {
                return _salesDate;
            }
            set
            {
                _salesDate = value;
            }
        }

        /// public propaty name  :	SalesDateJpFormal
        /// <summary>売上日 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 売上日 和暦プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string SalesDateJpFormal
        {
            get
            {
                return TDateTime.DateTimeToString("GGYYMMDD", _salesDate);
            }
            set
            {
            }
        }

        /// public propaty name  :	SalesDateJpInFormal
        /// <summary>売上日 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 売上日 和暦(略)プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string SalesDateJpInFormal
        {
            get
            {
                return TDateTime.DateTimeToString("ggYY/MM/DD", _salesDate);
            }
            set
            {
            }
        }

        /// public propaty name  :	SalesDateAdFormal
        /// <summary>売上日 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 売上日 西暦プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string SalesDateAdFormal
        {
            get
            {
                return TDateTime.DateTimeToString("YYYY/MM/DD", _salesDate);
            }
            set
            {
            }
        }

        /// public propaty name  :	SalesDateAdInFormal
        /// <summary>売上日 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 売上日 西暦(略)プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string SalesDateAdInFormal
        {
            get
            {
                return TDateTime.DateTimeToString("YY/MM/DD", _salesDate);
            }
            set
            {
            }
        }

        /// public propaty name  :	EmployeeCode
        /// <summary>従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 従業員コードプロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string EmployeeCode
        {
            get
            {
                return _employeeCode;
            }
            set
            {
                _employeeCode = value;
            }
        }

//----- ueno add---------- start 2007.11.21
		/// public propaty name  :	EmployeeDivCd
		/// <summary>従業員区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 従業員区分プロパティ</br>
		/// <br>Programer		 :	 30167 上野　弘貴</br>
		/// </remarks>
		public Int32 EmployeeDivCd
		{
			get
			{
				return _employeeDivCd;
			}
			set
			{
				_employeeDivCd = value;
			}
		}

		/// public propaty name  :	SubSectionCode
		/// <summary>部門コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 部門コードプロパティ</br>
		/// <br>Programer		 :	 30167 上野　弘貴</br>
		/// </remarks>
		public Int32 SubSectionCode
		{
			get
			{
				return _subSectionCode;
			}
			set
			{
				_subSectionCode = value;
			}
		}

		/// public propaty name  :	MinSectionCode
		/// <summary>課コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 課コードプロパティ</br>
		/// <br>Programer		 :	 30167 上野　弘貴</br>
		/// </remarks>
		public Int32 MinSectionCode
		{
			get
			{
				return _minSectionCode;
			}
			set
			{
				_minSectionCode = value;
			}
		}

		/// public propaty name  :	BusinessTypeCode
		/// <summary>業種コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 業種コードプロパティ</br>
		/// <br>Programer		 :	 30167 上野　弘貴</br>
		/// </remarks>
		public Int32 BusinessTypeCode
		{
			get
			{
				return _businessTypeCode;
			}
			set
			{
				_businessTypeCode = value;
			}
		}

		/// public propaty name  :	SalesAreaCode
		/// <summary>販売エリアコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 販売エリアコードプロパティ</br>
		/// <br>Programer		 :	 30167 上野　弘貴</br>
		/// </remarks>
		public Int32 SalesAreaCode
		{
			get
			{
				return _salesAreaCode;
			}
			set
			{
				_salesAreaCode = value;
			}
		}

		/// public propaty name  :	CustomerCode
		/// <summary>得意先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 得意先コードプロパティ</br>
		/// <br>Programer		 :	 30167 上野　弘貴</br>
		/// </remarks>
		public Int32 CustomerCode
		{
			get
			{
				return _customerCode;
			}
			set
			{
				_customerCode = value;
			}
		}
//----- ueno add---------- end   2007.11.21

		//----- ueno del---------- start 2007.11.21
		#region del
		///// public propaty name  :	SalesFormal
		///// <summary>売上形式プロパティ</summary>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note			 :	 売上形式プロパティ</br>
		///// <br>Programer		 :	 NEPCO</br>
		///// </remarks>
		//public int SalesFormal
		//{
		//    get
		//    {
		//        return _salesFormal;
		//    }
		//    set
		//    {
		//        _salesFormal = value;
		//    }
		//}

		///// public propaty name  :	SalesFormCode
		///// <summary>販売形態コードプロパティ</summary>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note			 :	 販売形態コードプロパティ</br>
		///// <br>Programer		 :	 NEPCO</br>
		///// </remarks>
		//public int SalesFormCode
		//{
		//    get
		//    {
		//        return _salesFormCode;
		//    }
		//    set
		//    {
		//        _salesFormCode = value;
		//    }

		//}

		///// public propaty name  :	CarrierCode
		///// <summary>キャリアコードプロパティ</summary>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note			 :	 従業員コードプロパティ</br>
		///// <br>Programer		 :	 NEPCO</br>
		///// </remarks>
		//public Int32 CarrierCode
		//{
		//    get
		//    {
		//        return _carrierCode;
		//    }
		//    set
		//    {
		//        _carrierCode = value;
		//    }
		//}

		///// public propaty name  :	CellphoneModelCode
		///// <summary>機種コードプロパティ</summary>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note			 :	 機種コードプロパティ</br>
		///// <br>Programer		 :	 NEPCO</br>
		///// </remarks>
		//public string CellphoneModelCode
		//{
		//    get
		//    {
		//        return _cellphoneModelCode;
		//    }
		//    set
		//    {
		//        _cellphoneModelCode = value;
		//    }
		//}
        #endregion del
		//----- ueno del---------- end   2007.11.21

        /// public propaty name  :	MakerCode
        /// <summary>メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 メーカーコードプロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public int MakerCode
        {
            get
            {
                return _makerCode;
            }
            set
            {
                _makerCode = value;
            }
        }

        /// public propaty name  :	GoodsCode
        /// <summary>商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 商品コードプロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public string GoodsCode
        {
            get
            {
                return _goodsCode;
            }
            set
            {
                _goodsCode = value;
            }
        }

        /// public propaty name  :	SalesmonyTaxExc
        /// <summary>売上金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	売上金額プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Int64 SalesmonyTaxExc
        {
            get
            {
                return _salesmonyTaxExc;
            }
            set
            {
                _salesmonyTaxExc = value;
            }
        }

        /// public propaty name  :	Cost
        /// <summary>売上原価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 売上原価プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Int64 Cost
        {
            get
            {
                return _cost;
            }
            set
            {
                _cost = value;
            }
        }

		//----- ueno del---------- start 2007.11.21
		#region del
		///// public propaty name  :	InsentiveRecv
		///// <summary>受取インセンティブプロパティ</summary>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note			 :	 受取インセンティブプロパティ</br>
		///// <br>Programer		 :	 NEPCO</br>
		///// </remarks>
		//public Int64 InsentiveRecv
		//{
		//    get
		//    {
		//        return _insentiveRecv;
		//    }
		//    set
		//    {
		//        _insentiveRecv = value;
		//    }
		//}

		///// public propaty name  :	InsentiveDtbt
		///// <summary>支払インセンティブプロパティ</summary>
		///// ----------------------------------------------------------------------
		///// <remarks>
		///// <br>note			 :	 支払インセンティブプロパティ</br>
		///// <br>Programer		 :	 NEPCO</br>
		///// </remarks>
		//public Int64 InsentiveDtbt
		//{
		//    get
		//    {
		//        return _insentiveDtbt;
		//    }
		//    set
		//    {
		//        _insentiveDtbt = value;
		//    }
		//}
		#endregion del
		//----- ueno del---------- end   2007.11.21

        /// public propaty name  :	SalesCount
        /// <summary>売上数量プロパティ</summary>
        /// <value>時刻（時間、分）商品入荷予定日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 売上数量プロパティ</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public Double SalesCount
        {
            get
            {
                return _salesCount;
            }
            set
            {
                _salesCount = value;
            }
        }
        #endregion Public Propaty

        #region コンストラクタ
        /// <summary>
        /// 目標用売上実績データコンストラクタ
        /// </summary>
        /// <returns>TrgtCompSalesRsltクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :	 TrgtCompSalesRsltクラスの新しいインスタンスを生成します</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public TrgtCompSalesRslt()
        {
        }


        /// <summary>
        /// 目標用売上実績データコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="targetContrastCd">目標対比区分</param>
        /// <param name="salesDate">売上日(YYYYMMDD)</param>
        /// <param name="employeeCode">従業員コード</param>
		/// <param name="employeeDivCd">従業員区分</param>
		/// <param name="subSectionCode">部門コード</param>
		/// <param name="minSectionCode">課コード</param>
		/// <param name="businessTypeCode">業種コード</param>
		/// <param name="salesAreaCode">販売エリアコード</param>
		/// <param name="customerCode">得意先コード</param>
        /// <param name="makerCode">メーカーコード</param>
        /// <param name="goodsCode">商品コード</param>
        /// <param name="salesmonyTaxExc">売上金額</param>
        /// <param name="trgtCompSalesRsltProfit">売上原価</param>
        /// <param name="salesCount">売上数量</param>
        /// <returns>TrgtCompSalesRsltクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :	 TrgtCompSalesRsltクラスの新しいインスタンスを生成します</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public TrgtCompSalesRslt(
            string enterpriseCode,
            string sectionCode,
            Int32 targetContrastCd,
            DateTime salesDate,
            string employeeCode,
//----- ueno add---------- start 2007.11.21
			Int32 employeeDivCd,
			Int32 subSectionCode,
			Int32 minSectionCode,
			Int32 businessTypeCode,
			Int32 salesAreaCode,
			Int32 customerCode,
//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//int salesFormal,
			//int salesFormCode,
			//Int32 carrierCode,
			//string cellphoneModelCode,
			//----- ueno del---------- end   2007.11.21
            int makerCode,
            string goodsCode,
            Int64 salesmonyTaxExc,
            Int64 trgtCompSalesRsltProfit,
			//----- ueno del---------- start 2007.11.21
			//Int64 insentiveRecv,
			//Int64 insentiveDtbt,
			//----- ueno del---------- end   2007.11.21
            Double salesCount
            )
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._targetContrastCd = targetContrastCd;
            this._salesDate = salesDate;
            this._employeeCode = employeeCode;
//----- ueno add---------- start 2007.11.21
			this._employeeDivCd = employeeDivCd;
			this._subSectionCode = subSectionCode;
			this._minSectionCode = minSectionCode;
			this._businessTypeCode = businessTypeCode;
			this._salesAreaCode = salesAreaCode;
			this._customerCode = customerCode;
//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//this._salesFormal = salesFormal;
			//this._salesFormCode = salesFormCode;
			//this._carrierCode = carrierCode;
			//this._cellphoneModelCode = cellphoneModelCode;
			//----- ueno del---------- end   2007.11.21
            this._makerCode = makerCode;
            this._goodsCode = goodsCode;
            this._salesmonyTaxExc = salesmonyTaxExc;
            this._cost = trgtCompSalesRsltProfit;
			//----- ueno del---------- start 2007.11.21
			//this._insentiveRecv = insentiveRecv;
			//this._insentiveDtbt = insentiveDtbt;
			//----- ueno del---------- end   2007.11.21
            this._salesCount = salesCount;
        }

        #endregion コンストラクタ

        #region Public Method
        #region ◆　目標用売上実績データ複製処理
        /// <summary>
        /// 目標用売上実績データ複製処理
        /// </summary>
        /// <returns>TrgtCompSalesRsltクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :	 自身の内容と等しいTrgtCompSalesRsltクラスのインスタンスを返します</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public TrgtCompSalesRslt Clone()
        {
            return new TrgtCompSalesRslt(
                               this._enterpriseCode,
                               this._sectionCode,
                               this._targetContrastCd,
                               this._salesDate,
                               this._employeeCode,
//----- ueno add---------- start 2007.11.21
							   this._employeeDivCd,
							   this._subSectionCode,
							   this._minSectionCode,
							   this._businessTypeCode,
							   this._salesAreaCode,
							   this._customerCode,
//----- ueno add---------- end   2007.11.21
							   //----- ueno del---------- start 2007.11.21
							   //this._salesFormal,
							   //this._salesFormCode,
							   //this._carrierCode,
							   //this._cellphoneModelCode,
							   //----- ueno del---------- end   2007.11.21
                               this._makerCode,
                               this._goodsCode,
                               this._salesmonyTaxExc,
                               this._cost,
			  				   //----- ueno del---------- start 2007.11.21
							   //this._insentiveRecv,
							   //this._insentiveDtbt,
							   //----- ueno del---------- end   2007.11.21
                               this._salesCount
                               );
        }
        #endregion ◆　目標用売上実績データ複製処理

        #region ◆　目標用売上実績データ比較処理(TrgtCompSalesRslt)
        /// <summary>
        /// 目標用売上実績データ比較処理
        /// </summary>
        /// <param name="target">比較対象のTrgtCompSalesRsltクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :	 TrgtCompSalesRsltクラスの内容が一致するか比較します</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public bool Equals(TrgtCompSalesRslt target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.TargetContrastCd == target.TargetContrastCd)
                 && (this.SalesDate == target.SalesDate)
                 && (this.EmployeeCode == target.EmployeeCode)
//----- ueno add---------- start 2007.11.21
				 && (this.EmployeeDivCd == target.EmployeeDivCd)
				 && (this.SubSectionCode == target.SubSectionCode)
				 && (this.MinSectionCode == target.MinSectionCode)
				 && (this.BusinessTypeCode == target.BusinessTypeCode)
				 && (this.SalesAreaCode == target.SalesAreaCode)
				 && (this.CustomerCode == target.CustomerCode)
//----- ueno add---------- end   2007.11.21
				 //----- ueno del---------- start 2007.11.21
				 //&& (this.SalesFormal == target.SalesFormal)
				 //&& (this.SalesFormCode == target.SalesFormCode)
				 //&& (this.CarrierCode == target.CarrierCode)
				 //&& (this.CellphoneModelCode == target.CellphoneModelCode)
				 //----- ueno del---------- end   2007.11.21
                 && (this.MakerCode == target.MakerCode)
                 && (this.GoodsCode == target.GoodsCode)
                 && (this.SalesmonyTaxExc == target.SalesmonyTaxExc)
                 && (this.Cost == target.Cost)
				 //----- ueno del---------- start 2007.11.21
				 //&& (this.InsentiveRecv == target.InsentiveRecv)
				 //&& (this.InsentiveDtbt == target.InsentiveDtbt)
				 //----- ueno del---------- end   2007.11.21
                 && (this.SalesCount == target.SalesCount)
                 );
        }
        #endregion ◆　目標用売上実績データ比較処理

        #region ◆　目標用売上実績データ比較処理(TrgtCompSalesRslt,ResvdDT)
        /// <summary>
        /// 目標用売上実績データ比較処理
        /// </summary>
        /// <param name="salesMonTarget1">
        /// 				   比較するTrgtCompSalesRsltクラスのインスタンス
        /// </param>
        /// <param name="salesMonTarget2">比較するTrgtCompSalesRsltクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :	 TrgtCompSalesRsltクラスの内容が一致するか比較します</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public static bool Equals(TrgtCompSalesRslt salesMonTarget1, TrgtCompSalesRslt salesMonTarget2)
        {
            return ((salesMonTarget1.EnterpriseCode == salesMonTarget2.EnterpriseCode)
                 && (salesMonTarget1.SectionCode == salesMonTarget2.SectionCode)
                 && (salesMonTarget1.TargetContrastCd == salesMonTarget2.TargetContrastCd)
                 && (salesMonTarget1.SalesDate == salesMonTarget2.SalesDate)
                 && (salesMonTarget1.EmployeeCode == salesMonTarget2.EmployeeCode)
//----- ueno add---------- start 2007.11.21
				 && (salesMonTarget1.EmployeeDivCd == salesMonTarget2.EmployeeDivCd)
				 && (salesMonTarget1.SubSectionCode == salesMonTarget2.SubSectionCode)
				 && (salesMonTarget1.MinSectionCode == salesMonTarget2.MinSectionCode)
				 && (salesMonTarget1.BusinessTypeCode == salesMonTarget2.BusinessTypeCode)
				 && (salesMonTarget1.SalesAreaCode == salesMonTarget2.SalesAreaCode)
				 && (salesMonTarget1.CustomerCode == salesMonTarget2.CustomerCode)
//----- ueno add---------- end   2007.11.21
				 //----- ueno del---------- start 2007.11.21
				 //&& (salesMonTarget1.SalesFormal == salesMonTarget2.SalesFormal)
				 //&& (salesMonTarget1.SalesFormCode == salesMonTarget2.SalesFormCode)
				 //&& (salesMonTarget1.CarrierCode == salesMonTarget2.CarrierCode)
				 //&& (salesMonTarget1.CellphoneModelCode == salesMonTarget2.CellphoneModelCode)
				 //----- ueno del---------- end   2007.11.21
                 && (salesMonTarget1.MakerCode == salesMonTarget2.MakerCode)
                 && (salesMonTarget1.GoodsCode == salesMonTarget2.GoodsCode)
                 && (salesMonTarget1.SalesmonyTaxExc == salesMonTarget2.SalesmonyTaxExc)
                 && (salesMonTarget1.Cost == salesMonTarget2.Cost)
				 //----- ueno del---------- start 2007.11.21
				 //&& (salesMonTarget1.InsentiveRecv == salesMonTarget2.InsentiveRecv)
                 //&& (salesMonTarget1.InsentiveDtbt == salesMonTarget2.InsentiveDtbt)
				 //----- ueno del---------- end   2007.11.21
                 && (salesMonTarget1.SalesCount == salesMonTarget2.SalesCount)
                 );
        }
        #endregion ◆　目標用売上実績データ比較処理(TrgtCompSalesRslt,ResvdDT)

        #region ◆　目標用売上実績データ比較結果リスト作成処理(TrgtCompSalesRslt)
        /// <summary>
        /// 目標用売上実績データ比較結果リスト作成処理
        /// </summary>
        /// <param name="target">比較対象のTrgtCompSalesRsltクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :	 TrgtCompSalesRsltクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public ArrayList Compare(TrgtCompSalesRslt target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.TargetContrastCd != target.TargetContrastCd) resList.Add("TargetContrastCd");
            if (this.SalesDate != target.SalesDate) resList.Add("SalesDate");
            if (this.EmployeeCode != target.EmployeeCode) resList.Add("EmployeeCode");
//----- ueno add---------- start 2007.11.21
			if (this.EmployeeDivCd != target.EmployeeDivCd) resList.Add("EmployeeDivCd");
			if (this.SubSectionCode != target.SubSectionCode) resList.Add("SubSectionCode");
			if (this.MinSectionCode != target.MinSectionCode) resList.Add("MinSectionCode");
			if (this.BusinessTypeCode != target.BusinessTypeCode) resList.Add("BusinessTypeCode");
			if (this.SalesAreaCode != target.SalesAreaCode) resList.Add("SalesAreaCode");
			if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//if (this.SalesFormal != target.SalesFormal) resList.Add("SalesFormal");
			//if (this.SalesFormCode != target.SalesFormCode) resList.Add("SalesFormCode");
			//if (this.CarrierCode != target.CarrierCode) resList.Add("CarrierCode");
			//if (this.CellphoneModelCode != target.CellphoneModelCode) resList.Add("CellphoneModelCode");
			//----- ueno del---------- end   2007.11.21
            if (this.MakerCode != target.MakerCode) resList.Add("MakerCode");
            if (this.GoodsCode != target.GoodsCode) resList.Add("GoodsCode");
            if (this.SalesmonyTaxExc != target.SalesmonyTaxExc) resList.Add("SalesmonyTaxExc");
            if (this.Cost != target.Cost) resList.Add("Cost");
			//----- ueno del---------- start 2007.11.21
			//if (this.InsentiveRecv != target.InsentiveRecv) resList.Add("InsentiveRecv");
			//if (this.InsentiveDtbt != target.InsentiveDtbt) resList.Add("InsentiveDtbt");
			//----- ueno del---------- end   2007.11.21
            if (this.SalesCount != target.SalesCount) resList.Add("SalesCount");

            return resList;
        }
        #endregion ◆　目標用売上実績データ比較結果リスト作成処理(TrgtCompSalesRslt)

        #region ◆　目標用売上実績データ比較結果リスト作成処理(TrgtCompSalesRslt,TrgtCompSalesRslt)
        /// <summary>
        /// 目標用売上実績データ比較処理
        /// </summary>
        /// <param name="salesMonTarget1">比較するTrgtCompSalesRsltクラスのインスタンス</param>
        /// <param name="salesMonTarget2">比較するTrgtCompSalesRsltクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :	 TrgtCompSalesRsltクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer		 :	 NEPCO</br>
        /// </remarks>
        public static ArrayList Compare(TrgtCompSalesRslt salesMonTarget1, TrgtCompSalesRslt salesMonTarget2)
        {
            ArrayList resList = new ArrayList();
            if (salesMonTarget1.EnterpriseCode != salesMonTarget2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (salesMonTarget1.SectionCode != salesMonTarget2.SectionCode) resList.Add("SectionCode");
            if (salesMonTarget1.TargetContrastCd != salesMonTarget2.TargetContrastCd) resList.Add("TargetContrastCd");
            if (salesMonTarget1.SalesDate != salesMonTarget2.SalesDate) resList.Add("SalesDate");
            if (salesMonTarget1.EmployeeCode != salesMonTarget2.EmployeeCode) resList.Add("EmployeeCode");
//----- ueno add---------- start 2007.11.21
			if (salesMonTarget1.EmployeeDivCd != salesMonTarget2.EmployeeDivCd) resList.Add("EmployeeDivCd");
			if (salesMonTarget1.SubSectionCode != salesMonTarget2.SubSectionCode) resList.Add("SubSectionCode");
			if (salesMonTarget1.MinSectionCode != salesMonTarget2.MinSectionCode) resList.Add("MinSectionCode");
			if (salesMonTarget1.BusinessTypeCode != salesMonTarget2.BusinessTypeCode) resList.Add("BusinessTypeCode");
			if (salesMonTarget1.SalesAreaCode != salesMonTarget2.SalesAreaCode) resList.Add("SalesAreaCode");
			if (salesMonTarget1.CustomerCode != salesMonTarget2.CustomerCode) resList.Add("CustomerCode");
//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//if (salesMonTarget1.SalesFormal != salesMonTarget2.SalesFormal) resList.Add("SalesFormal");
			//if (salesMonTarget1.SalesFormCode != salesMonTarget2.SalesFormCode) resList.Add("SalesFormCode");
			//if (salesMonTarget1.CarrierCode != salesMonTarget2.CarrierCode) resList.Add("CarrierCode");
			//if (salesMonTarget1.CellphoneModelCode != salesMonTarget2.CellphoneModelCode) resList.Add("CellphoneModelCode");
			//----- ueno del---------- end   2007.11.21
            if (salesMonTarget1.MakerCode != salesMonTarget2.MakerCode) resList.Add("MakerCode");
            if (salesMonTarget1.GoodsCode != salesMonTarget2.GoodsCode) resList.Add("GoodsCode");
            if (salesMonTarget1.SalesmonyTaxExc != salesMonTarget2.SalesmonyTaxExc) resList.Add("SalesmonyTaxExc");
            if (salesMonTarget1.Cost != salesMonTarget2.Cost) resList.Add("Cost");
			//----- ueno del---------- start 2007.11.21
			//if (salesMonTarget1.InsentiveRecv != salesMonTarget2.InsentiveRecv) resList.Add("InsentiveRecv");
			//if (salesMonTarget1.InsentiveDtbt != salesMonTarget2.InsentiveDtbt) resList.Add("InsentiveDtbt");
			//----- ueno del---------- end   2007.11.21
            if (salesMonTarget1.SalesCount != salesMonTarget2.SalesCount) resList.Add("SalesCount");

            return resList;
        }
        #endregion ◆　目標用売上実績データ比較結果リスト作成処理(TrgtCompSalesRslt,TrgtCompSalesRslt)

        #endregion Public Method

    }
}

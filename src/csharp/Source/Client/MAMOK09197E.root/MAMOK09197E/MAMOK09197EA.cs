using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:	 ExtrInfo_MAMOK09197EA
	/// <summary>
	/// 					 目標検索条件設定パラメータクラス
	/// </summary>
	/// <remarks>
	/// <br>note			 :	 目標検索条件設定パラメータファイル</br>
	/// <br>Programmer		 :	 NEPCO</br>
	/// <br>Date			 :	 </br>
	/// <br>Genarated Date	 :	 2007/05/08</br>
	/// <br>Update Note		 :   2007.11.21 上野 弘貴</br>
	/// <br>                     流通.DC用に変更（項目追加・削除）</br>
	/// <br></br>
	/// </remarks>
	[Serializable]
	public class ExtrInfo_MAMOK09197EA
	{
		#region Private Member

		/// <summary>企業コード</summary>
		private String _enterpriseCode = "";

		/// <summary>選択拠点コード</summary>
		private String[] _selectSectCd;

		/// <summary>目標設定区分</summary>
		private Int32 _targetSetCd;

		/// <summary>目標対比区分</summary>
		private Int32 _targetContrastCd;

		/// <summary>目標区分コード</summary>
		private String _targetDivideCode = "";

		/// <summary>目標区分名称</summary>
		private String _targetDivideName = "";

		/// <summary>適用開始日(開始)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _applyStaDateSt;

		/// <summary>適用開始日(終了)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _applyStaDateEd;

		/// <summary>適用終了日(開始)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _applyEndDateSt;

		/// <summary>適用終了日(終了)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _applyEndDateEd;

		/// <summary>従業員コード</summary>
		private String _employeeCode = "";

//----- ueno add---------- start 2007.11.21
		/// <summary>従業員区分</summary>
		private Int32 _employeeDivCd;

		/// <summary>部門コード</summary>
		private Int32 _subSectionCode;

		/// <summary>課コード</summary>
		private Int32 _minSectionCode;

		/// <summary>業種コード</summary>
		private Int32 _businessTypeCode;

        /// <summary>
        /// 業種名
        /// </summary>
        private string _businessTypeName;
        
		/// <summary>販売エリアコード</summary>
		private Int32 _salesAreaCode;

        /// <summary>
        /// 販売エリアコード
        /// </summary>
        private string _salesAreaName;

		/// <summary>得意先コード</summary>
		private Int32 _customerCode;
//----- ueno add---------- end   2007.11.21

		//----- ueno del---------- start 2007.11.21
		///// <summary>売上形式</summary>
		//private Int32 _salesFormal = -1;

		///// <summary>販売形態コード</summary>
		//private Int32 _salesFormCode = -1;

		///// <summary>キャリアコード</summary>
		//private Int32 _carrierCode = -1;

		///// <summary>機種コード</summary>
		//private string _cellphoneModelCode = "";
		//----- ueno del---------- end   2007.11.21

		//----- ueno upd---------- start 2007.11.21
		// -1設定を削除
		/// <summary>メーカーコード</summary>
		private Int32 _makerCode;
		//----- ueno upd---------- end   2007.11.21

		/// <summary>商品コード</summary>
		private String _goodsCode = "";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA ADD START
        // BLグループコード
        private Int32 _bLGroupCode;
        // BLグループ名
        private string _bLGroupName;
        // BLコード
        private Int32 _bLGoodsCode;
        // BLコード名
        private string _bLCodeName;
        // 販売区分
        private Int32 _salesCode;
        // 販売区分名
        private string _salesCdNm;
        // 商品区分
        private Int32 _enterpriseGanreCode;
        // 商品区分名
        private string _enterpriseGanreName;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA ADD END

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
		public String EnterpriseCode
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

		/// public propaty name  :	SelectSectCd
		/// <summary>選択拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 選択拠点コードプロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public String[] SelectSectCd
		{
			get
			{
				return _selectSectCd;
			}
			set
			{
				_selectSectCd = value;
			}
		}

		/// public propaty name  :	TargetSetCd
		/// <summary>目標設定区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 目標設定区分プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public Int32 TargetSetCd
		{
			get
			{
				return _targetSetCd;
			}
			set
			{
				_targetSetCd = value;
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

		/// public propaty name  :	TargetDivideCode
		/// <summary>目標区分コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 目標区分コードプロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public String TargetDivideCode
		{
			get
			{
				return _targetDivideCode;
			}
			set
			{
				_targetDivideCode = value;
			}
		}

		/// public propaty name  :	TargetDivideName
		/// <summary>目標区分名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 目標区分名称プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public String TargetDivideName
		{
			get
			{
				return _targetDivideName;
			}
			set
			{
				_targetDivideName = value;
			}
		}

		/// public propaty name  :	ApplyStaDateSt
		/// <summary>適用開始日(開始)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 適用開始日プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public DateTime ApplyStaDateSt
		{
			get
			{
				return _applyStaDateSt;
			}
			set
			{
				_applyStaDateSt = value;
			}
		}

		/// public propaty name  :	ApplyStaDateEd
		/// <summary>適用開始日(終了)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 適用開始日プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public DateTime ApplyStaDateEd
		{
			get
			{
				return _applyStaDateEd;
			}
			set
			{
				_applyStaDateEd = value;
			}
		}

		/// public propaty name  :	ApplyStaDateSt
		/// <summary>適用終了日(開始)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 適用開始日プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public DateTime ApplyEndDateSt
		{
			get
			{
				return _applyEndDateSt;
			}
			set
			{
				_applyEndDateSt = value;
			}
		}

		/// public propaty name  :	ApplyStaDateEd
		/// <summary>適用終了日(終了)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 適用開始日プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public DateTime ApplyEndDateEd
		{
			get
			{
				return _applyEndDateEd;
			}
			set
			{
				_applyEndDateEd = value;
			}
		}

		/// public propaty name  :	EmployeeCode
		/// <summary>従業員コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 従業員コードプロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public String EmployeeCode
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

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
        public string BusinessTypeName
        {
            get { return _businessTypeName; }
            set { this._businessTypeName = value; }
        }

        public string SalesAreaName
        {
            get { return _salesAreaName; }
            set { this._salesAreaName = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END
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
		//public Int32 SalesFormal
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
		//public Int32 SalesFormCode
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
		//----- ueno del---------- end 2007.11.21

		/// public propaty name  :	MakerCode
		/// <summary>メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 メーカーコードプロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public Int32 MakerCode
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
		public String GoodsCode
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

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { this._bLGroupCode = value; }
        }
        public string BLGroupName
        {
            get { return _bLGroupName; }
            set { this._bLGroupName = value; }
        }

        public Int32 BLCode
        {
            get { return _bLGoodsCode; }
            set { this._bLGoodsCode = value; }
        }

        public string BLCodeName
        {
            get { return _bLCodeName; }
            set { this._bLCodeName = value; }
        }

        public Int32 SalesTypeCode
        {
            get { return _salesCode; }
            set { this._salesCode = value; }
        }

        public string SalesTypeName
        {
            get { return _salesCdNm; }
            set { this._salesCdNm = value; }
        }

        public Int32 ItemTypeCode
        {
            get { return _enterpriseGanreCode; }
            set { this._enterpriseGanreCode = value; }
        }

        public string ItemTypeName
        {
            get { return _enterpriseGanreName; }
            set { this._enterpriseGanreName = value; }
        }

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END
		#endregion Public Propaty

		#region コンストラクタ
		/// <summary>
		/// 売上月間目標設定マスタ検索条件コンストラクタ
		/// </summary>
		/// <returns>ExtrInfo_MAMOK09197EAクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :	 ExtrInfo_MAMOK09197EAクラスの新しいインスタンスを生成します</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public ExtrInfo_MAMOK09197EA()
		{
		}


		/// <summary>
		/// 売上月間目標設定マスタ検索条件コンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="selectSectCd">選択拠点コード</param>
		/// <param name="targetSetCd">目標設定区分</param>
		/// <param name="targetContrastCd">目標対比区分</param>
		/// <param name="targetDivideCode">目標区分コード</param>
		/// <param name="targetDivideName">目標区分名称</param>
		/// <param name="applyStaDateSt">適用開始日(YYYYMMDD)</param>
		/// <param name="applyStaDateEd">適用開始日(YYYYMMDD)</param>
		/// <param name="applyEndDateSt">適用終了日(YYYYMMDD)</param>
		/// <param name="applyEndDateEd">適用終了日(YYYYMMDD)</param>
		/// <param name="employeeCode">従業員コード</param>
		/// <param name="employeeDivCd">従業員区分</param>
		/// <param name="subSectionCode">部門コード</param>
		/// <param name="minSectionCode">課コード</param>
		/// <param name="businessTypeCode">業種コード</param>
		/// <param name="salesAreaCode">販売エリアコード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="makerCode">メーカーコード</param>
		/// <param name="goodsCode">商品コード</param>
		/// <returns>ExtrInfo_MAMOK09197EAクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :	 ExtrInfo_MAMOK09197EAクラスの新しいインスタンスを生成します</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public ExtrInfo_MAMOK09197EA(
			String	 enterpriseCode,
			String[] selectSectCd,
			Int32	 targetSetCd,
			Int32	 targetContrastCd,
			String	 targetDivideCode,
			String	 targetDivideName,
			DateTime applyStaDateSt,
			DateTime applyStaDateEd,
			DateTime applyEndDateSt,
			DateTime applyEndDateEd,
			String	 employeeCode,
//----- ueno add---------- start 2007.11.21
			Int32 employeeDivCd,
			Int32 subSectionCode,
			Int32 minSectionCode,
			Int32 businessTypeCode,
			Int32 salesAreaCode,
			Int32 customerCode,
//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//Int32 salesFormal,
			//Int32	 salesFormCode,
			//Int32	 carrierCode,
			//String	 cellphoneModelCode,
			//----- ueno del---------- end   2007.11.21
			Int32	 makerCode,
			String	 goodsCode,
            String businessTypeName,
            String salesAreaName,
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
            Int32 blGroupCode,
            string blGroupName,
            Int32 blCode,
            string blCodeName,
            Int32 salesTypeCode,
            string salesTypeName,
            Int32 itemTypeCode,
            string itemTypeName
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END
		)
		{
			this._enterpriseCode   = enterpriseCode;
			this._selectSectCd	   = selectSectCd;
			this._targetSetCd	   = targetSetCd;
			this._targetContrastCd = targetContrastCd;
			this._targetDivideCode = targetDivideCode;
			this._targetDivideName = targetDivideName;
			this._applyStaDateSt   = applyStaDateSt;
			this._applyStaDateEd   = applyStaDateEd;
			this._applyEndDateSt   = applyEndDateSt;
			this._applyEndDateEd   = applyEndDateEd;
			this._employeeCode	   = employeeCode;
//----- ueno add---------- start 2007.11.21
			this._employeeDivCd	   = employeeDivCd;
			this._subSectionCode   = subSectionCode;
			this._minSectionCode   = minSectionCode;
			this._businessTypeCode = businessTypeCode;
			this._salesAreaCode    = salesAreaCode;
			this._customerCode     = customerCode;
//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//this._salesFormal = salesFormal;
			//this._salesFormCode    = salesFormCode;
			//this._carrierCode	   = carrierCode;
			//this._cellphoneModelCode = cellphoneModelCode;
			//----- ueno del---------- end   2007.11.21
			this._makerCode = makerCode;
			this._goodsCode 	   = goodsCode;
            this._businessTypeName = businessTypeName;
            this._salesAreaName = salesAreaName;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
            this._bLGroupCode = blGroupCode;
            this._bLGroupName = blGroupName;
            this._bLGoodsCode = blCode;
            this._bLCodeName = blCodeName;
            this._salesCode = salesTypeCode;
            this._salesCdNm = salesTypeName;
            this._enterpriseGanreCode = itemTypeCode;
            this._enterpriseGanreName = itemTypeName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END
		}

		#endregion コンストラクタ

		#region Public Method

		#region ◆　売上月間目標設定マスタ検索条件複製処理
		/// <summary>
		/// 売上月間目標設定マスタ検索条件複製処理
		/// </summary>
		/// <returns>ExtrInfo_MAMOK09197EAクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :	 自身の内容と等しいExtrInfo_MAMOK09197EAクラスのインスタンスを返します</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public ExtrInfo_MAMOK09197EA Clone()
		{
			return new ExtrInfo_MAMOK09197EA(
							   this._enterpriseCode,
							   this._selectSectCd,
							   this._targetSetCd,
							   this._targetContrastCd,
							   this._targetDivideCode,
							   this._targetDivideName,
							   this._applyStaDateSt,
							   this._applyStaDateEd,
							   this._applyEndDateSt,
							   this._applyEndDateEd,
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
                               this._businessTypeName,
                               this._salesAreaName,
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
                               this._bLGroupCode,
                               this._bLGroupName,
                               this._bLGoodsCode,
                               this._bLCodeName,
                               this._salesCode,
                               this._salesCdNm,
                               this._enterpriseGanreCode,
                               this._enterpriseGanreName
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END
							   );
		}
		#endregion ◆　売上月間目標設定マスタ検索条件複製処理

		#region ◆　売上月間目標設定マスタ検索条件比較処理(ExtrInfo_MAMOK09197EA)
		/// <summary>
		/// 売上月間目標設定マスタ検索条件比較処理
		/// </summary>
		/// <param name="target">比較対象のExtrInfo_MAMOK09197EAクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :	 ExtrInfo_MAMOK09197EAクラスの内容が一致するか比較します</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public bool Equals(ExtrInfo_MAMOK09197EA target)
		{
			return ((this.EnterpriseCode   == target.EnterpriseCode)
				 && (this.SelectSectCd	   == target.SelectSectCd)
				 && (this.TargetSetCd	   == target.TargetSetCd)
				 && (this.TargetContrastCd == target.TargetContrastCd)
				 && (this.TargetDivideCode == target.TargetDivideCode)
				 && (this.TargetDivideName == target.TargetDivideName)
				 && (this.ApplyStaDateSt   == target.ApplyStaDateSt)
				 && (this.ApplyStaDateEd   == target.ApplyStaDateEd)
				 && (this.ApplyEndDateSt   == target.ApplyEndDateSt)
				 && (this.ApplyEndDateEd   == target.ApplyEndDateEd)
				 && (this.EmployeeCode	   == target.EmployeeCode)
//----- ueno add---------- start 2007.11.21
				 && (this.EmployeeDivCd	   == target.EmployeeDivCd)
				 && (this.SubSectionCode   == target.SubSectionCode)
				 && (this.MinSectionCode   == target.MinSectionCode)
				 && (this.BusinessTypeCode == target.BusinessTypeCode)
				 && (this.SalesAreaCode    == target.SalesAreaCode)
				 && (this.CustomerCode     == target.CustomerCode)
//----- ueno add---------- end   2007.11.21
  			     //----- ueno del---------- start 2007.11.21
				 //&& (this.SalesFormCode == target.SalesFormCode)
				 //&& (this.CarrierCode	   == target.CarrierCode)
				 //&& (this.CellphoneModelCode == target.CellphoneModelCode)
				 //----- ueno del---------- end   2007.11.21
				 && (this.MakerCode 	   == target.MakerCode)
				 && (this.GoodsCode 	   == target.GoodsCode)
                 && (this.BusinessTypeName == target.BusinessTypeName)
                 && (this.SalesAreaName == target.SalesAreaName)
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
                 && (this.BLGroupCode == target.BLGroupCode)
                 && (this.BLGroupName == target.BLGroupName)
                 && (this.BLCode == target.BLCode)
                 && (this.BLCodeName == target.BLCodeName)
                 && (this.SalesTypeCode == target.SalesTypeCode)
                 && (this.SalesTypeName == target.SalesTypeName)
                 && (this.ItemTypeCode == target.ItemTypeCode)
                 && (this.ItemTypeName == target.ItemTypeName)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END
				 );
		}
		#endregion ◆　売上月間目標設定マスタ検索条件比較処理


		#endregion Public Method

	}
}

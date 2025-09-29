using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:	 ExtrInfo_MAMOK02121EA
	/// <summary>
	/// 					 目標売上対比表(印刷)抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note			 :	 目標売上対比表(印刷)抽出条件ファイル</br>
	/// <br>Programmer		 :	 NEPCO</br>
	/// <br>Date			 :	 </br>
	/// <br>Genarated Date	 :	 2007/05/08</br>
	/// <br>Update Note      :   2007/11/21 30167 上野　弘貴</br>
	/// <br>					 流通.DC用に変更（項目追加）</br>
	/// <br></br>
	/// </remarks>
	[Serializable]
	public class ExtrInfo_MAMOK02121EA
	{
		#region Public enum

		public enum MokuhyouReportMode
		{
			Section_Range,		// 拠点別(個別)
			Section_Month,		// 拠点別(月間)
			Employee_Range, 	// 従業員別(個別)
			Employee_Month, 	// 従業員別(月間)
			Goods_Range,		// 商品別(個別)
			Goods_Month,		// 商品別(月間)
			SalesFormal_Range,	// 売上形式別(個別)
			SalesFormal_Month,	// 売上形式別(月間)
			SalesForm_Range,	// 販売形態別(個別)
			SalesForm_Month 	// 販売形態別(月間)
		}

		public enum MoneyUnit
		{
			One = 0,
			Thousand = 1
		}

		#endregion Public enum

		#region Private Member

		/// <summary>企業コード</summary>
		private String _enterpriseCode = "";

		/// <summary>選択拠点コード</summary>
		private String[] _selectSectCd;

		/// <summary>拠点コード</summary>
		private String _sectionCode = "";

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

		/// <summary>売上確定日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _salesFixedDate;

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

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA ADD START
        /// <summary>業種名称</summary>
        private string _businessTypeName;

        /// <summary>販売エリア名称</summary>
        private string _salesAreaName;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA ADD END

		/// <summary>販売エリアコード</summary>
		private Int32 _salesAreaCode;

		/// <summary>得意先コード</summary>
		private Int32 _customerCode;
//----- ueno add---------- end   2007.11.21

		/// <summary>売上形式</summary>
		private Int32 _salesFormal = -1;

		/// <summary>販売形態コード</summary>
		private Int32 _salesFormCode = -1;

		/// <summary>キャリアコード</summary>
		private Int32 _carrierCode = -1;

		/// <summary>機種コード</summary>
		private String _cellphoneModelCode = "";

		/// <summary>メーカーコード</summary>
		private Int32 _makerCode = -1;

		/// <summary>商品コード</summary>
		private String _goodsCode = "";

		/// <summary>ソート順</summary>
		private Int32 _sortingOrder = 0;

		/// <summary>出力帳票フラグ</summary>
		private MokuhyouReportMode _outputMode = MokuhyouReportMode.Section_Range;

		/// <summary>拠点名</summary>
		private String _sectionName = "";

		/// <summary>従業員名</summary>
		private String _employeeName = "";

		/// <summary>売上形式名称</summary>
		private String _salesFormalName = "";

		/// <summary>販売形態名称</summary>
		private String _salesFormName = "";

		/// <summary>メーカー名称</summary>
		private String _makerName = "";

		/// <summary>商品名称</summary>
		private String _goodsName = "";

		/// <summary>売上表示フラグ</summary>
		private Boolean _view_Sales = true;

		/// <summary>粗利表示フラグ</summary>
		private Boolean _view_Profit = true;

		/// <summary>数量表示フラグ</summary>
		private Boolean _view_Count = true;

		/// <summary>金額単位</summary>
		/// <remarks>0:円,1:千円</remarks>
		private MoneyUnit _dispMoneyUnit = MoneyUnit.One;

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

		/// public propaty name  :	SectionCode
		/// <summary>拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 拠点コードプロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public String SectionCode
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
		/// <br>note			 :	 適用開始日(開始)プロパティ</br>
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
		/// <br>note			 :	 適用開始日(終了)プロパティ</br>
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
		/// <br>note			 :	 適用終了日(開始)プロパティ</br>
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
		/// <br>note			 :	 適用終了日(終了)プロパティ</br>
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

		/// public propaty name  :	SalesFixedDate
		/// <summary>売上確定日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 売上確定日プロパティ(進捗率,着地計算用)</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public DateTime SalesFixedDate
		{
			get
			{
				return _salesFixedDate;
			}
			set
			{
				_salesFixedDate = value;
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
//----- ueno add---------- end   2007.11.21

		/// public propaty name  :	SalesFormal
		/// <summary>売上形式プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 売上形式プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public Int32 SalesFormal
		{
			get
			{
				return _salesFormal;
			}
			set
			{
				_salesFormal = value;
			}
		}

		/// public propaty name  :	SalesFormCode
		/// <summary>販売形態コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 販売形態コードプロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public Int32 SalesFormCode
		{
			get
			{
				return _salesFormCode;
			}
			set
			{
				_salesFormCode = value;
			}

		}

		/// public propaty name  :	CarrierCode
		/// <summary>キャリアコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 従業員コードプロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public Int32 CarrierCode
		{
			get
			{
				return _carrierCode;
			}
			set
			{
				_carrierCode = value;
			}
		}

		/// public propaty name  :	CellphoneModelCode
		/// <summary>機種コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 機種コードプロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public string CellphoneModelCode
		{
			get
			{
				return _cellphoneModelCode;
			}
			set
			{
				_cellphoneModelCode = value;
			}
		}

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

		/// public propaty name  :	SortingOrder
		/// <summary>ソート順プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 ソート順プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public Int32 SortingOrder
		{
			get
			{
				return _sortingOrder;
			}
			set
			{
				_sortingOrder = value;
			}
		}

		/// public propaty name  :	MokuhyouReportMode
		/// <summary>出力帳票フラグ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 出力帳票フラグプロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public MokuhyouReportMode OutputMode
		{
			get
			{
				return _outputMode;
			}
			set
			{
				_outputMode = value;
			}
		}

		/// public propaty name  :	SectionName
		/// <summary>拠点名プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 拠点名プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public String SectionName
		{
			get
			{
				return _sectionName;
			}
			set
			{
				_sectionName = value;
			}
		}

		/// public propaty name  :	EmployeeName
		/// <summary>従業員名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 従業員名称プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public String EmployeeName
		{
			get
			{
				return _employeeName;
			}
			set
			{
				_employeeName = value;
			}
		}

		/// public propaty name  :	SalesFormalName
		/// <summary>売上形式名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 売上形式名称プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public String SalesFormalName
		{
			get
			{
				return _salesFormalName;
			}
			set
			{
				_salesFormalName = value;
			}

		}

		/// public propaty name  :	SalesFormName
		/// <summary>販売形態名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 販売形態名称プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public String SalesFormName
		{
			get
			{
				return _salesFormName;
			}
			set
			{
				_salesFormName = value;
			}

		}

		/// public propaty name  :	MakerName
		/// <summary>メーカー名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 メーカー名称プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public String MakerName
		{
			get
			{
				return _makerName;
			}
			set
			{
				_makerName = value;
			}
		}

		/// public propaty name  :	GoodsName
		/// <summary>商品名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 商品名称プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public String GoodsName
		{
			get
			{
				return _goodsName;
			}
			set
			{
				_goodsName = value;
			}
		}

		/// public propaty name  :	View_Sales
		/// <summary>売上表示フラグ</summary>
		/// <value>0:非表示,1:表示</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 売上表示プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public Boolean View_Sales
		{
			get
			{
				return _view_Sales;
			}
			set
			{
				_view_Sales = value;
			}
		}

		/// public propaty name  :	View_Profit
		/// <summary>粗利表示フラグ</summary>
		/// <value>0:非表示,1:表示</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 粗利表示プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public Boolean View_Profit
		{
			get
			{
				return _view_Profit;
			}
			set
			{
				_view_Profit = value;
			}
		}

		/// public propaty name  :	View_Count
		/// <summary>数量表示フラグ</summary>
		/// <value>0:非表示,1:表示</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 数量表示プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public Boolean View_Count
		{
			get
			{
				return _view_Count;
			}
			set
			{
				_view_Count = value;
			}
		}

		/// public propaty name  :	DispMoneyUnit
		/// <summary>金額単位</summary>
		/// <value>0:円,1:千円</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 金額単位プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public MoneyUnit DispMoneyUnit
		{
			get
			{
				return _dispMoneyUnit;
			}
			set
			{
				_dispMoneyUnit = value;
			}
		}
        
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA ADD START
        public string BusinessTypeName
        {
            get { return this._businessTypeName; }
            set { this._businessTypeName = value; }
        }

        public string SalesAreaName
        {
            get { return this._salesAreaName; }
            set { this._salesAreaName = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA ADD END

		#endregion Public Propaty

		#region コンストラクタ
		/// <summary>
		/// 売上月間目標設定マスタ検索条件コンストラクタ
		/// </summary>
		/// <returns>ExtrInfo_MAMOK02121EAクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :	 ExtrInfo_MAMOK02121EAクラスの新しいインスタンスを生成します</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public ExtrInfo_MAMOK02121EA()
		{
		}


		/// <summary>
		/// 売上月間目標設定マスタ検索条件コンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="selectSectCd">選択拠点コード</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="targetSetCd">目標設定区分</param>
		/// <param name="targetContrastCd">目標対比区分</param>
		/// <param name="targetDivideCode">目標区分コード</param>
		/// <param name="targetDivideName">目標区分名称</param>
		/// <param name="applyStaDateSt">適用開始日(YYYYMMDD)</param>
		/// <param name="applyStaDateEd">適用開始日(YYYYMMDD)</param>
		/// <param name="applyEndDateSt">適用終了日(YYYYMMDD)</param>
		/// <param name="applyEndDateEd">適用終了日(YYYYMMDD)</param>
		/// <param name="salesFixedDate">売上確定日(YYYYMMDD)</param>
		/// <param name="employeeCode">従業員コード</param>
		/// <param name="employeeDivCd">従業員区分</param>
		/// <param name="subSectionCode">部門コード</param>
		/// <param name="minSectionCode">課コード</param>
		/// <param name="businessTypeCode">業種コード</param>
		/// <param name="salesAreaCode">販売エリアコード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="salesFormal">売上形式</param>
		/// <param name="salesFormCode">販売形態コード</param>
		/// <param name="makerCode">メーカーコード</param>
		/// <param name="goodsCode">商品コード</param>
		/// <param name="sortingOrder">ソート順</param>
		/// <param name="outputMode">出力帳票フラグ</param>
		/// <param name="sectionName">拠点名</param>
		/// <param name="employeeName">従業員名称</param>
		/// <param name="salesFormalName">売上形式名称</param>
		/// <param name="salesFormName">販売形態名称</param>
		/// <param name="CarrierCode">キャリアコード</param>
		/// <param name="CellphoneModelCode">機種コード</param>
		/// <param name="makerName">メーカー名称</param>
		/// <param name="goodsName">商品名称</param>
		/// <param name="view_Sales">売上表示フラグ</param>
		/// <param name="view_Profit">粗利表示フラグ</param>
		/// <param name="view_Count">数量表示フラグ</param>
		/// <param name="dispMoneyUnit">金額単位</param>
		/// <returns>ExtrInfo_MAMOK02121EAクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :	 ExtrInfo_MAMOK02121EAクラスの新しいインスタンスを生成します</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public ExtrInfo_MAMOK02121EA(
			String enterpriseCode,
			String[] selectSectCd,
			String sectionCode,
			Int32 targetSetCd,
			Int32 targetContrastCd,
			String targetDivideCode,
			String targetDivideName,
			DateTime applyStaDateSt,
			DateTime applyStaDateEd,
			DateTime applyEndDateSt,
			DateTime applyEndDateEd,
			DateTime salesFixedDate,
			String employeeCode,
//----- ueno add---------- start 2007.11.21
			Int32 employeeDivCd,
			Int32 subSectionCode,
			Int32 minSectionCode,
			Int32 businessTypeCode,
			Int32 salesAreaCode,
			Int32 customerCode,
//----- ueno add---------- end   2007.11.21
			Int32 salesFormal,
			Int32 salesFormCode,
			Int32 makerCode,
			String goodsCode,
			Int32 sortingOrder,
			MokuhyouReportMode outputMode,
			String sectionName,
			String employeeName,
			String salesFormalName,
			String salesFormName,
			Int32 carrierCode,
			String cellphoneModelCode,
			String makerName,
			String goodsName,
			Boolean view_Sales,
			Boolean view_Profit,
			Boolean view_Count,
			MoneyUnit dispMoneyUnit,
            String businessTypeName,
            String salesAreaName
		)
		{
			this._enterpriseCode = enterpriseCode;
			this._selectSectCd = selectSectCd;
			this._sectionCode = sectionCode;
			this._targetSetCd = targetSetCd;
			this._targetContrastCd = targetContrastCd;
			this._targetDivideCode = targetDivideCode;
			this._targetDivideName = targetDivideName;
			this._applyStaDateSt = applyStaDateSt;
			this._applyStaDateEd = applyStaDateEd;
			this._applyEndDateSt = applyEndDateSt;
			this._applyEndDateEd = applyEndDateEd;
			this._salesFixedDate = salesFixedDate;
			this._employeeCode = employeeCode;
//----- ueno add---------- start 2007.11.21
			this._employeeDivCd = employeeDivCd;
			this._subSectionCode = subSectionCode;
			this._minSectionCode = minSectionCode;
			this._businessTypeCode = businessTypeCode;
			this._salesAreaCode = salesAreaCode;
			this._customerCode = customerCode;
//----- ueno add---------- end   2007.11.21
			this._salesFormal = salesFormal;
			this._salesFormCode = salesFormCode;
			this._makerCode = makerCode;
			this._goodsCode = goodsCode;
			this._sortingOrder = sortingOrder;
			this._outputMode = outputMode;
			this._sectionCode = sectionCode;
			this._employeeName = employeeName;
			this._salesFormalName = salesFormalName;
			this._salesFormName = salesFormName;
			this._carrierCode = carrierCode;
			this._cellphoneModelCode = cellphoneModelCode;
			this._makerName = makerName;
			this._goodsName = goodsName;
			this._view_Sales = view_Sales;
			this._view_Profit = view_Profit;
			this._view_Count = view_Count;
			this._dispMoneyUnit = dispMoneyUnit;
            this._businessTypeName = businessTypeName;
            this._salesAreaName = salesAreaName;
		}

		#endregion コンストラクタ

		#region Public Method

		#region ◆　売上月間目標設定マスタ検索条件複製処理
		/// <summary>
		/// 売上月間目標設定マスタ検索条件複製処理
		/// </summary>
		/// <returns>ExtrInfo_MAMOK02121EAクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :	 自身の内容と等しいExtrInfo_MAMOK02121EAクラスのインスタンスを返します</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public ExtrInfo_MAMOK02121EA Clone()
		{
			return new ExtrInfo_MAMOK02121EA(
							   this._enterpriseCode,
							   this._selectSectCd,
							   this._sectionCode,
							   this._targetSetCd,
							   this._targetContrastCd,
							   this._targetDivideCode,
							   this._targetDivideName,
							   this._applyStaDateSt,
							   this._applyStaDateEd,
							   this._applyEndDateSt,
							   this._applyEndDateEd,
							   this._salesFixedDate,
							   this._employeeCode,
//----- ueno add---------- start 2007.11.21
							   this._employeeDivCd,
							   this._subSectionCode,
							   this._minSectionCode,
							   this._businessTypeCode,
							   this._salesAreaCode,
							   this._customerCode,
//----- ueno add---------- end   2007.11.21
							   this._salesFormal,
							   this._salesFormCode,
							   this._makerCode,
							   this._goodsCode,
							   this._sortingOrder,
							   this._outputMode,
							   this._sectionName,
							   this._employeeName,
							   this._salesFormalName,
							   this._salesFormName,
							   this._carrierCode,
							   this._cellphoneModelCode,
							   this._makerName,
							   this._goodsName,
							   this._view_Sales,
							   this._view_Profit,
							   this._view_Count,
							   this._dispMoneyUnit,
                               this._businessTypeName,
                               this._salesAreaName
							   );
		}
		#endregion ◆　売上月間目標設定マスタ検索条件複製処理

		#region ◆　売上月間目標設定マスタ検索条件比較処理(ExtrInfo_MAMOK02121EA)
		/// <summary>
		/// 売上月間目標設定マスタ検索条件比較処理
		/// </summary>
		/// <param name="target">比較対象のExtrInfo_MAMOK02121EAクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :	 ExtrInfo_MAMOK02121EAクラスの内容が一致するか比較します</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public bool Equals(ExtrInfo_MAMOK02121EA target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SelectSectCd == target.SelectSectCd)
				 && (this.SectionCode == target.SectionCode)
				 && (this.TargetSetCd == target.TargetSetCd)
				 && (this.TargetContrastCd == target.TargetContrastCd)
				 && (this.TargetDivideCode == target.TargetDivideCode)
				 && (this.TargetDivideName == target.TargetDivideName)
				 && (this.ApplyStaDateSt == target.ApplyStaDateSt)
				 && (this.ApplyStaDateEd == target.ApplyStaDateEd)
				 && (this.ApplyEndDateSt == target.ApplyEndDateSt)
				 && (this.ApplyEndDateEd == target.ApplyEndDateEd)
				 && (this.SalesFixedDate == target.SalesFixedDate)
				 && (this.EmployeeCode == target.EmployeeCode)
//----- ueno add---------- start 2007.11.21
				 && (this.EmployeeDivCd == target.EmployeeDivCd)
				 && (this.SubSectionCode == target.SubSectionCode)
				 && (this.MinSectionCode == target.MinSectionCode)
				 && (this.BusinessTypeCode == target.BusinessTypeCode)
				 && (this.SalesAreaCode == target.SalesAreaCode)
				 && (this.CustomerCode == target.CustomerCode)
//----- ueno add---------- end   2007.11.21
				 && (this.SalesFormCode == target.SalesFormCode)
				 && (this.MakerCode == target.MakerCode)
				 && (this.GoodsCode == target.GoodsCode)
				 && (this.SortingOrder == target.SortingOrder)
				 && (this.OutputMode == target.OutputMode)
				 && (this.SectionName == target.SectionName)
				 && (this.EmployeeName == target.EmployeeName)
				 && (this.SalesFormalName == target.SalesFormalName)
				 && (this.SalesFormName == target.SalesFormName)
				 && (this.CarrierCode == target.CarrierCode)
				 && (this.CellphoneModelCode == target.CellphoneModelCode)
				 && (this.MakerName == target.MakerName)
				 && (this.GoodsName == target.GoodsName)
				 && (this.View_Sales == target.View_Sales)
				 && (this.View_Profit == target.View_Profit)
				 && (this.View_Count == target.View_Count)
				 && (this.DispMoneyUnit == target.DispMoneyUnit)
                 && (this.BusinessTypeName == target.BusinessTypeName)
                 && (this.SalesAreaName == target.SalesAreaName)
                 );
		}
		#endregion ◆　売上月間目標設定マスタ検索条件比較処理

		#endregion Public Method

	}
}

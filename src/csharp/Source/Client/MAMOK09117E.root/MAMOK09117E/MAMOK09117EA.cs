using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:	 ExtrInfo_MAMOK09117EA
	/// <summary>
	/// 					 従業員別売上目標検索条件設定パラメータクラス
	/// </summary>
	/// <remarks>
	/// <br>note			 :	 従業員別売上目標検索条件設定パラメータファイル</br>
	/// <br>Programmer		 :	 NEPCO</br>
	/// <br>Date			 :	 </br>
	/// <br>Genarated Date	 :	 2007/05/08</br>
	/// <br>Update Note      :   2007.11.21 上野 弘貴</br>
	/// <br>                     従業員別売上目標設定マスタ修正（項目の追加・削除）</br>
	/// <br></br>
	/// </remarks>
	[Serializable]
	public class ExtrInfo_MAMOK09117EA
	{
		#region Private Member

		/// <summary>企業コード</summary>
		private String _enterpriseCode = "";

		/// <summary>選択拠点コード</summary>
		private String[] _selectSectCd;

		/// <summary>全社選択</summary>
		private Boolean _allSecSelEpUnit;

		/// <summary>全拠点レコード出力</summary>
		private Boolean _allSecSelSecUnit;

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

		//----- ueno add---------- start 2007.11.21
		/// <summary>従業員区分</summary>
		private Int32 _employeeDivCd;
		//----- ueno add---------- end   2007.11.21

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>部門コード</summary>
        private Int32 _subSectionCode;

        /// <summary>課コード</summary>
        private Int32 _minSectionCode;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        /// <summary>従業員コード</summary>
		private String _employeeCode = "";

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

		/// public propaty name  :	AllSecSelEpUnit
		/// <summary>全社選択プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 全社選択プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public Boolean AllSecSelEpUnit
		{
			get
			{
				return _allSecSelEpUnit;
			}
			set
			{
				_allSecSelEpUnit = value;
			}
		}

		/// public propaty name  :	AllSecSelSecUnit
		/// <summary>全拠点レコード出力プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 全拠点レコード出力プロパティ</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public Boolean AllSecSelSecUnit
		{
			get
			{
				return _allSecSelSecUnit;
			}
			set
			{
				_allSecSelSecUnit = value;
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
		//----- ueno add---------- end   2007.11.21

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// public propaty name  :	SubSectionCode
        /// <summary>部門コードプロパティ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 部門コード</br>
        /// <br>Programer		 :	 22018 鈴木 正臣</br>
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
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note			 :	 課コード</br>
        /// <br>Programer		 :	 22018 鈴木 正臣</br>
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
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        #endregion Public Propaty

		#region コンストラクタ
		/// <summary>
		/// 売上月間目標設定マスタ検索条件コンストラクタ
		/// </summary>
		/// <returns>ExtrInfo_MAMOK09157EAクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :	 ExtrInfo_MAMOK09157EAクラスの新しいインスタンスを生成します</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public ExtrInfo_MAMOK09117EA()
		{
		}


		/// <summary>
		/// 売上月間目標設定マスタ検索条件コンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="selectSectCd">選択拠点コード</param>
		/// <param name="allSecSelEpUnit">全社選択</param>
		/// <param name="allSecSelSecUnit">全拠点レコード出力</param>
		/// <param name="targetSetCd">目標設定区分</param>
		/// <param name="targetContrastCd">目標対比区分</param>
		/// <param name="targetDivideCode">目標区分コード</param>
		/// <param name="targetDivideName">目標区分名称</param>
		/// <param name="applyStaDateSt">適用開始日(YYYYMMDD)</param>
		/// <param name="applyStaDateEd">適用開始日(YYYYMMDD)</param>
		/// <param name="applyEndDateSt">適用終了日(YYYYMMDD)</param>
		/// <param name="applyEndDateEd">適用終了日(YYYYMMDD)</param>
		/// <param name="employeeDivCd">従業員区分</param>
		/// <param name="subSectionCode">部門コード</param>
        /// <param name="minSectionCode">課コード</param>
        /// <param name="employeeCode">従業員コード</param>
		/// <returns>ExtrInfo_MAMOK09157EAクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :	 ExtrInfo_MAMOK09157EAクラスの新しいインスタンスを生成します</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public ExtrInfo_MAMOK09117EA(
			String enterpriseCode,
			String[] selectSectCd,
			Boolean allSecSelEpUnit,
			Boolean allSecSelSecUnit,
			Int32 targetSetCd,
			Int32 targetContrastCd,
			String targetDivideCode,
			String targetDivideName,
			DateTime applyStaDateSt,
			DateTime applyStaDateEd,
			DateTime applyEndDateSt,
			DateTime applyEndDateEd,
			//----- ueno add---------- start 2007.11.21
			Int32 employeeDivCd,
			//----- ueno add---------- end   2007.11.21
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            Int32 subSectionCode,
            Int32 minSectionCode,
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
			String employeeCode
		)
		{
			this._enterpriseCode = enterpriseCode;
			this._selectSectCd = selectSectCd;
			this._allSecSelEpUnit = allSecSelEpUnit;
			this._allSecSelSecUnit = allSecSelSecUnit;
			this._targetSetCd = targetSetCd;
			this._targetContrastCd = targetContrastCd;
			this._targetDivideCode = targetDivideCode;
			this._targetDivideName = targetDivideName;
			this._applyStaDateSt = applyStaDateSt;
			this._applyStaDateEd = applyStaDateEd;
			this._applyEndDateSt = applyEndDateSt;
			this._applyEndDateEd = applyEndDateEd;
			//----- ueno add---------- start 2007.11.21
			this._employeeDivCd = employeeDivCd;
			//----- ueno add---------- end   2007.11.21
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._subSectionCode = subSectionCode;
            this._minSectionCode = minSectionCode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._employeeCode = employeeCode;
		}

		#endregion コンストラクタ

		#region Public Method

		/// <summary>
		/// 売上月間目標設定マスタ検索条件複製処理
		/// </summary>
		/// <returns>ExtrInfo_MAMOK09157EAクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :	 自身の内容と等しいExtrInfo_MAMOK09157EAクラスのインスタンスを返します</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public ExtrInfo_MAMOK09117EA Clone()
		{
			return new ExtrInfo_MAMOK09117EA(
							   this._enterpriseCode,
							   this._selectSectCd,
							   this._allSecSelEpUnit,
							   this._allSecSelSecUnit,
							   this._targetSetCd,
							   this._targetContrastCd,
							   this._targetDivideCode,
							   this._targetDivideName,
							   this._applyStaDateSt,
							   this._applyStaDateEd,
							   this._applyEndDateSt,
							   this._applyEndDateEd,
							   //----- ueno add---------- start 2007.11.21
							   this._employeeDivCd,
							   //----- ueno add---------- end   2007.11.21
                               // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                               this._subSectionCode,
                               this._minSectionCode,
                               // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                               this._employeeCode
							   );
		}

		/// <summary>
		/// 売上月間目標設定マスタ検索条件比較処理
		/// </summary>
		/// <param name="target">比較対象のExtrInfo_MAMOK09157EAクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :	 ExtrInfo_MAMOK09157EAクラスの内容が一致するか比較します</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public bool Equals(ExtrInfo_MAMOK09117EA target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SelectSectCd == target.SelectSectCd)
				 && (this.AllSecSelEpUnit == target.AllSecSelEpUnit)
				 && (this.AllSecSelSecUnit == target.AllSecSelSecUnit)
				 && (this.TargetSetCd == target.TargetSetCd)
				 && (this.TargetContrastCd == target.TargetContrastCd)
				 && (this.TargetDivideCode == target.TargetDivideCode)
				 && (this.TargetDivideName == target.TargetDivideName)
				 && (this.ApplyStaDateSt == target.ApplyStaDateSt)
				 && (this.ApplyStaDateEd == target.ApplyStaDateEd)
				 && (this.ApplyEndDateSt == target.ApplyEndDateSt)
				 && (this.ApplyEndDateEd == target.ApplyEndDateEd)
				 //----- ueno add---------- start 2007.11.21
				 && (this.EmployeeDivCd == target.EmployeeDivCd)
				//----- ueno add---------- end   2007.11.21
                 // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                 && (this.SubSectionCode == target.SubSectionCode)
                 && (this.MinSectionCode == target.MinSectionCode)
                 // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                 && (this.EmployeeCode == target.EmployeeCode)
				 );
		}

		#endregion Public Method

	}
}

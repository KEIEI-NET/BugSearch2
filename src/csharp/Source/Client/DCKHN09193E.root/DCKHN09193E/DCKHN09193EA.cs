using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:	 ExtrInfo_DCKHN09193EA
	/// <summary>
	/// 					 得意先別売上目標検索条件設定パラメータクラス
	/// </summary>
	/// <remarks>
	/// <br>note			 :	 得意先別売上目標検索条件設定パラメータファイル</br>
	/// <br>Programmer		 :	 30167 上野　弘貴</br>
	/// <br>Date			 :	 </br>
	/// <br>Genarated Date	 :	 2007/11/21</br>
	/// <br>Update Note 	 :	 </br>
	/// <br></br>
	/// </remarks>
	[Serializable]
	public class ExtrInfo_DCKHN09193EA
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

		/// <summary>業種コード</summary>
		private Int32 _businessTypeCode;

		/// <summary>販売エリアコード</summary>
		private Int32 _salesAreaCode;

		/// <summary>得意先コード</summary>
		private Int32 _customerCode;

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

		#endregion Private Member

		#region Public Propaty

		/// public propaty name  :	EnterpriseCode
		/// <summary>企業コードプロパティ</summary>
		/// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 企業コードプロパティ</br>
		/// <br>Programer		 :	 30167 上野　弘貴</br>
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
		/// <br>Programer		 :	 30167 上野　弘貴</br>
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
		/// <br>Programer		 :	 30167 上野　弘貴</br>
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
		/// <br>Programer		 :	 30167 上野　弘貴</br>
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
		/// <br>Programer		 :	 30167 上野　弘貴</br>
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
		/// <br>Programer		 :	 30167 上野　弘貴</br>
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
		/// <br>Programer		 :	 30167 上野　弘貴</br>
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
		/// <br>Programer		 :	 30167 上野　弘貴</br>
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

		/// public propaty name  :	ApplyStaDateSt
		/// <summary>適用開始日(開始)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 適用開始日プロパティ</br>
		/// <br>Programer		 :	 30167 上野　弘貴</br>
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
		/// <br>Programer		 :	 30167 上野　弘貴</br>
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
		/// <br>Programer		 :	 30167 上野　弘貴</br>
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
		/// <br>Programer		 :	 30167 上野　弘貴</br>
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

		#endregion Public Propaty

		#region コンストラクタ
		/// <summary>
		/// 売上月間目標設定マスタ検索条件コンストラクタ
		/// </summary>
		/// <returns>ExtrInfo_MAMOK09157EAクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :	 ExtrInfo_DCKHN09193EAクラスの新しいインスタンスを生成します</br>
		/// <br>Programer		 :	 30167 上野　弘貴</br>
		/// </remarks>
		public ExtrInfo_DCKHN09193EA()
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
		/// <param name="businessTypeCode">業種コード</param>
		/// <param name="salesAreaCode">販売エリアコード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="applyStaDateSt">適用開始日(YYYYMMDD)</param>
		/// <param name="applyStaDateEd">適用開始日(YYYYMMDD)</param>
		/// <param name="applyEndDateSt">適用終了日(YYYYMMDD)</param>
		/// <param name="applyEndDateEd">適用終了日(YYYYMMDD)</param>
		/// <returns>ExtrInfo_DCKHN09193EAクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :	 ExtrInfo_DCKHN09193EAクラスの新しいインスタンスを生成します</br>
		/// <br>Programer		 :	 30167 上野　弘貴</br>
		/// </remarks>
		public ExtrInfo_DCKHN09193EA(
			String enterpriseCode,
			String[] selectSectCd,
			Boolean allSecSelEpUnit,
			Boolean allSecSelSecUnit,
			Int32 targetSetCd,
			Int32 targetContrastCd,
			String targetDivideCode,
			String targetDivideName,
			Int32 businessTypeCode,
			Int32 salesAreaCode,
			Int32 customerCode,
			DateTime applyStaDateSt,
			DateTime applyStaDateEd,
			DateTime applyEndDateSt,
			DateTime applyEndDateEd
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
			this._businessTypeCode = businessTypeCode;
			this._salesAreaCode = salesAreaCode;
			this._customerCode = customerCode;
			this._applyStaDateSt = applyStaDateSt;
			this._applyStaDateEd = applyStaDateEd;
			this._applyEndDateSt = applyEndDateSt;
			this._applyEndDateEd = applyEndDateEd;
		}

		#endregion コンストラクタ

		#region Public Method

		/// <summary>
		/// 売上月間目標設定マスタ検索条件複製処理
		/// </summary>
		/// <returns>ExtrInfo_DCKHN09193EAクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :	 自身の内容と等しいExtrInfo_DCKHN09193EAクラスのインスタンスを返します</br>
		/// <br>Programer		 :	 30167 上野　弘貴</br>
		/// </remarks>
		public ExtrInfo_DCKHN09193EA Clone()
		{
			return new ExtrInfo_DCKHN09193EA(
							   this._enterpriseCode,
							   this._selectSectCd,
							   this._allSecSelEpUnit,
							   this._allSecSelSecUnit,
							   this._targetSetCd,
							   this._targetContrastCd,
							   this._targetDivideCode,
							   this._targetDivideName,
							   this._businessTypeCode,
							   this._salesAreaCode,
							   this._customerCode,
							   this._applyStaDateSt,
							   this._applyStaDateEd,
							   this._applyEndDateSt,
							   this._applyEndDateEd
							   );
		}

		/// <summary>
		/// 売上月間目標設定マスタ検索条件比較処理
		/// </summary>
		/// <param name="target">比較対象のExtrInfo_DCKHN09193EAクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :	 ExtrInfo_DCKHN09193EAクラスの内容が一致するか比較します</br>
		/// <br>Programer		 :	 30167 上野　弘貴</br>
		/// </remarks>
		public bool Equals(ExtrInfo_DCKHN09193EA target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SelectSectCd == target.SelectSectCd)
				 && (this.AllSecSelEpUnit == target.AllSecSelEpUnit)
				 && (this.AllSecSelSecUnit == target.AllSecSelSecUnit)
				 && (this.TargetSetCd == target.TargetSetCd)
				 && (this.TargetContrastCd == target.TargetContrastCd)
				 && (this.TargetDivideCode == target.TargetDivideCode)
				 && (this.TargetDivideName == target.TargetDivideName)
				 && (this.BusinessTypeCode == target.BusinessTypeCode)
				 && (this.SalesAreaCode == target.SalesAreaCode)
				 && (this.CustomerCode == target.CustomerCode)
				 && (this.ApplyStaDateSt == target.ApplyStaDateSt)
				 && (this.ApplyStaDateEd == target.ApplyStaDateEd)
				 && (this.ApplyEndDateSt == target.ApplyEndDateSt)
				 && (this.ApplyEndDateEd == target.ApplyEndDateEd)
				 );
		}

		#endregion Public Method

	}
}

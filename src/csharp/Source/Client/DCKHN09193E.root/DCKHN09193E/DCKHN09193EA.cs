using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:	 ExtrInfo_DCKHN09193EA
	/// <summary>
	/// 					 ���Ӑ�ʔ���ڕW���������ݒ�p�����[�^�N���X
	/// </summary>
	/// <remarks>
	/// <br>note			 :	 ���Ӑ�ʔ���ڕW���������ݒ�p�����[�^�t�@�C��</br>
	/// <br>Programmer		 :	 30167 ���@�O�M</br>
	/// <br>Date			 :	 </br>
	/// <br>Genarated Date	 :	 2007/11/21</br>
	/// <br>Update Note 	 :	 </br>
	/// <br></br>
	/// </remarks>
	[Serializable]
	public class ExtrInfo_DCKHN09193EA
	{
		#region Private Member

		/// <summary>��ƃR�[�h</summary>
		private String _enterpriseCode = "";

		/// <summary>�I�����_�R�[�h</summary>
		private String[] _selectSectCd;

		/// <summary>�S�БI��</summary>
		private Boolean _allSecSelEpUnit;

		/// <summary>�S���_���R�[�h�o��</summary>
		private Boolean _allSecSelSecUnit;

		/// <summary>�ڕW�ݒ�敪</summary>
		private Int32 _targetSetCd;

		/// <summary>�ڕW�Δ�敪</summary>
		private Int32 _targetContrastCd;

		/// <summary>�ڕW�敪�R�[�h</summary>
		private String _targetDivideCode = "";

		/// <summary>�ڕW�敪����</summary>
		private String _targetDivideName = "";

		/// <summary>�Ǝ�R�[�h</summary>
		private Int32 _businessTypeCode;

		/// <summary>�̔��G���A�R�[�h</summary>
		private Int32 _salesAreaCode;

		/// <summary>���Ӑ�R�[�h</summary>
		private Int32 _customerCode;

		/// <summary>�K�p�J�n��(�J�n)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _applyStaDateSt;

		/// <summary>�K�p�J�n��(�I��)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _applyStaDateEd;

		/// <summary>�K�p�I����(�J�n)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _applyEndDateSt;

		/// <summary>�K�p�I����(�I��)</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _applyEndDateEd;

		#endregion Private Member

		#region Public Propaty

		/// public propaty name  :	EnterpriseCode
		/// <summary>��ƃR�[�h�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 ��ƃR�[�h�v���p�e�B</br>
		/// <br>Programer		 :	 30167 ���@�O�M</br>
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
		/// <summary>�I�����_�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 �I�����_�R�[�h�v���p�e�B</br>
		/// <br>Programer		 :	 30167 ���@�O�M</br>
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
		/// <summary>�S�БI���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 �S�БI���v���p�e�B</br>
		/// <br>Programer		 :	 30167 ���@�O�M</br>
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
		/// <summary>�S���_���R�[�h�o�̓v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 �S���_���R�[�h�o�̓v���p�e�B</br>
		/// <br>Programer		 :	 30167 ���@�O�M</br>
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
		/// <summary>�ڕW�ݒ�敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 �ڕW�ݒ�敪�v���p�e�B</br>
		/// <br>Programer		 :	 30167 ���@�O�M</br>
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
		/// <summary>�ڕW�Δ�敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 �ڕW�Δ�敪�v���p�e�B</br>
		/// <br>Programer		 :	 30167 ���@�O�M</br>
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
		/// <summary>�ڕW�敪�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 �ڕW�敪�R�[�h�v���p�e�B</br>
		/// <br>Programer		 :	 30167 ���@�O�M</br>
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
		/// <summary>�ڕW�敪���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 �ڕW�敪���̃v���p�e�B</br>
		/// <br>Programer		 :	 30167 ���@�O�M</br>
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
		/// <summary>�Ǝ�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 �Ǝ�R�[�h�v���p�e�B</br>
		/// <br>Programer		 :	 30167 ���@�O�M</br>
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
		/// <summary>�̔��G���A�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 �̔��G���A�R�[�h�v���p�e�B</br>
		/// <br>Programer		 :	 30167 ���@�O�M</br>
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
		/// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 ���Ӑ�R�[�h�v���p�e�B</br>
		/// <br>Programer		 :	 30167 ���@�O�M</br>
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
		/// <summary>�K�p�J�n��(�J�n)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 �K�p�J�n���v���p�e�B</br>
		/// <br>Programer		 :	 30167 ���@�O�M</br>
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
		/// <summary>�K�p�J�n��(�I��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 �K�p�J�n���v���p�e�B</br>
		/// <br>Programer		 :	 30167 ���@�O�M</br>
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
		/// <summary>�K�p�I����(�J�n)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 �K�p�J�n���v���p�e�B</br>
		/// <br>Programer		 :	 30167 ���@�O�M</br>
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
		/// <summary>�K�p�I����(�I��)�v���p�e�B</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 �K�p�J�n���v���p�e�B</br>
		/// <br>Programer		 :	 30167 ���@�O�M</br>
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

		#region �R���X�g���N�^
		/// <summary>
		/// ���㌎�ԖڕW�ݒ�}�X�^���������R���X�g���N�^
		/// </summary>
		/// <returns>ExtrInfo_MAMOK09157EA�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :	 ExtrInfo_DCKHN09193EA�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer		 :	 30167 ���@�O�M</br>
		/// </remarks>
		public ExtrInfo_DCKHN09193EA()
		{
		}


		/// <summary>
		/// ���㌎�ԖڕW�ݒ�}�X�^���������R���X�g���N�^
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="selectSectCd">�I�����_�R�[�h</param>
		/// <param name="allSecSelEpUnit">�S�БI��</param>
		/// <param name="allSecSelSecUnit">�S���_���R�[�h�o��</param>
		/// <param name="targetSetCd">�ڕW�ݒ�敪</param>
		/// <param name="targetContrastCd">�ڕW�Δ�敪</param>
		/// <param name="targetDivideCode">�ڕW�敪�R�[�h</param>
		/// <param name="targetDivideName">�ڕW�敪����</param>
		/// <param name="businessTypeCode">�Ǝ�R�[�h</param>
		/// <param name="salesAreaCode">�̔��G���A�R�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="applyStaDateSt">�K�p�J�n��(YYYYMMDD)</param>
		/// <param name="applyStaDateEd">�K�p�J�n��(YYYYMMDD)</param>
		/// <param name="applyEndDateSt">�K�p�I����(YYYYMMDD)</param>
		/// <param name="applyEndDateEd">�K�p�I����(YYYYMMDD)</param>
		/// <returns>ExtrInfo_DCKHN09193EA�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :	 ExtrInfo_DCKHN09193EA�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer		 :	 30167 ���@�O�M</br>
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

		#endregion �R���X�g���N�^

		#region Public Method

		/// <summary>
		/// ���㌎�ԖڕW�ݒ�}�X�^����������������
		/// </summary>
		/// <returns>ExtrInfo_DCKHN09193EA�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :	 ���g�̓��e�Ɠ�����ExtrInfo_DCKHN09193EA�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer		 :	 30167 ���@�O�M</br>
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
		/// ���㌎�ԖڕW�ݒ�}�X�^����������r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�ExtrInfo_DCKHN09193EA�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :	 ExtrInfo_DCKHN09193EA�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer		 :	 30167 ���@�O�M</br>
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

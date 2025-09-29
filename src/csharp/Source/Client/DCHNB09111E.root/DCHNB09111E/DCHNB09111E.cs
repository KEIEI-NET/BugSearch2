using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SalesProcMoney
	/// <summary>
	///                      ������z�����敪�ݒ�}�X�^
	/// </summary>
	/// <remarks>
	/// <br>note             :   ������z�����敪�ݒ�}�X�^�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/08/20  (CSharp File Generated Date)</br>
    /// </remarks>
	public class SalesProcMoney
	{
		/// <summary>�쐬����</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _createDateTime;

		/// <summary>�X�V����</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _updateDateTime;

		/// <summary>��ƃR�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
		private string _enterpriseCode = "";

		/// <summary>GUID</summary>
		/// <remarks>���ʃt�@�C���w�b�_</remarks>
		private Guid _fileHeaderGuid;

		/// <summary>�X�V�]�ƈ��R�[�h</summary>
		/// <remarks>���ʃt�@�C���w�b�_</remarks>
		private string _updEmployeeCode = "";

		/// <summary>�X�V�A�Z���u��ID1</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
		private string _updAssemblyId1 = "";

		/// <summary>�X�V�A�Z���u��ID2</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
		private string _updAssemblyId2 = "";

		/// <summary>�_���폜�敪</summary>
		/// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>�[�������Ώۋ��z�敪</summary>
		/// <remarks>0:������z,1:�����,2:����P��,3:���㌴���P��,4:���㌴�����z 3,4�͎��Зp�ݒ�̂�</remarks>
		private Int32 _fracProcMoneyDiv;

		/// <summary>�[�������R�[�h</summary>
		/// <remarks>0�̏ꍇ�͎��Зp(�W��)�ݒ�Ƃ���B</remarks>
		private Int32 _fractionProcCode;

		/// <summary>������z</summary>
		/// <remarks>���z�̏ꍇ�͐����̂ݐݒ�</remarks>
		private Double _upperLimitPrice;

		/// <summary>�[�������P��</summary>
		private Double _fractionProcUnit;

		/// <summary>�[�������敪</summary>
		/// <remarks>1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ</remarks>
		private Int32 _fractionProcCd;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

		/// <summary>�X�V�]�ƈ�����</summary>
		private string _updEmployeeName = "";

		/// public propaty name  :  CreateDateTime
		/// <summary>�쐬�����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime CreateDateTime
		{
			get{return _createDateTime;}
			set{_createDateTime = value;}
		}

		/// public propaty name  :  CreateDateTimeJpFormal
		/// <summary>�쐬���� �a��v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CreateDateTimeJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeJpInFormal
		/// <summary>�쐬���� �a��(��)�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CreateDateTimeJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeAdFormal
		/// <summary>�쐬���� ����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CreateDateTimeAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  CreateDateTimeAdInFormal
		/// <summary>�쐬���� ����(��)�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string CreateDateTimeAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTime
		/// <summary>�X�V�����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime UpdateDateTime
		{
			get{return _updateDateTime;}
			set{_updateDateTime = value;}
		}

		/// public propaty name  :  UpdateDateTimeJpFormal
		/// <summary>�X�V���� �a��v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���� �a��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateTimeJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeJpInFormal
		/// <summary>�X�V���� �a��(��)�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���� �a��(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateTimeJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeAdFormal
		/// <summary>�X�V���� ����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���� ����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateTimeAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  UpdateDateTimeAdInFormal
		/// <summary>�X�V���� ����(��)�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V���� ����(��)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdateDateTimeAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime);}
			set{}
		}

		/// public propaty name  :  EnterpriseCode
		/// <summary>��ƃR�[�h�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EnterpriseCode
		{
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
		}

		/// public propaty name  :  FileHeaderGuid
		/// <summary>GUID�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   GUID�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Guid FileHeaderGuid
		{
			get{return _fileHeaderGuid;}
			set{_fileHeaderGuid = value;}
		}

		/// public propaty name  :  UpdEmployeeCode
		/// <summary>�X�V�]�ƈ��R�[�h�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�]�ƈ��R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdEmployeeCode
		{
			get{return _updEmployeeCode;}
			set{_updEmployeeCode = value;}
		}

		/// public propaty name  :  UpdAssemblyId1
		/// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�A�Z���u��ID1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdAssemblyId1
		{
			get{return _updAssemblyId1;}
			set{_updAssemblyId1 = value;}
		}

		/// public propaty name  :  UpdAssemblyId2
		/// <summary>�X�V�A�Z���u��ID2�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�A�Z���u��ID2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdAssemblyId2
		{
			get{return _updAssemblyId2;}
			set{_updAssemblyId2 = value;}
		}

		/// public propaty name  :  LogicalDeleteCode
		/// <summary>�_���폜�敪�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �_���폜�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 LogicalDeleteCode
		{
			get{return _logicalDeleteCode;}
			set{_logicalDeleteCode = value;}
		}

		/// public propaty name  :  FracProcMoneyDiv
		/// <summary>�[�������Ώۋ��z�敪�v���p�e�B</summary>
		/// <value>0:������z,1:�����,2:����P��,3:���㌴���P��,4:���㌴�����z 3,4�͎��Зp�ݒ�̂�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�������Ώۋ��z�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 FracProcMoneyDiv
		{
			get{return _fracProcMoneyDiv;}
			set{_fracProcMoneyDiv = value;}
		}

		/// public propaty name  :  FractionProcCode
		/// <summary>�[�������R�[�h�v���p�e�B</summary>
		/// <value>0�̏ꍇ�͎��Зp(�W��)�ݒ�Ƃ���B</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�������R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 FractionProcCode
		{
			get{return _fractionProcCode;}
			set{_fractionProcCode = value;}
		}

		/// public propaty name  :  UpperLimitPrice
		/// <summary>������z�v���p�e�B</summary>
		/// <value>���z�̏ꍇ�͐����̂ݐݒ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ������z�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double UpperLimitPrice
		{
			get{return _upperLimitPrice;}
			set{_upperLimitPrice = value;}
		}

		/// public propaty name  :  FractionProcUnit
		/// <summary>�[�������P�ʃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�������P�ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double FractionProcUnit
		{
			get{return _fractionProcUnit;}
			set{_fractionProcUnit = value;}
		}

		/// public propaty name  :  FractionProcCd
		/// <summary>�[�������敪�v���p�e�B</summary>
		/// <value>1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[�������敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 FractionProcCd
		{
			get{return _fractionProcCd;}
			set{_fractionProcCd = value;}
		}

		/// public propaty name  :  EnterpriseName
		/// <summary>��Ɩ��̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ��Ɩ��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EnterpriseName
		{
			get{return _enterpriseName;}
			set{_enterpriseName = value;}
		}

		/// public propaty name  :  UpdEmployeeName
		/// <summary>�X�V�]�ƈ����̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�]�ƈ����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string UpdEmployeeName
		{
			get{return _updEmployeeName;}
			set{_updEmployeeName = value;}
		}


		/// <summary>
		/// ������z�����敪�ݒ�}�X�^�R���X�g���N�^
		/// </summary>
		/// <returns>SalesProcMoney�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SalesProcMoney�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SalesProcMoney()
		{
		}

		/// <summary>
		/// ������z�����敪�ݒ�}�X�^�R���X�g���N�^
		/// </summary>
		/// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
		/// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
		/// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
		/// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪(0:������z,1:�����,2:����P��,3:���㌴���P��,4:���㌴�����z 3,4�͎��Зp�ݒ�̂�)</param>
		/// <param name="fractionProcCode">�[�������R�[�h(0�̏ꍇ�͎��Зp(�W��)�ݒ�Ƃ���B)</param>
		/// <param name="upperLimitPrice">������z(���z�̏ꍇ�͐����̂ݐݒ�)</param>
		/// <param name="fractionProcUnit">�[�������P��</param>
		/// <param name="fractionProcCd">�[�������敪(1�F�؎̂�,2�F�l�̌ܓ�,3:�؏グ)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="fractionProcCdNm">�[�������敪����</param>
        /// <returns>SalesProcMoney�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SalesProcMoney�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
        public SalesProcMoney( DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 fracProcMoneyDiv, Int32 fractionProcCode, Double upperLimitPrice, Double fractionProcUnit, Int32 fractionProcCd, string enterpriseName, string updEmployeeName, string fractionProcCdNm )
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._fracProcMoneyDiv = fracProcMoneyDiv;
			this._fractionProcCode = fractionProcCode;
			this._upperLimitPrice = upperLimitPrice;
			this._fractionProcUnit = fractionProcUnit;
			this._fractionProcCd = fractionProcCd;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
            this._fractionProcCdNm = fractionProcCdNm;
        }

		/// <summary>
		/// ������z�����敪�ݒ�}�X�^��������
		/// </summary>
		/// <returns>SalesProcMoney�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SalesProcMoney�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public SalesProcMoney Clone()
		{
            return new SalesProcMoney(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._fracProcMoneyDiv, this._fractionProcCode, this._upperLimitPrice, this._fractionProcUnit, this._fractionProcCd, this._enterpriseName, this._updEmployeeName, this._fractionProcCdNm);
		}

		/// <summary>
		/// ������z�����敪�ݒ�}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SalesProcMoney�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SalesProcMoney�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(SalesProcMoney target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.FracProcMoneyDiv == target.FracProcMoneyDiv)
				 && (this.FractionProcCode == target.FractionProcCode)
				 && (this.UpperLimitPrice == target.UpperLimitPrice)
				 && (this.FractionProcUnit == target.FractionProcUnit)
				 && (this.FractionProcCd == target.FractionProcCd)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName));
		}

		/// <summary>
		/// ������z�����敪�ݒ�}�X�^��r����
		/// </summary>
		/// <param name="salesProcMoney1">
		///                    ��r����SalesProcMoney�N���X�̃C���X�^���X
		/// </param>
		/// <param name="salesProcMoney2">��r����SalesProcMoney�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SalesProcMoney�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(SalesProcMoney salesProcMoney1, SalesProcMoney salesProcMoney2)
		{
			return ((salesProcMoney1.CreateDateTime == salesProcMoney2.CreateDateTime)
				 && (salesProcMoney1.UpdateDateTime == salesProcMoney2.UpdateDateTime)
				 && (salesProcMoney1.EnterpriseCode == salesProcMoney2.EnterpriseCode)
				 && (salesProcMoney1.FileHeaderGuid == salesProcMoney2.FileHeaderGuid)
				 && (salesProcMoney1.UpdEmployeeCode == salesProcMoney2.UpdEmployeeCode)
				 && (salesProcMoney1.UpdAssemblyId1 == salesProcMoney2.UpdAssemblyId1)
				 && (salesProcMoney1.UpdAssemblyId2 == salesProcMoney2.UpdAssemblyId2)
				 && (salesProcMoney1.LogicalDeleteCode == salesProcMoney2.LogicalDeleteCode)
				 && (salesProcMoney1.FracProcMoneyDiv == salesProcMoney2.FracProcMoneyDiv)
				 && (salesProcMoney1.FractionProcCode == salesProcMoney2.FractionProcCode)
				 && (salesProcMoney1.UpperLimitPrice == salesProcMoney2.UpperLimitPrice)
				 && (salesProcMoney1.FractionProcUnit == salesProcMoney2.FractionProcUnit)
				 && (salesProcMoney1.FractionProcCd == salesProcMoney2.FractionProcCd)
				 && (salesProcMoney1.EnterpriseName == salesProcMoney2.EnterpriseName)
				 && (salesProcMoney1.UpdEmployeeName == salesProcMoney2.UpdEmployeeName));
		}
		/// <summary>
		/// ������z�����敪�ݒ�}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�SalesProcMoney�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SalesProcMoney�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(SalesProcMoney target)
		{
			ArrayList resList = new ArrayList();
			if(this.CreateDateTime != target.CreateDateTime)resList.Add("CreateDateTime");
			if(this.UpdateDateTime != target.UpdateDateTime)resList.Add("UpdateDateTime");
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.FileHeaderGuid != target.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(this.UpdEmployeeCode != target.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(this.UpdAssemblyId1 != target.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(this.UpdAssemblyId2 != target.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(this.LogicalDeleteCode != target.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(this.FracProcMoneyDiv != target.FracProcMoneyDiv)resList.Add("FracProcMoneyDiv");
			if(this.FractionProcCode != target.FractionProcCode)resList.Add("FractionProcCode");
			if(this.UpperLimitPrice != target.UpperLimitPrice)resList.Add("UpperLimitPrice");
			if(this.FractionProcUnit != target.FractionProcUnit)resList.Add("FractionProcUnit");
			if(this.FractionProcCd != target.FractionProcCd)resList.Add("FractionProcCd");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}

		/// <summary>
		/// ������z�����敪�ݒ�}�X�^��r����
		/// </summary>
		/// <param name="salesProcMoney1">��r����SalesProcMoney�N���X�̃C���X�^���X</param>
		/// <param name="salesProcMoney2">��r����SalesProcMoney�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SalesProcMoney�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(SalesProcMoney salesProcMoney1, SalesProcMoney salesProcMoney2)
		{
			ArrayList resList = new ArrayList();
			if(salesProcMoney1.CreateDateTime != salesProcMoney2.CreateDateTime)resList.Add("CreateDateTime");
			if(salesProcMoney1.UpdateDateTime != salesProcMoney2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(salesProcMoney1.EnterpriseCode != salesProcMoney2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(salesProcMoney1.FileHeaderGuid != salesProcMoney2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(salesProcMoney1.UpdEmployeeCode != salesProcMoney2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(salesProcMoney1.UpdAssemblyId1 != salesProcMoney2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(salesProcMoney1.UpdAssemblyId2 != salesProcMoney2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(salesProcMoney1.LogicalDeleteCode != salesProcMoney2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(salesProcMoney1.FracProcMoneyDiv != salesProcMoney2.FracProcMoneyDiv)resList.Add("FracProcMoneyDiv");
			if(salesProcMoney1.FractionProcCode != salesProcMoney2.FractionProcCode)resList.Add("FractionProcCode");
			if(salesProcMoney1.UpperLimitPrice != salesProcMoney2.UpperLimitPrice)resList.Add("UpperLimitPrice");
			if(salesProcMoney1.FractionProcUnit != salesProcMoney2.FractionProcUnit)resList.Add("FractionProcUnit");
			if(salesProcMoney1.FractionProcCd != salesProcMoney2.FractionProcCd)resList.Add("FractionProcCd");
			if(salesProcMoney1.EnterpriseName != salesProcMoney2.EnterpriseName)resList.Add("EnterpriseName");
			if(salesProcMoney1.UpdEmployeeName != salesProcMoney2.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
        }

        #region �蓮�Œǉ���

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _fractionProcCdNm = "";

        /// public propaty name  :  FractionProcCdName
        /// <summary>�[�������敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note       : �[�������敪���̃v���p�e�B�i�K�C�h�Ŏg�p)</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2007.08.23</br>
        /// </remarks>
        public string FractionProcCdNm
        {
            get { return _fractionProcCdNm; }
            set { _fractionProcCdNm = value; }
        }

        /// <summary>�[�������Ώۋ��z�敪���X�g</summary>
        private static ArrayList fracProvMoneyDivList;
        /// <summary>�[�������敪���X�g</summary>
        private static SortedList fractionProcCdTable;
        private const int CONST_BASIC = 0;
        private const int CONST_OTHER = 1;

        /// <summary>
        /// �ÓI�R���X�g���N�^
        /// </summary>
        static SalesProcMoney()
        {
            SalesProcMoney.fracProvMoneyDivList = MakeFrancProvMoneyDivList();
            SalesProcMoney.fractionProcCdTable = MakeFractionProcCdTable();
        }

        /// <summary>
        /// �[�������Ώۋ��z�敪���X�g����
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: �[�������Ώۋ��z�敪�̃��X�g�𐶐����܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2007.08.23</br>
        /// </remarks>
        private static ArrayList MakeFrancProvMoneyDivList()
        {
            ArrayList retList = new ArrayList();
            retList.Add(MakeFrancProvMoneyDivList(CONST_BASIC));
            retList.Add(MakeFrancProvMoneyDivList(CONST_OTHER));
            return retList;
        }

        /// <summary>
        /// �[�������Ώۋ��z�敪���X�g�擾����
        /// </summary>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <returns>�[�������Ώۋ��z�敪���X�g</returns>
        /// <remarks>
        /// <br>Note		: �[�������Ώۋ��z�敪�ɂĎg�p����R�[�h�̃��X�g���擾���܂��B</br>
        /// <br>			: �C���f�b�N�X��GetFracProcMoneyNmList()�ɂĎ擾�o���閼�̂ƈ�v���܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2007.08.23</br>
        /// </remarks>
        private static SortedList MakeFrancProvMoneyDivList( Int32 fractionProcCode )
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(0, new FracProcMoneyDivInfo(0, "������z", false));
            retSortedList.Add(1, new FracProcMoneyDivInfo(1, "�����", false));
            retSortedList.Add(2, new FracProcMoneyDivInfo(2, "����P��", true));

            // ���㌴���P���A���㌴�����z�͔�����z�Ɠ��������̂��� fractionProcCode �ɂ��ꍇ�������폜
            // DEL 2008/09/29 �s��Ή�[5504]---------->>>>>
            //if (fractionProcCode == CONST_BASIC) // ���Зp�ݒ�̂ݗL���Ȑݒ�
            //{
            //    retSortedList.Add(3, new FracProcMoneyDivInfo(3, "���㌴���P��", true));
            //    retSortedList.Add(4, new FracProcMoneyDivInfo(4, "���㌴�����z", false));
            //}
            // DEL 2008/09/29 �s��Ή�[5504]----------<<<<<

            // --- DEL 2009/01/20 ��QID:9815�Ή�------------------------------------------------------>>>>>
            //// ADD 2008/09/29 �s��Ή�[5504]---------->>>>>
            //retSortedList.Add(3, new FracProcMoneyDivInfo(3, "���㌴���P��", true));
            //retSortedList.Add(4, new FracProcMoneyDivInfo(4, "���㌴�����z", false));
            //// ADD 2008/09/29 �s��Ή�[5504]----------<<<<<
            // --- DEL 2009/01/20 ��QID:9815�Ή�------------------------------------------------------<<<<<

            return retSortedList;
        }

        /// <summary>
        /// �[�������Ώۋ��z�敪���X�g(�I���\��)�擾����
        /// </summary>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <returns>�[�������Ώۋ��z�敪���X�g</returns>
        /// <remarks>
        /// <br>Note       : �[�������R�[�h�ɏ]���āA�[�������Ώۋ��z�敪�ɐݒ�\�ȃ��X�g���擾���܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2007.08.23</br>
        /// </remarks>
        public static SortedList GetFracProcMoneyDivTable( Int32 fractionProcCode )
        {
            // �[�������R�[�h�ɂ���đI���ł���[�������Ώۋ��z�敪���ς��
            switch (fractionProcCode)
            {
                case CONST_BASIC:
                    return fracProvMoneyDivList[CONST_BASIC] as SortedList;
                default:
                    return fracProvMoneyDivList[CONST_OTHER] as SortedList;
            }
        }

        /// <summary>
        /// �[�������Ώۋ��z�敪���̎擾����
        /// </summary>
        /// <param name="fracProcMoneyDivCd">�[�������Ώۋ��z�敪</param>
        /// <param name="fractioinProcCode">�[�������R�[�h</param>
        /// <returns>�[�������Ώۋ��z�敪����</returns>
        /// <remarks>
        /// <br>Note       : �[�������R�[�h,�[�������Ώۋ��z�敪�ɂ���āA�[�������Ώۋ��z�敪���̂��擾���܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2007.08.23</br>
        /// </remarks>
        public static string GetFracProcMoneyDivNm( Int32 fracProcMoneyDivCd,Int32 fractioinProcCode )
        {
            // DEL 2008/09/29 �s��Ή�[5504]��
            //return (GetFracProcMoneyDivTable(fractioinProcCode)[fracProcMoneyDivCd] as FracProcMoneyDivInfo).FracProcMoneyDivName;

            // ADD 2008/09/29 �s��Ή�[5504]---------->>>>>
            FracProcMoneyDivInfo fracProcMoneyDivInfo = GetFracProcMoneyDivTable(fractioinProcCode)[fracProcMoneyDivCd] as FracProcMoneyDivInfo;
            if (fracProcMoneyDivInfo != null)
            {
                return fracProcMoneyDivInfo.FracProcMoneyDivName;
            }
            else
            {
                return string.Empty;
            }
            // ADD 2008/09/29 �s��Ή�[5504]----------<<<<<
        }

        /// <summary>
        /// �[�������Ώۋ��z�敪 �����_�g�p�L���擾����
        /// </summary>
        /// <param name="fracProcMoneyDivCd">�[�������Ώۋ��z�敪�l</param>
        /// <returns>�����_�g�p�L��</returns>
        /// <remarks>
        /// <br>Note       : �[�������Ώۋ��z�敪�l�̏����_�g�p�L�����擾���܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2007.08.23</br>
        /// </remarks>
        public static bool GetFracProcMoneyDivIsUseDecimal( Int32 fracProcMoneyDivCd)
        {
            return ( GetFracProcMoneyDivTable(CONST_BASIC)[fracProcMoneyDivCd] as FracProcMoneyDivInfo ).IsUseDecimal;
        }

        /// <summary>
        /// �[�������敪���X�g����
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note	   : �[�[�������敪�̃��X�g�𐶐����܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2007.08.23</br>
        /// </remarks>
        private static SortedList MakeFractionProcCdTable()
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(1, "�؎̂�");
            retSortedList.Add(2, "�l�̌ܓ�");
            retSortedList.Add(3, "�؏グ");
            return retSortedList;
        }

        /// <summary>
        /// �[�������Ώۋ��z�敪���X�g(�I���\��)�擾����
        /// </summary>
        /// <returns>�[�������Ώۋ��z�敪���X�g</returns>
        /// <remarks>
        /// <br>Note       : �[�������R�[�h�ɏ]���āA�[�������Ώۋ��z�敪�ɐݒ�\�ȃ��X�g���擾���܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2007.08.23</br>
        /// </remarks>
        public static SortedList GetFractionProcCdTable()
        {
            return fractionProcCdTable;
        }

        /// <summary>
        /// �[�������敪���̎擾����
        /// </summary>
        /// <param name="fractionProcCd">�[�������敪</param>
        /// <returns>�[�������敪����</returns>
        /// <remarks>
        /// <br>Note       : �[�������敪�ɂ���āA�[�������敪���̂��擾���܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2007.08.23</br>
        /// </remarks>
        public static string GetFractionProcCdNm( Int32 fractionProcCd)
        {
            return fractionProcCdTable[fractionProcCd].ToString();
        }

        /// <summary>
        /// �[�������敪�擾����
        /// </summary>
        /// <param name="fractionProcCdNm">�[�������敪����</param>
        /// <returns>�[�������敪</returns>
        /// <remarks>
        /// <br>Note       : �[�������敪���̂ɑΉ�����[�������敪���擾���܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2007.08.23</br>
        /// </remarks>
        public static int GetFractionProcCd( string fractionProcCdNm )
        {
            if (fractionProcCdTable.ContainsValue((object)fractionProcCdNm))
            {
                return (int)fractionProcCdTable.GetKey(fractionProcCdTable.IndexOfValue(fractionProcCdNm));
            }
            return 0;
        }

        #endregion

    }

    #region FracProcMoneyDivInfo�N���X
    /// private class name:   FracProcMoneyDivInfo
    /// <summary>
    ///                      �[�������Ώۋ��z�敪���N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �[�������Ώۋ��z�敪�N���X</br>
    /// <br>Programmer       :   21024 ���X�� ��</br>
    /// <br>Date             :   2007.08.23</br>
    /// </remarks>
    public class FracProcMoneyDivInfo
    {
        private int _fracProcMoneyDivCode;
        private string _fracProcMoneyDivName;
        private bool _isUseDecimal;
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public FracProcMoneyDivInfo()
        {
        }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="fracProcMoneyDivCode">�敪�l</param>
        /// <param name="fracProcMoneyDivName">�敪����</param>
        /// <param name="isUseDecimal">�����g�p�L��</param>
        public FracProcMoneyDivInfo( int fracProcMoneyDivCode, string fracProcMoneyDivName, bool isUseDecimal )
        {
            this._fracProcMoneyDivCode = fracProcMoneyDivCode;
            this._fracProcMoneyDivName = fracProcMoneyDivName;
            this._isUseDecimal = isUseDecimal;
        }

        /// public propaty name  :  FracProcMoneyDivCode
        /// <summary>�[�������Ώۋ��z�敪�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             : �[�������Ώۋ��z�敪���̃R�[�h�v���p�e�B</br>
        /// <br>Programmer       : 21024 ���X�� ��</br>
        /// <br>Date             : 2007.08.23</br>
        /// </remarks>
        public int FracProcMoneyDivCode
        {
            get { return this._fracProcMoneyDivCode; }
            set { this._fracProcMoneyDivCode = value; }
        }

        /// public propaty name  :  FracProcMoneyDivName
        /// <summary>�[�������Ώۋ��z�敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             : �[�������Ώۋ��z�敪���̃v���p�e�B</br>
        /// <br>Programmer       : 21024 ���X�� ��</br>
        /// <br>Date             : 2007.08.23</br>
        /// </remarks>
        public string FracProcMoneyDivName
        {
            get { return this._fracProcMoneyDivName; }
            set { this._fracProcMoneyDivName = value; }
        }

        /// public propaty name  :  IsUseDecimal
        /// <summary>�����g�p�L���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             : �����g�p�L���v���p�e�B</br>
        /// <br>Programmer       : 21024 ���X�� ��</br>
        /// <br>Date             : 2007.08.23</br>
        /// </remarks>
        public bool IsUseDecimal
        {
            get { return this._isUseDecimal; }
            set { this._isUseDecimal = value; }
        }
    }
    #endregion

}

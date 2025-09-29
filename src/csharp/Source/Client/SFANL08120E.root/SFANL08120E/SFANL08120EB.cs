using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	// ------------------------------------------------------------
	//  ��UsedFlg��ǉ�
	//  ���`�F�b�N���ڃR�[�h�̏����l��-1�ɕύX
	// ------------------------------------------------------------

	/// public class name:   FrePprECnd
	/// <summary>
	///                      ���R���[���o�����ݒ�}�X�^
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���R���[���o�����ݒ�}�X�^�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2007/03/15</br>
	/// <br>Genarated Date   :   2007/03/30  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class FrePprECnd
	{
		#region AutoGenerate PrivateMember
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

		/// <summary>�o�̓t�@�C����</summary>
		/// <remarks>�t�H�[���t�@�C��ID or �t�H�[�}�b�g�t�@�C��ID</remarks>
		private string _outputFormFileName = "";

		/// <summary>���[�U�[���[ID�}�ԍ�</summary>
		private Int32 _userPrtPprIdDerivNo;

		/// <summary>���R���[���o�����}��</summary>
		private Int32 _frePrtPprExtraCondCd;

		/// <summary>�\������</summary>
		private Int32 _displayOrder;

		/// <summary>���o�����敪</summary>
		/// <remarks>0:�g�p�s��,1:���l�^,2:�����^�i���p�j,3:�����^�i�S�p�j,4:���t�^,5:�R���{�^,6:�`�F�b�N�^</remarks>
		private Int32 _extraConditionDivCd;

		/// <summary>���o�����^�C�v</summary>
		/// <remarks>0:��v,1:�͈�,2:�����܂�,3:����</remarks>
		private Int32 _extraConditionTypeCd;

		/// <summary>���o�����^�C�g��</summary>
		private string _extraConditionTitle = "";

		/// <summary>DD����</summary>
		private Int32 _dDCharCnt;

		/// <summary>DD����</summary>
		/// <remarks>�������œo�^</remarks>
		private string _dDName = "";

		/// <summary>���o�J�n�R�[�h�i���l�j</summary>
		private Int64 _stExtraNumCode;

		/// <summary>���o�I���R�[�h�i���l�j</summary>
		private Int64 _edExtraNumCode;

		/// <summary>���o�J�n�R�[�h�i�����j</summary>
		private string _stExtraCharCode = "";

		/// <summary>���o�I���R�[�h�i�����j</summary>
		private string _edExtraCharCode = "";

		/// <summary>���o�J�n���t�i��j</summary>
		/// <remarks>0:�O�X��,1:�O��,2:�{��,3:����,4:���X��,5:���t�w��</remarks>
		private Int32 _stExtraDateBaseCd;

		/// <summary>���o�J�n���t�i�����j</summary>
		/// <remarks>0:�{�i�v���X�j,1:�|�i�}�C�i�X�j</remarks>
		private Int32 _stExtraDateSignCd;

		/// <summary>���o�J�n���t�i���l�j</summary>
		private Int32 _stExtraDateNum;

		/// <summary>���o�J�n���t�i�P�ʁj</summary>
		/// <remarks>0:��,1:�T,2:��,3:�N</remarks>
		private Int32 _stExtraDateUnitCd;

		/// <summary>���o�J�n���t�i���t�j</summary>
		private Int32 _startExtraDate;

		/// <summary>���o�I�����t�i��j</summary>
		/// <remarks>0:�O�X��,1:�O��,2:�{��,3:����,4:���X��,5:���t�w��</remarks>
		private Int32 _edExtraDateBaseCd;

		/// <summary>���o�I�����t�i�����j</summary>
		/// <remarks>0:�{�i�v���X�j,1:�|�i�}�C�i�X�j</remarks>
		private Int32 _edExtraDateSignCd;

		/// <summary>���o�I�����t�i���l�j</summary>
		private Int32 _edExtraDateNum;

		/// <summary>���o�I�����t�i�P�ʁj</summary>
		/// <remarks>0:��,1:�T,2:��,3:�N</remarks>
		private Int32 _edExtraDateUnitCd;

		/// <summary>���o�I�����t�i���t�j</summary>
		private Int32 _endExtraDate;

		/// <summary>���o�������׃O���[�v�R�[�h</summary>
		/// <remarks>���o�����敪���R���{�{�b�N�X�^�̎��Ɏg�p</remarks>
		private Int32 _extraCondDetailGrpCd;

		/// <summary>�K�{���o�����敪</summary>
		/// <remarks>0:�C��,1:�K�{</remarks>
		private Int32 _necessaryExtraCondCd;

		/// <summary>�`�F�b�N���ڃR�[�h1</summary>
		private Int32 _checkItemCode1 = -1;

		/// <summary>�`�F�b�N���ڃR�[�h2</summary>
		private Int32 _checkItemCode2 = -1;

		/// <summary>�`�F�b�N���ڃR�[�h3</summary>
		private Int32 _checkItemCode3 = -1;

		/// <summary>�`�F�b�N���ڃR�[�h4</summary>
		private Int32 _checkItemCode4 = -1;

		/// <summary>�`�F�b�N���ڃR�[�h5</summary>
		private Int32 _checkItemCode5 = -1;

		/// <summary>�`�F�b�N���ڃR�[�h6</summary>
		private Int32 _checkItemCode6 = -1;

		/// <summary>�`�F�b�N���ڃR�[�h7</summary>
		private Int32 _checkItemCode7 = -1;

		/// <summary>�`�F�b�N���ڃR�[�h8</summary>
		private Int32 _checkItemCode8 = -1;

		/// <summary>�`�F�b�N���ڃR�[�h9</summary>
		private Int32 _checkItemCode9 = -1;

		/// <summary>�`�F�b�N���ڃR�[�h10</summary>
		private Int32 _checkItemCode10 = -1;

		/// <summary>�t�@�C������</summary>
		/// <remarks>DB�̃e�[�u��ID</remarks>
		private string _fileNm = "";

		/// <summary>���͌���</summary>
		/// <remarks>�����̓��͐����Ŏg�p</remarks>
		private Int32 _inputCharCnt;

		/// <summary>��Ɩ���</summary>
		private string _enterpriseName = "";

		/// <summary>�X�V�]�ƈ�����</summary>
		private string _updEmployeeName = "";
		#endregion

		#region AutoGenerate Property
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
			get { return _createDateTime; }
			set { _createDateTime = value; }
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
			get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
			set { }
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
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
			set { }
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
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
			set { }
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
			get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
			set { }
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
			get { return _updateDateTime; }
			set { _updateDateTime = value; }
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
			get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
			set { }
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
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
			set { }
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
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
			set { }
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
			get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
			set { }
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
			get { return _enterpriseCode; }
			set { _enterpriseCode = value; }
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
			get { return _fileHeaderGuid; }
			set { _fileHeaderGuid = value; }
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
			get { return _updEmployeeCode; }
			set { _updEmployeeCode = value; }
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
			get { return _updAssemblyId1; }
			set { _updAssemblyId1 = value; }
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
			get { return _updAssemblyId2; }
			set { _updAssemblyId2 = value; }
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
			get { return _logicalDeleteCode; }
			set { _logicalDeleteCode = value; }
		}

		/// public propaty name  :  OutputFormFileName
		/// <summary>�o�̓t�@�C�����v���p�e�B</summary>
		/// <value>�t�H�[���t�@�C��ID or �t�H�[�}�b�g�t�@�C��ID</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�̓t�@�C�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string OutputFormFileName
		{
			get { return _outputFormFileName; }
			set { _outputFormFileName = value; }
		}

		/// public propaty name  :  UserPrtPprIdDerivNo
		/// <summary>���[�U�[���[ID�}�ԍ��v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�U�[���[ID�}�ԍ��v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 UserPrtPprIdDerivNo
		{
			get { return _userPrtPprIdDerivNo; }
			set { _userPrtPprIdDerivNo = value; }
		}

		/// public propaty name  :  FrePrtPprExtraCondCd
		/// <summary>���R���[���o�����}�ԃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���R���[���o�����}�ԃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 FrePrtPprExtraCondCd
		{
			get { return _frePrtPprExtraCondCd; }
			set { _frePrtPprExtraCondCd = value; }
		}

		/// public propaty name  :  DisplayOrder
		/// <summary>�\�����ʃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �\�����ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DisplayOrder
		{
			get { return _displayOrder; }
			set { _displayOrder = value; }
		}

		/// public propaty name  :  ExtraConditionDivCd
		/// <summary>���o�����敪�v���p�e�B</summary>
		/// <value>0:�g�p�s��,1:���l�^,2:�����^�i���p�j,3:�����^�i�S�p�j,4:���t�^,5:�R���{�^,6:�`�F�b�N�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ExtraConditionDivCd
		{
			get { return _extraConditionDivCd; }
			set { _extraConditionDivCd = value; }
		}

		/// public propaty name  :  ExtraConditionTypeCd
		/// <summary>���o�����^�C�v�v���p�e�B</summary>
		/// <value>0:��v,1:�͈�,2:�����܂�,3:����</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�����^�C�v�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ExtraConditionTypeCd
		{
			get { return _extraConditionTypeCd; }
			set { _extraConditionTypeCd = value; }
		}

		/// public propaty name  :  ExtraConditionTitle
		/// <summary>���o�����^�C�g���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�����^�C�g���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ExtraConditionTitle
		{
			get { return _extraConditionTitle; }
			set { _extraConditionTitle = value; }
		}

		/// public propaty name  :  DDCharCnt
		/// <summary>DD�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   DD�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DDCharCnt
		{
			get { return _dDCharCnt; }
			set { _dDCharCnt = value; }
		}

		/// public propaty name  :  DDName
		/// <summary>DD���̃v���p�e�B</summary>
		/// <value>�������œo�^</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   DD���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DDName
		{
			get { return _dDName; }
			set { _dDName = value; }
		}

		/// public propaty name  :  StExtraNumCode
		/// <summary>���o�J�n�R�[�h�i���l�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�J�n�R�[�h�i���l�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 StExtraNumCode
		{
			get { return _stExtraNumCode; }
			set { _stExtraNumCode = value; }
		}

		/// public propaty name  :  EdExtraNumCode
		/// <summary>���o�I���R�[�h�i���l�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�I���R�[�h�i���l�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int64 EdExtraNumCode
		{
			get { return _edExtraNumCode; }
			set { _edExtraNumCode = value; }
		}

		/// public propaty name  :  StExtraCharCode
		/// <summary>���o�J�n�R�[�h�i�����j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�J�n�R�[�h�i�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string StExtraCharCode
		{
			get { return _stExtraCharCode; }
			set { _stExtraCharCode = value; }
		}

		/// public propaty name  :  EdExtraCharCode
		/// <summary>���o�I���R�[�h�i�����j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�I���R�[�h�i�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string EdExtraCharCode
		{
			get { return _edExtraCharCode; }
			set { _edExtraCharCode = value; }
		}

		/// public propaty name  :  StExtraDateBaseCd
		/// <summary>���o�J�n���t�i��j�v���p�e�B</summary>
		/// <value>0:�O�X��,1:�O��,2:�{��,3:����,4:���X��,5:���t�w��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�J�n���t�i��j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StExtraDateBaseCd
		{
			get { return _stExtraDateBaseCd; }
			set { _stExtraDateBaseCd = value; }
		}

		/// public propaty name  :  StExtraDateSignCd
		/// <summary>���o�J�n���t�i�����j�v���p�e�B</summary>
		/// <value>0:�{�i�v���X�j,1:�|�i�}�C�i�X�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�J�n���t�i�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StExtraDateSignCd
		{
			get { return _stExtraDateSignCd; }
			set { _stExtraDateSignCd = value; }
		}

		/// public propaty name  :  StExtraDateNum
		/// <summary>���o�J�n���t�i���l�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�J�n���t�i���l�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StExtraDateNum
		{
			get { return _stExtraDateNum; }
			set { _stExtraDateNum = value; }
		}

		/// public propaty name  :  StExtraDateUnitCd
		/// <summary>���o�J�n���t�i�P�ʁj�v���p�e�B</summary>
		/// <value>0:��,1:�T,2:��,3:�N</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�J�n���t�i�P�ʁj�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StExtraDateUnitCd
		{
			get { return _stExtraDateUnitCd; }
			set { _stExtraDateUnitCd = value; }
		}

		/// public propaty name  :  StartExtraDate
		/// <summary>���o�J�n���t�i���t�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�J�n���t�i���t�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 StartExtraDate
		{
			get { return _startExtraDate; }
			set { _startExtraDate = value; }
		}

		/// public propaty name  :  EdExtraDateBaseCd
		/// <summary>���o�I�����t�i��j�v���p�e�B</summary>
		/// <value>0:�O�X��,1:�O��,2:�{��,3:����,4:���X��,5:���t�w��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�I�����t�i��j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EdExtraDateBaseCd
		{
			get { return _edExtraDateBaseCd; }
			set { _edExtraDateBaseCd = value; }
		}

		/// public propaty name  :  EdExtraDateSignCd
		/// <summary>���o�I�����t�i�����j�v���p�e�B</summary>
		/// <value>0:�{�i�v���X�j,1:�|�i�}�C�i�X�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�I�����t�i�����j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EdExtraDateSignCd
		{
			get { return _edExtraDateSignCd; }
			set { _edExtraDateSignCd = value; }
		}

		/// public propaty name  :  EdExtraDateNum
		/// <summary>���o�I�����t�i���l�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�I�����t�i���l�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EdExtraDateNum
		{
			get { return _edExtraDateNum; }
			set { _edExtraDateNum = value; }
		}

		/// public propaty name  :  EdExtraDateUnitCd
		/// <summary>���o�I�����t�i�P�ʁj�v���p�e�B</summary>
		/// <value>0:��,1:�T,2:��,3:�N</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�I�����t�i�P�ʁj�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EdExtraDateUnitCd
		{
			get { return _edExtraDateUnitCd; }
			set { _edExtraDateUnitCd = value; }
		}

		/// public propaty name  :  EndExtraDate
		/// <summary>���o�I�����t�i���t�j�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�I�����t�i���t�j�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EndExtraDate
		{
			get { return _endExtraDate; }
			set { _endExtraDate = value; }
		}

		/// public propaty name  :  ExtraCondDetailGrpCd
		/// <summary>���o�������׃O���[�v�R�[�h�v���p�e�B</summary>
		/// <value>���o�����敪���R���{�{�b�N�X�^�̎��Ɏg�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�������׃O���[�v�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ExtraCondDetailGrpCd
		{
			get { return _extraCondDetailGrpCd; }
			set { _extraCondDetailGrpCd = value; }
		}

		/// public propaty name  :  NecessaryExtraCondCd
		/// <summary>�K�{���o�����敪�v���p�e�B</summary>
		/// <value>0:�C��,1:�K�{</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �K�{���o�����敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 NecessaryExtraCondCd
		{
			get { return _necessaryExtraCondCd; }
			set { _necessaryExtraCondCd = value; }
		}

		/// public propaty name  :  CheckItemCode1
		/// <summary>�`�F�b�N���ڃR�[�h1�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�F�b�N���ڃR�[�h1�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CheckItemCode1
		{
			get { return _checkItemCode1; }
			set { _checkItemCode1 = value; }
		}

		/// public propaty name  :  CheckItemCode2
		/// <summary>�`�F�b�N���ڃR�[�h2�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�F�b�N���ڃR�[�h2�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CheckItemCode2
		{
			get { return _checkItemCode2; }
			set { _checkItemCode2 = value; }
		}

		/// public propaty name  :  CheckItemCode3
		/// <summary>�`�F�b�N���ڃR�[�h3�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�F�b�N���ڃR�[�h3�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CheckItemCode3
		{
			get { return _checkItemCode3; }
			set { _checkItemCode3 = value; }
		}

		/// public propaty name  :  CheckItemCode4
		/// <summary>�`�F�b�N���ڃR�[�h4�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�F�b�N���ڃR�[�h4�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CheckItemCode4
		{
			get { return _checkItemCode4; }
			set { _checkItemCode4 = value; }
		}

		/// public propaty name  :  CheckItemCode5
		/// <summary>�`�F�b�N���ڃR�[�h5�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�F�b�N���ڃR�[�h5�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CheckItemCode5
		{
			get { return _checkItemCode5; }
			set { _checkItemCode5 = value; }
		}

		/// public propaty name  :  CheckItemCode6
		/// <summary>�`�F�b�N���ڃR�[�h6�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�F�b�N���ڃR�[�h6�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CheckItemCode6
		{
			get { return _checkItemCode6; }
			set { _checkItemCode6 = value; }
		}

		/// public propaty name  :  CheckItemCode7
		/// <summary>�`�F�b�N���ڃR�[�h7�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�F�b�N���ڃR�[�h7�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CheckItemCode7
		{
			get { return _checkItemCode7; }
			set { _checkItemCode7 = value; }
		}

		/// public propaty name  :  CheckItemCode8
		/// <summary>�`�F�b�N���ڃR�[�h8�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�F�b�N���ڃR�[�h8�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CheckItemCode8
		{
			get { return _checkItemCode8; }
			set { _checkItemCode8 = value; }
		}

		/// public propaty name  :  CheckItemCode9
		/// <summary>�`�F�b�N���ڃR�[�h9�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�F�b�N���ڃR�[�h9�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CheckItemCode9
		{
			get { return _checkItemCode9; }
			set { _checkItemCode9 = value; }
		}

		/// public propaty name  :  CheckItemCode10
		/// <summary>�`�F�b�N���ڃR�[�h10�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �`�F�b�N���ڃR�[�h10�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CheckItemCode10
		{
			get { return _checkItemCode10; }
			set { _checkItemCode10 = value; }
		}

		/// public propaty name  :  FileNm
		/// <summary>�t�@�C�����̃v���p�e�B</summary>
		/// <value>DB�̃e�[�u��ID</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �t�@�C�����̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string FileNm
		{
			get { return _fileNm; }
			set { _fileNm = value; }
		}

		/// public propaty name  :  InputCharCnt
		/// <summary>���͌����v���p�e�B</summary>
		/// <value>�����̓��͐����Ŏg�p</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���͌����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 InputCharCnt
		{
			get { return _inputCharCnt; }
			set { _inputCharCnt = value; }
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
			get { return _enterpriseName; }
			set { _enterpriseName = value; }
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
			get { return _updEmployeeName; }
			set { _updEmployeeName = value; }
		}
		#endregion

		#region Constructor
		/// <summary>
		/// ���R���[���o�����ݒ�}�X�^�R���X�g���N�^
		/// </summary>
		/// <returns>FrePprECnd�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePprECnd�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public FrePprECnd()
		{
		}

		/// <summary>
		/// ���R���[���o�����ݒ�}�X�^�R���X�g���N�^
		/// </summary>
		/// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
		/// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
		/// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
		/// <param name="outputFormFileName">�o�̓t�@�C����(�t�H�[���t�@�C��ID or �t�H�[�}�b�g�t�@�C��ID)</param>
		/// <param name="userPrtPprIdDerivNo">���[�U�[���[ID�}�ԍ�</param>
		/// <param name="frePrtPprExtraCondCd">���R���[���o�����}��</param>
		/// <param name="displayOrder">�\������</param>
		/// <param name="extraConditionDivCd">���o�����敪(0:�g�p�s��,1:���l�^,2:�����^�i���p�j,3:�����^�i�S�p�j,4:���t�^,5:�R���{�^,6:�`�F�b�N�^)</param>
		/// <param name="extraConditionTypeCd">���o�����^�C�v(0:��v,1:�͈�,2:�����܂�,3:����)</param>
		/// <param name="extraConditionTitle">���o�����^�C�g��</param>
		/// <param name="dDCharCnt">DD����</param>
		/// <param name="dDName">DD����(�������œo�^)</param>
		/// <param name="stExtraNumCode">���o�J�n�R�[�h�i���l�j</param>
		/// <param name="edExtraNumCode">���o�I���R�[�h�i���l�j</param>
		/// <param name="stExtraCharCode">���o�J�n�R�[�h�i�����j</param>
		/// <param name="edExtraCharCode">���o�I���R�[�h�i�����j</param>
		/// <param name="stExtraDateBaseCd">���o�J�n���t�i��j(0:�O�X��,1:�O��,2:�{��,3:����,4:���X��,5:���t�w��)</param>
		/// <param name="stExtraDateSignCd">���o�J�n���t�i�����j(0:�{�i�v���X�j,1:�|�i�}�C�i�X�j)</param>
		/// <param name="stExtraDateNum">���o�J�n���t�i���l�j</param>
		/// <param name="stExtraDateUnitCd">���o�J�n���t�i�P�ʁj(0:��,1:�T,2:��,3:�N)</param>
		/// <param name="startExtraDate">���o�J�n���t�i���t�j</param>
		/// <param name="edExtraDateBaseCd">���o�I�����t�i��j(0:�O�X��,1:�O��,2:�{��,3:����,4:���X��,5:���t�w��)</param>
		/// <param name="edExtraDateSignCd">���o�I�����t�i�����j(0:�{�i�v���X�j,1:�|�i�}�C�i�X�j)</param>
		/// <param name="edExtraDateNum">���o�I�����t�i���l�j</param>
		/// <param name="edExtraDateUnitCd">���o�I�����t�i�P�ʁj(0:��,1:�T,2:��,3:�N)</param>
		/// <param name="endExtraDate">���o�I�����t�i���t�j</param>
		/// <param name="extraCondDetailGrpCd">���o�������׃O���[�v�R�[�h(���o�����敪���R���{�{�b�N�X�^�̎��Ɏg�p)</param>
		/// <param name="necessaryExtraCondCd">�K�{���o�����敪(0:�C��,1:�K�{)</param>
		/// <param name="checkItemCode1">�`�F�b�N���ڃR�[�h1</param>
		/// <param name="checkItemCode2">�`�F�b�N���ڃR�[�h2</param>
		/// <param name="checkItemCode3">�`�F�b�N���ڃR�[�h3</param>
		/// <param name="checkItemCode4">�`�F�b�N���ڃR�[�h4</param>
		/// <param name="checkItemCode5">�`�F�b�N���ڃR�[�h5</param>
		/// <param name="checkItemCode6">�`�F�b�N���ڃR�[�h6</param>
		/// <param name="checkItemCode7">�`�F�b�N���ڃR�[�h7</param>
		/// <param name="checkItemCode8">�`�F�b�N���ڃR�[�h8</param>
		/// <param name="checkItemCode9">�`�F�b�N���ڃR�[�h9</param>
		/// <param name="checkItemCode10">�`�F�b�N���ڃR�[�h10</param>
		/// <param name="fileNm">�t�@�C������(DB�̃e�[�u��ID)</param>
		/// <param name="inputCharCnt">���͌���(�����̓��͐����Ŏg�p)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
		/// <returns>FrePprECnd�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePprECnd�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public FrePprECnd(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string outputFormFileName, Int32 userPrtPprIdDerivNo, Int32 frePrtPprExtraCondCd, Int32 displayOrder, Int32 extraConditionDivCd, Int32 extraConditionTypeCd, string extraConditionTitle, Int32 dDCharCnt, string dDName, Int64 stExtraNumCode, Int64 edExtraNumCode, string stExtraCharCode, string edExtraCharCode, Int32 stExtraDateBaseCd, Int32 stExtraDateSignCd, Int32 stExtraDateNum, Int32 stExtraDateUnitCd, Int32 startExtraDate, Int32 edExtraDateBaseCd, Int32 edExtraDateSignCd, Int32 edExtraDateNum, Int32 edExtraDateUnitCd, Int32 endExtraDate, Int32 extraCondDetailGrpCd, Int32 necessaryExtraCondCd, Int32 checkItemCode1, Int32 checkItemCode2, Int32 checkItemCode3, Int32 checkItemCode4, Int32 checkItemCode5, Int32 checkItemCode6, Int32 checkItemCode7, Int32 checkItemCode8, Int32 checkItemCode9, Int32 checkItemCode10, string fileNm, Int32 inputCharCnt, string enterpriseName, string updEmployeeName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._outputFormFileName = outputFormFileName;
			this._userPrtPprIdDerivNo = userPrtPprIdDerivNo;
			this._frePrtPprExtraCondCd = frePrtPprExtraCondCd;
			this._displayOrder = displayOrder;
			this._extraConditionDivCd = extraConditionDivCd;
			this._extraConditionTypeCd = extraConditionTypeCd;
			this._extraConditionTitle = extraConditionTitle;
			this._dDCharCnt = dDCharCnt;
			this._dDName = dDName;
			this._stExtraNumCode = stExtraNumCode;
			this._edExtraNumCode = edExtraNumCode;
			this._stExtraCharCode = stExtraCharCode;
			this._edExtraCharCode = edExtraCharCode;
			this._stExtraDateBaseCd = stExtraDateBaseCd;
			this._stExtraDateSignCd = stExtraDateSignCd;
			this._stExtraDateNum = stExtraDateNum;
			this._stExtraDateUnitCd = stExtraDateUnitCd;
			this._startExtraDate = startExtraDate;
			this._edExtraDateBaseCd = edExtraDateBaseCd;
			this._edExtraDateSignCd = edExtraDateSignCd;
			this._edExtraDateNum = edExtraDateNum;
			this._edExtraDateUnitCd = edExtraDateUnitCd;
			this._endExtraDate = endExtraDate;
			this._extraCondDetailGrpCd = extraCondDetailGrpCd;
			this._necessaryExtraCondCd = necessaryExtraCondCd;
			this._checkItemCode1 = checkItemCode1;
			this._checkItemCode2 = checkItemCode2;
			this._checkItemCode3 = checkItemCode3;
			this._checkItemCode4 = checkItemCode4;
			this._checkItemCode5 = checkItemCode5;
			this._checkItemCode6 = checkItemCode6;
			this._checkItemCode7 = checkItemCode7;
			this._checkItemCode8 = checkItemCode8;
			this._checkItemCode9 = checkItemCode9;
			this._checkItemCode10 = checkItemCode10;
			this._fileNm = fileNm;
			this._inputCharCnt = inputCharCnt;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;

		}
		#endregion

		#region AutoGenerate PublicMethod
		/// <summary>
		/// ���R���[���o�����ݒ�}�X�^��������
		/// </summary>
		/// <returns>FrePprECnd�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����FrePprECnd�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public FrePprECnd Clone()
		{
			return new FrePprECnd(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._outputFormFileName, this._userPrtPprIdDerivNo, this._frePrtPprExtraCondCd, this._displayOrder, this._extraConditionDivCd, this._extraConditionTypeCd, this._extraConditionTitle, this._dDCharCnt, this._dDName, this._stExtraNumCode, this._edExtraNumCode, this._stExtraCharCode, this._edExtraCharCode, this._stExtraDateBaseCd, this._stExtraDateSignCd, this._stExtraDateNum, this._stExtraDateUnitCd, this._startExtraDate, this._edExtraDateBaseCd, this._edExtraDateSignCd, this._edExtraDateNum, this._edExtraDateUnitCd, this._endExtraDate, this._extraCondDetailGrpCd, this._necessaryExtraCondCd, this._checkItemCode1, this._checkItemCode2, this._checkItemCode3, this._checkItemCode4, this._checkItemCode5, this._checkItemCode6, this._checkItemCode7, this._checkItemCode8, this._checkItemCode9, this._checkItemCode10, this._fileNm, this._inputCharCnt, this._enterpriseName, this._updEmployeeName);
		}

		/// <summary>
		/// ���R���[���o�����ݒ�}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�FrePprECnd�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePprECnd�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(FrePprECnd target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.OutputFormFileName == target.OutputFormFileName)
				 && (this.UserPrtPprIdDerivNo == target.UserPrtPprIdDerivNo)
				 && (this.FrePrtPprExtraCondCd == target.FrePrtPprExtraCondCd)
				 && (this.DisplayOrder == target.DisplayOrder)
				 && (this.ExtraConditionDivCd == target.ExtraConditionDivCd)
				 && (this.ExtraConditionTypeCd == target.ExtraConditionTypeCd)
				 && (this.ExtraConditionTitle == target.ExtraConditionTitle)
				 && (this.DDCharCnt == target.DDCharCnt)
				 && (this.DDName == target.DDName)
				 && (this.StExtraNumCode == target.StExtraNumCode)
				 && (this.EdExtraNumCode == target.EdExtraNumCode)
				 && (this.StExtraCharCode == target.StExtraCharCode)
				 && (this.EdExtraCharCode == target.EdExtraCharCode)
				 && (this.StExtraDateBaseCd == target.StExtraDateBaseCd)
				 && (this.StExtraDateSignCd == target.StExtraDateSignCd)
				 && (this.StExtraDateNum == target.StExtraDateNum)
				 && (this.StExtraDateUnitCd == target.StExtraDateUnitCd)
				 && (this.StartExtraDate == target.StartExtraDate)
				 && (this.EdExtraDateBaseCd == target.EdExtraDateBaseCd)
				 && (this.EdExtraDateSignCd == target.EdExtraDateSignCd)
				 && (this.EdExtraDateNum == target.EdExtraDateNum)
				 && (this.EdExtraDateUnitCd == target.EdExtraDateUnitCd)
				 && (this.EndExtraDate == target.EndExtraDate)
				 && (this.ExtraCondDetailGrpCd == target.ExtraCondDetailGrpCd)
				 && (this.NecessaryExtraCondCd == target.NecessaryExtraCondCd)
				 && (this.CheckItemCode1 == target.CheckItemCode1)
				 && (this.CheckItemCode2 == target.CheckItemCode2)
				 && (this.CheckItemCode3 == target.CheckItemCode3)
				 && (this.CheckItemCode4 == target.CheckItemCode4)
				 && (this.CheckItemCode5 == target.CheckItemCode5)
				 && (this.CheckItemCode6 == target.CheckItemCode6)
				 && (this.CheckItemCode7 == target.CheckItemCode7)
				 && (this.CheckItemCode8 == target.CheckItemCode8)
				 && (this.CheckItemCode9 == target.CheckItemCode9)
				 && (this.CheckItemCode10 == target.CheckItemCode10)
				 && (this.FileNm == target.FileNm)
				 && (this.InputCharCnt == target.InputCharCnt)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName));
		}

		/// <summary>
		/// ���R���[���o�����ݒ�}�X�^��r����
		/// </summary>
		/// <param name="frePprECnd1">
		///                    ��r����FrePprECnd�N���X�̃C���X�^���X
		/// </param>
		/// <param name="frePprECnd2">��r����FrePprECnd�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePprECnd�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(FrePprECnd frePprECnd1, FrePprECnd frePprECnd2)
		{
			return ((frePprECnd1.CreateDateTime == frePprECnd2.CreateDateTime)
				 && (frePprECnd1.UpdateDateTime == frePprECnd2.UpdateDateTime)
				 && (frePprECnd1.EnterpriseCode == frePprECnd2.EnterpriseCode)
				 && (frePprECnd1.FileHeaderGuid == frePprECnd2.FileHeaderGuid)
				 && (frePprECnd1.UpdEmployeeCode == frePprECnd2.UpdEmployeeCode)
				 && (frePprECnd1.UpdAssemblyId1 == frePprECnd2.UpdAssemblyId1)
				 && (frePprECnd1.UpdAssemblyId2 == frePprECnd2.UpdAssemblyId2)
				 && (frePprECnd1.LogicalDeleteCode == frePprECnd2.LogicalDeleteCode)
				 && (frePprECnd1.OutputFormFileName == frePprECnd2.OutputFormFileName)
				 && (frePprECnd1.UserPrtPprIdDerivNo == frePprECnd2.UserPrtPprIdDerivNo)
				 && (frePprECnd1.FrePrtPprExtraCondCd == frePprECnd2.FrePrtPprExtraCondCd)
				 && (frePprECnd1.DisplayOrder == frePprECnd2.DisplayOrder)
				 && (frePprECnd1.ExtraConditionDivCd == frePprECnd2.ExtraConditionDivCd)
				 && (frePprECnd1.ExtraConditionTypeCd == frePprECnd2.ExtraConditionTypeCd)
				 && (frePprECnd1.ExtraConditionTitle == frePprECnd2.ExtraConditionTitle)
				 && (frePprECnd1.DDCharCnt == frePprECnd2.DDCharCnt)
				 && (frePprECnd1.DDName == frePprECnd2.DDName)
				 && (frePprECnd1.StExtraNumCode == frePprECnd2.StExtraNumCode)
				 && (frePprECnd1.EdExtraNumCode == frePprECnd2.EdExtraNumCode)
				 && (frePprECnd1.StExtraCharCode == frePprECnd2.StExtraCharCode)
				 && (frePprECnd1.EdExtraCharCode == frePprECnd2.EdExtraCharCode)
				 && (frePprECnd1.StExtraDateBaseCd == frePprECnd2.StExtraDateBaseCd)
				 && (frePprECnd1.StExtraDateSignCd == frePprECnd2.StExtraDateSignCd)
				 && (frePprECnd1.StExtraDateNum == frePprECnd2.StExtraDateNum)
				 && (frePprECnd1.StExtraDateUnitCd == frePprECnd2.StExtraDateUnitCd)
				 && (frePprECnd1.StartExtraDate == frePprECnd2.StartExtraDate)
				 && (frePprECnd1.EdExtraDateBaseCd == frePprECnd2.EdExtraDateBaseCd)
				 && (frePprECnd1.EdExtraDateSignCd == frePprECnd2.EdExtraDateSignCd)
				 && (frePprECnd1.EdExtraDateNum == frePprECnd2.EdExtraDateNum)
				 && (frePprECnd1.EdExtraDateUnitCd == frePprECnd2.EdExtraDateUnitCd)
				 && (frePprECnd1.EndExtraDate == frePprECnd2.EndExtraDate)
				 && (frePprECnd1.ExtraCondDetailGrpCd == frePprECnd2.ExtraCondDetailGrpCd)
				 && (frePprECnd1.NecessaryExtraCondCd == frePprECnd2.NecessaryExtraCondCd)
				 && (frePprECnd1.CheckItemCode1 == frePprECnd2.CheckItemCode1)
				 && (frePprECnd1.CheckItemCode2 == frePprECnd2.CheckItemCode2)
				 && (frePprECnd1.CheckItemCode3 == frePprECnd2.CheckItemCode3)
				 && (frePprECnd1.CheckItemCode4 == frePprECnd2.CheckItemCode4)
				 && (frePprECnd1.CheckItemCode5 == frePprECnd2.CheckItemCode5)
				 && (frePprECnd1.CheckItemCode6 == frePprECnd2.CheckItemCode6)
				 && (frePprECnd1.CheckItemCode7 == frePprECnd2.CheckItemCode7)
				 && (frePprECnd1.CheckItemCode8 == frePprECnd2.CheckItemCode8)
				 && (frePprECnd1.CheckItemCode9 == frePprECnd2.CheckItemCode9)
				 && (frePprECnd1.CheckItemCode10 == frePprECnd2.CheckItemCode10)
				 && (frePprECnd1.FileNm == frePprECnd2.FileNm)
				 && (frePprECnd1.InputCharCnt == frePprECnd2.InputCharCnt)
				 && (frePprECnd1.EnterpriseName == frePprECnd2.EnterpriseName)
				 && (frePprECnd1.UpdEmployeeName == frePprECnd2.UpdEmployeeName));
		}
		/// <summary>
		/// ���R���[���o�����ݒ�}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�FrePprECnd�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePprECnd�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(FrePprECnd target)
		{
			ArrayList resList = new ArrayList();
			if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
			if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
			if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
			if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
			if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
			if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
			if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
			if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
			if (this.OutputFormFileName != target.OutputFormFileName) resList.Add("OutputFormFileName");
			if (this.UserPrtPprIdDerivNo != target.UserPrtPprIdDerivNo) resList.Add("UserPrtPprIdDerivNo");
			if (this.FrePrtPprExtraCondCd != target.FrePrtPprExtraCondCd) resList.Add("FrePrtPprExtraCondCd");
			if (this.DisplayOrder != target.DisplayOrder) resList.Add("DisplayOrder");
			if (this.ExtraConditionDivCd != target.ExtraConditionDivCd) resList.Add("ExtraConditionDivCd");
			if (this.ExtraConditionTypeCd != target.ExtraConditionTypeCd) resList.Add("ExtraConditionTypeCd");
			if (this.ExtraConditionTitle != target.ExtraConditionTitle) resList.Add("ExtraConditionTitle");
			if (this.DDCharCnt != target.DDCharCnt) resList.Add("DDCharCnt");
			if (this.DDName != target.DDName) resList.Add("DDName");
			if (this.StExtraNumCode != target.StExtraNumCode) resList.Add("StExtraNumCode");
			if (this.EdExtraNumCode != target.EdExtraNumCode) resList.Add("EdExtraNumCode");
			if (this.StExtraCharCode != target.StExtraCharCode) resList.Add("StExtraCharCode");
			if (this.EdExtraCharCode != target.EdExtraCharCode) resList.Add("EdExtraCharCode");
			if (this.StExtraDateBaseCd != target.StExtraDateBaseCd) resList.Add("StExtraDateBaseCd");
			if (this.StExtraDateSignCd != target.StExtraDateSignCd) resList.Add("StExtraDateSignCd");
			if (this.StExtraDateNum != target.StExtraDateNum) resList.Add("StExtraDateNum");
			if (this.StExtraDateUnitCd != target.StExtraDateUnitCd) resList.Add("StExtraDateUnitCd");
			if (this.StartExtraDate != target.StartExtraDate) resList.Add("StartExtraDate");
			if (this.EdExtraDateBaseCd != target.EdExtraDateBaseCd) resList.Add("EdExtraDateBaseCd");
			if (this.EdExtraDateSignCd != target.EdExtraDateSignCd) resList.Add("EdExtraDateSignCd");
			if (this.EdExtraDateNum != target.EdExtraDateNum) resList.Add("EdExtraDateNum");
			if (this.EdExtraDateUnitCd != target.EdExtraDateUnitCd) resList.Add("EdExtraDateUnitCd");
			if (this.EndExtraDate != target.EndExtraDate) resList.Add("EndExtraDate");
			if (this.ExtraCondDetailGrpCd != target.ExtraCondDetailGrpCd) resList.Add("ExtraCondDetailGrpCd");
			if (this.NecessaryExtraCondCd != target.NecessaryExtraCondCd) resList.Add("NecessaryExtraCondCd");
			if (this.CheckItemCode1 != target.CheckItemCode1) resList.Add("CheckItemCode1");
			if (this.CheckItemCode2 != target.CheckItemCode2) resList.Add("CheckItemCode2");
			if (this.CheckItemCode3 != target.CheckItemCode3) resList.Add("CheckItemCode3");
			if (this.CheckItemCode4 != target.CheckItemCode4) resList.Add("CheckItemCode4");
			if (this.CheckItemCode5 != target.CheckItemCode5) resList.Add("CheckItemCode5");
			if (this.CheckItemCode6 != target.CheckItemCode6) resList.Add("CheckItemCode6");
			if (this.CheckItemCode7 != target.CheckItemCode7) resList.Add("CheckItemCode7");
			if (this.CheckItemCode8 != target.CheckItemCode8) resList.Add("CheckItemCode8");
			if (this.CheckItemCode9 != target.CheckItemCode9) resList.Add("CheckItemCode9");
			if (this.CheckItemCode10 != target.CheckItemCode10) resList.Add("CheckItemCode10");
			if (this.FileNm != target.FileNm) resList.Add("FileNm");
			if (this.InputCharCnt != target.InputCharCnt) resList.Add("InputCharCnt");
			if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
			if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

			return resList;
		}

		/// <summary>
		/// ���R���[���o�����ݒ�}�X�^��r����
		/// </summary>
		/// <param name="frePprECnd1">��r����FrePprECnd�N���X�̃C���X�^���X</param>
		/// <param name="frePprECnd2">��r����FrePprECnd�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePprECnd�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(FrePprECnd frePprECnd1, FrePprECnd frePprECnd2)
		{
			ArrayList resList = new ArrayList();
			if (frePprECnd1.CreateDateTime != frePprECnd2.CreateDateTime) resList.Add("CreateDateTime");
			if (frePprECnd1.UpdateDateTime != frePprECnd2.UpdateDateTime) resList.Add("UpdateDateTime");
			if (frePprECnd1.EnterpriseCode != frePprECnd2.EnterpriseCode) resList.Add("EnterpriseCode");
			if (frePprECnd1.FileHeaderGuid != frePprECnd2.FileHeaderGuid) resList.Add("FileHeaderGuid");
			if (frePprECnd1.UpdEmployeeCode != frePprECnd2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
			if (frePprECnd1.UpdAssemblyId1 != frePprECnd2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
			if (frePprECnd1.UpdAssemblyId2 != frePprECnd2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
			if (frePprECnd1.LogicalDeleteCode != frePprECnd2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
			if (frePprECnd1.OutputFormFileName != frePprECnd2.OutputFormFileName) resList.Add("OutputFormFileName");
			if (frePprECnd1.UserPrtPprIdDerivNo != frePprECnd2.UserPrtPprIdDerivNo) resList.Add("UserPrtPprIdDerivNo");
			if (frePprECnd1.FrePrtPprExtraCondCd != frePprECnd2.FrePrtPprExtraCondCd) resList.Add("FrePrtPprExtraCondCd");
			if (frePprECnd1.DisplayOrder != frePprECnd2.DisplayOrder) resList.Add("DisplayOrder");
			if (frePprECnd1.ExtraConditionDivCd != frePprECnd2.ExtraConditionDivCd) resList.Add("ExtraConditionDivCd");
			if (frePprECnd1.ExtraConditionTypeCd != frePprECnd2.ExtraConditionTypeCd) resList.Add("ExtraConditionTypeCd");
			if (frePprECnd1.ExtraConditionTitle != frePprECnd2.ExtraConditionTitle) resList.Add("ExtraConditionTitle");
			if (frePprECnd1.DDCharCnt != frePprECnd2.DDCharCnt) resList.Add("DDCharCnt");
			if (frePprECnd1.DDName != frePprECnd2.DDName) resList.Add("DDName");
			if (frePprECnd1.StExtraNumCode != frePprECnd2.StExtraNumCode) resList.Add("StExtraNumCode");
			if (frePprECnd1.EdExtraNumCode != frePprECnd2.EdExtraNumCode) resList.Add("EdExtraNumCode");
			if (frePprECnd1.StExtraCharCode != frePprECnd2.StExtraCharCode) resList.Add("StExtraCharCode");
			if (frePprECnd1.EdExtraCharCode != frePprECnd2.EdExtraCharCode) resList.Add("EdExtraCharCode");
			if (frePprECnd1.StExtraDateBaseCd != frePprECnd2.StExtraDateBaseCd) resList.Add("StExtraDateBaseCd");
			if (frePprECnd1.StExtraDateSignCd != frePprECnd2.StExtraDateSignCd) resList.Add("StExtraDateSignCd");
			if (frePprECnd1.StExtraDateNum != frePprECnd2.StExtraDateNum) resList.Add("StExtraDateNum");
			if (frePprECnd1.StExtraDateUnitCd != frePprECnd2.StExtraDateUnitCd) resList.Add("StExtraDateUnitCd");
			if (frePprECnd1.StartExtraDate != frePprECnd2.StartExtraDate) resList.Add("StartExtraDate");
			if (frePprECnd1.EdExtraDateBaseCd != frePprECnd2.EdExtraDateBaseCd) resList.Add("EdExtraDateBaseCd");
			if (frePprECnd1.EdExtraDateSignCd != frePprECnd2.EdExtraDateSignCd) resList.Add("EdExtraDateSignCd");
			if (frePprECnd1.EdExtraDateNum != frePprECnd2.EdExtraDateNum) resList.Add("EdExtraDateNum");
			if (frePprECnd1.EdExtraDateUnitCd != frePprECnd2.EdExtraDateUnitCd) resList.Add("EdExtraDateUnitCd");
			if (frePprECnd1.EndExtraDate != frePprECnd2.EndExtraDate) resList.Add("EndExtraDate");
			if (frePprECnd1.ExtraCondDetailGrpCd != frePprECnd2.ExtraCondDetailGrpCd) resList.Add("ExtraCondDetailGrpCd");
			if (frePprECnd1.NecessaryExtraCondCd != frePprECnd2.NecessaryExtraCondCd) resList.Add("NecessaryExtraCondCd");
			if (frePprECnd1.CheckItemCode1 != frePprECnd2.CheckItemCode1) resList.Add("CheckItemCode1");
			if (frePprECnd1.CheckItemCode2 != frePprECnd2.CheckItemCode2) resList.Add("CheckItemCode2");
			if (frePprECnd1.CheckItemCode3 != frePprECnd2.CheckItemCode3) resList.Add("CheckItemCode3");
			if (frePprECnd1.CheckItemCode4 != frePprECnd2.CheckItemCode4) resList.Add("CheckItemCode4");
			if (frePprECnd1.CheckItemCode5 != frePprECnd2.CheckItemCode5) resList.Add("CheckItemCode5");
			if (frePprECnd1.CheckItemCode6 != frePprECnd2.CheckItemCode6) resList.Add("CheckItemCode6");
			if (frePprECnd1.CheckItemCode7 != frePprECnd2.CheckItemCode7) resList.Add("CheckItemCode7");
			if (frePprECnd1.CheckItemCode8 != frePprECnd2.CheckItemCode8) resList.Add("CheckItemCode8");
			if (frePprECnd1.CheckItemCode9 != frePprECnd2.CheckItemCode9) resList.Add("CheckItemCode9");
			if (frePprECnd1.CheckItemCode10 != frePprECnd2.CheckItemCode10) resList.Add("CheckItemCode10");
			if (frePprECnd1.FileNm != frePprECnd2.FileNm) resList.Add("FileNm");
			if (frePprECnd1.InputCharCnt != frePprECnd2.InputCharCnt) resList.Add("InputCharCnt");
			if (frePprECnd1.EnterpriseName != frePprECnd2.EnterpriseName) resList.Add("EnterpriseName");
			if (frePprECnd1.UpdEmployeeName != frePprECnd2.UpdEmployeeName) resList.Add("UpdEmployeeName");

			return resList;
		}
		#endregion

		#region Property
		/// public propaty name  :  UsedFlg
		/// <summary>�g�p�敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �g�p�敪�v���p�e�B</br>
		/// <br>Programer        :   2007/04/03 22024 ����_�u</br>
		/// </remarks>
		public Int32 UsedFlg
		{
			get {
				if (_displayOrder <= 0 || _displayOrder >= 999)
					return 0;
				else
					return 1;
			}
			// Serialize���ɖ��O�������s�̌����ƂȂ��
			// set�A�N�Z�T���p��
			set { }
		}
		#endregion

		#region PublicMethod
		/// <summary>
		/// ���R���[���o�����ݒ�}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�FrePprECnd�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note			:   FrePprECnd�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer		:   2007/04/03 22024 ����_�u</br>
		/// </remarks>
		public bool EqualsWithoutSystemDate(FrePprECnd target)
		{
			bool isEqual;

			// ���t�^�̏ꍇ
			if (this.ExtraConditionDivCd == 4)
			{
				isEqual = ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.OutputFormFileName == target.OutputFormFileName)
				 && (this.UserPrtPprIdDerivNo == target.UserPrtPprIdDerivNo)
				 && (this.FrePrtPprExtraCondCd == target.FrePrtPprExtraCondCd)
				 && (this.DisplayOrder == target.DisplayOrder)
				 && (this.ExtraConditionDivCd == target.ExtraConditionDivCd)
				 && (this.ExtraConditionTypeCd == target.ExtraConditionTypeCd)
				 && (this.ExtraConditionTitle == target.ExtraConditionTitle)
				 && (this.DDCharCnt == target.DDCharCnt)
				 && (this.DDName == target.DDName)
				 && (this.StExtraNumCode == target.StExtraNumCode)
				 && (this.EdExtraNumCode == target.EdExtraNumCode)
				 && (this.StExtraCharCode == target.StExtraCharCode)
				 && (this.EdExtraCharCode == target.EdExtraCharCode)
				 && (this.StExtraDateBaseCd == target.StExtraDateBaseCd)
				 && (this.StExtraDateSignCd == target.StExtraDateSignCd)
				 && (this.StExtraDateNum == target.StExtraDateNum)
				 && (this.StExtraDateUnitCd == target.StExtraDateUnitCd)
				 && (this.EdExtraDateBaseCd == target.EdExtraDateBaseCd)
				 && (this.EdExtraDateSignCd == target.EdExtraDateSignCd)
				 && (this.EdExtraDateNum == target.EdExtraDateNum)
				 && (this.EdExtraDateUnitCd == target.EdExtraDateUnitCd)
				 && (this.ExtraCondDetailGrpCd == target.ExtraCondDetailGrpCd)
				 && (this.NecessaryExtraCondCd == target.NecessaryExtraCondCd)
				 && (this.CheckItemCode1 == target.CheckItemCode1)
				 && (this.CheckItemCode2 == target.CheckItemCode2)
				 && (this.CheckItemCode3 == target.CheckItemCode3)
				 && (this.CheckItemCode4 == target.CheckItemCode4)
				 && (this.CheckItemCode5 == target.CheckItemCode5)
				 && (this.CheckItemCode6 == target.CheckItemCode6)
				 && (this.CheckItemCode7 == target.CheckItemCode7)
				 && (this.CheckItemCode8 == target.CheckItemCode8)
				 && (this.CheckItemCode9 == target.CheckItemCode9)
				 && (this.CheckItemCode10 == target.CheckItemCode10)
				 && (this.FileNm == target.FileNm)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName)
				 && (this.UsedFlg == target.UsedFlg)
				 );

				if (isEqual)
				{
					switch (this.ExtraConditionTypeCd)
					{
						case 0:	// ��v
						{
							if (this.StExtraNumCode == 0)
								isEqual = this.StartExtraDate.Equals(target.StartExtraDate);
							break;
						}
						case 1:	// �͈�
						{
							if (this.StExtraNumCode == 0)
								isEqual = this.StartExtraDate.Equals(target.StartExtraDate);
							if (isEqual && this.EdExtraNumCode == 0)
								isEqual = this.EndExtraDate.Equals(target.EndExtraDate);
							break;
						}
						case 3:	// �J�n���
						{
							if (this.StExtraDateBaseCd == 5)	// ���t�w��
								isEqual = this.StartExtraDate.Equals(target.StartExtraDate);
							break;
						}
						case 4:	// �I�����
						{
							if (this.EdExtraDateBaseCd == 5)	// ���t�w��
								isEqual = this.EndExtraDate.Equals(target.EndExtraDate);
							break;
						}
					}
				}
			}
			else
			{
				isEqual = this.Equals(target);
			}

			return isEqual;
		}
		#endregion
	}
}

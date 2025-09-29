using System;
using System.Collections;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   FrePprECndWork
	/// <summary>
	///                      ���R���[���o�����ݒ胏�[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���R���[���o�����ݒ胏�[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2007/03/15</br>
	/// <br>Genarated Date   :   2007/07/19  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class FrePprECndWork : IFileHeader
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
		/// <remarks>0:��v,1:�͈�,2:�����܂�,3:���ԁi�J�n����j,4:���ԁi�I������j,5:����v,6:���͈�</remarks>
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
		private Int32 _checkItemCode1;

		/// <summary>�`�F�b�N���ڃR�[�h2</summary>
		private Int32 _checkItemCode2;

		/// <summary>�`�F�b�N���ڃR�[�h3</summary>
		private Int32 _checkItemCode3;

		/// <summary>�`�F�b�N���ڃR�[�h4</summary>
		private Int32 _checkItemCode4;

		/// <summary>�`�F�b�N���ڃR�[�h5</summary>
		private Int32 _checkItemCode5;

		/// <summary>�`�F�b�N���ڃR�[�h6</summary>
		private Int32 _checkItemCode6;

		/// <summary>�`�F�b�N���ڃR�[�h7</summary>
		private Int32 _checkItemCode7;

		/// <summary>�`�F�b�N���ڃR�[�h8</summary>
		private Int32 _checkItemCode8;

		/// <summary>�`�F�b�N���ڃR�[�h9</summary>
		private Int32 _checkItemCode9;

		/// <summary>�`�F�b�N���ڃR�[�h10</summary>
		private Int32 _checkItemCode10;

		/// <summary>�t�@�C������</summary>
		/// <remarks>DB�̃e�[�u��ID</remarks>
		private string _fileNm = "";

		/// <summary>���͌���</summary>
		/// <remarks>�����̓��͐����Ŏg�p</remarks>
		private Int32 _inputCharCnt;


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
		/// <value>0:��v,1:�͈�,2:�����܂�,3:���ԁi�J�n����j,4:���ԁi�I������j,5:����v,6:���͈�</value>
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


		/// <summary>
		/// ���R���[���o�����ݒ胏�[�N�R���X�g���N�^
		/// </summary>
		/// <returns>FrePprECndWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePprECndWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public FrePprECndWork()
		{
		}

	}

	/// <summary>
	///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
	/// </summary>
	/// <returns>FrePprECndWork�N���X�̃C���X�^���X(object)</returns>
	/// <remarks>
	/// <br>Note�@�@�@�@�@�@ :   FrePprECndWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
	/// <br>Programer        :   ��������</br>
	/// </remarks>
	public class FrePprECndWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate �����o

		/// <summary>
		///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePprECndWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  FrePprECndWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is FrePprECndWork || graph is ArrayList || graph is FrePprECndWork[]))
				throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(FrePprECndWork).FullName));

			if (graph != null && graph is FrePprECndWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.FrePprECndWork");

			//�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
			int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is FrePprECndWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((FrePprECndWork[])graph).Length;
			}
			else if (graph is FrePprECndWork)
			{
				serInfo.RetTypeInfo = 1;
				occurrence = 1;
			}

			serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

			//�쐬����
			serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
			//�X�V����
			serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
			//��ƃR�[�h
			serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
			//GUID
			serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
			//�X�V�]�ƈ��R�[�h
			serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
			//�X�V�A�Z���u��ID1
			serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
			//�X�V�A�Z���u��ID2
			serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
			//�_���폜�敪
			serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
			//�o�̓t�@�C����
			serInfo.MemberInfo.Add(typeof(string)); //OutputFormFileName
			//���[�U�[���[ID�}�ԍ�
			serInfo.MemberInfo.Add(typeof(Int32)); //UserPrtPprIdDerivNo
			//���R���[���o�����}��
			serInfo.MemberInfo.Add(typeof(Int32)); //FrePrtPprExtraCondCd
			//�\������
			serInfo.MemberInfo.Add(typeof(Int32)); //DisplayOrder
			//���o�����敪
			serInfo.MemberInfo.Add(typeof(Int32)); //ExtraConditionDivCd
			//���o�����^�C�v
			serInfo.MemberInfo.Add(typeof(Int32)); //ExtraConditionTypeCd
			//���o�����^�C�g��
			serInfo.MemberInfo.Add(typeof(string)); //ExtraConditionTitle
			//DD����
			serInfo.MemberInfo.Add(typeof(Int32)); //DDCharCnt
			//DD����
			serInfo.MemberInfo.Add(typeof(string)); //DDName
			//���o�J�n�R�[�h�i���l�j
			serInfo.MemberInfo.Add(typeof(Int64)); //StExtraNumCode
			//���o�I���R�[�h�i���l�j
			serInfo.MemberInfo.Add(typeof(Int64)); //EdExtraNumCode
			//���o�J�n�R�[�h�i�����j
			serInfo.MemberInfo.Add(typeof(string)); //StExtraCharCode
			//���o�I���R�[�h�i�����j
			serInfo.MemberInfo.Add(typeof(string)); //EdExtraCharCode
			//���o�J�n���t�i��j
			serInfo.MemberInfo.Add(typeof(Int32)); //StExtraDateBaseCd
			//���o�J�n���t�i�����j
			serInfo.MemberInfo.Add(typeof(Int32)); //StExtraDateSignCd
			//���o�J�n���t�i���l�j
			serInfo.MemberInfo.Add(typeof(Int32)); //StExtraDateNum
			//���o�J�n���t�i�P�ʁj
			serInfo.MemberInfo.Add(typeof(Int32)); //StExtraDateUnitCd
			//���o�J�n���t�i���t�j
			serInfo.MemberInfo.Add(typeof(Int32)); //StartExtraDate
			//���o�I�����t�i��j
			serInfo.MemberInfo.Add(typeof(Int32)); //EdExtraDateBaseCd
			//���o�I�����t�i�����j
			serInfo.MemberInfo.Add(typeof(Int32)); //EdExtraDateSignCd
			//���o�I�����t�i���l�j
			serInfo.MemberInfo.Add(typeof(Int32)); //EdExtraDateNum
			//���o�I�����t�i�P�ʁj
			serInfo.MemberInfo.Add(typeof(Int32)); //EdExtraDateUnitCd
			//���o�I�����t�i���t�j
			serInfo.MemberInfo.Add(typeof(Int32)); //EndExtraDate
			//���o�������׃O���[�v�R�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //ExtraCondDetailGrpCd
			//�K�{���o�����敪
			serInfo.MemberInfo.Add(typeof(Int32)); //NecessaryExtraCondCd
			//�`�F�b�N���ڃR�[�h1
			serInfo.MemberInfo.Add(typeof(Int32)); //CheckItemCode1
			//�`�F�b�N���ڃR�[�h2
			serInfo.MemberInfo.Add(typeof(Int32)); //CheckItemCode2
			//�`�F�b�N���ڃR�[�h3
			serInfo.MemberInfo.Add(typeof(Int32)); //CheckItemCode3
			//�`�F�b�N���ڃR�[�h4
			serInfo.MemberInfo.Add(typeof(Int32)); //CheckItemCode4
			//�`�F�b�N���ڃR�[�h5
			serInfo.MemberInfo.Add(typeof(Int32)); //CheckItemCode5
			//�`�F�b�N���ڃR�[�h6
			serInfo.MemberInfo.Add(typeof(Int32)); //CheckItemCode6
			//�`�F�b�N���ڃR�[�h7
			serInfo.MemberInfo.Add(typeof(Int32)); //CheckItemCode7
			//�`�F�b�N���ڃR�[�h8
			serInfo.MemberInfo.Add(typeof(Int32)); //CheckItemCode8
			//�`�F�b�N���ڃR�[�h9
			serInfo.MemberInfo.Add(typeof(Int32)); //CheckItemCode9
			//�`�F�b�N���ڃR�[�h10
			serInfo.MemberInfo.Add(typeof(Int32)); //CheckItemCode10
			//�t�@�C������
			serInfo.MemberInfo.Add(typeof(string)); //FileNm
			//���͌���
			serInfo.MemberInfo.Add(typeof(Int32)); //InputCharCnt


			serInfo.Serialize(writer, serInfo);
			if (graph is FrePprECndWork)
			{
				FrePprECndWork temp = (FrePprECndWork)graph;

				SetFrePprECndWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is FrePprECndWork[])
				{
					lst = new ArrayList();
					lst.AddRange((FrePprECndWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (FrePprECndWork temp in lst)
				{
					SetFrePprECndWork(writer, temp);
				}

			}


		}


		/// <summary>
		/// FrePprECndWork�����o��(public�v���p�e�B��)
		/// </summary>
		private const int currentMemberCount = 45;

		/// <summary>
		///  FrePprECndWork�C���X�^���X��������
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePprECndWork�̃C���X�^���X����������</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private void SetFrePprECndWork(System.IO.BinaryWriter writer, FrePprECndWork temp)
		{
			//�쐬����
			writer.Write((Int64)temp.CreateDateTime.Ticks);
			//�X�V����
			writer.Write((Int64)temp.UpdateDateTime.Ticks);
			//��ƃR�[�h
			writer.Write(temp.EnterpriseCode);
			//GUID
			byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
			writer.Write(fileHeaderGuidArray.Length);
			writer.Write(temp.FileHeaderGuid.ToByteArray());
			//�X�V�]�ƈ��R�[�h
			writer.Write(temp.UpdEmployeeCode);
			//�X�V�A�Z���u��ID1
			writer.Write(temp.UpdAssemblyId1);
			//�X�V�A�Z���u��ID2
			writer.Write(temp.UpdAssemblyId2);
			//�_���폜�敪
			writer.Write(temp.LogicalDeleteCode);
			//�o�̓t�@�C����
			writer.Write(temp.OutputFormFileName);
			//���[�U�[���[ID�}�ԍ�
			writer.Write(temp.UserPrtPprIdDerivNo);
			//���R���[���o�����}��
			writer.Write(temp.FrePrtPprExtraCondCd);
			//�\������
			writer.Write(temp.DisplayOrder);
			//���o�����敪
			writer.Write(temp.ExtraConditionDivCd);
			//���o�����^�C�v
			writer.Write(temp.ExtraConditionTypeCd);
			//���o�����^�C�g��
			writer.Write(temp.ExtraConditionTitle);
			//DD����
			writer.Write(temp.DDCharCnt);
			//DD����
			writer.Write(temp.DDName);
			//���o�J�n�R�[�h�i���l�j
			writer.Write(temp.StExtraNumCode);
			//���o�I���R�[�h�i���l�j
			writer.Write(temp.EdExtraNumCode);
			//���o�J�n�R�[�h�i�����j
			writer.Write(temp.StExtraCharCode);
			//���o�I���R�[�h�i�����j
			writer.Write(temp.EdExtraCharCode);
			//���o�J�n���t�i��j
			writer.Write(temp.StExtraDateBaseCd);
			//���o�J�n���t�i�����j
			writer.Write(temp.StExtraDateSignCd);
			//���o�J�n���t�i���l�j
			writer.Write(temp.StExtraDateNum);
			//���o�J�n���t�i�P�ʁj
			writer.Write(temp.StExtraDateUnitCd);
			//���o�J�n���t�i���t�j
			writer.Write(temp.StartExtraDate);
			//���o�I�����t�i��j
			writer.Write(temp.EdExtraDateBaseCd);
			//���o�I�����t�i�����j
			writer.Write(temp.EdExtraDateSignCd);
			//���o�I�����t�i���l�j
			writer.Write(temp.EdExtraDateNum);
			//���o�I�����t�i�P�ʁj
			writer.Write(temp.EdExtraDateUnitCd);
			//���o�I�����t�i���t�j
			writer.Write(temp.EndExtraDate);
			//���o�������׃O���[�v�R�[�h
			writer.Write(temp.ExtraCondDetailGrpCd);
			//�K�{���o�����敪
			writer.Write(temp.NecessaryExtraCondCd);
			//�`�F�b�N���ڃR�[�h1
			writer.Write(temp.CheckItemCode1);
			//�`�F�b�N���ڃR�[�h2
			writer.Write(temp.CheckItemCode2);
			//�`�F�b�N���ڃR�[�h3
			writer.Write(temp.CheckItemCode3);
			//�`�F�b�N���ڃR�[�h4
			writer.Write(temp.CheckItemCode4);
			//�`�F�b�N���ڃR�[�h5
			writer.Write(temp.CheckItemCode5);
			//�`�F�b�N���ڃR�[�h6
			writer.Write(temp.CheckItemCode6);
			//�`�F�b�N���ڃR�[�h7
			writer.Write(temp.CheckItemCode7);
			//�`�F�b�N���ڃR�[�h8
			writer.Write(temp.CheckItemCode8);
			//�`�F�b�N���ڃR�[�h9
			writer.Write(temp.CheckItemCode9);
			//�`�F�b�N���ڃR�[�h10
			writer.Write(temp.CheckItemCode10);
			//�t�@�C������
			writer.Write(temp.FileNm);
			//���͌���
			writer.Write(temp.InputCharCnt);

		}

		/// <summary>
		///  FrePprECndWork�C���X�^���X�擾
		/// </summary>
		/// <returns>FrePprECndWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePprECndWork�̃C���X�^���X���擾���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private FrePprECndWork GetFrePprECndWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
		{
			// V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
			// serInfo.MemberInfo.Count < currentMemberCount
			// �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

			FrePprECndWork temp = new FrePprECndWork();

			//�쐬����
			temp.CreateDateTime = new DateTime(reader.ReadInt64());
			//�X�V����
			temp.UpdateDateTime = new DateTime(reader.ReadInt64());
			//��ƃR�[�h
			temp.EnterpriseCode = reader.ReadString();
			//GUID
			int lenOfFileHeaderGuidArray = reader.ReadInt32();
			byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
			temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
			//�X�V�]�ƈ��R�[�h
			temp.UpdEmployeeCode = reader.ReadString();
			//�X�V�A�Z���u��ID1
			temp.UpdAssemblyId1 = reader.ReadString();
			//�X�V�A�Z���u��ID2
			temp.UpdAssemblyId2 = reader.ReadString();
			//�_���폜�敪
			temp.LogicalDeleteCode = reader.ReadInt32();
			//�o�̓t�@�C����
			temp.OutputFormFileName = reader.ReadString();
			//���[�U�[���[ID�}�ԍ�
			temp.UserPrtPprIdDerivNo = reader.ReadInt32();
			//���R���[���o�����}��
			temp.FrePrtPprExtraCondCd = reader.ReadInt32();
			//�\������
			temp.DisplayOrder = reader.ReadInt32();
			//���o�����敪
			temp.ExtraConditionDivCd = reader.ReadInt32();
			//���o�����^�C�v
			temp.ExtraConditionTypeCd = reader.ReadInt32();
			//���o�����^�C�g��
			temp.ExtraConditionTitle = reader.ReadString();
			//DD����
			temp.DDCharCnt = reader.ReadInt32();
			//DD����
			temp.DDName = reader.ReadString();
			//���o�J�n�R�[�h�i���l�j
			temp.StExtraNumCode = reader.ReadInt64();
			//���o�I���R�[�h�i���l�j
			temp.EdExtraNumCode = reader.ReadInt64();
			//���o�J�n�R�[�h�i�����j
			temp.StExtraCharCode = reader.ReadString();
			//���o�I���R�[�h�i�����j
			temp.EdExtraCharCode = reader.ReadString();
			//���o�J�n���t�i��j
			temp.StExtraDateBaseCd = reader.ReadInt32();
			//���o�J�n���t�i�����j
			temp.StExtraDateSignCd = reader.ReadInt32();
			//���o�J�n���t�i���l�j
			temp.StExtraDateNum = reader.ReadInt32();
			//���o�J�n���t�i�P�ʁj
			temp.StExtraDateUnitCd = reader.ReadInt32();
			//���o�J�n���t�i���t�j
			temp.StartExtraDate = reader.ReadInt32();
			//���o�I�����t�i��j
			temp.EdExtraDateBaseCd = reader.ReadInt32();
			//���o�I�����t�i�����j
			temp.EdExtraDateSignCd = reader.ReadInt32();
			//���o�I�����t�i���l�j
			temp.EdExtraDateNum = reader.ReadInt32();
			//���o�I�����t�i�P�ʁj
			temp.EdExtraDateUnitCd = reader.ReadInt32();
			//���o�I�����t�i���t�j
			temp.EndExtraDate = reader.ReadInt32();
			//���o�������׃O���[�v�R�[�h
			temp.ExtraCondDetailGrpCd = reader.ReadInt32();
			//�K�{���o�����敪
			temp.NecessaryExtraCondCd = reader.ReadInt32();
			//�`�F�b�N���ڃR�[�h1
			temp.CheckItemCode1 = reader.ReadInt32();
			//�`�F�b�N���ڃR�[�h2
			temp.CheckItemCode2 = reader.ReadInt32();
			//�`�F�b�N���ڃR�[�h3
			temp.CheckItemCode3 = reader.ReadInt32();
			//�`�F�b�N���ڃR�[�h4
			temp.CheckItemCode4 = reader.ReadInt32();
			//�`�F�b�N���ڃR�[�h5
			temp.CheckItemCode5 = reader.ReadInt32();
			//�`�F�b�N���ڃR�[�h6
			temp.CheckItemCode6 = reader.ReadInt32();
			//�`�F�b�N���ڃR�[�h7
			temp.CheckItemCode7 = reader.ReadInt32();
			//�`�F�b�N���ڃR�[�h8
			temp.CheckItemCode8 = reader.ReadInt32();
			//�`�F�b�N���ڃR�[�h9
			temp.CheckItemCode9 = reader.ReadInt32();
			//�`�F�b�N���ڃR�[�h10
			temp.CheckItemCode10 = reader.ReadInt32();
			//�t�@�C������
			temp.FileNm = reader.ReadString();
			//���͌���
			temp.InputCharCnt = reader.ReadInt32();


			//�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
			//�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
			//�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
			//�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
			for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
			{
				//byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
				//�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
				//�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
				//�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
				int optCount = 0;
				object oMemberType = serInfo.MemberInfo[k];
				if (oMemberType is Type)
				{
					Type t = (Type)oMemberType;
					object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
					if (t.Equals(typeof(int)))
					{
						optCount = Convert.ToInt32(oData);
					}
					else
					{
						optCount = 0;
					}
				}
				else if (oMemberType is string)
				{
					Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
					object userData = formatter.Deserialize(reader);  //�ǂݔ�΂�
				}
			}
			return temp;
		}

		/// <summary>
		///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
		/// </summary>
		/// <returns>FrePprECndWork�N���X�̃C���X�^���X(object)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePprECndWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
			{
				FrePprECndWork temp = GetFrePprECndWork(reader, serInfo);
				lst.Add(temp);
			}
			switch (serInfo.RetTypeInfo)
			{
				case 0:
					retValue = lst;
					break;
				case 1:
					retValue = lst[0];
					break;
				case 2:
					retValue = (FrePprECndWork[])lst.ToArray(typeof(FrePprECndWork));
					break;
			}
			return retValue;
		}

		#endregion
	}

}

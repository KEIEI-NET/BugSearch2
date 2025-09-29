using System;
using System.Collections;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   FrePrtPSetWork
	/// <summary>
	///                      ���R���[�󎚈ʒu�ݒ胏�[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���R���[�󎚈ʒu�ݒ胏�[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2007/03/15</br>
	/// <br>Genarated Date   :   2007/10/16  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class FrePrtPSetWork : IFileHeader
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

		/// <summary>���[�g�p�敪</summary>
		/// <remarks>1:���[,2:�`�[,3:DM�ꗗ�\,4:DM�͂���</remarks>
		private Int32 _printPaperUseDivcd;

		/// <summary>���[�敪�R�[�h</summary>
		private Int32 _printPaperDivCd;

		/// <summary>���o�v���O����ID</summary>
		private string _extractionPgId = "";

		/// <summary>���o�v���O�����N���XID</summary>
		/// <remarks>����v���O����ID or �e�L�X�g�o�̓v���O����ID</remarks>
		private string _extractionPgClassId = "";

		/// <summary>�o�̓v���O����ID</summary>
		private string _outputPgId = "";

		/// <summary>�o�̓v���O�����N���XID</summary>
		private string _outputPgClassId = "";

		/// <summary>�o�͊m�F���b�Z�[�W</summary>
		private string _outConfimationMsg = "";

		/// <summary>�o�͖���</summary>
		/// <remarks>�K�C�h���ɕ\�����閼��</remarks>
		private string _displayName = "";

		/// <summary>���[���[�U�[�}�ԃR�����g</summary>
		private string _prtPprUserDerivNoCmt = "";

		/// <summary>�󎚈ʒu�o�[�W����</summary>
		private Int32 _printPositionVer;

		/// <summary>�}�[�W�\�󎚈ʒu�o�[�W����</summary>
		private Int32 _mergeablePrintPosVer;

		/// <summary>�f�[�^���̓V�X�e��</summary>
		/// <remarks>0:����,1:����,2:���,3:�Ԕ�</remarks>
		private Int32 _dataInputSystem;

		/// <summary>�I�v�V�����R�[�h</summary>
		/// <remarks>���я�̵�߼�ݺ���</remarks>
		private string _optionCode = "";

		/// <summary>���R���[���ڃO���[�v�R�[�h</summary>
		private Int32 _freePrtPprItemGrpCd;

		/// <summary>���ōs��</summary>
		private Int32 _formFeedLineCount;

		/// <summary>�[���������敪</summary>
		/// <remarks>1:�[�����؎̂�,2:�t�H���g�k��</remarks>
		private Int32 _edgeCharProcDivCd;

		/// <summary>���[�w�i�摜�c�ʒu</summary>
		/// <remarks>Z9.9</remarks>
		private Double _prtPprBgImageRowPos;

		/// <summary>���[�w�i�摜���ʒu</summary>
		/// <remarks>Z9.9</remarks>
		private Double _prtPprBgImageColPos;

		/// <summary>�捞�摜�O���[�v�R�[�h</summary>
		/// <remarks>�捞�摜�̃O���[�v���ʂ��邽�߂�GUID</remarks>
		private Guid _takeInImageGroupCd;

		/// <summary>���o���_��ʋ敪</summary>
		/// <remarks>0:�g�p���Ȃ� 1:���сE���� 2:�d���E�̔�</remarks>
		private Int32 _extraSectionKindCd;

		/// <summary>���o���_�I��L��</summary>
		/// <remarks>0:�g�p���Ȃ� 1:�g�p����(�����I��) 2:�g�p����(�P�̑I��)</remarks>
		private Int32 _extraSectionSelExist;

		/// <summary>���הw�i�F(R)</summary>
		private Int32 _rDetailBackColor;

		/// <summary>���הw�i�F(G)</summary>
		private Int32 _gDetailBackColor;

		/// <summary>���הw�i�F(B)</summary>
		private Int32 _bDetailBackColor;

		/// <summary>���s������</summary>
		/// <remarks>���`�[�ō�ƁE���i���̂̉��s������</remarks>
		private Int32 _crCharCnt;

		/// <summary>���R���[ ����p�r�敪</summary>
		/// <remarks>0:�g�p���Ȃ�,1:�ē�������^�C�v,2:��p���[,3:�����͂���</remarks>
		private Int32 _freePrtPprSpPrpseCd;

		/// <summary>�󎚈ʒu�N���X�f�[�^</summary>
		private Byte[] _printPosClassData;


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

		/// public propaty name  :  PrintPaperUseDivcd
		/// <summary>���[�g�p�敪�v���p�e�B</summary>
		/// <value>1:���[,2:�`�[,3:DM�ꗗ�\,4:DM�͂���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�g�p�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrintPaperUseDivcd
		{
			get { return _printPaperUseDivcd; }
			set { _printPaperUseDivcd = value; }
		}

		/// public propaty name  :  PrintPaperDivCd
		/// <summary>���[�敪�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�敪�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrintPaperDivCd
		{
			get { return _printPaperDivCd; }
			set { _printPaperDivCd = value; }
		}

		/// public propaty name  :  ExtractionPgId
		/// <summary>���o�v���O����ID�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�v���O����ID�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ExtractionPgId
		{
			get { return _extractionPgId; }
			set { _extractionPgId = value; }
		}

		/// public propaty name  :  ExtractionPgClassId
		/// <summary>���o�v���O�����N���XID�v���p�e�B</summary>
		/// <value>����v���O����ID or �e�L�X�g�o�̓v���O����ID</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�v���O�����N���XID�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ExtractionPgClassId
		{
			get { return _extractionPgClassId; }
			set { _extractionPgClassId = value; }
		}

		/// public propaty name  :  OutputPgId
		/// <summary>�o�̓v���O����ID�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�̓v���O����ID�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string OutputPgId
		{
			get { return _outputPgId; }
			set { _outputPgId = value; }
		}

		/// public propaty name  :  OutputPgClassId
		/// <summary>�o�̓v���O�����N���XID�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�̓v���O�����N���XID�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string OutputPgClassId
		{
			get { return _outputPgClassId; }
			set { _outputPgClassId = value; }
		}

		/// public propaty name  :  OutConfimationMsg
		/// <summary>�o�͊m�F���b�Z�[�W�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�͊m�F���b�Z�[�W�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string OutConfimationMsg
		{
			get { return _outConfimationMsg; }
			set { _outConfimationMsg = value; }
		}

		/// public propaty name  :  DisplayName
		/// <summary>�o�͖��̃v���p�e�B</summary>
		/// <value>�K�C�h���ɕ\�����閼��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�͖��̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string DisplayName
		{
			get { return _displayName; }
			set { _displayName = value; }
		}

		/// public propaty name  :  PrtPprUserDerivNoCmt
		/// <summary>���[���[�U�[�}�ԃR�����g�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[���[�U�[�}�ԃR�����g�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string PrtPprUserDerivNoCmt
		{
			get { return _prtPprUserDerivNoCmt; }
			set { _prtPprUserDerivNoCmt = value; }
		}

		/// public propaty name  :  PrintPositionVer
		/// <summary>�󎚈ʒu�o�[�W�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󎚈ʒu�o�[�W�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrintPositionVer
		{
			get { return _printPositionVer; }
			set { _printPositionVer = value; }
		}

		/// public propaty name  :  MergeablePrintPosVer
		/// <summary>�}�[�W�\�󎚈ʒu�o�[�W�����v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �}�[�W�\�󎚈ʒu�o�[�W�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 MergeablePrintPosVer
		{
			get { return _mergeablePrintPosVer; }
			set { _mergeablePrintPosVer = value; }
		}

		/// public propaty name  :  DataInputSystem
		/// <summary>�f�[�^���̓V�X�e���v���p�e�B</summary>
		/// <value>0:����,1:����,2:���,3:�Ԕ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �f�[�^���̓V�X�e���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DataInputSystem
		{
			get { return _dataInputSystem; }
			set { _dataInputSystem = value; }
		}

		/// public propaty name  :  OptionCode
		/// <summary>�I�v�V�����R�[�h�v���p�e�B</summary>
		/// <value>���я�̵�߼�ݺ���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �I�v�V�����R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string OptionCode
		{
			get { return _optionCode; }
			set { _optionCode = value; }
		}

		/// public propaty name  :  FreePrtPprItemGrpCd
		/// <summary>���R���[���ڃO���[�v�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���R���[���ڃO���[�v�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 FreePrtPprItemGrpCd
		{
			get { return _freePrtPprItemGrpCd; }
			set { _freePrtPprItemGrpCd = value; }
		}

		/// public propaty name  :  FormFeedLineCount
		/// <summary>���ōs���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ōs���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 FormFeedLineCount
		{
			get { return _formFeedLineCount; }
			set { _formFeedLineCount = value; }
		}

		/// public propaty name  :  EdgeCharProcDivCd
		/// <summary>�[���������敪�v���p�e�B</summary>
		/// <value>1:�[�����؎̂�,2:�t�H���g�k��</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �[���������敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 EdgeCharProcDivCd
		{
			get { return _edgeCharProcDivCd; }
			set { _edgeCharProcDivCd = value; }
		}

		/// public propaty name  :  PrtPprBgImageRowPos
		/// <summary>���[�w�i�摜�c�ʒu�v���p�e�B</summary>
		/// <value>Z9.9</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�w�i�摜�c�ʒu�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double PrtPprBgImageRowPos
		{
			get { return _prtPprBgImageRowPos; }
			set { _prtPprBgImageRowPos = value; }
		}

		/// public propaty name  :  PrtPprBgImageColPos
		/// <summary>���[�w�i�摜���ʒu�v���p�e�B</summary>
		/// <value>Z9.9</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�w�i�摜���ʒu�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Double PrtPprBgImageColPos
		{
			get { return _prtPprBgImageColPos; }
			set { _prtPprBgImageColPos = value; }
		}

		/// public propaty name  :  TakeInImageGroupCd
		/// <summary>�捞�摜�O���[�v�R�[�h�v���p�e�B</summary>
		/// <value>�捞�摜�̃O���[�v���ʂ��邽�߂�GUID</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �捞�摜�O���[�v�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Guid TakeInImageGroupCd
		{
			get { return _takeInImageGroupCd; }
			set { _takeInImageGroupCd = value; }
		}

		/// public propaty name  :  ExtraSectionKindCd
		/// <summary>���o���_��ʋ敪�v���p�e�B</summary>
		/// <value>0:�g�p���Ȃ� 1:���сE���� 2:�d���E�̔�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o���_��ʋ敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ExtraSectionKindCd
		{
			get { return _extraSectionKindCd; }
			set { _extraSectionKindCd = value; }
		}

		/// public propaty name  :  ExtraSectionSelExist
		/// <summary>���o���_�I��L���v���p�e�B</summary>
		/// <value>0:�g�p���Ȃ� 1:�g�p����(�����I��) 2:�g�p����(�P�̑I��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o���_�I��L���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ExtraSectionSelExist
		{
			get { return _extraSectionSelExist; }
			set { _extraSectionSelExist = value; }
		}

		/// public propaty name  :  RDetailBackColor
		/// <summary>���הw�i�F(R)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���הw�i�F(R)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 RDetailBackColor
		{
			get { return _rDetailBackColor; }
			set { _rDetailBackColor = value; }
		}

		/// public propaty name  :  GDetailBackColor
		/// <summary>���הw�i�F(G)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���הw�i�F(G)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 GDetailBackColor
		{
			get { return _gDetailBackColor; }
			set { _gDetailBackColor = value; }
		}

		/// public propaty name  :  BDetailBackColor
		/// <summary>���הw�i�F(B)�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���הw�i�F(B)�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 BDetailBackColor
		{
			get { return _bDetailBackColor; }
			set { _bDetailBackColor = value; }
		}

		/// public propaty name  :  CrCharCnt
		/// <summary>���s�������v���p�e�B</summary>
		/// <value>���`�[�ō�ƁE���i���̂̉��s������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���s�������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CrCharCnt
		{
			get { return _crCharCnt; }
			set { _crCharCnt = value; }
		}

		/// public propaty name  :  FreePrtPprSpPrpseCd
		/// <summary>���R���[ ����p�r�敪�v���p�e�B</summary>
		/// <value>0:�g�p���Ȃ�,1:�ē�������^�C�v,2:��p���[,3:�����͂���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���R���[ ����p�r�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 FreePrtPprSpPrpseCd
		{
			get { return _freePrtPprSpPrpseCd; }
			set { _freePrtPprSpPrpseCd = value; }
		}

		/// public propaty name  :  PrintPosClassData
		/// <summary>�󎚈ʒu�N���X�f�[�^�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �󎚈ʒu�N���X�f�[�^�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Byte[] PrintPosClassData
		{
			get { return _printPosClassData; }
			set { _printPosClassData = value; }
		}


		/// <summary>
		/// ���R���[�󎚈ʒu�ݒ胏�[�N�R���X�g���N�^
		/// </summary>
		/// <returns>FrePrtPSetWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePrtPSetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public FrePrtPSetWork()
		{
		}

	}

	/// <summary>
	///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
	/// </summary>
	/// <returns>FrePrtPSetWork�N���X�̃C���X�^���X(object)</returns>
	/// <remarks>
	/// <br>Note�@�@�@�@�@�@ :   FrePrtPSetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
	/// <br>Programer        :   ��������</br>
	/// </remarks>
	public class FrePrtPSetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate �����o

		/// <summary>
		///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePrtPSetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  FrePrtPSetWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is FrePrtPSetWork || graph is ArrayList || graph is FrePrtPSetWork[]))
				throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(FrePrtPSetWork).FullName));

			if (graph != null && graph is FrePrtPSetWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.FrePrtPSetWork");

			//�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
			int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is FrePrtPSetWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((FrePrtPSetWork[])graph).Length;
			}
			else if (graph is FrePrtPSetWork)
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
			//���[�g�p�敪
			serInfo.MemberInfo.Add(typeof(Int32)); //PrintPaperUseDivcd
			//���[�敪�R�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //PrintPaperDivCd
			//���o�v���O����ID
			serInfo.MemberInfo.Add(typeof(string)); //ExtractionPgId
			//���o�v���O�����N���XID
			serInfo.MemberInfo.Add(typeof(string)); //ExtractionPgClassId
			//�o�̓v���O����ID
			serInfo.MemberInfo.Add(typeof(string)); //OutputPgId
			//�o�̓v���O�����N���XID
			serInfo.MemberInfo.Add(typeof(string)); //OutputPgClassId
			//�o�͊m�F���b�Z�[�W
			serInfo.MemberInfo.Add(typeof(string)); //OutConfimationMsg
			//�o�͖���
			serInfo.MemberInfo.Add(typeof(string)); //DisplayName
			//���[���[�U�[�}�ԃR�����g
			serInfo.MemberInfo.Add(typeof(string)); //PrtPprUserDerivNoCmt
			//�󎚈ʒu�o�[�W����
			serInfo.MemberInfo.Add(typeof(Int32)); //PrintPositionVer
			//�}�[�W�\�󎚈ʒu�o�[�W����
			serInfo.MemberInfo.Add(typeof(Int32)); //MergeablePrintPosVer
			//�f�[�^���̓V�X�e��
			serInfo.MemberInfo.Add(typeof(Int32)); //DataInputSystem
			//�I�v�V�����R�[�h
			serInfo.MemberInfo.Add(typeof(string)); //OptionCode
			//���R���[���ڃO���[�v�R�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //FreePrtPprItemGrpCd
			//���ōs��
			serInfo.MemberInfo.Add(typeof(Int32)); //FormFeedLineCount
			//�[���������敪
			serInfo.MemberInfo.Add(typeof(Int32)); //EdgeCharProcDivCd
			//���[�w�i�摜�c�ʒu
			serInfo.MemberInfo.Add(typeof(Double)); //PrtPprBgImageRowPos
			//���[�w�i�摜���ʒu
			serInfo.MemberInfo.Add(typeof(Double)); //PrtPprBgImageColPos
			//�捞�摜�O���[�v�R�[�h
			serInfo.MemberInfo.Add(typeof(byte[]));  //TakeInImageGroupCd
			//���o���_��ʋ敪
			serInfo.MemberInfo.Add(typeof(Int32)); //ExtraSectionKindCd
			//���o���_�I��L��
			serInfo.MemberInfo.Add(typeof(Int32)); //ExtraSectionSelExist
			//���הw�i�F(R)
			serInfo.MemberInfo.Add(typeof(Int32)); //RDetailBackColor
			//���הw�i�F(G)
			serInfo.MemberInfo.Add(typeof(Int32)); //GDetailBackColor
			//���הw�i�F(B)
			serInfo.MemberInfo.Add(typeof(Int32)); //BDetailBackColor
			//���s������
			serInfo.MemberInfo.Add(typeof(Int32)); //CrCharCnt
			//���R���[ ����p�r�敪
			serInfo.MemberInfo.Add(typeof(Int32)); //FreePrtPprSpPrpseCd
			//�󎚈ʒu�N���X�f�[�^
			serInfo.MemberInfo.Add(typeof(Byte[])); //PrintPosClassData


			serInfo.Serialize(writer, serInfo);
			if (graph is FrePrtPSetWork)
			{
				FrePrtPSetWork temp = (FrePrtPSetWork)graph;

				SetFrePrtPSetWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is FrePrtPSetWork[])
				{
					lst = new ArrayList();
					lst.AddRange((FrePrtPSetWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (FrePrtPSetWork temp in lst)
				{
					SetFrePrtPSetWork(writer, temp);
				}

			}


		}


		/// <summary>
		/// FrePrtPSetWork�����o��(public�v���p�e�B��)
		/// </summary>
		private const int currentMemberCount = 37;

		/// <summary>
		///  FrePrtPSetWork�C���X�^���X��������
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePrtPSetWork�̃C���X�^���X����������</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private void SetFrePrtPSetWork(System.IO.BinaryWriter writer, FrePrtPSetWork temp)
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
			//���[�g�p�敪
			writer.Write(temp.PrintPaperUseDivcd);
			//���[�敪�R�[�h
			writer.Write(temp.PrintPaperDivCd);
			//���o�v���O����ID
			writer.Write(temp.ExtractionPgId);
			//���o�v���O�����N���XID
			writer.Write(temp.ExtractionPgClassId);
			//�o�̓v���O����ID
			writer.Write(temp.OutputPgId);
			//�o�̓v���O�����N���XID
			writer.Write(temp.OutputPgClassId);
			//�o�͊m�F���b�Z�[�W
			writer.Write(temp.OutConfimationMsg);
			//�o�͖���
			writer.Write(temp.DisplayName);
			//���[���[�U�[�}�ԃR�����g
			writer.Write(temp.PrtPprUserDerivNoCmt);
			//�󎚈ʒu�o�[�W����
			writer.Write(temp.PrintPositionVer);
			//�}�[�W�\�󎚈ʒu�o�[�W����
			writer.Write(temp.MergeablePrintPosVer);
			//�f�[�^���̓V�X�e��
			writer.Write(temp.DataInputSystem);
			//�I�v�V�����R�[�h
			writer.Write(temp.OptionCode);
			//���R���[���ڃO���[�v�R�[�h
			writer.Write(temp.FreePrtPprItemGrpCd);
			//���ōs��
			writer.Write(temp.FormFeedLineCount);
			//�[���������敪
			writer.Write(temp.EdgeCharProcDivCd);
			//���[�w�i�摜�c�ʒu
			writer.Write(temp.PrtPprBgImageRowPos);
			//���[�w�i�摜���ʒu
			writer.Write(temp.PrtPprBgImageColPos);
			//�捞�摜�O���[�v�R�[�h
			byte[] takeInImageGroupCdArray = temp.TakeInImageGroupCd.ToByteArray();
			writer.Write(takeInImageGroupCdArray.Length);
			writer.Write(temp.TakeInImageGroupCd.ToByteArray());
			//���o���_��ʋ敪
			writer.Write(temp.ExtraSectionKindCd);
			//���o���_�I��L��
			writer.Write(temp.ExtraSectionSelExist);
			//���הw�i�F(R)
			writer.Write(temp.RDetailBackColor);
			//���הw�i�F(G)
			writer.Write(temp.GDetailBackColor);
			//���הw�i�F(B)
			writer.Write(temp.BDetailBackColor);
			//���s������
			writer.Write(temp.CrCharCnt);
			//���R���[ ����p�r�敪
			writer.Write(temp.FreePrtPprSpPrpseCd);
			//�󎚈ʒu�N���X�f�[�^
			writer.Write(temp.PrintPosClassData);

		}

		/// <summary>
		///  FrePrtPSetWork�C���X�^���X�擾
		/// </summary>
		/// <returns>FrePrtPSetWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePrtPSetWork�̃C���X�^���X���擾���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private FrePrtPSetWork GetFrePrtPSetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
		{
			// V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
			// serInfo.MemberInfo.Count < currentMemberCount
			// �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

			FrePrtPSetWork temp = new FrePrtPSetWork();

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
			//���[�g�p�敪
			temp.PrintPaperUseDivcd = reader.ReadInt32();
			//���[�敪�R�[�h
			temp.PrintPaperDivCd = reader.ReadInt32();
			//���o�v���O����ID
			temp.ExtractionPgId = reader.ReadString();
			//���o�v���O�����N���XID
			temp.ExtractionPgClassId = reader.ReadString();
			//�o�̓v���O����ID
			temp.OutputPgId = reader.ReadString();
			//�o�̓v���O�����N���XID
			temp.OutputPgClassId = reader.ReadString();
			//�o�͊m�F���b�Z�[�W
			temp.OutConfimationMsg = reader.ReadString();
			//�o�͖���
			temp.DisplayName = reader.ReadString();
			//���[���[�U�[�}�ԃR�����g
			temp.PrtPprUserDerivNoCmt = reader.ReadString();
			//�󎚈ʒu�o�[�W����
			temp.PrintPositionVer = reader.ReadInt32();
			//�}�[�W�\�󎚈ʒu�o�[�W����
			temp.MergeablePrintPosVer = reader.ReadInt32();
			//�f�[�^���̓V�X�e��
			temp.DataInputSystem = reader.ReadInt32();
			//�I�v�V�����R�[�h
			temp.OptionCode = reader.ReadString();
			//���R���[���ڃO���[�v�R�[�h
			temp.FreePrtPprItemGrpCd = reader.ReadInt32();
			//���ōs��
			temp.FormFeedLineCount = reader.ReadInt32();
			//�[���������敪
			temp.EdgeCharProcDivCd = reader.ReadInt32();
			//���[�w�i�摜�c�ʒu
			temp.PrtPprBgImageRowPos = reader.ReadDouble();
			//���[�w�i�摜���ʒu
			temp.PrtPprBgImageColPos = reader.ReadDouble();
			//�捞�摜�O���[�v�R�[�h
			int lenOfTakeInImageGroupCdArray = reader.ReadInt32();
			byte[] takeInImageGroupCdArray = reader.ReadBytes(lenOfTakeInImageGroupCdArray);
			temp.TakeInImageGroupCd = new Guid(takeInImageGroupCdArray);
			//���o���_��ʋ敪
			temp.ExtraSectionKindCd = reader.ReadInt32();
			//���o���_�I��L��
			temp.ExtraSectionSelExist = reader.ReadInt32();
			//���הw�i�F(R)
			temp.RDetailBackColor = reader.ReadInt32();
			//���הw�i�F(G)
			temp.GDetailBackColor = reader.ReadInt32();
			//���הw�i�F(B)
			temp.BDetailBackColor = reader.ReadInt32();
			//���s������
			temp.CrCharCnt = reader.ReadInt32();
			//���R���[ ����p�r�敪
			temp.FreePrtPprSpPrpseCd = reader.ReadInt32();
			//�󎚈ʒu�N���X�f�[�^


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
		/// <returns>FrePrtPSetWork�N���X�̃C���X�^���X(object)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePrtPSetWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
			{
				FrePrtPSetWork temp = GetFrePrtPSetWork(reader, serInfo);
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
					retValue = (FrePrtPSetWork[])lst.ToArray(typeof(FrePrtPSetWork));
					break;
			}
			return retValue;
		}

		#endregion
	}
}

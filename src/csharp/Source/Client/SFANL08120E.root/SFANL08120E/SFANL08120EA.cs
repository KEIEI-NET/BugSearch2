using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Collections;

using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	// ------------------------------------------------------------
	//  ���e���r���\�b�h���蓮�ŏC��
	//  ��byte[]�̎����Ő��������Image�^�̃v���p�e�B���폜
	//  �����הw�i�F�̏����l��255�ɕύX
	// ------------------------------------------------------------

	/// public class name:   FrePrtPSet
	/// <summary>
	///                      ���R���[�󎚈ʒu�ݒ�}�X�^
	/// </summary>
	/// <remarks>
	/// <br>note             :   ���R���[�󎚈ʒu�ݒ�}�X�^�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2007/03/15</br>
	/// <br>Genarated Date   :   2007/07/19  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class FrePrtPSet
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
		/// <remarks>1:���[,2:�`�[</remarks>
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
		private Int32 _rDetailBackColor = 255;

		/// <summary>���הw�i�F(G)</summary>
		private Int32 _gDetailBackColor = 255;

		/// <summary>���הw�i�F(B)</summary>
		private Int32 _bDetailBackColor = 255;

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
			get{return _outputFormFileName;}
			set{_outputFormFileName = value;}
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
			get{return _userPrtPprIdDerivNo;}
			set{_userPrtPprIdDerivNo = value;}
		}

		/// public propaty name  :  PrintPaperUseDivcd
		/// <summary>���[�g�p�敪�v���p�e�B</summary>
		/// <value>1:���[,2:�`�[</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�g�p�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrintPaperUseDivcd
		{
			get{return _printPaperUseDivcd;}
			set{_printPaperUseDivcd = value;}
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
			get{return _printPaperDivCd;}
			set{_printPaperDivCd = value;}
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
			get{return _extractionPgId;}
			set{_extractionPgId = value;}
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
			get{return _extractionPgClassId;}
			set{_extractionPgClassId = value;}
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
			get{return _outputPgId;}
			set{_outputPgId = value;}
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
			get{return _outputPgClassId;}
			set{_outputPgClassId = value;}
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
			get{return _outConfimationMsg;}
			set{_outConfimationMsg = value;}
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
			get{return _displayName;}
			set{_displayName = value;}
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
			get{return _prtPprUserDerivNoCmt;}
			set{_prtPprUserDerivNoCmt = value;}
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
			get{return _printPositionVer;}
			set{_printPositionVer = value;}
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
			get{return _mergeablePrintPosVer;}
			set{_mergeablePrintPosVer = value;}
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
			get{return _dataInputSystem;}
			set{_dataInputSystem = value;}
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
			get{return _optionCode;}
			set{_optionCode = value;}
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
			get{return _freePrtPprItemGrpCd;}
			set{_freePrtPprItemGrpCd = value;}
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
			get{return _prtPprBgImageRowPos;}
			set{_prtPprBgImageRowPos = value;}
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
			get{return _prtPprBgImageColPos;}
			set{_prtPprBgImageColPos = value;}
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
			get{return _takeInImageGroupCd;}
			set{_takeInImageGroupCd = value;}
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
			get{return _printPosClassData;}
			set{_printPosClassData = value;}
		}


		/// <summary>
		/// ���R���[�󎚈ʒu�ݒ�}�X�^�R���X�g���N�^
		/// </summary>
		/// <returns>FrePrtPSet�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePrtPSet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public FrePrtPSet()
		{
		}

		/// <summary>
		/// ���R���[�󎚈ʒu�ݒ�}�X�^�R���X�g���N�^
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
		/// <param name="printPaperUseDivcd">���[�g�p�敪(1:���[,2:�`�[)</param>
		/// <param name="printPaperDivCd">���[�敪�R�[�h</param>
		/// <param name="extractionPgId">���o�v���O����ID</param>
		/// <param name="extractionPgClassId">���o�v���O�����N���XID(����v���O����ID or �e�L�X�g�o�̓v���O����ID)</param>
		/// <param name="outputPgId">�o�̓v���O����ID</param>
		/// <param name="outputPgClassId">�o�̓v���O�����N���XID</param>
		/// <param name="outConfimationMsg">�o�͊m�F���b�Z�[�W</param>
		/// <param name="displayName">�o�͖���(�K�C�h���ɕ\�����閼��)</param>
		/// <param name="prtPprUserDerivNoCmt">���[���[�U�[�}�ԃR�����g</param>
		/// <param name="printPositionVer">�󎚈ʒu�o�[�W����</param>
		/// <param name="mergeablePrintPosVer">�}�[�W�\�󎚈ʒu�o�[�W����</param>
		/// <param name="dataInputSystem">�f�[�^���̓V�X�e��(0:����,1:����,2:���,3:�Ԕ�)</param>
		/// <param name="optionCode">�I�v�V�����R�[�h(���я�̵�߼�ݺ���)</param>
		/// <param name="freePrtPprItemGrpCd">���R���[���ڃO���[�v�R�[�h</param>
		/// <param name="formFeedLineCount">���ōs��</param>
		/// <param name="edgeCharProcDivCd">�[���������敪(1:�[�����؎̂�,2:�t�H���g�k��)</param>
		/// <param name="prtPprBgImageRowPos">���[�w�i�摜�c�ʒu(Z9.9)</param>
		/// <param name="prtPprBgImageColPos">���[�w�i�摜���ʒu(Z9.9)</param>
		/// <param name="takeInImageGroupCd">�捞�摜�O���[�v�R�[�h(�捞�摜�̃O���[�v���ʂ��邽�߂�GUID)</param>
		/// <param name="extraSectionKindCd">���o���_��ʋ敪(0:�g�p���Ȃ� 1:���сE���� 2:�d���E�̔�)</param>
		/// <param name="extraSectionSelExist">���o���_�I��L��(0:�g�p���Ȃ� 1:�g�p����(�����I��) 2:�g�p����(�P�̑I��))</param>
		/// <param name="rDetailBackColor">���הw�i�F(R)</param>
		/// <param name="gDetailBackColor">���הw�i�F(G)</param>
		/// <param name="bDetailBackColor">���הw�i�F(B)</param>
		/// <param name="crCharCnt">���s������(���`�[�ō�ƁE���i���̂̉��s������)</param>
		/// <param name="freePrtPprSpPrpseCd">���R���[ ����p�r�敪(0:�g�p���Ȃ�,1:�ē�������^�C�v,2:��p���[,3:�����͂���)</param>
		/// <param name="printPosClassData">�󎚈ʒu�N���X�f�[�^</param>
		/// <returns>FrePrtPSet�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePrtPSet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public FrePrtPSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string outputFormFileName, Int32 userPrtPprIdDerivNo, Int32 printPaperUseDivcd, Int32 printPaperDivCd, string extractionPgId, string extractionPgClassId, string outputPgId, string outputPgClassId, string outConfimationMsg, string displayName, string prtPprUserDerivNoCmt, Int32 printPositionVer, Int32 mergeablePrintPosVer, Int32 dataInputSystem, string optionCode, Int32 freePrtPprItemGrpCd, Int32 formFeedLineCount, Int32 edgeCharProcDivCd, Double prtPprBgImageRowPos, Double prtPprBgImageColPos, Guid takeInImageGroupCd, Int32 extraSectionKindCd, Int32 extraSectionSelExist, Int32 rDetailBackColor, Int32 gDetailBackColor, Int32 bDetailBackColor, Int32 crCharCnt, Int32 freePrtPprSpPrpseCd, Byte[] printPosClassData)
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
			this._printPaperUseDivcd = printPaperUseDivcd;
			this._printPaperDivCd = printPaperDivCd;
			this._extractionPgId = extractionPgId;
			this._extractionPgClassId = extractionPgClassId;
			this._outputPgId = outputPgId;
			this._outputPgClassId = outputPgClassId;
			this._outConfimationMsg = outConfimationMsg;
			this._displayName = displayName;
			this._prtPprUserDerivNoCmt = prtPprUserDerivNoCmt;
			this._printPositionVer = printPositionVer;
			this._mergeablePrintPosVer = mergeablePrintPosVer;
			this._dataInputSystem = dataInputSystem;
			this._optionCode = optionCode;
			this._freePrtPprItemGrpCd = freePrtPprItemGrpCd;
			this._formFeedLineCount = formFeedLineCount;
			this._edgeCharProcDivCd = edgeCharProcDivCd;
			this._prtPprBgImageRowPos = prtPprBgImageRowPos;
			this._prtPprBgImageColPos = prtPprBgImageColPos;
			this._takeInImageGroupCd = takeInImageGroupCd;
			this._extraSectionKindCd = extraSectionKindCd;
			this._extraSectionSelExist = extraSectionSelExist;
			this._rDetailBackColor = rDetailBackColor;
			this._gDetailBackColor = gDetailBackColor;
			this._bDetailBackColor = bDetailBackColor;
			this._crCharCnt = crCharCnt;
			this._freePrtPprSpPrpseCd = freePrtPprSpPrpseCd;
			this._printPosClassData = printPosClassData;

		}

		/// <summary>
		/// ���R���[�󎚈ʒu�ݒ�}�X�^��������
		/// </summary>
		/// <returns>FrePrtPSet�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����FrePrtPSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public FrePrtPSet Clone()
		{
			return new FrePrtPSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._outputFormFileName, this._userPrtPprIdDerivNo, this._printPaperUseDivcd, this._printPaperDivCd, this._extractionPgId, this._extractionPgClassId, this._outputPgId, this._outputPgClassId, this._outConfimationMsg, this._displayName, this._prtPprUserDerivNoCmt, this._printPositionVer, this._mergeablePrintPosVer, this._dataInputSystem, this._optionCode, this._freePrtPprItemGrpCd, this._formFeedLineCount, this._edgeCharProcDivCd, this._prtPprBgImageRowPos, this._prtPprBgImageColPos, this._takeInImageGroupCd, this._extraSectionKindCd, this._extraSectionSelExist, this._rDetailBackColor, this._gDetailBackColor, this._bDetailBackColor, this._crCharCnt, this._freePrtPprSpPrpseCd, this._printPosClassData);
		}

		/// <summary>
		/// ���R���[�󎚈ʒu�ݒ�}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�FrePrtPSet�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePrtPSet�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(FrePrtPSet target)
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
				 && (this.PrintPaperUseDivcd == target.PrintPaperUseDivcd)
				 && (this.PrintPaperDivCd == target.PrintPaperDivCd)
				 && (this.ExtractionPgId == target.ExtractionPgId)
				 && (this.ExtractionPgClassId == target.ExtractionPgClassId)
				 && (this.OutputPgId == target.OutputPgId)
				 && (this.OutputPgClassId == target.OutputPgClassId)
				 && (this.OutConfimationMsg == target.OutConfimationMsg)
				 && (this.DisplayName == target.DisplayName)
				 && (this.PrtPprUserDerivNoCmt == target.PrtPprUserDerivNoCmt)
				 && (this.PrintPositionVer == target.PrintPositionVer)
				 && (this.MergeablePrintPosVer == target.MergeablePrintPosVer)
				 && (this.DataInputSystem == target.DataInputSystem)
				 && (this.OptionCode == target.OptionCode)
				 && (this.FreePrtPprItemGrpCd == target.FreePrtPprItemGrpCd)
				 && (this.FormFeedLineCount == target.FormFeedLineCount)
				 && (this.EdgeCharProcDivCd == target.EdgeCharProcDivCd)
				 && (this.PrtPprBgImageRowPos == target.PrtPprBgImageRowPos)
				 && (this.PrtPprBgImageColPos == target.PrtPprBgImageColPos)
				 && (this.TakeInImageGroupCd == target.TakeInImageGroupCd)
				 && (this.ExtraSectionKindCd == target.ExtraSectionKindCd)
				 && (this.ExtraSectionSelExist == target.ExtraSectionSelExist)
				 && (this.RDetailBackColor == target.RDetailBackColor)
				 && (this.GDetailBackColor == target.GDetailBackColor)
				 && (this.BDetailBackColor == target.BDetailBackColor)
				 && (this.CrCharCnt == target.CrCharCnt)
				 && (this.FreePrtPprSpPrpseCd == target.FreePrtPprSpPrpseCd)
				//&& (this.PrintPosClassData == target.PrintPosClassData)
				);
		}

		/// <summary>
		/// ���R���[�󎚈ʒu�ݒ�}�X�^��r����
		/// </summary>
		/// <param name="frePrtPSet1">
		///                    ��r����FrePrtPSet�N���X�̃C���X�^���X
		/// </param>
		/// <param name="frePrtPSet2">��r����FrePrtPSet�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePrtPSet�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(FrePrtPSet frePrtPSet1, FrePrtPSet frePrtPSet2)
		{
			return ((frePrtPSet1.CreateDateTime == frePrtPSet2.CreateDateTime)
				 && (frePrtPSet1.UpdateDateTime == frePrtPSet2.UpdateDateTime)
				 && (frePrtPSet1.EnterpriseCode == frePrtPSet2.EnterpriseCode)
				 && (frePrtPSet1.FileHeaderGuid == frePrtPSet2.FileHeaderGuid)
				 && (frePrtPSet1.UpdEmployeeCode == frePrtPSet2.UpdEmployeeCode)
				 && (frePrtPSet1.UpdAssemblyId1 == frePrtPSet2.UpdAssemblyId1)
				 && (frePrtPSet1.UpdAssemblyId2 == frePrtPSet2.UpdAssemblyId2)
				 && (frePrtPSet1.LogicalDeleteCode == frePrtPSet2.LogicalDeleteCode)
				 && (frePrtPSet1.OutputFormFileName == frePrtPSet2.OutputFormFileName)
				 && (frePrtPSet1.UserPrtPprIdDerivNo == frePrtPSet2.UserPrtPprIdDerivNo)
				 && (frePrtPSet1.PrintPaperUseDivcd == frePrtPSet2.PrintPaperUseDivcd)
				 && (frePrtPSet1.PrintPaperDivCd == frePrtPSet2.PrintPaperDivCd)
				 && (frePrtPSet1.ExtractionPgId == frePrtPSet2.ExtractionPgId)
				 && (frePrtPSet1.ExtractionPgClassId == frePrtPSet2.ExtractionPgClassId)
				 && (frePrtPSet1.OutputPgId == frePrtPSet2.OutputPgId)
				 && (frePrtPSet1.OutputPgClassId == frePrtPSet2.OutputPgClassId)
				 && (frePrtPSet1.OutConfimationMsg == frePrtPSet2.OutConfimationMsg)
				 && (frePrtPSet1.DisplayName == frePrtPSet2.DisplayName)
				 && (frePrtPSet1.PrtPprUserDerivNoCmt == frePrtPSet2.PrtPprUserDerivNoCmt)
				 && (frePrtPSet1.PrintPositionVer == frePrtPSet2.PrintPositionVer)
				 && (frePrtPSet1.MergeablePrintPosVer == frePrtPSet2.MergeablePrintPosVer)
				 && (frePrtPSet1.DataInputSystem == frePrtPSet2.DataInputSystem)
				 && (frePrtPSet1.OptionCode == frePrtPSet2.OptionCode)
				 && (frePrtPSet1.FreePrtPprItemGrpCd == frePrtPSet2.FreePrtPprItemGrpCd)
				 && (frePrtPSet1.FormFeedLineCount == frePrtPSet2.FormFeedLineCount)
				 && (frePrtPSet1.EdgeCharProcDivCd == frePrtPSet2.EdgeCharProcDivCd)
				 && (frePrtPSet1.PrtPprBgImageRowPos == frePrtPSet2.PrtPprBgImageRowPos)
				 && (frePrtPSet1.PrtPprBgImageColPos == frePrtPSet2.PrtPprBgImageColPos)
				 && (frePrtPSet1.TakeInImageGroupCd == frePrtPSet2.TakeInImageGroupCd)
				 && (frePrtPSet1.ExtraSectionKindCd == frePrtPSet2.ExtraSectionKindCd)
				 && (frePrtPSet1.ExtraSectionSelExist == frePrtPSet2.ExtraSectionSelExist)
				 && (frePrtPSet1.RDetailBackColor == frePrtPSet2.RDetailBackColor)
				 && (frePrtPSet1.GDetailBackColor == frePrtPSet2.GDetailBackColor)
				 && (frePrtPSet1.BDetailBackColor == frePrtPSet2.BDetailBackColor)
				 && (frePrtPSet1.CrCharCnt == frePrtPSet2.CrCharCnt)
				 && (frePrtPSet1.FreePrtPprSpPrpseCd == frePrtPSet2.FreePrtPprSpPrpseCd)
				//&& (frePrtPSet1.PrintPosClassData == frePrtPSet2.PrintPosClassData)
				 );
		}
		/// <summary>
		/// ���R���[�󎚈ʒu�ݒ�}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�FrePrtPSet�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePrtPSet�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(FrePrtPSet target)
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
			if (this.PrintPaperUseDivcd != target.PrintPaperUseDivcd) resList.Add("PrintPaperUseDivcd");
			if (this.PrintPaperDivCd != target.PrintPaperDivCd) resList.Add("PrintPaperDivCd");
			if (this.ExtractionPgId != target.ExtractionPgId) resList.Add("ExtractionPgId");
			if (this.ExtractionPgClassId != target.ExtractionPgClassId) resList.Add("ExtractionPgClassId");
			if (this.OutputPgId != target.OutputPgId) resList.Add("OutputPgId");
			if (this.OutputPgClassId != target.OutputPgClassId) resList.Add("OutputPgClassId");
			if (this.OutConfimationMsg != target.OutConfimationMsg) resList.Add("OutConfimationMsg");
			if (this.DisplayName != target.DisplayName) resList.Add("DisplayName");
			if (this.PrtPprUserDerivNoCmt != target.PrtPprUserDerivNoCmt) resList.Add("PrtPprUserDerivNoCmt");
			if (this.PrintPositionVer != target.PrintPositionVer) resList.Add("PrintPositionVer");
			if (this.MergeablePrintPosVer != target.MergeablePrintPosVer) resList.Add("MergeablePrintPosVer");
			if (this.DataInputSystem != target.DataInputSystem) resList.Add("DataInputSystem");
			if (this.OptionCode != target.OptionCode) resList.Add("OptionCode");
			if (this.FreePrtPprItemGrpCd != target.FreePrtPprItemGrpCd) resList.Add("FreePrtPprItemGrpCd");
			if (this.FormFeedLineCount != target.FormFeedLineCount) resList.Add("FormFeedLineCount");
			if (this.EdgeCharProcDivCd != target.EdgeCharProcDivCd) resList.Add("EdgeCharProcDivCd");
			if (this.PrtPprBgImageRowPos != target.PrtPprBgImageRowPos) resList.Add("PrtPprBgImageRowPos");
			if (this.PrtPprBgImageColPos != target.PrtPprBgImageColPos) resList.Add("PrtPprBgImageColPos");
			if (this.TakeInImageGroupCd != target.TakeInImageGroupCd) resList.Add("TakeInImageGroupCd");
			if (this.ExtraSectionKindCd != target.ExtraSectionKindCd) resList.Add("ExtraSectionKindCd");
			if (this.ExtraSectionSelExist != target.ExtraSectionSelExist) resList.Add("ExtraSectionSelExist");
			if (this.RDetailBackColor != target.RDetailBackColor) resList.Add("RDetailBackColor");
			if (this.GDetailBackColor != target.GDetailBackColor) resList.Add("GDetailBackColor");
			if (this.BDetailBackColor != target.BDetailBackColor) resList.Add("BDetailBackColor");
			if (this.CrCharCnt != target.CrCharCnt) resList.Add("CrCharCnt");
			if (this.FreePrtPprSpPrpseCd != target.FreePrtPprSpPrpseCd) resList.Add("FreePrtPprSpPrpseCd");
			//if (this.PrintPosClassData != target.PrintPosClassData) resList.Add("PrintPosClassData");

			return resList;
		}

		/// <summary>
		/// ���R���[�󎚈ʒu�ݒ�}�X�^��r����
		/// </summary>
		/// <param name="frePrtPSet1">��r����FrePrtPSet�N���X�̃C���X�^���X</param>
		/// <param name="frePrtPSet2">��r����FrePrtPSet�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   FrePrtPSet�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(FrePrtPSet frePrtPSet1, FrePrtPSet frePrtPSet2)
		{
			ArrayList resList = new ArrayList();
			if (frePrtPSet1.CreateDateTime != frePrtPSet2.CreateDateTime) resList.Add("CreateDateTime");
			if (frePrtPSet1.UpdateDateTime != frePrtPSet2.UpdateDateTime) resList.Add("UpdateDateTime");
			if (frePrtPSet1.EnterpriseCode != frePrtPSet2.EnterpriseCode) resList.Add("EnterpriseCode");
			if (frePrtPSet1.FileHeaderGuid != frePrtPSet2.FileHeaderGuid) resList.Add("FileHeaderGuid");
			if (frePrtPSet1.UpdEmployeeCode != frePrtPSet2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
			if (frePrtPSet1.UpdAssemblyId1 != frePrtPSet2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
			if (frePrtPSet1.UpdAssemblyId2 != frePrtPSet2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
			if (frePrtPSet1.LogicalDeleteCode != frePrtPSet2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
			if (frePrtPSet1.OutputFormFileName != frePrtPSet2.OutputFormFileName) resList.Add("OutputFormFileName");
			if (frePrtPSet1.UserPrtPprIdDerivNo != frePrtPSet2.UserPrtPprIdDerivNo) resList.Add("UserPrtPprIdDerivNo");
			if (frePrtPSet1.PrintPaperUseDivcd != frePrtPSet2.PrintPaperUseDivcd) resList.Add("PrintPaperUseDivcd");
			if (frePrtPSet1.PrintPaperDivCd != frePrtPSet2.PrintPaperDivCd) resList.Add("PrintPaperDivCd");
			if (frePrtPSet1.ExtractionPgId != frePrtPSet2.ExtractionPgId) resList.Add("ExtractionPgId");
			if (frePrtPSet1.ExtractionPgClassId != frePrtPSet2.ExtractionPgClassId) resList.Add("ExtractionPgClassId");
			if (frePrtPSet1.OutputPgId != frePrtPSet2.OutputPgId) resList.Add("OutputPgId");
			if (frePrtPSet1.OutputPgClassId != frePrtPSet2.OutputPgClassId) resList.Add("OutputPgClassId");
			if (frePrtPSet1.OutConfimationMsg != frePrtPSet2.OutConfimationMsg) resList.Add("OutConfimationMsg");
			if (frePrtPSet1.DisplayName != frePrtPSet2.DisplayName) resList.Add("DisplayName");
			if (frePrtPSet1.PrtPprUserDerivNoCmt != frePrtPSet2.PrtPprUserDerivNoCmt) resList.Add("PrtPprUserDerivNoCmt");
			if (frePrtPSet1.PrintPositionVer != frePrtPSet2.PrintPositionVer) resList.Add("PrintPositionVer");
			if (frePrtPSet1.MergeablePrintPosVer != frePrtPSet2.MergeablePrintPosVer) resList.Add("MergeablePrintPosVer");
			if (frePrtPSet1.DataInputSystem != frePrtPSet2.DataInputSystem) resList.Add("DataInputSystem");
			if (frePrtPSet1.OptionCode != frePrtPSet2.OptionCode) resList.Add("OptionCode");
			if (frePrtPSet1.FreePrtPprItemGrpCd != frePrtPSet2.FreePrtPprItemGrpCd) resList.Add("FreePrtPprItemGrpCd");
			if (frePrtPSet1.FormFeedLineCount != frePrtPSet2.FormFeedLineCount) resList.Add("FormFeedLineCount");
			if (frePrtPSet1.EdgeCharProcDivCd != frePrtPSet2.EdgeCharProcDivCd) resList.Add("EdgeCharProcDivCd");
			if (frePrtPSet1.PrtPprBgImageRowPos != frePrtPSet2.PrtPprBgImageRowPos) resList.Add("PrtPprBgImageRowPos");
			if (frePrtPSet1.PrtPprBgImageColPos != frePrtPSet2.PrtPprBgImageColPos) resList.Add("PrtPprBgImageColPos");
			if (frePrtPSet1.TakeInImageGroupCd != frePrtPSet2.TakeInImageGroupCd) resList.Add("TakeInImageGroupCd");
			if (frePrtPSet1.ExtraSectionKindCd != frePrtPSet2.ExtraSectionKindCd) resList.Add("ExtraSectionKindCd");
			if (frePrtPSet1.ExtraSectionSelExist != frePrtPSet2.ExtraSectionSelExist) resList.Add("ExtraSectionSelExist");
			if (frePrtPSet1.RDetailBackColor != frePrtPSet2.RDetailBackColor) resList.Add("RDetailBackColor");
			if (frePrtPSet1.GDetailBackColor != frePrtPSet2.GDetailBackColor) resList.Add("GDetailBackColor");
			if (frePrtPSet1.BDetailBackColor != frePrtPSet2.BDetailBackColor) resList.Add("BDetailBackColor");
			if (frePrtPSet1.CrCharCnt != frePrtPSet2.CrCharCnt) resList.Add("CrCharCnt");
			if (frePrtPSet1.FreePrtPprSpPrpseCd != frePrtPSet2.FreePrtPprSpPrpseCd) resList.Add("FreePrtPprSpPrpseCd");
			//if (frePrtPSet1.PrintPosClassData != frePrtPSet2.PrintPosClassData) resList.Add("PrintPosClassData");

			return resList;
		}

		/// <summary>
		/// �󎚈ʒu�N���X�f�[�^��r����
		/// </summary>
		/// <param name="target">��r�Ώ�</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note       : �o�C�g�z��̓��e����v���邩��r���܂��B</br>
		/// <br>Programmer : 22024 ����_�u</br>
		/// <br>Date       : 2007.04.12</br>
		/// </remarks>
		public bool EqualsPrintPosClassData(byte[] target)
		{
			bool isEqual = false;

			if (this.PrintPosClassData == null && target == null)
				isEqual = true;
			else if (this.PrintPosClassData != null && target != null)
			{
				isEqual = Encoding.Unicode.GetString(this.PrintPosClassData).Equals(
							Encoding.Unicode.GetString(target));
			}

			return isEqual;
		}

		/// <summary>
		/// ���הw�i�F�擾����
		/// </summary>
		/// <returns>���הw�i�F</returns>
		/// <remarks>
		/// <br>Note       : ���הw�i�F���擾���܂��B</br>
		/// <br>Programmer : 22024 ����_�u</br>
		/// <br>Date       : 2007.09.27</br>
		/// </remarks>
		public Color GetDetailBackColor()
		{
			return Color.FromArgb(_rDetailBackColor, _gDetailBackColor, _bDetailBackColor);
		}

		/// <summary>
		/// ���הw�i�F�ݒ菈��
		/// </summary>
		/// <param name="detailBackColor">���הw�i�F</param>
		/// <remarks>
		/// <br>Note       : ���הw�i�F��ݒ肵�܂��B</br>
		/// <br>Programmer : 22024 ����_�u</br>
		/// <br>Date       : 2007.09.27</br>
		/// </remarks>
		public void SetDetailBackColor(Color detailBackColor)
		{
			_rDetailBackColor = detailBackColor.R;
			_gDetailBackColor = detailBackColor.G;
			_bDetailBackColor = detailBackColor.B;
		}
	}
}

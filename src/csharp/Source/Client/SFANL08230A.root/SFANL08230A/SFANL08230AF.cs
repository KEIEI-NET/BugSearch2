using System;
using System.IO;
using System.Collections;
using System.Drawing;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SFANL08230AF
    /// <summary>
    ///                      ���R���[�󎚈ʒuDL��ʃf�[�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���R���[�󎚈ʒuDL��ʃf�[�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2007/03/15</br>
    /// <br>Genarated Date   :   2007/06/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SFANL08230AF
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
        /// <remarks>1:�������[,2:�������[,3:�N�����[,4:�������[</remarks>
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
        /// <remarks>0:����,1:SF,2:BK,3:SH</remarks>
        private Int32 _dataInputSystem;

        /// <summary>�I�v�V�����R�[�h</summary>
        /// <remarks>���я�̵�߼�ݺ���</remarks>
        private string _optionCode = "";

        /// <summary>���R���[���ڃO���[�v�R�[�h</summary>
        private Int32 _freePrtPprItemGrpCd;

        /// <summary>���[�w�i�摜�c�ʒu</summary>
        /// <remarks>Z9.9</remarks>
        private Double _prtPprBgImageRowPos;

        /// <summary>���[�w�i�摜���ʒu</summary>
        /// <remarks>Z9.9</remarks>
        private Double _prtPprBgImageColPos;

        /// <summary>�󎚈ʒu�N���X�f�[�^</summary>
        private Byte[] _printPosClassData;

        /// <summary>���[�w�i�摜�f�[�^</summary>
        private Byte[] _printPprBgImageData;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>���R���[���ڃO���[�v����</summary>
        private string _freePrtPprItemGrpNm = "";

        /// <summary>�L�[�ԍ�</summary>
        private string _keyNo = "";

        /// <summary>�X�V�t���O</summary>
        private Int32 _updateFlag;

        /// <summary>�����t���O</summary>
        private Int32 _existingFlag;

        /// <summary>�捞�摜�O���[�v�R�[�h</summary>
        /// <remarks>�捞�摜�̃O���[�v���ʂ��邽�߂�GUID</remarks>
        private Guid _takeInImageGroupCd;
        /// <summary>���R���[ ����p�r�敪�@0:�g�p���Ȃ�,1:�ē�������^�C�v,2:��p���[,3:�����͂���</summary>
        private Int32 _FreePrtPprSpPrpseCd;
        


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
            get { return _printPaperUseDivcd; }
            set { _printPaperUseDivcd = value; }
        }

        /// public propaty name  :  PrintPaperDivCd
        /// <summary>���[�敪�R�[�h�v���p�e�B</summary>
        /// <value>1:�������[,2:�������[,3:�N�����[,4:�������[</value>
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
        /// <value>0:����,1:SF,2:BK,3:SH</value>
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

        /// public propaty field.NameJp  :  PrintPosClassDataImageObject
        /// <summary>�󎚈ʒu�N���X�f�[�^�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �󎚈ʒu�N���X�f�[�^�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Image PrintPosClassDataImageObject
        {
            get
            {
                MemoryStream mem = new MemoryStream(_printPosClassData);
                mem.Position = 0;
                return Image.FromStream(mem);
            }
            set
            {
                _printPosClassData = null;
                MemoryStream mem = new MemoryStream();
                Image img = value;
                img.Save(mem, System.Drawing.Imaging.ImageFormat.Bmp);
                _printPosClassData = mem.ToArray();
            }
        }

        /// public propaty name  :  PrintPprBgImageData
        /// <summary>���[�w�i�摜�f�[�^�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�w�i�摜�f�[�^�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Byte[] PrintPprBgImageData
        {
            get { return _printPprBgImageData; }
            set { _printPprBgImageData = value; }
        }

        /// public propaty field.NameJp  :  PrintPprBgImageDataImageObject
        /// <summary>���[�w�i�摜�f�[�^�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�w�i�摜�f�[�^�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Image PrintPprBgImageDataImageObject
        {
            get
            {
                MemoryStream mem = new MemoryStream(_printPprBgImageData);
                mem.Position = 0;
                return Image.FromStream(mem);
            }
            set
            {
                _printPprBgImageData = null;
                MemoryStream mem = new MemoryStream();
                Image img = value;
                img.Save(mem, System.Drawing.Imaging.ImageFormat.Bmp);
                _printPprBgImageData = mem.ToArray();
            }
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

        /// public propaty name  :  FreePrtPprItemGrpNm
        /// <summary>���R���[���ڃO���[�v���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���R���[���ڃO���[�v���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FreePrtPprItemGrpNm
        {
            get { return _freePrtPprItemGrpNm; }
            set { _freePrtPprItemGrpNm = value; }
        }

        /// public propaty name  :  KeyNo
        /// <summary>�L�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �L�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string KeyNo
        {
            get { return _keyNo; }
            set { _keyNo = value; }
        }

        /// public propaty name  :  UpdateFlag
        /// <summary>�X�V�t���O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UpdateFlag
        {
            get { return _updateFlag; }
            set { _updateFlag = value; }
        }

        /// public propaty name  :  ExistingDataFlag
        /// <summary>�����t���O�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ExistingDataFlag
        {
            get { return _existingFlag; }
            set { _existingFlag = value; }
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

        /// <summary>
        /// ���R���[ ����p�r�敪�v���p�e�B�@0:�g�p���Ȃ�,1:�ē�������^�C�v,2:��p���[,3:�����͂���
        /// </summary>
        public Int32 FreePrtPprSpPrpseCd
        {
            get { return _FreePrtPprSpPrpseCd; }
            set { _FreePrtPprSpPrpseCd = value; }
        }


        /// <summary>
        /// ���R���[�󎚈ʒuDL��ʃf�[�^�R���X�g���N�^
        /// </summary>
        /// <returns>SFANL08230AF�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SFANL08230AF�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SFANL08230AF()
        {
        }

        /// <summary>
        /// ���R���[�󎚈ʒuDL��ʃf�[�^�R���X�g���N�^
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
        /// <param name="slipOrPrtPprDivCd">���[�g�p�敪(1:���[,2:�`�[)</param>
        /// <param name="printPaperDivCd">���[�敪�R�[�h(1:�������[,2:�������[,3:�N�����[,4:�������[)</param>
        /// <param name="extractionPgId">���o�v���O����ID</param>
        /// <param name="extractionPgClassId">���o�v���O�����N���XID(����v���O����ID or �e�L�X�g�o�̓v���O����ID)</param>
        /// <param name="outputPgId">�o�̓v���O����ID</param>
        /// <param name="outputPgClassId">�o�̓v���O�����N���XID</param>
        /// <param name="outConfimationMsg">�o�͊m�F���b�Z�[�W</param>
        /// <param name="displayName">�o�͖���(�K�C�h���ɕ\�����閼��)</param>
        /// <param name="prtPprUserDerivNoCmt">���[���[�U�[�}�ԃR�����g</param>
        /// <param name="printPositionVer">�󎚈ʒu�o�[�W����</param>
        /// <param name="mergeablePrintPosVer">�}�[�W�\�󎚈ʒu�o�[�W����</param>
        /// <param name="systemDivCd">�f�[�^���̓V�X�e��(0:����,1:SF,2:BK,3:SH)</param>
        /// <param name="optionCode">�I�v�V�����R�[�h(���я�̵�߼�ݺ���)</param>
        /// <param name="freePrtPprItemGrpCd">���R���[���ڃO���[�v�R�[�h</param>
        /// <param name="prtPprBgImageRowPos">���[�w�i�摜�c�ʒu(Z9.9)</param>
        /// <param name="prtPprBgImageColPos">���[�w�i�摜���ʒu(Z9.9)</param>
        /// <param name="printPosClassData">�󎚈ʒu�N���X�f�[�^</param>
        /// <param name="printPprBgImageData">���[�w�i�摜�f�[�^</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="freePrtPprItemGrpNm">���R���[���ڃO���[�v����</param>
        /// <param name="keyNo">�L�[�ԍ�</param>
        /// <param name="updateFlag">�X�V�t���O</param>
        /// <param name="existingFlag">�����t���O</param>
        /// <param name="FreePrtPprSpPrpseCd">���R���[ ����p�r�敪</param>
        /// <param name="takeInImageGroupCd">�捞�摜�O���[�v�R�[�h(�捞�摜�̃O���[�v���ʂ��邽�߂�GUID)</param>
        /// <returns>SFANL08230AF�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SFANL08230AF�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SFANL08230AF(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string outputFormFileName, Int32 userPrtPprIdDerivNo, Int32 slipOrPrtPprDivCd, Int32 printPaperDivCd, string extractionPgId, string extractionPgClassId, string outputPgId, string outputPgClassId, string outConfimationMsg, string displayName, string prtPprUserDerivNoCmt, Int32 printPositionVer, Int32 mergeablePrintPosVer, Int32 systemDivCd, string optionCode, Int32 freePrtPprItemGrpCd, Double prtPprBgImageRowPos, Double prtPprBgImageColPos, Byte[] printPosClassData, Byte[] printPprBgImageData, string enterpriseName, string updEmployeeName, string freePrtPprItemGrpNm, string keyNo, Int32 updateFlag, Int32 existingFlag, Guid takeInImageGroupCd, Int32 FreePrtPprSpPrpseCd)
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
            this._printPaperUseDivcd = slipOrPrtPprDivCd;
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
            this._dataInputSystem = systemDivCd;
            this._optionCode = optionCode;
            this._freePrtPprItemGrpCd = freePrtPprItemGrpCd;
            this._prtPprBgImageRowPos = prtPprBgImageRowPos;
            this._prtPprBgImageColPos = prtPprBgImageColPos;
            this._printPosClassData = printPosClassData;
            this._printPprBgImageData = printPprBgImageData;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._freePrtPprItemGrpNm = freePrtPprItemGrpNm;
            this._keyNo = keyNo;
            this._updateFlag = updateFlag;
            this._existingFlag = existingFlag;
            this._takeInImageGroupCd = takeInImageGroupCd;
            this._FreePrtPprSpPrpseCd = FreePrtPprSpPrpseCd;
        }

        /// <summary>
        /// ���R���[�󎚈ʒuDL��ʃf�[�^��������
        /// </summary>
        /// <returns>SFANL08230AF�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SFANL08230AF�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SFANL08230AF Clone()
        {
            return new SFANL08230AF(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._outputFormFileName, this._userPrtPprIdDerivNo, this._printPaperUseDivcd, this._printPaperDivCd, this._extractionPgId, this._extractionPgClassId, this._outputPgId, this._outputPgClassId, this._outConfimationMsg, this._displayName, this._prtPprUserDerivNoCmt, this._printPositionVer, this._mergeablePrintPosVer, this._dataInputSystem, this._optionCode, this._freePrtPprItemGrpCd, this._prtPprBgImageRowPos, this._prtPprBgImageColPos, this._printPosClassData, this._printPprBgImageData, this._enterpriseName, this._updEmployeeName, this._freePrtPprItemGrpNm, this._keyNo, this._updateFlag, this._existingFlag, this._takeInImageGroupCd, this._FreePrtPprSpPrpseCd);
        }

        /// <summary>
        /// ���R���[�󎚈ʒuDL��ʃf�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SFANL08230AF�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SFANL08230AF�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(SFANL08230AF target)
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
                 && (this.PrtPprBgImageRowPos == target.PrtPprBgImageRowPos)
                 && (this.PrtPprBgImageColPos == target.PrtPprBgImageColPos)
                 && (this.PrintPosClassData == target.PrintPosClassData)
                 && (this.PrintPprBgImageData == target.PrintPprBgImageData)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.FreePrtPprItemGrpNm == target.FreePrtPprItemGrpNm)
                 && (this.KeyNo == target.KeyNo)
                 && (this.UpdateFlag == target.UpdateFlag)
                 && (this.ExistingDataFlag == target.ExistingDataFlag)
                 && (this.TakeInImageGroupCd == target.TakeInImageGroupCd)
                 && (this.FreePrtPprSpPrpseCd == target.FreePrtPprSpPrpseCd));
        }

        /// <summary>
        /// ���R���[�󎚈ʒuDL��ʃf�[�^��r����
        /// </summary>
        /// <param name="sFANL08230AF1">
        ///                    ��r����SFANL08230AF�N���X�̃C���X�^���X
        /// </param>
        /// <param name="sFANL08230AF2">��r����SFANL08230AF�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SFANL08230AF�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(SFANL08230AF sFANL08230AF1, SFANL08230AF sFANL08230AF2)
        {
            return ((sFANL08230AF1.CreateDateTime == sFANL08230AF2.CreateDateTime)
                 && (sFANL08230AF1.UpdateDateTime == sFANL08230AF2.UpdateDateTime)
                 && (sFANL08230AF1.EnterpriseCode == sFANL08230AF2.EnterpriseCode)
                 && (sFANL08230AF1.FileHeaderGuid == sFANL08230AF2.FileHeaderGuid)
                 && (sFANL08230AF1.UpdEmployeeCode == sFANL08230AF2.UpdEmployeeCode)
                 && (sFANL08230AF1.UpdAssemblyId1 == sFANL08230AF2.UpdAssemblyId1)
                 && (sFANL08230AF1.UpdAssemblyId2 == sFANL08230AF2.UpdAssemblyId2)
                 && (sFANL08230AF1.LogicalDeleteCode == sFANL08230AF2.LogicalDeleteCode)
                 && (sFANL08230AF1.OutputFormFileName == sFANL08230AF2.OutputFormFileName)
                 && (sFANL08230AF1.UserPrtPprIdDerivNo == sFANL08230AF2.UserPrtPprIdDerivNo)
                 && (sFANL08230AF1.PrintPaperUseDivcd == sFANL08230AF2.PrintPaperUseDivcd)
                 && (sFANL08230AF1.PrintPaperDivCd == sFANL08230AF2.PrintPaperDivCd)
                 && (sFANL08230AF1.ExtractionPgId == sFANL08230AF2.ExtractionPgId)
                 && (sFANL08230AF1.ExtractionPgClassId == sFANL08230AF2.ExtractionPgClassId)
                 && (sFANL08230AF1.OutputPgId == sFANL08230AF2.OutputPgId)
                 && (sFANL08230AF1.OutputPgClassId == sFANL08230AF2.OutputPgClassId)
                 && (sFANL08230AF1.OutConfimationMsg == sFANL08230AF2.OutConfimationMsg)
                 && (sFANL08230AF1.DisplayName == sFANL08230AF2.DisplayName)
                 && (sFANL08230AF1.PrtPprUserDerivNoCmt == sFANL08230AF2.PrtPprUserDerivNoCmt)
                 && (sFANL08230AF1.PrintPositionVer == sFANL08230AF2.PrintPositionVer)
                 && (sFANL08230AF1.MergeablePrintPosVer == sFANL08230AF2.MergeablePrintPosVer)
                 && (sFANL08230AF1.DataInputSystem == sFANL08230AF2.DataInputSystem)
                 && (sFANL08230AF1.OptionCode == sFANL08230AF2.OptionCode)
                 && (sFANL08230AF1.FreePrtPprItemGrpCd == sFANL08230AF2.FreePrtPprItemGrpCd)
                 && (sFANL08230AF1.PrtPprBgImageRowPos == sFANL08230AF2.PrtPprBgImageRowPos)
                 && (sFANL08230AF1.PrtPprBgImageColPos == sFANL08230AF2.PrtPprBgImageColPos)
                 && (sFANL08230AF1.PrintPosClassData == sFANL08230AF2.PrintPosClassData)
                 && (sFANL08230AF1.PrintPprBgImageData == sFANL08230AF2.PrintPprBgImageData)
                 && (sFANL08230AF1.EnterpriseName == sFANL08230AF2.EnterpriseName)
                 && (sFANL08230AF1.UpdEmployeeName == sFANL08230AF2.UpdEmployeeName)
                 && (sFANL08230AF1.FreePrtPprItemGrpNm == sFANL08230AF2.FreePrtPprItemGrpNm)
                 && (sFANL08230AF1.KeyNo == sFANL08230AF2.KeyNo)
                 && (sFANL08230AF1.UpdateFlag == sFANL08230AF2.UpdateFlag)
                 && (sFANL08230AF1.ExistingDataFlag == sFANL08230AF2.ExistingDataFlag)
                 && (sFANL08230AF1.TakeInImageGroupCd == sFANL08230AF2.TakeInImageGroupCd)
                 && (sFANL08230AF1.FreePrtPprSpPrpseCd == sFANL08230AF2.FreePrtPprSpPrpseCd));
        }
        /// <summary>
        /// ���R���[�󎚈ʒuDL��ʃf�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SFANL08230AF�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SFANL08230AF�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(SFANL08230AF target)
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
            if (this.PrtPprBgImageRowPos != target.PrtPprBgImageRowPos) resList.Add("PrtPprBgImageRowPos");
            if (this.PrtPprBgImageColPos != target.PrtPprBgImageColPos) resList.Add("PrtPprBgImageColPos");
            if (this.PrintPosClassData != target.PrintPosClassData) resList.Add("PrintPosClassData");
            if (this.PrintPprBgImageData != target.PrintPprBgImageData) resList.Add("PrintPprBgImageData");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.FreePrtPprItemGrpNm != target.FreePrtPprItemGrpNm) resList.Add("FreePrtPprItemGrpNm");
            if (this.KeyNo != target.KeyNo) resList.Add("KeyNo");
            if (this.UpdateFlag != target.UpdateFlag) resList.Add("UpdateFlag");
            if (this.ExistingDataFlag != target.ExistingDataFlag) resList.Add("ExistingDataFlag");
            if (this.TakeInImageGroupCd != target.TakeInImageGroupCd) resList.Add("TakeInImageGroupCd");
            if (this.FreePrtPprSpPrpseCd != target.FreePrtPprSpPrpseCd) resList.Add("FreePrtPprSpPrpseCd");
            return resList;
        }

        /// <summary>
        /// ���R���[�󎚈ʒuDL��ʃf�[�^��r����
        /// </summary>
        /// <param name="sFANL08230AF1">��r����SFANL08230AF�N���X�̃C���X�^���X</param>
        /// <param name="sFANL08230AF2">��r����SFANL08230AF�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SFANL08230AF�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(SFANL08230AF sFANL08230AF1, SFANL08230AF sFANL08230AF2)
        {
            ArrayList resList = new ArrayList();
            if (sFANL08230AF1.CreateDateTime != sFANL08230AF2.CreateDateTime) resList.Add("CreateDateTime");
            if (sFANL08230AF1.UpdateDateTime != sFANL08230AF2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (sFANL08230AF1.EnterpriseCode != sFANL08230AF2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (sFANL08230AF1.FileHeaderGuid != sFANL08230AF2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (sFANL08230AF1.UpdEmployeeCode != sFANL08230AF2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (sFANL08230AF1.UpdAssemblyId1 != sFANL08230AF2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (sFANL08230AF1.UpdAssemblyId2 != sFANL08230AF2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (sFANL08230AF1.LogicalDeleteCode != sFANL08230AF2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (sFANL08230AF1.OutputFormFileName != sFANL08230AF2.OutputFormFileName) resList.Add("OutputFormFileName");
            if (sFANL08230AF1.UserPrtPprIdDerivNo != sFANL08230AF2.UserPrtPprIdDerivNo) resList.Add("UserPrtPprIdDerivNo");
            if (sFANL08230AF1.PrintPaperUseDivcd != sFANL08230AF2.PrintPaperUseDivcd) resList.Add("PrintPaperUseDivcd");
            if (sFANL08230AF1.PrintPaperDivCd != sFANL08230AF2.PrintPaperDivCd) resList.Add("PrintPaperDivCd");
            if (sFANL08230AF1.ExtractionPgId != sFANL08230AF2.ExtractionPgId) resList.Add("ExtractionPgId");
            if (sFANL08230AF1.ExtractionPgClassId != sFANL08230AF2.ExtractionPgClassId) resList.Add("ExtractionPgClassId");
            if (sFANL08230AF1.OutputPgId != sFANL08230AF2.OutputPgId) resList.Add("OutputPgId");
            if (sFANL08230AF1.OutputPgClassId != sFANL08230AF2.OutputPgClassId) resList.Add("OutputPgClassId");
            if (sFANL08230AF1.OutConfimationMsg != sFANL08230AF2.OutConfimationMsg) resList.Add("OutConfimationMsg");
            if (sFANL08230AF1.DisplayName != sFANL08230AF2.DisplayName) resList.Add("DisplayName");
            if (sFANL08230AF1.PrtPprUserDerivNoCmt != sFANL08230AF2.PrtPprUserDerivNoCmt) resList.Add("PrtPprUserDerivNoCmt");
            if (sFANL08230AF1.PrintPositionVer != sFANL08230AF2.PrintPositionVer) resList.Add("PrintPositionVer");
            if (sFANL08230AF1.MergeablePrintPosVer != sFANL08230AF2.MergeablePrintPosVer) resList.Add("MergeablePrintPosVer");
            if (sFANL08230AF1.DataInputSystem != sFANL08230AF2.DataInputSystem) resList.Add("DataInputSystem");
            if (sFANL08230AF1.OptionCode != sFANL08230AF2.OptionCode) resList.Add("OptionCode");
            if (sFANL08230AF1.FreePrtPprItemGrpCd != sFANL08230AF2.FreePrtPprItemGrpCd) resList.Add("FreePrtPprItemGrpCd");
            if (sFANL08230AF1.PrtPprBgImageRowPos != sFANL08230AF2.PrtPprBgImageRowPos) resList.Add("PrtPprBgImageRowPos");
            if (sFANL08230AF1.PrtPprBgImageColPos != sFANL08230AF2.PrtPprBgImageColPos) resList.Add("PrtPprBgImageColPos");
            if (sFANL08230AF1.PrintPosClassData != sFANL08230AF2.PrintPosClassData) resList.Add("PrintPosClassData");
            if (sFANL08230AF1.PrintPprBgImageData != sFANL08230AF2.PrintPprBgImageData) resList.Add("PrintPprBgImageData");
            if (sFANL08230AF1.EnterpriseName != sFANL08230AF2.EnterpriseName) resList.Add("EnterpriseName");
            if (sFANL08230AF1.UpdEmployeeName != sFANL08230AF2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (sFANL08230AF1.FreePrtPprItemGrpNm != sFANL08230AF2.FreePrtPprItemGrpNm) resList.Add("FreePrtPprItemGrpNm");
            if (sFANL08230AF1.KeyNo != sFANL08230AF2.KeyNo) resList.Add("KeyNo");
            if (sFANL08230AF1.UpdateFlag != sFANL08230AF2.UpdateFlag) resList.Add("UpdateFlag");
            if (sFANL08230AF1.ExistingDataFlag != sFANL08230AF2.ExistingDataFlag) resList.Add("ExistingDataFlag");
            if (sFANL08230AF1.TakeInImageGroupCd != sFANL08230AF2.TakeInImageGroupCd) resList.Add("TakeInImageGroupCd");
            if (sFANL08230AF1.FreePrtPprSpPrpseCd != sFANL08230AF2.FreePrtPprSpPrpseCd) resList.Add("FreePrtPprSpPrpseCd");
            return resList;
        }
    }
}
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CompanyInfWork
    /// <summary>
    ///                      ���Џ�񃏁[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���Џ�񃏁[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/10</br>
    /// <br>Genarated Date   :   2008/05/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/4/1  ����</br>
    /// <br>                 :   �����Ǘ��敪�̓��e��ύX</br>
    /// <br>                 :   0:���_�@1:���_�{���@2:���_�{���{��</br>
    /// <br>                 :   ��</br>
    /// <br>                 :   0:���_�@1:���_�{��</br>
    /// <br>Update Note      :   2011/07/14  LDNS wangqx</br>
    /// <br>                 :   �f�[�^�N���A�������s�N�����A�f�[�^�N���A�������s�����b�~���b��ǉ�</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CompanyInfWork : IFileHeader
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

        /// <summary>���ЃR�[�h</summary>
        /// <remarks>�O�Œ�</remarks>
        private Int32 _companyCode;

        /// <summary>���В���</summary>
        /// <remarks>DD�@����N�������Z�o����閖�������ł��邱�Ɗ�����̓����z����l</remarks>
        private Int32 _companyTotalDay;

        /// <summary>��v�N�x</summary>
        /// <remarks>YYYY</remarks>
        private Int32 _financialYear;

        /// <summary>����</summary>
        /// <remarks>MM</remarks>
        private Int32 _companyBiginMonth;

        /// <summary>����2</summary>
        /// <remarks>MM</remarks>
        private Int32 _companyBiginMonth2;

        /// <summary>����N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _companyBiginDate;

        /// <summary>�J�n�N�敪</summary>
        /// <remarks>0:�O�N 1:���N</remarks>
        private Int32 _startYearDiv;

        /// <summary>�J�n���敪</summary>
        /// <remarks>0:�O�� 1:����</remarks>
        private Int32 _startMonthDiv;

        /// <summary>���Ж���1</summary>
        private string _companyName1 = "";

        /// <summary>���Ж���2</summary>
        private string _companyName2 = "";

        /// <summary>�X�֔ԍ�</summary>
        private string _postNo = "";

        /// <summary>�Z��1�i�s���{���s��S�E�����E���j</summary>
        private string _address1 = "";

        /// <summary>�Z��3�i�Ԓn�j</summary>
        private string _address3 = "";

        /// <summary>�Z��4�i�A�p�[�g���́j</summary>
        private string _address4 = "";

        /// <summary>���Гd�b�ԍ�1</summary>
        /// <remarks>TEL</remarks>
        private string _companyTelNo1 = "";

        /// <summary>���Гd�b�ԍ�2</summary>
        /// <remarks>TEL2</remarks>
        private string _companyTelNo2 = "";

        /// <summary>���Гd�b�ԍ�3</summary>
        /// <remarks>FAX</remarks>
        private string _companyTelNo3 = "";

        /// <summary>���Гd�b�ԍ��^�C�g��1</summary>
        /// <remarks>TEL</remarks>
        private string _companyTelTitle1 = "";

        /// <summary>���Гd�b�ԍ��^�C�g��2</summary>
        /// <remarks>TEL2</remarks>
        private string _companyTelTitle2 = "";

        /// <summary>���Гd�b�ԍ��^�C�g��3</summary>
        /// <remarks>FAX</remarks>
        private string _companyTelTitle3 = "";

        /// <summary>�����Ǘ��敪</summary>
        /// <remarks>0:���_�@1:���_�{��</remarks>
        private Int32 _secMngDiv;

        /// <summary>�f�[�^�ۑ�����</summary>
        private Int32 _dataSaveMonths;

        /// <summary>�f�[�^���k��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _dataCompressDt;

        /// <summary>���уf�[�^�ۑ�����</summary>
        private Int32 _resultDtSaveMonths;

        /// <summary>���уf�[�^���k��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _resultDtCompressDt;

        /// <summary>���q���i�f�[�^�ۑ�����</summary>
        private Int32 _caPrtsDtSaveMonths;

        /// <summary>���q���i�f�[�^���k��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _caPrtsDtCompressDt;

        /// <summary>�}�X�^�ۑ�����</summary>
        private Int32 _masterSaveMonths;

        /// <summary>�}�X�^���k��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _masterCompressDt;

		/// <summary>�|���D��敪</summary>
		/// <remarks>0:���_�D�� 1:�ݒ�敪�D��</remarks>
		private Int32 _ratePriorityDiv;

        // --- ADD 2011/07/14 --------------------------------------------------------------------->>>>>
        /// <summary>�f�[�^�N���A�������s�N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _dataClrExecDate;

        /// <summary>�f�[�^�N���A�������s�����b�~���b</summary>
        /// <remarks>HHMMSSXXX</remarks>
        private Int32 _dataClrExecTime;
        // --- ADD 2011/07/14 ---------------------------------------------------------------------<<<<<

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

        /// public propaty name  :  CompanyCode
        /// <summary>���ЃR�[�h�v���p�e�B</summary>
        /// <value>�O�Œ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ЃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CompanyCode
        {
            get { return _companyCode; }
            set { _companyCode = value; }
        }

        /// public propaty name  :  CompanyTotalDay
        /// <summary>���В����v���p�e�B</summary>
        /// <value>DD�@����N�������Z�o����閖�������ł��邱�Ɗ�����̓����z����l</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���В����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CompanyTotalDay
        {
            get { return _companyTotalDay; }
            set { _companyTotalDay = value; }
        }

        /// public propaty name  :  FinancialYear
        /// <summary>��v�N�x�v���p�e�B</summary>
        /// <value>YYYY</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��v�N�x�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FinancialYear
        {
            get { return _financialYear; }
            set { _financialYear = value; }
        }

        /// public propaty name  :  CompanyBiginMonth
        /// <summary>���񌎃v���p�e�B</summary>
        /// <value>MM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񌎃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CompanyBiginMonth
        {
            get { return _companyBiginMonth; }
            set { _companyBiginMonth = value; }
        }

        /// public propaty name  :  CompanyBiginMonth2
        /// <summary>����2�v���p�e�B</summary>
        /// <value>MM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CompanyBiginMonth2
        {
            get { return _companyBiginMonth2; }
            set { _companyBiginMonth2 = value; }
        }

        /// public propaty name  :  CompanyBiginDate
        /// <summary>����N�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CompanyBiginDate
        {
            get { return _companyBiginDate; }
            set { _companyBiginDate = value; }
        }

        /// public propaty name  :  StartYearDiv
        /// <summary>�J�n�N�敪�v���p�e�B</summary>
        /// <value>0:�O�N 1:���N</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�N�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StartYearDiv
        {
            get { return _startYearDiv; }
            set { _startYearDiv = value; }
        }

        /// public propaty name  :  StartMonthDiv
        /// <summary>�J�n���敪�v���p�e�B</summary>
        /// <value>0:�O�� 1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StartMonthDiv
        {
            get { return _startMonthDiv; }
            set { _startMonthDiv = value; }
        }

        /// public propaty name  :  CompanyName1
        /// <summary>���Ж���1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж���1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyName1
        {
            get { return _companyName1; }
            set { _companyName1 = value; }
        }

        /// public propaty name  :  CompanyName2
        /// <summary>���Ж���2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ж���2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyName2
        {
            get { return _companyName2; }
            set { _companyName2 = value; }
        }

        /// public propaty name  :  PostNo
        /// <summary>�X�֔ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�֔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PostNo
        {
            get { return _postNo; }
            set { _postNo = value; }
        }

        /// public propaty name  :  Address1
        /// <summary>�Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }

        /// public propaty name  :  Address3
        /// <summary>�Z��3�i�Ԓn�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��3�i�Ԓn�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Address3
        {
            get { return _address3; }
            set { _address3 = value; }
        }

        /// public propaty name  :  Address4
        /// <summary>�Z��4�i�A�p�[�g���́j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Z��4�i�A�p�[�g���́j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Address4
        {
            get { return _address4; }
            set { _address4 = value; }
        }

        /// public propaty name  :  CompanyTelNo1
        /// <summary>���Гd�b�ԍ�1�v���p�e�B</summary>
        /// <value>TEL</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ�1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyTelNo1
        {
            get { return _companyTelNo1; }
            set { _companyTelNo1 = value; }
        }

        /// public propaty name  :  CompanyTelNo2
        /// <summary>���Гd�b�ԍ�2�v���p�e�B</summary>
        /// <value>TEL2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ�2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyTelNo2
        {
            get { return _companyTelNo2; }
            set { _companyTelNo2 = value; }
        }

        /// public propaty name  :  CompanyTelNo3
        /// <summary>���Гd�b�ԍ�3�v���p�e�B</summary>
        /// <value>FAX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ�3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyTelNo3
        {
            get { return _companyTelNo3; }
            set { _companyTelNo3 = value; }
        }

        /// public propaty name  :  CompanyTelTitle1
        /// <summary>���Гd�b�ԍ��^�C�g��1�v���p�e�B</summary>
        /// <value>TEL</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ��^�C�g��1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyTelTitle1
        {
            get { return _companyTelTitle1; }
            set { _companyTelTitle1 = value; }
        }

        /// public propaty name  :  CompanyTelTitle2
        /// <summary>���Гd�b�ԍ��^�C�g��2�v���p�e�B</summary>
        /// <value>TEL2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ��^�C�g��2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyTelTitle2
        {
            get { return _companyTelTitle2; }
            set { _companyTelTitle2 = value; }
        }

        /// public propaty name  :  CompanyTelTitle3
        /// <summary>���Гd�b�ԍ��^�C�g��3�v���p�e�B</summary>
        /// <value>FAX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Гd�b�ԍ��^�C�g��3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CompanyTelTitle3
        {
            get { return _companyTelTitle3; }
            set { _companyTelTitle3 = value; }
        }

        /// public propaty name  :  SecMngDiv
        /// <summary>�����Ǘ��敪�v���p�e�B</summary>
        /// <value>0:���_�@1:���_�{��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����Ǘ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SecMngDiv
        {
            get { return _secMngDiv; }
            set { _secMngDiv = value; }
        }
        /// public propaty name  :  DataSaveMonths
        /// <summary>�f�[�^�ۑ������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^�ۑ������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DataSaveMonths
        {
            get { return _dataSaveMonths; }
            set { _dataSaveMonths = value; }
        }

        /// public propaty name  :  DataCompressDt
        /// <summary>�f�[�^���k���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^���k���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DataCompressDt
        {
            get { return _dataCompressDt; }
            set { _dataCompressDt = value; }
        }

        /// public propaty name  :  ResultDtSaveMonths
        /// <summary>���уf�[�^�ۑ������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���уf�[�^�ۑ������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ResultDtSaveMonths
        {
            get { return _resultDtSaveMonths; }
            set { _resultDtSaveMonths = value; }
        }

        /// public propaty name  :  ResultDtCompressDt
        /// <summary>���уf�[�^���k���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���уf�[�^���k���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ResultDtCompressDt
        {
            get { return _resultDtCompressDt; }
            set { _resultDtCompressDt = value; }
        }

        /// public propaty name  :  CaPrtsDtSaveMonths
        /// <summary>���q���i�f�[�^�ۑ������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���q���i�f�[�^�ۑ������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CaPrtsDtSaveMonths
        {
            get { return _caPrtsDtSaveMonths; }
            set { _caPrtsDtSaveMonths = value; }
        }

        /// public propaty name  :  CaPrtsDtCompressDt
        /// <summary>���q���i�f�[�^���k���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���q���i�f�[�^���k���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CaPrtsDtCompressDt
        {
            get { return _caPrtsDtCompressDt; }
            set { _caPrtsDtCompressDt = value; }
        }

        /// public propaty name  :  MasterSaveMonths
        /// <summary>�}�X�^�ۑ������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �}�X�^�ۑ������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MasterSaveMonths
        {
            get { return _masterSaveMonths; }
            set { _masterSaveMonths = value; }
        }

        /// public propaty name  :  MasterCompressDt
        /// <summary>�}�X�^���k���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �}�X�^���k���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MasterCompressDt
        {
            get { return _masterCompressDt; }
            set { _masterCompressDt = value; }
        }

		/// public propaty name  :  RatePriorityDiv
		/// <summary>�|���D��敪�v���p�e�B</summary>
		/// <value>0:���_�D�� 1:�ݒ�敪�D��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
		/// <br>note             :   �|���D��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
		public Int32 RatePriorityDiv
        {
			get{return _ratePriorityDiv;}
			set{_ratePriorityDiv = value;}
        }

        // --- ADD 2011/07/14 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  DataClrExecDate
        /// <summary>�f�[�^�N���A�������s�N�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^�N���A�������s�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DataClrExecDate
        {
            get { return _dataClrExecDate; }
            set { _dataClrExecDate = value; }
        }

        /// public propaty name  :  DataClrExecTime
        /// <summary>�f�[�^�N���A�������s�����b�~���b�v���p�e�B</summary>
        /// <value>HHMMSSXXX</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �f�[�^�N���A�������s�����b�~���b�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DataClrExecTime
        {
            get { return _dataClrExecTime; }
            set { _dataClrExecTime = value; }
        }
        // --- ADD 2011/07/14 ---------------------------------------------------------------------<<<<<
 
        /// <summary>
        /// ���Џ�񃏁[�N�R���X�g���N�^
        /// </summary>
        /// <returns>CompanyInfWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CompanyInfWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CompanyInfWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>CompanyInfWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   CompanyInfWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class CompanyInfWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CompanyInfWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CompanyInfWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CompanyInfWork || graph is ArrayList || graph is CompanyInfWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(CompanyInfWork).FullName));

            if (graph != null && graph is CompanyInfWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CompanyInfWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CompanyInfWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CompanyInfWork[])graph).Length;
            }
            else if (graph is CompanyInfWork)
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
            //���ЃR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CompanyCode
            //���В���
            serInfo.MemberInfo.Add(typeof(Int32)); //CompanyTotalDay
            //��v�N�x
            serInfo.MemberInfo.Add(typeof(Int32)); //FinancialYear
            //����
            serInfo.MemberInfo.Add(typeof(Int32)); //CompanyBiginMonth
            //����2
            serInfo.MemberInfo.Add(typeof(Int32)); //CompanyBiginMonth2
            //����N����
            serInfo.MemberInfo.Add(typeof(Int32)); //CompanyBiginDate
            //�J�n�N�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StartYearDiv
            //�J�n���敪
            serInfo.MemberInfo.Add(typeof(Int32)); //StartMonthDiv
            //���Ж���1
            serInfo.MemberInfo.Add(typeof(string)); //CompanyName1
            //���Ж���2
            serInfo.MemberInfo.Add(typeof(string)); //CompanyName2
            //�X�֔ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //PostNo
            //�Z��1�i�s���{���s��S�E�����E���j
            serInfo.MemberInfo.Add(typeof(string)); //Address1
            //�Z��3�i�Ԓn�j
            serInfo.MemberInfo.Add(typeof(string)); //Address3
            //�Z��4�i�A�p�[�g���́j
            serInfo.MemberInfo.Add(typeof(string)); //Address4
            //���Гd�b�ԍ�1
            serInfo.MemberInfo.Add(typeof(string)); //CompanyTelNo1
            //���Гd�b�ԍ�2
            serInfo.MemberInfo.Add(typeof(string)); //CompanyTelNo2
            //���Гd�b�ԍ�3
            serInfo.MemberInfo.Add(typeof(string)); //CompanyTelNo3
            //���Гd�b�ԍ��^�C�g��1
            serInfo.MemberInfo.Add(typeof(string)); //CompanyTelTitle1
            //���Гd�b�ԍ��^�C�g��2
            serInfo.MemberInfo.Add(typeof(string)); //CompanyTelTitle2
            //���Гd�b�ԍ��^�C�g��3
            serInfo.MemberInfo.Add(typeof(string)); //CompanyTelTitle3
            //�����Ǘ��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //SecMngDiv
            //�f�[�^�ۑ�����
            serInfo.MemberInfo.Add(typeof(Int32)); //DataSaveMonths
            //�f�[�^���k��
            serInfo.MemberInfo.Add(typeof(Int32)); //DataCompressDt
            //���уf�[�^�ۑ�����
            serInfo.MemberInfo.Add(typeof(Int32)); //ResultDtSaveMonths
            //���уf�[�^���k��
            serInfo.MemberInfo.Add(typeof(Int32)); //ResultDtCompressDt
            //���q���i�f�[�^�ۑ�����
            serInfo.MemberInfo.Add(typeof(Int32)); //CaPrtsDtSaveMonths
            //���q���i�f�[�^���k��
            serInfo.MemberInfo.Add(typeof(Int32)); //CaPrtsDtCompressDt
            //�}�X�^�ۑ�����
            serInfo.MemberInfo.Add(typeof(Int32)); //MasterSaveMonths
            //�}�X�^���k��
            serInfo.MemberInfo.Add(typeof(Int32)); //MasterCompressDt
		//�|���D��敪
		serInfo.MemberInfo.Add( typeof(Int32) ); //RatePriorityDiv
            // --- ADD 2011/07/14 --------------------------------------------------------------------->>>>>
            //�f�[�^�N���A�������s�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //DataClrExecDate
            //�����Ǘ��敪
            serInfo.MemberInfo.Add(typeof(Int32)); //DataClrExecTime
            // --- ADD 2011/07/14 ---------------------------------------------------------------------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is CompanyInfWork)
            {
                CompanyInfWork temp = (CompanyInfWork)graph;

                SetCompanyInfWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CompanyInfWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CompanyInfWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CompanyInfWork temp in lst)
                {
                    SetCompanyInfWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CompanyInfWork�����o��(public�v���p�e�B��)
        /// </summary>
        /// 
        /* --- DEL 2011/07/14 --------------------------------------------------------------------->>>>>
        private const int currentMemberCount = 30;
        --- DEL 2011/07/14 ---------------------------------------------------------------------<<<<<*/
        // --- ADD 2011/07/14 --------------------------------------------------------------------->>>>>
        private const int currentMemberCount = 41;
        // --- ADD 2011/07/14 ---------------------------------------------------------------------<<<<<

        /// <summary>
        ///  CompanyInfWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CompanyInfWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetCompanyInfWork(System.IO.BinaryWriter writer, CompanyInfWork temp)
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
            //���ЃR�[�h
            writer.Write(temp.CompanyCode);
            //���В���
            writer.Write(temp.CompanyTotalDay);
            //��v�N�x
            writer.Write(temp.FinancialYear);
            //����
            writer.Write(temp.CompanyBiginMonth);
            //����2
            writer.Write(temp.CompanyBiginMonth2);
            //����N����
            writer.Write(temp.CompanyBiginDate);
            //�J�n�N�敪
            writer.Write(temp.StartYearDiv);
            //�J�n���敪
            writer.Write(temp.StartMonthDiv);
            //���Ж���1
            writer.Write(temp.CompanyName1);
            //���Ж���2
            writer.Write(temp.CompanyName2);
            //�X�֔ԍ�
            writer.Write(temp.PostNo);
            //�Z��1�i�s���{���s��S�E�����E���j
            writer.Write(temp.Address1);
            //�Z��3�i�Ԓn�j
            writer.Write(temp.Address3);
            //�Z��4�i�A�p�[�g���́j
            writer.Write(temp.Address4);
            //���Гd�b�ԍ�1
            writer.Write(temp.CompanyTelNo1);
            //���Гd�b�ԍ�2
            writer.Write(temp.CompanyTelNo2);
            //���Гd�b�ԍ�3
            writer.Write(temp.CompanyTelNo3);
            //���Гd�b�ԍ��^�C�g��1
            writer.Write(temp.CompanyTelTitle1);
            //���Гd�b�ԍ��^�C�g��2
            writer.Write(temp.CompanyTelTitle2);
            //���Гd�b�ԍ��^�C�g��3
            writer.Write(temp.CompanyTelTitle3);
            //�����Ǘ��敪
            writer.Write(temp.SecMngDiv);
            //�f�[�^�ۑ�����
            writer.Write(temp.DataSaveMonths);
            //�f�[�^���k��
            writer.Write(temp.DataCompressDt);
            //���уf�[�^�ۑ�����
            writer.Write(temp.ResultDtSaveMonths);
            //���уf�[�^���k��
            writer.Write(temp.ResultDtCompressDt);
            //���q���i�f�[�^�ۑ�����
            writer.Write(temp.CaPrtsDtSaveMonths);
            //���q���i�f�[�^���k��
            writer.Write(temp.CaPrtsDtCompressDt);
            //�}�X�^�ۑ�����
            writer.Write(temp.MasterSaveMonths);
            //�}�X�^���k��
            writer.Write(temp.MasterCompressDt);
		//�|���D��敪
		writer.Write( temp.RatePriorityDiv );
            // --- ADD 2011/07/14 --------------------------------------------------------------------->>>>>
            //�f�[�^�N���A�������s�N����
            writer.Write(temp.DataClrExecDate);
            //�f�[�^�N���A�������s�����b�~���b
            writer.Write(temp.DataClrExecTime);
            // --- ADD 2011/07/14 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        ///  CompanyInfWork�C���X�^���X�擾
        /// </summary>
        /// <returns>CompanyInfWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CompanyInfWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private CompanyInfWork GetCompanyInfWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            CompanyInfWork temp = new CompanyInfWork();

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
            //���ЃR�[�h
            temp.CompanyCode = reader.ReadInt32();
            //���В���
            temp.CompanyTotalDay = reader.ReadInt32();
            //��v�N�x
            temp.FinancialYear = reader.ReadInt32();
            //����
            temp.CompanyBiginMonth = reader.ReadInt32();
            //����2
            temp.CompanyBiginMonth2 = reader.ReadInt32();
            //����N����
            temp.CompanyBiginDate = reader.ReadInt32();
            //�J�n�N�敪
            temp.StartYearDiv = reader.ReadInt32();
            //�J�n���敪
            temp.StartMonthDiv = reader.ReadInt32();
            //���Ж���1
            temp.CompanyName1 = reader.ReadString();
            //���Ж���2
            temp.CompanyName2 = reader.ReadString();
            //�X�֔ԍ�
            temp.PostNo = reader.ReadString();
            //�Z��1�i�s���{���s��S�E�����E���j
            temp.Address1 = reader.ReadString();
            //�Z��3�i�Ԓn�j
            temp.Address3 = reader.ReadString();
            //�Z��4�i�A�p�[�g���́j
            temp.Address4 = reader.ReadString();
            //���Гd�b�ԍ�1
            temp.CompanyTelNo1 = reader.ReadString();
            //���Гd�b�ԍ�2
            temp.CompanyTelNo2 = reader.ReadString();
            //���Гd�b�ԍ�3
            temp.CompanyTelNo3 = reader.ReadString();
            //���Гd�b�ԍ��^�C�g��1
            temp.CompanyTelTitle1 = reader.ReadString();
            //���Гd�b�ԍ��^�C�g��2
            temp.CompanyTelTitle2 = reader.ReadString();
            //���Гd�b�ԍ��^�C�g��3
            temp.CompanyTelTitle3 = reader.ReadString();
            //�����Ǘ��敪
            temp.SecMngDiv = reader.ReadInt32();
            //�f�[�^�ۑ�����
            temp.DataSaveMonths = reader.ReadInt32();
            //�f�[�^���k��
            temp.DataCompressDt = reader.ReadInt32();
            //���уf�[�^�ۑ�����
            temp.ResultDtSaveMonths = reader.ReadInt32();
            //���уf�[�^���k��
            temp.ResultDtCompressDt = reader.ReadInt32();
            //���q���i�f�[�^�ۑ�����
            temp.CaPrtsDtSaveMonths = reader.ReadInt32();
            //���q���i�f�[�^���k��
            temp.CaPrtsDtCompressDt = reader.ReadInt32();
            //�}�X�^�ۑ�����
            temp.MasterSaveMonths = reader.ReadInt32();
            //�}�X�^���k��
            temp.MasterCompressDt = reader.ReadInt32();
		//�|���D��敪
		temp.RatePriorityDiv = reader.ReadInt32();
            // --- ADD 2011/07/14 --------------------------------------------------------------------->>>>>
            //�f�[�^�N���A�������s�N����
            temp.DataClrExecDate = reader.ReadInt32();
            //�f�[�^�N���A�������s�����b�~���b
            temp.DataClrExecTime = reader.ReadInt32();
            // --- ADD 2011/07/14 ---------------------------------------------------------------------<<<<<

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
        /// <returns>CompanyInfWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CompanyInfWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CompanyInfWork temp = GetCompanyInfWork(reader, serInfo);
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
                    retValue = (CompanyInfWork[])lst.ToArray(typeof(CompanyInfWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

